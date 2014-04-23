Public Class FrmParOtrosDoc

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Dim tipo As String = ""

    Private Sub FrmParOtrosDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        '----------------- llenar txt OtrosDoc
        Dim t3 As New DataTable
        myCommand.CommandText = "SELECT * FROM aud_otdoc ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        If t3.Rows.Count > 0 Then
            txtcaja.Text = t3.Rows(0).Item(1)
            txtbanco.Text = t3.Rows(0).Item(2)
            txtctapc.Text = t3.Rows(0).Item(3)
            txtctapp.Text = t3.Rows(0).Item(4)
        End If
        '......................................

    End Sub

    Public Sub Guard_parODoc()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros para auditar las transacciones de Otros documentos se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM aud_otdoc ;"
            myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?tpuc", tipo)
            myCommand.Parameters.AddWithValue("?c1", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?c2", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?c3", txtctapc.Text.ToString)
            myCommand.Parameters.AddWithValue("?c4", txtctapp.Text.ToString)

            myCommand.CommandText = "INSERT INTO aud_otdoc VALUES(?tpuc,?c1,?c2, ?c3, ?c4 );"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
        End If
    End Sub

    Private Sub txtcaja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_od_caj"
            FrmCuentas.txtcuenta.Text = txtcaja.Text
            FrmCuentas.lbaux.Text = "todas"
            txtcaja.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaja.KeyPress
        validarnumero(txtcaja, e)
    End Sub
    'Private Sub txtcaja_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.LostFocus

    '    If txtcaja.Text <> "" Then Exit Sub
    '    If FrmParFac.buscarCuenta(txtcaja.Text) = True Then
    '        Try
    '            txtcaja_DoubleClick(AcceptButton, AcceptButton)

    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtbanco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanco.DoubleClick

        'Dim f As Integer = 0
        'f = Val(lbfila.Text)

        Try
            FrmCuentas.lbform.Text = "Aud_od_ban"
            FrmCuentas.txtcuenta.Text = txtbanco.Text
            FrmCuentas.lbaux.Text = "todas"
            txtbanco.Text = ""
            FrmCuentas.ShowDialog()
            'txtbanco.Text = FrmCuentas.gcuenta.Item(1, f).Value
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
    '            'txtbanco.Focus()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtctapc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapc.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_od_cxc"
            FrmCuentas.txtcuenta.Text = txtctapc.Text
            FrmCuentas.lbaux.Text = "todas"
            txtctapc.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtctapc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctapc.KeyPress
        validarnumero(txtctapc, e)
    End Sub
    'Private Sub txtctapc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapc.LostFocus
    '    If FrmParFac.buscarCuenta(txtctapc.Text) = True Then
    '        Try
    '            txtctapc_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub txtctapp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapp.DoubleClick
        Try
            FrmCuentas.lbform.Text = "Aud_od_cxp"
            FrmCuentas.txtcuenta.Text = txtctapp.Text
            FrmCuentas.lbaux.Text = "todas"
            txtctapp.Text = ""
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtctapp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctapp.KeyPress
        validarnumero(txtctapp, e)
    End Sub
    'Private Sub txtctapp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapp.LostFocus
    '    If FrmParFac.buscarCuenta(txtctapp.Text) = True Then
    '        Try
    '            txtctapp_DoubleClick(AcceptButton, AcceptButton)
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub cmdparfac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparfac.Click
        Guard_parODoc()
    End Sub


End Class