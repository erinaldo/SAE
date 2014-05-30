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
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmEstadoResultados
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer, Cond As String
    Dim FechaRep As String
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub FrmEstadoResultados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        cbini.Text = PerActual(0) & PerActual(1)
        cbfin.Text = PerActual(0) & PerActual(1)
        txtpini.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        txtpfin.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub
    '**************************************************************
    Private Sub cbini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbini.KeyPress
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbfin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbfin.KeyPress
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        cbfin.Items.Clear()
        For i = Val(cbini.Text) To 12
            If i < 10 Then
                cbfin.Items.Add("0" & i)
            Else
                cbfin.Items.Add(i)
            End If
        Next
        cbfin.Text = cbini.Text
    End Sub
    '**************************************************************
    Private Sub n1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n1.CheckedChanged
        txtnit.Enabled = False
    End Sub
    Private Sub n2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n2.CheckedChanged
        txtnit.Enabled = True
    End Sub
    '**************************************************************
    Private Sub nivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nivel.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        VerificarNit()
    End Sub
    Function VerificarNit()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            txtnit.Focus()
            txtnombre.Text = ""
            Return False
        Else
            txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
            Return True
        End If
    End Function
    '**************************************************************
    Private Sub fcon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fcon.CheckedChanged
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub frf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frf.CheckedChanged
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub frl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frl.CheckedChanged
        SendKeys.Send("{TAB}")
    End Sub
    '**************************************************************
    Public ca As String = ""
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        '  BorrarDiferencia()

        If chkMostrar.Checked = False Then
            Dim tDif As New DataTable
            myCommand.CommandText = "SELECT ctaPerdida FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tDif)
            If tDif.Rows(0).Item(0).ToString = "" Then
                MsgBox("No hay Cuenta Para Mostrar Utilidad / Perdida, Verifique Los Parametros", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            Else
                Try
                    '    GuardarDiferencia()
                Catch ex As Exception
                    MsgBox("Guardar Dif .." & ex.ToString)
                End Try
            End If
        End If
        FechaRep = Now.ToString
        If ChCierre.Checked = True Then
            ca = "AND tipodoc<>'CA'"
        Else
            ca = ""
        End If
        If n1.Checked = True Then 'TODOS LOS NIT
            BalancePYG(cbini.Text, cbfin.Text, nivel.Value, txtpini.Text, "")
        Else  'POR NIT
            If VerificarNit() = True Then
                BalancePYG(cbini.Text, cbfin.Text, nivel.Value, txtpini.Text, " AND nit='" & txtnit.Text & "' ")
            End If
        End If
    End Sub
    Dim utili As Double
    Private Sub BorrarDiferencia()

        MiConexion(bda)
        Try
            myCommand.CommandText = "delete from documentos" & cbfin.Text & " where doc='1' and tipodoc='AJ' and modulo='AJUSTE_BG';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox("Error al Borrar dif.. " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub GuardarDiferencia()
        utili = 0
        '***** ////////////////////////////////////////
        Dim tI, tG, tC, tDif, tDesc As New DataTable
        Dim sumaI, sumaG, sumaC, aI, aG, aC, UTI As Double
        Dim saldo As String
        Dim inicio As Integer
        Dim nk As Integer = k
        '****************************************
        sumaI = 0
        sumaG = 0
        sumaC = 0
        If cbini.Text = "01" Then
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '4%' " & ca & ";"
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '5%' " & ca & ";"
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '6%' " & ca & ";"
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

        utili = UTI
        If chkMostrar.Checked = False Then

            UTI = sumaI + sumaG + sumaC
            ''******************************
            myCommand.CommandText = "SELECT ctaPerdida FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tDif)

            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", 100)
            myCommand.Parameters.AddWithValue("?doc", "1")
            myCommand.Parameters.AddWithValue("?tipodoc", "AJ")
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", "01")
            myCommand.Parameters.AddWithValue("?centro", "0")
            myCommand.Parameters.AddWithValue("?desc", "AJUSTE")
            If UTI < 0 Then
                myCommand.Parameters.AddWithValue("?debito", 0)
                myCommand.Parameters.AddWithValue("?credito", DIN(UTI * -1))
            Else
                myCommand.Parameters.AddWithValue("?debito", DIN(UTI))
                myCommand.Parameters.AddWithValue("?credito", 0)
            End If
            myCommand.Parameters.AddWithValue("?sal", DIN(UTI))
            myCommand.Parameters.AddWithValue("?codigo", tDif.Rows(0).Item("ctaPerdida"))
            myCommand.Parameters.AddWithValue("?base", 0)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
            myCommand.Parameters.AddWithValue("?nit", 0)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "AJUSTE_BG")
            myCommand.CommandText = "INSERT INTO documentos" & cbfin.Text & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()

            If CInt(cbfin.Text) - 1 <= 9 Then
                myCommand.CommandText = "UPDATE selpuc SET saldo0" & CInt(cbfin.Text) - 1 & "= saldo0" & CInt(cbfin.Text) - 1 & " + ?sal, " _
                & " saldo" & cbfin.Text & "= saldo" & cbfin.Text & " + ?sal WHERE codigo=?codigo;"
            Else
                myCommand.CommandText = "UPDATE selpuc SET saldo" & CInt(cbfin.Text) - 1 & "= saldo" & CInt(cbfin.Text) - 1 & " + ?sal, " _
               & " saldo" & cbfin.Text & "= saldo" & cbfin.Text & " + ?sal WHERE codigo=?codigo;"
            End If
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Cerrar()


        End If


    End Sub

    Public Sub BalancePYG(ByVal perI As String, ByVal perF As String, ByVal n As Integer, ByVal ano As String, ByVal condiciones As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim i, j, pos, pos2, pos3, posA, posA2, posA3, tope As Integer
        MiPer = perI
        Cond = condiciones
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
        'Dim cc As String = ""
        'If chG.Checked = True Then
        '    cc = " codigo IN ('4','6')"
        '    cc = " codigo IN ('4','6')"
        'End If
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
            If tablacomp.Rows(0).Item("tipo") = "comercial" Then
                BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
            Else
                BannerBG(perI & ano, perF & ano, "ESTADO DE SITUACION FINANCIERA ECONOMICA SOCIAL Y AMBIENTAL")
            End If
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
            cb.ShowTextAligned(50, "PERIODO GENERADO: " & pi & "  P Y G DE PERIODO  ", 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "PERIODO INICIAL: " & pi & "    PERIODO FINAL: " & pf & "  P Y G ACUMULADO", 20, 780, 0)
        End If

        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tipo, 300, 760, 0)
        k = 750
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 20
        If Trim(Cond) <> "" Then
            cb.ShowTextAligned(50, "MOVIMIENTOS GENERADOS POR EL NIT: " & txtnit.Text & "  " & txtnombre.Text, 20, k, 0)
            k = k - 15
        End If
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
        If cbini.Text <> cbfin.Text Then
            If cbfin.Text = "12" Then
                myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos12 WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Try
                    aux = tabla.Rows(0).Item(0)
                Catch ex As Exception
                    aux = 0
                End Try
                suma = suma + aux
                tabla.Clear()
                myCommand.CommandText = "SELECT SUM(saldo11) as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
            Else
                myCommand.CommandText = "SELECT SUM(saldo" & cbfin.Text & ") as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
            End If
        Else
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & cbfin.Text & " WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            aux = tabla.Rows(0).Item(0)
        Catch ex As Exception
            aux = 0
        End Try
        suma = suma + aux
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
        tabla.Clear()
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
        Else
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos" & cbfin.Text & " WHERE codigo like '" & cuenta & "%' " & ca & " " & Cond & ";"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            Aux = tabla.Rows(0).Item(0)
        Catch ex As Exception
            Aux = 0
        End Try
        suma = suma + Aux
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
        Dim tI, tG, tC, tDif, tDesc As New DataTable
        Dim sumaI, sumaG, sumaC, aI, aG, aC, UTI As Double
        Dim saldo As String
        Dim inicio As Integer
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim nk As Integer = k
        '****************************************
        sumaI = 0
        sumaG = 0
        sumaC = 0
        If cbini.Text = "01" Then
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '4%' " & ca & ";"
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '5%' " & ca & ";"
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
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '6%' " & ca & ";"
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
        '*************************************
        ''******************************
        If chkMostrar.Checked = False Then
            nk = nk + 8
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            myCommand.CommandText = "SELECT ctaPerdida FROM  parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tDif)
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" + tDif.Rows(0).Item("ctaPerdida") + "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tDesc)

            cb.ShowTextAligned(50, "TOTAL " + tDesc.Rows(0).Item("descripcion"), 120, nk, 0)
            cb.ShowTextAligned(50, tDif.Rows(0).Item("ctaPerdida"), 50, nk + 10, 0)
            cb.ShowTextAligned(50, tDesc.Rows(0).Item("descripcion"), 150, nk + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(UTI), 585, nk + 10, 0)
            cb.ShowTextAligned(50, "__________________________________________________________________________________________________________________________________________________ ", 50, nk + 9, 0)
        Else
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            If chkMostrar.Checked = True Then
                If UTI >= 0 Then
                    cb.ShowTextAligned(50, "PERDIDAD", 50, k - 60, 0)
                Else
                    cb.ShowTextAligned(50, "UTILIDAD", 50, k - 60, 0)
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(UTI), 250, k - 60, 0)
            End If
        End If


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
    Function NomCuenta(ByVal codigo As String)
        Try
            Dim tn As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tn)
            Return tn.Rows(0).Item("descripcion")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub BalanceCA(ByVal perI As String, ByVal perF As String, ByVal n As Integer, ByVal ano As String, ByVal condiciones As String)
        'Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        'Dim pdfw As iTextSharp.text.pdf.PdfWriter
        'Dim fuente As iTextSharp.text.pdf.BaseFont
        'Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        'Dim i, j, pos, pos2, pos3, posA, posA2, posA3, tope As Integer
        'MiPer = perI
        'Cond = condiciones
        ''**********    Buscar Niveles   ********
        'Dim nivel As Integer
        'Dim tn, tc, taux As New DataTable
        'myCommand.CommandText = "SELECT * FROM parcontab;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tn)
        'Try
        '    If n = 1 Then
        '        nivel = Val(tn.Rows(0).Item("nivel1"))
        '    ElseIf n = 2 Then
        '        nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2"))
        '    ElseIf n = 3 Then
        '        nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3"))
        '    ElseIf n = 4 Then
        '        nivel = Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3")) + Val(tn.Rows(0).Item("nivel4"))
        '    ElseIf n = 5 Then
        '        nivel = Val(tn.Rows(0).Item("longitud"))
        '    End If
        'Catch ex As Exception
        '    MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
        'End Try
        ''********************
        'Dim tabla, tablacomp, tablames As New DataTable
        'myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo like '4%' OR codigo like '5%' OR codigo like '6%'  ORDER BY codigo;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        ''*********************
        'myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tablacomp)
        ''***************************
        'Try
        '    pag = 1
        '    tope = 70
        '    pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        '    oDoc.Open()
        '    cb = pdfw.DirectContent
        '    oDoc.NewPage()

        '    cb.BeginText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 9)
        '    BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
        '    cb.EndText()
        '    cb.BeginText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 8)
        '    For i = 0 To tabla.Rows.Count - 1
        '        k = k - 10
        '        If k < tope Then 'NUEVA PAGINA
        '            pag = pag + 1
        '            cb.EndText()
        '            oDoc.NewPage()
        '            cb.BeginText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 9)
        '            BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
        '            k = k - 10
        '            cb.EndText()
        '            cb.BeginText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 8)
        '        End If
        '        cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 50, k, 0)
        '        cb.ShowTextAligned(50, NomCuenta(tabla.Rows(i).Item("codigo")), 150, k, 0)
        '        '**************************
        '        tc.Clear()
        '        myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)<=" & nivel & " AND codigo like '" & tabla.Rows(i).Item("codigo") & "%' ORDER BY codigo;"
        '        myAdapter.SelectCommand = myCommand
        '        myAdapter.Fill(tc)
        '        pos = 0
        '        pos2 = 0
        '        pos3 = 0
        '        posA = 0
        '        posA2 = 0
        '        posA3 = 0
        '        For j = 1 To tc.Rows.Count - 1
        '            If k < tope Then 'NUEVA PAGINA
        '                pag = pag + 1
        '                cb.EndText()
        '                oDoc.NewPage()
        '                'cb.AddImage(img) 'IMAGEN
        '                cb.BeginText()
        '                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '                cb.SetFontAndSize(fuente, 9)
        '                BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
        '                k = k - 10
        '                cb.EndText()
        '                cb.BeginText()
        '                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '                cb.SetFontAndSize(fuente, 8)
        '            End If
        '            If VerificarSaldo(tc.Rows(j).Item("codigo"), "CA") = True Then
        '                k = k - 10
        '                cb.ShowTextAligned(50, tc.Rows(j).Item("codigo"), 50, k, 0)
        '                cb.ShowTextAligned(50, NomCuenta(tabla.Rows(i).Item("codigo")), 150, k, 0)
        '            End If
        '            If tc.Rows(j).Item("codigo").ToString.Length = nivel Then
        '                BuscarSubNiveles(tc.Rows(j).Item("codigo"), k, "CA")
        '                If n = 5 Then  'HAY NIVEL SUB CUENTA
        '                    Try
        '                        If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) < 9 Then
        '                            If pos3 > posA3 Then
        '                                BuscarSubTotal(tc.Rows(pos3).Item("codigo"), tc.Rows(pos3).Item("nivel"), tc.Rows(pos3).Item("descripcion"), k, "CA")
        '                                posA3 = pos3
        '                            End If
        '                        End If
        '                    Catch ex As Exception
        '                    End Try
        '                End If
        '                If n > 3 Then 'HAY NIVEL CUENTA
        '                    Try
        '                        If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) <= 4 Then
        '                            If pos2 > posA2 Then
        '                                BuscarSubTotal(tc.Rows(pos2).Item("codigo"), tc.Rows(pos2).Item("nivel"), tc.Rows(pos2).Item("descripcion"), k, "CA")
        '                                posA2 = pos2
        '                            End If
        '                        End If
        '                    Catch ex As Exception
        '                    End Try
        '                End If
        '                If n > 2 Then 'HAY NIVEL GRUPO
        '                    Try
        '                        If Val(tc.Rows(j).Item("codigo").ToString.Length) > Val(tc.Rows(j + 1).Item("codigo").ToString.Length) And Val(tc.Rows(j + 1).Item("codigo").ToString.Length) = 2 Then
        '                            If pos > posA Then
        '                                BuscarSubTotal(tc.Rows(pos).Item("codigo"), tc.Rows(pos).Item("nivel"), tc.Rows(pos).Item("descripcion"), k, "CA")
        '                                posA = pos
        '                            End If
        '                        End If
        '                    Catch ex As Exception
        '                    End Try
        '                End If
        '            End If
        '            'mirar nivel para posicionar el proximo
        '            If Val(tc.Rows(j).Item("codigo").ToString.Length) = 2 Then
        '                If VerificarSaldo(tc.Rows(j).Item("codigo"), "CA") = True Then
        '                    pos = j 'GRUPO
        '                End If
        '            ElseIf Val(tc.Rows(j).Item("codigo").ToString.Length) = 4 Then
        '                If VerificarSaldo(tc.Rows(j).Item("codigo"), "CA") = True Then
        '                    pos2 = j 'CUENTA
        '                End If
        '            ElseIf Val(tc.Rows(j).Item("codigo").ToString.Length) = Val(tn.Rows(0).Item("nivel4")) + 4 Then
        '                If VerificarSaldo(tc.Rows(j).Item("codigo"), "CA") = True Then
        '                    pos3 = j 'SUB CUENTA
        '                End If
        '            End If
        '        Next
        '        j = j - 1
        '        If n > 2 Then
        '            k = k - 10
        '            If n > 4 Then
        '                If pos3 > posA3 Then
        '                    BuscarSubTotal(tc.Rows(pos3).Item("codigo"), tc.Rows(pos3).Item("nivel"), tc.Rows(pos3).Item("descripcion"), k, "CA")
        '                    posA3 = pos3
        '                End If
        '            End If
        '            If n > 3 Then
        '                If pos2 > posA2 Then
        '                    BuscarSubTotal(tc.Rows(pos2).Item("codigo"), tc.Rows(pos2).Item("nivel"), tc.Rows(pos2).Item("descripcion"), k, "CA")
        '                    posA2 = pos2
        '                End If
        '            End If

        '            If pos > posA Then
        '                BuscarSubTotal(tc.Rows(pos).Item("codigo"), tc.Rows(pos).Item("nivel"), tc.Rows(pos).Item("descripcion"), k, "CA")
        '                posA = pos
        '            End If
        '        End If
        '        '***************************
        '        k = k - 10
        '        If k < 30 Then 'NUEVA PAGINA
        '            pag = pag + 1
        '            cb.EndText()
        '            oDoc.NewPage()
        '            'cb.AddImage(img) 'IMAGEN
        '            cb.BeginText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 9)
        '            BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
        '            k = k - 10
        '            cb.EndText()
        '            cb.BeginText()
        '            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '            cb.SetFontAndSize(fuente, 8)
        '        End If
        '        cb.ShowTextAligned(50, "__________________________________________________________________________________________________________________________________________________ ", 50, k + 10, 0)
        '        cb.ShowTextAligned(50, "TOTAL " & NomCuenta(tabla.Rows(i).Item("codigo")), 120, k, 0)
        '        If ChCierre.Checked = True Then
        '            taux.Clear()
        '            myCommand.CommandText = "SELECT nivel FROM selpuc WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
        '            myAdapter.SelectCommand = myCommand
        '            myAdapter.Fill(taux)
        '            BuscarSubTotal(tabla.Rows(i).Item("codigo"), taux.Rows(0).Item("nivel"), NomCuenta(tabla.Rows(i).Item("codigo")), k, "CA")
        '        Else
        '            BuscarSubTotal(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("nivel"), NomCuenta(tabla.Rows(i).Item("codigo")), k, "CA")
        '        End If
        '        k = k - 20
        '    Next
        '    k = k - 20
        '    If k < 130 Then 'NUEVA PAGINA
        '        pag = pag + 1
        '        cb.EndText()
        '        oDoc.NewPage()
        '        'cb.AddImage(img) 'IMAGEN
        '        cb.BeginText()
        '        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '        cb.SetFontAndSize(fuente, 9)
        '        BannerBG(perI & ano, perF & ano, "ESTADOS DE RESULTADOS")
        '        k = k - 20
        '    End If
        '    cb.EndText()
        '    cb.BeginText()
        '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        '    cb.SetFontAndSize(fuente, 9)
        '    ResumenBG("CA") 'RESUMEN DEL BALANCE
        '    cb.EndText()
        '    'Forzamos vaciamiento del buffer.
        '    pdfw.Flush()
        '    oDoc.Close()
        '    'ABRIR FORMULARIO DESEADO
        '    FrmReportePuc.ShowDialog()
        'Catch ex As Exception
        '    MsgBox("ERROR al momento de generar el balance de P Y G, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        'Finally
        '    cb = Nothing
        '    pdfw = Nothing
        '    oDoc = Nothing
        'End Try
    End Sub
    '**************************************************************
    Private Sub cmdGrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrafica.Click
        FrmGrafica.lbform.Text = "estados"
        FrmGrafica.ShowDialog()
    End Sub
    '**************************************************************

    Private Sub ChCierre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChCierre.CheckedChanged
        If ChCierre.Checked = True And cbfin.Text <> "12" Then
            ChCierre.Checked = False
            MsgBox("Solo para el periodo 12, verifique.   ", MsgBoxStyle.Information, "SAE Control")
        End If
    End Sub

    Private Sub cbfin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbfin.SelectedIndexChanged
        If cbfin.Text <> "12" Then
            ChCierre.Checked = False
        End If
    End Sub

    Private Sub pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf.Click
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim sql4 As String = ""
        Dim sql5 As String = ""

        Dim per As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim niv1 As String = ""
        Dim niv2 As String = ""
        Dim s1 As String = ""
        Dim dg As String = ""
        'Dim s3 As String = ""
        'Dim s4 As String = ""


        MiConexion(bda)
        Cerrar()
        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")
        per = "PERIODO: " & cbini.Text


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim t1 As New DataTable
        myCommand.Parameters.Clear()


        If nivel.Value = 2 Then
            niv1 = " 'Grupo' "
            niv2 = " 'Grupo'"
            s1 = "d"
            myCommand.CommandText = "SELECT SUM(nivel1+nivel2) AS s FROM parcontab"
        End If
        If nivel.Value = 3 Then
            niv1 = " 'Cuenta' "
            niv2 = " 'Grupo', 'Cuenta'"
            s1 = "N"
            myCommand.CommandText = "SELECT SUM(nivel1+nivel2+nivel3) AS s FROM parcontab"
        End If
        If nivel.Value = 4 Then
            niv1 = " 'Sub Cuenta' "
            niv2 = " 'Grupo', 'Cuenta', 'Sub Cuenta'"
            s1 = "N"
            myCommand.CommandText = "SELECT SUM(nivel1+nivel2+nivel3+nivel4) AS s FROM parcontab"
        End If
        If nivel.Value = 5 Then
            niv1 = " 'Auxiliar' "
            niv2 = " 'Grupo', 'Cuenta', 'Sub Cuenta','Auxiliar'"
            s1 = "N"
            myCommand.CommandText = "SELECT SUM(nivel1+nivel2+nivel3+nivel4+nivel5) AS s FROM parcontab"
        End If
        Dim ant As String = ""
        ant = CInt(cbini.Text) - 1
        If ant < 10 Then
            ant = "0" & ant
        End If
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        dg = t1.Rows(0).Item(0)

        sql = " SELECT " _
        & " 'INGRESOS' AS codart," _
        & " s.codigo as doc , s.descripcion AS nomart, s.nivel as cta_inv,  IFNULL(sum(c.saldo" & cbini.Text & "),0) as valor, sum(c.saldo" & ant & ") as vtotal, if(IFNULL(sum(c.saldo" & cbini.Text & "),0)=0,'Y','N') as tipo_it FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & cbini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '4%' " _
        & " group by s.codigo UNION " _
        & " SELECT " _
        & " 'COSTOS DE VENTAS' AS codart," _
        & " s.codigo as doc , s.descripcion AS nomart, s.nivel as cta_inv,  IFNULL(sum(c.saldo" & cbini.Text & "),0) as valor, sum(c.saldo" & ant & ") as vtotal, if(IFNULL(sum(c.saldo" & cbini.Text & "),0)=0,'Y','N') as tipo_it FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & cbini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '5%' " _
        & " group by s.codigo UNION " _
        & " SELECT " _
        & " 'GASTOS ' AS codart," _
        & " s.codigo as doc , s.descripcion AS nomart, s.nivel as cta_inv,  IFNULL(sum(c.saldo" & cbini.Text & "),0) as valor, sum(c.saldo" & ant & ") as vtotal, if(IFNULL(sum(c.saldo" & cbini.Text & "),0)=0,'Y','N') as tipo_it FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & cbini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '6%' " _
        & " group by s.codigo UNION " _
        & " SELECT " _
        & " 'COSTOS DE VENTAS' AS codart," _
        & " s.codigo as doc , s.descripcion AS nomart, s.nivel as cta_inv,  IFNULL(sum(c.saldo" & cbini.Text & "),0) as valor, sum(c.saldo" & ant & ") as vtotal, if(IFNULL(sum(c.saldo" & cbini.Text & "),0)=0,'Y','N') as tipo_it FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & cbini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '7%' " _
        & " group by s.codigo " _
        & " ORDER BY doc,codart "
        '& " UNION " _
        '& " SELECT " _
        '& " 'CUENTAS DE ORDEN ACREEDORAS' AS codart," _
        '& " s.codigo as doc , s.descripcion AS nomart, s.nivel as cta_inv,  IFNULL(sum(c.saldo" & cbini.Text & "),0) as valor, sum(c.saldo" & ant & ") as vtotal, if(IFNULL(sum(c.saldo" & cbini.Text & "),0)=0,'Y','N') as tipo_it FROM   " _
        '& " (SELECT codigo,  nivel,  saldo" & cbini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        '& " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '9%' " _
        '& " group by s.codigo" _



        '/////////////////////////////////////////////
        Dim f1 As String = ""
        Dim f2 As String = ""
        Dim f3 As String = ""
        If fcon.Checked = True Then
            f1 = "y"
        End If
        If frf.Checked = True Then
            f2 = "y"
        End If
        If frl.Checked = True Then
            f3 = "y"
        End If

        '/////////////////////////////////////////////

        Dim tabla As DataSet
        tabla = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCtResultPubl.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportContBalGen.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prs1 As New ParameterField
            Dim Prs2 As New ParameterField
            Dim Prs3 As New ParameterField
            Dim Prs4 As New ParameterField
            Dim Prf1 As New ParameterField
            Dim Prf2 As New ParameterField
            Dim Prf3 As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "per"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prs1.Name = "sp1"
            Prs1.CurrentValues.AddValue(s1.ToString)
            Prs2.Name = "dg"
            Prs2.CurrentValues.AddValue(dg.ToString)
            Prs3.Name = "t1"
            Prs3.CurrentValues.AddValue("SALDO" & cbini.Text)
            Prs4.Name = "t2"
            Prs4.CurrentValues.AddValue("SALDO" & ant)

            Prf1.Name = "f1"
            Prf1.CurrentValues.AddValue(f1)
            Prf2.Name = "f2"
            Prf2.CurrentValues.AddValue(f2)
            Prf3.Name = "f3"
            Prf3.CurrentValues.AddValue(f3)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prs1)
            prmdatos.Add(Prs2)
            prmdatos.Add(Prs3)
            prmdatos.Add(Prs4)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prf2)
            prmdatos.Add(Prf3)

            FrmReportContBalGen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportContBalGen.ShowDialog()

        Catch ex As Exception
            '  MsgBox(sql)
        End Try
    End Sub
End Class