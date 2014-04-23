Public Class FrmItemCartera

    Private Sub FrmItemCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim tabla As New DataTable
            'myCommand.CommandText = "SELECT par_rc, par_ci, par_aju FROM car_par;"
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(tabla)
            'Refresh()
            'If tabla.Rows.Count = 0 Then
            '    MsgBox("No han definido documentos para esta interfaz.  ", MsgBoxStyle.Information, "SAE Control")
            '    Me.Close()
            'End If
            'Dim t As String = txttipo.Text
            'txttipo.Items.Clear()
            'If Trim(tabla.Rows(0).Item("par_rc")) <> "" Then
            '    txttipo.Items.Add(Trim(tabla.Rows(0).Item(0)))
            'End If
            'If Trim(tabla.Rows(0).Item("par_ci")) <> "" Then
            '    txttipo.Items.Add(Trim(tabla.Rows(0).Item(1)))
            'End If
            'Try
            '    lbdoc_aj.Text = Trim(tabla.Rows(0).Item(2))
            'Catch ex As Exception
            '    lbdoc_aj.Text = ""
            'End Try
            If FrmReciboCartera.txttipo.Text <> "" Then
                txttipo.Items.Add(FrmReciboCartera.txttipo.Text)
                'Else
                '    txttipo.Text = t
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT hay_int FROM car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows(0).Item(0) = "NO" Then
            gitems.Columns("interes").ReadOnly = True
        Else
            gitems.Columns("interes").ReadOnly = False
        End If

        If FrmReciboCartera.lbedcc.Text = "NO" Then
            gitems.Columns("comision").ReadOnly = True
        Else
            gitems.Columns("comision").ReadOnly = False
        End If

        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        If txtcliente.Text <> "" And FrmReciboCartera.grilla.RowCount <= 1 Then
            BuscarFacturas()
        Else
            cargarconceptos()
        End If
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Private Sub cargarconceptos()

        cbconcepto.Items.Clear()
        cbsr.Items.Clear()
        cbvalor.Items.Clear()
        cbcuenta.Items.Clear()
        cbbase.Items.Clear()
        cbldoc.Items.Clear()

        For i = 0 To FrmReciboCartera.grilla.RowCount - 1
            If FrmReciboCartera.grilla.Item("otro", i).Value = "/" Then
                cbconcepto.Items.Add(FrmReciboCartera.grilla.Item("Descripcion", i).Value)
                cbcuenta.Items.Add(FrmReciboCartera.grilla.Item("Cuenta", i).Value)
                If FrmReciboCartera.grilla.Item("Debitos", i).Value <> Moneda(0) Then
                    cbsr.Items.Add("+")
                Else
                    cbsr.Items.Add("-")
                End If
                If FrmReciboCartera.grilla.Item("Debitos", i).Value <> Moneda(0) Then
                    cbvalor.Items.Add(Moneda(FrmReciboCartera.grilla.Item("Debitos", i).Value))
                Else
                    cbvalor.Items.Add(Moneda(FrmReciboCartera.grilla.Item("Creditos", i).Value))
                End If
                cbbase.Items.Add(Moneda(FrmReciboCartera.grilla.Item("Base", i).Value))
                Try
                    cbldoc.Items.Add(FrmReciboCartera.grilla.Item("DocAnti", i).Value)
                Catch ex As Exception
                    cbldoc.Items.Add(" ")
                End Try
            End If
        Next
    End Sub
    '**********************************************
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarFacturas()
        End If
    End Sub
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "it_ce_cpc"
            FrmSelCliente.ShowDialog()
            If txtcliente.Text <> "" Then
                BuscarFacturas()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '**********************************************
    Public Sub BuscarFacturas()
        Dim fecha As Date = Today
        Try
            fecha = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("Verifique la fecha (dd/mm/yyyy) => " & txtdia.Text & txtperiodo.Text, MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End Try
        Try
            '--------------------- INTERES
            Dim td As String = ""
            Dim inte As Double = 0
            Dim num As Integer = 0
            Dim ctamor As String = ""
            Dim ti As New DataTable
            myCommand.CommandText = "SELECT if(hay_int='SI',mon_int/100,0) as inte, tip_int, cta_mor FROM car_par ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ti)
            Refresh()
            inte = ti.Rows(0).Item(0)
            If ti.Rows(0).Item(1) = "diarios" Then
                num = 1
                td = "DAY"
            ElseIf ti.Rows(0).Item(1) = "mensual" Then
                num = 1
                td = "MONTH"
            ElseIf ti.Rows(0).Item(1) = "mes/dia" Then
                num = 30
                td = "DAY"
            Else
                num = 1
                td = "YEAR"
            End If
            ctamor = ti.Rows(0).Item("cta_mor").ToString
            '--------------------------------
            '& " DATEDIFF( NOW(),ADDDATE(fecha, INTERVAL vmto " & td & ")),0) AS vmtos, " _

            '  " & Strings.Right(txtperiodo.Text, 4) & "-" & Strings.Mid(txtperiodo.Text, 2, 2) & "-" & txtdia.Text.ToString & "
            Dim f As String = fecha.Year.ToString & "-" & fecha.Month.ToString & "-" & fecha.Day.ToString
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc,fecha,concepto,total,(total - pagado) AS saldo,ctatotal, " _
            & " IF (NOW() > ADDDATE(fecha, INTERVAL vmto DAY), " _
            & " TIMESTAMPDIFF(" & td & ", ADDDATE(fecha, INTERVAL vmto DAY ),NOW()),0) as vmtos," _
            & " CAST(IFNULL((SELECT codcon FROM comicar WHERE nitv='" & FrmReciboCartera.txtnitv.Text & "' AND vmtos BETWEEN r1 AND r2),'')AS CHAR(10)) AS comi" _
            & " FROM cobdpen WHERE nitc ='" & txtnitc.Text & "' AND fecha<='" & f & "' AND total>pagado ORDER BY doc,fecha;"

            'myCommand.CommandText = "SELECT doc,fecha,concepto,total,(total - pagado) AS saldo,ctatotal, " _
            '& " IF (NOW() > ADDDATE(fecha, INTERVAL vmto DAY), " _
            '& " DATEDIFF(NOW() , ADDDATE(fecha, INTERVAL vmto DAY )),0) as vmtos," _
            '& " CAST(IFNULL((SELECT codcon FROM comicar WHERE nitv='" & FrmReciboCartera.txtnitv.Text & "' AND vmtos BETWEEN r1 AND r2),'')AS CHAR(10)) AS comi" _
            '& " FROM cobdpen WHERE nitc ='" & txtnitc.Text & "' AND fecha<='" & f & "' AND total>pagado ORDER BY doc,fecha;"




            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count - 1
            If items = -1 Then
                MsgBox("El Cliente no tiene facturas por Cobrar a la fecha (" & CambiaCadena(fecha.ToString, 10) & "). ", MsgBoxStyle.Information, "SAE Control")
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
                gitems.RowCount = 1
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            If tabla.Rows.Count = 1 Then
                gitems.RowCount = 2
                'gitems.Columns("num").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("doc").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("descrip").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("total_fact").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("saldo").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("abono").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("sel").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("interes").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("totalp").SortMode = DataGridViewColumnSortMode.NotSortable
                'gitems.Columns("comision").SortMode = DataGridViewColumnSortMode.NotSortable
            Else
                gitems.RowCount = tabla.Rows.Count
                'gitems.Columns("num").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("doc").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("fecha").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("descrip").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("total_fact").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("saldo").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("abono").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("sel").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("interes").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("totalp").SortMode = DataGridViewColumnSortMode.Automatic
                'gitems.Columns("comision").SortMode = DataGridViewColumnSortMode.Automatic
            End If

            For i = 0 To items
                gitems.Item("num", i).Value = i + 1
                gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc")
                gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
                gitems.Item("descrip", i).Value = tabla.Rows(i).Item("concepto")
                gitems.Item("total_fact", i).Value = Moneda(tabla.Rows(i).Item("total"))
                gitems.Item("saldo", i).Value = Moneda(tabla.Rows(i).Item("saldo"))
                gitems.Item("abono", i).Value = Moneda(tabla.Rows(i).Item("saldo"))
                gitems.Item("ctacpp", i).Value = tabla.Rows(i).Item("ctatotal")
                gitems.Item("ctapago", i).Value = lbctafp.Text
                gitems.Item("sel", i).Value = False
                gitems.Item("t1", i).Value = "/"
                gitems.Item("t2", i).Value = "/"
                gitems.Item("t3", i).Value = "/"
                If ti.Rows(0).Item(1) = "mes/dia" Then
                    gitems.Item("interes", i).Value = Moneda((tabla.Rows(i).Item("saldo") * (inte / num)) * tabla.Rows(i).Item("vmtos"))
                Else
                    gitems.Item("interes", i).Value = Moneda((tabla.Rows(i).Item("saldo") * inte) * tabla.Rows(i).Item("vmtos"))
                End If
                gitems.Item("totalp", i).Value = Moneda(tabla.Rows(i).Item("saldo") + gitems.Item("interes", i).Value)
                gitems.Item("ctaint", i).Value = ctamor
                gitems.Item("comision", i).Value = tabla.Rows(i).Item("comi").ToString
            Next
            gitems.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '***********************************************
    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Trim(FrmReciboCartera.txttipo.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
        txttipo.Text = Trim(FrmReciboCartera.txttipo.Text)
        txttipo2.Text = tabla.Rows(0).Item(0)
        'BuscarNumero()
    End Sub
    Public Sub BuscarNumero()
        Try
            Dim tabla As New DataTable
            Dim item As Integer
            myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc where tipodoc='" & Trim(txttipo.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            item = tabla.Rows(0).Item(0)
            If item < 1 Then
                txtnumfac.Text = NumeroDoc(1)
            Else
                txtnumfac.Text = NumeroDoc(item + 1)
            End If
        Catch ex As Exception
            txtnumfac.Text = NumeroDoc(1)
        End Try
    End Sub
    '**********************************************
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub
    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        Try
            If Val(txtdia.Text) < 10 Then
                txtdia.Text = "0" & Val(txtdia.Text)
            End If
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
            If Trim(txtcliente.Text) <> "" Then BuscarFacturas()
        Catch ex As Exception
            MsgBox("Verifique la fecha (dd/mm/yyyy) => " & txtdia.Text & txtperiodo.Text, MsgBoxStyle.Information, "SAE Control")
        End Try
    End Sub
    '**********************************************
    Public FinEdit, fila, col As Integer
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub gitems_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gitems.CellValidating
        If FinEdit = 1 And fila < gitems.RowCount - 1 And col <> 10 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
        FinEdit = 0
    End Sub
    'FIN DE EDICION DE CELDAS
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 6  'CASO ABONO
                    Try
                        If gitems.Item(1, e.RowIndex).Value = "" Then
                            gitems.Item("abono", e.RowIndex).Value = ""
                            FinEdit = 0
                        Else
                            gitems.Item("abono", e.RowIndex).Value = Moneda(gitems.Item("abono", e.RowIndex).Value)
                            If CDbl(gitems.Item("abono", e.RowIndex).Value) <= 0 Then
                                MsgBox("El monto del ABONO debe ser mayor que cero (0,00).    ", MsgBoxStyle.Information)
                            ElseIf CDbl(gitems.Item("abono", e.RowIndex).Value) > CDbl(gitems.Item("saldo", e.RowIndex).Value) Then
                                MsgBox("El monto del ABONO debe ser mayor menor o igual al saldo.    ", MsgBoxStyle.Information)
                                gitems.Item("abono", e.RowIndex).Value = "0,00"
                            Else
                                gitems.Item("sel", e.RowIndex).Value = True
                            End If
                        End If
                    Catch ex As Exception
                        FinEdit = 0
                        gitems.Item("abono", e.RowIndex).Value = "0,00"
                    End Try
                    gitems.Item("totalp", e.RowIndex).Value = Moneda(CDbl(gitems.Item("abono", e.RowIndex).Value) + CDbl(gitems.Item("interes", e.RowIndex).Value))
                Case 7
                    Try
                        If gitems.Item(1, e.RowIndex).Value = "" Then
                            gitems.Item("interes", e.RowIndex).Value = ""
                            FinEdit = 0
                        Else
                            If gitems.Item("interes", e.RowIndex).Value = "" Then
                                gitems.Item("interes", e.RowIndex).Value = Moneda(0)
                            Else
                                gitems.Item("interes", e.RowIndex).Value = Moneda(gitems.Item("interes", e.RowIndex).Value)
                                If CDbl(gitems.Item("interes", e.RowIndex).Value) < 0 Then
                                    MsgBox("El monto del INTERES debe ser mayor o igual que cero (0,00).    ", MsgBoxStyle.Information)
                                    gitems.Item("interes", e.RowIndex).Value = Moneda(0)
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        FinEdit = 0
                        gitems.Item("interes", e.RowIndex).Value = Moneda(0)
                    End Try
                    gitems.Item("totalp", e.RowIndex).Value = Moneda(CDbl(gitems.Item("abono", e.RowIndex).Value) + CDbl(gitems.Item("interes", e.RowIndex).Value))
                Case 9
                    Buscarcuentas(gitems.Item(9, e.RowIndex).Value, e.RowIndex)
                    gitems.Item("sel", e.RowIndex).Value = True
                Case 10 'sel
                    Try
                        If gitems.Item(1, e.RowIndex).Value = "" And gitems.Item(7, e.RowIndex).Value = True Then
                            gitems.Item(7, e.RowIndex).Value = False
                        End If
                    Catch ex As Exception

                    End Try
                Case 31
                    If gitems.Item("comision", e.RowIndex).Value = "" Then
                        FrmConcepComi.Lbform.Text = "itemcar"
                        FrmConcepComi.lbfila.Text = e.RowIndex
                        FrmConcepComi.ShowDialog()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "CarMora"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                'If grilla.Item(9, fila).Value = "" Or nivel_cuenta(grilla.Item(9, fila).Value) = True Then
                'grilla.Item(9, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "CarMora"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
                'Else
                '    grilla.Item(9, fila).Value = ""
                '    SendKeys.Send(Chr(Keys.Tab))
                'End If
                'Else
                grilla.Item(10, fila).Selected = True
            End If
        End If

    End Sub
    Function nivel_cuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & codigo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub otN()

        Try
            If cbsr.Items.Count = 0 Then
                cbconcepto.Items.Clear()
                cbsr.Items.Clear()
                cbvalor.Items.Clear()
                cbcuenta.Items.Clear()
                cbbase.Items.Clear()
                cbldoc.Items.Clear()
                FrmOtrosConceptosCP.grilla.Rows.Clear()
            End If

            'FrmOtrosConceptosCP.grilla.Rows.Clear()
            'FrmOtrosConceptosCP.grilla.RowCount = cbsr.Items.Count + 2
            For k = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(k).ToString) <> "" Then
                    FrmOtrosConceptosCP.grilla.Item("sel", k).Value = True
                    FrmOtrosConceptosCP.grilla.Item("tipo", k).Value = cbsr.Items.Item(k)
                    FrmOtrosConceptosCP.grilla.Item("des", k).Value = cbconcepto.Items.Item(k)
                    FrmOtrosConceptosCP.grilla.Item("valor", k).Value = Moneda(cbvalor.Items.Item(k))
                    FrmOtrosConceptosCP.grilla.Item("bs", k).Value = Moneda(cbbase.Items.Item(k))
                    FrmOtrosConceptosCP.grilla.Item("cuenta", k).Value = cbcuenta.Items.Item(k)
                    Try
                        FrmOtrosConceptosCP.grilla.Item("ldoc", k).Value = cbldoc.Items.Item(k)
                    Catch ex As Exception
                        FrmOtrosConceptosCP.grilla.Item("ldoc", k).Value = ""
                    End Try
                End If
            Next

            'Try
            '    FrmOtrosConceptosCP.grilla.Rows.Clear()
            '    FrmOtrosConceptosCP.grilla.RowCount = gitems.RowCount + 1
            '    For i = 0 To gitems.RowCount - 1
            '        If gitems.Item("t1", i).Value <> "" Then
            '            FrmOtrosConceptosCP.grilla.Item("sel", i).Value = True
            '            FrmOtrosConceptosCP.grilla.Item("tipo", i).Value = gitems.Item("t1", i).Value
            '            FrmOtrosConceptosCP.grilla.Item("txt", i).Value = gitems.Item("d1", i).Value
            '            FrmOtrosConceptosCP.grilla.Item("valor", i).Value = Moneda(gitems.Item("v1", i).Value)
            '            FrmOtrosConceptosCP.grilla.Item("base", i).Value = Moneda(gitems.Item("b1", i).Value)
            '            FrmOtrosConceptosCP.grilla.Item("cta", i).Value = gitems.Item("cta1", i).Value
            '            Try
            '                FrmOtrosConceptosCP.grilla.Item("ldoc", i).Value = gitems.Item("doc1", i).Value
            '            Catch ex As Exception
            '                FrmOtrosConceptosCP.grilla.Item("ldoc", i).Value = ""
            '            End Try
            '        End If
            '    Next
            '    FrmOtrosConceptosCP.ShowDialog()
            'Catch ex As Exception
            '    'MsgBox(ex.ToString)
            'End Try

            'FrmOtrosConceptosCP.Ch1.Checked = False
            'FrmOtrosConceptosCP.Ch1.Checked = True
            'FrmOtrosConceptosCP.cb1.Text = gitems.Item("t1", i).Value
            'FrmOtrosConceptosCP.txt1.Text = gitems.Item("d1", i).Value
            'FrmOtrosConceptosCP.valor1.Text = Moneda(gitems.Item("v1", i).Value)
            'FrmOtrosConceptosCP.cta1.Text = gitems.Item("cta1", i).Value
            'FrmOtrosConceptosCP.base1.Text = Moneda(gitems.Item("b1", i).Value)
            Dim ab As Double = 0
            Dim tab As Double = 0
            For c = 0 To gitems.RowCount - 1
                If gitems.Item("sel", c).Value = True Then
                    Try
                        ab = ab + CDbl(gitems.Item("abono", c).Value)
                        tab = tab + CDbl(gitems.Item("totalp", c).Value)
                    Catch ex As Exception
                    End Try
                End If
            Next
            FrmOtrosConceptosCP.lbdoc.Text = gitems.Item("doc", 0).Value
            FrmOtrosConceptosCP.lbsaldo.Text = Moneda(FrmReciboCartera.txtvalor.Text)
            FrmOtrosConceptosCP.lbabono.Text = Moneda(ab)
            FrmOtrosConceptosCP.lbtotal.Text = Moneda(tab)
            FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmReciboCartera.txtvalor.Text) - ab)
            FrmOtrosConceptosCP.lbform.Text = "cpc"
            FrmOtrosConceptosCP.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub ot(ByVal i As Integer)
        i = 0
        Try
            Try
                If gitems.Item("t1", i).Value = "/" Then
                    FrmOtrosConceptosCP.Ch1.Checked = True
                    FrmOtrosConceptosCP.Ch1.Checked = False
                    FrmOtrosConceptosCP.cb1.Text = ""
                    FrmOtrosConceptosCP.txt1.Text = ""
                    FrmOtrosConceptosCP.valor1.Text = "0,00"
                    FrmOtrosConceptosCP.cta1.Text = ""
                    FrmOtrosConceptosCP.base1.Text = "0,00"
                Else
                    FrmOtrosConceptosCP.Ch1.Checked = False
                    FrmOtrosConceptosCP.Ch1.Checked = True
                    FrmOtrosConceptosCP.cb1.Text = gitems.Item("t1", i).Value
                    FrmOtrosConceptosCP.txt1.Text = gitems.Item("d1", i).Value
                    FrmOtrosConceptosCP.valor1.Text = Moneda(gitems.Item("v1", i).Value)
                    FrmOtrosConceptosCP.cta1.Text = gitems.Item("cta1", i).Value
                    FrmOtrosConceptosCP.base1.Text = Moneda(gitems.Item("b1", i).Value)
                    If gitems.Item("t1", i).Value = "-" Then
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) - CDbl(gitems.Item("v1", i).Value))
                    Else
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) + CDbl(gitems.Item("v1", i).Value))
                    End If
                End If
            Catch ex As Exception
                FrmOtrosConceptosCP.Ch1.Checked = True
                FrmOtrosConceptosCP.Ch1.Checked = False
                FrmOtrosConceptosCP.cb1.Text = ""
                FrmOtrosConceptosCP.txt1.Text = ""
                FrmOtrosConceptosCP.valor1.Text = "0,00"
                FrmOtrosConceptosCP.cta1.Text = ""
                FrmOtrosConceptosCP.base1.Text = "0,00"
            End Try
            '********************************************
            Try
                If gitems.Item("t2", i).Value = "/" Then
                    FrmOtrosConceptosCP.Ch2.Checked = True
                    FrmOtrosConceptosCP.Ch2.Checked = False
                    FrmOtrosConceptosCP.cb2.Text = ""
                    FrmOtrosConceptosCP.txt2.Text = ""
                    FrmOtrosConceptosCP.valor2.Text = "0,00"
                    FrmOtrosConceptosCP.cta2.Text = ""
                    FrmOtrosConceptosCP.base2.Text = "0,00"
                Else
                    FrmOtrosConceptosCP.Ch2.Checked = False
                    FrmOtrosConceptosCP.Ch2.Checked = True
                    FrmOtrosConceptosCP.cb2.Text = gitems.Item("t2", i).Value
                    FrmOtrosConceptosCP.txt2.Text = gitems.Item("d2", i).Value
                    FrmOtrosConceptosCP.valor2.Text = Moneda(gitems.Item("v2", i).Value)
                    FrmOtrosConceptosCP.cta2.Text = gitems.Item("cta2", i).Value
                    FrmOtrosConceptosCP.base2.Text = Moneda(gitems.Item("b2", i).Value)
                    If gitems.Item("t2", i).Value = "-" Then
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) - CDbl(gitems.Item("v2", i).Value))
                    Else
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) + CDbl(gitems.Item("v2", i).Value))
                    End If
                End If
            Catch ex As Exception
                FrmOtrosConceptosCP.Ch2.Checked = True
                FrmOtrosConceptosCP.Ch2.Checked = False
                FrmOtrosConceptosCP.cb2.Text = ""
                FrmOtrosConceptosCP.txt2.Text = ""
                FrmOtrosConceptosCP.valor2.Text = "0,00"
                FrmOtrosConceptosCP.cta2.Text = ""
                FrmOtrosConceptosCP.base2.Text = "0,00"
            End Try
            '**********************************************************
            Try
                If gitems.Item("t3", i).Value = "/" Then
                    FrmOtrosConceptosCP.Ch3.Checked = True
                    FrmOtrosConceptosCP.Ch3.Checked = False
                    FrmOtrosConceptosCP.cb3.Text = ""
                    FrmOtrosConceptosCP.txt3.Text = ""
                    FrmOtrosConceptosCP.valor3.Text = "0,00"
                    FrmOtrosConceptosCP.cta3.Text = ""
                    FrmOtrosConceptosCP.base3.Text = "0,00"
                Else
                    FrmOtrosConceptosCP.Ch3.Checked = False
                    FrmOtrosConceptosCP.Ch3.Checked = True
                    FrmOtrosConceptosCP.cb3.Text = gitems.Item("t3", i).Value
                    FrmOtrosConceptosCP.txt3.Text = gitems.Item("d3", i).Value
                    FrmOtrosConceptosCP.valor3.Text = Moneda(gitems.Item("v3", i).Value)
                    FrmOtrosConceptosCP.cta3.Text = gitems.Item("cta3", i).Value
                    FrmOtrosConceptosCP.base3.Text = Moneda(gitems.Item("b3", i).Value)
                    If gitems.Item("t3", i).Value = "-" Then
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) - CDbl(gitems.Item("v3", i).Value))
                    Else
                        FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmOtrosConceptosCP.lbdif.Text) + CDbl(gitems.Item("v3", i).Value))
                    End If
                End If
            Catch ex As Exception
                FrmOtrosConceptosCP.Ch3.Checked = True
                FrmOtrosConceptosCP.Ch3.Checked = False
                FrmOtrosConceptosCP.cb3.Text = ""
                FrmOtrosConceptosCP.txt3.Text = ""
                FrmOtrosConceptosCP.valor3.Text = "0,00"
                FrmOtrosConceptosCP.cta3.Text = ""
                FrmOtrosConceptosCP.base3.Text = "0,00"
            End Try
            Dim ab As Double = 0
            Dim tab As Double = 0
            For c = 0 To gitems.RowCount - 1
                If gitems.Item("sel", c).Value = True Then
                    Try
                        ab = ab + CDbl(gitems.Item("abono", c).Value)
                        tab = tab + CDbl(gitems.Item("totalp", c).Value)
                    Catch ex As Exception
                    End Try
                End If
            Next
            FrmOtrosConceptosCP.lbdoc.Text = gitems.Item("doc", i).Value
            FrmOtrosConceptosCP.lbsaldo.Text = Moneda(FrmReciboCartera.txtvalor.Text)
            FrmOtrosConceptosCP.lbabono.Text = Moneda(ab)
            FrmOtrosConceptosCP.lbtotal.Text = Moneda(tab)
            FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmReciboCartera.txtvalor.Text) - ab)
            FrmOtrosConceptosCP.lbform.Text = "cpc"
            FrmOtrosConceptosCP.lbfila.Text = i
            FrmOtrosConceptosCP.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        Select Case e.ColumnIndex
            Case 9
                If gitems.Item(9, e.RowIndex).Value <> "" Or gitems.Item("interes", e.RowIndex).Value = Moneda(0) Then Exit Sub
                SendKeys.Send(Chr(Keys.Space))
                SendKeys.Send(Chr(Keys.Back))
        End Select
    End Sub
    '************************************************
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click

        If Trim(txttipo.Text) = "" Or Trim(txttipo2.Text) = "" Then
            MsgBox("Favor seleccione un tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
            Exit Sub
        End If

        'Dim res As MsgBoxResult
        'res = MsgBox(" ¿Desea Agregar otros conceptos? ", MsgBoxStyle.YesNo, "Verificando")
        'If res = MsgBoxResult.Yes Then
        '    ot(0)
        '    cmdfpago_Click(AcceptButton, AcceptButton)
        'Else
        '    AgregarFactura()
        'End If
        'ot(0)
        otN()
        formapago()
        AgregarFactura()
    End Sub
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        FrmReciboCartera.lbhaydoc.Text = "NO"
        Me.Close()
    End Sub
    '*******************************************
    Dim j As Integer = 0
    Public Sub AgregarFactura()

        If Trim(txttipo.Text) = "" Or Trim(txttipo2.Text) = "" Then
            MsgBox("Favor seleccione un tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
            Exit Sub
        End If
        If lbfp.Text = "" Then
            MsgBox("Favor seleccione la forma de pago.  ", MsgBoxStyle.Information, "SAE Control")
            cmdfpago_Click(AcceptButton, AcceptButton)
            Exit Sub
        End If
        FrmReciboCartera.lbcta.Text = lbctafp.Text
        Dim sw As Integer = 0
        Dim abono As Double = 0
        Try
            grilla.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            grilla.RowCount = gitems.RowCount * 2
        Catch ex As Exception
            grilla.RowCount = 50
        End Try

        j = -1
        Dim i As Integer = 0
        For i = 0 To gitems.RowCount - 1
            Try
                If gitems.Item("sel", i).Value = True And gitems.Item("doc", i).Value <> "" Then
                    sw = sw + 1
                    If CDbl(gitems.Item("abono", i).Value) <= 0 Then
                        MsgBox("El monto de los abonos deben ser mayor que cero (0,00), verifique.  ", MsgBoxStyle.Information, "SAE Control")
                        gitems.Focus()
                        Exit Sub
                    End If
                    Try
                        abono = CDbl(gitems.Item("abono", i).Value)
                    Catch ex As Exception
                        abono = 0
                    End Try
                    '****************CALCULAR MI ABONO*************************************
                    If abono >= CDbl(gitems.Item("saldo", i).Value) Then
                        MovimientoContable(i, "cpp2", gitems.Item("ctacpp", i).Value, "PAGO DEL DOCUMENTO " & gitems.Item("doc", i).Value, gitems.Item("comision", i).Value)
                    Else
                        MovimientoContable(i, "cpp", gitems.Item("ctacpp", i).Value, "ABONO DEL DOCUMENTO " & gitems.Item("doc", i).Value, gitems.Item("comision", i).Value)
                    End If
                    ' intereses
                    If CDbl(gitems.Item("interes", i).Value) <> 0 Then
                        MovimientoContable(i, "inte", gitems.Item("ctaint", i).Value, "INTERESES MORATORIO " & gitems.Item("doc", i).Value, "")
                    End If
                End If
            Catch ex As Exception

            End Try
        Next
        '***********************************************************
        i = 0
        MovimientoContable(i, "total", lbctafp.Text, Trim(txtcliente.Text), "")
        '***************************************************************************
        If cbsr.Items.Count > 0 Then
            For l = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(l).ToString) = "+" Then
                    grilla.RowCount = grilla.RowCount + 1
                    MovimientoContable(l, "+", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l), "")
                ElseIf Trim(cbsr.Items.Item(l).ToString) = "-" Then
                    grilla.RowCount = grilla.RowCount + 1
                    MovimientoContable(l, "-", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l), "")
                End If
            Next
        End If
        '...........................................

        ''If gitems.Item("t1", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "1-", gitems.Item("cta1", i).Value, gitems.Item("d1", i).Value, "")
        ''ElseIf gitems.Item("t1", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "1+", gitems.Item("cta1", i).Value, gitems.Item("d1", i).Value, "")
        ''End If
        ' ''****************************************
        ''If gitems.Item("t2", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "2-", gitems.Item("cta2", i).Value, gitems.Item("d2", i).Value, "")
        ''ElseIf gitems.Item("t2", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "2+", gitems.Item("cta2", i).Value, gitems.Item("d2", i).Value, "")
        ''End If
        ' ''**************************************
        ''If gitems.Item("t3", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "3-", gitems.Item("cta3", i).Value, gitems.Item("d3", i).Value, "")
        ''ElseIf gitems.Item("t3", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "3+", gitems.Item("cta3", i).Value, gitems.Item("d3", i).Value, "")
        ''End If
        '*********************************************************
        If sw = 0 Then
            MsgBox("No ha selecionado documento(s) por pagar, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            FrmReciboCartera.lbhaydoc.Text = "si" 'hay documento
            FrmReciboCartera.grilla.Rows.Clear()
            FrmReciboCartera.grilla.RowCount = 2
            grilla.Sort(grilla.Columns("Debitos"), System.ComponentModel.ListSortDirection.Descending)
            Dim j As Integer = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    If grilla.Item("cuenta", i).Value <> "" Then
                        j = j + 1
                        FrmReciboCartera.grilla.RowCount = FrmReciboCartera.grilla.RowCount + 1
                        FrmReciboCartera.grilla.Item("Cuenta", i).Value = grilla.Item("cuenta", i).Value
                        FrmReciboCartera.grilla.Item("Descripcion", i).Value = grilla.Item("Descripcion", i).Value
                        FrmReciboCartera.grilla.Item("Debitos", i).Value = Moneda(grilla.Item("Debitos", i).Value)
                        FrmReciboCartera.grilla.Item("Creditos", i).Value = Moneda(grilla.Item("Creditos", i).Value)
                        FrmReciboCartera.grilla.Item("Base", i).Value = Moneda(grilla.Item("Base", i).Value)
                        FrmReciboCartera.grilla.Item("doc_afe", i).Value = grilla.Item("doc_afe", i).Value
                        FrmReciboCartera.grilla.Item("abonado", i).Value = grilla.Item("abonado", i).Value
                        FrmReciboCartera.grilla.Item("editar", i).Value = "no"
                        FrmReciboCartera.grilla.Item("DocAnti", i).Value = grilla.Item("DocAnti", i).Value
                        FrmReciboCartera.grilla.Item("comision", i).Value = grilla.Item("codcomi", i).Value
                        FrmReciboCartera.grilla.Item("otro", i).Value = grilla.Item("ott", i).Value
                    End If
                Catch ex As Exception
                End Try
            Next
            FrmReciboCartera.grilla.RowCount = FrmReciboCartera.grilla.RowCount + 1
            'If cbsr.Items.Count > 0 Then
            '    For l = 0 To cbsr.Items.Count - 1
            '        If Trim(cbsr.Items.Item(l).ToString) = "+" Then
            '            j = j + 1
            '            FrmReciboCartera.grilla.RowCount = FrmReciboCartera.grilla.RowCount + 1
            '            i = i + 1
            '            FrmReciboCartera.grilla.Item("Cuenta", i).Value = cbcuenta.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("Descripcion", i).Value = cbconcepto.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("Debitos", i).Value = Moneda(cbvalor.Items.Item(l))
            '            FrmReciboCartera.grilla.Item("Creditos", i).Value = Moneda(0)
            '            FrmReciboCartera.grilla.Item("Base", i).Value = Moneda(cbbase.Items.Item(l))
            '            FrmReciboCartera.grilla.Item("doc_afe", i).Value = ""
            '            FrmReciboCartera.grilla.Item("abonado", i).Value = ""
            '            FrmReciboCartera.grilla.Item("editar", i).Value = "no"
            '            FrmReciboCartera.grilla.Item("DocAnti", i).Value = cbldoc.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("comision", i).Value = ""
            '            FrmReciboCartera.grilla.Item("otro", i).Value = "/"
            '        ElseIf Trim(cbsr.Items.Item(l).ToString) = "-" Then
            '            j = j + 1
            '            FrmReciboCartera.grilla.RowCount = FrmReciboCartera.grilla.RowCount + 1
            '            i = i + 1
            '            FrmReciboCartera.grilla.Item("Cuenta", i).Value = cbcuenta.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("Descripcion", i).Value = cbconcepto.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("Debitos", i).Value = Moneda(0)
            '            FrmReciboCartera.grilla.Item("Creditos", i).Value = Moneda(cbvalor.Items.Item(l))
            '            FrmReciboCartera.grilla.Item("Base", i).Value = Moneda(cbbase.Items.Item(l))
            '            FrmReciboCartera.grilla.Item("doc_afe", i).Value = ""
            '            FrmReciboCartera.grilla.Item("abonado", i).Value = ""
            '            FrmReciboCartera.grilla.Item("editar", i).Value = "no"
            '            FrmReciboCartera.grilla.Item("DocAnti", i).Value = cbldoc.Items.Item(l)
            '            FrmReciboCartera.grilla.Item("comision", i).Value = ""
            '            FrmReciboCartera.grilla.Item("otro", i).Value = "/"
            '        End If
            '    Next
            'End If
            Try
                FrmReciboCartera.grilla.RowCount = j + 1
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
            FrmReciboCartera.lbdoc.Text = txttipo.Text
            FrmReciboCartera.txttipo.Text = txttipo.Text
            FrmReciboCartera.lbnomdoc.Text = txttipo2.Text
            FrmReciboCartera.lbper.Text = lbper.Text
            FrmReciboCartera.txtnumero.Text = txtnumfac.Text
            FrmReciboCartera.txtdia.Text = txtdia.Text
            FrmReciboCartera.txtperiodo.Text = txtperiodo.Text
            FrmReciboCartera.lbcliente.Text = txtcliente.Text
            FrmReciboCartera.txtnit.Text = txtnitc.Text
            FrmReciboCartera.fecha.Value = Today
            FrmReciboCartera.rbcc.Checked = True
            FrmReciboCartera.txtelaborado.Text = FrmPrincipal.lbuser.Text
            'FrmReciboCartera.txtvalor.Text = Moneda(abono)
            ' FrmReciboCartera.lbsuma.Text = "SON " & Num2Text(abono)
            If lbfp.Text = "efectivo" Then
                FrmReciboCartera.chefectivo.Checked = True
                FrmReciboCartera.lbfp.Text = "Cheque No."
                FrmReciboCartera.lb1.Text = "Banco"
                FrmReciboCartera.lb2.Text = "Sucursal"
                '**************************************
                FrmReciboCartera.txtcheque.Text = ""
                FrmReciboCartera.txtbanco.Text = ""
                FrmReciboCartera.txtsucursal.Text = ""
                '****
                FrmReciboCartera.txtcheque.Enabled = False
                FrmReciboCartera.txtbanco.Enabled = False
                FrmReciboCartera.txtsucursal.Enabled = False
            ElseIf lbfp.Text = "cheque" Then
                FrmReciboCartera.chefectivo.Checked = False
                FrmReciboCartera.lbfp.Text = "Cheque No."
                FrmReciboCartera.lb1.Text = "Banco"
                FrmReciboCartera.lb2.Text = "Sucursal"
                '*******************************
                FrmReciboCartera.txtcheque.Text = lbnum.Text 'numero de cheque
                FrmReciboCartera.txtbanco.Text = lbbanco.Text 'Banco
                FrmReciboCartera.txtsucursal.Text = "" 'Sucursal
                '**************************************
                FrmReciboCartera.txtcheque.Enabled = True
                FrmReciboCartera.txtbanco.Enabled = True
                FrmReciboCartera.txtsucursal.Enabled = True
            ElseIf lbfp.Text = "consignacion" Then
                FrmReciboCartera.chefectivo.Checked = False
                FrmReciboCartera.lbfp.Text = "Consignacion No."
                FrmReciboCartera.lb1.Text = "Banco"
                FrmReciboCartera.lb2.Text = "Sucursal"
                '*******************************
                FrmReciboCartera.txtcheque.Text = lbnum.Text 'numero de cheque
                FrmReciboCartera.txtbanco.Text = lbbanco.Text 'Banco
                FrmReciboCartera.txtsucursal.Text = "" 'Sucursal
                '**************************************
                FrmReciboCartera.txtcheque.Enabled = True
                FrmReciboCartera.txtbanco.Enabled = True
                FrmReciboCartera.txtsucursal.Enabled = True
            ElseIf lbfp.Text = "tarjeta" Then
                FrmReciboCartera.chefectivo.Checked = False
                FrmReciboCartera.lbfp.Text = "Tarjeta"
                FrmReciboCartera.lb1.Text = "Banco"
                FrmReciboCartera.lb2.Text = "Numero"
                '*******************************
                FrmReciboCartera.txtcheque.Text = lbtipotar.Text  'tipo tarjeta
                FrmReciboCartera.txtbanco.Text = lbbanco.Text 'Tarjeta
                FrmReciboCartera.txtsucursal.Text = lbnum.Text  'numero tarjeta
                '**************************************
                FrmReciboCartera.txtcheque.Enabled = True
                FrmReciboCartera.txtbanco.Enabled = True
                FrmReciboCartera.txtsucursal.Enabled = True
            End If
            If Trim(FrmReciboCartera.txtconcepto.Text) = "" Then FrmReciboCartera.txtconcepto.Text = "CUENTAS POR COBRAR A " & txtcliente.Text
            Me.Close()
        End If
    End Sub
    '*************************************************Ç
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String, ByVal codcomi As String)
        Try
            If cuenta = "" Then Exit Sub
            j = j + 1
            grilla.Item("cuenta", j).Value = cuenta
            grilla.Item("Descripcion", j).Value = descrip
            grilla.Item("Base", j).Value = "0,00"
            grilla.Item("doc_afe", j).Value = " "
            grilla.Item("codcomi", j).Value = codcomi
            '*******************************************************
            Dim db, cr, monto As Double
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
            '******************************************************
            Dim tipodoc As String = ""
            Try
                tipodoc = gitems.Item("doc", fo).Value
                tipodoc = tipodoc(0) & tipodoc(1)
            Catch ex As Exception
                tipodoc = gitems.Item("doc", 0).Value
            End Try


            '**********************************************************
            Select Case tipo
                Case "total"
                    Try
                        monto = CDbl(FrmReciboCartera.txtvalor.Text)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("ott", j).Value = " "
                Case "cpp"
                    Try
                        monto = CDbl(gitems.Item("abono", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    If monto >= CDbl(gitems.Item("saldo", fo).Value) Then
                        grilla.Item("abonado", j).Value = Moneda(gitems.Item("saldo", fo).Value)
                    Else
                        grilla.Item("abonado", j).Value = Moneda(monto)
                    End If
                    grilla.Item("doc_afe", j).Value = gitems.Item("doc", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "inte"
                    Try
                        monto = CDbl(gitems.Item("interes", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    grilla.Item("ott", j).Value = " "
                Case "cpp2"
                    Try
                        monto = CDbl(gitems.Item("saldo", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    If monto >= CDbl(gitems.Item("saldo", fo).Value) Then
                        grilla.Item("abonado", j).Value = Moneda(gitems.Item("saldo", fo).Value)
                    Else
                        grilla.Item("abonado", j).Value = Moneda(monto)
                    End If
                    grilla.Item("doc_afe", j).Value = gitems.Item("doc", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "-"
                    Try
                        monto = CDbl(cbvalor.Items.Item(fo))
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    grilla.Item("Base", j).Value = cbbase.Items.Item(fo)
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = cbldoc.Items.Item(fo)
                    grilla.Item("ott", j).Value = "/"
                Case "+"
                    Try
                        monto = CDbl(cbvalor.Items.Item(fo))
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If
                    grilla.Item("Base", j).Value = cbbase.Items.Item(fo)
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = cbldoc.Items.Item(fo)
                    grilla.Item("ott", j).Value = "/"
                Case "1-"
                    Try
                        monto = CDbl(gitems.Item("v1", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b1", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do1", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "2-"
                    Try
                        monto = CDbl(gitems.Item("v2", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b2", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do2", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "3-"
                    Try
                        monto = CDbl(gitems.Item("v3", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b3", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do3", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "1+"
                    Try
                        monto = CDbl(gitems.Item("v1", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b1", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do1", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "2+"
                    Try
                        monto = CDbl(gitems.Item("v2", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b2", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do2", fo).Value
                    grilla.Item("ott", j).Value = " "
                Case "3+"
                    Try
                        monto = CDbl(gitems.Item("v3", fo).Value)
                        monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                    Catch ex As Exception
                        monto = 0
                    End Try
                    If tipodoc = lbdoc_aj.Text Then 'documento de ajuste
                        grilla.Item("Debitos", j).Value = db + monto
                        grilla.Item("Creditos", j).Value = cr
                    Else 'documento de proveedor
                        grilla.Item("Debitos", j).Value = db
                        grilla.Item("Creditos", j).Value = cr + monto
                    End If
                    grilla.Item("Base", j).Value = gitems.Item("b3", fo).Value
                    grilla.Item("abonado", j).Value = "0,00"
                    grilla.Item("DocAnti", j).Value = gitems.Item("do3", fo).Value
                    grilla.Item("ott", j).Value = " "
            End Select
        Catch ex As Exception
        End Try
    End Sub
    '*************************************************Ç
    Private Sub formapago()
        Dim suma As Double = 0
        Try
            suma = CDbl(txtvalor.Text)
        Catch ex As Exception
        End Try

        Dim cad As String = lbfp.Text
        Dim cad2 As String = ""
        Try
            For i = 0 To cad.Length - 1
                If i = 0 Then
                    cad2 = cad2 & UCase(cad(0).ToString)
                Else
                    cad2 = cad2 & cad(i)
                End If
            Next
        Catch ex As Exception
            cad2 = ""
        End Try
        If Trim(cad2) = "" Then
            FrmFormaPago2.lbfp.Text = ""
        Else
            FrmFormaPago2.lbfp.Text = Trim("Pagar  Con " & cad2)
        End If
        FrmFormaPago2.lbform.Text = "cpc_rc"
        FrmFormaPago2.txttotal.Text = Moneda(suma)
        FrmFormaPago2.ShowDialog()
    End Sub
    Private Sub cmdfpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfpago.Click
        'Dim suma As Double = 0
        'Try
        '    suma = CDbl(txtvalor.Text)
        'Catch ex As Exception
        'End Try

        'Dim cad As String = lbfp.Text
        'Dim cad2 As String = ""
        'Try
        '    For i = 0 To cad.Length - 1
        '        If i = 0 Then
        '            cad2 = cad2 & UCase(cad(0).ToString)
        '        Else
        '            cad2 = cad2 & cad(i)
        '        End If
        '    Next
        'Catch ex As Exception
        '    cad2 = ""
        'End Try
        'If Trim(cad2) = "" Then
        '    FrmFormaPago2.lbfp.Text = ""
        'Else
        '    FrmFormaPago2.lbfp.Text = Trim("Pagar  Con " & cad2)
        'End If
        'FrmFormaPago2.lbform.Text = "cpc_rc"
        'FrmFormaPago2.txttotal.Text = Moneda(suma)
        'FrmFormaPago2.ShowDialog()
    End Sub
    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            ValidarMoneda(txtvalor, e)
        End If
    End Sub
    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        FrmReciboCartera.txtvalor.Text = Moneda(txtvalor.Text)
        FrmReciboCartera.lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
        For i = 0 To FrmReciboCartera.grilla.RowCount - 1
            Try
                If Trim(FrmReciboCartera.grilla.Item("Descripcion", i).Value) = Trim(txtcliente.Text) Then
                    If lbdoc_aj.Text = txttipo.Text Then
                        FrmReciboCartera.grilla.Item("Creditos", i).Value = Moneda(txtvalor.Text)
                    Else
                        FrmReciboCartera.grilla.Item("Debitos", i).Value = Moneda(txtvalor.Text)
                    End If
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub txtvalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvalor.TextChanged

    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub
End Class