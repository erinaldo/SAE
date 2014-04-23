Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmInfSerInm

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfSerInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 4)
        txtpini.Text = Strings.Right(PerActual, 4)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
    End Sub

    Private Sub txtdi1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdi1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtdi1, e)
        End If
    End Sub

    Private Sub txtdi2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdi2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtdi2, e)
        End If
    End Sub

    Private Sub txtdi2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi2.LostFocus
        If CDbl(txtdi2.Text) > 31 Then
            txtdi2.Text = 31
        ElseIf Int(txtdi2.Text) < 10 Then
            txtdi2.Text = "0" & Int(txtdi2.Text)
        End If
    End Sub

    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If CDbl(txtdi1.Text) > 31 Then
            txtdi1.Text = 31
        ElseIf Int(txtdi1.Text) < 10 Then
            txtdi1.Text = "0" & Int(txtdi1.Text)
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim cad As String = ""
        If d1.Checked = True Then
            cad = " and estado='AP'"
        ElseIf d3.Checked = True Then
            cad = " and estado='AN'"
        End If
        '...........
        If c2.Checked = True Then
            If Trim(txttip.Text) = "" Then
                MsgBox("Verifique el nit del cliente", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
            If cbfac.Text = "ARRENDATARIO" Then
                cad = cad & " and nita ='" & txttip.Text & "' "
            Else
                cad = cad & " and nitp ='" & txttip.Text & "' "
            End If
        End If
        If r1.Checked = True Then
            Try
                pdf1(cad)
            Catch ex As Exception
                MsgBox("Error al generar el informe " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        Else
            Try
                pdf2(cad)
            Catch ex As Exception
                MsgBox("Error al generar el informe " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
    End Sub
    Private Sub pdf1(ByVal cad As String)

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

        per = "PERIODO INICIAL: " & txtdi1.Text & "/" & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & txtdi2.Text & "/" & cbfin.Text & "/" & txtpfin.Text
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = "SELECT doc , CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS ctaret, " _
                & " CONCAT(nitp,' - ',nomp) AS nomnit, totalp AS total, por_iva AS iva, iva AS v_viva, por_comi AS ret, " _
                & " vcomi AS subtotal, estado as moneda FROM facturainm" & p & " WHERE  right(fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & cad
            Else
                If p = cbini.Text Then
                    sql = "SELECT doc , CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS ctaret, " _
               & " CONCAT(nitp,' - ',nomp) AS nomnit, totalp AS total, por_iva AS iva, iva AS v_viva, por_comi AS ret, " _
               & " vcomi AS subtotal, estado as moneda FROM facturainm" & p & " WHERE  right(fecha,2) >= '" & txtdi1.Text & "' " & cad
                ElseIf p = cbini.Text <> p = cbfin.Text Then
                    sql = sql & " UNION SELECT doc , CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS ctaret, " _
              & " CONCAT(nitp,' - ',nomp) AS nomnit, totalp AS total, por_iva AS iva, iva AS v_viva, por_comi AS ret, " _
              & " vcomi AS subtotal, estado as moneda FROM facturainm" & p & " where doc<>'' " & cad
                ElseIf p = cbfin.Text Then
                    sql = sql & " UNION SELECT doc , CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS ctaret, " _
             & " CONCAT(nitp,' - ',nomp) AS nomnit, totalp AS total, por_iva AS iva, iva AS v_viva, por_comi AS ret, " _
             & " vcomi AS subtotal, estado as moneda FROM facturainm" & p & " WHERE  right(fecha,2) <= '" & txtdi2.Text & "' " & cad
                End If
            End If

        Next
        sql = sql & " ORDER BY doc"


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfServD.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrdA As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)


            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub pdf2(ByVal cad As String)
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

        per = "PERIODO INICIAL: " & txtdi1.Text & "/" & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & txtdi2.Text & "/" & cbfin.Text & "/" & txtpfin.Text
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")

        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = "SELECT doc, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS usuario," _
                & " descripcion AS descrip, valor AS subtotal, nita AS cta1, noma AS d1, totala AS v1, " _
                & "  otrosa AS descuento, nitp AS cta2, nomp AS d2, totalp AS v2, otrosp AS ret_iva, por_comi AS por_ret_f, " _
                & "  vcomi AS ret_f, por_iva, iva, dias AS num FROM facturainm" & p & " WHERE  right(fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & cad
            Else
                If p = cbini.Text Then
                    sql = "SELECT doc, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS usuario," _
               & " descripcion AS descrip, valor AS subtotal, nita AS cta1, noma AS d1, totala AS v1, " _
               & "  otrosa AS descuento, nitp AS cta2, nomp AS d2, totalp AS v2, otrosp AS ret_iva, por_comi AS por_ret_f, " _
               & "  vcomi AS ret_f, por_iva, iva, dias AS num FROM facturainm" & p & " WHERE  right(fecha,2) >= '" & txtdi1.Text & "' " & cad
                ElseIf p = cbini.Text <> p = cbfin.Text Then
                    sql = sql & " UNION SELECT doc, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS usuario," _
               & " descripcion AS descrip, valor AS subtotal, nita AS cta1, noma AS d1, totala AS v1, " _
               & "  otrosa AS descuento, nitp AS cta2, nomp AS d2, totalp AS v2, otrosp AS ret_iva, por_comi AS por_ret_f, " _
               & "  vcomi AS ret_f, por_iva, iva, dias AS num FROM facturainm" & p & " WHERE  doc<>'' " & cad
                ElseIf p = cbfin.Text Then
                    sql = sql & " UNION SELECT doc, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS usuario," _
              & " descripcion AS descrip, valor AS subtotal, nita AS cta1, noma AS d1, totala AS v1, " _
              & "  otrosa AS descuento, nitp AS cta2, nomp AS d2, totalp AS v2, otrosp AS ret_iva, por_comi AS por_ret_f, " _
              & "  vcomi AS ret_f, por_iva, iva, dias AS num FROM facturainm" & p & " WHERE  right(fecha,2) <= '" & txtdi2.Text & "' " & cad
               End If
            End If

        Next
        sql = sql & " ORDER BY doc"


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfServC.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrdA As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(per.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

  
    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            cbfac.Enabled = True
            cbfac.Text = "ARRENDATARIO"
        Else
            txttip.Enabled = False
            cbfac.Enabled = False
        End If
    End Sub

    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        ValidarNIT(txttip, e)
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try
            If txttip.Text <> "" Then
                Dim t As New DataTable
                myCommand.CommandText = "SELECT nit, concat(nombre, apellidos) as nom FROM terceros WHERE nit='" & Trim(txttip.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If t.Rows.Count > 0 Then
                    txtnom.Text = t.Rows(0).Item("nom")
                Else
                    Try
                        txttip.Text = ""
                        FrmSelDueño.Text = "Seleccionar Tercero"
                        FrmSelDueño.lbform.Text = "infFacInm2"
                        FrmSelDueño.txtclase.Text = "cliente_inm"
                        FrmSelDueño.ShowDialog()
                    Catch ex As Exception
                    End Try
                End If

            Else
                Try
                    txttip.Text = ""
                    FrmSelDueño.Text = "Seleccionar Tercero"
                    FrmSelDueño.lbform.Text = "infFacInm2"
                    FrmSelDueño.txtclase.Text = "cliente_inm"
                    FrmSelDueño.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class