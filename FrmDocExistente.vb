Public Class FrmDocExistente
    Private Sub FrmDocExistente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumero.Text = ""
        txtdoc.Text = ""
        txtnomdoc.Text = ""
        txtdb.Text = "0,00"
        txtcr.Text = "0,00"
        txtdif.Text = "0,00"
        txtcentro.Text = ""
        txtncentro.Text = ""
        grilla.ReadOnly = False
        grilla.Item(0, 0).Selected = True
        grilla.Item(0, 0).Selected = False
        grilla.RowCount = 1
        grilla.Item(0, 0).Value = ""
        grilla.Item(1, 0).Value = "0,00"
        grilla.Item(2, 0).Value = "0,00"
        grilla.Item(3, 0).Value = ""
        grilla.Item(4, 0).Value = "0,00"
        grilla.Item(5, 0).Value = "0"
        grilla.Item(6, 0).Value = "00/00/0000"
        grilla.Item(7, 0).Value = ""
    End Sub

    Private Sub cbper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbper.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc.LostFocus
        If txtdoc.Text = "CA" Then
            txtnomdoc.Text = "CIERRE ANUAL"
        Else
            Dim tabla As New DataTable
            txtdoc.Text = Trim(txtdoc.Text)
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "' AND grupo<>'SI' ORDER BY tipodoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtnomdoc.Text = tabla.Rows(0).Item("descripcion")
            Else
                txtnomdoc.Text = ""
                Try
                    FrmTipoTransaccion.lbform.Text = "doc_exi"
                    FrmTipoTransaccion.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        validarnumero(txtnumero, e)
    End Sub
    Private Sub txtnumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumero.LostFocus
        Try
            txtnumero.Text = NumeroDoc(txtnumero.Text)
        Catch ex As Exception
            txtnumero.Text = NumeroDoc("0")
        End Try
    End Sub
    
    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        txtdb.Text = "0,00"
        txtcr.Text = "0,00"
        txtdif.Text = "0,00"
        txtcentro.Text = ""
        txtncentro.Text = ""
        grilla.ReadOnly = False
        grilla.Item(0, 0).Selected = True
        grilla.Item(0, 0).Selected = False
        grilla.RowCount = 1
        grilla.Item(0, 0).Value = ""
        grilla.Item(1, 0).Value = "0,00"
        grilla.Item(2, 0).Value = "0,00"
        grilla.Item(3, 0).Value = ""
        grilla.Item(4, 0).Value = "0,00"
        grilla.Item(5, 0).Value = "0"
        grilla.Item(6, 0).Value = "00/00/0000"
        grilla.Item(7, 0).Value = ""
        If txtnomdoc.Text = "" Then
            MsgBox("verifique el tipo de documento.   ", MsgBoxStyle.Information)
            txtdoc.Focus()
        ElseIf Val(txtnumero.Text) = 0 Then
            MsgBox("verifique el numero del documento.   ", MsgBoxStyle.Information)
            txtnumero.Focus()
        Else
            BuscarDocumento()
        End If
    End Sub
    Public Sub BuscarDocumento()
        Try

            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM documentos" & Trim(cbper.Text) & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & Trim(txtdoc.Text) & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("El documento no existe en el periodo( " & Trim(cbper.Text) & " ), verifique.  ", MsgBoxStyle.Information)
                Exit Sub
            End If
            If txtdoc.Text = "CA" Then
                txtnomdoc.Text = "CIERRE ANUAL"
            End If
            txtdia.Text = tabla.Rows(0).Item("dia")
            txtperiodo.Text = "/" & tabla.Rows(0).Item("periodo")
            Try
                If tabla.Rows(0).Item("centro") > 0 Then
                    txtcentro.Text = tabla.Rows(0).Item("centro")
                Else
                    txtcentro.Text = ""
                End If
            Catch ex As Exception
                txtcentro.Text = ""
            End Try
            txtncentro.Text = BuscarCentroCostos(txtcentro.Text)
            Dim db As Double = 0
            Dim cr As Double = 0
            grilla.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
                grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
                grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
                grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
                grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
                grilla.Item(5, i).Value = tabla.Rows(i).Item("diasv")
                grilla.Item(6, i).Value = tabla.Rows(i).Item("fechaven")
                grilla.Item(7, i).Value = tabla.Rows(i).Item("nit")
                Try
                    If tabla.Rows(i).Item("centro") = 0 Then
                        grilla.Item(8, i).Value = ""
                    Else
                        grilla.Item(8, i).Value = tabla.Rows(i).Item("centro")
                    End If
                Catch ex As Exception
                    grilla.Item(8, i).Value = ""
                End Try
                Try
                    db = db + CDbl(tabla.Rows(i).Item("debito"))
                Catch ex As Exception
                End Try
                Try
                    cr = cr + CDbl(tabla.Rows(i).Item("credito"))
                Catch ex As Exception
                End Try
            Next
            txtdb.Text = Moneda(db)
            txtcr.Text = Moneda(cr)
            txtdif.Text = Moneda(db - cr)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinuar.Click
        CmdBuscar_Click(AcceptButton, AcceptButton)
        If grilla.RowCount > 1 Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("¿Seguro que desea usar el docuemento " & txtdoc.Text & txtnumero.Text & "?   ", MsgBoxStyle.YesNo, "Confirmar Uso")
            If resultado = MsgBoxResult.No Then Exit Sub
            FrmEntradaDatos.lbestado.Text = "NUEVO"
            FrmEntradaDatos.TxtDocumento.Text = txtdoc.Text
            If Val(Today.Day) < 10 Then
                FrmEntradaDatos.txtdia.Text = "0" & Today.Day
            Else
                FrmEntradaDatos.txtdia.Text = Today.Day
            End If
            FrmEntradaDatos.txtperiodo.Text = "/" & PerActual
            Try
                Dim fe As Date = CDate(Today.Day.ToString & "/" & PerActual)
            Catch ex As Exception
                If PerActual(0) & PerActual(1) = "02" Then
                    FrmEntradaDatos.txtdia.Text = "28"
                Else
                    FrmEntradaDatos.txtdia.Text = "30"
                End If
            End Try
            FrmEntradaDatos.txtcentro.Text = txtcentro.Text
            FrmEntradaDatos.txtncentro.Text = txtncentro.Text
            FrmEntradaDatos.txtnit.Text = grilla.Item(7, 0).Value
            FrmEntradaDatos.grilla.RowCount = grilla.RowCount
            For i = 0 To grilla.RowCount - 1
                Try

               
                    FrmEntradaDatos.grilla.Item(0, i).Value = grilla.Item(0, i).Value
                    Try
                        FrmEntradaDatos.grilla.Item(1, i).Value = grilla.Item(1, i).Value
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(1, i).Value = "0"
                    End Try

                    Try
                        FrmEntradaDatos.grilla.Item(2, i).Value = grilla.Item(2, i).Value
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(2, i).Value = "0"
                    End Try

                    FrmEntradaDatos.grilla.Item(3, i).Value = grilla.Item(3, i).Value
                    Try
                        FrmEntradaDatos.grilla.Item(4, i).Value = grilla.Item(4, i).Value
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(4, i).Value = ""
                    End Try

                    FrmEntradaDatos.grilla.Item(5, i).Value = grilla.Item(5, i).Value
                    Dim f As Date
                    Try
                        f = CDate(FrmEntradaDatos.txtdia.Text & "/" & PerActual)
                    Catch ex As Exception
                        If PerActual(0) & PerActual(1) = "02" Then
                            f = "28/" & PerActual
                        Else
                            f = "30/" & PerActual
                        End If
                    End Try
                    Try
                        FrmEntradaDatos.grilla.Item(6, i).Value = f.AddDays(Val(grilla.Item(5, i).Value))
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(6, i).Value = f.AddDays(0)
                    End Try
                    Try
                        FrmEntradaDatos.grilla.Item(6, i).Value = f.AddDays(Val(grilla.Item(5, i).Value))
                        FrmEntradaDatos.grilla.Item(7, i).Value = grilla.Item(7, i).Value
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(6, i).Value = ""
                        FrmEntradaDatos.grilla.Item(7, i).Value = ""
                    End Try
                    
                    Try
                        FrmEntradaDatos.grilla.Item(8, i).Value = grilla.Item(8, i).Value
                    Catch ex As Exception
                        FrmEntradaDatos.grilla.Item(8, i).Value = 0
                    End Try
                    FrmEntradaDatos.grilla.Item("cheque", i).Value = ""
                Catch ex As Exception

                End Try
            Next
            Me.Close()
        End If
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

   

    Private Sub cmdTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTodos.Click
        If Trim(txtnomdoc.Text) = "" Then
            MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txtdoc.Focus()
        Else
            FrmSelExistente.lbper.Text = cbper.Text
            FrmSelExistente.lbform.Text = "doc_exi"
            FrmSelExistente.lbdoc.Text = txtdoc.Text
            lbsel.Text = "no"
            FrmSelExistente.ShowDialog()
            If lbsel.Text = "si" Then
                CmdBuscar_Click(AcceptButton, AcceptButton)
            End If
        End If
    End Sub
End Class