Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports MySql.Data.MySqlClient

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmEntradaDatos
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
        ValoresDefecto(e.RowIndex)
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
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
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
                    Try
                        Dim fec As Date = CDate(txtdia.Text & txtperiodo.Text)
                        grilla.Item(6, e.RowIndex).Value = fec.AddDays(Val(grilla.Item(5, e.RowIndex).Value))
                    Catch ex As Exception
                    End Try
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
                    'MsgBox("Error al digitar el nit. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
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
                FrmSelCentroCostos.lbform.Text = "conta_ent"
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
        Dim fec As Date
        Try
            fec = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            fec = CDate("01" & txtperiodo.Text)
        End Try
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
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
            If col = 7 And txtcentro.Enabled = False Then
                SendKeys.Send(Chr(Keys.Tab))
            End If
        End If
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "generadoc"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If grilla.Item(3, fila).Value = "" Or nivel_cuenta(grilla.Item(3, fila).Value) = True Then
                    grilla.Item(3, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "generadoc"
                    FrmCuentas.lbfila.Text = fila
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                Else
                    SendKeys.Send(Chr(Keys.Tab))
                    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                    resultado = MsgBox("La cuenta (" & grilla.Item(3, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                    If resultado = MsgBoxResult.Yes Then
                        FrmNuevaCuenta.txtcuenta.Text = grilla.Item(3, fila).Value
                        grilla.Item(3, fila).Value = ""
                        FrmNuevaCuenta.lbfila.Text = fila
                        FrmNuevaCuenta.ShowDialog()
                    Else
                        grilla.Item(3, fila).Value = ""
                    End If
                End If
            Else
                grilla.Item(4, fila).Selected = True
            End If
        End If

    End Sub
    Function nivel_cuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & codigo & "';"
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
    Public Sub BuscarNit(ByVal nit As String, ByVal fila As Integer)
        Try
            If Trim(nit) = "" Then
                FrmSelCliente.lbform.Text = "generadoc"
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
                    resultado = MsgBox("El nit/cédula " & nit & " del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(nit)
                        grilla.Item(7, fila).Value = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "generadoc"
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
    Private Sub CmdCambiarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCambiarPeriodo.Click
        Try
            BuscarPeriodo()
            FrmPeriodo.lbactual.Text = PerActual
            FrmPeriodo.ShowDialog()
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                txtperiodo.Text = "/" & PerActual
                Dim cad As String
                cad = TxtDocumento.Text
                If (cad(0) & cad(1)) = "FC" Then Exit Sub
                Lbper.Text = PerActual
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
            If FrmPrincipal.LbPeriodo.Text = "(ninguno)" Then
                FrmPeriodo.lbactual.Text = PerActual
                FrmPeriodo.ShowDialog()
                If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                    txtperiodo.Text = "/" & PerActual
                    Dim cad As String
                    cad = TxtDocumento.Text
                    If (cad(0) & cad(1)) = "FC" Then Exit Sub
                    Lbper.Text = PerActual
                    Exit Sub
                Else
                    CmdPrimero_Click(AcceptButton, AcceptButton)
                    Exit Sub
                End If
            Else
                BuscarPeriodo()
            End If
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " ORDER BY tipodoc,doc LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                Bloquear()
                TxtNumero.Text = ""
                TxtDocumento.Text = ""
                txtDoc.Text = ""
                txtdia.Text = "00"
                txtdb.Text = ""
                txtcr.Text = ""
                txtdif.Text = ""
                txtcentro.Text = ""
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
                lbnroobs.Text = 0
                lbestado.Text = "NULO"
                txtnit.Text = ""
                txtnombre.Text = ""
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            lbestado.Text = "NULO"
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            grilla.ReadOnly = True
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " ORDER BY tipodoc,doc LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
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
            mes = "documentos" & PerActual(0) & PerActual(1)
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
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                SacarCuenta()
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
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
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
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
            Bloquear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & tab & " WHERE doc=" & doc & " AND tipodoc='" & tipo & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                TxtNumero.Text = NumeroDoc(Val(tabla.Rows(0).Item("doc").ToString))
                TxtDocumento.Text = tabla.Rows(0).Item("tipodoc")
                TxtDocumento.ReadOnly = True
                TxtNumero.ReadOnly = True
                txtdia.Text = tabla.Rows(0).Item("dia")
                lbmodulo.Text = tabla.Rows(0).Item("modulo")
                txtperiodo.Text = "/" & tabla.Rows(0).Item("periodo")
                If tabla.Rows(0).Item("centro") <> "0" Then
                    txtcentro.Text = tabla.Rows(0).Item("centro")
                Else
                    txtcentro.Text = ""
                End If
                txtncentro.Text = BuscarCentroCostos(txtcentro.Text)
                txtvmto.Text = tabla.Rows(0).Item("diasv")
                txtnit.Text = tabla.Rows(0).Item("nit")
                txtnit_LostFocus(AcceptButton, AcceptButton)
                If TxtDocumento.Text = "CA" Then
                    txtDoc.Text = "CIERRE ANUAL"
                Else
                    BuscarTipo()
                End If
                Try
                    grilla.Rows.Clear()
                Catch ex As Exception
                End Try
                grilla.RowCount = tabla.Rows.Count + 1
                Dim fec As Date
                Try
                    fec = CDate(txtdia.Text & txtperiodo.Text)
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                End Try
                For i = 0 To tabla.Rows.Count - 1
                    grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
                    grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
                    grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
                    grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
                    grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
                    grilla.Item(5, i).Value = tabla.Rows(i).Item("diasv")
                    '********************************************************
                    Try
                        grilla.Item(6, i).Value = fec.AddDays(Val(tabla.Rows(i).Item("diasv")))
                    Catch ex As Exception
                        Try
                            grilla.Item(6, i).Value = txtdia.Text & txtperiodo.Text
                        Catch ex2 As Exception
                        End Try
                    End Try

                    'grilla.Item(6, i).Value = tabla.Rows(i).Item("fechaven")
                    grilla.Item(7, i).Value = tabla.Rows(i).Item("nit")
                    Try
                        If tabla.Rows(i).Item("centro") = 0 Then
                            grilla.Item(8, i).Value = ""
                        Else
                            grilla.Item(8, i).Value = tabla.Rows(i).Item("centro")
                        End If
                    Catch ex As Exception
                        grilla.Item(8, i).Value = ""
                    End Try
                    grilla.Item(9, i).Value = tabla.Rows(i).Item("cheque")
                Next

                Dim ta As New DataTable
                myCommand.CommandText = "SELECT * FROM obsdocumentos" & Strings.Right(tab, 2) & " WHERE doc=" & doc & " AND tipodoc='" & tipo & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(ta)
                If ta.Rows.Count > 0 Then
                    txtObserv.Text = ta.Rows(0).Item("comentario")
                Else
                    txtObserv.Text = ""
                End If

            Else
                MsgBox("El documento no se encuentra en este Periodo", MsgBoxStyle.Information, "Verificación")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MesdelPeriodo()
        BuscarPeriodo()
        Dim cadena As String
        cadena = PerActual
        TablaMes = "documentos"
        For x = 0 To cadena.Length - 1
            If cadena.Chars(x) = "/" Then
                Exit For
            Else
                TablaMes = TablaMes & cadena.Chars(x)
            End If
        Next
    End Sub
    '*******************************************************************************
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        Try
            If PerBloq() = False Then Exit Sub
            If lbestado.Text = "NUEVO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tra_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            TxtNumero.Text = ""
            TxtDocumento.Text = ""
            Try
                grilla.Rows.Clear()
            Catch ex As Exception
            End Try
            txtObserv.Text = ""
            txtDoc.Text = ""
            txtdb.Text = "0"
            txtcr.Text = "0"
            txtdif.Text = "0"
            txtnit.Text = ""
            txtnombre.Text = ""
            txtcentro.Text = ""
            txtncentro.Text = ""
            txtvmto.Text = "0"
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE grupo <> 'SI';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("Favor no han creado los tipos de documentos, verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count <= 0 Then
                MsgBox("Favor no han creados cuentas auxiliares, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            FrmTipoTransaccion.lbform.Text = "TODOS"
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
            Desbloquear()
            SacarCuenta()
            lbestado.Text = "NUEVO"
            Try
                txtdia.Text = Today.Day
                Dim fe As Date = CDate(Today.Day.ToString & "/" & PerActual)
            Catch ex As Exception
                txtdia.Text = "01"
            End Try
            lbmodulo.Text = "contabilidad"
            TxtNumero.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdnuevo_rep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnuevo_rep.Click
        Try
            If PerBloq() = False Then Exit Sub
            If lbestado.Text = "NUEVO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tra_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE grupo <> 'SI';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("Favor no han creado los tipos de documentos, verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count <= 0 Then
                MsgBox("Favor no han creados cuentas auxiliares, Verifique.  ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            '***************************************************************
            TxtNumero.Text = ""
            TxtDocumento.Text = ""
            txtDoc.Text = ""
            txtdb.Text = "0"
            txtcr.Text = "0"
            txtdif.Text = "0"
            txtcentro.Text = ""
            txtncentro.Text = ""
            txtvmto.Text = "0"
            Try
                grilla.ReadOnly = False
                grilla.Item(0, 0).Selected = True
                grilla.Item(0, 0).Selected = False
            Catch ex As Exception
            End Try
            Try
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
            Catch ex As Exception

            End Try
            '***************************************************************
            Try
                lbestado.Text = "CONSULTA"
                FrmDocExistente.cbper.Text = PerActual(0) & PerActual(1)
                FrmDocExistente.ShowDialog()
            Catch ex As Exception

            End Try

            If lbestado.Text = "NUEVO" Then
                TxtDocumento.ReadOnly = False
                TxtDocumento.Enabled = True
                TxtNumero.ReadOnly = False
                txtnit_LostFocus(AcceptButton, AcceptButton)
                lbmodulo.Text = "contabilidad"
                SacarCuenta()
                TxtDocumento_LostFocus(AcceptButton, AcceptButton)
                TxtNumero.Focus()
                grilla.ReadOnly = False
                Desbloquear()
                grilla.Item(0, 0).Selected = True
                grilla.Item(0, 0).Selected = False
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
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
                If TxtDocumento.Text = "CA" Then Exit Sub
                If PerBloq() = False Then Exit Sub
                'If lbmodulo.Text <> "contabilidad" Then
                '    MsgBox("El documento no se puede editar porque fué elaborado en el modulo " & lbmodulo.Text & ".  ", MsgBoxStyle.Information, "Verificando")
                '    Exit Sub
                'End If
                If tra_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                grilla.ReadOnly = False
                Desbloquear()
                TxtNumero.ReadOnly = True
                lbestado.Text = "EDITAR"
                grilla.Item(0, 0).Selected = True
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
                If TxtDocumento.Text = "CA" Then Exit Sub
                If lbmodulo.Text <> "contabilidad" Then
                    MsgBox("El documento no se puede eliminar porque fué elaborado en el modulo " & lbmodulo.Text & ".  ", MsgBoxStyle.Information, "Verificando")
                    Exit Sub
                End If
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
            BuscarPeriodo()
            cad = "documentos" & PerActual(0) & PerActual(1)
            FrmVerDocumentos.tcad = "documentos" & PerActual(0) & PerActual(1)
            FrmVerDocumentos.lbform.Text = "doc"
            FrmVerDocumentos.ShowDialog()
            BuscarTipo()
            If TxtNumero.Text <> "" And TxtDocumento.Text <> "" Then
                BuscarDocumento(cad, TxtNumero.Text, TxtDocumento.Text)
                SacarCuenta()
            End If
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
        ElseIf CDec(txtdb.Text) = 0 Then
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
        End If
        Try
            Dim mifec As Date
            mifec = txtdia.Text & txtperiodo.Text
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
            Exit Sub
        End Try
        MesdelPeriodo()
        Dim cad As String
        cad = TxtDocumento.Text
        cad = cad(0) & cad(1)
        MiConexion(bda)
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
            ElseIf CDbl(grilla.Item(1, i).Value) = 0 And CDbl(grilla.Item(2, i).Value) = 0 Then
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
        Dim cad2 As String
        If lbestado.Text = "NUEVO" Then
            '**************MIRAR SI EXIXTE***********************
            ValidarConsecutivo()

            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & TablaMes & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                MsgBox("Ya existe el documento, Verifique su número o consecutivo.  ", MsgBoxStyle.Information, "SAE Verificación")
                TxtNumero.Focus()
                Exit Sub
            End If
        Else
            '******************ELIMINAR LOS EXIXTENTES (PARA REMPLAZAR (MODIFICAR))******************************+
            cad2 = PerActual(0) & PerActual(1)
            ModificarCuentas("saldo" & cad2, "debito" & cad2, "credito" & cad2)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM " & TablaMes & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & cad & "';"
            myCommand.ExecuteNonQuery()
        End If
        '************GUARDAR *********************
        For i = 0 To grilla.RowCount - 2
            Guardar(cad, i)
        Next
        cad2 = PerActual(0) & PerActual(1)
        ActualizarCuentas("saldo" & cad2, "debito" & cad2, "credito" & cad2)
        '****************** ACTUALIZAR CONSECUTIVO **********************
        If lbestado.Text = "NUEVO" Then
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", cad)
            If cad = "FC" Then
                myCommand.CommandText = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            Else
                myCommand.CommandText = "Update tipdoc set actual" & cad2 & "=?actual WHERE tipodoc=?tipodoc AND actual" & cad2 & "<?actual;"
            End If
            myCommand.ExecuteNonQuery()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("CONTABILIDAD", "GUARDAR DOC Nº: " & TxtDocumento.Text & TxtNumero.Text & "-" & Lbper.Text, "", "", "")
            End If
            '.....
            lbestado.Text = "GUARDADO"
        Else
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("CONTABILIDAD", "EDITAR DOC Nº: " & TxtDocumento.Text & TxtNumero.Text & "-" & Lbper.Text, "", "", "")
            End If
            '.....
            lbestado.Text = "EDITADO"
        End If
        ' Guardar Observacion
        If Trim(txtObserv.Text) <> "" Then
            GuardarObser(cad2, cad, TxtNumero.Text.ToString)
        End If

        Bloquear()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        grilla.ReadOnly = True
        Cerrar()
    End Sub
    Private Sub GuardarObser(ByVal per As String, ByVal tip As String, ByVal num As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "delete from obsdocumentos" & per & " WHERE tipodoc='" & tip & "' AND doc=" & num & ";"
            myCommand.ExecuteNonQuery()
            Refresh()
        Catch ex As Exception
            'MsgBox("Error al eliminar obs" & ex.ToString)
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO obsdocumentos" & per & " VALUES(" & num & ", '" & tip & "', '" & txtObserv.Text & "');"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Error al insertar obs" & ex.ToString)
        End Try

       
    End Sub
    Private Sub ValidarConsecutivo()
        Dim t As New DataTable
        t.Clear()
        myCommand.CommandText = "SELECT grupo FROM  tipdoc WHERE tipodoc ='" & TxtDocumento.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        Refresh()

        Dim cons As String = ""
        If t.Rows(0).Item(0) = "FC" Or t.Rows(0).Item(0) = "FP" Then
            '....
            Dim p As String = ""
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If i <> 12 Then
                    cons = cons & "SELECT * FROM documentos" & p & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' UNION "
                Else
                    cons = cons & "SELECT * FROM documentos" & p & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' "
                End If
            Next
        Else
            cons = "SELECT * FROM documentos" & Strings.Left(PerActual, 2) & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' "
        End If

        Dim tf As New DataTable
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tf)
        Refresh()
        If tf.Rows.Count > 0 Then
            TxtNumero.Text = NumeroDoc(Val(TxtNumero.Text) + 1)
        End If

    End Sub
    Public Sub Guardar(ByVal tipo As String, ByVal fila As Integer)
        Dim fecha As Date = CDate(txtdia.Text & txtperiodo.Text)
        Dim diasv
        Try
            If grilla.Item(5, fila).Value = "0" Then
                fecha = CDate(txtdia.Text & txtperiodo.Text)
            Else
                fecha = fecha.AddDays(Val(grilla.Item(5, fila).Value))
            End If
        Catch ex As Exception
            fecha = "(NINGUNA)"
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
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
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
        myCommand.CommandText = "INSERT INTO " & TablaMes & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
    End Sub
    Public Sub ActualizarCuentas(ByVal saldo As String, ByVal debito As String, ByVal credito As String)
        Dim sql As String
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
            sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
                & debito & "=" & debito & " + " & DIN(db) & ", " _
                & credito & "=" & credito & " + " & DIN(cb) & " " _
                & "WHERE codigo='" & grilla.Item(3, i).Value & "';"
            Ejecutar(sql)
        Next
    End Sub
    Public Sub ModificarCuentas(ByVal saldo As String, ByVal debito As String, ByVal credito As String)
        Dim sql As String
        Dim tabla As New DataTable
        Dim suma, db, cb As Double
        myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & Trim(TxtDocumento.Text) & "';"
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
            sql = "UPDATE selpuc SET saldo=saldo - " & DIN(suma) & ", " & saldo & "=" & saldo & " - " & DIN(suma) & ", " _
                & debito & "=" & debito & " - " & DIN(db) & ", " _
                & credito & "=" & credito & " - " & DIN(cb) & " " _
                & "WHERE codigo='" & tabla.Rows(i).Item("codigo").ToString & "';"
            Ejecutar(sql)
        Next
    End Sub
    Public Sub Ejecutar(ByVal sql As String)
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    '*************************************************************
    Public Sub Eliminar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El documento " & TxtDocumento.Text & TxtNumero.Text & " se va a eliminar, ¿Desea Borrarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            BuscarPeriodo()
            Dim Sql, tabla As String
            tabla = "documentos" & PerActual(0) & PerActual(1)
            Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & TxtDocumento.Text & "' AND modulo='contabilidad';"
            Ejecutar(Sql)
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("CONTABILIDAD", "ELIMINAR DOC Nº: " & TxtDocumento.Text & TxtNumero.Text & "-" & Lbper.Text, "", "", "")
            End If
            '.....
            MsgBox("El Registro " & TxtDocumento.Text & TxtNumero.Text & " fué eliminado correctamente.", MsgBoxStyle.Information, "SAE Borrar")
            Cerrar()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    '*************************************************************
    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" Then
                txtdia.Focus()
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
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                validarnumero(txtdia, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        Try
            Dim mifec As Date
            mifec = txtdia.Text & txtperiodo.Text
            'MsgBox(mifec)
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
        End Try
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
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "' AND grupo<>'SI' ORDER BY tipodoc;"
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
                If tabla.Rows(0).Item("grupo") = "FC" Then
                    Lbper.Text = TxtDocumento.Text
                Else
                    BuscarPeriodo()
                    Lbper.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "-" & PerActual(0) & PerActual(1) & "- "
                End If
                txtDoc.Text = tabla.Rows(0).Item(2)
                If lbestado.Text = "NUEVO" Then
                    BuscarPeriodo()
                    txtdia.Text = "01"
                    txtperiodo.Text = "/" & PerActual
                    Dim tabla2 As New DataTable
                    If tabla.Rows(0).Item("grupo") = "FC" Then
                        myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla2)
                        TxtNumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(0).ToString) + 1)
                    Else
                        Dim cad As String
                        cad = "actual" & PerActual(0) & PerActual(1)
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
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else

            If i1.Checked = True Then
                GenerarPDF()
            Else
                Try
                    GeneralPDF2()
                Catch ex As Exception
                    MsgBox("Error al Generar el informe", MsgBoxStyle.Information, "SAE")
                End Try
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
            Dim tgru As New DataTable
            myCommand.CommandText = "SELECT grupo FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tgru)
            Dim tablacomp As New DataTable
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
            cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "FECHA: " & txtdia.Text & txtperiodo.Text, 20, 790, 0)
            cb.ShowTextAligned(50, "TIPO DOCUMENTO: " & txtDoc.Text, 20, 780, 0)
            Try
                If tgru.Rows(0).Item("grupo") = "FC" Then
                    cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
                Else
                    cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & PerActual & " - " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
                End If
            Catch ex As Exception
                cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & PerActual & " - " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
            End Try
            cb.ShowTextAligned(50, "TERCERO: " & txtnit.Text & " " & txtnombre.Text, 20, 760, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
            k = 710
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
                    If k <= 45 Then
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        cb.ShowTextAligned(50, UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "FECHA: " & txtdia.Text & txtperiodo.Text, 20, 790, 0)
                        cb.ShowTextAligned(50, "TIPO DOCUMENTO: " & txtDoc.Text, 20, 780, 0)
                        Try
                            If tgru.Rows(0).Item("grupo") = "FC" Then
                                cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
                            Else
                                cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & PerActual & " - " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
                            End If
                        Catch ex As Exception
                            cb.ShowTextAligned(50, "NÚMERO DOCUMENTO: " & PerActual & " - " & TxtDocumento.Text & TxtNumero.Text, 20, 770, 0)
                        End Try

                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 760, 0)
                        k = 740
                        cb.ShowTextAligned(50, "DESCRIPCIÓN", 10, k, 0)
                        cb.ShowTextAligned(50, "CUENTA", 220, k, 0)
                        cb.ShowTextAligned(50, "N.I.T.", 310, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 480, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
                        k = k - 12
                        sumad = 0
                        sumac = 0
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                    End If
                    sumad = CDbl(grilla.Item(1, i).Value.ToString)
                    sumac = CDbl(grilla.Item(2, i).Value.ToString)
                    sumasaldo = sumasaldo + sumad - sumac
                    cb.ShowTextAligned(50, CambiaCadena(grilla.Item(0, i).Value.ToString, 38), 10, k, 0)
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtdb.Text), 480, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtcr.Text), 585, k, 0)
            k = k - 50
            If k < 50 Then
                cb.EndText()
                oDoc.NewPage()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                k = 700
            End If
            If Trim(txtObserv.Text) <> "" Then
                Dim texto As String = txtObserv.Text
                'cb.ShowTextAligned(50, "OBSERVACION: " & SaltarCadena(txtObserv.Text, 20), 10, k, 0)
                If (texto.Length() <= 60) Then
                    cb.ShowTextAligned(50, "OBSERVACION: " & txtObserv.Text, 10, k, 0)
                    k = k - 30
                Else
                    '{ 
                    Dim aux As String = texto
                    While (aux.Length() > 100)
                        cb.ShowTextAligned(50, Strings.Mid(aux, 1, 100), 10, k, 0)
                        k = k - 7
                        aux = Strings.Mid(aux, 101, aux.Length())
                    End While
                    'k = k - 7
                    cb.ShowTextAligned(50, aux, 10, k, 0)
                    k = k - 30
                End If

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
            MsgBox("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    '*************************************************************
    Private Sub TxtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.LostFocus

        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT grupo FROM  tipdoc WHERE tipodoc ='" & TxtDocumento.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()

            Dim cons As String = ""
            If t.Rows(0).Item(0) = "FC" Or t.Rows(0).Item(0) = "FP" Then
                '....
                Dim p As String = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If i <> 12 Then
                        cons = cons & "SELECT * FROM documentos" & p & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM documentos" & p & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' "
                    End If
                Next
            Else
                cons = "SELECT * FROM documentos" & Strings.Left(PerActual, 2) & " WHERE  tipodoc='" & TxtDocumento.Text & "' AND doc='" & TxtNumero.Text & "' "
            End If

            Dim tf As New DataTable
            myCommand.CommandText = cons
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            Refresh()
            If tf.Rows.Count = 0 Then
                TxtNumero.Text = NumeroDoc(TxtNumero.Text)
            Else
                MsgBox("El numero del documento ya existe en el sistema", MsgBoxStyle.Information, "Verificacion")
                lbestado.Text = "CONSULTA"
                Bloquear()
                BuscarDocumento("documentos" & PerActual(0) & PerActual(1), TxtNumero.Text, TxtDocumento.Text)
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
    '*************************************************************
    Private Sub cmdImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImpuestos.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        SendKeys.Send(Chr(Keys.Space))
        FrmSelConcepImp.lbform.Text = "generar"
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
                FrmSelCentroCostos.lbform.Text = "conta_ent"
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
        txtObserv.Enabled = False
        TxtDocumento.Enabled = False
        TxtNumero.Enabled = False
        txtdia.Enabled = False
        txtnit.Enabled = False
        txtcentro.Enabled = False
        txtvmto.Enabled = False
        '**********COMANDOS*********
        CmdNuevo.Enabled = True
        cmdnuevo_rep.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Public Sub Desbloquear()
        txtObserv.Enabled = True
        TxtDocumento.Enabled = True
        TxtNumero.Enabled = True
        txtdia.Enabled = True
        txtnit.Enabled = True
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
        grilla.Columns(6).ReadOnly = True 'FECHA DE VENCIMIENTO
        '**********COMANDOS*********
        CmdNuevo.Enabled = False
        cmdnuevo_rep.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    '*************************************************************
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
                FrmSelCliente.lbform.Text = "generadoc_txt"
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
                        frmterceros.lbform.Text = "generadoc_txt"
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
                Dim fec As Date = CDate(txtdia.Text & txtperiodo.Text)
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
    '*************************************************************   

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged

    End Sub

    Private Sub txtdia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdia.TextChanged

    End Sub

    Private Sub GeneralPDF2()
        'Dim tp As String = ""
        'Dim p As String = ""
        'Dim sql As String = ""
        'Dim nom As String = ""
        'Dim nit As String = ""
        'Dim des As String = ""

        'If chddes.Checked = True Then
        '    des = "des"
        'End If

        'MiConexion(bda)
        'Cerrar()


        'Dim tabla2 As New DataTable
        'tabla2 = New DataTable
        'myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla2)
        'nom = tabla2.Rows(0).Item("descripcion")
        'nit = "NIT : " & tabla2.Rows(0).Item("nit")

        'Dim conexion As New MySqlConnection
        'Dim cadena As String
        'cadena = datosconR(bda)
        'conexion.ConnectionString = cadena
        'conexion.Open()

        'Dim desc As String = ""
        'If i2.Checked = True Then
        '    tp = "and d.tipodoc='" & TxtDocumento.Text & "'"
        '    desc = "(SELECT (SUM(debito)-SUM(credito)) FROM documentos" & p & " WHERE CAST(CONCAT(d.tipodoc, LPAD(d.doc, 7, '0')) AS CHAR(10)) = CAST(CONCAT(tipodoc, LPAD(doc, 7, '0')) AS CHAR(10))) AS base "
        'Else
        '    desc = "0 as base "
        'End If

        'For i = 1 To CInt(Strings.Left(PerActual, 2))
        '    If i < 10 Then
        '        p = "0" & i
        '    Else
        '        p = i
        '    End If

        '    If p <> CInt(Strings.Left(PerActual, 2)) Then

        '        '... doc desaprob
        '        If i2.Checked = True Then
        '            desc = "(SELECT (SUM(debito)-SUM(credito)) FROM documentos" & p & " WHERE CAST(CONCAT(d.tipodoc, LPAD(d.doc, 7, '0')) AS CHAR(10)) = CAST(CONCAT(tipodoc, LPAD(doc, 7, '0')) AS CHAR(10))) AS base "
        '        Else
        '            desc = "0 as base "
        '        End If
        '        '........

        '        sql = sql & "SELECT d.tipodoc , td.descripcion as centro, d.item,CAST(CONCAT(d.tipodoc, LPAD(d.doc,7,'0')) AS CHAR(10)) AS periodo, d.descri, " _
        '        & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo, " _
        '        & "  " & desc & " " _
        '        & " FROM documentos" & p & " d, tipdoc td " _
        '        & " WHERE td.tipodoc = d.tipodoc " & tp & " UNION "
        '    Else

        '        '... doc desaprob
        '        If i2.Checked = True Then
        '            desc = "(SELECT (SUM(debito)-SUM(credito)) FROM documentos" & p & " WHERE CAST(CONCAT(d.tipodoc, LPAD(d.doc, 7, '0')) AS CHAR(10)) = CAST(CONCAT(tipodoc, LPAD(doc, 7, '0')) AS CHAR(10))) AS base "
        '        Else
        '            desc = "0 as base "
        '        End If
        '        '........

        '        sql = sql & "SELECT d.tipodoc, td.descripcion as centro, d.item,CAST(CONCAT(d.tipodoc, LPAD(d.doc,7,'0')) AS CHAR(10)) AS periodo, d.descri, " _
        '        & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo, " _
        '        & " " & desc & " " _
        '        & " FROM documentos" & p & " d, tipdoc td " _
        '        & " WHERE td.tipodoc = d.tipodoc " & tp & " "
        '    End If
        'Next
        'sql = sql & " ORDER BY tipodoc, periodo, item"

        'TextBox1.Text = sql

        'Dim tabla As New DataTable
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = sql
        'myCommand.Connection = conexion
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)

        'Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        'CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContDoc.rpt")
        'CrReport.SetDataSource(tabla)
        'Try
        '    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        'Catch ex As Exception
        'End Try
        'FrmReportCertR.CrystalReportViewer1.ReportSource = CrReport

        'Try
        '    Dim Prcompañia As New ParameterField
        '    Dim PrNit As New ParameterField
        '    Dim Prdd As New ParameterField

        '    Dim prmdatos As ParameterFields
        '    prmdatos = New ParameterFields

        '    Prcompañia.Name = "comp"
        '    Prcompañia.CurrentValues.AddValue(nom.ToString)

        '    PrNit.Name = "nit"
        '    PrNit.CurrentValues.AddValue(nit.ToString)

        '    Prdd.Name = "ddes"
        '    Prdd.CurrentValues.AddValue(des.ToString)

        '    prmdatos.Add(Prcompañia)
        '    prmdatos.Add(PrNit)
        '    prmdatos.Add(Prdd)

        '    FrmReportCertR.CrystalReportViewer1.ParameterFieldInfo = prmdatos
        '    FrmReportCertR.ShowDialog()

        'Catch ex As Exception
        'End Try


        Dim tp As String = ""
        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim des As String = ""

        If chddes.Checked = True Then
            des = "des"
        End If

        MiConexion(bda)
        Cerrar()

        If i2.Checked = True Then
            tp = " and d.tipodoc='" & TxtDocumento.Text & "'"
        End If
        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT : " & tabla2.Rows(0).Item("nit")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim desc As String = ""
        'If i2.Checked = True Then
        '    tp = "and d.tipodoc='" & TxtDocumento.Text & "'"
        '    desc = "(SELECT (SUM(debito)-SUM(credito)) FROM documentos" & p & " WHERE CAST(CONCAT(d.tipodoc, LPAD(d.doc, 7, '0')) AS CHAR(10)) = CAST(CONCAT(tipodoc, LPAD(doc, 7, '0')) AS CHAR(10))) AS base "
        'Else
        desc = "0 as base "
        'End If

        'sql = "select item, tipodoc, centro, "
        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            ' CAST(CONCAT(d.tipodoc, LPAD(d.doc,7,'0')) AS CHAR(10)) AS periodo
            If p <> CInt(Strings.Left(PerActual, 2)) Then
                sql = sql & "SELECT  concat(d.tipodoc," & p & ")tipodoc , td.descripcion as centro, d.item, CAST(concat(d.tipodoc,d.doc)AS CHAR(20)) as periodo, d.descri, " _
                & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo, concat(t.nombre,' ', t.apellidos) as cheque, " _
                & "  " & desc & " " _
                & " FROM documentos" & p & " d, tipdoc td, terceros t " _
                & " WHERE td.tipodoc = d.tipodoc " & tp & " and t.nit= d.nit UNION "
            Else
                sql = sql & "SELECT  concat(d.tipodoc," & p & ")tipodoc, td.descripcion as centro, d.item,CAST(concat(d.tipodoc,d.doc)AS CHAR(20)) as periodo, d.descri, " _
                & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo,  concat(t.nombre,' ', t.apellidos) as cheque,  " _
                & " " & desc & " " _
                & " FROM documentos" & p & " d, tipdoc td, terceros t " _
                & " WHERE td.tipodoc = d.tipodoc " & tp & "  and t.nit= d.nit"
            End If
        Next
        sql = sql & " ORDER BY tipodoc, periodo, item"

        TextBox1.Text = sql

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContDoc.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        FrmReportCertR.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prdd As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prdd.Name = "ddes"
            Prdd.CurrentValues.AddValue(des.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prdd)

            FrmReportCertR.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCertR.ShowDialog()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCero.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("El documento " & TxtDocumento.Text & TxtNumero.Text & " será anulado, ¿Desea anularlo?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    lbestado.Text = "EDITAR"
                    ValoresCero()
                End If
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ValoresCero()
        MiConexion(bda)
        Try
            Dim sql As String
            Dim tabla As New DataTable
            Dim suma, db, cb As Double
            Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
            Dim debito As String = "debito" & PerActual(0) & PerActual(1)
            Dim credito As String = "credito" & PerActual(0) & PerActual(1)
            myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & Trim(TxtDocumento.Text) & "';"
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
                sql = "UPDATE selpuc SET saldo=saldo - " & DIN(suma) & ", " & saldo & "=" & saldo & " - " & DIN(suma) & ", " _
                    & debito & "=" & debito & " - " & DIN(db) & ", " _
                    & credito & "=" & credito & " - " & DIN(cb) & " " _
                    & "WHERE codigo='" & tabla.Rows(i).Item("codigo").ToString & "';"
                Ejecutar(sql)
            Next
            sql = "UPDATE documentos" & PerActual(0) & PerActual(1) & " SET debito=0, credito=0, base=0 " _
                & "WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & Trim(TxtDocumento.Text) & "';"
            Ejecutar(sql)
            For i = 0 To grilla.RowCount - 1
                grilla.Item("Debitos", i).Value = Moneda("0")
                grilla.Item("Creditos", i).Value = Moneda("0")
                grilla.Item("Base", i).Value = Moneda("0")
            Next
            lbestado.Text = "EDITADO"
            Bloquear()
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub

    Private Sub cmdCero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCero.GotFocus
        Try
            SendKeys.Send("{TAB}")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub i3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles i3.CheckedChanged
        If i3.Checked = True Then
            chddes.Checked = False
        End If
    End Sub

    Private Sub chddes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chddes.CheckedChanged
        If i3.Checked = True Then
            chddes.Checked = False
        End If
    End Sub

    Private Sub TxtDocumento_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDocumento.MarginChanged

    End Sub

    Private Sub TxtDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDocumento.TextChanged

    End Sub

  
End Class