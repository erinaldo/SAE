Public Class FrmImpuestos
    Private Sub FrmImpuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    '********************** OPERACIONES ************************************************************
    Public Sub PonerEnCero()
        lbcodigo.Text = "0"
        TxtCodGral.Text = ""
        txtDescriGral.Text = ""
        '*******************************
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtPorcentaje.Text = "0,00"
        txtCuenta.Text = ""
        cbTipoAsi.Text = "D"
    End Sub
    Public Sub Bloquear()
        TxtCodGral.Enabled = False
        txtDescriGral.Enabled = False
        '*******************************
        txtCodigo.Enabled = False
        txtDescripcion.Enabled = False
        txtPorcentaje.Enabled = False
        txtCuenta.Enabled = False
        cbTipoAsi.Enabled = False
    End Sub
    Public Sub DesBloquear()
        TxtCodGral.Enabled = True
        txtDescriGral.Enabled = False
        '*******************************
        txtCodigo.Enabled = True
        txtDescripcion.Enabled = True
        txtPorcentaje.Enabled = True
        txtCuenta.Enabled = True
        cbTipoAsi.Enabled = True
    End Sub
    '***************** BOTONES DE COMANDO ********************************************************************
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If per_imp <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        PonerEnCero()
        DesBloquear()
        lbestado.Text = "NUEVO"
        TxtCodGral.Focus()
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarGuardar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
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
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If per_imp <> "E" Then
                    MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
                    Exit Sub
                End If
                DesBloquear()
                lbestado.Text = "EDITAR"
                txtDescriGral.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If per_imp <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El impuesto " & txtDescripcion.Text & " se va a eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM impuestos WHERE  cod_concep='" & TxtCodGral.Text & "' AND codigo='" & txtCodigo.Text & "' "
            myCommand.ExecuteNonQuery()
            Cerrar()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
        
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelImpuestos.lbform.Text = "impuestos"
            FrmSelImpuestos.ShowDialog()
            If lbestado.Text = "CONSULTA" Then
                BuscarDoc(lbcodigo.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '***************** DESPLAZAMIENTO *****************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT id_imp FROM impuestos ORDER BY cod_concep,codigo LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                Bloquear()
                lbestado.Text = "NULO"
            Else
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("id_imp")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            Bloquear()
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT id_imp FROM impuestos ORDER BY cod_concep,codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("id_imp")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM impuestos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT id_imp FROM impuestos ORDER BY cod_concep,codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("id_imp")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM impuestos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT id_imp FROM impuestos ORDER BY cod_concep,codigo LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            TxtCodGral.Text = tabla.Rows(0).Item("id_imp")
            BuscarDoc(TxtCodGral.Text)
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDoc(ByVal codigo As String)
        Try
            Bloquear()
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM impuestos WHERE id_imp='" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                lbcodigo.Text = tabla.Rows(0).Item("id_imp")
                TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
                BuscarCon(tabla.Rows(0).Item("cod_concep"))
                txtCodigo.Text = tabla.Rows(0).Item("codigo")
                txtDescripcion.Text = tabla.Rows(0).Item("descrip")
                txtPorcentaje.Text = Moneda(tabla.Rows(0).Item("porce"))
                txtCuenta.Text = tabla.Rows(0).Item("cuenta")
                cbTipoAsi.Text = tabla.Rows(0).Item("tip_asi")
                lbestado.Text = "CONSULTA"
            Else
                PonerEnCero()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarCon(ByVal codigo As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM con_gral_imp WHERE cod_concep='" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtDescriGral.Text = tabla.Rows(0).Item("decrip_gral")
            Else
                txtDescriGral.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    '************ VALIDACIONES *************************************************
    Private Sub TxtCodGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodGral.KeyPress
        validarnumero(TxtCodGral, e)
    End Sub
    Private Sub TxtCodGral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodGral.LostFocus
        Try
            If Val(TxtCodGral.Text) < 10 Then
                TxtCodGral.Text = "0" & Val(TxtCodGral.Text)
            Else
                TxtCodGral.Text = Val(TxtCodGral.Text)
            End If
        Catch ex As Exception
            TxtCodGral.Text = "00"
        End Try
        BuscarConcepto()
    End Sub
    Public Sub BuscarConcepto()
        BuscarCon(TxtCodGral.Text)
        If txtDescriGral.Text = "" Then
            Try
                FrmSelConcepImp.lbform.Text = "impuestos"
                If TxtCodGral.Text <> "00" Then FrmSelConcepImp.txtcuenta.Text = TxtCodGral.Text
                FrmSelConcepImp.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        validarnumero(txtCodigo, e)
    End Sub
    Private Sub txtCodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.LostFocus
        Try
            If Val(txtCodigo.Text) < 10 Then
                txtCodigo.Text = "0" & Val(txtCodigo.Text)
            Else
                txtCodigo.Text = Val(txtCodigo.Text)
            End If
        Catch ex As Exception
            txtCodigo.Text = "00"
        End Try
    End Sub
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        ValidarPorcentaje(txtPorcentaje, e)
    End Sub
    Private Sub txtPorcentaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentaje.LostFocus
        txtPorcentaje.Text = Moneda(txtPorcentaje.Text)
    End Sub
    Private Sub txtCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuenta.KeyPress
        validarnumero(txtCuenta, e)
    End Sub
    Private Sub txtCuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuenta.LostFocus
        BuscarCuenta()
    End Sub
    Public Sub BuscarCuenta()
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT codigo FROM selpuc WHERE codigo='" & Trim(txtCuenta.Text) & "' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtCuenta.Text = tabla.Rows(0).Item("codigo")
        Else
            Try
                FrmCuentas.lbform.Text = "impuestos"
                FrmCuentas.txtcuenta.Text = txtCuenta.Text
                FrmCuentas.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub cbTipoAsi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipoAsi.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '****************** VALIDAR, GUARDAR Y MODIFICAR ********************************************
    Public Sub ValidarGuardar()
        If TxtCodGral.Text = "" Or TxtCodGral.Text = "00" Then
            MsgBox("Por favor digite el código del concepto, Verifique", MsgBoxStyle.Information, "Verificando")
            TxtCodGral.Focus()
            Exit Sub
        ElseIf txtCodigo.Text = "" Or txtCodigo.Text = "00" Then
            MsgBox("Por favor digite el código del impuesto, Verifique", MsgBoxStyle.Information, "Verificando")
            txtCodigo.Focus()
            Exit Sub
        ElseIf Trim(txtDescripcion.Text) = "" Then
            MsgBox("Por favor digite la descripción del impuesto, Verifique", MsgBoxStyle.Information, "Verificando")
            txtDescripcion.Focus()
            Exit Sub
        ElseIf Trim(txtCuenta.Text) = "" Then
            MsgBox("Por favor digite la cuenta del impuesto, Verifique", MsgBoxStyle.Information, "Verificando")
            txtCuenta.Focus()
            Exit Sub
        End If
        MiConexion(bda)
        Try
            If lbestado.Text = "NUEVO" Then
                Dim items As Integer
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * from impuestos WHERE cod_concep='" & TxtCodGral.ToString & "' AND codigo='" & txtCodigo.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items <> 0 Then
                    MsgBox("ya existe un impuesto con ese codigo asociado al concepto, Verifique", MsgBoxStyle.Information, "Verificando")
                Else
                    Guardar()
                End If
            Else
                Modificar()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub Guardar()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT MAX(id_imp) FROM impuestos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcodigo.Text = Val(tabla.Rows(0).Item(0).ToString) + 1
        Catch ex As Exception
            lbcodigo.Text = "1"
        End Try
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?id_imp", Val(lbcodigo.Text.ToString))
        myCommand.Parameters.AddWithValue("?cod_concep", TxtCodGral.Text.ToString)
        myCommand.Parameters.AddWithValue("?codigo", txtCodigo.Text.ToString)
        myCommand.Parameters.AddWithValue("?descrip", txtDescripcion.Text.ToString)
        myCommand.Parameters.AddWithValue("?porce", DIN(txtPorcentaje.Text))
        myCommand.Parameters.AddWithValue("?cuenta", txtCuenta.Text.ToString)
        myCommand.Parameters.AddWithValue("?tip_asi", cbTipoAsi.Text.ToString)
        myCommand.CommandText = "INSERT INTO impuestos  " _
                              & " Values(?id_imp,?cod_concep,?codigo,?descrip,?porce,?cuenta,?tip_asi);"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "GUARDADO"
        Bloquear()
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del impuesto se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod_concep", TxtCodGral.Text.ToString)
            myCommand.Parameters.AddWithValue("?codigo", txtCodigo.Text.ToString)
            myCommand.Parameters.AddWithValue("?descrip", txtDescripcion.Text.ToString)
            myCommand.Parameters.AddWithValue("?porce", DIN(txtPorcentaje.Text))
            myCommand.Parameters.AddWithValue("?cuenta", txtCuenta.Text.ToString)
            myCommand.Parameters.AddWithValue("?tip_asi", cbTipoAsi.Text.ToString)
            myCommand.CommandText = "UPDATE impuestos  SET " _
                                  & "cod_concep=?cod_concep,codigo=?codigo,descrip=?descrip,porce=?porce,cuenta=?cuenta,tip_asi=?tip_asi WHERE id_imp='" & Val(lbcodigo.Text) & "';"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            lbestado.Text = "EDITADO"
            Bloquear()
        End If
    End Sub
End Class