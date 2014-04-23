Public Class FrmConciliaciones

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(txtcuenta.Text) = "" Then
            MsgBox("Favor seleccione un banco... ", MsgBoxStyle.Information)
        Else

        End If
    End Sub

    Private Sub cmdActCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActCuenta.Click

    End Sub
End Class