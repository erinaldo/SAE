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
Public Class FrmImprDocContab

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmImprDocContab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BuscarPeriodo()

        lbperiodo.Text = PerActual
        txtperiodo.Text = PerActual
        txtperiodo2.Text = PerActual

        If Today.Day < 10 Then
            txt_fec_fin.Text = "0" & Today.Day
        Else
            txt_fec_fin.Text = Today.Day
        End If

        cbtipo.Items.Clear()
        txtnomdoc.Text = ""
        Dim td As New DataTable
        myCommand.CommandText = "SELECT ce,ci,rc  FROM `parotdoc` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)

        If td.Rows.Count = 0 Then
            MsgBox("Aun no ha definido los tipos de documentos", MsgBoxStyle.Information, "SAE")
            Me.Close()
        Else
            For i = 0 To td.Rows.Count - 1
                cbtipo.Items.Add(td.Rows(i).Item(0))
                cbtipo.Items.Add(td.Rows(i).Item(1))
                cbtipo.Items.Add(td.Rows(i).Item(2))
            Next
            cbtipo.Text = td.Rows(0).Item(0)
            cbtipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        End If



    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click


        Dim nom As String = ""
        Dim nitp As String = ""
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
        nitp = "NIT: " & tabla2.Rows(0).Item("nit")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        If d2.Checked = True Then
            cad = cad & " AND o.num BETWEEN '" & txt_doc_ini.Text & "' AND '" & txt_doc_fin.Text & "' "
        End If
        If f2.Checked = True Then
            cad = cad & " AND o.dia BETWEEN '" & txt_fec_ini.Text & "' AND '" & txt_fec_fin.Text & "' "
        End If


        sql = " SELECT td.descripcion AS ciu_ent, CONCAT(o.`periodo`,'-',o.`doc`) AS dir_ent, o.`ciudad` AS entregar, CONCAT(o.dia,'/',o.`periodo`) AS usuario, o.dia, " _
        & " o.total, o.tn, o.nitc, TRIM(CONCAT(t.`apellidos`,' ', t.`nombre`)) AS d1,  IF(o.efectivo<>'','X','') AS t1,o.cheque AS cta1,o.banco AS cta2,o.sucursal AS cta3, " _
        & " IF(o.tn='CC','X','') AS t2, IF(o.tn='NIT','X','') AS t3,o.elaborado AS d2,o.autorizado AS d3 ,o.contabilizado AS cc, " _
        & "  CAST(CONCAT(RIGHT(o.fecha,2),'/',MID(o.fecha,6,2),'/',LEFT(o.fecha,4)) AS CHAR(15)) AS cta_iva , " _
        & " o.cod_contra as doc_de, o.concepto AS descrip, o.debito as subtotal, o.credito as descuento, o.codigo as cta_desc,o.descrip as observ " _
        & " FROM tipdoc td, ot_doc" & Strings.Left(PerActual, 2) & " o, terceros t  " _
        & " WHERE o.tipo = td.tipodoc And t.nit = o.nitc  AND o.tipo ='" & cbtipo.Text & "' " & cad & "" _
        & " ORDER BY dir_ent, dia"


        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportDocCont.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try
        FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport
        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            'Dim Prperiodo As New ParameterField
            Dim Prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitp.ToString)

            'Prperiodo.Name = "periodo"
            'Prperiodo.CurrentValues.AddValue(per.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            'prmdatos.Add(Prperiodo)

            FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportTributario.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtipo.SelectedIndexChanged

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select descripcion  from tipdoc where tipodoc='" & cbtipo.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count > 0 Then
            txtnomdoc.Text = tabla.Rows(0).Item(0)
        End If

    End Sub

    Private Sub d2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.CheckedChanged
        If d2.Checked = True Then
            txt_doc_ini.Enabled = True
            txt_doc_fin.Enabled = True
        Else
            txt_doc_ini.Enabled = False
            txt_doc_fin.Enabled = False
        End If
    End Sub

    Private Sub f2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f2.CheckedChanged
        If f2.Checked = True Then
            txt_fec_ini.Enabled = True
            txt_fec_fin.Enabled = True
        Else
            txt_fec_ini.Enabled = False
            txt_fec_fin.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class