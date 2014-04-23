Public Class FrmDocumentos

    Private Sub FrmDocumentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    '**************************************************************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            txttipo.ReadOnly = True
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc ORDER BY tipodoc LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txttipo.Text = tabla.Rows(0).Item(0)
            txtdoc.Text = tabla.Rows(0).Item(2)
            BuscarGrupo(tabla.Rows(0).Item(1))
            BuscarIniAct(tabla.Rows(0).Item(1), tabla.Rows(0).Item(0))
            txtdoc.Text = tabla.Rows(0).Item(2)
            lbnroobs.Text = 1
            txtgrupodoc.Enabled = False
            txtaltual.ReadOnly = True
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            txttipo.Text = ""
            txttipo.ReadOnly = True
            txtgrupodoc.Text = ""
            txtdoc.Text = ""
            txtinicial.Text = "0000"
            txtaltual.Text = "0000"
            lbestado.Text = "NULO"
            lbnroobs.Text = 0
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            txttipo.ReadOnly = True
            txtaltual.ReadOnly = True
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM tipdoc ORDER BY tipodoc LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txttipo.Text = tabla.Rows(0).Item(0)
                txtdoc.Text = tabla.Rows(0).Item(2)
                BuscarGrupo(tabla.Rows(0).Item(1))
                BuscarIniAct(tabla.Rows(0).Item(1), tabla.Rows(0).Item(0))
                txtdoc.Text = tabla.Rows(0).Item(2)
                lbnroobs.Text = i + 1
                txtgrupodoc.Enabled = False
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            txtaltual.ReadOnly = True
            txttipo.ReadOnly = True
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM tipdoc"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM tipdoc ORDER BY tipodoc LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txttipo.Text = tabla.Rows(0).Item(0)
                txtdoc.Text = tabla.Rows(0).Item(2)
                BuscarGrupo(tabla.Rows(0).Item(1))
                BuscarIniAct(tabla.Rows(0).Item(1), tabla.Rows(0).Item(0))
                txtdoc.Text = tabla.Rows(0).Item(2)
                lbnroobs.Text = i + 1
                txtgrupodoc.Enabled = False
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            txtaltual.ReadOnly = True
            txttipo.ReadOnly = True
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM tipdoc"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT * FROM tipdoc ORDER BY tipodoc LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txttipo.Text = tabla.Rows(0).Item(0)
            txtdoc.Text = tabla.Rows(0).Item(2)
            BuscarGrupo(tabla.Rows(0).Item(1))
            BuscarIniAct(tabla.Rows(0).Item(1), tabla.Rows(0).Item(0))
            txtdoc.Text = tabla.Rows(0).Item(2)
            lbnroobs.Text = i + 1
            txtgrupodoc.Enabled = False
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarGrupo(ByVal gr As String)
        Dim cad, cad2 As String
        For i = 0 To txtgrupodoc.Items.Count - 1
            cad = txtgrupodoc.Items.Item(i).ToString
            'MsgBox(cad)
            cad2 = cad(0) & cad(1)
            If gr = cad2 Then
                txtgrupodoc.Text = cad
            End If
        Next
    End Sub
    Public Sub BuscarIniAct(ByVal grupo As String, ByVal tipo As String)
        If grupo = "FC" Then
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT iniciofc,actualfc FROM tipdoc where tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            InicioActual(tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
            lbini.Text = "--------"
            lbact.Text = "--------"
            txtgrupodoc.Enabled = False
        Else
            Dim tabla2 As New DataTable
            BuscarPeriodo()
            lbini.Text = PerActual
            lbact.Text = PerActual
            Dim cadena, cadI, cadA As String
            cadena = PerActual
            cadA = "actual"
            cadI = "inicio"
            For x = 0 To cadena.Length - 1
                If cadena.Chars(x) = "/" Then
                    Exit For
                Else
                    cadA = cadA & cadena.Chars(x)
                    cadI = cadI & cadena.Chars(x)
                End If
            Next
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & cadI & "," & cadA & " FROM tipdoc WHERE tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            InicioActual(tabla2.Rows(0).Item(0), tabla2.Rows(0).Item(1))
            txtgrupodoc.Enabled = False
        End If
    End Sub
    Public Sub InicioActual(ByVal ini As Long, ByVal act As Long)
        txtinicial.Text = NumeroDoc(ini)
        '*********************************************
        txtaltual.Text = NumeroDoc(act)
    End Sub
    
    '**************************************************************************************
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If per_tdoc <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        txttipo.Text = ""
        txtaltual.ReadOnly = True
        txttipo.ReadOnly = False
        txtgrupodoc.Text = "AJ-->AJUSTE DE CONTABILIDAD"
        txtgrupodoc.Enabled = True
        txtinicial.Text = NumeroDoc(0)
        txtaltual.Text = NumeroDoc(0)
        lbestado.Text = "NUEVO"
        Descripcion()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM tipdoc"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        lbnroobs.Text = tabla.Rows(0).Item(0) + 1
        txttipo.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Try
            If lbestado.Text = "NUEVO" Then
                ValidarGuardar()
            ElseIf lbestado.Text = "EDITAR" Then
                ValidarModificar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        txtaltual.ReadOnly = True
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If per_tdoc <> "E" Then
                    MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
                    Exit Sub
                End If
                lbestado.Text = "EDITAR"
                If txtgrupodoc.Text = "FC-->FACTURA DE VENTA" Or txtgrupodoc.Text = "FP-->FACTURA DE PROVEEDORES" Then txtaltual.ReadOnly = False
                txtgrupodoc.Enabled = True
                txtdoc.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Try
            If per_tdoc <> "E" Then
                MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT tipodoc,grupo,descripcion FROM tipdoc ORDER BY tipodoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No se han creado documentos...  ", MsgBoxStyle.Information, "Buscar Documentos")
                Exit Sub
            End If
            FrmTipoDocumentos.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmTipoDocumentos.gitems.Item(0, i).Value = i + 1
                FrmTipoDocumentos.gitems.Item(1, i).Value = tabla.Rows(i).Item(2)
                FrmTipoDocumentos.gitems.Item(2, i).Value = tabla.Rows(i).Item(0)
                FrmTipoDocumentos.gitems.Item(3, i).Value = tabla.Rows(i).Item(1)
            Next
            FrmTipoDocumentos.ShowDialog()
            txtinicial_LostFocus(AcceptButton, AcceptButton)
            txtaltual_LostFocus(AcceptButton, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Public Sub ValidarGuardar()
        If txttipo.Text = "" Then
            MsgBox("Favor digite el campo del tipo del documento", MsgBoxStyle.Information, "SAE Verificación")
            txttipo.Focus()
            Exit Sub
        ElseIf txtdoc.Text = "" Then
            MsgBox("Favor digite el campo descripción", MsgBoxStyle.Information, "SAE Verificación")
            txtdoc.Focus()
            Exit Sub
        ElseIf txttipo.Text = "CA" Then
            MsgBox("El documento CA no se puede utilizar porque es reservado para el Cierre de Año, verifique. ", MsgBoxStyle.Information, "SAE Verificación")
            txttipo.Focus()
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            MsgBox("Ya existe un tipo de documento con la sigla " & txttipo.Text & ", Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            txttipo.Focus()
            Exit Sub
        End If

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            '........
            Guar_MovUser("CONTABILIDAD", "GUARDAR NUEVO DOCUMENTO " & txttipo.Text, "", "", "")
            '.............
        End If
       
        Guardar()
    End Sub
    Public Sub Guardar()
        Dim grupo, gru As String
        grupo = txtgrupodoc.Text
        gru = grupo(0) & grupo(1)
        myCommand.Parameters.Clear()
        Refresh()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?tipo", Trim(txttipo.Text).ToString)
        myCommand.Parameters.AddWithValue("?grupo", gru)
        myCommand.Parameters.AddWithValue("?descripcion", CambiaCadena(txtdoc.Text.ToString, 30))
        myCommand.CommandText = "INSERT INTO tipdoc Values(?tipo,?grupo,?descripcion, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        txtgrupodoc.Enabled = False
        lbestado.Text = "GUARDADO"
    End Sub
    Private Sub AudMovimiento()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                Dim camp As String = ""
                Dim nuev As String = ""
                Dim anter As String = ""

                Dim csul As New DataTable
                myCommand.CommandText = "SELECT * FROM tipdoc where tipodoc = '" & txttipo.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(csul)
                Refresh()
                If csul.Rows.Count > 0 Then
                    If csul.Rows(0).Item("descripcion") <> txtdoc.Text Then
                        camp = "DESCRIPCION"
                        nuev = txtdoc.Text
                        anter = csul.Rows(0).Item("descripcion")
                    End If
                End If

                '........
                Guar_MovUser("CONTABILIDAD", "MODIFICAR DOCUMENTO " & txttipo.Text, camp, anter, nuev)
                '.............

            Catch ex As Exception
                MsgBox("Error auditar movimiento ", MsgBoxStyle.Information, "SAE")
            End Try
        End If
    End Sub
    Public Sub ValidarModificar()
        If txtdoc.Text = "" Then
            MsgBox("Favor digite el campo descripción", MsgBoxStyle.Information, "SAE Verificación")
            txtdoc.Focus()
            Exit Sub
        End If

        AudMovimiento()
        Modificar()
    End Sub
    Public Sub Modificar()
        myCommand.Parameters.Clear()
        Refresh()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?tipodoc", Trim(txttipo.Text).ToString)
        myCommand.Parameters.AddWithValue("?descripcion", CambiaCadena(txtdoc.Text.ToString, 30))
        myCommand.CommandText = "Update tipdoc set descripcion=?descripcion WHERE tipodoc=?tipodoc;"
        myCommand.ExecuteNonQuery()
        ModificarActual()
        MsgBox("Los datos fueron modificados correctamente... ", MsgBoxStyle.Information, "Guardar Datos")
        Cerrar()
        txtaltual.ReadOnly = True
        txtgrupodoc.Enabled = False
        lbestado.Text = "EDITADO"
    End Sub
    Public Sub ModificarActual()
        If txtgrupodoc.Text = "FC-->FACTURA DE VENTA" Or txtgrupodoc.Text = "FP-->FACTURA DE PROVEEDORES" Then
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?tipodoc", Trim(txttipo.Text).ToString)
            myCommand.Parameters.AddWithValue("?actualfc", Val(txtaltual.Text))
            myCommand.CommandText = "Update tipdoc set actualfc=?actualfc WHERE tipodoc=?tipodoc;"
            myCommand.ExecuteNonQuery()
        End If
    End Sub

    Private Sub txtgrupodoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrupodoc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txttipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyChar = "_" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtdoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                CmdListo.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub txtinicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinicial.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtaltual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltual.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "EDITAR") And (txtgrupodoc.Text = "FC-->FACTURA DE VENTA" Or txtgrupodoc.Text = "FP-->FACTURA DE PROVEEDORES") Then
                validarnumero(txtinicial, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtgrupodoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrupodoc.SelectedIndexChanged
        Descripcion()
        If lbestado.Text = "EDITAR" And (txtgrupodoc.Text = "FC-->FACTURA DE VENTA" Or txtgrupodoc.Text = "FP-->FACTURA DE PROVEEDORES") Then txtaltual.ReadOnly = False
    End Sub
    Public Sub Descripcion()
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Dim cad, cad2 As String
            cad = txtgrupodoc.Text
            cad2 = ""
            For i = 5 To cad.Length - 1
                cad2 = cad2 & cad(i)
            Next
            txtdoc.Text = cad2
        End If
    End Sub

    Private Sub txtinicial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinicial.LostFocus
        txtinicial.Text = NumeroDoc(txtinicial.Text)
    End Sub
    Private Sub txtaltual_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaltual.LostFocus
        txtaltual.Text = NumeroDoc(txtaltual.Text)
    End Sub
End Class