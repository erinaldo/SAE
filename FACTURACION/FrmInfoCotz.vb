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
Public Class FrmInfoCotz
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub FrmInfoCotz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 5)
        txtpini.Text = Strings.Right(PerActual, 5)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        cbtipo.Text = "PEDIDOS"
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            txtnom.Enabled = True
        Else
            txttip.Enabled = False
            txtnom.Enabled = False
        End If
    End Sub

    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmSelCliente.lbform.Text = "cotiz"
        FrmSelCliente.ShowDialog()
       
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME DE PEDIDOS/COTIZACIONES ", "", "", "")
        End If

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim cli As String = ""
        Dim per As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        If c1.Checked = False Then
            cli = "AND nitc = '" & txttip.Text & "'"
        End If
        Dim tbc As String = ""
        If cbtipo.Text = "PEDIDOS" Then
            tbc = "fapipen"
        Else
            tbc = "fact_acta_entrega"
        End If

        sql = "SELECT numero AS num, descrip as nomnit,CAST(CONCAT(Right(fecha,2),'/',mid(fecha,6,2),'/',left(fecha,4)) AS CHAR(10)) AS nitcod, vtotal as subtotal FROM " & tbc & " " _
        & " WHERE mid(fecha,6,2) between " & cbini.Text & " and " & cbfin.Text & " " _
        & " AND  Right(fecha,2) between " & txtdi1.Text & " and " & txtdi2.Text & " " & cli & " ORDER BY fecha"

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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCotz.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacCli.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "per"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtt.Name = "tt"
            Prtt.CurrentValues.AddValue("INFORME DE " & cbtipo.Text.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtt)

            FrmReportFacCli.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacCli.ShowDialog()
        Catch ex As Exception
        End Try


    End Sub

End Class