﻿Imports iTextSharp.text
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

Public Class FrmInfoReferencia

    Public ct As Integer

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_pdf()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR REFERENCIA ", "", "", "")
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
        Dim tb As New DataTable
        tb = New DataTable
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        doc_aj = tb.Rows(0).Item(0)

        Dim c As String = ""
        If c2.Checked = True Then
            c = " AND a.codart BETWEEN ('" & txtdocini.Text & "') AND ('" & txtdocfin.Text & "')"
        End If

        If d1.Checked = True Then
            For i = Val(cbini.Text) To Val(cbfin.Text)

                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If cbini.Text = cbfin.Text Then
                    sql = " SELECT f.doc AS doc, df.nomart AS nomart, df.codart ,a.referencia AS cta_ing,( TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS cta_cos , " _
                        & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cta_inv, " _
                        & " df.cantidad AS item," _
                        & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f , terceros t " _
                          & " WHERE f.nitc = t.nit AND  a.codart = df.codart " & c & " AND (f.doc = df.doc)  AND df.tipo_it = 'I' AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' and  '" & txtdi2.Text & "' "
                Else
                    If p = cbini.Text Then
                        sql = " SELECT f.doc AS doc, df.nomart AS nomart, df.codart ,a.referencia AS cta_ing,( TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS cta_cos , " _
                         & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cta_inv, " _
                        & " df.cantidad AS item," _
                        & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f , terceros t " _
                          & " WHERE  f.nitc = t.nit AND  a.codart = df.codart " & c & " AND (f.doc = df.doc)  AND df.tipo_it = 'I' AND right(f.fecha,2)>= '" & txtdi1.Text & "' "
                    ElseIf p <> cbini.Text And p <> cbfin.Text Then
                        sql = sql & " UNION  SELECT f.doc AS doc, df.nomart AS nomart, df.codart ,a.referencia AS cta_ing,( TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS cta_cos , " _
                         & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cta_inv, " _
                         & " df.cantidad AS item," _
                         & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f, terceros t " _
                          & " WHERE  f.nitc = t.nit AND  a.codart = df.codart " & c & " AND (f.doc = df.doc)  AND df.tipo_it = 'I' "
                    ElseIf p = cbfin.Text Then
                        sql = sql & " UNION  SELECT f.doc AS doc, df.nomart AS nomart, df.codart ,a.referencia AS cta_ing,( TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS cta_cos , " _
                         & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cta_inv, " _
                         & " df.cantidad AS item," _
                         & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f , terceros t " _
                          & " WHERE  f.nitc = t.nit AND  a.codart = df.codart " & c & " AND (f.doc = df.doc)  AND df.tipo_it = 'I' AND right(f.fecha,2)<= '" & txtdi2.Text & "'"
                    End If
                End If
            Next

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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFRef.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportFacRef.CrystalReportViewer1.ReportSource = CrReport

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

                PrAJ.Name = "doc_aj"
                PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(PrAJ)

                FrmReportFacRef.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacRef.ShowDialog()

            Catch ex As Exception
            End Try
        Else

            sql = " select c.nomart, c.codart, c.cta_ing, c.cta_cos, sum(c.item) as item, sum(c.valor) as valor, sum(c.cantidad) as cantidad, " _
            & " sum(c.costo) as costo, sum(c.vtotal) as vtotal from ( "

            For i = Val(cbini.Text) To Val(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If cbini.Text = cbfin.Text Then
                    sql = sql & " SELECT f.doc , df.nomart AS nomart, df.codart, a.referencia as cta_ing, " _
                      & " ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS cta_cos,  " _
                      & " df.cantidad AS item," _
                      & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f LEFT JOIN terceros t " _
                      & " ON  f.nitc = t.nit WHERE  a.codart = df.codart " & c & "  AND left(df.doc,2)<> '" & doc_aj & "' AND (f.doc = df.doc)  AND df.tipo_it = 'I' AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' and  '" & txtdi2.Text & "'"
                Else
                    If p = cbini.Text Then
                        sql = sql & " SELECT f.doc, df.nomart AS nomart, df.codart, a.referencia as cta_ing, " _
                       & " ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS cta_cos,  " _
                       & " df.cantidad AS item," _
                       & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f LEFT JOIN terceros t " _
                      & " ON  f.nitc = t.nit WHERE  a.codart = df.codart " & c & "  AND left(df.doc,2)<> '" & doc_aj & "' AND ( f.doc = df.doc ) AND f.nitc = t.nit AND df.tipo_it =  'I' AND right(f.fecha,2)>= '" & txtdi1.Text & "'"
                    ElseIf p <> cbini.Text And p <> cbfin.Text Then
                        sql = sql & " UNION SELECT f.doc AS doc, df.nomart AS nomart, df.codart, a.referencia as cta_ing,  " _
                      & " ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS cta_cos,  " _
                      & " df.cantidad AS item," _
                      & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f LEFT JOIN terceros t " _
                      & " ON  f.nitc = t.nit WHERE  a.codart = df.codart " & c & "  AND left(df.doc,2)<> '" & doc_aj & "' AND ( f.doc = df.doc ) AND f.nitc = t.nit AND df.tipo_it =  'I' "
                        ElseIf p = cbfin.Text Then
                        sql = sql & " UNION SELECT f.doc AS doc, df.nomart AS nomart, df.codart, a.referencia as cta_ing,  " _
                      & " ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS cta_cos,  " _
                      & " df.cantidad AS item," _
                     & " ((df.valor-(df.valor*(df.por_des/100))) - (( ((df.valor-(df.valor*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.valor-(df.valor*(df.por_des/100)))-((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.valor-(df.valor*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) As valor , " _
                         & "(( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS cantidad, " _
                         & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) AS costo, " _
                         & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS vtotal " _
                         & " FROM  detafac" & p & " df, articulos a, facturas" & p & " f LEFT JOIN terceros t " _
                      & " ON  f.nitc = t.nit WHERE  a.codart = df.codart " & c & "  AND left(df.doc,2)<> '" & doc_aj & "' AND ( f.doc = df.doc ) AND f.nitc = t.nit AND df.tipo_it =  'I' AND right(f.fecha,2)<= '" & txtdi2.Text & "' "
                    End If
                End If
            Next

            sql = sql & ") as c GROUP BY cta_ing ORDER BY cta_ing"
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

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFRef2.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportFacRef2.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtitulo As New ParameterField

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

                FrmReportFacRef2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacRef2.ShowDialog()

            Catch ex As Exception
            End Try

        End If


    End Sub

    Private Sub FrmInfoReferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As DataTable
        Dim niv As Integer
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)

        myCommand.CommandText = "select * from parinven"

        myAdapter.SelectCommand = myCommand
        tabla = New DataTable
        myAdapter.Fill(tabla)
        niv = 0
        If tabla.Rows.Count = 0 Then
            MsgBox("No existen parametros de Inventario")
            Me.Close()
            Exit Sub
        End If

        niv = CDbl(tabla.Rows(0).Item("nivel1").ToString) + CDbl(tabla.Rows(0).Item("nivel2").ToString) + CDbl(tabla.Rows(0).Item("nivel3").ToString) + CDbl(tabla.Rows(0).Item("nivel4").ToString) + CDbl(tabla.Rows(0).Item("nivel5").ToString) + CDbl(tabla.Rows(0).Item("nivel6").ToString)
        txtdocfin.MaxLength = niv
        txtdocini.MaxLength = niv
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub

    Public Sub mostrar_pdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim i, k, pag, no, c, par As Integer
        Dim sumavalor, sumaiva, sumasub, sumavalor1, sumaiva1, sumasub1, iva As Double
        Dim tabla, tabla1, tabla2, tabla3 As New DataTable
        Dim cadena, t1, t2, t3, tp, cad1, cad2, cad3, consulta, consulta2 As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        c = 0
        iva = 0
        cad2 = ""
        cad3 = ""
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        Refresh()
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME DE FACTURACION POR REFERENCIA"
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
        k = 700
        no = 0
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        If d1.Checked = True Then
            cb.ShowTextAligned(50, "Nro", 20, k, 0)
            cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
            cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
            cb.ShowTextAligned(50, "CLIENTE", 120, k - 8, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 300, k, 0)
            cb.ShowTextAligned(50, "UNITARIO", 300, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 370, k, 0)
            cb.ShowTextAligned(50, "DESCUENTO", 370, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 450, k, 0)
            cb.ShowTextAligned(50, "IVA", 450, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 530, k, 0)
            cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
            cad1 = " ORDER BY codart,nomart,tipodoc,num"

        Else
            cb.ShowTextAligned(50, "PRODUCTO", 20, k, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
            cb.ShowTextAligned(50, " VALOR", 330, k, 0)
            cb.ShowTextAligned(50, "DESCUENTO", 330, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 450, k, 0)
            cb.ShowTextAligned(50, " IVA", 450, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 530, k, 0)
            cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)
            cad1 = " ORDER BY codart,nomart"

        End If

        k = k - 30
        t1 = ""
        t2 = ""

        If CDbl(cbini.Text) > CDbl(cbfin.Text) Then
            MsgBox("La fecha inicial no debe ser mayor que la final")
            Exit Sub
        End If

        'If cdbl(cbfin.Text) > CambiaCadena(PerActual, 2) Then
        'MsgBox("Periodo no esta en uso")
        'Exit Sub
        'End If
        myCommand.CommandText = "SELECT " & bda & ".parafacgral.ivainclu FROM " & bda & ".parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count > 0 Then
            If tabla2.Rows(0).Item(0) = "SI" Then
                par = 1
            Else
                par = 0
            End If
        End If
        consulta = ""
        consulta2 = ""
        For i = CDbl(cbini.Text) To CDbl(cbfin.Text)
            t1 = bda & ".facturas" & adicionar(i)
            t2 = bda & ".detafac" & adicionar(i)
            t3 = bda


            cad3 = ""
            If consulta = "" Then

                If d1.Checked = True Then
                    consulta = "SELECT " & t2 & ".codart," & t2 & ".nomart," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t2 & ".cantidad," & t2 & ".valor as subtotal," & t1 & ".descuento," & t1 & ".iva," & t2 & ".vtotal as total," & t2 & ".iva_d," & t2 & ".valor  FROM " & t3 & ".terceros INNER JOIN (" & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc) ON " & t1 & ".nitc=" & t3 & ".terceros.nit where " & t1 & ".doc_de='I' "
                    cad3 = ""
                Else
                    consulta = "SELECT " & t2 & ".codart," & t2 & ".nomart," & "SUM(" & t2 & ".cantidad) as cantidad,SUM(" & t1 & ".descuento) as descuento,SUM(" & t1 & ".iva) as iva,SUM(" & t2 & ".vtotal) as total," & t2 & ".iva_d," & t2 & ".valor FROM " & t3 & ".terceros INNER JOIN (" & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc) ON " & t1 & ".nitc=" & t3 & ".terceros.nit where " & t1 & ".doc_de='I' "
                    cad3 = " GROUP BY codart,nomart "
                End If
                If c2.Checked = True Then
                    consulta = consulta & " AND (codart >= '" & txtdocini.Text & "' AND codart <= '" & txtdocfin.Text & "')"
                End If
                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
            Else
                If d1.Checked = True Then
                    consulta2 = "SELECT " & t2 & ".codart," & t2 & ".nomart," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t2 & ".cantidad," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".total," & t2 & ".iva_d," & t2 & ".valor  FROM " & t3 & ".terceros INNER JOIN (" & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc) ON " & t1 & ".nitc=" & t3 & ".terceros.nit where " & t1 & ".doc_de='I' "
                    cad3 = ""
                Else
                    consulta2 = "SELECT " & t2 & ".codart," & t2 & ".nomart," & "SUM(" & t2 & ".cantidad) as cantidad,SUM(" & t1 & ".descuento) as descuento,SUM(" & t1 & ".iva) as iva,SUM(" & t1 & ".total) as total," & t2 & ".iva_d," & t2 & ".valor  FROM " & t3 & ".terceros INNER JOIN (" & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc) ON " & t1 & ".nitc=" & t3 & ".terceros.nit where " & t1 & ".doc_de='I' "
                    cad3 = " GROUP BY codart,nomart "
                End If
                'consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                If c2.Checked = True Then
                    consulta2 = consulta & " AND (" & t2 & ".codart >= '" & txtdocini.Text & "' AND " & t2 & ".codart <= '" & txtdocfin.Text & "')"
                End If
                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
                consulta = consulta & cad1 & " UNION " & consulta2
            End If

        Next

        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        consulta = consulta & cad1 & ";"
        myCommand.CommandText = consulta
        tabla.Clear()
        myAdapter.SelectCommand = myCommand
        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        For i = 0 To tabla.Rows.Count - 1
            If d1.Checked = True Then
                If tp <> tabla.Rows(i).Item("nomart").ToString Then
                    If tp <> "" Then
                        cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub1), 330, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 480, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 560, k, 0)
                        sumaiva1 = 0
                        sumavalor1 = 0
                        sumasub1 = 0
                        k = k - 10

                    End If

                    cb.EndText()
                    k = k - 5
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)

                    cb.BeginText()
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("nomart").ToString & "           CODIGO: " & tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                    k = k - 10
                End If
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cad3 = Trim(tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString)
                If Len(cad3) > 21 Then
                    cad3 = CambiaCadena(cad3, 21)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & " " & NumeroDoc(CDbl(tabla.Rows(i).Item("num").ToString)), 20, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 60, k, 0)
                cb.ShowTextAligned(50, cad3, 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 250, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 330, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 410, k, 0)

                If par = 1 Then
                    iva = CDbl(tabla.Rows(i).Item("valor").ToString) - (CDbl(tabla.Rows(i).Item("valor").ToString) / (1 + (CDbl(tabla.Rows(i).Item("iva_d").ToString) / 100)))
                Else
                    iva = CDbl(tabla.Rows(i).Item("valor").ToString) * CDbl(tabla.Rows(i).Item("iva_d").ToString)
                End If
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(tabla.Rows(i).Item("iva").ToString)), 480, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(iva)), 480, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 560, k, 0)
                k = k - 10

                tp = tabla.Rows(i).Item("nomart").ToString

                sumaiva = sumaiva + CDbl(CDbl(iva) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
                sumaiva1 = sumaiva1 + CDbl(CDbl(iva) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                sumavalor1 = sumavalor1 + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub1 = sumasub1 + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
                'k = k - 8
            Else
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()

                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString & "  " & tabla.Rows(i).Item("nomart").ToString, 20, k, 0)
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, CDbl(tabla.Rows(i).Item("cantidad").ToString), 240, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 380, k, 0)
                tabla2.Clear()
                myCommand.CommandText = "SELECT * FROM " & bda & ".parafacgral WHERE " & bda & ".parafacgral.ivainclu='SI';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                If par = 1 Then
                    iva = CDbl(tabla.Rows(i).Item("valor").ToString) - (CDbl(tabla.Rows(i).Item("valor").ToString) / (1 + (CDbl(tabla.Rows(i).Item("iva_d").ToString) / 100)))
                Else
                    iva = CDbl(tabla.Rows(i).Item("valor").ToString) * CDbl(tabla.Rows(i).Item("iva_d").ToString)
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(CDbl(iva) * CDbl(tabla.Rows(i).Item("cantidad").ToString))), 480, k, 0)
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(cdbl(tabla.Rows(i).Item("iva").ToString)), 480, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 560, k, 0)
                k = k - 10
                sumaiva = sumaiva + CDbl((CDbl(iva) * CDbl(tabla.Rows(i).Item("cantidad").ToString)))
                sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("descuento").ToString))
            End If
            If k <= 80 Then
                cb.EndText()
                oDoc.NewPage()
                k = 730
                pag = pag + 1
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                Refresh()
                cb.BeginText()
                myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla3)
                cb.ShowTextAligned(50, tabla3.Rows(0).Item("descripcion"), 20, 810, 0)
                cb.ShowTextAligned(50, "N.I.T. " & tabla3.Rows(0).Item("nit"), 20, 800, 0)
                cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
                k = 700
                If d1.Checked = True Then
                    cb.ShowTextAligned(50, "Nro", 20, k, 0)
                    cb.ShowTextAligned(50, "DOCTO", 20, k - 8, 0)
                    cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
                    cb.ShowTextAligned(50, "CLIENTE", 120, k - 8, 0)
                    cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 300, k, 0)
                    cb.ShowTextAligned(50, "UNITARIO", 300, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 370, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 370, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 450, k, 0)
                    cb.ShowTextAligned(50, "IVA", 450, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)

                Else
                    cb.ShowTextAligned(50, "PRODUCTO", 20, k, 0)
                    cb.ShowTextAligned(50, "CANTIDAD", 220, k - 8, 0)
                    cb.ShowTextAligned(50, " VALOR", 330, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 330, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 450, k, 0)
                    cb.ShowTextAligned(50, " IVA", 450, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 530, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 530, k - 8, 0)

                End If
                k = k - 30
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If

        Next
        If tabla.Rows.Count <> 0 And d1.Checked = True Then
            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub1), 330, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 480, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 560, k, 0)
            sumaiva1 = 0
            sumavalor1 = 0
            sumasub1 = 0
            k = k - 10
        End If


        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)

        cb.BeginText()
        cb.ShowTextAligned(50, "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        If d1.Checked = True Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 330, k, 0)
        Else
            If d2.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 380, k, 0)
            End If
        End If
        cb.ShowTextAligned(50, "TOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), 480, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 560, k, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()

        Try
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
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

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtdocfin.Enabled = False
            txtdocini.Enabled = False
            txtdocini.ReadOnly = True
            txtdocfin.ReadOnly = True
        Else
            
            txtdocfin.Enabled = True
            txtdocini.Enabled = True
            txtdocini.ReadOnly = False
            txtdocfin.ReadOnly = False
        End If
    End Sub

    Private Sub txtdocini_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdocini.DoubleClick
        ct = 1
        FrmLisRef.ShowDialog()
    End Sub

    Private Sub txtdocfin_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdocfin.DoubleClick
        ct = 2
        FrmLisRef.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
End Class