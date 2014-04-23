Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class FrmContratos
    Dim var As String = ""
    Dim mes As Integer = 0
    Private Sub limpiar()
        cbAcuerdo.Checked = False
        lbtip_precio.Text = ""
        txtcentrocosto.Text = ""
        txtcentro.Text = ""
        txtcad.Text = ""
        txtcac.Text = ""
        lbdocDep.Text = ""
        txtinm.Text = ""
        If lbestado.Text <> "CONSULTA" Then
            txtcontrato.Text = ""
        End If
        txtdueño.Text = ""
        txtnomdu.Text = ""
        txtarre.Text = ""
        txtnomarr.Text = ""
        txtco.Text = ""
        txtco2.Text = ""
        txtnomco.Text = ""
        txtvalor.Text = ""
        cbiva.Checked = False
        txtivap.Text = Moneda(0)
        txtcta_iva.Text = ""
        txtcta_cms.Text = ""
        txtcta_cli.Text = ""
        txtcta_v.Text = ""
        txtcomis.Text = Moneda(0)
        txtretf.Text = Moneda(0)
        txtretc.Text = Moneda(0)
        txtcta_rtf.Text = ""
        txtretc.Text = Moneda(0)
        txtcta_rtc.Text = ""
        txtcta_v.Text = ""
        txtvend.Text = ""
        txtnomven.Text = ""
        txtvmto.Text = ""
        txtdep.Text = Moneda(0)
        lbtermi.Visible = False
        'CONCEPTOS
        cbconcepto.Items.Clear()
        cbsr.Items.Clear()
        cbvalor.Items.Clear()
        cbcta.Items.Clear()
        cbbase.Items.Clear()
        cbtcli.Items.Clear()
        cbCont.Items.Clear()
        cbDia.Items.Clear()

        Try
            txtf.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf.Enabled = True Then
                txtf.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf.Value = CDate(PerActual & "/" & "01")
            End If
        End Try

    End Sub
    Private Sub desbloquear()
        txtcontrato.Enabled = True
        cbAcuerdo.Enabled = True
        txtinm.Enabled = True
        txtdueño.Enabled = True
        txtarre.Enabled = True
        txtvmto.Enabled = True
        txtvalor.Enabled = True
        txtf1.Enabled = True
        txtf2.Enabled = True
        txtf.Enabled = True
        txtco.Enabled = True
        txtco2.Enabled = True

        'txtcentrocos.Enabled = True
        cbiva.Enabled = True
        txtcomis.Enabled = True

        txtivap.Enabled = True
        txtcta_iva.Enabled = True
        txtcta_v.Enabled = True
        txtretf.Enabled = True
        txtcta_rtf.Enabled = True
        txtretc.Enabled = True
        txtcta_rtc.Enabled = True
        txtcta_cli.Enabled = True
        txtcta_cms.Enabled = True
        txtvend.Enabled = True
        txtdep.Enabled = True
        txtcad.Enabled = True
        txtcac.Enabled = True

        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        CmdBuscar.Enabled = False
        CmdMostrar.Enabled = False
        cmdPrint.Enabled = False

        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        '....
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") = "S" Then
                txtcentrocosto.Enabled = True
            Else
                txtcentrocosto.Enabled = False
            End If
        Catch ex As Exception
            txtcentrocosto.Enabled = False
        End Try
    End Sub
    Private Sub bloquear()
        lbestado.Text = "CONSULTA"
        txtcontrato.Enabled = False
        cbAcuerdo.Enabled = False
        txtinm.Enabled = False
        txtdueño.Enabled = False
        txtvmto.Enabled = False
        txtarre.Enabled = False
        txtvalor.Enabled = False
        txtf1.Enabled = False
        txtf2.Enabled = False
        txtf.Enabled = False
        txtvend.Enabled = False
        txtco.Enabled = False
        txtco2.Enabled = False

        txtcentrocosto.Enabled = False
        cbiva.Enabled = False
        txtcomis.Enabled = False
        txtivap.Enabled = False
        txtcta_v.Enabled = False
        txtcta_iva.Enabled = False
        txtretf.Enabled = False
        txtcta_rtf.Enabled = False
        txtretc.Enabled = False
        txtcta_rtc.Enabled = False
        txtdep.Enabled = False
        txtcta_cli.Enabled = False
        txtcta_cms.Enabled = False
        txtcad.Enabled = False
        txtcac.Enabled = False


        cmdNuevo.Enabled = True
        If edita <> "NO" Then
            cmdmodificar.Enabled = True
        End If
        CmdBuscar.Enabled = True
        CmdMostrar.Enabled = True
        cmdPrint.Enabled = True

        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False


    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtarre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtarre.KeyPress
        ValidarNIT(txtarre, e)
    End Sub

    Private Sub txtdueño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdueño.KeyPress
        ValidarNIT(txtdueño, e)
    End Sub

    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        ValidarNIT(txtvalor, e)
    End Sub

    Private Sub txtinm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinm.KeyPress

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        lbestado.Text = "NUEVO"
        desbloquear()
        limpiar()
        lbtermi.Visible = False

        Try
            txtf1.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf1.Enabled = True Then
                txtf1.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf1.Value = CDate(PerActual & "/" & "01")
            End If
        End Try

        Try
            txtf2.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf1.Enabled = True Then
                txtf1.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf1.Value = CDate(PerActual & "/" & "01")
            End If
        End Try

        Try
            txtf.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf.Enabled = True Then
                txtf.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf.Value = CDate(PerActual & "/" & "01")
            End If
        End Try

        txtcontrato.Focus()
        parametros()
    End Sub
    Dim edita As String
    Private Sub FrmContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        edita = ""
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parcontrato;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("No ha definido los parametros para el modulo Inmobiliario", MsgBoxStyle.Information, "Verificacion")
            Me.Close()
        Else
            If tabla.Rows(0).Item("editar") = "NO" Then
                Dim tb As New DataTable
                myCommand.CommandText = "SELECT rol FROM  sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                If tb.Rows(0).Item(0) <> "admin" Then
                    edita = "NO"
                End If
            End If
        End If

        If edita = "NO" Then
            cmdmodificar.Enabled = False
        Else
            cmdmodificar.Enabled = True
        End If

        'Try
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    If tabla.Rows(0).Item("ccosto") = "N" Then
        '        txtcentrocos.Items.Clear()
        '        Exit Try
        '    End If
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT * FROM  centrocostos WHERE nivel='centro';"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    txtcentrocos.Items.Clear()
        '    For i = 0 To tabla.Rows.Count - 1
        '        txtcentrocos.Items.Add(tabla.Rows(i).Item("centro"))
        '    Next
        'Catch ex As Exception
        '    txtcentrocos.Items.Clear()
        'End Try
        bloquear()
        lbestado.Text = "NULO"
        limpiar()
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        bloquear()
        limpiar()
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If txtcontrato.Text <> "" Then
            desbloquear()
            lbestado.Text = "EDITAR"
            txtcontrato.Enabled = False
            parametros()
        End If
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click

        '
        'Dim fecha As Date
        'fecha = DateAdd("m", 1, txtf1.Text)
        'MsgBox(fecha)
        Try

       
            If txtcontrato.Text = "" Then
                MsgBox("No ha digitado el codigo del contrato", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtinm.Text = "" Then
                MsgBox("No ha seleccionado el inmueble", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtarre.Text = "" Then
                MsgBox("Seleccione el arrendatario", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If CDate(txtf1.Text) > CDate(txtf2.Text) Then
                MsgBox("Seleccione un rango de fecha valida", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If CDate(txtf.Text) < CDate(txtf1.Text) Then
                MsgBox("La Fecha de Facturación, no puede ser menor a la Fecha inicial del contrato", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtvalor.Text = "" Then
                MsgBox("Digite el valor a pagar mensual", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtcta_v.Text = "" Then
                MsgBox("Seleccione la cuenta ", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtcta_cli.Text = "" Then
                MsgBox("Seleccione la cuenta por Pagar ", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If cbiva.Checked = True And txtcta_iva.Text = "" Then
                MsgBox("Seleccione la cuenta del iva", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtcomis.Text <> Moneda(0) And txtcta_cms.Text = "" Then
                MsgBox("Seleccione la cuenta-Comision", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtnomven.Text = "" Then
                MsgBox("Seleccione el vendedor", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtvmto.Text = "" Then
                MsgBox("Digite los dias de venciemiento", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtdep.Text <> Moneda(0) Then
                If cbAcuerdo.Checked = True Then
                    If txtcac.Text = "" Or txtcad.Text = "" Then
                        MsgBox("Digite las cuentas para registrar el valor del Acuerdo", MsgBoxStyle.Information, "Verifique")
                        Exit Sub
                    End If
                End If
            End If
            If cbiva.Checked = True And txtivap.Text = Moneda(0) Then
                MsgBox("Digite el porcentaje para el IVA", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            'If txtretf.Text <> Moneda(0) And txtcta_rtf.Text = "" Then
            '    MsgBox("Digite la cuenta para la retencion en la fuente", MsgBoxStyle.Information, "Verifique")
            '    Exit Sub
            'End If
            'If txtretc.Text <> Moneda(0) And txtcta_rtc.Text = "" Then
            '    MsgBox("Digite la cuenta para el Retecree", MsgBoxStyle.Information, "Verifique")
            '    Exit Sub
            'End If
        Catch ex As Exception
        End Try

        mes = 0
        mes = DateDiff("m", txtf1.Text, txtf2.Text)
        'mes = DateDiff(("m", mes, txtf.Text)
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcontrato.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            modificar(tb.Rows(0).Item("cod_inm"), tb.Rows(0).Item("fechaini").ToString, tb.Rows(0).Item("fechafin").ToString, tb.Rows(0).Item("fechaF").ToString)
        Else
            guardar()
        End If

        ' End If
    End Sub
    Private Sub Guar_OConceptos()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM otcon_contrato " _
                                     & " WHERE codcon ='" & txtcontrato.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            For j = 0 To cbsr.Items.Count - 1
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?codcon", txtcontrato.Text)
                myCommand.Parameters.AddWithValue("?item", j + 1)
                myCommand.Parameters.AddWithValue("?sg", cbsr.Items.Item(j))
                myCommand.Parameters.AddWithValue("?des", CambiaCadena(cbconcepto.Items.Item(j), 99))
                myCommand.Parameters.AddWithValue("?v", DIN(Moneda(cbvalor.Items.Item(j))))
                myCommand.Parameters.AddWithValue("?b", DIN(Moneda(cbbase.Items.Item(j))))
                myCommand.Parameters.AddWithValue("?cta", cbcta.Items.Item(j))
                myCommand.Parameters.AddWithValue("?tpcli", cbtcli.Items.Item(j))
                If cbtcli.Items.Item(j) = "AMBOS" Then
                    myCommand.Parameters.AddWithValue("?cli", "")
                ElseIf cbtcli.Items.Item(j) = "ARRENDATARIO" Then
                    myCommand.Parameters.AddWithValue("?cli", txtarre.Text)
                ElseIf cbtcli.Items.Item(j) = "PROPIETARIO" Then
                    myCommand.Parameters.AddWithValue("?cli", txtdueño.Text)
                End If
                myCommand.Parameters.AddWithValue("?cont", cbCont.Items.Item(j))
                myCommand.Parameters.AddWithValue("?dia", cbDia.Items.Item(j))

                myCommand.CommandText = "INSERT INTO otcon_contrato " _
                                      & " Values(?codcon,?item,?sg,?des,?v,?b,?cta,?tpcli,?cli,?cont,?dia);"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox("Error al registrar los otros conceptos, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
    End Sub
    Private Sub modificar(ByVal inm As String, ByVal fec1 As Date, ByVal fec2 As Date, ByVal fefac As Date)
        MiConexion(bda)
        Try
            Dim resultado, r2 As MsgBoxResult
            resultado = MsgBox("Los datos del contrato se van a modificar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then


                'myCommand.Parameters.Clear()
                'myCommand.CommandText = "DELETE FROM contrato_inm WHERE cod_contra ='" & txtcontrato.Text & "' "
                'myCommand.ExecuteNonQuery()
                'Refresh()


                'guardar()

                Dim cad As String = ""

                ''If fec1 <> CDate(txtf1.Text.ToString) Then
                'Dim fecha As Integer
                'fecha = 0
                'fecha = DateDiff("m", txtf1.Text, txtf.Text)

                'Dim f2 As Integer
                'f2 = 0
                'If txtf1.Text <> txtf.Text Then
                '    Dim fecha2 As Date
                '    fecha2 = DateAdd("m", fecha, txtf1.Text)
                '    f2 = Val(Strings.Mid(fecha2, 4, 2))
                'End If
                'cad = " mes_fact=" & fecha & ",mes_act=" & f2 & ", periodo='', "
                ''End If

                ' CAMBIAR FECHA FACTURACION
                Dim fecha, f2 As Integer
                fecha = 0
                fecha = DateDiff("m", txtf1.Text, txtf.Text)
                'MsgBox(CDate(txtf.Text.ToString))
                'If fefac <> CDate(txtf.Text.ToString) Then
                '    r2 = MsgBox("Realmente desea cambiar la fecha de facturacion?", MsgBoxStyle.YesNo, "Confirmacion")
                '    If r2 = MsgBoxResult.No Then
                '        txtf.Value = fefac
                '        Exit Sub
                '    End If
                'End If
                If CDate(txtf2.Text.ToString) = CDate(txtf.Text.ToString) Then ' SI LA ffact= ffinal
                    fecha = fecha + 1
                End If
                If fefac <> CDate(txtf.Text.ToString) Then ' SI CAMBIA LA FECHA DE FACTURACION
                    f2 = 0
                    If txtf1.Text <> txtf.Text Then
                        Dim fecha2 As Date
                        fecha2 = DateAdd("m", fecha, txtf1.Text)
                        f2 = Val(Strings.Mid(fecha2, 4, 2))
                    End If
                    cad = cad & " mes_fact=" & fecha & ",mes_act=" & f2 & ", periodo='', dias =0,"
                End If
                If fec2 <> CDate(txtf2.Text.ToString) Then ' SI CAMBIA LA FECHA DE FINAL DEL CONTRATO
                    cad = cad & " mes_total=" & mes + 1 & ", "
                End If
               

                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?cod_con", txtcontrato.Text)
                myCommand.Parameters.AddWithValue("?cod_inm", txtinm.Text)
                myCommand.Parameters.AddWithValue("?nita", txtarre.Text)
                myCommand.Parameters.AddWithValue("?nom_a", txtnomarr.Text)
                myCommand.Parameters.AddWithValue("?nitd", txtdueño.Text)
                myCommand.Parameters.AddWithValue("?f1", CDate(txtf1.Text.ToString))
                myCommand.Parameters.AddWithValue("?f2", CDate(txtf2.Text.ToString))
                myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))
                myCommand.Parameters.AddWithValue("?ctaval", txtcta_v.Text)
                ' myCommand.Parameters.AddWithValue("?iva", txtivap.Text)
                If cbiva.Checked = True Then
                    myCommand.Parameters.AddWithValue("?iva", DIN(txtivap.Text))
                Else
                    myCommand.Parameters.AddWithValue("?iva", DIN(0))
                End If
                myCommand.Parameters.AddWithValue("?ctaiva", txtcta_iva.Text)
                If txtcomis.Text = "" Then
                    myCommand.Parameters.AddWithValue("?comi", DIN(0))
                Else
                    myCommand.Parameters.AddWithValue("?comi", DIN(txtcomis.Text))
                End If
                myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
                myCommand.Parameters.AddWithValue("?tmes", mes + 1)
                myCommand.Parameters.AddWithValue("?nitv", txtvend.Text)
                myCommand.Parameters.AddWithValue("?vmto", txtvmto.Text)
                myCommand.Parameters.AddWithValue("?rtf", DIN(txtretf.Text))
                myCommand.Parameters.AddWithValue("?ctartf", txtcta_rtf.Text)
                myCommand.Parameters.AddWithValue("?dep", DIN(txtdep.Text))
                myCommand.Parameters.AddWithValue("?ff", CDate(txtf.Text.ToString))
                myCommand.Parameters.AddWithValue("?nitc", txtco.Text)
                myCommand.Parameters.AddWithValue("?nitc2", txtco2.Text)
                myCommand.Parameters.AddWithValue("?ctacli", txtcta_cli.Text)
                myCommand.Parameters.AddWithValue("?ctacms", txtcta_cms.Text)
                myCommand.Parameters.AddWithValue("?rtc", DIN(txtretc.Text))
                myCommand.Parameters.AddWithValue("?ctartc", txtcta_rtc.Text)
                If cbAcuerdo.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cont_dp", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?cont_dp", "NO")
                End If

                myCommand.CommandText = "UPDATE contrato_inm SET cod_inm=?cod_inm,nit_a=?nita,nomb_arr =?nom_a,nit_d=?nitd,fechaini=?f1," _
                & " fechafin=?f2,valor=?valor,cta_valor=?ctaval,por_iva=?iva,cta_iva=?ctaiva,rtf=?rtf,cta_rtf=?ctartf,por_comi=?comi,cc=?cc,mes_total=?tmes, " _
                & " " & cad & " " _
                & " nitv=?nitv,vmto=?vmto,deposito=?dep,fechaF=?ff,nitc=?nitc,cta_cli=?ctacli,cta_cms=?ctacms,nitc2=?nitc2,rtc=?rtc,cta_rtc=?ctartc,cont_dp=?cont_dp " _
                & " WHERE cod_contra =?cod_con"
                myCommand.ExecuteNonQuery()

                myCommand.Parameters.Clear()
                Refresh()
                '************************
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE inmuebles set estado = 'OCUPADO' WHERE codigo ='" & txtinm.Text & "';"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
                Refresh()
                '***********************
                If (txtinm.Text <> inm) Or ((mes + 1) = fecha) Then
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE inmuebles SET estado='DISPONIBLE' WHERE codigo='" & inm & "';"
                    myCommand.ExecuteNonQuery()
                    Refresh()
                End If
                '*************************
                If cbAcuerdo.Checked = True Then
                    If lbdocDep.Text = "" Then
                        If mes <> fecha Then ' Si no ha terminado el contrato
                            If txtdep.Text <> "" Or txtdep.Text <> Moneda(0) Then
                                DocumenDeposito()
                            End If
                        End If
                    End If
                End If

                Guar_OConceptos()

                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                'cmdcancelar_Click(AcceptButton, AcceptButton)
                bloquear()
            End If
        Catch ex As Exception
            MsgBox("Error al modificar el contrato " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub guardar()
        MiConexion(bda)
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del contrato se van a guardar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then

                myCommand.Parameters.Clear()

                Dim fecha, f2 As Integer
                fecha = 0
                fecha = DateDiff("m", txtf1.Text, txtf.Text)

                If CDate(txtf2.Text.ToString) = CDate(txtf.Text.ToString) Then ' SI LA ffact= ffinal
                    fecha = fecha + 1
                End If

                f2 = 0
                If txtf1.Text <> txtf.Text Then
                    Dim fecha2 As Date
                    fecha2 = DateAdd("m", fecha, txtf1.Text)
                    f2 = Val(Strings.Mid(fecha2, 4, 2))
                End If

                myCommand.Parameters.AddWithValue("?cod_con", txtcontrato.Text)
                myCommand.Parameters.AddWithValue("?cod_inm", txtinm.Text)
                myCommand.Parameters.AddWithValue("?nita", txtarre.Text)
                myCommand.Parameters.AddWithValue("?nom_a", txtnomarr.Text)
                myCommand.Parameters.AddWithValue("?nitd", txtdueño.Text)
                myCommand.Parameters.AddWithValue("?f1", CDate(txtf1.Text.ToString))
                myCommand.Parameters.AddWithValue("?f2", CDate(txtf2.Text.ToString))
                myCommand.Parameters.AddWithValue("?valor", DIN(txtvalor.Text))
                myCommand.Parameters.AddWithValue("?ctaval", txtcta_v.Text)
                If cbiva.Checked = True Then
                    myCommand.Parameters.AddWithValue("?iva", DIN(txtivap.Text))
                Else
                    myCommand.Parameters.AddWithValue("?iva", DIN(0))
                End If
                '   myCommand.Parameters.AddWithValue("?iva", txtivap.Text)
                myCommand.Parameters.AddWithValue("?ctaiva", txtcta_iva.Text)
                If txtcomis.Text = "" Then
                    myCommand.Parameters.AddWithValue("?comi", DIN(0))
                Else
                    myCommand.Parameters.AddWithValue("?comi", DIN(txtcomis.Text))
                End If
                myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
                myCommand.Parameters.AddWithValue("?tmes", mes + 1)
                myCommand.Parameters.AddWithValue("?nitv", txtvend.Text)
                myCommand.Parameters.AddWithValue("?vmto", txtvmto.Text)
                myCommand.Parameters.AddWithValue("?rtf", DIN(txtretf.Text))
                myCommand.Parameters.AddWithValue("?ctartf", txtcta_rtf.Text)
                myCommand.Parameters.AddWithValue("?dep", DIN(txtdep.Text))
                myCommand.Parameters.AddWithValue("?mes_f", fecha)
                myCommand.Parameters.AddWithValue("?mes_a", f2)
                myCommand.Parameters.AddWithValue("?ff", CDate(txtf.Text.ToString))
                myCommand.Parameters.AddWithValue("?nitc", txtco.Text)
                myCommand.Parameters.AddWithValue("?ctacli", txtcta_cli.Text)
                myCommand.Parameters.AddWithValue("?ctacms", txtcta_cms.Text)
                myCommand.Parameters.AddWithValue("?dias", DIN(0))
                myCommand.Parameters.AddWithValue("?movdep", DIN(0))
                myCommand.Parameters.AddWithValue("?nitc2", txtco2.Text)
                myCommand.Parameters.AddWithValue("?rtc", DIN(txtretc.Text))
                myCommand.Parameters.AddWithValue("?ctartc", txtcta_rtc.Text)
                If cbAcuerdo.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cont_dp", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?cont_dp", "NO")
                End If
                myCommand.CommandText = "Insert INTO contrato_inm Values (?cod_con,?cod_inm,?nita,?nom_a,?nitd,?f1,?f2,?valor,?ctaval,?iva,?ctaiva,?rtf,?ctartf,?comi,?cc,?tmes,?mes_f,?mes_a," _
                & " '',?nitv,?vmto,?dep,?ff,?nitc,?ctacli,?ctacms,?dias,?movdep,'',?nitc2,?rtc,?ctartc,?cont_dp);"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
                Refresh()
                '************************ ACTU INMUEBLE
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE inmuebles set estado = 'OCUPADO' WHERE codigo ='" & txtinm.Text & "';"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
                Refresh()

                If (mes + 1) = fecha Then ' SI LA ffact= ffinal
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE inmuebles set estado = 'DISPONIBLE' WHERE codigo ='" & txtinm.Text & "';"
                    myCommand.ExecuteNonQuery()
                    myCommand.Parameters.Clear()
                    Refresh()
                End If

                If lbtip_precio.Text <> "" Then
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE inmuebles set " & lbtip_precio.Text & " = " & DIN(txtvalor.Text) & " WHERE codigo ='" & txtinm.Text & "';"
                    myCommand.ExecuteNonQuery()
                    myCommand.Parameters.Clear()
                    Refresh()
                End If
                '***********************
                If cbAcuerdo.Checked = True Then
                    If txtdep.Text <> "" Or txtdep.Text <> Moneda(0) Then
                        DocumenDeposito()
                    End If
                End If

                Guar_OConceptos()

                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")

                'cmdcancelar_Click(AcceptButton, AcceptButton)
                bloquear()
            End If
        Catch ex As Exception
            MsgBox("Error al guardar el contrato " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    
    Private Sub DocumenDeposito()

        Dim td As New DataTable
        td.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT actual" & Strings.Left(PerActual, 2) & " FROM tipdoc where tipodoc = 'CI' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        Refresh()
        If td.Rows.Count > 0 Then

            Dim ndoc As Integer
            ndoc = td.Rows(0).Item(0) + 1
            grilla.Rows.Clear()
            grilla.RowCount = 3

            ' ----------- DEBITO
            grilla.Item("Descripcion", 0).Value = "ACUERDO CONTRATO " & txtcontrato.Text
            grilla.Item(1, 0).Value = Moneda(txtdep.Text)
            grilla.Item(2, 0).Value = Moneda(0)
            grilla.Item(3, 0).Value = txtcad.Text
            grilla.Item(4, 0).Value = Moneda(0)
            grilla.Item(5, 0).Value = ""
            grilla.Item(6, 0).Value = txtarre.Text
            grilla.Item(7, 0).Value = ""
            '-------------------------------------------

            ' ----------- CREDITO
            grilla.Item("Descripcion", 1).Value = "ACUERDO CONTRATO " & txtcontrato.Text
            grilla.Item(1, 1).Value = Moneda(0)
            grilla.Item(2, 1).Value = Moneda(txtdep.Text)
            grilla.Item(3, 1).Value = txtcac.Text
            grilla.Item(4, 1).Value = Moneda(0)
            grilla.Item(5, 1).Value = ""
            grilla.Item(6, 1).Value = txtarre.Text
            grilla.Item(7, 1).Value = ""

            '-------------------------------------------
            Dim cad As String = ""
            Dim db As String = ""
            Dim cr As String = ""

            For i = 0 To grilla.RowCount - 1
                Try
                    Try
                        cad = grilla.Item("cuenta", i).Value.ToString
                    Catch ex As Exception
                        cad = ""
                    End Try
                    Try
                        db = grilla.Item("Debitos", i).Value
                    Catch ex As Exception
                        db = 0
                    End Try
                    Try
                        cr = grilla.Item("Creditos", i).Value
                    Catch ex As Exception
                        cr = 0
                    End Try
                    If cad <> "" And (db > 0 Or cr > 0) Then
                        InsertContabilidad(i, ndoc, 0)
                    End If
                Catch ex As Exception
                End Try
                lbdocDep.Text = PerActual & "-CI" & NumeroDoc(ndoc)
            Next

            '************************
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE tipdoc set actual" & Strings.Left(PerActual, 2) & " = " & ndoc & " WHERE tipodoc ='CI';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
            '***********************

            '************************
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE contrato_inm set doc_dep = '" & lbdocDep.Text & "' WHERE cod_contra ='" & txtcontrato.Text & "';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
            '***********************

            ' ////////////////////////////// ANTICIPO DEPOSITO ///////////////////////

            Dim Sql As String = "DELETE FROM ant_de_clie WHERE per_doc='" & PerActual & "-CI" & NumeroDoc(ndoc) & "';"
            FrmCompIngresos.Ejecutar(Sql)

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?per_doc", PerActual & "-CI" & NumeroDoc(ndoc))
            myCommand.Parameters.AddWithValue("?doc", "CI" & NumeroDoc(ndoc))
            myCommand.Parameters.AddWithValue("?per", PerActual)
            Try
                myCommand.Parameters.AddWithValue("?fecha", CDate(Now.Day.ToString & "/" & PerActual))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?fecha", Now.Day.ToString & "/" & PerActual)
            End Try
            myCommand.Parameters.AddWithValue("?nitc", txtarre.Text)
            myCommand.Parameters.AddWithValue("?monto", DIN(Moneda(txtdep.Text)))
            myCommand.Parameters.AddWithValue("?causado", DIN("0"))
            myCommand.Parameters.AddWithValue("?cta", txtcac.Text)
            myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text.ToString)
            myCommand.Parameters.AddWithValue("?concepto", "DEPOSITO CONTRATO:" & txtcontrato.Text)
            myCommand.CommandText = "INSERT INTO ant_de_clie VALUES(" _
            & "?per_doc,?doc,?per,?fecha,?nitc,?monto,?causado,?cta,?user,NOW(),?concepto" _
            & ");"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()

        Else
            MsgBox("No ha definido el Tipo de Documento para los CI, Verifiquelo y realice el documento para registrar el Deposito manualmente", MsgBoxStyle.Information, "SAE")
        End If

    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal ndoc As Integer, ByVal vmto As Integer)

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", ndoc)
            myCommand.Parameters.AddWithValue("?tipodoc", "CI")
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", Now.Day.ToString)
            myCommand.Parameters.AddWithValue("?centro", grilla.Item("cc", fila).Value)
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(Moneda(grilla.Item("Debitos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(Moneda(grilla.Item("Creditos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(Moneda(grilla.Item("base", fila).Value)))
            myCommand.Parameters.AddWithValue("?diasv", Val(vmto))
            If Val(vmto) > 0 Then
                Dim fec As Date = DateAdd("d", Val(vmto), DateTime.Now.ToString("yyyy-MM-dd"))
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            '  Try
            myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
            myCommand.Parameters.AddWithValue("?cheque", "")

            myCommand.Parameters.AddWithValue("?modulo", "inmobiliaria")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos" & Strings.Left(PerActual, 2) & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error Insertar Contable" & ex.ToString)
        End Try
    End Sub

    Public Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT i.*, concat(t.nombre,' ',t.apellidos) as nom FROM inmuebles i  left join terceros t on t.nit=i.nitp WHERE i.codigo ='" & txtinm.Text & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtinm.Text = ""
            txtdueño.Text = ""
            txtnomdu.Text = ""
            Try
                FrmSelInmueble.lbform.Text = "contrato"
                FrmSelInmueble.ShowDialog()
                var = "ok"
            Catch ex As Exception
            End Try
        Else
            txtinm.Text = tabla.Rows(0).Item("codigo")
            txtdueño.Text = tabla.Rows(0).Item("nitp")
            txtnomdu.Text = tabla.Rows(0).Item("nom")
            If lbestado.Text <> "CONSULTA" Then
                If Trim(txtinm.Text) <> "" Then
                    If txtvalor.Text = Moneda(0) Or Trim(txtvalor.Text) = "" Then
                        Try
                            FrmValorInmu.ShowDialog()
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub txtinm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.TextChanged
        If txtinm.Text = "" Then
            txtdueño.Text = ""
            txtnomdu.Text = ""
        End If
    End Sub

    Private Sub txtarre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarre.LostFocus

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='ARRENDATARIO'  and tr.nit = '" & txtarre.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtarre.Text = ""
            txtnomarr.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Arrendatario"
                FrmSelDueño.lbform.Text = "contratoA"
                FrmSelDueño.txtclase.Text = "ARRENDATARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtarre.Text = tabla.Rows(0).Item("nit")
            txtnomarr.Text = tabla.Rows(0).Item("nom")
        End If

    End Sub


    Private Sub txtarre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarre.TextChanged
        If txtarre.Text = "" Then
            txtnomarr.Text = ""
        End If
    End Sub
    Private Sub buscar_contr(ByVal cont As String)
        Try
            MiConexion(bda)
            Dim tb As New DataTable
            tb.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & cont & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            If tb.Rows.Count = 0 Then
                MsgBox("No existe ningun contrato con ese codigo en los registros", MsgBoxStyle.Information, "Informacion")
                limpiar()
            Else

                'Dim fecha As Date
                'fecha = DateAdd("m", tb.Rows(0).Item("mes_fact"), CDate(tb.Rows(0).Item("fechaini")))
                lbestado.Text = "CONSULTA"
                txtcontrato.Text = tb.Rows(0).Item("cod_contra")
                txtinm.Text = tb.Rows(0).Item("cod_inm")
                txtarre.Text = tb.Rows(0).Item("nit_a")
                txtdueño.Text = tb.Rows(0).Item("nit_d")
                Try
                     txtf.Value = CDate(Strings.Mid(tb.Rows(0).Item("fechaf").ToString, 7, 4) & "-" & Strings.Mid(tb.Rows(0).Item("fechaf").ToString, 4, 2) & "-" & Strings.Left(tb.Rows(0).Item("fechaf").ToString, 2))
                     txtf.Text = tb.Rows(0).Item("fechaf").ToString
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                    Try
                        'txtf.Text = tb.Rows(0).Item("fechaf")
                        txtf.Text = Strings.Left(tb.Rows(0).Item("fechaf").ToString, 2) & "/" & Strings.Mid(tb.Rows(0).Item("fechaf").ToString, 4, 2) & "/" & Strings.Right(tb.Rows(0).Item("fechaf").ToString, 4)
                    Catch ex1 As Exception
                        txtf.Text = tb.Rows(0).Item("fechaf").ToString
                    End Try
                End Try
                txtf1.Text = tb.Rows(0).Item("fechaini").ToString
                txtf2.Text = tb.Rows(0).Item("fechafin").ToString
                txtvalor.Text = tb.Rows(0).Item("valor")
                txtvalor_LostFocus(AcceptButton, AcceptButton)
                txtcta_v.Text = tb.Rows(0).Item("cta_valor")
                txtivap.Text = tb.Rows(0).Item("por_iva")
                txtcta_iva.Text = tb.Rows(0).Item("cta_iva")
                txtretf.Text = tb.Rows(0).Item("rtf")
                txtcta_rtf.Text = tb.Rows(0).Item("cta_rtf")
                If tb.Rows(0).Item("por_iva") <> "0.00" Then
                    cbiva.Checked = True
                Else
                    cbiva.Checked = False
                End If
                txtcomis.Text = tb.Rows(0).Item("por_comi")
                txtcentrocosto.Text = tb.Rows(0).Item("cc")
                If txtcentrocosto.Text <> "0" Then
                    BuscarCCs()
                End If
                txtvend.Text = tb.Rows(0).Item("nitv")
                txtvend_LostFocus(AcceptButton, AcceptButton)
                txtvmto.Text = tb.Rows(0).Item("vmto")
                txtdep.Text = Moneda(tb.Rows(0).Item("deposito"))
                If tb.Rows(0).Item("mes_fact") = tb.Rows(0).Item("mes_total") Then
                    lbtermi.Visible = True
                Else
                    lbtermi.Visible = False
                End If
                txtco.Text = tb.Rows(0).Item("nitc")
                If txtco.Text <> "" Then
                    txtco_LostFocus(AcceptButton, AcceptButton)
                End If
                txtcta_cli.Text = tb.Rows(0).Item("cta_cli")
                txtcta_cms.Text = tb.Rows(0).Item("cta_cms")
                lbdocDep.Text = tb.Rows(0).Item("doc_dep")
                txtco2.Text = tb.Rows(0).Item("nitc2")
                If txtco2.Text <> "" Then
                    txtco2_LostFocus(AcceptButton, AcceptButton)
                End If
                If tb.Rows(0).Item("cont_dp") = "NO" Then
                    cbAcuerdo.Checked = False
                Else
                    cbAcuerdo.Checked = True
                End If
                txtarre_LostFocus(AcceptButton, AcceptButton)
                txtinm_LostFocus(AcceptButton, AcceptButton)
                'txtf.Text = tb.Rows(0).Item("fechaF").ToString


                'CONCEPTOS
                cbconcepto.Items.Clear()
                cbsr.Items.Clear()
                cbvalor.Items.Clear()
                cbcta.Items.Clear()
                cbbase.Items.Clear()
                cbtcli.Items.Clear()
                cbCont.Items.Clear()
                cbDia.Items.Clear()
                '////////////
                Dim toc As New DataTable
                myCommand.CommandText = "SELECT  *  " _
                              & "FROM otcon_contrato" _
                              & " WHERE codcon = '" & cont _
                              & "' ORDER BY item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(toc)
                Refresh()

                If toc.Rows.Count > 0 Then
                    For l = 0 To toc.Rows.Count - 1
                        cbsr.Items.Add(toc.Rows(l).Item("tipo"))
                        cbconcepto.Items.Add(toc.Rows(l).Item("descr"))
                        cbvalor.Items.Add(Moneda(toc.Rows(l).Item("valor")))
                        cbcta.Items.Add(toc.Rows(l).Item("cta"))
                        cbbase.Items.Add(toc.Rows(l).Item("base"))
                        cbtcli.Items.Add(toc.Rows(l).Item("tcli"))
                        cbCont.Items.Add(toc.Rows(l).Item("contb"))
                        cbDia.Items.Add(toc.Rows(l).Item("dia"))
                    Next
                End If
                Try
                    cbconcepto.SelectedIndex = 0
                Catch ex As Exception
                End Try

            End If
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub txtcontrato_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontrato.LostFocus
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcontrato.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            If tb.Rows(0).Item(0) = txtcontrato.Text Then
                MsgBox("Este codigo de contrato ya fue asignado", MsgBoxStyle.Information)
                txtcontrato.Text = ""
                ' buscar_contr(txtcontrato.Text)
            End If
        End If
    End Sub


    Private Sub cbiva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbiva.CheckedChanged

        If cbiva.Checked = True Then
            txtivap.Text = "16,00"
            txtcta_iva.ReadOnly = True
        Else
            txtivap.Text = "0.00"
            txtcta_iva.ReadOnly = False
        End If
    End Sub
    Private Sub txtcta_rtf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_rtf.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratortf"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcta_v_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_v.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratov"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcta_rtf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_rtf.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcta_v_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_v.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_iva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_iva.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratoiva"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_iva.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        If txtvalor.Text <> "" Then
            txtvalor.Text = Moneda(txtvalor.Text)
        Else
            txtvalor.Text = Moneda(0)
        End If
    End Sub

    Private Sub txtcta_v_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_v.LostFocus
        If txtcta_v.Text = "" Then
            txtcta_v_DoubleClick(AcceptButton, AcceptButton)
        End If

    End Sub

    Private Sub txtcta_iva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_iva.LostFocus
        If txtcta_iva.Text = "" Then
            txtcta_iva_DoubleClick(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        Dim x As String
        x = Trim(InputBox("Digite el Codigo del contrato", "Buscar"))
        lbestado.Text = "CONSULTA"
        buscar_contr(x)
    End Sub

    Private Sub txtcomis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcomis.LostFocus
        If txtcomis.Text = "" Then
            txtcomis.Text = Moneda(0)
        Else
            txtcomis.Text = Moneda(txtcomis.Text)
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click

        FrmSelContratos.lbform.Text = "contrato"
        FrmSelContratos.ShowDialog()
        If txtcontrato.Text <> "" Then
            lbestado.Text = "CONSULTA"
            limpiar()
            buscar_contr(txtcontrato.Text)
        End If

    End Sub
    'Private Sub txtcentrocosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentrocos.KeyPress
    '    If e.KeyChar = Chr(Keys.Enter) Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    'Private Sub txtcentrocosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentrocos.SelectedIndexChanged
    '    Try
    '        Dim tabla As New DataTable
    '        myCommand.Parameters.Clear()
    '        myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro=" & txtcentrocos.Text & ";"
    '        myAdapter.SelectCommand = myCommand
    '        myAdapter.Fill(tabla)
    '        Refresh()
    '        If tabla.Rows.Count > 0 Then
    '            txtcentro.Text = tabla.Rows(0).Item("nombre")
    '        Else
    '            txtcentro.Text = ""
    '        End If
    '    Catch ex As Exception
    '        txtcentro.Text = ""
    '    End Try
    'End Sub

    Private Sub txtvend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvend.KeyPress
        ValidarNIT(txtvend, e)
    End Sub

    Private Sub txtvend_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvend.LostFocus

        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtvend.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtnomven.Text = ""
            txtvend.Text = ""
            '  MsgBox("El nit/cédula del vendedor no existe en los registros.", MsgBoxStyle.Information, "Verificando")
            cargarvendedor()
        Else  'mostrar uno solo q coinside
            txtnomven.Text = tabla.Rows(0).Item(1)
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
            FrmSelVendedor.lbform.Text = "contr"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtvend_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvend.TextChanged
        If txtvend.Text = "" Then
            txtnomven.Text = ""
        End If
    End Sub

    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        ValidarNIT(txtvmto, e)
    End Sub

    Private Sub txtretf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretf.LostFocus
        If txtretf.Text = "" Then
            txtretf.Text = Moneda(0)
        Else
            txtretf.Text = Moneda(txtretf.Text)
        End If
    End Sub

    Private Sub txtvalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvalor.TextChanged

    End Sub

    Private Sub txtdep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdep.KeyPress
        ValidarNIT(txtdep, e)
    End Sub

    Private Sub txtdep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdep.LostFocus
        If txtdep.Text = "" Then
            txtretf.Text = Moneda(0)
        Else
            txtdep.Text = Moneda(txtdep.Text)
        End If
    End Sub

    Private Sub parametros()


        If lbestado.Text = "NUEVO" Then
            Dim tablap As New DataTable
            tablap.Clear()
            myCommand.CommandText = "SELECT * FROM parcontrato ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablap)
            Refresh()
            If tablap.Rows.Count > 0 Then
                txtcta_rtf.Text = tablap.Rows(0).Item("ctartf")
                txtcta_v.Text = tablap.Rows(0).Item("ctavent")
                txtcta_iva.Text = tablap.Rows(0).Item("ctaiva")
                txtcta_cli.Text = tablap.Rows(0).Item("ctacli")
                txtcta_cms.Text = tablap.Rows(0).Item("ctacms")
                txtcad.Text = tablap.Rows(0).Item("ctaad")
                txtcac.Text = tablap.Rows(0).Item("ctaac")
            End If
        ElseIf lbestado.Text = "EDITAR" Then
            Dim tablap As New DataTable
            tablap.Clear()
            myCommand.CommandText = "SELECT * FROM parcontrato ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablap)
            Refresh()
            If tablap.Rows.Count > 0 Then
                txtcad.Text = tablap.Rows(0).Item("ctaad")
                txtcac.Text = tablap.Rows(0).Item("ctaac")
            End If
        End If

    End Sub

    Private Sub txtf1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtf1.ValueChanged
        If lbestado.Text <> "CONSULTA" Then
            txtf.Text = txtf1.Text
        End If
    End Sub

    Private Sub txtco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco.DoubleClick
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='CO-ARRENDATARIO'  and tr.nit = '" & txtco.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtco.Text = ""
            txtnomco.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Co-Arrendatario"
                FrmSelDueño.lbform.Text = "contratoC"
                FrmSelDueño.txtclase.Text = "CO-ARRENDATARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtco.Text = tabla.Rows(0).Item("nit")
            txtnomco.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txtco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtco.KeyPress
        ValidarNIT(txtco, e)
    End Sub

    Private Sub txtco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco.LostFocus

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='CO-ARRENDATARIO'  and tr.nit = '" & txtco.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtco.Text = ""
            txtnomco.Text = ""
            'Try
            '    FrmSelDueño.Text = "Seleccionar Co-Arrendatario"
            '    FrmSelDueño.lbform.Text = "contratoC"
            '    FrmSelDueño.txtclase.Text = "CO-ARRENDATARIO"
            '    FrmSelDueño.ShowDialog()
            'Catch ex As Exception
            'End Try
        Else
            txtco.Text = tabla.Rows(0).Item("nit")
            txtnomco.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txtco_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco.TextChanged
        If txtco.Text = "" Then
            txtnomco.Text = ""
        End If
    End Sub

    Private Sub txtcta_cli_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_cli.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratocli"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_cli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_cli.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_cms_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_cms.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratocms"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_cms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_cms.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtivap_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivap.LostFocus
        If txtivap.Text <> "" Then
            txtivap.Text = Moneda(txtivap.Text)
        Else
            txtivap.Text = Moneda(0)
        End If
    End Sub

    Private Sub txtcac_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcac.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contrato_AC"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcad.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contrato_AD"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If txtcontrato.Text = "" Then
            MsgBox("Verifique el codigo del contrato", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        PDFContrato(txtcontrato.Text)
    End Sub

    Private Sub txtcentrocosto_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentrocosto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtcentro, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcentrocosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCCs()
    End Sub
    Private Sub BuscarCCs()
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") <> "S" Then Exit Sub
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentrocosto.Text & "'  and nivel ='centro';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtcentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentrocosto.Text
                txtcentrocosto.Text = ""
                FrmSelCentroCostos.lbform.Text = "ContInm"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcentrocosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.TextChanged
        If txtcentrocosto.Text = "" Then
            txtcentro.Text = ""
        End If
    End Sub
    Public Sub PDFContrato(ByVal cod As String)
        Try

            MiConexion(bda)
            Cerrar()

            Dim nom As String = ""
            Dim nit As String = ""
            Dim sql As String = ""

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT: " & tabla2.Rows(0).Item("nit")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " SELECT cb.pagare as pagare, cb.doc AS doc, cb.concepto AS descrip , cb.total AS total, ( cb.total-cb.pagado) AS pagado, " _
            & " TRIM(CONCAT(i.direccion,' BARRIO:',i.barrio)) AS nomnit,  CAST(CONCAT(RIGHT(cb.fecha,2),'/',MID(cb.fecha,6,2),'/',LEFT(cb.fecha,4)) AS CHAR(15)) AS nitc, " _
            & " c.deposito- c.mov_deposito AS subtotal," _
            & "IF( c.mes_act=0, 'NINGUNO', " _
            & "(CASE mes_act -1 " _
            & " WHEN 0 THEN 'NINGUNO' " _
            & " WHEN 1 THEN 'ENERO'" _
            & " WHEN 2 THEN 'FEBRERO' " _
            & "WHEN 3 THEN 'MARZO' " _
            & "WHEN 4 THEN 'ABRIL' " _
            & "WHEN 5 THEN 'MAYO' " _
            & "WHEN 6 THEN 'JUNIO' " _
            & "WHEN 7 THEN 'JULIO' " _
            & "END ) )AS concepto, if(c.cont_dp='SI',doc_dep,'') as ctasubtotal  " _
            & "FROM inmuebles i, contrato_inm c, cobdpen cb " _
            & "WHERE c.cod_contra ='" & cod & "' AND c.cod_inm=i.codigo AND cb.descrip = '" & cod & "' "

            '....

            Dim toc As New DataTable
            myCommand.CommandText = "SELECT  *  " _
                          & "FROM otcon_contrato" _
                          & " WHERE codcon = '" & txtcontrato.Text & "' AND contb <> 'S' " _
                          & " ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(toc)
            Refresh()
            Dim desO As String = ""
            Dim valorO As String = ""
            Dim afectaO As String = ""
            If toc.Rows.Count > 0 Then
                For l = 0 To toc.Rows.Count - 1
                    desO = desO & toc.Rows(l).Item("descr") & vbCrLf
                    valorO = valorO & Moneda(toc.Rows(l).Item("tipo") & toc.Rows(l).Item("valor")) & vbCrLf
                    afectaO = afectaO & toc.Rows(l).Item("tcli") & vbCrLf

                    'cbsr.Items.Add(toc.Rows(l).Item("tipo"))
                    'cbconcepto.Items.Add(toc.Rows(l).Item("descr"))
                    'cbvalor.Items.Add(Moneda(toc.Rows(l).Item("valor")))
                    'cbcta.Items.Add(toc.Rows(l).Item("cta"))
                    'cbbase.Items.Add(toc.Rows(l).Item("base"))
                    'cbtcli.Items.Add(toc.Rows(l).Item("tcli"))
                Next
            End If

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportContrato.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prcont As New ParameterField
                Dim Prinm As New ParameterField
                Dim Prpro As New ParameterField
                Dim Prarr As New ParameterField
                Dim Prcoarr As New ParameterField
                Dim Prfini As New ParameterField
                Dim Prffin As New ParameterField
                Dim Prvalor As New ParameterField
                Dim Prmto As New ParameterField
                Dim Prval As New ParameterField
                Dim PrDO As New ParameterField
                Dim PrVO As New ParameterField
                Dim PrAO As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields
                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)
                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)
                Prcont.Name = "contrato"
                Prcont.CurrentValues.AddValue(txtcontrato.Text.ToString)
                Prinm.Name = "inmueble"
                Prinm.CurrentValues.AddValue(txtinm.Text.ToString)
                Prpro.Name = "prop"
                Prpro.CurrentValues.AddValue(txtdueño.Text.ToString & "-" & txtnomdu.Text.ToString)
                Prarr.Name = "arre"
                Prarr.CurrentValues.AddValue(txtarre.Text.ToString & "-" & txtnomarr.Text.ToString)
                Prcoarr.Name = "coarre"
                Prcoarr.CurrentValues.AddValue(txtco.Text.ToString & "-" & txtnomco.Text.ToString)
                Prfini.Name = "fini"
                Prfini.CurrentValues.AddValue(txtf1.Text.ToString)
                Prffin.Name = "ffin"
                Prffin.CurrentValues.AddValue(txtf2.Text.ToString)
                Prvalor.Name = "vcont"
                Prvalor.CurrentValues.AddValue(txtvalor.Text.ToString)
                Prmto.Name = "vmto"
                Prmto.CurrentValues.AddValue(txtvmto.Text.ToString)
                Prval.Name = "vacue"
                Prval.CurrentValues.AddValue(txtdep.Text.ToString)
                PrDO.Name = "desO"
                PrDO.CurrentValues.AddValue(desO)
                PrVO.Name = "valorO"
                PrVO.CurrentValues.AddValue(valorO)
                PrAO.Name = "afectaO"
                PrAO.CurrentValues.AddValue(afectaO)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prcont)
                prmdatos.Add(Prinm)
                prmdatos.Add(Prpro)
                prmdatos.Add(Prarr)
                prmdatos.Add(Prcoarr)
                prmdatos.Add(Prffin)
                prmdatos.Add(Prfini)
                prmdatos.Add(Prval)
                prmdatos.Add(Prvalor)
                prmdatos.Add(Prmto)
                prmdatos.Add(PrDO)
                prmdatos.Add(PrVO)
                prmdatos.Add(PrAO)

                FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmVisorInformes.ShowDialog()

            Catch ex As Exception
            End Try
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error al generar el documento , " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try


    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        MiConexion(bda)
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If txtcontrato.Text <> "" Then
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT periodo FROM contrato_inm WHERE cod_contra='" & txtcontrato.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                If tabla.Rows(0).Item(0) = "" Then
                    Eliminar()
                Else
                    MsgBox("El Contrato No se puede eliminar porque se han generado cobros ", MsgBoxStyle.Information, "SAE Control")
                End If
            Else
                MsgBox("Seleccione el contrato a eliminar", MsgBoxStyle.Information, "SAE Control")
            End If
        End If
        Cerrar()
    End Sub
    Private Sub Eliminar()

        Try

            Dim resultado As MsgBoxResult
            resultado = MsgBox("El contrato " & txtcontrato.Text & " se van ha eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM contrato_inm WHERE cod_contra='" & txtcontrato.Text & "';"
                myCommand.ExecuteNonQuery()

                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE inmuebles SET estado='DISPONIBLE' WHERE codigo='" & txtinm.Text & "';"
                myCommand.ExecuteNonQuery()
                MsgBox("El documeto fué eliminado correctamente.  ", MsgBoxStyle.Information, "SAE Control")
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el contrato " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub

    Private Sub txtco2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco2.DoubleClick
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='CO-ARRENDATARIO'  and tr.nit = '" & txtco2.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtco.Text = ""
            txtnomco.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Co-Arrendatario"
                FrmSelDueño.lbform.Text = "contratoC2"
                FrmSelDueño.txtclase.Text = "CO-ARRENDATARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtco2.Text = tabla.Rows(0).Item("nit")
            txtnomco2.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txtco2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtco2.KeyPress
        ValidarNIT(txtco2, e)
    End Sub

    Private Sub txtco2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco2.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE tr.clase ='CO-ARRENDATARIO'  and tr.nit = '" & txtco2.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtco.Text = ""
            txtnomco.Text = ""
            'Try
            '    FrmSelDueño.Text = "Seleccionar Co-Arrendatario"
            '    FrmSelDueño.lbform.Text = "contratoC2"
            '    FrmSelDueño.txtclase.Text = "CO-ARRENDATARIO"
            '    FrmSelDueño.ShowDialog()
            'Catch ex As Exception
            'End Try
        Else
            txtco2.Text = tabla.Rows(0).Item("nit")
            txtnomco2.Text = tabla.Rows(0).Item("nom")
        End If
    End Sub

    Private Sub txtco2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtco2.TextChanged
        If txtco2.Text = "" Then
            txtnomco2.Text = ""
        End If
    End Sub


    Private Sub txtretc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretc.LostFocus
        If txtretc.Text = "" Then
            txtretc.Text = Moneda(0)
        Else
            txtretc.Text = Moneda(txtretc.Text)
        End If
    End Sub

    Private Sub txtcta_rtc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_rtc.DoubleClick
        Try
            FrmCuentas.lbform.Text = "contratortc"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_rtc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_rtc.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConceptos.Click
        If txtcontrato.Text = "" Then
            MsgBox("Verifique el Codigo del Contrato", MsgBoxStyle.Information, "Verificar")
            Exit Sub
        End If

        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmOtrosccInm.grilla.Enabled = True
            FrmOtrosccInm.grilla.RowCount = 3
        Else
            FrmOtrosccInm.grilla.Enabled = False
        End If

        Try
            FrmOtrosccInm.grilla.Rows.Clear()
            FrmOtrosccInm.grilla.RowCount = cbsr.Items.Count + 2
            For j = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(j).ToString) <> "" Then
                    FrmOtrosccInm.grilla.Item("num", j).Value = j
                    FrmOtrosccInm.grilla.Item("sel", j).Value = True
                    FrmOtrosccInm.grilla.Item("tipo", j).Value = cbsr.Items.Item(j)
                    FrmOtrosccInm.grilla.Item("txt", j).Value = cbconcepto.Items.Item(j)
                    FrmOtrosccInm.grilla.Item("valor", j).Value = Moneda(cbvalor.Items.Item(j))
                    FrmOtrosccInm.grilla.Item("base", j).Value = Moneda(cbbase.Items.Item(j))
                    FrmOtrosccInm.grilla.Item("cta", j).Value = cbcta.Items.Item(j)
                    FrmOtrosccInm.grilla.Item("afecta", j).Value = cbtcli.Items.Item(j)
                    FrmOtrosccInm.grilla.Item("dia", j).Value = cbDia.Items.Item(j)
                    'If cbCont.Items.Item(j) = "N" Then
                    '    FrmOtrosccInm.grilla.Item("cont", j).Value = False
                    'Else
                    '    FrmOtrosccInm.grilla.Item("cont", j).Value = True
                    'End If
                    If cbCont.Items.Item(j) = "N" Then
                        FrmOtrosccInm.grilla.Item("cont2", j).Value = "SOLO FACT"
                    ElseIf cbCont.Items.Item(j) = "D" Then
                        FrmOtrosccInm.grilla.Item("cont2", j).Value = "CONT-FACT"
                    ElseIf cbCont.Items.Item(j) = "S" Then
                        FrmOtrosccInm.grilla.Item("cont2", j).Value = "SOLO CONTB"
                    End If

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        FrmOtrosccInm.lbform.Text = "cont"
        FrmOtrosccInm.ShowDialog()

        Try
            cbconcepto.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub txtf_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtf.ValueChanged
    '    'If lbestado.Text <> "CONSULTA" Then
    '    '    txtf.Text = txtf1.Text
    '    'End If
    'End Sub
End Class