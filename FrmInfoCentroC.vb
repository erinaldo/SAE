Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmInfoCentroC
    Dim cb As PdfContentByte
    Dim k, pag, tope As Integer
    Dim MiPer, Cond As String
    Dim FechaRep As String
    Private Sub FrmInfoCentroC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cborden.Text = "Codigo"
    End Sub
    Private Sub rb_cc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cc1.CheckedChanged
        txtcci.Enabled = False
        txtccf.Enabled = False
    End Sub
    Private Sub rb_cc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cc2.CheckedChanged
        txtcci.Enabled = True
        txtccf.Enabled = True
    End Sub
    '*******************************************************
    Private Sub txtcci_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcci.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtcci, e)
        End If
    End Sub
    Private Sub txtcci_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcci.LostFocus
        BuscarCC("cc1")
    End Sub
    Private Sub txtccf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtccf.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtccf, e)
        End If
    End Sub
    Private Sub txtccf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtccf.LostFocus
        BuscarCC("cc2")
    End Sub
    Public Sub BuscarCC(ByVal txt As String)
        Try
            Dim tabla As New DataTable
            If txt = "cc1" Then
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcci.Text & "';"
            Else
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtccf.Text & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If txt = "cc1" Then
                txtncci.Text = ""
            Else
                txtnccf.Text = ""
            End If
            If tabla.Rows.Count > 0 Then
                If txt = "cc1" Then
                    txtncci.Text = tabla.Rows(0).Item("nombre")
                Else
                    txtnccf.Text = tabla.Rows(0).Item("nombre")
                End If
            Else
                If txt = "cc1" Then
                    FrmSelCentroCostos.txtcuenta.Text = txtcci.Text
                    FrmSelCentroCostos.lbform.Text = "inf_cc_i"
                Else
                    FrmSelCentroCostos.txtcuenta.Text = txtccf.Text
                    FrmSelCentroCostos.lbform.Text = "inf_cc_f"
                End If
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '*******************************************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim orden As String
        If cborden.Text = "Codigo" Then
            orden = " ORDER BY centro;"
        Else
            orden = " ORDER BY nombre;"
        End If
        If rb_cc1.Checked = True Then
            GenerarPDF(orden)
        Else
            If Trim(txtncci.Text) = "" Then
                MsgBox("Digite los centros de costo.  ", MsgBoxStyle.Information, "SAE Control")
                txtcci.Focus()
            ElseIf Trim(txtnccf.Text) = "" Then
                MsgBox("Digite los centros de costo.  ", MsgBoxStyle.Information, "SAE Control")
                txtccf.Focus()
            ElseIf (txtcci.Text > txtccf.Text) Then
                MsgBox("Verifique el rango de los centros de costo.  ", MsgBoxStyle.Information, "SAE Control")
                txtcci.Focus()
            Else
                GenerarPDF(" WHERE centro>='" & txtcci.Text & "' AND centro<='" & txtccf.Text & "'" & orden)
            End If
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '*********************************************************
    Public Sub GenerarPDF(ByVal condicion As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        pag = 1
        tope = 70
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '**************************************************
            Dim tcc As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos " & condicion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcc)
            For i = 0 To tcc.Rows.Count - 1
                k = k - 10
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tcc.Rows(i).Item("centro"), 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tcc.Rows(i).Item("nombre"), 110, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, CalcularP(tcc.Rows(i).Item("centro").ToString, tcc.Rows(i).Item("nivel")), 575, k, 0)
            Next
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                ' MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("ERROR al momento de generar el reporte, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Function CalcularP(ByVal cc As String, ByVal niv As String)
        Dim p As String = "0,00"
        Try
            Dim tcc As New DataTable
            myCommand.Parameters.Clear()
            If niv <> "centro" Then
                myCommand.CommandText = "SELECT SUM(pres) FROM centrocostos WHERE centro LIKE '" & cc & "%' "
            Else
                myCommand.CommandText = "SELECT SUM(pres) FROM centrocostos WHERE centro = '" & cc & "' "
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcc)
            p = Moneda(tcc.Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return p
    End Function
    Public Sub Banner()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        If rb_cc1.Checked = True Then
            cb.ShowTextAligned(50, "REPORTE GENERADO PARA TODOS LOS CENTROS DE COSTO ", 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "REPORTE GENERADO POR RANGO DE CENTROS DE COSTO: [ " & txtcci.Text & " - " & txtccf.Text & " ]", 20, 780, 0)
        End If
        k = 770
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "COD. CENTRO", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NOMBRE CENTRO DE COSTO", 110, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PRESUPUESTO", 575, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
End Class