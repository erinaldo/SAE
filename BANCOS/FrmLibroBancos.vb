Public Class FrmLibroBancos

    Private Sub FrmLibroBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpini.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        txtpfin.Text = "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        cbini.Text = PerActual(0) & PerActual(1)
    End Sub
    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        cbfin.Items.Clear()
        Dim j As Integer = Val(cbini.Text)
        For i = j To 12
            If i < 10 Then
                cbfin.Items.Add("0" & i)
            Else
                cbfin.Items.Add(i)
            End If
        Next
        cbfin.Text = cbini.Text
    End Sub

    Private Sub c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        If c3.Checked = True Then
            txtcuenta.Enabled = True
        End If
    End Sub
End Class