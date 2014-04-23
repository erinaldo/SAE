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
Public Class FrmInforAudMov

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
        Else
            txttip.Enabled = False
        End If
    End Sub
    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try


            If txttip.Text <> "" Then

                Dim tabla As New DataTable
                tabla.Clear()
                Dim items As Integer
                myCommand.CommandText = "SELECT trim(concat(nombres,' ',apellidos)) as nom, login, rol FROM sae.usuarios WHERE login = '" & txttip.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    txttip.Text = ""
                    FrmSelUsuario.lbform.Text = "infAudMov"
                    FrmSelUsuario.ShowDialog()
                Else
                    txttip.Text = tabla.Rows(0).Item("login")
                    txtnom.Text = tabla.Rows(0).Item("nom")
                End If
            Else
                FrmSelUsuario.lbform.Text = "infAudMov"
                FrmSelUsuario.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub f2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f2.CheckedChanged
        If f2.Checked = True Then
            txtform.Enabled = True
        Else
            txtform.Enabled = False
        End If
    End Sub

    Private Sub FrmInforAudMov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '*********************
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub
    Private Sub verPDF()
        Dim sql As String = ""
        Dim per As String = ""
        Dim cad As String = ""
        Dim sql2 As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim p As String = ""
        Dim m1 As String = ""
        Dim m2 As String = ""
        Dim ord As String = ""
        Dim comp As String = "user" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)


        MiConexion(bda)


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT" & tabla2.Rows(0).Item("nit")
        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & "/" & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & "/" & Strings.Right(fecha2.Text, 4)


        If c2.Checked = True Then
            cad = cad & " AND usuario='" & txttip.Text & "'"
        End If
        If f2.Checked = True Then
            cad = cad & " AND form='" & txtform.Text & "'"
        End If

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If m1 = m2 Then
                sql = "SELECT u.usuario AS usuario, TRIM(CONCAT(s.nombres,' ',s.apellidos)) AS d1, u.fecha, u.hora," _
               & " CAST(CONCAT(RIGHT(u.fecha,2),'/',MID(u.fecha,6,2),'/',LEFT(u.fecha,4)) AS CHAR(15)) AS nitc,  " _
               & "CAST(u.hora AS CHAR(10)) AS nitv, u.form AS ciu_ent, u.tipmov AS dir_ent, u.campos AS descrip,  " _
               & "u.nuevo AS observ, u.anterior AS entregar , u.per as afecta " _
               & "FROM " & comp & ".mov" & p & " u, sae.usuarios s " _
               & " WHERE u.usuario = s.login AND u.fecha BETWEEN '" & CDate(fecha1.Text).ToString("yyyy-MM-dd") & "' AND '" & CDate(fecha2.Text).ToString("yyyy-MM-dd") & "' " & cad
            Else
                If p = m1 Then
                    sql = "SELECT u.usuario AS usuario, TRIM(CONCAT(s.nombres,' ',s.apellidos)) AS d1, u.fecha, u.hora," _
                   & " CAST(CONCAT(RIGHT(u.fecha,2),'/',MID(u.fecha,6,2),'/',LEFT(u.fecha,4)) AS CHAR(15)) AS nitc,  " _
                   & "CAST(u.hora AS CHAR(10)) AS nitv, u.form AS ciu_ent, u.tipmov AS dir_ent, u.campos AS descrip,  " _
                   & "u.nuevo AS observ, u.anterior AS entregar, u.per as afecta  " _
                   & "FROM " & comp & ".mov" & p & " u, sae.usuarios s " _
                   & " WHERE u.usuario = s.login AND u.fecha >= '" & CDate(fecha1.Text).ToString("yyyy-MM-dd") & "' " & cad
                ElseIf p <> m1 And p <> m2 Then
                    sql = sql & " UNION SELECT u.usuario AS usuario, TRIM(CONCAT(s.nombres,' ',s.apellidos)) AS d1, u.fecha, u.hora," _
                  & " CAST(CONCAT(RIGHT(u.fecha,2),'/',MID(u.fecha,6,2),'/',LEFT(u.fecha,4)) AS CHAR(15)) AS nitc,  " _
                  & "CAST(u.hora AS CHAR(10)) AS nitv, u.form AS ciu_ent, u.tipmov AS dir_ent, u.campos AS descrip,  " _
                  & "u.nuevo AS observ, u.anterior AS entregar, u.per as afecta  " _
                  & "FROM " & comp & ".mov" & p & " u, sae.usuarios s " _
                  & " WHERE u.usuario = s.login  " & cad
                ElseIf p = m2 Then
                    sql = sql & " UNION SELECT u.usuario AS usuario, TRIM(CONCAT(s.nombres,' ',s.apellidos)) AS d1, u.fecha, u.hora," _
                  & " CAST(CONCAT(RIGHT(u.fecha,2),'/',MID(u.fecha,6,2),'/',LEFT(u.fecha,4)) AS CHAR(15)) AS nitc,  " _
                  & "CAST(u.hora AS CHAR(10)) AS nitv, u.form AS ciu_ent, u.tipmov AS dir_ent, u.campos AS descrip,  " _
                  & "u.nuevo AS observ, u.anterior AS entregar, u.per as afecta  " _
                  & "FROM " & comp & ".mov" & p & " u, sae.usuarios s " _
                  & " WHERE u.usuario = s.login AND u.fecha <= '" & CDate(fecha2.Text).ToString("yyyy-MM-dd") & "' " & cad
                End If
            End If
        Next
        If chgrup.Checked = True Then
            sql = sql & " ORDER BY usuario, fecha, hora"
        Else
            sql = sql & " ORDER BY fecha, hora "
        End If


        TextBox1.Text = sql

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        If chgrup.Checked = True Then
            ' Agr por usuario
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RAuditar\ReportAudMovUser.rpt")
        Else
            ' Agr por fech
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RAuditar\ReportAudMovUserF.rpt")
        End If

        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try
        FrmVisorAuditoria.CrystalReportViewer1.ReportSource = CrReport

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

            'Prperiodo.Name = "periodo"
            'Prperiodo.CurrentValues.AddValue(per.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            'prmdatos.Add(Prperiodo)


            FrmVisorAuditoria.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorAuditoria.ShowDialog()


        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True And txttip.Text = "" Then
            MsgBox("Verifique el Usuario", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If CDate(fecha2.Value) < CDate(fecha1.Value) Then
            MsgBox("Verifique el rango de fechas", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        
        verPDF()
    End Sub
End Class