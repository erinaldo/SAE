Public Class Frmdetafac

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub Frmdetafac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gdetaF
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
End Class