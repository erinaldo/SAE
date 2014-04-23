Public Class FrmSelArea
    Public fila As Integer
    Private Sub FrmSelArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT CONSECUTIVO,NOMBRE_AREA,DESCRIPCION FROM nomina.areas  ORDER BY consecutivo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han creado ninguna Area, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try

            
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(1, i).Value = tabla.Rows(i).Item("NOMBRE_AREA")
                gitems.Item(2, i).Value = tabla.Rows(i).Item("DESCRIPCION")
            Next
            
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "Vendedor"
                FrmVendedores.txtzona.Text = gitems.Item(1, mifila).Value()
            Case "MetasArea"
                FrmMetasxArea.txtarea.Text = gitems.Item(1, mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "AREA" Then
                cl = 1
            ElseIf cmbbuscar.Text = "DESCRIPCION" Then
                cl = 2
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

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "AREA"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "AREA"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class