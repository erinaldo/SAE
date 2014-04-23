Public Class FrmVendedores
    Dim f As Integer = 0

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            lbnumero.Text = ""
            txtnit.Text = ""
            txtvendedor.Text = ""
            txtdir.Text = ""
            txttel.Text = ""
            cbestado.Text = "activo"
            txtzona.Text = ""
            txtpalm.Text = ""
            cbpalm.Text = "no"
            lbestado.Text = "NULO"
            gitems.Rows.Clear()
            gitems.RowCount = 1
            Exit Sub
        End If
        txtnit.Text = tabla.Rows(0).Item(0)
        txtvendedor.Text = tabla.Rows(0).Item(1)

        Buscarvendedor()
        lbnumero.Text = "1"
        lbestado.Text = "CONSULTA"
        CmdPrimero.Focus()
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            txtnit.Text = tabla.Rows(0).Item(0)
            txtvendedor.Text = tabla.Rows(0).Item(1)
            Buscarvendedor()
            lbestado.Text = "CONSULTA"
            CmdAtras.Focus()
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM vendedores"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT * FROM vendedores LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtnit.Text = tabla.Rows(0).Item(0)
            txtvendedor.Text = tabla.Rows(0).Item(1)
            Buscarvendedor()
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
            CmdSiguiente.Focus()
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM vendedores"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay vendedores en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * FROM vendedores LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtnit.Text = tabla.Rows(0).Item(0)
        txtvendedor.Text = tabla.Rows(0).Item(1)
        Buscarvendedor()
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
        CmdUltimo.Focus()
    End Sub
    '*******************************************************
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        lbestado.Text = "NUEVO"
        lbnumero.Text = ""
        txtnit.Text = ""
        txtvendedor.Text = ""
        txtdir.Text = ""
        txttel.Text = ""
        cbestado.Text = "activo"
        txtzona.Text = ""
        txtpalm.Text = ""
        cbpalm.Text = "no"
        gitems.Rows.Clear()
        gitems.RowCount = 1
        txtnit.Focus()
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False

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
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM vendedores"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) > 0 Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            cmdNuevo.Focus()
            lbestado.Text = ""
            lbnumero.Text = "0"
            txtnit.Text = ""
            txtvendedor.Text = ""
            txtdir.Text = ""
            txttel.Text = ""
            gitems.Rows.Clear()

        End If

        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        cmdNuevo.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True

    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            lbestado.Text = "EDITAR"
            txtvendedor.Focus()
            gitems.RowCount = gitems.RowCount + 1

            If FrmPrincipal.cmdAuditoria.Visible = True Then
                limpiarAD()
                llenarAD()
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        cmdNuevo.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        cargarvendedor()
        If lbestado.Text = "CONSULTA" Then
            Buscarvendedor()
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub Guardar()
        If txtnit.Text = "" Or txtvendedor.Text = "" Then Exit Sub
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?nitv", txtnit.Text.ToString)
        myCommand.Parameters.AddWithValue("?nombre", txtvendedor.Text.ToString)
        myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
        myCommand.Parameters.AddWithValue("?telefono", txttel.Text.ToString)
        myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
        myCommand.Parameters.AddWithValue("?zona", txtzona.Text.ToString)
        myCommand.Parameters.AddWithValue("?palm", cbpalm.Text.ToString)
        myCommand.Parameters.AddWithValue("?codpalm", txtpalm.Text.ToString)
        'myCommand.Parameters.AddWithValue("?nitv", txtnit.Text.ToString)
        myCommand.CommandText = "INSERT INTO vendedores  " _
                              & " Values(?nitv,?nombre,?dir,?telefono,?estado,?zona,?palm,?codpalm); "
        myCommand.ExecuteNonQuery()

        For i = 0 To gitems.Rows.Count - 2
            Dim por As String = ""
            por = Replace(gitems.Item("nit", i).Value, ",", ".")
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO vend_cc  " _
                                 & " Values('" & txtnit.Text.ToString & "', '" & gitems.Item("buscar", i).Value & "' ,'" & por & "','" & gitems.Item("RECAUDO", i).Value & "'); "
            myCommand.ExecuteNonQuery()

        Next
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "GUARDAR VENDEDOR NIT: " & txtnit.Text & " - " & txtvendedor.Text, "", "", "")
        End If
        '.....

        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        CmdUltimo_Click(AcceptButton, AcceptButton)
        lbestado.Text = "GUARDADO"
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del Vendedor se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.AddWithValue("?nombre", txtvendedor.Text.ToString)
            myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
            myCommand.Parameters.AddWithValue("?telefono", txttel.Text.ToString)
            myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
            myCommand.Parameters.AddWithValue("?zona", txtzona.Text.ToString)
            myCommand.Parameters.AddWithValue("?palm", cbpalm.Text.ToString)
            myCommand.Parameters.AddWithValue("?codpalm", txtpalm.Text.ToString)
            myCommand.CommandText = "Update vendedores set nombre=?nombre,dir=?dir,telefono=?telefono,estado=?estado,zona=?zona,palm=?palm,codpalm=?codpalm WHERE nitv=" & txtnit.Text & ";"
            myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM vend_cc WHERE nitv = '" & txtnit.Text.ToString & "'  "
            myCommand.ExecuteNonQuery()

            For i = 0 To gitems.Rows.Count - 2
                Dim por As String = ""
                por = Replace(gitems.Item("nit", i).Value, ",", ".")
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO vend_cc  " _
                                     & " Values('" & txtnit.Text.ToString & "', '" & gitems.Item("buscar", i).Value & "' ,'" & por & "','" & gitems.Item("RECAUDO", i).Value & "'); "
                myCommand.ExecuteNonQuery()
            Next

            If FrmPrincipal.cmdAuditoria.Visible = True Then
                auditardatos()
            End If

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lbestado.Text = "EDITADO"
            cmdNuevo.Enabled = True
            CmdEditar.Enabled = True
            CmdEliminar.Enabled = True
            CmdMostrar.Enabled = True

        End If
    End Sub
    '*******************************************************
    Private Sub FrmVendedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = " SELECT count(*) FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "' AND rol='admin';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows(0).Item(0) < 1 Then
                MsgBox("No tiene los permisos para esta interfaz. ", MsgBoxStyle.Information, "SAE Control")
                Me.Close()
                Exit Sub
            Else
                Dim tabla_c As New DataTable
                myCommand.CommandText = " SELECT comventa FROM parafacgral"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla_c)
                Refresh()
                If tabla_c.Rows(0).Item(0) = "NO" Then
                    GroupBox3.Text = "Conceptos Comisionables - Desactivado segun parametros"
                    cmdcc.Enabled = False
                    Button1.Enabled = False
                Else
                    GroupBox3.Text = "Conceptos Comisionables "
                    cmdcc.Enabled = True
                    Button1.Enabled = True
                End If
            End If
        Catch ex As Exception
            MsgBox("No tiene los permisos para esta interfaz. ", MsgBoxStyle.Information, "SAE Control")
            Me.Close()
            Exit Sub
        End Try
        MiConexion(bda)
        Cerrar()
        CmdPrimero_Click(AcceptButton, AcceptButton)

    End Sub

    '*******************************************************
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress

        If lbestado.Text = "NUEVO" Then
            ValidarNIT(txtnit, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtvendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvendedor.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtdir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdir.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txttel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtzona_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzona.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtpalm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpalm.KeyPress
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    '*******************************************
    Public Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            If items < 50 Then
                FrmSelVendedor.gitems.RowCount = 50
            Else
                FrmSelVendedor.gitems.RowCount = items + 1
            End If
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item(1)
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item(0)
            Next
            FrmSelVendedor.lbform.Text = "vendedor"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Buscarvendedor()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then  'mostrar todos los articulos porq ninguno coincide
            MsgBox("El nit/cédula del vendedor no existe en los registros.", MsgBoxStyle.Information, "Verificando")
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else  'mostrar uno solo q coinside
            txtvendedor.Text = tabla.Rows(0).Item("nombre")
            txtdir.Text = tabla.Rows(0).Item("dir")
            txttel.Text = tabla.Rows(0).Item("telefono")
            cbestado.Text = tabla.Rows(0).Item("estado")
            txtzona.Text = tabla.Rows(0).Item("zona")
            cbpalm.Text = tabla.Rows(0).Item("palm")
            txtpalm.Text = tabla.Rows(0).Item("codpalm")

            gitems.Rows.Clear()

            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT v.codcon, c.concepto, v.porcomi, v.dia_cob FROM vend_cc v, concomi c WHERE v.nitv = '" & txtnit.Text & "' AND c.codcon = v.codcon ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()

            For i = 0 To tabla2.Rows.Count - 1
                gitems.Rows.Add(tabla2.Rows(i).Item(0), tabla2.Rows(i).Item(1), tabla2.Rows(i).Item(2), tabla2.Rows(i).Item(3))
            Next
            lbestado.Text = "CONSULTA"

            CmdEditar.Enabled = True
            cmdNuevo.Enabled = True

        End If
    End Sub

    Private Sub cbpalm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpalm.SelectedIndexChanged
        If cbpalm.Text = "si" Then
            txtpalm.Enabled = True
        Else
            txtpalm.Enabled = False
        End If
    End Sub

    Private Sub cmdcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcc.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub

        lbadd.Text = "no"

        FrmConcepComi.Lbform.Text = "vendedores"
        FrmConcepComi.lbfila.Text = gitems.Rows.Count - 1
        FrmConcepComi.ShowDialog()
        If lbadd.Text = "si" Then
            gitems.RowCount = gitems.RowCount + 1
        End If


    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        gitems.Rows.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub


        Dim resultado As MsgBoxResult
        resultado = MsgBox("¿Esta seguro que desa eliminar el concepto seleccionado ?", MsgBoxStyle.YesNo, "Eliminar Concepto ")
        If resultado = MsgBoxResult.Yes Then

            If f = gitems.RowCount - 1 Then Exit Sub
            gitems.Rows.RemoveAt(f)

        End If

    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        f = e.RowIndex        'captura fila
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT nitv FROM vendedores ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            For i = 0 To tb.Rows.Count - 1
                If lbestado.Text = "NUEVO" Then
                    If tb.Rows(i).Item(0) = txtnit.Text Then
                        MsgBox("El vendedor ya se encuentra registrado", MsgBoxStyle.Information)
                        Buscarvendedor()
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub limpiarAD()
        txtnit1.Text = ""
        txtvendedor1.Text = ""
        cbestado1.Text = ""
        txtdir1.Text = ""
        txttel1.Text = ""
        gitemsA.Rows.Clear()
    End Sub
    Private Sub llenarAD()
        txtnit1.Text = txtnit.Text
        txtvendedor1.Text = txtvendedor.Text
        cbestado1.Text = cbestado.Text
        txtdir1.Text = txtdir.Text
        txttel1.Text = txttel.Text
        gitemsA.RowCount = gitems.RowCount
        For i = 0 To gitemsA.RowCount - 1
            gitemsA.Item("cod", i).Value = gitems.Item("buscar", i).Value
            gitemsA.Item("conc", i).Value = gitems.Item("nombre", i).Value
            gitemsA.Item("por", i).Value = gitems.Item("nit", i).Value
            gitemsA.Item("recau", i).Value = gitems.Item("recaudo", i).Value
        Next
    End Sub
    Private Sub auditardatos()
        Try

        
            Dim camp As String = ""
            Dim ant As String = ""
            Dim nue As String = ""

            If txtnit.Text <> txtnit1.Text Then
                camp = camp & "NIT; "
                ant = ant & txtnit1.Text & "; "
                nue = nue & txtnit.Text & "; "
            End If
            If txtvendedor.Text <> txtvendedor1.Text Then
                camp = camp & "NOMBRE; "
                ant = ant & txtvendedor1.Text & "; "
                nue = nue & txtvendedor.Text & "; "
            End If
            If txtdir.Text <> txtdir1.Text Then
                camp = camp & "DIRECCION; "
                ant = ant & txtdir1.Text & "; "
                nue = nue & txtdir.Text & "; "
            End If
            If txttel.Text <> txttel1.Text Then
                camp = camp & "TELEFONO; "
                ant = ant & txttel1.Text & "; "
                nue = nue & txttel.Text & "; "
            End If
            If cbestado.Text <> cbestado1.Text Then
                camp = camp & "ESTADO; "
                ant = ant & cbestado1.Text & "; "
                nue = nue & cbestado.Text & "; "
            End If

            '' No de Items
            'Dim ok = ""
            'For i = 0 To gitemsA.RowCount - 1
            '    For j = 0 To gitems.RowCount - 1
            '        If gitemsA.Item("cod", i).Value <> "" And gitemsA.Item("cod", j).Value <> "" Then
            '            If gitemsA.Item("cod", i).Value = gitems.Item("buscar", j).Value Then
            '                ok = "e"
            '                Exit For
            '            End If
            '        End If
            '    Next
            '    If gitemsA.Item("cod", i).Value <> "" Then
            '        If ok <> "e" Then
            '            camp = camp & "ELIMINAR CONCEPTO COMISIONABLE COD: " & gitemsA.Item("cod", i).Value & "; "
            '            ant = ant & " ;"
            '            nue = nue & " ;"
            '        End If
            '        ok = ""
            '    End If
            'Next

            'ok = ""
            'For j = 0 To gitems.RowCount - 1
            '    For i = 0 To gitemsA.RowCount - 1
            '        If gitems.Item("buscar", j).Value <> "" And gitemsA.Item("cod", j).Value <> "" Then
            '            If gitems.Item("buscar", j).Value = gitemsA.Item("cod", i).Value Then
            '                ok = "e"
            '                Exit For
            '            End If
            '        End If
            '    Next
            '    If gitems.Item("buscar", j).Value <> "" Then
            '        If ok <> "e" Then
            '            camp = camp & "NUEVO CONCEPTO COMISIONABLE COD: " & gitems.Item("buscar", j).Value & "; "
            '            ant = ant & " ;"
            '            nue = nue & " ;"
            '        End If
            '        ok = ""
            '    End If
            'Next

            '' Validar datos articulos
            'For i = 0 To gitemsA.RowCount - 1
            '    For j = 0 To gitems.RowCount - 1
            '        If gitemsA.Item("cod", i).Value <> "" Then
            '            If gitemsA.Item("cod", i).Value = gitems.Item("buscar", j).Value Then
            '                If CDbl(gitemsA.Item("por", i).Value) <> CDbl(gitems.Item("nit", j).Value) Then
            '                    camp = camp & "PORCENTAJE; "
            '                    ant = ant & gitemsA.Item("por", i).Value & ";"
            '                    nue = nue & gitems.Item("nit", i).Value & ";"
            '                End If
            '                If gitemsA.Item("recau", i).Value <> gitems.Item("recaudo", j).Value Then
            '                    camp = camp & "DIAS DE RECAUDO; "
            '                    ant = ant & gitemsA.Item("recau", i).Value & ";"
            '                    nue = nue & gitems.Item("recaudo", i).Value & ";"
            '                End If
            '                Exit For
            '            End If
            '        End If
            '    Next
            'Next

            Guar_MovUser("FACTURACION", "MODIFICAR VENDEDOR: " & txtnit.Text & txtvendedor.Text, camp, ant, nue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtzona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtzona.LostFocus

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
            Dim ta As New DataTable
            myCommand.CommandText = "SELECT * FROM nomina.areas where nombre_area='" & txtzona.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            Refresh()
            If ta.Rows.Count = 0 Then
                Try
                    txtzona.Text = ""
                    FrmSelArea.lbform.Text = "Vendedor"
                    FrmSelArea.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub
End Class