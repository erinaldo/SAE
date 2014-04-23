Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class FrmLogin
    Public sw As Integer

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        If txtusuario.Text = "" Then
            MsgBox("Digite el usuario ", MsgBoxStyle.Information, "Verificando")
            txtusuario.Focus()
            Exit Sub
        ElseIf txtpasswd.Text = "" Then
            MsgBox("Digite su contraseña ", MsgBoxStyle.Information, "Verificando")
            txtpasswd.Focus()
            Exit Sub
        End If
        Buscar()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Public Sub Buscar()
        MiConexion("sae")
        If bConexionExitosa = False Then
            Exit Sub
            Application.Exit()
        End If
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * from sae.usuarios where login='" & txtusuario.Text & "' AND estado='activo';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("Usuario o contraseña invalido, Verifique ", MsgBoxStyle.Information, "Verificando")
            txtusuario.Focus()
            Exit Sub
        End If
        TestDecoding(tabla.Rows(0).Item("passw"), txtpasswd.Text)
        If sw = 0 Then
            MsgBox("Usuario o contraseña invalido, Verifique ", MsgBoxStyle.Information, "Verificando")
            txtusuario.Focus()
            Exit Sub
        End If
        BuscarCom(tabla.Rows(0).Item("rol"))
    End Sub
    Public Sub BuscarCom(ByVal rol As String)
        If rol = "" Then
            MsgBox("Usuario no tiene un rol definido, Verifique ", MsgBoxStyle.Information, "Verificando")
            txtusuario.Focus()
            Exit Sub
        ElseIf rol = "admin" And txtcompania.Text = "" Then
            UsuarioActual = txtusuario.Text
            FrmPrincipal.lbuser.Text = UsuarioActual
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT login FROM companias ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay compañias creadas, Verifique ", MsgBoxStyle.Information, "Verificando")
                CompaniaActual = ""
                FrmPrincipal.lbcompania.Text = CompaniaActual
                FrmPrincipal.LbPeriodo.Text = "00/0000"
            Else
                CompaniaActual = LCase(tabla.Rows(0).Item("login"))
                FrmPrincipal.lbcompania.Text = tabla.Rows(0).Item("login")
                BuscarPeriodo()
                FrmPrincipal.LbPeriodo.Text = PerActual
            End If
        Else
            If rol <> "admin" Then
                FrmPrincipal.CrearNuevaToolStripMenuItem.Enabled = False
                FrmPrincipal.GestionToolStripMenuItem.Enabled = False
            End If
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT * from companias where login='" & txtcompania.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("Compañia o contraseña invalido, Verifique ", MsgBoxStyle.Information, "Verificando")
                txtcompania.Focus()
                Exit Sub
            End If
            TestDecoding(tabla.Rows(0).Item("clave"), txtpasswC.Text)
            If sw = 0 Then
                MsgBox("Compañia o contraseña invalido, Verifique ", MsgBoxStyle.Information, "Verificando")
                txtcompania.Focus()
                Exit Sub
            End If
            UsuarioActual = txtusuario.Text
            CompaniaActual = Trim(LCase(txtcompania.Text))
            BuscarPeriodo()
            FrmPrincipal.lbuser.Text = UsuarioActual
            FrmPrincipal.LbPeriodo.Text = PerActual
            FrmPrincipal.lbcompania.Text = UCase(CompaniaActual)
        End If
        '**********  ENTRAR   **********************
        Cerrar()
        BuscarPeriodo()
        Try
            If Trim(CompaniaActual) = "" Then
                bda = "sae"
            Else
                bda = "sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            End If
        Catch ex As Exception
            bda = "sae"
        End Try
        'FrmPrincipal.lbcompania.Text = ""
        If FrmPrincipal.LbPeriodo.Text = "(ninguno)" And FrmPrincipal.lbcompania.Text <> "" Then
            FrmPeriodo.lbactual.Text = PerActual
            FrmPeriodo.ShowDialog()
        End If
        FrmPrincipal.Show()
        Me.Close()
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

    '////////EVENTOS KEYPRESS ///////////////
    Private Sub txtusuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpasswd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasswd.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcompania_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcompania.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpasswC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasswC.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            OK_Click(AcceptButton, AcceptButton)
        End If
    End Sub
End Class
