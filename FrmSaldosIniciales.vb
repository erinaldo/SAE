Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmSaldosIniciales
    Public TablaMes As String
    Public col, fila, FinEdit As Integer
    Private Sub FrmEntradaDatos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbestado.Text = "NULO"
        CmdCancelar_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmEntradaDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'hay centros de costos
        MiConexion(bda)
        Cerrar()
        Dim t As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item("ccosto") = "S" Then
            txtcentro.Enabled = True
        Else
            txtcentro.Enabled = False
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        lbestado.Text = "NULO"
        CmdCancelar_Click(AcceptButton, AcceptButton)
    End Sub
    '**********************************************************************************
    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 And e.ColumnIndex <> 8 Then
            FinEdit = 0
            If e.ColumnIndex = 7 And txtcentro.Enabled = False Then
                SendKeys.Send("{HOME}")
            Else
                SendKeys.Send(Chr(Keys.Tab))
            End If
            e.Cancel = True
        End If
    End Sub
    Public Sub BuscarCta(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & grilla.Item(3, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcta.Text = tabla.Rows(0).Item("codigo").ToString & " " & tabla.Rows(0).Item("descripcion").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbcta.Text = ""
        End Try
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ape FROM terceros WHERE nit='" & grilla.Item(7, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtnit.Text = grilla.Item(7, f).Value.ToString
            txtnombre.Text = tabla.Rows(0).Item("ape").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            'txtnit.Text = ""
            txtnombre.Text = ""
        End Try
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        BuscarCta(fila)
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION 
                    'If filaAnt < fila And FinEdit = 1 Then
                    '    Posicionar(1)
                    'End If
                Case 1  'CASO DEBITO 
                Case 2  'CASO CREDITO                     
                Case 3 'CASO CUENTA 
                    If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 4 'CASO BASE                     
                Case 5 'CASO DIAS                     
                Case 6 'CASO FECHA                    
                Case 7 'CASO NIT 
                    If grilla.Item(7, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 8 'CASO NIT 
                    If grilla.Item(8, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Or txtcentro.Enabled = False Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Try
            If e.RowIndex > 0 And UCase(grilla.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "FF" Then
                grilla.Item(e.ColumnIndex, e.RowIndex).Value = grilla.Item(e.ColumnIndex, e.RowIndex - 1).Value
                ValoresDefecto(e.RowIndex)
                SacarCuenta()
                Exit Sub
            End If
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION                       
                    grilla.Item(0, e.RowIndex).Value = UCase(grilla.Item(0, e.RowIndex).Value)
                Case 1  'CASO DEBITO                    
                    grilla.Item(1, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(1, e.RowIndex).Value.ToString), 2)
                    If grilla.Item(1, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 2  'CASO CREDITO 
                    If CDbl(grilla.Item(2, e.RowIndex).Value) = 0 Then
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(2, e.RowIndex).Value.ToString), 2)
                        grilla.Item(1, e.RowIndex).Value = "0,00"
                    End If
                Case 3 'CASO CUENTA
                    Buscarcuentas(grilla.Item(3, e.RowIndex).Value, e.RowIndex)
                Case 4 'CASO BASE
                    grilla.Item(4, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(4, e.RowIndex).Value.ToString), 2)
                Case 5 'CASO DIAS 
                    grilla.Item(5, e.RowIndex).Value = Val(grilla.Item(5, e.RowIndex).Value)
                Case 6 'CASO FECHA
                    grilla.Item(6, e.RowIndex).Value = CDate(grilla.Item(6, e.RowIndex).Value)
                Case 7 'CASO NIT
                    grilla.Item(7, e.RowIndex).Value = Replace(grilla.Item(7, e.RowIndex).Value.ToString, ".", "")
                    grilla.Item(7, e.RowIndex).Value = Replace(grilla.Item(7, e.RowIndex).Value.ToString, "-", "")
                    BuscarNit(grilla.Item(7, e.RowIndex).Value, e.RowIndex)
                Case 8 'CASO CC
                    BuscarCCG(e.RowIndex)
                    If grilla.Item(0, e.RowIndex).Value <> "" Then
                        grilla.Focus()
                        SendKeys.Send("{HOME}")
                    End If
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION            
                Case 1  'CASO DEBITO
                    If grilla.Item(1, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(1, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(1, e.RowIndex).Value = "0,00"
                Case 2  'CASO CREDITO  
                    If grilla.Item(2, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 3 'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(3, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex)
                Case 4 'CASO BASE
                    If grilla.Item(4, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor de la base. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(4, e.RowIndex).Value = "0,00"
                Case 5 'CASO DIAS 
                    ' MsgBox("Error al digitar los dias de vencimiento, ", MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(5, e.RowIndex).Value = "0"
                Case 6 'CASO FECHA
                    MsgBox("Error al digitar la fecha de vencimiento, Verifique el formato (DD/MM/AAAA).", MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(6, e.RowIndex).Value = "00/00/0000"
                Case 7 'CASO NIT
                    grilla.Item(7, e.RowIndex).Value = ""
                    BuscarNit("", e.RowIndex)
                Case 8 'CASO CC
                    'MsgBox("Error al digitar el nit. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(8, e.RowIndex).Value = ""
                    BuscarCCG(e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuenta()
    End Sub
    '*************************************************************
    Public Sub BuscarCCG(ByVal i As Integer)
        Try
            SendKeys.Send("{HOME}")
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & Trim(grilla.Item(8, i).Value) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                grilla.Item(8, i).Value = tabla.Rows(i).Item("centro")
            Else
                FrmSelCentroCostos.txtcuenta.Text = grilla.Item(8, i).Value
                grilla.Item(8, i).Value = ""
                FrmSelCentroCostos.lbform.Text = "conta_si"
                FrmSelCentroCostos.ShowDialog()
            End If
            If grilla.Item(8, i).Value <> "" Then
                SendKeys.Send("{HOME}")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item(1, i).Value.ToString = "" Then
                grilla.Item(1, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(1, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(2, i).Value.ToString = "" Then
                grilla.Item(2, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(2, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(4, i).Value.ToString = "" Then
                grilla.Item(4, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(4, i).Value = "0,00"
        End Try
        Dim fec As Date = CDate(txtperiodo.Text)
        Try
            If Trim(grilla.Item(5, i).Value.ToString) = "" Then
                grilla.Item(5, i).Value = Val(txtvmto.Text)
                grilla.Item(6, i).Value = fec.AddDays(Val(txtvmto.Text))
            End If
        Catch ex As Exception
            Try
                grilla.Item(5, i).Value = Val(txtvmto.Text)
                grilla.Item(6, i).Value = fec.AddDays(Val(txtvmto.Text))
            Catch ex2 As Exception
                grilla.Item(5, i).Value = "0"
                grilla.Item(6, i).Value = fec
            End Try
        End Try
        Try
            If grilla.Item(7, i).Value.ToString = "" And Trim(txtnombre.Text) <> "" Then
                grilla.Item(7, i).Value = txtnit.Text
            End If
        Catch ex As Exception
            If Trim(txtnombre.Text) <> "" Then
                grilla.Item(7, i).Value = txtnit.Text
            End If
        End Try
        Try
            If Trim(grilla.Item(8, i).Value.ToString) = "" And Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then
                grilla.Item(8, i).Value = txtcentro.Text
            End If
        Catch ex As Exception
            If Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then
                grilla.Item(8, i).Value = txtcentro.Text
            End If
        End Try
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "si"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                grilla.Item(3, fila).Value = ""
                FrmCuentas.lbform.Text = "si"
                FrmCuentas.lbfila.Text = fila
                If cuenta <> "" Then
                    FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                End If
                FrmCuentas.ShowDialog()
            Else
                grilla.Item(4, fila).Selected = True
            End If
        End If

    End Sub
    Public Sub BuscarNit(ByVal nit As String, ByVal fila As Integer)
        Try
            If Trim(nit) = "" Then
                FrmSelCliente.lbform.Text = "si"
                FrmSelCliente.lbfila.Text = fila
                FrmSelCliente.ShowDialog()
            Else
                Dim items As Integer
                Dim tabla, tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & Trim(nit) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(nit)
                        LimpiarTerceros()
                        grilla.Item(7, fila).Value = ""
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.rbnatural.Checked = True
                        frmterceros.lbform.Text = "si"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit...", MsgBoxStyle.Information, "SAE Información")
                        grilla.Item(7, fila).Value = ""
                    End If
                Else
                    grilla.Item(7, fila).Value = Trim(nit)
                End If
            End If
            If txtcentro.Enabled = False Then
                SendKeys.Send("{HOME}")
            Else
                SendKeys.Send(Chr(Keys.Tab))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SacarCuenta()
        Try
            Dim sumadb, sumacr, db, cr As Double
            sumadb = 0
            sumacr = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    db = CDbl(grilla.Item(1, i).Value)
                Catch ex As Exception
                    db = 0
                End Try
                Try
                    cr = CDbl(grilla.Item(2, i).Value)
                Catch ex As Exception
                    cr = 0
                End Try
                sumadb = sumadb + db
                sumacr = sumacr + cr
            Next
            txtdb.Text = sumadb
            txtdb.Text = Moneda(txtdb.Text)
            txtcr.Text = sumacr
            txtcr.Text = Moneda(txtcr.Text)
            txtdif.Text = sumadb - sumacr
            txtdif.Text = Moneda(txtdif.Text)
            If (sumadb - sumacr) = 0 Then txtdif.Text = "0,00"
        Catch ex As Exception
            MsgBox("Error al sacar diferencia " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try
    End Sub
    '************************************************************************************
    Private Sub CmdCambiarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BuscarPeriodo()
            FrmPeriodo.lbactual.Text = PerActual
            FrmPeriodo.ShowDialog()
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                txtperiodo.Text = "/" & PerActual
                Dim cad As String
                cad = TxtDocumento.Text
                If (cad(0) & cad(1)) = "FC" Then Exit Sub
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim mes As String
            grilla.ReadOnly = True
            BuscarPeriodo()
            mes = "documentos00"
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc<>'__' ORDER BY tipodoc,doc LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                TxtNumero.Text = ""
                TxtDocumento.Text = ""
                txtDoc.Text = ""
                txtdb.Text = ""
                txtcr.Text = ""
                txtdif.Text = ""
                txtcentro.Text = ""
                txtvmto.Text = ""
                txtncentro.Text = ""
                TxtDocumento.Enabled = False
                grilla.ReadOnly = True
                grilla.RowCount = 1
                grilla.Item(0, 0).Value = ""
                grilla.Item(1, 0).Value = ""
                grilla.Item(2, 0).Value = ""
                grilla.Item(3, 0).Value = ""
                grilla.Item(4, 0).Value = ""
                grilla.Item(5, 0).Value = ""
                grilla.Item(6, 0).Value = ""
                grilla.Item(7, 0).Value = ""
                grilla.Item(0, 0).Value = ""
                lbnroobs.Text = 0
                lbestado.Text = "NULO"
                Bloquear()
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            Bloquear()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            grilla.ReadOnly = True
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos00"
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc<>'__' ORDER BY tipodoc,doc LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            grilla.ReadOnly = True
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos00"
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc<>'__' ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            Else
                CmdUltimo_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            grilla.ReadOnly = True
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos00"
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc<>'__' ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
            SacarCuenta()
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal tab As String, ByVal doc As String, ByVal tipo As String)
        Try
            Dim tabla As New DataTable
            lbestado.Text = "CONSULTA"
            myCommand.CommandText = "SELECT * FROM " & tab & " WHERE doc=" & doc & " AND tipodoc='" & tipo & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                TxtNumero.Text = NumeroDoc(Val(tabla.Rows(0).Item("doc").ToString))
                TxtDocumento.Text = tabla.Rows(0).Item("tipodoc")
                If tabla.Rows(0).Item("centro") <> "0" Then
                    txtcentro.Text = tabla.Rows(0).Item("centro")
                Else
                    txtcentro.Text = ""
                End If
                txtncentro.Text = BuscarCentroCostos(txtcentro.Text)
                txtvmto.Text = tabla.Rows(0).Item("diasv")
                txtnit.Text = tabla.Rows(0).Item("nit")
                txtnit_LostFocus(AcceptButton, AcceptButton)
                TxtDocumento.ReadOnly = True
                TxtNumero.ReadOnly = True
                BuscarTipo()
                'txtdia.Text = tabla.Rows(0).Item("dia")
                Try
                    txtperiodo.Value = tabla.Rows(0).Item("dia") & "/" & tabla.Rows(0).Item("periodo")
                Catch ex As Exception
                End Try
                Try
                    grilla.Rows.Clear()
                Catch ex As Exception
                End Try
                grilla.RowCount = tabla.Rows.Count + 1
                Dim fec As Date = CDate(txtperiodo.Text)
                For i = 0 To tabla.Rows.Count - 1
                    Try
                        grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
                        grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
                        grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
                        grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
                        grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
                        grilla.Item(5, i).Value = tabla.Rows(i).Item("diasv")
                        Try
                            grilla.Item(6, i).Value = fec.AddDays(Val(tabla.Rows(i).Item("diasv")))
                        Catch ex As Exception
                        End Try
                        'grilla.Item(6, i).Value = tabla.Rows(i).Item("fechaven")
                        grilla.Item(7, i).Value = tabla.Rows(i).Item("nit")
                        If tabla.Rows(i).Item("centro").ToString = "0" Then
                            grilla.Item("cc", i).Value = ""
                        Else
                            grilla.Item("cc", i).Value = tabla.Rows(i).Item("centro")
                        End If
                    Catch ex As Exception
                        grilla.Item("cc", i).Value = ""
                        MsgBox(ex.ToString)
                    End Try
                    grilla.Item(9, i).Value = tabla.Rows(i).Item("cheque")
                Next
                Try
                    tabla.Clear()
                    myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If tabla.Rows.Count <= 0 Then
                        txtDoc.Text = ""
                    Else
                        txtDoc.Text = tabla.Rows(0).Item("descripcion")
                    End If
                Catch ex As Exception
                    txtDoc.Text = ""
                End Try
                txtperiodo.Enabled = False
                Bloquear()
                SacarCuenta()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MesdelPeriodo()
        TablaMes = "documentos00"
    End Sub
    '*******************************************************************************
    Function PerBloq()
        Dim tablabloq As New DataTable
        myCommand.CommandText = "SELECT * FROM bloq_per WHERE periodo='00' ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablabloq)
        If tablabloq.Rows(0).Item(1) <> "n" Then
            MsgBox("No se pueden crear ni editar los saldos iniciales porque fueron bloqueados.   ", MsgBoxStyle.Information, "Verificando")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If PerBloq() = False Then Exit Sub
        Try
            If lbestado.Text = "NUEVO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tra_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            txtperiodo.Enabled = True
            TxtNumero.Text = ""
            TxtDocumento.Text = ""
            txtDoc.Text = ""
            txtdb.Text = "0"
            txtcr.Text = "0"
            txtdif.Text = "0"
            txtvmto.Text = "0"
            'txtdia.Text = "01"
            txtcentro.Text = ""
            txtncentro.Text = ""
            txtnit.Text = ""
            txtnombre.Text = ""
            Try
                txtperiodo.Text = Today.Day & "/" & "01" & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            Catch ex As Exception
                txtperiodo.Text = "01/" & "01" & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            End Try

            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE grupo = 'SI';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("Favor no han creado los tipos de documentos para saldos iniciales, verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count <= 0 Then
                MsgBox("Favor no han creados cuentas auxiliares, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            FrmTipoTransaccion.lbform.Text = "SI"
            FrmTipoTransaccion.ShowDialog()
            TxtDocumento.ReadOnly = False
            TxtDocumento.Enabled = True
            TxtNumero.ReadOnly = False
            Try
                grilla.ReadOnly = False
                grilla.Item(0, 0).Selected = True
                grilla.Item(0, 0).Selected = False
            Catch ex As Exception
            End Try
            grilla.RowCount = 1
            grilla.Item(0, 0).Value = ""
            grilla.Item(1, 0).Value = "0,00"
            grilla.Item(2, 0).Value = "0,00"
            grilla.Item(3, 0).Value = ""
            grilla.Item(4, 0).Value = "0,00"
            grilla.Item(5, 0).Value = "0"
            grilla.Item(6, 0).Value = "00/00/0000"
            grilla.Item(7, 0).Value = ""
            grilla.Item(8, 0).Value = ""
            grilla.Item(9, 0).Value = ""
            SacarCuenta()
            lbestado.Text = "NUEVO"
            Desbloquear()
            'txtdia.Text = Today.Day
            TxtNumero.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Try
            If lbestado.Text <> "CONSULTA" Then
                txtperiodo.Enabled = False
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
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
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If PerBloq() = False Then Exit Sub
                If tra_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                grilla.ReadOnly = False
                TxtNumero.ReadOnly = True
                lbestado.Text = "EDITAR"
                grilla.Item(0, 0).Selected = True
                txtperiodo.Enabled = True
                Desbloquear()
                grilla.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If tra_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                Eliminar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error. " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim cad As String
            cad = "documentos00"
            FrmVerDocumentos.tcad = "documentos00"
            FrmVerDocumentos.lbform.Text = "si"
            FrmVerDocumentos.ShowDialog()
            BuscarTipo()
            BuscarDocumento(cad, TxtNumero.Text, TxtDocumento.Text)
            SacarCuenta()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        TxtDocumento.Enabled = False
        Me.Close()
    End Sub
    '*************************************************************
    Public Sub ValidarGuardar()
        SacarCuenta()
        If TxtDocumento.Text = "" Then
            MsgBox("Favor escoger el tipo de documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtDocumento.Focus()
            Exit Sub
        ElseIf TxtNumero.Text = "" Then
            MsgBox("Favor verifique el campo Nro Documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtNumero.Focus()
            Exit Sub
        ElseIf CDec(txtdif.Text) <> 0 Then
            MsgBox("Favor verifique los items del documento la diferencia no puede ser distinta de cero(0)...", MsgBoxStyle.Information, "SAE Verificación")
            grilla.Focus()
            Exit Sub
        ElseIf txtdb.Text = "000,00" Then
            MsgBox("Favor verifique los items del documento no digitado ningun debito...", MsgBoxStyle.Information, "SAE Verificación")
            txtdb.Focus()
            Exit Sub
        ElseIf txtcr.Text = "000,00" Then
            MsgBox("Favor verifique los items del documento no digitado ningun credito...", MsgBoxStyle.Information, "SAE Verificación")
            txtcr.Focus()
            Exit Sub
        ElseIf grilla.RowCount <= 1 Then
            MsgBox("Favor verifique los items del documento no digitado ninguno...", MsgBoxStyle.Information, "SAE Verificación")
            grilla.Focus()
            Exit Sub
        ElseIf txtnit.Text = "" Then
            MsgBox("Favor digite el nit...", MsgBoxStyle.Information, "SAE Verificación")
            TxtDocumento.Focus()
            Exit Sub
        End If
        'If txtcentro.Enabled = True And txtncentro.Text = "" Then
        '    MsgBox("Favor seleccione un centro de costos...", MsgBoxStyle.Information, "SAE Verificación")
        '    txtcentro.Focus()
        '    Exit Sub
        'End If
        MesdelPeriodo()
        Dim cad As String
        cad = TxtDocumento.Text
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        'mirar que no falte nada enla grilla        
        For i = 0 To grilla.RowCount - 2
            If grilla.Item(0, i).Value = "" Then
                MsgBox("falta digitar una descripción.  ", MsgBoxStyle.Information, "SAE Verificación")
                grilla.Item(0, i).Selected = True
                grilla.Focus()
                Exit Sub
            ElseIf grilla.Item(3, i).Value = "" Then
                MsgBox("falta digitar una cuenta.  ", MsgBoxStyle.Information, "SAE Verificación")
                grilla.Item(3, i).Selected = True
                grilla.Focus()
                Exit Sub
            ElseIf Val(grilla.Item(1, i).Value) = 0 And Val(grilla.Item(2, i).Value) = 0 Then
                MsgBox("Los valores debito y credito no pueden ser ambos iguales a cero(0) en un mismo Item.   ", MsgBoxStyle.Information, "SAE Verificación")
                grilla.Item(1, i).Selected = True
                grilla.Focus()
                Exit Sub
            ElseIf Val(grilla.Item(8, i).Value) = 0 And txtcentro.Enabled = True Then
                MsgBox("Verifique todos los centros de costos.   ", MsgBoxStyle.Information, "SAE Verificación")
                grilla.Item(1, i).Selected = True
                grilla.Focus()
                Exit Sub
            End If
        Next
        If lbestado.Text = "NUEVO" Then
            '**************MIRAR SI EXIXTE***********************
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM documentos00 WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                MsgBox("Ya existe el documento, Verifique su número o consecutivo.  ", MsgBoxStyle.Information, "SAE Verificación")
                TxtNumero.Focus()
                Exit Sub
            End If
        Else
            '******************ELIMINAR LOS EXIXTENTES (PARA REMPLAZAR (MODIFICAR))******************************+
            ModificarCuentas()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM documentos00 WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & cad & "';"
            myCommand.ExecuteNonQuery()
        End If
        '************GUARDAR *********************
        For i = 0 To grilla.RowCount - 2
            Guardar(cad, i)
        Next
        ActualizarCuentas()
        If lbestado.Text = "NUEVO" Then
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", cad)
            myCommand.CommandText = "Update tipdoc set actual01=?actual WHERE tipodoc=?tipodoc AND actual01<?actual;"
            myCommand.ExecuteNonQuery()
            lbestado.Text = "GUARDADO"
        Else
            lbestado.Text = "EDITADO"
        End If
        Bloquear()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        txtperiodo.Enabled = False
        grilla.ReadOnly = True
        Cerrar()
    End Sub
    Public Sub Guardar(ByVal tipo As String, ByVal fila As Integer)
        Dim fecha As Date
        Dim diasv
        Try
            If grilla.Item(5, fila).Value = "0" Then
                fecha = CDate(txtperiodo.Value)
            Else
                fecha = fecha.AddDays(Val(grilla.Item(5, fila).Value))
            End If
        Catch ex As Exception
            fecha = CDate(txtperiodo.Value)
        End Try
        Try
            If Val(grilla.Item(5, fila).Value) = 0 Then
                diasv = 0
            Else
                diasv = Val(grilla.Item(5, fila).Value)
            End If
        Catch ex As Exception
            diasv = 0
        End Try
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", TxtNumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", tipo)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", txtperiodo.Value.Day.ToString)
        Try
            myCommand.Parameters.AddWithValue("?centro", grilla.Item(8, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?centro", "0")
        End Try
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(0, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(1, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(3, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", diasv)
        myCommand.Parameters.AddWithValue("?fechaven", CambiaCadena(Trim(fecha.ToString), 10))
        Try
            myCommand.Parameters.AddWithValue("?cheque", grilla.Item(9, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cheque", "")
        End Try
        myCommand.Parameters.AddWithValue("?nit", grilla.Item(7, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
        myCommand.CommandText = "INSERT INTO documentos00 VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
    End Sub
    Public Sub ActualizarCuentas()
        Dim suma, db, cb As Double
        For i = 0 To grilla.RowCount - 2
            Try
                db = CDbl(grilla.Item(1, i).Value.ToString)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cb = CDbl(grilla.Item(2, i).Value.ToString)
            Catch ex As Exception
                cb = 0
            End Try
            suma = db - cb
            Ejecutar("UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", saldo00=saldo00 + " & DIN(suma) & ", debito00=debito00 + " & DIN(db) & ", credito00=credito00 + " & DIN(cb) & " WHERE codigo='" & grilla.Item(3, i).Value & "';")
        Next
    End Sub
    Public Sub ModificarCuentas()
        Dim tabla As New DataTable
        Dim suma, db, cb As Double
        myCommand.CommandText = "SELECT * FROM documentos00 WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & Trim(TxtDocumento.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            Try
                db = CDbl(tabla.Rows(i).Item("debito").ToString)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cb = CDbl(tabla.Rows(i).Item("credito").ToString)
            Catch ex As Exception
                cb = 0
            End Try
            suma = db - cb
            Ejecutar("UPDATE selpuc SET saldo=saldo - " & DIN(suma) & ", saldo00=saldo00 - " & DIN(suma) & ", debito00=debito00 - " & DIN(db) & ", credito00=credito00 - " & DIN(cb) & " WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';")
        Next
    End Sub
    Public Sub Ejecutar(ByVal sql As String)
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    '*************************************************************
    Public Sub Eliminar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El documento " & TxtDocumento.Text & TxtNumero.Text & " de saldos iniciales se va a eliminar, ¿Desea Borrarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            BuscarPeriodo()
            Dim Sql, tabla As String
            tabla = "documentos00"
            Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & TxtDocumento.Text & "';"
            Ejecutar(Sql)
            MsgBox("El Registro " & TxtDocumento.Text & TxtNumero.Text & " fué eliminado correctamente.", MsgBoxStyle.Information, "SAE Borrar")
            Cerrar()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    '*************************************************************
    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" Then
                txtperiodo.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        Else
            If lbestado.Text = "NUEVO" Then
                validarnumero(TxtNumero, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "0" To "9", Chr(8), Chr(13)
                'txtdia.ForeColor = Color.Black
            Case Else
                ' txtdia.ForeColor = Color.Red
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" Then
                grilla.Focus()
                grilla.Item(0, 0).Selected = True
                SendKeys.Send(Chr(Keys.Space))
                SendKeys.Send(Chr(Keys.Back))
                grilla.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub TxtDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDocumento.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" Then
                TxtNumero.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub TxtDocumento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDocumento.LostFocus
        BuscarTipo()
    End Sub
    '*************************************************************
    Public Sub BuscarTipo()
        If TxtDocumento.Text = "" Then
            Try
                If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
                FrmTipoTransaccion.ShowDialog()
            Catch ex As Exception
                TxtDocumento.Focus()
            End Try
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "' AND grupo='SI' ORDER BY tipodoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                Try
                    If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
                    FrmTipoTransaccion.ShowDialog()
                Catch ex As Exception
                    TxtDocumento.Focus()
                End Try
            Else
                txtDoc.Text = tabla.Rows(0).Item(2)
                If lbestado.Text = "NUEVO" Then
                    Dim tablaI As New DataTable
                    myCommand.CommandText = "SELECT p.inicio FROM sae.periodos p LEFT JOIN (sae.companias c) ON p.codigo = c.codigo WHERE c.login = '" & FrmPrincipal.lbcompania.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tablaI)
                    '*****************************
                    'txtdia.Text = Today.Day
                    BuscarPeriodo()
                    Dim mi_per As String
                    mi_per = tablaI.Rows(0).Item(0)
                    If mi_per = "00" Then mi_per = "01"
                    txtperiodo.Text = Today.Day & "/" & mi_per & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
                    myCommand.Parameters.Clear()
                    Dim tabla2 As New DataTable
                    If TxtDocumento.Text = "FC" Then
                        myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla2)
                        TxtNumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(0).ToString) + 1)
                    Else
                        Dim cad As String
                        cad = "actual01"
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "SELECT " & cad & " FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla2)
                        TxtNumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(0).ToString) + 1)
                    End If
                End If
            End If
        End If
    End Sub
    '*************************************************************
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        Dim resp As MsgBoxResult
        resp = MsgBox("Si: Para imprimir el documento actual.  No: para imprimir todos los documetos de saldos iniciales. ", MsgBoxStyle.YesNoCancel, "SAE Imprimir")
        If resp = MsgBoxResult.No Then
            GenerarPDF2()
        ElseIf resp = MsgBoxResult.Yes Then
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Else
                GenerarPDF()
            End If
        End If
    End Sub
    Private Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\documento.pdf"
        Dim i, k As Integer
        Dim sumad, sumac, sumasaldo As Double
        Try
            Dim tablacomp As New DataTable
            Dim cad, cad2 As String
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            '***************************
            Refresh()
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(50, UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "FECHA: " & txtperiodo.Text, 20, 790, 0)
            cb.ShowTextAligned(50, "TIPO DOCUMENTO: " & txtDoc.Text, 20, 780, 0)
            cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 760, 0)
            k = 740
            cb.ShowTextAligned(50, "DESCRIPCIÓN", 10, k, 0)
            cb.ShowTextAligned(50, "CUENTA", 220, k, 0)
            cb.ShowTextAligned(50, "N.I.T.", 310, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 480, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
            k = k - 2
            sumad = 0
            sumac = 0
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            For i = 0 To grilla.RowCount - 1
                If grilla.Item(3, i).Value <> "" Then
                    k = k - 10
                    If k <= 65 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        k = 800
                    End If
                    sumad = CDbl(grilla.Item(1, i).Value.ToString)
                    sumac = CDbl(grilla.Item(2, i).Value.ToString)
                    sumasaldo = sumasaldo + sumad - sumac
                    cad2 = grilla.Item(0, i).Value.ToString
                    If cad2.Length > 37 Then
                        cad = ""
                        For j = 0 To 36
                            cad = cad & cad2(j)
                        Next
                        cb.ShowTextAligned(50, cad, 10, k, 0)
                    Else
                        cb.ShowTextAligned(50, grilla.Item(0, i).Value.ToString, 10, k, 0)
                    End If
                    cb.ShowTextAligned(50, grilla.Item(3, i).Value, 220, k, 0)
                    cb.ShowTextAligned(50, grilla.Item(7, i).Value, 310, k, 0)
                    If sumad > 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(grilla.Item(1, i).Value.ToString), 2), "0,00.00"), 480, k, 0)
                    End If
                    If sumac > 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(grilla.Item(2, i).Value.ToString), 2), "0,00.00"), 585, k, 0)
                    End If
                End If
            Next
            k = k - 10
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------", 300, k, 0)
            k = k - 10
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(txtdb.Text), 2), "0,00.00"), 480, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(txtcr.Text), 2), "0,00.00"), 585, k, 0)
            k = k - 50
            If k < 50 Then
                cb.EndText()
                oDoc.NewPage()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                k = 700
            End If
            cb.ShowTextAligned(50, "APROBADO:_________________________", 10, k, 0)
            cb.ShowTextAligned(50, "REVISADO:_________________________", 300, k, 0)
            k = k - 25
            cb.ShowTextAligned(10, "Impreso a la fecha y hora: " & Now, 10, k, 0)
            sumad = 0
            sumac = 0
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                ' MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            If oDoc.IsOpen Then
                oDoc.Close()
                GenerarPDF()
                Exit Sub
            End If
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    '*************************************************************
    Private Sub GenerarPDF2()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\documento.pdf"
        Dim i, k As Integer
        Dim sumad, sumac, sumatd, sumatc As Double
        Try
            Dim tablacomp, tabla As New DataTable
            sumatd = 0
            sumatc = 0
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            '***************************
            Refresh()
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            sumad = 0
            sumac = 0
            myCommand.CommandText = "SELECT * FROM documentos00 ORDER BY periodo,dia,tipodoc,doc,item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item("tipodoc").ToString = "__" Then
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM documentos00 ORDER BY codigo,nit;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
            End If
            k = 50
            Dim hoy As String
            hoy = Now.ToString
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item("tipodoc").ToString <> "" Then
                    k = k - 10
                    If k <= 65 Then
                        If i > 0 Then
                            cb.EndText()
                        End If
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        '////////// INICIO BANNER ////////////////
                        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & hoy, 20, 790, 0)
                        cb.ShowTextAligned(50, "REPORTE DE SALDOS INICIALES ", 20, 780, 0)
                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 770, 0)
                        k = 750
                        cb.ShowTextAligned(50, "DOC.", 10, k, 0)
                        cb.ShowTextAligned(50, "DESCRIPCIÓN", 60, k, 0)
                        cb.ShowTextAligned(50, "CUENTA", 240, k, 0)
                        If tabla.Rows(i).Item("tipodoc").ToString <> "__" Then
                            cb.ShowTextAligned(50, "FECHA", 310, k, 0)
                        Else
                            cb.ShowTextAligned(50, "N.I.T. / C.C.", 310, k, 0)
                        End If
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 480, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        k = k - 20
                        '////////// FIN BANNER ///////////////
                    End If
                    Try
                        sumad = CDbl(tabla.Rows(i).Item("debito"))
                    Catch ex As Exception
                        sumad = 0
                    End Try
                    Try
                        sumac = CDbl(tabla.Rows(i).Item("credito"))
                    Catch ex As Exception
                        sumac = 0
                    End Try
                    sumatd = sumatd + sumad
                    sumatc = sumatc + sumac
                    If tabla.Rows(i).Item("tipodoc").ToString <> "__" Then
                        If tabla.Rows(i).Item("doc") < 10 Then
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "000" & tabla.Rows(i).Item("doc").ToString, 10, k, 0)
                        ElseIf tabla.Rows(i).Item("doc") < 100 Then
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "00" & tabla.Rows(i).Item("doc").ToString, 10, k, 0)
                        ElseIf tabla.Rows(i).Item("doc") < 1000 Then
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "0" & tabla.Rows(i).Item("doc").ToString, 10, k, 0)
                        Else
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & tabla.Rows(i).Item("doc").ToString, 10, k, 0)
                        End If
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("periodo").ToString, 310, k, 0)
                    Else
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString, 10, k, 0)
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("nit").ToString, 310, k, 0)
                    End If
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("descri").ToString, 33), 60, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo").ToString, 240, k, 0)
                    If sumad > 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tabla.Rows(i).Item("debito")), 2), "0,00.00"), 480, k, 0)
                    End If
                    If sumac > 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tabla.Rows(i).Item("credito")), 2), "0,00.00"), 585, k, 0)
                    End If
                End If
            Next
            k = k - 10
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------", 300, k, 0)
            k = k - 10
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(50, "TOTALES", 300, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(sumatd, 2), "0,00.00"), 480, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(sumatc, 2), "0,00.00"), 585, k, 0)
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Private Sub cmdbloquear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbloquear.Click
        If pro_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
        resultado = MsgBox("Una vez bloqueada esta Interfaz no podrá crear SALDOS INICIALES, ¿Desea Bloquearla?", MsgBoxStyle.YesNo, "SAE verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.CommandText = "UPDATE bloq_per SET bloqueado='s' WHERE periodo='00';"
            myCommand.ExecuteNonQuery()
            Cerrar()
            MsgBox("La interfaz de saldos iniciales fue bloqueada.   ", MsgBoxStyle.Information, "Verificando")
            cmdbloquear.Enabled = False
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    '*************************************************************
    Private Sub TxtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.LostFocus
        'Try
        '    TxtNumero.Text = NumeroDoc(TxtNumero.Text)
        'Catch ex As Exception
        'End Try
        Try

            Dim tf As New DataTable
            myCommand.CommandText = "SELECT * FROM documentos00 WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            Refresh()

            If tf.Rows.Count = 0 Then
                TxtNumero.Text = NumeroDoc(TxtNumero.Text)
            Else
                MsgBox("El numero del documento ya existe en el sistema", MsgBoxStyle.Information, "Verificacion")
                lbestado.Text = "CONSULTA"
                Bloquear()
                BuscarDocumento("documentos00", TxtNumero.Text, TxtDocumento.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub
    '*************************************************************
    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
            SacarCuenta()
        End If
    End Sub
    Private Sub cmdquitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdquitar.Click
        QuitarFila(fila)
    End Sub
    Private Sub cmdquitar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdquitar.GotFocus
        SendKeys.Send(Chr(Keys.Tab))
    End Sub

    Private Sub cmdImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpuestos.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        SendKeys.Send(Chr(Keys.Space))
        FrmSelConcepImp.lbform.Text = "si"
        FrmSelConcepImp.lbfila.Text = fila
        If fila = grilla.RowCount - 1 Then
            grilla.RowCount = grilla.RowCount + 1
        End If
        FrmSelConcepImp.ShowDialog()
        SacarCuenta()
    End Sub
    Private Sub cmdImpuestos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImpuestos.GotFocus
        SendKeys.Send(Chr(Keys.Tab))
    End Sub
    '*************************************************************
    Public Sub BuscarCC()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentro.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtncentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtncentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentro.Text
                FrmSelCentroCostos.lbform.Text = "conta_si"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '*************************************************************
    Private Sub txtcentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentro.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtcentro, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcentro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentro.LostFocus
        If lbestado.Text <> "NULO" And lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCC()
    End Sub
    '*************************************************************
    Public Sub Bloquear()
        TxtDocumento.Enabled = False
        TxtNumero.Enabled = False
        txtnit.Enabled = False
        txtperiodo.Enabled = False
        txtcentro.Enabled = False
        txtvmto.Enabled = False
        '**********COMANDOS*********
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Public Sub Desbloquear()
        TxtDocumento.Enabled = True
        TxtNumero.Enabled = True
        txtnit.Enabled = True
        txtperiodo.Enabled = True
        txtvmto.Enabled = True
        Dim t As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item("ccosto") = "N" Then
            txtcentro.Enabled = False
        Else
            txtcentro.Enabled = True
        End If
        If txtcentro.Enabled = True Then
            grilla.Columns(8).ReadOnly = False
        Else
            grilla.Columns(8).ReadOnly = True
        End If
        grilla.Columns(6).ReadOnly = True
        '**********COMANDOS*********
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub

    Private Sub txtperiodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtperiodo.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtnit, e)
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Try
            If Trim(txtnit.Text) = "" Then
                FrmSelCliente.lbform.Text = "si_txt"
                FrmSelCliente.lbfila.Text = fila
                FrmSelCliente.ShowDialog()
            Else
                Dim items As Integer
                Dim tabla, tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & Trim(txtnit.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(txtnit.Text)
                        txtnit.Text = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "si_txt"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit...", MsgBoxStyle.Information, "SAE Información")
                        txtnit.Text = ""
                    End If
                Else
                    txtnit.Text = Trim(txtnit.Text)
                    txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
                End If
            End If
            If lbestado.Text = "NUEVO" And txtnit.Text <> "" Then
                Dim fec As Date = CDate(txtperiodo.Text)
                Try
                    grilla.Item(5, 0).Value = Val(txtvmto.Text)
                    grilla.Item(6, 0).Value = fec.AddDays(Val(txtvmto.Text))
                Catch ex As Exception
                    grilla.Item(5, 0).Value = "0"
                    grilla.Item(6, 0).Value = fec
                End Try
                '************************************
                grilla.Focus()
                grilla.Item(0, 0).Selected = True
                If Trim(grilla.Item(0, 0).Value) = "" Then
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                End If
                grilla.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        validarnumero(txtvmto, e)
    End Sub
  
End Class