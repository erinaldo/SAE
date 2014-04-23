Public Class FrmDatosDeEntrega
    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        Select Case lbform.Text
            Case "fn"
                FrmFacturasyAjustes.lbentrega.Text = txtentrega.Text
                FrmFacturasyAjustes.lbdir.Text = txtdir.Text
                FrmFacturasyAjustes.lbciudad.Text = txtciudad.Text
                FrmFacturasyAjustes.lborden.Text = txtorden.Text
                FrmFacturasyAjustes.lbfecha.Text = txtfecha.Value
            Case "fn_sp"
                FrmFacturasyAjustesSP.lbentrega.Text = txtentrega.Text
                FrmFacturasyAjustesSP.lbdir.Text = txtdir.Text
                FrmFacturasyAjustesSP.lbciudad.Text = txtciudad.Text
                FrmFacturasyAjustesSP.lborden.Text = txtorden.Text
                FrmFacturasyAjustesSP.lbfecha.Text = txtfecha.Value
            Case "fp"
        End Select
        Me.Close()
    End Sub
End Class