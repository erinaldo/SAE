Public Class FrmDocConciliaB
    Dim cm As String
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click

        txtdia.Text = Now.Day
        cbper.Text = Strings.Left(PerActual, 2)
        txtperiodo.Text = Strings.Right(PerActual, 4)
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        'cmdver.Enabled = False
        If FrmConciliacionB.lbestado.Text = "NUEVO" Then
            txtDoc.Text = ""
            TxtDocumento.Text = ""
            TxtNumero.Text = ""
            'Parametro
            Dim tp As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select p.doc3, t.descripcion, t.actual" & cbper.Text & " from parbanc p, tipdoc t WHERE t.tipodoc= p.doc3  "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count = 0 Then
                MsgBox("Verifique en los Parametros el tipo de documento ", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            Else
                TxtDocumento.Text = tp.Rows(0).Item(0)
                txtDoc.Text = tp.Rows(0).Item(1)
                TxtNumero.Text = NumeroDoc(Val(tp.Rows(0).Item(2).ToString) + 1)
            End If
        Else
            txtDoc.Text = ""
            TxtDocumento.Text = FrmConciliacionB.txtDcb.Text
            TxtNumero.Text = FrmConciliacionB.txtNcb.Text
        End If

        txtdb.Text = Moneda(0)
        txtcr.Text = Moneda(0)
        txtdif.Text = Moneda(0)
        gitems.Rows.Clear()
        gitems.ReadOnly = False
        gitems.RowCount = 2
        gitems.Item(0, 0).Value = ""
        gitems.Item(1, 0).Value = "0,00"
        gitems.Item(2, 0).Value = "0,00"
        gitems.Item(3, 0).Value = ""
        gitems.Item(4, 0).Value = "0,00"
        gitems.Item(5, 0).Value = "0"
        gitems.Item(6, 0).Value = "00/00/0000"
        gitems.Item(7, 0).Value = ""
        gitems.Item(8, 0).Value = ""
        gitems.Item(9, 0).Value = ""

        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & Strings.Right(PerActual, 4) & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "c.ingc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "c.ingc_fut"
        Else
            cm = "c.ingc_cgdg"
        End If
        saldoAj()
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        ValidarGuardar()

        ' cmdContinuar_Click(AcceptButton, AcceptButton)

    End Sub
    Private Sub EnviarD()

        If gitems.Rows.Count <> 0 Then
            FrmConciliacionB.gcon.Rows.Clear()
            FrmConciliacionB.gcon.RowCount = gitems.RowCount
            For i = 0 To gitems.Rows.Count - 1
                FrmConciliacionB.gcon.Item("gdes", i).Value = gitems.Item("gdes", i).Value
                FrmConciliacionB.gcon.Item("gDeb", i).Value = gitems.Item("gDeb", i).Value
                FrmConciliacionB.gcon.Item("gCred", i).Value = gitems.Item("gCred", i).Value
                FrmConciliacionB.gcon.Item("gCta", i).Value = gitems.Item("gCta", i).Value
                FrmConciliacionB.gcon.Item("gBase", i).Value = gitems.Item("gBase", i).Value
                FrmConciliacionB.gcon.Item("gdvmto", i).Value = gitems.Item("gdvmto", i).Value
                FrmConciliacionB.gcon.Item("gfvmto", i).Value = gitems.Item("gfvmto", i).Value
                FrmConciliacionB.gcon.Item("gnit", i).Value = gitems.Item("gnit", i).Value
                FrmConciliacionB.gcon.Item("grubro", i).Value = gitems.Item("grubro", i).Value
                FrmConciliacionB.gcon.Item("gcheque", i).Value = gitems.Item("gcheque", i).Value
                FrmConciliacionB.gcon.Item("trbro", i).Value = gitems.Item("trbro", i).Value
            Next
        End If

        FrmConciliacionB.txtsalcon.Text = txtsalcon.Text
        FrmConciliacionB.txtDcb.Text = TxtDocumento.Text
        FrmConciliacionB.txtDcb2.Text = txtDoc.Text
        FrmConciliacionB.txtNcb.Text = TxtNumero.Text

    End Sub
    Private Sub ValidarGuardar()
        SacarCuenta()
        If TxtDocumento.Text = "" Then
            MsgBox("Favor escoger el tipo de documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtDocumento.Focus()
            Exit Sub
        ElseIf TxtNumero.Text = "" Then
            MsgBox("Favor verifique el campo Nro Documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtNumero.Focus()
            Exit Sub
        ElseIf CDec(txtdif.Text) <> 0 Then
            MsgBox("Favor verifique los items del documento la diferencia no puede ser distinta de cero(0)...", MsgBoxStyle.Information, "SAE Verificación")
            gitems.Focus()
            Exit Sub
        ElseIf CDec(txtdb.Text) = 0 Then
            MsgBox("Favor verifique los items del documento no digitado ningun debito...", MsgBoxStyle.Information, "SAE Verificación")
            txtdb.Focus()
            Exit Sub
        ElseIf txtcr.Text = "000,00" Then
            MsgBox("Favor verifique los items del documento no digitado ningun credito...", MsgBoxStyle.Information, "SAE Verificación")
            txtcr.Focus()
            Exit Sub
        ElseIf gitems.RowCount <= 1 Then
            MsgBox("Favor verifique los items del documento no digitado ninguno...", MsgBoxStyle.Information, "SAE Verificación")
            gitems.Focus()
            Exit Sub
        End If
        'Try
        '    Dim mifec As Date
        '    mifec = txtdia.Text & txtperiodo.Text
        'Catch ex As Exception
        '    MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
        '    txtdia.Focus()
        '    Exit Sub
        'End Try
        'MesdelPeriodo()
        'Dim cad As String
        'cad = TxtDocumento.Text
        'cad = cad(0) & cad(1)
        'MiConexion(bda)
        For i = 0 To gitems.RowCount - 2
            If gitems.Item(0, i).Value = "" And gitems.Item(3, i).Value <> "" Then
                MsgBox("falta digitar una descripción.  ", MsgBoxStyle.Information, "SAE Verificación")
                gitems.Item(0, i).Selected = True
                gitems.Focus()
                Exit Sub
            ElseIf gitems.Item(3, i).Value = "" Then
                MsgBox("falta digitar una cuenta.  ", MsgBoxStyle.Information, "SAE Verificación")
                gitems.Item(3, i).Selected = True
                gitems.Focus()
                Exit Sub
            ElseIf CDbl(gitems.Item(1, i).Value) = 0 And CDbl(gitems.Item(2, i).Value) = 0 Then
                MsgBox("Los valores debito y credito no pueden ser ambos iguales a cero(0) en un mismo Item.   ", MsgBoxStyle.Information, "SAE Verificación")
                gitems.Item(1, i).Selected = True
                gitems.Focus()
                Exit Sub
            End If
        Next
        Try
            Dim fecha As Date = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
        Catch ex As Exception
            MsgBox("Verifique la Fecha", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End Try
        'For i = 0 To gitems.RowCount - 2
        '    Try
        '        If gitems.Item(3, i).Value.ToString <> "" Then
        '            Guardar(i)
        '            If gitems.Item(3, i).Value.ToString <> txtcuenta.Text Then
        '                Try
        '                    GuardarPresup(i)
        '                Catch ex As Exception
        '                    MsgBox("Error al ingresar en presupuesto")
        '                End Try
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next

        ''****************** ACTUALIZAR CONSECUTIVO **********************
        'MiConexion(bda)
        'myCommand.Parameters.Clear()
        'myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
        'myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
        'myCommand.CommandText = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
        'myCommand.ExecuteNonQuery()

        'MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        gitems.ReadOnly = True
        Cerrar()
        '...limpiar
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        'cmdver.Enabled = True

        'txtDoc.Text = ""
        'TxtDocumento.Text = ""
        'TxtNumero.Text = ""
        'txtdb.Text = Moneda(0)
        'txtcr.Text = Moneda(0)
        'txtdif.Text = Moneda(0)
        'gitems.Rows.Clear()
        'gitems.ReadOnly = True
        'CmdCancelar_Click(AcceptButton, AcceptButton)

        EnviarD()
        Me.Close()

    End Sub
    Private Sub GuardarPresup(ByVal fil As Integer)

        MiConexion(bda)
        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim cta As String = ""
        Dim ing As String = ""
        Dim val As Double = 0
        Dim f As String = Strings.Right(txtperiodo.Text, 4) & cbper.Text & txtdia.Text

        ' cta = txtcuenta.Text

        If gitems.Item(8, fil).Value <> "" Then
            If CDbl(gitems.Item(1, fil).Value) <> 0 Then ' debito
                MovPresup(pbd, gitems.Item(8, fil).Value, CDbl("-" & gitems.Item(1, fil).Value), f, gitems.Item(7, fil).Value.ToString)
            Else
                MovPresup(pbd, gitems.Item(8, fil).Value, CDbl(gitems.Item(2, fil).Value), f, gitems.Item(7, fil).Value.ToString)
            End If
        End If
        'Dim tp As New DataTable
        'tp.Clear()
        'myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
        '& " WHERE v.ingv_credito='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tp)
        'If tp.Rows.Count = 0 Then Exit Sub


        'For i = 0 To gitems.RowCount - 2
        '    Try
        '        If gitems.Item(3, i).Value.ToString <> "" And gitems.Item(3, i).Value.ToString <> txtcuenta.Text Then
        '            'If gitems.Item(3, i).Value.ToString Like 4 & "*" Then
        '            If CDbl(gitems.Item(1, i).Value) <> 0 Then ' debito
        '                MovPresup(pbd, tp.Rows(0).Item(1), CDbl("-" & gitems.Item(1, i).Value), f, gitems.Item(7, i).Value.ToString)
        '            Else
        '                MovPresup(pbd, tp.Rows(0).Item(1), CDbl(gitems.Item(2, i).Value), f, gitems.Item(7, i).Value.ToString)
        '            End If
        '            'MovPresup(pbd, tp.Rows(0).Item(1), CDbl(gitems.Item(2, fila).Value), f, gitems.Item(7, fila).Value.ToString)
        '            'End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next
        Cerrar()
    End Sub
    Private Sub MovPresup(ByVal pbd As String, ByVal ing As String, ByVal val As Double, ByVal f As String, ByVal nit As String)

        Try
            'Guardar MovIng
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                            & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                            & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                            & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & cbper.Text & "/" & txtperiodo.Text & "-" & TxtDocumento.Text & TxtNumero.Text & "' )"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
           & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
           & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
           & "   " & f & ", '" & ing & "',  'RECAUDO POR " & cbper.Text & "/" & txtperiodo.Text & "-" & TxtDocumento.Text & TxtNumero.Text & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
           & " '',  '',  'sae_cbanco', '" & cbper.Text & "/" & txtperiodo.Text & "-" & TxtDocumento.Text & TxtNumero.Text & "', '" & nit & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
            myCommand.ExecuteNonQuery()
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
                                        & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & cbper.Text & "/" & txtperiodo.Text & "-" & TxtDocumento.Text & TxtNumero.Text & "' )"
                        myCommand.ExecuteNonQuery()

                    Next
                End If

            Next
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try
    End Sub
    Public Sub Guardar(ByVal fila As Integer)


        Dim fecha As Date = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
        Dim diasv
        'Try
        '    If gitems.Item(5, fila).Value = "0" Then
        '        fecha = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
        '    Else
        '        fecha = fecha.AddDays(Val(gitems.Item(5, fila).Value))
        '    End If
        'Catch ex As Exception
        '    fecha = "(NINGUNA)"
        'End Try
        'Try
        '    If Val(gitems.Item(5, fila).Value) = 0 Then
        '        diasv = 0
        '    Else
        '        diasv = Val(gitems.Item(5, fila).Value)
        '    End If
        'Catch ex As Exception
        '    diasv = 0
        'End Try
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", TxtNumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
        myCommand.Parameters.AddWithValue("?periodo", cbper.Text & "/" & txtperiodo.Text)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
        Try
            myCommand.Parameters.AddWithValue("?centro", gitems.Item(8, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?centro", "0")
        End Try
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(gitems.Item(0, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(gitems.Item(1, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(gitems.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", gitems.Item(3, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(gitems.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", diasv)
        myCommand.Parameters.AddWithValue("?fechaven", CambiaCadena(Trim(fecha.ToString), 10))
        Try
            myCommand.Parameters.AddWithValue("?cheque", gitems.Item(9, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cheque", "")
        End Try
        myCommand.Parameters.AddWithValue("?nit", gitems.Item(7, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?modulo", "Bancos")
        myCommand.CommandText = "INSERT INTO documentos" & cbper.Text & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
        Cerrar()

    End Sub
    Public col, fila, FinEdit As Integer
    Dim vl As String
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        If e.RowIndex >= gitems.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 1
                    vl = Moneda(gitems.Item("Deb", e.RowIndex).Value)
                Case 2
                    vl = Moneda(gitems.Item("Cred", e.RowIndex).Value)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        If e.RowIndex >= gitems.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0
                    Try
                        gitems.Item("gdes", e.RowIndex).Value = UCase(gitems.Item("gdes", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("gdes", e.RowIndex).Value = ""
                    End Try
                Case 1
                    Try
                        gitems.Item("gDeb", e.RowIndex).Value = Moneda(gitems.Item("gDeb", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("gDeb", e.RowIndex).Value = Moneda(0)
                    End Try
                Case 2
                    Try
                        gitems.Item("gCred", e.RowIndex).Value = Moneda(gitems.Item("gCred", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("gCred", e.RowIndex).Value = Moneda(0)
                    End Try
                Case 3
                    Buscarcuentas(gitems.Item(3, e.RowIndex).Value, e.RowIndex)
                Case 4
                    Try
                        gitems.Item("gBase", e.RowIndex).Value = Moneda(gitems.Item("gBase", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("gBase", e.RowIndex).Value = Moneda(0)
                    End Try
                Case 7
                    BuscarNit(gitems.Item(7, e.RowIndex).Value, e.RowIndex)
                Case 8
                    BuscarRubr(gitems.Item(8, e.RowIndex).Value, e.RowIndex)

            End Select
        Catch ex As Exception
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuenta()
        saldoAj()
        diferenc()
    End Sub
    Public Sub BuscarNit(ByVal nit As String, ByVal fila As Integer)
        Try
            If Trim(nit) = "" Then
                FrmSelCliente.lbform.Text = "doccon"
                FrmSelCliente.lbfila.Text = fila
                FrmSelCliente.ShowDialog()
            Else
                Dim items As Integer
                Dim tabla, tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & Trim(nit) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula " & nit & " del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(nit)
                        gitems.Item(7, fila).Value = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "doccon"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit...", MsgBoxStyle.Information, "SAE Información")
                        gitems.Item(7, fila).Value = ""
                    End If
                Else
                    gitems.Item(7, fila).Value = Trim(nit)
                End If
            End If
           
        Catch ex As Exception
        End Try
    End Sub
    Private Sub saldoAj()

        Try
            Dim sumadb, sumacr, db, cr As Double
            sumadb = 0
            sumacr = 0
            For i = 0 To gitems.RowCount - 1
                If gitems.Item(3, i).Value = txtcuenta.Text Then
                    Try
                        db = CDbl(gitems.Item(1, i).Value)
                    Catch ex As Exception
                        db = 0
                    End Try
                    Try
                        cr = CDbl(gitems.Item(2, i).Value)
                    Catch ex As Exception
                        cr = 0
                    End Try
                    sumadb = db - cr
                End If
            Next
            txtsalcon.Text = Moneda(sumadb)
            txtsaldo.Text = Moneda(CDbl(txtsalB2.Text) + CDbl(txtsalcon.Text))
        Catch ex As Exception
            MsgBox("Error al sacar diferencia 2" & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try

    End Sub
    Private Sub diferenc()
        Try
            txtdifsal.Text = Moneda(CDbl(txtsaldo.Text) - CDbl(txtsalB.Text))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "DocConciBancaria"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If gitems.Item(3, fila).Value = "" Or FrmEntradaDatos.nivel_cuenta(gitems.Item(3, fila).Value) = True Then
                    gitems.Item(3, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "DocConciBancaria"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    SendKeys.Send(Chr(Keys.Tab))
                    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                    resultado = MsgBox("La cuenta (" & gitems.Item(3, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                    If resultado = MsgBoxResult.Yes Then
                        FrmNuevaCuenta.txtcuenta.Text = gitems.Item(3, fila).Value
                        gitems.Item(3, fila).Value = ""
                        FrmNuevaCuenta.lbfila.Text = fila
                        FrmNuevaCuenta.ShowDialog()
                    Else
                        gitems.Item(3, fila).Value = ""
                    End If
                End If
            Else
                gitems.Item(4, fila).Selected = True
            End If
        End If

    End Sub
    Private Sub BuscarRubr(ByVal rb As String, ByVal fl As Integer)

        Dim a As String = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        myCommand.CommandText = " select " & cm & ", c.ingc_concepto, c.ingc_cod1 , c.ingc_sd, v.ingv_credito, v.ingv_contrac " _
        & " from presupuesto" & a & ".ingconcepto c, presupuesto" & a & ".ingvalores v " _
        & " where " & cm & " = '" & Trim(rb) & "' AND c.ingc_sd='D' and c.ingc_cod1= v.ingv_cod1"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            gitems.Item(8, fl).Value = tabla.Rows(0).Item("ingc_cod1")
            'txtnomrb.Text = tabla.Rows(0).Item("ingc_concepto")
            'txtcred.Text = tabla.Rows(0).Item("ingv_contrac")
            'txtdeb.Text = tabla.Rows(0).Item("ingv_credito")
        Else
            Try
                Try
                    gitems.Item(8, fl).Value = ""
                Catch ex As Exception
                End Try
                FrmSelRubrIng.lbfila.Text = fl
                FrmSelRubrIng.lbform.Text = "concB"
                FrmSelRubrIng.lbcm.Text = cm
                FrmSelRubrIng.grub.Enabled = True
                FrmSelRubrIng.r1.Checked = True
                FrmSelRubrIng.ShowDialog()
                FrmSelRubrIng.grub.Enabled = False
                FrmSelRubrIng.r1.Checked = True
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        ValoresDefecto(e.RowIndex)
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION 
                    'If filaAnt < fila And FinEdit = 1 Then
                    '    Posicionar(1)
                    'End If
                Case 1  'CASO DEBITO 
                Case 2  'CASO CREDITO                     
                Case 3 'CASO CUENTA 
                    If gitems.Item(3, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 4 'CASO BASE                     
                Case 5 'CASO DIAS                     
                Case 6 'CASO FECHA                    
                Case 7 'CASO NIT 
                    If gitems.Item(7, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 8 'CASO NIT 
                    If gitems.Item(8, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If gitems.Item(1, i).Value.ToString = "" Then
                gitems.Item(1, i).Value = "0,00"
            End If
        Catch ex As Exception
            gitems.Item(1, i).Value = "0,00"
        End Try
        Try
            If gitems.Item(2, i).Value.ToString = "" Then
                gitems.Item(2, i).Value = "0,00"
            End If
        Catch ex As Exception
            gitems.Item(2, i).Value = "0,00"
        End Try
        Try
            If gitems.Item(4, i).Value.ToString = "" Then
                gitems.Item(4, i).Value = "0,00"
            End If
        Catch ex As Exception
            gitems.Item(4, i).Value = "0,00"
        End Try
        Dim fec As Date
        Try
            fec = CDate(Now.Day & "/" & PerActual)
        Catch ex As Exception
            fec = CDate("01" & "/" & PerActual)
        End Try
        Try
            If Trim(gitems.Item(5, i).Value.ToString) = "" Then
                gitems.Item(5, i).Value = Val(0)
                gitems.Item(6, i).Value = fec.AddDays(Val(0))
            End If
        Catch ex As Exception
            Try
                gitems.Item(5, i).Value = Val(0)
                gitems.Item(6, i).Value = fec.AddDays(Val(0))
            Catch ex2 As Exception
                gitems.Item(5, i).Value = "0"
                gitems.Item(6, i).Value = fec
            End Try
        End Try
        ''Try
        ''    If gitems.Item(7, i).Value.ToString = "" And Trim(txtbanco.Text) <> "" Then
        ''        gitems.Item(7, i).Value = txtnit.Text
        ''    End If
        ''Catch ex As Exception
        ''    If Trim(txtbanco.Text) <> "" Then
        ''        gitems.Item(7, i).Value = txtnit.Text
        ''    End If
        ''End Try
        Try
            If gitems.Item(8, i).Value = "" Then
                gitems.Item(8, i).Value = ""
            End If
        Catch ex As Exception
            gitems.Item(8, i).Value = ""
        End Try
        'gitems.Item(8, i).Value = "0"
        'Try
        '    If Trim(gitems.Item(8, i).Value.ToString) = "" And Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then

        '    End If
        'Catch ex As Exception
        '    If Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then
        '        gitems.Item(8, i).Value = txtcentro.Text
        '    End If
        'End Try
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        'If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If CmdListo.Enabled = True Then
            If fila = gitems.RowCount - 1 Then Exit Sub
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
            If resultado = MsgBoxResult.Yes Then
                gitems.Rows.RemoveAt(fila)
                SacarCuenta()
                saldoAj()
                diferenc()
            End If
        End If
    End Sub

    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = 8 Then
            If fila = gitems.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        End If
    End Sub
    Public Sub SacarCuenta()
        Try
            Dim sumadb, sumacr, db, cr As Double
            sumadb = 0
            sumacr = 0
            For i = 0 To gitems.RowCount - 1
                Try
                    db = CDbl(gitems.Item(1, i).Value)
                Catch ex As Exception
                    db = 0
                End Try
                Try
                    cr = CDbl(gitems.Item(2, i).Value)
                Catch ex As Exception
                    cr = 0
                End Try
                sumadb = sumadb + db
                sumacr = sumacr + cr
            Next
            txtdb.Text = sumadb
            txtdb.Text = Moneda(txtdb.Text)
            txtcr.Text = sumacr
            txtcr.Text = Moneda(txtcr.Text)
            txtdif.Text = sumadb - sumacr
            txtdif.Text = Moneda(txtdif.Text)
            If (sumadb - sumacr) = 0 Then txtdif.Text = "0,00"
        Catch ex As Exception
            MsgBox("Error al sacar diferencia " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try
    End Sub

    Private Sub FrmDocConciliaB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        txtDoc.Text = ""
        TxtDocumento.Text = ""
        TxtNumero.Text = ""
        txtdb.Text = Moneda(0)
        txtcr.Text = Moneda(0)
        txtdif.Text = Moneda(0)
        gitems.Rows.Clear()
        txtsalcon.Text = Moneda(0)
        txtsaldo.Text = txtsalB2.Text
        gitems.ReadOnly = True
    End Sub
End Class