Public Class FrmCirreInv

    Private Sub FrmCirreInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
    End Sub

    Private Sub cmdcierreA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcierreA.Click
        BuscarPeriodo()
        If (PerActual(0) & PerActual(1)) = "12" Then
            If VerificarCierre() = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Me.mibarra.Visible = True
            CierreInventarios()
            Me.Cursor = Cursors.Default
            Me.mibarra.Visible = False
        Else
            MsgBox("Esta operación solo se puede realizar en el mes 12 (Diciembre). ", MsgBoxStyle.Information, "SAE CONTROL")
        End If
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Function VerificarCierre()
        If Val(PerActual(0) & PerActual(1)) <> 12 Then
            MsgBox("Este proceso solo se puede realizar en el mes 12 (diciembre)", MsgBoxStyle.Information, "SAE Cierre de Año")
            Return False
        Else
            Return True
        End If
    End Function
End Class