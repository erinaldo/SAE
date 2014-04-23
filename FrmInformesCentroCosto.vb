Public Class FrmInformesCentroCosto

    Private Sub cmdegresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdegresos.Click
        FrmInfoCentroC.ShowDialog()
    End Sub

    Private Sub cmdingresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdingresos.Click
        FrmBalanceG_cc.ShowDialog()
    End Sub

    Private Sub cmdcaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcaja.Click
        FrmEstadoR_cc.rb_per2.Checked = True
        FrmEstadoR_cc.rb_per1.Checked = True
        FrmEstadoR_cc.ShowDialog()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Try
            FrmInfMovCentroC.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class