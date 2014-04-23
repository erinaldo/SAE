Public Class FrmRepKarCod

    Private Sub FrmRepKarCod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer1.ShowPrintButton = True
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        CrystalReportViewer1.Zoom(125)
    End Sub
End Class