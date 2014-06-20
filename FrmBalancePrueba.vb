Imports iTextSharp.text.pdf
Imports iTextSharp.text
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

Public Class FrmBalancePrueba
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim db, cr, totaldb, totalcr As Double
    Dim FechaRep As String
    Private Sub FrmBalancePrueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        txtci.Text = ""
        txtcf.Text = ""
        t1.Checked = True
        c1.Checked = True
        o1.Checked = True

        txtpini.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        txtpfin.Text = txtpini.Text
        cbini.Text = PerActual(0) & PerActual(1)
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
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
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        txtci.Enabled = False
        txtcf.Enabled = False
    End Sub
    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        txtci.Enabled = True
        txtcf.Enabled = True
        txtci.Focus()
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "cuentaini"
        If FrmCuentas.txtcuenta.Text = txtci.Text Then
            FrmCuentas.txtcuenta.Text = ""
        Else
            FrmCuentas.txtcuenta.Text = txtci.Text
        End If
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcf.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "cuentafin"
        If FrmCuentas.txtcuenta.Text = txtcf.Text Then
            FrmCuentas.txtcuenta.Text = txtcf.Text
        Else
            FrmCuentas.txtcuenta.Text = ""
        End If
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'pag = 0
        'FechaRep = Now.ToString
        'Me.Cursor = Cursors.WaitCursor

        balance2()
        'If t1.Checked = True Then
        '    If c1.Checked = True Then
        '        ' balance2()
        '        BalanceNormal("SELECT * FROM selpuc ORDER BY codigo;")
        '    ElseIf c2.Checked = True Then
        '        If VeriCuentas() = False Then Exit Sub
        '        ' balance2()
        '        BalanceNormal("SELECT * FROM selpuc WHERE codigo >='" & Trim(txtci.Text) & "' AND codigo <='" & Trim(txtcf.Text) & "' ORDER BY codigo;")
        '    End If
        'ElseIf t2.Checked = True Then
        '    Dim ini As Integer = 0
        '    If c1.Checked = True Then
        '        BalanceTerceros("SELECT * FROM selpuc WHERE nivel='Auxiliar' AND (debito" & cbfin.Text & "<>'0' OR credito" & cbfin.Text & "<>'0') ORDER BY codigo;")
        '    ElseIf c2.Checked = True Then
        '        If VeriCuentas() = False Then Exit Sub
        '        BalanceTerceros("SELECT * FROM selpuc WHERE codigo >='" & Trim(txtci.Text) & "' AND codigo <='" & Trim(txtcf.Text) & "' AND nivel='Auxiliar' AND (debito" & cbfin.Text & "<>'0' OR credito" & cbfin.Text & "<>'0') ORDER BY codigo;")
        '    End If
        'End If
        'Me.Cursor = Cursors.Default
    End Sub
    Function VeriCuentas()
        If txtci.Text = "" Or txtcf.Text = "" Then
            MsgBox("Verifique las cuentas, no pueden ser vacias.", MsgBoxStyle.Information, "SAE Verificación")
            Return False
            Exit Function
        ElseIf txtci.Text > txtcf.Text Then
            MsgBox("Verifique las cuentas, la inicial debe ser menor o igual a la final.", MsgBoxStyle.Information, "SAE Verificación")
            Return False
            Exit Function
        Else
            Return True
        End If
    End Function

    Private Sub t2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2.CheckedChanged
        cbfin.Text = cbini.Text

        If t2.Checked = True Then
            gb.Enabled = True
        Else
            gb.Enabled = False
        End If

        'cbfin.Enabled = False
    End Sub
    Private Sub t1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t1.CheckedChanged
        cbfin.Enabled = True
    End Sub

    '******************************************************************
    Public Sub Banner(ByVal titulo As String)
        Dim tablacomp As New DataTable
        pag = pag + 1
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        If cbini.Text = cbfin.Text Then
            cb.ShowTextAligned(50, "PERIODO: " & cbini.Text & txtpini.Text, 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & txtpfin.Text, 20, 780, 0)
        End If
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, titulo, 300, 760, 0)
        k = 750
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 20
        cb.ShowTextAligned(20, "CUENTA", 10, k, 0)
        If Trim(titulo) = "BALANCE DE PRUEBA" Then
            cb.ShowTextAligned(20, "NOMBRE", 70, k, 0)
        Else
            cb.ShowTextAligned(20, "NOMBRE DEL TERCERO", 70, k, 0)
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO ANTERIOR", 285, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 385, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO ACTUAL", 585, k, 0)
        k = k - 10
    End Sub
    Public Sub BalanceNormal(ByVal sql As String)
        Dim tope As Integer
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        totaldb = 0
        totalcr = 0
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner("BALANCE DE PRUEBA")
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '************** CUERPO ***********************************************
            tope = 80
            Dim tabla As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                If VerifcarSaldo(tabla.Rows(i).Item("codigo")) = True Then
                    k = k - 10
                    If k < tope Then 'NUEVA PAGINA
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        Banner("BALANCE DE PRUEBA")
                        k = k - 10
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                    End If
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 10, k, 0)
                    SaldosInicial(tabla.Rows(i).Item("codigo"))
                    Movimientos(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("nivel"))
                    SaldosActual(tabla.Rows(i).Item("codigo"))
                    descripcion(tabla.Rows(i).Item("descripcion"), 25)
                End If
            Next
            '**************** FIN CUERPO *******************************
            '****************  TOTALES *******************************
            k = k - 10
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------- ", 270, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "TOTALES", 70, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totaldb), 385, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalcr), 485, k, 0)
            '******------------ FIN -----------***************
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
    Public Sub SaldosInicial(ByVal cuenta As String)
        Dim tabla As New DataTable
        Dim Saldo As String
        Dim suma As Double
        '///////////CALCULAR SALDO INICIAL //////////////////////
        If cbini.Text = "00" Then
            suma = 0
        Else
            Saldo = (Val(cbini.Text) - 1)
            If Saldo < 10 Then
                Saldo = "saldo0" & Saldo
            Else
                Saldo = "saldo" & Saldo
            End If
            myCommand.CommandText = "SELECT sum(" & Saldo & ") FROM selpuc WHERE codigo like '" & cuenta & "%' and nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                suma = tabla.Rows(0).Item(0)
            Catch ex As Exception
                suma = 0
            End Try
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 285, k, 0)
    End Sub
    Public Sub Movimientos(ByVal cuenta As String, ByVal nivel As String)
        Dim Saldo As String
        Dim dbt, crt As Double
        dbt = 0
        crt = 0
        For j = Val(cbini.Text) To Val(cbfin.Text)
            If j < 10 Then
                Saldo = "sum(debito0" & j & "),sum(credito0" & j & ")"
            Else
                Saldo = "sum(debito" & j & "),sum(credito" & j & ")"
            End If
            movi("SELECT " & Saldo & " FROM selpuc WHERE codigo like '" & cuenta & "%' and nivel='Auxiliar';")
            dbt = dbt + db
            crt = crt + cr
        Next
        If dbt Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(dbt), 385, k, 0)
        End If
        If crt Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(crt), 485, k, 0)
        End If
        If nivel = "Auxiliar" Then
            totaldb = totaldb + dbt
            totalcr = totalcr + crt
        End If
    End Sub
    Public Sub movi(ByVal sql)
        Dim tabla As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        'debito
        Try
            db = CDbl(tabla.Rows(0).Item(0).ToString)
        Catch ex As Exception
            db = 0
        End Try
        'credito
        Try
            cr = CDbl(tabla.Rows(0).Item(1).ToString)
        Catch ex As Exception
            cr = 0
        End Try
    End Sub
    Public Sub SaldosActual(ByVal cuenta As String)
        Dim tabla As New DataTable
        Dim Saldo As String
        Dim suma As Double
        '///////////CALCULAR SALDO INICIAL //////////////////////
        Saldo = (Val(cbfin.Text))
        If Saldo < 10 Then
            Saldo = "saldo0" & Saldo
        Else
            Saldo = "saldo" & Saldo
        End If
        myCommand.CommandText = "SELECT sum(" & Saldo & ") FROM selpuc WHERE codigo like '" & cuenta & "%' and nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            suma = tabla.Rows(0).Item(0)
        Catch ex As Exception
            suma = 0
        End Try
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(suma), 585, k, 0)
    End Sub
    Public Sub descripcion(ByVal cad2 As String, ByVal tope As Integer)
        Dim cad As String
        If cad2.Length > tope Then
            cad = ""
            For i = 0 To cad2.Length - 1
                cad = cad & cad2(i)
                If cad.Length > (tope - 3) Then
                    If cad2(i) <> " " Then
                        If (i + 1) < cad2.Length - 1 Then
                            If cad2(i + 1) <> " " Then
                                cad = cad & "-"
                            End If
                        End If
                    End If
                    cb.ShowTextAligned(50, Trim(cad), 70, k, 0)
                    cad = ""
                    k = k - 10
                End If
            Next
            cb.ShowTextAligned(50, Trim(cad), 70, k, 0)

        Else
            cb.ShowTextAligned(50, Trim(cad2), 70, k, 0)
        End If
    End Sub

    Function VerifcarSaldo2(ByVal cuenta As String)
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT SUM(debito" & cbfin.Text & "),SUM(credito" & cbfin.Text & ") FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            If tabla.Rows(0).Item(0) <> 0 Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
        End Try
        Try
            If tabla.Rows(0).Item(1) <> 0 Then
                Return True
                Exit Function
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function
    Function VerifcarSaldo(ByVal cuenta As String)
        Dim suma, aux As Double
        Dim condicion, per As String
        condicion = ""
        suma = 0
        'For i = 0 To Val(PerActual(0) & PerActual(1))
        Dim i As Integer '= Val(PerActual(0) & PerActual(1))
        'If i < 10 Then
        '    per = "0" & i
        'Else
        '    per = i
        'End If
        per = cbfin.Text
        Dim tabla, tabla2 As New DataTable
        tabla.Clear()
        ' despues de cierre o normal
        i = Val(cbini.Text) - 1
        If cbini.Text = "00" Then i = 0
        Dim per_a As String 'periodo anterior
        If i < 10 Then
            per_a = "0" & i
        Else
            per_a = i
        End If
        myCommand.CommandText = "SELECT SUM(saldo" & per_a & ") FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            aux = tabla.Rows(0).Item(0)
        Catch ex As Exception
            aux = 0
        End Try
        suma = aux
        If suma <> 0 Then
            Return True
            Exit Function
        End If
        tabla.Clear()
        myCommand.CommandText = "SELECT SUM(debito" & per & "),SUM(credito" & per & ") FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        tabla2.Clear()
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Try
            Try
                aux = tabla2.Rows(0).Item(0)
            Catch ex As Exception
                aux = 0
            End Try
            suma = aux
        Catch ex As Exception
        End Try
        If suma <> 0 Then
            Return True
            Exit Function
        End If
        Try
            Try
                aux = tabla2.Rows(0).Item(1)
            Catch ex As Exception
                aux = 0
            End Try
            suma = aux
        Catch ex As Exception
        End Try
        If suma <> 0 Then
            Return True
            Exit Function
        End If
        Return False
    End Function
    '**************** POR TERCEROS
    Public Sub BalanceTerceros(ByVal sql As String)
        Dim tope As Integer
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim si, tsi As Double
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner("BALANCE DE PRUEBA POR TERCERO")
            '************** CUERPO ***********************************************
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            tope = 80
            totaldb = 0
            totalcr = 0
            Dim tabla, tcuenta As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim s As String = ""
            Dim p As String = ""
            tsi = 0
            For i = 0 To tabla.Rows.Count - 1
                tcuenta.Clear()
                For w = 0 To Val(cbfin.Text)
                    If w < 10 Then
                        p = "0" & w
                    Else
                        p = w
                    End If
                    If w = 0 Then
                        s = "SELECT DISTINCT(d.nit),t.apellidos,t.nombre FROM documentos" & p & " d LEFT JOIN (terceros t) ON d.nit=t.nit WHERE d.codigo='" & tabla.Rows(i).Item("codigo") & "'  "
                    Else
                        s = s & " UNION SELECT DISTINCT(d.nit),t.apellidos,t.nombre FROM documentos" & p & " d LEFT JOIN (terceros t) ON d.nit=t.nit WHERE d.codigo='" & tabla.Rows(i).Item("codigo") & "' "
                    End If
                Next
                s = s & " ORDER BY nombre,apellidos;"
                's = "SELECT DISTINCT(d.nit),t.apellidos,t.nombre FROM documentos" & p & " d LEFT JOIN (terceros t) ON d.nit=t.nit WHERE d.codigo='" & tabla.Rows(i).Item("codigo") & "'  "
                myCommand.CommandText = s
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcuenta)
                If tcuenta.Rows.Count > 0 Then
                    k = k - 20
                    If k < tope Then 'NUEVA PAGINA
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        Banner("BALANCE DE PRUEBA POR TERCERO")
                        k = k - 10
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                    End If
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    '*******************************************
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 10, k, 0)
                    descripcion(tabla.Rows(i).Item("descripcion"), 50)
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    For j = 0 To tcuenta.Rows.Count - 1
                        k = k - 10
                        If k < tope Then 'NUEVA PAGINA
                            cb.EndText()
                            oDoc.NewPage()
                            cb.BeginText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 9)
                            Banner("BALANCE DE PRUEBA POR TERCERO")
                            k = k - 10
                            cb.EndText()
                            cb.BeginText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 8)
                        End If
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tcuenta.Rows(j).Item("nit"), 15, k, 0)
                        descripcion(tcuenta.Rows(j).Item("nombre") & " " & tcuenta.Rows(j).Item("apellidos"), 27)
                        si = CDbl(SaldoInicial(tabla.Rows(i).Item("codigo"), tcuenta.Rows(j).Item("nit")))
                        MovimientosTerceros(tabla.Rows(i).Item("codigo"), tcuenta.Rows(j).Item("nit"), si)
                    Next
                    cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------", 300, k - 5, 0)
                    k = k - 15
                    cb.ShowTextAligned(50, "SUBTOTAL", 20, k, 0)
                    Movimientos(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("nivel"))
                    SaldosActual(tabla.Rows(i).Item("codigo"))
                    descripcion(tabla.Rows(i).Item("descripcion"), 50)
                End If
            Next
            '**************** FIN CUERPO *******************************
            k = k - 10
            cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "TOTALES", 70, k, 0)
            'If totaldb = 0 Then
            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 385, k, 0)
            'Else
            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totaldb), 385, k, 0)
            'End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totaldb), 385, k, 0)
            'If totalcr = 0 Then
            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 485, k, 0)
            'Else
            '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(totalcr), 2), "0,00.00"), 485, k, 0)
            'End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalcr), 485, k, 0)
            '******------------ FIN -----------***************
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
    Public Sub MovimientosTerceros(ByVal cuenta As String, ByVal nit As String, ByVal si As Double)
        Dim tabla As New DataTable
        Dim dbt, crt As Double
        Dim sql As String = ""
        Dim per As String = ""
        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            If i = Val(cbini.Text) Then
                sql = "SELECT SUM(debito), SUM(credito),concat('" & per & " ') AS per FROM documentos" & per & " WHERE codigo='" & cuenta & "' AND nit='" & nit & "' "
            Else
                sql = sql & " UNION SELECT SUM(debito), SUM(credito),concat('" & per & " ') AS per FROM documentos" & per & " WHERE codigo='" & cuenta & "' AND nit='" & nit & "' "
            End If
        Next
        sql = sql + ";"
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        dbt = 0
        crt = 0
        For i = 0 To tabla.Rows.Count - 1
            Try
                dbt = dbt + CDbl(tabla.Rows(i).Item(0))
            Catch ex As Exception
                'dbt = 0
            End Try
            Try
                crt = crt + CDbl(tabla.Rows(i).Item(1))
            Catch ex As Exception
                'crt = 0
            End Try
        Next
        If dbt Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(dbt), 2), "0,00.00"), 385, k, 0)
        End If
        If crt Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(crt), 2), "0,00.00"), 485, k, 0)
        End If
        If (dbt - crt + si) <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(dbt - crt + si), 2), "0,00.00"), 585, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
        End If
    End Sub
    Function SaldoInicial(ByVal cuenta As String, ByVal nit As String)
        Dim tabla As New DataTable
        Dim dbt As Double = 0
        Dim db As Double = 0
        Dim sql As String = ""
        Dim per As String = ""
        Dim fin As Integer = 0
        fin = Val(cbini.Text)
        If fin = 0 Then
            Return 0
            Exit Function
        End If
        fin = fin - 1
        For i = 0 To fin
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            If i = 0 Then
                sql = "SELECT SUM(debito-credito) as saldo,concat('" & per & " ') AS per FROM documentos" & per & " WHERE codigo='" & cuenta & "' AND nit='" & nit & "' "
            Else
                sql = sql & " UNION SELECT SUM(debito-credito) as saldo,concat('" & per & " ') AS per FROM documentos" & per & " WHERE codigo='" & cuenta & "' AND nit='" & nit & "' "
            End If
        Next
        sql = sql + ";"
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            Try
                db = CDbl(tabla.Rows(i).Item(0).ToString)
            Catch ex As Exception
                db = 0
            End Try
            dbt = dbt + db
        Next
        If dbt Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(dbt), 285, k, 0)
        End If
        Return dbt
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        balance2()

    End Sub

    Public Sub balance2()
        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim i As Integer = 0
        Dim tt As String = ""

        Dim saldoI As String = ""
        Dim saldoI_s As String = ""
        Dim debito As String = ""
        Dim credito As String = ""
        Dim debito_s As String = ""
        Dim credito_s As String = ""
        Dim saldoF As String = ""
        Dim saldoF_s As String = ""
        Dim T_debito As Double
        Dim T_credito As Double

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text
        tt = "BALANCE DE PRUEBA"
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")


        Dim pp As String = ""

        If Val(cbini.Text) - 1 < 10 Then
            saldoI = "c.saldo0" & cbini.Text - 1
            saldoI_s = "saldo0" & cbini.Text - 1
        Else
            saldoI = "c.saldo" & cbini.Text - 1
            saldoI_s = "saldo" & cbini.Text - 1
        End If
        saldoF = "c.saldo" & cbini.Text
        saldoF_s = "saldo" & cbini.Text

        '.........

        For i = Val(cbini.Text) To Val(cbfin.Text)

            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = cbini.Text Then
                debito = debito & "c.debito" & p
                credito = credito & "c.credito" & p
                debito_s = debito_s & "debito" & p
                credito_s = credito_s & "credito" & p
            Else
                debito = debito & "+ c.debito" & p
                credito = credito & "+ c.credito" & p
                debito_s = debito_s & ", debito" & p
                credito_s = credito_s & ", credito" & p

            End If
        Next

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        MiConexion(bda)

        ' ................ INFORME NORMAL
        If t1.Checked = Enabled Then

            Dim rg As String = ""
            Dim rg2 As String = ""
            If c2.Checked = True Then
                rg = " WHERE s.codigo between '" & txtci.Text & "' and '" & txtcf.Text & "' "
                rg2 = " AND codigo between '" & txtci.Text & "' and '" & txtcf.Text & "' "
            End If

            sql = " SELECT s.codigo AS observ,s.descripcion as descrip, SUM(" & saldoI & ") as subtotal, sum(" & debito & ") as v1, sum(" & credito & ") as v2,  (SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")) as total FROM  " _
            & " (SELECT codigo, " & saldoI_s & ", nivel, " & debito_s & ", " & credito_s & ", " & saldoF_s & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s " _
            & " on (c.codigo LIKE CONCAT(s.codigo,'%'))  " & rg & "  group by s.codigo "

            sql2 = "SELECT IFNULL(SUM(" & debito & "),0), IFNULL(SUM(" & credito & "),0)  FROM selpuc c WHERE nivel =  'Auxiliar' " & rg2 & " "

            Dim tabla_p As DataTable
            tabla_p = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql2
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_p)

            If tabla_p.Rows.Count > 0 Then
                T_debito = tabla_p.Rows(0).Item(0).ToString
                T_credito = tabla_p.Rows(0).Item(1).ToString
            Else
                T_debito = 0
                T_credito = 0
            End If
           


            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContBalPru.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4

            FrmReportContBalPru.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtitulo As New ParameterField

                Dim PrTC As New ParameterField
                Dim PrTD As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                PrTD.Name = "totalD"
                PrTD.CurrentValues.AddValue(T_debito)

                PrTC.Name = "totalC"
                PrTC.CurrentValues.AddValue(T_credito)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(PrTD)
                prmdatos.Add(PrTC)

                FrmReportContBalPru.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportContBalPru.ShowDialog()

            Catch ex As Exception
                MsgBox("Error al Generar el Informe " & ex.ToString)
            End Try


        End If
        '.......... FIN INFORME NORMAL



        '..........POR TERCERO
        Try

            If t2.Checked = True Then

                Dim rang As String = ""
                Dim ord As String = ""
                If c2.Checked = True Then
                    rang = " AND s.codigo between '" & txtci.Text & "' and '" & txtcf.Text & "' AND  d.codigo between '" & txtci.Text & "' and '" & txtcf.Text & "' "
                End If
                If o1.Checked = True Then
                    sql = " SELECT  codigo as nitc, descripcion as observ, nit as nitv, nombre as descrip, SUM(d1-c1) AS subtotal, SUM(d2) as v1, SUM(c2) as v2, (SUM(d1-c1)+SUM(d2)-SUM(c2)) AS total FROM ( "
                Else
                    sql = " SELECT  codigo as nitv, descripcion as descrip, nit as nitc, nombre as observ, SUM(d1-c1) AS subtotal, SUM(d2) as v1, SUM(c2) as v2, (SUM(d1-c1)+SUM(d2)-SUM(c2)) AS total FROM ( "
                End If

                For i = 0 To Val(cbfin.Text)

                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If p < cbini.Text Then
                        sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, d.debito AS d1, d.credito AS c1, 0 AS d2, 0 AS c2 " _
                          & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                          & " from selpuc s, documentos" & p & " d ,terceros t WHERE  d.nit = t.nit and d.`codigo`= s.`codigo`  " & rang & "  UNION "
                    Else
                        If p <> cbfin.Text Then
                            sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, 0 AS d1, 0 AS c1, d.debito AS d2, d.credito AS c2 " _
                             & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                             & " from selpuc s, documentos" & p & " d ,terceros t WHERE  d.nit = t.nit and d.`codigo`= s.`codigo`  " & rang & " UNION    "
                        Else
                            sql = sql & " SELECT  d.codigo,d.item, d.dia, d.doc, d.tipodoc, d.periodo, 0 AS d1, 0 AS c1, d.debito AS d2, d.credito AS c2 " _
                            & " , s.descripcion, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) As nombre " _
                            & " from selpuc s, documentos" & p & " d,terceros t WHERE  d.nit = t.nit and d.`codigo`= s.`codigo`  " & rang & "   "
                        End If
                    End If
                Next


                If o1.Checked = True Then
                    sql = sql & " ) as cons GROUP BY nit,codigo ORDER by  codigo,nombre "
                Else
                    sql = sql & " ) as cons GROUP BY nit,codigo ORDER by  nombre, codigo "
                End If
               

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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContBalPruT.rpt")
                CrReport.SetDataSource(tabla)
                Try
                    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                Catch ex As Exception
                End Try
                FrmReportContBalPruT.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim Prtitulo As New ParameterField

                    Dim PrTC As New ParameterField
                    Dim PrTD As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nit.ToString)

                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    Prtitulo.Name = "tit"
                    Prtitulo.CurrentValues.AddValue(tt.ToString)


                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(Prtitulo)


                    FrmReportContBalPruT.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportContBalPruT.ShowDialog()

                Catch ex As Exception
                    MsgBox(sql)
                End Try

            End If
            '.........FIN .POR TERCERO
        Catch ex As Exception
            MsgBox("Error al Generar el Informe ," & ex.ToString)
        End Try
        conexion.Close()
        Cerrar()
    End Sub

    Private Sub txtci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtci.TextChanged

    End Sub
End Class