Public Class FrmSelGasto
    Public fila, sw As Integer

    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        Select Case e.ColumnIndex
            'Case 3 'precio
            '    Try
            '        If gitems.Item("nombre", e.RowIndex).Value = "" Then Exit Sub
            '        FrmPrecioItems.lbform.Text = "selS"
            '        FrmPrecioItems.lbfila.Text = e.RowIndex
            '        FrmPrecioItems.Ch1.Checked = True
            '        FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
            '        FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
            '        FrmPrecioItems.ShowDialog()
            '    Catch ex As Exception
            '    End Try
        End Select
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        sw = 0
        Select Case e.ColumnIndex
            Case 3 'precio
                'Try
                '    If gitems.Item("nombre", e.RowIndex).Value = "" Then Exit Sub
                '    FrmPrecioItems.lbform.Text = "selS"
                '    FrmPrecioItems.lbfila.Text = e.RowIndex
                '    FrmPrecioItems.Ch1.Checked = True
                '    FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                '    FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
                '    FrmPrecioItems.ShowDialog()
                'Catch ex As Exception
                'End Try
        End Select
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
        Dim fd As Integer
        fd = Val(lbfila.Text)
        FrmItemsCompras.gitems.Item("tipo", fd).Value = "G"
        FrmItemsCompras.gitems.Item("codigo", fd).Value = gitems.Item(1, mifila).Value
        FrmItemsCompras.gitems.Item("descrip", fd).Value = gitems.Item(2, mifila).Value
        FrmItemsCompras.gitems.Item("cant", fd).Value = "1"
        FrmItemsCompras.gitems.Item("precio", fd).Value = Moneda(gitems.Item(3, mifila).Value)
        FrmItemsCompras.gitems.Item("bodega", fd).Value = ""
        FrmItemsCompras.gitems.Item("iva", fd).Value = gitems.Item("iva", mifila).Value
        ''''''''''''''''''''''''''''''''''''''''
        FrmItemsCompras.gitems.Item("ctainv", fd).Value = ""
        FrmItemsCompras.gitems.Item("ctacven", fd).Value = ""
        FrmItemsCompras.gitems.Item("ctaing", fd).Value = gitems.Item("CTAING", mifila).Value
        FrmItemsCompras.gitems.Item("ctaiva", fd).Value = gitems.Item("CTAIVA", mifila).Value
        FrmItemsCompras.gitems.Item("descuento", fd).Value = Moneda(0)
        Me.Close()
        gitems.Focus()
        sw = 1
        Me.Close()
    End Sub
    Private Sub FrmSelVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sw <> 1 Then
            seleccionar(0)
            Exit Sub
        End If
        sw = 0
    End Sub

    Private Sub FrmSelVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim items As Integer
        Dim tabla2 As New DataTable
        If FrmItems.cbdesc.Text = "DETALLADA" Then
            myCommand.CommandText = "SELECT cod_gas,desc_gas as n,por_iva,cta_iva,cta_gas FROM gastos ORDER BY cod_gas;"
        Else
            myCommand.CommandText = "SELECT cod_gas,nom_gas as n,por_iva,cta_iva,cta_gas FROM gastos ORDER BY cod_gas;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(1, i).Value = tabla2.Rows(i).Item("cod_gas")
            gitems.Item(2, i).Value = Trim(tabla2.Rows(i).Item("n"))
            gitems.Item(3, i).Value = "0,00"
            gitems.Item("iva", i).Value = tabla2.Rows(i).Item("por_iva")
            gitems.Item(4, i).Value = tabla2.Rows(i).Item("cta_iva")
            gitems.Item(5, i).Value = tabla2.Rows(i).Item("cta_gas")
        Next
        BuscarGrilla(txtcuenta.Text)
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
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

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Select Case e.ColumnIndex
            Case 3 'precio
                gitems.Item(3, e.RowIndex).Value = Moneda(gitems.Item(3, e.RowIndex).Value)
        End Select
    End Sub
End Class