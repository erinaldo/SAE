Public Class FrmSelCiorden
    Public fila As Integer
    Dim tabla As New DataTable
    Private Sub FrmSelCiorden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tabla.Clear()
        myCommand.CommandText = " SELECT * from otdoc_pres "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
            Exit Sub
        Else

            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item("num")
                gitems.Item(1, i).Value = tabla.Rows(i).Item("rb_cod1")
                gitems.Item(2, i).Value = tabla.Rows(i).Item("rb_cod2")
                gitems.Item(3, i).Value = tabla.Rows(i).Item("nitc") & " " & tabla.Rows(i).Item("nombre")
                gitems.Item(4, i).Value = Strings.Left(tabla.Rows(i).Item("fecha").ToString, 10)
                gitems.Item(5, i).Value = tabla.Rows(i).Item("concepto")
                gitems.Item(6, i).Value = Moneda(tabla.Rows(i).Item("valor"))
                gitems.Item(7, i).Value = tabla.Rows(i).Item("doc_ci") & NumeroDoc(tabla.Rows(i).Item("num_ci"))
                gitems.Item(8, i).Value = tabla.Rows(i).Item("doc_rc") & NumeroDoc(tabla.Rows(i).Item("num_rc"))
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        End If
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
       
        Select Case lbform.Text
            Case "ciorden"
                FrmCIordenes.lbestado.Text = "CONSULTA"
                FrmCIordenes.txtnum.Text = tabla.Rows(fila).Item("num")
                FrmCIordenes.txtrb1.Text = gitems.Item("rbcod1", fila).Value
                FrmCIordenes.txtrb.Text = gitems.Item("rbcod2", fila).Value
                FrmCIordenes.txtnomrb.Text = tabla.Rows(fila).Item("rb")
                FrmCIordenes.txtnit.Text = tabla.Rows(fila).Item("nitc")
                FrmCIordenes.txtnomt.Text = tabla.Rows(fila).Item("nombre")
                FrmCIordenes.txtdia.Text = Strings.Left(gitems.Item("fecha", fila).Value, 2)
                FrmCIordenes.cbper.Text = Strings.Mid(gitems.Item("fecha", fila).Value, 4, 2)
                FrmCIordenes.txtperiodo.Text = "/" & Strings.Right(gitems.Item("fecha", fila).Value, 4)
                FrmCIordenes.txtconcepto.Text = gitems.Item("concepto", fila).Value
                FrmCIordenes.txtvalor.Text = gitems.Item("valor", fila).Value
                FrmCIordenes.txtDip.Text = tabla.Rows(fila).Item("doc_ci")
                FrmCIordenes.txtnumIP.Text = tabla.Rows(fila).Item("num_ci")
                FrmCIordenes.txtDrc.Text = tabla.Rows(fila).Item("doc_rc")
                FrmCIordenes.txtnumRC.Text = tabla.Rows(fila).Item("num_ci")
                If tabla.Rows(fila).Item("tipoing") = 1 Then
                    FrmCIordenes.i1.Checked = True
                Else
                    FrmCIordenes.i2.Checked = True
                End If
                Me.Close()
        End Select
        Me.Close()
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
End Class