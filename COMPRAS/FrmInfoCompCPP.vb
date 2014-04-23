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
Public Class FrmInfoCompCPP
    Private Sub FrmInfoCompCPP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '********************

        ' CARGAR CLIENTES
        ' AUTOCOMPLETAR NIT CLIENTE
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
            FrmSelCliente.lbform.Text = "cpp_inf_cpp"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '**********************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'Dim sql As String = "SELECT v.estado,v.tipo,v.doc,v.doc_afec,v.dia,v.periodo,v.abonado,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit,v.total,ucase(v.tipo_pago) AS tp FROM vista_ot_cpp v LEFT JOIN (terceros t) ON v.nitc=t.nit WHERE "
        'Dim tipo As String = ""
        'If rb1.Checked = True Then
        '    sql = sql & "v.estado='AP' "
        '    tipo = "INFORME DE COMPROBANTES APROBADOS DE CUENTAS POR PAGAR"
        'ElseIf rb2.Checked = True Then
        '    sql = sql & "(v.estado='' OR v.estado=' ') "
        '    tipo = "INFORME DE COMPROBANTES PENDIENTES DE CUENTAS POR PAGAR"
        'ElseIf rb3.Checked = True Then
        '    sql = sql & " v.estado<>'NN' "
        '    tipo = "INFORME DE COMPROBANTES DE CUENTAS POR PAGAR"
        'End If
        ''**************************
        If c2.Checked = True Then
            If txtcliente.Text = "" Then
                MsgBox("Verifique datos del proveedor.  ", MsgBoxStyle.Information)
                txtnitc.Focus()
                Exit Sub
            End If
            'sql = sql & " AND v.nitc='" & txtnitc.Text & "'"
            'tipo = tipo & " Y UN PROVEEDOR"
        End If
        '**************************
        If fecha1.Value > fecha2.Value Then
            MsgBox("La fecha inicial no puede ser mayor que la final, verifique. ", MsgBoxStyle.Information)
            fecha1.Focus()
            Exit Sub
        End If
        '*********************************
        'Dim per1, per2, dia1, dia2 As String
        'If Val(fecha1.Value.Month.ToString) < 10 Then
        '    per1 = "0" & Val(fecha1.Value.Month.ToString) & "/" & fecha1.Value.Year
        'Else
        '    per1 = fecha1.Value.Month.ToString & "/" & fecha1.Value.Year
        'End If
        'If Val(fecha2.Value.Month.ToString) < 10 Then
        '    per2 = "0" & Val(fecha2.Value.Month.ToString) & "/" & fecha2.Value.Year
        'Else
        '    per2 = fecha2.Value.Month.ToString & "/" & fecha2.Value.Year
        'End If
        'If Val(fecha1.Value.Day.ToString) < 10 Then
        '    dia1 = "0" & Val(fecha1.Value.Day.ToString)
        'Else
        '    dia1 = fecha1.Value.Day.ToString
        'End If
        'If Val(fecha2.Value.Day.ToString) < 10 Then
        '    dia2 = "0" & Val(fecha2.Value.Day.ToString)
        'Else
        '    dia2 = fecha2.Value.Day.ToString
        'End If
        'Dim cad As String = "AND (v.dia>='" & dia1 & "' AND v.periodo>='" & per1 & "') AND (v.dia<='" & dia2 & "' AND v.periodo<='" & per2 & "')"
        'sql = sql & cad & " AND v.abonado>'0' ORDER BY tipo,periodo,dia,doc;"
        'Try
        '    GeneraPDF(sql, tipo)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        Dim sql As String = ""
        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim inf As String = ""
        Dim fc As String = ""



        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & "/" & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & "/" & Strings.Right(fecha2.Text, 4)

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")
        'inf = "DIAS DE VENCIMIENTO " & txtdias.Text & " O MAS "


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim m1 As String = ""
        Dim m2 As String = ""

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        Dim tdoc As String = ""
        Dim cl As String = ""
        If rb1.Checked = True Then
            tdoc = " AND o . estado ='AP'"
        ElseIf rb2.Checked = True Then
            tdoc = " AND o . estado ='' "
        End If

        If c2.Checked = True Then
            cl = " AND o.nitc = '" & txtnitc.Text & "' AND  t.nit = '" & txtnitc.Text & "'"
        Else
            cl = " AND o . nitc =t . nit"
        End If


        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If p = m1 Then

                sql = " SELECT o.doc_aj as d1, o . nitc , t . nombre AS usuario ,CONCAT( o . doc_afec,' - ',c.doc_ext) AS doc_de , o . doc , CAST(CONCAT(o . dia , '/' , o . periodo )AS CHAR(20 ))AS fecha_o , o . descrip , o . abonado AS v2 , o . tipo_pago as cta1, o.total as subtotal " _
                & " FROM ot_cpp" & p & " o , ctas_x_pagar c , terceros t WHERE (o . doc_afec =c . doc ) " & cl & " " & tdoc & " "

            Else
                sql = sql & " UNION SELECT o.doc_aj as d1, o . nitc , t . nombre AS usuario , CONCAT( o . doc_afec,' - ',c.doc_ext) AS doc_de , o . doc , CAST(CONCAT(o . dia , '/' , o . periodo )AS CHAR(20 ))AS fecha_o , o . descrip , o . abonado AS v2 , o . tipo_pago as cta1, o.total as subtotal " _
                & " FROM ot_cpp" & p & " o , ctas_x_pagar c , terceros t WHERE (o . doc_afec =c . doc )" & cl & " " & tdoc & " "
            End If
        Next
        sql = sql & " ORDER BY nitc "


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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCompCPP.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportCompCPP.CrystalReportViewer1.ReportSource = CrReport

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


            FrmReportCompCPP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCompCPP.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try


    End Sub
    '*************************************************
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GeneraPDF(ByVal sql As String, ByVal tipo As String)
        Dim per As String = ""
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
                If art <> tabla.Rows(i).Item("tipo") Then
                    If art <> "" Then 'HAY SUBTOTAL
                        k = k - 5
                        cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                        k = k - 10
                        cb.ShowTextAligned(50, "*** SUB TOTAL DOCUMENTO: ", 150, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subabono), 440, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 500, k, 0)
                    End If
                    k = k - 15
                    cb.ShowTextAligned(50, "*** " & tabla.Rows(i).Item("tipo") & " - " & tipodoc(tabla.Rows(i).Item("tipo")) & " ****", 10, k, 0)
                    art = tabla.Rows(i).Item("tipo")
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
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 2, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("periodo"), 60, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomnit"), 45), 100, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("doc_afec"), 290, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("estado"), 345, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("abonado")), 440, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("total")), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("tp"), 510, k, 0)
                '******************************************************************
                subtotal = subtotal + (Moneda(tabla.Rows(i).Item("total")))
                subabono = subabono + (Moneda(tabla.Rows(i).Item("abonado")))
                '******************************************************************
                ta = ta + (Moneda(tabla.Rows(i).Item("abonado")))
                total = total + (Moneda(tabla.Rows(i).Item("total")))
            Next
            '****************************************************************
            If art <> "" Then 'HAY SUBTOTAL
                k = k - 5
                cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "*** SUB TOTAL DOCUMENTO: ", 150, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subabono), 440, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 500, k, 0)
            End If
            k = k - 5
            cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "***  TOTAL  GENERAL  *** ", 150, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(ta), 440, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total), 500, k, 0)
            '****************************************************************
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
        cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
        cb.ShowTextAligned(50, "FECHA", 60, k, 0)
        cb.ShowTextAligned(50, "PROVEEDOR", 100, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DOCUMENTO", 290, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AFECTADO", 290, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ESTADO", 345, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ABONADO", 440, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR NETO", 500, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COMPROBANTE", 500, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "FORMA DE PAGO", 510, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    '******************************************

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


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
                FrmSelCliente.lbform.Text = "cpp_inf_cpp"
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
            FrmSelCliente.lbform.Text = "cpp_inf_cpp"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class