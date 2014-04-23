Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmNotaDebito
    Public col, fila, FinEdit As Integer
    Private Sub FrmNotaDebito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = "NULO"
        lbper.Text = PerActual & " - "
        txtperiodo.Text = "/" & PerActual
        grilla.RowCount = 5
        grilla2.RowCount = 4
        Try
            Dim tablacomp As New DataTable
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            lbcompa.Text = tablacomp.Rows(0).Item("descripcion")
            lbnit.Text = "NIT: " & tablacomp.Rows(0).Item("nit")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Public Sub PonerEnCero()
        txtcentro.Text = ""
        txtncentro.Text = ""
        txtnumero.Text = ""
        txtcuenta.Text = ""
        lbdir.Text = ""
        txtdia.Text = Now.Day
        Try
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            txtdia.Text = "01"
        End Try
        txtvalor.Text = "0,00"
        lbcliente.Text = ""
        lbsuma.Text = "SON CERO PESOS"
        grilla.Rows.Clear()
        grilla.RowCount = 5
        grilla2.Rows.Clear()
        grilla2.RowCount = 4
        txtnit.Text = ""
        txtelaborado.Text = ""
        txtaprobado.Text = ""
        txtrevisado.Text = ""
        txtconta.Text = ""
        lbestado.Text = "NULO"
        lbnroobs.Text = "0"
        Bloquear()
    End Sub
    Public Sub Bloquear()
        txtcentro.Enabled = False
        grilla.ReadOnly = True
        grilla2.ReadOnly = True
        txtdia.Enabled = False
        txtaprobado.Enabled = False
        txtelaborado.Enabled = False
        txtconta.Enabled = False
        txtrevisado.Enabled = False
        rbcc.Enabled = False
        rbnit.Enabled = False
        txtcuenta.Enabled = False
        '**** READ ONLY *************
        txtnit.ReadOnly = True
        '********** comandos ***********
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        'CmdEliminar.Enabled=true 
        cmdprint.Enabled = True
        CmdMostrar.Enabled = True
        txtnumero.Enabled = False
    End Sub
    Public Sub DesBloquear()
        Dim t As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item("ccosto") = "S" Then
            txtcentro.Enabled = True
        Else
            txtcentro.Enabled = False
        End If
        '****************************************************
        grilla.ReadOnly = False
        grilla2.ReadOnly = False
        txtdia.Enabled = True
        txtaprobado.Enabled = True
        txtelaborado.Enabled = True
        txtconta.Enabled = True
        txtrevisado.Enabled = True
        rbcc.Enabled = True
        rbnit.Enabled = True
        txtcuenta.Enabled = True
        '**** READ ONLY *************
        txtnit.ReadOnly = False
        '********** comandos ***********
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        'CmdEliminar.Enabled=False 
        cmdprint.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Public Sub BuscarActual()
        If lbestado.Text = "NUEVO" Then
            Dim tabla2, tabla As New DataTable
            myCommand.CommandText = "SELECT nd FROM parotdoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para las Notas Debito (del grupo ND), verifique.   ", MsgBoxStyle.Information, "Verificando")
                Me.Close()
                Exit Sub
            End If
            myCommand.CommandText = "SELECT tipodoc, descripcion, actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & tabla.Rows(0).Item(0) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para las Notas Debito (del grupo ND), verifique.   ", MsgBoxStyle.Information, "Verificando")
                Me.Close()
            Else
                lbnomdoc.Text = tabla2.Rows(0).Item("descripcion").ToString
                lbdoc.Text = tabla2.Rows(0).Item("tipodoc").ToString
                txtnumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1)
            End If
        End If
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If PerBloq() = False Then Exit Sub
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If tra_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        Dim tabla2 As New DataTable
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <= 0 Then
            MsgBox("Favor no han creados cuentas auxiliares, Verifique.  ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        PonerEnCero()
        'txtelaborado.Text = FrmPrincipal.lbuser.Text
        lbestado.Text = "NUEVO"
        DesBloquear()
        BuscarActual()
        txtnumero.Enabled = True
        txtnumero.ReadOnly = False
        If txtcentro.Enabled = True Then
            txtcentro.Focus()
        Else
            txtnit.Focus()
        End If
    End Sub
    Private Sub cmdver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdver.Click
        Try
            FrmSelOtdoc.lbtabla.Text = "ot_doc" & PerActual(0) & PerActual(1) & ""
            FrmSelOtdoc.tdoc.Text = "'" & lbdoc.Text & "'"
            FrmSelOtdoc.lbform.Text = "NotaDb"
            FrmSelOtdoc.ShowDialog()
            BuscarDocumento(lbdoc.Text & txtnumero.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                If ValidarGuardar() = True Then
                    MiConexion(bda)
                    If lbestado.Text = "NUEVO" Then
                        Dim ban As Integer = 0
                        Dim tabla As New DataTable
                        '************** COMO ES NUEVO GUARDAR UNO QUE NO EXISTA ********************
                        While ban = 0
                            tabla.Clear()
                            'myCommand.CommandText = "SELECT doc FROM ot_doc" & PerActual(0) & PerActual(1) & " WHERE doc ='" & lbdoc.Text & txtnumero.Text & "';"
                            myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc ='" & CInt(txtnumero.Text) & "' and tipodoc='" & lbdoc.Text & "';"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)
                            If tabla.Rows.Count = 0 Then 'NO EXISTE
                                ban = 1
                            Else 'EXISTE BUSCO EL SGT
                                txtnumero.Text = NumeroDoc(Val(txtnumero.Text) + 1)
                                ban = 0
                            End If
                        End While
                        Dim it As Integer = -1
                        For i = 0 To grilla.RowCount - 1
                            If grilla.Item(0, i).Value <> "" And Moneda(grilla.Item(1, i).Value) <> "0,00" Then
                                Try
                                    it = it + 1
                                    Guardar(it, txtcuenta.Text, grilla.Item(1, i).Value, 0, grilla.Item(0, i).Value)
                                    GuardarContable(it, txtcuenta.Text, grilla.Item(1, i).Value, 0, grilla.Item(0, i).Value)
                                    ActualizarCuentas(txtcuenta.Text, grilla.Item(1, i).Value, 0)
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            End If
                        Next
                        For i = 0 To grilla2.RowCount - 1
                            If grilla2.Item(0, i).Value <> "" And Moneda(grilla2.Item(1, i).Value) <> "0,00" Then
                                Try
                                    it = it + 1
                                    Guardar(it, grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value, "CREDITOS")
                                    GuardarContable(it, grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value, "CREDITOS")
                                    ActualizarCuentas(grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value)
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            End If
                        Next
                        '********************************
                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?actual", txtnumero.Text.ToString)
                        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
                        myCommand.CommandText = "Update tipdoc set actual" & PerActual(0) & PerActual(1) & "=?actual WHERE tipodoc=?tipodoc AND actual" & PerActual(0) & PerActual(1) & "<?actual;"
                        myCommand.ExecuteNonQuery()
                        lbestado.Text = "GUARDADO"
                        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                        Bloquear()
                    Else
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("El documento " & lbdoc.Text & txtnumero.Text & " se va a Editar, ¿Desea Modificarlo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            ModificarCuentas()
                            Eliminar()
                            Dim it As Integer = -1
                            For i = 0 To grilla.RowCount - 1
                                If grilla.Item(0, i).Value <> "" And Moneda(grilla.Item(1, i).Value) <> "0,00" Then
                                    Try
                                        it = it + 1
                                        Guardar(it, txtcuenta.Text, grilla.Item(1, i).Value, 0, grilla.Item(0, i).Value)
                                        GuardarContable(it, txtcuenta.Text, grilla.Item(1, i).Value, 0, grilla.Item(0, i).Value)
                                        ActualizarCuentas(txtcuenta.Text, grilla.Item(1, i).Value, 0)
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try
                                End If
                            Next
                            For i = 0 To grilla2.RowCount - 1
                                If grilla2.Item(0, i).Value <> "" And Moneda(grilla2.Item(1, i).Value) <> "0,00" Then
                                    Try
                                        it = it + 1
                                        Guardar(it, grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value, "CREDITOS")
                                        GuardarContable(it, grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value, "CREDITOS")
                                        ActualizarCuentas(grilla2.Item(0, i).Value, 0, grilla2.Item(1, i).Value)
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                    End Try
                                End If
                            Next
                            lbestado.Text = "EDITADO"
                            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                            Bloquear()
                        End If
                    End If
                    Cerrar()
                End If
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
                If PerBloq() = False Then Exit Sub
                If Trim(lbanulado.Text) <> "" Then
                    MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                    Exit Sub
                End If
                If tra_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                DesBloquear()
                grilla.ReadOnly = False
                txtnumero.ReadOnly = True
                lbestado.Text = "EDITAR"
                grilla.Item(0, 0).Selected = True
                grilla.Focus()
                If txtcentro.Enabled = True Then
                    txtcentro.Focus()
                Else
                    txtnit.Focus()
                End If
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If tra_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
    End Sub
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            GenerarPDF()
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If PerBloq() = False Then Exit Sub
            If Trim(lbanulado.Text) <> "" Then
                MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tra_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            FrmAnularOtDoc.lbcompa.Text = lbcompa.Text
            FrmAnularOtDoc.lbnit.Text = lbnit.Text
            FrmAnularOtDoc.txtcentro.Text = txtcentro.Text
            FrmAnularOtDoc.txtncentro.Text = txtncentro.Text
            FrmAnularOtDoc.txttipo.Text = lbdoc.Text
            FrmAnularOtDoc.txttipo2.Text = lbnomdoc.Text
            FrmAnularOtDoc.txtnumfac.Text = txtnumero.Text
            FrmAnularOtDoc.lbper_a.Text = "del " & PerActual
            Try
                FrmAnularOtDoc.txtfecha.Text = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
            End Try
            FrmAnularOtDoc.txtfecha_ana.Text = Today
            FrmAnularOtDoc.lbcliente.Text = lbcliente.Text
            FrmAnularOtDoc.lbform.Text = "nd"
            FrmAnularOtDoc.ShowDialog()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND' ORDER BY doc, item LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND' ORDER BY doc, item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND' ORDER BY doc, item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='ND' ORDER BY doc, item LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0))
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal doc As String)
        Try
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & mes & " WHERE doc='" & doc & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                CmdNuevo.Focus()
            Else
                Refresh()
                txtcentro.Text = tabla.Rows(0).Item("ccosto")
                txtncentro.Text = ""
                If tabla.Rows(0).Item("ccosto").ToString <> "0" Then BuscarCC()
                lbdoc.Text = tabla.Rows(0).Item("tipo")
                txtnumero.Text = NumeroDoc(tabla.Rows(0).Item("num"))
                txtcuenta.Text = tabla.Rows(0).Item("codigo")
                txtdia.Text = tabla.Rows(0).Item("dia")
                Try
                    Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
                Catch ex As Exception
                    txtdia.Text = "01"
                End Try
                txtvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtvalor_LostFocus(AcceptButton, AcceptButton)
                lbcliente.Text = ""
                grilla.Rows.Clear()
                grilla2.Rows.Clear()
                txtnit.Text = tabla.Rows(0).Item("nitc")
                Try
                    If tabla.Rows(0).Item("tn") = "CC" Then
                        rbcc.Checked = True
                    Else
                        rbnit.Checked = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    rbnit.Checked = True
                End Try
                txtnit_LostFocus(AcceptButton, AcceptButton)
                txtelaborado.Text = tabla.Rows(0).Item("elaborado")
                txtaprobado.Text = tabla.Rows(0).Item("autorizado")
                txtconta.Text = tabla.Rows(0).Item("contabilizado")
                txtrevisado.Text = tabla.Rows(0).Item("contabilizado")
                Try
                    lbanulado.Text = tabla.Rows(0).Item("doc_aj")
                Catch ex As Exception
                    lbanulado.Text = ""
                End Try
                Dim ic As Integer = -1
                Dim id As Integer = -1
                grilla.RowCount = 5
                grilla2.RowCount = 4
                For i = 0 To tabla.Rows.Count - 1
                    If Moneda(tabla.Rows(i).Item("credito")) <> "0,00" Then
                        ic = ic + 1
                        grilla.Item(0, ic).Value = tabla.Rows(i).Item("descrip")
                        grilla.Item(1, ic).Value = Moneda(tabla.Rows(i).Item("credito"))
                    Else
                        id = id + 1
                        grilla2.Item(0, id).Value = tabla.Rows(i).Item("codigo")
                        grilla2.Item(1, id).Value = Moneda(tabla.Rows(i).Item("debito"))
                    End If
                Next
                '***********************************************************
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                If tabla2.Rows.Count > 0 Then
                    lbnomdoc.Text = tabla2.Rows(0).Item("descripcion").ToString
                End If
                Bloquear()
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '******************************************
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
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCC()
    End Sub

    Public Sub BuscarCC()
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") <> "S" Then Exit Sub
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
                FrmSelCentroCostos.lbform.Text = "nd"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtdocafec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                validarnumero(txtcuenta, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Buscarcuentas(txtcuenta.Text, 0, "txt")
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
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
        End Try
    End Sub

    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarNIT(txtnit, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnit.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            lbcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnit.Text)
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            FrmSelCliente.lbform.Text = "nd"
            FrmSelCliente.ShowDialog()
            If lbcliente.Text <> "" Then
                BuscarClientes(txtnit.Text)
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
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
            lbcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.txtnit.Text = txtnit.Text
                LimpiarTerceros()
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.lbform.Text = "nd"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                If lbcliente.Text <> "" Then
                    BuscarClientes(txtnit.Text)
                End If
                txtdia.Focus()
            End If
        Else  'mostrar uno solo q coinside
            lbcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            lbdir.Text = tabla.Rows(0).Item("dir")
        End If
    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        If rbnit.Checked = True Then
            txtdv.Text = "-" & DigitoNIT(txtnit.Text)
        Else
            txtdv.Text = ""
        End If
    End Sub
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        txtdv.Text = ""
        txtnit.Focus()
    End Sub
    Private Sub rbnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnit.CheckedChanged
        txtdv.Text = "-" & DigitoNIT(txtnit.Text)
        txtnit.Focus()
    End Sub

    Private Sub txtelaborado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtelaborado.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtrevisado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrevisado.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaprobado.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtconta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconta.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        Try
            Select Case e.ColumnIndex
                Case 2  'CASO DEBITO 
                Case 3  'CASO CREDITO                     
                Case 0 'CASO CUENTA 
                    If grilla.Item(1, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION                       
                    grilla.Item(0, e.RowIndex).Value = UCase(grilla.Item(0, e.RowIndex).Value)
                Case 1 'CASO DEBITO                    
                    grilla.Item(1, e.RowIndex).Value = Moneda(grilla.Item(1, e.RowIndex).Value.ToString)
                    'If grilla.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    'grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO 
                    If CDbl(grilla.Item(3, e.RowIndex).Value) = 0 Then
                        grilla.Item(3, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(3, e.RowIndex).Value.ToString), 2)
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    End If
                Case 4 'CASO CUENTA
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex

                Case 1 'CASO DEBITO
                    If grilla.Item(1, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(1, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(1, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO  
                    If grilla.Item(3, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 0  'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    'grilla.Item(0, e.RowIndex).Value = ""
                    'Buscarcuentas("", e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuentas()
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item(1, i).Value.ToString = "" Then
                grilla.Item(1, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(1, i).Value = "0,00"
        End Try
    End Sub
    Public Sub SacarCuentas()
        Dim suma, monto As Double
        suma = 0
        For i = 0 To grilla.RowCount - 1
            Try
                If grilla.Item(0, i).Value <> "" Or grilla.Item(1, i).Value <> "" Then
                    Try
                        monto = CDbl(grilla.Item(1, i).Value)
                    Catch ex As Exception
                        monto = 0
                    End Try
                    suma = suma + monto
                End If
            Catch ex As Exception
            End Try
        Next
        txtvalor.Text = Moneda(suma)
        txtvalor_LostFocus(AcceptButton, AcceptButton)
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If e.KeyCode = 8 Then
            If fila > grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila > grilla.RowCount - 1 Then Exit Sub
        If grilla.Item(0, fila).Value <> "" Or grilla.Item(1, fila).Value <> "" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Toda la fila será retirada, ¿Desea limpiada?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
            If resultado = MsgBoxResult.Yes Then
                grilla.Item(0, fila).Value = ""
                grilla.Item(1, fila).Value = ""
            End If
        End If

    End Sub
    '***********************************************************
    Private Sub grilla2_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla2.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub grilla2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla2.CellValidating
        If FinEdit = 1 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
    End Sub
    Private Sub grilla2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla2.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        Try
            Select Case e.ColumnIndex
                Case 2  'CASO DEBITO 
                Case 3  'CASO CREDITO                     
                Case 0 'CASO CUENTA 
                    If grilla2.Item(1, e.RowIndex).Value <> "" Or grilla2.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grilla2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla2.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 1 'CASO DEBITO                    
                    grilla2.Item(1, e.RowIndex).Value = Moneda(grilla2.Item(1, e.RowIndex).Value.ToString)
                Case 0  'CASO CREDITO 
                    Buscarcuentas(grilla2.Item(0, e.RowIndex).Value, e.RowIndex, "grilla")
                Case 4 'CASO CUENTA
            End Select
        Catch ex As Exception
        End Try
        ValoresDefecto2(e.RowIndex)
    End Sub
    Public Sub ValoresDefecto2(ByVal i)
        Try
            If grilla.Item(1, i).Value.ToString = "" Then
                grilla.Item(1, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(1, i).Value = "0,00"
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer, ByVal control As String)
        Try
            If cuenta = "" Then
                FrmCuentas.lbform.Text = "nd"
                If control = "txt" Then
                    FrmCuentas.lbfila.Text = "txt"
                Else
                    FrmCuentas.lbfila.Text = fila
                End If
                FrmCuentas.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <= 0 Then
                    grilla2.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "nd"
                    If control = "txt" Then
                        FrmCuentas.lbfila.Text = "txt"
                    Else
                        FrmCuentas.lbfila.Text = fila
                    End If
                    FrmCuentas.ShowDialog()
                Else
                    If control <> "txt" Then
                        grilla2.Item(0, fila).Value = cuenta
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
    '///////////////////////////////////////////////////////////////
    Function ValidarGuardar()
        Try
            Dim fec As Date
            fec = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("El dia no coincide con un formato de fecha correcto, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Return False
            Exit Function
        End Try
        If txtcentro.Enabled = True And txtncentro.Text = "" Then
            MsgBox("No ha digitado centro de costos, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtncentro.Focus()
            Return False
            Exit Function
        ElseIf txtvalor.Text = "0,00" Then
            MsgBox("No ha digitado el campo valor, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtvalor.Focus()
            Return False
            Exit Function
        ElseIf lbcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtnit.Focus()
            Return False
            Exit Function
        ElseIf txtcuenta.Text = "" Then
            MsgBox("No ha digitado cuenta crédito, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtcuenta.Focus()
            Return False
            Exit Function
        End If
        If grilla.RowCount < 2 Then
            MsgBox("Verifique los campos de contabilización.  ", MsgBoxStyle.Information, "SAE Control ")
            grilla.Focus()
            Return False
            Exit Function
        Else
            Dim db As Double
            Dim sdb As Double = 0
            Dim scr As Double = 0
            '***********************************************
            Try
                SacarCuentas()
                scr = CDbl(txtvalor.Text)
            Catch ex As Exception
                scr = 0
            End Try
            '*******************************************
            For i = 0 To grilla2.RowCount - 1
                Try
                    If Trim(grilla2.Item(0, i).Value.ToString) <> "" Then
                        Try
                            db = CDbl(grilla2.Item(1, i).Value)
                        Catch ex As Exception
                            db = 0
                        End Try
                        sdb = sdb + db
                    End If
                Catch ex As Exception
                End Try
            Next
            If sdb = 0 Or scr = 0 Then
                MsgBox("Verifique los campos Debitos y Créditos. Debitos(" & Moneda(sdb) & "), Créditos(" & Moneda(scr) & "). ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            ElseIf sdb <> scr Then
                MsgBox("Debitos(" & Moneda(sdb) & ") <> Créditos(" & Moneda(scr) & "); Las sumas deben ser iguales.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Public Sub Guardar(ByVal it As Integer, ByVal codigo As String, ByVal db As Double, ByVal cr As Double, ByVal des As String)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", it)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?grupo", "ND")
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumero.Text.ToString))
        myCommand.Parameters.AddWithValue("?doc_afec", CambiaCadena(txtcuenta.Text, 15))
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?ciudad", "")
        myCommand.Parameters.AddWithValue("?concepto", "")
        myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
        If rbcc.Checked = True Then
            myCommand.Parameters.AddWithValue("?tn", "CC")
        Else
            myCommand.Parameters.AddWithValue("?tn", "NIT")
        End If
        myCommand.Parameters.AddWithValue("?codigo", codigo)
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(des, 99))
        myCommand.Parameters.AddWithValue("?debito", DIN(db))
        myCommand.Parameters.AddWithValue("?credito", DIN(cr))
        myCommand.Parameters.AddWithValue("?base", DIN("0"))
        myCommand.Parameters.AddWithValue("?total", DIN(txtvalor.Text))
        myCommand.Parameters.AddWithValue("?efectivo", "S")
        myCommand.Parameters.AddWithValue("?cheque", "")
        myCommand.Parameters.AddWithValue("?banco", "")
        myCommand.Parameters.AddWithValue("?sucursal", "")
        '*********************************************************
        myCommand.Parameters.AddWithValue("?ccosto", Val(txtcentro.Text))
        myCommand.Parameters.AddWithValue("?fecha", Now)
        myCommand.Parameters.AddWithValue("?elaborado", CambiaCadena(txtelaborado.Text, 40))
        myCommand.Parameters.AddWithValue("?autorizado", CambiaCadena(txtaprobado.Text, 40))
        myCommand.Parameters.AddWithValue("?revisado", CambiaCadena(txtrevisado.Text, 40))
        myCommand.Parameters.AddWithValue("?contabilizado", CambiaCadena(txtconta.Text, 40))
        myCommand.Parameters.AddWithValue("?doc_aj", " ")
        myCommand.CommandText = "INSERT INTO ot_doc" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,'');"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Public Sub GuardarContable(ByVal it As Integer, ByVal codigo As String, ByVal db As Double, ByVal cr As Double, ByVal des As String)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", it)
        myCommand.Parameters.AddWithValue("?doc", txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?centro", Val(txtcentro.Text))
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(des, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(db))
        myCommand.Parameters.AddWithValue("?credito", DIN(cr))
        myCommand.Parameters.AddWithValue("?codigo", codigo)
        myCommand.Parameters.AddWithValue("?base", "0")
        myCommand.Parameters.AddWithValue("?diasv", "0")
        myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
        myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
        myCommand.Parameters.AddWithValue("?cheque", "")
        myCommand.Parameters.AddWithValue("?modulo", "Otros doc")
        myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Public Sub ActualizarCuentas(ByVal codigo As String, ByVal db As Double, ByVal cb As Double)
        Dim sql As String
        Dim suma As Double = 0
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        suma = db - cb
        sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
            & debito & "=" & debito & " + " & DIN(db) & ", " _
            & credito & "=" & credito & " + " & DIN(cb) & " " _
            & "WHERE codigo='" & codigo & "';"
        Ejecutar(sql)
    End Sub
    Public Sub ModificarCuentas()
        Dim sql As String
        Dim tabla As New DataTable
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & Trim(lbdoc.Text) & "';"
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
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim Sql, tabla As String
        tabla = "documentos" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & lbdoc.Text & "';"
        Ejecutar(Sql)
        tabla = "ot_doc" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc='" & lbdoc.Text & txtnumero.Text & "';"
        Ejecutar(Sql)
    End Sub
    '******************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 110
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg(1)
            '********CABECERA************** 
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.SetFontAndSize(fuente, 11)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbnomdoc.Text, 384, 820, 0)
            cb.EndText()
            cb.BeginText()
            '********NUMERO************** 
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PerActual & " - " & lbdoc.Text & txtnumero.Text, 433, 797, 0)
            cb.EndText()
            cb.BeginText()
            '********** BANNER ********************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 9)
            Banner()
            cb.EndText()
            cb.BeginText()
            '*********************************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '*******FORMA DE PAGO*****************
            '*******CUERPO**********************
            k = 682
            For i = 0 To grilla.RowCount - 1
                k = k - 19
                If k < tope Then
                    k = 760
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                End If
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                If grilla.Item(0, i).Value <> "" Then
                    '*** datos
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(0, i).Value, 100), 10, k + 1, 0)
                    If Moneda(grilla.Item(1, i).Value) <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(1, i).Value), 585, k + 1, 0)
                End If
            Next
            k = 560
            Control_de_linea(": " & lbsuma.Text, 141, 60)
            k = 558
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtvalor.Text), 585, k, 0)
            k = 517
            For i = 0 To grilla2.RowCount - 1
                k = k - 19
                If grilla2.Item(0, i).Value <> "" Then
                    '*** datos
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla2.Item(0, i).Value, 100), 13, k + 1, 0)
                    If Moneda(grilla2.Item(1, i).Value) <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla2.Item(1, i).Value), 172, k + 1, 0)
                End If
            Next
            k = 498
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 197, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtrevisado.Text, 400, k, 0)
            k = k - 38
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 197, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtconta.Text, 400, k, 0)
            k = k - 43
            Observacion()
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            '*********** FIN ***********************
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Observacion()
        Try
            If Trim(lbanulado.Text) <> "" Then
                cb.ShowTextAligned(50, "DOCUMENTO " & lbanulado.Text & ". ", 10, k, 0)
                k = k - 20
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT aj FROM parotdoc;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item("aj") = lbdoc.Text Then
                    tabla.Clear()
                    myCommand.CommandText = "SELECT doc_afec FROM ot_doc" & PerActual(0) & PerActual(1) & " WHERE doc='" & lbdoc.Text.ToString & txtnumero.Text.ToString & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If Trim(tabla.Rows(0).Item("doc_afec").ToString) <> "" Then
                        cb.ShowTextAligned(50, "ANULA AL DOCUMENTO " & tabla.Rows(0).Item("doc_afec") & ". ", 10, k, 0)
                        k = k - 20
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 820
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), 10, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), 10, k, 0)
        If txtncentro.Text <> "" Then
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CENTRO DE COSTOS: " & txtcentro.Text & " - " & txtncentro.Text, 10, k, 0)
        End If
        k = 767
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 525, k, 0)
        k = 771
        Control_de_linea(Trim(lbcliente.Text), 80, 41)
        k = 767
        PrintNit()
        k = 733
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcuenta.Text, 502, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbdir.Text, 80, k, 0)
    End Sub
    Public Sub ColocarImg(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\NOTA\ND.jpg")
                img.SetAbsolutePosition(0, 430)
                img.ScaleToFit(598, 600)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\NOTA\N2.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 50)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\NOTA\N3C.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 170)
            End If
            img.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal pos As Integer, ByVal tam As Integer)
        Dim s As Integer = 1
        linea = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = "" Or cadena(i) = "," Or cadena(i) = "." Or j = tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
                    linea = ""
                    k = k - 10
                    s = s + 1
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
    End Sub
    Public Sub PrintNit()
        If rbcc.Checked = True Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text, 398, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 319, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text & txtdv.Text, 398, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "X", 354, k, 0)
        End If
    End Sub

    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        validarnumero(txtnumero, e)
    End Sub

    Private Sub txtnumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumero.LostFocus
        txtnumero.Text = NumeroDoc(txtnumero.Text)
    End Sub

    Private Sub txtnumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumero.TextChanged

    End Sub

   
    Private Sub cmdmas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmas.Click
        'If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        'SendKeys.Send(Chr(Keys.Space))
        'FrmSelConcepImp.lbform.Text = "NotaDb"
        'FrmSelConcepImp.lbfila.Text = fila
        'If fila = grilla.RowCount - 1 Then
        '    grilla.RowCount = grilla.RowCount + 1
        'End If
        'FrmSelConcepImp.ShowDialog()
    End Sub
    Private Sub cmdmas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdmas.GotFocus
        SendKeys.Send(Chr(Keys.Tab))
    End Sub
End Class