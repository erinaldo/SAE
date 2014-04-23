Public Class FrmFormaPago
    Public sw As Integer
    '//////// BOTONES DE FORMAS DE PAGOS  /////////////
    Private Sub cmdcheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcheque.Click
        rbndia.Checked = True
        gdia.Enabled = False
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        txtespecifica.Text = ""
        tabforma.Visible = True
        tabvarias.Visible = False
        lbfp.Text = "Pagar Con Cheque"
        If lbform.Text = "fp" Then
            cuentatotal("SELECT cta_banco FROM par_comp;")
            'If FrmDocProveedor.txtcuentatotal.Text <> "" Then
            '    If FrmDocProveedor.txtcuentatotal.Text <> txtcuenta.Text Then
            '        txtcuenta.Text = FrmDocProveedor.txtcuentatotal.Text
            '    End If
            'End If
        Else
            cuentatotal("SELECT bancos FROM parafacgral;")
        End If
        txtpago.Text = txttotal.Text
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = True
        gtar.Enabled = False
        gcre.Enabled = False
        txtnumcheq.Focus()
    End Sub
    Private Sub cmdtarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtarjeta.Click
        rbndia.Checked = True
        gdia.Enabled = False
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        txtespecifica.Text = ""
        tabforma.Visible = True
        tabvarias.Visible = False
        txtpago.Text = txttotal.Text
        lbfp.Text = "Pagar Con Tarjeta"
        If lbform.Text = "fp" Then
            cuentatotal("SELECT cta_banco FROM par_comp;")
            'If FrmDocProveedor.txtcuentatotal.Text <> "" Then
            '    If FrmDocProveedor.txtcuentatotal.Text <> txtcuenta.Text Then
            '        txtcuenta.Text = FrmDocProveedor.txtcuentatotal.Text
            '    End If
            'End If
        Else
            cuentatotal("SELECT bancos FROM parafacgral;")
        End If
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = False
        gtar.Enabled = True
        gcre.Enabled = False
        txttarjeta.Focus()
    End Sub
    Private Sub cmdefectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdefectivo.Click
        rbndia.Checked = True
        gdia.Enabled = False
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        txtespecifica.Text = ""
        tabforma.Visible = True
        tabvarias.Visible = False
        lbfp.Text = "Pagar Con Efectivo"
        If lbform.Text = "fp" Then
            cuentatotal("SELECT cta_caja FROM par_comp;")
            'If FrmDocProveedor.txtcuentatotal.Text <> "" Then
            '    If FrmDocProveedor.txtcuentatotal.Text <> txtcuenta.Text Then
            '        txtcuenta.Text = FrmDocProveedor.txtcuentatotal.Text
            '    End If
            'End If
        Else
            cuentatotal("SELECT caja FROM parafacgral;")
        End If
        txtpago.Text = txttotal.Text
        txtpago.ReadOnly = False
        txtpago_TextChanged(AcceptButton, AcceptButton)
        txtpago.Focus()
        '''''' '''''''
        gche.Enabled = False
        gtar.Enabled = False
        gcre.Enabled = False
    End Sub
    Private Sub cmdcredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcredito.Click
        gdia.Enabled = True
        rbsdia.Checked = True
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        txtespecifica.Text = "CREDITO"
        txtdias.Text = "30"
        tabforma.Visible = True
        tabvarias.Visible = False
        lbfp.Text = "Pagar Con Otro Medio"
        If lbform.Text = "fp" Then
            cuentatotal("SELECT cta_cpp FROM par_comp;")
            If FrmDocProveedor.txtcuentatotal.Text <> "" Then
                If FrmDocProveedor.txtcuentatotal.Text <> txtcuenta.Text Then
                    txtcuenta.Text = FrmDocProveedor.txtcuentatotal.Text
                End If
            End If
        Else
            cuentatotal("SELECT ctapc FROM parafacgral;")
        End If
        txtpago.Text = txttotal.Text
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = False
        gtar.Enabled = False
        gcre.Enabled = True
        txtespecifica.Focus()
    End Sub
    Private Sub cmdvarias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdvarias.Click
        sw = 0
        rbndia.Checked = True
        gdia.Enabled = False
        txtnumcheque2.Text = ""
        txtbanco2.Text = ""
        txttar1.Text = ""
        txttar2.Text = ""
        txttar3.Text = ""
        txtnumtar1.Text = ""
        txtnumtar2.Text = ""
        txtnumtar3.Text = ""
        cbtarj1.Text = "DB"
        cbtarj2.Text = "DB"
        cbtarj3.Text = "DB"
        txtvche.Text = "0,00"
        txtvt1.Text = "0,00"
        txtvt2.Text = "0,00"
        txtvt3.Text = "0,00"
        txtvefec.Text = "0,00"
        txtpago.Text = "0,00"
        cuentatotal("SELECT caja FROM parafacgral;")
        tabforma.Visible = False
        tabvarias.Visible = True
        txtpago.ReadOnly = True
        sw = 1
        txtpago_TextChanged(AcceptButton, AcceptButton)
    End Sub
    Public Sub cuentatotal(ByVal sql)
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items > 0 Then
                txtcuenta.Text = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '//////// EVENTOS FORMULARIOS  /////////////
    Private Sub FrmFormaPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'cmdefectivo_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmFormaPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cmdefectivo_Click(AcceptButton, AcceptButton)
    End Sub
    '//////// EVENTOS DE LAS CAJAS DE TEXTO /////////////
    Private Sub txtpago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpago.KeyPress
        ValidarMoneda(txtpago, e)
        txtpago.ForeColor = Color.MediumSeaGreen
    End Sub
    Private Sub txtpago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpago.TextChanged
        txtpago.Text = Moneda(CDbl(txtpago.Text))
        txtcambio.Text = Moneda(CDec(txtpago.Text) - CDec(txttotal.Text))
    End Sub

    Private Sub txtvche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvche.KeyPress
        ValidarMoneda(txtvche, e)
    End Sub
    Private Sub txtvche_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvche.LostFocus
        txtvche.Text = Moneda(txtvche.Text)
        SumarTotal()
    End Sub

    Private Sub txtvt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvt1.KeyPress
        ValidarMoneda(txtvt1, e)
    End Sub
    Private Sub txtvt1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvt1.LostFocus
        txtvt1.Text = Moneda(txtvt1.Text)
        SumarTotal()
    End Sub

    Private Sub txtvt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvt2.KeyPress
        ValidarMoneda(txtvt2, e)
    End Sub
    Private Sub txtvt2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvt2.LostFocus
        txtvt2.Text = Moneda(txtvt2.Text)
        SumarTotal()
    End Sub

    Private Sub txtvt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvt3.KeyPress
        ValidarMoneda(txtvt3, e)
    End Sub
    Private Sub txtvt3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvt3.LostFocus
        txtvt3.Text = Moneda(txtvt3.Text)
        SumarTotal()
    End Sub

    Private Sub txtvefec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvefec.KeyPress
        ValidarMoneda(txtvefec, e)
    End Sub
    Private Sub txtvefec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvefec.LostFocus
        txtvefec.Text = Moneda(txtvefec.Text)
        SumarTotal()
    End Sub

    Public Sub SumarTotal()
        If sw = 0 Then Exit Sub
        Try
            txtpago.Text = Moneda(CDbl(txtvche.Text) + CDbl(txtvt1.Text) + CDbl(txtvt2.Text) + CDbl(txtvt3.Text) + CDbl(txtvefec.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttotal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.DoubleClick
        If tabvarias.Visible = True Then Exit Sub
        txtpago.Text = txttotal.Text
    End Sub

    '//////////// CONTINUAR  ///////////////////////
    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        Try
            If CDbl(txtpago.Text) < CDbl(txttotal.Text) Then
                MsgBox("El valor pagado debe ser mayor o igual al valor de la factura, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tabvarias.Visible = True Then
                variasFP()
            Else
                FormaDePago()
            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Public Sub variasFP()
        Dim cant As Integer
        cant = 0
        Select Case lbform.Text
            Case "fr"
                Frmfacturarapida.gfp.Rows.Clear()
                Frmfacturarapida.gfp.RowCount = 5
            Case "fn"
                FrmFacturasyAjustes.gfp.Rows.Clear()
                FrmFacturasyAjustes.gfp.RowCount = 5
            Case "fn_sp"
                FrmFacturasyAjustesSP.gfp.Rows.Clear()
                FrmFacturasyAjustesSP.gfp.RowCount = 5
            Case "frs"
                FrmFacturaEstetica.gfp.Rows.Clear()
                FrmFacturaEstetica.gfp.RowCount = 5
        End Select

        If CDbl(txtvche.Text) <> 0 Then ' cheque
            If txtbanco2.Text = "" Or txtnumcheque2.Text = "" Then
                MsgBox("Faltan parametros del cheque, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                txtbanco2.Focus()
                Exit Sub
            End If
            cant = cant + 1
            Select Case lbform.Text
                Case "fr"
                    Frmfacturarapida.gfp.Item("cual", cant - 1).Value = "Cheque"
                    Frmfacturarapida.gfp.Item("detalle", cant - 1).Value = "cheque"
                    Frmfacturarapida.gfp.Item("monto", cant - 1).Value = txtvche.Text
                    Frmfacturarapida.gfp.Item("numero", cant - 1).Value = txtnumcheque2.Text
                    Frmfacturarapida.gfp.Item("banco", cant - 1).Value = txtbanco2.Text
                    Frmfacturarapida.gfp.Item("tt", cant - 1).Value = ""
                Case "fn"
                    FrmFacturasyAjustes.gfp.Item("cual", cant - 1).Value = "Cheque"
                    FrmFacturasyAjustes.gfp.Item("detalle", cant - 1).Value = "cheque"
                    FrmFacturasyAjustes.gfp.Item("monto", cant - 1).Value = txtvche.Text
                    FrmFacturasyAjustes.gfp.Item("numero", cant - 1).Value = txtnumcheque2.Text
                    FrmFacturasyAjustes.gfp.Item("banco", cant - 1).Value = txtbanco2.Text
                    FrmFacturasyAjustes.gfp.Item("tt", cant - 1).Value = ""
                Case "fn_sp"
                    FrmFacturasyAjustesSP.gfp.Item("cual", cant - 1).Value = "Cheque"
                    FrmFacturasyAjustesSP.gfp.Item("detalle", cant - 1).Value = "cheque"
                    FrmFacturasyAjustesSP.gfp.Item("monto", cant - 1).Value = txtvche.Text
                    FrmFacturasyAjustesSP.gfp.Item("numero", cant - 1).Value = txtnumcheque2.Text
                    FrmFacturasyAjustesSP.gfp.Item("banco", cant - 1).Value = txtbanco2.Text
                    FrmFacturasyAjustesSP.gfp.Item("tt", cant - 1).Value = ""
                Case "frs"
                    FrmFacturaEstetica.gfp.Item("cual", cant - 1).Value = "Cheque"
                    FrmFacturaEstetica.gfp.Item("detalle", cant - 1).Value = "cheque"
                    FrmFacturaEstetica.gfp.Item("monto", cant - 1).Value = txtvche.Text
                    FrmFacturaEstetica.gfp.Item("numero", cant - 1).Value = txtnumcheque2.Text
                    FrmFacturaEstetica.gfp.Item("banco", cant - 1).Value = txtbanco2.Text
                    FrmFacturaEstetica.gfp.Item("tt", cant - 1).Value = ""
            End Select

        End If
        If txtvt1.Text <> "0,00" Then ' tarjeta 1
            If txtnumtar1.Text = "" Or txttar1.Text = "" Then
                MsgBox("Faltan parametros de la tarjeta 1, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                txtnumtar1.Focus()
                Exit Sub
            End If
            cant = cant + 1
            'Frmfacturarapida.gfp.RowCount = cant
            Select Case lbform.Text
                Case "fr"
                    Frmfacturarapida.gfp.Item("cual", cant - 1).Value = "Tarjeta1"
                    Frmfacturarapida.gfp.Item("detalle", cant - 1).Value = txttar1.Text
                    Frmfacturarapida.gfp.Item("monto", cant - 1).Value = txtvt1.Text
                    Frmfacturarapida.gfp.Item("numero", cant - 1).Value = txtnumtar1.Text
                    Frmfacturarapida.gfp.Item("tt", cant - 1).Value = cbtarj1.Text
                    Frmfacturarapida.gfp.Item("banco", cant - 1).Value = ""
                Case "fn"
                    FrmFacturasyAjustes.gfp.Item("cual", cant - 1).Value = "Tarjeta1"
                    FrmFacturasyAjustes.gfp.Item("detalle", cant - 1).Value = txttar1.Text
                    FrmFacturasyAjustes.gfp.Item("monto", cant - 1).Value = txtvt1.Text
                    FrmFacturasyAjustes.gfp.Item("numero", cant - 1).Value = txtnumtar1.Text
                    FrmFacturasyAjustes.gfp.Item("tt", cant - 1).Value = cbtarj1.Text
                    FrmFacturasyAjustes.gfp.Item("banco", cant - 1).Value = ""
                Case "fn_sp"
                    FrmFacturasyAjustesSP.gfp.Item("cual", cant - 1).Value = "Tarjeta1"
                    FrmFacturasyAjustesSP.gfp.Item("detalle", cant - 1).Value = txttar1.Text
                    FrmFacturasyAjustesSP.gfp.Item("monto", cant - 1).Value = txtvt1.Text
                    FrmFacturasyAjustesSP.gfp.Item("numero", cant - 1).Value = txtnumtar1.Text
                    FrmFacturasyAjustesSP.gfp.Item("tt", cant - 1).Value = cbtarj1.Text
                    FrmFacturasyAjustesSP.gfp.Item("banco", cant - 1).Value = ""
                Case "frs"
                    FrmFacturaEstetica.gfp.Item("cual", cant - 1).Value = "Tarjeta1"
                    FrmFacturaEstetica.gfp.Item("detalle", cant - 1).Value = txttar1.Text
                    FrmFacturaEstetica.gfp.Item("monto", cant - 1).Value = txtvt1.Text
                    FrmFacturaEstetica.gfp.Item("numero", cant - 1).Value = txtnumtar1.Text
                    FrmFacturaEstetica.gfp.Item("tt", cant - 1).Value = cbtarj1.Text
                    FrmFacturaEstetica.gfp.Item("banco", cant - 1).Value = ""
            End Select

        End If
        If txtvt2.Text <> "0,00" Then ' tarjeta 2
            If txtnumtar2.Text = "" Or txttar2.Text = "" Then
                MsgBox("Faltan parametros de la tarjeta 2, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                txtnumtar2.Focus()
                Exit Sub
            End If
            cant = cant + 1
            'Frmfacturarapida.gfp.RowCount = cant
            Select Case lbform.Text
                Case "fr"
                    Frmfacturarapida.gfp.Item("cual", cant - 1).Value = "Tarjeta2"
                    Frmfacturarapida.gfp.Item("detalle", cant - 1).Value = txttar2.Text
                    Frmfacturarapida.gfp.Item("monto", cant - 1).Value = txtvt2.Text
                    Frmfacturarapida.gfp.Item("numero", cant - 1).Value = txtnumtar2.Text
                    Frmfacturarapida.gfp.Item("tt", cant - 1).Value = cbtarj2.Text
                    Frmfacturarapida.gfp.Item("banco", cant - 1).Value = ""
                Case "fn"
                    FrmFacturasyAjustes.gfp.Item("cual", cant - 1).Value = "Tarjeta2"
                    FrmFacturasyAjustes.gfp.Item("detalle", cant - 1).Value = txttar2.Text
                    FrmFacturasyAjustes.gfp.Item("monto", cant - 1).Value = txtvt2.Text
                    FrmFacturasyAjustes.gfp.Item("numero", cant - 1).Value = txtnumtar2.Text
                    FrmFacturasyAjustes.gfp.Item("tt", cant - 1).Value = cbtarj2.Text
                    FrmFacturasyAjustes.gfp.Item("banco", cant - 1).Value = ""
                Case "fn_sp"
                    FrmFacturasyAjustesSP.gfp.Item("cual", cant - 1).Value = "Tarjeta2"
                    FrmFacturasyAjustesSP.gfp.Item("detalle", cant - 1).Value = txttar2.Text
                    FrmFacturasyAjustesSP.gfp.Item("monto", cant - 1).Value = txtvt2.Text
                    FrmFacturasyAjustesSP.gfp.Item("numero", cant - 1).Value = txtnumtar2.Text
                    FrmFacturasyAjustesSP.gfp.Item("tt", cant - 1).Value = cbtarj2.Text
                    FrmFacturasyAjustesSP.gfp.Item("banco", cant - 1).Value = ""
                Case "frs"
                    FrmFacturaEstetica.gfp.Item("cual", cant - 1).Value = "Tarjeta2"
                    FrmFacturaEstetica.gfp.Item("detalle", cant - 1).Value = txttar2.Text
                    FrmFacturaEstetica.gfp.Item("monto", cant - 1).Value = txtvt2.Text
                    FrmFacturaEstetica.gfp.Item("numero", cant - 1).Value = txtnumtar2.Text
                    FrmFacturaEstetica.gfp.Item("tt", cant - 1).Value = cbtarj2.Text
                    FrmFacturaEstetica.gfp.Item("banco", cant - 1).Value = ""
            End Select

        End If
        If txtvt3.Text <> "0,00" Then ' tarjeta 3
            If txtnumtar3.Text = "" Or txttar3.Text = "" Then
                MsgBox("Faltan parametros de la tarjeta 3, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                txtnumtar3.Focus()
                Exit Sub
            End If
            cant = cant + 1
            Select Case lbform.Text
                Case "fr"
                    Frmfacturarapida.gfp.Item("cual", cant - 1).Value = "Tarjeta3"
                    Frmfacturarapida.gfp.Item("detalle", cant - 1).Value = txttar3.Text
                    Frmfacturarapida.gfp.Item("monto", cant - 1).Value = txtvt3.Text
                    Frmfacturarapida.gfp.Item("numero", cant - 1).Value = txtnumtar3.Text
                    Frmfacturarapida.gfp.Item("tt", cant - 1).Value = cbtarj3.Text
                    Frmfacturarapida.gfp.Item("banco", cant - 1).Value = ""
                Case "fn"
                    FrmFacturasyAjustes.gfp.Item("cual", cant - 1).Value = "Tarjeta3"
                    FrmFacturasyAjustes.gfp.Item("detalle", cant - 1).Value = txttar3.Text
                    FrmFacturasyAjustes.gfp.Item("monto", cant - 1).Value = txtvt3.Text
                    FrmFacturasyAjustes.gfp.Item("numero", cant - 1).Value = txtnumtar3.Text
                    FrmFacturasyAjustes.gfp.Item("tt", cant - 1).Value = cbtarj3.Text
                    FrmFacturasyAjustes.gfp.Item("banco", cant - 1).Value = ""
                Case "fn_sp"
                    FrmFacturasyAjustesSP.gfp.Item("cual", cant - 1).Value = "Tarjeta3"
                    FrmFacturasyAjustesSP.gfp.Item("detalle", cant - 1).Value = txttar3.Text
                    FrmFacturasyAjustesSP.gfp.Item("monto", cant - 1).Value = txtvt3.Text
                    FrmFacturasyAjustesSP.gfp.Item("numero", cant - 1).Value = txtnumtar3.Text
                    FrmFacturasyAjustesSP.gfp.Item("tt", cant - 1).Value = cbtarj3.Text
                    FrmFacturasyAjustesSP.gfp.Item("banco", cant - 1).Value = ""
                Case "frs"
                    FrmFacturaEstetica.gfp.Item("cual", cant - 1).Value = "Tarjeta3"
                    FrmFacturaEstetica.gfp.Item("detalle", cant - 1).Value = txttar3.Text
                    FrmFacturaEstetica.gfp.Item("monto", cant - 1).Value = txtvt3.Text
                    FrmFacturaEstetica.gfp.Item("numero", cant - 1).Value = txtnumtar3.Text
                    FrmFacturaEstetica.gfp.Item("tt", cant - 1).Value = cbtarj3.Text
                    FrmFacturaEstetica.gfp.Item("banco", cant - 1).Value = ""
            End Select
            'Frmfacturarapida.gfp.RowCount = cant

        End If
        If CDbl(txtvefec.Text) <> 0 Then
            cant = cant + 1
            'Frmfacturarapida.gfp.RowCount = cant
            Select Case lbform.Text
                Case "fr"
                    Frmfacturarapida.gfp.Item("cual", cant - 1).Value = "Efectivo"
                    Frmfacturarapida.gfp.Item("detalle", cant - 1).Value = "Efectivo"
                    Frmfacturarapida.gfp.Item("monto", cant - 1).Value = txtvefec.Text
                    Frmfacturarapida.gfp.Item("numero", cant - 1).Value = ""
                    Frmfacturarapida.gfp.Item("tt", cant - 1).Value = ""
                    Frmfacturarapida.gfp.Item("banco", cant - 1).Value = ""
                Case "fn"
                    FrmFacturasyAjustes.gfp.Item("cual", cant - 1).Value = "Efectivo"
                    FrmFacturasyAjustes.gfp.Item("detalle", cant - 1).Value = "Efectivo"
                    FrmFacturasyAjustes.gfp.Item("monto", cant - 1).Value = txtvefec.Text
                    FrmFacturasyAjustes.gfp.Item("numero", cant - 1).Value = ""
                    FrmFacturasyAjustes.gfp.Item("tt", cant - 1).Value = ""
                    FrmFacturasyAjustes.gfp.Item("banco", cant - 1).Value = ""
                Case "fn_sp"
                    FrmFacturasyAjustesSP.gfp.Item("cual", cant - 1).Value = "Efectivo"
                    FrmFacturasyAjustesSP.gfp.Item("detalle", cant - 1).Value = "Efectivo"
                    FrmFacturasyAjustesSP.gfp.Item("monto", cant - 1).Value = txtvefec.Text
                    FrmFacturasyAjustesSP.gfp.Item("numero", cant - 1).Value = ""
                    FrmFacturasyAjustesSP.gfp.Item("tt", cant - 1).Value = ""
                    FrmFacturasyAjustesSP.gfp.Item("banco", cant - 1).Value = ""
                Case "frs"
                    FrmFacturaEstetica.gfp.Item("cual", cant - 1).Value = "Efectivo"
                    FrmFacturaEstetica.gfp.Item("detalle", cant - 1).Value = "Efectivo"
                    FrmFacturaEstetica.gfp.Item("monto", cant - 1).Value = txtvefec.Text
                    FrmFacturaEstetica.gfp.Item("numero", cant - 1).Value = ""
                    FrmFacturaEstetica.gfp.Item("tt", cant - 1).Value = ""
                    FrmFacturaEstetica.gfp.Item("banco", cant - 1).Value = ""
            End Select
        End If
        Select Case lbform.Text
            Case "fr"
                Frmfacturarapida.txtcuentatotal.Text = txtcuenta.Text
            Case "fn"
                FrmFacturasyAjustes.txtcuentatotal.Text = txtcuenta.Text
            Case "fn_sp"
                FrmFacturasyAjustesSP.txtcuentatotal.Text = txtcuenta.Text
            Case "frs"
                FrmFacturaEstetica.txtcuentatotal.Text = txtcuenta.Text
        End Select
        Me.Close()
    End Sub
    Public Sub FormaDePago()
         Select lbform.Text
            Case "fr"
                Frmfacturarapida.gfp.Rows.Clear()
                Frmfacturarapida.gfp.RowCount = 1
                Frmfacturarapida.gfp.Item(0, 0).Value = ""
                Frmfacturarapida.gfp.Item("detalle", 0).Value = ""
                Frmfacturarapida.gfp.Item("numero", 0).Value = ""
                Frmfacturarapida.gfp.Item("banco", 0).Value = ""
                Frmfacturarapida.gfp.Item("tt", 0).Value = ""
            Case "frs"
                FrmFacturaEstetica.gfp.Rows.Clear()
                FrmFacturaEstetica.gfp.RowCount = 1
                FrmFacturaEstetica.gfp.Item(0, 0).Value = ""
                FrmFacturaEstetica.gfp.Item("detalle", 0).Value = ""
                FrmFacturaEstetica.gfp.Item("numero", 0).Value = ""
                FrmFacturaEstetica.gfp.Item("banco", 0).Value = ""
                FrmFacturaEstetica.gfp.Item("tt", 0).Value = ""
            Case "fn"
                FrmFacturasyAjustes.gfp.Rows.Clear()
                FrmFacturasyAjustes.gfp.RowCount = 1
                FrmFacturasyAjustes.gfp.Item(0, 0).Value = ""
                FrmFacturasyAjustes.gfp.Item("detalle", 0).Value = ""
                FrmFacturasyAjustes.gfp.Item("numero", 0).Value = ""
                FrmFacturasyAjustes.gfp.Item("banco", 0).Value = ""
                FrmFacturasyAjustes.gfp.Item("tt", 0).Value = ""
            Case "fn_sp"
                FrmFacturasyAjustesSP.gfp.Rows.Clear()
                FrmFacturasyAjustesSP.gfp.RowCount = 1
                FrmFacturasyAjustesSP.gfp.Item(0, 0).Value = ""
                FrmFacturasyAjustesSP.gfp.Item("detalle", 0).Value = ""
                FrmFacturasyAjustesSP.gfp.Item("numero", 0).Value = ""
                FrmFacturasyAjustesSP.gfp.Item("banco", 0).Value = ""
                FrmFacturasyAjustesSP.gfp.Item("tt", 0).Value = ""
            Case "fp"
                FrmDocProveedor.gfp.Rows.Clear()
                FrmDocProveedor.gfp.RowCount = 1
                FrmDocProveedor.gfp.Item(0, 0).Value = ""
                FrmDocProveedor.gfp.Item("detalle", 0).Value = ""
                FrmDocProveedor.gfp.Item("numero", 0).Value = ""
                FrmDocProveedor.gfp.Item("banco", 0).Value = ""
                FrmDocProveedor.gfp.Item("tt", 0).Value = ""
            Case "sal"
                FrmSalidas.txtvmto.Text = "0"
                FrmSalidas.txtctapago.Text = ""
        End Select
        Select Case lbfp.Text
            Case "Pagar Con Efectivo"
                Select Case lbform.Text
                    Case "fr"
                        Frmfacturarapida.gfp.Item("cual", 0).Value = "Efectivo"
                        Frmfacturarapida.gfp.Item("detalle", 0).Value = "Efectivo"
                    Case "frs"
                        FrmFacturaEstetica.gfp.Item("cual", 0).Value = "Efectivo"
                        FrmFacturaEstetica.gfp.Item("detalle", 0).Value = "Efectivo"
                    Case "fn"
                        FrmFacturasyAjustes.gfp.Item("cual", 0).Value = "Efectivo"
                        FrmFacturasyAjustes.gfp.Item("detalle", 0).Value = "Efectivo"
                    Case "fn_sp"
                        FrmFacturasyAjustesSP.gfp.Item("cual", 0).Value = "Efectivo"
                        FrmFacturasyAjustesSP.gfp.Item("detalle", 0).Value = "Efectivo"
                    Case "fp"
                        FrmDocProveedor.gfp.Item("cual", 0).Value = "Efectivo"
                        FrmDocProveedor.gfp.Item("detalle", 0).Value = "Efectivo"
                    Case "sal"
                        FrmSalidas.txtcual.Text = "Efectivo"
                End Select

            Case "Pagar Con Cheque"
                If txtnumcheq.Text = "" Or txtbanco.Text = "" Then
                    MsgBox("Faltan parametros del cheque, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                    txtnumcheq.Focus()
                    Exit Sub
                End If
                Select Case lbform.Text
                    Case "fr"
                        Frmfacturarapida.gfp.Item("detalle", 0).Value = "pago con cheque"
                        Frmfacturarapida.gfp.Item("cual", 0).Value = "Cheque"
                        Frmfacturarapida.gfp.Item("numero", 0).Value = txtnumcheq.Text
                        Frmfacturarapida.gfp.Item("banco", 0).Value = txtbanco.Text
                    Case "frs"
                        FrmFacturaEstetica.gfp.Item("detalle", 0).Value = "pago con cheque"
                        FrmFacturaEstetica.gfp.Item("cual", 0).Value = "Cheque"
                        FrmFacturaEstetica.gfp.Item("numero", 0).Value = txtnumcheq.Text
                        FrmFacturaEstetica.gfp.Item("banco", 0).Value = txtbanco.Text
                    Case "fn"
                        FrmFacturasyAjustes.gfp.Item("detalle", 0).Value = "pago con cheque"
                        FrmFacturasyAjustes.gfp.Item("cual", 0).Value = "Cheque"
                        FrmFacturasyAjustes.gfp.Item("numero", 0).Value = txtnumcheq.Text
                        FrmFacturasyAjustes.gfp.Item("banco", 0).Value = txtbanco.Text
                    Case "fn_sp"
                        FrmFacturasyAjustesSP.gfp.Item("detalle", 0).Value = "pago con cheque"
                        FrmFacturasyAjustesSP.gfp.Item("cual", 0).Value = "Cheque"
                        FrmFacturasyAjustesSP.gfp.Item("numero", 0).Value = txtnumcheq.Text
                        FrmFacturasyAjustesSP.gfp.Item("banco", 0).Value = txtbanco.Text
                    Case "fp"
                        FrmDocProveedor.gfp.Item("detalle", 0).Value = "pago con cheque"
                        FrmDocProveedor.gfp.Item("cual", 0).Value = "Cheque"
                        FrmDocProveedor.gfp.Item("numero", 0).Value = txtnumcheq.Text
                        FrmDocProveedor.gfp.Item("banco", 0).Value = txtbanco.Text
                    Case "sal"
                        FrmSalidas.txtcual.Text = "Cheque"
                End Select

            Case "Pagar Con Tarjeta"
                If txttarjeta.Text = "" Or txtnumtarjeta.Text = "" Or cbtarj.Text = "" Then
                    MsgBox("Faltan parametros de la tarjeta, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                    txttarjeta.Focus()
                    Exit Sub
                End If
                Select Case lbform.Text
                    Case "fr"
                        Frmfacturarapida.gfp.Item("cual", 0).Value = "Tarjeta"
                        Frmfacturarapida.gfp.Item("detalle", 0).Value = txttarjeta.Text
                        Frmfacturarapida.gfp.Item("numero", 0).Value = txtnumtarjeta.Text
                        Frmfacturarapida.gfp.Item("tt", 0).Value = cbtarj.Text
                    Case "frs"
                        FrmFacturaEstetica.gfp.Item("cual", 0).Value = "Tarjeta"
                        FrmFacturaEstetica.gfp.Item("detalle", 0).Value = txttarjeta.Text
                        FrmFacturaEstetica.gfp.Item("numero", 0).Value = txtnumtarjeta.Text
                        FrmFacturaEstetica.gfp.Item("tt", 0).Value = cbtarj.Text
                    Case "fn"
                        FrmFacturasyAjustes.gfp.Item("cual", 0).Value = "Tarjeta"
                        FrmFacturasyAjustes.gfp.Item("detalle", 0).Value = txttarjeta.Text
                        FrmFacturasyAjustes.gfp.Item("numero", 0).Value = txtnumtarjeta.Text
                        FrmFacturasyAjustes.gfp.Item("tt", 0).Value = cbtarj.Text
                    Case "fn_sp"
                        FrmFacturasyAjustesSP.gfp.Item("cual", 0).Value = "Tarjeta"
                        FrmFacturasyAjustesSP.gfp.Item("detalle", 0).Value = txttarjeta.Text
                        FrmFacturasyAjustesSP.gfp.Item("numero", 0).Value = txtnumtarjeta.Text
                        FrmFacturasyAjustesSP.gfp.Item("tt", 0).Value = cbtarj.Text
                    Case "fp"
                        FrmDocProveedor.gfp.Item("cual", 0).Value = "Tarjeta"
                        FrmDocProveedor.gfp.Item("detalle", 0).Value = txttarjeta.Text
                        FrmDocProveedor.gfp.Item("numero", 0).Value = txtnumtarjeta.Text
                        FrmDocProveedor.gfp.Item("tt", 0).Value = cbtarj.Text
                    Case "sal"
                        FrmSalidas.txtcual.Text = "Tarjeta"
                End Select

            Case "Pagar Con Otro Medio"
                If txtespecifica.Text = "" Then
                    MsgBox("Favor especifique la forma de pago, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                    txtespecifica.Focus()
                    Exit Sub
                End If
                Select Case lbform.Text
                    Case "fr"
                        Frmfacturarapida.gfp.Item("detalle", 0).Value = txtespecifica.Text
                        Frmfacturarapida.gfp.Item("cual", 0).Value = "Otra"
                        Frmfacturarapida.txtvmto.Text = txtdias.Text
                    Case "frs"
                        FrmFacturaEstetica.gfp.Item("detalle", 0).Value = txtespecifica.Text
                        FrmFacturaEstetica.gfp.Item("cual", 0).Value = "Otra"
                        FrmFacturaEstetica.txtvmto.Text = txtdias.Text
                    Case "fn"
                        FrmFacturasyAjustes.gfp.Item("detalle", 0).Value = txtespecifica.Text
                        FrmFacturasyAjustes.gfp.Item("cual", 0).Value = "Otra"
                        FrmFacturasyAjustes.txtvmto.Text = txtdias.Text
                    Case "fn_sp"
                        FrmFacturasyAjustesSP.gfp.Item("detalle", 0).Value = txtespecifica.Text
                        FrmFacturasyAjustesSP.gfp.Item("cual", 0).Value = "Otra"
                        FrmFacturasyAjustesSP.txtvmto.Text = txtdias.Text
                    Case "fp"
                        FrmDocProveedor.gfp.Item("detalle", 0).Value = txtespecifica.Text
                        FrmDocProveedor.gfp.Item("cual", 0).Value = "Otra"
                        FrmDocProveedor.txtvmto.Text = txtdias.Text
                    Case "sal"
                        FrmSalidas.txtvmto.Text = txtdias.Text
                        FrmSalidas.txtcual.Text = "Otra"
                End Select
        End Select
        If CDec(txtcambio.Text) < 0 Then
            MsgBox("El valor del pago no puede ser menor que el del monto de la factura, Verifique.  ", MsgBoxStyle.Information, "Verificando")
            txtpago.Focus()
            Exit Sub
        End If
        Select Case lbform.Text
            Case "fr"
                Frmfacturarapida.gfp.Item("monto", 0).Value = txtpago.Text
                Frmfacturarapida.txtcuentatotal.Text = txtcuenta.Text
            Case "frs"
                FrmFacturaEstetica.gfp.Item("monto", 0).Value = txtpago.Text
                FrmFacturaEstetica.txtcuentatotal.Text = txtcuenta.Text
            Case "fn"
                FrmFacturasyAjustes.gfp.Item("monto", 0).Value = txtpago.Text
                FrmFacturasyAjustes.txtcuentatotal.Text = txtcuenta.Text
            Case "fn_sp"
                FrmFacturasyAjustesSP.gfp.Item("monto", 0).Value = txtpago.Text
                FrmFacturasyAjustesSP.txtcuentatotal.Text = txtcuenta.Text
            Case "fp"
                FrmDocProveedor.gfp.Item("monto", 0).Value = txtpago.Text
                FrmDocProveedor.txtcuentatotal.Text = txtcuenta.Text
            Case "sal"
                FrmSalidas.txtforma.Text = lbfp.Text
                FrmSalidas.txtctapago.Text = txtcuenta.Text
        End Select
        Me.Close()
    End Sub
    Private Sub cmdcuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcuenta.Click
        FrmCuentas.lbform.Text = "fp"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub rbndia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbndia.CheckedChanged
        txtdias.Enabled = False
        txtdias.Text = "0"
    End Sub

    Private Sub rbsdia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbsdia.CheckedChanged
        txtdias.Enabled = True
    End Sub
    Private Sub txtdias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdias.KeyPress
        validarnumero(txtdias, e)
    End Sub
    Private Sub txtvche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvche.TextChanged
        SumarTotal()
    End Sub
    Private Sub txtvt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvt1.TextChanged
        SumarTotal()
    End Sub
    Private Sub txtvt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvt2.TextChanged
        SumarTotal()
    End Sub
    Private Sub txtvt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvt3.TextChanged
        SumarTotal()
    End Sub
    Private Sub txtvefec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvefec.TextChanged
        SumarTotal()
    End Sub

    Private Sub cmdcancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancelar.GotFocus
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
   
End Class