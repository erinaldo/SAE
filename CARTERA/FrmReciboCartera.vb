Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmReciboCartera
    Public col, fila, FinEdit As Integer
    Public Sub Bloquear()
        txtnitv.Enabled = False
        txtnumero.Enabled = False
        txtcentro.Enabled = False
        grilla.ReadOnly = True
        fecha.Enabled = False
        txtaprobado.Enabled = False
        txtelaborado.Enabled = False
        txtconta.Enabled = False
        rbcc.Enabled = False
        rbnit.Enabled = False
        cbaprobado.Enabled = False
        txtnit.Enabled = False
        '**** READ ONLY *************
        txtdia.Enabled = False
        txtciudad.ReadOnly = True
        txtconcepto.ReadOnly = True
        txtvalor.ReadOnly = True
        txttipo.Enabled = False
        '********** comandos ***********
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        'CmdEliminar.Enabled=true 
        cmdprint.Enabled = True
        CmdMostrar.Enabled = True
        cmditems.Enabled = False
    End Sub
    Public Sub DesBloquear()
        Dim t As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item("ccosto") = "S" Then
            txtcentro.Enabled = True
        Else
            txtcentro.Enabled = False
        End If
        '****************************************************
        If lbcomi.Text = "SI" Then
            txtnitv.Enabled = True
        Else
            txtnitv.Enabled = False
        End If
        txtnit.Enabled = False
        grilla.ReadOnly = True
        fecha.Enabled = True
        txtaprobado.Enabled = True
        txtelaborado.Enabled = True
        txtconta.Enabled = True
        rbcc.Enabled = True
        rbnit.Enabled = True
        cbaprobado.Enabled = True
        txtdia.Enabled = True
        txttipo.Enabled = True
        '**** READ ONLY *************
        txtciudad.ReadOnly = False
        txtconcepto.ReadOnly = False
        txtvalor.ReadOnly = False
        '********** comandos ***********
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        'CmdEliminar.Enabled=False 
        cmdprint.Enabled = False
        CmdMostrar.Enabled = False
        cmditems.Enabled = True
    End Sub
    Public Sub CalularTotales()
        Try
            Dim cr, db As Double
            cr = 0
            db = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    db = db + CDbl(grilla.Item("Debitos", i).Value)
                Catch ex As Exception
                End Try
                Try
                    cr = cr + CDbl(grilla.Item("Creditos", i).Value)
                Catch ex As Exception
                End Try
            Next
            lbdb.Text = Moneda(db)
            lbcr.Text = Moneda(cr)
            lbdif.Text = Moneda(db - cr)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        lbestado.Text = "NUEVO"
        lbhaydoc.Text = "NO"
        MiConexion(bda)
        Cerrar()
        limpiar()
        parametros()
        DesBloquear()
        txtnumero.Enabled = True
        txtnumero.ReadOnly = False
        Try
            txtperiodo.Text = "/" & PerActual
            Me.txtdia.Text = Today.Day
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            Me.txtdia.Text = "01"
        End Try
        '*********************************
        Try
            FrmItemCartera.gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        rbnit.Checked = True
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If ValidarGuardar() = True Then
                AuditoriaRC()
                MiConexion(bda)
                BuscarPeriodo()
                Try
                    If lbestado.Text = "NUEVO" Then
                        GuardarTodo()
                    Else
                        ModificarTodo()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                Cerrar()
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Bloquear()
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If PerBloq() = False Then Exit Sub
                If Trim(lbanulado.Text) <> "" Then
                    MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                    Exit Sub
                ElseIf Trim(cbaprobado.Text) = "AP" Then
                    MsgBox("El documento fué Aprobado (AP), nose puede editar.   ", MsgBoxStyle.Information, "Verificando")
                    Exit Sub
                End If
                DesBloquear()
                txttipo.Enabled = False
                grilla.ReadOnly = False
                txtnumero.ReadOnly = True
                lbestado.Text = "EDITAR"
                grilla.Item(0, 0).Selected = True
                grilla.Focus()
                If txtcentro.Enabled = True Then
                    txtcentro.Focus()
                Else
                    txtciudad.Focus()
                End If
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click

    End Sub
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            GenerarPDF()
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If PerBloq() = False Then Exit Sub
            If Trim(lbanulado.Text) <> "" Then
                MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            ElseIf Trim(cbaprobado.Text) <> "AP" Then
                MsgBox("El documento No esta aprobado(AP).   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            FrmAnularOtDoc.lbcompa.Text = lbcompa.Text
            FrmAnularOtDoc.lbnit.Text = lbnit.Text
            FrmAnularOtDoc.txtcentro.Text = txtcentro.Text
            FrmAnularOtDoc.txtncentro.Text = txtncentro.Text
            FrmAnularOtDoc.txttipo.Text = lbdoc.Text
            FrmAnularOtDoc.txttipo2.Text = lbnomdoc.Text
            FrmAnularOtDoc.txtnumfac.Text = txtnumero.Text
            FrmAnularOtDoc.lbper_a.Text = "del " & PerActual
            Try
                FrmAnularOtDoc.txtfecha.Text = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
            End Try
            FrmAnularOtDoc.txtfecha_ana.Text = Today
            FrmAnularOtDoc.lbcliente.Text = lbcliente.Text
            If chefectivo.Checked = False Then
                FrmAnularOtDoc.lbcheque.Text = txtcheque.Text
            Else
                FrmAnularOtDoc.lbcheque.Text = ""
            End If
            FrmAnularOtDoc.lbform.Text = "rc"
            FrmAnularOtDoc.ShowDialog()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '*******************************************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Bloquear()
            Dim mes As String = "ot_cpc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " ORDER BY doc,tipo,num,item LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                grilla.Rows.Clear()
                txtaprobado.Text = ""
                txtconta.Text = ""
                txtelaborado.Text = ""
                txtcentro.Text = ""
                txtncentro.Text = ""
                txtciudad.Text = ""
                cbaprobado.Text = ""
                txtnitv.Text = ""
                txtnomv.Text = ""
                CalularTotales()
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_cpc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " ORDER BY doc,tipo,num,item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_cpc" & PerActual(0) & PerActual(1)
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " ORDER BY doc,tipo,num,item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_cpc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " ORDER BY doc,tipo,num,item LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0))
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal doc As String)
        Try
            Dim mes As String = "ot_cpc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & mes & " WHERE doc='" & doc & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                CmdNuevo.Focus()
            Else
                Refresh()
                txtcentro.Text = tabla.Rows(0).Item("ccosto")
                txtncentro.Text = ""
                If Val(tabla.Rows(0).Item("ccosto").ToString) > 0 Then BuscarCC()
                txtnitv.Text = tabla.Rows(0).Item("nitv")
                txtnomv.Text = ""
                If Trim(tabla.Rows(0).Item("nitv").ToString) <> "" Then BuscarVend()

            lbdoc.Text = tabla.Rows(0).Item("tipo")
            txttipo.Text = tabla.Rows(0).Item("tipo")
            txtnumero.Text = NumeroDoc(tabla.Rows(0).Item("num"))
            txtciudad.Text = tabla.Rows(0).Item("ciudad")
            txtdia.Text = tabla.Rows(0).Item("dia")
            Try
                Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
                txtdia.Text = "01"
            End Try
            txtvalor.Text = Moneda(tabla.Rows(0).Item("total"))
            lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
            lbcliente.Text = ""
            txtconcepto.Text = tabla.Rows(0).Item("concepto")
            grilla.Rows.Clear()
            txtcheque.Text = tabla.Rows(0).Item("cheque")
            txtbanco.Text = tabla.Rows(0).Item("banco")
            txtsucursal.Text = tabla.Rows(0).Item("sucursal")
            If tabla.Rows(0).Item("tipo_pago") = "efectivo" Then
                chefectivo.Checked = True
                lbfp.Text = "Cheque No."
                lb1.Text = "Banco"
                lb2.Text = "Sucursal"
            ElseIf tabla.Rows(0).Item("tipo_pago") = "cheque" Then
                chefectivo.Checked = False
                lbfp.Text = "Cheque No."
                lb1.Text = "Banco"
                lb2.Text = "Sucursal"
            ElseIf tabla.Rows(0).Item("tipo_pago") = "consig" Then
                chefectivo.Checked = False
                lbfp.Text = "Consignacion"
                lb1.Text = "Banco"
                lb2.Text = "Sucursal"
            ElseIf tabla.Rows(0).Item("tipo_pago") = "tarjeta" Then
                chefectivo.Checked = False
                lbfp.Text = "Tarjeta"
                lb1.Text = "Banco"
                lb2.Text = "Numero"
            End If
            txtnit.Text = tabla.Rows(0).Item("nitc")
            txtnit_TextChanged(AcceptButton, AcceptButton)
            Try
                If tabla.Rows(0).Item("tn") = "CC" Then
                    rbcc.Checked = True
                Else
                    rbnit.Checked = True
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                rbnit.Checked = True
            End Try
            txtelaborado.Text = tabla.Rows(0).Item("elaborado")
            txtaprobado.Text = tabla.Rows(0).Item("autorizado")
            txtconta.Text = tabla.Rows(0).Item("contabilizado")
            cbaprobado.Text = tabla.Rows(0).Item("estado")
            Try
                lbanulado.Text = tabla.Rows(0).Item("doc_aj")
            Catch ex As Exception
                lbanulado.Text = ""
            End Try
            fecha.Value = CDate(tabla.Rows(0).Item("fecha"))
            grilla.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                grilla.Item("Cuenta", i).Value = tabla.Rows(i).Item("codigo")
                grilla.Item("Descripcion", i).Value = tabla.Rows(i).Item("descrip")
                grilla.Item("Debitos", i).Value = Moneda(tabla.Rows(i).Item("debito"))
                grilla.Item("Creditos", i).Value = Moneda(tabla.Rows(i).Item("credito"))
                grilla.Item("Base", i).Value = Moneda(tabla.Rows(i).Item("base"))
                grilla.Item("doc_afe", i).Value = tabla.Rows(i).Item("doc_afec")
                grilla.Item("abonado", i).Value = Moneda(tabla.Rows(i).Item("abonado"))
                If Moneda(tabla.Rows(i).Item("abonado")) <> "0,00" Then
                    grilla.Item("editar", i).Value = "no"
                Else
                    grilla.Item("editar", i).Value = "si"
                End If
                Try
                    grilla.Item("DocAnti", i).Value = Moneda(tabla.Rows(i).Item("doc_anti"))
                Catch ex As Exception
                    grilla.Item("DocAnti", i).Value = "si"
                End Try
                    grilla.Item("comision", i).Value = tabla.Rows(i).Item("codcon")
                Next
            '***********************************************************
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count > 0 Then
                lbnomdoc.Text = tabla2.Rows(0).Item("descripcion").ToString
            End If
            Bloquear()
            lbestado.Text = "CONSULTA"
                End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        CalularTotales()
    End Sub
    '********************************************************************
    Private Sub txtcentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentro.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtcentro, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcentro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentro.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCC()
    End Sub
    Private Sub BuscarVend()
        Try
            Dim tv As New DataTable
            myCommand.CommandText = "SELECT nombre FROM vendedores WHERE nitv='" & txtnitv.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tv)
            If tv.Rows.Count > 0 Then
                txtnomv.Text = tv.Rows(0).Item(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarCC()
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") <> "S" Then Exit Sub
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentro.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtncentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtncentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentro.Text
                FrmSelCentroCostos.lbform.Text = "rec_car"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus

    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            lbcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            lbcliente.Text = ""
        End If
    End Sub
    '******************************************************************
    Private Sub txtciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtciudad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarletra(txtciudad, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarMoneda(txtvalor, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
        For i = 0 To grilla.RowCount - 1
            Try
                If Trim(grilla.Item("Descripcion", i).Value) = Trim(lbcliente.Text) Then
                    If lbdoc_aj.Text = txttipo.Text Then
                        grilla.Item("Creditos", i).Value = Moneda(txtvalor.Text)
                    Else
                        grilla.Item("Debitos", i).Value = Moneda(txtvalor.Text)
                    End If
                    CalularTotales()
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub txtconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcepto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '*****************************************************************
    Private Sub txtcheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheque.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtsucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsucursal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    '*****************************************************************
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        txtdv.Text = ""
        txtnit.Focus()
    End Sub
    Private Sub rbnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnit.CheckedChanged
        txtdv.Text = "-" & DigitoNIT(txtnit.Text)
        txtnit.Focus()
    End Sub
    '*****************************************************************
    Private Sub fecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtelaborado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtelaborado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtconta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    '*****************************************************************
    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
        CalularTotales()
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        '***************** INICIO VALIDAR SI SE PUEDE DIGITAR O NO *****************
        'Try
        '    If grilla.Item("editar", e.RowIndex).Value = "no" And (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") Then
        '        grilla.Columns(e.ColumnIndex).ReadOnly = True
        '    ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        '        grilla.Columns(e.ColumnIndex).ReadOnly = False
        '    Else
        '        grilla.Columns(e.ColumnIndex).ReadOnly = True
        '    End If
        'Catch ex As Exception 'puede mandar error cuando es nulo el valor
        '    If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        '        grilla.Columns(e.ColumnIndex).ReadOnly = False
        '    Else
        '        grilla.Columns(e.ColumnIndex).ReadOnly = True
        '    End If
        'End Try
        ''***************** FIN VALIDAR SI SE PUEDE DIGITAR O NO *****************
        'Try
        '    Select Case e.ColumnIndex
        '        Case 2  'CASO DEBITO 
        '        Case 3  'CASO CREDITO                     
        '        Case 0 'CASO CUENTA 
        '            If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
        '            SendKeys.Send(Chr(Keys.Space))
        '            SendKeys.Send(Chr(Keys.Back))
        '    End Select
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Try
            If e.RowIndex > 0 And UCase(grilla.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "FF" Then
                grilla.Item(e.ColumnIndex, e.RowIndex).Value = grilla.Item(e.ColumnIndex, e.RowIndex - 1).Value
                ValoresDefecto(e.RowIndex)
                Exit Sub
            End If
            Select Case e.ColumnIndex
                Case 1  'CASO DESCRIPCION                       
                    grilla.Item(1, e.RowIndex).Value = UCase(grilla.Item(1, e.RowIndex).Value)
                Case 2  'CASO DEBITO                    
                    grilla.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(2, e.RowIndex).Value.ToString), 2)
                    If grilla.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO 
                    If CDbl(grilla.Item(3, e.RowIndex).Value) = 0 Then
                        grilla.Item(3, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(3, e.RowIndex).Value.ToString), 2)
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    End If
                Case 4  'CASO BASE 
                    grilla.Item(4, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(4, e.RowIndex).Value.ToString), 2)
                Case 0 'CASO CUENTA
                    Buscarcuentas(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex

                Case 2 'CASO DEBITO
                    If grilla.Item(2, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(2, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO  
                    If grilla.Item(3, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 3  'CASO BASE 
                    If grilla.Item(4, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor de la base, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(4, e.RowIndex).Value = "0,00"
                Case 0  'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(0, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        CalularTotales()
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            Try
                If grilla.Item(2, i).Value.ToString = "" Then
                    grilla.Item(2, i).Value = "0,00"
                End If
            Catch ex As Exception
                grilla.Item(2, i).Value = "0,00"
            End Try
            Try
                If grilla.Item(3, i).Value.ToString = "" Then
                    grilla.Item(3, i).Value = "0,00"
                End If
            Catch ex As Exception
                grilla.Item(3, i).Value = "0,00"
            End Try
            Try
                If grilla.Item(4, i).Value.ToString = "" Then
                    grilla.Item(4, i).Value = "0,00"
                End If
            Catch ex As Exception
                grilla.Item(4, i).Value = "0,00"
            End Try
            Try
                If grilla.Item("doc_afe", i).Value.ToString = "" Then
                    grilla.Item("doc_afe", i).Value = grilla.Item("doc_afe", i - 1).Value
                End If
            Catch ex As Exception
                Try
                    grilla.Item("doc_afe", i).Value = grilla.Item("doc_afe", i - 1).Value
                Catch ex2 As Exception
                End Try
            End Try
            grilla.Item("abonado", i).Value = "0,00"
            grilla.Item("editar", i).Value = "si"
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        Try
            If cuenta = "" Then
                FrmCuentas.lbform.Text = "cpp_egre"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <= 0 Then
                    grilla.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "cpp_egre"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    grilla.Item(0, fila).Value = cuenta
                    grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descripcion")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If e.KeyCode = 8 Then
            'If fila = grilla.RowCount - 1 Then Exit Sub
            'QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub
    '*****************************************************************
    Public Sub GuardarTodo()
        Dim tabla As New DataTable
        Dim ban As Integer = 0
        '************** COMO ES NUEVO GUARDAR UNO QUE NO EXISTA ********************
        While ban = 0
            tabla.Clear()
            myCommand.CommandText = "SELECT doc FROM ot_cpc" & PerActual(0) & PerActual(1) & " WHERE doc ='" & lbdoc.Text & txtnumero.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then 'NO EXISTE
                ban = 1
            Else 'EXISTE BUSCO EL SGT
                txtnumero.Text = Val(txtnumero.Text) + 1
                ban = 0
            End If
        End While
        txtnumero.Text = NumeroDoc(txtnumero.Text)
        '************** RECORRER Y GUARDAR OK ********************
        For i = 0 To grilla.RowCount - 1
            If grilla.Item(0, i).Value <> "" Then
                Try
                    If cbaprobado.Text = "AP" Then
                        Pagos(i)
                        GuardarContable(i)
                        ActualizarCuentas(i)
                    End If
                    Guardar(i)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Exit Sub
                End Try
            End If
        Next
        '********* ACTUALIZAR CONSECUTIVO ***********************
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?actual", txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.CommandText = "Update tipdoc set actual" & PerActual(0) & PerActual(1) & "=?actual WHERE tipodoc=?tipodoc AND actual" & PerActual(0) & PerActual(1) & "<?actual;"
        myCommand.ExecuteNonQuery()
        '************** LISTO OK ********************
        lbestado.Text = "GUARDADO"
        Bloquear()
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("CARTERA", "GUARDAR COMPROBANTE DE CXC Nº: " & txttipo.Text & txtnumero.Text, "", "", "")
        End If
        '.....
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
    End Sub
    Public Sub ModificarTodo()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El documento " & lbdoc.Text & txtnumero.Text & " se va a Editar, ¿Desea Modificarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            '************** ELIMINAR PARA REMPLAZAR ********************
            Eliminar()
            '************** RECORRER Y GUARDAR OK ********************
            For i = 0 To grilla.RowCount - 1
                If grilla.Item(0, i).Value <> "" Then
                    Try
                        If cbaprobado.Text = "AP" Then
                            Pagos(i)
                            GuardarContable(i)
                            ActualizarCuentas(i)
                        End If
                        Guardar(i)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        Exit Sub
                    End Try
                End If
            Next
            '************** LISTO OK ********************
            lbestado.Text = "EDITADO"
            Bloquear()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("CARTERA", "MODIFICAR COMPROBANTE DE CXC Nº: " & txttipo.Text & txtnumero.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        End If
    End Sub
    '///////////////////////////////////////////////////////////////
    Public Sub Pagos(ByVal fila As Integer)
        '************* GUARDAR MONTO ABONADO *********************************************
        Try
            If CDbl(grilla.Item("abonado", fila).Value) > 0 Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?abonado", DIN(grilla.Item("abonado", fila).Value).ToString)
                myCommand.CommandText = "UPDATE cobdpen SET pagado=pagado+?abonado WHERE doc= TRIM('" & grilla.Item("doc_afe", fila).Value.ToString & "');"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            GuardarError(ex.ToString, "Recibo Cartera", "Registrar abono")
        End Try
    End Sub
    Function ValidarGuardar()
        Try
            Dim fec As Date
            fec = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("El dia no coincide con un formato de fecha correcto, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Return False
            Exit Function
        End Try
        If txtcentro.Enabled = True And txtncentro.Text = "" Then
            MsgBox("No ha digitado centro de costos, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtncentro.Focus()
            Return False
            Exit Function
        ElseIf txtvalor.Text = "0,00" Then
            MsgBox("No ha digitado el campo valor, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtvalor.Focus()
            Return False
            Exit Function
        ElseIf lbcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtnit.Focus()
            Return False
            Exit Function
        ElseIf chefectivo.Checked = False Then
            If txtcheque.Text = "" Then
                MsgBox("No ha digitado el numero del cheque, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtcheque.Focus()
                Return False
                Exit Function
            ElseIf Trim(txtbanco.Text) = "" Then
                MsgBox("No ha digitado el campo banco, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtbanco.Focus()
                Return False
                Exit Function
            ElseIf Trim(txtsucursal.Text) = "" Then
                MsgBox("No ha digitado el campo sucursal, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtsucursal.Focus()
                Return False
                Exit Function
            End If
        End If
        If grilla.RowCount < 2 Then
            MsgBox("Verifique los campos de contabilización.  ", MsgBoxStyle.Information, "SAE Control ")
            grilla.Focus()
            Return False
            Exit Function
        Else
            Dim db, cr As Double
            Dim sdb As Double = 0
            Dim scr As Double = 0
            For i = 0 To grilla.RowCount - 1
                If grilla.Item("Cuenta", i).Value <> "" Then
                    Try
                        db = CDbl(grilla.Item("Debitos", i).Value)
                    Catch ex As Exception
                        db = 0
                    End Try
                    sdb = sdb + db
                    Try
                        cr = CDbl(grilla.Item("Creditos", i).Value)
                    Catch ex As Exception
                        cr = 0
                    End Try
                    scr = scr + cr
                End If
            Next
            If sdb = 0 Or scr = 0 Then
                MsgBox("Verifique los campos Debitos y Créditos.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            ElseIf Moneda(sdb) <> Moneda(scr) Then
                MsgBox("Debitos(" & Moneda(sdb) & ") <> Créditos(" & Moneda(scr) & "); Las sumas deben ser iguales.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Private Sub AuditoriaRC()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                For i = 0 To grilla.RowCount - 1
                    If grilla.Item("Cuenta", i).Value <> "" Then
                        If grilla.Item("Descripcion", i).Value.ToString = lbcliente.Text Then
                            If chefectivo.Checked = True Then
                                Vali_cuent_Odoc("caj", txttipo.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, txttipo.Text & txtnumero.Text & "-" & lbper.Text, "")
                            Else
                                Vali_cuent_Odoc("ban", txttipo.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, txttipo.Text & txtnumero.Text & "-" & lbper.Text, "")
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                MsgBox("Error al Auditar, " & ex.ToString, MsgBoxStyle.Information)
            End Try
        End If
    End Sub
    Public Sub Guardar(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?grupo", "CE")
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumero.Text.ToString))
        myCommand.Parameters.AddWithValue("?doc_afec", grilla.Item("doc_afe", fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?ciudad", txtciudad.Text.ToString)
        myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
        If rbcc.Checked = True Then
            myCommand.Parameters.AddWithValue("?tn", "CC")
        Else
            myCommand.Parameters.AddWithValue("?tn", "NIT")
        End If
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 99))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?total", DIN(txtvalor.Text).ToString)
        If chefectivo.Checked = True Then
            myCommand.Parameters.AddWithValue("?tipo_pago", "efectivo")
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?banco", "")
            myCommand.Parameters.AddWithValue("?sucursal", "")
        ElseIf lbfp.Text = "Tarjeta" Then
            myCommand.Parameters.AddWithValue("?tipo_pago", "tarjeta")
            myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            myCommand.Parameters.AddWithValue("?banco", txtbanco.Text)
            myCommand.Parameters.AddWithValue("?sucursal", txtsucursal.Text)
        ElseIf lbfp.Text = "consignacion" Or lbfp.Text = "Consignacion" Or lbfp.Text = "Consignacion No." Then
            myCommand.Parameters.AddWithValue("?tipo_pago", "consig")
            myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            myCommand.Parameters.AddWithValue("?banco", txtbanco.Text)
            myCommand.Parameters.AddWithValue("?sucursal", txtsucursal.Text)
        Else
            myCommand.Parameters.AddWithValue("?tipo_pago", "cheque")
            myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            myCommand.Parameters.AddWithValue("?banco", txtbanco.Text)
            myCommand.Parameters.AddWithValue("?sucursal", txtsucursal.Text)
        End If
        '*********************************************************
        myCommand.Parameters.AddWithValue("?ccosto", Val(txtcentro.Text))
        myCommand.Parameters.AddWithValue("?fecha", fecha.Value)
        myCommand.Parameters.AddWithValue("?elaborado", CambiaCadena(txtelaborado.Text, 50))
        myCommand.Parameters.AddWithValue("?autorizado", CambiaCadena(txtaprobado.Text, 50))
        myCommand.Parameters.AddWithValue("?revisado", "")
        myCommand.Parameters.AddWithValue("?contabilizado", CambiaCadena(txtconta.Text, 50))
        myCommand.Parameters.AddWithValue("?doc_aj", " ")
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        myCommand.Parameters.AddWithValue("?abonado", DIN(grilla.Item("abonado", fila).Value).ToString)
        Try
            myCommand.Parameters.AddWithValue("?DocAnti", grilla.Item("DocAnti", fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?DocAnti", "")
        End Try
        myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text)
        myCommand.Parameters.AddWithValue("?codcon", grilla.Item("comision", fila).Value.ToString)
        '************* GUARDAR CONSULTA *********************************************
        myCommand.CommandText = "INSERT INTO ot_cpc" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?tipo_pago,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?DocAnti,?nitv,?codcon);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        If cbaprobado.Text = "AP" Then GuardarAnticipos(fila)
    End Sub
    Public Sub GuardarAnticipos(ByVal fila As Integer)
        'otros conceptos
        Dim sql As String = ""
        Dim sig As String = ""
        Try
            If Trim(grilla.Item("DocAnti", fila).Value.ToString) <> "" Then
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_de_clie SET causado = causado + " & DIN(grilla.Item("Debitos", fila).Value).ToString & " WHERE per_doc='" & Trim(grilla.Item("DocAnti", fila).Value.ToString) & "';"
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarContable(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?centro", Val(txtcentro.Text))
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", "0")
        myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
        myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
        If grilla.Item("Descripcion", fila).Value.ToString = lbcliente.Text Then
            If lbfp.Text = "Cheque No." And txtcheque.Text <> "" Then
                myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            Else
                myCommand.Parameters.AddWithValue("?cheque", "")
            End If
        Else
            myCommand.Parameters.AddWithValue("?cheque", "")
        End If
        myCommand.Parameters.AddWithValue("?modulo", "ctas x pagar")
        myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Public Sub ActualizarCuentas(ByVal i As Integer)
        Dim sql As String
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        Try
            db = CDbl(grilla.Item(2, i).Value.ToString)
        Catch ex As Exception
            db = 0
        End Try
        Try
            cb = CDbl(grilla.Item(3, i).Value.ToString)
        Catch ex As Exception
            cb = 0
        End Try
        suma = db - cb
        sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
            & debito & "=" & debito & " + " & DIN(db) & ", " _
            & credito & "=" & credito & " + " & DIN(cb) & " " _
            & "WHERE codigo='" & grilla.Item(0, i).Value & "';"
        Ejecutar(sql)
    End Sub
    Public Sub ModificarCuentas()
        Dim sql As String
        Dim tabla As New DataTable
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & Trim(lbdoc.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            Try
                db = CDbl(tabla.Rows(i).Item("debito").ToString)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cb = CDbl(tabla.Rows(i).Item("credito").ToString)
            Catch ex As Exception
                cb = 0
            End Try
            suma = db - cb
            sql = "UPDATE selpuc SET saldo=saldo - " & DIN(suma) & ", " & saldo & "=" & saldo & " - " & DIN(suma) & ", " _
                & debito & "=" & debito & " - " & DIN(db) & ", " _
                & credito & "=" & credito & " - " & DIN(cb) & " " _
                & "WHERE codigo='" & tabla.Rows(i).Item("codigo").ToString & "';"
            Ejecutar(sql)
        Next
    End Sub
    Public Sub Ejecutar(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Eliminar()
        Dim Sql, tabla As String
        '********* ACTUALIZAR LO ABONADO CON SENTENCIA SQL INNER JOIN ******************************************
        't1= tabla1(ctas_x_pagar) && t2=tabla2(ot_cppXX)
        ' ==> (ACTUALIZA TODOS LOS ABONOS SEGUN FACTURA Y COMPROBANTE DE EGRESO)
        'tabla = "ot_cpp" & PerActual(0) & PerActual(1)
        'Sql = "UPDATE ctas_x_pagar t1 INNER JOIN (" & tabla & " t2) " _
        '& "ON t1.doc = t2.doc_afec SET t1.pagado = t1.pagado - t2.abonado " _
        '& "WHERE t2.doc = '" & lbdoc.Text & txtnumero.Text & "';"
        'Ejecutar(Sql)
        '**************** ACTUALIZO CONTABILIDAD (ESTO SOLO SUCEDE SI EXISTE EL DOCUMENTO) **********************************
        tabla = "documentos" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & lbdoc.Text & "';"
        Ejecutar(Sql)
        '***************** ELINIAR LOS DATOS DEL COMPROBANTE PARA VOLVER A INSERTAR *******************************************
        tabla = "ot_cpc" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc='" & lbdoc.Text & txtnumero.Text & "';"
        Ejecutar(Sql)
    End Sub
    '******************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Private Sub ColocarLogo()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
            img.ScaleToFit(80, 160)
            img.SetAbsolutePosition(8, 774)
            img.Alignment = Element.ALIGN_RIGHT
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 110
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg(1)
            If logo = "SI" Then
                ColocarLogo()
            End If
            '********CABECERA************** 
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.SetFontAndSize(fuente, 11)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbnomdoc.Text, 388, 807, 0)
            cb.EndText()
            cb.BeginText()
            '********NUMERO************** 
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PerActual & " - " & lbdoc.Text & txtnumero.Text, 410, 780, 0)
            cb.EndText()
            cb.BeginText()
            '********** BANNER ********************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '*******FORMA DE PAGO*****************
            If chefectivo.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 590, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcheque.Text, 457, 605, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtbanco.Text, 516, 605, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtsucursal.Text, 454, 588, 0)
            End If
            '*******CUERPO**********************
            k = 595
            Dim fin As Integer
            If ChPrint.Checked = True Then
                fin = grilla.RowCount - 1
            Else
                fin = 1
            End If
            Dim cad As String = "///"
            For i = 0 To fin
                If ChPrint.Checked = True Then cad = Trim(grilla.Item(0, i).Value)
                If cad <> "" Then
                    If i = 0 Or i = 1 Then
                        k = k - 22
                    Else
                        k = k - 18
                    End If
                    'If (i Mod 2) = 1 Then k = k + 1
                    'If i = 1 Then k = k - 2
                    If k < tope Then
                        k = 760
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If i > 0 Then
                        cb.EndText()
                        ColocarImg(2)
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If ChPrint.Checked = True Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value, 27), 75, k + 1, 0)
                        If grilla.Item(2, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(2, i).Value), 312, k + 1, 0)
                        If grilla.Item(3, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 401, k + 1, 0)
                    End If
                End If
            Next
            cb.EndText()
            k = k - 96
            ColocarImg(3)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = k + 42
            PrintNit()
            k = k - 17
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fecha.Value, 515, k, 0)
            k = k - 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 12, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 145, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtconta.Text, 278, k, 0)
            Observacion()
            k = k - 20
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            '*********** FIN ***********************
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
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Observacion()
        Try
            If Trim(lbanulado.Text) <> "" Then
                k = k - 20
                cb.ShowTextAligned(50, "DOCUMENTO " & lbanulado.Text & ". ", 10, k, 0)
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT aj FROM parotdoc;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item("aj") = lbdoc.Text Then
                    tabla.Clear()
                    myCommand.CommandText = "SELECT doc_afec FROM ot_cpc" & PerActual(0) & PerActual(1) & " WHERE doc='" & lbdoc.Text.ToString & txtnumero.Text.ToString & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If Trim(tabla.Rows(0).Item("doc_afec").ToString) <> "" Then
                        k = k - 20
                        cb.ShowTextAligned(50, "ANULA AL DOCUMENTO " & tabla.Rows(0).Item("doc_afec") & ". ", 10, k, 0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner()
        Dim d As Integer = 0
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 800
        If logo = "SI" Then
            d = 88
        Else
            d = 10
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), d, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), d, k, 0)
        If txtncentro.Text <> "" Then
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CENTRO DE COSTOS: " & txtcentro.Text & " - " & txtncentro.Text, d, k, 0)
        End If
        k = 750
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtciudad.Text, 60, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 338, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtvalor.Text), 575, k, 0)
        'pagado a
        k = 716
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbcliente.Text, 73, k, 0)
        'concepto
        k = k - 28
        Control_de_linea(txtconcepto.Text, 110, 80)
        'valor en letras
        k = 655
        Control_de_linea(": " & lbsuma.Text, 137, 75)
    End Sub
    Public Sub ColocarImg(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                If lbfp.Text = "Tarjeta" Then
                    img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE1_22.jpg")
                ElseIf lbfp.Text = "Consignacion" Or lbfp.Text = "consignacion" Or lbfp.Text = "Consignacion No." Then
                    img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE1_C2.jpg")
                Else
                    img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE12.jpg")
                End If
                img.SetAbsolutePosition(0, 570)
                img.ScaleToFit(598, 500)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE2.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 50)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE3.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 170)
            End If
            img.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal pos As Integer, ByVal tam As Integer)
        Dim s As Integer = 1
        linea = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = " " And j > tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
                    linea = ""
                    k = k - 10
                    s = s + 1
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
    End Sub
    Public Sub PrintNit()
        If rbcc.Checked = True Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text, 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 419, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text & txtdv.Text, 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "X", 456, k, 0)
        End If
    End Sub
    '*****************************************************************
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        MiConexion(bda)
        Cerrar()
        If txttipo.Enabled = True Then
            FrmItemCartera.txttipo.Enabled = True
        Else
            FrmItemCartera.txttipo.Enabled = False
        End If
        If txttipo.Text = "" Then
            MsgBox("Favor seleccione un tipo de documento antes de continuar. ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
            Exit Sub
        End If
        If txtnitv.Enabled = True And txtnitv.Text = "" Then
            MsgBox("Favor seleccione el nit del vendedor antes de continuar. ", MsgBoxStyle.Information, "SAE Control")
            txtnitv.Focus()
            Exit Sub
        End If

        If grilla.RowCount <= 1 Then
            Try
                FrmItemCartera.gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            FrmItemCartera.lbfp.Text = ""
            FrmItemCartera.lbnum.Text = ""
            FrmItemCartera.lbbanco.Text = ""
        End If
        FrmItemCartera.txtvalor.Text = txtvalor.Text
        FrmItemCartera.txtnitc.Text = txtnit.Text
        FrmItemCartera.txtcliente.Text = lbcliente.Text
        FrmItemCartera.txttipo.Text = txttipo.Text
        FrmItemCartera.txtperiodo.Text = "/" & PerActual
        FrmItemCartera.txtnumfac.Text = NumeroDoc(txtnumero.Text)
        FrmItemCartera.lbper.Text = PerActual
        Try
            FrmItemCartera.txtdia.Text = txtdia.Text
            Dim f As Date = CDate(FrmItemCartera.txtdia.Text & FrmItemCartera.txtperiodo.Text)
        Catch ex As Exception
            FrmItemCartera.txtdia.Text = "01"
        End Try
        '**********************************
        FrmItemCartera.ShowDialog()
        CalularTotales()
        If lbhaydoc.Text = "si" Then

        End If
    End Sub
    Public Sub parametros()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT par_rc, par_ci, par_aju, concomi, editarcc FROM car_par;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            Dim nc As String = ""
            Dim td As New DataTable
            myCommand.CommandText = "SELECT nc FROM parotdoc ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            Refresh()
            If td.Rows.Count > 0 Then
                nc = td.Rows(0).Item("nc")
            End If

            If tabla.Rows.Count = 0 Then
                MsgBox("No han definido documentos para esta interfaz.  ", MsgBoxStyle.Information, "SAE Control")
                Me.Close()
            End If
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("par_rc")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item(0)))
            End If
            If Trim(tabla.Rows(0).Item("par_ci")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item(1)))
            End If
            If nc <> "" Then
                txttipo.Items.Add(Trim(nc))
            End If
            Try
                lbdoc_aj.Text = Trim(tabla.Rows(0).Item(2))
            Catch ex As Exception
                lbdoc_aj.Text = ""
            End Try
            Try
                lbcomi.Text = tabla.Rows(0).Item("concomi")
            Catch ex As Exception
            End Try
            lbedcc.Text = tabla.Rows(0).Item("editarcc")
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
    End Sub
    Public Sub limpiar()
        txtnitv.Text = ""
        txtnomv.Text = ""
        txtaprobado.Text = ""
        txtconta.Text = ""
        txtcentro.Text = ""
        txtncentro.Text = ""
        txtciudad.Text = ""
        cbaprobado.Text = ""
        txtvalor.Text = "0,00"
        txtvalor_LostFocus(AcceptButton, AcceptButton)
        lbcliente.Text = ""
        txtnit.Text = ""
        txtconcepto.Text = ""
        lbdb.Text = "0,00"
        lbcr.Text = "0,00"
        lbdif.Text = "0,00"
        Try
            grilla.Rows.Clear()
        Catch ex As Exception
        End Try
        DesBloquear()
        If txtcentro.Enabled = True Then
            txtcentro.Focus()
        Else
            txtciudad.Focus()
        End If
        
    End Sub
    Dim logo As String
    Private Sub FrmReciboCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = "NULO"
        lbper.Text = PerActual & " - "
        txtperiodo.Text = "/" & PerActual
        Try
            Dim tablacomp As New DataTable
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            lbcompa.Text = tablacomp.Rows(0).Item("descripcion")
            lbnit.Text = "NIT: " & tablacomp.Rows(0).Item("nit")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        logo = ""
        Try
            Dim td As New DataTable
            myCommand.CommandText = "SELECT logo FROM parotdoc ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            logo = td.Rows(0).Item("logo")
        Catch ex As Exception
            logo = "NO"
        End Try
        parametros()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub


    Private Sub txttipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Trim(txttipo.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            lbnomdoc.Text = ""
            Exit Sub
        End If
        lbdoc.Text = txttipo.Text
        lbnomdoc.Text = tabla.Rows(0).Item(0)
        BuscarNumero()
    End Sub

    Public Sub BuscarNumero()
        Try
            Dim tabla As New DataTable
            Dim item As Integer
            myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc where tipodoc='" & Trim(txttipo.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            item = tabla.Rows(0).Item(0)
            If item < 1 Then
                txtnumero.Text = NumeroDoc(1)
            Else
                txtnumero.Text = NumeroDoc(item + 1)
            End If
        Catch ex As Exception
            txtnumero.Text = NumeroDoc(1)
        End Try
    End Sub

    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub

    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        Try
            If Val(txtdia.Text) < 10 Then
                txtdia.Text = "0" & Val(txtdia.Text)
            End If
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("Error al digitar el dia, verifique. ", MsgBoxStyle.Information)
            txtdia.Text = "01"
        End Try
    End Sub

    Private Sub txtcentro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentro.TextChanged
        Try
            If txtcentro.Text = "" Or txtcentro.Text = "0" Then
                txtcentro.Text = ""
                txtncentro.Text = ""
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentro.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtncentro.Text = ""
                If tabla.Rows.Count > 0 Then
                    txtncentro.Text = tabla.Rows(0).Item("nombre")
                Else
                    txtncentro.Text = ""
                End If
            End If
        Catch ex As Exception
            txtncentro.Text = ""
        End Try
    End Sub

    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        validarnumero(txtnumero, e)
    End Sub
    Private Sub txtnumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumero.LostFocus
        txtnumero.Text = NumeroDoc(txtnumero.Text)
    End Sub

    Private Sub cmdver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdver.Click
        Dim td As String = ""
        If txttipo.Items.Count > 0 Then
            For i = 0 To txttipo.Items.Count - 1
                td = td & "'" & txttipo.Items(i).ToString & "',"
            Next
            td = Strings.Left(td, Strings.Len(td) - 1)
        End If

        Try
            FrmSelOtdoc.lbtabla.Text = "ot_cpc" & PerActual(0) & PerActual(1) & ""
            FrmSelOtdoc.tdoc.Text = td
            FrmSelOtdoc.lbform.Text = "ReciCartera"
            FrmSelOtdoc.ShowDialog()
            BuscarDocumento(txttipo.Text & txtnumero.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ValidarNIT(txtnitv, e)
    End Sub


    
    Private Sub txtnitv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus

        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM vendedores WHERE nitv='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtnitv.Text = ""
            Try
                Dim items As Integer
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM vendedores where estado='activo' ORDER BY nombre ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                Refresh()
                items = tabla2.Rows.Count
                FrmSelVendedor.gitems.RowCount = items + 1
                For i = 0 To items - 1
                    FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                    FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
                Next

                FrmSelVendedor.lbform.Text = "reccar"
                FrmSelVendedor.ShowDialog()
            Catch ex As Exception
            End Try

        Else
            txtnomv.Text = tabla.Rows(0).Item("nombre")
        End If
    End Sub

    Private Sub txtnitv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged
        If txtnitv.Text = "" Then
            txtnomv.Text = ""
        End If
    End Sub
End Class