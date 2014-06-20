Public Class FrmCuentasRubros
    Dim cm As String
    Dim a As String
    Private Sub FrmCuentasRubros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        Dim ok As String = "n"
        myCommand.CommandText = "SHOW DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = "presupuesto" & a Then
                ok = "s"
                Exit For
            End If
        Next
        If ok = "n" Then
            MsgBox("Esta empresa no usa el software de Presupuesto", MsgBoxStyle.Information, "SAE")
            Me.Close()
        End If

      
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click

        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "fut"
        Else
            cm = "cgdg"
        End If

        If r1.Checked = True Then
            FrmCtasRubroxx.tiprb.Text = "GASTOS"
            cm = "c.gasc_" & cm
        Else
            FrmCtasRubroxx.tiprb.Text = "INGRESOS"
            cm = "c.ingc_" & cm
        End If

        If lbform.Text = "ctas" Then
            FrmCtasRubroxx.lbcm.Text = ""
            FrmCtasRubroxx.lbcm.Text = cm
            FrmCtasRubroxx.ShowDialog()
        ElseIf lbform.Text = "ejecucion" Then
            If r1.Checked = True Then
                FrmRubros.Text = "Ejecucion de Gastos"
                FrmRubros.lbtipo.Text = "gas"
            Else
                FrmRubros.Text = "Ejecucion de Ingresos"
                FrmRubros.lbtipo.Text = "ing"
            End If

            FrmRubros.ShowDialog()
        End If
       
    End Sub
End Class