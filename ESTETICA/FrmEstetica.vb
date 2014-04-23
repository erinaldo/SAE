Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Data
Public Class FrmEstetica
    Private Sub frmfacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion("sae")
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap, rol from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)


        If tabla.Rows(0).Item(0) = "S" Then
            cmdCamPer.Visible = True
            cmddes.Visible = True
        Else
            cmdCamPer.Visible = False
            cmddes.Visible = False
        End If

        If tabla.Rows(0).Item(1) = "admin" Then
            cmdfacajus.Visible = True
        Else
            cmdfacajus.Visible = False
        End If

        Cerrar()
        MiConexion(bda)
        CrearVista()
        Dim p As String = ""
        Try
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE  `detafac" & p & "` ADD  `nit` VARCHAR( 15 ) NOT NULL ;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `fapipen` CHANGE `descrip` `descrip` TEXT NOT NULL ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO `vendedores` (`nitv`, `nombre`, `dir`, `telefono`, `estado`, `zona`, `palm`, `codpalm`) VALUES ('0', '[SIN NIT]', '0', '0', 'activo', '', 'no', '');"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            Dim pf As String
            For i = 1 To 12
                If i < 10 Then
                    pf = "0" & i
                Else
                    pf = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE facturas" & pf & " ADD `cc` BIGINT NOT NULL ;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try

        ' Agregar campos descuento por articulos 
        Dim per As String
        For i = 1 To 12
            If i < 10 Then
                per = "0" & i
            Else
                per = i
            End If
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "  ALTER TABLE  `detafac" & per & "` ADD  `por_des` DECIMAL( 10, 2 ) NOT NULL DEFAULT  '0' AFTER `iva_d` ; "
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE  `parafacgral` ADD  `reteica` VARCHAR( 15 ) DEFAULT NULL ,ADD  `reteiva` VARCHAR( 15 ) DEFAULT NULL;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE  `parafacts` ADD  `comentario` TEXT NOT NULL ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE  `parafacgral` ADD  `lista_art` VARCHAR( 10 ) NOT NULL DEFAULT  'SI' ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  `parafacgral` ADD  `lista_pre` VARCHAR( 3 ) NOT NULL DEFAULT  'SI';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  `parafacts` ADD  `bus_cli` VARCHAR( 3 ) NOT NULL DEFAULT  'N';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  `parafacgral` ADD  `Guar_Ap` VARCHAR( 2 ) NOT NULL DEFAULT  'N';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  ALTER TABLE  `parafacts` ADD  `GuarNumFac` VARCHAR( 2 ) NOT NULL DEFAULT  'N';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        ActualizarPrefijo(bda)
        Act_lis_ser()
        AcualizarT()
        Cerrar()
    End Sub
    Public Sub Act_lis_ser()
        Try
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS `lista_cliente` (" _
                                  & "`numlist` int(11) NOT NULL,`nitc` varchar(20) NOT NULL," _
                                  & "UNIQUE KEY `nitc` (`nitc`));"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `servicios` ADD `pventa2` DOUBLE NOT NULL DEFAULT '0' AFTER `pventa` ," _
                                  & "ADD `pventa3` DOUBLE NOT NULL DEFAULT '0' AFTER `pventa2` ," _
                                  & "ADD `pventa4` DOUBLE NOT NULL DEFAULT '0' AFTER `pventa3` ," _
                                  & "ADD `pventa5` DOUBLE NOT NULL DEFAULT '0' AFTER `pventa4` ," _
                                  & "ADD `pventa6` DOUBLE NOT NULL DEFAULT '0' AFTER `pventa5` ;"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bda & ".`listasprec` (`numlist` int(11) NOT NULL AUTO_INCREMENT,`nomlist` varchar(70) NOT NULL, PRIMARY KEY (`numlist`));"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub AcualizarT()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `parafacts` ADD `imp_dec` CHAR( 1 ) NOT NULL DEFAULT 'S';"
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
            myCommand.Parameters.Clear()
            myCommand.CommandText = "ALTER TABLE `facturas" & per & "` ADD `o_con` VARCHAR( 2 ) NOT NULL DEFAULT 'no'," _
            & "ADD `t1` CHAR( 1 ) NOT NULL ,ADD `d1` VARCHAR( 100 ) NOT NULL ,ADD `v1` DOUBLE NOT NULL ,ADD `cta1` VARCHAR( 15 ) NOT NULL ," _
            & "ADD `t2` CHAR( 1 ) NOT NULL ,ADD `d2` VARCHAR( 100 ) NOT NULL ,ADD `v2` DOUBLE NOT NULL ,ADD `cta2` VARCHAR( 15 ) NOT NULL ," _
            & "ADD `t3` CHAR( 1 ) NOT NULL ,ADD `d3` VARCHAR( 100 ) NOT NULL ,ADD `v3` DOUBLE NOT NULL ,ADD `cta3` VARCHAR( 15 ) NOT NULL ;" _
            & "ALTER TABLE `facpagos" & per & "` CHANGE `valor` `valor` DOUBLE NOT NULL;"
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                Exit Sub 'ya fué actualizada
            End Try
        Next
    End Sub
    '////////////////////////////////////////////
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub
    Private Sub cmdfactrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactrap.Click
        MiConexion(bda)
        Cerrar()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM parafacgral LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros generales definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Exit Sub
        Else
            tabla.Clear()
            myCommand.CommandText = " SELECT factura FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay parametros de factura rapida definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
                Exit Sub
            End If
        End If
        CargarComboTipoDoc("frs")
        Try
            FrmFacturaEstetica.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub frmfacturacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FrmPrincipal.Focus()
    End Sub
    '***************************************************
    Private Sub cmdperio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperio.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
    End Sub
    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub
    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "EXPLORADOR WEB"
        FrmWEB.ShowDialog()
    End Sub
    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub
    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Facturacion.pdf"
        Try
            If (ruta IsNot Nothing) Then
                Try
                    AbrirArchivo(ruta)
                Catch ex As Exception
                    AbrirArchivo(ruta)
                End Try
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmdfacpargral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfacpargral.Click
        MiConexion(bda)
        Cerrar()

        'MiConexion(bda)
        '' .............. ROL ADMIN S&S
        'Dim ta As New DataTable
        'myCommand.CommandText = " SELECT rol FROM  sae.usuarios WHERE login ='" & FrmPrincipal.lbuser.Text & "';"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(ta)
        'Refresh()
        'If ta.Rows(0).Item(0) <> "admin" Then
        '    FrmParametrosFact.grprecio.Enabled = False
        '    myCommand.Parameters.Clear()
        '    myCommand.CommandText = "UPDATE parafacgral SET lista_pre = 'NO';"
        '    myCommand.ExecuteNonQuery()
        'Else
        '    FrmParametrosFact.grprecio.Enabled = True
        'End If
        ''........................
        'Cerrar()

        Dim items As Integer
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = " SELECT * FROM parafacgral LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            FrmParametrosFact.lb.Text = "NUEVO"
            FrmParametrosFact.txttipo1.Text = ""
            FrmParametrosFact.txttipo2.Text = ""
            FrmParametrosFact.txttipo3.Text = ""
            FrmParametrosFact.txttipo4.Text = ""
            FrmParametrosFact.txtajust.Text = ""
            FrmParametrosFact.txtn1.Enabled = True
            FrmParametrosFact.txtn2.Enabled = True
            FrmParametrosFact.txtn3.Enabled = True
            FrmParametrosFact.txtn3.Enabled = True
            FrmParametrosFact.cbres1.Text = "NO"
            FrmParametrosFact.cbres2.Text = "NO"
            FrmParametrosFact.cbres3.Text = "NO"
            FrmParametrosFact.cbres4.Text = "NO"
            FrmParametrosFact.fecexp1.Value = Today
            FrmParametrosFact.fecexp2.Value = Today
            FrmParametrosFact.fecexp3.Value = Today
            FrmParametrosFact.fecexp4.Value = Today
            FrmParametrosFact.feclim1.Value = Today
            FrmParametrosFact.feclim2.Value = Today
            FrmParametrosFact.feclim3.Value = Today
            FrmParametrosFact.feclim4.Value = Today
            '***********************************
            FrmParametrosFact.rbf1.Checked = True
            FrmParametrosFact.rbiva1.Checked = True
            FrmParametrosFact.rbcomi2.Checked = True
            '***************************************
            FrmParametrosFact.rbcont2.Checked = True
            FrmParametrosFact.txtcaja.Text = ""
            FrmParametrosFact.txtbanco.Text = ""
            FrmParametrosFact.txtctapc.Text = ""
            FrmParametrosFact.txtinventario.Text = ""
            FrmParametrosFact.txtventas.Text = ""
            FrmParametrosFact.txtcosto.Text = ""
            FrmParametrosFact.txtivapp.Text = ""
            FrmParametrosFact.txtivad.Text = ""
            FrmParametrosFact.txtvalorivap.Text = ""
            FrmParametrosFact.txtvalorivad.Text = ""
            FrmParametrosFact.txtdescuento.Text = ""
            FrmParametrosFact.txtretfuente.Text = ""
            FrmParametrosFact.txtreteica.Text = ""
            FrmParametrosFact.txtreteiva.Text = ""
            FrmParametrosFact.ShowDialog()
            Exit Sub
        End If

        CargarListasDePrecios()
        FrmParametrosFact.lb.Text = ""
        FrmParametrosFact.txttipo1.Text = tabla.Rows(0).Item("tipof1")
        FrmParametrosFact.txttipo2.Text = tabla.Rows(0).Item("tipof2")
        FrmParametrosFact.txttipo3.Text = tabla.Rows(0).Item("tipof3")
        FrmParametrosFact.txttipo4.Text = tabla.Rows(0).Item("tipof4")
        FrmParametrosFact.txtajust.Text = tabla.Rows(0).Item("tipoaj")
        FrmParametrosFact.txtn1.Text = NumeroDoc(tabla.Rows(0).Item("a_f1"))
        FrmParametrosFact.txtn2.Text = NumeroDoc(tabla.Rows(0).Item("a_f2"))
        FrmParametrosFact.txtn3.Text = NumeroDoc(tabla.Rows(0).Item("a_f3"))
        FrmParametrosFact.txtn4.Text = NumeroDoc(tabla.Rows(0).Item("a_f4"))
        FrmParametrosFact.txtn1.Enabled = False
        FrmParametrosFact.txtn2.Enabled = False
        FrmParametrosFact.txtn3.Enabled = False
        FrmParametrosFact.txtn4.Enabled = False
        '*************** RESOLUCION DIAN*********************************
        FrmParametrosFact.cbres1.Text = tabla.Rows(0).Item("hr1")
        FrmParametrosFact.cbres2.Text = tabla.Rows(0).Item("hr2")
        FrmParametrosFact.cbres3.Text = tabla.Rows(0).Item("hr3")
        FrmParametrosFact.cbres4.Text = tabla.Rows(0).Item("hr4")
        FrmParametrosFact.reso1.Text = tabla.Rows(0).Item("reso1")
        FrmParametrosFact.reso2.Text = tabla.Rows(0).Item("reso2")
        FrmParametrosFact.reso3.Text = tabla.Rows(0).Item("reso3")
        FrmParametrosFact.reso4.Text = tabla.Rows(0).Item("reso4")
        FrmParametrosFact.fecexp1.Value = tabla.Rows(0).Item("fecexp1")
        FrmParametrosFact.fecexp2.Value = tabla.Rows(0).Item("fecexp2")
        FrmParametrosFact.fecexp3.Value = tabla.Rows(0).Item("fecexp3")
        FrmParametrosFact.fecexp4.Value = tabla.Rows(0).Item("fecexp4")
        FrmParametrosFact.feclim1.Value = tabla.Rows(0).Item("feclim1")
        FrmParametrosFact.feclim2.Value = tabla.Rows(0).Item("feclim2")
        FrmParametrosFact.feclim3.Value = tabla.Rows(0).Item("feclim3")
        FrmParametrosFact.feclim4.Value = tabla.Rows(0).Item("feclim4")
        FrmParametrosFact.ini1.Value = Val(tabla.Rows(0).Item("ini1"))
        FrmParametrosFact.ini2.Value = Val(tabla.Rows(0).Item("ini2"))
        FrmParametrosFact.ini3.Value = Val(tabla.Rows(0).Item("ini3"))
        FrmParametrosFact.ini4.Value = Val(tabla.Rows(0).Item("ini4"))
        FrmParametrosFact.fin1.Value = Val(tabla.Rows(0).Item("fin1"))
        FrmParametrosFact.fin2.Value = Val(tabla.Rows(0).Item("fin2"))
        FrmParametrosFact.fin3.Value = Val(tabla.Rows(0).Item("fin3"))
        FrmParametrosFact.fin4.Value = Val(tabla.Rows(0).Item("fin4"))
        FrmParametrosFact.pre1.Text = tabla.Rows(0).Item("pre1")
        FrmParametrosFact.pre2.Text = tabla.Rows(0).Item("pre2")
        FrmParametrosFact.pre3.Text = tabla.Rows(0).Item("pre3")
        FrmParametrosFact.pre4.Text = tabla.Rows(0).Item("pre4")
        '************************************************
        If tabla.Rows(0).Item("formcosto") = "1" Then
            FrmParametrosFact.rbf1.Checked = True
        ElseIf tabla.Rows(0).Item("formcosto") = "2" Then
            FrmParametrosFact.rbf2.Checked = True
        Else
            FrmParametrosFact.rbf3.Checked = True
        End If
        If tabla.Rows(0).Item("ivainclu") = "SI" Then
            FrmParametrosFact.rbiva1.Checked = True
        ElseIf tabla.Rows(0).Item("ivainclu") = "NO" Then
            FrmParametrosFact.rbiva2.Checked = True
        End If
        If tabla.Rows(0).Item("comventa") = "SI" Then
            FrmParametrosFact.rbcomi1.Checked = True
        ElseIf tabla.Rows(0).Item("comventa") = "NO" Then
            FrmParametrosFact.rbcomi2.Checked = True
        End If
        If tabla.Rows(0).Item("intecontab") = "SI" Then
            Try
                FrmParametrosFact.rbcont1.Checked = True
                FrmParametrosFact.txtcaja.Text = tabla.Rows(0).Item("caja")
                FrmParametrosFact.txtbanco.Text = tabla.Rows(0).Item("bancos")
                FrmParametrosFact.txtctapc.Text = tabla.Rows(0).Item("ctapc")
                FrmParametrosFact.txtinventario.Text = tabla.Rows(0).Item("inventario")
                FrmParametrosFact.txtventas.Text = tabla.Rows(0).Item("ventas")
                FrmParametrosFact.txtcosto.Text = tabla.Rows(0).Item("costoventa")
                FrmParametrosFact.txtivapp.Text = tabla.Rows(0).Item("ivapp")
                FrmParametrosFact.txtivad.Text = tabla.Rows(0).Item("ivadesc")
                FrmParametrosFact.txtvalorivap.Text = tabla.Rows(0).Item("porivapp")
                FrmParametrosFact.txtvalorivad.Text = tabla.Rows(0).Item("porivadesc")
                FrmParametrosFact.txtdescuento.Text = tabla.Rows(0).Item("descuento")
                FrmParametrosFact.txtretfuente.Text = tabla.Rows(0).Item("retfuente")
                FrmParametrosFact.txtreteica.Text = tabla.Rows(0).Item("reteica")
                FrmParametrosFact.txtreteiva.Text = tabla.Rows(0).Item("reteiva")
            Catch ex As Exception
            End Try
        ElseIf tabla.Rows(0).Item("intecontab") = "NO" Then
            FrmParametrosFact.rbcont2.Checked = True
        End If
        If tabla.Rows(0).Item("lista_art") = "SI" Then
            FrmParametrosFact.rbListA1.Checked = True
        Else
            FrmParametrosFact.rbListA2.Checked = True
        End If
        If tabla.Rows(0).Item("lista_pre") = "SI" Then
            FrmParametrosFact.rbPre1.Checked = True
        Else
            FrmParametrosFact.rbPre2.Checked = True
        End If
        If tabla.Rows(0).Item("Guar_Ap") = "N" Then
            FrmParametrosFact.rbAp_n.Checked = True
        Else
            FrmParametrosFact.rbAp_s.Checked = True
        End If

        '////////////////////   PARA AUDITORIA
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            If tabla.Rows(0).Item("formcosto") = "1" Then
                FrmParametrosFact.rbf11.Checked = True
            ElseIf tabla.Rows(0).Item("formcosto") = "2" Then
                FrmParametrosFact.rbf12.Checked = True
            Else
                FrmParametrosFact.rbf13.Checked = True
            End If
            '..
            If tabla.Rows(0).Item("ivainclu") = "SI" Then
                FrmParametrosFact.rbiva11.Checked = True
            ElseIf tabla.Rows(0).Item("ivainclu") = "NO" Then
                FrmParametrosFact.rbiva22.Checked = True
            End If
            '..
            If tabla.Rows(0).Item("Guar_Ap") = "N" Then
                FrmParametrosFact.rbAp_n1.Checked = True
            Else
                FrmParametrosFact.rbAp_s1.Checked = True
            End If
            '..
            If tabla.Rows(0).Item("lista_art") = "SI" Then
                FrmParametrosFact.rbListA11.Checked = True
            Else
                FrmParametrosFact.rbListA22.Checked = True
            End If
            '..
            If tabla.Rows(0).Item("lista_pre") = "SI" Then
                FrmParametrosFact.rbpre11.Checked = True
            Else
                FrmParametrosFact.rbpre22.Checked = True
            End If
        End If

        FrmParametrosFact.ShowDialog()
    End Sub
    Public Sub CargarListasDePrecios()
        'Dim items As Integer
        'Dim tabla As New DataTable
        'myCommand.CommandText = " SELECT * FROM `listasprec` ORDER BY numlist;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        'Refresh()
        'items = tabla.Rows.Count
        'If items = 0 Then
        '    FrmParametrosFact.gitems.RowCount = 1
        '    FrmParametrosFact.gitems.Item(0, 0).Value = "1"
        '    FrmParametrosFact.gitems.Item(1, 0).Value = ""
        'Else
        '    FrmParametrosFact.gitems.RowCount = items
        '    For i = 0 To items - 1
        '        FrmParametrosFact.gitems.Item(0, i).Value = tabla.Rows(i).Item(0)
        '        FrmParametrosFact.gitems.Item(1, i).Value = tabla.Rows(i).Item(1)
        '    Next
        'End If
    End Sub
    Private Sub cmdparfacrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparfacrap.Click
        MiConexion(bda)
        Cerrar()
        FrmParaFactRapida.lbfact.Text = "RAPIDA"
        CargarComboTipoDoc("pf")
        BuscarParametrosDeFacturas("RAPIDA")
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = False
        FrmParaFactRapida.Tab3.Visible = False
        FrmParaFactRapida.cmdatras.Enabled = False
        FrmParaFactRapida.cmdsgt.Enabled = True
        FrmParaFactRapida.cmdatras.Text = ""
        FrmParaFactRapida.cmdsgt.Text = "&S"
        FrmParaFactRapida.gped.Enabled = True
        FrmParaFactRapida.gcot.Enabled = True
        FrmParaFactRapida.ShowDialog()
    End Sub
    Private Sub cmdfactnormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactnormal.Click
        FrmParaFactRapida.lbfact.Text = "NORMAL"
        CargarComboTipoDoc("pf")
        BuscarParametrosDeFacturas("NORMAL")
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = False
        FrmParaFactRapida.Tab3.Visible = False
        FrmParaFactRapida.cmdatras.Enabled = False
        FrmParaFactRapida.cmdsgt.Enabled = True
        FrmParaFactRapida.cmdatras.Text = ""
        FrmParaFactRapida.cmdsgt.Text = "&S"
        FrmParaFactRapida.gped.Enabled = False
        FrmParaFactRapida.gcot.Enabled = False
        FrmParaFactRapida.ShowDialog()
    End Sub
    Public Sub CargarComboTipoDoc(ByVal formu As String)
        Try
            If formu = "pf" Then
                FrmParaFactRapida.txttipo.Items.Clear()
            ElseIf formu = "fn" Then
                FrmFacturasyAjustes.txttipo.Items.Clear()
            ElseIf formu = "fn_sp" Then
                FrmFacturasyAjustesSP.txttipo.Items.Clear()
            ElseIf formu = "fr" Then
                Frmfacturarapida.txttipo.Items.Clear()
            ElseIf formu = "frs" Then
                FrmFacturaEstetica.txttipo.Items.Clear()
            End If
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4,tipoaj FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            If Trim(tabla.Rows(0).Item("tipof1")) <> "" Then
                If formu = "pf" Then
                    FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                ElseIf formu = "fn" Then
                    FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                ElseIf formu = "fn_sp" Then
                    FrmFacturasyAjustesSP.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                ElseIf formu = "fr" Then
                    Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                ElseIf formu = "frs" Then
                    FrmFacturaEstetica.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                End If
            End If
            If Trim(tabla.Rows(0).Item("tipof2")) <> "" Then
                If formu = "pf" Then
                    FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                ElseIf formu = "fn" Then
                    FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                ElseIf formu = "fn_sp" Then
                    FrmFacturasyAjustesSP.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                ElseIf formu = "fr" Then
                    Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                ElseIf formu = "frs" Then
                    FrmFacturaEstetica.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                End If
            End If
            If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
                If formu = "pf" Then
                    FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                ElseIf formu = "fn" Then
                    FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                ElseIf formu = "fn_sp" Then
                    FrmFacturasyAjustesSP.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                ElseIf formu = "fr" Then
                    Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                ElseIf formu = "frs" Then
                    FrmFacturaEstetica.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                End If
            End If
            If Trim(tabla.Rows(0).Item("tipof4")) <> "" Then
                If formu = "pf" Then
                    FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                ElseIf formu = "fn" Then
                    FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                ElseIf formu = "fn_sp" Then
                    FrmFacturasyAjustesSP.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                ElseIf formu = "fr" Then
                    Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                ElseIf formu = "frs" Then
                    FrmFacturaEstetica.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                End If
            End If
            If Trim(tabla.Rows(0).Item("tipoaj")) <> "" Then
                If formu = "pf" And FrmParaFactRapida.lbfact.Text = "NORMAL" Then
                    FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
                ElseIf formu = "fn" Then
                    FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
                    FrmFacturasyAjustes.lbdocajuste.Text = Trim(tabla.Rows(0).Item("tipoaj"))
                ElseIf formu = "fn_sp" Then
                    FrmFacturasyAjustesSP.txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
                    'FrmFacturasyAjustesSP.lbdocajuste.Text = Trim(tabla.Rows(0).Item("tipoaj"))
                ElseIf formu = "fr" Then
                    Frmfacturarapida.lbdocajuste.Text = Trim(tabla.Rows(0).Item("tipoaj"))
                ElseIf formu = "frs" Then
                    FrmFacturaEstetica.lbdocajuste.Text = Trim(tabla.Rows(0).Item("tipoaj"))
                End If
            End If
            ''''''''''''''''''COMBO BODEGA ''''''''''''''
            If formu = "pf" Then
                tabla.Clear()
                Dim items As Integer
                myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items > 0 Then
                    FrmParaFactRapida.txtbodega.Text = ""
                    FrmParaFactRapida.cbbod.Items.Clear()
                    For i = 0 To items - 1
                        FrmParaFactRapida.cbbod.Items.Add(tabla.Rows(i).Item("numbod"))
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarParametrosDeFacturas(ByVal factura As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='" & factura & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmParaFactRapida.lbpara.Text = "Nota: No hay parametros en los registos."
            PonerEnCero()
            Exit Sub
        End If
        FrmParaFactRapida.lbpara.Text = ""
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = True
        FrmParaFactRapida.Tab3.Visible = True
        '/////// PRIMERA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item("doc")) = "S" Then
            FrmParaFactRapida.rbdoc1.Checked = True
            FrmParaFactRapida.txttipo.Text = tabla.Rows(0).Item("tipodoc")
        Else
            FrmParaFactRapida.rbdoc2.Checked = True
            FrmParaFactRapida.txttipo.Text = ""
            FrmParaFactRapida.txttipo2.Text = ""
        End If
        If Trim(tabla.Rows(0).Item("numfact")) = "manual" Then
            FrmParaFactRapida.rbnumf2.Checked = True
        Else
            FrmParaFactRapida.rbnumf.Checked = True
        End If
        If Trim(tabla.Rows(0).Item("afecinv")) = "S" Then
            FrmParaFactRapida.rbinv.Checked = True
        Else
            FrmParaFactRapida.rbinv2.Checked = True
        End If

        If Trim(tabla.Rows(0).Item("fecha")) = "automatico" Then 'fecha
            FrmParaFactRapida.rbfec1.Checked = True
        ElseIf Trim(tabla.Rows(0).Item("fecha")) = "manual" Then
            FrmParaFactRapida.rbfec2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item("nitcpre")) = "S" Then  'cliente
            FrmParaFactRapida.rbclie.Checked = True
            FrmParaFactRapida.txtnitc.Text = tabla.Rows(0).Item("nitc")
        Else
            FrmParaFactRapida.rbclie2.Checked = True
            FrmParaFactRapida.txtnitc.Text = ""
            FrmParaFactRapida.txtcliente.Text = ""
        End If
        If Trim(tabla.Rows(0).Item("nitvpre")) = "S" Then  'vedendor
            FrmParaFactRapida.rbvendedor.Checked = True
            FrmParaFactRapida.txtnitv.Text = tabla.Rows(0).Item("nitv")
        Else
            FrmParaFactRapida.rbvendedor2.Checked = True
            FrmParaFactRapida.txtnitv.Text = ""
            FrmParaFactRapida.txtvendedor.Text = ""
        End If
        '/////// SEGUNDA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item("codinv")) = "S" Then 'codigo inventario
            FrmParaFactRapida.rbcodinv.Checked = True
        Else
            FrmParaFactRapida.rbcodinv2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item("centrocost")) = "S" Then '
            FrmParaFactRapida.rbcentro.Checked = True
        Else
            FrmParaFactRapida.rbcentro2.Checked = True
        End If
        ''''''
        If Trim(tabla.Rows(0).Item("facdifuniemp")) = "S" Then 'Facturar diferentes unidades de empaque
            FrmParaFactRapida.rbfacdifuniemp.Checked = True
            If Trim(tabla.Rows(0).Item("precautcant")) = "S" Then
                FrmParaFactRapida.ChPA.Checked = True
            Else
                FrmParaFactRapida.ChPA.Checked = False
            End If
        Else
            FrmParaFactRapida.rbfacdifuniemp2.Checked = True
            FrmParaFactRapida.ChPA.Checked = False
        End If
        ''''''''''''
        If Trim(tabla.Rows(0).Item("bodpred")) = "S" Then 'BODEGA
            FrmParaFactRapida.rbbodpre.Checked = True
            FrmParaFactRapida.cbbod.Text = tabla.Rows(0).Item("idbod")
        Else
            FrmParaFactRapida.rbbodpre2.Checked = True
            FrmParaFactRapida.cbbod.Text = ""
        End If
        If Trim(tabla.Rows(0).Item("margmin")) = "S" Then 'MARGEN
            FrmParaFactRapida.rbmarg.Checked = True
            FrmParaFactRapida.txtmargen.Text = tabla.Rows(0).Item("margen")
        Else
            FrmParaFactRapida.rbmarg2.Checked = True
            FrmParaFactRapida.txtmargen.Text = ""
        End If
        If Trim(tabla.Rows(0).Item("concomipre")) = "S" Then 'CONCEPTO COMICIONABLE
            FrmParaFactRapida.rbcc.Checked = True
            FrmParaFactRapida.txtcc.Text = tabla.Rows(0).Item("concomi")
        Else
            FrmParaFactRapida.rbcc2.Checked = True
            FrmParaFactRapida.txtcc.Text = tabla.Rows(0).Item("concomi")
        End If
        If Trim(tabla.Rows(0).Item("fpagopre")) = "S" Then 'FORMA DE PAGO
            FrmParaFactRapida.rbfp.Checked = True
            If Trim(tabla.Rows(0).Item("cualfp")) = "cheque" Then
                FrmParaFactRapida.rbcualfp1.Checked = True
            ElseIf Trim(tabla.Rows(0).Item("cualfp")) = "tarjeta" Then
                FrmParaFactRapida.rbcualfp2.Checked = True
            ElseIf Trim(tabla.Rows(0).Item("cualfp")) = "efectivo" Then
                FrmParaFactRapida.rbcualfp3.Checked = True
            ElseIf Trim(tabla.Rows(0).Item("cualfp")) = "otra" Then
                FrmParaFactRapida.rbcualfp4.Checked = True
            End If
        Else
            FrmParaFactRapida.rbfp2.Checked = True
        End If
        '/////// TERCERA PAGINA ///////////////////////////
        If tabla.Rows(0).Item("formatfac") = "pdf" Then
            FrmParaFactRapida.pdffac.Checked = True
            Try
                FrmParaFactRapida.imgfoto.Image = Bytes_Imagen(tabla.Rows(0).Item("logofac"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto.Image = Nothing
            End Try
        ElseIf tabla.Rows(0).Item("formatfac") = "pdf2" Then
            FrmParaFactRapida.pdffac2.Checked = True
            Try
                FrmParaFactRapida.imgfoto.Image = Bytes_Imagen(tabla.Rows(0).Item("logofac"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto.Image = Nothing
            End Try
        Else
            FrmParaFactRapida.ticfac.Checked = True
            FrmParaFactRapida.imgfoto.Image = Nothing
        End If
        If tabla.Rows(0).Item("formatped") = "pdf" Then
            FrmParaFactRapida.pdfped.Checked = True
            Try
                FrmParaFactRapida.imgfoto2.Image = Bytes_Imagen(tabla.Rows(0).Item("logoped"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto2.Image = Nothing
            End Try
        ElseIf tabla.Rows(0).Item("formatped") = "pdf2" Then
            FrmParaFactRapida.pdfped2.Checked = True
            Try
                FrmParaFactRapida.imgfoto2.Image = Bytes_Imagen(tabla.Rows(0).Item("logoped"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto2.Image = Nothing
            End Try
        Else
            FrmParaFactRapida.ticped.Checked = True
            FrmParaFactRapida.imgfoto2.Image = Nothing
        End If
        If tabla.Rows(0).Item("formatcot") = "pdf" Then
            FrmParaFactRapida.pdfcot.Checked = True
            Try
                FrmParaFactRapida.imgfoto3.Image = Bytes_Imagen(tabla.Rows(0).Item("logocot"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto3.Image = Nothing
            End Try
        ElseIf tabla.Rows(0).Item("formatcot") = "pdf2" Then
            FrmParaFactRapida.pdfcot2.Checked = True
            Try
                FrmParaFactRapida.imgfoto3.Image = Bytes_Imagen(tabla.Rows(0).Item("logocot"))
            Catch ex As Exception
                FrmParaFactRapida.imgfoto3.Image = Nothing
            End Try
        Else
            FrmParaFactRapida.ticcot.Checked = True
            FrmParaFactRapida.imgfoto3.Image = Nothing
        End If
        FrmParaFactRapida.cbregimen.Text = tabla.Rows(0).Item("tipocompa")
        FrmParaFactRapida.txtcomentario.Text = tabla.Rows(0).Item("comentario")
        Try
            If Trim(tabla.Rows(0).Item("imp_dec")) = "S" Then  'vedendor
                FrmParaFactRapida.rb_imp_decS.Checked = True
            Else
                FrmParaFactRapida.rb_imp_decN.Checked = True
            End If
        Catch ex As Exception
            FrmParaFactRapida.rb_imp_decS.Checked = True
        End Try
        Try
            If Trim(tabla.Rows(0).Item("bus_cli")) = "N" Then  ' BUSCAR CLIENTE
                FrmParaFactRapida.rbBNit.Checked = True
            Else
                FrmParaFactRapida.rbBAp.Checked = True
            End If
        Catch ex As Exception
            FrmParaFactRapida.rb_imp_decS.Checked = True
        End Try
        Try
            If Trim(tabla.Rows(0).Item("GuarNumFac")) = "N" Then  ' BUSCAR GUARDAR No FAC AL DAR CLICK EN NUEVO
                FrmParaFactRapida.rdnf_n.Checked = True
            Else
                FrmParaFactRapida.rdnf_s.Checked = True
            End If
        Catch ex As Exception
            FrmParaFactRapida.rdnf_n.Checked = True
        End Try
        FrmParaFactRapida.txtcomentarioini.Text = tabla.Rows(0).Item("comentario_ini")
    End Sub
    Public Sub PonerEnCero()
        '/////// PRIMERA PAGINA ///////////////////////////
        FrmParaFactRapida.rbdoc2.Checked = True
        FrmParaFactRapida.txttipo.Text = ""
        FrmParaFactRapida.txttipo2.Text = ""
        FrmParaFactRapida.rbnumf.Checked = True
        FrmParaFactRapida.rbinv.Checked = True
        FrmParaFactRapida.rbfec1.Checked = True
        FrmParaFactRapida.rbclie2.Checked = True
        FrmParaFactRapida.txtnitc.Text = ""
        FrmParaFactRapida.txtcliente.Text = ""
        FrmParaFactRapida.rbvendedor2.Checked = True
        FrmParaFactRapida.txtnitv.Text = ""
        FrmParaFactRapida.txtvendedor.Text = ""
        '/////// SEGUNDA PAGINA ///////////////////////////
        FrmParaFactRapida.rbcodinv2.Checked = True
        FrmParaFactRapida.rbcentro2.Checked = True
        FrmParaFactRapida.rbfacdifuniemp2.Checked = True
        FrmParaFactRapida.ChPA.Checked = False
        FrmParaFactRapida.rbbodpre2.Checked = True
        FrmParaFactRapida.cbbod.Text = ""
        FrmParaFactRapida.rbmarg2.Checked = True
        FrmParaFactRapida.txtmargen.Text = ""
        FrmParaFactRapida.rbcc2.Checked = True
        FrmParaFactRapida.txtcc.Text = ""
        FrmParaFactRapida.rbfp.Checked = True
        FrmParaFactRapida.rbcualfp3.Checked = True
        '/////// TERCERA PAGINA ///////////////////////////
        FrmParaFactRapida.pdffac.Checked = True
        FrmParaFactRapida.imgfoto.Image = Nothing
        FrmParaFactRapida.pdfped.Checked = True
        FrmParaFactRapida.imgfoto2.Image = Nothing
        FrmParaFactRapida.pdfcot.Checked = True
        FrmParaFactRapida.imgfoto3.Image = Nothing
        '****************
        FrmParaFactRapida.cbregimen.Text = ""
        FrmParaFactRapida.txtcomentario.Text = ""
        '*****************************
        FrmParaFactRapida.rb_imp_decS.Checked = True
    End Sub
    Private Sub cdmdatvend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmdatvend.Click
        FrmVendedores.ShowDialog()
    End Sub
    Private Sub cmdconcomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdconcomi.Click
        FrmConceptosComicionables.ShowDialog()
    End Sub
    '////////////////////////////////////////////
    Private Sub cmdentped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdentped.Click
        FrmEntraPedidos.lblform.Text = "Pedido"
        FrmEntraPedidos.Text = "SAE PEDIDOS / COTIZACIONES"
        FrmEntraPedidos.Label2.Text = "Pedido Número"
        FrmEntraPedidos.cmbtipo.Enabled = True
        FrmEntraPedidos.ShowDialog()
    End Sub
    Private Sub cmdfacajus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfacajus.Click
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM parafacgral LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros generales definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Exit Sub
        Else
            tabla.Clear()
            myCommand.CommandText = " SELECT factura FROM parafacts WHERE factura='NORMAL';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay parametros de factura definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
                Exit Sub
            End If
        End If
        CargarComboTipoDoc("fn")
        FrmFacturasyAjustes.ShowDialog()


        'CargarComboTipoDoc("fn_sp")
        'FrmFacturasyAjustesSP.ShowDialog()
    End Sub
    Private Sub rapido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub
    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "factura"
        FrmAbrirCompania.ShowDialog()
        MiConexion(bda)
        Cerrar()
    End Sub
    'articulos
    Function VerificarArticulos()
        MiConexion(bda)
        Cerrar()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = " SELECT count(*) FROM articulos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows(0).Item(0) < 1 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub cmdpre_art_inv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpre_art_inv.Click
        MiConexion(bda)
        Cerrar()
        If VerificarArticulos() = False Then
            MsgBox("No hay articulos de inventarios.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            If FrmPrincipal.Inventarios.Enabled = True Then
                FrmProductos.ShowDialog()
            Else
                FrmProductos.cmdNuevo.Enabled = False
                FrmProductos.cmdguardar.Enabled = False
                FrmProductos.cmdcancelar.Enabled = False
                FrmProductos.cmdmodificar.Enabled = False
                FrmProductos.ShowDialog()
                FrmProductos.cmdNuevo.Enabled = True
                FrmProductos.cmdguardar.Enabled = True
                FrmProductos.cmdcancelar.Enabled = True
                FrmProductos.cmdmodificar.Enabled = True
            End If
        End If
    End Sub
    Private Sub cmd_precio_costo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_precio_costo.Click
        MiConexion(bda)
        Cerrar()
        If VerificarArticulos() = False Then
            MsgBox("No hay articulos de inventarios.  ", MsgBoxStyle.Information, "SAE Control")
        Else
        End If
    End Sub
    Private Sub cmd_lista_art_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_lista_art.Click
        MiConexion(bda)
        Cerrar()
        If VerificarArticulos() = False Then
            MsgBox("No hay articulos de inventarios.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            FrmInfoListaPreciosArt.ShowDialog()
        End If
    End Sub
    'servicios
    Private Sub cmd_ser_items_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ser_items.Click
        MiConexion(bda)
        Cerrar()
        FrmServicios.ShowDialog()
    End Sub
    Private Sub cmd_inc_pre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inc_pre.Click
        MiConexion(bda)
        Cerrar()
    End Sub
    Private Sub cmd_lista_serv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_lista_serv.Click
        MiConexion(bda)
        Cerrar()
        InfServicios()
    End Sub
    Private Sub cmdinftp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinftp.Click
        MiConexion(bda)
        Cerrar()
        ListaPedidos()
    End Sub

    Private Sub cmd_imp_tipodoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmd_anular_facts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmd_info_consec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_consec.Click
        MiConexion(bda)
        Cerrar()
        Frminfoconse.ShowDialog()
    End Sub

    Private Sub cmd_info_art_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_art.Click
        MiConexion(bda)
        Cerrar()
        If VerificarArticulos() = False Then
            MsgBox("No hay articulos de inventarios.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            '////////////////////////
            FrmInfoArticulos.ShowDialog()
        End If
    End Sub

    Private Sub cmd_info_serv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_serv.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoServicios.ShowDialog()
    End Sub

    Private Sub cmd_info_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_cliente.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoClientes.ShowDialog()
    End Sub

    Private Sub cmd_info_cronologico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_cronologico.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoCrono.ShowDialog()
    End Sub

    Private Sub cmd_info_referencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_referencia.Click
        MiConexion(bda)
        Cerrar()
        If VerificarArticulos() = False Then
            MsgBox("No hay articulos de inventarios.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            FrmInfoReferencia.ShowDialog()
        End If
    End Sub

    Private Sub cmd_info_fpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_fpago.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoPagos.ShowDialog()
    End Sub

    Private Sub cmd_info_vendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_info_vendedor.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoVendedores.Text = "INFORME POR ASESOR"
        FrmInfoVendedores.ShowDialog()
    End Sub

    Private Sub cmdveninfocc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdveninfocc.Click
        MiConexion(bda)
        Cerrar()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "VISUALIZAR INFORME DE CONCEPTOS COMISIONABLES ", "", "", "")
        End If
        InfConComi()
    End Sub

    Private Sub cmdveninfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdveninfo.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoVendedores.ShowDialog()
    End Sub
    Private Sub cmddes_pre_gral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes_pre_gral.Click
        MiConexion(bda)
        Cerrar()
        FrmListasClientes.ShowDialog()
    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmAumentarPrecios.ShowDialog()
    End Sub

    Private Sub cmddes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmDesFact.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    ''.....................
    'Private Sub Bfa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bfa.Click

    '    MiConexion(bda)
    '    Cerrar()
    '    Dim dataset As New saeosteomaterial2012DataSet

    '    Dim conexion As New OleDbConnection
    '    Dim cadena As String
    '    cadena = datosconR(bda)
    '    conexion.ConnectionString = cadena
    '    conexion.Open()

    '    Dim sql As String = ""
    '    sql = "SELECT doc FROM `facturas01` where nitc = '77195905'"


    '    Dim command As New OleDbCommand(sql, conexion)
    '    Dim da As New OleDbDataAdapter(command)
    '    da.Fill(dataset, "")



    'End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoCotz.ShowDialog()
    End Sub

    Private Sub TabControlPanel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlPanel5.Click

    End Sub

    Private Sub cmd_imp_tipodoc_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_imp_tipodoc.Click
        MiConexion(bda)
        Cerrar()
        FrmImpFacturas.ShowDialog()
    End Sub

    Private Sub cmd_anular_facts_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_anular_facts.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            MsgBox("No hay parametros generales de facturacion.", MsgBoxStyle.Information, "SAE Parametros")
            Exit Sub
        Else
            If Trim(tabla.Rows(0).Item(0)) = "" Then
                MsgBox("No hay documento asignado para los ajustes de facturacion.", MsgBoxStyle.Information, "SAE Parametros")
                Exit Sub
            End If
        End If
        FrmAnularFact.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmAprFac.ShowDialog()
    End Sub

    Private Sub cmddes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes.Click
        MiConexion(bda)
        Cerrar()
        FrmDesFact.ShowDialog()
    End Sub

    Private Sub cmdCamPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCamPer.Click
        MiConexion(bda)
        Cerrar()
        FrmCamPerFact.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmDiarioFac.ShowDialog()
    End Sub

    Private Sub cmdUsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUsu.Click
        Dim ta As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios where login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count = 0 Then Exit Sub
        If ta.Rows(0).Item(0) = "admin" Then
            MiConexion(bda)
            Cerrar()
            FrmInfoUsuario.ShowDialog()
        Else
            MsgBox("NO tiene permisos para este proceso", MsgBoxStyle.Information, "SAE")
        End If


    End Sub

    Private Sub cmdpedcimplidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpedcimplidos.Click
        FrmEntraPedidos.lblform.Text = "Acta"
        FrmEntraPedidos.Text = "SAE Actas de Entrega"
        FrmEntraPedidos.Label2.Text = "Documento"
        FrmEntraPedidos.cmbtipo.Enabled = False
        FrmEntraPedidos.ShowDialog()
    End Sub

    Private Sub cmdgrupedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmGestionCitas.ShowDialog()
    End Sub

    Private Sub cmdinfpa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MiConexion(bda)
        Cerrar()
        FrmInforCitas.ShowDialog()
    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX5.Click
        MiConexion(bda)
        Cerrar()
        FrmMetasxArea.ShowDialog()
    End Sub

    Private Sub cmdgrupedidos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgrupedidos.Click
        MiConexion(bda)
        Cerrar()
        FrmGestionCitas.ShowDialog()
    End Sub

    Private Sub cmdinfpa_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdinfpa.Click
        MiConexion(bda)
        Cerrar()
        FrmInforCitas.ShowDialog()
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX6.Click
        MiConexion(bda)
        Cerrar()
        FrmNucleoFami.ShowDialog()
    End Sub
End Class