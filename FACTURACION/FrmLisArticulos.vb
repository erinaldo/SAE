

Public Class FrmLisArticulos

    Dim fil, j, i As Integer

    Private Sub FrmLisProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim t1 As String
        t1 = bda & ".articulos"
        myCommand.CommandText = "SELECT " & t1 & ".codart," & t1 & ".nomart," & t1 & ".nivel FROM " & t1 & " ORDER BY " & t1 & ".codart," & t1 & ".nomart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' gitems.DataSource = tabla
        gitems.RowCount = tabla.Rows.Count + 1
        j = 0
        For i As Integer = 0 To tabla.Rows.Count - 1
            If Len(tabla.Rows(i).Item("codart").ToString) <> 2 Then
                gitems.Item(0, j).Value = tabla.Rows(i).Item("codart")
                gitems.Item(1, j).Value = tabla.Rows(i).Item("nomart")
                gitems.Item(2, j).Value = tabla.Rows(i).Item("nivel")
                j = j + 1
            End If
        Next
        gitems.RowCount = tabla.Rows.Count - (i - j)
        fil = 0
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Try
             Select lbform.Text
                Case "Info_Art"
                    FrmInfoArticulos.txttip.Text = gitems.Item(0, e.RowIndex).Value
                    FrmInfoArticulos.txtnom.Text = gitems.Item(1, e.RowIndex).Value
                    Me.Close()
                Case "Cam_Art"
                    If gitems.Item(2, e.RowIndex).Value = "Articulo" Then
                        FrmCamCodart.txttip.Text = gitems.Item(0, e.RowIndex).Value
                        FrmCamCodart.txtnom.Text = gitems.Item(1, e.RowIndex).Value
                        Me.Close()
                    End If
            End Select

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click

        Select lbform.Text
            Case "Info_Art"
                FrmInfoArticulos.txttip.Text = gitems.Item(0, fil).Value
                FrmInfoArticulos.txtnom.Text = gitems.Item(1, fil).Value
                Me.Close()
            Case "Cam_Art"
                If gitems.Item(2, fil).Value = "Articulo" Then
                    FrmCamCodart.txttip.Text = gitems.Item(0, fil).Value
                    FrmCamCodart.txtnom.Text = gitems.Item(1, fil).Value
                    Me.Close()
                End If
        End Select

    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then

            FrmInfoClientes.txttip.Text = gitems.Item(0, fil - 1).Value
            FrmInfoClientes.txtnom.Text = gitems.Item(1, fil - 1).Value & " " & gitems.Item(2, fil - 1).Value
            Me.Close()
        End If
    End Sub

End Class