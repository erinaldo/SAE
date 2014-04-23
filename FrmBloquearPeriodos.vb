Public Class FrmBloquearPeriodos

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmBloquearPeriodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano As String
        ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        grilla.RowCount = 12
        grilla.Item(1, 0).Value = "ENERO / " & ano
        grilla.Item(1, 1).Value = "FEBRERO / " & ano
        grilla.Item(1, 2).Value = "MARZO / " & ano
        grilla.Item(1, 3).Value = "ABRIL / " & ano
        grilla.Item(1, 4).Value = "MAYO / " & ano
        grilla.Item(1, 5).Value = "JUNIO / " & ano
        grilla.Item(1, 6).Value = "JULIO / " & ano
        grilla.Item(1, 7).Value = "AGOSTO / " & ano
        grilla.Item(1, 8).Value = "SEPTIEMBRE / " & ano
        grilla.Item(1, 9).Value = "OCTUBRE / " & ano
        grilla.Item(1, 10).Value = "NOVIEMBRE / " & ano
        grilla.Item(1, 11).Value = "DICIEMBRE / " & ano
        llenargrilla()
    End Sub
    Public Sub llenargrilla()
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bloq_per ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 1 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(1) = "n" Then
                grilla.Item(0, i - 1).Value = False
            Else
                grilla.Item(0, i - 1).Value = True
            End If
        Next
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If pro_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        Dim per, op As String
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        For i = 0 To grilla.RowCount - 1
            If i + 1 < 10 Then
                per = "0" & (i + 1)
            Else
                per = (i + 1)
            End If
            If grilla.Item(0, i).Value = True Then
                op = "s"
            Else
                op = "n"
            End If
            Guardar("UPDATE bloq_per SET bloqueado='" & op & "' WHERE periodo='" & per & "';")
        Next
        Cerrar()
        MsgBox("El bloqueo de periodos fue actualizado correctamente...", MsgBoxStyle.Information, "SAE Información")
        Me.Close()
    End Sub
    Public Sub Guardar(ByVal sql As String)
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
End Class