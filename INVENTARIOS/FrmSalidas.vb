Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object

Public Class FrmSalidas
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PoneEnCero()
                Exit Sub
            End If
            BuscarDocumento(tabla.Rows(0).Item("doc"))
            lbnumero.Text = "1"
        Catch ex As Exception
            PoneEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnumero.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal num_per As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT *  FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc='" & num_per & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '***************************************
        txttipo.Text = tabla.Rows(0).Item("tipodoc")
        txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item("num")))
        txtdia.Text = tabla.Rows(0).Item("dia")
        txtperiodo.Text = "/" & tabla.Rows(0).Item("per")
        lbhora.Text = tabla.Rows(0).Item("hora").ToString
        cbtipo.Text = tabla.Rows(0).Item("desc_mov")
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        txtnitc_LostFocus(AcceptButton, AcceptButton)
        cbcc.Text = tabla.Rows(0).Item("cc")
        txtconcepto.Text = tabla.Rows(0).Item("concepto")
        txtpedido.Text = tabla.Rows(0).Item("n_pedido")
        txtobs.Text = tabla.Rows(0).Item("observ")
        txttotal.Text = Moneda(tabla.Rows(0).Item("total"))
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        If tabla.Rows(0).Item("o_compra") = "ING" Then
            ching.Checked = True
        Else
            ching.Checked = False
        End If
        BuscarDetalles(num_per)
        '***************************************
        bloquear()
        Timer1.Enabled = False
        lbestado.Text = "CONSULTA"
    End Sub
    Public Sub BuscarDetalles(ByVal num_per As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM deta_mov" & PerActual(0) & PerActual(1) & " WHERE doc = '" & num_per & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Dim suma As Double
            suma = 0
            gfactura.RowCount = tabla.Rows.Count
            cborigen.Text = tabla.Rows(0).Item("bod_ori")
            For i = 0 To tabla.Rows.Count - 1
                gfactura.Item(0, i).Value = tabla.Rows(i).Item("item")
                gfactura.Item(1, i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item(2, i).Value = tabla.Rows(i).Item("nomart")
                gfactura.Item(3, i).Value = Fraccion(tabla.Rows(i).Item("cantidad"))
                gfactura.Item(4, i).Value = Moneda(tabla.Rows(i).Item("valor"))
                gfactura.Item(5, i).Value = Moneda(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor"))
                suma = suma + CDbl(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor"))
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                gfactura.Item(7, i).Value = cborigen.Text

            Next
            txttotal.Text = Moneda(suma)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub bloquear()
        txtcentro.Enabled = False
        txtdia.Enabled = False
        txtobs.Enabled = False
        txtpedido.Enabled = False
        txtnitc.Enabled = False
        '*******************
        cborigen.Enabled = False
        cbtipo.Enabled = False
        cbaprobado.Enabled = False
        cbcc.Enabled = False
        txtconcepto.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        'CmdEliminar.Enabled = true
        CmdMostrar.Enabled = True
        ching.Enabled = False
        txtvmto.Enabled = False
    End Sub
    Public Sub DesBloquear()
        txtcentro.Enabled = True
        txtdia.Enabled = True
        txtobs.Enabled = True
        txtpedido.Enabled = True
        txtnitc.Enabled = True
        cborigen.Enabled = True
        cbtipo.Enabled = True
        cbaprobado.Enabled = True
        cbcc.Enabled = True
        txtconcepto.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        'CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        ching.Enabled = True

    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT salidas FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("No ha seleccionado tipo de documento para las salidas.", MsgBoxStyle.Information, "SAE Control")
        Else
            PoneEnCero()
            Timer1.Enabled = True
            Dim t As New DataTable
            If Today.Day < 10 Then
                txtdia.Text = "0" & Today.Day
            Else
                txtdia.Text = Today.Day
            End If
            txtperiodo.Text = "/" & PerActual
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                txtnumfac.Text = NumeroDoc(1)
            End Try
            cbtipo.Text = "SALIDA DE MERCANCIA"
            lbestado.Text = "NUEVO"
            txttipo.Text = tabla.Rows(0).Item(0)
            lbhora.Text = Format(Now, "HH:mm:ss")
            DesBloquear()
        End If
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Try
                myCommand.Parameters.Clear()
            Catch ex As Exception
            End Try
            ValidarGuardar()
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
            If cbaprobado.Text <> "AP" Then
                lbestado.Text = "EDITAR"
                cborigen.Enabled = True
                cbtipo.Enabled = True
                cbaprobado.Enabled = True
                DesBloquear()
                '...
                txtvmto.Text = "0"
                txtctapago.Text = ""
                txtcual.Text = ""
                txtforma.Text = ""
                '...
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    limpiar_AD()
                    llenar_AD()
                End If
            Else
                MsgBox("El registro no se puede editar (REGISTRO APROBADO).   ", MsgBoxStyle.Information, "Verificando")
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click

    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelMovInventario.lbform.Text = "salidas"
        FrmSelMovInventario.lbtipo.Text = lbdoc.Text
        FrmSelMovInventario.lbtitulo.Text = "BUSCAR SALIDA(" & lbdoc.Text & ") POR NUMERO "
        FrmSelMovInventario.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarDocumento(txttipo.Text & txtnumfac.Text)
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub


    Public Sub PoneEnCero()
        BuscarPeriodo()
        cborigen.Enabled = False
        cbtipo.Enabled = False
        cbaprobado.Enabled = False
        Timer1.Enabled = False
        lbestado.Text = "NULO"
        txttipo.Text = ""
        txtnumfac.Text = ""
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtconcepto.Text = ""
        txtpedido.Text = ""
        txtobs.Text = ""
        txttotal.Text = "0,00"
        cbaprobado.Text = ""
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        lbhora.Text = ""
        cbcc.Text = ""
        ching.Checked = False
        chvalor.Checked = False

        txtvmto.Text = "0"
        txtctapago.Text = ""
        txtcual.Text = ""
        txtforma.Text = ""
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarNIT(txtnitc, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtcliente.Text = ""
            cargarclientes()
        ElseIf txtnitc.Text = "0" Then
            txtcliente.Text = "   [  SIN NIT  ]"
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
        Try
            FrmSelCliente.lbform.Text = "salidas"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
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
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.txtnit.Text = txtnitc.Text
                LimpiarTerceros()
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.lbform.Text = "salidas"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtconcepto.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    Private Sub txtobs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobs.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub FrmSalidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT salidas FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try

       
            If tabla.Rows(0).Item("salidas").ToString = "" Then
                MsgBox("No han asignado ningun tipo de docuementos a las salidas, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Me.Close()
                Exit Sub
            Else
                lbdoc.Text = tabla.Rows(0).Item("salidas").ToString
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    MsgBox("No han creado ninguna Bodega, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    Me.Close()
                    Exit Sub
                End If
                cborigen.Items.Clear()
                For i = 0 To items - 1
                    cborigen.Items.Add(tabla.Rows(i).Item("numbod"))
                Next
            End If
            'VERIFICAR SI USAN CENTRO DE COSTOS
            Try
                tabla.Clear()
                myCommand.CommandText = "SELECT ccosto FROM parcontab;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item("ccosto") = "N" Then
                    cbcc.Items.Clear()
                    BuscarPeriodo()
                    lbestado.Text = "NULO"
                    CmdPrimero_Click(AcceptButton, AcceptButton)
                    Exit Sub
                End If
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM  centrocostos WHERE nivel='centro';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                cbcc.Items.Clear()
                txtcentro.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    cbcc.Items.Add(tabla.Rows(i).Item("centro"))
                    txtcentro.Items.Add(tabla.Rows(i).Item("nombre"))
                Next
            Catch ex As Exception
                cbcc.Items.Clear()
            End Try
            '****************************************
            If FrmPrincipal.Facturacion.Enabled = False Then
                ching.Visible = False
                cmdfpago.Visible = False
                lbdvmt.Visible = False
                txtvmto.Visible = False
            Else
                ching.Visible = True
                cmdfpago.Visible = True
                lbdvmt.Visible = True
                txtvmto.Visible = True
            End If
            '****************************************
            BuscarPeriodo()
            lbestado.Text = "NULO"
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cborigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cborigen.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & cborigen.Text & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtnombod.Text = tabla.Rows(0).Item("nombod")
        Else
            txtnombod.Text = ""
        End If
    End Sub

    Public Sub ValidarGuardar()
        Try
            Dim fec As Date
            fec = CDate(txtdia.Text & txtperiodo.Text & " " & lbhora.Text)
        Catch ex As Exception
            MsgBox("El dia no coincide con un formato de fecha correcto, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Exit Sub
        End Try
        If txttipo.Text = "" Then
            MsgBox("No ha escogido el tipo de salida, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtnombod.Text = "" Then
            MsgBox("No ha seleccionado bodega de salida, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cborigen.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cmditems.Focus()
            Exit Sub
        ElseIf ching.Checked = True And txtcual.Text = "" Then
            MsgBox("No ha escogido la forma de pago, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cmdfpago.Focus()
            Exit Sub
        End If
        Dim ap As String = ""
        ap = par_guar_inv()
        If ap = "SI" Then
            If cbaprobado.Text <> "AP" Then
                MsgBox("No se puede guardar la Salida si no esta Aprobada", MsgBoxStyle.Exclamation, "Verifique")
                Exit Sub
            End If
        End If

        'PARAMETRO LISTAR ARTIC CON EXISTENCIA PARA VALIDAR CANTI
        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows.Count > 0 Then
            If tc.Rows(0).Item(0) = "SI" Then
                '...VALIDAR CANTIDAD DISPONIBLE ...
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item(1, i).Value <> "" Then
                        If cbaprobado.Text = "AP" Then
                            If ValidarCantidades(i) = False Then
                                Exit Sub
                            End If
                        End If
                    End If
                Next
            End If
        End If

        If lbestado.Text = "NUEVO" Then
            GuardarFactura()
        Else
            ModificarFactura()
        End If

    End Sub
    Private Function par_guar_inv()

        Dim par As String = ""

        Dim tb As New DataTable
        tb.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT guar_Ap FROM parinven ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            par = tb.Rows(0).Item(0)
        End If
        Return par
    End Function
    Public Sub GuardarFactura()
        MiConexion(bda)
        Try
            Try
                Dim tabla As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                txtnumfac.Text = NumeroDoc(1)
            End Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipo_mov", "S")
            myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
            myCommand.Parameters.AddWithValue("?tipo_sal", cbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
            If ching.Checked = True Then
                myCommand.Parameters.AddWithValue("?o_compra", "ING")
            Else
                myCommand.Parameters.AddWithValue("?o_compra", "")
            End If
            myCommand.Parameters.AddWithValue("?n_pedido", txtpedido.Text.ToString)
            myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?tipo_sal,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '*********************************************
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item(1, i).Value <> "" Then
                    GuardarDetalles(i)
                    If cbaprobado.Text = "AP" Then GuardarEnBodega(i)
                End If
            Next
            '.............................
            If txtvmto.Text <> "0" And cbaprobado.Text = "AP" Then
                GuardarCOBDPEN()
            End If
            '.............................
            ActualizarCon()
            cbaprobado.Enabled = False
            If cbaprobado.Text = "AP" Then GuardarContable()
            bloquear()
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "GUARDAR SALIDA Nº: " & txttipo.Text & txtnumfac.Text, "", "", "")
            End If
            '.....
            Refresh()
            lbnumero.Text = "0"
            lbestado.Text = "GUARDADO"
        Catch ex As Exception

        End Try
        Cerrar()
    End Sub
    Public Sub GuardarCOBDPEN()
        Try
            If txtcual.Text <> "Otra" Then Exit Sub
            Dim cad As String = txtctapago.Text
            If cad(0) & cad(1) <> "13" Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Las cuenta (" & txtctapago.Text & ") no pertenece a Cuentas por Pagar, ¿Desea Generar un Documento De Cuentas por Pagar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.No Then Exit Sub
            End If
            ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR TABLA COBDPEN'''''''''''''''''''''''''''''''
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", PerActual & "-" & txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
            myCommand.Parameters.AddWithValue("?descrip", "")
            myCommand.Parameters.AddWithValue("?tipafec", "")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.Parameters.AddWithValue("?nomnit", txtcliente.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitcod", "")
            myCommand.Parameters.AddWithValue("?nitv", "0")
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtdia.Text & txtperiodo.Text))
            'dias de vmto
            myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
            myCommand.Parameters.AddWithValue("?concepto", CambiaCadena(gfactura.Item("desc", 0).Value, 99))
            'subtotal
            myCommand.Parameters.AddWithValue("?subtotal", DIN(txttotal.Text))
            'descuento
            myCommand.Parameters.AddWithValue("?descto", DIN(0))
            'myCommand.Parameters.AddWithValue("?descto", DIN(lbdescuento.Text))
            'rete_fuente
            myCommand.Parameters.AddWithValue("?ret", "0")
            'iva
            myCommand.Parameters.AddWithValue("?iva", DIN(0))
            myCommand.Parameters.AddWithValue("?v_iva", DIN(0))
            'total
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            'cuentas
            myCommand.Parameters.AddWithValue("?ctasubtotal", "")
            myCommand.Parameters.AddWithValue("?ctaret", "")
            myCommand.Parameters.AddWithValue("?ctaiva", "")
            myCommand.Parameters.AddWithValue("?ctatotal", txtctapago.Text)
            'ccosto
            myCommand.Parameters.AddWithValue("?ccosto", Val(0))
            myCommand.Parameters.AddWithValue("?otroimp", "N")
            'rete_iva
            myCommand.Parameters.AddWithValue("?retiva", "0")
            myCommand.Parameters.AddWithValue("?ctaretiva", "")
            'ret_ica
            myCommand.Parameters.AddWithValue("?retica", "0")
            myCommand.Parameters.AddWithValue("?ctaretica", "")
            'pagado
            myCommand.Parameters.AddWithValue("?pagado", "0")
            'pos
            myCommand.Parameters.AddWithValue("?rcpos", "")
            myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
            myCommand.Parameters.AddWithValue("?vpos", "0")
            'tasa
            myCommand.Parameters.AddWithValue("?tasa", "0")
            'moneda
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            'estado
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", "")
            'INSERTAR COBDPEN
            myCommand.CommandText = "INSERT INTO cobdpen VALUES (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto," _
                                  & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                                  & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarCon()
        Try
            Dim campo As String = "actual" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & campo & " FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                If Val(txtnumfac.Text) > Val(tabla.Rows(0).Item(0)) Then
                    myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                    myCommand.ExecuteNonQuery()
                End If
            Catch ex As Exception
                myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", fila).Value)
            myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("desc", fila).Value)
            myCommand.Parameters.AddWithValue("?bod_ori", cborigen.Text)
            myCommand.Parameters.AddWithValue("?bod_des", "0")
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", fila).Value))
            '**********************************************************
            myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_ing", gfactura.Item("ctaing", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
            Try
                myCommand.Parameters.AddWithValue("?costo", DIN(gfactura.Item("costo", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
            & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function ValidarCantidades(ByVal fila As Integer)
        Dim tbc As New DataTable
        tbc.Clear()
        myCommand.CommandText = "SELECT cant" & cborigen.Text & " FROM con_inv WHERE codart='" & gfactura.Item(1, fila).Value & "' and  periodo='" & PerActual(0) & PerActual(1) & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbc)
        Refresh()
        If (CDbl(tbc.Rows(0).Item(0)) - CDbl(gfactura.Item(3, fila).Value)) < 0 Then
            MsgBox("La cantidad disponible del articulo " & gfactura.Item(1, fila).Value & ", es " & tbc.Rows(0).Item(0) & " , Verifique", MsgBoxStyle.Information, "Verifique")
            Return (False)
            Exit Function
        End If
        Return (True)
    End Function
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
            myCommand.CommandText = "UPDATE con_inv SET cant" & cborigen.Text & "=cant" & cborigen.Text & " - ?cantidad " _
                                  & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarContable()
        try
        Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        grilla.RowCount = 1
        grilla.Rows.Clear()
        grilla.RowCount = 30
            If tabla.Rows(0).Item("contable").ToString <> "no" Then 'HAY INTERFAZ CONTABLE
                Dim tdoc As String
                BuscarPeriodo()
                tdoc = "documentos" & PerActual(0) & PerActual(1)
                '************************************************
                grilla.RowCount = grilla.RowCount + 1
                For i = 0 To gfactura.RowCount - 1
                    MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, "SALIDA DE BOD. " & cborigen.Text & " " & Trim(txtcliente.Text))
                    MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, Trim(txtcliente.Text) & " A VENTAS ")
                Next i
                '********************************************************************
                Try

                    If ching.Checked = True Then '... AFECTAR CUENTAS D INGRESOS Y CAJA
                        Dim i As Integer = 0
                        Dim cta As String = ""
                        Dim ctai As String = ""
                        Try
                            Dim tb As New DataTable
                            myCommand.CommandText = "SELECT caja,ventas FROM parafacgral;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tb)
                            'cta = tb.Rows(0).Item(0).ToString
                            cta = txtctapago.Text
                            ctai = tb.Rows(0).Item(1).ToString
                        Catch ex As Exception
                            cta = "110505001"
                            ctai = gfactura.Item("ctaing", 0).Value.ToString
                        End Try
                        grilla.RowCount = grilla.RowCount + 2
                        i = grilla.RowCount - 3
                        grilla.Item("Descripcion", i).Value = "INGRESO POR SALIDA A " & txtcliente.Text
                        grilla.Item("cuenta", i).Value = ctai
                        grilla.Item("Debitos", i).Value = "0"
                        grilla.Item("Creditos", i).Value = txttotal.Text
                        '********************************************
                        i = i + 1
                        grilla.Item("Descripcion", i).Value = "INGRESO POR SALIDA A " & txtcliente.Text
                        grilla.Item("cuenta", i).Value = cta
                        grilla.Item("Debitos", i).Value = txttotal.Text
                        grilla.Item("Creditos", i).Value = "0"
                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                Dim cad As String
                Dim db, cr As Double
                For i = 0 To grilla.RowCount - 1
                    Try
                        Try
                            cad = grilla.Item("cuenta", i).Value.ToString
                        Catch ex As Exception
                            cad = ""
                        End Try
                        Try
                            db = grilla.Item("Debitos", i).Value
                        Catch ex As Exception
                            db = 0
                        End Try
                        Try
                            cr = grilla.Item("Creditos", i).Value
                        Catch ex As Exception
                            cr = 0
                        End Try
                        If cad <> "" And (db > 0 Or cr > 0) Then
                            InsertContabilidad(i, tdoc)
                        End If
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
            myCommand.Parameters.AddWithValue("?centro", Val(cbcc.Text.ToString))
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", "0")
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "inventarios")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String)
        Try
            If cuenta = "" Then Exit Sub
            Dim sw, j, k As Integer
            Dim cad, des As String
            sw = 0
            For j = 0 To grilla.RowCount - 1
                k = j
                Try
                    cad = grilla.Item("cuenta", j).Value.ToString
                Catch ex As Exception
                    cad = ""
                End Try
                Try
                    des = grilla.Item("Descripcion", j).Value.ToString
                Catch ex As Exception
                    des = ""
                End Try
                '***************************
                If cad = "" And des = "" Then
                    grilla.Item("cuenta", j).Value = cuenta
                    grilla.Item("Descripcion", j).Value = descrip
                    sw = 1
                    Exit For
                ElseIf cad = cuenta Then
                    If des = descrip Then
                        sw = 1
                        Exit For
                    End If
                End If
            Next j
            j = k
            If sw = 0 Then
                grilla.RowCount = grilla.RowCount + 1
                grilla.Item("cuenta", k).Value = cuenta
                grilla.Item("Descripcion", k).Value = descrip
                grilla.RowCount = grilla.RowCount + 1
            End If
            Dim db, cr, monto As Double
            Try
                db = grilla.Item("Debitos", j).Value
            Catch ex As Exception
                db = 0
            End Try
            Try
                cr = grilla.Item("Creditos", j).Value
            Catch ex As Exception
                cr = 0
            End Try
            Select Case tipo
                Case "inv"
                    Try
                        If ching.Checked = True Then
                            monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                        Else
                            monto = CDbl(gfactura.Item("Vtotal", fo).Value)
                        End If

                    Catch ex As Exception
                        monto = 0
                    End Try
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Case "cventa"
                    Try
                        If ching.Checked = True Then
                            monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                        Else
                            monto = CDbl(gfactura.Item("Vtotal", fo).Value)
                        End If
                    Catch ex As Exception
                        monto = 0
                    End Try
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ModificarFactura()
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la salida se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                '***********************************************************
                EliminarDetalles(txttipo.Text & txtnumfac.Text)
                '***********************************************************
                myCommand.Parameters.Clear()
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
                myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
                myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
                myCommand.Parameters.AddWithValue("?tipo_sal", cbtipo.Text.ToString)
                myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
                If ching.Checked = True Then
                    myCommand.Parameters.AddWithValue("?o_compra", "ING")
                Else
                    myCommand.Parameters.AddWithValue("?o_compra", "")
                End If
                myCommand.Parameters.AddWithValue("?n_pedido", txtpedido.Text.ToString)
                myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
                myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
                myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
                myCommand.CommandText = "UPDATE movimientos" & PerActual(0) & PerActual(1) & " SET dia=?dia, hora=?hora, desc_mov=?tipo_sal, nitc=?nitc, " _
                                      & "cc=?cc, concepto=?concepto, o_compra=?o_compra, n_pedido=?n_pedido, observ=?observ, total=?total, estado=?estado WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.ExecuteNonQuery()
                '*********************************************
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item(1, i).Value <> "" Then
                        GuardarDetalles(i)
                        If cbaprobado.Text = "AP" Then GuardarEnBodega(i)
                    End If
                Next
                '.............................
                If txtvmto.Text <> "0" And cbaprobado.Text = "AP" Then
                    GuardarCOBDPEN()
                End If
                '.............................
                If cbaprobado.Text = "AP" Then GuardarContable()
                bloquear()

                '//////********
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    AuditarDatos()
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                cbaprobado.Enabled = False
                lbestado.Text = "EDITADO"
                '***********************************************************
                Cerrar()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Cerrar()
        End Try
    End Sub
    Public Sub ModificarEnBodega(ByVal num_per As String, ByVal bodega As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT codart, cantidad FROM deta_salidas WHERE num_per='" & num_per & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                EjecutaSQL("UPDATE art_x_bod SET cantidad=cantidad + " & tabla.Rows(i).Item("cantidad") & " WHERE codart='" & tabla.Rows(i).Item("codart") & "' AND numbod=" & bodega & ";")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub EliminarDetalles(ByVal num_per As String)
        EjecutaSQL("DELETE FROM deta_mov" & PerActual(0) & PerActual(1) & " WHERE doc='" & num_per & "';")
    End Sub
    Public Sub EjecutaSQL(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If cborigen.Text = "" Then
                MsgBox("Favor Seleccione Bodega De Salida. ", MsgBoxStyle.Information, "SAE Control")
                cborigen.Focus()
                Exit Sub
            End If
            FrmItems.txtnumfac.Text = txtnumfac.Text
            Try
                FrmItems.txtfecha.Text = txtdia.Text & txtperiodo.Text
            Catch ex As Exception
                FrmItems.txtfecha.Text = "01" & txtperiodo.Text
            End Try
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = ""
            Try
                FrmItems.gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            FrmItems.gitems.RowCount = gfactura.RowCount + 1
            For i = 0 To gfactura.RowCount - 1
                FrmItems.gitems.Item("num", i).Value = i + 1
                FrmItems.gitems.Item("tipo", i).Value = gfactura.Item(6, i).Value
                FrmItems.gitems.Item("codigo", i).Value = gfactura.Item(1, i).Value
                FrmItems.gitems.Item("descrip", i).Value = gfactura.Item(2, i).Value
                FrmItems.gitems.Item("cant", i).Value = gfactura.Item(3, i).Value
                FrmItems.gitems.Item("precio", i).Value = gfactura.Item(4, i).Value
                FrmItems.gitems.Item("bodega", i).Value = gfactura.Item(7, i).Value
                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
                FrmItems.gitems.Item("costo", i).Value = gfactura.Item("costo", i).Value
            Next
            '*******************************************************
            FrmItems.gitems.Columns(1).Visible = False  'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = False  'cc
            FrmItems.gitems.Columns("ctainv").Visible = True   'cc
            FrmItems.gitems.Columns("num").Visible = True   'num
            FrmItems.gitems.Columns("bodega").ReadOnly = True 'bodega
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = cbtipo.Text
            FrmItems.txtnumfac.Text = txtnumfac.Text
            FrmItems.lbform.Text = "salidas"
            FrmItems.LbTipoMov.Text = "salidas"
            FrmItems.ShowDialog()
            FrmItems.gitems.Columns(1).Visible = True   'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = True   'cc
            FrmItems.gitems.Columns("ctainv").Visible = False   'cc
            FrmItems.gitems.Columns("num").Visible = False    'num
            FrmItems.gitems.Columns("bodega").ReadOnly = False 'bodega
            FrmItems.gitems.Columns("cc").ReadOnly = False 'C COMI
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            lbhora.Text = Format(Now, "HH:mm:ss")
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Else
                NGenerarPDF()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim num_per As String = txtnumfac.Text & "-" & PerActual
        FechaRep = Now.ToString
        pag = 0
        '**************************************
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        Banner()
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        '*********************************************
        Dim tabla, t As New DataTable
        myCommand.CommandText = "SELECT * FROM deta_mov" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            k = k - 10
            If k < 60 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
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
            cb.ShowTextAligned(50, tabla.Rows(i).Item("codart"), 50, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 150, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantidad"), 320, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("valor")), 465, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor")), 585, k, 0)
        Next
        '********************************************************************
        k = k - 20
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT total, observ FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL $", 460, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(t.Rows(0).Item("total")), 585, k, 0)
        k = k - 15
        If t.Rows(0).Item("observ") <> "" Then cb.ShowTextAligned(50, "OBSERVACIONES: " & CambiaCadena(t.Rows(0).Item("observ"), 100), 10, k, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        Try
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp, tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        myCommand.CommandText = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 800, 0)
        cb.ShowTextAligned(50, "DOCUMENTO DE SALIDA: " & tabla.Rows(0).Item("doc") & " DEL PERIODO " & PerActual, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA ELABORACION:" & tabla.Rows(0).Item("dia") & "/" & PerActual & " " & tabla.Rows(0).Item("hora").ToString, 20, 780, 0)
        cb.ShowTextAligned(50, "BODEGA DE SALIDA: " & cborigen.Text & " " & txtnombod.Text, 20, 770, 0)
        cb.ShowTextAligned(50, "TIPO DE SALIDA: " & tabla.Rows(0).Item("desc_mov"), 20, 760, 0)
        cb.ShowTextAligned(50, "NIT / C.C. " & tabla.Rows(0).Item("nitc") & "  " & Trim(txtcliente.Text), 20, 750, 0)
        cb.ShowTextAligned(50, "PEDIDO # " & tabla.Rows(0).Item("n_pedido"), 20, 740, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 730, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 720, 0)
        '**************************
        k = 710
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 50, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 150, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 320, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "V. UNITARIO", 465, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "V. TOTAL", 585, k, 0)
        k = k - 5
    End Sub


    Private Sub cbcc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbcc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbcc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcc.SelectedIndexChanged
        Try
            txtcentro.SelectedIndex = cbcc.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcentro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentro.SelectedIndexChanged
        Try
            cbcc.SelectedIndex = txtcentro.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Public Sub NGenerarPDF()

        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim email As String = ""
        Dim dire As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString


        MiConexion(bda)
        Cerrar()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")
        tel = Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        email = tabla2.Rows(0).Item("emailconta")
        dire = tabla2.Rows(0).Item("direccion")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql = "SELECT d.item, d.codart, d.nomart,CAST((d.cantidad) AS CHAR(20)) AS doc, d.valor  AS costo, d.valor * d.cantidad as valor, " _
        & " m.nitc as cta_inv, trim(CONCAT(t.nombre,' ', t.apellidos)) as cta_cos, t.dir as cta_ing, trim(CONCAT(t.telefono,' - ',t.celular)) as cta_iva" _
        & " FROM  `deta_mov" & p & "` d, movimientos" & p & " m LEFT JOIN terceros t ON m.nitc=t.nit " _
        & " WHERE  d.doc=m.doc AND d.doc =  '" & txttipo.Text & txtnumfac.Text & "'  ORDER BY item"


        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "deta_mov01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "Select doc as cc, desc_mov, concepto, n_pedido, observ, CAST(concat(dia,'/',per) AS CHAR(20)) as per " _
                                & " from movimientos" & p & " where doc= '" & txttipo.Text & txtnumfac.Text & "' "
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "movimientos01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " select logofac from parafacts where factura ='RAPIDA' "
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parafacts")


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        If chvalor.Checked = False Then
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportSalidas.rpt")
        Else
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportSalida2.rpt")
        End If
        CrReport.SetDataSource(tabla)
        FrmReportFacRap.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtelef As New ParameterField
            Dim Premail As New ParameterField
            Dim Prtipo As New ParameterField
            Dim Prorden As New ParameterField
            Dim Prbod As New ParameterField
            Dim PrAP As New ParameterField

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
            Prtipo.Name = "tipo"
            Prtipo.CurrentValues.AddValue("SALIDA No")
            Prorden.Name = "orden"
            Prorden.CurrentValues.AddValue("ORDEN DE PEDIDO")
            Prbod.Name = "bod"
            Prbod.CurrentValues.AddValue(cborigen.Text & " " & txtnombod.Text)
            PrAP.Name = "ap"
            If cbaprobado.Text = "AP" Then
                PrAP.CurrentValues.AddValue("")
            Else
                PrAP.CurrentValues.AddValue("PENDIENTE")
            End If
            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtelef)
            prmdatos.Add(Premail)
            prmdatos.Add(Prtipo)
            prmdatos.Add(Prorden)
            prmdatos.Add(Prbod)
            If chvalor.Checked = False Then
                prmdatos.Add(PrAP)
            End If


            FrmReportFacRap.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRap.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NGenerarPDF()
    End Sub

    Private Sub cmdfpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfpago.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            FrmFormaPago.G1.Enabled = False
            FrmFormaPago.tabfp.Enabled = False
            FrmFormaPago.cmdcontinuar.Enabled = True
            FrmFormaPago.cmdcuenta.Enabled = False
            FrmFormaPago.txtcuenta.Enabled = False
            FrmFormaPago.txtpago.Enabled = False
            FrmFormaPago.txttotal.Enabled = False
            FrmFormaPago.txtcambio.Enabled = False
        Else
            FrmFormaPago.G1.Enabled = True
            FrmFormaPago.tabfp.Enabled = True
            FrmFormaPago.cmdcontinuar.Enabled = True
            FrmFormaPago.cmdcuenta.Enabled = True
            FrmFormaPago.txtcuenta.Enabled = True
            FrmFormaPago.txtpago.Enabled = True
            FrmFormaPago.txttotal.Enabled = True
            FrmFormaPago.txtcambio.Enabled = True
        End If
        'FrmFormaPago.txtcuenta.Text = txtcuentatotal.Text
        FrmFormaPago.txtdias.Text = txtvmto.Text

        'If txtforma.Text <> "" Then

        'End If
        'If gfp.RowCount = 1 Then
        '    FrmFormaPago.tabforma.Visible = True
        '    FrmFormaPago.tabvarias.Visible = False
        '    FrmFormaPago.txtpago.Text = txttotal.Text
        '    gfp.Item("monto", 0).Value = txttotal.Text
        '    FrmFormaPago.txttotal.Text = txttotal.Text
        '    FrmFormaPago.txtcambio.Text = "0,00"
        '    If gfp.Item("detalle", 0).Value = "" Then
        '        FrmFormaPago.lbfp.Text = "Pagar Con Efectivo"
        '    ElseIf gfp.Item("cual", 0).Value = "Cheque" Then
        '        FrmFormaPago.txtnumcheq.Text = gfp.Item("numero", 0).Value
        '        FrmFormaPago.txtbanco.Text = gfp.Item("banco", 0).Value
        '        FrmFormaPago.gche.Enabled = True
        '        FrmFormaPago.gtar.Enabled = False
        '        FrmFormaPago.gcre.Enabled = False
        '    ElseIf gfp.Item("cual", 0).Value = "Tarjeta" Then
        '        FrmFormaPago.txttarjeta.Text = gfp.Item("detalle", 0).Value
        '        FrmFormaPago.txtnumtarjeta.Text = gfp.Item("numero", 0).Value
        '        FrmFormaPago.cbtarj.Text = gfp.Item("tt", 0).Value
        '        FrmFormaPago.gche.Enabled = False
        '        FrmFormaPago.gtar.Enabled = True
        '        FrmFormaPago.gcre.Enabled = False
        '    Else
        '        FrmFormaPago.txtespecifica.Text = gfp.Item("detalle", 0).Value
        '        FrmFormaPago.txtdias.Text = txtvmto.Text
        '        FrmFormaPago.gche.Enabled = False
        '        FrmFormaPago.gtar.Enabled = False
        '        FrmFormaPago.gcre.Enabled = True
        '        If Val(txtvmto.Text) > 0 Then
        '            FrmFormaPago.rbsdia.Checked = True
        '        Else
        '            FrmFormaPago.rbndia.Checked = True
        '        End If
        '    End If
        'Else
        FrmFormaPago.cmdvarias.Enabled = False
        FrmFormaPago.tabvarias.Visible = False
        'End If
        FrmFormaPago.lbfp.Text = txtforma.Text
        FrmFormaPago.lbform.Text = "sal"
        FrmFormaPago.ShowDialog()
        FrmFormaPago.cmdvarias.Enabled = True
        FrmFormaPago.tabvarias.Visible = True
    End Sub
    Public Sub CeroFP()
        '***********************************
        FrmFormaPago.txtnumcheq.Text = ""
        FrmFormaPago.txtbanco.Text = ""
        FrmFormaPago.txttarjeta.Text = ""
        FrmFormaPago.cbtarj.Text = "DB"
        FrmFormaPago.txtnumtarjeta.Text = ""
        FrmFormaPago.txtespecifica.Text = ""
        FrmFormaPago.txtdias.Text = "0"
        '***********************************
        FrmFormaPago.txtnumcheque2.Text = ""
        FrmFormaPago.txtbanco2.Text = ""
        FrmFormaPago.txtvche.Text = "0,00"
        FrmFormaPago.txttar1.Text = ""
        FrmFormaPago.txtnumtar1.Text = ""
        FrmFormaPago.txtvt1.Text = "0,00"
        FrmFormaPago.txttar2.Text = ""
        FrmFormaPago.txtnumtar2.Text = ""
        FrmFormaPago.txtvt2.Text = "0,00"
        FrmFormaPago.txttar3.Text = ""
        FrmFormaPago.txtnumtar3.Text = ""
        FrmFormaPago.txtvt3.Text = "0,00"
        FrmFormaPago.txtvefec.Text = "0,00"
        '***********************************
        FrmFormaPago.txtcuenta.Text = ""
        FrmFormaPago.txtpago.Text = "0,00"
        FrmFormaPago.txttotal.Text = "0,00"
        FrmFormaPago.txtcambio.Text = "0,00"
    End Sub

    Private Sub ching_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ching.CheckedChanged
        If ching.Checked = True Then
            cmdfpago.Enabled = True
            txtvmto.Enabled = True
        Else
            cmdfpago.Enabled = False
            txtvmto.Enabled = False
        End If
    End Sub

    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        validarnumero(txtvmto, e)
    End Sub
    Private Sub limpiar_AD()
        cborigen1.Text = ""
        txtnitc1.Text = ""
        cbcc1.Text = ""
        txtconcepto1.Text = ""
        txtpedido1.Text = ""
        txtobs1.Text = ""
        cbaprobado1.Text = ""
        txttotal1.Text = ""
        txtfecha.Text = ""
        gfactura2.Rows.Clear()
    End Sub
    Private Sub llenar_AD()
        cborigen1.Text = cborigen.Text
        txtnitc1.Text = txtnitc.Text
        cbcc1.Text = cbcc.Text
        txtconcepto1.Text = txtconcepto.Text
        txtpedido1.Text = txtpedido.Text
        txtobs1.Text = txtobs.Text
        cbaprobado1.Text = cbaprobado.Text
        txttotal1.Text = txttotal.Text
        txtfecha.Text = txtdia.Text & txtperiodo.Text
        gfactura2.RowCount = gfactura.RowCount
        For i = 0 To gfactura2.RowCount - 1
            Try
                gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", i).Value
                gfactura2.Item("desc2", i).Value = gfactura.Item("desc", i).Value
                gfactura2.Item("cant2", i).Value = gfactura.Item("cant", i).Value
                gfactura2.Item("valor2", i).Value = gfactura.Item("valor", i).Value
                gfactura2.Item("bodega2", i).Value = gfactura.Item("bodega", i).Value
                gfactura2.Item("cc2", i).Value = gfactura.Item("cc", i).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
    End Sub
    Private Sub AuditarDatos()
        Try
            Dim camp As String = ""
            Dim ant As String = ""
            Dim nue As String = ""

            lbespera.Visible = True

            If cborigen.Text <> cborigen1.Text Then
                camp = camp & " BODEGA ORIGEN; "
                ant = ant & cborigen1.Text & "; "
                nue = nue & cborigen.Text & "; "
            End If
            If txtnitc.Text <> txtnitc1.Text Then
                camp = camp & " CLIENTE; "
                ant = ant & txtnitc1.Text & "; "
                nue = nue & txtnitc.Text & "; "
            End If
            If cbcc.Text <> cbcc1.Text Then
                camp = camp & " CENTRO DE COSTO; "
                ant = ant & cbcc1.Text & "; "
                nue = nue & cbcc.Text & "; "
            End If
            If txtconcepto.Text <> txtconcepto1.Text Then
                camp = camp & " CONCEPTO; "
                ant = ant & txtconcepto1.Text & "; "
                nue = nue & txtconcepto.Text & "; "
            End If
            If txtpedido.Text <> txtpedido1.Text Then
                camp = camp & " N° PEDIDO; "
                ant = ant & txtpedido1.Text & "; "
                nue = nue & txtpedido.Text & "; "
            End If
            If cbaprobado.Text <> cbaprobado1.Text Then
                camp = camp & " ESTADO; "
                ant = ant & cbaprobado1.Text & "; "
                nue = nue & cbaprobado.Text & "; "
            End If
            If txtfecha.Text <> txtdia.Text & txtperiodo.Text Then
                camp = camp & " FECHA; "
                ant = ant & txtfecha.Text & "; "
                nue = nue & txtdia.Text & txtperiodo.Text & "; "
            End If
            If txtobs.Text <> txtobs1.Text Then
                camp = camp & " OBSERVACION; "
                ant = ant & txtobs1.Text & "; "
                nue = nue & txtobs.Text & "; "
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
                        If (gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value) Then
                            If gfactura2.Item("cant2", i).Value <> gfactura.Item("cant", j).Value Then
                                camp = camp & "CANTIDAD ITEM " & gfactura2.Item("codigo2", i).Value & ";"
                                ant = ant & gfactura2.Item("cant2", i).Value & ";"
                                nue = nue & gfactura.Item("cant", i).Value & ";"
                            End If
                            If gfactura2.Item("valor2", i).Value <> gfactura.Item("valor", j).Value Then
                                camp = camp & "VALOR ITEM " & gfactura2.Item("codigo2", i).Value & ";"
                                ant = ant & gfactura2.Item("valor2", i).Value & ";"
                                nue = nue & gfactura.Item("valor", i).Value & ";"
                            End If
                            Exit For
                        End If
                    End If
                Next
            Next
            Guar_MovUser("INVENTARIO", "MODIFICAR SALIDA Nº: " & txttipo.Text & txtnumfac.Text, camp, ant, nue)

            lbespera.Visible = False
        Catch ex As Exception
            lbespera.Visible = False
            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
            MsgBox("Error al Auditar campos, pulse Aceptar para continuar " & ex.ToString)
        End Try
    End Sub
End Class

