Public Class FrmOtrosccInm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmOtrosccInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim C As Integer = 3, F As Integer = 0
        grilla.CurrentCell = grilla(C, F)
        grilla.Focus()
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub
    Public fila As Integer

    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        Try
            Select Case e.ColumnIndex
                Case 1
                    If fila <> 0 Then
                        If e.RowIndex > 0 And grilla.Item("tipo", e.RowIndex - 1).Value = "+" Then
                            valoresDefecto(e.RowIndex)
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub valoresDefecto(ByVal i)
        grilla.Item("num", i).Value = i + 1
        grilla.Item("sel", i).Value = True
        grilla.Item("tipo", i).Value = "-"
        grilla.Item("txt", i).Value = grilla.Item("txt", i - 1).Value
        grilla.Item("valor", i).Value = Moneda(grilla.Item("valor", i - 1).Value)
        grilla.Item("base", i).Value = grilla.Item("base", i - 1).Value
        grilla.Item("afecta", i).Value = grilla.Item("afecta", i - 1).Value
        'grilla.Item("cont", i).Value = True
        grilla.Item("cont2", i).Value = "SOLO CONTB"
    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Select Case e.ColumnIndex
            Case 3
                'If grilla.Item(2, e.RowIndex).Value = "" Then
                '    MsgBox("Verifique el signo", MsgBoxStyle.Information, "Verificacion")
                '    grilla.Item(2, e.RowIndex).Value = "+"
                'End If
                grilla.Item(3, e.RowIndex).Value = UCase(grilla.Item(3, e.RowIndex).Value)
                Try
                    grilla.Item(4, e.RowIndex).Value = Moneda(grilla.Item(4, e.RowIndex).Value)
                Catch ex As Exception
                    grilla.Item(4, e.RowIndex).Value = Moneda(0)
                End Try
                Try
                    grilla.Item(5, e.RowIndex).Value = Moneda(grilla.Item(5, e.RowIndex).Value)
                Catch ex As Exception
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                End Try
            Case 4
                Try
                    grilla.Item(4, e.RowIndex).Value = Moneda(grilla.Item(4, e.RowIndex).Value)
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                Catch ex As Exception
                    grilla.Item(4, e.RowIndex).Value = Moneda(0)
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                End Try
            Case 5
                Try
                    grilla.Item(5, e.RowIndex).Value = Moneda(grilla.Item(5, e.RowIndex).Value)
                Catch ex As Exception
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                End Try
            Case 6
                Buscarcuentas(grilla.Item(6, e.RowIndex).Value, e.RowIndex)
        End Select
    End Sub

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        End If
    End Sub
    Function nivel_cuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & codigo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If Trim(cuenta) = "" Then
            FrmCuentas.lbform.Text = "OConInm"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                'If Trim(grilla.Item(3, fila).Value) = "" Or nivel_cuenta(grilla.Item(3, fila).Value) = True Then
                grilla.Item(3, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "OConInm"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
                'Else
                '    SendKeys.Send(Chr(Keys.Tab))
                '    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                '    resultado = MsgBox("La cuenta (" & grilla.Item(3, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                '    If resultado = MsgBoxResult.Yes Then
                '        FrmNuevaCuenta.txtcuenta.Text = grilla.Item(3, fila).Value
                '        grilla.Item(3, fila).Value = ""
                '        FrmNuevaCuenta.lbfila.Text = fila
                '        FrmNuevaCuenta.ShowDialog()
                '    Else
                '        grilla.Item(3, fila).Value = ""
                '    End If
            End If
            '    Else
            '    grilla.Item(7, fila).Selected = True
            'End If
        End If

    End Sub
    Private Sub ConInm()
        FrmContratos.cbconcepto.Items.Clear()
        FrmContratos.cbsr.Items.Clear()
        FrmContratos.cbvalor.Items.Clear()
        FrmContratos.cbcta.Items.Clear()
        FrmContratos.cbbase.Items.Clear()
        FrmContratos.cbtcli.Items.Clear()
        FrmContratos.cbCont.Items.Clear()
        FrmContratos.cbDia.Items.Clear()
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len( FrmContratos.lbanti3.Text))
                If grilla.Item("tipo", i).Value = "" Then
                    MsgBox("Verifique si el concepto suma o resta, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf Trim(grilla.Item("txt", i).Value) = "" Then
                    MsgBox("Verifique la descripcion del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("valor", i).Value = "0,00" Or grilla.Item("valor", i).Value = "" Then
                    MsgBox("Verifique el valor, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("cta", i).Value = "" Then
                    MsgBox("Verifique la cuenta del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("afecta", i).Value = "" Then
                    MsgBox("Verifique a quien afecta este valor, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("cont2", i).Value = "" Then
                    MsgBox("Verifique que tipo de movimiento es, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("dia", i).Value = "" Then
                    MsgBox("Verifique si el valor varia segun los dias facturados, En la fila " & i + 1, MsgBoxStyle.Exclamation, "SAE Control")
                    Exit Sub
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmContratos.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                FrmContratos.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmContratos.cbvalor.Items.Add(Moneda(grilla.Item("valor", i).Value))
                FrmContratos.cbbase.Items.Add(Moneda(grilla.Item("base", i).Value))
                FrmContratos.cbcta.Items.Add(grilla.Item("cta", i).Value)
                FrmContratos.cbtcli.Items.Add(grilla.Item("afecta", i).Value)
                FrmContratos.cbDia.Items.Add(grilla.Item("dia", i).Value)
                'If grilla.Item("cont", i).Value = True Then
                '    FrmContratos.cbCont.Items.Add("S")
                'Else
                '    FrmContratos.cbCont.Items.Add("N")
                'End If
                If grilla.Item("cont2", i).Value = "SOLO CONTB" Then
                    FrmContratos.cbCont.Items.Add("S")
                ElseIf grilla.Item("cont2", i).Value = "CONT-FACT" Then
                    FrmContratos.cbCont.Items.Add("D")
                ElseIf grilla.Item("cont2", i).Value = "SOLO FACT" Then
                    FrmContratos.cbCont.Items.Add("N")
                End If
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub

    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
         Select lbform.Text
            Case "cont"
                ConInm()
        End Select
    End Sub
End Class