Public Class FrmInmServicios

    Private Sub FrmInmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gservicios
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With

        cmbservicio.Text = "AGUA"
        gservicios.Rows.Clear()

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT * from inm_servicios WHERE codigo_inm='" & txtcod.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()

        If ta.Rows.Count > 0 Then
            gservicios.RowCount = ta.Rows.Count
            For i = 0 To ta.Rows.Count - 1
                gservicios.Item("item", i).Value = i + 1
                gservicios.Item("serv", i).Value = ta.Rows(i).Item("descrip")
                gservicios.Item("cod", i).Value = ta.Rows(i).Item("codigo")
                gservicios.Item("num", i).Value = ta.Rows(i).Item("numero")
                gservicios.Item("titular", i).Value = ta.Rows(i).Item("titular")
                gservicios.Item("obser", i).Value = ta.Rows(i).Item("observacion")
            Next
        End If

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gservicios.RowCount = gservicios.RowCount + 1
        gservicios.Item("item", gservicios.Rows.Count - 1).Value = gservicios.Rows.Count
        gservicios.Item("serv", gservicios.Rows.Count - 1).Value = cmbservicio.Text
        gservicios.CurrentCell = gservicios("serv", gservicios.Rows.Count - 1)
    End Sub
    Public filaS As Integer

    Private Sub gservicios_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gservicios.CellEndEdit
        Select Case e.ColumnIndex
            Case 2
                gservicios.Item("cod", e.RowIndex).Value = UCase(gservicios.Item("cod", e.RowIndex).Value)
            Case 4
                gservicios.Item("titular", e.RowIndex).Value = UCase(gservicios.Item("titular", e.RowIndex).Value)
            Case 5
                gservicios.Item("obser", e.RowIndex).Value = UCase(gservicios.Item("obser", e.RowIndex).Value)
        End Select
    End Sub
    Private Sub gservicios_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gservicios.CellEnter
        filaS = e.RowIndex
    End Sub
    Private Sub seleccionar(ByVal fila As Integer)
        If gservicios.Item("serv", fila).Value <> "" Then
            Frmdescrip_items.txtCod.Text = gservicios.Item("item", fila).Value
            Frmdescrip_items.lbform.Text = "inm_ser"
            Frmdescrip_items.ShowDialog()
            Frmdescrip_items.lbform.Text = ""
        End If
    End Sub

    Private Sub gservicios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gservicios.KeyDown
        Try
            If e.KeyCode = 8 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
                If resultado = MsgBoxResult.Yes Then
                    gservicios.Rows.RemoveAt(filaS)
                End If
            ElseIf e.KeyCode = "13" Then
                If gservicios.Item("serv", filaS).Value <> "OTROS" Then
                    MsgBox("No puede editar la descripcion de este servicio", MsgBoxStyle.Information, "Verificación")
                Else
                    seleccionar(filaS)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        gservicios.Rows.Clear()
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
       
        MiConexion(bda)
        Try

            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los Servicios del inmueble se van a guardar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then

                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "DELETE FROM inm_servicios WHERE codigo_inm='" & txtcod.Text & "';"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                End Try
                If gservicios.Rows.Count <> 0 Then
                    For i = 0 To gservicios.Rows.Count - 1
                        If gservicios.Item("serv", i).Value <> "" Then
                            guardar(i)
                        End If
                    Next
                End If

                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            End If
            'Else
            '    MsgBox("No ha creado ningun Servicio", MsgBoxStyle.Information, "Verificación")

        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
    Private Sub guardar(ByVal fila As Integer)

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codinm", txtcod.Text)
        myCommand.Parameters.AddWithValue("?nombre", gservicios.Item("serv", fila).Value)
        If gservicios.Item("cod", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?codigo", "")
        Else
            myCommand.Parameters.AddWithValue("?codigo", gservicios.Item("cod", fila).Value)
        End If
        If gservicios.Item("num", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?numero", "")
        Else
            myCommand.Parameters.AddWithValue("?numero", gservicios.Item("num", fila).Value)
        End If
        If gservicios.Item("titular", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?titular", "")
        Else
            myCommand.Parameters.AddWithValue("?titular", gservicios.Item("titular", fila).Value)
        End If
        If gservicios.Item("obser", fila).Value = vbNullString Then
            myCommand.Parameters.AddWithValue("?obser", "")
        Else
            myCommand.Parameters.AddWithValue("?obser", gservicios.Item("obser", fila).Value)
        End If
        myCommand.CommandText = "Insert INTO inm_servicios Values (?codinm,?nombre,?codigo,?numero,?titular,?obser);"
        myCommand.ExecuteNonQuery()
        Refresh()
    End Sub

   
End Class