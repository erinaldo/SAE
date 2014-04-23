Public Class FrmPagosServicios
    Dim dd As String
    'Dim dc As String

    Private Sub FrmPagosServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtf1.Value = CDate(Strings.Left(PerActual, 2) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
        limpiar()
        bloquear()
        lbestado.Text = ""

        ' ....... 
        Dim tp As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT  ctaad,	ctaac FROM parcontrato ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Refresh()

        If tp.Rows.Count > 0 Then
            dd = tp.Rows(0).Item("ctaad")
            'dc = tp.Rows(0).Item("ctaac")
        End If

    End Sub

    Public Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT i.*, concat(t.nombre,' ',t.apellidos) as nom FROM inmuebles i, terceros t WHERE t.nit=i.nitp AND i.codigo ='" & txtinm.Text & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtinm.Text = ""
            Try
                FrmSelInmueble.lbform.Text = "InmPagServ"
                FrmSelInmueble.ShowDialog()
                'var = "ok"
            Catch ex As Exception
            End Try
        Else
            txtinm.Text = tabla.Rows(0).Item("codigo")
        End If
        If txtinm.Text <> "" Then
            buscarServicio(txtinm.Text)
            BusArre()
        End If

    End Sub
    Public Sub BusArre()
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM contrato_inm WHERE cod_inm ='" & txtinm.Text & "' AND mes_total > mes_fact ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            MsgBox("No exiten clientes asociados a este inmueble", MsgBoxStyle.Information, "Verificación")
            txtnita.Text = ""
            txtnoma.Text = ""
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
    Public Sub buscarServicio(ByVal txt As String)

        If txt <> "" Then
            Dim ts As New DataTable
            ts.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inm_servicios WHERE codigo_inm ='" & txt & "'  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ts)
            Refresh()
            If ts.Rows.Count > 0 Then
                cmbservicio.Items.Clear()
                For i = 0 To ts.Rows.Count - 1
                    cmbservicio.Items.Add(ts.Rows(i).Item("descrip"))
                Next
                cmbservicio.Text = cmbservicio.Items(0).ToString
            Else
                MsgBox("El inmueble no tiene registrado ningun servicio publico", MsgBoxStyle.Information, "Verificacion")
                cmdcancelar_Click(AcceptButton, AcceptButton)
            End If
        Else
            cmbservicio.Items.Clear()
        End If
    End Sub

    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        limpiar()
        bloquear()
        lbestado.Text = ""
        txtf1.Value = CDate(Strings.Left(PerActual, 2) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    End Sub
    Function buscarmes(ByVal mes As String)
        Dim m As String = ""

        If mes = "ENERO" Then
            m = "01"
        ElseIf mes = "FEBRERO" Then
            m = "02"
        ElseIf mes = "MARZO" Then
            m = "03"
        ElseIf mes = "ABRIL" Then
            m = "04"
        ElseIf mes = "MAYO" Then
            m = "05"
        ElseIf mes = "JUNIO" Then
            m = "06"
        ElseIf mes = "JULIO" Then
            m = "07"
        ElseIf mes = "AGOSTO" Then
            m = "08"
        ElseIf mes = "SEPTIEMBRE" Then
            m = "09"
        ElseIf mes = "OCTUBRE" Then
            m = "10"
        ElseIf mes = "NOVIEMBRE" Then
            m = "11"
        ElseIf mes = "DICIEMBRE" Then
            m = "12"
        End If
        Return m
    End Function
    Function buscarmesN(ByVal mes As String)
        Dim m As String = ""

        If mes = "01" Then
            m = "ENERO"
        ElseIf mes = "02" Then
            m = "FEBRERO"
        ElseIf mes = "03" Then
            m = "MARZO"
        ElseIf mes = "04" Then
            m = "ABRIL"
        ElseIf mes = "05" Then
            m = "MAYO"
        ElseIf mes = "06" Then
            m = "JUNIO"
        ElseIf mes = "07" Then
            m = "JULIO"
        ElseIf mes = "08" Then
            m = "AGOSTO"
        ElseIf mes = "09" Then
            m = "SEPTIEMBRE"
        ElseIf mes = "10" Then
            m = "OCTUBRE"
        ElseIf mes = "11" Then
            m = "NOVIEMBRE"
        ElseIf mes = "12" Then
            m = "DICIEMBRE"
        End If
        Return m
    End Function

    'Private Sub cmbmes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmes.SelectedIndexChanged
    '    If cmbmes.Text = "ENERO" Then
    '        txtf1.Value = CDate("01" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "FEBRERO" Then
    '        txtf1.Value = CDate("02" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "MARZO" Then
    '        txtf1.Value = CDate("03" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "ABRIL" Then
    '        txtf1.Value = CDate("04" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "MAYO" Then
    '        txtf1.Value = CDate("05" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "JUNIO" Then
    '        txtf1.Value = CDate("06" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "JULIO" Then
    '        txtf1.Value = CDate("07" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "AGOSTO" Then
    '        txtf1.Value = CDate("08" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "SEPTIEMBRE" Then
    '        txtf1.Value = CDate("09" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "OCTUBRE" Then
    '        txtf1.Value = CDate("10" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "NOVIEMBRE" Then
    '        txtf1.Value = CDate("11" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    ElseIf cmbmes.Text = "DICIEMBRE" Then
    '        txtf1.Value = CDate("12" & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
    '    End If
    'End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        lbestado.Text = "NUEVO"
        desbloquear()
        limpiar()
    End Sub
    Private Sub desbloquear()
        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        CmdEliminar.Enabled = False
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        CmdMostrar.Enabled = False
        cmbservicio.Enabled = True

        txtinm.Enabled = True
        cmbmes.Enabled = True
        txtf1.Enabled = True
        txtvalor.Enabled = True
        txtmedpago.Enabled = True
    End Sub
    Private Sub bloquear()
        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        CmdEliminar.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        CmdMostrar.Enabled = True
        cmbservicio.Enabled = False

        txtinm.Enabled = False
        cmbmes.Enabled = False
        txtf1.Enabled = False
        txtvalor.Enabled = False
        txtmedpago.Enabled = False
    End Sub
    Private Sub limpiar()

        lbanulado.Text = ""
        lbdoc.Text = ""
        lbper.Text = ""
        txtinm.Text = ""
        'txtf1.Value = CDate(buscarmes(cmbmes.Text) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
        txtvalor.Text = Moneda(0)
        txtmedpago.Text = ""
        txtvalor.Text = Moneda(0)
        txtdep.Text = Moneda(0)
        cmbmes.Text = buscarmesN(Strings.Left(PerActual, 2))
        'cmbmes_SelectedIndexChanged(AcceptButton, AcceptButton)
        cmbservicio.Items.Clear()
        lbmesA.Text = ""
        ctaDep = ""
        docdep = ""
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click

        If txtinm.Text = "" Then
            MsgBox("Por favor digite el codigo del inmueble ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If txtvalor.Text = Moneda(0) Then
            MsgBox("Por favor digite el valor pagado ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If lbestado.Text = "EDITAR" And lbmesA.Text <> cmbmes.Text & "-" & Strings.Right(CDate(txtf1.Text.ToString), 4) Then
            MsgBox("No puede modificar el mes ", MsgBoxStyle.Information, "Verificación")
            cmbmes.Text = Strings.Left(lbmesA.Text, Len(lbmesA.Text) - 5)
            Exit Sub
        End If

        If lbestado.Text = "NUEVO" Then
            Dim ta As New DataTable
            ta.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inm_servpagos WHERE codigo_inm ='" & txtinm.Text & "' and mes = '" & cmbmes.Text & "-" & Strings.Right(CDate(txtf1.Text.ToString), 4) & "' AND servicio = '" & cmbservicio.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            Refresh()
            If ta.Rows.Count > 0 Then
                MsgBox("El inmueble ya tiene registrado un pago en este mes , para el servicio publico " & cmbservicio.Text, MsgBoxStyle.Information, " Verificacion")
                Exit Sub
            End If
        End If


        Try
            '
            MiConexion(bda)
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El pago del servicio " & cmbservicio.Text & " se va a registrar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                'If lbdoc.Text <> "" Then
                If lbestado.Text = "NUEVO" Then
                    Guardar()
                ElseIf lbestado.Text = "EDITAR" Then
                    Modificar()
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                cmdcancelar_Click(AcceptButton, AcceptButton)
                'Else
                '    MsgBox("Realice el documento contable antes de Guardar", MsgBoxStyle.Information, "Verificación")
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error al Guardar el documento. " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        Cerrar()
    End Sub
    Private Sub Guardar()
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codinm", txtinm.Text)
        myCommand.Parameters.AddWithValue("?mes", cmbmes.Text & "-" & Strings.Right(CDate(txtf1.Text.ToString), 4))
        myCommand.Parameters.AddWithValue("?servicio", cmbservicio.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtf1.Text.ToString))
        myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))
        myCommand.Parameters.AddWithValue("?forma", txtmedpago.Text.ToString)
        myCommand.Parameters.AddWithValue("?perdoc", lbper.Text.ToString)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text.ToString)
        If chdp.Checked = True Then
            myCommand.Parameters.AddWithValue("?dep", DIN(txtvalor.Text))
        Else
            myCommand.Parameters.AddWithValue("?dep", DIN(0))
        End If


        myCommand.CommandText = "Insert INTO inm_servpagos  Values (?codinm,?mes,?servicio,?fecha,?valor,?forma,?perdoc,?doc,?dep);"
        myCommand.ExecuteNonQuery()
        Refresh()

        If chdp.Checked = True And txtdep.Text <> Moneda(0) Then
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE  `contrato_inm`  SET mov_deposito= mov_deposito + " & DIN(txtvalor.Text) & "   WHERE cod_inm='" & txtinm.Text & "' AND nit_a ='" & txtnita.Text & "' AND mes_total > mes_fact"
                myCommand.ExecuteNonQuery()
                Refresh()
            Catch ex As Exception
                MsgBox("Error al Aplicar el deposito", MsgBoxStyle.Information, "Error")
            End Try

            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE ant_de_clie SET causado= causado + " & DIN(txtvalor.Text) & "   WHERE per_doc='" & docdep & "' "
                Refresh()
            Catch ex As Exception
                MsgBox("Error al actualizar el anticipo", MsgBoxStyle.Information, "Error")
            End Try
        End If
    End Sub
    Private Sub Modificar()
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codinm", txtinm.Text)
        myCommand.Parameters.AddWithValue("?mes", cmbmes.Text & "-" & Strings.Right(CDate(txtf1.Text.ToString), 4))
        myCommand.Parameters.AddWithValue("?servicio", cmbservicio.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtf1.Text.ToString))
        myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))
        myCommand.Parameters.AddWithValue("?forma", txtmedpago.Text.ToString)
        myCommand.Parameters.AddWithValue("?perdoc", lbper.Text.ToString)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text.ToString)

        myCommand.CommandText = "UPDATE inm_servpagos SET servicio=?servicio, fecha=?fecha, valor=?valor, forma=?forma, perdoc=?perdoc, doc=?doc WHERE codigo_inm='" & txtinm.Text & "' AND mes='" & lbmesA.Text & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        lbestado.Text = "EDITAR"
        desbloquear()
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        MiConexion(bda)
        Try
            FrmSelPagos.gitems.Rows.Clear()
            FrmSelPagos.lbform.Text = "InmPagosSer"
            FrmSelPagos.ShowDialog()
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        MiConexion(bda)

        If txtinm.Text = "" And lbmesA.Text = "" Then
            MsgBox("Digite el codigo del Inmueble ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If

        If lbdoc.Text <> "" Then
            If Strings.Left(PerActual, 2) <> Strings.Left(lbper.Text, 2) Then
                MsgBox("El documento contable no existe en este periodo, Cambie de Periodo y anulelo para poder Eliminar el Pago del Servicio", MsgBoxStyle.Information, "SAE")
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
        If lbanulado.Text = "" Then
            Dim resultado2 As MsgBoxResult
            resultado2 = MsgBox("El documento contable no ha sido anulado, Desea anularlo?", MsgBoxStyle.YesNo, "Verificando")
            If resultado2 = MsgBoxResult.Yes Then
                cmbCont_Click(AcceptButton, AcceptButton)
                Exit Sub
            Else
                Exit Sub
            End If
        End If


        Try

            Dim resultado As MsgBoxResult
            resultado = MsgBox("El pago del servicio " & cmbservicio.Text & " se va a eliminar, ¿Esta seguro que Desea Eliminardarlo?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM inm_servpagos WHERE codigo_inm='" & txtinm.Text & "' AND mes='" & lbmesA.Text & "' AND servicio = '" & cmbservicio.Text & "' ;"
                myCommand.ExecuteNonQuery()
                Refresh()

                If chdp.Checked = True And txtdep.Text <> Moneda(0) Then
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "UPDATE  `contrato_inm`  SET mov_deposito= mov_deposito - " & DIN(txtvalor.Text) & "   WHERE cod_inm='" & txtinm.Text & "' AND nit_a ='" & txtnita.Text & "' AND mes_total > mes_fact"
                        myCommand.ExecuteNonQuery()
                        Refresh()
                    Catch ex As Exception
                        MsgBox("Error al Aplicar el deposito", MsgBoxStyle.Information, "Error")
                    End Try
                End If

                MsgBox("La Pago eliminado satisfactoriamente", MsgBoxStyle.Information, "SAE")
                cmdcancelar_Click(AcceptButton, AcceptButton)
            End If

        Catch ex As Exception
            MsgBox("Error al Eliminar el Pago del Servicio", MsgBoxStyle.Information, "Error")
        End Try
        Cerrar()
    End Sub

    Private Sub txtnita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.TextChanged
        If lbestado.Text = "NUEVO" Then
            If txtnita.Text = "" Then
                chdp.Checked = False
                chdp.Enabled = False
                txtdep.Enabled = False
            Else
                chdp.Enabled = True
                txtdep.Enabled = True
            End If
        Else
            chdp.Enabled = False
            txtdep.Enabled = False
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
    Public ctaDep, docdep As String
    Private Sub chdp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chdp.CheckedChanged

        ctaDep = ""
        docdep = ""
        If chdp.Checked = False Then
            txtdep.Text = Moneda(0)
            txtdep.Enabled = False
            'txtvalordp.Enabled = False
            txtvalordp.Text = Moneda(0)
        Else

            Dim td As New DataTable
            td.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT doc_dep FROM contrato_inm WHERE cod_inm ='" & txtinm.Text & "'  and nit_a='" & txtnita.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            Refresh()
            If td.Rows.Count > 0 Then
                If td.Rows(0).Item(0) = "" Then
                    txtdep.Text = Moneda(0)
                    txtvalordp.Text = Moneda(0)
                Else
                    '...ANTICIPO...
                    Dim ta As New DataTable
                    ta.Clear()
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT * FROM ant_de_clie  WHERE per_doc ='" & td.Rows(0).Item(0) & "' ;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(ta)
                    Refresh()
                    If ta.Rows.Count > 0 Then
                        docdep = td.Rows(0).Item(0)
                        txtdep.Text = Moneda(ta.Rows(0).Item("monto") - ta.Rows(0).Item("causado"))
                        ctaDep = ta.Rows(0).Item("cta")
                        txtvalordp.Text = Moneda(0)
                    Else
                        txtdep.Text = Moneda(0)
                    End If
                End If
            Else
                'txtdep.Enabled = True
                txtdep.Text = Moneda(0)
            End If
            'txtdep.Enabled = True

        End If
    End Sub

    Private Sub cmbCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCont.Click


        If txtnitp.Text <> "" And txtvalor.Text <> Moneda(0) Then

            If lbestado.Text = "NUEVO" Then
                FrmComEgresoCpp.CmdNuevo_Click(AcceptButton, AcceptButton)

                FrmComEgresoCpp.txtvalor.Text = Moneda(txtvalor.Text)
                FrmComEgresoCpp.rbcc.Checked = True
                FrmComEgresoCpp.txtnit.Text = txtnitp.Text
                FrmComEgresoCpp.BuscarClientes(txtnitp.Text)
                FrmComEgresoCpp.txtconcepto.Text = " PAGO SERVICIO PUBLICO:" & cmbservicio.Text & ", MES " & cmbmes.Text & ", INMUEBLE " & txtinm.Text
                FrmComEgresoCpp.ps = "ps"
                FrmComEgresoCpp.grilla.RowCount = 3

                If chdp.Checked = False Then
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
                Else

                    If CDbl(txtdep.Text) < CDbl(txtvalor.Text) Then
                        MsgBox(" El valor a pagar supera el saldo disponible del Deposito", MsgBoxStyle.Information, "Verificación")
                        Exit Sub
                    End If

                    '....
                    FrmComEgresoCpp.ChAnti.Checked = False
                    Dim tc As New DataTable
                    tc.Clear()
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT codigo, descripcion FROM selpuc WHERE codigo IN('" & dd & "','" & ctaDep & "') ORDER BY codigo "
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tc)
                    Refresh()
                    If tc.Rows.Count > 0 Then
                        ' CAJA
                        FrmComEgresoCpp.grilla.Item("Cuenta", 0).Value = tc.Rows(0).Item("codigo")
                        FrmComEgresoCpp.grilla.Item("Descripcion", 0).Value = tc.Rows(0).Item("descripcion")
                        FrmComEgresoCpp.grilla.Item("Debitos", 0).Value = Moneda(0)
                        FrmComEgresoCpp.grilla.Item("Creditos", 0).Value = Moneda(txtvalor.Text)
                        FrmComEgresoCpp.grilla.Item("Base", 0).Value = Moneda(0)
                        FrmComEgresoCpp.grilla.Item("cc", 0).Value = ""
                        ' NACIONAL
                        FrmComEgresoCpp.grilla.Item("Cuenta", 1).Value = tc.Rows(1).Item("codigo")
                        FrmComEgresoCpp.grilla.Item("Descripcion", 1).Value = tc.Rows(1).Item("descripcion")
                        FrmComEgresoCpp.grilla.Item("Debitos", 1).Value = Moneda(txtvalor.Text)
                        FrmComEgresoCpp.grilla.Item("Creditos", 1).Value = Moneda(0)
                        FrmComEgresoCpp.grilla.Item("Base", 1).Value = Moneda(0)
                        FrmComEgresoCpp.grilla.Item("cc", 1).Value = ""
                    End If
                End If

                FrmComEgresoCpp.lbestado.Text = "NUEVO"
                FrmComEgresoCpp.ShowDialog()
                If FrmComEgresoCpp.lbestado.Text = "NUEVO" Then
                    FrmComEgresoCpp.CmdCancelar_Click(AcceptButton, AcceptButton)
                End If
                If FrmComEgresoCpp.lbestado.Text = "GUARDADO" Then
                    lbper.Text = FrmComEgresoCpp.lbper.Text
                    lbdoc.Text = FrmComEgresoCpp.lbdoc.Text & FrmComEgresoCpp.txtnumero.Text
                End If
            End If
            If lbestado.Text = "ELIMINAR" Then
                FrmComEgresoCpp.ps = "ps"
                FrmComEgresoCpp.lbdoc.Text = Strings.Left(lbdoc.Text, 2)
                FrmComEgresoCpp.txtnumero.Text = Strings.Right(lbdoc.Text, Strings.Len(lbdoc.Text) - 2)
                FrmComEgresoCpp.BuscarDocumento(lbdoc.Text)
                FrmComEgresoCpp.ShowDialog()

            End If
        Else
            MsgBox("Datos incompletos , Verifique los valores", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub

    Private Sub lbestado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbestado.TextChanged
        If lbestado.Text <> "NUEVO" Then
            chdp.Enabled = False
            txtdep.Enabled = False
        End If
    End Sub

    Private Sub txtdep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdep.TextChanged
        If txtdep.Text = Moneda(0) Then
            txtvalordp.Enabled = False
            txtvalordp.Text = Moneda(0)
        Else
            txtvalordp.Enabled = True
        End If
    End Sub

    Private Sub txtvalordp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalordp.LostFocus
        If CDbl(txtvalordp.Text) > CDbl(txtdep.Text) Then
            MsgBox("El Valor supera el saldo del deposito", MsgBoxStyle.Information, "SAE")
        End If
    End Sub
End Class