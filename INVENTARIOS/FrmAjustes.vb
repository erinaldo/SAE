Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmAjustes
    Private Sub FrmAjustes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Try
            myCommand.CommandText = "SELECT ajustes FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item(0).ToString = "" Then
                MsgBox("No han asignado ningun tipo de docuementos a los ajustes, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Me.Close()
                Exit Sub
            Else
                lbdoc.Text = tabla.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            MsgBox("No han asignado ningun tipo de docuementos a los ajustes, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
            Exit Sub
        End Try
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
        BuscarPeriodo()
        lbestado.Text = "NULO"
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
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
                FrmItems.gitems.Item("tipo", i).Value = gfactura.Item("tipo", i).Value
                FrmItems.gitems.Item("codigo", i).Value = gfactura.Item("codigo", i).Value
                FrmItems.gitems.Item("descrip", i).Value = gfactura.Item("desc", i).Value
                'FrmItems.gitems.Item("cant", i).Value = "0"
                FrmItems.gitems.Item("precio", i).Value = gfactura.Item("valor", i).Value
                FrmItems.gitems.Item("bodega", i).Value = ""
                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = "0"
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
            Next
            '*******************************************************
            FrmItems.gitems.Columns("precio").HeaderText = "VALOR AJUSTE"
            FrmItems.gitems.Columns("cant").Visible = False 'cantidad
            FrmItems.gitems.Columns(1).Visible = False 'tipo I/S
            FrmItems.gitems.Columns("bodega").Visible = False  'bodega
            FrmItems.gitems.Columns("cc").Visible = False  'C COMI 
            FrmItems.gitems.Columns("ctainv").Visible = True
            FrmItems.gitems.Columns("ctacven").Visible = True
            FrmItems.gitems.Columns("ctaiva").Visible = True
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = ""
            FrmItems.txtnumfac.Text = txtnumfac.Text
            FrmItems.lbform.Text = "aju_val"
            FrmItems.LbTipoMov.Text = "entradas"
            FrmItems.ShowDialog()
            FrmItems.gitems.Columns("cant").Visible = True    'cantidad
            FrmItems.gitems.Columns(1).Visible = True 'tipo I/S
            FrmItems.gitems.Columns("bodega").Visible = True   'bodega
            FrmItems.gitems.Columns("cc").Visible = True  'C COMI
            FrmItems.gitems.Columns("ctainv").Visible = False
            FrmItems.gitems.Columns("ctacven").Visible = False
            FrmItems.gitems.Columns("ctaiva").Visible = False
            FrmItems.gitems.Columns("precio").HeaderText = "PRECIO"
        End If
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Else
                GenerarPDF()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '**************************************************************************
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT ajustes FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("No ha seleccionado tipo de documento para los ajustes.", MsgBoxStyle.Information, "SAE Control")
        Else
            PoneEnCero()
            DesBloquear()
            Timer1.Enabled = True
            Dim t As New DataTable
            If Today.Day < 10 Then
                txtdia.Text = "0" & Today.Day
            Else
                txtdia.Text = Today.Day
            End If
            txttipo.Text = lbdoc.Text
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
            lbestado.Text = "NUEVO"
            cbtipo_aju.Text = "para aumentar valores"
            cbtipo_aju.Focus()
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
        BuscarPeriodo()
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If cbaprobado.Text <> "AP" Then
                lbestado.Text = "EDITAR"
                DesBloquear()
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
    Private Sub limpiar_AD()
        cbtipo_aju1.Text = ""
        cbcc1.Text = ""
        txtconcepto1.Text = ""
        txtobs1.Text = ""
        txttotal1.Text = ""
        cbaprobado1.Text = ""
        gfactura2.Rows.Clear()
        txtfecha.Text = ""
    End Sub
    Private Sub llenar_AD()
        cbtipo_aju1.Text = cbtipo_aju.Text
        cbcc1.Text = cbcc.Text
        txtconcepto1.Text = txtconcepto.Text
        txttotal1.Text = txttotal.Text
        txtobs1.Text = txtobs.Text
        cbaprobado1.Text = cbaprobado.Text
        txtfecha.Text = txtdia.Text & txtperiodo.Text
        gfactura2.RowCount = gfactura.RowCount
        For i = 0 To gfactura2.RowCount - 1
            Try
                gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", i).Value
                gfactura2.Item("valor2", i).Value = gfactura.Item("valor", i).Value
                gfactura2.Item("tipo2", i).Value = gfactura.Item("tipo", i).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click

    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelMovInventario.lbform.Text = "ajus_val"
        FrmSelMovInventario.lbtipo.Text = lbdoc.Text
        FrmSelMovInventario.lbtitulo.Text = "BUSCAR AJUSTE DE VALORES(" & lbdoc.Text & ") POR NUMERO"
        FrmSelMovInventario.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarDocumento(txttipo.Text & txtnumfac.Text)
        End If
    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V' LIMIT 0, 1;"
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
            MsgBox(ex.ToString)
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
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V' LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V' LIMIT " & i & ", 1;"
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
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='V' LIMIT " & i & ", 1;"
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
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc='" & num_per & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '***************************************
        txttipo.Text = tabla.Rows(0).Item("tipodoc")
        txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item("num")))
        txtdia.Text = tabla.Rows(0).Item("dia")
        txtperiodo.Text = "/" & tabla.Rows(0).Item("per")
        lbhora.Text = tabla.Rows(0).Item("hora").ToString
        cbtipo_aju.Text = tabla.Rows(0).Item("tipo")
        'txtnitc.Text = tabla.Rows(0).Item("nitc")
        'txtnitc_LostFocus(AcceptButton, AcceptButton)
        cbcc.Text = tabla.Rows(0).Item("cc")
        txtconcepto.Text = tabla.Rows(0).Item("concepto")
        txtobs.Text = tabla.Rows(0).Item("observ")
        txttotal.Text = Moneda(tabla.Rows(0).Item("total"))
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        BuscarDetalles(num_per)
        '***************************************
        Bloquear()
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
            For i = 0 To tabla.Rows.Count - 1
                gfactura.Item(0, i).Value = tabla.Rows(i).Item("item")
                gfactura.Item(1, i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item(2, i).Value = tabla.Rows(i).Item("nomart")
                'gfactura.Item(3, i).Value = Decimales(tabla.Rows(i).Item("cantidad"))
                gfactura.Item("valor", i).Value = Moneda(tabla.Rows(i).Item("valor"))
                'gfactura.Item(5, i).Value = Moneda(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor"))
                suma = suma + CDbl(tabla.Rows(i).Item("valor"))
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
            Next
            txttotal.Text = Moneda(suma)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub PoneEnCero()
        BuscarPeriodo()
        Bloquear()
        lbestado.Text = "NULO"
        txttipo.Text = ""
        txtnumfac.Text = ""
        txtconcepto.Text = ""
        txtobs.Text = ""
        txttotal.Text = "0,00"
        cbaprobado.Text = ""
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        lbhora.Text = ""
        cbcc.Text = ""
    End Sub
    Public Sub Bloquear()
        txtcentro.Enabled = False
        cbaprobado.Enabled = False
        Timer1.Enabled = False
        cbtipo_aju.Enabled = False
        txtconcepto.Enabled = False
        txtobs.Enabled = False
        txtdia.Enabled = False
        '*******************       
        cbcc.Enabled = False
        txtconcepto.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        'CmdEliminar.Enabled = true
        CmdMostrar.Enabled = True
    End Sub
    Public Sub DesBloquear()
        txtcentro.Enabled = True
        cbaprobado.Enabled = True
        cbtipo_aju.Enabled = True
        txtconcepto.Enabled = True
        txtobs.Enabled = True
        txtdia.Enabled = True
        '************************
        txtdia.Enabled = True
        cbcc.Enabled = True
        txtconcepto.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        'CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
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
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            lbhora.Text = Format(Now, "HH:mm:ss")
        End If
    End Sub
    Private Sub txtconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcepto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    '**************************************************************************
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
            MsgBox("No ha escogido el tipo de ajuste, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para el ajuste, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cmditems.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            GuardarFactura()
        ElseIf lbestado.Text = "EDITAR" Then
            ModificarFactura()
        End If
    End Sub
    Public Sub GuardarFactura()
        Try
            MiConexion(bda)
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
            myCommand.Parameters.AddWithValue("?nitc", "0")
            myCommand.Parameters.AddWithValue("?tipo_mov", "V")
            myCommand.Parameters.AddWithValue("?tipo", cbtipo_aju.Text.ToString)
            myCommand.Parameters.AddWithValue("?desc_mov", cbtipo_aju.Text.ToString)
            myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?desc_mov,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '*********************************************
            Dim t As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Dim formula As String
            formula = t.Rows(0).Item("formula")
            Dim margen As Integer
            margen = t.Rows(0).Item("porcen")
            '*********************************************
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item(1, i).Value <> "" Then
                    GuardarDetalles(i)
                    If cbaprobado.Text = "AP" Then
                        GuardarPrecios(i, formula, margen)
                    End If
                End If
            Next
            ActualizarCon()
            If cbaprobado.Text = "AP" Then GuardarContable()
            Bloquear()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "GUARDAR AJUSTE DE VALORES Nº: " & txttipo.Text & txtnumfac.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbnumero.Text = "0"
            lbestado.Text = "GUARDADO"
            cbaprobado.Enabled = False
        Catch ex As Exception
            Cerrar()
            MsgBox("Error al intentar guardar el registro. Intentelo nuevamente." & ex.ToString, MsgBoxStyle.Information, "SAE Control")
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
            myCommand.Parameters.AddWithValue("?bod_ori", "0")
            myCommand.Parameters.AddWithValue("?bod_des", "0")
            myCommand.Parameters.AddWithValue("?cantidad", "0")
            myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", fila).Value))
            '****************************************************************************************
            myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_ing", gfactura.Item("ctaing", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
            Try
                myCommand.Parameters.AddWithValue("?costo", "0")
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
            & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarPrecios(ByVal fila As Integer, ByVal f As String, ByVal margen As Integer)
        '**************BUSCAR COSTO ACTUAL*******************
        Dim cant As String = "SUM( 0 "
        Try
            Dim tb As New DataTable
            tb.Clear()
            myCommand.CommandText = "SELECT * FROM bodegas;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            For i = 0 To tb.Rows.Count - 1
                cant += " + cant" & tb.Rows(i).Item("numbod").ToString
            Next
        Catch ex As Exception
        End Try
        cant += ")"
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT " & cant & " AS cant,costuni,periodo FROM con_inv WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "'  GROUP BY codart, periodo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            '******************************************************
            Dim precio, costo, aju, c As Double
            aju = 0
            '******************************************************
            Try
                c = CDbl(tabla.Rows(0).Item("cant"))
            Catch ex As Exception
                c = 1
            End Try
            aju = CDbl(gfactura.Item("valor", fila).Value)
            aju = aju / c
            Try
                costo = CDbl(tabla.Rows(0).Item("costuni"))
            Catch ex As Exception
                costo = 0
            End Try
            If costo = 0 Then
                costo = aju
            Else
                If Trim(cbtipo_aju.Text) = "para aumentar valores" Then
                    costo = costo + aju
                Else
                    costo = costo - aju
                End If
            End If
            '*****************************************************
            If f = "manual" Then
                precio = costo
            ElseIf f = "/" Then
                precio = costo / (1 - margen / 100)
            Else
                precio = costo * (1 + margen / 100)
            End If
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
            myCommand.Parameters.AddWithValue("?precio", DIN(precio))
            myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni,precio=?precio " _
                                  & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            myCommand.ExecuteNonQuery()
            Actualizar_Con_inv(fila, f, margen, costo)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Actualizar_Con_inv(ByVal fila As Integer, ByVal f As String, ByVal margen As Integer, ByVal costo As Double)
        Try
            Dim precio, costoprom, suma As Double
            Dim cant As Integer
            '******** iva de l artiuclo***************************************
            Dim tabla, tiva As New DataTable
            tabla.Clear()
            tiva.Clear()
            Dim iva As Decimal
            myCommand.CommandText = "SELECT iva FROM articulos WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tiva)
            Try
                iva = tiva.Rows(0).Item("iva")
            Catch ex As Exception
                iva = 0
            End Try
            '***********************************************
            myCommand.CommandText = "SELECT  costuni,costprom,margen,precio1,periodo FROM con_inv WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            suma = 0
            cant = 1 'al menos el q acaba de entrar
            For i = 0 To tabla.Rows.Count - 1
                Try
                    costoprom = tabla.Rows(i).Item("costprom")
                Catch ex As Exception
                    costoprom = 0
                End Try
                If costoprom > 0 Then
                    suma = suma + costoprom
                    cant = cant + 1 'hubo compra en ese mes ==> entra en promedio
                End If
            Next
            'costo = CDbl(gfactura.Item(4, fila).Value) 'costo del articulo
            '******************************************************              
            '*****************************************************
            Try
                margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("margen")) 'margen del periodo actual (el ultimo campo)
            Catch ex As Exception
                margen = 0
            End Try
            suma = suma + costo
            costoprom = suma / cant
            '*********************************
            If f = "/" Then 'precio segun formula
                precio = costo / (1 - margen / 100)
            ElseIf f = "manual" Then
                Try
                    margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("precio1")) 'precio1 del periodo actual porq es manual(el ultimo campo)
                Catch ex As Exception
                    margen = 0
                End Try
            Else
                precio = costo * (1 + margen / 100)
            End If
            ' precio = precio + (precio * iva / 100)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cosuni", costo)
            myCommand.Parameters.AddWithValue("?costprom", costoprom)
            myCommand.Parameters.AddWithValue("?precio", precio)
            myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom,precio1=?precio " _
                                 & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarContable()
        Try
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
                    MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, "AJUSTE " & UCase(cbtipo_aju.Text))
                    MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, "AJUSTE DE VALORES A VENTAS ")
                Next i
                '********************************************************************
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
            myCommand.Parameters.AddWithValue("?nit", "0")
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "inventarios")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
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
                        monto = CDbl(gfactura.Item("valor", fo).Value)
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If Trim(cbtipo_aju.Text) = "para aumentar valores" Then
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                Case "cventa"
                    Try
                        monto = CDbl(gfactura.Item("valor", fo).Value)
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If Trim(cbtipo_aju.Text) = "para aumentar valores" Then
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub
    '****************************************************
    Public Sub ModificarFactura()
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del ajuste se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                '********************************************
                EliminarDetalles(txttipo.Text & txtnumfac.Text)
                '***********************************************************
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
                myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
                myCommand.Parameters.AddWithValue("?nitc", "0")
                myCommand.Parameters.AddWithValue("?tipo", cbtipo_aju.Text.ToString)
                myCommand.Parameters.AddWithValue("?tipo_sal", cbtipo_aju.Text.ToString)
                myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
                myCommand.Parameters.AddWithValue("?o_compra", "")
                myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
                myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
                myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
                myCommand.CommandText = "UPDATE movimientos" & PerActual(0) & PerActual(1) & " SET dia=?dia, hora=?hora, tipo=?tipo, desc_mov=?tipo_sal,nitc=?nitc, " _
                                      & "cc=?cc, concepto=?concepto, o_compra=?o_compra, observ=?observ, total=?total, estado=?estado WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.ExecuteNonQuery()
                '*********************************************
                Dim t As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                Dim formula As String
                formula = t.Rows(0).Item("formula")
                Dim margen As Integer
                margen = t.Rows(0).Item("porcen")
                '*********************************************
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item(1, i).Value <> "" Then
                        GuardarDetalles(i)
                        If cbaprobado.Text = "AP" Then
                            'Actualizar_Con_inv(i, formula, margen)
                            GuardarPrecios(i, formula, margen)
                        End If
                    End If
                Next
                If cbaprobado.Text = "AP" Then GuardarContable()
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                Bloquear()
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    AuditarDatos()
                End If
                lbestado.Text = "EDITADO"
                cbaprobado.Enabled = False
                '***********************************************************
                Cerrar()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Cerrar()
        End Try
    End Sub
    Private Sub AuditarDatos()
        Try
            Dim camp As String = ""
            Dim ant As String = ""
            Dim nue As String = ""

            lbespera.Visible = True

            If UCase(txtconcepto.Text) <> UCase(txtconcepto1.Text) Then
                camp = camp & "CONCEPTO; "
                ant = ant & txtconcepto1.Text & "; "
                nue = nue & txtconcepto.Text & "; "
            End If
            If cbaprobado.Text <> cbaprobado1.Text Then
                camp = camp & " ESTADO; "
                ant = ant & cbaprobado1.Text & "; "
                nue = nue & cbaprobado.Text & "; "
            End If
            If txtfecha.Text <> txtdia.Text & txtperiodo.Text Then
                camp = camp & "FECHA; "
                ant = ant & txtfecha.Text & "; "
                nue = nue & txtdia.Text & txtperiodo.Text & "; "
            End If
            If UCase(txtobs.Text) <> UCase(txtobs1.Text) Then
                camp = camp & "OBSERVACION; "
                ant = ant & txtobs1.Text & "; "
                nue = nue & txtobs.Text & "; "
            End If
            If cbcc.Text <> cbcc1.Text Then
                camp = camp & "CENTRO DE COSTO; "
                ant = ant & cbcc1.Text & "; "
                nue = nue & cbcc.Text & "; "
            End If
            If cbtipo_aju.Text <> cbtipo_aju1.Text Then
                camp = camp & "TIPO DE AJUSTE; "
                ant = ant & cbtipo_aju1.Text & "; "
                nue = nue & cbtipo_aju.Text & "; "
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
            Guar_MovUser("INVENTARIO", "MODIFICAR AJUSTE DE VALORES Nº: " & txttipo.Text & txtnumfac.Text, camp, ant, nue)

            lbespera.Visible = False
        Catch ex As Exception
            lbespera.Visible = False
            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
            MsgBox("Error al Auditar campos, pulse Aceptar para continuar " & ex.ToString)
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
    '****************************************************
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("valor")), 585, k, 0)
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
        cb.ShowTextAligned(50, "DOCUMENTO DE AJUSTE: " & tabla.Rows(0).Item("doc") & " DEL PERIODO " & PerActual, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA ELABORACION:" & tabla.Rows(0).Item("dia") & "/" & PerActual & " " & tabla.Rows(0).Item("hora").ToString, 20, 780, 0)
        cb.ShowTextAligned(50, "TIPO DE AJUSTE: " & UCase(tabla.Rows(0).Item("tipo")), 20, 770, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 760, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        '**************************
        k = 740
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 50, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 150, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR AJUSTE", 585, k, 0)
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
End Class