Public Class FrmMetasxArea

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmMetasxArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        bloquear()

    End Sub
    Private Sub limpiar()
        txtcod.Text = ""
        txtarea.Text = ""
        txttope.Text = ""
        cbcom.Text = ""
        txtvalor.Text = Moneda(0)
        Try
            txtf1.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf1.Enabled = True Then
                txtf1.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf1.Value = CDate(PerActual & "/" & "01")
            End If
        End Try

        Try
            txtf2.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtf2.Enabled = True Then
                txtf2.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtf2.Value = CDate(PerActual & "/" & "01")
            End If
        End Try
        cbrango.Text = ""
        lbestado.Text = "NULO"
    End Sub
    Private Sub bloquear()
        txtcod.Enabled = False
        BusArea.Enabled = False
        txtarea.Enabled = False
        txttope.Enabled = False
        cbcom.Enabled = False
        txtvalor.Enabled = False
        txtf1.Enabled = False
        txtf2.Enabled = False
        cbrango.Enabled = False

        cmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True

    End Sub
    Private Sub Desbloquear()
        txtcod.Enabled = True
        BusArea.Enabled = True
        txtarea.Enabled = True
        txttope.Enabled = True
        cbcom.Enabled = True
        txtvalor.Enabled = True
        txtf1.Enabled = True
        txtf2.Enabled = True
        cbrango.Enabled = True

        cmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False

    End Sub

    Private Sub txttope_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttope.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Then
                validarnumero(txttope, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txttope_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttope.LostFocus
        Try
            txttope.Text = Moneda(txttope.Text)
        Catch ex As Exception
            txttope.Text = Moneda(0)
        End Try
    End Sub

    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Then
                validarnumero(txtvalor, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        Try
            txtvalor.Text = Moneda(txtvalor.Text)
        Catch ex As Exception
            txtvalor.Text = Moneda(0)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusArea.Click
        Dim tabla As New DataTable
        Dim ok As String = "n"
        myCommand.CommandText = "SHOW DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = "nomina" Then
                ok = "s"
                Exit For
            End If
        Next
        If ok = "s" Then
            Try
                txtarea.Text = ""
                FrmSelArea.lbform.Text = "MetasArea"
                FrmSelArea.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            MsgBox("No existen las tablas de Nomina")
        End If
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Validar()
    End Sub
    Private Sub Validar()
        If txtcod.Text = "" Then
            MsgBox("Verifique el Codigo para la Meta", MsgBoxStyle.Information, "SAE")
            txtcod.Focus()
            Exit Sub
        End If
        If txtarea.Text = "" Then
            MsgBox("Verifique el Area Laboral", MsgBoxStyle.Information, "SAE")
            BusArea.Focus()
            Exit Sub
        End If
        If txttope.Text = "" Or txttope.Text = Moneda(0) Then
            MsgBox("Verifique el Valor Tope para la meta", MsgBoxStyle.Information, "SAE")
            txttope.Focus()
            Exit Sub
        End If
        If cbcom.Text = "" Then
            MsgBox("Seleccione el tipo de Comision", MsgBoxStyle.Information, "SAE")
            cbcom.Focus()
            Exit Sub
        End If
        If txtvalor.Text = "" Or txtvalor.Text = Moneda(0) Then
            MsgBox("Verifique el " & cbcom.Text & " de la comision", MsgBoxStyle.Information, "SAE")
            txtvalor.Focus()
            Exit Sub
        End If
        If (txtf2.Value < txtf1.Value) Then
            MsgBox("La Fecha Final debe ser Mayor a la Inicial", MsgBoxStyle.Information, "SAE Buscar")
            txtf2.Focus()
            Exit Sub
        End If
        If cbrango.Text = "" Then
            MsgBox("Verifique el Rango a Evaluar", MsgBoxStyle.Information, "SAE")
            cbrango.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            eliminar()
            Guardar()
        End If

    End Sub
    Private Sub Guardar()
        MiConexion(bda)

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod", txtcod.Text)
            myCommand.Parameters.AddWithValue("?area", txtarea.Text)
            myCommand.Parameters.AddWithValue("?tope", DIN(txttope.Text))
            myCommand.Parameters.AddWithValue("?tipcom", cbcom.Text)
            myCommand.Parameters.AddWithValue("?valcom", DIN(txtvalor.Text))
            myCommand.Parameters.AddWithValue("?f1", CDate(txtf1.Text))
            myCommand.Parameters.AddWithValue("?f2", CDate(txtf2.Text))
            myCommand.Parameters.AddWithValue("?rango", cbrango.Text)
            myCommand.Parameters.AddWithValue("?fela", DateTime.Now.ToString("yyyy-MM-dd"))
            myCommand.CommandText = "INSERT INTO   `metas_x_area`  " _
                                 & " Values(?cod,?area,?tope,?tipcom,?valcom,?f1,?f2,?rango,?fela); "
            myCommand.ExecuteNonQuery()

            MsgBox("Meta Guardada Exitosamente", MsgBoxStyle.Information, "SAE")
            lbestado.Text = "GUARDADO"
            bloquear()
        Catch ex As Exception
            MsgBox("Error al Guardar " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
        Cerrar()

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Desbloquear()
        limpiar()
        lbestado.Text = "NUEVO"
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        bloquear()
        limpiar()
    End Sub

    Private Sub txtcod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod.LostFocus
        Dim tc As New DataTable
        myCommand.CommandText = "SELECT codigo FROM metas_x_area where codigo='" & txtcod.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()
        If tc.Rows.Count > 0 Then
            MsgBox("Este codigo ya fue asignado", MsgBoxStyle.Information, "Verifique")
            txtcod.Text = ""
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If Trim(txtcod.Text) = "" Then
            MsgBox("Verifique el codigo de la Meta", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        Dim resultado As MsgBoxResult
        resultado = MsgBox("La meta " & txtcod.Text & " sera Eliminada, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            eliminar()
            MsgBox("Meta Eliminada", MsgBoxStyle.Information, "Verificacion")
            lbestado.Text = "ELIMINADO"
            limpiar()
        End If

    End Sub
    Private Sub eliminar()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM `metas_x_area` WHERE codigo='" & Trim(txtcod.Text) & "'; "
        myCommand.ExecuteNonQuery()

        Cerrar()
    End Sub

    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click

        If Trim(txtcod.Text) = "" Then
            MsgBox("Verifique el codigo de la Meta", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        lbestado.Text = "EDITAR"
        Desbloquear()
        txtcod.Enabled = False

    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelMetas.lbform.Text = "metas"
            FrmSelMetas.ShowDialog()
        Catch ex As Exception
        End Try
        If Trim(txtcod.Text) <> "" Then
            BuscarMeta()
        End If
    End Sub
    Private Sub BuscarMeta()
        Try

       
            MiConexion(bda)
            Dim tm As New DataTable
            myCommand.CommandText = "SELECT * FROM metas_x_area where codigo='" & Trim(txtcod.Text) & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tm)
            Refresh()

            txtcod.Text = tm.Rows(0).Item("codigo")
            txtarea.Text = tm.Rows(0).Item("area")
            txttope.Text = Moneda(tm.Rows(0).Item("tope"))
            cbcom.Text = tm.Rows(0).Item("tipcom")
            txtvalor.Text = Moneda(tm.Rows(0).Item("valcom"))
            txtf1.Text = tm.Rows(0).Item("fini").ToString
            txtf2.Text = tm.Rows(0).Item("ffin").ToString
            cbrango.Text = tm.Rows(0).Item("rango")

            Cerrar()
        Catch ex As Exception

        End Try
    End Sub
End Class