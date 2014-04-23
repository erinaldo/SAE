Public Class FrmInmueblesTipos
    Private Sub buscar()
        MiConexion(bda)
        Try

            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM inm_tipo ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                cmbtipo.Items.Clear()
                lbitem.Text = ""
                MsgBox("No ha creado ningun tipo de Inmueble", MsgBoxStyle.Information, "Verificación")
                cmdmodificar.Enabled = False
            Else
                cmbtipo.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    cmbtipo.Items.Add(tabla.Rows(i).Item("tipo"))
                Next
                cmbtipo.Text = cmbtipo.Items(0).ToString
                lbitem.Text = tabla.Rows(0).Item("item")
                cmdmodificar.Enabled = True
            End If
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
    Private Sub FrmInmueblesTipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        desbloquear()
        buscar()

    End Sub

    Private Sub cmbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.SelectedIndexChanged

        MiConexion(bda)
        Try

            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM inm_tipo where tipo='" & cmbtipo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                lbitem.Text = tabla.Rows(0).Item("item")
            End If
        Catch ex As Exception
        End Try
        Cerrar()

    End Sub
    Private Sub bloquear()
        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        txttipo.Enabled = True
    End Sub
    Private Sub desbloquear()
        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        txttipo.Enabled = False
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        lbestado.Text = "EDITAR"
        txttipo.Text = cmbtipo.Text
        bloquear()
        txttipo.Focus()

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        lbestado.Text = "NUEVO"
        txttipo.Text = ""
        bloquear()

    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        If txttipo.Text = "" Then
            MsgBox("Digite la descripcion para los inmuebles", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        End If

        Try
            MiConexion(bda)
            If lbestado.Text = "NUEVO" Then
                GuardarI()
            ElseIf lbestado.Text = "EDITAR" Then
                Modificar()
            End If
        Catch ex As Exception
            MsgBox("Error al Guardar el Tipo de inmueble, La descripcion del inmueble no debe ser mayor de 60 caracteres" & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
        Cerrar()
        lbestado.Text = ""
    End Sub
    Private Sub GuardarI()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "Insert INTO inm_tipo (tipo) Values ('" & txttipo.Text & "');"
        myCommand.ExecuteNonQuery()
        Refresh()

        MsgBox("Tipo de Inmueble Guardado", MsgBoxStyle.Information, "SAE")
        Button1_Click(AcceptButton, AcceptButton)
        buscar()
    End Sub
    Private Sub Modificar()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE inm_tipo SET tipo='" & txttipo.Text & "' WHERE item='" & lbitem.Text & "';"
        myCommand.ExecuteNonQuery()
        Refresh()

        MsgBox("Tipo de Inmueble Modificado", MsgBoxStyle.Information, "SAE")
        Button1_Click(AcceptButton, AcceptButton)
        buscar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        desbloquear()
        txttipo.Text = ""
        lbestado.Text = ""
        Me.Close()
    End Sub
End Class