Public Class FrmSelRemiProv

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If rbEnt.Checked = True Then
            FrmSelMovInventario.lbform.Text = "FacturaC"
            FrmSelMovInventario.ShowDialog()
        Else

            FrmSelOrdenesCompras.lbremis.Text = " WHERE cumplido='no' "
            FrmSelOrdenesCompras.lbform.Text = "FacturaC"
            FrmSelOrdenesCompras.ShowDialog()
        End If
        Me.Close()
    End Sub
End Class