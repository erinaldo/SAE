Public Class FrmParametrosOtrosDoc

    Private Sub FrmParametrosOtrosDoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txt_ce.Text = ""
        txt_nce.Text = ""
        txt_ci.Text = ""
        txt_nci.Text = ""
        txt_rc.Text = ""
        txt_nrc.Text = ""
        txt_nd.Text = ""
        txt_nnd.Text = ""
        txt_nc.Text = ""
        txt_nnc.Text = ""
        txt_cd.Text = ""
        txt_ncd.Text = ""
        txt_aj.Text = ""
        txt_naj.Text = ""
    End Sub
    Private Sub FrmParametrosOtrosDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parotdoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count < 1 Then
            txt_ce.Text = ""
            txt_nce.Text = ""
            txt_ci.Text = ""
            txt_nci.Text = ""
            txt_rc.Text = ""
            txt_nrc.Text = ""
            txt_nd.Text = ""
            txt_nnd.Text = ""
            txt_nc.Text = ""
            txt_nnc.Text = ""
            txt_cd.Text = ""
            txt_ncd.Text = ""
            txt_aj.Text = ""
            txt_naj.Text = ""
            clogo.Checked = False
        Else
            txt_ce.Text = tabla.Rows(0).Item("ce")
            txt_nce.Text = documento(txt_ce.Text)
            txt_ci.Text = tabla.Rows(0).Item("ci")
            txt_nci.Text = documento(txt_ci.Text)
            txt_rc.Text = tabla.Rows(0).Item("rc")
            txt_nrc.Text = documento(txt_rc.Text)
            txt_nd.Text = tabla.Rows(0).Item("nd")
            txt_nnd.Text = documento(txt_nd.Text)
            txt_nc.Text = tabla.Rows(0).Item("nc")
            txt_nnc.Text = documento(txt_nc.Text)
            txt_cd.Text = tabla.Rows(0).Item("cd")
            txt_ncd.Text = documento(txt_cd.Text)
            txt_aj.Text = tabla.Rows(0).Item("aj")
            txt_naj.Text = documento(txt_aj.Text)
            If tabla.Rows(0).Item("logo") = "SI" Then
                clogo.Checked = True
            Else
                clogo.Checked = False
            End If
        End If
    End Sub
    Public Function documento(ByVal tipo As String)
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows.Count < 1 Then
                Return ""
            Else
                Return t.Rows(0).Item("descripcion").ToString
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        If ValidarGuardar() = True Then
            GuardarPara()
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '************** COMPROBANTE DE EGRESOS **************************
    Private Sub txt_ce_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ce.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_ce.Text, "ce")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_ce_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ce.LostFocus
        BuscarMiDoc(txt_ce.Text, "ce")
    End Sub
    '************** COMPROBANTE DE INGRESOS **************************
    Private Sub txt_ci_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ci.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_ci.Text, "ci")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_ci_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ci.LostFocus
        BuscarMiDoc(txt_ci.Text, "ci")
    End Sub
    '************** RECIBO DE CAJA **************************
    Private Sub txt_rc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_rc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_rc.Text, "rc")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_rc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rc.LostFocus
        BuscarMiDoc(txt_rc.Text, "rc")
    End Sub
    '************** NOTA DEBITO **************************
    Private Sub txt_nd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nd.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_nd.Text, "nd")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_nd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nd.LostFocus
        BuscarMiDoc(txt_nd.Text, "nd")
    End Sub
    '************** NOTA CREDITO **************************
    Private Sub txt_nc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_nc.Text, "nc")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_nc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nc.LostFocus
        BuscarMiDoc(txt_nc.Text, "nc")
    End Sub
    '************** COMPROBANTE DE DIARIO **************************
    Private Sub txt_cd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cd.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_cd.Text, "cd")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_cd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd.LostFocus
        BuscarMiDoc(txt_cd.Text, "cd")
    End Sub
    '**************  AJUSTES  **************************
    Private Sub txt_aj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_aj.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarMiDoc(txt_aj.Text, "aj")
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt_aj_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aj.LostFocus
        BuscarMiDoc(txt_aj.Text, "aj")
    End Sub
    '***********************************************************
    Public Sub BuscarMiDoc(ByVal tipo As String, ByVal txt As String)
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows.Count < 1 Then
                If Trim(tipo) <> "" Then MsgBox("El documento no existe en los registros, verifique.  ", MsgBoxStyle.Information, "SAE Control")
                Select Case txt
                    Case "ce"
                        txt_ce.Text = ""
                        txt_nce.Text = ""
                    Case "ci"
                        txt_ci.Text = ""
                        txt_nci.Text = ""
                    Case "rc"
                        txt_rc.Text = ""
                        txt_nrc.Text = ""
                    Case "nd"
                        txt_nd.Text = ""
                        txt_nnd.Text = ""
                    Case "nc"
                        txt_nc.Text = ""
                        txt_nnc.Text = ""
                    Case "cd"
                        txt_cd.Text = ""
                        txt_ncd.Text = ""
                    Case "aj"
                        txt_aj.Text = ""
                        txt_naj.Text = ""
                    Case "ci_ord"
                        FrmPOrdOt.ci.Text = ""
                        FrmPOrdOt.txt_nrc.Text = ""
                    Case "rc_ord"
                        FrmPOrdOt.rc.Text = ""
                        FrmPOrdOt.txt_nrc.Text = ""
                End Select
                Try
                    FrmTipoTransaccion.lbform.Text = "odoc_" & txt
                    FrmTipoTransaccion.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                Select Case txt
                    Case "ce"
                        txt_nce.Text = t.Rows(0).Item("descripcion")
                    Case "ci"
                        txt_nci.Text = t.Rows(0).Item("descripcion")
                    Case "rc"
                        txt_nrc.Text = t.Rows(0).Item("descripcion")
                    Case "nd"
                        txt_nnd.Text = t.Rows(0).Item("descripcion")
                    Case "nc"
                        txt_nnc.Text = t.Rows(0).Item("descripcion")
                    Case "cd"
                        txt_ncd.Text = t.Rows(0).Item("descripcion")
                    Case "aj"
                        txt_naj.Text = t.Rows(0).Item("descripcion")
                    Case "ci_ord"
                        FrmPOrdOt.txt_nci.Text = t.Rows(0).Item("descripcion")
                    Case "rc_ord"
                        FrmPOrdOt.txt_nrc.Text = t.Rows(0).Item("descripcion")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    '***************************************************
    Function ValidarGuardar()
        If Trim(txt_nce.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_ce.Focus()
            Return False
        ElseIf Trim(txt_nci.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_ci.Focus()
            Return False
        ElseIf Trim(txt_nrc.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_rc.Focus()
            Return False
        ElseIf Trim(txt_nnd.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_nd.Focus()
            Return False
        ElseIf Trim(txt_nnc.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_nc.Focus()
            Return False
        ElseIf Trim(txt_ncd.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_cd.Focus()
            Return False
        ElseIf Trim(txt_naj.Text) = "" Then
            MsgBox("Favor verifique los documentos.   ", MsgBoxStyle.Information, "SAE Control")
            txt_aj.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub GuardarPara()
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?ce", txt_ce.Text)
            myCommand.Parameters.AddWithValue("?ci", txt_ci.Text)
            myCommand.Parameters.AddWithValue("?rc", txt_rc.Text)
            myCommand.Parameters.AddWithValue("?nd", txt_nd.Text)
            myCommand.Parameters.AddWithValue("?nc", txt_nc.Text)
            myCommand.Parameters.AddWithValue("?cd", txt_cd.Text)
            myCommand.Parameters.AddWithValue("?aj", txt_aj.Text)
            If clogo.Checked = False Then
                myCommand.Parameters.AddWithValue("?logo", "NO")
            Else
                myCommand.Parameters.AddWithValue("?logo", "SI")
            End If
            myCommand.CommandText = "TRUNCATE parotdoc; INSERT INTO parotdoc VALUES (?ce,?ci,?rc,?nd,?nc,?cd,?aj,?logo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            MsgBox("Los parametros fueron guardados correctamente.   ", MsgBoxStyle.Information, "SAE Guardar Parametros")
            Me.Close()
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
End Class