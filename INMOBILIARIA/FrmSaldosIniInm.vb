Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmSaldosIniInm
    Private Sub limpiar()
        grilla2.Rows.Clear()
        txtcodcont.Text = ""
        txtinm.Text = ""
        txtnita.Text = ""
        txtnoma.Text = ""
      
    End Sub
    Private Sub bloquear()
        GroupBox2.Enabled = False
        txtcodcont.Enabled = False
        chcont.Enabled = False
        txtinm.Enabled = False
        txtnita.Enabled = False

        'botones
        cmdNuevo.Enabled = True
        cmdInf.Enabled = True
        CmdSalir.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
    End Sub
    Private Sub desbloquear()
        GroupBox2.Enabled = True
        txtcodcont.Enabled = True
        chcont.Enabled = True
        txtinm.Enabled = True
        txtnita.Enabled = True

        'botones
        cmdNuevo.Enabled = False
        cmdInf.Enabled = False
        CmdSalir.Enabled = True
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Dim taI As New DataTable
    Private Sub FrmSaldosIniInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        bloquear()

        '.......... BUSCAR PARAMETROS .....

        taI.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM parcontrato "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(taI)
        Refresh()
        If taI.Rows.Count > 0 Then
            If taI.Rows(0).Item("ctacms") = "" Or taI.Rows(0).Item("ctavent") = "" Then
                MsgBox("Verifique las cuentas en los parametros para crear los Saldos Iniciales", MsgBoxStyle.Information, "Verificación")
                Me.Close()
            Else
                lbCtaIng.Text = taI.Rows(0).Item("ctacms")
                lbCtaXP.Text = taI.Rows(0).Item("ctavent")
            End If
        Else
            MsgBox("Verifique las cuentas en los parametros para crear los Saldos Iniciales", MsgBoxStyle.Information, "Verificación")
            Me.Close()
        End If

    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        desbloquear()
        chcont.Focus()
        'BuscarConsec()
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        limpiar()
        bloquear()

    End Sub

    Private Sub txtnita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnita.KeyPress
        ValidarNIT(txtnita, e)
    End Sub

  

    Private Sub txtnita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.LostFocus

        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr ,terceros t  WHERE tr.clase ='ARRENDATARIO'  and tr.nit = '" & txtnita.Text & "' and t.nit=tr.nit ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtnita.Text = ""
            txtnoma.Text = ""
            Try
                FrmSelDueño.Text = "Seleccionar Arrendatario"
                FrmSelDueño.lbform.Text = "SaldosInm"
                FrmSelDueño.txtclase.Text = "ARRENDATARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtnita.Text = tabla.Rows(0).Item("nit")
            txtnoma.Text = tabla.Rows(0).Item("nom")
        End If

    End Sub

    Private Sub txtnoma_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnoma.TextChanged
        If txtnita.Text = "" Then
            txtnoma.Text = ""
        End If
    End Sub

    Private Sub txtcodcont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodcont.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarContrato()
        End If
    End Sub
    Private Sub BuscarContrato()
        MiConexion(bda)
        If chcont.Checked = True Then
            Dim tb As New DataTable
            myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcodcont.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            Try
                If tb.Rows.Count = 0 Then
                    txtcodcont.Text = ""
                    FrmSelContratos.lbform.Text = "SaldoInm"
                    FrmSelContratos.ShowDialog()
                Else
                    txtnita.Text = tb.Rows(0).Item("nit_a")
                    txtinm.Text = tb.Rows(0).Item("cod_inm")
                    txtnoma.Text = tb.Rows(0).Item("nomb_arr")
                End If
            Catch ex As Exception

            End Try

        Else
            Dim tc As New DataTable
            tc.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * from contrato_inm where cod_contra='" & txtcodcont.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            Refresh()
            If tc.Rows.Count <> 0 Then
                MsgBox("El codigo del contrato ya existe en el sistema, Verifique el codigo o Marquelo como existente", MsgBoxStyle.Information, "Verificacion")
                txtcodcont.Text = ""
            End If
        End If
        Cerrar()
    End Sub

    Private Sub txtcodcont_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodcont.LostFocus
        'MiConexion(bda)
        'If chcont.Checked = True Then
        '    Dim tb As New DataTable
        '    myCommand.CommandText = "SELECT * FROM contrato_inm where cod_contra='" & txtcodcont.Text & "';"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    Refresh()
        '    Try
        '        If tb.Rows.Count = 0 Then
        '            txtcodcont.Text = ""
        '            FrmSelContratos.lbform.Text = "SaldoInm"
        '            FrmSelContratos.ShowDialog()
        '        Else
        '            txtnita.Text = tb.Rows(0).Item("nit_a")
        '            txtinm.Text = tb.Rows(0).Item("cod_inm")
        '            txtnoma.Text = tb.Rows(0).Item("nomb_arr")
        '        End If
        '    Catch ex As Exception

        '    End Try

        'Else
        '    Dim tc As New DataTable
        '    tc.Clear()
        '    myCommand.Parameters.Clear()
        '    myCommand.CommandText = "SELECT * from contrato_inm where cod_contra='" & txtcodcont.Text & "'"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tc)
        '    Refresh()
        '    If tc.Rows.Count <> 0 Then
        '        MsgBox("El codigo del contrato ya existe en el sistema, Verifique el codigo o Marquelo como existente", MsgBoxStyle.Information, "Verificacion")
        '        txtcodcont.Text = ""
        '    End If
        'End If
        'Cerrar()
    End Sub

    Private Sub chcont_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcont.CheckedChanged
        txtcodcont.Text = ""
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click


        Dim resultado As MsgBoxResult
        resultado = MsgBox("El Saldo Inicial se va a Guardar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then

            If txtcodcont.Text = "" Then
                MsgBox("Verifique el codigo de la factura", MsgBoxStyle.Information, "Verificación")
                Exit Sub
            End If
            If txtinm.Text = "" Then
                MsgBox("Verifique el Codigo del Inmueble", MsgBoxStyle.Information, "Verificación")
                Exit Sub
            End If
            If txtnita.Text = "" Then
                MsgBox("Verifique el nit del Arrendatario", MsgBoxStyle.Information, "Verificación")
                Exit Sub
            End If

            For i = 0 To grilla2.RowCount - 1

                'If grilla2.Item("concepto", i).Value = "" Then
                '    MsgBox("Digite el Mes para la cuenta por cobrar", MsgBoxStyle.Information, "Verificación")
                '    Exit Sub
                'End If
                'If grilla2.Item("fecha", i).Value = "" Then
                '    MsgBox("Digite la fecha", MsgBoxStyle.Information, "Verificación")
                '    Exit Sub
                'End If
                'If grilla2.Item("valor", i).Value = Moneda(0) Then
                '    MsgBox("Digite el Valor a Cobrar", MsgBoxStyle.Information, "Verificación")
                '    Exit Sub
                'End If
                'If grilla2.Item("tipo", i).Value = "" Then
                '    MsgBox("Digite el Valor a Cobrar", MsgBoxStyle.Information, "Verificación")
                '    Exit Sub
                'End If
                Try

                    If grilla2.Item("valor", i).Value <> Moneda(0) And grilla2.Item("tipo", i).Value <> "" And grilla2.Item("concepto", i).Value <> "" And grilla2.Item("fecha", i).Value.ToString <> "" Then
                        'MsgBox(CInt(Strings.Right(grilla2.Item("tipo", i).Value, Len(grilla2.Item("tipo", i).Value) - 2)))
                        guardar(i)
                    End If
                Catch ex As Exception

                End Try
            Next
            MsgBox("Los datos fueron registrados exitosamente ", MsgBoxStyle.Information, "SAE")
            bloquear()
        End If



    End Sub
    Dim num As String = ""
    Dim doc As String = ""
    Dim pref As String = ""
    Dim actual As Integer = 0
    Dim taf As New DataTable
    Private Sub BuscarConsec(ByRef fila As Integer)
        ''****************** PARAMETROS PARA FACTU **********************


        taf.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM  parcontrato ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(taf)
        Refresh()

        If taf.Rows.Count = 0 Then
            MsgBox("Usted no ha definido los parametros de Inmobiliaria.", MsgBoxStyle.Exclamation, "Verifique")
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
                    'txtnumfac.Text = doc & NumeroDoc(actual + 1)
                    grilla2.Item("tipo", fila).Value = doc & NumeroDoc(actual + 1)
                Else
                    '................. Con Resolucion
                    If Val(taf.Rows(0).Item("a_f1")) > Val(taf.Rows(0).Item("fin1")) And Val(taf.Rows(0).Item("fin1")) > 0 Then
                        MsgBox("Has superado el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & taf.Rows(0).Item("reso1") & ", Limite=" & Val(taf.Rows(0).Item("fin1")), MsgBoxStyle.Critical, "SAE Resolución DIAN")
                        Exit Sub
                    End If
                    If DateTime.Now.ToString("yyyy-MM-dd") > CDate(taf.Rows(0).Item("feclim1").ToString) Then
                        MsgBox("Ha superado la fecha limite para realizar facturas por computador permitidas por la RESOLUCIÓN DIAN " & taf.Rows(0).Item("reso1") & ", Fecha Limite=" & taf.Rows(0).Item("feclim1").ToString, MsgBoxStyle.Critical, "SAE Resolución DIAN")
                        Exit Sub
                    End If
                    doc = taf.Rows(0).Item("tipof1")
                    actual = taf.Rows(0).Item("a_f1")
                    pref = taf.Rows(0).Item("pre1")
                    'txtnumfac.Text = doc & NumeroDoc(actual + 1)
                    grilla2.Item("tipo", fila).Value = doc & NumeroDoc(actual + 1)
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
                        'txtnumfac.Text = doc & NumeroDoc(actual + 1)
                        grilla2.Item("tipo", fila).Value = doc & NumeroDoc(actual + 1)
                    Else
                        '................. Con Resolucion
                        If Val(tpf.Rows(0).Item(0)) > Val(tpf.Rows(0).Item(7)) And Val(tpf.Rows(0).Item(7)) > 0 Then
                            MsgBox("Has superado el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & tpf.Rows(0).Item(3) & ", Limite=" & Val(tpf.Rows(0).Item(7)), MsgBoxStyle.Critical, "SAE Resolución DIAN")
                            Exit Sub
                        End If
                        If DateTime.Now.ToString("yyyy-MM-dd") > CDate(tpf.Rows(0).Item(5).ToString) Then
                            MsgBox("Ha superado la fecha limite para realizar facturas por computador permitidas por la RESOLUCIÓN DIAN " & tpf.Rows(0).Item(3) & ", Fecha Limite=" & tpf.Rows(0).Item(5).ToString, MsgBoxStyle.Critical, "SAE Resolución DIAN")
                            Exit Sub
                        End If
                        doc = taf.Rows(0).Item("docf")
                        actual = tpf.Rows(0).Item(0)
                        pref = tpf.Rows(0).Item(1)
                        'txtnumfac.Text = doc & NumeroDoc(actual + 1)
                        grilla2.Item("tipo", fila).Value = doc & NumeroDoc(actual + 1)
                    End If
                End If
            End If
            '*************************************************
            '***************************  ****************************
        End If

    End Sub
    Private Sub guardar(ByRef fila As Integer)

        MiConexion(bda)
        Try
            
            Dim fecha As Date = CDate(grilla2.Item("fecha", fila).Value)

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", grilla2.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?tipo", Strings.Left(grilla2.Item("tipo", fila).Value, 2))
            myCommand.Parameters.AddWithValue("?num", CInt(Strings.Right(grilla2.Item("tipo", fila).Value, Len(grilla2.Item("tipo", fila).Value) - 2)))
            myCommand.Parameters.AddWithValue("?descrip", txtcodcont.Text)
            myCommand.Parameters.AddWithValue("?tipafec", "CNT")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", txtnita.Text)
            myCommand.Parameters.AddWithValue("?nomnit", txtnoma.Text)
            myCommand.Parameters.AddWithValue("?nitcod", "")
            myCommand.Parameters.AddWithValue("?nitv", "")
            myCommand.Parameters.AddWithValue("?fecha", CDate(fecha))
            myCommand.Parameters.AddWithValue("?vmto", grilla2.Item("vmto", fila).Value)
            myCommand.Parameters.AddWithValue("?concepto", "ARRIENDO MES " & grilla2.Item("concepto", fila).Value & " - INMUEBLE COD: " & txtinm.Text)
            myCommand.Parameters.AddWithValue("?subtotal", DIN(grilla2.Item("valor", fila).Value))
            myCommand.Parameters.AddWithValue("?descto", "0")
            myCommand.Parameters.AddWithValue("?ret", "0")
            myCommand.Parameters.AddWithValue("?iva", 0)
            myCommand.Parameters.AddWithValue("?v_viva", 0)
            myCommand.Parameters.AddWithValue("?total", DIN(grilla2.Item("valor", fila).Value))
            myCommand.Parameters.AddWithValue("?ctasubtotal", "")
            myCommand.Parameters.AddWithValue("?ctaret", "")
            myCommand.Parameters.AddWithValue("?ctaiva", "")
            myCommand.Parameters.AddWithValue("?ctatotal", taI.Rows(0).Item("ctavent"))
            myCommand.Parameters.AddWithValue("?ccosto", "")
            myCommand.Parameters.AddWithValue("?otroimp", "N")
            myCommand.Parameters.AddWithValue("?retiva", "0")
            myCommand.Parameters.AddWithValue("?ctaretiva", "")
            myCommand.Parameters.AddWithValue("?retica", "0")
            myCommand.Parameters.AddWithValue("?ctaretica", "")
            myCommand.Parameters.AddWithValue("?pagado", "0")
            myCommand.Parameters.AddWithValue("?rcpos", CInt(Strings.Right(grilla2.Item("tipo", fila).Value, Len(grilla2.Item("tipo", fila).Value) - 2)))
            myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
            myCommand.Parameters.AddWithValue("?vpos", "0")
            myCommand.Parameters.AddWithValue("?tasa", "0")
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", pref)

            myCommand.CommandText = "Insert INTO cobdpen Values (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto,?concepto,?subtotal,?descto, " _
            & " ?ret,?iva,?v_viva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica,?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()

            doccontabl(fila)
            If chcont.Checked = False Then
                GuardarContrato()
            End If
            Consecutivo(doc, taf.Rows(0).Item("parf"), CInt(Strings.Right(grilla2.Item("tipo", fila).Value, Len(grilla2.Item("tipo", fila).Value) - 2)), num)

        Catch ex As Exception
            'MsgBox("Error al Ingresar el saldo Inicial, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
        Cerrar()

    End Sub
    Private Sub GuardarContrato()

        Try

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod_con", txtcodcont.Text)
            myCommand.Parameters.AddWithValue("?cod_inm", txtinm.Text)
            myCommand.Parameters.AddWithValue("?nita", txtnita.Text)
            myCommand.Parameters.AddWithValue("?nom_a", txtnoma.Text)
            myCommand.Parameters.AddWithValue("?nitd", "")
            myCommand.Parameters.AddWithValue("?f1", DateTime.Now.ToString("yyyy-MM-dd"))
            myCommand.Parameters.AddWithValue("?f2", DateTime.Now.ToString("yyyy-MM-dd"))
            myCommand.Parameters.AddWithValue("?valor", DIN(grilla2.Item("valor", 0).Value))
            myCommand.Parameters.AddWithValue("?ctaval", "")
            myCommand.Parameters.AddWithValue("?iva", DIN(0))
            '   myCommand.Parameters.AddWithValue("?iva", txtivap.Text)
            myCommand.Parameters.AddWithValue("?ctaiva", "")
            myCommand.Parameters.AddWithValue("?comi", DIN(0))
            myCommand.Parameters.AddWithValue("?cc", Val(0))
            myCommand.Parameters.AddWithValue("?tmes", 0)
            myCommand.Parameters.AddWithValue("?nitv", "")
            myCommand.Parameters.AddWithValue("?vmto", grilla2.Item("vmto", 0).Value)
            myCommand.Parameters.AddWithValue("?rtf", DIN(0))
            myCommand.Parameters.AddWithValue("?ctartf", "")
            myCommand.Parameters.AddWithValue("?dep", DIN(0))
            myCommand.Parameters.AddWithValue("?mes_f", 0)
            myCommand.Parameters.AddWithValue("?mes_a", 0)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?ff", DateTime.Now.ToString("yyyy-MM-dd"))
            myCommand.Parameters.AddWithValue("?nitc", "")
            myCommand.Parameters.AddWithValue("?ctacli", "")
            myCommand.Parameters.AddWithValue("?ctacms", "")
            myCommand.Parameters.AddWithValue("?dias", DIN(0))
            myCommand.Parameters.AddWithValue("?movdep", DIN(0))

            myCommand.CommandText = "Insert INTO contrato_inm Values (?cod_con,?cod_inm,?nita,?nom_a,?nitd,?f1,?f2,?valor,?ctaval,?iva,?ctaiva,?rtf,?ctartf,?comi,?cc,?tmes,?mes_f,?mes_a,?periodo,?nitv,?vmto,?dep,?ff,?nitc,?ctacli,?ctacms,?dias,?movdep,'');"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            Refresh()
            '************************
        Catch ex As Exception
            MsgBox("Error al registrar el Contrato", MsgBoxStyle.Information, "Error")
        End Try

    End Sub
    Private Sub doccontabl(ByVal fila As Integer)

        grilla.Rows.Clear()
        grilla.RowCount = 3

        ' ----------- cxc
        grilla.Item("Descripcion", 0).Value = "SALDO INCIAL INMOBILIARIA "
        grilla.Item(1, 0).Value = Moneda(grilla2.Item("valor", fila).Value)
        grilla.Item(2, 0).Value = Moneda(0)
        grilla.Item(3, 0).Value = lbCtaXP.Text
        grilla.Item(4, 0).Value = Moneda(0)
        grilla.Item(5, 0).Value = ""
        grilla.Item(6, 0).Value = txtnita.Text
        grilla.Item(7, 0).Value = "0"
        '-------------------------------------------

        ' ----------- ing
        grilla.Item("Descripcion", 1).Value = "SALDO INCIAL INMOBILIARIA "
        grilla.Item(1, 1).Value = Moneda(0)
        grilla.Item(2, 1).Value = Moneda(grilla2.Item("valor", fila).Value)
        grilla.Item(3, 1).Value = lbCtaIng.Text
        grilla.Item(4, 1).Value = Moneda(0)
        grilla.Item(5, 1).Value = ""
        grilla.Item(6, 1).Value = txtnita.Text
        grilla.Item(7, 1).Value = "0"
        '-------------------------------------------


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
                    InsertContabilidad(i, fila)
                    ' MsgBox("Insertar " & i & grilla.Item("descripcion", i).Value.ToString)
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal filaG As Integer)

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", CInt(Strings.Right(grilla2.Item("tipo", filaG).Value, Len(grilla2.Item("tipo", filaG).Value) - 2)))
            myCommand.Parameters.AddWithValue("?tipodoc", Strings.Left(grilla2.Item("tipo", filaG).Value, 2))
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", Now.Day.ToString)
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
            myCommand.Parameters.AddWithValue("?diasv", Val(grilla2.Item("vmto", filaG).Value))
            If Val(grilla2.Item("vmto", filaG).Value) > 0 Then
                Dim fec As Date = DateAdd("d", Val(grilla2.Item("vmto", filaG).Value), DateTime.Now.ToString("yyyy-MM-dd"))
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            '  Try
            myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
            myCommand.Parameters.AddWithValue("?cheque", "")

            myCommand.Parameters.AddWithValue("?modulo", "inmobiliaria")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos00 " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error Insertar Contable" & ex.ToString)
        End Try
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


        Try
            If parf = "NO" Then
                myCommand.CommandText = "UPDATE parcontrato SET a_f1 = " & Val(num) & ";"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(num) & " WHERE tipodoc='" & tipo & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.CommandText = "UPDATE parafacgral SET a_f" & n & " = " & Val(num) & ";"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(num) & " WHERE tipodoc='" & tipo & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar el consecutivo", MsgBoxStyle.Information, "Error")
        End Try

    End Sub
    Dim v As String
    Private Sub txtinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinm.LostFocus
        MiConexion(bda)
        Dim ti As New DataTable
        myCommand.CommandText = "SELECT * FROM inmuebles where codigo='" & txtinm.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ti)
        Refresh()
        Try
            If ti.Rows.Count = 0 Then
                txtinm.Text = ""
                FrmSelInmueble.lbform.Text = "SaldoInm"
                FrmSelInmueble.ShowDialog()
            End If
        Catch ex As Exception

        End Try
        Cerrar()
    End Sub

    Private Sub txtnita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.TextChanged
        If txtnita.Text = "" Then
            txtnoma.Text = ""
        End If
    End Sub

    Private Sub txtcodcont_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodcont.TextChanged
        If txtcodcont.Text = "" Then
            txtnita.Text = ""
            txtnoma.Text = ""
            txtinm.Text = ""
        End If
    End Sub

    Private Sub cmdInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInf.Click


        'Try

        Dim nom As String = ""
        Dim nit As String = ""
        Dim tabla2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")

        ' DOCUMENTOS00
        Dim docu As String = ""
        Dim tdc As New DataTable
        myCommand.CommandText = "SELECT DISTINCT CAST(CONCAT(tipodoc,doc)  AS CHAR(50) ) AS d FROM documentos00 WHERE modulo='inmobiliaria' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tdc)
        If tdc.Rows.Count > 0 Then
            For j = 0 To tdc.Rows.Count - 1
                docu = docu & "'" & tdc.Rows(j).Item(0) & "',"
            Next
        End If
        docu = Strings.Left(docu, Len(docu) - 1)

        Dim tc As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT doc, fecha,CAST(CONCAT( RIGHT(fecha, 2), '/', MID(fecha, 6, 2), '/',LEFT(fecha, 4) ) AS CHAR(20)) AS nitv," _
        & " concat(nitc,' ',nomnit) as nomnit, total,descrip, (total-pagado) AS pagado FROM cobdpen " _
        & " WHERE CONCAT(tipo, num) IN (" & docu & ") ORDER BY fecha"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportSaldosInici.rpt")
        CrReport.SetDataSource(tc)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)

            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try
        'Catch ex As Exception
        '    MsgBox("Informe no generado")
        'End Try
    End Sub
    Private fil As Integer
    Private Sub grilla2_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla2.CellBeginEdit

        Select Case e.ColumnIndex
            Case 0
                If e.RowIndex = 0 Then
                    BuscarConsec(e.RowIndex)
                Else
                    Dim camp As String = ""
                    camp = grilla2.Item("tipo", e.RowIndex - 1).Value
                    grilla2.Item("tipo", e.RowIndex).Value = Strings.Left(camp, 2) & NumeroDoc(CInt(Strings.Right(camp, Len(camp) - 2)) + 1)
                End If
        End Select
    End Sub

    Private Sub grilla2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla2.CellEndEdit
        Try

            Select Case e.ColumnIndex
                Case 0
                    If e.RowIndex = 0 Then
                        BuscarConsec(e.RowIndex)
                    Else
                        Dim camp As String = ""
                        camp = grilla2.Item("tipo", e.RowIndex - 1).Value
                        grilla2.Item("tipo", e.RowIndex).Value = Strings.Left(camp, 2) & NumeroDoc(CInt(Strings.Right(camp, Len(camp) - 2)) + 1)
                        'grilla2.Item("tipo", e.RowIndex).Value = CInt(grilla2.Item("tipo", e.RowIndex - 1).Value) + 1
                    End If
                    grilla2.Item("fecha", e.RowIndex).Value = Now.Day & "/" & PerActual
                    grilla2.Item("vmto", e.RowIndex).Value = 0
                    grilla2.Item("valor", e.RowIndex).Value = Moneda(0)
                Case 1
                    grilla2.Item("concepto", e.RowIndex).Value = UCase(grilla2.Item("concepto", e.RowIndex).Value)
                Case 2
                    If grilla2.Item("fecha", e.RowIndex).Value = "" Then
                        grilla2.Item("fecha", e.RowIndex).Value = Now.Day & "/" & PerActual
                    End If
                Case 3
                    If grilla2.Item("vmto", e.RowIndex).Value = "" Then
                        grilla2.Item("vmto", e.RowIndex).Value = 0
                    End If
                Case 4
                    If grilla2.Item("valor", e.RowIndex).Value = "" Then
                        grilla2.Item("valor", e.RowIndex).Value = Moneda(0)
                    Else
                        grilla2.Item("valor", e.RowIndex).Value = Moneda(grilla2.Item("valor", e.RowIndex).Value)
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub


    Private Sub grilla2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla2.CellEnter
        fil = e.RowIndex
    End Sub

    Private Sub grilla2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla2.KeyDown
        Try
            If e.KeyCode = 8 Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
                If resultado = MsgBoxResult.Yes Then
                    grilla2.Rows.RemoveAt(fil)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class