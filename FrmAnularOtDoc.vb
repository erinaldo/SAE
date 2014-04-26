Public Class FrmAnularOtDoc
    Private Sub FrmAnularOtDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarActual()
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
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
        If (txtfecha_ana.Value.Day < txtfecha.Value.Day) Then
            MsgBox("Favor escoja una fecha de anulación valida(el dia debe ser mayor o igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        If (Val(txtfecha_ana.Value.Month) <> Val(PerActual(0) & PerActual(1))) Then
            MsgBox("Favor escoja una fecha de anulación valida(el periodo debe ser igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        If txtfecha_ana.Value.Year <> (PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)) Then
            MsgBox("Favor escoja una fecha de anulación valida(el año de coincidir con el actualmente utilizado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El docuemento " & txttipo.Text & txtnumfac.Text & " será anulado, ¿Desea Anularlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            If docCredito() = "no" Then Exit Sub
            AnularFactura()
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    '**********************************************************
    Public Sub BuscarActual()
        Dim tabla2, tabla As New DataTable
        myCommand.CommandText = "SELECT aj FROM parotdoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count < 1 Then
            MsgBox("Favor no han creado tipo de documento para los ajustes (del grupo AJ), verifique.   ", MsgBoxStyle.Information, "Verificando")
            Me.Close()
            Exit Sub
        End If
        myCommand.CommandText = "SELECT tipodoc, descripcion, actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & tabla.Rows(0).Item(0) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count < 1 Then
            MsgBox("Favor no han creado tipo de documento para los ajustes (del grupo AJ), verifique.   ", MsgBoxStyle.Information, "Verificando")
            Me.Close()
        Else
            lbtipo.Text = tabla2.Rows(0).Item("tipodoc").ToString
            lbdoc.Text = NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1)
        End If
    End Sub
    Function docCredito()
        Try
            '... CREDITO ...
            MiConexion(bda)
            Dim tc As New DataTable
            myCommand.CommandText = "SELECT pagado FROM cobdpen WHERE doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "' UNION SELECT pagado FROM ctas_x_pagar WHERE doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            If tc.Rows.Count > 0 Then
                If tc.Rows(0).Item(0) <> CDbl(0) Then
                    MsgBox("El documento no se puede anular porque ya han abanonado a la deuda", MsgBoxStyle.Information, "Verificacion")
                    Return ("no")
                    Cerrar()
                    Exit Function
                End If
            End If
        Catch ex As Exception
        End Try
        Return ("")
        Cerrar()
        '......
    End Function
    Public Sub AnularFactura()
        Dim tb As String = ""
        MiConexion(bda)
        Try
            BuscarActual()

            Select Case lbform.Text
                Case "ci"
                    tb = "ot_doc"
                Case "rc"
                    tb = "ot_cpc"
                Case "ce"
                    tb = "ot_cpp"
                Case "nc"
                    tb = "ot_doc"
            End Select

            Dim tabla As New DataTable
            'MsgBox("SELECT * FROM " & tb & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;")
            myCommand.CommandText = "SELECT * FROM " & tb & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
                Exit Sub
            ElseIf Trim(tabla.Rows(0).Item("doc_aj").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
                Exit Sub
            Else
                If tb = "ot_cpp" Or tb = "ot_cpc" Then
                    For k = 0 To tabla.Rows.Count - 1
                        If tabla.Rows(k).Item("doc_afec") <> "" Then
                            If tb = "ot_cpc" Then
                                Actualsaldos(tb, tabla.Rows(k).Item("doc_afec"), tabla.Rows(k).Item("credito"))
                            Else
                                Actualsaldos(tb, tabla.Rows(k).Item("doc_afec"), tabla.Rows(k).Item("debito"))
                            End If
                        End If
                    Next
                End If
                For i = 0 To tabla.Rows.Count - 1
                    GuardarDetalles(tabla.Rows(i).Item("item"), tb)
                Next
            End If
            Contable()
            ActualizarDoc(tb)
            ActualizarConsecutivo()
            Dim sql2 As String = ""
            Try
                sql2 = "DELETE FROM cobdpen WHERE doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.CommandText = sql2
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            Try
                sql2 = "DELETE FROM ctas_x_pagar WHERE doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "' ;"
                myCommand.CommandText = sql2
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
            Try
                Dim Sql As String = "DELETE FROM ant_a_prov WHERE per_doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
                Sql = "DELETE FROM ant_de_clie WHERE per_doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.CommandText = Sql
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
           

            
            Select Case lbform.Text
                Case "ce"
                    FrmComEgresoCpp.lbanulado.Text = "ANULADO CON " & lbtipo.Text & NumeroDoc(lbdoc.Text)
                Case "ci"
                    FrmCompIngresos.lbanulado.Text = "ANULADO CON " & lbtipo.Text & NumeroDoc(lbdoc.Text)
                Case "rc"
                    FrmRecibodeCaja.lbanulado.Text = "ANULADO CON " & lbtipo.Text & NumeroDoc(lbdoc.Text)
                Case "nd"
                    FrmNotaDebito.lbanulado.Text = "ANULADO CON " & lbtipo.Text & NumeroDoc(lbdoc.Text)
                Case "nc"
                    FrmNotaCredito.lbanulado.Text = "ANULADO CON " & lbtipo.Text & NumeroDoc(lbdoc.Text)
            End Select
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("CONTABILIDAD", "ANULAR DOCUMENTO: " & txttipo.Text & txtnumfac.Text & "-" & lbper_a.Text, "", "", "")
            End If
            '.....
            MsgBox("El documento fué anulado con " & lbtipo.Text & NumeroDoc(lbdoc.Text) & ".", MsgBoxStyle.Information, "SAE Buscar")
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR AL ANULAR DOCUMENTO: " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub Actualsaldos(ByVal tb As String, ByVal docaf As String, ByVal abonado As Double)
        Try
            Dim sq As String = ""
            Dim t As String = ""
            If tb = "ot_cpp" Then
                t = "ctas_x_pagar"
            ElseIf tb = "ot_cpc" Then
                t = "cobdpen"
            End If
            myCommand.Parameters.Clear()
            sq = "UPDATE " & t & "  SET pagado=pagado- " & DIN(abonado) & " WHERE doc='" & docaf & "';"
            myCommand.CommandText = sq
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(" Error al regresar el abono, " & ex.ToString)
        End Try
    End Sub
    
    Public Sub GuardarDetalles(ByVal fila As Integer, ByVal tb As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & tb & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' AND item=" & fila & " ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        myCommand.Parameters.Clear()
        '*************************************************************************************
        myCommand.Parameters.AddWithValue("?item", fila)
        myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text.ToString)
        myCommand.Parameters.AddWithValue("?grupo", tabla.Rows(0).Item("grupo"))
        myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text)
        myCommand.Parameters.AddWithValue("?num", Val(lbdoc.Text.ToString))
        myCommand.Parameters.AddWithValue("?doc_afec", txttipo.Text & txtnumfac.Text)
        myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?ciudad", tabla.Rows(0).Item("ciudad"))
        myCommand.Parameters.AddWithValue("?concepto", "ANULA A " & txttipo.Text & txtnumfac.Text & " - " & tabla.Rows(0).Item("concepto"))
        myCommand.Parameters.AddWithValue("?nitc", tabla.Rows(0).Item("nitc"))
        myCommand.Parameters.AddWithValue("?tn", tabla.Rows(0).Item("tn"))
        myCommand.Parameters.AddWithValue("?codigo", tabla.Rows(0).Item("codigo"))
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(tabla.Rows(0).Item("descrip"), 99))
        myCommand.Parameters.AddWithValue("?debito", DIN(tabla.Rows(0).Item("credito")))
        myCommand.Parameters.AddWithValue("?credito", DIN(tabla.Rows(0).Item("debito")))
        myCommand.Parameters.AddWithValue("?base", DIN(tabla.Rows(0).Item("base")))
        myCommand.Parameters.AddWithValue("?total", DIN(tabla.Rows(0).Item("total")))
        myCommand.Parameters.AddWithValue("?cheque", tabla.Rows(0).Item("cheque"))
        myCommand.Parameters.AddWithValue("?banco", tabla.Rows(0).Item("banco"))
        myCommand.Parameters.AddWithValue("?sucursal", tabla.Rows(0).Item("sucursal"))
        '*********************************************************
        myCommand.Parameters.AddWithValue("?ccosto", tabla.Rows(0).Item("ccosto"))
        myCommand.Parameters.AddWithValue("?fecha", txtfecha_ana.Value)
        myCommand.Parameters.AddWithValue("?elaborado", FrmPrincipal.lbuser.Text)
        myCommand.Parameters.AddWithValue("?autorizado", "")
        myCommand.Parameters.AddWithValue("?revisado", "")
        myCommand.Parameters.AddWithValue("?contabilizado", "")
        myCommand.Parameters.AddWithValue("?doc_aj", " ")

        If tb = "ot_doc " Then
            myCommand.Parameters.AddWithValue("?efectivo", tabla.Rows(0).Item("efectivo"))
            myCommand.CommandText = "INSERT INTO ot_doc" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,'');"
        Else
            If tb = "ot_cpc" Then
                myCommand.Parameters.AddWithValue("?efectivo", tabla.Rows(0).Item("tipo_pago"))
                myCommand.Parameters.AddWithValue("?estado", tabla.Rows(0).Item("estado"))
                myCommand.Parameters.AddWithValue("?abonado", tabla.Rows(0).Item("abonado"))
                myCommand.Parameters.AddWithValue("?doc_anti", tabla.Rows(0).Item("doc_anti"))
                myCommand.Parameters.AddWithValue("?nitv", tabla.Rows(0).Item("nitv"))
                myCommand.Parameters.AddWithValue("?comis", tabla.Rows(0).Item("codcon"))
                myCommand.CommandText = "INSERT INTO " & tb & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?doc_anti,?nitv,?comis);"
            ElseIf tb = "ot_cpp" Then
                myCommand.Parameters.AddWithValue("?efectivo", tabla.Rows(0).Item("tipo_pago"))
                myCommand.Parameters.AddWithValue("?estado", tabla.Rows(0).Item("estado"))
                myCommand.Parameters.AddWithValue("?abonado", tabla.Rows(0).Item("abonado"))
                myCommand.Parameters.AddWithValue("?doc_anti", tabla.Rows(0).Item("doc_anti"))
                myCommand.CommandText = "INSERT INTO " & tb & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?doc_anti);"
            End If
        End If
        myCommand.ExecuteNonQuery()
        If tb = "ot_cpc" Then
            GuardarAnticipos(DIN(tabla.Rows(0).Item("debito")), tabla.Rows(0).Item("doc_anti"), "ant_de_clie")
        ElseIf tb = "ot_cpp" Then
            GuardarAnticipos(DIN(tabla.Rows(0).Item("credito")), tabla.Rows(0).Item("doc_anti"), "ant_a_prov")
        End If
        myCommand.Parameters.Clear()
    End Sub
    Public Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String, ByVal tb As String)
        Dim sql As String = ""
        Dim sig As String = ""
        Try
            If doc <> "" Then
                myCommand.Parameters.Clear()
                If lbtipo.Text = txttipo.Text Then
                    sig = "+"
                Else
                    sig = "-"
                End If
                sql = "UPDATE " & tb & " SET causado = causado " & sig & " " & DIN(valor) & " WHERE per_doc='" & Trim(doc) & "';"
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarDoc(ByVal tb As String)
        Try
            myCommand.CommandText = "UPDATE " & tb & PerActual(0) & PerActual(1) & " SET doc_aj='ANULADO CON " & lbtipo.Text & lbdoc.Text & "' WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR AL MOMENTO DE ACTUALIZAR EL ESTADO DEL DOCUMENTO ANULADO: " & ex.ToString)
        End Try
    End Sub
    Public Sub Contable()
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                Try
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?item", tabla.Rows(i).Item("item"))
                    myCommand.Parameters.AddWithValue("?doc", lbdoc.Text.ToString)
                    myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text)
                    myCommand.Parameters.AddWithValue("?periodo", PerActual)
                    myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day.ToString)
                    myCommand.Parameters.AddWithValue("?centro", tabla.Rows(i).Item("centro"))
                    myCommand.Parameters.AddWithValue("?descrip", CambiaCadena("ANULA A " & txttipo.Text & txtnumfac.Text & " " & tabla.Rows(i).Item("descri"), 50))
                    Try
                        myCommand.Parameters.AddWithValue("?debito", DIN(tabla.Rows(i).Item("credito")))
                    Catch ex As Exception
                        myCommand.Parameters.AddWithValue("?debito", "0")
                    End Try
                    Try
                        myCommand.Parameters.AddWithValue("?credito", DIN(tabla.Rows(i).Item("debito")))
                    Catch ex As Exception
                        myCommand.Parameters.AddWithValue("?credito", "0")
                    End Try
                    myCommand.Parameters.AddWithValue("?codigo", tabla.Rows(i).Item("codigo"))
                    myCommand.Parameters.AddWithValue("?base", tabla.Rows(i).Item("base"))
                    myCommand.Parameters.AddWithValue("?diasv", tabla.Rows(i).Item("diasv"))
                    Try
                        myCommand.Parameters.AddWithValue("?fechaven", tabla.Rows(i).Item("fechaven"))
                    Catch ex As Exception
                        myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
                    End Try
                    myCommand.Parameters.AddWithValue("?nit", tabla.Rows(i).Item("nit"))
                    myCommand.Parameters.AddWithValue("?cheque", lbcheque.Text)
                    myCommand.Parameters.AddWithValue("?modulo", "ot_doc")
                    'INSERTAR CONTABLE
                    myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " " _
                                          & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
                    myCommand.ExecuteNonQuery()
                    ActualizarMisCuentas(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("credito"), tabla.Rows(i).Item("debito"))
                Catch ex As Exception
                    MsgBox("ERROR INSERTANDO DOCUMENTO CONTABLE:" & ex.ToString)
                End Try
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ActualizarConsecutivo()
        Try
            Dim num As Integer
            Try
                num = Val(lbdoc.Text)
            Catch ex As Exception
                num = 1
            End Try
            myCommand.CommandText = "UPDATE tipdoc SET actual" & PerActual(0) & PerActual(1) & "='" & num & "' WHERE tipodoc='" & lbtipo.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class