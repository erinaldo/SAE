Public Class FrmDigitarBase
    Private Sub FrmDigitarBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBase.Text = "0,00"
    End Sub
    Private Sub txtBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBase.KeyPress
        ValidarMoneda(txtBase, e)
    End Sub
    Private Sub txtBase_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBase.LostFocus
        txtBase.Text = Moneda(txtBase.Text)
        cmditems_Click(AcceptButton, AcceptButton)
    End Sub
    '**************************************************************    
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM impuestos WHERE id_imp='" & lbconcepto.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items < 1 Then
            MsgBox("El impuesto no existe, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            txtBase.Focus()
            Me.Close()
            Exit Sub
        End If
        '*****************************************************
        Dim fila As Integer = Val(lbfila.Text)
        Dim monto As Double
        Select Case lbform.Text
            Case "generar"
                FrmEntradaDatos.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmEntradaDatos.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmEntradaDatos.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmEntradaDatos.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmEntradaDatos.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmEntradaDatos.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmEntradaDatos.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "si"
                FrmSaldosIniciales.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmSaldosIniciales.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmSaldosIniciales.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmSaldosIniciales.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmSaldosIniciales.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmSaldosIniciales.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmSaldosIniciales.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "ComEgres"
                FrmComEgresoCpp.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmComEgresoCpp.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmComEgresoCpp.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmComEgresoCpp.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmComEgresoCpp.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmComEgresoCpp.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmComEgresoCpp.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "ComIng"
                FrmCompIngresos.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmCompIngresos.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmCompIngresos.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmCompIngresos.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmCompIngresos.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmCompIngresos.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmCompIngresos.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "ReciCaja"
                FrmRecibodeCaja.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmRecibodeCaja.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmRecibodeCaja.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmRecibodeCaja.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmRecibodeCaja.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmRecibodeCaja.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmRecibodeCaja.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "NotaDb"
                FrmNotaDebito.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmNotaDebito.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmNotaDebito.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmNotaDebito.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmNotaDebito.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmNotaDebito.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmNotaDebito.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "NotaCr"
                FrmNotaCredito.grilla.Item("Descripcion", fila).Value = tabla.Rows(0).Item("descrip")
                FrmNotaCredito.grilla.Item("Cuenta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmNotaCredito.grilla.Item("Base", fila).Value = txtBase.Text
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmNotaCredito.grilla.Item("Debitos", fila).Value = Moneda(monto)
                    FrmNotaCredito.grilla.Item("Creditos", fila).Value = "0,00"
                Else
                    FrmNotaCredito.grilla.Item("Debitos", fila).Value = "0,00"
                    FrmNotaCredito.grilla.Item("Creditos", fila).Value = Moneda(monto)
                End If
            Case "OtrosCP"
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                FrmOtrosConceptosProv.grilla.Item("sel", fila).Value = True
                If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                    FrmOtrosConceptosProv.grilla.Item("tipo", fila).Value = "+"
                Else
                    FrmOtrosConceptosProv.grilla.Item("tipo", fila).Value = "-"
                End If
                FrmOtrosConceptosProv.grilla.Item("txt", fila).Value = tabla.Rows(0).Item("descrip")
                FrmOtrosConceptosProv.grilla.Item("valor", fila).Value = Moneda2(monto, FrmDocProveedor.lb_imp_dec.Text)
                FrmOtrosConceptosProv.grilla.Item("base", fila).Value = Moneda2(txtBase.Text, FrmDocProveedor.lb_imp_dec.Text)
                FrmOtrosConceptosProv.grilla.Item("cta", fila).Value = tabla.Rows(0).Item("cuenta")
                FrmOtrosConceptosProv.grilla.Item("ldoc", fila).Value = ""

                'If fila = "1" Then
                '    FrmOtrosConceptosProv.Ch1.Checked = True
                '    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                '        FrmOtrosConceptosProv.cb1.Text = "+"
                '    Else
                '        FrmOtrosConceptosProv.cb1.Text = "-"
                '    End If
                '    FrmOtrosConceptosProv.txt1.Text = tabla.Rows(0).Item("descrip")
                '    FrmOtrosConceptosProv.valor1.Text = Moneda(monto)
                '    FrmOtrosConceptosProv.base1.Text = txtBase.Text
                '    FrmOtrosConceptosProv.cta1.Text = tabla.Rows(0).Item("cuenta")
                'ElseIf fila = "2" Then
                '    FrmOtrosConceptosProv.Ch2.Checked = True
                '    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                '        FrmOtrosConceptosProv.cb2.Text = "+"
                '    Else
                '        FrmOtrosConceptosProv.cb2.Text = "-"
                '    End If
                '    FrmOtrosConceptosProv.txt2.Text = tabla.Rows(0).Item("descrip")
                '    FrmOtrosConceptosProv.valor2.Text = Moneda(monto)
                '    FrmOtrosConceptosProv.base2.Text = txtBase.Text
                '    FrmOtrosConceptosProv.cta2.Text = tabla.Rows(0).Item("cuenta")
                'ElseIf fila = "3" Then
                '    FrmOtrosConceptosProv.Ch3.Checked = True
                '    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                '        FrmOtrosConceptosProv.cb3.Text = "+"
                '    Else
                '        FrmOtrosConceptosProv.cb3.Text = "-"
                '    End If
                '    FrmOtrosConceptosProv.txt3.Text = tabla.Rows(0).Item("descrip")
                '    FrmOtrosConceptosProv.valor3.Text = Moneda(monto)
                '    FrmOtrosConceptosProv.base3.Text = txtBase.Text
                '    FrmOtrosConceptosProv.cta3.Text = tabla.Rows(0).Item("cuenta")
                'End If
            Case "OtrosCF"
                Try
                    monto = CDbl(txtBase.Text) * tabla.Rows(0).Item("porce") / 100
                Catch ex As Exception
                    monto = 0
                End Try
                If fila = "1" Then
                    FrmOtrosConceptos.Ch1.Checked = True
                    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                        FrmOtrosConceptos.cb1.Text = "+"
                    Else
                        FrmOtrosConceptos.cb1.Text = "-"
                    End If
                    FrmOtrosConceptos.txt1.Text = tabla.Rows(0).Item("descrip")
                    FrmOtrosConceptos.valor1.Text = Moneda(monto)
                    'FrmOtrosConceptos.base1.Text = txtBase.Text
                    FrmOtrosConceptos.cta1.Text = tabla.Rows(0).Item("cuenta")
                ElseIf fila = "2" Then
                    FrmOtrosConceptos.Ch2.Checked = True
                    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                        FrmOtrosConceptos.cb2.Text = "+"
                    Else
                        FrmOtrosConceptos.cb2.Text = "-"
                    End If
                    FrmOtrosConceptos.txt2.Text = tabla.Rows(0).Item("descrip")
                    FrmOtrosConceptos.valor2.Text = Moneda(monto)
                    ' FrmOtrosConceptos.base2.Text = txtBase.Text
                    FrmOtrosConceptos.cta2.Text = tabla.Rows(0).Item("cuenta")
                ElseIf fila = "3" Then
                    FrmOtrosConceptos.Ch3.Checked = True
                    If Trim(tabla.Rows(0).Item("tip_asi")) = "D" Then
                        FrmOtrosConceptos.cb3.Text = "+"
                    Else
                        FrmOtrosConceptos.cb3.Text = "-"
                    End If
                    FrmOtrosConceptos.txt3.Text = tabla.Rows(0).Item("descrip")
                    FrmOtrosConceptos.valor3.Text = Moneda(monto)
                    'FrmOtrosConceptos.base3.Text = txtBase.Text
                    FrmOtrosConceptos.cta3.Text = tabla.Rows(0).Item("cuenta")
                End If
        End Select
        txtBase.Focus()
        Me.Close()
    End Sub
End Class