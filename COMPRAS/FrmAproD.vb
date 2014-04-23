Imports MySql.Data.MySqlClient
Public Class FrmAproD
    Dim p As String
    Dim conexion As New MySqlConnection
    Dim cadena As String
    Dim concep As Integer = 0
    Private Sub FrmAproD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        txtaño.Text = PerActual(2) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim resultado As MsgBoxResult
        Dim ndoc As String = ""
        Dim afec As String = ""
        Dim sig As String = ""
        conexion.Close()
        p = cbper.Text

        grilla.Rows.Clear()
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT f.doc, f.tipodoc, f.estado, f.afecta, f.fpago FROM fact_comp" & p & " f WHERE f.estado <> 'AP' ;"
        ' myCommand.CommandText = " SELECT f.doc, f.tipodoc, f.estado, f.afecta, f.fpago FROM fact_comp" & p & " f WHERE f.estado <> 'AP'  and f.doc in ('FP25164')  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim ajust As String = ""
        Dim tabla_A As New DataTable
        myCommand.CommandText = " SELECT doc_aj FROM `par_comp` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_A)
        Refresh()
        ajust = tabla_A.Rows(0).Item(0).ToString

        If tabla.Rows.Count > 0 Then
            resultado = MsgBox("Desea aprobar todos los documentos del  periodo " & p & " ?", MsgBoxStyle.YesNo, "Confirmacion")
            If resultado = MsgBoxResult.No Then
                Me.Close()
            Else
                Dim it As Integer = 0
                mibarra.Value = 0
                mibarra.Visible = True
                mibarra.Maximum = tabla.Rows.Count
                it = 1
                Me.Cursor = Cursors.WaitCursor

                For i = 0 To tabla.Rows.Count - 1
                    ndoc = tabla.Rows(i).Item("doc")
                    afec = tabla.Rows(i).Item("afecta")

                    aprobar(ndoc)
                    con_inv(ndoc, afec, tabla_A.Rows(0).Item(0))
                    movimientos(ndoc, afec, tabla_A.Rows(0).Item(0))
                    detamov(ndoc, afec)
                    If tabla.Rows(i).Item("tipodoc") <> tabla_A.Rows(0).Item(0) And tabla.Rows(i).Item("fpago") = "Otra" Then
                        credito(ndoc)
                    End If

                    contable(ndoc, afec)
                    If tabla.Rows(i).Item("tipodoc") <> ajust Then
                        credito(ndoc)
                        sig = "+"
                    Else
                        sig = "-"
                    End If
                    GuardarAnticipos(tabla.Rows(i).Item("v1").ToString, tabla.Rows(i).Item("doc1").ToString, sig)
                    GuardarAnticipos(tabla.Rows(i).Item("v2").ToString, tabla.Rows(i).Item("doc2").ToString, sig)
                    GuardarAnticipos(tabla.Rows(i).Item("v3").ToString, tabla.Rows(i).Item("doc3").ToString, sig)

                    mibarra.Value = mibarra.Value + it
                Next
                mibarra.Visible = False
                Me.Cursor = Cursors.Default
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("COMPRAS", "APROBAR TODAS LAS FACTURAS DE COMPRAS PER: " & cbper.Text, "", "", "")
                End If
                '.....
                MsgBox("El proceso se realizo con exito", MsgBoxStyle.Information, "SAE")
            End If
        Else
            MsgBox(" No existen documentos a aprobar en el periodo " & p & " ")
        End If

    End Sub
    Public Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String, ByVal sig As String)
        'otros conceptos
        Dim sql As String = ""
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
    Private Sub aprobar(ByVal doc As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE fact_comp" & p & " SET estado = 'AP' WHERE doc = '" & doc & "'  "
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub con_inv(ByVal doc As String, ByVal afec As String, ByVal ajus As String)
        Dim art As String = ""
        Dim bod As String = ""
        Dim cant As String = ""

        Dim tabla_d As New DataTable
        myCommand.CommandText = " SELECT cod_art, num_bod, cantidad FROM detacomp" & p & " WHERE doc = '" & doc & "' and tipo_it = 'I' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_d)

        If afec = "SI" Then
            If tabla_d.Rows.Count > 0 Then
                For i = 0 To tabla_d.Rows.Count - 1
                    art = tabla_d.Rows(i).Item("cod_art")
                    bod = tabla_d.Rows(i).Item("num_bod")
                    If bod = 0 Then
                        bod = 1
                    End If
                    cant = tabla_d.Rows(i).Item("cantidad")

                    If Strings.Left(doc, 2) <> ajus Then
                        Try
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & " = cant" & bod & " + " & cant & " WHERE codart = '" & art & "' and  periodo ='" & p & "' "
                            myCommand.Connection = conexion
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Else
                        Try
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & " = cant" & bod & " - " & cant & " WHERE codart = '" & art & "' and  periodo ='" & p & "' "
                            myCommand.Connection = conexion
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub movimientos(ByVal doc As String, ByVal afec As String, ByVal ajus As String)

        Try
            If afec = "SI" Then
                Dim cad As String = ""
                Dim num As String = ""
                Dim per As String = ""
                Dim dia As String = ""
                Dim hora As String = ""
                Dim nit As String = ""
                Dim cc As String = ""
                Dim sum As String = ""
                Dim tdoc As String = ""

                Dim tabla As New DataTable
                myCommand.CommandText = " SELECT * FROM fact_comp" & p & " f  WHERE  f.doc = '" & doc & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                tdoc = Strings.Left(doc, 2)
                num = Strings.Right(doc, 5)
                per = p & Strings.Right(PerActual, 5)
                dia = Strings.Left(tabla.Rows(0).Item("fecha").ToString, 2)
                hora = tabla.Rows(0).Item("hora").ToString
                nit = tabla.Rows(0).Item("nitc")
                cc = tabla.Rows(0).Item("ctoc")

                Dim tabla_d As New DataTable
                myCommand.CommandText = " select sum(vtotal) as s from detacomp" & p & " where doc = '" & doc & "' and tipo_it = 'I'  ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla_d)
                sum = tabla_d.Rows(0).Item("s")

                If tdoc <> ajus Then
                    cad = "'E', 'ENTRADA', 'ENTRADA POR COMPRA'"
                Else
                    cad = "'S', 'SALIDA', 'SALIDA POR COMPRA'"
                End If

                myCommand.Parameters.Clear()
                myCommand.CommandText = " INSERT INTO `movimientos" & p & "` " _
                & "(`doc`, `tipodoc`, `num`, `per`, `dia`, `hora`, `nitc`, `tipo_mov`, `tipo`, `desc_mov`, `cc`, `concepto`, `o_compra`, `n_pedido`, `observ`, `total`, `estado`) " _
                & " VALUES ('" & doc & "', '" & tdoc & "', '" & num & "','" & per & "', '" & dia & "', '" & hora & "', '" & nit & "', " & cad & ", '" & cc & "', '', '', '', '', '" & sum & "', 'AP');"
                myCommand.Connection = conexion
                myCommand.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub detamov(ByVal doc As String, ByVal afec As String)

        Try
            If afec = "SI" Then
                Dim tabla_d As New DataTable
                myCommand.CommandText = " SELECT * FROM detacomp" & p & " WHERE doc = '" & doc & "' and tipo_it = 'I' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla_d)

                Dim cos As Double = 0
                If tabla_d.Rows.Count > 0 Then
                    For i = 0 To tabla_d.Rows.Count - 1

                        cos = DIN(tabla_d.Rows(i).Item("valor") / (1 + (tabla_d.Rows(i).Item("por_iva_g") / 100)))

                        myCommand.Parameters.Clear()
                        myCommand.CommandText = " INSERT INTO `deta_mov" & p & "` (`doc`, `item`, `codart`, `nomart`, `bod_ori`, `bod_des`, `cantidad`, `valor`, `cta_inv`, `cta_cos`, `cta_ing`, `cta_iva`, `costo`) " _
                        & " VALUES ('" & doc & "', '" & tabla_d.Rows(i).Item("item") & "', '" & tabla_d.Rows(i).Item("cod_art") & "', '" & tabla_d.Rows(i).Item("nom_art") & "','0','" & tabla_d.Rows(i).Item("num_bod") & "', '" & tabla_d.Rows(i).Item("cantidad") & "', '" & tabla_d.Rows(i).Item("valor") & "', '" & tabla_d.Rows(i).Item("cta_inv") & "', '" & tabla_d.Rows(i).Item("cta_cos") & "', '" & tabla_d.Rows(i).Item("cta_gas") & "', '" & tabla_d.Rows(i).Item("cta_iva") & "', '" & cos & "');"
                        myCommand.Connection = conexion
                        myCommand.ExecuteNonQuery()
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub credito(ByVal doc As String)
        Try
            Dim fech As String = ""
            Dim tabla_c As New DataTable
            myCommand.CommandText = " SELECT  IFNULL( TRIM( CONCAT( t.nombre,  '', t.apellidos ) ) ,  'NOMBRE' ) AS nombre, d.nom_art AS concepto, f. *  " _
            & " from detacomp" & p & " d, fact_comp" & p & " f LEFT join terceros t on t.nit= f.nitc " _
            & " where f.doc = '" & doc & "' and f.doc= d.doc and d.item = 1 "
            myAdapter.SelectCommand = myCommand
            myCommand.Connection = conexion
            myAdapter.Fill(tabla_c)

            ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR '''''''''''''''''''''''''''''''
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", doc)
            myCommand.Parameters.AddWithValue("?tipo", tabla_c.Rows(0).Item("tipodoc"))
            myCommand.Parameters.AddWithValue("?num", tabla_c.Rows(0).Item("num"))
            myCommand.Parameters.AddWithValue("?doc_ext", tabla_c.Rows(0).Item("doc_afec"))
            myCommand.Parameters.AddWithValue("?descrip", "")
            myCommand.Parameters.AddWithValue("?tipafec", "")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", tabla_c.Rows(0).Item("nitc"))
            myCommand.Parameters.AddWithValue("?nomnit", tabla_c.Rows(0).Item("nombre"))
            myCommand.Parameters.AddWithValue("?nitcod", "")
            fech = "" & Strings.Right(tabla_c.Rows(0).Item("fecha").ToString, 4) & Strings.Mid(tabla_c.Rows(0).Item("fecha").ToString, 4, 2) & Strings.Left(tabla_c.Rows(0).Item("fecha").ToString, 2) & ""
            myCommand.Parameters.AddWithValue("?fecha", fech)
            'dias de vmto
            myCommand.Parameters.AddWithValue("?vmto", tabla_c.Rows(0).Item("vmto"))
            myCommand.Parameters.AddWithValue("?concepto", tabla_c.Rows(0).Item("concepto"))
            'subtotal
            myCommand.Parameters.AddWithValue("?subtotal", tabla_c.Rows(0).Item("subtotal"))
            'descuento
            myCommand.Parameters.AddWithValue("?descto", tabla_c.Rows(0).Item("descuento"))
            'rete_fuente
            myCommand.Parameters.AddWithValue("?ret", "0")
            'iva
            myCommand.Parameters.AddWithValue("?iva", tabla_c.Rows(0).Item("por_iva"))
            myCommand.Parameters.AddWithValue("?v_iva", tabla_c.Rows(0).Item("iva"))
            'total
            myCommand.Parameters.AddWithValue("?total", tabla_c.Rows(0).Item("total"))
            'cuentas
            myCommand.Parameters.AddWithValue("?ctasubtotal", "")
            myCommand.Parameters.AddWithValue("?ctaret", "")
            myCommand.Parameters.AddWithValue("?ctaiva", tabla_c.Rows(0).Item("cta_iva"))
            myCommand.Parameters.AddWithValue("?ctatotal", tabla_c.Rows(0).Item("cta_total"))
            'ccosto
            myCommand.Parameters.AddWithValue("?ccosto", tabla_c.Rows(0).Item("ctoc"))
            myCommand.Parameters.AddWithValue("?otroimp", "N")
            'rete_iva
            myCommand.Parameters.AddWithValue("?retiva", "0")
            myCommand.Parameters.AddWithValue("?ctaretiva", "")
            'ret_ica
            myCommand.Parameters.AddWithValue("?retica", "0")
            myCommand.Parameters.AddWithValue("?ctaretica", "")
            'pagado
            myCommand.Parameters.AddWithValue("?pagado", "0")
            'pos
            myCommand.Parameters.AddWithValue("?rcpos", "")
            myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
            myCommand.Parameters.AddWithValue("?vpos", "0")
            'tasa
            myCommand.Parameters.AddWithValue("?tasa", "0")
            'moneda
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            'estado
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", "")
            'INSERTAR COBDPEN
            myCommand.CommandText = "INSERT INTO ctas_x_pagar VALUES (?doc,?tipo,?num,?doc_ext,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?fecha,?vmto," _
                                  & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                                  & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Dim tabla_df As New DataTable
    Dim tablac As New DataTable
    Dim tb As New DataTable

    Private Sub contable(ByVal doc As String, ByVal afec As String)

        tabla_df.Rows.Clear()
        tablac.Rows.Clear()
        tb.Rows.Clear()

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        Dim n As Integer = 1
        grilla.RowCount = 1
        grilla.Rows.Clear()
        grilla.RowCount = 30

        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then 'HAY INTERFAZ CONTABLE
            Dim tdoc As String = ""
            BuscarPeriodo()
            tdoc = "documentos" & PerActual(0) & PerActual(1)

            myCommand.CommandText = "SELECT sum(vtotal) as s from detacomp" & p & " where doc = '" & doc & "' and tipo_it = 'I';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()


            '************************************************
            myCommand.CommandText = " SELECT  IFNULL(trim(concat(t.nombre,'',t.apellidos)),'NOMBRE') as nombre, f.* " _
            & " FROM fact_comp" & p & " f LEFT join terceros t on t.nit = f.nitc where  f.doc ='" & doc & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablac)
            Refresh()

            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "total", tablac.Rows(0).Item("cta_total"), "VR. TOTAL " & tablac.Rows(0).Item("nombre"))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "desc", tablac.Rows(0).Item("cta_desc"), "DESCUENTO " & tablac.Rows(0).Item("por_desc") & "%  " & tablac.Rows(0).Item("nombre"))
            '
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "rtf", tablac.Rows(0).Item("cta_rtf"), "RETE FUENTE " & tablac.Rows(0).Item("por_rtf") & "% " & tablac.Rows(0).Item("nombre"))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "fle", tablac.Rows(0).Item("cta_fle"), "FLETE ")
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "seg", tablac.Rows(0).Item("cta_seg"), "SEGURO ")
            '
            If tablac.Rows(0).Item("o_con") <> "no" Then
                If tablac.Rows(0).Item("t1") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t1"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t1"), tablac.Rows(0).Item("cta1"), tablac.Rows(0).Item("d1"))
                End If
                If tablac.Rows(0).Item("t2") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t2"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t2"), tablac.Rows(0).Item("cta2"), tablac.Rows(0).Item("d2"))
                End If
                If tablac.Rows(0).Item("t3") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t3"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t3"), tablac.Rows(0).Item("cta3"), tablac.Rows(0).Item("d3"))
                End If
            End If
            '..... detafac
            myCommand.CommandText = " SELECT d.*, f.fle, f.seg, f.tipodoc, f.por_rtf, f.rtf, f.por_desc, f.descuento, f.total, f.iva FROM detacomp" & p & " d, fact_comp" & p & " f where   d.doc ='" & doc & "' and d.doc=f.doc "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_df)
            Refresh()

            For i = 0 To tabla_df.Rows.Count - 1
                If tabla_df.Rows(i).Item("tipo_it") = "I" Then
                    MovimientoContable(i, "inv", tabla_df.Rows(i).Item("cta_inv"), "INVENTARIO " & tabla_df.Rows(i).Item("nom_art"))
                    MovimientoContable(i, "iva", tabla_df.Rows(i).Item("cta_iva"), "IVA " & tabla_df.Rows(i).Item("por_iva_g") & "% " & tablac.Rows(0).Item("nombre"))
                Else
                    MovimientoContable(i, "ing", tabla_df.Rows(i).Item("cta_cos"), tabla_df.Rows(i).Item("nom_art"))
                    MovimientoContable(i, "iva", tabla_df.Rows(i).Item("cta_iva"), "IVA " & tabla_df.Rows(i).Item("por_iva_g") & "% " & tablac.Rows(0).Item("nombre"))
                End If

                '    If afec = "SI" Then
                '        MovimientoContable(i, "cventa", tabla_df.Rows(i).Item("cta_cos"), tablac.Rows(0).Item("nombre") & " A VENTAS ")
                '        MovimientoContable(i, "inv", tabla_df.Rows(i).Item("cta_inv"), tablac.Rows(0).Item("nombre") & " A 1435 ")
                '    End If
                '    MovimientoContable(i, "ing", tabla_df.Rows(i).Item("cta_ing"), tablac.Rows(0).Item("nombre"))
                '    MovimientoContable(i, "iva", tabla_df.Rows(i).Item("cta_iva"), "IVA " & tabla_df.Rows(i).Item("iva_d") & "% " & tablac.Rows(0).Item("nombre"))
            Next
            '    '********************************************************************

            Dim cad As String
            Dim db, cr As Double
            grilla.Sort(grilla.Columns("Debitos"), System.ComponentModel.ListSortDirection.Descending)
            For i = 0 To grilla.RowCount - 1
                Try
                    Try
                        cad = grilla.Item("cuenta", i).Value.ToString
                    Catch ex As Exception
                        cad = ""
                    End Try
                    Try
                        db = grilla.Item("Debitos", i).Value
                    Catch ex As Exception
                        db = 0
                    End Try
                    Try
                        cr = grilla.Item("Creditos", i).Value
                    Catch ex As Exception
                        cr = 0
                    End Try
                    If cad <> "" And (db > 0 Or cr > 0) Then
                        '  InsertContabilidad(i, tdoc, doc, n)
                        n = n + 1
                    End If
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                End Try
            Next
        End If

    End Sub

    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String, ByVal doc As String, ByVal n As Integer)
        Dim num As String = ""
        Dim tdoc As String = ""
        Dim dia As String = ""

        Dim tabla_fA As New DataTable
        myCommand.CommandText = " SELECT tipoaj FROM `parafacgral` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_fA)
        Refresh()

        Dim tabla_f As New DataTable
        myCommand.CommandText = " SELECT * FROM fact_comp" & p & " where doc ='" & doc & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_f)
        Refresh()

        num = Strings.Right(doc, 5)
        tdoc = Strings.Left(doc, 2)
        dia = Strings.Left(tabla_f.Rows(0).Item("fecha").ToString, 2)

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", n)
            myCommand.Parameters.AddWithValue("?doc", num)
            myCommand.Parameters.AddWithValue("?tipodoc", tdoc)
            myCommand.Parameters.AddWithValue("?periodo", p & "/" & Strings.Right(PerActual, 4))
            myCommand.Parameters.AddWithValue("?dia", dia)
            myCommand.Parameters.AddWithValue("?centro", tabla_f.Rows(0).Item("cc"))
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            ''.... FC
            'If tdoc <> tabla_fA.Rows(0).Item(0) Then

            '    Try
            '        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            '    Catch ex As Exception
            '        myCommand.Parameters.AddWithValue("?debito", "0")
            '    End Try
            '    Try
            '        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            '    Catch ex As Exception
            '        myCommand.Parameters.AddWithValue("?credito", "0")
            '    End Try

            'Else '.... AF

            '    Try
            '        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Creditos", fila).Value))
            '    Catch ex As Exception
            '        myCommand.Parameters.AddWithValue("?debito", "0")
            '    End Try
            '    Try
            '        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Debitos", fila).Value))
            '    Catch ex As Exception
            '        myCommand.Parameters.AddWithValue("?credito", "0")
            '    End Try

            'End If
            '..........

            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item("base", fila).Value))
            myCommand.Parameters.AddWithValue("?diasv", tabla_f.Rows(0).Item("vmto"))

            If Val(tabla_f.Rows(0).Item("vmto")) > 0 Then
                Dim fec As Date = DateAdd("d", Val(tabla_f.Rows(0).Item("vmto")), tabla_f.Rows(0).Item("fecha").ToString)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            myCommand.Parameters.AddWithValue("?nit", tabla_f.Rows(0).Item("nitc"))
            myCommand.Parameters.AddWithValue("?modulo", "facturacion")
            'INSERTAR CONTABLE

            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?modulo);"
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
            '   ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String)


        Dim tabla_A As New DataTable
        myCommand.CommandText = " SELECT doc_aj FROM `par_comp` "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_A)
        Refresh()

        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des As String
        Dim desc, b2, rtf As Double
        sw = 0

        For j = 0 To grilla.RowCount - 1
            k = j
            Try
                cad = grilla.Item("cuenta", j).Value.ToString
            Catch ex As Exception
                cad = ""
            End Try
            Try
                des = grilla.Item("Descripcion", j).Value.ToString
            Catch ex As Exception
                des = ""
            End Try
            '***************************
            If cad = "" And des = "" Then
                grilla.Item("cuenta", j).Value = cuenta
                grilla.Item("Descripcion", j).Value = descrip
                sw = 1
                Exit For
            ElseIf cad = cuenta Then
                If des = descrip Then
                    sw = 1
                    Exit For
                End If
            End If
        Next j
        j = k
        If sw = 0 Then
            grilla.RowCount = grilla.RowCount + 1
            grilla.Item("cuenta", k).Value = cuenta
            grilla.Item("Descripcion", k).Value = descrip
            grilla.Item("base", k).Value = "0"
            grilla.RowCount = grilla.RowCount + 1
        End If

        Dim db, cr, base, monto, iva As Double
        Try
            db = grilla.Item("Debitos", j).Value
        Catch ex As Exception
            db = 0
        End Try
        Try
            cr = grilla.Item("Creditos", j).Value
        Catch ex As Exception
            cr = 0
        End Try
        Try
            base = grilla.Item("base", j).Value
        Catch ex As Exception
            base = 0
        End Try

        Select Case tipo
            Case "ing"
                Try
                    base = CDbl(tabla_df.Rows(fo).Item("vtotal") / (1 + (CDbl(tabla_df.Rows(fo).Item("iva_d") / 100))))
                Catch ex As Exception
                End Try
                Try
                    desc = base * (CDbl(tabla_df.Rows(fo).Item("por_des")) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                monto = base - desc
                Try
                    rtf = monto * CDec(tabla_df.Rows(fo).Item("por_rtf")) / 100
                    rtf = Format(Math.Round(CDbl(rtf), 2), "0.00")
                Catch ex As Exception
                    rtf = 0
                End Try

                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                '    '...........
            Case "iva"
                Try 'base sin descuento
                    b2 = CDbl(tabla_df.Rows(fo).Item("vtotal") / (1 + (CDbl(tabla_df.Rows(fo).Item("por_iva_g") / 100))))
                Catch ex As Exception
                End Try
                Try
                    desc = b2 * (CDbl(tabla_df.Rows(fo).Item("por_des")) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    desc = b2 * (CDbl(tabla_df.Rows(fo).Item("por_desc")) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    base = base + b2  'base acomulada + nueva base
                Catch ex As Exception
                End Try
                Try
                    iva = b2 * (CDec(tabla_df.Rows(fo).Item("por_iva_g")) / 100)
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = iva
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base

            Case "inv"
                Try
                    iva = CDbl(tabla_df.Rows(fo).Item("vtotal")) - (CDbl(tabla_df.Rows(fo).Item("vtotal") / (1 + (CDbl(tabla_df.Rows(fo).Item("por_iva_g") / 100)))))
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = CDbl(tabla_df.Rows(fo).Item("vtotal")) - iva
                monto = monto - ((monto * tabla_df.Rows(fo).Item("por_des")) / 100)
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "cventa"
                iva = CDbl(tabla_df.Rows(fo).Item("valor")) - (CDbl(tabla_df.Rows(fo).Item("valor") / (1 + (CDbl(tabla_df.Rows(fo).Item("por_iva_g") / 100)))))
                monto = CDbl(tabla_df.Rows(fo).Item("valor")) - iva
                Try
                    monto = monto * CDbl(tabla_df.Rows(fo).Item("cantidad"))
                Catch ex As Exception
                    monto = 0
                End Try
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "desc"
                monto = CDbl(tablac.Rows(fo).Item("descuento"))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "rtf"
                monto = Format(Math.Round(CDbl(tablac.Rows(fo).Item("rtf")), 2), "0.00")
                Try
                    base = base + (CDbl(tb.Rows(0).Item("s")) - CDbl(tablac.Rows(fo).Item("iva"))) - (CDbl(tb.Rows(0).Item("s")) * CDbl(tablac.Rows(fo).Item("por_desc")) / 100)
                Catch ex As Exception
                End Try
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                grilla.Item("base", j).Value = base
            Case "total"
                monto = CDbl(tablac.Rows(fo).Item("total"))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If

            Case "fle"
                monto = CDbl(tablac.Rows(fo).Item("fle"))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If

            Case "seg"
                monto = CDbl(tablac.Rows(fo).Item("seg"))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If

            Case "+"
                monto = CDbl(tablac.Rows(fo).Item("v" & concep))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                Try
                    grilla.Item("base", j).Value = CDbl(grilla.Item("base", j).Value) + CDbl(tablac.Rows(fo).Item("b" & concep))
                Catch ex As Exception
                End Try
            Case "-"
                monto = CDbl(tablac.Rows(fo).Item("v" & concep))
                If tablac.Rows(0).Item("tipodoc") <> tabla_A.Rows(0).Item("doc_aj") Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                Try
                    grilla.Item("base", j).Value = CDbl(grilla.Item("base", j).Value) + CDbl(tablac.Rows(fo).Item("b" & concep))
                Catch ex As Exception
                End Try
        End Select
    End Sub
End Class