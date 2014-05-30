Imports System.Data.SqlClient

Public Class FrmSelArticulos
    Dim existe As String
    Dim f As Integer
    Dim cad As String
    Private Sub FrmSelArticulos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Me.Dispose()
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(f)
    End Sub

    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        f = e.RowIndex        'captura fila

        Select Case e.ColumnIndex
            'Case 6
            '    Try
            '        If Trim(gitems.Item("nivel", e.RowIndex).Value) <> "Articulo" Then Exit Sub
            '        If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Or FrmItems.lbform.Text = "fp" Then
            '            FrmPrecioItems.lbform.Text = "selA"
            '            FrmPrecioItems.lbfila.Text = e.RowIndex
            '            FrmPrecioItems.Ch1.Checked = True
            '            FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
            '            FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
            '            FrmPrecioItems.ShowDialog()
            '        End If
            '    Catch ex As Exception

            '    End Try
        End Select
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(f)
    End Sub
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Select Case e.ColumnIndex
            Case 5
                gitems.Item(e.ColumnIndex, e.RowIndex).Value = Decimales(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
            Case 6
                ''*****************  EDITAR PRECIOS  *****************
                If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Or FrmItemsEst.lbform.Text = "frs" Then
                    Try
                        Dim tc As New DataTable
                        myCommand.CommandText = "SELECT lista_pre FROM parafacgral ;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)
                        If tc.Rows(0).Item("lista_pre").ToString = "NO" Then
                            If CDbl(gitems.Item("precio", e.RowIndex).Value) < CDbl(gitems.Item("precio2", e.RowIndex).Value) Then
                                MsgBox("No tiene permitido bajar el precio", MsgBoxStyle.Information, " Verifique")
                                gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item("precio2", e.RowIndex).Value)
                            Else
                                gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                            End If
                        Else
                            gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                        End If
                    Catch ex As Exception
                        gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
                    End Try
                End If
                ''******************************************************************
                'gitems.Item(e.ColumnIndex, e.RowIndex).Value = Moneda(gitems.Item(e.ColumnIndex, e.RowIndex).Value)
        End Select
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        f = e.RowIndex        'captura fila
        Select Case e.ColumnIndex
            'Case 6
            '    Try
            '        If Trim(gitems.Item("nivel", e.RowIndex).Value) <> "Articulo" Then Exit Sub
            '        If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Or FrmItems.lbform.Text = "fp" Then
            '            FrmPrecioItems.lbform.Text = "selA"
            '            FrmPrecioItems.lbfila.Text = e.RowIndex
            '            FrmPrecioItems.Ch1.Checked = True
            '            FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
            '            FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
            '            FrmPrecioItems.ShowDialog()
            '        End If
            '    Catch ex As Exception

            '    End Try
        End Select
    End Sub

    Private Sub gitems_ColumnSortModeChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles gitems.ColumnSortModeChanged

    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(f - 1)
        End If
    End Sub
    Public Sub seleccionar(ByVal fo As Integer)
        If gitems.Item("nivel", fo).Value = "Articulo" Then
            Dim fd As Integer
            fd = Val(fila.Text)
            Select Case lbform.Text
                Case "items"

                    Dim ccm As String = ""
                    Try
                        If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Then
                            '..................
                            Dim tabla As New DataTable
                            myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            If tabla.Rows.Count <> 0 Then
                                If tabla.Rows(0).Item(0) = "S" Then
                                    ccm = tabla.Rows(0).Item(1)
                                Else
                                    ccm = ""
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try

                    '............ FAC NORMAL
                    Try
                        If FrmItems.lbform.Text = "fn" Then
                            '..................
                            Dim tabla As New DataTable
                            myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'NORMAL' and p.concomi = c.codcon;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            If tabla.Rows.Count <> 0 Then
                                If tabla.Rows(0).Item(0) = "S" Then
                                    ccm = tabla.Rows(0).Item(1)
                                Else
                                    ccm = ""
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try
                    '................


                    '---- VALIDAR CUENTAS ARTICULOS
                    If (FrmItems.lbform.Text = "fr" And Frmfacturarapida.usacontf = "si") Or (FrmItems.lbform.Text = "fn" And FrmFacturasyAjustes.usacontfn = "si") Then
                        If gitems.Item("ctainv", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctacven", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctaing", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctaiva", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                    End If
                    '------------------------------------

                    FrmItems.gitems.Item("tipo", fd).Value = "I"
                    FrmItems.gitems.Item("codigo", fd).Value = gitems.Item("codigo", fo).Value
                    FrmItems.gitems.Item("descrip", fd).Value = gitems.Item("desc", fo).Value
                    FrmItems.gitems.Item("cant", fd).Value = Fraccion(gitems.Item("cant", fo).Value)
                    FrmItems.gitems.Item("precio", fd).Value = gitems.Item("precio", fo).Value
                    FrmItems.gitems.Item("iva", fd).Value = gitems.Item("iva", fo).Value
                    '**************************************************************************
                    FrmItems.gitems.Item("cc", fd).Value = ccm
                    FrmItems.gitems.Item("ctainv", fd).Value = gitems.Item("ctainv", fo).Value
                    FrmItems.gitems.Item("ctacven", fd).Value = gitems.Item("ctacven", fo).Value
                    FrmItems.gitems.Item("ctaing", fd).Value = gitems.Item("ctaing", fo).Value
                    FrmItems.gitems.Item("ctaiva", fd).Value = gitems.Item("ctaiva", fo).Value
                    FrmItems.gitems.Item("costo", fd).Value = Costos(gitems.Item("codigo", fo).Value)
                    FrmItems.gitems.Item("descuento", fd).Value = "0,00"
                    Try
                        FrmItems.gitems.Item("disponible", fd).Value = gitems.Item("cant2", fo).Value
                    Catch ex As Exception
                        'FrmItems.gitems.Item("disponible", fd).Value = "0"
                    End Try
                    FrmItems.gitems.Item("precio2", fd).Value = gitems.Item("precio2", fo).Value
                    Me.Close()

                Case "itemsEst"
                    Dim ccm As String = ""
                    Try
                        If FrmItemsEst.lbform.Text = "frs" Then
                            '..................
                            Dim tabla As New DataTable
                            myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            If tabla.Rows.Count <> 0 Then
                                If tabla.Rows(0).Item(0) = "S" Then
                                    ccm = tabla.Rows(0).Item(1)
                                Else
                                    ccm = ""
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try


                    '---- VALIDAR CUENTAS ARTICULOS
                    If (FrmItemsEst.lbform.Text = "frs" And FrmFacturaEstetica.usacontf = "si") Then
                        If gitems.Item("ctainv", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctacven", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctaing", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                        If gitems.Item("ctaiva", fo).Value = "" Then
                            MsgBox("Las cuentas del articulo estan incompletas.Verifique en Catalogo de Articulos ", MsgBoxStyle.Information, "SAE Verificacion")
                            Dim resultado As MsgBoxResult
                            resultado = MsgBox("Desea agregar las cuentas para este articulo?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                FrmProductos.txtcodigo.Text = gitems.Item("codigo", fo).Value
                                FrmProductos.lbitem.Text = "itemMod"
                                FrmProductos.ShowDialog()
                                llenarGrilla(0, 1000, "N")
                            End If
                            Exit Sub
                        End If
                    End If
                    '------------------------------------

                    FrmItemsEst.gitems.Item("tipo", fd).Value = "I"
                    FrmItemsEst.gitems.Item("codigo", fd).Value = gitems.Item("codigo", fo).Value
                    FrmItemsEst.gitems.Item("descrip", fd).Value = gitems.Item("desc", fo).Value
                    FrmItemsEst.gitems.Item("cant", fd).Value = Fraccion(gitems.Item("cant", fo).Value)
                    FrmItemsEst.gitems.Item("precio", fd).Value = gitems.Item("precio", fo).Value
                    FrmItemsEst.gitems.Item("iva", fd).Value = gitems.Item("iva", fo).Value
                    '**************************************************************************
                    FrmItemsEst.gitems.Item("codcom", fd).Value = ccm
                    FrmItemsEst.gitems.Item("ctainv", fd).Value = gitems.Item("ctainv", fo).Value
                    FrmItemsEst.gitems.Item("ctacven", fd).Value = gitems.Item("ctacven", fo).Value
                    FrmItemsEst.gitems.Item("ctaing", fd).Value = gitems.Item("ctaing", fo).Value
                    FrmItemsEst.gitems.Item("ctaiva", fd).Value = gitems.Item("ctaiva", fo).Value
                    FrmItemsEst.gitems.Item("costo", fd).Value = Costos(gitems.Item("codigo", fo).Value)
                    FrmItemsEst.gitems.Item("descuento", fd).Value = "0,00"
                    Try
                        FrmItemsEst.gitems.Item("disponible", fd).Value = gitems.Item("cant2", fo).Value
                    Catch ex As Exception
                        'FrmItems.gitems.Item("disponible", fd).Value = "0"
                    End Try
                    FrmItemsEst.gitems.Item("precio2", fd).Value = gitems.Item("precio2", fo).Value
                    FrmItemsEst.gitems.Item("nit", fd).Value = ""
                    Me.Close()
                Case "itemsC"
                    FrmItemsCompras.gitems.Item("tipo", fd).Value = "I"
                    FrmItemsCompras.gitems.Item("codigo", fd).Value = gitems.Item("codigo", fo).Value
                    FrmItemsCompras.gitems.Item("descrip", fd).Value = gitems.Item("desc", fo).Value
                    FrmItemsCompras.gitems.Item("cant", fd).Value = gitems.Item("cant", fo).Value
                    FrmItemsCompras.gitems.Item("precio", fd).Value = gitems.Item("precio", fo).Value
                    FrmItemsCompras.gitems.Item("iva", fd).Value = gitems.Item("iva", fo).Value
                    '**************************************************************************
                    FrmItemsCompras.gitems.Item("cc", fd).Value = ""
                    FrmItemsCompras.gitems.Item("ctainv", fd).Value = gitems.Item("ctainv", fo).Value
                    FrmItemsCompras.gitems.Item("ctacven", fd).Value = gitems.Item("ctacven", fo).Value
                    FrmItemsCompras.gitems.Item("ctaing", fd).Value = gitems.Item("ctaing", fo).Value
                    FrmItemsCompras.gitems.Item("ctaiva", fd).Value = gitems.Item("ctaiva", fo).Value
                    FrmItemsCompras.gitems.Item("costo", fd).Value = Costos(gitems.Item("codigo", fo).Value)
                    FrmItemsCompras.gitems.Item("bodega", fd).Value = "1"
                    FrmItemsCompras.gitems.Item("descuento", fd).Value = "0,00"
                    Me.Close()
            End Select
        Else
            MsgBox("Solo se puede seleccionar articulos del inventario, verifique.  ", MsgBoxStyle.Information, "SAE")
        End If
    End Sub
    Function Costos(ByVal cod As String)
        Try
            Dim c As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT costprom FROM con_inv WHERE codart='" & cod & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                c = CDbl(tabla.Rows(0).Item(0))
            Catch ex As Exception
                c = 0
            End Try
            Return Moneda(c)
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function

    Private Sub FrmSelArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cerrar()
        Catch ex As Exception
        End Try
        MiConexion(bda)
        Cerrar()
        lbitems.Text = "BUSCAR ARTICULOS POR"
        cb_buscar.Text = "CODIGO"
        Try
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
            Dim items As Integer
            Dim control As Double
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM articulos WHERE estado='Activo' ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            control = tabla2.Rows(0).Item(0) / 100
            items = Val(tabla2.Rows(0).Item(0) / 100)
            If items < control Then
                items = items + 1
            ElseIf items = 0 Then
                items = 1
            End If
            cbpag.Items.Clear()
            For i = 1 To items
                cbpag.Items.Add(i)
            Next

            existe = ""
            Try
                Dim tb As New DataTable
                myCommand.CommandText = "SELECT lista_art FROM parafacgral ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                If tb.Rows.Count > 0 Then
                    existe = tb.Rows(0).Item(0)
                Else
                    existe = ""
                End If
            Catch ex As Exception
            End Try

            'cbpag.Text = 1
            Try
                llenarGrilla(0, 1000, "N")
            Catch ex As Exception
            End Try
            BuscarGrilla(txtcuenta.Text, "codigo")
            txtcuenta.Text = ""

            If (lbform.Text <> "itemsC") And FrmItems.lbform.Text <> "entradas" Then
                cmd_nv.Visible = False
            Else
                cmd_nv.Visible = True
            End If

           

            'If lbform.Text = "items" Then
            '    gitems.Columns("canbod").ReadOnly = False
            'Else
            '    gitems.Columns("canbod").ReadOnly = True
            'End If

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


        ' ''*****************  EDITAR PRECIOS  *****************
        'If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Then
        '    Try
        '        Dim tc As New DataTable
        '        myCommand.CommandText = "SELECT lista_pre FROM parafacgral ;"
        '        myAdapter.SelectCommand = myCommand
        '        myAdapter.Fill(tc)
        '        If tc.Rows(0).Item("lista_pre").ToString = "NO" Then
        '            gitems.Columns("precio").ReadOnly = True
        '        Else
        '            gitems.Columns("precio").ReadOnly = False
        '        End If
        '    Catch ex As Exception
        '        gitems.Columns("precio").ReadOnly = False
        '    End Try
        'End If
      
        ' ''******************************************************************
    End Sub

    Function lp(ByVal tipo As String)

        
        Try
            Dim t1, t2 As New DataTable
            If lbform.Text = "itemsEst" Then
                myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & FrmItemsEst.lbnit.Text & "';"
            Else
                myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & FrmItems.lbnit.Text & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t1)
            If t1.Rows.Count = 0 Then
                If tipo = "a" Then
                    Return "con_inv.precio1"
                Else
                    Return "pventa"
                End If
            Else
                If tipo = "a" Then
                    Return "con_inv.precio" & t1.Rows(0).Item(0)
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
                Return "con_inv.precio1"
            Else
                Return "pventa"
            End If
        End Try
    End Function
    Public Sub llenarGrilla(ByVal ini As Double, ByVal cant As Integer, ByVal act As String)
        ' Try
        '************ INICIO CONSULTA SQL ****************
        Dim nombre As String = ""
        Dim tmov As String = ""
        Dim campo As String = lp("a")
        Select Case lbform.Text
            Case "items"
                nombre = FrmItems.cbdesc.Text
                tmov = FrmItems.LbTipoMov.Text
            Case "itemsC"
                nombre = FrmItemsCompras.cbdesc.Text
                tmov = FrmItemsCompras.LbTipoMov.Text
            Case "itemsEst"
                nombre = FrmItemsEst.cbdesc.Text
                tmov = FrmItemsEst.LbTipoMov.Text
        End Select
        Dim sql As String = ""
        Dim pmin, marmin As String
        pmin = "0"
        marmin = " (SELECT IF(margmin='S',CAST(margen AS SIGNED),0) FROM parafacts WHERE factura='RAPIDA') "
        ' MsgBox(FrmItems.lbform.Text)
        If lbform.Text = "items" And (FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn") Then
            Select Case FrmItems.fr
                Case "1"
                    pmin = "0"
                Case "2"
                    pmin = " (cos_uni/(1-( " & marmin & "/100)))"
                Case "3"
                    pmin = " (cos_uni*(1+( " & marmin & "/100)))"
            End Select
        ElseIf lbform.Text = "itemsEst" And (FrmItemsEst.lbform.Text = "frs") Then
            Select Case FrmItems.fr
                Case "1"
                    pmin = "0"
                Case "2"
                    pmin = " (cos_uni/(1-( " & marmin & "/100)))"
                Case "3"
                    pmin = " (cos_uni*(1+( " & marmin & "/100)))"
            End Select
        End If

        'VERIFICAR SI EL TERCERO SE LE COBRA IVA O NO
        Dim civa As String = "iva"
        If lbform.Text = "itemsC" Then
            Try
                Dim tt As New DataTable
                tt.Clear()
                If FrmItemsCompras.lbform.Text = "fdp" Then
                    myCommand.CommandText = "SELECT iva from terceros where nit ='" & FrmDocProveedor.txtnitc.Text & "' ;"
                ElseIf FrmItemsCompras.lbform.Text = "oc" Then
                    myCommand.CommandText = "SELECT iva from terceros where nit ='" & FrmOrdenCompra.txtnitc.Text & "' ;"
                End If
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tt)
                Refresh()
                If tt.Rows(0).Item(0) = "SI" Then
                    civa = "iva"
                Else
                    civa = "0"
                End If
            Catch ex As Exception
                civa = "iva"
            End Try
        Else
            If lbform.Text = "items" And FrmItems.lbform.Text = "fr" Then
                Dim tt As New DataTable
                tt.Clear()
                myCommand.CommandText = "SELECT iva from terceros where nit ='" & Frmfacturarapida.txtnitc.Text & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tt)
                Refresh()
                If tt.Rows(0).Item(0) = "SI" Then
                    civa = "iva"
                Else
                    civa = "0"
                End If
            ElseIf lbform.Text = "items" And FrmItems.lbform.Text = "fn" Then
                Dim tt As New DataTable
                tt.Clear()
                myCommand.CommandText = "SELECT iva from terceros where nit ='" & FrmFacturasyAjustes.txtnitc.Text & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tt)
                Refresh()
                If tt.Rows(0).Item(0) = "SI" Then
                    civa = "iva"
                Else
                    civa = "0"
                End If
            End If
        End If

        'Dim tb As New DataTable
        'myCommand.CommandText = "SELECT lista_art FROM parafacgral ;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tb)


        'If FrmItems.lbExistencia.Text = "SI" Then
        '    If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Then
        '        sql = "SELECT codart,  referencia, desart AS nombre, nivel, NULL as cant,  NULL as iva,  NULL as p, cue_inv,cue_cos,cue_ing,cue_iva_v AS c_iva,cos_uni,  NULL as ct from articulos where nivel<> 'Articulo' UNION "
        '        sql = sql & "SELECT * FROM ( "
        '    End If
        'End If


        sql = sql & "SELECT codart,referencia"
        If nombre = "DETALLADA" Then
            sql = sql & ",desart AS nombre"
        Else
            sql = sql & ",nomart AS nombre"
        End If
        sql = sql & ",nivel,LEAST('1','1','1') as cant," & civa & " as iva"



        If lbform.Text = "itemsC" Then
            sql = sql & ",(cos_uni*(1+(" & civa & "/100))) as p"
        Else
            If tmov = "entradas" Or FrmItems.lbParSalida.Text = "CS" Then
                sql = sql & ",cos_uni as p"
            Else
                Dim cad As String = "precio"
                If lbiva.Text = "SI" Then
                    sql = sql & ",ROUND((" & cad & " * (1 + ( " & civa & " / 100) )) + 49,-2) as p"
                    sql = sql & ",ROUND((" & pmin & " * (1 + ( " & civa & " / 100) )),0) as pmin"
                Else
                    sql = sql & ",ROUND(" & cad & "+49,-2) as p"
                    sql = sql & ",ROUND(" & pmin & ",0) as pmin"
                End If
            End If
        End If


        sql = sql & ",cue_inv,cue_cos,cue_ing"
        If tmov = "salidas" Or FrmItems.lbform.Text = "fn" Then
            sql = sql & ",cue_iva_v AS c_iva"
        Else
            sql = sql & ",cue_iva_c AS c_iva"
        End If
        sql = sql & ",cos_uni, SUM(ctotal) AS ct FROM vista_canti WHERE estado='Activo' GROUP BY codart ORDER BY codart"


        'If FrmItems.lbExistencia.Text = "SI" Then
        '    If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Then
        '        sql = sql & " ) AS c WHERE c.ct >0 ORDER by codart"
        '    End If
        'End If


        'gitems.Rows.Clear()
        gitems.RowCount = 1

        '**************** FIN CONSULTA SQL **********************
        Dim items As Integer
        Dim tabla2 As New DataTable
        'myCommand.CommandText = "SELECT articulos WHERE estado='Activo' ORDER BY codart LIMIT " & ini & "," & cant & ";"
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        lbitems.Text = "hay " & items & " Items."
        'gitems.RowCount = items + 1
        gitems.RowCount = 2
        'gitems.DataSource = myAdapter.Fill(tabla2)

        ':::::::::::::::::: ACTUALIZAR LISTA
        Dim it As Integer = 0
        If act = "S" Then
            mibarra.Value = 0
            mibarra.Visible = True
            mibarra.Maximum = items
            it = 1
        End If

        Dim k As Integer = 0
        If lbform.Text <> "itemsC" Then
            If existe = "SI" Then
                If FrmItems.lbform.Text = "fr" Or FrmItems.lbform.Text = "fn" Or FrmItemsEst.lbform.Text = "frs" Then
                    For i = 0 To items - 1
                        If tabla2.Rows(i).Item("nivel") = "Articulo" Then
                            If Moneda(tabla2.Rows(i).Item("ct")) > Moneda(0) Then
                                gitems.Item("codigo", k).Value = tabla2.Rows(i).Item("codart")
                                gitems.Item("ref", k).Value = tabla2.Rows(i).Item("referencia")
                                gitems.Item("desc", k).Value = tabla2.Rows(i).Item("nombre")
                                gitems.Item("nivel", k).Value = tabla2.Rows(i).Item("nivel")
                                gitems.Item("cant", k).Value = tabla2.Rows(i).Item("cant")
                                gitems.Item("iva", k).Value = tabla2.Rows(i).Item("iva")
                                gitems.Item("precio", k).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                                gitems.Item("ctainv", k).Value = tabla2.Rows(i).Item("cue_inv")
                                gitems.Item("ctacven", k).Value = tabla2.Rows(i).Item("cue_cos")
                                gitems.Item("ctaing", k).Value = tabla2.Rows(i).Item("cue_ing")
                                gitems.Item("ctaiva", k).Value = tabla2.Rows(i).Item("c_iva")
                                gitems.Item("costo", k).Value = tabla2.Rows(i).Item("cos_uni")
                                gitems.Item("cant2", k).Value = Moneda(tabla2.Rows(i).Item("ct"))
                                If pmin = "0" Then
                                    gitems.Item("precio2", k).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                                Else
                                    gitems.Item("precio2", k).Value = Moneda(tabla2.Rows(i).Item("pmin").ToString)
                                End If

                                k = k + 1
                                gitems.RowCount = gitems.RowCount + 1
                            End If
                        Else
                            gitems.Item("codigo", k).Value = tabla2.Rows(i).Item("codart")
                            gitems.Item("ref", k).Value = tabla2.Rows(i).Item("referencia")
                            gitems.Item("desc", k).Value = tabla2.Rows(i).Item("nombre")
                            gitems.Item("nivel", k).Value = tabla2.Rows(i).Item("nivel")
                            gitems.Item("cant", k).Value = tabla2.Rows(i).Item("cant")
                            gitems.Item("iva", k).Value = tabla2.Rows(i).Item("iva")
                            gitems.Item("precio", k).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                            gitems.Item("ctainv", k).Value = tabla2.Rows(i).Item("cue_inv")
                            gitems.Item("ctacven", k).Value = tabla2.Rows(i).Item("cue_cos")
                            gitems.Item("ctaing", k).Value = tabla2.Rows(i).Item("cue_ing")
                            gitems.Item("ctaiva", k).Value = tabla2.Rows(i).Item("c_iva")
                            gitems.Item("costo", k).Value = tabla2.Rows(i).Item("cos_uni")
                            gitems.Item("cant2", k).Value = Moneda(tabla2.Rows(i).Item("ct"))
                            gitems.Item("precio2", k).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                            If pmin = "0" Then
                                gitems.Item("precio2", k).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                            Else
                                gitems.Item("precio2", k).Value = Moneda(tabla2.Rows(i).Item("pmin").ToString)
                            End If
                            k = k + 1
                            gitems.RowCount = gitems.RowCount + 1
                        End If
                        If act = "S" Then
                            mibarra.Value = mibarra.Value + it
                        End If
                    Next
                Else
                    For i = 0 To items - 1
                        gitems.Item("codigo", i).Value = tabla2.Rows(i).Item("codart")
                        gitems.Item("ref", i).Value = tabla2.Rows(i).Item("referencia")
                        gitems.Item("desc", i).Value = tabla2.Rows(i).Item("nombre")
                        gitems.Item("nivel", i).Value = tabla2.Rows(i).Item("nivel")
                        gitems.Item("cant", i).Value = tabla2.Rows(i).Item("cant")
                        gitems.Item("iva", i).Value = tabla2.Rows(i).Item("iva")
                        gitems.Item("precio", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                        gitems.Item("ctainv", i).Value = tabla2.Rows(i).Item("cue_inv")
                        gitems.Item("ctacven", i).Value = tabla2.Rows(i).Item("cue_cos")
                        gitems.Item("ctaing", i).Value = tabla2.Rows(i).Item("cue_ing")
                        gitems.Item("ctaiva", i).Value = tabla2.Rows(i).Item("c_iva")
                        gitems.Item("costo", i).Value = tabla2.Rows(i).Item("cos_uni")
                        gitems.Item("cant2", i).Value = Moneda(tabla2.Rows(i).Item("ct"))
                        gitems.Item("precio2", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                        If act = "S" Then
                            mibarra.Value = mibarra.Value + it
                        End If
                        gitems.RowCount = gitems.RowCount + 1
                    Next
                End If
            Else
                For i = 0 To items - 1
                    gitems.Item("codigo", i).Value = tabla2.Rows(i).Item("codart")
                    gitems.Item("ref", i).Value = tabla2.Rows(i).Item("referencia")
                    gitems.Item("desc", i).Value = tabla2.Rows(i).Item("nombre")
                    gitems.Item("nivel", i).Value = tabla2.Rows(i).Item("nivel")
                    gitems.Item("cant", i).Value = tabla2.Rows(i).Item("cant")
                    gitems.Item("iva", i).Value = tabla2.Rows(i).Item("iva")
                    gitems.Item("precio", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                    gitems.Item("ctainv", i).Value = tabla2.Rows(i).Item("cue_inv")
                    gitems.Item("ctacven", i).Value = tabla2.Rows(i).Item("cue_cos")
                    gitems.Item("ctaing", i).Value = tabla2.Rows(i).Item("cue_ing")
                    gitems.Item("ctaiva", i).Value = tabla2.Rows(i).Item("c_iva")
                    gitems.Item("costo", i).Value = tabla2.Rows(i).Item("cos_uni")
                    gitems.Item("cant2", i).Value = Moneda(tabla2.Rows(i).Item("ct"))
                    gitems.Item("precio2", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                    If act = "S" Then
                        mibarra.Value = mibarra.Value + it
                    End If
                    gitems.RowCount = gitems.RowCount + 1
                Next
            End If
        Else
            'PARA ITEMS COMPRA
            For i = 0 To items - 1
                gitems.Item("codigo", i).Value = tabla2.Rows(i).Item("codart")
                gitems.Item("ref", i).Value = tabla2.Rows(i).Item("referencia")
                gitems.Item("desc", i).Value = tabla2.Rows(i).Item("nombre")
                gitems.Item("nivel", i).Value = tabla2.Rows(i).Item("nivel")
                gitems.Item("cant", i).Value = tabla2.Rows(i).Item("cant")
                gitems.Item("iva", i).Value = tabla2.Rows(i).Item("iva")
                gitems.Item("precio", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                gitems.Item("ctainv", i).Value = tabla2.Rows(i).Item("cue_inv")
                gitems.Item("ctacven", i).Value = tabla2.Rows(i).Item("cue_cos")
                gitems.Item("ctaing", i).Value = tabla2.Rows(i).Item("cue_ing")
                gitems.Item("ctaiva", i).Value = tabla2.Rows(i).Item("c_iva")
                gitems.Item("costo", i).Value = tabla2.Rows(i).Item("cos_uni")
                gitems.Item("cant2", i).Value = Moneda(tabla2.Rows(i).Item("ct"))
                gitems.Item("precio2", i).Value = Moneda(tabla2.Rows(i).Item("p").ToString)
                If act = "S" Then
                    mibarra.Value = mibarra.Value + it
                End If
                gitems.RowCount = gitems.RowCount + 1
            Next
        End If


        txtcuenta.Focus()
        lbitems.Text = "hay " & gitems.Rows.Count - 1 & " Items."
        If Trim(txtcuenta.Text) = "" Then
            gitems.CurrentCell() = gitems.Item("codigo", 1)
        Else
            ok_Click(AcceptButton, AcceptButton)
        End If


        For o = 0 To gitems.Rows.Count - 1
            If (IsDBNull(gitems.Item("codigo", o).Value) = True) Or gitems.Item("codigo", o).Value = "" Then
                gitems.Rows.RemoveAt(o)
            End If
        Next

        mibarra.Visible = False
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        TextBox1.Text = sql
        FrmItems.lbExistencia.Text = ""
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
        gitems.Item("precio2", fila).Value = total
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text, "desc")
        End If
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text, "codigo")
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String, ByVal col As String)
        Dim C As Integer
        If cb_buscar.Text = "CODIGO" Then
            gitems.Sort(gitems.Columns("codigo"), System.ComponentModel.ListSortDirection.Ascending)
            col = "codigo"
            C = 1
        ElseIf cb_buscar.Text = "REFERENCIA" Then
            gitems.Sort(gitems.Columns("ref"), System.ComponentModel.ListSortDirection.Ascending)
            col = "ref"
            C = 2
        Else
            gitems.Sort(gitems.Columns("desc"), System.ComponentModel.ListSortDirection.Ascending)
            col = "desc"
            C = 3
        End If
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            Dim cad2, aux As String
            For i = 0 To gitems.RowCount - 1
                aux = gitems.Item(col, i).Value.ToString
                If Val(aux.Length) >= Val(cad.Length) Then
                    cad2 = ""
                    For j = 0 To cad.Length - 1
                        cad2 = cad2 & aux(j)
                    Next
                    If cad = cad2 Then
                        Dim F As Integer = i
                        gitems.CurrentCell = gitems.Rows(F).Cells(C)  'gitems(C, F)
                        gitems.Item(C, F).Selected = True
                        gitems.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbpag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbpag.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbpag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpag.SelectedIndexChanged
        Dim ini As Double
        Try
            ini = (Val(cbpag.Text) - 1) * 100
        Catch ex As Exception
            ini = 0
        End Try
        Me.Cursor = Cursors.WaitCursor
        llenarGrilla(ini, 100, "N")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            If Val(cbpag.Text) <> 1 Then
                cbpag.Text = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            If Val(cbpag.Text) - 1 > 1 Then
                cbpag.Text = Val(cbpag.Text) - 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim items As Integer
            Dim control As Double
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM articulos WHERE estado='Activo' ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            control = tabla2.Rows(0).Item(0) / 100
            items = Val(tabla2.Rows(0).Item(0) / 100)
            If items < control Then
                items = items + 1
            ElseIf items = 0 Then
                items = 1
            End If
            If Val(cbpag.Text) + 1 < items Then
                cbpag.Text = Val(cbpag.Text) + 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim items As Integer
            Dim control As Double
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM articulos WHERE estado='Activo' ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            control = tabla2.Rows(0).Item(0) / 100
            items = Val(tabla2.Rows(0).Item(0) / 100)
            If items < control Then
                items = items + 1
            ElseIf items = 0 Then
                items = 1
            End If
            If Val(cbpag.Text) <> items Then
                cbpag.Text = items
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub

    Private Sub cmd_nv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_nv.Click

        Try
            '  FrmProductos.cmdNuevo_Click(AcceptButton, AcceptButton)
            FrmProductos.lbitem.Text = "item"
            FrmProductos.ShowDialog()
            llenarGrilla(0, 1000, "N")

        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAct.Click
        gitems.Rows.Clear()
        llenarGrilla(0, 1000, "S")
    End Sub

    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
        Try
            Select Case e.ColumnIndex
                Case 15 'CASO PRECIO   
                    If lbform.Text = "items" Or lbform.Text = "itemsEst" Then
                        detalleCantidad(e.RowIndex, e.ColumnIndex)
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub detalleCantidad(ByVal fl As Integer, ByVal cl As Integer)

        FrmArtBodPre.CmdRegistrarCambios.Enabled = False
        FrmArtBodPre.lbcodigo.Text = gitems.Item("codigo", fl).Value
        FrmArtBodPre.lbdescricion.Text = gitems.Item("desc", fl).Value
        FrmArtBodPre.lbform.Text = "ARTICULO EN BODEGAS"
        FrmArtBodPre.gitems.Columns(2).HeaderText = "CANTIDAD"
        FrmArtBodPre.gitems.Columns(2).ReadOnly = True
        FrmArtBodPre.ShowDialog()
    End Sub
End Class