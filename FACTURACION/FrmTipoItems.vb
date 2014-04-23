Public Class FrmTipoItems

    Private Sub Ch_Inv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch_Inv.CheckedChanged
        Dim fila As Integer = Val(lbfila.text)
        If Ch_Inv.Checked = True Then
            If lbser.Text = "Alt + G = Gastos" Then
                FrmItemsCompras.gitems.Item("tipo", fila).Value = "I"
            Else
                FrmItems.gitems.Item("tipo", fila).Value = "I"
            End If
            Me.Close()
        End If
    End Sub
    Private Sub Ch_Ser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch_Ser.CheckedChanged
        Dim fila As Integer = Val(lbfila.Text)
        If Ch_Ser.Checked = True Then
            If lbser.Text = "Alt + G = Gastos" Then
                FrmItemsCompras.gitems.Item("tipo", fila).Value = "G"
            Else
                FrmItems.gitems.Item("tipo", fila).Value = "S"
            End If
            Me.Close()
        End If
    End Sub
    '*****************************
    Private Sub FrmTipoItems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Ch_Inv.Checked = False
        Ch_Ser.Checked = False
    End Sub

    Private Sub FrmTipoItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ch_Inv.Checked = False
        Ch_Ser.Checked = False
    End Sub

   
End Class