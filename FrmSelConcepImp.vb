Public Class FrmSelConcepImp
    Public fila As Integer

    Private Sub FrmSelConcepImp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtcuenta.Text = ""
    End Sub
    Private Sub FrmSelConcepImp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM con_gral_imp ORDER BY cod_concep;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ningún concepto de impuestos, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gcuenta.RowCount = items + 1
        For i = 0 To items - 1
            gcuenta.Item(1, i).Value = tabla.Rows(i).Item("cod_concep")
            gcuenta.Item(2, i).Value = tabla.Rows(i).Item("decrip_gral")
        Next
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        BuscarGrilla(txtcuenta.Text)
        gcuenta.Focus()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gcuenta.RowCount - 2
            aux = gcuenta.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    fila = i
                    Dim C As Integer = 1, F As Integer = i
                    gcuenta.CurrentCell = gcuenta(C, F)
                    gcuenta.Focus()
                    Exit Sub
                End If
            End If
        Next
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

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            If Trim(gcuenta.Item(1, fila).Value) = "" Then Exit Sub
            Select Case lbform.Text
                Case "concepto"
                    FrmGruposImp.TxtCodGral.Text = gcuenta.Item(1, fila).Value()
                    FrmGruposImp.txtDescriGral.Text = gcuenta.Item(2, fila).Value()
                    FrmGruposImp.lbnroobs.Text = fila + 1
                    FrmGruposImp.lbestado.Text = "CONSULTA"
                Case "impuestos"
                    FrmImpuestos.TxtCodGral.Text = gcuenta.Item(1, fila).Value()
                    FrmImpuestos.txtDescriGral.Text = gcuenta.Item(2, fila).Value()
                Case "generar"
                    FrmSelImpuestos.lbform.Text = "generar"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "si"
                    FrmSelImpuestos.lbform.Text = "si"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "ComEgres"
                    FrmSelImpuestos.lbform.Text = "ComEgres"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "ComIng"
                    FrmSelImpuestos.lbform.Text = "ComIng"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "ReciCaja"
                    FrmSelImpuestos.lbform.Text = "ReciCaja"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "NotaDb"
                    FrmSelImpuestos.lbform.Text = "NotaDb"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "NotaCr"
                    FrmSelImpuestos.lbform.Text = "NotaCr"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "OtrosCP"
                    FrmSelImpuestos.lbform.Text = "OtrosCP"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
                Case "OtrosCF"
                    FrmSelImpuestos.lbform.Text = "OtrosCF"
                    FrmSelImpuestos.lbfila.Text = lbfila.Text
                    FrmSelImpuestos.lbconcepto.Text = gcuenta.Item(1, fila).Value()
                    FrmSelImpuestos.ShowDialog()
            End Select
            gcuenta.Focus()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

End Class