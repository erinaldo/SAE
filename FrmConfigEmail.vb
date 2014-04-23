Public Class FrmConfigEmail

    Private Sub FrmConfigEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        TraerConfig()
    End Sub
    Public Sub TraerConfig()
        '********* SINO HAY PONER EN CERO ****************
        cbhost.Text = "hotmail"
        cbdia.Text = "Lunes"

    End Sub
    Private Sub cmdemail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdemail.Click
        EnviarEmail(cbhost.Text, txtcorreo.Text, txtpass1.Text, "C:\temp.txt", "Una pueba de correo", txtdestino1.Text, txtdestino2.Text, "Copia SAE " & Now)
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class