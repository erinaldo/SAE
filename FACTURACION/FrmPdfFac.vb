Public Class FrmPdfFac

    Private Sub FrmPdfFac_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Me.Close()
    End Sub

    Private Sub FrmPdfFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Try
            If (ruta IsNot Nothing) Then
                pdf.LoadFile(ruta)
            End If
        Catch ex As Exception
            AbrirArchivo(ruta)
        End Try
    End Sub

    Private Sub FrmPdfFac_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        pdf.Size = Me.Size
    End Sub
End Class