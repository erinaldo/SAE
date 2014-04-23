Imports iTextSharp.text.pdf
Imports iTextSharp.text
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
Public Class FrmInfMovCentroC

    Private Sub FrmInfMovCentroC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BuscarPeriodo()
        
            Dim ano As String = ""
            ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtcuenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.DoubleClick
        Try
            FrmCuentas.lbform.Text = "infMovCC"
            FrmCuentas.txtcuenta.Text = txtcuenta.Text
            txtcuenta.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
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
    Private Sub BuscarNit()
        Try
            If Trim(txtnit.Text) = "" Then
                txtnombre.Text = ""
                FrmSelCliente.lbform.Text = "infMovCC"
                FrmSelCliente.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & Trim(txtnit.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtnombre.Text = ""
                    FrmSelCliente.lbform.Text = "infMovCC"
                    FrmSelCliente.txtcuenta.Text = Trim(txtnit.Text)
                    txtnit.Text = ""
                    FrmSelCliente.ShowDialog()
                Else
                    txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
                End If
            End If
        Catch ex As Exception
            txtnombre.Text = ""
        End Try
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged
        If txtnit.Text = "" Then
            txtnombre.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ch2.Checked = True Then
            If txtcheque.Text = "" Then
                MsgBox("Verifique el codigo del centro de costo", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
        End If
        If c2.Checked = True Then
            If txtcuenta.Text = "" Then
                MsgBox("Verifique el numero de la cuenta", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
        End If
        If n2.Checked = True Then
            If txtnombre.Text = "" Then
                MsgBox("Verifique los datos del Tercero", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
        End If
        'Try
        pdf()
        'Catch ex As Exception
        '    MsgBox("Error al General el Informe", MsgBoxStyle.Information, "SAE")
        'End Try
    End Sub
    Private Sub pdf()

        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cad As String = ""


        MiConexion(bda)
        Cerrar()

        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & "/" & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & "/" & Strings.Right(fecha2.Text, 4)


        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")


        If ch2.Checked = True Then
            cad = " AND d.cheque='" & txtcheque.Text & "'"
        End If
        If c2.Checked = True Then
            cad = " AND d.codigo='" & txtcuenta.Text & "'"
        End If
        If n2.Checked = True Then
            cad = " AND d.nit='" & txtnit.Text & "'"
        End If
        If chGrupo.Checked = True Then
            cad = " AND d.codigo like '5%' OR d.codigo like '6%' "
        End If

        Dim m1 As String = ""
        Dim m2 As String = ""

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        sql = sql & " SELECT ctaret,descrip,subtotal,nitc,nomnit,doc,ctaiva,concepto,tasa,pagado, ctatotal,item FROM ("


        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If m1 = m2 Then
                sql = sql & "SELECT d.centro AS ctaret,c.nombre AS descrip, c.pres AS subtotal,d.nit AS nitc, TRIM(CONCAT(t.nombre,' ', t.apellidos)) AS nomnit, d.item," _
                & " CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS doc,CONCAT(d.dia,'/',d.periodo) AS ctaiva,d.descri AS concepto,d.debito AS pagado, " _
                & " d.credito AS tasa,d.codigo AS ctatotal " _
                & " FROM documentos" & p & " d , centrocostos c, terceros t WHERE c.centro=d.centro AND d.nit= t.nit AND FORMAT(d.dia,0) BETWEEN '" & Val(Strings.Left(fecha1.Text, 2)) & "' AND  '" & Val(Strings.Left(fecha2.Text, 2)) & "' " & cad

                'sql = sql & "SELECT d.cheque AS doc_ext,CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS nitcod, CONCAT(d.dia,'/', d.periodo) AS nitc, " _
                '& " d.descri AS descrip, d.debito AS subtotal, d.credito AS total,CONCAT(d.codigo,' ',s.descripcion) AS  nomnit, " _
                '& " CONCAT(d.nit,' ',TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS concepto FROM documentos" & p & " d, terceros t, selpuc s" _
                '& " WHERE cheque NOT IN ('','facturacion','inventarios') AND t.nit = d.nit AND s.codigo= d.codigo AND FORMAT(d.dia,0) BETWEEN '" & Val(Strings.Left(fecha1.Text, 2)) & "' AND  '" & Val(Strings.Left(fecha2.Text, 2)) & "' " & cad
            Else
                If p = m1 Then
                    sql = sql & "SELECT d.centro AS ctaret,c.nombre AS descrip, c.pres AS subtotal,d.nit AS nitc, TRIM(CONCAT(t.nombre,' ', t.apellidos)) AS nomnit, d.item," _
               & " CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS doc,CONCAT(d.dia,'/',d.periodo) AS ctaiva,d.descri AS concepto,d.debito AS pagado, " _
               & " d.credito AS tasa,d.codigo AS ctatotal " _
               & " FROM documentos" & p & " d , centrocostos c, terceros t WHERE c.centro=d.centro AND d.nit= t.nit AND FORMAT(d.dia,0) >='" & CInt(Strings.Left(fecha1.Text, 2)) & "' " & cad
                    '     sql = sql & "SELECT d.cheque AS doc_ext,CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS nitcod, CONCAT(d.dia,'/', d.periodo) AS nitc, " _
                    '& " d.descri AS descrip, d.debito AS subtotal, d.credito AS total,CONCAT(d.codigo,' ',s.descripcion) AS  nomnit, " _
                    '& " CONCAT(d.nit,' ',TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS concepto FROM documentos" & p & " d, terceros t, selpuc s" _
                    '& " WHERE cheque NOT IN ('','facturacion','inventarios') AND t.nit = d.nit AND s.codigo= d.codigo AND FORMAT(d.dia,0) >='" & CInt(Strings.Left(fecha1.Text, 2)) & "' " & cad
                ElseIf p <> m1 And p <> m2 Then
                    sql = sql & " UNION SELECT d.centro AS ctaret,c.nombre AS descrip, c.pres AS subtotal,d.nit AS nitc, TRIM(CONCAT(t.nombre,' ', t.apellidos)) AS nomnit, d.item," _
              & " CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS doc,CONCAT(d.dia,'/',d.periodo) AS ctaiva,d.descri AS concepto,d.debito AS pagado, " _
              & " d.credito AS tasa,d.codigo AS ctatotal " _
              & " FROM documentos" & p & " d , centrocostos c, terceros t WHERE c.centro=d.centro AND d.nit= t.nit " & cad

                    '      sql = sql & " UNION SELECT d.cheque AS doc_ext,CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS nitcod, CONCAT(d.dia,'/', d.periodo) AS nitc, " _
                    '& " d.descri AS descrip, d.debito AS subtotal, d.credito AS total,CONCAT(d.codigo,' ',s.descripcion) AS  nomnit, " _
                    '& " CONCAT(d.nit,' ',TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS concepto FROM documentos" & p & " d, terceros t, selpuc s" _
                    '& " WHERE cheque NOT IN ('','facturacion','inventarios') AND t.nit = d.nit AND s.codigo= d.codigo  " & cad
                ElseIf p = m2 Then
                    sql = sql & " UNION SELECT d.centro AS ctaret,c.nombre AS descrip, c.pres AS subtotal,d.nit AS nitc, TRIM(CONCAT(t.nombre,' ', t.apellidos)) AS nomnit, d.item," _
              & " CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS doc,CONCAT(d.dia,'/',d.periodo) AS ctaiva,d.descri AS concepto,d.debito AS pagado, " _
              & " d.credito AS tasa,d.codigo AS ctatotal " _
              & " FROM documentos" & p & " d , centrocostos c, terceros t WHERE c.centro=d.centro AND d.nit= t.nit AND FORMAT(d.dia,0) >='" & CInt(Strings.Left(fecha2.Text, 2)) & "' " & cad

                    '       sql = sql & " UNION SELECT d.cheque AS doc_ext,CAST(CONCAT(d.tipodoc,'',LPAD(d.doc,5,'0')) AS CHAR(10)) AS nitcod, CONCAT(d.dia,'/', d.periodo) AS nitc, " _
                    '& " d.descri AS descrip, d.debito AS subtotal, d.credito AS total,CONCAT(d.codigo,' ',s.descripcion) AS  nomnit, " _
                    '& " CONCAT(d.nit,' ',TRIM(CONCAT(t.nombre,' ',t.apellidos))) AS concepto FROM documentos" & p & " d, terceros t, selpuc s" _
                    '& " WHERE cheque NOT IN ('','facturacion','inventarios') AND t.nit = d.nit AND s.codigo= d.codigo AND FORMAT(d.dia,0) >='" & CInt(Strings.Left(fecha2.Text, 2)) & "'  " & cad
                End If
            End If
        Next
        sql = sql & " ) AS c ORDER BY ctaret "



        Dim tabla As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")



        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportMovCentroCosto.rpt")
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

            'Prtipo.Name = "tipo"
            'Prtipo.CurrentValues.AddValue(tipo.ToString)

            'Prtt.Name = "tt"
            'Prtt.CurrentValues.AddValue(tt.ToString)

            'Prtitulo.Name = "titulo"
            'Prtitulo.CurrentValues.AddValue(titulo.ToString)

            'PrtituloG.Name = "tituloG"
            'PrtituloG.CurrentValues.AddValue(tituloG.ToString)

            'Prcf.Name = "Cue_Fec"
            'Prcf.CurrentValues.AddValue(c_f.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            'prmdatos.Add(Prtipo)
            'prmdatos.Add(Prtt)
            'prmdatos.Add(Prtitulo)
            'prmdatos.Add(PrtituloG)
            'prmdatos.Add(Prcf)

            FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCMov_cue.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked = True Then
            txtcheque.Enabled = True
        Else
            txtcheque.Enabled = False
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcuenta.Enabled = True
        Else
            txtcuenta.Enabled = False
        End If
    End Sub

    Private Sub n2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n2.CheckedChanged
        If n2.Checked = True Then
            txtnit.Enabled = True
        Else
            txtnit.Enabled = False
        End If
    End Sub

    Private Sub txtcheque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcheque.LostFocus

        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcheque.Text & "' and nivel='centro' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        If tabla2.Rows.Count = 0 Then
            txtcheque.Text = ""
            FrmSelCentroCostos.lbform.Text = "InfoMovCC"
            FrmSelCentroCostos.ShowDialog()
        End If
    End Sub
End Class