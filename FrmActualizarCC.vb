Public Class FrmActualizarCC
    Private Sub FrmActualizarCC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        p1.Checked = True
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub cmdperiodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperiodo.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
        BuscarPeriodo()
        lbper.Text = PerActual
    End Sub
    Private Sub p1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1.CheckedChanged
        txtmes.Enabled = False
        txtmes2.Enabled = False
    End Sub
    Private Sub p2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p2.CheckedChanged
        txtmes.Enabled = True
        txtmes2.Enabled = True
        txtmes.Text = PerActual(0) & PerActual(1)
        txtmes2.Text = PerActual(0) & PerActual(1)
        txtmes.Focus()
    End Sub
    Private Sub p3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p3.CheckedChanged
        txtmes.Enabled = False
        txtmes2.Enabled = False
    End Sub
    Private Sub txtmes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmes.KeyPress
        validarnumero(txtmes, e)
    End Sub
    Private Sub txtmes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmes.TextChanged
        If Val(txtmes.Text) < 1 Or Val(txtmes.Text) > 12 Then
            MsgBox("El mes debe estar en el rango 01-12, Verifique ", MsgBoxStyle.Critical, "SAE Verificación")
            txtmes.Text = PerActual(0) & PerActual(1)
        End If
    End Sub
    Private Sub txtmes2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmes2.KeyPress
        validarnumero(txtmes2, e)
    End Sub
    Private Sub txtmes2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmes2.TextChanged
        If Val(txtmes2.Text) < 1 Or Val(txtmes2.Text) > 12 Then
            MsgBox("El mes debe estar en el rango 01-12, Verifique ", MsgBoxStyle.Critical, "SAE Verificación")
            txtmes2.Text = PerActual(0) & PerActual(1)
        End If
    End Sub
End Class