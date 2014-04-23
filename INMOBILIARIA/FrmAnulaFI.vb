Public Class FrmAnulaFI

    Private Sub FrmAnulaFI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbpro.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        txtfecha_ana.Value = Today
        '******************************************
        Dim tabla As New DataTable
        Dim ta As New DataTable
        myCommand.CommandText = "SELECT parf, docf,tipof1 FROM   `parcontrato` ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count = 0 Then
            MsgBox("No ha definido documentos para facturar ", MsgBoxStyle.Information, "Verifique")
            Me.Close()
        ElseIf ta.Rows(0).Item("parf") = "NO" And ta.Rows(0).Item("tipof1") = "" Then
            MsgBox("No ha definido el tipo de documento para Facturar, Verifique en los Parametros ", MsgBoxStyle.Exclamation, "Verifique")
            Me.Close()
        Else
            If ta.Rows(0).Item("parf") = "NO" Then
                txttipo.Items.Clear()
                txttipo.Items.Add(Trim(ta.Rows(0).Item("tipof1")))
                txttipo.Text = Trim(ta.Rows(0).Item("tipof1"))
            Else
                txttipo.Items.Clear()
                txttipo.Items.Add(Trim(ta.Rows(0).Item("docf")))
                txttipo.Text = Trim(ta.Rows(0).Item("docf"))
                'tabla.Clear()
                'myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4 FROM parafacgral;"
                'myAdapter.SelectCommand = myCommand
                'myAdapter.Fill(tabla)
                'Refresh()
                'If tabla.Rows.Count = 0 Then Exit Sub
                'txttipo.Items.Clear()
                'If Trim(tabla.Rows(0).Item("tipof1")) <> "" Then
                '    txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
                '    txttipo.Text = Trim(tabla.Rows(0).Item("tipof1"))
                'End If
                'If Trim(tabla.Rows(0).Item("tipof2")) <> "" Then
                '    txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
                'End If
                'If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
                '    txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
                'End If
                'If Trim(tabla.Rows(0).Item("tipof4")) <> "" Then
                '    txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
                'End If
            End If
        End If
        tabla.Clear()
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        If Trim(tabla.Rows(0).Item("tipoaj")) <> "" Then
            'txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
            lbtipo.Text = Trim(tabla.Rows(0).Item("tipoaj"))
        Else
            MsgBox("No han asignado documento para ajustes de facturación... ", MsgBoxStyle.Information, "SAE Control")
            Me.Close()
        End If
        '******************************************
        cbper.Text = PerActual(0) & PerActual(1)
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If BuscarFI() <> "ok" Then
            Exit Sub
        End If
        If Trim(txtnumfac.Text) = "" Then
            MsgBox("Digite un numero de documento.", MsgBoxStyle.Information, "SAE Buscar")
            txtnumfac.Focus()
            Exit Sub
        End If
        If Trim(lbcliente.Text) = "" Then
            MsgBox("Favor escoja un documento valido.", MsgBoxStyle.Information, "SAE Buscar")
            txtnumfac.Focus()
            Exit Sub
        End If
        If (txtfecha_ana.Value < txtfecha.Value) Then
            MsgBox("Favor escoja una fecha de anulación valida(el dia debe ser mayor o igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        If txtfecha_ana.Value.Year <> (PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)) Then
            MsgBox("Favor escoja una fecha de anulación valida(el año debe coincidir con el actualmente utilizado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        MsgBox("Este proceso es irreversible, La anulacion debe realizarse a la ultima factura del contrato para evitar inconvenientes", MsgBoxStyle.Information, "Recomendaciones")
        resultado = MsgBox("El documento " & txttipo.Text & txtnumfac.Text & " será anulado, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            AnularFacturaI()
        End If
    End Sub
    Private Sub AnularFacturaI()
        Dim rs As MsgBoxResult
        MiConexion(bda)
        Dim t As New DataTable
        t.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT (c.pagado + x.pagado) as p  FROM cobdpen c,ctas_x_pagar x  WHERE c.doc='" & txttipo.Text & txtnumfac.Text & "' and x.doc= c.doc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)

        If t.Rows.Count > 0 Then
            If CDbl(t.Rows(0).Item("p")) <> CDbl(0) Then
                MsgBox("El documento " & txttipo.Text & txtnumfac.Text & " tiene abonos registrados, verifique ", MsgBoxStyle.Information, "Verificando")
                '              rs = MsgBox("El documento " & txttipo.Text & txtnumfac.Text & " tiene abonos registrados, verifique ", MsgBoxStyle.YesNo, "Verificando")
                ' If rs = MsgBoxResult.No Then
                Exit Sub
                ' End If
            End If
        End If
        contable()
        Act_contrato()
        cxc()
        Act_fact()
        Cerrar()
        MsgBox("DOCUMENTO " & txttipo.Text & txtnumfac.Text & " ANULADO CON " & lbtipo.Text & lbdoc.Text, MsgBoxStyle.Information, "SAE Guardar")
    End Sub
    Private Sub Act_fact()
        Dim t As New DataTable
        t.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT  * FROM facturainm" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        Refresh()

        If t.Rows.Count = 0 Then Exit Sub
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE facturainm" & cbper.Text & "  SET estado='AN', doc_anul='" & lbtipo.Text & lbdoc.Text & "' WHERE doc='" & txttipo.Text & txtnumfac.Text & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar facturainmobiliaria , " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Private Sub Act_contrato()
        Dim t As New DataTable
        t.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT  descrip FROM cobdpen WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        Refresh()

        If t.Rows.Count = 0 Then Exit Sub
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE contrato_inm SET mes_fact =mes_fact - 1 WHERE cod_contra='" & t.Rows(0).Item(0) & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar mesfacturado , " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE contrato_inm SET mes_act =mes_act - 1 WHERE cod_contra='" & t.Rows(0).Item(0) & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar mesactual en el contrato , " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE contrato_inm SET periodo ='' WHERE cod_contra='" & t.Rows(0).Item(0) & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al actualizar periodo contrato , " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
        '///////////////////////////////////////////////////
        '...... Confirmar si es 1ra factura

        Dim tb As New DataTable
        tb.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT fechaini,fechaf, mes_fact FROM contrato_inm  WHERE cod_contra='" & t.Rows(0).Item(0) & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Dim fecha As Integer
        fecha = 0
        fecha = DateDiff("m", CDate(tb.Rows(0).Item(0)), CDate(tb.Rows(0).Item(1)))

        If CInt(tb.Rows(0).Item(2)) = fecha Then
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE contrato_inm SET dias ='0' WHERE cod_contra='" & t.Rows(0).Item(0) & "'"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Error al actualizar el dia del contrato , " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If
    End Sub

    Private Sub contable()
        Dim ta As New DataTable
        ta.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select * from documentos" & cbper.Text & " WHERE tipodoc='" & txttipo.Text & "' and doc='" & Val(txtnumfac.Text) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        lbdoc.Text = NumeroAJ()
        For i = 0 To ta.Rows.Count - 1
            Try
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?item", ta.Rows(i).Item("item"))
                myCommand.Parameters.AddWithValue("?doc", lbdoc.Text.ToString)
                myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text)
                myCommand.Parameters.AddWithValue("?periodo", cbper.Text & "/" & txtfecha_ana.Value.Year)
                myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day.ToString)
                myCommand.Parameters.AddWithValue("?centro", ta.Rows(i).Item("centro"))
                myCommand.Parameters.AddWithValue("?descrip", CambiaCadena("ANULA A " & txttipo.Text & txtnumfac.Text & " " & ta.Rows(i).Item("descri"), 50))
                Try
                    myCommand.Parameters.AddWithValue("?debito", DIN(ta.Rows(i).Item("credito")))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?debito", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?credito", DIN(ta.Rows(i).Item("debito")))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?credito", "0")
                End Try
                myCommand.Parameters.AddWithValue("?codigo", ta.Rows(i).Item("codigo"))
                myCommand.Parameters.AddWithValue("?base", DIN(ta.Rows(i).Item("base")))
                myCommand.Parameters.AddWithValue("?diasv", ta.Rows(i).Item("diasv"))
                myCommand.Parameters.AddWithValue("?cheque", ta.Rows(i).Item("cheque"))
                Try
                    myCommand.Parameters.AddWithValue("?fechaven", ta.Rows(i).Item("fechaven"))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
                End Try
                myCommand.Parameters.AddWithValue("?nit", ta.Rows(i).Item("nit"))
                myCommand.Parameters.AddWithValue("?modulo", "inm_anulado")
                'INSERTAR CONTABLE
                myCommand.CommandText = "INSERT INTO documentos" & cbper.Text & " " _
                                      & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
                myCommand.ExecuteNonQuery()
                'ActualizarMisCuentas(ta.Rows(i).Item("codigo"), tabla.Rows(i).Item("credito"), tabla.Rows(i).Item("debito"))
            Catch ex As Exception
                MsgBox("ERROR INSERTANDO DOCUMENTO CONTABLE:" & ex.ToString)
            End Try
        Next
    End Sub
    Private Sub cxc()
        Try
            myCommand.CommandText = "UPDATE documentos" & cbper.Text & " SET modulo ='inm_anulado' WHERE tipodoc='" & txttipo.Text & "' and doc='" & Val(txtnumfac.Text) & "'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        
        '**************
        Try
            myCommand.CommandText = "DELETE FROM cobdpen WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
       
        '**************
        Try
            myCommand.CommandText = "DELETE FROM ctas_x_pagar WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub
    Function NumeroAJ()
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT tipoaj FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Dim tipo As String = tabla.Rows(0).Item("tipoaj")
        myCommand.CommandText = "SELECT actual" & cbper.Text & " FROM tipdoc WHERE tipodoc='" & tipo & "';"
        'myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & tipo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        lbtipo.Text = tipo

        '****************
        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE tipdoc SET actual" & cbper.Text & "='" & Val(tabla2.Rows(0).Item(0)) + 1 & "' WHERE tipodoc='" & tipo & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        '********************

        Try
            Return NumeroDoc(Val(tabla2.Rows(0).Item(0)) + 1)
        Catch ex As Exception
            Return NumeroDoc(1)
        End Try
    End Function
    Function BuscarFI()

        MiConexion(bda)
        Dim sum As Double = 0
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select * from documentos" & cbper.Text & " WHERE tipodoc='" & txttipo.Text & "' and doc='" & Val(txtnumfac.Text) & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("modulo").ToString) = "inm_anulado" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
                Return ("exi")
                Exit Function
            ElseIf tabla.Rows(0).Item("modulo").ToString <> "inmobiliaria" Then
                MsgBox("El documento NO pertenece a el modulo inmobiliario.", MsgBoxStyle.Information, "Verificar")
                Me.Close()
            Else
                For i = 0 To tabla.Rows.Count - 1
                    If tabla.Rows(i).Item("item") = "1" Then
                        lbcliente.Text = Datos_Cliente(tabla.Rows(i).Item("nit"))
                    ElseIf tabla.Rows(i).Item("item") = "5" Then
                        lbpro.Text = Datos_Cliente(tabla.Rows(i).Item("nit"))
                    End If
                    sum = sum + tabla.Rows(i).Item("debito")
                Next

                lbtotal.Text = Moneda(sum)
                txtfecha.Value = CDate(tabla.Rows(0).Item("dia") & "/" & tabla.Rows(0).Item("periodo"))
            End If
        End If
        Cerrar()
        Return ("ok")
    End Function

    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub

    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        txtnumfac.Text = NumeroDoc(Val(txtnumfac.Text))
        BuscarFI()
    End Sub
    Function Datos_Cliente(ByVal nit As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nombre,apellidos FROM terceros WHERE nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Return Trim(tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos"))
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
        txttipo2.Text = tabla.Rows(0).Item(0)
        txtnumfac.Text = ""
    End Sub
End Class