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
Public Class FrmInfPagoServ

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            txtnom.Enabled = True
        Else
            txttip.Enabled = False
            txtnom.Enabled = False
        End If
    End Sub
    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub
    Private Sub txttip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.DoubleClick
        FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
        FrmSelDueño.lbform.Text = "dueños_inf_pago"
        FrmSelDueño.txtclase.Text = "PROPIETARIO"
        FrmSelDueño.ShowDialog()
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr , terceros t  WHERE  tr.nit = '" & txttip.Text & "' and tr.clase ='PROPIETARIO' AND t.nit=tr.nit;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            txtnom.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
                FrmSelDueño.lbform.Text = "dueños_inf_pago"
                FrmSelDueño.txtclase.Text = "PROPIETARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txttip.Text = tabla.Rows(0).Item("nit")
            txtnom.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub
    Private Sub i2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i2.CheckedChanged
        If i2.Checked = True Then
            txtinm.Enabled = True
        Else
            txtinm.Enabled = False
        End If
    End Sub
    Private Sub txtinm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.DoubleClick
        Try
            FrmSelInmueble.lbform.Text = "inf_PSe"
            FrmSelInmueble.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus

        If txtinm.Text = "" Then
            txtinm_DoubleClick(AcceptButton, AcceptButton)
        Else
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inmuebles  WHERE  codigo = '" & txtinm.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txtinm.Text = ""
                Try
                    FrmSelInmueble.lbform.Text = "inf_PSe"
                    FrmSelInmueble.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                txtinm.Text = tabla.Rows(0).Item("codigo")
            End If
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try

        
            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""
            Dim desc As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = "N.I.T: " & tabla2.Rows(0).Item("nit")



            Dim cons As String = ""
            If i2.Checked = True Then
                If txtinm.Text = "" Then
                    MsgBox("Verifique el codigo del inmueble", MsgBoxStyle.Information, "Verificación")
                    Exit Sub
                End If
                cons = cons & " and i.codigo= '" & txtinm.Text & "' "
            End If
            If c2.Checked = True Then
                If txtinm.Text = "" Then
                    MsgBox("Verifique el nit del propietario", MsgBoxStyle.Information, "Verificación")
                    Exit Sub
                End If
                cons = cons & " AND i.nitp = '" & txttip.Text & "'"
            End If

            sql = "SELECT s.`codigo_inm` AS doc, TRIM(CONCAT(i.nitp,' - ',t.`nombre`, ' ', t.`apellidos`)) AS concepto, " _
            & " TRIM(CONCAT(i.`direccion`,'  BARRIO:',i.barrio))AS nomnit,  " _
            & " s.`servicio` AS descrip,s.`mes` AS nitcod, s.fecha," _
            & " CAST( CONCAT( RIGHT(  s.fecha, 2 ) ,  '/', MID( s.fecha, 6, 2 ) ,  '/', LEFT( s.fecha, 4 ) ) AS CHAR(15))  AS nitc, s.`valor` as subtotal" _
            & " FROM inm_servpagos s, inmuebles i, terceros t " _
            & " WHERE i.`codigo`= s.`codigo_inm` AND i.`nitp`= t.`nit` " & cons & " " _
            & " ORDER BY doc, fecha "

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfPagServ.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField

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

            conexion.Close()
        Catch ex As Exception
            MsgBox("Error al Generar el Informe", MsgBoxStyle.Information, "Error")
        End Try
    End Sub
End Class