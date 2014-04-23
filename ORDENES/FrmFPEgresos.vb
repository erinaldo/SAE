Public Class FrmFPEgresos

   
    Private Sub FrmFPEgresos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub gcuenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellContentClick

    End Sub

    Private Sub gcuenta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEndEdit
        Select Case e.ColumnIndex
            Case 5
                If gcuenta.Item("monto", e.RowIndex).Value <> "" Then
                    Try
                        gcuenta.Item("monto", e.RowIndex).Value = Moneda(gcuenta.Item("monto", e.RowIndex).Value)
                    Catch ex As Exception
                        gcuenta.Item("monto", e.RowIndex).Value = ""
                    End Try
                End If
            Case 2
                Try
                    BuscarBanco(gcuenta.Item("cta", e.RowIndex).Value.ToString, e.RowIndex)
                Catch ex As Exception
                    BuscarBanco("", e.RowIndex)
                End Try
            Case 6
                Try
                    gcuenta.Item("cheque", e.RowIndex).Value = UCase(gcuenta.Item("cheque", e.RowIndex).Value)
                Catch ex As Exception
                    gcuenta.Item("cheque", e.RowIndex).Value = ""
                End Try
        End Select
    End Sub
    Public Sub BuscarBanco(ByVal cta As String, ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT b.*, s.descripcion FROM bancos b, selpuc s WHERE s.codigo= b.codigo AND b.num_cta LIKE '%" & cta & "%';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If (tabla.Rows.Count = 0) Then
                
                Try
                    FrmSelBanco.txtcuenta.Text = cta
                    Me.gcuenta.Item("codigo", f).Value = ""
                    Me.gcuenta.Item("banco", f).Value = ""
                    Me.gcuenta.Item("cta", f).Value = ""
                    Me.gcuenta.Item("cta_con", f).Value = ""
                    FrmSelBanco.lbfila.Text = f
                    FrmSelBanco.lbform.Text = "FPE" 'forma de pago egresos públicos
                    FrmSelBanco.ShowDialog()
                Catch ex As Exception

                End Try
            Else
                Me.gcuenta.Item("codigo", f).Value = tabla.Rows(0).Item("cod_ban").ToString
                Me.gcuenta.Item("banco", f).Value = tabla.Rows(0).Item("descripcion").ToString
                Me.gcuenta.Item("cta", f).Value = tabla.Rows(0).Item("num_cta").ToString
                Me.gcuenta.Item("cta_con", f).Value = tabla.Rows(0).Item("codigo").ToString

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        AgregarPagos()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub AgregarPagos()
        Dim suma As Double = 0
        Try
            For i = 0 To gcuenta.RowCount - 2
                Try
                    suma += CDbl(gcuenta.Item("monto", i).Value)
                Catch ex As Exception
                End Try
                Try
                    If gcuenta.Item("cta", i).Value = "" Then
                        MsgBox("Favor verifique las cuentas bancarias.", MsgBoxStyle.Information, "SAE Validar Pagos")
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Favor verifique las cuentas bancarias.", MsgBoxStyle.Information, "SAE Validar Pagos")
                    gcuenta.Focus()
                    Exit Sub
                End Try
                Try
                    If gcuenta.Item("cheque", i).Value = "" Then
                        MsgBox("Favor verifique los numeros de transacciones / cheque.", MsgBoxStyle.Information, "SAE Validar Pagos")
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Favor verifique los numeros de transacciones / cheque.", MsgBoxStyle.Information, "SAE Validar Pagos")
                    gcuenta.Focus()
                    Exit Sub
                End Try
            Next
            If suma <> CDbl(txttotal.Text) Then
                MsgBox("La sumatoria de los montos pagados no puede ser diferente del valor neto a pagar (" & txttotal.Text & "), verifique.", MsgBoxStyle.Information, "SAE Validar Pagos")
                gcuenta.Focus()
                Exit Sub
            End If
            FrmNuevoEgreso.gcuenta.RowCount = gcuenta.RowCount
            FrmNuevoEgreso.txtcta.Text = gcuenta.Item("cta_con", 0).Value
            FrmNuevoEgreso.txtbanco.Text = gcuenta.Item("banco", 0).Value
            FrmNuevoEgreso.txtcheque.Text = gcuenta.Item("cheque", 0).Value
            For i = 0 To gcuenta.RowCount - 1
                FrmNuevoEgreso.gcuenta.Item("cta_con", i).Value = gcuenta.Item("cta_con", i).Value
                FrmNuevoEgreso.gcuenta.Item("monto", i).Value = gcuenta.Item("monto", i).Value
                FrmNuevoEgreso.gcuenta.Item("cheque2", i).Value = gcuenta.Item("cheque", i).Value
                FrmNuevoEgreso.gcuenta.Item("banco", i).Value = gcuenta.Item("banco", i).Value
            Next
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public fila As Integer
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gcuenta_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gcuenta.CellValidating
        If e.ColumnIndex = 6 Then
            SendKeys.Send("{HOME}")
        Else
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If

    End Sub

    Private Sub gcuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gcuenta.KeyDown
        If e.KeyCode = 8 Then
            If fila = gcuenta.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If fila = gcuenta.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            gcuenta.Rows.RemoveAt(fila)
        End If

    End Sub
End Class