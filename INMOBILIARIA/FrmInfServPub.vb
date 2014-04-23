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
Public Class FrmInfServPub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If i2.Checked = True And txtinm.Text = "" Then
            MsgBox("Verifique el codigo del inmuble", MsgBoxStyle.Information, "SAE")
            txtinm.Focus()
            Exit Sub
        ElseIf i3.Checked = True And cmbEstado.Text = "" Then
            MsgBox("Verifique el estado del inmuble", MsgBoxStyle.Information, "SAE")
            cmbEstado.Focus()
            Exit Sub
        End If

        If s2.Checked = True And cmbServ.Text = "" Then
            MsgBox("Verifique el nombre del servicio", MsgBoxStyle.Information, "SAE")
            cmbServ.Focus()
            Exit Sub
        End If


        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim cad As String = ""

        MiConexion(bda)
        Cerrar()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "N.I.T: " & tabla2.Rows(0).Item("nit")

        If i2.Checked = True Then
            cad = cad & " and s. codigo_inm='" & txtinm.Text & "' "
        ElseIf i3.Checked = True Then
            cad = cad & " and i. estado='" & cmbEstado.Text & "' "
        End If

        If s2.Checked = True Then
            cad = cad & " and s.descrip='" & cmbServ.Text & "' "
        End If
        sql = "SELECT s.codigo_inm, CONCAT(s.codigo_inm,' / ',i.direccion, ' -- PROPIETARIO: ', i.nitp, ' ', t.nombre,' ', t.apellidos,' -- ESTADO: ',i.estado) AS descrip, " _
       & " s.descrip AS dir_ent, s.codigo AS ciu_ent, s.numero AS d2, s.titular AS d1, s.observacion AS entregar  " _
       & " FROM inm_servicios s, inmuebles i, terceros t " _
       & " WHERE i.codigo = s.codigo_inm And i.nitp = t.nit " & cad _
       & " ORDER BY codigo_inm"

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfServInm.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub FrmInfServPub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)

        Dim ta As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "  SELECT DISTINCT  descrip FROM inm_servicios"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then
            MsgBox("No existen servicios registrados", MsgBoxStyle.Information, "Verificacion")
            Me.Close()
        Else
            For i = 0 To ta.Rows.Count - 1
                cmbServ.Items.Add(ta.Rows(i).Item(0))
            Next
        End If
        Cerrar()
    End Sub

    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus

    End Sub

    Private Sub i3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i3.CheckedChanged
        If i3.Checked = True Then
            cmbEstado.Enabled = True
        Else
            cmbEstado.Enabled = False
        End If
    End Sub

    Private Sub s2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s2.CheckedChanged
        If s2.Checked = True Then
            cmbServ.Enabled = True
        Else
            cmbServ.Enabled = False
        End If
    End Sub

    Private Sub i2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i2.CheckedChanged
        If i2.Checked = True Then
            txtinm.Enabled = True
        Else
            txtinm.Enabled = False
        End If
    End Sub
End Class