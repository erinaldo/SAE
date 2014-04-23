Imports MySql.Data.MySqlClient
Public Class FrmCopiarInv

    Private Sub FrmCopiarInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtanio.Items.Clear()

        chIAct.Checked = False
        cbConCant.Checked = False

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT login from sae.companias WHERE login<>'" & UCase(FrmPrincipal.lbcompania.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtComp.Items.Clear()
        If tabla.Rows.Count > 0 Then
            For i = 0 To tabla.Rows.Count - 1
                txtComp.Items.Add(tabla.Rows(i).Item("login"))
            Next
        End If
    End Sub

    Private Sub txtComp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComp.SelectedIndexChanged

        Dim c As String = ""
        Dim tablaa As New DataTable
        myCommand.CommandText = "SHOW DATABASES LIKE '%" & LCase(txtComp.Text) & "%' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaa)
        Refresh()
        txtanio.Items.Clear()
        If tablaa.Rows.Count > 0 Then
            For i = 0 To tablaa.Rows.Count - 1
                c = Strings.Right(tablaa.Rows(i).Item(0), 4)
                txtanio.Items.Add(c)
            Next
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        MiConexion(bda)



        Dim cant As String = ""
        Dim t As String = ""
        Dim resultado As MsgBoxResult

        If txtanio.Text <> "" Then

            resultado = MsgBox("El Inventario será modificado, ¿Realmente desea modificarlo?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.No Then
                Me.Close()
            Else

                If chIAct.Checked = True Then ' Guard inv actual

                    Try
                        'CREAR TABLA temporal ARTICULOS
                        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bda & ".`temp_articulos` (`codart` varchar(18) NOT NULL,`nomart` varchar(60) NOT NULL,`desart` text NOT NULL,`nivel` varchar(15) NOT NULL,`referencia` varchar(18) NOT NULL,`codbar` varchar(20) NOT NULL,`cos_uni` double NOT NULL," _
                        & "`cos_pro` double NOT NULL,`margen` DECIMAL(10,2) NOT NULL,`precio` double NOT NULL,`iva` decimal(10,2) NOT NULL,`exento` varchar(2) NOT NULL,`excluido` varchar(2) NOT NULL,`cue_inv` varchar(15) NOT NULL,`cue_ing` varchar(15) NOT NULL,`cue_cos` varchar(15) NOT NULL,`cue_iva_v` varchar(15) NOT NULL," _
                        & "`cue_iva_c` varchar(15) NOT NULL,`cue_dev` varchar(15) NOT NULL,`unidad` varchar(10) NOT NULL,`empaque` double NOT NULL,`can_emp` double NOT NULL,`uni_emp` double NOT NULL,`cant_min` double NOT NULL,`pp` double NOT NULL,`estado` varchar(10) NOT NULL,`con_comi` varchar(20) NOT NULL," _
                        & "`importa` varchar(2) NOT NULL,`num_reg` varchar(20) NOT NULL,`por_ara` decimal(10,2) NOT NULL,`pos_ara` varchar(20) NOT NULL,`p1` varchar(15) NOT NULL,`p2` varchar(15) NOT NULL,`p3` varchar(15) NOT NULL,`p4` varchar(15) NOT NULL,`p5` varchar(15) NOT NULL, PRIMARY KEY (`codart`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
                        myCommand.ExecuteNonQuery()


                        'TABLA TEMPORAL CONSOLIDADOS INVENTARIOS
                        myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bda & ".`temp_con_inv` (`codart` varchar(18) NOT NULL,`periodo` varchar(2) NOT NULL,`costuni` double NOT NULL default '0',`costprom` double NOT NULL default '0',`costmoe` double NOT NULL default '0',`otro` double NOT NULL default '0'," _
                        & "`margen` decimal(10,2) NOT NULL default '0.00',`base` double NOT NULL default '0',`precio1` double NOT NULL default '0',`precio2` double NOT NULL default '0',`precio3` double NOT NULL default '0',`precio4` double NOT NULL default '0',`precio5` double NOT NULL default '0',`precio6` double NOT NULL default '0'," _
                        & "`cue_inv` varchar(18) NOT NULL,`cue_cos` varchar(18) NOT NULL,`cue_ing` varchar(18) NOT NULL,`cue_iva_v` varchar(18) NOT NULL,`cue_iva_c` varchar(18) NOT NULL,`cue_dev` varchar(18) NOT NULL,`saldoi` double NOT NULL,`vent` double NOT NULL,`vsal` double NOT NULL,`vaju` double NOT NULL," _
                        & "`cant1` double NOT NULL default '0',`cant2` double NOT NULL default '0',`cant3` double NOT NULL default '0',`cant4` double NOT NULL default '0',`cant5` double NOT NULL default '0',`cant6` double NOT NULL default '0',`cant7` double NOT NULL default '0',`cant8` double NOT NULL default '0',`cant9` double NOT NULL default '0',`cant10` double NOT NULL default '0'," _
                        & "`cant11` double NOT NULL default '0',`cant12` double NOT NULL default '0',`cant13` double NOT NULL default '0',`cant14` double NOT NULL default '0',`cant15` double NOT NULL default '0',`cant16` double NOT NULL default '0',`cant17` double NOT NULL default '0',`cant18` double NOT NULL default '0',`cant19` double NOT NULL default '0',`cant20` double NOT NULL default '0'," _
                        & "`cant21` double NOT NULL default '0',`cant22` double NOT NULL default '0',`cant23` double NOT NULL default '0',`cant24` double NOT NULL default '0',`cant25` double NOT NULL default '0',`cant26` double NOT NULL default '0',`cant27` double NOT NULL default '0',`cant28` double NOT NULL default '0',`cant29` double NOT NULL default '0',`cant30` double NOT NULL default '0'" _
                        & ");"
                        myCommand.ExecuteNonQuery()

                        Try
                            myCommand.Parameters.Clear() ' llenar temp_arti
                            myCommand.CommandText = " TRUNCATE " & bda & ".temp_articulos; INSERT INTO " & bda & ".temp_articulos SELECT * FROM " & bda & ".articulos ; "
                            myCommand.ExecuteNonQuery()

                            myCommand.Parameters.Clear() ' llenar temp_inve
                            myCommand.CommandText = " TRUNCATE " & bda & ".temp_con_inv; INSERT INTO " & bda & ".temp_con_inv SELECT * FROM " & bda & ". con_inv ; "
                            myCommand.ExecuteNonQuery()

                        Catch ex As Exception
                        End Try
                    Catch ex As Exception
                    End Try
                End If ' fin guard inv actual

                If cbConCant.Checked = True Then ' con cantid
                    Dim tabla As New DataTable
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT numbod from bodegas ;"
                    myCommand.Connection = conexion
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    Refresh()
                    For i = 1 To tabla.Rows.Count
                        cant = cant & " ,cant" & i
                    Next
                End If

                t = " sae" & LCase(txtComp.Text) & txtanio.Text
                myCommand.Parameters.Clear()
                myCommand.CommandText = " TRUNCATE " & bda & ".articulos; INSERT INTO " & bda & ".articulos SELECT * FROM " & t & ".articulos ; "
                myCommand.ExecuteNonQuery()

                myCommand.Parameters.Clear()
                myCommand.CommandText = " TRUNCATE " & bda & ".con_inv; INSERT INTO " & bda & ".con_inv (codart, periodo, costuni, costprom, costmoe, otro, margen, base, precio1, precio2, precio3, precio4, precio5, precio6, cue_inv, cue_cos, cue_ing, cue_iva_v, cue_iva_c, cue_dev, saldoi, vent, vsal, vaju " & cant & ") SELECT codart, periodo, costuni, costprom, costmoe, otro, margen, base, precio1, precio2, precio3, precio4, precio5, precio6, cue_inv, cue_cos, cue_ing, cue_iva_v, cue_iva_c, cue_dev, saldoi, vent, vsal, vaju " & cant & " FROM " & t & ".con_inv ; "
                myCommand.ExecuteNonQuery()

                MsgBox("El Inventario se modifico exitosamente")
                Me.Close()
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("INVENTARIO", "COPIAR INVENTARIO DE LA COMPAÑIA " & txtComp.Text, "", "", "")
                End If
            End If

        Else
            MsgBox(" Seleccione el año ")
        End If

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class