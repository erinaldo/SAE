Imports MySql.Data.MySqlClient

Public Class FrmParInventarios

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        Try
            If validaropciones() = True Then
                borrardatos()
                MiConexion(bda)
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?longitud", nivel.Value)
                myCommand.Parameters.AddWithValue("?nivel1", n1.Value)
                myCommand.Parameters.AddWithValue("?desc1", txtdes1.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel2", n2.Value)
                myCommand.Parameters.AddWithValue("?desc2", txtdes2.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel3", n3.Value)
                myCommand.Parameters.AddWithValue("?desc3", txtdes3.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel4", n4.Value)
                myCommand.Parameters.AddWithValue("?desc4", txtdes4.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel5", n5.Value)
                myCommand.Parameters.AddWithValue("?desc5", txtdes5.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel6", n6.Value)
                myCommand.Parameters.AddWithValue("?desc6", txtdes6.Text.ToString)
                If rbprecio1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?formula", "manual")
                ElseIf rbprecio2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?formula", "/")
                Else
                    myCommand.Parameters.AddWithValue("?formula", "*")
                End If
                myCommand.Parameters.AddWithValue("?porcen", npor.Value)
                myCommand.Parameters.AddWithValue("?traslados", txttra.Text.ToString)
                myCommand.Parameters.AddWithValue("?ajustes", txtaju.Text.ToString)
                myCommand.Parameters.AddWithValue("?entradas", txtent.Text.ToString)
                myCommand.Parameters.AddWithValue("?salidas", txtsal.Text.ToString)
                If cod2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?codbar", "si")
                Else
                    myCommand.Parameters.AddWithValue("?codbar", "no".ToString)
                End If
                If opcsi.Checked = True Then
                    myCommand.Parameters.AddWithValue("?contable", "si")
                Else
                    myCommand.Parameters.AddWithValue("?contable", "no".ToString)
                End If
                myCommand.Parameters.AddWithValue("?cuenta1", txtcuenta1.Text.ToString)
                myCommand.Parameters.AddWithValue("?cuenta2", txtcuenta2.Text.ToString)
                myCommand.Parameters.AddWithValue("?cuenta3", txtcuenta3.Text.ToString)
                myCommand.Parameters.AddWithValue("?cuenta4", txtcuenta4.Text.ToString)
                myCommand.Parameters.AddWithValue("?cuenta5", txtcuenta5.Text.ToString)
                myCommand.Parameters.AddWithValue("?cuenta6", txtcuenta6.Text.ToString)
                If rbVenta.Checked = True Then
                    myCommand.Parameters.AddWithValue("?vsalida", "VN")
                Else
                    myCommand.Parameters.AddWithValue("?vsalida", "CS")
                End If
                If rbAp_n.Checked = True Then
                    myCommand.Parameters.AddWithValue("guar_Ap", "NO")
                Else
                    myCommand.Parameters.AddWithValue("?guar_Ap", "SI")
                End If
                myCommand.CommandText = "INSERT INTO parinven (longitud,nivel1,desc1,nivel2,desc2,nivel3,desc3,nivel4,desc4,nivel5,desc5,nivel6,desc6,formula,porcen,traslados,ajustes,entradas,salidas,codbar,contable,cuenta1,cuenta2,cuenta3,cuenta4,cuenta5,cuenta6,vsalida,cdebito,ccredito,guar_Ap)" _
                                      & " VALUES (?longitud,?nivel1,?desc1,?nivel2,?desc2,?nivel3,?desc3,?nivel4,?desc4,?nivel5,?desc5,?nivel6,?desc6,?formula,?porcen,?traslados,?ajustes,?entradas,?salidas,?codbar,?contable,?cuenta1,?cuenta2,?cuenta3,?cuenta4,?cuenta5,?cuenta6,?vsalida,'','',?guar_Ap);"

                myCommand.ExecuteNonQuery()
                Cerrar()
                ' /////////////////    AUDITORIA
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    If lbpar.Text = "NO HAY PARAMETROS GUARDADOS" Then
                        Guar_MovUser("INVENTARIO", "GUARDAR PARAMETROS", "", "", "")
                    Else
                        ValidarAuditoria()
                    End If
                End If
                '////////////////////////
                MsgBox("Los Parametros de Inventarios Fueron Guadados Exitosamente.", MsgBoxStyle.Information, "SAE, Guardar Parametros")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString, MsgBoxStyle.Critical, "SAE, Guardar Parametros")
        End Try
    End Sub
    Private Sub ValidarAuditoria()

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Dim camp As String = ""
            Dim ant As String = ""
            Dim nuv As String = ""
            Try
                If nivel.Value <> nivel2.Text Then
                    camp = camp & "LONGITUD DEL CODIGO, "
                    ant = ant & nivel2.Text & ", "
                    nuv = nuv & nivel.Value.ToString & ", "
                End If
                If npor.Value <> npor2.Text Then
                    camp = camp & "MARGEN, "
                    ant = ant & npor2.Text & ", "
                    nuv = nuv & npor.Value.ToString & ", "
                End If
                If n1.Value <> n12.Text Then
                    camp = camp & "LOGITUD NIVEL 1, "
                    ant = ant & n12.Text & ", "
                    nuv = nuv & n1.Value.ToString & ", "
                End If
                If txtdes1.Text <> txtdes12.Text Then
                    camp = camp & "DESCRIPCION NIVEL 1,"
                    ant = ant & txtdes12.Text & ", "
                    nuv = nuv & txtdes1.Text & ", "
                End If
                If n2.Value <> n22.Text Then
                    camp = camp & "LOGITUD NIVEL 2, "
                    ant = ant & n22.Text & ", "
                    nuv = nuv & n2.Value.ToString & ", "
                End If
                If txtdes2.Text <> txtdes22.Text Then
                    camp = camp & "DESCRIPCION NIVEL2,"
                    ant = ant & txtdes22.Text & ", "
                    nuv = nuv & txtdes2.Text & ", "
                End If
                If n3.Value <> n32.Text Then
                    camp = camp & "LOGITUD NIVEL 3, "
                    ant = ant & n32.Text & ", "
                    nuv = nuv & n3.Value.ToString & ", "
                End If
                If txtdes3.Text <> txtdes32.Text Then
                    camp = camp & "DESCRIPCION NIVEL 3, "
                    ant = ant & txtdes32.Text & ", "
                    nuv = nuv & txtdes3.Text & ", "
                End If
                If n4.Value <> n42.Text Then
                    camp = camp & "LOGITUD NIVEL 4, "
                    ant = ant & n42.Text & ", "
                    nuv = nuv & n4.Value.ToString & ", "
                End If
                If txtdes4.Text <> txtdes42.Text Then
                    camp = camp & "DESCRIPCION NIVEL 4, "
                    ant = ant & txtdes42.Text & ", "
                    nuv = nuv & txtdes4.Text & ", "
                End If
                If n5.Value <> n52.Text Then
                    camp = camp & "LOGITUD NIVEL 5, "
                    ant = ant & n52.Text & ", "
                    nuv = nuv & n5.Value.ToString & ", "
                End If
                If txtdes5.Text <> txtdes52.Text Then
                    camp = camp & "DESCRIPCION NIVEL5, "
                    ant = ant & txtdes52.Text & ", "
                    nuv = nuv & txtdes5.Text & ", "
                End If
                If n6.Value <> n62.Text Then
                    camp = camp & "LOGITUD NIVEL 6, "
                    ant = ant & n62.Text & ", "
                    nuv = nuv & n6.Value.ToString & ", "
                End If
                If txtdes6.Text <> txtdes62.Text Then
                    camp = camp & "DESCRIPCION NIVEL 6, "
                    ant = ant & txtdes62.Text & ", "
                    nuv = nuv & txtdes6.Text & ", "
                End If
                If txttra.Text <> txttra2.Text Then
                    camp = camp & "DOCUMENTO TRASLADOS, "
                    ant = ant & txttra2.Text & ", "
                    nuv = nuv & txttra.Text & ", "
                End If
                If txtaju.Text <> txtaju2.Text Then
                    camp = camp & "DOCUMENTO AJUSTES, "
                    ant = ant & txtaju2.Text & ", "
                    nuv = nuv & txtaju.Text & ", "
                End If
                If txtsal.Text <> txtsal2.Text Then
                    camp = camp & "DOCUMENTO SALIDAS, "
                    ant = ant & txtsal2.Text & ", "
                    nuv = nuv & txtsal.Text & ", "
                End If
                If txtent.Text <> txtent2.Text Then
                    camp = camp & "DOCUMENTO ENTRADAS, "
                    ant = ant & txtent2.Text & ", "
                    nuv = nuv & txtent.Text & ", "
                End If
                If cod1.Checked <> cod12.Checked Then
                    If cod1.Checked = True Then
                        camp = camp & "CODIGO DE BARRA, "
                        ant = ant & cod2.Text & ", "
                        nuv = nuv & cod1.Text & ", "
                    ElseIf cod2.Checked = True Then
                        camp = camp & "CODIGO DE BARRA, "
                        ant = ant & cod1.Text & ", "
                        nuv = nuv & cod2.Text & ", "
                    End If
                End If
                'If cod2.Checked <> cod22.Checked Then
                '    camp = camp & "CODIGO DE BARRA, "
                '    ant = ant & cod22.Text & ", "
                '    nuv = nuv & cod1.Text & ", "
                'End If
                'If rbVenta.Checked <> rbVenta2.Checked Then
                '    camp = camp & "VALOR EN SALIDAS, "
                '    ant = ant & rbVenta2.Text & ", "
                '    nuv = nuv & rbCosto.Text & ", "
                'End If
                If rbCosto.Checked <> rbCosto2.Checked Then
                    If rbCosto.Checked = True Then
                        camp = camp & "VALOR EN SALIDAS, "
                        ant = ant & rbVenta.Text & ", "
                        nuv = nuv & rbCosto.Text & ", "
                    ElseIf rbVenta.Checked = True Then
                        camp = camp & "VALOR EN SALIDAS, "
                        ant = ant & rbCosto.Text & ", "
                        nuv = nuv & rbVenta.Text & ", "
                    End If
                End If
                If opcsi.Checked <> opcsi1.Checked Then
                    If opcsi.Checked = True Then
                        camp = camp & "INTERFASE CONTABLE, "
                        ant = ant & opcno.Text & ", "
                        nuv = nuv & opcsi.Text & ", "
                    ElseIf opcno.Checked = True Then
                        camp = camp & "INTERFASE CONTABLE, "
                        ant = ant & opcsi.Text & ", "
                        nuv = nuv & opcno.Text & ", "
                    End If
                End If
                If rbAp_n.Checked <> rbAp_n2.Checked Then
                    If rbAp_n.Checked = True Then
                        camp = camp & "SOLO SALIDAS AP, "
                        ant = ant & rbAp_s.Text & ", "
                        nuv = nuv & rbAp_n.Text & ", "
                    ElseIf rbAp_s.Checked = True Then
                        camp = camp & "SOLO SALIDAS AP, "
                        ant = ant & rbAp_n.Text & ", "
                        nuv = nuv & rbAp_s.Text & ", "
                    End If
                End If
                'If rbAp_s.Checked <> rbAp_s1.Checked Then
                '    camp = camp & "SOLO SALIDAS AP, "
                '    ant = ant & rbAp_s1.Text & ", "
                '    nuv = nuv & rbAp_n.Text & ", "
                'End If
                If txtcuenta1.Text <> txtcuenta12.Text Then
                    camp = camp & "CTA INVENTARIO, "
                    ant = ant & txtcuenta12.Text & ", "
                    nuv = nuv & txtcuenta1.Text & ", "
                End If
                If txtcuenta2.Text <> txtcuenta22.Text Then
                    camp = camp & "CTA INGRESOS, "
                    ant = ant & txtcuenta22.Text & ", "
                    nuv = nuv & txtcuenta2.Text & ", "
                End If
                If txtcuenta3.Text <> txtcuenta32.Text Then
                    camp = camp & "CTA INGRESOS, "
                    ant = ant & txtcuenta32.Text & ", "
                    nuv = nuv & txtcuenta3.Text & ", "
                End If
                If txtcuenta4.Text <> txtcuenta42.Text Then
                    camp = camp & "CTA IVA G, "
                    ant = ant & txtcuenta42.Text & ", "
                    nuv = nuv & txtcuenta4.Text & ", "
                End If
                If txtcuenta5.Text <> txtcuenta52.Text Then
                    camp = camp & "CTA IVA D, "
                    ant = ant & txtcuenta52.Text & ", "
                    nuv = nuv & txtcuenta5.Text & ", "
                End If
                If txtcuenta6.Text <> txtcuenta62.Text Then
                    camp = camp & "CTA DEVOL, "
                    ant = ant & txtcuenta62.Text & ", "
                    nuv = nuv & txtcuenta6.Text & ", "
                End If
                Guar_MovUser("INVENTARIO", "MODIFICAR PARAMETROS INVENTARIO", camp, ant, nuv)

            Catch ex As Exception
                MsgBox("error al auditar")
                bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)
            End Try

        End If

    End Sub
    Private Sub n1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub n2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub n3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub n4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub n5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n5.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub n6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles n6.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes5.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdes6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes6.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub nivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nivel.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Function validaropciones()
        Dim x As Integer, y As Integer
        y = Val(nivel.Text)
        x = Val(n1.Value) + Val(n2.Value) + Val(n3.Value) + Val(n4.Value) + Val(n5.Value) + Val(n6.Value)
        If x = y Then
            If txtdes1.Text = "Articulo" Or txtdes2.Text = "Articulo" Or txtdes3.Text = "Articulo" Or txtdes4.Text = "Articulo" Or txtdes5.Text = "Articulo" Then
                MsgBox("Error no pueden haber 2 o mas descripciones de niveles llamadas Articulo.  ", MsgBoxStyle.Information, "SAE, Verificación")
                Return False
                Exit Function
            End If
            If opcsi.Checked = True Then
                If txtnombre1.Text <> "" Then
                    Return True
                Else
                    MsgBox("Error, debe escoger al menos una cuenta contable", MsgBoxStyle.Information, "SAE, Verificación")
                    Return False
                End If
            Else
                Return True
            End If

        Else
            MsgBox("Error Revise la Longitud del Codigo es Diferente a valor de Los Niveles", MsgBoxStyle.Information, "SAE, Verificación")
            Return False
        End If
    End Function
    Sub borrardatos()
        MiConexion(bda)
        myCommand.Connection = DBCon
        myCommand.CommandText = "delete from parinven"
        myCommand.CommandType = CommandType.Text
        myCommand.ExecuteNonQuery()
        Cerrar()
    End Sub

    Private Sub txtcuenta1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta1.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta1"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta2.DoubleClick
        If txtcuenta1.Text = "" Then
            MsgBox("Favor Revise Debe Escoger la Cuenta 1 Para Poder Escoger la Cuenta 2", MsgBoxStyle.Information, "SAE, Verificación")
            Exit Sub
        End If
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta2"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta3.DoubleClick
        If txtcuenta2.Text = "" Then
            MsgBox("Favor Revise Debe Escoger la Cuenta 2 Para Poder Escoger la Cuenta 3", MsgBoxStyle.Information, "SAE, Verificación")
            Exit Sub
        End If
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta3"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta4.DoubleClick
        If txtcuenta3.Text = "" Then
            MsgBox("Favor Revise Debe Escoger la Cuenta 3 Para Poder Escoger la Cuenta 4", MsgBoxStyle.Information, "SAE, Verificación")
            Exit Sub
        End If
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta4"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta5.DoubleClick
        If txtcuenta4.Text = "" Then
            MsgBox("Favor Revise Debe Escoger la Cuenta 4 Para Poder Escoger la Cuenta 5", MsgBoxStyle.Information, "SAE, Verificación")
            Exit Sub
        End If
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta5"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta6.DoubleClick
        If txtcuenta5.Text = "" Then
            MsgBox("Favor Revise Debe Escoger la Cuenta 5 Para Poder Escoger la Cuenta 6", MsgBoxStyle.Information, "SAE, Verificación")
            Exit Sub
        End If
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "inv_cuenta6"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuenta1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta5.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuenta6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta6.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub opcsi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcsi.CheckedChanged
        Gcuentas.Enabled = True
    End Sub
    Private Sub opcno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opcno.CheckedChanged
        Gcuentas.Enabled = False
    End Sub

    Private Sub txttra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttra.DoubleClick
        FrmTipoTransaccion.lbform.Text = "inv_tr"
        FrmTipoTransaccion.ShowDialog()
    End Sub
    Private Sub txttra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttra.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtaju_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaju.DoubleClick
        FrmTipoTransaccion.lbform.Text = "inv_aj"
        FrmTipoTransaccion.ShowDialog()
    End Sub
    Private Sub txtaju_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaju.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtsal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsal.DoubleClick
        FrmTipoTransaccion.lbform.Text = "inv_sa"
        FrmTipoTransaccion.ShowDialog()
    End Sub
    Private Sub txtsal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtent.DoubleClick
        FrmTipoTransaccion.lbform.Text = "inv_en"
        FrmTipoTransaccion.ShowDialog()
    End Sub
    Private Sub txtent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtent.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cmdlista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlista.Click
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM listasprec ORDER BY numlist;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        FrmGestionLista.gitems.Rows.Clear()
        FrmGestionLista.gitems.RowCount = items + 1
        For i = 0 To items - 1
            FrmGestionLista.gitems.Item(0, i).Value = tabla.Rows(i).Item("numlist")
            FrmGestionLista.gitems.Item(1, i).Value = tabla.Rows(i).Item("nomlist")
        Next
        FrmGestionLista.lbestado.Text = "NULO"
        FrmGestionLista.lbnroobs.Text = "0"
        FrmGestionLista.txtnum.Text = ""
        FrmGestionLista.txtnombre.Text = ""
        FrmGestionLista.lbform.Text = "LISTAS DE PRECIOS"
        FrmGestionLista.Text = "SAE Gestion Listas de Precios"
        FrmGestionLista.ShowDialog()
        SendKeys.Send("{TAB}")
    End Sub
    Private Sub cmdbodegas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbodegas.Click
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        FrmGestionLista.gitems.Rows.Clear()
        FrmGestionLista.gitems.RowCount = items + 1
        For i = 0 To items - 1
            FrmGestionLista.gitems.Item(0, i).Value = tabla.Rows(i).Item("numbod")
            FrmGestionLista.gitems.Item(1, i).Value = tabla.Rows(i).Item("nombod")
        Next
        FrmGestionLista.lbestado.Text = "NULO"
        FrmGestionLista.lbnroobs.Text = "0"
        FrmGestionLista.txtnum.Text = ""
        FrmGestionLista.txtnombre.Text = ""
        FrmGestionLista.lbform.Text = "BODEGAS"
        FrmGestionLista.Text = "SAE Gestion Bodegas"
        FrmGestionLista.ShowDialog()
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub n1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n1.ValueChanged

    End Sub

    Private Sub FrmParInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class