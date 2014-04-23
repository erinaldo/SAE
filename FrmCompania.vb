Public Class FrmCompania
    Public fil As Integer
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Seleccionar(e.RowIndex)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Seleccionar(fil - 1)
        End If
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Seleccionar(fil)
    End Sub
    Public Sub Seleccionar(ByVal fila As Integer)
        If gitems.Item(0, fila).Value = "" Then Exit Sub
        FrmGestionCompa.lbcompa.Text = gitems.Item(3, fila).Value
        FrmGestionCompa.txtcompania.Text = gitems.Item(1, fila).Value
        FrmGestionCompa.txtlogin.Text = gitems.Item(0, fila).Value
        FrmGestionCompa.txtnit.Text = gitems.Item(2, fila).Value
        FrmGestionCompa.lbestado.Text = "CONSULTA"
        FrmGestionCompa.lbnroobs.Text = fila + 1
        FrmUsuarios.lbuser.Visible = False
        Me.Close()
    End Sub
End Class