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
Public Class FrmInfTercerosInm
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            txtnom.Enabled = True
            cbclas.Text = "TODOS"
        Else
            txttip.Enabled = False
            txtnom.Enabled = False
        End If
    End Sub

    Private Sub txttip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.DoubleClick
        FrmSelDueño.Text = "Seleccionar Terceros Inmobiliaria"
        FrmSelDueño.lbform.Text = "cliente_inm"
        FrmSelDueño.ShowDialog()
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE  tr.nit = '" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            txtnom.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Terceros Inmobiliaria"
                FrmSelDueño.lbform.Text = "cliente_inm"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txttip.Text = tabla.Rows(0).Item("nit")
            txtnom.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""
            MiConexion(bda)
            Cerrar()
            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = "N.I.T: " & tabla2.Rows(0).Item("nit")

            Dim ter As String = ""
            Dim cla As String = ""
            If c2.Checked = True Then
                ter = "AND ti.nit = '" & txttip.Text & "'"
            End If

            If cbclas.Text <> "TODOS" Then
                cla = " AND ti.clase ='" & cbclas.Text & "' "
            End If


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            If cbTd.Checked = False Then ' INFORME NORMAL
                sql = "SELECT ti.nit, concat(t.nombre,' ',t.apellidos) as nombre ,ti.clase as apellidos," _
                & " if( (SELECT count(*) FROM `inmuebles` WHERE nitp= ti.nit)='0','--',cast((SELECT count(*) FROM `inmuebles` WHERE nitp= ti.nit ) as char(10))) as pais, " _
                & "  CONCAT(t.cta_banco1,IF(t.cbanco<>'',CONCAT(' BANCO: ',t.cbanco),'')) AS contacto  " _
                & " FROM tercerosinm ti left join terceros t on t.nit=ti.nit where ti.nit<>'' " & ter & " " & cla & " " _
                & " Order by nombre"

                Dim tabla As DataTable
                tabla = New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportTercInm.rpt")
                CrReport.SetDataSource(tabla)
                FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrAJ As New ParameterField

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
            Else
                ' INFORME DETALLADO

                '        sql = "SELECT t.nit, TRIM(CONCAT(t.`nombre`,' ',t.`apellidos`)) AS nombre, ti.`clase` AS tipo, t.`dir`, " _
                '& " TRIM(CONCAT(t.telefono,' ',t.celular)) AS telefono, m.`descripcion` AS contacto, " _
                '& " IF( (SELECT COUNT(*) FROM `inmuebles` WHERE ti.nit= nitp)='0',0,CAST((SELECT COUNT(*) FROM `inmuebles` WHERE nitp= nitp ) AS CHAR(10))) AS cupo" _
                '& " FROM terceros t ,  tercerosinm ti , sae.mun m " _
                '& " WHERE m.coddep=t.dept AND m.`codmun`= t.`mun` AND  t.`nit` = ti.nit " & ter & " " & cla & " " _
                '& " ORDER BY nombre "

                sql = "SELECT t.nit, TRIM(CONCAT(t.`nombre`,' ',t.`apellidos`)) AS nombre, ti.`clase` AS tipo, t.`dir`, " _
    & " TRIM(CONCAT(t.telefono,' ',t.celular)) AS telefono, m.`descripcion` AS contacto, " _
    & "  CONCAT(t.cta_banco1,IF(t.cbanco<>'',CONCAT(' BANCO: ',t.cbanco),'')) AS correo  " _
    & " FROM terceros t ,  tercerosinm ti , sae.mun m " _
    & " WHERE m.coddep=t.dept AND m.`codmun`= t.`mun` AND  t.`nit` = ti.nit " & ter & " " & cla & " " _
    & " ORDER BY nombre "

                Dim tabla As DataTable
                tabla = New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportTercInmD.rpt")
                CrReport.SetDataSource(tabla)
                FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrAJ As New ParameterField

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

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub FrmInfTercerosInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbclas.Text = "TODOS"
    End Sub
End Class