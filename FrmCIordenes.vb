Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports MySql.Data.MySqlClient
Public Class FrmCIordenes

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Bloquear()
        Limpiar()
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Desdloquear()
        Limpiar()
        Buscardoc()
        lbestado.Text = "NUEVO"
        i1.Focus()
    End Sub
    Private Sub Buscardoc()

        Dim ta As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select ci, rc from parrecaudo "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then
            MsgBox("No ha seleccionado el tipo de documento a usar para este proceso", MsgBoxStyle.Information, "Verificacion")
            Me.Close()
        Else
            If ta.Rows(0).Item("ci") = "" Then
                MsgBox("Seleccione el tipo de documento para registrar los CI", MsgBoxStyle.Information, "SAE")
                Exit Sub
            End If
            Dim td As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select tipodoc, descripcion, actual" & Strings.Left(PerActual, 2) & ",grupo, actualfc from tipdoc where tipodoc='" & ta.Rows(0).Item("ci") & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)

            txtDip.Text = td.Rows(0).Item(0)
            txtNip.Text = td.Rows(0).Item(1)
            If td.Rows(0).Item("grupo") = "FC" Then
                txtnumIP.Text = NumeroDoc(Val(td.Rows(0).Item("actualfc")) + 1)
            Else
                txtnumIP.Text = NumeroDoc(Val(td.Rows(0).Item(2)) + 1)
            End If


            If ta.Rows(0).Item("rc") = "" Then
                MsgBox("Seleccione el tipo de documento para registrar los RC", MsgBoxStyle.Information, "SAE")
                Exit Sub
            End If
            Dim td2 As New DataTable
            td2.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select tipodoc, descripcion, actual" & Strings.Left(PerActual, 2) & ",grupo, actualfc from tipdoc where tipodoc='" & ta.Rows(0).Item("rc") & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td2)
            txtDrc.Text = td2.Rows(0).Item(0)
            txtNrc.Text = td2.Rows(0).Item(1)
            If td.Rows(0).Item("grupo") = "FC" Then
                txtnumRC.Text = NumeroDoc(Val(td2.Rows(0).Item("actualfc")) + 1)
            Else
                txtnumRC.Text = NumeroDoc(Val(td2.Rows(0).Item(2)) + 1)
            End If
        End If


    End Sub
    Private Sub Desdloquear()
        g0.Enabled = True
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        '......
        txtrb.Enabled = True
        txtrb1.Enabled = True
        txtnomrb.Enabled = True
        txtconcepto.Enabled = True
        txtvalor.Enabled = True
        txtdia.Enabled = True
        cbper.Enabled = True
        txtnit.Enabled = True

        cmdBanco.Enabled = True
        grilla2.ReadOnly = False
        grilla1.ReadOnly = False

        CmdNuevo.Enabled = False
        cmdprint.Enabled = False
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        CmdCons.Enabled = False
    End Sub
    Private Sub Bloquear()

        g0.Enabled = False
        txtrb.Enabled = False
        txtrb1.Enabled = False
        txtnomrb.Enabled = False
        txtconcepto.Enabled = False
        txtvalor.Enabled = False
        txtdia.Enabled = False
        cbper.Enabled = False
        txtnit.Enabled = False

        cmdBanco.Enabled = False
        grilla1.ReadOnly = True
        grilla2.ReadOnly = True

        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        '......
        CmdNuevo.Enabled = True
        cmdprint.Enabled = True
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        CmdCons.Enabled = True
    End Sub
    Dim cm, a As String
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmCIordenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        Dim ok As String = "n"
        myCommand.CommandText = "SHOW DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = "presupuesto" & a Then
                ok = "s"
                Exit For
            End If
        Next
        If ok = "n" Then
            MsgBox("Esta empresa no usa el software de Presupuesto", MsgBoxStyle.Information, "SAE")
            Me.Close()
        End If

        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "c.ingc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "c.ingc_fut"
        Else
            cm = "c.ingc_cgdg"
        End If
        Limpiar()
        Bloquear()
    End Sub
    Private Sub BuscarRubr()

        Dim tabla As New DataTable
        myCommand.CommandText = " select " & cm & ", c.ingc_concepto, c.ingc_cod1 , c.ingc_sd, v.ingv_credito, v.ingv_contrac " _
        & " from presupuesto" & a & ".ingconcepto c, presupuesto" & a & ".ingvalores v " _
        & " where " & cm & " = '" & Trim(txtrb.Text) & "' AND c.ingc_sd='D' and c.ingc_cod1= v.ingv_cod1"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtrb1.Text = tabla.Rows(0).Item("ingc_cod1")
            txtnomrb.Text = tabla.Rows(0).Item("ingc_concepto")
            txtcred.Text = tabla.Rows(0).Item("ingv_contrac")
            txtdeb.Text = tabla.Rows(0).Item("ingv_credito")
        Else
            Try
                Try
                    txtrb.Text = ""
                    txtrb1.Text = ""
                    txtnomrb.Text = ""
                    txtdeb.Text = ""
                    txtcred.Text = ""
                    limpiarGrill()
                    limpBanco()
                Catch ex As Exception
                End Try
                FrmSelRubrIng.lbform.Text = "ingp"
                FrmSelRubrIng.lbcm.Text = cm
                FrmSelRubrIng.ShowDialog()
                If txtrb1.Text = "" Then
                    MsgBox("Confirme el rubro nuevamente", MsgBoxStyle.Information, "SAE")
                    txtrb.Text = ""
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub Buscarcta1(ByVal cuenta As String, ByVal fila As Integer, ByVal tp As String)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ciod1"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If tp <> "cs" Then
                    grilla1.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "ciod1"
                    FrmCuentas.lbfila.Text = fila
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                End If
            Else
                grilla1.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
            End If
        End If

    End Sub
    Public Sub Buscarcta2(ByVal cuenta As String, ByVal fila As Integer, ByVal tp As String)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ciod2"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If tp <> "cs" Then
                    'If FrmEntradaDatos.nivel_cuenta(grilla2.Item(0, fila).Value) = True Then
                    grilla2.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "ciod2"
                    FrmCuentas.lbfila.Text = fila
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                    'End If
                End If
            Else
                grilla2.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
            End If
        End If

    End Sub
    Private Sub Limpiar()
        txtnum.Text = ""
        lbestado.Text = ""
        txtconcepto.Text = ""
        txtdeb.Text = ""
        txtcred.Text = ""
        txtrb.Text = ""
        txtrb1.Text = ""
        txtnomrb.Text = ""
        grilla1.Rows.Clear()
        grilla2.Rows.Clear()
        txtvalor.Text = Moneda(0)
        txtdia.Text = Now.Day.ToString
        cbper.Text = Strings.Left(PerActual, 2)
        txtperiodo.Text = Strings.Right(PerActual, 5)
        txtDip.Text = ""
        txtNip.Text = ""
        txtnumIP.Text = ""
        txtDrc.Text = ""
        txtNrc.Text = ""
        txtnumRC.Text = ""
        txtnitb.Text = ""
        txtbanco.Text = ""
        txtctab.Text = ""
        txtnit.Text = ""
        txtnomt.Text = ""
    End Sub

    Private Sub txtrb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrb.LostFocus
        BuscarRubr()
    End Sub
    Private Sub AddCtas()

        Try
            '//// GRILLA1 IP
            Try
                grilla1.Rows.Clear()
            Catch ex As Exception
            End Try
            grilla1.RowCount = 3

            If txtdeb.Text <> 0 And txtdeb.Text <> "" Then
                grilla1.Item("cta1", 0).Value = txtdeb.Text
                Buscarcta1(txtdeb.Text, 0, "cs")
            Else
                grilla1.Item("cta1", 0).Value = ""
            End If
            grilla1.Item("db1", 0).Value = Moneda(txtvalor.Text)
            grilla1.Item("cd1", 0).Value = Moneda(0)
            '...
            If txtcred.Text <> 0 And txtcred.Text <> "" Then
                grilla1.Item("cta1", 1).Value = txtcred.Text
                Buscarcta1(txtcred.Text, 1, "cs")
            Else
                grilla1.Item("cta1", 1).Value = ""
            End If
            grilla1.Item("db1", 1).Value = Moneda(0)
            grilla1.Item("cd1", 1).Value = Moneda(txtvalor.Text)

            '//// GRILLA2 RC
            Try
                grilla2.Rows.Clear()
            Catch ex As Exception
            End Try
            grilla2.RowCount = 3

            If txtdeb.Text <> 0 And txtdeb.Text <> "" Then
                grilla2.Item("cta2", 0).Value = txtdeb.Text
                Buscarcta2(txtdeb.Text, 0, "cs")
            Else
                grilla2.Item("cta2", 0).Value = ""
            End If
            grilla2.Item("db2", 0).Value = Moneda(0)
            grilla2.Item("cd2", 0).Value = txtvalor.Text
        Catch ex As Exception
            MsgBox("Verifique el rubro o las cuentas", MsgBoxStyle.Information, "Verificacion")
        End Try
    End Sub
    Private Sub txtrb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrb.TextChanged
        If Trim(txtrb.Text) = "" Then
            txtrb1.Text = ""
            txtnomrb.Text = ""
            txtdeb.Text = ""
            txtcred.Text = ""
            limpiarGrill()
            limpBanco()
        End If
    End Sub

    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        limpiarGrill()
        If txtrb.Text <> "" And txtvalor.Text <> Moneda(0) Then
            AddCtas()
        End If
    End Sub
    Private Sub limpiarGrill()
        grilla1.Rows.Clear()
        grilla2.Rows.Clear()
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Then
                ValidarNIT(txtnit, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Try
            BuscarTerce()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub BuscarTerce()
        If Trim(txtnit.Text) = "" Then
            Try
                FrmSelCliente.lbform.Text = "ingop"
                FrmSelCliente.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtnomt.Text = ""
                Dim resultado As MsgBoxResult
                resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    frmterceros.lbform.Text = "ingop"
                    frmterceros.txtnit.Text = txtnomt.Text
                    frmterceros.lbestado.Text = "NUEVO"
                    frmterceros.cbtipo.Text = "CLIENTES"
                    frmterceros.rbnatural.Checked = True
                    frmterceros.txtnit.Focus()
                    frmterceros.ShowDialog()
                    txtnit.Focus()
                Else
                    txtnit.Text = ""
                End If
            Else  'mostrar uno solo q coinside
                txtnomt.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            End If
        End If

    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        If Trim(txtnit.Text) = "" Then
            txtnomt.Text = ""
        End If
    End Sub

    Private Sub grilla1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla1.CellEndEdit
        If e.RowIndex >= grilla1.RowCount - 1 Then Exit Sub
        Select Case e.ColumnIndex
            Case 0
                Buscarcta1(grilla1.Item(0, e.RowIndex).Value, e.RowIndex, "")
            Case 2
                Try
                    grilla1.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla1.Item(2, e.RowIndex).Value.ToString), 2)
                    If grilla1.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla1.Item(3, e.RowIndex).Value = "0,00"
                Catch ex As Exception
                    grilla1.Item(2, e.RowIndex).Value = "0,00"
                End Try
            Case 3
                Try
                    grilla1.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla1.Item(3, e.RowIndex).Value.ToString), 2)
                    If grilla1.Item(3, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla1.Item(2, e.RowIndex).Value = "0,00"
                Catch ex As Exception
                    grilla1.Item(3, e.RowIndex).Value = "0,00"
                End Try
        End Select
    End Sub

    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        If Int(txtdia.Text) < 9 Then
            txtdia.Text = "0" & Int(txtdia.Text)
        End If
        Try
            Dim mifec As Date
            mifec = txtdia.Text & "/" & cbper.Text & txtperiodo.Text
            'MsgBox(mifec)
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
        End Try
    End Sub

    Private Sub grilla2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla2.CellEndEdit
        If e.RowIndex >= grilla2.RowCount - 1 Then Exit Sub
        Select Case e.ColumnIndex
            Case 0
                Buscarcta2(grilla2.Item(0, e.RowIndex).Value, e.RowIndex, "")
            Case 2
                Try
                    grilla2.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla2.Item(2, e.RowIndex).Value.ToString), 2)
                    If grilla2.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla2.Item(3, e.RowIndex).Value = "0,00"
                Catch ex As Exception
                    grilla2.Item(2, e.RowIndex).Value = "0,00"
                End Try
            Case 3
                Try
                    grilla2.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla2.Item(3, e.RowIndex).Value.ToString), 2)
                    If grilla2.Item(3, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla2.Item(2, e.RowIndex).Value = "0,00"
                Catch ex As Exception
                    grilla2.Item(3, e.RowIndex).Value = "0,00"
                End Try
        End Select
    End Sub

    Private Sub cmdBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBanco.Click
        Try
            If lbestado.Text <> "EDITAR" Then
                limpBanco()
            End If
            FrmSelBanco.lbform.Text = "ciord"
            FrmSelBanco.ShowDialog()
            If txtnitb.Text <> "" Then
                If txtctab.Text <> "" Then
                    grilla2.Item("cta2", 1).Value = txtctab.Text
                    Buscarcta2(txtctab.Text, 1, "cs")
                Else
                    grilla2.Item("cta2", 1).Value = ""
                End If
                grilla2.Item("db2", 1).Value = txtvalor.Text
                grilla2.Item("cd2", 1).Value = Moneda(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub limpBanco()
        Try
            txtnitb.Text = ""
            txtbanco.Text = ""
            txtctab.Text = ""

            grilla2.Item("cta2", 1).Value = ""
            grilla2.Item("deta2", 1).Value = ""
            grilla2.Item("db2", 1).Value = Moneda(0)
            grilla2.Item("cd2", 1).Value = Moneda(0)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        MiConexion(bda)
        If lbestado.Text <> "EDITAR" Then
            If ValidarGuardar() = False Then Exit Sub
            Guardar()
            For i = 0 To grilla1.RowCount - 1
                If grilla1.Item(0, i).Value <> "" Then
                    GuardarContable1(i)
                End If
            Next
            If i1.Checked = True Then
                For i = 0 To grilla2.RowCount - 1
                    If grilla2.Item(0, i).Value <> "" Then
                        GuardarContable2(i)
                    End If
                Next
            End If
            
            Ingres_Presup()
            ActConsecutivo()
        Else
            Modificar()
            For i = 0 To grilla1.RowCount - 1
                If grilla1.Item(0, i).Value <> "" Then
                    GuardarContable1(i)
                End If
            Next
            If i1.Checked = True Then
                For i = 0 To grilla2.RowCount - 1
                    If grilla2.Item(0, i).Value <> "" Then
                        GuardarContable2(i)
                    End If
                Next
            End If
            Ingres_Presup()
            Limpiar()
        End If

        lbestado.Text = "GUARDADO"
        Cerrar()
        MsgBox("Documento guardado", MsgBoxStyle.Information, "Confirmacion")
        Bloquear()
    End Sub
    Private Sub Modificar()
        EliminarDatos()
        Guardar()
    End Sub
    Private Sub EliminarDatos()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM documentos" & cbper.Text & " WHERE doc='" & DIN(txtnumIP.Text) & "' and tipodoc='" & txtDip.Text & "';"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM documentos" & cbper.Text & " WHERE doc='" & DIN(txtnumRC.Text) & "' and tipodoc='" & txtDrc.Text & "';"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM otdoc_pres  WHERE num='" & DIN(txtnum.Text) & "' ;"
        myCommand.ExecuteNonQuery()

        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM " & pbd & ".movingresos  WHERE movi_reconoce='" & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "';"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM " & pbd & ".recaudos  WHERE rec_nrodoc='" & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "';"
        myCommand.ExecuteNonQuery()

    End Sub
    Function ValidarGuardar()
        If txtrb.Text = "" Then
            MsgBox("Verifique el rubro  ", MsgBoxStyle.Information, "Verifique")
            txtrb.Focus()
            Return False
        End If
        If txtnit.Text = "" Then
            MsgBox("Verifique el nit del tercero  ", MsgBoxStyle.Information, "Verifique")
            txtnit.Focus()
            Return False
        End If
        If txtvalor.Text = Moneda(0) Then
            MsgBox("Verifique el valor ", MsgBoxStyle.Information, "Verifique")
            Return False
        End If
        If txtnitb.Text = "" And i1.Checked = True Then
            MsgBox("Verifique los datos del banco ", MsgBoxStyle.Information, "Verifique")
            Return False
        End If
        Return True
    End Function
    Private Sub ActConsecutivo()

        Dim t2 As New DataTable
        myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & txtDip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        Dim cs As String = ""
        If t2.Rows(0).Item("grupo") <> "FC" Then
            cs = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
        Else
            cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
        End If

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?actual", DIN(txtnumIP.Text))
        myCommand.Parameters.AddWithValue("?tipodoc", txtDip.Text)
        myCommand.CommandText = cs
        myCommand.ExecuteNonQuery()

        If i1.Checked = True Then
            Dim t3 As New DataTable
            t3.Clear()
            myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & txtDrc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t3)
            cs = ""
            If t2.Rows(0).Item("grupo") <> "FC" Then
                cs = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
            Else
                cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            End If
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", DIN(txtnumRC.Text))
            myCommand.Parameters.AddWithValue("?tipodoc", txtDrc.Text)
            myCommand.CommandText = cs
            myCommand.ExecuteNonQuery()
        End If
        
    End Sub
    Private Sub Guardar()
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?rb", txtnomrb.Text)
            myCommand.Parameters.AddWithValue("?cod1", txtrb1.Text)
            myCommand.Parameters.AddWithValue("?cod2", txtrb.Text)
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            myCommand.Parameters.AddWithValue("?nom", txtnomt.Text)
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtdia.Text & "/" & cbper.Text & txtperiodo.Text))
            myCommand.Parameters.AddWithValue("?ci", txtDip.Text)
            myCommand.Parameters.AddWithValue("?numci", Val(txtnumIP.Text))
            If i1.Checked = True Then
                myCommand.Parameters.AddWithValue("?rc", txtDrc.Text)
                myCommand.Parameters.AddWithValue("?numrc", Val(txtnumRC.Text))
            Else
                myCommand.Parameters.AddWithValue("?rc", txtDrc.Text)
                myCommand.Parameters.AddWithValue("?numrc", Val(0))
            End If
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text)
            myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))
            If i1.Checked = True Then
                myCommand.Parameters.AddWithValue("?tp", 1)
            Else
                myCommand.Parameters.AddWithValue("?tp", 2)
            End If
            myCommand.CommandText = "INSERT INTO otdoc_pres VALUES(NULL,?rb,?cod1,?cod2,?nit,?nom,?fecha,?ci,?numci,?rc,?numrc,?concepto,?valor,?tp);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error " & ex.ToString)
        End Try
    End Sub
    Public Sub GuardarContable1(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", Val(txtnumIP.Text))
            myCommand.Parameters.AddWithValue("?tipodoc", txtDip.Text)
            myCommand.Parameters.AddWithValue("?periodo", cbper.Text & txtperiodo.Text)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?centro", 0)
            myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla1.Item(1, fila).Value.ToString, 50))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla1.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla1.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?codigo", grilla1.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?base", 0)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
            myCommand.CommandText = "INSERT INTO documentos" & cbper.Text & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox("Error GuardarContable1 " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Public Sub GuardarContable2(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", Val(txtnumRC.Text))
            myCommand.Parameters.AddWithValue("?tipodoc", txtDrc.Text)
            myCommand.Parameters.AddWithValue("?periodo", cbper.Text & txtperiodo.Text)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?centro", 0)
            myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla2.Item(1, fila).Value.ToString, 50))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla2.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla2.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?codigo", grilla2.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?base", 0)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
            myCommand.CommandText = "INSERT INTO documentos" & cbper.Text & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox("Error GuardarContable2 " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Private Sub Ingres_Presup()

        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim cta As String = ""
        Dim ing As String = ""
        Dim val As Double = 0
        Dim f As String = Strings.Right(txtperiodo.Text, 4) & cbper.Text & txtdia.Text

        val = txtvalor.Text
        ing = txtrb1.Text
        Try
            'Guardar MovIng
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                            & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                            & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                            & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "' )"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
           & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
           & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
           & "   " & f & ", '" & ing & "',  'RECAUDO POR " & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
           & " '',  '',  'sae_otrosing', '" & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "', '" & txtnit.Text & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            '..Buscar nivel
            Dim tam As Integer = Len(ing)
            Dim lik As String = ""

            Dim tg As New DataTable
            myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tg)
            Dim nv As String = tg.Rows(0).Item(0)
            Dim num As String = tg.Rows(0).Item(1)
            For j = 0 To tam
                lik = Strings.Left(ing, tam - j)

                Dim tc As New DataTable
                tc.Clear()
                myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                & "FROM " & pbd & ".ingvalores as v " _
                                & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                & "c.ingc_concepto LIMIT 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    For k = 0 To tc.Rows.Count - 1
                        nv = tc.Rows(k).Item("nivel")
                        num = tc.Rows(k).Item("num")
                        'Guardar MovIng
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                        & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                        & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                        & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                        & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & cbper.Text & "-" & txtDip.Text & Int(txtnumIP.Text) & "' )"
                        myCommand.ExecuteNonQuery()

                    Next
                End If

            Next
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try

    End Sub

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        Try
            FrmSelCiorden.lbform.Text = "ciorden"
            FrmSelCiorden.ShowDialog()
        Catch ex As Exception
        End Try
        If txtnum.Text <> "" Then
            BuscarContable()
        End If
    End Sub
    Private Sub BuscarContable()

        Try
            Dim td As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select tipodoc, descripcion from tipdoc where tipodoc IN ('" & txtDip.Text & "', '" & txtDrc.Text & "') "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            If td.Rows.Count > 0 Then
                Try
                    txtNip.Text = td.Rows(0).Item("descripcion")
                    txtNrc.Text = td.Rows(1).Item("descripcion")
                Catch ex As Exception
                End Try
            End If


            Dim t As New DataTable
            t.Clear()
            myCommand.CommandText = "SELECT * FROM documentos" & cbper.Text & " WHERE tipodoc ='" & txtDip.Text & "' and doc='" & txtnumIP.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()
            grilla1.Rows.Clear()
            If t.Rows.Count <> 0 Then
                grilla1.RowCount = t.Rows.Count + 1
                For i = 0 To t.Rows.Count - 1
                    grilla1.Item("cta1", i).Value = t.Rows(i).Item("codigo")
                    grilla1.Item("deta1", i).Value = t.Rows(i).Item("descri")
                    grilla1.Item("db1", i).Value = t.Rows(i).Item("debito")
                    grilla1.Item("cd1", i).Value = t.Rows(i).Item("credito")
                Next
            End If
            '.............
            t.Clear()
            myCommand.CommandText = "SELECT * FROM documentos" & cbper.Text & " WHERE tipodoc ='" & txtDrc.Text & "' and doc='" & txtnumRC.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()
            grilla2.Rows.Clear()
            If t.Rows.Count <> 0 Then
                grilla2.RowCount = t.Rows.Count + 1
                For i = 0 To t.Rows.Count - 1
                    grilla2.Item("cta2", i).Value = t.Rows(i).Item("codigo")
                    grilla2.Item("deta2", i).Value = t.Rows(i).Item("descri")
                    grilla2.Item("db2", i).Value = t.Rows(i).Item("debito")
                    grilla2.Item("cd2", i).Value = t.Rows(i).Item("credito")
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        MiConexion(bda)
        VerdPdf()
        Cerrar()
    End Sub
    Private Sub VerdPdf()

        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        '...
        Dim pcta1 As String = ""
        Dim pdeta1 As String = ""
        Dim pdb1 As String = ""
        Dim pcd1 As String = ""
        '...
        Dim pcta2 As String = ""
        Dim pdeta2 As String = ""
        Dim pdb2 As String = ""
        Dim pcd2 As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        ':::::::::::::::::::::::::::::::::::::::::::::

        If grilla1.Rows.Count > 0 Then
            For i = 0 To grilla1.Rows.Count - 1
                If grilla1.Item("cta1", i).Value <> "" Then
                    pcta1 = pcta1 & grilla1.Item("cta1", i).Value & vbCrLf
                    pdeta1 = pdeta1 & grilla1.Item("deta1", i).Value & vbCrLf
                    pdb1 = pdb1 & Moneda(grilla1.Item("db1", i).Value) & vbCrLf
                    pcd1 = pcd1 & Moneda(grilla1.Item("cd1", i).Value) & vbCrLf
                End If
            Next
        End If

        If grilla2.Rows.Count > 0 Then
            For i = 0 To grilla2.Rows.Count - 1
                If grilla2.Item("cta2", i).Value <> "" Then
                    pcta2 = pcta2 & grilla2.Item("cta2", i).Value & vbCrLf
                    pdeta2 = pdeta2 & grilla2.Item("deta2", i).Value & vbCrLf
                    pdb2 = pdb2 & Moneda(grilla2.Item("db2", i).Value) & vbCrLf
                    pcd2 = pcd2 & Moneda(grilla2.Item("cd2", i).Value) & vbCrLf
                End If
            Next
        End If


        sql = "SELECT concepto AS descrip, nitc AS nitc, nombre AS nomnit, valor AS total, CAST(LPAD(num,5,0) AS CHAR(6)) AS ctaretiva," _
        & " CONCAT(rb_cod2,' - ', rb) AS concepto, CAST(CONCAT(doc_ci,LPAD(num_ci,5,0)) as char(10)) AS ctaiva,  cast(CONCAT(doc_rc,LPAD(num_rc,5,0))as char(10)) AS ctatotal," _
        & " CAST( CONCAT( RIGHT( fecha, 2 ) ,  '/', MID( fecha, 6, 2 ) ,  '/', LEFT(fecha, 4 ) ) AS CHAR(15))  AS ctaret " _
        & "  FROM otdoc_pres WHERE num='" & txtnum.Text & "'"

        Dim tabl As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLegal
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportCIorden.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            ''..
            Dim Prcta1 As New ParameterField
            Dim Prdeta1 As New ParameterField
            Dim Prdb1 As New ParameterField
            Dim Prcd1 As New ParameterField

            Dim Prcta2 As New ParameterField
            Dim Prdeta2 As New ParameterField
            Dim Prdb2 As New ParameterField
            Dim Prcd2 As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "comp"
            PrNit.CurrentValues.AddValue(nom)
            Prcomp.Name = "nit"
            Prcomp.CurrentValues.AddValue(nit.ToString)
            ''...
            Prcta1.Name = "cta1"
            Prcta1.CurrentValues.AddValue(pcta1)
            Prdeta1.Name = "deta1"
            Prdeta1.CurrentValues.AddValue(pdeta1)
            Prdb1.Name = "db1"
            Prdb1.CurrentValues.AddValue(pdb1)
            Prcd1.Name = "cd1"
            Prcd1.CurrentValues.AddValue(pcd1)
            ''...
            Prcta2.Name = "cta2"
            Prcta2.CurrentValues.AddValue(pcta2)
            Prdeta2.Name = "deta2"
            Prdeta2.CurrentValues.AddValue(pdeta2)
            Prdb2.Name = "db2"
            Prdb2.CurrentValues.AddValue(pdb2)
            Prcd2.Name = "cd2"
            Prcd2.CurrentValues.AddValue(pcd2)


            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prcta1)
            prmdatos.Add(Prdeta1)
            prmdatos.Add(Prdb1)
            prmdatos.Add(Prcd1)
            prmdatos.Add(Prcta2)
            prmdatos.Add(Prdeta2)
            prmdatos.Add(Prdb2)
            prmdatos.Add(Prcd2)
           

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If txtnum.Text = "" Then
            MsgBox("Verifique el documento a editar", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        lbestado.Text = "EDITAR"
        Desdloquear()
        cbper.Enabled = False

    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Se eliminara el documento, ¿Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            EliminarDatos()
            Limpiar()
            lbestado.Text = "ELIMINADO"
            MsgBox("Documento Eliminado", MsgBoxStyle.Information, "Verificacion")
            Cerrar()
        End If
    End Sub

    Private Sub i1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i1.CheckedChanged
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If i1.Checked = True Then
                g1.Enabled = True
                g2.Enabled = True
                g3.Enabled = True
            Else
                'g2.Enabled = False
                g3.Enabled = False
            End If
        Else
            g1.Enabled = True
            g2.Enabled = True
            g3.Enabled = True
        End If
       
    End Sub
End Class