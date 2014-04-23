Public Class FrmReportCertR

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        CrystalReportViewer1.Zoom(120)
    End Sub

    Private Sub FrmReportCertR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer1.DisplayGroupTree() = False
        CrystalReportViewer1.ShowPrintButton = True
    End Sub
End Class