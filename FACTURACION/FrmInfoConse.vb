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

Public Class Frminfoconse

    Private Sub Frminfoconse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.CommandText = "select * from bodegas;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            codbod.Maximum = tabla.Rows.Count
        Catch ex As Exception
        End Try
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

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub

    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmLisDocumen.ShowDialog()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub mostrar_pdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim i, k, pag, no, c As Integer
        Dim sumavalor, sumaiva, sumasub As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, t1, t2, t3, tp, cad, cad1, cad2, consulta, consulta2, final As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        c = 0
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
        cadena = "INFORME DE FACTURACION EN ORDEN CONSECUTIVO"
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
        cb.ShowTextAligned(50, "VALOR", 410, k, 0)
        cb.ShowTextAligned(50, "IVA", 410, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 470, k, 0)
        cb.ShowTextAligned(50, "RETENCION", 470, k - 8, 0)
        cb.ShowTextAligned(50, "VALOR", 530, k, 0)
        cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
        k = k - 30
        t1 = ""
        t2 = ""
        
        If CDbl(cbini.Text) > CDbl(cbfin.Text) Then
            MsgBox("La fecha inicial no debe ser mayor que la final")
            Exit Sub
        End If

        'If cdbl(cbfin.Text) > CambiaCadena(PerActual, 2) Then
        'MsgBox("Periodo no esta en uso")
        'Exit Sub
        'End If
        cad1 = ""
        cad2 = ""
        consulta = ""
        consulta2 = ""
        final = " GROUP BY tipodoc,num"
        For i = CDbl(cbini.Text) To CDbl(cbfin.Text)
            t1 = bda & ".facturas" & adicionar(i)
            t2 = bda & ".detafac" & adicionar(i)
            t3 = bda

            If consulta = "" Then
                consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec,SUM(" & t2 & ".valor) as subtotal," & t1 & ".descuento ," & t1 & ".iva," & t1 & ".ret_iva,SUM(" & t2 & ".vtotal) as total  FROM " & t3 & ".terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "

                If i1.Checked = True Then
                    c = 1
                    If txtnombod.Text <> "" Then
                        consulta = consulta & " and " & t2 & ".numbod='" & codbod.Value.ToString & "'"
                    Else
                        MsgBox("Por favor digite una bodega valida")
                    End If
                Else
                    consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                End If
                If c2.Checked = True Then
                    If txtnom.Text <> "" Then
                        consulta = consulta & "and " & t1 & ".tipodoc='" & txttip.Text & "'"
                    Else
                        MsgBox("Digite un documento valido para realizar el informe")
                        Exit Sub
                    End If
                End If

                If d1.Checked = True Then
                    consulta = consulta & " and " & t1 & ".estado='AP'"
                Else
                    If d2.Checked = True Then
                        consulta = consulta & " and " & t1 & ".estado=''"
                    Else
                        If d3.Checked = True Then
                            consulta = consulta & " and " & t1 & ".descri<>''"
                        End If
                    End If
                End If

                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))"
                If c = 1 Then
                    consulta = consulta & final
                End If

            Else
                consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                If i1.Checked = True Then
                    c = 1
                    If txtnombod.Text <> "" Then
                        consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                        consulta2 = consulta2 & " and " & t2 & ".numbod='" & codbod.Value.ToString & "'"
                    Else
                        MsgBox("Por favor digite una bodega valida")
                    End If
                Else
                    consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha,terceros.nombre,terceros.apellidos," & t1 & ".doc_afec," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM terceros inner join " & t1 & " on " & t1 & ".nitc=terceros.nit where 1 "
                End If
                If c2.Checked = True Then
                    If txtnom.Text <> "" Then
                        consulta2 = consulta2 & "and " & t1 & ".tipodoc='" & txttip.Text & "'"
                    Else
                        MsgBox("Digite un documento valido para realizar el informe")
                        Exit Sub
                    End If
                End If

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

                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "')) "
                If c = 1 Then
                    consulta2 = consulta2 & final
                End If

                consulta = consulta & " UNION " & consulta2
            End If
        Next

        cb.EndText()

        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        '        myCommand.CommandText = consulta & " ORDER BY tipodoc,num;"
        If c <> 1 Then
            ' consulta = consulta & " GROUP BY " & t1 & ".tipodoc," & t1 & ".num ORDER BY tipodoc,num;"
            consulta = consulta & " ORDER BY tipodoc,num;"
        End If
        myCommand.CommandText = consulta
        myAdapter.SelectCommand = myCommand
        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        For i = 0 To tabla.Rows.Count - 1
            If tp <> tabla.Rows(i).Item("tipodoc").ToString Then
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
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 450, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 510, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 570, k, 0)
                k = k - 10
            Else
                cb.ShowTextAligned(50, cad, 150, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec"), 90, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 310, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 370, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 450, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 510, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 570, k, 0)
            End If


            tp = tabla.Rows(i).Item("tipodoc").ToString
            sumaiva = sumaiva + CDbl(tabla.Rows(i).Item("iva").ToString)
            sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
            sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
            k = k - 10
            If k <= 80 Then
                cb.EndText()
                oDoc.NewPage()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                Refresh()
                tabla2.Clear()
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
                cb.ShowTextAligned(50, "VALOR", 410, k, 0)
                cb.ShowTextAligned(50, "IVA", 410, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 470, k, 0)
                cb.ShowTextAligned(50, "RETENCION", 470, k - 8, 0)
                cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
                k = k - 30
                pag = pag + 1
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If
        Next
        k = k - 10
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "SUBTOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 310, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), 450, k, 0)
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


    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_pdf()
        'Me.Close()

        '////////////////////////
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR CONSECUTIVO ", "", "", "")
        End If

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

        Dim d As String = ""
        Dim td As String = ""
        Dim bg As String = ""

        tit = "INFORME DE FACTURACION / "


        If c2.Checked = True Then ' UN DOC
            d = " AND f.tipodoc= '" & txttip.Text & "' "
            tit = tit & " DOC " & txttip.Text
        Else
            tit = tit & " DOCUMENTOS " & d
        End If

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

        If i1.Checked = True Then ' bodegas
            bg = " AND df.numbod = '" & codbod.Text & "'"
            tit = tit & " - BODEGA N° " & codbod.Text
        End If


        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            '& " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
            '      & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
            '      & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
            '      & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
            '       & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _


            If cbini.Text = cbfin.Text Then
                sql = " Select f.tipodoc, f.doc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha_o,  f.doc_afec,  df.cantidad AS num, f.hora as cta_iva, " _
                    & " ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100))) AS subtotal, f.fecha, f.hora, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* (f.por_desc /100)) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * 0/100))) * df.iva_d/100) as iva, " _
                   & " ((((df.vtotal-(df.vtotal*(df.por_des/100)))/ (1+(df.iva_d/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))*(f.por_desc/100)))* (f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit and  right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & d & " " & td & " " & bg & " AND ( f.doc = df.doc ) "
            Else
                If p = cbini.Text Then
                    sql = " Select f.tipodoc, f.doc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha_o,  f.doc_afec,  df.cantidad AS num, f.hora as cta_iva, " _
                     & " ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100))) AS subtotal,f.fecha, f.hora, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* (f.por_desc /100)) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * 0/100))) * df.iva_d/100) as iva, " _
                   & " ((((df.vtotal-(df.vtotal*(df.por_des/100)))/ (1+(df.iva_d/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))*(f.por_desc/100)))* (f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit and right(f.fecha,2) >= '" & txtdi1.Text & "' " & d & " " & td & " " & bg & " AND ( f.doc = df.doc ) "
                ElseIf p = cbini.Text <> p = cbfin.Text Then
                    sql = sql & " UNION SELECT f.tipodoc, f.doc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha_o,  f.doc_afec,  " _
                   & " df.cantidad AS num, f.hora as cta_iva, " _
                     & " ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100))) AS subtotal,f.fecha, f.hora, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* (f.por_desc /100)) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * 0/100))) * df.iva_d/100) as iva, " _
                   & " ((((df.vtotal-(df.vtotal*(df.por_des/100)))/ (1+(df.iva_d/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))*(f.por_desc/100)))* (f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM  detafac" & p & " df, facturas" & p & " f ,terceros t WHERE f.nitc = t.nit AND ( f.doc = df.doc ) " & d & " " & td & " " & bg & " "
                ElseIf p = cbfin.Text Then
                    sql = sql & " UNION SELECT f.tipodoc, f.doc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha_o,  f.doc_afec, " _
                    & " df.cantidad AS num, f.hora as cta_iva, " _
                      & " ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100))) AS subtotal, f.fecha, f.hora, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* (f.por_desc /100)) AS descuento, " _
                   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * 0/100))) * df.iva_d/100) as iva, " _
                   & " ((((df.vtotal-(df.vtotal*(df.por_des/100)))/ (1+(df.iva_d/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))*(f.por_desc/100)))* (f.por_ret_f/100)) AS ret_f, " _
                    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                   & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND right(f.fecha,2) <= '" & txtdi2.Text & "' " & d & " " & td & " " & bg & " AND ( f.doc = df.doc ) "
                End If
            End If
          
        Next
        sql = sql & " ORDER BY fecha ,hora "

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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFCon.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
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

    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "select * from tipdoc where tipodoc='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtnom.Text = tabla.Rows(0).Item("descripcion")
        Else
            txtnom.Text = ""
        End If
    End Sub

    Private Sub codbod_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codbod.ValueChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & bda & ".bodegas where numbod='" & codbod.Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <> 0 Then
                txtnombod.Text = tabla.Rows(0).Item("nombod")
            Else
                MsgBox("No existen bodegas", , "Verificando...")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function adicionar(ByVal texto As String)
        Dim num As String
        If Len(texto) = 1 Then
            num = "0" & texto
        Else
            num = texto
        End If
        Return num
    End Function

    Private Sub dia1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdi1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtdi1, e)
        End If
    End Sub

    Private Sub dia2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdi2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtdi1, e)
        End If
    End Sub

    Private Sub dia1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If CDbl(txtdi1.Text) > 31 Then
            txtdi1.Text = 31
        End If
    End Sub

    Private Sub dia2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi2.LostFocus
        If CDbl(txtdi2.Text) > 31 Then
            txtdi2.Text = 31
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub cbfin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbfin.SelectedIndexChanged

    End Sub
End Class