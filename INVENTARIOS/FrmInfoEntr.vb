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

Public Class FrmInfoEntr

    Public ent, sal As String
    Public costo, vi As Double

    Private Sub cmdsalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoEntr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "select * from bodegas;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        codbod.Maximum = tabla.Rows.Count
        tabla = New DataTable
        myCommand.CommandText = "select * from parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            ent = tabla.Rows(0).Item("entradas").ToString
            sal = tabla.Rows(0).Item("salidas").ToString
        End If
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

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2, t3, t4 As String
        Dim i, j, k, pag, med, niv, pv As Integer
        Dim sum1, sument, sumsal, totalent, totalsal, cant, cant1, total As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, cv, consulta, consulta2, tp, per As String
        j = 0
        pag = 1
        per = ""
        cv = ""
        t4 = ""
        cant1 = 0
        sument = 0
        totalent = 0
        totalsal = 0
        sumsal = 0
        niv = 0
        pv = 0
        cant = 0
        sum1 = 0
        Dim nom As String = ""
        Dim nit As String = ""
        Try
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
            nom = tabla.Rows(0).Item("descripcion")
            nit = tabla.Rows(0).Item("nit")
            cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
            cadena = "INFORME MOVIMIENTOS MENSUALES"
            med = 250
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 760, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
            k = 730
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.BeginText()
            cb.ShowTextAligned(50, "MM/AA", 20, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 60, k, 0)
            cb.ShowTextAligned(50, "INICIAL", 60, k - 10, 0)
            cb.ShowTextAligned(50, "  VALOR", 120, k, 0)
            cb.ShowTextAligned(50, "INICIAL", 120, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDADES", 220, k, 0)
            cb.ShowTextAligned(50, "ENTRADAS", 200, k - 10, 0)
            cb.ShowTextAligned(50, "SALIDAS", 250, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR", 320, k, 0)
            cb.ShowTextAligned(50, "ENTRADAS", 320, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR", 400, k, 0)
            cb.ShowTextAligned(50, "SALIDAS", 400, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 460, k, 0)
            cb.ShowTextAligned(50, "FINAL", 460, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR", 540, k, 0)
            cb.ShowTextAligned(50, "FINAL", 540, k - 10, 0)
            k = k - 30
            cb.EndText()
            cad = ""
            consulta = ""
            For i = Val(cbini.Text) To Val(cbfin.Text)
                t1 = bda & ".deta_mov" & adicionar(i)
                t2 = bda & ".movimientos" & adicionar(i)
                t3 = bda & ".con_inv"
                t4 = bda & ".articulos"


                If consulta = "" Then

                    consulta = "(SELECT " & t1 & ".doc," & t1 & ".item," & t4 & ".codart," & t4 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart WHERE CHAR_LENGTH(" & t4 & ".codart) >2 "

                    If c2.Checked = True Then
                        consulta = consulta & " AND " & t1 & ".codart = '" & txtci.Text & "' "
                    End If

                    If i1.Checked = True Then
                        consulta = consulta & " AND (" & t1 & ".bod_ori='" & codbod.Value & "'" & " OR " & t1 & ".bod_des='" & codbod.Value & "')"
                    End If

                    consulta = consulta & " ORDER BY " & t2 & ".doc )"
                Else
                    consulta2 = "(SELECT " & t1 & ".doc," & t1 & ".item," & t4 & ".codart," & t4 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart WHERE CHAR_LENGTH(" & t4 & ".codart) >2 "
                    If c2.Checked = True Then
                        consulta2 = consulta2 & " AND " & t1 & ".codart = '" & txtci.Text & "' "
                    End If

                    If i1.Checked = True Then
                        consulta2 = consulta2 & " AND (" & t1 & ".bod_ori='" & codbod.Value & "'" & " OR " & t1 & ".bod_des='" & codbod.Value & "')"
                    End If

                    consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & "doc )"
                End If
            Next

            consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.codart"

            tabla = New DataTable
            myCommand.CommandText = consulta & cad
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            cb.BeginText()
            tp = ""
            If tabla.Rows.Count <> 0 Then
                For i = 0 To tabla.Rows.Count - 1
                    If Len(tabla.Rows(i).Item("nomart").ToString) <> 2 Then
                        If tp <> tabla.Rows(i).Item("nomart").ToString Then
                            If tp <> "" Then
                                'cb.EndText()
                                'fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                'cb.SetFontAndSize(fuente, 7)
                                'cb.BeginText()
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 440, k, 0)
                                k = k - 10
                                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 360, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 440, k, 0)
                                k = k - 15
                                'cb.ShowTextAligned(50, "CANTIDAD Y COSTOS FINALES      " & "VALOR FINAL", 380, k, 0)
                                'k = k - 8
                                'If tabla1.Rows.Count <> 0 Then
                                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 420, k, 0)
                                '  cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                                '   cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)
                                ' End If
                                sument = 0
                                sumsal = 0
                                k = k - 20
                            End If
                            'cb.EndText()
                            '' k = k - 5
                            'fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            'cb.SetFontAndSize(fuente, 7)
                            'cb.BeginText()
                            per = Mid(PerActual, 1, 2)
                            per = Val(per) - 1
                            If Len(per) = 1 Then per = "0" & per
                            cant1 = 0
                            tabla1 = New DataTable
                            myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & per & "'"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla1)

                            'If i1.Checked = True Then
                            tabla2 = New DataTable
                            myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla2)
                            If tabla2.Rows.Count <> 0 Then
                                For l = 1 To tabla2.Rows.Count - 1
                                    If tabla1.Rows.Count <> 0 Then
                                        cant1 = cant1 + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                                    End If
                                Next
                            End If



                            cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString & "       " & tabla.Rows(i).Item("nomart").ToString, 20, k, 0)
                            k = k - 2
                            cb.ShowTextAligned(50, "__________________________________", 20, k, 0)
                            'CANTIDAD Y COSTOS INICIALES
                            k = k - 20
                            'cb.EndText()
                            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            'cb.SetFontAndSize(fuente, 7)
                            'cb.BeginText()
                            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant1, 80, k, 0)
                            If tabla1.Rows.Count <> 0 Then
                                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant1) * CDbl(tabla1.Rows(0).Item("costuni"))), 160, k, 0)
                                vi = CDbl(cant1) * CDbl(tabla1.Rows(0).Item("costuni"))
                                total = CDbl(cant1) * CDbl(tabla1.Rows(0).Item("costuni"))
                            End If
                        End If
                        tp = tabla.Rows(i).Item("nomart").ToString
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        Refresh()
                        cb.BeginText()

                        If tabla.Rows(i).Item("doc").ToString = "" Then
                            cb.ShowTextAligned(50, "NO REGISTRA MOVIMIENTO", 20, k, 0)
                        Else
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("per"), 20, k, 0)

                            tabla1 = New DataTable
                            myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & Mid(tabla.Rows(i).Item("per").ToString, 1, 2) & "'"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla1)

                            ' If i1.Checked = True Then
                            'tabla2 = New DataTable
                            'myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                            'myAdapter.SelectCommand = myCommand
                            'myAdapter.Fill(tabla2)
                            'If tabla2.Rows.Count <> 0 Then
                            '    For l = 1 To tabla2.Rows.Count - 1
                            '        cant = cant + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                            '    Next
                            'End If
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant1, 80, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(vi), 160, k, 0)
                            If tabla.Rows(i).Item("tipodoc").ToString = ent Then
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 230, k, 0)
                                cant1 = cant1 + Val(tabla.Rows(i).Item("cantidad").ToString)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 360, k, 0)
                                costo = CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)
                                total = total + costo
                                sument = sument + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                                totalent = totalent + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                            Else
                                If tabla.Rows(i).Item("tipodoc").ToString = sal Then
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 270, k, 0)
                                    cant1 = cant1 - Val(tabla.Rows(i).Item("cantidad").ToString)
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 440, k, 0)
                                    costo = CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)
                                    total = total - costo
                                    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                                    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                                Else
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 270, k, 0)
                                    cant1 = cant1 - Val(tabla.Rows(i).Item("cantidad").ToString)
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 440, k, 0)
                                    costo = CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)
                                    total = total - costo
                                    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                                    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                                End If
                            End If
                        End If

                        'CANTIDAD FINALES
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant1, 480, k, 0)
                        '  cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total), 570, k, 0)
                        vi = vi + costo
                        ' End If

                        k = k - 10
                        If k <= 80 Then
                            pag = pag + 1
                            cb.EndText()
                            oDoc.NewPage()
                            cb.BeginText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 9)
                            Refresh()
                            'myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                            'myAdapter.SelectCommand = myCommand
                            'myAdapter.Fill(tabla)
                            cb.ShowTextAligned(50, nom, 20, 810, 0)
                            cb.ShowTextAligned(50, "N.I.T. " & nit, 20, 800, 0)
                            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                            cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                            cadena = "INFORME GENERAL DE ARTICULOS"
                            med = 250
                            'i = cadena.Length
                            'i = i / 2
                            'j = med - i
                            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 760, 0)
                            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                            k = 700
                            cb.EndText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 6)
                            cb.BeginText()
                            cb.ShowTextAligned(50, "MM/AA", 20, k - 10, 0)
                            cb.ShowTextAligned(50, "CANTIDAD", 60, k, 0)
                            cb.ShowTextAligned(50, "INICIAL", 60, k - 10, 0)
                            cb.ShowTextAligned(50, "  VALOR", 120, k, 0)
                            cb.ShowTextAligned(50, "INICIAL", 120, k - 10, 0)
                            cb.ShowTextAligned(50, "CANTIDADES", 220, k, 0)
                            cb.ShowTextAligned(50, "ENTRADAS", 200, k - 10, 0)
                            cb.ShowTextAligned(50, "SALIDAS", 250, k - 10, 0)
                            cb.ShowTextAligned(50, "VALOR", 320, k, 0)
                            cb.ShowTextAligned(50, "ENTRADAS", 320, k - 10, 0)
                            cb.ShowTextAligned(50, "VALOR", 400, k, 0)
                            cb.ShowTextAligned(50, "SALIDAS", 400, k - 10, 0)
                            cb.ShowTextAligned(50, "CANTIDAD", 460, k, 0)
                            cb.ShowTextAligned(50, "FINAL", 460, k - 10, 0)
                            cb.ShowTextAligned(50, "VALOR", 540, k, 0)
                            cb.ShowTextAligned(50, "FINAL", 540, k - 10, 0)
                            k = k - 30
                        End If
                    End If
                Next
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 440, k, 0)
                k = k - 10
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 360, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 440, k, 0)
                k = k - 15
                sument = 0
                sumsal = 0
                k = k - 20

            End If

            If tabla.Rows.Count <> 0 Then
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 15)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________", 440, k, 0)
                k = k - 15
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
                cb.BeginText()
                cb.ShowTextAligned(50, "TOTAL GENERAL", 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalent), 360, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalsal), 440, k, 0)
                k = k - 15
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
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

    Private Sub cmdpantalla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_PDF()


        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim sql As String = ""
        Dim peri As String = ""

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

        Try

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim tablab As DataTable
            tablab = New DataTable
            myCommand.CommandText = "SELECT numbod from bodegas"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablab)

            Dim cant As String = ""
            Dim p As String = " "
            Dim pr As String = " "

            For i = 0 To tablab.Rows.Count - 1
                If i = 0 Then
                    cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
                Else
                    cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
                End If
            Next
            cant = cant & ")  "


            '//////////////// TODOS LOS CODIGOS ////////////////
            If c1.Checked = True Then

                If i1.Checked = True Then ' 1 bodega

                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                            pr = p - 1

                        Else
                            p = i
                            pr = p - 1
                        End If


                        If p = cbini.Text Then

                            sql = " SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, c.cant" & codbod.Text & " AS base, " _
                            & " (c.costuni * c.cant" & codbod.Text & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, c.cant" & codbod.Text & " + cantidad, c.cant" & codbod.Text & " - cantidad ) AS precio5,  " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (c.cant" & codbod.Text & " + cantidad), (cantidad * d.valor)*(c.cant" & codbod.Text & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE (c.codart = d.codart) AND c.periodo = " & pr & " AND d.doc = m.doc"

                        Else
                            sql = sql & " UNION SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, c.cant" & codbod.Text & " AS base, " _
                            & " (c.costuni * c.cant" & codbod.Text & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, c.cant" & codbod.Text & " + cantidad, c.cant" & codbod.Text & " - cantidad ) AS precio5, " _
                             & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (c.cant" & codbod.Text & " + cantidad), (cantidad * d.valor)*(c.cant" & codbod.Text & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE (c.codart = d.codart) AND c.periodo = " & pr & " AND d.doc = m.doc "

                        End If
                    Next
                    sql = sql & " ORDER BY codart;"
                    '  TextBox1.Text = sql

                Else       ' TOdas las bodegas

                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                            pr = p - 1

                        Else
                            p = i
                            pr = p - 1
                        End If


                        If p = cbini.Text Then

                            sql = " SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, " & cant & " AS base, " _
                            & " (c.costuni * " & cant & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, " & cant & " + cantidad, " & cant & " - cantidad ) AS precio5, " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (" & cant & " + cantidad), (cantidad * d.valor)*(" & cant & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE (c.codart = d.codart) AND c.periodo = " & pr & " AND d.doc = m.doc"

                        Else

                            sql = sql & " UNION SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, " & cant & " AS base, " _
                            & " (c.costuni * " & cant & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, " & cant & " + cantidad, " & cant & " - cantidad ) AS precio5,  " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (" & cant & " + cantidad), (cantidad * d.valor)*(" & cant & "- cantidad )) AS precio6  " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE (c.codart = d.codart) AND c.periodo = " & pr & " AND d.doc = m.doc "


                        End If
                    Next
                    sql = sql & " ORDER BY codart;"
                    '   TextBox1.Text = sql
                End If

            End If
            '/////////////FIN TODOS LOS CODIGOS ////////////////



            '//////////////// UN CODIGOS ////////////////
            If c2.Checked = True Then

                If i1.Checked = True Then ' 1 bodega

                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                            pr = p - 1

                        Else
                            p = i
                            pr = p - 1
                        End If


                        If p = cbini.Text Then

                            sql = " SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, c.cant" & codbod.Text & " AS base, " _
                            & " (c.costuni * c.cant" & codbod.Text & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, c.cant" & codbod.Text & " + cantidad, c.cant" & codbod.Text & " - cantidad ) AS precio5, " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (c.cant" & codbod.Text & " + cantidad), (cantidad * d.valor)*(c.cant" & codbod.Text & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE c.codart = '" & txtci.Text & "' AND d.codart= '" & txtci.Text & "' AND c.periodo = " & pr & " AND d.doc = m.doc"

                        Else
                            sql = sql & " UNION SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, c.cant" & codbod.Text & " AS base, " _
                            & " (c.costuni * c.cant" & codbod.Text & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, c.cant" & codbod.Text & " + cantidad, c.cant" & codbod.Text & " - cantidad ) AS precio5,  " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (c.cant" & codbod.Text & " + cantidad), (cantidad * d.valor)*(c.cant" & codbod.Text & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE c.codart = '" & txtci.Text & "' AND d.codart= '" & txtci.Text & "' AND c.periodo = " & pr & " AND d.doc = m.doc "

                        End If
                    Next
                    sql = sql & " ORDER BY codart;"
                    '  TextBox1.Text = sql

                Else       ' TOdas las bodegas

                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                            pr = p - 1

                        Else
                            p = i
                            pr = p - 1
                        End If


                        If p = cbini.Text Then

                            sql = " SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, " & cant & " AS base, " _
                            & " (c.costuni * " & cant & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, " & cant & " + cantidad, " & cant & " - cantidad ) AS precio5, " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (" & cant & " + cantidad), (cantidad * d.valor)*(" & cant & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE c.codart = '" & txtci.Text & "' AND d.codart= '" & txtci.Text & "' AND c.periodo = " & pr & " AND d.doc = m.doc"

                        Else

                            sql = sql & " UNION SELECT d.codart AS codart, d.nomart AS cue_inv, m.per AS cue_cos, " & cant & " AS base, " _
                            & " (c.costuni * " & cant & " ) AS vent, " _
                            & " IF( d.bod_ori <>0, 0, cantidad ) AS precio1, IF( d.bod_des <>0, 0, cantidad ) AS precio2, " _
                            & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS precio3, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS precio4, " _
                            & "IF( d.bod_ori <>0, " & cant & " + cantidad, " & cant & " - cantidad ) AS precio5, " _
                            & "IF( d.bod_ori <>0,  (cantidad * d.valor)* (" & cant & " + cantidad), (cantidad * d.valor)*(" & cant & "- cantidad )) AS precio6 " _
                            & "FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c WHERE c.codart = '" & txtci.Text & "' AND d.codart= '" & txtci.Text & "' AND c.periodo = " & pr & " AND d.doc = m.doc "


                        End If
                    Next
                    sql = sql & " ORDER BY codart;"
                    '   TextBox1.Text = sql
                End If

            End If
            '///////////// UN CODIGOS ////////////////




            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstMovMen.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmRepEsMovMen.CrystalReportViewer1.ReportSource = CrReport


            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
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


                FrmRepEsMovMen.CrystalReportViewer1.ParameterFieldInfo = prmdatos

            Catch ex As Exception
                MsgBox(sql)
            End Try

        Catch ex As Exception
            ' MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
        FrmRepEsMovMen.ShowDialog()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtci.Enabled = True
        Else
            txtci.Enabled = False
        End If
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        ct = 67
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub txtci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtci.TextChanged

    End Sub

End Class