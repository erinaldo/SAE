Public Class FrmCambiarContraComp
    Public sw As Integer
    Private Sub FrmCambiarContraComp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        actual.Text = ""
        pass1.Text = ""
        pass2.Text = ""
        actual.Focus()
    End Sub
    Private Sub FrmCambiarContraComp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbusuario.Text = FrmPrincipal.lbcompania.Text
        actual.Text = ""
        pass1.Text = ""
        pass2.Text = ""
    End Sub
    Private Sub cmdcambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcambiar.Click
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * from sae.companias where login='" & lbusuario.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("Compañia o contraseña invalido, Verifique ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        TestDecoding(tabla.Rows(0).Item("clave"), actual.Text)
        If sw = 0 Then
            MsgBox("Contraseña invalida, Verifique ", MsgBoxStyle.Information, "Verificando")
            actual.Focus()
            Exit Sub
        End If
        If pass1.Text <> pass2.Text Then
            MsgBox("Las contraseñas no coinciden, Verifique ", MsgBoxStyle.Information, "Verificando")
            pass1.Focus()
            Exit Sub
        ElseIf pass1.Text = "" Then
            MsgBox("La contraseñas no pude ser en blanco, Verifique ", MsgBoxStyle.Information, "Verificando")
            pass1.Focus()
            Exit Sub
        End If
        TestEncoding()
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    '****************************************************
    Sub TestEncoding()
        Dim plainText As String = "sae"
        Dim password As String = pass1.Text
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        modificar(cipherText)
    End Sub
    Sub TestDecoding(ByVal cipherText As String, ByVal password As String)
        sw = 0
        Dim wrapper As New Simple3Des(password)
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            sw = 1
        Catch ex As System.Security.Cryptography.CryptographicException
            sw = 0
        End Try
    End Sub

    Public Sub modificar(ByVal passw As String)
        MiConexion("sae")
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?login", lbusuario.Text)
        myCommand.Parameters.AddWithValue("?passw", passw.ToString)
        myCommand.CommandText = "Update sae.companias set clave=?passw WHERE login=?login;"
        myCommand.ExecuteNonQuery()
        MsgBox("La contraseña de la compañia fue modifica correctamente ", MsgBoxStyle.Information, "Guardar Datos")
        Cerrar()
        MiConexion(bda)
        Cerrar()
        Me.Close()
    End Sub

    Private Sub actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles actual.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub pass1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pass1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub pass2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pass2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class