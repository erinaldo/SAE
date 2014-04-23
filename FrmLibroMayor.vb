Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmLibroMayor
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim tdi, tci, tdm, tcm, tda, tca As Double
    Dim MiPer As String
    Dim FechaRep As String
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            ' GenerarLibroMayor(PerActual(0) & PerActual(1))
            informe()
        Catch ex As Exception

        End Try

    End Sub
    '**************************************************************
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    'inicio libro mayor
    Public Sub GenerarLibroMayor(ByVal per As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Try
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            Dim i As Integer
            Dim dbi, cdi, cad, cad2 As String
            If (Val(per) - 1) < 10 Then
                dbi = "debito0" & (Val(per) - 1)
                cdi = "credito0" & (Val(per) - 1)
            Else
                dbi = "debito" & per
                cdi = "credito" & per
            End If
            FechaRep = Now.ToString
            Me.Cursor = Cursors.WaitCursor
            Dim tabla, tablacomp, tablames, tsaldo As New DataTable
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            '***************************
            pag = 1
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            BannerLM(tablacomp.Rows(0).Item("descripcion"), tablacomp.Rows(0).Item("nit"), "PERIODO: " & PerActual, "LIBRO MAYOR Y DE BALANCES")
            k = k - 10
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            tdi = 0
            tci = 0
            tdm = 0
            tcm = 0
            tda = 0
            tca = 0
            '----------------- ACTIVO -------------------------------
            For j = 1 To 5
                tabla.Clear()
                If j = 1 Then
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=" & Niveles(na.Value) & " AND tipo='Activo' ORDER BY codigo;"
                ElseIf j = 2 Then
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=" & Niveles(np.Value) & " AND tipo='Pasivo' ORDER BY codigo;"
                ElseIf j = 3 Then
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=" & Niveles(nc.Value) & " AND tipo='Capital' ORDER BY codigo;"
                ElseIf j = 4 Then
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=" & Niveles(ni.Value) & " AND tipo='Ingresos' ORDER BY codigo;"
                Else
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE LENGTH(codigo)=" & Niveles(ne.Value) & " AND tipo='Egresos' ORDER BY codigo;"
                End If
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                For i = 0 To tabla.Rows.Count - 1
                    If VerifcarSaldo(tabla.Rows(i).Item("codigo")) = True Then
                        k = k - 10
                        If k < 40 Then 'NUEVA PAGINA
                            pag = pag + 1
                            cb.EndText()
                            oDoc.NewPage()
                            cb.BeginText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 9)
                            BannerLM(tablacomp.Rows(0).Item("descripcion"), tablacomp.Rows(0).Item("nit"), "PERIODO: " & PerActual, "LIBRO MAYOR Y DE BALANCES")
                            k = k - 10
                            cb.EndText()
                            cb.BeginText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 8)
                        End If
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 10, k, 0)
                        If tabla.Rows(i).Item("descripcion").ToString.Length > 18 Then
                            cad = ""
                            cad2 = tabla.Rows(i).Item("descripcion")
                            For w = 0 To 17
                                cad = cad & cad2(w)
                            Next
                            cb.ShowTextAligned(50, cad, 70, k, 0)
                        Else
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("descripcion"), 70, k, 0)
                        End If
                        BuscarSaldoInicial(tabla.Rows(i).Item("codigo"))
                        BuscarMovimiento(tabla.Rows(i).Item("codigo"))
                        BuscarSaldoActual(tabla.Rows(i).Item("codigo"))
                    End If
                Next
            Next
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 70, k + 10, 0)
            cb.ShowTextAligned(50, "SUMAS TOTALES ", 70, k, 0)
            If tdi <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tdi), 235, k, 0)
            If tci <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tci), 305, k, 0)
            If tdm <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tdm), 375, k, 0)
            If tcm <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tcm), 445, k, 0)
            If tda <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tda), 515, k, 0)
            If tca <> 0 Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tca), 585, k, 0)
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
            Me.Cursor = Cursors.Default
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex2 As Exception
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
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub BannerLM(ByVal comp As String, ByVal nit As String, ByVal periodo As String, ByVal tipo As String)
        cb.ShowTextAligned(50, comp, 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & nit, 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, periodo, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
        cb.ShowTextAligned(50, tipo, 230, 760, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        k = 730
        cb.ShowTextAligned(50, "CUENTA ", 10, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCIÓN ", 70, k, 0)
        cb.ShowTextAligned(50, "SALDO ANTERIOR ", 210, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 235, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 305, k, 0)
        cb.ShowTextAligned(50, "MOVIMIENTOS MES ", 345, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 375, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 445, k, 0)
        cb.ShowTextAligned(50, "SALDO ACTUAL ", 490, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 515, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    '**************************************************************
    Public Sub BuscarSaldoInicial(ByVal cuenta As String)
        Try
            Dim per, saldo As String
            Dim ts As New DataTable
            Dim db, cd, debito, credito As Double
            per = PerActual(0) & PerActual(1)
            db = 0
            cd = 0
            debito = 0
            credito = 0
            ' For i = 0 To (Val(per) - 1)
            Dim i As Integer = Val(per) - 1
            If i < 10 Then
                saldo = "0" & i
            Else
                saldo = i
            End If
            '****************************            
            ts.Clear()
            myCommand.CommandText = "SELECT SUM(saldo" & saldo & ") FROM selpuc WHERE codigo like'" & cuenta & "%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ts)
            Try
                debito = ts.Rows(0).Item(0)
            Catch ex As Exception
                debito = 0
            End Try
            Try
                credito = ts.Rows(0).Item(1)
            Catch ex As Exception
                credito = 0
            End Try
            db = db + debito
            cd = cd + credito
            'Next
            Dim dife As Double = db - cd
            If dife > 0 Then
                tdi = tdi + dife
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(dife), 235, k, 0)
            ElseIf dife < 0 Then
                tci = tci + dife
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(dife), 305, k, 0)
            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Sub BuscarMovimiento(ByVal cuenta As String)
        Dim per As String
        Dim tablames As New DataTable
        tablames.Clear()
        per = PerActual(0) & PerActual(1)
        If ChCierre.Checked = True Then
            myCommand.CommandText = "SELECT SUM(debito), SUM(credito) FROM documentos12 WHERE codigo like'" & cuenta & "%' AND tipodoc<>'CA';"
        Else
            myCommand.CommandText = "SELECT SUM(debito" & per & "), SUM(credito" & per & ") FROM selpuc WHERE codigo like'" & cuenta & "%' AND nivel='Auxiliar';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablames)
        Try
            If tablames.Rows(0).Item(0) <> "0" Then 'debito mes
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tablames.Rows(0).Item(0)), 2), "0,00.00"), 375, k, 0)
                tdm = tdm + tablames.Rows(0).Item(0)
            End If
        Catch ex As Exception
        End Try
        Try
            If tablames.Rows(0).Item(1) <> "0" Then 'credito mes
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tablames.Rows(0).Item(1)), 2), "0,00.00"), 445, k, 0)
                tcm = tcm + tablames.Rows(0).Item(1)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarSaldoActual(ByVal cuenta As String)
        Dim per As String
        Dim tablames As New DataTable
        tablames.Clear()
        per = PerActual(0) & PerActual(1)
        If ChCierre.Checked = True Then
            Try
                Dim saldo_a As Double = 0
                myCommand.CommandText = "SELECT SUM(saldo11) as s FROM selpuc WHERE codigo like'" & cuenta & "%' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablames)
                Try
                    saldo_a = (tablames.Rows(0).Item(0))
                Catch ex As Exception
                    saldo_a = 0
                End Try
                tablames.Clear()
                myCommand.CommandText = "SELECT SUM(debito-credito) as s FROM documentos12 WHERE codigo like'" & cuenta & "%' AND tipodoc<>'CA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablames)
                Try
                    saldo_a = (saldo_a + tablames.Rows(0).Item(0))
                Catch ex As Exception
                End Try
                If saldo_a > 0 Then 'debito actual
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(saldo_a), 515, k, 0)
                    tda = (tda + saldo_a)
                ElseIf saldo_a < 0 Then 'credito actual
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(saldo_a), 585, k, 0)
                    tca = (tca + saldo_a)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            myCommand.CommandText = "SELECT SUM(saldo" & per & ") as s FROM selpuc WHERE codigo like'" & cuenta & "%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablames)
            Try
                If tablames.Rows(0).Item(0) > 0 Then 'debito actual
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablames.Rows(0).Item(0)), 515, k, 0)
                    tda = (tda + tablames.Rows(0).Item(0))
                ElseIf tablames.Rows(0).Item(0) < 0 Then 'credito actual
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablames.Rows(0).Item(0)), 585, k, 0)
                    tca = (tca + tablames.Rows(0).Item(0))
                End If
            Catch ex As Exception
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(0), 515, k, 0)
            End Try
        End If
    End Sub
    '**************************************************************
    Function VerifcarSaldo(ByVal cuenta As String)
        Dim suma, aux As Double
        Dim condicion, per As String
        condicion = ""
        suma = 0
        'For i = 0 To Val(PerActual(0) & PerActual(1))
        Dim i As Integer = Val(PerActual(0) & PerActual(1))
        If i < 10 Then
            per = "0" & i
        Else
            per = i
        End If
        Dim tabla, tabla2 As New DataTable
        tabla.Clear()
        If ChCierre.Checked = True Then ' antes de cierre
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM documentos12 WHERE codigo like '" & cuenta & "%' AND tipodoc<>'CA';"
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
            myCommand.CommandText = "SELECT SUM(saldo11) as s FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        Else ' despues de cierre o normal
            i = Val(PerActual(0) & PerActual(1)) - 1
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
            myCommand.CommandText = "SELECT SUM(saldo" & per & ") FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
        End If
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
        Else
            Return False
        End If
    End Function
    Function Niveles(ByVal n As Integer)
        Dim tn As New DataTable
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Try
            If n = 1 Then
                Return (Val(tn.Rows(0).Item("nivel1")))
            ElseIf n = 2 Then
                Return (Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")))
            ElseIf n = 3 Then
                Return (Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3")))
            ElseIf n = 4 Then
                Return (Val(tn.Rows(0).Item("nivel1")) + Val(tn.Rows(0).Item("nivel2")) + Val(tn.Rows(0).Item("nivel3")) + Val(tn.Rows(0).Item("nivel4")))
            ElseIf n = 5 Then
                Return (Val(tn.Rows(0).Item("longitud")))
            Else
                MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
            Return 0
        End Try
    End Function
    'fin libro mayor
    Private Sub ChCierre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChCierre.CheckedChanged
        If ChCierre.Checked = True And (PerActual(0) & PerActual(1)) <> "12" Then
            MsgBox("Opcion permitida solo en el periodo 12", MsgBoxStyle.Information, "SAE Control")
            ChCierre.Checked = False
        End If
    End Sub
    Private Sub informe()
        Try



            Dim nom As String = ""
            Dim nitp As String = ""
            Dim per As String = ""
            Dim p As String = ""
            Dim pA As String = ""


            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            p = PerActual(0) & PerActual(1)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
            per = "PERIODO: " & PerActual


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            Dim sql As String = ""
            Dim act As String = ""
            Dim pas As String = ""
            Dim pat As String = ""
            Dim ing As String = ""
            Dim gast As String = ""


            pA = p - 1
            If pA < 10 Then
                pA = "0" & pA
            End If

            Select Case na.Value
                Case "5"
                    act = "Auxiliar"
                Case "4"
                    act = "Sub Cuenta"
                Case "3"
                    act = "Cuenta"
                Case "2"
                    act = "Grupo"
            End Select

            Select Case np.Value
                Case "5"
                    pas = "Auxiliar"
                Case "4"
                    pas = "Sub Cuenta"
                Case "3"
                    pas = "Cuenta"
                Case "2"
                    pas = "Grupo"
            End Select

            Select Case nc.Value
                Case "5"
                    pat = "Auxiliar"
                Case "4"
                    pat = "Sub Cuenta"
                Case "3"
                    pat = "Cuenta"
                Case "2"
                    pat = "Grupo"
            End Select

            Select Case ni.Value
                Case "5"
                    ing = "Auxiliar"
                Case "4"
                    ing = "Sub Cuenta"
                Case "3"
                    ing = "Cuenta"
                Case "2"
                    ing = "Grupo"
            End Select

            Select Case ne.Value
                Case "5"
                    gast = "Auxiliar"
                Case "4"
                    gast = "Sub Cuenta"
                Case "3"
                    gast = "Cuenta"
                Case "2"
                    gast = "Grupo"
            End Select


            If p <> 12 Then
                sql = "  SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '1%' and s.nivel = '" & act & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '8%' and s.nivel = '" & act & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '2%' and s.nivel = '" & pas & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '3%' and s.nivel = '" & pat & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '4%' and s.nivel = '" & ing & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '5%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '6%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '7%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " SUM(c.sd) as saldo00, " _
                & " SUM(c.sc) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " SUM(c.d) as debito01, " _
                & " SUM(c.c) as credito01 " _
                & " FROM (SELECT codigo, " _
                & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
                & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '9%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo "
            Else

                ' ......  periodo 12 NO generar antes de cierre
                If ChCierre.Checked = False Then
                    'sql = "  SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '1%' and s.nivel = '" & act & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& "  SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '8%' and s.nivel = '" & act & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& "  SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '2%' and s.nivel = '" & pas & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& "  SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '3%' and s.nivel = '" & pat & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& " SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '4%' and s.nivel = '" & ing & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& " SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '5%' and s.nivel = '" & gast & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& " SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '6%' and s.nivel = '" & gast & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& " SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '7%' and s.nivel = '" & gast & "' " _
                    '& " group by s.codigo " _
                    '& " UNION " _
                    '& " SELECT s.codigo,s.descripcion ," _
                    '& " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    '& " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    '& " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    '& " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    '& " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    '& " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    '& " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    '& " where s.codigo like '9%' and s.nivel = '" & gast & "' " _
                    '& " group by s.codigo "
                    sql = "  SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '1%' and s.nivel = '" & act & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & "  SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '8%' and s.nivel = '" & act & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & "  SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '2%' and s.nivel = '" & pas & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & "  SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '3%' and s.nivel = '" & pat & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & " SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '4%' and s.nivel = '" & ing & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & " SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '5%' and s.nivel = '" & gast & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & " SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '6%' and s.nivel = '" & gast & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & " SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '7%' and s.nivel = '" & gast & "' " _
               & " group by s.codigo " _
               & " UNION " _
               & " SELECT s.codigo,s.descripcion ," _
               & " SUM(c.sd) as saldo00, " _
               & " SUM(c.sc) as saldo01,  " _
               & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
               & " SUM(c.d) as debito01, " _
               & " SUM(c.c) as credito01 " _
               & " FROM (SELECT codigo, " _
               & " IF (saldo" & pA & "> 0, saldo" & pA & ", 0) AS sd, IF (saldo" & pA & "< 0, saldo" & pA & ", 0) AS sc, nivel, debito" & p & ", credito" & p & ", " _
               & " IF (saldo" & p & "> 0, saldo" & p & ", 0) AS d, IF (saldo" & p & "< 0, saldo" & p & ", 0) AS c  from selpuc  where nivel =  'Auxiliar' ) as c " _
               & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
               & " where s.codigo like '9%' and s.nivel = '" & gast & "' " _
               & " group by s.codigo "
                Else

                    ' ......  periodo 12 generar antes de cierre

                    sql = " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '1%' and s.nivel = '" & act & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '2%' and s.nivel = '" & pas & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '3%' and s.nivel = '" & pat & "' group by s.codigo UNION  " _
                     & " SELECT s.codigo,s.descripcion , " _
                   & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '4%' and s.nivel = '" & ing & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '5%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '6%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '7%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " SUM(c.sd) as saldo00,  " _
                    & " SUM(c.sc) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.sd)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.sc)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, " _
                    & " IF (saldo11 > 0, saldo11, 0) AS sd, IF (saldo11 < 0, saldo11, 0) AS sc,  nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '9%' and s.nivel = '" & gast & "' group by s.codigo "
                End If
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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportLibroMay.rpt")
            CrReport.SetDataSource(tabla)
            Try
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportLibroMay.CrystalReportViewer1.ReportSource = CrReport
            Catch ex As Exception
            End Try
            

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtipo As New ParameterField
                Dim Prtt As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportLibroMay.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportLibroMay.ShowDialog()

            Catch ex As Exception
            End Try
            conexion.Close()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

        

            Dim nom As String = ""
            Dim nitp As String = ""
            Dim per As String = ""
            Dim p As String = ""
            Dim pA As String = ""


            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            p = PerActual(0) & PerActual(1)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
            per = "PERIODO: " & PerActual


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            Dim sql As String = ""
            Dim act As String = ""
            Dim pas As String = ""
            Dim pat As String = ""
            Dim ing As String = ""
            Dim gast As String = ""


            pA = p - 1
            If pA < 10 Then
                pA = "0" & pA
            End If

            Select Case na.Value
                Case "5"
                    act = "Auxiliar"
                Case "4"
                    act = "Sub Cuenta"
                Case "3"
                    act = "Cuenta"
                Case "2"
                    act = "Grupo"
            End Select

            Select Case np.Value
                Case "5"
                    pas = "Auxiliar"
                Case "4"
                    pas = "Sub Cuenta"
                Case "3"
                    pas = "Cuenta"
                Case "2"
                    pas = "Grupo"
            End Select

            Select Case nc.Value
                Case "5"
                    pat = "Auxiliar"
                Case "4"
                    pat = "Sub Cuenta"
                Case "3"
                    pat = "Cuenta"
                Case "2"
                    pat = "Grupo"
            End Select

            Select Case ni.Value
                Case "5"
                    ing = "Auxiliar"
                Case "4"
                    ing = "Sub Cuenta"
                Case "3"
                    ing = "Cuenta"
                Case "2"
                    ing = "Grupo"
            End Select

            Select Case ne.Value
                Case "5"
                    gast = "Auxiliar"
                Case "4"
                    gast = "Sub Cuenta"
                Case "3"
                    gast = "Cuenta"
                Case "2"
                    gast = "Grupo"
            End Select


            If p <> 12 Then
                sql = "  SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '1%' and s.nivel = '" & act & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '8%' and s.nivel = '" & act & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '2%' and s.nivel = '" & pas & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & "  SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '3%' and s.nivel = '" & pat & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '4%' and s.nivel = '" & ing & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '5%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '6%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '7%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo " _
                & " UNION " _
                & " SELECT s.codigo,s.descripcion ," _
                & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                & " where s.codigo like '9%' and s.nivel = '" & gast & "' " _
                & " group by s.codigo "
            Else

                ' ......  periodo 12 NO generar antes de cierre
                If ChCierre.Checked = False Then
                    sql = "  SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '1%' and s.nivel = '" & act & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & "  SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '8%' and s.nivel = '" & act & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & "  SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '2%' and s.nivel = '" & pas & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & "  SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '3%' and s.nivel = '" & pat & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & " SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '4%' and s.nivel = '" & ing & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & " SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '5%' and s.nivel = '" & gast & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & " SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '6%' and s.nivel = '" & gast & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & " SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '7%' and s.nivel = '" & gast & "' " _
                    & " group by s.codigo " _
                    & " UNION " _
                    & " SELECT s.codigo,s.descripcion ," _
                    & " if ( SUM(c.saldo" & pA & ")> 0, SUM(c.saldo" & pA & "),0 ) as saldo00, " _
                    & " if ( SUM(c.saldo" & pA & ")< 0, SUM(c.saldo" & pA & "),0 ) as saldo01,  " _
                    & " sum(c.debito" & p & ") as debito00, sum(c.credito" & p & ") as credito00, " _
                    & " if ( sum(c.saldo" & p & ")> 0, SUM(c.saldo" & p & "),0 ) as debito01, " _
                    & " if ( SUM(c.saldo" & p & ")< 0, SUM(c.saldo" & p & "),0 ) as credito01 " _
                    & " FROM (SELECT codigo, saldo" & pA & ", nivel, debito" & p & ", credito" & p & ", saldo" & p & "  from selpuc  where nivel =  'Auxiliar' ) as c " _
                    & " right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%')) " _
                    & " where s.codigo like '9%' and s.nivel = '" & gast & "' " _
                    & " group by s.codigo "
                Else

                    ' ......  periodo 12 generar antes de cierre

                    sql = " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '1%' and s.nivel = '" & act & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '2%' and s.nivel = '" & pas & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '3%' and s.nivel = '" & pat & "' group by s.codigo UNION  " _
                     & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '4%' and s.nivel = '" & ing & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '5%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '6%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '7%' and s.nivel = '" & gast & "' group by s.codigo UNION  " _
                    & " SELECT s.codigo,s.descripcion , " _
                    & " if ( SUM(c.saldo11)> 0, SUM(c.saldo11),0 ) as saldo00,  " _
                    & " if ( SUM(c.saldo11)< 0, SUM(c.saldo11),0 ) as saldo01, " _
                    & " if (  ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>    'CA'),0) > 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as debito00, " _
                    & " if ( ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) < 0, ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) , 0) as credito00, " _
                    & " if(   SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) >0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0),0) as debito01, " _
                    & " if(  SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0) <0, SUM(c.saldo11)+ ifnull( ( select sum(debito-credito) from documentos12 where codigo = s.codigo and  tipodoc <>  'CA'),0), 0) as credito01 " _
                    & " FROM (SELECT codigo, saldo11, nivel  from selpuc  where nivel =  'Auxiliar' ) as c  right join selpuc s  on (c.codigo LIKE CONCAT(s.codigo,'%'))  " _
                    & " where s.codigo like '9%' and s.nivel = '" & gast & "' group by s.codigo "
                End If
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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportLibroMay.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportLibroMay.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtipo As New ParameterField
                Dim Prtt As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportLibroMay.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportLibroMay.ShowDialog()

            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try

    End Sub
End Class