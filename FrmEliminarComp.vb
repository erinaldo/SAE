Imports MySql.Data.MySqlClient

Public Class FrmEliminarComp
    Dim conexion As New MySqlConnection
    Public fil As Integer
    Private Sub FrmAbrirCompania_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MostrarCompaniaParaEliminar()
        gitems.Focus()
    End Sub
    Private Sub FrmAbrirCompania_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        gitems.Focus()
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Seleccionar(e.RowIndex)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Seleccionar(fil - 1)
        End If
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Seleccionar(fil)
    End Sub

    Public Sub Seleccionar(ByVal fila As Integer)
        If fila < 0 Then Exit Sub
        If gitems.Item(1, fila).Value = "" Then Exit Sub
        'FrmPass.txtcompania.Text = gitems.Item(0, fila).Value
        'LbPass.Text = ""
        'FrmPass.txtpasswC.Text = ""
        'FrmPass.ShowDialog()
        ElimCompa(gitems.Item(0, fila).Value, fila)
    End Sub
    Public Sub ElimCompa(ByVal compa As String, ByVal num As Integer)

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & compa & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        Dim resultado As MsgBoxResult
        resultado = MsgBox("¿ Realmente desea eliminar la compañia (" & compa & ") ?", MsgBoxStyle.YesNo, "SAE verificando")
        If resultado = MsgBoxResult.Yes Then
            resultado = MsgBox("¿ Este proceso es IRREVERSIBLE, Esta seguro que desea eliminar la compañia (" & compa & ") ?", MsgBoxStyle.YesNo, "SAE verificando")
            If resultado = MsgBoxResult.Yes Then

                Try
                    conexion.ConnectionString = datosconR(bda)
                    conexion.Open()

                    Lbesperar.Visible = True

                    '.... ELIMINAR BD
                    compa = "frutos"
                    Dim c As String = ""
                    Dim tablaa As New DataTable
                    myCommand.CommandText = "SHOW DATABASES LIKE 'sae" & compa & "%' "
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tablaa)
                    Refresh()
                    If tablaa.Rows.Count > 0 Then
                        For i = 0 To tablaa.Rows.Count - 1
                            c = Strings.Right(tablaa.Rows(i).Item(0), 4)
                            Try
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = " DROP DATABASE sae" & compa & c & " ;"
                                myCommand.Connection = conexion
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try
                        Next
                    End If

                    '.... ELIMINAR DE PERIODOS
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = " DELETE FROM sae.periodos WHERE codigo = " & gitems.Item(3, num).Value & "; "
                        myCommand.Connection = conexion
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    '.... ELIMINAR DE COMPAÑIA
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = " DELETE FROM sae.companias WHERE codigo = " & gitems.Item(3, num).Value & "; "
                        myCommand.Connection = conexion
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    conexion.Close()
                    Cerrar()
                    MsgBox("El proceso se realizo satisfactoriamente", MsgBoxStyle.Information, "SAE")
                    Lbesperar.Visible = False
                    MostrarCompaniaParaEliminar()
                    If compa = FrmPrincipal.lbcompania.Text Then
                        End
                    End If
                Catch ex As Exception
                    Lbesperar.Visible = False
                    MsgBox("Error al eliminar la compañia , " & ex.ToString, MsgBoxStyle.Information, "Error")
                End Try

            End If
        End If
       
    End Sub

    Public Sub MostrarCompaniaParaEliminar()

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT c.*, p.periodo FROM sae.companias c, sae.periodos p where p.codigo=c.codigo ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <= 0 Then
            MsgBox("No hay compañias creadas, verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        gitems.Rows.Clear()
        gitems.RowCount = tabla.Rows.Count
        For i = 0 To tabla.Rows.Count - 1
            If UCase(tabla.Rows(i).Item("login")) = UCase(CompaniaActual) Then
                txtlogin.Text = UCase(CompaniaActual)
                txtcompania.Text = tabla.Rows(i).Item("descripcion")
                txtnit.Text = tabla.Rows(i).Item("nit")
                BuscarPeriodo()
                txtperiodo.Text = PerActual
            End If
            gitems.Item(0, i).Value = tabla.Rows(i).Item("login")
            gitems.Item(1, i).Value = UCase(tabla.Rows(i).Item("descripcion"))
            gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
            gitems.Item(3, i).Value = tabla.Rows(i).Item("codigo")
            gitems.Item(4, i).Value = tabla.Rows(i).Item("periodo")

        Next
    End Sub

End Class