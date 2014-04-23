Public Class FrmVerUsuarios
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
        If gitems.Item(1, fila).Value = "" Then Exit Sub
        FrmUsuarios.txtnombres.Text = gitems.Item(3, fila).Value
        FrmUsuarios.txtapellidos.Text = gitems.Item(2, fila).Value
        FrmUsuarios.txtuser.Text = gitems.Item(1, fila).Value
        FrmUsuarios.cbrol.Text = gitems.Item(4, fila).Value
        FrmUsuarios.cbestado.Text = gitems.Item(5, fila).Value
        FrmUsuarios.lbestado.Text = "CONSULTA"
        FrmUsuarios.lbnroobs.Text = fila + 1
        FrmUsuarios.lbuser.Visible = False
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 2
            aux = gitems.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 1, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    cmditems_Click(AcceptButton, AcceptButton)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub FrmVerUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
End Class