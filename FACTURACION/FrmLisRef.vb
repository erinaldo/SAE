Public Class FrmLisRef

    Dim fil, j, i As Integer

    Private Sub FrmLisRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim t1 As String
        t1 = bda & ".articulos"
        myCommand.CommandText = "SELECT " & t1 & ".codart," & t1 & ".nomart FROM " & t1 & " ORDER BY " & t1 & ".codart," & t1 & ".nomart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' gitems.DataSource = tabla
        gitems.RowCount = tabla.Rows.Count + 1
        j = 0
        For i As Integer = 0 To tabla.Rows.Count - 1
            If Len(tabla.Rows(i).Item("codart").ToString) <> 1 Then
                gitems.Item(0, j).Value = tabla.Rows(i).Item("codart")
                gitems.Item(1, j).Value = tabla.Rows(i).Item("nomart")
                j = j + 1
            End If
        Next
        gitems.RowCount = tabla.Rows.Count - (i - j)
        fil = 0
    End Sub

    Private Sub gitems_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentDoubleClick
        Try
            If FrmInfoReferencia.ct = 1 Then
                FrmInfoReferencia.txtdocini.Text = gitems.Item(0, e.RowIndex).Value
                Me.Close()
            End If

            If FrmInfoReferencia.ct = 2 Then
                FrmInfoReferencia.txtdocfin.Text = gitems.Item(0, e.RowIndex).Value
                Me.Close()
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            If FrmInfoReferencia.ct = 1 Then
                FrmInfoReferencia.txtdocini.Text = gitems.Item(0, fil).Value
                Me.Close()
            End If

            If FrmInfoReferencia.ct = 2 Then
                FrmInfoReferencia.txtdocfin.Text = gitems.Item(0, fil).Value
                Me.Close()
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Try
                If FrmInfoReferencia.ct = 1 Then
                    FrmInfoReferencia.txtdocini.Text = gitems.Item(0, fil - 1).Value
                    Me.Close()
                End If

                If FrmInfoReferencia.ct = 2 Then
                    FrmInfoReferencia.txtdocfin.Text = gitems.Item(0, fil - 1).Value
                    Me.Close()
                End If

                Me.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class