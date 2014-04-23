Imports MySql.Data.MySqlClient
Public Class FrmAprFac
    Dim p As String
    Dim ajust As String
    Dim conexion As New MySqlConnection
    Dim cadena As String
    Dim concep As Integer = 0

    Private Sub FrmAprFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        txtaño.Text = PerActual(2) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)

        Try
            Dim tb As New DataTable
            myCommand.CommandText = " select tipoaj from `parafacgral`;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            ajust = tb.Rows(0).Item(0)
        Catch ex As Exception
        End Try
       
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
        myCommand.CommandText = " SELECT f.doc, f.tipodoc, f.estado, f.afecta,v1,v2,v3,doc1,doc2,doc3 FROM facturas" & p & " f WHERE f.estado <> 'AP' ;"
        '  myCommand.CommandText = " SELECT f.doc, f.tipodoc, f.estado, f.afecta FROM facturas" & p & " f  WHERE f.estado <> 'AP'  and f.doc in ('FC01283')  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

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

                    If con_inv(ndoc, afec) <> "no" Then
                        aprobar(ndoc)
                        movimientos(ndoc, afec)
                        detamov(ndoc, afec)
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
                    End If
                    mibarra.Value = mibarra.Value + it
                Next
                mibarra.Visible = False
                Me.Cursor = Cursors.Default
                MsgBox("El proceso se realizo con exito")
                conexion.Close()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "APROBAR TODAS LAS FACTURAS - PERIODO " & cbper.Text, "ESTADO", "", "AP")
                End If
                '.....
            End If
        Else
            MsgBox(" No existen documentos pendientes por aprobar en el periodo " & p & " ")
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
            myCommand.CommandText = "UPDATE facturas" & p & " SET estado = 'AP' WHERE doc = '" & doc & "'  "
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function ValidarCantidades(ByVal bodega As String, ByVal art As String, ByVal cant As Integer)
        Dim tbc As New DataTable
        tbc.Clear()
        myCommand.CommandText = "SELECT cant" & bodega & " FROM con_inv WHERE codart='" & art & "' and  periodo='" & p & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbc)
        Refresh()
        If (CInt(tbc.Rows(0).Item(0)) - DIN(cant)) < 0 Then
            ' MsgBox("La cantidad disponible del articulo " & gfactura.Item(1, fila).Value & ", es " & tbc.Rows(0).Item(0) & " , Verifique", MsgBoxStyle.Information, "Verifique")
            Return (False)
            Exit Function
        End If
        Return (True)
    End Function
    Function con_inv(ByVal doc As String, ByVal afec As String)
        Dim art As String = ""
        Dim bod As String = ""
        Dim cant As String = ""
        Dim par As String = ""

        Dim tabla_d As New DataTable
        myCommand.CommandText = " SELECT codart, numbod, cantidad FROM detafac" & p & " WHERE doc ='" & doc & "'  and tipo_it = 'I' ;"

        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_d)

        If afec = "SI" Then

            Dim tc As New DataTable
            tc.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            If tc.Rows.Count > 0 Then
                If tc.Rows(0).Item(0) = "SI" Then
                    par = "SI"
                End If
            End If

            '... VERIFICAR CANTIDAES
            If tabla_d.Rows.Count > 0 Then
                If Strings.Left(doc, 2) <> ajust Then
                    For j = 0 To tabla_d.Rows.Count - 1
                        art = tabla_d.Rows(j).Item("codart")
                        bod = tabla_d.Rows(j).Item("numbod")
                        cant = tabla_d.Rows(j).Item("cantidad")
                        If par = "SI" Then
                            If ValidarCantidades(bod, art, cant) = False Then
                                Return ("no")
                                Exit Function
                            End If
                        End If
                    Next
                End If
            End If
            '...


            '////////////////////////////////////////////
            If tabla_d.Rows.Count > 0 Then
                For i = 0 To tabla_d.Rows.Count - 1
                    art = tabla_d.Rows(i).Item("codart")
                    bod = tabla_d.Rows(i).Item("numbod")
                    If bod = 0 Then
                        bod = 1
                    End If
                    cant = tabla_d.Rows(i).Item("cantidad")

                    Try
                        myCommand.Parameters.Clear()
                        If Strings.Left(doc, 2) <> ajust Then
                            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & " = cant" & bod & " - " & cant & " WHERE codart = '" & art & "' and  periodo >='" & p & "' "
                        Else
                            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & " = cant" & bod & " + " & cant & " WHERE codart = '" & art & "' and  periodo >='" & p & "' "
                        End If
                        myCommand.Connection = conexion
                        myCommand.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Next
            End If
        End If
        Return ("si")
    End Function

    Private Sub movimientos(ByVal doc As String, ByVal afec As String)

        Try
            If afec = "SI" Then
                Dim num As String = ""
                Dim per As String = ""
                Dim dia As String = ""
                Dim hora As String = ""
                Dim nit As String = ""
                Dim cc As String = ""
                Dim sum As String = ""
                Dim tdoc As String = ""

                tdoc = Strings.Left(doc, 2)

                Dim tabla As New DataTable
                myCommand.CommandText = " SELECT * FROM facturas" & p & " f  WHERE  f.doc = '" & doc & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)

                num = Strings.Right(doc, 5)
                per = p & Strings.Right(PerActual, 5)
                dia = Strings.Left(tabla.Rows(0).Item("fecha").ToString, 2)
                hora = tabla.Rows(0).Item("hora").ToString
                nit = tabla.Rows(0).Item("nitc")
                cc = tabla.Rows(0).Item("cc")

                Dim tabla_d As New DataTable
                myCommand.CommandText = " select sum(vtotal) as s from detafac" & p & " where doc = '" & doc & "' and tipo_it = 'I'  ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla_d)
                sum = tabla_d.Rows(0).Item("s")

                myCommand.Parameters.Clear()
                myCommand.CommandText = " INSERT INTO `movimientos" & p & "` " _
                & "(`doc`, `tipodoc`, `num`, `per`, `dia`, `hora`, `nitc`, `tipo_mov`, `tipo`, `desc_mov`, `cc`, `concepto`, `o_compra`, `n_pedido`, `observ`, `total`, `estado`) " _
                & " VALUES ('" & doc & "', '" & tdoc & "', '" & num & "','" & per & "', '" & dia & "', '" & hora & "', '" & nit & "', 'S', 'SALIDA', 'SALIDA POR FACTURA', '" & cc & "', '', '', '', '', '" & sum & "', 'AP');"
                myCommand.Connection = conexion
                myCommand.ExecuteNonQuery()
            End If

        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub detamov(ByVal doc As String, ByVal afec As String)

        Try
            If afec = "SI" Then
                Dim tabla_d As New DataTable
                myCommand.CommandText = " SELECT * FROM detafac" & p & " WHERE doc = '" & doc & "' and tipo_it = 'I' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla_d)

                If tabla_d.Rows.Count > 0 Then
                    For i = 0 To tabla_d.Rows.Count - 1
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = " INSERT INTO `deta_mov" & p & "` (`doc`, `item`, `codart`, `nomart`, `bod_ori`, `bod_des`, `cantidad`, `valor`, `cta_inv`, `cta_cos`, `cta_ing`, `cta_iva`, `costo`) " _
                        & " VALUES ('" & doc & "', '" & tabla_d.Rows(i).Item("item") & "', '" & tabla_d.Rows(i).Item("codart") & "', '" & tabla_d.Rows(i).Item("nomart") & "', '" & tabla_d.Rows(i).Item("numbod") & "', '0', '" & tabla_d.Rows(i).Item("cantidad") & "', '" & DIN(tabla_d.Rows(i).Item("valor")) & "', '" & tabla_d.Rows(i).Item("cta_inv") & "', '" & tabla_d.Rows(i).Item("cta_cos") & "', '" & tabla_d.Rows(i).Item("cta_ing") & "', '" & tabla_d.Rows(i).Item("cta_iva") & "', '" & DIN(tabla_d.Rows(i).Item("costo")) & "');"
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

        Dim num As String = ""
        Dim cad As String = ""
        Dim fech As String = ""
        Dim tdoc As String = ""

        tdoc = Strings.Left(doc, 2)

        Dim tabla_c As New DataTable
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT tipo FROM facpagos" & p & " WHERE doc = '" & doc & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count > 0 Then
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item("tipo") = "Otra" Then

                    myCommand.CommandText = " SELECT f.nitc, IFNULL(trim(concat(t.nombre,'',t.apellidos)),'NOMBRE') as nombre, f.nitv, f.fecha, f.vmto, d.nomart as concepto, f.subtotal, " _
                    & " f.descuento, f.ret_f, f.por_iva, f.iva, f.total, f.cta_total as ctasubtotal, f.cta_ret_f, f.cta_iva, f.cta_total, f.cc, " _
                    & "  f.ret_iva, f.cta_ret_iva, f.ret_ica, f.cta_ret_ica " _
                     & " from detafac" & p & " d, facturas" & p & " f LEFT join terceros t on t.nit= f.nitc " _
                    & " where f.doc = '" & doc & "' and f.doc= d.doc and d.item = 1 "
                    myAdapter.SelectCommand = myCommand
                    myCommand.Connection = conexion
                    myAdapter.Fill(tabla_c)

                    fech = "" & Strings.Right(tabla_c.Rows(0).Item("fecha").ToString, 4) & Strings.Mid(tabla_c.Rows(0).Item("fecha").ToString, 4, 2) & Strings.Left(tabla_c.Rows(0).Item("fecha").ToString, 2) & ""
                    num = Strings.Right(doc, 5)

                    cad = " '" & doc & "' ,'" & tdoc & "' ,'" & num & "','' ,'' ,'','" & tabla_c.Rows(0).Item("nitc") & "','" & tabla_c.Rows(0).Item("nombre") & "','',  " _
                         & " '" & tabla_c.Rows(0).Item("nitv") & "', '" & fech & "', '" & tabla_c.Rows(0).Item("vmto") & "', '" & tabla_c.Rows(0).Item("concepto") & "', '" & tabla_c.Rows(0).Item("subtotal") & "',  " _
                         & " '" & tabla_c.Rows(0).Item("descuento") & "', '" & tabla_c.Rows(0).Item("ret_f") & "', '" & tabla_c.Rows(0).Item("por_iva") & "', '" & tabla_c.Rows(0).Item("iva") & "', '" & tabla_c.Rows(0).Item("total") & "', " _
                         & " '" & tabla_c.Rows(0).Item("ctasubtotal") & "', '" & tabla_c.Rows(0).Item("cta_ret_f") & "', '" & tabla_c.Rows(0).Item("cta_iva") & "', '" & tabla_c.Rows(0).Item("cta_total") & "', '" & tabla_c.Rows(0).Item("cc") & "', " _
                         & " 'N', '" & tabla_c.Rows(0).Item("ret_iva") & "', '" & tabla_c.Rows(0).Item("cta_ret_iva") & "', '" & tabla_c.Rows(0).Item("ret_ica") & "', '" & tabla_c.Rows(0).Item("cta_ret_ica") & "', '0', " _
                         & " '', '0000-00-00', '0', '0', 'L', 'L', 'AP', '', '' "
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "  INSERT INTO `cobdpen` (`doc`, `tipo`, `num`, `descrip`, `tipafec`, `clasaju`, `nitc`, `nomnit`, `nitcod`, `nitv`, `fecha`, `vmto`, `concepto`, `subtotal`, `descto`, `ret`, `iva`, `v_viva`, `total`, `ctasubtotal`, `ctaret`, `ctaiva`, `ctatotal`, `ccosto`, `otroimp`, `retiva`, `ctaretiva`, `retica`, `ctaretica`, `pagado`, `rcpos`, `fechpos`, `vpos`, `tasa`, `moneda`, `monloex`, `estado`, `salmov`, `pagare`) " _
                        & " VALUES ( " & cad & " );"
                        myCommand.Connection = conexion
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

    End Sub

    Dim tabla_df As New DataTable
    Dim tablac As New DataTable
    Dim tablapg As New DataTable

    Private Sub contable(ByVal doc As String, ByVal afec As String)

        tabla_df.Rows.Clear()
        tablac.Rows.Clear()
        tablapg.Rows.Clear()

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
            '************************************************
            myCommand.CommandText = " SELECT  IFNULL(trim(concat(t.nombre,'',t.apellidos)),'NOMBRE') as nombre, f.cta_desc,cta_total, f.descuento,f.total, " _
            & " f.subtotal, f.iva, f.por_desc, f.o_con, f.t1, f.d1, f.v1, f.cta1, f.t2, f.d2, f.v2, f.cta2, f.t3, f.d3, f.v3, f.cta3, " _
            & " f.por_ret_f, f.por_ret_iva, f.por_ret_ica, f.ret_f, f.ret_iva, f.ret_ica  " _
            & " FROM facturas" & p & " f LEFT join terceros t on t.nit = f.nitc where  f.doc ='" & doc & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablac)
            Refresh()

            myCommand.CommandText = " SELECT tipo, numero FROM facpagos" & p & " f where  doc ='" & doc & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablapg)
            Refresh()

            For j = 0 To tablapg.Rows.Count - 1
                grilla.RowCount = grilla.RowCount + 1
                MovimientoContable(j, "total", tablac.Rows(0).Item("cta_total"), "VR. TOTAL " & tablapg.Rows(j).Item(0) & " " & tablac.Rows(0).Item("nombre"), doc)
            Next
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "desc", tablac.Rows(0).Item("cta_desc"), "DESCUENTO " & tablac.Rows(0).Item("por_desc") & "%  " & tablac.Rows(0).Item("nombre"), doc)
            '
            MovimientoContable(0, "rtf", tablac.Rows(0).Item("ret_f"), "RETE FUENTE " & tablac.Rows(0).Item("por_ret_f") & "% " & tablac.Rows(0).Item("nombre"), doc)
            MovimientoContable(0, "rtica", tablac.Rows(0).Item("ret_ica"), "RETE ICA " & tablac.Rows(0).Item("por_ret_ica") & "% " & tablac.Rows(0).Item("nombre"), doc)
            MovimientoContable(0, "rtiva", tablac.Rows(0).Item("ret_iva"), "RETE IVA " & tablac.Rows(0).Item("por_ret_iva") & "% " & tablac.Rows(0).Item("nombre"), doc)
            '
            If tablac.Rows(0).Item("o_con") <> "no" Then
                If tablac.Rows(0).Item("t1") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t1"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t1"), tablac.Rows(0).Item("cta1"), tablac.Rows(0).Item("d1"), doc)
                End If
                If tablac.Rows(0).Item("t2") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t2"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t2"), tablac.Rows(0).Item("cta2"), tablac.Rows(0).Item("d2"), doc)
                End If
                If tablac.Rows(0).Item("t3") <> "" Then
                    grilla.RowCount = grilla.RowCount + 1
                    concep = Strings.Right(tablac.Rows(0).Item("t3"), 1)
                    MovimientoContable(0, tablac.Rows(0).Item("t3"), tablac.Rows(0).Item("cta3"), tablac.Rows(0).Item("d3"), doc)
                End If
            End If
            '..... detafac
            myCommand.CommandText = " SELECT d.*, f.por_desc, f.descuento, f.total, d.tipo_it FROM detafac" & p & " d, facturas" & p & " f where d.doc ='" & doc & "' and d.doc=f.doc "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_df)
            Refresh()

            For i = 0 To tabla_df.Rows.Count - 1
                If afec = "SI" And tabla_df.Rows(i).Item("tipo_it") = "I" Then
                    MovimientoContable(i, "cventa", tabla_df.Rows(i).Item("cta_cos"), tablac.Rows(0).Item("nombre") & " A VENTAS ", doc)
                    MovimientoContable(i, "inv", tabla_df.Rows(i).Item("cta_inv"), tablac.Rows(0).Item("nombre") & " A 1435 ", doc)
                End If
                MovimientoContable(i, "ing", tabla_df.Rows(i).Item("cta_ing"), tablac.Rows(0).Item("nombre"), doc)
                MovimientoContable(i, "iva", tabla_df.Rows(i).Item("cta_iva"), "IVA " & tabla_df.Rows(i).Item("iva_d") & "% " & tablac.Rows(0).Item("nombre"), doc)
            Next
            '    '********************************************************************

            Dim cad As String
            Dim db, cr As Double
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
                        InsertContabilidad(i, tdoc, doc, n)
                        n = n + 1
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
        End If

    End Sub

    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String, ByVal doc As String, ByVal n As Integer)
        Dim num As String = ""
        Dim tdoc As String = ""
        Dim dia As String = ""

        Dim tabla_f As New DataTable
        myCommand.CommandText = " SELECT * FROM `facturas" & p & "` where doc ='" & doc & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_f)
        Refresh()

        num = Strings.Right(doc, Strings.Len(doc) - 2)
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
            '.... FC
            If tdoc <> ajust Then

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

            Else '.... AF
                Try
                    myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Creditos", fila).Value))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?debito", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Debitos", fila).Value))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?credito", "0")
                End Try
            End If
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
            Try
                myCommand.Parameters.AddWithValue("?cheque", grilla.Item("cheque", fila).Value.ToString)
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?cheque", "")
            End Try
            myCommand.Parameters.AddWithValue("?modulo", "facturacion")
            'INSERTAR CONTABLE

            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
            '   ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String, ByVal doc As String)

        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des As String
        Dim desc, b2 As Double
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
        monto = 0

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
        Dim rtf, rtica, rtiva As Double
        rtf = 0
        rtica = 0
        rtiva = 0

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
                    rtf = monto * CDec(tablac.Rows(fo).Item("por_ret_f")) / 100
                    rtf = Format(Math.Round(CDbl(rtf), 2), "0.00")
                Catch ex As Exception
                    rtf = 0
                End Try
                Try
                    rtica = monto * CDec(tablac.Rows(fo).Item("por_ret_ica")) / 100
                    rtica = Format(Math.Round(CDbl(rtica), 2), "0.00")
                Catch ex As Exception
                    rtica = 0
                End Try
                Try
                    rtiva = monto * CDec(tablac.Rows(fo).Item("por_ret_iva")) / 100
                    rtiva = Format(Math.Round(CDbl(rtiva), 2), "0.00")
                Catch ex As Exception
                    rtiva = 0
                End Try
                monto = monto
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                '    '...........
            Case "iva"
                Try 'base sin descuento
                    b2 = CDbl(tabla_df.Rows(fo).Item("vtotal") / (1 + (tabla_df.Rows(fo).Item("iva_d") / 100)))
                    ' b2 = CDbl(tabla_df.Rows(fo).Item("vtotal") / (1 + (CDbl(tabla_df.Rows(fo).Item("iva_d") / 100))))
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
                    iva = b2 * (CDbl(tabla_df.Rows(fo).Item("iva_d")) / 100)
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = iva
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                grilla.Item("base", j).Value = base
            Case "rtf"
                monto = Format(Math.Round(CDbl(tablac.Rows(fo).Item("ret_f")), 2), "0.00")
                Try
                    base = base + (CDbl(tablac.Rows(fo).Item("subtotal")) - CDbl(tablac.Rows(fo).Item("iva"))) - (CDbl(tablac.Rows(fo).Item("subtotal")) * CDbl(tablac.Rows(fo).Item("por_desc")) / 100)
                Catch ex As Exception
                End Try
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "rtica"
                Try
                    base = base + (CDbl(tablac.Rows(fo).Item("subtotal")) - CDbl(tablac.Rows(fo).Item("iva"))) - (CDbl(tablac.Rows(fo).Item("subtotal")) * CDbl(tablac.Rows(fo).Item("por_desc")) / 100)
                Catch ex As Exception
                End Try
                monto = Format(Math.Round(CDbl(tablac.Rows(fo).Item("ret_ica")), 2), "0.00")
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "rtiva"
                Try
                    base = base + (CDbl(tablac.Rows(fo).Item("subtotal")) - CDbl(tablac.Rows(fo).Item("iva"))) - (CDbl(tablac.Rows(fo).Item("subtotal")) * CDbl(tablac.Rows(fo).Item("por_desc")) / 100)
                Catch ex As Exception
                End Try
                monto = Format(Math.Round(CDbl(tablac.Rows(fo).Item("ret_iva")), 2), "0.00")
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "inv"
                Try
                    monto = CDbl(tabla_df.Rows(fo).Item("costo")) * CDbl(tabla_df.Rows(fo).Item("cantidad"))
                Catch ex As Exception
                    monto = 0
                End Try
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "cventa"
                Try
                    monto = CDbl(tabla_df.Rows(fo).Item("costo")) * CDbl(tabla_df.Rows(fo).Item("cantidad"))
                Catch ex As Exception
                    monto = 0
                End Try
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "desc"
                monto = CDbl(tablac.Rows(fo).Item("descuento"))
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "total"
                monto = CDbl(tablac.Rows(fo).Item("total"))
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                If tablapg.Rows(fo).Item(0) = "Cheque" Then
                    grilla.Item("cheque", j).Value = tablapg.Rows(fo).Item(1)
                Else
                    grilla.Item("cheque", j).Value = ""
                End If
            Case "+"
                monto = CDbl(tablac.Rows(fo).Item("v" & concep))
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "-"
                monto = CDbl(tablac.Rows(fo).Item("v" & concep))
                If Strings.Left(doc, 2) <> ajust Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
        End Select
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class