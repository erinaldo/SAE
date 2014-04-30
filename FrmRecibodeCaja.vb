Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmRecibodeCaja
    Public col, fila, FinEdit As Integer

    Private Sub FrmComEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbestado.Text = "NULO"
        lbper.Text = PerActual & " - "
        txtperiodo.Text = "/" & PerActual
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

        logo = ""
        Try
            Dim td As New DataTable
            myCommand.CommandText = "SELECT logo FROM parotdoc ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            logo = td.Rows(0).Item("logo")
        Catch ex As Exception
            logo = "NO"
        End Try
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Dim logo As String
    Public Sub PonerEnCero()
        txtcentro.Text = ""
        txtncentro.Text = ""
        txtnumero.Text = ""
        txtciudad.Text = ""
        txtdocafec.Text = ""
        txtdia.Text = Now.Day
        ChAnti.Checked = False
        Try
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            txtdia.Text = "01"
        End Try
        txtvalor.Text = "0,00"
        lbcliente.Text = ""
        txtconcepto.Text = ""
        lbsuma.Text = "SON CERO PESOS"
        grilla.Rows.Clear()
        grilla.RowCount = 6
        txtcheque.Text = ""
        txtbanco.Text = ""
        txtsucursal.Text = ""
        chefectivo.Checked = True
        txtnit.Text = ""
        'txtelaborado.Text = ""
        'txtaprobado.Text = ""
        'txtconta.Text = ""
        fecha.Value = Today
        lbestado.Text = "NULO"
        lbnroobs.Text = "0"
        Bloquear()
    End Sub
    Public Sub Bloquear()
        txtcentro.Enabled = False
        grilla.ReadOnly = True
        txtdia.Enabled = False
        chefectivo.Enabled = False
        fecha.Enabled = False
        ChAnti.Enabled = False
        'txtaprobado.Enabled = False
        'txtelaborado.Enabled = False
        'txtconta.Enabled = False
        rbcc.Enabled = False
        rbnit.Enabled = False
        txtdocafec.Enabled = False
        '**** READ ONLY *************
        txtciudad.ReadOnly = True
        txtnit.ReadOnly = True
        txtconcepto.ReadOnly = True
        txtvalor.ReadOnly = True
        txtcheque.ReadOnly = True
        txtbanco.ReadOnly = True
        txtsucursal.ReadOnly = True
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
        ChAnti.Enabled = True
        grilla.ReadOnly = False
        txtdia.Enabled = True
        chefectivo.Enabled = True
        fecha.Enabled = True
        'txtaprobado.Enabled = True
        'txtelaborado.Enabled = True
        'txtconta.Enabled = True
        rbcc.Enabled = True
        rbnit.Enabled = True
        txtdocafec.Enabled = True
        '**** READ ONLY *************
        txtciudad.ReadOnly = False
        txtnit.ReadOnly = False
        txtconcepto.ReadOnly = False
        txtvalor.ReadOnly = False
        txtcheque.ReadOnly = False
        txtbanco.ReadOnly = False
        txtsucursal.ReadOnly = False
        '********** comandos ***********
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        'CmdEliminar.Enabled=false 
        cmdprint.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Public Sub BuscarActual()
        If lbestado.Text = "NUEVO" Then
            Dim tabla2, tabla As New DataTable
            myCommand.CommandText = "SELECT rc FROM parotdoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para los recibos de caja (del grupo RO, verifique.   ", MsgBoxStyle.Information, "Verificando")
                Me.Close()
                Exit Sub
            End If
            myCommand.CommandText = "SELECT tipodoc, descripcion, actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & tabla.Rows(0).Item(0) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para los recibos de caja (del grupo RO), verifique.   ", MsgBoxStyle.Information, "Verificando")
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
            txtciudad.Focus()
        End If
    End Sub
    Private Sub AuditoriaRC()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                Dim en As String = "N"
                For i = 0 To grilla.RowCount - 1
                    If grilla.Item("Cuenta", i).Value <> "" Then
                        If grilla.Item("Debitos", i).Value.ToString <> Moneda(0) Then
                            If chefectivo.Checked = True Then
                                If Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "cs") = "y" Then
                                    en = "S"
                                    Exit For
                                End If
                            Else
                                If Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "cs") = "y" Then
                                    en = "S"
                                    Exit For
                                End If
                            End If
                        End If
                    End If
                Next
                If en = "N" Then
                    If chefectivo.Checked = True Then
                        For i = 0 To grilla.RowCount - 1
                            If grilla.Item("Cuenta", i).Value <> "" Then
                                If grilla.Item("Debitos", i).Value.ToString <> Moneda(0) Then
                                    Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                                End If
                            End If
                        Next
                    Else
                        For i = 0 To grilla.RowCount - 1
                            If grilla.Item("Cuenta", i).Value <> "" Then
                                If grilla.Item("Debitos", i).Value.ToString <> Moneda(0) Then
                                    Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                                End If
                            End If
                        Next
                    End If
                End If
                'For i = 0 To grilla.RowCount - 1
                '    If grilla.Item("Cuenta", i).Value <> "" Then
                '        If grilla.Item("Debitos", i).Value.ToString <> Moneda(0) Then
                '            If chefectivo.Checked = True Then
                '                Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                '            Else
                '                Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                '            End If
                '        End If
                '    End If
                'Next
            Catch ex As Exception
                MsgBox("Error al Auditar, " & ex.ToString, MsgBoxStyle.Information)
            End Try
        End If
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                If ValidarGuardar() = True Then
                    AuditoriaRC()
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
                        If GuardarAnticipo() = 0 Then
                            If ChAnti.Checked = True Then
                                MsgBox("Favor seleccione una cuenta para los anticipos para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                Exit Sub
                            End If
                        End If
                        For i = 0 To grilla.RowCount - 1
                            If grilla.Item(0, i).Value <> "" Then
                                Try
                                    Guardar(i)
                                    GuardarContable(i)
                                    ActualizarCuentas(i)
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
                            If ChAnti.Checked = True Then
                                If GuardarAnticipo() = 0 Then
                                    MsgBox("Favor seleccione una cuenta para los anticipos para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                    Exit Sub
                                End If
                            End If
                            ModificarCuentas()
                            Eliminar()
                            For i = 0 To grilla.RowCount - 1
                                If grilla.Item(0, i).Value <> "" Then
                                    Try
                                        Guardar(i)
                                        GuardarContable(i)
                                        ActualizarCuentas(i)
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
    Function GuardarAnticipo()
        Dim sw As Integer = 0 'bandera para la cta
        Dim cta As String = ""
        Try
            For i = 0 To grilla.RowCount - 1
                Try
                    If grilla.Item("Cuenta", i).Value.ToString Like "2805*" = True Then
                        cta = grilla.Item("Cuenta", i).Value.ToString
                        sw = 1
                        'MsgBox(cta)
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            If sw = 0 Then
                Dim resultado As MsgBoxResult
                For i = 0 To grilla.RowCount - 1
                    Try
                        If ChAnti.Checked = True Then
                            resultado = MsgBox("No ha seleccionado una cuenta de la 2805, ¿esta es su cuenta de anticipos " & grilla.Item("Cuenta", i).Value.ToString & "?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                cta = grilla.Item("Cuenta", i).Value.ToString
                                sw = 1
                                Exit For
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
            Dim Sql As String = "DELETE FROM ant_de_clie WHERE per_doc='" & PerActual & "-" & lbdoc.Text & txtnumero.Text & "';"
            Ejecutar(Sql)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?per_doc", PerActual & "-" & lbdoc.Text & txtnumero.Text)
            myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            Try
                myCommand.Parameters.AddWithValue("?fecha", CDate(txtdia.Text & "/" & PerActual))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?fecha", txtdia.Text & "/" & PerActual)
            End Try
            myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
            myCommand.Parameters.AddWithValue("?monto", DIN(Moneda(txtvalor.Text)))
            myCommand.Parameters.AddWithValue("?causado", DIN("0"))
            myCommand.Parameters.AddWithValue("?cta", cta)
            myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text.ToString)
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text)
            myCommand.CommandText = "INSERT INTO ant_de_clie VALUES(" _
            & "?per_doc,?doc,?per,?fecha,?nitc,?monto,?causado,?cta,?user,NOW(),?concepto" _
            & ");"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return sw
    End Function
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
                    txtciudad.Focus()
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
            FrmAnularOtDoc.lbform.Text = "rc"
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
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO' ORDER BY doc, item LIMIT 0, 1;"
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
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO' ORDER BY doc, item LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO' ORDER BY doc, item LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='RO' ORDER BY doc, item LIMIT " & i & ", 1;"
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
                '----- INMOBILIARIA
                If tabla.Rows(0).Item("cod_contra").ToString = "SI" Then
                    ChAnti.Checked = True
                Else
                    ChAnti.Checked = False
                End If
                txtcentro.Text = tabla.Rows(0).Item("ccosto")
                txtncentro.Text = ""
                If tabla.Rows(0).Item("ccosto").ToString <> "0" Then BuscarCC()
                lbdoc.Text = tabla.Rows(0).Item("tipo")
                txtnumero.Text = NumeroDoc(tabla.Rows(0).Item("num"))
                txtciudad.Text = tabla.Rows(0).Item("ciudad")
                txtdia.Text = tabla.Rows(0).Item("dia")
                Try
                    Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
                Catch ex As Exception
                    txtdia.Text = "01"
                End Try
                txtvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtvalor_LostFocus(AcceptButton, AcceptButton)
                lbcliente.Text = ""
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
                txtdocafec.Text = tabla.Rows(0).Item("doc_afec")
                grilla.Rows.Clear()
                txtcheque.Text = tabla.Rows(0).Item("cheque")
                txtbanco.Text = tabla.Rows(0).Item("banco")
                txtsucursal.Text = tabla.Rows(0).Item("sucursal")
                If tabla.Rows(0).Item("efectivo") = "S" Then
                    chefectivo.Checked = True
                Else
                    chefectivo.Checked = False
                End If
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
                'txtelaborado.Text = tabla.Rows(0).Item("elaborado")
                'txtaprobado.Text = tabla.Rows(0).Item("autorizado")
                'txtconta.Text = tabla.Rows(0).Item("contabilizado")
                Try
                    lbanulado.Text = tabla.Rows(0).Item("doc_aj")
                Catch ex As Exception
                    lbanulado.Text = ""
                End Try
                fecha.Value = CDate(tabla.Rows(0).Item("fecha"))
                grilla.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    grilla.Item(0, i).Value = tabla.Rows(i).Item("codigo")
                    grilla.Item(1, i).Value = tabla.Rows(i).Item("descrip")
                    grilla.Item(2, i).Value = Moneda(tabla.Rows(i).Item("debito"))
                    grilla.Item(3, i).Value = Moneda(tabla.Rows(i).Item("credito"))
                    grilla.Item(4, i).Value = Moneda(tabla.Rows(i).Item("base"))
                    grilla.Item(5, i).Value = tabla.Rows(i).Item("ccosto")
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
                FrmSelCentroCostos.lbform.Text = "comproRo"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtdocafec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocafec.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
            End If
        Else
            e.Handled = True
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
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
        End Try
    End Sub

    Private Sub txtciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtciudad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarletra(txtciudad, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarMoneda(txtvalor, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
    End Sub
    Private Sub txtconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcepto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" And grilla.Item(0, 0).Value = "" Then
                grilla.Focus()
                grilla.Item(0, 0).Selected = True
                SendKeys.Send(Chr(Keys.Space))
                SendKeys.Send(Chr(Keys.Back))
                grilla.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheque.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtsucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsucursal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chefectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chefectivo.CheckedChanged
        If chefectivo.Checked = True Then
            txtcheque.Enabled = False
            txtbanco.Enabled = False
            txtsucursal.Enabled = False
            txtnit.Focus()
        Else
            txtcheque.Enabled = True
            txtbanco.Enabled = True
            txtsucursal.Enabled = True
            txtcheque.Focus()
        End If

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
            FrmSelCliente.lbform.Text = "comproRo"
            FrmSelCliente.ShowDialog()
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
                frmterceros.lbform.Text = "comproRo"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtconcepto.Focus()
            End If
        Else  'mostrar uno solo q coinside
            lbcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
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


    Private Sub fecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
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
                    If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
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
                Exit Sub
            End If
            Select Case e.ColumnIndex
                Case 1  'CASO DESCRIPCION                       
                    grilla.Item(1, e.RowIndex).Value = UCase(grilla.Item(1, e.RowIndex).Value)
                Case 2  'CASO DEBITO                    
                    grilla.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(2, e.RowIndex).Value.ToString), 2)
                    If grilla.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO 
                    If CDbl(grilla.Item(3, e.RowIndex).Value) = 0 Then
                        grilla.Item(3, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(3, e.RowIndex).Value.ToString), 2)
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    End If
                Case 4 'base
                    grilla.Item(4, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(4, e.RowIndex).Value.ToString), 2)
                Case 0 'CASO CUENTA
                    Buscarcuentas(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
                Case 5 ' CASO CCOSTO
                    Buscarcco(grilla.Item("cc", e.RowIndex).Value, e.RowIndex)
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex

                Case 2 'CASO DEBITO
                    If grilla.Item(2, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(2, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO  
                    If grilla.Item(3, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 4  'CASO base  
                    If grilla.Item(4, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor de la base, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(4, e.RowIndex).Value = "0,00"
                Case 0  'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(0, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex)
                Case 5 ' CASO CCOSTO
                    grilla.Item("cc", e.RowIndex).Value = ""
                    Buscarcco("", e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item(2, i).Value.ToString = "" Then
                grilla.Item(2, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(2, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(3, i).Value.ToString = "" Then
                grilla.Item(3, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(3, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(4, i).Value.ToString = "" Then
                grilla.Item(4, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(4, i).Value = "0,00"
        End Try
    End Sub
    Private Sub Buscarcco(ByVal ccosto As String, ByVal fila As Integer)
        Try
            If ccosto = "" Then
                FrmSelCentroCostos.lbform.Text = "RecCaG"
                FrmSelCentroCostos.lbfila.Text = fila
                FrmSelCentroCostos.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & ccosto & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    grilla.Item("cc", fila).Value = ""
                    FrmSelCentroCostos.txtcuenta.Text = ccosto
                    FrmSelCentroCostos.lbform.Text = "RecCaG"
                    FrmSelCentroCostos.lbfila.Text = fila
                    FrmSelCentroCostos.ShowDialog()
                Else
                    grilla.Item("cc", fila).Value = ccosto
                End If
            End If
        Catch ex As Exception
            '  txtnomcc.Text = ""
        End Try
    End Sub

    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        Try
            If cuenta = "" Then
                FrmCuentas.lbform.Text = "comproRo"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <= 0 Then
                    grilla.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "comproRo"
                    FrmCuentas.lbfila.Text = fila
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                Else
                    grilla.Item(0, fila).Value = cuenta
                    grilla.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
                End If
            End If
        Catch ex As Exception

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
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
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
        ElseIf chefectivo.Checked = False Then
            If txtcheque.Text = "" Then
                MsgBox("No ha digitado el numero del cheque, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtcheque.Focus()
                Return False
                Exit Function
            ElseIf Trim(txtbanco.Text) = "" Then
                MsgBox("No ha digitado el campo banco, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtbanco.Focus()
                Return False
                Exit Function
            ElseIf Trim(txtsucursal.Text) = "" Then
                MsgBox("No ha digitado el campo sucursal, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtsucursal.Focus()
                Return False
                Exit Function
            End If
        End If
        If grilla.RowCount < 2 Then
            MsgBox("Verifique los campos de contabilización.  ", MsgBoxStyle.Information, "SAE Control ")
            grilla.Focus()
            Return False
            Exit Function
        Else
            Dim db, cr As Double
            Dim sdb As Double = 0
            Dim scr As Double = 0
            For i = 0 To grilla.RowCount - 1
                If grilla.Item("Cuenta", i).Value <> "" Then
                    Try
                        db = CDbl(grilla.Item("Debitos", i).Value)
                    Catch ex As Exception
                        db = 0
                    End Try
                    sdb = sdb + db
                    Try
                        cr = CDbl(grilla.Item("Creditos", i).Value)
                    Catch ex As Exception
                        cr = 0
                    End Try
                    scr = scr + cr
                End If
            Next
            If sdb = 0 Or scr = 0 Then
                MsgBox("Verifique los campos Debitos y Créditos.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            ElseIf sdb <> scr Then
                MsgBox("Debitos(" & Moneda(sdb) & ") <> Créditos(" & Moneda(scr) & "); Las sumas deben ser iguales.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            ElseIf scr <> CDbl(txtvalor.Text) Then
                MsgBox("El valor del documento no coincide con los movimientos ", MsgBoxStyle.Information, "SAE Control ")
                txtvalor.Focus()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function
    Public Sub Guardar(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?grupo", "RO")
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumero.Text.ToString))
        myCommand.Parameters.AddWithValue("?doc_afec", CambiaCadena(txtdocafec.Text, 15))
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?ciudad", txtciudad.Text.ToString)
        myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
        If rbcc.Checked = True Then
            myCommand.Parameters.AddWithValue("?tn", "CC")
        Else
            myCommand.Parameters.AddWithValue("?tn", "NIT")
        End If
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 99))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?total", DIN(txtvalor.Text).ToString)
        If chefectivo.Checked = True Then
            myCommand.Parameters.AddWithValue("?efectivo", "S")
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?banco", "")
            myCommand.Parameters.AddWithValue("?sucursal", "")
        Else
            myCommand.Parameters.AddWithValue("?efectivo", "N")
            myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
            myCommand.Parameters.AddWithValue("?banco", txtbanco.Text)
            myCommand.Parameters.AddWithValue("?sucursal", txtsucursal.Text)
        End If
        '*********************************************************
        If grilla.Item("cc", fila).Value <> "" Then
            myCommand.Parameters.AddWithValue("?ccosto", grilla.Item("cc", fila).Value.ToString)
        Else
            myCommand.Parameters.AddWithValue("?ccosto", txtcentro.Text)
        End If
        '  myCommand.Parameters.AddWithValue("?ccosto", txtcentro.Text)
        myCommand.Parameters.AddWithValue("?fecha", fecha.Value)
        myCommand.Parameters.AddWithValue("?elaborado", "")
        myCommand.Parameters.AddWithValue("?autorizado", "")
        myCommand.Parameters.AddWithValue("?revisado", "")
        myCommand.Parameters.AddWithValue("?contabilizado", "")
        myCommand.Parameters.AddWithValue("?doc_aj", " ")
        If ChAnti.Checked = True Then
            myCommand.Parameters.AddWithValue("?cont", "SI")
        Else
            myCommand.Parameters.AddWithValue("?cont", " ")
        End If
        myCommand.CommandText = "INSERT INTO ot_doc" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?cont);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Public Sub GuardarContable(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        If grilla.Item("cc", fila).Value <> "" Then
            myCommand.Parameters.AddWithValue("?centro", grilla.Item("cc", fila).Value.ToString)
        Else
            myCommand.Parameters.AddWithValue("?centro", txtcentro.Text)
        End If
        ' myCommand.Parameters.AddWithValue("?centro", txtcentro.Text)
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", "0")
        myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
        myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
        myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
        myCommand.Parameters.AddWithValue("?modulo", "Otros doc")
        myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Public Sub ActualizarCuentas(ByVal i As Integer)
        Dim sql As String
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        Try
            db = CDbl(grilla.Item(2, i).Value.ToString)
        Catch ex As Exception
            db = 0
        End Try
        Try
            cb = CDbl(grilla.Item(3, i).Value.ToString)
        Catch ex As Exception
            cb = 0
        End Try
        suma = db - cb
        sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
            & debito & "=" & debito & " + " & DIN(db) & ", " _
            & credito & "=" & credito & " + " & DIN(cb) & " " _
            & "WHERE codigo='" & grilla.Item(0, i).Value & "';"
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
            sql = "UPDATE selpuc SET saldo=saldo - '" & DIN(suma) & "', " & saldo & "=" & saldo & " - '" & DIN(suma) & "', " _
                & debito & "=" & debito & " - '" & DIN(db) & "', " _
                & credito & "=" & credito & " - '" & DIN(cb) & "' " _
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
            If logo = "SI" Then
                ColocarLogo()
            End If
            '********CABECERA************** 
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.SetFontAndSize(fuente, 11)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbnomdoc.Text, 381, 820, 0)
            cb.EndText()
            cb.BeginText()
            '********NUMERO************** 
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PerActual & " - " & lbdoc.Text & txtnumero.Text, 430, 797, 0)
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
            If chefectivo.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 578, 602, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcheque.Text, 462, 618, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtbanco.Text, 518, 618, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtsucursal.Text, 453, 602, 0)
            End If
            '*******CUERPO**********************
            k = 615
            Dim sw As Integer = 0
            Dim fin As Integer
            If Ch_mov.Checked = True Then
                fin = grilla.RowCount - 1
            Else
                fin = 1
            End If

            Dim cad As String = "///"
            For i = 0 To fin
                If Ch_mov.Checked = True Then cad = Trim(grilla.Item(0, i).Value)

                If cad <> "" Then
                    If i < 3 Then
                        k = k - 21
                        sw = 0
                    Else
                        k = k - 19
                        sw = 3
                    End If
                    If k < tope Then
                        k = 760
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If i > 1 Then
                        cb.EndText()
                        ColocarImg(2)
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If Ch_mov.Checked = True Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value, 27), 76, k + 1, 0)
                        If grilla.Item(2, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(2, i).Value), 314, k + 1, 0)
                        If grilla.Item(3, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 403, k + 1, 0)
                    End If
                End If
            Next
            cb.EndText()
            k = k - 87 + sw
            ColocarImg(3)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = k + 33
            PrintNit()
            k = k - 20
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fecha.Value, 515, k, 0)
            Observacion()
            k = k - 20
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text & ". Modulo:Contabilidad ", 10, k, 0)
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
            k = k - 7
            If Trim(lbanulado.Text) <> "" Then
                k = k - 20
                cb.ShowTextAligned(50, "DOCUMENTO " & lbanulado.Text & ". ", 10, k, 0)
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
                        k = k - 20
                        cb.ShowTextAligned(50, "ANULA AL DOCUMENTO " & tabla.Rows(0).Item("doc_afec") & ". ", 10, k, 0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner()
        Dim d As Integer = 0
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 820
        If logo = "SI" Then
            d = 85
        Else
            d = 10
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), d, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), d, k, 0)
        If txtncentro.Text <> "" Then
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CENTRO DE COSTOS: " & txtcentro.Text & " - " & txtncentro.Text, d, k, 0)
        End If
        k = 767
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtciudad.Text, 60, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 338, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, txtdocafec.Text, 577, k, 0)
        k = 737
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtvalor.Text), 580, k, 0)
        k = 739
        Control_de_linea(Trim(lbcliente.Text), 80, 58)
        'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbcliente.Text, 80, k, 0)
        k = 705
        'concepto
        Control_de_linea(txtconcepto.Text, 110, 80)
        'valor en letras
        k = 672
        Control_de_linea(": " & lbsuma.Text, 138, 75)
    End Sub
    Public Sub ColocarImg(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CI\CI1.jpg")
                img.SetAbsolutePosition(0, 570)
                img.ScaleToFit(598, 500)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CI\CI2.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 50)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CI\CI3.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 170)
            End If
            img.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ColocarLogo()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
            img.ScaleToFit(70, 150)
            img.SetAbsolutePosition(10, 800)
            img.Alignment = Element.ALIGN_RIGHT
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text, 503, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 423, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text & txtdv.Text, 503, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "X", 462, k, 0)
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

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        Try
            FrmSelOtdoc.lbtabla.Text = "ot_doc" & PerActual(0) & PerActual(1) & ""
            FrmSelOtdoc.tdoc.Text = "'" & lbdoc.Text & "'"
            FrmSelOtdoc.lbform.Text = "RecCaja"
            FrmSelOtdoc.ShowDialog()
            BuscarDocumento(lbdoc.Text & txtnumero.Text)
        Catch ex As Exception
        End Try
        BuscarDocumento(lbdoc.Text & txtnumero.Text)
    End Sub

    Private Sub cmdmas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmas.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        SendKeys.Send(Chr(Keys.Space))
        FrmSelConcepImp.lbform.Text = "ReciCaja"
        FrmSelConcepImp.lbfila.Text = fila
        If fila = grilla.RowCount - 1 Then
            grilla.RowCount = grilla.RowCount + 1
        End If
        FrmSelConcepImp.ShowDialog()
    End Sub

    Private Sub cmdmas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdmas.GotFocus
        SendKeys.Send(Chr(Keys.Tab))
    End Sub
End Class