Public Class Frmctaconceptos
    Dim fila2 As Integer
    Private Sub Frmctaconceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'gcuenta.RowCount = 3
        buscarFormatos()
    End Sub
    Private Sub buscarFormatos()
        Try

            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT DISTINCT c.codfor, f.descripcion FROM conceptos c, formatos f WHERE c.codfor = f.codigo Limit 7"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                cmbForm.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    cmbForm.Items.Add(tabla.Rows(i).Item("codfor"))
                Next
            Else
                MsgBox("No existen formatos para mostrar", MsgBoxStyle.Information, "Verifique")
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar los Formatos")
        End Try

    End Sub

    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        Me.Close()
    End Sub

    Private Sub cmbForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForm.SelectedIndexChanged
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT  f.descripcion, c.codcon  FROM  formatos f, conceptos c " _
        & " WHERE f.codigo= '" & cmbForm.Text & "'  AND c.codfor='" & cmbForm.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtdesfor.Text = UCase(tabla.Rows(0).Item("descripcion"))
            For j = 0 To tabla.Rows.Count - 1
                cmbcon.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    cmbcon.Items.Add(tabla.Rows(i).Item("codcon"))
                Next
            Next
        End If
    End Sub

    Private Sub cmbcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcon.SelectedIndexChanged
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT  c.descr  FROM  formatos f, conceptos c " _
        & " WHERE c.codcon= '" & cmbcon.Text & "'  AND c.codfor='" & cmbForm.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtcon.Text = UCase(tabla.Rows(0).Item("descr"))
            buscarCuentas()
        End If

        'gcuenta.RowCount = 2
    End Sub
    Private Sub buscarCuentas()
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT c.cuenta, s.descripcion, c.mov FROM cta_conc c, selpuc s " _
        & " WHERE c.cuenta = s.codigo AND c.codfor ='" & cmbForm.Text & "' AND c.codcon = '" & cmbcon.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        gcuenta.Rows.Clear()
        If t1.Rows.Count = 0 Then
            gcuenta.RowCount = 10
        Else

            If t1.Rows(0).Item("mov") = "sl" Then
                cbtmv.Text = "SALDO"
            ElseIf t1.Rows(0).Item("mov") = "db" Then
                cbtmv.Text = "DEDITO"
            ElseIf t1.Rows(0).Item("mov") = "cr" Then
                cbtmv.Text = "CREDITO"
            End If

            gcuenta.RowCount = t1.Rows.Count + 3
            For j = 0 To t1.Rows.Count - 1
                gcuenta.Item(0, j).Value = t1.Rows(j).Item("cuenta")
                gcuenta.Item(1, j).Value = t1.Rows(j).Item("descripcion")
                If t1.Rows(j).Item("mov") = "sl" Then
                    gcuenta.Item(2, j).Value = "SALDO"
                ElseIf t1.Rows(j).Item("mov") = "db" Then
                    gcuenta.Item(2, j).Value = "DEDITO"
                ElseIf t1.Rows(j).Item("mov") = "cr" Then
                    gcuenta.Item(2, j).Value = "CREDITO"
                End If
            Next
        End If
    End Sub

    Private Sub gcuenta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gcuenta.CellBeginEdit
        Select Case e.ColumnIndex
            Case 0
                Try
                    gcuenta.RowCount = gcuenta.RowCount + 1
                Catch ex As Exception
                End Try

        End Select
    End Sub
    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        FrmCuentas.lbform.Text = "magnet"
        FrmCuentas.lbfila.Text = fila2
        FrmCuentas.lbaux.Text = ""
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub gcuenta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEndEdit
        Select Case e.ColumnIndex
            Case 0
                Bcuentas(gcuenta.Item(0, e.RowIndex).Value, e.RowIndex)

        End Select
    End Sub
    Public Sub Bcuentas(ByVal cuenta As String, ByVal fila As Integer)
        Try
            If cuenta = "" Then
                FrmCuentas.lbform.Text = "magnet"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
            Else
                Dim t2 As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t2)

                If t2.Rows.Count <= 0 Then
                    gcuenta.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "magnet"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    gcuenta.Item(1, fila).Value = t2.Rows(0).Item("descripcion")
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            gcuenta.Item(2, fila).Value = cbtmv.Text
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila2 = e.RowIndex
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If cmbForm.Text = "" Then
            MsgBox("Verifique el codigo del Formato", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If
        If cmbcon.Text = "" Then
            MsgBox("Verifique el codigo del concepto", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If

        Dim resultado As MsgBoxResult
        resultado = MsgBox("Las cuentas seran asociadas al formato " & cmbcon.Text & ", ¿Desea Continuar?", MsgBoxStyle.YesNo, "SAE Confirmar")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM cta_conc WHERE codfor='" & cmbForm.Text & "' AND codcon='" & cmbcon.Text & "' "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception

            End Try
            For i = 0 To gcuenta.Rows.Count - 1
                If gcuenta.Item(0, i).Value <> "" Then
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?codfor", cmbForm.Text)
                    myCommand.Parameters.AddWithValue("?codcon", cmbcon.Text)
                    myCommand.Parameters.AddWithValue("?cta", gcuenta.Item(0, i).Value)
                    If gcuenta.Item(2, i).Value = "SALDO" Then
                        myCommand.Parameters.AddWithValue("?mov", "sl")
                    ElseIf gcuenta.Item(2, i).Value = "DEBITO" Then
                        myCommand.Parameters.AddWithValue("?mov", "db")
                    ElseIf gcuenta.Item(2, i).Value = "CREDITO" Then
                        myCommand.Parameters.AddWithValue("?mov", "cr")
                    End If
                    myCommand.CommandText = "INSERT cta_conc VALUES (?codfor,?codcon,?cta,?mov)"
                    myCommand.ExecuteNonQuery()
                End If
            Next
            Cerrar()
            MsgBox("Las cuentas se agregaron exitosamente", MsgBoxStyle.Information, "SAE")
        End If
    End Sub

    Private Sub gcuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gcuenta.KeyDown
        If e.KeyCode = 8 Then
            If fila2 = gcuenta.RowCount - 1 Then Exit Sub
            QuitarFila(fila2)
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If fila2 = gcuenta.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            gcuenta.Rows.RemoveAt(fila2)
        End If
    End Sub

    Private Sub cbtmv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbtmv.SelectedIndexChanged
        Try
            For i = 0 To gcuenta.Rows.Count - 1
                gcuenta.Item("sl", i).Value = cbtmv.Text
            Next
        Catch ex As Exception
        End Try
       
    End Sub
End Class