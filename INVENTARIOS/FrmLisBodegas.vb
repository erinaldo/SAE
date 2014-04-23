
Public Class FrmLisBodegas

    Public fil, j, i, nbod, c As Integer

    Private Sub FrmLisBodegas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabla As New DataTable
        Dim t1 As String
        t1 = bda & ".bodegas"
        nbod = 0
        myCommand.CommandText = "SELECT " & t1 & ".numbod FROM " & t1 & " ORDER BY " & t1 & ".numbod;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' gitems.DataSource = tabla
        nbod = tabla.Rows.Count
        gitems.RowCount = tabla.Rows.Count + 1
        j = 0
        For i As Integer = 0 To tabla.Rows.Count - 1
            gitems.Item(0, j).Value = tabla.Rows(i).Item("numbod")
            j = j + 1
        Next
        gitems.RowCount = tabla.Rows.Count - (i - j)
        fil = 0
        cbobod.Items.Clear()
        cbobod.Items.Add("NO")
        cbobod.Items.Add("SI")
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        c = 0
        For k As Integer = 0 To nbod
            If c > 5 Then
                Me.Close()
                Exit Sub
            End If
            If gitems.Item(1, k).Value = "SI" Then
                If ct = 10 Then
                    FrmInfartalf.vec(c) = gitems.Item(0, k).Value
                End If

                If ct = 20 Then
                    FrmInfoRef.vec(c) = gitems.Item(0, k).Value
                End If
                c = c + 1
            End If

        Next
        ct = 0
        Me.Close()
    End Sub
End Class