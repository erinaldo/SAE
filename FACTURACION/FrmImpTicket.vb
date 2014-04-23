Imports System.Drawing.Printing
Public Class FrmImpTicket

    Private Sub PrintText(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        ev.Graphics.DrawString(TextBox1.Text, New Font("Courier New", 8, FontStyle.Regular), Brushes.Black, 2, 2)
        ev.HasMorePages = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim printdoc As New printDocument
        AddHandler printdoc.PrintPage, AddressOf Me.PrintText
        printdoc.Print()
        Me.Close()
    End Sub

    Private Sub FrmImpTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1_Click(AcceptButton, AcceptButton)
    End Sub
End Class