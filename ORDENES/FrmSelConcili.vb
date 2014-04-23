Public Class FrmSelConcili
    Public fila As Integer
    Private Sub FrmSelConcili_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As String = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT num , CAST(CONCAT(dia,'/',per) AS CHAR(15)) AS fech, ctabanco, CAST(CONCAT(banco,' ', num_cta) AS CHAR(100)) AS nomban," _
        & " docotros, doccuadre FROM conciliacion c, bancos b WHERE c.ctabanco= b.codigo ORDER BY num; "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            gitems.Rows.Clear()
            MsgBox("No existen conciliaciones para mostrar", MsgBoxStyle.Information, "SAE")
            Exit Sub
        Else

            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item("num")
                gitems.Item(1, i).Value = tabla.Rows(i).Item("fech")
                gitems.Item(2, i).Value = tabla.Rows(i).Item("ctabanco")
                gitems.Item(3, i).Value = tabla.Rows(i).Item("nomban")
                gitems.Item(4, i).Value = tabla.Rows(i).Item("docotros")
                gitems.Item(5, i).Value = tabla.Rows(i).Item("doccuadre")
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        End If
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "ConcilB"
                FrmConciliacionB.lbnum.Text = gitems.Item(0, mifila).Value()
        End Select
        Me.Close()
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "CTABANCO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "CTABANCO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "NUMERO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "CTABANCO" Then
                cl = 2
            ElseIf cmbbuscar.Text = "NOMBRE BANCO" Then
                cl = 3
            ElseIf cmbbuscar.Text = "DOC OTRO" Then
                cl = 4
            ElseIf cmbbuscar.Text = "DOC CB" Then
                cl = 5
            End If

            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = fila + 1 To gitems.RowCount - 1
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Terceros")
        Catch ex As Exception
        End Try
    End Sub
End Class