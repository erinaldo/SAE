Public Class FrmConcomiCart

    Private Sub limpiar()
        txttip.Text = ""
        txtnom.Text = ""
        gitems.Rows.Clear()
        lbestado.Text = ""
    End Sub
    Private Sub bloquear()
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        CmdMostrar.Enabled = False
        CmdEliminar.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        txttip.Enabled = True
        gitems.Enabled = True
    End Sub
    Private Sub desbloquear()
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        CmdMostrar.Enabled = True
        CmdEliminar.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        txttip.Enabled = False
        gitems.Enabled = False
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close
    End Sub

    Private Sub FrmConcomiCart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        desbloquear()
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        bloquear()
        gitems.RowCount = 2
        lbestado.Text = "NUEVO"
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        limpiar()
        desbloquear()
        lbestado.Text = ""
    End Sub

    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores WHERE nitv='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttip.Text = ""
            Try
                Dim items As Integer
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM vendedores where estado='activo' ORDER BY nombre ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                Refresh()
                items = tabla2.Rows.Count
                FrmSelVendedor.gitems.RowCount = items + 1
                For i = 0 To items - 1
                    FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                    FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
                Next

                FrmSelVendedor.lbform.Text = "comicar"
                FrmSelVendedor.ShowDialog()
            Catch ex As Exception
            End Try
           
        Else
            txtnom.Text = tabla.Rows(0).Item("nombre")
        End If

        If txttip.Text <> "" Then
            buscExist()
        End If

    End Sub

    Private Sub txttip_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        If txttip.Text = "" Then
            txtnom.Text = ""
        End If
    End Sub

    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        Select Case e.ColumnIndex
            Case 0
                'gitems.RowCount = gitems.RowCount + 1
        End Select
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
      
        Select Case e.ColumnIndex
            Case 0
                concomi(e.RowIndex)
            Case 3
                Try
                    gitems.Item("R1", e.RowIndex).Value = CInt(gitems.Item("R1", e.RowIndex).Value)
                Catch ex As Exception
                    MsgBox("Digite un valor numerico", MsgBoxStyle.Information, "Verificacion")
                    gitems.Item("R1", e.RowIndex).Value = "0"
                End Try
            Case 4
                Try
                    gitems.Item("R2", e.RowIndex).Value = CInt(gitems.Item("R2", e.RowIndex).Value)
                    If CInt(gitems.Item("R2", e.RowIndex).Value) < CInt(gitems.Item("R1", e.RowIndex).Value) Then
                        MsgBox("Digite un Rango de dias Valido", MsgBoxStyle.Information, "Verificacion")
                        gitems.Item("R2", e.RowIndex).Value = "0"
                    End If
                Catch ex As Exception
                    MsgBox("Digite un valor numerico", MsgBoxStyle.Information, "Verificacion")
                    gitems.Item("R2", e.RowIndex).Value = "0"
                End Try

        End Select
        
    End Sub
    Private Sub concomi(ByVal fil As Integer)

        Dim tc As New DataTable
        myCommand.CommandText = "SELECT * FROM concomi where codcon='" & Trim(gitems.Item(0, fila).Value) & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()

        If tc.Rows.Count = 0 Then
            gitems.Item("buscar", fil).Value = ""
            gitems.Item("nombre", fil).Value = ""
            gitems.Item("por", fil).Value = ""
            gitems.Item("R1", fil).Value = ""
            gitems.Item("R2", fil).Value = ""
            FrmConcepComi.Lbform.Text = "conmicar"
            FrmConcepComi.lbfila.Text = fil
            FrmConcepComi.ShowDialog()
        Else
            gitems.Item("buscar", fil).Value = tc.Rows(0).Item("codcon")
            gitems.Item("nombre", fil).Value = tc.Rows(0).Item("concepto")
            gitems.Item("por", fil).Value = tc.Rows(0).Item("porcomi")
            gitems.Item("R1", fil).Value = 0
            gitems.Item("R2", fil).Value = 0

        End If
    End Sub
    Private fila As Integer

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub
    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        Try
            If e.KeyCode = 8 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
                If resultado = MsgBoxResult.Yes Then
                    gitems.Rows.RemoveAt(fila)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click

        If txttip.Text = "" Then
            MsgBox("Verifique el nit del Vendedor", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If
        Dim c As Integer = 0
        For i = 0 To gitems.RowCount - 1
            If CStr(gitems.Item("buscar", i).Value) = "" Then
                c = c + 1
            End If
        Next
        If c = gitems.RowCount Then
            MsgBox("Agrege al menos un concepto comisionable", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If

        '....Guardar
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Las comisiones por recaudo para el vendedor " & txtnom.Text & " se van ha Guardar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            If lbestado.Text = "CONSULTA" Then
                Eliminar()
            End If
            For j = 0 To gitems.RowCount - 1
                If CStr(gitems.Item("buscar", j).Value) <> "" Then
                    Guardar(j)
                End If
            Next
            Cerrar()
            MsgBox("Las comisiones para el vendedor " & txtnom.Text & " han sido Guardadas ", MsgBoxStyle.Information, "SAE")
            desbloquear()
        End If

      



        

    End Sub
    Private Sub Eliminar()
        'Try
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM comicar WHERE nitv='" & txttip.Text & "'; "
        myCommand.ExecuteNonQuery()
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub Guardar(ByVal f As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?nitv", txttip.Text.ToString)
            myCommand.Parameters.AddWithValue("?codcon", gitems.Item("buscar", f).Value)
            myCommand.Parameters.AddWithValue("?por", DIN(gitems.Item("por", f).Value))
            myCommand.Parameters.AddWithValue("?r1", DIN(gitems.Item("R1", f).Value))
            myCommand.Parameters.AddWithValue("?r2", DIN(gitems.Item("R2", f).Value))
            myCommand.CommandText = "INSERT INTO comicar Values(?nitv,?codcon,?por,?r1,?r2); "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al Guardar ", MsgBoxStyle.Information, "Error")
        End Try
        
    End Sub

    Private Sub BuscarCC()

        Dim t2 As New DataTable
        t2.Clear()
        myCommand.CommandText = "SELECT c.codcon, cc.concepto, c.porcomi, c.r1, c.r2 FROM  comicar c, concomi cc WHERE c.nitv = '" & txttip.Text & "' AND cc.codcon = c.codcon ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        Refresh()
        lbestado.Text = "CONSULTA"
        gitems.Rows.Clear()

        For i = 0 To t2.Rows.Count - 1
            gitems.Rows.Add(t2.Rows(i).Item("codcon"), t2.Rows(i).Item("concepto"), t2.Rows(i).Item("porcomi"), t2.Rows(i).Item("r1"), t2.Rows(i).Item("r2"))
        Next

    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            tabla2.Clear()
            myCommand.CommandText = "SELECT * FROM vendedores where estado='activo' ORDER BY nombre ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next

            FrmSelVendedor.lbform.Text = "comicarV"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
        End Try

        buscExist()

    End Sub
    Private Sub buscExist()
        If txttip.Text <> "" Then
            Dim t As New DataTable
            t.Clear()
            myCommand.CommandText = "SELECT * FROM comicar where nitv='" & txttip.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()
            gitems.Rows.Clear()
            lbestado.Text = ""
            If t.Rows.Count <> 0 Then
                BuscarCC()
            End If
        End If
    End Sub

    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If lbestado.Text = "CONSULTA" Then
            bloquear()
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text = "CONSULTA" And txttip.Text <> "" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Las comisiones por recaudo para el vendedor " & txtnom.Text & " se van ha eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Eliminar()
                limpiar()
            End If
        Else
            MsgBox("Verifique las comisiones por recaudo", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub
End Class