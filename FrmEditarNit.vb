Public Class FrmEditarNit

    Private Sub FrmEditarNit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNitA.Text = frmterceros.txtnit.Text
        txtNitN.Text = txtNitA.Text
        txtNitN.Focus()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Dim resultado As MsgBoxResult
        Dim p As String = ""

        MiConexion(bda)

        If txtNitN.Text = "" Then
            MsgBox("Debe digitar un valor")
        Else

            Dim tabla As DataTable
            myCommand.CommandText = "select * from terceros where nit='" & txtNitN.Text & "' "
            myAdapter.SelectCommand = myCommand
            tabla = New DataTable
            myAdapter.Fill(tabla)

            If tabla.Rows.Count <> 0 Then
                MsgBox("Este Numero de identificacion ya se encuentra registrado")
                txtNitN.Text = ""
            Else
                resultado = MsgBox("El nit será modificado, ¿Realmente desea modificarlo?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.No Then
                    Me.Close()
                Else
                    MsgBox("Este proceso puede tardar unos minutos", MsgBoxStyle.Exclamation, "SAE")
                    Try
                        myCommand.CommandText = "UPDATE  cobdpen " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  ctas_x_pagar " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  fapipen " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  lista_cliente " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  parafacts " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  pedi_comp " _
                             & " SET nitc ='" & txtNitN.Text & "'" _
                             & " WHERE nitc='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  temp_terceros " _
                             & " SET nit ='" & txtNitN.Text & "', dv = '" & LABELDV.Text & "'" _
                             & " WHERE nit='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                    Try
                        myCommand.CommandText = "UPDATE  terceros " _
                             & " SET nit ='" & txtNitN.Text & "' , dv = '" & LABELDV.Text & "' " _
                             & " WHERE nit='" & txtNitA.Text & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try


                    For i = 1 To 12
                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If

                        Try
                            myCommand.CommandText = "UPDATE  documentos" & p & " " _
                                  & " SET nit ='" & txtNitN.Text & "'" _
                                  & " WHERE nit='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  facturas" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  fact_comp" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  movimientos" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  ot_cpc" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  ot_cpp" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  ot_doc" & p & " " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        ':::::::::::: SI INMOBILIRIARIA
                        If FrmPrincipal.inmobiliaria.Visible = True Then
                            Try
                                myCommand.CommandText = "UPDATE  facturainm" & p & " " _
                                      & " SET nita ='" & txtNitN.Text & "'" _
                                      & " WHERE nita='" & txtNitA.Text & "' "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try
                            Try
                                myCommand.CommandText = "UPDATE  facturainm" & p & " " _
                                      & " SET nitp ='" & txtNitN.Text & "'" _
                                      & " WHERE nitp='" & txtNitA.Text & "' "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                            End Try
                        End If

                    Next

                    ':::::::::::: SI INMOBILIRIARIA
                    If FrmPrincipal.inmobiliaria.Visible = True Then
                        Try
                            myCommand.CommandText = "UPDATE  contrato_inm " _
                                  & " SET nit_a ='" & txtNitN.Text & "'" _
                                  & " WHERE nit_a='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  contrato_inm " _
                                  & " SET nit_d ='" & txtNitN.Text & "'" _
                                  & " WHERE nit_d='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                        Try
                            myCommand.CommandText = "UPDATE  contrato_inm " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  inmuebles " _
                                  & " SET nitp ='" & txtNitN.Text & "'" _
                                  & " WHERE nitp='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  inmuebles " _
                                  & " SET nitp ='" & txtNitN.Text & "'" _
                                  & " WHERE nitp='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  inm_novdad " _
                                  & " SET nita ='" & txtNitN.Text & "'" _
                                  & " WHERE nita='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  inm_novdad " _
                                  & " SET nitp ='" & txtNitN.Text & "'" _
                                  & " WHERE nitp='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  otcon_contrato " _
                                  & " SET nitc ='" & txtNitN.Text & "'" _
                                  & " WHERE nitc='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Try
                            myCommand.CommandText = "UPDATE  tercerosinm " _
                                  & " SET nit ='" & txtNitN.Text & "'" _
                                  & " WHERE nit='" & txtNitA.Text & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                    End If

                    MsgBox("El proceso se realizó con exito", MsgBoxStyle.Information, "SAE")
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub txtNitN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNitN.KeyPress
        ValidarNIT(txtNitN, e)
    End Sub

    
    Private Sub txtNitN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNitN.TextChanged
        LABELDV.Text = DigitoNIT(txtNitN.Text)
    End Sub
End Class