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
Public Class FrmEjecGastos
    Dim tt, cm, a, f1, f2 As String
    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        MiConexion("presupuesto" & Strings.Right(PerActual, 4))
        Try

       
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            f1 = Strings.Right(CDate(fecha1.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha1.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha1.Text.ToString), 2)
            f2 = Strings.Right(CDate(fecha2.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha2.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha2.Text.ToString), 2)


            If r1.Checked = True Then
                tt = "EJECUCION DE " & fecha1.Text & " A " & fecha2.Text & " ACUMULADO" & vbCrLf & tabla2.Rows(0).Item("descripcion") & vbCrLf & " NIT: " & tabla2.Rows(0).Item("nit") & vbCrLf & " VIGENCIA: " & Strings.Right(PerActual, 4)
                If p1.Checked = True Then
                    GAcu1()
                Else
                    GAcu2()
                End If
            Else
                tt = "EJECUCION DE " & fecha1.Text & " A " & fecha2.Text & " INDIVIDUAL " & vbCrLf & tabla2.Rows(0).Item("descripcion") & vbCrLf & " NIT: " & tabla2.Rows(0).Item("nit") & vbCrLf & " VIGENCIA: " & Strings.Right(PerActual, 4)
                If p1.Checked = True Then
                    GIcu1()
                Else
                    GInd2()
                End If

            End If
        Catch ex As Exception
            MsgBox("Error al generar los informes " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub GAcu1()
        Dim sql As String = ""

        sql = "SELECT c.gasc_orden, c.gasc_" & cm & " d1, c.gasc_concepto descrip, c.gasc_sd t1,  TRIM(REPLACE(SUBSTRING(gasc_concepto,INSTR(gasc_concepto,'-')),'-','')) AS ciu_ent," _
& " cast(v.gasv_valor as signed)subtotal, IFNULL(m.cr,0) iva, IFNULL(m.ct,0) AS ret_iva, IFNULL(m.ad,0) descuento, IFNULL(m.rd,0) ret_f ," _
& " (v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0)) ret_ica, " _
& " IFNULL(m.rp,0) total, ((v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0))- IFNULL(m.rp,0)) v1, " _
& " IFNULL(m.pagos,0) v2,(IFNULL(m.rp,0)-IFNULL(m.pagos,0)) v3 " _
& " FROM  gasvalores v,gasconcepto c " _
& " Left Join " _
& " (SELECT movg_rubro, SUM(movg_credito) cr, SUM(movg_contra) ct, SUM(movg_aumento) ad, SUM(movg_reduccion) rd, " _
& " SUM(movg_rp) AS rp, SUM(movg_cdp) cdp, SUM(mov_vsae) pagos, SUM(movg_aplaza) apla, SUM(movg_desaplaza) dsz  FROM movgastos WHERE  " _
& "  movg_fecha BETWEEN '2014-01-01' AND '" & f2 & "'  " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) m ON m.movg_rubro=c.gasc_orden  " _
& "  WHERE(c.gasc_orden = v.gasv_orden) " _
& " ORDER BY c.gasc_nums "

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = Sql
       myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportEjecGasA1.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCompCPP.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcomp As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "t1"
            Prcomp.CurrentValues.AddValue(tt.ToString)
            prmdatos.Add(Prcomp)

            FrmReportCompCPP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCompCPP.ShowDialog()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GIcu1()
        Dim sql As String = ""

        sql = "SELECT c.gasc_orden, c.gasc_" & cm & " d1, c.gasc_concepto descrip, c.gasc_sd t1,  TRIM(REPLACE(SUBSTRING(gasc_concepto,INSTR(gasc_concepto,'-')),'-','')) AS ciu_ent," _
& " cast(v.gasv_valor as signed)subtotal, IFNULL(m.cr,0) iva, IFNULL(m.ct,0) AS ret_iva, IFNULL(m.ad,0) descuento, IFNULL(m.rd,0) ret_f ," _
& " (v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0)) ret_ica, " _
& " IFNULL(m.rp,0) total, IFNULL(n.rp,0) por_desc, ((v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0))- IFNULL(m.rp,0)) v1, " _
& " IFNULL(m.pagos,0) v2,IFNULL(n.pagos,0) por_ret_f,(IFNULL(m.rp,0)-IFNULL(m.pagos,0)) v3 " _
& " FROM  gasvalores v,gasconcepto c " _
& " Left Join " _
& " (SELECT movg_rubro, SUM(movg_credito) cr, SUM(movg_contra) ct, SUM(movg_aumento) ad, SUM(movg_reduccion) rd, " _
& " SUM(movg_rp) AS rp, SUM(movg_cdp) cdp, SUM(mov_vsae) pagos, SUM(movg_aplaza) apla, SUM(movg_desaplaza) dsz  FROM movgastos WHERE  " _
& "  movg_fecha BETWEEN '2014-01-01' AND '" & f2 & "'  " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) m ON m.movg_rubro=c.gasc_orden  " _
& " LEFT JOIN " _
& " (SELECT movg_rubro,  SUM(movg_rp) AS rp,  SUM(mov_vsae) pagos  FROM movgastos WHERE   movg_fecha BETWEEN '" & f1 & "' AND '" & f2 & "'  " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) n   ON n.movg_rubro=c.gasc_orden " _
& "  WHERE(c.gasc_orden = v.gasv_orden) " _
& " ORDER BY c.gasc_nums "

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportEjecGasI1.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCompCPP.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcomp As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "t1"
            Prcomp.CurrentValues.AddValue(tt.ToString)
            prmdatos.Add(Prcomp)

            FrmReportCompCPP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCompCPP.ShowDialog()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GAcu2()
        Dim sql As String = ""


        sql = "SELECT c.gasc_orden, c.gasc_" & cm & " d1, c.gasc_concepto descrip, c.gasc_sd t1,  " _
& " TRIM(REPLACE(SUBSTRING(gasc_concepto,INSTR(gasc_concepto,'-')),'-','')) AS ciu_ent,cast(v.gasv_valor as signed)subtotal,  " _
& " IFNULL(m.cr,0) iva, IFNULL(m.ct,0) AS ret_iva, IFNULL(m.ad,0) descuento, IFNULL(m.rd,0) ret_f ,  " _
& " (v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0)) ret_ica, " _
& " IFNULL(m.rp,0) total,  " _
& " IFNULL(m.cdp,0) por_desc, " _
& " ((v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0))- IFNULL(m.cdp,0)) v1, " _
& " IFNULL(m.pagos,0) v2,(IFNULL(m.rp,0)-IFNULL(m.pagos,0)) v3   " _
& " FROM  gasvalores v,gasconcepto c  LEFT JOIN   " _
& " (SELECT movg_rubro, SUM(movg_credito) cr, SUM(movg_contra) ct, SUM(movg_aumento) ad, SUM(movg_reduccion) rd,  SUM(movg_rp) AS rp,  " _
& " SUM(movg_cdp) cdp, SUM(mov_vsae) pagos, SUM(movg_aplaza) apla, SUM(movg_desaplaza) dsz  FROM movgastos  " _
& " WHERE    movg_fecha BETWEEN '2014-01-01' AND '" & f2 & "'    " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) m ON m.movg_rubro=c.gasc_orden    WHERE(c.gasc_orden = v.gasv_orden)   " _
& " ORDER BY c.gasc_nums "

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportEjecGasA2.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCompCPP.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "t1"
            Prcomp.CurrentValues.AddValue(tt.ToString)
            prmdatos.Add(Prcomp)

            FrmReportCompCPP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCompCPP.ShowDialog()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GInd2()
        Dim sql As String = ""


        sql = "SELECT c.gasc_orden, c.gasc_" & cm & " d1, c.gasc_concepto descrip, c.gasc_sd t1,  " _
& " TRIM(REPLACE(SUBSTRING(gasc_concepto,INSTR(gasc_concepto,'-')),'-','')) AS ciu_ent,cast(v.gasv_valor as signed)subtotal,  " _
& " IFNULL(m.cr,0) iva, IFNULL(m.ct,0) AS ret_iva, IFNULL(m.ad,0) descuento, IFNULL(m.rd,0) ret_f ,  " _
& " (v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0)) ret_ica, " _
& " IFNULL(m.rp,0) total, IFNULL(n.rp,0) por_ret_f,  " _
& " IFNULL(m.cdp,0) por_desc, IFNULL(n.cdp,0) por_iva,  IFNULL(n.pagos,0) por_ret_iva, " _
& " ((v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0))- IFNULL(m.cdp,0)) v1, " _
& " IFNULL(m.pagos,0) v2,(IFNULL(m.rp,0)-IFNULL(m.pagos,0)) v3   " _
& " FROM  gasvalores v,gasconcepto c  LEFT JOIN   " _
& " (SELECT movg_rubro, SUM(movg_credito) cr, SUM(movg_contra) ct, SUM(movg_aumento) ad, SUM(movg_reduccion) rd,  SUM(movg_rp) AS rp,  " _
& " SUM(movg_cdp) cdp, SUM(mov_vsae) pagos, SUM(movg_aplaza) apla, SUM(movg_desaplaza) dsz  FROM movgastos  " _
& " WHERE    movg_fecha BETWEEN '2014-01-01' AND '" & f2 & "'    " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) m ON m.movg_rubro=c.gasc_orden    LEFT JOIN  " _
& " (SELECT movg_rubro,  SUM(movg_cdp) cdp,  SUM(movg_rp) rp,  SUM(mov_vsae) pagos  FROM movgastos  " _
& " WHERE    movg_fecha BETWEEN '" & f1 & "' AND '" & f2 & "'    " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) n ON n.movg_rubro=c.gasc_orden" _
& " WHERE(c.gasc_orden = v.gasv_orden)   " _
& " ORDER BY c.gasc_nums "

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportEjecGasI2.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCompCPP.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "t1"
            Prcomp.CurrentValues.AddValue(tt.ToString)
            prmdatos.Add(Prcomp)

            FrmReportCompCPP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCompCPP.ShowDialog()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FrmEjecGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        a = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        Dim ok As String = "n"
        myCommand.CommandText = "SHOW DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = "presupuesto" & a Then
                ok = "s"
                Exit For
            End If
        Next
        If ok = "n" Then
            MsgBox("Esta empresa no usa el software de Presupuesto", MsgBoxStyle.Information, "SAE")
            Me.Close()
        End If


        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Try
            fecha1.MinDate = "01/01/" & ano
            fecha1.MaxDate = "31/12/" & ano
            fecha2.MinDate = "01/01/" & ano
            fecha2.MaxDate = "31/12/" & ano
            '**************************************

            fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception

        End Try
        Try
            fecha2.Value = DateSerial(Strings.Right(PerActual, 4), Strings.Left(PerActual, 2) + 1, 0)
            'fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
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


        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "fut"
        Else
            cm = "cgdg"
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class