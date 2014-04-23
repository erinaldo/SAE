Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class FrmInfoGastos
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        GenerarPdf()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Public Sub GenerarPdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim k, pag As Integer
        Dim tabla, tcomp As New DataTable
        Dim fecha As String = Now.ToString
        pag = 0
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
          FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Refresh()
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcomp)
            k = 30
            If rbcod.Checked = True Then
                myCommand.CommandText = "SELECT * FROM gastos ORDER BY cod_gas;"
            Else
                myCommand.CommandText = "SELECT * FROM gastos ORDER BY nom_gas;"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k < 40 Then
                    '*********INICIO BANNER****************
                    pag = pag + 1
                    cb.EndText()
                    If i > 0 Then oDoc.NewPage()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    cb.BeginText()
                    cb.ShowTextAligned(50, tcomp.Rows(0).Item("descripcion"), 20, 810, 0)
                    cb.ShowTextAligned(50, "N.I.T. " & tcomp.Rows(0).Item("nit"), 20, 800, 0)
                    cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                    cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                    cb.ShowTextAligned(50, "FECHA IMPRESO: " & fecha, 20, 770, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE GRUPOS DE COMPRAS / GASTOS", 300, 760, 0)
                    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                    k = 740
                    cb.ShowTextAligned(50, "CODIGO", 10, k, 0)
                    cb.ShowTextAligned(50, "NOMBRE / DESCRIPCIÓN", 80, k, 0)
                    cb.ShowTextAligned(50, "IVA %", 420, k, 0)
                    cb.ShowTextAligned(50, "CTA IVA", 465, k, 0)
                    cb.ShowTextAligned(50, "CTA GASTOS", 525, k, 0)
                    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
                    k = 720
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    cb.BeginText()
                    k = k - 10
                    '*********FIN BANNER****************
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cod_gas"), 10, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nom_gas"), 80), 80, k, 0)
                cb.ShowTextAligned(50, Moneda(tabla.Rows(i).Item("por_iva")), 420, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cta_iva"), 465, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cta_gas"), 525, k, 0)
            Next
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
End Class