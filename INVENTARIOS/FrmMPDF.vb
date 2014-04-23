Public Class FrmMPDF

    Private Sub pdf_OnError(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf.OnError

    End Sub

    Private Sub FrmMPDF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Try
            If (ruta IsNot Nothing) Then
                pdf.LoadFile(ruta)
            End If
        Catch ex As Exception
            AbrirArchivo(ruta)
        End Try
    End Sub

    Private Sub FrmMPDF_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Dim tama As Integer = 0
        pdf.Size = Me.Size
    End Sub
End Class