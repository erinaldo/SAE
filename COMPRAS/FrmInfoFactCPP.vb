Public Class FrmInfoFactCPP

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        ValidarNIT(txtnit, e)
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtcliente.Text = "" Then cargarclientes()
    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "cpp_inf_fac"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmInfoFactCPP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM par_comp LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Me.Close()
            Exit Sub
        Else
            If Trim(tabla.Rows(0).Item("doc_fp").ToString) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fp").ToString))
                txttipo.Text = Trim(tabla.Rows(0).Item("doc_fp").ToString)
                txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
            End If
        End If
        txtnit.Text = ""
        lbfecha.Text = ""
        lbvalor.Text = "0,00"
        lbvmto.Text = ""
        lbsaldo.Text = "0,00"
        lbpagado.Text = "0,00"
        txtnumfac.Text = ""
        grilla.Rows.Clear()
    End Sub

    Private Sub txttipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Trim(txttipo.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txttipo2.Text = ""
            Else
                txttipo2.Text = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        Try
            txtnumfac.Text = NumeroDoc(txtnumfac.Text)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        If Trim(txttipo2.Text) = "" Then
            MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
        ElseIf Trim(txtcliente.Text) = "" Then
            MsgBox("Verifique documento del proveedor.  ", MsgBoxStyle.Information, "SAE Control")
            txtnit.Focus()
        Else
            lbsel.Text = "no"
            FrmSelFacturaCompra.lbform.Text = "cpp_inf_fac"
            FrmSelFacturaCompra.ShowDialog()
            If lbsel.Text = "si" Then cmdBuscar_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If Trim(txttipo2.Text) = "" Then
            MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
        ElseIf Trim(txtnumfac.Text) = "" Or Trim(txtnumfac.Text) = "00000" Then
            MsgBox("Verifique el numero de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txtnumfac.Focus()
        Else
            BuscarDoc()
        End If
    End Sub
    Public Sub BuscarDoc()
        Dim items As Integer
        Dim tabla As New DataTable
        grilla.Rows.Clear()
        myCommand.CommandText = " SELECT num,doc_ext,nitc,nomnit,doc,fecha,total,vmto,pagado,(total - pagado) AS saldo FROM ctas_x_pagar WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            lbfecha.Text = ""
            lbvalor.Text = "0,00"
            lbvmto.Text = ""
            lbsaldo.Text = "0,00"
            lbpagado.Text = "0,00"
            MsgBox("El Docuemnto No Existe en Cuentas Por Pagar.  ", MsgBoxStyle.Information)
        Else
            Try
                txtnit.Text = tabla.Rows(0).Item("nitc").ToString
                lbfecha.Text = tabla.Rows(0).Item("fecha").ToString
                lbvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtdoc_ext.Text = tabla.Rows(0).Item("doc_ext").ToString
                txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num").ToString)
                lbdoc_i.Text = tabla.Rows(0).Item("doc").ToString
                lbdoc_e.Text = tabla.Rows(0).Item("doc_ext").ToString
                Dim t As String = ""
                lbvmto.Text = CDate(tabla.Rows(0).Item("fecha").ToString).AddDays(Val(tabla.Rows(0).Item("vmto")))
                lbsaldo.Text = Moneda(tabla.Rows(0).Item("saldo"))
                lbpagado.Text = Moneda(tabla.Rows(0).Item("pagado"))
                Dim j As Integer = -1
                grilla.RowCount = 200
                For p = 1 To 12
                    tabla.Clear()
                    If p < 10 Then
                        t = "ot_cpp0" & p
                    Else
                        t = "ot_cpp" & p
                    End If
                    myCommand.CommandText = " SELECT doc,concepto,dia,periodo,abonado FROM " & t & " WHERE doc_afec='" & txttipo.Text & txtnumfac.Text & "' AND estado='AP' AND abonado>'0';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    For i = 0 To tabla.Rows.Count - 1
                        j = j + 1
                        grilla.Item("doc", j).Value = tabla.Rows(i).Item("doc")
                        grilla.Item("concepto", j).Value = tabla.Rows(i).Item("concepto")
                        grilla.Item("fecha", j).Value = tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("periodo").ToString
                        grilla.Item("valor", j).Value = Moneda(tabla.Rows(i).Item("abonado"))
                    Next
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            grilla.CurrentCell = grilla(0, 1)
            grilla.Focus()
            SendKeys.Send("{UP}")
        End If
    End Sub

    Private Sub txtdoc_ext_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc_ext.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc_ext_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc_ext.LostFocus
        BuscarDocExt()
    End Sub

    Private Sub cmdBuscarExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarExt.Click
        BuscarDocExt()
    End Sub
    Public Sub BuscarDocExt()
        Dim items As Integer
        Dim tabla As New DataTable
        grilla.Rows.Clear()
        myCommand.CommandText = " SELECT num,doc_ext,nitc,nomnit,doc,fecha,total,vmto,pagado,(total - pagado) AS saldo FROM ctas_x_pagar WHERE doc_ext='" & txtdoc_ext.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtnit.Text = ""
            lbfecha.Text = ""
            lbvalor.Text = "0,00"
            lbvmto.Text = ""
            lbsaldo.Text = "0,00"
            lbpagado.Text = "0,00"
            MsgBox("El Docuemnto Externo No Existe en Cuentas Por Pagar.  ", MsgBoxStyle.Information)
        Else
            Try
                txtnit.Text = tabla.Rows(0).Item("nitc").ToString
                lbfecha.Text = tabla.Rows(0).Item("fecha").ToString
                lbvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtdoc_ext.Text = tabla.Rows(0).Item("doc_ext").ToString
                txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num").ToString)
                lbdoc_i.Text = tabla.Rows(0).Item("doc").ToString
                lbdoc_e.Text = tabla.Rows(0).Item("doc_ext").ToString
                Dim t As String = ""
                lbvmto.Text = CDate(tabla.Rows(0).Item("fecha").ToString).AddDays(Val(tabla.Rows(0).Item("vmto")))
                lbsaldo.Text = Moneda(tabla.Rows(0).Item("saldo"))
                lbpagado.Text = Moneda(tabla.Rows(0).Item("pagado"))
                Dim j As Integer = -1
                grilla.RowCount = 200
                For p = 1 To 12
                    tabla.Clear()
                    If p < 10 Then
                        t = "ot_cpp0" & p
                    Else
                        t = "ot_cpp" & p
                    End If
                    myCommand.CommandText = " SELECT doc,concepto,dia,periodo,abonado FROM " & t & " WHERE doc_afec='" & txttipo.Text & txtnumfac.Text & "' AND estado='AP' AND abonado>'0';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    For i = 0 To tabla.Rows.Count - 1
                        j = j + 1
                        grilla.Item("doc", j).Value = tabla.Rows(i).Item("doc")
                        grilla.Item("concepto", j).Value = tabla.Rows(i).Item("concepto")
                        grilla.Item("fecha", j).Value = tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("periodo").ToString
                        grilla.Item("valor", j).Value = Moneda(tabla.Rows(i).Item("abonado"))
                    Next
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            grilla.CurrentCell = grilla(0, 1)
            grilla.Focus()
            SendKeys.Send("{UP}")
        End If
    End Sub

   
    Private Sub txtnumfac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumfac.TextChanged

    End Sub
End Class