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

Public Class FrmAnalisisCPP
    Private Sub FrmAnalisisCPP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtfecha.MinDate = CDate("01/01/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        Try
            txtfecha.MaxDate = CDate(31 & "/" & 12 & Strings.Right(PerActual, 5))
        Catch ex As Exception
            If PerActual(0) & PerActual(1) = "02" Then
                txtfecha.MaxDate = CDate("28/" & PerActual)
            Else
                txtfecha.MaxDate = CDate("30/" & PerActual)
            End If
        End Try

    End Sub
    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            txtfecha.Enabled = False
        End If
    End Sub
    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        If rb2.Checked = True Then
            txtfecha.Enabled = True
        End If
    End Sub
    Public tabla5 As DataTable
    Public tabla As DataTable
    Public tabla2 As DataTable
    Public tabla3 As DataTable
    Public tabla4 As DataTable
    Public totalcar, total1, total2, total3, total4, total5 As Double
    Public totalcar_, total1_, total2_, total3_, total4_, total5_ As Double


    'Public Sub etiquetas_intervalos()
    'Dim x As Integer
    '   x = Val(txtdias.Text)

    'End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        '   etiquetas_intervalos()

        'inter1 = Val(txtdias.Text)
        'inter2 = inter1 + Val(txtdias.Text)
        'inter3 = inter2 + Val(txtdias.Text)
        'inter4 = inter3 + Val(txtdias.Text)
        'inter5 = inter4 + Val(txtdias.Text)

        'Dim sql As String = ""
        'total1 = 0
        'total2 = 0
        'total3 = 0
        'total4 = 0
        'total5 = 0
        'totalcar = 0
        'total1_ = 0
        'total2_ = 0
        'total3_ = 0
        'total4_ = 0
        'total5_ = 0
        'totalcar_ = 0
        'Dim f1 As String

        'f1 = (txtfecha.Value.ToString("yyyy-MM-dd"))
        'If Not rb1.Checked = True Then
        '    sql = "SELECT nitc FROM ctas_x_pagar WHERE total>pagado AND fecha<='" & f1 & "' group BY nitc order by nomnit;"
        'Else
        '    sql = "SELECT nitc FROM ctas_x_pagar WHERE total>pagado group BY nitc order by nomnit;"
        'End If
        '' sql = "SELECT nitc FROM cobdpen WHERE total>pagado group by nitc;"
        'GenerarPDF_todos(sql)
        If chAnt.Checked = False Then
            reporte()
        Else
            Try
                Button1_Click(AcceptButton, AcceptButton)
            Catch ex As Exception
                MsgBox("Error al generar el informe, " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If



    End Sub
    Private Sub reporte()

        Dim sql As String = ""

        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim inf As String = ""
        Dim fc As String = ""
        Dim rr As String = ""

        Dim tt As String = ""

        Dim r1 As String = ""
        Dim r11 As String = ""
        Dim Tr1 As String = ""
        Dim r2 As String = ""
        Dim r22 As String = ""
        Dim Tr2 As String = ""
        Dim r3 As String = ""
        Dim r33 As String = ""
        Dim Tr3 As String = ""
        Dim r4 As String = ""
        Dim r44 As String = ""
        Dim Tr4 As String = ""
        Dim r5 As String = ""
        Dim Tr5 As String = ""


        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO ACTUAL: " & PerActual

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        tt = "INFORME PROVEEDORES ANALISIS DE CUENTAS POR PAGAR "

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        r1 = txtdias.Text
        r11 = r1 + 1
        Tr1 = "SALDO 0 - " & r1

        r2 = txtdias.Text * 2
        r22 = r2 + 1
        Tr2 = "SALDO " & r11 & " - " & r2

        r3 = txtdias.Text * 3
        r33 = r3 + 1
        Tr3 = "SALDO " & r22 & " - " & r3

        r4 = txtdias.Text * 4
        r44 = r4 + 1
        Tr4 = "SALDO " & r33 & " - " & r4

        r5 = txtdias.Text * 5
        Tr5 = "SALDO " & r44 & " O MAS"


        fc = Strings.Right(txtfecha.Text, 4) & "-" & Strings.Mid(txtfecha.Text, 4, 2) & "-" & Strings.Left(txtfecha.Text, 2)


        If rb1.Checked = True Then ' ANALISIS AL DIA 

            sql = "SELECT c.nitc, c.nomnit, t.telefono AS ccosto, c.doc, c.doc_ext, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, CAST( (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitcod, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
       & " IF ((SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, (total - pagado) AS total " _
       & " FROM ctas_x_pagar c, terceros t WHERE c.nitc=t.nit AND c.total > c.pagado  "

        End If  ' Fin Analisis dia

        If rb2.Checked = True Then ' Un proveedor 

            sql = "SELECT c.nitc, c.nomnit, t.telefono AS ccosto, c.doc, c.doc_ext, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, CAST( (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitcod, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
       & " IF ((SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, (total - pagado) AS total " _
       & " FROM ctas_x_pagar c, terceros t WHERE c.nitc= t.nit AND c.total > c.pagado  AND c.fecha <= '" & fc & "'"

        End If  ' Fin Un proveedor 


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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportPPlanPago.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportPPlanPago.CrystalReportViewer1.ReportSource = CrReport

        Dim doc_aj As String = ""
        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT doc_aj FROM `par_comp` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtr1 As New ParameterField
            Dim Prtr2 As New ParameterField
            Dim Prtr3 As New ParameterField
            Dim Prtr4 As New ParameterField
            Dim Prtr5 As New ParameterField
            Dim Prtt As New ParameterField
            Dim PrAJ As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtr1.Name = "R1"
            Prtr1.CurrentValues.AddValue(Tr1.ToString)

            Prtr2.Name = "R2"
            Prtr2.CurrentValues.AddValue(Tr2.ToString)

            Prtr3.Name = "R3"
            Prtr3.CurrentValues.AddValue(Tr3.ToString)

            Prtr4.Name = "R4"
            Prtr4.CurrentValues.AddValue(Tr4.ToString)

            Prtr5.Name = "R5"
            Prtr5.CurrentValues.AddValue(Tr5.ToString)

            Prtt.Name = "titulo"
            Prtt.CurrentValues.AddValue(tt.ToString)

            PrAJ.Name = "doc_aj"
            PrAJ.CurrentValues.AddValue(doc_aj.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtr1)
            prmdatos.Add(Prtr2)
            prmdatos.Add(Prtr3)
            prmdatos.Add(Prtr4)
            prmdatos.Add(Prtr5)
            prmdatos.Add(Prtt)
            prmdatos.Add(PrAJ)

            FrmReportPPlanPago.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportPPlanPago.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    '**********************************************
    Public cb As PdfContentByte
    Public k, pag As Integer
    Public MiPer As String
    Public FechaRep As String
    Public oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
    Public pdfw As iTextSharp.text.pdf.PdfWriter
    Public fuente As iTextSharp.text.pdf.BaseFont
    Public NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
    Public nroreg As Integer
    Public inter1, inter2, inter3, inter4, inter5 As Integer

    Public Sub GenerarPDF_todos(ByVal sql As String)
        Try
            MiConexion(bda)
            Cerrar()
            FechaRep = Now.ToString
            pag = 1
            nroreg = 0
            oDoc = New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)

            'Ubicamos Datos de la Compañia
            Dim tablacomp As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 2, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 2, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 2, 790, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 2, 780, 0)
            cb.ShowTextAligned(50, "FECHA INICIAL: " & txtfecha.Text & "  FECHA FINAL: " & Now.ToString, 2, 770, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANALISIS DE  PROVEEDORES POR VENCIMIENTOS", 300, 755, 0)
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 745, 0)
            k = 735
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 556, k, 0)
            k = k - 10
            'cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
            cb.ShowTextAligned(50, "* D O C U M E N T O *", 2, k + 10, 0)
            cb.ShowTextAligned(50, "INTERNO", 2, k, 0)
            cb.ShowTextAligned(50, "EXTERNO", 40, k, 0)
            '********************************************************
            cb.ShowTextAligned(50, "FECHA", 80, k, 0)
            cb.ShowTextAligned(50, "VMTO.", 120, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0-" & Str(inter1), 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter1 + 1) & "-" & Str(inter2), 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter2 + 1) & "-" & Str(inter3), 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter3 + 1) & "-" & Str(inter4), 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter4 + 1) & " O MAS", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 556, k, 0)
            k = k - 5
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)

            '/************* Buscar Los nits Para la Consulta
            Dim tablax As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablax)
            nroreg = tablax.Rows.Count ' Localizo el numero de PErsonas Que estan en cartera.
            '*****************************************************
            total1_ = 0
            total2_ = 0
            total3_ = 0
            total4_ = 0
            total5_ = 0
            totalcar_ = 0
            For i = 0 To nroreg - 1
                ' Comenzamos con los Datos Reuqridos Para Impresion
                total1 = 0
                total2 = 0
                total3 = 0
                total4 = 0
                total5 = 0
                totalcar = 0
                k = k - 10
                imprime_individual_grupo(tablax.Rows(i).Item(0))
                k = k - 10
                estadistica_grupo(tablax.Rows(i).Item(0))
                cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 125, k, 0)
                k = k - 5
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.ShowTextAligned(50, "SUB TOTAL CLIENTE   ", 35, k, 0)

                'k = k - 5
                'k = k - 10
                'Imprime Totales de Por Internalos
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total1), 206, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total2), 276, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total3), 346, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total4), 416, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total5), 486, k, 0)
                totalcar = total1 + total2 + total3 + total4 + total5
                total1_ = total1_ + total1
                total2_ = total2_ + total2
                total3_ = total3_ + total3
                total4_ = total4_ + total4
                total5_ = total5_ + total5
                totalcar_ = totalcar_ + totalcar

                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalcar), 556, k, 0)
                'imprime_cuerpo_facturas(sw)
                k = k - 10
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
            Next
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 125, k, 0)
            k = k - 5
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            cb.ShowTextAligned(50, "TOTAL GENERAL   ", 35, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total1_), 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total2_), 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total3_), 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total4_), 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total5_), 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalcar_), 556, k, 0)

            '**********
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
            'ABRIR FORMULARIO DESEADO
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
        'Cerrar y Abrir nuevamente la conexion normal
        MiConexion(bda)
        Cerrar()
    End Sub


    Public Sub imprime_cuerpo_facturas(ByVal vencimiento As Integer)

        If k <= 60 Then Banner()
        Dim x As Integer
        Try
            x = tabla.Rows.Count
            If vencimiento = 1 Then
                For i = 0 To x - 1
                    txtfechavmto.Value = tabla.Rows(i).Item(4)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item(2)), 206, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item(6), 2, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item(7), 40, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item(4), 80, k, 0)
                    cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla.Rows(i).Item(5))), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item(2)), 556, k, 0)
                    k = k - 10
                    If k <= 60 Then Banner()
                    total1 = total1 + (Val(tabla.Rows(i).Item(2)) - Val(tabla.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        Try
            x = tabla2.Rows.Count
            If vencimiento = 2 Then
                For i = 0 To x - 1
                    txtfechavmto.Value = tabla2.Rows(i).Item(4)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla2.Rows(i).Item(2)), 276, k, 0)
                    cb.ShowTextAligned(50, tabla2.Rows(i).Item(6), 2, k, 0)
                    cb.ShowTextAligned(50, tabla2.Rows(i).Item(7), 40, k, 0)
                    cb.ShowTextAligned(50, tabla2.Rows(i).Item(4), 80, k, 0)
                    cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla2.Rows(i).Item(5))), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla2.Rows(i).Item(2)), 556, k, 0)
                    k = k - 10
                    If k <= 60 Then Banner()
                    total2 = total2 + (Val(tabla2.Rows(i).Item(2)) - Val(tabla2.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            x = tabla3.Rows.Count
            If vencimiento = 3 Then
                For i = 0 To x - 1
                    txtfechavmto.Value = tabla3.Rows(i).Item(4)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla3.Rows(i).Item(2)), 346, k, 0)
                    cb.ShowTextAligned(50, tabla3.Rows(i).Item(6), 2, k, 0)
                    cb.ShowTextAligned(50, tabla3.Rows(i).Item(7), 40, k, 0)
                    cb.ShowTextAligned(50, tabla3.Rows(i).Item(4), 80, k, 0)
                    cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla3.Rows(i).Item(5))), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla3.Rows(i).Item(2)), 556, k, 0)
                    k = k - 10
                    If k <= 60 Then Banner()
                    total3 = total3 + (Val(tabla3.Rows(i).Item(2)) - Val(tabla3.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try
        Try
            x = tabla4.Rows.Count
            If vencimiento = 4 Then
                For i = 0 To x - 1
                    txtfechavmto.Value = tabla4.Rows(i).Item(4)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla4.Rows(i).Item(2)), 416, k, 0)
                    cb.ShowTextAligned(50, tabla4.Rows(i).Item(6), 2, k, 0)
                    cb.ShowTextAligned(50, tabla4.Rows(i).Item(7), 40, k, 0)
                    cb.ShowTextAligned(50, tabla4.Rows(i).Item(4), 80, k, 0)
                    cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla4.Rows(i).Item(5))), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla4.Rows(i).Item(2)), 556, k, 0)
                    k = k - 10
                    If k <= 60 Then Banner()
                    total4 = total4 + (Val(tabla4.Rows(i).Item(2)) - Val(tabla4.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try

        Try
            x = 0
            x = tabla5.Rows.Count
            If vencimiento = 5 Then
                For i = 0 To x - 1
                    txtfechavmto.Value = tabla5.Rows(i).Item(4)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla5.Rows(i).Item(2)), 486, k, 0)
                    cb.ShowTextAligned(50, tabla5.Rows(i).Item(6), 2, k, 0)
                    cb.ShowTextAligned(50, tabla5.Rows(i).Item(7), 40, k, 0)
                    cb.ShowTextAligned(50, tabla5.Rows(i).Item(4), 80, k, 0)
                    cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla5.Rows(i).Item(5))), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla5.Rows(i).Item(2)), 556, k, 0)
                    k = k - 10
                    If k <= 60 Then Banner()
                    total5 = total5 + (Val(tabla5.Rows(i).Item(2)) - Val(tabla5.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Banner()
        Dim tablacomp, tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        pag = pag + 1
        cb.EndText()
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 2, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 2, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 2, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 2, 780, 0)
        cb.ShowTextAligned(50, "FECHA INICIAL: " & txtfecha.Text & "  FECHA FINAL: " & Now.ToString, 2, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANALISIS DE CARTERA PROVEEDORES POR VENCIMIENTOS", 300, 755, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
        k = 735
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 206, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 276, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 340, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 416, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 486, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 556, k, 0)
        k = k - 10
        'cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
        cb.ShowTextAligned(50, "* D O C U M E N T O *", 2, k + 10, 0)
        cb.ShowTextAligned(50, "INTERNO", 2, k, 0)
        cb.ShowTextAligned(50, "EXTERNO", 40, k, 0)
        '********************************************************
        cb.ShowTextAligned(50, "FECHA", 80, k, 0)
        cb.ShowTextAligned(50, "VMTO.", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0-" & Str(inter1), 206, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter1 + 1) & "-" & Str(inter2), 276, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter2 + 1) & "-" & Str(inter3), 346, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter3 + 1) & "-" & Str(inter4), 416, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter4 + 1) & " O MAS", 486, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 556, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)

        ' Comenzamos con los Datos Reuqridos Para Impresion
        k = k - 10
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 6)
        imprime_individual()
        k = k - 10
    End Sub
    Public Sub imprime_individual_grupo(ByVal cad As String)
        Try
            Dim items2 As Integer
            Dim nit As String
            Dim tabla11 As New DataTable
            nit = cad
            myCommand.CommandText = "SELECT nit, nombre, apellidos, dir, telefono, mun  FROM terceros  where nit='" + nit + "';"
            'MsgBox(myCommand.CommandText)
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla11)
            Refresh()
            items2 = tabla11.Rows.Count
            ' Imprimo el Estado de cuenta del Cliente...
            Dim nom As String
            nom = tabla11.Rows(0).Item("nombre") + " " + tabla11.Rows(0).Item("apellidos")
            cb.ShowTextAligned(50, "PROVEEDOR:", 2, k, 0)
            cb.ShowTextAligned(50, nom, 60, k, 0)
            cb.ShowTextAligned(50, "NIT:", 310, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("nit"), 332, k, 0)
            cb.ShowTextAligned(50, "TELEFONOS:", 380, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("telefono"), 440, k, 0)
            cb.ShowTextAligned(50, "CIUDAD:", 500, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("mun"), 550, k, 0)
            k = k - 5
        Catch ex As Exception
        End Try
    End Sub

    Public Sub imprime_individual()
        Try
            Dim items2 As Integer
            Dim nit As String
            Dim tabla11 As New DataTable
            nit = ""
            'nit = Trim(txtnitc.Text)
            myCommand.CommandText = "SELECT nit, nombre, apellidos, dir, telefono, mun  FROM terceros  where nit='" + nit + "';"
            'MsgBox(myCommand.CommandText)
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla11)
            Refresh()
            items2 = tabla11.Rows.Count
            ' Imprimo el Estado de cuenta del Cliente...
            Dim nom As String
            nom = tabla11.Rows(0).Item("nombre") + " " + tabla11.Rows(0).Item("apellidos")
            cb.ShowTextAligned(50, "PROVEEDOR:", 2, k, 0)
            cb.ShowTextAligned(50, nom, 60, k, 0)
            cb.ShowTextAligned(50, "NIT:", 310, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("nit"), 332, k, 0)
            cb.ShowTextAligned(50, "TELEFONOS:", 380, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("telefono"), 440, k, 0)
            cb.ShowTextAligned(50, "CIUDAD:", 500, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("mun"), 550, k, 0)
            k = k - 5
        Catch ex As Exception
        End Try
    End Sub

    
    Public Sub estadistica_grupo(ByVal nit As String)
        Dim items1 As Integer
        Dim num_reg As Integer

        Dim venc1, venc2, venc3, venc4, venc5 As Integer
        Dim f1 As String
        If Not rb1.Checked Then
            f1 = Format(txtfecha.Value, "yyyy-MM-dd")
        Else
            f1 = Format(Today, "yyyy-MM-dd")
        End If
        Try
            items1 = -1
            '************Vencimientos**************
            venc1 = Val(txtdias.Text)
            venc2 = venc1 + Val(txtdias.Text)
            venc3 = venc2 + Val(txtdias.Text)
            venc4 = venc3 + Val(txtdias.Text)
            venc5 = venc4 + Val(txtdias.Text)
            '********* Totalizar Cartera 
            tabla = New DataTable
            Dim recibe As New Object

            ' Filtro de Fecha si Existe.----
            myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc,doc_ext FROM ctas_x_pagar where total>pagado and DATEDIFF('" & f1 & "',fecha) <='" & venc1 & "' and nitc ='" & nit & "' and fecha <='" & f1 & "' group by doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            'imprime_individual(txtnitc.Text)
            Refresh()

            num_reg = tabla.Rows.Count
            recibe = tabla.Rows(0).Item(0)

            If num_reg = 0 Then
                total1 = 0
            Else
                '  total1 = tabla.Rows(0).Item(0)

                imprime_cuerpo_facturas(1)

            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try

            tabla2 = New DataTable
            myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc,doc_ext FROM ctas_x_pagar where total>pagado and DATEDIFF('" & f1 & "',fecha) >'" & venc1 & "' and DATEDIFF('" & f1 & "',fecha) <='" & venc2 & "' and nitc ='" & nit & "'and fecha <='" & f1 & "' group by doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            'imprime_individual(txtnitc.Text)
            Refresh()

            items1 = tabla2.Rows.Count

            If items1 <= 0 Then
                total2 = 0
            Else
                ' total2 = tabla2.Rows(0).Item(0)

                imprime_cuerpo_facturas(2)

            End If
            '**********************************
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
        '********* Totalizar Cartera 

        Try

            tabla3 = New DataTable
            myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc,doc_ext AS dife FROM ctas_x_pagar where total>pagado and DATEDIFF('" & f1 & "',fecha) >'" & venc2 & "' and DATEDIFF('" & f1 & "',fecha) <='" & venc3 & "' and nitc ='" & nit & "' and fecha <='" & f1 & "' group by doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            'imprime_individual(txtnitc.Text)
            Refresh()
            items1 = tabla3.Rows.Count

            If items1 <= 0 Then
                total3 = 0
            Else
                'total3 = tabla3.Rows(0).Item(0)

                imprime_cuerpo_facturas(3)

            End If
            '**********************************
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        '********* Totalizar Cartera 
        Try
            tabla4 = New DataTable
            myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc,doc_ext AS dife FROM ctas_x_pagar where total>pagado and DATEDIFF('" & f1 & "',fecha)>'" & venc3 & "' and DATEDIFF('" & f1 & "',fecha)  <='" & venc4 & "' and nitc ='" & nit & "' and fecha<='" & f1 & "' group by doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)
            'imprime_individual(txtnitc.Text)
            Refresh()
            items1 = tabla4.Rows.Count

            If items1 <= 0 Then
                total4 = 0
            Else
                'total4 = tabla4.Rows(0).Item(0)
                imprime_cuerpo_facturas(4)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try

        Try
            tabla5 = New DataTable
            myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc,doc_ext,DATEDIFF(now(),fecha) AS dife FROM ctas_x_pagar where total>pagado and DATEDIFF('" & f1 & "',fecha) >'" & venc4 & "' and nitc ='" & nit & "' and fecha <='" & f1 & "' group by doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla5)

            'imprime_individual(txtnitc.Text)
            Refresh()

            items1 = tabla5.Rows.Count

            If items1 <= 0 Then
                total5 = 0
            Else
                'total5 = tabla5.Rows(0).Item(0)

                imprime_cuerpo_facturas(5)

            End If
            '**********************************
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try

        'totalcar = total1 + total2 + total3 + total4 + total5

    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = ""
        Dim sql2 As String = ""

        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim inf As String = ""
        Dim fc As String = ""
        Dim rr As String = ""

        Dim tt As String = ""

        Dim r1 As String = ""
        Dim r11 As String = ""
        Dim Tr1 As String = ""
        Dim r2 As String = ""
        Dim r22 As String = ""
        Dim Tr2 As String = ""
        Dim r3 As String = ""
        Dim r33 As String = ""
        Dim Tr3 As String = ""
        Dim r4 As String = ""
        Dim r44 As String = ""
        Dim Tr4 As String = ""
        Dim r5 As String = ""
        Dim Tr5 As String = ""


        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO ACTUAL: " & PerActual

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        tt = "INFORME PROVEEDORES ANALISIS DE CUENTAS POR PAGAR "

       


        r1 = txtdias.Text
        r11 = r1 + 1
        Tr1 = "SALDO 0 - " & r1

        r2 = txtdias.Text * 2
        r22 = r2 + 1
        Tr2 = "SALDO " & r11 & " - " & r2

        r3 = txtdias.Text * 3
        r33 = r3 + 1
        Tr3 = "SALDO " & r22 & " - " & r3

        r4 = txtdias.Text * 4
        r44 = r4 + 1
        Tr4 = "SALDO " & r33 & " - " & r4

        r5 = txtdias.Text * 5
        Tr5 = "SALDO " & r44 & " O MAS"


        fc = Strings.Right(txtfecha.Text, 4) & "-" & Strings.Mid(txtfecha.Text, 4, 2) & "-" & Strings.Left(txtfecha.Text, 2)


        If rb1.Checked = True Then ' ANALISIS AL DIA 

            sql = "SELECT c.nitc, c.nomnit, t.telefono AS ccosto, c.doc, c.doc_ext, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, CAST( (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitcod, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
       & " IF ((SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, (total - pagado) AS total " _
       & " FROM ctas_x_pagar c, terceros t WHERE c.nitc=t.nit AND c.total > c.pagado  "

        End If  ' Fin Analisis dia

        If rb2.Checked = True Then ' FECHA ANTERIOR 

            sql = "SELECT c.nitc, c.nomnit, t.telefono AS ccosto, c.doc, c.doc_ext, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, CAST( (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitcod, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
       & " IF ((SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
       & " IF ( (SELECT DATEDIFF( NOW( ) , (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, (total - pagado) AS total " _
       & " FROM ctas_x_pagar c, terceros t WHERE c.nitc= t.nit AND c.total > c.pagado  AND c.fecha <= '" & fc & "'"

        End If  ' Fin Un proveedor 

        sql2 = "SELECT a.nitc AS doc, a.per_doc AS codart, " _
        & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cta_inv, " _
        & " TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart, a.monto AS cantidad, a.causado AS valor, (a.monto - a.`causado`) AS vtotal   " _
        & " FROM terceros t, ant_a_prov a   " _
        & " WHERE(a.nitc = t.nit) " _
        & "ORDER BY nomart, a.fecha"

        TextBox1.Text = sql

        Dim tabla As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportPPlanPAnt.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportPPlanPago.CrystalReportViewer1.ReportSource = CrReport

        Dim doc_aj As String = ""
        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT doc_aj FROM `par_comp` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtr1 As New ParameterField
            Dim Prtr2 As New ParameterField
            Dim Prtr3 As New ParameterField
            Dim Prtr4 As New ParameterField
            Dim Prtr5 As New ParameterField
            Dim Prtt As New ParameterField
            Dim PrAJ As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtr1.Name = "R1"
            Prtr1.CurrentValues.AddValue(Tr1.ToString)

            Prtr2.Name = "R2"
            Prtr2.CurrentValues.AddValue(Tr2.ToString)

            Prtr3.Name = "R3"
            Prtr3.CurrentValues.AddValue(Tr3.ToString)

            Prtr4.Name = "R4"
            Prtr4.CurrentValues.AddValue(Tr4.ToString)

            Prtr5.Name = "R5"
            Prtr5.CurrentValues.AddValue(Tr5.ToString)

            Prtt.Name = "titulo"
            Prtt.CurrentValues.AddValue(tt.ToString)

            PrAJ.Name = "doc_aj"
            PrAJ.CurrentValues.AddValue(doc_aj.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtr1)
            prmdatos.Add(Prtr2)
            prmdatos.Add(Prtr3)
            prmdatos.Add(Prtr4)
            prmdatos.Add(Prtr5)
            prmdatos.Add(Prtt)
            prmdatos.Add(PrAJ)

            FrmReportPPlanPago.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportPPlanPago.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class