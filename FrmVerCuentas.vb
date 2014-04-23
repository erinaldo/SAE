Public Class FrmVerCuentas
    Public fil As Integer

    Public Sub BuscarCuenta(ByVal cuenta As String, ByVal n As Integer)
        If cuenta = "" Then Exit Sub
        FrmCatalogoC.lbaux.Visible = False
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        FrmCatalogoC.grilla.ReadOnly = True
        FrmCatalogoC.txtcuenta.ReadOnly = True
        FrmCatalogoC.txtdesc.ReadOnly = True
        FrmCatalogoC.txtcuenta.Text = tabla.Rows(0).Item("codigo")
        FrmCatalogoC.txtdesc.Text = tabla.Rows(0).Item("descripcion")
        FrmCatalogoC.txtsaldo.Text = Format(Math.Round(CDec(tabla.Rows(0).Item("saldo")), 2), "0,00.00")
        FrmCatalogoC.cbnivel.Text = tabla.Rows(0).Item("nivel")
        FrmCatalogoC.txtnat.Text = tabla.Rows(0).Item("naturaleza")
        FrmCatalogoC.cbtipo.Text = tabla.Rows(0).Item("tipo")
        FrmCatalogoC.lbestado.Text = "CONSULTA"
        FrmCatalogoC.lbnroobs.Text = n
        Me.Close()
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        BuscarCuenta(gitems.Item(1, e.RowIndex).Value, e.RowIndex + 1)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(gitems.Item(1, fil - 1).Value, fil)
        End If
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        BuscarCuenta(gitems.Item(1, fil).Value, fil + 1)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        Else
            validarnumero(txtcuenta, e)
        End If
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 2
            aux = gitems.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 1, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    cmditems_Click(AcceptButton, AcceptButton)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub FrmVerCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
End Class