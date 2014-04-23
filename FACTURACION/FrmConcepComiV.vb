Public Class FrmConcepComiV

    Dim f As Integer = 0

    Private Sub FrmConcepComiV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nit As String = ""
        Dim sql As String = ""
        If lbform.Text = "fr" Then
            lbvend.Text = "VENDEDOR: " & Frmfacturarapida.txtvendedor.Text
            nit = Frmfacturarapida.txtnitv.Text
        ElseIf lbform.Text = "frs" Then
            Try
                Dim tv As New DataTable
                myCommand.CommandText = "SELECT nitv, nombre  FROM  vendedores WHERE nitv='" & FrmItemsEst.gitems.Item(15, CInt(lbfila.Text)).Value & "' AND estado='activo' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tv)
                Refresh()
                lbvend.Text = "VENDEDOR: " & tv.Rows(0).Item("nombre")
                nit = FrmItemsEst.gitems.Item(15, CInt(lbfila.Text)).Value
            Catch ex As Exception
            End Try
        Else
            lbvend.Text = "VENDEDOR: " & FrmFacturasyAjustes.txtvendedor.Text
            nit = FrmFacturasyAjustes.txtnitv.Text
        End If

        Try

            sql = " SELECT  v.codcon, c.concepto, v.porcomi, v.dia_cob FROM vend_cc v, concomi c WHERE v.nitv = '" & nit & "' AND v.codcon = c.codcon "
            gitems.Rows.Clear()
            Dim tabla2 As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            For i = 0 To tabla2.Rows.Count - 1
                gitems.Rows.Add(tabla2.Rows(i).Item(0), tabla2.Rows(i).Item(1), tabla2.Rows(i).Item(2), tabla2.Rows(i).Item(3))
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click

        seleccionar(f)




    End Sub

    Public Sub seleccionar(ByVal fo As Integer)
        If gitems.Item(1, f).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "frs"
                FrmItemsEst.gitems.Item("codcom", FrmItemsEst.fila).Value = gitems.Item("CODIGO", f).Value
            Case Else
                FrmItems.gitems.Item("cc", FrmItems.fila).Value = gitems.Item("CODIGO", f).Value
        End Select
        Me.Close()
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(f)
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        f = e.RowIndex        'captura fila
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(f - 1)
        End If
    End Sub
End Class