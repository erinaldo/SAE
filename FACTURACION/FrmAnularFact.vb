Public Class FrmAnularFact

    Private Sub FrmAnularFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        txtfecha_ana.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4,tipoaj FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("tipof1")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
            txttipo.Text = Trim(tabla.Rows(0).Item("tipof1"))
        End If
        If Trim(tabla.Rows(0).Item("tipof2")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
        End If
        If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
        End If
        If Trim(tabla.Rows(0).Item("tipof4")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
        End If
        If Trim(tabla.Rows(0).Item("tipoaj")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
            lbtipo.Text = Trim(tabla.Rows(0).Item("tipoaj"))
        Else
            MsgBox("No han asignado documento para ajustes de facturación... ", MsgBoxStyle.Information, "SAE Control")
            Me.Close()
        End If
        '******************************************
        cbper.Text = PerActual(0) & PerActual(1)
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
        If (txtfecha_ana.Value < txtfecha.Value) Then
            MsgBox("Favor escoja una fecha de anulación valida(el dia debe ser mayor o igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        'If (Val(txtfecha_ana.Value.Month) <> Val(cbper.Text)) Then
        '    MsgBox("Favor escoja una fecha de anulación valida(el periodo debe ser igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
        '    txtfecha_ana.Focus()
        '    Exit Sub
        'End If
        If txtfecha_ana.Value.Year <> (PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)) Then
            MsgBox("Favor escoja una fecha de anulación valida(el año de coincidir con el actualmente utilizado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El docuemento " & txttipo.Text & txtnumfac.Text & " será anulado, ¿Desea Anularlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            AnularFactura()
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        txtfecha.Value = Today
        txtfecha_ana.Value = Today
        limpiar()
    End Sub
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
        limpiar()
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
        myCommand.CommandText = "SELECT * FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("descrip").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
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
    '************************************************************************************
    Public Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String)
        'otros conceptos
        Dim sql As String = ""
        Dim sig As String = ""
        If txttipo.Text = lbtipo.Text Then
            sig = "+"
        Else
            sig = "-"
        End If
        Try
            If Trim(doc) <> "" Then
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_de_clie SET causado = causado " & sig & " " & DIN(valor) & " WHERE per_doc='" & Trim(doc) & "';"
                'MsgBox(sql)
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim per As String
    Public Sub AnularFactura()
        per = ""
        per = Strings.Mid(txtfecha_ana.Value, 4, 2)

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("descrip").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
                Exit Sub
            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
                Exit Sub
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
            End If
        End If
        '******************************************
        myCommand.Parameters.Clear()
        Dim afecta As String
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
            Exit Sub
        Else
            afecta = tabla.Rows(0).Item("afecta")
            Try
                MiConexion(bda)
                lbdoc.Text = NumeroAJ()
                myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
                myCommand.Parameters.AddWithValue("?num", Val(lbdoc.Text))
                myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_de", tabla.Rows(0).Item("doc_de"))
                myCommand.Parameters.AddWithValue("?nitc", tabla.Rows(0).Item("nitc"))
                myCommand.Parameters.AddWithValue("?nitv", tabla.Rows(0).Item("nitv"))
                myCommand.Parameters.AddWithValue("?usuario", FrmPrincipal.lbuser.Text)
                myCommand.Parameters.AddWithValue("?fecha", txtfecha_ana.Value)
                myCommand.Parameters.AddWithValue("?hora", Now.Hour)
                myCommand.Parameters.AddWithValue("?descrip", "ANULA A " & txttipo.Text & txtnumfac.Text)
                myCommand.Parameters.AddWithValue("?doc_afec", txttipo.Text & txtnumfac.Text)
                myCommand.Parameters.AddWithValue("?afecta", tabla.Rows(0).Item("afecta"))
                'subtotal
                myCommand.Parameters.AddWithValue("?subtotal", tabla.Rows(0).Item("subtotal"))
                'descuento
                myCommand.Parameters.AddWithValue("?por_desc", DIN(tabla.Rows(0).Item("por_desc").ToString))
                myCommand.Parameters.AddWithValue("?descuento", DIN(tabla.Rows(0).Item("descuento").ToString))
                myCommand.Parameters.AddWithValue("?cta_desc", tabla.Rows(0).Item("cta_desc"))
                'rete_fuente
                myCommand.Parameters.AddWithValue("?por_ret_f", DIN(tabla.Rows(0).Item("por_ret_f").ToString))
                myCommand.Parameters.AddWithValue("?ret_f", DIN(tabla.Rows(0).Item("ret_f").ToString))
                myCommand.Parameters.AddWithValue("?cta_ret_f", tabla.Rows(0).Item("cta_ret_f").ToString)
                'iva
                myCommand.Parameters.AddWithValue("?por_iva", DIN(tabla.Rows(0).Item("por_iva").ToString))
                myCommand.Parameters.AddWithValue("?iva", DIN(tabla.Rows(0).Item("iva").ToString))
                myCommand.Parameters.AddWithValue("?cta_iva", tabla.Rows(0).Item("cta_iva").ToString)
                'rete_iva
                myCommand.Parameters.AddWithValue("?por_ret_iva", DIN(tabla.Rows(0).Item("por_ret_iva").ToString))
                myCommand.Parameters.AddWithValue("?ret_iva", DIN(tabla.Rows(0).Item("ret_iva").ToString))
                myCommand.Parameters.AddWithValue("?cta_ret_iva", tabla.Rows(0).Item("cta_ret_iva").ToString)
                'rete_cree
                myCommand.Parameters.AddWithValue("?porcree", DIN(tabla.Rows(0).Item("por_rtc").ToString))
                myCommand.Parameters.AddWithValue("?retcree", DIN(tabla.Rows(0).Item("rtc").ToString))
                myCommand.Parameters.AddWithValue("?ctacree", tabla.Rows(0).Item("cta_rtc").ToString)
                'ret_ica
                myCommand.Parameters.AddWithValue("?por_ret_ica", DIN(tabla.Rows(0).Item("por_ret_ica").ToString))
                myCommand.Parameters.AddWithValue("?ret_ica", DIN(tabla.Rows(0).Item("ret_ica").ToString))
                myCommand.Parameters.AddWithValue("?cta_ret_ica", tabla.Rows(0).Item("cta_ret_ica").ToString)
                'total
                myCommand.Parameters.AddWithValue("?total", DIN(tabla.Rows(0).Item("total").ToString))
                myCommand.Parameters.AddWithValue("?cta_total", tabla.Rows(0).Item("cta_total").ToString)
                'aprobada
                myCommand.Parameters.AddWithValue("?estado", tabla.Rows(0).Item("estado").ToString)
                'observaciones
                myCommand.Parameters.AddWithValue("?observ", Trim(tabla.Rows(0).Item("observ").ToString & " ANULA A " & txttipo.Text & txtnumfac.Text))
                'dias de vmto
                myCommand.Parameters.AddWithValue("?vmto", tabla.Rows(0).Item("vmto").ToString)
                'datos de entega
                myCommand.Parameters.AddWithValue("?entregar", tabla.Rows(0).Item("entregar").ToString)
                myCommand.Parameters.AddWithValue("?dir_ent", tabla.Rows(0).Item("dir_ent").ToString)
                myCommand.Parameters.AddWithValue("?ciu_ent", tabla.Rows(0).Item("ciu_ent").ToString)
                myCommand.Parameters.AddWithValue("?o_compra", tabla.Rows(0).Item("o_compra").ToString)
                myCommand.Parameters.AddWithValue("?fecha_o", tabla.Rows(0).Item("fecha_o").ToString)
                myCommand.Parameters.AddWithValue("?cc", tabla.Rows(0).Item("cc"))
                'conceptos
                myCommand.Parameters.AddWithValue("?o_con", tabla.Rows(0).Item("o_con").ToString)
                myCommand.Parameters.AddWithValue("?t1", tabla.Rows(0).Item("t1").ToString)
                myCommand.Parameters.AddWithValue("?d1", tabla.Rows(0).Item("d1").ToString)
                myCommand.Parameters.AddWithValue("?v1", DIN(tabla.Rows(0).Item("v1").ToString))
                myCommand.Parameters.AddWithValue("?cta1", tabla.Rows(0).Item("cta1").ToString)
                myCommand.Parameters.AddWithValue("?t2", tabla.Rows(0).Item("t2").ToString)
                myCommand.Parameters.AddWithValue("?d2", tabla.Rows(0).Item("d2").ToString)
                myCommand.Parameters.AddWithValue("?v2", DIN(tabla.Rows(0).Item("v2").ToString))
                myCommand.Parameters.AddWithValue("?cta2", tabla.Rows(0).Item("cta2").ToString)
                myCommand.Parameters.AddWithValue("?t3", tabla.Rows(0).Item("t3").ToString)
                myCommand.Parameters.AddWithValue("?d3", tabla.Rows(0).Item("d3").ToString)
                myCommand.Parameters.AddWithValue("?v3", DIN(tabla.Rows(0).Item("v3").ToString))
                myCommand.Parameters.AddWithValue("?cta3", tabla.Rows(0).Item("cta3").ToString)
                myCommand.Parameters.AddWithValue("?doc1", tabla.Rows(0).Item("doc1").ToString)
                myCommand.Parameters.AddWithValue("?doc2", tabla.Rows(0).Item("doc2").ToString)
                myCommand.Parameters.AddWithValue("?doc3", tabla.Rows(0).Item("doc3").ToString)
                myCommand.Parameters.AddWithValue("?vl_aj", DIN(0))
                'INSERTAR FACTURA
                myCommand.CommandText = "INSERT INTO facturas" & per & " VALUES (?doc,?num,?tipodoc,?doc_de,?nitc,?nitv,?usuario,?fecha,?hora,?descrip,?doc_afec,?afecta," _
                                      & "?subtotal,?por_desc,?descuento,?cta_desc,?por_ret_f,?ret_f,?cta_ret_f,?por_iva,?iva,?cta_iva,?por_ret_iva,?ret_iva,?cta_ret_iva,?por_ret_ica,?ret_ica,?cta_ret_ica," _
                                      & "?total,?cta_total,?estado,?observ,?vmto,?entregar,?dir_ent,?ciu_ent,?o_compra,?fecha_o,?cc," _
                                      & "?o_con,?t1,?d1,?v1,?cta1,?t2,?d2,?v2,?cta2,?t3,?d3,?v3,?cta3,?doc1,?doc2,?doc3,?vl_aj,?porcree,?retcree,?ctacree);"
                myCommand.ExecuteNonQuery()
                Refresh()
                If tabla.Rows(0).Item("o_con").ToString = "si" Then
                    GuardOtrosC()
                End If
                'GuardarAnticipos(tabla.Rows(0).Item("v1").ToString, tabla.Rows(0).Item("doc1").ToString)
                'GuardarAnticipos(tabla.Rows(0).Item("v2").ToString, tabla.Rows(0).Item("doc2").ToString)
                'GuardarAnticipos(tabla.Rows(0).Item("v3").ToString, tabla.Rows(0).Item("doc3").ToString)
                'otros conceptos
                '**** ACTUALIZAR EN BODEGAS
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM detafac" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                For i = 0 To tabla.Rows.Count - 1
                    GuardarDetalles(i + 1, tabla.Rows(i).Item("tipo_it"), tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("nomart"), tabla.Rows(i).Item("numbod"), tabla.Rows(i).Item("cantidad"), tabla.Rows(i).Item("valor"), tabla.Rows(i).Item("iva_d"), tabla.Rows(i).Item("por_des"), tabla.Rows(i).Item("cta_inv"), tabla.Rows(i).Item("cta_cos"), tabla.Rows(i).Item("cta_ing"), tabla.Rows(i).Item("cta_iva"), tabla.Rows(i).Item("costo"), tabla.Rows(i).Item("concep"))
                    If tabla.Rows(i).Item("tipo_it") = "I" Then
                        ActualizarBodega(tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("numbod"), tabla.Rows(i).Item("cantidad"))
                    End If
                Next
                '********GENERAR DOCUENTO CONTABLE*************************************************
                Contable()
                '*****************
                ActualizarDoc()
                '*************************
                ActualizarConsecutivo()
                '*******************************
                AnularInv()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "ANULAR DOC " & txttipo.Text & txtnumfac.Text & " - PERIODO " & cbper.Text, "ANULAR", "", " ANULADO CON " & lbtipo.Text & lbdoc.Text)
                End If
                '.....
                MsgBox("DOCUMENTO " & txttipo.Text & txtnumfac.Text & " ANULADO CON " & lbtipo.Text & lbdoc.Text, MsgBoxStyle.Information, "SAE Guardar")
                Cerrar()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Private Sub GuardOtrosC()
        Dim tl As New DataTable
        tl.Clear()
        myCommand.CommandText = "SELECT * FROM otcon_fac" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tl)
        Refresh()
        If tl.Rows.Count > 0 Then
            For j = 0 To tl.Rows.Count - 1
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
                myCommand.Parameters.AddWithValue("?itm", j + 1)
                myCommand.Parameters.AddWithValue("?sg", tl.Rows(j).Item("tipo"))
                myCommand.Parameters.AddWithValue("?des", tl.Rows(j).Item("descrip"))
                myCommand.Parameters.AddWithValue("?v", DIN(tl.Rows(j).Item("valor")))
                myCommand.Parameters.AddWithValue("?b", DIN(tl.Rows(j).Item("base")))
                myCommand.Parameters.AddWithValue("?cta", tl.Rows(j).Item("cta"))
                myCommand.Parameters.AddWithValue("?docAn", tl.Rows(j).Item("doc_ant"))
                myCommand.CommandText = "INSERT INTO otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                      & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                myCommand.ExecuteNonQuery()

                GuardarAnticipos(tl.Rows(j).Item("valor").ToString, tl.Rows(j).Item("doc_ant").ToString)
            Next
        End If
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer, ByVal tipo As Char, ByVal codart As String, ByVal des As String, ByVal bod As Integer, ByVal cantidad As Double, ByVal valor As Double, ByVal iva As Decimal, ByVal por_des As Decimal, ByVal ctainv As String, ByVal ctacos As String, ByVal ctaing As String, ByVal ctaiva As String, ByVal costo As Double, ByVal concepto As String)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
        myCommand.Parameters.AddWithValue("?item", fila)
        myCommand.Parameters.AddWithValue("?tipo_it", tipo)
        myCommand.Parameters.AddWithValue("?codart", codart)
        myCommand.Parameters.AddWithValue("?descrip", des)
        myCommand.Parameters.AddWithValue("?numbod", bod)
        myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
        myCommand.Parameters.AddWithValue("?valor", DIN(valor))
        myCommand.Parameters.AddWithValue("?vtotal", DIN(valor * cantidad))
        myCommand.Parameters.AddWithValue("?iva_d", iva)
        myCommand.Parameters.AddWithValue("?por_des", por_des)
        'cuentas y concepto
        myCommand.Parameters.AddWithValue("?cta_inv", ctainv)
        myCommand.Parameters.AddWithValue("?cta_cos", ctacos)
        myCommand.Parameters.AddWithValue("?cta_ing", ctaing)
        myCommand.Parameters.AddWithValue("?cta_iva", ctaiva)
        myCommand.Parameters.AddWithValue("?costo", costo)
        myCommand.Parameters.AddWithValue("?concep", concepto)
        myCommand.Parameters.AddWithValue("?nit", "")
        'INSERTAR DETALLES
        myCommand.CommandText = "INSERT INTO detafac" & per & " " _
                              & " VALUES(?doc,?item,?tipo_it,?codart,?descrip,?numbod,?cantidad,?valor,?vtotal,?iva_d,?por_des,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo,?concep,?nit);"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bod As Integer, ByVal cantidad As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
        myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " + ?cantidad " _
                                & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub ActualizarDoc()
        myCommand.CommandText = "UPDATE facturas" & cbper.Text & " SET descrip='ANULADO CON " & lbtipo.Text & lbdoc.Text & "', observ= concat(observ , ' ANULADO CON " & lbtipo.Text & lbdoc.Text & "') WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
        '**************
        myCommand.CommandText = "DELETE FROM cobdpen WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
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
        Try
            Return NumeroDoc(Val(tabla2.Rows(0).Item(0)) + 1)
        Catch ex As Exception
            Return NumeroDoc(1)
        End Try

        '****************
        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE tipdoc SET actual" & cbper.Text & "='" & Val(tabla2.Rows(0).Item(0)) + 1 & "' WHERE tipodoc='" & tipo & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        '********************
    End Function
    Public Sub Contable()
        Try
            Dim tabla, tabla2 As New DataTable
            tabla2.Clear()
            myCommand.CommandText = "SELECT intecontab FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows(0).Item("intecontab") = "SI" Then
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM documentos" & cbper.Text & " WHERE doc='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "' ORDER BY item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                For i = 0 To tabla.Rows.Count - 1
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?item", tabla.Rows(i).Item("item"))
                        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text.ToString)
                        myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text)
                        myCommand.Parameters.AddWithValue("?periodo", cbper.Text & "/" & txtfecha_ana.Value.Year)
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
                        myCommand.Parameters.AddWithValue("?base", DIN(tabla.Rows(i).Item("base")))
                        myCommand.Parameters.AddWithValue("?diasv", tabla.Rows(i).Item("diasv"))
                        myCommand.Parameters.AddWithValue("?cheque", tabla.Rows(i).Item("cheque"))
                        Try
                            myCommand.Parameters.AddWithValue("?fechaven", tabla.Rows(i).Item("fechaven"))
                        Catch ex As Exception
                            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
                        End Try
                        myCommand.Parameters.AddWithValue("?nit", tabla.Rows(i).Item("nit"))
                        myCommand.Parameters.AddWithValue("?modulo", "facturacion")
                        'INSERTAR CONTABLE
                        myCommand.CommandText = "INSERT INTO documentos" & per & " " _
                                              & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
                        myCommand.ExecuteNonQuery()
                        ActualizarMisCuentas(tabla.Rows(i).Item("codigo"), tabla.Rows(i).Item("credito"), tabla.Rows(i).Item("debito"))
                    Catch ex As Exception
                        MsgBox("ERROR INSERTANDO DOCUMENTO CONTABLE:" & ex.ToString)
                    End Try
                Next
            End If
        Catch ex As Exception
            MsgBox("ERROR CON PARAMETROS DE FACTURACIÓN: " & ex.ToString)
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
            myCommand.CommandText = "UPDATE tipdoc SET actual" & per & "='" & num & "' WHERE tipodoc='" & lbtipo.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '********************************************
    Public Sub AnularInv()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '*********************ANULAR DOCUENTO**************************************************
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", lbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(lbdoc.Text.ToString))
            myCommand.Parameters.AddWithValue("?per", cbper.Text)
            myCommand.Parameters.AddWithValue("?dia", txtfecha_ana.Value.Day)
            myCommand.Parameters.AddWithValue("?hora", Now.Hour)
            myCommand.Parameters.AddWithValue("?nitc", tabla.Rows(0).Item("nitc"))
            myCommand.Parameters.AddWithValue("?tipo_mov", "A")
            If tabla.Rows(0).Item("tipo").ToString = "ENTRADA" Then
                myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
            Else
                myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
            End If
            myCommand.Parameters.AddWithValue("?desc_mov", "ANULA A " & txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?cc", tabla.Rows(0).Item("cc"))
            myCommand.Parameters.AddWithValue("?concepto", "ANULACION " & txttipo.Text & " " & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", tabla.Rows(0).Item("total"))
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.CommandText = "INSERT INTO movimientos" & per & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?desc_mov,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '****************guardar detalles*****************************
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM deta_mov" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                GuardarDetallesInv(i + 1, tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("nomart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"), tabla.Rows(i).Item("valor"), tabla.Rows(i).Item("cta_inv"), tabla.Rows(i).Item("cta_cos"), tabla.Rows(i).Item("cta_ing"), tabla.Rows(i).Item("cta_iva"), tabla.Rows(i).Item("costo"))
            Next
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetallesInv(ByVal it As Integer, ByVal codart As String, ByVal nom As String, ByVal bo As Integer, ByVal bd As Integer, ByVal cant As Double, ByVal valor As Double, ByVal cinv As String, ByVal ccos As String, ByVal cing As String, ByVal civa As String, ByVal costo As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", lbtipo.Text & lbdoc.Text)
        myCommand.Parameters.AddWithValue("?item", it)
        myCommand.Parameters.AddWithValue("?codart", codart)
        myCommand.Parameters.AddWithValue("?nomart", nom)
        myCommand.Parameters.AddWithValue("?bod_ori", bd)
        myCommand.Parameters.AddWithValue("?bod_des", bo)
        Try
            myCommand.Parameters.AddWithValue("?cantidad", DIN(cant))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cantidad", "0")
        End Try
        Try
            myCommand.Parameters.AddWithValue("?valor", DIN(valor))
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
        myCommand.CommandText = "INSERT INTO deta_mov" & per & " " _
        & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        limpiar()
        FrmSelFacturaVenta.lbform.Text = "anularFact"
        FrmSelFacturaVenta.Label1.Visible = False
        FrmSelFacturaVenta.cmbper.Visible = False
        FrmSelFacturaVenta.ShowDialog()
        If txtnumfac.Text <> "" Then
            txtnumfac_LostFocus(AcceptButton, AcceptButton)
        End If
    End Sub
    Public Sub limpiar()
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
    End Sub
End Class