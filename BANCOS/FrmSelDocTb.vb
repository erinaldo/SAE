Public Class FrmSelDocTb
    Public fila As Integer
    Private Sub FrmSelDocTb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim j As Integer = -1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT d.*, s.descripcion as cta " _
            & " FROM documentos" & PerActual(0) & PerActual(1) & " d LEFT JOIN selpuc s " _
            & " ON d.codigo=s.codigo WHERE  tipodoc='" & lbdoc.Text & "' ORDER BY tipodoc,doc,item; "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            gcuenta.RowCount = 1
            If tabla.Rows.Count = 0 Then
                MsgBox("No se han creado documentos...  ", MsgBoxStyle.Information, "Buscar Documentos")
                Exit Sub
            End If
            For i = 0 To tabla.Rows.Count - 1
                If (i Mod 2) = 0 Then
                    gcuenta.RowCount = gcuenta.RowCount + 1
                    j = j + 1
                    gcuenta.Item("doc", j).Value = NumeroDoc(tabla.Rows(i).Item("doc"))
                    gcuenta.Item("fecha", j).Value = tabla.Rows(i).Item("dia") & "/" & PerActual
                    gcuenta.Item("origen", j).Value = tabla.Rows(i).Item("cta")
                    gcuenta.Item("monto", j).Value = Moneda(tabla.Rows(i).Item("credito"))
                    gcuenta.Item("destino", j).Value = tabla.Rows(i + 1).Item("cta")
                End If
            Next
            With gcuenta
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            Select Case lbform.Text
                Case "tb"
                    FrmTransacciones.TxtNumero.Text = gcuenta.Item(1, fila).Value()
                    FrmTransacciones.lbestado.Text = "CONSULTA"
                    FrmTransacciones.lbnroobs.Text = fila + 1
               
            End Select
            gcuenta.Focus()
            Me.Close()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        cmditems_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub gcuenta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO BUSCAR
                Case 1
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                Case 2
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                Case 3
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                Case 4
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If gcuenta.Item(0, fila - 1).Value <> "" Then Exit Sub
            fila = fila - 1
            cmditems_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Try
            Dim it As Integer = 1
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = fila + 1 To gcuenta.RowCount - 1
                Try
                    If gcuenta.Item(it, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = it, F As Integer = i
                        gcuenta.CurrentCell = gcuenta(it, F)
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gcuenta.Item(it, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = it, F As Integer = i
                        gcuenta.CurrentCell = gcuenta(C, F)
                        gcuenta.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar TBancos")
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
End Class