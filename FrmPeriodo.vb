Imports System.IO
Public Class FrmPeriodo
    Private Sub cmdcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcan.Click
        Me.Close()
    End Sub
    Private Sub cmdabrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdabrir.Click
        Try
            If mes.Text = "" Or ano.Text = "" Then Exit Sub
            AbrirPeriodo(mes.Text & "/" & ano.Text)
            lbactual.Text = PerActual
            FrmPrincipal.LbPeriodo.Text = PerActual
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub mes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mes.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmPeriodo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mes.Items.Clear()
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" And t.Rows(0).Item(0).ToString <> "modificacion" Then
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Me.Close()
            Exit Sub
        End If
        '*******************************
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & bda & ".bloq_per ORDER BY periodo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 1 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item(1) = "n" Then
                    mes.Items.Add(tabla.Rows(i).Item(0))
                End If
            Next
        Catch ex As Exception
            For i = 1 To 12
                If i < 10 Then
                    mes.Items.Add("0" & i)
                Else
                    mes.Items.Add(i)
                End If

            Next

        End Try

        mes.Text = lbmes.Text
    End Sub
End Class