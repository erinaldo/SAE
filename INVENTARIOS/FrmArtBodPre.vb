Public Class FrmArtBodPre

    Private Sub FrmArtBodPre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        gitems.RowCount = 1
        gitems.Rows.Clear()
        If lbform.Text = "ARTICULO EN BODEGAS" Then
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            gitems.RowCount = items
            For i = 0 To items - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item("numbod")
                gitems.Item(1, i).Value = tabla.Rows(i).Item("nombod")
                gitems.Item(2, i).Value = CantEnBodega(tabla.Rows(i).Item("numbod"))
            Next
        Else
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
                gitems.Item(2, i).Value = ListasPrec(tabla.Rows(i).Item("numlist"))
            Next
        End If
    End Sub
    Function CantEnBodega(ByVal numbod As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cant" & numbod & " FROM con_inv WHERE periodo=" & PerActual(0) & PerActual(1) & " AND codart='" & lbcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                Return "0"
            Else
                Return tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Return "0"
        End Try
    End Function
    Function ListasPrec(ByVal numlist As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT precio" & numlist & " FROM con_inv WHERE periodo=" & PerActual(0) & PerActual(1) & " AND codart='" & lbcodigo.Text & "';"
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
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Select Case e.ColumnIndex
            Case 2
                gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
        End Select
    End Sub

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        If lbform.Text = "LISTAS DE PRECIOS DEL ARTICULO" Then
            ActualizarListaPrecios()
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub ActualizarListaPrecios()
        MiConexion(bda)
        For i = 0 To gitems.Rows.Count - 1
            If gitems.Item(1, i).Value <> "" Then
                ejecutaSQL("UPDATE con_inv SET precio" & gitems.Item(0, i).Value & "=" & DIN(gitems.Item(2, i).Value) & " WHERE codart='" & lbcodigo.Text & "' AND periodo='" & PerActual(0) & PerActual(1) & "';")
            End If
        Next
        Cerrar()
        MsgBox("Las listas de precios fueron actualizadas correctamente. ", MsgBoxStyle.Information, "SAE Acualizar Listas")
        Me.Close()
    End Sub
    Public Sub ejecutaSQL(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            '  MsgBox(sql & " //////// " & ex.ToString)
        End Try
     
    End Sub
End Class