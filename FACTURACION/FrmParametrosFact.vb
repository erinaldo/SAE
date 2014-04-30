Public Class FrmParametrosFact
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If lb.Text = "NUEVO" Then
            GuardarParametros()
        Else
            ModificarParametros()
        End If
    End Sub
    Public Sub GuardarParametros()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de facturación general se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?tipof1", txttipo1.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof2", txttipo2.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof3", txttipo3.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof4", txttipo4.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipoaj", txtajust.Text.ToString)
            Try
                myCommand.Parameters.AddWithValue("?a_f1", Val(txtn1.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?a_f1", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?a_f2", Val(txtn2.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?a_f2", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?a_f3", Val(txtn3.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?a_f3", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?a_f4", Val(txtn4.Text))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?a_f4", "0")
            End Try
            '********************* RESOLUCIÓN DIAN ******************************
            myCommand.Parameters.AddWithValue("?hr1", cbres1.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr2", cbres2.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr3", cbres3.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr4", cbres3.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso1", reso1.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso2", reso2.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso3", reso3.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso4", reso4.Text.ToString)
            myCommand.Parameters.AddWithValue("?fecexp1", fecexp1.Value)
            myCommand.Parameters.AddWithValue("?fecexp2", fecexp2.Value)
            myCommand.Parameters.AddWithValue("?fecexp3", fecexp3.Value)
            myCommand.Parameters.AddWithValue("?fecexp4", fecexp4.Value)
            myCommand.Parameters.AddWithValue("?feclim1", feclim1.Value)
            myCommand.Parameters.AddWithValue("?feclim2", feclim2.Value)
            myCommand.Parameters.AddWithValue("?feclim3", feclim3.Value)
            myCommand.Parameters.AddWithValue("?feclim4", feclim4.Value)
            myCommand.Parameters.AddWithValue("?ini1", ini1.Value)
            myCommand.Parameters.AddWithValue("?ini2", ini2.Value)
            myCommand.Parameters.AddWithValue("?ini3", ini3.Value)
            myCommand.Parameters.AddWithValue("?ini4", ini4.Value)
            myCommand.Parameters.AddWithValue("?fin1", fin1.Value)
            myCommand.Parameters.AddWithValue("?fin2", fin2.Value)
            myCommand.Parameters.AddWithValue("?fin3", fin3.Value)
            myCommand.Parameters.AddWithValue("?fin4", fin4.Value)
            '********************************************************************
            If rbf1.Checked = True Then
                myCommand.Parameters.AddWithValue("?formcosto", "1")
            ElseIf rbf2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formcosto", "2")
            Else
                myCommand.Parameters.AddWithValue("?formcosto", "3")
            End If
            If rbiva1.Checked = True Then
                myCommand.Parameters.AddWithValue("?ivainclu", "SI")
            Else
                myCommand.Parameters.AddWithValue("?ivainclu", "NO")
            End If
            If rbcomi1.Checked = True Then
                myCommand.Parameters.AddWithValue("?comventa", "SI")
            Else
                myCommand.Parameters.AddWithValue("?comventa", "NO")
            End If
            If rbcont1.Checked = True Then
                myCommand.Parameters.AddWithValue("?intecontab", "SI")
            Else
                myCommand.Parameters.AddWithValue("?intecontab", "NO")
            End If
            If rbListA1.Checked = True Then
                myCommand.Parameters.AddWithValue("?lista_art", "SI")
            Else
                myCommand.Parameters.AddWithValue("?lista_art", "NO")
            End If
            myCommand.Parameters.AddWithValue("?caja", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?bancos", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?ctapc", txtctapc.Text.ToString)
            myCommand.Parameters.AddWithValue("?inventario", txtinventario.Text.ToString)
            myCommand.Parameters.AddWithValue("?ventas", txtventas.Text.ToString)
            myCommand.Parameters.AddWithValue("?costoventa", txtcosto.Text.ToString)
            myCommand.Parameters.AddWithValue("?ivapp", txtivapp.Text.ToString)
            myCommand.Parameters.AddWithValue("?ivad", txtivad.Text.ToString)
            myCommand.Parameters.AddWithValue("?porivapp", DIN(txtvalorivap.Text.ToString))
            myCommand.Parameters.AddWithValue("?porivad", DIN(txtvalorivad.Text.ToString))
            myCommand.Parameters.AddWithValue("?des", txtdescuento.Text.ToString)
            myCommand.Parameters.AddWithValue("?retfuente", txtretfuente.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteica", txtreteica.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteiva", txtreteiva.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre1", pre1.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre2", pre2.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre3", pre3.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre4", pre4.Text.ToString)
            If rbPre1.Checked = True Then
                myCommand.Parameters.AddWithValue("?lista_pre", "SI")
            Else
                myCommand.Parameters.AddWithValue("?lista_pre", "NO")
            End If
            If rbAp_n.Checked = True Then
                myCommand.Parameters.AddWithValue("?Guar_Ap", "N")
            Else
                myCommand.Parameters.AddWithValue("?Guar_Ap", "S")
            End If
            myCommand.CommandText = "INSERT INTO parafacgral VALUES(?tipof1,?tipof2, ?tipof3, ?tipof4, ?tipoaj, ?a_f1, ?a_f2, ?a_f3, ?a_f4, " _
                                  & " ?hr1,?hr2,?hr3,?hr4,?reso1,?reso2,?reso3,?reso4,?fecexp1,?fecexp2,?fecexp3,?fecexp4,?feclim1,?feclim2,?feclim3,?feclim4,?ini1,?ini2,?ini3,?ini4,?fin1,?fin2,?fin3,?fin4," _
                                  & " ?formcosto, ?ivainclu, ?comventa, ?intecontab, " _
                                  & " ?caja, ?bancos, ?ctapc, ?inventario, ?ventas, ?costoventa, " _
                                  & " ?ivapp, ?ivad, ?porivapp, ?porivad, ?des, ?retfuente, ?reteica, ?reteiva,?pre1,?pre2,?pre3,?pre4,?lista_art,?lista_pre,?Guar_Ap);"
            myCommand.ExecuteNonQuery()
            'myCommand.CommandText = "delete from listasprec where numlist >" & gitems.RowCount & ";"
            'myCommand.ExecuteNonQuery()
            'For i = 0 To gitems.RowCount - 1
            '    GuardarListasDePrecios(gitems.Item(0, i).Value, gitems.Item(1, i).Value)
            'Next
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "GUARDAR PARAMETROS GENERALES DE FACTURACION ", "", "", "")
            End If

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lb.Text = ""
            Me.Close()
        End If
    End Sub
    Public Sub GuardarListasDePrecios(ByVal numlist As String, ByVal nomlist As String)
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM `listasprec` WHERE numlist=" & numlist & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        myCommand.Parameters.Clear()
        Refresh()
        myCommand.Parameters.AddWithValue("?numlist", numlist.ToString)
        myCommand.Parameters.AddWithValue("?nomlist", nomlist.ToString)
        If items = 0 Then
            myCommand.CommandText = "INSERT INTO listasprec VALUES(?numlist,?nomlist);"
        Else
            myCommand.CommandText = "UPDATE listasprec SET nomlist=?nomlist WHERE numlist=?numlist;"
        End If
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub ModificarParametros()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de facturación general se van ha modifcar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?tipof1", txttipo1.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof2", txttipo2.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof3", txttipo3.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipof4", txttipo4.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipoaj", txtajust.Text.ToString)
            '********************* RESOLUCIÓN DIAN ******************************
            myCommand.Parameters.AddWithValue("?hr1", cbres1.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr2", cbres2.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr3", cbres3.Text.ToString)
            myCommand.Parameters.AddWithValue("?hr4", cbres3.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso1", reso1.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso2", reso2.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso3", reso3.Text.ToString)
            myCommand.Parameters.AddWithValue("?reso4", reso4.Text.ToString)
            myCommand.Parameters.AddWithValue("?fecexp1", fecexp1.Value)
            myCommand.Parameters.AddWithValue("?fecexp2", fecexp2.Value)
            myCommand.Parameters.AddWithValue("?fecexp3", fecexp3.Value)
            myCommand.Parameters.AddWithValue("?fecexp4", fecexp4.Value)
            myCommand.Parameters.AddWithValue("?feclim1", feclim1.Value)
            myCommand.Parameters.AddWithValue("?feclim2", feclim2.Value)
            myCommand.Parameters.AddWithValue("?feclim3", feclim3.Value)
            myCommand.Parameters.AddWithValue("?feclim4", feclim4.Value)
            myCommand.Parameters.AddWithValue("?ini1", ini1.Value)
            myCommand.Parameters.AddWithValue("?ini2", ini2.Value)
            myCommand.Parameters.AddWithValue("?ini3", ini3.Value)
            myCommand.Parameters.AddWithValue("?ini4", ini4.Value)
            myCommand.Parameters.AddWithValue("?fin1", fin1.Value)
            myCommand.Parameters.AddWithValue("?fin2", fin2.Value)
            myCommand.Parameters.AddWithValue("?fin3", fin3.Value)
            myCommand.Parameters.AddWithValue("?fin4", fin4.Value)
            '********************************************************************
            If rbf1.Checked = True Then
                myCommand.Parameters.AddWithValue("?formcosto", "1")
            ElseIf rbf2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formcosto", "2")
            Else
                myCommand.Parameters.AddWithValue("?formcosto", "3")
            End If
            If rbiva1.Checked = True Then
                myCommand.Parameters.AddWithValue("?ivainclu", "SI")
            Else
                myCommand.Parameters.AddWithValue("?ivainclu", "NO")
            End If
            If rbcomi1.Checked = True Then
                myCommand.Parameters.AddWithValue("?comventa", "SI")
            Else
                myCommand.Parameters.AddWithValue("?comventa", "NO")
            End If
            If rbcont1.Checked = True Then
                myCommand.Parameters.AddWithValue("?intecontab", "SI")
            Else
                myCommand.Parameters.AddWithValue("?intecontab", "NO")
            End If
            If rbListA1.Checked = True Then
                myCommand.Parameters.AddWithValue("?lista_art", "SI")
            Else
                myCommand.Parameters.AddWithValue("?lista_art", "NO")
            End If
            myCommand.Parameters.AddWithValue("?caja", txtcaja.Text.ToString)
            myCommand.Parameters.AddWithValue("?bancos", txtbanco.Text.ToString)
            myCommand.Parameters.AddWithValue("?ctapc", txtctapc.Text.ToString)
            myCommand.Parameters.AddWithValue("?inventario", txtinventario.Text.ToString)
            myCommand.Parameters.AddWithValue("?ventas", txtventas.Text.ToString)
            myCommand.Parameters.AddWithValue("?costoventa", txtcosto.Text.ToString)
            myCommand.Parameters.AddWithValue("?ivapp", txtivapp.Text.ToString)
            myCommand.Parameters.AddWithValue("?ivad", txtivad.Text.ToString)
            myCommand.Parameters.AddWithValue("?porivapp", DIN(txtvalorivap.Text.ToString))
            myCommand.Parameters.AddWithValue("?porivad", DIN(txtvalorivad.Text.ToString))
            myCommand.Parameters.AddWithValue("?descue", txtdescuento.Text.ToString)
            myCommand.Parameters.AddWithValue("?retfuente", txtretfuente.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteica", txtreteica.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteiva", txtreteiva.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre1", pre1.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre2", pre2.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre3", pre3.Text.ToString)
            myCommand.Parameters.AddWithValue("?pre4", pre4.Text.ToString)
            If rbPre1.Checked = True Then
                myCommand.Parameters.AddWithValue("?lista_pre", "SI")
            Else
                myCommand.Parameters.AddWithValue("?lista_pre", "NO")
            End If
            If rbAp_n.Checked = True Then
                myCommand.Parameters.AddWithValue("?Guar_Ap", "N")
            Else
                myCommand.Parameters.AddWithValue("?Guar_Ap", "S")
            End If
            myCommand.CommandText = "Update parafacgral set tipof1=?tipof1, tipof2=?tipof2, tipof3=?tipof3, tipof4=?tipof4, tipoaj=?tipoaj, " _
                                  & " hr1=?hr1,hr2=?hr2,hr3=?hr3,hr4=?hr4,reso1=?reso1,reso2=?reso2,reso3=?reso3,reso4=?reso4,fecexp1=?fecexp1,fecexp2=?fecexp2,fecexp3=?fecexp3,fecexp4=?fecexp4," _
                                  & " feclim1=?feclim1,feclim2=?feclim2,feclim3=?feclim3,feclim4=?feclim4,ini1=?ini1,ini2=?ini2,ini3=?ini3,ini4=?ini4,fin1=?fin1,fin2=?fin2,fin3=?fin3,fin4=?fin4," _
                                  & " formcosto=?formcosto, ivainclu=?ivainclu, comventa=?comventa, intecontab=?intecontab, " _
                                  & " caja=?caja, bancos=?bancos, ctapc=?ctapc, inventario=?inventario, ventas=?ventas, costoventa=?costoventa, " _
                                  & " ivapp=?ivapp, ivadesc=?ivad, porivapp=?porivapp, porivadesc=?porivad, descuento=?descue, retfuente=?retfuente, reteica=?reteica, reteiva=?reteiva, " _
                                  & " pre1=?pre1,pre2=?pre2,pre3=?pre3,pre4=?pre4,lista_art=?lista_art,lista_pre=?lista_pre,Guar_Ap=?Guar_Ap;"
            myCommand.ExecuteNonQuery()
            'myCommand.CommandText = "delete from listasprec where numlist >" & gitems.RowCount & ";"
            'myCommand.ExecuteNonQuery()
            'For i = 0 To gitems.RowCount - 1
            '    GuardarListasDePrecios(gitems.Item(0, i).Value, gitems.Item(1, i).Value)
            'Next
            
            AudiMov()

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lb.Text = ""
            Me.Close()
        End If
    End Sub
    Private Sub AudiMov()

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                Dim camp As String = ""
                Dim ant As String = ""
                Dim nuv As String = ""
                If rbf1.Checked = False And rbf11.Checked = True Then
                    camp = camp & "FORMULA,"
                    ant = ant & "MANUAL,"
                    nuv = nuv & " ,"
                End If
                If rbf2.Checked = False And rbf12.Checked = True Then
                    camp = camp & "FORMULA,"
                    ant = ant & "COSTO/UTILIDAD,"
                    nuv = nuv & " ,"
                End If
                If rbf3.Checked = False And rbf13.Checked = True Then
                    camp = camp & "FORMULA,"
                    ant = ant & "COSTO*UTILIDAD,"
                    nuv = nuv & " ,"
                End If
                '........
                If rbPre1.Checked = False And rbpre11.Checked = True Then
                    camp = camp & "MODIFICAR PRECIO,"
                    ant = ant & "SI,"
                    nuv = nuv & "NO,"
                End If
                If rbPre2.Checked = False And rbpre22.Checked = True Then
                    camp = camp & "MODIFICAR PRECIO,"
                    ant = ant & "NO,"
                    nuv = nuv & "SI,"
                End If
                '........
                If rbiva1.Checked = False And rbiva11.Checked = True Then
                    camp = camp & "MOSTRAR PRECIO,"
                    ant = ant & "CON IVA,"
                    nuv = nuv & "SIN IVA,"
                End If
                If rbiva2.Checked = False And rbiva2.Checked = True Then
                    camp = camp & "MOSTRAR PRECIO,"
                    ant = ant & "SIN IVA,"
                    nuv = nuv & "CON IVA,"
                End If
                '.........
                If rbListA1.Checked = False And rbListA11.Checked = True Then
                    camp = camp & "MOSTRAR ARTICULOS,"
                    ant = ant & "CON EXISTENCIA,"
                    nuv = nuv & "TODOS,"
                End If
                If rbListA2.Checked = False And rbListA22.Checked = True Then
                    camp = camp & "MOSTRAR ARTICULOS,"
                    ant = ant & "TODOS,"
                    nuv = nuv & "CON EXISTENCIA,"
                End If
                '........
                If rbAp_s.Checked = False And rbAp_s1.Checked = True Then
                    camp = camp & "GUARDAR SOLO AP,"
                    ant = ant & "SI,"
                    nuv = nuv & "NO,"
                End If
                If rbAp_n.Checked = False And rbAp_n1.Checked = True Then
                    camp = camp & "GUARDAR SOLO AP,"
                    ant = ant & "NO,"
                    nuv = nuv & "SI,"
                End If
                Guar_MovUser("FACTURACION", "MODIFICAR PARAMETROS GENERALES DE FACTURACION ", camp, ant, nuv)
            Catch ex As Exception
                MsgBox("error al auditar")
                bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)
            End Try
        End If
    End Sub

    Private Sub rbcont2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont2.CheckedChanged
        txtcaja.Enabled = False
        txtbanco.Enabled = False
        txtctapc.Enabled = False
        txtinventario.Enabled = False
        txtventas.Enabled = False
        txtcosto.Enabled = False
        txtivapp.Enabled = False
        txtivad.Enabled = False
        txtvalorivap.Enabled = False
        txtvalorivad.Enabled = False
        txtdescuento.Enabled = False
        txtretfuente.Enabled = False
        txtreteica.Enabled = False
        txtreteiva.Enabled = False
    End Sub
    '//////////DOCUMENTOS/////////
    Public Sub TiposDeDocumentos(ByVal cad As String)
        FrmSelTipoDoc.lbtipo.Text = cad
        FrmSelTipoDoc.ShowDialog()
    End Sub
    Private Sub txttipo1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo1.DoubleClick
        TiposDeDocumentos("1")
    End Sub
    Private Sub txttipo1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo1.KeyPress

    End Sub
    Private Sub txttipo2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo2.DoubleClick
        TiposDeDocumentos("2")
    End Sub
    Private Sub txttipo2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo2.KeyPress

    End Sub
    Private Sub txttipo3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo3.DoubleClick
        TiposDeDocumentos("3")
    End Sub
    Private Sub txttipo3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo3.KeyPress

    End Sub
    Private Sub txttipo4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo4.DoubleClick
        TiposDeDocumentos("4")
    End Sub
    Private Sub txttipo4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo4.KeyPress

    End Sub
    Private Sub txtajust_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtajust.DoubleClick
        TiposDeDocumentos("A")
    End Sub
    Private Sub txtajust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtajust.KeyPress

    End Sub
    '////////////CUENTAS//////////////
    Private Sub txtcaja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcaja.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "caja"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtcaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcaja.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtbanco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbanco.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "banco"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtctapc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapc.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "ctapc"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtctapc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctapc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtinventario_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinventario.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "inventario"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtinventario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinventario.KeyPress
        FrmCuentas.lbaux.Text = "Grupo"
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtventas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtventas.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "ventas"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtventas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtventas.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcosto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcosto.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "costo"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtcosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcosto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtivapp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivapp.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "ivapp"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtivapp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivapp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtivad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtivad.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "ivad"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtivad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtivad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdescuento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuento.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "descuento"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtdescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtretfuente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtretfuente.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "retfuente"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtretfuente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtretfuente.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtreteica_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteica.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "reteica"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtreteica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreteica.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtreteiva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtreteiva.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "reteiva"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txtreteiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreteiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    '*************************************
    Private Sub txtcompa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmCuentas.lbform.Text = "compartido"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcompa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcuota_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmCuentas.lbform.Text = "cuota"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtabono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        FrmCuentas.lbform.Text = "abono"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtabono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rbcont1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont1.CheckedChanged
        txtcaja.Enabled = True
        txtbanco.Enabled = True
        txtctapc.Enabled = True
        txtinventario.Enabled = True
        txtventas.Enabled = True
        txtcosto.Enabled = True
        txtivapp.Enabled = True
        txtivad.Enabled = True
        txtvalorivap.Enabled = True
        txtvalorivad.Enabled = True
        txtdescuento.Enabled = True
        txtretfuente.Enabled = True
        txtreteica.Enabled = True
        txtreteiva.Enabled = True
        If txtvalorivap.Text = "" Then
            txtvalorivap.Text = "16,00"
        End If
        If txtvalorivad.Text = "" Then
            txtvalorivad.Text = "16,00"
        End If
    End Sub

    Private Sub cbres1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbres1.SelectedIndexChanged
        If cbres1.Text = "SI" Then
            reso1.Enabled = True
            fecexp1.Enabled = True
            feclim1.Enabled = True
            ini1.Enabled = True
            fin1.Enabled = True
            pre1.Enabled = True
        Else
            cbres1.Text = "NO"
            reso1.Enabled = False
            fecexp1.Enabled = False
            feclim1.Enabled = False
            ini1.Enabled = False
            fin1.Enabled = False
            pre1.Enabled = False
        End If
    End Sub
    Private Sub cbres2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbres2.SelectedIndexChanged
        If cbres2.Text = "SI" Then
            reso2.Enabled = True
            fecexp2.Enabled = True
            feclim2.Enabled = True
            ini2.Enabled = True
            fin2.Enabled = True
            pre2.Enabled = True
        Else
            cbres2.Text = "NO"
            reso2.Enabled = False
            fecexp2.Enabled = False
            feclim2.Enabled = False
            ini2.Enabled = False
            fin2.Enabled = False
            pre2.Enabled = False
        End If
    End Sub
    Private Sub cbres3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbres3.SelectedIndexChanged
        If cbres3.Text = "SI" Then
            reso3.Enabled = True
            fecexp3.Enabled = True
            feclim3.Enabled = True
            ini3.Enabled = True
            fin3.Enabled = True
            pre3.Enabled = True
        Else
            cbres3.Text = "NO"
            reso3.Enabled = False
            fecexp3.Enabled = False
            feclim3.Enabled = False
            ini3.Enabled = False
            fin3.Enabled = False
            pre3.Enabled = False
        End If
    End Sub
    Private Sub cbres4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbres4.SelectedIndexChanged
        If cbres4.Text = "SI" Then
            reso4.Enabled = True
            fecexp4.Enabled = True
            feclim4.Enabled = True
            ini4.Enabled = True
            fin4.Enabled = True
            pre4.Enabled = True
        Else
            cbres4.Text = "NO"
            reso4.Enabled = False
            fecexp4.Enabled = False
            feclim4.Enabled = False
            ini4.Enabled = False
            fin4.Enabled = False
            pre4.Enabled = False
        End If
    End Sub

    Private Sub cmdlista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlista.Click
        MiConexion(bda)
        Try
            'CREAR TABLA LISTAS DE PRECIOS
            myCommand.CommandText = "CREATE TABLE IF NOT EXISTS " & bda & ".`listasprec` (`numlist` int(11) NOT NULL AUTO_INCREMENT,`nomlist` varchar(70) NOT NULL, PRIMARY KEY (`numlist`));"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Cerrar()
        '*************************************************************
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
    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

   
End Class