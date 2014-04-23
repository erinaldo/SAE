
Public Class FrmInfTributarios

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    '*///////////////INFORMES TRIBUTARIOS ///////////////////
    Private Sub cmdcuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcuentas.Click
        FrmCuentasTributarias.ShowDialog()
    End Sub
    Private Sub cmdivapp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdivapp.Click
        BuscarTributarios(1)
    End Sub
    Private Sub cmdivades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdivades.Click
        BuscarTributarios(2)
    End Sub
    Private Sub cmdretpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdretpt.Click
        BuscarTributarios(3)
    End Sub
    Private Sub cmdretat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdretat.Click
        BuscarTributarios(4)
    End Sub
    Private Sub cmdivaret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdivaret.Click
        BuscarTributarios(5)
    End Sub
    Private Sub cdmICA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmICA.Click
        BuscarTributarios(6)
    End Sub
    Private Sub cdmotras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmotras.Click
        BuscarTributarios(7)
    End Sub
    Public Sub BuscarTributarios(ByVal num As Integer)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tributarios WHERE num=" & num & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then Exit Sub
        If tabla.Rows(0).Item("cuenta1").ToString = "" Then
            MsgBox("No hay cuentas definidas para este informe, verifique.", MsgBoxStyle.Information, "SAE Verificación")
        Else
            FrmTributarios.lbnum.Text = num
            FrmTributarios.lbtipo.Text = "INFORME DE " & UCase(tabla.Rows(0).Item("detalle").ToString)
            FrmTributarios.ShowDialog()
        End If
    End Sub

    Private Sub cmdrtc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrtc.Click
        BuscarTributarios(8)
    End Sub
End Class