Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmOrdenCompra
    Private Sub FrmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbusuario.Text = FrmPrincipal.lbuser.Text
        Parametros()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Public Sub Parametros()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM par_comp LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Exit Sub
        Else
            lbsolnumcom.Text = Trim(tabla.Rows(0).Item("sol_num_com").ToString)
            lbcanfact.Text = Trim(tabla.Rows(0).Item("can_fact").ToString)
            lbaumenta.Text = Trim(tabla.Rows(0).Item("fs_aum_inv").ToString)
            lbimpap.Text = Trim(tabla.Rows(0).Item("imp_ap").ToString)
            lbformat.Text = Trim(tabla.Rows(0).Item("format_fp").ToString)
        End If
    End Sub
    Public Sub bloquear()

        txtnumfac.Enabled = False
        txtnitc.Enabled = False
        txtfecha.Enabled = False
        txtfecha_ent.Enabled = False
        txtobservaciones.Enabled = False
        cmditems.Enabled = False
        txtflete.Enabled = False
        '******impuestos ************
        valordes.Enabled = False
        valoriva.Enabled = False
        valorret.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        cmdnuevo_rep.Enabled = True
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        cmditems.Enabled = False
    End Sub
    Public Sub Desbloquear()
        txtnitc.Enabled = True
        txtfecha.Enabled = True
        txtfecha_ent.Enabled = True
        txtobservaciones.Enabled = True
        cmditems.Enabled = True
        txtflete.Enabled = True
        '******impuestos ************
        valordes.Enabled = True
        valoriva.Enabled = True
        valorret.Enabled = True
        '****** comandos ***************
        cmditems.Enabled = True
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        cmdnuevo_rep.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Public Sub PonerenCero()

        Timer1.Enabled = False
        lbestado.Text = "NULO"
        cmditems.Enabled = False
        txtnumfac.Text = ""
        lbnumero.Text = ""
        lbusuario.Text = FrmPrincipal.lbuser.Text
        ' txtfecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
        Try
            txtfecha.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtfecha.Enabled = True Then
                txtfecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtfecha.Value = CDate(PerActual & "/" & "01")
            End If
        End Try
        txtfecha_ent.Value = txtfecha.Value
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtsubtotal.Text = "0,00"
        txtdescuento.Text = "0,00"
        txtret.Text = "0,00"
        txtiva.Text = "0,00"
        txtflete.Text = "0,00"
        txttotal.Text = "0,00"
        valordes.Text = "0,00"
        valoriva.Text = "0,00"
        valorret.Text = "0,00"
        lbsubtotal.Text = "0,00"
        txtobservaciones.Text = ""
        gfactura.RowCount = 1
        lbusuario.Text = ""
        txtobservaciones.Text = ""
        txtfecha.Enabled = False
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        gfp.Rows.Clear()
        gfp.RowCount = 1
        CalcularTotales()
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else

            Dim tabla As New DataTable
            PonerenCero()
            myCommand.CommandText = "SELECT max(numero) FROM pedi_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Try
                If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                txtnumfac.Text = NumeroDoc(1)
            End Try
            lbusuario.Text = FrmPrincipal.lbuser.Text
            lbestado.Text = "NUEVO"
            Desbloquear()
            txtnitc.Focus()


        End If
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Then
            ValidarGuardar()
        ElseIf lbestado.Text = "EDITAR" Then
            ValidarGuardar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
        CalcularTotales()
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
            Desbloquear()
            cmditems.Enabled = True
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            'Eliminar()
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelOrdenesCompras.lbremis.Text = ""
            FrmSelOrdenesCompras.lbform.Text = "Orden"
            FrmSelOrdenesCompras.ShowDialog()
            Dim num As String = ""
            Try
                num = lbnumero.Text
            Catch ex As Exception
            End Try
            If lbestado.Text = "CONSULTA" Then
                BuscarDoc(txtnumfac.Text)
                lbnumero.Text = num
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    'BURCAR DESPLAZAMIENTO
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp ORDER BY numero LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerenCero()
                Exit Sub
            End If
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnumero.Text = "1"
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            PonerenCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnumero.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp ORDER BY numero LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnumero.Text) - 1
            Refresh()
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp ORDER BY numero LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnumero.Text) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                Exit Sub
            End If
            myCommand.CommandText = "SELECT DISTINCT(numero) FROM pedi_comp ORDER BY numero LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDoc(ByVal numero As String)
        Try
            Timer1.Enabled = False
            PonerenCero()
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT * " _
                                   & "FROM pedi_comp " _
                                   & "WHERE numero = '" & numero & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("La factura no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                Exit Sub
            End If
            txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("numero"))
            txtnitc.Text = tabla.Rows(0).Item("nitc")
            lbusuario.Text = tabla.Rows(0).Item("usuario")
            txtfecha.Text = tabla.Rows(0).Item("fechaped")
            txtfecha_ent.Text = tabla.Rows(0).Item("fecharec")
            'descuento
            valordes.Text = tabla.Rows(0).Item("por_desc")
            txtdescuento.Text = tabla.Rows(0).Item("descuento")
            'rtf
            valorret.Text = tabla.Rows(0).Item("por_rtf")
            txtret.Text = tabla.Rows(0).Item("rtf")
            'iva
            valoriva.Text = tabla.Rows(0).Item("por_iva")
            txtiva.Text = tabla.Rows(0).Item("iva")
            'fletes
            txtflete.Text = tabla.Rows(0).Item("fle")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            txtobservaciones.Text = tabla.Rows(0).Item("observ")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lbestado.Text = "CONSULTA"
            gfactura.RowCount = items + 1
            Dim suma As Double = 0
            Try
                For i = 0 To items - 1
                    gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                    gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo")
                    gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("cod_art")
                    gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nom_art")
                    Try
                        gfactura.Item("cant", i).Value = Decimales(tabla.Rows(i).Item("cantped").ToString)
                    Catch ex As Exception
                    End Try
                    Try
                        gfactura.Item("recibida", i).Value = Decimales(tabla.Rows(i).Item("cantrec").ToString)
                    Catch ex As Exception
                    End Try
                    gfactura.Item("valor", i).Value = tabla.Rows(i).Item("valor")
                    gfactura.Item("Vtotal", i).Value = tabla.Rows(i).Item("vtotal")
                    gfactura.Item("iva", i).Value = tabla.Rows(i).Item("por_iva")
                    gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                    suma = suma + tabla.Rows(i).Item("vtotal")
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            '*****************************************************
            lbsubtotal.Text = suma
            bloquear()
            cmditems.Enabled = False
            CalcularTotales()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '*********** CALCULAR TOTALES *******************
    Public Sub CalcularTotales()
        Dim v_iva, x, desc, vt, st, sd As Double
        v_iva = 0
        st = 0
        sd = 0
        Try
            For i = 0 To gfactura.RowCount - 1

                Try
                    vt = CDbl(gfactura.Item("Vtotal", i).Value) / (1 + (CDbl(gfactura.Item("iva", i).Value) / 100)) 'base
                Catch ex As Exception
                    vt = 0
                End Try

                Try
                    desc = CDbl(gfactura.Item("Vtotal", i).Value) * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                'Try
                '    vt = CDbl(gfactura.Item("Vtotal", i).Value) - desc
                'Catch ex As Exception
                '    vt = 0
                'End Try
                'Try
                '    x = vt - (vt / (1 + (CDec(gfactura.Item("iva", i).Value) / 100)))
                '    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                'Catch ex As Exception
                '    'MsgBox(ex.ToString)
                '    x = 0
                'End Try

                '

                st = st + vt 'subtotal
                Try
                    desc = vt * (CDbl(valordes.Text) / 100)
                    'desc = vt * (CDbl(valordes.Text) / 100) 
                Catch ex As Exception
                    desc = 0
                End Try

                ' desc = CDbl(lbdescuento.Text)
                sd = sd + desc
                ' sd = desc
                Try
                    vt = vt - desc 'nueva base
                Catch ex As Exception
                    vt = 0
                End Try
                Try
                    x = vt * (CDbl(gfactura.Item("iva", i).Value) / 100)
                    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                    x = 0
                End Try
                '

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
        txtdescuento.Text = Moneda(sd)
        '  txtdescuento.Text = Moneda(CDbl(valordes.Text) * CDbl(lbsubtotal.Text) / 100)
        Try
            valorret.Text = Format(CDbl(valorret.Text), "0.00")
        Catch ex As Exception
            valorret.Text = "0,00"
        End Try
        txtsubtotal.Text = Moneda(st)
        'txtsubtotal.Text = Moneda(CDbl(lbsubtotal.Text) - CDbl(txtiva.Text) )
        txtret.Text = Moneda(CDbl(valorret.Text) * CDbl(txtsubtotal.Text) / 100)
        txttotal.Text = Moneda(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtret.Text) - CDbl(txtdescuento.Text))
        txtflete.Text = Moneda(CDbl(txtflete.Text))
        txttotal.Text = Moneda(CDbl(txttotal.Text) + CDbl(txtflete.Text))
        If gfp.RowCount = 1 Then
            gfp.Item("monto", 0).Value = txttotal.Text
        End If
    End Sub
    '************************************************
    'VALIDACIONES
    Private Sub txtfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfecha.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If txtfecha.Value > txtfecha_ent.Value Then
            MsgBox("La fecha del pedido debe ser mayor o igual a la fecha de entrega, Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
        End If
    End Sub
    Private Sub txtfecha_ent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfecha_ent.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtfecha_ent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfecha_ent.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If txtfecha.Value > txtfecha_ent.Value Then
            MsgBox("La fecha del pedido debe ser mayor o igual a la fecha de entrega, Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
        End If
    End Sub
    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        txtnumfac.Text = NumeroDoc(txtnumfac.Text)
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
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
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "oc"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
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
            resultado = MsgBox("El nit/cédula del proveedor no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "oc"
                frmterceros.txtnit.Text = txtnitc.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "PROVEEDOR"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    '********* PORCENTAJES ***************
    Private Sub valordes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valordes.KeyPress
        ValidarPorcentaje(valordes, e)
    End Sub
    Private Sub valordes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valordes.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valorret_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valorret.KeyPress
        ValidarPorcentaje(valorret, e)
    End Sub
    Private Sub valorret_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valorret.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valoriva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valoriva.KeyPress
        ValidarPorcentaje(valoriva, e)
    End Sub
    Private Sub valoriva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valoriva.LostFocus
        CalcularTotales()
    End Sub
    Private Sub txtflete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtflete.KeyPress
        ValidarMoneda(txtflete, e)
    End Sub
    Private Sub txtflete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtflete.LostFocus
        CalcularTotales()
    End Sub
    '***************   
    Public Sub ValidarGuardar()
        If txtnumfac.Text = "" Then
            MsgBox("No ha escogido el numero del pedido, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnumfac.Focus()
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf txtfecha.Value > txtfecha_ent.Value Then
            MsgBox("La fecha del pedido debe ser mayor o igual a la fecha de entrega, Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
        End If
        '''''' VALIDAR SI EXIXTE FACTURA NUEVA'''''''''''''''''
        If lbestado.Text = "NUEVO" Then
            Dim sw As Integer = 0
            Do
                Dim t As New DataTable
                myCommand.CommandText = "SELECT numero FROM pedi_comp WHERE numero='" & txtnumfac.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                Refresh()
                If t.Rows.Count > 0 Then
                    If txtnumfac.Enabled = True Then
                        MsgBox("Verifique el numero de factura, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
                        txtnumfac.Focus()
                        Exit Sub
                    Else
                        Dim tabla As New DataTable
                        myCommand.CommandText = "SELECT max(numero) FROM pedi_comp;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla)
                        Refresh()
                        Try
                            If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                                txtnumfac.Text = NumeroDoc(1)
                            Else
                                txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            txtnumfac.Text = NumeroDoc(1)
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
                    GuardarFactura(i) 'item
                End If
            Next
            bloquear()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("COMPRAS", "GUARDAR ORDEN DE COMPRA Nº: " & txtnumfac.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            lbnumero.Text = ""
            lbestado.Text = "GUARDADO"
        ElseIf lbestado.Text = "EDITAR" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del pedido / orden de compra (" & txtnumfac.Text & ") se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Eliminar()
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item("codigo", i).Value <> "" Then
                        GuardarFactura(i) 'item
                    End If
                Next
                bloquear()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("COMPRAS", "MODIFICAR ORDEN DE COMPRA Nº: " & txtnumfac.Text, "", "", "")
                End If
                '.....
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
        myCommand.Parameters.AddWithValue("?numero", txtnumfac.Text)
        myCommand.Parameters.AddWithValue("?item", gfactura.Item("num", i).Value)
        myCommand.Parameters.AddWithValue("?tipo", gfactura.Item("tipo", i).Value)
        myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", i).Value)
        myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("descrip", i).Value)
        myCommand.Parameters.AddWithValue("?cantped", DIN(gfactura.Item("cant", i).Value))
        myCommand.Parameters.AddWithValue("?cantrec", DIN(gfactura.Item("recibida", i).Value))
        myCommand.Parameters.AddWithValue("?costo", DIN(gfactura.Item("valor", i).Value))
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(txtdescuento.Text))
        myCommand.Parameters.AddWithValue("?por_iva", DIN(gfactura.Item("iva", i).Value))
        myCommand.Parameters.AddWithValue("?iva", DIN(txtiva.Text))
        myCommand.Parameters.AddWithValue("?por_rtf", DIN(valordes.Text))
        myCommand.Parameters.AddWithValue("?rtf", DIN(txtret.Text))
        myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", i).Value))
        myCommand.Parameters.AddWithValue("?vtotal", DIN(gfactura.Item("Vtotal", i).Value))
        myCommand.Parameters.AddWithValue("?fle", DIN(txtflete.Text))
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?usuario", lbusuario.Text.ToString)
        myCommand.Parameters.AddWithValue("?fechaped", CDate(txtfecha.Value))
        myCommand.Parameters.AddWithValue("?fecharec", CDate(txtfecha_ent.Value))
        myCommand.Parameters.AddWithValue("?observ", txtobservaciones.Text.ToString)
        myCommand.Parameters.AddWithValue("?cumplido", "no")
        'INSERTAR PEDIDO / ORDEN DE COMPRA
        myCommand.CommandText = "INSERT INTO pedi_comp VALUES (?numero,?item,?tipo,?codart,?nomart,?cantped,?cantrec,?costo,?por_desc,?descuento,?por_iva,?iva,?por_rtf,?rtf,?valor,?vtotal," _
                              & "?fle,?nitc,?usuario,?fechaped,?fecharec,?observ,?cumplido);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
    End Sub
    Public Sub Eliminar()
        myCommand.CommandText = "DELETE FROM pedi_comp WHERE numero='" & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
    End Sub


    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        FrmItemsCompras.txtnumfac.Text = txtnumfac.Text
        FrmItemsCompras.txtfecha.Text = txtfecha.Text
        FrmItemsCompras.txttipo.Text = ""
        FrmItemsCompras.txttipo2.Text = "PEDIDO / ORDEN DE COMPRA"
        FrmItemsCompras.gitems.RowCount = 1
        Try
            FrmItemsCompras.gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        FrmItemsCompras.gitems.RowCount = gfactura.RowCount
        For i = 0 To gfactura.RowCount - 1
            FrmItemsCompras.gitems.Item("num", i).Value = i + 1
            FrmItemsCompras.gitems.Item("tipo", i).Value = gfactura.Item("tipo", i).Value
            FrmItemsCompras.gitems.Item("codigo", i).Value = gfactura.Item("codigo", i).Value
            FrmItemsCompras.gitems.Item("descrip", i).Value = gfactura.Item("descrip", i).Value
            FrmItemsCompras.gitems.Item("cant", i).Value = gfactura.Item("cant", i).Value
            FrmItemsCompras.gitems.Item("precio", i).Value = gfactura.Item("valor", i).Value
            FrmItemsCompras.gitems.Item("bodega", i).Value = gfactura.Item("bodega", i).Value
            FrmItemsCompras.gitems.Item("iva", i).Value = gfactura.Item("iva", i).Value
            '/////////////////////////////////////////////////////////////////////////////
            FrmItemsCompras.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
            FrmItemsCompras.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
            FrmItemsCompras.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
            FrmItemsCompras.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value 'cta ing / gas
            FrmItemsCompras.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
        Next
        FrmItemsCompras.lbiva.Text = "NO"
        FrmItemsCompras.gitems.Columns(1).ReadOnly = False  'tipo I/S
        FrmItemsCompras.gitems.Columns(6).ReadOnly = False  'bodega
        FrmItemsCompras.gitems.Columns("cc").ReadOnly = True  'NO hay concepto comicionable
        FrmItemsCompras.lbform.Text = "oc"
        FrmItemsCompras.LbTipoMov.Text = "entradas"
        FrmItemsCompras.gitems.Focus()
        FrmItemsCompras.ShowDialog()
        FrmItemsCompras.lbiva.Text = "NO"
        CalcularTotales()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If Trim(lbformat.Text) = "pdf" Then
                GenerarPDF()
            ElseIf Trim(lbformat.Text) = "pdf2" Then
                GenerarPDF2()
            Else
                GenerarTicket()
            End If
        End If
    End Sub
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
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
            Dim tabla As New DataTable
            Dim valor, vtotal As Double
            myCommand.CommandText = "SELECT * FROM pedi_comp WHERE numero = '" & txtnumfac.Text & "' ORDER BY item;"
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
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cod_art"), 40, k, 0)
                'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantped"), 325, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantrec"), 370, k, 0)
                Try
                    valor = Moneda(tabla.Rows(i).Item("valor")) / (1 + (CDec(tabla.Rows(i).Item("por_iva")) / 100))
                Catch ex As Exception
                    valor = Moneda(tabla.Rows(i).Item("valor"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor), 485, k, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("por_iva")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal), 585, k, 0)
                'CONTROL SALTO DE LINEA PARA NOMBRE O DESCRIPCION DEL ARTICULO
                Control_de_linea(tabla.Rows(i).Item("nom_art").ToString, 120, 33)
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text), 585, k, 0)
            If CDec(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtdescuento.Text), 585, k, 0)
            End If
            If CDec(valorret.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE. FUENTE " & valorret.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtret.Text), 585, k, 0)
            End If
            If CDbl(txtiva.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA ", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtiva.Text), 585, k, 0)
            End If
            If CDbl(txtflete.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "FLETE ", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtflete.Text), 585, k, 0)
            End If
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text), 585, k, 0)
            k = k - 10
            Control_de_linea("SON: " & Num2Text(Moneda2(txttotal.Text)), 10, 80)
            k = k - 10
            If txtobservaciones.Text <> "" Then
                cb.ShowTextAligned(50, "Observaciones: ", 10, k, 0)
                Control_de_linea(txtobservaciones.Text, 70, 100)
                k = k - 10
            End If
            k = k - 15
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM par_comp;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    ' cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 10, 125)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            '*************************************************************
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 10
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            k = k - 46
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
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Function Moneda2(ByVal monto As String)
        If lbestado.Text <> "" Then
            Try
                If CDbl(monto) = 0 Then
                    monto = "0,00"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 2), "0,00.00")
                End If
                Return monto
            Catch ex As Exception
                Return "0,00"
            End Try
        Else
            Try
                If CDbl(monto) = 0 Then
                    monto = "0"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 0), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 0), "0,00")
                End If
                Return monto
            Catch ex As Exception
                Return "0"
            End Try
        End If
    End Function
    Public Sub ColocarImg()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
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
        k = 815
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        k = k - 25
        cb.ShowTextAligned(50, "PEDIDO / ORDEN DE COMPRA No. " & txtnumfac.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA PEDIDO: " & txtfecha.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA ENTREGA: " & txtfecha_ent.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "PROVEEDOR: ", 20, k, 0)
        Control_de_linea(Trim(txtcliente.Text), 83, 45)
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: " & txtnitc.Text, 20, k, 0)
        '**********************************************************************************************************************
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        '******************************************************** DIAN **************************************************************
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PAGINA: " & pag, 585, k + 25, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 40, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANT", 325, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "RECI", 370, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR UNITARIO", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
    Public Sub PrintDian(ByVal r As String, ByVal f As String)
        cb.ShowTextAligned(50, r, 350, k + 45, 0)
        cb.ShowTextAligned(50, f, 350, k + 35, 0)
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
    Public Sub GenerarPDF2()

    End Sub
    Public Sub GenerarTicket()

    End Sub

    Private Sub chnuevo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdnuevo_rep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnuevo_rep.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            txtnumfac.Text = ""
            Try
                txtfecha.Value = CDate(PerActual & "/" & Now.Day)
            Catch ex As Exception
                If txtfecha.Enabled = True Then
                    txtfecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
                Else
                    txtfecha.Value = CDate(PerActual & "/" & "01")
                End If
            End Try
            txtfecha_ent.Value = txtfecha.Value

            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT max(numero) FROM pedi_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Try
                If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                txtnumfac.Text = NumeroDoc(1)
            End Try
            lbusuario.Text = FrmPrincipal.lbuser.Text
            lbestado.Text = "NUEVO"
            Desbloquear()
            txtnitc.Focus()
        End If

    End Sub

   
End Class