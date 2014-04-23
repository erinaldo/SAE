Public Class FrmPass
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub FrmPass_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtpasswC.Text = ""
        txtpasswC.Focus()
    End Sub

    Private Sub CmdOk_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        FrmAbrirCompania.LbPass.Text = txtpasswC.Text
        Me.Close()
    End Sub

    Private Sub txtpasswC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasswC.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            CmdOk_Click_1(AcceptButton, AcceptButton)
        End If
    End Sub
End Class