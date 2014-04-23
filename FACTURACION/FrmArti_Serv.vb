Public Class FrmArti_Serv
    Private Sub FrmArti_Serv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbestado.Text = ""
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmArti_Serv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = ""
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    '*//////////////*/////////////////////////////////////////
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub PonerCero()
        txtcod.Text = ""
        txtservicio.Text = ""
        txtdesc.Text = ""
        txtprecio.Text = ""
        txtservicio.Text = ""
        lbestado.Text = "NULO"
        lbnroobs.Text = "0"
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        PonerCero()
        lbestado.Text = "NUEVO"
        txtcod.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
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
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
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
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                lbestado.Text = "EDITAR"
                txtservicio.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click

    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim tabla As New DataTable
            Dim items As Integer
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM servicios;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("no hay servicios en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                Exit Sub
            End If
            FrmSelServicio.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelServicio.gitems.Item(1, i).Value = tabla.Rows(i).Item("codser")
                FrmSelServicio.gitems.Item(2, i).Value = tabla.Rows(i).Item("nombre")
            Next
            FrmSelServicio.lbform.Text = "servicio"
            FrmSelServicio.ShowDialog()
            If lbestado.Text = "CONSULTA" Then
                buscarSercicio(txtcod.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '//////////////////////////////////////////////////////////
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM servicios LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerCero()
            Else
                lbestado.Text = "CONSULTA"
                lbnroobs.Text = "1"
                buscarSercicio(tabla.Rows(0).Item("codser"))
            End If
        Catch ex As Exception
            PonerCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM servicios LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                lbestado.Text = "CONSULTA"
                lbnroobs.Text = i + 1
                buscarSercicio(tabla.Rows(0).Item("codser"))
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM servicios;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM servicios LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                lbestado.Text = "CONSULTA"
                lbnroobs.Text = i + 1
                buscarSercicio(tabla.Rows(0).Item("codser"))
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM servicios;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                CmdNuevo_Click(AcceptButton, AcceptButton)
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM servicios LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbestado.Text = "CONSULTA"
            lbnroobs.Text = i + 1
            buscarSercicio(tabla.Rows(0).Item("codser"))
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub buscarSercicio(ByVal codigo As String)
        Try
            Dim tabla As New DataTable
            Dim items As Integer
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM servicios WHERE codser = '" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("el servicio no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                Exit Sub
            End If
            txtcod.Text = tabla.Rows(0).Item("codser")
            txtservicio.Text = tabla.Rows(0).Item("nombre")
            txtdesc.Text = tabla.Rows(0).Item("descri")
            txtprecio.Text = Format(Math.Round(CDbl(tabla.Rows(0).Item("pventa")), 2), "0,00.00")
            txtcuenta.Text = tabla.Rows(0).Item("cuenta")
            txtiva.Text = tabla.Rows(0).Item("civa")
            cbtipo.Text = tabla.Rows(0).Item("tipo")
            If txtcuenta.Text <> "" Then
                BuscarCuenta(txtcuenta.Text)
            End If
            If txtiva.Text <> "" Then
                BuscarCuentaIva(txtiva.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '*****************************************
    Public Sub ValidarGuardar()
        If txtcod.Text = "" Then
            MsgBox("No ha digitado codigo del servicio, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcod.Focus()
            Exit Sub
        ElseIf txtservicio.Text = "" Then
            MsgBox("No ha digitado nombre del servicio, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtservicio.Focus()
            Exit Sub
        ElseIf cbtipo.Text = "" Then
            MsgBox("No ha digitado tipo del servicio, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cbtipo.Focus()
            Exit Sub
        ElseIf txtprecio.Text = "" Then
            MsgBox("No ha digitado precio del servicio, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtprecio.Focus()
            Exit Sub
        ElseIf txtnomcuenta.Text = "" Then
            MsgBox("No ha digitado cuenta contable del servicio, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuenta.Focus()
            Exit Sub
        ElseIf txtnomiva.Text = "" Then
            MsgBox("No ha digitado cuenta contable del iva, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtiva.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        End If
    End Sub
    Public Sub Guardar()
        If txtcod.Text <> "" Then
            Dim tser As New DataTable
            tser.Clear()
            myCommand.CommandText = "SELECT * FROM servicios WHERE codser = '" & txtcod.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tser)
            Refresh()
            If tser.Rows.Count > 0 Then
                MsgBox("El codigo del servicio ya se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
                txtcod.Focus()
                Exit Sub
            End If
        End If
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codser", txtcod.Text.ToString)
        myCommand.Parameters.AddWithValue("?nombre", txtservicio.Text.ToString)
        myCommand.Parameters.AddWithValue("?descri", txtdesc.Text.ToString)
        myCommand.Parameters.AddWithValue("?pventa", CDbl(txtprecio.Text.ToString))
        myCommand.Parameters.AddWithValue("?cuenta", txtcuenta.Text.ToString)
        myCommand.Parameters.AddWithValue("?civa", txtiva.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
        myCommand.CommandText = "INSERT INTO servicios (codser,nombre,descri,pventa,cuenta,civa,tipo) " _
                                         & " Values(?codser,?nombre,?descri,?pventa,?cuenta,?civa,?tipo);"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        Cerrar()
        lbnroobs.Text = "0"
        lbestado.Text = "GUARDADO"
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del servicio se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codser", txtcod.Text.ToString)
            myCommand.Parameters.AddWithValue("?nombre", txtservicio.Text.ToString)
            myCommand.Parameters.AddWithValue("?descri", txtdesc.Text.ToString)
            myCommand.Parameters.AddWithValue("?pventa", CDbl(txtprecio.Text.ToString))
            myCommand.Parameters.AddWithValue("?cuenta", txtcuenta.Text.ToString)
            myCommand.Parameters.AddWithValue("?civa", txtiva.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
            myCommand.CommandText = "Update servicios set nombre=?nombre, descri=?descri, pventa=?pventa,cuenta=?cuenta,civa=?civa,tipo=?tipo WHERE codser=?codser;"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbestado.Text = "EDITADO"
        End If
    End Sub
    '//////******************************/////////////////////////
    Private Sub txtcod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Then
            ' validarnumero(txtnitc, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtservicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtservicio.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then

        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then

        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtprecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtprecio, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtcuenta, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub cbtipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbtipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtprecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprecio.LostFocus
        Try
            txtprecio.Text = Format(Math.Round(CDbl(txtprecio.Text), 2), "0,00.00")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            BuscarCuenta(txtcuenta.Text)
        End If
    End Sub
    Public Sub BuscarCuenta(ByVal cuenta As String)
        If cuenta = "" Then
            txtnomcuenta.Text = ""
            FrmCuentas.lbform.Text = "servicios"
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                txtnomcuenta.Text = ""
                FrmCuentas.lbform.Text = "servicios"
                FrmCuentas.ShowDialog()
            Else
                txtnomcuenta.Text = tabla.Rows(0).Item("descripcion")
            End If
        End If
    End Sub

    Private Sub txtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtiva, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiva.LostFocus
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            BuscarCuentaIva(txtiva.Text)
        End If
    End Sub
    Public Sub BuscarCuentaIva(ByVal cuenta As String)
        If cuenta = "" Then
            txtnomiva.Text = ""
            FrmCuentas.lbform.Text = "serviciosIVA"
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                txtnomiva.Text = ""
                FrmCuentas.lbform.Text = "serviciosIVA"
                FrmCuentas.ShowDialog()
            Else
                txtnomiva.Text = tabla.Rows(0).Item("descripcion")
            End If
        End If
    End Sub
End Class