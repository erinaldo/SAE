Public Class FrmReportContBalPruT

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        CrystalReportViewer1.Zoom(150)
    End Sub

    Private Sub FrmReportContBalPruT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer1.ShowPrintButton = True
    End Sub
End Class