Public Class FrmUsuarios

    '****** COMANDOS ************************
    Public Sub PonerenCero()
        cbter.Text = "N"
        cbdoc.Text = "N"
        cbimp.Text = "N"
        '*********************
        conta_bas.Text = "N"
        conta_tran.Text = "N"
        conta_info.Text = "N"
        conta_proc.Text = "N"
        '*********************
        inve_bas.Text = "N"
        inve_tra.Text = "N"
        inve_inf.Text = "N"
        inve_pro.Text = "N"
        '*********************
        fact_bas.Text = "N"
        fact_tra.Text = "N"
        fact_inf.Text = "N"
        fact_pro.Text = "N"
        '*********************
        cart_bas.Text = "N"
        cart_tra.Text = "N"
        cart_inf.Text = "N"
        cart_pro.Text = "N"
        '*********************
        prov_bas.Text = "N"
        prov_tra.Text = "N"
        prov_inf.Text = "N"
        prov_pro.Text = "N"
        '*********************
        nomi_bas.Text = "N"
        nomi_tra.Text = "N"
        nomi_inf.Text = "N"
        nomi_pro.Text = "N"
    End Sub
    Public Sub Bloquear()
        g_gral.Enabled = False
        g_conta.Enabled = False
        g_inve.Enabled = False
        g_fact.Enabled = False
        g_cart.Enabled = False
        g_prove.Enabled = False
        g_nomi.Enabled = False
        cb_ct.Visible = False
    End Sub
    Public Sub DesBloquear()
        g_gral.Enabled = True
        If FrmPrincipal.Contabilidad.Enabled = True Then g_conta.Enabled = True
        If FrmPrincipal.Inventarios.Enabled = True Then g_inve.Enabled = True
        If FrmPrincipal.Facturacion.Enabled = True Then g_fact.Enabled = True
        If FrmPrincipal.Cartera.Enabled = True Then g_cart.Enabled = True
        If FrmPrincipal.Proveedores.Enabled = True Then g_prove.Enabled = True
        If FrmPrincipal.Nomina.Enabled = True Then g_nomi.Enabled = True
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Try
            If lbestado.Text <> "NUEVO" Then
                txtnombres.Text = ""
                txtapellidos.Text = ""
                txtuser.Text = ""
                txtpass.Text = ""
                txtpass2.Text = ""
                cbrol.Text = "consulta"
                cbestado.Text = "activo"
                lbestado.Text = "NUEVO"
                lbnroobs.Text = ""
                Activar()
                PonerenCero()
                DesBloquear()
                txtnombres.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
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
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Try
            If lbestado.Text <> "CONSULTA" And lbestado.Text <> "NULO" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                lbestado.Text = "EDITAR"
                Activar()
                DesBloquear()
                txtnombres.Focus()
                cb_ct.Visible = True
                cb_ct.Checked = False
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAbrir.Click

    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM usuarios ORDER BY rol,apellidos,nombres;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <= 0 Then
            MsgBox("No hay usuarios creados, verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        FrmVerUsuarios.gitems.RowCount = tabla.Rows.Count + 1
        For i = 0 To tabla.Rows.Count - 1
            FrmVerUsuarios.gitems.Item(1, i).Value = tabla.Rows(i).Item("login")
            FrmVerUsuarios.gitems.Item(2, i).Value = tabla.Rows(i).Item("apellidos")
            FrmVerUsuarios.gitems.Item(3, i).Value = tabla.Rows(i).Item("nombres")
            FrmVerUsuarios.gitems.Item(4, i).Value = tabla.Rows(i).Item("rol")
            FrmVerUsuarios.gitems.Item(5, i).Value = tabla.Rows(i).Item("estado")
        Next
        FrmVerUsuarios.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarPermiso()
            DesActivar()
            Bloquear()
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub Activar()
        lbuser.Visible = False
        txtnombres.ReadOnly = False
        txtapellidos.ReadOnly = False
        If lbestado.Text = "EDITAR" Then
            txtuser.ReadOnly = True
        Else
            txtuser.ReadOnly = False
        End If
        If txtuser.Text = "sae" Then
            txtpass.ReadOnly = True
            txtpass2.ReadOnly = True
            cbrol.Enabled = False
            cbestado.Enabled = False
        Else
            txtpass.ReadOnly = False
            txtpass2.ReadOnly = False
            cbrol.Enabled = True
            cbestado.Enabled = True
        End If
    End Sub
    Public Sub DesActivar()
        lbuser.Visible = False
        txtnombres.ReadOnly = True
        txtapellidos.ReadOnly = True
        txtuser.ReadOnly = True
        txtpass.ReadOnly = True
        txtpass2.ReadOnly = True
        cbrol.Enabled = False
        cbestado.Enabled = False
    End Sub
    Public Sub ValidarGuardar()
        If txtnombres.Text = "" Then
            MsgBox("Favor verifique el campo NOMBRES...", MsgBoxStyle.Information, "SAE Verificación")
            txtnombres.Focus()
            Exit Sub
        ElseIf txtapellidos.Text = "" Then
            MsgBox("Favor verifique el campo APELLIDOS...", MsgBoxStyle.Information, "SAE Verificación")
            txtapellidos.Focus()
            Exit Sub
        ElseIf txtuser.Text = "" Then
            MsgBox("Favor verifique el campo USUARIO...", MsgBoxStyle.Information, "SAE Verificación")
            txtuser.Focus()
            Exit Sub
        ElseIf lbuser.ForeColor = Color.Red Then
            MsgBox("Favor verifique el usuario ya existe...", MsgBoxStyle.Information, "SAE Verificación")
            txtuser.Focus()
            Exit Sub
        ElseIf txtpass.Text = "" Then
            MsgBox("Favor verifique el campo CONTRASEÑA...", MsgBoxStyle.Information, "SAE Verificación")
            txtpass.Focus()
            Exit Sub
        ElseIf txtpass.Text <> txtpass2.Text Then
            MsgBox("Favor verifique las contraseñas NO coinciden...", MsgBoxStyle.Information, "SAE Verificación")
            txtuser.Focus()
            Exit Sub
        End If
        Guardar()
    End Sub
    Function TestEncoding2()
        Dim plainText As String = "sae"
        Dim password As String = txtuser.Text
        If txtuser.Text.ToLower = "sae" Then password = "root"
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return (cipherText)
    End Function
    Function TestEncoding()
        Dim plainText As String = "sae"
        Dim password As String = txtpass.Text
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return (cipherText)
    End Function
    Public Sub Guardar()
        MiConexion("sae")
        Dim pass As String
        pass = TestEncoding()
        Dim cad As String = ""
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?nombres", txtnombres.Text.ToString)
        myCommand.Parameters.AddWithValue("?apellidos", txtapellidos.Text.ToString)
        myCommand.Parameters.AddWithValue("?login", txtuser.Text.ToString)
        myCommand.Parameters.AddWithValue("?passw", pass)
        myCommand.Parameters.AddWithValue("?rol", cbrol.Text.ToString)
        myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
        For i = 1 To 27
            cad = cad & ",'N'"
        Next
        'MsgBox("INSERT INTO usuarios VALUES(?nombres,?apellidos,?login,?passw,?rol,?estado" & cad & ");")
        myCommand.CommandText = "INSERT INTO usuarios VALUES(?nombres,?apellidos,?login,?passw,?rol,?estado" & cad & ",'N');"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        ModificarPermisos()
        Cerrar()
        Bloquear()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        DesActivar()
        lbestado.Text = "GUARDADO"
    End Sub
    Public Sub ValidarModificar()
        If txtnombres.Text = "" Then
            MsgBox("Favor verifique el campo NOMBRES...", MsgBoxStyle.Information, "SAE Verificación")
            txtnombres.Focus()
            Exit Sub
        ElseIf txtapellidos.Text = "" Then
            MsgBox("Favor verifique el campo APELLIDOS...", MsgBoxStyle.Information, "SAE Verificación")
            txtapellidos.Focus()
            Exit Sub
            'ElseIf txtuser.Text = "" Then
            '    MsgBox("Favor verifique el campo USUARIO...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtuser.Focus()
            '    Exit Sub
            'ElseIf lbuser.ForeColor = Color.Red Then
            '    MsgBox("Favor verifique el usuario ya existe...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtuser.Focus()
            '    Exit Sub
            'ElseIf txtpass.Text = "" Then
            '    MsgBox("Favor verifique el campo CONTRASEÑA...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtpass.Focus()
            '    Exit Sub
            'ElseIf txtpass.Text <> txtpass2.Text Then
            '    MsgBox("Favor verifique las contraseñas NO coinciden...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtuser.Focus()
            '    Exit Sub
        End If
        Modificar()
    End Sub

    Public Sub Modificar()
        MiConexion("sae")
       
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?login", txtuser.Text.ToString)
        myCommand.Parameters.AddWithValue("?nombres", txtnombres.Text.ToString)
        myCommand.Parameters.AddWithValue("?apellidos", txtapellidos.Text.ToString)
        myCommand.Parameters.AddWithValue("?rol", cbrol.Text.ToString)
        myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
        myCommand.CommandText = "Update usuarios set nombres=?nombres,apellidos=?apellidos,rol=?rol,estado=?estado WHERE login=?login;"
        myCommand.ExecuteNonQuery()
        If cb_ct.Checked = True Then
            Dim pass As String
            pass = TestEncoding2()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?login", txtuser.Text.ToString)
            myCommand.Parameters.AddWithValue("?passw", pass)
            myCommand.CommandText = "Update usuarios set passw=?passw WHERE login=?login;"
            myCommand.ExecuteNonQuery()
        End If
        ModificarPermisos()
        MsgBox("El usuario fue modificado correctamente... ", MsgBoxStyle.Information, "Guardar Datos")
        Cerrar()
        DesActivar()
        Bloquear()
        lbestado.Text = "EDITADO"
    End Sub
    Public Sub ModificarPermisos()
        MiConexion("sae")
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?login", txtuser.Text.ToString)
        '****************  GENERALES ****************************************
        myCommand.Parameters.AddWithValue("?ter", cbter.Text.ToString)
        myCommand.Parameters.AddWithValue("?tip_doc", cbdoc.Text.ToString)
        myCommand.Parameters.AddWithValue("?imp", cbimp.Text.ToString)
        '''''''''''' CONTABILIDAD ''''''''''''''''''''''''''''''
        myCommand.Parameters.AddWithValue("?conta_basi", conta_bas.Text.ToString)
        myCommand.Parameters.AddWithValue("?conta_tran", conta_tran.Text.ToString)
        myCommand.Parameters.AddWithValue("?conta_info", conta_info.Text.ToString)
        myCommand.Parameters.AddWithValue("?conta_pros", conta_proc.Text.ToString)
        '''''''''''''INVENTARIOS'''''''''''''''''''''''''''''''
        myCommand.Parameters.AddWithValue("?inve_basi", inve_bas.Text.ToString)
        myCommand.Parameters.AddWithValue("?inve_tran", inve_tra.Text.ToString)
        myCommand.Parameters.AddWithValue("?inve_info", inve_inf.Text.ToString)
        myCommand.Parameters.AddWithValue("?inve_proc", inve_pro.Text.ToString)
        '''''''''''''FACTURACION'''''''''''''''''''''''''''''''
        myCommand.Parameters.AddWithValue("?fact_basi", fact_bas.Text.ToString)
        myCommand.Parameters.AddWithValue("?fact_tran", fact_tra.Text.ToString)
        myCommand.Parameters.AddWithValue("?fact_info", fact_inf.Text.ToString)
        myCommand.Parameters.AddWithValue("?fact_proc", fact_pro.Text.ToString)
        '''''''''''''CARTERA'''''''''''''''''''''''''''''''
        myCommand.Parameters.AddWithValue("?cart_basi", cart_bas.Text.ToString)
        myCommand.Parameters.AddWithValue("?cart_tran", cart_tra.Text.ToString)
        myCommand.Parameters.AddWithValue("?cart_info", cart_inf.Text.ToString)
        myCommand.Parameters.AddWithValue("?cart_proc", cart_pro.Text.ToString)
        '''''''''''''PROVEEDORES'''''''''''''''''''''''''''''''
        myCommand.Parameters.AddWithValue("?prov_basi", prov_bas.Text.ToString)
        myCommand.Parameters.AddWithValue("?prov_tran", prov_tra.Text.ToString)
        myCommand.Parameters.AddWithValue("?prov_info", prov_inf.Text.ToString)
        myCommand.Parameters.AddWithValue("?prov_proc", prov_pro.Text.ToString)
        '************************************************************
        myCommand.CommandText = "Update usuarios set ter=?ter,tip_doc=?tip_doc,imp=?imp,conta_basi=?conta_basi,conta_tran=?conta_tran,conta_info=?conta_info,conta_pros=?conta_pros " _
        & ",inve_basi=?inve_basi,inve_tran=?inve_tran,inve_info=?inve_info,inve_proc=?inve_proc " _
        & ",fact_basi=?fact_basi,fact_tran=?fact_tran,fact_info=?fact_info,fact_proc=?fact_proc " _
        & ",cart_basi=?cart_basi,cart_tran=?cart_tran,cart_info=?cart_info,cart_proc=?cart_proc " _
        & ",prov_basi=?prov_basi,prov_tran=?prov_tran,prov_info=?prov_info,prov_proc=?prov_proc " _
        & " WHERE login=?login;"
        myCommand.ExecuteNonQuery()
        Cerrar()
        DesActivar()
        Bloquear()
        lbestado.Text = "EDITADO"
    End Sub

    '*********** BOTONES DE DESPLAZAMIENTO *************************
    Public Sub BuscarPermiso()
        PonerenCero()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM usuarios WHERE login='" & txtuser.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                cbter.Text = tabla.Rows(0).Item("ter")
                cbdoc.Text = tabla.Rows(0).Item("tip_doc")
                cbimp.Text = tabla.Rows(0).Item("imp")
                '*********************
                conta_bas.Text = tabla.Rows(0).Item("conta_basi")
                conta_tran.Text = tabla.Rows(0).Item("conta_tran")
                conta_info.Text = tabla.Rows(0).Item("conta_info")
                conta_proc.Text = tabla.Rows(0).Item("conta_pros")
                '*********************
                inve_bas.Text = tabla.Rows(0).Item("inve_basi")
                inve_tra.Text = tabla.Rows(0).Item("inve_tran")
                inve_inf.Text = tabla.Rows(0).Item("inve_info")
                inve_pro.Text = tabla.Rows(0).Item("inve_proc")
                '*********************
                fact_bas.Text = tabla.Rows(0).Item("fact_basi")
                fact_tra.Text = tabla.Rows(0).Item("fact_tran")
                fact_inf.Text = tabla.Rows(0).Item("fact_info")
                fact_pro.Text = tabla.Rows(0).Item("fact_proc")
                '*********************
                cart_bas.Text = tabla.Rows(0).Item("cart_basi")
                cart_tra.Text = tabla.Rows(0).Item("cart_tran")
                cart_inf.Text = tabla.Rows(0).Item("cart_info")
                cart_pro.Text = tabla.Rows(0).Item("cart_proc")
                '*********************
                prov_bas.Text = tabla.Rows(0).Item("prov_basi")
                prov_tra.Text = tabla.Rows(0).Item("prov_tran")
                prov_inf.Text = tabla.Rows(0).Item("prov_info")
                prov_pro.Text = tabla.Rows(0).Item("prov_proc")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM usuarios ORDER BY rol,apellidos,nombres LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtnombres.Text = ""
                txtapellidos.Text = ""
                txtuser.Text = ""
                cbrol.Text = ""
                cbestado.Text = ""
                txtpass.Text = ""
                txtpass2.Text = ""
                lbnroobs.Text = 0
                lbestado.Text = "NULO"
                DesActivar()
                CmdNuevo.Focus()
            Else
                Refresh()
                txtnombres.Text = tabla.Rows(0).Item("nombres")
                txtapellidos.Text = tabla.Rows(0).Item("apellidos")
                txtuser.Text = tabla.Rows(0).Item("login")
                cbrol.Text = tabla.Rows(0).Item("rol")
                cbestado.Text = tabla.Rows(0).Item("estado")
                txtpass.Text = ""
                txtpass2.Text = ""
                lbnroobs.Text = 1
                BuscarPermiso()
                lbestado.Text = "CONSULTA"
                DesActivar()
                Bloquear()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM usuarios ORDER BY rol,apellidos,nombres  LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtnombres.Text = tabla.Rows(0).Item("nombres")
                txtapellidos.Text = tabla.Rows(0).Item("apellidos")
                txtuser.Text = tabla.Rows(0).Item("login")
                cbrol.Text = tabla.Rows(0).Item("rol")
                cbestado.Text = tabla.Rows(0).Item("estado")
                txtpass.Text = ""
                txtpass2.Text = ""
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
                BuscarPermiso()
                DesActivar()
                Bloquear()
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM usuarios"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM usuarios ORDER BY rol,apellidos,nombres LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtnombres.Text = tabla.Rows(0).Item("nombres")
                txtapellidos.Text = tabla.Rows(0).Item("apellidos")
                txtuser.Text = tabla.Rows(0).Item("login")
                cbrol.Text = tabla.Rows(0).Item("rol")
                cbestado.Text = tabla.Rows(0).Item("estado")
                txtpass.Text = ""
                txtpass2.Text = ""
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
                BuscarPermiso()
                DesActivar()
                Bloquear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM usuarios"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT * FROM usuarios ORDER BY rol,apellidos,nombres LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtnombres.Text = tabla.Rows(0).Item("nombres")
            txtapellidos.Text = tabla.Rows(0).Item("apellidos")
            txtuser.Text = tabla.Rows(0).Item("login")
            cbrol.Text = tabla.Rows(0).Item("rol")
            cbestado.Text = tabla.Rows(0).Item("estado")
            txtpass.Text = ""
            txtpass2.Text = ""
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
            BuscarPermiso()
            DesActivar()
            Bloquear()
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    '****** FORMULARIO *********************
    Private Sub FrmUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub cbrol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbrol.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub cbestado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbestado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombres.KeyPress
        validarletra(txtnombres, e)
    End Sub
    Private Sub txtapellidos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtapellidos.KeyPress
        validarletra(txtapellidos, e)
    End Sub
    Private Sub txtuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuser.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpass2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtuser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuser.LostFocus
        If txtuser.Text = "" Or lbestado.Text <> "NUEVO" Then
            lbuser.Visible = False
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM usuarios WHERE login='" & Trim(txtuser.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            lbuser.Text = "Usuario Disponible"
            lbuser.ForeColor = Color.Green
            lbuser.Visible = True
        Else
            lbuser.Text = "Usuario NO Disponible"
            lbuser.ForeColor = Color.Red
            lbuser.Visible = True
        End If
    End Sub

    Private Sub GroupBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox5.Enter

    End Sub
End Class