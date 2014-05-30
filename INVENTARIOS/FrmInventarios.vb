Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmInventarios

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub
    'basicos
    Private Sub cmdparinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparinv.Click
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            FrmParInventarios.nivel.Value = tabla.Rows(0).Item("longitud")
            FrmParInventarios.n1.Value = tabla.Rows(0).Item("nivel1")
            FrmParInventarios.txtdes1.Text = tabla.Rows(0).Item("desc1")
            FrmParInventarios.n2.Value = tabla.Rows(0).Item("nivel2")
            FrmParInventarios.txtdes2.Text = tabla.Rows(0).Item("desc2")
            FrmParInventarios.n3.Value = tabla.Rows(0).Item("nivel3")
            FrmParInventarios.txtdes3.Text = tabla.Rows(0).Item("desc3")
            FrmParInventarios.n4.Value = tabla.Rows(0).Item("nivel4")
            FrmParInventarios.txtdes4.Text = tabla.Rows(0).Item("desc4")
            FrmParInventarios.n5.Value = tabla.Rows(0).Item("nivel5")
            FrmParInventarios.txtdes5.Text = tabla.Rows(0).Item("desc5")
            FrmParInventarios.n6.Value = tabla.Rows(0).Item("nivel6")
            FrmParInventarios.txtdes6.Text = tabla.Rows(0).Item("desc6")
            If tabla.Rows(0).Item("formula") = "manual" Then
                FrmParInventarios.rbprecio1.Checked = True
            ElseIf tabla.Rows(0).Item("formula") = "/" Then
                FrmParInventarios.rbprecio2.Checked = True
            Else
                FrmParInventarios.rbprecio3.Checked = True
            End If
            FrmParInventarios.npor.Value = tabla.Rows(0).Item("porcen")
            FrmParInventarios.txttra.Text = tabla.Rows(0).Item("traslados")
            FrmParInventarios.txtaju.Text = tabla.Rows(0).Item("ajustes")
            FrmParInventarios.txtent.Text = tabla.Rows(0).Item("entradas")
            FrmParInventarios.txtsal.Text = tabla.Rows(0).Item("salidas")
            If tabla.Rows(0).Item("codbar") = "si" Then
                FrmParInventarios.cod2.Checked = True
            Else
                FrmParInventarios.cod1.Checked = True
            End If
            If tabla.Rows(0).Item("contable") = "si" Then
                FrmParInventarios.opcsi.Checked = True
            Else
                FrmParInventarios.opcno.Checked = True
            End If
            FrmParInventarios.txtcuenta1.Text = tabla.Rows(0).Item("cuenta1")
            FrmParInventarios.txtnombre1.Text = b_cuentas(tabla.Rows(0).Item("cuenta1"))
            FrmParInventarios.txtcuenta2.Text = tabla.Rows(0).Item("cuenta2")
            FrmParInventarios.txtnombre2.Text = b_cuentas(tabla.Rows(0).Item("cuenta2"))
            FrmParInventarios.txtcuenta3.Text = tabla.Rows(0).Item("cuenta3")
            FrmParInventarios.txtnombre3.Text = b_cuentas(tabla.Rows(0).Item("cuenta3"))
            FrmParInventarios.txtcuenta4.Text = tabla.Rows(0).Item("cuenta4")
            FrmParInventarios.txtnombre4.Text = b_cuentas(tabla.Rows(0).Item("cuenta4"))
            FrmParInventarios.txtcuenta5.Text = tabla.Rows(0).Item("cuenta5")
            FrmParInventarios.txtnombre5.Text = b_cuentas(tabla.Rows(0).Item("cuenta5"))
            FrmParInventarios.txtcuenta6.Text = tabla.Rows(0).Item("cuenta6")
            FrmParInventarios.txtnombre6.Text = b_cuentas(tabla.Rows(0).Item("cuenta6"))
            If tabla.Rows(0).Item("vsalida") = "CS" Then
                FrmParInventarios.rbCosto.Checked = True
            Else
                FrmParInventarios.rbVenta.Checked = True
            End If
            If tabla.Rows(0).Item("guar_Ap") = "NO" Then
                FrmParInventarios.rbAp_n.Checked = True
            Else
                FrmParInventarios.rbAp_s.Checked = True
            End If
            '....................
            '..................para AUD..
            FrmParInventarios.nivel2.Text = tabla.Rows(0).Item("longitud")
            FrmParInventarios.n12.Text = tabla.Rows(0).Item("nivel1")
            FrmParInventarios.txtdes12.Text = tabla.Rows(0).Item("desc1")
            FrmParInventarios.n22.Text = tabla.Rows(0).Item("nivel2")
            FrmParInventarios.txtdes22.Text = tabla.Rows(0).Item("desc2")
            FrmParInventarios.n32.Text = tabla.Rows(0).Item("nivel3")
            FrmParInventarios.txtdes32.Text = tabla.Rows(0).Item("desc3")
            FrmParInventarios.n42.Text = tabla.Rows(0).Item("nivel4")
            FrmParInventarios.txtdes42.Text = tabla.Rows(0).Item("desc4")
            FrmParInventarios.n52.Text = tabla.Rows(0).Item("nivel5")
            FrmParInventarios.txtdes52.Text = tabla.Rows(0).Item("desc5")
            FrmParInventarios.n62.Text = tabla.Rows(0).Item("nivel6")
            FrmParInventarios.txtdes62.Text = tabla.Rows(0).Item("desc6")
            'If tabla.Rows(0).Item("formula") = "manual" Then
            '    FrmParInventarios.rbprecio1.Checked = True
            'ElseIf tabla.Rows(0).Item("formula") = "/" Then
            '    FrmParInventarios.rbprecio2.Checked = True
            'Else
            '    FrmParInventarios.rbprecio3.Checked = True
            'End If
            FrmParInventarios.npor2.Text = tabla.Rows(0).Item("porcen")
            FrmParInventarios.txttra2.Text = tabla.Rows(0).Item("traslados")
            FrmParInventarios.txtaju2.Text = tabla.Rows(0).Item("ajustes")
            FrmParInventarios.txtent2.Text = tabla.Rows(0).Item("entradas")
            FrmParInventarios.txtsal2.Text = tabla.Rows(0).Item("salidas")
            If tabla.Rows(0).Item("codbar") = "si" Then
                FrmParInventarios.cod22.Checked = True
            Else
                FrmParInventarios.cod12.Checked = True
            End If
            If tabla.Rows(0).Item("contable") = "si" Then
                FrmParInventarios.opcsi1.Checked = True
            Else
                FrmParInventarios.opcno2.Checked = True
            End If
            FrmParInventarios.txtcuenta12.Text = tabla.Rows(0).Item("cuenta1")
            FrmParInventarios.txtcuenta22.Text = tabla.Rows(0).Item("cuenta2")
            FrmParInventarios.txtcuenta32.Text = tabla.Rows(0).Item("cuenta3")
            FrmParInventarios.txtcuenta42.Text = tabla.Rows(0).Item("cuenta4")
            FrmParInventarios.txtcuenta52.Text = tabla.Rows(0).Item("cuenta5")
            FrmParInventarios.txtcuenta62.Text = tabla.Rows(0).Item("cuenta6")
            If tabla.Rows(0).Item("vsalida") = "CS" Then
                FrmParInventarios.rbCosto2.Checked = True
            Else
                FrmParInventarios.rbVenta2.Checked = True
            End If
            If tabla.Rows(0).Item("guar_Ap") = "NO" Then
                FrmParInventarios.rbAp_n2.Checked = True
            Else
                FrmParInventarios.rbAp_s1.Checked = True
            End If

            '....................

            FrmParInventarios.lbpar.Text = "YA HAY PARAMETROS GUARDADOS"
        Else
            FrmParInventarios.lbpar.Text = "NO HAY PARAMETROS GUARDADOS"
        End If
        FrmParInventarios.ShowDialog()
    End Sub
    Function b_cuentas(ByVal codigo As String)
        Dim t As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count > 0 Then
            Return t.Rows(0).Item("descripcion")
        Else
            Return ""
        End If
    End Function
    Private Sub cmdcataart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcataart.Click
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            FrmProductos.ShowDialog()
        Else
            MsgBox("No hay parametros de inventarios creados, verifique", MsgBoxStyle.Information, "SAE Control")
        End If

    End Sub
    Private Sub cmdsaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldos.Click
        MiConexion(bda)
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            FrmSaldosInicialesInvMenu.ShowDialog()
        Else
            MsgBox("No hay parametros de inventarios creados, verifique", MsgBoxStyle.Information, "SAE Control")
        End If


    End Sub
    'transacciones
    Private Sub cmdtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtra.Click
        MiConexion(bda)
        Cerrar()
        FrmTraslados.ShowDialog()
    End Sub
    Private Sub cmdaju_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdaju.Click
        MiConexion(bda)
        Cerrar()
        FrmAjustesCant.ShowDialog()
    End Sub
    Private Sub cmdajuval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdajuval.Click
        MiConexion(bda)
        Cerrar()
        FrmAjustes.ShowDialog()
    End Sub
    Private Sub cmdsal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsal.Click
        MiConexion(bda)
        Cerrar()
        FrmSalidas.ShowDialog()
    End Sub
    Private Sub cdentr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdentr.Click
        MiConexion(bda)
        Cerrar()
        FrmEntradas.ShowDialog()
    End Sub
    Private Sub cmddocu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddocu.Click
        MiConexion(bda)
        Cerrar()
        BuscarPeriodo()
        FrmImpDocumentos.lbperiodo.Text = PerActual
        FrmImpDocumentos.txtperiodo.Text = "/" & PerActual
        FrmImpDocumentos.txtperiodo2.Text = "/" & PerActual
        FrmImpDocumentos.cbtipo.Text = "Traslados"
        FrmImpDocumentos.ShowDialog()
    End Sub
    Private Sub cmd_anu_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub con_consig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
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
        FrmAbrirCompania.lbform.Text = "inventario"
        FrmAbrirCompania.ShowDialog()
        MiConexion(bda)
        Cerrar()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Inventarios.pdf"
        Try
            If (ruta IsNot Nothing) Then
                FrmAyuda.pdf.LoadFile(ruta)
                FrmAyuda.Show()
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub cmdactcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdactcc.Click
        BuscarPeriodo()
        FrmCirreInv.ShowDialog()
    End Sub

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

    Private Sub cmd_tar_conteo_fisico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_tar_conteo_fisico.Click
        FrmTarConteoFisico.ShowDialog()
    End Sub

    Private Sub cmdlistaprecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlistaprecio.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoListaPreciosArt.ShowDialog()
    End Sub

    Private Sub FrmInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion("sae")
        Dim t As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)

        If t.Rows(0).Item(0) = "S" Then
            ' cmddes.Visible = True
        Else
            '  cmddes.Visible = False
        End If
        Cerrar()


        'If FrmPrincipal.lbuser.Text = "sae" Then
        '    cmddes.Visible = True
        'Else
        '    cmddes.Visible = False
        'End If

        MiConexion(bda)
        Dim per As String = ""
        Try
            Dim tabla As New DataTable
            per = "SELECT count(*) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " _
            & "WHERE TABLE_SCHEMA = '" & bda & "' AND TABLE_NAME = 'con_inv';"
            myCommand.CommandText = per
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows(0).Item(0) > 0 Then
                Exit Sub
            End If
            per = "ALTER TABLE `con_inv` ENGINE=InnoDB DEFAULT CHARSET=utf8; " _
            & "ALTER TABLE `articulos` ENGINE=InnoDB DEFAULT CHARSET=utf8; " _
            & "ALTER TABLE `con_inv` CHANGE `codart` `codart` VARCHAR( 18 ) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL "
            myCommand.Parameters.Clear()
            myCommand.CommandText = per
            myCommand.ExecuteNonQuery()
            per = "ALTER TABLE `con_inv` " _
            & "ADD FOREIGN KEY (codart) " _
            & "REFERENCES articulos (codart) " _
            & "ON DELETE CASCADE " _
            & "ON UPDATE CASCADE;"
            myCommand.Parameters.Clear()
            myCommand.CommandText = per
            myCommand.ExecuteNonQuery()
            per = "Optimize Table articulos; Optimize Table con_inv;"
            myCommand.Parameters.Clear()
            myCommand.CommandText = per
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(per & "  ****  " & ex.ToString)
        End Try
        Try

            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE movimientos" & per & "  ADD `cc` BIGINT NOT NULL AFTER `desc_mov`;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try
        Try
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "ALTER TABLE  movimientos" & per & " ADD  `tipo` VARCHAR( 50 ) NOT NULL AFTER  `tipo_mov`;"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub cmdbloper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbloper.Click
        MiConexion(bda)
        Cerrar()
        FrmConteoFisInv.ShowDialog()
    End Sub
    Private Sub cmd_inf_kar_cod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inf_kar_cod.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoKardex.ShowDialog()
    End Sub
    Private Sub cmd_inf_kar_ref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inf_kar_ref.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoRef.ShowDialog()
    End Sub

    Private Sub cmd_codigo_o_alfabeto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_codigo_o_alfabeto.Click
        MiConexion(bda)
        Cerrar()
        FrmInfartalf.ShowDialog()
    End Sub

    Private Sub cmd_referencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_referencia.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoRef.ShowDialog()
    End Sub

    Private Sub cdm_exi_bod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdm_exi_bod.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoExistencia.ShowDialog()
    End Sub

    Private Sub cmd_inv_dia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_inv_dia.Click
        MiConexion(bda)
        Cerrar()
        FrmInvenDia.ShowDialog()
    End Sub

    Private Sub cmdcatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcatalogo.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoTipodoc.ShowDialog()
    End Sub

    Private Sub ButtonX15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX15.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoMovRef.ShowDialog()
    End Sub

    Private Sub cmdcopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcopiar.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoMovArt.ShowDialog()
    End Sub

    Private Sub ButtonX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX16.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoterceros.ShowDialog()
    End Sub
    Private Sub ButtonX14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX14.Click
        MiConexion(bda)
        Cerrar()
    End Sub
    Private Sub ButtonX20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX20.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoSinMov.ShowDialog()
    End Sub

    Private Sub ButtonX21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX21.Click
        MiConexion(bda)
        Cerrar()
        FrmInfoEntr.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmReproInven.ShowDialog()

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmCopiarInv.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmCamCodart.ShowDialog()
    End Sub

    Private Sub cmdAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdAprobar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAprobar.Click
        MiConexion(bda)
        Cerrar()
        FrmAprInv.ShowDialog()
    End Sub

    Private Sub cmd_anu_doc_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_anu_doc.Click
        MiConexion(bda)
        Cerrar()
        FrmAnular_Inv.ShowDialog()
    End Sub

    Private Sub cmddes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaInvetario.ShowDialog()
    End Sub

    Private Sub cmdInvIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvIni.Click

        MiConexion(bda)
        Cerrar()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql = "SELECT c.codart as codart, a.nomart , c.costuni as cos_uni, c.costprom as cos_pro, c.cant1 as empaque, c.cant2 as can_emp, c.cant3 as uni_emp, c.cant4 as cant_min, c.cant5 as pp " _
        & " FROM con_inv c, articulos a WHERE c.codart= a.codart AND c.periodo='00' ORDER BY codart"

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportInvInic.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmRepExis.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            FrmRepExis.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepExis.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try

    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmInfPunto.ShowDialog()
    End Sub
End Class