Public Class frmseltipodoccar
    Public fila As Integer
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Public Sub seleccionar(ByVal f As Integer)
        If gitems.Item(1, f).Value() = "" Then Exit Sub
        Select Case lbtipo.Text
            Case "1"
                frmparametroscartera.txttipo1.Text = gitems.Item(0, f).Value()
            Case "2"
                frmparametroscartera.txttipo2.Text = gitems.Item(0, f).Value()
            Case "3"
                frmparametroscartera.txttipo3.Text = gitems.Item(0, f).Value()
            Case "4"
                frmparametroscartera.txttipo4.Text = gitems.Item(0, f).Value()
            Case "A"
                frmparametroscartera.txtajust.Text = gitems.Item(0, f).Value()
            Case "B"
                frmparametroscartera.txtrc.Text = gitems.Item(0, f).Value()
            Case "C"
                frmparametroscartera.txtrcc.Text = gitems.Item(0, f).Value()
        End Select
        Me.Close()
    End Sub

    Private Sub frmseltipodoccar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc ORDER BY tipodoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay documentos creados, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        gitems.Rows.Clear()
        gitems.RowCount = items
        For i = 0 To items - 1
            gitems.Item(0, i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item(1, i).Value = tabla.Rows(i).Item("grupo")
            gitems.Item(2, i).Value = tabla.Rows(i).Item("descripcion")
        Next
    End Sub
End Class