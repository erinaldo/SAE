Public Class FrmSelBanco
    Public fila As Integer

    Private Sub FrmSelBanco_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtcuenta.Text = ""
    End Sub
    Private Sub FrmSelBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT b.*, s.descripcion FROM bancos b, selpuc s WHERE s.codigo= b.codigo ORDER BY cod_ban;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If (tabla.Rows.Count = 0) Then
                Me.gcuenta.RowCount = 1
                MsgBox("No hay bancos o corporaciones creadas.  ", MsgBoxStyle.Information)
            Else
                Me.gcuenta.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    Me.gcuenta.Item("codigo", i).Value = tabla.Rows(i).Item("cod_ban").ToString
                    Me.gcuenta.Item("banco", i).Value = tabla.Rows(i).Item("descripcion").ToString
                    Me.gcuenta.Item("cta", i).Value = tabla.Rows(i).Item("num_cta").ToString
                    Me.gcuenta.Item("cta_con", i).Value = tabla.Rows(i).Item("codigo").ToString
                    Me.gcuenta.Item("desc", i).Value = tabla.Rows(i).Item("banco").ToString
                Next
            End If
            With gcuenta
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
            cbbucar.Text = "NUMERO CTA"
            BuscarGrilla(txtcuenta.Text)
            gcuenta.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            Select Case lbform.Text
                Case "ciord"
                    FrmCIordenes.txtnitb.Text = gcuenta.Item("codigo", fila).Value
                    FrmCIordenes.txtbanco.Text = gcuenta.Item("banco", fila).Value
                    FrmCIordenes.txtctab.Text = gcuenta.Item("cta_con", fila).Value
                Case "gbanco"
                    FrmGestionBancos.txtcodigo.Text = gcuenta.Item(1, fila).Value()
                    FrmGestionBancos.lbestado.Text = "CONSULTA"
                    FrmGestionBancos.lbnumero.Text = fila + 1
                Case "banco_ext"
                    FrmExtratosBanc.txtcuenta.Text = gcuenta.Item("cta_con", fila).Value().ToString
                    FrmExtratosBanc.lbhay.Text = "si"
                Case "nce"
                    FrmNuevoEgreso.txtcta.Text = gcuenta.Item("cta_con", fila).Value().ToString
                Case "concil"
                    FrmConciliacionB.txtcuenta.Text = gcuenta.Item("cta_con", fila).Value().ToString
                    FrmConciliacionB.lbhay.Text = "si"
                Case "tra1"
                    FrmTransacciones.txtnum.Text = gcuenta.Item("cta", fila).Value().ToString
                Case "tra2"
                    FrmTransacciones.txtnum2.Text = gcuenta.Item("cta", fila).Value().ToString
                Case "FPE" 'Forma Pagos Egresos Públicos
                    Dim f As Integer = 0
                    Try
                        f = Val(lbfila.Text)
                        FemFPE2.gcuenta.Item("codigo", f).Value = Me.gcuenta.Item("codigo", fila).Value
                        FemFPE2.gcuenta.Item("banco", f).Value = Me.gcuenta.Item("banco", fila).Value
                        FemFPE2.gcuenta.Item("cta", f).Value = Me.gcuenta.Item("cta", fila).Value
                        FemFPE2.gcuenta.Item("cta_con", f).Value = Me.gcuenta.Item("cta_con", fila).Value
                    Catch ex As Exception
                    End Try
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
            Dim it As Integer = 0
            If cbbucar.Text = "NUMERO CTA" Then
                it = 3
            ElseIf cbbucar.Text = "CTA CONTABLE" Then
                it = 4
            Else
                it = 1
            End If
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