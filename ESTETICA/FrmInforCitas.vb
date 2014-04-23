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
Public Class FrmInforCitas

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInforCitas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 5)
        txtpini.Text = Strings.Right(PerActual, 5)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
        cbest.Text = "TODOS"
    End Sub

    Private Sub a2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.CheckedChanged
        If a2.Checked = True Then
            txtnita.Enabled = True
        Else
            txtnita.Enabled = False
        End If
    End Sub

    Private Sub a1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a1.CheckedChanged

    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
        Else
            txtnitc.Enabled = True
        End If
    End Sub

   
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True And txtnitc.Text = "" Then
            MsgBox("Verifique el NIT del cliente", MsgBoxStyle.Information, "Verificacion")
            txtnitc.Focus()
            Exit Sub
        End If
        If a2.Checked = True And txtnita.Text = "" Then
            MsgBox("Verifique el NIT del Asesor", MsgBoxStyle.Information, "Verificacion")
            txtnita.Focus()
            Exit Sub
        End If
        Pdf()
    End Sub
    Private Sub Pdf()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cad As String = ""
        Dim f1 As String = ""
        Dim f2 As String = ""


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

        If c2.Checked = True Then
            cad = cad & "and  c.nitc = '" & txtnitc.Text & "' "
        End If
        If a2.Checked = True Then
            cad = cad & "and  c.nita = '" & txtnita.Text & "' "
        End If
        If cbest.Text <> "TODOS" Then
            cad = cad & "and c.estado='" & cbest.Text & "'"
        End If
        f1 = Strings.Right(txtpini.Text, 4) & "-" & cbini.Text & "-" & txtdi1.Text

        f2 = Strings.Right(txtpfin.Text, 4) & "-" & cbfin.Text & "-" & txtdi2.Text


        sql = "SELECT cast(c.num as char(15)) AS doc, CONCAT(c.nitc,' __ ',t.nombre,' ', t.apellidos) AS d1, CONCAT(c.nitc,' __ ',v.nombre) AS d2," _
              & " c.servicio AS descrip, CAST( (CONCAT( RIGHT( c. fecha , 2 ) ,  '/', MID( c . fecha ,  6, 2 ) ,  '/', LEFT( c . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS nitc,  " _
              & " CAST( c.hora AS CHAR(10)) AS nitv, c.observ, c.estado AS usuario " _
              & " FROM citas c, terceros t, vendedores v WHERE t.nit= c.nitc AND v.nitv= c.nita " & cad & " AND c.fecha BETWEEN '" & f1 & "' AND  '" & f2 & "'"

        sql = sql & " ORDER BY nitc, d2"
        TextBox1.Text = sql

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\REstetica\ReportCitas.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        FrmReportFacVen.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim PrAJ As New ParameterField
            Dim Prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(txtdi1.Text & "/" & cbini.Text & "--" & txtdi2.Text & "/" & cbfin.Text)



            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)

            FrmReportFacVen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacVen.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtnita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnita.KeyPress
        ValidarNIT(txtnita, e)
    End Sub

    Private Sub txtnita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.LostFocus

        If txtnita.Text <> "" Then
            Dim ta As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * from vendedores where nitv ='" & txtnita.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)

            If ta.Rows.Count > 0 Then
                txtnoma.Text = ta.Rows(0).Item("nombre")
            Else
                txtnita.Text = ""
                txtnoma.Text = ""
                cargarvendedor()
            End If
        Else
            cargarvendedor()
        End If

    End Sub
    Private Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = "infcitas"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub txtnita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.TextChanged
        If txtnita.Text = "" Then
            txtnoma.Text = ""
        End If
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text <> "" Then
            Dim ta As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select concat(nombre,' ',apellidos) as nom from terceros where nit ='" & txtnitc.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)

            If ta.Rows.Count > 0 Then
                txtnomv.Text = ta.Rows(0).Item("nom")
            Else
                txtnita.Text = ""
                txtnoma.Text = ""
                Try
                    FrmSelCliente.lbform.Text = "infcitas"
                    FrmSelCliente.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        Else
            Try
                FrmSelCliente.lbform.Text = "infcitas"
                FrmSelCliente.ShowDialog()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        If txtnitc.Text = "" Then
            txtnomv.Text = ""
        End If
    End Sub
End Class