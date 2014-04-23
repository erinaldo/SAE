Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmEntraPedidos
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        cmditems.Enabled = False
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If txtnitc.Text = "0" Then
                txtcliente.Enabled = True
            Else
                txtcliente.Enabled = False
            End If
        End If
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtnitc, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnitc.Text)
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub
    Public Sub cargarclientes()
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        If items < 50 Then
            FrmSelCliente.gitems.RowCount = 50
        Else
            FrmSelCliente.gitems.RowCount = items + 1
        End If
        For i = 0 To items - 1
            FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
            FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
        Next
        Try
            FrmSelCliente.lbform.Text = "fp"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtcliente.Text = ""
                Dim resultado As MsgBoxResult
                resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    frmterceros.lbform.Text = "fp"
                    frmterceros.txtnit.Text = txtnitc.Text
                    frmterceros.lbestado.Text = "NUEVO"
                    frmterceros.cbtipo.Text = "CLIENTES"
                    frmterceros.rbnatural.Checked = True
                    frmterceros.txtnit.Focus()
                    frmterceros.ShowDialog()
                    txtnitv.Focus()
                End If
            Else  'mostrar uno solo q coinside
                txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''////////////////////////////////////////   
    Private Sub txtnitv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged
        cmditems.Enabled = False
    End Sub
    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitv.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtnitv, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnitv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus
        If txtnitv.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtvendedor.Text = ""
            cargarvendedor()
        ElseIf txtnitv.Text = "0" Then
            txtvendedor.Text = "   [  SIN NIT  ]"
        Else
            Buscarvendedor()
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub
    Public Sub cargarvendedor()
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        If items < 50 Then
            FrmSelVendedor.gitems.RowCount = 50
        Else
            FrmSelVendedor.gitems.RowCount = items + 1
        End If
        For i = 0 To items - 1
            FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item(1)
            FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item(0)
        Next
        Try
            FrmSelVendedor.lbform.Text = "fp"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub Buscarvendedor()
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then  'mostrar todos los articulos porq ninguno coincide
            txtvendedor.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del vendedor no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MsgBox("  PENDIENTE...   ", MsgBoxStyle.Information, "sae")
                cmditems.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtvendedor.Text = tabla.Rows(0).Item(1)
        End If
    End Sub
    '///////////////////////////////////////////
    Public Sub Parametros()
        Dim tabla As New DataTable
        '*********************FACTURA RAPIDA********************************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacts ORDER BY factura DESC;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then Exit Sub
        ''''''''''''''''''DOC PRE'''''''''''''''''''''''''''''''
        If lbestado.Text = "NUEVO" Then
            ''''''''''''''''''NIT CLIENTE PRE'''''''''''''''''''''''''''''''
            If tabla.Rows(0).Item("nitcpre").ToString = "N" Then
                txtnitc.Text = ""
                txtcliente.Text = ""
            Else
                txtnitc.Text = tabla.Rows(0).Item("nitc")
                txtnitc_LostFocus(AcceptButton, AcceptButton)
            End If
            ''''''''''''''''''NIT VENDEDOR PRE'''''''''''''''''''''''''''''''
            If tabla.Rows(0).Item("nitvpre").ToString = "N" Then
                txtnitv.Text = ""
                txtvendedor.Text = ""
            Else
                txtnitv.Text = tabla.Rows(0).Item("nitv")
                txtnitv_LostFocus(AcceptButton, AcceptButton)
            End If
        End If
        '''''''''''''''''' BODEGA PRE-DETERMINADA '''''''''''''''''''''''''
        If tabla.Rows(0).Item("bodpred").ToString = "N" Then
            'lbnumbod.Text = ""
        Else
            'lbnumbod.Text = tabla.Rows(0).Item("idbod")
        End If
        '**************** PARAMETROS G/RALES ****************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        'PRECIO CON IVA INCLUIDO
        lbprecioiva.Text = tabla.Rows(0).Item("ivainclu").ToString
        'FORMULA PARA CALCULAR PRECIO
        lbformula.Text = tabla.Rows(0).Item("formcosto").ToString
    End Sub
    Public Sub bloquear()
        txtcliente.Enabled = False
        txtnitc.Enabled = False
        txtnitv.Enabled = False
        cmditems.Enabled = False
        '******impuestos ************
        valordes.Enabled = False
        valoriva.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Public Sub Desbloquear()
        txtnitc.Enabled = True
        txtnitv.Enabled = True
        cmditems.Enabled = True
        '******impuestos ************
        valordes.Enabled = True
        valoriva.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        PonerEnCero()
        lbestado.Text = "NUEVO"
        valoriva.Text = "16,00"
        gfactura.RowCount = 1

        For i = 0 To gfactura.ColumnCount - 1
            gfactura.Item(i, 0).Value = ""
        Next
        Dim tabla As New DataTable
        Dim sql As String
        Try
            If lblform.Text = "Acta" Then
                sql = "SELECT max(numero) FROM fact_acta_entrega;"
            Else
                sql = "SELECT max(numero) FROM fapipen;"
            End If

            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try

        Try
            If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                txtnumped.Text = NumeroDoc(1)
            Else
                txtnumped.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            txtnumped.Text = NumeroDoc(1)
        End Try
        Parametros()
        CalcularTotales()
        Desbloquear()
        lbusuario.Text = FrmPrincipal.lbuser.Text
        cmditems.Enabled = True
        txtfechaent.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Then
            If lblform.Text = "Acta" Then
                ValidarGuardar("fact_acta_entrega")
            Else
                ValidarGuardar("fapipen")
            End If
            CalcularTotales()
        ElseIf lbestado.Text = "EDITAR" Then
            If lblform.Text = "Acta" Then
                ValidarGuardar("fact_acta_entrega")
            Else
                ValidarGuardar("fapipen")
            End If
            CalcularTotales()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If

    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        If lbestado.Text <> "CONSULTA" Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            lbestado.Text = "EDITAR"
            cmditems.Enabled = True
            Desbloquear()
            Parametros()
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                limpiarAD()
                llenarAD()
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del pedido / cotización (" & txtnumped.Text & ") se van ha eliminar, ¿Desea Borrarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                If lblform.Text = "Acta" Then
                    Eliminar("fact_acta_entrega")
                Else
                    Eliminar("fapipen")
                End If

                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "ELIMINAR PEDIDO COD: " & txtnumped.Text, "", "", "")
                End If
                '.....
                MsgBox("El pedido / cotización fué borrado correctamente de los registros.", MsgBoxStyle.Information, "SAE Control")
                Cerrar()
                lbestado.Text = "BORRADO"
                lbnumero.Text = ""
            End If
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            If lblform.Text = "Acta" Then
                FrmSelPedidos.lbltabla.Text = "Acta"
            Else
                FrmSelPedidos.lbltabla.Text = ""
            End If
            FrmSelPedidos.ShowDialog()
            Dim num As String = ""
            Try
                num = lbnumero.Text
            Catch ex As Exception
            End Try
            If lbestado.Text = "CONSULTA" Then
                If lblform.Text = "Acta" Then
                    BuscarDocumento(txtnumped.Text, "fact_acta_entrega")
                Else
                    BuscarDocumento(txtnumped.Text, "fapipen")
                End If

                lbnumero.Text = num
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '/////////////////////////////////////////////////////////
    Private Sub txtfechaent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfechaent.ValueChanged
        'If txtfechaent.Value < txtfechaped.Value Then
        '    MsgBox("La fecha de entrega NO puede ser MENOR que la fecha del pedido, Verifique.   ", MsgBoxStyle.Information, "Verificando. ")
        '    txtfechaent.Value = txtfechaped.Value
        'End If
    End Sub
    Private Sub txtfechaped_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfechaped.ValueChanged
        'If txtfechaent.Value < txtfechaped.Value Then
        '    MsgBox("La fecha del pedido NO puede ser MAYOR que la fecha de entrega, Verifique.   ", MsgBoxStyle.Information, "Verificando. ")
        '    txtfechaped.Value = txtfechaent.Value
        'End If
    End Sub
    '///////////////////////////////////////////////////////
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        '********************************************
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        FrmItems.txtnumfac.Text = txtnumped.Text
        FrmItems.txtfecha.Text = txtfechaped.Text
        FrmItems.txttipo.Text = "00"
        FrmItems.txttipo2.Text = "PEDIDO/COTIZACIÓN"
        FrmItems.gitems.RowCount = 1
        FrmItems.gitems.Rows.Clear()
        FrmItems.gitems.RowCount = gfactura.RowCount + 1
        For i = 0 To gfactura.RowCount - 1
            FrmItems.gitems.Item("num", i).Value = i + 1
            FrmItems.gitems.Item("tipo", i).Value = gfactura.Item(6, i).Value
            FrmItems.gitems.Item("codigo", i).Value = gfactura.Item(1, i).Value
            FrmItems.gitems.Item("descrip", i).Value = gfactura.Item(2, i).Value
            FrmItems.gitems.Item("cant", i).Value = Fraccion(gfactura.Item(3, i).Value)
            FrmItems.gitems.Item("precio", i).Value = gfactura.Item(4, i).Value
            FrmItems.gitems.Item("bodega", i).Value = gfactura.Item(7, i).Value
            FrmItems.gitems.Item("iva", i).Value = gfactura.Item("iva", i).Value
            '/////////////////////////////////////////////////////////////////////////////
            FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
            FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
            FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
            FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
            FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
        Next
        FrmItems.lbiva.Text = lbprecioiva.Text
        FrmItems.gitems.Columns(1).ReadOnly = False  'tipo I/S
        FrmItems.gitems.Columns(6).ReadOnly = False  'bodega
        FrmItems.gitems.Columns("cc").ReadOnly = True  'NO hay concepto comicionable
        FrmItems.lbform.Text = "fp"
        FrmItems.LbTipoMov.Text = "salidas"
        '********************************************
        FrmItems.gitems.Focus()
        FrmItems.ShowDialog()
        FrmItems.lbiva.Text = "NO"
        FrmItems.gitems.Columns("cc").ReadOnly = False   'NO hay concepto comicionable
        CalcularTotales()
    End Sub

    '*************** TOTALES ///////////////////////////////////
    Private Sub valordes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valordes.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(valordes, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub valordes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valordes.LostFocus
        CalcularTotales()
    End Sub
    Public Sub CalcularTotales()
        Dim v_iva, x, desc, sd, vt, st As Double
        v_iva = 0
        sd = 0
        st = 0
        Try
            For i = 0 To gfactura.RowCount - 1
                Try
                    vt = CDbl(gfactura.Item("Vtotal", i).Value) / (1 + (CDec(gfactura.Item("iva", i).Value) / 100)) 'base
                Catch ex As Exception
                    vt = 0
                End Try
                st = st + vt 'subtotal
                Try
                    desc = vt * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                sd = sd + desc
                Try
                    vt = vt - desc 'nueva base
                Catch ex As Exception
                    vt = 0
                End Try
                Try
                    x = vt * (CDec(gfactura.Item("iva", i).Value) / 100)
                    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                    x = 0
                End Try
                v_iva = v_iva + x
            Next
            txtiva.Text = Moneda(v_iva)
        Catch ex As Exception
            txtiva.Text = Moneda(v_iva)
            valoriva.Text = "0,00"
        End Try
        Try
            valordes.Text = Format(CDbl(valordes.Text), "0.00")
        Catch ex As Exception
            valordes.Text = "0,00"
        End Try
        'txtiva.Text = Moneda(CDbl(valoriva.Text) * CDbl(lbsubtotal.Text) / 100)
        txtdescuento.Text = Moneda(sd)
        txtsubtotal.Text = Moneda(st)
        txttotal.Text = Moneda(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtdescuento.Text))
    End Sub
    '/////////////////////////////////////////////////////////
    Private Sub cmdentrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdentrega.Click
        FrmDatosDeEntrega.lbform.Text = "fp"
        FrmDatosDeEntrega.lborden.Visible = True
        FrmDatosDeEntrega.lbfecha.Visible = True
        FrmDatosDeEntrega.txtorden.Visible = True
        FrmDatosDeEntrega.txtfecha.Visible = True
        FrmDatosDeEntrega.ShowDialog()
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            'Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT formatped FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item("formatped") = "pdf" Then
                If lblform.Text = "Acta" Then
                    GenerarPDF("fact_acta_entrega")
                Else
                    GenerarPDF("fapipen")
                End If

            ElseIf tabla.Rows(0).Item("formatped") = "pdf2" Then
                'GenerarPDF2()

                If lblform.Text = "Acta" Then
                    ver_pdf2("fact_acta_entrega")
                Else
                    ver_pdf2("fapipen")
                End If
            Else
                If lblform.Text = "Acta" Then
                    VerTICKET2("fact_acta_entrega")
                Else
                    VerTICKET2("fapipen")
                End If

            End If
            'Catch ex As Exception
            '    GenerarPDF()
            'End Try
        End If
    End Sub

    Private Sub FrmEntraPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbusuario.Text = FrmPrincipal.lbuser.Text
        If lblform.Text = "Acta" Then
            cmbtipo.Text = "ACTA DE ENTREGA"
        Else
            cmbtipo.Text = "COTIZACION"
        End If

        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        If lblform.Text = "Acta" Then
            primerRegistro("fact_acta_entrega")
        Else
            primerRegistro("fapipen")
        End If
    End Sub
    Sub primerRegistro(ByVal selTabla As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT (numero) FROM " & selTabla & " ORDER BY numero LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerEnCero()
                Exit Sub
            End If
            BuscarDocumento(tabla.Rows(0).Item(0), selTabla)
            lbnumero.Text = "1"
        Catch ex As Exception
            PonerEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click

        If lblform.Text = "Acta" Then
            registroAnterior("fact_acta_entrega")
        Else
            registroAnterior("fapipen")
        End If

    End Sub
    Sub registroAnterior(ByVal selTabla As String)
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT (numero) FROM " & selTabla & " ORDER BY numero LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0), selTabla)
            lbnumero.Text = i + 1
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        If lblform.Text = "Acta" Then
            siguienteRegistro("fact_acta_entrega")
        Else
            siguienteRegistro("fapipen")
        End If

       
    End Sub
    Sub siguienteRegistro(ByVal selTabla As String)
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM " & selTabla & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT (numero) FROM " & selTabla & " ORDER BY numero LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0), selTabla)
                lbnumero.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        If lblform.Text = "Acta" Then
            Ultimo("fact_acta_entrega")
        Else
            Ultimo("fapipen")
        End If
    End Sub
    Sub Ultimo(ByVal selTablas As String)
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM " & selTablas & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT (numero) FROM " & selTablas & " ORDER BY numero LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0), selTablas)
            lbnumero.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal numero As String, ByVal selTabla As String)
        Try
            bloquear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & selTabla & " WHERE numero = '" & numero & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            '*****************************************
            If tabla.Rows.Count = 0 Then
                If selTabla = "fact_acta_entrega" Then
                    MsgBox("El Acta de Entrega  no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                Else
                    MsgBox("El pedido/cotización no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                End If
                Exit Sub
            End If
            '*****************************************
            txtnumped.Text = tabla.Rows(0).Item("numero")
            txtfechaped.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
            txtfechaent.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
            txtnitc.Text = tabla.Rows(0).Item("nitc")
            txtnitc_LostFocus(AcceptButton, AcceptButton)
            txtnitv.Text = tabla.Rows(0).Item("nitv")
            txtnitv_LostFocus(AcceptButton, AcceptButton)
            txtobs.Text = tabla.Rows(0).Item("observ")
            Dim suma As Double = 0
            gfactura.RowCount = tabla.Rows.Count
            For i = 0 To tabla.Rows.Count - 1
                gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("descrip")
                gfactura.Item("cant", i).Value = Fraccion(tabla.Rows(i).Item("cantped"))
                gfactura.Item("valor", i).Value = Moneda(tabla.Rows(i).Item("precio"))
                gfactura.Item("Vtotal", i).Value = Moneda(tabla.Rows(i).Item("vtotal"))
                gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo")
                gfactura.Item("iva", i).Value = tabla.Rows(i).Item("iva")
                suma = suma + Moneda(tabla.Rows(i).Item("vtotal"))
            Next
            lbsubtotal.Text = Moneda(suma)
            CalcularTotales()
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerEnCero()
        End Try
    End Sub

    Public Sub PonerEnCero()
        lbestado.Text = "NULO"
        lbnumero.Text = ""
        txtfechaent.Value = DateTime.Now.ToString("yyyy/MM/dd")
        txtfechaped.Value = DateTime.Now.ToString("yyyy/MM/dd")
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtnitv.Text = ""
        txtvendedor.Text = ""
        txtsubtotal.Text = "0,00"
        lbsubtotal.Text = "0,00"
        txtdescuento.Text = "0,00"
        txtiva.Text = "0,00"
        txttotal.Text = "0,00"
        valordes.Text = "0,00"
        valoriva.Text = "16,00"
        txtobs.Text = ""
        gfactura.RowCount = 1
        gfactura.Rows.Clear()
    End Sub
    '////////// GUARDAR ///////////////////////////////////////////////////
    Public Sub ValidarGuardar(ByVal selTabla As String)
        If txtnumped.Text = "" Then
            txtnumped.Focus()
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtvendedor.Text = "" Then
            MsgBox("No ha digitado datos del vendedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitv.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        End If

        '''''' VALIDAR SI EXIXTE FACTURA NUEVA'''''''''''''''''
        If lbestado.Text = "NUEVO" Then
            Dim sw As Integer = 0
            Do
                Dim t As New DataTable
                myCommand.CommandText = "SELECT numero FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                Refresh()
                If t.Rows.Count > 0 Then
                    If txtnumped.Enabled = True Then
                        MsgBox("Verifique el numero de factura, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
                        txtnumped.Focus()
                        Exit Sub
                    Else
                        Dim tabla As New DataTable
                        myCommand.CommandText = "SELECT max(numero) FROM " & selTabla & ";"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla)
                        Refresh()
                        Try
                            If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                                txtnumped.Text = NumeroDoc(1)
                            Else
                                txtnumped.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            txtnumped.Text = NumeroDoc(1)
                        End Try
                    End If
                Else
                    sw = 1
                End If
            Loop While sw = 0
        End If 'FIN VER SI EXISTE FACTURA NUEVA

        MiConexion(bda)
        If lbestado.Text = "NUEVO" Then
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("codigo", i).Value <> "" Then
                    If lblform.Text = "Acta" Then
                        GuardarActaEntrega(i)
                    Else
                        GuardarFactura(i) 'item
                    End If

                End If
            Next
            bloquear()
            '////////////////////////
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "GUARDAR PEDIDO COD: " & txtnumped.Text, "", "", "")
            End If
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            lbnumero.Text = ""
            lbestado.Text = "GUARDADO"
        ElseIf lbestado.Text = "EDITAR" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del pedido / cotización (" & txtnumped.Text & ") se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                If lblform.Text = "Acta" Then
                    Eliminar("fact_acta_entrega")
                Else
                    Eliminar("fapipen")
                End If

                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item("codigo", i).Value <> "" Then
                        If lblform.Text = "Acta" Then
                            GuardarActaEntrega(i)
                        Else
                            GuardarFactura(i) 'item
                        End If
                    End If
                Next
                bloquear()
                '////////////////////////
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    AuditarMovFac()
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                lbestado.Text = "EDITADO"
            End If
        End If
        Cerrar()
    End Sub
    Public Sub GuardarFactura(ByVal i As Integer)
        txtsubtotal.Text = CDbl(lbsubtotal.Text)
        Timer1.Enabled = False
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?numero", txtnumped.Text)
        myCommand.Parameters.AddWithValue("?item", gfactura.Item("num", i).Value)
        myCommand.Parameters.AddWithValue("?tipo", gfactura.Item("tipo", i).Value)
        myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", i).Value)
        myCommand.Parameters.AddWithValue("?descrip", gfactura.Item("descrip", i).Value)
        myCommand.Parameters.AddWithValue("?cantped", DIN(gfactura.Item("cant", i).Value))
        myCommand.Parameters.AddWithValue("?cantdes", "0")
        myCommand.Parameters.AddWithValue("?precio", DIN(gfactura.Item("valor", i).Value))
        Try
            myCommand.Parameters.AddWithValue("?descto", DIN(gfactura.Item("Vtotal", i).Value) * CDec(txtdescuento.Text))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?descto", "0")
        End Try
        myCommand.Parameters.AddWithValue("?iva", DIN(gfactura.Item("iva", i).Value))
        myCommand.Parameters.AddWithValue("?vtotal", DIN(gfactura.Item("Vtotal", i).Value))
        myCommand.Parameters.AddWithValue("?concomi", "0")
        myCommand.Parameters.AddWithValue("?factur", "")
        Try
            myCommand.Parameters.AddWithValue("?preciva", DIN(gfactura.Item("Vtotal", i).Value) * CDec(gfactura.Item("iva", i).Value))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?preciva", "0")
        End Try
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
        myCommand.Parameters.AddWithValue("?empaque", " ")
        myCommand.Parameters.AddWithValue("?uniemp", "1")
        myCommand.Parameters.AddWithValue("?costo", "0")
        myCommand.Parameters.AddWithValue("?lispre", "0")
        myCommand.Parameters.AddWithValue("?ccosto", "0")
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfechaped.Text))
        myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
        'INSERTAR PEDIDO / COTIZACIÓN
        myCommand.CommandText = "INSERT INTO fapipen VALUES (?numero,?item,?tipo,?codart,?descrip,?cantped,?cantdes,?precio,?descto,?iva,?vtotal," _
                              & "?concomi,?factur,?preciva,?nitc,?nitv,?empaque,?uniemp,?costo,?lispre,?ccosto,?fecha,?observ);"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        Refresh()


    End Sub

    Public Sub GuardarActaEntrega(ByVal i As Integer)
        txtsubtotal.Text = CDbl(lbsubtotal.Text)
        Timer1.Enabled = False
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?numero", txtnumped.Text)
        myCommand.Parameters.AddWithValue("?item", gfactura.Item("num", i).Value)
        myCommand.Parameters.AddWithValue("?tipo", gfactura.Item("tipo", i).Value)
        myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", i).Value)
        myCommand.Parameters.AddWithValue("?descrip", gfactura.Item("descrip", i).Value)
        myCommand.Parameters.AddWithValue("?cantped", DIN(gfactura.Item("cant", i).Value))
        myCommand.Parameters.AddWithValue("?cantdes", "0")
        myCommand.Parameters.AddWithValue("?precio", DIN(gfactura.Item("valor", i).Value))
        Try
            myCommand.Parameters.AddWithValue("?descto", DIN(gfactura.Item("Vtotal", i).Value) * CDec(txtdescuento.Text))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?descto", "0")
        End Try
        myCommand.Parameters.AddWithValue("?iva", DIN(gfactura.Item("iva", i).Value))
        myCommand.Parameters.AddWithValue("?vtotal", DIN(gfactura.Item("Vtotal", i).Value))
        myCommand.Parameters.AddWithValue("?concomi", "0")
        myCommand.Parameters.AddWithValue("?factur", "")
        Try
            myCommand.Parameters.AddWithValue("?preciva", DIN(gfactura.Item("Vtotal", i).Value) * CDec(gfactura.Item("iva", i).Value))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?preciva", "0")
        End Try
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
        myCommand.Parameters.AddWithValue("?empaque", " ")
        myCommand.Parameters.AddWithValue("?uniemp", "1")
        myCommand.Parameters.AddWithValue("?costo", "0")
        myCommand.Parameters.AddWithValue("?lispre", "0")
        myCommand.Parameters.AddWithValue("?ccosto", "0")
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfechaped.Text))
        myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
        'INSERTAR PEDIDO / COTIZACIÓN
        myCommand.CommandText = "INSERT INTO fact_acta_entrega VALUES (?numero,?item,?tipo,?codart,?descrip,?cantped,?cantdes,?precio,?descto,?iva,?vtotal," _
                              & "?concomi,?factur,?preciva,?nitc,?nitv,?empaque,?uniemp,?costo,?lispre,?ccosto,?fecha,?observ);"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        Refresh()


    End Sub
    Public Sub Eliminar(ByVal selTabla As String)
        myCommand.CommandText = "DELETE FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    '***************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Dim viva() As String
    Dim vmon() As Double
    Public Sub AgruparIva(ByVal iva As String, ByVal monto As Double)
        Dim i As Integer = 0
        Dim sw As Integer = 0
        For i = 0 To viva.Length - 1
            If viva(0) = "--" Then
                viva(i) = iva
                vmon(i) = monto
                sw = 1 'ya existe
                Exit For
            Else
                If viva(i) = iva Then
                    vmon(i) = vmon(i) + monto
                    sw = 1 'ya existe
                    Exit For
                End If
            End If
        Next
        If sw = 0 Then
            ReDim Preserve viva(i)
            ReDim Preserve vmon(i)
            viva(i) = iva
            vmon(i) = monto
        End If
    End Sub
    Public Sub GenerarPDF(ByVal selTabla As String)
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
            ReDim Preserve viva(1)
            ReDim Preserve vmon(1)
            viva(0) = "--"
            vmon(0) = 0
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '*********************************************
            Dim valor, vtotal, vdesc, va_iva As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & selTabla & " WHERE numero= '" & txtnumped.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If i = tabla.Rows.Count - 1 Then tope = 130
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    ColocarImg()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("item"), 20, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart"), 40, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantped"), 355, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("iva").ToString), 500, k, 0)
                Try
                    valor = Moneda(tabla.Rows(i).Item("precio")) / (1 + (CDec(tabla.Rows(i).Item("iva")) / 100))
                Catch ex As Exception
                    valor = Moneda(tabla.Rows(i).Item("precio"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(valor), 460, k, 0)
                Try
                    vtotal = Moneda(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("iva")) / 100))
                Catch ex As Exception
                    vtotal = Moneda(tabla.Rows(i).Item("vtotal"))
                End Try
                '********** calculo subtotal con dcto ******
                Try
                    vdesc = vtotal - (vtotal * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                    vdesc = vtotal
                End Try
                '***** valor iva *********
                Try
                    va_iva = (vdesc * (CDbl(tabla.Rows(i).Item("iva")) / 100))
                Catch ex As Exception
                    va_iva = 0
                End Try
                Try
                    AgruparIva(tabla.Rows(i).Item("iva").ToString, va_iva)
                Catch ex As Exception
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(vtotal), 585, k, 0)
                'CONTROL SALTO DE LINEA PARA NOMBRE O DESCRIPCION DEL ARTICULO
                Control_de_linea(tabla.Rows(i).Item("descrip").ToString, 120, 38)
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtsubtotal.Text), 585, k, 0)
            If CDec(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtdescuento.Text), 585, k, 0)
            End If
            Try
                For iiva = 0 To viva.Length - 1
                    If Moneda(viva(iiva)) <> "0,00" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA " & Moneda(viva(iiva)) & "%", 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(vmon(iiva)), 585, k, 0)
                    End If
                Next
            Catch ex As Exception

            End Try
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txttotal.Text), 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "SON: " & Num2Text(txttotal.Text), 10, k, 0)
            k = k - 10
            If txtobs.Text <> "" Then
                cb.ShowTextAligned(50, "Observaciones: ", 10, k, 0)
                Control_de_linea(txtobs.Text, 70, 100)
                k = k - 10
            End If
            k = k - 20
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    'cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 10, 115)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            '*************************************************************
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE Versión 2013, NIT 17957679-1", 10, k, 0)
            k = k - 45
            cb.ShowTextAligned(50, "_____________________________", 20, k, 0)
            cb.ShowTextAligned(50, "_____________________________", 350, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "RECIBIDO", 20, k, 0)
            cb.ShowTextAligned(50, "ENTREGADO", 350, k, 0)
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub ColocarImg()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logoped FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logoped"))
            img.ScaleToFit(80, 180)
            img.SetAbsolutePosition(20, 770)
            img.Alignment = Element.ALIGN_RIGHT
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        Dim tablaR As New DataTable
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='RAPIDA';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
        k = 815
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit") & " " & tablaR.Rows(0).Item("tipocompa"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        k = 760
        cb.ShowTextAligned(50, "PEDIDO / COTIZACIÓN No. " & txtnumped.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA: " & txtfechaped.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "SEÑORES: " & Trim(txtcliente.Text), 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: " & txtnitc.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "VENDEDOR: " & txtvendedor.Text, 20, k, 0)
        '**********************************************************************************************************************
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        '******************************************************** DIAN **************************************************************
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PAGINA: " & pag, 585, k + 25, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 40, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 355, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR UNITARIO", 460, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "% IVA", 500, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal x As Integer, ByVal tam As Integer)
        Try
            salto = 1
            linea = ""
            Dim j As Integer = 0
            For i = 0 To cadena.Length - 1
                Try
                    If cadena(i) = "%" Then
                        If cadena(i + 1) = "%" Then
                            j = 0
                            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                            linea = ""
                            i = i + 1
                            k = k - 10
                        End If
                    Else
                        linea = linea & cadena(i)
                        If j < tam Then
                            j = j + 1
                        Else
                            If cadena(i) = "" Or cadena(i) = " " Or cadena(i) = "," Or cadena(i) = "." Or j >= tam + 3 Then
                                j = 0
                                cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                                linea = ""
                                k = k - 10
                            Else
                                j = j + 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
        Catch ex As Exception

        End Try
    End Sub
    '//////////// GENERAR PDF2//////////////////////////
    Public Sub GenerarPDF2(ByVal selTabla As String)
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 1
            tope = 80
            Dim k2 As Integer = 0
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg2(1)
            ColocarImg2(4)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner2()
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 11)
            cb.BeginText()
            nfact()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            Dim valor, vtotal As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & selTabla & " WHERE numero= '" & txtnumped.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If i = tabla.Rows.Count - 1 Then tope = 160
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    ColocarImg2(1)
                    ColocarImg2(4)
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner2()
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 11)
                    cb.BeginText()
                    nfact()
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    k = k - 10
                End If
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
                '*********************PRINT ITEMS********************************
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda(tabla.Rows(i).Item("cantped")), 50, k, 0)
                Try
                    valor = Moneda(tabla.Rows(i).Item("precio")) / (1 + (CDec(tabla.Rows(i).Item("iva")) / 100))
                Catch ex As Exception
                    valor = Moneda(tabla.Rows(i).Item("precio"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(valor), 468, k + 2, 0)
                Try
                    vtotal = Moneda(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("iva")) / 100))
                Catch ex As Exception
                    vtotal = Moneda(tabla.Rows(i).Item("vtotal"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(vtotal), 568, k + 2, 0)
                Control_de_linea(tabla.Rows(i).Item("descrip").ToString, 82, 56)
                cb.EndText()
                k = k - 3
                ColocarImg2(3) ' linea
                cb.BeginText()
                '*****************************************************************
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = 217
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUBTOTAL $", 390, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCUENTO $", 390, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IVA $", 390, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TOTAL $", 390, k, 0)
            k = k - 10
            k = 217
            '**************************************************************
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtsubtotal.Text), 568, k, 0)
            k = k - 10
            Dim hd As String = ""
            If CDbl(txtdescuento.Text) > 0 Then
                hd = "-"
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, hd & Moneda(txtdescuento.Text), 568, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtiva.Text), 568, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txttotal.Text), 568, k, 0)
            '/////////////////////////////////////////////////////////////////
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = 217
            '*****************COMENTARIO******************************************
            Control_de_linea("SON: " & Num2Text(Moneda(txttotal.Text)), 23, 90)
            k = k - 10
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    'cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 23, 98)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            k = k - 10
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now, 23, k, 0)
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub ColocarImg2(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                'img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\FV1.jpg")
                'img.SetAbsolutePosition(0, 600)
                'img.ScaleToFit(598, 500)
                'img.Alignment = Element.ALIGN_CENTER
                'cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\banner.jpg")
                img.SetAbsolutePosition(10, 595)
                img.ScaleToFit(690, 255)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 2 Then
                'img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\FV2.jpg")
                'img.SetAbsolutePosition(0, k)
                'img.ScaleToFit(598, 50)
                'img.Alignment = Element.ALIGN_CENTER
                'cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\body.jpg")
                img.SetAbsolutePosition(10, 128)
                img.ScaleToFit(690, 470)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 3 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\linea.jpg")
                img.SetAbsolutePosition(23, k)
                img.ScaleToFit(280, 1)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\linea.jpg")
                img.SetAbsolutePosition(302, k)
                img.ScaleToFit(270, 1)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\footer.jpg")
                img.SetAbsolutePosition(20, 20)
                img.ScaleToFit(670, 100)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner2()
        k = 705
        cb.ShowTextAligned(50, Now.Day, 20, k, 0)
        cb.ShowTextAligned(50, Now.Month, 55, k, 0)
        cb.ShowTextAligned(50, Now.Year, 80, k, 0)
        '*****************************************************
        k = 678
        cb.ShowTextAligned(50, txtcliente.Text, 90, k, 0)
        k = k - 23
        cb.ShowTextAligned(50, txtnitc.Text, 90, k, 0)
        k = k - 18
        DatosTercero(txtnitc.Text)
        '**********************************
        k = k - 25
        '***********************************************       
        cb.ShowTextAligned(50, CambiaCadena(Now.AddDays(Val(15)).ToString, 10), 480, k, 0)
        cb.EndText()
        ColocarImg2(2) 'body
        cb.BeginText()
        k = 565
    End Sub
    Public Sub nfact()
        Dim k2 As Integer = 750
        cb.ShowTextAligned(50, "COTIZACION", 445, k2, 0)
        cb.ShowTextAligned(50, "No. " & txtnumped.Text, 445, k2 - 25, 0)
        cb.ShowTextAligned(50, "Página No." & pag, 445, k2 - 50, 0)

    End Sub
    Public Sub DatosTercero(ByVal nit As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim tablac As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM sae.mun WHERE codmun='" & tabla.Rows(0).Item("mun") & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablac)
            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(0).Item("dir"), 40) & " " & tablac.Rows(0).Item("descripcion"), 100, k - 3, 0)
            cb.ShowTextAligned(50, Trim(tabla.Rows(0).Item("telefono") & " " & tabla.Rows(0).Item("celular")), 450, k - 3, 0)
            'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(0).Item("dir"), 40), 75, k, 0)
            'cb.ShowTextAligned(50, Trim(tabla.Rows(0).Item("telefono") & " " & tabla.Rows(0).Item("celular")), 330, k, 0)
        Catch ex As Exception
        End Try
    End Sub
    '////////////// GENERAR TICKET /////////////////////
    Private stringToPrint As String
    Public Sub GenerarTicket(ByVal campo As String)
        Dim file As System.IO.StreamWriter = System.IO.File.CreateText("C:\temp.txt")
        '*************DATOS COMPAÑIA***************************************
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        file.WriteLine(CambiaCadena(tablacomp.Rows(0).Item("descripcion"), 50))
        file.WriteLine("NIT. " & tablacomp.Rows(0).Item("nit"))
        file.WriteLine(tablacomp.Rows(0).Item("direccion"))
        file.WriteLine("TEL. " & tablacomp.Rows(0).Item("telefono1") & "    " & tablacomp.Rows(0).Item("telefono2"))
        '************** FACTURA ******************************
        file.WriteLine("FECHA: " & Now)
        If campo = "fact" Then
            file.WriteLine("FACTURA No. 00000 ")
        ElseIf campo = "ped" Then
            file.WriteLine("PEDIDO No. 00000 ")
        Else
            file.WriteLine("COTIZACIÓN No. 00000")
        End If
        file.WriteLine("SEÑORES: NOMBRE DEL CLIENTE")
        file.WriteLine("NIT/CEDULA: NIT / CEDULA")
        file.WriteLine("VENDEDOR: NOMBRE DEL VENDEDOR")
        file.WriteLine("Forma De Pago: Efectivo: $0,00")
        '*************** CUERPO ********************************
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                  Cant      Unit          Iva         V/total")
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("01001  producto  01001")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("02003  producto  02003")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("03016  producto  03016")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                                         Sub Total:   0,00")
        file.WriteLine("                                         Iva:         0,00")
        file.WriteLine("                                         Total:       0,00")
        file.WriteLine(Chr(13))
        '*****************************************************************************
        file.WriteLine("Resolución DIAN 00000000 del 00-00-000")
        file.WriteLine("Factura por computador Nro. 1 al 1000")
        file.WriteLine("---------------------------------------------------------------")
        'If Trim(txtcomentario.Text) <> "" Then file.WriteLine(txtcomentario.Text)
        file.WriteLine("Impreso a la fecha y hora: " & Now)
        file.WriteLine("Factura elaborada por computadora en el Software")
        file.WriteLine("de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text)
        file.WriteLine("---------------------------------------------------------------")
        file.Close()
        Dim docName As String = "temp.txt"
        Dim docPath As String = "c:\"
        imprimir.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        imprimir.Print()
    End Sub
    Private Sub imprimir_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles imprimir.PrintPage

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lblform.Text = "Acta" Then
            ver_pdf2("fact_acta_entrega")
        Else
            ver_pdf2("fapipen")
        End If

    End Sub
    Private Sub ver_pdf2(ByVal selTabla As String)
        Dim nit As String = ""
        Dim nom As String = ""
        Dim dire As String = ""
        Dim tel As String = ""
        Dim email As String = ""
        Dim fec As String = ""
        Dim fac As String = ""
        Dim cli As String = ""
        Dim Ncli As String = ""
        Dim vend As String = ""

        Dim dirC As String = ""
        Dim telC As String = ""

        Dim obs As String = ""

        'Dim log As String = ""

        Dim lett As String = ""
        Dim des As String = ""
        Dim tcomp As String = ""

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        lett = Num2Text(Moneda(txttotal.Text))

        MiConexion(bda)
        Cerrar()

        sql2 = "SELECT f.nitc, CONCAT(t.nombre,' ', t.apellidos) as nom, t.telefono, t.dir, f.observ , (Select tipocompa from parafacts where factura= 'RAPIDA' ) as tcomp " _
        & " FROM " & selTabla & " f LEFT JOIN terceros t ON f.nitc= t.nit WHERE f.item='1' AND numero='" & txtnumped.Text & "'"

        Dim tabla3 As New DataTable
        tabla3 = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)
        If tabla3.Rows.Count > 0 Then
            dirC = tabla3.Rows(0).Item("dir").ToString
            telC = tabla3.Rows(0).Item("telefono").ToString
            obs = tabla3.Rows(0).Item("observ").ToString
            tcomp = tabla3.Rows(0).Item("tcomp").ToString
        End If

        Dim vd As String = ""
        vd = valordes.Text.Replace(",", ".")
        sql3 = " SELECT iva , SUM(( (((vtotal/(1+(iva/100))))-(((vtotal/(1+(iva/100)))) * (" & vd & "/100)))*(iva/100)) )as IVA FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "' GROUP BY iva "

        Dim tabla4 As New DataTable
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        If txtiva.Text <> "0,00" Then
            For i = 0 To tabla4.Rows.Count - 1
                If tabla4.Rows(i).Item(1).ToString <> 0 Then
                    v_iva = v_iva & Moneda(tabla4.Rows(i).Item(1).ToString) & vbCrLf
                    tv_iva = tv_iva & "IVA " & (tabla4.Rows(i).Item(0).ToString) & " %" & vbCrLf
                End If
            Next
        Else
            tv_iva = "IVA "
            v_iva = "0,00"
        End If

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        If Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2")) <> "" Then
            tel = tel & " TEL: " & Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        End If
        If tabla2.Rows(0).Item("emailconta") <> "" Then
            tel = tel & " EMAIL: " & tabla2.Rows(0).Item("emailconta")
        End If
        If tabla2.Rows(0).Item("direccion") <> "" Then
            tel = tel & " DIR:" & tabla2.Rows(0).Item("direccion")
        End If

        'email = tabla2.Rows(0).Item("emailconta")
        'dire = tabla2.Rows(0).Item("direccion")

        fac = txtnumped.Text
        fec = txtfechaped.Text.ToString
        cli = txtcliente.Text
        Ncli = txtnitc.Text
        vend = txtvendedor.Text
        des = txtdescuento.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        sql = "SELECT item as tipodoc, codart as idbod, descrip as comentario,  CAST((cantped) AS CHAR(20)) AS   nitc, (precio/(1+(iva/100))) as nitvpre, iva as cualfp, cantped * (precio/(1+(iva/100)))  as nitv, " _
        & " (select sum(vtotal) from " & selTabla & " where numero='" & txtnumped.Text & "' group by numero) as margmin, " _
        & " (select logofac from parafacts where factura='RAPIDA') as logofac" _
        & " FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "'" _
        & " ORDER BY item"


        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacRap.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacRap.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtelef As New ParameterField
            Dim Premail As New ParameterField

            Dim prefec As New ParameterField
            Dim prefac As New ParameterField
            Dim preNcl As New ParameterField
            Dim precl As New ParameterField
            Dim preven As New ParameterField
            Dim prefecv As New ParameterField
            Dim prereso As New ParameterField
            Dim prenfac As New ParameterField
            Dim pretelc As New ParameterField
            Dim predirc As New ParameterField
            Dim precom As New ParameterField
            Dim preobs As New ParameterField
            Dim prpg As New ParameterField
            Dim prtf As New ParameterField
            Dim prlt As New ParameterField
            Dim prds As New ParameterField
            Dim prviva As New ParameterField
            Dim prtviva As New ParameterField

            Dim prOcon As New ParameterField
            Dim prTOcon As New ParameterField
            Dim prTcomp As New ParameterField
            Dim prTipo As New ParameterField

            Dim prO As New ParameterField
            Dim prT As New ParameterField

            Dim prrtf As New ParameterField
            Dim prrti As New ParameterField
            Dim prrtic As New ParameterField

            Dim prtotalg As New ParameterField
            Dim prsubtotal As New ParameterField
            Dim prrtc As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "dir"
            Prperiodo.CurrentValues.AddValue(dire.ToString)
            Prtelef.Name = "telef"
            Prtelef.CurrentValues.AddValue(tel.ToString)
            Premail.Name = "email"
            Premail.CurrentValues.AddValue(email.ToString)

            prefec.Name = "fec"
            prefec.CurrentValues.AddValue(fec.ToString)
            prefac.Name = "fac"
            prefac.CurrentValues.AddValue(fac.ToString)
            precl.Name = "cli"
            precl.CurrentValues.AddValue(cli.ToString)
            preNcl.Name = "ncli"
            preNcl.CurrentValues.AddValue(Ncli.ToString)
            preven.Name = "vend"
            preven.CurrentValues.AddValue(vend.ToString)
            prefecv.Name = "fecV"
            prefecv.CurrentValues.AddValue("")
            predirc.Name = "dirC"
            predirc.CurrentValues.AddValue(dirC.ToString)
            prereso.Name = "reso"
            prereso.CurrentValues.AddValue("")
            pretelc.Name = "telC"
            pretelc.CurrentValues.AddValue(telC.ToString)
            prenfac.Name = "nfac"
            prenfac.CurrentValues.AddValue("")
            precom.Name = "coment"
            precom.CurrentValues.AddValue("")
            preobs.Name = "obs"
            preobs.CurrentValues.AddValue(obs.ToString)
            prpg.Name = "fpago"
            prpg.CurrentValues.AddValue("")
            prtf.Name = "tfac"
            prtf.CurrentValues.AddValue("")
            prlt.Name = "lt"
            prlt.CurrentValues.AddValue(lett.ToString)
            prds.Name = "desc"
            prds.CurrentValues.AddValue(des.ToString)
            prviva.Name = "v_iva"
            prviva.CurrentValues.AddValue(v_iva.ToString)
            prtviva.Name = "tv_iva"
            prtviva.CurrentValues.AddValue(tv_iva.ToString)

            prOcon.Name = "conc"
            prOcon.CurrentValues.AddValue("")
            prTOcon.Name = "t_conc"
            prTOcon.CurrentValues.AddValue("")

            prTcomp.Name = "tcomp"
            prTcomp.CurrentValues.AddValue(tcomp.ToString)
            prTipo.Name = "tipo"
            prTipo.CurrentValues.AddValue(cmbtipo.Text.ToString & " N°")

            prO.Name = "otro"
            prO.CurrentValues.AddValue(Moneda(0))
            prT.Name = "t_otro"
            prT.CurrentValues.AddValue("")

            prrtf.Name = "rtf"
            prrtf.CurrentValues.AddValue(Moneda(0))
            prrti.Name = "rti"
            prrti.CurrentValues.AddValue(Moneda(0))
            prrtic.Name = "rtic"
            prrtic.CurrentValues.AddValue(Moneda(0))

            prtotalg.Name = "totalG"
            prtotalg.CurrentValues.AddValue(Moneda(txttotal.Text))
            prsubtotal.Name = "subtotal"
            prsubtotal.CurrentValues.AddValue(Moneda(txtsubtotal.Text))
            prrtc.Name = "rtc"
            prrtc.CurrentValues.AddValue(Moneda(0))



            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtelef)
            prmdatos.Add(Premail)
            prmdatos.Add(prefec)
            prmdatos.Add(prefac)
            prmdatos.Add(precl)
            prmdatos.Add(preNcl)
            prmdatos.Add(preven)
            prmdatos.Add(predirc)
            prmdatos.Add(pretelc)
            prmdatos.Add(prefecv)
            prmdatos.Add(prenfac)
            prmdatos.Add(prereso)
            prmdatos.Add(precom)
            prmdatos.Add(preobs)
            prmdatos.Add(prpg)
            prmdatos.Add(prtf)
            prmdatos.Add(prlt)
            prmdatos.Add(prds)
            prmdatos.Add(prviva)
            prmdatos.Add(prtviva)

            prmdatos.Add(prTOcon)
            prmdatos.Add(prOcon)
            prmdatos.Add(prTcomp)
            prmdatos.Add(prTipo)

            prmdatos.Add(prO)
            prmdatos.Add(prT)

            prmdatos.Add(prrtf)
            prmdatos.Add(prrti)
            prmdatos.Add(prrtic)

            prmdatos.Add(prtotalg)
            prmdatos.Add(prsubtotal)
            prmdatos.Add(prrtc)

            FrmReportFacRap.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRap.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub VerTICKET2(ByVal selTabla As String)

        Try

            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""
            Dim nit As String = ""
            Dim nom As String = ""
            Dim dire As String = ""
            Dim tel As String = ""
            Dim email As String = ""
            Dim fec As String = ""
            Dim fac As String = ""
            Dim hr As String = ""
            Dim p As String = ""
            Dim vend As String = ""
            Dim tpago As String = ""
            Dim reso As String = ""
            Dim tfac As String = ""
            Dim tcomp As String = ""
            Dim pre As String = ""
            Dim coment As String = ""

            p = PerActual(0).ToString & PerActual(1).ToString

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT " & tabla2.Rows(0).Item("nit")
            tel = "TEL " & Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
            dire = tabla2.Rows(0).Item("direccion")

            'Informacion Fact
            fac = "Cotizacion No:" & pre & " " & txtnumped.Text
            fec = CambiaCadena(txtfechaped.Value.ToString, 10)
            vend = " " & txtnitv.Text & " " & txtvendedor.Text


            Dim vd As String = ""
            vd = valordes.Text.Replace(",", ".")
            sql3 = " SELECT iva , SUM(( (((vtotal/(1+(iva/100))))-(((vtotal/(1+(iva/100)))) * (" & vd & "/100)))*(iva/100)) )as IVA FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "' GROUP BY iva "

            Dim tabla4 As New DataTable
            Dim v_iva As String = ""
            Dim tv_iva As String = ""
            tabla4 = New DataTable
            myCommand.CommandText = sql3
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)

            If txtiva.Text <> "0,00" Then
                For i = 0 To tabla4.Rows.Count - 1
                    If tabla4.Rows(i).Item(1).ToString <> 0 Then
                        v_iva = v_iva & Moneda(tabla4.Rows(i).Item(1).ToString) & vbCrLf
                        tv_iva = tv_iva & "IVA " & (tabla4.Rows(i).Item(0).ToString) & " %" & vbCrLf
                    End If
                Next
            Else
                tv_iva = "IVA "
                v_iva = "0,00"
            End If


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            sql = "SELECT item as tipodoc, codart as idbod, descrip as nomart, " _
            & " cantped as can_emp, (precio/(1+(iva/100))) as precio, iva as numfact, cantped * (precio/(1+(iva/100)))  as nitv, " _
            & " (select sum(vtotal) from " & selTabla & " where numero='" & txtnumped.Text & "' group by numero) as margmin " _
            & " FROM " & selTabla & " WHERE numero='" & txtnumped.Text & "'" _
            & " ORDER BY item"

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacTicket.rpt")
            CrReport.SetDataSource(tabla)
            'FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            CrReport.SetParameterValue("comp", nom.ToString)
            CrReport.SetParameterValue("nit", nit.ToString)
            CrReport.SetParameterValue("dir", dire.ToString)
            CrReport.SetParameterValue("tel", tel.ToString)
            CrReport.SetParameterValue("fac", fac.ToString)
            CrReport.SetParameterValue("fec", fec.ToString)
            CrReport.SetParameterValue("v_iva", v_iva.ToString)
            CrReport.SetParameterValue("tv_iva", tv_iva.ToString)
            CrReport.SetParameterValue("nomc", txtcliente.Text.ToString)
            CrReport.SetParameterValue("cc_cl", txtnitc.Text.ToString)
            CrReport.SetParameterValue("vend", vend.ToString)
            CrReport.SetParameterValue("des", txtdescuento.Text.ToString)
            CrReport.SetParameterValue("total", txttotal.Text.ToString)
            CrReport.SetParameterValue("reso", reso.ToString)
            CrReport.SetParameterValue("reso2", tfac.ToString)
            CrReport.SetParameterValue("tcomp", tcomp.ToString)
            CrReport.SetParameterValue("rtiv", "0,00")
            CrReport.SetParameterValue("rtic", "0,00")
            CrReport.SetParameterValue("rtf", "0,00")
            CrReport.SetParameterValue("coment", coment.ToString)
            CrReport.SetParameterValue("pago", "")
            CrReport.SetParameterValue("vpagos", "")

            CrReport.PrintToPrinter(1, False, 0, 0)
            CrReport.Dispose()

            'FrmVisorInformes.ShowDialog()
            'CrReport.Dispose()
        Catch ex As Exception
            MsgBox("Error al imprimir el Ticket " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try

    End Sub
    Private Sub limpiarAD()
        txtnitc2.Text = ""
        txtnitv2.Text = ""
        txtfechaped2.Text = ""
        txttotal2.Text = ""
        txtobs2.Text = ""
        valordes2.Text = ""
        gfactura2.Rows.Clear()
    End Sub
    Private Sub llenarAD()
        txtnitc2.Text = txtnitc.Text
        txtnitv2.Text = txtnitv.Text
        txtfechaped2.Text = txtfechaped.Value.ToString
        txttotal2.Text = txttotal.Text
        txtobs2.Text = txtobs.Text
        valordes2.Text = valordes.Text
        gfactura2.RowCount = gfactura.RowCount
        For i = 0 To gfactura2.RowCount - 1
            Try
                gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", i).Value
                gfactura2.Item("descrip2", i).Value = gfactura.Item("descrip", i).Value
                gfactura2.Item("cant2", i).Value = gfactura.Item("cant", i).Value
                gfactura2.Item("tipo2", i).Value = gfactura.Item("tipo", i).Value
                gfactura2.Item("bodega2", i).Value = gfactura.Item("bodega", i).Value
                gfactura2.Item("cc2", i).Value = gfactura.Item("cc", i).Value
                gfactura2.Item("iva2", i).Value = gfactura.Item("iva", i).Value
                gfactura2.Item("valor2", i).Value = gfactura.Item("valor", i).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
    End Sub
    Private Sub AuditarMovFac()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                Dim camp As String = ""
                Dim ant As String = ""
                Dim nue As String = ""

                lbespera.Visible = True

                If txtnitc.Text <> txtnitc2.Text Then
                    camp = camp & "CLIENTE; "
                    ant = ant & txtnitc2.Text & "; "
                    nue = nue & txtnitc.Text & "; "
                End If
                If txtnitv.Text <> txtnitv2.Text Then
                    camp = camp & "VENDEDOR;"
                    ant = ant & txtnitv2.Text & "; "
                    nue = nue & txtnitv.Text & "; "
                End If
                If txtfechaped.Value.ToString <> txtfechaped2.Text Then
                    camp = camp & "FECHA;"
                    ant = ant & txtfechaped2.Text & "; "
                    nue = nue & txtfechaped.Text & "; "
                End If
                If txttotal.Text <> txttotal2.Text Then
                    camp = camp & "VALOR FACT;"
                    ant = ant & txttotal2.Text & "; "
                    nue = nue & txttotal.Text & "; "
                End If
                If txtobs.Text <> txtobs2.Text Then
                    camp = camp & "OBSERVACION; "
                    ant = ant & txtobs2.Text & "; "
                    nue = nue & txtobs.Text & "; "
                End If
                If valordes.Text <> valordes2.Text Then
                    camp = camp & "% DESCUENTO; "
                    ant = ant & valordes2.Text & "; "
                    nue = nue & valordes.Text & "; "
                End If


                ' No de Items
                Dim ok = ""
                For i = 0 To gfactura2.RowCount - 1
                    For j = 0 To gfactura.RowCount - 1
                        If gfactura2.Item("codigo2", i).Value <> "" Then
                            If gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value Then
                                ok = "e"
                                Exit For
                            End If
                        End If
                    Next
                    If gfactura2.Item("codigo2", i).Value <> "" Then
                        If ok <> "e" Then
                            camp = camp & "ELIMINADO ITEM COD: " & gfactura2.Item("codigo2", i).Value & "; "
                            ant = ant & " ;"
                            nue = nue & " ;"
                        End If
                        ok = ""
                    End If
                Next

                ok = ""
                For j = 0 To gfactura.RowCount - 1
                    For i = 0 To gfactura2.RowCount - 1
                        If gfactura.Item("codigo", j).Value <> "" Then
                            If gfactura.Item("codigo", j).Value = gfactura2.Item("codigo2", i).Value Then
                                ok = "e"
                                Exit For
                            End If
                        End If
                    Next
                    If gfactura.Item("codigo", j).Value <> "" Then
                        If ok <> "e" Then
                            camp = camp & "NUEVO ITEM COD: " & gfactura.Item("codigo", j).Value & "; "
                            ant = ant & " ;"
                            nue = nue & " ;"
                        End If
                        ok = ""
                    End If
                Next

                ' Validar datos articulos
                For i = 0 To gfactura2.RowCount - 1
                    For j = 0 To gfactura.RowCount - 1
                        If gfactura2.Item("codigo2", i).Value <> "" Then
                            If gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value Then
                                If gfactura2.Item("cant2", i).Value <> gfactura.Item("cant", j).Value Then
                                    camp = camp & "CANTIDAD; "
                                    ant = ant & gfactura2.Item("cant2", i).Value & "; "
                                    nue = nue & gfactura.Item("cant", i).Value & "; "
                                End If
                                If gfactura2.Item("valor2", i).Value <> gfactura.Item("valor", j).Value Then
                                    camp = camp & "VALOR; "
                                    ant = ant & gfactura2.Item("valor2", i).Value & "; "
                                    nue = nue & gfactura.Item("valor", i).Value & "; "
                                End If
                                Exit For
                            End If
                        End If
                    Next
                Next
                Guar_MovUser("FACTURACION", "MODIFICAR PEDIDO COD: " & txtnumped.Text, camp, ant, nue)

                lbespera.Visible = False
            Catch ex As Exception
                lbespera.Visible = False
                bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

End Class
