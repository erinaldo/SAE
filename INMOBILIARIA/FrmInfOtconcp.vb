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
Public Class FrmInfOtconcp

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcon.Enabled = True
        Else
            txtcon.Enabled = False
        End If
    End Sub

    Private Sub c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        If c3.Checked = True Then
            txtdes.Enabled = True
        Else
            txtdes.Enabled = False
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True And Trim(txtcon.Text) = "" Then
            MsgBox("Verifique el codigo del contrato", MsgBoxStyle.Information, "Verificacion")
            txtcon.Focus()
            Exit Sub
        End If
        If c3.Checked = True And Trim(txtdes.Text) = "" Then
            MsgBox("Verifique la descripcion", MsgBoxStyle.Information, "Verificacion")
            txtdes.Focus()
            Exit Sub
        End If
        PDF()
    End Sub
    Private Sub PDF()
        MiConexion(bda)
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim cad As String = ""

        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "N.I.T: " & tabla2.Rows(0).Item("nit")


        If c2.Checked = True Then
            cad = "AND o.codcon='" & txtcon.Text & "'"
        ElseIf c3.Checked = True Then
            cad = "AND o.descr like '%" & txtdes.Text & "%'"
        End If
        sql = "SELECT o.item, o.codcon AS doc_ext, o.tipo, o.descr AS nomnit, o.valor AS subtotal, o.tcli AS nitc, o.dia AS clasaju, " _
        & " CASE o.contb " _
        & " WHEN 'N' THEN 'SOLO FACT' " _
        & " WHEN 'D' THEN 'CONT-FACT'  " _
        & " WHEN 'S' THEN 'SOLO CONT'  " _
        & " END AS ctaret, CAST(CONCAT(t.nit,' - ', t.nombre,' ', t.apellidos) AS CHAR(100)) AS concepto " _
        & " FROM otcon_contrato o , terceros t WHERE t.nit= o.nitc " & cad & " ORDER BY doc_ext, item"

        Dim ta As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportOtccinm.rpt")
        CrReport.SetDataSource(ta)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nitc"
            PrNit.CurrentValues.AddValue(nit.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtcon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcon.LostFocus

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcon.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count = 0 Then
            Try
                txtcon.Text = ""
                FrmSelContratos.lbform.Text = "inf_conc"
                FrmSelContratos.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FrmInfOtconcp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtcon.Text = ""
        txtdes.Text = ""
    End Sub
End Class