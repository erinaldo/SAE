Public Class FrmOtrosConceptos

    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        Select Case lbform.Text
            Case "fr"
                fr()
            Case "fn"
                fn()
            Case "fdp"
                fdp()
            Case "cont"
                cont()
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
        BuscarCuenta("concep_1")
    End Sub
    Private Sub cta2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cta2.KeyPress
        validarnumero(cta2, e)
    End Sub
    Private Sub cta2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cta2.LostFocus
        BuscarCuenta("concep_2")
    End Sub
    Private Sub cta3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cta3.KeyPress
        validarnumero(cta3, e)
    End Sub
    Private Sub cta3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cta3.LostFocus
        BuscarCuenta("concep_3")
    End Sub
    Public Sub BuscarCuenta(ByVal txt As String)
        Dim codigo As String
        If txt = "concep_1" Then
            codigo = Trim(cta1.Text)
        ElseIf txt = "concep_2" Then
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
                    Case "concep_1"
                        cta1.Text = ""
                    Case "concep_2"
                        cta2.Text = ""
                    Case "concep_3"
                        cta3.Text = ""
                End Select
                FrmCuentas.txtcuenta.Text = codigo
                FrmCuentas.lbaux.Text = "auxiliar"
                FrmCuentas.ShowDialog()
            Else
                Select Case txt
                    Case "concep_1"
                        cta1.Text = tabla.Rows(0).Item("codigo")
                    Case "concep_2"
                        cta2.Text = tabla.Rows(0).Item("codigo")
                    Case "concep_3"
                        cta3.Text = tabla.Rows(0).Item("codigo")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    '* che *****************
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        If Ch1.Checked = False Then
            cmdanti1.Enabled = False
            cb1.Enabled = False
            txt1.Enabled = False
            valor1.Enabled = False
            cta1.Enabled = False
            txt1.Text = ""
            valor1.Text = "0,00"
            cta1.Text = ""
            lbdoc1.Text = ""
        Else
            cmdanti1.Enabled = True
            cb1.Enabled = True
            txt1.Enabled = True
            valor1.Enabled = True
            cta1.Enabled = True
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
            txt2.Text = ""
            valor2.Text = "0,00"
            cta2.Text = ""
            lbdoc2.Text = ""
        Else
            cmdanti2.Enabled = True
            cb2.Enabled = True
            txt2.Enabled = True
            valor2.Enabled = True
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
            cta3.Enabled = False
            txt3.Text = ""
            valor3.Text = "0,00"
            cta3.Text = ""
            lbdoc3.Text = ""
        Else
            cmdanti3.Enabled = True
            cb3.Enabled = True
            txt3.Enabled = True
            valor3.Enabled = True
            cta3.Enabled = True
            Try
                cb3.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    '*******************************
    Public Sub cont()
      
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
                'FrmContratos.cbconcepto.Items.Add(txt1.Text)
                'FrmContratos.cbsr.Items.Add(cb1.Text)
                'FrmContratos.cbvalor.Items.Add(Moneda(valor1.Text))
                'FrmContratos.cbcuenta.Items.Add(cta1.Text)
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
                'FrmContratos.cbconcepto.Items.Add(txt2.Text)
                'FrmContratos.cbsr.Items.Add(cb2.Text)
                'FrmContratos.cbvalor.Items.Add(Moneda(valor2.Text))
                'FrmContratos.cbcuenta.Items.Add(cta2.Text)
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
                'FrmContratos.cbconcepto.Items.Add(txt3.Text)
                'FrmContratos.cbsr.Items.Add(cb3.Text)
                'FrmContratos.cbvalor.Items.Add(Moneda(valor3.Text))
                'FrmContratos.cbcuenta.Items.Add(cta3.Text)
            End If
        End If
        Me.Close()
    End Sub
    Public Sub fr()
        Frmfacturarapida.cbconcepto.Items.Clear()
        Frmfacturarapida.cbsr.Items.Clear()
        Frmfacturarapida.cbvalor.Items.Clear()
        Frmfacturarapida.cbcuenta.Items.Clear()
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
                Frmfacturarapida.cbconcepto.Items.Add(txt1.Text)
                Frmfacturarapida.cbsr.Items.Add(cb1.Text)
                Frmfacturarapida.cbvalor.Items.Add(Moneda(valor1.Text))
                Frmfacturarapida.cbcuenta.Items.Add(cta1.Text)
                Frmfacturarapida.lbanti1.Text = lbdoc1.Text
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
                Frmfacturarapida.cbconcepto.Items.Add(txt2.Text)
                Frmfacturarapida.cbsr.Items.Add(cb2.Text)
                Frmfacturarapida.cbvalor.Items.Add(Moneda(valor2.Text))
                Frmfacturarapida.cbcuenta.Items.Add(cta2.Text)
                Frmfacturarapida.lbanti2.Text = lbdoc2.Text
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
                Frmfacturarapida.cbconcepto.Items.Add(txt3.Text)
                Frmfacturarapida.cbsr.Items.Add(cb3.Text)
                Frmfacturarapida.cbvalor.Items.Add(Moneda(valor3.Text))
                Frmfacturarapida.cbcuenta.Items.Add(cta3.Text)
                Frmfacturarapida.lbanti3.Text = lbdoc3.Text
            End If
        End If
        Me.Close()
    End Sub
    Public Sub fn()
        FrmFacturasyAjustes.cbconcepto.Items.Clear()
        FrmFacturasyAjustes.cbsr.Items.Clear()
        FrmFacturasyAjustes.cbvalor.Items.Clear()
        FrmFacturasyAjustes.cbcuenta.Items.Clear()
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
                FrmFacturasyAjustes.cbconcepto.Items.Add(txt1.Text)
                FrmFacturasyAjustes.cbsr.Items.Add(cb1.Text)
                FrmFacturasyAjustes.cbvalor.Items.Add(Moneda(valor1.Text))
                FrmFacturasyAjustes.cbcuenta.Items.Add(cta1.Text)
                FrmFacturasyAjustes.lbanti1.Text = lbdoc1.Text
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
                FrmFacturasyAjustes.cbconcepto.Items.Add(txt2.Text)
                FrmFacturasyAjustes.cbsr.Items.Add(cb2.Text)
                FrmFacturasyAjustes.cbvalor.Items.Add(Moneda(valor2.Text))
                FrmFacturasyAjustes.cbcuenta.Items.Add(cta2.Text)
                FrmFacturasyAjustes.lbanti2.Text = lbdoc2.Text
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
                FrmFacturasyAjustes.cbconcepto.Items.Add(txt3.Text)
                FrmFacturasyAjustes.cbsr.Items.Add(cb3.Text)
                FrmFacturasyAjustes.cbvalor.Items.Add(Moneda(valor3.Text))
                FrmFacturasyAjustes.cbcuenta.Items.Add(cta3.Text)
                FrmFacturasyAjustes.lbanti3.Text = lbdoc3.Text
            End If
        End If
        Me.Close()
    End Sub
    Public Sub fdp()
        FrmDocProveedor.cbconcepto.Items.Clear()
        FrmDocProveedor.cbsr.Items.Clear()
        FrmDocProveedor.cbvalor.Items.Clear()
        FrmDocProveedor.cbcuenta.Items.Clear()
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
                FrmDocProveedor.cbcuenta.Items.Add(cta1.Text)
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
                FrmDocProveedor.cbcuenta.Items.Add(cta2.Text)
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
                FrmDocProveedor.cbcuenta.Items.Add(cta3.Text)
            End If
        End If
        Me.Close()
    End Sub
    Public Sub llenarGrilla()
        Dim nit As String = ""
        If lbform.Text = "fr" Then
            nit = Frmfacturarapida.txtnitc.Text
        ElseIf lbform.Text = "fn" Then
            nit = FrmFacturasyAjustes.txtnitc.Text
        End If
        Dim items As Integer
        Dim tabla2 As New DataTable
        Try
            myCommand.CommandText = "SELECT *, (monto - causado) AS disp " _
            & "FROM ant_de_clie " _
            & "WHERE (monto - causado)>0 AND nitc='" & nit & "' " _
            & "ORDER BY fecha DESC;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmAntiProv.gitems.RowCount = items + 1
            For i = 0 To items - 1
                Try
                    FrmAntiProv.gitems.Item("doc", i).Value = tabla2.Rows(i).Item("per_doc")
                    FrmAntiProv.gitems.Item("fecha", i).Value = CambiaCadena(tabla2.Rows(i).Item("fecha").ToString, 10)
                    FrmAntiProv.gitems.Item("total", i).Value = Moneda(tabla2.Rows(i).Item("monto").ToString)
                    FrmAntiProv.gitems.Item("disponible", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                    FrmAntiProv.gitems.Item("monto", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                    FrmAntiProv.gitems.Item("cta", i).Value = tabla2.Rows(i).Item("cta").ToString
                    FrmAntiProv.gitems.Item("detalle", i).Value = tabla2.Rows(i).Item("concepto").ToString
                Catch ex As Exception
                    MsgBox("Llenar Item " & ex.ToString)
                End Try
            Next
        Catch ex As Exception
            MsgBox("Llenar Grilla " & ex.ToString)
        End Try
    End Sub

    Private Sub cmdanti1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti1.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = lbform.Text
            FrmAntiProv.lbfila.Text = "1"
            FrmAntiProv.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti2.Click
        Try
            llenarGrilla()
           FrmAntiCliente.lbform.Text = lbform.Text
            FrmAntiCliente.lbfila.Text = "2"
            FrmAntiCliente.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti3.Click
        Try
            llenarGrilla()
            FrmAntiCliente.lbform.Text = lbform.Text
            FrmAntiCliente.lbfila.Text = "2"
            FrmAntiCliente.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fila As String = ""
        If Ch1.Checked = True And valor1.Text = Moneda(0) Then
            fila = "1"
        ElseIf Ch2.Checked = True And valor2.Text = Moneda(0) Then
            fila = "2"
        ElseIf Ch3.Checked = True And valor3.Text = Moneda(0) Then
            fila = "3"
        End If

        If fila <> "" Then
            SendKeys.Send(Chr(Keys.Space))
            FrmSelConcepImp.lbform.Text = "OtrosCF"
            FrmSelConcepImp.lbfila.Text = fila
            FrmSelConcepImp.ShowDialog()
        Else
            MsgBox("Verifique el campo seleccionado", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub
End Class