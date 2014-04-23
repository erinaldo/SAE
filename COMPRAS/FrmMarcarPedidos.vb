Public Class FrmMarcarPedidos
    Private Sub FrmMarcarPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grilla.Rows.Clear()
        txtnit.Text = ""
        txtcliente.Text = ""
        txtnumfac.Text = ""
        lbsel.Text = "no"
        lbcumplido.Text = ""
        cmdguardar.Enabled = False
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If lbcumplido.Text = "si" Then
            MsgBox("El pedido ya fué marcado como cumplido. ", MsgBoxStyle.Information)
        Else
            Validar()
        End If
    End Sub
    Public Sub Validar()
        MiConexion(bda)
        Dim cant As Integer = 0
        For i = 0 To grilla.Rows.Count - 1
            Try
                If CDbl(grilla.Item("pedida", i).Value) <= CDbl(grilla.Item("recibida", i).Value) Then
                    cant = cant + 1
                End If
                If CDbl(grilla.Item("recibida", i).Value) <> CDbl(grilla.Item("recibida2", i).Value) Then
                    Guardar(i)
                End If
            Catch ex As Exception
            End Try
        Next
        If cant = grilla.Rows.Count Then
            MarcarCumplido()
        End If
        cmdguardar.Enabled = False
        MsgBox("La base de datos se actualizo correctamente. ", MsgBoxStyle.Information)
        Cerrar()
    End Sub
    Public Sub Guardar(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantrec", DIN(CDbl(grilla.Item("recibida", fila).Value)))
            myCommand.CommandText = "UPDATE pedi_comp SET cantrec=?cantrec WHERE numero='" & txtnumfac.Text & "' AND item='" & grilla.Item("item", fila).Value & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MarcarCumplido()
        Try
            lbcumplido.Text = "si"
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cumplido", "si")
            myCommand.CommandText = "UPDATE pedi_comp SET cumplido=?cumplido WHERE numero='" & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        lbsel.Text = "no"
        FrmSelPediPen.lbform.Text = "marcar_ped"
        FrmSelPediPen.ShowDialog()
        If lbsel.Text = "si" Then
            cmdBuscar_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT p.*,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM pedi_comp p LEFT JOIN (terceros t) ON p.nitc=t.nit WHERE p.numero='" & txtnumfac.Text & "' ORDER BY p.item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                cmdguardar.Enabled = False
                grilla.Rows.Clear()
                lbfecha.Text = ""
                lbfecha2.Text = ""
                txtcliente.Text = ""
                txtnit.Text = ""
                lbcumplido.Text = ""
                MsgBox("El numero nose encuentra en los pedidos por cumplir.  ", MsgBoxStyle.Information)
            Else
                cmdguardar.Enabled = True
                lbfecha.Text = CambiaCadena(tabla.Rows(0).Item("fechaped").ToString, 10)
                lbfecha2.Text = CambiaCadena(tabla.Rows(0).Item("fecharec").ToString, 10)
                txtcliente.Text = tabla.Rows(0).Item("nomnit")
                txtnit.Text = tabla.Rows(0).Item("nitc")
                lbcumplido.Text = tabla.Rows(0).Item("cumplido")
                grilla.Rows.Clear()
                grilla.RowCount = tabla.Rows.Count
                For i = 0 To tabla.Rows.Count - 1
                    grilla.Item("tipo", i).Value = tabla.Rows(i).Item("tipo")
                    grilla.Item("codigo", i).Value = tabla.Rows(i).Item("cod_art")
                    grilla.Item("concepto", i).Value = tabla.Rows(i).Item("nom_art")
                    grilla.Item("pedida", i).Value = Moneda(tabla.Rows(i).Item("cantped"))
                    grilla.Item("recibida", i).Value = Moneda(tabla.Rows(i).Item("cantrec"))
                    grilla.Item("recibida2", i).Value = Moneda(tabla.Rows(i).Item("cantrec"))
                    grilla.Item("item", i).Value = Moneda(tabla.Rows(i).Item("item"))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            cmdguardar.Enabled = True
        End Try

    End Sub

    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        If txtnumfac.Text = "" Or txtnumfac.Text = "00000" Then
            cmdguardar.Enabled = False
            grilla.Rows.Clear()
            lbfecha.Text = ""
            lbfecha2.Text = ""
            txtcliente.Text = ""
            txtnit.Text = ""
            lbcumplido.Text = ""
        Else
            Try
                txtnumfac.Text = NumeroDoc(txtnumfac.Text)
            Catch ex As Exception
            End Try
            cmdBuscar_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub txtnumfac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumfac.TextChanged
        cmdguardar.Enabled = False
        grilla.Rows.Clear()
        lbfecha.Text = ""
        lbfecha2.Text = ""
        txtcliente.Text = ""
        txtnit.Text = ""
        lbcumplido.Text = ""
    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        grilla.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(grilla.Item(e.ColumnIndex, e.RowIndex).Value)
    End Sub
End Class