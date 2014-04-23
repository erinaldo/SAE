
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
Public Class FrmInfMovContables

    Private Sub FrmInfMovContables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
    End Sub
    Private Sub txtcuenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.DoubleClick
        Try
            FrmCuentas.lbaux.Text = "todas"
            FrmCuentas.lbform.Text = "infmovc"
            FrmCuentas.txtcuenta.Text = txtcuenta.Text
            txtcuenta.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Function buscarcuenta(ByVal cuenta As String)
        Try

            MiConexion(bda)
            Dim tb2 As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select  codigo  from selpuc where codigo='" & cuenta & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb2)

            If tb2.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
            Cerrar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Try
            If buscarcuenta(txtcuenta.Text) = False Then
                txtcuenta_DoubleClick(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        If c3.Checked = True Then
            txtcuenta.Enabled = True
        Else
            txtcuenta.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MiConexion(bda)
        Cerrar()

        Dim nom As String = ""
        Dim nit As String = ""
        Dim per As String = ""
        Dim sql As String = ""
        Dim p As String = ""

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")

        If cbini.Text = cbfin.Text Then
            per = "PERIODO: " & cbini.Text & txtpini.Text
        Else
            per = "PERIODO: " & cbini.Text & txtpini.Text & " AL " & cbfin.Text & txtpfin.Text
        End If

        MiConexion(bda)


        Dim len1 As Integer = 0
        Dim niveles As String = ""

        If nc.Value = 2 Then
            niveles = niveles & "'Grupo'"
            len1 = 2
        ElseIf nc.Value = 3 Then
            niveles = niveles & "'Cuenta'"
            len1 = 4
        ElseIf nc.Value = 4 Then
            niveles = niveles & "'Sub Cuenta'"
            len1 = 6
        ElseIf nc.Value = 5 Then
            niveles = niveles & "'Auxiliar'"
            len1 = 9
        End If

        Dim cu1 As String = ""
        Dim cu2 As String = ""
        If c3.Checked = True And txtcuenta.Text <> "" Then
            cu1 = "  AND d.codigo LIKE '" & txtcuenta.Text & "%' "
            cu2 = "  AND codigo LIKE '" & txtcuenta.Text & "%' "
        End If


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        Dim cad As String = ""
        If chAux.Checked = True Then
            cad = " s.descripcion "
        Else
            cad = "''"
        End If
        Dim sql2 As String = ""


        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> cbfin.Text Then
                sql = sql & " SELECT d.tipodoc, CONCAT(d.tipodoc,' ', t.descripcion) as nomnit,s.nivel AS pagare, d.codigo as nitc," & cad & " AS concepto, SUM(d.debito) AS subtotal, SUM(d.credito) AS ret, LEFT(d.codigo," & len1 & ") AS ctaret, LEFT(d.codigo,9) AS ctaiva  " _
                & " FROM documentos" & p & " d, selpuc s, tipdoc t WHERE d.codigo=s.codigo AND t.tipodoc= d.tipodoc " & cu1 & " GROUP BY nitc,tipodoc UNION "
            Else
                sql = sql & " SELECT d.tipodoc, CONCAT(d.tipodoc,' ', t.descripcion) as nomnit,s.nivel AS pagare, d.codigo as nitc," & cad & " AS concepto, SUM(d.debito) AS subtotal, SUM(d.credito) AS ret, LEFT(d.codigo," & len1 & ") AS ctaret, LEFT(d.codigo,9) AS ctaiva  " _
               & " FROM documentos" & p & " d, selpuc s, tipdoc t WHERE d.codigo=s.codigo AND t.tipodoc= d.tipodoc " & cu1 & " GROUP BY nitc,tipodoc "
            End If
        Next

        sql2 = " SELECT DISTINCT LEFT(nitc," & len1 & ") FROM ( " & sql & " ) AS c  "
        Dim ta As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Dim cd As String = ""
        If ta.Rows.Count > 0 Then
            For j = 0 To ta.Rows.Count - 1
                If j <> ta.Rows.Count - 1 Then
                    cd = cd & "'" & ta.Rows(j).Item(0) & "' ,"
                Else
                    cd = cd & "'" & ta.Rows(j).Item(0) & "'"
                End If
            Next
        End If


        sql = " SELECT tipodoc, nomnit, pagare,nitc, concepto, sum(subtotal) as subtotal,sum(ret) as ret,ctaret," _
        & " ctaiva FROM ( " & sql & " ) AS c GROUP BY nitc,tipodoc  "

        '.................................................. RESUMIDO CON AUXILIAR
        If rbR.Checked = True And chAux.Checked = True Then
            sql = "SELECT LEFT(nitc,9) AS nitc, concepto, SUM(subtotal) AS subtotal, SUM(ret) AS ret, LEFT(nitc," & len1 & ") AS ctaret " _
            & " FROM (" & sql & " ) AS d GROUP BY LEFT(nitc,9)"
            sql = sql & "  UNION SELECT  codigo as nitc, descripcion as concepto, 0 AS subtotal, 0 AS ret, LEFT(codigo," & len1 & ") AS ctaret " _
            & " FROM selpuc WHERE nivel IN (" & niveles & ") " & cu2 & " AND codigo IN (" & cd & ")  " _
            & " ORDER BY  nitc "

            TextBox1.Text = sql

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMovContablResA.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport
        End If


        '........................... DETALLADO
        If rbD.Checked = True Then
            sql = sql & "  UNION SELECT '' AS tipodoc, '' as nomnit,nivel as pagare,  codigo as nitc, descripcion as concepto, 0 AS subtotal, 0 AS ret, LEFT(codigo," & len1 & ") AS ctaret, LEFT(codigo,9) AS ctaiva " _
        & " FROM selpuc WHERE nivel IN (" & niveles & ") " & cu2 & " AND codigo IN (" & cd & ")  " _
        & " ORDER BY  nitc, tipodoc"

            TextBox1.Text = sql

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMovContabl.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport
        End If


        '.................................................... RESUMIDO SIN AUXILIAR
        If rbR.Checked = True And chAux.Checked = False Then
            sql = "SELECT LEFT(nitc," & len1 & ") AS nitc,  concepto, SUM(subtotal) as subtotal, SUM(ret) as ret FROM( " & sql & " " _
            & "  UNION SELECT '' AS tipodoc, '' as nomnit,nivel as pagare,  codigo as nitc, descripcion as concepto, 0 AS subtotal, 0 AS ret, LEFT(codigo," & len1 & ") AS ctaret, LEFT(codigo,9) AS ctaiva " _
            & " FROM selpuc WHERE nivel IN (" & niveles & ") " & cu2 & " AND codigo IN (" & cd & ")  " _
            & " ORDER BY  nitc, tipodoc" _
            & " ) AS d GROUP BY LEFT(nitc," & len1 & ")"

            TextBox1.Text = sql

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMovContablRes.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport
        End If


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

            Prperiodo.Name = "per"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)

            FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCMov_cue.ShowDialog()
        Catch ex As Exception
        End Try
        conexion.Close()

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class