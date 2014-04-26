Public Class FrmOtrosConceptosProv

    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        Select Case lbform.Text
            Case "frs"
                frs()
            Case "fr"
                fr()
            Case "fn"
                fn()
            Case "fn_sp"
                fn_sp()
            Case "fdp"
                'fdp()
                Nfdp()
        End Select
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    '*** COMBOS ****
    Private Sub cb1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cb2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cb3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cb3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '*** DESCRIPCION ****
    Private Sub txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '*** VALORES ****
    Private Sub valor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor1.KeyPress
        ValidarMoneda(valor1, e)
    End Sub
    Private Sub valor1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor1.LostFocus
        valor1.Text = Moneda(valor1.Text)
    End Sub
    Private Sub valor2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor2.KeyPress
        ValidarMoneda(valor2, e)
    End Sub
    Private Sub valor2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor2.LostFocus
        valor2.Text = Moneda(valor2.Text)
    End Sub
    Private Sub valor3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor3.KeyPress
        ValidarMoneda(valor3, e)
    End Sub
    Private Sub valor3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor3.LostFocus
        valor3.Text = Moneda(valor3.Text)
    End Sub
    '*** CUANTAS ****
    Private Sub cta1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cta1.KeyPress
        validarnumero(cta1, e)
    End Sub
    Private Sub cta1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cta1.LostFocus
        BuscarCuenta("concep_11")
    End Sub
    Private Sub cta2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cta2.KeyPress
        validarnumero(cta2, e)
    End Sub
    Private Sub cta2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cta2.LostFocus
        BuscarCuenta("concep_22")
    End Sub
    Private Sub cta3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cta3.KeyPress
        validarnumero(cta3, e)
    End Sub
    Private Sub cta3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cta3.LostFocus
        BuscarCuenta("concep_33")
    End Sub
    Public Sub BuscarCuenta(ByVal txt As String)
        Dim codigo As String
        If txt = "concep_11" Then
            codigo = Trim(cta1.Text)
        ElseIf txt = "concep_22" Then
            codigo = Trim(cta2.Text)
        Else
            codigo = Trim(cta3.Text)
        End If
        Try
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT codigo FROM selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                FrmCuentas.lbform.Text = txt
                Select Case txt
                    Case "concep_11"
                        cta1.Text = ""
                    Case "concep_22"
                        cta2.Text = ""
                    Case "concep_33"
                        cta3.Text = ""
                End Select
                FrmCuentas.txtcuenta.Text = codigo
                FrmCuentas.lbaux.Text = "auxiliar"
                FrmCuentas.ShowDialog()
            Else
                Select Case txt
                    Case "concep_11"
                        cta1.Text = tabla.Rows(0).Item("codigo")
                    Case "concep_22"
                        cta2.Text = tabla.Rows(0).Item("codigo")
                    Case "concep_33"
                        cta3.Text = tabla.Rows(0).Item("codigo")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    '* che *****************
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        If Ch1.Checked = False Then
            cb1.Enabled = False
            txt1.Enabled = False
            valor1.Enabled = False
            cta1.Enabled = False
            base1.Enabled = False
            txt1.Text = ""
            valor1.Text = "0,00"
            base1.Text = "0,00"
            cta1.Text = ""
            lbdoc1.Text = ""
            cmdanti1.Enabled = False
        Else
            cmdanti1.Enabled = True
            cb1.Enabled = True
            txt1.Enabled = True
            valor1.Enabled = True
            cta1.Enabled = True
            base1.Enabled = True
            Try
                cb1.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch2.CheckedChanged
        If Ch2.Checked = False Then
            cmdanti2.Enabled = False
            cb2.Enabled = False
            txt2.Enabled = False
            valor2.Enabled = False
            cta2.Enabled = False
            base2.Enabled = False
            txt2.Text = ""
            valor2.Text = "0,00"
            base2.Text = "0,00"
            cta2.Text = ""
            lbdoc2.Text = ""
        Else
            cmdanti2.Enabled = True
            cb2.Enabled = True
            txt2.Enabled = True
            valor2.Enabled = True
            base2.Enabled = True
            cta2.Enabled = True
            Try
                cb2.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Ch3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch3.CheckedChanged
        If Ch3.Checked = False Then
            cmdanti3.Enabled = False
            cb3.Enabled = False
            txt3.Enabled = False
            valor3.Enabled = False
            base3.Enabled = False
            cta3.Enabled = False
            txt3.Text = ""
            valor3.Text = "0,00"
            base3.Text = "0,00"
            cta3.Text = ""
            lbdoc3.Text = ""
        Else
            cmdanti3.Enabled = True
            cb3.Enabled = True
            txt3.Enabled = True
            valor3.Enabled = True
            base3.Enabled = True
            cta3.Enabled = True
            Try
                cb3.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub fr()
        Frmfacturarapida.cbconcepto.Items.Clear()
        Frmfacturarapida.cbsr.Items.Clear()
        Frmfacturarapida.cbvalor.Items.Clear()
        Frmfacturarapida.cbcuenta.Items.Clear()
        Frmfacturarapida.cbbase.Items.Clear()
        Frmfacturarapida.cbldoc.Items.Clear()
        Frmfacturarapida.lbanti1.Text = ""
        Frmfacturarapida.lbanti2.Text = ""
        Frmfacturarapida.lbanti3.Text = ""
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
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
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                Frmfacturarapida.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                Frmfacturarapida.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                Frmfacturarapida.cbvalor.Items.Add(Moneda2(grilla.Item("valor", i).Value, Frmfacturarapida.lb_imp_dec.Text))
                Frmfacturarapida.cbbase.Items.Add(Moneda2(grilla.Item("base", i).Value, Frmfacturarapida.lb_imp_dec.Text))
                Frmfacturarapida.cbcuenta.Items.Add(grilla.Item("cta", i).Value)
                Try
                    Frmfacturarapida.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    Frmfacturarapida.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub
    Private Sub frs()
        FrmFacturaEstetica.cbconcepto.Items.Clear()
        FrmFacturaEstetica.cbsr.Items.Clear()
        FrmFacturaEstetica.cbvalor.Items.Clear()
        FrmFacturaEstetica.cbcuenta.Items.Clear()
        FrmFacturaEstetica.cbbase.Items.Clear()
        FrmFacturaEstetica.cbldoc.Items.Clear()
        FrmFacturaEstetica.lbanti1.Text = ""
        FrmFacturaEstetica.lbanti2.Text = ""
        FrmFacturaEstetica.lbanti3.Text = ""
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
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
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmFacturaEstetica.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                FrmFacturaEstetica.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmFacturaEstetica.cbvalor.Items.Add(Moneda2(grilla.Item("valor", i).Value, FrmFacturaEstetica.lb_imp_dec.Text))
                FrmFacturaEstetica.cbbase.Items.Add(Moneda2(grilla.Item("base", i).Value, FrmFacturaEstetica.lb_imp_dec.Text))
                FrmFacturaEstetica.cbcuenta.Items.Add(grilla.Item("cta", i).Value)
                Try
                    FrmFacturaEstetica.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmFacturaEstetica.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub
    '*******************************
    Private Sub fn()
        FrmFacturasyAjustes.cbconcepto.Items.Clear()
        FrmFacturasyAjustes.cbsr.Items.Clear()
        FrmFacturasyAjustes.cbvalor.Items.Clear()
        FrmFacturasyAjustes.cbcuenta.Items.Clear()
        FrmFacturasyAjustes.cbbase.Items.Clear()
        FrmFacturasyAjustes.cbldoc.Items.Clear()
        FrmFacturasyAjustes.lbanti1.Text = ""
        FrmFacturasyAjustes.lbanti2.Text = ""
        FrmFacturasyAjustes.lbanti3.Text = ""
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
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
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmFacturasyAjustes.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                FrmFacturasyAjustes.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmFacturasyAjustes.cbvalor.Items.Add(Moneda2(grilla.Item("valor", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmFacturasyAjustes.cbbase.Items.Add(Moneda2(grilla.Item("base", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmFacturasyAjustes.cbcuenta.Items.Add(grilla.Item("cta", i).Value)
                Try
                    FrmFacturasyAjustes.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmFacturasyAjustes.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub
    Private Sub fn_sp()
        FrmFacturasyAjustesSP.cbconcepto.Items.Clear()
        FrmFacturasyAjustesSP.cbsr.Items.Clear()
        FrmFacturasyAjustesSP.cbvalor.Items.Clear()
        FrmFacturasyAjustesSP.cbcuenta.Items.Clear()
        FrmFacturasyAjustesSP.cbbase.Items.Clear()
        FrmFacturasyAjustesSP.cbldoc.Items.Clear()
        FrmFacturasyAjustesSP.lbanti1.Text = ""
        FrmFacturasyAjustesSP.lbanti2.Text = ""
        FrmFacturasyAjustesSP.lbanti3.Text = ""
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
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
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmFacturasyAjustesSP.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                FrmFacturasyAjustesSP.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmFacturasyAjustesSP.cbvalor.Items.Add(Moneda2(grilla.Item("valor", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmFacturasyAjustesSP.cbbase.Items.Add(Moneda2(grilla.Item("base", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmFacturasyAjustesSP.cbcuenta.Items.Add(grilla.Item("cta", i).Value)
                Try
                    FrmFacturasyAjustesSP.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmFacturasyAjustesSP.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub
    Public Sub Nfdp()

        FrmDocProveedor.cbconcepto.Items.Clear()
        FrmDocProveedor.cbsr.Items.Clear()
        FrmDocProveedor.cbvalor.Items.Clear()
        FrmDocProveedor.cbcuenta.Items.Clear()
        FrmDocProveedor.cbbase.Items.Clear()
        FrmDocProveedor.cbldoc.Items.Clear()
        FrmDocProveedor.lbanti1.Text = ""
        FrmDocProveedor.lbanti2.Text = ""
        FrmDocProveedor.lbanti3.Text = ""
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
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
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmDocProveedor.cbconcepto.Items.Add(grilla.Item("txt", i).Value)
                FrmDocProveedor.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmDocProveedor.cbvalor.Items.Add(Moneda2(grilla.Item("valor", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmDocProveedor.cbbase.Items.Add(Moneda2(grilla.Item("base", i).Value, FrmDocProveedor.lb_imp_dec.Text))
                FrmDocProveedor.cbcuenta.Items.Add(grilla.Item("cta", i).Value)
                Try
                    FrmDocProveedor.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmDocProveedor.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        'MsgBox("ok")
        Me.Close()
    End Sub
    Public Sub fdp()
        FrmDocProveedor.cbconcepto.Items.Clear()
        FrmDocProveedor.cbsr.Items.Clear()
        FrmDocProveedor.cbvalor.Items.Clear()
        FrmDocProveedor.cbcuenta.Items.Clear()
        FrmDocProveedor.cbbase.Items.Clear()
        FrmDocProveedor.lbanti1.Text = ""
        FrmDocProveedor.lbanti2.Text = ""
        FrmDocProveedor.lbanti3.Text = ""
        If Ch1.Checked = True Then
            If Trim(cb1.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb1.Focus()
                Exit Sub
            ElseIf Trim(txt1.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt1.Focus()
                Exit Sub
            ElseIf Moneda(valor1.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor1.Focus()
                Exit Sub
            ElseIf Trim(cta1.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta1.Focus()
                Exit Sub
            Else ' todo bien
                FrmDocProveedor.cbconcepto.Items.Add(txt1.Text)
                FrmDocProveedor.cbsr.Items.Add(cb1.Text)
                FrmDocProveedor.cbvalor.Items.Add(Moneda(valor1.Text))
                FrmDocProveedor.cbbase.Items.Add(Moneda(base1.Text))
                FrmDocProveedor.cbcuenta.Items.Add(cta1.Text)
                FrmDocProveedor.lbanti1.Text = lbdoc1.Text
            End If
        End If
        If Ch2.Checked = True Then
            If Trim(cb2.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb2.Focus()
                Exit Sub
            ElseIf Trim(txt2.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt2.Focus()
                Exit Sub
            ElseIf Moneda(valor2.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor2.Focus()
                Exit Sub
            ElseIf Trim(cta2.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta2.Focus()
                Exit Sub
            Else ' todo bien
                FrmDocProveedor.cbconcepto.Items.Add(txt2.Text)
                FrmDocProveedor.cbsr.Items.Add(cb2.Text)
                FrmDocProveedor.cbvalor.Items.Add(Moneda(valor2.Text))
                FrmDocProveedor.cbbase.Items.Add(Moneda(base2.Text))
                FrmDocProveedor.cbcuenta.Items.Add(cta2.Text)
                FrmDocProveedor.lbanti2.Text = lbdoc2.Text
            End If

        End If
        If Ch3.Checked = True Then
            If Trim(cb3.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb3.Focus()
                Exit Sub
            ElseIf Trim(txt3.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt3.Focus()
                Exit Sub
            ElseIf Moneda(valor3.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor3.Focus()
                Exit Sub
            ElseIf Trim(cta3.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta3.Focus()
                Exit Sub
            Else ' todo bien
                FrmDocProveedor.cbconcepto.Items.Add(txt3.Text)
                FrmDocProveedor.cbsr.Items.Add(cb3.Text)
                FrmDocProveedor.cbvalor.Items.Add(Moneda(valor3.Text))
                FrmDocProveedor.cbbase.Items.Add(Moneda(base3.Text))
                FrmDocProveedor.cbcuenta.Items.Add(cta3.Text)
                FrmDocProveedor.lbanti3.Text = lbdoc3.Text
            End If
       
        End If
        Me.Close()
    End Sub
    ' CONTORL DE LAS BASE
    Private Sub base1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles base1.KeyPress
        ValidarMoneda(base1, e)
    End Sub
    Private Sub base1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles base1.LostFocus
        base1.Text = Moneda(base1.Text)
    End Sub
    Private Sub base2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles base2.KeyPress
        ValidarMoneda(base2, e)
    End Sub
    Private Sub base2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles base2.LostFocus
        base2.Text = Moneda(base2.Text)
    End Sub
    Private Sub base3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles base3.KeyPress
        ValidarMoneda(base3, e)
    End Sub
    Private Sub base3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles base3.LostFocus
        base3.Text = Moneda(base3.Text)
    End Sub
    'anticipos
    Public Sub llenarGrilla()
        Dim nit As String = ""
        If lbform.Text = "fdp" Then
            nit = FrmDocProveedor.txtnitc.Text
        End If
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT *, (monto - causado) AS disp " _
            & "FROM ant_a_prov " _
            & "WHERE (monto - causado)>0 AND nitc='" & nit & "' " _
            & "ORDER BY fecha DESC;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmAntiProv.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmAntiProv.gitems.Item("doc", i).Value = tabla2.Rows(i).Item("per_doc")
                FrmAntiProv.gitems.Item("fecha", i).Value = CambiaCadena(tabla2.Rows(i).Item("fecha").ToString, 10)
                FrmAntiProv.gitems.Item("total", i).Value = Moneda(tabla2.Rows(i).Item("monto").ToString)
                FrmAntiProv.gitems.Item("disponible", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                FrmAntiProv.gitems.Item("monto", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                FrmAntiProv.gitems.Item("cta", i).Value = tabla2.Rows(i).Item("cta").ToString
                FrmAntiProv.gitems.Item("detalle", i).Value = tabla2.Rows(i).Item("concepto").ToString
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdanti1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti1.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = "otcon"
            FrmAntiProv.lbfila.Text = "1"
            FrmAntiProv.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti2.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = "otcon"
            FrmAntiProv.lbfila.Text = "2"
            FrmAntiProv.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti3.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = "otcon"
            FrmAntiProv.lbfila.Text = "3"
            FrmAntiProv.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpuestos.Click

        'SendKeys.Send(Chr(Keys.Space))
        'FrmSelConcepImp.lbform.Text = "ComIng"
        'FrmSelConcepImp.lbfila.Text = fila
        'If fila = grilla.RowCount - 1 Then
        '    grilla.RowCount = grilla.RowCount + 1
        'End If
        'Dim fila As String = ""
        'If Ch1.Checked = True And valor1.Text = Moneda(0) Then
        '    fila = "1"
        'ElseIf Ch2.Checked = True And valor2.Text = Moneda(0) Then
        '    fila = "2"
        'ElseIf Ch3.Checked = True And valor3.Text = Moneda(0) Then
        '    fila = "3"
        'End If

        'If fila <> "" Then
        SendKeys.Send(Chr(Keys.Space))
        FrmSelConcepImp.lbform.Text = "OtrosCP"
        FrmSelConcepImp.lbfila.Text = fila
        If fila = grilla.RowCount - 1 Then
            grilla.RowCount = grilla.RowCount + 1
        End If
        FrmSelConcepImp.ShowDialog()
        'Else
        'MsgBox("Verifique el campo seleccionado", MsgBoxStyle.Information, "Verificacion")
        'End If
        
    End Sub

    Private Sub grilla_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellClick
        Try
            Select Case e.ColumnIndex
                Case 7 'CASO ANTICIPO   
                    BusAnticipo(e.RowIndex, e.ColumnIndex)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BusAnticipo(ByVal fl As Integer, ByVal cl As Integer)
        llenarGrilla()
        FrmAntiProv.lbform.Text = "Gotcon"
        FrmAntiProv.lbfila.Text = fl
        FrmAntiProv.ShowDialog()
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

    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If Trim(cuenta) = "" Then
            FrmCuentas.lbform.Text = "OConProv"
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
                FrmCuentas.lbform.Text = "OConProv"
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

    Public fila As Integer

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub

    Private Sub FrmOtrosConceptosProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim C As Integer = 3, F As Integer = 0
        grilla.CurrentCell = grilla(C, F)
        grilla.Focus()
    End Sub
End Class