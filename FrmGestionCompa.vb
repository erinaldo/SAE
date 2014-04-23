Public Class FrmGestionCompa
    '************** EVENTOS FORMULARIOS *************************
    Private Sub FrmGestionCompa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbestado.Text = ""
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub FrmGestionCompa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        '....
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.dptos ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        If tabla.Rows.Count <= 0 Then
            MsgBox("No hay departamentos creados, Verifique", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        cbdep.Items.Clear()
        cbdep.Text = ""
        cbdep2.Items.Clear()
        cbdep2.Text = ""
        For i = 0 To tabla.Rows.Count - 1
            cbdep2.Items.Add(UCase(tabla.Rows(i).Item("codigo")))
            cbdep.Items.Add(UCase(tabla.Rows(i).Item("descripcion")))
        Next

        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    '************* BOTONES COMANDOS ************************
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcompa.Text = tabla.Rows(0).Item(0) + 1
        txtcompania.Focus()
        lbestado.Text = "NUEVO"
        txtcompania.Text = ""
        txtnit.Text = ""
        txtrlegal.Text = ""
        txtdir.Text = ""
        cbtipo.Text = "comercial"
        txttel1.Text = ""
        txttel2.Text = ""
        txtfax.Text = ""
        txtlogin.Text = ""
        txtpassw.Text = ""
        txtpassw2.Text = ""
        txtconta.Text = ""
        txttelcont.Text = ""
        txtemailcont.Text = ""
        cbdep2.Text = "20"
        cbciudad2.Text = "20001"
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM sae.modulos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        grilla.RowCount = tabla.Rows.Count
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item("sel") = "s" Then
                grilla.Item(0, i).Value = True
            Else
                grilla.Item(0, i).Value = False
            End If
            grilla.Item(1, i).Value = tabla.Rows(i).Item("nombre")
            grilla.Item(2, i).Value = tabla.Rows(i).Item("cod")
        Next
        txtcompania.Focus()
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
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
                ChReiniciar.Visible = False
                ChReiniciar.Checked = False
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            lbestado.Text = "EDITAR"
            ChReiniciar.Visible = True
            ChReiniciar.Checked = False
            txtreiniciar.Text = txtlogin.Text.ToLower
            txtcompania.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAbrir.Click
        MiConexion("sae")
        Cerrar()
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "gcompa"
        FrmAbrirCompania.ShowDialog()
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <= 0 Then
            MsgBox("No hay compañias creadas, verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        FrmCompania.gitems.RowCount = tabla.Rows.Count + 1
        For i = 0 To tabla.Rows.Count - 1
            FrmCompania.gitems.Item(3, i).Value = tabla.Rows(i).Item("codigo")
            FrmCompania.gitems.Item(0, i).Value = tabla.Rows(i).Item("login")
            FrmCompania.gitems.Item(1, i).Value = UCase(tabla.Rows(i).Item("descripcion"))
            FrmCompania.gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
        Next
        FrmCompania.ShowDialog()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Public Sub ValidarGuardar()
        If txtnit.Text = "" Then
            MsgBox("Por favor digite el NIT de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtnit.Focus()
            Exit Sub
        ElseIf txtcompania.Text = "" Then
            MsgBox("Por favor digite el Nombre de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtcompania.Focus()
            Exit Sub
        ElseIf txtrlegal.Text = "" Then
            MsgBox("Por favor digite el representante legal de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtrlegal.Focus()
            Exit Sub
        ElseIf txtlogin.Text = "" Then
            MsgBox("Por favor digite el usuario/sigla de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtlogin.Focus()
            Exit Sub
        ElseIf txtrlegal.Text = "" Then
            MsgBox("Por favor digite el representante legal de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtrlegal.Focus()
            Exit Sub
        ElseIf txtpassw.Text = "" Then
            MsgBox("Por favor digite la contraseña de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtpassw.Focus()
            Exit Sub
        ElseIf txtpassw.Text <> txtpassw2.Text Then
            MsgBox("Las contraseñas no coinciden, Verifique", MsgBoxStyle.Information, "Verificando")
            txtpassw.Focus()
            Exit Sub
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias WHERE login='" & Trim(txtlogin.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) > 0 Then
            MsgBox("El usuario/sigla (" & txtlogin.Text & ") ya existe en los registros, Verifique", MsgBoxStyle.Information, "Verificando")
            txtlogin.Focus()
            Exit Sub
        End If
        Guardar()
    End Sub
    Public Sub Guardar()
        Dim bd As String
        MiConexion("sae")
        'crear compañia
        Dim pass As String
        pass = TestEncoding()
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?descripcion", CambiaCadena(txtcompania.Text.ToString, 79))
        myCommand.Parameters.AddWithValue("?nit", txtnit.Text.ToString)
        myCommand.Parameters.AddWithValue("?rlegal", CambiaCadena(txtrlegal.Text.ToString, 79))
        myCommand.Parameters.AddWithValue("?contador", txtconta.Text.ToString)
        myCommand.Parameters.AddWithValue("?telconta", txttelcont.Text.ToString)
        myCommand.Parameters.AddWithValue("?email", CambiaCadena(txtemailcont.Text.ToString, 99))
        myCommand.Parameters.AddWithValue("?dir", CambiaCadena(txtdir.Text.ToString, 59))
        myCommand.Parameters.AddWithValue("?telefono1", txttel1.Text.ToString)
        myCommand.Parameters.AddWithValue("?telefono2", txttel2.Text.ToString)
        myCommand.Parameters.AddWithValue("?fax", txtfax.Text.ToString)
        myCommand.Parameters.AddWithValue("?login", Trim(txtlogin.Text.ToString))
        myCommand.Parameters.AddWithValue("?clave", pass)
        myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text)
        myCommand.Parameters.AddWithValue("?dpto", cbdep2.Text)
        myCommand.Parameters.AddWithValue("?mun", cbciudad2.Text)
        myCommand.CommandText = "INSERT INTO sae.companias (descripcion,nit,rlegal,contador,telconta,emailconta,direccion,telefono1,telefono2,fax,login,clave,tipo,cant,dpto,mun) " _
                                & " Values(?descripcion,?nit,?rlegal,?contador,?telconta,?email,?dir,?telefono1,?telefono2,?fax,?login,?clave,?tipo,'',?dpto,?mun);"
        myCommand.ExecuteNonQuery()
        '****************************************
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT MAX(codigo) FROM sae.companias;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcompa.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        '**************************************
        Dim ano As String
        ano = miano.Value
        Try
            myCommand.Parameters.AddWithValue("?periodo", "01/" & ano)
            myCommand.Parameters.AddWithValue("?codigo", Val(lbcompa.Text))
            myCommand.CommandText = "INSERT INTO sae.periodos VALUES(?periodo,'00','SI',?codigo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        bd = "sae" & Trim(txtlogin.Text.ToLower) & ano
        'CREAR BASE DE DATOS 
        myCommand.CommandText = "DROP DATABASE IF EXISTS " & bd & "; CREATE DATABASE " & bd & "; use " & bd & "; "
        myCommand.ExecuteNonQuery()
        'GENERALES
        Generales(bd)
        If FrmPrincipal.Contabilidad.Enabled = True Then
            'HAY CONTABILIDAD
            Try
                Contabilidad(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.Inventarios.Enabled = True Then
            'HAY INVENTARIO
            Inventario(bd)
        End If
        If FrmPrincipal.Facturacion.Enabled = True Then
            'HAY FACTURACION
            Try
                Facturacion(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.Cartera.Enabled = True Then
            'HAY(Cartera)
            Try
                Cartera(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.Proveedores.Enabled = True Then
            'HAY(Proveedores CPP)
            Try
                Proveedores(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.Nomina.Enabled = True Then
            'HAY(Nomina)
            Try
                Nomina(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.inmobiliaria.Visible = True Then
            'HAY(INMOBILIARIA)
            Try
                Inmobiliaria(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        If FrmPrincipal.cmdBanco.Visible = True Then
            'BANCOS
            Try
                bancos(bda)
            Catch ex As Exception
            End Try
        End If

        If FrmPrincipal.cmdOrden.Visible = True Then
            ' ORDENES DE PAGO
            Try
                ord_pagos(bda)
            Catch ex As Exception
            End Try
            Try
                ord_cxp(bda)
            Catch ex As Exception
            End Try
        End If

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            ' AUDITORIA
            Try
                Auditoria(bda)
            Catch ex As Exception
            End Try
            ' AUDITORIA_MOVIMIENTOS
            Try
                Auditoria_movimientos()
            Catch ex As Exception
            End Try
        End If
        If FrmPrincipal.BEstetica.Visible = True Then
            'HAY FACTURACION
            Try
                Facturacion(bd)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Try
                Estetica(bda)
            Catch ex As Exception
            End Try
        End If

        'CERRAR CONEXION
        Cerrar()
        If FrmPrincipal.lbcompania.Text <> "" Then
            MiConexion(bda)
            Cerrar()
        End If
        ChReiniciar.Visible = False
        ChReiniciar.Checked = False
        MsgBox("La compañia fue creada correctamente.  ", MsgBoxStyle.Information, "SAE Guardar Datos")
        lbestado.Text = "GUARDADO"
        lbnroobs.Text = lbcompa.Text
    End Sub
    Function TestEncoding()
        Dim plainText As String = "sae"
        Dim password As String = txtpassw.Text
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return (cipherText)
    End Function
    Function TestEncoding2()
        Dim plainText As String = "sae"
        Dim password As String = txtreiniciar.Text
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return (cipherText)
    End Function
    Public Sub ValidarModificar()
        If txtnit.Text = "" Then
            MsgBox("Por favor digite el NIT de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtnit.Focus()
            Exit Sub
        ElseIf txtcompania.Text = "" Then
            MsgBox("Por favor digite el Nombre de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtcompania.Focus()
            Exit Sub
        ElseIf txtrlegal.Text = "" Then
            MsgBox("Por favor digite el representante legal de la compañia, Verifique", MsgBoxStyle.Information, "Verificando")
            txtrlegal.Focus()
            Exit Sub
        End If
        Modificar()
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos de la compañia se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae")
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text.ToString)
            myCommand.Parameters.AddWithValue("?descripcion", txtcompania.Text.ToString)
            myCommand.Parameters.AddWithValue("?rlegal", txtrlegal.Text.ToString)
            myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
            myCommand.Parameters.AddWithValue("?telefono1", txttel1.Text.ToString)
            myCommand.Parameters.AddWithValue("?telefono2", txttel2.Text.ToString)
            myCommand.Parameters.AddWithValue("?fax", txtfax.Text.ToString)
            myCommand.Parameters.AddWithValue("?contador", txtconta.Text.ToString)
            myCommand.Parameters.AddWithValue("?telconta", txttelcont.Text.ToString)
            myCommand.Parameters.AddWithValue("?emailconta", txtemailcont.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text)
            myCommand.Parameters.AddWithValue("?dpto", cbdep2.Text)
            myCommand.Parameters.AddWithValue("?mun", cbciudad2.Text)
            myCommand.CommandText = "Update sae.companias set nit=?nit,descripcion=?descripcion, rlegal=?rlegal, " _
                                  & "direccion=?dir, telefono1=?telefono1,telefono2=?telefono2, fax=?fax, " _
                                  & "contador=?contador,telconta=?telconta,emailconta=?emailconta,tipo=?tipo,dpto=?dpto,mun=?mun " _
                                  & "  WHERE codigo=" & Val(lbcompa.Text) & ";"
            myCommand.ExecuteNonQuery()
            If ChReiniciar.Checked = True Then
                modificarContra()
            End If
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            ChReiniciar.Visible = False
            ChReiniciar.Checked = False
            lbestado.Text = "EDITADO"
        End If
    End Sub
    Public Sub modificarContra()
        Try
            Dim pass As String
            pass = TestEncoding2()
            '*******************************************
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?passw", pass)
            myCommand.CommandText = "Update sae.companias set clave=?passw WHERE codigo=" & Val(lbcompa.Text) & ";"
            myCommand.ExecuteNonQuery()
            MsgBox("La nueva contaseña de la compañia es: " + txtreiniciar.Text, MsgBoxStyle.Information, "Guardar Datos")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '************ BOTONES DESPLAZAMIENTO **************
    Public Sub BuscarAno(ByVal codigo As String)
        Dim ano As String
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT periodo FROM sae.periodos WHERE codigo='" & Val(codigo) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        ' MsgBox(myCommand.CommandText.ToString)
        ano = tabla.Rows(0).Item("periodo")
        miano.Value = ano(3) & ano(4) & ano(5) & ano(6)
    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtcompania.Text = ""
                txtnit.Text = ""
                txtrlegal.Text = ""
                txtdir.Text = ""
                txttel1.Text = ""
                txttel2.Text = ""
                txtfax.Text = ""
                txtlogin.Text = ""
                txtpassw.Text = ""
                txtpassw2.Text = ""
                txtconta.Text = ""
                txttelcont.Text = ""
                txtemailcont.Text = ""
                lbcompa.Text = "0"
                lbnroobs.Text = 0
                lbestado.Text = "NULO"
                ChReiniciar.Visible = False
                ChReiniciar.Checked = False
                CmdNuevo.Focus()
            Else
                Refresh()
                lbcompa.Text = tabla.Rows(0).Item("codigo").ToString
                BuscarAno(lbcompa.Text)
                txtcompania.Text = tabla.Rows(0).Item("descripcion").ToString
                txtnit.Text = tabla.Rows(0).Item("nit").ToString
                txtrlegal.Text = tabla.Rows(0).Item("rlegal").ToString
                txtdir.Text = tabla.Rows(0).Item("direccion").ToString
                txttel1.Text = tabla.Rows(0).Item("telefono1").ToString
                txttel2.Text = tabla.Rows(0).Item("telefono2").ToString
                txtfax.Text = tabla.Rows(0).Item("fax").ToString
                txtlogin.Text = tabla.Rows(0).Item("login").ToString
                cbtipo.Text = tabla.Rows(0).Item("tipo").ToString
                txtpassw.Text = ""
                txtpassw2.Text = ""
                txtconta.Text = tabla.Rows(0).Item("contador").ToString
                txttelcont.Text = tabla.Rows(0).Item("telconta").ToString
                txtemailcont.Text = tabla.Rows(0).Item("emailconta").ToString
                cbdep2.Text = tabla.Rows(0).Item("dpto").ToString
                cbciudad2.Text = tabla.Rows(0).Item("mun").ToString
                lbnroobs.Text = 1
                BuscarModulos()
                lbestado.Text = "CONSULTA"
                ChReiniciar.Visible = False
                ChReiniciar.Checked = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                lbcompa.Text = tabla.Rows(0).Item("codigo").ToString
                BuscarAno(lbcompa.Text)
                txtcompania.Text = tabla.Rows(0).Item("descripcion").ToString
                txtnit.Text = tabla.Rows(0).Item("nit").ToString
                txtrlegal.Text = tabla.Rows(0).Item("rlegal").ToString
                txtdir.Text = tabla.Rows(0).Item("direccion").ToString
                txttel1.Text = tabla.Rows(0).Item("telefono1").ToString
                txttel2.Text = tabla.Rows(0).Item("telefono2").ToString
                txtfax.Text = tabla.Rows(0).Item("fax").ToString
                txtlogin.Text = tabla.Rows(0).Item("login").ToString
                cbtipo.Text = tabla.Rows(0).Item("tipo").ToString
                txtpassw.Text = ""
                txtpassw2.Text = ""
                txtconta.Text = tabla.Rows(0).Item("contador").ToString
                txttelcont.Text = tabla.Rows(0).Item("telconta").ToString
                txtemailcont.Text = tabla.Rows(0).Item("emailconta").ToString
                cbdep2.Text = tabla.Rows(0).Item("dptp").ToString
                cbciudad2.Text = tabla.Rows(0).Item("mun").ToString
                lbnroobs.Text = i + 1
                BuscarModulos()
                lbestado.Text = "CONSULTA"
                ChReiniciar.Visible = False
                ChReiniciar.Checked = False
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM sae.companias"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                lbcompa.Text = tabla.Rows(0).Item("codigo").ToString
                BuscarAno(lbcompa.Text)
                txtcompania.Text = tabla.Rows(0).Item("descripcion").ToString
                txtnit.Text = tabla.Rows(0).Item("nit").ToString
                txtrlegal.Text = tabla.Rows(0).Item("rlegal").ToString
                txtdir.Text = tabla.Rows(0).Item("direccion").ToString
                txttel1.Text = tabla.Rows(0).Item("telefono1").ToString
                txttel2.Text = tabla.Rows(0).Item("telefono2").ToString
                txtfax.Text = tabla.Rows(0).Item("fax").ToString
                txtlogin.Text = tabla.Rows(0).Item("login").ToString
                cbtipo.Text = tabla.Rows(0).Item("tipo").ToString
                txtpassw.Text = ""
                txtpassw2.Text = ""
                txtconta.Text = tabla.Rows(0).Item("contador").ToString
                txttelcont.Text = tabla.Rows(0).Item("telconta").ToString
                txtemailcont.Text = tabla.Rows(0).Item("emailconta").ToString
                cbdep2.Text = tabla.Rows(0).Item("dpto").ToString
                cbciudad2.Text = tabla.Rows(0).Item("mun").ToString
                lbnroobs.Text = i + 1
                BuscarModulos()
                lbestado.Text = "CONSULTA"
                ChReiniciar.Visible = False
                ChReiniciar.Checked = False
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM sae.companias"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            lbcompa.Text = tabla.Rows(0).Item("codigo").ToString
            BuscarAno(lbcompa.Text)
            txtcompania.Text = tabla.Rows(0).Item("descripcion").ToString
            txtnit.Text = tabla.Rows(0).Item("nit").ToString
            txtrlegal.Text = tabla.Rows(0).Item("rlegal").ToString
            txtdir.Text = tabla.Rows(0).Item("direccion").ToString
            txttel1.Text = tabla.Rows(0).Item("telefono1").ToString
            txttel2.Text = tabla.Rows(0).Item("telefono2").ToString
            txtfax.Text = tabla.Rows(0).Item("fax").ToString
            txtlogin.Text = tabla.Rows(0).Item("login").ToString
            cbtipo.Text = tabla.Rows(0).Item("tipo").ToString
            txtpassw.Text = ""
            txtpassw2.Text = ""
            txtconta.Text = tabla.Rows(0).Item("contador").ToString
            txttelcont.Text = tabla.Rows(0).Item("telconta").ToString
            txtemailcont.Text = tabla.Rows(0).Item("emailconta").ToString
            cbdep2.Text = tabla.Rows(0).Item("dpto").ToString
            cbciudad2.Text = tabla.Rows(0).Item("mun").ToString
            lbnroobs.Text = i + 1
            BuscarModulos()
            lbestado.Text = "CONSULTA"
            ChReiniciar.Visible = False
            ChReiniciar.Checked = False
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarModulos()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.modulos"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        grilla.RowCount = tabla.Rows.Count
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item("sel") = "s" Then
                grilla.Item(0, i).Value = True
            Else
                grilla.Item(0, i).Value = False
            End If
            grilla.Item(1, i).Value = tabla.Rows(i).Item("nombre")
            grilla.Item(2, i).Value = tabla.Rows(i).Item("cod")
        Next
    End Sub

    '*********** CONTROLAR TABULADOR **********************
    Private Sub txtcompania_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcompania.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Select Case e.KeyChar
                Case "0" To "9", Chr(8), Chr(13), "-"
                    txtnit.ForeColor = Color.Black
                Case Else
                    'txt.ForeColor = Color.Red
                    Beep()
                    e.Handled = True
            End Select
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If


    End Sub
    Private Sub a1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub a2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles miano.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub a3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub a4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtrlegal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrlegal.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdir.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txttel1, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txttel2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel2.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txttel2, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtfax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtfax, e)
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtlogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlogin.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Then
                Select Case e.KeyChar
                    Case "A" To "Z", "a" To "z", Chr(8), Chr(13)
                    Case "0" To "9"
                    Case Else
                        Beep()
                        e.Handled = True
                End Select
            Else
                e.Handled = True
            End If
        End If
       
    End Sub
    Private Sub txtpassw_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassw.KeyPress
        If lbestado.Text = "NUEVO" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtpassw2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassw2.KeyPress
        If lbestado.Text = "NUEVO" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtconta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconta.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txttelcont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelcont.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txttelcont, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtemailcont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemailcont.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbcont_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbinv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbfac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbcp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtlogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlogin.TextChanged

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub cbdep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdep.SelectedIndexChanged
        cbdep2.SelectedIndex = cbdep.SelectedIndex
        BuscarMunicipio(cbdep2.Text)
        Try
            cbciudad.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbciudad.KeyPress
        If lbestado.Text = "NUEVO" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbciudad.SelectedIndexChanged
        cbciudad2.SelectedIndex = cbciudad.SelectedIndex
    End Sub
    Public Sub BuscarMunicipio(ByVal dpt As String)
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT m.descripcion,m.codmun FROM sae.mun m LEFT JOIN (sae.dptos d) ON m.coddep = d.codigo WHERE d.codigo = '" & dpt & "' ORDER BY m.descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
            MsgBox("No hay municipios creados, Verifique", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        cbciudad.Items.Clear()
        cbciudad.Text = ""
        cbciudad2.Items.Clear()
        cbciudad2.Text = ""
        For i = 0 To tabla.Rows.Count - 1
            cbciudad.Items.Add(tabla.Rows(i).Item("descripcion"))
            cbciudad2.Items.Add(tabla.Rows(i).Item("codmun"))
        Next
    End Sub

    Private Sub cbdep2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbdep2.KeyPress
        If lbestado.Text = "NUEVO" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

   
    Private Sub cbdep2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdep2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.dptos WHERE codigo='" & cbdep2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
        Else
            cbdep.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub

    Private Sub cbciudad2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbciudad2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.mun WHERE codmun='" & cbciudad2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then

        Else
            cbciudad.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub
End Class