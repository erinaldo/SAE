Imports iTextSharp.text.pdf
Imports System.IO
Imports iTextSharp.text
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmInve_y_Balances

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'GenerearPDF()
        informe()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerearPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
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
            '*******************************************
            Dim sw As Boolean
            Dim tabla, tter As New DataTable
            If chter.Checked = False Then
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo <'4' ORDER BY codigo;"
            Else
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo <'4' AND nivel='Auxiliar' ORDER BY codigo;"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                If rbc1.Checked = True And chter.Checked = False Then
                    sw = True
                Else
                    sw = VerificarSaldo(tabla.Rows(i).Item("codigo"))
                End If
                If sw = True Then 'hay saldo
                    k = k - 10
                    If k < tope Then 'NUEVA PAGINA
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
                    '*********************************
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 5, k, 0)
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("descripcion"), 60), 85, k, 0)
                    If chter.Checked = False Then
                        saldos(tabla.Rows(i).Item("codigo"), "documentos" & PerActual(0) & PerActual(1), 530)
                    Else ' por terceros
                        tter.Clear()
                        myCommand.CommandText = "SELECT nit FROM terceros ORDER BY apellidos, nombre;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tter)
                        For j = 0 To tter.Rows.Count - 1
                            If VerificarNIT(tter.Rows(j).Item("nit"), tabla.Rows(i).Item("codigo")) Then
                                k = k - 10
                                If k < tope Then 'NUEVA PAGINA
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
                                BuscarTerceros(tabla.Rows(i).Item("codigo"), tter.Rows(j).Item("nit"))
                            End If
                        Next
                        k = k - 8
                        cb.ShowTextAligned(50, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
                        k = k - 7
                        cb.ShowTextAligned(50, "SUB TOTAL " & tabla.Rows(i).Item("descripcion"), 30, k, 0)
                        SubTotales(tabla.Rows(i).Item("codigo"))
                        saldos(tabla.Rows(i).Item("codigo"), PerActual(0) & PerActual(1), 585)
                        k = k - 5
                    End If
                End If
            Next
            '********************************************
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Me.Cursor = Cursors.Default
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 800
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "NIT. " & tablacomp.Rows(0).Item("nit"), 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "PERIODO: " & PerActual, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INVENTARIO Y BALANCES", 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        If chter.Checked = True Then
            k = k - 20
            cb.ShowTextAligned(50, "CUENTA", 5, k, 0)
            cb.ShowTextAligned(50, "NOMBRE DEL TERCERO", 85, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 285, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ANTERIOR", 285, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITOS", 385, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITOS", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 585, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ACTUAL", 585, k, 0)
        Else
            k = k - 10
            cb.ShowTextAligned(50, "CUENTA", 5, k, 0)
            cb.ShowTextAligned(50, "DESCRIPCION", 85, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO " & PerActual, 530, k, 0)
        End If
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
    Function VerificarSaldo(ByVal cuenta As String)
        Dim ts As New DataTable
        Dim per As String
        'For i = 0 To Val(PerActual(0) & PerActual(1))
        per = PerActual(0) & PerActual(1)
        ts.Clear()
        myCommand.CommandText = "SELECT SUM(saldo" & per & ") as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Try
            If ts.Rows(0).Item(0) <> 0 Then
                Return True
            End If
        Catch ex As Exception
        End Try
        'Next
        Return False
    End Function
    Public Sub saldos(ByVal cuenta As String, ByVal campo As String, ByVal pos As Integer)
        Dim ts As New DataTable
        Dim dife, aux As Double
        Dim per As String
        dife = 0
        ts.Clear()
        'For i = 0 To Val()
      
        per = PerActual(0) & PerActual(1)
        ts.Clear()
        myCommand.CommandText = "SELECT SUM(saldo" & per & ") as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Try
            If ts.Rows(0).Item(0) <> 0 Then
                aux = ts.Rows(0).Item(0)
            End If
        Catch ex As Exception
            aux = 0
        End Try
        dife = dife + aux
        'Next
        If dife <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(dife), pos, k, 0)
    End Sub
    Public Sub BuscarTerceros(ByVal cuenta As String, ByVal nit As String)
        Dim tnom, tini, tmov, tact As New DataTable
        Dim per As String
        Dim suma, aux As Double
        tnom.Clear()
        tmov.Clear()
        '************************* NOMBRE TERCERO *******************************************
        myCommand.CommandText = "SELECT nombre,apellidos FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tnom)
        cb.ShowTextAligned(50, CambiaCadena(tnom.Rows(0).Item("nombre") & " " & tnom.Rows(0).Item("apellidos"), 35), 85, k, 0)
        '***************************SALDO INICIAL NIT *****************************************
        suma = 0
        For i = 0 To (Val(PerActual(0) & PerActual(1)) - 1)
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            tini.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' AND nit ='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tini)
            Try
                If tini.Rows(0).Item(0) <> 0 Then
                    aux = tini.Rows(0).Item(0)
                End If
            Catch ex As Exception
                aux = 0
            End Try
            suma = suma + aux
        Next
        If suma <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 285, k, 0)
        '******************** MOVIMIENTOS NIT ************************************************
        tmov.Clear()
        per = PerActual(0) & PerActual(1)
        myCommand.CommandText = "SELECT SUM(debito), SUM(credito) FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' AND nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tmov)
        Try
            If tmov.Rows(0).Item(0) <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tmov.Rows(0).Item(0)), 385, k, 0)
        Catch ex As Exception
        End Try
        Try
            If tmov.Rows(0).Item(1) <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tmov.Rows(0).Item(1)), 485, k, 0)
        Catch ex As Exception
        End Try
        '****************** SALDO ACTUAL NIT**************************************************
        suma = 0
        For i = 0 To Val(PerActual(0) & PerActual(1))
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            tact.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) AS s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' AND nit ='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tact)
            Try
                aux = tact.Rows(0).Item(0)
            Catch ex As Exception
                aux = 0
            End Try
            suma = suma + aux
        Next
        If suma <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
    End Sub
    Public Sub SubTotales(ByVal cuenta As String)
        Dim tini, tact As New DataTable
        Dim per As String
        Dim sdb, scr, db, cr, suma, aux As Double
        sdb = 0
        scr = 0
        per = PerActual(0) & PerActual(1)
        tact.Clear()
        myCommand.CommandText = "SELECT SUM(debito" & per & "), SUM(credito" & per & ") FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tact)
        Try
            db = tact.Rows(0).Item(0)
        Catch ex As Exception
            db = 0
        End Try
        sdb = sdb + db
        Try
            cr = tact.Rows(0).Item(1)
        Catch ex As Exception
            cr = 0
        End Try
        scr = scr + cr
        If sdb <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sdb), 385, k, 0)
        If scr <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(scr), 485, k, 0)
        '********************************************************************
        suma = 0
        For i = 0 To (Val(PerActual(0) & PerActual(1)) - 1)
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            tini.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tini)
            Try
                If tini.Rows(0).Item(0) <> 0 Then
                    aux = tini.Rows(0).Item(0)
                End If
            Catch ex As Exception
                aux = 0
            End Try
            suma = suma + aux
        Next
        If suma <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 285, k, 0)
    End Sub
    Function VerificarNIT(ByVal nit As String, ByVal cuenta As String)
        Dim ts As New DataTable
        Dim per As String
        For i = 0 To Val(PerActual(0) & PerActual(1))
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            ts.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' AND nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ts)
            Try
                If ts.Rows(0).Item(0) <> 0 Then
                    Return True
                End If
            Catch ex As Exception
            End Try
        Next
        Return False
    End Function

    Private Sub informe()

        Try
            BuscarPeriodo()

            Dim sql As String = ""
            Dim nom As String = ""
            Dim nitp As String = ""
            Dim per As String = ""
            Dim p As String = ""
            Dim pA As String = ""
            Dim tit As String = ""

            p = PerActual(0) & PerActual(1)

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
            per = PerActual


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            MiConexion(bda)

            If chter.Checked = False Then

                If rbc1.Checked = True Then
                    tit = "INVENTARIO Y BALANCE DE TODAS LAS CUENTAS"
                Else
                    tit = "INVENTARIO Y BALANCE - CUENTAS CON SALDO "
                End If

                sql = " SELECT s.codigo ,s.descripcion , sum(c.saldo" & p & ") as saldo, if ( sum(c.saldo" & p & ") =0, 'Y','N') as nivel " _
                    & " FROM (SELECT codigo,  saldo" & p & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
                    & " on (c.codigo LIKE CONCAT(s.codigo,'%')) WHERE s.codigo BETWEEN '1' AND '4' group by s.codigo "

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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportInvBalanc.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportInvBalanc.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nitp.ToString)

                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    Prtt.Name = "tit"
                    Prtt.CurrentValues.AddValue(tit.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(Prtt)

                    FrmReportInvBalanc.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportInvBalanc.ShowDialog()
                Catch ex As Exception
                End Try
            End If

            ' -------------- DETALLADO POR TECEROS 
            If chter.Checked = True Then

                tit = "INVENTARIOS Y BALANCES"

                Dim pe As String = ""


                sql = " SELECT  codigo as nitc, descripcion as observ, nit as nitv, nombre as descrip, SUM(d1-c1) AS subtotal, SUM(d2) as v1, SUM(c2) as v2, (SUM(d1-c1)+SUM(d2)-SUM(c2)) AS total FROM ( "


                For i = 0 To Val(p)

                    If i < 10 Then
                        pe = "0" & i
                    Else
                        pe = i
                    End If

                    If pe < Val(1) Then
                        sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, d.debito AS d1, d.credito AS c1, 0 AS d2, 0 AS c2 " _
                          & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                          & " from selpuc s, documentos" & pe & " d , terceros t WHERE (d.nit = t.nit) AND  d.`codigo`= s.`codigo`    UNION "
                    Else
                        If pe <> Val(p) Then
                            sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, 0 AS d1, 0 AS c1, d.debito AS d2, d.credito AS c2 " _
                             & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                             & " from selpuc s, documentos" & pe & " d , terceros t WHERE (d.nit = t.nit) AND d.`codigo`= s.`codigo`   UNION    "
                        Else
                            sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, 0 AS d1, 0 AS c1, d.debito AS d2, d.credito AS c2 " _
                            & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                            & " from selpuc s, documentos" & pe & " d , terceros t WHERE (d.nit = t.nit) AND d.`codigo`= s.`codigo`    "
                        End If
                    End If
                Next

                sql = sql & " ) as cons GROUP BY nit,codigo ORDER by  codigo,nombre "
              

                TextBox1.Text = sql

                Dim tablaT As DataTable
                tablaT = New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)

                Dim CrReportt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReportt = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                CrReportt.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContBalPruT.rpt")
                CrReportt.SetDataSource(tablaT)
                CrReportt.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportContBalPruT.CrystalReportViewer1.ReportSource = CrReportt

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nitp.ToString)

                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    Prtt.Name = "tit"
                    Prtt.CurrentValues.AddValue(tit.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(Prtt)

                    FrmReportContBalPruT.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportContBalPruT.ShowDialog()

                Catch ex As Exception
                End Try
            End If
            conexion.Close()
            Cerrar()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sql As String = ""
        Dim nom As String = ""
        Dim nitp As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim pA As String = ""
        Dim tit As String = ""

        p = PerActual(0) & PerActual(1)

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nitp = "NIT: " & tabla2.Rows(0).Item("nit")
        per = PerActual


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        If chter.Checked = False Then

            If rbc1.Checked = True Then
                tit = "INVENTARIO Y BALANCE DE TODAS LAS CUENTAS"
            Else
                tit = "INVENTARIO Y BALANCE - CUENTAS CON SALDO "
            End If

            sql = " SELECT s.codigo ,s.descripcion , sum(c.saldo" & p & ") as saldo, if ( sum(c.saldo" & p & ") =0, 'Y','N') as nivel " _
                & " FROM (SELECT codigo,  saldo" & p & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
                & " on (c.codigo LIKE CONCAT(s.codigo,'%')) WHERE s.codigo BETWEEN '1' AND '4' group by s.codigo "

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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportInvBalanc.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportInvBalanc.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtt As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtt.Name = "tit"
                Prtt.CurrentValues.AddValue(tit.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtt)

                FrmReportInvBalanc.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportInvBalanc.ShowDialog()

            Catch ex As Exception
            End Try

        End If

        ' -------------- DETALLADO POR TECEROS 
        If chter.Checked = True Then

            tit = "INVENTARIOS Y BALANCES"
            Dim pe As String = ""

            sql = " SELECT codigo as nitc, descripcion as observ, nit as nitv, nombre as descrip, SUM(salAn) as subtotal, SUM(debito) as v1, SUM(credito) as v2, SUM(salAc) as total FROM ( "

            For i = 0 To Val(p)

                If i < 10 Then
                    pe = "0" & i
                Else
                    pe = i
                End If

                If pe < Val(p) Then
                    sql = sql & " SELECT d.codigo, s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre, (d.debito-d.credito) as salAn, '' as debito, '' as credito,  (d.debito-d.credito) as salAc " _
                    & " from selpuc s, documentos" & pe & " d LEFT JOIN terceros t ON (d.nit = t.nit) where  s.codigo = d.codigo  UNION  "
                End If

                If pe >= Val(p) And pe < Val(p) Then
                    sql = sql & " SELECT d.codigo, s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre , '' as salAn,  sum(debito) AS debito, sum(credito) AS credito,  (d.debito-d.credito) as salAc " _
                    & " from selpuc s, documentos" & pe & " d LEFT JOIN terceros t ON (d.nit = t.nit) where  s.codigo = d.codigo  GROUP by nit, codigo UNION "
                End If

                If pe = Val(p) Then
                    sql = sql & " SELECT d.codigo, s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre , '' as salAn,  sum(debito) AS debito, sum(credito) AS credito,  (d.debito-d.credito) as salAc " _
                   & " from selpuc s, documentos" & pe & " d LEFT JOIN terceros t ON (d.nit = t.nit) where  s.codigo = d.codigo  "
                End If
            Next

            sql = sql & " GROUP by nit, codigo ORDER by codigo, nombre) as cons GROUP BY codigo, nit ORDER by codigo, nombre "


            TextBox1.Text = sql

            Dim tablaT As DataTable
            tablaT = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaT)

            Dim CrReportt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReportt = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReportt.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContBalPruT.rpt")
            CrReportt.SetDataSource(tablaT)
            FrmReportContBalPruT.CrystalReportViewer1.ReportSource = CrReportt

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtt As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtt.Name = "tit"
                Prtt.CurrentValues.AddValue(tit.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtt)

                FrmReportContBalPruT.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportContBalPruT.ShowDialog()

            Catch ex As Exception
            End Try


        End If

        conexion.Close()

    End Sub
End Class