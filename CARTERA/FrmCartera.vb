Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Public Class FrmCartera


    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MiConexion("sae")
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) <= 0 Then
            MsgBox("No hay compañias creadas. Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            Exit Sub
        End If
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "conta"
        FrmAbrirCompania.ShowDialog()
        MiConexion(bda)
        Cerrar()
    End Sub


    Private Sub cmdperio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperio.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
    End Sub

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Cartera.pdf"
        Try
            If (ruta IsNot Nothing) Then
                FrmAyuda.pdf.LoadFile(ruta)
                FrmAyuda.Show()
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            AbrirArchivo(ruta)
        End Try

    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub cmdsaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldo.Click
        MiConexion(bda)
        Cerrar()
        FrmFacturasPendientes.ShowDialog()
    End Sub

    Public Sub cmddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddoc.Click
        MiConexion(bda)
        Cerrar()
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = " SELECT * FROM car_par LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
                frmparametroscartera.lb.Text = "NUEVO"
                frmparametroscartera.txttipo1.Text = ""
                frmparametroscartera.txttipo2.Text = ""
                frmparametroscartera.txttipo3.Text = ""
                frmparametroscartera.txttipo4.Text = ""
                frmparametroscartera.txtajust.Text = ""
                frmparametroscartera.txtrc.Text = ""
                frmparametroscartera.txtrcc.Text = ""

                '***************************************
                frmparametroscartera.rbcont2.Checked = True
                '***************************************

                frmparametroscartera.txtcaja.Text = ""
                frmparametroscartera.txtbanco.Text = ""
                frmparametroscartera.txtctapc.Text = ""
                frmparametroscartera.txtretencion.Text = ""
                frmparametroscartera.txtventas.Text = ""
                frmparametroscartera.txtivapp.Text = ""
                frmparametroscartera.txtdescuento.Text = ""
                frmparametroscartera.txtretencion.Text = ""
                '**********************************************
                frmparametroscartera.txtmonto.Text = "0,00"
                frmparametroscartera.txtmora.Text = ""
                frmparametroscartera.cbint.Text = "NO"
                frmparametroscartera.ShowDialog()
                Exit Sub
            End If
            frmparametroscartera.lb.Text = ""
            frmparametroscartera.txttipo1.Text = tabla.Rows(0).Item("par_fac1")
            frmparametroscartera.txttipo2.Text = tabla.Rows(0).Item("par_fac2")
            frmparametroscartera.txttipo3.Text = tabla.Rows(0).Item("par_fac3")
            frmparametroscartera.txttipo4.Text = tabla.Rows(0).Item("par_fac4")
            frmparametroscartera.txtajust.Text = tabla.Rows(0).Item("par_aju")
            frmparametroscartera.txtrc.Text = tabla.Rows(0).Item("par_rc")
            frmparametroscartera.txtrcc.Text = tabla.Rows(0).Item("par_ci")
            '**********************************************
            frmparametroscartera.txtmonto.Text = tabla.Rows(0).Item("mon_int").ToString.Replace(".", ",")
            frmparametroscartera.txtmora.Text = tabla.Rows(0).Item("cta_mor").ToString
            frmparametroscartera.cbint.Text = tabla.Rows(0).Item("hay_int").ToString
            frmparametroscartera.cbtipoint.Text = tabla.Rows(0).Item("tip_int").ToString
            '************************************************

            If tabla.Rows(0).Item("par_int") = "SI" Then
                Try
                    frmparametroscartera.rbcont1.Checked = True
                    frmparametroscartera.txtcaja.Text = tabla.Rows(0).Item("par_cta_caja")
                    frmparametroscartera.txtbanco.Text = tabla.Rows(0).Item("par_cta_ban")
                    frmparametroscartera.txtctapc.Text = tabla.Rows(0).Item("par_cta_cco")
                    frmparametroscartera.txtventas.Text = tabla.Rows(0).Item("par_cta_ven")
                    frmparametroscartera.txtivapp.Text = tabla.Rows(0).Item("par_cta_iva")
                    frmparametroscartera.txtdescuento.Text = tabla.Rows(0).Item("par_cta_des")
                    frmparametroscartera.txtretencion.Text = tabla.Rows(0).Item("par_cta_ret")
                Catch ex As Exception
                End Try
            ElseIf tabla.Rows(0).Item("par_int") = "NO" Then
                frmparametroscartera.rbcont2.Checked = True
            End If
            If tabla.Rows(0).Item("concomi") = "NO" Then
                frmparametroscartera.rbcc2.Checked = True
            Else
                frmparametroscartera.rbccS.Checked = True
            End If
            If tabla.Rows(0).Item("editarcc") = "NO" Then
                frmparametroscartera.cheditar.Checked = False
            Else
                frmparametroscartera.cheditar.Checked = True
            End If
            frmparametroscartera.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonX20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        Frmestadisticaedades.ShowDialog()
    End Sub


    Private Sub cmd_OtrosIngresos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_OtrosIngresos.Click
        MiConexion(bda)
        Cerrar()
        CrearTablaOT_DOC()
        FrmCompIngresos.Chcredito.Visible = True
        FrmCompIngresos.ShowDialog()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub
    '************************************
    Private Sub cmd_SaldoIniciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_SaldoIniciales.Click
        MiConexion(bda)
        Cerrar()
        FrmSaldosInicialesCartera.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ven_plan.Click
        MiConexion(bda)
        Cerrar()
        FrmMovCartera.ShowDialog()
    End Sub

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        'FrmVentasCartera.ShowDialog()
    End Sub

    Private Sub cmdgenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgenerar.Click
        MiConexion(bda)
        Cerrar()
        FrmReciboCartera.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ven_est.Click
        MiConexion(bda)
        Cerrar()
        FrmEstadoCuentas.ShowDialog()
    End Sub
    'consultas
    Private Sub cmd_con_fac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmConUnaFC.ShowDialog()
    End Sub
    Private Sub cmd_con_con_fac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_con_ciu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_con_mora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_con_cto_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_con_res_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'movimientos
    Private Sub cmd_mov_cli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_mov_ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_mov_rec_car_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_mov_otros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    '**************************************

    Private Sub FrmCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion("sae")
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        'If tabla.Rows(0).Item(0) = "S" Then
        '    cmddes.Visible = True
        'Else
        '    cmddes.Visible = False
        'End If
        Cerrar()

        'If FrmPrincipal.lbuser.Text = "sae" Then
        '    cmddes.Visible = True
        'Else
        '    cmddes.Visible = False
        'End If
        MiConexion(bda)
        Try
            myCommand.CommandText = "ALTER TABLE `car_par` ADD `hay_int` VARCHAR( 2 ) NOT NULL DEFAULT 'NO' COMMENT '¿se cobran intereses moratorios?'," _
                                  & "ADD `mon_int` decimal(10,6) NOT NULL DEFAULT '0' COMMENT 'monto del interes moratorio'," _
                                  & "ADD `tip_int` VARCHAR( 10 ) NOT NULL DEFAULT 'diario' COMMENT 'tipo de interes moratorio'," _
                                  & "ADD `cta_mor` VARCHAR( 18 ) NOT NULL COMMENT 'cta intereses moratorios';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Cerrar()
        If FrmPrincipal.Facturacion.Enabled = True Then
            cmdsaldo.Enabled = True
        Else
            cmdsaldo.Enabled = False
        End If
    End Sub

    Private Sub cmd_ven_clie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ven_clie.Click
        MiConexion(bda)
        Cerrar()
        FrmConUnaFC.ShowDialog()
    End Sub

    Private Sub cmd_ven_ven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmddes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub ButtonX1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmAnalisisVencimiento.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmClientMora.ShowDialog()
    End Sub

    Private Sub cmd_conp_fac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_conp_fac.Click
        MiConexion(bda)
        Cerrar()
        FrmConcpFac.ShowDialog()
    End Sub

    Private Sub cmd_car_ciud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_car_ciud.Click
        MiConexion(bda)
        Cerrar()
        FrmCarxCiu.ShowDialog()
    End Sub

    Private Sub cmdbalgral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbalgral.Click

        Dim p As String = ""
        p = PerActual(0).ToString() & PerActual(1).ToString

        If p = "12" Then

            Dim resultado As MsgBoxResult

            resultado = MsgBox(" ¿Desea realizar el cierre anual de cartera? ", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then

                Dim conexion As New MySqlConnection
                Dim cadena As String
                cadena = datosconR(bda)
                conexion.ConnectionString = cadena
                conexion.Open()

                Dim b As String = ""
                Dim c As String = ""
                Dim f As String = ""
                Dim fp As String = ""
                Dim sql As String = ""
                Dim sql2 As String = ""
                b = Strings.Right(bda, 4)
                b = b + 1

                c = "sae" & CompaniaActual & b
                Dim tabla As New DataTable
                myCommand.CommandText = "show databases like '" & c & "'"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()

                If tabla.Rows.Count > 0 Then

                    sql2 = "select doc, tipo, num, descrip, tipafec, clasaju, nitc, nomnit, nitcod, nitv, " _
                    & "  fecha  , vmto, concepto, subtotal, descto, ret, iva, v_viva, total, ctasubtotal, ctaret, " _
                    & "ctaiva, ctatotal, ccosto, otroimp, retiva, ctaretiva, retica, ctaretica, pagado, rcpos, " _
                    & " DATE_FORMAT(fechpos, '%Y-%m-%y') as fechpos, vpos, tasa, moneda, monloex, estado, salmov, pagare " _
                    & " FROM cobdpen where pagado < total"

                    Dim tabla2 As DataTable
                    tabla2 = New DataTable
                    myCommand.CommandText = sql2
                    myCommand.Connection = conexion
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla2)
                    Refresh()

                    For i = 0 To tabla2.Rows.Count - 1
                        Try

                            f = " '" & Strings.Right(tabla2.Rows(i).Item("fecha").ToString, 4) & Strings.Mid(tabla2.Rows(i).Item("fecha").ToString, 4, 2) & Strings.Left(tabla2.Rows(i).Item("fecha").ToString, 2) & "'   "
                            fp = " '" & Strings.Right(tabla2.Rows(i).Item("fechpos").ToString, 4) & Strings.Mid(tabla2.Rows(i).Item("fechpos").ToString, 4, 2) & Strings.Left(tabla2.Rows(i).Item("fechpos").ToString, 2) & "'   "

                            sql = " '" & tabla2.Rows(i).Item("doc") & "', '" & tabla2.Rows(i).Item("tipo") & "' , '" & tabla2.Rows(i).Item("num") & "', '" & tabla2.Rows(i).Item("descrip") & "', '" & tabla2.Rows(i).Item("tipafec") & "', '" & tabla2.Rows(i).Item("clasaju") & "', " _
                            & "  '" & tabla2.Rows(i).Item("nitc") & "', '" & tabla2.Rows(i).Item("nomnit") & "',  " _
                            & " '" & tabla2.Rows(i).Item("nitcod") & "' , '" & tabla2.Rows(i).Item("nitv") & "' ,  " _
                            & "  " & f & " " _
                            & " , '" & tabla2.Rows(i).Item("vmto") & "' , '" & tabla2.Rows(i).Item("concepto") & "', '" & DIN(tabla2.Rows(i).Item("subtotal")) & "', " _
                            & " '" & DIN(tabla2.Rows(i).Item("descto")) & "', '" & DIN(tabla2.Rows(i).Item("ret")) & "', '" & DIN(tabla2.Rows(i).Item("iva")) & "', " _
                            & " '" & DIN(tabla2.Rows(i).Item("v_viva")) & "', '" & DIN(tabla2.Rows(i).Item("total")) & "', '" & tabla2.Rows(i).Item("ctasubtotal") & "', " _
                            & " '" & tabla2.Rows(i).Item("ctaret") & "', '" & tabla2.Rows(i).Item("ctaiva") & "', '" & tabla2.Rows(i).Item("ctatotal") & "' , " _
                            & " '" & tabla2.Rows(i).Item("ccosto") & "', '" & tabla2.Rows(i).Item("otroimp") & "', '" & DIN(tabla2.Rows(i).Item("retiva")) & "', " _
                            & " '" & tabla2.Rows(i).Item("ctaretiva") & "', '" & DIN(tabla2.Rows(i).Item("retica")) & "', '" & tabla2.Rows(i).Item("ctaretica") & "', " _
                            & " '" & DIN(tabla2.Rows(i).Item("pagado")) & "', '" & tabla2.Rows(i).Item("rcpos") & "', " & fp & ", " _
                            & " '" & DIN(tabla2.Rows(i).Item("vpos")) & "', '" & DIN(tabla2.Rows(i).Item("tasa")) & "', '" & tabla2.Rows(i).Item("moneda") & "', " _
                            & " '" & tabla2.Rows(i).Item("monloex") & "', '" & tabla2.Rows(i).Item("estado") & "', '" & tabla2.Rows(i).Item("salmov") & "', '" & tabla2.Rows(i).Item("pagare") & "' "

                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "  INSERT INTO " & c & ".cobdpen ( doc, tipo, num, descrip, tipafec, clasaju, nitc, nomnit, nitcod, nitv, fecha, vmto, concepto, " _
                            & "subtotal, descto, ret, iva, v_viva, total, ctasubtotal, ctaret, ctaiva, ctatotal, ccosto, otroimp, retiva, ctaretiva, retica, ctaretica, " _
                            & " pagado, rcpos, fechpos, vpos, tasa, moneda, monloex, estado, salmov, pagare) VALUES  ( " & sql & ") "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            ' MsgBox(ex.ToString)
                        End Try
                    Next
                    MsgBox("El proceso se realizo satisfactoriamente")
                Else
                    MsgBox("Debe crear el nuevo año")
                End If
            End If

        Else
            MsgBox("Este proceso solo puede realizar en el Periodo N° 12")
        End If

    End Sub

    Private Sub cmdestres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdestres.Click
        MiConexion(bda)
        Cerrar()
        FrmActSal.ShowDialog()
    End Sub

    Private Sub cmdAp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub cmdMC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMC.Click
        MiConexion(bda)
        Cerrar()
        FrmMovCli.ShowDialog()
    End Sub

    Private Sub cmdRecC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecC.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoReciboCartera.ShowDialog()
    End Sub

    Private Sub cmdAp_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAp.Click
        MiConexion(bda)
        Cerrar()
        FrmAprCart.ShowDialog()
    End Sub

    Private Sub cmddes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCartera.ShowDialog()
    End Sub

    Private Sub cmdfactnormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactnormal.Click
        MiConexion(bda)
        Cerrar()

        Try
            MiConexion(bda)
            Dim tabla As New DataTable
            myCommand.CommandText = " SELECT * FROM car_par LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                If tabla.Rows(0).Item("concomi") = "NO" Then
                    MsgBox("Usted No maneja Comisiones por Recaudo", MsgBoxStyle.Information, "Verificacion")
                Else
                    FrmConcomiCart.ShowDialog()
                End If
            End If
            Cerrar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        FrmConceptosComicionables.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmInfCartComision.ShowDialog()
    End Sub
End Class