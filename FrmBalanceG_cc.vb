Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmBalanceG_cc
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Private Sub FrmBalanceG_cc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        txtano.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        FechaRep = Now.ToString
        If rb_cc1.Checked = True Then 'TODOS LOS CC
            BalanceGralCC(cbper.Text, nivel.Value, txtano.Text)
        Else  'POR CC
            If Trim(txtncc.Text) <> "" Then
                BalanceGralCC(cbper.Text, nivel.Value, txtano.Text)
            Else
                MsgBox("Verifique el centro de costo.   ", MsgBoxStyle.Information, "SAE Control")
                txtcc.Focus()
            End If
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '***************************************************
    Private Sub rb_cc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cc1.CheckedChanged
        txtcc.Enabled = False
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
                FrmSelCentroCostos.lbform.Text = "bal_gral_cc"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '***************************************************
    'inicio balance general
    Public Sub BalanceGralCC(ByVal perI As String, ByVal n As Integer, ByVal ano As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim i, j, pos, pos2, pos3, posA, posA2, posA3, tope As Integer
        MiPer = perI
        FechaRep = Now.ToString
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
        myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=1 AND codigo<'4' ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        '*********************
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        '***************************
        Try
            pag = 1
            tope = 80
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            '******************
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            BannerBG("PERIODO: " & perI & "/" & ano, "BALANCE GENERAL")
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
                    'cb.AddImage(img) 'IMAGEN
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    BannerBG("PERIODO INICIAL: " & perI & "/" & ano, "BALANCE GENERAL")
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
                        BannerBG("PERIODO: " & perI & "/" & ano, "BALANCE GENERAL")
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
                    BannerBG("PERIODO: " & perI & "/" & ano, "BALANCE GENERAL")
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
            If k < 155 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                BannerBG("PERIODO: " & perI & "/" & ano, "BALANCE GENERAL")
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
            MsgBox(ex.ToString)
            If oDoc.IsOpen Then
                oDoc.Close()
                Exit Sub
            End If
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub BannerBG(ByVal periodo As String, ByVal tipo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, periodo, 20, 780, 0)
        k = 770
        If rb_cc1.Checked = True Then
            cb.ShowTextAligned(50, "REPORTE GENERADO PARA TODOS LOS CENTROS DE COSTO ", 20, 770, 0)
        Else
            cb.ShowTextAligned(50, "CENTRO DE COSTO: " & txtcc.Text & " - " & txtncc.Text, 20, 770, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, tipo, 230, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 20
    End Sub
    Function VerificarSaldo(ByVal cuenta As String)
        Dim tabla As New DataTable
        Dim suma As Double
        Dim Saldo As String
        Saldo = "documentos" & MiPer
        '///////////CALCULAR SALDO INICIAL //////////////////////
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            suma = tabla.Rows(0).Item(0)
        Catch ex As Exception
            suma = 0
        End Try
        If suma = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub BuscarSubNiveles(ByVal cuenta As String, ByVal item As Integer)
        Dim tabla As New DataTable
        Dim suma As Double
        Dim Saldo As String
        Saldo = "documentos" & MiPer
        '///////////CALCULAR SALDO INICIAL //////////////////////
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            suma = tabla.Rows(0).Item(0)
        Catch ex As Exception
            suma = 0
        End Try
        If suma = 0 Then
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, item, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, item, 0)
        End If
    End Sub
    Public Sub BuscarSubTotal(ByVal cuenta As String, ByVal nivel As String, ByVal des As String, ByVal item As Integer)
        Dim tabla As New DataTable
        Dim suma As Double
        Dim Saldo As String
        Saldo = "documentos" & MiPer
        '///////////CALCULAR SALDO INICIAL //////////////////////
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '" & cuenta & "%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            suma = tabla.Rows(0).Item(0)
        Catch ex As Exception
            suma = 0
        End Try
        If suma <> 0 Then
            If cuenta.Length > 1 Then
                k = k - 15
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "________________________", 585, k + 10, 0)
                cb.ShowTextAligned(50, "SUB TOTAL " & UCase(nivel) & " " & des, 50, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
            End If
            k = k - 5
        End If
    End Sub
    Public Sub ResumenBG()
        Dim tA, tP, tC As New DataTable
        Dim sumaA, sumaP, sumaC, Dif As Double
        Dim Saldo As String
        Saldo = "documentos" & MiPer
        'TOTAL ACTIVO
        'myCommand.CommandText = "SELECT sum(" & Saldo & ") FROM selpuc WHERE codigo like '1%' and nivel='Auxiliar';"
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '1%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '1%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '1%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tA)
        Try
            sumaA = tA.Rows(0).Item(0)
        Catch ex As Exception
            sumaA = 0
        End Try
        'TOTAL PASIVO
        'myCommand.CommandText = "SELECT sum(" & Saldo & ") FROM selpuc WHERE codigo like '2%' and nivel='Auxiliar';"
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '2%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '2%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '2%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tP)
        Try
            sumaP = tP.Rows(0).Item(0)
        Catch ex As Exception
            sumaP = 0
        End Try
        'TOTAL CAPITAL
        'myCommand.CommandText = "SELECT sum(" & Saldo & ") FROM selpuc WHERE codigo like '3%' and nivel='Auxiliar';"
        If rb_cc1.Checked = True Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '3%';"
        ElseIf ch.Checked = False Then
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '3%' and centro = '" & txtcc.Text & "';"
        Else
            myCommand.CommandText = "SELECT sum(debito-credito) FROM " & Saldo & " WHERE codigo like '3%' and centro LIKE '" & Val(txtcc.Text) & "%';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tC)
        Try
            sumaC = tC.Rows(0).Item(0)
        Catch ex As Exception
            sumaC = 0
        End Try
        cb.ShowTextAligned(50, "RESUMEN DEL BALANCE", 200, k, 0)
        cb.ShowTextAligned(50, "ACTIVOS", 50, k - 15, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaA), 250, k - 15, 0)
        cb.ShowTextAligned(50, "PASIVOS", 50, k - 30, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaP), 420, k - 30, 0)
        cb.ShowTextAligned(50, "CAPITAL", 50, k - 45, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaC), 420, k - 45, 0)
        cb.ShowTextAligned(50, "DIFERENCIA", 50, k - 60, 0)
        Dif = sumaA + sumaP + sumaC
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(Dif), 250, k - 60, 0)
        'firmas
        If fcon.Checked = True Then
            cb.ShowTextAligned(50, "___________________________ ", 20, k - 120, 0)
            cb.ShowTextAligned(50, "CONTADOR ", 20, k - 130, 0)
        End If
        If frf.Checked = True Then
            cb.ShowTextAligned(50, "___________________________  ", 210, k - 120, 0)
            cb.ShowTextAligned(50, "REVISOR FISCAL ", 210, k - 130, 0)
        End If
        If frl.Checked = True Then
            cb.ShowTextAligned(50, "___________________________  ", 400, k - 120, 0)
            cb.ShowTextAligned(50, "REPRESENTANTE LEGAL ", 400, k - 130, 0)
        End If
    End Sub
    'fin balance general

End Class