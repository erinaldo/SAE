Public Class FrmAbrirCompania
    Public fil As Integer
    Private Sub FrmAbrirCompania_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gitems.Focus()
    End Sub
    Private Sub FrmAbrirCompania_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        gitems.Focus()
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Seleccionar(e.RowIndex)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Seleccionar(fil - 1)
        End If
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Seleccionar(fil)
    End Sub

    Public Sub Seleccionar(ByVal fila As Integer)
        If fila < 0 Then Exit Sub
        If gitems.Item(1, fila).Value = "" Then Exit Sub
        FrmPass.txtcompania.Text = gitems.Item(0, fila).Value
        LbPass.Text = ""
        FrmPass.txtpasswC.Text = ""
        FrmPass.ShowDialog()
        AbrirCompa(gitems.Item(0, fila).Value, LbPass.Text)
    End Sub
    Public Sub AbrirCompa(ByVal compa As String, ByVal pass As String)
        If pass = "" Then Exit Sub
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & compa & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If TestDecoding(tabla.Rows(0).Item("clave"), pass) = True Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Se abrira la compañia (" & compa & "), ¿Desea Abrirla?", MsgBoxStyle.YesNo, "SAE verificando")
            If resultado = MsgBoxResult.Yes Then
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("PRINCIPAL", "ABRIR COMPAÑIA " & compa, "", "", "")
                End If
                CompaniaActual = LCase(compa)
                FrmPrincipal.lbcompania.Text = UCase(compa)
                'bda 
                BuscarPeriodo()
                FrmPrincipal.LbPeriodo.Text = PerActual
                CrearVista()
                If FrmPrincipal.lbcompania.Text <> "" Then
                    If FrmPrincipal.LbPeriodo.Text = "(ninguno)" Then
                        FrmPeriodo.lbactual.Text = PerActual
                        FrmPeriodo.ShowDialog()
                    End If
                End If
                MiConexion(bda)
                TablaAnticipos(bda)
                Cerrar()
                FrmPrincipal.Update_tablas()
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Auditoria(bda)
                    Auditoria_movimientos()
                End If
            End If

            Me.Close()
        Else
            MsgBox("Compañia o contraseña invalida, Verifique ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If

        MiConexion(bda)
        MoficarCC()
        Cerrar()


       
    End Sub
    Function TestDecoding(ByVal cipherText As String, ByVal password As String)
        Dim wrapper As New Simple3Des(password)
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            Return True
        Catch ex As System.Security.Cryptography.CryptographicException
            Return False
        End Try
    End Function
End Class