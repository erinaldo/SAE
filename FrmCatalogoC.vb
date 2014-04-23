Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmCatalogoC
    Public sumadb, sumacr, sumasaldo As Double
    Public n, n1, n2, n3, n4, n5 As Integer
    Private Sub FrmSeleccionPuc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmSeleccionPuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    'RECORRER CUENTAS 
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            grilla.RowCount = 12
            Meses()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codigo FROM selpuc ORDER BY codigo LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarCuenta(tabla.Rows(0).Item("codigo"))
            lbnroobs.Text = 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            MsgBox(ex.ToString)
            lbaux.Visible = False
            PonerEnCero()
            txtcuenta.Text = ""
            txtdesc.Text = ""
            lbestado.Text = "NULO"
            txtnat.Text = ""
            lbnroobs.Text = 0
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT codigo FROM selpuc ORDER BY codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarCuenta(tabla.Rows(0).Item("codigo"))
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            PonerEnCero()
            lbestado.Text = "NULO"
            lbnroobs.Text = 0
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM selpuc"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT codigo FROM selpuc ORDER BY codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarCuenta(tabla.Rows(0).Item("codigo"))
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerEnCero()
            lbestado.Text = "NULO"
            lbnroobs.Text = 0
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM selpuc"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT codigo FROM selpuc ORDER BY codigo LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarCuenta(tabla.Rows(0).Item("codigo"))
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            PonerEnCero()
            lbestado.Text = "NULO"
            lbnroobs.Text = 0
        End Try
    End Sub
    Public Sub BuscarCuenta(ByVal cuenta As String)
        lbaux.Visible = False
        txtcuenta.MaxLength = 12
        Dim tabla, tsaldo As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        grilla.ReadOnly = True
        txtcuenta.ReadOnly = True
        txtdesc.ReadOnly = True
        txtcuenta.Text = tabla.Rows(0).Item("codigo")
        txtdesc.Text = tabla.Rows(0).Item("descripcion")
        txtsaldo.Text = Moneda(tabla.Rows(0).Item("saldo"))
        cbnivel.Text = tabla.Rows(0).Item("nivel")
        txtnat.Text = tabla.Rows(0).Item("naturaleza")
        cbtipo.Text = tabla.Rows(0).Item("tipo")
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
        txtsaldo.Text = Moneda(total)
        BuscarEstNat()
    End Sub
    Public Sub BuscarEstNat()
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
    End Sub
    Public Sub Meses()
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
    End Sub
    Public Sub PonerEnCero()
        For i = 0 To 11
            grilla.Item(1, i).Value = "0,00"
            grilla.Item(2, i).Value = ""
            grilla.Item(3, i).Value = "0,00"
            grilla.Item(4, i).Value = "0,00"
            grilla.Item(5, i).Value = "0,00"
            grilla.Item(6, i).Value = ""
        Next
    End Sub

    'COMANDOS DEL FORMULARIO
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If lbestado.Text <> "NUEVO" Then
            If bas_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            Meses()
            PonerEnCero()
            lbaux.Visible = False
            txtcuenta.Text = ""
            txtdesc.Text = ""
            txtsaldo.Text = "0,00"
            cbnivel.Text = "Ninguno"
            cbtipo.Text = "Ninguno"
            txtnat.Text = ""
            txtcuenta.ReadOnly = False
            txtdesc.ReadOnly = False
            lbestado.Text = "NUEVO"
            PonerEnCero()
            BuscarNiveles()
            txtcuenta.Focus()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
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
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If bas_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                txtcuenta.ReadOnly = False
                txtdesc.ReadOnly = False
                lbestado.Text = "EDITAR"
                txtcuenta.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If bas_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            Eliminar()
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            FrmVerCuentas.lbform.Text = "doc"
            FrmVerCuentas.gitems.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                FrmVerCuentas.gitems.Item(0, i).Value = ""
                FrmVerCuentas.gitems.Item(1, i).Value = tabla.Rows(i).Item("codigo")
                FrmVerCuentas.gitems.Item(2, i).Value = tabla.Rows(i).Item("descripcion")
                FrmVerCuentas.gitems.Item(3, i).Value = tabla.Rows(i).Item("nivel")
                FrmVerCuentas.gitems.Item(4, i).Value = tabla.Rows(i).Item("tipo")
                FrmVerCuentas.gitems.Item(5, i).Value = tabla.Rows(i).Item("saldo")
            Next
            FrmVerCuentas.ShowDialog()
            If lbestado.Text = "CONSULTA" Then
                BuscarCuenta(txtcuenta.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Private Sub cmdactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactualizar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            mibarra.Visible = True
            mibarra.Value = 5
            ActualizarCatalogo()
            mibarra.Value = 100
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Catch ex As Exception
            MsgBox("ERROR AL MOMENTO DE ACTUALIZAR CATALOGO DE CUENTAS:  " & ex.ToString, MsgBoxStyle.Critical, "SAE Control de Errores")
            mibarra.Value = 0
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub

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

    '***************** INICIO ACTUALIZAR CATALOGO CUENTA *******************************
    Public Sub ActualizarCatalogo()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        Dim tabla As New DataTable
        Dim barra, baraux As Double
        myCommand.CommandText = "SELECT codigo,saldo00 FROM selpuc WHERE nivel='Auxiliar' ORDER BY codigo desc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        barra = 100 / tabla.Rows.Count
        ' MsgBox(barra)
        For i = 0 To tabla.Rows.Count - 1
            CalcularSaldo(tabla.Rows(i).Item("codigo"))
            For j = 0 To 12
                If j < 10 Then
                    Calcular("0" & j, tabla.Rows(i).Item("codigo"))
                Else
                    Calcular(j, tabla.Rows(i).Item("codigo"))
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
            If mibarra.Value + barra < 98 Then
                baraux = baraux + barra
                If baraux >= 1 Then
                    mibarra.Value = mibarra.Value + baraux
                    baraux = 0
                End If
            Else
                mibarra.Value = 95
            End If
        Next
        mibarra.Value = 100
        mibarra.Visible = False
        Me.Cursor = Cursors.Default
        Cerrar()
    End Sub
    Public Sub CalcularSaldo(ByVal micuenta As String)
        Dim tabla As New DataTable
        '///////////CALCULAR SALDO INICIAL //////////////////////
        myCommand.CommandText = "SELECT sum(saldo00) FROM selpuc WHERE codigo like '" & micuenta & "%' and nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumasaldo = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumasaldo = 0
        End Try
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        '/////////////ACTUALIZAR SALDO INICIAL///////////////////
        myCommand.CommandText = "UPDATE selpuc SET saldo00=?sal WHERE codigo='" & micuenta & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Calcular(ByVal mitabla As String, ByVal cuenta As String)
        If mitabla = "00" Then
            sumasaldo = 0
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT sum(debito),sum(credito) FROM documentos" & mitabla & " WHERE codigo like '" & cuenta & "%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            sumadb = tabla.Rows(0).Item(0)
        Catch ex As Exception
            sumadb = 0
        End Try
        Try
            sumacr = tabla.Rows(0).Item(1)
        Catch ex As Exception
            sumacr = 0
        End Try
        sumasaldo = sumasaldo + (sumadb - sumacr)
        '**********************************************
        ActualizarSelPuc(cuenta, "debito" & mitabla, "credito" & mitabla, "saldo" & mitabla)
    End Sub
    Public Sub ActualizarSelPuc(ByVal cuenta As String, ByVal db As String, ByVal cr As String, ByVal sa As String)
        myCommand.Parameters.Clear()
        Try
            myCommand.Parameters.AddWithValue("?dbto", CDbl(sumadb))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?dbto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?crto", CDbl(sumacr))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?crto", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?sal", CDbl(sumasaldo))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?sal", "0")
        End Try
        Try
            myCommand.CommandText = "UPDATE selpuc SET " & db & "=?dbto," & cr & "=?crto," & sa & "=?sal " _
                              & " WHERE codigo='" & cuenta & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '*****************  FIN ACTUALIZAR CATALOGO  ***************************************

    'BUSCAR NIVELES DE LAS CUENTAS
    Public Sub BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            n = Val(tabla.Rows(0).Item("longitud"))
            n1 = Val(tabla.Rows(0).Item("nivel1"))
            n2 = Val(tabla.Rows(0).Item("nivel2"))
            n3 = Val(tabla.Rows(0).Item("nivel3"))
            n4 = Val(tabla.Rows(0).Item("nivel4"))
            n5 = Val(tabla.Rows(0).Item("nivel5"))
            txtcuenta.MaxLength = n
        Catch ex As Exception
            MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
            Me.Close()
        End Try
    End Sub

    'DIGITANDO LA CUENTA
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        lbaux.Visible = False
        Select Case e.KeyChar
            Case "0" To "9", Chr(8), Chr(13)
            Case Else
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcuenta.KeyUp
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        LongitudCuenta()
    End Sub
    Function LongitudCuenta()
        BuscarNiveles()
        lbaux.Visible = False
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If Val(txtcuenta.Text.Length) = n1 Then
                cbnivel.Text = "Clase"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2) Then
                cbnivel.Text = "Grupo"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2 + n3) Then
                cbnivel.Text = "Cuenta"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2 + n3 + n4) Then
                cbnivel.Text = "Sub Cuenta"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = n Then
                cbnivel.Text = "Auxiliar"
                Return BCuenta()
            Else
                cbnivel.Text = "Ninguno"
                Return False
            End If
        Else
            Return False
            Exit Function
        End If
    End Function
    Function BCuenta()
        lbaux.Visible = False
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdesc.Text = tabla.Rows(0).Item("descripcion")
            txtnat.Text = tabla.Rows(0).Item("naturaleza")
            cbtipo.Text = tabla.Rows(0).Item("tipo")
            If cbnivel.Text = "Auxiliar" And lbestado.Text = "NUEVO" Then
                lbaux.Visible = True
            End If
            Return False
        Else
            If cbnivel.Text = "Clase" Then
                MsgBox("La clase ( " & txtcuenta.Text & " ) No exixte por favor verifique. ", MsgBoxStyle.Information, "SAE verificación")
                txtcuenta.Text = ""
                txtdesc.Text = ""
                txtsaldo.Text = "0,00"
                cbnivel.Text = "Ninguno"
                cbtipo.Text = "Ninguno"
                txtnat.Text = ""
                Return False
            Else
                txtsaldo.Text = "0,00"
                Return True
            End If
        End If
    End Function

    '/////////// GUARDAR Y MODIFICAR //////////////////////////////
    Public Sub ValidarGuardar()
        BuscarNiveles()
        If cbnivel.Text = "Ninguno" Then
            MsgBox("La cuenta ( " & txtcuenta.Text & " ) NO pertenece a ningún nivel, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            txtcuenta.Focus()
            Exit Sub
        ElseIf txtdesc.Text = "" Then
            MsgBox("Favor digite la descripción de la cuenta, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            txtdesc.Focus()
            Exit Sub
        ElseIf BuscarNivelesAnt() = False Then
            txtcuenta.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Function BuscarNivelesAnt()
        BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 And lbestado.Text = "NUEVO" Then
            MsgBox("La cuenta ( " & txtcuenta.Text & " ) YA se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            Return False
        Else
            Return VerificarNiveles()
        End If
    End Function
    Function VerificarNiveles()
        BuscarNiveles()
        Dim cad, cad2 As String
        cad2 = Trim(txtcuenta.Text)
        '*************** NIVEL 1 ***********************
        cad = ""
        If n1 < cad2.Length Then
            For i = 0 To n1 - 1
                cad = cad & cad2(i)
            Next
            Dim tablan1 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan1)
            If tablan1.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Clase ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 2 ***********************
        cad = ""
        If (n1 + n2) < cad2.Length Then
            For i = 0 To (n1 + n2 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan2 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan2)
            If tablan2.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El Grupo ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 3 ***********************
        cad = ""
        If (n1 + n2 + n3) < cad2.Length Then
            For i = 0 To (n1 + n2 + n3 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan3 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan3)
            If tablan3.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Cuenta ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 4 ***********************
        cad = ""
        If (n1 + n2 + n3 + n4) < cad2.Length Then
            For i = 0 To (n1 + n2 + n3 + n4 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan4 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan4)
            If tablan4.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Sub Cuenta ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** TODO BIEN (HAY TODOS LOS NIVELES) *************************
        Return True
    End Function
    Public Sub Guardar()
        '....Validar cta no tenga auxiliar
        Dim ok As String = ""
        'If cbnivel.Text = "Auxiliar" Then
        '    Dim t4 As New DataTable
        '    myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo LIKE  '" & Strings.Left(txtcuenta.Text, 6) & "%'  AND nivel='Auxiliar' ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(t4)
        '    If t4.Rows.Count > 0 Then ok = "dato"
        'End If
        'If ok <> "" Then
        '    MsgBox("No puede crear esta cuenta como Auxiliar ", MsgBoxStyle.Information, "SAE")
        '    Exit Sub
        'End If
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codigo", Trim(txtcuenta.Text.ToString))
        myCommand.Parameters.AddWithValue("?descripcion", txtdesc.Text.ToString)
        myCommand.Parameters.AddWithValue("?naturaleza", txtnat.Text.ToString)
        myCommand.Parameters.AddWithValue("?nivel", cbnivel.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
        myCommand.CommandText = "INSERT INTO selpuc VALUES (?codigo,?descripcion,?naturaleza,?nivel,?tipo,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
        lbestado.Text = "GUARDADO"
        Cerrar()

        Try
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                '........
                Guar_MovUser("CONTABILIDAD", "CATALOGO DE CUENTAS. NUEVA CUENTA COD " & txtcuenta.Text, "", "", "")
                '.............
            End If
        Catch ex As Exception
            MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")

        txtcuenta.ReadOnly = True
        txtdesc.ReadOnly = True
        lbaux.Visible = False
    End Sub
    Private Sub AudiModificar()

        Dim tc As New DataTable
        myCommand.CommandText = "SELECT descripcion from selpuc WHERE codigo='" & txtcuenta.Text & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()
        If tc.Rows.Count > 0 Then
            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    If tc.Rows(0).Item(0) <> txtdesc.Text Then
                        '........
                        Guar_MovUser("CONTABILIDAD", "MODIFICAR CUENTA COD " & txtcuenta.Text, "DESCRIPCION", tc.Rows(0).Item(0), txtdesc.Text)
                        '.............
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If


    End Sub
    Public Sub Modificar()
        'Dim ok As String = ""
        'If cbnivel.Text = "Auxiliar" Then
        '    Dim t4 As New DataTable
        '    myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo LIKE  '" & txtcuenta.Text & "%'  AND nivel='Auxiliar' ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(t4)
        '    If t4.Rows.Count > 0 Then ok = "dato"
        'End If
        'If ok <> "" Then
        '    MsgBox("No puede crear esta cuenta como Auxiliar, ya que existen mas auxiliares asociadas a esta ", MsgBoxStyle.Information, "SAE")
        '    Exit Sub
        'End If

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then 'LA CUENTA EXISTE SE PUEDE MODIFICAR
            AudiModificar()
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codigo", txtcuenta.Text.ToString)
            myCommand.Parameters.AddWithValue("?des", txtdesc.Text.ToString)
            myCommand.Parameters.AddWithValue("?nivel", cbnivel.Text.ToString)
            myCommand.CommandText = "Update selpuc set descripcion=?des, nivel=?nivel  WHERE codigo=?codigo;"
            myCommand.ExecuteNonQuery()
            lbestado.Text = "EDITADO"
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            txtcuenta.ReadOnly = True
            txtdesc.ReadOnly = True
            lbaux.Visible = False
        Else
            Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
            resultado = MsgBox("La cuenta (" & txtcuenta.Text & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
            If resultado = MsgBoxResult.Yes Then
                If BuscarNivelesAnt() = False Then
                    txtcuenta.Focus()
                    Exit Sub
                End If
                txtsaldo.Text = "0,00"
                Guardar()
            End If
        End If
    End Sub

    Public Sub Eliminar()
        If VerificarSaldoCta() = True Then
            If cbnivel.Text = "Auxiliar" Then
                MsgBox("La cuenta " & txtcuenta.Text & " tiene movimientos contables, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            Else
                MsgBox("las cuentas " & txtcuenta.Text & " tienen movimientos contables, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            End If
        Else
            Dim resultado As MsgBoxResult
            If cbnivel.Text = "Auxiliar" Then
                resultado = MsgBox("La cuenta " & txtcuenta.Text & " será eliminada, ¿Desea Borrarla?", MsgBoxStyle.YesNo, "Verificando")
            Else
                resultado = MsgBox("la(s) cuenta(s) " & txtcuenta.Text & ", ¿Desea Borrarla(s)?", MsgBoxStyle.YesNo, "Verificando")
            End If
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                myCommand.CommandText = "DELETE FROM selpuc WHERE codigo like '" & Trim(txtcuenta.Text) & "%';"
                myCommand.ExecuteNonQuery()
                Refresh()
                lbestado.Text = "ELIMINADO"
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                Cerrar()
            End If
        End If
    End Sub
    Function VerificarSaldoCta()
        Dim t As New DataTable
        Dim dto, cto As String
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo like '" & txtcuenta.Text & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        For i = 0 To t.Rows.Count - 1
            For j = 0 To 12
                Try
                    If j < 10 Then
                        dto = "debito0" & j
                        cto = "credito0" & j
                    Else
                        dto = "debito" & j
                        cto = "credito" & j
                    End If
                    If CDbl(t.Rows(i).Item(dto)) > 0 Then
                        Return True
                        Exit Function
                    End If
                    If CDbl(t.Rows(i).Item(cto)) > 0 Then
                        Return True
                        Exit Function
                    End If
                Catch ex As Exception
                End Try
            Next
        Next
        Return False
    End Function

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        GenerarPDF()
    End Sub
    Dim cb As PdfContentByte
    Dim k, pag, tope As Integer
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        pag = 0
        tope = 40
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            k = k - 10
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********CUERPO*******************
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k < tope Then 'NUEVA PAGINA
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("codigo"), 7, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(Trim(tabla.Rows(i).Item("descripcion")), 95), 65, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("nivel"), 372, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("tipo"), 420, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("naturaleza"), 478, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Mi_SA(tabla.Rows(i).Item("codigo")), 585, k, 0)
            Next
            ''''''''FIN'''''''''
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
            'ABRIR FORMULARIO DESEADO
            Me.Cursor = Cursors.Default
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
            If oDoc.IsOpen Then
                oDoc.Close()
                Exit Sub
            End If
        Finally
            Me.Cursor = Cursors.Default
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        '************************************************
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "INFORME CATALOGO DE CUENTAS", 230, 770, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 760, 0)
        k = 750
        cb.ShowTextAligned(50, "CODIGO ", 7, k, 0)
        cb.ShowTextAligned(50, "NOMBRE / DESCRIPCIÓN ", 65, k, 0)
        cb.ShowTextAligned(50, "NIVEL ", 372, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TIPO", 420, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NATURALEZA", 478, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO", 585, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    Function Mi_SA(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT SUM(saldo) FROM selpuc WHERE codigo like '" & codigo & "%' AND nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            Return Moneda(tabla.Rows(0).Item(0))
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function

    Private Sub chAuxiliar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chAuxiliar.CheckedChanged
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If chAuxiliar.Checked = True Then
                cbnivel.Text = "Auxiliar"
                BCuenta()
            Else
                LongitudCuenta()
            End If
        End If
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged
        If txtcuenta.Text = "" Then
            chAuxiliar.Checked = False
        End If
    End Sub
End Class