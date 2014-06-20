Public Class FrmContabilidad
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

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

    Private Sub cmddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddoc.Click
        MiConexion(bda)
        Cerrar()
        FrmDocumentos.ShowDialog()
    End Sub

    Private Sub cmdfactnormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactnormal.Click
        MiConexion(bda)
        Cerrar()
        NivelesDeCuentas()
        FrmParContable.ShowDialog()
    End Sub

    Private Sub cmdgenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgenerar.Click
        MiConexion(bda)
        Cerrar()
        FrmEntradaDatos.ShowDialog()
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcc.Click
        MiConexion(bda)
        Cerrar()
        FrmInformeCC.ShowDialog()
    End Sub

    Private Sub cmdsaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldo.Click
        MiConexion(bda)
        Cerrar()
        Dim tablabloq As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".bloq_per WHERE periodo='00' ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablabloq)
        If tablabloq.Rows(0).Item(1) <> "n" Then
            FrmSaldosIniciales.cmdbloquear.Enabled = False
        Else
            FrmSaldosIniciales.cmdbloquear.Enabled = True
        End If
        FrmSaldosIniciales.ShowDialog()
    End Sub

    Private Sub cmdactcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactcc.Click
        MiConexion(bda)
        Cerrar()
        BuscarPeriodo()
        FrmActualizarCC.lbper.Text = PerActual
        FrmActualizarCC.txtano.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        FrmActualizarCC.txtano2.Text = FrmActualizarCC.txtano.Text
        FrmActualizarCC.ShowDialog()
    End Sub

    Private Sub cmdbloper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbloper.Click
        MiConexion(bda)
        Cerrar()
        FrmBloquearPeriodos.ShowDialog()
    End Sub

    Private Sub cmdfinano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfinano.Click
        MiConexion(bda)
        Cerrar()
        FrmCierreAno.ShowDialog()
    End Sub

    Private Sub cdmadapPUC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmadapPUC.Click
        MiConexion(bda)
        Cerrar()
        Me.Cursor = Cursors.WaitCursor
        FrmAdaptacionPUC.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdcatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcatalogo.Click
        MiConexion(bda)
        Cerrar()
        FrmCatalogoC.ShowDialog()
    End Sub

    Private Sub cmdbalgra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbalgra.Click
        MiConexion(bda)
        Cerrar()
        FrmBalanceGral.lbform.Text = "BG"
        FrmBalanceGral.ShowDialog()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "EXPLORADOR WEB"
        FrmWEB.ShowDialog()
    End Sub
    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cdmlibmay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmlibmay.Click
        MiConexion(bda)
        Cerrar()
        FrmLibroMayor.ShowDialog()
    End Sub

    Private Sub cdmestres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmestres.Click
        MiConexion(bda)
        Cerrar()
        FrmEstadoResultados.cmdpantalla.Visible = True
        FrmEstadoResultados.pdf.Visible = False
        FrmEstadoResultados.Label2.Visible = True
        FrmEstadoResultados.Label1.Visible = True
        FrmEstadoResultados.Label6.Visible = True
        FrmEstadoResultados.Label7.Visible = False
        FrmEstadoResultados.txtpfin.Visible = True
        FrmEstadoResultados.cbfin.Visible = True
        FrmEstadoResultados.ChCierre.Visible = True
        FrmEstadoResultados.ShowDialog()
    End Sub

    Private Sub cmdPB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPB.Click
        MiConexion(bda)
        Cerrar()
        FrmBalancePrueba.ShowDialog()
    End Sub
    Private Sub cmdTri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTri.Click
        MiConexion(bda)
        Cerrar()
        FrmInfTributarios.ShowDialog()
    End Sub

    Private Sub cmdanexosB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanexosB.Click
        MiConexion(bda)
        Cerrar()
        FrmLibroDiario.ShowDialog()
        ' FrmAnexosBalance.ShowDialog()
    End Sub
    Private Sub cmdbalgral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmBalanceGral.ShowDialog()
    End Sub
    Private Sub cmdestres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmEstadoResultados.ShowDialog()
    End Sub

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Contable.pdf"
        Try
            If (ruta IsNot Nothing) Then
                Try
                    AbrirArchivo(ruta)
                Catch ex As Exception
                    AbrirArchivo(ruta)
                End Try
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cdmcentro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmcentro.Click
        Try
            MiConexion(bda)
            Cerrar()
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") = "N" Then
                MsgBox("Usted no esta trabajando con centro de costos.   ", MsgBoxStyle.Information, "SAE Control")
            Else
                FrmCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Verifique parametros de contabilidad." & ex.ToString, MsgBoxStyle.Information, "SAE Control")
        End Try
    End Sub
    Private Sub cmdinfo_c_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinfo_c_c.Click
        Try
            MiConexion(bda)
            Cerrar()
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") = "N" Then
                MsgBox("Usted no esta trabajando con centro de costos.   ", MsgBoxStyle.Information, "SAE Control")
            Else
                FrmInformesCentroCosto.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Verifique parametros de contabilidad." & ex.ToString, MsgBoxStyle.Information, "SAE Control")
        End Try
    End Sub

    Private Sub FrmContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmdgenerar.Focus()
        If FrmPrincipal.LbPeriodo.Text = "(ninguno)" Then
            FrmPeriodo.lbactual.Text = PerActual
            FrmPeriodo.ShowDialog()
        Else
            BuscarPeriodo()
        End If
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `centrocostos` ADD `pres` DOUBLE NOT NULL AFTER `nombre`;"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
        End Try
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS `parotdoc` (`ce` VARCHAR( 4 ) NOT NULL,`ci` VARCHAR( 4 ) NOT NULL ,`rc` VARCHAR( 4 ) NOT NULL,`nd` VARCHAR( 4 ) NOT NULL ,`nc` VARCHAR( 4 ) NOT NULL ,`cd` VARCHAR( 4 ) NOT NULL ,`aj` VARCHAR( 4 ) NOT NULL);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Dim p As String = ""
        For i = 0 To 12
            If i >= 10 Then
                p = i
            Else
                p = "0" & i
            End If
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE  `documentos" & p & "` ADD  `cheque` VARCHAR( 20 ) NOT NULL AFTER  `nit` ;"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
        Cerrar()
    End Sub

    Private Sub cmdinven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinven.Click
        FrmInve_y_Balances.ShowDialog()
    End Sub

    Private Sub cmdNumPag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNumPag.Click
        FrmNumPag.ShowDialog()
    End Sub

    Private Sub cdotrosdoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdotrosdoc.Click
        FrmOtrosDocumentos.ShowDialog()
    End Sub

    Private Sub cdCopiarPUC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdCopiarPUC.Click
        FrmCopiarPUC.ShowDialog()
    End Sub

    Private Sub cmdAnti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnti.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoAnticipos.ShowDialog()
    End Sub

    Private Sub cmdMov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMov.Click
        MiConexion(bda)
        Cerrar()
        FrmInfMovContables.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmInformeCheque.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmCuentaRtCree.ShowDialog()
    End Sub

    Private Sub TabControlPanel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlPanel6.Click

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmUtilidadDiaria.ShowDialog()
    End Sub
    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        FrmInfCGN.ShowDialog()
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        MiConexion(bda)
        Cerrar()
        FrmBalanceGral.lbform.Text = "BGC"
        FrmBalanceGral.ShowDialog()
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        FrmEstadoResultados.cmdpantalla.Visible = False
        FrmEstadoResultados.ChCierre.Visible = False
        FrmEstadoResultados.pdf.Visible = True
        FrmEstadoResultados.Label2.Visible = False
        FrmEstadoResultados.Label1.Visible = False
        FrmEstadoResultados.Label6.Visible = False
        FrmEstadoResultados.Label7.Visible = True
        FrmEstadoResultados.txtpfin.Visible = False
        FrmEstadoResultados.cbfin.Visible = False
        FrmEstadoResultados.ShowDialog()
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCIordenes.ShowDialog()
    End Sub

    Private Sub ButtonX7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        FrmCuentasRubros.lbform.Text = "ctas"
        FrmCuentasRubros.ShowDialog()
    End Sub
End Class