Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object

Public Class FrmTarConteoFisico

    Private Sub FrmTarConteoFisico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ninguna Bodega, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
            Exit Sub
        End If
        cbbodega.Items.Clear()
        For i = 0 To items - 1
            cbbodega.Items.Add(tabla.Rows(i).Item("numbod"))
        Next
        cbbodega.SelectedIndex = 0
    End Sub

    Private Sub cbbodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbodega.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & cbbodega.Text & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtnombre.Text = tabla.Rows(0).Item("nombod")
        Else
            txtnombre.Text = ""
        End If
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        txtini.Enabled = False
        txtfin.Enabled = False
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        txtini.Enabled = True
        txtfin.Enabled = True
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'If txtini.Text > txtfin.Text And c2.Checked = True Then
        '    MsgBox("Verifique los rangos de los codigos.", MsgBoxStyle.Information, "Control")
        '    Exit Sub
        'End If
        'GenerarPDF()


        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim p As String = ""
        Dim b As String = ""


        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        b = cbbodega.Text
        p = PerActual(0) & PerActual(1)

        If c1.Checked = True Then

            sql = " SELECT a.codart, a.nomart, NULL AS desart, a.nivel, NULL AS cant_min,   NULL AS codbar FROM articulos a  where a.nivel <> 'Articulo'  " _
          & " union " _
          & " SELECT a.codart, a.nomart, a.desart, a.nivel, c.cant" & b & " AS cant_min,   IF( a.nivel =  'Articulo',  '__________', '' ) AS codbar FROM articulos a , con_inv c where a.codart = c.codart  AND c.periodo =  '" & p & "'  " _
          & " ORDER BY codart "

           
        End If

        If c2.Checked = True Then

            sql = " SELECT a.codart, a.nomart,  NULL AS desart, a.nivel, NULL AS cant_min,   NULL AS codbar FROM articulos a  where a.nivel <> 'Articulo' AND (a.codart) BETWEEN '" & txtini.Text & "' AND '" & txtfin.Text & "' " _
          & " union " _
          & " SELECT a.codart, a.nomart, a.desart, a.nivel, c.cant" & b & " AS cant_min,   IF( a.nivel =  'Articulo',  '__________', '' ) AS codbar FROM articulos a , con_inv c where a.codart = c.codart AND (a.codart) BETWEEN '" & txtini.Text & "' AND '" & txtfin.Text & "'  AND c.periodo =  '" & p & "'  " _
          & " ORDER BY codart "

        End If


        TextBox1.Text = sql

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContFis.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmRepCont.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prbodega As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(PerActual.ToString)

            Prbodega.Name = "No"
            Prbodega.CurrentValues.AddValue(b.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prbodega)

            FrmRepCont.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepCont.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    '************************************************************************************
    Private Sub txtini_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtini.DoubleClick
        FrmArti_de_Inventarios.lbform.Text = "tar_conteo_ini"
        FrmArti_de_Inventarios.ShowDialog()
    End Sub
    Private Sub txtfin_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfin.DoubleClick
        FrmArti_de_Inventarios.lbform.Text = "tar_conteo_fin"
        FrmArti_de_Inventarios.ShowDialog()
    End Sub

    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            '**************************************
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
            '*********************************************
            Dim tabla As New DataTable
            If c1.Checked = True = True Then
                myCommand.CommandText = "SELECT * FROM articulos ORDER BY codart;"
            Else
                myCommand.CommandText = "SELECT * FROM articulos WHERE codart>='" & txtini.Text & "' AND codart<='" & txtfin.Text & "' ORDER BY codart;"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k < 60 Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    'cb.AddImage(img) 'IMAGEN
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
                If tabla.Rows(i).Item("nivel") <> "Articulo" Then
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codart") & " " & tabla.Rows(i).Item("nomart"), 20, k, 0)
                    k = k - 5
                Else
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codart"), 20, k, 0)
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 70, k, 0)
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("desart"), 45), 220, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Cantidad_en_bodega(tabla.Rows(i).Item("codart").ToString), 485, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "______________", 585, k, 0)
                End If
            Next
            '********************************************************************
            k = k - 20
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
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 800, 0)
        cb.ShowTextAligned(50, "BODEGA: " & cbbodega.Text & " " & txtnombre.Text, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 770, 0)
        '**************************
        k = 755
        cb.ShowTextAligned(50, "CODIGO", 20, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 70, k, 0)
        cb.ShowTextAligned(50, "DETALLES", 220, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CONTEO FISICO", 585, k, 0)
        k = k - 5
    End Sub
    Function Cantidad_en_bodega(ByVal codart As String)
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT cant" & cbbodega.Text & " FROM con_inv WHERE codart LIKE'" & codart & "%' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Return t.Rows(0).Item(0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub
End Class