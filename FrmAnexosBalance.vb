Public Class FrmAnexosBalance

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        MsgBox("No se pudo generar el Reporte...   ", MsgBoxStyle.Information, "SAE Control")
    End Sub
End Class