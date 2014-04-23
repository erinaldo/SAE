Public Class FrmMediosMagneticos

    Private Sub cmdPCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPCar.Click
        FrmValorMin.ShowDialog()
    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        Frmctaconceptos.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmGenerarFmtos.ShowDialog()
    End Sub
End Class