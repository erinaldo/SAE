Imports System.IO
Public Class FrmSelMovInventario
    Public fila As Integer
    Private Sub FrmSelMovInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtmes.Text = Strings.Left(PerActual, 2)
        txtcli.Text = "TODOS"
        txtcuenta.Text = ""
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        '   Try
        Dim tabla As New DataTable
        Dim items As Integer
        If lbform.Text = "ajus_val" Then
            txtcli.Visible = False
            lbper.Visible = False
            txtmes.Visible = False
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & PerActual(0) & PerActual(1) & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE m.tipodoc='" & lbtipo.Text & "' AND m.tipo_mov='V' ORDER BY num;"
        ElseIf lbform.Text = "ajustes" Then
            txtcli.Visible = False
            lbper.Visible = False
            txtmes.Visible = False
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*,concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & PerActual(0) & PerActual(1) & " m  LEFT JOIN terceros t ON t.nit=m.nitc WHERE m.tipodoc='" & lbtipo.Text & "' AND m.tipo_mov='A' ORDER BY num;"
        ElseIf lbform.Text = "Factura" Or lbform.Text = "FacturaEst" Then
            txtcli.Visible = True
            lbper.Visible = True
            txtmes.Visible = True
            lbtitulo.Text = "BUSCAR SALIDAS"
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*,concat(t.nombre,' ',t.apellidos) as nom  FROM movimientos" & txtmes.Text & " m ,terceros t WHERE t.nit=m.nitc and t.nit=m.nitc AND m.tipodoc ='SA' AND m.o_compra='' " _
                                    & " ORDER BY tipodoc, num;"
        ElseIf lbform.Text = "SaldosIniInv" Then
            txtcli.Visible = False
            lbper.Visible = False
            txtmes.Visible = False
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*,concat(t.nombre,' ',t.apellidos) as nom FROM movimientos00 m, terceros t where t.nit=m.nitc and m.tipodoc='" & lbtipo.Text & "' ORDER BY num;"
        ElseIf lbform.Text = "FacturaC" Then
            txtcli.Visible = True
            lbper.Visible = True
            txtmes.Visible = True
            lbtitulo.Text = "BUSCAR ENTRADAS"
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*,concat(t.nombre,' ',t.apellidos) as nom  FROM movimientos" & txtmes.Text & " m ,terceros t WHERE t.nit=m.nitc and m.tipodoc ='EN' AND m.n_pedido<>'FAC' " _
                                    & " ORDER BY tipodoc, num;"
        Else
            txtcli.Visible = False
            lbper.Visible = False
            txtmes.Visible = False
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*,concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & PerActual(0) & PerActual(1) & "  m LEFT JOIN terceros t ON t.nit=m.nitc WHERE m.tipodoc='" & lbtipo.Text & "' ORDER BY num;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(1, i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
            gitems.Item(2, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("per") & "  " & tabla.Rows(i).Item("hora").ToString
            gitems.Item(3, i).Value = tabla.Rows(i).Item("desc_mov")
            gitems.Item(4, i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item("tercero", i).Value = tabla.Rows(i).Item("nitc")
            gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
        Next
        '   Catch ex As Exception
        '    MsgBox(ex.ToString)
        ' End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
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
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "entradas"
                FrmEntradas.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmEntradas.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmEntradas.lbestado.Text = "CONSULTA"
                FrmEntradas.lbnumero.Text = mifila + 1
            Case "salidas"
                FrmSalidas.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmSalidas.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmSalidas.lbestado.Text = "CONSULTA"
                FrmSalidas.lbnumero.Text = mifila + 1
            Case "traslados"
                FrmTraslados.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmTraslados.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmTraslados.lbestado.Text = "CONSULTA"
                FrmTraslados.lbnumero.Text = mifila + 1
            Case "ajus_val"
                FrmAjustes.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmAjustes.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmAjustes.lbestado.Text = "CONSULTA"
                FrmAjustes.lbnumero.Text = mifila + 1
            Case "ajustes"
                FrmAjustesCant.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmAjustesCant.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmAjustesCant.lbestado.Text = "CONSULTA"
                FrmAjustesCant.lbnumero.Text = mifila + 1
            Case "FacturaEst"
                BuscarDocumentoFS(gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value(), mifila)
            Case "Factura"
                'Frmfacturarapida.txtremision.Text = gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value()
                BuscarDocumentoF(gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value(), mifila)
                'Frmfacturarapida.txtremision.Text = gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value()
            Case "FacturaC"
                BuscarDocumentoFC(gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value())
                FrmDocProveedor.txtremision.Text = gitems.Item(4, mifila).Value() & gitems.Item(1, mifila).Value()
            Case "SaldosIniInv"
                FrmSaldosIniInv.txtnumfac.Text = gitems.Item(1, mifila).Value()
                FrmSaldosIniInv.txttipo.Text = gitems.Item(4, mifila).Value()
                FrmSaldosIniInv.lbestado.Text = "CONSULTA"
        End Select
        gitems.Focus()
        Me.Close()
    End Sub
    Public Sub BuscarDocumentoFC(ByVal doc As String)
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & txtmes.Text & " WHERE doc='" & doc & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        FrmDocProveedor.PonerenCero()
        FrmDocProveedor.Desbloquear()
        FrmDocProveedor.lbusuario.Text = FrmPrincipal.lbuser.Text
        FrmDocProveedor.lbhora.Text = Format(Now, "HH:mm:ss")

        FrmDocProveedor.txttipo.Enabled = False
        FrmDocProveedor.BuscarClientes(tabla.Rows(0).Item("nitc"))
        FrmDocProveedor.grup_tip_doc.Enabled = False
        FrmDocProveedor.grupoafecta.Enabled = False
        FrmDocProveedor.rbafecta2.Checked = True

        '.......
        Dim ts As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Refresh()

        If ts.Rows(0).Item(0) = "admin" Then
            FrmDocProveedor.txtnitc.Enabled = True
            FrmDocProveedor.txtfecha.Enabled = True
        Else
            FrmDocProveedor.txtnitc.Enabled = False
            FrmDocProveedor.txtfecha.Enabled = False
        End If
        'FrmDocProveedor.txtnitc.Enabled = False
        FrmDocProveedor.txtnitc.Text = tabla.Rows(0).Item("nitc")
        FrmDocProveedor.cmditems.Enabled = False
        FrmDocProveedor.cmdConceptos.Enabled = True
        FrmDocProveedor.lbestado.Text = "NUEVO"
        FrmDocProveedor.txt_doc_afe.Enabled = True
        FrmDocProveedor.valordes.Enabled = False
        FrmDocProveedor.txtobserbaciones.Text = "APARTIR DE ENTRADA N° " & doc & tabla.Rows(0).Item("concepto")
        'cuentas
        FrmDocProveedor.txtflete.Enabled = False
        FrmDocProveedor.txtseguro.Enabled = False
        '
        FrmDocProveedor.valorret.Enabled = False
        FrmDocProveedor.chcosto.Enabled = False
        FrmDocProveedor.gfactura.Rows.Clear()
        FrmDocProveedor.gfactura.RowCount = 1
        BuscarDetallesC(doc)
        FrmDocProveedor.CalcularTotales()
        FrmDocProveedor.cbaprobado.Text = "AP"
        FrmDocProveedor.cbaprobado.Enabled = False
    End Sub
    Public Sub BuscarDocumentoFS(ByVal doc As String, ByVal fl As Integer)
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & txtmes.Text & " WHERE doc='" & doc & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '***************************************
        'Frmfacturarapida.PonerEnCero()
        'Frmfacturarapida.Desbloquear()
        FrmFacturaEstetica.lbusuario.Text = FrmPrincipal.lbuser.Text
        FrmFacturaEstetica.lbhora.Text = Format(Now, "HH:mm:ss")
        FrmFacturaEstetica.txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)

        FrmFacturaEstetica.BuscarClientes(tabla.Rows(0).Item("nitc"))
        FrmFacturaEstetica.grupoafecta.Enabled = False
        FrmFacturaEstetica.rbafecta2.Checked = True
        '.......
        Dim ts As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Refresh()

        If ts.Rows(0).Item(0) = "admin" Then
            FrmFacturaEstetica.txtnitc.Enabled = True
            FrmFacturaEstetica.txtfecha.Enabled = True
        Else
            FrmFacturaEstetica.txtnitc.Enabled = False
            FrmFacturaEstetica.txtfecha.Enabled = False
        End If

        'FrmFacturaEstetica.txtnitc.Enabled = False
        FrmFacturaEstetica.txtnitc.Text = tabla.Rows(0).Item("nitc")
        FrmFacturaEstetica.cmditems.Enabled = False
        FrmFacturaEstetica.cmdConceptos.Enabled = False
        FrmFacturaEstetica.lbestado.Text = "NUEVO"
        FrmFacturaEstetica.valordes.Enabled = False
        'FrmFacturaEstetica.txtobserbaciones.Text = FrmFacturaEstetica.txtobserbaciones.Text & "APARTIR DE SALIDA N° " & doc & tabla.Rows(0).Item("concepto")
        If FrmFacturaEstetica.txtremision.Text = "" Then
            FrmFacturaEstetica.gfactura.Rows.Clear()
            FrmFacturaEstetica.gfactura.RowCount = 1
        End If
        'FrmFacturaEstetica.gfactura.Rows.Clear()
        'FrmFacturaEstetica.gfactura.RowCount = 1
        BuscarDetallesES(doc, fl)
        FrmFacturaEstetica.CalcularTotales()
        FrmFacturaEstetica.cbaprobado.Text = "AP"
        FrmFacturaEstetica.cbaprobado.Enabled = False

        '***************************************
        '  Timer1.Enabled = False
        ' bloquear()
        ' lbestado.Text = "CONSULTA"

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & FrmFacturaEstetica.txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count = 0 Then
            FrmFacturaEstetica.txttipo2.Text = ""
        Else
            FrmFacturaEstetica.txttipo2.Text = ta.Rows(0).Item(0)
        End If
        'Frmfacturarapida.BuscarNumero()
        'If Frmfacturarapida.lbestado.Text = "NUEVO" Then
        '    VeificarRDIAN(Frmfacturarapida.txttipo.Text, Val(Frmfacturarapida.txtnumfac.Text), Frmfacturarapida.txtfecha.Value)
        'End If
    End Sub
    Public Sub BuscarDocumentoF(ByVal doc As String, ByVal fl As Integer)
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos" & txtmes.Text & " WHERE doc='" & doc & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '***************************************
        'Frmfacturarapida.PonerEnCero()
        'Frmfacturarapida.Desbloquear()
        Frmfacturarapida.lbusuario.Text = FrmPrincipal.lbuser.Text
        Frmfacturarapida.lbhora.Text = Format(Now, "HH:mm:ss")
        Frmfacturarapida.txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)

        Frmfacturarapida.BuscarClientes(tabla.Rows(0).Item("nitc"))
        Frmfacturarapida.grupoafecta.Enabled = False
        Frmfacturarapida.rbafecta2.Checked = True
        '.......
        Dim ts As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Refresh()

        If ts.Rows(0).Item(0) = "admin" Then
            Frmfacturarapida.txtnitc.Enabled = True
            Frmfacturarapida.txtfecha.Enabled = True
        Else
            Frmfacturarapida.txtnitc.Enabled = False
            Frmfacturarapida.txtfecha.Enabled = False
        End If

        'Frmfacturarapida.txtnitc.Enabled = False
        Frmfacturarapida.txtnitc.Text = tabla.Rows(0).Item("nitc")
        Frmfacturarapida.cmditems.Enabled = False
        Frmfacturarapida.cmdConceptos.Enabled = False
        Frmfacturarapida.lbestado.Text = "NUEVO"
        Frmfacturarapida.valordes.Enabled = False
        'Frmfacturarapida.txtobserbaciones.Text = Frmfacturarapida.txtobserbaciones.Text & "APARTIR DE SALIDA N° " & doc & tabla.Rows(0).Item("concepto")
        If Frmfacturarapida.txtremision.Text = "" Then
            Frmfacturarapida.gfactura.Rows.Clear()
            Frmfacturarapida.gfactura.RowCount = 1
        End If
        'Frmfacturarapida.gfactura.Rows.Clear()
        'Frmfacturarapida.gfactura.RowCount = 1
        BuscarDetalles(doc, fl)
        Frmfacturarapida.CalcularTotales()
        Frmfacturarapida.cbaprobado.Text = "AP"
        Frmfacturarapida.cbaprobado.Enabled = False

        '***************************************
        '  Timer1.Enabled = False
        ' bloquear()
        ' lbestado.Text = "CONSULTA"

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Frmfacturarapida.txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        Refresh()
        If ta.Rows.Count = 0 Then
            Frmfacturarapida.txttipo2.Text = ""
        Else
            Frmfacturarapida.txttipo2.Text = ta.Rows(0).Item(0)
        End If
        'Frmfacturarapida.BuscarNumero()
        'If Frmfacturarapida.lbestado.Text = "NUEVO" Then
        '    VeificarRDIAN(Frmfacturarapida.txttipo.Text, Val(Frmfacturarapida.txtnumfac.Text), Frmfacturarapida.txtfecha.Value)
        'End If
    End Sub
    Dim v As Integer
    Public Sub BuscarDetalles(ByVal num_per As String, ByVal fl As Integer)

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT d.* , a.iva FROM deta_mov" & txtmes.Text & " d,  articulos a where d.doc= '" & num_per & "' and  a.codart= d.codart ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        'parametrosfac()
        If Frmfacturarapida.txtremision.Text = "" Then
            v = 0
            Frmfacturarapida.gfactura.Rows.Clear()
            Frmfacturarapida.gfactura.RowCount = tabla.Rows.Count
        Else
            Frmfacturarapida.gfactura.RowCount = Frmfacturarapida.gfactura.RowCount + tabla.Rows.Count
        End If
        'Frmfacturarapida.gfactura.RowCount = Frmfacturarapida.gfactura.RowCount + tabla.Rows.Count
        'Frmfacturarapida.gfactura.Rows.Count
        Dim suma As Double
        Dim dct As Double
        Dim base As Double
        If Frmfacturarapida.txtremision.Text = "" Then
            suma = 0
            dct = 0
            base = 0
        End If
        Try
            If v = 0 Then 'NO HAY ARTICULOS
                For i = 0 To tabla.Rows.Count - 1
                    Frmfacturarapida.gfactura.Item(0, v).Value = tabla.Rows(i).Item("item")
                    Frmfacturarapida.gfactura.Item("tipo", v).Value = "I"
                    Frmfacturarapida.gfactura.Item(1, v).Value = tabla.Rows(i).Item("codart")
                    Frmfacturarapida.gfactura.Item("descrip", v).Value = tabla.Rows(i).Item("nomart")
                    Frmfacturarapida.gfactura.Item("bodega", v).Value = tabla.Rows(i).Item("bod_ori")
                    Frmfacturarapida.gfactura.Item(3, v).Value = Decimales(tabla.Rows(i).Item("cantidad"))
                    Frmfacturarapida.gfactura.Item(4, v).Value = (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                    Frmfacturarapida.gfactura.Item(5, v).Value = Moneda(tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                    Frmfacturarapida.gfactura.Item("iva", v).Value = tabla.Rows(i).Item("iva")
                    'descuento
                    Frmfacturarapida.gfactura.Item("descuento", v).Value = Moneda(0)
                    Try
                        base = tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))) / (1 + (tabla.Rows(i).Item("iva") / 100))
                    Catch ex As Exception
                        base = 0
                    End Try
                    Try
                        dct = dct + (base * 0 / 100)
                    Catch ex As Exception
                    End Try
                    If Frmfacturarapida.txtremision.Text = "" Then
                        Frmfacturarapida.lbdescuento.Text = dct
                    Else
                        Frmfacturarapida.lbdescuento.Text = Frmfacturarapida.lbdescuento.Text + dct
                    End If
                    'Frmfacturarapida.lbdescuento.Text = dct
                    'cuentas
                    Frmfacturarapida.gfactura.Item("ctainv", v).Value = tabla.Rows(i).Item("cta_inv")
                    Frmfacturarapida.gfactura.Item("ctacven", v).Value = tabla.Rows(i).Item("cta_cos")
                    Frmfacturarapida.gfactura.Item("ctaing", v).Value = tabla.Rows(i).Item("cta_ing")
                    Frmfacturarapida.gfactura.Item("ctaiva", v).Value = tabla.Rows(i).Item("cta_iva")
                    Frmfacturarapida.gfactura.Item("costo", v).Value = tabla.Rows(i).Item("costo")
                    Frmfacturarapida.gfactura.Item("cc", v).Value = ""
                    Frmfacturarapida.gfactura.Item("nit", v).Value = ""
                    suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                    v = v + 1
                Next
            Else
                Dim k As String = ""
                ' SI HAY ART EN LA GRILLA
                For i = 0 To tabla.Rows.Count - 1
                    k = ""
                    For j = 0 To Frmfacturarapida.gfactura.RowCount - 1
                        If Frmfacturarapida.gfactura.Item(1, j).Value = tabla.Rows(i).Item("codart") And Frmfacturarapida.gfactura.Item("bodega", j).Value = tabla.Rows(i).Item("bod_ori") Then
                            Frmfacturarapida.gfactura.Item(3, j).Value = Decimales(CDbl(Frmfacturarapida.gfactura.Item(3, j).Value) + tabla.Rows(i).Item("cantidad"))
                            'Frmfacturarapida.gfactura.Item(4, j).Value = CDbl(Frmfacturarapida.gfactura.Item(4, j).Value) + (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                            Frmfacturarapida.gfactura.Item(5, j).Value = Moneda(CDbl(Frmfacturarapida.gfactura.Item(5, j).Value) + ((tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))))
                            'Frmfacturarapida.gfactura.Item("iva", j).Value = CDbl(Frmfacturarapida.gfactura.Item("iva", j).Value) + tabla.Rows(i).Item("iva")
                            suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                            k = "Ok"
                            Exit For
                            'Else
                        End If
                    Next
                    If k = "" Then
                        Frmfacturarapida.gfactura.Item(0, v).Value = tabla.Rows(i).Item("item")
                        Frmfacturarapida.gfactura.Item("tipo", v).Value = "I"
                        Frmfacturarapida.gfactura.Item(1, v).Value = tabla.Rows(i).Item("codart")
                        Frmfacturarapida.gfactura.Item("descrip", v).Value = tabla.Rows(i).Item("nomart")
                        Frmfacturarapida.gfactura.Item("bodega", v).Value = tabla.Rows(i).Item("bod_ori")
                        Frmfacturarapida.gfactura.Item(3, v).Value = Decimales(tabla.Rows(i).Item("cantidad"))
                        Frmfacturarapida.gfactura.Item(4, v).Value = (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                        Frmfacturarapida.gfactura.Item(5, v).Value = Moneda(tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                        Frmfacturarapida.gfactura.Item("iva", v).Value = tabla.Rows(i).Item("iva")
                        'descuento
                        Frmfacturarapida.gfactura.Item("descuento", v).Value = Moneda(0)
                        Try
                            base = tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))) / (1 + (tabla.Rows(i).Item("iva") / 100))
                        Catch ex As Exception
                            base = 0
                        End Try
                        Try
                            dct = dct + (base * 0 / 100)
                        Catch ex As Exception
                        End Try
                        If Frmfacturarapida.txtremision.Text = "" Then
                            Frmfacturarapida.lbdescuento.Text = dct
                        Else
                            Frmfacturarapida.lbdescuento.Text = Frmfacturarapida.lbdescuento.Text + dct
                        End If
                        'Frmfacturarapida.lbdescuento.Text = dct
                        'cuentas
                        Frmfacturarapida.gfactura.Item("ctainv", v).Value = tabla.Rows(i).Item("cta_inv")
                        Frmfacturarapida.gfactura.Item("ctacven", v).Value = tabla.Rows(i).Item("cta_cos")
                        Frmfacturarapida.gfactura.Item("ctaing", v).Value = tabla.Rows(i).Item("cta_ing")
                        Frmfacturarapida.gfactura.Item("ctaiva", v).Value = tabla.Rows(i).Item("cta_iva")
                        Frmfacturarapida.gfactura.Item("costo", v).Value = tabla.Rows(i).Item("costo")
                        Frmfacturarapida.gfactura.Item("cc", v).Value = ""
                        Frmfacturarapida.gfactura.Item("nit", v).Value = ""
                        suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                        v = v + 1
                    End If
                Next
            End If

            Frmfacturarapida.txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
            If Frmfacturarapida.txtremision.Text = "" Then
                Frmfacturarapida.txttotal.Text = Moneda(suma)
                Frmfacturarapida.txtremision.Text = gitems.Item(4, fl).Value() & gitems.Item(1, fl).Value() & "-" & txtmes.Text
            Else
                Frmfacturarapida.txttotal.Text = Frmfacturarapida.txttotal.Text + Moneda(suma)
                Frmfacturarapida.txtremision.Text = Frmfacturarapida.txtremision.Text & ";" & gitems.Item(4, fl).Value() & gitems.Item(1, fl).Value() & "-" & txtmes.Text
            End If
            'Frmfacturarapida.txttotal.Text = Moneda(suma)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarDetallesES(ByVal num_per As String, ByVal fl As Integer)

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT d.* , a.iva FROM deta_mov" & txtmes.Text & " d,  articulos a where d.doc= '" & num_per & "' and  a.codart= d.codart ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        'parametrosfac()
        If FrmFacturaEstetica.txtremision.Text = "" Then
            v = 0
            FrmFacturaEstetica.gfactura.Rows.Clear()
            FrmFacturaEstetica.gfactura.RowCount = tabla.Rows.Count
        Else
            FrmFacturaEstetica.gfactura.RowCount = FrmFacturaEstetica.gfactura.RowCount + tabla.Rows.Count
        End If
        'FrmFacturaEstetica.gfactura.RowCount = FrmFacturaEstetica.gfactura.RowCount + tabla.Rows.Count
        'FrmFacturaEstetica.gfactura.Rows.Count
        Dim suma As Double
        Dim dct As Double
        Dim base As Double
        If FrmFacturaEstetica.txtremision.Text = "" Then
            suma = 0
            dct = 0
            base = 0
        End If
        Try
            If v = 0 Then 'NO HAY ARTICULOS
                For i = 0 To tabla.Rows.Count - 1
                    FrmFacturaEstetica.gfactura.Item(0, v).Value = tabla.Rows(i).Item("item")
                    FrmFacturaEstetica.gfactura.Item("tipo", v).Value = "I"
                    FrmFacturaEstetica.gfactura.Item(1, v).Value = tabla.Rows(i).Item("codart")
                    FrmFacturaEstetica.gfactura.Item("descrip", v).Value = tabla.Rows(i).Item("nomart")
                    FrmFacturaEstetica.gfactura.Item("bodega", v).Value = tabla.Rows(i).Item("bod_ori")
                    FrmFacturaEstetica.gfactura.Item(3, v).Value = Decimales(tabla.Rows(i).Item("cantidad"))
                    FrmFacturaEstetica.gfactura.Item(4, v).Value = (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                    FrmFacturaEstetica.gfactura.Item(5, v).Value = Moneda(tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                    FrmFacturaEstetica.gfactura.Item("iva", v).Value = tabla.Rows(i).Item("iva")
                    'descuento
                    FrmFacturaEstetica.gfactura.Item("descuento", v).Value = Moneda(0)
                    Try
                        base = tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))) / (1 + (tabla.Rows(i).Item("iva") / 100))
                    Catch ex As Exception
                        base = 0
                    End Try
                    Try
                        dct = dct + (base * 0 / 100)
                    Catch ex As Exception
                    End Try
                    If FrmFacturaEstetica.txtremision.Text = "" Then
                        FrmFacturaEstetica.lbdescuento.Text = dct
                    Else
                        FrmFacturaEstetica.lbdescuento.Text = FrmFacturaEstetica.lbdescuento.Text + dct
                    End If
                    'FrmFacturaEstetica.lbdescuento.Text = dct
                    'cuentas
                    FrmFacturaEstetica.gfactura.Item("ctainv", v).Value = tabla.Rows(i).Item("cta_inv")
                    FrmFacturaEstetica.gfactura.Item("ctacven", v).Value = tabla.Rows(i).Item("cta_cos")
                    FrmFacturaEstetica.gfactura.Item("ctaing", v).Value = tabla.Rows(i).Item("cta_ing")
                    FrmFacturaEstetica.gfactura.Item("ctaiva", v).Value = tabla.Rows(i).Item("cta_iva")
                    FrmFacturaEstetica.gfactura.Item("costo", v).Value = tabla.Rows(i).Item("costo")
                    FrmFacturaEstetica.gfactura.Item("cc", v).Value = ""
                    FrmFacturaEstetica.gfactura.Item("nit", v).Value = ""
                    suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                    v = v + 1
                Next
            Else
                Dim k As String = ""
                ' SI HAY ART EN LA GRILLA
                For i = 0 To tabla.Rows.Count - 1
                    k = ""
                    For j = 0 To FrmFacturaEstetica.gfactura.RowCount - 1
                        If FrmFacturaEstetica.gfactura.Item(1, j).Value = tabla.Rows(i).Item("codart") And FrmFacturaEstetica.gfactura.Item("bodega", j).Value = tabla.Rows(i).Item("bod_ori") Then
                            FrmFacturaEstetica.gfactura.Item(3, j).Value = Decimales(CDbl(FrmFacturaEstetica.gfactura.Item(3, j).Value) + tabla.Rows(i).Item("cantidad"))
                            'FrmFacturaEstetica.gfactura.Item(4, j).Value = CDbl(FrmFacturaEstetica.gfactura.Item(4, j).Value) + (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                            FrmFacturaEstetica.gfactura.Item(5, j).Value = Moneda(CDbl(FrmFacturaEstetica.gfactura.Item(5, j).Value) + ((tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))))
                            'FrmFacturaEstetica.gfactura.Item("iva", j).Value = CDbl(FrmFacturaEstetica.gfactura.Item("iva", j).Value) + tabla.Rows(i).Item("iva")
                            suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                            k = "Ok"
                            Exit For
                            'Else
                        End If
                    Next
                    If k = "" Then
                        FrmFacturaEstetica.gfactura.Item(0, v).Value = tabla.Rows(i).Item("item")
                        FrmFacturaEstetica.gfactura.Item("tipo", v).Value = "I"
                        FrmFacturaEstetica.gfactura.Item(1, v).Value = tabla.Rows(i).Item("codart")
                        FrmFacturaEstetica.gfactura.Item("descrip", v).Value = tabla.Rows(i).Item("nomart")
                        FrmFacturaEstetica.gfactura.Item("bodega", v).Value = tabla.Rows(i).Item("bod_ori")
                        FrmFacturaEstetica.gfactura.Item(3, v).Value = Decimales(tabla.Rows(i).Item("cantidad"))
                        FrmFacturaEstetica.gfactura.Item(4, v).Value = (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                        FrmFacturaEstetica.gfactura.Item(5, v).Value = Moneda(tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                        FrmFacturaEstetica.gfactura.Item("iva", v).Value = tabla.Rows(i).Item("iva")
                        'descuento
                        FrmFacturaEstetica.gfactura.Item("descuento", v).Value = Moneda(0)
                        Try
                            base = tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))) / (1 + (tabla.Rows(i).Item("iva") / 100))
                        Catch ex As Exception
                            base = 0
                        End Try
                        Try
                            dct = dct + (base * 0 / 100)
                        Catch ex As Exception
                        End Try
                        If FrmFacturaEstetica.txtremision.Text = "" Then
                            FrmFacturaEstetica.lbdescuento.Text = dct
                        Else
                            FrmFacturaEstetica.lbdescuento.Text = FrmFacturaEstetica.lbdescuento.Text + dct
                        End If
                        'FrmFacturaEstetica.lbdescuento.Text = dct
                        'cuentas
                        FrmFacturaEstetica.gfactura.Item("ctainv", v).Value = tabla.Rows(i).Item("cta_inv")
                        FrmFacturaEstetica.gfactura.Item("ctacven", v).Value = tabla.Rows(i).Item("cta_cos")
                        FrmFacturaEstetica.gfactura.Item("ctaing", v).Value = tabla.Rows(i).Item("cta_ing")
                        FrmFacturaEstetica.gfactura.Item("ctaiva", v).Value = tabla.Rows(i).Item("cta_iva")
                        FrmFacturaEstetica.gfactura.Item("costo", v).Value = tabla.Rows(i).Item("costo")
                        FrmFacturaEstetica.gfactura.Item("cc", v).Value = ""
                        FrmFacturaEstetica.gfactura.Item("nit", v).Value = ""
                        suma = suma + (tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                        v = v + 1
                    End If
                Next
            End If

            FrmFacturaEstetica.txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
            If FrmFacturaEstetica.txtremision.Text = "" Then
                FrmFacturaEstetica.txttotal.Text = Moneda(suma)
                FrmFacturaEstetica.txtremision.Text = gitems.Item(4, fl).Value() & gitems.Item(1, fl).Value() & "-" & txtmes.Text
            Else
                FrmFacturaEstetica.txttotal.Text = FrmFacturaEstetica.txttotal.Text + Moneda(suma)
                FrmFacturaEstetica.txtremision.Text = FrmFacturaEstetica.txtremision.Text & ";" & gitems.Item(4, fl).Value() & gitems.Item(1, fl).Value() & "-" & txtmes.Text
            End If
            'FrmFacturaEstetica.txttotal.Text = Moneda(suma)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarDetallesC(ByVal num_per As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT d.* , a.iva FROM deta_mov" & txtmes.Text & " d,  articulos a where d.doc= '" & num_per & "' and  a.codart= d.codart ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        FrmDocProveedor.Parametros()
        FrmDocProveedor.gfactura.RowCount = tabla.Rows.Count

        Dim suma As Double = 0
        FrmDocProveedor.lbdescuento.Text = "0"
        Dim dct As Double = 0
        Dim base As Double = 0
        Try
            For i = 0 To tabla.Rows.Count - 1
                FrmDocProveedor.gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                FrmDocProveedor.gfactura.Item("tipo", i).Value = "I"
                FrmDocProveedor.gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("codart")
                FrmDocProveedor.gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nomart")
                FrmDocProveedor.gfactura.Item("bodega", i).Value = tabla.Rows(i).Item("bod_des")
                Try
                    FrmDocProveedor.gfactura.Item("cant", i).Value = Decimales(tabla.Rows(i).Item("cantidad").ToString)
                Catch ex As Exception
                End Try
                FrmDocProveedor.gfactura.Item("valor", i).Value = (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100)))
                FrmDocProveedor.gfactura.Item("Vtotal", i).Value = Moneda(tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))))
                FrmDocProveedor.gfactura.Item("iva", i).Value = tabla.Rows(i).Item("iva")
                'cuentas
                FrmDocProveedor.gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                FrmDocProveedor.gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                FrmDocProveedor.gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                FrmDocProveedor.gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                FrmDocProveedor.gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                FrmDocProveedor.gfactura.Item("cc", i).Value = ""
                '... descuento
                FrmDocProveedor.gfactura.Item("descuento", i).Value = Moneda(0)
                Try
                    base = tabla.Rows(i).Item("cantidad") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("iva") / 100))) / (1 + (tabla.Rows(i).Item("iva") / 100))
                Catch ex As Exception
                    base = 0
                End Try
                Try
                    dct = dct + (base * 0 / 100)
                Catch ex As Exception
                End Try
                FrmDocProveedor.lbdescuento.Text = dct
                '....
                Try
                    suma = suma + tabla.Rows(i).Item("vtotal")
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '*****************************************

    End Sub
    Private Sub parametrosfac()
        Dim tabla As New DataTable
        '*********************FACTURA RAPIDA********************************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='RAPIDA';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        ''''''''''''''''''DOC PRE'''''''''''''''''''''''''''''''
        If Frmfacturarapida.lbestado.Text = "NUEVO" Then
            Frmfacturarapida.txttipo.Enabled = False
            If tabla.Rows(0).Item("doc").ToString = "N" Then
                Frmfacturarapida.txttipo.Text = ""
                Frmfacturarapida.txttipo2.Text = ""
            Else
                Frmfacturarapida.txttipo.Text = tabla.Rows(0).Item("tipodoc")
            End If

            ''''''''''''''''''NIT VENDEDOR PRE'''''''''''''''''''''''''''''''
            If tabla.Rows(0).Item("nitvpre").ToString = "N" Then
                'Frmfacturarapida.txtnitv.Text = ""
                'Frmfacturarapida.txtvendedor.Text = ""
                Dim Archivo As String = ""
                Dim ruta As String
                ruta = My.Application.Info.DirectoryPath & "\" & "ven_fr.txt"
                If My.Computer.FileSystem.FileExists(ruta) Then
                    Archivo = My.Computer.FileSystem.ReadAllText(ruta)
                    Frmfacturarapida.txtnitv.Text = Archivo
                    Frmfacturarapida.Buscarvendedor()
                Else
                    Frmfacturarapida.txtnitv.Text = ""
                    Frmfacturarapida.txtvendedor.Text = ""
                End If
            Else
                Frmfacturarapida.txtnitv.Text = tabla.Rows(0).Item("nitv")
                Frmfacturarapida.Buscarvendedor()
            End If
        Else 'MODIFICAR
            '  txttipo.Enabled = False
        End If

        ''''''''''''''''''''NUMERO FACT'''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("numfact").ToString = "automatico" Then
            Frmfacturarapida.txtnumfac.Enabled = False
        Else
            Frmfacturarapida.txtnumfac.Enabled = True
        End If

        ''''''''''''''''''''FECHA '''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("fecha").ToString = "automatico" Then
            Frmfacturarapida.txtfecha.Enabled = False
        Else
            Frmfacturarapida.txtfecha.Enabled = True
        End If

        '''''''''''''''''' MANEJAR CENTRO DE COSTOS '''''''''''''''''''''''''
        If tabla.Rows(0).Item("centrocost").ToString = "N" Then
            If Frmfacturarapida.lbestado.Text = "NUEVO" Then Frmfacturarapida.txtcentrocos.Text = ""
            Frmfacturarapida.txtcentrocos.Enabled = False
        Else
            If Frmfacturarapida.lbestado.Text = "NUEVO" Then Frmfacturarapida.txtcentrocos.Text = ""
            Frmfacturarapida.txtcentrocos.Enabled = True
        End If
        '''''''''''''''''' CONCEPTO COMICINABLE PRE-DETERMINADO ''''''''''
        If tabla.Rows(0).Item("concomipre").ToString = "N" Then
            Frmfacturarapida.lbcc.Text = ""
        Else
            Frmfacturarapida.lbcc.Text = tabla.Rows(0).Item("concomi")
        End If
        ''''''''''''''''''FORMA DE PAGO PRE'''''''''''''''''''''''''''''''
        Dim campo As String = ""
        If Frmfacturarapida.lbestado.Text = "NUEVO" Then
            Frmfacturarapida.gfp.RowCount = 1
            Frmfacturarapida.gfp.Rows.Clear()
            If tabla.Rows(0).Item("fpagopre").ToString = "N" Then
                campo = "caja"
            Else
                'Efectivo
                If tabla.Rows(0).Item("cualfp").ToString = "otra" Then
                    Frmfacturarapida.gfp.Item(0, 0).Value = "Otra"
                    Frmfacturarapida.gfp.Item(1, 0).Value = "CREDITO"
                    campo = "ctapc"
                    Frmfacturarapida.txtvmto.Text = "30"
                ElseIf tabla.Rows(0).Item("cualfp").ToString = "cheque" Then
                    Frmfacturarapida.gfp.Item(0, 0).Value = "Cheque"
                    Frmfacturarapida.gfp.Item(1, 0).Value = ""
                    campo = "bancos"
                ElseIf tabla.Rows(0).Item("cualfp").ToString = "tarjeta" Then
                    Frmfacturarapida.gfp.Item(0, 0).Value = "Tarjeta"
                    Frmfacturarapida.gfp.Item(1, 0).Value = ""
                    campo = "bancos"
                Else
                    Frmfacturarapida.gfp.Item(0, 0).Value = "Efectivo"
                    Frmfacturarapida.gfp.Item(1, 0).Value = "Efectivo"
                    campo = "caja"
                End If
            End If
        End If
        '**************** PARAMETROS G/RALES ****************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        'HAY INTERFAZ CONTABLE
        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then
            If Frmfacturarapida.lbestado.Text = "NUEVO" Then
                Frmfacturarapida.valoriva.Text = tabla.Rows(0).Item("porivapp")
                Frmfacturarapida.txtcuentaiva.Text = tabla.Rows(0).Item("ivapp")
                Frmfacturarapida.valordes.Text = "0,00"
                Frmfacturarapida.txtcuentadesc.Text = tabla.Rows(0).Item("descuento")
                Frmfacturarapida.txtcuentatotal.Text = tabla.Rows(0).Item(campo)
            End If
            Frmfacturarapida.txtcuentaiva.Enabled = True
            Frmfacturarapida.txtcuentadesc.Enabled = True
            Frmfacturarapida.txtcuentatotal.Enabled = True
        Else
            If Frmfacturarapida.lbestado.Text = "NUEVO" Then
                Frmfacturarapida.valoriva.Text = "0,00"
                Frmfacturarapida.txtcuentaiva.Text = ""
                Frmfacturarapida.valordes.Text = "0,00"
                Frmfacturarapida.txtcuentadesc.Text = ""
                Frmfacturarapida.txtcuentatotal.Text = ""
            End If
            Frmfacturarapida.txtcuentaiva.Enabled = False
            Frmfacturarapida.txtcuentadesc.Enabled = False
            Frmfacturarapida.txtcuentatotal.Enabled = False
        End If
        'COMICION EN VENTAS
        Frmfacturarapida.lbcomicion.Text = tabla.Rows(0).Item("comventa").ToString
        'PRECIO CON IVA INCLUIDO
        Frmfacturarapida.lbprecioiva.Text = tabla.Rows(0).Item("ivainclu").ToString
        'FORMULA PARA CALCULAR PRECIO
        Frmfacturarapida.lbformula.Text = tabla.Rows(0).Item("formcosto").ToString
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
            SendKeys.Send("{TAB}")
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Try
            If Trim(txtcuenta.Text) = "" Then Exit Sub
            txtcuenta.Text = NumeroDoc(txtcuenta.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtmes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmes.SelectedIndexChanged
        Dim tabla As New DataTable
        Dim tabla_c As New DataTable
        Dim items As Integer
        Dim per As String = ""
        Dim sql As String = ""
        If lbform.Text = "Factura" Then
            txtcli.Visible = True
            lbper.Visible = True
            txtmes.Visible = True
            lbtitulo.Text = "BUSCAR SALIDAS"
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='SA' AND o_compra<>'FAC' " _
                                    & " ORDER BY tipodoc, num;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            gitems.Rows.Clear()
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(1, i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
                gitems.Item(2, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("per") & "  " & tabla.Rows(i).Item("hora").ToString
                gitems.Item(3, i).Value = tabla.Rows(i).Item("desc_mov")
                gitems.Item(4, i).Value = tabla.Rows(i).Item("tipodoc")
                gitems.Item("tercero", i).Value = tabla.Rows(i).Item("nitc")
                gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
            Next

            ' cargar clientes
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.nitc, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='SA' AND o_compra<>'FAC' " _
                                    & " GROUP BY nitc ORDER BY nom;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_c)
            Refresh()
            txtcli.Items.Clear()
            txtcli.Items.Add("TODOS")
            For j = 0 To tabla_c.Rows.Count - 1
                txtcli.Items.Add(Trim(tabla_c.Rows(j).Item("nom")))
            Next

        ElseIf lbform.Text = "FacturaC" Then
            txtcli.Visible = True
            lbper.Visible = True
            txtmes.Visible = True
            lbtitulo.Text = "BUSCAR ENTRADAS"
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.*, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='EN' AND n_pedido<>'FAC' " _
                                    & " ORDER BY tipodoc, num;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            gitems.Rows.Clear()
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(1, i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
                gitems.Item(2, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("per") & "  " & tabla.Rows(i).Item("hora").ToString
                gitems.Item(3, i).Value = tabla.Rows(i).Item("desc_mov")
                gitems.Item(4, i).Value = tabla.Rows(i).Item("tipodoc")
                gitems.Item("tercero", i).Value = tabla.Rows(i).Item("nitc")
                gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
            Next

            ' cargar clientes
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT m.nitc, IFNULL(concat(t.nombre,' ',t.apellidos),'Q') as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='EN' AND n_pedido<>'FAC' " _
                                    & " GROUP BY nitc ORDER BY nom;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_c)
            Refresh()
            txtcli.Items.Clear()
            txtcli.Items.Add("TODOS")
            For j = 0 To tabla_c.Rows.Count - 1
                If tabla_c.Rows(j).Item("nom") <> "Q" Then
                    txtcli.Items.Add(Trim(tabla_c.Rows(j).Item("nom")))
                End If
            Next

        End If

    End Sub

    Private Sub txtcli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcli.SelectedIndexChanged
        If txtcli.Text = "TODOS" Then
            txtmes_SelectedIndexChanged(AcceptButton, AcceptButton)
        Else

            Dim tabla As New DataTable
            Dim items As Integer
            If lbform.Text = "Factura" Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT m.*, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='SA' AND o_compra<>'FAC' AND  concat(t.nombre,' ',t.apellidos) = '" & txtcli.Text & "'" _
                                        & " ORDER BY tipodoc, num;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                gitems.Rows.Clear()
                gitems.RowCount = items + 1
                For i = 0 To items - 1
                    gitems.Item(1, i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("per") & "  " & tabla.Rows(i).Item("hora").ToString
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("desc_mov")
                    gitems.Item(4, i).Value = tabla.Rows(i).Item("tipodoc")
                    gitems.Item("tercero", i).Value = tabla.Rows(i).Item("nitc")
                    gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
                Next

            ElseIf lbform.Text = "FacturaC" Then

                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT m.*, concat(t.nombre,' ',t.apellidos) as nom FROM movimientos" & txtmes.Text & " m LEFT JOIN terceros t ON t.nit=m.nitc WHERE tipodoc ='EN' AND n_pedido<>'FAC' AND  concat(t.nombre,' ',t.apellidos) = '" & txtcli.Text & "' " _
                                        & " ORDER BY tipodoc, num;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                gitems.Rows.Clear()
                gitems.RowCount = items + 1
                For i = 0 To items - 1
                    gitems.Item(1, i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("per") & "  " & tabla.Rows(i).Item("hora").ToString
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("desc_mov")
                    gitems.Item(4, i).Value = tabla.Rows(i).Item("tipodoc")
                    gitems.Item("tercero", i).Value = tabla.Rows(i).Item("nitc")
                    gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
                Next
            End If

        End If
    End Sub
End Class