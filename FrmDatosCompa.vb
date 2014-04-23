Public Class FrmDatosCompa

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Me.Close()
    End Sub

    Private Sub FrmDatosCompa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        lbcompa.Text = tabla.Rows(0).Item("codigo").ToString
        txtcompania.Text = tabla.Rows(0).Item("descripcion").ToString
        txtnit.Text = tabla.Rows(0).Item("nit").ToString
        txtrlegal.Text = tabla.Rows(0).Item("rlegal").ToString
        txtdir.Text = tabla.Rows(0).Item("direccion").ToString
        txttel1.Text = tabla.Rows(0).Item("telefono1").ToString
        txttel2.Text = tabla.Rows(0).Item("telefono2").ToString
        txtfax.Text = tabla.Rows(0).Item("fax").ToString
        txtlogin.Text = tabla.Rows(0).Item("login").ToString
        txtconta.Text = tabla.Rows(0).Item("contador").ToString
        txttelcont.Text = tabla.Rows(0).Item("telconta").ToString
        txtemailcont.Text = tabla.Rows(0).Item("emailconta").ToString
        txtperiodo.Text = FrmPrincipal.LbPeriodo.Text
    End Sub
End Class