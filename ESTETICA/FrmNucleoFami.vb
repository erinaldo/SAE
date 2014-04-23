Public Class FrmNucleoFami

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtpor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpor.LostFocus
        Try
            txtpor.Text = Moneda(txtpor.Text)
        Catch ex As Exception
            txtpor.Text = Moneda(0)
        End Try
    End Sub
    Private Sub Desbloquear()
        txtcodG.Enabled = True
        txtGrupo.Enabled = True
        txtpor.Enabled = True
        grilla.Enabled = True

        cmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Private Sub Bloquear()
        txtcodG.Enabled = False
        txtGrupo.Enabled = False
        txtpor.Enabled = False
        grilla.Enabled = False

        cmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Private Sub limpiar()

        'Try
        '    grilla.Rows.Clear()
        'Catch ex As Exception
        'End Try
        txtGrupo.Text = ""
        txtpor.Text = Moneda(0)
        txtcodG.Text = ""

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        Desbloquear()
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Bloquear()
    End Sub

    Private Sub FrmNucleoFami_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        Bloquear()

        Dim col As New CalendarColumn()
        Me.grilla.Columns.Add(col)
        Me.grilla.Columns.Item(3).HeaderText = "FECHA DE NACIEMIENTO"

        With grilla
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub txtcodG_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodG.LostFocus

        Dim tabla As New DataTable
        myCommand.CommandText = "Select * from grupo_flia where codgrupo='" & txtcodG.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            MsgBox("Este codigo ya fue asignado a un grupo familiar", MsgBoxStyle.Information, "Verifique")
            txtcodG.Text = ""
        End If
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
       
    End Sub
    Public Sub BuscarNit(ByVal nit As String, ByVal fila As Integer)
        Try
            If Trim(nit) = "" Then
                Try
                    grilla.Item(1, fila).Value = ""
                    FrmSelCliente.lbform.Text = "NucleoF"
                    FrmSelCliente.lbfila.Text = fila
                    FrmSelCliente.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                Dim items As Integer
                Dim tabla, tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & Trim(nit) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula " & nit & " del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(nit)
                        grilla.Item(0, fila).Value = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "NucleoF"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit, Verifique...", MsgBoxStyle.Information, "SAE Información")
                        grilla.Item(0, fila).Value = ""
                        grilla.Item(1, fila).Value = ""
                        Try
                            FrmSelCliente.lbform.Text = "NucleoF"
                            FrmSelCliente.lbfila.Text = fila
                            FrmSelCliente.ShowDialog()
                        Catch ex As Exception
                        End Try
                    End If
                Else
                    grilla.Item(0, fila).Value = Trim(nit)
                    grilla.Item(1, fila).Value = Trim(tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos"))
                End If
            End If
           
            'SendKeys.Send(Chr(Keys.Tab))

        Catch ex As Exception
        End Try
    End Sub


    Private Sub grilla_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0
                    BuscarNit(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
                Case 2
                    Try
                        grilla.Item(0, e.RowIndex).Value = Int(grilla.Item(0, e.RowIndex).Value)
                    Catch ex As Exception
                        MsgBox("Verifique la edad", MsgBoxStyle.Information, "Verifique")
                        grilla.Item(0, e.RowIndex).Value = 0
                    End Try
            End Select
        Catch ex As Exception
        End Try
    End Sub

    
End Class