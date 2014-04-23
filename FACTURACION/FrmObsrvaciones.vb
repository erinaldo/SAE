Public Class FrmObsrvaciones

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        Select Case lbform.Text
            Case "fr"
                Frmfacturarapida.txtobserbaciones.Text = txtobservacion.Text
            Case "frs"
                FrmFacturaEstetica.txtobserbaciones.Text = txtobservacion.Text
            Case "fn"
                FrmFacturasyAjustes.txtobserbaciones.Text = txtobservacion.Text
            Case "fn_sp"
                FrmFacturasyAjustesSP.txtobserbaciones.Text = txtobservacion.Text
            Case "fdp"
                FrmDocProveedor.txtobserbaciones.Text = txtobservacion.Text
            Case ""
        End Select
        Me.Close()
    End Sub
End Class