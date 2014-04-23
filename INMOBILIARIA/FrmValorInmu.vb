Public Class FrmValorInmu

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Dim camp As String = ""
        If v1.Checked = True Then
            camp = "previvi "
        ElseIf v2.Checked = True Then
            camp = "prelocal "
        End If

        If camp = "" Then
            FrmContratos.txtvalor.Text = Moneda(0)
        Else
            MiConexion(bda)
            Dim t As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & camp & " FROM inmuebles WHERE codigo ='" & FrmContratos.txtinm.Text & "'  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()

            If t.Rows.Count > 0 Then
                FrmContratos.txtvalor.Text = Moneda(t.Rows(0).Item(0))
            Else
                FrmContratos.txtvalor.Text = Moneda(0)
            End If
            FrmContratos.lbtip_precio.Text = camp
            Cerrar()
        End If
        Me.Close()
    End Sub
End Class