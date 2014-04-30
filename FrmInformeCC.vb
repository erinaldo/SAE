Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object

Public Class FrmInformeCC
    Dim sumadb, sumacr, sumasaldo As Double
    Dim dia As String
    Dim FechaRep As String
    Private Sub FrmCatalogosCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        lbper.Text = PerActual
        txtpini.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        txtpfin.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        If Now.Day.ToString < 10 Then
            txtdia.Text = "0" & Now.Day.ToString
        Else
            txtdia.Text = Now.Day.ToString
        End If
        txtperiodo.Text = "/" & PerActual

        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            If tabla.Rows(0).Item(0) <> "N" Then
                gcc.Enabled = True
            Else
                gcc.Enabled = False
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub p1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1.CheckedChanged
        BuscarPeriodo()
        lbper.Text = PerActual
        cbini.Enabled = False
        cbfin.Enabled = False
        txtdia.Enabled = False
    End Sub
    Private Sub p2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p2.CheckedChanged
        BuscarPeriodo()
        cbini.Enabled = True
        cbfin.Enabled = True
        txtdia.Enabled = False
        cbini.Text = PerActual(0) & PerActual(1)
        cbfin.Text = PerActual(0) & PerActual(1)
    End Sub
    Private Sub p3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p3.CheckedChanged
        BuscarPeriodo()
        cbini.Enabled = False
        cbfin.Enabled = False
        txtdia.Enabled = True
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        txtcini.Enabled = False
        txtcfin.Enabled = False
        txtcuenta.Enabled = False
    End Sub
    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        txtcini.Text = ""
        txtcfin.Text = ""
        txtcini.Enabled = True
        txtcini.Focus()
        txtcfin.Enabled = True
        txtcuenta.Enabled = False
    End Sub
    Private Sub c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        txtcuenta.Text = ""
        txtcini.Enabled = False
        txtcfin.Enabled = False
        txtcuenta.Enabled = True
    End Sub

    Private Sub d1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d1.CheckedChanged
        txtdoc.Enabled = False
        txtdoc2.Enabled = False
    End Sub
    Private Sub d2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.CheckedChanged
        txtdoc.Enabled = True
        txtdoc2.Enabled = True
    End Sub

    Private Sub n1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n1.CheckedChanged
        txtnit.Enabled = False
    End Sub
    Private Sub n2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n2.CheckedChanged
        txtnit.Enabled = True
    End Sub
    Private Sub cc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cc1.CheckedChanged
        txtcc.Enabled = False
    End Sub
    Private Sub cc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cc2.CheckedChanged
        txtcc.Enabled = True
    End Sub
    

    Private Sub cmdperiodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperiodo.Click
        Try
            BuscarPeriodo()
            FrmPeriodo.lbactual.Text = PerActual
            FrmPeriodo.ShowDialog()
            p1.Checked = True
            txtperiodo.Text = PerActual
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FechaRep = Now.ToString
        If p1.Checked = True Then 'PERIODO ACTUAL
            PeriodoActual()
        ElseIf p2.Checked = True Then 'RANGO DE PERIODOS
            RangoPeriodo()
        ElseIf p3.Checked = True Then 'COMPROBANTE DIARIO
            ComprobanteDiario()
        End If
    End Sub

    '******** INICIO ESCOGER INFORME ************
    Public Sub PeriodoActual()
        Dim sql, mes As String
        BuscarPeriodo()
        mes = PerActual(0) & PerActual(1)
        If c1.Checked = True Then 'TODAS LAS CUENTAS
            If d1.Checked = True Then 'TODAS LOS DOCUMENTOS
                If n1.Checked = True Then
                    Sql = "SELECT * FROM documentos" & mes & " ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE TODAS LAS CUENTAS", PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    Sql = "SELECT * FROM documentos" & mes & " WHERE nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE TODAS LAS CUENTAS CON NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then
                    Sql = "SELECT * FROM documentos" & mes & " WHERE tipodoc='" & txtdoc.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE TODAS LAS CUENTAS Y TIPO DE DOCUMENTO  " & txtdoc.Text, PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    Sql = "SELECT * FROM documentos" & mes & " WHERE tipodoc='" & txtdoc.Text & "' AND nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, TIPO DE DOCUMENTO  " & txtdoc.Text & " Y DE NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            End If
        ElseIf c2.Checked = True Then 'RANGO DE CUENTAS
            If txtcini.Text > txtcfin.Text Then
                MsgBox("Favor verifique rango de cuentas.  ", MsgBoxStyle.Information, "Verificando ")
                txtcini.Focus()
                Exit Sub
            End If
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then
                    sql = "SELECT * FROM documentos" & mes & " WHERE codigo>='" & txtcini.Text & "' AND codigo<='" & txtcfin.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(sql, "MOVIMIENTOS RANGO DE CUENTAS [" & txtcini.Text & " - " & txtcfin.Text & "]", PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    sql = "SELECT * FROM documentos" & mes & " WHERE codigo>='" & txtcini.Text & "' AND codigo<='" & txtcfin.Text & "' AND nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(sql, "MOVIMIENTOS RANGO DE CUENTAS [" & txtcini.Text & " - " & txtcfin.Text & "] Y DE NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then
                    sql = "SELECT * FROM documentos" & mes & " WHERE codigo>='" & txtcini.Text & "' AND codigo<='" & txtcfin.Text & "' AND tipodoc='" & txtdoc.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(sql, "MOVIMIENTOS RANGO DE CUENTAS [" & txtcini.Text & " - " & txtcfin.Text & "] Y TIPO DE DOCUMENTO  " & txtdoc.Text, PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    sql = "SELECT * FROM documentos" & mes & " WHERE codigo>='" & txtcini.Text & "' AND codigo<='" & txtcfin.Text & "' AND tipodoc='" & txtdoc.Text & "' AND nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(sql, "MOVIMIENTOS RANGO DE CUENTAS [" & txtcini.Text & " - " & txtcfin.Text & "], TIPO DE DOCUMENTO  " & txtdoc.Text & " Y DE NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            End If
        ElseIf c3.Checked = True Then 'POR CUENTA
            If d1.Checked = True Then 'TODAS LOS DOCUMENTOS
                If n1.Checked = True Then
                    Sql = "SELECT * FROM documentos" & mes & " WHERE codigo like '" & txtcuenta.Text & "%' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE LA(S) CUENTA(S) " & txtcuenta.Text, PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    Sql = "SELECT * FROM documentos" & mes & " WHERE codigo like '" & txtcuenta.Text & "%' AND nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE LA(S) CUENTA(S) " & txtcuenta.Text & " Y EL NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then
                    Sql = "SELECT * FROM documentos" & mes & " WHERE codigo like '" & txtcuenta.Text & "%' AND tipodoc='" & txtdoc.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE LA(S) CUENTA(S) " & txtcuenta.Text & " Y TIPO DE DOCUMENTO  " & txtdoc.Text, PerActual(0) & PerActual(1))
                Else
                    If VerificarNit() = False Then Exit Sub
                    Sql = "SELECT * FROM documentos" & mes & " WHERE codigo like '" & txtcuenta.Text & "%' AND tipodoc='" & txtdoc.Text & "' AND nit='" & txtnit.Text & "' ORDER BY codigo,dia,tipodoc,doc,item;"
                    GenerarPDF(Sql, "MOVIMIENTOS DE LA(S) CUENTA(S) " & txtcuenta.Text & ", TIPO DE DOCUMENTO  " & txtdoc.Text & " Y EL NIT " & txtnit.Text & " " & txtnombre.Text, PerActual(0) & PerActual(1))
                End If
            End If
        End If
    End Sub
    Public Sub RangoPeriodo()
        Dim sql, mes As String
        BuscarPeriodo()
        mes = PerActual(0) & PerActual(1)
        If c1.Checked = True Then 'TODAS LAS CUENTAS
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = ""
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS", cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = "AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON TIPO DE DOCUMENTO " & txtdoc.Text, cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            End If
        ElseIf c2.Checked = True Then 'RANGO DE CUENTAS
            If txtcini.Text > txtcfin.Text Then
                MsgBox("Favor verifique rango de cuentas.  ", MsgBoxStyle.Information, "Verificando ")
                txtcini.Focus()
                Exit Sub
            End If
            If txtcini.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If txtcfin.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "'"
                    GenerarRangoPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "]", cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON TIPO DE DOCUMENTO " & txtdoc.Text & " ", cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            End If
        ElseIf c3.Checked = True Then 'POR CUENTA
            If txtcuenta.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text), cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON TIPO DE DOCUMENTO " & txtdoc.Text & " ", cbini.Text, cbfin.Text)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarRangoPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, cbini.Text, cbfin.Text)
                End If
            End If
        End If
    End Sub
    Public Sub ComprobanteDiario()
        If Val(txtdia.Text) < 10 Then
            dia = "0" & Val(txtdia.Text)
        Else
            dia = txtdia.Text
        End If
        '************************************************
        Dim sql, mes As String
        BuscarPeriodo()
        mes = PerActual(0) & PerActual(1)
        If c1.Checked = True Then 'TODAS LAS CUENTAS
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = ""
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS", mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = "AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON TIPO DE DOCUMENTO " & txtdoc.Text, mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE TODAS LAS CUENTAS, CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            End If
        ElseIf c2.Checked = True Then 'RANGO DE CUENTAS
            If txtcini.Text > txtcfin.Text Then
                MsgBox("Favor verifique rango de cuentas.  ", MsgBoxStyle.Information, "Verificando ")
                txtcini.Focus()
                Exit Sub
            End If
            If txtcini.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If txtcfin.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "'"
                    GenerarDiarioPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "]", mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON TIPO DE DOCUMENTO " & txtdoc.Text & " ", mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo>='" & Trim(txtcini.Text) & "' AND codigo<='" & Trim(txtcfin.Text) & "' AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS POR RANGO DE CUENTAS [" & Trim(txtcini.Text) & " - " & Trim(txtcfin.Text) & "], CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            End If
        ElseIf c3.Checked = True Then 'POR CUENTA
            If txtcuenta.Text = "" Then
                txtcini.Focus()
                Exit Sub
            End If
            If d1.Checked = True Then 'TODOS LOS DOCUMENTOS
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text), mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            ElseIf d2.Checked = True Then 'POR DOCUMENTO
                If txtdoc2.Text = "" Then
                    MsgBox("Favor digite un tipo de documento, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtdoc.Focus()
                    Exit Sub
                End If
                If n1.Checked = True Then 'TODOS LOS NIT
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND tipodoc='" & Trim(txtdoc.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON TIPO DE DOCUMENTO " & txtdoc.Text & " ", mes, mes)
                Else
                    If VerificarNit() = False Then Exit Sub 'por nit
                    sql = " AND codigo like '" & Trim(txtcuenta.Text) & "%' AND tipodoc='" & Trim(txtdoc.Text) & "' AND nit='" & Trim(txtnit.Text) & "' "
                    GenerarDiarioPDF(sql, "MOVIMIENTOS DE LA CUENTA " & Trim(txtcuenta.Text) & ", CON TIPO DE DOCUMENTO " & txtdoc.Text & " Y CON NIT " & txtnit.Text & " " & txtnombre.Text, mes, mes)
                End If
            End If
        End If
    End Sub
    '******** FIN ESCOGER INFORME ************
    Private Sub GenerarPDF(ByVal tablames As String, ByVal movi As String, ByVal per As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim Cuenta, num, cad, cad2 As String
        Dim i, k, pag As Integer
        Dim sumad, sumac As Double
        Refresh()
        pag = 0
        Try
            Dim tabla, tablacomp, tini As New DataTable
            myCommand.CommandText = tablames
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            '***************************
            Refresh()
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            pag = pag + 1
            cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
            cb.ShowTextAligned(50, movi, 20, 760, 0)
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 750, 0)
            k = 740
            Cuenta = ""
            sumad = 0
            sumac = 0
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            per = Val(per) - 1
            If Val(per) < 0 Then
                per = "saldo00"
            ElseIf Val(per) < 10 Then
                per = "saldo0" & per
            Else
                per = "saldo" & per
            End If
            For i = 0 To tabla.Rows.Count - 1
                If Cuenta <> tabla.Rows(i).Item("codigo") Then
                    If i <> 0 Then
                        k = k - 10
                        cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------", 300, k, 0)
                        k = k - 10
                        cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
                        If sumad <> 0 Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumad), 440, k, 0)
                        End If
                        If sumac <> 0 Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumac), 510, k, 0)
                        End If
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 585, k, 0)
                        sumad = 0
                        sumac = 0
                    End If
                    Cuenta = tabla.Rows(i).Item("codigo")
                    k = k - 30
                    If k <= 60 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        pag = pag + 1
                        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                        cb.ShowTextAligned(50, movi, 20, 760, 0)
                        cb.ShowTextAligned(50, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 740
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    cb.ShowTextAligned(50, "*********** CUENTA: " & tabla.Rows(i).Item("codigo") & " " & NomCuenta(tabla.Rows(i).Item("codigo")) & " ***********", 50, k, 0)
                    tini.Clear()
                    myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tini)
                    sumasaldo = CDbl(tini.Rows(0).Item(per))
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO INICIAL:      " & Moneda(tini.Rows(0).Item(per)), 585, k, 0)
                    k = k - 15
                    If k <= 45 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                        pag = pag + 1
                        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                        cb.ShowTextAligned(50, movi, 20, 760, 0)
                        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 740
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, “Ejemplo basico con iTextSharp”, 200, PageSize.A4.Height – 50, 0)
                    cb.ShowTextAligned(50, "FECHA ", 10, k, 0)
                    cb.ShowTextAligned(50, "DOCUMENTO ", 55, k, 0)
                    cb.ShowTextAligned(50, "DETALLE ", 105, k, 0)
                    cb.ShowTextAligned(50, "N.I.T.", 210, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 450, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 520, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 590, k, 0)
                End If
                k = k - 15
                If k <= 45 Then
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    pag = pag + 1
                    cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                    cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                    cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                    cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                    cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                    cb.ShowTextAligned(50, movi, 20, 760, 0)
                    cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                    k = 740
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                End If
                sumad = sumad + tabla.Rows(i).Item("debito")
                sumac = sumac + tabla.Rows(i).Item("credito")
                If tabla.Rows(i).Item("doc") < 10 Then
                    num = "000" & tabla.Rows(i).Item("doc")
                ElseIf tabla.Rows(i).Item("doc") < 100 Then
                    num = "00" & tabla.Rows(i).Item("doc")
                ElseIf tabla.Rows(i).Item("doc") < 1000 Then
                    num = "0" & tabla.Rows(i).Item("doc")
                Else
                    num = tabla.Rows(i).Item("doc")
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & PerActual, 10, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc") & num, 55, k, 0)
                If tabla.Rows(i).Item("descri").ToString.Length > 25 Then
                    cad = ""
                    cad2 = tabla.Rows(i).Item("descri")
                    For j = 0 To 24
                        cad = cad & cad2(j)
                    Next
                    cb.ShowTextAligned(50, cad, 105, k, 0)
                Else
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("descri"), 105, k, 0)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("nit") & " - " & BuscarTer(tabla.Rows(i).Item("nit")), 210, k, 0)
                If tabla.Rows(i).Item("debito") <> "0,00" Then
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("debito")), 450, k, 0)
                End If
                If tabla.Rows(i).Item("credito") <> "0,00" Then
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("credito")), 520, k, 0)
                End If
                sumasaldo = sumasaldo + CDbl(tabla.Rows(i).Item("debito")) - CDbl(tabla.Rows(i).Item("credito"))
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 590, k, 0)
            Next
            k = k - 10
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------", 300, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
            If sumad <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumad), 440, k, 0)
            End If
            If sumac <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumac), 510, k, 0)
            End If
            sumasaldo = sumasaldo
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 585, k, 0)
            sumad = 0
            sumac = 0
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public st As Double
    Private Sub GenerarRangoPDF(ByVal condiciones As String, ByVal movi As String, ByVal perI As String, ByVal perF As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim ano, num, cad, cad2, SalIni, per As String
        Dim i, k, pag As Integer
        Dim sumad, sumac As Double
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Refresh()
        Try
            pag = 0
            st = 0
            Dim tabla, tablaComp, tablaPer As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaComp)
            '***************************
            Refresh()
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            pag = pag + 1
            cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "RANGO DE PERIODOS: DESDE EL " & perI & " HASTA EL " & perF & " DEL AÑO " & ano, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
            cb.ShowTextAligned(50, movi, 20, 760, 0)
            cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
            k = 740
            sumad = 0
            sumac = 0
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            If Val(perI) - 1 < 10 Then
                SalIni = "saldo0" & Val(perI) - 1
            Else
                SalIni = "saldo" & Val(perI) - 1
            End If
            Dim sal As Double = 0
            For i = 0 To tabla.Rows.Count - 1
                If VerificarMovimiento(tabla.Rows(i).Item("codigo"), condiciones, perI, perF) = True Then
                    k = k - 15
                    If k <= 45 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                        pag = pag + 1
                        cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "RANGO DE PERIODOS: DESDE EL " & perI & " HASTA EL " & perF & " DEL AÑO " & ano, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                        cb.ShowTextAligned(50, movi, 20, 760, 0)
                        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 740
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    cb.ShowTextAligned(50, "*********** CUENTA: " & tabla.Rows(i).Item("codigo") & " " & NomCuenta(tabla.Rows(i).Item("codigo")) & " ***********", 50, k, 0)

                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO INICIAL:      " & Saldo_ini(tabla.Rows(i).Item("codigo"), condiciones, perI, perF), 585, k, 0)
                    k = k - 15
                    cb.ShowTextAligned(50, "FECHA ", 10, k, 0)
                    cb.ShowTextAligned(50, "DOCUMENTO ", 55, k, 0)
                    cb.ShowTextAligned(50, "DETALLE ", 105, k, 0)
                    cb.ShowTextAligned(50, "N.I.T. - NOMBRE / RAZON SOCIAL", 210, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 450, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 520, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 590, k, 0)
                    sumad = 0
                    sumac = 0
                    'Try
                    '    sumasaldo = tabla.Rows(i).Item(SalIni)
                    'Catch ex As Exception
                    '    sumasaldo = 0
                    'End Try
                    For j = Val(perI) To Val(perF)
                        If j < 10 Then
                            per = "0" & j
                        Else
                            per = j
                        End If
                        tablaPer.Clear()
                        myCommand.CommandText = "SELECT * FROM documentos" & per & " WHERE codigo='" & tabla.Rows(i).Item("codigo") & "' " & condiciones & " ORDER BY dia,tipodoc,doc,item;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tablaPer)
                        For w = 0 To tablaPer.Rows.Count - 1
                            k = k - 15
                            If k <= 45 Then
                                cb.EndText()
                                oDoc.NewPage()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 9)
                                pag = pag + 1
                                cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
                                cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
                                cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                                cb.ShowTextAligned(50, "RANGO DE PERIODOS: DESDE EL " & perI & " HASTA EL " & perF & " DEL AÑO " & ano, 20, 780, 0)
                                cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                                cb.ShowTextAligned(50, movi, 20, 760, 0)
                                cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                                k = 740
                                cb.EndText()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 7)
                            End If
                            Try
                                sumad = sumad + tablaPer.Rows(w).Item("debito")
                            Catch ex As Exception
                            End Try
                            Try
                                sumac = sumac + tablaPer.Rows(w).Item("credito")
                            Catch ex As Exception
                            End Try
                            If tablaPer.Rows(w).Item("doc") < 10 Then
                                num = "000" & tablaPer.Rows(w).Item("doc")
                            ElseIf tablaPer.Rows(w).Item("doc") < 100 Then
                                num = "00" & tablaPer.Rows(w).Item("doc")
                            ElseIf tablaPer.Rows(w).Item("doc") < 1000 Then
                                num = "0" & tablaPer.Rows(w).Item("doc")
                            Else
                                num = tablaPer.Rows(w).Item("doc")
                            End If
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("dia") & "/" & tablaPer.Rows(w).Item("periodo"), 10, k, 0)
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("tipodoc") & num, 55, k, 0)
                            If Val(tablaPer.Rows(w).Item("descri").ToString.Length) > 25 Then
                                cad = ""
                                cad2 = tablaPer.Rows(w).Item("descri")
                                For l = 0 To 24
                                    cad = cad & cad2(l)
                                Next
                                cb.ShowTextAligned(50, cad, 105, k, 0)
                            Else
                                cb.ShowTextAligned(50, tablaPer.Rows(w).Item("descri"), 105, k, 0)
                            End If
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("nit") & " - " & BuscarTer(tablaPer.Rows(w).Item("nit")), 210, k, 0)
                            If tablaPer.Rows(w).Item("debito") <> "0,00" Then
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablaPer.Rows(w).Item("debito")), 450, k, 0)
                            End If
                            If tablaPer.Rows(w).Item("credito") <> "0,00" Then
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablaPer.Rows(w).Item("credito")), 520, k, 0)
                            End If
                            sumasaldo = sumasaldo + CDbl(tablaPer.Rows(w).Item("debito")) - CDbl(tablaPer.Rows(w).Item("credito"))
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 590, k, 0)
                            st = st + CDbl(tablaPer.Rows(w).Item("debito")) - CDbl(tablaPer.Rows(w).Item("credito"))
                        Next
                    Next
                    k = k - 10
                    cb.ShowTextAligned(50, "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 300, k, 0)
                    k = k - 10
                    cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
                    If sumad <> 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumad), 440, k, 0)
                    End If
                    If sumac <> 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumac), 510, k, 0)
                    End If
                    sumasaldo = sumasaldo
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 585, k, 0)
                    k = k - 10
                End If
            Next
            '*******************************************************************
            k = k - 5
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 300, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "TOTAL GENERAL", 300, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(st), 585, k, 0)
            k = k - 10
            '*******************************************************************
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Function BuscarTer(ByVal nit As String)
        Dim nom As String = ""
        Dim tabla As New DataTable
        Try
            tabla.Clear()
            myCommand.CommandText = "SELECT TRIM(CONCAT(nombre, ' ', apellidos)) FROM terceros WHERE nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            nom = CambiaCadena(tabla.Rows(0).Item(0).ToString, 30)
        Catch ex As Exception
        End Try
        Return nom
    End Function
    Function VerificarMovimiento(ByVal cuenta As String, ByVal condiciones As String, ByVal peri As String, ByVal perf As String)
        Dim tablaPer As New DataTable
        Dim per As String
        For j = Val(peri) To Val(perf)
            If j < 10 Then
                per = "0" & j
            Else
                per = j
            End If
            tablaPer.Clear()
            myCommand.CommandText = "SELECT count(*) FROM documentos" & per & " WHERE codigo='" & cuenta & "' " & condiciones & " ORDER BY dia,tipodoc,doc,item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaPer)
            If tablaPer.Rows(0).Item(0) > 0 Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Function Saldo_ini(ByVal cuenta As String, ByVal condiciones As String, ByVal peri As String, ByVal perf As String)
        Dim tablaPer As New DataTable
        Dim per, sql As String
        Dim axu As Integer = 0
        sql = ""
        peri = Val(Val(peri) - 1)
        If cbini.Text = "00" Then
            sumasaldo = 0
            Return Moneda(0)
            Exit Function
        End If
        For j = 0 To Val(peri)
            If j < 10 Then
                per = "0" & j
            Else
                per = j
            End If
            axu = axu + 1
            If axu <= 1 Then
                sql = "SELECT SUM(debito - credito) AS s FROM documentos" & per & " WHERE codigo='" & cuenta & "' " & condiciones & " "
            Else
                sql = sql & " UNION SELECT SUM(debito - credito) AS s FROM documentos" & per & " WHERE codigo='" & cuenta & "' " & condiciones & ""
            End If
        Next
        sql = sql & ";"
        Dim suma As Double = 0
        Try
            'MsgBox(sql)
            tablaPer.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaPer)
            For i = 0 To tablaPer.Rows.Count - 1
                Try
                    suma = suma + CDbl(Moneda(tablaPer.Rows(i).Item("s").ToString))
                Catch ex As Exception
                    '       MsgBox(ex.ToString)
                End Try
            Next
        Catch ex As Exception
            'MsgBox("22222" & ex.ToString)
        End Try
        sumasaldo = suma
        st = st + suma
        Return Moneda(suma)
    End Function

    Private Sub GenerarDiarioPDF(ByVal condiciones As String, ByVal movi As String, ByVal perI As String, ByVal perF As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim ano, num, cad, cad2, SalIni, per As String
        Dim i, k, pag As Integer
        Dim sumad, sumac As Double
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Refresh()
        Try
            pag = 0
            Dim tabla, tablaComp, tablaPer As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaComp)
            '***************************
            Refresh()
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            pag = pag + 1
            cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "LIBRO DIARIO: " & dia & "/" & PerActual, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
            cb.ShowTextAligned(50, movi, 20, 760, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
            k = 740
            sumad = 0
            sumac = 0
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            If Val(perI) - 1 < 10 Then
                SalIni = "saldo0" & Val(perI) - 1
            Else
                SalIni = "saldo" & Val(perI) - 1
            End If
            For i = 0 To tabla.Rows.Count - 1
                If VerificarMoviDia(tabla.Rows(i).Item("codigo"), condiciones, perI, perF) = True Then
                    k = k - 15
                    If k <= 45 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                        pag = pag + 1
                        cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "LIBRO DIARIO: " & dia & "/" & PerActual, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                        cb.ShowTextAligned(50, movi, 20, 760, 0)
                        cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 740
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                    End If
                    cb.ShowTextAligned(50, "*********** CUENTA: " & tabla.Rows(i).Item("codigo") & " " & NomCuenta(tabla.Rows(i).Item("codigo")) & " ***********", 50, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO INICIAL:      " & Moneda(tabla.Rows(i).Item(SalIni)), 585, k, 0)
                    k = k - 15
                    cb.ShowTextAligned(50, "FECHA ", 10, k, 0)
                    cb.ShowTextAligned(50, "DOCUMENTO ", 55, k, 0)
                    cb.ShowTextAligned(50, "DETALLE ", 105, k, 0)
                    cb.ShowTextAligned(50, "N.I.T.", 210, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 450, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 520, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 590, k, 0)
                    sumad = 0
                    sumac = 0
                    Try
                        sumasaldo = tabla.Rows(i).Item(SalIni)
                    Catch ex As Exception
                        sumasaldo = 0
                    End Try
                    For j = Val(perI) To Val(perF)
                        If j < 10 Then
                            per = "0" & j
                        Else
                            per = j
                        End If
                        tablaPer.Clear()
                        myCommand.CommandText = "SELECT * FROM documentos" & per & " WHERE codigo='" & tabla.Rows(i).Item("codigo") & "' " & condiciones & " AND (dia='" & dia & "' OR dia='" & Val(dia) & "') ORDER BY dia,tipodoc,doc,item;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tablaPer)
                        For w = 0 To tablaPer.Rows.Count - 1
                            k = k - 15
                            If k <= 45 Then
                                cb.EndText()
                                oDoc.NewPage()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 8)
                                pag = pag + 1
                                cb.ShowTextAligned(50, tablaComp.Rows(0).Item("descripcion"), 20, 810, 0)
                                cb.ShowTextAligned(50, "N.I.T. " & tablaComp.Rows(0).Item("nit"), 20, 800, 0)
                                cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                                cb.ShowTextAligned(50, "LIBRO DIARIO: " & dia & "/" & PerActual, 20, 780, 0)
                                cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
                                cb.ShowTextAligned(50, movi, 20, 760, 0)
                                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                                k = 740
                                cb.EndText()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 7)
                            End If
                            Try
                                sumad = sumad + tablaPer.Rows(w).Item("debito")
                            Catch ex As Exception
                            End Try
                            Try
                                sumac = sumac + tablaPer.Rows(w).Item("credito")
                            Catch ex As Exception
                            End Try
                            If tablaPer.Rows(w).Item("doc") < 10 Then
                                num = "000" & tablaPer.Rows(w).Item("doc")
                            ElseIf tablaPer.Rows(w).Item("doc") < 100 Then
                                num = "00" & tablaPer.Rows(w).Item("doc")
                            ElseIf tablaPer.Rows(w).Item("doc") < 1000 Then
                                num = "0" & tablaPer.Rows(w).Item("doc")
                            Else
                                num = tablaPer.Rows(w).Item("doc")
                            End If
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("dia") & "/" & tablaPer.Rows(w).Item("periodo"), 10, k, 0)
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("tipodoc") & num, 25, k, 0)
                            If Val(tablaPer.Rows(w).Item("descri").ToString.Length) > 25 Then
                                cad = ""
                                cad2 = tablaPer.Rows(w).Item("descri")
                                For l = 0 To 24
                                    cad = cad & cad2(l)
                                Next
                                cb.ShowTextAligned(50, cad, 105, k, 0)
                            Else
                                cb.ShowTextAligned(50, tablaPer.Rows(w).Item("descri"), 105, k, 0)
                            End If
                            cb.ShowTextAligned(50, tablaPer.Rows(w).Item("nit") & " - " & BuscarTer(tablaPer.Rows(w).Item("nit")), 210, k, 0)
                            If tablaPer.Rows(w).Item("debito") <> "0,00" Then
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablaPer.Rows(w).Item("debito")), 450, k, 0)
                            End If
                            If tablaPer.Rows(w).Item("credito") <> "0,00" Then
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tablaPer.Rows(w).Item("credito")), 520, k, 0)
                            End If
                            sumasaldo = sumasaldo + CDbl(tablaPer.Rows(w).Item("debito")) - CDbl(tablaPer.Rows(w).Item("credito"))
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 590, k, 0)
                        Next
                    Next
                    k = k - 10
                    cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------", 300, k, 0)
                    k = k - 10
                    cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
                    If sumad <> 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumad), 440, k, 0)
                    End If
                    If sumac <> 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumac), 510, k, 0)
                    End If
                    sumasaldo = sumasaldo
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasaldo), 585, k, 0)
                    k = k - 10
                End If
            Next
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Function VerificarMoviDia(ByVal cuenta As String, ByVal condiciones As String, ByVal peri As String, ByVal perf As String)
        Dim tablaPer As New DataTable
        Dim per As String
        per = PerActual(0) & PerActual(1)
        tablaPer.Clear()
        myCommand.CommandText = "SELECT count(*) FROM documentos" & per & " WHERE codigo='" & cuenta & "' " & condiciones & " AND (dia='" & dia & "' OR dia='" & Val(dia) & "') ORDER BY dia,tipodoc,doc,item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaPer)
        If tablaPer.Rows(0).Item(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function NomCuenta(ByVal codigo As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Return CambiaCadena(tabla.Rows(0).Item("descripcion"), 40)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '**************************************************************************************
    Private Sub cmdactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactualizar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            mibarra.Visible = True
            mibarra.Value = 0
            ActualizarCatalogo()
            mibarra.Value = 100
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("ERROR AL MOMENTO DE ACTUALIZAR CATALOGO DE CUENTAS:  " & ex.ToString, MsgBoxStyle.Critical, "SAE Control de Errores")
            mibarra.Value = 0
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    '***************** INICIO ACTUALIZAR CATALOGO CUENTA *******************************

    Public Sub ActualizarCatalogo()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        'Dim tabla As New DataTable
        'Dim barra, baraux As Double
        'myCommand.CommandText = "SELECT codigo,saldo00 FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo desc;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        'barra = 100 / tabla.Rows.Count
        'baraux = barra
        'For i = 0 To tabla.Rows.Count - 1
        '    CalcularSaldo(tabla.Rows(i).Item("codigo"))
        '    For j = 1 To 12
        '        If j < 10 Then
        '            Calcular("0" & j, tabla.Rows(i).Item("codigo"))
        '        Else
        '            Calcular(j, tabla.Rows(i).Item("codigo"))
        '        End If
        '    Next
        '    myCommand.Parameters.Clear()
        '    Try
        '        myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        '    Catch ex As Exception
        '        myCommand.Parameters.AddWithValue("?sal", "0")
        '    End Try
        '    myCommand.CommandText = "UPDATE selpuc SET saldo=?sal WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
        '    myCommand.ExecuteNonQuery()
        '    If mibarra.Value + barra < 98 Then
        '        baraux = baraux + barra
        '        If baraux >= 1 Then
        '            mibarra.Value = mibarra.Value + baraux
        '            baraux = 0
        '        End If
        '    Else
        '        mibarra.Value = 95
        '    End If
        'Next
        'Cerrar()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        Dim tabla As New DataTable
        Dim barra, baraux As Double
        myCommand.CommandText = "SELECT codigo,saldo00 FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo desc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        barra = 100 / tabla.Rows.Count
        ' MsgBox(barra)
        For i = 0 To tabla.Rows.Count - 1
            CalcularSaldo(tabla.Rows(i).Item("codigo"))
            For j = 0 To 12
                If j < 10 Then
                    Calcular("0" & j, tabla.Rows(i).Item("codigo"))
                Else
                    Calcular(j, tabla.Rows(i).Item("codigo"))
                End If
            Next
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?sal", "0")
            End Try
            myCommand.CommandText = "UPDATE selpuc SET saldo=?sal WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
            myCommand.ExecuteNonQuery()
            If mibarra.Value + barra < 98 Then
                baraux = baraux + barra
                If baraux >= 1 Then
                    mibarra.Value = mibarra.Value + baraux
                    baraux = 0
                End If
            Else
                mibarra.Value = 95
            End If
        Next
        mibarra.Value = 100
        mibarra.Visible = False
        Me.Cursor = Cursors.Default
        Cerrar()
    End Sub
    Public Sub CalcularSaldo(ByVal micuenta As String)
        Dim tabla As New DataTable
        '///////////CALCULAR SALDO INICIAL //////////////////////
        myCommand.CommandText = "SELECT sum(saldo00) FROM selpuc WHERE codigo like '" & micuenta & "%' and nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumasaldo = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumasaldo = 0
        End Try
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        '/////////////ACTUALIZAR SALDO INICIAL///////////////////
        myCommand.CommandText = "UPDATE selpuc SET saldo00=?sal WHERE codigo='" & micuenta & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Calcular(ByVal mitabla As String, ByVal cuenta As String)
        If mitabla = "00" Then
            sumasaldo = 0
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT sum(debito),sum(credito) FROM documentos" & mitabla & " WHERE codigo like '" & cuenta & "%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumadb = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumadb = 0
        End Try
        Try
            sumacr = tabla.Rows(0).Item(1)
        Catch ex As Exception
            sumacr = 0
        End Try
        sumasaldo = sumasaldo + (sumadb - sumacr)
        '**********************************************
        ActualizarSelPuc(cuenta, "debito" & mitabla, "credito" & mitabla, "saldo" & mitabla)
    End Sub
    Public Sub ActualizarSelPuc(ByVal cuenta As String, ByVal db As String, ByVal cr As String, ByVal sa As String)
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?dbto", CDbl(sumadb))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?dbto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?crto", CDbl(sumacr))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?crto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        Try
            myCommand.CommandText = "UPDATE selpuc SET " & db & "=?dbto," & cr & "=?crto," & sa & "=?sal " _
                              & " WHERE codigo='" & cuenta & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    '*****************  FIN ACTUALIZAR CATALOGO  ***************************************
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        BuscarNit()
    End Sub

    Private Sub txtdoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc.LostFocus
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdoc2.Text = tabla.Rows(0).Item("descripcion")
        Else

        End If
        n1.Focus()
    End Sub
    Private Sub txtdoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdoc2.Text = tabla.Rows(0).Item("descripcion")
        Else
            txtdoc2.Text = ""
        End If
    End Sub
    Public Sub BuscarNit()
        Try
            If Trim(txtnit.Text) = "" Then
                FrmSelCliente.lbform.Text = "inf_cc"
                FrmSelCliente.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & Trim(txtnit.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtnombre.Text = ""
                    FrmSelCliente.lbform.Text = "inf_cc"
                    FrmSelCliente.txtcuenta.Text = Trim(txtnit.Text)
                    FrmSelCliente.ShowDialog()
                Else
                    txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
                End If
            End If
        Catch ex As Exception
            txtnombre.Text = ""
        End Try
    End Sub
    Function VerificarNit()
        Try
            If Trim(txtnit.Text) <> "" Then
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & Trim(txtnit.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtnombre.Text = ""
                    Return False
                Else
                    txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        cbfin.Items.Clear()
        Dim j As Integer = Val(cbini.Text)
        For i = j To 12
            If i < 10 Then
                cbfin.Items.Add("0" & i)
            Else
                cbfin.Items.Add(i)
            End If
        Next
        cbfin.Text = cbini.Text
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub
    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        If p3.Checked = False Then Exit Sub
        If Val(txtdia.Text) > 31 Or Val(txtdia.Text) < 1 Then
            MsgBox("Favor digite un numero de dia valido, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            txtdia.Text = "01"
            txtdia.Focus()
        End If
    End Sub
    Private Sub txtcini_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcini.DoubleClick
        FrmCuentas.lbaux.Text = "todas"
        FrmCuentas.lbform.Text = "infcc1"
        If FrmCuentas.txtcuenta.Text <> txtcini.Text Then
            FrmCuentas.txtcuenta.Text = txtcini.Text
        Else
            FrmCuentas.txtcuenta.Text = ""
        End If
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtcini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcini.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            FrmCuentas.lbaux.Text = "todas"
            FrmCuentas.lbform.Text = "infcc1"
            If FrmCuentas.txtcuenta.Text <> txtcini.Text Then
                FrmCuentas.txtcuenta.Text = txtcini.Text
            Else
                FrmCuentas.txtcuenta.Text = ""
            End If
            FrmCuentas.ShowDialog()
            txtcfin.Focus()
        Else
            validarnumero(txtcini, e)
        End If
    End Sub
    Private Sub txtcfin_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcfin.DoubleClick
        FrmCuentas.lbaux.Text = "todas"
        FrmCuentas.lbform.Text = "infcc2"
        If FrmCuentas.txtcuenta.Text <> txtcfin.Text Then
            FrmCuentas.txtcuenta.Text = txtcfin.Text
        Else
            FrmCuentas.txtcuenta.Text = ""
        End If
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcfin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcfin.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            FrmCuentas.lbaux.Text = "todas"
            FrmCuentas.lbform.Text = "infcc2"
            If FrmCuentas.txtcuenta.Text <> txtcfin.Text Then
                FrmCuentas.txtcuenta.Text = txtcfin.Text
            Else
                FrmCuentas.txtcuenta.Text = ""
            End If
            FrmCuentas.ShowDialog()
        Else
            validarnumero(txtcfin, e)
        End If
    End Sub
    Private Sub txtcuenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.DoubleClick
        FrmCuentas.lbaux.Text = "todas"
        FrmCuentas.lbform.Text = "infcc3"
        FrmCuentas.txtcuenta.Text = txtcuenta.Text
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

        
            If cc2.Checked = True And txtcc.Text = "" Then
                MsgBox("Verifique el centro de costo")
                Exit Sub
            End If


            BuscarPeriodo()

            Dim titulo As String = ""
            Dim tituloG As String = ""
            Dim nom As String = ""
            Dim nitp As String = ""
            Dim per As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
            tituloG = "MOVIMIENTO DE TODAS LAS CUENTAS"

            MiConexion(bda)

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            ' Try
            Dim sql2 As String = ""
            Dim sql As String = ""
            Dim ini As Integer = 0
            Dim fin As Integer = 0
            Dim dia As String = ""
            Dim p As String = ""
            Dim pi As String = ""
            Dim cuent As String = ""
            Dim cuentT As String = ""
            Dim doc As String = ""
            Dim docT As String = ""
            Dim nit As String = ""
            Dim nitT As String = ""
            Dim tipo As String = ""
            Dim tt As String = ""
            Dim ord As String = ""
            Dim cc As String = ""
            Dim c_f As String = ""

            If p1.Checked = True Then ' periodo act
                ini = PerActual(0).ToString & PerActual(1).ToString
                fin = PerActual(0).ToString & PerActual(1).ToString
                per = "PERIODO: " & PerActual
            Else
                If p2.Checked = True Then ' rango period
                    ini = cbini.Text
                    fin = cbfin.Text
                    per = "PERIODOS: " & cbini.Text & "/" & txtpini.Text & " - " & cbfin.Text & "/" & txtpfin.Text
                End If
                If p3.Checked = True Then ' libro
                    ini = PerActual(0).ToString & PerActual(1).ToString
                    fin = PerActual(0).ToString & PerActual(1).ToString
                    dia = " AND  FORMAT( d.dia, 0 ) =  " & Val(txtdia.Text) & " "
                    per = "PERIODO: " & PerActual
                End If
            End If

            If c2.Checked = True Then ' Rango d cuentas
                cuent = " AND s.codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' "
            End If
            If c3.Checked = True Then ' una cuenta
                cuent = " AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )"
            End If

            If d2.Checked = True Then
                doc = " AND d.tipodoc = '" & txtdoc.Text & "' "
            End If
            If n2.Checked = True Then
                nit = " AND d.nit = '" & txtnit.Text & "' "
            End If

            If cc2.Checked = True Then
                titulo = "CENTRO DE COSTO " & txtcc.Text & "/ " & txtNomcc.Text
                cc = "AND d.centro = '" & txtcc.Text & "' "
            End If

            Dim che As String = ""
            If ch2.Checked = True Then
                che = "AND d.cheque = '" & txtcheque.Text & "' "
            End If

            '***********************************************************
            '*********************************************************
            '--------------------- AGRUPAR POR CUENTA
            If o1.Checked = True Then
                Dim cad As String = ""
                If c1.Checked = True Then
                    If d1.Checked = True Then
                        If n1.Checked = True Then
                            cad = ""
                        Else
                            cad = " WHERE nit = '" & txtnit.Text & "' "
                        End If
                    Else
                        If n1.Checked = True Then
                            cad = "WHERE tipodoc = '" & txtdoc.Text & "' "
                        Else
                            cad = " WHERE tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                        End If
                    End If
                End If

                If c2.Checked = True Then
                    If d1.Checked = True Then
                        If n1.Checked = True Then
                            cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' "
                        Else
                            cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND nit = '" & txtnit.Text & "' "
                        End If
                    Else
                        If n1.Checked = True Then
                            cad = "WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND tipodoc = '" & txtdoc.Text & "' "
                        Else
                            cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                        End If
                    End If
                End If

                If c3.Checked = True Then
                    If d1.Checked = True Then
                        If n1.Checked = True Then
                            cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) "
                        Else
                            cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND nit = '" & txtnit.Text & "' "
                        End If
                    Else
                        If n1.Checked = True Then
                            cad = "WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND tipodoc = '" & txtdoc.Text & "' "
                        Else
                            cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                        End If
                    End If

                End If

                '---------- saldos iniciales
                Dim salT As String = ""
                For j = 1 To ini
                    If j < 10 Then
                        pi = "0" & j - 1
                    Else
                        If j = 10 Then
                            pi = "0" & j - 1
                        Else
                            pi = j - 1
                        End If
                    End If
                    If j <> ini Then
                        salT = salT & " SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cad & " group by codigo UNION "
                    Else
                        salT = salT & " SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cad & "  group by codigo "
                    End If
                Next

                '' por dia
                If p3.Checked = True Then
                    If cad = "" Then
                        salT = salT & " UNION SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & Strings.Left(PerActual, 2) & " WHERE FORMAT(dia,0) < " & Val(txtdia.Text) & " group by codigo "
                    Else
                        salT = salT & " UNION SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & Strings.Left(PerActual, 2) & " " & cad & "  AND FORMAT(dia,0) < " & Val(txtdia.Text) & " group by codigo "
                    End If
                End If
                ' ....... fin saldos iniciales

                ' SQL2
                ' sql2 = "select  codigo as codart, sum(c.n) AS valor FROM ( " & salT & " ) as c   GROUP BY codigo ORDER BY  codigo "
                sql2 = "select  '' as item, '' as tipodoc, c.codigo as nitcod, s.descripcion as decrip, '' as nitc, '' as nomnit, '' as fecha, sum(c.n) AS subtotal, " _
                & " '' as ccosto, '' as doc, '' as concepto, 0 as tasa, 0 as total,'' as ctaretiva FROM ( " & salT & " ) as c , selpuc s WHERE c.codigo = s.codigo   "



                tipo = "***** CUENTA: "
                c_f = " FECHA "
                tt = "NIT / NOMBRE - RAZON SOCIAL"
                ord = " d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, concat(t.nombre,' ', t.apellidos) as nomnit "

                If ini < 10 Then
                    pi = "0" & ini - 1
                Else
                    If ini = 10 Then
                        pi = "0" & ini - 1
                    Else
                        pi = ini - 1
                    End If
                End If
                For i = ini To fin
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If i <> fin Then
                        sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                        & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia) )AS DATE ) AS fecha, " _
                        & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                        & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                        & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                        & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
                        & " AND s.codigo = d.codigo " & dia & " " & cuent & " " & doc & " " & nit & " " & cc & " " & che & " UNION "
                    Else
                        sql = sql & " SELECT d.item, d.tipodoc, " & ord & ", " _
                        & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia) )AS DATE ) AS fecha, " _
                        & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal, " _
                        & " concat(d.dia,'/',d.periodo) as ccosto, CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20)) as doc, " _
                        & " d.descri as concepto, d.debito as tasa , d.credito as total, d.cheque as ctaretiva  " _
                        & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                        & " AND  s.codigo = d.codigo " & dia & " " & cuent & "  " & doc & " " & nit & " " & cc & " " & che & " "
                    End If
                Next
                ' sql = sql & " ORDER BY nitcod, fecha ASC, tipodoc, doc  "

            Else
                '*********************************************************************************
                '**********************************************************************************
                ' AGRUPAR POR TERCERO
                If o2.Checked = True Then
                    If c1.Checked = False And d1.Checked = True Then

                        If c2.Checked = True Then ' Rango d cuentas
                            cuentT = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' "
                        End If
                        If c3.Checked = True Then ' una cuenta
                            cuentT = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )"
                        End If
                    End If
                    If c1.Checked = True And d1.Checked = False Then
                        If d2.Checked = True Then
                            docT = " WHERE tipodoc = '" & txtdoc.Text & "' "
                        End If
                    End If
                    If c1.Checked = False And d1.Checked = False Then
                        If c2.Checked = True Then ' Rango d cuentas
                            cuentT = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' "
                        End If
                        If c3.Checked = True Then ' una cuenta
                            cuentT = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )"
                        End If
                        If d2.Checked = True Then
                            docT = " AND tipodoc = '" & txtdoc.Text & "' "
                        End If
                    End If

                    Dim salT As String = ""
                    tipo = "***** TERCERO: "
                    c_f = " FECHA "
                    tt = "CUENTA / DESCRIPCION"
                    ord = " d.codigo AS nitc, s.descripcion AS nomnit , d.nit as nitcod, concat(t.nombre,' ',t.apellidos) as  descrip "

                    For j = 1 To ini
                        If j < 10 Then
                            pi = "0" & j - 1
                        Else
                            If j = 10 Then
                                pi = "0" & j - 1
                            Else
                                pi = j - 1
                            End If
                        End If
                        If j <> ini Then
                            salT = salT & " SELECT " & pi & ", item,nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cuentT & " " & docT & "  group by nit UNION "
                        Else
                            salT = salT & " SELECT " & pi & ", item,nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cuentT & " " & docT & "  group by nit"
                        End If
                    Next

                    '      sql2 = "select  '' as item, '' as tipodoc, c.codigo as nitcod, s.descripcion as decrip, c.nit as nitc, '' as nomnit, '' as fecha, sum(c.n) AS subtotal, " _
                    '& " '' as ccosto, '' as doc, '' as concepto, 0 as tasa, 0 as total,'' as ctaretiva FROM ( " & salT & " ) as c , selpuc s WHERE c.codigo = s.codigo   "


                    For i = ini To fin
                        If i < 10 Then
                            p = "0" & i
                            pi = "0" & i - 1
                        Else
                            If i = 10 Then
                                pi = "0" & i - 1
                            Else
                                pi = i - 1
                            End If
                            p = i
                        End If

                        If i <> fin Then
                            sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                            & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia) )AS DATE ) AS fecha, " _
                            & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE c.nit =  d.nit  GROUP BY nit ),0) as subtotal,  " _
                            & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                            & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva  " _
                            & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                            & " AND  s.codigo = d.codigo " & dia & " " & cuent & " " & doc & " " & nit & " " & cc & " " & che & " UNION "
                        Else
                            sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                            & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia) )AS DATE ) AS fecha, " _
                            & " IFNULL( (select  sum(c.n) FROM ( " & salT & " ) as c   WHERE c.nit =  d.nit  GROUP BY nit ),0) as subtotal, " _
                            & " concat(d.dia,'/',d.periodo) as ccosto, CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20)) as doc, " _
                            & " d.descri as concepto, d.debito as tasa , d.credito as total, d.cheque as ctaretiva  " _
                            & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                            & " AND  s.codigo = d.codigo " & dia & " " & cuent & "  " & doc & " " & nit & " " & cc & " " & che & " "
                        End If
                    Next
                    sql = sql & " ORDER BY nitcod, fecha , tipodoc, doc "

                Else
                    '//////////////////////////////////////////////////////////////////////////////////
                    ' AGRUPAR POR FECHA
                    Dim cad As String = ""
                    If c1.Checked = True Then
                        If d1.Checked = True Then
                            If n1.Checked = True Then
                                cad = ""
                            Else
                                cad = " WHERE nit = '" & txtnit.Text & "' "
                            End If
                        Else
                            If n1.Checked = True Then
                                cad = "WHERE tipodoc = '" & txtdoc.Text & "' "
                            Else
                                cad = " WHERE tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                            End If
                        End If
                    End If

                    If c2.Checked = True Then
                        If d1.Checked = True Then
                            If n1.Checked = True Then
                                cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' "
                            Else
                                cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND nit = '" & txtnit.Text & "' "
                            End If
                        Else
                            If n1.Checked = True Then
                                cad = "WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND tipodoc = '" & txtdoc.Text & "' "
                            Else
                                cad = " WHERE codigo BETWEEN '" & txtcini.Text & "' AND '" & txtcfin.Text & "' AND tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                            End If
                        End If
                    End If

                    If c3.Checked = True Then
                        If d1.Checked = True Then
                            If n1.Checked = True Then
                                cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) "
                            Else
                                cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND nit = '" & txtnit.Text & "' "
                            End If
                        Else
                            If n1.Checked = True Then
                                cad = "WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND tipodoc = '" & txtdoc.Text & "' "
                            Else
                                cad = " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND tipodoc = '" & txtdoc.Text & "' AND nit = '" & txtnit.Text & "' "
                            End If
                        End If

                    End If

                    '---------- saldos iniciales
                    Dim salT As String = ""
                    For j = 1 To ini
                        If j < 10 Then
                            pi = "0" & j - 1
                        Else
                            If j = 10 Then
                                pi = "0" & j - 1
                            Else
                                pi = j - 1
                            End If
                        End If
                        If j <> ini Then
                            salT = salT & " SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cad & " group by codigo UNION "
                        Else
                            salT = salT & " SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " & cad & "  group by codigo "
                        End If
                    Next

                    ' ....... fin saldos iniciales

                    c_f = " CUENTA "
                    tipo = "***** FECHA: "
                    tt = "NIT / NOMBRE - RAZON SOCIAL"

                    ord = " d.codigo AS ccosto, '' AS descrip, d.nit as nitc, concat(t.nombre,' ', t.apellidos) as nomnit "
                    If ini < 10 Then
                        pi = "0" & ini - 1
                    Else
                        If ini = 10 Then
                            pi = "0" & ini - 1
                        Else
                            pi = ini - 1
                        End If
                    End If

                    For i = ini To fin
                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If
                        If i <> fin Then
                            sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                            & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia))AS DATE ) AS fecha, " _
                            & " 0 as subtotal,  " _
                            & " concat(d.dia,'/',d.periodo) as nitcod,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                            & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                            & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                            & " AND  s.codigo = d.codigo " & dia & " " & cuent & " " & doc & " " & nit & " " & cc & " " & che & " UNION "
                        Else
                            sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                            & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), IF(LENGTH(d.dia)=1,CONCAT('0',d.dia),d.dia) )AS DATE ) AS fecha, " _
                            & " 0 as subtotal, " _
                            & " concat(d.dia,'/',d.periodo) as nitcod, CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20)) as doc, " _
                            & " d.descri as concepto, d.debito as tasa , d.credito as total, d.cheque as ctaretiva  " _
                            & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                            & " AND  s.codigo = d.codigo " & dia & " " & cuent & "  " & doc & " " & nit & " " & cc & " " & che & " "
                        End If
                    Next
                    sql = sql & " ORDER BY  fecha ASC , tipodoc, doc  "
                End If
            End If

            TextBox1.Text = sql

            Dim tb As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)


            Dim ca As String = ""

            ' AGRUPAR POR CUENTA
            If o1.Checked = True Then
                If tb.Rows.Count = 0 Then
                    sql = sql2 & "GROUP BY c.codigo ORDER BY  c.codigo "
                Else
                    Dim tb2 As New DataTable
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "select  DISTINCT r.nitcod  from (" & sql & ") as r"
                    myCommand.Connection = conexion
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tb2)

                    For i = 0 To tb2.Rows.Count - 1
                        If i = 0 Then
                            ca = ca & tb2.Rows(i).Item(0)
                        Else
                            ca = ca & "," & tb2.Rows(i).Item(0)
                        End If
                    Next

                    sql2 = sql2 & " AND c.codigo NOT IN (" & ca & ") GROUP BY c.codigo "
                    sql = sql & " UNION " & sql2 & " ORDER BY nitcod, fecha , tipodoc, doc  "

                    'Dim tb3 As New DataTable
                    'myCommand.Parameters.Clear()
                    'myCommand.CommandText = sql2
                    'myCommand.Connection = conexion
                    'myAdapter.SelectCommand = myCommand
                    'myAdapter.Fill(tb3)
                End If
            End If

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "cobdpen")

            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * from deta_mov01"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "deta_mov01")


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMov_cue.rpt")
            CrReport.SetDataSource(tabla)
            ' CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtipo As New ParameterField
                Dim Prtt As New ParameterField
                Dim Prtitulo As New ParameterField
                Dim PrtituloG As New ParameterField
                Dim Prcf As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtipo.Name = "tipo"
                Prtipo.CurrentValues.AddValue(tipo.ToString)

                Prtt.Name = "tt"
                Prtt.CurrentValues.AddValue(tt.ToString)

                Prtitulo.Name = "titulo"
                Prtitulo.CurrentValues.AddValue(titulo.ToString)

                PrtituloG.Name = "tituloG"
                PrtituloG.CurrentValues.AddValue(tituloG.ToString)

                Prcf.Name = "Cue_Fec"
                Prcf.CurrentValues.AddValue(c_f.ToString)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtipo)
                prmdatos.Add(Prtt)
                prmdatos.Add(Prtitulo)
                prmdatos.Add(PrtituloG)
                prmdatos.Add(Prcf)

                FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCMov_cue.ShowDialog()

            Catch ex As Exception
            End Try

            conexion.Close()
            Cerrar()
            'Catch ex As Exception
            '    MsgBox("Error al generar el informe " & ex.ToString, MsgBoxStyle.Information, "SAE")
            'End Try
        Catch ex As Exception
            MsgBox("Error al Generar el Informe" & ex.ToString, MsgBoxStyle.Information, "Informacion")
        End Try
    End Sub


    Private Sub txtcc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcc.LostFocus
        Buscarcc()
    End Sub

    Private Sub Buscarcc()

        Try
            If Trim(txtcc.Text) = "" Then
                FrmSelCentroCostos.lbform.Text = "inf_cc"
                FrmSelCentroCostos.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & Trim(txtcc.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    MsgBox("El centro de costo no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtcc.Text = ""
                    txtNomcc.Text = ""
                    FrmSelCentroCostos.lbform.Text = "inf_cc"
                    'FrmSelCentroCostos.txtcuenta.Text = Trim(txtnit.Text)
                    FrmSelCentroCostos.ShowDialog()
                Else
                    txtNomcc.Text = tabla.Rows(0).Item("nombre")
                End If
            End If
        Catch ex As Exception
            txtNomcc.Text = ""
        End Try
    End Sub
    
    Private Sub txtcini_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcini.TextChanged

    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged

    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked = True Then
            txtcheque.Enabled = True
        Else
            txtcheque.Enabled = False
        End If
    End Sub
End Class