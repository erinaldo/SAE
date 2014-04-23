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

Public Class FrmConcpFac

    Private Sub FrmConcpFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Txtconp.Enabled = False
        Else
            Txtconp.Enabled = True
        End If
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
            FrmSelCliente.lbform.Text = "lista_clie_conpF"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
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

        Dim r1 As String = ""
        Dim r11 As String = ""
        Dim Tr1 As String = ""
        Dim r2 As String = ""
        Dim r22 As String = ""
        Dim Tr2 As String = ""
        Dim r3 As String = ""
        Dim r33 As String = ""
        Dim Tr3 As String = ""
        Dim r4 As String = ""
        Dim r44 As String = ""
        Dim Tr4 As String = ""
        Dim r5 As String = ""
        Dim Tr5 As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO ACTUAL: " & PerActual

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


        r1 = txtdias.Text
        r11 = r1 + 1
        Tr1 = "SALDO 0 - " & r1

        r2 = txtdias.Text * 2
        r22 = r2 + 1
        Tr2 = "SALDO " & r11 & " - " & r2

        r3 = txtdias.Text * 3
        r33 = r3 + 1
        Tr3 = "SALDO " & r22 & " - " & r3

        r4 = txtdias.Text * 4
        r44 = r4 + 1
        Tr4 = "SALDO " & r33 & " - " & r4

        r5 = txtdias.Text * 5
        Tr5 = "SALDO " & r44 & " O MAS"

        fc = Strings.Right(fecha1.Text, 4) & "-" & Strings.Mid(fecha1.Text, 4, 2) & "-" & Strings.Left(fecha1.Text, 2)

        Dim cl As String = ""
        Dim ff As String = ""
        Dim co As String = ""
        If c2.Checked = True Then
            cl = " AND c.nitc = '" & txtnitc.Text & "' AND  t.nit= '" & txtnitc.Text & "' "
        End If
        If f1.Checked = True Then
            ff = " AND c.fecha >= '" & fc & "'"
        Else
            ff = " AND (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) >= '" & fc & "' AND (SELECT ADDDATE( c.fecha, INTERVAL c.vmto DAY) ) <= NOW()"
        End If
        If d2.Checked = True Then
            co = " AND c.concepto LIKE  '" & Txtconp.Text & " %'"
        End If

        sql = " SELECT c.concepto, c.nitc, c.nomnit,  c.doc, CAST( c.fecha AS CHAR( 20 ) ) AS fecha,  " _
        & " CAST( (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) AS CHAR( 20 ) ) as nitv,  " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r1 & ", (c.total - c.pagado), 0) AS retiva,  " _
        & " IF ((SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r11 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r2 & " , (c.total - c.pagado), 0 ) AS retica, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r22 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r3 & " , (c.total - c.pagado), 0 ) AS pagado, " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r33 & " AND (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) < " & r4 & " , (c.total - c.pagado), 0 ) AS vpos,  " _
        & " IF ( (SELECT DATEDIFF( NOW( ) ,  (SELECT ADDDATE(  c.fecha, INTERVAL c.vmto DAY) ) ) ) > " & r5 & ", (c.total - c.pagado), 0 ) AS tasa,  (total - pagado) AS total FROM cobdpen c, terceros t  " _
        & " WHERE c.nitc=t.nit AND c.total > c.pagado " & cl & " " & ff & " " & co & "ORDER BY concepto "


        Dim doc_aj As String = ""
        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT par_aju FROM car_par ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)



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

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportConcF.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportConcF.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtr1 As New ParameterField
            Dim Prtr2 As New ParameterField
            Dim Prtr3 As New ParameterField
            Dim Prtr4 As New ParameterField
            Dim Prtr5 As New ParameterField
            Dim PrAJ As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtr1.Name = "R1"
            Prtr1.CurrentValues.AddValue(Tr1.ToString)

            Prtr2.Name = "R2"
            Prtr2.CurrentValues.AddValue(Tr2.ToString)

            Prtr3.Name = "R3"
            Prtr3.CurrentValues.AddValue(Tr3.ToString)

            Prtr4.Name = "R4"
            Prtr4.CurrentValues.AddValue(Tr4.ToString)

            Prtr5.Name = "R5"
            Prtr5.CurrentValues.AddValue(Tr5.ToString)

            PrAJ.Name = "doc_aj"
            PrAJ.CurrentValues.AddValue(doc_aj.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtr1)
            prmdatos.Add(Prtr2)
            prmdatos.Add(Prtr3)
            prmdatos.Add(Prtr4)
            prmdatos.Add(Prtr5)
            prmdatos.Add(PrAJ)

            FrmReportConcF.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportConcF.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
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
                FrmSelCliente.lbform.Text = "lista_clie_conpF"
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
            FrmSelCliente.lbform.Text = "lista_clie_conpF"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class