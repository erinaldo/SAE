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
Public Class FrmInfFacInm

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

    Private Sub FrmInfFacInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbfac.Text = "ARRENDATARIO"
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
                        FrmSelDueño.lbform.Text = "infFacInm"
                        FrmSelDueño.txtclase.Text = "cliente_inm"
                        FrmSelDueño.ShowDialog()
                    Catch ex As Exception
                    End Try
                End If

            Else
                Try
                    txttip.Text = ""
                    FrmSelDueño.Text = "Seleccionar Tercero"
                    FrmSelDueño.lbform.Text = "infFacInm"
                    FrmSelDueño.txtclase.Text = "cliente_inm"
                    FrmSelDueño.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If c2.Checked = True And txttip.Text = "" Then
            MsgBox("Verifique el NIT del tercero", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        pdf()
    End Sub
    Private Sub pdf()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim cad As String = ""
        Dim nomt As String = ""
        Dim f1, f2 As String
        f1 = Strings.Right(fecha1.Text, 4) & "-" & Strings.Mid(fecha1.Text, 4, 2) & "-" & Strings.Left(fecha1.Text, 2)
        f2 = Strings.Right(fecha2.Text, 4) & "-" & Strings.Mid(fecha2.Text, 4, 2) & "-" & Strings.Left(fecha2.Text, 2)

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "N.I.T: " & tabla2.Rows(0).Item("nit")

        MiConexion(bda)
        If c2.Checked = True Then
            cad = cad & " AND nitc ='" & txttip.Text & "'"
        End If

        If cbfac.Text = "ARRENDATARIO" Then
            nomt = "cobdpen"
        Else
            nomt = "ctas_x_pagar"
        End If

        sql = " SELECT doc, fecha, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS ctaret, concepto, total, (total- pagado) pagado, descrip, nitc, nomnit " _
        & " FROM " & nomt & " WHERE tipafec='CNT' " & cad & " AND fecha BETWEEN '" & f1 & "' AND '" & f2 & "' ORDER BY nitc, fecha "

        Dim ta As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfFacInm.rpt")
        CrReport.SetDataSource(ta)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            prtt.Name = "tt"
            prtt.CurrentValues.AddValue("FACTURAS DE " & cbfac.Text)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(prtt)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()
        Catch ex As Exception
        End Try

        Cerrar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'llenar tabla factu inmob
        MiConexion(bda)
        Dim con, f, p As String
        con = " SELECT cast(MID(c.fecha,6,2) as char(5)) AS p, c.doc,c.num, c.tipo, c.fecha, c.descrip, ct.cod_inm, ct.nit_a, ct.nomb_arr, ct.nit_d, c.nomnit," _
        & " c.pagare, (cb.subtotal+cb.v_viva) AS valor, c.total as totalp, c.retiva, cb.total,(cb.total-(cb.subtotal+cb.v_viva)) AS otAr, " _
        & " ct.por_comi, c.descto, ct.por_iva,c.v_viva, c.concepto,'AP' as est,'' AS anul,c.vmto " _
        & " FROM ctas_x_pagar c, contrato_inm ct, cobdpen cb  " _
        & " WHERE c.tipafec='CNT' AND ct.cod_contra=c.descrip AND cb.doc= c.doc "
        Dim ti As New DataTable
        myCommand.CommandText = con
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ti)
        For i = 0 To ti.Rows.Count - 1

            f = " '" & Strings.Right(ti.Rows(i).Item("fecha"), 4) & Strings.Mid(ti.Rows(i).Item("fecha"), 4, 2) & Strings.Left(ti.Rows(i).Item("fecha"), 2) & "'   "
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "  Insert INTO facturainm" & ti.Rows(i).Item("p") & " Values ('" & ti.Rows(i).Item("doc") & "'," & ti.Rows(i).Item("num") & ",'" & ti.Rows(i).Item("tipo") & "', " _
                & " " & f & ",'" & ti.Rows(i).Item("descrip") & "','" & ti.Rows(i).Item("cod_inm") & "','" & ti.Rows(i).Item("nit_a") & "','" & ti.Rows(i).Item("nomb_arr") & "' " _
                & " ,'" & ti.Rows(i).Item("nit_d") & "','" & ti.Rows(i).Item("nomnit") & "'," & ti.Rows(i).Item("pagare") & "," & DIN(ti.Rows(i).Item("valor")) & "," & DIN(ti.Rows(i).Item("totalp")) & ", " _
                & " " & DIN(ti.Rows(i).Item("retiva")) & "," & DIN(ti.Rows(i).Item("total")) & "," & DIN(ti.Rows(i).Item("otAr")) & " " _
                & " ," & DIN(ti.Rows(i).Item("por_comi")) & " ," & DIN(ti.Rows(i).Item("descto")) & ",'" & DIN(ti.Rows(i).Item("por_iva")) & "'," & DIN(ti.Rows(i).Item("v_viva")) & ", " _
                & " '" & ti.Rows(i).Item("concepto") & "','" & ti.Rows(i).Item("est") & "',''," & ti.Rows(i).Item("vmto") & " )"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            Try ' AJUSTE % COMISION
                myCommand.CommandText = "UPDATE facturainm" & ti.Rows(i).Item("p") & " SET por_comi= IFNULL((SELECT  REPLACE(CAST(MID(descri,10,4) AS CHAR(10)),',','.') AS por FROM documentos" & ti.Rows(i).Item("p") & " WHERE doc='" & ti.Rows(i).Item("num") & "' and tipodoc='" & ti.Rows(i).Item("tipo") & "' AND item=3 LIMIT 1),0) WHERE num='" & ti.Rows(i).Item("num") & "' and tipodoc='" & ti.Rows(i).Item("tipo") & "' "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
        MsgBox("facturas agregadas.. ok")

        MsgBox("Ajuste de valores...")
        For i = 1 To 12
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            Dim t2 As New DataTable
            myCommand.CommandText = "SELECT '" & p & "' AS p, doc, num, tipodoc,  iva, vcomi FROM facturainm" & p & " WHERE (iva=0 AND por_iva<>0) OR (vcomi=0 AND por_comi<>0) order by doc"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t2)
            If t2.Rows.Count > 0 Then
                For j = 0 To t2.Rows.Count - 1
                    Try ' AJUSTE valor del IVA
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "UPDATE facturainm" & t2.Rows(j).Item("p") & " SET iva= IFNULL((SELECT  credito FROM documentos" & p & " WHERE doc='" & t2.Rows(j).Item("num") & "' and tipodoc='" & t2.Rows(j).Item("tipodoc") & "' AND item=2 LIMIT 1),0) WHERE doc='" & t2.Rows(j).Item("doc") & "'  "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    Try ' AJUSTE valor COMISION
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "UPDATE facturainm" & t2.Rows(j).Item("p") & " SET vcomi= IFNULL((SELECT  credito FROM documentos" & p & " WHERE doc='" & t2.Rows(j).Item("num") & "' and tipodoc='" & t2.Rows(j).Item("tipodoc") & "' AND item=3 LIMIT 1),0) WHERE doc='" & t2.Rows(j).Item("doc") & "'  "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Next
            End If
        Next
        MsgBox(" Fin Ajuste de valores...")

        Cerrar()
    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged

    End Sub
End Class