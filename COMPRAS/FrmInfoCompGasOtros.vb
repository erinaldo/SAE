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
Public Class FrmInfoCompGasOtros
    Private Sub FrmInfoCompGasOtros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/" & ano
        fecha1.MaxDate = "31/12/" & ano
        fecha2.MinDate = "01/01/" & ano
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
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '**********************************
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then txtnitc.Enabled = False
    End Sub
    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            chcli.Visible = True
            chcli.Checked = False
            'txtnitc.Focus()
        Else
            txtnitc.Enabled = False
            chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            txtnitc.Text = ""
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
            FrmSelCliente.lbform.Text = "cpp_inf_gas"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '**********************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim con As String = ""
        Dim tipo As String = ""
        'If r1.Checked = True Then
        '    con = " WHERE o.doc_aj<>'%%' "
        '    tipo = "INFORME DE COMPROBANTES APROBADOS DE OTROS EGRESOS"
        'Else
        '    con = " WHERE o.doc_aj<>'' AND o.doc_aj<>' ' "
        '    tipo = "INFORME DE COMPROBANTES ANULADOS DE OTROS EGRESOS"
        'End If
        If c2.Checked = True Then
            If txtcliente.Text = "" Then
                MsgBox("Verifique datos del proveedor.  ", MsgBoxStyle.Information)
                txtnitc.Focus()
                Exit Sub
            End If
            'con = con & " AND o.nitc='" & txtnitc.Text & "'"
            'tipo = " Y UN PROVEEDOR"
            If fecha1.Value > fecha2.Value Then
                MsgBox("La fecha inicial no puede ser mayor que la final, verifique. ", MsgBoxStyle.Information)
                fecha1.Focus()
                Exit Sub
            End If
        End If
        Try
            'GeneraPDF(con, tipo)
            GenerarPDFN()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '*************************************************
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String

    Public Sub GenerarPDFN()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""


        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & "/" & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & "/" & Strings.Right(fecha2.Text, 4)

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim m1 As String = ""
        Dim m2 As String = ""

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)



        Dim sql As String = ""


        If c1.Checked = True Then '********** TODOS TERCEROS ********

            For i = Val(m1) To Val(m2)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p = m1 Then

                    sql = " select o . doc as doc, o.doc_aj as d1, concat(o . dia , '/' , o . periodo )as fecha_o , o . concepto as cta_desc, t . nombre as usuario , o . nitc as nitc ,if(o . debito <>0 , '+' , '-' )as doc_de , " _
                    & " (o . debito - o . credito )as subtotal , o.total as descuento, " _
                    & " if(o . efectivo ='S' , 'EFECTIVO' , CONCAT('CHEQUE N° ' , o . cheque , '  BANCO: ' , o . banco ))as descrip , " _
                    & " o . periodo as num, o . dia as tipodoc, o . descrip as cta_iva FROM ot_doc" & p & " o , terceros t  WHERE o . tipo =(select ce from parotdoc )AND o . nitc =t . nit "

                Else

                    sql = sql & " UNION  select o . doc as doc, o.doc_aj as d1, concat(o . dia , '/' , o . periodo )as fecha_o , o . concepto as cta_desc, t . nombre as usuario , o . nitc as nitc ,if(o . debito <>0 , '+' , '-' )as doc_de , " _
                    & " (o . debito - o . credito )as subtotal , o.total as descuento, " _
                    & " if(o . efectivo ='S' , 'EFECTIVO' , CONCAT('CHEQUE N° ' , o . cheque , '  BANCO: ' , o . banco ))as descrip , " _
                    & " o . periodo as num, o . dia as tipodoc, o . descrip as cta_iva FROM ot_doc" & p & " o , terceros t  WHERE o . tipo =(select ce from parotdoc )AND o . nitc =t . nit "

                End If
            Next
            sql = sql & " ORDER BY usuario, doc, num, tipodoc "

        End If ' ********* FIN TODOS LOS TERCEROS


        If c2.Checked = True Then '********** UN TERCEROS ********

            For i = Val(m1) To Val(m2)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p = m1 Then

                    sql = " select o . doc as doc,  o.doc_aj as d1,concat(o . dia , '/' , o . periodo )as fecha_o , o . concepto as cta_desc, t . nombre as usuario , o . nitc as nitc ,if(o . debito <>0 , '+' , '-' )as doc_de , " _
                   & " (o . debito - o . credito )as subtotal , o.total as descuento, " _
                   & " if(o . efectivo ='S' , 'EFECTIVO' , CONCAT('CHEQUE N° ' , o . cheque , '  BANCO: ' , o . banco ))as descrip , " _
                   & " o . periodo as num, o . dia as tipodoc, o . descrip as cta_iva FROM ot_doc" & p & " o , terceros t  WHERE o . tipo =(select ce from parotdoc )AND o . nitc = '" & txtnitc.Text & "' AND t . nit= '" & txtnitc.Text & "' "

                Else

                    sql = sql & " UNION  select o . doc as doc,  o.doc_aj as d1,concat(o . dia , '/' , o . periodo )as fecha_o , o . concepto as cta_desc, t . nombre as usuario , o . nitc as nitc ,if(o . debito <>0 , '+' , '-' )as doc_de , " _
                   & " (o . debito - o . credito )as subtotal , o.total as descuento, " _
                   & " if(o . efectivo ='S' , 'EFECTIVO' , CONCAT('CHEQUE N° ' , o . cheque , '  BANCO: ' , o . banco ))as descrip , " _
                   & " o . periodo as num, o . dia as tipodoc, o . descrip as cta_iva FROM ot_doc" & p & " o , terceros t  WHERE o . tipo =(select ce from parotdoc )AND o . nitc = '" & txtnitc.Text & "' AND t . nit= '" & txtnitc.Text & "' "

                End If
            Next
            sql = sql & " ORDER BY usuario, doc, num, tipodoc "

        End If ' ********* FIN UN TERCEROS

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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCoOtrosG.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportCoOtrosG.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)


            FrmReportCoOtrosG.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCoOtrosG.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try

    End Sub
    Public Sub GeneraPDF(ByVal cad As String, ByVal tipo As String)
        Dim per As String = ""
        Dim sql As String = ""
        Dim tabla As New DataTable
        Dim items As Integer = 0
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        Dim subtotal, subabono As Double
        Dim ta, total As Double
        Dim tope As Integer = 80
        Try
            pag = 1
            tope = 80
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            Banner(tipo)
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            Dim p As String = ""
            Dim d1, d2 As String
            If fecha1.Value.Day < 10 Then
                d1 = "0" & Val(fecha1.Value.Day.ToString)
            Else
                d1 = fecha1.Value.Day.ToString
            End If
            If fecha2.Value.Day < 10 Then
                d2 = "0" & Val(fecha2.Value.Day.ToString)
            Else
                d2 = fecha2.Value.Day.ToString
            End If
            '*******************************************
            For i = Val(fecha1.Value.Month.ToString) To Val(fecha2.Value.Month.ToString)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If i = Val(fecha1.Value.Month.ToString) Then 'IF i=primer periodo
                    If i = Val(fecha2.Value.Month.ToString) Then 'If solo hay un periodo i tambien = al ultimo
                        sql = "SELECT o.base,o.item,o.tipo,o.doc,o.codigo,descrip,o.doc_afec,o.dia,o.periodo,o.debito,o.credito,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM ot_doc" & p & " o LEFT JOIN(terceros t) ON o.nitc=t.nit " & cad & " AND o.dia>='" & d1 & "' AND o.dia<='" & d2 & "' AND o.grupo='CE' "
                    Else 'if hay varios periodos hace la consulta pa el primer periodo pa saber desde que dia empiesa
                        sql = "SELECT o.base,o.item,o.tipo,o.doc,o.codigo,descrip,o.doc_afec,o.dia,o.periodo,o.debito,o.credito,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM ot_doc" & p & " o LEFT JOIN(terceros t) ON o.nitc=t.nit " & cad & " AND o.dia>='" & d1 & "' AND o.grupo='CE' "
                    End If
                ElseIf i = Val(fecha2.Value.Month.ToString) Then 'if i es el ultimo hace la consulta para ver has q dia llega
                    sql = sql & " UNION SELECT o.base,o.item,o.tipo,o.doc,o.codigo,descrip,o.doc_afec,o.dia,o.periodo,o.debito,o.credito,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM ot_doc" & p & " o LEFT JOIN(terceros t) ON o.nitc=t.nit " & cad & " AND o.dia<='" & d2 & "' AND o.grupo='CE' "
                Else 'if es un periodo trae todo los dias
                    sql = sql & " UNION SELECT o.base,o.item,o.tipo,o.doc,o.codigo,descrip,o.doc_afec,o.dia,o.periodo,o.debito,o.credito,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM ot_doc" & p & " o LEFT JOIN(terceros t) ON o.nitc=t.nit " & cad & " AND o.grupo='CE' "
                End If
            Next
            sql = sql & "  ORDER BY nomnit,periodo,dia,doc,item;"
            tabla.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            subtotal = 0
            subabono = 0
            ta = 0
            total = 0
            Dim art As String = ""
            '****************************************************************
            For i = 0 To items - 1
                If art <> tabla.Rows(i).Item("nomnit") Then
                    If art <> "" Then 'HAY SUBTOTAL
                        k = k - 5
                        cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                        k = k - 10
                        cb.ShowTextAligned(50, "*** SUB TOTAL PROVEEDOR: ", 150, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subabono), 500, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 585, k, 0)
                    End If
                    k = k - 15
                    cb.ShowTextAligned(50, "*** PROVEEDOR: " & tabla.Rows(i).Item("nomnit") & " ****", 10, k, 0)
                    art = tabla.Rows(i).Item("nomnit")
                    subtotal = 0
                    subabono = 0
                End If
                k = k - 10
                If k <= tope Then
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner(tipo)
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                    k = k - 10
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 10, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("periodo"), 60, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("descrip"), 45), 100, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("doc_afec"), 290, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("codigo"), 345, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("base")), 440, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("debito")), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("credito")), 585, k, 0)
                '******************************************************************
                subtotal = subtotal + (Moneda(tabla.Rows(i).Item("debito")))
                subabono = subabono + (Moneda(tabla.Rows(i).Item("credito")))
                '******************************************************************
                ta = ta + (Moneda(tabla.Rows(i).Item("debito")))
                total = total + (Moneda(tabla.Rows(i).Item("credito")))
            Next
            '****************************************************************
            If art <> "" Then 'HAY SUBTOTAL
                k = k - 5
                cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "*** SUB TOTAL PROVEEDOR: ", 150, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subabono), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 585, k, 0)
            End If
            k = k - 5
            cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "***  TOTAL  GENERAL  *** ", 150, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(ta), 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total), 585, k, 0)
            '****************************************************************
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                'FrmReportePuc.ShowDialog()
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
    End Sub
    Function tipodoc(ByVal t As String)
        Try
            Dim ta As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & t & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            If ta.Rows.Count > 0 Then
                Return ta.Rows(0).Item(0)
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub Banner(ByVal tipo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tipo, 300, 755, 0)
        cb.ShowTextAligned(50, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
        k = 735
        k = k - 10
        cb.ShowTextAligned(50, "DOCUMENTO", 10, k, 0)
        cb.ShowTextAligned(50, "FECHA", 60, k, 0)
        cb.ShowTextAligned(50, "CONCEPTO", 100, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DOCUMENTO", 290, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AFECTADO", 290, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CUENTA", 345, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "BASE", 440, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 500, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    '******************************************

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

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
                FrmSelCliente.lbform.Text = "cpp_inf_gas"
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
            FrmSelCliente.lbform.Text = "cpp_inf_gas"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class