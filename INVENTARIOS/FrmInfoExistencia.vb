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

Public Class FrmInfoExistencia

    Public col As Integer

    Private Sub FrmInfoExistencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cbini.Text = PerActual(0) & PerActual(1)

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "select * from bodegas;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        codbod.Maximum = tabla.Rows.Count
    End Sub

    Private Sub codbod_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codbod.ValueChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".bodegas where numbod='" & codbod.Value & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <> 0 Then
            txtnombod.Text = tabla.Rows(0).Item("nombod")
        Else
            MsgBox("No existen bodegas", , "Verificando...")
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcf.Enabled = True
            txtci.Enabled = True
        Else
            txtcf.Enabled = False
            txtci.Enabled = False
        End If
    End Sub
    '*********************************************************
    Dim cb As PdfContentByte
    Dim i2, j, k, pag, med, niv, pv As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Dim cadena, cv As String
    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2 As String
        Dim sum1 As Double
        Dim tabla As New DataTable
        pag = 1
        cv = ""
        niv = 0
        pv = 0
        sum1 = 0
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        Refresh()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME POR EXISTENCIA EN BODEGA"
        med = 250
        i2 = cadena.Length
        i2 = i2 / 2
        j = med - i2
        cb.ShowTextAligned(50, cadena, j, 760, 0)
        cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        k = 730
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        cb.ShowTextAligned(50, "CODIGO / REFERENCIA", 5, k - 10, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 90, k - 10, 0)
        cb.ShowTextAligned(50, "CANTIDAD", 260, k, 0)
        cb.ShowTextAligned(50, "BODEGA " & codbod.Value, 260, k - 10, 0)
        cb.ShowTextAligned(50, " COSTO", 330, k, 0)
        cb.ShowTextAligned(50, "UNITARIO", 330, k - 10, 0)
        cb.ShowTextAligned(50, " COSTO", 390, k, 0)
        cb.ShowTextAligned(50, "PROMEDIO", 390, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR TOTAL", 460, k, 0)
        cb.ShowTextAligned(50, "A COSTO", 460, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR TOTAL", 540, k, 0)
        cb.ShowTextAligned(50, "A PRECIO", 540, k - 10, 0)

            k = k - 30
            cb.EndText()
            cad = ""
            t1 = bda & ".articulos"
            t2 = bda & ".con_inv"
        If O1.Checked = True Then
            cad = " ORDER BY " & t1 & ".codart"
            cadena = "SELECT " & t1 & ".*," & t2 & ".*,(" & t2 & ".costprom * " & t2 & ".cant" & codbod.Value & ")AS tprom,(" & t2 & ".precio" & codbod.Value & " * (1 + (" & t1 & ".iva / 100)) )AS p,(" & t2 & ".cant" & codbod.Value & ")AS cant FROM " & t1 & " LEFT OUTER JOIN " & t2 & " ON " & t1 & ".codart=" & t2 & ".codart WHERE 1 "
        Else
            If O2.Checked = True Then
                cad = " ORDER BY " & t1 & ".nomart"
                cadena = "SELECT " & t1 & ".*," & t2 & ".*,(" & t2 & ".costprom * " & t2 & ".cant" & codbod.Value & ")AS tprom,(" & t2 & ".precio" & codbod.Value & " * (1 + (" & t1 & ".iva / 100)) )AS p,(" & t2 & ".cant" & codbod.Value & ")AS cant FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".codart=" & t2 & ".codart WHERE 1 "
            Else
                cad = " ORDER BY " & t1 & ".referencia"
                cadena = "SELECT " & t1 & ".*," & t2 & ".*,(" & t2 & ".costprom * " & t2 & ".cant" & codbod.Value & ")AS tprom,(" & t2 & ".precio" & codbod.Value & " * (1 + (" & t1 & ".iva / 100)) )AS p,(" & t2 & ".cant" & codbod.Value & ")AS cant FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".codart=" & t2 & ".codart WHERE 1 "
            End If
        End If
        If l2.Checked = True Then
            tabla = New DataTable
            myCommand.CommandText = "SELECT * FROM bodegas"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("No hay bodegas registradas")
                Exit Sub
            End If
            cadena = cadena & " AND " & t2 & ".cant" & codbod.Value & ">0"
        End If
            If c2.Checked = True And O1.Checked = True Then
                cadena = cadena & " AND (" & t1 & ".codart>='" & txtci.Text & "' AND " & t1 & ".codart<='" & txtcf.Text & "') "
            Else
                If c2.Checked = True And O3.Checked = True Then
                    cadena = cadena & " AND (" & t1 & ".referencia>='" & txtci.Text & "' AND " & t1 & ".referencia<='" & txtcf.Text & "') "
                Else
                    If c2.Checked = True And O2.Checked = True Then
                        cadena = cadena & " AND (" & t1 & ".codart>='" & txtci.Text & "' AND " & t1 & ".codart<='" & txtcf.Text & "') "
                End If
            End If
        End If
        cadena = cadena & " AND " & t2 & ".periodo ='" & PerActual(0) & PerActual(1) & "' "
        tabla = New DataTable
        myCommand.CommandText = cadena & cad
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 6)
        cb.BeginText()
        'MsgBox(tabla.Rows.Count)
        If tabla.Rows.Count <> 0 Then
            cv = ""
            For i = 0 To tabla.Rows.Count - 1
                'If tabla.Rows(i).Item("periodo").ToString = Mid(PerActual, 1, 2) Or Trim(Len(tabla.Rows(i).Item("codart").ToString)) < 3 Then
                'If Trim(Len(tabla.Rows(i).Item("codart").ToString)) < 3 Then
                '    If cv <> tabla.Rows(i).Item("nomart").ToString And cv <> "" Then
                '        cb.EndText()
                '        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                '        cb.SetFontAndSize(fuente, 7)
                '        cb.BeginText()
                '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "______________________", 500, k, 0)
                '        k = k - 11
                '        cb.ShowTextAligned(50, "SUBTOTAL " & cv, 20, k, 0)
                '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
                '        sum1 = 0
                '        k = k - 10
                '    End If
                '    cv = tabla.Rows(i).Item("nomart").ToString
                '    k = k - 10
                '    cb.EndText()
                '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                '    cb.SetFontAndSize(fuente, 7)
                '    cb.BeginText()
                '    cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                '    cb.ShowTextAligned(50, tabla.Rows(i).Item("nomart").ToString, 80, k, 0)
                'Else
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 6)
                cb.BeginText()
                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString & " / " & tabla.Rows(i).Item("referencia").ToString, 5, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("desart").ToString, 36), 90, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cant").ToString, 280, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("costuni").ToString), 360, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("costprom").ToString), 430, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("tprom").ToString), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("p").ToString), 580, k, 0)
                sum1 = sum1 + CDbl(tabla.Rows(i).Item("tprom").ToString)
                'End If
                k = k - 10
                If k <= 80 Then
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner()
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                    cb.BeginText()
                End If
                'End If
            Next
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.BeginText()
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "______________________", 500, k, 0)
            k = k - 11
            cb.ShowTextAligned(50, "TOTAL GENERAL " & cv, 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
            sum1 = 0
            k = k - 10
        End If

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
    Public Sub Banner()
        Dim s As Integer = 0
        Dim tabla As New DataTable
        Refresh()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion").ToString, 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit").ToString, 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME GENERAL DE ARTICULOS"
        med = 250
        s = cadena.Length
        s = s / 2
        j = med - s
        cb.ShowTextAligned(50, cadena, j, 760, 0)
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 750, 0)
        k = 730
        'cb.EndText()
        'fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        'cb.SetFontAndSize(fuente, 6)
        'cb.BeginText()
        cb.ShowTextAligned(50, "CODIGO / REFERENCIA", 5, k - 10, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 90, k - 10, 0)
        cb.ShowTextAligned(50, "CANTIDAD", 260, k, 0)
        cb.ShowTextAligned(50, "BODEGA " & codbod.Value, 260, k - 10, 0)
        cb.ShowTextAligned(50, " COSTO", 330, k, 0)
        cb.ShowTextAligned(50, "UNITARIO", 330, k - 10, 0)
        cb.ShowTextAligned(50, " COSTO", 390, k, 0)
        cb.ShowTextAligned(50, "PROMEDIO", 390, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR TOTAL", 460, k, 0)
        cb.ShowTextAligned(50, "A COSTO", 460, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR TOTAL", 540, k, 0)
        cb.ShowTextAligned(50, "A PRECIO", 540, k - 10, 0)
        k = k - 30
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtci_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtci.MouseDoubleClick
        If O1.Checked = True Or O2.Checked = True Then
            ct = 40
        Else
            ct = 50
        End If
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub txtcf_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtcf.MouseDoubleClick
        If O1.Checked = True Or O2.Checked = True Then
            ct = 41
        Else
            ct = 51
        End If
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub cmdpantalla_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdpantalla.MouseClick

    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_PDF()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim p As String = ""
        Dim pt As String = ""
        Dim b As String = ""
        Dim j As String = ""
        Dim cant As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        p = cbini.Text
        pt = cbini.Text & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        b = codbod.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        '/////////////// CODIGOS //////////////////////////
        If c1.Checked = True Then

            If l1.Checked = True Then ' Con y Sin existencia

                If iva.Checked = True Then ' IVA

                    If O1.Checked = True Then ' Ordenar x Codigo

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY codart"

                    End If

                    If O2.Checked = True Then ' Ordenar x Nomar

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY nomart"

                    End If

                    If O3.Checked = True Then ' Ordenar x Refe

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY referencia"

                    End If

                Else ' SIN IVA 

                    If O1.Checked = True Then ' Ordenar x Codig
                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY codart"

                    End If

                    If O2.Checked = True Then ' Ordenar x nomb

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY nomart"

                    End If

                    If O3.Checked = True Then ' Ordenar x referen
                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY referencia"

                    End If
                End If ' fIN iVA

            Else



                If l2.Checked = True Then ' FIN Con Art existencia

                    If iva.Checked = True Then ' IVA

                        If O1.Checked = True Then ' Ordenar x Codigo

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY codart"

                        End If

                        If O2.Checked = True Then ' Ordenar x Nomar

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY nomart"

                        End If

                        If O3.Checked = True Then ' Ordenar x Refe

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart  AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY referencia"

                        End If

                    Else ' SIN IVA 

                        If O1.Checked = True Then ' Ordenar x Codig
                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY codart"

                        End If

                        If O2.Checked = True Then ' Ordenar x nomb

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY nomart"

                        End If

                        If O3.Checked = True Then ' Ordenar x referen
                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY referencia"

                        End If
                    End If ' fIN iVA


                End If ' FIN Con Art existencia


            End If ' FIN Con y Sin existencia
        End If
        '//////////////FIN/ CODIGOS //////////////////////////



        '///////////////  RANGO CODIGOS //////////////////////////
        If c2.Checked = True Then

            If l1.Checked = True Then ' Con y Sin existencia

                If iva.Checked = True Then ' IVA

                    If O1.Checked = True Then ' Ordenar x Codigo

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "'  WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY codart"

                    End If

                    If O2.Checked = True Then ' Ordenar x Nomar

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY nomart"

                    End If

                    If O3.Checked = True Then ' Ordenar x Refe

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY referencia"

                    End If

                Else ' SIN IVA 

                    If O1.Checked = True Then ' Ordenar x Codig
                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY codart"

                    End If

                    If O2.Checked = True Then ' Ordenar x nomb

                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & " AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "'  WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY nomart"

                    End If

                    If O3.Checked = True Then ' Ordenar x referen
                        sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                        & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart" _
                        & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                        & "ORDER BY referencia"

                    End If
                End If ' fIN iVA

            Else


                If l2.Checked = True Then ' FIN Con Art existencia

                    If iva.Checked = True Then ' IVA

                        If O1.Checked = True Then ' Ordenar x Codigo

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY codart"

                        End If

                        If O2.Checked = True Then ' Ordenar x Nomar

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY nomart"

                        End If

                        If O3.Checked = True Then ' Ordenar x Refe

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "( c.precio1 * ( 1 + ( a.iva /100 ) ) ) AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart  AND c.cant" & b & " <> 0 " _
                            & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY referencia"

                        End If

                    Else ' SIN IVA 

                        If O1.Checked = True Then ' Ordenar x Codig
                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY codart"

                        End If

                        If O2.Checked = True Then ' Ordenar x nomb

                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & " AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY nomart"

                        End If

                        If O3.Checked = True Then ' Ordenar x referen
                            sql = " SELECT a.codart, a.referencia, a.nomart, c.margen AS margen, c.cant" & b & " AS can_emp, c.costuni AS cos_uni, c.costprom AS cos_pro, (c.cant" & b & " * c.costuni) AS pp, " _
                            & "c.precio1 AS precio FROM articulos a LEFT JOIN con_inv c ON a.codart = c.codart AND c.cant" & b & " <> 0 " _
                            & "  AND  a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "' WHERE c.periodo =  '" & p & "' AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & "ORDER BY referencia"

                        End If
                    End If ' fIN iVA


                End If ' FIN Con Art existencia


            End If ' FIN Con y Sin existencia
        End If
        '//////////////FIN/  RANGO CODIGOS //////////////////////////


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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportExisB.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        FrmRepExis.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prbodega As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(pt.ToString)

            Prbodega.Name = "No"
            Prbodega.CurrentValues.AddValue(b.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prbodega)

            FrmRepExis.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepExis.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try
    End Sub

    Private Sub l2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l2.CheckedChanged

    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
End Class