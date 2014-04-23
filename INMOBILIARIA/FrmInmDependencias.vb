Public Class FrmInmDependencias

    Private Sub crear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crear.Click
        gEspacio.RowCount = gEspacio.RowCount + 1
        gEspacio.Item("item", gEspacio.Rows.Count - 1).Value = gEspacio.Rows.Count
        gEspacio.Item("nombre", gEspacio.Rows.Count - 1).Value = cmbDesc.Text
        gEspacio.CurrentCell = gEspacio("nombre", gEspacio.Rows.Count - 1)

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInmDependencias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gEspacio
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With

        cmbDesc.Text = "AIRE ACONDICIONADO"
        gEspacio.Rows.Clear()

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT * from inm_dpden WHERE codigo_inm='" & txtcod.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()

        If ta.Rows.Count > 0 Then
            gEspacio.RowCount = ta.Rows.Count
            For i = 0 To ta.Rows.Count - 1
                gEspacio.Item("item", i).Value = i + 1
                gEspacio.Item("nombre", i).Value = ta.Rows(i).Item("descrip")
                gEspacio.Item("med", i).Value = ta.Rows(i).Item("espacio")
                gEspacio.Item("unidad", i).Value = ta.Rows(i).Item("umedida")
            Next
        End If

    End Sub
    Public fila As Integer
    Private Sub gEspacio_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gEspacio.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub seleccionar(ByVal fila As Integer)
        If gEspacio.Item("nombre", fila).Value <> "" Then
            Frmdescrip_items.txtCod.Text = gEspacio.Item("item", fila).Value
            Frmdescrip_items.lbform.Text = "inm"
            Frmdescrip_items.ShowDialog()
            Frmdescrip_items.lbform.Text = ""
        End If
    End Sub

    Private Sub gEspacio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gEspacio.KeyDown
        Try
            If e.KeyCode = 8 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
                If resultado = MsgBoxResult.Yes Then
                    gEspacio.Rows.RemoveAt(fila)
                End If
            ElseIf e.KeyCode = "13" Then
                seleccionar(fila)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        gEspacio.Rows.Clear()
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        MiConexion(bda)
        Try
            If gEspacio.Rows.Count <> 0 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Las Dependecias del inmueble se van a registrar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "DELETE FROM inm_dpden WHERE codigo_inm='" & txtcod.Text & "';"
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    For i = 0 To gEspacio.Rows.Count - 1
                        If gEspacio.Item("nombre", i).Value <> "" Then
                            guardar(i)
                        End If
                    Next
                    MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                End If
            Else
                MsgBox("No ha creado ninguna dependencia", MsgBoxStyle.Information, "Verificación")
            End If
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
    Private Sub guardar(ByVal fila As Integer)

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codinm", txtcod.Text)
        myCommand.Parameters.AddWithValue("?descrip", gEspacio.Item("nombre", fila).Value)
        If gEspacio.Item("med", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?espacio", DIN(0))
        Else
            myCommand.Parameters.AddWithValue("?espacio", DIN(gEspacio.Item("med", fila).Value))
        End If
        If gEspacio.Item("unidad", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?umedida", "")
        Else
            myCommand.Parameters.AddWithValue("?umedida", gEspacio.Item("unidad", fila).Value)
        End If
        myCommand.CommandText = "Insert INTO inm_dpden Values (?codinm,?descrip,?espacio,?umedida);"
        myCommand.ExecuteNonQuery()
        Refresh()
    End Sub
End Class