Public Class FrmNitF

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Then
            txtnit_LostFocus(AcceptButton, AcceptButton)
        Else
            validarnumero(txtnit, e)
        End If
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnit.Text = "" Then
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnit.Text)
        End If
    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items > 0 Then
                txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nit,TRIM(CONCAT(apellidos,' ',nombre))AS ter FROM terceros ORDER BY ter;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("ter")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "items"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "items"
                frmterceros.txtnit.Text = txtnit.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtfila.Text = FrmItems.fila
        FrmItems.gitems.Item("nit", FrmItems.fila).Value = txtnit.Text
        Me.Close()
    End Sub

    Private Sub FrmNitF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfila.Text = ""
        txtnit.Text = ""
        txtcliente.Text = ""
        'If FrmItems.gitems.Item("tipo", FrmItems.fila).Value = "S" Then
        txtnit.Text = FrmItems.gitems.Item("nit", FrmItems.fila).Value()
        'End If
    End Sub
End Class