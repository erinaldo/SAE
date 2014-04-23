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
Public Class FrmInforAudit

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Try

            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""
            Dim user As String = ""
            Dim per As String = ""
            Dim doc As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT" & tabla2.Rows(0).Item("nit")

            If c2.Checked = True Then
                If txttip.Text = "" Then
                    MsgBox("Verifique la informacion del usuario ", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                user = " AND usuario = '" & txttip.Text & "'"
            End If

            If rp2.Checked = True Then
                per = " AND periodo = '" & cbini.Text & txtpini.Text & "' "
            End If

            If rd2.Checked = True Then
                If txtdoc.Text = "" Then
                    MsgBox("Verifique el documento ", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                doc = " AND LEFT(formulario,2) = '" & cmdoc.Text & "'"
            End If


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = "SELECT usuario as codart, formulario as nomart, " _
            & " CAST(CONCAT( RIGHT(fec_aud, 2), '/', MID(fec_aud, 6, 2), '/',LEFT(fec_aud, 4) ) AS CHAR(13))  as cue_inv, " _
            & " CAST(hora AS CHAR(10)) as cue_ing, periodo as cue_cos,tip_cuenta as referencia,cuenta_err as cue_dev,doc_alt as p1 " _
            & " from auditoria " _
            & " WHERE usuario <> '' " & user & " " & per & " " & doc & "" _
            & " ORDER BY nomart, fec_aud, hora"

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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RAuditar\ReportAuditoria.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmVisorAuditoria.CrystalReportViewer1.ReportSource = CrReport

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

                FrmVisorAuditoria.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmVisorAuditoria.ShowDialog()

            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("Error al Generar el Informe", MsgBoxStyle.Information, "Error")
        End Try
    End Sub

    Private Sub txttip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.DoubleClick
        Try
            FrmSelUsuario.lbform.Text = "infAud"
            FrmSelUsuario.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try


            If txttip.Text <> "" Then

                Dim tabla As New DataTable
                tabla.Clear()
                Dim items As Integer
                myCommand.CommandText = "SELECT trim(concat(nombres,' ',apellidos)) as nom, login, rol FROM sae.usuarios WHERE login = '" & txttip.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    txttip.Text = ""
                    FrmSelUsuario.lbform.Text = "infAud"
                    FrmSelUsuario.ShowDialog()
                Else
                    txttip.Text = tabla.Rows(0).Item("login")
                    txtnom.Text = tabla.Rows(0).Item("nom")
                End If
            Else
                FrmSelUsuario.lbform.Text = "infAud"
                FrmSelUsuario.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub

    Private Sub FrmInforAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtpini.Text = Strings.Right(PerActual, 5)
        cbini.Text = Strings.Left(PerActual, 2)

        Dim td As New DataTable
        myCommand.CommandText = "SELECT  DISTINCT LEFT(a.formulario,2) AS doc, t.descripcion FROM auditoria a, tipdoc t WHERE LEFT(a.formulario,2) = t.tipodoc ORDER BY doc "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        Refresh()
        If td.Rows.Count = 0 Then cmdoc.Enabled = False And rd2.Checked = False
        cmdoc.Items.Clear()
        For i As Integer = 0 To td.Rows.Count - 1
            cmdoc.Items.Add(Trim(td.Rows(i).Item("doc")))
            If i = 0 Then
                cmdoc.Text = Trim(td.Rows(i).Item("doc"))
            End If
        Next

    End Sub

    Private Sub rp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rp2.CheckedChanged
        If rp2.Checked = True Then
            cbini.Enabled = True
        Else
            cbini.Enabled = False
        End If
    End Sub

    Private Sub rd2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd2.CheckedChanged
        If rd2.Checked = True Then
            cmdoc.Enabled = True
            txtdoc.Enabled = True
        Else
            cmdoc.Enabled = False
            txtdoc.Enabled = False
        End If
    End Sub

    Private Sub txtpini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpini.LostFocus
    End Sub

    Private Sub cmdoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdoc.SelectedIndexChanged

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT t.descripcion FROM  tipdoc t WHERE  t.tipodoc = '" & cmdoc.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtdoc.Text = ""
            Exit Sub
        End If
        txtdoc.Text = tabla.Rows(0).Item(0)

    End Sub

End Class