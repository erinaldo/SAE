﻿Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmAjustesCant

    Private Sub FrmAjustesCant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    '*********************************************************
    Public Sub PoneEnCero()
        BuscarPeriodo()
        Bloquear()
        lbestado.Text = "NULO"
        txttipo.Text = ""
        txtnumfac.Text = ""
        txtnomdestino.Text = ""
        txtnomorigen.Text = ""
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
        cborigen.Enabled = False
        cbdestino.Enabled = False
        cbtipo_aju.Enabled = False
        cbaprobado.Enabled = False
        txtdia.Enabled = False
        Timer1.Enabled = False
        txtdia.Enabled = False
        txtconcepto.Enabled = False
        txtobs.Enabled = False
        cbcc.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        'CmdEliminar.Enabled = true
        CmdMostrar.Enabled = True
        txtcentro.Enabled = False
    End Sub
    Public Sub Desbloquear()
        txtcentro.Enabled = True
        cborigen.Enabled = True
        cbdestino.Enabled = True
        cbtipo_aju.Enabled = True
        cbaprobado.Enabled = True
        txtdia.Enabled = True
        txtconcepto.Enabled = True
        txtobs.Enabled = True
        cbcc.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        'CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
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
            Desbloquear()
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
            cbtipo_aju.Text = "entrada"
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
                Desbloquear()
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
        cborigen1.Text = ""
        cbdestino1.Text = ""
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
        cborigen1.Text = cborigen.Text
        cbdestino1.Text = cbdestino.Text
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
                gfactura2.Item("cant2", i).Value = gfactura.Item("cant", i).Value
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
        FrmSelMovInventario.lbform.Text = "ajustes"
        FrmSelMovInventario.lbtipo.Text = lbdoc.Text
        FrmSelMovInventario.lbtitulo.Text = "BUSCAR AJUSTE(" & lbdoc.Text & ") POR NUMERO"
        FrmSelMovInventario.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            ' BuscarDocumento(txttipo.Text & txtnumfac.Text)
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '***************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A' LIMIT 0, 1;"
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
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A' LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A' LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND tipo_mov='A' LIMIT " & i & ", 1;"
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
        'txtcompra.Text = tabla.Rows(0).Item("o_compra")
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
            cbdestino.Text = tabla.Rows(0).Item("bod_des")
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
            Next
            txttotal.Text = Moneda(suma)
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub
    '**************************************************************************
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If Trim(cbtipo_aju.Text) = "" Then
                MsgBox("Favor Seleccione Tipo de ajuste. ", MsgBoxStyle.Information, "SAE Control")
                cbdestino.Focus()
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
                If Trim(cbtipo_aju.Text) = "ENTRADA" Then
                    FrmItems.gitems.Item("bodega", i).Value = cborigen.Text
                    FrmItems.lbbodega.Text = cborigen.Text
                Else
                    FrmItems.gitems.Item("bodega", i).Value = cbdestino.Text
                    FrmItems.lbbodega.Text = cbdestino.Text
                End If

                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
            Next
            '*******************************************************
            If Trim(cbtipo_aju.Text) = "ENTRADA" Then
                FrmItems.gitems.Columns("precio").HeaderText = "COSTO"
            Else
                FrmItems.gitems.Columns("precio").HeaderText = "PRECIO"
            End If
            FrmItems.gitems.Columns(1).Visible = False  'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = False  'cc
            FrmItems.gitems.Columns("ctainv").Visible = True   'cc
            FrmItems.gitems.Columns("num").Visible = True   'num
            FrmItems.gitems.Columns("bodega").ReadOnly = True 'bodega
            FrmItems.gitems.Columns("cc").ReadOnly = True 'C COMI
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = ""
            FrmItems.txtnumfac.Text = txtnumfac.Text
            FrmItems.lbform.Text = "ajustes"
            If Trim(cbtipo_aju.Text) = "ENTRADA" Then
                FrmItems.LbTipoMov.Text = "entradas"
            Else
                FrmItems.LbTipoMov.Text = "salidas"
            End If
            FrmItems.ShowDialog()
            FrmItems.gitems.Columns(1).Visible = True   'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = True   'cc
            FrmItems.gitems.Columns("ctainv").Visible = False    'cc
            FrmItems.gitems.Columns("num").Visible = False    'num
            FrmItems.gitems.Columns("bodega").ReadOnly = False 'bodega
            FrmItems.gitems.Columns("cc").ReadOnly = False 'C COMI
            FrmItems.gitems.Columns("precio").HeaderText = "PRECIO"
        End If
    End Sub
    Private Sub cbtipo_aju_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtipo_aju.SelectedIndexChanged
        cborigen.Items.Clear()
        cbdestino.Items.Clear()
        Dim tabla As New DataTable
        Dim items As Integer
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
        If Trim(cbtipo_aju.Text) = "ENTRADA" Then
            cbdestino.Items.Add("0")
            cbdestino.Text = "0"
            For i = 0 To items - 1
                cborigen.Items.Add(tabla.Rows(i).Item("numbod"))
            Next
            cborigen.Text = tabla.Rows(0).Item("numbod")
        Else
            cborigen.Items.Add("0")
            cborigen.Text = "0"
            For i = 0 To items - 1
                cbdestino.Items.Add(tabla.Rows(i).Item("numbod"))
            Next
            cbdestino.Text = tabla.Rows(0).Item("numbod")
        End If
    End Sub
    Public Sub NomBod(ByVal bod As Integer, ByVal cbn As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod='" & bod & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If cbn = "ent" Then
                txtnomorigen.Text = tabla.Rows(0).Item("nombod")
            Else
                txtnomdestino.Text = tabla.Rows(0).Item("nombod")
            End If
        Catch ex As Exception
            If cbn = "ent" Then
                txtnomorigen.Text = ""
            Else
                txtnomdestino.Text = ""
            End If
        End Try
    End Sub
    Private Sub cborigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cborigen.SelectedIndexChanged
        NomBod(Val(cborigen.Text), "ent")
    End Sub
    Private Sub cbdestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdestino.SelectedIndexChanged
        NomBod(Val(cbdestino.Text), "sal")
    End Sub
    '******************************************************************************
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
    '******************************************************************************
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
            MsgBox("No ha escogido el tipo de entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
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
            myCommand.Parameters.AddWithValue("?tipo_mov", "A")
            myCommand.Parameters.AddWithValue("?tipo", cbtipo_aju.Text)
            myCommand.Parameters.AddWithValue("?tipo_sal", cbtipo_aju.Text.ToString)
            myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
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
                    If cbaprobado.Text = "AP" Then
                        GuardarEnBodega(i)
                    End If
                End If
            Next
            ActualizarCon()
            If cbaprobado.Text = "AP" Then GuardarContable()
            Bloquear()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "GUARDAR AJUSTE DE CANTIDADES Y VALORES DOC N°: " & txttipo.Text & txtnumfac.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbnumero.Text = "0"
            lbestado.Text = "GUARDADO"
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
            myCommand.Parameters.AddWithValue("?bod_ori", cbdestino.Text)
            myCommand.Parameters.AddWithValue("?bod_des", cborigen.Text)
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", fila).Value))
            '****************************************************************************************
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

        End Try
    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item(1, fila).Value)
            If cbtipo_aju.Text = "ENTRADA" Then
                myCommand.Parameters.AddWithValue("?numbod", cborigen.Text)
            Else
                myCommand.Parameters.AddWithValue("?numbod", cbdestino.Text)
            End If
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
            If cbtipo_aju.Text = "ENTRADA" Then
                myCommand.CommandText = "UPDATE con_inv SET cant" & cborigen.Text & "=cant" & cborigen.Text & " + ?cantidad " _
                   & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            Else
                myCommand.CommandText = "UPDATE con_inv SET cant" & cbdestino.Text & "=cant" & cbdestino.Text & " - ?cantidad " _
               & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            End If
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

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
                    If cbtipo_aju.Text = "ENTRADA" Then
                        MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, "AJUSTE SALIDA A BOD. " & cborigen.Text)
                        MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, "AJUSTE A VENTAS ")
                    Else
                        MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, "AJUSTE ENTRADA A BOD. " & cbdestino.Text)
                        MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, "AJUSTE A VENTAS ")
                    End If
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
                        monto = CDbl(gfactura.Item("Vtotal", fo).Value)
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If cbtipo_aju.Text = "ENTRADA" Then
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                Case "cventa"
                    Try
                        monto = CDbl(gfactura.Item("Vtotal", fo).Value)
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If cbtipo_aju.Text = "ENTRADA" Then
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
            resultado = MsgBox("Los datos de la entrada se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                '********************************************
                EliminarDetalles(txttipo.Text & txtnumfac.Text)
                '***********************************************************
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
                myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
                myCommand.Parameters.AddWithValue("?nitc", "")
                myCommand.Parameters.AddWithValue("?tipo_sal", cbtipo_aju.Text.ToString)
                myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
                myCommand.Parameters.AddWithValue("?o_compra", "")
                myCommand.Parameters.AddWithValue("?observ", txtobs.Text.ToString)
                myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
                myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
                myCommand.CommandText = "UPDATE movimientos" & PerActual(0) & PerActual(1) & " SET dia=?dia, hora=?hora, desc_mov=?tipo_sal, nitc=?nitc, " _
                                      & "cc=?cc, concepto=?concepto, o_compra=?o_compra, observ=?observ, total=?total, estado=?estado WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.ExecuteNonQuery()
                '*********************************************
                '*********************************************
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item(1, i).Value <> "" Then
                        GuardarDetalles(i)
                        If cbaprobado.Text = "AP" Then
                            GuardarEnBodega(i)
                        End If
                    End If
                Next
                If cbaprobado.Text = "AP" Then GuardarContable()
                Bloquear()
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    AuditarDatos()
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                cbaprobado.Enabled = False
                cbdestino.Enabled = False
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

            If cborigen.Text <> cborigen1.Text Then
                camp = camp & "BODEGA ORIGEN; "
                ant = ant & cborigen1.Text & "; "
                nue = nue & cborigen.Text & "; "
            End If
            If cbdestino.Text <> cbdestino1.Text Then
                camp = camp & "BODEGA DESTINO; "
                ant = ant & cborigen1.Text & "; "
                nue = nue & cborigen.Text & "; "
            End If
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
            Guar_MovUser("INVENTARIO", "MODIFICAR AJUSTE DE CANTIDADES Y VALORES Nº: " & txttipo.Text & txtnumfac.Text, camp, ant, nue)

            lbespera.Visible = False
        Catch ex As Exception
            lbespera.Visible = False
            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
            MsgBox("Error al Auditar campos, pulse Aceptar para continuar " & ex.ToString)
        End Try
    End Sub
    Public Sub ModificarEnBodega(ByVal num_per As String, ByVal bodega As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT codart, cantidad FROM deta_entradas WHERE num_per='" & num_per & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                If cbtipo_aju.Text = "ENTRADA" Then
                    EjecutaSQL("UPDATE art_x_bod SET cantidad=cantidad - " & tabla.Rows(i).Item("cantidad") & " WHERE codart='" & tabla.Rows(i).Item("codart") & "' AND numbod=" & bodega & ";")
                Else
                    EjecutaSQL("UPDATE art_x_bod SET cantidad=cantidad + " & tabla.Rows(i).Item("cantidad") & " WHERE codart='" & tabla.Rows(i).Item("codart") & "' AND numbod=" & bodega & ";")
                End If

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
    '***********************************************************************************
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
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txttotal.Text), 585, k, 0)
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
        If cbtipo_aju.Text = "ENTRADA" Then
            cb.ShowTextAligned(50, "BODEGA: " & cborigen.Text & " " & txtnomorigen.Text, 20, 770, 0)
        Else
            cb.ShowTextAligned(50, "BODEGA: " & cbdestino.Text & " " & txtnomdestino.Text, 20, 770, 0)
        End If
        cb.ShowTextAligned(50, "TIPO DE AJUSTE: " & tabla.Rows(0).Item("tipo"), 20, 760, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 750, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
        '**************************
        k = 730
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
End Class