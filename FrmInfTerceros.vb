Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class FrmInfTerceros

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub r2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r2.CheckedChanged
        If r2.Checked = True Then
            cmbtipo.Enabled = True
        Else
            cmbtipo.Enabled = False
        End If
    End Sub

    Private Sub cmdpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpdf.Click
        MiConexion(bda)

        If r2.Checked = True And cmbtipo.Text = "" Then
            MsgBox("Verifique el tipo de tercero para visualizar en el informe", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If r3.Checked = False Then
            PDFTerceros()
        Else
            PDFTerCompleto()
        End If

        Cerrar()
    End Sub
    Private Sub PDFTerCompleto()

        MiConexion(bda)
        Try

            Dim nom As String = ""
            Dim nit As String = ""
            Dim sql As String = ""
            Dim cad As String = ""
           

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")

          

            sql = " SELECT CONCAT(t.nit,'-',t.dv) AS nit ,  TRIM(CONCAT(t.apellidos,' ',t.`nombre`)) AS nombre,t.tipo, t.dir, t.correo,  " _
            & " TRIM(CONCAT(t.telefono,'-',t.celular)) AS apellidos, CONCAT(t.dia,' ',t.mes) AS telefono, m.descripcion AS persona, t.web,  " _
            & " t.cta_banco1, t.cbanco " _
            & " FROM terceros t, sae.mun m   WHERE m.`coddep`= t.`dept` AND m.`codmun`= t.`mun`  ORDER BY nombre "


            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTercCom.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

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

                FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportTributario.ShowDialog()

            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
    Private Sub PDFTerceros()
        Try

            Dim nom As String = ""
            Dim nit As String = ""
            Dim sql As String = ""
            Dim cad As String = ""
            If r2.Checked = True Then
                cad = " and t.tipo='" & cmbtipo.Text & "'"
            End If

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " SELECT CONCAT(t.nit,'-',t.dv) AS nit ,  TRIM(CONCAT(t.apellidos,' ',t.`nombre`)) AS nombre,t.tipo, t.dir, t.correo, " _
            & " TRIM(CONCAT(t.telefono,'-',t.celular)) AS apellidos, CONCAT(t.dia,t.mes), m.descripcion AS web " _
            & " FROM terceros t, sae.mun m  " _
            & " WHERE m.`coddep`= t.`dept` AND m.`codmun`= t.`mun` " & cad & " " _
            & " ORDER BY nombre "

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTerceros.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

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

                FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportTributario.ShowDialog()

            Catch ex As Exception
            End Try
            conexion.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class