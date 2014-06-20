Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmInfDeducciones

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        MiConexion(bda)
        If r2.Checked = True And txtd.Text = "" Then
            MsgBox("Verifique el codigo de la deduccion ", MsgBoxStyle.Information, "Verificacion")
            txtd.Focus()
            Exit Sub
        End If
        If r3.Checked = True And txtce.Text = "" Then
            MsgBox("Verifique el codigo del Comprobante de egreso ", MsgBoxStyle.Information, "Verificacion")
            txtce.Focus()
            Exit Sub
        End If
        VERPDF()
        Cerrar()
    End Sub
    Private Sub VERPDF()


        Dim sql As String = ""
        Dim cad As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim p As String = ""
        Dim cs As String = ""

        Dim tabla2 As  New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        If r2.Checked = True Then
            cad = " and c.codigo='" & txtd.Text & "'"
        ElseIf r3.Checked = True Then
            cad = " and c.doc='" & txtce.Text & "'"
        End If

        If chb.Checked = False Then
            For i = Val(cbini.Text) To Val(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If cbini.Text = cbfin.Text Then
                    sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                    & " c.credito AS subtotal, " _
                    & " c.codigo AS nitc, c.descrip AS nomnit, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'" & cad
                Else
                    If p = cbini.Text Then
                        sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal , " _
                    & " c.codigo AS nitc, c.descrip AS nomnit, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed)>= '" & txtdi1.Text & "' " & cad
                    ElseIf p <> cbini.Text And p <> cbfin.Text Then
                        sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal ," _
                    & " c.codigo AS nitc, c.descrip AS nomnit, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%')  " & cad

                    ElseIf p = cbfin.Text Then

                        sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal , " _
                    & " c.codigo AS nitc, c.descrip AS nomnit, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c , terceros t  WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed)<= '" & txtdi2.Text & "' " & cad
                    End If
                End If

            Next

        Else
            cs = " c.codigo AS ctaret, c.descrip AS concepto, " _
       & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS nitc, " _
       & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS nomnit, "

            For i = Val(cbini.Text) To Val(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If cbini.Text = cbfin.Text Then
                    sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                    & " c.credito AS subtotal, " _
                    & " c.codigo AS ctaret, c.descrip AS concepto, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS nitc, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS nomnit, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'" & cad
                Else
                    If p = cbini.Text Then
                        sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal , " _
                     & " c.codigo AS ctaret, c.descrip AS concepto, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS nitc, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS nomnit, " _
                     & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed)>= '" & txtdi1.Text & "' " & cad
                    ElseIf p <> cbini.Text And p <> cbfin.Text Then
                        sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal ," _
                     & " c.codigo AS ctaret, c.descrip AS concepto, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS nitc, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS nomnit, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%')  " & cad
                    ElseIf p = cbfin.Text Then
                        sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo,  c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                   & " c.credito AS subtotal , " _
                    & " c.codigo AS ctaret, c.descrip AS concepto, " _
                    & " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS nitc, " _
                    & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS nomnit, " _
                    & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    & " FROM ot_cpp" & p & " c , terceros t  WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    & " cast(c.dia as signed)<= '" & txtdi2.Text & "' " & cad
                    End If
                End If
            Next
        End If

       
        sql = sql & " ORDER BY nitc, ff  "


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportDeducc.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField
            Dim Prnit As New ParameterField
            Dim Prgr As New ParameterField
            Dim Prt As New ParameterField
            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prnit.Name = "nit"
            Prnit.CurrentValues.AddValue(nit.ToString)

            If chb.Checked = False Then
                Prgr.Name = "tgrup"
                Prgr.CurrentValues.AddValue("DEDUCCION")
                Prt.Name = "tt1"
                Prt.CurrentValues.AddValue("CTA BANCARIA")
            Else
                Prgr.Name = "tgrup"
                Prgr.CurrentValues.AddValue("BANCO")
                Prt.Name = "tt1"
                Prt.CurrentValues.AddValue("DEDUCCION")
            End If

            prmdatos.Add(Prcomp)
            prmdatos.Add(Prnit)
            prmdatos.Add(Prgr)
            prmdatos.Add(Prt)
            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub FrmInfDeducciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        r1.Checked = True
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

    Private Sub r2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r2.CheckedChanged
        If r2.Checked = True Then
            txtd.Enabled = True
        Else
            txtd.Enabled = False
            txtd.Text = ""
        End If
    End Sub

    Private Sub r3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r3.CheckedChanged
        If r3.Checked = True Then
            txtce.Enabled = True
        Else
            txtce.Enabled = False
            txtce.Text = ""
        End If
    End Sub

   
    Private Sub txtd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtd.LostFocus

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT DISTINCT TRIM(CTA), concep FROM DETA_ORD WHERE CTA<>''  " _
        & " AND  TRIM(CTA)='" & txtd.Text & "' AND doc LIKE '%" & Strings.Right(PerActual, 4) & "%' ORDER BY TRIM(CTA) ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows.Count = 0 Then
            Try
                txtd.Text = ""
                FrmSeldeducciones.lbform.Text = "infdedu"
                FrmSeldeducciones.ShowDialog()
            Catch ex As Exception

            End Try
        End If

    End Sub
End Class