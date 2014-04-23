Public Class FrmMenuImp
    Private Sub cmdgrupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgrupos.Click
        FrmGruposImp.ShowDialog()
    End Sub
    Private Sub cmdimpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdimpuestos.Click
        FrmImpuestos.ShowDialog()
    End Sub
    Private Sub cmdreportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreportes.Click
        Me.Close()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMenuImp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Try
            myCommand.CommandText = "ALTER TABLE `impuestos` CHANGE `porce` `porce` DECIMAL( 10, 2 ) NOT NULL;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
End Class