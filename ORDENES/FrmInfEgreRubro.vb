Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports MySql.Data.MySqlClient
Public Class FrmInfEgreRubro
    Dim cm, a As String

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtd.LostFocus
        BuscarRubr()
    End Sub

    Private Sub FrmInfEgreRubro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbini.Text = Strings.Left(PerActual, 2)
        cbfin.Text = Strings.Left(PerActual, 2)

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

        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "c.gasc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "c.gasc_fut"
        Else
            cm = "c.gasc_cgdg"
        End If
    End Sub
    Private Sub BuscarRubr()

        If Trim(txtd.Text) <> "" Then
            Dim tabla As New DataTable
            myCommand.CommandText = " select " & cm & ", c.gasc_concepto, c.gasc_cod1 , c.gasc_sd, v.gasv_credito, v.gasv_contrac " _
            & " from presupuesto" & a & ".gasconcepto c, presupuesto" & a & ".gasvalores v " _
            & " where " & cm & " = '" & Trim(txtd.Text) & "' AND c.gasc_sd='D' and c.gasc_cod1= v.gasv_cod1"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                txtd.Text = tabla.Rows(0).Item("gasc_cod1")
                txtnomr.Text = tabla.Rows(0).Item("gasc_concepto")
            Else
                Try
                    Try
                        txtd.Text = ""
                        txtnomr.Text = ""
                    Catch ex As Exception
                    End Try
                    FrmSelRubrIng.lbform.Text = "infCER"
                    FrmSelRubrIng.lbcm.Text = cm
                    FrmSelRubrIng.ShowDialog()
                    If txtd.Text = "" Then
                        MsgBox("Confirme el rubro nuevamente", MsgBoxStyle.Information, "SAE")
                        txtd.Text = ""
                    End If
                Catch ex As Exception
                End Try
            End If
        Else
            Try
                Try
                    txtd.Text = ""
                    txtnomr.Text = ""
                Catch ex As Exception
                End Try
                FrmSelRubrIng.lbform.Text = "infCER"
                FrmSelRubrIng.lbcm.Text = cm
                FrmSelRubrIng.ShowDialog()
                If txtd.Text = "" Then
                    MsgBox("Confirme el rubro nuevamente", MsgBoxStyle.Information, "SAE")
                    txtd.Text = ""
                End If
            Catch ex As Exception
            End Try
        End If


    End Sub

    Private Sub r2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r2.CheckedChanged
        If r2.Checked = True Then
            txtd.Enabled = True
            txtd.Text = ""
            txtnomr.Text = ""
        Else
            txtd.Enabled = False
        End If
    End Sub

    Private Sub txtd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtd.TextChanged
        If txtd.Text = "" Then
            txtnomr.Text = ""
        End If
    End Sub

    Private Sub r3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r3.CheckedChanged
        If r3.Checked = True Then
            cmdrb.Enabled = True
        Else
            cmdrb.Enabled = True
        End If
        Try
            grubro.Rows.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdrb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrb.Click
        Try
            Try
                grubro.Rows.Clear()
            Catch ex As Exception
            End Try
            FrmSelRubrIng.lbform.Text = "infCER2"
            FrmSelRubrIng.lbcm.Text = cm
            FrmSelRubrIng.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If CInt(txtdi1.Text) < 9 Then
            txtdi1.Text = "0" & CInt(txtdi1.Text)
        Else
            txtdi1.Text = CInt(txtdi1.Text)
        End If
    End Sub

    Private Sub txtdi2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi2.LostFocus
        If CInt(txtdi2.Text) < 9 Then
            txtdi2.Text = "0" & CInt(txtdi2.Text)
        Else
            txtdi2.Text = CInt(txtdi2.Text)
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            If r2.Checked = True And txtd.Text = "" Then
                MsgBox("Verifique el rubro", MsgBoxStyle.Information, "SAE")
                txtd.Focus()
                Exit Sub
            End If
            If r3.Checked = True And grubro.RowCount = 1 Then
                MsgBox("No ha seleccionado ningun rubro", MsgBoxStyle.Information, "SAE")
                Exit Sub
            End If
            VERPDF()
        Catch ex As Exception
            MsgBox("Error al Generar el Informe", MsgBoxStyle.Information, "SAE")
        End Try

    End Sub
    Private Sub VERPDF()


        Dim sql As String = ""
        Dim cad As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim p As String = ""

        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        If r2.Checked = True Then
            cad = " and c.ccosto like '%" & txtd.Text & "%'"
        ElseIf r3.Checked = True Then
            If grubro.RowCount - 1 > 0 Then
                cad = cad & " AND ("
                For i = 0 To grubro.RowCount - 2

                    If i <> grubro.RowCount - 2 Then
                        cad = cad & " c.ccosto like'%" & grubro.Item(0, i).Value & "%' or "
                    Else
                        cad = cad & " c.ccosto like'%" & grubro.Item(0, i).Value & "%') "
                    End If
                Next
            End If
        End If

        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                'sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.codigo AS nitc, c.descrip AS nomnit, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                '& " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                '& " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                '& " c.credito AS subtotal, " _
                '& " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                '& " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                '& " cast(c.dia as signed) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'" & cad

                sql = "SELECT o.doc AS doc, CAST(CONCAT(o.dia,'/',o.periodo) AS CHAR(15)) AS nitc, o.doc_afec , p.doccxp, p.doc AS doc_ext, c.ccosto AS descrip, g.gasc_concepto AS nomnit, o.total as ret " _
                & " FROM ot_cpp" & p & " o,  ord_pagos p, ctas_x_pagar c LEFT JOIN presupuesto" & Strings.Right(PerActual, 4) & ".gasconcepto g ON c.ccosto = g.gasc_cod1 " _
                & " WHERE o.doc_afec<>'' AND o.doc_afec=p.doccxp AND p.sop_cont =CONCAT('" & p & "/" & Strings.Right(PerActual, 4) & "-',o.doc)  " _
                & " AND p.doccxp = c.doc AND o.doc_afec=c.doc " _
                & " AND cast(o.dia as signed) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "'" & cad

            Else
                If p = cbini.Text Then
                    '     sql = "SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.codigo AS nitc, c.descrip AS nomnit, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                    '& " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    ' & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE t.nit = c.nitc AND p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    ' & " c.credito AS subtotal , " _
                    ' & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    ' & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    ' & " cast(c.dia as signed)>= '" & txtdi1.Text & "' " & cad

                    sql = "SELECT o.doc AS doc, CAST(CONCAT(o.dia,'/',o.periodo) AS CHAR(15)) AS nitc, o.doc_afec , p.doccxp, p.doc AS doc_ext, c.ccosto AS descrip, g.gasc_concepto AS nomnit, o.total as ret " _
                                   & " FROM ot_cpp" & p & " o,  ord_pagos p, ctas_x_pagar c LEFT JOIN presupuesto" & Strings.Right(PerActual, 4) & ".gasconcepto g ON c.ccosto = g.gasc_cod1 " _
                                   & " WHERE o.doc_afec<>'' AND o.doc_afec=p.doccxp AND p.sop_cont =CONCAT('" & p & "/" & Strings.Right(PerActual, 4) & "-',o.doc)  " _
                                   & " AND p.doccxp = c.doc AND o.doc_afec=c.doc " _
                                    & " AND cast(o.dia as signed)>= '" & txtdi1.Text & "' " & cad


                ElseIf p <> cbini.Text And p <> cbfin.Text Then
                    '     sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.codigo AS nitc, c.descrip AS nomnit, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                    '& " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    ' & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE t.nit = c.nitc AND p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    ' & " c.credito AS subtotal , " _
                    ' & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    ' & " FROM ot_cpp" & p & " c, terceros t   WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%')  " & cad

                    sql = sql & " UNION SELECT o.doc AS doc, CAST(CONCAT(o.dia,'/',o.periodo) AS CHAR(15)) AS nitc, o.doc_afec , p.doccxp, p.doc AS doc_ext, c.ccosto AS descrip, g.gasc_concepto AS nomnit, o.total as ret " _
               & " FROM ot_cpp" & p & " o,  ord_pagos p, ctas_x_pagar c LEFT JOIN presupuesto" & Strings.Right(PerActual, 4) & ".gasconcepto g ON c.ccosto = g.gasc_cod1 " _
               & " WHERE o.doc_afec<>'' AND o.doc_afec=p.doccxp AND p.sop_cont =CONCAT('" & p & "/" & Strings.Right(PerActual, 4) & "-',o.doc)  " _
               & " AND p.doccxp = c.doc AND o.doc_afec=c.doc " & cad

                ElseIf p = cbfin.Text Then

                    '     sql = sql & " UNION SELECT CONCAT(c.nitc,' - ',t.nombre, ' ', t.apellidos) AS descrip, c.dia, c.periodo, c.codigo AS nitc, c.descrip AS nomnit, c.doc AS nitcod, CAST( CONCAT(c.dia,'/', c.periodo) AS CHAR(20)) AS nitv," _
                    '& " (SELECT codigo FROM ot_cpp" & p & " WHERE (sucursal='--' OR codigo LIKE '1110%')AND doc= c.doc LIMIT 1) AS ctaret, " _
                    ' & " (SELECT s.descripcion FROM selpuc s, ot_cpp" & p & " p WHERE p.codigo= s.codigo AND p.doc=c.doc AND  (p.sucursal='--' OR p.codigo LIKE '1110%') LIMIT 1) AS concepto, " _
                    ' & " c.credito AS subtotal , " _
                    ' & " CAST(CONCAT(RIGHT(c.periodo,4),LEFT(c.periodo,2),IF(LENGTH(c.dia)=1,CONCAT('0',c.dia),c.dia)) AS DATE) AS ff " _
                    ' & " FROM ot_cpp" & p & " c , terceros t  WHERE t.nit = c.nitc AND c.credito <> 0   AND (c.sucursal<>'--' and c.codigo NOT LIKE '1110%') and  " _
                    ' & " cast(c.dia as signed)<= '" & txtdi2.Text & "' " & cad

                    sql = sql & " union SELECT o.doc AS doc, CAST(CONCAT(o.dia,'/',o.periodo) AS CHAR(15)) AS nitc, o.doc_afec , p.doccxp, p.doc AS doc_ext, c.ccosto AS descrip, g.gasc_concepto AS nomnit, o.total as ret " _
               & " FROM ot_cpp" & p & " o,  ord_pagos p, ctas_x_pagar c LEFT JOIN presupuesto" & Strings.Right(PerActual, 4) & ".gasconcepto g ON c.ccosto = g.gasc_cod1 " _
               & " WHERE o.doc_afec<>'' AND o.doc_afec=p.doccxp AND p.sop_cont =CONCAT('" & p & "/" & Strings.Right(PerActual, 4) & "-',o.doc)  " _
               & " AND p.doccxp = c.doc AND o.doc_afec=c.doc " _
                & " AND cast(o.dia as signed)<= '" & txtdi2.Text & "' " & cad

                End If
            End If

        Next
        sql = sql & " ORDER BY doc, nitc "


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportEgreRb.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField
            Dim Prnit As New ParameterField
            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prnit.Name = "nit"
            Prnit.CurrentValues.AddValue(nit.ToString)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prnit)
            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class