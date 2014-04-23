Public Class FrmGestionBancos
    Private Sub FrmGestionBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            grilla.RowCount = 12
            lbestado.Text = "NULO"
            Meses()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Meses()
        Try
            grilla.RowCount = 12
            Dim ano As String
            BuscarPeriodo()
            ano = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            grilla.Item(0, 0).Value = "ENERO / " & ano
            grilla.Item(0, 1).Value = "FEBRERO / " & ano
            grilla.Item(0, 2).Value = "MARZO / " & ano
            grilla.Item(0, 3).Value = "ABRIL / " & ano
            grilla.Item(0, 4).Value = "MAYO / " & ano
            grilla.Item(0, 5).Value = "JUNIO / " & ano
            grilla.Item(0, 6).Value = "JULIO / " & ano
            grilla.Item(0, 7).Value = "AGOSTO / " & ano
            grilla.Item(0, 8).Value = "SEPTIEMBRE / " & ano
            grilla.Item(0, 9).Value = "OCTUBRE / " & ano
            grilla.Item(0, 10).Value = "NOVIEMBRE / " & ano
            grilla.Item(0, 11).Value = "DICIEMBRE / " & ano
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PonerEnCero()
        Try
            For i = 0 To 11
                grilla.Item(1, i).Value = "0,00"
                grilla.Item(2, i).Value = ""
                grilla.Item(3, i).Value = "0,00"
                grilla.Item(4, i).Value = "0,00"
                grilla.Item(5, i).Value = "0,00"
                grilla.Item(6, i).Value = ""
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Sub VaciarCampos()
        txtcuenta.Text = ""
        txtcodigo.Text = ""
        txtnit.Text = ""
        txtbanco.Text = ""
        txtnum.Text = ""
        txtnombre.Text = ""
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        PonerEnCero()
        DesBloquear()
        VaciarCampos()
        lbestado.Text = "NUEVO"
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
        Bloquear()
        VaciarCampos()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                DesBloquear()
                lbestado.Text = "EDITAR"
                txtcodigo.Enabled = False
                txtcuenta.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM bancos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If (tabla.Rows.Count = 0) Then
                MsgBox("No hay bancos o corporaciones creadas.  ", MsgBoxStyle.Information)
            Else
                FrmSelBanco.lbform.Text = "gbanco"
                FrmSelBanco.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '*****************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cod_ban FROM bancos ORDER BY cod_ban LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                Meses()
                PonerEnCero()
                VaciarCampos()
                Bloquear()
                lbestado.Text = "NULO"
                Exit Sub
            End If
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnumero.Text = "1"
            lbestado.Text = "CONSULTA"
            CmdPrimero.Focus()
        Catch ex As Exception
            Meses()
            VaciarCampos()
            PonerEnCero()
            Bloquear()
            lbestado.Text = "NULO"
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cod_ban FROM bancos ORDER BY cod_ban LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbnumero.Text = i + 1
            BuscarDoc(tabla.Rows(0).Item(0))
            lbestado.Text = "CONSULTA"
            CmdAtras.Focus()
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM bancos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnumero.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT cod_ban FROM bancos ORDER BY cod_ban LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDoc(tabla.Rows(0).Item(0))
            lbestado.Text = "CONSULTA"
            lbnumero.Text = i + 1
            CmdSiguiente.Focus()
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM bancos;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        If i < 0 Then
            MsgBox("No hay bancos en los registros.  ", MsgBoxStyle.Information, "Editar Conceptos ")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT cod_ban FROM bancos ORDER BY cod_ban LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        BuscarDoc(tabla.Rows(0).Item(0))
        lbestado.Text = "CONSULTA"
        lbnumero.Text = i + 1
        CmdUltimo.Focus()
    End Sub
    '************************************
    Public Sub BuscarDoc(ByVal doc As String)
        Try
            Meses()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM bancos WHERE cod_ban='" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcodigo.Text = tabla.Rows(0).Item("cod_ban")
            txtcuenta.Text = tabla.Rows(0).Item("codigo")
            txtcuenta_TextChanged(AcceptButton, AcceptButton)
            txtbanco.Text = tabla.Rows(0).Item("banco")
            txtnum.Text = tabla.Rows(0).Item("num_cta")
            txtnombre.Text = tabla.Rows(0).Item("nombre")
            txtnit.Text = tabla.Rows(0).Item("nit")
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            PonerEnCero()
            lbestado.Text = "NULO"
            lbnumero.Text = 0
        End Try
        Bloquear()
    End Sub
    '*************************************
    Public Sub Bloquear()
        Try
            cmdNuevo.Enabled = True
            CmdListo.Enabled = False
            CmdCancelar.Enabled = False
            CmdEditar.Enabled = True
            CmdMostrar.Enabled = True
            '*********************
            txtcuenta.Enabled = False
            txtbanco.Enabled = False
            txtnum.Enabled = False
            txtnombre.Enabled = False
            txtnum.Enabled = False
            txtcodigo.Enabled = False
            txtnit.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Public Sub DesBloquear()
        cmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        CmdEditar.Enabled = False
        CmdMostrar.Enabled = False
        '*********************
        txtcuenta.Enabled = True
        txtbanco.Enabled = False
        txtnum.Enabled = True
        txtnombre.Enabled = True
        txtnum.Enabled = True
        txtcodigo.Enabled = True
        txtnit.Enabled = True
    End Sub
    '************************************
    Public Sub ValidarGuardar()
        Dim tabla As New DataTable
        If Trim(txtnomcta.Text) = "" Then
            MsgBox("Verifique la cuenta contable del banco o corporación. ", MsgBoxStyle.Information)
            txtcuenta.Focus()
            Exit Sub
        Else
            myCommand.CommandText = "SELECT * FROM bancos WHERE codigo='" & txtcuenta.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                MsgBox("Verifique la cuenta contable ya fué asignada a otro banco. ", MsgBoxStyle.Information)
                txtcuenta.Focus()
                Exit Sub
            End If
        End If
        If Trim(txtbanco.Text) = "" Then
            MsgBox("Verifique el nombre del banco o corporación. ", MsgBoxStyle.Information)
            txtnit.Focus()
            Exit Sub
        End If
        If Trim(txtnum.Text) = "" Then
            MsgBox("Verifique el numero de cuenta del banco o corporación. ", MsgBoxStyle.Information)
            txtbanco.Focus()
            Exit Sub
        End If
        If Trim(txtnit.Text) = "" Then
            MsgBox("Verifique el nit de cuenta del banco o corporación. ", MsgBoxStyle.Information)
            txtnit.Focus()
            Exit Sub
        End If
        If Trim(txtcodigo.Text) = "" Then
            MsgBox("Verifique el código interno del banco. ", MsgBoxStyle.Information)
            txtcuenta.Focus()
            Exit Sub
        Else
            myCommand.CommandText = "SELECT * FROM bancos WHERE cod_ban='" & txtcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                MsgBox("Verifique el codigo interno ya fué asignado a otro banco. ", MsgBoxStyle.Information)
                txtcuenta.Focus()
                Exit Sub
            End If
        End If
        Guardar()
    End Sub
    Public Sub Guardar()
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod_ban", CambiaCadena(txtcodigo.Text, 10))
            myCommand.Parameters.AddWithValue("?codigo", CambiaCadena(txtcuenta.Text, 15))
            myCommand.Parameters.AddWithValue("?banco", CambiaCadena(txtbanco.Text, 200))
            myCommand.Parameters.AddWithValue("?num_cta", CambiaCadena(txtnum.Text, 30))
            myCommand.Parameters.AddWithValue("?nombre", CambiaCadena(txtnombre.Text, 200))
            myCommand.Parameters.AddWithValue("?nit", CambiaCadena(txtnit.Text, 15))
            myCommand.CommandText = "INSERT INTO bancos VALUES(?cod_ban,?codigo,?banco,?num_cta,?nombre,?nit);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
            Bloquear()
            lbestado.Text = "GUARDADO"
            MsgBox("Datos Guardados Correctamente. ", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub ValidarModificar()
        Dim tabla As New DataTable
        If Trim(txtnomcta.Text) = "" Then
            MsgBox("Verifique la cuenta contable del banco o corporación. ", MsgBoxStyle.Information)
            txtcuenta.Focus()
            Exit Sub
        Else
            myCommand.CommandText = "SELECT * FROM bancos WHERE codigo='" & txtcuenta.Text & "' AND cod_ban<>'" & txtcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                MsgBox("Verifique la cuenta contable ya fué asignada a otro banco. ", MsgBoxStyle.Information)
                txtcuenta.Focus()
                Exit Sub
            End If
        End If
        If Trim(txtbanco.Text) = "" Then
            MsgBox("Verifique el nombre del banco o corporación. ", MsgBoxStyle.Information)
            txtnit.Focus()
            Exit Sub
        End If
        If Trim(txtnum.Text) = "" Then
            MsgBox("Verifique el numero de cuenta del banco o corporación. ", MsgBoxStyle.Information)
            txtbanco.Focus()
            Exit Sub
        End If
        If Trim(txtnit.Text) = "" Then
            MsgBox("Verifique el nit de cuenta del banco o corporación. ", MsgBoxStyle.Information)
            txtnit.Focus()
            Exit Sub
        End If
        If Trim(txtcodigo.Text) = "" Then
            MsgBox("Verifique el código interno del banco. ", MsgBoxStyle.Information)
            txtcuenta.Focus()
            Exit Sub
        End If
        Modificar()
    End Sub
    Public Sub Modificar()
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            'myCommand.Parameters.AddWithValue("?cod_ban", CambiaCadena(txtcodigo.Text, 10))
            myCommand.Parameters.AddWithValue("?codigo", CambiaCadena(txtcuenta.Text, 15))
            myCommand.Parameters.AddWithValue("?banco", CambiaCadena(txtbanco.Text, 200))
            myCommand.Parameters.AddWithValue("?num_cta", CambiaCadena(txtnum.Text, 30))
            myCommand.Parameters.AddWithValue("?nombre", CambiaCadena(txtnombre.Text, 200))
            myCommand.Parameters.AddWithValue("?nit", CambiaCadena(txtnit.Text, 15))
            myCommand.CommandText = "UPDATE bancos SET codigo=?codigo,banco=?banco,num_cta=?num_cta,nombre=?nombre,nit=?nit WHERE cod_ban='" & txtcodigo.Text & "';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Bloquear()
            lbestado.Text = "EDITADO"
            MsgBox("Datos Guardados Correctamente. ", MsgBoxStyle.Information)
            Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    '*****************************************
    '*********** ACTUALIZAR CUENTAS
    Private Sub cmdActCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActCuenta.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("Solo en el estado CONSULTA se puede realizar esta operación.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        Dim tabla As New DataTable
        Dim barra As Double
        myCommand.CommandText = "SELECT codigo,saldo00 FROM selpuc WHERE codigo='" & txtcuenta.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        barra = 8
        Me.Cursor = Cursors.WaitCursor
        mibarra.Visible = True
        mibarra.Value = 0
        For i = 0 To tabla.Rows.Count - 1
            CalcularSaldo(tabla.Rows(i).Item("codigo"))
            For j = 0 To 12
                If j < 10 Then
                    Calcular("0" & j, tabla.Rows(i).Item("codigo"))
                Else
                    Calcular(j, tabla.Rows(i).Item("codigo"))
                End If
                If mibarra.Value < 95 Then
                    mibarra.Value = mibarra.Value + barra
                End If
            Next
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?sal", "0")
            End Try
            myCommand.CommandText = "UPDATE selpuc SET saldo=?sal WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
            myCommand.ExecuteNonQuery()
        Next
        mibarra.Value = 100
        mibarra.Visible = False
        Me.Cursor = Cursors.Default
        Cerrar()
        BuscarCuenta(txtcuenta.Text)
    End Sub
    Public Sub BuscarCuenta(ByVal cuenta As String)
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            grilla.ReadOnly = True
            'txtcuenta.ReadOnly = True
            'txtcuenta.Text = tabla.Rows(0).Item("codigo")
            txtnomcta.Text = tabla.Rows(0).Item("descripcion")
            'txtbanco.Text = tabla.Rows(0).Item("descripcion")
            '********************************************
            Dim consulta As String
            consulta = "SUM(saldo00) as saldo00,"
            For i = 1 To 12
                If i <= 9 Then
                    consulta = consulta & "SUM(debito0" & i & ") as debito0" & i & ","
                    consulta = consulta & "SUM(credito0" & i & ") as credito0" & i & ","
                Else
                    consulta = consulta & "SUM(debito" & i & ") as debito" & i & ","
                    If i < 12 Then
                        consulta = consulta & "SUM(credito" & i & ") as credito" & i & ","
                    Else
                        consulta = consulta & "SUM(credito" & i & ") as credito" & i
                    End If
                End If
            Next
            tsaldo.Clear()
            myCommand.CommandText = "SELECT " & consulta & " FROM selpuc WHERE codigo like '" & cuenta & "%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tsaldo)
            ' t.Text = (myCommand.CommandText.ToString)
            Dim total, d, c As Double
            Dim item As Integer
            Try
                total = tsaldo.Rows(0).Item("saldo00")
            Catch ex As Exception
                total = 0
            End Try
            For i = 0 To 11
                item = i + 1
                grilla.Item(1, i).Value = total
                If item < 10 Then
                    grilla.Item(3, i).Value = tsaldo.Rows(0).Item("debito0" & item)
                    grilla.Item(4, i).Value = tsaldo.Rows(0).Item("credito0" & item)
                Else
                    grilla.Item(3, i).Value = tsaldo.Rows(0).Item("debito" & item)
                    grilla.Item(4, i).Value = tsaldo.Rows(0).Item("credito" & item)
                End If
                Try
                    d = grilla.Item(3, i).Value
                Catch ex As Exception
                    d = 0
                End Try
                Try
                    c = grilla.Item(4, i).Value
                Catch ex As Exception
                    c = 0
                End Try
                total = total + d - c
                grilla.Item(5, i).Value = total
            Next
            BuscarEstNat()
        Catch ex As Exception
            txtnomcta.Text = ""
            PonerEnCero()
        End Try
    End Sub
    Public Sub BuscarEstNat()
        Try
            For i = 0 To grilla.RowCount - 1
                Try
                    If CDbl(grilla.Item(1, i).Value) < 0 Then
                        grilla.Item(2, i).Value = "C"
                    Else
                        grilla.Item(2, i).Value = "D"
                    End If
                Catch ex As Exception
                    grilla.Item(2, i).Value = "D"
                End Try
                Try
                    If CDbl(grilla.Item(5, i).Value) < 0 Then
                        grilla.Item(6, i).Value = "C"
                    Else
                        grilla.Item(6, i).Value = "D"
                    End If
                Catch ex As Exception
                    grilla.Item(6, i).Value = "D"
                End Try
            Next
        Catch ex As Exception

        End Try

    End Sub
    'cuenta
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
    End Sub
    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Try
            If txtnomcta.Text = "" Then
                FrmCuentas.lbform.Text = "bancos_cta"
                FrmCuentas.txtcuenta.Text = txtcuenta.Text
                FrmCuentas.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged
        Try
            BuscarCuenta(txtcuenta.Text)
        Catch ex As Exception

        End Try
    End Sub
    'banco
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    'num de cuenta
    Private Sub txtnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    'a nombre de
    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                    CmdListo.Focus()
                Else
                    SendKeys.Send("{TAB}")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    'nit
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        validarnumero(txtnit, e)
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Try
            If txtbanco.Text = "" Then
                If Trim(txtnit.Text) = "" Or txtnit.Text = "" Then
                    FrmSelCliente.lbform.Text = "bancos_txt"
                    FrmSelCliente.ShowDialog()
                Else
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(txtnit.Text)
                        txtnit.Text = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "bancos_txt"
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Try
            LABELDV.Text = DigitoNIT(txtnit.Text)
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If (tabla.Rows.Count = 0) Then
                txtbanco.Text = ""
            Else
                txtbanco.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            End If
        Catch ex As Exception
        End Try
    End Sub
    'codigo interno banco
    Private Sub txtcodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class