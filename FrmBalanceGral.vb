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

Public Class FrmBalanceGral
    Public sumadb, sumacr, sumasaldo As Double

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Sub FrmBalanceGral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lbform.Text = "BG" Then
            pdf.Visible = False
            cmdpantalla.Visible = True
        Else
            pdf.Visible = True
            cmdpantalla.Visible = False
        End If
        BuscarPeriodo()
        ini.Text = PerActual(0) & PerActual(1)
        txtano.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If chkMostrarDif.Checked = False Then
            Dim tDif As New DataTable
            myCommand.CommandText = "SELECT ctaDiferencia FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tDif)
            If tDif.Rows(0).Item(0).ToString = "" Then
                MsgBox("No hay Cuenta Para Mostrar Diferencia, Verifique Los Parametros", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
        End If
        BalanceGral(ini.Text, nivel.Value, txtano.Text)
    End Sub

    Private Sub cmdactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactualizar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            mibarra.Visible = True
            mibarra.Value = 5
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
        MiConexion(bda)
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
            sumasaldo = CDbl(tabla.Rows(0).Item(0))
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
            sumadb = CDbl(tabla.Rows(0).Item(0))
        Catch ex As Exception
            sumadb = 0
        End Try
        Try
            sumacr = CDbl(tabla.Rows(0).Item(1))
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

    Private Sub cmdGrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrafica.Click
        FrmGrafica.lbform.Text = "general"
        FrmGrafica.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf.Click


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
        per = "PERIODO: " & ini.Text


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
        ant = CInt(ini.Text) - 1
        If ant < 10 Then
            ant = "0" & ant
        End If
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        dg = t1.Rows(0).Item(0)

        sql = " SELECT " _
        & " IF(s.tipo_saldo='CO','CORRIENTE','NO CORRIENTE') AS tipo," _
        & " s.codigo , s.descripcion , s.nivel,  IFNULL(sum(c.saldo" & ini.Text & "),0) as saldo, sum(c.saldo" & ant & ") as saldo00, if(IFNULL(sum(c.saldo" & ini.Text & "),0)=0,'Y','N') as naturaleza FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & ini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '1%' " _
        & " group by s.codigo ORDER BY tipo,codigo  "

        sql2 = " SELECT " _
        & " IF(s.tipo_saldo='CO','CORRIENTE','NO CORRIENTE') AS correo," _
        & " s.codigo as nit, s.descripcion as nombre, s.nivel as apellidos, IFNULL(sum(c.saldo" & ant & "),0) as web, IFNULL(sum(c.saldo" & ini.Text & "),0) as cupo, if(IFNULL(sum(c.saldo" & ini.Text & "),0)=0,'Y','N') as tipo FROM   " _
        & " (SELECT codigo,  nivel,  saldo" & ini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
        & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '2%' " _
        & " group by s.codigo ORDER BY correo, nit "

        sql3 = " SELECT " _
        & " IF(s.tipo_saldo='CO','CORRIENTE','NO CORRIENTE') AS modulo," _
       & " s.codigo as nit, s.descripcion as descri, s.nivel as centro,  IFNULL(sum(c.saldo" & ini.Text & "),0) as base,IFNULL(sum(c.saldo" & ant & "),0) as debito, if(sum(c.saldo" & ini.Text & ")=0,'Y','N') as dia FROM   " _
       & " (SELECT codigo,  nivel,  saldo" & ini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
       & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '3%' " _
       & " group by s.codigo ORDER BY modulo, nit "


        sql4 = "select  modulo as cta_inv, nit as codart, descri as nomart, centro as doc, base as valor, debito as vtotal, dia as tipo_it FROM (" _
        & " SELECT 'ACREEDORAS' AS modulo," _
       & " s.codigo as nit, s.descripcion as descri, s.nivel as centro,  IFNULL(sum(c.saldo" & ini.Text & "),0) as base,IFNULL(sum(c.saldo" & ant & "),0) as debito, IFNULL(if(sum(c.saldo" & ini.Text & ")=0,'Y','N'),0) as dia FROM   " _
       & " (SELECT codigo,  nivel,  saldo" & ini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
       & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '9%' " _
       & " group by s.codigo  UNION " _
       & " SELECT 'DEUDORAS' AS modulo," _
       & " s.codigo as nit, s.descripcion as descri, s.nivel as centro,  sum(c.saldo" & ini.Text & ") as base,IFNULL(sum(c.saldo" & ant & "),0) as debito, if(sum(c.saldo" & ini.Text & ")=0,'Y','N') as dia FROM   " _
       & " (SELECT codigo,  nivel,  saldo" & ini.Text & ", saldo" & ant & "  from selpuc  where nivel = 'Auxiliar' ) as c right join selpuc s  " _
       & " on (c.codigo LIKE CONCAT(s.codigo,'%') ) and s.nivel in (" & niv2 & ")  where s.nivel IN (" & niv2 & ") AND s.`codigo` LIKE '8%' " _
       & " group by s.codigo ) AS c ORDER BY modulo, nit  "

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
        TextBox1.Text = sql

        Dim tabla As DataSet
        tabla = New DataSet
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = sql
        'myCommand.Connection = conexion
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "selpuc")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "terceros")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql3
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "documentos01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql4
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "detafac01")


        'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContBalGen.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        'CrReport.Subreports.Item("BanGenActivos").SetDataSource(tabla)
        FrmReportContBalGen.CrystalReportViewer1.ReportSource = CrReport


        'Dim report As New DynamicReport
        'report.SetDataSource(ds)
        'report.Subreports.Item("SubReport1").SetDataSource(ds.Tables("Customers"))
        'report.Subreports.Item("SubReport2").SetDataSource(ds.Tables("Orders"))
        'CrystalReportViewer1.ReportSource = report
        'CrystalReportViewer1.DataBind()

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
            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prs1.Name = "sp1"
            Prs1.CurrentValues.AddValue(s1.ToString)
            Prs2.Name = "dg"
            Prs2.CurrentValues.AddValue(dg.ToString)
            Prs3.Name = "t1"
            Prs3.CurrentValues.AddValue("SALDO" & ini.Text)
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