Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmTransacciones

    Private Sub FrmTransacciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ponerencero()
        Bloquear()
    End Sub
    Public Sub ponerencero()
        BuscarPeriodo()
        '0000000000000000000000
        txtnum.Text = ""
        txtbanco.Text = ""
        txtcuenta.Text = ""
        txtnomcta.Text = ""
        txtnit.Text = ""
        txtnomctab.Text = ""
        '''''9999999999999999''''''
        txtnum2.Text = ""
        txtbanco2.Text = ""
        txtcuenta2.Text = ""
        txtnomcta2.Text = ""
        txtnit2.Text = ""
        txtnomctab2.Text = ""
        '00000000000000000000000000
        TxtDocumento.Text = ""
        txtDoc.Text = ""
        Lbper.Text = PerActual
        TxtNumero.Text = ""
        'txtdia.Text
        Lbper.Text = PerActual
        txtperiodo.Text = "/" & PerActual
        txtmonto.Text = Moneda(0)
        lbestado.Text = "NULO"
        lbnroobs.Text = ""
        txtcheque.Text = ""
        txtcheque2.Text = ""
    End Sub
    Public Sub Bloquear()
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        CmdNuevo.Enabled = True
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        cmdprint.Enabled = True
        '+++++++++++++++++++++++++++
        gorigen.Enabled = False
        gdestino.Enabled = False
        gdoc.Enabled = False
    End Sub
    Public Sub DesBloquear()
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        CmdNuevo.Enabled = False
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        cmdprint.Enabled = False
        '+++++++++++++++++++++++++++
        gorigen.Enabled = True
        gdestino.Enabled = True
        gdoc.Enabled = True
    End Sub
    '''999999999999999999999999999999999999999999999999999999
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If PerBloq() = False Then Exit Sub
        If tra_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        ponerencero()
        DesBloquear()
        lbestado.Text = "NUEVO"
        BuscarActual()
        ValidarDia(Today.Day.ToString)
        TxtNumero.Enabled = True
        txtnum.Focus()
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
        ponerencero()
        Bloquear()

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If PerBloq() = False Then Exit Sub
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
                DesBloquear()
                TxtNumero.Enabled = False
                lbestado.Text = "EDITAR"
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
        docTB()
        FrmSelDocTb.lbdoc.Text = lbdoc.Text
        FrmSelDocTb.lbdoc2.Text = txtDoc.Text
        FrmSelDocTb.lbform.Text = "tb"
        FrmSelDocTb.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarDocumento("documentos" & PerActual(0) & PerActual(1), Val(TxtNumero.Text), TxtDocumento.Text)
        End If
    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnum.LostFocus
        If Trim(txtnomctab.Text) <> "" Then Exit Sub
        Try
            FrmSelBanco.txtcuenta.Text = txtnum.Text
            FrmSelBanco.lbform.Text = "tra1"
            FrmSelBanco.ShowDialog()
            BuscarPuc(txtcuenta.Text, 1)
            BuscarTercero(txtnit.Text, 1)
            LABELDV.Text = DigitoNIT(txtnit.Text)
            'txtnum2.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtnum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnum.TextChanged
        BuscarCuenta(txtnum.Text, 1)
    End Sub

    Private Sub txtnum2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtnum2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnum2.LostFocus
        If Trim(txtnomctab2.Text) <> "" Then Exit Sub
        Try
            FrmSelBanco.txtcuenta.Text = txtnum2.Text
            FrmSelBanco.lbform.Text = "tra2"
            FrmSelBanco.ShowDialog()
            BuscarPuc(txtcuenta2.Text, 2)
            BuscarTercero(txtnit2.Text, 2)
            LABELDV2.Text = DigitoNIT(txtnit2.Text)
            'TxtNumero.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtnum2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnum2.TextChanged
        BuscarCuenta(txtnum2.Text, 2)
    End Sub
    Public Sub BuscarCuenta(ByVal cuenta As String, ByVal it As Integer)
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM bancos WHERE num_cta ='" & cuenta & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If it = 1 Then
                txtnomctab.Text = tabla.Rows(0).Item("banco")
                txtcuenta.Text = tabla.Rows(0).Item("codigo")
                txtnit.Text = tabla.Rows(0).Item("nit")
                BuscarPuc(txtcuenta.Text, 1)
                BuscarTercero(txtnit.Text, 1)
                LABELDV.Text = DigitoNIT(txtnit.Text)
            Else
                txtnomctab2.Text = tabla.Rows(0).Item("banco")
                txtcuenta2.Text = tabla.Rows(0).Item("codigo")
                txtnit2.Text = tabla.Rows(0).Item("nit")
                BuscarPuc(txtcuenta2.Text, 2)
                BuscarTercero(txtnit2.Text, 2)
                LABELDV2.Text = DigitoNIT(txtnit2.Text)
            End If
        Catch ex As Exception
            If it = 1 Then
                txtnomctab.Text = ""
                txtcuenta.Text = ""
                txtnit.Text = ""
                BuscarPuc(txtcuenta.Text, 1)
                BuscarTercero(txtnit.Text, 1)
                LABELDV.Text = DigitoNIT(txtnit.Text)
            Else
                txtnomctab2.Text = ""
                txtcuenta2.Text = ""
                txtnit2.Text = ""
                BuscarPuc(txtcuenta2.Text, 2)
                BuscarTercero(txtnit2.Text, 2)
                LABELDV2.Text = DigitoNIT(txtnit2.Text)
            End If
        End Try
    End Sub
    Public Sub BuscarTercero(ByVal nit As String, ByVal it As Integer)
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT TRIM(CONCAT(apellidos,' ',nombre)) AS ter FROM terceros WHERE nit ='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If it = 1 Then
                txtbanco.Text = tabla.Rows(0).Item("ter")
            Else
                txtbanco2.Text = tabla.Rows(0).Item("ter")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
            If it = 1 Then
                txtbanco.Text = ""
            Else
                txtbanco2.Text = ""
            End If
        End Try
    End Sub
    Public Sub BuscarPuc(ByVal cta As String, ByVal it As Integer)
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo ='" & cta & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If it = 1 Then
                txtnomcta.Text = tabla.Rows(0).Item("descripcion")
            Else
                txtnomcta2.Text = tabla.Rows(0).Item("descripcion")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
            If it = 1 Then
                txtnomcta.Text = ""
            Else
                txtnomcta2.Text = ""
            End If
        End Try
    End Sub
    Private Sub txtmonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        ValidarMoneda(txtmonto, e)
    End Sub
    Private Sub txtmonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto.LostFocus
        txtmonto.Text = Moneda(txtmonto.Text)
    End Sub
    Public Sub docTB()
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT doc4 FROM parbanc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            TxtDocumento.Text = tabla.Rows(0).Item("doc4")
            lbdoc.Text = tabla.Rows(0).Item("doc4")
            tabla.Clear()
            myCommand.CommandText = "SELECT descripcion,(actual" & PerActual(0) & PerActual(1) & " + 1) as a FROM tipdoc where tipodoc='" & TxtDocumento.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtDoc.Text = tabla.Rows(0).Item("descripcion")
            'TxtNumero.Text = NumeroDoc(tabla.Rows(0).Item("a"))
            txtperiodo.Text = "/" & PerActual
            Lbper.Text = PerActual & "-" & TxtDocumento.Text
        Catch ex As Exception

        End Try
    End Sub
    Public Sub BuscarActual()
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT doc4 FROM parbanc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            TxtDocumento.Text = tabla.Rows(0).Item("doc4")
            tabla.Clear()
            myCommand.CommandText = "SELECT descripcion,(actual" & PerActual(0) & PerActual(1) & " + 1) as a, grupo, actualfc  FROM tipdoc where tipodoc='" & TxtDocumento.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtDoc.Text = tabla.Rows(0).Item("descripcion")
            If tabla.Rows(0).Item("grupo").ToString = "FC" Then
                TxtNumero.Text = NumeroDoc(Val(tabla.Rows(0).Item("actualfc").ToString) + 1)
            Else
                TxtNumero.Text = NumeroDoc(tabla.Rows(0).Item("a"))
            End If
            txtperiodo.Text = "/" & PerActual
            Lbper.Text = PerActual & "-" & TxtDocumento.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        validarnumero(TxtNumero, e)
    End Sub

    Private Sub TxtNumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.LostFocus
        TxtNumero.Text = NumeroDoc(TxtNumero.Text)
    End Sub

    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub

    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        ValidarDia(txtdia.Text)
    End Sub
    Public Sub ValidarDia(ByVal dia As String)
        Dim fecha As Date
        Try
            If dia.Length = 1 Then dia = "0" & dia
            fecha = CDate(dia & "/" & PerActual)
        Catch ex As Exception
            dia = "01"
        End Try
        txtdia.Text = dia
    End Sub

    Private Sub txtcheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheque.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '9999999999999999999999999
    Public Sub ValidarGuardar()
        MiConexion(bda)
        Try
            If TxtDocumento.Text = "" Then
                MsgBox("Favor escoger el tipo de documento...", MsgBoxStyle.Information, "SAE Verificación")
                TxtDocumento.Focus()
                Exit Sub
            ElseIf TxtNumero.Text = "" Then
                MsgBox("Favor verifique el campo Nro Documento...", MsgBoxStyle.Information, "SAE Verificación")
                TxtNumero.Focus()
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
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & TxtDocumento.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If lbestado.Text = "NUEVO" Then
                If tabla.Rows.Count > 0 Then
                    MsgBox("Ya existe el documento, Verifique su número o consecutivo.  ", MsgBoxStyle.Information, "SAE Verificación")
                    TxtNumero.Focus()
                    Exit Sub
                End If
            Else
                '******************ELIMINAR LOS EXIXTENTES (PARA REMPLAZAR (MODIFICAR))******************************+
                Dim cad2 As String = PerActual(0) & PerActual(1)
                ModificarCuentas("saldo" & cad2, "debito" & cad2, "credito" & cad2)
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM documentos" & cad2 & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & TxtDocumento.Text & "';"
                myCommand.ExecuteNonQuery()
            End If
            Guardar(txtcuenta.Text)
            Guardar(txtcuenta2.Text)
            ActualizarCuentas("saldo" & PerActual(0) & PerActual(1), "debito" & PerActual(0) & PerActual(1), "credito" & PerActual(0) & PerActual(1), txtcuenta.Text)
            ActualizarCuentas("saldo" & PerActual(0) & PerActual(1), "debito" & PerActual(0) & PerActual(1), "credito" & PerActual(0) & PerActual(1), txtcuenta2.Text)
            If lbestado.Text = "NUEVO" Then
                lbestado.Text = "GUARDADO"
                UpConsecutivo()
            Else
                lbestado.Text = "EDITADO"
            End If
            Bloquear()
            MsgBox("La base de datos se acualizo correctamente.", MsgBoxStyle.Information, "SAE Guardar Datos")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
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
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '999999999999999999999999999
    Public Sub ActualizarCuentas(ByVal saldo As String, ByVal debito As String, ByVal credito As String, ByVal cta As String)
        Try
            Dim sql As String
            Dim suma, db, cb As Double
            If txtcuenta.Text = cta Then
                db = 0
                cb = CDbl(txtmonto.Text)
            Else
                db = CDbl(txtmonto.Text)
                cb = 0
            End If
            suma = db - cb
            sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
                & debito & "=" & debito & " + " & DIN(db) & ", " _
                & credito & "=" & credito & " + " & DIN(cb) & " " _
                & "WHERE codigo='" & cta & "';"
            Ejecutar(sql)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub UpConsecutivo()
        Try
            'myCommand.Parameters.Clear()
            'myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
            'myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
            'myCommand.CommandText = "Update tipdoc set actual" & PerActual(0) & PerActual(1) & "=?actual WHERE tipodoc=?tipodoc AND actual" & PerActual(0) & PerActual(1) & "<?actual;"
            'myCommand.ExecuteNonQuery()
            'myCommand.Parameters.Clear()
            'Refresh()

            Dim t2 As New DataTable
            myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t2)
            Dim cs As String = ""
            If t2.Rows(0).Item("grupo") <> "FC" Then
                cs = "Update tipdoc set actual" & PerActual(0) & PerActual(1) & "=?actual WHERE tipodoc=?tipodoc AND actual" & PerActual(0) & PerActual(1) & "<?actual;"
            Else
                cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            End If

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
            myCommand.CommandText = cs
            myCommand.ExecuteNonQuery()
            Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Guardar(ByVal cta As String)
        Try
            Dim fecha As Date = CDate(txtdia.Text & txtperiodo.Text)
            myCommand.Parameters.Clear()
            If cta = txtcuenta.Text Then
                myCommand.Parameters.AddWithValue("?item", 1)
            Else
                myCommand.Parameters.AddWithValue("?item", 2)
            End If
            myCommand.Parameters.AddWithValue("?doc", TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?centro", "0")
            If cta = txtcuenta.Text Then
                myCommand.Parameters.AddWithValue("?desc", CambiaCadena("TRANSLADO DE LA CUENTA " & txtnomcta.Text, 50))
                myCommand.Parameters.AddWithValue("?debito", DIN(0))
                myCommand.Parameters.AddWithValue("?credito", DIN(txtmonto.Text))
                myCommand.Parameters.AddWithValue("?codigo", txtcuenta.Text)
            Else
                myCommand.Parameters.AddWithValue("?desc", CambiaCadena("A LA CUENTA " & txtnomcta2.Text, 50))
                myCommand.Parameters.AddWithValue("?debito", DIN(txtmonto.Text))
                myCommand.Parameters.AddWithValue("?credito", DIN(0))
                myCommand.Parameters.AddWithValue("?codigo", txtcuenta2.Text)
            End If
            myCommand.Parameters.AddWithValue("?base", DIN(0))
            myCommand.Parameters.AddWithValue("?diasv", 0)
            myCommand.Parameters.AddWithValue("?fechaven", CambiaCadena(Trim(fecha.ToString), 10))
            If cta = txtcuenta.Text Then
                myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            Else
                myCommand.Parameters.AddWithValue("?cheque", txtcheque2.Text)
            End If
            myCommand.Parameters.AddWithValue("?nit", "0")
            myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
            myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function nitEmpresa()
        Dim nit As String = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT SUBSTRING_INDEX( nit, '-', 1 ) AS n FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            nit = tabla.Rows(0).Item("n").ToString
        Catch ex As Exception
            nit = ""
        End Try
        Return nit
    End Function
    Private Sub txtcheque2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheque2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim mes As String
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
            docTB()
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc='" & lbdoc.Text & "' ORDER BY tipodoc,doc LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                Bloquear()
                ponerencero()
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            lbestado.Text = "NULO"
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
                If TxtDocumento.Text = "CA" Then
                    txtDoc.Text = "CIERRE ANUAL "
                End If
                txtdia.Text = tabla.Rows(0).Item("dia")
                txtperiodo.Text = "/" & tabla.Rows(0).Item("periodo")
                txtmonto.Text = Moneda(tabla.Rows(0).Item("credito").ToString)
                If txtmonto.Text = "0,00" Then
                    txtmonto.Text = Moneda(tabla.Rows(0).Item("debito").ToString)
                End If
                For i = 0 To 1
                    Try
                        If i = 0 Then
                            txtcuenta.Text = tabla.Rows(i).Item("codigo")
                            txtcheque.Text = tabla.Rows(i).Item("cheque")
                            BancoCodigo(txtcuenta.Text, 1)
                        Else
                            txtcuenta2.Text = tabla.Rows(i).Item("codigo")
                            txtcheque2.Text = tabla.Rows(i).Item("cheque")
                            BancoCodigo(txtcuenta2.Text, 2)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Next
            Else
                MsgBox("El documento no se encuentra en este Periodo", MsgBoxStyle.Information, "Verificación")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BancoCodigo(ByVal cta As String, ByVal it As Integer)
        Try
            Dim tabla, tsaldo As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM bancos WHERE codigo ='" & cta & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If it = 1 Then
                txtnum.Text = tabla.Rows(0).Item("num_cta")
                txtnomctab.Text = tabla.Rows(0).Item("banco")
                txtcuenta.Text = tabla.Rows(0).Item("codigo")
                txtnit.Text = tabla.Rows(0).Item("nit")
                BuscarPuc(txtcuenta.Text, 1)
                BuscarTercero(txtnit.Text, 1)
                LABELDV.Text = DigitoNIT(txtnit.Text)
            Else
                txtnum2.Text = tabla.Rows(0).Item("num_cta")
                txtnomctab2.Text = tabla.Rows(0).Item("banco")
                txtcuenta2.Text = tabla.Rows(0).Item("codigo")
                txtnit2.Text = tabla.Rows(0).Item("nit")
                BuscarPuc(txtcuenta2.Text, 2)
                BuscarTercero(txtnit2.Text, 2)
                LABELDV2.Text = DigitoNIT(txtnit2.Text)
            End If
        Catch ex As Exception
            If it = 1 Then
                txtnomctab.Text = ""
                txtcuenta.Text = ""
                txtnit.Text = ""
                BuscarPuc(txtcuenta.Text, 1)
                BuscarTercero(txtnit.Text, 1)
                LABELDV.Text = DigitoNIT(txtnit.Text)
            Else
                txtnomctab2.Text = ""
                txtcuenta2.Text = ""
                txtnit2.Text = ""
                BuscarPuc(txtcuenta2.Text, 2)
                BuscarTercero(txtnit2.Text, 2)
                LABELDV2.Text = DigitoNIT(txtnit2.Text)
            End If
        End Try
    End Sub

    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & "  WHERE tipodoc='" & lbdoc.Text & "'  ORDER BY tipodoc,doc LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & "  WHERE tipodoc='" & lbdoc.Text & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & "  WHERE tipodoc='" & lbdoc.Text & "'  ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            BuscarPeriodo()
            Dim mes As String
            mes = "documentos" & PerActual(0) & PerActual(1)
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc='" & lbdoc.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc),tipodoc FROM " & mes & " WHERE tipodoc='" & lbdoc.Text & "' ORDER BY tipodoc,doc  LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(mes, tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub Eliminar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El documento " & TxtDocumento.Text & TxtNumero.Text & " se va a eliminar, ¿Desea Borrarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            BuscarPeriodo()
            Dim Sql, tabla As String
            Dim cad2 As String = PerActual(0) & PerActual(1)
            ModificarCuentas("saldo" & cad2, "debito" & cad2, "credito" & cad2)
            tabla = "documentos" & PerActual(0) & PerActual(1)
            Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(TxtNumero.Text) & " AND tipodoc='" & TxtDocumento.Text & "' AND modulo='contabilidad';"
            Ejecutar(Sql)
            MsgBox("El Registro " & TxtDocumento.Text & TxtNumero.Text & " fué eliminado correctamente.", MsgBoxStyle.Information, "SAE Borrar")
            Cerrar()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            GenerarPDF()
        End If
    End Sub
    Public Sub GenerarPDF()


        Dim nom As String = ""
        Dim nitp As String = ""
        Dim per As String = ""
        Dim sql As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nitp = "NIT: " & tabla2.Rows(0).Item("nit")


        MiConexion(bda)

        'Dim tabla As DataSet
        'tabla = New DataSet
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = "select man"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla, "cobdpen")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RBancos\ReportTransCuenta.rpt")
        'CrReport.SetDataSource(tabla)
        ' CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField

            Dim Prtipo As New ParameterField
            Dim Prtt As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrtituloG As New ParameterField

            Dim Prcf As New ParameterField
            Dim Pr3 As New ParameterField
            Dim Pr4 As New ParameterField
            Dim Pr5 As New ParameterField
            Dim Pr6 As New ParameterField
            Dim Pr7 As New ParameterField
            Dim Pr8 As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitp.ToString)
            'Prperiodo.Name = "periodo"
            'Prperiodo.CurrentValues.AddValue(per.ToString)

            Prtipo.Name = "Oncta"
            Prtipo.CurrentValues.AddValue(txtnum.Text & "  -  " & txtnomctab.Text)
            Prtt.Name = "Octa"
            Prtt.CurrentValues.AddValue(txtcuenta.Text & "  -   " & txtnomcta.Text)
            Prtitulo.Name = "Onit"
            Prtitulo.CurrentValues.AddValue(txtnit.Text & " DV " & LABELDV.Text & "  - " & txtbanco.Text)
            PrtituloG.Name = "Ocheq"
            PrtituloG.CurrentValues.AddValue(txtcheque.Text)

            Prcf.Name = "Dncta"
            Prcf.CurrentValues.AddValue(txtnum2.Text & "  -  " & txtnomctab2.Text)
            Pr3.Name = "Dcta"
            Pr3.CurrentValues.AddValue(txtcuenta2.Text & "  -  " & txtnomcta2.Text)
            Pr4.Name = "Dnit"
            Pr4.CurrentValues.AddValue(txtnit2.Text & " DV " & LABELDV2.Text & "  - " & txtbanco2.Text)
            Pr5.Name = "Dcheq"
            Pr5.CurrentValues.AddValue(txtcheque2.Text)

            Pr6.Name = "doc"
            Pr6.CurrentValues.AddValue(TxtDocumento.Text & " " & txtDoc.Text)
            Pr7.Name = "ndoc"
            Pr7.CurrentValues.AddValue(Lbper.Text & "-" & TxtNumero.Text & "       FECHA(dd/mm/aaaa): " & txtdia.Text & txtperiodo.Text)
            Pr8.Name = "valor"
            Pr8.CurrentValues.AddValue(txtmonto.Text)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            'prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtipo)
            prmdatos.Add(Prtt)
            prmdatos.Add(Prtitulo)
            prmdatos.Add(PrtituloG)
            prmdatos.Add(Prcf)
            prmdatos.Add(Pr3)
            prmdatos.Add(Pr4)
            prmdatos.Add(Pr5)
            prmdatos.Add(Pr6)
            prmdatos.Add(Pr7)
            prmdatos.Add(Pr8)

            FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCMov_cue.ShowDialog()

        Catch ex As Exception
        End Try

        Cerrar()

    End Sub
End Class