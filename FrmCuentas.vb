Public Class FrmCuentas
    Public fila As Integer

    Private Sub FrmCuentas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtcuenta.Text = ""
    End Sub

    Private Sub FrmCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM selpuc ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han seleccionado ninguna cuenta del PUC, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gcuenta.RowCount = items + 1
        For i = 0 To items - 1
            gcuenta.Item(1, i).Value = tabla.Rows(i).Item("codigo")
            gcuenta.Item(2, i).Value = tabla.Rows(i).Item("descripcion")
            gcuenta.Item(3, i).Value = tabla.Rows(i).Item("nivel")
        Next
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        BuscarGrilla(txtcuenta.Text)
        gcuenta.Focus()
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            If gcuenta.Item(1, fila).Value() = "" Then Exit Sub
            If gcuenta.Item(3, fila).Value() <> "Auxiliar" And lbaux.Text = "auxiliar" Then
                MsgBox("solo puede elegir cuentas de tipo auxiliar", MsgBoxStyle.Information, "SAE escoger cuenta")
                Exit Sub
            End If
            Select Case lbform.Text
                'Case "ModPres7"
                '    FrmModCausaPresu.gitems.Item(7, fila).Value = gcuenta.Item(1, fila).Value()
                'Case "ModPres8"
                '    FrmModCausaPresu.gitems.Item(8, fila).Value = gcuenta.Item(1, fila).Value()
                Case "epuc"
                    FrmNuevoEgreso.txtcta.Text = gcuenta.Item(1, fila).Value()
                Case "ctarbd"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCtasRubroxx.gitems.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "ctarbc"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCtasRubroxx.gitems.Item(4, fil).Value = gcuenta.Item(1, fila).Value()
                Case "ciod1"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCIordenes.grilla1.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmCIordenes.grilla1.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                Case "ciod2"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCIordenes.grilla2.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmCIordenes.grilla2.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                Case "DesCta"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmDesenglobarCta.grilla.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "ModPres7"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmModCausaPresu.gitems.Item(7, fil).Value = gcuenta.Item(1, fila).Value()

                Case "ModPres8"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmModCausaPresu.gitems.Item(8, fil).Value = gcuenta.Item(1, fila).Value()
                Case "magnet"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    Frmctaconceptos.gcuenta.Item("cta", fil).Value = gcuenta.Item(1, fila).Value()
                    Frmctaconceptos.gcuenta.Item("descripcion", fil).Value = gcuenta.Item(2, fila).Value()
                Case "contratortc"
                    FrmContratos.txtcta_rtc.Text = gcuenta.Item(1, fila).Value()
                Case "infMovCC"
                    FrmInfMovCentroC.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "fac_rtc"
                    FrmFacturasyAjustes.txtcuentaCree.Text = gcuenta.Item(1, fila).Value()
                Case "fac_rtc_sp"
                    FrmFacturasyAjustesSP.txtcuentaCree.Text = gcuenta.Item(1, fila).Value()
                Case "cuentRC"
                    FrmCuentaRtCree.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "bancos_cta"
                    FrmGestionBancos.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                    ' INVENTARIO
                Case "it_costo"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmItems.gitems.Item(9, fil).Value = gcuenta.Item(1, fila).Value()
                Case "Items_ctaing"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmItems.gitems.Item(10, fil).Value = gcuenta.Item(1, fila).Value()
                    ' Cuentas Cartera
                Case "caja_car"
                    frmparametroscartera.txtcaja.Text = gcuenta.Item(1, fila).Value()
                Case "banco_car"
                    frmparametroscartera.txtbanco.Text = gcuenta.Item(1, fila).Value()
                Case "ctapc_car"
                    frmparametroscartera.txtctapc.Text = gcuenta.Item(1, fila).Value()
                Case "retencion_car"
                    frmparametroscartera.txtretencion.Text = gcuenta.Item(1, fila).Value()
                Case "descuento_car"
                    frmparametroscartera.txtdescuento.Text = gcuenta.Item(1, fila).Value()
                Case "ivapp_car"
                    frmparametroscartera.txtivapp.Text = gcuenta.Item(1, fila).Value()
                Case "ventas_car"
                    frmparametroscartera.txtventas.Text = gcuenta.Item(1, fila).Value()
                Case "mora_car"
                    frmparametroscartera.txtmora.Text = gcuenta.Item(1, fila).Value()

                    '///////////// CUENTAS DE FACTURACIÓN /////////////////

                Case "banco_car_fac_sub"
                    FrmFacturasPendientes.txtctasub.Text = gcuenta.Item(1, fila).Value()
                Case "banco_car_fac_des"
                    FrmFacturasPendientes.txtcuentadesc.Text = gcuenta.Item(1, fila).Value()
                Case "banco_car_fac_iva"
                    FrmFacturasPendientes.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "banco_car_fac_ret"
                    FrmFacturasPendientes.txtctaret.Text = gcuenta.Item(1, fila).Value()
                Case "banco_car_fac_tot"
                    FrmFacturasPendientes.txtctatotal.Text = gcuenta.Item(1, fila).Value()

                Case "fp"
                    FrmFormaPago.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "sic"
                    FrmSaldosInicialesCartera.txtcta.Text = gcuenta.Item(1, fila).Value()
                    FrmSaldosInicialesCartera.txtnomcta.Text = gcuenta.Item(2, fila).Value()
                Case "fp2"
                    FrmFormaPago2.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "caja"
                    FrmParametrosFact.txtcaja.Text = gcuenta.Item(1, fila).Value()
                Case "banco"
                    FrmParametrosFact.txtbanco.Text = gcuenta.Item(1, fila).Value()
                Case "ctapc"
                    FrmParametrosFact.txtctapc.Text = gcuenta.Item(1, fila).Value()
                Case "inventario"
                    FrmParametrosFact.txtinventario.Text = gcuenta.Item(1, fila).Value()
                Case "ventas"
                    FrmParametrosFact.txtventas.Text = gcuenta.Item(1, fila).Value()
                Case "costo"
                    FrmParametrosFact.txtcosto.Text = gcuenta.Item(1, fila).Value()
                Case "ivapp"
                    FrmParametrosFact.txtivapp.Text = gcuenta.Item(1, fila).Value()
                Case "ivad"
                    FrmParametrosFact.txtivad.Text = gcuenta.Item(1, fila).Value()
                Case "descuento"
                    FrmParametrosFact.txtdescuento.Text = gcuenta.Item(1, fila).Value()
                Case "retfuente"
                    FrmParametrosFact.txtretfuente.Text = gcuenta.Item(1, fila).Value()
                Case "reteica"
                    FrmParametrosFact.txtreteica.Text = gcuenta.Item(1, fila).Value()
                Case "reteiva"
                    FrmParametrosFact.txtreteiva.Text = gcuenta.Item(1, fila).Value()
                    '******************* OTROS CONCEPTOS ******************
                Case "concep_1"
                    FrmOtrosConceptos.cta1.Text = gcuenta.Item(1, fila).Value()
                Case "concep_2"
                    FrmOtrosConceptos.cta2.Text = gcuenta.Item(1, fila).Value()
                Case "concep_3"
                    FrmOtrosConceptos.cta3.Text = gcuenta.Item(1, fila).Value()
                    '******************* OTROS CONCEPTOS ******************
                Case "concep_11"
                    FrmOtrosConceptosProv.cta1.Text = gcuenta.Item(1, fila).Value()
                Case "concep_22"
                    FrmOtrosConceptosProv.cta2.Text = gcuenta.Item(1, fila).Value()
                Case "concep_33"
                    FrmOtrosConceptosProv.cta3.Text = gcuenta.Item(1, fila).Value()
                    '******************* OTROS CONCEPTOS CP******************
                Case "concep2_1"
                    FrmOtrosConceptosCP.cta1.Text = gcuenta.Item(1, fila).Value()
                Case "concep2_2"
                    FrmOtrosConceptosCP.cta2.Text = gcuenta.Item(1, fila).Value()
                Case "concep2_3"
                    FrmOtrosConceptosCP.cta3.Text = gcuenta.Item(1, fila).Value()
                    ' OTROS CONCP CP
                Case "OConCP"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmOtrosConceptosCP.grilla.Item(6, fil).Value = gcuenta.Item(1, fila).Value()
                    ' OTROS CONCP PROV
                Case "OConProv"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmOtrosConceptosProv.grilla.Item(6, fil).Value = gcuenta.Item(1, fila).Value()
                Case "OConInm"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmOtrosccInm.grilla.Item(6, fil).Value = gcuenta.Item(1, fila).Value()
                    '//////////// ORDENES DE PAGO /////////////////
                Case "ordenPG"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmOrdenPagos.grilla.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmOrdenPagos.grilla.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                    '////////////////// CONTABILIDAD ////////////////////
                Case "infCheq"
                    FrmInformeCheque.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "DocConciBancaria"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmDocConciliaB.gitems.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "ConciBancaria"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmConciliacionB.gitems.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "generadoc"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmEntradaDatos.grilla.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "si"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmSaldosIniciales.grilla.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                Case "siccartera"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmSaldosInicialesCartera.grilla.Item("cuenta", fil).Value = gcuenta.Item(1, fila).Value()
                Case "servicios"
                    'FrmArti_Serv.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                    'FrmArti_Serv.txtnomcuenta.Text = gcuenta.Item(2, fila).Value()
                Case "serviciosIVA"
                    'FrmArti_Serv.txtiva.Text = gcuenta.Item(1, fila).Value()
                    'FrmArti_Serv.txtnomiva.Text = gcuenta.Item(2, fila).Value()
                Case "cuentaini"
                    FrmBalancePrueba.txtci.Text = gcuenta.Item(1, fila).Value()
                Case "cuentafin"
                    FrmBalancePrueba.txtcf.Text = gcuenta.Item(1, fila).Value()
                Case "tributario"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCuentasTributarias.gcuenta.Item(2, fil).Value = gcuenta.Item(1, fila).Value()
                Case "infcc1"
                    FrmInformeCC.txtcini.Text = gcuenta.Item(1, fila).Value()
                    '  FrmInformeCC.txtcfin.Focus()
                Case "infcc2"
                    FrmInformeCC.txtcfin.Text = gcuenta.Item(1, fila).Value()
                Case "infcc3"
                    FrmInformeCC.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                Case "infmovc"
                    FrmInfMovContables.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                    '///////// PARAMETROS DE INVENTARIOS ////////////////////

                Case "inv_cuenta1"
                    FrmParInventarios.txtcuenta1.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre1.Text = gcuenta.Item(2, fila).Value()
                Case "inv_cuenta2"
                    FrmParInventarios.txtcuenta2.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre2.Text = gcuenta.Item(2, fila).Value()
                Case "inv_cuenta3"
                    FrmParInventarios.txtcuenta3.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre3.Text = gcuenta.Item(2, fila).Value()
                Case "inv_cuenta4"
                    FrmParInventarios.txtcuenta4.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre4.Text = gcuenta.Item(2, fila).Value()
                Case "inv_cuenta5"
                    FrmParInventarios.txtcuenta5.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre5.Text = gcuenta.Item(2, fila).Value()
                Case "inv_cuenta6"
                    FrmParInventarios.txtcuenta6.Text = gcuenta.Item(1, fila).Value()
                    FrmParInventarios.txtnombre6.Text = gcuenta.Item(2, fila).Value()
                    '////// FORMULARIO CUENTAS DEL ARTICULO //////////////
                Case "fca_inv"
                    FrmCuestasArt.txtcinv.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtninv.Text = gcuenta.Item(2, fila).Value()
                Case "fca_ing"
                    FrmCuestasArt.txtcing.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtning.Text = gcuenta.Item(2, fila).Value()
                Case "fca_cos"
                    FrmCuestasArt.txtccos.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtncos.Text = gcuenta.Item(2, fila).Value()
                Case "fca_ivag"
                    FrmCuestasArt.txtcivag.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtnivag.Text = gcuenta.Item(2, fila).Value()
                Case "fca_ivad"
                    FrmCuestasArt.txtcivad.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtnivad.Text = gcuenta.Item(2, fila).Value()
                Case "fca_dev"
                    FrmCuestasArt.txtcdev.Text = gcuenta.Item(1, fila).Value()
                    FrmCuestasArt.txtndev.Text = gcuenta.Item(2, fila).Value()
                    '***************** FACTURA RAPIDA //////////////////////
                Case "fr_desc"
                    Frmfacturarapida.txtcuentadesc.Text = gcuenta.Item(1, fila).Value()
                Case "fr_iva"
                    Frmfacturarapida.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "fr_total"
                    Frmfacturarapida.txtcuentatotal.Text = gcuenta.Item(1, fila).Value()
                    '***************** FACTURA NORMAL //////////////////////
                Case "fn_desc_sp"
                    FrmFacturasyAjustesSP.txtcuentadesc.Text = gcuenta.Item(1, fila).Value()
                Case "fn_desc"
                    FrmFacturasyAjustes.txtcuentadesc.Text = gcuenta.Item(1, fila).Value()
                Case "fn_iva_sp"
                    FrmFacturasyAjustesSP.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "fn_iva"
                    FrmFacturasyAjustes.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "fn_iva_sp"
                    FrmFacturasyAjustesSP.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "fn_total"
                    FrmFacturasyAjustes.txtcuentatotal.Text = gcuenta.Item(1, fila).Value()
                Case "fn_total_sp"
                    FrmFacturasyAjustesSP.txtcuentatotal.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtf"
                    FrmFacturasyAjustes.txtctaretef.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtf_sp"
                    FrmFacturasyAjustesSP.txtctaretef.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtiva"
                    FrmFacturasyAjustes.txtctariva.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtiva_sp"
                    FrmFacturasyAjustesSP.txtctariva.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtica"
                    FrmFacturasyAjustes.txtctarica.Text = gcuenta.Item(1, fila).Value()
                Case "fn_rtica_sp"
                    FrmFacturasyAjustesSP.txtctarica.Text = gcuenta.Item(1, fila).Value()
                    '**************** CUANTAS DE UN SERVICIO *********************
                Case "ser_iva"
                    FrmServicios.txtctaiva.Text = gcuenta.Item(1, fila).Value()
                    FrmServicios.txtniva.Text = gcuenta.Item(2, fila).Value()
                Case "ser_ing"
                    FrmServicios.txtctaing.Text = gcuenta.Item(1, fila).Value()
                    FrmServicios.txtning.Text = gcuenta.Item(2, fila).Value()
                    '******************* OTROS DOCUMENTOS ******************
                Case "comproEg"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmComEgresoCpp.grilla.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmComEgresoCpp.grilla.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                Case "comproIn"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCompIngresos.grilla.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmCompIngresos.grilla.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                Case "comproRo"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmRecibodeCaja.grilla.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    FrmRecibodeCaja.grilla.Item(1, fil).Value = gcuenta.Item(2, fila).Value()
                Case "nc"
                    If lbfila.Text = "txt" Then
                        FrmNotaCredito.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                    Else
                        Dim fil As Integer
                        fil = Val(lbfila.Text)
                        FrmNotaCredito.grilla2.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    End If
                Case "nd"
                    If lbfila.Text = "txt" Then
                        FrmNotaDebito.txtcuenta.Text = gcuenta.Item(1, fila).Value()
                    Else
                        Dim fil As Integer
                        fil = Val(lbfila.Text)
                        FrmNotaDebito.grilla2.Item(0, fil).Value = gcuenta.Item(1, fila).Value()
                    End If
                    '////// FORMULARIO CONTEO FISICO INVENTARIOS //////////////
                Case "cfi_inv"
                    FrmConteoFisInv.txtctainv.Text = gcuenta.Item(1, fila).Value()
                    FrmConteoFisInv.txtnominv.Text = gcuenta.Item(2, fila).Value()
                Case "cfi_cos"
                    FrmConteoFisInv.txtctacos.Text = gcuenta.Item(1, fila).Value()
                    FrmConteoFisInv.txtnomcos.Text = gcuenta.Item(2, fila).Value()
                Case "impuestos"
                    FrmImpuestos.txtCuenta.Text = gcuenta.Item(1, fila).Value()
                    '************* COMPRAS *********************************
                Case "comp_caja"
                    FrmParCompras.txt_cta_caja.Text = gcuenta.Item(1, fila).Value()
                Case "comp_banco"
                    FrmParCompras.txt_cta_banco.Text = gcuenta.Item(1, fila).Value()
                Case "comp_cpp"
                    FrmParCompras.txt_cta_cpp.Text = gcuenta.Item(1, fila).Value()
                Case "comp_gas"
                    FrmParCompras.txt_cta_gas.Text = gcuenta.Item(1, fila).Value()
                Case "comp_com"
                    FrmParCompras.txt_cta_com.Text = gcuenta.Item(1, fila).Value()
                Case "comp_desc"
                    FrmParCompras.txt_cta_desc.Text = gcuenta.Item(1, fila).Value()
                Case "comp_inv"
                    FrmParCompras.txt_cta_inv.Text = gcuenta.Item(1, fila).Value()
                Case "comp_iva_g"
                    FrmParCompras.txt_cta_iva_g.Text = gcuenta.Item(1, fila).Value()
                Case "comp_iva_d"
                    FrmParCompras.txt_cta_iva_d.Text = gcuenta.Item(1, fila).Value()
                Case "comp_rtf"
                    FrmParCompras.txt_cta_rtf.Text = gcuenta.Item(1, fila).Value()
                Case "comp_fle"
                    FrmParCompras.txt_cta_fle.Text = gcuenta.Item(1, fila).Value()
                Case "comp_seg"
                    FrmParCompras.txt_cta_seg.Text = gcuenta.Item(1, fila).Value()
                Case "comp_ppf_c"
                    FrmParCompras.txt_cta_ppf_c.Text = gcuenta.Item(1, fila).Value()
                Case "comp_ppf_d"
                    FrmParCompras.txt_cta_ppf_d.Text = gcuenta.Item(1, fila).Value()
                Case "cpp_egre"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmCompEgreCpp.grilla.Item("Cuenta", fil).Value = gcuenta.Item(1, fila).Value().ToString
                    FrmCompEgreCpp.grilla.Item("Descripcion", fil).Value = gcuenta.Item(2, fila).Value()
                Case "ItemsPr_ctaing"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmItemsCompras.gitems.Item(10, fil).Value = gcuenta.Item(1, fila).Value()
                    '*************** DOCUMENTOS PROVEEDORES ************
                Case "fdp_rtc"
                    FrmDocProveedor.txtcuentaCree.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_desc"
                    FrmDocProveedor.txtcuentadesc.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_rtf"
                    FrmDocProveedor.txtcuentaret.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_iva"
                    FrmDocProveedor.txtcuentaiva.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_fle"
                    FrmDocProveedor.txtcuentaflete.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_seg"
                    FrmDocProveedor.txtcuentaseguro.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_total"
                    FrmDocProveedor.txtcuentatotal.Text = gcuenta.Item(1, fila).Value()
                Case "fdp_items_Comp"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmItemsCompras.gitems.Item(8, fil).Value = gcuenta.Item(1, fila).Value()
                Case "cpp_si"
                    FrmSaldosInicialesCPP.txtcta.Text = gcuenta.Item(1, fila).Value()
                    FrmSaldosInicialesCPP.txtnomcta.Text = gcuenta.Item(2, fila).Value()
                Case "cpp_si_g"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmSaldosInicialesCPP.grilla.Item("cuenta", fil).Value = gcuenta.Item(1, fila).Value().ToString
                    ' CUENTAS INT_MORA CARTERA
                Case "CarMora"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmItemCartera.gitems.Item("ctaint", fil).Value = gcuenta.Item(1, fila).Value()
                    '*************** CUANTAS GASTOS ************
                Case "gas_gas"
                    FrmGastos.txtctagas.Text = gcuenta.Item(1, fila).Value()
                    FrmGastos.txtngas.Text = gcuenta.Item(2, fila).Value()
                Case "gas_iva"
                    FrmGastos.txtctaiva.Text = gcuenta.Item(1, fila).Value()
                    FrmGastos.txtniva.Text = gcuenta.Item(2, fila).Value()
                    '**************** ANALISIS ******************
                Case "analisis"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmParametrosGer.gcuenta.Item(2, fil).Value = gcuenta.Item(2, fila).Value()
                    FrmParametrosGer.gcuenta.Item(3, fil).Value = gcuenta.Item(1, fila).Value()
                    '********************* CONTRATO INMOBILIARIA ******************
                Case "contratov"
                    FrmContratos.txtcta_v.Text = gcuenta.Item(1, fila).Value()
                Case "contratoiva"
                    FrmContratos.txtcta_iva.Text = gcuenta.Item(1, fila).Value()
                Case "contratortf"
                    FrmContratos.txtcta_rtf.Text = gcuenta.Item(1, fila).Value()
                Case "contratocli"
                    FrmContratos.txtcta_cli.Text = gcuenta.Item(1, fila).Value()
                Case "contratocms"
                    FrmContratos.txtcta_cms.Text = gcuenta.Item(1, fila).Value()
                Case "contrato_AC"
                    FrmContratos.txtcac.Text = gcuenta.Item(1, fila).Value()
                Case "contrato_AD"
                    FrmContratos.txtcad.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_ventas"
                    FrmParInmob.txtcta_v.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_rtf"
                    FrmParInmob.txtcta_rtf.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_iva"
                    FrmParInmob.txtcta_iva.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_cli"
                    FrmParInmob.txtcta_cli.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_cms"
                    FrmParInmob.txtcta_c.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_ac"
                    FrmParInmob.txtctaac.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_ad"
                    FrmParInmob.txtctaad.Text = gcuenta.Item(1, fila).Value()
                Case "parinm_ing"
                    FrmParInmob.txtctaing.Text = gcuenta.Item(1, fila).Value()
                    '.... cierre contable
                Case "cierreOp"
                    FrmCierreOpciones.txtctapuente.Text = gcuenta.Item(1, fila).Value()
                Case "cierreOUP"
                    FrmCierreOpciones.txtctaUP.Text = gcuenta.Item(1, fila).Value()
                    '***************** AUDITORIA *********************
                    ' AUDITORIA FAC
                Case "Aud_fac_ban"
                    FrmParFac.txtbancoF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_caj"
                    FrmParFac.txtcajaF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_cos"
                    FrmParFac.txtcostoF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_cpc"
                    FrmParFac.txtctapcF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_des"
                    FrmParFac.txtdescuentoF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_inv"
                    FrmParFac.txtinventarioF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_ivad"
                    FrmParFac.txtivadF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_ivap"
                    FrmParFac.txtivappF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_rti"
                    FrmParFac.txtreteicaF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_rtf"
                    FrmParFac.txtretfuenteF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_rtiv"
                    FrmParFac.txtreteivaF.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_fac_ven"
                    FrmParFac.txtventasF.Text = gcuenta.Item(1, fila).Value()
                    ' AUDITORIA FP
                Case "Aud_pro_ban"
                    FrmParProv.txtbanco.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_caj"
                    FrmParProv.txtcaja.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_comp"
                    FrmParProv.txtcomp.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_cxp"
                    FrmParProv.txtcxp.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_gas"
                    FrmParProv.txtgas.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_des"
                    FrmParProv.txtdesc.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_inv"
                    FrmParProv.txtinv.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_ivap"
                    FrmParProv.txtivap.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_ivad"
                    FrmParProv.txtivad.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_rtf"
                    FrmParProv.txtrtf.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_fle"
                    FrmParProv.txtfle.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_seg"
                    FrmParProv.txtseg.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_pc"
                    FrmParProv.txtpc.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_pro_pd"
                    FrmParProv.txtpd.Text = gcuenta.Item(1, fila).Value()
                    ' AUDITORIA OTROS DOC
                Case "Aud_od_caj"
                    FrmParOtrosDoc.txtcaja.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_od_ban"
                    FrmParOtrosDoc.txtbanco.Text = gcuenta.Item(1, fila).Value()
                    'FrmParOtrosDoc.lbfila.Text = fila
                Case "Aud_od_cxc"
                    FrmParOtrosDoc.txtctapc.Text = gcuenta.Item(1, fila).Value()
                Case "Aud_od_cxp"
                    FrmParOtrosDoc.txtctapp.Text = gcuenta.Item(1, fila).Value()
                    'SALDOS INICIALES IN.V
                Case "salinv_C"
                    FrmCuentasSalIniinv.txtcredito.Text = gcuenta.Item(1, fila).Value()
                Case "salinv_D"
                    FrmCuentasSalIniinv.txtdebito.Text = gcuenta.Item(1, fila).Value()
                Case "ModPres7"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmModCausaPresu.gitems.Item(7, fil).Value = gcuenta.Item(1, fila).Value()
                Case "ModPres8"
                    Dim fil As Integer
                    fil = Val(lbfila.Text)
                    FrmModCausaPresu.gitems.Item(8, fil).Value = gcuenta.Item(1, fila).Value()
                    ' ### PARAMETROS DE CONTABILIDAD #### '
                Case "parCont_dif"
                    FrmParContable .txtCtaDiferencia .Text = gcuenta.Item(1, fila).Value()
                Case "parCont_perd"
                    FrmParContable.txtCtaPerdida.Text = gcuenta.Item(1, fila).Value()
            End Select
            gcuenta.Focus()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        cmditems_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub gcuenta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO BUSCAR
                Case 1
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                Case 2
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If gcuenta.Item(0, fila - 1).Value <> "" Then Exit Sub
            fila = fila - 1
            cmditems_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Dim lk As String = ""
        Try
            If cmbbuscar.Text = "CUENTA" Then
                cl = 1
            ElseIf cmbbuscar.Text = "DESCRIPCION" Then
                cl = 2
            End If

            If cad = "" Then Exit Sub
            cad = UCase(cad)
            If cl = 1 Then
                cad = "" & cad & "*"
            Else
                cad = "*" & cad & "*"
            End If
            For i = fila + 1 To gcuenta.RowCount - 1
                Try
                    If gcuenta.Item(cl, i).Value.ToString Like cad Then
                        Dim C As Integer = cl, F As Integer = i
                        gcuenta.CurrentCell = gcuenta(C, F)
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gcuenta.Item(cl, i).Value.ToString Like cad Then
                        Dim C As Integer = cl, F As Integer = i
                        gcuenta.CurrentCell = gcuenta(C, F)
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Cuenta")
        Catch ex As Exception
        End Try

        '..........
        'Dim ok As String = ""
        'Try
        '    If cad = "" Then Exit Sub
        '    Dim cad2, aux As String
        '    For i = 0 To gcuenta.RowCount - 2
        '        aux = gcuenta.Item(1, i).Value.ToString
        '        If Val(aux.Length) >= Val(cad.Length) Then
        '            cad2 = ""
        '            For j = 0 To cad.Length - 1
        '                cad2 = cad2 & aux(j)
        '            Next
        '            If cad = cad2 Then
        '                fila = i
        '                Dim C As Integer = 1, F As Integer = i
        '                gcuenta.CurrentCell = gcuenta(C, F)
        '                gcuenta.Focus()
        '                ok = "ok"
        '                Exit Sub
        '            End If
        '        End If
        '    Next
        '    If ok = "" Then
        '        'MsgBox("La cuenta no existe", MsgBoxStyle.Information)
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Public Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "CUENTA"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress

        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "CUENTA"
        End If
        If cmbbuscar.Text = "CUENTA" Then
            validarnumero(txtcuenta, e)
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub gcuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellContentClick

    End Sub
End Class