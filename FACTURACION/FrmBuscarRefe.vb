Public Class FrmBuscarRefe

    Private Sub txtcod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod.LostFocus
        BuscarRef()
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        BuscarRef()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Public Sub BuscarRef()
        If lbsalir.Text = "SI" Then
            'NO HACER NADA PARA SALIR
        ElseIf Trim(txtcod.Text) = "" Then
            MsgBox("Digete la Referencia del Articulo.  ", MsgBoxStyle.Information, "SAE Control")
            txtcod.Focus()
        ElseIf Trim(txtcod.Text) = "00" Then
            Me.Close()
            txtcod.Focus()
        Else
            Try
                Dim items As Integer
                Dim tabla As New DataTable
                Dim fila As Integer = 0
                Select Case lbform.Text
                    Case "items"
                        For i = 0 To FrmItems.gitems.RowCount - 1
                            If Trim(FrmItems.gitems.Item("codigo", i).Value = "") Then
                                fila = i
                                Exit For
                            End If
                        Next
                        If fila = FrmItems.gitems.RowCount - 1 Then FrmItems.gitems.RowCount = FrmItems.gitems.RowCount + 1
                    Case "itemsC"
                        For i = 0 To FrmItemsCompras.gitems.RowCount - 1
                            If Trim(FrmItemsCompras.gitems.Item("codigo", i).Value = "") Then
                                fila = i
                                Exit For
                            End If
                        Next
                        If fila = FrmItemsCompras.gitems.RowCount - 1 Then FrmItemsCompras.gitems.RowCount = FrmItemsCompras.gitems.RowCount + 1
                    Case "itemsEst"
                        For i = 0 To FrmItemsEst.gitems.RowCount - 1
                            If Trim(FrmItemsEst.gitems.Item("codigo", i).Value = "") Then
                                fila = i
                                Exit For
                            End If
                        Next
                        If fila = FrmItemsEst.gitems.RowCount - 1 Then FrmItemsEst.gitems.RowCount = FrmItemsEst.gitems.RowCount + 1
                End Select
                myCommand.CommandText = "SELECT a.*, (SELECT IF(margmin='S',CAST(margen AS SIGNED),0) FROM parafacts WHERE factura='RAPIDA') AS margin FROM articulos a WHERE 	a.referencia='" & Trim(txtcod.Text) & "' AND a.nivel='Articulo' And a.estado='Activo' ORDER BY codart;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items < 1 Then
                    MsgBox("La Referencia(" & Trim(txtcod.Text) & ") no se encuentra en los registros, verifique.  ", MsgBoxStyle.Information, "SAE")
                    txtcod.Focus()
                Else
                    Select Case lbform.Text
                        Case "itemEst"

                            Dim ccm As String = ""
                            Try
                                '..................
                                Dim tab As New DataTable
                                myCommand.CommandText = "select p.concomipre ,c.codcon from  concomi c, parafacts p where p.factura = 'RAPIDA' and p.concomi = c.codcon;"
                                myAdapter.SelectCommand = myCommand
                                myAdapter.Fill(tabla)

                                If tabla.Rows.Count <> 0 Then
                                    If tabla.Rows(0).Item(0) = "S" Then
                                        ccm = tab.Rows(0).Item(1)
                                    Else
                                        ccm = ""
                                    End If
                                End If
                            Catch ex As Exception
                                ' MsgBox(ex.ToString)
                            End Try

                            FrmItemsEst.gitems.Item("num", fila).Value = fila + 1
                            FrmItemsEst.gitems.Item("tipo", fila).Value = "I"
                            FrmItemsEst.gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codart")
                            If FrmItemsEst.cbdesc.Text = "DETALLADA" Then
                                FrmItemsEst.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("desart")
                            Else
                                FrmItemsEst.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("nomart")
                            End If
                            FrmItemsEst.gitems.Item("codcom", fila).Value = ccm
                            FrmItemsEst.gitems.Item("cant", fila).Value = "1"
                            If LbTipoMov.Text = "entradas" Then
                                FrmItemsEst.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                                FrmItemsEst.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            Else
                                FrmItemsEst.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("precio"))
                                FrmItemsEst.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"), "precio")
                                If FrmItemsEst.bajPrec = "SI" Then
                                    FrmItemsEst.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"), "precio2")
                                Else
                                    FrmItemsEst.PrecMargenMin(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margin"), "precio2")
                                End If
                                'FrmItemsEst.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"))
                                FrmItemsEst.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            End If
                            FrmItemsEst.gitems.Item(6, fila).Value = ""
                            FrmItemsEst.gitems.Item("ctainv", fila).Value = tabla.Rows(0).Item("cue_inv").ToString
                            FrmItemsEst.gitems.Item("ctacven", fila).Value = tabla.Rows(0).Item("cue_cos").ToString
                            FrmItemsEst.gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cue_ing").ToString
                            If LbTipoMov.Text = "salidas" Then
                                FrmItemsEst.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_v").ToString
                            Else
                                FrmItemsEst.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_c").ToString
                            End If
                            FrmItemsEst.gitems.Item("costo", fila).Value = Costos(tabla.Rows(0).Item("codart"))
                            FrmItemsEst.gitems.Item("descuento", fila).Value = Moneda(0)
                            FrmItemsEst.gitems.Item("bodega", fila).Value = "1"
                            FrmItemsEst.gitems.Item("nit", fila).Value = ""
                            FrmItemsEst.gitems.Item("descuento", fila).Value = 0
                            FrmItemsEst.gitems.Item("precio2", fila).Value = 0
                            FrmItemsEst.gitems.Item("disponible", fila).Value = Disponible(tabla.Rows(0).Item("codart"))
                            txtcod.Text = ""
                            Me.Close()

                        Case "items"
                            FrmItems.gitems.Item("num", fila).Value = fila + 1
                            FrmItems.gitems.Item("tipo", fila).Value = "I"
                            FrmItems.gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codart")
                            If FrmItems.cbdesc.Text = "DETALLADA" Then
                                FrmItems.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("desart")
                            Else
                                FrmItems.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("nomart")
                            End If
                            FrmItems.gitems.Item("cc", fila).Value = ""
                            FrmItems.gitems.Item("cant", fila).Value = "1"
                            If LbTipoMov.Text = "entradas" Then
                                FrmItems.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                                FrmItems.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            Else
                                FrmItems.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("precio"))
                                FrmItems.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"), "precio")
                                If FrmItems.bajPrec = "SI" Then
                                    FrmItems.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"), "precio2")
                                Else
                                    FrmItems.PrecMargenMin(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margin"), "precio2")
                                End If
                                'FrmItems.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"))
                                FrmItems.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            End If
                            FrmItems.gitems.Item(6, fila).Value = ""
                            FrmItems.gitems.Item("ctainv", fila).Value = tabla.Rows(0).Item("cue_inv").ToString
                            FrmItems.gitems.Item("ctacven", fila).Value = tabla.Rows(0).Item("cue_cos").ToString
                            FrmItems.gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cue_ing").ToString
                            If LbTipoMov.Text = "salidas" Then
                                FrmItems.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_v").ToString
                            Else
                                FrmItems.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_c").ToString
                            End If
                            FrmItems.gitems.Item("costo", fila).Value = Costos(tabla.Rows(0).Item("codart"))
                            FrmItems.gitems.Item("descuento", fila).Value = Moneda(0)
                            FrmItems.gitems.Item("bodega", fila).Value = "1"
                            FrmItems.gitems.Item("nit", fila).Value = ""
                            FrmItems.gitems.Item("descuento", fila).Value = 0
                            FrmItems.gitems.Item("precio2", fila).Value = 0
                            FrmItems.gitems.Item("disponible", fila).Value = Disponible(tabla.Rows(0).Item("codart"))
                            txtcod.Text = ""
                            Me.Close()
                        Case "itemsC"
                            FrmItemsCompras.gitems.Item("num", fila).Value = fila + 1
                            FrmItemsCompras.gitems.Item("tipo", fila).Value = "I"
                            FrmItemsCompras.gitems.Item("codigo", fila).Value = tabla.Rows(0).Item("codart")
                            If FrmItemsCompras.cbdesc.Text = "DETALLADA" Then
                                FrmItemsCompras.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("desart")
                            Else
                                FrmItemsCompras.gitems.Item("descrip", fila).Value = tabla.Rows(0).Item("nomart")
                            End If
                            FrmItemsCompras.gitems.Item("cant", fila).Value = "1"
                            If LbTipoMov.Text = "entradas" Then
                                FrmItemsCompras.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("cos_uni"))
                                FrmItemsCompras.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            Else
                                FrmItemsCompras.gitems.Item(5, fila).Value = Moneda(tabla.Rows(0).Item("precio"))
                                FrmItemsCompras.Precios(fila, Moneda(tabla.Rows(0).Item("cos_uni")), Moneda(tabla.Rows(0).Item("precio")), tabla.Rows(0).Item("iva"), tabla.Rows(0).Item("margen"))
                                FrmItemsCompras.gitems.Item("iva", fila).Value = tabla.Rows(0).Item("iva")
                            End If
                            FrmItemsCompras.gitems.Item(6, fila).Value = ""
                            FrmItemsCompras.gitems.Item("ctainv", fila).Value = tabla.Rows(0).Item("cue_inv").ToString
                            FrmItemsCompras.gitems.Item("ctacven", fila).Value = tabla.Rows(0).Item("cue_cos").ToString
                            FrmItemsCompras.gitems.Item("ctaing", fila).Value = tabla.Rows(0).Item("cue_ing").ToString
                            If LbTipoMov.Text = "salidas" Then
                                FrmItemsCompras.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_v").ToString
                            Else
                                FrmItemsCompras.gitems.Item("ctaiva", fila).Value = tabla.Rows(0).Item("cue_iva_c").ToString
                            End If
                            FrmItemsCompras.gitems.Item("costo", fila).Value = Costos(tabla.Rows(0).Item("codart"))

                            txtcod.Text = ""
                            Me.Close()
                    End Select
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Function Disponible(ByVal cod As String)
        Try
            Dim c As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cant1 FROM con_inv WHERE codart='" & cod & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                c = CDbl(tabla.Rows(0).Item(0))
            Catch ex As Exception
                c = 0
            End Try
            Return c
        Catch ex As Exception
            Return "0"
        End Try
    End Function
    Function Costos(ByVal cod As String)
        Try
            Dim c As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT costuni FROM con_inv WHERE codart='" & cod & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
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
    Function Precios(ByVal fila As Integer, ByVal costo As Double, ByVal precio As Double, ByVal iva As Decimal, ByVal margen As Decimal)
        Try
            'Dim total As Double
            'Dim tabla As New DataTable
            ''Dim campo As String = lp("a")
            'myCommand.CommandText = "SELECT " & campo & " FROM con_inv WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(tabla)
            'Try
            '    total = CDbl(tabla.Rows(0).Item(0))
            'Catch ex As Exception
            '    total = 0
            'End Try
            'If lbiva.Text = "SI" And iva <> 0 Then
            '    total = total + (total * iva / 100)
            'End If
            'Return Moneda(total)
            Return "0,00"
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function
    Private Sub FrmBuscarRefe_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        lbsalir.Text = "SI"
        txtcod.Text = ""
        txtcod.Focus()
    End Sub
    Private Sub FrmBuscarRefe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbsalir.Text = "NO"
            txtcod.Text = ""
            txtcod.Focus()
        Catch ex As Exception
        End Try
    End Sub
End Class