Public Class FrmConUnaFC

    Private Sub FrmConUnaFC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '************************************
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT par_fac1,par_fac2,par_fac3,par_fac4 FROM car_par LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros de cartera definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Me.Close()
            Exit Sub
        Else
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("par_fac1")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac1")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac2")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac2")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac3")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac3")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac4")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac4")))
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
    '***************************************
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
            FrmSelCliente.lbform.Text = "cpc_1_FC"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '***************************************************
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
            txtnumfac.Text = NumeroDoc(0)
        End Try
    End Sub
    '***********************************************************
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        If Trim(txttipo2.Text) = "" Then
            MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
        ElseIf Trim(txtcliente.Text) = "" Then
            MsgBox("Verifique documento del proveedor.  ", MsgBoxStyle.Information, "SAE Control")
            txtnit.Focus()
        Else
            lbsel.Text = "no"
            FrmSelFacturaCartera.lbform.Text = "cpp_inf_fac"
            FrmSelFacturaCartera.ShowDialog()
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
        myCommand.CommandText = " SELECT num,nitc,nomnit,doc,fecha,total,vmto,pagado,(total - pagado) AS saldo FROM cobdpen WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
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
            MsgBox("El Docuemnto No Existe en Cuentas Por Cobrar.  ", MsgBoxStyle.Information)
        Else
            Try
                txtnit.Text = tabla.Rows(0).Item("nitc").ToString
                lbfecha.Text = tabla.Rows(0).Item("fecha").ToString
                lbvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num").ToString)
                lbdoc_i.Text = tabla.Rows(0).Item("doc").ToString
                Dim t As String = ""
                lbvmto.Text = CDate(tabla.Rows(0).Item("fecha").ToString).AddDays(Val(tabla.Rows(0).Item("vmto")))
                lbsaldo.Text = Moneda(tabla.Rows(0).Item("saldo"))
                lbpagado.Text = Moneda(tabla.Rows(0).Item("pagado"))
                Dim j As Integer = -1
                grilla.RowCount = 200
                For p = 1 To 12
                    tabla.Clear()
                    If p < 10 Then
                        t = "ot_cpc0" & p
                    Else
                        t = "ot_cpc" & p
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
    '***********************************************************

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class