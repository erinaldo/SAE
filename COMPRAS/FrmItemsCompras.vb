Public Class FrmItemsCompras

    Private Sub FrmItemsCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AJUST PROVEEDORES
        If FrmDocProveedor.txttipo.Text = FrmDocProveedor.lbdocajuste.Text Then
            gitems.Columns("ctaing").Visible = True
            gitems.Columns("ctaing").ReadOnly = False
            gitems.Columns("descuento").Visible = False
        Else
            gitems.Columns("ctaing").Visible = False
            gitems.Columns("ctaing").ReadOnly = True
            gitems.Columns("descuento").Visible = True
        End If

        '************ ¿MANEJAN CODIGOS DE BARRAS? ******************
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codbar FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If Trim(tabla.Rows(0).Item("codbar").ToString) = "SI" Or Trim(tabla.Rows(0).Item("codbar").ToString) = "si" Then
                cmd_cod_bar.Enabled = True
            Else
                cmd_cod_bar.Enabled = False
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
            'NO HAY TABLAS DE INVENTARIOS
            cmd_cod_bar.Enabled = False
        End Try
        '*************HAY INVENTARIOS*********************************************
        If FrmPrincipal.Inventarios.Enabled = False Then
            gitems.Columns(1).ReadOnly = True
            gitems.Columns("bodega").ReadOnly = True
            cmd_cod_bar.Enabled = False
            cmd_refe.Enabled = False
        Else
            gitems.Columns(1).ReadOnly = False
            gitems.Columns("bodega").ReadOnly = False
            cmd_cod_bar.Enabled = True
            cmd_refe.Enabled = True
        End If
        If cbdesc.Text = "" Then cbdesc.Text = "NORMAL"
        If gitems.RowCount = 1 Then gitems.RowCount = 2
        gitems.Item("codigo", 0).Selected = True
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Public col, fila, FinEdit As Integer
    'INICIO DE EDICION DE CELDAS
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        FinEdit = 1
        If FrmPrincipal.Inventarios.Enabled = False Then
            gitems.Item(1, e.RowIndex).Value = "G"
        End If
        Select Case e.ColumnIndex
            Case 0  'CASO NUMERO
            Case 1  'CASO TIPO
                For i = 2 To gitems.ColumnCount - 1
                    gitems.Item(i, e.RowIndex).Value = ""
                Next
                If FrmPrincipal.Inventarios.Enabled = False Then
                    gitems.Item(1, e.RowIndex).Value = "G"
                End If
            Case 2  'CASO CODIGO
                For i = 3 To gitems.ColumnCount - 1
                    gitems.Item(i, e.RowIndex).Value = ""
                Next
            Case 3 'CASO DESCRPICION
            Case 4 'CASO CANTIDAD
            Case 5 'CASO PRECIO
                Try
                    If Trim(gitems.Item("codigo", e.RowIndex).Value) = "" Or Trim(gitems.Item("precio", e.RowIndex).Value) = "" Then Exit Sub
                    'If lbform.Text = "fr" Or lbform.Text = "fn" Or lbform.Text = "fp" Then
                    FrmPrecioItems.lbform.Text = "itemsC"
                    FrmPrecioItems.lbfila.Text = e.RowIndex
                    FrmPrecioItems.Ch1.Checked = True
                    FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                    FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
                    FrmPrecioItems.ShowDialog()
                    ' End If
                Catch ex As Exception
                End Try
            Case 6 'CASO BODEGA
        End Select
    End Sub
    Private Sub gitems_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gitems.CellValidating
        If FinEdit = 1 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
    End Sub
    'FIN DE EDICION DE CELDAS
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM `bodegas`;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Try
            Select Case e.ColumnIndex
                Case 0  'CASO NUMERO
                Case 1  'CASO TIPO  
                    gitems.Item(2, e.RowIndex).Value = ""
                    gitems.Item(3, e.RowIndex).Value = ""
                    gitems.Item(4, e.RowIndex).Value = ""
                    gitems.Item(5, e.RowIndex).Value = ""
                Case 2  'CASO CODIGO  
                    If FrmPrincipal.Inventarios.Enabled = False Then
                        gitems.Item(1, e.RowIndex).Value = "G"
                        BuscarGastos(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "S")
                    Else
                        If gitems.Columns("tipo").Visible = False Then
                            gitems.Item(1, e.RowIndex).Value = "I"
                        End If
                        If Trim(gitems.Item(1, e.RowIndex).Value) = "" Then
                            FrmTipoItems.lbfila.Text = e.RowIndex
                            Try
                                FrmTipoItems.Ch_Ser.Text = "&Gastos"
                                FrmTipoItems.lbser.Text = "Alt + G = Gastos"
                                FrmTipoItems.ShowDialog()
                                FrmTipoItems.Ch_Ser.Text = "&Servicios"
                                FrmTipoItems.lbser.Text = "Alt + S = Servicios"
                            Catch ex As Exception
                            End Try
                        End If
                        If gitems.Item(1, e.RowIndex).Value = "I" Then
                            gitems.Item(1, e.RowIndex).Value = "I"
                            BuscarArticulos(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "I")
                        Else
                            gitems.Item(1, e.RowIndex).Value = "G"
                            BuscarGastos(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "G")
                        End If
                    End If
                Case 3 'CASO DESCRPICION
                Case 4 'CASO CANTIDAD
                    gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                Case 5 'CASO PRECIO                   
                    gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                Case 6 'CASO BODEGA
                    If gitems.Item(1, e.RowIndex).Value = "G" Then
                        gitems.Item(6, e.RowIndex).Value = ""
                    ElseIf gitems.Item(6, e.RowIndex).Value > tabla.Rows(0).Item(0) Or gitems.Item(6, e.RowIndex).Value < 0 Then
                        MsgBox("El numero no corresponde a ninguna bodega")
                        gitems.Item(6, e.RowIndex).Value = ""
                    End If
                Case 10 ' CUENTA INGRESO
                    BuscarCuentaP(e.RowIndex, gitems.Item("ctaing", e.RowIndex).Value, "10")
                Case 12 ' IVA
                    gitems.Item("iva", e.RowIndex).Value = Moneda(gitems.Item("iva", e.RowIndex).Value)
                    Try
                        If Trim(gitems.Item("codigo", e.RowIndex).Value) = "" Or Trim(gitems.Item("precio", e.RowIndex).Value) = "" Then Exit Sub
                        'If lbform.Text = "fr" Or lbform.Text = "fn" Or lbform.Text = "fp" Then
                        FrmPrecioItems.lbform.Text = "itemsC"
                        FrmPrecioItems.lbfila.Text = e.RowIndex
                        FrmPrecioItems.Ch1.Checked = True
                        FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                        FrmPrecioItems.txt1.Text = Moneda(0)
                        FrmPrecioItems.ShowDialog()
                        ' End If
                    Catch ex As Exception
                    End Try
                Case 14
                    Try
                        gitems.Item("descuento", e.RowIndex).Value = Moneda(gitems.Item("descuento", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("descuento", e.RowIndex).Value = Moneda("0")
                    End Try

            End Select
            If gitems.Item(1, e.RowIndex).Value = "I" Or gitems.Item(1, e.RowIndex).Value = "" Then
                If gitems.Item("descrip", e.RowIndex).Value = "" Then Exit Sub
                Select Case lbform.Text
                    Case "traslados"
                        gitems.Item(6, e.RowIndex).Value = FrmTraslados.cborigen.Text
                    Case "entradas"
                        gitems.Item(6, e.RowIndex).Value = FrmEntradas.cbdestino.Text
                    Case "salidas"
                        gitems.Item(6, e.RowIndex).Value = FrmSalidas.cborigen.Text
                    Case "ajustes"
                        gitems.Item(6, e.RowIndex).Value = lbbodega.Text
                    Case "fr"
                        If gitems.Item(6, e.RowIndex).Value = "" Then gitems.Item(6, e.RowIndex).Value = Frmfacturarapida.lbnumbod.Text
                End Select
                If LbTipoMov.Text = "salidas" Then
                    If lbform.Text = "fp" Then Exit Sub
                    If haybodega(Val(gitems.Item("bodega", e.RowIndex).Value.ToString)) = True Then
                        ExistenciaEnBodega(gitems.Item(2, e.RowIndex).Value, Val(gitems.Item("bodega", e.RowIndex).Value.ToString), Val(gitems.Item("cant", e.RowIndex).Value.ToString))
                    Else
                        MsgBox("Verifique la bodega  " & gitems.Item("bodega", e.RowIndex).Value.ToString & " no existe en los registros, verifique. ", MsgBoxStyle.Information, "SAE")
                        gitems.Item("bodega", e.RowIndex).Value = ""
                        gitems.Item("bodega", e.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BuscarCuentaP(ByVal fila As Integer, ByVal codigo As String, ByVal caso As String)

        Try
            Dim ta As New DataTable
            myCommand.CommandText = "SELECT codigo  FROM  selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            Refresh()
            If ta.Rows.Count <= 0 Then
                Select Case caso
                    Case "10"
                        FrmCuentas.txtcuenta.Text = gitems.Item(10, fila).Value
                        gitems.Item(10, fila).Value = ""
                        FrmCuentas.lbform.Text = "ItemsPr_ctaing"
                        FrmCuentas.lbfila.Text = fila
                        FrmCuentas.ShowDialog()
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function haybodega(ByVal numbod As Integer)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & numbod & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub ExistenciaEnBodega(ByVal codart As String, ByVal numbod As Integer, ByVal cantidad As Double)
        Try
            If codart = "" Or lbform.Text = "fp" Then Exit Sub
            Dim tabla As New DataTable
            If numbod = 0 Then
                MsgBox("Seleccione una bodega de salida.  ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            Else
                myCommand.CommandText = "SELECT cant" & numbod & " FROM con_inv WHERE periodo='" & PerActual(0) & PerActual(1) & "' AND codart='" & codart & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                MsgBox("No hay cantidades de este articulo en la bodega " & numbod, MsgBoxStyle.Information, "SAE")
            Else
                If tabla.Rows(0).Item(0) < cantidad Then
                    MsgBox("Solo hay " & Decimales(tabla.Rows(0).Item(0)) & " unidades de este articulo en la bodega " & numbod & ", verifique. ", MsgBoxStyle.Information, "SAE")
                End If
            End If
        Catch ex As Exception
            MsgBox("No hay cantidades de este articulo en la bodega " & numbod, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Public Sub BuscarArticulos(ByVal fila As Integer, ByVal codigo As String, ByVal tipo As String)
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            If Ch_Ref.Checked = True Then
                myCommand.CommandText = "SELECT * FROM articulos WHERE (codart='" & codigo & "' OR referencia='" & codigo & "') AND nivel='Articulo' And estado='Activo' ORDER BY codart;"
            Else
                myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & codigo & "' AND nivel='Articulo' And estado='Activo' ORDER BY codart;"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            FrmSelArticulos.lb.Text = "BUSCAR ARTICULOS POR DESCRIPCIÓN"
            FrmSelArticulos.cb_buscar.Text = "CODIGO"
            If items = 0 Or codigo = "" Then
                FrmSelArticulos.lbform.Text = "itemsC"
                FrmSelArticulos.txtcuenta.Text = codigo
                FrmSelArticulos.fila.Text = fila
                FrmSelArticulos.ShowDialog()
                FrmSelArticulos.lbform.Text = "items"
            Else
                gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codart")
                If cbdesc.Text = "DETALLADA" Then
                    gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("desart")
                Else
                    gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("nomart")
                End If
                gitems.Item("cant", fila).Value = "1"

                If lbform.Text = "fdp" Or lbform.Text = "oc" Then
                    gitems.Item(5, fila).Value = (tabla.Rows(0).Item("cos_uni") * (1 + (tabla.Rows(0).Item("iva") / 100)))
                    gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                Else
                    If LbTipoMov.Text = "entradas" Then
                        gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                        gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                    Else
                        gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("precio"))
                        Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"))
                        gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                    End If
                End If
             
                gitems.Item(6, fila).Value = "1"
            End If
            gitems.Item("ctainv", fila).Value = tabla.Rows(0).Item("cue_inv").ToString
            gitems.Item("ctacven", fila).Value = tabla.Rows(0).Item("cue_cos").ToString
            gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cue_ing").ToString
            If LbTipoMov.Text = "salidas" Then
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_v").ToString
            Else
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_c").ToString
            End If
            gitems.Item("descuento", fila).Value = Moneda(0)
            'gitems.Item("costo", fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
            Costos(fila)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Costos(ByVal fila As Integer)
        Try
            Dim c As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT costuni FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                c = CDbl(tabla.Rows(0).Item(0))
            Catch ex As Exception
                c = 0
            End Try
            gitems.Item("costo", fila).Value = Moneda(c)
        Catch ex As Exception
            gitems.Item("costo", fila).Value = "0,00"
        End Try
    End Sub
    Public Sub Precios(ByVal fila As Integer, ByVal costo As Double, ByVal precio As Double, ByVal iva As Decimal, ByVal margen As Decimal)
        Dim total As Double
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT precio1 FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            total = CDbl(tabla.Rows(0).Item("precio1"))
        Catch ex As Exception
            total = 0
        End Try
        If lbiva.Text = "SI" And iva <> 0 Then
            total = total + (total * iva / 100)
        End If
        gitems.Item("precio", fila).Value = total
    End Sub
    Public Sub BuscarGastos(ByVal fila As Integer, ByVal codigo As String, ByVal tipo As String)
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM gastos WHERE cod_gas LIKE '" & UCase(codigo) & "%' ORDER BY cod_gas;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 1 Then  'mostrar uno solo q coinside 
                gitems.Item(2, fila).Value = tabla.Rows(0).Item("cod_gas")
                If cbdesc.Text = "DETALLADA" Then
                    gitems.Item(3, fila).Value = Trim(tabla.Rows(0).Item("desc_gas"))
                Else
                    gitems.Item(3, fila).Value = Trim(tabla.Rows(0).Item("nom_gas"))
                End If
                gitems.Item(4, fila).Value = "1"
                gitems.Item(5, fila).Value = "0,00"
                gitems.Item("iva", fila).Value = tabla.Rows(0).Item("por_iva")
                gitems.Item(6, fila).Value = ""
                gitems.Item("ctainv", fila).Value = ""
                gitems.Item("ctacven", fila).Value = ""
                gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cta_gas")
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cta_iva")
                gitems.Item("descuento", fila).Value = Moneda(0)
            Else   'mostrar algunos de la consulta LIKE de los articulos  q coinciden
                FrmSelGasto.txtcuenta.Text = codigo
                FrmSelGasto.lbfila.Text = fila
                FrmSelGasto.ShowDialog()
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Select Case lbform.Text
            Case "fdp"
                FacturaDocProveedores()
            Case "oc"
                Orden_de_Compra()
        End Select
        gitems.Focus()
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO NUMERO
                Case 1  'CASO TIPO
                    If cmd_cod_bar.Enabled = False Then
                        SendKeys.Send(Chr(Keys.Space))
                        SendKeys.Send(Chr(Keys.Back))
                    End If
                Case 2  'CASO CODIGO
                Case 3 'CASO DESCRPICION
                Case 4 'CASO CANTIDAD
                Case 5 'CASO PRECIO
                    If Trim(gitems.Item("codigo", e.RowIndex).Value) = "" Or Trim(gitems.Item("precio", e.RowIndex).Value) = "" Then Exit Sub
                    'If lbform.Text = "fr" Or lbform.Text = "fn" Or lbform.Text = "fp" Then
                    FrmPrecioItems.lbform.Text = "itemsC"
                    FrmPrecioItems.lbfila.Text = e.RowIndex
                    FrmPrecioItems.Ch1.Checked = True
                    FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                    FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
                    FrmPrecioItems.ShowDialog()
                    'End If
                Case 6 'CASO BODEGA               
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmddel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddel.Click
        If fila = gitems.RowCount - 1 Then Exit Sub
        gitems.Rows.RemoveAt(fila)
    End Sub
    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.F10) Then
            cmdadd_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub Ch_Cod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch_Cod.CheckedChanged
        If Ch_Cod.Checked = True Then
            Ch_Ref.Checked = False
        Else
            Ch_Cod.Checked = False
        End If
    End Sub
    Private Sub Ch_Ref_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch_Ref.CheckedChanged
        If Ch_Ref.Checked = True Then
            Ch_Cod.Checked = False
        Else
            Ch_Ref.Checked = False
        End If
    End Sub

    Private Sub cmd_cod_bar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cod_bar.Click
        FrmBuscarCodBar.lbform.Text = "itemsC"
        FrmBuscarCodBar.lbbodega.Text = lbbodega.Text
        FrmBuscarCodBar.LbTipoMov.Text = LbTipoMov.Text
        FrmBuscarCodBar.lbiva.Text = lbiva.Text
        FrmBuscarCodBar.ShowDialog()
        gitems.Focus()
    End Sub

    Private Sub cmd_refe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_refe.Click
        FrmBuscarRefe.lbform.Text = "itemsC"
        FrmBuscarRefe.lbbodega.Text = lbbodega.Text
        FrmBuscarRefe.LbTipoMov.Text = LbTipoMov.Text
        FrmBuscarRefe.lbiva.Text = lbiva.Text
        FrmBuscarRefe.ShowDialog()
        gitems.Focus()
    End Sub


    Public Sub FacturaDocProveedores()
        Dim suma As Double
        Dim valor, descuento As Double
        suma = 0
        valor = 0
        descuento = 0
        Dim j As Integer
        j = 0
        FrmDocProveedor.gfactura.Rows.Clear()
        FrmDocProveedor.gfactura.RowCount = gitems.RowCount
        Dim bod As Integer = 0
        Try
            For i = 0 To gitems.RowCount - 1
                If Trim(gitems.Item("codigo", i).Value) <> "" And Trim(gitems.Item("tipo", i).Value) <> "" Then
                    Try
                        bod = Val(gitems.Item("bodega", i).Value.ToString)
                    Catch ex As Exception
                        bod = 1
                    End Try
                    If Trim(gitems.Item("tipo", i).Value) = "I" And bod = 0 Then
                        MsgBox("Verifique las bodegas de los articulos de inventario.  ", MsgBoxStyle.Information, "SAE Control")
                        Exit Sub
                    End If
                    FrmDocProveedor.gfactura.Item("num", j).Value = j + 1
                    FrmDocProveedor.gfactura.Item("tipo", j).Value = gitems.Item("tipo", i).Value
                    FrmDocProveedor.gfactura.Item("codigo", j).Value = gitems.Item("codigo", i).Value
                    FrmDocProveedor.gfactura.Item("descrip", j).Value = gitems.Item("descrip", i).Value
                    FrmDocProveedor.gfactura.Item("cant", j).Value = gitems.Item("cant", i).Value
                    FrmDocProveedor.gfactura.Item("valor", j).Value = gitems.Item("precio", i).Value
                    FrmDocProveedor.gfactura.Item("Vtotal", j).Value = Moneda(CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                    suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                    FrmDocProveedor.gfactura.Item("bodega", j).Value = gitems.Item("bodega", i).Value ' BODEGA
                    FrmDocProveedor.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                    '//////////////////////////////////
                    Try
                        FrmDocProveedor.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                    Catch ex As Exception
                        FrmDocProveedor.gfactura.Item("cc", j).Value = ""
                    End Try
                    FrmDocProveedor.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                    FrmDocProveedor.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                    FrmDocProveedor.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value 'cta ing / gas 
                    FrmDocProveedor.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                    'descuento
                    valor = (CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                    valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                    descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                    Try
                        If CDbl(gitems.Item("descuento", i).Value) <= 100 Then
                            FrmDocProveedor.gfactura.Item("descuento", j).Value = Moneda(gitems.Item("descuento", i).Value)
                        Else
                            MsgBox("Digite un valor entre 0 y 100 para el descuento")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        FrmDocProveedor.gfactura.Item("descuento", j).Value = Moneda(0)
                    End Try
                    ' costo
                    Try
                        FrmDocProveedor.gfactura.Item("costo", j).Value = gitems.Item("precio", i).Value / (1 + (gitems.Item("iva", i).Value / 100))
                    Catch ex As Exception
                        FrmDocProveedor.gfactura.Item("costo", j).Value = gitems.Item("precio", i).Value
                    End Try
                    j = j + 1
                End If
            Next
        Catch ex As Exception
        End Try
        
        FrmDocProveedor.lbsubtotal.Text = Moneda(suma)
        FrmDocProveedor.lbdescuento.Text = Moneda(descuento)
        Me.Close()
    End Sub

    Public Sub Orden_de_Compra()
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        Try
            FrmOrdenCompra.gfactura.Rows.Clear()
            FrmOrdenCompra.gfactura.RowCount = gitems.RowCount
            Dim bod As Integer = 0
            For i = 0 To gitems.RowCount - 1
                If Trim(gitems.Item("codigo", i).Value) <> "" And Trim(gitems.Item("tipo", i).Value) <> "" Then
                    Try
                        bod = Val(gitems.Item("bodega", i).Value.ToString)
                    Catch ex As Exception
                        bod = 0
                    End Try
                    'If Trim(gitems.Item("tipo", i).Value) = "I" And bod = 0 Then
                    '    MsgBox("Verifique las bodegas de los articulos de inventario.  ", MsgBoxStyle.Information, "SAE Control")
                    '    Exit Sub
                    'End If
                    FrmOrdenCompra.gfactura.Item("num", j).Value = j + 1
                    FrmOrdenCompra.gfactura.Item("tipo", j).Value = gitems.Item("tipo", i).Value
                    FrmOrdenCompra.gfactura.Item("codigo", j).Value = gitems.Item("codigo", i).Value
                    FrmOrdenCompra.gfactura.Item("descrip", j).Value = gitems.Item("descrip", i).Value
                    FrmOrdenCompra.gfactura.Item("cant", j).Value = gitems.Item("cant", i).Value
                    FrmOrdenCompra.gfactura.Item("valor", j).Value = gitems.Item("precio", i).Value
                    FrmOrdenCompra.gfactura.Item("Vtotal", j).Value = Moneda(CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                    suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                    FrmOrdenCompra.gfactura.Item("bodega", j).Value = gitems.Item("bodega", i).Value ' BODEGA
                    FrmOrdenCompra.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                    If gitems.Item("iva", i).Value <> "0,00" Then
                        FrmOrdenCompra.valoriva.Text = gitems.Item("iva", i).Value
                    End If
                    '//////////////////////////////////
                    FrmOrdenCompra.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                    FrmOrdenCompra.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                    FrmOrdenCompra.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                    FrmOrdenCompra.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value 'cta ing / gas 
                    FrmOrdenCompra.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                    Try
                        FrmOrdenCompra.gfactura.Item("costo", j).Value = gitems.Item("precio", i).Value / (1 + (gitems.Item("iva", i).Value / 100))
                    Catch ex As Exception
                        FrmOrdenCompra.gfactura.Item("costo", j).Value = gitems.Item("precio", i).Value
                    End Try
                    j = j + 1
                End If
            Next
        Catch ex As Exception
        End Try
        FrmOrdenCompra.lbsubtotal.Text = Moneda(suma)
        Me.Close()
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub

    Private Sub gitems_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellMouseEnter

    End Sub
End Class