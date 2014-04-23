Public Class FrmServicios
    Private Sub FrmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    '**********************************
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        PonerEnCero()
        lbestado.Text = "NUEVO"
        txtser.Focus()
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
            txtservicio.Focus()
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                limpiarAu()
                llenarAu()
            End If
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
                    sql = sql & " select codart from detafac" & p & " where tipo_it='S' and codart= '" & txtser.Text & "' UNION "
                Else
                    sql = sql & " select codart from detafac" & p & " where tipo_it='S' and codart= '" & txtser.Text & "'  "
                End If
            Next
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)

            If tb.Rows.Count <> 0 Then
                MsgBox(" El Servicio no se puede eliminar porque ya ha tenido movimientos", MsgBoxStyle.Information, "Informacion")
            Else
                Dim resultado As MsgBoxResult
                resultado = MsgBox("El servicio " & txtservicio.Text & " se va ha eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    myCommand.CommandText = "DELETE FROM servicios WHERE codser= '" & txtser.Text & "'"
                    myCommand.ExecuteNonQuery()
                    MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                    myCommand.Parameters.Clear()
                    Refresh()
                    CmdPrimero_Click(AcceptButton, AcceptButton)
                End If
            End If

            Cerrar()
           
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelServicio.lbform.Text = "servicios"
        FrmSelServicio.ShowDialog()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Public Sub PonerEnCero()
        txtser.Text = ""
        txtservicio.Text = ""
        txtdescrip.Text = ""
        txtprecio.Text = "0,00"
        '  txtctaiva.Text = ""
        ' txtctaing.Text = ""
        txtning.Text = ""
        txtniva.Text = ""
        lbestado.Text = "NULO"
        lbnumero.Text = ""
    End Sub
    Public Sub Guardar()
        If txtser.Text = "" Then
            MsgBox("Verifique el codigo del servicio no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtser.Focus()
            Exit Sub
        ElseIf txtservicio.Text = "" Then
            MsgBox("Verifique el nombre del servicio no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtservicio.Focus()
            Exit Sub
        Else
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT count(*) FROM servicios WHERE codser='" & txtser.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item(0) > 0 Then
                    MsgBox("Verifique el codigo del servicio ya existe en los registros.", MsgBoxStyle.Information, "SAE, Verificación")
                    txtser.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "SAE, Verificación")
                txtser.Focus()
            End Try
        End If
        Try
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codser", txtser.Text.ToString)
            myCommand.Parameters.AddWithValue("?nombre", txtservicio.Text.ToString)
            myCommand.Parameters.AddWithValue("?descrip", txtdescrip.Text.ToString)
            Try
                myCommand.Parameters.AddWithValue("?pventa", DIN(txtprecio.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?pventa", "0")
            End Try
            myCommand.Parameters.AddWithValue("?pventa2", "0")
            myCommand.Parameters.AddWithValue("?pventa3", "0")
            myCommand.Parameters.AddWithValue("?pventa4", "0")
            myCommand.Parameters.AddWithValue("?pventa5", "0")
            myCommand.Parameters.AddWithValue("?pventa6", "0")
            Try
                myCommand.Parameters.AddWithValue("?iva", CDec(txtiva.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?iva", "0")
            End Try
            If txtning.Text = "" Then
                myCommand.Parameters.AddWithValue("?ctaing", "")
            Else
                myCommand.Parameters.AddWithValue("?ctaing", txtctaing.Text.ToString)
            End If
            If txtniva.Text = "" Then
                myCommand.Parameters.AddWithValue("?ctaiva", "")
            Else
                myCommand.Parameters.AddWithValue("?ctaiva", txtctaiva.Text.ToString)
            End If
            myCommand.CommandText = "INSERT INTO servicios " _
                                  & " VALUES(?codser,?nombre,?descrip,?pventa,?pventa2,?pventa3,?pventa4,?pventa5,?pventa6,?iva,?ctaing,?ctaiva);"
            myCommand.ExecuteNonQuery()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "GUARDAR SERVICIO COD: " & txtser.Text & " - " & txtservicio.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbestado.Text = "GUARDADO"
        Catch ex As Exception
            Cerrar()
        End Try

    End Sub
    Public Sub Modificar()
        If txtservicio.Text = "" Then
            MsgBox("Verifique el nombre del servicio no puede ser en blanco.", MsgBoxStyle.Information, "SAE, Verificación")
            txtservicio.Focus()
            Exit Sub
        End If
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del servicio se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?nombre", txtservicio.Text.ToString)
                myCommand.Parameters.AddWithValue("?descrip", txtdescrip.Text.ToString)
                Try
                    myCommand.Parameters.AddWithValue("?pventa", DIN(txtprecio.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?pventa", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?iva", CDec(txtiva.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?iva", "0")
                End Try
                If txtning.Text = "" Then
                    myCommand.Parameters.AddWithValue("?ctaing", "")
                Else
                    myCommand.Parameters.AddWithValue("?ctaing", txtctaing.Text.ToString)
                End If
                If txtniva.Text = "" Then
                    myCommand.Parameters.AddWithValue("?ctaiva", "")
                Else
                    myCommand.Parameters.AddWithValue("?ctaiva", txtctaiva.Text.ToString)
                End If
                myCommand.CommandText = "Update servicios set nombre=?nombre,descrip=?descrip,pventa=?pventa,iva=?iva,cta_ing=?ctaing,cta_iva=?ctaiva WHERE codser='" & txtser.Text & "';"
                myCommand.ExecuteNonQuery()
              
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Auditardat()
                End If
                '.....
                Cerrar()
                lbestado.Text = "EDITADO"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '**********************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codser FROM servicios LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerEnCero()
                Exit Sub
            End If
            BuscarSer(tabla.Rows(0).Item("codser"))
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
            myCommand.CommandText = "SELECT codser FROM servicios LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            BuscarSer(tabla.Rows(0).Item("codser"))
            lbestado.Text = "CONSULTA"
            CmdAtras.Focus()
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM servicios"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT codser FROM servicios LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarSer(tabla.Rows(0).Item("codser"))
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
            CmdSiguiente.Focus()
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM servicios;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay servicios en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT codser FROM servicios LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        BuscarSer(tabla.Rows(0).Item("codser"))
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
        CmdUltimo.Focus()
    End Sub
    Public Sub BuscarSer(ByVal codser As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM servicios WHERE codser='" & codser & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        txtser.Text = tabla.Rows(0).Item("codser")
        txtservicio.Text = tabla.Rows(0).Item("nombre")
        txtdescrip.Text = tabla.Rows(0).Item("descrip")
        txtprecio.Text = Moneda(tabla.Rows(0).Item("pventa"))
        txtiva.Text = tabla.Rows(0).Item("iva")
        txtiva_LostFocus(AcceptButton, AcceptButton)
        txtctaiva.Text = tabla.Rows(0).Item("cta_iva")
        txtctaing.Text = tabla.Rows(0).Item("cta_ing")
        If txtctaiva.Text = "" Then
            txtniva.Text = ""
        Else
            BuscarCuenta(txtctaiva.Text, "iva")
        End If
        If txtctaing.Text = "" Then
            txtning.Text = ""
        Else
            BuscarCuenta(txtctaing.Text, "ing")
        End If
    End Sub
    '***********************************
    'cajas de texto
    Private Sub txtser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtser.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtservicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtservicio.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtservicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtservicio.LostFocus
        If txtdescrip.Text = "" Then
            txtdescrip.Text = txtservicio.Text
        End If
    End Sub
    Private Sub txtdescrip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescrip.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        End If
    End Sub
    'precio 
    Private Sub txtprecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        Else
            ValidarMoneda(txtprecio, e)
        End If
    End Sub
    Private Sub txtprecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprecio.LostFocus
        txtprecio.Text = Moneda(txtprecio.Text)
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
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
                SendKeys.Send("{TAB}")
            Else
                BuscarCuenta(txtctaiva.Text, "iva")
            End If
        ElseIf lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
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
    Private Sub txtctaing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctaing.KeyPress

        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            e.Handled = True
        Else
            validarnumero(txtctaing, e)
        End If
    End Sub
    Private Sub txtctaing_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaing.LostFocus
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            BuscarCuenta(txtctaing.Text, "ing")
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
                    Case "ing"
                        FrmCuentas.lbform.Text = "ser_ing"
                        txtning.Text = ""
                    Case "iva"
                        FrmCuentas.lbform.Text = "ser_iva"
                        txtniva.Text = ""
                End Select
                FrmCuentas.txtcuenta.Text = codigo
                FrmCuentas.lbaux.Text = "auxiliar"
                FrmCuentas.ShowDialog()
            Else
                Select Case cta
                    Case "ing"
                        txtning.Text = tabla.Rows(0).Item("descripcion")
                    Case "iva"
                        txtniva.Text = tabla.Rows(0).Item("descripcion")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cdmlista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmlista.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "NULO" Then
            FrmPreciosServicios.lbcodigo.Text = txtser.Text
            FrmPreciosServicios.lbdescricion.Text = txtservicio.Text
            If lbestado.Text = "EDITAR" Then
                FrmPreciosServicios.gitems.Columns(2).ReadOnly = False
                FrmPreciosServicios.CmdRegistrarCambios.Enabled = True
            Else
                FrmPreciosServicios.gitems.Columns(2).ReadOnly = True
                FrmPreciosServicios.CmdRegistrarCambios.Enabled = False
            End If
            FrmPreciosServicios.ShowDialog()
        Else
            MsgBox("Primero cree el servicio y luego modifique los precios de la lista.  ", MsgBoxStyle.Information, "SAE Control")
        End If
    End Sub
    Private Sub limpiarAu()
        txtservicio1.Text = ""
        txtdescrip1.Text = ""
        txtprecio1.Text = ""
        txtiva1.Text = ""
        txtctaiva1.Text = ""
        txtctaing1.Text = ""
    End Sub
    Private Sub llenarAu()
        txtservicio1.Text = txtservicio.Text
        txtdescrip1.Text = txtdescrip.Text
        txtprecio1.Text = txtprecio.Text
        txtiva1.Text = txtiva.Text
        txtctaiva1.Text = txtctaiva.Text
        txtctaing1.Text = txtctaing.Text
    End Sub
    Private Sub Auditardat()
        Try
            Dim camp As String = ""
            Dim ant As String = ""
            Dim nue As String = ""

            If txtservicio.Text <> txtservicio1.Text Then
                camp = camp & "NOMBRE; "
                ant = ant & txtservicio1.Text & "; "
                nue = nue & txtservicio.Text & "; "
            End If
            If txtdescrip.Text <> txtdescrip1.Text Then
                camp = camp & "DESCRIPCION; "
                ant = ant & txtdescrip1.Text & "; "
                nue = nue & txtdescrip.Text & "; "
            End If
            If txtprecio.Text <> txtprecio1.Text Then
                camp = camp & "PRECIO; "
                ant = ant & txtprecio1.Text & "; "
                nue = nue & txtprecio.Text & "; "
            End If
            If txtiva.Text <> txtiva1.Text Then
                camp = camp & "IVA; "
                ant = ant & txtiva1.Text & "; "
                nue = nue & txtiva.Text & "; "
            End If
            If txtctaiva.Text <> txtctaiva1.Text Then
                camp = camp & "CTAIVA; "
                ant = ant & txtctaiva1.Text & "; "
                nue = nue & txtctaiva.Text & "; "
            End If
            If txtctaing.Text <> txtctaing1.Text Then
                camp = camp & "CTAINGRESO; "
                ant = ant & txtctaing1.Text & "; "
                nue = nue & txtctaing.Text & "; "
            End If

            Guar_MovUser("FACTURACION", "MODIFICAR SERVICIO COD: " & txtser.Text & " - " & txtservicio.Text, camp, ant, nue)

        Catch ex As Exception
        End Try

    End Sub
End Class