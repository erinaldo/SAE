Public Class FrmOtrosConceptosCP
    Public txt As String = ""
    Public cta As String = ""
    Public sw As Integer = 0
    Public monto As Double = 0
    Public base As Double = 0
    Private Sub FrmOtrosConceptosCP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim C As Integer = 3, F As Integer = 0
        grilla.CurrentCell = grilla(C, F)
        grilla.Focus()
        If lbform.Text = "cpc" Then
            sw = 0
            monto = 0
            txt = ""
            base = 0
            'For i = 0 To FrmItemCartera.gitems.RowCount - 1
            '    Try
            '        If FrmItemCartera.gitems.Item("sel", i).Value = True Then
            '            'facturavencida(FrmItemCartera.gitems.Item("doc", i).Value.ToString, i)
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Next
            If sw = 1 Then
                Ch1.Checked = True
                cb1.Text = "+"
                txt1.Text = txt
                valor1.Text = Moneda(monto.ToString)
                cta1.Text = cta
                base1.Text = Moneda(base)
            Else
            End If
        Else
            If lbtotal.Text <> lbabono.Text Then
                lbtotal.Text = lbabono.Text
            End If
        End If
        If Ch1.Checked = False Then
            cmdanti1.Enabled = False
        End If
        'calcularDif()
        calcularDiff()
    End Sub
    Public Sub facturavencida(ByVal fac As String, ByVal i As Integer)
        Dim ven As Boolean = False
        Dim sql As String = ""
        Dim tipo As String = ""
        Dim fecha As String = Today.ToString
        Try
            If Val(FrmItemCartera.txtdia.Text) < 10 Then FrmItemCartera.txtdia.Text = "0" & Val(FrmItemCartera.txtdia.Text)
            fecha = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "-" & PerActual(0) & PerActual(1) & "-" & FrmItemCartera.txtdia.Text
        Catch ex As Exception
        End Try
        Try
            Dim tpar, tabla As New DataTable
            tpar.Clear()
            tabla.Clear()
            myCommand.CommandText = "SELECT hay_int,mon_int,tip_int,cta_mor FROM `car_par`;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tpar)
            If tpar.Rows.Count = 0 Then
                Exit Sub
            Else
                If tpar.Rows(0).Item("hay_int").ToString = "SI" Then
                    cta = tpar.Rows(0).Item("cta_mor").ToString
                    If tpar.Rows(0).Item("tip_int").ToString = "diarios" Then
                        tipo = "DAY"
                    ElseIf tpar.Rows(0).Item("tip_int").ToString = "mensual" Then
                        tipo = "MONTH"
                    Else
                        tipo = "YEAR"
                    End If
                    sql = "SELECT (total-pagado) AS saldo,doc, fecha, vmto, TIMESTAMPDIFF(" & tipo & " , adddate( fecha, vmto ) , '" & fecha & "' ) AS dif, " _
                    & "((TIMESTAMPDIFF(" & tipo & " , adddate( fecha, vmto ) , '" & fecha & "' ) * '" & tpar.Rows(0).Item("mon_int").ToString.Replace(",", ".") & "') * (total-pagado)) AS monto " _
                    & " FROM `cobdpen` WHERE doc='" & fac & "';"
                    myCommand.CommandText = sql
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If tpar.Rows(0).Item("tip_int").ToString = "diarios" Then
                        If txt = "" Then
                            txt = "INTERESES MORATORIOS DE " & tabla.Rows(0).Item("dif") & " DIA(S) FACTURA(S) " & fac
                        Else
                            txt = txt & "," & fac
                        End If
                    ElseIf tpar.Rows(0).Item("tip_int").ToString = "mensual" Then
                        If txt = "" Then
                            txt = "INTERESES MORATORIOS DE " & tabla.Rows(0).Item("dif") & " MES(ES) FACTURA(S) " & fac
                        Else
                            txt = txt & "," & fac
                        End If
                    Else
                        If txt = "" Then
                            txt = "INTERESES MORATORIOS DE " & tabla.Rows(0).Item("dif") & " AÑO(S) FACTURA(S) " & fac
                        Else
                            txt = txt & "," & fac
                        End If
                    End If
                    Try
                        'MsgBox(sql)
                        'MsgBox("monto: " & tabla.Rows(0).Item("monto").ToString)
                        'MsgBox("dif: " & tabla.Rows(0).Item("dif").ToString)
                        If CDbl(tabla.Rows(0).Item("monto").ToString) > 0 Then
                            sw = 1
                            monto = monto + CDbl(tabla.Rows(0).Item("monto").ToString)
                            FrmItemCartera.gitems.Item("abono", i).Value = Moneda(CDbl(FrmItemCartera.gitems.Item("abono", i).Value.ToString) - CDbl(tabla.Rows(0).Item("monto").ToString))
                            lbabono.Text = Moneda(CDbl(lbabono.Text) - CDbl(tabla.Rows(0).Item("monto").ToString))
                            base = base + CDbl(tabla.Rows(0).Item("saldo").ToString)
                        End If
                    Catch ex As Exception
                        'MsgBox(sql & "****888*****" & ex.ToString)
                    End Try
                    Refresh()
                End If
            End If
        Catch ex As Exception
            'MsgBox(sql & " ********** " & ex.ToString)
        End Try
    End Sub
    '**************************************************
    Private Sub cmdcontinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcontinuar.Click
        'If Validar() = True Then
        Select Case lbform.Text
            Case "cpp"
                'CpP()
                NCpP()
            Case "cpc"
                'CpC()
                NCpC()
        End Select
        'End If
    End Sub
    Public Sub NCpC()

        FrmItemCartera.cbconcepto.Items.Clear()
        FrmItemCartera.cbsr.Items.Clear()
        FrmItemCartera.cbvalor.Items.Clear()
        FrmItemCartera.cbcuenta.Items.Clear()
        FrmItemCartera.cbbase.Items.Clear()
        FrmItemCartera.cbldoc.Items.Clear()
        
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
                If grilla.Item("tipo", i).Value = "" Then
                    MsgBox("Verifique si el concepto suma o resta, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf Trim(grilla.Item("des", i).Value) = "" Then
                    MsgBox("Verifique la descripcion del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("valor", i).Value = "0,00" Or grilla.Item("valor", i).Value = "" Then
                    MsgBox("Verifique el valor, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("cuenta", i).Value = "" Then
                    MsgBox("Verifique la cuenta del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmItemCartera.cbconcepto.Items.Add(grilla.Item("des", i).Value)
                FrmItemCartera.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmItemCartera.cbvalor.Items.Add(Moneda(grilla.Item("valor", i).Value))
                FrmItemCartera.cbbase.Items.Add(Moneda(grilla.Item("bs", i).Value))
                FrmItemCartera.cbcuenta.Items.Add(grilla.Item("cuenta", i).Value)
                Try
                    FrmItemCartera.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmItemCartera.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        '..............

        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    '*** COMBOS ****
    Private Sub cb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.SelectedIndexChanged
        calcularDif()
    End Sub
    Private Sub cb2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2.SelectedIndexChanged
        calcularDif()
    End Sub
    Private Sub cb3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb3.SelectedIndexChanged
        calcularDif()
    End Sub
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
    Private Sub cb1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb1.LostFocus
        calcularDif()
    End Sub
    Private Sub cb2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb2.LostFocus
        calcularDif()
    End Sub
    Private Sub cb3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb3.LostFocus
        calcularDif()
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
        calcularDif()
    End Sub
    Private Sub valor2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor2.KeyPress
        ValidarMoneda(valor2, e)
    End Sub
    Private Sub valor2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor2.LostFocus
        valor2.Text = Moneda(valor2.Text)
        calcularDif()
    End Sub
    Private Sub valor3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor3.KeyPress
        ValidarMoneda(valor3, e)
    End Sub
    Private Sub valor3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor3.LostFocus
        valor3.Text = Moneda(valor3.Text)
        calcularDif()
    End Sub
    Public Sub calcularDiff()
        Dim conceptos As Double = 0
        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                If grilla.Item("tipo", i).Value = "-" Then
                    Try
                        conceptos = conceptos - CDbl(grilla.Item("valor", i).Value)
                    Catch ex As Exception
                        conceptos = conceptos - CDbl(0)
                    End Try
                Else
                    Try
                        conceptos = conceptos + CDbl(grilla.Item("valor", i).Value)
                    Catch ex As Exception
                        conceptos = conceptos + CDbl(0)
                    End Try
                End If
            End If
        Next
        lbdif.Text = Moneda(CDbl(lbtotal.Text) + conceptos - CDbl(lbsaldo.Text))
        If conceptos >= 0 Then
            lbsigno.Text = "+"
        Else
            lbsigno.Text = "-"
            conceptos = conceptos * (-1)
        End If
        lbconcepto.Text = Moneda(conceptos)
    End Sub
    Public Sub calcularDif()
        Try
            'Try
            '    lbdif.Text = Moneda(CDbl(lbsaldo.Text) - CDbl(lbabono.Text))
            'Catch ex As Exception
            'End Try
            Dim conceptos As Double = 0
            If Ch1.Checked = True Then
                If cb1.Text = "-" Then
                    conceptos = conceptos - CDbl(valor1.Text)
                Else
                    conceptos = conceptos + CDbl(valor1.Text)
                End If
            End If
            If Ch2.Checked = True Then
                If cb2.Text = "-" Then
                    conceptos = conceptos - CDbl(valor2.Text)
                Else
                    conceptos = conceptos + CDbl(valor2.Text)
                End If
            End If
            If Ch3.Checked = True Then
                If cb3.Text = "-" Then
                    conceptos = conceptos - CDbl(valor3.Text)
                Else
                    conceptos = conceptos + CDbl(valor3.Text)
                End If
            End If
            ' lbdif.Text = Moneda(CDbl(lbabono.Text) + conceptos - CDbl(lbsaldo.Text))
            lbdif.Text = Moneda(CDbl(lbtotal.Text) + conceptos - CDbl(lbsaldo.Text))
            'If CDbl(lbdif.Text) <= 0 Then
            '    lbdif.Text = Moneda(CDbl(lbabono.Text) + conceptos - CDbl(lbsaldo.Text))
            'End If
            If conceptos >= 0 Then
                lbsigno.Text = "+"
            Else
                lbsigno.Text = "-"
                conceptos = conceptos * (-1)
            End If
            lbconcepto.Text = Moneda(conceptos)
        Catch ex As Exception
        End Try
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
                Select Case txt
                    Case "concep_1"
                        FrmCuentas.lbform.Text = "concep2_1"
                        cta1.Text = ""
                    Case "concep_2"
                        cta2.Text = ""
                        FrmCuentas.lbform.Text = "concep2_2"
                    Case "concep_3"
                        FrmCuentas.lbform.Text = "concep2_3"
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
    '******* BASE *************
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
    '* che *****************
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        calcularDif()
        If Ch1.Checked = False Then
            cb1.Enabled = False
            txt1.Enabled = False
            valor1.Enabled = False
            cta1.Enabled = False
            base1.Enabled = False
            cmdanti1.Enabled = False
            base1.Text = "0,00"
            txt1.Text = ""
            valor1.Text = "0,00"
            cta1.Text = ""
            lbdoc1.Text = ""
        Else
            cb1.Enabled = True
            txt1.Enabled = True
            valor1.Enabled = True
            cta1.Enabled = True
            base1.Enabled = True
            cmdanti1.Enabled = True
            Try
                cb1.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch2.CheckedChanged
        calcularDif()
        If Ch2.Checked = False Then
            cmdanti2.Enabled = False
            cb2.Enabled = False
            txt2.Enabled = False
            valor2.Enabled = False
            cta2.Enabled = False
            base2.Enabled = False
            base2.Text = "0,00"
            txt2.Text = ""
            valor2.Text = "0,00"
            cta2.Text = ""
            lbdoc2.Text = ""
        Else
            cb2.Enabled = True
            cmdanti2.Enabled = True
            txt2.Enabled = True
            valor2.Enabled = True
            cta2.Enabled = True
            base2.Enabled = True
            Try
                cb2.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Ch3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch3.CheckedChanged
        calcularDif()
        If Ch3.Checked = False Then
            cmdanti3.Enabled = False
            cb3.Enabled = False
            txt3.Enabled = False
            valor3.Enabled = False
            cta3.Enabled = False
            base3.Enabled = False
            base3.Text = "0,00"
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
            base3.Enabled = True
            Try
                cb3.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    '*******************************
    Function Validar()
        If Ch1.Checked = True Then
            If Trim(cb1.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb1.Focus()
                Return False
                Exit Function
            ElseIf Trim(txt1.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt1.Focus()
                Return False
                Exit Function
            ElseIf Moneda(valor1.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor1.Focus()
                Return False
                Exit Function
            ElseIf Trim(cta1.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta1.Focus()
                Return False
                Exit Function
            End If
        End If
        '******************************************************************************************
        If Ch2.Checked = True Then
            If Trim(cb2.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb2.Focus()
                Return False
                Exit Function
            ElseIf Trim(txt2.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt2.Focus()
                Return False
                Exit Function
            ElseIf Moneda(valor2.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor2.Focus()
                Return False
                Exit Function
            ElseIf Trim(cta2.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta2.Focus()
                Return False
                Exit Function
            End If
        End If
        '******************************************************************************************
        If Ch3.Checked = True Then
            If Trim(cb3.Text) = "" Then
                MsgBox("Verifique si el concepto suma o resta. ", MsgBoxStyle.Information, "SAE Control")
                cb3.Focus()
                Return False
                Exit Function
            ElseIf Trim(txt3.Text) = "" Then
                MsgBox("Verifique la descripcion del concepto. ", MsgBoxStyle.Information, "SAE Control")
                txt3.Focus()
                Return False
                Exit Function
            ElseIf Moneda(valor3.Text) = "0,00" Then
                MsgBox("Verifique el valor o monto del concepto. ", MsgBoxStyle.Information, "SAE Control")
                valor3.Focus()
                Return False
                Exit Function
            ElseIf Trim(cta3.Text) = "" Then
                MsgBox("Verifique la cuenta del concepto. ", MsgBoxStyle.Information, "SAE Control")
                cta3.Focus()
                Return False
                Exit Function
            End If
        End If
        '*************************************************************************************************
        Return True
    End Function
    '**********************************
    Public Sub NCpP()
        FrmItemsCPP.cbconcepto.Items.Clear()
        FrmItemsCPP.cbsr.Items.Clear()
        FrmItemsCPP.cbvalor.Items.Clear()
        FrmItemsCPP.cbcuenta.Items.Clear()
        FrmItemsCPP.cbbase.Items.Clear()
        FrmItemsCPP.cbldoc.Items.Clear()

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                'MsgBox(Strings.Len(FrmDocProveedor.lbanti3.Text))
                If grilla.Item("tipo", i).Value = "" Then
                    MsgBox("Verifique si el concepto suma o resta, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf Trim(grilla.Item("des", i).Value) = "" Then
                    MsgBox("Verifique la descripcion del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("valor", i).Value = "0,00" Or grilla.Item("valor", i).Value = "" Then
                    MsgBox("Verifique el valor, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf grilla.Item("cuenta", i).Value = "" Then
                    MsgBox("Verifique la cuenta del concepto, En la fila " & i + 1, MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
            End If
        Next

        For i = 0 To grilla.RowCount - 1
            If grilla.Item("sel", i).Value = True Then
                FrmItemsCPP.cbconcepto.Items.Add(grilla.Item("des", i).Value)
                FrmItemsCPP.cbsr.Items.Add(grilla.Item("tipo", i).Value)
                FrmItemsCPP.cbvalor.Items.Add(Moneda(grilla.Item("valor", i).Value))
                FrmItemsCPP.cbbase.Items.Add(Moneda(grilla.Item("bs", i).Value))
                FrmItemsCPP.cbcuenta.Items.Add(grilla.Item("cuenta", i).Value)
                Try
                    FrmItemsCPP.cbldoc.Items.Add(grilla.Item("ldoc", i).Value)
                Catch ex As Exception
                    FrmItemsCPP.cbldoc.Items.Add(" ")
                End Try
            End If
        Next
        '..............

        'MsgBox("ok")
        Me.Close()
    End Sub
    Public Sub CpP()
        Try
            Dim fila As Integer = Val(lbfila.Text)
            FrmItemsCPP.gitems.Item("abono", fila).Value = lbabono.Text  'ABONO
            '*************************************************************************
            If Ch1.Checked = True Then
                FrmItemsCPP.gitems.Item("t1", fila).Value = cb1.Text 'tipo + / -
                FrmItemsCPP.gitems.Item("d1", fila).Value = txt1.Text 'descrip
                FrmItemsCPP.gitems.Item("v1", fila).Value = valor1.Text 'valos $
                FrmItemsCPP.gitems.Item("cta1", fila).Value = cta1.Text 'cuenta 
                FrmItemsCPP.gitems.Item("b1", fila).Value = base1.Text 'base $
                FrmItemsCPP.gitems.Item("b1", fila).Value = base1.Text 'base $
                FrmItemsCPP.gitems.Item("do1", fila).Value = lbdoc1.Text 'Documento
            Else
                FrmItemsCPP.gitems.Item("t1", fila).Value = "/" 'tipo + / -
                FrmItemsCPP.gitems.Item("d1", fila).Value = "" 'descrip
                FrmItemsCPP.gitems.Item("v1", fila).Value = "0,00" 'valos $
                FrmItemsCPP.gitems.Item("cta1", fila).Value = "" 'cuenta 
                FrmItemsCPP.gitems.Item("b1", fila).Value = "0,00" 'base $
                FrmItemsCPP.gitems.Item("do1", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            If Ch2.Checked = True Then
                FrmItemsCPP.gitems.Item("t2", fila).Value = cb2.Text 'tipo + / -
                FrmItemsCPP.gitems.Item("d2", fila).Value = txt2.Text 'descrip
                FrmItemsCPP.gitems.Item("v2", fila).Value = valor2.Text 'valos $
                FrmItemsCPP.gitems.Item("cta2", fila).Value = cta2.Text 'cuenta 
                FrmItemsCPP.gitems.Item("b2", fila).Value = base2.Text 'base $
                FrmItemsCPP.gitems.Item("do2", fila).Value = lbdoc2.Text 'Documento
            Else
                FrmItemsCPP.gitems.Item("t2", fila).Value = "/" 'tipo + / -
                FrmItemsCPP.gitems.Item("d2", fila).Value = "" 'descrip
                FrmItemsCPP.gitems.Item("v2", fila).Value = "0,00" 'valos $
                FrmItemsCPP.gitems.Item("cta2", fila).Value = "" 'cuenta 
                FrmItemsCPP.gitems.Item("b2", fila).Value = "0,00" 'base $
                FrmItemsCPP.gitems.Item("do2", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            If Ch3.Checked = True Then
                FrmItemsCPP.gitems.Item("t3", fila).Value = cb3.Text 'tipo + / -
                FrmItemsCPP.gitems.Item("d3", fila).Value = txt3.Text 'descrip
                FrmItemsCPP.gitems.Item("v3", fila).Value = valor3.Text 'valos $
                FrmItemsCPP.gitems.Item("cta3", fila).Value = cta3.Text 'cuenta 
                FrmItemsCPP.gitems.Item("b3", fila).Value = base3.Text 'base $
                FrmItemsCPP.gitems.Item("do3", fila).Value = lbdoc3.Text 'Documento
            Else
                FrmItemsCPP.gitems.Item("t3", fila).Value = "/" 'tipo + / -
                FrmItemsCPP.gitems.Item("d3", fila).Value = "" 'descrip
                FrmItemsCPP.gitems.Item("v3", fila).Value = "0,00" 'valos $
                FrmItemsCPP.gitems.Item("cta3", fila).Value = "" 'cuenta 
                FrmItemsCPP.gitems.Item("b3", fila).Value = "0,00" 'base $
                FrmItemsCPP.gitems.Item("do3", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            'MsgBox("Un Momento......")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '**********************************
    Public Sub CpC()
        Try
            Dim fila As Integer = Val(lbfila.Text)
            FrmItemCartera.gitems.Item("abono", fila).Value = lbabono.Text  'ABONO
            '*************************************************************************
            If Ch1.Checked = True Then
                FrmItemCartera.gitems.Item("t1", fila).Value = cb1.Text 'tipo + / -
                FrmItemCartera.gitems.Item("d1", fila).Value = txt1.Text 'descrip
                FrmItemCartera.gitems.Item("v1", fila).Value = valor1.Text 'valos $
                FrmItemCartera.gitems.Item("cta1", fila).Value = cta1.Text 'cuenta 
                FrmItemCartera.gitems.Item("b1", fila).Value = base1.Text 'base $
                FrmItemCartera.gitems.Item("do1", fila).Value = lbdoc1.Text 'Documento
            Else
                FrmItemCartera.gitems.Item("t1", fila).Value = "/" 'tipo + / -
                FrmItemCartera.gitems.Item("d1", fila).Value = "" 'descrip
                FrmItemCartera.gitems.Item("v1", fila).Value = "0,00" 'valos $
                FrmItemCartera.gitems.Item("cta1", fila).Value = "" 'cuenta 
                FrmItemCartera.gitems.Item("b1", fila).Value = "0,00" 'base $
                FrmItemCartera.gitems.Item("do1", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            If Ch2.Checked = True Then
                FrmItemCartera.gitems.Item("t2", fila).Value = cb2.Text 'tipo + / -
                FrmItemCartera.gitems.Item("d2", fila).Value = txt2.Text 'descrip
                FrmItemCartera.gitems.Item("v2", fila).Value = valor2.Text 'valos $
                FrmItemCartera.gitems.Item("cta2", fila).Value = cta2.Text 'cuenta 
                FrmItemCartera.gitems.Item("b2", fila).Value = base2.Text 'base $
                FrmItemCartera.gitems.Item("do2", fila).Value = lbdoc2.Text 'Documento
            Else
                FrmItemCartera.gitems.Item("t2", fila).Value = "/" 'tipo + / -
                FrmItemCartera.gitems.Item("d2", fila).Value = "" 'descrip
                FrmItemCartera.gitems.Item("v2", fila).Value = "0,00" 'valos $
                FrmItemCartera.gitems.Item("cta2", fila).Value = "" 'cuenta 
                FrmItemCartera.gitems.Item("b2", fila).Value = "0,00" 'base $
                FrmItemCartera.gitems.Item("do2", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            If Ch3.Checked = True Then
                FrmItemCartera.gitems.Item("t3", fila).Value = cb3.Text 'tipo + / -
                FrmItemCartera.gitems.Item("d3", fila).Value = txt3.Text 'descrip
                FrmItemCartera.gitems.Item("v3", fila).Value = valor3.Text 'valos $
                FrmItemCartera.gitems.Item("cta3", fila).Value = cta3.Text 'cuenta 
                FrmItemCartera.gitems.Item("b3", fila).Value = base3.Text 'base $
                FrmItemCartera.gitems.Item("do3", fila).Value = lbdoc3.Text 'Documento
            Else
                FrmItemCartera.gitems.Item("t3", fila).Value = "/" 'tipo + / -
                FrmItemCartera.gitems.Item("d3", fila).Value = "" 'descrip
                FrmItemCartera.gitems.Item("v3", fila).Value = "0,00" 'valos $
                FrmItemCartera.gitems.Item("cta3", fila).Value = "" 'cuenta 
                FrmItemCartera.gitems.Item("b3", fila).Value = "0,00" 'base $
                FrmItemCartera.gitems.Item("do3", fila).Value = "" 'Documento
            End If
            '*************************************************************************
            'MsgBox("Un Momento......")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '************************************  
    Public Sub llenarGrilla()
        Dim nit As String = ""
        Dim tb As String = ""
        If lbform.Text = "cpp" Then
            nit = FrmItemsCPP.txtnitc.Text
            tb = "ant_a_prov "
        Else
            nit = FrmItemCartera.txtnitc.Text
            tb = "ant_de_clie "
        End If

        Dim items As Integer
        Dim tabla2 As New DataTable
        Try
            myCommand.CommandText = "SELECT *, (monto - causado) AS disp " _
            & "FROM " & tb & " " _
            & "WHERE (monto - causado)>0 AND nitc='" & nit & "' " _
            & "ORDER BY fecha DESC;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmAntiProv.gitems.Rows.Clear()
            FrmAntiProv.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmAntiProv.gitems.Item("doc", i).Value = tabla2.Rows(i).Item("per_doc")
                FrmAntiProv.gitems.Item("fecha", i).Value = CambiaCadena(tabla2.Rows(i).Item("fecha").ToString, 10)
                FrmAntiProv.gitems.Item("total", i).Value = Moneda(tabla2.Rows(i).Item("monto").ToString)
                FrmAntiProv.gitems.Item("disponible", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                FrmAntiProv.gitems.Item("monto", i).Value = Moneda(tabla2.Rows(i).Item("disp").ToString)
                FrmAntiProv.gitems.Item("cta", i).Value = tabla2.Rows(i).Item("cta").ToString
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub cmdanti1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti1.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = lbform.Text
            FrmAntiProv.lbfila.Text = "1"
            FrmAntiProv.ShowDialog()
            calcularDif()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti2.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = lbform.Text
            FrmAntiProv.lbfila.Text = "2"
            FrmAntiProv.ShowDialog()
            calcularDif()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdanti3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdanti3.Click
        Try
            llenarGrilla()
            FrmAntiProv.lbform.Text = lbform.Text
            FrmAntiProv.lbfila.Text = "3"
            FrmAntiProv.ShowDialog()
            calcularDif()
        Catch ex As Exception

        End Try
    End Sub
    Public fila As Integer

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
        FrmAntiProv.lbform.Text = "otconCP"
        FrmAntiProv.lbfila.Text = fl
        FrmAntiProv.ShowDialog()
    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Select Case e.ColumnIndex
            Case 3
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
                calcularDiff()
            Case 4
                Try
                    grilla.Item(4, e.RowIndex).Value = Moneda(grilla.Item(4, e.RowIndex).Value)
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                Catch ex As Exception
                    grilla.Item(4, e.RowIndex).Value = Moneda(0)
                    grilla.Item(5, e.RowIndex).Value = Moneda(0)
                End Try
                calcularDiff()
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
        calcularDiff()
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
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If Trim(cuenta) = "" Then
            FrmCuentas.lbform.Text = "OConCP"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                'If Trim(grilla.Item(3, fila).Value) = "" Or nivel_cuenta(grilla.Item(3, fila).Value) = True Then
                'grilla.Item(3, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "OConCP"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
            End If
        End If

    End Sub
End Class