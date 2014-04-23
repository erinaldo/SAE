Public Class FrmProve_Art

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        FrmProductos.lbp1.Text = txt1.Text
        FrmProductos.lbp2.Text = txt2.Text
        FrmProductos.lbp3.Text = txt3.Text
        FrmProductos.lbp4.Text = txt4.Text
        FrmProductos.lbp5.Text = txt5.Text
        Me.Close()
    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txt1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1.DoubleClick
        FrmSelCliente.lbform.Text = "inv_p1"
        FrmSelCliente.ShowDialog()
    End Sub
    Private Sub txt2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.DoubleClick
        FrmSelCliente.lbform.Text = "inv_p2"
        FrmSelCliente.ShowDialog()
    End Sub
    Private Sub txt3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt3.DoubleClick
        FrmSelCliente.lbform.Text = "inv_p3"
        FrmSelCliente.ShowDialog()
    End Sub
    Private Sub txt4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt4.DoubleClick
        FrmSelCliente.lbform.Text = "inv_p4"
        FrmSelCliente.ShowDialog()
    End Sub
    Private Sub txt5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt5.DoubleClick
        FrmSelCliente.lbform.Text = "inv_p5"
        FrmSelCliente.ShowDialog()
    End Sub
End Class