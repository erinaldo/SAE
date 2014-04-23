Public Class FrmParBancos

    Private Sub FrmParBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM `parbanc`;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtdoc1.Text = ""
                txtn1.Text = ""
                txtdoc2.Text = ""
                txtn2.Text = ""
                txtdoc3.Text = ""
                txtn3.Text = ""
                txtdoc4.Text = ""
                txtn4.Text = ""
            Else
                txtdoc1.Text = tabla.Rows(0).Item("doc1")
                txtdoc2.Text = tabla.Rows(0).Item("doc2")
                txtdoc3.Text = tabla.Rows(0).Item("doc3")
                txtdoc4.Text = tabla.Rows(0).Item("doc4")
                txtdoc1_TextChanged(AcceptButton, AcceptButton)
                txtdoc2_TextChanged(AcceptButton, AcceptButton)
                txtdoc3_TextChanged(AcceptButton, AcceptButton)
                txtdoc4_TextChanged(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        ValidarGuardar()
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    '****************************************************
    Private Sub txtdoc1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc1.LostFocus
        If txtn1.Text = "" Then
            Try
                FrmSelTipoDoc.lbtipo.Text = "bank_d1"
                FrmSelTipoDoc.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtdoc1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc1.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc1.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtn1.Text = ""
            Else
                For i = 0 To tabla.Rows.Count - 1
                    txtn1.Text = tabla.Rows(0).Item("descripcion")
                Next
            End If
        Catch ex As Exception
            txtn1.Text = ""
        End Try
    End Sub
    '***********************************************************
    Private Sub txtdoc2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc2.LostFocus
        If txtn2.Text = "" Then
            Try
                FrmSelTipoDoc.lbtipo.Text = "bank_d2"
                FrmSelTipoDoc.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtdoc2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc2.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc2.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtn2.Text = ""
            Else
                For i = 0 To tabla.Rows.Count - 1
                    txtn2.Text = tabla.Rows(0).Item("descripcion")
                Next
            End If
        Catch ex As Exception
            txtn2.Text = ""
        End Try
    End Sub
    '***********************************************************
    Private Sub txtdoc3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc3.LostFocus
        If txtn3.Text = "" Then
            Try
                FrmSelTipoDoc.lbtipo.Text = "bank_d3"
                FrmSelTipoDoc.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtdoc3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc3.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc3.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtn3.Text = ""
            Else
                For i = 0 To tabla.Rows.Count - 1
                    txtn3.Text = tabla.Rows(0).Item("descripcion")
                Next
            End If
        Catch ex As Exception
            txtn3.Text = ""
        End Try
    End Sub
    '*************************************************************************
    Private Sub txtdoc4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc4.LostFocus
        If txtn4.Text = "" Then
            Try
                FrmSelTipoDoc.lbtipo.Text = "bank_d4"
                FrmSelTipoDoc.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtdoc4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc4.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txtdoc4.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtn4.Text = ""
            Else
                For i = 0 To tabla.Rows.Count - 1
                    txtn4.Text = tabla.Rows(0).Item("descripcion")
                Next
            End If
        Catch ex As Exception
            txtn4.Text = ""
        End Try
    End Sub
    Private Sub txtn1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub txtn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub txtn3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub txtn4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    '********** VALIDAR GUARDAR *************************
    Public Sub ValidarGuardar()
        If txtdoc1.Text = "" Then
            MsgBox("Verifique el docuemento pagos con cheques. ", MsgBoxStyle.Information)
            txtdoc1.Focus()
            Exit Sub
        Else
            If txtn1.Text = "" Then
                MsgBox("Verifique el docuemento pagos con cheques. ", MsgBoxStyle.Information)
                txtdoc1.Focus()
                Exit Sub
            End If
        End If
        If txtdoc2.Text <> "" And txtn2.Text = "" Then
            MsgBox("Verifique el docuemento de Consignaciones Bancarias. ", MsgBoxStyle.Information)
            txtdoc2.Focus()
            Exit Sub
        End If
        If txtdoc3.Text <> "" And txtn3.Text = "" Then
            MsgBox("Verifique el docuemento de Conciliaciones Bancarias. ", MsgBoxStyle.Information)
            txtdoc3.Focus()
            Exit Sub
        End If
        If txtdoc4.Text <> "" And txtn4.Text = "" Then
            MsgBox("Verifique el docuemento de Transacciones Bancarias. ", MsgBoxStyle.Information)
            txtdoc4.Focus()
            Exit Sub
        End If
        Guardar()
    End Sub
    Public Sub Guardar()
        MiConexion(bda)
        Try
            myCommand.CommandText = "TRUNCATE TABLE `parbanc`; " _
            & "INSERT INTO parbanc VALUES ('" & txtdoc1.Text & "','" & txtdoc2.Text & "','" & txtdoc3.Text & "','" & txtdoc4.Text & "');"
            myCommand.ExecuteNonQuery()
            MsgBox("Datos Guardados Correctamente.")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()

    End Sub

End Class