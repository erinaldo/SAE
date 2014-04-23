Public Class FrmDesenglobarCta
    Dim fila As Integer
    Dim col As Integer
    Dim FinEdit As Integer

    Private Sub FrmDesenglobarCta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grilla.RowCount = 1
        Try
            grilla.Rows.Clear()
        Catch ex As Exception
        End Try
        BuscarCta(-1)
    End Sub
    Public Sub BuscarCta(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            If f = -1 Then
                myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & lbcta.Text & "';"
            Else
                myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & grilla.Item("Cuenta", f).Value.ToString & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcta2.Text = tabla.Rows(0).Item("codigo").ToString & " " & tabla.Rows(0).Item("descripcion").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbcta2.Text = ""
        End Try
        Try
            Dim tabla As New DataTable
            If f = -1 Then
                myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ape FROM terceros WHERE nit='" & FrmCompEgreCpp.txtnit.Text & "';"
            Else
                myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ape FROM terceros WHERE nit='" & grilla.Item("Nit", f).Value.ToString & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbter.Text = grilla.Item("Nit", f).Value.ToString & "  " & tabla.Rows(0).Item("ape").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            'txtnit.Text = ""
            lbter.Text = ""
        End Try
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item(1, i).Value.ToString = "" Then
                grilla.Item(1, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(1, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(2, i).Value.ToString = "" Then
                grilla.Item(2, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(2, i).Value = "0,00"
        End Try
        'Try
        '    If grilla.Item(3, i).Value.ToString = "" Then
        '        grilla.Item(3, i).Value = lbcta.Text
        '    End If
        'Catch ex As Exception
        '    grilla.Item(3, i).Value = lbcta.Text
        'End Try
        Try
            If grilla.Item(4, i).Value.ToString = "" Then
                grilla.Item(4, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(4, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(5, i).Value.ToString = "" Then
                grilla.Item(5, i).Value = FrmCompEgreCpp.txtnit.Text
            End If
        Catch ex As Exception
            grilla.Item(5, i).Value = FrmCompEgreCpp.txtnit.Text
        End Try
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        ValoresDefecto(e.RowIndex)
        BuscarCta(fila)
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION 
                    'If filaAnt < fila And FinEdit = 1 Then
                    '    Posicionar(1)
                    'End If
                Case 1  'CASO DEBITO 
                Case 2  'CASO CREDITO                     
                Case 3 'CASO CUENTA 
                    If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 4 'CASO BASE                     
                Case 5 'CASO NIT 
                    If grilla.Item(5, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Public Sub QuitarFila(ByVal fila)
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
            SacarCuenta()
        End If
    End Sub
    Public Sub SacarCuenta()

    End Sub
    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 And e.ColumnIndex <> 8 Then
            FinEdit = 0
            If e.ColumnIndex = 4 Then
                SendKeys.Send("{HOME}")
            Else
                SendKeys.Send(Chr(Keys.Tab))
                e.Cancel = True
            End If

        End If
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            If e.RowIndex > 0 And UCase(grilla.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "FF" Then
                grilla.Item(e.ColumnIndex, e.RowIndex).Value = grilla.Item(e.ColumnIndex, e.RowIndex - 1).Value
                ValoresDefecto(e.RowIndex)
                SacarCuenta()
                Exit Sub
            End If
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION                       
                    grilla.Item(0, e.RowIndex).Value = UCase(grilla.Item(0, e.RowIndex).Value)
                Case 1  'CASO DEBITO                    
                    grilla.Item(1, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(1, e.RowIndex).Value.ToString), 2)
                    If grilla.Item(1, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 2  'CASO CREDITO 
                    If CDbl(grilla.Item(2, e.RowIndex).Value) = 0 Then
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(2, e.RowIndex).Value.ToString), 2)
                        grilla.Item(1, e.RowIndex).Value = "0,00"
                    End If
                Case 3 'CASO CUENTA
                    Buscarcuentas(grilla.Item(3, e.RowIndex).Value, e.RowIndex)
                Case 4 'CASO BASE
                    grilla.Item(4, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(4, e.RowIndex).Value.ToString), 2)
                Case 5 'CASO NIT
                    grilla.Item(7, e.RowIndex).Value = Replace(grilla.Item(5, e.RowIndex).Value.ToString, ".", "")
                    grilla.Item(7, e.RowIndex).Value = Replace(grilla.Item(5, e.RowIndex).Value.ToString, "-", "")
                    BuscarNit(grilla.Item(5, e.RowIndex).Value, e.RowIndex)

            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION            
                Case 1  'CASO DEBITO
                    If grilla.Item(1, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(1, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(1, e.RowIndex).Value = "0,00"
                Case 2  'CASO CREDITO  
                    If grilla.Item(2, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 3 'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(3, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex)
                Case 4 'CASO BASE
                    If grilla.Item(4, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor de la base. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(4, e.RowIndex).Value = "0,00"
                Case 5 'CASO NIT
                    'MsgBox("Error al digitar el nit. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(5, e.RowIndex).Value = ""
                    BuscarNit("", e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuenta()
    End Sub
    Public Sub BuscarNit(ByVal nit As String, ByVal fila As Integer)
        Try
            If Trim(nit) = "" Then
                FrmSelCliente.lbform.Text = "DesCta"
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
                        grilla.Item(5, fila).Value = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "DesCta"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit...", MsgBoxStyle.Information, "SAE Información")
                        grilla.Item(5, fila).Value = ""
                    End If
                Else
                    grilla.Item(5, fila).Value = Trim(nit)
                End If
            End If
            SendKeys.Send(Chr(Keys.Tab))
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "DesCta"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                'If Trim(grilla.Item(3, fila).Value) = "" Then
                grilla.Item(3, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "DesCta"
                FrmCuentas.lbfila.Text = fila
                If cuenta <> "" Then
                    FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                End If
                FrmCuentas.ShowDialog()
                'Else
                '    SendKeys.Send(Chr(Keys.Tab))
                '    grilla.Item(3, fila).Value = ""
                'End If
            Else
                grilla.Item(4, fila).Selected = True
            End If
        End If

    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Validar()
    End Sub
    Public Sub Validar()
        Dim t1 As Double = 0
        Try
            t1 = CDbl(lbdb.Text)
        Catch ex As Exception
        End Try
        Try
            t1 = t1 - CDbl(lbcr.Text)
        Catch ex As Exception
        End Try
        Dim d As Double = 0
        Dim c As Double = 0
        Dim t2 As Double = 0
        For i = 0 To grilla.RowCount - 1
            Try
                d = CDbl(grilla.Item(1, i).Value.ToString)
            Catch ex As Exception
                d = 0
            End Try
            Try
                c = CDbl(grilla.Item(2, i).Value.ToString)
            Catch ex As Exception
                c = 0
            End Try
            t2 = t2 + (d - c)
            Try
                If grilla.Item("Cuenta", i).Value.ToString = "" And i < grilla.RowCount - 1 Then
                    MsgBox("Favor Verifique, las cuentas de los movimientos.")
                    grilla.Focus()
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            
        Next
        If t1 <> t2 Then
            MsgBox("Favor Verifique, los movimientos realizados no pueden ser diferente a los de la cuenta a desenglobar.")
            grilla.Focus()
            Exit Sub
        End If
        PreGuardar()
    End Sub
    Public Sub PreGuardar()
        Try
            Dim f As Integer = Val(lbfila.Text)
            Dim docafe As String = ""
            Try
                docafe = FrmCompEgreCpp.grilla.Item("doc_afe", f).Value.ToString
            Catch ex As Exception
            End Try
            FrmCompEgreCpp.grilla.Rows.RemoveAt(f)
            f = FrmCompEgreCpp.grilla.RowCount - 1
            FrmCompEgreCpp.grilla.RowCount = FrmCompEgreCpp.grilla.RowCount + grilla.RowCount
            Dim j As Integer = -1
            For i = f To FrmCompEgreCpp.grilla.RowCount - 1
                j = j + 1
                Try
                    If grilla.Item("Cuenta", j).Value <> "" Then
                        FrmCompEgreCpp.grilla.Item("Descripcion", i).Value = grilla.Item("Descripcion", j).Value
                        FrmCompEgreCpp.grilla.Item("Cuenta", i).Value = grilla.Item("Cuenta", j).Value
                        FrmCompEgreCpp.grilla.Item("Debitos", i).Value = grilla.Item("Debitos", j).Value
                        FrmCompEgreCpp.grilla.Item("Creditos", i).Value = grilla.Item("Creditos", j).Value
                        FrmCompEgreCpp.grilla.Item("Debitos", i).Value = grilla.Item("Debitos", j).Value
                        FrmCompEgreCpp.grilla.Item("Base", i).Value = grilla.Item("Base", j).Value
                        '**************************************************************************************
                        FrmCompEgreCpp.grilla.Item("doc_afe", i).Value = docafe
                        If docafe = "" Then
                            FrmCompEgreCpp.grilla.Item("abonado", i).Value = "0,00"
                        Else
                            If lbdb.Text <> "0,00" Then
                                FrmCompEgreCpp.grilla.Item("abonado", i).Value = lbdb.Text
                            Else
                                FrmCompEgreCpp.grilla.Item("abonado", i).Value = lbcr.Text
                            End If
                        End If
                        FrmCompEgreCpp.grilla.Item("editar", i).Value = "no"
                        FrmCompEgreCpp.grilla.Item("DocAnti", i).Value = ""
                        FrmCompEgreCpp.grilla.Item("otro", i).Value = ""
                    End If
                Catch ex As Exception
                    Exit For
                End Try
            Next
            MiConexion(bda)
            Eliminar()
            If docafe <> "" Then
                BucarCP(docafe)
            End If
            Try
                For i = 0 To FrmCompEgreCpp.grilla.RowCount - 1
                    GuardarContable(i)
                    Guardar(i)
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BucarCP(ByVal cp As String)
        Dim per As String = ""
        Dim num As Integer = 0
        Dim sql As String = ""
        Dim cad As String = ""
        Try
            ' MsgBox(Mid(cp, 3))
            num = Val(Mid(cp, 3))
        Catch ex As Exception

        End Try
        Dim tabla As New DataTable
        If lbdb.Text <> "0,00" Then
            cad = "AND credito=" & DIN(lbdb.Text) & ""
        Else
            cad = "AND debito=" & DIN(lbcr.Text) & ""
        End If
        Try
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                tabla.Clear()
                sql = "SELECT * FROM documentos" & per & " WHERE tipodoc='" & cp(0) & cp(1) & "' " _
                & "AND doc='" & num & "' AND codigo='" & lbcta.Text & "' " & cad & ";"
                myCommand.CommandText = sql
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                If tabla.Rows.Count > 0 Then
                    MsgBox("entro a buscar cp " & per)
                    EliminarCP(per, cp(0) & cp(1), num, tabla.Rows(0).Item("item"))
                    For j = 0 To grilla.RowCount - 1
                        ModificarCP(j, tabla.Rows(0).Item("item"), num, cp(0) & cp(1), per, tabla.Rows(0).Item("dia"))
                    Next
                    Exit For
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub EliminarCP(ByVal per As String, ByVal cp As String, ByVal num As String, ByVal it As String)
        Try
            Dim Sql As String = "DELETE FROM documentos" & per & " WHERE tipodoc='" & cp & "' " _
               & "AND doc='" & num & "' AND item='" & it & "';"
            myCommand.CommandText = Sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ModificarCP(ByVal fila As Integer, ByVal it As Integer, ByVal num As String, ByVal cp As String, ByVal per As String, ByVal dia As String)
        Dim p As String = per & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", it)
            myCommand.Parameters.AddWithValue("?doc", num)
            myCommand.Parameters.AddWithValue("?tipodoc", cp)
            myCommand.Parameters.AddWithValue("?periodo", p)
            myCommand.Parameters.AddWithValue("?dia", dia)
            myCommand.Parameters.AddWithValue("?centro", "0")
            myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(0, fila).Value.ToString, 50))
            myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(1, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item(3, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
            myCommand.Parameters.AddWithValue("?nit", FrmCompEgreCpp.txtnit.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "ctas x pagar")
            myCommand.CommandText = "INSERT INTO documentos" & per & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Eliminar()
        Dim Sql, tabla As String
        '**************** ACTUALIZO CONTABILIDAD (ESTO SOLO SUCEDE SI EXISTE EL DOCUMENTO) **********************************
        tabla = "documentos" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(lbnum.Text) & " AND tipodoc='" & lbdoc.Text & "';"
        Ejecutar(Sql)
        '***************** ELINIAR LOS DATOS DEL COMPROBANTE PARA VOLVER A INSERTAR *******************************************
        tabla = "ot_cpp" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc='" & lbdoc.Text & lbnum.Text & "';"
        Ejecutar(Sql)
    End Sub
    Public Sub Ejecutar(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Public Sub GuardarContable(ByVal fila As Integer)
        ct = 0
        ct = ct + 1
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", FrmCompEgreCpp.txtnumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", FrmCompEgreCpp.lbdoc.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", FrmCompEgreCpp.txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?centro", Val(FrmCompEgreCpp.txtcentro.Text))
            myCommand.Parameters.AddWithValue("?desc", CambiaCadena(FrmCompEgreCpp.grilla.Item(1, fila).Value.ToString, 50))
            myCommand.Parameters.AddWithValue("?debito", DIN(FrmCompEgreCpp.grilla.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(FrmCompEgreCpp.grilla.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?codigo", FrmCompEgreCpp.grilla.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?base", DIN(FrmCompEgreCpp.grilla.Item(4, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
            myCommand.Parameters.AddWithValue("?nit", FrmCompEgreCpp.txtnit.Text)
            If FrmCompEgreCpp.grilla.Item("Descripcion", fila).Value.ToString = FrmCompEgreCpp.lbcliente.Text Then
                If FrmCompEgreCpp.lbfp.Text = "Cheque No." And FrmCompEgreCpp.txtcheque.Text <> "" Then
                    myCommand.Parameters.AddWithValue("?cheque", FrmCompEgreCpp.txtcheque.Text)
                Else
                    myCommand.Parameters.AddWithValue("?cheque", "")
                End If
            Else
                myCommand.Parameters.AddWithValue("?cheque", "")
            End If
            myCommand.Parameters.AddWithValue("?modulo", "ctas x pagar")
            myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            
        End Try
    End Sub
    Public Sub Guardar(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", FrmCompEgreCpp.lbdoc.Text & FrmCompEgreCpp.txtnumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?grupo", "CE")
            myCommand.Parameters.AddWithValue("?tipodoc", FrmCompEgreCpp.lbdoc.Text)
            myCommand.Parameters.AddWithValue("?num", Val(FrmCompEgreCpp.txtnumero.Text.ToString))
            'Try
            myCommand.Parameters.AddWithValue("?doc_afec", FrmCompEgreCpp.grilla.Item("doc_afe", fila).Value.ToString)
            'Catch ex As Exception
            '    myCommand.Parameters.AddWithValue("?doc_afec", "")
            'End Try
            myCommand.Parameters.AddWithValue("?dia", FrmCompEgreCpp.txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?ciudad", FrmCompEgreCpp.txtciudad.Text.ToString)
            myCommand.Parameters.AddWithValue("?concepto", FrmCompEgreCpp.txtconcepto.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitc", FrmCompEgreCpp.txtnit.Text)
            If FrmCompEgreCpp.rbcc.Checked = True Then
                myCommand.Parameters.AddWithValue("?tn", "CC")
            Else
                myCommand.Parameters.AddWithValue("?tn", "NIT")
            End If
            myCommand.Parameters.AddWithValue("?codigo", FrmCompEgreCpp.grilla.Item(0, fila).Value.ToString)
            myCommand.Parameters.AddWithValue("?desc", CambiaCadena(FrmCompEgreCpp.grilla.Item(1, fila).Value.ToString, 99))
            myCommand.Parameters.AddWithValue("?debito", DIN(FrmCompEgreCpp.grilla.Item(2, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?credito", DIN(FrmCompEgreCpp.grilla.Item(3, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?base", DIN(FrmCompEgreCpp.grilla.Item(4, fila).Value).ToString)
            myCommand.Parameters.AddWithValue("?total", DIN(FrmCompEgreCpp.txtvalor.Text).ToString)
            If FrmCompEgreCpp.chefectivo.Checked = True Then
                myCommand.Parameters.AddWithValue("?tipo_pago", "efectivo")
                myCommand.Parameters.AddWithValue("?cheque", "")
                myCommand.Parameters.AddWithValue("?banco", "")
                myCommand.Parameters.AddWithValue("?sucursal", "")
            ElseIf FrmCompEgreCpp.lbfp.Text = "Tarjeta" Then
                myCommand.Parameters.AddWithValue("?tipo_pago", "tarjeta")
                myCommand.Parameters.AddWithValue("?cheque", FrmCompEgreCpp.txtcheque.Text)
                myCommand.Parameters.AddWithValue("?banco", FrmCompEgreCpp.txtbanco.Text)
                myCommand.Parameters.AddWithValue("?sucursal", FrmCompEgreCpp.txtsucursal.Text)
            ElseIf FrmCompEgreCpp.lbfp.Text = "Consignacion No." Or FrmCompEgreCpp.lbfp.Text = "consignacion" Or FrmCompEgreCpp.lbfp.Text = "consignacion" Then
                myCommand.Parameters.AddWithValue("?tipo_pago", "consig")
                myCommand.Parameters.AddWithValue("?cheque", FrmCompEgreCpp.txtcheque.Text)
                myCommand.Parameters.AddWithValue("?banco", FrmCompEgreCpp.txtbanco.Text)
                myCommand.Parameters.AddWithValue("?sucursal", FrmCompEgreCpp.txtsucursal.Text)
            Else
                myCommand.Parameters.AddWithValue("?tipo_pago", "cheque")
                myCommand.Parameters.AddWithValue("?cheque", FrmCompEgreCpp.txtcheque.Text)
                myCommand.Parameters.AddWithValue("?banco", FrmCompEgreCpp.txtbanco.Text)
                myCommand.Parameters.AddWithValue("?sucursal", FrmCompEgreCpp.txtsucursal.Text)
            End If
            '*********************************************************
            myCommand.Parameters.AddWithValue("?ccosto", Val(FrmCompEgreCpp.txtcentro.Text))
            myCommand.Parameters.AddWithValue("?fecha", FrmCompEgreCpp.fecha.Value)
            myCommand.Parameters.AddWithValue("?elaborado", CambiaCadena(FrmCompEgreCpp.txtelaborado.Text, 50))
            myCommand.Parameters.AddWithValue("?autorizado", CambiaCadena(FrmCompEgreCpp.txtaprobado.Text, 50))
            myCommand.Parameters.AddWithValue("?revisado", "")
            myCommand.Parameters.AddWithValue("?contabilizado", CambiaCadena(FrmCompEgreCpp.txtconta.Text, 50))
            myCommand.Parameters.AddWithValue("?doc_aj", " ")
            myCommand.Parameters.AddWithValue("?estado", FrmCompEgreCpp.cbaprobado.Text)
            myCommand.Parameters.AddWithValue("?abonado", DIN(FrmCompEgreCpp.grilla.Item("abonado", fila).Value).ToString)
            Try
                myCommand.Parameters.AddWithValue("?doc_anti", FrmCompEgreCpp.grilla.Item("DocAnti", fila).Value.ToString)
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?doc_anti", "")
            End Try
            '************* GUARDAR CONSULTA *********************************************
            myCommand.CommandText = "INSERT INTO ot_cpp" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?tipo_pago,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?estado,?abonado,?doc_anti);"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception

        End Try
    End Sub

End Class