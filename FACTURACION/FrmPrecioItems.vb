Public Class FrmPrecioItems

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Dim fila As Integer = Val(lbfila.Text)
        Select Case lbform.Text
            Case "items"
                FrmItems.gitems.Item("precio", fila).Value = Moneda(txt1.Text)
            Case "itemsC"
                FrmItemsCompras.gitems.Item("precio", fila).Value = Moneda(txt1.Text)
            Case "selA"
                FrmSelArticulos.gitems.Item("precio", fila).Value = Moneda(txt1.Text)
            Case "selS"
                FrmSelServicio.gitems.Item("precio", fila).Value = Moneda(txt1.Text)
            Case "lista_precio"
                FrmAumentarPrecios.txtprecio.Text = Moneda(txt2.Text)
            Case "lista_precio2"
                FrmAumentarPrecios.txtprecio.Text = Moneda(txt1.Text)
        End Select
        Me.Close()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        If Ch1.Checked = True Then
            Ch2.Checked = False
            Try
                txt1.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub Ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch2.CheckedChanged
        If Ch2.Checked = True Then
            Ch1.Checked = False
            Try
                txt2.Focus()
            Catch ex As Exception
            End Try
        End If
    End Sub
    '**** PRECIO CON IVA ******
    Private Sub txt1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1.GotFocus
        Ch1.Checked = True
    End Sub
    Private Sub txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress
        ValidarMoneda(txt1, e)
    End Sub
    Private Sub txt1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt1.LostFocus
        txt1.Text = Moneda(txt1.Text)
    End Sub
    Private Sub txt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1.TextChanged
        If Ch1.Checked = True Then
            Try
                txt2.Text = Moneda(CDbl(txt1.Text) / (1 + (CDbl(lbiva.Text) / 100)))
            Catch ex As Exception
                txt2.Text = "0,00"
            End Try
        End If
    End Sub
    '**** PRECIO SIN IVA ******
    Private Sub txt2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.GotFocus
        Ch2.Checked = True
    End Sub
    Private Sub txt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt2.KeyPress
        ValidarMoneda(txt2, e)
    End Sub
    Private Sub txt2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt2.LostFocus
        txt2.Text = Moneda(txt2.Text)
    End Sub
    Private Sub txt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2.TextChanged
        If Ch2.Checked = True Then
            Try
                txt1.Text = Moneda(CDbl(txt2.Text) + ((CDbl(txt2.Text) * CDbl(lbiva.Text) / 100)))
            Catch ex As Exception
                txt1.Text = "0,00"
            End Try
        End If
    End Sub
    '*** FROMULARIO ////////////////
    Private Sub FrmPrecioItems_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            txt1.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmPrecioItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If lbform.Text = "lista_precio" Then
                txt1.Text = "0,00"
                txt2.Text = "0,00"
            ElseIf lbform.Text = "lista_precio2" Then
                txt1.Text = "0,00"
                txt2.Text = "0,00"
            End If
            txt1.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub Ch1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch1.GotFocus
        txt1.Focus()
    End Sub

    Private Sub Ch2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch2.GotFocus
        txt2.Focus()
    End Sub
End Class