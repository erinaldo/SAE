Public Class FrmParFac

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Dim tipo As String = ""
    Private Sub FrmParFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        myCommand.CommandText = "SELECT * FROM audi_parfac ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        If t3.Rows.Count > 0 Then
            txtcajaF.Text = t3.Rows(0).Item(1)
            txtbancoF.Text = t3.Rows(0).Item(2)
            txtctapcF.Text = t3.Rows(0).Item(3)
            txtinventarioF.Text = t3.Rows(0).Item(4)
            txtventasF.Text = t3.Rows(0).Item(5)
            txtcostoF.Text = t3.Rows(0).Item(6)
            txtivappF.Text = t3.Rows(0).Item(7)
            txtivadF.Text = t3.Rows(0).Item(8)
            txtdescuentoF.Text = t3.Rows(0).Item(9)
            txtretfuenteF.Text = t3.Rows(0).Item(10)
            txtreteicaF.Text = t3.Rows(0).Item(11)
            txtreteivaF.Text = t3.Rows(0).Item(12)
        End If
        '......................................
    End Sub

    Private Sub cmdparfac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparfac.Click

        'If txtcajaF.Text = "" Then
        '    MsgBox("Digite la cuenta Caja", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtbancoF.Text = "" Then
        '    MsgBox("Digite la cuenta Bancos", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtctapcF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtinventarioF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtventasF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtcostoF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtivappF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtivadF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtdescuentoF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtretfuenteF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtreteicaF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'ElseIf txtreteivaF.Text = "" Then
        '    MsgBox("Digite todas Las cuentas", MsgBoxStyle.Information, "SAE Verificacion")
        '    Exit Sub
        'End If

        Guard_parfac()
    End Sub
    Public Sub Guard_parfac()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros para auditar las transacciones de facturacion se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM audi_parfac ;"
            myCommand.ExecuteNonQuery()


            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?tpuc", tipo)
            myCommand.Parameters.AddWithValue("?c1", txtcajaF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c2", txtbancoF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c3", txtctapcF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c4", txtinventarioF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c5", txtventasF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c6", txtcostoF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c7", txtivappF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c8", txtivadF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c9", txtdescuentoF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c10", txtretfuenteF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c11", txtreteicaF.Text.ToString)
            myCommand.Parameters.AddWithValue("?c12", txtreteivaF.Text.ToString)

            myCommand.CommandText = "INSERT INTO audi_parfac VALUES(?tpuc,?c1,?c2, ?c3, ?c4,?c5,?c6,?c7,?c8,?c9,?c10,?c11,?c12 );"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
        End If
    End Sub
    Private Sub txtbancoF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbancoF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_ban"
            FrmCuentas.txtcuenta.Text = txtbancoF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtbancoF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtbancoF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbancoF.KeyPress
        validarnumero(txtbancoF, e)
    End Sub
    'Private Sub txtbancoF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbancoF.LostFocus
    '    If buscarCuenta(txtbancoF.Text) = True Then
    '        Try
    '            txtbancoF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtcajaF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcajaF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_caj"
            FrmCuentas.txtcuenta.Text = txtcajaF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcajaF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcajaF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcajaF.KeyPress
        validarnumero(txtcajaF, e)
    End Sub
    'Private Sub txtcajaF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcajaF.LostFocus
    '    If buscarCuenta(txtcajaF.Text) = True Then
    '        Try
    '            txtcajaF.Text = ""
    '            FrmCuentas.lbform.Text = "Aud_fac_caj"
    '            FrmCuentas.lbaux.Text = "todas"
    '            FrmCuentas.ShowDialog()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtcostoF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcostoF.DoubleClick
        Try

            FrmCuentas.lbform.Text = "Aud_fac_cos"
            FrmCuentas.txtcuenta.Text = txtcostoF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcostoF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcostoF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcostoF.KeyPress
        validarnumero(txtcostoF, e)
    End Sub

    'Private Sub txtcostoF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcostoF.LostFocus
    '    If buscarCuenta(txtcostoF.Text) = True Then
    '        Try
    '            txtcostoF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtctapcF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapcF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_cpc"
            FrmCuentas.txtcuenta.Text = txtctapcF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtctapcF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtctapcF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctapcF.KeyPress
        validarnumero(txtctapcF, e)
    End Sub
    'Private Sub txtctapcF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapcF.LostFocus
    '    If buscarCuenta(txtctapcF.Text) = True Then
    '        Try
    '            txtctapcF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtdescuentoF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuentoF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_des"
            FrmCuentas.txtcuenta.Text = txtdescuentoF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtdescuentoF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtdescuentoF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuentoF.KeyPress
        validarnumero(txtdescuentoF, e)
    End Sub
    'Private Sub txtdescuentoF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuentoF.LostFocus
    '    If buscarCuenta(txtdescuentoF.Text) = True Then
    '        Try
    '            txtdescuentoF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtinventarioF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinventarioF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_inv"
            FrmCuentas.txtcuenta.Text = txtinventarioF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtinventarioF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtinventarioF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinventarioF.KeyPress
        validarnumero(txtinventarioF, e)
    End Sub
    'Private Sub txtinventarioF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinventarioF.LostFocus
    '    If buscarCuenta(txtinventarioF.Text) = True Then
    '        Try
    '            txtinventarioF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtivadF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivadF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_ivad"
            FrmCuentas.txtcuenta.Text = txtivadF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtivadF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtivadF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivadF.KeyPress
        validarnumero(txtivadF, e)
    End Sub
    'Private Sub txtivadF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivadF.LostFocus
    '    If buscarCuenta(txtivadF.Text) = True Then
    '        Try
    '            txtivadF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtivappF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivappF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_ivap"
            FrmCuentas.txtcuenta.Text = txtivappF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtivappF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtivappF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivappF.KeyPress
        validarnumero(txtivappF, e)
    End Sub
    'Private Sub txtivappF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivappF.LostFocus
    '    If buscarCuenta(txtivappF.Text) = True Then
    '        Try
    '            txtivappF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtreteicaF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteicaF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_rti"
            FrmCuentas.txtcuenta.Text = txtreteicaF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtreteicaF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtreteicaF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreteicaF.KeyPress
        validarnumero(txtreteicaF, e)
    End Sub
    'Private Sub txtreteicaF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteicaF.LostFocus
    '    If buscarCuenta(txtreteicaF.Text) = True Then
    '        Try
    '            txtreteicaF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtreteivaF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteivaF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_rtiv"
            FrmCuentas.txtcuenta.Text = txtreteivaF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtreteivaF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtreteivaF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreteivaF.KeyPress
        validarnumero(txtreteivaF, e)
    End Sub
    'Private Sub txtreteivaF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteivaF.LostFocus
    '    If buscarCuenta(txtreteivaF.Text) = True Then
    '        Try
    '            txtreteivaF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtretfuenteF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretfuenteF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_rtf"
            FrmCuentas.txtcuenta.Text = txtretfuenteF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtretfuenteF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtretfuenteF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtretfuenteF.KeyPress
        validarnumero(txtretfuenteF, e)
    End Sub
    'Private Sub txtretfuenteF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretfuenteF.LostFocus
    '    If buscarCuenta(txtretfuenteF.Text) = True Then
    '        Try
    '            txtretfuenteF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtventasF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtventasF.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_fac_ven"
            FrmCuentas.txtcuenta.Text = txtventasF.Text
            FrmCuentas.lbaux.Text = "todas"
            txtventasF.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtventasF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtventasF.KeyPress
        validarnumero(txtventasF, e)
    End Sub
    'Private Sub txtventasF_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtventasF.LostFocus
    '    If buscarCuenta(txtventasF.Text) = True Then
    '        Try
    '            txtventasF_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Public Function buscarCuenta(ByVal cuenta As String)

        Dim tabc As New DataTable
        myCommand.CommandText = "SELECT codigo FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabc)

        If tabc.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function


End Class