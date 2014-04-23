Public Class FrmParametrosGer
    Dim fila2 As Integer
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Me.Close()
    End Sub

    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        'If fila2 > 0 Then
        '    Dim f As Integer
        '    f = fila2 - 1
        '    If gcuenta.Item(2, f).Value.ToString = "" Then
        '        MsgBox("Favor Verifique el orden de las cuentas", MsgBoxStyle.Information, "SAE Verificación")
        '        Exit Sub
        '    End If
        'End If
        FrmCuentas.lbform.Text = "analisis"
        FrmCuentas.lbfila.Text = fila2
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila2 = e.RowIndex
    End Sub

    Private Sub FrmParametrosGer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If c1.Checked = True Then
            lbtipo.Text = UCase(c1.Text)
            lbnum.Text = "1"
        Else
            lbtipo.Text = UCase(c2.Text)
            lbnum.Text = "2"
        End If
        BuscarCuentas(lbnum.Text)
    End Sub
    Public Sub BuscarCuentas(ByVal num As Integer)

        gcuenta.Rows.Clear()
        gcuenta.RowCount = 11
        For i = 0 To 9
            gcuenta.Item(1, i).Value = "CUENTA " & i + 1
        Next
        Dim tb As New DataTable

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM par_analisis WHERE num='" & num & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count = 0 Then Exit Sub
        For i = 0 To 9
            gcuenta.Item(3, i).Value = tabla.Rows(0).Item("cuenta" & i + 1)
            If tabla.Rows(0).Item("cuenta" & i + 1).ToString = "" Then
                gcuenta.Item(0, i).Value = False
            Else
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & tabla.Rows(0).Item("cuenta" & i + 1) & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                gcuenta.Item(2, i).Value = tb.Rows(0).Item("descripcion")
                gcuenta.Item(0, i).Value = True
                tb.Clear()
            End If
        Next
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        MiConexion(bda)
        Dim sw As Integer
        sw = 0
        For i = 0 To 9
            If gcuenta.Item(3, i).Value.ToString = "" Then Exit For
            sw = 1
            Guardar(Val(lbnum.Text), "cuenta" & (i + 1), gcuenta.Item(3, i).Value.ToString)
        Next
        If sw = 1 Then
            MsgBox("La(s) cuenta(s) de " & lbtipo.Text & " fueron guardadas coreectamente.", MsgBoxStyle.Information, "SAE Guardar")
        Else
            MsgBox("No ha digitado cuentas, Verifique.", MsgBoxStyle.Information, "SAE Verificación")
        End If
        Cerrar()
    End Sub
    Public Sub Guardar(ByVal numero As Integer, ByVal cuenta As String, ByVal codigo As String)
        myCommand.CommandText = "UPDATE par_analisis SET " & cuenta & "='" & codigo & "' WHERE num=" & numero & ";"
        myCommand.ExecuteNonQuery()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c1.Checked = True Then
            lbtipo.Text = UCase(c1.Text)
            lbnum.Text = "1"
            BuscarCuentas(lbnum.Text)
        Else
            lbtipo.Text = UCase(c2.Text)
            lbnum.Text = "2"
            BuscarCuentas(lbnum.Text)
        End If
    End Sub
End Class