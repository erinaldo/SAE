Public Class FrmLisClientes

    Dim fil As Integer

    Private Sub FrmLisClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim t1 As String
        t1 = bda & ".terceros"
        myCommand.CommandText = "SELECT " & t1 & ".nit as NIT," & t1 & ".apellidos AS APELLIDOS," & t1 & ".nombre AS NOMBRES FROM " & t1 & " ORDER BY " & t1 & ".apellidos," & t1 & ".nombre;"

        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' gitems.DataSource = tabla
        gitems.RowCount = tabla.Rows.Count + 1
        For i As Integer = 0 To tabla.Rows.Count - 1
            gitems.Item(0, i).Value = tabla.Rows(i).Item(0)
            gitems.Item(1, i).Value = tabla.Rows(i).Item(1)
            gitems.Item(2, i).Value = tabla.Rows(i).Item(2)
        Next
        gitems.Columns(1).Width = 160
        gitems.Columns(2).Width = 120
        fil = 0
    End Sub

    Private Sub gitems_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentDoubleClick
        Select Case lbform.Text
            Case "cliente"
                FrmInfoClientes.txttip.Text = gitems.Item(0, e.RowIndex).Value
                FrmInfoClientes.txtnom.Text = gitems.Item(1, e.RowIndex).Value & " " & gitems.Item(2, e.RowIndex).Value
                Me.Close()
            Case "cotiz"
                FrmInfoCotz.txttip.Text = gitems.Item(0, e.RowIndex).Value
                FrmInfoCotz.txtnom.Text = gitems.Item(1, e.RowIndex).Value & " " & gitems.Item(2, e.RowIndex).Value
                Me.Close()
        End Select
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Select Case lbform.Text
            Case "cliente"
                FrmInfoClientes.txttip.Text = gitems.Item(0, fil).Value
                FrmInfoClientes.txtnom.Text = gitems.Item(1, fil).Value & " " & gitems.Item(2, fil).Value
                Me.Close()
            Case "cotiz"
                FrmInfoCotz.txttip.Text = gitems.Item(0, fil).Value
                FrmInfoCotz.txtnom.Text = gitems.Item(1, fil).Value & " " & gitems.Item(2, fil).Value
                Me.Close()
        End Select
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub

    Private Sub gitems_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellMouseLeave

    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Select Case lbform.Text
                Case "cliente"
                    FrmInfoClientes.txttip.Text = gitems.Item(0, fil - 1).Value
                    FrmInfoClientes.txtnom.Text = gitems.Item(1, fil - 1).Value & " " & gitems.Item(2, fil - 1).Value
                    Me.Close()
                Case "cotiz"
                    FrmInfoCotz.txttip.Text = gitems.Item(0, fil - 1).Value
                    FrmInfoCotz.txtnom.Text = gitems.Item(1, fil - 1).Value & " " & gitems.Item(2, fil - 1).Value
                    Me.Close()
            End Select
        End If
    End Sub
End Class