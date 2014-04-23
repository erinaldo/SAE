Public Class FrmReportePuc

    Private Sub FrmReportePuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '*************
        Try
            pdf.Size = Me.Size
        Catch ex As Exception
        End Try
        '****************
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Try
            If (ruta IsNot Nothing) Then
                pdf.LoadFile(ruta)
            End If
        Catch ex As Exception
            AbrirArchivo(ruta)
        End Try
    End Sub

    Private Sub FrmReportePuc_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Try
            pdf.Size = Me.Size
        Catch ex As Exception
        End Try

    End Sub
End Class