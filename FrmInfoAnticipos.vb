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
Public Class FrmInfoAnticipos

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try

       

            Dim tab As String = ""
            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""
            Dim p As String = ""
            Dim ter As String = ""


            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT " & tabla2.Rows(0).Item("nit")

            If cbInf.Text = "PROVEEDOR" Then
                tab = "ant_a_prov"
            Else
                tab = "ant_de_clie"
            End If

            If c2.Checked = True Then
                If txtnom.Text = "" Then
                    MsgBox("Verifique datos del tercero.", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                ter = " WHERE p1 = '" & txttip.Text & "'"
            End If

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            ' ............... ANTICIPOS CAUSADOS
            If rbac.Checked = True Then



                sql = " SELECT p1, nomart as nom, CONCAT(p1,' ',nomart) as nomart, p2, p3,precio,p4,pp,cos_uni,cos_pro,fecha,fecCau,cue_dev FROM ( "

                For i = 1 To 1
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If i <> 1 Then
                        sql = sql & " SELECT a.per_doc AS p2, f.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha," _
                    & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3, " _
                    & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro,f.fecha AS fecCau, " _
                    & " CAST( (CONCAT( RIGHT( f.fecha , 2 ) ,  '/', MID(f.fecha ,  6, 2 ) ,  '/', LEFT( f.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                    & " CASE a.per_doc " _
                    & " WHEN f.doc1 THEN v1 " _
                    & " WHEN f.doc2 THEN v2 " _
                    & " WHEN f.doc3 THEN v3 " _
                    & " END AS pp " _
                    & " FROM fact_comp" & p & " f, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                    & " AND doc1 = a.per_doc Or doc2 = a.per_doc Or doc3 = a.per_doc  UNION " _
                    & "" _
                    & " SELECT a.per_doc AS p2, d.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha," _
                    & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3," _
                    & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro, d.fecha AS fecCau, " _
                    & " CAST( (CONCAT( RIGHT( d.fecha , 2 ) ,  '/', MID(d.fecha ,  6, 2 ) ,  '/', LEFT( d.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                    & " d.total AS pp " _
                    & " FROM ot_doc" & p & " d, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                    & " AND d.cod_contra = a.per_doc  UNION " _
                    & "" _
                    & " SELECT a.per_doc AS p2, cp.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha, " _
                    & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3, " _
                    & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro, cp.fecha AS fecCau, " _
                    & " CAST( (CONCAT( RIGHT( cp.fecha , 2 ) ,  '/', MID(cp.fecha ,  6, 2 ) ,  '/', LEFT( cp.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                    & " cp.total AS pp " _
                    & " FROM ot_cpp" & p & " cp, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                    & " AND cp.doc_anti = a.per_doc  UNION "

                    Else
                        sql = sql & " SELECT a.per_doc AS p2, f.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha," _
                     & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3, " _
                     & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro,f.fecha AS fecCau, " _
                     & " CAST( (CONCAT( RIGHT( f.fecha , 2 ) ,  '/', MID(f.fecha ,  6, 2 ) ,  '/', LEFT( f.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                     & " CASE a.per_doc " _
                     & " WHEN f.doc1 THEN v1 " _
                     & " WHEN f.doc2 THEN v2 " _
                     & " WHEN f.doc3 THEN v3 " _
                     & " END AS pp " _
                     & " FROM fact_comp" & p & " f, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                     & " AND doc1 = a.per_doc Or doc2 = a.per_doc Or doc3 = a.per_doc UNION " _
                     & "" _
                    & " SELECT a.per_doc AS p2, d.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha," _
                    & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3," _
                    & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro, d.fecha AS fecCau, " _
                    & " CAST( (CONCAT( RIGHT( d.fecha , 2 ) ,  '/', MID(d.fecha ,  6, 2 ) ,  '/', LEFT( d.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                    & " d.total AS pp " _
                    & " FROM ot_doc" & p & " d, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                    & " AND d.cod_contra = a.per_doc  UNION" _
                    & "" _
                    & " SELECT a.per_doc AS p2, cp.doc AS p4, a.nitc AS p1, TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart,a.fecha, " _
                    & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3, " _
                    & " a.monto AS precio, a.causado AS cos_uni, (a.monto-a.causado) AS cos_pro, cp.fecha AS fecCau, " _
                    & " CAST( (CONCAT( RIGHT( cp.fecha , 2 ) ,  '/', MID(cp.fecha ,  6, 2 ) ,  '/', LEFT( cp.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS cue_dev, " _
                    & " cp.total AS pp " _
                    & " FROM ot_cpp" & p & " cp, " & tab & " a ,terceros t WHERE t.nit= a.nitc " _
                    & " AND cp.doc_anti = a.per_doc  "
                    End If
                Next

                sql = sql & " ) AS c " & ter & " ORDER BY nom, fecha, fecCau"


                Dim tabla As DataTable
                tabla = New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Ranticipos\ReportAnticip.rpt")
                CrReport.SetDataSource(tabla)
                Try
                    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                Catch ex As Exception
                End Try
                FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nit.ToString)

                    Prtt.Name = "grupo"
                    Prtt.CurrentValues.AddValue(cbInf.Text.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prtt)

                    FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportTributario.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                '.................. TODOS LOS ANTICIPOS


                sql = "SELECT a.nitc AS p1, a.per_doc AS p2, CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS p3," _
                & " TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomart, a.monto AS precio, a.causado AS pp, (a.monto - a.`causado`) AS cos_pro " _
                & " FROM terceros t, " & tab & " a " _
                & " WHERE a.nitc = t.nit " & ter & "  " _
                & " ORDER BY nomart, a.fecha"

                Dim tabla As DataTable
                tabla = New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Ranticipos\ReportAncipT.rpt")
                CrReport.SetDataSource(tabla)
                Try
                    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                Catch ex As Exception
                End Try
                FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prtt As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                    PrNit.Name = "nitc"
                    PrNit.CurrentValues.AddValue(nit.ToString)

                    Prtt.Name = "grupo"
                    Prtt.CurrentValues.AddValue(cbInf.Text.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prtt)

                    FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportTributario.ShowDialog()
                Catch ex As Exception
                End Try

            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox("Error al Generar el Informe ", MsgBoxStyle.Information, "Error")
        End Try
    End Sub

    Private Sub FrmInfoAnticipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbInf.Text = "PROVEEDOR"

        ' CARGAR CLIENTES
        ' AUTOCOMPLETAR NIT CLIENTE
        Try
            txtnom.AutoCompleteCustomSource.Clear()

            Dim tb As New DataTable
            tb.Clear()
            myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                For i = 0 To tb.Rows.Count - 1
                    txtnom.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            chcli.Visible = True
            chcli.Checked = False
        Else
            txttip.Enabled = False
            chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub

    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txttip.Enabled = False
            txtnom.Enabled = True
        Else
            txtnom.Enabled = False
            txttip.Enabled = True
        End If
    End Sub

    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        ValidarNIT(txttip, e)
    End Sub

    
    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try
            'If txttip.Text <> "" Then
            '    FrmSelCliente.lbform.Text = "inf_antic"
            '    FrmSelCliente.ShowDialog()
            'End If
            If txtnom.Text = "" Then
                txttip.Text = ""
                cargarclientes()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmSelCliente.lbform.Text = "inf_antic"
        FrmSelCliente.ShowDialog()
    End Sub

    Private Sub txtnom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnom.LostFocus
        Try
            If txtnom.Text = "" Then
                txttip.Text = ""
                FrmSelCliente.lbform.Text = "inf_antic"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtnom.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(nombre,' ',apellidos)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txttip.Text = ""
            FrmSelCliente.lbform.Text = "inf_antic"
            FrmSelCliente.ShowDialog()
        Else
            txttip.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub

    
    Private Sub txttip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtnom.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtnom.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "inf_antic"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbInf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbInf.SelectedIndexChanged
        If cbInf.SelectedIndex = 0 Then
            c1.Text = "Todos los proveedores"
            c2.Text = "Un Proveedor"
            chcli.Text = "Buscar Proveedor por Apellido"
            lb.Text = "* Doble click para seleccionar el Proveedor"
        Else
            c1.Text = "Todos los clientes"
            c2.Text = "Un Cliente"
            chcli.Text = "Buscar Cliente por Apellido"
            lb.Text = "* Doble click para seleccionar el Cliente"
        End If
    End Sub
End Class