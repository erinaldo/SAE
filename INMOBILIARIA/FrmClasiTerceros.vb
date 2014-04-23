Public Class FrmClasiTerceros

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
        lbform.Text = ""
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelCliente.lbform.Text = "tercerosInm"
        FrmSelCliente.ShowDialog()
    End Sub

    Private Sub FrmClasiTerceros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        If lbform.Text <> "terceros" Then
            cmdcancelar_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        ValidarNIT(txtnit, e)
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnombre.Text = "" Then
            Try
                txtnit.Text = ""
                txttipo1.Items.Clear()
                FrmSelCliente.lbform.Text = "tercerosInm"
                FrmSelCliente.ShowDialog()
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Dim items As Integer
        Dim tb As New DataTable
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtnombre.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))

            myCommand.CommandText = "SELECT clase FROM tercerosinm WHERE nit ='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            If tb.Rows.Count > 0 Then
                For i = 0 To tb.Rows.Count - 1
                    txttipo1.Items.Add(tb.Rows(i).Item(0))
                Next
                'txttipo.Text = tb.Rows(0).Item(0)
            Else
                'txttipo.Text = ""
                txttipo1.Items.Clear()

            End If
            lbestado.Text = "CONSULTA"
        Else
            txtnombre.Text = ""
            txttipo1.Items.Clear()
            lbestado.Text = "NULO"

        End If
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        txtnit.Text = ""
        txtnombre.Text = ""
        txttipo1.Items.Clear()
        lbestado.Text = "NULO"
        Bloquear()
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click

        If lbestado.Text = "ELIMINAR" Then
            If txttipo1.Text.ToString = "" Then
                MsgBox("Seleccione la Clasificacion que desea eliminar", MsgBoxStyle.Information, "Verificacion")
                txttipo1.Focus()
                Exit Sub
            End If
            Eliminar()
        Else
            ' NUEVO
            If cbtipo.Text = "Seleccione..." Then
                MsgBox("Debe seleccionar una clasificacion valida", MsgBoxStyle.Information, "Verificacion")
            Else
                Try
                    For i = 0 To txttipo1.Items.Count
                        If cbtipo.Text = txttipo1.Items(i).ToString Then
                            MsgBox("El Tercero ya es " & txttipo1.Items(i).ToString & ". Seleccione una clasificacion diferente", MsgBoxStyle.Information, "Verificacion")
                            Exit Sub
                        End If
                    Next
                Catch ex As Exception
                End Try
                If txtnit.Text = "" Then
                    MsgBox("Seleccione un tercero", MsgBoxStyle.Information, "Verificacion")
                    Exit Sub
                End If
            End If

            guardar()
            txttipo1.Items.Clear()
        End If

    End Sub
    Private Sub Eliminar()

        Dim resultado As MsgBoxResult
        resultado = MsgBox("La clasificacion del tercero se va a eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
            myCommand.Parameters.AddWithValue("?clase", txttipo1.Text.ToString)
            myCommand.CommandText = "DELTE FROM tercerosInm WHERE nit=?nitc and clase=?clase "
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbestado.Text = "NULO"
            cmdcancelar_Click(AcceptButton, AcceptButton)
            Bloquear()
        End If
    End Sub
    Private Sub guardar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del tercero se van a registrar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
            myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
            myCommand.CommandText = "Insert INTO tercerosInm (nit, clase) " _
            & " Values (?nitc,?tipo);"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbestado.Text = "NULO"
            cmdcancelar_Click(AcceptButton, AcceptButton)
            Bloquear()
        End If
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        'If txtnit.Text <> "" Then
        lbestado.Text = "EDITAR"
        Bloquear()
        ' End If
    End Sub
    Private Sub Bloquear()
        If lbestado.Text = "EDITAR" Then
            cbtipo.Enabled = True
            cmdguardar.Enabled = True
            cmdcancelar.Enabled = True
            cmdmodificar.Enabled = False
            cmdEliminar.Enabled = False
            CmdMostrar.Enabled = False
            cbtipo.Text = "Seleccione..."
            lbestado.Visible = True
            lbform.Text = ""
            lbtipo.Visible = False
            txttipo1.Visible = False
        ElseIf lbestado.Text = "CONSULTA" Then
            cbtipo.Enabled = False
            cmdguardar.Enabled = False
            cmdcancelar.Enabled = False
            cmdmodificar.Enabled = True
            cmdEliminar.Enabled = True
            CmdMostrar.Enabled = True
            cbtipo.Text = "Seleccione..."
            lbestado.Visible = True
            lbtipo.Visible = False
            lbform.Text = ""
        ElseIf lbestado.Text = "NULO" Then
            cbtipo.Enabled = False
            cmdguardar.Enabled = False
            cmdcancelar.Enabled = False
            cmdmodificar.Enabled = True
            cmdEliminar.Enabled = True
            CmdMostrar.Enabled = True
            cbtipo.Text = "Seleccione..."
            lbestado.Visible = False
            lbform.Text = ""
            lbtipo.Visible = False
            txttipo1.Visible = False
        ElseIf lbestado.Text = "ELIMINAR" Then
            cbtipo.Enabled = False
            cmdguardar.Enabled = True
            cmdcancelar.Enabled = True
            cmdmodificar.Enabled = False
            cmdEliminar.Enabled = False
            CmdMostrar.Enabled = False
            cbtipo.Text = "Seleccione..."
            lbestado.Visible = True
            lbform.Text = ""
            lbtipo.Visible = True
            txttipo1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lbestado.Text <> "EDITAR" Then
            frmterceros.cmdNuevo_Click(AcceptButton, AcceptButton)
            frmterceros.txtnit.Focus()
            frmterceros.ShowDialog()
            txtnit.Text = frmterceros.txtnit.Text
        Else
            MsgBox("El estado " & lbestado.Text & " no permite esta acción. ", MsgBoxStyle.Information, "Verifique")
        End If
    End Sub

    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click
        If txtnit.Text = "" Or txtnombre.Text = "" Then
            MsgBox("Verifique los datos del tercero", MsgBoxStyle.Information, "SAE")
            Exit Sub
        End If
        If txttipo1.Items.Count = 0 Then
            MsgBox("El Tercero no pertenece a ninguna clasificacion", MsgBoxStyle.Information, "SAE")
            Exit Sub
        End If
        txttipo1.Visible = True
        lbestado.Text = "ELIMINAR"
        Bloquear()
    End Sub
End Class