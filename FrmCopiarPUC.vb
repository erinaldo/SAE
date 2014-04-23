Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System
Imports System.Object

Public Class FrmCopiarPUC

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmCopiarPUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtanio.Items.Clear()
        chPAct.Checked = False

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

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim t As String

        If txtComp.Text = "" Then
            MsgBox("Verifique la compañia ", MsgBoxStyle.Information, "SAE")
            txtComp.Focus()
            Exit Sub
        End If
        If txtanio.Text = "" Then
            MsgBox("Verifique el año  ", MsgBoxStyle.Information, "SAE")
            txtanio.Focus()
            Exit Sub
        End If

        t = " sae" & LCase(txtComp.Text) & txtanio.Text & ""
        If r1.Checked = True Then
            CopiarPuc(t)
        ElseIf r2.Checked = True Then
            CopiarParametros(t)
        ElseIf r3.Checked = True Then
            CopiarImpuestos(t)
        ElseIf r4.Checked = True Then
            CopiarServicios(t)
        ElseIf r5.Checked = True Then
            CopiarGastos(t)
        End If

    End Sub
    Private Sub CopiarServicios(ByVal t As String)
        MiConexion(bda)
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los Servicios seran Agregados, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then
            Me.Close()
        Else

            myCommand.Parameters.Clear()
            myCommand.CommandText = " TRUNCATE " & bda & ".servicios; INSERT INTO " & bda & ".servicios SELECT * FROM " & t & ".servicios ; "
            myCommand.ExecuteNonQuery()

            MsgBox("Los Servicios fueron Agregados exitosamente", MsgBoxStyle.Information, "Verificacion")

            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("CONTABILIDAD", "COPIAR SERVICIOS DE OTRA COMPAÑIA: " & txtComp.Text, "", "", "")
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
        Cerrar()
    End Sub
    Private Sub CopiarGastos(ByVal t As String)
        MiConexion(bda)
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los Gastos seran Agregados, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then
            Me.Close()
        Else

            myCommand.Parameters.Clear()
            myCommand.CommandText = " TRUNCATE " & bda & ".gastos; INSERT INTO " & bda & ".gastos SELECT * FROM " & t & ".gastos ; "
            myCommand.ExecuteNonQuery()

            MsgBox("Los Gastos fueron Agregados exitosamente", MsgBoxStyle.Information, "Verificacion")

            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("CONTABILIDAD", "COPIAR GASTOS DE OTRA COMPAÑIA: " & txtComp.Text, "", "", "")
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
        Cerrar()
    End Sub
    Private Sub CopiarImpuestos(ByVal t As String)
        MiConexion(bda)
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los Impuestos seran Agregados, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then
            Me.Close()
        Else

            myCommand.Parameters.Clear()
            myCommand.CommandText = " TRUNCATE " & bda & ".con_gral_imp; INSERT INTO " & bda & ".con_gral_imp SELECT * FROM " & t & ".con_gral_imp ; "
            myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            myCommand.CommandText = " TRUNCATE " & bda & ".impuestos; INSERT INTO " & bda & ".impuestos SELECT * FROM " & t & ".impuestos ; "
            myCommand.ExecuteNonQuery()

            MsgBox("Los Impuestos fueron Agregados exitosamente", MsgBoxStyle.Information, "Verificacion")

            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("CONTABILIDAD", "COPIAR PUC COMPAÑIA: " & txtComp.Text, "", "", "")
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
        Cerrar()
    End Sub
    Private Sub CopiarParametros(ByVal t As String)
        MiConexion(bda)
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de todos los modulos seran copiados a esta compañia, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then
            Me.Close()
        Else

            If FrmPrincipal.Cartera.Visible = True And FrmPrincipal.Cartera.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".car_par ; INSERT INTO " & bda & ".car_par  SELECT * FROM " & t & ".car_par  ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros de Cartera. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If

            If FrmPrincipal.Facturacion.Visible = True And FrmPrincipal.Facturacion.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".parafacgral ; INSERT INTO " & bda & ".parafacgral  SELECT * FROM " & t & ".parafacgral  ; "
                    myCommand.ExecuteNonQuery()


                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " UPDATE " & bda & ".parafacgral SET a_f1=0	AND a_f2=0	AND a_f3=0	AND a_f4=0  "
                    myCommand.ExecuteNonQuery()


                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".parafacts ; INSERT INTO " & bda & ".parafacts  SELECT * FROM " & t & ".parafacts  ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros de fACTURACION. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If

            If FrmPrincipal.Contabilidad.Visible = True And FrmPrincipal.Contabilidad.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".parcontab ; INSERT INTO " & bda & ".parcontab  SELECT * FROM " & t & ".parcontab  ; "
                    myCommand.ExecuteNonQuery()

                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".parotdoc ; INSERT INTO " & bda & ".parotdoc  SELECT * FROM " & t & ".parotdoc  ; "
                    myCommand.ExecuteNonQuery()

                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".tipdoc; INSERT INTO " & bda & ".tipdoc (tipodoc,grupo,descripcion,inicio01,actual01) SELECT tipodoc,grupo,descripcion,0,0 FROM " & t & ".tipdoc ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros de Contabilidad. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If
            
            If FrmPrincipal.Inventarios.Visible = True And FrmPrincipal.Inventarios.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".parinven ; INSERT INTO " & bda & ".parinven  SELECT * FROM " & t & ".parinven  ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros de Inventario. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If

            If FrmPrincipal.Proveedores.Visible = True And FrmPrincipal.Proveedores.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".par_comp; INSERT INTO " & bda & ".par_comp  SELECT * FROM " & t & ".par_comp ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros de Proveedores. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If

            If FrmPrincipal.Gerencial.Visible = True And FrmPrincipal.Gerencial.Enabled = True Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = " TRUNCATE " & bda & ".par_analisis ; INSERT INTO " & bda & ".par_analisis   SELECT * FROM " & t & ".par_analisis  ; "
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error al Copiar los Parametros del modulo Gerencial. " & ex.ToString, MsgBoxStyle.Information, "SAE")
                End Try
            End If


            MsgBox("Los Parametros Fueron Agregados ", MsgBoxStyle.Information, "Verificacion")
            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("CONTABILIDAD", "COPIAR PARAMETROS DE OTRA COMPAÑIA: " & txtComp.Text, "", "", "")
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
        Cerrar()
    End Sub
    Private Sub CopiarPuc(ByVal t As String)
        MiConexion(bda)
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El PUC será modificado, ¿Desea modificarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then
            Me.Close()
        Else

            If chPAct.Checked = True Then ' Guardar puc actual
                Try
                    myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bda & ".temselpuc (" _
                                      & " `codigo` varchar(10) NOT NULL DEFAULT '',`descripcion` varchar(100) NOT NULL,`naturaleza` varchar(1) NOT NULL DEFAULT 'D',`nivel` varchar(12) NOT NULL DEFAULT 'Auxiliar'," _
                                      & "`tipo` varchar(10) NOT NULL DEFAULT 'Activo',`saldo` double NOT NULL DEFAULT '0',`saldo00` double NOT NULL DEFAULT '0',`debito00` double NOT NULL DEFAULT '0',`credito00` double NOT NULL DEFAULT '0',`debito01` double NOT NULL DEFAULT '0'," _
                                      & "`credito01` double NOT NULL DEFAULT '0',`saldo01` double NOT NULL DEFAULT '0',`debito02` double NOT NULL DEFAULT '0',`credito02` double NOT NULL DEFAULT '0'," _
                                      & "`saldo02` double NOT NULL DEFAULT '0',`debito03` double NOT NULL DEFAULT '0',`credito03` double NOT NULL DEFAULT '0',`saldo03` double NOT NULL DEFAULT '0'," _
                                      & "`debito04` double NOT NULL DEFAULT '0',`credito04` double NOT NULL DEFAULT '0',`saldo04` double NOT NULL DEFAULT '0',`debito05` double NOT NULL DEFAULT '0'," _
                                      & "`credito05` double NOT NULL DEFAULT '0',`saldo05` double NOT NULL DEFAULT '0',`debito06` double NOT NULL DEFAULT '0',`credito06` double NOT NULL DEFAULT '0'," _
                                      & "`saldo06` double NOT NULL DEFAULT '0',`debito07` double NOT NULL DEFAULT '0',`credito07` double NOT NULL DEFAULT '0',`saldo07` double NOT NULL DEFAULT '0'," _
                                      & "`debito08` double NOT NULL DEFAULT '0',`credito08` double NOT NULL DEFAULT '0',`saldo08` double NOT NULL DEFAULT '0',`debito09` double NOT NULL DEFAULT '0'," _
                                      & "`credito09` double NOT NULL DEFAULT '0',`saldo09` double NOT NULL DEFAULT '0',`debito10` double NOT NULL DEFAULT '0',`credito10` double NOT NULL DEFAULT '0'," _
                                      & "`saldo10` double NOT NULL DEFAULT '0',`debito11` double NOT NULL DEFAULT '0',`credito11` double NOT NULL DEFAULT '0',`saldo11` double NOT NULL DEFAULT '0'," _
                                      & "`debito12` double NOT NULL DEFAULT '0',`credito12` double NOT NULL DEFAULT '0',`saldo12` double NOT NULL DEFAULT '0',PRIMARY KEY (`codigo`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
                    myCommand.ExecuteNonQuery()

                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = " TRUNCATE " & bda & ".temselpuc; INSERT INTO " & bda & ".temselpuc SELECT * FROM " & bda & ".`selpuc`; "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try

                Catch ex As Exception
                End Try

            End If ' fin guardar puc actual



            myCommand.Parameters.Clear()
            myCommand.CommandText = " TRUNCATE " & bda & ".selpuc; INSERT INTO " & bda & ".selpuc (codigo, descripcion,  naturaleza, nivel, tipo) SELECT codigo, descripcion, naturaleza, nivel, tipo FROM " & t & ".selpuc ; "
            myCommand.ExecuteNonQuery()
            MsgBox("El PUC se modifico exitosamente", MsgBoxStyle.Information, "Verificacion")

            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    '........
                    Guar_MovUser("CONTABILIDAD", "COPIAR PUC COMPAÑIA: " & txtComp.Text, "", "", "")
                    '.............
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try

        End If
        Cerrar()

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

    Private Sub r1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r1.CheckedChanged
        If r1.Checked = True Then
            chPAct.Enabled = True
        Else
            chPAct.Enabled = False
        End If
    End Sub
End Class