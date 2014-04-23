Public Class FrmCentroCostos
    Private Sub FrmCentroCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Try
            myCommand.CommandText = "ALTER TABLE  `centrocostos` ADD  `nivel` VARCHAR( 15 ) NOT NULL DEFAULT  'centro';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        BuscarNivel()
        Cerrar()
        lbexiste.Text = ""
        CmdPrimero_Click(AcceptButton, AcceptButton)

    End Sub
    Dim tc As New DataTable
    Dim n1, n2, n3, n4 As Integer

    Private Sub BuscarNivel()
        n1 = 0
        n2 = 0
        n3 = 0
        n4 = 0

        'BUSCAR NIVELES
        Dim cad As String = ""
        'Dim tc As New DataTable
        tc.Clear()
        myCommand.CommandText = "SELECT * FROM ccnivel ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()
        If tc.Rows.Count > 0 Then
            'Grupo
            If tc.Rows(0).Item("lon1") <> 0 Then
                cad = cad & "Grupo (" & tc.Rows(0).Item("lon1") & "), "
                n1 = tc.Rows(0).Item("lon1")
            End If
            'Subgrupo
            If tc.Rows(0).Item("lon2") <> 0 Then
                cad = cad & "SubGrupo (" & tc.Rows(0).Item("lon2") & "), "
                n2 = tc.Rows(0).Item("lon2")
            End If
            'Tipo
            If tc.Rows(0).Item("lon3") <> 0 Then
                cad = cad & "Tipo (" & tc.Rows(0).Item("lon3") & "), "
                n3 = tc.Rows(0).Item("lon3")
            End If
            If tc.Rows(0).Item("lon4") <> 0 Then
                cad = cad & "Centro (" & tc.Rows(0).Item("lon4") & "), "
                n4 = tc.Rows(0).Item("lon4")
            End If

            If chnivel.Checked = True Then
                Label5.Text = "Cantidad de Digitos: " & cad
                Label5.Enabled = True
                If n4 <> 0 Then
                    txtcodigo.MaxLength = n4
                End If
            Else
                Label5.Enabled = False
                txtcodigo.MaxLength = tc.Rows(0).Item("lon4")
            End If

        End If

        
    End Sub


    '***************** BOTONES DE COMANDO *********************
    Public Sub Bloquear()
        txtcodigo.Enabled = False
        txtnombre.Enabled = False
        txtpre.Enabled = False
        '**************************
        cmdNuevo.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdmodificar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Public Sub DesBloquear()
        txtnombre.Enabled = True
        txtpre.Enabled = True
        '**************************
        cmdNuevo.Enabled = False
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        cmdmodificar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If bas_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM centrocostos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtcodigo.Text = ""
        txtnombre.Text = ""
        txtpre.Text = "0,00"
        lbestado.Text = "NUEVO"
        lbnumero.Text = ""
        DesBloquear()
        txtcodigo.Enabled = True
        txtcodigo.Focus()
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If lbestado.Text = "NUEVO" Then
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            Modificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If bas_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        DesBloquear()
        If lbnivel.Text <> "centro" Then
            txtpre.Enabled = False
        Else
            txtpre.Enabled = True
        End If
        lbestado.Text = "EDITAR"
        txtnombre.Focus()
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelCentroCostos.lbform.Text = "centro"
        FrmSelCentroCostos.ShowDialog()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Public Sub Guardar()
        Try
            txtcodigo.Text = Val(txtcodigo.Text)
            If txtcodigo.Text = "0" Then
                txtcodigo.Text = ""
            End If
        Catch ex As Exception

        End Try
        If txtnombre.Text = "" Then
            MsgBox("El nombre no puede ser en blanco, verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtnombre.Focus()
            Exit Sub
        End If
        If lbexiste.Text <> "Bien, código no existe." Then
            MsgBox("Verifique el código del centro de costos.  ", MsgBoxStyle.Information, "SAE Control")
            txtcodigo.Focus()
            Exit Sub
        End If
        If lbnivel.Text = "ninguno" Or lbnivel.Text = "" Then
            MsgBox("Verifique el código del centro de costos.  ", MsgBoxStyle.Information, "SAE Control")
            txtcodigo.Focus()
            Exit Sub
        End If
        If lbnivel.Text = "ninguno" And chnivel.Checked = True Then
            MsgBox("Verifique el código del centro de costos.  ", MsgBoxStyle.Information, "SAE Control")
            txtcodigo.Focus()
            Exit Sub
        End If
        If chnivel.Checked = False Then
            lbnivel.Text = "centro"
        End If
        If lbnivel.Text <> "centro" Then
            txtpre.Text = "0,00"
        End If
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?centro", txtcodigo.Text.ToString)
        myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
        myCommand.Parameters.AddWithValue("?pres", DIN(txtpre.Text))
        myCommand.Parameters.AddWithValue("?nivel", lbnivel.Text)
        myCommand.CommandText = "INSERT INTO centrocostos " _
                                 & " VALUES(?centro,?nombre,?pres,?nivel);"
        myCommand.ExecuteNonQuery()
        Bloquear()
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()

        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                '........
                Guar_MovUser("CONTABILIDAD", "GUARDAR CENTRO DE COSTO " & txtcodigo.Text & " NIVEL:" & lbnivel.Text, "", "", "")
                '.............
            End If
        Catch ex As Exception
            MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "GUARDADO"
    End Sub
    Private Sub AudModificar()
        Dim cam As String = ""
        Dim ant As String = ""
        Dim nue As String = ""
        Dim ta As New DataTable
        myCommand.CommandText = "select * from centrocostos where centro = '" & txtcodigo.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count > 0 Then
            If ta.Rows(0).Item("nombre") <> txtnombre.Text Then
                cam = cam & "NOMBRE,"
                ant = ta.Rows(0).Item("nombre")
                nue = txtnombre.Text & ","
            End If
            If ta.Rows(0).Item("pres") <> txtpre.Text Then
                cam = cam & "PRESUPUESTO,"
                ant = ta.Rows(0).Item("pres")
                nue = txtpre.Text & ","
            End If

            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    '........
                    Guar_MovUser("CONTABILIDAD", "MODIFICAR CENTRO DE COSTO COD: " & txtcodigo.Text, cam, ant, nue)
                    '.............
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If


    End Sub
    Public Sub Modificar()
        If txtnombre.Text = "" Then
            MsgBox("El nombre no puede ser en blanco, verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtnombre.Focus()
            Exit Sub
        End If
        If chnivel.Checked = False Then
            lbnivel.Text = "centro"
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del centro de costos se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            AudModificar()
            MiConexion(bda)
            If lbnivel.Text <> "centro" Then
                txtpre.Text = "0,00"
            End If
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
            myCommand.Parameters.AddWithValue("?nivel", lbnivel.Text.ToString)
            myCommand.Parameters.AddWithValue("?pres", DIN(txtpre.Text))
            myCommand.CommandText = "UPDATE centrocostos SET nombre=?nombre, nivel=?nivel, pres=?pres WHERE centro='" & txtcodigo.Text & "';"
            myCommand.ExecuteNonQuery()
            Bloquear()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lbestado.Text = "EDITADO"
        End If
    End Sub
    '************** DESPLAZAMIENTO ******************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos ORDER BY centro LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                txtcodigo.Text = ""
                txtnombre.Text = ""
                lbestado.Text = "NULO"
                lbnumero.Text = ""
                Exit Sub
            End If
            txtcodigo.Text = tabla.Rows(0).Item("centro")
            txtnombre.Text = tabla.Rows(0).Item("nombre")
            txtpre.Text = CalcularP(tabla.Rows(0).Item("centro"), tabla.Rows(0).Item("nivel"))
            lbnumero.Text = "1"
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            txtcodigo.Text = ""
            txtnombre.Text = ""
            lbestado.Text = "NULO"
            lbnumero.Text = ""
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Bloquear()
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos ORDER BY centro LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            txtcodigo.Text = tabla.Rows(0).Item("centro")
            txtnombre.Text = tabla.Rows(0).Item("nombre")
            txtpre.Text = CalcularP(tabla.Rows(0).Item("centro"), tabla.Rows(0).Item("nivel"))
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            lbestado.Text = "CONSULTA"
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Bloquear()
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM centrocostos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT * FROM centrocostos ORDER BY centro LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcodigo.Text = tabla.Rows(0).Item("centro")
            txtnombre.Text = tabla.Rows(0).Item("nombre")
            txtpre.Text = CalcularP(tabla.Rows(0).Item("centro"), tabla.Rows(0).Item("nivel"))
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Bloquear()
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM centrocostos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay centros de costos en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * FROM centrocostos ORDER BY centro LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtcodigo.Text = tabla.Rows(0).Item("centro")
        txtnombre.Text = tabla.Rows(0).Item("nombre")
        txtpre.Text = CalcularP(tabla.Rows(0).Item("centro"), tabla.Rows(0).Item("nivel"))
        If chnivel.Checked = False Then
            lbnivel.Text = "centro"
        End If
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
    End Sub
    Function CalcularP(ByVal cc As String, ByVal niv As String)
        Dim p As String = "0,00"
        Try

            Dim tcc As New DataTable
            If niv <> "centro" Then
                myCommand.CommandText = "SELECT SUM(pres) FROM centrocostos WHERE centro LIKE '" & cc & "%' "
            Else
                myCommand.CommandText = "SELECT SUM(pres) FROM centrocostos WHERE centro = '" & cc & "' "
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcc)
            p = Moneda(tcc.Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return p
    End Function
    '*********** CAJAS DE TEXTO ***********************************
    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarMoneda(txtpre, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub txtpre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpre.LostFocus
        txtpre.Text = Moneda(txtpre.Text)
    End Sub

    Private Sub txtcodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        validarnumero(txtcodigo, e)
    End Sub

    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo.TextChanged

        If txtcodigo.Text = "" Then
            lbexiste.Text = ""
            lbnivel.Text = ""
            Exit Sub
        End If
        If chnivel.Checked = True Then
            If txtcodigo.Text.Length = n1 And n1 <> 0 Then
                lbnivel.Text = "grupo"
            ElseIf txtcodigo.Text.Length = n2 And n2 <> 0 Then
                lbnivel.Text = "subgrupo"
            ElseIf txtcodigo.Text.Length = n3 And n3 <> 0 Then
                lbnivel.Text = "tipo"
            ElseIf txtcodigo.Text.Length = n4 And n4 <> 0 Then
                lbnivel.Text = "centro"
            Else
                lbnivel.Text = "ninguno"
            End If
        End If

        If lbestado.Text = "NUEVO" Then
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If chnivel.Checked = False Then
                lbnivel.Text = "centro"
            End If
            If tabla.Rows.Count = 0 Then
                lbexiste.ForeColor = Color.ForestGreen
                lbexiste.Text = "Bien, código no existe."
            Else
                lbexiste.ForeColor = Color.Maroon
                lbexiste.Text = "Código ya existe(" & tabla.Rows(0).Item("nombre").ToString & "), Verifique."
            End If
        Else
            lbexiste.Text = ""
        End If
    End Sub

    Private Sub txtpre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpre.TextChanged
        If lbestado.Text = "NUEVO" And lbnivel.Text <> "centro" Then
            txtpre.Text = "0,00"
        End If
    End Sub

    Private Sub chnivel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chnivel.CheckedChanged

        BuscarNivel()

        If chnivel.Checked = False Then
            lbnivel.Text = "centro"
            GroupBox2.Enabled = True
        Else
            If tc.Rows.Count > 0 Then
                GroupBox2.Enabled = True
            Else
                MsgBox("No ha definido los Niveles para los Centro de Costo", MsgBoxStyle.Information, "Verificación")
                GroupBox2.Enabled = False
            End If
        End If
    End Sub
End Class