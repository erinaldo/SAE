Public Class FrmCuentasSalIniinv

    Private Sub txtcredito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcredito.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "salinv_C"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtdebito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdebito.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "salinv_D"
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If txtcredito.Text = "" Then
            MsgBox("No ha definido la cuenta credito para el documento contable", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        If txtcredito.Text = "" Then
            MsgBox("No ha definido la cuenta debito para el documento contable", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        guardar()

    End Sub

    Private Sub guardar()

        MiConexion(bda)
        'Try
        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE parinven " _
                             & "SET cdebito='" & txtdebito.Text & "', ccredito='" & txtcredito.Text & "' ;"
        myCommand.ExecuteNonQuery()

        Cerrar()
        MsgBox("Las cuentas han sido guardadas exitosamente.", MsgBoxStyle.Information, "SAE")
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub FrmCuentasSalIniinv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM parinven ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            If tabla.Rows.Count > 0 Then
                txtdebito.Text = tabla.Rows(0).Item("cdebito")
                txtcredito.Text = tabla.Rows(0).Item("ccredito")
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class