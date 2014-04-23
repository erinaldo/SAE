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
Public Class FrmUtilidadDiaria

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmUtilidadDiaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If fecha1.Value > fecha2.Value Then
            MsgBox("Verifique el rango de fechas", MsgBoxStyle.Information, "Verificacion")
            fecha1.Focus()
            Exit Sub
        End If
        If c1.Checked = False And c2.Checked = False And c3.Checked = False Then
            MsgBox("Seleccione al menos un grupo de cuentas", MsgBoxStyle.Information, "Verificacion")
            c1.Focus()
            Exit Sub
        End If
        pdf()
    End Sub

    Private Sub pdf()

        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim sql2 As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cad As String = ""
        Dim cad1 As String = ""
        Dim cad2 As String = ""
        Dim cad3 As String = ""


        MiConexion(bda)
        Cerrar()

        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & "/" & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & "/" & Strings.Right(fecha2.Text, 4)


        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")

        Dim n As Integer = 0
        If c1.Checked = True Then
            cad1 = cad1 & "AND  (d.codigo LIKE '4%'"
            n = n + 1
        End If
        If c2.Checked = True Then
            If n = 1 Then
                cad2 = cad2 & " OR d.codigo LIKE '5%'"
                n = n + 1
            ElseIf n = 0 Then
                cad2 = cad2 & " AND (d.codigo LIKE '5%'"
                n = n + 1
            End If
        End If
        If c3.Checked = True Then
            If n = 1 Then
                cad3 = cad3 & " OR d.codigo LIKE '6%'"
                n = n + 1
            ElseIf n = 2 Then
                cad3 = cad3 & " OR d.codigo LIKE '6%'"
                n = n + 1
            ElseIf n = 0 Then
                cad3 = cad3 & " AND (d.codigo LIKE '6%'"
                n = n + 1
            End If
        End If
        cad = cad & cad1 & cad2 & cad3 & ")"


        Dim m1 As String = ""
        Dim m2 As String = ""
        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If m1 = m2 Then
                sql = sql & "SELECT d.item, d.codigo, (d.debito- d.credito) AS sald FROM  documentos" & p & " d " _
                & " WHERE d.codigo <> '' AND CAST(d.dia AS SIGNED) BETWEEN '" & Val(Strings.Left(fecha1.Text, 2)) & "' AND  '" & Val(Strings.Left(fecha2.Text, 2)) & "' " & cad
            Else
                If p = m1 Then
                    sql = sql & "SELECT d.item, d.codigo, (d.debito- d.credito) AS sald FROM  documentos" & p & " d " _
               & " WHERE d.codigo <> '' AND CAST(d.dia AS SIGNED) >='" & CInt(Strings.Left(fecha1.Text, 2)) & "' " & cad
                ElseIf p <> m1 And p <> m2 Then
                    sql = sql & " UNION SELECT d.item, d.codigo, (d.debito- d.credito) AS sald FROM  documentos" & p & " d " _
              & " WHERE d.codigo <> '' " & cad
                ElseIf p = m2 Then
                    sql = sql & " UNION SELECT d.item, d.codigo, (d.debito- d.credito) AS sald FROM  documentos" & p & " d " _
              & " WHERE d.codigo <> '' AND CAST(d.dia AS SIGNED) <='" & CInt(Strings.Left(fecha2.Text, 2)) & "'" & cad
                End If
            End If
        Next
        sql1 = " SELECT LEFT(c.codigo,1) AS nitc ,(SELECT descripcion FROM selpuc WHERE codigo= LEFT(c.codigo,1)) AS descrip, LEFT(c.codigo,4) AS doc  ,(SELECT descripcion FROM selpuc WHERE codigo= LEFT(c.codigo,4)) AS nomnit, " _
        & " c.codigo AS ctaret, s.descripcion AS concepto, SUM(sald)  AS total  FROM ( "
        sql1 = sql1 & sql & "  ) AS c, selpuc s WHERE c.codigo = s.codigo GROUP BY ctaret ORDER BY ctaret  "


        '... TOTAL ........
        Dim ting As Double = 0
        Dim tgas As Double = 0
        Dim tcos As Double = 0
        sql2 = " SELECT LEFT(c.codigo,1) AS nitc ,(SELECT descripcion FROM selpuc WHERE codigo= LEFT(c.codigo,1)) AS descrip,  SUM(sald)  AS total  FROM ("
        sql2 = sql2 & sql & " )  AS c, selpuc s WHERE c.codigo = s.codigo GROUP BY LEFT(c.codigo,1) ORDER BY nitc  "
        Dim tt As New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tt)
        If tt.Rows.Count > 0 Then
            For i = 0 To tt.Rows.Count - 1
                If tt.Rows(i).Item("nitc") = "4" Then
                    ting = Moneda(tt.Rows(i).Item("total"))
                ElseIf tt.Rows(i).Item("nitc") = "5" Then
                    tgas = Moneda(tt.Rows(i).Item("total"))
                ElseIf tt.Rows(i).Item("nitc") = "6" Then
                    tcos = Moneda(tt.Rows(i).Item("total"))
                End If
            Next
        End If

        Dim tabla As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql1
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportUtilDiaria.rpt")
        CrReport.SetDataSource(tabla)
        ' CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtipo As New ParameterField
            Dim Prtt As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrtituloG As New ParameterField
            Dim Prcf As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtipo.Name = "ing"
            Prtipo.CurrentValues.AddValue(ting.ToString)

            Prtt.Name = "gas"
            Prtt.CurrentValues.AddValue(tgas.ToString)

            Prtitulo.Name = "cos"
            Prtitulo.CurrentValues.AddValue(tcos.ToString)

            'PrtituloG.Name = "tituloG"
            'PrtituloG.CurrentValues.AddValue(tituloG.ToString)

            'Prcf.Name = "Cue_Fec"
            'Prcf.CurrentValues.AddValue(c_f.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtipo)
            prmdatos.Add(Prtt)
            prmdatos.Add(Prtitulo)
            'prmdatos.Add(PrtituloG)
            'prmdatos.Add(Prcf)

            FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCMov_cue.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
End Class