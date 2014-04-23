Public Class FrmCamCodart

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub


    Private Sub txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub txttip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttip.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txttip_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.LostFocus
        Try
            If Trim(txttip.Text) = "" Then
            Else
                Dim tabla As DataTable
                myCommand.CommandText = "select * from articulos where codart='" & txttip.Text & "' and nivel = 'Articulo' "
                myAdapter.SelectCommand = myCommand
                tabla = New DataTable
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    txtnom.Text = ""
                Else
                    txtnom.Text = tabla.Rows(0).Item("nomart")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttip_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txttip.MouseDoubleClick
        FrmLisArticulos.lbform.Text = "Cam_Art"
        FrmLisArticulos.ShowDialog()
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged

    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        MiConexion(bda)

        Dim n As String = ""
        Dim it As String = ""
        Dim c As String = ""
        Dim tb As String = ""
        Dim p As String = ""

        Dim sql As String = ""

        Dim resultado As MsgBoxResult

        If txtnom.Text = "" Then
            MsgBox("Verifique que el codigo digitado pertenezca a un Articulo")
        Else
            If txtNcod.Text = "" Then
                MsgBox("Digite el nuevo codigo")
            Else

                Dim tabla As DataTable
                myCommand.CommandText = "select * from articulos where codart='" & txtNcod.Text & "' "
                myAdapter.SelectCommand = myCommand
                tabla = New DataTable
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <> 0 Then
                    MsgBox("El codigo ya existe, Intentelo nuevamente ")
                    txtNcod.Text = ""
                Else

                    resultado = MsgBox("El codigo del Articulo será modificado, ¿Realmente desea modificarlo?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.No Then
                        Me.Close()
                    Else

                        For i = 1 To 12
                            If i < 10 Then
                                p = "0" & i
                            Else
                                p = i
                            End If

                            Try
                                myCommand.CommandText = "UPDATE  detafac" & p & " " _
                                       & " SET codart ='" & txtNcod.Text & "'" _
                                       & " WHERE codart='" & txttip.Text & "' " _
                                       & " AND tipo_it = 'I' "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                            Try
                                myCommand.CommandText = "UPDATE  deta_mov" & p & " " _
                                     & " SET codart ='" & txtNcod.Text & "'" _
                                     & " WHERE codart='" & txttip.Text & "' "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                            Try
                                myCommand.CommandText = "UPDATE  detacomp" & p & " " _
                                      & " SET cod_art ='" & txtNcod.Text & "' " _
                                      & " WHERE cod_art='" & txttip.Text & "' " _
                                      & " AND tipo_it = 'I' "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try

                        Next


                        myCommand.CommandText = "UPDATE articulos a " _
                                                & " SET a.codart ='" & txtNcod.Text & "'  " _
                                                & " WHERE a.codart ='" & txttip.Text & "'   "
                        myCommand.ExecuteNonQuery()

                        myCommand.CommandText = "UPDATE con_inv c " _
                                                & " SET  c.codart ='" & txtNcod.Text & "' " _
                                                & " WHERE c.codart ='" & txttip.Text & "'  "
                        myCommand.ExecuteNonQuery()

                        Try
                            myCommand.CommandText = "UPDATE  fapipen f  " _
                                               & " SET f.codart ='" & txtNcod.Text & "'" _
                                               & " WHERE f.codart='" & txttip.Text & "' " _
                                               & " AND f.tipo = 'I' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        If FrmPrincipal.cmdAuditoria.Visible = True Then
                            Guar_MovUser("INVENTARIO", "CAMBIAR CODIGO AL ARTICULO " & txtnom.Text, "CODIGO", txttip.Text, txtNcod.Text)
                        End If

                        MsgBox("El cambio se realizo exitosamente ", MsgBoxStyle.Information, "SAE")
                        Limpiar()
                    End If
                End If
            End If
        End If
        Cerrar()
    End Sub

    Private Sub FrmCamCodart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub Limpiar()
        txtNcod.Text = ""
        txtnom.Text = ""
        txttip.Text = ""
    End Sub
End Class