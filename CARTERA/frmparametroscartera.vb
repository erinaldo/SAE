Public Class frmparametroscartera

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If cbint.Text = "SI" And cbtipoint.Text = "" Then
            MsgBox("Parametros de Intereses moratorios Incompletos, Verifique", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        If cbint.Text = "SI" And (txtmonto.Text = Moneda(0) Or txtmonto.Text = "0,000000") Then
            MsgBox("Parametros de Intereses moratorios Incompletos, Verifique", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If

        If lb.Text = "NUEVO" Then
            GuardarParametros()
        Else
            ModificarParametros()
        End If
    End Sub
    Public Sub GuardarParametros()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de Cuentas Por Cobrar general se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            myCommand.Parameters.Clear()
            Refresh()

            myCommand.Parameters.AddWithValue("?par_fac1", txttipo1.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac2", txttipo2.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac3", txttipo3.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac4", txttipo4.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_aju", txtajust.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_rc", txtrcc.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_ci", txtrc.Text.ToString)
            
            '********************************************************************
            If rbcont1.Checked = True Then
                myCommand.Parameters.AddWithValue("?par_int", "SI")
            Else
                myCommand.Parameters.AddWithValue("?par_int", "NO")
            End If
            myCommand.Parameters.AddWithValue("?par_cta_caja", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ban", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_cco", txtctapc.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ret", txtretencion.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ven", txtventas.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_iva", txtivapp.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_des", txtdescuento.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_sal_ini", "1981,06,06")
            myCommand.Parameters.AddWithValue("?par_cta_pos", "000000000000")
            myCommand.Parameters.AddWithValue("?par_posf", "00")
            myCommand.Parameters.AddWithValue("?par_blq_cup", "NO")
            myCommand.Parameters.AddWithValue("?par_dia_ven", "NO")
            myCommand.Parameters.AddWithValue("?par_blq_mor", "NO")
            myCommand.Parameters.AddWithValue("?par_blq_exc", "NO")
            myCommand.Parameters.AddWithValue("?par_rcb_apr", "NO")
            myCommand.Parameters.AddWithValue("?par_nro_rec", "NO")
            myCommand.Parameters.AddWithValue("?par_pag_com", "NO")
            myCommand.Parameters.AddWithValue("?par_com_var", "NO")
            myCommand.Parameters.AddWithValue("?par_env_cor", "NO")
            '**************************************
            myCommand.Parameters.AddWithValue("?hay_int", cbint.Text.ToString)
            myCommand.Parameters.AddWithValue("?mon_int", txtmonto.Text.ToString.Replace(",", "."))
            myCommand.Parameters.AddWithValue("?tip_int", cbtipoint.Text.ToString)
            myCommand.Parameters.AddWithValue("?cta_mor", txtmora.Text.ToString)
            '********************************************************************
            If rbccS.Checked = True Then
                myCommand.Parameters.AddWithValue("?concomi", "SI")
            Else
                myCommand.Parameters.AddWithValue("?concomi", "NO")
            End If
            If cheditar.Checked = True Then
                myCommand.Parameters.AddWithValue("?mod", "SI")
            Else
                myCommand.Parameters.AddWithValue("?mod", "NO")
            End If
            myCommand.CommandText = "INSERT INTO car_par VALUES(?par_fac1,?par_fac2, ?par_fac3, ?par_fac4, ?par_aju, ?par_rc, ?par_ci,?par_posf, ?par_int, ?par_cta_caja," _
                                  & "?par_cta_ban,?par_cta_ret,?par_cta_des,?par_cta_iva,?par_cta_ven,?par_cta_pos,?par_cta_cco,?par_sal_ini,?par_blq_cup,?par_dia_ven,?par_blq_mor,?par_blq_exc,?par_rcb_apr,?par_nro_rec,?par_pag_com,?par_com_var,?par_env_cor," _
                                  & "?hay_int,?mon_int,?tip_int,?cta_mor,?concomi,?mod);"
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                Cerrar()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            'myCommand.CommandText = "delete from listasprec where numlist >" & gitems.RowCount & ";"
            'myCommand.ExecuteNonQuery()
            'For i = 0 To gitems.RowCount - 1
            '    GuardarListasDePrecios(gitems.Item(0, i).Value, gitems.Item(1, i).Value)
            'Next
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lb.Text = ""
            Me.Close()
        End If
    End Sub

    Public Sub ModificarParametros()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de Cartera se van ha modifcar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            Refresh()

            myCommand.Parameters.AddWithValue("?par_fac1", txttipo1.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac2", txttipo2.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac3", txttipo3.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_fac4", txttipo4.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_aju", txtajust.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_rc", txtrcc.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_ci", txtrc.Text.ToString)

            '********************************************************************

            If rbcont1.Checked = True Then
                myCommand.Parameters.AddWithValue("?par_int", "SI")
            Else
                myCommand.Parameters.AddWithValue("?par_int", "NO")
            End If

            myCommand.Parameters.AddWithValue("?par_cta_caja", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ban", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_cco", txtctapc.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ret", txtretencion.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_ven", txtventas.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_iva", txtivapp.Text.ToString)
            myCommand.Parameters.AddWithValue("?par_cta_des", txtdescuento.Text.ToString)
            'myCommand.Parameters.AddWithValue("?par_sal_ini", "1981,06,06")
            'myCommand.Parameters.AddWithValue("?par_cta_pos", "000000000000")
            'myCommand.Parameters.AddWithValue("?par_posf", "00")
            myCommand.Parameters.AddWithValue("?par_blq_cup", "NO")
            myCommand.Parameters.AddWithValue("?par_dia_ven", "NO")
            myCommand.Parameters.AddWithValue("?par_blq_mor", "NO")
            myCommand.Parameters.AddWithValue("?par_blq_exc", "NO")
            myCommand.Parameters.AddWithValue("?par_rcb_apr", "NO")
            myCommand.Parameters.AddWithValue("?par_nro_rec", "NO")
            myCommand.Parameters.AddWithValue("?par_pag_com", "NO")
            myCommand.Parameters.AddWithValue("?par_com_var", "NO")
            myCommand.Parameters.AddWithValue("?par_env_cor", "NO")
            '*******************************
            myCommand.Parameters.AddWithValue("?hay_int", cbint.Text.ToString)
            myCommand.Parameters.AddWithValue("?mon_int", txtmonto.Text.ToString.Replace(",", "."))
            myCommand.Parameters.AddWithValue("?tip_int", cbtipoint.Text.ToString)
            myCommand.Parameters.AddWithValue("?cta_mor", txtmora.Text.ToString)
            '********************************************************************
            If rbccS.Checked = True Then
                myCommand.Parameters.AddWithValue("?concomi", "SI")
            Else
                myCommand.Parameters.AddWithValue("?concomi", "NO")
            End If
            If cheditar.Checked = True Then
                myCommand.Parameters.AddWithValue("?mod", "SI")
            Else
                myCommand.Parameters.AddWithValue("?mod", "NO")
            End If

            myCommand.CommandText = "Update car_par set par_fac1=?par_fac1,par_fac2=?par_fac2, par_fac3=?par_fac3, par_fac4=?par_fac4, par_aju=?par_aju, par_rc=?par_rc, par_ci=?par_ci,par_int=?par_int, par_cta_caja=?par_cta_caja," _
                                  & " par_cta_ban=?par_cta_ban,par_cta_ret=?par_cta_ret,par_cta_des=?par_cta_des,par_cta_iva=?par_cta_iva,par_cta_ven=?par_cta_ven,par_cta_cco=?par_cta_cco,par_blq_cup=?par_blq_cup,par_dia_ven=?par_dia_ven,par_blq_mor=?par_blq_mor,par_blq_exc=?par_blq_exc,par_rcb_apr=?par_rcb_apr,par_nro_rec=?par_nro_rec,par_pag_com=?par_pag_com,par_com_var=?par_com_var,par_env_cor=?par_env_cor," _
                                  & " hay_int=?hay_int,mon_int=?mon_int,tip_int=?tip_int,cta_mor=?cta_mor,concomi=?concomi,editarcc=?mod;"
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                Cerrar()
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            'myCommand.CommandText = "delete from listasprec where numlist >" & gitems.RowCount & ";"
            'myCommand.ExecuteNonQuery()
            'For i = 0 To gitems.RowCount - 1
            '    GuardarListasDePrecios(gitems.Item(0, i).Value, gitems.Item(1, i).Value)
            'Next
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lb.Text = ""
            Me.Close()
        End If
    End Sub


    Private Sub rbcont2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont2.CheckedChanged
        txtcaja.Enabled = False
        txtbanco.Enabled = False
        txtctapc.Enabled = False
        txtretencion.Enabled = False
        txtventas.Enabled = False
        txtivapp.Enabled = False
        txtdescuento.Enabled = False
        txtmora.Enabled = False
    End Sub
    '//////////DOCUMENTOS/////////
    Public Sub TiposDeDocumentos(ByVal cad As String)
        frmseltipodoccar.lbtipo.Text = cad
        frmseltipodoccar.ShowDialog()
    End Sub

    '////////////CUENTAS//////////////
    Private Sub txtcaja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.DoubleClick
        FrmCuentas.lbform.Text = "caja_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaja.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtbanco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanco.DoubleClick
        FrmCuentas.lbform.Text = "banco_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtctapc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapc.DoubleClick
        FrmCuentas.lbform.Text = "ctapc_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtctapc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctapc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    
    Private Sub txtventas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtventas.DoubleClick
        FrmCuentas.lbform.Text = "ventas_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtventas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtventas.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
   
    Private Sub txtivapp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivapp.DoubleClick
        FrmCuentas.lbform.Text = "ivapp_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtivapp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivapp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    
    Private Sub txtdescuento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuento.DoubleClick
        FrmCuentas.lbform.Text = "descuento_car"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtdescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtretfuente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        
    End Sub
    Private Sub txtretfuente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    
    End Sub
    
    Private Sub rbcont1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont1.CheckedChanged
        txtcaja.Enabled = True
        txtbanco.Enabled = True
        txtctapc.Enabled = True
        txtretencion.Enabled = True
        txtventas.Enabled = True
        txtivapp.Enabled = True
        txtdescuento.Enabled = True
        txtmora.Enabled = True
    End Sub


    Private Sub txttipo1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo1.DoubleClick
        TiposDeDocumentos("1")
    End Sub


    Private Sub txttipo2_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo2.DoubleClick
        TiposDeDocumentos("2")
    End Sub

    Private Sub txttipo3_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo3.DoubleClick
        TiposDeDocumentos("3")
    End Sub

    Private Sub txttipo4_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo4.DoubleClick
        TiposDeDocumentos("4")
    End Sub

    Private Sub txtajust_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtajust.DoubleClick
        TiposDeDocumentos("A")
    End Sub

    Private Sub txtrc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrc.DoubleClick
        TiposDeDocumentos("B")
    End Sub

    Private Sub txtrcc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrcc.DoubleClick
        TiposDeDocumentos("C")
    End Sub

    Private Sub txtretencion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretencion.DoubleClick
        FrmCuentas.lbform.Text = "retencion_car"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtretencion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtretencion.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtmora_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmora.DoubleClick
        FrmCuentas.lbform.Text = "mora_car"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtmora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmora.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbint.SelectedIndexChanged
        If cbint.Text = "SI" Then
            txtmonto.Enabled = True
            cbtipoint.Enabled = True
        Else
            txtmonto.Enabled = False
            cbtipoint.Enabled = False
        End If
    End Sub

    Private Sub txtmonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto.LostFocus
        If txtmonto.Text <> "" Then
            txtmonto.Text = Moneda(txtmonto.Text)
        Else
            txtmonto.Text = Moneda(0)
        End If
    End Sub

    Private Sub frmparametroscartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub rbcc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc2.CheckedChanged
        If rbcc2.Checked = True Then
            cheditar.Checked = False
            cheditar.Enabled = False
        Else
            cheditar.Checked = False
            cheditar.Enabled = True
        End If
    End Sub
End Class