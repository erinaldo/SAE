﻿Public Class FrmAntiProv
    Public fila, sw As Integer
    Private Sub FrmAntiProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        Select Case e.ColumnIndex
            'Case 3 'precio
            '    Try
            '        If gitems.Item("nombre", e.RowIndex).Value = "" Then Exit Sub
            '        FrmPrecioItems.lbform.Text = "selS"
            '        FrmPrecioItems.lbfila.Text = e.RowIndex
            '        FrmPrecioItems.Ch1.Checked = True
            '        FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
            '        FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
            '        FrmPrecioItems.ShowDialog()
            '    Catch ex As Exception
            '    End Try
        End Select
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        sw = 0

    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        Try
            Select Case lbform.Text
                Case "otconCP"
                    Dim fl As Integer
                    fl = Val(lbfila.Text)
                    FrmOtrosConceptosCP.grilla.Item("sel", fl).Value = True
                    FrmOtrosConceptosCP.grilla.Item("tipo", fl).Value = "-"
                    FrmOtrosConceptosCP.grilla.Item("des", fl).Value = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                    FrmOtrosConceptosCP.grilla.Item("valor", fl).Value = Moneda(gitems.Item("monto", mifila).Value.ToString)
                    FrmOtrosConceptosCP.grilla.Item("bs", fl).Value = Moneda(0)
                    FrmOtrosConceptosCP.grilla.Item("cuenta", fl).Value = gitems.Item("cta", mifila).Value.ToString
                    FrmOtrosConceptosCP.grilla.Item("ldoc", fl).Value = gitems.Item("doc", mifila).Value.ToString
                Case "Gotcon"
                    Dim fl As Integer
                    fl = Val(lbfila.Text)
                    FrmOtrosConceptosProv.grilla.Item("sel", fl).Value = True
                    FrmOtrosConceptosProv.grilla.Item("tipo", fl).Value = "-"
                    FrmOtrosConceptosProv.grilla.Item("txt", fl).Value = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                    FrmOtrosConceptosProv.grilla.Item("valor", fl).Value = Moneda(gitems.Item("monto", mifila).Value.ToString)
                    FrmOtrosConceptosProv.grilla.Item("base", fl).Value = Moneda(0)
                    FrmOtrosConceptosProv.grilla.Item("cta", fl).Value = gitems.Item("cta", mifila).Value.ToString
                    FrmOtrosConceptosProv.grilla.Item("ldoc", fl).Value = gitems.Item("doc", mifila).Value.ToString

                Case "otcon"
                    If lbfila.Text = "1" Then
                        FrmOtrosConceptosProv.cb1.Text = "-"
                        FrmOtrosConceptosProv.txt1.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosProv.valor1.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosProv.base1.Text = "0,00"
                        FrmOtrosConceptosProv.cta1.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosProv.lbdoc1.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "2" Then
                        FrmOtrosConceptosProv.cb2.Text = "-"
                        FrmOtrosConceptosProv.txt2.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosProv.valor2.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosProv.base2.Text = "0,00"
                        FrmOtrosConceptosProv.cta2.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosProv.lbdoc2.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "3" Then
                        FrmOtrosConceptosProv.cb3.Text = "-"
                        FrmOtrosConceptosProv.txt3.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosProv.valor3.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosProv.base3.Text = "0,00"
                        FrmOtrosConceptosProv.cta3.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosProv.lbdoc3.Text = gitems.Item("doc", mifila).Value.ToString
                    End If
                Case "cpp"
                    If lbfila.Text = "1" Then
                        FrmOtrosConceptosCP.cb1.Text = "-"
                        FrmOtrosConceptosCP.txt1.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor1.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base1.Text = "0,00"
                        FrmOtrosConceptosCP.cta1.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc1.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "2" Then
                        FrmOtrosConceptosCP.cb2.Text = "-"
                        FrmOtrosConceptosCP.txt2.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor2.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base2.Text = "0,00"
                        FrmOtrosConceptosCP.cta2.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc2.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "3" Then
                        FrmOtrosConceptosCP.cb3.Text = "-"
                        FrmOtrosConceptosCP.txt3.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor3.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base3.Text = "0,00"
                        FrmOtrosConceptosCP.cta3.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc3.Text = gitems.Item("doc", mifila).Value.ToString
                    End If
                Case "cpc"
                    If lbfila.Text = "1" Then
                        FrmOtrosConceptosCP.cb1.Text = "-"
                        FrmOtrosConceptosCP.txt1.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor1.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base1.Text = "0,00"
                        FrmOtrosConceptosCP.cta1.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc1.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "2" Then
                        FrmOtrosConceptosCP.cb2.Text = "-"
                        FrmOtrosConceptosCP.txt2.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor2.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base2.Text = "0,00"
                        FrmOtrosConceptosCP.cta2.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc2.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "3" Then
                        FrmOtrosConceptosCP.cb3.Text = "-"
                        FrmOtrosConceptosCP.txt3.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptosCP.valor3.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        FrmOtrosConceptosCP.base3.Text = "0,00"
                        FrmOtrosConceptosCP.cta3.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptosCP.lbdoc3.Text = gitems.Item("doc", mifila).Value.ToString
                    End If
                Case "fr"
                    If lbfila.Text = "1" Then
                        FrmOtrosConceptos.cb1.Text = "-"
                        FrmOtrosConceptos.txt1.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor1.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        ' FrmOtrosConceptos.base1.Text = "0,00"
                        FrmOtrosConceptos.cta1.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc1.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "2" Then
                        FrmOtrosConceptos.cb2.Text = "-"
                        FrmOtrosConceptos.txt2.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor2.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        'FrmOtrosConceptos.base2.Text = "0,00"
                        FrmOtrosConceptos.cta2.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc2.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "3" Then
                        FrmOtrosConceptos.cb3.Text = "-"
                        FrmOtrosConceptos.txt3.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor3.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        'FrmOtrosConceptos.base3.Text = "0,00"
                        FrmOtrosConceptos.cta3.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc3.Text = gitems.Item("doc", mifila).Value.ToString
                    End If
                Case "fn"
                    If lbfila.Text = "1" Then
                        FrmOtrosConceptos.cb1.Text = "-"
                        FrmOtrosConceptos.txt1.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor1.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        ' FrmOtrosConceptos.base1.Text = "0,00"
                        FrmOtrosConceptos.cta1.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc1.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "2" Then
                        FrmOtrosConceptos.cb2.Text = "-"
                        FrmOtrosConceptos.txt2.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor2.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        'FrmOtrosConceptos.base2.Text = "0,00"
                        FrmOtrosConceptos.cta2.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc2.Text = gitems.Item("doc", mifila).Value.ToString
                    ElseIf lbfila.Text = "3" Then
                        FrmOtrosConceptos.cb3.Text = "-"
                        FrmOtrosConceptos.txt3.Text = "ANTICIPO DOCUMENTO " & gitems.Item("doc", mifila).Value.ToString
                        FrmOtrosConceptos.valor3.Text = Moneda(gitems.Item("monto", mifila).Value.ToString)
                        'FrmOtrosConceptos.base3.Text = "0,00"
                        FrmOtrosConceptos.cta3.Text = gitems.Item("cta", mifila).Value.ToString
                        FrmOtrosConceptos.lbdoc3.Text = gitems.Item("doc", mifila).Value.ToString
                    End If
            End Select
            Me.Close()
            gitems.Focus()
            sw = 1
            Me.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = 0 To gitems.RowCount - 1
                If gitems.Item(1, i).Value.ToString Like "*" & cad & "*" Then
                    Dim C As Integer = 1, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    gitems.Focus()
                    Exit Sub
                End If
            Next
            MsgBox("No hay coincidencias en la busquedad.", MsgBoxStyle.Information, "SAE")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Select Case e.ColumnIndex
            Case 5 'precio
                Try
                    gitems.Item(5, e.RowIndex).Value = Moneda(gitems.Item(5, e.RowIndex).Value)
                    If CDbl(gitems.Item(5, e.RowIndex).Value) > CDbl(gitems.Item("disponible", e.RowIndex).Value) Then
                        MsgBox("El monto a utilizar no puede ser mayor que el monto disponible, verifique.", MsgBoxStyle.Information, "SAE Control")
                        gitems.Item(5, e.RowIndex).Value = Moneda(gitems.Item("disponible", e.RowIndex).Value)
                    ElseIf CDbl(gitems.Item(5, e.RowIndex).Value) < 0 Then
                        MsgBox("El monto a utilizar no puede ser menor que cero (0), verifique.", MsgBoxStyle.Information, "SAE Control")
                        gitems.Item(5, e.RowIndex).Value = Moneda("0")
                    End If
                Catch ex As Exception
                    gitems.Item(5, e.RowIndex).Value = Moneda("0")
                End Try
        End Select
    End Sub
End Class