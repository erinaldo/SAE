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

Public Class FrmInvenDia

    Public art As DataTable
    Public col As New Integer
    Public vec(5) As Integer

    Public Sub mostrar_PDF()
        'Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        'Dim pdfw As iTextSharp.text.pdf.PdfWriter
        'Dim cb As PdfContentByte
        'Dim fuente As iTextSharp.text.pdf.BaseFont
        'Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        'Dim cad, t1, t2 As String
        'Dim i, j, k, pag, med, niv, pv As Integer
        'Dim scan, sum1, sument, sumsal As Double
        'Dim tabla As New DataTable
        'Dim tabla1, tabla2, banner As DataTable
        'Dim cadena, cv, consulta, consulta2, cadena1, tp As String
        'cad = ""
        'scan = 0
        'pag = 1
        'cv = ""
        'tp = ""
        'niv = 0
        'pv = 0
        'sum1 = 0
        'pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
        '    FileMode.Create, FileAccess.Write, FileShare.None))
        'oDoc.Open()
        'cb = pdfw.DirectContent
        'oDoc.NewPage()
        'cb.BeginText()
        'fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        'cb.SetFontAndSize(fuente, 9)
        'Refresh()
        'myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        'myAdapter.SelectCommand = myCommand
        'banner = New DataTable
        'myAdapter.Fill(banner)
        'cb.ShowTextAligned(50, banner.Rows(0).Item("descripcion"), 20, 810, 0)
        'cb.ShowTextAligned(50, "N.I.T. " & banner.Rows(0).Item("nit"), 20, 800, 0)
        'cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        'cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        'cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        'cadena = "INFORME GENERAL DE ARTICULOS"
        'med = 250
        ''i = cadena.Length
        ''i = i / 2
        ''j = med - i
        'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 760, 0)
        'cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        'k = 730
        'cb.EndText()
        'fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        'cb.SetFontAndSize(fuente, 6)
        'cb.BeginText()
        'cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
        'cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 230, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 230, k - 10, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "UNIDADES", 280, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DE EMPAQUE", 280, k - 10, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 370, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "UNITARIO", 370, k - 10, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 460, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PROMEDIO", 460, k - 10, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 550, k, 0)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "A COSTO", 550, k - 10, 0)
        ''cb.ShowTextAligned(50, "VALOR TOTAL", 540, k, 0)
        ''cb.ShowTextAligned(50, "A PRECIO", 540, k - 10, 0)

        'k = k - 30

        'For i = 0 To art.Rows.Count - 1
        '    cb.EndText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 7)
        '    cb.BeginText()

        '    consulta = ""
        '    For j = 1 To Val(Mid(PerActual, 1, 2))
        '        t1 = bda & ".movimientos" & adicionar(j)
        '        t2 = bda & ".deta_mov" & adicionar(j)
        '        If consulta = "" Then
        '            consulta = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart," & t2 & ".bod_ori," & t2 & ".bod_des," & t2 & ".cantidad  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc WHERE " & t2 & ".codart='" & art.Rows(i).Item("codart") & "' "
        '            cadena = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart," & t2 & ".bod_ori," & t2 & ".bod_des," & t2 & ".cantidad FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc " ' ORDER BY " & t2 & ".doc) "
        '            If c2.Checked = True Then
        '                consulta = consulta & " AND " & t2 & ".codart='" & txtci.Text & "' "
        '                cadena = cadena & " AND " & t2 & ".codart='" & txtci.Text & "' "
        '            End If
        '            consulta = consulta & " ORDER BY " & t2 & ".doc) "
        '            cadena = cadena & " ORDER BY " & t2 & ".doc) "
        '        Else
        '            consulta2 = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart," & t2 & ".bod_ori," & t2 & ".bod_des," & t2 & ".cantidad FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc WHERE " & t2 & ".codart='" & art.Rows(i).Item("codart") & "' "
        '            cadena1 = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart," & t2 & ".bod_ori," & t2 & ".bod_des," & t2 & ".cantidad FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc" ' ORDER BY " & t2 & ".doc) "
        '            If c2.Checked = True Then
        '                consulta2 = consulta2 & " AND " & t2 & ".codart='" & txtci.Text & "' "
        '                cadena1 = cadena1 & " AND " & t2 & ".codart='" & txtci.Text & "' "
        '            End If
        '            consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & ".doc)"
        '            cadena = cadena & " UNION " & cadena1 & " ORDER BY " & t2 & ".doc) "
        '        End If
        '    Next

        '    consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.per,consulta.dia ASC"

        '    TextBox1.Text = consulta

        '    tabla = New DataTable
        '    myCommand.CommandText = consulta
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    sum1 = 0

        '    'sumsal = 0
        '    If tabla.Rows.Count <> 0 Then
        '        For l As Integer = 0 To tabla.Rows.Count - 1
        '            If CDate(tabla.Rows(l).Item("dia").ToString & "/" & tabla.Rows(l).Item("per").ToString) >= CDate("01" & "/" & cbini.Text & txtpini.Text) And CDate(tabla.Rows(l).Item("dia").ToString & "/" & tabla.Rows(l).Item("per").ToString) <= CDate(txtdi2.Text & "/" & cbfin.Text & txtpfin.Text) Then
        '                If tabla.Rows(l).Item("bod_ori").ToString = "0" And tabla.Rows(l).Item("bod_des").ToString <> "0" Then
        '                    'sument = sument + tabla.Rows(l).Item("cantidad").ToString
        '                    sum1 = sum1 + tabla.Rows(l).Item("cantidad").ToString
        '                Else
        '                    If tabla.Rows(l).Item("bod_ori").ToString <> "0" And tabla.Rows(l).Item("bod_des").ToString = "0" Then
        '                        sum1 = sum1 - tabla.Rows(l).Item("cantidad").ToString
        '                        'sumsal = sumsal + tabla.Rows(l).Item("cantidad").ToString
        '                    End If
        '                End If
        '            End If
        '        Next
        '        cb.ShowTextAligned(50, art.Rows(i).Item("codart").ToString, 20, k, 0)
        '        cb.ShowTextAligned(50, CambiaCadena(art.Rows(i).Item("desart").ToString, 25), 80, k, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 230, k, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, art.Rows(i).Item("unidad").ToString, 280, k, 0)

        '        tabla1 = New DataTable
        '        myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & art.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & Mid(PerActual, 1, 2) & "'"
        '        myAdapter.SelectCommand = myCommand
        '        myAdapter.Fill(tabla1)
        '        If tabla1.Rows.Count <> 0 Then

        '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni").ToString), 370, k, 0)
        '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costprom").ToString), 460, k, 0)
        '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * sum1), 550, k, 0)
        '            sument = sument + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * sum1)
        '            sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * sum1)
        '        End If
        '        k = k - 10
        '    Else
        '        cv = "SELECT consulta.* FROM (" & cadena & ") AS consulta WHERE consulta.codart like '" & art.Rows(i).Item("codart").ToString & "%' ORDER BY consulta.per,consulta.dia ASC"

        '        TextBox1.Text = cv

        '        tabla2 = New DataTable
        '        myCommand.CommandText = cv
        '        myAdapter.SelectCommand = myCommand
        '        myAdapter.Fill(tabla2)
        '        If Len(art.Rows(i).Item("codart").ToString) = 2 And tabla2.Rows.Count <> 0 Then
        '            cb.EndText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 7)
        '            cb.BeginText()
        '            If tp <> "" Then
        '                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 550, k, 0)
        '                k = k - 10
        '                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
        '                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 550, k, 0)
        '                sum1 = 0
        '                sument = 0
        '                k = k - 20
        '            End If

        '            cb.EndText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 7)
        '            cb.BeginText()
        '            cb.ShowTextAligned(50, art.Rows(i).Item("codart").ToString & "   " & art.Rows(i).Item("nomart").ToString, 20, k, 0)
        '            tp = art.Rows(i).Item("nomart").ToString
        '            k = k - 20
        '        End If
        '    End If

        '    If k <= 80 Then
        '        pag = pag + 1
        '        cb.EndText()
        '        oDoc.NewPage()
        '        cb.BeginText()
        '        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '        cb.SetFontAndSize(fuente, 9)
        '        Refresh()
        '        cb.ShowTextAligned(50, banner.Rows(0).Item("descripcion"), 20, 810, 0)
        '        cb.ShowTextAligned(50, "N.I.T. " & banner.Rows(0).Item("nit"), 20, 800, 0)
        '        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        '        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        '        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        '        'cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & "                                " & "PERIODO FINAL: " & "/" & cbfin.Text & txtpfin.Text, 20, 760, 0)
        '        cadena = "INFORME GENERAL DE ARTICULOS"
        '        med = 250
        '        'i = cadena.Length
        '        'i = i / 2
        '        'j = med - i
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 750, 0)
        '        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
        '        k = 700
        '        cb.EndText()
        '        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '        cb.SetFontAndSize(fuente, 6)
        '        cb.BeginText()
        '        cb.ShowTextAligned(50, "DIAS", 20, k - 10, 0)
        '        cb.ShowTextAligned(50, "DESCRIPCION", 60, k - 10, 0)
        '        cb.ShowTextAligned(50, "CANTIDAD", 200, k, 0)
        '        cb.ShowTextAligned(50, "MINIMA", 200, k - 10, 0)
        '        cb.ShowTextAligned(50, "PUNTO DE", 250, k, 0)
        '        cb.ShowTextAligned(50, "PEDIDO", 250, k - 10, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 330, k, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 330, k - 10, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 420, k, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PROMEDIO", 420, k - 10, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 500, k, 0)
        '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "A COSTO", 500, k - 10, 0)
        '        cb.ShowTextAligned(50, "ULTIMA", 510, k, 0)
        '        cb.ShowTextAligned(50, "FECHA", 510, k - 10, 0)
        '        cb.ShowTextAligned(50, "DIAS", 550, k - 10, 0)
        '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '        cb.SetFontAndSize(fuente, 7)
        '        'cb.BeginText()
        '        k = k - 30
        '    End If
        'Next

        'If art.Rows.Count <> 0 Then
        '    cb.EndText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 7)
        '    cb.BeginText()
        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 550, k, 0)
        '    k = k - 10
        '    cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 550, k, 0)
        '    sum1 = 0
        '    k = k - 20
        '    cb.EndText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 8)
        '    cb.BeginText()
        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 550, k, 0)
        '    k = k - 10
        '    cb.ShowTextAligned(50, "VALOR TOTAL ", 20, k, 0)
        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 550, k, 0)
        'End If
        'cb.EndText()
        'pdfw.Flush()
        'oDoc.Close()
        'banner.Dispose()
        'Try
        '    AbrirArchivo(NombreArchivo)
        'Catch ex As Exception
        '    AbrirArchivo(NombreArchivo)
        '    Exit Try
        'End Try

    End Sub

    Private Sub FrmInvenDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        art = New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".articulos ORDER BY " & bda & ".articulos.codart; " 'WHERE " & bda & ".articulos.doc_de='I';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(art)
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        cbfin.Text = PerActual(0) & PerActual(1)

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
        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim nomA As String = ""
        Dim codA As String = ""
        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        per = "PERIODO: " & cbfin.Text & "/" & txtpfin.Text
        '8888888888888888888888888888888888

        Try
            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim sql As String = ""
            Dim peri As String = ""
            Dim cant As String = ""
            Dim codar As String = ""


            codar = txtci.Text

            Dim tablab As DataTable
            tablab = New DataTable
            myCommand.CommandText = "SELECT numbod from bodegas"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablab)



            For i = 0 To tablab.Rows.Count - 1
                If i = 0 Then
                    cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
                Else
                    cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
                End If
            Next
            cant = cant & ") "


            ' Radio button 1
            If c1.Checked = True Then

                sql = "select  *  from ( select a.nivel, a.codart, a.nomart, a.desart, a.cos_uni, a.cos_pro, a.precio, a.pp from articulos a where length(a.codart) <> (select longitud from parinven) UNION "
                sql = sql & "SELECT a.nivel , a.codart, a.nomart, a.desart, c.costuni AS cos_uni ,c.costprom AS cos_pro, " & cant & " AS precio,((" & cant & ") * c.costuni) AS pp " _
                    & " FROM(articulos a) " _
                    & "right JOIN ( " _
                    & " con_inv c " _
                    & " ) ON a.codart = c.codart " _
                    & " WHERE c.periodo = '" & cbfin.Text & "' and " & cant & " <> 0"

                sql = sql & ") AS consulta GROUP BY codart ORDER BY codart"

            End If ' final radio button1


            ' Radio button 2
            If c2.Checked = True Then

                sql = "select  *  from ( select a.nivel, a.codart, a.nomart,c.periodo, a.desart, a.cos_uni, a.cos_pro, a.precio, a.pp from articulos a,con_inv c  where length(a.codart) <> (select longitud from parinven) AND c.periodo = '" & cbfin.Text & "' AND a.codart like '" & codar & "%' "
                sql = sql & " UNION "
                sql = sql & "SELECT a.nivel , a.codart, a.nomart,c.periodo, a.desart, c.costuni AS cos_uni ,c.costprom AS cos_pro, " & cant & " AS precio,((" & cant & ") * c.costuni) AS pp " _
                    & " FROM(articulos a) " _
                    & "right JOIN ( " _
                    & " con_inv c " _
                    & " ) ON a.codart = c.codart " _
                    & " WHERE c.periodo = '" & cbfin.Text & "' and a.codart like '" & codar & "%' and " & cant & " <> 0"

                sql = sql & ") AS consulta GROUP BY codart "

            End If ' final radio button2

            TextBox1.Text = sql

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            ' Refresh()
            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Reportdia.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmRdia.CrystalReportViewer1.ReportSource = CrReport

            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField

                Dim Prperiodo As New ParameterField
                Dim Pr_cod_art As New ParameterField
                Dim Pr_des_art As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nitc"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmRdia.CrystalReportViewer1.ParameterFieldInfo = prmdatos

            Catch ex As Exception
                MsgBox(sql)
            End Try

        Catch ex As Exception
            MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
        FrmRdia.ShowDialog()

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtci.Enabled = True
        Else
            txtci.Enabled = False
        End If
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        ct = 80
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtci.TextChanged

    End Sub
End Class