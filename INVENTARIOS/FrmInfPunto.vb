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
Public Class FrmInfPunto

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtci.Enabled = True
            txtcf.Enabled = True
        Else
            txtci.Enabled = False
            txtcf.Enabled = False
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True Then
            If txtci.Text = "" Then
                MsgBox("Verifique el rango de articulos", MsgBoxStyle.Information, "Verificacion")
                txtci.Focus()
                Exit Sub
            ElseIf txtcf.Text = "" Then
                MsgBox("Verifique el rango de articulos", MsgBoxStyle.Information, "Verificacion")
                txtcf.Focus()
                Exit Sub
            End If
        End If
        GenerarPDF()
    End Sub
    Private Sub GenerarPDF()
        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim cad As String = ""
        Dim cant As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

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

        Dim tablab As DataTable
        tablab = New DataTable
        myCommand.CommandText = "SELECT numbod from bodegas"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablab)

        For i = 0 To tablab.Rows.Count - 1
            If i = 0 Then
                cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
            Else
                cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
            End If
        Next
        cant = cant & ") "

        If c2.Checked = True Then
            cad = " AND a.codart BETWEEN '" & txtci.Text & "' AND '" & txtcf.Text & "'"
        End If

        sql = " SELECT  a.nomart, a.codart, a.nivel,(c.cant1+ c.cant2+ c.cant3)  AS can_emp, a.pp, c.costuni AS cos_uni, " _
        & " c.costprom AS cos_pro FROM articulos a, con_inv c " _
        & " WHERE a.codart = c.codart And " & cant & " = a.pp " _
        & " AND c.periodo =  '" & cbini.Text & "' " & cad & " " _
        & "ORDER BY codart  "

        Dim tabla As  New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportPunto.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmRepSinMov2.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(PerActual.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)

            FrmRepSinMov2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepSinMov2.ShowDialog()

        Catch ex As Exception
        End Try

        conexion.Close()
    End Sub

    Private Sub FrmInfPunto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbini.Text = Strings.Left(PerActual, 2)
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        FrmArti_de_Inventarios.lbform.Text = "InfPunto1"
        FrmArti_de_Inventarios.ShowDialog()
    End Sub

    Private Sub txtcf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcf.DoubleClick
        FrmArti_de_Inventarios.lbform.Text = "InfPunto2"
        FrmArti_de_Inventarios.ShowDialog()
    End Sub
End Class