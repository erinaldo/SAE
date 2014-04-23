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
Public Class FrmInfContratos

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcontrato.Enabled = True
            g2.Enabled = False
            p1.Checked = True
            g3.Enabled = False
            a1.Checked = True
            cbmes.Enabled = False
        Else
            txtcontrato.Enabled = False
            g2.Enabled = True
            g3.Enabled = True
        End If
    End Sub

    Private Sub txtcontrato_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontrato.DoubleClick
        FrmSelContratos.lbform.Text = "inf_contrato"
        FrmSelContratos.ShowDialog()
    End Sub

    Private Sub txtcontrato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontrato.LostFocus
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcontrato.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count = 0 Then
            Try
                txtcontrato.Text = ""
                FrmSelContratos.lbform.Text = "inf_contrato"
                FrmSelContratos.ShowDialog()
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub p2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p2.CheckedChanged
        If p2.Checked = True Then
            txtdueño.Enabled = True
            p1.Checked = False
        Else
            txtdueño.Enabled = False
            p1.Checked = True
        End If
    End Sub

    Private Sub txtdueño_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdueño.DoubleClick
        FrmSelDueño.txtclase.Text = "PROPIETARIO"
        FrmSelDueño.Text = "Seleccionar Propietario del Inmueble"
        FrmSelDueño.lbform.Text = "inf_contrato"
        FrmSelDueño.ShowDialog()
    End Sub

    Private Sub txtdueño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdueño.KeyPress
        ValidarNIT(txtdueño, e)
    End Sub

    Private Sub txtdueño_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdueño.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE  tr.nit = '" & txtdueño.Text & "' and tr.clase ='DUEÑO DE INMUEBLE';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtdueño.Text = ""
            txtnomdu.Text = ""
            Try
                FrmSelDueño.txtclase.Text = "PROPIETARIO"
                FrmSelDueño.Text = "Seleccionar Propietario del Inmueble"
                FrmSelDueño.lbform.Text = "inf_contrato"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtdueño.Text = tabla.Rows(0).Item("nit")
            txtnomdu.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub a2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.CheckedChanged
        If a2.Checked = True Then
            txtarre.Enabled = True
            a1.Checked = False
        Else
            txtarre.Enabled = False
            a1.Checked = True
        End If
    End Sub

    Private Sub txtarre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarre.DoubleClick
        FrmSelDueño.Text = "Seleccionar Arrendatario"
        FrmSelDueño.lbform.Text = "inf_contrato_a"
        FrmSelDueño.ShowDialog()
    End Sub

    Private Sub txtarre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtarre.KeyPress
        ValidarNIT(txtarre, e)
    End Sub

    Private Sub txtarre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarre.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE  tr.nit = '" & txtarre.Text & "' and tr.clase ='ARRENDATARIO';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtarre.Text = ""
            txtnomarr.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Arrendatario"
                FrmSelDueño.lbform.Text = "inf_contrato_a"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtarre.Text = tabla.Rows(0).Item("nit")
            txtnomarr.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Try

            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = "N.I.T: " & tabla2.Rows(0).Item("nit")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim con As String = ""
            Dim pro As String = ""
            Dim ar As String = ""
            If c2.Checked = True Then
                con = " AND c.cod_contra ='" & txtcontrato.Text & "'"
            End If
            If c3.Checked = True Then
                con = "AND (c.mes_total	- c.mes_fact) = '" & cbmes.Text & "'"
            End If
            If p2.Checked = True Then
                pro = " AND c.nit_d = '" & txtdueño.Text & "'"
            End If
            If a2.Checked = True Then
                ar = " AND c.nit_a = '" & txtarre.Text & "'"
            End If

            '& " ((c.valor *(1+(c.por_comi/100))) * (1+ (c.por_iva/100))) as subtotal, " _

            sql = "SELECT c.cod_contra as doc, concat(c.nit_a, ' ', c.nomb_arr) as nomnit, i.direccion as nitc, c.nit_d as nitcod, concat(t.nombre, ' ',t.apellidos)as concepto, " _
            & " c.por_comi as iva, c.deposito as ret,  cast(concat(right(c.fechaini,2),'/',mid(c.fechaini,6,2),'/',left(c.fechaini,4))AS CHAR(20)) as ctaret,  " _
            & " cast(concat(right(c.fechafin,2),'/',mid(c.fechafin,6,2),'/',left(c.fechafin,4))AS CHAR(20)) as ctaiva, " _
            & " c.valor as subtotal, c.doc_dep as doc_ext, " _
            & " (c.deposito-c.mov_deposito) as total " _
            & " FROM contrato_inm c , terceros t,inmuebles i WHERE c.cod_inm=i.codigo and c.nit_d = t.nit " & con & " " & pro & " " & ar & "" _
            & "ORDER BY concepto"

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfCont.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

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

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)

                FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmVisorInformes.ShowDialog()
            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        If c3.Checked = True Then
            cbmes.Text = "1"
            cbmes.Enabled = True
        Else
            cbmes.Enabled = False
        End If
    End Sub
End Class