Imports MySql.Data.MySqlClient
Public Class FrmPrincipal

    Private Sub FrmPrincipal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Application.Exit()
    End Sub
    Public Sub UpPermisos()
        Try
            myCommand.Parameters.Clear()
            '****************  GENERALES ****************************************
            myCommand.Parameters.AddWithValue("?ter", "E")
            myCommand.Parameters.AddWithValue("?tip_doc", "E")
            myCommand.Parameters.AddWithValue("?imp", "E")
            '''''''''''' CONTABILIDAD ''''''''''''''''''''''''''''''
            myCommand.Parameters.AddWithValue("?conta_basi", "E")
            myCommand.Parameters.AddWithValue("?conta_tran", "E")
            myCommand.Parameters.AddWithValue("?conta_info", "E")
            myCommand.Parameters.AddWithValue("?conta_pros", "E")
            '''''''''''''INVENTARIOS'''''''''''''''''''''''''''''''
            myCommand.Parameters.AddWithValue("?inve_basi", "E")
            myCommand.Parameters.AddWithValue("?inve_tran", "E")
            myCommand.Parameters.AddWithValue("?inve_info", "E")
            myCommand.Parameters.AddWithValue("?inve_proc", "E")
            '''''''''''''FACTURACION'''''''''''''''''''''''''''''''
            myCommand.Parameters.AddWithValue("?fact_basi", "E")
            myCommand.Parameters.AddWithValue("?fact_tran", "E")
            myCommand.Parameters.AddWithValue("?fact_info", "E")
            myCommand.Parameters.AddWithValue("?fact_proc", "E")
            '''''''''''''CARTERA'''''''''''''''''''''''''''''''
            myCommand.Parameters.AddWithValue("?cart_basi", "E")
            myCommand.Parameters.AddWithValue("?cart_tran", "E")
            myCommand.Parameters.AddWithValue("?cart_info", "E")
            myCommand.Parameters.AddWithValue("?cart_proc", "E")
            '''''''''''''PROVEEDORES'''''''''''''''''''''''''''''''
            myCommand.Parameters.AddWithValue("?prov_basi", "E")
            myCommand.Parameters.AddWithValue("?prov_tran", "E")
            myCommand.Parameters.AddWithValue("?prov_info", "E")
            myCommand.Parameters.AddWithValue("?prov_proc", "E")
            '************************************************************
            myCommand.CommandText = "Update usuarios set ter=?ter,tip_doc=?tip_doc,imp=?imp,conta_basi=?conta_basi,conta_tran=?conta_tran,conta_info=?conta_info,conta_pros=?conta_pros " _
            & ",inve_basi=?inve_basi,inve_tran=?inve_tran,inve_info=?inve_info,inve_proc=?inve_proc " _
            & ",fact_basi=?fact_basi,fact_tran=?fact_tran,fact_info=?fact_info,fact_proc=?fact_proc " _
            & ",cart_basi=?cart_basi,cart_tran=?cart_tran,cart_info=?cart_info,cart_proc=?cart_proc " _
            & ",prov_basi=?prov_basi,prov_tran=?prov_tran,prov_info=?prov_info,prov_proc=?prov_proc " _
            & " ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Permisos()
        MiConexion("sae")
        Try
            myCommand.CommandText = "ALTER TABLE sae.usuarios ADD `cop_seg` CHAR( 1 ) NOT NULL COMMENT 'perimiso copia de seguridad'," _
            & "ADD `res_cop` CHAR( 1 ) NOT NULL COMMENT 'pemiso restauracion de copia'," _
            & "ADD `cam_ser` CHAR( 1 ) NOT NULL COMMENT 'permiso cambiar de servidor'," _
            & "ADD `ter` CHAR( 1 ) NOT NULL COMMENT 'permisos terceros'," _
            & "ADD `tip_doc` CHAR( 1 ) NOT NULL COMMENT 'permisos tipo documentos'," _
            & "ADD `imp` CHAR( 1 ) NOT NULL COMMENT 'permisos impuestos'," _
            & "ADD `compa` CHAR( 1 ) NOT NULL COMMENT 'permisos compaNias';"
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "ALTER TABLE sae.usuarios ADD `conta_basi` CHAR( 1 ) NOT NULL COMMENT 'contabilidad datos basico'," _
            & "ADD `conta_tran` CHAR( 1 ) NOT NULL COMMENT 'contabilidad transacciones'," _
            & "ADD `conta_info` CHAR( 1 ) NOT NULL COMMENT 'contabilidad informes'," _
            & "ADD `conta_pros` CHAR( 1 ) NOT NULL COMMENT 'contabilidad procesos';"
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "ALTER TABLE `usuarios` ADD `inve_basi` CHAR( 1 ) NOT NULL COMMENT 'basicos inventarios'," _
            & "ADD `inve_tran` CHAR( 1 ) NOT NULL COMMENT 'transacciones de inventarios'," _
            & "ADD `inve_info` CHAR( 1 ) NOT NULL COMMENT 'informes de inventarios'," _
            & "ADD `inve_proc` CHAR( 1 ) NOT NULL COMMENT 'procesos de inventarios';"
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "ALTER TABLE `usuarios` ADD `fact_basi` CHAR( 1 ) NOT NULL COMMENT 'basicos facturacion'," _
            & "ADD `fact_tran` CHAR( 1 ) NOT NULL COMMENT 'transacciones de facturacion'," _
            & "ADD `fact_info` CHAR( 1 ) NOT NULL COMMENT 'informes de facturacion'," _
            & "ADD `fact_proc` CHAR( 1 ) NOT NULL COMMENT 'procesos de facturacion';"
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "ALTER TABLE `usuarios` ADD `cart_basi` CHAR( 1 ) NOT NULL COMMENT 'basicos cartera'," _
            & "ADD `cart_tran` CHAR( 1 ) NOT NULL COMMENT 'transacciones cartera'," _
            & "ADD `cart_info` CHAR( 1 ) NOT NULL COMMENT 'informes cartera'," _
            & "ADD `cart_proc` CHAR( 1 ) NOT NULL COMMENT 'procesos cartera';"
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "ALTER TABLE `usuarios` ADD `prov_basi` CHAR( 1 ) NOT NULL COMMENT 'basicos proveedores'," _
            & "ADD `prov_tran` CHAR( 1 ) NOT NULL COMMENT 'transacciones proveedores'," _
            & "ADD `prov_info` CHAR( 1 ) NOT NULL COMMENT 'informes proveedores'," _
            & "ADD `prov_proc` CHAR( 1 ) NOT NULL COMMENT 'procesos proveedores';"
            myCommand.ExecuteNonQuery()
            '******************
            UpPermisos()
            'MsgBox("Se recomieda Actualizar los datos de los usuarios del sistema... ", MsgBoxStyle.Information, "SAE Verificacion.")
        Catch ex As Exception
        End Try
        '************* VER PERMISOS *******************************
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * from sae.usuarios where login='" & FrmLogin.txtusuario.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            per_ter = tabla.Rows(0).Item("ter").ToString
            per_tdoc = tabla.Rows(0).Item("tip_doc").ToString
            per_imp = tabla.Rows(0).Item("imp").ToString
            '**************************************
            bas_con = tabla.Rows(0).Item("conta_basi").ToString
            tra_con = tabla.Rows(0).Item("conta_tran").ToString
            inf_con = tabla.Rows(0).Item("conta_info").ToString
            pro_con = tabla.Rows(0).Item("conta_pros").ToString
            '**************************************
            bas_inv = tabla.Rows(0).Item("inve_basi").ToString
            tra_inv = tabla.Rows(0).Item("inve_tran").ToString
            inf_inv = tabla.Rows(0).Item("inve_info").ToString
            pro_inv = tabla.Rows(0).Item("inve_proc").ToString
            '**************************************
            bas_fac = tabla.Rows(0).Item("fact_basi").ToString
            tra_fac = tabla.Rows(0).Item("fact_tran").ToString
            inf_fac = tabla.Rows(0).Item("fact_info").ToString
            pro_fac = tabla.Rows(0).Item("fact_proc").ToString
            '**************************************
            bas_car = tabla.Rows(0).Item("cart_basi").ToString
            tra_car = tabla.Rows(0).Item("cart_tran").ToString
            inf_car = tabla.Rows(0).Item("cart_info").ToString
            pro_car = tabla.Rows(0).Item("cart_proc").ToString
            '**************************************
            bas_pro = tabla.Rows(0).Item("prov_basi").ToString
            tra_pro = tabla.Rows(0).Item("prov_tran").ToString
            inf_pro = tabla.Rows(0).Item("prov_info").ToString
            pro_pro = tabla.Rows(0).Item("prov_proc").ToString
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Dim it As Integer = 0
        If bas_con = "N" Then
            BasicosContabilidadToolStripMenuItem.Enabled = False
            FrmContabilidad.datosbac.Visible = False
            it = it + 1
        Else
            BasicosContabilidadToolStripMenuItem.Enabled = True
            FrmContabilidad.datosbac.Visible = True
        End If
        If tra_con = "N" Then
            EntradaDeDatosToolStripMenuItem.Enabled = False
            FrmContabilidad.tra.Visible = False
            it = it + 1
        Else
            EntradaDeDatosToolStripMenuItem.Enabled = True
            FrmContabilidad.tra.Visible = True
        End If
        If inf_con = "N" Then
            InformesToolStripMenuItem.Enabled = False
            FrmContabilidad.info.Visible = False
            it = it + 1
        Else
            InformesToolStripMenuItem.Enabled = True
            FrmContabilidad.info.Visible = True
        End If
        If pro_con = "N" Then
            it = it + 1
            ProcesosToolStripMenuItem1.Enabled = False
            FrmContabilidad.proceso.Visible = False
        Else
            ProcesosToolStripMenuItem1.Enabled = True
            FrmContabilidad.proceso.Visible = True
        End If
        If it = 4 Then
            FrmContabilidad.permiso.Visible = True
        Else
            FrmContabilidad.permiso.Visible = False
        End If
        '****** INVENTARIO ****************
        it = 0
        If bas_inv = "N" Then
            FrmInventarios.datosbac.Visible = False
            it = it + 1
        Else
            FrmInventarios.datosbac.Visible = True
        End If
        If tra_inv = "N" Then
            FrmInventarios.tran.Visible = False
            it = it + 1
        Else
            FrmInventarios.tran.Visible = True
        End If
        If inf_inv = "N" Then
            FrmInventarios.info.Visible = False
            it = it + 1
        Else
            FrmInventarios.info.Visible = True
        End If
        If pro_inv = "N" Then
            it = it + 1
            FrmInventarios.pro.Visible = False
        Else
            FrmInventarios.pro.Visible = True
        End If
        If it = 4 Then
            FrmInventarios.permiso.Visible = True
        Else
            FrmInventarios.permiso.Visible = False
        End If
        '****** FACTURACION ****************
        it = 0
        If bas_fac = "N" Then
            frmfacturacion.datosbac.Visible = False
            it = it + 1
        Else
            frmfacturacion.datosbac.Visible = True
        End If
        If tra_fac = "N" Then
            frmfacturacion.tra.Visible = False
            it = it + 1
        Else
            frmfacturacion.tra.Visible = True
        End If
        If inf_fac = "N" Then
            frmfacturacion.info.Visible = False
            it = it + 1
        Else
            frmfacturacion.info.Visible = True
        End If
        If pro_fac = "N" Then
            it = it + 1
            frmfacturacion.admin.Visible = False
        Else
            frmfacturacion.admin.Visible = True
        End If
        If it = 4 Then
            frmfacturacion.permisos.Visible = True
        Else
            frmfacturacion.permisos.Visible = False
        End If
        '****** CARTERA ****************
        it = 0
        If bas_car = "N" Then
            FrmCartera.datosbac.Visible = False
            it = it + 1
        Else
            FrmCartera.datosbac.Visible = True
        End If
        If tra_car = "N" Then
            FrmCartera.tra.Visible = False
            it = it + 1
        Else
            FrmCartera.tra.Visible = True
        End If
        If inf_car = "N" Then
            FrmCartera.info.Visible = False
            it = it + 1
        Else
            FrmCartera.info.Visible = True
        End If
        If pro_car = "N" Then
            it = it + 1
            FrmCartera.pro.Visible = False
        Else
            FrmCartera.pro.Visible = True
        End If
        If it = 4 Then
            FrmCartera.permisos.Visible = True
        Else
            FrmCartera.permisos.Visible = False
        End If
        '****** PROVEEROS ****************
        it = 0
        If bas_pro = "N" Then
            FrmCompras.datosbac.Visible = False
            it = it + 1
        Else
            FrmCompras.datosbac.Visible = True
        End If
        If tra_pro = "N" Then
            FrmCompras.tra.Visible = False
            it = it + 1
        Else
            FrmCompras.tra.Visible = True
        End If
        If inf_pro = "N" Then
            FrmCompras.info.Visible = False
            it = it + 1
        Else
            FrmCompras.info.Visible = True
        End If
        If pro_pro = "N" Then
            it = it + 1
            FrmCompras.pro.Visible = False
        Else
            FrmCompras.pro.Visible = True
        End If
        If it = 4 Then
            FrmCompras.permisos.Visible = True
        Else
            FrmCompras.permisos.Visible = False
        End If

        Try
            Dim tab As New DataTable
            myCommand.CommandText = "Select rol from sae.usuarios where login ='" & lbuser.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tab)
            Refresh()
            If tab.Rows(0).Item(0) = "admin" Then
                Gerencial.Enabled = True
                cmdAuditoria.Enabled = True
            Else
                Gerencial.Enabled = False
                cmdAuditoria.Enabled = False
            End If
        Catch ex As Exception
        End Try

        Cerrar()

    End Sub
    Private Sub FrmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim licencia, aux, licOK As String
            Dim rutaconex As String
            rutaconex = "C:\lus.txt"
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                aux = My.Computer.FileSystem.ReadAllText(rutaconex)
            Else
                MsgBox("Error #3501 no se puede ingresar al sistema, Verifique con el Administrador Terminos de Licencia", MsgBoxStyle.Critical, "Verificando")
                End
            End If
            licencia = ""
            licOK = ""
            For i = 0 To aux.Length - 2
                If i < 8 Then
                    licOK = licOK & (Chr(Val(Asc(aux(i))) - 3))
                Else
                    licencia = licencia & (Chr(Val(Asc(aux(i))) - 3))
                End If

            Next
            If Trim(licencia) = "" Or Trim(licencia) = "Licencia Otorgada a" Then
                MsgBox("Error #3501 no se puede ingresar al sistema, Verifique con el Administrador Terminos de Licencia", MsgBoxStyle.Critical, "Verificando")
                End
            ElseIf Trim(licOK <> "licsaeOK") Then
                MsgBox("Error #3501 no se puede ingresar al sistema, Verifique con el Administrador Terminos de Licencia", MsgBoxStyle.Critical, "Verificando")
                End
            End If
            lblicencia.Text = Trim(licencia)
        Catch ex As Exception
            MsgBox("Error #3501 no se puede ingresar al sistema, Verifique con el Administrador Terminos de Licencia", MsgBoxStyle.Critical, "Verificando")
            End
        End Try

        'Archivo = ""
        'Dim rutaconex2 As String
        'rutaconex2 = My.Application.Info.DirectoryPath & "\nomina.txt"
        'If My.Computer.FileSystem.FileExists(rutaconex2) Then
        '    Nomina.Visible = True
        '    Archivo = My.Computer.FileSystem.ReadAllText(rutaconex2)
        '    Archivo = Archivo & "LOGIN?usu=" & lbuser.Text & "&clave=" & FrmLogin.txtpasswd.Text & "&compa=" & lbcompania.Text & ""
        'End If

        'PERMISOS POR INTERFAZ
        Permisos()

        Try
            '----------------CAMBIAR PERIODO-------------------------
            Dim m As String = ""
            FrmPeriodo.lbmes.Text = ""

            m = tmes(Now.Month.ToString)
            If Now.Month.ToString <> Val(Strings.Left(PerActual, 2)) Then

                If Now.Day.ToString <= 5 Then

                    Dim rst As MsgBoxResult
                    rst = MsgBox("Hoy es " & Now.Day.ToString & " del mes de " & m & ". Desea cambiar el periodo? ", MsgBoxStyle.YesNo, "Verificacion")
                    If rst = MsgBoxResult.Yes Then
                        If Now.Month.ToString < 10 Then
                            m = "0" & Now.Month.ToString
                        Else
                            m = Now.Month.ToString
                        End If
                        FrmPeriodo.lbmes.Text = m
                        FrmPeriodo.lbactual.Text = PerActual
                        FrmPeriodo.ShowDialog()

                    End If
                End If
            End If
            '--------------------------------------------------------
        Catch ex As Exception
        End Try


        Update_tablas()

        '////////////////////////
        If cmdAuditoria.Visible = True Then
            Guar_MovUser("PRINCIPAL", "ENTRADA AL SISTEMA ", "", "", "")
        End If


    End Sub
    Dim Archivo As String = ""
    Public Sub Update_tablas() ' MODIFICAR TABLAS 



        'CREA LA TABLA IMPUESTOS SINO EXISTE
        If Trim(bda) = "" Then Exit Sub
        MiConexion("sae")

        ' NUEVO PERMISO
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  `usuarios` ADD  `desap` VARCHAR( 2 ) NOT NULL DEFAULT  'N';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  `companias` ADD  `tipo` VARCHAR( 15 ) NOT NULL DEFAULT  'comercial' AFTER  `clave` ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  sae.companias ADD  `cant` CHAR( 2 ) NOT NULL ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  sae.`companias` ADD  `dpto` VARCHAR( 2 ) NOT NULL DEFAULT  '20',ADD  `mun` VARCHAR( 5 ) NOT NULL  DEFAULT  '20001';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Cerrar()
        MiConexion(bda)

        If bda = "sae" Then Exit Sub

        ' DECIMALES D CANTIDADES
        Try
            Dim tc As New DataTable
            myCommand.CommandText = "SELECT cant FROM sae.companias where login ='" & lbcompania.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            txtcant.Text = tc.Rows(0).Item("cant")
        Catch ex As Exception
            txtcant.Text = ""
        End Try

       
        If cmdBanco.Visible = True Then
            bancos(bda)
        End If
        If cmdOrden.Visible = True Then
            ord_pagos(bda)
            ord_cxp(bda)
        End If
        If BEstetica.Visible = True Then
            Estetica(bda)
        End If

        If inmobiliaria.Visible = True Then
            Try ' OTROS CONC CONTRATOS
                myCommand.Parameters.Clear()
                myCommand.CommandText = " CREATE TABLE  IF NOT EXISTS `otcon_contrato` (" _
                 & " `codcon` VARCHAR( 30 ) NOT NULL , " _
                 & " `item` VARCHAR( 11 ) NOT NULL , " _
                 & " `tipo` CHAR( 1 ) NOT NULL , " _
                 & "  `descr` VARCHAR( 100 ) NOT NULL ," _
                 & "  `valor` DOUBLE NOT NULL , " _
                 & " `base` DOUBLE NOT NULL , " _
                 & " `cta` VARCHAR( 15 ) NOT NULL , " _
                 & " `tcli` VARCHAR( 15 ) NOT NULL , " _
                 & " `nitc` VARCHAR( 15 ) NOT NULL, " _
                 & " `contb` CHAR( 1 ) NOT NULL DEFAULT  'N' " _
                 & " ) ENGINE = INNODB; "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try


            Dim per As String
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                Try
                    myCommand.CommandText = "  CREATE TABLE  IF NOT EXISTS facturainm" & per & "(" _
                     & " `doc` VARCHAR( 15 ) NOT NULL , " _
                     & " `num` BIGINT( 10 ) NOT NULL , " _
                     & " `tipodoc` VARCHAR( 4 ) NOT NULL , " _
                     & " `fecha` DATE NOT NULL ," _
                     & " `codcontrato` VARCHAR( 30 ) NOT NULL ," _
                     & " `codinm` VARCHAR( 30 ) NOT NULL , " _
                     & " `nita` VARCHAR( 15 ) NOT NULL , " _
                     & " `noma` VARCHAR( 200 ) NOT NULL , " _
                     & " `nitp` VARCHAR( 15 ) NOT NULL , " _
                     & " `nomp` VARCHAR( 200 ) NOT NULL , " _
                     & " `dias` INT NOT NULL , " _
                     & " `valor` DOUBLE NOT NULL , " _
                     & " `totalp` DOUBLE NOT NULL , " _
                     & " `otrosp` DOUBLE NOT NULL , " _
                     & " `totala` DOUBLE NOT NULL , " _
                     & " `otrosa` DOUBLE NOT NULL , " _
                     & " `por_comi` DECIMAL( 10, 2 ) NOT NULL , " _
                     & " `vcomi` DOUBLE NOT NULL , " _
                     & " `por_iva` DECIMAL( 10, 2 ) NOT NULL , " _
                     & " `iva` DOUBLE NOT NULL ,  " _
                     & " `descripcion` TEXT NOT NULL , " _
                     & " `estado` VARCHAR( 2 ) NOT NULL , " _
                     & " `doc_anul` VARCHAR( 15 ) NOT NULL , " _
                     & " `vmto` INT NOT NULL , " _
                    & " PRIMARY KEY (  `doc` ) " _
                    & " ) ENGINE = INNODB; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            Next

        End If
        '/////////////////


        CrearVista()
        If cmdAuditoria.Visible = True Then ' TABLAS AUDITORIA
            Auditoria(bda)
            Auditoria_movimientos()
        End If

        If Exogena.Visible = True Then
            MedioMag(bda)
        End If
        CreateImpuestos(bda)
        'TablaAnticipos(bda)
        ''MoficarCC()
        Cerrar()

    End Sub


    Function tmes(ByVal txt As String)
        Dim ms As String = ""
        If txt = "1" Then
            ms = "ENERO"
        ElseIf txt = "2" Then
            ms = "FEBRERO"
        ElseIf txt = "3" Then
            ms = "MARZO"
        ElseIf txt = "4" Then
            ms = "ABRIL"
        ElseIf txt = "5" Then
            ms = "MAYO"
        ElseIf txt = "6" Then
            ms = "JUNIO"
        ElseIf txt = "7" Then
            ms = "JULIO"
        ElseIf txt = "8" Then
            ms = "AGOSTO"
        ElseIf txt = "9" Then
            ms = "SEPTIEMBRE"
        ElseIf txt = "10" Then
            ms = "OCTUBRE"
        ElseIf txt = "11" Then
            ms = "NOVIEMBRE"
        ElseIf txt = "12" Then
            ms = "DICIEMBRE"
        End If
        Return (ms)
    End Function

    Private Sub AdaptacionDelPUCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCatalogoC.ShowDialog()
    End Sub

    Private Sub NivelesDeCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmParContable.ShowDialog()
    End Sub

    Private Sub CatalogoDeCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmBusquedas.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmDocumentos.ShowDialog()
    End Sub

    Private Sub TercerosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TercerosToolStripMenuItem.Click
        If per_ter = "N" Then
            MsgBox("No tiene los permisos para esta interfaz...", MsgBoxStyle.Information)
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        frmterceros.ShowDialog()
    End Sub

    Private Sub BancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BancosToolStripMenuItem.Click
        'FrmBusquedas.ShowDialog()
    End Sub

    Private Sub CopiaDeSeguridadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiaDeSeguridadToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub GenerarDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarDocumentosToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmEntradaDatos.ShowDialog()
    End Sub

    Private Sub CerrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem1.Click
        End
    End Sub

    Private Sub ToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MiConexion(bda)
        Cerrar()
        FrmDocumentos.ShowDialog()
    End Sub

    Private Sub NivelesDeCuentasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NivelesDeCuentasToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        NivelesDeCuentas()
        FrmParContable.ShowDialog()
    End Sub

    Private Sub AdaptacionDelPUCToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdaptacionDelPUCToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmCatalogoC.ShowDialog()
    End Sub

    Private Sub Facturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Facturacion.Click
        Try


            If ValidarCompa() = False Then Exit Sub
            MiConexion(bda)
            Cerrar()
            If ValidarCompa() = False Then Exit Sub
            MiConexion(bda)
            Cerrar()
            Dim t As New DataTable
            Dim ban As Integer
            myCommand.CommandText = "SHOW TABLES FROM " & bda & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            ban = 0
            For i = 0 To t.Rows.Count - 1
                If t.Rows(i).Item(0) = "detafac" & PerActual(0) & PerActual(1) Then
                    ban = 1
                    Exit For
                End If
            Next
            If ban = 0 Then
                MsgBox("No existen tablas de facturación.", MsgBoxStyle.Critical, "SAE Control")
                Exit Sub
            End If
            frmfacturacion.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TiposDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeDocumentosToolStripMenuItem.Click
        If per_tdoc = "N" Then
            MsgBox("No tiene los permisos para esta interfaz...", MsgBoxStyle.Information)
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmDocumentos.ShowDialog()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturacionToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        frmfacturacion.ShowDialog()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        FrmCambiarPass.lbusuario.Text = UsuarioActual
        FrmCambiarPass.ShowDialog()
    End Sub

    Private Sub CrearNuevaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrearNuevaToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        FrmGestionCompa.ShowDialog()
    End Sub

    Private Sub GestionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestionToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        FrmUsuarios.ShowDialog()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) <= 0 Then
            MsgBox("No hay compañias creadas. Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            Exit Sub
        End If
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "ppal"
        FrmAbrirCompania.ShowDialog()
    End Sub


    '************** VERIFICAR MENUS Y CONEXION ************************
    'MENU PARAMETROS
    Private Sub GeneralesToolStripMenuItem_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles GeneralesToolStripMenuItem.MouseEnter
        If lbcompania.Text = "" Then
            ToolStripMenuItem3.Enabled = False
            ContabilidadToolStripMenuItem.Enabled = False
        Else
            ToolStripMenuItem3.Enabled = True
            ContabilidadToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub DatosGeneralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosGeneralesToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        If ValidarCompa() = False Then Exit Sub
        FrmDatosCompa.ShowDialog()
    End Sub
    Private Sub NuevoAñoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoAñoToolStripMenuItem.Click
        MiConexion("sae")
        Cerrar()
        If ValidarCompa() = False Then Exit Sub
        FrmNuevoAno.ShowDialog()
    End Sub
    Function ValidarCompa()
        If lbcompania.Text = "" Then
            MsgBox("No hay una compañia seleccionada. Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Contabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contabilidad.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        Dim t As New DataTable
        Dim ban As Integer
        myCommand.CommandText = "SHOW TABLES FROM " & bda & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        ban = 0
        For i = 0 To t.Rows.Count - 1
            If t.Rows(i).Item(0) = "documentos00" Then
                ban = 1
                Exit For
            End If
        Next
        If ban = 0 Then
            MsgBox("No existen tablas de contabilidad.", MsgBoxStyle.Critical, "SAE Control")
            Exit Sub
        End If
        FrmContabilidad.ShowDialog()
    End Sub

    'INFORMES
    Private Sub CatalogoDeCuentasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogoDeCuentasToolStripMenuItem1.Click
        MiConexion(bda)
        Cerrar()
        FrmInformeCC.ShowDialog()
    End Sub
    Private Sub BalanceGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceGeneralToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmBalanceGral.ShowDialog()
    End Sub
    Private Sub LibroMayorYDeBalancesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroMayorYDeBalancesToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmLibroMayor.ShowDialog()
    End Sub
    Private Sub EstadoDeResultadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDeResultadosToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmEstadoResultados.ShowDialog()
    End Sub

    Private Sub SaldosInicialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosInicialesToolStripMenuItem.Click
        Dim tablabloq As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".bloq_per WHERE periodo='00' ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablabloq)
        If tablabloq.Rows(0).Item(1) <> "n" Then
            FrmSaldosIniciales.cmdbloquear.Enabled = False
        Else
            FrmSaldosIniciales.cmdbloquear.Enabled = True
        End If
        FrmSaldosIniciales.ShowDialog()
    End Sub

    Private Sub BalanceDePruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceDePruebaToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmBalancePrueba.ShowDialog()
    End Sub

    Private Sub TributariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TributariosToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmInfTributarios.ShowDialog()
    End Sub
    Private Sub AnexosDelBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnexosDelBalanceToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmAnexosBalance.ShowDialog()
    End Sub

    Private Sub BloqueDePeriodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloqueDePeriodosToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmBloquearPeriodos.ShowDialog()
    End Sub

    Private Sub ActualizaciónCatalogoDeCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaciónCatalogoDeCuentasToolStripMenuItem.Click
        FrmActualizarCC.ShowDialog()
    End Sub
    Private Sub BloquearPeriodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloquearPeriodosToolStripMenuItem.Click
        FrmBloquearPeriodos.ShowDialog()
    End Sub
    Private Sub ProcesoFinDeAñoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesoFinDeAñoToolStripMenuItem.Click
        FrmCierreAno.ShowDialog()
    End Sub

    Private Sub Inventarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inventarios.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        Dim t As New DataTable
        Dim ban As Integer
        myCommand.CommandText = "SHOW TABLES FROM " & bda & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        ban = 0
        For i = 0 To t.Rows.Count - 1
            If t.Rows(i).Item(0) = "articulos" Then
                ban = 1
                Exit For
            End If
        Next
        If ban = 0 Then
            MsgBox("No existen tablas de inventarios.", MsgBoxStyle.Critical, "SAE Control")
            Exit Sub
        End If
        FrmInventarios.ShowDialog()
    End Sub
    Private Sub InventariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmInventarios.ShowDialog()
    End Sub

    Private Sub RestaurarCopiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurarCopiaToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmRestaurarCopia.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem1.Click
        FrmAcercaDe.ShowDialog()
    End Sub
    Private Sub CambiarDeServidorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarDeServidorToolStripMenuItem.Click
        FrmConexion.lbform.Text = "ppal"
        FrmConexion.ShowDialog()
        FrmConexion.lbform.Text = ""
    End Sub

    Private Sub BalacesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalacesToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmInve_y_Balances.ShowDialog()
    End Sub

    Private Sub NumeraciónDePáginasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumeraciónDePáginasToolStripMenuItem.Click
        FrmNumPag.ShowDialog()
    End Sub

    Private Sub OtrosDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtrosDocumentosToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        FrmOtrosDocumentos.ShowDialog()
    End Sub

    Private Sub ConfiguraciónEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónEmailToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        FrmConfigEmail.ShowDialog()
    End Sub

    Private Sub ImpuestosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpuestosToolStripMenuItem.Click
        If per_imp = "N" Then
            MsgBox("No tiene los permisos para esta interfaz...", MsgBoxStyle.Information)
            Exit Sub
        End If
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmMenuImp.ShowDialog()
    End Sub

    Private Sub Proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Proveedores.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmCompras.ShowDialog()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Proveedores_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub Cartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cartera.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmCartera.ShowDialog()
    End Sub

    Private Sub CarteraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarteraToolStripMenuItem.Click
        Cartera_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub CambiarContaseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContaseñaToolStripMenuItem.Click
        If ValidarCompa() = False Then Exit Sub
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & Me.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        FrmCambiarContraComp.ShowDialog()
    End Sub

    Private Sub Gerencial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gerencial.Click
        Try

            If ValidarCompa() = False Then Exit Sub
            MiConexion(bda)
            Cerrar()
            FrmGerencial.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GerencialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerencialToolStripMenuItem.Click
        Gerencial_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inmobiliaria.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmInmobiliaria.ShowDialog()
    End Sub

    Private Sub BarrasH_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles BarrasH.ItemClicked

    End Sub

    Private Sub cmdOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOrden.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmOrdenesDePago.ShowDialog()
    End Sub

    Private Sub cmdBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBanco.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmBancos.ShowDialog()
    End Sub
    Private Sub cmdAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAuditoria.Click
        If ValidarCompa() = False Then Exit Sub
        MiConexion(bda)
        Cerrar()
        FrmAuditoria.ShowDialog()
    End Sub

    Private Sub EliminarCompañiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarCompañiaToolStripMenuItem.Click
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) <= 0 Then
            MsgBox("No hay compañias creadas. Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            Exit Sub
        End If
        MostrarCompaniaParaAbrir()
        FrmEliminarComp.ShowDialog()
    End Sub

    Private Sub Nomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nomina.Click


        Archivo = ""
        Dim rutaconex2 As String
        rutaconex2 = My.Application.Info.DirectoryPath & "\nomina.txt"
        If My.Computer.FileSystem.FileExists(rutaconex2) Then
            Nomina.Visible = True
            Archivo = My.Computer.FileSystem.ReadAllText(rutaconex2)
            Archivo = Archivo & "LOGIN?usu=" & LCase(lbuser.Text) & "&clave=" & FrmLogin.txtpasswd.Text & "&compa=" & LCase(lbcompania.Text) & "&par=sae"
        End If

        If Archivo <> "" Then
            Dim proceso As New System.Diagnostics.Process
            With proceso
                .StartInfo.FileName = Archivo
                .Start()
            End With
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exogena.Click
        MiConexion(bda)
        Cerrar()
        FrmMediosMagneticos.ShowDialog()
    End Sub

    Private Sub BEstetica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEstetica.Click
        Try


            If ValidarCompa() = False Then Exit Sub
            MiConexion(bda)
            Cerrar()
            If ValidarCompa() = False Then Exit Sub
            MiConexion(bda)
            Cerrar()
            Dim t As New DataTable
            Dim ban As Integer
            myCommand.CommandText = "SHOW TABLES FROM " & bda & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            ban = 0
            For i = 0 To t.Rows.Count - 1
                If t.Rows(i).Item(0) = "detafac" & PerActual(0) & PerActual(1) Then
                    ban = 1
                    Exit For
                End If
            Next
            If ban = 0 Then
                MsgBox("No existen tablas de facturación.", MsgBoxStyle.Critical, "SAE Control")
                Exit Sub
            End If
            FrmEstetica.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class
