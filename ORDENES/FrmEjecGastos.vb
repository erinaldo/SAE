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

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        MiConexion("presupuesto2014")
        If r1.Checked = True Then
            GAcu1()
        End If

        Cerrar()
    End Sub
    Private Sub GAcu1()
        Dim sql As String = ""

        sql = "SELECT c.gasc_orden, c.gasc_fut d1, c.gasc_concepto descrip, c.gasc_sd t1,  TRIM(REPLACE(SUBSTRING(gasc_concepto,INSTR(gasc_concepto,'-')),'-','')) AS ciu_ent," _
& " v.gasv_valor subtotal, IFNULL(m.cr,0) iva, IFNULL(m.ct,0) AS ret_iva, IFNULL(m.ad,0) descuento, IFNULL(m.rd,0) ret_f ," _
& " (v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0)) ret_ica, " _
& " IFNULL(m.rp,0) total, ((v.gasv_valor +IFNULL(m.ad,0) +IFNULL(m.dsz,0)+ IFNULL(m.cr,0)-IFNULL(m.ct,0)-IFNULL(m.rd,0)-IFNULL(m.apla,0))- IFNULL(m.rp,0)) v1, " _
& " IFNULL(m.pagos,0) v2,(IFNULL(m.rp,0)-IFNULL(m.pagos,0)) v3 " _
& " FROM  gasvalores v,gasconcepto c " _
& " Left Join " _
& " (SELECT movg_rubro, SUM(movg_credito) cr, SUM(movg_contra) ct, SUM(movg_aumento) ad, SUM(movg_reduccion) rd, " _
& " SUM(movg_rp) AS rp, SUM(movg_cdp) cdp, SUM(mov_vsae) pagos, SUM(movg_aplaza) apla, SUM(movg_desaplaza) dsz  FROM movgastos WHERE  " _
& "  movg_fecha BETWEEN '2014-01-01' AND '2014-06-30'  " _
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
        FrmReportCompCPP.ShowDialog()

    End Sub
End Class