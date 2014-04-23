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

Public Class FrmInfoClientes

    Private Sub FrmInfoClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If


        '' CARGAR CLIENTES
        '' AUTOCOMPLETAR NIT CLIENTE
        'Try
        '    txtnom.AutoCompleteCustomSource.Clear()

        '    Dim tb As New DataTable
        '    tb.Clear()
        '    myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    If tb.Rows.Count > 0 Then
        '        For i = 0 To tb.Rows.Count - 1
        '            txtnom.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        ValidarNIT(txttip, e)
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try
            If txttip.Text <> "" Then
                FrmSelCliente.lbform.Text = "fac_cliA"
                FrmSelCliente.ShowDialog()
            End If
        Catch ex As Exception

        End Try
        
    End Sub


    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmSelCliente.lbform.Text = "fac_cliA"
        FrmSelCliente.ShowDialog()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            chcli.Visible = True
            chcli.Checked = False
        Else
            txttip.Enabled = False
            chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'mostrar_pdf()

        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "VISUALIZAR INFORME POR CLIENTE ", "", "", "")
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
                c = " AND f.nitc = '" & txttip.Text & "' "
            End If

            If d1.Checked = True Then
                For i = Val(cbini.Text) To Val(cbfin.Text)

                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If cbini.Text = cbfin.Text Then
                        sql = " SELECT f.nitc,  CONCAT( t.nombre,' ', t.apellidos ) AS entregar, f.doc AS doc, " _
                        & " CAST( f.fecha AS CHAR( 20 ) ) AS usuario, f.doc_afec, " _
                        & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t  " _
                        & " WHERE  f.nitc = t.nit and ( f.doc = df.doc )  " & c & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' "
                    Else
                        If p = cbini.Text Then
                            sql = " SELECT f.nitc,  CONCAT( t.nombre,  ' ', t.apellidos )  AS entregar, f.doc AS doc, " _
                            & " CAST( f.fecha AS CHAR( 20 ) ) AS usuario, f.doc_afec, " _
                           & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f ,  terceros t  WHERE  f.nitc = t.nit and ( f.doc = df.doc )  " & c & " AND right(f.fecha,2) >= '" & txtdi1.Text & "' "
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION SELECT f.nitc,  CONCAT( t.nombre,  ' ', t.apellidos ) AS entregar, f.doc AS doc, " _
                            & " CAST( f.fecha AS CHAR( 20 ) ) AS usuario, f.doc_afec, " _
                           & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t  WHERE  f.nitc = t.nit and ( f.doc = df.doc )  " & c & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION SELECT f.nitc,  CONCAT( t.nombre,  ' ', t.apellidos ) AS entregar, f.doc AS doc, " _
                            & " CAST( f.fecha AS CHAR( 20 ) ) AS usuario, f.doc_afec, " _
                          & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t WHERE  f.nitc = t.nit and ( f.doc = df.doc )  " & c & " AND right(f.fecha,2) <= '" & txtdi2.Text & "' "
                        End If
                    End If
                Next

                sql = sql & " ORDER BY entregar "
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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFCli.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportFacCli.CrystalReportViewer1.ReportSource = CrReport

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

                    PrAJ.Name = "doc_aj"
                    PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrAJ)

                    FrmReportFacCli.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacCli.ShowDialog()
                Catch ex As Exception
                End Try

            Else

                sql = "SELECT c.nitc, c.entregar, sum(c.valor) as subtotal, sum(c.descuento) as descuento, sum(c.iva) as iva, sum(ret_f) as ret_f, sum(c.total) as total FROM ( "
                For i = Val(cbini.Text) To Val(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If cbini.Text = cbfin.Text Then
                        sql = sql & " SELECT f.nitc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS entregar,  " _
                            & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t  " _
                           & " WHERE   f.nitc = t.nit AND ( f.doc = df.doc ) " & c & " AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' AND left(df.doc,2)<> '" & doc_aj & "'"
                    Else
                        If p = cbini.Text Then
                            sql = sql & " SELECT f.nitc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS entregar,  " _
                             & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t  " _
                            & " WHERE ( f.doc = df.doc )  " & c & " AND right(f.fecha,2) >= '" & txtdi1.Text & "' AND left(df.doc,2)<> '" & doc_aj & "'"
                        ElseIf p <> cbini.Text And p <> cbfin.Text Then
                            sql = sql & " UNION SELECT f.nitc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS entregar,   " _
                             & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t  " _
                            & " WHERE ( f.doc = df.doc ) and  f.nitc = t.nit AND left(df.doc,2)<> '" & doc_aj & "'" & c & ""
                        ElseIf p = cbfin.Text Then
                            sql = sql & " UNION SELECT f.nitc, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS entregar,   " _
                             & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100) ) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS valor, " _
                       & " (( (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) AS descuento, " _
                       & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                       & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                        & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                       & " FROM  detafac" & p & " df, facturas" & p & " f ,terceros t  " _
                            & " WHERE    f.nitc = t.nit and ( f.doc = df.doc )  " & c & " AND right(f.fecha,2) <= '" & txtdi2.Text & "' AND left(df.doc,2)<> '" & doc_aj & "'"
                        End If
                    End If
                Next

                sql = sql & ") as c GROUP BY nitc ORDER BY entregar"
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

                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFCli2.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportFacCli2.CrystalReportViewer1.ReportSource = CrReport

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

                    PrAJ.Name = "doc_aj"
                    PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrAJ)

                    FrmReportFacCli2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportFacCli2.ShowDialog()

                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error al general el informe. " & ex.ToString)
        End Try

    End Sub

    Public Sub mostrar_pdf()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
        Dim i, k, pag, no, c As Integer
        Dim sumavalor, sumaiva, sumasub, sumavalor1, sumaiva1, sumasub1 As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, t1, t2, t3, tp, cad1, cad2, cad3, consulta, consulta2 As String
        pag = 1
        sumaiva = 0
        sumavalor = 0
        sumasub = 0
        c = 0
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
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME DE FACTURACION POR CLIENTES"
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
            cb.ShowTextAligned(50, " DOCTO ", 120, k, 0)
            cb.ShowTextAligned(50, "AFECTADO", 120, k - 8, 0)
            cb.ShowTextAligned(50, "SUBTOTAL", 230, k - 8, 0)
            cb.ShowTextAligned(50, " VALOR", 310, k, 0)
            cb.ShowTextAligned(50, "DESCUENTO", 300, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 380, k, 0)
            cb.ShowTextAligned(50, " IVA", 380, k - 8, 0)
            cb.ShowTextAligned(50, "  VALOR", 440, k, 0)
            cb.ShowTextAligned(50, "RETENCION", 440, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 520, k, 0)
            cb.ShowTextAligned(50, "TOTAL", 520, k - 8, 0)
            cad1 = " ORDER BY apellidos,nombre,tipodoc,num;"

        Else
            cb.ShowTextAligned(50, "CLIENTE", 20, k, 0)
            cb.ShowTextAligned(50, "SUBTOTAL", 230, k - 8, 0)
            cb.ShowTextAligned(50, "  VALOR", 310, k, 0)
            cb.ShowTextAligned(50, "DESCUENTO", 310, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 380, k, 0)
            cb.ShowTextAligned(50, " IVA", 380, k - 8, 0)
            cb.ShowTextAligned(50, "  VALOR", 434, k, 0)
            cb.ShowTextAligned(50, "RETENCION", 440, k - 8, 0)
            cb.ShowTextAligned(50, "VALOR", 520, k, 0)
            cb.ShowTextAligned(50, "TOTAL", 520, k - 8, 0)
            cad1 = " ORDER BY apellidos,nombre;"

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

        consulta = ""
        consulta2 = ""
        For i = CDbl(cbini.Text) To CDbl(cbfin.Text)
            t1 = bda & ".facturas" & adicionar(i)
            t2 = bda & ".detafac" & adicionar(i)
            t3 = bda


            cad3 = ""
            If consulta = "" Then
                'consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                If d1.Checked = True Then
                    consulta = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                    cad3 = ""
                Else
                    consulta = "SELECT " & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos, " & t1 & ".doc_afec,SUM(" & t1 & ".subtotal) as subtotal,SUM(" & t1 & ".descuento) as descuento,SUM(" & t1 & ".iva) as iva,SUM(" & t1 & ".ret_iva) as ret_iva,SUM(" & t1 & ".total) as total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                    cad3 = " GROUP BY terceros.apellidos,terceros.nombre "
                End If
                If c2.Checked = True Then
                    consulta = consulta & " AND " & t3 & ".terceros.nit='" & txttip.Text & "'"
                End If
                consulta = consulta & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
            Else
                If d1.Checked = True Then
                    consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                    cad3 = ""
                Else
                    consulta2 = "SELECT " & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".doc_afec,SUM(" & t1 & ".subtotal) as subtotal,SUM(" & t1 & ".descuento) as descuento,SUM(" & t1 & ".iva) as iva,SUM(" & t1 & ".ret_iva) as ret_iva,SUM(" & t1 & ".total) as total  FROM " & t3 & ".terceros inner join " & t1 & " on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                    cad3 = " GROUP BY terceros.apellidos,terceros.nombre "
                End If
                'consulta2 = "SELECT " & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t3 & ".terceros.nit," & t1 & ".subtotal," & t1 & ".descuento," & t1 & ".iva," & t1 & ".ret_iva," & t1 & ".total  FROM " & t3 & ".terceros inner join (" & t1 & " inner join " & t2 & " on " & t1 & ".doc=" & t2 & ".doc) on " & t1 & ".nitc=" & t3 & ".terceros.nit where 1 "
                If c2.Checked = True Then
                    consulta2 = consulta2 & " AND " & t3 & ".terceros.nit='" & txttip.Text & "'"
                End If
                consulta2 = consulta2 & " AND (DATE_FORMAT(" & t1 & ".fecha,'%Y-%m-%d') BETWEEN DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbini.Text & "-" & adicionar(txtdi1.Text) & "') AND DATE('" & extraer_cadena2(PerActual, 3, 7) & "-" & cbfin.Text & "-" & adicionar(txtdi2.Text) & "'))" & cad3
                consulta = consulta & " UNION " & consulta2
            End If

        Next

        cb.EndText()

        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()

        consulta = consulta & cad1
        myCommand.CommandText = consulta

        myAdapter.SelectCommand = myCommand
        tabla = New DataTable
        myAdapter.Fill(tabla)
        tp = ""
        For i = 0 To tabla.Rows.Count - 1
            If d1.Checked = True Then
                If tp <> tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString Then
                    If tp <> "" Then
                        cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub1), 270, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 410, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 550, k, 0)
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
                    cb.ShowTextAligned(50, Trim(tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString) & "           NIT: " & tabla.Rows(i).Item("nit").ToString, 20, k, 0)
                    k = k - 10
                End If
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()

                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & " " & NumeroDoc(CDbl(tabla.Rows(i).Item("num").ToString)), 20, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 60, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_afec").ToString, 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 270, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 350, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 410, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 470, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 550, k, 0)
                k = k - 10

                tp = tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString

                sumaiva = sumaiva + CDbl(tabla.Rows(i).Item("iva").ToString)
                sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
                sumaiva1 = sumaiva1 + CDbl(tabla.Rows(i).Item("iva").ToString)
                sumavalor1 = sumavalor1 + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub1 = sumasub1 + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
                'k = k - 8
            Else
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()

                cb.ShowTextAligned(50, tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString, 20, k, 0)
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("subtotal").ToString)), 270, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("descuento").ToString)), 350, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("iva").ToString)), 410, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("ret_iva").ToString)), 470, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("total").ToString)), 550, k, 0)
                k = k - 10
                sumaiva = sumaiva + CDbl(tabla.Rows(i).Item("iva").ToString)
                sumavalor = sumavalor + CDbl(CDbl(tabla.Rows(i).Item("total").ToString))
                sumasub = sumasub + CDbl(CDbl(tabla.Rows(i).Item("subtotal").ToString))
            End If
            If k <= 80 Then
                cb.EndText()
                oDoc.NewPage()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                Refresh()
                cb.BeginText()
                myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                cb.ShowTextAligned(50, tabla2.Rows(0).Item("descripcion"), 20, 810, 0)
                cb.ShowTextAligned(50, "N.I.T. " & tabla2.Rows(0).Item("nit"), 20, 800, 0)
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
                    cb.ShowTextAligned(50, " DOCTO ", 120, k, 0)
                    cb.ShowTextAligned(50, "AFECTADO", 120, k - 8, 0)
                    cb.ShowTextAligned(50, "SUBTOTAL", 230, k - 8, 0)
                    cb.ShowTextAligned(50, " VALOR", 310, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 300, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 380, k, 0)
                    cb.ShowTextAligned(50, " IVA", 380, k - 8, 0)
                    cb.ShowTextAligned(50, "  VALOR", 440, k, 0)
                    cb.ShowTextAligned(50, "RETENCION", 440, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 520, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 520, k - 8, 0)

                Else
                    cb.ShowTextAligned(50, "CLIENTE", 20, k, 0)
                    cb.ShowTextAligned(50, "SUBTOTAL", 230, k - 8, 0)
                    cb.ShowTextAligned(50, "  VALOR", 310, k, 0)
                    cb.ShowTextAligned(50, "DESCUENTO", 310, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 380, k, 0)
                    cb.ShowTextAligned(50, " IVA", 380, k - 8, 0)
                    cb.ShowTextAligned(50, "  VALOR", 434, k, 0)
                    cb.ShowTextAligned(50, "RETENCION", 440, k - 8, 0)
                    cb.ShowTextAligned(50, "VALOR", 520, k, 0)
                    cb.ShowTextAligned(50, "TOTAL", 520, k - 8, 0)

                End If
                k = k - 30
                pag = pag + 1
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
            End If

        Next
        If tabla.Rows.Count <> 0 And d1.Checked = True Then
            cb.ShowTextAligned(50, "SUBTOTAL " & CambiaCadena(Trim(tp), 40), 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub1), 270, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva1), 410, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor1), 550, k, 0)
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
        cb.ShowTextAligned(50, "TOTAL FACTURA DE VENTA", 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumasub), 270, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumaiva), 410, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 550, k, 0)
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

    
    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged

    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged

    End Sub

    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txttip.Enabled = False
            txtnom.Enabled = True
        Else
            txtnom.Enabled = False
            txttip.Enabled = True
        End If
    End Sub

    Private Sub txtnom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnom.LostFocus
        Try
            If txtnom.Text = "" Then
                txttip.Text = ""
                FrmSelCliente.lbform.Text = "fac_cliA"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtnom.Text)
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
            txttip.Text = ""
            FrmSelCliente.lbform.Text = "fac_cliA"
            FrmSelCliente.ShowDialog()
        Else
            txttip.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
    
End Class