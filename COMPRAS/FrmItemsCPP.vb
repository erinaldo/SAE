Public Class FrmItemsCPP

    Private Sub FrmItemsCPP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc_cpp, doc_gas, doc_aj FROM par_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                MsgBox("No han definido documentos para esta interfaz.  ", MsgBoxStyle.Information, "SAE Control")
                Me.Close()
            End If
            Dim t As String = txttipo.Text
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("doc_cpp")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_cpp")))
            End If
            If Trim(tabla.Rows(0).Item("doc_gas")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_gas")))
            End If
            Try
                lbdoc_aj.Text = Trim(tabla.Rows(0).Item("doc_aj"))
            Catch ex As Exception
                lbdoc_aj.Text = ""
            End Try
            txttipo.Items.Add(FrmCompEgreCpp.txttipo.Text)
            If FrmCompEgreCpp.txttipo.Text <> "" Then
                txttipo.Text = FrmCompEgreCpp.txttipo.Text
            Else
                txttipo.Text = t
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        If txtcliente.Text <> "" And FrmCompEgreCpp.grilla.RowCount <= 1 Then
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

        For i = 0 To FrmCompEgreCpp.grilla.RowCount - 1
            If FrmCompEgreCpp.grilla.Item("otro", i).Value = "/" Then
                cbconcepto.Items.Add(FrmCompEgreCpp.grilla.Item("Descripcion", i).Value)
                cbcuenta.Items.Add(FrmCompEgreCpp.grilla.Item("Cuenta", i).Value)
                If FrmCompEgreCpp.grilla.Item("Debitos", i).Value <> Moneda(0) Then
                    cbsr.Items.Add("-")
                Else
                    cbsr.Items.Add("+")
                End If
                If FrmCompEgreCpp.grilla.Item("Debitos", i).Value <> Moneda(0) Then
                    cbvalor.Items.Add(Moneda(FrmCompEgreCpp.grilla.Item("Debitos", i).Value))
                Else
                    cbvalor.Items.Add(Moneda(FrmCompEgreCpp.grilla.Item("Creditos", i).Value))
                End If
                cbbase.Items.Add(Moneda(FrmCompEgreCpp.grilla.Item("Base", i).Value))
                Try
                    cbldoc.Items.Add(FrmCompEgreCpp.grilla.Item("DocAnti", i).Value)
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
            FrmSelCliente.lbform.Text = "it_ce_cpp"
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
        'MsgBox("voy a buscar")
        Try
            Dim m As String = ""
            If CInt(fecha.Month) < 9 Then
                m = "0" & fecha.Month
            Else
                m = fecha.Month
            End If
            Dim f As String = fecha.Year & "-" & m & "-" & fecha.Day
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc,doc_ext,fecha,concepto,total,(total - pagado) AS saldo,ctatotal FROM ctas_x_pagar WHERE nitc ='" & txtnitc.Text & "' AND fecha<='" & f & "' AND total>pagado ORDER BY doc,fecha;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count - 1
            If items = -1 Then
                MsgBox("El Proveedor no tiene facturas por pagar a la fecha (" & CambiaCadena(fecha.ToString, 10) & "). ", MsgBoxStyle.Information, "SAE Control")
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
                gitems.Columns("num").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("doc").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("doc2").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("descrip").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("total_fact").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("saldo").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("abono").SortMode = DataGridViewColumnSortMode.NotSortable
                gitems.Columns("sel").SortMode = DataGridViewColumnSortMode.NotSortable
            Else
                gitems.RowCount = tabla.Rows.Count
                gitems.Columns("num").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("doc").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("doc2").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("fecha").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("descrip").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("total_fact").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("saldo").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("abono").SortMode = DataGridViewColumnSortMode.Automatic
                gitems.Columns("sel").SortMode = DataGridViewColumnSortMode.Automatic
            End If
            For i = 0 To items
                gitems.Item("num", i).Value = i + 1
                gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc")
                gitems.Item("doc2", i).Value = tabla.Rows(i).Item("doc_ext")
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
            Next
            gitems.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '***********************************************
    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Trim(txttipo.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
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
        If FinEdit = 1 And fila < gitems.RowCount - 1 And col <> 8 Then
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
                Case 7  'CASO ABONO
                    Try
                        If gitems.Item(1, e.RowIndex).Value = "" Then
                            gitems.Item("abono", e.RowIndex).Value = ""
                            FinEdit = 0
                        Else
                            gitems.Item("abono", e.RowIndex).Value = Moneda(gitems.Item("abono", e.RowIndex).Value)
                            If CDbl(gitems.Item("abono", e.RowIndex).Value) <= 0 Then
                                MsgBox("El monto del ABONO debe ser mayor que cero (0,00).    ", MsgBoxStyle.Information)
                            Else
                                gitems.Item("sel", e.RowIndex).Value = True
                            End If
                        End If
                    Catch ex As Exception
                        FinEdit = 0
                        gitems.Item("abono", e.RowIndex).Value = "0,00"
                    End Try
                Case 8
                    Try
                        If gitems.Item(1, e.RowIndex).Value = "" And gitems.Item(8, e.RowIndex).Value = True Then
                            gitems.Item(8, e.RowIndex).Value = False
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        Catch ex As Exception
        End Try
    End Sub
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
            FrmOtrosConceptosCP.lbsaldo.Text = Moneda(FrmCompEgreCpp.txtvalor.Text)
            FrmOtrosConceptosCP.lbabono.Text = Moneda(ab)
            FrmOtrosConceptosCP.lbtotal.Text = Moneda(tab)
            FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmCompEgreCpp.txtvalor.Text) - ab)
            FrmOtrosConceptosCP.lbform.Text = "cpp"
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
            '*******************************************************************
            Dim ab As Double = 0
            For c = 0 To gitems.RowCount - 1
                If gitems.Item("sel", c).Value = True Then
                    Try
                        ab = ab + CDbl(gitems.Item("abono", c).Value)
                    Catch ex As Exception
                    End Try
                End If
            Next
            FrmOtrosConceptosCP.lbdoc.Text = gitems.Item("doc2", 0).Value
            FrmOtrosConceptosCP.lbsaldo.Text = Moneda(FrmCompEgreCpp.txtvalor.Text)
            FrmOtrosConceptosCP.lbabono.Text = Moneda(ab)
            'FrmOtrosConceptosCP.lbdif.Text = Moneda(CDbl(FrmCompEgreCpp.txtvalor.Text) - CDbl(ab))
            FrmOtrosConceptosCP.lbform.Text = "cpp"
            FrmOtrosConceptosCP.lbfila.Text = 0
            FrmOtrosConceptosCP.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
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
        FormaPago()
        AgregarFactura()
    End Sub
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        FrmCompEgreCpp.lbhaydoc.Text = "NO"
        Me.Close()
    End Sub
    '*******************************************
    Public Sub FormaPago()
        Dim suma As Double = 0
        Try
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
        Catch ex As Exception
        End Try
        Try
            FrmFormaPago2.lbform.Text = "cpp_eg"
            FrmFormaPago2.txttotal.Text = Moneda(suma)
            FrmFormaPago2.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Dim j As Integer = 0
    Public Sub AgregarFactura()
        If Trim(txttipo.Text) = "" Or Trim(txttipo2.Text) = "" Then
            MsgBox("Favor seleccione un tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
            txttipo.Focus()
            Exit Sub
        End If
        If lbfp.Text = "" Then
            MsgBox("Favor seleccione la forma de pago.  ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        Dim sw As Integer = 0
        Dim abono As Double = 0
        Try
            grilla.Rows.Clear()
        Catch ex As Exception
        End Try
        grilla.RowCount = gitems.RowCount * 2
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
                    '**********************************************************************
                    If abono >= CDbl(gitems.Item("saldo", i).Value) Then
                        MovimientoContable(i, "cpp2", gitems.Item("ctacpp", i).Value, "PAGO DEL DOCUMENTO " & gitems.Item("doc2", i).Value)
                    Else
                        MovimientoContable(i, "cpp", gitems.Item("ctacpp", i).Value, "ABONO DEL DOCUMENTO " & gitems.Item("doc2", i).Value)
                    End If

                End If
            Catch ex As Exception
            End Try
        Next
        '***********************************************************
        i = 0
        MovimientoContable(i, "total", lbctafp.Text, Trim(txtcliente.Text))
        '***************************************************************************

        If cbsr.Items.Count > 0 Then
            For l = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(l).ToString) = "+" Then
                    grilla.RowCount = grilla.RowCount + 1
                    MovimientoContable(l, "+", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l))
                ElseIf Trim(cbsr.Items.Item(l).ToString) = "-" Then
                    grilla.RowCount = grilla.RowCount + 1
                    MovimientoContable(l, "-", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l))
                End If
            Next
        End If
        '...............
        ''If gitems.Item("t1", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "1-", gitems.Item("cta1", i).Value, gitems.Item("d1", i).Value)
        ''ElseIf gitems.Item("t1", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "1+", gitems.Item("cta1", i).Value, gitems.Item("d1", i).Value)
        ''End If
        ' ''****************************************
        ''If gitems.Item("t2", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "2-", gitems.Item("cta2", i).Value, gitems.Item("d2", i).Value)
        ''ElseIf gitems.Item("t2", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "2+", gitems.Item("cta2", i).Value, gitems.Item("d2", i).Value)
        ''End If
        ' ''**************************************
        ''If gitems.Item("t3", i).Value = "-" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "3-", gitems.Item("cta3", i).Value, gitems.Item("d3", i).Value)
        ''ElseIf gitems.Item("t3", i).Value = "+" Then
        ''    grilla.RowCount = grilla.RowCount + 1
        ''    MovimientoContable(i, "3+", gitems.Item("cta3", i).Value, gitems.Item("d3", i).Value)
        ''End If
        ' ''**************************************************************************************
        If sw = 0 Then
            MsgBox("No ha selecionado documento(s) por pagar, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            FrmCompEgreCpp.lbhaydoc.Text = "si" 'hay documento
            FrmCompEgreCpp.grilla.Rows.Clear()
            FrmCompEgreCpp.grilla.RowCount = 2
            grilla.Sort(grilla.Columns("Debitos"), System.ComponentModel.ListSortDirection.Descending)
            Dim j As Integer = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    If grilla.Item("cuenta", i).Value <> "" Then
                        j = j + 1
                        FrmCompEgreCpp.grilla.RowCount = FrmCompEgreCpp.grilla.RowCount + 1
                        FrmCompEgreCpp.grilla.Item("Cuenta", i).Value = grilla.Item("cuenta", i).Value
                        FrmCompEgreCpp.grilla.Item("Descripcion", i).Value = grilla.Item("Descripcion", i).Value
                        FrmCompEgreCpp.grilla.Item("Debitos", i).Value = Moneda(grilla.Item("Debitos", i).Value)
                        FrmCompEgreCpp.grilla.Item("Creditos", i).Value = Moneda(grilla.Item("Creditos", i).Value)
                        FrmCompEgreCpp.grilla.Item("Base", i).Value = Moneda(grilla.Item("Base", i).Value)
                        FrmCompEgreCpp.grilla.Item("doc_afe", i).Value = grilla.Item("doc_afe", i).Value
                        FrmCompEgreCpp.grilla.Item("abonado", i).Value = grilla.Item("abonado", i).Value
                        FrmCompEgreCpp.grilla.Item("editar", i).Value = "no"
                        FrmCompEgreCpp.grilla.Item("DocAnti", i).Value = grilla.Item("DocAnti", i).Value
                        FrmCompEgreCpp.grilla.Item("otro", i).Value = grilla.Item("ott", i).Value
                    End If
                Catch ex As Exception
                End Try
            Next
            Try
                FrmCompEgreCpp.grilla.RowCount = j + 1
            Catch ex As Exception
                ' MsgBox(ex.ToString)
            End Try
            FrmCompEgreCpp.grilla.RowCount = FrmCompEgreCpp.grilla.RowCount + 1
            FrmCompEgreCpp.lbdoc.Text = txttipo.Text
            FrmCompEgreCpp.txttipo.Text = txttipo.Text
            FrmCompEgreCpp.lbnomdoc.Text = txttipo2.Text
            FrmCompEgreCpp.lbper.Text = lbper.Text
            FrmCompEgreCpp.txtnumero.Text = txtnumfac.Text
            FrmCompEgreCpp.txtdia.Text = txtdia.Text
            FrmCompEgreCpp.txtperiodo.Text = txtperiodo.Text
            FrmCompEgreCpp.lbcliente.Text = txtcliente.Text
            FrmCompEgreCpp.txtnit.Text = txtnitc.Text
            FrmCompEgreCpp.fecha.Value = Today
            FrmCompEgreCpp.rbcc.Checked = True
            FrmCompEgreCpp.txtelaborado.Text = FrmPrincipal.lbuser.Text
            If lbfp.Text = "efectivo" Then
                FrmCompEgreCpp.chefectivo.Checked = True
                FrmCompEgreCpp.lbfp.Text = "Cheque No."
                FrmCompEgreCpp.lb1.Text = "Banco"
                FrmCompEgreCpp.lb2.Text = "Sucursal"
                FrmCompEgreCpp.txtcheque.Text = "" 'numero de cheque
                FrmCompEgreCpp.txtbanco.Text = "" 'Banco
                FrmCompEgreCpp.txtsucursal.Text = "" 'Sucursal
                '**************************************
                FrmCompEgreCpp.txtcheque.Enabled = False
                FrmCompEgreCpp.txtbanco.Enabled = False
                FrmCompEgreCpp.txtsucursal.Enabled = False
            ElseIf lbfp.Text = "cheque" Then
                FrmCompEgreCpp.chefectivo.Checked = False
                FrmCompEgreCpp.lbfp.Text = "Cheque No."
                FrmCompEgreCpp.lb1.Text = "Banco"
                FrmCompEgreCpp.lb2.Text = "Sucursal"
                '*******************************
                FrmCompEgreCpp.txtcheque.Text = lbnum.Text 'numero de cheque
                FrmCompEgreCpp.txtbanco.Text = lbbanco.Text 'Banco
                FrmCompEgreCpp.txtsucursal.Text = "" 'Sucursal
                '**************************************
                FrmCompEgreCpp.txtcheque.Enabled = True
                FrmCompEgreCpp.txtbanco.Enabled = True
                FrmCompEgreCpp.txtsucursal.Enabled = True
            ElseIf lbfp.Text = "consignacion" Then
                FrmCompEgreCpp.chefectivo.Checked = False
                FrmCompEgreCpp.lbfp.Text = "Consignacion No."
                FrmCompEgreCpp.lb1.Text = "Banco"
                FrmCompEgreCpp.lb2.Text = "Sucursal"
                '*******************************
                FrmCompEgreCpp.txtcheque.Text = lbnum.Text 'numero de cheque
                FrmCompEgreCpp.txtbanco.Text = lbbanco.Text 'Banco
                FrmCompEgreCpp.txtsucursal.Text = "" 'Sucursal
                '**************************************
                FrmCompEgreCpp.txtcheque.Enabled = True
                FrmCompEgreCpp.txtbanco.Enabled = True
                FrmCompEgreCpp.txtsucursal.Enabled = True
            ElseIf lbfp.Text = "tarjeta" Then
                FrmCompEgreCpp.chefectivo.Checked = False
                FrmCompEgreCpp.lbfp.Text = "Tarjeta"
                FrmCompEgreCpp.lb1.Text = "Banco"
                FrmCompEgreCpp.lb2.Text = "Numero"
                '*******************************
                FrmCompEgreCpp.txtcheque.Text = lbtipotar.Text  'tipo tarjeta
                FrmCompEgreCpp.txtbanco.Text = lbbanco.Text 'Tarjeta
                FrmCompEgreCpp.txtsucursal.Text = lbnum.Text  'numero tarjeta
                '**************************************
                FrmCompEgreCpp.txtcheque.Enabled = True
                FrmCompEgreCpp.txtbanco.Enabled = True
                FrmCompEgreCpp.txtsucursal.Enabled = True
            End If
            If Trim(FrmCompEgreCpp.txtconcepto.Text) = "" Then FrmCompEgreCpp.txtconcepto.Text = "CUENTAS POR PAGAR A " & txtcliente.Text
            Me.Close()
        End If
    End Sub
    '*************************************************
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String)
        If cuenta = "" Then Exit Sub
        j = j + 1
        grilla.Item("cuenta", j).Value = cuenta
        grilla.Item("Descripcion", j).Value = descrip
        grilla.Item("Base", j).Value = "0,00"
        grilla.Item("doc_afe", j).Value = ""
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
                    monto = CDbl(FrmCompEgreCpp.txtvalor.Text)
                    monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                Catch ex As Exception
                    monto = 0
                End Try
                If FrmCompEgreCpp.txttipo.Text = lbdoc_aj.Text Then 'documento de ajuste
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else 'documento de proveedor
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "cpp"
                Try
                    monto = CDbl(gitems.Item("abono", fo).Value)
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
                grilla.Item("doc_afe", j).Value = gitems.Item("doc", fo).Value
                If monto >= CDbl(gitems.Item("saldo", fo).Value) Then
                    grilla.Item("abonado", j).Value = Moneda(gitems.Item("saldo", fo).Value)
                Else
                    grilla.Item("abonado", j).Value = Moneda(monto)
                End If
            Case "cpp2"
                Try
                    monto = CDbl(gitems.Item("saldo", fo).Value)
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
                grilla.Item("doc_afe", j).Value = gitems.Item("doc", fo).Value
                If monto >= CDbl(gitems.Item("saldo", fo).Value) Then
                    grilla.Item("abonado", j).Value = Moneda(gitems.Item("saldo", fo).Value)
                Else
                    grilla.Item("abonado", j).Value = Moneda(monto)
                End If
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
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else 'documento de proveedor
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("Base", j).Value = gitems.Item("b1", fo).Value
                grilla.Item("abonado", j).Value = "0,00"
                grilla.Item("DocAnti", j).Value = gitems.Item("do1", fo).Value
            Case "2-"
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
            Case "3-"
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
            Case "1+"
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
            Case "2+"
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
            Case "3+"
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
        End Select
    End Sub
    '*************************************************
    Private Sub cmdfpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfpago.Click
        Dim suma As Double = 0
        Try
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
        Catch ex As Exception
        End Try
        Try
            FrmFormaPago2.lbform.Text = "cpp_eg"
            FrmFormaPago2.txttotal.Text = Moneda(suma)
            FrmFormaPago2.ShowDialog()
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        txtnumfac.Text = NumeroDoc(txtnumfac.Text)
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
        FrmCompEgreCpp.txtvalor.Text = Moneda(txtvalor.Text)
        FrmCompEgreCpp.lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
        For i = 0 To FrmCompEgreCpp.grilla.RowCount - 1
            Try
                If Trim(FrmCompEgreCpp.grilla.Item("Descripcion", i).Value) = Trim(txtcliente.Text) Then
                    If lbdoc_aj.Text <> txttipo.Text Then
                        FrmCompEgreCpp.grilla.Item("Creditos", i).Value = Moneda(txtvalor.Text)
                    Else
                        FrmCompEgreCpp.grilla.Item("Debitos", i).Value = Moneda(txtvalor.Text)
                    End If
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub txtvalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvalor.TextChanged

    End Sub
End Class