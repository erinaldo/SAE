Public Class FrmPreciosServicios
    Private Sub FrmPreciosServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM listasprec ORDER BY numlist;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            gitems.RowCount = items
            For i = 0 To items - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item("numlist")
                gitems.Item(1, i).Value = tabla.Rows(i).Item("nomlist")
                If i = 0 Then
                    gitems.Item(2, i).Value = ListasPrec("pventa")
                Else
                    gitems.Item(2, i).Value = ListasPrec("pventa" & (i + 1))
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function ListasPrec(ByVal precio As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT " & precio & " FROM servicios WHERE codser='" & lbcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                Return "0,00"
            Else
                Return Moneda(tabla.Rows(0).Item(0))
            End If
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function
    '********************************************************************
    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        ActualizarListaPrecios()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '********************************************************
    Public Sub ActualizarListaPrecios()
        MiConexion(bda)
        For i = 0 To gitems.Rows.Count - 1
            If gitems.Item(1, i).Value <> "" Then
                If i = 0 Then
                    ejecutaSQL("UPDATE servicios SET pventa=" & DIN(gitems.Item(2, i).Value) & " WHERE codser='" & lbcodigo.Text & "';")
                    FrmServicios.txtprecio.Text = Moneda(gitems.Item(2, i).Value)
                Else
                    ejecutaSQL("UPDATE servicios SET pventa" & (i + 1) & "=" & DIN(gitems.Item(2, i).Value) & " WHERE codser='" & lbcodigo.Text & "';")
                End If
            End If
        Next
        Cerrar()
        MsgBox("La lista de precios fué actualizada correctamente. ", MsgBoxStyle.Information, "SAE Acualizar Listas")
        Me.Close()
    End Sub
    Public Sub ejecutaSQL(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(sql & " //////// " & ex.ToString)
        End Try
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Select Case e.ColumnIndex
            Case "2"
                Try
                    gitems.Item(2, e.RowIndex).Value = Moneda(gitems.Item(2, e.RowIndex).Value)
                Catch ex As Exception
                    gitems.Item(2, e.RowIndex).Value = "0,00"
                End Try
        End Select
    End Sub
End Class