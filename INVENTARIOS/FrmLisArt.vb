Public Class FrmLisArt

    Dim fil, j, i As Integer

    Private Sub FrmLisArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim t1 As String
        t1 = bda & ".articulos"
        myCommand.CommandText = "SELECT " & t1 & ".codart," & t1 & ".nomart," & t1 & ".referencia FROM " & t1 & " ORDER BY " & t1 & ".codart," & t1 & ".nomart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' gitems.DataSource = tabla
        gitems.RowCount = tabla.Rows.Count + 1
        j = 0
        For i As Integer = 0 To tabla.Rows.Count - 1
            If Len(tabla.Rows(i).Item("codart").ToString) <> 1 Then
                gitems.Item(0, j).Value = tabla.Rows(i).Item("codart")
                gitems.Item(2, j).Value = tabla.Rows(i).Item("nomart")
                gitems.Item(1, j).Value = tabla.Rows(i).Item("referencia")
                j = j + 1
            End If
        Next
        gitems.RowCount = tabla.Rows.Count - (i - j)
        fil = 0
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            If ct = 1 Then
                FrmInfartalf.txtci.Text = gitems.Item(1, fil).Value
                ct = 0
                Me.Close()
            Else
                If ct = 2 Then
                    FrmInfartalf.txtcf.Text = gitems.Item(1, fil).Value
                    ct = 0
                    Me.Close()
                Else
                    If ct = 10 Then
                        FrmInfoRef.txtci.Text = gitems.Item(1, fil).Value
                        ct = 0
                        Me.Close()
                    Else
                        If ct = 20 Then
                            FrmInfoRef.txtcf.Text = gitems.Item(1, fil).Value
                            ct = 0
                            Me.Close()
                        Else
                            If ct = 40 Then
                                FrmInfoExistencia.txtci.Text = gitems.Item(0, fil).Value
                                ct = 0
                                Me.Close()
                            Else
                                If ct = 50 Then
                                    FrmInfoExistencia.txtci.Text = gitems.Item(1, fil).Value
                                    ct = 0
                                    Me.Close()
                                Else
                                    If ct = 41 Then
                                        FrmInfoExistencia.txtcf.Text = gitems.Item(0, fil).Value
                                        ct = 0
                                        Me.Close()
                                    Else
                                        If ct = 51 Then
                                            FrmInfoExistencia.txtcf.Text = gitems.Item(1, fil).Value
                                            ct = 0
                                            Me.Close()
                                        Else
                                            If ct = 60 Then
                                                FrmInfoKardex.txtci.Text = gitems.Item(0, fil).Value
                                                ct = 0
                                                Me.Close()
                                            Else
                                                If ct = 61 Then
                                                    FrmInfoKardexref.txtci.Text = gitems.Item(1, fil).Value
                                                    ct = 0
                                                    Me.Close()
                                                Else
                                                    If ct = 62 Then
                                                        FrmInfoMovArt.txtci.Text = gitems.Item(0, fil).Value
                                                        ct = 0
                                                        Me.Close()
                                                    Else
                                                        If ct = 63 Then
                                                            FrmInfoMovRef.txtci.Text = gitems.Item(1, fil).Value
                                                            ct = 0
                                                            Me.Close()
                                                        Else
                                                            If ct = 64 Then
                                                                FrmInfoMovRef.txtcf.Text = gitems.Item(1, fil).Value
                                                                ct = 0
                                                                Me.Close()
                                                            Else
                                                                If ct = 80 Then
                                                                    FrmInvenDia.txtci.Text = gitems.Item(0, fil).Value
                                                                    ct = 0
                                                                    Me.Close()
                                                                Else
                                                                    If ct = 67 Then
                                                                        FrmInfoEntr.txtci.Text = gitems.Item(0, fil).Value
                                                                        ct = 0
                                                                        Me.Close()
                                                                    End If

                                                                    End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_CellEnter1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub

    Private Sub gitems_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gitems.DoubleClick
        Try
            If ct = 1 Then
                FrmInfartalf.txtci.Text = gitems.Item(0, fil).Value
                ct = 0
                Me.Close()
            Else
                If ct = 2 Then
                    FrmInfartalf.txtcf.Text = gitems.Item(0, fil).Value
                    ct = 0
                    Me.Close()
                Else
                    If ct = 10 Then
                        FrmInfoRef.txtci.Text = gitems.Item(1, fil).Value
                        ct = 0
                        Me.Close()
                    Else
                        If ct = 20 Then
                            FrmInfoRef.txtcf.Text = gitems.Item(1, fil).Value
                            ct = 0
                            Me.Close()
                        Else
                            If ct = 40 Then
                                FrmInfoExistencia.txtci.Text = gitems.Item(0, fil).Value
                                ct = 0
                                Me.Close()
                            Else
                                If ct = 50 Then
                                    FrmInfoExistencia.txtci.Text = gitems.Item(1, fil).Value
                                    ct = 0
                                    Me.Close()
                                Else
                                    If ct = 41 Then
                                        FrmInfoExistencia.txtcf.Text = gitems.Item(0, fil).Value
                                        ct = 0
                                        Me.Close()
                                    Else
                                        If ct = 51 Then
                                            FrmInfoExistencia.txtcf.Text = gitems.Item(1, fil).Value
                                            ct = 0
                                            Me.Close()
                                        Else
                                            If ct = 60 Then
                                                FrmInfoKardex.txtci.Text = gitems.Item(0, fil).Value
                                                ct = 0
                                                Me.Close()
                                            Else
                                                If ct = 61 Then
                                                    FrmInfoKardexref.txtci.Text = gitems.Item(1, fil).Value
                                                    ct = 0
                                                    Me.Close()
                                                Else
                                                    If ct = 62 Then
                                                        FrmInfoMovArt.txtci.Text = gitems.Item(0, fil).Value
                                                        ct = 0
                                                        Me.Close()
                                                    Else
                                                        If ct = 63 Then
                                                            FrmInfoMovRef.txtci.Text = gitems.Item(1, fil).Value
                                                            ct = 0
                                                            Me.Close()
                                                        Else
                                                            If ct = 64 Then
                                                                FrmInfoMovRef.txtcf.Text = gitems.Item(1, fil).Value
                                                                ct = 0
                                                                Me.Close()
                                                            Else
                                                                If ct = 80 Then
                                                                    FrmInvenDia.txtci.Text = gitems.Item(0, fil).Value
                                                                    ct = 0
                                                                    Me.Close()
                                                                Else
                                                                    If ct = 67 Then
                                                                        FrmInfoEntr.txtci.Text = gitems.Item(0, fil).Value
                                                                        ct = 0
                                                                        Me.Close()
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Try
                If ct = 1 Then
                    FrmInfartalf.txtci.Text = gitems.Item(0, fil - 1).Value
                    ct = 0
                    Me.Close()
                Else
                    If ct = 2 Then
                        FrmInfartalf.txtcf.Text = gitems.Item(0, fil - 1).Value
                        ct = 0
                        Me.Close()
                    Else
                        If ct = 10 Then
                            FrmInfoRef.txtci.Text = gitems.Item(1, fil - 1).Value
                            ct = 0
                            Me.Close()
                        Else
                            If ct = 20 Then
                                FrmInfoRef.txtcf.Text = gitems.Item(1, fil - 1).Value
                                ct = 0
                                Me.Close()
                            Else
                                If ct = 40 Then
                                    FrmInfoExistencia.txtci.Text = gitems.Item(0, fil - 1).Value
                                    ct = 0
                                    Me.Close()
                                Else
                                    If ct = 50 Then
                                        FrmInfoExistencia.txtci.Text = gitems.Item(1, fil - 1).Value
                                        ct = 0
                                        Me.Close()
                                    Else
                                        If ct = 41 Then
                                            FrmInfoExistencia.txtcf.Text = gitems.Item(0, fil - 1).Value
                                            ct = 0
                                            Me.Close()
                                        Else
                                            If ct = 51 Then
                                                FrmInfoExistencia.txtcf.Text = gitems.Item(1, fil - 1).Value
                                                ct = 0
                                                Me.Close()
                                            Else
                                                If ct = 60 Then
                                                    FrmInfoKardex.txtci.Text = gitems.Item(0, fil - 1).Value
                                                    ct = 0
                                                    Me.Close()
                                                Else
                                                    If ct = 61 Then
                                                        FrmInfoKardexref.txtci.Text = gitems.Item(1, fil - 1).Value
                                                        ct = 0
                                                        Me.Close()
                                                    Else
                                                        If ct = 62 Then
                                                            FrmInfoMovArt.txtci.Text = gitems.Item(0, fil - 1).Value
                                                            ct = 0
                                                            Me.Close()
                                                        Else
                                                            If ct = 63 Then
                                                                FrmInfoMovRef.txtci.Text = gitems.Item(1, fil - 1).Value
                                                                ct = 0
                                                                Me.Close()
                                                            Else
                                                                If ct = 64 Then
                                                                    FrmInfoMovRef.txtcf.Text = gitems.Item(1, fil - 1).Value
                                                                    ct = 0
                                                                    Me.Close()
                                                                Else
                                                                    If ct = 80 Then
                                                                        FrmInvenDia.txtci.Text = gitems.Item(0, fil - 1).Value
                                                                        ct = 0
                                                                        Me.Close()
                                                                    Else
                                                                        If ct = 67 Then
                                                                            FrmInfoEntr.txtci.Text = gitems.Item(0, fil - 1).Value
                                                                            ct = 0
                                                                            Me.Close()
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                Me.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class