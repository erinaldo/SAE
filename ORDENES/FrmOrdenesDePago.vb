Public Class FrmOrdenesDePago

    Private Sub cmdgenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgenerar.Click
        MiConexion(bda)
        Cerrar()
        FrmOrdenPagos.Show()
    End Sub

    Private Sub FrmOrdenesDePago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion("sae")
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap, rol from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows(0).Item(0) = "S" Then
            cmddesa.Visible = True
        Else
            cmddesa.Visible = False
        End If
        Cerrar()


        MiConexion(bda)
        ord_pagos(bda)
        Cerrar()
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

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
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
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdCPP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCPP.Click
        MiConexion(bda)
        Cerrar()
        FrmCompEgreCpp.ShowDialog()
    End Sub

    Private Sub cmdOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOt.Click
        If FrmPrincipal.Contabilidad.Enabled = False Then
            MsgBox("No tiene permisos para la interfaz de contabilidad.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmComEgresoCpp.ShowDialog()
    End Sub

    Private Sub cmd_cpp_inf_pro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cpp_inf_pro.Click
        MiConexion(bda)
        Cerrar()
        'FrmCPPinfoProv.ShowDialog()
        FrmVentasCartera.ShowDialog()
    End Sub

    Private Sub cmd_analisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_analisis.Click
        MiConexion(bda)
        Cerrar()
        FrmAnalisisCPP.ShowDialog()
    End Sub

    Private Sub cmd_plan_pagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_plan_pagos.Click
        MiConexion(bda)
        Cerrar()
        FrmPlanPagoCPP.ShowDialog()
    End Sub

    Private Sub cmd_comp_cpp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_comp_cpp.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoCompCPP.ShowDialog()
    End Sub

    Private Sub cmd_g_o_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_g_o.Click
        If FrmPrincipal.Contabilidad.Enabled = False Then
            MsgBox("No tiene permisos para la interfaz de contabilidad.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmInfoCompGasOtros.ShowDialog()
    End Sub

    Private Sub cdmlibmay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmlibmay.Click
        'ModificarNumCE()
        FrmInformeCC.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmInforOrdenes.ShowDialog()
    End Sub

    Private Sub cmdEgresoOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEgresoOrden.Click
        MiConexion(bda)
        Cerrar()
        FrmNuevoEgreso.Show()
    End Sub

    Private Sub cmddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddoc.Click
        MiConexion(bda)
        Cerrar()
        Try
            FrmParOrdenes.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmRepDatos.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmModCausaPresu.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmInfDeducciones.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MiConexion(bda)
        Cerrar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Desea ingresar los movimientos a presupuesto?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            LLenarMovPresupuestoGas()

        End If

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        MiConexion(bda)
        Cerrar()
        FrmPOrdOt.ShowDialog()
    End Sub

    Private Sub ButtonX7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX7.Click
        If FrmPrincipal.Contabilidad.Enabled = False Then
            MsgBox("No tiene permisos para la interfaz de contabilidad.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmCIordenes.ShowDialog()
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        If FrmPrincipal.Contabilidad.Enabled = False Then
            MsgBox("No tiene permisos para la interfaz de contabilidad.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmEgresoNomina.ShowDialog()
    End Sub

    Private Sub cmddesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddesa.Click
        MiConexion(bda)
        Cerrar()
        FrmDesapCEOrden.ShowDialog()
    End Sub

    Private Sub ButtonX8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX8.Click
        MiConexion(bda)
        Cerrar()
        FrmInfEgreRubro.ShowDialog()
    End Sub
End Class