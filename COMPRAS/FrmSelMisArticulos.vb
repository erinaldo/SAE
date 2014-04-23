Public Class FrmSelMisArticulos

    Private Sub FrmSelMisArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT codart,nomart,nivel FROM articulos ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(0, i).Value = tabla2.Rows(i).Item("codart")
                gitems.Item(1, i).Value = Trim(tabla2.Rows(i).Item("nomart"))
                gitems.Item(2, i).Value = tabla2.Rows(i).Item("nivel")
            Next
            BuscarGrilla(txtcuenta.Text)
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            Dim cad2, aux As String
            For i = 0 To gitems.RowCount - 1
                aux = gitems.Item(1, i).Value.ToString
                If Val(aux.Length) >= Val(cad.Length) Then
                    cad2 = ""
                    For j = 0 To cad.Length - 1
                        cad2 = cad2 & aux(j)
                    Next
                    If cad = cad2 Then
                        Dim C As Integer = 1, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                End If
            Next
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
    Public fila As Integer
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
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
            If gitems.Item(1, mifila).Value = "" Then Exit Sub
            Select Case lbform.Text
                Case "info_art_gas"
                    FrmInfoArtGas.txtart.Text = gitems.Item("codigo", mifila).Value
                    FrmInfoArtGas.txtnomart.Text = gitems.Item("nombre", mifila).Value
                Case ""

            End Select
            Me.Close()
            gitems.Focus()
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class