Public Class FrmNovedadProce

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub ButtonG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonG.Click

        Try

       
            If txtproc.Text = "" Then
                MsgBox("Describa el procedimiento utilizado", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If

            Dim resultado As MsgBoxResult
            resultado = MsgBox("El procedimiento sera aplicado a la novedad.¿Desea Guardarlo?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?fecha", CDate(txtf2.Text.ToString))
                myCommand.CommandText = "UPDATE inm_novdad set proced= '" & txtproc.Text & "',fecha_pro = ?fecha, estado='CUMPLIDO' WHERE ndoc ='" & Lbnov.Text & "';"
                myCommand.ExecuteNonQuery()
                Refresh()

                MsgBox("Procedimiento registrado satisfactoriamente", MsgBoxStyle.Information, "SAE")
                txtproc.Enabled = False
                txtf2.Enabled = False
                ButtonG.Enabled = False
                FrmNovedadInm.BuscarNovedad()

            End If

        Catch ex As Exception
            MsgBox("Error al Guardar los datos", MsgBoxStyle.Information, "SAE")
        End Try

    End Sub
End Class