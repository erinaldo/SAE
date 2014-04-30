Public Class FrmAnularCompras

    Private Sub FrmAnularCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        txtfecha_ana.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT doc_fp, doc_aj FROM par_comp;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("doc_fp")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fp")))
            txttipo.Text = Trim(tabla.Rows(0).Item("doc_fp"))
        End If
        'If Trim(tabla.Rows(0).Item("doc_aj")) <> "" Then
        '    txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_aj")))
        'End If
        If Trim(tabla.Rows(0).Item("doc_aj")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_aj")))
            lbtipo.Text = Trim(tabla.Rows(0).Item("doc_aj"))
        Else
            MsgBox("No han asignado documento para ajustes de compras... ", MsgBoxStyle.Information, "SAE Control")
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
        If (txtfecha_ana.Value.Day < txtfecha.Value.Day) Then
            MsgBox("Favor escoja una fecha de anulación valida(el dia debe ser mayor o igual al del documento que será anulado).", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha_ana.Focus()
            Exit Sub
        End If
        If (Val(txtfecha_ana.Value.Month) <> Val(cbper.Text)) Then
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
            AnularFactura()
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        txtnumfac.Text = ""
        txtfecha.Value = Today
        txtfecha_ana.Value = Today
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
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
        txtnumfac.Text = ""
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
        myCommand.CommandText = "SELECT * FROM fact_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("anulado").ToString) <> "no" Then
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
    Public Sub AnularFactura()
        Dim sig As String = ""
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM fact_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("anulado").ToString) <> "no" Then
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
        myCommand.CommandText = "SELECT * FROM fact_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
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
                ' myCommand.Parameters.AddWithValue("?nitv", tabla.Rows(0).Item("nitv"))
                myCommand.Parameters.AddWithValue("?usuario", FrmPrincipal.lbuser.Text)
                myCommand.Parameters.AddWithValue("?fecha", txtfecha_ana.Value)
                myCommand.Parameters.AddWithValue("?hora", Now.Hour)
                myCommand.Parameters.AddWithValue("?anulado", "no")
                myCommand.Parameters.AddWithValue("?doc_afec", txttipo.Text & txtnumfac.Text)
                myCommand.Parameters.AddWithValue("?afecta", tabla.Rows(0).Item("afecta"))
                'subtotal
                myCommand.Parameters.AddWithValue("?subtotal", tabla.Rows(0).Item("subtotal"))
                'descuento
                myCommand.Parameters.AddWithValue("?por_desc", DIN(tabla.Rows(0).Item("por_desc").ToString))
                myCommand.Parameters.AddWithValue("?descuento", DIN(tabla.Rows(0).Item("descuento").ToString))
                myCommand.Parameters.AddWithValue("?cta_desc", tabla.Rows(0).Item("cta_desc").ToString)
                'rete_fuente
                myCommand.Parameters.AddWithValue("?por_rtf", DIN(tabla.Rows(0).Item("por_rtf").ToString))
                myCommand.Parameters.AddWithValue("?rtf", DIN(tabla.Rows(0).Item("rtf").ToString))
                myCommand.Parameters.AddWithValue("?cta_rtf", tabla.Rows(0).Item("cta_rtf").ToString)
                'iva
                myCommand.Parameters.AddWithValue("?por_iva", DIN(tabla.Rows(0).Item("por_iva").ToString))
                myCommand.Parameters.AddWithValue("?iva", DIN(tabla.Rows(0).Item("iva").ToString))
                myCommand.Parameters.AddWithValue("?cta_iva", tabla.Rows(0).Item("cta_iva").ToString)
                'iva
                myCommand.Parameters.AddWithValue("?por_cree", DIN(tabla.Rows(0).Item("por_rtc").ToString))
                myCommand.Parameters.AddWithValue("?cree", DIN(tabla.Rows(0).Item("rtc").ToString))
                myCommand.Parameters.AddWithValue("?cta_cree", tabla.Rows(0).Item("cta_rtc").ToString)
                'fletes
                myCommand.Parameters.AddWithValue("?fle", DIN(tabla.Rows(0).Item("fle").ToString))
                myCommand.Parameters.AddWithValue("?cta_fle", tabla.Rows(0).Item("cta_fle").ToString)
                'seguros
                myCommand.Parameters.AddWithValue("?seg", DIN(tabla.Rows(0).Item("seg").ToString))
                myCommand.Parameters.AddWithValue("?cta_seg", tabla.Rows(0).Item("cta_seg").ToString)
                'total
                myCommand.Parameters.AddWithValue("?total", DIN(tabla.Rows(0).Item("total")))
                myCommand.Parameters.AddWithValue("?cta_total", tabla.Rows(0).Item("cta_total").ToString)
                'aprobada
                myCommand.Parameters.AddWithValue("?estado", tabla.Rows(0).Item("estado").ToString)
                'observaciones
                myCommand.Parameters.AddWithValue("?observ", "ANULA DOCUMENTO " & txttipo.Text & txtnumfac.Text)
                'dias de vmto
                myCommand.Parameters.AddWithValue("?vmto", tabla.Rows(0).Item("vmto"))
                'centro de costo
                myCommand.Parameters.AddWithValue("?ctoc", tabla.Rows(0).Item("ctoc"))
                'fpago
                myCommand.Parameters.AddWithValue("?fpago", tabla.Rows(0).Item("fpago").ToString)
                myCommand.Parameters.AddWithValue("?num_ch", tabla.Rows(0).Item("num_ch").ToString)
                myCommand.Parameters.AddWithValue("?banco", tabla.Rows(0).Item("banco").ToString)
                myCommand.Parameters.AddWithValue("?tip_tarj", tabla.Rows(0).Item("tip_tarj").ToString)
                myCommand.Parameters.AddWithValue("?num_tarj", tabla.Rows(0).Item("num_tarj").ToString)
                myCommand.Parameters.AddWithValue("?desc_otra", tabla.Rows(0).Item("desc_otra").ToString)
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

                myCommand.Parameters.AddWithValue("?b1", tabla.Rows(0).Item("b1").ToString)
                myCommand.Parameters.AddWithValue("?b2", DIN(tabla.Rows(0).Item("b2").ToString))
                myCommand.Parameters.AddWithValue("?b3", tabla.Rows(0).Item("b3").ToString)
                '***********************
                myCommand.Parameters.AddWithValue("?doc1", tabla.Rows(0).Item("doc1").ToString)
                myCommand.Parameters.AddWithValue("?doc2", DIN(tabla.Rows(0).Item("doc2").ToString))
                myCommand.Parameters.AddWithValue("?doc3", tabla.Rows(0).Item("doc3").ToString)
                myCommand.Parameters.AddWithValue("?doaj", DIN(0))
                '****************************
                'INSERTAR FACTURA
                'INSERTAR FACTURA
                myCommand.CommandText = "INSERT INTO fact_comp" & cbper.Text & " VALUES (?doc,?num,?tipodoc,?doc_de,?nitc,?usuario,?fecha,?hora,?anulado,?doc_afec,?afecta," _
                                      & "?subtotal,?por_desc,?descuento,?cta_desc,?por_rtf,?rtf,?cta_rtf,?por_iva,?iva,?cta_iva,?fle,?cta_fle,?seg,?cta_seg," _
                                      & "?total,?cta_total,?estado,?observ,?vmto,?ctoc," _
                                      & "?fpago,?num_ch,?banco,?tip_tarj,?num_tarj,?desc_otra," _
                                      & "?o_con,?t1,?d1,?v1,?cta1,?t2,?d2,?v2,?cta2,?t3,?d3,?v3,?cta3,?b1,?b2,?b3,?doc1,?doc2,?doc3,?doaj,?por_cree,?cree,?cta_cree);"
                myCommand.ExecuteNonQuery()
                Refresh()
                If tabla.Rows(0).Item("o_con").ToString = "si" Then
                    GuardOtrosC()
                End If
                ''ANTIICPOS
                'For i = 1 To 3
                '    Try
                '        If txttipo.Text = lbdoc.Text Then
                '            sig = "+"
                '        Else
                '            sig = "-"
                '        End If
                '        GuardarAnticipos(tabla.Rows(0).Item("v" & i).ToString, tabla.Rows(0).Item("doc" & i).ToString, sig)
                '    Catch ex As Exception
                '    End Try
                'Next
                '**** ACTUALIZAR EN BODEGAS
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM detacomp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                For i = 0 To tabla.Rows.Count - 1
                    GuardarDetalles(i + 1, tabla.Rows(i).Item("tipo_it"), tabla.Rows(i).Item("cod_art"), tabla.Rows(i).Item("nom_art"), tabla.Rows(i).Item("num_bod"), tabla.Rows(i).Item("cantidad"), tabla.Rows(i).Item("valor"), tabla.Rows(i).Item("por_iva_g"), tabla.Rows(i).Item("cta_inv"), tabla.Rows(i).Item("cta_cos"), tabla.Rows(i).Item("cta_gas"), tabla.Rows(i).Item("cta_iva"), tabla.Rows(i).Item("concep"), tabla.Rows(i).Item("por_des").ToString)
                    If tabla.Rows(i).Item("tipo_it") = "I" Then
                        ActualizarBodega(tabla.Rows(i).Item("cod_art"), tabla.Rows(i).Item("num_bod"), tabla.Rows(i).Item("cantidad"))
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
                '************************
                SacarCartera()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("COMPRAS", "ANULAR FACTURA DE COMPRA : " & txttipo.Text & txtnumfac.Text & "-" & cbper.Text, "", "", "")
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
        Dim sig As String = ""
        Dim tl As New DataTable
        tl.Clear()
        myCommand.CommandText = "SELECT * FROM otcon_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
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
                myCommand.CommandText = "INSERT INTO otcon_comp" & PerActual(0) & PerActual(1) & " " _
                                      & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                myCommand.ExecuteNonQuery()

                Try
                    If txttipo.Text = lbdoc.Text Then
                        sig = "+"
                    Else
                        sig = "-"
                    End If
                    GuardarAnticipos(tl.Rows(j).Item("valor").ToString, tl.Rows(j).Item("doc_ant").ToString, sig)
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub
    Public Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String, ByVal sig As String)
        'otros conceptos
        Dim sql As String = ""

        Try
            If doc <> "" Then
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(valor) & " WHERE per_doc='" & Trim(doc) & "';"
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer, ByVal tipo As Char, ByVal codart As String, ByVal des As String, ByVal bod As Integer, ByVal cantidad As Double, ByVal valor As Double, ByVal iva As Decimal, ByVal ctainv As String, ByVal ctacos As String, ByVal ctaing As String, ByVal ctaiva As String, ByVal concepto As String, ByVal dcto As String)
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
        myCommand.Parameters.AddWithValue("?iva_d", DIN(iva))
        myCommand.Parameters.AddWithValue("?por_des", DIN(Moneda(dcto)))
        'cuentas y concepto
        myCommand.Parameters.AddWithValue("?cta_inv", ctainv)
        myCommand.Parameters.AddWithValue("?cta_cos", ctacos)
        myCommand.Parameters.AddWithValue("?cta_gas", ctaing)
        myCommand.Parameters.AddWithValue("?cta_iva", ctaiva)
        myCommand.Parameters.AddWithValue("?concep", concepto)
        'INSERTAR DETALLES
        myCommand.CommandText = "INSERT INTO detacomp" & cbper.Text & " " _
                              & " VALUES(?doc,?item,?tipo_it,?codart,?descrip,?numbod,?cantidad,?valor,?vtotal,?iva_d,?por_des,?cta_inv,?cta_cos,?cta_gas,?cta_iva,?concep);"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bod As Integer, ByVal cantidad As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
        If txttipo.Text <> lbtipo.Text Then
            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " - ?cantidad " _
            & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
        Else
            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " + ?cantidad " _
            & " WHERE codart='" & codart & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
        End If
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub ActualizarDoc()
        myCommand.CommandText = "UPDATE fact_comp" & cbper.Text & " SET anulado='si', observ= concat(observ , ' ANULADO CON " & lbtipo.Text & lbdoc.Text & "') WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Private Sub SacarCartera()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM ctas_x_pagar WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
    End Sub
    Function NumeroAJ()
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT doc_aj FROM par_comp;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Dim tipo As String = tabla.Rows(0).Item("doc_aj")
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
                        Try
                            myCommand.Parameters.AddWithValue("?fechaven", tabla.Rows(i).Item("fechaven"))
                        Catch ex As Exception
                            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
                        End Try
                        myCommand.Parameters.AddWithValue("?nit", tabla.Rows(i).Item("nit"))
                        myCommand.Parameters.AddWithValue("?modulo", "facturacion")
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
            myCommand.CommandText = "UPDATE tipdoc SET actual" & cbper.Text & "='" & num & "' WHERE tipodoc='" & lbtipo.Text & "';"
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
            myCommand.CommandText = "INSERT INTO movimientos" & cbper.Text & " " _
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
        myCommand.CommandText = "INSERT INTO deta_mov" & cbper.Text & " " _
        & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class