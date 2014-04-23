Public Class FrmCuentaRtCree

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmCuentaRtCree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tb As New DataTable
            myCommand.CommandText = "SELECT  distinct tarifa FROM `retecree`;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            cmbporc.Items.Clear()

            If tb.Rows.Count > 0 Then
                For i = 0 To tb.Rows.Count - 1
                    cmbporc.Items.Add(Moneda(tb.Rows(i).Item(0)))
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los porcentajes, " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        If txtcuenta.Text = "" Then
            Try
                FrmCuentas.lbform.Text = "cuentRC"
                FrmCuentas.ShowDialog()
            Catch ex As Exception
            End Try
            
        Else
            Dim t As New DataTable
            myCommand.CommandText = "SELECT codigo FROM selpuc where nivel='Auxiliar' and codigo='" & txtcuenta.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows.Count = 0 Then
                Try
                    txtcuenta.Text = ""
                    FrmCuentas.lbform.Text = "cuentRC"
                    FrmCuentas.ShowDialog()
                Catch ex As Exception
                End Try
            End If

        End If
    End Sub

    Private Sub cmdactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactualizar.Click
        If txtcuenta.Text = "" Then
            MsgBox("Verifique la cuenta", MsgBoxStyle.Information, "Verificacion")
            txtcuenta.Focus()
            Exit Sub
        End If
        If cmbporc.Text = "" Then
            MsgBox("Verifique el porcentaje", MsgBoxStyle.Information, "Verificacion")
            cmbporc.Focus()
            Exit Sub
        End If
        Cuenta_RC()
    End Sub
    Private Sub Cuenta_RC()
        Try
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE retecree SET cuenta='" & txtcuenta.Text & "' WHERE tarifa='" & DIN(cmbporc.Text) & "'"
            myCommand.ExecuteNonQuery()
            Refresh()
            Cerrar()

            MsgBox("Cuenta Agregada ", MsgBoxStyle.Information, "SAE")
        Catch ex As Exception
            MsgBox("Error al Guardar la cuenta, " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub

    Private Sub cmbporc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbporc.SelectedIndexChanged
        Try
            If cmbporc.Text <> "" Then
                Dim tc As New DataTable
                myCommand.CommandText = "SELECT distinct cuenta FROM `retecree` where tarifa ='" & DIN(cmbporc.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    txtcuenta.Text = tc.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class