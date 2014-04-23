Public Class FrmEgresoNomina

    Private Sub FrmEgresoNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TipoDoc()
        cbper.Text = PerActual(0) & PerActual(1)
        grilla.Rows.Clear()
        txtnumero.Text = ""
    End Sub
    Public Sub TipoDoc()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc_cpp FROM  par_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtdoc.Text = tabla.Rows(0).Item("doc_cpp")
            Else
                txtdoc.Text = "CE"
            End If
            tabla.Clear()
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtnomdoc.Text = tabla.Rows(0).Item("descripcion")
            Else
                txtnomdoc.Text = "COMPROBANTE DE EGRESO"
            End If
        Catch ex As Exception

        End Try
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
        grilla.ReadOnly = False
        grilla.Item(0, 0).Selected = True
        grilla.Item(0, 0).Selected = False
        grilla.RowCount = 1
        grilla.Item(0, 0).Value = ""
        grilla.Item(1, 0).Value = "0,00"
        grilla.Item(2, 0).Value = "0,00"
        grilla.Item(3, 0).Value = ""
        grilla.Item(4, 0).Value = "0,00"
        grilla.Item(5, 0).Value = ""
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
            '++++++++++++++++++++++++++++++++++++++++++++++++
            grilla.Columns(0).ReadOnly = True
            grilla.Columns(1).ReadOnly = True
            grilla.Columns(2).ReadOnly = True
            grilla.Columns(3).ReadOnly = True
            grilla.Columns(4).ReadOnly = True
            grilla.Columns(5).ReadOnly = True
            '+++++++++++++++++++++++++++++++++++++++++++++++++
            Dim cta As String = ""
            grilla.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
                grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
                grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
                grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
                grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
                grilla.Item(5, i).Value = tabla.Rows(i).Item("nit")
                cta = tabla.Rows(i).Item("codigo")
                If cta(0) = "2" Then
                    grilla.Item("dg", i).Value = "Desenglobar"
                Else
                    grilla.Item("dg", i).Value = "    ----    "
                End If
            Next
          
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick
        Select Case e.ColumnIndex
            Case 7
                If grilla.Item("dg", e.RowIndex).Value = "Desenglobar" Then
                    FrmDesNomina.lbcta.Text = grilla.Item("Cuenta", e.RowIndex).Value
                    FrmDesNomina.lbcuenta.Text = lbcuenta.Text
                    FrmDesNomina.lbdoc.Text = cbper.Text & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "-" & txtdoc.Text & txtnumero.Text
                    If grilla.Item("Debitos", e.RowIndex).Value = "0,00" Then
                        FrmDesNomina.lbvalor.Text = Moneda(grilla.Item("Creditos", e.RowIndex).Value)
                    Else
                        FrmDesNomina.lbvalor.Text = Moneda(grilla.Item("Debitos", e.RowIndex).Value)
                    End If
                    FrmDesNomina.ShowDialog()
                Else
                    MsgBox("La cuenta " & grilla.Item("Cuenta", e.RowIndex).Value & " No se puede desenglobar.")
                End If
            Case 6
        End Select
        

    End Sub

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        BuscarCta(e.RowIndex)
    End Sub
    Public Sub BuscarCta(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & grilla.Item(3, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcuenta.Text = tabla.Rows(0).Item("codigo").ToString & " " & tabla.Rows(0).Item("descripcion").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbcuenta.Text = ""
        End Try
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ape FROM terceros WHERE nit='" & grilla.Item(5, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbtercero.Text = tabla.Rows(0).Item("ape").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbtercero.Text = ""
        End Try
    End Sub

    Private Sub cmdTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTodos.Click
        If Trim(txtnomdoc.Text) = "" Then
            MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txtdoc.Focus()
        Else
            FrmSelExistente.lbper.Text = cbper.Text
            FrmSelExistente.lbform.Text = "doc_exi2"
            FrmSelExistente.lbdoc.Text = txtdoc.Text
            lbsel.Text = "no"
            FrmSelExistente.ShowDialog()
            If lbsel.Text = "si" Then
                CmdBuscar_Click(AcceptButton, AcceptButton)
            End If
        End If
    End Sub
End Class