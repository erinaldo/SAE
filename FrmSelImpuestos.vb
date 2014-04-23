Public Class FrmSelImpuestos
    Public fila As Integer

    Private Sub FrmSelImpuestos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtcuenta.Text = ""
    End Sub
    Private Sub FrmSelImpuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        If lbform.Text = "generar" Or lbform.Text = "si" Then
            myCommand.CommandText = "SELECT * FROM impuestos WHERE cod_concep='" & lbconcepto.Text & "' ORDER BY cod_concep, codigo;"
        Else
            myCommand.CommandText = "SELECT * FROM impuestos  ORDER BY cod_concep, codigo;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ningún impuesto, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        Try
            gcuenta.Rows.Clear()
        Catch ex As Exception
        End Try
        gcuenta.RowCount = items + 1
        For i = 0 To items - 1
            gcuenta.Item(0, i).Value = tabla.Rows(i).Item("cod_concep")
            gcuenta.Item(1, i).Value = tabla.Rows(i).Item("codigo")
            gcuenta.Item(2, i).Value = tabla.Rows(i).Item("descrip")
            gcuenta.Item(3, i).Value = Moneda(tabla.Rows(i).Item("porce"))
            gcuenta.Item(4, i).Value = tabla.Rows(i).Item("cuenta")
            gcuenta.Item(5, i).Value = tabla.Rows(i).Item("id_imp")
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
            fila = e.RowIndex
            cmditems_Click(AcceptButton, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Trim(gcuenta.Item(0, fila - 1).Value) = "" Then Exit Sub
            fila = fila - 1
            cmditems_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            If Trim(gcuenta.Item(5, fila).Value) = "" Then Exit Sub
            Select Case lbform.Text
                Case "impuestos"
                    FrmImpuestos.lbcodigo.Text = gcuenta.Item(5, fila).Value()
                    FrmImpuestos.lbnroobs.Text = fila + 1
                    FrmImpuestos.lbestado.Text = "CONSULTA"
                Case "generar"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "generar"
                    FrmDigitarBase.ShowDialog()
                Case "si"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "si"
                    FrmDigitarBase.ShowDialog()
                Case "ComEgres"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "ComEgres"
                    FrmDigitarBase.ShowDialog()
                Case "ComIng"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "ComIng"
                    FrmDigitarBase.ShowDialog()
                Case "ReciCaja"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "ReciCaja"
                    FrmDigitarBase.ShowDialog()
                Case "NotaDb"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "NotaDb"
                    FrmDigitarBase.ShowDialog()
                Case "NotaCr"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "NotaCr"
                    FrmDigitarBase.ShowDialog()
                Case "OtrosCP"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "OtrosCP"
                    FrmDigitarBase.ShowDialog()
                Case "OtrosCF"
                    FrmDigitarBase.lbconcepto.Text = gcuenta.Item(5, fila).Value()
                    FrmDigitarBase.lbfila.Text = lbfila.Text
                    FrmDigitarBase.lbform.Text = "OtrosCF"
                    FrmDigitarBase.ShowDialog()
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