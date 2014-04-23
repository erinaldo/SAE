Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmEst_Cuen_Inm

    Private Sub FrmEst_Cuen_Inm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtaño.Text = PerActual
        cbini.Text = Strings.Left(PerActual, 2)
        txtpini.Text = Strings.Right(PerActual, 5)
        Try
            txtdi1.Text = Strings.Left(DateSerial(Strings.Right(PerActual, 4), cbini.Text + 1, 0), 2)
        Catch ex As Exception
            txtdi1.Text = Now.Day
        End Try

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        If rb2.Checked = True Then
            txtcontr.Enabled = True
        Else
            txtcontr.Enabled = False
        End If
    End Sub
    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            txtcontr.Text = ""
            chG.Checked = False
            rb2_CheckedChanged(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click


        If rb2.Checked = True And Trim(txtcontr.Text) = "" Then
            MsgBox("Verifique el codigo del contrato", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        Dim rt As MsgBoxResult
       
        If rb2.Checked = True And chG.Checked = True Then
            rt = MsgBox("Ya este contrato tiene una cuenta de cobro en este periodo,¿Desea Generarle Otra?", MsgBoxStyle.YesNo, "Confirmacion")
            If rt = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        '......
        BuscarPeriodo()
        Dim ct As String = ""
        If rb2.Checked = True And Trim(txtcontr.Text) <> "" Then
            ct = "AND cod_contra='" & Trim(txtcontr.Text) & "' "
        End If

        Dim cnt As String = ""
        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        'myCommand.CommandText = "SELECT cod_contra FROM contrato_inm where periodo <> '" & PerActual & "' AND mes_total > mes_fact;"
        If chG.Checked = False Then
            myCommand.CommandText = "SELECT cod_contra FROM contrato_inm where CAST(LEFT(periodo,2) AS DECIMAL) < " & CInt(Strings.Left(PerActual, 2)) & " AND mes_total > mes_fact " & ct
        Else
            myCommand.CommandText = "SELECT cod_contra FROM contrato_inm where mes_total > mes_fact " & ct
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()

        If tc.Rows.Count = 0 Then
            MsgBox("Este proceso ya se realizo para los contratos seleccionados ", MsgBoxStyle.Information, "Informacion")
        Else
            cnt = "("
            For i = 0 To tc.Rows.Count - 1
                If i <> tc.Rows.Count - 1 Then
                    cnt = cnt & "'" & tc.Rows(i).Item(0) & "'" & ","
                Else
                    cnt = cnt & "'" & tc.Rows(i).Item(0) & "'" & ")"
                End If
            Next
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Se va a crear la cuenta de cobro, ¿Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                cuentaXcobrar(cnt)
                Cerrar()

            End If
        End If
    End Sub
    Function OtrosConceptos(ByVal tcli As String, ByVal contrato As String, ByVal ref As String, ByVal di As Integer)

        Dim taO As New DataTable
        taO.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM otcon_contrato WHERE tcli='" & tcli & "' AND codcon='" & contrato & "' AND contb<>'S' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(taO)
        Refresh()

        Dim vl As Double = 0
        Dim sal As Double = 0



        If taO.Rows.Count > 0 Then
            For i = 0 To taO.Rows.Count - 1
                If taO.Rows(i).Item("dia") = "SI" Then
                    vl = CDbl((taO.Rows(i).Item("valor") / 30) * di)
                Else
                    vl = CDbl(taO.Rows(i).Item("valor"))
                End If

                Dim tv As New DataTable
                tv.Clear()
                'myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT ROUND( REPLACE('" & vl & "',',','.') ,0) FROM contrato_inm limit 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tv)
                Refresh()
                vl = tv.Rows(0).Item(0)

                '//////////////////////////////////////////////////////////////////////
                If ref = "des" And taO.Rows(i).Item("tipo") = "-" Then
                    sal = sal - vl
                ElseIf ref = "sum" And taO.Rows(i).Item("tipo") = "+" Then
                    sal = sal + vl
                ElseIf ref = "" Then
                    Select Case taO.Rows(i).Item("tipo")
                        Case "+"
                            sal = sal + vl
                        Case "-"
                            sal = sal - vl
                    End Select
                End If
            Next
        End If

        Return sal

    End Function
    Private Sub cuentaXcobrar(ByVal cont As String)

        'Try
        Dim tab As New DataTable
        tab.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra IN " & cont & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tab)
        Refresh()

        Dim it As Integer = 0
        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = tab.Rows.Count
        it = 1

        For i = 0 To tab.Rows.Count - 1

            ''****************** PARAMETROS PARA FACTU **********************
            Dim num As String = ""
            Dim doc As String = ""
            Dim pref As String = ""
            Dim actual As Integer = 0
            Dim taf As New DataTable
            taf.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM  parcontrato ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(taf)
            Refresh()

            If taf.Rows.Count = 0 Then
                MsgBox("Usted no ha definido los parametros para Generar los Estados de Cuenta ", MsgBoxStyle.Exclamation, "Verifique")
                Exit Sub
            ElseIf taf.Rows(0).Item("parf") = "NO" And taf.Rows(0).Item("tipof1") = "" Then
                MsgBox("No ha definido el tipo de documento para Generar los Estados de Cuenta, Verifique en los Parametros ", MsgBoxStyle.Exclamation, "Verifique")
                Exit Sub
            Else

                If taf.Rows(0).Item("parf") = "NO" Then
                    ' //// PAR INMO
                    If taf.Rows(0).Item("hr1") = "NO" Then
                        '................. Sin Resolucion
                        doc = taf.Rows(0).Item("tipof1")
                        actual = taf.Rows(0).Item("a_f1")
                    Else
                        '................. Con Resolucion
                        If Val(taf.Rows(0).Item("a_f1")) > Val(taf.Rows(0).Item("fin1")) And Val(taf.Rows(0).Item("fin1")) > 0 Then
                            MsgBox("Has superado el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & taf.Rows(0).Item("reso1") & ", Limite=" & Val(taf.Rows(0).Item("fin1")), MsgBoxStyle.Critical, "SAE Resolución DIAN")
                            Exit Sub
                            mibarra.Visible = False
                        End If
                        If DateTime.Now.ToString("yyyy-MM-dd") > CDate(taf.Rows(0).Item("feclim1").ToString) Then
                            MsgBox("Ha superado la fecha limite para realizar facturas por computador permitidas por la RESOLUCIÓN DIAN " & taf.Rows(0).Item("reso1") & ", Fecha Limite=" & taf.Rows(0).Item("feclim1").ToString, MsgBoxStyle.Critical, "SAE Resolución DIAN")
                            Exit Sub
                            mibarra.Visible = False
                        End If
                        doc = taf.Rows(0).Item("tipof1")
                        actual = taf.Rows(0).Item("a_f1")
                        pref = taf.Rows(0).Item("pre1")
                    End If

                Else
                    ' //// PAR FAC
                    num = buscarconse(taf.Rows(0).Item("docf"))

                    Dim tpf As New DataTable
                    tpf.Clear()
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT a_f" & num & ",pre" & num & ", hr" & num & ", reso" & num & ", fecexp" & num & ", feclim" & num & ", ini" & num & ", fin" & num & " FROM  parafacgral ;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tpf)
                    Refresh()
                    If tpf.Rows.Count > 0 Then
                        If tpf.Rows(0).Item(2) = "NO" Then
                            doc = taf.Rows(0).Item("docf")
                            actual = tpf.Rows(0).Item(0)
                            pref = tpf.Rows(0).Item(1)
                        Else
                            '................. Con Resolucion
                            If Val(tpf.Rows(0).Item(0)) > Val(tpf.Rows(0).Item(7)) And Val(tpf.Rows(0).Item(7)) > 0 Then
                                MsgBox("Has superado el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & tpf.Rows(0).Item(3) & ", Limite=" & Val(tpf.Rows(0).Item(7)), MsgBoxStyle.Critical, "SAE Resolución DIAN")
                                Exit Sub
                                mibarra.Visible = False
                            End If
                            If DateTime.Now.ToString("yyyy-MM-dd") > CDate(tpf.Rows(0).Item(5).ToString) Then
                                MsgBox("Ha superado la fecha limite para realizar facturas por computador permitidas por la RESOLUCIÓN DIAN " & tpf.Rows(0).Item(3) & ", Fecha Limite=" & tpf.Rows(0).Item(5).ToString, MsgBoxStyle.Critical, "SAE Resolución DIAN")
                                Exit Sub
                                mibarra.Visible = False
                            End If
                            doc = taf.Rows(0).Item("docf")
                            actual = tpf.Rows(0).Item(0)
                            pref = tpf.Rows(0).Item(1)
                        End If
                    End If

                End If
                '*************************************************
                '***************************  ****************************
            End If

            Dim fd, fd2, fdf As Date
            ' fd = DateTime.Now.ToString("yyyy-MM-dd")
            Try
                fd = Strings.Right(txtpini.Text, 4) & "-" & cbini.Text & "-" & txtdi1.Text
                fdf = fd
            Catch ex As Exception
                fd = DateSerial(Strings.Right(txtpini.Text, 4), cbini.Text + 1, 0)
                fdf = fd
            End Try

            Dim fecha As Date
            fecha = DateAdd("m", tab.Rows(i).Item("mes_fact"), CDate(tab.Rows(i).Item("fechaini")))

            Dim nd As Integer = 0
            nd = DateDiff("d", fd, DateSerial(Year(fd), Month(fd) + 1, 0)) + CInt(tab.Rows(i).Item("vmto"))

            'DIAS ...
            Dim d As Integer = 0

            ''If tab.Rows(i).Item("periodo") = "" Then
            ''    fd = CDate(tab.Rows(i).Item("fechaF"))
            ''    'fd = DateAdd("d", tab.Rows(i).Item("dias"), CDate(tab.Rows(i).Item("fechaF")))
            ''    If fd <> DateSerial(Year(fd), Month(fd) + 0, 1) Then 'INICIO DEL CONTRATO <> primer dia mes
            ''        'd = DateDiff("d", fd, DateSerial(Year(fd), Month(fd) + 1, 0)) ' dife ultimo dia del mes
            ''        d = DateDiff("d", fd, DateSerial(Year(fd), Month(fd), 30)) ' dife ultimo dia del mes
            ''        If d = 0 Then
            ''            d = 1
            ''        End If
            ''    Else
            ''        d = 30
            ''    End If
            ''Else
            ''    If Int(tab.Rows(i).Item("mes_fact") + 1) = Int(tab.Rows(i).Item("mes_total")) Then
            ''        fd = CDate(tab.Rows(i).Item("fechafin"))
            ''        If fd <> DateSerial(Year(fd), Month(fd) + 1, 0) Then 'FINAL DEL CONTRATO <> ULTIMO DIA DEL MES
            ''            d = DateDiff("d", DateSerial(Year(fd), Month(fd) + 0, 1), fd) 'Primer dia del mes
            ''            'd = d + 1
            ''        End If
            ''    Else
            ''        d = 30
            ''    End If
            ''End If

            '//////****************************************************///////////////
            '//////****************************************************///////////////
            '//////****************************************************///////////////
            If Int(tab.Rows(i).Item("mes_fact") + 1) = Int(tab.Rows(i).Item("mes_total")) Then 'SI ES ULTIMA FACTURA
                If tab.Rows(i).Item("dias") = 0 Then ' PRIMERA FACTURA
                    fd = CDate(tab.Rows(i).Item("fechaF"))
                    fd2 = CDate(tab.Rows(i).Item("fechafin"))
                    'If fd <> DateSerial(Year(fd), Month(fd) + 0, 1) Then 'INICIO DEL CONTRATO <> primer dia mes
                    If fd <> DateSerial(Year(fd), Month(fd) + 0, 1) Then
                        d = DateDiff("d", fd, fd2) ' dife ultimo dia del mes
                        d = d + 1
                    Else
                        d = DateDiff("d", DateSerial(Year(fd2), Month(fd2) + 0, 1), fd2) 'Primer dia del mes
                        d = d + 1 'Calcula dias 
                        If d > 30 Then
                            d = 30
                        End If
                    End If
                Else
                    fd = CDate(tab.Rows(i).Item("fechafin"))
                    If fd <> DateSerial(Year(fd), Month(fd) + 1, 0) Then 'FINAL DEL CONTRATO <> ULTIMO DIA DEL MES
                        d = DateDiff("d", DateSerial(Year(fd), Month(fd) + 0, 1), fd) 'Primer dia del mes
                        d = d + 1 'Calcula dias 
                    Else
                        d = 30
                    End If
                End If
                    '*************
                    'fd = CDate(tab.Rows(i).Item("fechafin"))
                    'If fd <> DateSerial(Year(fd), Month(fd) + 1, 0) Then 'FINAL DEL CONTRATO <> ULTIMO DIA DEL MES
                    '    d = DateDiff("d", DateSerial(Year(fd), Month(fd) + 0, 1), fd) 'Primer dia del mes
                    '    d = d + 1 'Calcula dias 
                    'Else
                    '    d = 30
                    'End If
            Else 'NO ES LA ULTIMA FACTURA
                If tab.Rows(i).Item("dias") = 0 Then ' PRIMERA FACTURA
                    fd = CDate(tab.Rows(i).Item("fechaF"))
                    If fd <> DateSerial(Year(fd), Month(fd) + 0, 1) Then 'INICIO DEL CONTRATO <> primer dia mes
                        d = DateDiff("d", fd, DateSerial(Year(fd), Month(fd), 30)) ' dife ultimo dia del mes
                        d = d + 1
                    Else
                        d = 30
                    End If
                Else
                    d = 30
                End If
            End If


                'MsgBox(DateSerial(Year(fd), Month(fd) + 1, 0)) ' ultimo dia del mes
                Dim ulT As Integer = 0 ' Ultimo dia del mes
                ulT = Int(Strings.Left(DateSerial(Year(fd), Month(fd) + 1, 0), 2))

                Dim valor As Double = 0
            'If d <> 0 Or d <> 30 Then
            If d <> 30 Then
                valor = (tab.Rows(i).Item("valor") / 30) * d

                Dim tv As New DataTable
                tv.Clear()
                myCommand.Parameters.Clear()
                'myCommand.CommandText = "SELECT ROUND( REPLACE('" & valor & "',',','.') + 49,-2) FROM contrato_inm"
                myCommand.CommandText = "SELECT ROUND( REPLACE('" & valor & "',',','.') ,0) FROM contrato_inm limit 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tv)
                Refresh()
                valor = tv.Rows(0).Item(0)
            Else
                valor = tab.Rows(i).Item("valor")
            End If

            valor = valor + OtrosConceptos("ARRENDATARIO", tab.Rows(i).Item("cod_contra"), "des", d)

            Dim mas As Double = 0
            mas = OtrosConceptos("ARRENDATARIO", tab.Rows(i).Item("cod_contra"), "sum", d)


            Dim m As String = ""
            m = tmes(Strings.Mid(fecha, 4, 2)) & Strings.Right(fecha, 5)
            'myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", doc & NumeroDoc(actual + 1))
            myCommand.Parameters.AddWithValue("?tipo", doc)
            myCommand.Parameters.AddWithValue("?num", actual + 1)
            myCommand.Parameters.AddWithValue("?descrip", tab.Rows(i).Item("cod_contra"))
            myCommand.Parameters.AddWithValue("?tipafec", "CNT")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", tab.Rows(i).Item("nit_a"))
            myCommand.Parameters.AddWithValue("?nomnit", tab.Rows(i).Item("nomb_arr"))
            myCommand.Parameters.AddWithValue("?nitcod", tab.Rows(i).Item("nit_d"))
            myCommand.Parameters.AddWithValue("?nitv", tab.Rows(i).Item("nitv"))
            myCommand.Parameters.AddWithValue("?fecha", fdf)
            myCommand.Parameters.AddWithValue("?vmto", nd)
            myCommand.Parameters.AddWithValue("?concepto", "ARRIENDO MES " & m & " - INMUEBLE COD: " & tab.Rows(i).Item("cod_inm"))
            myCommand.Parameters.AddWithValue("?subtotal", valor - (valor * (tab.Rows(i).Item("por_iva") / 100)))
            myCommand.Parameters.AddWithValue("?descto", "0")
            myCommand.Parameters.AddWithValue("?ret", "0")
            myCommand.Parameters.AddWithValue("?iva", tab.Rows(i).Item("por_iva"))
            myCommand.Parameters.AddWithValue("?v_viva", (valor * (tab.Rows(i).Item("por_iva") / 100)))
            myCommand.Parameters.AddWithValue("?total", valor + mas)
            myCommand.Parameters.AddWithValue("?ctasubtotal", tab.Rows(i).Item("cta_valor"))
            myCommand.Parameters.AddWithValue("?ctaret", tab.Rows(i).Item("cta_rtf"))
            myCommand.Parameters.AddWithValue("?ctaiva", tab.Rows(i).Item("cta_iva"))
            myCommand.Parameters.AddWithValue("?ctatotal", tab.Rows(i).Item("cta_valor"))
            myCommand.Parameters.AddWithValue("?ccosto", tab.Rows(i).Item("cc"))
            myCommand.Parameters.AddWithValue("?otroimp", "N")
            myCommand.Parameters.AddWithValue("?retiva", "0")
            myCommand.Parameters.AddWithValue("?ctaretiva", "")
            myCommand.Parameters.AddWithValue("?retica", "0")
            myCommand.Parameters.AddWithValue("?ctaretica", "")
            myCommand.Parameters.AddWithValue("?pagado", "0")
            myCommand.Parameters.AddWithValue("?rcpos", NumeroDoc(actual + 1))
            myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
            myCommand.Parameters.AddWithValue("?vpos", "0")
            myCommand.Parameters.AddWithValue("?tasa", "0")
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", d)

            myCommand.CommandText = "Insert INTO cobdpen Values (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto,?concepto,?subtotal,?descto, " _
            & " ?ret,?iva,?v_viva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica,?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()


            '' OTROS CONCEPTOS DE FAC
            GuardOtcon("ARRENDATARIO", doc & NumeroDoc(actual + 1), tab.Rows(i).Item("cod_contra"), d)
            '' -------------------------------------
            ' '' CUENTAS X PAGAR
            cuentaXpagar(tab.Rows(i).Item("cod_contra"), actual, doc, m, pref, nd, valor, d)
            ' ''-------------------------------------------------------------------------
            ' ''ACTUALIZAR CONTRATOS
            actcontrato(tab.Rows(i).Item("cod_contra"), Val(Strings.Mid(fecha, 4, 2)), d)
            '' -------------------------------------------------------------------------
            ''CREAR DOC CONTABLE
            grilla.Rows.Clear()
            doc_cont(m, tab.Rows(i).Item("cod_contra"), doc, (actual + 1), valor, d)
            ''---------------------------------------------------------------------------
            ' '' GUARDAR FACTURA INMM
            guardarFac(doc, actual, tab.Rows(i).Item("cod_contra"), d, valor, m, nd)
            ''---------------------------------------------------------------------------
            ' '' ACTUALIZAR CONSECUTIVO FACTURACION
            Consecutivo(doc, taf.Rows(0).Item("parf"), actual, num)
            ''----------------------------------------------------------------------------
            mibarra.Value = mibarra.Value + it
        Next

        MsgBox("El proceso se realizo exitosamente", MsgBoxStyle.Information, "Datos Guardados")

        mibarra.Visible = False
        ' ..............  IMPRIMIR
        Dim rs As MsgBoxResult
        rs = MsgBox("Desea visualizar las facturas? ", MsgBoxStyle.YesNo, "Verificando")
        If rs = MsgBoxResult.Yes Then
            cmbprint_Click(AcceptButton, AcceptButton)
        Else
            Me.Close()
        End If

        'Catch ex As Exception
        '    MsgBox("Error  al crear la cuenta de cobro " & ex.ToString)
        '    mibarra.Visible = False
        'End Try
    End Sub
    Private Sub guardarFac(ByVal doc As String, ByVal actual As Integer, ByVal cont As String, ByVal d As Integer, ByVal valor As Double, ByVal m As String, ByVal nd As Integer)

        Try
            Dim iva As Double = 0
            Dim com As Double = 0
            Dim rtf As Double = 0
            Dim rtc As Double = 0
            Dim tt As Double = 0

            Dim tf As New DataTable
            tf.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT c.*, trim(concat(t.apellidos,' ',t.nombre)) as nomdue  FROM contrato_inm c, terceros t where cod_contra = '" & cont & "' and c.nit_d = t.nit ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            Refresh()

            iva = (valor * (tf.Rows(0).Item("por_comi") / 100)) * (tf.Rows(0).Item("por_iva") / 100)
            com = valor * (tf.Rows(0).Item("por_comi") / 100)
            tt = valor - iva - com

            Dim masP As Double = 0
            Dim masA As Double = 0
            masP = OtrosConceptos("PROPIETARIO", tf.Rows(0).Item("cod_contra"), "", d)
            tt = tt + masP
            masA = OtrosConceptos("ARRENDATARIO", tf.Rows(0).Item("cod_contra"), "sum", d)

            myCommand.Parameters.AddWithValue("?doc", doc & NumeroDoc(actual + 1))
            myCommand.Parameters.AddWithValue("?tipo", doc)
            myCommand.Parameters.AddWithValue("?num", actual + 1)
            myCommand.Parameters.AddWithValue("?fecha", CDate(PerActual & "/" & txtdi1.Text))
            myCommand.Parameters.AddWithValue("?codcontrato", cont)
            myCommand.Parameters.AddWithValue("?codinm", tf.Rows(0).Item("cod_inm"))
            myCommand.Parameters.AddWithValue("?nita", tf.Rows(0).Item("nit_a"))
            myCommand.Parameters.AddWithValue("?noma", tf.Rows(0).Item("nomb_arr"))
            myCommand.Parameters.AddWithValue("?nitp", tf.Rows(0).Item("nit_d"))
            myCommand.Parameters.AddWithValue("?nomp", tf.Rows(0).Item("nomdue"))
            myCommand.Parameters.AddWithValue("?dias", d)
            myCommand.Parameters.AddWithValue("?valor", valor)
            myCommand.Parameters.AddWithValue("?totalp", tt)
            myCommand.Parameters.AddWithValue("?otrosp", masP)
            myCommand.Parameters.AddWithValue("?totala", valor + masA)
            myCommand.Parameters.AddWithValue("?otrosa", masA)
            myCommand.Parameters.AddWithValue("?por_comi", tf.Rows(0).Item("por_comi"))
            myCommand.Parameters.AddWithValue("?vcomi", com)
            myCommand.Parameters.AddWithValue("?por_iva", tf.Rows(0).Item("por_iva"))
            myCommand.Parameters.AddWithValue("?viva", iva)
            myCommand.Parameters.AddWithValue("?descripcion", "ARRIENDO MES " & m & " - INMUEBLE COD: " & tf.Rows(0).Item("cod_inm"))
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.Parameters.AddWithValue("?doc_anul", "")
            myCommand.Parameters.AddWithValue("?vmto", nd)

            myCommand.CommandText = "Insert INTO facturainm" & Strings.Left(PerActual, 2) & "  Values (?doc,?num,?tipo,?fecha,?codcontrato,?codinm,?nita,?noma, " _
         & " ?nitp,?nomp,?dias,?valor,?totalp,?otrosp,?totala,?otrosa,?por_comi,?vcomi,?por_iva,?viva,?descripcion,?estado,?doc_anul,?vmto);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
        Catch ex As Exception
            MsgBox("Error al guardar la factura " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

    End Sub
    Private Sub GuardOtcon(ByVal tipo As String, ByVal nfac As String, ByVal contrato As String, ByVal dia As Integer)

        Dim tgo As New DataTable
        tgo.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM otcon_contrato WHERE tcli='" & tipo & "' AND codcon='" & contrato & "' AND contb<>'S' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tgo)
        Refresh()


        Dim vl As Double = 0
        Dim sal As Double = 0
        If tgo.Rows.Count > 0 Then
            For j = 0 To tgo.Rows.Count - 1
                If tgo.Rows(j).Item("dia") = "SI" Then
                    vl = CDbl((tgo.Rows(j).Item("valor") / 30) * dia)
                Else
                    vl = CDbl(tgo.Rows(j).Item("valor"))
                End If

                Dim tvl As New DataTable
                tvl.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT ROUND( REPLACE('" & vl & "',',','.') ,0) FROM contrato_inm limit 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tvl)
                Refresh()
                vl = tvl.Rows(0).Item(0)

                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc", nfac)
                myCommand.Parameters.AddWithValue("?itm", j + 1)
                myCommand.Parameters.AddWithValue("?sg", tgo.Rows(j).Item("tipo"))
                myCommand.Parameters.AddWithValue("?des", CambiaCadena(tgo.Rows(j).Item("descr"), 99))
                myCommand.Parameters.AddWithValue("?v", DIN(vl))
                myCommand.Parameters.AddWithValue("?b", DIN(Moneda(tgo.Rows(j).Item("base"))))
                myCommand.Parameters.AddWithValue("?cta", tgo.Rows(j).Item("cta"))
                myCommand.Parameters.AddWithValue("?docAn", "")
                If tipo = "ARRENDATARIO" Then
                    myCommand.CommandText = "INSERT INTO otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                    & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                    myCommand.ExecuteNonQuery()
                ElseIf tipo = "PROPIETARIO" Then
                    myCommand.CommandText = "INSERT INTO otcon_comp" & PerActual(0) & PerActual(1) & " " _
                                    & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                    myCommand.ExecuteNonQuery()
                End If
            Next
        End If

    End Sub
    Private Sub cuentaXpagar(ByVal cont As String, ByVal actual As Integer, ByVal doc As String, ByVal m As String, ByVal pref As String, ByVal nd As Integer, ByVal valor As Double, ByVal dia As String)

        Dim iva As Double = 0
        Dim com As Double = 0
        Dim rtf As Double = 0
        Dim rtc As Double = 0
        Dim tt As Double = 0


        Dim tabc As New DataTable
        tabc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT c.*, trim(concat(t.apellidos,' ',t.nombre)) as nomdue  FROM contrato_inm c, terceros t where cod_contra = '" & cont & "' and c.nit_d = t.nit ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabc)
        Refresh()



        iva = (valor * (tabc.Rows(0).Item("por_comi") / 100)) * (tabc.Rows(0).Item("por_iva") / 100)
        com = valor * (tabc.Rows(0).Item("por_comi") / 100)
        rtf = (valor - com - iva) * (tabc.Rows(0).Item("rtf") / 100)
        rtc = (valor - com - iva) * (tabc.Rows(0).Item("rtc") / 100)
        tt = valor - iva - com - rtf - rtc

        Dim mas As Double = 0
        mas = OtrosConceptos("PROPIETARIO", tabc.Rows(0).Item("cod_contra"), "", dia)
        tt = tt + mas
        '.... Valor
        'Dim tv As New DataTable
        'tv.Clear()
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = "SELECT ROUND( REPLACE('" & tt & "',',','.') + 49,-2) FROM contrato_inm"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tv)
        'tt = tv.Rows(0).Item(0)

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", doc & NumeroDoc(actual + 1))
        myCommand.Parameters.AddWithValue("?tipo", doc)
        myCommand.Parameters.AddWithValue("?num", actual + 1)
        myCommand.Parameters.AddWithValue("?descrip", tabc.Rows(0).Item("cod_contra"))
        myCommand.Parameters.AddWithValue("?tipafec", "CNT")
        myCommand.Parameters.AddWithValue("?clasaju", "")
        myCommand.Parameters.AddWithValue("?nitc", tabc.Rows(0).Item("nit_d"))
        myCommand.Parameters.AddWithValue("?nomnit", tabc.Rows(0).Item("nomdue"))
        myCommand.Parameters.AddWithValue("?nitcod", tabc.Rows(0).Item("nit_d"))
        'Try
        myCommand.Parameters.AddWithValue("?fecha", CDate(PerActual & "/" & txtdi1.Text))
        'myCommand.Parameters.AddWithValue("?fecha", CDate(Strings.Right(PerActual, 4) & "-" & Strings.Left(PerActual, 2) & "-" & Now.Day))
        'Catch ex As Exception
        '' myCommand.Parameters.AddWithValue("?fecha", CDate(Now.Day & "/" & PerActual))
        'Try
        '    myCommand.Parameters.AddWithValue("?fecha", CDate(Strings.Right(PerActual, 4) & "-" & Strings.Left(PerActual, 2) & "-" & Now.Day))
        'Catch ex1 As Exception
        '    myCommand.Parameters.AddWithValue("?fecha", Strings.Right(PerActual, 4) & Strings.Left(PerActual, 2) & Now.Day)
        'End Try

        'End Try

        myCommand.Parameters.AddWithValue("?vmto", nd)
        myCommand.Parameters.AddWithValue("?concepto", "ARRIENDO MES " & m & " - INMUEBLE COD: " & tabc.Rows(0).Item("cod_inm"))
        'myCommand.Parameters.AddWithValue("?subtotal", valor - iva - com - rtf - rtc)
        myCommand.Parameters.AddWithValue("?subtotal", tt)
        myCommand.Parameters.AddWithValue("?descto", com)
        myCommand.Parameters.AddWithValue("?ret", rtf)
        myCommand.Parameters.AddWithValue("?iva", DIN(tabc.Rows(0).Item("por_comi")))
        myCommand.Parameters.AddWithValue("?v_viva", iva)
        'myCommand.Parameters.AddWithValue("?total", valor - iva - com - rtf - rtc)
        myCommand.Parameters.AddWithValue("?total", tt)
        myCommand.Parameters.AddWithValue("?ctasubtotal", tabc.Rows(0).Item("cta_valor"))
        myCommand.Parameters.AddWithValue("?ctaret", tabc.Rows(0).Item("cta_rtf"))
        myCommand.Parameters.AddWithValue("?ctaiva", tabc.Rows(0).Item("cta_iva"))
        myCommand.Parameters.AddWithValue("?ctatotal", tabc.Rows(0).Item("cta_cli"))
        myCommand.Parameters.AddWithValue("?ccosto", tabc.Rows(0).Item("cc"))
        myCommand.Parameters.AddWithValue("?otroimp", "N")
        myCommand.Parameters.AddWithValue("?retiva", mas) ' Total otrosconceptos
        myCommand.Parameters.AddWithValue("?ctaretiva", "")
        myCommand.Parameters.AddWithValue("?retica", "0")
        myCommand.Parameters.AddWithValue("?ctaretica", "")
        myCommand.Parameters.AddWithValue("?pagado", "0")
        myCommand.Parameters.AddWithValue("?rcpos", NumeroDoc(actual + 1))
        myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
        myCommand.Parameters.AddWithValue("?vpos", "0")
        myCommand.Parameters.AddWithValue("?tasa", "0")
        myCommand.Parameters.AddWithValue("?moneda", "")
        myCommand.Parameters.AddWithValue("?monloex", "L")
        myCommand.Parameters.AddWithValue("?estado", "AP")
        myCommand.Parameters.AddWithValue("?salmov", "")
        myCommand.Parameters.AddWithValue("?pagare", dia)

        myCommand.CommandText = "Insert INTO ctas_x_pagar  Values (?doc,?tipo,?num,'',?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?fecha,?vmto,?concepto,?subtotal,?descto, " _
        & " ?ret,?iva,?v_viva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica,?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()

        '' OTROS CONCEPTOS DE FAC
        GuardOtcon("PROPIETARIO", doc & NumeroDoc(actual + 1), tabc.Rows(0).Item("cod_contra"), dia)

    End Sub
    Function buscarconse(ByVal doc As String)

        Dim cons As String = ""

        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT CASE '" & doc & "' " _
         & " WHEN tipof4 THEN '4' " _
         & " WHEN tipof3 THEN '3' " _
         & " WHEN tipof2 THEN '2'  " _
         & " WHEN tipof1 THEN '1' " _
         & " END AS num FROM parafacgral; "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            cons = tabla.Rows(0).Item(0)
        End If
        Return cons
    End Function
    Private Sub Consecutivo(ByVal tipo As String, ByVal parf As String, ByVal num As Integer, ByVal n As String)

        If parf = "NO" Then
            myCommand.CommandText = "UPDATE parcontrato SET a_f1 = " & Val(num + 1) & ";"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(num + 1) & " WHERE tipodoc='" & tipo & "';"
            myCommand.ExecuteNonQuery()
        Else
            myCommand.CommandText = "UPDATE parafacgral SET a_f" & n & " = " & Val(num + 1) & ";"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(num + 1) & " WHERE tipodoc='" & tipo & "';"
            myCommand.ExecuteNonQuery()
        End If


    End Sub
   
    Private Sub actcontrato(ByVal cont As String, ByVal msAc As Integer, ByVal dias As Integer)
        Try
            Dim tab As New DataTable
            tab.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra = '" & cont & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tab)
            Refresh()

            If tab.Rows(0).Item("mes_total") = (tab.Rows(0).Item("mes_fact") + 1) Then
                ' If tab.Rows(0).Item("mes_total") = (tab.Rows(0).Item("mes_act") + 1) Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE inmuebles SET estado='DISPONIBLE' WHERE codigo='" & tab.Rows(0).Item("cod_inm") & "';"
                myCommand.ExecuteNonQuery()
                Refresh()
            End If

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?mes_fact", tab.Rows(0).Item("mes_fact") + 1)
            myCommand.Parameters.AddWithValue("?mes_act", msAc + 1)
            myCommand.Parameters.AddWithValue("?dias", dias)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.CommandText = "UPDATE contrato_inm SET  mes_fact=?mes_fact, mes_act=?mes_act, periodo=?periodo, dias=?dias WHERE cod_contra='" & cont & "';"
            myCommand.ExecuteNonQuery()
            ' MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
        Catch ex As Exception
            MsgBox("Error  al actualizar el contrato " & ex.ToString)
        End Try

    End Sub

    Private Sub doc_cont(ByVal m As String, ByVal cont As String, ByVal doc As String, ByVal ndoc As Integer, ByVal valor As Double, ByVal dia As Integer)

        Dim sum As Double
        Dim iva As Double = 0
        Dim com As Double = 0
        Dim rtf As Double = 0
        Dim rtc As Double = 0

        Dim td As New DataTable
        td.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra = '" & cont & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        Refresh()

        sum = 0
        grilla.Rows.Clear()
        grilla.RowCount = 6

        iva = ((valor * (td.Rows(0).Item("por_comi") / 100)) * (td.Rows(0).Item("por_iva") / 100))
        com = valor * (td.Rows(0).Item("por_comi") / 100)
        rtf = (valor - com - iva) * (td.Rows(0).Item("rtf") / 100)
        rtc = (valor - com - iva) * (td.Rows(0).Item("rtc") / 100)

        'sum = sum + (valor * (td.Rows(0).Item("por_comi") / 100))
        'sum = sum + (valor - (valor * (td.Rows(0).Item("por_comi") / 100)) - ((valor * (td.Rows(0).Item("por_comi") / 100)) * (td.Rows(0).Item("por_iva") / 100)))

        '----------- ARRIENDO
        grilla.Item("Descripcion", 0).Value = "ARRIENDO MES " & m
        grilla.Item(1, 0).Value = Moneda(valor)
        'grilla.Item(2, 1).Value = Moneda(valor - (valor * (td.Rows(0).Item("por_comi") / 100)) - ((valor * (td.Rows(0).Item("por_comi") / 100)) * (td.Rows(0).Item("por_iva") / 100)))
        grilla.Item(2, 0).Value = Moneda(0)
        grilla.Item(3, 0).Value = td.Rows(0).Item("cta_valor")
        grilla.Item(4, 0).Value = Moneda(0)
        grilla.Item(5, 0).Value = ""
        grilla.Item(6, 0).Value = td.Rows(0).Item("nit_a")
        grilla.Item(7, 0).Value = td.Rows(0).Item("cc")

        '------------IVA
        grilla.Item("Descripcion", 1).Value = "IVA " & td.Rows(0).Item("por_iva") & "%"
        grilla.Item(1, 1).Value = Moneda(0)
        'grilla.Item(2, 1).Value = Moneda((valor * (td.Rows(0).Item("por_comi") / 100)) * (td.Rows(0).Item("por_iva") / 100))
        grilla.Item(2, 1).Value = Moneda(iva)
        grilla.Item(3, 1).Value = td.Rows(0).Item("cta_iva")
        grilla.Item(4, 1).Value = Moneda(valor * (td.Rows(0).Item("por_comi") / 100))
        grilla.Item(5, 1).Value = ""
        grilla.Item(6, 1).Value = td.Rows(0).Item("nit_d")
        grilla.Item(7, 1).Value = td.Rows(0).Item("cc")

        '-------------- COMISION
        grilla.Item("Descripcion", 2).Value = "COMISION " & td.Rows(0).Item("por_comi") & "%"
        grilla.Item(1, 2).Value = Moneda(0)
        'grilla.Item(2, 2).Value = Moneda((valor * (td.Rows(0).Item("por_comi") / 100)) - (valor * (td.Rows(0).Item("por_comi") / 100)) * (td.Rows(0).Item("por_iva") / 100))
        grilla.Item(2, 2).Value = Moneda(com)
        grilla.Item(3, 2).Value = td.Rows(0).Item("cta_cms")
        grilla.Item(4, 2).Value = Moneda(0)
        grilla.Item(5, 2).Value = ""
        grilla.Item(6, 2).Value = td.Rows(0).Item("nit_d")
        grilla.Item(7, 2).Value = td.Rows(0).Item("cc")

        '------------RETEFUENTE
        grilla.Item("Descripcion", 3).Value = "RETEFUENTE " & td.Rows(0).Item("rtf") & "%"
        grilla.Item(1, 3).Value = Moneda(0)
        'grilla.Item(2, 3).Value = Moneda((valor - (valor * (td.Rows(0).Item("por_comi") / 100))) * (td.Rows(0).Item("rtf") / 100))
        grilla.Item(2, 3).Value = Moneda(rtf)
        grilla.Item(3, 3).Value = td.Rows(0).Item("cta_rtf")
        grilla.Item(4, 3).Value = Moneda((valor - com - iva))
        grilla.Item(5, 3).Value = ""
        grilla.Item(6, 3).Value = td.Rows(0).Item("nit_d")
        grilla.Item(7, 3).Value = td.Rows(0).Item("cc")


        '------------CTAPAGAR
        grilla.Item("Descripcion", 4).Value = "PROPIETARIO "
        grilla.Item(1, 4).Value = Moneda(0)
        ' grilla.Item(2, 4).Value = Moneda((valor - (valor * (td.Rows(0).Item("por_comi") / 100))) - ((valor - (valor * (td.Rows(0).Item("por_comi") / 100))) * (td.Rows(0).Item("rtf") / 100)))
        grilla.Item(2, 4).Value = Moneda(valor - com - iva - rtf - rtc)
        grilla.Item(3, 4).Value = td.Rows(0).Item("cta_cli")
        grilla.Item(4, 4).Value = Moneda(0)
        grilla.Item(5, 4).Value = ""
        grilla.Item(6, 4).Value = td.Rows(0).Item("nit_d")
        grilla.Item(7, 4).Value = td.Rows(0).Item("cc")

        '------------RETECREE
        grilla.Item("Descripcion", 5).Value = "RETECREE " & td.Rows(0).Item("rtc") & "%"
        grilla.Item(1, 5).Value = Moneda(0)
        'grilla.Item(2, 3).Value = Moneda((valor - (valor * (td.Rows(0).Item("por_comi") / 100))) * (td.Rows(0).Item("rtf") / 100))
        grilla.Item(2, 5).Value = Moneda(rtc)
        grilla.Item(3, 5).Value = td.Rows(0).Item("cta_rtc")
        grilla.Item(4, 5).Value = Moneda((valor - com - iva))
        grilla.Item(5, 5).Value = ""
        grilla.Item(6, 5).Value = td.Rows(0).Item("nit_d")
        grilla.Item(7, 5).Value = td.Rows(0).Item("cc")


        ''/////////////////////////////////

        '-------------- OTROS CONCEPTOS
        Dim taO As New DataTable
        taO.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM otcon_contrato WHERE codcon='" & cont & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(taO)
        Refresh()


        Dim sal As Double = 0
        Dim vl As Double = 0
        If taO.Rows.Count > 0 Then
            grilla.RowCount = grilla.RowCount + taO.Rows.Count + 1
            For i = 0 To taO.Rows.Count - 1
                '////// dias

                If taO.Rows(i).Item("dia") = "SI" Then
                    vl = CDbl((taO.Rows(i).Item("valor") / 30) * dia)
                Else
                    vl = CDbl(taO.Rows(i).Item("valor"))
                End If
                Dim tv As New DataTable
                tv.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT ROUND( REPLACE('" & vl & "',',','.') ,0) FROM contrato_inm limit 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tv)
                Refresh()
                vl = tv.Rows(0).Item(0)
                '--------------
                '........_______
                If taO.Rows(i).Item("tcli") = "ARRENDATARIO" Then
                    If taO.Rows(i).Item("tipo") = "+" Then
                        If taO.Rows(i).Item("contb") = "N" Then ' solo fact, suma VALOR TOTAL
                            If CDbl(taO.Rows(i).Item("valor")) > 0 Then ' solo valores positivos
                                grilla.Item(1, 0).Value = Moneda(CDbl(grilla.Item(1, 0).Value) + vl)
                            Else
                                grilla.Item(1, 0).Value = Moneda(CDbl(grilla.Item(1, 0).Value) + vl)
                                grilla.Item(2, 4).Value = Moneda(CDbl(grilla.Item(2, 4).Value) + vl)
                            End If
                        Else
                            grilla.Item("Descripcion", 6 + i).Value = taO.Rows(i).Item("descr")
                            grilla.Item(1, 6 + i).Value = Moneda(vl)
                            grilla.Item(2, 6 + i).Value = Moneda(0)
                            grilla.Item(3, 6 + i).Value = taO.Rows(i).Item("cta")
                            grilla.Item(4, 6 + i).Value = Moneda(taO.Rows(i).Item("base"))
                            grilla.Item(5, 6 + i).Value = ""
                            grilla.Item(6, 6 + i).Value = taO.Rows(i).Item("nitc")
                            grilla.Item(7, 6 + i).Value = td.Rows(0).Item("cc")
                        End If

                    ElseIf taO.Rows(i).Item("tipo") = "-" Then
                        If taO.Rows(i).Item("contb") = "S" Then
                            '...Nuevo Concepto
                            grilla.Item("Descripcion", 6 + i).Value = taO.Rows(i).Item("descr")
                            grilla.Item(1, 6 + i).Value = Moneda(0)
                            grilla.Item(2, 6 + i).Value = Moneda(vl)
                            grilla.Item(3, 6 + i).Value = taO.Rows(i).Item("cta")
                            grilla.Item(4, 6 + i).Value = Moneda(taO.Rows(i).Item("base"))
                            grilla.Item(5, 6 + i).Value = ""
                            grilla.Item(6, 6 + i).Value = taO.Rows(i).Item("nitc")
                            grilla.Item(7, 6 + i).Value = td.Rows(0).Item("cc")
                        End If
                    End If
                ElseIf taO.Rows(i).Item("tcli") = "PROPIETARIO" Then
                  
                    If taO.Rows(i).Item("tipo") = "+" Then
                        If taO.Rows(i).Item("contb") = "N" Then
                            grilla.Item(2, 4).Value = Moneda(CDbl(grilla.Item(2, 4).Value) + vl)
                        Else
                            grilla.Item("Descripcion", 6 + i).Value = taO.Rows(i).Item("descr")
                            'grilla.Item(1, 6 + i).Value = Moneda(taO.Rows(i).Item("valor"))
                            grilla.Item(1, 6 + i).Value = Moneda(vl)
                            grilla.Item(2, 6 + i).Value = Moneda(0)
                            grilla.Item(3, 6 + i).Value = taO.Rows(i).Item("cta")
                            grilla.Item(4, 6 + i).Value = Moneda(taO.Rows(i).Item("base"))
                            grilla.Item(5, 6 + i).Value = ""
                            grilla.Item(6, 6 + i).Value = taO.Rows(i).Item("nitc")
                            grilla.Item(7, 6 + i).Value = td.Rows(0).Item("cc")
                        End If
                    ElseIf taO.Rows(i).Item("tipo") = "-" Then
                        If taO.Rows(i).Item("contb") = "N" Or taO.Rows(i).Item("contb") = "D" Then
                            grilla.Item(2, 4).Value = Moneda(CDbl(grilla.Item(2, 4).Value) - vl)
                        End If
                        '...Nuevo Concepto
                        grilla.Item("Descripcion", 6 + i).Value = taO.Rows(i).Item("descr")
                        grilla.Item(1, 6 + i).Value = Moneda(0)
                        grilla.Item(2, 6 + i).Value = Moneda(vl)
                        grilla.Item(3, 6 + i).Value = taO.Rows(i).Item("cta")
                        grilla.Item(4, 6 + i).Value = Moneda(taO.Rows(i).Item("base"))
                        grilla.Item(5, 6 + i).Value = ""
                        grilla.Item(6, 6 + i).Value = taO.Rows(i).Item("nitc")
                        grilla.Item(7, 6 + i).Value = td.Rows(0).Item("cc")
                    End If
                End If
            Next
        End If

        Dim cad As String = ""
        Dim db As String = ""
        Dim cr As String = ""

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
                    InsertContabilidad(i, doc, ndoc, td.Rows(0).Item("vmto"))
                    ' MsgBox("Insertar " & i & grilla.Item("descripcion", i).Value.ToString)
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal doc As String, ByVal ndoc As Integer, ByVal vmto As Integer)

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", ndoc)
            myCommand.Parameters.AddWithValue("?tipodoc", doc)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdi1.Text)
            myCommand.Parameters.AddWithValue("?centro", grilla.Item("cc", fila).Value)
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(Moneda(grilla.Item("Debitos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(Moneda(grilla.Item("Creditos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(Moneda(grilla.Item("base", fila).Value)))
            myCommand.Parameters.AddWithValue("?diasv", Val(vmto))
            If Val(vmto) > 0 Then
                Dim fec As Date = DateAdd("d", Val(vmto), DateTime.Now.ToString("yyyy-MM-dd"))
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            '  Try
            myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
            myCommand.Parameters.AddWithValue("?cheque", "")

            myCommand.Parameters.AddWithValue("?modulo", "inmobiliaria")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos" & Strings.Left(PerActual, 2) & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error Insertar Contable" & ex.ToString)
        End Try
    End Sub
    Function tmes(ByVal txt As String)
        'Dim n As Integer = 0


        'n = CInt(txt)

        'If n <> 1 Then
        '    n = n - 1
        'End If

        Dim ms As String = ""
        If txt = "01" Then
            ms = "ENERO"
        ElseIf txt = "02" Then
            ms = "FEBRERO"
        ElseIf txt = "03" Then
            ms = "MARZO"
        ElseIf txt = "04" Then
            ms = "ABRIL"
        ElseIf txt = "05" Then
            ms = "MAYO"
        ElseIf txt = "06" Then
            ms = "JUNIO"
        ElseIf txt = "07" Then
            ms = "JULIO"
        ElseIf txt = "08" Then
            ms = "AGOSTO"
        ElseIf txt = "09" Then
            ms = "SEPTIEMBRE"
        ElseIf txt = "10" Then
            ms = "OCTUBRE"
        ElseIf txt = "11" Then
            ms = "NOVIEMBRE"
        ElseIf txt = "12" Then
            ms = "DICIEMBRE"
        End If

        'If n = 1 Then
        '    ms = "ENERO"
        'ElseIf n = 2 Then
        '    ms = "FEBRERO"
        'ElseIf n = 3 Then
        '    ms = "MARZO"
        'ElseIf n = 4 Then
        '    ms = "ABRIL"
        'ElseIf n = 5 Then
        '    ms = "MAYO"
        'ElseIf n = 6 Then
        '    ms = "JUNIO"
        'ElseIf n = 7 Then
        '    ms = "JULIO"
        'ElseIf n = 8 Then
        '    ms = "AGOSTO"
        'ElseIf n = 9 Then
        '    ms = "SEPTIEMBRE"
        'ElseIf n = 10 Then
        '    ms = "OCTUBRE"
        'ElseIf n = 11 Then
        '    ms = "NOVIEMBRE"
        'ElseIf n = 12 Then
        '    ms = "DICIEMBRE"
        'End If

        Return (ms)
    End Function

    Private Sub cmbprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprint.Click
        Dim imp As String = ""
        Dim tc As New DataTable
        myCommand.Parameters.Clear()

        If rb1.Checked = True Then
            myCommand.CommandText = "SELECT * FROM contrato_inm where mes_fact<>0;"
            imp = "TODOS"
        Else
            If txtcontr.Text = "" Then
                MsgBox("Digite el codigo del contrato", MsgBoxStyle.Information, "verifique")
                Exit Sub
            Else
                myCommand.CommandText = "SELECT * FROM contrato_inm where mes_fact <> 0 AND cod_contra='" & txtcontr.Text & "';"
                imp = "UNO"
            End If
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()



        If tc.Rows.Count = 0 Then
            MsgBox("No existen facturas para Visualizar ", MsgBoxStyle.Information, "Informacion")
            mibarra.Visible = False
        Else
            If imp = "UNO" Then
                'PDF(txtcontr.Text)
                pdf2(txtcontr.Text)
            Else
                'PDF("")
                pdf2("")
            End If
        End If

    End Sub
    Private Sub pdf2(ByVal ct As String)

        MiConexion(bda)
        Cerrar()

        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim dir As String = ""
        Dim tcomp As String = ""
        Dim reso As String = ""
        Dim comt As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim sql4 As String = ""
        Dim sql5 As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        dir = tabla2.Rows(0).Item("direccion")
        tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")

        Try
            Dim tabl As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabl)
            tcomp = tabl.Rows(0).Item(0)
        Catch ex As Exception
        End Try


        Dim tap As New DataTable
        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT IFNULL(comentario,'')as com  from parcontrato ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        If tap.Rows.Count > 0 Then
            comt = tap.Rows(0).Item(0)
        End If



        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        If ct <> "" Then
            ct = "AND ci.cod_contra= '" & ct & "' "
        End If
        ' PPAL
        sql = " SELECT  ci.cod_contra AS doc, CONCAT(c.nitc, ' ', c.nomnit) AS nomnit,  t.dir AS ctaretica, " _
         & " CAST(CONCAT( RIGHT(c.fecha, 2), '/', MID(c.fecha, 6, 2), '/',LEFT(c.fecha, 4) ) AS CHAR(20)) AS ctaret,  " _
          & "CAST(CONCAT(RIGHT(ADDDATE(c.fecha, INTERVAL c.vmto DAY), 2),'/', MID( ADDDATE(c.fecha, INTERVAL c.vmto DAY),6, 2), '/',LEFT(ADDDATE(c.fecha, INTERVAL c.vmto DAY), 4)) AS CHAR(20)) AS ctaiva,   " _
          & "MID(concepto, 13, LENGTH(concepto))  AS pagare,   " _
         & "rcpos  AS ctaretiva,  " _
         & "(c.total) AS subtotal, " _
          & "i.codigo AS ctasubtotal,   c.rcpos,   c.pagare AS num, ci.valor AS retica,  " _
         & "UCASE(CONCAT(i.direccion,' ',(SELECT CONCAT(m.descripcion,' - ', d.descripcion)  " _
         & "FROM sae.mun m, sae.dptos d WHERE m.codmun= i.ciudad AND d.codigo=i.dpto)))AS concepto   " _
         & "FROM cobdpen c, contrato_inm ci,inmuebles i, terceros t   " _
         & "WHERE(c.total > c.pagado) AND c.descrip = ci.cod_contra  AND ci.cod_inm = i.codigo  AND c.nitc = t.nit AND i.codigo= ci.cod_inm " & ct & " " _
         & " AND num = (SELECT MAX(num) FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) " _
         & "ORDER BY doc , nomnit, rcpos "

        'DETALLES
        sql4 = "SELECT  ci.cod_contra AS doc, c.doc AS ctatotal, CONCAT(c.nitc, ' ', c.nomnit) AS nomnit,  MID(c.concepto, 13, LENGTH(c.concepto)) AS ccosto,  c.total AS total,  " _
        & " c.pagado, IF  (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY), DATEDIFF(NOW() , ADDDATE(c.fecha, INTERVAL c.vmto DAY)), 0) AS vmto,  " _
        & " (SELECT mora  FROM parcontrato ) AS ret, c.rcpos, " _
        & " c.total * (((SELECT  mora FROM parcontrato)/100)/30)*  IF (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY),DATEDIFF(NOW(), ADDDATE(c.fecha, INTERVAL c.vmto DAY)),0) AS  descto " _
        & " FROM cobdpen c, contrato_inm ci " _
        & " WHERE(c.total > c.pagado) AND c.descrip = ci.cod_contra  " & ct & " " _
        & " ORDER BY doc , nomnit, rcpos "

        sql2 = "select logo, parf from parcontrato "

        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        If tap.Rows.Count > 0 Then
            reso = tap.Rows(0).Item("parf")
        End If

        If reso = "SI" Then
            sql3 = " SELECT CONCAT( " _
        & " CASE i.docf WHEN pg.tipof1  THEN IF " _
        & " (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '') " _
        & " WHEN " _
        & " pg.tipof2 " _
        & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')  " _
        & " WHEN " _
        & " pg.tipof3 " _
        & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '') " _
        & " WHEN " _
        & " pg.tipof4 " _
        & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '') " _
        & " End " _
        & " ,'\n', " _
        & " CASE  i.docf WHEN pg.tipof1 " _
        & " THEN IF (pg.hr1='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
        & " WHEN pg.tipof2 " _
        & " THEN IF (pg.hr2='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
        & " WHEN pg.tipof3 " _
        & " THEN IF (pg.hr3='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
        & " WHEN pg.tipof4 " _
        & " THEN IF (pg.hr4='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
        & " END) AS r " _
        & " FROM parcontrato i, parafacgral pg "
        Else
            sql3 = " SELECT " _
            & " CAST(CONCAT('Resolucion DIAN ' ,i.reso1, ' del ', CONCAT( RIGHT(i.fecexp1, 2),'/', MID( i.fecexp1, 6, 2 ),'/', LEFT( i.fecexp1, 4 ))" _
            & " ,'\n', CONCAT('Factura por computador ' ,i.ini1, ' al ',i.fin1) " _
            & " ) AS CHAR(100)) " _
            & "  AS r FROM parcontrato i"
        End If

        '        SELECT  c.doc AS ctatotal, ci.cod_contra AS doc, CONCAT(c.nitc, ' ', c.nomnit) AS nomnit,  t.dir AS ctaretica, c.total AS total,  
        'IF  (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY), DATEDIFF(NOW() , ADDDATE(c.fecha, INTERVAL c.vmto DAY)), 0) AS vmto, 
        '(SELECT  CAST(CONCAT( RIGHT(c.fecha, 2), '/', MID(c.fecha, 6, 2), '/',LEFT(c.fecha, 4) ) AS CHAR(20)) FROM cobdpen WHERE `rcpos` = 
        '(SELECT  MAX(num) FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra)) AS ctaret, 
        '(SELECT  CAST(CONCAT(RIGHT(ADDDATE(fecha, INTERVAL vmto DAY), 2),'/', MID( ADDDATE(fecha, INTERVAL vmto DAY),6, 2), '/',LEFT(ADDDATE(fecha, INTERVAL vmto DAY), 4)) AS CHAR(20)) 
        'FROM cobdpen WHERE `rcpos` = (SELECT MAX(num)FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra)) AS ctaiva,  
        '(c.total) AS subtotal,   MID(c.concepto, 13, LENGTH(c.concepto)) AS ccosto,   
        '(SELECT MID(concepto, 13, LENGTH(concepto)) FROM cobdpen WHERE rcpos = (SELECT MAX(num) FROM cobdpen  WHERE tipafec = 'CNT'  AND descrip = ci.cod_contra)) AS pagare,  
        '(SELECT rcpos FROM cobdpen WHERE num = (SELECT MAX(num) FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva,  
        'c.pagado, i.codigo AS ctasubtotal,  (SELECT mora  FROM parcontrato ) AS ret, c.rcpos,  ci.dias AS num, ci.valor AS retica, 
        'c.total * (((SELECT  mora FROM parcontrato)/100)/30)*  IF (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY),DATEDIFF(NOW(), ADDDATE(c.fecha, INTERVAL c.vmto DAY)),0) AS  descto,
        'UCASE(CONCAT(i.direccion,' ',(SELECT CONCAT(m.descripcion,' - ', d.descripcion) 
        'FROM sae.mun m, sae.dptos d WHERE m.codmun= i.ciudad AND d.codigo=i.dpto)))AS concepto,  
        '(SELECT rcpos FROM ctas_x_pagar WHERE num = (SELECT MAX(num) FROM ctas_x_pagar WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva   
        'FROM cobdpen c, contrato_inm ci,inmuebles i, terceros t  
        'WHERE(c.total > c.pagado)AND c.descrip = ci.cod_contra  AND ci.cod_inm = i.codigo  AND i.nitp = t.nit AND i.codigo= ci.cod_inm   ORDER BY doc , nomnit, rcpos 


        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        If tap.Rows.Count > 0 Then
            reso = tap.Rows(0).Item("r")
        End If

        Dim p As String = ""
        For l = 1 To 12
            If l < 10 Then
                p = "0" & l
            Else
                p = l
            End If
            If l <> 12 Then
                sql5 = sql5 & " SELECT doc AS doc1, RIGHT(doc, LENGTH(doc)-2) AS doc, descrip AS nomart, valor  FROM otcon_fac" & p & " UNION "
            Else
                sql5 = sql5 & " SELECT doc AS doc1, RIGHT(doc, LENGTH(doc)-2) AS doc, descrip AS nomart, valor  FROM otcon_fac" & p & "  "
            End If
        Next
        'CAST( CONCAT(tipo,valor) AS SIGNED) 
        Dim tabla As DataSet
        tabla = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "cobdpen")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql4
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parcontrato")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql5
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportEstCuentArr.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtel As New ParameterField
            Dim PrEmail As New ParameterField
            Dim Prdir As New ParameterField
            Dim Prres As New ParameterField
            Dim Prfac As New ParameterField
            Dim Prcomt As New ParameterField
            Dim Pres As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prtel.Name = "telf"
            Prtel.CurrentValues.AddValue(tel.ToString)

            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue(dir.ToString)

            PrEmail.Name = "tcomp"
            PrEmail.CurrentValues.AddValue(tcomp.ToString)

            Prcomt.Name = "comentario"
            Prcomt.CurrentValues.AddValue(comt.ToString)
            Pres.Name = "reso"
            Pres.CurrentValues.AddValue(reso.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            prmdatos.Add(PrEmail)
            prmdatos.Add(Prcomt)
            prmdatos.Add(Pres)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub PDF(ByVal ct As String)

        'Try

        MiConexion(bda)
        Cerrar()

        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim dir As String = ""
        Dim tcomp As String = ""
        Dim reso As String = ""
        Dim comt As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        dir = tabla2.Rows(0).Item("direccion")
        tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")

        Try
            Dim tabl As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabl)
            tcomp = tabl.Rows(0).Item(0)
        Catch ex As Exception
        End Try


        Dim tap As New DataTable
        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT IFNULL(comentario,'')as com  from parcontrato ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        comt = tap.Rows(0).Item(0)


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        If ct <> "" Then
            ct = "AND ci.cod_contra= '" & ct & "' "
        End If

        'sql = "SELECT   c.doc as ctatotal, ci.cod_contra AS doc, CONCAT(c.nitc, ' ', c.nomnit) AS nomnit,  t.dir AS ctaretica, c.total AS total, " _
        '& " IF  (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY), DATEDIFF(NOW() , ADDDATE(c.fecha, INTERVAL c.vmto DAY)), 0) AS vmto," _
        '& " (SELECT  CAST(CONCAT( RIGHT(c.fecha, 2), '/', MID(c.fecha, 6, 2), '/',LEFT(c.fecha, 4) ) AS CHAR(20)) FROM cobdpen WHERE `rcpos` = " _
        '& "(SELECT  MAX(num) FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra)) AS ctaret," _
        '& " (SELECT  CAST(CONCAT(RIGHT(ADDDATE(fecha, INTERVAL vmto DAY), 2),'/', MID( ADDDATE(fecha, INTERVAL vmto DAY),6, 2), '/',LEFT(ADDDATE(fecha, INTERVAL vmto DAY), 4)) AS CHAR(20))  FROM cobdpen WHERE `rcpos` = (SELECT MAX(num)FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra)) AS ctaiva, " _
        '& " (c.total) AS subtotal,  " _
        '& " MID(c.concepto, 13, LENGTH(c.concepto)) AS ccosto, " _
        '& "  (SELECT MID(concepto, 13, LENGTH(concepto)) FROM cobdpen WHERE rcpos = (SELECT MAX(num) FROM cobdpen  WHERE tipafec = 'CNT'  AND descrip = ci.cod_contra)) AS pagare, " _
        '& " (SELECT rcpos FROM cobdpen WHERE num = (SELECT MAX(num) FROM cobdpen WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva, " _
        '& " c.pagado, i.codigo as ctasubtotal, " _
        '& " (SELECT mora  from parcontrato ) as ret, c.rcpos, " _
        '& " ci.dias as num, ci.valor as retica," _
        '& " c.total * (((SELECT  mora FROM parcontrato)/100)/30)*  IF (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY),DATEDIFF(NOW(), ADDDATE(c.fecha, INTERVAL c.vmto DAY)),0) AS  descto " _
        '& " ,UCASE(CONCAT(i.direccion,' ',(SELECT CONCAT(m.descripcion,' - ', d.descripcion) FROM sae.mun m, sae.dptos d WHERE m.codmun= i.ciudad AND d.codigo=i.dpto)))AS concepto, " _
        '& " (SELECT rcpos FROM ctas_x_pagar WHERE num = (SELECT MAX(num) FROM ctas_x_pagar WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva  " _
        '& " FROM cobdpen c, contrato_inm ci,inmuebles i, terceros t " _
        '& " WHERE(c.total > c.pagado)AND c.descrip = ci.cod_contra  AND ci.cod_inm = i.codigo  AND i.nitp = t.nit AND i.codigo= ci.cod_inm  " & ct & "" _
        '& " ORDER BY doc , nomnit, rcpos "

        sql = "SELECT   c.doc as ctatotal, ci.cod_contra AS doc, CONCAT(c.nitc, ' ', c.nomnit) AS nomnit,  t.dir AS ctaretica, c.total AS total, " _
     & " IF  (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY), DATEDIFF(NOW() , ADDDATE(c.fecha, INTERVAL c.vmto DAY)), 0) AS vmto," _
     & " ( CAST(CONCAT( RIGHT(fecha, 2), '/', MID(fecha, 6, 2), '/',LEFT(fecha, 4) ) AS CHAR(20)) ) AS ctaret, (c.total) AS subtotal,  " _
     & " MID(c.concepto, 13, LENGTH(c.concepto)) AS ccosto, " _
     & " c.pagado, i.codigo as ctasubtotal, " _
     & " (SELECT mora  from parcontrato ) as ret, c.rcpos, " _
     & " ci.dias as num, ci.valor as retica," _
     & " c.total * (((SELECT  mora FROM parcontrato)/100)/30)*  IF (NOW() > ADDDATE(c.fecha, INTERVAL c.vmto DAY),DATEDIFF(NOW(), ADDDATE(c.fecha, INTERVAL c.vmto DAY)),0) AS  descto " _
     & " ,UCASE(CONCAT(i.direccion,' ',(SELECT CONCAT(m.descripcion,' - ', d.descripcion) FROM sae.mun m, sae.dptos d WHERE m.codmun= i.ciudad AND d.codigo=i.dpto)))AS concepto, " _
     & " (SELECT rcpos FROM ctas_x_pagar WHERE num = (SELECT MAX(num) FROM ctas_x_pagar WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva  " _
     & " FROM cobdpen c, contrato_inm ci,inmuebles i, terceros t " _
     & " WHERE(c.total > c.pagado)AND c.descrip = ci.cod_contra  AND ci.cod_inm = i.codigo  AND i.nitp = t.nit AND i.codigo= ci.cod_inm  " & ct & "" _
     & " ORDER BY doc , nomnit, rcpos "

        sql2 = "select logo, parf from parcontrato "

        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        If tap.Rows.Count > 0 Then
            reso = tap.Rows(0).Item("parf")
        End If

        If reso = "SI" Then
            sql3 = " SELECT CONCAT( " _
        & " CASE i.docf WHEN pg.tipof1  THEN IF " _
        & " (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '') " _
        & " WHEN " _
        & " pg.tipof2 " _
        & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')  " _
        & " WHEN " _
        & " pg.tipof3 " _
        & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '') " _
        & " WHEN " _
        & " pg.tipof4 " _
        & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '') " _
        & " End " _
        & " ,'\n', " _
        & " CASE  i.docf WHEN pg.tipof1 " _
        & " THEN IF (pg.hr1='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
        & " WHEN pg.tipof2 " _
        & " THEN IF (pg.hr2='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
        & " WHEN pg.tipof3 " _
        & " THEN IF (pg.hr3='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
        & " WHEN pg.tipof4 " _
        & " THEN IF (pg.hr4='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
        & " END) AS r " _
        & " FROM parcontrato i, parafacgral pg "
        Else
            sql3 = " SELECT " _
            & " CAST(CONCAT('Resolucion DIAN ' ,i.reso1, ' del ', CONCAT( RIGHT(i.fecexp1, 2),'/', MID( i.fecexp1, 6, 2 ),'/', LEFT( i.fecexp1, 4 ))" _
            & " ,'\n', CONCAT('Factura por computador ' ,i.ini1, ' al ',i.fin1) " _
            & " ) AS CHAR(100)), " _
            & " ) AS r FROM parcontrato i"
        End If

        tap.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)
        If tap.Rows.Count > 0 Then
            reso = tap.Rows(0).Item("r")
        End If

        Dim tabla As DataSet
        tabla = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "cobdpen")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parcontrato")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportEstCuent_inm.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtel As New ParameterField
            Dim PrEmail As New ParameterField
            Dim Prdir As New ParameterField
            Dim Prres As New ParameterField
            Dim Prfac As New ParameterField
            Dim Prcomt As New ParameterField
            Dim Pres As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prtel.Name = "telf"
            Prtel.CurrentValues.AddValue(tel.ToString)

            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue(dir.ToString)

            PrEmail.Name = "tcomp"
            PrEmail.CurrentValues.AddValue(tcomp.ToString)

            Prcomt.Name = "comentario"
            Prcomt.CurrentValues.AddValue(comt.ToString)
            Pres.Name = "reso"
            Pres.CurrentValues.AddValue(reso.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            prmdatos.Add(PrEmail)
            prmdatos.Add(Prcomt)
            prmdatos.Add(Pres)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try

        'Catch ex As Exception
        '    MsgBox("Error al visualizar factura , " & ex.ToString, MsgBoxStyle.Exclamation, "Error")
        'End Try

    End Sub

    Private Sub txtcontr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontr.DoubleClick
        Try
            FrmSelContratos.lbform.Text = "Extr"
            FrmSelContratos.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcontr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontr.LostFocus

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcontr.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count = 0 Then
            Try
                txtcontr.Text = ""
                FrmSelContratos.lbform.Text = "Extr"
                FrmSelContratos.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub chG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chG.CheckedChanged
        If rb1.Checked = True Then
            chG.Checked = False
        End If
    End Sub

    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        Try
            txtdi1.Text = Strings.Left(DateSerial(Strings.Right(PerActual, 4), cbini.Text + 1, 0), 2)
        Catch ex As Exception
            txtdi1.Text = Now.Day
        End Try

    End Sub

    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        Dim d As Date
        Try
            d = CDate(cbini.Text & txtpini.Text & "/" & txtdi1.Text)
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdi1.Focus()
            'Try
            '    txtdi1.Text = Strings.Left(DateSerial(Strings.Right(PerActual, 4), cbini.Text + 1, 0), 2)
            'Catch ex As Exception
            '    txtdi1.Text = Now.Day
            'End Try
        End Try
    End Sub
End Class