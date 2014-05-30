Public Class FrmSelServicio

    Public fila, sw As Integer

    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        Select Case e.ColumnIndex
            'Case 3 'precio
            '    Try
            '        If gitems.Item("nombre", e.RowIndex).Value = "" Then Exit Sub
            '        FrmPrecioItems.lbform.Text = "selS"
            '        FrmPrecioItems.lbfila.Text = e.RowIndex
            '        FrmPrecioItems.Ch1.Checked = True
            '        FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
            '        FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
            '        FrmPrecioItems.ShowDialog()
            '    Catch ex As Exception
            '    End Try
        End Select
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        sw = 0
        Select Case e.ColumnIndex
            Case 3 'precio
                'Try
                '    If gitems.Item("nombre", e.RowIndex).Value = "" Then Exit Sub
                '    FrmPrecioItems.lbform.Text = "selS"
                '    FrmPrecioItems.lbfila.Text = e.RowIndex
                '    FrmPrecioItems.Ch1.Checked = True
                '    FrmPrecioItems.lbiva.Text = Moneda(gitems.Item("iva", e.RowIndex).Value)
                '    FrmPrecioItems.txt1.Text = Moneda(gitems.Item("precio", e.RowIndex).Value)
                '    FrmPrecioItems.ShowDialog()
                'Catch ex As Exception
                'End Try
        End Select
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    
    Public Sub seleccionar(ByVal mifila As Integer)

        ''..................
        'Dim cc As String = ""
        'Dim tabla As New DataTable
        'myCommand.CommandText = "select p.concomipre ,c.porcomi from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)

        'If tabla.Rows(0).Item(0) = "S" Then
        '    cc = tabla.Rows(0).Item(1)
        'End If

        ''................
        '................
        Select Case lbform.Text
            Case "items"

                Dim fd As Integer
                fd = Val(lbfila.Text)

                Dim ccm As String = ""

                Try
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

                Catch ex As Exception
                End Try

                FrmItems.gitems.Item("tipo", fd).Value = "S"
                FrmItems.gitems.Item("codigo", fd).Value = gitems.Item(1, mifila).Value
                FrmItems.gitems.Item("descrip", fd).Value = gitems.Item(2, mifila).Value
                FrmItems.gitems.Item("cant", fd).Value = "1"
                FrmItems.gitems.Item("precio", fd).Value = gitems.Item(3, mifila).Value
                FrmItems.gitems.Item("bodega", fd).Value = ""
                FrmItems.gitems.Item("iva", fd).Value = gitems.Item("iva", mifila).Value
                '''''''''''''''''''''''''''''''''''''''
                FrmItems.gitems.Item("cc", fd).Value = ccm
                FrmItems.gitems.Item("ctainv", fd).Value = ""
                FrmItems.gitems.Item("ctacven", fd).Value = ""
                FrmItems.gitems.Item("ctaing", fd).Value = gitems.Item("CTAING", mifila).Value
                FrmItems.gitems.Item("ctaiva", fd).Value = gitems.Item("CTAIVA", mifila).Value
                FrmItems.gitems.Item("descuento", fd).Value = "0.00"
                FrmItems.gitems.Item("precio2", fd).Value = gitems.Item(3, mifila).Value
                Me.Close()
                gitems.Focus()
                sw = 1
                Me.Close()
            Case "itemsEst"

                Dim fd As Integer
                fd = Val(lbfila.Text)

                Dim ccm As String = ""

                Try
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

                Catch ex As Exception
                End Try

                FrmItemsEst.gitems.Item("tipo", fd).Value = "S"
                FrmItemsEst.gitems.Item("codigo", fd).Value = gitems.Item(1, mifila).Value
                FrmItemsEst.gitems.Item("descrip", fd).Value = gitems.Item(2, mifila).Value
                FrmItemsEst.gitems.Item("cant", fd).Value = "1"
                FrmItemsEst.gitems.Item("precio", fd).Value = gitems.Item(3, mifila).Value
                FrmItemsEst.gitems.Item("bodega", fd).Value = ""
                FrmItemsEst.gitems.Item("iva", fd).Value = gitems.Item("iva", mifila).Value
                '''''''''''''''''''''''''''''''''''''''
                FrmItemsEst.gitems.Item("cc", fd).Value = ccm
                FrmItemsEst.gitems.Item("ctainv", fd).Value = ""
                FrmItemsEst.gitems.Item("ctacven", fd).Value = ""
                FrmItemsEst.gitems.Item("ctaing", fd).Value = gitems.Item("CTAING", mifila).Value
                FrmItemsEst.gitems.Item("ctaiva", fd).Value = gitems.Item("CTAIVA", mifila).Value
                FrmItemsEst.gitems.Item("descuento", fd).Value = "0.00"
                FrmItemsEst.gitems.Item("precio2", fd).Value = gitems.Item(3, mifila).Value
                Me.Close()
                gitems.Focus()
                sw = 1
                Me.Close()
            Case "servicios"
                FrmServicios.txtser.Text = gitems.Item(1, mifila).Value
                FrmServicios.txtservicio.Text = gitems.Item(2, mifila).Value
                FrmServicios.txtdescrip.Text = gitems.Item("nombre2", mifila).Value
                FrmServicios.txtprecio.Text = gitems.Item(3, mifila).Value
                FrmServicios.txtiva.Text = gitems.Item("iva", mifila).Value
                ''''''''''''''''''''''''''''''''''''''''
                FrmServicios.txtctaing.Text = gitems.Item("CTAING", mifila).Value
                FrmServicios.txtctaiva.Text = gitems.Item("CTAIVA", mifila).Value
                Me.Close()
                gitems.Focus()
                sw = 1
                Me.Close()
            Case "inf_servicios"
                FrmInfoServicios.txttip.Text = gitems.Item(1, mifila).Value
                FrmInfoServicios.txtnom.Text = gitems.Item(2, mifila).Value
                Me.Close()
                gitems.Focus()
                sw = 1
                Me.Close()
            Case "cita_a"
                FrmGestionCitas.txtserv.Text = gitems.Item(2, mifila).Value
                Me.Close()
                gitems.Focus()
                sw = 1
                Me.Close()
        End Select
        '   lbform.Text = ""
       
    End Sub
    Private Sub FrmSelVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sw <> 1 Then
            seleccionar(0)
            Exit Sub
        End If
        sw = 0
    End Sub
    Function lp(ByVal tipo As String)

        Select Case lbform.Text
            Case "itemsEst"
                Try
                    Dim t1, t2 As New DataTable
                    myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & FrmItemsEst.lbnit.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(t1)
                    If t1.Rows.Count = 0 Then
                        If tipo = "a" Then
                            Return "c.precio1"
                        Else
                            Return "pventa"
                        End If
                    Else
                        If tipo = "a" Then
                            Return "c.precio" & t1.Rows(0).Item(0)
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
                        Return "c.precio1"
                    Else
                        Return "pventa"
                    End If
                End Try

            Case Else
                Try
                    Dim t1, t2 As New DataTable
                    myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & FrmItems.lbnit.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(t1)
                    If t1.Rows.Count = 0 Then
                        If tipo = "a" Then
                            Return "c.precio1"
                        Else
                            Return "pventa"
                        End If
                    Else
                        If tipo = "a" Then
                            Return "c.precio" & t1.Rows(0).Item(0)
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
                        Return "c.precio1"
                    Else
                        Return "pventa"
                    End If
                End Try
        End Select
    End Function
    Private Sub FrmSelVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'CONSULTAR SI EL CLIENTE AFECTA IVA
        Dim civa As String = "iva"
        If lbform.Text = "items" Then
            Try
                Dim tt As New DataTable
                tt.Clear()
                If FrmItems.lbform.Text = "fr" Then
                    myCommand.CommandText = "SELECT iva from terceros where nit ='" & Frmfacturarapida.txtnitc.Text & "' ;"
                ElseIf FrmItems.lbform.Text = "fn" Then
                    myCommand.CommandText = "SELECT iva from terceros where nit ='" & FrmFacturasyAjustes.txtnitc.Text & "' ;"
                End If
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tt)
                Refresh()
                If tt.Rows(0).Item(0) = "SI" Then
                    civa = "iva"
                Else
                    civa = "0 as iva"
                End If
            Catch ex As Exception
                civa = "iva"
            End Try
        End If

        Dim items As Integer
        Dim tabla2 As New DataTable
        Dim campo As String = lp("s")
        Select Case lbform.Text
            Case "itemsEst"
                If FrmItemsEst.cbdesc.Text = "DETALLADA" Then
                    myCommand.CommandText = "SELECT codser,descrip as n," & campo & ",iva,cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
                Else
                    myCommand.CommandText = "SELECT codser,nombre as n," & campo & ",iva,cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
                End If
            Case Else
                If FrmItems.cbdesc.Text = "DETALLADA" Then
                    myCommand.CommandText = "SELECT codser,descrip as n," & campo & "," & civa & ",cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
                Else
                    myCommand.CommandText = "SELECT codser,nombre as n," & campo & "," & civa & ",cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
                End If
        End Select
        'If FrmItems.cbdesc.Text = "DETALLADA" Then
        '    myCommand.CommandText = "SELECT codser,descrip as n," & campo & ",iva,cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
        'Else
        '    myCommand.CommandText = "SELECT codser,nombre as n," & campo & ",iva,cta_iva,cta_ing,descrip as d FROM servicios ORDER BY codser;"
        'End If

        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(1, i).Value = tabla2.Rows(i).Item("codser")
            gitems.Item(2, i).Value = Trim(tabla2.Rows(i).Item("n"))
            gitems.Item(3, i).Value = tabla2.Rows(i).Item(campo)
            gitems.Item("iva", i).Value = tabla2.Rows(i).Item("iva")
            gitems.Item(4, i).Value = tabla2.Rows(i).Item("cta_iva")
            gitems.Item(5, i).Value = tabla2.Rows(i).Item("cta_ing")
            gitems.Item(7, i).Value = tabla2.Rows(i).Item("d")

        Next
        BuscarGrilla(txtcuenta.Text)
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            Dim cad2, aux As String
            For i = 0 To gitems.RowCount - 1
                aux = gitems.Item(1, i).Value.ToString
                If Val(aux.Length) >= Val(cad.Length) Then
                    cad2 = ""
                    For j = 0 To cad.Length - 1
                        cad2 = cad2 & aux(j)
                    Next
                    If cad = cad2 Then
                        Dim C As Integer = 1, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class