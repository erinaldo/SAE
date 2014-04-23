Public Class FrmSelCliente
    Public fila As Integer

    Private Sub FrmSelCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            If lbform.Text = "tercerosInm" Then
                myCommand.CommandText = "SELECT t.nit,TRIM(CONCAT(t.apellidos,' ',t.nombre))AS ter, IFNULL(i.clase,'') as tipo FROM terceros t left join tercerosinm i ON i.nit=t.nit ORDER BY ter;"
            Else
                myCommand.CommandText = "SELECT t.nit,TRIM(CONCAT(t.apellidos,' ',t.nombre))AS ter FROM terceros t  ORDER BY ter;"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han seleccionado ningun tercero, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try

            If lbform.Text = "tercerosInm" Then
                gitems.RowCount = items + 1
                For i = 0 To items - 1
                    gitems.Item(1, i).Value = tabla.Rows(i).Item("ter")
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("tipo")
                Next
            Else
                gitems.RowCount = items + 1
                For i = 0 To items - 1
                    gitems.Item(1, i).Value = tabla.Rows(i).Item("ter")
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
                Next
            End If
            'gitems.RowCount = items + 1
            'For i = 0 To items - 1
            '    gitems.Item(1, i).Value = tabla.Rows(i).Item("ter")
            '    gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
            '    '   gitems.Item(3, i).Value = tabla.Rows(i).Item("tipo")
            'Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "infcitas"
                FrmInforCitas.txtnitc.Text = gitems.Item(2, mifila).Value
                FrmInforCitas.txtnomv.Text = gitems.Item(1, mifila).Value
            Case "citaE"
                FrmGestionCitas.txtnitc.Text = gitems.Item(2, mifila).Value
                FrmGestionCitas.txtnomc.Text = gitems.Item(1, mifila).Value
            Case "doccon"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmDocConciliaB.gitems.Item(7, fil).Value = gitems.Item(2, mifila).Value()
            Case "fac_cliA"
                FrmInfoClientes.txttip.Text = gitems.Item(2, mifila).Value
                FrmInfoClientes.txtnom.Text = gitems.Item(1, mifila).Value
            Case "cerret"
                FrmCertificadoRete.txtnit.Text = gitems.Item(2, mifila).Value
                FrmCertificadoRete.txtnombre.Text = gitems.Item(1, mifila).Value
            Case "trib"
                FrmTributarios.txtnit.Text = gitems.Item(2, mifila).Value
                FrmTributarios.txtnombre.Text = gitems.Item(1, mifila).Value
            Case "ingop"
                FrmCIordenes.txtnit.Text = gitems.Item(2, mifila).Value
                FrmCIordenes.txtnomt.Text = gitems.Item(1, mifila).Value
            Case "NucleoF"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmNucleoFami.grilla.Item(0, fil).Value = gitems.Item(2, mifila).Value()
                FrmNucleoFami.grilla.Item(1, fil).Value = gitems.Item(1, mifila).Value()
            Case "Gce"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmComEgresoCpp.grilla.Item(6, fil).Value = gitems.Item(2, mifila).Value()
            Case "DesCta"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmDesenglobarCta.grilla.Item(5, fil).Value = gitems.Item(2, mifila).Value()
            Case "nv_inm"
                FrmNovedadInm.txtnita.Text = gitems.Item(2, mifila).Value
                FrmNovedadInm.txtnoma.Text = gitems.Item(1, mifila).Value
            Case "cotiz"
                FrmInfoCotz.txttip.Text = gitems.Item(2, mifila).Value
                FrmInfoCotz.txtnom.Text = gitems.Item(1, mifila).Value
            Case "infMovCC"
                FrmInfMovCentroC.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmInfMovCentroC.txtnombre.Text = gitems.Item(1, mifila).Value()
            Case "bancos_txt"
                FrmGestionBancos.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmGestionBancos.txtbanco.Text = gitems.Item(1, mifila).Value()
            Case "Orden"
                FrmOrdenPagos.txtnit.Text = gitems.Item(2, mifila).Value()
            Case "lista_clie"
                FrmListasClientes.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmListasClientes.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "lista_clie_conpF"
                FrmConcpFac.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmConcpFac.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "lista_clie_carXciu"
                FrmCarxCiu.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmCarxCiu.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "lista_clie_Mora"
                FrmClientMora.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmClientMora.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpc_1_FC"
                FrmConUnaFC.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmConUnaFC.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_car_ana_ven"
                FrmAnalisisVencimiento.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmAnalisisVencimiento.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_car_est_cta"
                FrmEstadoCuentas.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmEstadoCuentas.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "informe_xclientes"
                FrmMovCartera.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmMovCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "informe_xproveedor"
                FrmPlanPagoCPP.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmPlanPagoCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "it_ce_cpc"
                FrmItemCartera.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmItemCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_pp"
                FrmPlanPagoCPP.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmPlanPagoCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_gas"
                FrmInfoCompGasOtros.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmInfoCompGasOtros.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_cpp"
                FrmInfoCompCPP.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmInfoCompCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_art_gas"
                FrmInfoArtGas.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmInfoArtGas.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "com_inf_car"
                FrmVentasCartera.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmVentasCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fcp"
                FrmFacturasPendientes.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmFacturasPendientes.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fcp_cob"
                FrmFacturasPendientes.txtcod.Text = gitems.Item(2, mifila).Value()
                FrmFacturasPendientes.txtcodeudor.Text = gitems.Item(1, mifila).Value()
            Case "informe_xclientes"
                FrmMovCartera.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmMovCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "sic"
                FrmSaldosInicialesCartera.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmSaldosInicialesCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_si"
                FrmSaldosInicialesCPP.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmSaldosInicialesCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_fac"
                FrmInfoFactCPP.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmInfoFactCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "frs"
                FrmFacturaEstetica.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmFacturaEstetica.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fr"
                Frmfacturarapida.txtnitc.Text = gitems.Item(2, mifila).Value()
                Frmfacturarapida.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fp"
                FrmEntraPedidos.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmEntraPedidos.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fn"
                FrmFacturasyAjustes.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmFacturasyAjustes.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "fdp"
                FrmDocProveedor.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmDocProveedor.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "oc"
                FrmOrdenCompra.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmOrdenCompra.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "cpp_inf_pro"
                FrmCPPinfoProv.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmCPPinfoProv.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "com_inf_pro"
                FrmInfoCompProv.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmInfoCompProv.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "it_ce_cpp"
                FrmItemsCPP.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmItemsCPP.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "generadoc"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmEntradaDatos.grilla.Item(7, fil).Value = gitems.Item(2, mifila).Value()
            Case "generadoc_txt"
                FrmEntradaDatos.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmEntradaDatos.txtnombre.Text = gitems.Item(1, mifila).Value()
            Case "si"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmSaldosIniciales.grilla.Item(7, fil).Value = gitems.Item(2, mifila).Value()
            Case "si_txt"
                FrmSaldosIniciales.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmSaldosIniciales.txtnombre.Text = gitems.Item(1, mifila).Value()
            Case "terceros"
                frmterceros.lbestado.Text = "CONSULTA"
                frmterceros.lbnroobs.Text = mifila + 1
                frmterceros.txtnit.Text = gitems.Item(2, mifila).Value()
            Case "inv_p1"
                FrmProve_Art.txt1.Text = gitems.Item(2, mifila).Value()
                FrmProve_Art.txtn1.Text = gitems.Item(1, mifila).Value()
            Case "inv_p2"
                FrmProve_Art.txt2.Text = gitems.Item(2, mifila).Value()
                FrmProve_Art.txtn2.Text = gitems.Item(1, mifila).Value()
            Case "inv_p3"
                FrmProve_Art.txt3.Text = gitems.Item(2, mifila).Value()
                FrmProve_Art.txtn3.Text = gitems.Item(1, mifila).Value()
            Case "inv_p4"
                FrmProve_Art.txt4.Text = gitems.Item(2, mifila).Value()
                FrmProve_Art.txtn4.Text = gitems.Item(1, mifila).Value()
            Case "inv_p5"
                FrmProve_Art.txt5.Text = gitems.Item(2, mifila).Value()
                FrmProve_Art.txtn5.Text = gitems.Item(1, mifila).Value()
            Case "entradas"
                FrmEntradas.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmEntradas.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "salidas"
                FrmSalidas.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmSalidas.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "comproEg"
                FrmComEgresoCpp.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmComEgresoCpp.lbcliente.Text = gitems.Item(1, mifila).Value()
            Case "comproIn"
                FrmCompIngresos.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmCompIngresos.lbcliente.Text = gitems.Item(1, mifila).Value()
            Case "comproRo"
                FrmRecibodeCaja.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmRecibodeCaja.lbcliente.Text = gitems.Item(1, mifila).Value()
            Case "nc"
                FrmNotaCredito.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmNotaCredito.lbcliente.Text = gitems.Item(1, mifila).Value()
            Case "nd"
                FrmNotaDebito.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmNotaDebito.lbcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_cc"
                FrmInformeCC.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmInformeCC.txtnombre.Text = gitems.Item(1, mifila).Value()
            Case "inv_ter"
                FrmInfoterceros.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfoterceros.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "Anal_cart"
                FrmClienteC.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmClienteC.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "Anal_pro"
                FrmAnaProv.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmAnaProv.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_mov_cli"
                FrmMovCli.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmMovCli.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "items"
                FrmNitF.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmNitF.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_recc"
                FrmInfoReciboCartera.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmInfoReciboCartera.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "tercerosInm"
                FrmClasiTerceros.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmClasiTerceros.txtnombre.Text = gitems.Item(1, mifila).Value()
                FrmClasiTerceros.txttipo1.Text = gitems.Item(3, mifila).Value()
            Case "inf_antic"
                FrmInfoAnticipos.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfoAnticipos.txtnom.Text = gitems.Item(1, mifila).Value()
                '.............ORDENES DE PAGO
            Case "OrdenesP"
                FrmInforOrdenes.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInforOrdenes.txtnom.Text = gitems.Item(1, mifila).Value()
                '...
            Case "SaldoIniInv"
                FrmSaldosIniInv.txtnitc.Text = gitems.Item(2, mifila).Value()
                FrmSaldosIniInv.txtcliente.Text = gitems.Item(1, mifila).Value()
            Case "inf_cheq"
                FrmInformeCheque.txtnit.Text = gitems.Item(2, mifila).Value()
                FrmInformeCheque.txtnombre.Text = gitems.Item(1, mifila).Value()


        End Select
        gitems.Focus()
        Me.Close()
    End Sub
   
    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "NOMBRES" Then
                cl = 1
            ElseIf cmbbuscar.Text = "NIT/CEDULA" Then
                cl = 2
            End If

            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = fila + 1 To gitems.RowCount - 1
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Terceros")
        Catch ex As Exception
        End Try

        
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "NOMBRES"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "NOMBRES"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
    
End Class