Public Class FrmCompras

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "compras"
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
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/ ")
        FrmWEB.Text = "EXPLORADOR WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        'Dim ruta As String
        'ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Contable.pdf"
        'Try
        '    If (ruta IsNot Nothing) Then
        '        Try
        '            AbrirArchivo(ruta)
        '        Catch ex As Exception
        '            AbrirArchivo(ruta)
        '        End Try
        '    Else
        '        MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub
    '**********************************************************
    Private Sub cmdfactrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactrap.Click
        MiConexion(bda)
        Cerrar()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM par_comp LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Exit Sub
        Else
            FrmDocProveedor.txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("doc_fp").ToString) <> "" Then
                FrmDocProveedor.txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fp").ToString))
            End If
            If Trim(tabla.Rows(0).Item("doc_aj").ToString) <> "" Then
                FrmDocProveedor.txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_aj").ToString))
                FrmDocProveedor.lbdocajuste.Text = Trim(tabla.Rows(0).Item("doc_aj").ToString)
            End If
        End If
        Try
            FrmDocProveedor.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmd_ped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ped.Click
        MiConexion(bda)
        Cerrar()
        FrmOrdenCompra.ShowDialog()
    End Sub
   
    Private Sub cmd_parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_parametros.Click
        MiConexion(bda)
        Cerrar()
        Buscarpar()
        FrmParCompras.Tab1.Visible = True
        FrmParCompras.Tab2.Visible = False
        FrmParCompras.Tab3.Visible = False
        FrmParCompras.cmdatras.Enabled = False
        FrmParCompras.cmdsgt.Enabled = True
        FrmParCompras.cmdatras.Text = ""
        FrmParCompras.cmdsgt.Text = "&S"
        FrmParCompras.ShowDialog()
    End Sub
    Public Sub Buscarpar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM par_comp;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            FrmParCompras.lbpara.Visible = True
            FrmParCompras.rbcont2.Checked = True
            FrmParCompras.g_cuentas.Enabled = False
        Else
            FrmParCompras.lbpara.Visible = False
            '*************** PAGINA 1 / 3 ******************
            'documentos
            FrmParCompras.txt_fp.Text = tabla.Rows(0).Item("doc_fp")
            FrmParCompras.txt_aj.Text = tabla.Rows(0).Item("doc_aj")
            FrmParCompras.txt_cpp.Text = tabla.Rows(0).Item("doc_cpp")
            FrmParCompras.txt_gas.Text = tabla.Rows(0).Item("doc_gas")
            FrmParCompras.txt_ppf.Text = tabla.Rows(0).Item("doc_ppf")
            'interfaz contable
            If Trim(tabla.Rows(0).Item("int_con")) = "SI" Then
                FrmParCompras.rbcont1.Checked = True
                FrmParCompras.g_cuentas.Enabled = True
            Else
                FrmParCompras.rbcont2.Checked = True
                FrmParCompras.g_cuentas.Enabled = False
            End If
            'cuentas contables
            FrmParCompras.txt_cta_caja.Text = tabla.Rows(0).Item("cta_caja")
            FrmParCompras.txt_cta_banco.Text = tabla.Rows(0).Item("cta_banco")
            FrmParCompras.txt_cta_cpp.Text = tabla.Rows(0).Item("cta_cpp")
            FrmParCompras.txt_cta_gas.Text = tabla.Rows(0).Item("cta_gas")
            FrmParCompras.txt_cta_com.Text = tabla.Rows(0).Item("cta_com")
            FrmParCompras.txt_cta_desc.Text = tabla.Rows(0).Item("cta_desc")
            FrmParCompras.txt_cta_inv.Text = tabla.Rows(0).Item("cta_inv")
            FrmParCompras.txt_cta_iva_g.Text = tabla.Rows(0).Item("cta_iva_g")
            FrmParCompras.txt_por_iva_g.Text = Moneda(tabla.Rows(0).Item("por_iva_g"))
            FrmParCompras.txt_cta_iva_d.Text = tabla.Rows(0).Item("cta_iva_d")
            FrmParCompras.txt_por_iva_d.Text = Moneda(tabla.Rows(0).Item("por_iva_d"))
            FrmParCompras.txt_cta_rtf.Text = tabla.Rows(0).Item("cta_rtf")
            FrmParCompras.txt_cta_fle.Text = tabla.Rows(0).Item("cta_fle")
            FrmParCompras.txt_cta_seg.Text = tabla.Rows(0).Item("cta_seg")
            FrmParCompras.txt_cta_ppf_c.Text = tabla.Rows(0).Item("cta_ppf_c")
            FrmParCompras.txt_cta_ppf_d.Text = tabla.Rows(0).Item("cta_ppf_d")
            '*************** PAGINA 2 / 3 ******************
            If Trim(tabla.Rows(0).Item("sol_num_com")) = "SI" Then
                FrmParCompras.rb_sol_num1.Checked = True
            Else
                FrmParCompras.rb_sol_num2.Checked = True
            End If
            If Trim(tabla.Rows(0).Item("can_fact")) = "NO" Then
                FrmParCompras.rb_cant_fact1.Checked = True
            Else
                FrmParCompras.rb_cant_fact2.Checked = True
            End If
            If Trim(tabla.Rows(0).Item("fs_aum_inv")) = "SI" Then
                FrmParCompras.rb_fs1.Checked = True
            Else
                FrmParCompras.rb_fs2.Checked = True
            End If
            If Trim(tabla.Rows(0).Item("imp_ap")) = "NO" Then
                FrmParCompras.rb_imp_ap1.Checked = True
            Else
                FrmParCompras.rb_imp_ap1.Checked = True
            End If
            '*************** PAGINA 3 / 3 ******************
            'Formato pre-determinado de proveedor
            If tabla.Rows(0).Item("format_fp") = "pdf" Then
                FrmParCompras.pdffp.Checked = True
                Try
                    FrmParCompras.imgfoto.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_fp"))
                Catch ex As Exception
                    FrmParCompras.imgfoto.Image = Nothing
                End Try
            ElseIf tabla.Rows(0).Item("format_fp") = "pdf2" Then
                FrmParCompras.pdf2fp.Checked = True
                Try
                    FrmParCompras.imgfoto.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_fp"))
                Catch ex As Exception
                    FrmParCompras.imgfoto.Image = Nothing
                End Try
            Else
                FrmParCompras.ticfp.Checked = True
                FrmParCompras.imgfoto.Image = Nothing
            End If
            'Formato pre-determinado de cuentas por pagar
            If tabla.Rows(0).Item("format_cpp") = "pdf" Then
                FrmParCompras.pdfcpp.Checked = True
                Try
                    FrmParCompras.imgfoto2.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_cpp"))
                Catch ex As Exception
                    FrmParCompras.imgfoto2.Image = Nothing
                End Try
            ElseIf tabla.Rows(0).Item("format_cpp") = "pdf2" Then
                FrmParCompras.pdf2cpp.Checked = True
                Try
                    FrmParCompras.imgfoto2.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_cpp"))
                Catch ex As Exception
                    FrmParCompras.imgfoto2.Image = Nothing
                End Try
            Else
                FrmParCompras.ticcpp.Checked = True
                FrmParCompras.imgfoto2.Image = Nothing
            End If
            'Formato pre-determinado de post-fechado
            If tabla.Rows(0).Item("format_ppf") = "pdf" Then
                FrmParCompras.pdfppf.Checked = True
                Try
                    FrmParCompras.imgfoto3.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_ppf"))
                Catch ex As Exception
                    FrmParCompras.imgfoto3.Image = Nothing
                End Try
            ElseIf tabla.Rows(0).Item("format_ppf") = "pdf2" Then
                FrmParCompras.pdf2ppf.Checked = True
                Try
                    FrmParCompras.imgfoto3.Image = Bytes_Imagen(tabla.Rows(0).Item("logo_ppf"))
                Catch ex As Exception
                    FrmParCompras.imgfoto3.Image = Nothing
                End Try
            Else
                FrmParCompras.ticppf.Checked = True
                FrmParCompras.imgfoto3.Image = Nothing
            End If
            If tabla.Rows(0).Item("deci") = "S" Then
                FrmParCompras.rb_decS.Checked = True
            Else
                FrmParCompras.rb_decN.Checked = True
            End If
        End If
    End Sub

    Private Sub cmd_grupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_grupos.Click
        MiConexion(bda)
        Cerrar()
        FrmGastos.ShowDialog()
    End Sub

    Private Sub cmd_info_gru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_gru.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoGastos.ShowDialog()
    End Sub

    Private Sub cmdanular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub cmd_info_prov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_prov.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoCompProv.ShowDialog()
    End Sub

    Private Sub cmd_cpp_inf_pro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cpp_inf_pro.Click
        MiConexion(bda)
        Cerrar()
        'FrmCPPinfoProv.ShowDialog()
        FrmVentasCartera.ShowDialog()
    End Sub
    Private Sub cmdCPP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCPP.Click
        MiConexion(bda)
        Cerrar()
        FrmRepDatos.cmdActuaS_Click(AcceptButton, AcceptButton)
        FrmCompEgreCpp.ShowDialog()
    End Sub

    Private Sub cmdOt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOt.Click
        If FrmPrincipal.Contabilidad.Enabled = False Then
            MsgBox("No tiene permisos para la interfaz de contabilidad.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmComEgresoCpp.lbcontr.Text = ""
        FrmComEgresoCpp.Chcredito.Visible = True
        FrmComEgresoCpp.ShowDialog()
    End Sub

    Private Sub cmd_info_art_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_art.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoArtGas.ShowDialog()
    End Sub

    Private Sub cmd_sal_ini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_sal_ini.Click
        MiConexion(bda)
        Cerrar()
        FrmSaldosInicialesCPP.ShowDialog()
    End Sub
    Private Sub cmd_1_fac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_1_fac.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoFactCPP.ShowDialog()
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

    Private Sub FrmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion("sae")
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        'If tabla.Rows(0).Item(0) = "S" Then
        '    cmdpost.Visible = True
        '    cmddes.Visible = True
        'Else
        '    cmdpost.Visible = False
        '    cmddes.Visible = False
        'End If
        Cerrar()


        'If FrmPrincipal.lbuser.Text = "sae" Then
        '    cmdpost.Visible = True
        '    cmddes.Visible = True
        'Else
        '    cmdpost.Visible = False
        '    cmddes.Visible = False
        'End If
        MiConexion(bda)
        Try
            myCommand.CommandText = "ALTER TABLE `ctas_x_pagar` ADD `doc_ext` VARCHAR( 20 ) NOT NULL AFTER `num` ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        ' Agregar campos descuento por articulos 
        Dim pe As String
        For i = 1 To 12
            If i < 10 Then
                pe = "0" & i
            Else
                pe = i
            End If
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "  ALTER TABLE  `detacomp" & pe & "` ADD  `por_des` DECIMAL( 10, 2 ) NOT NULL DEFAULT  '0' AFTER `por_iva_g` ; "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next

        Try
            Dim per As String = ""
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                myCommand.CommandText = "ALTER TABLE fact_comp" & per & " ADD `b1` DOUBLE NOT NULL DEFAULT '0' AFTER `cta3` ," _
                & "ADD `b2` DOUBLE NOT NULL DEFAULT '0' AFTER `b1` ," _
                & "ADD `b3` DOUBLE NOT NULL DEFAULT '0' AFTER `b2` ;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmMarcarPedidos.ShowDialog()
    End Sub

    Private Sub cmdpost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub cmddes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        MiConexion(bda)
        Cerrar()
        FrmCierreComp.ShowDialog()
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        MiConexion(bda)
        Cerrar()
        FrmRepDatos.ShowDialog()
    End Sub

    Private Sub cmdAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub cmd_info_pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_pendientes.Click

    End Sub

    Private Sub cmd_info_cant_ped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_cant_ped.Click

    End Sub

    Private Sub cmdanular_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanular.Click
        MiConexion(bda)
        Cerrar()
        FrmAnularCompras.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmAproD.ShowDialog()
    End Sub

    Private Sub cmddes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCompra.ShowDialog()
    End Sub

    Private Sub cmdAprobar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprobar.Click
        MiConexion(bda)
        Cerrar()
        FrmAprobarC.ShowDialog()
    End Sub

    Private Sub cmdpost_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpost.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCxP.ShowDialog()
    End Sub
End Class