Public Class FrmPOrdOt

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmPOrdOt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parrecaudo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            ci.Text = tabla.Rows(0).Item("ci")
            rc.Text = tabla.Rows(0).Item("rc")
            txt_nci.Text = FrmParametrosOtrosDoc.documento(ci.Text)
            txt_nrc.Text = FrmParametrosOtrosDoc.documento(rc.Text)
        End If
    End Sub

    'Private Sub ci_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ci.KeyPress
    '    If e.KeyChar = Chr(Keys.Enter) Then
    '        FrmParametrosOtrosDoc.BuscarMiDoc(ci.Text, "ci_ord")
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    'Private Sub rc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rc.KeyPress
    '    If e.KeyChar = Chr(Keys.Enter) Then
    '        FrmParametrosOtrosDoc.BuscarMiDoc(rc.Text, "rc_ord")
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub ci_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ci.LostFocus
        FrmParametrosOtrosDoc.BuscarMiDoc(ci.Text, "ci_ord")
    End Sub

    Private Sub rc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rc.LostFocus
        FrmParametrosOtrosDoc.BuscarMiDoc(rc.Text, "rc_ord")
    End Sub

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        Try
            guardar()
        Catch ex As Exception
            MsgBox("error al guardar")
        End Try

    End Sub
    Private Sub guardar()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?ci", ci.Text)
        myCommand.Parameters.AddWithValue("?rc", rc.Text)

        myCommand.CommandText = "TRUNCATE parrecaudo; INSERT INTO parrecaudo VALUES (?ci,?rc);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        MsgBox("Los parametros fueron guardados correctamente.   ", MsgBoxStyle.Information, "SAE Guardar Parametros")
        Me.Close()
        Cerrar()
    End Sub
End Class