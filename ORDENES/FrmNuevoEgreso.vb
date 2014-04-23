Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports MySql.Data.MySqlClient

Public Class FrmNuevoEgreso
    Dim a As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If Val(txtce.Text) = 0 Or Trim(txtce.Text) = "" Then
            MsgBox("Verifique el numero del comprobante. ", MsgBoxStyle.Information, "SAE Control")
            txtce.Focus()
            Exit Sub
        End If
        If Trim(txtvig.Text) = "" Then
            MsgBox("Favor verifique la vigencia del contrato.  ", MsgBoxStyle.Information, "SAE Control")
            txtvig.Focus()
            Exit Sub
        End If
        If ExisteAno() = 0 Then
            MsgBox("El documento no puede ser creado porque el año contable " & fechace.Value.Year & " no existe.  ", MsgBoxStyle.Information, "SAE Control")
            fechace.Focus()
            Exit Sub
        End If
        If Trim(txtbanco.Text) = "" Then
            MsgBox("Favor seleecione una cuenta Bancaria.  ", MsgBoxStyle.Information, "SAE Control")
            txtcta.Focus()
            Exit Sub
        End If
        If Trim(txtcheque.Text) = "" Then
            MsgBox("Favor digite un numero de cheque.  ", MsgBoxStyle.Information, "SAE Control")
            txtcheque.Focus()
            Exit Sub
        End If
        If ExisteDoc() > 0 Then
            MsgBox("El documento " & lbtipodoc.Text & txtce.Text & "  ya existe en el periodo " & lbperiodo.Text & ", Verifique,  ", MsgBoxStyle.Information, "SAE Control")
            txtce.Focus()
            Exit Sub
        End If
        MiConexion(bda)

        'Try
        CuadrarPagos()
        For i = 0 To grilla.RowCount - 1
            Try
                If grilla.Item("Cuenta", i).Value.ToString <> "" Then
                    GuardarEgreso(i)
                End If
            Catch ex As Exception
                'MsgBox()
            End Try
        Next
        ActualizarCon()
        ActualizarOrd()
        CxPagar()
        Ingres_Presup()
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdprint.Enabled = True
        gce.Enabled = False
        MsgBox("Datos Guardados Correctamente.", MsgBoxStyle.Information, "SAE Guardar Datos")
        'Catch ex As Exception
        'End Try
        Cerrar()
    End Sub
    Public Sub CuadrarPagos()
        grilla.Rows.RemoveAt(0)
        Dim f As Integer = 0
        gcuenta.Item("cta_con", 0).Value = txtcta.Text
        gcuenta.Item("banco", 0).Value = txtbanco.Text
        gcuenta.Item("cheque2", 0).Value = txtcheque.Text
        If gcuenta.RowCount = 2 Then
            gcuenta.Item("monto", 0).Value = txttotal.Text
        End If
        For i = 0 To gcuenta.RowCount - 1
            grilla.RowCount = grilla.RowCount + 1
            f = grilla.RowCount - 1
            grilla.Item("Cuenta", f).Value = gcuenta.Item("cta_con", i).Value
            grilla.Item("Descripcion", f).Value = gcuenta.Item("banco", i).Value
            grilla.Item("Debitos", f).Value = "0"
            grilla.Item("Creditos", f).Value = gcuenta.Item("monto", i).Value
            grilla.Item("base", f).Value = "0"
            grilla.Item("doc_afe", f).Value = ""
            grilla.Item("abonado", f).Value = ""
            grilla.Item("nit", f).Value = txtnit.Text
            grilla.Item("cheque", f).Value = gcuenta.Item("cheque2", i).Value
            grilla.Item("sucursal", f).Value = "--"
        Next
    End Sub
    Private Sub CxPagar()
        '*** GUARDAR MONTO ABONADO *********************************************
        'Try
        If CDbl(VBruto) > 0 Then
            myCommand.Parameters.AddWithValue("?abonado", DIN(VBruto))
            myCommand.CommandText = "UPDATE ctas_x_pagar SET pagado=pagado+?abonado WHERE doc='" & FrmOrdenPagos.Doccxp & "';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        End If
        'Catch ex As Exception
        'End Try
    End Sub
    Function ExisteAno()
        Dim bandera As Integer = 0
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "show DATABASES;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            bandera = 0
            Dim b As String = "sae" & FrmPrincipal.lbcompania.Text.ToString.ToLower & fechace.Value.Year
            ' MsgBox(b)
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item(0) = b Then
                    bandera = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try
        Return bandera
    End Function
    Public Sub ActualizarOrd()
        Try
            '********* ACTUALIZAR ORDEN ***********************
            myCommand.Parameters.Clear()
            myCommand.CommandText = "Update ord_pagos set estado='AP',sop_cont = '" & lbperiodo.Text & "-" & lbtipodoc.Text & txtce.Text & "' WHERE doc='" & txtorden.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarCon()
        Try
            Dim m As String = fechace.Value.Month
            If Val(m) < 10 Then m = "0" & Val(m)
            Dim b As String = "sae" & FrmPrincipal.lbcompania.Text & fechace.Value.Year
            Dim cs As String = ""
            Dim t2 As New DataTable
            myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & lbtipodoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t2)
            If t2.Rows(0).Item("grupo") <> "FC" Then
                cs = "Update  " & b & ".tipdoc set actual" & m & "=?actual WHERE tipodoc=?tipodoc AND actual" & m & "<?actual;"
            Else
                cs = "Update  " & b & ".tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            End If

            '********* ACTUALIZAR CONSECUTIVO ***********************
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", Val(txtce.Text.ToString))
            myCommand.Parameters.AddWithValue("?tipodoc", lbtipodoc.Text)
            myCommand.CommandText = cs
            ' myCommand.CommandText = "Update " & b & ".tipdoc set actual" & m & "=?actual WHERE tipodoc=?tipodoc AND actual" & m & "<?actual;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GuardarEgreso(ByVal fila As Integer)
        Try
            Dim m As String = fechace.Value.Month
            If Val(m) < 10 Then m = "0" & Val(m)
            Dim b As String = "sae" & FrmPrincipal.lbcompania.Text & fechace.Value.Year
            Dim t As String = "ot_cpp" & m
            '*******************************************
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", 100 - fila)
            myCommand.Parameters.AddWithValue("?doc", lbtipodoc.Text & txtce.Text.ToString)
            myCommand.Parameters.AddWithValue("?grupo", "CE")
            myCommand.Parameters.AddWithValue("?tipodoc", lbtipodoc.Text)
            myCommand.Parameters.AddWithValue("?num", Val(txtce.Text.ToString))
            myCommand.Parameters.AddWithValue("?doc_afec", grilla.Item("doc_afe", fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?dia", fechace.Value.Day)
            myCommand.Parameters.AddWithValue("?periodo", lbperiodo.Text)
            myCommand.Parameters.AddWithValue("?ciudad", ciudad())
            myCommand.Parameters.AddWithValue("?concepto", "CONTRATO NUMERO " & txtcontra.Text & ", VIGENCIA " & txtvig.Text & ", ORDEN DE PAGO NUMERO " & lbper2.Text & "-" & txtorden.Text & ".")
            myCommand.Parameters.AddWithValue("?nitc", grilla.Item("nit", fila).Value)
            myCommand.Parameters.AddWithValue("?tn", "NIT")
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item(1, fila).Value.ToString, 99))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text).ToString)
            '*************************************************************
            Try
                If grilla.Item("cheque", fila).Value = "" Then
                    myCommand.Parameters.AddWithValue("?tipo_pago", "cheque")
                    myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
                    myCommand.Parameters.AddWithValue("?banco", CambiaCadena(txtbanco.Text, 50))
                    'myCommand.Parameters.AddWithValue("?sucursal", "")
                Else
                    myCommand.Parameters.AddWithValue("?tipo_pago", "cheque")
                    myCommand.Parameters.AddWithValue("?cheque", grilla.Item("cheque", fila).Value)
                    myCommand.Parameters.AddWithValue("?banco", CambiaCadena(txtbanco.Text, 50))
                    'myCommand.Parameters.AddWithValue("?sucursal", "")
                End If
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?tipo_pago", "cheque")
                myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
                myCommand.Parameters.AddWithValue("?banco", CambiaCadena(txtbanco.Text, 50))
            End Try
            Try
                myCommand.Parameters.AddWithValue("?sucursal", grilla.Item("sucursal", fila).Value)
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?sucursal", "-")
            End Try
            '*********************************************************
            myCommand.Parameters.AddWithValue("?ccosto", "0")
            myCommand.Parameters.AddWithValue("?fecha", fechace.Value)
            myCommand.Parameters.AddWithValue("?elaborado", UCase(FrmPrincipal.lbuser.Text))
            myCommand.Parameters.AddWithValue("?autorizado", CambiaCadena(txtordenador.Text, 50))
            myCommand.Parameters.AddWithValue("?revisado", CambiaCadena(txtordenador.Text, 50))
            myCommand.Parameters.AddWithValue("?contabilizado", CambiaCadena(txtcontador.Text, 50))
            myCommand.Parameters.AddWithValue("?doc_aj", " ")
            myCommand.Parameters.AddWithValue("?estado", "AP")
            '******
            myCommand.Parameters.AddWithValue("?abonado", DIN(grilla.Item("abonado", fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?doc_anti", txtvig.Text)
            '************* GUARDAR CONSULTA *********************************************
            Dim s As String = "INSERT INTO " & b & "." & t & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?descrip,?debito,?credito,?base,?total,?tipo_pago,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?doc_anti);"

            myCommand.CommandText = "INSERT INTO " & b & "." & t & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?descrip,?debito,?credito,?base,?total,?tipo_pago,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?doc_anti);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            '*************** GUARDAR CONTABLE *************************************
            '*************** GUARDAR CTAS X PAGAR  *************************************
            Try
                If Trim(grilla.Item("doc_afe", fila).Value.ToString) <> "" Then
                    myCommand.Parameters.AddWithValue("?pagado", DIN(grilla.Item("abonado", fila).Value).ToString)
                    myCommand.CommandText = "UPDATE ctas_x_pagar SET pagado=pagado+?pagado WHERE doc='" & grilla.Item("doc_afe", fila).Value.ToString & "'"
                    myCommand.ExecuteNonQuery()
                    myCommand.Parameters.Clear()
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
            myCommand.Parameters.Clear()
            '*************** GUARDAR CONTABLE *************************************
            t = "documentos" & m
            myCommand.Parameters.AddWithValue("?item", 100 - fila)
            myCommand.Parameters.AddWithValue("?doc", Val(txtce.Text.ToString))
            myCommand.Parameters.AddWithValue("?tipodoc", lbtipodoc.Text)
            myCommand.Parameters.AddWithValue("?periodo", lbperiodo.Text)
            myCommand.Parameters.AddWithValue("?dia", fechace.Value.Day)
            myCommand.Parameters.AddWithValue("?ccosto", "0")
            myCommand.Parameters.AddWithValue("?descri", CambiaCadena("CONTRATO #" & txtcontra.Text & " ,ORDEN DE PAGO #" & lbper2.Text & "-" & txtorden.Text, 50))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", CambiaCadena(fechace.Value.ToString, 10))
            myCommand.Parameters.AddWithValue("?nit", grilla.Item("nit", fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?cheque", grilla.Item("cheque", fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?modulo", "Ord de pagos")
            '************* GUARDAR CONSULTA *********************************************
            myCommand.CommandText = "INSERT INTO " & b & "." & t & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?ccosto,?descri,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox("Guardar Egreso => " & fila & " => " & ex.ToString)
        End Try

        'GUARDAR PAGO PRESUPUESTO
        If Trim(grilla.Item("doc_afe", fila).Value.ToString) <> "" Then
            ActPago_Presup(grilla.Item("doc_afe", fila).Value.ToString)
        End If


    End Sub
    Private Sub Ingres_Presup()

        'Dim a As String = Strings.Mid(txtorden.Text, 4, 4)
        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim cta As String = ""
        Dim ing As String = ""
        Dim val As Double = 0
        Dim f As String = Strings.Right(fechace.Value, 4) & Strings.Mid(fechace.Value, 4, 2) & Strings.Left(fechace.Value, 2)

        Dim tcta As New DataTable
        tcta.Clear()
        myCommand.CommandText = "SELECT d.cta, d.cr, o.con_ben, o.nomnit FROM ord_pagos o , deta_ord d  WHERE o.doccxp='" & Doccxp & "' AND d.doc= o.doc AND cta LIKE '41%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tcta)

        If tcta.Rows.Count = 0 Then Exit Sub

        For i = 0 To tcta.Rows.Count - 1
            cta = tcta.Rows(i).Item("cta")
            val = tcta.Rows(i).Item("cr")

            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
            & " WHERE v.ingv_contrac='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count <> 0 Then

                ing = tp.Rows(0).Item(1)
                Try
                    'Guardar MovIng
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                    & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                    & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                    & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                    & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", " & lbperiodo.Text & "-" & txtce.Text & " )"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try

                    'If Trim(tcta.Rows(i).Item("sop_cont")) <> "" Then
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
                   & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
                   & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
                   & "   " & f & ", '" & ing & "',  'RECAUDO POR " & lbperiodo.Text & "-" & txtce.Text & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
                   & " '',  '',  'sae_ordenes', '" & lbperiodo.Text & "-" & txtce.Text & "', '" & tcta.Rows(i).Item("con_ben") & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
                    myCommand.ExecuteNonQuery()
                    'End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    '..Buscar nivel
                    Dim tam As Integer = Len(ing)
                    Dim lik As String = ""

                    Dim tg As New DataTable
                    myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tg)
                    Dim nv As String = tg.Rows(0).Item(0)
                    Dim num As String = tg.Rows(0).Item(1)
                    For j = 0 To tam
                        lik = Strings.Left(ing, tam - j)

                        Dim tc As New DataTable
                        tc.Clear()
                        myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                        & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                        & "FROM " & pbd & ".ingvalores as v " _
                                        & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                        & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                        & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                        & "c.ingc_concepto LIMIT 1"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)
                        If tc.Rows.Count > 0 Then
                            For k = 0 To tc.Rows.Count - 1
                                nv = tc.Rows(k).Item("nivel")
                                num = tc.Rows(k).Item("num")
                                'Guardar MovIng
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                                & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & "," & lbperiodo.Text & "-" & txtce.Text & " )"
                                myCommand.ExecuteNonQuery()

                            Next
                        End If

                    Next
                Catch ex As Exception
                    MsgBox("Error " & ex.ToString)
                End Try
            End If
        Next
    End Sub
    Private Sub ActPago_Presup(ByVal doccxp As String)

        Dim tp As New DataTable
        myCommand.CommandText = "SELECT salmov FROM ctas_x_pagar WHERE doc='" & doccxp & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Refresh()
        If tp.Rows.Count = 0 Then Exit Sub
        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE presupuesto" & Strings.Right(PerActual, 4) & ".pagos SET pag_sae='SI' WHERE pag_consecutivo='" & tp.Rows(0).Item(0) & "'"
        myCommand.ExecuteNonQuery()

        ' REGISTRAR PAGO PRESUPUESTO
        Movimiento_pres(doccxp)
    End Sub
    Private Sub Movimiento_pres(ByVal doccxp As String)

        Dim tp As New DataTable
        myCommand.CommandText = "SELECT ccosto, rcpos FROM ctas_x_pagar WHERE doc='" & doccxp & "' and LEFT(fecha,4)='" & Strings.Right(PerActual, 4) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Refresh()
        If tp.Rows.Count = 0 Then Exit Sub

        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim v As String = ""
        Dim f As String = Strings.Right(fechace.Value, 4) & Strings.Mid(fechace.Value, 4, 2) & Strings.Left(fechace.Value, 2)

        Dim rb(), vrb() As String
        rb = tp.Rows(0).Item(0).Split(";")
        vrb = tp.Rows(0).Item(1).Split(";")

        If rb.Length = 0 Then Exit Sub
        For i = 0 To rb.Length - 1
            If Trim(rb(i).ToString) <> "" Then
                Try
                    v = vrb(i).ToString
                    ' v = MontoRubro2(vrb(i).ToString.Replace(".", ","))
                Catch ex As Exception
                    v = 0
                End Try

                Try
                    'Guardar MovGasto
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO " & pbd & ".`movgastos`(movg_rubro,movg_fecha, movg_vigencia, " _
                                    & "movg_aumento, movg_reduccion, movg_credito, movg_contra, " _
                                    & "movg_aplaza,movg_desaplaza, movg_cdp, movg_rp, movg_pago,movg_anticipo,mov_vsae) " _
                                    & "VALUES ('" & rb(i).ToString & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                    & " '0', '0', '0', '0', '0', '0', '0', '0','0','0'," & v & " )"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    '..Buscar nivel
                    Dim tam As Integer = Len(rb(i).ToString)
                    Dim lik As String = ""

                    Dim tg As New DataTable
                    myCommand.CommandText = "SELECT gasc_nivel, gasc_nums  FROM " & pbd & ".gasconcepto WHERE gasc_orden='" & rb(i).ToString & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tg)
                    Refresh()
                    Dim nv As String = tg.Rows(0).Item(0)
                    Dim num As String = tg.Rows(0).Item(1)
                    For j = 0 To tam
                        lik = Strings.Left(rb(i).ToString, tam - j)

                        Dim tc As New DataTable
                        myCommand.CommandText = "SELECT c.gasc_cod1 as codigo, c.gasc_concepto, " _
                                        & "c.gasc_nivel as nivel, c.gasc_nums as num " _
                                        & "FROM " & pbd & ".gasvalores as v " _
                                        & "INNER JOIN " & pbd & ".gasconcepto as c ON c.gasc_cod1=v.gasv_cod1 " _
                                        & "WHERE c.gasc_orden = '" & lik & "' AND c.gasc_nums< " & num & " " _
                                        & "AND c.gasc_nivel<" & nv & " ORDER BY c.gasc_nivel, " _
                                        & "c.gasc_concepto LIMIT 1"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)
                        Refresh()
                        If tc.Rows.Count > 0 Then
                            For k = 0 To tc.Rows.Count - 1
                                nv = tc.Rows(k).Item("nivel")
                                num = tc.Rows(k).Item("num")
                                'Guardar MovGasto
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "INSERT INTO " & pbd & ".`movgastos`(movg_rubro,movg_fecha, movg_vigencia, " _
                                                & "movg_aumento, movg_reduccion, movg_credito, movg_contra, " _
                                                & "movg_aplaza,movg_desaplaza, movg_cdp, movg_rp, movg_pago,movg_anticipo,mov_vsae) " _
                                                & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                                & " '0', '0', '0', '0', '0', '0', '0', '0','0','0'," & v & " )"
                                myCommand.ExecuteNonQuery()
                            Next
                        End If

                    Next
                Catch ex As Exception
                    MsgBox("Error " & ex.ToString)
                End Try
            End If
        Next

    End Sub
    Function ciudad()
        Dim Archivo As String = "VALLEDUPAR"
        Try
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & "\ciudad.txt"
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
                Return Archivo
            Else
                Try
                    Dim swEscritor As StreamWriter
                    swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\ciudad.txt", False)
                    swEscritor.Write("VALLEDUPAR")
                    swEscritor.Close()
                Catch ex2 As Exception
                    Archivo = "VALLEDUPAR"
                End Try
            End If
        Catch ex As Exception
            Try
                Dim swEscritor As StreamWriter
                swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\ciudad.txt", False)
                swEscritor.Write("VALLEDUPAR")
                swEscritor.Close()
            Catch ex2 As Exception
                Archivo = "VALLEDUPAR"
            End Try
        End Try
        Return Archivo
    End Function
    Public Sub CausarCPP()
        Try

        Catch ex As Exception
            MsgBox("Guardar Cpp=> " & ex.ToString)
        End Try
    End Sub
    Function ExisteDoc()
        Dim bandera As Integer = 0
        Try
            Dim tabla As New DataTable
            Dim m As String = fechace.Value.Month
            If Val(m) < 10 Then m = "0" & Val(m)
            Dim b As String = "sae" & FrmPrincipal.lbcompania.Text & fechace.Value.Year
            Dim t As String = "" & m
            myCommand.CommandText = "SELECT * FROM " & b & "." & t & " WHERE doc='" & lbtipodoc.Text & txtce.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            bandera = tabla.Rows.Count
        Catch ex As Exception
        End Try
        Return bandera
    End Function
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If Trim(txtorden.Text) = "" Then
            MsgBox("Verifique el codigo de la orden", MsgBoxStyle.Information, "Verificacion")
            txtorden.Focus()
            Exit Sub
        End If

        Try
            Dim ch As String = ""
            Dim resultado As MsgBoxResult

            Dim tf As New DataTable
            tf.Clear()
            myCommand.CommandText = "SELECT fce FROM parordenes"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            If tf.Rows.Count <> 0 Then
                If tf.Rows(0).Item(0) <> "" Then
                    resultado = MsgBox("Desea imprimir con el formato de cheque?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        ch = "ch"
                    End If

                    Select Case tf.Rows(0).Item(0)
                        Case "1"
                            GenerarPDF(ch)
                        Case "2"
                            GenerarPDF2(ch)
                        Case "3"
                            GenerarPDF3(ch)
                    End Select
                Else
                    MsgBox("Verifique el Formato del egreso en los parametros", MsgBoxStyle.Information, "SAE")
                End If
            Else
                MsgBox("Verifique el Formato del egreso en los parametros", MsgBoxStyle.Information, "SAE")
            End If

            'Dim resultado As MsgBoxResult
            'resultado = MsgBox("Desea imprimir con el formato de cheque?", MsgBoxStyle.YesNo, "Verificando")
            'If resultado = MsgBoxResult.Yes Then
            '    GenerarPDF("ch")
            'Else
            '    GenerarPDF("")
            'End If

        Catch ex As Exception
            MsgBox("Error al generar el informe, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
    End Sub
   
    Public Sub GenerarPDF(ByVal ch As String)

        BuscarPeriodo()

        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        Dim ban As String = ""
        Dim cta As String = ""
        Dim cheq As String = ""
        Dim valor As String = ""
        doc = PerActual & "-" & txtorden.Text

        MiConexion(bda)
        Cerrar()

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        ' nit = tabla2.Rows(0).Item("nit")


        sql = "SELECT o.`doc` AS doc_ext,  o.`fecha` , o.`con_ben` AS  nitc, o.`nomnit` AS nomnit, o.`v_bruto` AS subtotal," _
         & " (SELECT SUM(d.`db`- d.cr) FROM deta_ord d WHERE d.doc=o.doc GROUP BY doc) AS ret,  " _
         & " o.`v_neto` AS total,  o.con_objeto AS concepto,d.cta AS ctatotal, d.`concep` AS descrip, d.`db` AS tasa , " _
         & " d.cr AS vpos , CAST(CONCAT( RIGHT(o.fecha, 2), '/', MID(o.fecha, 6, 2),'/',LEFT(o.fecha, 4)) AS CHAR(10)) AS pagare  " _
         & " FROM ord_pagos o LEFT JOIN deta_ord d " _
         & " ON o.doc = d.doc  WHERE o.doc = '" & txtorden.Text & "' "

        If gcuenta.RowCount > 0 Then
            For i = 0 To gcuenta.RowCount - 1
                ban = ban & gcuenta.Item("banco", i).Value & vbCrLf
                cta = cta & gcuenta.Item("cta_con", i).Value & vbCrLf
                cheq = cheq & gcuenta.Item("cheque2", i).Value & vbCrLf
                valor = valor & gcuenta.Item("monto", i).Value & vbCrLf
            Next
        End If

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)


        Dim tabl As DataSet
        tabl = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac FROM parafacts WHERE factura='RAPIDA'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "parafacts")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "select codigo as descri, debito, credito FROM ot_cpp" & Strings.Left(lbperiodo.Text, 2) & "  " _
       & " WHERE doc= '" & lbtipodoc.Text & txtce.Text & "'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "documentos01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportComprOrden.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField
            Dim Prdoc As New ParameterField
            Dim Prord As New ParameterField
            Dim Prcont As New ParameterField
            Dim Prvig As New ParameterField
            Dim Prcta As New ParameterField
            Dim Prban As New ParameterField
            Dim Prchq As New ParameterField
            Dim Prletra As New ParameterField
            Dim PrFE As New ParameterField
            Dim Prch As New ParameterField
            Dim Prmont As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prdoc.Name = "ce"
            Prdoc.CurrentValues.AddValue(lbperiodo.Text & "-" & lbtipodoc.Text & txtce.Text.ToString)
            Prord.Name = "ord"
            Prord.CurrentValues.AddValue(txtordenador.Text.ToString)
            Prcont.Name = "cont"
            Prcont.CurrentValues.AddValue(txtcontador.Text.ToString)
            Prvig.Name = "vig"
            Prvig.CurrentValues.AddValue(txtvig.Text.ToString)
            Prcta.Name = "cuent"
            Prcta.CurrentValues.AddValue(cta)
            Prban.Name = "banc"
            Prban.CurrentValues.AddValue(ban)
            Prchq.Name = "cheq"
            Prchq.CurrentValues.AddValue(cheq)
            Prmont.Name = "monto"
            Prmont.CurrentValues.AddValue(valor)
            Prletra.Name = "letra"
            Prletra.CurrentValues.AddValue(lbpesos.Text.ToString)
            PrFE.Name = "FE"
            PrFE.CurrentValues.AddValue(fechace.Value)
            Prch.Name = "vcheq"
            Prch.CurrentValues.AddValue(ch)

            prmdatos.Add(Prcomp)
            prmdatos.Add(Prdoc)
            prmdatos.Add(Prord)
            prmdatos.Add(Prcont)
            prmdatos.Add(Prvig)
            prmdatos.Add(Prcta)
            prmdatos.Add(Prban)
            prmdatos.Add(Prchq)
            prmdatos.Add(Prletra)
            prmdatos.Add(PrFE)
            prmdatos.Add(Prch)
            prmdatos.Add(Prmont)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        conexion.Close()
    End Sub
    Private Sub GenerarPDF3(ByVal ch As String)

        Dim a As String = Strings.Mid(txtorden.Text, 4, 4)
        BuscarPeriodo()

        Dim sql As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim ban As String = ""
        Dim cta As String = ""
        Dim cheq As String = ""
        Dim valor As String = ""


        MiConexion(bda)

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        ':::::::::::::::::::::::::::::::::::::::::::::

        '.. Deducciones
        Dim nomd As String = ""
        Dim vald As String = ""
        Dim td As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CAST(CONCAT(d.`concep`,' ', d.porc, '%') AS CHAR(200)) AS nomd,  CAST((d.`db`- d.cr) AS SIGNED) AS valor " _
        & " FROM  deta_ord d WHERE d.doc = '" & txtorden.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        If td.Rows.Count > 0 Then
            For j = 0 To td.Rows.Count - 1
                nomd = nomd & td.Rows(j).Item(0).ToString & vbCrLf
                vald = vald & Moneda(td.Rows(j).Item(1)) & vbCrLf
            Next
        End If

       
        sql = "select o.con_objeto as descrip, o.v_bruto as descto, o.v_neto as ret,  c.ctaretica as ctaretiva, c.pagare as ctasubtotal " _
        & " from ord_pagos o, ctas_x_pagar c where o.doc='" & txtorden.Text & "' and c.doc=o.doccxp"

        '///////////////////////////////////////////////
        '.. Imputacion
        Dim tabla3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "Select cta_rubro , doccxp from ord_pagos  where doc='" & txtorden.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)


        Dim cm As String = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "gasc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "gasc_fut"
        Else
            cm = "gasc_cgdg"
        End If


        Dim rb As String = ""
        'Try
        Dim cd_rb As String = ""
        rb = Trim(tabla3.Rows(0).Item("cta_rubro"))

        Dim cp() As String
        cp = rb.Split(";")
        For i = 0 To cp.Length - 1
            If i <> cp.Length - 1 Then
                cd_rb = cd_rb & "'" & cp(i).ToString & "',"
            Else
                cd_rb = cd_rb & "'" & cp(i).ToString & "'"
            End If
        Next

        cd_rb = Trim(cd_rb.Replace(Chr(10), ""))
        Dim tr As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CONCAT(" & cm & " ,'  - ' ,gasc_concepto) " _
        & " FROM presupuesto" & a & ".`gasconcepto`, ctas_x_pagar  WHERE `gasc_cod1` IN (" & Trim(cd_rb) & ") " _
        & " and doc='" & tabla3.Rows(0).Item(1) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr)
        rb = ""
        Dim ta5 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select moneda, rcpos, if(monloex='N','',monloex) as mon from ctas_x_pagar where doc='" & tabla3.Rows(0).Item(1) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta5)
        Dim cp2() As String
        Dim cp3() As String
        Dim cp4() As String
        cp2 = Trim(ta5.Rows(0).Item("moneda")).Split(";")
        cp3 = Trim(ta5.Rows(0).Item("rcpos")).Split(";")
        cp4 = Trim(ta5.Rows(0).Item("mon")).Split(";")

        If tr.Rows.Count > 0 Then
            For j = 0 To tr.Rows.Count - 1
                rb = rb & "RUBRO:" & tr.Rows(j).Item(0).ToString & vbCrLf
                ' "FUENTE: " & cp2(j).ToString & vbCrLf & _
                ' "MONTO: " & MontoRubro(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf & _
                '"SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                Try
                    If Trim(cp2(j).ToString) <> "" Then
                        rb = rb & "FUENTE: " & cp2(j).ToString & vbCrLf
                    End If
                Catch ex As Exception
                End Try
                Try
                    rb = rb & "MONTO: " & MontoRubro2(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf
                Catch ex As Exception
                End Try
                Try
                    If Trim(cp4(j).ToString) <> "" Then
                        rb = rb & "SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                    Else
                        rb = rb & vbCrLf
                    End If
                Catch ex As Exception
                    rb = rb & vbCrLf
                End Try
            Next
        End If

        If gcuenta.RowCount > 0 Then
            For i = 0 To gcuenta.RowCount - 1
                ban = ban & gcuenta.Item("banco", i).Value & vbCrLf
                cta = cta & gcuenta.Item("cta_con", i).Value & vbCrLf
                cheq = cheq & gcuenta.Item("cheque2", i).Value & vbCrLf
                valor = valor & gcuenta.Item("monto", i).Value & vbCrLf
            Next
        End If
        '....
        Dim f1 As String = ""
        Dim f2 As String = ""
        Dim tf As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT firma1, firma2  FROM parordenes  "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tf)
        If tf.Rows.Count <> 0 Then
            f1 = tf.Rows(0).Item(0)
            f2 = tf.Rows(0).Item(1)
        End If

        Dim tabl As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLegal
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportComprOrden3.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            '..
            Dim Prt1 As New ParameterField
            Dim Prm1 As New ParameterField
            '..
            Dim Prch As New ParameterField
            Dim Pror As New ParameterField
            Dim Prts As New ParameterField
            '...
            Dim Prnd As New ParameterField
            Dim Prvd As New ParameterField
            Dim Prrb As New ParameterField
            '...
            Dim Prbn As New ParameterField
            Dim Prcta As New ParameterField
            Dim Prmon As New ParameterField
            Dim Prcheq As New ParameterField
            '...
            Dim Prf1 As New ParameterField
            Dim Prf2 As New ParameterField
            Dim Prordn As New ParameterField
            Dim Prfce As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "comp"
            PrNit.CurrentValues.AddValue(nom)
            Prcomp.Name = "nit"
            Prcomp.CurrentValues.AddValue(nit.ToString)
            '...
            Prt1.Name = "doc"
            Prt1.CurrentValues.AddValue(lbperiodo.Text & " " & txtce.Text)
            Prm1.Name = "pagado"
            Prm1.CurrentValues.AddValue(txtnit.Text & " " & txtnombre.Text)
            '..
            Prch.Name = "ch"
            Prch.CurrentValues.AddValue(ch)
            Pror.Name = "ord"
            Pror.CurrentValues.AddValue("")
            Prts.Name = "tes"
            Prts.CurrentValues.AddValue("")

            Prnd.Name = "nd"
            Prnd.CurrentValues.AddValue(nomd)
            Prvd.Name = "vd"
            Prvd.CurrentValues.AddValue(vald)
            Prrb.Name = "rubr"
            Prrb.CurrentValues.AddValue(rb)

            Prbn.Name = "banc"
            Prbn.CurrentValues.AddValue(ban)
            Prcta.Name = "cuent"
            Prcta.CurrentValues.AddValue(cta)
            Prmon.Name = "monto"
            Prmon.CurrentValues.AddValue(valor)
            Prcheq.Name = "cheq"
            Prcheq.CurrentValues.AddValue(cheq)

            Prf1.Name = "ord"
            Prf1.CurrentValues.AddValue(f1)
            Prf2.Name = "tes"
            Prf2.CurrentValues.AddValue(f2)
            Prordn.Name = "norden"
            Prordn.CurrentValues.AddValue(txtorden.Text)
            Prfce.Name = "fce"
            Prfce.CurrentValues.AddValue(fechace.Text.ToString)

            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prt1)
            prmdatos.Add(Prm1)
            prmdatos.Add(Prch)
            prmdatos.Add(Pror)
            prmdatos.Add(Prts)
            prmdatos.Add(Prnd)
            prmdatos.Add(Prvd)
            prmdatos.Add(Prrb)
            prmdatos.Add(Prbn)
            prmdatos.Add(Prcheq)
            prmdatos.Add(Prmon)
            prmdatos.Add(Prcta)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prf2)
            prmdatos.Add(Prordn)
            prmdatos.Add(Prfce)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Private Sub GenerarPDF2(ByVal ch As String)

        BuscarPeriodo()

        Dim a As String = Strings.Mid(txtorden.Text, 4, 4)

        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        Dim ban As String = ""
        Dim cta As String = ""
        Dim cheq As String = ""
        Dim valor As String = ""
        Dim nite As String = ""
        doc = PerActual & "-" & txtorden.Text

        MiConexion(bda)
        Cerrar()

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nite = tabla2.Rows(0).Item("nit")


        sql = "SELECT o.`doc` AS doc_ext,  o.`fecha` , o.`con_ben` AS  nitc, o.`nomnit` AS nomnit, o.`v_bruto` AS subtotal," _
         & " (SELECT SUM(d.`db`- d.cr) FROM deta_ord d WHERE d.doc=o.doc GROUP BY doc) AS ret,  " _
         & " o.`v_neto` AS total,  o.con_objeto AS concepto,d.cta AS ctatotal, d.`concep` AS descrip, d.`db` AS tasa , " _
         & " d.cr AS vpos , CAST(CONCAT( RIGHT(o.fecha, 2), '/', MID(o.fecha, 6, 2),'/',LEFT(o.fecha, 4)) AS CHAR(10)) AS pagare, c.ctaretica , CAST(c.pagare AS CHAR(20)) as ctasubtotal  " _
         & " FROM ctas_x_pagar c,ord_pagos o LEFT JOIN deta_ord d " _
         & " ON o.doc = d.doc  WHERE o.doc = '" & txtorden.Text & "' and o.doccxp=c.doc "

        If gcuenta.RowCount > 0 Then
            For i = 0 To gcuenta.RowCount - 1
                ban = ban & gcuenta.Item("banco", i).Value & vbCrLf
                cta = cta & gcuenta.Item("cta_con", i).Value & vbCrLf
                cheq = cheq & gcuenta.Item("cheque2", i).Value & vbCrLf
                valor = valor & gcuenta.Item("monto", i).Value & vbCrLf
            Next
        End If

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        '.. Deducciones
        Dim nomd As String = ""
        Dim vald As String = ""
        Dim td As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CAST(CONCAT(d.`concep`,' ', d.porc, '%') AS CHAR(200)) AS nomd,  CAST((d.`db`- d.cr) AS SIGNED) AS valor " _
& " FROM  deta_ord d WHERE d.doc = '" & txtorden.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        If td.Rows.Count > 0 Then
            For j = 0 To td.Rows.Count - 1
                nomd = nomd & td.Rows(j).Item(0).ToString & vbCrLf
                vald = vald & Moneda(td.Rows(j).Item(1)) & vbCrLf
            Next
        End If

        '///////////////////////////////////////////////
        '.. Imputacion
        Dim tabla3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "Select cta_rubro , doccxp from ord_pagos  where doc='" & txtorden.Text & "'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)


        Dim cm As String = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "gasc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "gasc_fut"
        Else
            cm = "gasc_cgdg"
        End If


        Dim rb As String = ""
        'Try
        Dim cd_rb As String = ""
        rb = Trim(tabla3.Rows(0).Item("cta_rubro"))

        Dim cp() As String
        cp = rb.Split(";")
        For i = 0 To cp.Length - 1
            If i <> cp.Length - 1 Then
                cd_rb = cd_rb & "'" & cp(i).ToString & "',"
            Else
                cd_rb = cd_rb & "'" & cp(i).ToString & "'"
            End If
        Next

        cd_rb = Trim(cd_rb.Replace(Chr(10), ""))
        Dim tr As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CONCAT(" & cm & " ,'  - ' ,gasc_concepto) " _
        & " FROM presupuesto" & a & ".`gasconcepto`, ctas_x_pagar  WHERE `gasc_cod1` IN (" & Trim(cd_rb) & ") " _
        & " and doc='" & tabla3.Rows(0).Item(1) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr)
        rb = ""
        Dim ta5 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select moneda, rcpos, if(monloex='N','',monloex) as mon from ctas_x_pagar where doc='" & tabla3.Rows(0).Item(1) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta5)
        Dim cp2() As String
        Dim cp3() As String
        Dim cp4() As String
        cp2 = Trim(ta5.Rows(0).Item("moneda")).Split(";")
        cp3 = Trim(ta5.Rows(0).Item("rcpos")).Split(";")
        cp4 = Trim(ta5.Rows(0).Item("mon")).Split(";")

        If tr.Rows.Count > 0 Then
            For j = 0 To tr.Rows.Count - 1
                If Int(cp3(j).ToString) <> 0 Then
                    rb = rb & "RUBRO:" & tr.Rows(j).Item(0).ToString & vbCrLf
                    ' "FUENTE: " & cp2(j).ToString & vbCrLf & _
                    ' "MONTO: " & MontoRubro(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf & _
                    '"SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                    'Try
                    '    rb = rb & "FUENTE: " & cp2(j).ToString & vbCrLf
                    'Catch ex As Exception
                    'End Try
                    Try
                        If Trim(cp2(j).ToString) <> "" Then
                            rb = rb & "FUENTE: " & cp2(j).ToString & vbCrLf
                        Else
                            rb = rb & vbCrLf
                        End If
                    Catch ex As Exception
                        rb = rb & vbCrLf
                    End Try
                    Try
                        rb = rb & "MONTO: " & MontoRubro2(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf
                    Catch ex As Exception
                    End Try
                    Try
                        If Trim(cp4(j).ToString) <> "" Then
                            rb = rb & "SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                        Else
                            rb = rb & vbCrLf
                        End If
                    Catch ex As Exception
                        rb = rb & vbCrLf
                    End Try
                End If
            Next
        End If


        Dim tabl As DataSet
        tabl = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac FROM parafacts WHERE factura='RAPIDA'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "parafacts")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "select codigo as descri, debito, credito FROM ot_cpp" & Strings.Left(lbperiodo.Text, 2) & "  " _
       & " WHERE doc= '" & lbtipodoc.Text & txtce.Text & "'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "documentos01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportCompOrdenP.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcomp As New ParameterField
            Dim Prdoc As New ParameterField
            Dim Prord As New ParameterField
            Dim Prcont As New ParameterField
            Dim Prvig As New ParameterField
            Dim Prcta As New ParameterField
            Dim Prban As New ParameterField
            Dim Prchq As New ParameterField
            Dim Prletra As New ParameterField
            Dim PrFE As New ParameterField
            Dim Prch As New ParameterField
            Dim Prmont As New ParameterField
            Dim Prnite As New ParameterField
            Dim PrOP As New ParameterField
            Dim Prnd As New ParameterField
            Dim Prvd As New ParameterField
            Dim Prrb As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prnd.Name = "nd"
            Prnd.CurrentValues.AddValue(nomd.ToString)
            Prvd.Name = "vd"
            Prvd.CurrentValues.AddValue(vald.ToString)
            Prrb.Name = "rubr"
            Prrb.CurrentValues.AddValue(rb.ToString)
            '...
            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prdoc.Name = "ce"
            Prdoc.CurrentValues.AddValue(lbperiodo.Text & "-" & lbtipodoc.Text & txtce.Text.ToString)
            Prord.Name = "ord"
            Prord.CurrentValues.AddValue(txtordenador.Text.ToString)
            Prcont.Name = "cont"
            Prcont.CurrentValues.AddValue(txtcontador.Text.ToString)
            Prvig.Name = "vig"
            Prvig.CurrentValues.AddValue(txtvig.Text.ToString)
            Prcta.Name = "cuent"
            Prcta.CurrentValues.AddValue(cta)
            Prban.Name = "banc"
            Prban.CurrentValues.AddValue(ban)
            Prchq.Name = "cheq"
            Prchq.CurrentValues.AddValue(cheq)
            Prmont.Name = "monto"
            Prmont.CurrentValues.AddValue(valor)
            Prletra.Name = "letra"
            Prletra.CurrentValues.AddValue(lbpesos.Text.ToString)
            PrFE.Name = "fe"
            PrFE.CurrentValues.AddValue(fechace.Value)
            Prch.Name = "vcheq"
            Prch.CurrentValues.AddValue(ch)
            Prnite.Name = "nit"
            Prnite.CurrentValues.AddValue(nite)
            PrOP.Name = "op"
            PrOP.CurrentValues.AddValue(txtorden.Text)

            prmdatos.Add(Prcomp)
            prmdatos.Add(Prdoc)
            prmdatos.Add(Prord)
            prmdatos.Add(Prcont)
            prmdatos.Add(Prvig)
            prmdatos.Add(Prcta)
            prmdatos.Add(Prban)
            prmdatos.Add(Prchq)
            prmdatos.Add(Prletra)
            prmdatos.Add(PrFE)
            prmdatos.Add(Prch)
            prmdatos.Add(Prnite)
            prmdatos.Add(PrOP)
            prmdatos.Add(Prnd)
            prmdatos.Add(Prvd)
            prmdatos.Add(Prrb)
            prmdatos.Add(Prmont)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        conexion.Close()
    End Sub
    Function MontoRubro2(ByVal m As String)


        Dim mt As Double = 0 'monto rubro
        Dim mta As Double = 0 'monto auxiliar
        Dim dcto As Double = 0 'descuento
        Try
            mt = CDbl(m)
            mta = CDbl(m)
        Catch ex As Exception
        End Try

        Dim td As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT  d.porc,  CAST((d.`db`- d.cr) AS SIGNED) AS valor " _
        & " FROM  deta_ord d WHERE d.doc = '" & txtorden.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        If td.Rows.Count > 0 Then

            For j = 0 To td.Rows.Count - 1
                Try
                    dcto = 0
                    If (CDbl(td.Rows(j).Item("porc")) > 0) Then
                        dcto = mta * (CDbl(td.Rows(j).Item("porc")) / 100)
                    End If
                    mt = mt - dcto
                    'MsgBox(mt)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
            m = Moneda(mt)
        End If
        Return m
    End Function

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub txtcta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta.KeyPress
        validarnumero(txtcta, e)
    End Sub

    Private Sub txtcta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta.LostFocus
        Try
            If txtbanco.Text = "" Then
                txtcta.Text = ""
                FrmSelBanco.lbform.Text = "nce"
                FrmSelBanco.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtcta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcta.TextChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT b.*, s.descripcion FROM bancos b, selpuc s WHERE s.codigo= b.codigo and b.codigo='" & txtcta.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtctab.Text = tabla.Rows(0).Item("num_cta").ToString
            txtbanco.Text = tabla.Rows(0).Item("descripcion").ToString
            grilla.Item("Cuenta", 0).Value = txtcta.Text
            gcuenta.Item("cta_con", 0).Value = txtcta.Text

        Catch ex As Exception
            txtctab.Text = ""
            txtbanco.Text = ""
            If grilla.RowCount > 0 Then
                grilla.Item("Cuenta", 0).Value = ""
            End If
        End Try
    End Sub

    Private Sub txtce_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtce.KeyPress
        validarnumero(txtce, e)
    End Sub

    Private Sub txtce_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtce.LostFocus
        Try

            If ok = "ok" Then
                txtce.Text = NumeroDoc(Val(txtce.Text))
                Dim tbo As New DataTable
                myCommand.CommandText = "SELECT * FROM ot_cpp" & Strings.Mid(fechace.Value, 4, 2) & " WHERE doc ='" & Trim(lbtipodoc.Text & txtce.Text) & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tbo)
                If tbo.Rows.Count > 0 Then
                    MsgBox("El codigo del egreso ya ha sido utilizado, Verifique", MsgBoxStyle.Information, "Verificacion")
                    FrmOrdenPagos.BuscarActualCE(Strings.Mid(fechace.Value, 4, 2))
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtvig_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvig.KeyPress
        validarnumero(txtvig, e)
    End Sub

    Private Sub txtordenador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtordenador.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcontador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontador.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub fechace_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fechace.ValueChanged
        If ok = "ok" Then
            Try
                Dim m As String = fechace.Value.Month
                If Val(m) < 10 Then m = "0" & Val(m)
                lbperiodo.Text = m & "/" & fechace.Value.Year
            Catch ex As Exception
            End Try

            Dim tbo As New DataTable
            myCommand.CommandText = "SELECT * FROM ot_cpp" & Strings.Mid(fechace.Value, 4, 2) & " WHERE doc ='" & Trim(lbtipodoc.Text & txtce.Text) & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tbo)
            If tbo.Rows.Count > 0 Then
                MsgBox("El codigo del egreso ya ha sido utilizado en el perido " & Strings.Mid(fechace.Value, 4, 2) & ", Verifique", MsgBoxStyle.Information, "Verificacion")
                FrmOrdenPagos.BuscarActualCE(Strings.Mid(fechace.Value, 4, 2))
                Exit Sub
            End If
        End If
    End Sub

    Private Sub FrmNuevoEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtcta_TextChanged(AcceptButton, AcceptButton)
    End Sub

    Private Sub txtdoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc.LostFocus


    End Sub
    Dim soport As String = ""
    Private Sub BuscarOrden()
        Try
            ok = ""
            soport = ""
            Dim base2 As Double


            Dim tb As New DataTable
            tb.Clear()
            myCommand.CommandText = " SELECT  c.*  FROM ord_pagos o, ctas_x_pagar  c where c.doc = o.doccxp and o.doc='" & txtorden.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()

            Dim tb2 As New DataTable
            tb2.Clear()
            myCommand.CommandText = " SELECT o. *  FROM ord_pagos o, ctas_x_pagar  c where c.doc = o.doccxp and o.doc='" & txtorden.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb2)
            Refresh()
            'lbdoc.Text = PerActual & "-" & txtorden.Text
            'lbper2.Text = PerActual
            'lbperiodo.Text = lbper2.Text
            'txtorden.Text = txtorden.Text
            'If tb.Rows.Count = 0 Then Exit Sub
            'If tb2.Rows.Count = 0 Then Exit Sub
            Dim a As String = Strings.Mid(txtorden.Text, 4, 4)
            txtdoc.Text = tb2.Rows(0).Item("sop_cont")
            Try
                gcuenta.Rows.Clear()
                gcuenta.RowCount = 2
            Catch ex As Exception

            End Try
            Doccxp = tb.Rows(0).Item("doc")
            fecha.Value = tb.Rows(0).Item("fecha").ToString
            txtdis.Text = tb.Rows(0).Item("pagare")
            txtcontra.Text = tb2.Rows(0).Item("con_num")
            txtplazo.Text = tb.Rows(0).Item("vmto")
            txttipo.Text = tb.Rows(0).Item("ctaret")
            txtnit.Text = tb2.Rows(0).Item("con_ben")
            txtnombre.Text = tb2.Rows(0).Item("nomnit").ToString
            lbdv.Text = DigitoNIT(txtnit.Text)
            txtconcep.Text = tb2.Rows(0).Item("con_objeto")
            base2 = tb2.Rows(0).Item("v_bruto") - tb2.Rows(0).Item("v_iva")

            VBruto = ""
            VBruto = tb2.Rows(0).Item("v_bruto").ToString
            ' varios rubros
            Dim rb As String = ""
            Dim cad As String = ""
            Dim vc() As String
            rb = tb.Rows(0).Item("ccosto").ToString
            If rb.Length <> rb.Replace(";", "").Length Then
                vc = rb.Split(";")
                For i = 0 To vc.Length - 1
                    If i = vc.Length - 1 Then
                        cad = cad & vc(i)
                    Else
                        cad = cad & vc(i) & vbCrLf
                    End If
                Next
            Else
                cad = tb.Rows(0).Item("ccosto").ToString
            End If
            txtrubro.Text = cad
            txtrubro_TextChanged(AcceptButton, AcceptButton)
            txttotal.Text = Moneda(tb2.Rows(0).Item("v_neto").ToString)
            lbpesos.Text = "SON: " & Num2Text(txttotal.Text)
            'fechace.MinDate = fecha.Value
            'fechace.Value = fecha.Value
            Try
                fechace.Value = Now.Day.ToString & "/" & PerActual(0) & PerActual(1) & "/" & Strings.Right(PerActual, 4)
            Catch ex As Exception
                fechace.Value = Today
            End Try
            lbperiodo.Text = PerActual

            soport = tb2.Rows(0).Item("sop_cont").ToString

            FrmOrdenPagos.BuscarActualCE(Strings.Mid(fechace.Value, 4, 2))
            FrmOrdenPagos.BuscarVigencia()

            If Trim(tb2.Rows(0).Item("estado").ToString) <> "" Then
                CmdListo.Enabled = False
                CmdCancelar.Enabled = False
                cmdprint.Enabled = True
                'Try
                Dim v() As String
                v = soport.Split("-")
                lbperiodo.Text = v(0)
                txtce.Text = Strings.Right(v(1), v(1).Length - 2)
                FrmOrdenPagos.BuscarCE(v(0), v(1))
                'fechace.Value = fecha.Value
                gce.Enabled = False
            ElseIf Trim(tb2.Rows(0).Item("estado").ToString) = "" And Trim(tb2.Rows(0).Item("sop_cont").ToString) <> "" Then
                CmdListo.Enabled = True
                CmdCancelar.Enabled = True
                cmdprint.Enabled = False
                'Try
                Dim v() As String
                v = soport.Split("-")
                lbperiodo.Text = v(0)
                txtce.Text = Strings.Right(v(1), v(1).Length - 2)
                FrmOrdenPagos.BuscarCE(v(0), v(1))
                'fechace.Value = fecha.Value
                gce.Enabled = True
            Else
                CmdListo.Enabled = True
                CmdCancelar.Enabled = True
                cmdprint.Enabled = False
                gce.Enabled = True
                txtvig.Text = ""
                txtcta.Text = ""
                txtcheque.Text = ""
                txtordenador.Text = ""
                txtcontador.Text = ""
                FrmOrdenPagos.BuscarContador()
                FrmOrdenPagos.BuscarActualCE(Strings.Mid(fechace.Value, 4, 2))
                ok = "ok"
            End If
            If txtvig.Text = "" Then
                txtvig.Text = Now.Year
            End If
            Try
                grilla.Rows.Clear()
            Catch ex As Exception
            End Try
            grilla.RowCount = grilla.RowCount + 5
            Dim j As Integer = 0
            '*********************************************
            grilla.Item("Cuenta", j).Value = ""
            grilla.Item("Debitos", j).Value = "0"
            grilla.Item("Creditos", j).Value = txttotal.Text
            grilla.Item("Descripcion", j).Value = "ORDEN DE PAGO " & PerActual & "-" & txtorden.Text
            grilla.Item("Base", j).Value = "0"
            grilla.Item("doc_afe", j).Value = ""
            grilla.Item("editar", j).Value = "si"
            grilla.Item("DocAnti", j).Value = ""
            grilla.Item("abonado", j).Value = "0"
            grilla.Item("nit", j).Value = txtnit.Text
            grilla.Item("cheque", j).Value = ""
            grilla.Item("sucursal", j).Value = ""

            '**********************************************

            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT o.*,d.* FROM ord_pagos o LEFT JOIN deta_ord d ON o.doc = d.doc WHERE o.doc='" & txtorden.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                CmdListo.Enabled = True
                CmdCancelar.Enabled = True
                cmdprint.Enabled = False
                gce.Enabled = True
            Else
                grilla.RowCount = tabla.Rows.Count + 5
                If tabla.Rows.Count > 0 Then
                    For i = 0 To tabla.Rows.Count - 1
                        j = i + 1
                        Try
                            grilla.Item("Cuenta", j).Value = tabla.Rows(i).Item("cta").ToString
                            grilla.Item("Descripcion", j).Value = tabla.Rows(i).Item("concep").ToString
                            grilla.Item("Base", j).Value = Moneda(base2)
                            Try
                                grilla.Item("Debitos", j).Value = Moneda(CDbl(tabla.Rows(i).Item("db").ToString))
                            Catch ex As Exception
                                grilla.Item("Debitos", j).Value = Moneda("0")
                            End Try
                            Try
                                grilla.Item("Creditos", j).Value = Moneda(CDbl(tabla.Rows(i).Item("cr").ToString))
                            Catch ex As Exception
                                grilla.Item("Creditos", j).Value = Moneda("0")
                            End Try
                            grilla.Item("doc_afe", j).Value = ""
                            grilla.Item("editar", j).Value = "no"
                            grilla.Item("DocAnti", j).Value = ""
                            grilla.Item("abonado", j).Value = "0"
                            grilla.Item("nit", j).Value = tb2.Rows(0).Item("con_ben")
                            grilla.Item("cheque", j).Value = ""
                            grilla.Item("sucursal", j).Value = ""
                        Catch ex As Exception
                            MsgBox("Error al buscar detalles " & ex.ToString)
                        End Try
                    Next
                End If
                j = j + 1
                If tb.Rows(0).Item("nitc") <> tb2.Rows(0).Item("con_ben") Then
                    grilla.RowCount = grilla.RowCount + 1
                    j = j + 1
                    grilla.Item("Cuenta", j).Value = tb.Rows(0).Item("ctatotal")
                    grilla.Item("Descripcion", j).Value = "AJUSTE DE CUENTA POR PAGAR"
                    grilla.Item("Base", j).Value = Moneda(0)
                    Try
                        grilla.Item("Debitos", j).Value = Moneda(VBruto)
                    Catch ex As Exception
                        grilla.Item("Debitos", j).Value = Moneda("0")
                    End Try
                    Try
                        grilla.Item("Creditos", j).Value = Moneda("0")
                    Catch ex As Exception
                        grilla.Item("Creditos", j).Value = Moneda("0")
                    End Try
                    grilla.Item("doc_afe", j).Value = ""
                    grilla.Item("editar", j).Value = "no"
                    grilla.Item("DocAnti", j).Value = ""
                    grilla.Item("abonado", j).Value = "0"
                    grilla.Item("nit", j).Value = tb.Rows(0).Item("nitc")
                    grilla.Item("cheque", j).Value = ""
                    grilla.Item("sucursal", j).Value = ""
                    grilla.RowCount = grilla.RowCount + 1
                    j = j + 1
                    grilla.Item("Cuenta", j).Value = tb.Rows(0).Item("ctatotal")
                    grilla.Item("Descripcion", j).Value = "AJUSTE DE CUENTA POR PAGAR"
                    grilla.Item("Base", j).Value = Moneda(0)
                    Try
                        grilla.Item("Debitos", j).Value = Moneda("0")
                    Catch ex As Exception
                        grilla.Item("Debitos", j).Value = Moneda("0")
                    End Try
                    Try
                        grilla.Item("Creditos", j).Value = Moneda(VBruto)
                    Catch ex As Exception
                        grilla.Item("Creditos", j).Value = Moneda("0")
                    End Try
                    grilla.Item("doc_afe", j).Value = ""
                    grilla.Item("editar", j).Value = "no"
                    grilla.Item("DocAnti", j).Value = ""
                    grilla.Item("abonado", j).Value = "0"
                    grilla.Item("nit", j).Value = tb2.Rows(0).Item("con_ben")
                    grilla.Item("cheque", j).Value = ""
                    grilla.Item("sucursal", j).Value = ""
                End If

            End If
            'For i = 0 To grilla.RowCount - 1
            '    j = i + 1
            '    grilla.Item("Cuenta", j).Value = grilla.Item("cta", i).Value
            '    grilla.Item("Debitos", j).Value = grilla.Item("Debitos", i).Value
            '    grilla.Item("Creditos", j).Value = grilla.Item("Creditos", i).Value
            '    grilla.Item("Descripcion", j).Value = grilla.Item("Descripcion", i).Value
            '    grilla.Item("Base", j).Value = Moneda(tb2.Rows(0).Item("con_valor").ToString)
            '    grilla.Item("doc_afe", j).Value = ""
            '    grilla.Item("editar", j).Value = "no"
            '    grilla.Item("DocAnti", j).Value = ""
            '    grilla.Item("abonado", j).Value = "0"
            'Next
            j = j + 1
            '*********************************************
            grilla.Item("Cuenta", j).Value = tb.Rows(0).Item("ctatotal")
            grilla.Item("Debitos", j).Value = Moneda(tb2.Rows(0).Item("v_bruto").ToString)
            grilla.Item("Creditos", j).Value = "0"
            grilla.Item("Descripcion", j).Value = "ORDEN DE PAGO " & PerActual & "-" & txtorden.Text
            grilla.Item("Base", j).Value = "0"
            grilla.Item("doc_afe", j).Value = tb.Rows(0).Item("doc").ToString
            grilla.Item("editar", j).Value = "no"
            grilla.Item("DocAnti", j).Value = ""
            grilla.Item("abonado", j).Value = Moneda(tb2.Rows(0).Item("v_bruto").ToString)
            grilla.Item("nit", j).Value = tb2.Rows(0).Item("con_ben")
            grilla.Item("cheque", j).Value = ""
            grilla.Item("sucursal", j).Value = ""
            '*********************************************************************
            If Trim(soport) <> "" Then
                BuscarFP(soport)
            End If
        Catch ex As Exception
            '   MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarFP(ByVal doc As String)
        Try
            Dim d() As String
            d = doc.Split("-")
            Dim sql As String = ""
            If fechace.Value.Month < 10 Then
                sql = "SELECT * FROM  ot_cpp0" & fechace.Value.Month & " where doc = '" & d(1) & "' AND sucursal = '--';"
            Else
                sql = "SELECT * FROM  ot_cpp" & fechace.Value.Month & " where doc = '" & d(1) & "' AND sucursal = '--';"
            End If
            Dim tb2 As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb2)
            Try
                gcuenta.Rows.Clear()
                FemFPE2.gcuenta.Rows.Clear()
            Catch ex As Exception
            End Try
            If tb2.Rows.Count = 0 Then
                gcuenta.RowCount = 2
            Else
                gcuenta.RowCount = tb2.Rows.Count + 1
                For i = 0 To tb2.Rows.Count - 1
                    If i = 0 Then
                        txtcta.Text = tb2.Rows(0).Item("codigo").ToString
                        txtbanco.Text = tb2.Rows(0).Item("banco").ToString
                        If Trim(txtctab.Text) = "" Then txtctab.Text = "--"
                    End If
                    gcuenta.Item("cta_con", i).Value = tb2.Rows(i).Item("codigo").ToString
                    gcuenta.Item("monto", i).Value = Moneda(tb2.Rows(i).Item("credito").ToString)
                    gcuenta.Item("cheque2", i).Value = tb2.Rows(i).Item("cheque").ToString
                    gcuenta.Item("banco", i).Value = BuscarBanco(tb2.Rows(i).Item("codigo").ToString)
                Next
            End If
        Catch ex As Exception
            MsgBox("buscando cuentas de bancos... " & ex.ToString)
        End Try
    End Sub
    Function BuscarBanco(ByVal cta As String)
        Dim cad As String = ""
        Try
            Dim tb2 As New DataTable
            myCommand.CommandText = "SELECT descripcion  FROM  selpuc where codigo= '" & cta & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb2)
            cad = tb2.Rows(0).Item(0)
        Catch ex As Exception

        End Try
        Return cad
    End Function
    Dim VBruto, Doccxp As String
    Dim ok = ""

    'Public Sub BuscarDoc(ByVal doc As String)
    '    Try
    '        'Bloquear()
    '        Dim tabla As New DataTable
    '        myCommand.CommandText = "SELECT o.*,d.* FROM ord_pagos o LEFT JOIN deta_ord d ON o.doc = d.doc WHERE o.doc='" & doc & "';"
    '        myAdapter.SelectCommand = myCommand
    '        myAdapter.Fill(tabla)
    '        'MsgBox(tabla.Rows.Count)
    '        If tabla.Rows.Count = 0 Then
    '            'CmdNuevo.Focus()
    '        Else

    '            'lbper2.Text = tabla.Rows(0).Item("per").ToString
    '            'txtorden.Text = NumeroDoc(Val(tabla.Rows(0).Item("num").ToString))
    '            'fecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
    '            'txtcontra.Text = tabla.Rows(0).Item("con_num").ToString
    '            'txtnit.Text = tabla.Rows(0).Item("con_ben").ToString
    '            'txtnombre.Text = tabla.Rows(0).Item("nomnit").ToString
    '            'txtdoc.Text = tabla.Rows(0).Item("sop_cont").ToString
    '            Try
    '                grilla.Rows.Clear()
    '            Catch ex As Exception

    '            End Try
    '            grilla.RowCount = tabla.Rows.Count
    '            If tabla.Rows.Count > 0 Then

    '                For i = 0 To tabla.Rows.Count - 1
    '                    Try
    '                        grilla.Item("cta", i).Value = tabla.Rows(i).Item("cta").ToString
    '                        grilla.Item("Descripcion", i).Value = tabla.Rows(i).Item("concep").ToString
    '                        grilla.Item("tipo", i).Value = tabla.Rows(i).Item("tipo").ToString
    '                        Try
    '                            grilla.Item("porc", i).Value = CDbl(tabla.Rows(i).Item("porc").ToString)
    '                        Catch ex As Exception
    '                            grilla.Item("porc", i).Value = "0"
    '                        End Try
    '                        Try
    '                            grilla.Item("Debitos", i).Value = Moneda(CDbl(tabla.Rows(i).Item("db").ToString))
    '                        Catch ex As Exception
    '                            grilla.Item("Debitos", i).Value = Moneda("0")
    '                        End Try
    '                        Try
    '                            grilla.Item("Creditos", i).Value = Moneda(CDbl(tabla.Rows(i).Item("cr").ToString))
    '                        Catch ex As Exception
    '                            grilla.Item("Creditos", i).Value = Moneda("0")
    '                        End Try
    '                    Catch ex As Exception
    '                        MsgBox("Error al buscar detalles " & ex.ToString)
    '                    End Try
    '                Next
    '            End If
    '        End If
    '        'CalcularTotales()
    '        'lbestado.Text = "CONSULTA"
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub
    Private Sub txtrubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrubro.TextChanged

        Dim cd_rb As String = ""
        Dim rb As String = ""
        Dim crb As String = ""
        Dim a As String = Strings.Mid(txtorden.Text, 4, 4)

        Dim cp() As String
        cp = txtrubro.Text.Split(Chr(Keys.Enter))

        For i = 0 To cp.Length - 1
            If i = 0 Then
                cd_rb = "'" & Trim(cp(i)) & "'"

            ElseIf Trim(cp(i)) <> "" Then
                cd_rb = Trim(cd_rb) & ",'" & Trim(cp(i)) & "'"
            End If
        Next

        cd_rb = cd_rb.Replace(Chr(10), "")

        'Try
        'txtrubro2.Text = ""
        If cd_rb <> "" Then
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT gasc_cod1,gasc_concepto FROM presupuesto" & a & ".gasconcepto WHERE gasc_cod1 IN(" & Trim(cd_rb) & ") ORDER BY " & Trim(cd_rb) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            rb = ""
            crb = ""
            If tabla.Rows.Count > 0 Then
                For j = 0 To tabla.Rows.Count - 1
                    rb = rb & tabla.Rows(j).Item("gasc_concepto").ToString & vbCrLf
                    crb = crb & tabla.Rows(j).Item("gasc_cod1").ToString & vbCrLf
                Next
            End If
            txtnomrubro.Text = rb
            txtrubro.Text = crb
        End If
        'Catch ex As Exception
        '    txtnomrubro.Text = ""
        'End Try
    End Sub

    Private Sub txtorden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtorden.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Try
                Dim tb As New DataTable
                tb.Clear()
                myCommand.CommandText = "SELECT * FROM ord_pagos where doc='" & txtorden.Text & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                Refresh()
                If tb.Rows.Count = 0 Then
                    Try
                        txtorden.Text = ""
                        FrmSelOndenPago.lbform.Text = "egre_ord"
                        FrmSelOndenPago.ShowDialog()
                        If txtorden.Text <> "" Then
                            BuscarOrden()
                        Else
                            'limpiar()
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    BuscarOrden()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtorden_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtorden.LostFocus
        Try
            If Trim(txtorden.Text) = "" Then
                FrmSelOndenPago.lbform.Text = "egre_ord"
                FrmSelOndenPago.ShowDialog()
                If txtorden.Text <> "" Then
                    BuscarOrden()
                End If
            Else
                Dim tb As New DataTable
                tb.Clear()
                myCommand.CommandText = "SELECT doc FROM ord_pagos where doc='" & txtorden.Text & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                'Refresh()
                If tb.Rows.Count = 0 Then
                    Try
                        txtorden.Text = ""
                        FrmSelOndenPago.lbform.Text = "egre_ord"
                        FrmSelOndenPago.ShowDialog()
                        If txtorden.Text <> "" Then
                            BuscarOrden()
                        Else
                            'limpiar()
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    BuscarOrden()
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        limpiar()

    End Sub
    Private Sub limpiar()
        txtorden.Text = ""
        txtcontra.Text = ""
        txtplazo.Text = ""
        txtdis.Text = ""
        txttipo.Text = ""
        txtdoc.Text = ""
        txtnit.Text = ""
        txtnombre.Text = ""
        txtconcep.Text = ""
        txtrubro.Text = ""
        txtnomrubro.Text = ""
        txttotal.Text = Moneda(0)
        txtce.Text = ""
        lbperiodo.Text = ""
        txtvig.Text = ""
        txtcta.Text = ""
        txtbanco.Text = ""
        txtcheque.Text = ""
        txtordenador.Text = ""
        txtcontador.Text = ""
        lbpesos.Text = ""
        grilla.Rows.Clear()
        fechace.Value = "01/" & PerActual(0) & PerActual(1) & "/" & Strings.Right(PerActual, 4)
        txtorden.Focus()

    End Sub

    Private Sub txtdoc_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc.TextAlignChanged

    End Sub


    Private Sub txtorden_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtorden.TextChanged
        If txtorden.Text = "" Then
            limpiar()
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If txtorden.Text <> "" And gce.Enabled = False Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El documento " & txtdoc.Text & " será Eliminado, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)

                Try
                    Dim tb As New DataTable
                    tb.Clear()
                    myCommand.CommandText = "SELECT * FROM ot_cpp" & Strings.Left(lbperiodo.Text, 2) & " where doc='" & lbtipodoc.Text & txtce.Text & "' AND doc_afec <> '';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tb)
                    Refresh()
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?valor", tb.Rows(0).Item("abonado"))
                    myCommand.Parameters.AddWithValue("?docaf", tb.Rows(0).Item("doc_afec"))
                    myCommand.CommandText = "UPDATE ctas_x_pagar   " _
                                 & "SET pagado= pagado - ?valor WHERE doc = ?docaf ;"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    myCommand.CommandText = "DELETE FROM ot_cpp" & Strings.Left(lbperiodo.Text, 2) & " " _
                            & "  WHERE doc='" & lbtipodoc.Text & txtce.Text & "' ;"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    myCommand.CommandText = "DELETE FROM documentos" & Strings.Left(lbperiodo.Text, 2) & " " _
                            & "  WHERE tipodoc='" & lbtipodoc.Text & "' AND doc='" & Val(txtce.Text) & "' ;"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    myCommand.CommandText = "UPDATE ord_pagos  " _
                                 & "SET estado='', sop_cont='' WHERE doc='" & txtorden.Text & "';"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                Cerrar()
                MsgBox("Egreso Eliminado", MsgBoxStyle.Information, "SAE")
            End If
        Else
            MsgBox("ACCION NO PERMITIDA")
        End If
    End Sub

    Private Sub txtcheque_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcheque.TextChanged
        Try
            grilla.Item("cheque", 0).Value = txtcheque.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtce_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtce.TextChanged

    End Sub

    Private Sub cmdpagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpagos.Click
        Try
            FemFPE2.txttotal.Text = txttotal.Text
            FemFPE2.gcuenta.RowCount = gcuenta.RowCount
            FemFPE2.gcuenta.Item("cta_con", 0).Value = txtcta.Text
            FemFPE2.gcuenta.Item("cheque", 0).Value = txtcheque.Text
            For i = 0 To gcuenta.RowCount - 1
                FemFPE2.gcuenta.Item("cta_con", i).Value = gcuenta.Item("cta_con", i).Value
                FemFPE2.gcuenta.Item("monto", i).Value = gcuenta.Item("monto", i).Value
                FemFPE2.gcuenta.Item("cheque", i).Value = gcuenta.Item("cheque2", i).Value
                BuscarCtas(gcuenta.Item("cta_con", i).Value, i)
            Next
            FemFPE2.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub BuscarCtas(ByVal cta As String, ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT b.*, s.descripcion FROM bancos b, selpuc s WHERE s.codigo= b.codigo AND b.codigo = '" & cta & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            FemFPE2.gcuenta.Item("codigo", f).Value = tabla.Rows(0).Item("cod_ban").ToString
            FemFPE2.gcuenta.Item("banco", f).Value = tabla.Rows(0).Item("descripcion").ToString
            FemFPE2.gcuenta.Item("cta", f).Value = tabla.Rows(0).Item("num_cta").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdpagos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdpagos.GotFocus
        'SendKeys.Send("{TAB}")
    End Sub

    Private Sub cmdpuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpuc.Click
        Try
            FrmCuentas.lbform.Text = "epuc"
            FrmCuentas.ShowDialog()
            txtcta_TextChanged(AcceptButton, AcceptButton)
            If txtctab.Text = "" Then
                txtctab.Text = "--"
                txtbanco.Text = lbbanco.Text
                grilla.Item("Cuenta", 0).Value = txtcta.Text
                gcuenta.Item("cta_con", 0).Value = txtcta.Text
            End If
            txtcheque.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'' ORDER BY sop_cont LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtorden.Text = tabla.Rows(0).Item(0)
                BuscarOrden()
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'' ORDER BY sop_cont LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <> 0 Then
                Refresh()
                txtorden.Text = tabla.Rows(0).Item(0)
                BuscarOrden()
                lbnroobs.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'' ORDER BY sop_cont LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtorden.Text = tabla.Rows(0).Item(0)
                BuscarOrden()
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' and sop_cont<>'' ORDER BY sop_cont LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtorden.Text = tabla.Rows(0).Item(0)
            BuscarOrden()
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub cmdMost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMost.Click
        Try
            FrmSelOrdenPagoDoc.ShowDialog()
            If txtorden.Text <> "" Then
                BuscarOrden()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class