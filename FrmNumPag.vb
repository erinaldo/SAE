Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class FrmNumPag

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If txtcod.Text = "" Then
            MsgBox("Favor digite el código alfabético del informe.  ", MsgBoxStyle.Information, "SAE Control")
            txtcod.Focus()
            Exit Sub
        ElseIf txtini.Value > txtfin.Value Or txtini.Value = 0 Then
            MsgBox("Favor Verifique el número de las páginas.  ", MsgBoxStyle.Information, "SAE Control")
            txtini.Focus()
            Exit Sub
        End If
        Dim cb As PdfContentByte
        Dim pag As Integer
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            Dim tablacomp As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            For i = txtini.Value To txtfin.Value
                pag = i
                oDoc.NewPage()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                cb.ShowTextAligned(50, txtcod.Text & "   " & pag, 475, 810, 0)
                If rbs.Checked = True Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tablacomp.Rows(0).Item("descripcion") & "    NIT. " & tablacomp.Rows(0).Item("nit"), 575, 795, 0)
                cb.EndText()
            Next
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                ' MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("ERROR al momento de generar números de páginas para el libro oficial, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
      
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtcod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtini.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtfin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfin.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub rbs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbs.CheckedChanged
        cmdpantalla.Focus()
    End Sub
    Private Sub rbn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn.CheckedChanged
        cmdpantalla.Focus()
    End Sub
End Class