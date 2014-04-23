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

Public Class FrmInfoKardexref

    Public ent, sal, fc1, fc2, fc3, fc4 As String

    Private Sub FrmInfoKardexref_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        tabla = New DataTable
        myCommand.CommandText = "select * from parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count > 0 Then
            fc1 = tabla.Rows(0).Item("tipof1").ToString
            fc2 = tabla.Rows(0).Item("tipof2").ToString
            fc3 = tabla.Rows(0).Item("tipof3").ToString
            fc4 = tabla.Rows(0).Item("tipof4").ToString
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

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2, t3, t4 As String
        Dim i, i2, j, k, pag, med, niv, pv As Integer
        Dim sum1, sument, sumsal, totalent, totalsal, cant, cant1 As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, cv, consulta, consulta2, tp, per As String
        pag = 1
        per = ""
        cv = ""
        i2 = 0
        cant1 = 0
        sument = 0
        totalent = 0
        totalsal = 0
        sumsal = 0
        niv = 0
        pv = 0
        cant = 0
        sum1 = 0
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
            cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
            cadena = "KARDEX POR REFERENCIA"
            med = 250
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, j, 760, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
            k = 730
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.BeginText()
            cb.ShowTextAligned(50, "TIPO/NUMERO", 20, k, 0)
            cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 10, 0)
            cb.ShowTextAligned(50, "FECHA", 80, k - 10, 0)
            cb.ShowTextAligned(50, " BODEGAS", 120, k, 0)
            cb.ShowTextAligned(50, "DEST|ORIG", 120, k - 10, 0)
            cb.ShowTextAligned(50, "CONCEPTO", 160, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDADES", 300, k, 0)
            cb.ShowTextAligned(50, "ENTRADAS", 280, k - 10, 0)
            cb.ShowTextAligned(50, "SALIDAS", 320, k - 10, 0)
            cb.ShowTextAligned(50, "COSTO", 380, k, 0)
            cb.ShowTextAligned(50, "UNITARIO", 380, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR", 460, k, 0)
            cb.ShowTextAligned(50, "ENTRADAS", 460, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR", 540, k, 0)
            cb.ShowTextAligned(50, "SALIDAS", 540, k - 10, 0)
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

                    consulta = "(SELECT " & t4 & ".referencia," & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart WHERE 1"

                    If c2.Checked = True Then
                        consulta = consulta & " AND " & t1 & ".codart = '" & txtci.Text & "' "
                    End If

                    If i1.Checked = True Then
                        consulta = consulta & " AND (" & t1 & ".bod_ori='" & codbod.Value & "'" & " OR " & t1 & ".bod_des='" & codbod.Value & "')"
                    End If

                    consulta = consulta & " ORDER BY " & t2 & ".doc)"
                Else
                    consulta2 = "(SELECT " & t4 & ".referencia," & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart WHERE 1"
                    If c2.Checked = True Then
                        consulta2 = consulta2 & " AND " & t1 & ".codart = '" & txtci.Text & "' "
                    End If

                    If i1.Checked = True Then
                        consulta2 = consulta2 & " AND (" & t1 & ".bod_ori='" & codbod.Value & "'" & " OR " & t1 & ".bod_des='" & codbod.Value & "')"
                    End If

                    consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & ".doc)"
                End If
            Next

            consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.referencia"

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
                    If tp <> tabla.Rows(i).Item("nomart").ToString Then
                        If tp <> "" Then
                            cb.EndText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 7)
                            cb.BeginText()
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 570, k, 0)
                            k = k - 10
                            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
                            k = k - 15
                            cb.ShowTextAligned(50, "CANTIDAD Y COSTOS FINALES      " & "VALOR FINAL", 380, k, 0)
                            k = k - 8
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 420, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)

                            sument = 0
                            sumsal = 0
                            k = k - 20
                        End If
                        cb.EndText()
                        ' k = k - 5
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        per = Mid(PerActual, 1, 2)
                        per = Val(per) - 1
                        If Len(per) = 1 Then
                            per = "0" & per
                        End If
                        cant1 = 0
                        tabla1 = New DataTable
                        myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & per & "'"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla1)
                        If l1.Checked = True Then
                            tabla2 = New DataTable
                            myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla2)
                            If tabla2.Rows.Count <> 0 Then
                                For l = 1 To tabla2.Rows.Count - 1
                                    cant1 = cant1 + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                                Next
                            End If
                        Else
                            tabla2 = New DataTable
                            myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas WHERE " & bda & ".bodegas.numbod='" & codbod.Value & "' ORDER BY " & bda & ".bodegas.numbod;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla2)
                            If tabla2.Rows.Count <> 0 Then
                                For l = 1 To tabla2.Rows.Count - 1
                                    cant1 = cant1 + CDbl(tabla1.Rows(i).Item("cant" & l).ToString)
                                Next
                            End If
                        End If
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString & "       " & tabla.Rows(i).Item("nomart").ToString, 20, k, 0)
                        cb.ShowTextAligned(50, "CANTIDAD Y COSTOS INICIALES      " & "VALOR INICIAL", 380, k, 0)
                        k = k - 1
                        cb.ShowTextAligned(50, "_____________________________________________", 20, k, 0)
                        k = k - 9
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant1, 420, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant1) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)

                        k = k - 20
                    End If

                    tp = tabla.Rows(i).Item("nomart").ToString
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Refresh()
                    cb.BeginText()
                    'k = k - 10
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "  " & NumeroDoc(tabla.Rows(i).Item("num").ToString), 20, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("per").ToString, 105, k, 0)
                    'If Len(tabla.Rows(i).Item("concepto").ToString) > 20 Then
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("concepto").ToString, 20), 160, k, 0)
                    'Else
                    'cb.ShowTextAligned(50, tabla.Rows(i).Item("concepto").ToString, 160, k, 0)
                    'End If

                    If tabla.Rows(i).Item("bod_ori").ToString <> "0" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("bod_ori").ToString, 130, k, 0)
                    'End If
                    If tabla.Rows(i).Item("bod_des").ToString <> "0" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("bod_des").ToString, 150, k, 0)
                    'End If
                    tabla1 = New DataTable
                    myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & Mid(tabla.Rows(i).Item("per").ToString, 1, 2) & "'"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla1)
                    cant = 0
                    If l1.Checked = True Then
                        tabla2 = New DataTable
                        myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla2)
                        If tabla2.Rows.Count <> 0 Then
                            For l = 1 To tabla2.Rows.Count - 1
                                cant = cant + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                            Next
                        End If
                    Else
                        tabla2 = New DataTable
                        myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas WHERE " & bda & ".bodegas.numbod='" & codbod.Value & "' ORDER BY " & bda & ".bodegas.numbod;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla2)
                        If tabla2.Rows.Count <> 0 Then
                            For l = 1 To tabla2.Rows.Count - 1
                                cant = cant + CDbl(tabla1.Rows(i).Item("cant" & l).ToString)
                            Next
                        End If
                    End If

                    If tabla1.Rows.Count > 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni").ToString), 420, k, 0)
                    End If

                    If tabla.Rows(i).Item("bod_ori").ToString = "0" And tabla.Rows(i).Item("bod_des").ToString <> "0" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 300, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 490, k, 0)
                        sument = sument + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                        totalent = totalent + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    Else
                        If tabla.Rows(i).Item("bod_ori").ToString <> "0" And tabla.Rows(i).Item("bod_des").ToString = "0" Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 340, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 570, k, 0)
                            sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                            totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                            'Else
                            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 340, k, 0)
                            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 570, k, 0)
                            '    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                            '    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                        End If
                    End If


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
                        myAdapter.Fill(tabla)
                        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion").ToString, 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit").ToString, 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                        cadena = "KARDEX POR REFERENCIA"
                        med = 250
                        'i = cadena.Length
                        'i = i / 2
                        'j = med - i
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, j, 760, 0)
                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 700
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 6)
                        cb.BeginText()
                        cb.ShowTextAligned(50, "TIPO/NUMERO", 20, k, 0)
                        cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 10, 0)
                        cb.ShowTextAligned(50, "FECHA", 80, k - 10, 0)
                        cb.ShowTextAligned(50, " BODEGAS", 120, k, 0)
                        cb.ShowTextAligned(50, "DEST|ORIG", 120, k - 10, 0)
                        cb.ShowTextAligned(50, "CONCEPTO", 160, k - 10, 0)
                        cb.ShowTextAligned(50, "CANTIDADES", 300, k, 0)
                        cb.ShowTextAligned(50, "ENTRADAS", 280, k - 10, 0)
                        cb.ShowTextAligned(50, "SALIDAS", 320, k - 10, 0)
                        cb.ShowTextAligned(50, "COSTO", 380, k, 0)
                        cb.ShowTextAligned(50, "UNITARIO", 380, k - 10, 0)
                        cb.ShowTextAligned(50, "VALOR", 460, k, 0)
                        cb.ShowTextAligned(50, "ENTRADAS", 460, k - 10, 0)
                        cb.ShowTextAligned(50, "VALOR", 540, k, 0)
                        cb.ShowTextAligned(50, "SALIDAS", 540, k - 10, 0)
                        k = k - 30
                    End If
                Next
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 570, k, 0)
                k = k - 10
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
                k = k - 15
                cb.ShowTextAligned(50, "CANTIDAD Y COSTOS FINALES      " & "VALOR FINAL", 380, k, 0)
                k = k - 8
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 420, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)

                sument = 0
                sumsal = 0
                k = k - 20

            End If

            If tabla.Rows.Count <> 0 Then
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 15)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________", 580, k, 0)
                k = k - 15
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
                cb.BeginText()
                cb.ShowTextAligned(50, "TOTAL GENERAL", 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalent), 490, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalsal), 570, k, 0)
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
        mostrar_PDF()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtci.Enabled = True
        Else
            txtci.Enabled = False
        End If
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        ct = 61
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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



            Dim tablab As DataTable
            tablab = New DataTable
            myCommand.CommandText = "SELECT numbod from bodegas"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablab)

            'Dim cant As String = ""

            'For i = 0 To tablab.Rows.Count - 1
            '    If i = 0 Then
            '        cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
            '    Else
            '        cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
            '    End If
            'Next
            'cant = cant & ") as cantidad"

            'If i1.Checked = True Then

            '    cant = "cant" & codbod.Value & " as cantidad "
            'End If


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
End Class