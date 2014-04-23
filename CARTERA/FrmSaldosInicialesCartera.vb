Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmSaldosInicialesCartera
    Public lon_cta As Integer
    Public TablaMes As String
    Public col, fila, FinEdit As Integer
    Private Sub FrmSaldosInicialesCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbcta.Text = ""
        cmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        txtnit.Enabled = False
        txtcta.Enabled = False
        txtcentro.Enabled = False
        '************************************
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT par_fac1,par_fac2,par_fac3,par_fac4,par_cta_cco FROM car_par LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros de cartera definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Me.Close()
            Exit Sub
        Else
            tipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("par_fac1")) <> "" Then
                tipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac1")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac2")) <> "" Then
                tipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac2")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac3")) <> "" Then
                tipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac3")))
            End If
            If Trim(tabla.Rows(0).Item("par_fac4")) <> "" Then
                tipo.Items.Add(Trim(tabla.Rows(0).Item("par_fac4")))
            End If
            lbcta.Text = Trim(tabla.Rows(0).Item("par_cta_cco"))
        End If

        Try
            MiConexion(bda)
            myCommand.CommandText = " UPDATE cobdpen SET salmov='S'  WHERE doc IN " _
                                    & "(SELECT DISTINCT cobdpen.doc " _
                                    & " FROM documentos00 d  WHERE d.doc= cobdpen.num AND d.tipodoc=cobdpen.tipo)  "
            myCommand.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtnit_LostFocus(AcceptButton, AcceptButton)
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtnit, e)
        End If
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnit.Text = "" Then
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnit.Text)
        End If
    End Sub

    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "sic"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "sic"
                frmterceros.txtnit.Text = txtnit.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtcta.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    Function valor_longitud_contable() As Integer
        Dim tabla As New DataTable
        Dim x1 As Integer
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        x1 = tabla.Rows(0).Item("longitud")
        Return x1
    End Function

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        lon_cta = valor_longitud_contable()
        grilla.Rows.Clear()
        grilla.RowCount = 1
        txtnit.Text = ""
        txtcliente.Text = ""
        txtcta.Text = ""
        txtnomcta.Text = ""
        txtcentro.Text = ""
        txtncentro.Text = ""
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        txtnit.Enabled = True
        txtcta.Enabled = True
        '¿HAY CENTRO DE COSTO?
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item("ccosto") = "N" Then
                txtcentro.Enabled = False
            Else
                txtcentro.Enabled = True
            End If
        Catch ex As Exception
            txtcentro.Enabled = False 'no hay tablas de contabilidad
        End Try
        txtnit.Focus()
    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items < 1 Then
                txtcliente.Text = ""
            Else
                txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            End If
        Catch ex As Exception
            txtcliente.Text = ""
        End Try
    End Sub

    Private Sub txtcta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta.DoubleClick
        FrmCuentas.lbform.Text = "sic"
        FrmCuentas.ShowDialog()
    End Sub
    Function Verificar(ByVal cuenta As String) As Boolean
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub txtcta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcta.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & txtcta.Text & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtnomcta.Text = tabla.Rows(0).Item("descripcion")
            Else
                txtnomcta.Text = ""
            End If
        Catch ex As Exception
            txtnomcta.Text = ""
        End Try
    End Sub

    Private Sub txtcta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtcta.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtcta.Text) Then
                    grilla.Focus()
                End If
            Else
                FrmCuentas.txtcuenta.Text = Trim(txtcta.Text)
                FrmCuentas.lbform.Text = "sic"
                FrmCuentas.ShowDialog()
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        txtcta.Text = ""
        txtnomcta.Text = ""
        txtnit.Text = ""
        txtcliente.Text = ""
        cmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        grilla.Rows.Clear()
        laboltotal.Text = ""
    End Sub

    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
    End Sub

    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item("valor", i).Value.ToString = "" Then
                grilla.Item("valor", i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item("valor", i).Value = "0,00"
        End Try
        Try
            If grilla.Item("fecha", i).Value = "" Then
                grilla.Item("fecha", i).Value = CDate(Today.Day & "/" & PerActual)
            End If
        Catch ex As Exception
            'Try
            '    grilla.Item("fecha", i).Value = CDate(Today.Day & "/" & PerActual)
            'Catch ex2 As Exception
            '    If PerActual(0) & PerActual(1) = "02" Then
            '        grilla.Item("fecha", i).Value = CDate("28/" & PerActual)
            '    Else
            '        grilla.Item("fecha", i).Value = CDate("30/" & PerActual)
            '    End If
            'End Try
        End Try
        Try
            If grilla.Item("vmto", i).Value.ToString = "" Then
                grilla.Item("vmto", i).Value = "30"
            End If
        Catch ex As Exception
            grilla.Item("vmto", i).Value = "30"
        End Try
        Try
            If grilla.Item("cuenta", i).Value.ToString = "" Then
                grilla.Item("cuenta", i).Value = Trim(lbcta.Text)
            End If
        Catch ex As Exception
            grilla.Item("cuenta", i).Value = Trim(lbcta.Text)
        End Try
    End Sub
    Public Sub BuscarExistente(ByVal doc As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM cobdpen WHERE doc='" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim item As Integer = tabla.Rows.Count
            If item > 0 Then
                MsgBox("Documento " & doc & " ya existe en los registros de cuentas por cobrar. ", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0 'tipo doc

                Case 1  'CASO MUNERO DOC                       
                    grilla.Item("doc", e.RowIndex).Value = NumeroDoc(grilla.Item("doc", e.RowIndex).Value)
                    BuscarExistente(grilla.Item("tipo", e.RowIndex).Value & grilla.Item("doc", e.RowIndex).Value)
                Case 2  'CASO CONCEPTO                       
                    grilla.Item(2, e.RowIndex).Value = UCase(grilla.Item(2, e.RowIndex).Value)
                Case 3 'FECHA
                    Try
                        grilla.Item("fecha", e.RowIndex).Value = CDate(grilla.Item("fecha", e.RowIndex).Value)
                    Catch ex As Exception
                        MsgBox("Erro al digitar la fecha, verifique el formato")
                    End Try
                Case 4 'VMTO
                    Try
                        grilla.Item("vmto", e.RowIndex).Value = Val(grilla.Item("vmto", e.RowIndex).Value)
                    Catch ex As Exception
                        grilla.Item("vmto", e.RowIndex).Value = "0"
                    End Try
                Case 5 'VALOR
                    grilla.Item("valor", e.RowIndex).Value = Moneda(grilla.Item("valor", e.RowIndex).Value)
                    SacarCuenta()
                    'Buscarcuentas(grilla.Item(3, e.RowIndex).Value, e.RowIndex)
                Case 6 'CUENTAS
                    Buscarcuentas(grilla.Item("cuenta", e.RowIndex).Value, e.RowIndex)
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION            
                Case 1  'CASO DEBITO
                Case 2  'CASO CREDITO  
                Case 3 'CASO CUENTA    
                Case 4 'CASO BASE
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        'SacarCuenta()
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If CmdListo.Enabled = False Then Exit Sub
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If CmdListo.Enabled = False Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub

    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        FrmCuentas.txtcuenta.Text = cuenta
        If cuenta = "" Then
            FrmCuentas.txtcuenta.Text = cuenta
            FrmCuentas.lbform.Text = "siccartera"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If nivel_cuenta(grilla.Item("cuenta", fila).Value) = True Then
                    grilla.Item("cuenta", fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "siccartera"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    SendKeys.Send(Chr(Keys.Tab))
                    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                    resultado = MsgBox("La cuenta (" & grilla.Item(4, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                    If resultado = MsgBoxResult.Yes Then
                        FrmNuevaCuenta.txtcuenta.Text = grilla.Item(4, fila).Value
                        grilla.Item("cuenta", fila).Value = ""
                        FrmNuevaCuenta.lbfila.Text = fila
                        FrmNuevaCuenta.ShowDialog()
                    Else
                        grilla.Item("cuenta", fila).Value = ""

                    End If
                End If
            Else
                grilla.Item("cuenta", fila).Selected = True
            End If
        End If
    End Sub
    Function nivel_cuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo LIKE '%" & codigo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        'ValoresDefecto(e.RowIndex)
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION 
                    'If filaAnt < fila And FinEdit = 1 Then
                    '    Posicionar(1)
                    'End If
                Case 1  'CASO DEBITO 
                Case 3 'CASO VALOR 
                Case 6 'CASO CUENTA
                    If grilla.Item("cuenta", e.RowIndex).Value <> "" Or grilla.Item(1, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 And e.ColumnIndex <> 5 Then
            FinEdit = 0
            If e.ColumnIndex = 6 Then
                SendKeys.Send("{HOME}")
            Else
                SendKeys.Send(Chr(Keys.Tab))
            End If
            e.Cancel = True
        End If
    End Sub
    Public Sub SacarCuenta()
        Try
            Dim valor, sum As Double
            valor = 0
            sum = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    valor = CDbl(grilla.Item("valor", i).Value)
                Catch ex As Exception
                    valor = 0
                End Try
                sum = sum + valor
            Next
            laboltotal.Text = Moneda(sum)
        Catch ex As Exception
            MsgBox("Error En Los Valores Verifique... " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If validar() = True Then
            EnviarGuardar()
        End If
    End Sub
    Function validar()
        If cbcont.Checked = False Then
            Dim rs As MsgBoxResult
            rs = MsgBox("Los saldos iniciales no seran contabilizados,¿Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
            If rs = MsgBoxResult.No Then
                cbcont.Focus()
                Return False
                Exit Function
            End If
        End If
        If txtcliente.Text = "" Or txtnit.Text = "" Then
            MsgBox("Verifique los datos del cliente. ", MsgBoxStyle.Information)
            txtnit.Focus()
            Return False
            Exit Function
        End If
        If cbcont.Checked = True Then
            If txtnomcta.Text = "" Or txtcta.Text = "" Then
                MsgBox("Verifique la cuanta contable. ", MsgBoxStyle.Information)
                txtcta.Focus()
                Return False
                Exit Function
            End If
        End If
        If txtncentro.Text = "" And txtcentro.Enabled = True Then
            MsgBox("Verifique el centro de costo. ", MsgBoxStyle.Information)
            txtcentro.Focus()
            Return False
            Exit Function
        End If
        For i = 0 To grilla.RowCount - 1
            Try
                If grilla.Item("cuenta", i).Value <> "" And grilla.Item("doc", i).Value <> "" And grilla.Item("concepto", i).Value <> "" And grilla.Item("fecha", i).Value.ToString <> "" Then
                    If grilla.Item("doc", i).Value = "" Or grilla.Item("doc", i).Value = "00000" Then
                        MsgBox("Verifique el numero de la facturas. ", MsgBoxStyle.Information)
                        grilla.Focus()
                        Return False
                        Exit Function
                    End If
                    If grilla.Item("valor", i).Value = "0,00" Then
                        MsgBox("Verifique el valor de la factura " & grilla.Item("tipo", i).Value & grilla.Item("doc", i).Value & ". ", MsgBoxStyle.Information)
                        grilla.Focus()
                        Return False
                        Exit Function
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        Return True
    End Function
    Public Sub EnviarGuardar()
        Try
            MiConexion(bda)
            Dim sw As Integer = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    If grilla.Item("cuenta", i).Value <> "" And grilla.Item("doc", i).Value <> "" And grilla.Item("concepto", i).Value <> "" And grilla.Item("fecha", i).Value.ToString <> "" Then
                        Guardar_COBDPEN(i)
                        If cbcont.Checked = True Then
                            Guardar_Cta_13(i)
                            Guardar_Cta_Contable(i)
                        End If
                        sw = sw + 1
                        ActualizarConsecutivo(i)
                        grilla.Item("ok", i).Value = True
                    End If
                Catch ex As Exception
                End Try
            Next
            If sw > 0 Then
                cmdNuevo.Enabled = True
                CmdListo.Enabled = False
                CmdCancelar.Enabled = False
                txtnit.Enabled = False
                txtcta.Enabled = False
                txtcentro.Enabled = False
                MsgBox("Se Ingresaron " & sw & " Facturas Correctamente, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            Else
                MsgBox("NO Se Ingresaron Facturas, Verifique que los datos sean correctos.  ", MsgBoxStyle.Information, "SAE Control")
            End If
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub
    Public Sub ActualizarConsecutivo(ByVal fila As Integer)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & grilla.Item("tipo", fila).Value & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Try
            If Val(tabla.Rows(0).Item("actualfc").ToString) < Val(grilla.Item("doc", fila).Value) Then
                myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(grilla.Item("doc", fila).Value) & " WHERE tipodoc='" & grilla.Item("tipo", fila).Value & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Guardar_COBDPEN(ByVal fila As Integer)
        Dim fecha As Date = CDate(grilla.Item("fecha", fila).Value)
        ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR TABLA COBDPEN'''''''''''''''''''''''''''''''
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", grilla.Item("tipo", fila).Value & grilla.Item("doc", fila).Value)
        myCommand.Parameters.AddWithValue("?tipo", grilla.Item("tipo", fila).Value)
        myCommand.Parameters.AddWithValue("?num", Val(grilla.Item("doc", fila).Value))
        myCommand.Parameters.AddWithValue("?descrip", "")
        myCommand.Parameters.AddWithValue("?tipafec", "")
        myCommand.Parameters.AddWithValue("?clasaju", "")
        myCommand.Parameters.AddWithValue("?nitc", txtnit.Text.ToString)
        myCommand.Parameters.AddWithValue("?nomnit", txtcliente.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitcod", "")
        myCommand.Parameters.AddWithValue("?nitv", "0")
        myCommand.Parameters.AddWithValue("?fecha", CDate(fecha))
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(grilla.Item("vmto", fila).Value))
        myCommand.Parameters.AddWithValue("?concepto", CambiaCadena(grilla.Item("concepto", fila).Value, 99))
        'subtotal
        myCommand.Parameters.AddWithValue("?subtotal", DIN(grilla.Item("valor", fila).Value))
        'descuento
        myCommand.Parameters.AddWithValue("?descto", DIN(0))
        'rete_fuente
        myCommand.Parameters.AddWithValue("?ret", "0")
        'iva
        myCommand.Parameters.AddWithValue("?iva", DIN(0))
        myCommand.Parameters.AddWithValue("?v_iva", DIN(0))
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(grilla.Item("valor", fila).Value))
        'cuentas
        myCommand.Parameters.AddWithValue("?ctasubtotal", "")
        myCommand.Parameters.AddWithValue("?ctaret", "")
        myCommand.Parameters.AddWithValue("?ctaiva", "")
        myCommand.Parameters.AddWithValue("?ctatotal", grilla.Item("cuenta", fila).Value)
        'ccosto
        Try
            myCommand.Parameters.AddWithValue("?ccosto", Val(txtcentro.Text))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?ccosto", Val(0))
        End Try
        myCommand.Parameters.AddWithValue("?otroimp", "N")
        'rete_iva
        myCommand.Parameters.AddWithValue("?retiva", "0")
        myCommand.Parameters.AddWithValue("?ctaretiva", "")
        'ret_ica
        myCommand.Parameters.AddWithValue("?retica", "0")
        myCommand.Parameters.AddWithValue("?ctaretica", "")
        'pagado
        myCommand.Parameters.AddWithValue("?pagado", "0")
        'pos
        myCommand.Parameters.AddWithValue("?rcpos", "")
        myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
        myCommand.Parameters.AddWithValue("?vpos", "0")
        'tasa
        myCommand.Parameters.AddWithValue("?tasa", "0")
        'moneda
        myCommand.Parameters.AddWithValue("?moneda", "")
        myCommand.Parameters.AddWithValue("?monloex", "L")
        'estado
        myCommand.Parameters.AddWithValue("?estado", "AP")
        myCommand.Parameters.AddWithValue("?salmov", "S")
        myCommand.Parameters.AddWithValue("?pagare", "")
        'INSERTAR COBDPEN
        myCommand.CommandText = "INSERT INTO cobdpen VALUES (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto," _
                              & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                              & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Guardar_Cta_13(ByVal fila)
        Try
            Dim fecha As Date = CDate(grilla.Item("fecha", fila).Value)
            Dim dia As Integer = fecha.Day
            Dim per As String = fecha.Month & "/" & fecha.Year
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", grilla.Item("doc", fila).Value)
            myCommand.Parameters.AddWithValue("?tipodoc", grilla.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?periodo", per)
            myCommand.Parameters.AddWithValue("?dia", dia)
            Try
                myCommand.Parameters.AddWithValue("?centro", Val(txtcentro.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?centro", Val(0))
            End Try
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("concepto", fila).Value, 49))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("valor", fila).Value))
            myCommand.Parameters.AddWithValue("?credito", "0")
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(0))
            myCommand.Parameters.AddWithValue("?diasv", Val(grilla.Item("vmto", fila).Value))
            If Val(grilla.Item("vmto", fila).Value) > 0 Then
                Dim fec As Date = DateAdd("d", grilla.Item("vmto", fila).Value, fecha)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "cartera")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos00 " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("valor", fila).Value, 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Guardar_Cta_Contable(ByVal fila As Integer)
        Try
            Dim fecha As Date = CDate(grilla.Item("fecha", fila).Value)
            Dim dia As Integer = fecha.Day
            Dim per As String = fecha.Month & "/" & fecha.Year
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", grilla.Item("doc", fila).Value)
            myCommand.Parameters.AddWithValue("?tipodoc", grilla.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?periodo", per)
            myCommand.Parameters.AddWithValue("?dia", dia)
            Try
                myCommand.Parameters.AddWithValue("?centro", Val(txtcentro.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?centro", Val(0))
            End Try
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("concepto", fila).Value, 49))
            myCommand.Parameters.AddWithValue("?debito", "0")
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("valor", fila).Value))
            myCommand.Parameters.AddWithValue("?codigo", Trim(txtcta.Text))
            myCommand.Parameters.AddWithValue("?base", DIN(0))
            myCommand.Parameters.AddWithValue("?diasv", Val(grilla.Item("vmto", fila).Value))
            If Val(grilla.Item("vmto", fila).Value) > 0 Then
                Dim fec As Date = DateAdd("d", grilla.Item("vmto", fila).Value, fecha)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "cartera")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos00 " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, 0, DIN(grilla.Item("valor", fila).Value))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtcentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentro.KeyPress
        validarnumero(txtcentro, e)
    End Sub
    Private Sub txtcentro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentro.LostFocus
        If Trim(txtncentro.Text) = "" Then
            FrmSelCentroCostos.txtcuenta.Text = txtcentro.Text
            FrmSelCentroCostos.lbform.Text = "car_si"
            FrmSelCentroCostos.ShowDialog()
        End If
    End Sub
    Private Sub txtcentro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentro.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nombre FROM centrocostos WHERE centro ='" & txtcentro.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtncentro.Text = tabla.Rows(0).Item("nombre")
            Else
                txtncentro.Text = ""
            End If
        Catch ex As Exception
            txtncentro.Text = ""
        End Try
    End Sub


    Private Sub cmdInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInf.Click


        Try

        Dim nom As String = ""
        Dim nit As String = ""
        Dim tt As String = ""
        Dim tabla2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")
        tt = "SALDOS INICIALES DE CARTERA"

        Dim tdoc As String = ""
        Dim td As New DataTable
        myCommand.CommandText = "SELECT par_fac1,par_fac2,par_fac3,par_fac4 FROM  car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        If td.Rows.Count > 0 Then
            For i = 0 To 3
                If td.Rows(0).Item(i) <> "" Then
                    tdoc = tdoc & "'" & td.Rows(0).Item(i) & "',"
                End If
            Next
            tdoc = Strings.Left(tdoc, Len(tdoc) - 1)
        End If


        ' DOCUMENTOS00
        Dim docu As String = ""
        Dim tdc As New DataTable
        myCommand.CommandText = "SELECT DISTINCT CAST(CONCAT(tipodoc,doc)  AS CHAR(50) ) AS d FROM documentos00 WHERE tipodoc IN (" & tdoc & ") ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tdc)
        If tdc.Rows.Count > 0 Then
            For j = 0 To tdc.Rows.Count - 1
                docu = docu & "'" & tdc.Rows(j).Item(0) & "',"
            Next
        End If
            If tdc.Rows.Count = 0 Then Exit Sub
            docu = Strings.Left(docu, Len(docu) - 1)


        Dim tc As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT doc, fecha,CAST(CONCAT( RIGHT(fecha, 2), '/', MID(fecha, 6, 2), '/',LEFT(fecha, 4) ) AS CHAR(20)) AS nitv," _
        & " concat(nitc,' ',nomnit) as nomnit, total, (total-pagado) AS pagado FROM cobdpen " _
        & " WHERE CONCAT(tipo, num) IN (" & docu & ") ORDER BY fecha"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportSalIniCar.rpt")
        CrReport.SetDataSource(tc)
        FrmReportCarCuen.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prtt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prtt.Name = "tt"
            Prtt.CurrentValues.AddValue(tt.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtt)

            FrmReportCarCuen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCarCuen.ShowDialog()

        Catch ex As Exception
        End Try
        Catch ex As Exception
            MsgBox(ex.ToString & "Informe no generado")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmEliminarSICart.lbform.Text = "cartCli"
        FrmEliminarSICart.ShowDialog()
    End Sub
End Class