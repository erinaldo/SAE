Public Class FrmConceptosComicionables

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM concomi LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                txtcodconcep.Text = ""
                txtconcep.Text = ""
                txtporcomi.Text = ""
                lbnumero.Text = "0"
                lbestado.Text = "NULO"
                Exit Sub
            End If
            codigo(tabla.Rows(0).Item(0))
            txtconcep.Text = tabla.Rows(0).Item(1)
            txtporcomi.Text = tabla.Rows(0).Item(2)
            lbnumero.Text = "1"
            lbestado.Text = "CONSULTA"
        Catch ex As Exception

        End Try
      
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM concomi LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            codigo(tabla.Rows(0).Item(0))
            txtconcep.Text = tabla.Rows(0).Item(1)
            txtporcomi.Text = tabla.Rows(0).Item(2)
            lbestado.Text = "CONSULTA"
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM concomi"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT * FROM concomi LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            codigo(tabla.Rows(0).Item(0))
            txtconcep.Text = tabla.Rows(0).Item(1)
            txtporcomi.Text = tabla.Rows(0).Item(2)
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM concomi"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay conceptos comicionables en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * FROM concomi LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        codigo(tabla.Rows(0).Item(0))
        txtconcep.Text = tabla.Rows(0).Item(1)
        txtporcomi.Text = tabla.Rows(0).Item(2)
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM concomi"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        codigo(Val(tabla.Rows(0).Item(0)) + 1)
        lbestado.Text = "NUEVO"
        lbnumero.Text = ""
        txtconcep.Text = ""
        txtporcomi.Text = "1,00"
        txtconcep.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM concomi"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) > 0 Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            cmdNuevo.Focus()
            lbestado.Text = ""
            lbnumero.Text = "0"
        End If
    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If txtcodconcep.Text = "" Then Exit Sub
        lbestado.Text = "EDITAR"
        txtconcep.Focus()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            txtconcep1.Text = ""
            txtporcomi1.Text = ""
            txtconcep1.Text = txtconcep.Text
            txtporcomi1.Text = txtporcomi.Text
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Dim x As String
        Dim items As Integer
        Dim tabla As New DataTable
        x = Trim(InputBox("Digite el codigo del concepto comicionable:   ", "Buscar Datos"))
        If x = "" Then Exit Sub
        If Val(x) = 0 Then
            MsgBox("Dato Invalido, Verifique.    ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * from concomi where codcon='" & x.ToString & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("El codigo del concepto comicionable no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        codigo(tabla.Rows(0).Item(0))
        txtconcep.Text = tabla.Rows(0).Item(1)
        txtporcomi.Text = tabla.Rows(0).Item(2)
        lbnumero.Text = tabla.Rows(0).Item(0)
        lbestado.Text = "CONSULTA"
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub Guardar()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?concepto", txtconcep.Text.ToString)
        myCommand.Parameters.AddWithValue("?porcomi", DIN(txtporcomi.Text.ToString))
        myCommand.CommandText = "INSERT INTO concomi (concepto,porcomi) " _
                                 & " Values(?concepto,?porcomi)"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "GUARDAR CONCEPTO COMISIONABLE COD: " & txtcodconcep.Text & " - " & txtconcep.Text, "", "", "")
        End If
        '.....
        CmdUltimo_Click(AcceptButton, AcceptButton)
        lbestado.Text = "GUARDADO"
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del concepto comicionable se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codcon", txtcodconcep.Text.ToString)
            myCommand.Parameters.AddWithValue("?concepto", txtconcep.Text.ToString)
            myCommand.Parameters.AddWithValue("?porcomi", DIN(txtporcomi.Text.ToString))
            myCommand.CommandText = "Update concomi set concepto=?concepto, porcomi=?porcomi WHERE codcon=?codcon"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Dim ant As String = ""
                Dim nue As String = ""
                Dim camp As String = ""
                If txtconcep1.Text <> txtconcep.Text Then
                    camp = camp & "DESCRIPCION ;"
                    ant = ant & txtconcep1.Text & ";"
                    nue = nue & txtconcep.Text & ";"
                End If
                If txtporcomi1.Text <> txtporcomi.Text Then
                    camp = camp & "PORCENTAJE ;"
                    ant = ant & txtporcomi1.Text & ";"
                    nue = nue & txtporcomi.Text & ";"
                End If
                Guar_MovUser("FACTURACION", "MODIFICAR CONCEPTO COMISIONABLE COD: " & txtcodconcep.Text & " - " & txtconcep.Text, camp, ant, nue)
            End If
            '.....
            lbestado.Text = "EDITADO"
        End If
    End Sub

    Private Sub FrmConceptosComicionables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM concomi"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) > 0 Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            cmdNuevo.Focus()
        End If
    End Sub

    Public Sub codigo(ByVal codigo As Integer)
        If codigo > 0 Then
            txtcodconcep.Text = codigo
        Else
            txtcodconcep.Text = "1"
        End If
    End Sub

    Private Sub txtconcep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcep.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        ElseIf e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtporcomi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtporcomi.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        Else
            ValidarPorcentaje(txtporcomi, e)
        End If
    End Sub
    Private Sub txtporcomi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtporcomi.LostFocus
        txtporcomi.Text = Moneda(txtporcomi.Text)
    End Sub
End Class