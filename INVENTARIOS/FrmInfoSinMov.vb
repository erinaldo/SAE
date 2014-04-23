Imports iTextSharp.text
Imports iTextSharp.text.pdf
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

Public Class FrmInfoSinMov

    Public ent, sal, tras, fc1, fc2, fc3, fc4 As String
    Public art As DataTable

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoSinMov_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "select * from parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            ent = tabla.Rows(0).Item("entradas").ToString
            sal = tabla.Rows(0).Item("salidas").ToString
            tras = tabla.Rows(0).Item("traslados").ToString
        End If

        art = New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".articulos ORDER BY " & bda & ".articulos.codart; " 'WHERE " & bda & ".articulos.doc_de='I';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(art)

    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_PDF()


        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim p As String = ""
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
        Dim cad As String = ""
        Dim pr As String = ""
        Dim ini As String = ""
        Dim pa As Integer
        pa = PerActual(0) & PerActual(1)
        ini = "01"
        '///////////////////////////////////////////////////////
        If exis.Checked = True Then ' .... Solo existencia
            cad = " AND (" & cant & " ) <>0 "
        End If

        For i = 1 To pa
            If i < 10 Then
                p = "0" & i
                pr = p - 1
            Else
                p = i
                pr = p - 1
            End If
            If p = ini Then
                sql = " SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
               & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
               & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
               & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " " & cad
                '& " AND (" & cant & " ) <>0 "
            Else
                sql = sql & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
                & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
                & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
                & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " " & cad
                '& " AND (" & cant & " ) <>0  "
            End If
        Next

        If or1.Checked = True Then
            sql = sql & " GROUP BY codart  ORDER BY referencia "
        Else
            sql = sql & " GROUP BY codart  ORDER BY codart "
        End If
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        If or1.Checked = True Then
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov2.rpt")
        Else
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov.rpt")
        End If
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
        '/////////////////////////////////////////////////////////////////////////

        ' '' ............. Ordenar por referencias
        ''If or1.Checked = True Then
        ''    If exis.Checked = True Then ' .... Solo existencia
        ''        For i = 1 To pa
        ''            If i < 10 Then
        ''                p = "0" & i
        ''                pr = p - 1
        ''            Else
        ''                p = i
        ''                pr = p - 1
        ''            End If
        ''            If p = ini Then
        ''                sql = " SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''               & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
        ''               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''               & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
        ''               & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
        ''               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " " _
        ''               & " AND (" & cant & " ) <>0 "
        ''            Else
        ''                sql = sql & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
        ''                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
        ''                & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
        ''                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " " _
        ''                & " AND (" & cant & " ) <>0  "
        ''            End If
        ''        Next
        ''        sql = sql & " GROUP BY codart  ORDER BY referencia "

        ''        'TextBox1.Text = sql

        ''        Dim tabla As DataTable
        ''        tabla = New DataTable
        ''        myCommand.Parameters.Clear()
        ''        myCommand.CommandText = sql
        ''        myCommand.Connection = conexion
        ''        myAdapter.SelectCommand = myCommand
        ''        myAdapter.Fill(tabla)

        ''        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ''        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        ''        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov2.rpt")
        ''        CrReport.SetDataSource(tabla)
        ''        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        ''        FrmRepSinMov2.CrystalReportViewer1.ReportSource = CrReport

        ''        Try
        ''            Dim Prcompañia As New ParameterField
        ''            Dim PrNit As New ParameterField
        ''            Dim Prperiodo As New ParameterField

        ''            Dim prmdatos As ParameterFields
        ''            prmdatos = New ParameterFields

        ''            Prcompañia.Name = "comp"
        ''            Prcompañia.CurrentValues.AddValue(nom.ToString)

        ''            PrNit.Name = "nit"
        ''            PrNit.CurrentValues.AddValue(nit.ToString)

        ''            Prperiodo.Name = "periodo"
        ''            Prperiodo.CurrentValues.AddValue(PerActual.ToString)

        ''            prmdatos.Add(Prcompañia)
        ''            prmdatos.Add(PrNit)
        ''            prmdatos.Add(Prperiodo)

        ''            FrmRepSinMov2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
        ''            FrmRepSinMov2.ShowDialog()
        ''        Catch ex As Exception
        ''            MsgBox(sql)
        ''        End Try
        ''    Else ' Todas las exist

        ''        For i = 1 To pa
        ''            If i < 10 Then
        ''                p = "0" & i
        ''                pr = p - 1
        ''            Else
        ''                p = i
        ''                pr = p - 1
        ''            End If

        ''            If p = ini Then
        ''                sql = " SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia , CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''               & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
        ''               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''               & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
        ''               & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
        ''               & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " "
        ''            Else
        ''                sql = sql & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, a.referencia as referencia , CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                & " " & cant & "  AS pp, c.costprom AS cos_pro, ( c.costprom * " & cant & " ) AS precio, " _
        ''                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND ( a.codart = d.codart ) " _
        ''                & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo =" & pr & " AND d.doc = m.doc AND  " _
        ''                & " ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) ) ) >  " & NumericUpDown1.Text & " "
        ''            End If
        ''        Next

        ''        sql = sql & " GROUP BY codart  ORDER BY referencia "


        ''        'TextBox1.Text = sql


        ''        Dim tabla As DataTable
        ''        tabla = New DataTable
        ''        myCommand.Parameters.Clear()
        ''        myCommand.CommandText = sql
        ''        myCommand.Connection = conexion
        ''        myAdapter.SelectCommand = myCommand
        ''        myAdapter.Fill(tabla)

        ''        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ''        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        ''        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov2.rpt")
        ''        CrReport.SetDataSource(tabla)
        ''        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        ''        FrmRepSinMov2.CrystalReportViewer1.ReportSource = CrReport



        ''        Try
        ''            Dim Prcompañia As New ParameterField
        ''            Dim PrNit As New ParameterField
        ''            Dim Prperiodo As New ParameterField

        ''            Dim prmdatos As ParameterFields
        ''            prmdatos = New ParameterFields

        ''            Prcompañia.Name = "comp"
        ''            Prcompañia.CurrentValues.AddValue(nom.ToString)

        ''            PrNit.Name = "nit"
        ''            PrNit.CurrentValues.AddValue(nit.ToString)

        ''            Prperiodo.Name = "periodo"
        ''            Prperiodo.CurrentValues.AddValue(PerActual.ToString)


        ''            prmdatos.Add(Prcompañia)
        ''            prmdatos.Add(PrNit)
        ''            prmdatos.Add(Prperiodo)

        ''            FrmRepSinMov2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
        ''            FrmRepSinMov2.ShowDialog()

        ''        Catch ex As Exception
        ''            MsgBox(sql)
        ''        End Try

        ''    End If


        ''Else ' Orden normal



        ''    If exis.Checked = True Then ' .... Solo existencia

        ''        For i = 1 To pa

        ''            If i < 10 Then
        ''                p = "0" & i
        ''                pr = p - 1

        ''            Else
        ''                p = i
        ''                pr = p - 1
        ''            End If


        ''            If p = ini Then

        ''                sql = " SELECT * FROM ( SELECT a.nivel,  a.codart, a.nomart, a.codbar as estado, a.cant_min, a.cos_uni as pp, a.cos_pro, a.precio, a.empaque " _
        ''                  & " FROM articulos a WHERE a.nivel = (  Select p.desc1 FROM parinven p ) " _
        ''                  & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                  & " " & cant & " AS pp, c.costprom AS cos_pro, " _
        ''                  & " (c.costprom * " & cant & " ) AS precio, " _
        ''                  & "( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                  & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND (a.codart = d.codart) " _
        ''                  & "  AND ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) >   " & NumericUpDown1.Text & " " _
        ''                  & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo = " & pr & " AND d.doc = m.doc  AND " & cant & " <> 0 ) AS consulta  "


        ''            Else

        ''                sql = sql & " UNION SELECT * FROM ( SELECT a.nivel,  a.codart, a.nomart, a.codbar as estado, a.cant_min, a.cos_uni as pp, a.cos_pro, a.precio, a.empaque " _
        ''                  & " FROM articulos a WHERE a.nivel = (  Select p.desc1 FROM parinven p ) " _
        ''                  & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                  & " " & cant & " AS pp, c.costprom AS cos_pro, " _
        ''                  & " (c.costprom * " & cant & " ) AS precio, " _
        ''                  & "( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                  & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND (a.codart = d.codart)" _
        ''                  & "  AND ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) >   " & NumericUpDown1.Text & " " _
        ''                 & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo = " & pr & " AND d.doc = m.doc   AND " & cant & " <> 0 ) AS consulta  "


        ''                '  TextBox1.Text = sql


        ''            End If
        ''        Next

        ''        sql = sql & " GROUP BY codart ORDER BY codart "

        ''        Dim tabla As DataTable
        ''        tabla = New DataTable
        ''        myCommand.Parameters.Clear()
        ''        myCommand.CommandText = sql
        ''        myCommand.Connection = conexion
        ''        myAdapter.SelectCommand = myCommand
        ''        myAdapter.Fill(tabla)

        ''        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ''        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        ''        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov.rpt")
        ''        CrReport.SetDataSource(tabla)
        ''        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        ''        FrmRepSinMov.CrystalReportViewer1.ReportSource = CrReport



        ''        Try
        ''            Dim Prcompañia As New ParameterField
        ''            Dim PrNit As New ParameterField
        ''            Dim Prperiodo As New ParameterField

        ''            Dim prmdatos As ParameterFields
        ''            prmdatos = New ParameterFields

        ''            Prcompañia.Name = "comp"
        ''            Prcompañia.CurrentValues.AddValue(nom.ToString)

        ''            PrNit.Name = "nit"
        ''            PrNit.CurrentValues.AddValue(nit.ToString)

        ''            Prperiodo.Name = "periodo"
        ''            Prperiodo.CurrentValues.AddValue(PerActual.ToString)


        ''            prmdatos.Add(Prcompañia)
        ''            prmdatos.Add(PrNit)
        ''            prmdatos.Add(Prperiodo)

        ''            FrmRepSinMov.CrystalReportViewer1.ParameterFieldInfo = prmdatos
        ''            FrmRepSinMov.ShowDialog()

        ''        Catch ex As Exception
        ''            MsgBox(sql)
        ''        End Try



        ''    Else ' todas las exist

        ''        For i = 1 To pa

        ''            If i < 10 Then
        ''                p = "0" & i
        ''                pr = p - 1

        ''            Else
        ''                p = i
        ''                pr = p - 1
        ''            End If


        ''            If p = ini Then

        ''                sql = " SELECT * FROM ( SELECT a.nivel,  a.codart, a.nomart, a.codbar as estado, a.cant_min, a.cos_uni as pp, a.cos_pro, a.precio, a.empaque " _
        ''                  & " FROM articulos a WHERE a.nivel = (  Select p.desc1 FROM parinven p ) " _
        ''                  & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                  & " " & cant & " AS pp, c.costprom AS cos_pro, " _
        ''                  & " (c.costprom * " & cant & " ) AS precio, " _
        ''                  & "( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                  & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND (a.codart = d.codart) " _
        ''                  & "  AND ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) >   " & NumericUpDown1.Text & " " _
        ''                  & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo = " & pr & " AND d.doc = m.doc ) AS consulta  "


        ''            Else

        ''                sql = sql & " UNION SELECT * FROM ( SELECT a.nivel,  a.codart, a.nomart, a.codbar as estado, a.cant_min, a.cos_uni as pp, a.cos_pro, a.precio, a.empaque " _
        ''                  & " FROM articulos a WHERE a.nivel = (  Select p.desc1 FROM parinven p ) " _
        ''                  & " UNION SELECT a.nivel, d.codart AS codart, d.nomart AS nomart, CONCAT( m.dia,  '/', m.per ) AS estado, a.cant_min, " _
        ''                  & " " & cant & " AS pp, c.costprom AS cos_pro, " _
        ''                  & " (c.costprom * " & cant & " ) AS precio, " _
        ''                  & "( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) AS empaque " _
        ''                  & " FROM deta_mov" & p & " d, movimientos" & p & " m, con_inv c, articulos a WHERE (c.codart = d.codart )AND (a.codart = d.codart)" _
        ''                  & "  AND ( SELECT DATEDIFF( NOW( ) , CONCAT( RIGHT( m.per, 4 ) ,  '-', LEFT( m.per, 2 ) ,  '-', LPAD( m.dia, 2,  '0' ) ) )) >   " & NumericUpDown1.Text & " " _
        ''                 & " AND dia = ( Select MAX(m.dia) FROM movimientos" & p & " m )  AND c.periodo = " & pr & " AND d.doc = m.doc ) AS consulta  "

        ''            End If
        ''        Next

        ''        sql = sql & " GROUP BY codart ORDER BY codart "


        ''        '  TextBox1.Text = sql


        ''        Dim tabla As DataTable
        ''        tabla = New DataTable
        ''        myCommand.Parameters.Clear()
        ''        myCommand.CommandText = sql
        ''        myCommand.Connection = conexion
        ''        myAdapter.SelectCommand = myCommand
        ''        myAdapter.Fill(tabla)

        ''        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        ''        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        ''        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportEstSinMov.rpt")
        ''        CrReport.SetDataSource(tabla)
        ''        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        ''        FrmRepSinMov.CrystalReportViewer1.ReportSource = CrReport



        ''        Try
        ''            Dim Prcompañia As New ParameterField
        ''            Dim PrNit As New ParameterField
        ''            Dim Prperiodo As New ParameterField

        ''            Dim prmdatos As ParameterFields
        ''            prmdatos = New ParameterFields

        ''            Prcompañia.Name = "comp"
        ''            Prcompañia.CurrentValues.AddValue(nom.ToString)

        ''            PrNit.Name = "nit"
        ''            PrNit.CurrentValues.AddValue(nit.ToString)

        ''            Prperiodo.Name = "periodo"
        ''            Prperiodo.CurrentValues.AddValue(PerActual.ToString)


        ''            prmdatos.Add(Prcompañia)
        ''            prmdatos.Add(PrNit)
        ''            prmdatos.Add(Prperiodo)

        ''            FrmRepSinMov.CrystalReportViewer1.ParameterFieldInfo = prmdatos
        ''            FrmRepSinMov.ShowDialog()

        ''        Catch ex As Exception
        ''            MsgBox(sql)
        ''        End Try



        ''    End If

        ''End If
    End Sub

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim t1, t2 As String
        Dim i, j, k, pag, med, niv, pv As Integer
        Dim sum1, sument, sumsal, totalent, totalsal, cant, cant1 As Double
        Dim tabla, tabla1, tabla2, banner As New DataTable
        Dim cadena, cadena1, cv, consulta, consulta2, per, tp As String
        tp = ""
        Dim fec1 As Date
        pag = 1
        per = ""
        cv = ""
        cant1 = 0
        sument = 0
        totalent = 0
        totalsal = 0
        sumsal = 0
        niv = 0
        pv = 0
        cant = 0
        sum1 = 0
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
                FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Refresh()
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            banner = New DataTable
            myAdapter.Fill(banner)
            cb.ShowTextAligned(50, banner.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & banner.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
            'cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & "                                " & "PERIODO FINAL: " & "/" & cbfin.Text & txtpfin.Text, 20, 760, 0)
            cadena = "INFORME GENERAL DE ARTICULOS"
            med = 250
            'i = cadena.Length
            'i = i / 2
            'j = med - i
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 750, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
            k = 700
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.BeginText()
            cb.ShowTextAligned(50, "DIAS", 20, k - 10, 0)
            cb.ShowTextAligned(50, "DESCRIPCION", 60, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 200, k, 0)
            cb.ShowTextAligned(50, "MINIMA", 200, k - 10, 0)
            cb.ShowTextAligned(50, "PUNTO DE", 250, k, 0)
            cb.ShowTextAligned(50, "PEDIDO", 250, k - 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 330, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 330, k - 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 420, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PROMEDIO", 420, k - 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "A COSTO", 500, k - 10, 0)
            cb.ShowTextAligned(50, "ULTIMA", 510, k, 0)
            cb.ShowTextAligned(50, "FECHA", 510, k - 10, 0)
            cb.ShowTextAligned(50, "DIAS", 550, k - 10, 0)
            k = k - 30

            'CONSULTA DE DIAS



            For i = 0 To art.Rows.Count - 1

                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()

                consulta = ""
                For j = 1 To Val(Mid(PerActual, 1, 2))
                    t1 = bda & ".movimientos" & adicionar(j)
                    t2 = bda & ".deta_mov" & adicionar(j)
                    If consulta = "" Then
                        consulta = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc WHERE " & t2 & ".codart='" & art.Rows(i).Item("codart") & "' "
                        cadena = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc ORDER BY " & t2 & ".doc) "
                        consulta = consulta & " ORDER BY " & t2 & ".doc) "
                        'cadena = cadena & " ORDER BY " & t2 & ".doc) "
                    Else
                        consulta2 = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc WHERE " & t2 & ".codart='" & art.Rows(i).Item("codart") & "' "
                        consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & ".doc)"
                        cadena1 = "(SELECT " & t1 & ".per," & t1 & ".dia," & t1 & ".doc," & t2 & ".codart FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".doc=" & t2 & ".doc ORDER BY " & t2 & ".doc) "
                        cadena = cadena & " UNION " & cadena1
                    End If
                Next

                consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.per,consulta.dia ASC"
                'cadena = consulta

                tabla = New DataTable
                myCommand.CommandText = consulta
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                If tabla.Rows.Count <> 0 Then

                    'tabla.Rows(tabla.Rows.Count - 1).Item("dia").ToString()
                    'cb.ShowTextAligned(50, DateDiff(DateInterval.Day, fec1, Now.Date), 20, k, 0)
                    tabla1 = New DataTable
                    myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & art.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & Mid(PerActual, 1, 2) & "'"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla1)
                    cant = 0
                    tabla2 = New DataTable
                    myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla2)
                    If tabla2.Rows.Count <> 0 Then
                        For l = 1 To tabla2.Rows.Count - 1
                            cant = cant + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                        Next
                    End If
                    fec1 = DateValue(tabla.Rows(tabla.Rows.Count - 1).Item("dia").ToString() & "/" & tabla.Rows(tabla.Rows.Count - 1).Item("per").ToString())
                    If Val(DateDiff(DateInterval.Day, fec1, Now.Date)) >= Val(NumericUpDown1.Value) Then
                        If exis.Checked = True Then
                            If cant > 0 Then
                                cb.ShowTextAligned(50, art.Rows(i).Item("codart").ToString, 20, k, 0)
                                cb.ShowTextAligned(50, CambiaCadena(art.Rows(i).Item("desart").ToString, 30), 60, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0", 220, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 330, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costprom").ToString), 420, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant), 500, k, 0)
                                sum1 = sum1 + (CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant)
                                totalent = totalent + (CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant)
                                cb.ShowTextAligned(50, tabla.Rows(tabla.Rows.Count - 1).Item("dia").ToString() & "/" & tabla.Rows(tabla.Rows.Count - 1).Item("per").ToString(), 510, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, DateDiff(DateInterval.Day, fec1, Now.Date), 570, k, 0)
                                k = k - 10
                            End If
                        Else
                            cb.ShowTextAligned(50, art.Rows(i).Item("codart").ToString, 20, k, 0)
                            cb.ShowTextAligned(50, CambiaCadena(art.Rows(i).Item("desart").ToString, 30), 60, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0", 220, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 330, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costprom").ToString), 420, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant), 500, k, 0)
                            sum1 = sum1 + (CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant)
                            totalent = totalent + (CDbl(tabla1.Rows(0).Item("costprom").ToString) * cant)
                            cb.ShowTextAligned(50, tabla.Rows(tabla.Rows.Count - 1).Item("dia").ToString() & "/" & tabla.Rows(tabla.Rows.Count - 1).Item("per").ToString(), 510, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, DateDiff(DateInterval.Day, fec1, Now.Date), 570, k, 0)
                            k = k - 10
                        End If


                    End If


                Else
                    cv = "SELECT consulta.* FROM (" & cadena & ") AS consulta WHERE consulta.codart like '" & art.Rows(i).Item("codart").ToString & "%' ORDER BY consulta.per,consulta.dia ASC"

                    tabla = New DataTable
                    myCommand.CommandText = cv
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If Len(art.Rows(i).Item("codart").ToString) = 2 And tabla.Rows.Count <> 0 Then
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        If tp <> "" Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 500, k, 0)
                            k = k - 10
                            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
                            sum1 = 0
                            k = k - 20
                        End If

                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        cb.ShowTextAligned(50, art.Rows(i).Item("codart").ToString & "   " & art.Rows(i).Item("nomart").ToString, 20, k, 0)
                        tp = art.Rows(i).Item("nomart").ToString
                        k = k - 20
                    End If

                End If

                If k <= 80 Then
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    cb.ShowTextAligned(50, banner.Rows(0).Item("descripcion"), 20, 810, 0)
                    cb.ShowTextAligned(50, "N.I.T. " & banner.Rows(0).Item("nit"), 20, 800, 0)
                    cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                    cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                    cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                    'cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & "                                " & "PERIODO FINAL: " & "/" & cbfin.Text & txtpfin.Text, 20, 760, 0)
                    cadena = "INFORME GENERAL DE ARTICULOS"
                    med = 250
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 750, 0)
                    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
                    k = 700
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                    cb.BeginText()
                    cb.ShowTextAligned(50, "DIAS", 20, k - 10, 0)
                    cb.ShowTextAligned(50, "DESCRIPCION", 60, k - 10, 0)
                    cb.ShowTextAligned(50, "CANTIDAD", 200, k, 0)
                    cb.ShowTextAligned(50, "MINIMA", 200, k - 10, 0)
                    cb.ShowTextAligned(50, "PUNTO DE", 250, k, 0)
                    cb.ShowTextAligned(50, "PEDIDO", 250, k - 10, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 330, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL", 330, k - 10, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 420, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PROMEDIO", 420, k - 10, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 500, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "A COSTO", 500, k - 10, 0)
                    cb.ShowTextAligned(50, "ULTIMA", 510, k, 0)
                    cb.ShowTextAligned(50, "FECHA", 510, k - 10, 0)
                    cb.ShowTextAligned(50, "DIAS", 550, k - 10, 0)
                    k = k - 30
                End If

            Next
            If art.Rows.Count <> 0 Then
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 500, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
                sum1 = 0
                k = k - 20
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 500, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "VALOR TOTAL ", 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalent), 500, k, 0)
            End If
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                'FrmReportePuc.ShowDialog()
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try

    End Sub

    Public Function adicionar(ByVal texto As String)
        Dim num As String
        If Len(texto) = 1 Then
            num = "0" & texto
        Else
            num = texto
        End If
        Return num
    End Function

    Public Function extraer_cadena2(ByVal cadena As String, ByVal ti As Integer, ByVal tf As Integer)
        Dim cad As String
        If cadena.Length >= 7 Then
            cad = ""
            For j = ti To tf - 1
                cad = cad & cadena(j)
            Next
        Else
            cad = cadena
        End If
        Return cad
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

End Class