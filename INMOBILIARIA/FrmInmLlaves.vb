Public Class FrmInmLlaves

    Private Sub FrmInmLlaves_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With grilla
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With

        cmbsitio.Text = "ALCOBA"
        grilla.Rows.Clear()

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT * from inm_llaves WHERE codigo_inm='" & txtcod.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()

        If ta.Rows.Count > 0 Then
            grilla.RowCount = ta.Rows.Count
            For i = 0 To ta.Rows.Count - 1
                grilla.Item("item", i).Value = i + 1
                grilla.Item("sitio", i).Value = ta.Rows(i).Item("sitio")
                grilla.Item("cant", i).Value = ta.Rows(i).Item("cant")
                grilla.Item("marca", i).Value = ta.Rows(i).Item("marca")
            Next
        End If
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        grilla.Rows.Clear()
    End Sub

    Private Sub crear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crear.Click
        grilla.RowCount = grilla.RowCount + 1
        grilla.Item("item", grilla.Rows.Count - 1).Value = grilla.Rows.Count
        grilla.Item("sitio", grilla.Rows.Count - 1).Value = cmbsitio.Text
        grilla.CurrentCell = grilla("sitio", grilla.Rows.Count - 1)
    End Sub
    Public fila As Integer
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Select Case e.ColumnIndex
            Case 3
                grilla.Item("marca", e.RowIndex).Value = UCase(grilla.Item("marca", e.RowIndex).Value)
        End Select
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
    End Sub
    Private Sub seleccionar(ByVal fila As Integer)
        If grilla.Item("sitio", fila).Value <> "" Then
            Frmdescrip_items.txtCod.Text = grilla.Item("item", fila).Value
            Frmdescrip_items.lbform.Text = "inm_sitio"
            Frmdescrip_items.ShowDialog()
            Frmdescrip_items.lbform.Text = ""
        End If
    End Sub

    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        Try
            If e.KeyCode = 8 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
                If resultado = MsgBoxResult.Yes Then
                    grilla.Rows.RemoveAt(fila)
                End If
            ElseIf e.KeyCode = "13" Then
                seleccionar(fila)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        MiConexion(bda)
        Try
            If grilla.Rows.Count <> 0 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Las llaves del inmueble se van a guardar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then

                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "DELETE FROM inm_llaves WHERE codigo_inm='" & txtcod.Text & "';"
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Dim can As Integer = 0
                    For i = 0 To grilla.Rows.Count - 1
                        If grilla.Item("sitio", i).Value <> "" And grilla.Item("cant", i).Value <> vbNullString Then
                            guardar(i)
                            can = can + CInt(grilla.Item("cant", i).Value)
                        End If
                        'ACTUALIZAR NUMERO DE LLAVES
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "UPDATE inmuebles set llaves = " & can & " WHERE codigo='" & txtcod.Text & "';"
                        myCommand.ExecuteNonQuery()
                        txtllaves.Text = can
                        FrmInmueble.txtllaves.Text = can

                    Next
                    MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                End If
            Else
                MsgBox("No ha creado ningun Servicio", MsgBoxStyle.Information, "Verificación")
            End If
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub guardar(ByVal fila As Integer)

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codinm", txtcod.Text)
        myCommand.Parameters.AddWithValue("?nombre", grilla.Item("sitio", fila).Value)
        If grilla.Item("cant", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?cant", Val(0))
        Else
            myCommand.Parameters.AddWithValue("?cant", Val(grilla.Item("cant", fila).Value))
        End If
        If grilla.Item("marca", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?marca", "")
        Else
            myCommand.Parameters.AddWithValue("?marca", grilla.Item("marca", fila).Value)
        End If
       
        myCommand.CommandText = "Insert INTO inm_llaves Values (?codinm,?nombre,?cant,?marca);"
        myCommand.ExecuteNonQuery()
        Refresh()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class