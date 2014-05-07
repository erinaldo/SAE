Public Class FrmNucleoFami
    Public col, fila, FinEdit As Integer
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtpor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpor.LostFocus
        Try
            txtpor.Text = Moneda(txtpor.Text)
        Catch ex As Exception
            MsgBox("Verifique el porcentaje", MsgBoxStyle.Information, "SAE")
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

        Try
            grilla.Rows.Clear()
        Catch ex As Exception
        End Try
        txtGrupo.Text = ""
        txtpor.Text = Moneda(0)
        txtcodG.Text = ""

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        Desbloquear()
        txtcodG.Focus()
        lbestado.Text = "NUEVO"
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Bloquear()
        limpiar()
        lbestado.Text = ""
    End Sub

    Private Sub FrmNucleoFami_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        Bloquear()

        'Dim col As New CalendarColumn()
        'Me.grilla.Columns.Add(col)
        'Me.grilla.Columns.Item(3).HeaderText = "FECHA DE NACIMIENTO"

        'With grilla
        '    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        '    .DefaultCellStyle.BackColor = Color.FloralWhite
        'End With
    End Sub

    Private Sub txtcodG_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodG.LostFocus
        If lbestado.Text = "NUEVO" Then
            Dim tabla As New DataTable
            myCommand.CommandText = "Select codgrupo,nombre,pordes,nitc,edad,item from grupo_flia where codgrupo='" & txtcodG.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                MsgBox("Este codigo ya fue asignado a un grupo familiar", MsgBoxStyle.Information, "Verifique")
                txtcodG.Text = ""
            End If
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

    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        ' If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0
                    grilla.Item(3, e.RowIndex).Value = 0
            End Select
        Catch ex As Exception
        End Try
    End Sub


    Private Sub grilla_CellEndEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0
                    BuscarNit(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
                Case 3
                    Try
                        grilla.Item(3, e.RowIndex).Value = Int(grilla.Item(3, e.RowIndex).Value)
                    Catch ex As Exception
                        MsgBox("Verifique la edad", MsgBoxStyle.Information, "Verifique")
                        grilla.Item(3, e.RowIndex).Value = 0
                    End Try
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click


        If Trim(txtcodG.Text) = "" Then
            MsgBox("Verifique el codigo del Grupo", MsgBoxStyle.Information, "SAE")
            txtcodG.Focus()
            Exit Sub
        End If
        If grilla.Rows.Count = 1 Then
            MsgBox("Verifique los integrantes del nucleo familiar", MsgBoxStyle.Information, "SAE")
            Exit Sub
        End If

        MiConexion(bda)
        If lbestado.Text = "EDITAR" Then
            Eliminar()
        End If
        For i = 0 To grilla.Rows.Count - 1
            Try
                If grilla.Item("id", i).Value <> "" Then
                    Guardar(i)
                End If
            Catch ex As Exception
                MsgBox("Error " & ex.ToString)
            End Try
        Next
        Cerrar()
        If lbestado.Text = "EDITAR" Then
            MsgBox("Informacion Modificada Exitosamente", MsgBoxStyle.Information, "SAE")
        Else
            MsgBox("Informacion Guardada Exitosamente", MsgBoxStyle.Information, "SAE")
        End If

        Bloquear()
        lbestado.Text = "GUARDAR"

    End Sub
    Private Sub Eliminar()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM grupo_flia WHERE codgrupo='" & txtcodG.Text & "' ;"
            myCommand.ExecuteNonQuery()
            Refresh()
        Catch ex As Exception
            MsgBox("Error Eliminar " & ex.ToString)
        End Try
    End Sub
    Private Sub Guardar(ByVal i As Integer)

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?cod", txtcodG.Text)
        myCommand.Parameters.AddWithValue("?nom", CambiaCadena(txtGrupo.Text, 15))
        myCommand.Parameters.AddWithValue("?por", DIN(txtpor.Text))
        myCommand.Parameters.AddWithValue("?nitc", grilla.Item("id", i).Value)
        myCommand.Parameters.AddWithValue("?fec", "0000-00-00")
        myCommand.Parameters.AddWithValue("?edad", grilla.Item("edad", i).Value)
        myCommand.Parameters.AddWithValue("?item", i)
        myCommand.CommandText = "INSERT INTO grupo_flia Values(?cod,?nom,?por,?nitc,?fec,?edad,?item) ;"
        myCommand.ExecuteNonQuery()
        Refresh()

    End Sub

    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If txtcodG.Text = "" Then
            MsgBox("Verifique el Nucleo Familiar a Editar", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If
        lbestado.Text = "EDITAR"
        Desbloquear()
        txtGrupo.Focus()
        txtcodG.Enabled = False
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If txtcodG.Text = "" Then
            MsgBox("Verifique el Nucleo Familiar a Eliminar", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If

        Dim resultado As MsgBoxResult
        resultado = MsgBox("El Nucleo Familiar será Eliminado ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            Eliminar()
            Cerrar()
            limpiar()
            lbestado.Text = "ELIMINADO"
            MsgBox("Nucleo Familiar Eliminado", MsgBoxStyle.Information, "SAE")
        End If
    End Sub

    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        
        End If
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelNucleoF.lbform.Text = "nucleo"
            FrmSelNucleoF.ShowDialog()
        Catch ex As Exception
        End Try
       
        If Trim(txtcodG.Text) <> "" Then
            BuscarNucleo(Trim(txtcodG.Text))
        End If
    End Sub
    Private Sub BuscarNucleo(ByVal nucleo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "Select codgrupo,nombre,pordes,nitc,edad,item from grupo_flia where codgrupo='" & nucleo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            grilla.RowCount = tabla.Rows.Count + 1
            txtcodG.Text = tabla.Rows(0).Item("codgrupo")
            txtGrupo.Text = tabla.Rows(0).Item("nombre")
            txtpor.Text = Moneda(tabla.Rows(0).Item("nombre"))
            For i = 0 To tabla.Rows.Count - 1
                grilla.Item("id", i).Value = tabla.Rows(i).Item("nitc")
                BuscarNit(tabla.Rows(i).Item("nitc"), i)
                grilla.Item("edad", i).Value = tabla.Rows(i).Item("edad")
            Next
        End If
    End Sub

End Class