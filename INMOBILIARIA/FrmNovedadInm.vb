Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmNovedadInm

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmNovedadInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        bloquear()
    End Sub

    Private Sub limpiar()
        txtestado.Text = ""
        txtf1.Value = CDate(Strings.Left(PerActual, 2) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
        txtinm.Text = ""
        txtnita.Text = ""
        txtnoma.Text = ""
        txtnov.Text = ""
        lbestado.Text = ""
        Lbnov.Text = ""
        txtnitv.Text = ""
        txtnomv.Text = ""
        txtnitp.Text = ""
        txtnomp.Text = ""
        txtvalor.Text = Moneda(0)
        lbanulado.Text = ""
        lbdoc.Text = ""
        lbper.Text = ""
    End Sub
    Private Sub desbloquear()
        ' act guardar
        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        cmdProc.Enabled = False
        CmdMostrar.Enabled = False
        cmdPrint.Enabled = False
        txtnita.ReadOnly = True
        txtnitv.Enabled = True
        txtf1.Enabled = True
        txtinm.Enabled = True
        txtnita.Enabled = True
        txtnov.Enabled = True
        txtvalor.Enabled = True
    End Sub
    Private Sub bloquear()
        ' act guardar
        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdProc.Enabled = True
        CmdMostrar.Enabled = True
        cmdPrint.Enabled = True
        txtnita.Enabled = True


        txtnitv.Enabled = False
        txtf1.Enabled = False
        txtinm.Enabled = False
        txtnita.Enabled = False
        txtnov.Enabled = False
        txtvalor.Enabled = False
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        desbloquear()
        txtestado.Text = "PENDIENTE"
        lbestado.Text = "NUEVO"
        txtf1.Focus()
        MiConexion(bda)
        NumNov()
        Cerrar()
    End Sub
    Private Sub NumNov()
        Try
            Lbnov.Text = ""
            Dim tn As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT max(ndoc) FROM inm_novdad  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tn)
            Refresh()
            Lbnov.Text = NumeroDoc(tn.Rows(0).Item(0) + 1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        limpiar()
        bloquear()
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("Seleccione la novedad a modificar", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        ElseIf lbestado.Text = "CONSULTA" And txtestado.Text <> "PENDIENTE" Then
            MsgBox("El estado CUMPLIDO no permite esta acción ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        Else
            lbestado.Text = "EDITAR"
            desbloquear()
        End If
    End Sub

    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
        Try

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inmuebles WHERE estado<>'INACTIVO' and codigo='" & txtinm.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txtinm.Text = ""
                Try
                    FrmSelInmueble.lbform.Text = "InmNov"
                    FrmSelInmueble.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                txtinm.Text = tabla.Rows(0).Item("codigo")
            End If
            If txtinm.Text <> "" Then
                BusArre()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BusArre()
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM contrato_inm WHERE cod_inm ='" & txtinm.Text & "' AND mes_total > mes_fact ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            MsgBox("No exiten clientes asociados a este inmueble", MsgBoxStyle.Information, "Verificación")
            txtnita.Enabled = True
            txtnita.Text = "0"
            txtnoma.Text = "[  SIN NIT  ]"
            txtnita.ReadOnly = False
        Else
            txtnita.Text = tabla.Rows(0).Item("nit_a")
            txtnoma.Text = tabla.Rows(0).Item("nomb_arr")
        End If

        Dim td As New DataTable
        td.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT i.nitp, trim(concat(t.nombre,' ',t.apellidos)) as nom FROM inmuebles i, terceros t WHERE i.nitp = t.nit and i.codigo='" & txtinm.Text & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        Refresh()
        If td.Rows.Count = 0 Then
            txtnitp.Text = ""
            txtnomp.Text = ""
        Else
            txtnitp.Text = td.Rows(0).Item("nitp")
            txtnomp.Text = td.Rows(0).Item("nom")
        End If


    End Sub
    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitv.KeyPress
        ValidarNIT(txtnitv, e)
    End Sub

    Private Sub txtnitv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtnomv.Text = ""
            txtnitv.Text = ""
            cargarvendedor()
        Else  'mostrar uno solo q coinside
            txtnomv.Text = tabla.Rows(0).Item(1)
        End If
    End Sub
    Private Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = "novedades"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If txtinm.Text = "" Then
            MsgBox("Digite el codigo del Inmueble ", MsgBoxStyle.Information, "Verificación")
            txtinm.Focus()
            Exit Sub
        End If
        If txtnitp.Text = "" Then
            MsgBox("Verifique el Propietario del inmueble ", MsgBoxStyle.Information, "Verificación")
            txtnitp.Focus()
            Exit Sub
        End If
        If txtnita.Text = "" Then
            MsgBox("Verifique el Arrendatario del inmueble ", MsgBoxStyle.Information, "Verificación")
            txtnita.Focus()
            Exit Sub
        End If
        If txtnov.Text = "" Then
            MsgBox("Describa la Novedad a registrar ", MsgBoxStyle.Information, "Verificación")
            txtnov.Focus()
            Exit Sub
        End If
        If txtnitv.Text = "" Then
            MsgBox("Digite el codigo del vendedor ", MsgBoxStyle.Information, "Verificación")
            txtnitv.Focus()
            Exit Sub
        End If

        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        End If

    End Sub
    Private Sub Guardar()

        Dim resultado As MsgBoxResult
        resultado = MsgBox("¿Desea Registrar esta Novedad?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            Dim t2 As New DataTable
            t2.Clear()
            myCommand.CommandText = "SELECT ndoc FROM inm_novdad where ndoc='" & Lbnov.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t2)
            Refresh()
            If t2.Rows.Count <> 0 Then
                NumNov()
            End If

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?ndoc", Lbnov.Text)
            myCommand.Parameters.AddWithValue("?codinm", txtinm.Text)
            myCommand.Parameters.AddWithValue("?nita", txtnita.Text)
            myCommand.Parameters.AddWithValue("?novedad", txtnov.Text)
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtf1.Text.ToString))
            myCommand.Parameters.AddWithValue("?estado", txtestado.Text)
            myCommand.Parameters.AddWithValue("?proced", "")
            myCommand.Parameters.AddWithValue("?fechp", "0000-00-00")
            myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text)
            myCommand.Parameters.AddWithValue("?nitp", txtnitp.Text)
            myCommand.Parameters.AddWithValue("?perdoc", lbper.Text)
            myCommand.Parameters.AddWithValue("?doc", lbdoc.Text)
            myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))

            myCommand.CommandText = "Insert INTO inm_novdad Values(?ndoc,?codinm, ?nita,?novedad,?fecha,?estado,?proced,?fechp," _
            & " ?nitv,?nitp,?perdoc,?doc,?valor);"
            myCommand.ExecuteNonQuery()
            Refresh()

            Cerrar()
            MsgBox("Novedad registrada Exitosamente", MsgBoxStyle.Information, "SAE")
            limpiar()
            bloquear()
        End If
    End Sub
    Private Sub Modificar()

        Dim resultado As MsgBoxResult
        resultado = MsgBox("¿Desea Modificar la Novedad No " & Lbnov.Text & "?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", Lbnov.Text)
            myCommand.Parameters.AddWithValue("?codinm", txtinm.Text)
            myCommand.Parameters.AddWithValue("?nita", txtnita.Text)
            myCommand.Parameters.AddWithValue("?novedad", txtnov.Text)
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtf1.Text.ToString))
            myCommand.Parameters.AddWithValue("?estado", txtestado.Text)
            myCommand.Parameters.AddWithValue("?proced", "")
            myCommand.Parameters.AddWithValue("?fechp", "0000-00-00")
            myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text)
            myCommand.Parameters.AddWithValue("?nitp", txtnitp.Text)
            myCommand.Parameters.AddWithValue("?doc_cont", lbper.Text & lbdoc.Text)

            myCommand.CommandText = "UPDATE inm_novdad SET codigoinm=?codinm,nita=?nita,novedad=?novedad,fecha=?fecha,nitv=?nitv,nitp=?nitp WHERE ndoc='" & Lbnov.Text & "';"
            myCommand.ExecuteNonQuery()
            Refresh()

            Cerrar()
            MsgBox("Novedad Modificada Exitosamente", MsgBoxStyle.Information, "SAE")
            limpiar()
            bloquear()
        End If
    End Sub

    Private Sub txtinm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.TextChanged
        If txtinm.Text = "" Then
            txtnita.Text = ""
            txtnoma.Text = ""
            txtnitp.Text = ""
            txtnomp.Text = ""
        End If
    End Sub

    Private Sub txtnitv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged
        If txtnitv.Text = "" Then
            txtnomv.Text = ""
        End If
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelNovedad.lbform.Text = "novedad"
        FrmSelNovedad.ShowDialog()
        If Lbnov.Text <> "" Then
            BuscarNovedad()
        End If

    End Sub
    Public Sub BuscarNovedad()
        Try
            MiConexion(bda)

            Dim tn As New DataTable
            tn.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT ndoc,codigoinm,nita,novedad,fecha,estado, nitv, nitp, valor, perdoc, doc FROM inm_novdad WHERE ndoc='" & Lbnov.Text & "'  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tn)
            Refresh()

            txtinm_LostFocus(AcceptButton, AcceptButton)
            txtnov.Text = tn.Rows(0).Item("novedad")
            txtf1.Text = tn.Rows(0).Item("fecha")
            txtestado.Text = tn.Rows(0).Item("estado")
            txtvalor.Text = Moneda(tn.Rows(0).Item("valor"))
            lbper.Text = tn.Rows(0).Item("perdoc")
            lbdoc.Text = tn.Rows(0).Item("doc")
            txtnitv.Text = tn.Rows(0).Item("nitv")
            txtnitv_LostFocus(AcceptButton, AcceptButton)
            Cerrar()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProc.Click

        If lbestado.Text = "CONSULTA" Then
            MiConexion(bda)

            FrmNovedadProce.txtf2.Value = CDate(Strings.Left(PerActual, 2) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
            FrmNovedadProce.txtproc.Text = ""
            Try
                Dim tp As New DataTable
                tp.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT proced, fecha_pro FROM inm_novdad WHERE ndoc='" & Lbnov.Text & "'  ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tp)
                Refresh()

                FrmNovedadProce.txtproc.Text = tp.Rows(0).Item("proced")
                FrmNovedadProce.txtf2.Text = tp.Rows(0).Item("fecha_pro")
            Catch ex As Exception
            End Try

            FrmNovedadProce.Lbnov.Text = Lbnov.Text
            If txtestado.Text = "CUMPLIDO" Then
                FrmNovedadProce.txtproc.Enabled = False
                FrmNovedadProce.txtf2.Enabled = False
                FrmNovedadProce.ButtonG.Enabled = False
            Else
                FrmNovedadProce.txtproc.Enabled = True
                FrmNovedadProce.txtf2.Enabled = True
                FrmNovedadProce.ButtonG.Enabled = True

            End If
            FrmNovedadProce.ShowDialog()
            Cerrar()
        Else
            MsgBox("Verifique el numero la Novedad", MsgBoxStyle.Information, "Verificación")
        End If

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        If Lbnov.Text <> "" Then

            Dim nom As String = ""
            Dim nitc As String = ""
            Dim tel As String = ""
            Dim dir As String = ""


            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nitc = "NIT: " & tabla2.Rows(0).Item("nit")
            dir = "DIRECCION: " & tabla2.Rows(0).Item("direccion")
            tel = "TELEFONO: " & tabla2.Rows(0).Item("telefono1") & "   " & tabla2.Rows(0).Item("telefono2")


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim sql As String = ""


            sql = "SELECT cast(i.codigo as char(10)) AS cta_desc, TRIM(CONCAT(i.direccion,' ',i.`barrio`)) AS d1, n.proced AS observ," _
             & " CAST(CONCAT( RIGHT(n.fecha_pro, 2), '/', MID(n.fecha_pro, 6, 2), '/',LEFT(n.fecha_pro, 4) ) AS CHAR(20)) AS cta_iva" _
             & " FROM inmuebles i, inm_novdad n  " _
             & " WHERE i.codigo='" & txtinm.Text & "' AND n.ndoc='" & Lbnov.Text & "' AND i.codigo= n.codigoinm "


            Dim tabla As New DataSet
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT logo as logofac FROM parcontrato"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "parafacts")

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "facturas01")

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportNovedad.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            'Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtel As New ParameterField
            Dim Prdir As New ParameterField
            Dim Prnov As New ParameterField
            Dim Prvend As New ParameterField
            Dim Prpro As New ParameterField
            Dim Prarr As New ParameterField
            Dim Prfec As New ParameterField
            Dim Prest As New ParameterField
            Dim Prdesn As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitc.ToString)
            Prtel.Name = "telf"
            Prtel.CurrentValues.AddValue(tel.ToString)
            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue(dir.ToString)

            Prnov.Name = "nov"
            Prnov.CurrentValues.AddValue(lbnov1.Text.ToString & Lbnov.Text.ToString)
            Prvend.Name = "vend"
            Prvend.CurrentValues.AddValue(txtnitv.Text.ToString & " - " & txtnomv.Text.ToString)
            Prpro.Name = "prop"
            Prpro.CurrentValues.AddValue(txtnitp.Text.ToString & " - " & txtnomp.Text.ToString)
            Prarr.Name = "arr"
            Prarr.CurrentValues.AddValue(txtnita.Text.ToString & " - " & txtnoma.Text.ToString)
            Prfec.Name = "fecn"
            Prfec.CurrentValues.AddValue(txtf1.Text.ToString)
            Prest.Name = "est"
            Prest.CurrentValues.AddValue(txtestado.Text.ToString)
            Prdesn.Name = "desn"
            Prdesn.CurrentValues.AddValue(txtnov.Text.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            prmdatos.Add(Prnov)
            prmdatos.Add(Prvend)
            prmdatos.Add(Prpro)
            prmdatos.Add(Prarr)
            prmdatos.Add(Prfec)
            prmdatos.Add(Prest)
            prmdatos.Add(Prdesn)


            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

            'Catch ex As Exception
            'End Try

            conexion.Close()
        Else
            MsgBox("Verifique el numero la Novedad", MsgBoxStyle.Information, "Verificación")

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'FrmComEgresoCpp.ShowDialog()
        If txtnita.Text <> "" And txtvalor.Text <> Moneda(0) Then

            If lbestado.Text = "NUEVO" Then
                FrmComEgresoCpp.CmdNuevo_Click(AcceptButton, AcceptButton)

                FrmComEgresoCpp.txtvalor.Text = Moneda(txtvalor.Text)
                FrmComEgresoCpp.rbcc.Checked = True
                FrmComEgresoCpp.txtnit.Text = txtnitp.Text
                FrmComEgresoCpp.BuscarClientes(txtnitp.Text)
                FrmComEgresoCpp.txtconcepto.Text = txtnov.Text
                FrmComEgresoCpp.ps = "ps"
                FrmComEgresoCpp.grilla.RowCount = 3

                '....
                FrmComEgresoCpp.ChAnti.Checked = True
                Dim tc As New DataTable
                tc.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo IN('133005001','110505001') ORDER BY descripcion "
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                Refresh()
                If tc.Rows.Count > 0 Then
                    ' CAJA
                    FrmComEgresoCpp.grilla.Item("Cuenta", 0).Value = "110505001"
                    FrmComEgresoCpp.grilla.Item("Descripcion", 0).Value = tc.Rows(1).Item(0)
                    FrmComEgresoCpp.grilla.Item("Debitos", 0).Value = Moneda(0)
                    FrmComEgresoCpp.grilla.Item("Creditos", 0).Value = Moneda(txtvalor.Text)
                    FrmComEgresoCpp.grilla.Item("Base", 0).Value = Moneda(0)
                    FrmComEgresoCpp.grilla.Item("cc", 0).Value = ""
                    ' NACIONAL
                    FrmComEgresoCpp.grilla.Item("Cuenta", 1).Value = "133005001"
                    FrmComEgresoCpp.grilla.Item("Descripcion", 1).Value = tc.Rows(0).Item(0)
                    FrmComEgresoCpp.grilla.Item("Debitos", 1).Value = Moneda(txtvalor.Text)
                    FrmComEgresoCpp.grilla.Item("Creditos", 1).Value = Moneda(0)
                    FrmComEgresoCpp.grilla.Item("Base", 1).Value = Moneda(0)
                    FrmComEgresoCpp.grilla.Item("cc", 1).Value = ""
                End If

                FrmComEgresoCpp.lbestado.Text = "NUEVO"
                FrmComEgresoCpp.ShowDialog()
                If FrmComEgresoCpp.lbestado.Text = "NUEVO" Then
                    FrmComEgresoCpp.CmdCancelar_Click(AcceptButton, AcceptButton)
                ElseIf FrmComEgresoCpp.lbestado.Text = "GUARDADO" Or FrmComEgresoCpp.lbestado.Text = "EDITADO" Then
                    lbper.Text = FrmComEgresoCpp.lbper.Text
                    lbdoc.Text = FrmComEgresoCpp.lbdoc.Text & FrmComEgresoCpp.txtnumero.Text
                End If
            ElseIf lbestado.Text = "ELIMINAR" Then
                FrmComEgresoCpp.ps = "ps"
                FrmComEgresoCpp.lbdoc.Text = Strings.Left(lbdoc.Text, 2)
                FrmComEgresoCpp.txtnumero.Text = Strings.Right(lbdoc.Text, Strings.Len(lbdoc.Text) - 2)
                FrmComEgresoCpp.BuscarDocumento(lbdoc.Text)
                FrmComEgresoCpp.ShowDialog()
            ElseIf lbestado.Text = "CONSULTA" Then
                If lbper.Text <> FrmPrincipal.LbPeriodo.Text & " - " Then
                    MsgBox("El documento no puede ser visualizado, No corresponde al periodo actual", MsgBoxStyle.Information, "Verifique")
                Else
                    FrmComEgresoCpp.ps = "ps"
                    FrmComEgresoCpp.lbdoc.Text = Strings.Left(lbdoc.Text, 2)
                    FrmComEgresoCpp.txtnumero.Text = Strings.Right(lbdoc.Text, Strings.Len(lbdoc.Text) - 2)
                    FrmComEgresoCpp.BuscarDocumento(lbdoc.Text)
                    FrmComEgresoCpp.ShowDialog()
                End If
            End If
        Else
            MsgBox("Datos incompletos , Verifique los valores", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub

    Private Sub txtnita_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.DoubleClick
        If txtinm.Text <> "" Then
            'If txtnita.Text = "" Then
            '    If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            '    txtnoma.Text = ""
            '    cargarclientes()
            'Else
            '    BuscarClientes(txtnita.Text)
            'End If

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='ARRENDATARIO'  and tr.nit = '" & txtnita.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txtnita.Text = ""
                txtnoma.Text = ""
                Try
                    FrmSelDueño.Text = "Seleccionar Arrendatario"
                    FrmSelDueño.lbform.Text = "nv_inm"
                    FrmSelDueño.txtclase.Text = "ARRENDATARIO"
                    FrmSelDueño.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                txtnita.Text = tabla.Rows(0).Item("nit")
                txtnoma.Text = tabla.Rows(0).Item("nom")
            End If

        End If
    End Sub

    Private Sub txtnita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.LostFocus
        If txtnita.Text = "" Then
            txtnoma.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nit,TRIM(CONCAT(apellidos,' ',nombre))AS ter FROM terceros ORDER BY ter;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("ter")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "nv_inm"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <> 0 Then
            txtnoma.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        MiConexion(bda)

        If txtinm.Text = "" And Lbnov.Text = "" Then
            MsgBox("Verifique el codigo del Inmueble o el numero de la Novedad ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If

        If lbdoc.Text <> "" Then
            If Strings.Left(PerActual, 2) <> Strings.Left(lbper.Text, 2) Then
                MsgBox("El documento contable no existe en este periodo, Cambie de Periodo y anulelo para poder Eliminar La Novedad", MsgBoxStyle.Information, "SAE")
                Exit Sub
            End If
        End If

        Dim ta As New DataTable
        ta.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM ot_doc" & Strings.Left(PerActual, 2) & "  WHERE doc ='" & lbdoc.Text & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count > 0 Then
            If Trim(ta.Rows(0).Item("doc_aj")) <> "" Then
                lbanulado.Text = ta.Rows(0).Item("doc_aj")
            Else
                lbanulado.Text = ""
            End If
        End If

        lbestado.Text = "ELIMINAR"
        If lbanulado.Text = "" And lbdoc.Text <> "" Then
            Dim resultado2 As MsgBoxResult
            resultado2 = MsgBox("El documento contable no ha sido anulado, Desea anularlo?", MsgBoxStyle.YesNo, "Verificando")
            If resultado2 = MsgBoxResult.Yes Then
                Button1_Click(AcceptButton, AcceptButton)
                Exit Sub
            Else
                Exit Sub
            End If
        End If


        Try

            Dim resultado As MsgBoxResult
            resultado = MsgBox("La novedad No " & Lbnov.Text & " sera eliminada ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM `inm_novdad` WHERE ndoc='" & Lbnov.Text & "' ;"
                myCommand.ExecuteNonQuery()
                Refresh()

                MsgBox("Novedad Eliminada Satisfactoriamente", MsgBoxStyle.Information, "SAE")
                cmdcancelar_Click(AcceptButton, AcceptButton)
            End If

        Catch ex As Exception
            MsgBox("Error al Eliminar el Eliminar la novedad", MsgBoxStyle.Information, "Error")
        End Try
        Cerrar()
    End Sub
End Class