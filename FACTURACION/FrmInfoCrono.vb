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

Public Class FrmInfoCrono

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoCrono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ' Dim Cuenta, num, cad, cad2 As String
        Dim i, k, pag, no As Integer
        Dim sumavalor, sumaiva, sumasub As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, t1, t2, tp, cad, cad1, cad2, consulta, consulta2 As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        Refresh()
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME DE FACTURACION CRONOLOGICO"
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
        cb.ShowTextAligned(50, "SUBTOTAL", 260, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 320, k, 0)
        cb.ShowTextAligned(50, "DESCUENTO", 320, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 400, k, 0)
        cb.ShowTextAligned(50, "IVA", 400, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 460, k, 0)
        cb.ShowTextAligned(50, "RETENCION", 460, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 530, k, 0)
        cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
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
            t2 = bda & ".detafac" & adicionar(i)
            If consulta = "" Then
                consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha,terceros.nombre,terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=terceros.nit where 1 "

                If d1.Checked = True Then
                    consulta = consulta & " and " & t1 & ".estado='AP'"

                ElseIf d2.Checked = True Then
                    consulta = consulta & " and " & t1 & ".estado=''"
                ElseIf d3.Checked = True Then
                    consulta = consulta & " and " & t1 & ".descri<>''"
                Else

                End If

                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))"

            Else
                consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha,terceros.nombre,terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM terceros inner join " & t1 & " on " & t1 & ".nitc=terceros.nit where 1 "

                If d1.Checked = True Then
                    consulta2 = consulta2 & " and " & t1 & ".estado='AP'"
                Else
                    If d2.Checked = True Then
                        consulta2 = consulta2 & " and " & t1 & ".estado=''"
                    Else
                        If d3.Checked = True Then
                            consulta2 = consulta2 & " and " & t1 & ".descri<>''"
                        End If
                    End If
                End If

                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))"

                consulta = consulta & " UNION " & consulta2
            End If
        Next
        'MsgBox(consulta)


        cb.EndText()


        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        myCommand.CommandText = consulta & " ORDER BY tipodoc,num;"
        tabla.Clear()
        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        For i = 0 To tabla.Rows.Count - 1
            If tp <> tabla.Rows(i).Item("tipodoc").ToString Then
                tabla1.Clear()
                tabla1 = New DataTable
                myCommand.CommandText = "select * from tipdoc where tipodoc='" & tabla.Rows(i).Item("tipodoc").ToString & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla1)
                cb.EndText()
                k = k - 5
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString, 20, k, 0)
                cb.ShowTextAligned(50, tabla1.Rows(0).Item("descripcion"), 60, k, 0)
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
            If Len(cad) > 18 Then
                no = 2
                cad1 = CambiaCadena(cad, 18)
                cad2 = extraer_cadena(cad, 18, Len(cad))
            End If

            If no = 2 Then
                cb.ShowTextAligned(50, cad1, 150, k, 0)
                cb.ShowTextAligned(50, cad2, 150, k - 10, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec"), 90, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 310, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 370, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 430, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 570, k, 0)
                k = k - 10
            Else
                cb.ShowTextAligned(50, cad, 150, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec"), 90, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 310, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 370, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 430, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 570, k, 0)
            End If


            tp = tabla.Rows(i).Item("tipodoc").ToString
            sumaiva = sumaiva + CDbl(tabla.Rows(i).Item("iva").ToString)
            sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
            sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("valor").ToString))
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
                cb.ShowTextAligned(50, "SUBTOTAL", 260, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 320, k, 0)
                cb.ShowTextAligned(50, "DESCUENTO", 320, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 400, k, 0)
                cb.ShowTextAligned(50, "IVA", 400, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 460, k, 0)
                cb.ShowTextAligned(50, "RETENCION", 460, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
                k = k - 30
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If
        Next
        k = k - 10
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "TOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 310, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), 430, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 570, k, 0)
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

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'Try
        '////////////////////////
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME CRONOLOGICO ", "", "", "")
        End If

        mostrar_pdf2()
        '   Catch ex As Exception
        '  End Try

    End Sub

    Private Sub mostrar_pdf2()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim tit As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text


        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

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


        Dim td As String = ""
      
        tit = "INFORME DE FACTURACION / DOCUMENTOS "


        If d1.Checked = True Then '  DOC apr
            td = " AND f.estado= 'AP'"
            tit = tit & " APROBADOS"
        ElseIf d2.Checked = True Then '  DOC pend
            td = " AND f.estado= ''"
            tit = tit & " PENDIENTES"
        ElseIf d3.Checked = True Then '  DOC anul
            td = " AND LEFT(f.descrip,7)='ANULADO' "
            tit = tit & " ANULADOS"
        End If


        sql = sql & " SELECT  c.fecha, cta_iva,  c.fecha_o, c.doc, c.ciu_ent, c.doc_afec, c.num, c.fecha_o as tipodoc,  c.subtotal, c.descuento, c.iva, c.ret_f, c.total FROM ( "

        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = sql & " Select f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, f.fecha, f.doc_afec,  df.cantidad AS num, " _
                   & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                   & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & td & "  AND ( f.doc = df.doc ) "
            Else
                If p = cbini.Text Then
                    sql = sql & " Select f.tipodoc, f.doc,f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, f.fecha ,  f.doc_afec,  df.cantidad AS num, " _
                     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                    & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND right(f.fecha,2) >= '" & txtdi1.Text & "'  " & td & "  AND ( f.doc = df.doc ) "
                ElseIf p = cbini.Text <> p = cbfin.Text Then
                    sql = sql & " UNION SELECT f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent,  f.fecha ,  f.doc_afec, df.cantidad AS num, " _
                     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                    & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND ( f.doc = df.doc )  " & td & "  "
                ElseIf p = cbfin.Text Then
                    sql = sql & " UNION SELECT f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent,  f.fecha ,  f.doc_afec, df.cantidad AS num, " _
                     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                     & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM  detafac" & p & " df, facturas" & p & " f, terceros t WHERE f.nitc = t.nit and  right(f.fecha,2) <= '" & txtdi2.Text & "'  " & td & "  AND ( f.doc = df.doc ) "
                End If
            End If

        Next

        sql = sql & ") as c ORDER BY fecha ASC, cta_iva "
        '  TextBox1.Text = sql
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFCon.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportFacCon.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrdA As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtitulo.Name = "titulo"
            Prtitulo.CurrentValues.AddValue(tit.ToString)

            PrdA.Name = "doc_aj"
            PrdA.CurrentValues.AddValue(doc_aj.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtitulo)
            prmdatos.Add(PrdA)

            FrmReportFacCon.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacCon.ShowDialog()

        Catch ex As Exception
            ' MsgBox(sql)
        End Try

    End Sub
End Class