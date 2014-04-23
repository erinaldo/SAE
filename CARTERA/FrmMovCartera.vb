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

Public Class FrmMovCartera
    Public tabla5 As DataTable
    Public tabla As DataTable
    Public tabla2 As DataTable
    Public tabla3 As DataTable
    Public tabla4 As DataTable
    Public totalcar, total1, total2, total3, total4, total5 As Double
    Public totalcar_, total1_, total2_, total3_, total4_, total5_ As Double
    Private Sub FrmMovCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/2000"
        fecha1.MaxDate = "31/12/" & ano
        fecha2.MinDate = "01/01/2000"
        fecha2.MaxDate = "31/12/" & ano
        '**************************************
        fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Try
            fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception
            Try
                If PerActual(0) & PerActual(1) = "02" Then
                    fecha2.Value = "28/" & PerActual(0) & PerActual(1) & "/" & ano
                Else
                    fecha2.Value = "30/" & PerActual(0) & PerActual(1) & "/" & ano
                End If
            Catch ex2 As Exception
            End Try
        End Try
        '*********************

        '' CARGAR CLIENTES
        '' AUTOCOMPLETAR NIT CLIENTE
        'Try
        '    txtcliente.AutoCompleteCustomSource.Clear()

        '    Dim tb As New DataTable
        '    tb.Clear()
        '    myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    If tb.Rows.Count > 0 Then
        '        For i = 0 To tb.Rows.Count - 1
        '            txtcliente.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub

    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "informe_xclientes"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            cargarclientes()
        End If
    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = False
        End If

    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            'chcli.Visible = True
            'chcli.Checked = False
            'txtnitc.Focus()
        Else
            txtnitc.Enabled = False
            'chcli.Visible = False
            'chcli.Checked = False
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

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
        'Dim f1, f2 As String

        'f1 = (fecha1.Value.ToString("yyyy-MM-dd"))
        'f2 = (fecha2.Value.ToString("yyyy-MM-dd"))
        'If c1.Checked = True Then
        '    If fecha1.Value > fecha2.Value Then
        '        MsgBox("La fecha inicial debe ser menor o igual a la fecha final, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        '        fecha1.Focus()
        '        Exit Sub
        '    End If
        '    sql = "SELECT nitc FROM cobdpen WHERE total>pagado AND (fecha>='" & f1 & "' AND fecha<='" & f2 & "') group BY nitc order by nomnit;"
        '    ' sql = "SELECT nitc FROM cobdpen WHERE total>pagado group by nitc;"
        '    GenerarPDF_todos(sql)
        'Else
        '    If Trim(txtcliente.Text) = "" Then
        '        MsgBox("Digite un nit de Cliente valido, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        '        txtnitc.Focus()
        '        Exit Sub
        '    ElseIf fecha1.Value > fecha2.Value Then
        '        MsgBox("La fecha inicial debe ser menor o igual a la fecha final, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        '        fecha1.Focus()
        '        Exit Sub
        '    End If
        '    If checkresumido.Checked Then
        '        sql = "SELECT * FROM cobdpen WHERE nitc='" & txtnitc.Text & "' AND total>pagado AND fecha>='" & fecha1.Value & "' AND fecha<='" & fecha2.Value & "' ORDER BY nitc;"
        '        GenerarPDF_individual(sql)
        '    Else
        '        sql = "SELECT * FROM cobdpen WHERE nitc='" & txtnitc.Text & "' AND total>pagado AND fecha>='" & fecha1.Value & "' AND fecha<='" & fecha2.Value & "' ORDER BY doc;"
        '        GenerarPDF_individual(sql)
        '    End If
        'End If

        reporte()



    End Sub
    Private Sub reporte()

        Dim doc_aj As String = ""
        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim inf As String = ""
        Dim ley As String = ""
        Dim fc1 As String = ""
        Dim fc2 As String = ""

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
        inf = "ANALISIS DE CARTERA POR VENCIMIENTO"


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

        fc1 = Strings.Right(fecha1.Text, 4) & "-" & Strings.Mid(fecha1.Text, 4, 2) & "-" & Strings.Left(fecha1.Text, 2)
        fc2 = Strings.Right(fecha2.Text, 4) & "-" & Strings.Mid(fecha2.Text, 4, 2) & "-" & Strings.Left(fecha2.Text, 2)


        If c1.Checked = True Then

            sql = " SELECT c.nitc, c.nomnit, t.telefono AS nitcod, c.doc, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, " _
        & " CAST( (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitv, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
        & " IF ((SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, " _
        & " (total - pagado) AS total FROM cobdpen c, terceros t " _
        & " WHERE c.nitc=t.nit AND c.total > c.pagado AND (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) <= '" & fc2 & "'  "

        End If


        If c2.Checked = True Then

            sql = " SELECT c.nitc, c.nomnit, t.telefono AS nitcod, c.doc, CAST( c.fecha AS CHAR( 20 ) ) AS fecha, " _
        & " CAST( (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitv, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva, " _
        & " IF ((SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa, " _
        & " (total - pagado) AS total FROM cobdpen c, terceros t " _
        & " WHERE c.nitc = '" & txtnitc.Text & "' AND  t.nit= '" & txtnitc.Text & "' AND c.total > c.pagado AND (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) <= '" & fc2 & "'  "


        End If

        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT par_aju FROM car_par ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)


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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCCue.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportCarCuen.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtr1 As New ParameterField
            Dim Prtr2 As New ParameterField
            Dim Prtr3 As New ParameterField
            Dim Prtr4 As New ParameterField
            Dim Prtr5 As New ParameterField
            Dim Prinf As New ParameterField
            Dim Prley As New ParameterField
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

            Prley.Name = "leyenda"
            Prley.CurrentValues.AddValue(ley.ToString)

            Prinf.Name = "informe"
            Prinf.CurrentValues.AddValue(inf.ToString)

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
            prmdatos.Add(Prinf)
            prmdatos.Add(Prley)
            prmdatos.Add(PrAJ)

            FrmReportCarCuen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCarCuen.ShowDialog()

        Catch ex As Exception
            '  MsgBox(sql)
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
            cb.SetFontAndSize(fuente, 8)

            'Ubicamos Datos de la Compañia
            Dim tablacomp As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 2, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 2, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 2, 790, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 2, 780, 0)
            cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 2, 770, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANALISIS DE CARTERA POR VENCIMIENTOS", 300, 755, 0)
            cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
            k = 735
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 556, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
            cb.ShowTextAligned(50, "FECHA", 60, k, 0)
            cb.ShowTextAligned(50, "VMTO.", 110, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0-" & Str(inter1), 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter1 + 1) & "-" & Str(inter2), 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter2 + 1) & "-" & Str(inter3), 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter3 + 1) & "-" & Str(inter4), 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter4 + 1) & " O MAS", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 556, k, 0)
            k = k - 5
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)

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
                cb.SetFontAndSize(fuente, 8)
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
                cb.SetFontAndSize(fuente, 8)
            Next
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 125, k, 0)
            k = k - 5
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
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

    Public Sub GenerarPDF_individual(ByVal sql As String)
        Try
            MiConexion(bda)
            Cerrar()
            FechaRep = Now.ToString
            pag = 1
            oDoc = New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '*****************************************************
            Dim tablacomp, tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 2, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 2, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 2, 790, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 2, 780, 0)
            cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 2, 770, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANALISIS DE CARTERA POR VENCIMIENTOS", 300, 755, 0)
            cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
            k = 735
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 556, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
            cb.ShowTextAligned(50, "FECHA", 60, k, 0)
            cb.ShowTextAligned(50, "VMTO.", 110, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0-" & Str(inter1), 206, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter1 + 1) & "-" & Str(inter2), 276, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter2 + 1) & "-" & Str(inter3), 346, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter3 + 1) & "-" & Str(inter4), 416, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter4 + 1) & " O MAS", 486, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 556, k, 0)
            k = k - 5
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)

            ' Comenzamos con los Datos Reuqridos Para Impresion
            k = k - 10
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            imprime_individual()
            k = k - 10
            estadistica_individual()
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 125, k, 0)
            k = k - 5
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalcar), 556, k, 0)
            'imprime_cuerpo_facturas(sw)
            k = k - 10
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

        Dim x As Integer
        Try
            x = tabla.Rows.Count
            If vencimiento = 1 Then
                For i = 0 To x - 1
                    If Not checkresumido.Checked Then
                        txtfechavmto.Value = tabla.Rows(i).Item(4)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item(2)), 206, k, 0)
                        cb.ShowTextAligned(50, tabla.Rows(i).Item(6), 2, k, 0)
                        cb.ShowTextAligned(50, tabla.Rows(i).Item(4), 60, k, 0)
                        cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla.Rows(i).Item(5))), 110, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item(2)), 556, k, 0)
                        k = k - 10
                        If k <= 60 Then banner()
                    End If
                    total1 = total1 + (Val(tabla.Rows(i).Item(2)) - Val(tabla.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            x = tabla2.Rows.Count
            If vencimiento = 2 Then
                For i = 0 To x - 1
                    If Not checkresumido.Checked Then
                        txtfechavmto.Value = tabla2.Rows(i).Item(4)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla2.Rows(i).Item(2)), 276, k, 0)
                        cb.ShowTextAligned(50, tabla2.Rows(i).Item(6), 2, k, 0)
                        cb.ShowTextAligned(50, tabla2.Rows(i).Item(4), 60, k, 0)
                        cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla2.Rows(i).Item(5))), 110, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla2.Rows(i).Item(2)), 556, k, 0)
                        k = k - 10
                        If k <= 60 Then banner()
                    End If
                    total2 = total2 + (Val(tabla2.Rows(i).Item(2)) - Val(tabla2.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            x = tabla3.Rows.Count
            If vencimiento = 3 Then
                For i = 0 To x - 1
                    If Not checkresumido.Checked Then
                        txtfechavmto.Value = tabla3.Rows(i).Item(4)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla3.Rows(i).Item(2)), 346, k, 0)
                        cb.ShowTextAligned(50, tabla3.Rows(i).Item(6), 2, k, 0)
                        cb.ShowTextAligned(50, tabla3.Rows(i).Item(4), 60, k, 0)
                        cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla3.Rows(i).Item(5))), 110, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla3.Rows(i).Item(2)), 556, k, 0)
                        k = k - 10
                        If k <= 60 Then banner()
                    End If
                    total3 = total3 + (Val(tabla3.Rows(i).Item(2)) - Val(tabla3.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try
        Try
            x = tabla4.Rows.Count
            If vencimiento = 4 Then
                For i = 0 To x - 1
                    If Not checkresumido.Checked Then
                        txtfechavmto.Value = tabla4.Rows(i).Item(4)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla4.Rows(i).Item(2)), 416, k, 0)
                        cb.ShowTextAligned(50, tabla4.Rows(i).Item(6), 2, k, 0)
                        cb.ShowTextAligned(50, tabla4.Rows(i).Item(4), 60, k, 0)
                        cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla4.Rows(i).Item(5))), 110, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla4.Rows(i).Item(2)), 556, k, 0)
                        k = k - 10
                        If k <= 60 Then banner()
                    End If
                    total4 = total4 + (Val(tabla4.Rows(i).Item(2)) - Val(tabla4.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            x = 0
            x = tabla5.Rows.Count
            If vencimiento = 5 Then
                For i = 0 To x - 1
                    If Not checkresumido.Checked Then
                        txtfechavmto.Value = tabla5.Rows(i).Item(4)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla5.Rows(i).Item(2)), 486, k, 0)
                        cb.ShowTextAligned(50, tabla5.Rows(i).Item(6), 2, k, 0)
                        cb.ShowTextAligned(50, tabla5.Rows(i).Item(4), 60, k, 0)
                        cb.ShowTextAligned(50, txtfechavmto.Value.AddDays(Val(tabla5.Rows(i).Item(5))), 110, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla5.Rows(i).Item(2)), 556, k, 0)
                        k = k - 10
                        If k <= 60 Then banner()
                    End If
                    total5 = total5 + (Val(tabla5.Rows(i).Item(2)) - Val(tabla5.Rows(i).Item(3)))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub banner()
        Dim tablacomp, tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        pag = pag + 1
        cb.EndText()
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 2, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 2, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 2, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 2, 780, 0)
        cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 2, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANALISIS DE CARTERA POR VENCIMIENTOS", 300, 755, 0)
        cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
        k = 735
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 206, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 276, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 340, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 416, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 486, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 556, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
        cb.ShowTextAligned(50, "FECHA", 60, k, 0)
        cb.ShowTextAligned(50, "VMTO.", 110, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0-" & Str(inter1), 206, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter1 + 1) & "-" & Str(inter2), 276, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter2 + 1) & "-" & Str(inter3), 346, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter3 + 1) & "-" & Str(inter4), 416, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Str(inter4 + 1) & " O MAS", 486, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 556, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)

        ' Comenzamos con los Datos Reuqridos Para Impresion
        k = k - 10
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        imprime_individual()
        k = k - 10
        Exit Sub
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
            cb.ShowTextAligned(50, "CLIENTE:", 2, k, 0)
            cb.ShowTextAligned(50, nom, 40, k, 0)
            cb.ShowTextAligned(50, "NIT:", 297, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("nit"), 320, k, 0)
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
            nit = Trim(txtnitc.Text)
            myCommand.CommandText = "SELECT nit, nombre, apellidos, dir, telefono, mun  FROM terceros  where nit='" + nit + "';"
            'MsgBox(myCommand.CommandText)
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla11)
            Refresh()
            items2 = tabla11.Rows.Count
            ' Imprimo el Estado de cuenta del Cliente...
            Dim nom As String
            nom = tabla11.Rows(0).Item("nombre") + " " + tabla11.Rows(0).Item("apellidos")
            cb.ShowTextAligned(50, "CLIENTE:", 2, k, 0)
            cb.ShowTextAligned(50, nom, 40, k, 0)
            cb.ShowTextAligned(50, "NIT:", 297, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("nit"), 320, k, 0)
            cb.ShowTextAligned(50, "TELEFONOS:", 380, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("telefono"), 440, k, 0)
            cb.ShowTextAligned(50, "CIUDAD:", 500, k, 0)
            cb.ShowTextAligned(50, tabla11.Rows(0).Item("mun"), 550, k, 0)
            k = k - 5
        Catch ex As Exception
        End Try
    End Sub

    Public Sub estadistica_individual()
        Dim items1 As Integer
        Dim num_reg As Integer

        Dim venc1, venc2, venc3, venc4, venc5 As Integer
        Dim f1, f2 As String

        f1 = Format(fecha1.Value, "yyyy-MM-dd")
        f2 = Format(fecha2.Value, "yyyy-MM-dd")
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

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)<='" & venc1 & "' and nitc ='" & Trim(txtnitc.Text) & "' and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado, fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF(now(),fecha) <='" & Trim(Str(venc1)) & "' and nitc ='" & Trim(txtnitc.Text) & "' group by doc;"
            End If

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
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try

            tabla2 = New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc1 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc2 & "' and nitc ='" & Trim(txtnitc.Text) & "'and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('now()',fecha)>'" & Trim(Str(venc1)) & "' and DATEDIFF('now()',fecha)<='" & Trim(Str(venc2)) & "' and nitc ='" & Trim(txtnitc.Text) & "' group by doc;"
            End If

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
            '
        End Try
        '********* Totalizar Cartera 

        Try

            tabla3 = New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc2 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc3 & "' and nitc ='" & Trim(txtnitc.Text) & "' and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('now()',fecha)>'" & Trim(Str(venc2)) & "' and DATEDIFF('now()',fecha)<='" & Trim(Str(venc3)) & "' and nitc ='" & Trim(txtnitc.Text) & "' group by doc;"
            End If

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
            '
        End Try
        '********* Totalizar Cartera 
        Try

            tabla4 = New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc3 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc4 & "' and nitc ='" & Trim(txtnitc.Text) & "' and fecha>='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('now()',fecha)>'" & Trim(Str(venc3)) & "' and DATEDIFF('now()',fecha)<='" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnitc.Text) & "' group by doc;"
            End If

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

            Try
                tabla5 = New DataTable
                If filtrofecha.Checked Then
                    myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc4 & "' and nitc ='" & Trim(txtnitc.Text) & "'and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
                Else
                    myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('now()',fecha)>'" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnitc.Text) & "' group by doc;"
                End If

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
                '
            End Try


        Catch ex As Exception
            '
        End Try
        'totalcar = total1 + total2 + total3 + total4 + total5

    End Sub
    Public Sub estadistica_grupo(ByVal nit As String)
        Dim items1 As Integer
        Dim num_reg As Integer

        Dim venc1, venc2, venc3, venc4, venc5 As Integer
        Dim f1, f2 As String

        f1 = Format(fecha1.Value, "yyyy-MM-dd")
        f2 = Format(fecha2.Value, "yyyy-MM-dd")
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

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)<='" & venc1 & "' and nitc ='" & nit & "' and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado, fecha, vmto,doc FROM cobdpen where total>pagado and vmto <='" & Trim(Str(venc1)) & "' and nitc ='" & nit & "' group by doc;"
            End If

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
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try

            tabla2 = New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc1 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc2 & "' and nitc ='" & nit & "' and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and nitc ='" & nit & "' group by doc;"
            End If

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
            '
        End Try
        '********* Totalizar Cartera 

        Try

            tabla3 = New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc2 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc3 & "' and nitc ='" & nit & "' and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and nitc ='" & nit & "' group by doc;"
            End If

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
            '
        End Try
        '********* Totalizar Cartera 
        Try

            tabla4 = New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc  FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc3 & "' and DATEDIFF('" & f2 & "',fecha)<='" & venc4 & "' and nitc ='" & nit & "' and fecha>='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
            Else
                myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and nitc ='" & nit & "' group by doc;"
            End If

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

            Try
                tabla5 = New DataTable
                If filtrofecha.Checked Then
                    myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and DATEDIFF('" & f2 & "',fecha)>'" & venc4 & "' and nitc ='" & nit & "'and fecha >='" & f1 & "' and fecha <='" & f2 & "' group by doc;"
                Else
                    myCommand.CommandText = "SELECT sum(total-pagado), tipo,(total-pagado) AS total,pagado , fecha, vmto,doc FROM cobdpen where total>pagado and vmto >'" & Trim(Str(venc4)) & "' and nitc ='" & nit & "' group by doc;"
                End If

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
                '
            End Try


        Catch ex As Exception
            '
        End Try
        'totalcar = total1 + total2 + total3 + total4 + total5

    End Sub

    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = True
        Else
            txtcliente.Enabled = False
            txtnitc.Enabled = True
        End If
    End Sub

    Private Sub txtcliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcliente.LostFocus
        Try
            If txtcliente.Text = "" Then
                txtnitc.Text = ""
                FrmSelCliente.lbform.Text = "informe_xclientes"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtcliente.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(nombre,' ',apellidos)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txtnitc.Text = ""
            FrmSelCliente.lbform.Text = "informe_xclientes"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub

   
End Class