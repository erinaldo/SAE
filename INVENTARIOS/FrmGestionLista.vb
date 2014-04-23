Imports MySql.Data.MySqlClient
Public Class FrmGestionLista
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text <> "NUEVO" Then
            If VerificarCantidad() = False Then Exit Sub
            txtnum.Text = ""
            txtnombre.Text = ""
            lbestado.Text = "NUEVO"
            txtnombre.Focus()
        End If
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        End If
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            txtnum.Text = ""
            txtnombre.Text = ""
            lbestado.Text = "NULO"
        End If
    End Sub
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If lbestado.Text = "CONSULTA" Or lbestado.Text = "EDITADO" Or lbestado.Text = "GUARDADO" Then
            lbestado.Text = "EDITAR"
            txtnombre.Focus()
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click

        Try
            MiConexion(bda)
            Dim tabla As New DataTable
            If lbform.Text = "BODEGAS" Then

                myCommand.CommandText = "select sum(cant" & txtnum.Text & ") from con_inv;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0).Item(0) <= 0 Then
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "DELETE FROM  bodegas WHERE  `bodegas`.`numbod` = '" & txtnum.Text & "' ;"
                        myCommand.ExecuteNonQuery()
                        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                    Else
                        MsgBox("La bodega no se puede eliminar", MsgBoxStyle.Information)
                    End If
                End If
            Else
                myCommand.CommandText = "select sum(precio" & txtnum.Text & ") from con_inv;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()

                If tabla.Rows.Count > 0 Then
                    If tabla.Rows(0).Item(0) <= 0 Then
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "DELETE FROM  listasprec WHERE  `listasprec`.`numlist` = '" & txtnum.Text & "' ;"
                        myCommand.ExecuteNonQuery()
                        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                    Else
                        MsgBox("La lista de precio no se puede eliminar", MsgBoxStyle.Information)
                    End If
                End If
            End If

            lbestado.Text = "EDITADO"
            txtnum.Text = ""
            txtnombre.Text = ""
            Actualizar()
            Cerrar()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmGestionLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        If lbform.Text = "BODEGAS" Then
            lbtope.Text = "* Solo puede crear 30 bodegas."
        Else
            lbtope.Text = "* Solo puede crear 6 listas de precios."
        End If
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Try
            If gitems.Item(0, e.RowIndex).Value <> 0 Then
                txtnum.Text = gitems.Item(0, e.RowIndex).Value
                txtnombre.Text = gitems.Item(1, e.RowIndex).Value
                lbestado.Text = "CONSULTA"
                lbnroobs.Text = e.RowIndex + 1
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub Guardar()
        MiConexion(bda)
        Dim i As Integer = 0
        Dim tb As New DataTable

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
        If lbform.Text = "BODEGAS" Then
            myCommand.CommandText = "select count(*) From bodegas;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            i = tb.Rows.Count - 1
            myCommand.Parameters.AddWithValue("?bod", tb.Rows(i).Item(0) + 1)
            myCommand.CommandText = "INSERT INTO bodegas (numbod,nombod) VALUES (?bod,?nombre);"
            tb.Clear()
        Else
            myCommand.CommandText = "select count(*) From listasprec;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            i = tb.Rows.Count - 1
            myCommand.Parameters.AddWithValue("?lis", tb.Rows(i).Item(0) + 1)
            myCommand.CommandText = "INSERT INTO listasprec (numlist,nomlist) VALUES (?lis,?nombre);"
            tb.Clear()
        End If
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "GUARDADO"
        Actualizar()
        txtnum.Text = gitems.Rows.Count - 1
        lbnroobs.Text = gitems.Rows.Count - 1
        Cerrar()
    End Sub
    Public Sub Modificar()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
        If lbform.Text = "BODEGAS" Then
            myCommand.CommandText = "UPDATE bodegas SET nombod=?nombre WHERE numbod=" & txtnum.Text & ";"
        Else
            myCommand.CommandText = "UPDATE listasprec SET nomlist=?nombre WHERE numlist=" & txtnum.Text & ";"
        End If
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "EDITADO"
        Actualizar()
        Cerrar()
    End Sub
    Public Sub Actualizar()
        Dim tabla As New DataTable
        Dim items As Integer
        If lbform.Text = "BODEGAS" Then
            myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
        Else
            myCommand.CommandText = "SELECT * FROM listasprec ORDER BY numlist;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = tabla.Rows(i).Item(0)
            gitems.Item(1, i).Value = tabla.Rows(i).Item(1)
        Next
        txtnum.Text = ""
        txtnombre.Text = ""
    End Sub
    Function VerificarCantidad()
        Dim tabla As New DataTable
        If lbform.Text = "BODEGAS" Then
            myCommand.CommandText = "SELECT count(*) FROM bodegas;"
        Else
            myCommand.CommandText = "SELECT count(*) FROM listasprec;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If lbform.Text = "BODEGAS" Then
            If tabla.Rows(0).Item(0) >= 30 Then
                MsgBox("Solo Puede Crear 30 Bodegas.   ", MsgBoxStyle.Information, "SAE Control")
                Return False
            Else
                Return True
            End If
        Else
            If tabla.Rows(0).Item(0) >= 6 Then
                MsgBox("Solo Puede Crear 6 Listas de Precios.   ", MsgBoxStyle.Information, "SAE Control")
                Return False
            Else
                Return True
            End If
        End If
    End Function
End Class