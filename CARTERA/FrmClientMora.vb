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

Public Class FrmClientMora

    Private Sub FrmClientMora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)
        Dim tabla As New DataTable
        cbdoc.Items.Clear()

        myCommand.CommandText = "SELECT par_fac1, par_fac2, par_fac3, par_fac4, par_aju FROM car_par"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            If tabla.Rows(0).Item("par_fac1") <> "" Then
                cbdoc.Items.Add(tabla.Rows(0).Item("par_fac1"))
            End If
            If tabla.Rows(0).Item("par_fac2") <> "" Then
                cbdoc.Items.Add(tabla.Rows(0).Item("par_fac2"))
            End If
            If tabla.Rows(0).Item("par_fac3") <> "" Then
                cbdoc.Items.Add(tabla.Rows(0).Item("par_fac3"))
            End If
            If tabla.Rows(0).Item("par_fac4") <> "" Then
                cbdoc.Items.Add(tabla.Rows(0).Item("par_fac4"))
            End If
            If tabla.Rows(0).Item("par_aju") <> "" Then
                cbdoc.Items.Add(tabla.Rows(0).Item("par_aju"))
            End If

        End If

        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/2000"
        fecha1.MaxDate = "31/12/" & ano
        fecha1.Value = "01/01" & "/" & ano
        '*********************

        '' CARGAR CLIENTES
        '' AUTOCOMPLETAR NIT CLIENTE
        'Try
        '    txtcliente.AutoCompleteCustomSource.Clear()

        '    Dim tb As New DataTable
        '    tb.Clear()
        '    myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    If tb.Rows.Count > 0 Then
        '        For i = 0 To tb.Rows.Count - 1
        '            txtcliente.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub
    Private Sub d2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.CheckedChanged
        If d2.Checked = False Then
            cbdoc.Enabled = False
        Else
            cbdoc.Enabled = True
        End If

    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "lista_clie_Mora"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            cargarclientes()
        End If
    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = False
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            'chcli.Visible = True
            'chcli.Checked = False
            'txtnitc.Focus()
        Else
            txtnitc.Enabled = False
            'chcli.Visible = False
            'chcli.Checked = False
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click


        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim inf As String = ""
        Dim fc As String = ""
        Dim doc_aj As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT par_aju FROM car_par ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        inf = "DIAS DE VENCIMIENTO " & txtdias.Text & " O MAS "
        per = "PERIODO ACTUAL: " & PerActual

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        fc = Strings.Right(fecha1.Text, 4) & "-" & Strings.Mid(fecha1.Text, 4, 2) & "-" & Strings.Left(fecha1.Text, 2)

        Dim d As String = ""
        Dim cl As String = ""
        Dim td As String = ""
        Dim ff As String = ""
        If c2.Checked = True Then
            cl = " AND c.nitc = '" & txtnitc.Text & "' AND  t.nit= '" & txtnitc.Text & "'"
        End If
        If d2.Checked = True Then
            td = " AND c.tipo = '" & cbdoc.Text & "'"
        End If
        If f1.Checked = True Then
            ff = " AND c.fecha >= '" & fc & "'"
        Else
            ff = " AND (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) >= '" & fc & "'"
        End If
        If txtdias.Text <> "0" Then
            d = " AND (SELECT DATEDIFF( NOW( ) ,ADDDATE(  c.fecha, INTERVAL c.vmto DAY) )) >= '" & txtdias.Text & "' "
        End If


        '---
        If checkresumido.Checked = False Then
            sql = "  SELECT c.nitc, c.nomnit, t.telefono AS nitcod, c.doc, CAST( c.fecha AS CHAR( 20 ) ) AS fecha,  " _
         & " CAST( (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitv,  " _
         & " (total - pagado) AS total, c.concepto, " _
         & "  IF((SELECT DATEDIFF(NOW(), ADDDATE(c . fecha , INTERVAL c . vmto DAY )))>=0,(SELECT DATEDIFF(NOW(), ADDDATE(c . fecha , INTERVAL c . vmto DAY ))),0) as vmto  " _
         & " FROM cobdpen c LEFT JOIN terceros t  ON  c.nitc=t.nit WHERE c.total > c.pagado " & ff & " " & d & " " & cl & " " & td & ""

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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportClmor.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportCClMor.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prinf As New ParameterField
                Dim PrAJ As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prinf.Name = "informe"
                Prinf.CurrentValues.AddValue(inf.ToString)

                PrAJ.Name = "doc_aj"
                PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prinf)
                prmdatos.Add(PrAJ)
                FrmReportCClMor.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCClMor.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            sql = " SELECT c.nitc, c.nomnit, SUM(total - pagado) AS total, " _
             & " AVG( if ((SELECT DATEDIFF( NOW( ) ,ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ))>=0,(SELECT DATEDIFF( NOW( ) ,ADDDATE(  c.fecha, INTERVAL c.vmto DAY) )),0 ))as vmto " _
             & " FROM cobdpen c LEFT JOIN terceros t ON  c.nitc=t.nit WHERE c.total > c.pagado " & ff & " " & d & " " & cl & " " & td & " " _
             & " AND left(c.doc,2)<>'" & doc_aj & "' GROUP BY c.nitc  ORDER BY nitc "

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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportClmorR.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportCClMorR.CrystalReportViewer1.ReportSource = CrReport

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
                Prperiodo.CurrentValues.AddValue(per.ToString)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportCClMorR.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCClMorR.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
        '----

    End Sub

    Private Sub txtdias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress
        validarnumero(txtdias, e)
    End Sub

    Private Sub txtdias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdias.TextChanged
        Try
            txtdias.Text = Val(txtdias.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = True
        Else
            txtcliente.Enabled = False
            txtnitc.Enabled = True
        End If
    End Sub
    Private Sub txtcliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcliente.LostFocus
        Try
            If txtcliente.Text = "" Then
                txtnitc.Text = ""
                FrmSelCliente.lbform.Text = "lista_clie_Mora"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtcliente.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(nombre,' ',apellidos)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txtnitc.Text = ""
            FrmSelCliente.lbform.Text = "lista_clie_Mora"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub

End Class