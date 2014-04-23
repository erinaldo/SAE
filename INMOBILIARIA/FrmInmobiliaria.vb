Public Class FrmInmobiliaria

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        FrmClasiTerceros.ShowDialog()
    End Sub

    Private Sub FrmInmobiliaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)
        Inmobiliaria(bda)
        Cerrar()

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT rol FROM  sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        If tb.Rows(0).Item(0) <> "admin" Then
            TabParametro.Visible = False
        Else
            TabParametro.Visible = True
        End If

    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmInmueble.ShowDialog()
    End Sub

    Private Sub btcontrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "factura"
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
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmEst_Cuen_Inm.ShowDialog()
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        MiConexion(bda)
        Cerrar()
        FrmParInmob.ShowDialog()
    End Sub

    Private Sub ButtonX6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        BuscarPeriodo()
        FrmCierreInm.ShowDialog()
    End Sub

    Private Sub cmd_inf_cla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inf_cla.Click
        MiConexion(bda)
        Cerrar()
        FrmInfTercerosInm.ShowDialog()
    End Sub

    Private Sub cmd_if_inm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_if_inm.Click
        MiConexion(bda)
        Cerrar()
        FrmInfInmuebles.ShowDialog()
    End Sub

    Private Sub cmd_inf_cont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inf_cont.Click
        MiConexion(bda)
        Cerrar()
        FrmInfContratos.ShowDialog()
    End Sub

    
    Private Sub cmdRecArr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecArr.Click
        MiConexion(bda)

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT hay_int FROM car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows(0).Item(0) = "NO" Then
            MsgBox("Recuerde Definir el porcentaje del interes a cobrar en los parametros de Cartera ", MsgBoxStyle.Information, "Informacion")
        End If
        Cerrar()
        FrmReciboCartera.ShowDialog()
    End Sub

    Private Sub cmdNov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNov.Click
        MiConexion(bda)
        Cerrar()
        FrmComEgresoCpp.ShowDialog()
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        MiConexion(bda)
        Cerrar()
        FrmEst_Cuen_Prop.ShowDialog()
    End Sub

    Private Sub btcontrato_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcontrato.Click
        MiConexion(bda)
        Cerrar()
        FrmContratos.ShowDialog()
    End Sub

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        MiConexion(bda)
        Cerrar()
        FrmCompEgreCpp.ShowDialog()
    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click
        MiConexion(bda)
        Cerrar()
        FrmCompIngresos.ShowDialog()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub BServicios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BServicios.Click
        MiConexion(bda)
        Cerrar()
        FrmPagosServicios.ShowDialog()
    End Sub

    Private Sub ButtonX10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX10.Click
        MiConexion(bda)
        Cerrar()
        FrmInmueblesTipos.ShowDialog()
    End Sub

    
    Private Sub BNovedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNovedades.Click
        MiConexion(bda)
        Cerrar()
        FrmNovedadInm.ShowDialog()
    End Sub

  
    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX11.Click
        MiConexion(bda)
        Cerrar()
        FrmGaleriaInm.ShowDialog()
    End Sub

    Private Sub cmdPagosServ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPagosServ.Click
        MiConexion(bda)
        Cerrar()
        FrmInfPagoServ.ShowDialog()
    End Sub

    Private Sub BconInm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BconInm.Click
        MiConexion(bda)
        Cerrar()
        FrmConsultaInm.ShowDialog()
    End Sub

    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX12.Click
        MiConexion(bda)
        Cerrar()
        FrmSaldosIniInm.ShowDialog()
    End Sub

    Private Sub ButtonX13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX13.Click
        MiConexion(bda)
        Cerrar()
        FrmAnulaFI.ShowDialog()
    End Sub

    Private Sub ButtonX14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX14.Click
        MiConexion(bda)
        Cerrar()
        FrmInfNovedades.ShowDialog()
    End Sub

    Private Sub BFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFact.Click
        MiConexion(bda)
        Cerrar()
        FrmInfFacInm.ShowDialog()
    End Sub

    Private Sub FrmServPub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FrmServPub.Click
        MiConexion(bda)
        Cerrar()
        FrmInfServPub.ShowDialog()
    End Sub

    Private Sub ButtonX15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX15.Click
        MiConexion(bda)
        Cerrar()
        FrmInfSerInm.ShowDialog()
    End Sub

    Private Sub ButtonX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX16.Click
        MiConexion(bda)
        Cerrar()
        FrmInfOtconcp.ShowDialog()
    End Sub
End Class