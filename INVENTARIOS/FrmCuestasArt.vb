Public Class FrmCuestasArt

    Private Sub txtcinv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcinv.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_inv"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcing_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcing.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_ing"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtccos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtccos.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_cos"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcivag_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcivag.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_ivag"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcivad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcivad.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_ivad"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcdev_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcdev.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fca_dev"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        FrmProductos.lbinv.Text = txtcinv.Text
        FrmProductos.lbing.Text = txtcing.Text
        FrmProductos.lbcos.Text = txtccos.Text
        FrmProductos.lbivag.Text = txtcivag.Text
        FrmProductos.lbivad.Text = txtcivad.Text
        FrmProductos.lbdev.Text = txtcdev.Text
        Me.Close()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtcinv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcinv.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtcinv.Text, "inv")
        Else
            validarnumero(txtcinv, e)
        End If
    End Sub
    Private Sub txtcing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcing.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtcing.Text, "ing")
        Else
            validarnumero(txtcing, e)
        End If
    End Sub
    Private Sub txtccos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtccos.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtccos.Text, "cos")
        Else
            validarnumero(txtccos, e)
        End If
    End Sub
    Private Sub txtcivag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcivag.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtcivag.Text, "ivag")
        Else
            validarnumero(txtcivag, e)
        End If
    End Sub
    Private Sub txtcivad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcivad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtcivad.Text, "ivad")
        Else
            validarnumero(txtcivad, e)
        End If
    End Sub
    Private Sub txtcdev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcdev.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtcdev.Text, "dev")
        Else
            validarnumero(txtcdev, e)
        End If
    End Sub
    Public Sub BuscarCuenta(ByVal codigo As String, ByVal cta As String)
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            Select Case cta
                Case "inv"
                    FrmCuentas.lbform.Text = "fca_inv"
                    txtcinv.Text = ""
                    txtninv.Text = ""
                Case "ing"
                    FrmCuentas.lbform.Text = "fca_ing"
                    txtcing.Text = ""
                    txtning.Text = ""
                Case "cos"
                    FrmCuentas.lbform.Text = "fca_cos"
                    txtccos.Text = ""
                    txtncos.Text = ""
                Case "ivag"
                    FrmCuentas.lbform.Text = "fca_ivag"
                    txtcivag.Text = ""
                    txtnivag.Text = ""
                Case "ivad"
                    FrmCuentas.lbform.Text = "fca_ivad"
                    txtcivad.Text = ""
                    txtnivad.Text = ""
                Case "dev"
                    FrmCuentas.lbform.Text = "fca_dev"
                    txtcdev.Text = ""
                    txtndev.Text = ""
            End Select
            Try
                FrmCuentas.txtcuenta.Text = codigo
                FrmCuentas.lbaux.Text = "auxiliar"
                FrmCuentas.ShowDialog()
            Catch ex As Exception
            End Try
            
        Else
            Select Case cta
                Case "inv"
                    txtninv.Text = tabla.Rows(0).Item("descripcion")
                Case "ing"
                    txtning.Text = tabla.Rows(0).Item("descripcion")
                Case "cos"
                    txtncos.Text = tabla.Rows(0).Item("descripcion")
                Case "ivag"
                    txtnivag.Text = tabla.Rows(0).Item("descripcion")
                Case "ivad"
                    txtnivad.Text = tabla.Rows(0).Item("descripcion")
                Case "dev"
                    txtndev.Text = tabla.Rows(0).Item("descripcion")
            End Select
        End If
    End Sub

    Private Sub txtcinv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcinv.LostFocus
        BuscarCuenta(txtcinv.Text, "inv")
    End Sub
    Private Sub txtcing_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcing.LostFocus
        BuscarCuenta(txtcing.Text, "ing")
    End Sub
    Private Sub txtccos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtccos.LostFocus
        BuscarCuenta(txtccos.Text, "cos")
    End Sub
    Private Sub txtcivag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcivag.LostFocus
        BuscarCuenta(txtcivag.Text, "ivag")
    End Sub
    Private Sub txtcivad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcivad.LostFocus
        BuscarCuenta(txtcivad.Text, "ivad")
    End Sub
    Private Sub txtcdev_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcdev.LostFocus
        BuscarCuenta(txtcdev.Text, "dev")
    End Sub

End Class