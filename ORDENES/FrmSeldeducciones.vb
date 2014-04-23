Public Class FrmSeldeducciones
    Public fila As Integer
    Private Sub FrmSeldeducciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT DISTINCT TRIM(CTA), concep FROM DETA_ORD WHERE CTA<>''  AND doc LIKE '%" & Strings.Right(PerActual, 4) & "%' ORDER BY TRIM(CTA) ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han movido ninguna deduccion, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item(0)
                gitems.Item(1, i).Value = tabla.Rows(i).Item(1)
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
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "infdedu"
                FrmInfDeducciones.txtd.Text = gitems.Item(0, fila).Value
        End Select
        gitems.Focus()
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "CODIGO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "DESCRIPCION" Then
                cl = 1
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
            cmbbuscar.Text = "CODIGO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "CODIGO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class