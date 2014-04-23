Public Class FrmAnular_Inv
    Dim sw_aju As Integer = 0
    Private Sub FrmAnular_Inv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT traslados,ajustes,entradas,salidas FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then Exit Sub
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("entradas")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("entradas")))
                txttipo.Text = Trim(tabla.Rows(0).Item("entradas"))
            End If
            If Trim(tabla.Rows(0).Item("salidas")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("salidas")))
            End If
            If Trim(tabla.Rows(0).Item("traslados")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("traslados")))
                lbtras.Text = Trim(tabla.Rows(0).Item("traslados"))
            End If
            If Trim(tabla.Rows(0).Item("ajustes")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("ajustes")))
                lbtipo.Text = Trim(tabla.Rows(0).Item("ajustes"))
            Else
                MsgBox("No han asignado documento para ajustes de inventarios... ", MsgBoxStyle.Information, "SAE Control")
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '****************************************************************************
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
            If txttipo.Text = lbtras.Text Then
                AnularTras()
            Else
                AnularFactura()
            End If
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '**************************************************************************
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
        lbcliente.Text = ""
        txtconcepto.Text = ""
        lbtotal.Text = "0,00"
    End Sub
    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        txtnumfac.Text = NumeroDoc(Val(txtnumfac.Text))
        BuscarDoc()
    End Sub
    Public Sub BuscarDoc()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtconcepto.Text = ""
        lbcliente.Text = ""
        lbtiopomov.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If VerificarDescrip(Trim(tabla.Rows(0).Item("desc_mov").ToString)) = False Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("dia").ToString & "/" & PerActual)
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
                lbtiopomov.Text = UCase(tabla.Rows(0).Item("tipo"))
            End If
        End If
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
    Function VerificarDescrip(ByVal descrip As String)
        Dim cad As String = ""
        For i = 0 To descrip.Length - 1
            cad = cad & descrip(i)
            If cad = "ANULADO CON" Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function
    '************************************************************************************
    Public Sub AnularTras()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtconcepto.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If VerificarDescrip(Trim(tabla.Rows(0).Item("desc_mov").ToString)) = False Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("dia").ToString & "/" & PerActual)
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
            End If
        End If
        '*********************ANULAR DOCUENTO**************************************************
        Try
            MiConexion(bda)
            Try
                lbtipo.Text = txttipo.Text
                Dim t As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & lbtipo.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) = 0 Then
                    lbdoc.Text = NumeroDoc(1)
                Else
                    lbdoc.Text = NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                lbdoc.Text = NumeroDoc(1)
            End Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", lbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(lbdoc.Text.ToString))
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day)
            myCommand.Parameters.AddWithValue("?hora", Now.Hour)
            myCommand.Parameters.AddWithValue("?nitc", tabla.Rows(0).Item("nitc"))
            myCommand.Parameters.AddWithValue("?tipo_mov", "T")
            myCommand.Parameters.AddWithValue("?tipo", "TRASLADO")
            myCommand.Parameters.AddWithValue("?desc_mov", "ANULA A " & txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?cc", "0")
            myCommand.Parameters.AddWithValue("?concepto", "ANULACION " & txttipo.Text & " " & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", tabla.Rows(0).Item("total"))
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?desc_mov,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '****************guardar detalles*****************************
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM deta_mov" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                GuardarDetalles(i + 1, tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("nomart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"), tabla.Rows(i).Item("valor"), tabla.Rows(i).Item("cta_inv"), tabla.Rows(i).Item("cta_cos"), tabla.Rows(i).Item("cta_ing"), tabla.Rows(i).Item("cta_iva"), tabla.Rows(i).Item("costo"))
                ActualizarBodega(tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"))
            Next
            '********GENERAR DOCUENTO CONTABLE*************************************************
            '*****************
            ActualizarDoc()
            '*************************
            ActualizarConsecutivo()
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "ANULAR DOC: " & txttipo.Text & txtnumfac.Text, "", "", "")
            End If
            MsgBox("DOCUMENTO " & txttipo.Text & txtnumfac.Text & " ANULADO CON " & lbtipo.Text & lbdoc.Text, MsgBoxStyle.Information, "SAE Guardar")
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub AnularFactura()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtconcepto.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If VerificarDescrip(Trim(tabla.Rows(0).Item("desc_mov").ToString)) = False Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("dia").ToString & "/" & PerActual)
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
            End If
        End If
        '*********************ANULAR DOCUENTO**************************************************
        Try
            MiConexion(bda)
            Try
                Dim t As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & lbtipo.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) = 0 Then
                    lbdoc.Text = NumeroDoc(1)
                Else
                    lbdoc.Text = NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                lbdoc.Text = NumeroDoc(1)
            End Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", lbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(lbdoc.Text.ToString))
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day)
            myCommand.Parameters.AddWithValue("?hora", Now.Hour)
            myCommand.Parameters.AddWithValue("?nitc", tabla.Rows(0).Item("nitc"))
            sw_aju = 0
            If tabla.Rows(0).Item("tipodoc") = lbtipo.Text Then
                If tabla.Rows(0).Item("tipo_mov") = "A" Then ' ANULAR UN AJUSTE DE INVENTARIOS (CANTIDADES)
                    myCommand.Parameters.AddWithValue("?tipo_mov", "A")
                    If tabla.Rows(0).Item("tipo").ToString = "ENTRADA" Then
                        myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
                    Else
                        myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
                    End If
                Else
                    myCommand.Parameters.AddWithValue("?tipo_mov", "V") ' ANULAR UN AJUSTE DE INVENTARIOS (VALORES)
                    If tabla.Rows(0).Item("tipo").ToString = "para disminuir valores" Then
                        sw_aju = 1
                        myCommand.Parameters.AddWithValue("?tipo", "para aumentar valores")
                    Else
                        sw_aju = 2
                        myCommand.Parameters.AddWithValue("?tipo", "para disminuir valores")
                    End If
                End If
            Else
                myCommand.Parameters.AddWithValue("?tipo_mov", "A")
                If tabla.Rows(0).Item("tipo").ToString = "ENTRADA" Then
                    myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
                Else
                    myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
                End If
            End If
            myCommand.Parameters.AddWithValue("?desc_mov", "ANULA A " & txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?cc", tabla.Rows(0).Item("cc"))
            myCommand.Parameters.AddWithValue("?concepto", "ANULACION " & txttipo.Text & " " & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", tabla.Rows(0).Item("total"))
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?desc_mov,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '****************guardar detalles*****************************
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM deta_mov" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                GuardarDetalles(i + 1, tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("nomart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"), tabla.Rows(i).Item("valor"), tabla.Rows(i).Item("cta_inv"), tabla.Rows(i).Item("cta_cos"), tabla.Rows(i).Item("cta_ing"), tabla.Rows(i).Item("cta_iva"), tabla.Rows(i).Item("costo"))
                ActualizarBodega(tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"))
            Next
            '********GENERAR DOCUENTO CONTABLE*************************************************
            Contable()
            '*****************
            ActualizarDoc()
            '*************************
            ActualizarConsecutivo()
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "ANULAR DOC: " & txttipo.Text & txtnumfac.Text, "", "", "")
            End If
            MsgBox("DOCUMENTO " & txttipo.Text & txtnumfac.Text & " ANULADO CON " & lbtipo.Text & lbdoc.Text, MsgBoxStyle.Information, "SAE Guardar")
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetalles(ByVal it As Integer, ByVal codart As String, ByVal nom As String, ByVal bo As Integer, ByVal bd As Integer, ByVal cant As Double, ByVal valor As Double, ByVal cinv As String, ByVal ccos As String, ByVal cing As String, ByVal civa As String, ByVal costo As Double)
        Dim can As String = ""
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
        myCommand.Parameters.AddWithValue("?item", it)
        myCommand.Parameters.AddWithValue("?codart", codart)
        myCommand.Parameters.AddWithValue("?nomart", nom)
        myCommand.Parameters.AddWithValue("?bod_ori", bd)
        myCommand.Parameters.AddWithValue("?bod_des", bo)
        Try
            myCommand.Parameters.AddWithValue("?cantidad", cant)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cantidad", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?valor", valor)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?valor", "0")
        End Try
        '****************************************************************************************
        myCommand.Parameters.AddWithValue("?cta_inv", cinv)
        myCommand.Parameters.AddWithValue("?cta_cos", ccos)
        myCommand.Parameters.AddWithValue("?cta_ing", cing)
        myCommand.Parameters.AddWithValue("?cta_iva", civa)
        Try
            myCommand.Parameters.AddWithValue("?costo", costo)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?costo", "0")
        End Try
        myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
        & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            If sw_aju > 0 Then
                '*********************************************
                Dim t As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT formula FROM parinven;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                Dim formula As String
                formula = t.Rows(0).Item("formula")
                '*********************************************
                Try
                    can = "SUM( 0 "
                    Try
                        Dim tb As New DataTable
                        tb.Clear()
                        myCommand.CommandText = "SELECT * FROM bodegas;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tb)
                        For i = 0 To tb.Rows.Count - 1
                            can += " + cant" & tb.Rows(i).Item("numbod").ToString
                        Next
                    Catch ex As Exception
                    End Try
                    can += ")"
                    Dim tabla As New DataTable
                    tabla.Clear()
                    myCommand.CommandText = "SELECT codart,periodo," & can & " AS cant FROM con_inv WHERE codart='" & codart & "' AND periodo='" & PerActual(0) & PerActual(1) & "'  GROUP BY codart, periodo;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    valor = valor / CDbl(tabla.Rows(0).Item("cant").ToString)
                Catch ex As Exception
                End Try
                Actualizar_Con_inv(codart, valor, formula)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bo As Integer, ByVal bd As Integer, ByVal cantidad As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?cantidad", cantidad)
        If bo <> 0 Then 'HAY BODEGA ORIGEN ==> SUMO LA CANTIDAD RETIRADA
            myCommand.CommandText = "UPDATE con_inv SET cant" & bo & "=cant" & bo & " + ?cantidad " _
                                & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        End If
        If bd <> 0 Then 'HAY BODEGA DESTINO ==> RESTO LA CANTIDAD ALMACENADA
            myCommand.CommandText = "UPDATE con_inv SET cant" & bd & "=cant" & bd & " - ?cantidad " _
                                & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        End If
    End Sub
    Public Sub Contable()
        Try
            Dim tabla, tabla2 As New DataTable
            tabla2.Clear()
            myCommand.CommandText = "SELECT contable FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows(0).Item("contable") = "si" Then
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
                        myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day)
                        myCommand.Parameters.AddWithValue("?centro", tabla.Rows(i).Item("centro"))
                        myCommand.Parameters.AddWithValue("?descrip", CambiaCadena("ANULA A " & txttipo.Text & txtnumfac.Text & " " & tabla.Rows(i).Item("descri"), 50))
                        Try
                            myCommand.Parameters.AddWithValue("?debito", CDbl(tabla.Rows(i).Item("credito")))
                        Catch ex As Exception
                            myCommand.Parameters.AddWithValue("?debito", "0")
                        End Try
                        Try
                            myCommand.Parameters.AddWithValue("?credito", CDbl(tabla.Rows(i).Item("debito")))
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
                        myCommand.Parameters.AddWithValue("?modulo", "inventarios")
                        'INSERTAR CONTABLE
                        myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " " _
                                              & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,'',?modulo);"
                        myCommand.ExecuteNonQuery()
                        ActualizarMisCuentas(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("credito"), tabla.Rows(i).Item("debito"))
                    Catch ex As Exception
                        MsgBox("ERROR INSERTANDO DOCUMENTO CONTABLE:" & ex.ToString)
                    End Try
                Next
            End If
        Catch ex As Exception
            MsgBox("ERROR CON PARAMETROS DE INVENTARIOS: " & ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarDoc()
        myCommand.CommandText = "UPDATE movimientos" & PerActual(0) & PerActual(1) & " SET desc_mov='ANULADO CON " & lbtipo.Text & lbdoc.Text & "',observ='ANULADO CON " & lbtipo.Text & lbdoc.Text & "' WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
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
    '*************************************************************************
    Public Sub GuardarPrecios(ByVal codart As String, ByVal aju As Double, ByVal f As String)

    End Sub
    Public Sub Actualizar_Con_inv(ByVal codart As String, ByVal aju As Double, ByVal f As String)
        Dim precio, costo, costoprom, suma, margen As Double
        Dim cant As Integer
        '******** iva de l artiuclo***************************************
        Dim tabla As New DataTable
        tabla.Clear()
        '***********************************************
        myCommand.CommandText = "SELECT costuni,costprom,margen,precio1 FROM con_inv WHERE codart='" & codart & "' AND periodo ='" & PerActual(0) & PerActual(1) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        suma = 0
        cant = 1 'al menos el q acaba de entrar
        For i = 0 To tabla.Rows.Count - 1
            Try
                costoprom = tabla.Rows(i).Item("costprom")
            Catch ex As Exception
                costoprom = 0
            End Try
            If costoprom > 0 Then
                suma = suma + costoprom
                cant = cant + 1 'hubo compra en ese mes ==> entra en promedio
            End If
            Try
                costo = CDbl(tabla.Rows(i).Item("costuni"))
            Catch ex As Exception
                costo = 0
            End Try
        Next
        '******************************************************
        MsgBox("antes: " & costo & " **** " & aju)
        If costo = 0 Then
            costo = aju
        Else
            If sw_aju = 1 Then
                costo = costo + aju
            Else
                costo = costo - aju
            End If
        End If
        MsgBox("Despues: " & costo)
        '*****************************************************
        Try
            margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("margen")) 'margen del periodo actual (el ultimo campo)
        Catch ex As Exception
            margen = 0
        End Try
        suma = suma + costo
        costoprom = suma / cant
        '*********************************
        If f = "/" Then 'precio segun formula
            precio = costo / (1 - margen / 100)
        ElseIf f = "manual" Then
            Try
                margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("precio1")) 'precio1 del periodo actual porq es manual(el ultimo campo)
            Catch ex As Exception
                margen = 0
            End Try
        Else
            precio = costo * (1 + margen / 100)
        End If
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cosuni", costo)
            myCommand.Parameters.AddWithValue("?costprom", costoprom)
            myCommand.Parameters.AddWithValue("?precio", precio)
            myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom,precio1=?precio " _
                                 & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
            myCommand.Parameters.AddWithValue("?precio", DIN(precio))
            myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni,precio=?precio " _
                                  & " WHERE codart='" & codart & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub txtnumfac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumfac.TextChanged

    End Sub
End Class