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
Public Class FrmInfInmuebles
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
        FrmSelDueño.lbform.Text = "dueños_inf_inm"
        FrmSelDueño.txtclase.Text = "PROPIETARIO"
        FrmSelDueño.ShowDialog()
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE  tr.nit = '" & txttip.Text & "' and tr.clase ='PROPIETARIO';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            txtnom.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
                FrmSelDueño.lbform.Text = "dueños_inf_inm"
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
            
            gr2.Enabled = False
            c1.Checked = True
            gr3.Enabled = False
        Else
            txtinm.Enabled = False

            gr2.Enabled = True
            gr3.Enabled = True
        End If
    End Sub

    Private Sub txtinm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.DoubleClick
        FrmSelInmueble.lbform.Text = "inf_inm"
        FrmSelInmueble.ShowDialog()
    End Sub


    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
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
                FrmSelInmueble.lbform.Text = "inf_inm"
                FrmSelInmueble.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtinm.Text = tabla.Rows(0).Item("codigo")
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If i2.Checked = True Then
            If txtinm.Text = "" Then
                MsgBox("Verifique el codigo del inmueble", MsgBoxStyle.Information, "Verificación")
                Exit Sub
            Else
                FrmInmueble.MostrarInmuebles(txtinm.Text)
            End If
        Else
            TodosInmuebles()
        End If

    End Sub

    Private Sub TodosInmuebles()
        ' Try

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

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim inm As String = ""
        Dim est As String = ""
        Dim due As String = ""

        If i2.Checked = True Then
            inm = inm & " and i.codigo= '" & txtinm.Text & "' "
        End If
        'estado
        If cmbesta.Text <> "TODOS" Then
            inm = inm & " AND i.estado= '" & cmbesta.Text & "' "
        End If
        ' dueño
        If c2.Checked = True Then
            inm = inm & " AND i.nitp = '" & txttip.Text & "'"
        End If
        ' DESCRIPCION
        If txtdesc.Text <> "" Then
            inm = inm & " AND i.descrip LIKE  '%" & txtdesc.Text & "%'"
        End If
        'TIPO
        If cmbTipo.Text <> "TODOS" And (cmbTipo.Text <> "") Then
            inm = inm & " AND i.tipoim='" & cmbTipo.Text & "'"
        End If
        'DESTINO
        If cmbDestino.Text <> "TODOS" And (cmbDestino.Text <> "") Then
            inm = inm & " AND i.destino='" & cmbDestino.Text & "'"
        End If
        'VALOR
        If v2.Checked = True Then
            If P1.Checked = True Then
                inm = " AND i.previvi between " & DIN(r1.Text) & " AND " & DIN(r2.Text)
                due = " i.previvi as subtotal, "
            Else
                inm = " AND i.prelocal between " & DIN(r1.Text) & " AND " & DIN(r2.Text)
                due = " i.prelocal as subtotal, "
            End If
        End If

        '---------------------------------
        ' Orden Diferente a dueño
        If a2.Checked = False Then

            Dim titG As String = ""
            Dim tit As String = ""
            Dim sql2 As String = ""

            If a1.Checked = True Then
                titG = "*** ESTADO "
                tit = "CIUDAD "
                sql2 = " , i.estado  as ctaret, m.descripcion  as doc_ext "
            Else
                tit = "ESTADO "
                titG = "*** CIUDAD "
                sql2 = " ,m.descripcion as ctaret, i.estado  as doc_ext  "
            End If


            sql = "SELECT i.codigo as doc, i.nitp as nitc, concat(t.nombre,' ',t.apellidos)as nomnit, i.previvi as subtotal, i.prelocal as ret, " _
            & " i.direccion as descrip, i.destino AS ctasubtotal, tipoim as concepto " & sql2 & " from inmuebles i, terceros t, " _
            & " sae.mun m where i.nitp=t.nit AND m.codmun=i.ciudad AND m.coddep= i.dpto " & inm & "  order by ctaret "

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInfInmu.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim PrTg As New ParameterField
                Dim PrTt As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                PrTg.Name = "titG"
                PrTg.CurrentValues.AddValue(titG.ToString)

                PrTt.Name = "tit"
                PrTt.CurrentValues.AddValue(tit.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(PrTg)
                prmdatos.Add(PrTt)

                FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmVisorInformes.ShowDialog()
            Catch ex As Exception
            End Try

        Else

            sql = "SELECT i.codigo as doc, i.nitp as nitc, concat(t.nombre,' ',t.apellidos)as nomnit, i.direccion as concepto, " _
            & " i.previvi as subtotal, i.prelocal as ret, " _
            & " i.estado as doc_ext, m.descripcion as descrip from inmuebles i, terceros t, sae.mun m " _
            & " where i.nitp=t.nit and  m.codmun=i.ciudad AND m.coddep= i.dpto " & inm & " " _
            & " order by nomnit, doc "

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInmPro.rpt")
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

        End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub FrmInfInmuebles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbesta.Text = "TODOS"

        Dim tablas As New DataTable
        tablas.Clear()
        myCommand.CommandText = "SELECT * FROM inm_tipo ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablas)
        Refresh()
        cmbTipo.Items.Clear()
        cmbTipo.Items.Add("TODOS")
        If tablas.Rows.Count <> 0 Then
            For i = 0 To tablas.Rows.Count - 1
                cmbTipo.Items.Add(tablas.Rows(i).Item("tipo"))
            Next
            cmbTipo.Text = cmbTipo.Items(0).ToString
        End If
    End Sub

    Private Sub v2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v2.CheckedChanged
        If v2.Checked = True Then
            GrVal.Visible = True
        Else
            GrVal.Visible = False
        End If
    End Sub

    Private Sub r1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles r1.LostFocus
        Try
            r1.Text = Moneda(r1.Text)
        Catch ex As Exception
            r1.Text = Moneda(0)
        End Try
    End Sub

    Private Sub r2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles r2.LostFocus
        Try
            r2.Text = Moneda(r2.Text)
        Catch ex As Exception
            r2.Text = Moneda(0)
        End Try
    End Sub
End Class