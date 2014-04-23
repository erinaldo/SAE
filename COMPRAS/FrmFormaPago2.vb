Public Class FrmFormaPago2
    Private Sub cmdcheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcheque.Click
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        lbfp.Text = "Pagar Con Cheque"
        If lbform.Text = "cpp_eg" Then
            cuentatotal("SELECT cta_banco FROM par_comp;")
        Else
            cuentatotal("SELECT bancos FROM parafacgral;")
        End If
        txtpago.Text = txttotal.Text
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = True
        gtar.Enabled = False
        txtnumcheq.Focus()
    End Sub
    Private Sub cmdtarjeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtarjeta.Click
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        txtpago.Text = txttotal.Text
        lbfp.Text = "Pagar Con Tarjeta"
        If lbform.Text = "cpp_eg" Then
            cuentatotal("SELECT cta_banco FROM par_comp;")
        Else
            cuentatotal("SELECT bancos FROM parafacgral;")
        End If
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = False
        gtar.Enabled = True
        txttarjeta.Focus()
    End Sub
    Private Sub cmdefectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdefectivo.Click
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        lbfp.Text = "Pagar Con Efectivo"
        If lbform.Text = "cpp_eg" Then
            cuentatotal("SELECT cta_caja FROM par_comp;")
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
    '//////// EVENTOS DE LAS CAJAS DE TEXTO /////////////
    Private Sub txtpago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpago.KeyPress
        ValidarMoneda(txtpago, e)
        txtpago.ForeColor = Color.MediumSeaGreen
    End Sub
    Private Sub txtpago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpago.TextChanged
        txtpago.Text = Moneda(CDbl(txtpago.Text))
        txtcambio.Text = Moneda(CDec(txtpago.Text) - CDec(txttotal.Text))
    End Sub
    Private Sub txttotal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.DoubleClick
        txtpago.Text = txttotal.Text
    End Sub
    Private Sub cmdcuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcuenta.Click
        FrmCuentas.lbform.Text = "fp2"
        FrmCuentas.ShowDialog()
    End Sub
    '******************************
    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        Try
            If Trim(lbfp.Text) = "" Then
                MsgBox("Verifique la forma de pago", MsgBoxStyle.Information, "Seleccione una forma de pago")
                Exit Sub
            End If
            FormaDePago()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormaDePago()
        Try
            Select Case lbform.Text
                Case "cpp_eg"
                    FrmItemsCPP.lbfp.Text = " "
                    FrmItemsCPP.lbnum.Text = " "
                    FrmItemsCPP.lbbanco.Text = " "
                    FrmItemsCPP.lbtipotar.Text = " "
                    FrmItemsCPP.lbctafp.Text = txtcuenta.Text 'cta forma de pago
                Case "cpc_rc"
                    FrmItemCartera.lbfp.Text = " "
                    FrmItemCartera.lbnum.Text = " "
                    FrmItemCartera.lbbanco.Text = " "
                    FrmItemCartera.lbtipotar.Text = " "
                    FrmItemCartera.lbctafp.Text = txtcuenta.Text 'cta forma de pago
            End Select
            '*****************************************************
            Select Case lbfp.Text
                Case "Pagar Con Efectivo"
                    Select Case lbform.Text
                        Case "cpp_eg"
                            FrmItemsCPP.lbfp.Text = "efectivo"
                        Case "cpc_rc"
                            FrmItemCartera.lbfp.Text = "efectivo"
                    End Select
                Case "Pagar Con Cheque"
                    If txtnumcheq.Text = "" Or txtbanco.Text = "" Then
                        MsgBox("Faltan parametros del cheque, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                        txtnumcheq.Focus()
                        Exit Sub
                    End If
                    Select Case lbform.Text
                        Case "cpp_eg"
                            FrmItemsCPP.lbfp.Text = "cheque"
                            FrmItemsCPP.lbnum.Text = txtnumcheq.Text
                            FrmItemsCPP.lbbanco.Text = txtbanco.Text
                        Case "cpc_rc"
                            FrmItemCartera.lbfp.Text = "cheque"
                            FrmItemCartera.lbnum.Text = txtnumcheq.Text
                            FrmItemCartera.lbbanco.Text = txtbanco.Text
                    End Select
                Case "Pagar Con Consignacion"
                    If txtnumcheq.Text = "" Or txtbanco.Text = "" Then
                        MsgBox("Faltan parametros de la consignacion, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                        txtnumcheq.Focus()
                        Exit Sub
                    End If
                    Select Case lbform.Text
                        Case "cpp_eg"
                            FrmItemsCPP.lbfp.Text = "consignacion"
                            FrmItemsCPP.lbnum.Text = txtnumcheq.Text
                            FrmItemsCPP.lbbanco.Text = txtbanco.Text
                        Case "cpc_rc"
                            FrmItemCartera.lbfp.Text = "consignacion"
                            FrmItemCartera.lbnum.Text = txtnumcheq.Text
                            FrmItemCartera.lbbanco.Text = txtbanco.Text
                    End Select
                Case "Pagar Con Tarjeta"
                    If txttarjeta.Text = "" Or txtnumtarjeta.Text = "" Or cbtarj.Text = "" Then
                        MsgBox("Faltan parametros de la tarjeta, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                        txttarjeta.Focus()
                        Exit Sub
                    End If
                    Select Case lbform.Text
                        Case "cpp_eg"
                            FrmItemsCPP.lbfp.Text = "tarjeta"
                            FrmItemsCPP.lbnum.Text = txtnumtarjeta.Text 'numero de tarjeta
                            FrmItemsCPP.lbbanco.Text = txttarjeta.Text 'tarjeta
                            FrmItemsCPP.lbtipotar.Text = cbtarj.Text 'tipo tarjeta (DB/CR)                        
                        Case "cpc_rc"
                            FrmItemCartera.lbfp.Text = "tarjeta"
                            FrmItemCartera.lbnum.Text = txtnumtarjeta.Text 'numero de tarjeta
                            FrmItemCartera.lbbanco.Text = txttarjeta.Text 'tarjeta
                            FrmItemCartera.lbtipotar.Text = cbtarj.Text 'tipo tarjeta (DB/CR)                        
                    End Select
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
            Try
                Select Case lbform.Text
                    Case "cpp_eg"
                        FrmItemsCPP.lbctafp.Text = txtcuenta.Text 'cta forma de pago
                    Case "cpc_rc"
                        FrmItemCartera.lbctafp.Text = txtcuenta.Text 'cta forma de pago
                End Select
            Catch ex2 As Exception
                MsgBox(ex2.ToString)
            End Try
        End Try
        Me.Close()
    End Sub
    '******** ENTER => TAB ***************
    Private Sub txtnumcheq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumcheq.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txttarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttarjeta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbtarj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbtarj.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnumtarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumtarjeta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdcancelar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdcancelar.GotFocus
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdbanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbanco.Click
        txtnumcheq.Text = ""
        txtbanco.Text = ""
        txtnumtarjeta.Text = ""
        txttarjeta.Text = ""
        lbfp.Text = "Pagar Con Consignacion"
        If lbform.Text = "cpp_eg" Then
            cuentatotal("SELECT cta_banco FROM par_comp;")
        Else
            cuentatotal("SELECT bancos FROM parafacgral;")
        End If
        txtpago.Text = txttotal.Text
        txtpago.ReadOnly = False
        '''''' '''''''
        gche.Enabled = True
        gtar.Enabled = False
        txtnumcheq.Focus()
    End Sub
End Class