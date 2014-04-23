Public Class FrmCierreAno

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub FrmCierreAno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
    End Sub

    Private Sub cmdcierreA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcierreA.Click
        If pro_con <> "E" Then
            MsgBox("No tienes permisos para esta operación.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        BuscarPeriodo()
        If (PerActual(0) & PerActual(1)) = "12" Then
            If VerificarCierre() = False Then
                FrmCierreOpciones.lbsaldo.Text = (s1 + s2 + s3)
                FrmCierreOpciones.ShowDialog()
                Me.Close()
                'Exit Sub
            Else
                Me.Cursor = Cursors.WaitCursor
                Me.mibarra.Visible = True
                Cierre()
                Me.Cursor = Cursors.Default
                Me.mibarra.Visible = False
                'MsgBox("saldos ok")
            End If
        Else
            MsgBox("Esta operación solo se puede realizar en el mes 12 (Diciembre). ", MsgBoxStyle.Information, "SAE CONTROL")
        End If
    End Sub
    Public s1, s2, s3 As Double
    Function VerificarCierre()
        s1 = 0
        s2 = 0
        s3 = 0
        Dim t1, t2, t3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT ROUND(SUM(saldo), 2 ) FROM selpuc WHERE codigo like '1%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT ROUND(SUM(saldo), 2 ) FROM selpuc WHERE codigo like '2%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT ROUND(SUM(saldo), 2 ) FROM selpuc WHERE codigo like '3%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        Try
            'MsgBox(t1.Rows(0).Item(0).ToString)
            s1 = CDbl(Moneda(t1.Rows(0).Item(0).ToString))
            's1 = CDbl(890000)
        Catch ex As Exception
            s1 = 0
        End Try
        Try
            'MsgBox(t2.Rows(0).Item(0).ToString)
            s2 = CDbl(Moneda(t2.Rows(0).Item(0).ToString))
        Catch ex As Exception
            s2 = 0
        End Try
        Try
            'MsgBox(t3.Rows(0).Item(0).ToString)
            s3 = CDbl(Moneda(t3.Rows(0).Item(0).ToString))
        Catch ex As Exception
            s3 = 0
        End Try
        'MsgBox(s1 + s2 + s3)
        'Dim res As Double = (s1 + s2 + s3)
        'MsgBox("Activos:" & s1 & " Pasivos:" & s2 & " Capital:" & s3 & "  =  " & res, MsgBoxStyle.Information, "SAE Cierre de Año")
        If (s1 + s2 + s3) = 0 Or CDbl(Moneda(s1 + s2 + s3)) = 0 Then
            Return True
        Else

            MsgBox("No se puede hacer cierre de año, Verifique pues Activos - Pasivos son diferentes del Capital. (A-P=C) " & (s1 + s2 + s3), MsgBoxStyle.Information, "SAE Cierre de Año")
            Return False
        End If
    End Function

    Private Sub cmdcierreT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class