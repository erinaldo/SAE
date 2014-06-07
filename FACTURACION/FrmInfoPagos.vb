Imports iTextSharp.text
Imports iTextSharp.text.pdf
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

Public Class FrmInfoPagos

    Private Sub FrmInfoPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d5.CheckedChanged

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub


    Public Function extraer_cadena(ByVal cadena As String, ByVal ti As Integer, ByVal tf As Integer)
        Dim cad As String
        If cadena.Length > 18 Then
            cad = ""
            For j = ti To tf - 1
                cad = cad & cadena(j)
            Next
        Else
            cad = cadena
        End If
        Return cad
    End Function

    Public Function extraer_cadena2(ByVal cadena As String, ByVal ti As Integer, ByVal tf As Integer)
        Dim cad As String
        If cadena.Length >= 7 Then
            cad = ""
            For j = ti To tf - 1
                cad = cad & cadena(j)
            Next
        Else
            cad = cadena
        End If
        Return cad
    End Function

    Public Function adicionar(ByVal texto As String)
        Dim num As String
        If Len(texto) = 1 Then
            num = "0" & texto
        Else
            num = texto
        End If
        Return num
    End Function

    Public Sub mostrar_pdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim i, k, pag, no As Integer
        Dim sumavalor, sumaiva, sum1, sum2 As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, t1, t2, tp, cad, cad1, cad2, consulta, consulta2 As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
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
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME DE FACTURACION POR MEDIOS DE PAGOS"
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
        k = 700
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        cb.ShowTextAligned(50, "Nro", 20, k, 0)
        cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
        cb.ShowTextAligned(50, "FECHA", 55, k - 8, 0)
        cb.ShowTextAligned(50, "DOCTO ", 90, k, 0)
        cb.ShowTextAligned(50, "AFECTADO", 90, k - 8, 0)
        cb.ShowTextAligned(50, "CLIENTE", 150, k - 8, 0)
        cb.ShowTextAligned(50, "  VALOR", 320, k, 0)
        cb.ShowTextAligned(50, "FACTURADO", 320, k - 8, 0)
        cb.ShowTextAligned(50, "  VALOR", 450, k, 0)
        cb.ShowTextAligned(50, "PAGADO", 450, k - 8, 0)
        cb.ShowTextAligned(50, "FORMA DE PAGO", 490, k, 0)
        k = k - 30
        t1 = ""
        t2 = ""
        cad1 = ""
        cad2 = ""
        'If adicionar(fec2.Value.Month.ToString) & "/" & adicionar(fec2.Value.Year.ToString) > PerActual Then
        '    MsgBox("La fecha final no se encuentra dentro de ningun periodo activo")
        '    Exit Sub
        'End If
        'per2 = adicionar(fec2.Value.Month.ToString)
        'per1 = adicionar(fec2.Value.Month.ToString)
        'For i = 1 To cdbl(per2)

        'Next
        If CDbl(cbini.Text) > CDbl(cbfin.Text) Then
            MsgBox("La fecha inicial no debe ser mayor que la final")
            Exit Sub
        End If

        'If cdbl(cbfin.Text) > CambiaCadena(PerActual, 2) Then
        'MsgBox("Periodo no esta en uso")
        'Exit Sub
        'End If
        consulta = ""
        consulta2 = ""
        For i = CDbl(cbini.Text) To CDbl(cbfin.Text)
            t1 = bda & ".facturas" & adicionar(i)
            t2 = bda & ".facpagos" & adicionar(i)
            If consulta = "" Then
                consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha,terceros.nombre,terceros.apellidos," & t1 & ".doc_afec," & t1 & ".total," & t2 & ".valor," & t2 & ".tipo FROM terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=terceros.nit where 1 "

                If d1.Checked = True Then
                    consulta = consulta & " and " & t2 & ".tipo='Efectivo'"
                Else
                    If d2.Checked = True Then
                        consulta = consulta & " and " & t2 & ".tipo='Cheque'"
                    Else
                        If d3.Checked = True Then
                            consulta = consulta & " and " & t2 & ".tipo='Tarjeta'"
                        Else
                            If d4.Checked = True Then
                                consulta = consulta & " and " & t2 & ".tipo='Otros'"
                            End If
                        End If
                    End If
                End If

                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))"

            Else
                consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha,terceros.nombre,terceros.apellidos," & t1 & ".doc_afec," & t1 & ".total," & t2 & ".valor," & t2 & ".tipo FROM terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=terceros.nit where 1 "

                If d1.Checked = True Then
                    consulta2 = consulta2 & " and " & t2 & ".tipo='Efectivo'"
                Else
                    If d2.Checked = True Then
                        consulta2 = consulta2 & " and " & t2 & ".tipo='Cheque'"
                    Else
                        If d3.Checked = True Then
                            consulta2 = consulta2 & " and " & t2 & ".tipo='Tarjeta'"
                        Else
                            If d4.Checked = True Then
                                consulta2 = consulta2 & " and " & t2 & ".tipo='Otros'"
                            End If
                        End If
                    End If
                End If

                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))"

                consulta = consulta & " UNION " & consulta2
            End If
        Next


        cb.EndText()


        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        myCommand.CommandText = consulta & " ORDER BY tipo,tipodoc,num;"

        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        For i = 0 To tabla.Rows.Count - 1
            If tp <> tabla.Rows(i).Item("tipo").ToString Then
                If tp <> "" Then
                    cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 370, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum2), 480, k, 0)
                    sum1 = 0
                    sum2 = 0
                    k = k - 10

                End If

                cb.EndText()
                k = k - 5
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, "Tipo de Pago:  " & tabla.Rows(i).Item("tipo").ToString, 20, k, 0)
                'cb.ShowTextAligned(50, "Tipo de Pago:  " & tp, 20, k, 0)
                k = k - 10
            End If
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            cb.BeginText()
            cb.ShowTextAligned(50, NumeroDoc(CDbl(tabla.Rows(i).Item("num").ToString)), 20, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 55, k, 0)
            cb.ShowTextAligned(50, "", 120, k, 0)
            cad = Trim(tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString)
            no = 1
            If Len(cad) > 30 Then
                no = 2
                cad1 = CambiaCadena(cad, 30)
                cad2 = extraer_cadena(cad, 30, Len(cad))
            End If

            If no = 2 Then
                cb.ShowTextAligned(50, cad1, 150, k, 0)
                cb.ShowTextAligned(50, cad2, 150, k - 10, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec"), 90, k - 10, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("valor").ToString)), 370, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("Valor").ToString)), 480, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipo").ToString, 490, k, 0)
                k = k - 10
            Else
                cb.ShowTextAligned(50, cad, 150, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec"), 90, k - 10, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("valor").ToString)), 370, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("valor").ToString)), 480, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipo").ToString, 490, k, 0)
            End If

            If tabla.Rows(i).Item("tipo").ToString = "Efectivo" Then
                tp = tabla.Rows(i).Item("tipo").ToString
            Else
                If tabla.Rows(i).Item("tipo").ToString = "Cheque" Then
                    tp = tabla.Rows(i).Item("tipo").ToString
                Else
                    If tabla.Rows(i).Item("tipo").ToString = "Tarjeta" Then

                        tp = tabla.Rows(i).Item("tipo").ToString
                    Else
                        tp = "Otros"
                    End If

                End If
            End If
            sumaiva = sumaiva + CDbl(tabla.Rows(i).Item("valor").ToString)
            sum1 = sum1 + CDbl(tabla.Rows(i).Item("valor").ToString)
            sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("valor").ToString))
            sum2 = sum2 + CDbl(CDbl(tabla.Rows(i).Item("valor").ToString))
            k = k - 10
            If k <= 80 Then
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                Refresh()
                myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                cb.ShowTextAligned(50, tabla2.Rows(0).Item("descripcion"), 20, 810, 0)
                cb.ShowTextAligned(50, "N.I.T. " & tabla2.Rows(0).Item("nit"), 20, 800, 0)
                cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)

                k = 700
                cb.ShowTextAligned(50, "Nro", 20, k, 0)
                cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
                cb.ShowTextAligned(50, "FECHA", 55, k - 8, 0)
                cb.ShowTextAligned(50, "DOCTO ", 90, k, 0)
                cb.ShowTextAligned(50, "AFECTADO", 90, k - 8, 0)
                cb.ShowTextAligned(50, "CLIENTE", 150, k - 8, 0)
                cb.ShowTextAligned(50, "  VALOR", 320, k, 0)
                cb.ShowTextAligned(50, "FACTURADO", 320, k - 8, 0)
                cb.ShowTextAligned(50, "  VALOR", 420, k, 0)
                cb.ShowTextAligned(50, "PAGADO", 420, k - 8, 0)
                cb.ShowTextAligned(50, "FORMA DE PAGO", 490, k, 0)
                k = k - 30
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If
        Next
        If tabla.Rows.Count <> 0 Then
            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 370, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum2), 480, k, 0)
        End If
        
        k = k - 10
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        cb.ShowTextAligned(50, "TOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), 370, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 480, k, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()

        Try
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try


    End Sub

    Private Sub mostrar_pdf2()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim p As String = ""
        Dim j As String = ""
        Dim cant As String = ""
        Dim per As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text

        Dim doc_aj As String = ""
        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim pg As String = ""
        If d1.Checked = True Then
            pg = " AND fp.tipo = 'Efectivo'"
        ElseIf d2.Checked = True Then
            pg = " AND fp.tipo = 'Cheque' "
        ElseIf d3.Checked = True Then
            pg = " AND fp.tipo = 'Tarjeta' "
        ElseIf d4.Checked = True Then
            pg = " AND  fp.tipo = 'Otra' "
        End If



        For i = Val(cbini.Text) To Val(cbfin.Text)

            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = " SELECT f.fecha, f.doc as doc, t.nombre AS tt,  " _
                 & " CONCAT( CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ),'   ', f.doc_afec) AS banco, " _
                 & "  fp.tipo, fp.descrip, f.total as numero, fp.valor " _
                   & " FROM facpagos" & p & " fp, facturas" & p & " f , terceros t WHERE (t.nit = f.nitc) " _
                   & " AND (f.doc = fp.doc)  " & pg & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' and  '" & txtdi2.Text & "' "
            Else
                If p = cbini.Text Then
                    sql = " SELECT f.fecha, f.doc as doc, t.nombre AS tt,  " _
                 & " CONCAT( CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ),'   ', f.doc_afec) AS banco, " _
                & "  fp.tipo, fp.descrip, f.total as numero, fp.valor " _
                    & " FROM facpagos" & p & " fp, facturas" & p & " f , terceros t WHERE(t.nit = f.nitc) " _
                    & " AND (f.doc = fp.doc)  " & pg & " AND right(f.fecha,2)>= '" & txtdi1.Text & "'"

                ElseIf p <> cbini.Text And p <> cbfin.Text Then
                    sql = sql & " UNION SELECT f.fecha, f.doc as doc, t.nombre AS tt, " _
                     & " CONCAT( CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ),'   ', f.doc_afec) AS banco, " _
                    & "  fp.tipo, fp.descrip, f.total as numero, fp.valor " _
                   & " FROM facpagos" & p & " fp ,facturas" & p & " f, terceros t WHERE (t.nit = f.nitc)  AND (f.doc = fp.doc)" & pg & " "

                ElseIf p = cbfin.Text Then
                    sql = sql & " UNION SELECT f.fecha, f.doc as doc, t.nombre AS tt,  " _
                    & " CONCAT( CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ),'   ', f.doc_afec) AS banco, " _
                    & "  fp.tipo, fp.descrip, f.total as numero, fp.valor " _
                     & " FROM facpagos" & p & " fp, facturas" & p & " f , terceros t WHERE(t.nit = f.nitc) " _
                    & " and (f.doc = fp.doc)" & pg & " AND right(f.fecha,2)<= '" & txtdi2.Text & "'"

                End If
            End If

        Next

        sql = sql & " ORDER BY fecha "
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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFPago.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        FrmReportFacPag.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim PrdA As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            PrdA.Name = "doc_aj"
            PrdA.CurrentValues.AddValue(doc_aj.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(PrdA)

            FrmReportFacPag.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacPag.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        ' mostrar_pdf()
        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR FORMA DE PAGO ", "", "", "")
            End If
            mostrar_pdf2()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
End Class