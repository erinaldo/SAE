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
Public Class FrmInfNovedades

    Private Sub txtinm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.DoubleClick
        Try
            FrmSelInmueble.lbform.Text = "inf_nov"
            FrmSelInmueble.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
        If txtinm.Text = "" Then
            txtinm_DoubleClick(AcceptButton, AcceptButton)
        Else
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inmuebles  WHERE  codigo = '" & txtinm.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txtinm.Text = ""
                Try
                    FrmSelInmueble.lbform.Text = "inf_nov"
                    FrmSelInmueble.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                txtinm.Text = tabla.Rows(0).Item("codigo")
            End If
        End If
    End Sub

    Private Sub txttip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.DoubleClick
        Try
            FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
            FrmSelDueño.lbform.Text = "InfPnov"
            FrmSelDueño.txtclase.Text = "PROPIETARIO"
            FrmSelDueño.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr , terceros t  WHERE  tr.nit = '" & txttip.Text & "' and tr.clase ='PROPIETARIO' AND t.nit=tr.nit;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            txtnom.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
                FrmSelDueño.lbform.Text = "InfPnov"
                FrmSelDueño.txtclase.Text = "PROPIETARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txttip.Text = tabla.Rows(0).Item("nit")
            txtnom.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txtnita_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.DoubleClick
        Try
            FrmSelDueño.Text = "Seleccionar Arrendatario de Inmueble"
            FrmSelDueño.lbform.Text = "InfAnov"
            FrmSelDueño.txtclase.Text = "ARRENDATARIO"
            FrmSelDueño.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr , terceros t  WHERE  tr.nit = '" & txttip.Text & "' and tr.clase ='ARRENDATARIO' AND t.nit=tr.nit;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            txtnom.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Arrendatario de Inmueble"
                FrmSelDueño.lbform.Text = "InfAnov"
                FrmSelDueño.txtclase.Text = "ARRENDATARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txttip.Text = tabla.Rows(0).Item("nit")
            txtnom.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        MiConexion(bda)
        Cerrar()

        If i2.Checked = True And txtinm.Text = "" Then
            MsgBox("Verifique el codigo del inmueble", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If c2.Checked = True And txttip.Text = "" Then
            MsgBox("Verifique el nit del propietario", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If a2.Checked = True And txtnita.Text = "" Then
            MsgBox("Verifique el nit del arrendatario", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        Try
            PDF()
        Catch ex As Exception
            MsgBox("Error al generar el informe, " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Private Sub PDF()
        'ReportInmNovT
        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim desc As String = ""

        MiConexion(bda)


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "N.I.T: " & tabla2.Rows(0).Item("nit")

        Dim tt, tg, f1, f2 As String
        f1 = Strings.Right(fecha1.Text, 4) & "-" & Strings.Mid(fecha1.Text, 4, 2) & "-" & Strings.Left(fecha1.Text, 2)
        f2 = Strings.Right(fecha2.Text, 4) & "-" & Strings.Mid(fecha2.Text, 4, 2) & "-" & Strings.Left(fecha2.Text, 2)
        Dim cad As String = ""
        If g1.Checked = True Then
            tg = "ARRENDATARIO"
            tt = "PROPIETARIO: "
            cad = " CONCAT(n.nita,' ', ta.nombre) AS d1, CONCAT(n.nitp,' ', t.nombre) AS d2 "
        Else
            tg = "PROPIETARIO: "
            tt = "ARRENDATARIO"
            cad = " CONCAT(n.nita,' ', ta.nombre) AS d2, CONCAT(n.nitp,' ', t.nombre) AS d1 "
        End If

        Dim cons As String = ""
        If i2.Checked = True Then
            cons = cons & " and i.codigo= '" & txtinm.Text & "' "
        End If
        If c2.Checked = True Then
            cons = cons & " AND i.nitp = '" & txttip.Text & "'"
        End If




        sql = "SELECT n.ndoc AS doc, CONCAT(n.codigoinm,' - ', i.direccion) AS d3, " _
         & " CONCAT(n.perdoc,' ',doc) AS nitv, n.valor AS iva, n.novedad AS entregar, " _
         & " CAST(CONCAT(RIGHT(n.fecha,2),'/',MID(n.fecha,6,2),'/',LEFT(n.fecha,4)) AS CHAR(15)) AS usuario,  " _
         & " CONCAT(n.nita,' ', ta.nombre, ' ', ta.apellidos) AS d1, CONCAT(n.nitp,' ', t.nombre , ' ', t.apellidos) AS d2  " _
         & "  FROM inm_novdad n, inmuebles i, terceros t, terceros ta  " _
         & "  WHERE i.codigo= n.codigoinm AND n.nita = ta.nit AND t.nit = n.nitp  AND n.fecha BETWEEN '" & f1 & "' AND '" & f2 & "' ORDER BY d1"


        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInmNovT.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prtt As New ParameterField
            Dim Prtg As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prtt.Name = "tt"
            Prtt.CurrentValues.AddValue(tt.ToString)
            Prtg.Name = "tgr"
            Prtg.CurrentValues.AddValue(tg.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtt)
            prmdatos.Add(Prtg)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()
        Catch ex As Exception
        End Try

        Cerrar()
    End Sub

   
    Private Sub FrmInfNovedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '*********************
    End Sub

    Private Sub i2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i2.CheckedChanged
        If i2.Checked = True Then
            txtinm.Enabled = True
        Else
            txtinm.Enabled = False
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub

    Private Sub a2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.CheckedChanged
        If a2.Checked = True Then
            txtnita.Enabled = True
        Else
            txtnita.Enabled = False
        End If
    End Sub
End Class