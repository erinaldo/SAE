
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
Public Class frmInfoFacturas

    Private Sub frmInfoFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub
    Public Function extraer_cadena(ByVal cadena As String, ByVal ti As Integer, ByVal tf As Integer)
        Dim cad As String
        If cadena.Length > 18 Then
            cad = ""
            For j = ti To tf - 1
                cad = cad & cadena(j)
            Next
        Else
            cad = cadena
        End If
        Return cad
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

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True And txttip.Text = "" Then
            MsgBox("Verifique el numero de la factura", MsgBoxStyle.Exclamation, "SAE INFORMES")
            txttip.Focus()
            Exit Sub
        End If

        If CInt(cbini.Text) > CInt(cbfin.Text) Then
            MsgBox("Error Verifique que el Periodo Inicial NO sea mayor al Final", MsgBoxStyle.Exclamation, "SAE INFORMES")
            Exit Sub
        End If

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR FACTURAS ", "", "", "")
        End If

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

        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text
        tit = "INFORME DE FACTURACION"

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


        Dim doc_aj As String = ""
        Dim ng As String = ""
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)

        'Dim tb2 As New DataTable
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = "SELECT nivel1 FROM `parinven`"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tb2)
        'If tb2.Rows.Count > 0 Then
        '    Try
        '        ng = (tb2.Rows(0).Item(0))
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try

        'Else
        '    MsgBox("Verifique los parametros de inventario", MsgBoxStyle.Information, "Verificacion")
        '    Exit Sub
        'End If


        Dim cd As String = ""
        If c2.Checked = True Then ' .... un cod
            cd = "AND df.doc = '" & txttip.Text & "'"
        End If

        If d1.Checked = True Then ' ;;;;;;;;;;;;  Detallado

            For i = Val(cbini.Text) To Val(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If cbini.Text = cbfin.Text Then
                    sql = " SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                        & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                        & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                        & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                        & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc) " _
                        & " AND RIGHT(f.fecha,2) BETWEEN '" & txtdi1.Text & "' and '" & txtdi2.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "
                Else
                    If p = cbini.Text Then
                        sql = " SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                        & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                        & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                        & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                        & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc) " _
                        & " AND right(f.fecha,2)>= '" & txtdi1.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "

                    ElseIf p <> cbini.Text And p <> cbfin.Text Then
                        sql = sql & " UNION SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                        & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                        & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                        & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                        & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc)   " _
                        & " AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "

                    ElseIf p = cbfin.Text Then
                        sql = sql & " UNION SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                       & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                       & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                       & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                       & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc)  " _
                       & " AND right(f.fecha,2)<= '" & txtdi2.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "
                    End If
                End If
            Next

            sql = sql & "ORDER BY doc"


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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFactGanancia.rpt")
            CrReport.SetDataSource(tabla)
            Try
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            Catch ex As Exception

            End Try

            FrmReportFacArt.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtitulo As New ParameterField
                Dim PrAJ As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtitulo.Name = "titulo"
                Prtitulo.CurrentValues.AddValue(tit.ToString)

                PrAJ.Name = "doc_aj"
                PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtitulo)
                prmdatos.Add(PrAJ)

                FrmReportFacArt.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacArt.ShowDialog()
            Catch ex As Exception
            End Try
        Else

            sql = "select c.doc, sum(c.valor) as valor, c.cta_inv, sum(c.costo) as costo, sum(c.vtotal) as vtotal from ("
            For i = Val(cbini.Text) To Val(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If cbini.Text = cbfin.Text Then

                    sql = sql & " SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                     & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                     & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                     & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                     & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc) " _
                     & "  AND RIGHT(f.fecha,2) BETWEEN '" & txtdi1.Text & "' and '" & txtdi2.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "
                 
                Else
                    If p = cbini.Text Then

                        sql = sql & " SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                      & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                      & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                      & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                      & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc)  " _
                      & " AND right(f.fecha,2)>= '" & txtdi1.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "

                    ElseIf p = cbini.Text <> p = cbfin.Text Then
                        sql = sql & " UNION SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                       & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                       & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                       & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                       & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc)  " _
                       & "  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "
                    ElseIf p = cbfin.Text Then
                        sql = sql & " UNION SELECT  f.doc AS doc, df.nomart AS nomart, df.codart, CAST( f.fecha AS CHAR( 20 ) ) AS cta_inv  , df.cantidad AS item,  " _
                       & "((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor , ci.costuni AS costo, " _
                       & "(((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni) AS cantidad, " _
                       & "((((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) - ci.costuni)) * df.cantidad AS vtotal " _
                       & "FROM detafac" & p & " df, facturas" & p & " f , con_inv ci WHERE (f.doc = df.doc) " _
                       & " AND right(f.fecha,2)<= '" & txtdi2.Text & "'  AND (df.codart =ci.codart) AND ci.periodo='" & p & "' " & cd & "  "
                    End If
                End If
            Next

            sql = sql & " ) as c GROUP BY doc ORDER BY doc "
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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportInfoFacturas2.rpt")
            CrReport.SetDataSource(tabla)
            Try

                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4

            Catch ex As Exception

            End Try
            FrmReportFacArt2.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtitulo As New ParameterField
                Dim PrAJ As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtitulo.Name = "titulo"
                Prtitulo.CurrentValues.AddValue(tit.ToString)

                PrAJ.Name = "doc_aj"
                PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtitulo)
                prmdatos.Add(PrAJ)

                FrmReportFacArt2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacArt2.ShowDialog()

            Catch ex As Exception
            End Try

        End If

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus

    End Sub
End Class