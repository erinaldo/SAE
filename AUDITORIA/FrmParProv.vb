Public Class FrmParProv

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Dim tipo As String = ""
    Private Sub FrmParProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '******************************
        Dim tabla3 As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" + FrmPrincipal.lbcompania.Text + "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)
        tipo = tabla3.Rows(0).Item("tipo")
        If tipo = "comercial" Then
            tipo = "puc"
        ElseIf tipo = "cooperativo" Then
            tipo = "puc_coop"
        ElseIf tipo = "publico" Then
            tipo = "puc_public"
        Else
            tipo = "puc_salud"
        End If
        '********************************

        '----------------- llenar txt facturacion
        Dim t3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM audi_parcom ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        If t3.Rows.Count > 0 Then
            txtcaja.Text = t3.Rows(0).Item(1)
            txtbanco.Text = t3.Rows(0).Item(2)
            txtcxp.Text = t3.Rows(0).Item(3)
            txtgas.Text = t3.Rows(0).Item(4)
            txtcomp.Text = t3.Rows(0).Item(5)
            txtdesc.Text = t3.Rows(0).Item(6)
            txtinv.Text = t3.Rows(0).Item(7)
            txtivap.Text = t3.Rows(0).Item(8)
            txtivad.Text = t3.Rows(0).Item(9)
            txtrtf.Text = t3.Rows(0).Item(10)
            txtfle.Text = t3.Rows(0).Item(11)
            txtseg.Text = t3.Rows(0).Item(12)
            txtpc.Text = t3.Rows(0).Item(13)
            txtpd.Text = t3.Rows(0).Item(14)
        End If
        '......................................
    End Sub

    Private Sub cmdparfac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparfac.Click
        Guard()
    End Sub
    Public Sub Guard()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros para auditar las transacciones de compras se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM audi_parcom ;"
            myCommand.ExecuteNonQuery()


            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?tpuc", tipo)
            myCommand.Parameters.AddWithValue("?c1", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?c2", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?c3", txtcxp.Text.ToString)
            myCommand.Parameters.AddWithValue("?c4", txtgas.Text.ToString)
            myCommand.Parameters.AddWithValue("?c5", txtcomp.Text.ToString)
            myCommand.Parameters.AddWithValue("?c6", txtdesc.Text.ToString)
            myCommand.Parameters.AddWithValue("?c7", txtinv.Text.ToString)
            myCommand.Parameters.AddWithValue("?c8", txtivap.Text.ToString)
            myCommand.Parameters.AddWithValue("?c9", txtivad.Text.ToString)
            myCommand.Parameters.AddWithValue("?c10", txtrtf.Text.ToString)
            myCommand.Parameters.AddWithValue("?c11", txtfle.Text.ToString)
            myCommand.Parameters.AddWithValue("?c12", txtseg.Text.ToString)
            myCommand.Parameters.AddWithValue("?c13", txtpc.Text.ToString)
            myCommand.Parameters.AddWithValue("?c14", txtpd.Text.ToString)

            myCommand.CommandText = "INSERT INTO audi_parcom VALUES(?tpuc,?c1,?c2, ?c3,?c4,?c5,?c6,?c7,?c8,?c9,?c10,?c11,?c12,?c13,?c14 );"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
        End If
    End Sub

    Private Sub txtbanco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanco.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_ban"
            FrmCuentas.txtcuenta.Text = txtbanco.Text
            FrmCuentas.lbaux.Text = "todas"
            txtbanco.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        validarnumero(txtbanco, e)
    End Sub
    'Private Sub txtbanco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanco.LostFocus

    '    If FrmParFac.buscarCuenta(txtbanco.Text) = True Then
    '        Try
    '            txtbanco_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub txtcaja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_caj"
            FrmCuentas.txtcuenta.Text = txtcaja.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcaja.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaja.KeyPress
        ValidarNIT(txtcaja, e)
    End Sub
    'Private Sub txtcaja_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.LostFocus
    '    If FrmParFac.buscarCuenta(txtcaja.Text) = True Then
    '        Try
    '            txtcaja_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtcomp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcomp.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_comp"
            FrmCuentas.txtcuenta.Text = txtcomp.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcomp.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcomp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcomp.KeyPress
        validarnumero(txtcomp, e)
    End Sub
    'Private Sub txtcomp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcomp.LostFocus
    '    If FrmParFac.buscarCuenta(txtcomp.Text) = True Then
    '        Try
    '            txtcomp_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtcxp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcxp.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_cxp"
            FrmCuentas.txtcuenta.Text = txtcxp.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcxp.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcxp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcxp.KeyPress
        validarnumero(txtcxp, e)
    End Sub
    'Private Sub txtcxp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcxp.LostFocus
    '    If FrmParFac.buscarCuenta(txtcxp.Text) = True Then
    '        Try
    '            txtcxp_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtdesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesc.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_des"
            FrmCuentas.txtcuenta.Text = txtdesc.Text
            FrmCuentas.lbaux.Text = "todas"
            txtdesc.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        validarnumero(txtdesc, e)
    End Sub
    'Private Sub txtdesc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesc.LostFocus
    '    If FrmParFac.buscarCuenta(txtdesc.Text) = True Then
    '        Try
    '            txtdesc_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub txtgas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgas.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_gas"
            FrmCuentas.txtcuenta.Text = txtgas.Text
            FrmCuentas.lbaux.Text = "todas"
            txtgas.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtgas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgas.KeyPress
        validarnumero(txtgas, e)
    End Sub
    'Private Sub txtgas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgas.LostFocus
    '    If FrmParFac.buscarCuenta(txtgas.Text) = True Then
    '        Try
    '            txtgas_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtinv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinv.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_inv"
            FrmCuentas.txtcuenta.Text = txtinv.Text
            FrmCuentas.lbaux.Text = "todas"
            txtinv.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtinv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinv.KeyPress
        validarnumero(txtinv, e)
    End Sub
    'Private Sub txtinv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinv.LostFocus
    '    If FrmParFac.buscarCuenta(txtinv.Text) = True Then
    '        Try
    '            txtinv_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtivad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivad.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_ivad"
            FrmCuentas.txtcuenta.Text = txtivad.Text
            FrmCuentas.lbaux.Text = "todas"
            txtivad.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtivad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivad.KeyPress
        validarnumero(txtivad, e)
    End Sub
    'Private Sub txtivad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivad.LostFocus
    '    If FrmParFac.buscarCuenta(txtivad.Text) = True Then
    '        Try
    '            txtivad_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtivap_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivap.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_ivap"
            FrmCuentas.txtcuenta.Text = txtivap.Text
            FrmCuentas.lbaux.Text = "todas"
            txtivap.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtivap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivap.KeyPress
        validarnumero(txtivap, e)
    End Sub
    'Private Sub txtivap_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivap.LostFocus
    '    If FrmParFac.buscarCuenta(txtivap.Text) = True Then
    '        Try
    '            txtivap_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtrtf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrtf.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_rtf"
            FrmCuentas.txtcuenta.Text = txtrtf.Text
            FrmCuentas.lbaux.Text = "todas"
            txtrtf.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtrtf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrtf.KeyPress
        validarnumero(txtrtf, e)
    End Sub
    'Private Sub txtrtf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrtf.LostFocus
    '    If FrmParFac.buscarCuenta(txtrtf.Text) = True Then
    '        Try
    '            txtrtf_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub txtfle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfle.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_fle"
            FrmCuentas.txtcuenta.Text = txtfle.Text
            FrmCuentas.lbaux.Text = "todas"
            txtfle.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtfle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfle.KeyPress
        validarnumero(txtfle, e)
    End Sub
    'Private Sub txtfle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfle.LostFocus
    '    If FrmParFac.buscarCuenta(txtfle.Text) = True Then
    '        Try
    '            txtfle_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtseg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtseg.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_seg"
            FrmCuentas.txtcuenta.Text = txtseg.Text
            FrmCuentas.lbaux.Text = "todas"
            txtseg.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtseg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtseg.KeyPress
        validarnumero(txtseg, e)
    End Sub
    'Private Sub txtseg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtseg.LostFocus
    '    If FrmParFac.buscarCuenta(txtseg.Text) = True Then
    '        Try
    '            txtseg_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub txtpc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpc.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_pc"
            FrmCuentas.txtcuenta.Text = txtpc.Text
            FrmCuentas.lbaux.Text = "todas"
            txtpc.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtpc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpc.KeyPress
        validarnumero(txtpc, e)
    End Sub
    'Private Sub txtpc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpc.LostFocus
    '    If FrmParFac.buscarCuenta(txtpc.Text) = True Then
    '        Try
    '            txtpc_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtpd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpd.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_pro_pd"
            FrmCuentas.txtcuenta.Text = txtpd.Text
            FrmCuentas.lbaux.Text = "todas"
            txtpd.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtpd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpd.KeyPress
        validarnumero(txtpd, e)
    End Sub
    'Private Sub txtpd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpd.LostFocus
    '    If FrmParFac.buscarCuenta(txtpd.Text) = True Then
    '        Try
    '            txtpd_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub


End Class