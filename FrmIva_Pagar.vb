Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object

Public Class FrmIva_Pagar

    Private Sub ivaPagar()


        Dim sql As String = ""
        Dim tituloG As String = ""
        Dim nom As String = ""
        Dim nitp As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim pi As String = ""
        Dim cadC As String = ""
        Dim ini As Integer = 0
        Dim fin As Integer = 0

        ini = cbini.Text
        fin = cbfin.Text
        tituloG = "INFORME I.V.A RECAUDADO (POR PAGAR)"

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nitp = "NIT: " & tabla2.Rows(0).Item("nit")
        per = "PERIODO: " & cbini.Text & txtpini.Text & " - " & cbfin.Text & txtperf.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tablaT As New DataTable
        tablaT = New DataTable
        myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5 FROM tributarios WHERE num = '1' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaT)
        If tablaT.Rows.Count > 0 Then
            For i = 0 To 4
                If tablaT.Rows(0).Item(i) <> "" Then
                    cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                End If
            Next
        End If
        cadC = Strings.Left(cadC, cadC.Length - 2)

        '---------- saldos iniciales
        Dim salT As String = ""
        For j = 1 To ini
            If j < 10 Then
                pi = "0" & j - 1
            Else
                If j = 10 Then
                    pi = "0" & j - 1
                Else
                    pi = j - 1
                End If
            End If
            If j <> ini Then
                salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & "   WHERE codigo IN (" & cadC & ") group by codigo UNION "
            Else
                salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & "  WHERE codigo IN (" & cadC & ") group by codigo "
            End If
        Next

        ' ....... fin saldos iniciales
        If ini < 10 Then
            pi = "0" & ini - 1
        Else
            If ini = 10 Then
                pi = "0" & ini - 1
            Else
                pi = ini - 1
            End If
        End If

        For i = ini To fin
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> fin Then
                sql = sql & " SELECT  d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, trim( concat(t.nombre,' ', t.apellidos)) as nomnit,  trim(concat( t.telefono,' ', t.celular)) as ctaret, " _
                & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20) ) as doc, " _
                & " d.descri as concepto, d.base as descto, d.debito as tasa, d.credito as total  " _
                & " FROM  selpuc s , documentos" & p & " d LEFT JOIN  terceros t ON (d.nit = t.nit) " _
                & " WHERE  s.codigo = d.codigo  AND s.codigo IN (" & cadC & ") UNION "
            Else
                sql = sql & " SELECT  d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, trim( concat(t.nombre,' ', t.apellidos)) as nomnit,  trim(concat( t.telefono,' ', t.celular)) as ctaret, " _
                & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal, " _
                & " concat(d.dia,'/',d.periodo) as ccosto, CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20)) as doc, " _
                & " d.descri as concepto,d.base as descto,  d.debito as tasa , d.credito as total " _
                & " FROM  selpuc s , documentos" & p & " d LEFT JOIN  terceros t ON (d.nit = t.nit) " _
                & " WHERE  s.codigo = d.codigo   AND s.codigo IN (" & cadC & ")    "
            End If
        Next
        sql = sql & " ORDER BY nitcod, nomnit, fecha ASC "

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
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTributario.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim PrtituloG As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitp.ToString)
            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            PrtituloG.Name = "tituloG"
            PrtituloG.CurrentValues.AddValue(tituloG.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(PrtituloG)

            FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportTributario.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Select Case Trep.Text
            Case "1"
                ivaPagar()
        End Select


    End Sub

    Private Sub FrmIva_Pagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbini.Text = PerActual(0) & PerActual(1)
        txtpini.Text = PerActual(2).ToString & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString
        txtperf.Text = PerActual(2).ToString & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

    End Sub

    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        cbfin.Items.Clear()
        Dim j As Integer = Val(cbini.Text)
        For i = j To 12
            If i < 10 Then
                cbfin.Items.Add("0" & i)
            Else
                cbfin.Items.Add(i)
            End If
        Next
        cbfin.Text = cbini.Text
    End Sub
End Class