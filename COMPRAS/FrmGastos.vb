Public Class FrmGastos

    Private Sub FrmGastos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = "NULO"
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    '**********************************
    Public Sub Bloquear()
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        '***************************
        txtcod.Enabled = False
        txtnombre.Enabled = False
        txtdescrip.Enabled = False
        txtiva.Enabled = False
        txtctaiva.Enabled = False
        txtctagas.Enabled = False
    End Sub
    Public Sub DesBloquear()
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        '***************************
        txtnombre.Enabled = True
        txtdescrip.Enabled = True
        txtiva.Enabled = True
        txtctaiva.Enabled = True
        txtctagas.Enabled = True
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        PonerEnCero()
        DesBloquear()
        txtcod.Enabled = True
        lbestado.Text = "NUEVO"
        txtcod.Focus()
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
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            lbestado.Text = "EDITAR"
            DesBloquear()
            txtnombre.Focus()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text = "CONSULTA" Then
            MiConexion(bda)

            Dim sql As String = ""
            Dim p As String = ""
            Dim tb As New DataTable

            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p <> 12 Then
                    sql = sql & " select cod_art from detacomp" & p & " where tipo_it='G' and cod_art= '" & txtcod.Text & "' UNION "
                Else
                    sql = sql & " select cod_art from detacomp" & p & " where tipo_it='G' and cod_art= '" & txtcod.Text & "'  "
                End If
            Next
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)

            If tb.Rows.Count = 0 Then
                myCommand.CommandText = "DELETE FROM gastos WHERE cod_gas= '" & txtcod.Text & "'"
                myCommand.ExecuteNonQuery()
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
            Else
                MsgBox(" El Gasto no se puede eliminar porque ya ha tenido movimientos", MsgBoxStyle.Information, "Informacion")
            End If

            Cerrar()
            '   lbestado.Text = "GUARDADO"
            ' Bloquear()
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelMisGastos.lbform.Text = "gas"
        FrmSelMisGastos.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarSer(txtcod.Text)
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub PonerEnCero()
        txtcod.Text = ""
        txtnombre.Text = ""
        txtdescrip.Text = ""
        txtctaiva.Text = ""
        txtctagas.Text = ""
        txtiva.Text = "0,00"
        txtngas.Text = ""
        txtniva.Text = ""
        lbestado.Text = "NULO"
        lbnumero.Text = ""
    End Sub
    Public Sub Guardar()
        If txtcod.Text = "" Then
            MsgBox("Verifique el codigo del gasto no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtcod.Focus()
            Exit Sub
        ElseIf txtnombre.Text = "" Then
            MsgBox("Verifique el nombre del gasto no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtnombre.Focus()
            Exit Sub
        Else
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT count(*) FROM gastos WHERE cod_gas='" & txtcod.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item(0) > 0 Then
                    MsgBox("Verifique el codigo del gasto ya existe en los registros.", MsgBoxStyle.Information, "SAE, Verificación")
                    txtcod.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "SAE, Verificación")
                txtcod.Focus()
            End Try
        End If
        Try
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod_gas", CambiaCadena(txtcod.Text.ToString, 15))
            myCommand.Parameters.AddWithValue("?nom_gas", CambiaCadena(txtnombre.Text.ToString, 149))
            myCommand.Parameters.AddWithValue("?desc_gas", txtdescrip.Text.ToString)
            Try
                myCommand.Parameters.AddWithValue("?por_iva", DIN(txtiva.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?por_iva", "0")
            End Try
            If txtniva.Text = "" Then
                myCommand.Parameters.AddWithValue("?cta_iva", "")
            Else
                myCommand.Parameters.AddWithValue("?cta_iva", txtctaiva.Text.ToString)
            End If
            If txtngas.Text = "" Then
                myCommand.Parameters.AddWithValue("?cta_gas", "")
            Else
                myCommand.Parameters.AddWithValue("?cta_gas", txtctagas.Text.ToString)
            End If

            myCommand.CommandText = "INSERT INTO gastos " _
                                  & " VALUES(?cod_gas,?nom_gas,?desc_gas,?por_iva,?cta_iva,?cta_gas);"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("COMPRAS", "CREAR GASTO COD:" & txtcod.Text, "", "", "")
            End If
            '.....
            lbestado.Text = "GUARDADO"
            Bloquear()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Cerrar()
        End Try

    End Sub
    Public Sub Modificar()
        If txtnombre.Text = "" Then
            MsgBox("Verifique el nombre del gasto no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtnombre.Focus()
            Exit Sub
        End If
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del gasto se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                MiConexion(bda)
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?nom_gas", CambiaCadena(txtnombre.Text.ToString, 149))
                myCommand.Parameters.AddWithValue("?desc_gas", txtdescrip.Text.ToString)
                Try
                    myCommand.Parameters.AddWithValue("?por_iva", DIN(txtiva.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?por_iva", "0")
                End Try
                If txtniva.Text = "" Then
                    myCommand.Parameters.AddWithValue("?cta_iva", "")
                Else
                    myCommand.Parameters.AddWithValue("?cta_iva", txtctaiva.Text.ToString)
                End If
                If txtngas.Text = "" Then
                    myCommand.Parameters.AddWithValue("?cta_gas", "")
                Else
                    myCommand.Parameters.AddWithValue("?cta_gas", txtctagas.Text.ToString)
                End If
                myCommand.CommandText = "Update gastos set nom_gas=?nom_gas,desc_gas=?desc_gas,por_iva=?por_iva,cta_iva=?cta_iva,cta_gas=?cta_gas WHERE cod_gas='" & txtcod.Text & "';"
                myCommand.ExecuteNonQuery()
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                DBCon.Close()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("COMPRAS", "MODIFICAR GASTO COD:" & txtcod.Text, "", "", "")
                End If
                '.....
                lbestado.Text = "EDITADO"
                Bloquear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '**********************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cod_gas FROM gastos LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerEnCero()
                Exit Sub
            End If
            BuscarSer(tabla.Rows(0).Item("cod_gas"))
            lbnumero.Text = "1"
            lbestado.Text = "CONSULTA"
            CmdPrimero.Focus()
        Catch ex As Exception
            PonerEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cod_gas FROM gastos LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            BuscarSer(tabla.Rows(0).Item("cod_gas"))
            lbestado.Text = "CONSULTA"
            CmdAtras.Focus()
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM gastos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT cod_gas FROM gastos LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarSer(tabla.Rows(0).Item("cod_gas"))
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
            CmdSiguiente.Focus()
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM gastos;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay gastos en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT cod_gas FROM gastos LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        BuscarSer(tabla.Rows(0).Item("cod_gas"))
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
        CmdUltimo.Focus()
    End Sub
    Public Sub BuscarSer(ByVal codser As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM gastos WHERE cod_gas='" & codser & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        txtcod.Text = tabla.Rows(0).Item("cod_gas")
        txtnombre.Text = tabla.Rows(0).Item("nom_gas")
        txtdescrip.Text = tabla.Rows(0).Item("desc_gas")
        txtiva.Text = tabla.Rows(0).Item("por_iva")
        txtiva_LostFocus(AcceptButton, AcceptButton)
        txtctaiva.Text = tabla.Rows(0).Item("cta_iva")
        txtctagas.Text = tabla.Rows(0).Item("cta_gas")
        If txtctaiva.Text = "" Then
            txtniva.Text = ""
        Else
            BuscarCuenta(txtctaiva.Text, "iva")
        End If
        If txtctagas.Text = "" Then
            txtngas.Text = ""
        Else
            BuscarCuenta(txtctagas.Text, "gas")
        End If
        Bloquear()
    End Sub
    '***********************************
    'cajas de texto
    Private Sub txtser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtservicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtservicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre.LostFocus
        If txtdescrip.Text = "" Then
            txtdescrip.Text = txtnombre.Text
        End If
    End Sub
    Private Sub txtdescrip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescrip.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    'iva
    Private Sub txtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        Else
            ValidarPorcentaje(txtiva, e)
        End If
    End Sub
    Private Sub txtiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiva.LostFocus
        Try
            txtiva.Text = Format(CDbl(txtiva.Text), "0.00")
        Catch ex As Exception
            txtiva.Text = "0,00"
        End Try
    End Sub
    'cta iva
    Private Sub txtctaiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctaiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarCuenta(txtctagas.Text, "iva")
            txtctagas.Focus()
        Else
            validarnumero(txtctaiva, e)
        End If

    End Sub
    Private Sub txtctaiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaiva.LostFocus
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            BuscarCuenta(txtctaiva.Text, "iva")
        End If
    End Sub
    'cta ingreso
    Private Sub txtctaing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctagas.KeyPress
        validarnumero(txtctagas, e)
    End Sub
    Private Sub txtctaing_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctagas.LostFocus
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            BuscarCuenta(txtctagas.Text, "gas")
        End If
    End Sub
    Public Sub BuscarCuenta(ByVal codigo As String, ByVal cta As String)
        Try
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                Select Case cta
                    Case "gas"
                        FrmCuentas.lbform.Text = "gas_gas"
                        txtngas.Text = ""
                    Case "iva"
                        FrmCuentas.lbform.Text = "gas_iva"
                        txtniva.Text = ""
                End Select
                FrmCuentas.txtcuenta.Text = codigo
                FrmCuentas.lbaux.Text = "auxiliar"
                FrmCuentas.ShowDialog()
            Else
                Select Case cta
                    Case "gas"
                        txtngas.Text = tabla.Rows(0).Item("descripcion")
                    Case "iva"
                        txtniva.Text = tabla.Rows(0).Item("descripcion")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class