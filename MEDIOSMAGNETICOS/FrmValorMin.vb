Public Class FrmValorMin

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Me.Close()
    End Sub

    Private Sub FrmValorMin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buscarFormatos()
    End Sub
    Private Sub buscarFormatos()
        'Try


        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT DISTINCT c.codfor, f.descripcion FROM conceptos c, formatos f WHERE c.codfor = f.codigo Limit 7"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            cmbForm.Items.Clear()
            For i = 0 To tabla.Rows.Count - 1
                cmbForm.Items.Add(tabla.Rows(i).Item("codfor"))
            Next
        Else
            MsgBox("No existen formatos para mostrar", MsgBoxStyle.Information, "Verifique")
        End If
        'Catch ex As Exception
        '    MsgBox("Error al Cargar los Formatos")
        'End Try

    End Sub

    Private Sub cmbForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForm.SelectedIndexChanged
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT  f.descripcion, c.codcon, c.desc, c.tope  FROM  formatos f, conceptos c " _
        & " WHERE f.codigo= '" & cmbForm.Text & "'  AND c.codfor='" & cmbForm.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        grilla.Rows.Clear()
        If tabla.Rows.Count > 0 Then
            txtdesfor.Text = UCase(tabla.Rows(0).Item("descripcion"))
            grilla.RowCount = tabla.Rows.Count + 1
            For j = 0 To tabla.Rows.Count - 1
                grilla.Item("concepto", j).Value = tabla.Rows(j).Item("codcon")
                grilla.Item("nomd", j).Value = tabla.Rows(j).Item("desc")
                grilla.Item("valor", j).Value = tabla.Rows(j).Item("tope")
            Next
        End If
    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Select Case e.ColumnIndex
            Case 2
                Try
                    grilla.Item(2, e.RowIndex).Value = Moneda(grilla.Item(2, e.RowIndex).Value)
                Catch ex As Exception
                    grilla.Item(2, e.RowIndex).Value = Moneda(0)
                End Try
        End Select
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los valores para el formato" & cmbForm.Text & " seran agregados, Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            ActualiValor()
        End If
    End Sub
    Private Sub ActualiValor()
        MiConexion(bda)
        For i = 0 To grilla.Rows.Count - 1
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE conceptos " _
                            & "SET tope=" & DIN(grilla.Item("valor", i).Value) & " WHERE " _
                            & " codfor='" & cmbForm.Text & "' AND codcon='" & grilla.Item("concepto", i).Value & "';"
            myCommand.ExecuteNonQuery()
        Next
        MsgBox("Los Valores Fueron Actualizados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
End Class