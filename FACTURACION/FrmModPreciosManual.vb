Public Class FrmModPreciosManual
    Public sw As Integer = 0
    Private Sub FrmModPreciosManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sw = 1
        cbtipo.Text = "INVENTARIOS"
        If FrmPrincipal.Inventarios.Enabled = False Then
            cbtipo.Text = "SERVICIOS"
            cbtipo.Enabled = False
        Else
            cbtipo.Enabled = True
        End If
        cbnombre.Text = "NORMAL"
        cborden.Text = "CODIGO"
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT numlist FROM listasprec ORDER BY numlist;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            cblista.Items.Clear()
            For i = 0 To items - 1
                cblista.Items.Add(tabla.Rows(i).Item(0))
            Next
            cblista.SelectedIndex() = 0
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        sw = 0
        llenarGrilla()
    End Sub
    Private Sub cblista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblista.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nomlist FROM listasprec WHERE  numlist='" & Trim(cblista.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtlista.Text = tabla.Rows(0).Item(0)
            llenarGrilla()
        Catch ex As Exception
            txtlista.Text = ""
        End Try
    End Sub
    Private Sub cbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtipo.SelectedIndexChanged
        llenarGrilla()
    End Sub
    Private Sub cbnombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbnombre.SelectedIndexChanged
        llenarGrilla()
    End Sub
    Private Sub cborden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cborden.SelectedIndexChanged
        llenarGrilla()
    End Sub
    Public Sub llenarGrilla()
        If cbtipo.Text = "INVENTARIOS" Then
            lbprecio.Text = "COLOCAR PRECIOS SIN IVA."
        Else
            lbprecio.Text = "COLOCAR PRECIOS CON IVA INCLUIDO."
        End If
        If sw = 1 Then Exit Sub
        Dim sql As String = ""
        Dim nom As String = ""
        Dim ord As String = ""
        Dim pre As String = ""
        lbitems.Text = "Hay 0 item(s)"
        Dim tabla As New DataTable
        Try
            gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        If cborden.Text = "CODIGO" Then
            ord = "cod"
        Else
            ord = "nom"
        End If
        If cbtipo.Text = "INVENTARIOS" Then
            If cbnombre.Text = "NORMAL" Then
                nom = "a.nomart AS nom"
            Else
                nom = "a.desart AS nom"
            End If
            sql = "SELECT a.codart AS cod,a.referencia AS ref," & nom & ",c.precio" & cblista.Text & " AS p,a.iva " _
                & "FROM articulos a LEFT JOIN (con_inv c) " _
                & "ON a.codart=c.codart " _
                & "WHERE c.periodo='" & PerActual(0) & PerActual(1) & "' AND a.nivel='Articulo' " _
                & "ORDER BY " & ord & ";"
        Else
            If cbnombre.Text = "NORMAL" Then
                nom = "nombre AS nom"
            Else
                nom = "descrip AS nom"
            End If
            If cblista.Text = "1" Then
                pre = ""
            Else
                pre = cblista.Text
            End If
            sql = "SELECT codser AS cod,CONCAT('    ---') AS ref," & nom & ",pventa" & pre & " AS p,iva " _
                & "FROM servicios " _
                & "ORDER BY " & ord & ";"
        End If
        gitems.RowCount = 1
        Try
            'MsgBox(sql)
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then Exit Sub
            gitems.RowCount = tabla.Rows.Count
            lbitems.Text = "Hay " & tabla.Rows.Count & " item(s)"
            For i = 0 To tabla.Rows.Count - 1
                gitems.Item("codigo", i).Value = tabla.Rows(i).Item("cod").ToString
                gitems.Item("ref", i).Value = tabla.Rows(i).Item("ref").ToString
                gitems.Item("desc", i).Value = tabla.Rows(i).Item("nom").ToString
                gitems.Item("pa", i).Value = Moneda(tabla.Rows(i).Item("p").ToString)
                gitems.Item("np", i).Value = Moneda(tabla.Rows(i).Item("p").ToString)
                gitems.Item("iva", i).Value = Moneda(tabla.Rows(i).Item("iva").ToString)
            Next
        Catch ex As Exception
            MsgBox(sql & "***********" & ex.ToString)
        End Try

    End Sub
    '*****************************************************
    Private Sub cmdcancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancela.Click
        Me.Close()
    End Sub
    '***************************
    Public col, fila As Integer
    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
        Try
            Select Case e.ColumnIndex
                Case 6 'guardar                   
                    GuardarFila(fila, col)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            gitems.Item("np", e.RowIndex).Value = Moneda(gitems.Item("np", e.RowIndex).Value)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
    End Sub
    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = "13" And col = 7 Then
            GuardarFila(fila, col)
        End If
    End Sub
    '***************************************************
    Public Sub GuardarFila(ByVal f As Integer, ByVal c As Integer)
        If (Moneda(gitems.Item("pa", f).Value) = Moneda(gitems.Item("np", f).Value)) Then
            MsgBox("no ha modificado el precio...", MsgBoxStyle.Information)
        Else
            If cbtipo.Text = "INVENTARIOS" Then
                CambiarPrecioInv(f)
            Else
                CambiarPrecioSer(f)
            End If
        End If
    End Sub
    Public Sub CambiarPrecioInv(ByVal f As Integer)
        Dim pre As String = ""
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "MODIFICAR PRECIO ARTICULO COD: " & gitems.Item("codigo", f).Value, "PRECIO", DIN(gitems.Item("pa", f).Value), DIN(gitems.Item("np", f).Value))
        End If
        '.....
        MiConexion(bda)
        Try
            If cblista.Text = "1" Then
                pre = "precio='" & DIN(gitems.Item("np", f).Value) & "'"
                myCommand.CommandText = "UPDATE articulos SET " & pre & " WHERE codart='" & gitems.Item("codigo", f).Value & "';"
                myCommand.ExecuteNonQuery()
            End If
            pre = "precio" & cblista.Text & "='" & DIN(gitems.Item("np", f).Value) & "'"
            myCommand.CommandText = "UPDATE con_inv SET " & pre & " WHERE codart='" & gitems.Item("codigo", f).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
            gitems.Item("pa", f).Value = gitems.Item("np", f).Value
            MsgBox("Precio cambiado correctamente...", MsgBoxStyle.Information, "SAE Cambiar Precio")
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub CambiarPrecioSer(ByVal f As Integer)
        Dim pre As String = ""
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "MODIFICAR PRECIO SERVICIO COD: " & gitems.Item("codigo", f).Value, "PRECIO", DIN(gitems.Item("pa", f).Value), DIN(gitems.Item("np", f).Value))
        End If
        '.....
        MiConexion(bda)
        Try
            If cblista.Text = "1" Then
                pre = "pventa='" & DIN(gitems.Item("np", f).Value) & "'"
            Else
                pre = "pventa" & cblista.Text & "='" & DIN(gitems.Item("np", f).Value) & "'"
            End If
            myCommand.CommandText = "UPDATE servicios SET " & pre & " WHERE codser='" & gitems.Item("codigo", f).Value & "';"
            myCommand.ExecuteNonQuery()
            gitems.Item("pa", f).Value = gitems.Item("np", f).Value
            MsgBox("Precio cambiado correctamente...", MsgBoxStyle.Information, "SAE Cambiar Precio")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub

End Class