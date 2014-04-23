Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmEstadoR_cc
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer, Cond As String
    Dim FechaRep As String
    Public ca As String = ""
    Private Sub FrmEstadoR_cc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbper.Text = "( " & PerActual & " )"
    End Sub
    Private Sub rb_cc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cc1.CheckedChanged
        'txtcc.Enabled = False
    End Sub
    Private Sub rb_cc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cc2.CheckedChanged
        If rb_cc2.Checked = True Then
            txtcc.Enabled = True
            ch.Enabled = True
        Else
            txtcc.Enabled = False
            ch.Enabled = False
        End If
    End Sub
    Private Sub rb_per1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_per1.CheckedChanged
        cbini.Text = PerActual(0) & PerActual(1)
        cbfin.Text = PerActual(0) & PerActual(1)
    End Sub
    '**************************************************************
    Private Sub rb_per2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_per2.CheckedChanged
        cbini.Text = "01"
        cbfin.Text = PerActual(0) & PerActual(1)
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        FechaRep = Now.ToString
        If rb_cc1.Checked = True Then 'TODOS LOS CC

            BalancePYG(cbini.Text, cbfin.Text, nivel.Value, "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6), "")
        Else  'POR CC
            If Trim(txtncc.Text) <> "" Then
                If ch.Checked = False Then
                    BalancePYG(cbini.Text, cbfin.Text, nivel.Value, "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6), " AND centro = '" & txtcc.Text & "';")
                Else
                    BalancePYG(cbini.Text, cbfin.Text, nivel.Value, "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6), " AND centro LIKE '" & Val(txtcc.Text) & "%';")
                End If
            Else
                MsgBox("Verifique el centro de costo.   ", MsgBoxStyle.Information, "SAE Control")
                txtcc.Focus()
            End If
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '********************************************
    Private Sub txtcc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtcc, e)
        End If
    End Sub
    Private Sub txtcc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcc.LostFocus
        BuscarCC()
    End Sub
    Public Sub BuscarCC()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtncc.Text = ""
            If tabla.Rows.Count > 0 Then
                txtncc.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcc.Text
                FrmSelCentroCostos.lbform.Text = "est_res_cc"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '********************************************
    Public Sub BalancePYG(ByVal perI As String, ByVal perF As String, ByVal n As Integer, ByVal ano As String, ByVal condiciones As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim i, j, pos, pos2, pos3, posA, posA2, posA3, tope As Integer
        MiPer = perI
        Cond = condiciones
        'MsgBox(Cond)
        '**********    Buscar Niveles   ********
        Dim nivel As Integer
        Dim tn, tc As New DataTable
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Try
            If n = 1 Then
                nivel = Val(tn.Rows(0).Item("nivel1"))
            ElseIf n = 2 Then
                nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2"))
            ElseIf n = 3 Then
                nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3"))
            ElseIf n = 4 Then
                nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3")) + Val(tn.Rows(0).Item("nivel4"))
            ElseIf n = 5 Then
                nivel = Val(tn.Rows(0).Item("longitud"))
            End If
        Catch ex As Exception
            MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
        End Try
        '********************
        Dim tabla, tablacomp, tablames As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='4' OR codigo='5' OR codigo='6' ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        '*********************
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        '***************************
        Try
            pag = 1
            tope = 70
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()

            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 50, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("descripcion"), 150, k, 0)
                '**************************
                tc.Clear()
                myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)<=" & nivel & " AND codigo like '" & tabla.Rows(i).Item("codigo") & "%' ORDER BY codigo;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                pos = 0
                pos2 = 0
                pos3 = 0
                posA = 0
                posA2 = 0
                posA3 = 0
                For j = 1 To tc.Rows.Count - 1
                    If k < tope Then 'NUEVA PAGINA
                        pag = pag + 1
                        cb.EndText()
                        oDoc.NewPage()
                        'cb.AddImage(img) 'IMAGEN
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
                        k = k - 10
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                    End If
                    If VerificarSaldo(tc.Rows(j).Item("codigo")) = True Then
                        k = k - 10
                        cb.ShowTextAligned(50, tc.Rows(j).Item("codigo"), 50, k, 0)
                        cb.ShowTextAligned(50, tc.Rows(j).Item("descripcion"), 150, k, 0)
                    End If
                    If tc.Rows(j).Item("codigo").ToString.Length = nivel Then
                        BuscarSubNiveles(tc.Rows(j).Item("codigo"), k)
                        If n = 5 Then  'HAY NIVEL SUB CUENTA
                            Try
                                If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) < 9 Then
                                    If pos3 > posA3 Then
                                        BuscarSubTotal(tc.Rows(pos3).Item("codigo"), tc.Rows(pos3).Item("nivel"), tc.Rows(pos3).Item("descripcion"), k)
                                        posA3 = pos3
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                        If n > 3 Then 'HAY NIVEL CUENTA
                            Try
                                If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) <= 4 Then
                                    If pos2 > posA2 Then
                                        BuscarSubTotal(tc.Rows(pos2).Item("codigo"), tc.Rows(pos2).Item("nivel"), tc.Rows(pos2).Item("descripcion"), k)
                                        posA2 = pos2
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                        If n > 2 Then 'HAY NIVEL GRUPO
                            Try
                                If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) = 2 Then
                                    If pos > posA Then
                                        BuscarSubTotal(tc.Rows(pos).Item("codigo"), tc.Rows(pos).Item("nivel"), tc.Rows(pos).Item("descripcion"), k)
                                        posA = pos
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                    'mirar nivel para posicionar el proximo
                    If Val(tc.Rows(j).Item("codigo").ToString.Length) = 2 Then
                        If VerificarSaldo(tc.Rows(j).Item("codigo")) = True Then
                            pos = j 'GRUPO
                        End If
                    ElseIf Val(tc.Rows(j).Item("codigo").ToString.Length) = 4 Then
                        If VerificarSaldo(tc.Rows(j).Item("codigo")) = True Then
                            pos2 = j 'CUENTA
                        End If
                    ElseIf Val(tc.Rows(j).Item("codigo").ToString.Length) = Val(tn.Rows(0).Item("nivel4")) + 4 Then
                        If VerificarSaldo(tc.Rows(j).Item("codigo")) = True Then
                            pos3 = j 'SUB CUENTA
                        End If
                    End If
                Next
                j = j - 1
                If n > 2 Then
                    k = k - 10
                    If n > 4 Then
                        If pos3 > posA3 Then
                            BuscarSubTotal(tc.Rows(pos3).Item("codigo"), tc.Rows(pos3).Item("nivel"), tc.Rows(pos3).Item("descripcion"), k)
                            posA3 = pos3
                        End If
                    End If
                    If n > 3 Then
                        If pos2 > posA2 Then
                            BuscarSubTotal(tc.Rows(pos2).Item("codigo"), tc.Rows(pos2).Item("nivel"), tc.Rows(pos2).Item("descripcion"), k)
                            posA2 = pos2
                        End If
                    End If

                    If pos > posA Then
                        BuscarSubTotal(tc.Rows(pos).Item("codigo"), tc.Rows(pos).Item("nivel"), tc.Rows(pos).Item("descripcion"), k)
                        posA = pos
                    End If
                End If
                '***************************
                k = k - 10
                If k < 30 Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    'cb.AddImage(img) 'IMAGEN
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                cb.ShowTextAligned(50, "__________________________________________________________________________________________________________________________________________________ ", 50, k + 10, 0)
                cb.ShowTextAligned(50, "TOTAL " & tabla.Rows(i).Item("descripcion"), 120, k, 0)
                BuscarSubTotal(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("nivel"), tabla.Rows(i).Item("descripcion"), k)
                k = k - 20
            Next
            k = k - 20
            If k < 130 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
                k = k - 20
            End If
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            ResumenBG() 'RESUMEN DEL BALANCE
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                ' MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("ERROR al momento de generar el balance de P Y G, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub BannerBG(ByVal pi As String, ByVal pf As String, ByVal tipo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        If cbini.Text = cbfin.Text Then
            cb.ShowTextAligned(50, "PERIODO GENERADO: " & pi & "  ", 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "PERIODO INICIAL: " & pi & "    PERIODO FINAL: " & pf & "  (ACUMULADO)", 20, 780, 0)
        End If
        k = 770
        If rb_cc1.Checked = True Then
            cb.ShowTextAligned(50, "REPORTE GENERADO PARA TODOS LOS CENTROS DE COSTO ", 20, 770, 0)
        Else
            cb.ShowTextAligned(50, "CENTRO DE COSTO: " & txtcc.Text & " - " & txtncc.Text, 20, 770, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tipo, 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 20
    End Sub
    '**************************************************************
    Function VerificarSaldo(ByVal cuenta As String)
        Dim tabla, tabla2 As New DataTable
        Dim suma, suma2, Aux As Double
        Dim Saldo As String
        Dim p As Integer
        If Val(cbini.Text) = 0 Then
            p = 0
        Else
            p = Val(cbini.Text) - 1
        End If
        If p < 10 Then
            Saldo = "0" & p
        Else
            Saldo = p
        End If
        suma = 0
        suma2 = 0
        '///////////CALCULAR SALDO INICIAL //////////////////////
        If cbini.Text <> cbfin.Text Then
            If cbfin.Text = "12" Then
                myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos12 WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Try
                    Aux = tabla.Rows(0).Item(0)
                Catch ex As Exception
                    Aux = 0
                End Try
                suma = suma + Aux
                tabla.Clear()
                myCommand.CommandText = "SELECT SUM(saldo11) as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
            Else
                myCommand.CommandText = "SELECT SUM(saldo" & cbfin.Text & ") as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                suma = suma + tabla.Rows(0).Item(0)
            Catch ex As Exception
                suma = 0
            End Try
            If suma <> 0 Then
                Return True
                Exit Function
            End If
        Else
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & cbfin.Text & " WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Try
                suma2 = tabla2.Rows(0).Item(0)
            Catch ex As Exception
                suma2 = 0
            End Try
            If suma2 <> 0 Then
                Return True
                Exit Function
            End If
        End If
        Return False
    End Function
    Public Sub BuscarSubNiveles(ByVal cuenta As String, ByVal item As Integer)
        Dim tabla As New DataTable
        Dim suma, aux As Double
        '///////////CALCULAR SALDO SUB NIVEL//////////////////////
        suma = 0
        tabla.Clear()
        Dim ini As Integer
        If cbini.Text <> cbfin.Text Then
            ini = 0
        Else
            ini = Val(cbini.Text)
        End If
        Dim per As String = ""
        For i = ini To Val(cbfin.Text)
            tabla.Clear()
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                aux = tabla.Rows(0).Item(0)
            Catch ex As Exception
                aux = 0
            End Try
            suma = suma + aux
        Next
        If suma = 0 Then
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, item, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, item, 0)
        End If
    End Sub
    Public Sub BuscarSubTotal(ByVal cuenta As String, ByVal nivel As String, ByVal des As String, ByVal item As Integer)
        Dim tabla As New DataTable
        Dim suma, Aux As Double
        suma = 0
        '///////////CALCULAR SALDO INICIAL //////////////////////
        Dim ini As Integer
        If cbini.Text <> cbfin.Text Then
            ini = 0
        Else
            ini = Val(cbini.Text)
        End If
        Dim per As String = ""
        For i = ini To Val(cbfin.Text)
            tabla.Clear()
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & per & " WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                Aux = tabla.Rows(0).Item(0)
            Catch ex As Exception
                Aux = 0
            End Try
            suma = suma + Aux
        Next
        '**************************************************************************
        If suma <> 0 Then
            If cuenta.Length > 1 Then
                k = k - 15
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "________________________", 585, k + 10, 0)
                cb.ShowTextAligned(50, "SUB TOTAL " & UCase(nivel) & " " & des, 50, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
            End If
            k = k - 8
        ElseIf cuenta.Length = 1 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
            k = k - 12
        End If
    End Sub
    Public Sub ResumenBG()
        Dim tI, tG, tC As New DataTable
        Dim sumaI, sumaG, sumaC, aI, aG, aC, UTI As Double
        Dim saldo As String
        Dim inicio As Integer
        '****************************************
        sumaI = 0
        sumaG = 0
        sumaC = 0
        If cbini.Text = cbfin.Text Then
            inicio = 0
        Else
            inicio = Val(cbini.Text)
        End If
        For j = inicio To Val(cbfin.Text)
            If j < 10 Then
                saldo = "documentos0" & j
            Else
                saldo = "documentos" & j
            End If
            'TOTAL INGRESOS
            tI.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '4%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tI)
            Try
                aI = tI.Rows(0).Item(0)
            Catch ex As Exception
                aI = 0
            End Try
            sumaI = sumaI + aI
            'TOTAL GASTOS
            tG.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '5%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tG)
            Try
                aG = tG.Rows(0).Item(0)
            Catch ex As Exception
                aG = 0
            End Try
            sumaG = sumaG + aG
            'TOTAL COSTOS
            tC.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '6%' " & ca & " " & Cond & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tC)
            Try
                aC = tC.Rows(0).Item(0)
            Catch ex As Exception
                aC = 0
            End Try
            sumaC = sumaC + aC
        Next
        '***************************************
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "RESUMEN", 300, k, 0)
        cb.ShowTextAligned(50, "INGRESOS", 50, k - 15, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaI), 250, k - 15, 0)
        cb.ShowTextAligned(50, "GASTOS", 50, k - 30, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaG), 420, k - 30, 0)
        cb.ShowTextAligned(50, "COSTOS DE VENTAS", 50, k - 45, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaC), 420, k - 45, 0)
        UTI = sumaI + sumaG + sumaC
        If UTI >= 0 Then
            cb.ShowTextAligned(50, "PERDIDAD", 50, k - 60, 0)
        Else
            cb.ShowTextAligned(50, "UTILIDAD", 50, k - 60, 0)
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(UTI), 250, k - 60, 0)
        'firmas
        If fcon.Checked = True Then
            cb.ShowTextAligned(50, "___________________________ ", 20, k - 110, 0)
            cb.ShowTextAligned(50, "CONTADOR ", 20, k - 120, 0)
        End If
        If frf.Checked = True Then
            cb.ShowTextAligned(50, "___________________________  ", 210, k - 110, 0)
            cb.ShowTextAligned(50, "REVISOR FISCAL ", 210, k - 120, 0)
        End If
        If frl.Checked = True Then
            cb.ShowTextAligned(50, "___________________________  ", 400, k - 110, 0)
            cb.ShowTextAligned(50, "REPRESENTANTE LEGAL ", 400, k - 120, 0)
        End If
    End Sub
    '**************************************************************

    Private Sub txtcc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcc.TextChanged

    End Sub
End Class