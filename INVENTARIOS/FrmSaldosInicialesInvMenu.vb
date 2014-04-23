Public Class FrmSaldosInicialesInvMenu

    Private Sub cmdsaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldos.Click
        FrmSaldosIniInv.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        FrmDesaInvSI.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        FrmCuentasSalIniinv.ShowDialog()
    End Sub
End Class