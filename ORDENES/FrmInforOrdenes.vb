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
Public Class FrmInforOrdenes

    Private Sub FrmInforOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbOrden.Text = "TODOS"

        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/" & ano
        fecha1.MaxDate = "31/12/" & ano
        fecha2.MinDate = "01/01/" & ano
        fecha2.MaxDate = "31/12/" & ano
        '**************************************
        fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Try
            fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception
            Try
                If PerActual(0) & PerActual(1) = "02" Then
                    fecha2.Value = "28/" & PerActual(0) & PerActual(1) & "/" & ano
                Else
                    fecha2.Value = "30/" & PerActual(0) & PerActual(1) & "/" & ano
                End If
            Catch ex2 As Exception
            End Try
        End Try
        '********************
    End Sub
    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        ValidarNIT(txttip, e)
    End Sub
    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try
            If txttip.Text = "" Then
                FrmSelCliente.lbform.Text = "OrdenesP"
                FrmSelCliente.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmSelCliente.lbform.Text = "OrdenesP"
        FrmSelCliente.ShowDialog()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub
    Public Sub GenerarPDF()


        If c2.Checked = True Then
            If txtnom.Text = "" Then
                MsgBox("Verifique datos del Beneficiario.  ", MsgBoxStyle.Information)
                txttip.Focus()
                Exit Sub
            End If
        End If
        If fecha1.Value > fecha2.Value Then
            MsgBox("La fecha inicial no puede ser mayor que la final, verifique. ", MsgBoxStyle.Information)
            fecha1.Focus()
            Exit Sub
        End If

        Dim sql As String = ""
        Dim cad As String = ""
        Dim nom As String = ""

        MiConexion(bda)
        Cerrar()

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")

        If c2.Checked = True Then
            cad = cad & " AND con_ben='" & txttip.Text & "' "
        End If
        If cmbOrden.Text = "CON SOPORTES" Then
            cad = cad & " AND estado = 'AP' "
        ElseIf cmbOrden.Text = "PENDIENTES" Then
            cad = cad & " AND estado = '' "
        End If

        sql = "SELECT doc AS doc_ext, fecha, CONCAT(doccxp,'  ---  ', con_num) AS descrip, CONCAT(con_ben,' - ',nomnit) AS nomnit, v_bruto AS subtotal, v_neto AS descto, estado, sop_cont AS concepto," _
        & " CAST(CONCAT( RIGHT(fecha, 2), '/', MID(fecha, 6, 2),'/',LEFT(fecha, 4)) AS CHAR(10)) AS ctaiva " _
        & " FROM ord_pagos WHERE  fecha BETWEEN '" & (fecha1.Value.ToString("yyyy-MM-dd")) & "' AND '" & (fecha2.Value.ToString("yyyy-MM-dd")) & "' " & cad & " ORDER BY fecha"

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportInfOrden.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            prmdatos.Add(Prcomp)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            GenerarPDF()
        Catch ex As Exception
            MsgBox("Error al generar el informe,  " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try


    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class