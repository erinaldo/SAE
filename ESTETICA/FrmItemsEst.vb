Public Class FrmItemsEst
    Public bajPrec, rol, fr, p1 As String
    Private Sub FrmItemsEst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lbform.Text = "frs" Then
            lbeditarnit.Visible = True
        Else
            lbeditarnit.Visible = False
        End If
        '***************** MANEJA CONCEPTOS COMISIONABLES *****************
        Try
            Dim tc As New DataTable
            myCommand.CommandText = "SELECT comventa FROM parafacgral ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            If Trim(tc.Rows(0).Item("comventa").ToString) = "NO" Or Trim(tc.Rows(0).Item("comventa").ToString) = "no" Then
                gitems.Columns("codcom").ReadOnly = True
            Else
                gitems.Columns("codcom").ReadOnly = False
            End If
        Catch ex As Exception
            gitems.Columns("codcom").ReadOnly = True
        End Try
        '******************************************************************


        gitems.AllowUserToAddRows = True

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
        '**********************************************************
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
        gitems.Item(2, 0).Selected = True
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With

        '............................

        Try
            If LbTipoMov.Text = "salidas" And lbform.Text <> "frs" And lbform.Text <> "fn" And lbform.Text <> "fn_sp" And lbform.Text <> "fp" Then

                Dim ta As New DataTable
                myCommand.CommandText = "SELECT vsalida FROM parinven;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(ta)
                Refresh()
                lbParSalida.Text = ta.Rows(0).Item(0)
            Else
                lbParSalida.Text = ""
            End If

        Catch ex As Exception
        End Try

        Try
            Dim tb As New DataTable
            myCommand.CommandText = "SELECT lista_art FROM parafacgral ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                lbExistencia.Text = tb.Rows(0).Item(0)
            Else
                lbExistencia.Text = ""
            End If
        Catch ex As Exception
        End Try

        bajPrec = ""
        fr = ""
        Try
            Dim tc As New DataTable
            myCommand.CommandText = "SELECT lista_pre, formcosto FROM parafacgral ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            If tc.Rows.Count > 0 Then
                bajPrec = tc.Rows(0).Item(0)
                fr = tc.Rows(0).Item(1)
            Else
                bajPrec = ""
            End If
        Catch ex As Exception
        End Try
        rol = ""
        Try
            Dim tt As New DataTable
            myCommand.CommandText = "SELECT rol FROM sae.usuarios where login='" & FrmPrincipal.lbuser.Text & "' LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tt)
            rol = tt.Rows(0).Item(0)
        Catch ex As Exception
        End Try

    End Sub
    Public col, fila, filad, FinEdit As Integer
    'INICIO DE EDICION DE CELDAS
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        FinEdit = 1
        If FrmPrincipal.Inventarios.Enabled = False Then
            gitems.Item(1, e.RowIndex).Value = "S"
        End If
        Try
            ' **** ITEMS POR EQUIPO ***
            If Trim(gitems.Item(1, e.RowIndex).Value.ToString) = "" Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\item.txt") Then
                    gitems.Item(1, e.RowIndex).Value = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\item.txt")
                End If
            End If
            '*******************
        Catch ex As Exception
            Try
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\item.txt") Then
                    gitems.Item(1, e.RowIndex).Value = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\item.txt")
                End If
            Catch ex2 As Exception

            End Try

        End Try

        '-----------------------------------------


        ''*****************  EDITAR PRECIOS  *****************
        If lbform.Text = "frs" Or lbform.Text = "fn" Or lbform.Text = "fn_sp" Then
            If gitems.Item(1, e.RowIndex).Value = "I" Then
                Try
                    'Dim tc As New DataTable
                    'myCommand.CommandText = "SELECT lista_pre FROM parafacgral ;"
                    'myAdapter.SelectCommand = myCommand
                    'myAdapter.Fill(tc)
                    'If tc.Rows(0).Item("lista_pre").ToString = "NO" Then
                    If bajPrec = "NO" Then
                        If gitems.Item(1, e.RowIndex).Value = "I" Then
                            gitems.Item("descuento", e.RowIndex).ReadOnly = True
                        Else
                            gitems.Item("descuento", e.RowIndex).ReadOnly = False
                        End If
                    Else
                        gitems.Item("descuento", e.RowIndex).ReadOnly = False
                    End If
                Catch ex As Exception
                    gitems.Item("descuento", e.RowIndex).ReadOnly = False
                End Try
            End If
        End If
        ''******************************************************************

        Select Case e.ColumnIndex
            Case 0  'CASO NUMERO
            Case 1  'CASO TIPO
                For i = 2 To gitems.ColumnCount - 1
                    gitems.Item(i, e.RowIndex).Value = ""
                Next
                If FrmPrincipal.Inventarios.Enabled = False Then
                    gitems.Item(1, e.RowIndex).Value = "S"
                End If
            Case 2  'CASO CODIGO
                If Trim(gitems.Item("codigo", e.RowIndex).Value) <> "" Then Exit Sub
                For i = 3 To gitems.ColumnCount - 1
                    gitems.Item(i, e.RowIndex).Value = ""
                Next
            Case 3
                filad = e.RowIndex
            Case 5 'precio
                Try
                    If Trim(gitems.Item("codigo", e.RowIndex).Value) = "" Or Trim(gitems.Item("precio", e.RowIndex).Value) = "" Then Exit Sub

                Catch ex As Exception
                End Try
            Case 6
            Case 7


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
        Try
            Select Case e.ColumnIndex
                Case 1  'CASO TIPO  
                    gitems.Item("codigo", e.RowIndex).Value = ""
                    gitems.Item("descrip", e.RowIndex).Value = ""
                    gitems.Item("cant", e.RowIndex).Value = ""
                    gitems.Item("precio", e.RowIndex).Value = ""
                Case 2  'CASO CODIGO  
                    If FrmPrincipal.Inventarios.Enabled = False Then
                        gitems.Item(1, e.RowIndex).Value = "S"
                        BuscarServicios(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "S")
                    Else
                        If gitems.Columns("tipo").Visible = False Then
                            gitems.Item(1, e.RowIndex).Value = "I"
                        End If
                        If Trim(gitems.Item(1, e.RowIndex).Value) = "" Then
                            FrmTipoItems.lbfila.Text = e.RowIndex
                            Try
                                FrmTipoItems.ShowDialog()
                            Catch ex As Exception
                            End Try
                        End If
                        If gitems.Item(1, e.RowIndex).Value = "I" Then
                            gitems.Item(1, e.RowIndex).Value = "I"
                            BuscarArticulos(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "I")
                        Else
                            gitems.Item(1, e.RowIndex).Value = "S"
                            BuscarServicios(e.RowIndex, gitems.Item(2, e.RowIndex).Value, "S")
                        End If
                    End If
                    If gitems.Item(2, e.RowIndex).Value = "" Then
                        gitems.Item(3, e.RowIndex).Value = ""
                    End If

                Case 3 'descripcion
                    gitems.Item(e.ColumnIndex, e.RowIndex).Value = UCase(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                    filad = e.RowIndex
                Case 4 'CASO CANTIDAD

                    gitems.Item(e.ColumnIndex, e.RowIndex).Value = Fraccion(gitems.Item(e.ColumnIndex, e.RowIndex).Value)

                    'gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                Case 5 'CASO PRECIO   
                    '*****************  EDITAR PRECIOS  *****************
                    If lbform.Text = "frs" Or lbform.Text = "fn" Or lbform.Text = "fn_sp" Then
                        If gitems.Item(1, e.RowIndex).Value <> "S" Then
                            Try
                                'Dim tc As New DataTable
                                'myCommand.CommandText = "SELECT lista_pre FROM parafacgral ;"
                                'myAdapter.SelectCommand = myCommand
                                'myAdapter.Fill(tc)
                                'If tc.Rows(0).Item("lista_pre").ToString = "NO" Then
                                If bajPrec = "NO" And rol <> "admin" Then
                                    If CDbl(gitems.Item("precio", e.RowIndex).Value) < CDbl(gitems.Item("precio2", e.RowIndex).Value) Then
                                        MsgBox("No tiene permitido bajar el precio, el precio minimo es " & Moneda(gitems.Item("precio2", e.RowIndex).Value.ToString) & "", MsgBoxStyle.Information, " Verifique")
                                        gitems.Item("precio", e.RowIndex).Value = Moneda(p1)
                                    Else
                                        gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                                    End If
                                Else
                                    gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                                End If
                            Catch ex As Exception
                                gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item("precio", e.RowIndex).Value)
                            End Try
                        End If
                    Else
                        gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item("precio", e.RowIndex).Value)
                    End If
                    gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item("precio", e.RowIndex).Value)
                    '******************************************************************
                    'gitems.Item("precio", e.RowIndex).Value = Moneda(gitems.Item("precio", e.RowIndex).Value)
                Case 6 'CASO BODEGA
                    If gitems.Item(1, e.RowIndex).Value = "S" Then
                        gitems.Item(6, e.RowIndex).Value = ""
                    End If
                Case 9
                    BuscarCuenta(e.RowIndex, gitems.Item(9, e.RowIndex).Value, "9")
                Case 10 ' CUENTA INGRESO
                    BuscarCuenta(e.RowIndex, gitems.Item(10, e.RowIndex).Value, "10")
                Case 14
                    Try
                        gitems.Item("descuento", e.RowIndex).Value = Moneda(gitems.Item("descuento", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("descuento", e.RowIndex).Value = Moneda("0")
                    End Try
                Case 15
                    BuscarVendedor(e.RowIndex, gitems.Item(15, e.RowIndex).Value, "12")
                Case 16
                Case 18 ' CASO CONCEPTOS COMISIONABLES
                    If lbform.Text = "frs" Or lbform.Text = "fn" Or lbform.Text = "fn_sp" Then
                        If gitems.Columns("codcom").ReadOnly = True Then
                            MsgBox("Usted no Maneja conceptos comisionables", MsgBoxStyle.Information)
                        Else
                            If gitems.Item("nit", e.RowIndex).Value = "" Then
                                MsgBox(" Seleccione el Vendedor, para ver los conceptos comisionables relacionados a este")
                            Else
                                Dim tabla2 As New DataTable
                                myCommand.CommandText = " SELECT  v.codcon, c.concepto, v.porcomi, v.dia_cob FROM vend_cc v, concomi c " _
                                & " WHERE v.nitv = '" & gitems.Item("nit", e.RowIndex).Value & "' and v.codcon ='" & gitems.Item("codcom", e.RowIndex).Value.ToString & "' AND v.codcon = c.codcon "
                                myAdapter.SelectCommand = myCommand
                                myAdapter.Fill(tabla2)
                                If tabla2.Rows.Count = 0 Then
                                    Try
                                        gitems.Item("codcom", e.RowIndex).Value = ""
                                        FrmConcepComiV.lbfila.Text = e.RowIndex
                                        FrmConcepComiV.lbform.Text = lbform.Text
                                        FrmConcepComiV.ShowDialog()
                                    Catch ex As Exception
                                    End Try
                                    
                                End If
                            End If
                        End If
                    End If

            End Select
            If gitems.Item(1, e.RowIndex).Value = "I" Or gitems.Item(1, e.RowIndex).Value = "" Then
                If gitems.Item("descrip", e.RowIndex).Value = "" Then Exit Sub
                Select Case lbform.Text
                    Case "traslados"
                        gitems.Item("bodega", e.RowIndex).Value = FrmTraslados.cborigen.Text
                    Case "entradas"
                        gitems.Item("bodega", e.RowIndex).Value = FrmEntradas.cbdestino.Text
                    Case "salidas"
                        gitems.Item("bodega", e.RowIndex).Value = FrmSalidas.cborigen.Text
                    Case "ajustes"
                        gitems.Item("bodega", e.RowIndex).Value = lbbodega.Text
                    Case "frs"
                        If gitems.Item("bodega", e.RowIndex).Value = "" Then gitems.Item("bodega", e.RowIndex).Value = Frmfacturarapida.lbnumbod.Text
                    Case "fn"
                        If gitems.Item("bodega", e.RowIndex).Value = "" Then gitems.Item("bodega", e.RowIndex).Value = FrmFacturasyAjustes.lbnumbod.Text
                    Case "fn_sp"
                        If gitems.Item("bodega", e.RowIndex).Value = "" Then gitems.Item("bodega", e.RowIndex).Value = FrmFacturasyAjustesSP.lbnumbod.Text
                    Case "saldosInic"
                        gitems.Item("bodega", e.RowIndex).Value = FrmSaldosIniInv.cbdestino.Text
                End Select
                If LbTipoMov.Text = "salidas" Then
                    If lbform.Text = "fp" Then Exit Sub
                    If haybodega(Val(gitems.Item("bodega", e.RowIndex).Value.ToString)) = True Then
                        ExistenciaEnBodega(gitems.Item("codigo", e.RowIndex).Value, Val(gitems.Item("bodega", e.RowIndex).Value.ToString), CDbl(gitems.Item("cant", e.RowIndex).Value.ToString), e.RowIndex)
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
    Public Sub ExistenciaEnBodega(ByVal codart As String, ByVal numbod As Integer, ByVal cantidad As Double, ByVal fila As Integer)
        Try
            ' If codart = "" Or lbform.Text = "fp" Then Exit Sub
            If codart = "" Then Exit Sub
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

            '..................
            'PARAMETRO LISTAR ARTIC CON EXISTENCIA
            Dim tc As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)

            If tabla.Rows.Count < 1 Then
                MsgBox("No hay cantidades de este articulo en la bodega " & numbod, MsgBoxStyle.Information, "SAE")
                If tc.Rows(0).Item(0) = "SI" Then
                    gitems.Item("cant", fila).Value = Decimales(0)
                End If
            Else
                If tabla.Rows(0).Item(0) < cantidad Then
                    MsgBox("Solo hay " & Decimales(tabla.Rows(0).Item(0)) & " unidades de este articulo en la bodega " & numbod & ", verifique. ", MsgBoxStyle.Information, "SAE")
                    If tc.Rows(0).Item(0) = "SI" Then
                        gitems.Item("cant", fila).Value = Decimales(tabla.Rows(0).Item(0))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("No hay cantidades de este articulo en la bodega " & numbod, MsgBoxStyle.Information, "SAE")
            gitems.Item("cant", fila).Value = Decimales(0)
        End Try
    End Sub
    Function lp(ByVal tipo As String)
        Try
            Dim t1, t2 As New DataTable
            myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & lbnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t1)
            If t1.Rows.Count = 0 Then
                If tipo = "a" Then
                    Return "precio1"
                Else
                    Return "pventa"
                End If
            Else
                If tipo = "a" Then
                    Return "precio" & t1.Rows(0).Item(0)
                Else
                    If t1.Rows(0).Item(0) > 1 Then
                        Return "pventa" & t1.Rows(0).Item(0)
                    Else
                        Return "pventa"
                    End If
                End If
            End If
        Catch ex As Exception
            If tipo = "a" Then
                Return "precio1"
            Else
                Return "pventa"
            End If
        End Try
    End Function
    Public Sub BuscarVendedor(ByVal fila As Integer, ByVal codigo As String, ByVal caso As String)

        Dim tv As New DataTable
        myCommand.CommandText = "SELECT nitv  FROM  vendedores WHERE nitv='" & codigo & "' AND estado='activo' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tv)
        Refresh()

        If tv.Rows.Count > 0 Then
            gitems.Item(15, fila).Value = tv.Rows(0).Item(0)
        Else
            gitems.Item(15, fila).Value = ""
            Try
                Dim items As Integer
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM vendedores where  estado='activo' ORDER BY nombre ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                Refresh()
                items = tabla2.Rows.Count
                FrmSelVendedor.gitems.RowCount = items + 1
                For i = 0 To items - 1
                    FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                    FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
                Next
                Try
                    FrmSelVendedor.lbfila.Text = fila
                    FrmSelVendedor.lbform.Text = "item_s"
                    FrmSelVendedor.ShowDialog()
                Catch ex As Exception
                End Try
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Public Sub BuscarCuenta(ByVal fila As Integer, ByVal codigo As String, ByVal caso As String)

        Try

            Dim ta As New DataTable
            myCommand.CommandText = "SELECT codigo  FROM  selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            Refresh()
            If ta.Rows.Count <= 0 Then
                Select Case caso
                    Case "9"
                        FrmCuentas.txtcuenta.Text = gitems.Item(9, fila).Value
                        gitems.Item(9, fila).Value = ""
                        FrmCuentas.lbform.Text = "it_costo"
                        FrmCuentas.lbfila.Text = fila
                        FrmCuentas.ShowDialog()
                    Case "10"
                        FrmCuentas.txtcuenta.Text = gitems.Item(10, fila).Value
                        gitems.Item(10, fila).Value = ""
                        FrmCuentas.lbform.Text = "Items_ctaing"
                        FrmCuentas.lbfila.Text = fila
                        FrmCuentas.ShowDialog()
                End Select


            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub BuscarArticulos(ByVal fila As Integer, ByVal codigo As String, ByVal tipo As String)
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            'myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & codigo & "' AND nivel='Articulo' And estado='Activo' ORDER BY codart;"
            myCommand.CommandText = "SELECT a.*,  FORMAT(SUM(v.ctotal),2) AS ct, (SELECT IF(margmin='S',CAST(margen AS SIGNED),0) FROM parafacts WHERE factura='RAPIDA') AS margin  FROM articulos a, vista_canti  v WHERE a.codart='" & codigo & "' AND a.nivel='Articulo' And  a.estado='Activo' and v.codart = a.codart GROUP BY codart ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            FrmSelArticulos.lb.Text = "BUSCAR ARTICULOS POR DESCRIPCIÓN"
            FrmSelArticulos.cb_buscar.Text = "CODIGO"
            If items = 0 Or codigo = "" Then
                FrmSelArticulos.lbform.Text = "itemsEst"
                FrmSelArticulos.lbiva.Text = lbiva.Text
                FrmSelArticulos.txtcuenta.Text = codigo
                FrmSelArticulos.fila.Text = fila
                FrmSelArticulos.ShowDialog()

                Try
                    '.....  DESCUENTO POR GRUPO FAMILIAR
                    If gitems.Item("codigo", fila).Value <> "" Then
                        Try
                            Dim taF2 As New DataTable
                            myCommand.CommandText = "SELECT pordes FROM  `grupo_flia` WHERE nitc='" & FrmFacturaEstetica.txtnitc.Text & "' LIMIT 1;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(taF2)

                            If taF2.Rows.Count <> 0 Then
                                gitems.Item("descuento", fila).Value = Moneda(taF2.Rows(0).Item(0).ToString)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
            Else

                '---- VALIDAR CUENTAS ARTICULOS
                If (lbform.Text = "frs" And Frmfacturarapida.usacontf = "si") Or (lbform.Text = "fn" And FrmFacturasyAjustes.usacontfn = "si") Or (lbform.Text = "fn_sp" And FrmFacturasyAjustesSP.usacontfn = "si") Or (lbform.Text = "frs" And FrmFacturaEstetica.usacontf = "si") Then
                    If tabla.Rows(0).Item("cue_iva_c").ToString = "" Then
                        MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            FrmProductos.txtcodigo.Text = gitems.Item("codigo", fila).Value
                            FrmProductos.lbitem.Text = "itemMod"
                            FrmProductos.ShowDialog()
                        End If
                        Exit Sub
                    End If
                    If tabla.Rows(0).Item("cue_iva_v").ToString = "" Then
                        MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            FrmProductos.txtcodigo.Text = gitems.Item("codigo", fila).Value
                            FrmProductos.lbitem.Text = "itemMod"
                            FrmProductos.ShowDialog()
                        End If
                        Exit Sub
                    End If
                    If tabla.Rows(0).Item("cue_inv").ToString = "" Then
                        MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            FrmProductos.txtcodigo.Text = gitems.Item("codigo", fila).Value
                            FrmProductos.lbitem.Text = "itemMod"
                            FrmProductos.ShowDialog()
                        End If
                        Exit Sub
                    End If
                    If tabla.Rows(0).Item("cue_cos").ToString = "" Then
                        MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            FrmProductos.txtcodigo.Text = gitems.Item("codigo", fila).Value
                            FrmProductos.lbitem.Text = "itemMod"
                            FrmProductos.ShowDialog()
                        End If
                        Exit Sub
                    End If
                    If tabla.Rows(0).Item("cue_ing").ToString = "" Then
                        MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                        Dim resultado As MsgBoxResult
                        resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            FrmProductos.txtcodigo.Text = gitems.Item("codigo", fila).Value
                            FrmProductos.lbitem.Text = "itemMod"
                            FrmProductos.ShowDialog()
                        End If
                        Exit Sub
                    End If
                End If
                '------------------------------------

                gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codart")
                If cbdesc.Text = "DETALLADA" Then
                    gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("desart")
                Else
                    gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("nomart")
                End If
                gitems.Item("cant", fila).Value = Fraccion("1")

                If lbform.Text = "salidas" Then
                    gitems.Item("iva", fila).Value = Moneda(0)
                Else
                    gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                End If

                If LbTipoMov.Text = "entradas" Or lbParSalida.Text = "CS" Then
                    gitems.Item("precio", fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                    gitems.Item("precio2", fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                Else
                    Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), gitems.Item("iva", fila).Value, tabla.Rows(0).Item("margen"), "precio")
                    If bajPrec = "SI" Then
                        Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), gitems.Item("iva", fila).Value, tabla.Rows(0).Item("margin"), "precio2")
                    Else
                        PrecMargenMin(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), gitems.Item("iva", fila).Value, tabla.Rows(0).Item("margin"), "precio2")
                        'Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), gitems.Item("iva", fila).Value, tabla.Rows(0).Item("margen"), "precio2")
                    End If
                End If
                gitems.Item("bodega", fila).Value = "1"
            End If
            gitems.Item("ctainv", fila).Value = tabla.Rows(0).Item("cue_inv").ToString
            gitems.Item("ctacven", fila).Value = tabla.Rows(0).Item("cue_cos").ToString
            gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cue_ing").ToString
            If LbTipoMov.Text = "salidas" Or lbform.Text = "fn" Or lbform.Text = "fn_sp" Then
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_v").ToString
            Else
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_c").ToString
            End If
            gitems.Item("descuento", fila).Value = Moneda("0")
            gitems.Item("disponible", fila).Value = tabla.Rows(0).Item("ct")
            '........... CONCEPTOS COMISIONABLES.....
            Try
                If lbform.Text = "fn" Or lbform.Text = "frs" Or lbform.Text = "fn_sp" Then

                    Dim taF As New DataTable
                    myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(taF)

                    If taF.Rows.Count <> 0 Then
                        If taF.Rows(0).Item(0) = "S" Then
                            gitems.Item("codcom", fila).Value = taF.Rows(0).Item(1).ToString
                        Else
                            gitems.Item("codcom", fila).Value = ""
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            '.....  DESCUENTO POR GRUPO FAMILIAR
            Try
                Dim taF2 As New DataTable
                myCommand.CommandText = "SELECT pordes FROM  `grupo_flia` WHERE nitc='" & FrmFacturaEstetica.txtnitc.Text & "' LIMIT 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(taF2)

                If taF2.Rows.Count <> 0 Then
                    gitems.Item("descuento", fila).Value = Moneda(taF2.Rows(0).Item(0).ToString)
                End If
            Catch ex As Exception
            End Try


            Costos(fila)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Costos(ByVal fila As Integer)
        Try
            Dim c As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT costprom FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
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
    Public Sub PrecMargenMin(ByVal fila As Integer, ByVal costo As Double, ByVal precio As Double, ByVal iva As Decimal, ByVal margen As Decimal, ByVal col As String)
        Try
            Dim total As Double
            Dim tabla As New DataTable
            Dim campo As String = ""
            Dim vl As Double = 0

            Select Case fr
                Case "1"
                    gitems.Item(col, fila).Value = Moneda(0)
                    Exit Sub
                Case "2"
                    vl = costo / (1 - (margen / 100))
                Case "3"
                    vl = costo * (1 + (margen / 100))
            End Select

            'myCommand.CommandText = "SELECT ROUND((" & campo & " * (1 + (" & iva.ToString.Replace(",", ".") & " / 100))) + 49,-2) AS " & campo & " FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            'myCommand.CommandText = "SELECT " _
            '& " ROUND((" & DIN(vl) & " * (1 + (" & iva.ToString.Replace(",", ".") & " / 100))) + 49,-2) AS pcon, " _
            '& " ROUND(" & DIN(vl) & " + 49,-2) AS psin " _
            '& " FROM con_inv " _
            '& " WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(tabla)

            myCommand.CommandText = "SELECT " _
          & " ROUND((" & DIN(vl) & " * (1 + (" & iva.ToString.Replace(",", ".") & " / 100))) ,0) AS pcon, " _
          & " ROUND(" & DIN(vl) & " ,0) AS psin " _
          & " FROM con_inv " _
          & " WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)


            If lbiva.Text = "NO" Then
                Try
                    total = CDbl(tabla.Rows(0).Item(1))
                Catch ex As Exception
                    total = 0
                End Try
            Else
                Try
                    total = CDbl(tabla.Rows(0).Item(0))
                Catch ex As Exception
                    total = 0
                End Try
            End If
            gitems.Item(col, fila).Value = Moneda(total)
        Catch ex As Exception
            gitems.Item(col, fila).Value = "0,00"
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Precios(ByVal fila As Integer, ByVal costo As Double, ByVal precio As Double, ByVal iva As Decimal, ByVal margen As Decimal, ByVal col As String)
        Try
            Dim total As Double
            Dim tabla As New DataTable
            Dim campo As String = lp("a")
            'myCommand.CommandText = "SELECT ROUND((" & campo & " * (1 + (" & iva.ToString.Replace(",", ".") & " / 100))) + 49,-2) AS " & campo & " FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myCommand.CommandText = "SELECT " _
            & " ROUND((" & campo & " * (1 + (" & iva.ToString.Replace(",", ".") & " / 100))) + 49,-2) AS pcon, " _
            & " ROUND(" & campo & " + 49,-2) AS psin " _
            & " FROM con_inv " _
            & " WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            'Try
            '    total = CDbl(tabla.Rows(0).Item(0))
            'Catch ex As Exception
            '    total = 0
            'End Try
            If lbiva.Text = "NO" Then
                Try
                    total = CDbl(tabla.Rows(0).Item(1))
                Catch ex As Exception
                    total = 0
                End Try
            Else
                Try
                    total = CDbl(tabla.Rows(0).Item(0))
                Catch ex As Exception
                    total = 0
                End Try
            End If
            'If lbiva.Text = "SI" And iva <> 0 Then
            '    total = total + (total * iva / 100)
            'End If
            gitems.Item(col, fila).Value = Moneda(total)
        Catch ex As Exception
            gitems.Item(col, fila).Value = "0,00"
            'MsgBox(ex.ToString)
        End Try
    End Sub
    '*******************************************************
    Public Sub BuscarServicios(ByVal fila As Integer, ByVal codigo As String, ByVal tipo As String)
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            Dim campo As String = lp("s")
            myCommand.CommandText = "SELECT * FROM servicios WHERE codser LIKE '" & UCase(codigo) & "%' ORDER BY codser;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Refresh()
            items = tabla.Rows.Count
            If items = 1 Then  'mostrar uno solo q coinside 
                gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codser")
                If cbdesc.Text = "DETALLADA" Then
                    gitems.Item("descrip", fila).Value = Trim(tabla.Rows(0).Item("descrip"))
                Else
                    gitems.Item("descrip", fila).Value = Trim(tabla.Rows(0).Item("nombre"))
                End If
                gitems.Item("cant", fila).Value = "1"
                gitems.Item("precio", fila).Value = tabla.Rows(0).Item(campo)
                gitems.Item("precio2", fila).Value = tabla.Rows(0).Item(campo)
                gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                gitems.Item("bodega", fila).Value = ""
                gitems.Item("ctainv", fila).Value = ""
                gitems.Item("ctacven", fila).Value = ""
                gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cta_ing")
                gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cta_iva")
                gitems.Item("descuento", fila).Value = Moneda("0")

                '........... CONCEPTOS COMISIONABLES.....
                Try
                    If lbform.Text = "fn" Or lbform.Text = "frs" Or lbform.Text = "fn_sp" Then

                        Dim taF As New DataTable
                        myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(taF)

                        If taF.Rows.Count <> 0 Then
                            If taF.Rows(0).Item(0) = "S" Then
                                gitems.Item("codcom", fila).Value = taF.Rows(0).Item(1).ToString
                            Else
                                gitems.Item("codcom", fila).Value = ""
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
                '.....  DESCUENTO POR GRUPO FAMILIAR
                Try
                    Dim taF2 As New DataTable
                    myCommand.CommandText = "SELECT pordes FROM  `grupo_flia` WHERE nitc='" & FrmFacturaEstetica.txtnitc.Text & "' LIMIT 1;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(taF2)

                    If taF2.Rows.Count <> 0 Then
                        gitems.Item("descuento", fila).Value = Moneda(taF2.Rows(0).Item(0).ToString)
                    End If
                Catch ex As Exception
                End Try
            Else   'mostrar algunos de la consulta LIKE de los articulos  q coinciden
                FrmSelServicio.lbform.Text = "itemsEst"
                FrmSelServicio.txtcuenta.Text = codigo
                FrmSelServicio.lbfila.Text = fila
                FrmSelServicio.ShowDialog()
                Try
                    '.....  DESCUENTO POR GRUPO FAMILIAR
                    If gitems.Item("codigo", fila).Value <> "" Then
                        Try
                            Dim taF2 As New DataTable
                            myCommand.CommandText = "SELECT pordes FROM  `grupo_flia` WHERE nitc='" & FrmFacturaEstetica.txtnitc.Text & "' LIMIT 1;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(taF2)

                            If taF2.Rows.Count <> 0 Then
                                gitems.Item("descuento", fila).Value = Moneda(taF2.Rows(0).Item(0).ToString)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try


            Select Case lbform.Text
                Case "frs"
                    FacturaEstetica()
                Case "fr"
                    FacturaRapida()
                Case "fp"
                    Pedidos()
                Case "fn"
                    FacturaNormal()
                Case "fn_sp"
                    FacturaNormalSP()
                Case "entradas"
                    F_Entradas()
                Case "salidas"
                    F_Salidas()
                Case "traslados"
                    F_Traslados()
                Case "aju_val"
                    F_Aju_Val()
                Case "ajustes"
                    F_Aju_Inv()
                Case "saldosInic"
                    F_SaldosIniciales()
            End Select
            gitems.Focus()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        FinEdit = 0
        Try
            Select Case e.ColumnIndex
                Case 1  'CASO TIPO
                Case 2  'CASO CODIGO
                    Try
                        If cmd_cod_bar.Enabled = False And Trim(gitems.Item("codigo", e.RowIndex).Value.ToString) = "" And e.RowIndex < (gitems.RowCount - 1) Then

                        End If
                    Catch ex As Exception
                    End Try
                Case 3
                    filad = fila
                Case 4
                Case 5
                    Try
                        If Trim(gitems.Item("codigo", e.RowIndex).Value) = "" Or Trim(gitems.Item("precio", e.RowIndex).Value) = "" Then Exit Sub
                        p1 = Moneda(gitems.Item("precio", e.RowIndex).Value)
                        'If lbform.Text = "fr" Or lbform.Text = "fn" Or lbform.Text = "fp" Then
                        '    FrmPrecioItems.lbform.Text = "items"
                        '    FrmPrecioItems.lbfila.Text = e.RowIndex
                        '    FrmPrecioItems.Ch1.Checked = True
                        '    FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                        '    FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
                        '    FrmPrecioItems.ShowDialog()
                        'End If
                    Catch ex As Exception
                    End Try
                Case 6
                Case 7 ' CASO CONCEPTOS COMISIONABLES

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
    '//////// CERRAR SEGUN FACTURA //////////
    Public Sub FacturaEstetica()
        Dim suma As Double
        suma = 0
        Dim descuento As Double
        Dim valor As Double
        descuento = 0
        valor = 0
        Dim j As Integer
        j = 0
        FrmFacturaEstetica.gfactura.Rows.Clear()
        FrmFacturaEstetica.gfactura.RowCount = gitems.RowCount
        ' afecta inventario
        If FrmFacturaEstetica.rbafecta1.Checked = True Then

        End If


        Dim tb As New DataTable

        Try
            For l = 0 To gitems.RowCount - 1
                If gitems.Item("codigo", l).Value <> "" And gitems.Item("bodega", l).Value = "" And gitems.Item("tipo", l).Value = "I" Then
                    MsgBox("Verifique la bodega del articulo Codigo " & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                    Exit Sub
                End If

                If gitems.Item("codigo", l).Value <> "" Then
                    Try
                        If gitems.Item("nit", l).Value = "" Then
                            MsgBox("Verifique el codigo del Asesor, para el Servicio" & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                            gitems.CurrentRow.Cells(15).Selected = True
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox("Verifique el codigo del Asesor, para el Servicio " & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                        gitems.CurrentRow.Cells(15).Selected = True
                        Exit Sub
                    End Try

                    Try
                        If gitems.Columns("codcom").ReadOnly = False Then
                            Try
                                If gitems.Item("codcom", l).Value.ToString = "" Then
                                    MsgBox("Verifique el codigo del concepto comisionable, para el Asesor " & gitems.Item("nit", l).Value, MsgBoxStyle.Exclamation, "SAE")
                                    gitems.CurrentRow.Cells(18).Selected = True
                                    Exit Sub
                                End If
                            Catch ex As Exception
                                MsgBox("Verifique el codigo del concepto comisionable, para el Asesor " & gitems.Item("nit", l).Value, MsgBoxStyle.Exclamation, "SAE")
                                gitems.CurrentRow.Cells(18).Selected = True
                                Exit Sub
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If

            Next
        Catch ex As Exception
        End Try

        For i = 0 To gitems.RowCount - 1
            Try
                If DIN(gitems.Item("precio", i).Value) <> 0 Then
                    If gitems.Item(3, i).Value <> "" And gitems.Item(2, i).Value <> "" And gitems.Item("tipo", i).Value <> "" And gitems.Item("cant", i).Value > 0 Then
                        tb.Clear()
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "SELECT " _
                        & " ROUND((" & DIN(gitems.Item("precio", i).Value) & " * (1 + ( " & DIN(gitems.Item("iva", i).Value) & " / 100) )) + 25,-2) as pcon " _
                        & "  FROM parafacgral ;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tb)

                        Dim pre As Double
                        Try
                            If lbiva.Text = "NO" Then
                                pre = CDbl(tb.Rows(0).Item(0))
                            Else
                                pre = CDbl(gitems.Item("precio", i).Value)
                            End If
                        Catch ex As Exception
                            pre = CDbl(gitems.Item("precio", i).Value)
                        End Try

                        If FrmFacturaEstetica.lb_imp_dec.Text = "S" Then
                            pre = CDbl(gitems.Item("precio", i).Value)
                        End If
                        FrmFacturaEstetica.gfactura.Item(0, j).Value = j + 1
                        FrmFacturaEstetica.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                        FrmFacturaEstetica.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                        FrmFacturaEstetica.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                        FrmFacturaEstetica.gfactura.Item(4, j).Value = pre
                        FrmFacturaEstetica.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * pre
                        suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * pre, 2)
                        valor = (CDbl(gitems.Item("cant", i).Value) * pre)
                        valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                        descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                        FrmFacturaEstetica.gfactura.Item("tipo", j).Value = gitems.Item("tipo", i).Value ' TIPO
                        FrmFacturaEstetica.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                        '  gitems.Item("cc", i).Value = cc
                        FrmFacturaEstetica.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                        '/////////////////////////////// //
                        FrmFacturaEstetica.gfactura.Item("cc", j).Value = gitems.Item("codcom", i).Value
                        FrmFacturaEstetica.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                        FrmFacturaEstetica.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                        FrmFacturaEstetica.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                        FrmFacturaEstetica.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                        FrmFacturaEstetica.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                        Try
                            If CDbl(gitems.Item("descuento", i).Value) <= 100 Then
                                FrmFacturaEstetica.gfactura.Item("descuento", j).Value = Moneda(gitems.Item("descuento", i).Value)
                            Else
                                MsgBox("Digite un valor entre 0 y 100 para el descuento")
                                Exit Sub
                            End If
                        Catch ex As Exception
                            FrmFacturaEstetica.gfactura.Item("descuento", j).Value = Moneda(0)
                        End Try
                        Try
                            FrmFacturaEstetica.gfactura.Item("nit", j).Value = gitems.Item("nit", i).Value.ToString
                        Catch ex As Exception
                            FrmFacturaEstetica.gfactura.Item("nit", j).Value = ""
                        End Try
                        FrmFacturaEstetica.gfactura.Item("precio2", j).Value = gitems.Item("precio2", i).Value.ToString
                        j = j + 1
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
        FrmFacturaEstetica.lbsubtotal.Text = Moneda(suma)
        FrmFacturaEstetica.lbdescuento.Text = Moneda(descuento)
        Me.Close()
    End Sub
    Public Sub FacturaRapida()
        Dim suma As Double
        suma = 0
        Dim descuento As Double
        Dim valor As Double
        descuento = 0
        valor = 0
        Dim j As Integer
        j = 0
        Frmfacturarapida.gfactura.Rows.Clear()
        Frmfacturarapida.gfactura.RowCount = gitems.RowCount
        ' afecta inventario
        If Frmfacturarapida.rbafecta1.Checked = True Then

        End If


        Dim tb As New DataTable

        Try
            For l = 0 To gitems.RowCount - 1
                If gitems.Item("codigo", l).Value <> "" And gitems.Item("bodega", l).Value = "" And gitems.Item("tipo", l).Value = "I" Then
                    MsgBox("Verifique la bodega del articulo Codigo " & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        For i = 0 To gitems.RowCount - 1
            Try
                If DIN(gitems.Item("precio", i).Value) <> 0 Then
                    If gitems.Item(3, i).Value <> "" And gitems.Item(2, i).Value <> "" And gitems.Item("tipo", i).Value <> "" And gitems.Item("cant", i).Value > 0 Then


                        tb.Clear()
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "SELECT " _
                        & " ROUND((" & DIN(gitems.Item("precio", i).Value) & " * (1 + ( " & DIN(gitems.Item("iva", i).Value) & " / 100) )) + 25,-2) as pcon " _
                        & "  FROM parafacgral ;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tb)

                        Dim pre As Double
                        Try
                            If lbiva.Text = "NO" Then
                                pre = CDbl(tb.Rows(0).Item(0))
                            Else
                                pre = CDbl(gitems.Item("precio", i).Value)
                            End If
                        Catch ex As Exception
                            pre = CDbl(gitems.Item("precio", i).Value)
                        End Try

                        If Frmfacturarapida.lb_imp_dec.Text = "S" Then
                            pre = CDbl(gitems.Item("precio", i).Value)
                        End If
                        Frmfacturarapida.gfactura.Item(0, j).Value = j + 1
                        Frmfacturarapida.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                        Frmfacturarapida.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                        Frmfacturarapida.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                        Frmfacturarapida.gfactura.Item(4, j).Value = pre
                        Frmfacturarapida.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * pre
                        suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * pre, 2)
                        valor = (CDbl(gitems.Item("cant", i).Value) * pre)
                        valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                        descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                        Frmfacturarapida.gfactura.Item("tipo", j).Value = gitems.Item("tipo", i).Value ' TIPO
                        Frmfacturarapida.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                        '  gitems.Item("cc", i).Value = cc
                        Frmfacturarapida.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                        '/////////////////////////////// //
                        Frmfacturarapida.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                        Frmfacturarapida.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                        Frmfacturarapida.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                        Frmfacturarapida.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                        Frmfacturarapida.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                        Frmfacturarapida.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                        Try
                            If CDbl(gitems.Item("descuento", i).Value) <= 100 Then
                                Frmfacturarapida.gfactura.Item("descuento", j).Value = Moneda(gitems.Item("descuento", i).Value)
                            Else
                                MsgBox("Digite un valor entre 0 y 100 para el descuento")
                                Exit Sub
                            End If
                        Catch ex As Exception
                            Frmfacturarapida.gfactura.Item("descuento", j).Value = Moneda(0)
                        End Try
                        Try
                            Frmfacturarapida.gfactura.Item("nit", j).Value = gitems.Item("nit", i).Value.ToString
                        Catch ex As Exception
                            Frmfacturarapida.gfactura.Item("nit", j).Value = ""
                        End Try
                        Frmfacturarapida.gfactura.Item("precio2", j).Value = gitems.Item("precio2", i).Value.ToString
                        j = j + 1
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
        Frmfacturarapida.lbsubtotal.Text = Moneda(suma)
        Frmfacturarapida.lbdescuento.Text = Moneda(descuento)
        Me.Close()
    End Sub
    Public Sub FacturaNormal()
        Dim descuento As Double
        Dim valor As Double
        valor = 0
        descuento = 0
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        FrmFacturasyAjustes.gfactura.Rows.Clear()
        FrmFacturasyAjustes.gfactura.RowCount = gitems.RowCount
        Dim tb As New DataTable

        Try
            For l = 0 To gitems.RowCount - 1
                If gitems.Item("codigo", l).Value <> "" And gitems.Item("bodega", l).Value = "" And gitems.Item("tipo", l).Value = "I" Then
                    MsgBox("Verifique la bodega del articulo Codigo " & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" And gitems.Item(2, i).Value <> "" And gitems.Item("tipo", i).Value <> "" And gitems.Item("cant", i).Value > 0 Then

                tb.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT " _
                & " ROUND((" & DIN(gitems.Item("precio", i).Value) & " * (1 + ( " & DIN(gitems.Item("iva", i).Value) & " / 100) )) + 25,-2) as pcon " _
                & "  FROM parafacgral ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)

                Dim pre As Double
                If lbiva.Text = "NO" Then
                    pre = CDbl(tb.Rows(0).Item(0))
                Else
                    pre = CDbl(gitems.Item("precio", i).Value)
                End If


                FrmFacturasyAjustes.gfactura.Item(0, j).Value = j + 1
                FrmFacturasyAjustes.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmFacturasyAjustes.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmFacturasyAjustes.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmFacturasyAjustes.gfactura.Item(4, j).Value = pre
                FrmFacturasyAjustes.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * pre
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * pre, 2)
                FrmFacturasyAjustes.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmFacturasyAjustes.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                FrmFacturasyAjustes.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                '//////////////////////////////////
                '  gitems.Item("cc", i).Value = cc
                FrmFacturasyAjustes.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmFacturasyAjustes.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmFacturasyAjustes.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmFacturasyAjustes.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmFacturasyAjustes.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmFacturasyAjustes.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value

                valor = (CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                If gitems.Item("descuento", i).Value = "" Then
                    gitems.Item("descuento", i).Value = 0
                End If
                descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                'valor = (CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                'valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                'descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                Try
                    If CDbl(gitems.Item("descuento", i).Value) <= 100 Then
                        FrmFacturasyAjustes.gfactura.Item("descuento", j).Value = Moneda(gitems.Item("descuento", i).Value)
                    Else
                        MsgBox("Digite un valor entre 0 y 100 para el descuento")
                        Exit Sub
                    End If
                Catch ex As Exception
                    FrmFacturasyAjustes.gfactura.Item("descuento", j).Value = Moneda(0)
                End Try
                Try
                    FrmFacturasyAjustes.gfactura.Item("nit", j).Value = gitems.Item("nit", i).Value.ToString
                Catch ex As Exception
                    FrmFacturasyAjustes.gfactura.Item("nit", j).Value = ""
                End Try
                FrmFacturasyAjustes.gfactura.Item("precio2", j).Value = gitems.Item("precio2", i).Value.ToString
                j = j + 1
            End If
        Next
        FrmFacturasyAjustes.lbsubtotal.Text = Moneda(suma)
        FrmFacturasyAjustes.lbdescuento.Text = Moneda(descuento)
        Me.Close()
    End Sub
    Public Sub FacturaNormalSP()
        Dim descuento As Double
        Dim valor As Double
        valor = 0
        descuento = 0
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        FrmFacturasyAjustesSP.gfactura.Rows.Clear()
        FrmFacturasyAjustesSP.gfactura.RowCount = gitems.RowCount
        Dim tb As New DataTable

        Try
            For l = 0 To gitems.RowCount - 1
                If gitems.Item("codigo", l).Value <> "" And gitems.Item("bodega", l).Value = "" And gitems.Item("tipo", l).Value = "I" Then
                    MsgBox("Verifique la bodega del articulo Codigo " & gitems.Item("codigo", l).Value, MsgBoxStyle.Exclamation, "SAE")
                    Exit Sub
                End If
            Next
        Catch ex As Exception
        End Try

        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" And gitems.Item(2, i).Value <> "" And gitems.Item("tipo", i).Value <> "" And gitems.Item("cant", i).Value > 0 Then

                tb.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT " _
                & " ROUND((" & DIN(gitems.Item("precio", i).Value) & " * (1 + ( " & DIN(gitems.Item("iva", i).Value) & " / 100) )) + 25,-2) as pcon " _
                & "  FROM parafacgral ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)

                Dim pre As Double
                If lbiva.Text = "NO" Then
                    pre = CDbl(tb.Rows(0).Item(0))
                Else
                    pre = CDbl(gitems.Item("precio", i).Value)
                End If


                FrmFacturasyAjustesSP.gfactura.Item(0, j).Value = j + 1
                FrmFacturasyAjustesSP.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmFacturasyAjustesSP.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmFacturasyAjustesSP.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmFacturasyAjustesSP.gfactura.Item(4, j).Value = pre
                FrmFacturasyAjustesSP.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * pre
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * pre, 2)
                FrmFacturasyAjustesSP.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmFacturasyAjustesSP.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                FrmFacturasyAjustesSP.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                '//////////////////////////////////
                '  gitems.Item("cc", i).Value = cc
                FrmFacturasyAjustesSP.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmFacturasyAjustesSP.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmFacturasyAjustesSP.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmFacturasyAjustesSP.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmFacturasyAjustesSP.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmFacturasyAjustesSP.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value

                valor = (CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                If gitems.Item("descuento", i).Value = "" Then
                    gitems.Item("descuento", i).Value = 0
                End If
                descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                'valor = (CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value))
                'valor = valor / (1 + (gitems.Item("iva", i).Value / 100))
                'descuento = Math.Round(descuento + (valor * (gitems.Item("descuento", i).Value / 100)), 2)
                Try
                    If CDbl(gitems.Item("descuento", i).Value) <= 100 Then
                        FrmFacturasyAjustesSP.gfactura.Item("descuento", j).Value = Moneda(gitems.Item("descuento", i).Value)
                    Else
                        MsgBox("Digite un valor entre 0 y 100 para el descuento")
                        Exit Sub
                    End If
                Catch ex As Exception
                    FrmFacturasyAjustesSP.gfactura.Item("descuento", j).Value = Moneda(0)
                End Try
                Try
                    FrmFacturasyAjustesSP.gfactura.Item("nit", j).Value = gitems.Item("nit", i).Value.ToString
                Catch ex As Exception
                    FrmFacturasyAjustesSP.gfactura.Item("nit", j).Value = ""
                End Try
                FrmFacturasyAjustesSP.gfactura.Item("precio2", j).Value = gitems.Item("precio2", i).Value.ToString
                j = j + 1
            End If
        Next
        FrmFacturasyAjustesSP.lbsubtotal.Text = Moneda(suma)
        FrmFacturasyAjustesSP.lbdescuento.Text = Moneda(descuento)
        Me.Close()
    End Sub
    Public Sub Pedidos()
        '********************************************************
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        FrmEntraPedidos.gfactura.Rows.Clear()
        FrmEntraPedidos.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" And CDbl(gitems.Item("cant", i).Value) > 0 Then
                FrmEntraPedidos.gfactura.Item(0, j).Value = j + 1
                FrmEntraPedidos.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmEntraPedidos.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmEntraPedidos.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmEntraPedidos.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmEntraPedidos.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                FrmEntraPedidos.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmEntraPedidos.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                FrmEntraPedidos.gfactura.Item("iva", j).Value = gitems.Item("iva", i).Value
                '//////////////////////////////////
                FrmEntraPedidos.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmEntraPedidos.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmEntraPedidos.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmEntraPedidos.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmEntraPedidos.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                j = j + 1
            End If
        Next
        FrmEntraPedidos.lbsubtotal.Text = Moneda(suma)
        Me.Close()
        '********************************************************     
    End Sub
    Public Sub F_Entradas()
        Dim j As Integer
        Dim suma As Double
        suma = 0
        j = 0
        FrmEntradas.gfactura.Rows.Clear()
        FrmEntradas.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" And CDbl(gitems.Item("cant", i).Value) > 0 Then
                FrmEntradas.gfactura.Item(0, j).Value = j + 1
                FrmEntradas.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmEntradas.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmEntradas.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmEntradas.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmEntradas.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                FrmEntradas.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmEntradas.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                '//////////////////////////////////
                FrmEntradas.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmEntradas.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmEntradas.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmEntradas.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmEntradas.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmEntradas.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        FrmEntradas.txttotal.Text = Moneda(suma)
        Me.Close()
    End Sub
    Public Sub F_Salidas()
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        FrmSalidas.gfactura.Rows.Clear()
        FrmSalidas.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" And CDbl(gitems.Item("cant", i).Value) > 0 Then
                If haybodega(Val(gitems.Item("bodega", i).Value)) = False Then
                    MsgBox("Favor Verifique las Bodegas de salida.  ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                FrmSalidas.gfactura.Item(0, j).Value = j + 1
                FrmSalidas.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmSalidas.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmSalidas.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmSalidas.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmSalidas.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                FrmSalidas.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmSalidas.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                '//////////////////////////////////
                FrmSalidas.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmSalidas.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmSalidas.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmSalidas.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmSalidas.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmSalidas.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        FrmSalidas.txttotal.Text = Moneda(suma)
        Me.Close()
    End Sub
    Public Sub F_Aju_Inv()
        Dim suma As Double
        suma = 0
        Dim j As Integer
        j = 0
        FrmAjustesCant.gfactura.Rows.Clear()
        FrmAjustesCant.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" Then
                FrmAjustesCant.gfactura.Item(0, j).Value = j + 1
                FrmAjustesCant.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmAjustesCant.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmAjustesCant.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmAjustesCant.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmAjustesCant.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                FrmAjustesCant.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmAjustesCant.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                '//////////////////////////////////
                FrmAjustesCant.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmAjustesCant.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmAjustesCant.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmAjustesCant.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmAjustesCant.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmAjustesCant.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        FrmAjustesCant.txttotal.Text = Moneda(suma)
        Me.Close()
    End Sub
    Public Sub F_Aju_Val()
        Dim suma As Double
        suma = 0
        FrmAjustes.gfactura.Rows.Clear()
        FrmAjustes.gfactura.RowCount = gitems.RowCount
        Dim j As Integer = 0
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" Then
                FrmAjustes.gfactura.Item(0, j).Value = j + 1
                FrmAjustes.gfactura.Item("codigo", j).Value = gitems.Item("codigo", i).Value
                FrmAjustes.gfactura.Item("desc", j).Value = gitems.Item("descrip", i).Value
                FrmAjustes.gfactura.Item("valor", j).Value = gitems.Item("precio", i).Value
                suma = Math.Round(suma + CDbl(gitems.Item("precio", i).Value), 2)
                FrmAjustes.gfactura.Item("tipo", j).Value = gitems.Item("tipo", i).Value ' TIPO
                '//////////////////////////////////
                FrmAjustes.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmAjustes.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmAjustes.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmAjustes.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmAjustes.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        FrmAjustes.txttotal.Text = Moneda(suma)
        Me.Close()
    End Sub
    Public Sub F_Traslados()
        Dim j As Integer
        j = 0
        FrmTraslados.gfactura.Rows.Clear()
        FrmTraslados.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" Then
                If haybodega(Val(gitems.Item("bodega", i).Value)) = False Then
                    MsgBox("Favor Verifique las Bodegas de salida.  ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                FrmTraslados.gfactura.Item(0, j).Value = j + 1
                FrmTraslados.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmTraslados.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmTraslados.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmTraslados.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmTraslados.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                FrmTraslados.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmTraslados.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                '//////////////////////////////////
                FrmTraslados.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmTraslados.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmTraslados.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmTraslados.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmTraslados.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmTraslados.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        Me.Close()
    End Sub
    Public Sub F_SaldosIniciales()
        Dim j As Integer
        Dim suma As Double
        suma = 0
        j = 0
        FrmSaldosIniInv.gfactura.Rows.Clear()
        FrmSaldosIniInv.gfactura.RowCount = gitems.RowCount
        For i = 0 To gitems.RowCount - 1
            If gitems.Item(3, i).Value <> "" Then
                FrmSaldosIniInv.gfactura.Item(0, j).Value = j + 1
                FrmSaldosIniInv.gfactura.Item(1, j).Value = gitems.Item("codigo", i).Value
                FrmSaldosIniInv.gfactura.Item(2, j).Value = gitems.Item("descrip", i).Value
                FrmSaldosIniInv.gfactura.Item(3, j).Value = gitems.Item("cant", i).Value
                FrmSaldosIniInv.gfactura.Item(4, j).Value = gitems.Item("precio", i).Value
                FrmSaldosIniInv.gfactura.Item(5, j).Value = CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value)
                suma = Math.Round(suma + CDbl(gitems.Item("cant", i).Value) * CDbl(gitems.Item("precio", i).Value), 2)
                FrmSaldosIniInv.gfactura.Item(6, j).Value = gitems.Item("tipo", i).Value ' TIPO
                FrmSaldosIniInv.gfactura.Item(7, j).Value = gitems.Item("bodega", i).Value ' BODEGA
                '//////////////////////////////////
                FrmSaldosIniInv.gfactura.Item("cc", j).Value = gitems.Item("cc", i).Value
                FrmSaldosIniInv.gfactura.Item("ctainv", j).Value = gitems.Item("ctainv", i).Value
                FrmSaldosIniInv.gfactura.Item("ctacven", j).Value = gitems.Item("ctacven", i).Value
                FrmSaldosIniInv.gfactura.Item("ctaing", j).Value = gitems.Item("ctaing", i).Value
                FrmSaldosIniInv.gfactura.Item("ctaiva", j).Value = gitems.Item("ctaiva", i).Value
                FrmSaldosIniInv.gfactura.Item("costo", j).Value = gitems.Item("costo", i).Value
                j = j + 1
            End If
        Next
        FrmSaldosIniInv.txttotal.Text = Moneda(suma)
        Me.Close()
    End Sub

    Private Sub cmd_cod_bar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cod_bar.Click
        FrmBuscarCodBar.lbform.Text = "itemsEst"
        FrmBuscarCodBar.lbbodega.Text = lbbodega.Text
        FrmBuscarCodBar.LbTipoMov.Text = LbTipoMov.Text
        FrmBuscarCodBar.lbiva.Text = lbiva.Text
        FrmBuscarCodBar.ShowDialog()

        gitems.Focus()
    End Sub

    Private Sub cmd_refe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_refe.Click
        FrmBuscarRefe.lbform.Text = "itemsEst"
        FrmBuscarRefe.lbbodega.Text = lbbodega.Text
        FrmBuscarRefe.LbTipoMov.Text = LbTipoMov.Text
        FrmBuscarRefe.lbiva.Text = lbiva.Text
        FrmBuscarRefe.ShowDialog()
        gitems.Focus()
    End Sub


    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick

        fila = e.RowIndex        'captura fila
        Try
            Select Case e.ColumnIndex
                Case 1  'CASO TIPO
                Case 2  'CASO CODIGO 
                Case 3
                    filad = fila
                Case 4
                Case 5
                Case 6
                Case 7 ' CASO CONCEPTOS COMISIONABLES
                    If lbform.Text = "frs" Or lbform.Text = "fn" Or lbform.Text = "fn_sp" Then
                        If gitems.Columns("codcomi").ReadOnly = True Then
                            MsgBox("Usted no Maneja conceptos comisionables", MsgBoxStyle.Information)
                        Else
                            If Frmfacturarapida.txtnitv.Text = "" Then
                                MsgBox(" Seleccione el vendedor, para ver los conceptos comisionables relacionados a este")
                            Else
                                FrmConcepComiV.lbform.Text = lbform.Text
                                FrmConcepComiV.ShowDialog()
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try

    End Sub


    Private Sub cmd_descp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_descp.Click
        If gitems.Item("codigo", fila).Value <> "" Then
            Frmdescrip_items.txtCod.Text = gitems.Item("codigo", fila).Value
            Frmdescrip_items.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If gitems.Item("codigo", fila).Value <> "" Then
            FrmNitF.txtCod.Text = gitems.Item("codigo", fila).Value
            FrmNitF.ShowDialog()
        End If
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class