Public Class FrmSelCC
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
            If gitems.Item(0, mifila).Value().ToString = "" Then Exit Sub
            Select Case lbform.Text
                Case "para_fac"
                    FrmParaFactRapida.txtcc.Text = gitems.Item(0, mifila).Value()
            End Select
            gitems.Focus()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        cad = UCase(cad)
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 1
            aux = gitems.Item(0, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 0, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub FrmSelCC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM concomi ORDER BY codcon;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ningun concepto comicionable, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = tabla.Rows(i).Item("codcon")
            gitems.Item(1, i).Value = tabla.Rows(i).Item("concepto")
            gitems.Item(2, i).Value = tabla.Rows(i).Item("porcomi")
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
End Class