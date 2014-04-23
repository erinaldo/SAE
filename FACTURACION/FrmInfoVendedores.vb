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

Public Class FrmInfoVendedores

    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txttip_LostFocus(AcceptButton, AcceptButton)
        Else
            ValidarNIT(txttip, e)
        End If
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus

        Dim t As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".vendedores WHERE nitv='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count = 0 Then
            txtnom.Clear()
            cargarvendedor()
        Else
            txtnom.Text = t.Rows(0).Item("nombre").ToString()
        End If

    End Sub
    Private Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = "inf_vend"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".vendedores WHERE nitv='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            txtnom.Clear()
        Else
            txtnom.Text = tabla.Rows(0).Item("nombre").ToString()
        End If
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnom.Enabled = False
            txttip.Enabled = False
        Else
            txtnom.Enabled = True
            txttip.Enabled = True
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoVendedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Public Function adicionar(ByVal texto As String)
        Dim num As String
        If Len(texto) = 1 Then
            num = "0" & texto
        Else
            num = texto
        End If
        Return num
    End Function

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

    Public Sub mostrar_pdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim i, k, pag, no, c, col As Integer
        Dim sumavalor, sumaiva, sumasub, sumavalor1, sumaiva1, sumasub1, iva As Double
        Dim tabla, tabla1, tabla2, tabla3 As New DataTable
        Dim cadena, t1, t2, t3, t4, mart, tp, cad1, cad2, cad3, consulta, consulta2 As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        c = 0
        col = 0
        iva = 0
        cad2 = ""
        cad1 = ""
        cad3 = ""
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
        cadena = "INFORME DE FACTURACION POR VENDEDORES"
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
        k = 700
        no = 0
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        If d1.Checked = True Then
            cb.ShowTextAligned(50, "Nro", 20, k, 0)
            cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
            cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
            cb.ShowTextAligned(50, "CLIENTE", 120, k - 8, 0)
            cb.ShowTextAligned(50, "ARTICULO\SERVICIO", 220, k - 8, 0)
            cb.ShowTextAligned(50, "TOTAL NETO", 360, k, 0)
            cb.ShowTextAligned(50, "FACTURADO", 360, k - 8, 0)
            cb.ShowTextAligned(50, "CONCEPTO", 440, k, 0)
            cb.ShowTextAligned(50, "COMISION", 440, k - 8, 0)
            cb.ShowTextAligned(50, "%", 500, k, 0)
            cb.ShowTextAligned(50, "VALOR", 530, k, 0)
            cb.ShowTextAligned(50, "COMISION", 530, k - 8, 0)
            cad1 = " ORDER BY 10 DESC"
            col = 410

        Else
            cb.ShowTextAligned(50, "Nro", 20, k, 0)
            cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
            cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
            cb.ShowTextAligned(50, "FORMA DE PAGO", 120, k - 8, 0)
            'cb.ShowTextAligned(50, "ARTICULO\SERVICIO", 220, k - 8, 0)
            cb.ShowTextAligned(50, "TOTAL NETO", 260, k, 0)
            cb.ShowTextAligned(50, "FACTURADO", 260, k - 8, 0)
            cb.ShowTextAligned(50, "CONCEPTO", 340, k, 0)
            cb.ShowTextAligned(50, "COMISION", 340, k - 8, 0)
            cb.ShowTextAligned(50, "%", 400, k, 0)
            cb.ShowTextAligned(50, "VALOR", 430, k, 0)
            cb.ShowTextAligned(50, "COMISION", 430, k - 8, 0)
            cad1 = " ORDER BY 6 DESC"
            col = 310

        End If

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
        t4 = ""
        mart = ""
        'myCommand.CommandText = "SELECT " & bda & ".parafacgral.ivainclu FROM " & bda & ".parafacgral;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla2)
        'If tabla2.Rows.Count > 0 Then
        '    If tabla2.Rows(0).Item(0) = "SI" Then
        '        par = 1
        '    Else
        '        par = 0
        '    End If
        'End If
        consulta = ""
        consulta2 = ""
        For i = CDbl(cbini.Text) To CDbl(cbfin.Text)
            t1 = bda & ".facturas" & adicionar(i)
            t2 = bda & ".detafac" & adicionar(i)
            t3 = bda & ".facpagos" & adicionar(i)


            cad3 = ""
            If consulta = "" Then

                If d1.Checked = True Then
                    consulta = "SELECT DISTINCT (" & t1 & ".nitv)," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".tipo," & bda & ".terceros.apellidos," & bda & ".terceros.nombre," & t2 & ".nomart,MAX(" & t2 & ".vtotal) as valor," & bda & ".vendedores.nombre as vnombre," & t1 & ".nitv FROM " & t1 & " INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t1 & ".nitc INNER JOIN " & t3 & " ON " & t3 & ".doc=" & t1 & ".doc" & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & bda & ".vendedores ON " & bda & ".vendedores.nitv=" & t1 & ".nitv WHERE 1"
                    cad3 = "  GROUP BY num,nomart "
                Else
                    consulta = "SELECT DISTINCT (" & t1 & ".nitv)," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".tipo,MAX(" & t2 & ".vtotal) as vtotal," & bda & ".vendedores.nombre as vnombre," & t1 & ".nitv FROM " & t1 & " INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t1 & ".nitc INNER JOIN " & t3 & " ON " & t3 & ".doc=" & t1 & ".doc" & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & bda & ".vendedores ON " & bda & ".vendedores.nitv=" & t1 & ".nitv WHERE 1"
                    cad3 = "GROUP BY num,nomart "
                End If
                If c2.Checked = True Then
                    consulta = consulta & " AND " & t1 & ".nitv='" & txttip.Text & "'"
                End If
                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
            Else
                If d1.Checked = True Then
                    consulta2 = "SELECT DISTINCT (" & t1 & ".nitv)," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".tipo," & bda & ".terceros.apellidos," & bda & ".terceros.nombre," & t2 & ".nomart,MAX(" & t2 & ".vtotal) as valor," & bda & ".vendedores.nombre," & t1 & ".nitv FROM " & t1 & " INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t1 & ".nitc INNER JOIN " & t3 & " ON " & t3 & ".doc=" & t1 & ".doc" & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & bda & ".vendedores ON " & bda & ".vendedores.nitv=" & t1 & ".nitv WHERE 1"
                    cad3 = "  GROUP BY num,nomart "
                Else
                    consulta2 = "SELECT DISTINCT (" & t1 & ".nitv)," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".tipo,MAX(" & t2 & ".vtotal) as vtotal," & bda & ".vendedores.nombre as vnombre," & t1 & ".nitv FROM " & t1 & " INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t1 & ".nitc INNER JOIN " & t3 & " ON " & t3 & ".doc=" & t1 & ".doc" & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & bda & ".vendedores ON " & bda & ".vendedores.nitv=" & t1 & ".nitv WHERE 1"
                    cad3 = "  GROUP BY num,nomart "
                End If
                'consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                If c2.Checked = True Then
                    consulta2 = consulta2 & " AND " & t1 & ".nitv='" & txttip.Text & "'"
                End If
                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
                consulta = consulta & " UNION " & consulta2
            End If

        Next

        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        consulta = consulta & " " & cad1 & ";"
        myCommand.CommandText = consulta

        myAdapter.SelectCommand = myCommand
        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        For i = 0 To tabla.Rows.Count - 1
            If d1.Checked = True Then
                If tp <> tabla.Rows(i).Item("vnombre").ToString Then
                    If tp <> "" Then
                        cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 410, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 480, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 560, k, 0)
                        sumaiva1 = 0
                        sumavalor1 = 0
                        sumasub1 = 0
                        k = k - 10

                    End If

                    cb.EndText()
                    k = k - 5
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)

                    cb.BeginText()
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("vnombre").ToString & "           CODIGO: " & tabla.Rows(i).Item("nitv").ToString, 20, k, 0)
                    k = k - 10
                End If
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cad3 = Trim(tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString)
                If Len(cad3) > 21 Then
                    cad3 = CambiaCadena(cad3, 21)
                End If

                If mart = tabla.Rows(i).Item("num").ToString Then
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart").ToString, 21), 220, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("valor").ToString)), 410, k, 0)
                    'k = k - 7
                Else
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & " " & NumeroDoc(CDbl(tabla.Rows(i).Item("num").ToString)), 20, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 60, k, 0)
                    cb.ShowTextAligned(50, cad3, 100, k, 0)

                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart").ToString, 30), 220, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("valor").ToString)), 410, k, 0)
                    'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(tabla.Rows(i).Item("descuento").ToString)), 410, k, 0)

                End If


                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(tabla.Rows(i).Item("iva").ToString)), 480, k, 0)
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(iva)), 480, k, 0)
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(tabla.Rows(i).Item("total").ToString)), 560, k, 0)
                k = k - 10

                tp = tabla.Rows(i).Item("vnombre").ToString
                mart = tabla.Rows(i).Item("num").ToString

                sumaiva = sumaiva + Moneda(CDbl(tabla.Rows(i).Item("valor").ToString))
                'sumavalor = sumavalor + cdbl(cdbl(tabla.Rows(i).Item("total").ToString))
                'sumasub = sumasub + cdbl(cdbl(tabla.Rows(i).Item("subtotal").ToString))
                sumaiva1 = sumaiva1 + Moneda(CDbl(tabla.Rows(i).Item("valor").ToString))
                'sumavalor1 = sumavalor1 + cdbl(cdbl(tabla.Rows(i).Item("total").ToString))
                'sumasub1 = sumasub1 + cdbl(cdbl(tabla.Rows(i).Item("subtotal").ToString))
                'k = k - 8
            Else
                If tp <> tabla.Rows(i).Item("vnombre").ToString Then
                    If tp <> "" Then
                        cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 410, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 480, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 560, k, 0)
                        sumaiva1 = 0
                        sumavalor1 = 0
                        sumasub1 = 0
                        k = k - 10

                    End If

                    cb.EndText()
                    k = k - 5
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)

                    cb.BeginText()
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("vnombre").ToString & "           CODIGO: " & tabla.Rows(i).Item("nitv").ToString, 20, k, 0)
                    k = k - 10
                End If
                cb.EndText()

                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & " " & NumeroDoc(CDbl(tabla.Rows(i).Item("num").ToString)), 20, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 60, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipo").ToString, 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("vtotal").ToString)), 310, k, 0)
                sumaiva = sumaiva + Moneda(CDbl(tabla.Rows(i).Item("vtotal").ToString))
                sumaiva1 = sumaiva1 + Moneda(CDbl(tabla.Rows(i).Item("vtotal").ToString))
                k = k - 10
                tp = tabla.Rows(i).Item("vnombre").ToString


            End If
            If k <= 80 Then
                cb.EndText()
                oDoc.NewPage()
                k = 730
                pag = pag + 1
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                Refresh()
                cb.BeginText()
                myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla3)
                cb.ShowTextAligned(50, tabla3.Rows(0).Item("descripcion"), 20, 810, 0)
                cb.ShowTextAligned(50, "N.I.T. " & tabla3.Rows(0).Item("nit"), 20, 800, 0)
                cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
                k = 700
                If d1.Checked = True Then
                    cb.ShowTextAligned(50, "Nro", 20, k, 0)
                    cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
                    cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
                    cb.ShowTextAligned(50, "CLIENTE", 120, k - 8, 0)
                    cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 300, k, 0)
                    cb.ShowTextAligned(50, "UNITARIO", 300, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 370, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 370, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 450, k, 0)
                    cb.ShowTextAligned(50, "IVA", 450, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)

                Else
                    cb.ShowTextAligned(50, "PRODUCTO", 20, k, 0)
                    cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
                    cb.ShowTextAligned(50, " VALOR", 330, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 330, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 450, k, 0)
                    cb.ShowTextAligned(50, " IVA", 450, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)

                End If
                k = k - 30
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If

        Next
        If tabla.Rows.Count <> 0 And d1.Checked = True Then
            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub1), 330, k, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 480, k, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 560, k, 0)
            sumaiva1 = 0
            sumavalor1 = 0
            sumasub1 = 0
            k = k - 10
        End If


        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)

        cb.BeginText()
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        If d1.Checked = True Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 330, k, 0)
        Else
            If d2.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 380, k, 0)
            End If
        End If
        cb.ShowTextAligned(50, "TOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), col, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 560, k, 0)
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
    Private Sub PDF()
        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR VENDEDOR ", "", "", "")
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


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            MiConexion(bda)

            Dim doc_aj As String = ""
            Dim tb As New DataTable
            tb = New DataTable
            myCommand.CommandText = "SELECT tipoaj FROM parafacgral ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            doc_aj = tb.Rows(0).Item(0)

            Dim n As String = ""
            If c2.Checked = True Then
                n = " AND f.nitv = '" & txttip.Text & "'"
            End If

            If d1.Checked = True Then
                For i = Val(cbini.Text) To Val(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If cbini.Text = cbfin.Text Then
                        sql = " SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & " (SELECT  vc.porcomi  FROM concomi c, vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS por_desc, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f ,terceros t " _
                           & " WHERE t.nit = f.nitc and f.doc = df.doc  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'"
                    Else
                        If p = cbini.Text Then
                            sql = " SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                           & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) >= '" & txtdi1.Text & "'"
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f,terceros t " _
                           & "  WHERE t.nit = f.nitc and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) <= '" & txtdi2.Text & "'"
                        End If
                    End If

                Next

                sql = sql & " ORDER BY ciu_ent"
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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFVen.rpt")
                CrReport.SetDataSource(tabla)
                Try
                    CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                Catch ex As Exception
                End Try
                FrmReportFacVen.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrAJ As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nit.ToString)

                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    PrAJ.Name = "doc_aj"
                    PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                    Prtt.Name = "tit"
                    Prtt.CurrentValues.AddValue(" VENEDEDORES")

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrAJ)
                    prmdatos.Add(Prtt)
                    FrmReportFacVen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacVen.ShowDialog()

                Catch ex As Exception
                End Try
            Else

                sql = "SELECT  c.nitv, c.ciu_ent, c.cc, c.fecha_o, c.cta3, c.por_desc, SUM(c.ret_f) as ret_f, SUM(c.subtotal) as subtotal FROM ("
                For i = Val(cbini.Text) To Val(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If cbini.Text = cbfin.Text Then
                        sql = sql & " SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & " (SELECT  vc.porcomi  FROM concomi c, vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS por_desc, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS ret_f, " _
                            & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "   WHERE t.nit = f.nitc and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'"
                    Else
                        If p = cbini.Text Then
                            sql = sql & " SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) >= '" & txtdi1.Text & "'"
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , f.nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND f.nitv = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND f.nitv = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='" & doc_aj & "'   , " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = f.nitv " & n & " AND right(f.fecha,2) <= '" & txtdi2.Text & "'"
                        End If
                    End If

                Next

                sql = sql & ") as c GROUP BY nitv order by ciu_ent"

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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFVen2.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportFacVen2.CrystalReportViewer1.ReportSource = CrReport

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

                    FrmReportFacVen2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacVen2.ShowDialog()

                Catch ex As Exception
                End Try
            End If

            Cerrar()
        Catch ex As Exception
            MsgBox("Error al Generar el Informe, " & ex.ToString, MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub
    Private Sub PDF_ASESOR()
        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR VENDEDOR ", "", "", "")
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


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            MiConexion(bda)

            Dim doc_aj As String = ""
            Dim tb As New DataTable
            tb = New DataTable
            myCommand.CommandText = "SELECT tipoaj FROM parafacgral ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            doc_aj = tb.Rows(0).Item(0)

            Dim n As String = ""
            If c2.Checked = True Then
                n = " AND df.nit = '" & txttip.Text & "'"
            End If

            If d1.Checked = True Then
                For i = Val(cbini.Text) To Val(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If cbini.Text = cbfin.Text Then
                        sql = " SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & " (SELECT  vc.porcomi  FROM concomi c, vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv) AS por_desc, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f ,terceros t " _
                           & " WHERE t.nit = f.nitc and f.doc = df.doc  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'"
                    Else
                        If p = cbini.Text Then
                            sql = " SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                           & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) >= '" & txtdi1.Text & "'"
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , df.nit AS nitv,, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f,terceros t " _
                           & "  WHERE t.nit = f.nitc and (f.doc = df.doc)  AND v.nitv = df.nit " & n & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "  (SELECT ((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d/100)))* ( c.porcomi /100 ) as venc FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as ret_f, " _
                            & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) <= '" & txtdi1.Text & "'"
                        End If
                    End If

                Next

                sql = sql & " ORDER BY ciu_ent"
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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFVen.rpt")
                CrReport.SetDataSource(tabla)
                Try
                    CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                Catch ex As Exception
                End Try
                FrmReportFacVen.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrAJ As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nit.ToString)

                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    PrAJ.Name = "doc_aj"
                    PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                    Prtt.Name = "tit"
                    Prtt.CurrentValues.AddValue(" ASESOR")

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrAJ)
                    prmdatos.Add(Prtt)
                    FrmReportFacVen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacVen.ShowDialog()

                Catch ex As Exception
                End Try
            Else

                sql = "SELECT  c.nitv, c.ciu_ent, c.cc, c.fecha_o, c.cta3, c.por_desc, SUM(c.ret_f) as ret_f, SUM(c.subtotal) as subtotal FROM ("
                For i = Val(cbini.Text) To Val(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If cbini.Text = cbfin.Text Then
                        sql = sql & " SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & " (SELECT  vc.porcomi  FROM concomi c, vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv) AS por_desc, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND df.nit = vc.nitv) AS ret_f, " _
                            & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "   WHERE t.nit = f.nitc and (f.doc = df.doc)  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'"
                    Else
                        If p = cbini.Text Then
                            sql = sql & " SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND df.nit = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) >= '" & txtdi1.Text & "'"
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc ,  df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                            & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND df.nit = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='AF', " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = df.nit " & n & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION  SELECT f.doc , df.nit AS nitv, v.nombre as ciu_ent, t.nombre As cc , df.nomart AS observ , " _
                            & " (SELECT c.concepto FROM concomi c where df.concep = c.codcon) AS cta3, " _
                            & " (SELECT  vc.porcomi FROM concomi c,  vend_cc vc WHERE df.concep = c.codcon AND df.concep = vc.codcon AND df.nit = vc.nitv ) as por_desc, " _
                            & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                        & "(SELECT IF( LEFT(f.doc,2)='" & doc_aj & "', CONCAT('-',((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100)))," _
                        & " ((( df.vtotal - (df.vtotal * (df.por_des / 100)) ) / (1+ (df.iva_d / 100))) * (c.porcomi / 100))) FROM concomi c, vend_cc vc  WHERE df.concep = c.codcon  " _
                        & " AND df.concep = vc.codcon AND df.nit = vc.nitv) AS ret_f, " _
                           & " IF( LEFT(f.doc,2)='" & doc_aj & "'   , " _
                      & " CONCAT('-',(((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100) ))) - (((df.vtotal / (1+ (df.iva_d / 100)) - (df.vtotal / (1+ (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1+ (df.iva_d / 100))), " _
                      & " (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) - (((df.vtotal / (1 + (df.iva_d / 100)) - (df.vtotal / (1 + (df.iva_d / 100)) * (df.por_des / 100)))) * (f.por_desc / 100))) * (1 + (df.iva_d / 100)) " _
                      & " ) AS subtotal " _
                           & " FROM detafac" & p & " df, vendedores v, facturas" & p & " f , terceros t " _
                           & "  WHERE t.nit = f.nitc  and (f.doc = df.doc)  AND v.nitv = df.nit " & n & " AND right(f.fecha,2) <= '" & txtdi1.Text & "'"
                        End If
                    End If

                Next

                sql = sql & ") as c GROUP BY nitv order by ciu_ent"

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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFVen2.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportFacVen2.CrystalReportViewer1.ReportSource = CrReport

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

                    FrmReportFacVen2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacVen2.ShowDialog()

                Catch ex As Exception
                End Try
            End If

            Cerrar()
        Catch ex As Exception
            MsgBox("Error al Generar el Informe, " & ex.ToString, MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub


    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_pdf()
        If Me.Text = "INFORME POR VENDEDOR" Then
            PDF()
        Else
            PDF_ASESOR()
        End If

    End Sub
    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If CInt(txtdi1.Text) <= 9 Then
            txtdi1.Text = "0" & txtdi1.Text
        End If
    End Sub
    Private Sub txtdi2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi2.LostFocus
        If CInt(txtdi2.Text) <= 9 Then
            txtdi2.Text = "0" & txtdi2.Text
        End If
    End Sub
End Class