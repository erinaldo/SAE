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
Public Class FrmInfCartComision
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
        Else
            txtnitc.Enabled = True
        End If
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            Try
                Dim items As Integer
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM vendedores where estado='activo' ORDER BY nombre ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                Refresh()
                items = tabla2.Rows.Count
                FrmSelVendedor.gitems.RowCount = items + 1
                For i = 0 To items - 1
                    FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                    FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
                Next
                FrmSelVendedor.lbform.Text = "infcartcom"
                FrmSelVendedor.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".vendedores WHERE nitv='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            txtcliente.Clear()
        Else
            txtcliente.Text = tabla.Rows(0).Item("nombre").ToString()
        End If
    End Sub

    Private Sub FrmInfCartComision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 5)
        txtpini.Text = Strings.Right(PerActual, 5)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If c2.Checked = True And txtnitc.Text = "" Then
            MsgBox("Verifique el nit del vendedor", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        pdf()
    End Sub
    Private Sub pdf()
        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim tit As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        per = "PERIODO INICIAL: " & cbini.Text & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & txtpfin.Text
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        MiConexion(bda)

        Dim n As String = ""
        If c2.Checked = True Then
            n = " AND o.nitv = '" & txtnitc.Text & "'"
        End If

        If d2.Checked = True Then
            sql = "SELECT nomnit, SUM(subtotal) AS subtotal, SUM(total) AS total FROM ( "
        End If



        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = sql & "SELECT CONCAT(o.nitv,' ',v.`nombre`) AS nomnit,  o.doc AS doc, o.doc_afec AS ctaiva, TRIM(CONCAT(o.nitc,' ',t.`nombre`,' ', t.apellidos)) AS concepto, " _
                & " CONCAT(o.dia,'/',o.periodo) AS ctaret, o.credito AS subtotal, o.codcon, c.`concepto` AS descrip, c.`porcomi` AS num, " _
                & " ( o.`credito`* (c.`porcomi`/100)) AS total,  " _
                & " IF ( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
                & " > ADDDATE(d.fecha, INTERVAL d.vmto DAY),  " _
                & " DATEDIFF( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
                & ",ADDDATE(d.fecha, INTERVAL d.vmto DAY)),0) AS tipafec " _
                & " FROM ot_cpc" & p & " o, terceros t, vendedores v, concomi c, cobdpen d " _
                & " WHERE o.codcon<>'' AND o.nitc= t.nit AND v.`nitv`=o.nitv AND c.`codcon`= o.`codcon` AND o.doc_afec= d.doc AND o.`estado` ='AP' " _
                & " AND o.dia BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & n

            Else
                If p = cbini.Text Then
                    sql = sql & "SELECT CONCAT(o.nitv,' ',v.`nombre`) AS nomnit,  o.doc AS doc, o.doc_afec AS ctaiva, TRIM(CONCAT(o.nitc,' ',t.`nombre`,' ', t.apellidos)) AS concepto, " _
               & " CONCAT(o.dia,'/',o.periodo) AS ctaret, o.credito AS subtotal, o.codcon, c.`concepto` AS descrip, c.`porcomi` AS num, " _
               & " ( o.`credito`* (c.`porcomi`/100)) AS total,  " _
               & " IF ( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
               & " > ADDDATE(d.fecha, INTERVAL d.vmto DAY),  " _
               & " DATEDIFF( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
               & ",ADDDATE(d.fecha, INTERVAL d.vmto DAY)),0) AS tipafec " _
               & " FROM ot_cpc" & p & " o, terceros t, vendedores v, concomi c, cobdpen d " _
               & " WHERE o.codcon<>'' AND o.nitc= t.nit AND v.`nitv`=o.nitv AND c.`codcon`= o.`codcon` AND o.doc_afec= d.doc AND o.`estado` ='AP' " _
               & " AND o.dia >= '" & txtdi1.Text & "' " & n

                  ElseIf p <> cbini.Text And p <> cbfin.Text Then
                    sql = sql & " UNION SELECT CONCAT(o.nitv,' ',v.`nombre`) AS nomnit,  o.doc AS doc, o.doc_afec AS ctaiva, TRIM(CONCAT(o.nitc,' ',t.`nombre`,' ', t.apellidos)) AS concepto, " _
            & " CONCAT(o.dia,'/',o.periodo) AS ctaret, o.credito AS subtotal, o.codcon, c.`concepto` AS descrip, c.`porcomi` AS num, " _
            & " ( o.`credito`* (c.`porcomi`/100)) AS total,  " _
            & " IF ( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
            & " > ADDDATE(d.fecha, INTERVAL d.vmto DAY),  " _
            & " DATEDIFF( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
            & ",ADDDATE(d.fecha, INTERVAL d.vmto DAY)),0) AS tipafec " _
            & " FROM ot_cpc" & p & " o, terceros t, vendedores v, concomi c, cobdpen d " _
            & " WHERE o.codcon<>'' AND o.nitc= t.nit AND v.`nitv`=o.nitv AND c.`codcon`= o.`codcon` AND o.doc_afec= d.doc AND o.`estado` ='AP' " & n

                ElseIf p = cbfin.Text Then

                    sql = sql & " UNION SELECT CONCAT(o.nitv,' ',v.`nombre`) AS nomnit,  o.doc AS doc, o.doc_afec AS ctaiva, TRIM(CONCAT(o.nitc,' ',t.`nombre`,' ', t.apellidos)) AS concepto, " _
             & " CONCAT(o.dia,'/',o.periodo) AS ctaret, o.credito AS subtotal, o.codcon, c.`concepto` AS descrip, c.`porcomi` AS num, " _
             & " ( o.`credito`* (c.`porcomi`/100)) AS total,  " _
             & " IF ( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
             & " > ADDDATE(d.fecha, INTERVAL d.vmto DAY),  " _
             & " DATEDIFF( CAST( CONCAT(RIGHT(o.periodo,4),'-',LEFT(o.periodo,2),'-',o.dia) AS DATE) " _
             & ",ADDDATE(d.fecha, INTERVAL d.vmto DAY)),0) AS tipafec " _
             & " FROM ot_cpc" & p & " o, terceros t, vendedores v, concomi c, cobdpen d " _
             & " WHERE o.codcon<>'' AND o.nitc= t.nit AND v.`nitv`=o.nitv AND c.`codcon`= o.`codcon` AND o.doc_afec= d.doc AND o.`estado` ='AP' " _
             & " AND o.dia <= '" & txtdi2.Text & "' " & n
                End If
            End If

        Next

        sql = sql & " ORDER BY nomnit"
        If d2.Checked = True Then
            sql = sql & ") AS g GROUP BY nomnit"
        End If
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
        If d1.Checked = True Then
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCartComis.rpt")
        ElseIf d2.Checked = True Then
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCartComisr.rpt")
        End If
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try
        FrmReportFacVen.CrystalReportViewer1.ReportSource = CrReport
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
            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)

            FrmReportFacVen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacVen.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class