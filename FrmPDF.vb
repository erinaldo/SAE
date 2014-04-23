Public Class FrmPDF

    Private Sub FrmPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '*************
        pdf.Size = Me.Size
        '****************
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\documento.pdf"
        Try
            If (ruta IsNot Nothing) Then
                pdf.LoadFile(ruta)
            End If
        Catch ex As Exception
            ' MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
            AbrirArchivo(ruta)
        End Try
    End Sub
    Private Sub FrmPDF_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        pdf.Size = Me.Size
    End Sub
End Class
