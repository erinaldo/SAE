Public Class FrmCuentasTributarias
    Dim fila, fila2 As Integer
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Me.Close()
    End Sub

    Private Sub FrmCuentasTributarias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tributarios ORDER BY num;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        grilla.RowCount = tabla.Rows.Count
        gcuenta.RowCount = 15
        For i = 0 To tabla.Rows.Count - 1
            grilla.Item(0, i).Value = tabla.Rows(i).Item("num")
            grilla.Item(1, i).Value = tabla.Rows(i).Item("detalle")
        Next
        For i = 0 To 14
            gcuenta.Item(1, i).Value = "CUENTA " & i + 1
        Next
        BuscarCuentas(grilla.Item(0, 0).Value)
        lbtipo.Text = grilla.Item(1, 0).Value
    End Sub
    Public Sub BuscarCuentas(ByVal num As Integer)
        lbnum.Text = num
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tributarios WHERE num='" & num & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then Exit Sub
        For i = 0 To 14
            gcuenta.Item(2, i).Value = tabla.Rows(0).Item("cuenta" & i + 1)
            If tabla.Rows(0).Item("cuenta" & i + 1).ToString = "" Then
                gcuenta.Item(0, i).Value = False
            Else
                gcuenta.Item(0, i).Value = True
            End If
        Next
    End Sub

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        BuscarCuentas(Val(grilla.Item(0, fila).Value))
        lbtipo.Text = grilla.Item(1, fila).Value
    End Sub
    Private Sub grilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grilla.DoubleClick
        'If grilla.Item(0, fila).Value = "" Then Exit Sub
        BuscarCuentas(Val(grilla.Item(0, fila).Value))
        lbtipo.Text = grilla.Item(1, fila).Value
    End Sub
    
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        MiConexion(bda)
        Dim sw As Integer
        sw = 0
        For i = 0 To 14
            If gcuenta.Item(2, i).Value.ToString = "" Then Exit For
            sw = 1
            Guardar(Val(lbnum.Text), "cuenta" & (i + 1), gcuenta.Item(2, i).Value.ToString)
        Next
        If sw = 1 Then
            MsgBox("La(s) cuenta(s) de " & lbtipo.Text & " fueron guardadas coreectamente.", MsgBoxStyle.Information, "SAE Guardar")
        Else
            MsgBox("No ha digitado cuentas, Verifique.", MsgBoxStyle.Information, "SAE Verificación")
        End If
        Cerrar()
    End Sub
    Public Sub Guardar(ByVal numero As Integer, ByVal cuenta As String, ByVal codigo As String)
        myCommand.CommandText = "UPDATE tributarios SET " & cuenta & "='" & codigo & "' WHERE num=" & numero & ";"
        myCommand.ExecuteNonQuery()
    End Sub

    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        If fila2 > 0 Then
            Dim f As Integer
            f = fila2 - 1
            If gcuenta.Item(2, f).Value.ToString = "" Then
                MsgBox("Favor Verifique el orden de las cuentas", MsgBoxStyle.Information, "SAE Verificación")
                Exit Sub
            End If
        End If
        FrmCuentas.lbform.Text = "tributario"
        FrmCuentas.lbfila.Text = fila2
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila2 = e.RowIndex
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub gcuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellContentClick

    End Sub
End Class