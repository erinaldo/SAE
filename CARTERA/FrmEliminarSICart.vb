Public Class FrmEliminarSICart
    Dim tb As String = ""
    Public fila As Integer
    Private Sub FrmEliminarSICart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If lbform.Text = "cartCli" Then
            tb = "cobdpen"
        Else
            tb = "ctas_x_pagar"
        End If
        llenar(tb)
    End Sub
    Private Sub llenar(ByVal tb As String)
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer

        myCommand.CommandText = "SELECT DISTINCT c.doc, c.tipo, c.num, cast(c.fecha as char(20)) AS f, c.fecha , c.pagado,  " _
       & " CONCAT(c.nitc,' ',c.nomnit) AS cli, c.total, (c.total-c.pagado) AS sald FROM " & tb & " c " _
       & " WHERE c.salmov='S'  ORDER BY fecha"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado facturas para la busquedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc")
            gitems.Item("fecha", i).Value = tabla.Rows(i).Item("f")
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("cli")
            gitems.Item("total", i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("abono", i).Value = Moneda(tabla.Rows(i).Item("pagado"))
            gitems.Item("saldo", i).Value = Moneda(tabla.Rows(i).Item("sald"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipo")
            gitems.Item("numero", i).Value = tabla.Rows(i).Item("num")
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click

        MsgBox("Este proceso es irreversible, si elimina un saldo que ha tenido abonos o pago total, tendra inconsistencias en cartera", MsgBoxStyle.Exclamation, "Advertencia")
        Dim rs As MsgBoxResult
        rs = MsgBox("Los saldos iniciales seleccionados seran eliminados,¿Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
        If rs = MsgBoxResult.Yes Then
            MiConexion(bda)
            mibarra.Value = 0
            mibarra.Visible = True
            mibarra.Maximum = gitems.RowCount
            For i = 0 To gitems.RowCount - 1
                If gitems.Item("sel", i).Value = True Then
                    eliminar(i)
                End If
                mibarra.Value = mibarra.Value + 1
                mibarra.Visible = False
            Next
            Cerrar()
            MsgBox("El Proceso se ha Realizado Exitosamente", MsgBoxStyle.Information, "SAE")
            llenar(tb)
        End If
    End Sub

    Private Sub eliminar(ByVal fl As Integer)

        'sacar de cartera
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  DELETE FROM " & tb & " WHERE doc='" & gitems.Item("doc", fl).Value & "' "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'sacar contabilidad
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  DELETE FROM documentos00 WHERE doc='" & gitems.Item("numero", fl).Value & "' and tipodoc ='" & gitems.Item("tipo", fl).Value & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "DOCUMENTO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "DOCUMENTO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "CLIENTE" Then
                cl = 2
            End If

            Try
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

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "DOCUMENTO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class