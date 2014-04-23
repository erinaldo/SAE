Imports MySql.Data.MySqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmFacturasyAjustesSP
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click

        FrmItems.txtnumfac.Text = txtnumfac.Text
        FrmItems.txtfecha.Text = txtfecha.Text.ToString
        FrmItems.txttipo.Text = txttipo.Text
        FrmItems.txttipo2.Text = txttipo2.Text
        FrmItems.lbnit.Text = txtnitc.Text
        FrmItems.gitems.RowCount = 1
        Try
            FrmItems.gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        FrmItems.gitems.RowCount = gfactura.RowCount
        Dim tb As New DataTable
        For i = 0 To gfactura.RowCount - 1
            Try
                tb.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT " _
                & " ROUND((" & DIN(gfactura.Item(4, i).Value) & " / (1 + ( " & DIN(gfactura.Item("iva", i).Value) & " / 100) )) + 25,-2) as pcon " _
                & "  FROM parafacgral ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)

                Dim pre As Double
                If lbprecioiva.Text = "NO" Then
                    pre = CDbl(tb.Rows(0).Item(0))
                    'pre = CDbl(gfactura.Item(4, i).Value) / (1 + (gfactura.Item("iva", i).Value / 100))
                Else
                    pre = CDbl(gfactura.Item(4, i).Value)
                End If

                FrmItems.gitems.Item("num", i).Value = i + 1
                FrmItems.gitems.Item("tipo", i).Value = gfactura.Item(6, i).Value
                FrmItems.gitems.Item("codigo", i).Value = gfactura.Item(1, i).Value
                FrmItems.gitems.Item("descrip", i).Value = gfactura.Item(2, i).Value
                FrmItems.gitems.Item("cant", i).Value = Fraccion(gfactura.Item(3, i).Value)
                FrmItems.gitems.Item("precio", i).Value = pre
                FrmItems.gitems.Item("bodega", i).Value = gfactura.Item(7, i).Value
                FrmItems.gitems.Item("iva", i).Value = gfactura.Item("iva", i).Value
                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
                FrmItems.gitems.Item("descuento", i).Value = Moneda2(gfactura.Item("descuento", i).Value)
                FrmItems.gitems.Item("nit", i).Value = gfactura.Item("nit", i).Value.ToString
                FrmItems.gitems.Item("precio2", i).Value = gfactura.Item("precio2", i).Value
            Catch ex As Exception

            End Try
        Next
        FrmItems.lbiva.Text = lbprecioiva.Text
        FrmItems.gitems.Columns(1).ReadOnly = False  'tipo I/S
        FrmItems.gitems.Columns(6).ReadOnly = False  'bodega
        If lbcomicion.Text = "NO" Then
            FrmItems.gitems.Columns("cc").ReadOnly = True  'NO hay concepto comicionable
        Else
            FrmItems.gitems.Columns("cc").ReadOnly = False  'SI hay concepto comicionable
        End If
        FrmItems.lbform.Text = "fn_sp"
        'If txttipo.Text <> lbdocajuste.Text Then
        FrmItems.LbTipoMov.Text = "salidas"
        'Else
        '    FrmItems.LbTipoMov.Text = "entradas"
        'End If

        If txttipo.Text = "AF" Then ' AJUSTE FACTURA
            FrmItems.gitems.Columns("descuento").Visible = False
            FrmItems.gitems.Columns("ctaing").Visible = True
            FrmItems.gitems.Columns("ctaing").ReadOnly = False
        Else
            FrmItems.gitems.Columns("descuento").Visible = True
            FrmItems.gitems.Columns("ctaing").Visible = False
            FrmItems.gitems.Columns("ctaing").ReadOnly = True
        End If

        FrmItems.gitems.Focus()
        FrmItems.ShowDialog()
        FrmItems.lbiva.Text = "NO"
        FrmItems.gitems.Columns("cc").ReadOnly = False
        CalcularTotales()
    End Sub
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        cmditems.Enabled = False
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                txtnitc_LostFocus(AcceptButton, AcceptButton)
            Else
                validarnumero(txtnitc, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnitc.Text)
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub
    Private Sub retecree()
        Try
            Dim tcr As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcr)
            Refresh()
            If tcr.Rows(0).Item("persona") = "juridica" And tcr.Rows(0).Item("retecree") = "SI" Then
                Dim tr As New DataTable
                myCommand.CommandText = "SELECT * FROM retecree WHERE codigo ='" & tcr.Rows(0).Item("act1") & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tr)
                Refresh()
                If tr.Rows.Count > 0 Then
                    valorretCree.Text = Moneda2(tr.Rows(0).Item("tarifa"))
                    txtcuentaCree.Text = tr.Rows(0).Item("cuenta")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nit,TRIM(CONCAT(apellidos,' ',nombre))AS ter FROM terceros ORDER BY ter;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("ter")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "fn"
            FrmSelCliente.ShowDialog()
            If txtcliente.Text <> "" Then
                BuscarClientes(txtnitc.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "fn_sp"
                frmterceros.txtnit.Text = txtnitc.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                If txtcliente.Text <> "" Then
                    BuscarClientes(txtnitc.Text)
                End If
                txtnitv.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                lbentrega.Text = txtcliente.Text
                lbdir.Text = tabla.Rows(0).Item("dir")
                lbciudad.Text = BuscarMun(tabla.Rows(0).Item("mun"))
            End If
        End If
    End Sub
    Function BuscarMun(ByVal mun As String)
        Try
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM sae.mun WHERE codmun ='" & mun & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Return tabla.Rows(0).Item("descripcion")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    ''////////////////////////////////////////   
    Private Sub txtnitv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged
        cmditems.Enabled = False
    End Sub
    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitv.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtnitv, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnitv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus
        If txtnitv.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtvendedor.Text = ""
            cargarvendedor()
        Else
            Buscarvendedor()
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub
    Public Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores where estado='activo' ORDER BY nombre ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = "fn"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Buscarvendedor()
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtvendedor.Text = ""
            MsgBox("El nit/cédula del vendedor no existe en los registros.", MsgBoxStyle.Information, "Verificando")
            cargarvendedor()
            cmditems.Focus()
        Else  'mostrar uno solo q coinside
            txtvendedor.Text = tabla.Rows(0).Item(1)
        End If
    End Sub
    Private Sub valordes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valordes.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(valordes, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub valordes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valordes.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valor_rtfuente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor_rtfuente.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(valor_rtfuente, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub valor_rtfuente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor_rtfuente.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valor_rtica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor_rtica.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(valor_rtica, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub valor_rtica_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor_rtica.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valor_rtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valor_rtiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        ElseIf lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(valor_rtiva, e)
        Else
            Beep()
            e.Handled = True
        End If
    End Sub
    Private Sub valor_rtiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valor_rtiva.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valoriva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valoriva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtcuentadesc.Focus()
        End If
    End Sub
    Private Sub valoriva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valoriva.LostFocus
        CalcularTotales()
    End Sub
    '*************** TOTALES ///////////////////////////////////
    Public Sub CalcularTotales()
        Dim v_iva, x, desc, sd, vt, st, base As Double
        v_iva = 0
        sd = 0
        st = 0
        base = 0
        Try
            For i = 0 To gfactura.RowCount - 1
                Try 'base sin descuento
                    vt = CDbl(gfactura.Item("Vtotal", i).Value) / (1 + (CDec(gfactura.Item("iva", i).Value) / 100)) 'base
                Catch ex As Exception
                    vt = 0
                End Try
                Try
                    desc = vt * (CDbl(gfactura.Item("descuento", i).Value) / 100)
                    'desc = vt * (CDbl(valordes.Text) / 100) 
                Catch ex As Exception
                    desc = 0
                End Try

                vt = vt - desc
                st = st + vt 'subtotal

                Try
                    desc = vt * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try

                ' desc = CDbl(lbdescuento.Text)
                sd = sd + desc

                Try
                    vt = vt - desc 'nueeva base
                Catch ex As Exception
                    vt = 0
                End Try
                base = base + vt
                Try
                    x = vt * (CDec(gfactura.Item("iva", i).Value) / 100)
                    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                Catch ex As Exception
                    ' MsgBox(ex.ToString)
                    x = 0
                End Try
                v_iva = v_iva + x
            Next
            txtiva.Text = Moneda2(v_iva)
        Catch ex As Exception
            txtiva.Text = Moneda2(v_iva)
            valoriva.Text = "0,00"
        End Try

        '***** Descuentos
        Try
            valordes.Text = Format(CDbl(valordes.Text), "0.00")
        Catch ex As Exception
            valordes.Text = "0,00"
        End Try
        '********* RETENCIONES ************
        'RT FUENTE
        Try
            valor_rtfuente.Text = Format(CDbl(valor_rtfuente.Text), "0.00")
        Catch ex As Exception
            valor_rtfuente.Text = "0,00"
        End Try
        'RT CREE
        Try
            valorretCree.Text = Format(CDbl(valorretCree.Text), "0.00")
        Catch ex As Exception
            valorretCree.Text = "0,00"
        End Try
        'RT ICA
        Try
            valor_rtica.Text = Format(CDbl(valor_rtica.Text), "0.00")
        Catch ex As Exception
            valor_rtica.Text = "0,00"
        End Try
        'RT IVA
        Try
            valor_rtiva.Text = Format(CDbl(valor_rtiva.Text), "0.00")
        Catch ex As Exception
            valor_rtiva.Text = "0,00"
        End Try
        '*****************************
        'st = CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)
        '  txtdescuento.Text = Moneda2(CDbl(valordes.Text) * st / 100)
        '*****************************
        'txtdescuento.Text = Moneda2(sd + lbdescuento.Text)
        txtdescuento.Text = Moneda2(sd)
        txtrtefuente.Text = Moneda2(CDbl(valor_rtfuente.Text) * base / 100)
        txtretCre.Text = Moneda2(CDbl(valorretCree.Text) * base / 100)
        txtrica.Text = Moneda2(CDbl(valor_rtica.Text) * base / 100)
        txtriva.Text = Moneda2(CDbl(valor_rtiva.Text) * base / 100)
        '*****************************
        txtsubtotal.Text = Moneda2(st)
        txttotal.Text = Moneda2(st + CDbl(Moneda2(txtiva.Text)) + CDbl(Moneda2(txtrtefuente.Text)) + CDbl(Moneda2(txtrica.Text)) + CDbl(Moneda2(txtriva.Text)) + CDbl(Moneda2(txtdescuento.Text)) + CDbl(Moneda2(txtretCre.Text)))
        ' txttotal.Text = Moneda2(st + CDbl(txtiva.Text) - CDbl(txtrtefuente.Text) - CDbl(txtrica.Text) - CDbl(txtriva.Text) - CDbl(lbdescuento.Text))
        For i = 0 To cbsr.Items.Count - 1
            Try
                If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                    txttotal.Text = Moneda2(CDbl(txttotal.Text) + CDbl(cbvalor.Items.Item(i)))
                ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                    txttotal.Text = Moneda2(CDbl(txttotal.Text) - CDbl(cbvalor.Items.Item(i)))
                End If
            Catch ex As Exception
            End Try
        Next
        If gfp.RowCount = 1 Then
            gfp.Item("monto", 0).Value = txttotal.Text
        End If
    End Sub
    '///////////////////////////////////////////
    Public Sub PonerEnCero()
        cmbTipoAF.Text = "Seleccione..."
        txtdocafec.Text = ""
        Timer1.Enabled = False
        lbhora.Text = "00:00:00"
        lbestado.Text = "NULO"
        cmditems.Enabled = False
        txttipo.Enabled = False
        lbAnula.Text = ""
        txttipo2.Text = ""
        txtnumfac.Text = ""
        lbnumero.Text = ""
        rbafecta2.Checked = True
        ' txtfecha.Text = DateTime.Now.ToString("yyyy-MM-dd")
        Try
            txtfecha.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
            If txtfecha.Enabled = True Then
                txtfecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
            Else
                txtfecha.Value = CDate(PerActual & "/" & "01")
            End If
        End Try
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtnitv.Text = ""
        txtvendedor.Text = ""
        txtsubtotal.Text = "0,00"
        txtdescuento.Text = "0,00"
        lbdescuento.Text = "0,00"
        txtiva.Text = "0,00"
        txttotal.Text = "0,00"
        valordes.Text = "0,00"
        valor_rtfuente.Text = "0,00"
        valorretCree.Text = "0,00"
        valor_rtica.Text = "0,00"
        valor_rtiva.Text = "0,00"
        lbsubtotal.Text = "0,00"
        gfactura.RowCount = 1
        txtcuentadesc.Text = ""
        txtcuentaiva.Text = ""
        txtcuentatotal.Text = ""
        txtctaretef.Text = ""
        txtcuentaCree.Text = ""
        txtctarica.Text = ""
        txtctariva.Text = ""
        cbaprobado.Text = ""
        lbusuario.Text = ""
        txtvmto.Text = "0"
        txtcentrocosto.Text = ""
        txtobserbaciones.Text = ""
        '****************
        lbentrega.Text = ""
        lbdir.Text = ""
        lbciudad.Text = ""
        lborden.Text = ""
        lbfecha.Text = txtfecha.Value.ToString
        '**********************
        txtfecha.Enabled = False
        grupoafecta.Enabled = False
        txtcentrocosto.Enabled = False
        cbaprobado.Enabled = False
        txtcuentaiva.Enabled = False
        txtcuentadesc.Enabled = False
        txtctaretef.Enabled = False
        txtctarica.Enabled = False
        txtctariva.Enabled = False
        txtcuentaCree.Enabled = False
        txtcuentatotal.Enabled = False
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        gfp.Rows.Clear()
        gfp.RowCount = 1
        lbvalor.Text = "0,00"
        cbconcepto.Items.Clear()
        cbsr.Items.Clear()
        cbvalor.Items.Clear()
        cbcuenta.Items.Clear()
        CalcularTotales()
    End Sub
    Public Sub BuscarUser(ByVal usuario As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.usuarios WHERE login='" & usuario & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        lbusuario.Text = tabla.Rows(0).Item("nombres") & " " & tabla.Rows(0).Item("apellidos")
    End Sub
    ' ////////   INICIO BARRA DE BOTONES FACTURA  ''''''''''''''''
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Public Sub bloquear()
        txtnumfac.Enabled = False
        txtnitc.Enabled = False
        txtnitv.Enabled = False
        txtfecha.Enabled = False
        cbaprobado.Enabled = False
        grup_tip_doc.Enabled = False
        cmditems.Enabled = False
        'txtcentrocos.Enabled = False
        '******impuestos ************
        valordes.Enabled = False
        valor_rtfuente.Enabled = False
        valor_rtica.Enabled = False
        valor_rtiva.Enabled = False
        valoriva.Enabled = False
        txtvmto.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        cmdNuevoAF.Enabled = True
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        '******* conceptos ***********
        cbconcepto.Enabled = False
        cbsr.Enabled = False
        cbvalor.Enabled = False
        cbcuenta.Enabled = False
        txtcentrocosto.Enabled = False
        cmbTipoAF.Enabled = False
    End Sub
    Public Sub Desbloquear()

        txtnitc.Enabled = True
        txtnitv.Enabled = True
        txtfecha.Enabled = True
        cbaprobado.Enabled = True
        cmditems.Enabled = True
        grup_tip_doc.Enabled = True
        '******impuestos ************
        valordes.Enabled = True
        valor_rtfuente.Enabled = True
        valorretCree.Enabled = True
        valor_rtica.Enabled = True
        valor_rtiva.Enabled = True
        valoriva.Enabled = True
        txtvmto.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        cmdNuevoAF.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        '******* conceptos ***********
        cbconcepto.Enabled = True
        cbsr.Enabled = True
        cbvalor.Enabled = True
        cbcuenta.Enabled = True
        '....
        If txtdocafec.Text <> "" Then
            cmbTipoAF.Enabled = True
        Else
            cmbTipoAF.Enabled = False
        End If
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") = "S" Then
                txtcentrocosto.Enabled = True
            Else
                txtcentrocosto.Enabled = False
            End If
        Catch ex As Exception
            txtcentrocosto.Enabled = False
        End Try
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        PonerEnCero()
        BuscarPeriodo()
        lbestado.Text = "NUEVO"
        Try
            Parametros()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Desbloquear()
        lbusuario.Text = FrmPrincipal.lbuser.Text
        '  txtnitv.Text = 0
        ' Buscarvendedor()
        '  cmditems.Enabled = True
        txttipo.Enabled = True
        Timer1.Enabled = True
        lbhora.Text = Format(Now, "HH:mm:ss")
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        CalcularTotales()
        cbaprobado.Enabled = True
        rbafecta1.Checked = True
        cmditems.Enabled = True
    End Sub
    Public usacontfn As String
    Public Sub Parametros()
        Dim tabla As New DataTable
        '*********************FACTURA RAPIDA********************************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='NORMAL';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        ''''''''''''''''''DOC PRE'''''''''''''''''''''''''''''''
        If lbestado.Text = "NUEVO" Then
            txttipo.Enabled = True
            If tabla.Rows(0).Item("doc").ToString = "N" Then
                txttipo.Text = ""
                txttipo2.Text = ""
            Else
                txttipo.Text = tabla.Rows(0).Item("tipodoc")
            End If
            ''''''''''''''''''NIT CLIENTE PRE'''''''''''''''''''''''''''''''
            If tabla.Rows(0).Item("nitcpre").ToString = "N" Then
                txtnitc.Text = ""
                txtcliente.Text = ""
            Else
                txtnitc.Text = tabla.Rows(0).Item("nitc")
                txtnitc_LostFocus(AcceptButton, AcceptButton)
            End If
            ''''''''''''''''''NIT VENDEDOR PRE'''''''''''''''''''''''''''''''
            If tabla.Rows(0).Item("nitvpre").ToString = "N" Then
                'txtnitv.Text = ""
                'txtvendedor.Text = ""
                Dim Archivo As String = ""
                Dim ruta As String
                ruta = My.Application.Info.DirectoryPath & "\" & "ven_fn.txt"
                If My.Computer.FileSystem.FileExists(ruta) Then
                    Archivo = My.Computer.FileSystem.ReadAllText(ruta)
                    txtnitv.Text = Archivo
                    Buscarvendedor()
                Else
                    txtnitv.Text = ""
                    txtvendedor.Text = ""
                End If
            Else
                txtnitv.Text = tabla.Rows(0).Item("nitv")
                txtnitv_LostFocus(AcceptButton, AcceptButton)
            End If
        Else 'MODIFICAR
            txttipo.Enabled = False
        End If

        ''''''''''''''''''''NUMERO FACT'''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("numfact").ToString = "automatico" Then
            txtnumfac.Enabled = False
        Else
            txtnumfac.Enabled = True
        End If
        ''''''''''''''''''AFECTA SIEMPRE INV'''''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("afecinv").ToString = "S" Then
            rbafecta1.Checked = True
            grupoafecta.Enabled = False
        Else
            rbafecta1.Checked = True
            grupoafecta.Enabled = True
        End If
        ''''''''''''''''''''FECHA '''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("fecha").ToString = "automatico" Then
            txtfecha.Enabled = False
        Else
            txtfecha.Enabled = True
        End If
        '''''''''''''''''' BODEGA PRE-DETERMINADA '''''''''''''''''''''''''
        If tabla.Rows(0).Item("bodpred").ToString = "N" Then
            lbnumbod.Text = ""
        Else
            lbnumbod.Text = tabla.Rows(0).Item("idbod")
        End If
        '''''''''''''''''' MARGEN PRECIO MINIMO '''''''''''''''''''''''''
        lbcontrolprecio.Text = tabla.Rows(0).Item("margmin").ToString
        lbmargen.Text = tabla.Rows(0).Item("margen")
        '''''''''''''''''' MANEJAR CENTRO DE COSTOS '''''''''''''''''''''''''
        If tabla.Rows(0).Item("centrocost").ToString = "N" Then
            If lbestado.Text = "NUEVO" Then txtcentrocosto.Text = ""
            txtcentrocosto.Enabled = False
        Else
            If lbestado.Text = "NUEVO" Then txtcentrocosto.Text = ""
            txtcentrocosto.Enabled = True
        End If
        '''''''''''''''''' CONCEPTO COMICINABLE PRE-DETERMINADO ''''''''''
        If tabla.Rows(0).Item("concomipre").ToString = "N" Then
            lbcc.Text = ""
        Else
            lbcc.Text = tabla.Rows(0).Item("concomi")
        End If
        ''''''''''''''''''FORMA DE PAGO PRE'''''''''''''''''''''''''''''''
        Dim campo As String = ""
        If lbestado.Text = "NUEVO" Then
            gfp.RowCount = 1
            gfp.Rows.Clear()
            If tabla.Rows(0).Item("fpagopre").ToString = "N" Then
                campo = "caja"
            Else
                'Efectivo
                If tabla.Rows(0).Item("cualfp").ToString = "otra" Then
                    gfp.Item(0, 0).Value = "Otra"
                    gfp.Item(1, 0).Value = "CREDITO"
                    txtvmto.Text = "30"
                    campo = "ctapc"
                ElseIf tabla.Rows(0).Item("cualfp").ToString = "cheque" Then
                    gfp.Item(0, 0).Value = "Cheque"
                    gfp.Item(1, 0).Value = ""
                    campo = "bancos"
                ElseIf tabla.Rows(0).Item("cualfp").ToString = "tarjeta" Then
                    gfp.Item(0, 0).Value = "Tarjeta"
                    gfp.Item(1, 0).Value = ""
                    campo = "bancos"
                Else
                    gfp.Item(0, 0).Value = "Efectivo"
                    gfp.Item(1, 0).Value = "Efectivo"
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
        usacontfn = ""
        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then
            '.. Parametros inventarios
            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT contable FROM parinven ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            Try
                usacontfn = tp.Rows(0).Item(0)
            Catch ex As Exception
                usacontfn = "no"
            End Try
            If lbestado.Text = "NUEVO" Then
                'iva
                valoriva.Text = tabla.Rows(0).Item("porivapp")
                txtcuentaiva.Text = tabla.Rows(0).Item("ivapp")
                'descuento
                valordes.Text = "0,00"
                txtcuentadesc.Text = tabla.Rows(0).Item("descuento")
                'total
                txtcuentatotal.Text = tabla.Rows(0).Item(campo)
                '********** retenciones ***************
                'rt f
                valor_rtfuente.Text = "0,00"
                txtctaretef.Text = tabla.Rows(0).Item("retfuente")
                'rt ica
                valor_rtica.Text = "0,00"
                txtctarica.Text = tabla.Rows(0).Item("reteica")
                'rt iva
                valor_rtiva.Text = "0,00"
                txtctariva.Text = tabla.Rows(0).Item("reteiva")
                'rt cree
                valorretCree.Text = "0,00"
                txtcuentaCree.Text = ""
            End If
            txtcuentaiva.Enabled = True
            txtcuentadesc.Enabled = True
            txtctaretef.Enabled = True
            txtctarica.Enabled = True
            txtctariva.Enabled = True
            txtcuentatotal.Enabled = True
            txtcuentaCree.Enabled = True
        Else
            usacontfn = "no"
            If lbestado.Text = "NUEVO" Then
                valoriva.Text = "0,00"
                txtcuentaiva.Text = ""
                valordes.Text = "0,00"
                txtcuentadesc.Text = ""
                txtcuentatotal.Text = ""
                '********** retenciones ***************
                'rt f
                valor_rtfuente.Text = "0,00"
                txtctaretef.Text = ""
                'rt ica
                valor_rtica.Text = "0,00"
                txtctarica.Text = ""
                'rt iva
                valor_rtiva.Text = "0,00"
                txtctariva.Text = ""
            End If
            txtcuentaiva.Enabled = False
            txtcuentadesc.Enabled = False
            txtctaretef.Enabled = False
            txtctarica.Enabled = False
            txtctariva.Enabled = False
            txtcuentatotal.Enabled = False
        End If
        'COMICION EN VENTAS
        lbcomicion.Text = tabla.Rows(0).Item("comventa").ToString
        'PRECIO CON IVA INCLUIDO
        lbprecioiva.Text = tabla.Rows(0).Item("ivainclu").ToString
        'FORMULA PARA CALCULAR PRECIO
        lbformula.Text = tabla.Rows(0).Item("formcosto").ToString
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Then
            ValidarGuardar()
        ElseIf lbestado.Text = "EDITAR" Then
            ValidarModificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
        CalcularTotales()
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        If lbestado.Text <> "CONSULTA" Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If cbaprobado.Text = "AP" Then
                MsgBox("Documeto aprobado(AP), no se puede modificar.  ", MsgBoxStyle.Information, "SAE Control")
            Else
                Try
                    Parametros()
                Catch ex As Exception
                    MsgBox("Error al momento de consultar los parametros, verifique. " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
                End Try
                lbestado.Text = "EDITAR"
                Desbloquear()
                cmditems.Enabled = True
                cbaprobado.Enabled = True
                'IF AUDI
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Frmfacturarapida.limpiarDatosAudi()
                    llenarDatosAudi()
                End If
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If cbaprobado.Text = "AP" Then
                MsgBox("Documeto aprobado(AP), no se puede eliminar.  ", MsgBoxStyle.Information, "SAE Control")
            Else
                Eliminar()
            End If
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelFacturaVenta.cmbper.Text = PerActual(0) & PerActual(1)
        FrmSelFacturaVenta.lbform.Text = "fn_sp"
        FrmSelFacturaVenta.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            Dim n As String = lbnumero.Text
            BuscarFactura(txttipo.Text & txtnumfac.Text)
            lbnumero.Text = n
        End If
    End Sub
    '////////// ELIMINAR ///////////////////////////////////////////////////
    Public Sub Eliminar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='RAPIDA';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        ''''''''''''''''''SI numfact (NUMERO DE FACTURA) ES MANUAL SE ELIMINA'''''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("numfact").ToString = "automatico" Then
            MsgBox("El documeto no se puede eliminar porque los numeros son automaticos.  ", MsgBoxStyle.Information, "SAE Control")
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del documento " & txttipo.Text & txtnumfac.Text & " se van ha eliminar, ¿Desea Borrarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.CommandText = "DELETE FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';" _
                                      & "DELETE FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';" _
                                      & "DELETE FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';" _
                                      & "DELETE FROM otcon_fac" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  "
                myCommand.ExecuteNonQuery()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "ELIMINAR FACTURA COD: " & txttipo.Text & txtnumfac.Text, "", "", "")
                End If
                '.....
                MsgBox("El documeto fué eliminado correctamente.  ", MsgBoxStyle.Information, "SAE Control")
            End If
        End If
    End Sub
    '////////// GUARDAR ///////////////////////////////////////////////////
    Public Sub ValidarGuardar()
        CalcularTotales()

        If txttipo2.Text = "" Then
            MsgBox("No ha escogido el tipo de factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txttipo.Focus()
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtvendedor.Text = "" Then
            MsgBox("No ha digitado datos del vendedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitv.Focus()
            Exit Sub
            'ElseIf lbdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            '    MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            '    txtcuentadesc.Focus()
            '    Exit Sub
        ElseIf txtdescuento.Text <> Moneda2(0) And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
            Exit Sub
        ElseIf valor_rtfuente.Text <> Moneda2(0) And txtctaretef.Text = "" And txtctaretef.Enabled = True Then
            MsgBox("No ha escojido cuenta para la Rete Fuente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctaretef.Focus()
            Exit Sub
        ElseIf valorretCree.Text <> Moneda2(0) And txtcuentaCree.Text = "" And txtcuentaCree.Enabled = True Then
            MsgBox("No ha escojido cuenta para el Imprevisto, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaCree.Focus()
            Exit Sub
        ElseIf valor_rtica.Text <> Moneda2(0) And txtctarica.Text = "" And txtctarica.Enabled = True Then
            MsgBox("No ha escojido cuenta para el Rete I.C.A, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctarica.Focus()
            Exit Sub
        ElseIf valor_rtiva.Text <> Moneda2(0) And txtctariva.Text = "" And txtctariva.Enabled = True Then
            MsgBox("No ha escojido cuenta para el Imprevisto, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctariva.Focus()
            Exit Sub
        ElseIf CDbl(txttotal.Text) <= 0 And CDbl(lbvalor.Text) = 0 Then
            MsgBox("El total a pagar deber mayor que cero (0), Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf txtcuentatotal.Text = "" And txtcuentatotal.Enabled = True Then
            MsgBox("No ha escojido forma de pago o la cuenta, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmdfpago.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf cmbTipoAF.Enabled = True And cmbTipoAF.Text = "Seleccione..." Then
            MsgBox("No ha escogido el Tipo de Ajuste para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmbTipoAF.Focus()
            Exit Sub
        End If
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value)
        Next
        If sumafp <> Moneda2(txttotal.Text) Or gfp.Item("cual", 0).Value = "" Then
            MsgBox("Verifique la forma de pago.", MsgBoxStyle.Information, "Control Factura ")
            cdmfpago_Click(AcceptButton, AcceptButton)
            Exit Sub
        End If
        If PerActual <> Format(txtfecha.Value, "MM/yyyy") Then
            MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
            If txtfecha.Enabled = True Then
                txtfecha.Focus()
            End If
            Exit Sub
        End If
        'If txtcuentatotal.Text = "130505001" And txttipo.Text = lbdocajuste.Text Then
        '    MsgBox("Verifique la forma de pago ", MsgBoxStyle.Information, "Verificacion")
        '    cmdfpago.Focus()
        '    Exit Sub
        'End If
        '''''' VALIDAR SI EXIXTE FACTURA '''''''''''''''''
        Dim sw As Integer = 0
        Dim conta As Integer = 0
        Do
            Dim cons As String = ""
            If txttipo.Text = lbdocajuste.Text Then
                cons = cons & "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
            Else

                Dim p As String = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> 12 Then
                        cons = cons & "SELECT * FROM facturas" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM facturas" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
                    End If
                Next
            End If
            Dim t As New DataTable
            myCommand.CommandText = cons
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()

            'If t.Rows.Count = 0 Then
            '    'End If
            '    'Dim t As New DataTable
            '    myCommand.CommandText = "SELECT doc FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            '    myAdapter.SelectCommand = myCommand
            '    myAdapter.Fill(t)
            '    Refresh()
            If t.Rows.Count > 0 Then
                If txtnumfac.Enabled = True Then
                    MsgBox("Verifique el numero de factura, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
                    txtnumfac.Focus()
                    Exit Sub
                Else
                    If conta < 3 Then
                        If txttipo.Text = lbdocajuste.Text Then
                            BuscarNumero()
                            txtnumfac.Text = NumeroDoc(txtnumfac.Text + 1)
                        Else
                            Dim tnf As New DataTable
                            tnf.Clear()
                            myCommand.CommandText = "SELECT actualfc FROM `tipdoc` where tipodoc='" & txttipo.Text & "' ;"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tnf)
                            Refresh()
                            conta = tnf.Rows(0).Item(0)
                            txtnumfac.Text = NumeroDoc(conta + 1)
                        End If

                    End If

                End If
            Else
                sw = 1
            End If
        Loop While sw = 0
        Dim ap As String = ""
        ap = Frmfacturarapida.par_guar()
        If ap = "S" Then
            If cbaprobado.Text <> "AP" Then
                MsgBox("No se puede guardar la Factura si no esta Aprobada", MsgBoxStyle.Exclamation, "Verifique")
                Exit Sub
            End If
        End If

        'PARAMETRO LISTAR ARTIC CON EXISTENCIA PARA VALIDAR CANTI
        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows(0).Item(0) = "SI" Then
            '...VALIDAR CANTIDAD DISPONIBLE ...
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("codigo", i).Value <> "" And gfactura.Item("tipo", i).Value <> "S" Then
                    If cbaprobado.Text = "AP" Then
                        If ValidarCantidades(i) = False Then
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If
        validarcuentas()
        Try

            GuardarFactura()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function ValidarCantidades(ByVal fila As Integer)
        Try

            'SELECT lista_art FROM parafacgral
            If gfactura.Item("tipo", fila).Value = "I" Then
                Dim tbc As New DataTable
                tbc.Clear()
                myCommand.CommandText = "SELECT cant" & gfactura.Item("bodega", fila).Value & " FROM con_inv WHERE codart='" & gfactura.Item("codigo", fila).Value & "' and  periodo='" & PerActual(0) & PerActual(1) & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tbc)
                Refresh()
                If (CInt(tbc.Rows(0).Item(0)) - DIN(gfactura.Item(3, fila).Value)) < 0 Then
                    MsgBox("La cantidad disponible del articulo " & gfactura.Item("codigo", fila).Value & ", es " & tbc.Rows(0).Item(0) & " , Verifique", MsgBoxStyle.Information, "Verifique")
                    Return (False)
                    Exit Function
                End If
                Return (True)
            Else
                Return (True)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Sub GuardarAnticipos()
        'otros conceptos
        Dim sql As String = ""
        Dim sig As String = ""
        If txttipo.Text = lbdocajuste.Text Then
            sig = "-"
        Else
            sig = "+"
        End If
        For i = 0 To 2
            If i = 0 Then
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti1.Text) & "';"
                        'MsgBox(sql)
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    ' MsgBox(ex.ToString)
                End Try
            ElseIf i = 1 Then
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti2.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti3.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
    Public Sub GuardarFactura()
        Dim afecta As String
        ' txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(lbdescuento.Text)
        txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(txtdescuento.Text)
        If rbafecta1.Checked = True Then
            afecta = "SI"  'SI afecta inventario
        Else
            afecta = "NO"  'NO afecta inventario
        End If
        Timer1.Enabled = False
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
        myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text.ToString)
        If rbdocde1.Checked = True Then
            myCommand.Parameters.AddWithValue("?doc_de", "I")
        Else
            myCommand.Parameters.AddWithValue("?doc_de", "S")
        End If
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
        myCommand.Parameters.AddWithValue("?usuario", lbusuario.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text.ToString))
        myCommand.Parameters.AddWithValue("?hora", CDate(lbhora.Text))
        myCommand.Parameters.AddWithValue("?descrip", " ")
        myCommand.Parameters.AddWithValue("?doc_afec", txtdocafec.Text)
        myCommand.Parameters.AddWithValue("?afecta", afecta)
        'subtotal
        myCommand.Parameters.AddWithValue("?subtotal", DIN(txtsubtotal.Text))
        'descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(txtdescuento.Text))
        ' myCommand.Parameters.AddWithValue("?descuento", DIN(lbdescuento.Text))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_ret_f", DIN(valor_rtfuente.Text))
        myCommand.Parameters.AddWithValue("?ret_f", DIN(txtrtefuente.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_f", txtctaretef.Text)
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(txtiva.Text))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'rete_iva
        myCommand.Parameters.AddWithValue("?por_ret_iva", DIN(valor_rtiva.Text))
        myCommand.Parameters.AddWithValue("?ret_iva", DIN(txtriva.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_iva", txtctariva.Text)
        'ret_ica
        myCommand.Parameters.AddWithValue("?por_ret_ica", DIN(valor_rtica.Text))
        myCommand.Parameters.AddWithValue("?ret_ica", DIN(txtrica.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_ica", txtctarica.Text)
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", DIN(valorretCree.Text))
        myCommand.Parameters.AddWithValue("?rtc", DIN(txtretCre.Text))
        myCommand.Parameters.AddWithValue("?cta_rtc", txtcuentaCree.Text)
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'datos de entega
        myCommand.Parameters.AddWithValue("?entregar", CambiaCadena(lbentrega.Text, 60))
        myCommand.Parameters.AddWithValue("?dir_ent", CambiaCadena(lbdir.Text, 50))
        myCommand.Parameters.AddWithValue("?ciu_ent", CambiaCadena(lbciudad.Text, 30))
        myCommand.Parameters.AddWithValue("?o_compra", CambiaCadena(lborden.Text, 15))
        myCommand.Parameters.AddWithValue("?fecha_o", CambiaCadena(lbfecha.Text, 15))
        myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
        If (txtdocafec.Text <> "") And (txttipo.Text = lbdocajuste.Text) And (fpagoAJ <> "") Then
            myCommand.Parameters.AddWithValue("?val_aj", DIN(txttotal.Text))
        Else
            myCommand.Parameters.AddWithValue("?val_aj", DIN(0))
        End If
        'OTROS CONCEPTOS
        If cbsr.Items.Count = 0 Then
            myCommand.Parameters.AddWithValue("?o_con", "no")
        Else
            myCommand.Parameters.AddWithValue("?o_con", "si")
        End If
        myCommand.Parameters.AddWithValue("?t1", "")
        myCommand.Parameters.AddWithValue("?d1", "")
        myCommand.Parameters.AddWithValue("?v1", DIN(0))
        myCommand.Parameters.AddWithValue("?b1", DIN(0))
        myCommand.Parameters.AddWithValue("?cta1", "")
        myCommand.Parameters.AddWithValue("?doc1", "")
        myCommand.Parameters.AddWithValue("?t2", "")
        myCommand.Parameters.AddWithValue("?d2", "")
        myCommand.Parameters.AddWithValue("?v2", DIN(0))
        myCommand.Parameters.AddWithValue("?b2", DIN(0))
        myCommand.Parameters.AddWithValue("?cta2", "")
        myCommand.Parameters.AddWithValue("?doc2", "")
        myCommand.Parameters.AddWithValue("?t3", "")
        myCommand.Parameters.AddWithValue("?d3", "")
        myCommand.Parameters.AddWithValue("?v3", DIN(0))
        myCommand.Parameters.AddWithValue("?b3", DIN(0))
        myCommand.Parameters.AddWithValue("?cta3", "")
        myCommand.Parameters.AddWithValue("?doc3", "")
        ''otros conceptos
        'For i = 0 To 2
        '    If i = 0 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?o_con", "si")
        '                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v1", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta1", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc1", lbanti1.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?o_con", "no")
        '                myCommand.Parameters.AddWithValue("?t1", "")
        '                myCommand.Parameters.AddWithValue("?d1", "")
        '                myCommand.Parameters.AddWithValue("?v1", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta1", "")
        '                myCommand.Parameters.AddWithValue("?doc1", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?o_con", "no")
        '            myCommand.Parameters.AddWithValue("?t1", "")
        '            myCommand.Parameters.AddWithValue("?d1", "")
        '            myCommand.Parameters.AddWithValue("?v1", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta1", "")
        '            myCommand.Parameters.AddWithValue("?doc1", "")
        '        End Try
        '    ElseIf i = 1 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?t2", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d2", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v2", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta2", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc2", lbanti2.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?t2", "")
        '                myCommand.Parameters.AddWithValue("?d2", "")
        '                myCommand.Parameters.AddWithValue("?v2", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta2", "")
        '                myCommand.Parameters.AddWithValue("?doc2", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?t2", "")
        '            myCommand.Parameters.AddWithValue("?d2", "")
        '            myCommand.Parameters.AddWithValue("?v2", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta2", "")
        '            myCommand.Parameters.AddWithValue("?doc2", "")
        '        End Try
        '    Else
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?t3", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d3", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v3", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta3", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc3", lbanti3.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?t3", "")
        '                myCommand.Parameters.AddWithValue("?d3", "")
        '                myCommand.Parameters.AddWithValue("?v3", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta3", "")
        '                myCommand.Parameters.AddWithValue("?doc3", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?t3", "")
        '            myCommand.Parameters.AddWithValue("?d3", "")
        '            myCommand.Parameters.AddWithValue("?v3", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta3", "")
        '            myCommand.Parameters.AddWithValue("?doc3", "")
        '        End Try
        '    End If
        'Next

        'INSERTAR FACTURA
        myCommand.CommandText = "INSERT INTO facturas" & PerActual(0) & PerActual(1) & " VALUES (?doc,?num,?tipodoc,?doc_de,?nitc,?nitv,?usuario,?fecha,?hora,?descrip,?doc_afec,?afecta," _
                              & "?subtotal,?por_desc,?descuento,?cta_desc,?por_ret_f,?ret_f,?cta_ret_f,?por_iva,?iva,?cta_iva,?por_ret_iva,?ret_iva,?cta_ret_iva,?por_ret_ica,?ret_ica,?cta_ret_ica," _
                              & "?total,?cta_total,?estado,?observ,?vmto,?entregar,?dir_ent,?ciu_ent,?o_compra,?fecha_o,?cc," _
                              & "?o_con,?t1,?d1,?v1,?cta1,?t2,?d2,?v2,?cta2,?t3,?d3,?v3,?cta3,?doc1,?doc2,?doc3,?val_aj,?por_rtc,?rtc,?cta_rtc);"
        myCommand.ExecuteNonQuery()
        Refresh()
        Dim sw As Integer = 0
        Dim total_inv, subt As Double
        total_inv = 0
        If cbaprobado.Text = "AP" Then GuardarAnticipos()
        For i = 0 To gfactura.RowCount - 1
            If gfactura.Item("codigo", i).Value <> "" Then
                GuardarDetalles(i)
                If rbafecta1.Checked = True And cbaprobado.Text = "AP" Then 'AFECTA INVENTARIOS
                    If gfactura.Item("tipo", i).Value = "I" Then ' hay movimientos de inventarios
                        GuardarEnBodega(i)
                        sw = 1
                        Try
                            subt = CDbl(gfactura.Item("Vtotal", i).Value)
                        Catch ex As Exception
                            subt = 0
                        End Try
                        total_inv = total_inv + subt
                    End If
                End If
            End If
        Next
        For i = 0 To gfp.RowCount - 1
            If gfp.Item(0, i).Value <> "" Then
                GuardarPagos(i)
            End If
        Next
        If cbaprobado.Text = "AP" Then
            GuardarContable()
            If txttipo.Text <> lbdocajuste.Text Then GuardarCOBDPEN()
            GuardarMoviInvetarios(total_inv) 'si hay movi de inventarios y si afecta inventarios
        End If

        '...AJUST PAGO CREDITO
        If txtdocafec.Text <> "" And fpagoAJ <> "" And cbaprobado.Text = "AP" Then
            AbonoAJ()
        End If
        ValidarConsecutivo()
        '.....
        'If cbsr.Items.Count <> 0 Then
        GuardarOtrosConcep()
        'End If
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("FACTURACION", "GUARDAR FACTURA Nº: " & txttipo.Text & txtnumfac.Text, "", "", "")
        End If
        '.....
        bloquear()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        lbnumero.Text = "0"
        lbestado.Text = "GUARDADO"
        cmditems.Enabled = False
        cbaprobado.Enabled = False
    End Sub
    Private Sub GuardarOtrosConcep()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                     & " WHERE doc ='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            If cbsr.Items.Count <> 0 Then
                For j = 0 To cbsr.Items.Count - 1
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
                    myCommand.Parameters.AddWithValue("?itm", j + 1)
                    myCommand.Parameters.AddWithValue("?sg", cbsr.Items.Item(j))
                    myCommand.Parameters.AddWithValue("?des", CambiaCadena(cbconcepto.Items.Item(j), 99))
                    myCommand.Parameters.AddWithValue("?v", DIN(Moneda2(cbvalor.Items.Item(j))))
                    myCommand.Parameters.AddWithValue("?b", DIN(Moneda2(cbbase.Items.Item(j))))
                    myCommand.Parameters.AddWithValue("?cta", cbcuenta.Items.Item(j))
                    myCommand.Parameters.AddWithValue("?docAn", cbldoc.Items.Item(j))
                    myCommand.CommandText = "INSERT INTO otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                          & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                    myCommand.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            MsgBox("Error al registrar los otros conceptos, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
    End Sub

    Private Sub AbonoAJ()
        Try
            myCommand.Parameters.Clear()
            'myCommand.Parameters.AddWithValue("?abonado", DIN(txttotal.Text))
            myCommand.CommandText = "UPDATE cobdpen SET total=total-" & DIN(txttotal.Text) & " WHERE doc='" & txtdocafec.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text.ToString)
        myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
        myCommand.Parameters.AddWithValue("?tipo_it", gfactura.Item("tipo", fila).Value)
        myCommand.Parameters.AddWithValue("?codart", gfactura.Item(1, fila).Value)
        myCommand.Parameters.AddWithValue("?descrip", gfactura.Item(2, fila).Value)
        myCommand.Parameters.AddWithValue("?numbod", Val(gfactura.Item("bodega", fila).Value))
        myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
        myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item(4, fila).Value))
        myCommand.Parameters.AddWithValue("?vtotal", DIN(gfactura.Item(5, fila).Value))
        myCommand.Parameters.AddWithValue("?iva_d", DIN(gfactura.Item("iva", fila).Value))
        'descuento
        myCommand.Parameters.AddWithValue("?por_des", DIN(gfactura.Item("descuento", fila).Value))
        'cuentas y concepto
        myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
        myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
        myCommand.Parameters.AddWithValue("?cta_ing", gfactura.Item("ctaing", fila).Value)
        myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
        Try
            myCommand.Parameters.AddWithValue("?costo", DIN(gfactura.Item("costo", fila).Value))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?costo", "0")
        End Try
        myCommand.Parameters.AddWithValue("?concep", gfactura.Item("cc", fila).Value)
        Try
            myCommand.Parameters.AddWithValue("?nit", gfactura.Item("nit", fila).Value)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?nit", "")
        End Try
        'INSERTAR DETALLES
        myCommand.CommandText = "INSERT INTO detafac" & PerActual(0) & PerActual(1) & " " _
                              & " VALUES(?doc,?item,?tipo_it,?codart,?descrip,?numbod,?cantidad,?valor,?vtotal,?iva_d,?por_des,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo,?concep,?nit);"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            If gfactura.Item("tipo", fila).Value = "S" Then Exit Sub
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            If txttipo.Text <> lbdocajuste.Text Then
                myCommand.CommandText = "UPDATE con_inv SET cant" & gfactura.Item("bodega", fila).Value & "=cant" & gfactura.Item("bodega", fila).Value & " - ?cantidad " _
                                                 & " WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.CommandText = "UPDATE con_inv SET cant" & gfactura.Item("bodega", fila).Value & "=cant" & gfactura.Item("bodega", fila).Value & " + ?cantidad " _
                                 & " WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡ AUDITORIA ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡
    Private Sub validarcuentas()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                If txtcuentadesc.Text <> "" Then
                    Vali_cuent_fac("des", "FC-FACTURA DE VENTA", txtcuentadesc.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtcuentaiva.Text <> "" Then
                    Vali_cuent_fac("iva", "FC-FACTURA DE VENTA", txtcuentaiva.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtctaretef.Text <> "" Then
                    Vali_cuent_fac("rtf", "FC-FACTURA DE VENTA", txtctaretef.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtctarica.Text <> "" Then
                    Vali_cuent_fac("rtic", "FC-FACTURA DE VENTA", txtctarica.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtctariva.Text <> "" Then
                    Vali_cuent_fac("rtiv", "FC-FACTURA DE VENTA", txtctariva.Text, txttipo.Text & txtnumfac.Text)
                End If
                ' ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡ fin  AUDITORIA ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡
            Catch ex As Exception
                MsgBox("Error al Auditar " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If
    End Sub
    Public Sub GuardarPagos(ByVal fila As Integer)

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                '.....AUDITORIA 
                If gfp.Item("cual", fila).Value.ToString = "Cheque" Then
                    Vali_cuent_fac("ban", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", fila).Value.ToString = "Tarjeta" Then
                    Vali_cuent_fac("ban", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", fila).Value.ToString = "Efectivo" Then
                    Vali_cuent_fac("caja", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", fila).Value.ToString = "Otra" Then
                    Vali_cuent_fac("cxc", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                End If
                '....... FIN AUDITORIA 
            Catch ex As Exception
                MsgBox("Error al Auditar forma de pago" & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If

        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipo", gfp.Item("cual", fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?descrip", gfp.Item("detalle", fila).Value.ToString)
        ' if gfp.Item("tt", fila).Value.ToString)=null then
        Try
            If gfp.Item("tt", fila).Value.ToString <> "" Then
                myCommand.Parameters.AddWithValue("?tt", gfp.Item("tt", fila).Value.ToString)
            Else
                myCommand.Parameters.AddWithValue("?tt", "")
            End If
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?tt", "")
        End Try
        Try
            If gfp.Item("banco", fila).Value.ToString <> "" Then
                myCommand.Parameters.AddWithValue("?banco", gfp.Item("banco", fila).Value.ToString)
            Else
                myCommand.Parameters.AddWithValue("?banco", "")
            End If
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?banco", "")
        End Try
        Try
            If gfp.Item("numero", fila).Value.ToString <> "" Then
                myCommand.Parameters.AddWithValue("?numero", gfp.Item("numero", fila).Value.ToString)
            Else
                myCommand.Parameters.AddWithValue("?numero", "")
            End If
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?numero", "")
        End Try
        myCommand.Parameters.AddWithValue("?valor", DIN(gfp.Item("monto", fila).Value))
        'INSERTAR FORMAS DE PAGO
        myCommand.CommandText = "INSERT INTO facpagos" & PerActual(0) & PerActual(1) & " VALUES(?doc,?tipo,?descrip,?tt,?banco,?numero,?valor)"
        myCommand.ExecuteNonQuery()
    End Sub

    Public Sub GuardarContable()

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        grilla.RowCount = 1
        grilla.Rows.Clear()
        grilla.RowCount = 30
        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then 'HAY INTERFAZ CONTABLE
            Dim tdoc As String
            BuscarPeriodo()
            tdoc = "documentos" & PerActual(0) & PerActual(1)
            '************************************************
            For i = 0 To gfp.Rows.Count - 1
                grilla.RowCount = grilla.RowCount + 1
                MovimientoContable(i, "total", txtcuentatotal.Text, "VR. TOTAL " & gfp.Item("cual", i).Value & " " & Trim(txtcliente.Text), "")
            Next
            '**************
            'grilla.RowCount = grilla.RowCount + 1
            'MovimientoContable(0, "total", txtcuentatotal.Text, "VR. TOTAL " & Trim(txtcliente.Text))
            grilla.RowCount = grilla.RowCount + 1
            ' MovimientoContable(0, "desc", txtcuentadesc.Text, "DESCUENTO " & valordes.Text & "% " & Trim(txtcliente.Text))
            MovimientoContable(0, "desc", txtcuentadesc.Text, "DESCUENTO " & Trim(txtcliente.Text), "")
            MovimientoContable(0, "rtf", txtctaretef.Text, "RETE FUENTE " & valor_rtfuente.Text & "% " & Trim(txtcliente.Text), "")
            MovimientoContable(0, "rtica", txtctarica.Text, "RETE ICA " & valor_rtica.Text & "% " & Trim(txtcliente.Text), "")
            MovimientoContable(0, "rtiva", txtctariva.Text, "RETE IVA " & valor_rtiva.Text & "% " & Trim(txtcliente.Text), "")
            MovimientoContable(0, "rtcre", txtctariva.Text, "RETE CREE " & valorretCree.Text & "% " & Trim(txtcliente.Text), "")
            For i = 0 To 2
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        grilla.RowCount = grilla.RowCount + 1
                        concep = i
                        MovimientoContable(0, "+", cbcuenta.Items.Item(i), cbconcepto.Items.Item(i), "")
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        grilla.RowCount = grilla.RowCount + 1
                        concep = i
                        MovimientoContable(0, "-", cbcuenta.Items.Item(i), cbconcepto.Items.Item(i), "")
                    End If
                Catch ex As Exception
                End Try
            Next
            Dim nit As String = ""
            For i = 0 To gfactura.RowCount - 1
                Try
                    nit = gfactura.Item("nit", i).Value
                Catch ex As Exception
                    nit = ""
                End Try
                MovimientoContable(i, "ing", gfactura.Item("ctaing", i).Value, Trim(txtcliente.Text), nit)
                MovimientoContable(i, "iva", gfactura.Item("ctaiva", i).Value, "IVA " & gfactura.Item("iva", i).Value & "% " & Trim(txtcliente.Text), "")
                If gfactura.Item("tipo", i).Value = "I" And rbafecta1.Checked = True Then 'TIPO I ^ AFECTA INVENTARIOS
                    MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, Trim(txtcliente.Text) & " A 1435 ", "")
                    MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, Trim(txtcliente.Text) & " A VENTAS ", "")
                End If
            Next i
            '********************************************************************
            Dim cad As String
            Dim db, cr As Double
            For i = 0 To grilla.RowCount - 1
                Try
                    Try
                        cad = grilla.Item("cuenta", i).Value.ToString
                    Catch ex As Exception
                        cad = ""
                    End Try
                    Try
                        db = grilla.Item("Debitos", i).Value
                    Catch ex As Exception
                        db = 0
                    End Try
                    Try
                        cr = grilla.Item("Creditos", i).Value
                    Catch ex As Exception
                        cr = 0
                    End Try
                    If cad <> "" And (db > 0 Or cr > 0) Then
                        InsertContabilidad(i, tdoc)
                    End If
                Catch ex As Exception
                    ' MsgBox(ex.ToString)
                End Try
            Next
        End If
    End Sub
    Dim concep As Integer = 0
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha.Value.Day.ToString)
            myCommand.Parameters.AddWithValue("?centro", Val(txtcentrocosto.Text))
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item("base", fila).Value))
            myCommand.Parameters.AddWithValue("?diasv", Val(txtvmto.Text))
            If Val(txtvmto.Text) > 0 Then
                Dim fec As Date = DateAdd("d", Val(txtvmto.Text), txtfecha.Value)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            Try
                If grilla.Item("nitc", fila).Value = "" Then
                    myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
                Else
                    myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
                '  myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            End Try
            Try
                myCommand.Parameters.AddWithValue("?cheque", grilla.Item("cheque", fila).Value.ToString)
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?cheque", "")
            End Try
            myCommand.Parameters.AddWithValue("?modulo", "facturacion")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String, ByVal nit As String)
        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des As String
        Dim desc, b2 As Double
        sw = 0
        For j = 0 To grilla.RowCount - 1
            k = j
            Try
                cad = grilla.Item("cuenta", j).Value.ToString
            Catch ex As Exception
                cad = ""
            End Try
            Try
                des = grilla.Item("Descripcion", j).Value.ToString
            Catch ex As Exception
                des = ""
            End Try
            '***************************
            If cad = "" And des = "" Then
                grilla.Item("cuenta", j).Value = cuenta
                grilla.Item("Descripcion", j).Value = descrip
                grilla.Item("nitc", j).Value = nit
                sw = 1
                Exit For
            ElseIf cad = cuenta Then
                If des = descrip Then
                    sw = 1
                    Exit For
                End If
            End If
        Next j
        j = k
        If sw = 0 Then
            grilla.RowCount = grilla.RowCount + 1
            grilla.Item("cuenta", k).Value = cuenta
            grilla.Item("Descripcion", k).Value = descrip
            grilla.Item("nitc", k).Value = nit
            grilla.Item("base", k).Value = "0"
            grilla.RowCount = grilla.RowCount + 1
        End If
        Dim db, cr, base, monto, iva As Double
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
        Try
            base = grilla.Item("base", j).Value
        Catch ex As Exception
            base = 0
        End Try
        Dim rtf, rtica, rtiva As Double
        rtf = 0
        rtica = 0
        rtiva = 0
        Select Case tipo
            Case "ing"
                Try
                    base = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                ' monto = base
                Try
                    desc = base * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                monto = base - desc
                'Try
                '    iva = CDbl(gfactura.Item("Vtotal", fo).Value) - (CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100)))
                '    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                'Catch ex As Exception
                '    iva = 0
                'End Try
                'monto = CDbl(gfactura.Item("Vtotal", fo).Value) - iva
                Try
                    rtf = monto * CDec(valor_rtfuente.Text) / 100
                    rtf = Format(Math.Round(CDbl(rtf), 2), "0.00")
                Catch ex As Exception
                    rtf = 0
                End Try
                Try
                    rtica = monto * CDec(valor_rtica.Text) / 100
                    rtica = Format(Math.Round(CDbl(rtica), 2), "0.00")
                Catch ex As Exception
                    rtica = 0
                End Try
                Try
                    'rtiva = CDbl(gfactura.Item("Vtotal", fo).Value) - (CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(valor_rtiva.Text) / 100)))
                    rtiva = monto * CDec(valor_rtiva.Text) / 100
                    rtiva = Format(Math.Round(CDbl(rtiva), 2), "0.00")
                Catch ex As Exception
                    rtiva = 0
                End Try
                'monto= monto - impuestos
                monto = monto '- rtf - rtica - rtiva
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                'MsgBox("monto=" & CDbl(gfactura.Item("Vtotal", fo).Value) & " - " & iva & " - " & rtf & " - " & rtica & " - " & rtiva)
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "iva"
                Try 'base sin descuento
                    b2 = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                Try
                    desc = b2 * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    desc = b2 * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                ' b2 = b2 - desc
                Try
                    base = base + b2 - desc 'base acomulada + nueva base
                Catch ex As Exception
                End Try
                Try
                    'iva = CDbl(gfactura("Vtotal", fo).Value) * CDec(gfactura("iva", fo).Value) / 100
                    iva = b2 * (CDec(gfactura.Item("iva", fo).Value) / 100)
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = iva
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                grilla.Item("base", j).Value = base
            Case "rtf"
                monto = Format(Math.Round(CDbl(txtrtefuente.Text), 2), "0.00")
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "rtcre"
                monto = Format(Math.Round(CDbl(txtretCre.Text), 2), "0.00")
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "rtica"
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                monto = Format(Math.Round(CDbl(txtrica.Text), 2), "0.00")
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "rtiva"
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                monto = Format(Math.Round(CDbl(txtriva.Text), 2), "0.00")
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                grilla.Item("base", j).Value = base
            Case "inv"
                Try
                    monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                Catch ex As Exception
                    monto = 0
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "cventa"
                Try
                    monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                Catch ex As Exception
                    monto = 0
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "desc"
                ' monto = CDbl(lbdescuento.Text)
                monto = CDbl(txtdescuento.Text)
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "total"
                ' monto = CDbl(txttotal.Text)
                monto = gfp.Item("monto", j).Value
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                If gfp.Item("cual", j).Value = "Cheque" Then
                    grilla.Item("cheque", j).Value = gfp.Item("numero", j).Value
                Else
                    grilla.Item("cheque", j).Value = ""
                End If
            Case "+"
                monto = CDbl(cbvalor.Items.Item(concep))
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "-"
                monto = CDbl(cbvalor.Items.Item(concep))
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
        End Select
    End Sub
    Public Sub GuardarCOBDPEN()
        Try
            If gfp.Item("cual", 0).Value <> "Otra" Then Exit Sub
            Dim cad As String = txtcuentatotal.Text
            If cad(0) & cad(1) <> "13" Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Las cuenta (" & txtcuentatotal.Text & ") no pertenece a Cuentas por Pagar, ¿Desea Generar un Documento De Cuentas por Pagar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.No Then Exit Sub
            End If
            ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR TABLA COBDPEN'''''''''''''''''''''''''''''''
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
            myCommand.Parameters.AddWithValue("?descrip", "")
            myCommand.Parameters.AddWithValue("?tipafec", "")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.Parameters.AddWithValue("?nomnit", txtcliente.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitcod", "")
            myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text))
            'dias de vmto
            myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
            myCommand.Parameters.AddWithValue("?concepto", CambiaCadena(gfactura.Item("descrip", 0).Value, 99))
            'subtotal
            myCommand.Parameters.AddWithValue("?subtotal", DIN(txtsubtotal.Text))
            'descuento
            myCommand.Parameters.AddWithValue("?descto", DIN(txtdescuento.Text))
            ' myCommand.Parameters.AddWithValue("?descto", DIN(lbdescuento.Text))
            'rete_fuente
            myCommand.Parameters.AddWithValue("?ret", "0")
            'iva
            myCommand.Parameters.AddWithValue("?iva", DIN(valoriva.Text))
            myCommand.Parameters.AddWithValue("?v_iva", DIN(txtiva.Text))
            'total
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            'cuentas
            myCommand.Parameters.AddWithValue("?ctasubtotal", "")
            myCommand.Parameters.AddWithValue("?ctaret", "")
            myCommand.Parameters.AddWithValue("?ctaiva", txtcuentaiva.Text)
            myCommand.Parameters.AddWithValue("?ctatotal", txtcuentatotal.Text)
            'ccosto
            myCommand.Parameters.AddWithValue("?ccosto", Val(txtcentrocosto.Text))
            myCommand.Parameters.AddWithValue("?otroimp", "N")
            'rete_iva
            myCommand.Parameters.AddWithValue("?retiva", "0")
            myCommand.Parameters.AddWithValue("?ctaretiva", "")
            'ret_ica
            myCommand.Parameters.AddWithValue("?retica", "0")
            myCommand.Parameters.AddWithValue("?ctaretica", "")
            'pagado
            myCommand.Parameters.AddWithValue("?pagado", "0")
            'pos
            myCommand.Parameters.AddWithValue("?rcpos", "")
            myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
            myCommand.Parameters.AddWithValue("?vpos", "0")
            'tasa
            myCommand.Parameters.AddWithValue("?tasa", "0")
            'Moneda2
            myCommand.Parameters.AddWithValue("?Moneda2", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            'estado
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", "")
            'INSERTAR COBDPEN
            myCommand.CommandText = "INSERT INTO cobdpen VALUES (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto," _
                                  & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                                  & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?Moneda2,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarMoviInvetarios(ByVal total As Double)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha.Value.Day.ToString)
            myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            If txttipo.Text <> lbdocajuste.Text Then
                myCommand.Parameters.AddWithValue("?tipo_mov", "S")
                myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
                myCommand.Parameters.AddWithValue("?tipo_sal", "SALIDA POR FACTURA")
            Else
                myCommand.Parameters.AddWithValue("?tipo_mov", "A")
                myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
                myCommand.Parameters.AddWithValue("?tipo_sal", "AJUSTE DE FACTURA")
            End If
            myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", "")
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", DIN(total))
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?tipo_sal,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item(1, i).Value <> "" And gfactura.Item("tipo", i).Value = "I" Then
                    GuardarDetallesInv(i)
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetallesInv(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", fila).Value)
            myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("descrip", fila).Value)
            If txttipo.Text <> lbdocajuste.Text Then
                Try
                    myCommand.Parameters.AddWithValue("?bod_ori", Val(gfactura.Item("bodega", fila).Value))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?bod_ori", "0")
                End Try
                myCommand.Parameters.AddWithValue("?bod_des", "0")
            Else
                myCommand.Parameters.AddWithValue("?bod_ori", "0")
                Try
                    myCommand.Parameters.AddWithValue("?bod_des", Val(gfactura.Item("bodega", fila).Value))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?bod_des", "0")
                End Try
            End If
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            Try
                myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?valor", "0")
            End Try
            '**********************************************************
            myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_ing", gfactura.Item("ctaing", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
            Try
                myCommand.Parameters.AddWithValue("?costo", DIN(gfactura.Item("costo", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
            & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ValidarConsecutivo()
        Try
            If txttipo.Text <> lbdocajuste.Text Then
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4,a_f1,a_f2,a_f3,a_f4 FROM parafacgral;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                If tabla.Rows(0).Item("tipof1") = txttipo.Text Then
                    ActualizarConsecutivo("a_f1")
                ElseIf tabla.Rows(0).Item("tipof2") = txttipo.Text Then
                    ActualizarConsecutivo("a_f2")
                ElseIf tabla.Rows(0).Item("tipof3") = txttipo.Text Then
                    ActualizarConsecutivo("a_f3")
                ElseIf tabla.Rows(0).Item("tipof4") = txttipo.Text Then
                    ActualizarConsecutivo("a_f4")
                End If
            Else
                ActualizarConsecutivo("")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarConsecutivo(ByVal campo As String)
        Dim tabla As New DataTable
        If txttipo.Text <> lbdocajuste.Text Then
            myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        Else
            myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Try
            If txttipo.Text <> lbdocajuste.Text Then
                If Val(tabla.Rows(0).Item("actualfc").ToString) < Val(txtnumfac.Text) Then
                    myCommand.CommandText = "UPDATE parafacgral SET " & campo & "=" & Val(txtnumfac.Text) & ";"
                    myCommand.ExecuteNonQuery()
                    myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                    myCommand.ExecuteNonQuery()
                End If
            Else
                If Val(tabla.Rows(0).Item(0).ToString) < Val(txtnumfac.Text) Then
                    myCommand.CommandText = "UPDATE tipdoc SET actual" & PerActual(0) & PerActual(1) & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                    myCommand.ExecuteNonQuery()
                End If
            End If

        Catch ex As Exception
            If txttipo.Text <> lbdocajuste.Text Then
                myCommand.CommandText = "UPDATE parafacgral SET " & campo & "=" & Val(txtnumfac.Text) & ";"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.CommandText = "UPDATE tipdoc SET actual" & PerActual(0) & PerActual(1) & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End If
        End Try
    End Sub
    '/////////// MODIFICAR //////////////////////////////////////////////
    Public Sub ValidarModificar()
        CalcularTotales()
        If txttipo2.Text = "" Then
            MsgBox("No ha escogido el tipo de factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txttipo.Focus()
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtvendedor.Text = "" Then
            MsgBox("No ha digitado datos del vendedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitv.Focus()
            Exit Sub
            'ElseIf lbdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            '    MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            '    txtcuentadesc.Focus()
            '    Exit Sub
        ElseIf txtdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
            Exit Sub
        ElseIf valor_rtfuente.Text <> "0,00" And txtctaretef.Text = "" Then
            MsgBox("No ha escojido cuenta para la Rete Fuente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctaretef.Focus()
            Exit Sub
        ElseIf valor_rtica.Text <> "0,00" And txtctarica.Text = "" Then
            MsgBox("No ha escojido cuenta para el Rete I.C.A, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctarica.Focus()
            Exit Sub
        ElseIf valor_rtiva.Text <> "0,00" And txtctariva.Text = "" Then
            MsgBox("No ha escojido cuenta para el Rete I.V.A, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtctariva.Focus()
            Exit Sub
        ElseIf CDbl(txttotal.Text) <= 0 And CDbl(lbvalor.Text) = 0 Then
            MsgBox("El total a pagar deber mayor que cero (0), Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf txtcuentatotal.Text = "" And txtcuentatotal.Enabled = True Then
            MsgBox("No ha escojido forma de pago o la cuenta, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmdfpago.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf cmbTipoAF.Enabled = True And cmbTipoAF.Text = "Seleccione..." Then
            MsgBox("No ha escogido el Tipo de Ajuste para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmbTipoAF.Focus()
            Exit Sub
        End If
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value)
        Next
        If sumafp <> Moneda2(txttotal.Text) Or gfp.Item("cual", 0).Value = "" Then
            MsgBox("Verifique la forma de pago.", MsgBoxStyle.Information, "Control Factura ")
            cdmfpago_Click(AcceptButton, AcceptButton)
            Exit Sub
        End If
        If PerActual <> Format(txtfecha.Value, "MM/yyyy") Then
            MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
            If txtfecha.Enabled = True Then
                txtfecha.Focus()
            End If
            Exit Sub
        End If
        Dim ap As String = ""
        ap = Frmfacturarapida.par_guar()
        If ap = "S" Then
            If cbaprobado.Text <> "AP" Then
                MsgBox("No se puede guardar la Factura si no esta Aprobada", MsgBoxStyle.Exclamation, "Verifique")
                Exit Sub
            End If
        End If

        'PARAMETRO LISTAR ARTIC CON EXISTENCIA PARA VALIDAR CANTI
        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows(0).Item(0) = "SI" Then
            '...VALIDAR CANTIDAD DISPONIBLE ...
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("codigo", i).Value <> "" Then
                    If cbaprobado.Text = "AP" Then
                        If ValidarCantidades(i) = False Then
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If

        '''''' VALIDAR SI EXIXTE FACTURA PARA CREAR O MODIFICAR'''''''''''''''''
        Dim t As New DataTable
        myCommand.CommandText = "SELECT doc FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        Refresh()
        If t.Rows.Count < 1 Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("La factura (" & txttipo.Text & txtnumfac.Text & ") No Existe en los registros, ¿Desea Guardarla?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                validarcuentas()
                GuardarFactura()
            End If
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la factura (" & txttipo.Text & txtnumfac.Text & ") se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                validarcuentas()
                ModificarFactura()
            End If
        End If
    End Sub
    Private Sub AuditarMovFac()
        Try


            Dim camp As String = ""
            Dim ant As String = ""
            Dim nue As String = ""

            lbespera.Visible = True

            If txtnitc.Text <> txtnitc2.Text Then
                camp = camp & "CLIENTE; "
                ant = ant & txtnitc2.Text & "; "
                nue = nue & txtnitc.Text & "; "
            End If
            If txtnitv.Text <> txtnitv2.Text Then
                camp = camp & "VENDEDOR;"
                ant = ant & txtnitv2.Text & "; "
                nue = nue & txtnitv.Text & "; "
            End If
            If cbaprobado.Text <> cbaprobado2.Text Then
                camp = camp & "ESTADO;"
                ant = ant & cbaprobado2.Text & "; "
                nue = nue & cbaprobado.Text & "; "
            End If
            If txtvmto.Text <> txtvmto2.Text Then
                camp = camp & "DIAS DE VENCIMIENTO;"
                ant = ant & txtvmto2.Text & "; "
                nue = nue & txtvmto.Text & "; "
            End If
            If txtcentro.Text <> txtcentro2.Text Then
                camp = camp & "CENTRO DE COSTO; "
                ant = ant & txtcentro2.Text & "; "
                nue = nue & txtcentro.Text & "; "
            End If
            If txttotal.Text <> txttotal2.Text Then
                camp = camp & "VALOR FACT; "
                ant = ant & txttotal2.Text & "; "
                nue = nue & txttotal.Text & "; "
            End If
            If txtobserbaciones.Text <> txtobserbaciones2.Text Then
                camp = camp & "OBSERVACION; "
                ant = ant & txtobserbaciones2.Text & "; "
                nue = nue & txtobserbaciones.Text & "; "
            End If

            ' No de Items
            Dim ok = ""
            For i = 0 To gfactura2.RowCount - 1
                For j = 0 To gfactura.RowCount - 1
                    If gfactura2.Item("codigo2", i).Value <> "" Then
                        If gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value Then
                            ok = "e"
                            Exit For
                        End If
                    End If
                Next
                If gfactura2.Item("codigo2", i).Value <> "" Then
                    If ok <> "e" Then
                        camp = camp & "ELIMINADO ITEM COD: " & gfactura2.Item("codigo2", i).Value & "; "
                        ant = ant & " ;"
                        nue = nue & " ;"
                    End If
                    ok = ""
                End If
            Next

            ok = ""
            For j = 0 To gfactura.RowCount - 1
                For i = 0 To gfactura2.RowCount - 1
                    If gfactura.Item("codigo", j).Value <> "" Then
                        If gfactura.Item("codigo", j).Value = gfactura2.Item("codigo2", i).Value Then
                            ok = "e"
                            Exit For
                        End If
                    End If
                Next
                If gfactura.Item("codigo", j).Value <> "" Then
                    If ok <> "e" Then
                        camp = camp & "NUEVO ITEM COD: " & gfactura.Item("codigo", j).Value & "; "
                        ant = ant & " ;"
                        nue = nue & " ;"
                    End If
                    ok = ""
                End If
            Next

            ' Validar datos articulos
            For i = 0 To gfactura2.RowCount - 1
                For j = 0 To gfactura.RowCount - 1
                    If gfactura2.Item("codigo2", i).Value <> "" Then
                        If gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value Then
                            If gfactura2.Item("cant2", i).Value <> gfactura.Item("cant", j).Value Then
                                camp = camp & "CANTIDAD; "
                                ant = ant & gfactura2.Item("cant2", i).Value & ";"
                                nue = nue & gfactura.Item("cant", i).Value & ";"
                            End If
                            If gfactura2.Item("valor2", i).Value <> gfactura.Item("valor", j).Value Then
                                camp = camp & "VALOR; "
                                ant = ant & gfactura2.Item("valor2", i).Value & ";"
                                nue = nue & gfactura.Item("valor", i).Value & ";"
                            End If
                            If CDbl(gfactura2.Item("descuento2", i).Value) <> CDbl(gfactura.Item("descuento", j).Value) Then
                                camp = camp & "DESCUENTO; "
                                ant = ant & gfactura2.Item("descuento2", i).Value & ";"
                                nue = nue & gfactura.Item("descuento", i).Value & ";"
                            End If
                            If gfactura2.Item("nit2", i).Value <> gfactura.Item("nit", j).Value Then
                                camp = camp & "NIT; "
                                ant = ant & gfactura2.Item("nit2", i).Value & ";"
                                nue = nue & gfactura.Item("nit", i).Value & ";"
                            End If
                            Exit For
                        End If
                    End If
                Next
            Next
            Guar_MovUser("FACTURACION", "MODIFICAR FACTURA Nº: " & txttipo.Text & txtnumfac.Text, camp, ant, nue)
            lbespera.Visible = False
        Catch ex As Exception
            lbespera.Visible = False
            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ModificarFactura()
        '//////////////////////////////////////////////////////
        Dim afecta As String
        txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(txtdescuento.Text)
        ' txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(lbdescuento.Text)
        If rbafecta1.Checked = True Then
            afecta = "SI"  'SI afecta inventario
        Else
            afecta = "NO"  'NO afecta inventario
        End If
        Timer1.Enabled = False
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text.ToString)
        myCommand.Parameters.AddWithValue("?doc_de", "I")
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
        myCommand.Parameters.AddWithValue("?usuario", lbusuario.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text))
        myCommand.Parameters.AddWithValue("?hora", CDate(lbhora.Text))
        myCommand.Parameters.AddWithValue("?descrip", " ")
        myCommand.Parameters.AddWithValue("?doc_afec", " ")
        myCommand.Parameters.AddWithValue("?afecta", afecta)
        'subtotal
        myCommand.Parameters.AddWithValue("?subtotal", DIN(txtsubtotal.Text))
        '****descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        ' myCommand.Parameters.AddWithValue("?descuento", DIN(lbdescuento.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(txtdescuento.Text))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_ret_f", DIN(valor_rtfuente.Text))
        myCommand.Parameters.AddWithValue("?ret_f", DIN(txtrtefuente.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_f", txtctaretef.Text)
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(txtiva.Text))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'rete_iva
        myCommand.Parameters.AddWithValue("?por_ret_iva", DIN(valor_rtiva.Text))
        myCommand.Parameters.AddWithValue("?ret_iva", DIN(txtriva.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_iva", txtctariva.Text)
        'ret_ica
        myCommand.Parameters.AddWithValue("?por_ret_ica", DIN(valor_rtica.Text))
        myCommand.Parameters.AddWithValue("?ret_ica", DIN(txtrica.Text))
        myCommand.Parameters.AddWithValue("?cta_ret_ica", txtctarica.Text)
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", DIN(valorretCree.Text))
        myCommand.Parameters.AddWithValue("?rtc", DIN(txtretCre.Text))
        myCommand.Parameters.AddWithValue("?cta_rtc", txtcuentaCree.Text)
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'datos de entega
        myCommand.Parameters.AddWithValue("?entregar", CambiaCadena(lbentrega.Text, 60))
        myCommand.Parameters.AddWithValue("?dir_ent", CambiaCadena(lbdir.Text, 60))
        myCommand.Parameters.AddWithValue("?ciu_ent", CambiaCadena(lbciudad.Text, 30))
        myCommand.Parameters.AddWithValue("?o_compra", CambiaCadena(lborden.Text, 15))
        myCommand.Parameters.AddWithValue("?fecha_o", CambiaCadena(lbfecha.Text, 60))
        myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
        ' VALOR AAF
        If (txttipo.Text = lbdocajuste.Text) And (txtdocafec.Text <> "") And (gfp.Item("detalle", 0).Value.ToString = "CREDITO") Then
            myCommand.Parameters.AddWithValue("?val_aj", DIN(txttotal.Text))
        Else
            myCommand.Parameters.AddWithValue("?val_aj", DIN(0))
        End If
        'OTROS CONCEPTOS
        If cbsr.Items.Count = 0 Then
            myCommand.Parameters.AddWithValue("?o_con", "no")
        Else
            myCommand.Parameters.AddWithValue("?o_con", "si")
        End If
        myCommand.Parameters.AddWithValue("?t1", "")
        myCommand.Parameters.AddWithValue("?d1", "")
        myCommand.Parameters.AddWithValue("?v1", DIN(0))
        myCommand.Parameters.AddWithValue("?b1", DIN(0))
        myCommand.Parameters.AddWithValue("?cta1", "")
        myCommand.Parameters.AddWithValue("?doc1", "")
        myCommand.Parameters.AddWithValue("?t2", "")
        myCommand.Parameters.AddWithValue("?d2", "")
        myCommand.Parameters.AddWithValue("?v2", DIN(0))
        myCommand.Parameters.AddWithValue("?b2", DIN(0))
        myCommand.Parameters.AddWithValue("?cta2", "")
        myCommand.Parameters.AddWithValue("?doc2", "")
        myCommand.Parameters.AddWithValue("?t3", "")
        myCommand.Parameters.AddWithValue("?d3", "")
        myCommand.Parameters.AddWithValue("?v3", DIN(0))
        myCommand.Parameters.AddWithValue("?b3", DIN(0))
        myCommand.Parameters.AddWithValue("?cta3", "")
        myCommand.Parameters.AddWithValue("?doc3", "")
        ''otros conceptos
        'For i = 0 To 2
        '    If i = 0 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?o_con", "si")
        '                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v1", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta1", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc1", lbanti1.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?o_con", "no")
        '                myCommand.Parameters.AddWithValue("?t1", "")
        '                myCommand.Parameters.AddWithValue("?d1", "")
        '                myCommand.Parameters.AddWithValue("?v1", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta1", "")
        '                myCommand.Parameters.AddWithValue("?doc1", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?o_con", "no")
        '            myCommand.Parameters.AddWithValue("?t1", "")
        '            myCommand.Parameters.AddWithValue("?d1", "")
        '            myCommand.Parameters.AddWithValue("?v1", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta1", "")
        '            myCommand.Parameters.AddWithValue("?doc1", "")
        '        End Try
        '    ElseIf i = 1 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?t2", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d2", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v2", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta2", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc2", lbanti2.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?t2", "")
        '                myCommand.Parameters.AddWithValue("?d2", "")
        '                myCommand.Parameters.AddWithValue("?v2", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta2", "")
        '                myCommand.Parameters.AddWithValue("?doc2", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?t2", "")
        '            myCommand.Parameters.AddWithValue("?d2", "")
        '            myCommand.Parameters.AddWithValue("?v2", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta2", "")
        '            myCommand.Parameters.AddWithValue("?doc2", "")
        '        End Try
        '    Else
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?t3", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d3", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v3", DIN(cbvalor.Items.Item(i)))
        '                myCommand.Parameters.AddWithValue("?cta3", cbcuenta.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?doc3", lbanti1.Text)
        '            Else
        '                myCommand.Parameters.AddWithValue("?t3", "")
        '                myCommand.Parameters.AddWithValue("?d3", "")
        '                myCommand.Parameters.AddWithValue("?v3", DIN(0))
        '                myCommand.Parameters.AddWithValue("?cta3", "")
        '                myCommand.Parameters.AddWithValue("?doc3", "")
        '            End If
        '        Catch ex As Exception
        '            myCommand.Parameters.AddWithValue("?t3", "")
        '            myCommand.Parameters.AddWithValue("?d3", "")
        '            myCommand.Parameters.AddWithValue("?v3", DIN(0))
        '            myCommand.Parameters.AddWithValue("?cta3", "")
        '            myCommand.Parameters.AddWithValue("?doc3", "")
        '        End Try
        '    End If
        'Next
        'EDITAR FACTURA
        myCommand.CommandText = "UPDATE facturas" & PerActual(0) & PerActual(1) & " SET tipodoc=?tipodoc,doc_de=?doc_de,nitc=?nitc,nitv=?nitv,usuario=?usuario,fecha=?fecha,hora=?hora,descrip=?descrip,doc_afec=?doc_afec,afecta=?afecta," _
                              & "subtotal=?subtotal,por_desc=?por_desc,descuento=?descuento,cta_desc=?cta_desc,por_ret_f=?por_ret_f,ret_f=?ret_f,cta_ret_f=?cta_ret_f,por_iva=?por_iva,iva=?iva,cta_iva=?cta_iva," _
                              & "por_ret_iva=?por_ret_iva,ret_iva=?ret_iva,cta_ret_iva=?cta_ret_iva,por_ret_ica=?por_ret_ica,ret_ica=?ret_ica,cta_ret_ica=?cta_ret_ica," _
                              & "total=?total,cta_total=?cta_total,estado=?estado,observ=?observ,vmto=?vmto,entregar=?entregar,dir_ent=?dir_ent,ciu_ent=?ciu_ent,o_compra=?o_compra,fecha_o=?fecha_o,cc=?cc, " _
                              & "o_con=?o_con,t1=?t1,d1=?d1,v1=?v1,cta1=?cta1,t2=?t2,d2=?d2,v2=?v2,cta2=?cta2,t3=?t3,d3=?d3,v3=?v3,cta3=?cta3,doc1=?doc1,doc2=?doc2,doc3=?doc3, " _
                              & " valor_aj=?val_aj,por_rtc=?por_rtc,rtc=?rtc,cta_rtc=?cta_rtc WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        '///////////////////////////////////////////////////////////////
        Insertar("DELETE FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';")
        Insertar("DELETE FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';")
        Dim sw As Integer = 0
        Dim total_inv, subt As Double
        total_inv = 0
        If cbaprobado.Text = "AP" Then GuardarAnticipos()
        For i = 0 To gfactura.RowCount - 1
            If gfactura.Item("codigo", i).Value <> "" Then
                GuardarDetalles(i)
                If rbafecta1.Checked = True And cbaprobado.Text = "AP" Then 'AFECTA INVENTARIOS
                    If gfactura.Item("tipo", i).Value = "I" Then ' hay movimientos de inventarios
                        GuardarEnBodega(i)
                        sw = 1
                        Try
                            subt = CDbl(gfactura.Item("Vtotal", i).Value)
                        Catch ex As Exception
                            subt = 0
                        End Try
                        total_inv = total_inv + subt
                    End If
                End If
            End If
        Next
        For i = 0 To gfp.RowCount - 1 'FORMAS DE PAGO
            If gfp.Item(0, i).Value <> "" Then
                GuardarPagos(i)
            End If
        Next
        If cbaprobado.Text = "AP" Then 'documentio contable
            GuardarContable()
            GuardarCOBDPEN() 'CUENTAS POR COBRAR
            If sw = 1 And rbafecta1.Checked = True Then GuardarMoviInvetarios(total_inv) 'si hay movi de inventarios y si afecta inventarios
        End If
        '.....
        'If cbsr.Items.Count <> 0 Then
        GuardarOtrosConcep()
        'End If
        '.....AUDITORIA USUARIO ...
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            AuditarMovFac()
        End If
        '............

        bloquear()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        lbestado.Text = "EDITADO"
        cmditems.Enabled = False
        cbaprobado.Enabled = False
    End Sub
    '************ BUSCAR ****************************************************
    Public Sub BuscarNumero()
        'Try
        Dim tabla As New DataTable
        Dim item As Integer
        If txttipo.Text <> lbdocajuste.Text Then
            myCommand.CommandText = "SELECT actualfc FROM tipdoc where tipodoc='" & txttipo.Text & "';"
        Else
            myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc where tipodoc='" & txttipo.Text & "';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        item = tabla.Rows(0).Item(0)
        If item = 0 Then
            If txttipo.Text <> lbdocajuste.Text Then
                PrimeraFactura()
            Else
                txtnumfac.Text = NumeroDoc(1)
            End If
        Else
            txtnumfac.Text = NumeroDoc(item + 1)
            Exit Sub
        End If
        'Catch ex As Exception
        '    If txttipo.Text <> lbdocajuste.Text Then
        '        PrimeraFactura()
        '    Else
        '        txtnumfac.Text = NumeroDoc(1)
        '    End If
        'End Try
    End Sub
    Public Sub PrimeraFactura()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT tipof1,a_f1,tipof2,a_f2,tipof3,a_f3,tipof4,a_f4 FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Select Case txttipo.Text
                Case tabla.Rows(0).Item("tipof1")
                    txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("a_f1") + 1)
                Case tabla.Rows(0).Item("tipof2")
                    txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("a_f2") + 1)
                Case tabla.Rows(0).Item("tipof3")
                    txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("a_f3") + 1)
                Case tabla.Rows(0).Item("tipof4")
                    txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("a_f4") + 1)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarFactura(ByVal numero As String)
        Timer1.Enabled = False
        PonerEnCero()
        BuscarPeriodo()
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT f. * , d. *   " _
                               & "FROM facturas" & PerActual(0) & PerActual(1) & " f " _
                               & "LEFT JOIN (detafac" & PerActual(0) & PerActual(1) & " d) " _
                               & "ON f.doc = d.doc " _
                               & "WHERE f.doc = '" & numero _
                               & "' ORDER BY d.item;"
        'myCommand.CommandText = "SELECT f. * , d. * , (a.precio +(a.precio * (a.iva/100))) as pre " _
        '                    & "FROM articulos a, facturas" & PerActual(0) & PerActual(1) & " f " _
        '                    & "LEFT JOIN (detafac" & PerActual(0) & PerActual(1) & " d) " _
        '                    & "ON f.doc = d.doc " _
        '                    & "WHERE f.doc = '" & numero _
        '                    & "' AND a.codart= d.codart ORDER BY d.item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("La factura no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If

        If Strings.Left(tabla.Rows(0).Item("descrip"), 7) = "ANULADO" Then
            lbAnula.Text = Strings.Left(tabla.Rows(0).Item("descrip"), 7)
        Else
            lbAnula.Text = ""
        End If

        txtsubtotal.Text = "0"
        txttotal.Text = "0"
        txtdescuento.Text = "0"
        lbdescuento.Text = "0"
        txtiva.Text = "0"
        txttipo.Text = tabla.Rows(0).Item("tipodoc")
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)  'para buscar
        txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num"))
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        txtnitc_LostFocus(AcceptButton, AcceptButton) 'para buscar cliente
        txtnitv.Text = tabla.Rows(0).Item("nitv")
        txtnitv_LostFocus(AcceptButton, AcceptButton) 'para buscar vendedor
        lbusuario.Text = tabla.Rows(0).Item("usuario")
        txtfecha.Text = tabla.Rows(0).Item("fecha").ToString
        lbhora.Text = tabla.Rows(0).Item("hora").ToString
        txtsubtotal.Text = Moneda2(tabla.Rows(0).Item("subtotal"))
        'descuento
        valordes.Text = tabla.Rows(0).Item("por_desc")
        txtdescuento.Text = tabla.Rows(0).Item("descuento")
        'lbdescuento.Text = Moneda2(tabla.Rows(0).Item("descuento"))
        txtcuentadesc.Text = tabla.Rows(0).Item("cta_desc")
        'RETE FUENTE
        Try
            valor_rtfuente.Text = tabla.Rows(0).Item("por_ret_f")
            txtrtefuente.Text = tabla.Rows(0).Item("ret_f")
            txtctaretef.Text = tabla.Rows(0).Item("cta_ret_f")
        Catch ex As Exception
        End Try
        'RETE CREE
        Try
            valorretCree.Text = tabla.Rows(0).Item("por_rtc")
            txtretCre.Text = tabla.Rows(0).Item("rtc")
            txtcuentaCree.Text = tabla.Rows(0).Item("cta_rtc")
        Catch ex As Exception
        End Try
        'RETE ica
        Try
            valor_rtica.Text = tabla.Rows(0).Item("por_ret_ica")
            txtrica.Text = tabla.Rows(0).Item("ret_ica")
            txtctarica.Text = tabla.Rows(0).Item("cta_ret_ica")
        Catch ex As Exception
        End Try
        'RETE iva
        Try
            valor_rtiva.Text = tabla.Rows(0).Item("por_ret_iva")
            txtriva.Text = tabla.Rows(0).Item("ret_iva")
            txtctariva.Text = tabla.Rows(0).Item("cta_ret_iva")
        Catch ex As Exception
        End Try
        Try
            lbanti1.Text = tabla.Rows(0).Item("doc1").ToString
            lbanti2.Text = tabla.Rows(0).Item("doc2").ToString
            lbanti3.Text = tabla.Rows(0).Item("doc3").ToString
        Catch ex As Exception

        End Try
        'iva
        valoriva.Text = tabla.Rows(0).Item("por_iva")
        txtiva.Text = tabla.Rows(0).Item("iva")
        txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
        'total
        txttotal.Text = tabla.Rows(0).Item("total")
        txtcuentatotal.Text = tabla.Rows(0).Item("cta_total")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        txtobserbaciones.Text = tabla.Rows(0).Item("observ")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        lbentrega.Text = tabla.Rows(0).Item("entregar")
        lbdir.Text = tabla.Rows(0).Item("dir_ent")
        lbciudad.Text = tabla.Rows(0).Item("ciu_ent")
        lborden.Text = tabla.Rows(0).Item("o_compra")
        lbfecha.Text = tabla.Rows(0).Item("fecha_o")
        '*********************************************************
        txtvmto.Text = tabla.Rows(0).Item("vmto")
        txtcentrocosto.Text = tabla.Rows(0).Item("cc")
        If txtcentrocosto.Text <> "0" Then
            BuscarCCs()
        Else
            txtcentro.Text = ""
        End If
        lbestado.Text = "CONSULTA"
        If Trim(tabla.Rows(0).Item("afecta")) = "SI" Then
            rbafecta1.Checked = True
        Else
            rbafecta2.Checked = True
        End If
        gfactura.RowCount = items + 1
        Dim suma As Double = 0
        Try
            Dim dct As Double = 0
            Dim base As Double = 0
            lbdescuento.Text = "0"
            For i = 0 To items - 1
                gfactura.Item(0, i).Value = tabla.Rows(i).Item("item")
                gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo_it")
                gfactura.Item(1, i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nomart")
                gfactura.Item("bodega", i).Value = tabla.Rows(i).Item("numbod")
                gfactura.Item(3, i).Value = Fraccion(tabla.Rows(i).Item("cantidad"))
                gfactura.Item(4, i).Value = tabla.Rows(i).Item("valor")
                gfactura.Item(5, i).Value = tabla.Rows(i).Item("vtotal")
                gfactura.Item("iva", i).Value = tabla.Rows(i).Item("iva_d")
                'descuento
                gfactura.Item("descuento", i).Value = Moneda2(tabla.Rows(i).Item("por_des"))
                Try
                    base = tabla.Rows(i).Item("vtotal") / (1 + (tabla.Rows(i).Item("iva_d") / 100))
                Catch ex As Exception
                    base = 0
                End Try
                Try
                    dct = dct + (base * tabla.Rows(i).Item("por_des") / 100)
                Catch ex As Exception
                End Try
                lbdescuento.Text = dct
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                gfactura.Item("cc", i).Value = tabla.Rows(i).Item("concep")
                gfactura.Item("nit", i).Value = tabla.Rows(i).Item("nit")
                gfactura.Item("precio2", i).Value = Moneda2(0)
                suma = suma + tabla.Rows(i).Item("vtotal")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try 'CONCEPTOS
            cbconcepto.Items.Clear()
            cbsr.Items.Clear()
            cbvalor.Items.Clear()
            cbcuenta.Items.Clear()
            cbbase.Items.Clear()
            cbldoc.Items.Clear()
            If Trim(tabla.Rows(0).Item("o_con")) = "si" Then

                'hay otros conceptos
                '////////////
                Dim toc As New DataTable
                myCommand.CommandText = "SELECT  *  " _
                              & "FROM otcon_fac" & PerActual(0) & PerActual(1) & "  " _
                              & " WHERE doc = '" & numero _
                              & "' ORDER BY item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(toc)
                Refresh()

                If toc.Rows.Count > 0 Then
                    For l = 0 To toc.Rows.Count - 1
                        cbsr.Items.Add(toc.Rows(l).Item("tipo"))
                        cbconcepto.Items.Add(toc.Rows(l).Item("descrip"))
                        cbvalor.Items.Add(Moneda2(toc.Rows(l).Item("valor")))
                        cbcuenta.Items.Add(toc.Rows(l).Item("cta"))
                        cbbase.Items.Add(toc.Rows(l).Item("base"))
                        cbldoc.Items.Add(toc.Rows(l).Item("doc_ant"))
                    Next
                End If
                Try
                    cbconcepto.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If

            'cbconcepto.Items.Clear()
            'cbsr.Items.Clear()
            'cbvalor.Items.Clear()
            'cbcuenta.Items.Clear()
            'If Trim(tabla.Rows(0).Item("o_con")) = "si" Then 'hay otros conceptos
            '    Dim tipo As String = ""
            '    For i = 1 To 3
            '        tipo = "t" & i 'tipo de concepto (1,2 o 3)
            '        If Trim(tabla.Rows(0).Item(tipo)) <> "" Then
            '            cbsr.Items.Add(tabla.Rows(0).Item(tipo))
            '            tipo = "d" & i 'descripcion (1,2 o 3)
            '            cbconcepto.Items.Add(tabla.Rows(0).Item(tipo))
            '            tipo = "v" & i 'valor (1,2 o 3)
            '            cbvalor.Items.Add(Moneda2(tabla.Rows(0).Item(tipo)))
            '            tipo = "cta" & i 'cuenta (1,2 o 3)
            '            cbcuenta.Items.Add(tabla.Rows(0).Item(tipo))
            '        End If
            '    Next
            '    Try
            '        cbconcepto.SelectedIndex = 0
            '    Catch ex As Exception
            '    End Try
            'End If
        Catch ex As Exception
        End Try
        FormasDePago(numero)
        bloquear()
        lbsubtotal.Text = suma
        cmditems.Enabled = False
        CalcularTotales()
    End Sub
    Public Sub FormasDePago(ByVal numero As String)
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc = '" & numero & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            gfp.RowCount = items
            For i = 0 To items - 1
                gfp.Item("cual", i).Value = tabla.Rows(i).Item("tipo").ToString
                gfp.Item("detalle", i).Value = tabla.Rows(i).Item("descrip").ToString
                gfp.Item("tt", i).Value = tabla.Rows(i).Item("tt").ToString
                gfp.Item("banco", i).Value = tabla.Rows(i).Item("banco").ToString
                gfp.Item("numero", i).Value = tabla.Rows(i).Item("numero").ToString
                gfp.Item("monto", i).Value = Moneda2(tabla.Rows(i).Item("valor"))
            Next
        End If
    End Sub
    ' /////////// FIN BARRA DE BOTONES FACTURA  ''''''''''''''''
    '///////////  DESPLAZAR REGISTROS    ///////////////////
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            'MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
            PonerEnCero()
            Exit Sub
        End If
        BuscarFactura(tabla.Rows(0).Item(0))
        lbnumero.Text = "1"
        bloquear()
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarFactura(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarFactura(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                cmdNuevo_Click(AcceptButton, AcceptButton)
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarFactura(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    ''//////////////// FIN DESPLAZAR REGISTROS  ///////////////////////////
    Private Sub Frmfacturarapida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''VERIFICAR SI USAN CENTRO DE COSTOS
        'Dim tabla As New DataTable
        'Try
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    If tabla.Rows(0).Item("ccosto") = "N" Then
        '        txtcentrocos.Items.Clear()
        '        Exit Try
        '    End If
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT * FROM  centrocostos WHERE nivel='centro';"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    txtcentrocos.Items.Clear()
        '    For i = 0 To tabla.Rows.Count - 1
        '        txtcentrocos.Items.Add(tabla.Rows(i).Item("centro"))
        '    Next
        'Catch ex As Exception
        '    txtcentrocos.Items.Clear()
        'End Try
        lbestado.Text = "NULO"
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub cdmfpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfpago.Click
        CeroFP()
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then
            FrmFormaPago.G1.Enabled = False
            FrmFormaPago.tabfp.Enabled = False
            FrmFormaPago.cmdcontinuar.Enabled = True
            FrmFormaPago.cmdcuenta.Enabled = False
            FrmFormaPago.txtcuenta.Enabled = False
            FrmFormaPago.txtpago.Enabled = False
            FrmFormaPago.txttotal.Enabled = False
            FrmFormaPago.txtcambio.Enabled = False
        Else
            FrmFormaPago.G1.Enabled = True
            FrmFormaPago.tabfp.Enabled = True
            FrmFormaPago.cmdcontinuar.Enabled = True
            FrmFormaPago.cmdcuenta.Enabled = True
            FrmFormaPago.txtcuenta.Enabled = True
            FrmFormaPago.txtpago.Enabled = True
            FrmFormaPago.txttotal.Enabled = True
            FrmFormaPago.txtcambio.Enabled = True
        End If
        FrmFormaPago.txtcuenta.Text = txtcuentatotal.Text
        FrmFormaPago.txtdias.Text = txtvmto.Text
        If gfp.RowCount = 1 Then
            FrmFormaPago.tabforma.Visible = True
            FrmFormaPago.tabvarias.Visible = False
            FrmFormaPago.txtpago.Text = txttotal.Text
            gfp.Item("monto", 0).Value = txttotal.Text
            FrmFormaPago.txttotal.Text = txttotal.Text
            FrmFormaPago.txtcambio.Text = "0,00"
            If gfp.Item("detalle", 0).Value = "" Then
                FrmFormaPago.lbfp.Text = "Pagar Con Efectivo"
            Else
                FrmFormaPago.lbfp.Text = "Pagar Con " & gfp.Item(0, 0).Value
                If gfp.Item(2, 0).Value = "Otra" Then

                End If
            End If
        Else
            VariasFP()
        End If
        FrmFormaPago.lbform.Text = "fn_sp"
        FrmFormaPago.ShowDialog()
    End Sub
    Public Sub VariasFP()
        FrmFormaPago.tabforma.Visible = False
        FrmFormaPago.tabvarias.Visible = True
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value)
            If gfp.Item("cual", i).Value = "Cheque" Then
                FrmFormaPago.txtnumcheque2.Text = gfp.Item("numero", i).Value
                FrmFormaPago.txtbanco2.Text = gfp.Item("banco", i).Value
                FrmFormaPago.txtvche.Text = gfp.Item("monto", i).Value
            ElseIf gfp.Item("cual", i).Value = "Tarjeta1" Then
                FrmFormaPago.txttar1.Text = gfp.Item("detalle", i).Value
                FrmFormaPago.cbtarj1.Text = gfp.Item("tt", i).Value
                FrmFormaPago.txtnumtar1.Text = gfp.Item("numero", i).Value
                FrmFormaPago.txtvt1.Text = gfp.Item("monto", i).Value
            ElseIf gfp.Item("cual", i).Value = "Tarjeta2" Then
                FrmFormaPago.txttar2.Text = gfp.Item("detalle", i).Value
                FrmFormaPago.cbtarj2.Text = gfp.Item("tt", i).Value
                FrmFormaPago.txtnumtar2.Text = gfp.Item("numero", i).Value
                FrmFormaPago.txtvt2.Text = gfp.Item("monto", i).Value
            ElseIf gfp.Item("cual", i).Value = "Tarjeta3" Then
                FrmFormaPago.txttar3.Text = gfp.Item("detalle", i).Value
                FrmFormaPago.cbtarj3.Text = gfp.Item("tt", i).Value
                FrmFormaPago.txtnumtar3.Text = gfp.Item("numero", i).Value
                FrmFormaPago.txtvt3.Text = gfp.Item("monto", i).Value
            ElseIf gfp.Item("cual", i).Value = "Efectivo" Then
                FrmFormaPago.txtvefec.Text = gfp.Item("monto", i).Value
            End If
            FrmFormaPago.txtpago.Text = sumafp
            FrmFormaPago.txtcuenta.Text = txtcuentatotal.Text
            FrmFormaPago.txttotal.Text = txttotal.Text
        Next
    End Sub
    Public Sub CeroFP()
        '***********************************
        FrmFormaPago.txtnumcheq.Text = ""
        FrmFormaPago.txtbanco.Text = ""
        FrmFormaPago.txttarjeta.Text = ""
        FrmFormaPago.cbtarj.Text = "DB"
        FrmFormaPago.txtnumtarjeta.Text = ""
        FrmFormaPago.txtespecifica.Text = ""
        FrmFormaPago.txtdias.Text = "0"
        '***********************************
        FrmFormaPago.txtnumcheque2.Text = ""
        FrmFormaPago.txtbanco2.Text = ""
        FrmFormaPago.txtvche.Text = "0,00"
        FrmFormaPago.txttar1.Text = ""
        FrmFormaPago.txtnumtar1.Text = ""
        FrmFormaPago.txtvt1.Text = "0,00"
        FrmFormaPago.txttar2.Text = ""
        FrmFormaPago.txtnumtar2.Text = ""
        FrmFormaPago.txtvt2.Text = "0,00"
        FrmFormaPago.txttar3.Text = ""
        FrmFormaPago.txtnumtar3.Text = ""
        FrmFormaPago.txtvt3.Text = "0,00"
        FrmFormaPago.txtvefec.Text = "0,00"
        '***********************************
        FrmFormaPago.txtcuenta.Text = ""
        FrmFormaPago.txtpago.Text = "0,00"
        FrmFormaPago.txttotal.Text = "0,00"
        FrmFormaPago.txtcambio.Text = "0,00"
    End Sub
    '************************************
    Private Sub cmdobservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdobservaciones.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmObsrvaciones.txtobservacion.Enabled = True
        Else
            FrmObsrvaciones.txtobservacion.Enabled = False
        End If
        FrmObsrvaciones.txtobservacion.Text = txtobserbaciones.Text
        FrmObsrvaciones.lbform.Text = "fn_sp"
        FrmObsrvaciones.ShowDialog()
    End Sub
    ''' //////////////// EVENTOS DE LAS CAJAS DE TEXTO CUENTAS  //////////////
    Private Sub txtcuentadesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentadesc.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcuentadesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentadesc.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_desc_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtctaretef_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaretef.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_rtf_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtctaretef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctaretef.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtctarica_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctarica.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_rtica_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtctarica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctarica.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtctariva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctariva.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_rtiva_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtctariva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctariva.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcuentaiva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaiva.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_iva_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentaiva.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcuentatotal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentatotal.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fn_total_sp"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentatotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentatotal.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub BuscarCuenta(ByVal txt As TextBox)
        'FrmCuentas.ShowDialog()
    End Sub
    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
        txttipo2.Text = tabla.Rows(0).Item(0)
        BuscarNumero()
        If lbestado.Text = "NUEVO" And txttipo.Text <> lbdocajuste.Text Then
            VeificarRDIAN(txttipo.Text, Val(txtnumfac.Text), txtfecha.Value)
        End If
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT formatfac,imp_dec FROM parafacts WHERE factura='NORMAL';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                lb_imp_dec.Text = Trim(tabla.Rows(0).Item("imp_dec"))
                If tabla.Rows(0).Item("formatfac") = "pdf" Then
                    generarPDFSupHierr()
                    'GenerarPDF()
                ElseIf tabla.Rows(0).Item("formatfac") = "pdf2" Then
                    NGenerarPDF()
                    'GenerarPDF2()
                Else
                    GenerarTICKET2()
                End If
            Catch ex As Exception
                GenerarPDF()
            End Try
        End If
    End Sub
    Private Sub cmdentrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdentrega.Click
        FrmDatosDeEntrega.txtentrega.Text = txtcliente.Text
        FrmDatosDeEntrega.txtdir.Text = lbdir.Text
        FrmDatosDeEntrega.txtciudad.Text = lbciudad.Text
        FrmDatosDeEntrega.txtorden.Text = lborden.Text
        Try
            FrmDatosDeEntrega.txtfecha.Value = lbfecha.Text
        Catch ex As Exception
            FrmDatosDeEntrega.txtfecha.Value = txtfecha.Value
        End Try
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmDatosDeEntrega.txtentrega.Enabled = True
            FrmDatosDeEntrega.txtdir.Enabled = True
            FrmDatosDeEntrega.txtciudad.Enabled = True
            FrmDatosDeEntrega.txtorden.Enabled = True
            FrmDatosDeEntrega.txtfecha.Enabled = True
        Else
            FrmDatosDeEntrega.txtentrega.Enabled = False
            FrmDatosDeEntrega.txtdir.Enabled = False
            FrmDatosDeEntrega.txtciudad.Enabled = False
            FrmDatosDeEntrega.txtorden.Enabled = False
            FrmDatosDeEntrega.txtfecha.Enabled = False
        End If
        FrmDatosDeEntrega.txtorden.Visible = False
        FrmDatosDeEntrega.txtfecha.Visible = False
        FrmDatosDeEntrega.lbtitulo.Text = "DATOS DE ENTREGA"
        FrmDatosDeEntrega.lborden.Text = ""
        FrmDatosDeEntrega.lbfecha.Text = ""
        FrmDatosDeEntrega.lbform.Text = "fn_sp"
        FrmDatosDeEntrega.ShowDialog()
        FrmDatosDeEntrega.txtorden.Visible = True
        FrmDatosDeEntrega.txtfecha.Visible = True
        FrmDatosDeEntrega.lbtitulo.Text = "DATOS DE ENTREGA DEL PEDIDO"
        FrmDatosDeEntrega.lborden.Text = "Orden de Compra Nro."
        FrmDatosDeEntrega.lbfecha.Text = "Fecha de la orden"
    End Sub
    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtvmto, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            lbhora.Text = Format(Now, "HH:mm:ss")
        End If
    End Sub

    Private Sub txtfecha_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfecha.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If PerActual <> Format(txtfecha.Value, "MM/yyyy") Then
            Try
                txtfecha.Value = CDate(PerActual & "/" & Now.Day)
            Catch ex As Exception
                If txtfecha.Enabled = True Then
                    txtfecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
                Else
                    txtfecha.Value = CDate(PerActual & "/" & "01")
                End If
            End Try
            If txtfecha.Enabled = True Then
                txtfecha.Focus()
            End If
            MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
        End If
    End Sub
    Private Sub txtfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfecha.ValueChanged

    End Sub
    '***************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Dim viva() As String
    Dim vmon() As Double
    Public Sub AgruparIva(ByVal iva As String, ByVal monto As Double)
        Dim i As Integer = 0
        Dim sw As Integer = 0
        For i = 0 To viva.Length - 1
            If viva(0) = "--" Then
                viva(i) = iva
                vmon(i) = monto
                sw = 1 'ya existe
                Exit For
            Else
                If viva(i) = iva Then
                    vmon(i) = vmon(i) + monto
                    sw = 1 'ya existe
                    Exit For
                End If
            End If
        Next
        If sw = 0 Then
            ReDim Preserve viva(i)
            ReDim Preserve vmon(i)
            viva(i) = iva
            vmon(i) = monto
        End If
    End Sub
    Public Sub generarPDFSupHierr()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        'Try

        'Catch ex As Exception

        'End Try
        ReDim Preserve viva(1)
        ReDim Preserve vmon(1)
        viva(0) = "--"
        vmon(0) = 0
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        pag = 0
        tope = 80
        '**************************************
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        '///////////////
        Try
            Dim img As iTextSharp.text.Image
            img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\SUPER\super43.jpg")
            'img.SetAbsolutePosition(0, 150)
            'img.ScaleToFit(1800, 650)
            img.SetAbsolutePosition(17, 80)
            img.ScaleToFit(2500, 680)
            img.Alignment = Element.ALIGN_RIGHT
            cb.AddImage(img)
        Catch ex As Exception
        End Try
        '///////////////
        'ColocarImg()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9.5)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "FACTURA DE VENTA", 511, 656, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "No " & txtnumfac.Text, 515, 630, 0)
        BannSuper()
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        ' ... Datos tercero
        Dim ta As New DataTable
        ta.Clear()
        myCommand.CommandText = "SELECT CONCAT(t.dir,' ',m.descripcion) AS dir,TRIM(CONCAT(t.telefono,' ',t.celular)) AS tel FROM " & bda & ".terceros t LEFT JOIN (sae.mun m) ON m.codmun=t.mun WHERE t.nit='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then Exit Sub
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, ta.Rows(0).Item("dir").ToString, 140, 558, 0)
        cb.ShowTextAligned(50, ta.Rows(0).Item("tel").ToString, 352, 558, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnitc.Text, 398, 580, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcliente.Text, 98, 605, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtfecha.Value, 80, 580, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtobserbaciones.Text, 249, 580, 0)


        k = 533
        '..........
        Dim tabla As New DataTable
        Dim valor, vtotal, vdesc, va_iva As Double
        myCommand.CommandText = "SELECT * FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            k = k - 16.48
            If i = tabla.Rows.Count - 1 Then tope = 130
            If k < tope Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'ColocarImg()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                'Banner()
                k = k - 20
                cb.EndText()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantidad"), 52, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 50), 80, k, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(tabla.Rows(i).Item("iva_d").ToString), 500, k, 0)
            Try
                valor = Moneda2(tabla.Rows(i).Item("valor")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
            Catch ex As Exception
                valor = Moneda2(tabla.Rows(i).Item("valor"))
                valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
            End Try
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor), 440, k, 0)
            Try
                vtotal = Moneda2(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
            Catch ex As Exception
                vtotal = Moneda2(tabla.Rows(i).Item("vtotal"))
                vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
            End Try
            ''********** calculo subtotal con dcto ******
            'Try
            '    vdesc = vtotal - (vtotal * CDbl(valordes.Text) / 100)
            'Catch ex As Exception
            '    vdesc = vtotal
            'End Try
            ''***** valor iva *********
            'Try
            '    va_iva = (vdesc * (CDec(tabla.Rows(i).Item("iva_d")) / 100))
            'Catch ex As Exception
            '    va_iva = 0
            'End Try
            'Try
            '    AgruparIva(tabla.Rows(i).Item("iva_d").ToString, va_iva)
            'Catch ex As Exception
            'End Try

            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal), 542, k, 0)
        Next
        ' TOTALES
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "COSTOS DIRECTOS", 352, 210, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text), 542, 210, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ADMIN" & valor_rtfuente.Text & "%", 352, 198, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtrtefuente.Text), 542, 198, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IMPREVISTOS " & valor_rtiva.Text & "%", 352, 186, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtriva.Text), 542, 186, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "UTILIDAD " & valor_rtica.Text & "%", 352, 174, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtrica.Text), 542, 174, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUBTOTAL ", 352, 162, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(CDbl(txtsubtotal.Text) + CDbl(txtrtefuente.Text) + CDbl(txtretCre.Text) + CDbl(txtrica.Text)), 542, 162, 0)
        k = 162
        For j = 0 To cbsr.Items.Count - 1
            k = k - 12
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, cbconcepto.Items.Item(j), 352, k, 0)
            If cbsr.Items.Item(j) = "-" Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbsr.Items.Item(j) & " " & Moneda2(cbvalor.Items.Item(j)), 542, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(j)), 542, k, 0)
            End If
        Next
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text), 542, 100, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        AbrirArchivo(NombreArchivo)
    End Sub
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            ReDim Preserve viva(1)
            ReDim Preserve vmon(1)
            viva(0) = "--"
            vmon(0) = 0
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '*********************************************
            Dim tabla As New DataTable
            Dim valor, vtotal, vdesc, va_iva As Double
            myCommand.CommandText = "SELECT * FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If i = tabla.Rows.Count - 1 Then tope = 130
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    ColocarImg()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("item"), 20, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart"), 40, k, 0)
                'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantidad"), 350, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(tabla.Rows(i).Item("iva_d").ToString), 500, k, 0)
                Try
                    valor = Moneda2(tabla.Rows(i).Item("valor")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                    valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                Catch ex As Exception
                    valor = Moneda2(tabla.Rows(i).Item("valor"))
                    valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor), 460, k, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                    vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"))
                    vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                End Try
                '********** calculo subtotal con dcto ******
                Try
                    vdesc = vtotal - (vtotal * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                    vdesc = vtotal
                End Try
                '***** valor iva *********
                Try
                    va_iva = (vdesc * (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    va_iva = 0
                End Try
                Try
                    AgruparIva(tabla.Rows(i).Item("iva_d").ToString, va_iva)
                Catch ex As Exception
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal), 585, k, 0)
                Control_de_linea(tabla.Rows(i).Item("nomart").ToString, 120, 38)
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text), 585, k, 0)
            If CDec(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                ' cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(lbdescuento.Text), 585, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtdescuento.Text), 585, k, 0)
            End If
            If CDec(valor_rtfuente.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE FUENTE " & valor_rtfuente.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtrtefuente.Text), 585, k, 0)
            End If
            If CDec(valorretCree.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE CREE " & valorretCree.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtretCre.Text), 585, k, 0)
            End If
            If CDec(valor_rtica.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE ICA " & valor_rtica.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtrica.Text), 585, k, 0)
            End If
            If CDec(valor_rtiva.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE IVA " & valor_rtiva.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtriva.Text), 585, k, 0)
            End If
            If CDbl(txtiva.Text) <> 0 Then
                For iiva = 0 To viva.Length - 1
                    If Moneda2(viva(iiva)) <> "0,00" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA " & Moneda2(viva(iiva)) & "%", 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vmon(iiva)), 585, k, 0)
                    End If
                Next
            End If
            For i = 0 To cbsr.Items.Count - 1
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i)), 585, k, 0)
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i)), 585, k, 0)
                    End If
                Catch ex As Exception
                End Try
            Next
            'For i = 0 To 2
            '    Try
            '        If Trim(cbsr.Items.Item(i).ToString) = "+" Then
            '            k = k - 10
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i)), 585, k, 0)
            '        ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
            '            k = k - 10
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i)), 585, k, 0)
            '        End If
            '    Catch ex As Exception
            '    End Try
            'Next
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text), 585, k, 0)
            k = k - 10
            '**************************** FORMA DE PAGO*****************************************************************
            cb.ShowTextAligned(50, "Forma De Pago:", 10, k2, 0)
            For i = 0 To gfp.RowCount - 1
                If gfp.Item("cual", i).Value = "Otra" Then
                    cb.ShowTextAligned(50, CambiaCadena(gfp.Item("detalle", i).Value.ToString, 35) & ": $" & Moneda2(gfp.Item("monto", i).Value), 73, k2, 0)
                Else
                    cb.ShowTextAligned(50, gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value), 73, k2, 0)
                End If
                k2 = k2 - 10
            Next
            k2 = k2 - 5
            If k2 < k Then
                k = k2
            End If
            'cb.ShowTextAligned(50, "SON: " & Num2Text(txttotal.Text), 10, k, 0)
            Control_de_linea("SON: " & Num2Text(txttotal.Text), 10, 80)
            k = k - 10
            If txtobserbaciones.Text <> "" Then
                cb.ShowTextAligned(50, "Observaciones: ", 10, k, 0)
                Control_de_linea(txtobserbaciones.Text, 70, 100)
                k = k - 10
            End If
            k = k - 20
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    'cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 10, 125)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            '*************************************************************
            cb.ShowTextAligned(50, "Esta factura se asimila para todos sus efectos a la letra de cambio. Articulo 774 Codigo de Comercio.", 10, k, 0)
            k = k - 10
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 15
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            k = k - 46
            cb.ShowTextAligned(50, "_____________________________", 20, k, 0)
            cb.ShowTextAligned(50, "_____________________________", 350, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "RECIBIDO", 20, k, 0)
            cb.ShowTextAligned(50, "ENTREGADO", 350, k, 0)
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Function Moneda2(ByVal monto As String)
        If lb_imp_dec.Text = "S" Then
            Try
                If CDbl(monto) = 0 Then
                    monto = "0,00"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 2), "0,00.00")
                End If
                Return monto
            Catch ex As Exception
                Return "0,00"
            End Try
        Else
            Try
                If CDbl(monto) = 0 Then
                    monto = "0"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 0), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 0), "0,00")
                End If
                Return monto
            Catch ex As Exception
                Return "0"
            End Try
        End If
    End Function
    Public Sub ColocarImg()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='NORMAL';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
            img.ScaleToFit(80, 180)
            img.SetAbsolutePosition(20, 770)
            img.Alignment = Element.ALIGN_RIGHT
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BannSuper()

        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion") & " - TELEFONO: " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, 70, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, " VALLEDUPAR - CESAR ", 305, 60, 0)


        Dim tablaR As New DataTable
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='NORMAL';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablaR.Rows(0).Item("tipocompa"), 520, 610, 0)


        ''k = 815
        ''cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        ''k = k - 10
        ''cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit") & " " & tablaR.Rows(0).Item("tipocompa"), 300, k, 0)
        ''k = k - 10
        ''cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        ''k = k - 10
        ''cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        ' ''k = k - 25
        Dim tablad As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablad)
        'Dim pref As String = ""
        'If tablad.Rows(0).Item("tipof1") = txttipo.Text And Trim(tablad.Rows(0).Item("pre1")) <> "" Then
        '    pref = Trim(tablad.Rows(0).Item("pre1"))
        'ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And Trim(tablad.Rows(0).Item("pre2")) <> "" Then
        '    pref = Trim(tablad.Rows(0).Item("pre2"))
        'ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And Trim(tablad.Rows(0).Item("pre3")) <> "" Then
        '    pref = Trim(tablad.Rows(0).Item("pre3"))
        'ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And Trim(tablad.Rows(0).Item("pre4")) <> "" Then
        '    pref = Trim(tablad.Rows(0).Item("pre4"))
        'End If
        'If txttipo.Text <> lbdocajuste.Text Then
        '    cb.ShowTextAligned(50, txttipo2.Text & " No. " & pref & " " & txtnumfac.Text, 20, k, 0)
        'Else
        '    cb.ShowTextAligned(50, txttipo2.Text & " No. " & txtnumfac.Text & " Del Periodo " & PerActual, 20, k, 0)
        'End If
        ' ''******************************************************** DIAN **************************************************************      
        If tablad.Rows(0).Item("tipof1") = txttipo.Text And tablad.Rows(0).Item("hr1") = "SI" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RESOLUCION DIAN No " & tablad.Rows(0).Item("reso1") & " DE FECHA ", 300, 162, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablad.Rows(0).Item("fecexp1") & "Factura por computador Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 180, 150, 0)
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RESOLUCION DIAN No " & tablad.Rows(0).Item("reso1") & " DE FECHA ", 300, 162, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablad.Rows(0).Item("fecexp1") & "Factura por computador Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 180, 150, 0)
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RESOLUCION DIAN No " & tablad.Rows(0).Item("reso1") & " DE FECHA ", 300, 162, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablad.Rows(0).Item("fecexp1") & "Factura por computador Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 180, 150, 0)
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RESOLUCION DIAN No " & tablad.Rows(0).Item("reso1") & " DE FECHA ", 300, 162, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablad.Rows(0).Item("fecexp1") & "Factura por computador Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 2180, 150, 0)
        End If

    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        Dim tablaR As New DataTable
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='NORMAL';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
        k = 815
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit") & " " & tablaR.Rows(0).Item("tipocompa"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        k = k - 25
        Dim tablad As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablad)
        Dim pref As String = ""
        If tablad.Rows(0).Item("tipof1") = txttipo.Text And Trim(tablad.Rows(0).Item("pre1")) <> "" Then
            pref = Trim(tablad.Rows(0).Item("pre1"))
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And Trim(tablad.Rows(0).Item("pre2")) <> "" Then
            pref = Trim(tablad.Rows(0).Item("pre2"))
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And Trim(tablad.Rows(0).Item("pre3")) <> "" Then
            pref = Trim(tablad.Rows(0).Item("pre3"))
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And Trim(tablad.Rows(0).Item("pre4")) <> "" Then
            pref = Trim(tablad.Rows(0).Item("pre4"))
        End If
        If txttipo.Text <> lbdocajuste.Text Then
            cb.ShowTextAligned(50, txttipo2.Text & " No. " & pref & " " & txtnumfac.Text, 20, k, 0)
        Else
            cb.ShowTextAligned(50, txttipo2.Text & " No. " & txtnumfac.Text & " Del Periodo " & PerActual, 20, k, 0)
        End If

        k = k - 10
        cb.ShowTextAligned(50, "FECHA: " & txtfecha.Text & " HORA: " & lbhora.Text, 20, k, 0)
        If Val(txtvmto.Text) > 0 Then
            k = k - 10
            cb.ShowTextAligned(50, "FECHA DE VENCIMIENTO: " & txtfecha.Value.AddDays(Val(txtvmto.Text)) & " HORA: " & lbhora.Text, 20, k, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "SEÑORES: ", 20, k, 0)
        Control_de_linea(Trim(txtcliente.Text), 70, 45)
        If lbentrega.Text <> txtcliente.Text And Trim(lbentrega.Text) <> "" Then
            k = k - 10
            cb.ShowTextAligned(50, "ENTREGAR A: " & lbentrega.Text, 20, k, 0)
        End If
        DatosTercero()
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: " & txtnitc.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "VENDEDOR: " & txtvendedor.Text, 20, k, 0)
        '**********************************************************************************************************************
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        '******************************************************** DIAN **************************************************************      
        If tablad.Rows(0).Item("tipof1") = txttipo.Text And tablad.Rows(0).Item("hr1") = "SI" Then
            PrintDian("Resolución DIAN " & tablad.Rows(0).Item("reso1") & " del " & tablad.Rows(0).Item("fecexp1").ToString, "Factura por computador Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"))
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            PrintDian("Resolución DIAN " & tablad.Rows(0).Item("reso2") & " del " & tablad.Rows(0).Item("fecexp2").ToString, "Factura por computador Nro. " & tablad.Rows(0).Item("ini2") & " al " & tablad.Rows(0).Item("fin2"))
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            PrintDian("Resolución DIAN " & tablad.Rows(0).Item("reso3") & " del " & tablad.Rows(0).Item("fecexp3").ToString, "Factura por computador Nro. " & tablad.Rows(0).Item("ini3") & " al " & tablad.Rows(0).Item("fin3"))
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            PrintDian("Resolución DIAN " & tablad.Rows(0).Item("reso4") & " del " & tablad.Rows(0).Item("fecexp4").ToString, "Factura por computador Nro. " & tablad.Rows(0).Item("ini4") & " al " & tablad.Rows(0).Item("fin4"))
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PAGINA: " & pag, 585, k + 25, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 40, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 350, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR UNITARIO", 460, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "% IVA", 500, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
    Public Sub DatosTercero()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT CONCAT(t.dir,' ',m.descripcion) AS dir,TRIM(CONCAT(t.telefono,' ',t.celular)) AS tel FROM " & bda & ".terceros t LEFT JOIN (sae.mun m) ON m.codmun=t.mun WHERE t.nit='" & txtnitc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then Exit Sub
            k = k - 10
            cb.ShowTextAligned(50, "DIRECCION:", 20, k, 0)
            If lbdir.Text <> "" Then
                Control_de_linea(Trim(lbdir.Text & " " & lbciudad.Text), 75, 40)
            Else
                Control_de_linea(tabla.Rows(0).Item("dir").ToString, 75, 40)
            End If
            k = k - 10
            cb.ShowTextAligned(50, "TELEFONO: " & tabla.Rows(0).Item("tel").ToString, 20, k, 0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub PrintDian(ByVal r As String, ByVal f As String)
        cb.ShowTextAligned(50, r, 350, k + 45, 0)
        cb.ShowTextAligned(50, f, 350, k + 35, 0)
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal x As Integer, ByVal tam As Integer)
        Try
            salto = 1
            linea = ""
            Dim j As Integer = 0
            For i = 0 To cadena.Length - 1
                Try
                    If cadena(i) = "%" Then
                        If cadena(i + 1) = "%" Then
                            j = 0
                            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                            linea = ""
                            i = i + 1
                            k = k - 10
                        End If
                    Else
                        linea = linea & cadena(i)
                        If j < tam Then
                            j = j + 1
                        Else
                            If cadena(i) = "" Or cadena(i) = " " Or cadena(i) = "," Or cadena(i) = "." Or j >= tam + 3 Then
                                j = 0
                                cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                                linea = ""
                                k = k - 10
                            Else
                                j = j + 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
        Catch ex As Exception

        End Try
    End Sub
    '//////////// GENERAR PDF2//////////////////////////
    Public Sub GenerarPDF2()
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 1
            tope = 80
            Dim k2 As Integer = 0
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg2(1)
            ColocarImg2(4)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner2()
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 11)
            cb.BeginText()
            nfact()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            Dim valor, vtotal As Double
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim sw As Integer
            Try
                If CDbl(txtrtefuente.Text) <> 0 And CDbl(txtrica.Text) <> 0 And CDbl(txtriva.Text) <> 0 Then
                    sw = 1
                Else
                    sw = 0
                End If
            Catch ex As Exception
                sw = 0
            End Try
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If i = tabla.Rows.Count - 1 Then tope = 250
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    ColocarImg2(1)
                    ColocarImg2(4)
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner2()
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 11)
                    cb.BeginText()
                    nfact()
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    k = k - 10
                End If

                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
                '*********************PRINT ITEMS********************************
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda2(tabla.Rows(i).Item("cantidad")), 50, k, 0)
                Try
                    valor = Moneda2(tabla.Rows(i).Item("valor")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    valor = Moneda2(tabla.Rows(i).Item("valor"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor), 468, k + 2, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal")) / (1 + (CDec(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal), 568, k + 2, 0)
                Control_de_linea(tabla.Rows(i).Item("nomart").ToString, 82, 56)
                cb.EndText()
                k = k - 3
                ColocarImg2(3) ' linea
                cb.BeginText()
            Next
            k = k - 158
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = 217
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUBTOTAL $", 390, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCUENTO $", 390, k, 0)
            k = k - 10
            If CDbl(txtrtefuente.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "RET. FUENTE $", 390, k, 0)
                k = k - 10
            End If
            If CDbl(txtrica.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "RET. ICA $", 390, k, 0)
                k = k - 10
            End If
            If CDbl(txtriva.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "RET. IVA $", 390, k, 0)
                k = k - 10
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "IVA $", 390, k, 0)
            k = k - 10
            For i = 0 To 2
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(cbconcepto.Items.Item(i) & " $", 10), 390, k, 0)
                        k = k - 10
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(cbconcepto.Items.Item(i) & " $", 10), 390, k, 0)
                        k = k - 10
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TOTAL $", 390, k, 0)
            k = k - 10
            k = 217
            '**************************************************************
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text), 568, k, 0)
            k = k - 10
            Dim hd As String = ""
            ' If CDbl(lbdescuento.Text) > 0 Then
            If CDbl(txtdescuento.Text) > 0 Then
                hd = "-"
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, hd & Moneda2(txtdescuento.Text), 568, k, 0)
            ' cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, hd & Moneda2(lbdescuento.Text), 568, k, 0)
            k = k - 10
            If CDbl(txtrtefuente.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtrtefuente.Text), 568, k, 0)
                k = k - 10
            End If
            If CDbl(txtrica.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtrica.Text), 568, k, 0)
                k = k - 10
            End If
            If CDbl(txtriva.Text) > 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtriva.Text), 568, k, 0)
                k = k - 10
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtiva.Text), 568, k, 0)
            k = k - 10
            For i = 0 To 2
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i)), 568, k, 0)
                        k = k - 10
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i)), 568, k, 0)
                        k = k - 10
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text), 568, k, 0)
            '/////////////////////////////////////////////////////////////////
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = 217
            '*****************COMENTARIO******************************************
            Control_de_linea("SON: " & Num2Text(Moneda2(txttotal.Text)), 23, 90)
            k = k - 10
            If Trim(txtobserbaciones.Text) <> "" Then
                Control_de_linea(txtobserbaciones.Text, 23, 98)
                k = k - 10
            End If
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    'cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 23, 98)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            cb.ShowTextAligned(50, "Esta factura se asimila para todos sus efectos a la letra de cambio. Articulo 774 Codigo de Comercio.", 23, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now, 23, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE. Versión " & FrmPrincipal.lbversion.Text & ".", 23, k, 0)
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub ColocarImg2(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                'img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\FV1.jpg")
                'img.SetAbsolutePosition(0, 600)
                'img.ScaleToFit(598, 500)
                'img.Alignment = Element.ALIGN_CENTER
                'cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\banner.jpg")
                img.SetAbsolutePosition(10, 595)
                img.ScaleToFit(690, 255)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 2 Then
                'img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\FV2.jpg")
                'img.SetAbsolutePosition(0, k)
                'img.ScaleToFit(598, 50)
                'img.Alignment = Element.ALIGN_CENTER
                'cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\body.jpg")
                img.SetAbsolutePosition(10, 128)
                img.ScaleToFit(690, 470)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 3 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\linea.jpg")
                img.SetAbsolutePosition(23, k)
                img.ScaleToFit(280, 1)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\linea.jpg")
                img.SetAbsolutePosition(302, k)
                img.ScaleToFit(270, 1)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\footer.jpg")
                img.SetAbsolutePosition(20, 20)
                img.ScaleToFit(670, 100)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner2()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        Dim tablaR As New DataTable
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='NORMAL';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
        '******************************************************** DIAN **************************************************************
        Dim tablad As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablad)
        k = 780
        '******************************************************** DIAN **************************************************************       
        Dim pre As String = ""
        If tablad.Rows(0).Item("tipof1") = txttipo.Text And tablad.Rows(0).Item("hr1") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre1") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre1")
            cb.ShowTextAligned(50, "Resolución DIAN " & " " & tablad.Rows(0).Item("reso1"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp1").ToString & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre2") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre2")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso2"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp2").ToString & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini2") & " al " & tablad.Rows(0).Item("fin2"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre3") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre3")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso3"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp3").ToString & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini3") & " al " & tablad.Rows(0).Item("fin3"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre4") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre4")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso4"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp4").ToString & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini4") & " al " & tablad.Rows(0).Item("fin4"), 435, k, 0)
        End If
        '***********************************************************
        k = 705
        cb.ShowTextAligned(50, txtfecha.Value.Day, 20, k, 0)
        cb.ShowTextAligned(50, txtfecha.Value.Month, 55, k, 0)
        cb.ShowTextAligned(50, txtfecha.Value.Year, 80, k, 0)
        '*****************************************************
        k = 678
        cb.ShowTextAligned(50, txtcliente.Text, 90, k, 0)
        k = k - 23
        cb.ShowTextAligned(50, txtnitc.Text, 90, k, 0)
        k = k - 18
        DatosTercero(txtnitc.Text)
        'k = k - 32
        ''********* FORMA DE PAGO *********************
        'Dim k2 As Integer = k
        'For i = 0 To gfp.RowCount - 1
        '    Try
        '        If gfp.Item("cual", i).Value = "Otra" Then
        '            cb.ShowTextAligned(50, CambiaCadena(gfp.Item("detalle", i).Value.ToString, 27), 105, k2, 0)
        '        ElseIf Trim(gfp.Item("cual", i).Value.ToString) <> "" Then
        '            cb.ShowTextAligned(50, gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value), 105, k2, 0)
        '        End If
        '        k2 = k2 - 10
        '    Catch ex As Exception
        '    End Try
        'Next
        '**********************************
        k = k - 25
        Try
            If gfp.Item("cual", 0).Value = "Otra" Then
                cb.ShowTextAligned(50, CambiaCadena(gfp.Item("detalle", 0).Value.ToString, 30), 140, k, 0)
            ElseIf Trim(gfp.Item("cual", 0).Value.ToString) <> "" Then
                cb.ShowTextAligned(50, gfp.Item("cual", 0).Value & ": $" & Moneda2(gfp.Item("monto", 0).Value), 140, k, 0)
            End If
        Catch ex As Exception
        End Try
        '***********************************************       
        If Val(txtvmto.Text) > 0 Then
            cb.ShowTextAligned(50, txtfecha.Value.AddDays(Val(txtvmto.Text)), 480, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.AddDays(Val(txtvmto.Text)).Day, 514, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.AddDays(Val(txtvmto.Text)).Month, 536, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.AddDays(Val(txtvmto.Text)).Year, 560, k, 0)
        Else
            cb.ShowTextAligned(50, txtfecha.Value, 480, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.Day, 514, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.Month, 536, k, 0)
            'cb.ShowTextAligned(50, txtfecha.Value.Year, 560, k, 0)
        End If
        cb.EndText()
        ColocarImg2(2) 'body
        cb.BeginText()
        k = 565
    End Sub
    Public Sub nfact()
        Dim tablad As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablad)
        Dim pref As String = ""
        Dim k2 As Integer = 750
        cb.ShowTextAligned(50, txttipo2.Text, 445, k2, 0)
        If txttipo.Text = lbdocajuste.Text Then
            cb.ShowTextAligned(50, txtnumfac.Text & " del periodo " & PerActual, 462, 727 - 30, 0)
        Else
            If tablad.Rows(0).Item("tipof1") = txttipo.Text And Trim(tablad.Rows(0).Item("pre1")) <> "" Then
                pref = Trim(tablad.Rows(0).Item("pre1"))
            ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And Trim(tablad.Rows(0).Item("pre2")) <> "" Then
                pref = Trim(tablad.Rows(0).Item("pre2"))
            ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And Trim(tablad.Rows(0).Item("pre3")) <> "" Then
                pref = Trim(tablad.Rows(0).Item("pre3"))
            ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And Trim(tablad.Rows(0).Item("pre4")) <> "" Then
                pref = Trim(tablad.Rows(0).Item("pre4"))
            End If
            cb.ShowTextAligned(50, "No. " & pref & " " & txtnumfac.Text, 445, k2 - 25, 0)
        End If
        cb.ShowTextAligned(50, "Página No." & pag, 445, k2 - 50, 0)
    End Sub
    Public Sub NGenerarPDF()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim dire As String = ""
        Dim tel As String = ""
        Dim email As String = ""
        Dim fec As String = ""
        Dim fac As String = ""
        Dim cli As String = ""
        Dim Ncli As String = ""
        Dim vend As String = ""
        Dim fecv As String = ""
        Dim Nfac As String = ""
        Dim dirC As String = ""
        Dim telC As String = ""
        Dim reso As String = ""
        Dim obs As String = ""
        Dim com As String = ""
        Dim fpag As String = ""
        Dim log As String = ""
        Dim tfac As String = ""
        Dim lett As String = ""
        Dim des As String = ""
        Dim tcomp As String = ""

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        lett = Num2Text(Moneda2(txttotal.Text))

        MiConexion(bda)
        Cerrar()

        sql2 = "select CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM facturas" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 2 ) ,  '/', MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM facturas" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 6, 2 ) ,  '/', LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM facturas" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 4 ) ) ) AS CHAR( 20 ) ) AS fechaV, " _
        & " CASE (Select f.tipodoc from facturas" & p & " f WHERE  f.doc = '" & txttipo.Text & txtnumfac.Text & "' ) " _
        & " WHEN pg.tipof1 " _
        & " THEN IF (pg.hr1='SI', " _
        & " CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '') " _
        & " WHEN pg.tipof2 " _
        & " THEN IF (pg.hr2='SI', " _
        & " CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '') " _
        & " WHEN pg.tipof3 " _
        & " THEN IF (pg.hr3='SI', " _
        & " CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '') " _
        & " WHEN pg.tipof4 " _
        & " THEN IF (pg.hr4='SI', " _
        & " CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '') " _
        & " END AS reso, " _
        & " CASE '" & txttipo.Text & "' " _
        & " WHEN pg.tipof1 THEN pg.pre1 " _
        & " WHEN pg.tipof2 THEN pg.pre2 " _
        & " WHEN pg.tipof3 THEN pg.pre3 " _
        & " WHEN pg.tipof4 THEN pg.pre4 " _
        & " END AS pref, " _
        & " (SELECT  t.dir from facturas" & p & " f, terceros t where f.doc =  '" & txttipo.Text & txtnumfac.Text & "' and f.nitc= t.nit ) as dirC, " _
        & " (SELECT  t.telefono from facturas" & p & " f, terceros t where f.doc =  '" & txttipo.Text & txtnumfac.Text & "' and f.nitc= t.nit ) as telC " _
        & " , (Select f.observ from facturas" & p & " f where f.doc =  '" & txttipo.Text & txtnumfac.Text & "') as obs,  " _
        & " ( select comentario from parafacts where factura= 'RAPIDA') as com , " _
        & " CASE (Select f.tipodoc from facturas" & p & " f WHERE  f.doc = '" & txttipo.Text & txtnumfac.Text & "' ) " _
        & " WHEN pg.tipof1 " _
        & " THEN IF (pg.hr1='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
        & " WHEN pg.tipof2 " _
        & " THEN IF (pg.hr2='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
        & " WHEN pg.tipof3 " _
        & " THEN IF (pg.hr3='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
        & " WHEN pg.tipof4 " _
        & " THEN IF (pg.hr4='SI', " _
        & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
        & " END AS tfac, " _
        & " (Select tipocompa from parafacts where factura= 'NORMAL' ), " _
        & "(Select comentario_ini from parafacts where factura= 'NORMAL' ) as com_ini " _
        & " from parafacgral pg "

        Dim com_ini As String = ""
        Dim tabla3 As New DataTable
        tabla3 = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)
        If tabla3.Rows.Count > 0 Then
            fecv = tabla3.Rows(0).Item("fechaV").ToString
            reso = tabla3.Rows(0).Item(1).ToString
            Nfac = tabla3.Rows(0).Item(2).ToString
            dirC = tabla3.Rows(0).Item(3).ToString
            telC = tabla3.Rows(0).Item(4).ToString
            obs = tabla3.Rows(0).Item(5).ToString
            com = tabla3.Rows(0).Item(6).ToString
            fpag = ""
            tfac = tabla3.Rows(0).Item(7).ToString
            tcomp = tabla3.Rows(0).Item(8).ToString
            com_ini = tabla3.Rows(0).Item("com_ini").ToString
        End If

        Dim vd As String = ""
        vd = valordes.Text.Replace(",", ".")

        'Nfac = txttipo.Text

        sql3 = " SELECT iva_d , SUM( " _
        & " ( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & vd & "/100)))*(iva_d/100)) " _
        & " - ( " _
        & " ( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & vd & "/100)))*(iva_d/100)) * por_des/100) " _
        & " )as IVA FROM detafac" & p & " d WHERE d.doc='" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' GROUP BY iva_d "

        Dim tabla4 As New DataTable
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        If txtiva.Text <> Moneda2(0) Then
            For i = 0 To tabla4.Rows.Count - 1
                If tabla4.Rows(i).Item(1).ToString <> 0 Then
                    v_iva = v_iva & Moneda2(tabla4.Rows(i).Item(1).ToString) & vbCrLf
                    tv_iva = tv_iva & "IVA " & (tabla4.Rows(i).Item(0).ToString) & " %" & vbCrLf
                End If
            Next
        Else
            tv_iva = "IVA "
            v_iva = "0,00"
        End If


        Dim sql4 As String = ""

        sql4 = " SELECT  descrip, valor FROM facpagos" & p & "  WHERE doc=  '" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' "
        Dim tabla5 As New DataTable
        Dim conc As String = ""
        Dim t_conc As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql4
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        For i = 0 To tabla4.Rows.Count - 1
            t_conc = t_conc & "" & (tabla4.Rows(i).Item(0).ToString) & ": " & Moneda2(tabla4.Rows(i).Item(1).ToString) & " // "
            conc = ""
            't_conc = t_conc & "" & (tabla4.Rows(i).Item(0).ToString) & vbCrLf
            'conc = conc & Moneda2(tabla4.Rows(i).Item(1).ToString) & vbCrLf
        Next


        '---------------------------------------------
        Dim sql5 As String = ""
        Dim otro As String = ""
        Dim t_otro As String = ""
        'sql5 = " SELECT f.o_con,f.t1, f.d1, f.v1, f.cta1, f.t2,f.d2,f.v2,f.cta2,f.t3,f.d3,f.v3, f.cta3 FROM facturas" & p & " f WHERE f.doc= '" & txttipo.Text & txtnumfac.Text & "' "
        sql5 = " SELECT f.o_con FROM facturas" & p & " f WHERE f.doc= '" & txttipo.Text & txtnumfac.Text & "' "
        Dim tablO As New DataTable
        tablO = New DataTable
        myCommand.CommandText = sql5
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablO)

        'For i = 0 To tablO.Rows.Count - 1
        If (tablO.Rows(0).Item("o_con").ToString) = "si" Then
            'sql3 = " SELECT f.o_con,f.t1, f.d1, f.v1, f.cta1, f.t2,f.d2,f.v2,f.cta2,f.t3,f.d3,f.v3, f.cta3 FROM fact_comp" & p & " f WHERE f.doc= '" & txttipo.Text & txtnumfac.Text & "' "
            Dim ta4 As New DataTable
            ta4 = New DataTable
            myCommand.CommandText = "SELECT * FROM otcon_fac" & p & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta4)

            If tabla4.Rows.Count > 0 Then
                For l = 0 To ta4.Rows.Count - 1
                    t_otro = t_otro & (ta4.Rows(l).Item("descrip").ToString) & vbCrLf & vbCrLf
                    otro = otro & (ta4.Rows(l).Item("tipo").ToString) & Moneda2(ta4.Rows(l).Item("valor").ToString) & vbCrLf & vbCrLf
                Next
            End If
            ''.......
            'If (tablO.Rows(i).Item("t1").ToString) <> "" Then
            '    t_otro = t_otro & (tablO.Rows(i).Item("d1").ToString) & vbCrLf & vbCrLf
            '    otro = otro & (tablO.Rows(i).Item("t1").ToString) & Moneda2(tablO.Rows(i).Item("v1").ToString) & vbCrLf & vbCrLf
            'End If
            'If (tablO.Rows(i).Item("t2").ToString) <> "" Then
            '    t_otro = t_otro & (tablO.Rows(i).Item("d2").ToString) & vbCrLf & vbCrLf
            '    otro = otro & (tablO.Rows(i).Item("t2").ToString) & Moneda2(tablO.Rows(i).Item("v2").ToString) & vbCrLf & vbCrLf
            'End If
            'If (tablO.Rows(i).Item("t3").ToString) <> "" Then
            '    t_otro = t_otro & (tablO.Rows(i).Item("d3").ToString) & vbCrLf & vbCrLf
            '    otro = otro & (tablO.Rows(i).Item("t3").ToString) & Moneda2(tablO.Rows(i).Item("v3").ToString) & vbCrLf & vbCrLf
            'End If
        Else
            t_otro = ""
            otro = ""
        End If
        'Next
        '----------------------------------------------



        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        If Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2")) <> "" Then
            tel = tel & " TEL: " & Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        End If
        If tabla2.Rows(0).Item("emailconta") <> "" Then
            tel = tel & " EMAIL: " & tabla2.Rows(0).Item("emailconta")
        End If
        If tabla2.Rows(0).Item("direccion") <> "" Then
            tel = tel & " DIR: " & tabla2.Rows(0).Item("direccion")
        End If
        'email = tabla2.Rows(0).Item("emailconta")
        'dire = tabla2.Rows(0).Item("direccion")

        fac = txtnumfac.Text
        fec = txtfecha.Text
        cli = txtcliente.Text
        Ncli = txtnitc.Text
        vend = txtvendedor.Text
        des = txtdescuento.Text
        'des = lbdescuento.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim dc As Integer = 0
        If lb_imp_dec.Text = "S" Then
            dc = 2
        End If

        sql = " SELECT  d.doc , d.iva_d as cualfp, d.item as tipodoc, d.codart as idbod, d.nomart as comentario , " _
        & " CAST((d.cantidad) AS CHAR(20)) as nitc, CAST(FORMAT(((d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)))," & dc & ")AS CHAR(20)) as nitvpre, " _
        & " FORMAT((((d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)) )* d.cantidad)," & dc & ") as nitv, " _
        & " (SELECT logofac FROM  parafacts where factura = 'RAPIDA') AS logofac, " _
        & " f.iva as numfact,  f.total as margmin" _
        & " FROM facturas" & p & " f INNER JOIN(detafac" & p & " d) ON f.doc = d.doc WHERE f.doc = '" & txttipo.Text & txtnumfac.Text & "' " _
        & " ORDER BY item"


        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacRap.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacRap.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtelef As New ParameterField
            Dim Premail As New ParameterField

            Dim prefec As New ParameterField
            Dim prefac As New ParameterField
            Dim preNcl As New ParameterField
            Dim precl As New ParameterField
            Dim preven As New ParameterField
            Dim prefecv As New ParameterField
            Dim prereso As New ParameterField
            Dim prenfac As New ParameterField
            Dim pretelc As New ParameterField
            Dim predirc As New ParameterField
            Dim precom As New ParameterField
            Dim preobs As New ParameterField
            Dim prpg As New ParameterField
            Dim prtf As New ParameterField
            Dim prlt As New ParameterField
            Dim prds As New ParameterField
            Dim prviva As New ParameterField
            Dim prtviva As New ParameterField

            Dim prOcon As New ParameterField
            Dim prTOcon As New ParameterField
            Dim prTcomp As New ParameterField
            Dim prTipo As New ParameterField

            Dim prO As New ParameterField
            Dim prT As New ParameterField

            Dim prrtf As New ParameterField
            Dim prrti As New ParameterField
            Dim prrtic As New ParameterField
            Dim prrtc As New ParameterField

            Dim prtotalg As New ParameterField
            Dim prsubtotal As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "dir"
            Prperiodo.CurrentValues.AddValue(dire.ToString)
            Prtelef.Name = "telef"
            Prtelef.CurrentValues.AddValue(tel.ToString)
            Premail.Name = "email"
            Premail.CurrentValues.AddValue(com_ini.ToString)

            prefec.Name = "fec"
            prefec.CurrentValues.AddValue(fec.ToString)
            prefac.Name = "fac"
            prefac.CurrentValues.AddValue(fac.ToString)
            precl.Name = "cli"
            precl.CurrentValues.AddValue(cli.ToString)
            preNcl.Name = "ncli"
            preNcl.CurrentValues.AddValue(Ncli.ToString)
            preven.Name = "vend"
            preven.CurrentValues.AddValue(vend.ToString)
            prefecv.Name = "fecV"
            prefecv.CurrentValues.AddValue(fecv.ToString)
            predirc.Name = "dirC"
            predirc.CurrentValues.AddValue(dirC.ToString)
            prereso.Name = "reso"
            prereso.CurrentValues.AddValue(reso.ToString)
            pretelc.Name = "telC"
            pretelc.CurrentValues.AddValue(telC.ToString)
            prenfac.Name = "nfac"
            prenfac.CurrentValues.AddValue(Nfac.ToString)
            precom.Name = "coment"
            precom.CurrentValues.AddValue(com.ToString)
            preobs.Name = "obs"
            preobs.CurrentValues.AddValue(obs.ToString)
            prpg.Name = "fpago"
            prpg.CurrentValues.AddValue(fpag.ToString)
            prtf.Name = "tfac"
            prtf.CurrentValues.AddValue(tfac.ToString)
            prlt.Name = "lt"
            prlt.CurrentValues.AddValue(lett.ToString)
            prds.Name = "desc"
            prds.CurrentValues.AddValue(des.ToString)
            prviva.Name = "v_iva"
            prviva.CurrentValues.AddValue(v_iva.ToString)
            prtviva.Name = "tv_iva"
            prtviva.CurrentValues.AddValue(tv_iva.ToString)

            prOcon.Name = "conc"
            prOcon.CurrentValues.AddValue(conc.ToString)
            prTOcon.Name = "t_conc"
            prTOcon.CurrentValues.AddValue(t_conc.ToString)

            prTcomp.Name = "tcomp"
            prTcomp.CurrentValues.AddValue(tcomp.ToString)

            prTipo.Name = "tipo"
            If txttipo.Text = lbdocajuste.Text Then
                prTipo.CurrentValues.AddValue("AJUSTE DE FACTURACION")
            Else
                prTipo.CurrentValues.AddValue("FACTURA DE VENTA N°")
            End If

            prO.Name = "otro"
            prO.CurrentValues.AddValue(otro.ToString)
            prT.Name = "t_otro"
            prT.CurrentValues.AddValue(t_otro.ToString)

            prrtf.Name = "rtf"
            prrtf.CurrentValues.AddValue(Moneda2(txtrtefuente.Text.ToString))
            prrti.Name = "rti"
            prrti.CurrentValues.AddValue(Moneda2(txtriva.Text.ToString))
            prrtic.Name = "rtic"
            prrtic.CurrentValues.AddValue(Moneda2(txtrica.Text.ToString))
            prrtc.Name = "rtc"
            prrtc.CurrentValues.AddValue(Moneda2(txtretCre.Text.ToString))

            prtotalg.Name = "totalG"
            prtotalg.CurrentValues.AddValue(Moneda2(txttotal.Text))
            prsubtotal.Name = "subtotal"
            prsubtotal.CurrentValues.AddValue(Moneda2(txtsubtotal.Text))


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtelef)
            prmdatos.Add(Premail)
            prmdatos.Add(prefec)
            prmdatos.Add(prefac)
            prmdatos.Add(precl)
            prmdatos.Add(preNcl)
            prmdatos.Add(preven)
            prmdatos.Add(predirc)
            prmdatos.Add(pretelc)
            prmdatos.Add(prefecv)
            prmdatos.Add(prenfac)
            prmdatos.Add(prereso)
            prmdatos.Add(precom)
            prmdatos.Add(preobs)
            prmdatos.Add(prpg)
            prmdatos.Add(prtf)
            prmdatos.Add(prlt)
            prmdatos.Add(prds)
            prmdatos.Add(prviva)
            prmdatos.Add(prtviva)

            prmdatos.Add(prTOcon)
            prmdatos.Add(prOcon)
            prmdatos.Add(prTcomp)
            prmdatos.Add(prTipo)
            prmdatos.Add(prO)
            prmdatos.Add(prT)

            prmdatos.Add(prrtf)
            prmdatos.Add(prrti)
            prmdatos.Add(prrtic)
            prmdatos.Add(prrtc)

            prmdatos.Add(prtotalg)
            prmdatos.Add(prsubtotal)

            FrmReportFacRap.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRap.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub DatosTercero(ByVal nit As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim tablac As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM sae.mun WHERE codmun='" & tabla.Rows(0).Item("mun") & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablac)
            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(0).Item("dir"), 40) & " " & tablac.Rows(0).Item("descripcion"), 100, k - 3, 0)
            cb.ShowTextAligned(50, Trim(tabla.Rows(0).Item("telefono") & " " & tabla.Rows(0).Item("celular")), 450, k - 3, 0)
        Catch ex As Exception
        End Try
    End Sub
    '////////////// GENERAR TICKET /////////////////////
    Private stringToPrint As String
    Public Sub GenerarTicket(ByVal campo As String)
        Dim file As System.IO.StreamWriter = System.IO.File.CreateText("C:\temp.txt")
        '*************DATOS COMPAÑIA***************************************
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        file.WriteLine(CambiaCadena(tablacomp.Rows(0).Item("descripcion"), 50))
        file.WriteLine("NIT. " & tablacomp.Rows(0).Item("nit"))
        file.WriteLine(tablacomp.Rows(0).Item("direccion"))
        file.WriteLine("TEL. " & tablacomp.Rows(0).Item("telefono1") & "    " & tablacomp.Rows(0).Item("telefono2"))
        '************** FACTURA ******************************
        file.WriteLine("FECHA: " & Now)
        If campo = "fact" Then
            file.WriteLine("FACTURA No. 00000 ")
        ElseIf campo = "ped" Then
            file.WriteLine("PEDIDO No. 00000 ")
        Else
            file.WriteLine("COTIZACIÓN No. 00000")
        End If
        file.WriteLine("SEÑORES: NOMBRE DEL CLIENTE")
        file.WriteLine("NIT/CEDULA: NIT / CEDULA")
        file.WriteLine("VENDEDOR: NOMBRE DEL VENDEDOR")
        file.WriteLine("Forma De Pago: Efectivo: $0,00")
        '*************** CUERPO ********************************
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                  Cant      Unit          Iva         V/total")
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("01001  producto  01001")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("02003  producto  02003")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("03016  producto  03016")
        file.WriteLine("                   0        0,00          0,00        0,00")
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                                         Sub Total:   0,00")
        file.WriteLine("                                         Iva:         0,00")
        file.WriteLine("                                         Total:       0,00")
        file.WriteLine(Chr(13))
        '*****************************************************************************
        file.WriteLine("Resolución DIAN 00000000 del 00-00-000")
        file.WriteLine("Factura por computador Nro. 1 al 1000")
        file.WriteLine("---------------------------------------------------------------")
        'If Trim(txtcomentario.Text) <> "" Then file.WriteLine(txtcomentario.Text)
        file.WriteLine("Impreso a la fecha y hora: " & Now)
        file.WriteLine("Factura elaborada por computadora en el Software")
        file.WriteLine("de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text)
        file.WriteLine("---------------------------------------------------------------")
        file.Close()
        Dim docName As String = "temp.txt"
        Dim docPath As String = "c:\"
        imprimir.DocumentName = docName
        Dim stream As New FileStream(docPath + docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        imprimir.Print()
    End Sub
    Public Sub GenerarTICKET2()

        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim nit As String = ""
        Dim nom As String = ""
        Dim dire As String = ""
        Dim tel As String = ""
        Dim email As String = ""
        Dim fec As String = ""
        Dim fac As String = ""
        Dim hr As String = ""
        Dim p As String = ""
        Dim vend As String = ""
        Dim tpago As String = ""
        Dim reso As String = ""
        Dim tfac As String = ""
        Dim tcomp As String = ""
        Dim pre As String = ""
        Dim coment As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString

        MiConexion(bda)
        Cerrar()

        sql2 = "select  " _
     & " CASE (Select f.tipodoc from facturas" & p & " f WHERE  f.doc = '" & txttipo.Text & txtnumfac.Text & "' ) " _
     & " WHEN pg.tipof1 " _
     & " THEN IF (pg.hr1='SI', " _
     & " CAST(CONCAT('R.DIAN:' ,pg.reso1, ' DE ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '') " _
     & " WHEN pg.tipof2 " _
     & " THEN IF (pg.hr2='SI', " _
     & " CAST(CONCAT('R.DIAN:' ,pg.reso2, ' DE ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '') " _
     & " WHEN pg.tipof3 " _
     & " THEN IF (pg.hr3='SI', " _
     & " CAST(CONCAT('R.DIAN:' ,pg.reso3, ' DE ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '') " _
     & " WHEN pg.tipof4 " _
     & " THEN IF (pg.hr4='SI', " _
     & " CAST(CONCAT('R.DIAN:' ,pg.reso4, ' DE ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '') " _
     & " END AS reso, " _
    & " CASE '" & txttipo.Text & "' " _
    & " WHEN pg.tipof1 THEN pg.pre1 " _
    & " WHEN pg.tipof2 THEN pg.pre2 " _
    & " WHEN pg.tipof3 THEN pg.pre3 " _
    & " WHEN pg.tipof4 THEN pg.pre4 " _
    & " END AS pref, " _
     & " CASE (Select f.tipodoc from facturas" & p & " f WHERE  f.doc = '" & txttipo.Text & txtnumfac.Text & "' ) " _
     & " WHEN pg.tipof1 " _
     & " THEN IF (pg.hr1='SI', " _
     & " CAST(CONCAT('RANGO FACT. ' ,pg.ini1, ' AL ',pg.fin1) AS CHAR(100)), '') " _
     & " WHEN pg.tipof2 " _
     & " THEN IF (pg.hr2='SI', " _
     & " CAST(CONCAT('RANGO FACT.' ,pg.ini2, ' AL ',pg.fin2) AS CHAR(100)), '') " _
     & " WHEN pg.tipof3 " _
     & " THEN IF (pg.hr3='SI', " _
     & " CAST(CONCAT('RANGO FACT. ' ,pg.ini3, ' AL ',pg.fin3) AS CHAR(100)), '') " _
     & " WHEN pg.tipof4 " _
     & " THEN IF (pg.hr4='SI', " _
     & " CAST(CONCAT('RANGO FACT. ' ,pg.ini4, ' AL ',pg.fin4) AS CHAR(100)), '') " _
     & " END AS tfac, " _
     & " (Select tipocompa from parafacts where factura= 'RAPIDA' ) as tcomp, " _
     & " ( select comentario from parafacts where factura= 'RAPIDA') as com  " _
    & " from parafacgral pg "

        Dim tabla3 As New DataTable
        tabla3 = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)
        If tabla3.Rows.Count > 0 Then
            pre = tabla3.Rows(0).Item("pref").ToString
            reso = tabla3.Rows(0).Item("reso").ToString
            tfac = tabla3.Rows(0).Item("tfac").ToString
            tcomp = tabla3.Rows(0).Item("tcomp").ToString
            coment = tabla3.Rows(0).Item("com").ToString
        End If

        Dim tabla2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT " & tabla2.Rows(0).Item("nit")
        tel = "TEL " & Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        dire = tabla2.Rows(0).Item("direccion")

        'Informacion Fact
        fac = "Factura de Venta No:" & pre & " " & txtnumfac.Text
        'hr = lbhora.Text.ToString
        fec = CambiaCadena(txtfecha.Value.ToString, 10) & " Hora:" & lbhora.Text.ToString
        vend = " " & txtnitv.Text & " " & txtvendedor.Text


        Dim vd As String = ""
        vd = valordes.Text.Replace(",", ".")

        sql3 = " SELECT iva_d , SUM( " _
        & " ( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & vd & "/100)))*(iva_d/100)) " _
        & " - ( " _
        & " ( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & vd & "/100)))*(iva_d/100)) * por_des/100) " _
        & " )as IVA FROM detafac" & p & " d WHERE d.doc='" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' GROUP BY iva_d "

        Dim tabla4 As New DataTable
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        If txtiva.Text <> "0,00" Then
            For i = 0 To tabla4.Rows.Count - 1
                If tabla4.Rows(i).Item(1).ToString <> 0 Then
                    v_iva = v_iva & Moneda2(tabla4.Rows(i).Item(1).ToString) & vbCrLf
                    tv_iva = tv_iva & "IVA " & (tabla4.Rows(i).Item(0).ToString) & " %" & vbCrLf
                End If
            Next
        Else
            tv_iva = "IVA "
            v_iva = "0,00"
        End If

        '...................

        Dim sql4 As String = ""
        sql4 = " SELECT  tipo, valor FROM facpagos" & p & "  WHERE doc=  '" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' "
        Dim tabla5 As New DataTable
        Dim conc As String = ""
        Dim t_conc As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql4
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        For i = 0 To tabla4.Rows.Count - 1
            't_conc = t_conc & "" & (tabla4.Rows(i).Item(0).ToString) & ": " & Moneda2(tabla4.Rows(i).Item(1).ToString) & " // "
            'conc = ""
            t_conc = t_conc & "" & (tabla4.Rows(i).Item(0).ToString) & vbCrLf
            conc = conc & Moneda2(tabla4.Rows(i).Item(1).ToString) & vbCrLf
        Next



        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql = " SELECT  d.doc , d.iva_d as cualfp, d.item as tipodoc, d.codart as idbod, d.nomart as nomart , " _
       & " d.cantidad as can_emp, (d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)) as precio, " _
       & " ((d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)) )* d.cantidad as nitv, " _
       & " (SELECT logofac FROM  parafacts where factura = 'RAPIDA') AS logofac, " _
       & " f.iva as numfact,  f.total as margmin" _
       & " FROM facturas" & p & " f INNER JOIN(detafac" & p & " d) ON f.doc = d.doc WHERE f.doc = '" & txttipo.Text & txtnumfac.Text & "' " _
       & " ORDER BY item"

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacTicket.rpt")
        CrReport.SetDataSource(tabla)
        ' FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        CrReport.SetParameterValue("comp", nom.ToString)
        CrReport.SetParameterValue("nit", nit.ToString)
        CrReport.SetParameterValue("dir", dire.ToString)
        CrReport.SetParameterValue("tel", tel.ToString)
        CrReport.SetParameterValue("fac", fac.ToString)
        CrReport.SetParameterValue("fec", fec.ToString)
        ' CrReport.SetParameterValue("hr", hr.ToString)
        CrReport.SetParameterValue("v_iva", v_iva.ToString)
        CrReport.SetParameterValue("tv_iva", tv_iva.ToString)
        CrReport.SetParameterValue("nomc", txtcliente.Text.ToString)
        CrReport.SetParameterValue("cc_cl", txtnitc.Text.ToString)
        CrReport.SetParameterValue("vend", vend.ToString)
        CrReport.SetParameterValue("des", txtdescuento.Text.ToString)
        CrReport.SetParameterValue("total", txttotal.Text.ToString)
        CrReport.SetParameterValue("reso", reso.ToString)
        CrReport.SetParameterValue("reso2", tfac.ToString)
        CrReport.SetParameterValue("tcomp", tcomp.ToString)
        CrReport.SetParameterValue("rtiv", txtriva.Text.ToString)
        CrReport.SetParameterValue("rtic", txtrica.Text.ToString)
        CrReport.SetParameterValue("rtf", txtrtefuente.Text.ToString)
        CrReport.SetParameterValue("coment", coment.ToString)
        CrReport.SetParameterValue("pago", t_conc.ToString)
        CrReport.SetParameterValue("vpagos", conc.ToString)


        CrReport.PrintToPrinter(1, False, 0, 0)
        'FrmVisorInformes.ShowDialog()
        CrReport.Dispose()


    End Sub
    Private Sub imprimir_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles imprimir.PrintPage

    End Sub

    'Private Sub txtcentrocosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentrocos.KeyPress
    '    If e.KeyChar = Chr(Keys.Enter) Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    'Private Sub txtcentrocosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentrocos.SelectedIndexChanged
    '    Try
    '        Dim tabla As New DataTable
    '        myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro=" & txtcentrocos.Text & ";"
    '        myAdapter.SelectCommand = myCommand
    '        myAdapter.Fill(tabla)
    '        Refresh()
    '        If tabla.Rows.Count > 0 Then
    '            txtcentro.Text = tabla.Rows(0).Item("nombre")
    '        Else
    '            txtcentro.Text = ""
    '        End If
    '    Catch ex As Exception
    '        txtcentro.Text = ""
    '    End Try
    'End Sub
    Private Sub cmdConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConceptos.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            'FrmOtrosConceptos.g_concep.Enabled = True
            FrmOtrosConceptosProv.g_concep.Enabled = True
            FrmOtrosConceptosProv.grilla.Enabled = True
            FrmOtrosConceptosProv.grilla.RowCount = 3
        Else
            'FrmOtrosConceptos.g_concep.Enabled = False
            FrmOtrosConceptosProv.g_concep.Enabled = False
            FrmOtrosConceptosProv.grilla.Enabled = False
        End If
        'Try
        '    For i = 0 To 2
        '        If i = 0 Then
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptos.Ch1.Checked = False
        '                    FrmOtrosConceptos.Ch1.Checked = True
        '                    FrmOtrosConceptos.cb1.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptos.txt1.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptos.valor1.Text = Moneda2(cbvalor.Items.Item(i))
        '                    FrmOtrosConceptos.cta1.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptos.lbdoc1.Text = lbanti1.Text
        '                Else
        '                    FrmOtrosConceptos.Ch1.Checked = True
        '                    FrmOtrosConceptos.Ch1.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptos.Ch1.Checked = True
        '                FrmOtrosConceptos.Ch1.Checked = False
        '            End Try
        '        ElseIf i = 1 Then
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptos.Ch2.Checked = False
        '                    FrmOtrosConceptos.Ch2.Checked = True
        '                    FrmOtrosConceptos.cb2.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptos.txt2.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptos.valor2.Text = Moneda2(cbvalor.Items.Item(i))
        '                    FrmOtrosConceptos.cta2.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptos.lbdoc2.Text = lbanti2.Text
        '                Else
        '                    FrmOtrosConceptos.Ch2.Checked = True
        '                    FrmOtrosConceptos.Ch2.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptos.Ch2.Checked = True
        '                FrmOtrosConceptos.Ch2.Checked = False
        '            End Try
        '        Else
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptos.Ch3.Checked = False
        '                    FrmOtrosConceptos.Ch3.Checked = True
        '                    FrmOtrosConceptos.cb3.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptos.txt3.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptos.valor3.Text = Moneda2(cbvalor.Items.Item(i))
        '                    FrmOtrosConceptos.cta3.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptos.lbdoc3.Text = lbanti3.Text
        '                Else
        '                    FrmOtrosConceptos.Ch3.Checked = True
        '                    FrmOtrosConceptos.Ch3.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptos.Ch3.Checked = True
        '                FrmOtrosConceptos.Ch3.Checked = False
        '            End Try
        '        End If
        '    Next
        'Catch ex As Exception
        'End Try
        'FrmOtrosConceptos.lbform.Text = "fn"
        'FrmOtrosConceptos.ShowDialog()
        'Try
        '    cbconcepto.SelectedIndex = 0
        'Catch ex As Exception
        'End Try
        'CalcularTotales()
        Try
            FrmOtrosConceptosProv.grilla.Rows.Clear()
            FrmOtrosConceptosProv.grilla.RowCount = cbsr.Items.Count + 2
            For j = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(j).ToString) <> "" Then
                    FrmOtrosConceptosProv.grilla.Item("sel", j).Value = True
                    FrmOtrosConceptosProv.grilla.Item("tipo", j).Value = cbsr.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("txt", j).Value = cbconcepto.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("valor", j).Value = Moneda2(cbvalor.Items.Item(j))
                    FrmOtrosConceptosProv.grilla.Item("base", j).Value = Moneda2(cbbase.Items.Item(j))
                    FrmOtrosConceptosProv.grilla.Item("cta", j).Value = cbcuenta.Items.Item(j)
                    Try
                        FrmOtrosConceptosProv.grilla.Item("ldoc", j).Value = cbldoc.Items.Item(j)
                    Catch ex As Exception
                        FrmOtrosConceptosProv.grilla.Item("ldoc", j).Value = ""
                    End Try
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        FrmOtrosConceptosProv.lbform.Text = "fn_sp"
        FrmOtrosConceptosProv.ShowDialog()
        Try
            cbconcepto.SelectedIndex = 0
        Catch ex As Exception
        End Try
        CalcularTotales()
    End Sub
    'COMBOS DE LOS CONCEPTOS
    Private Sub cbconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbconcepto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbconcepto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbconcepto.SelectedIndexChanged
        Try
            cbsr.SelectedIndex = cbconcepto.SelectedIndex
            cbvalor.SelectedIndex = cbconcepto.SelectedIndex
            cbcuenta.SelectedIndex = cbconcepto.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cbsr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbsr.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbsr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsr.SelectedIndexChanged
        Try
            cbconcepto.SelectedIndex = cbsr.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cbvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbvalor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbvalor.SelectedIndexChanged
        Try
            cbconcepto.SelectedIndex = cbvalor.SelectedIndex
        Catch ex As Exception
        End Try
        Try
            lbvalor.Text = Moneda2(cbvalor.Text)
        Catch ex As Exception
            lbvalor.Text = "0,00"
        End Try
    End Sub
    Private Sub cbcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbcuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcuenta.SelectedIndexChanged
        Try
            cbconcepto.SelectedIndex = cbcuenta.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub

    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        Try

            Dim cons As String = ""
            If txttipo.Text = lbdocajuste.Text Then
                cons = cons & "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
            Else

                Dim p As String = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> 12 Then
                        cons = cons & "SELECT * FROM facturas" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM facturas" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
                    End If
                Next
            End If
            Dim tf As New DataTable
            myCommand.CommandText = cons
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            Refresh()
            If tf.Rows.Count = 0 Then
                Try
                    txtnumfac.Text = NumeroDoc(txtnumfac.Text)
                Catch ex As Exception
                    txtnumfac.Text = NumeroDoc("0")
                End Try
            Else

                MsgBox("El numero del documento ya existe en el sistema", MsgBoxStyle.Information, "Verificacion")

                lbestado.Text = "CONSULTA"
                bloquear()

                Dim n As String = lbnumero.Text
                BuscarFactura(txttipo.Text & txtnumfac.Text)
                lbnumero.Text = n

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnumfac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumfac.TextChanged

    End Sub
    Private Sub txtcentrocosto_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentrocosto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtcentro, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcentrocosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCCs()
    End Sub
    Private Sub BuscarCCs()
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") <> "S" Then Exit Sub
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentrocosto.Text & "' and nivel ='centro';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtcentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentrocosto.Text
                txtcentrocosto.Text = ""
                FrmSelCentroCostos.lbform.Text = "FactAjus"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcentrocosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.TextChanged
        If txtcentrocosto.Text = "" Then
            txtcentro.Text = ""
        End If
    End Sub

    Public Sub BuscarFacturaAJ(ByVal numero As String)
        'Timer1.Enabled = False
        'PonerEnCero()
        BuscarPeriodo()
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT f. * , d. *   " _
                               & "FROM facturas" & FrmSelFacturaVenta.cmbper.Text & " f " _
                               & "LEFT JOIN (detafac" & FrmSelFacturaVenta.cmbper.Text & " d) " _
                               & "ON f.doc = d.doc " _
                               & "WHERE f.doc = '" & numero _
                               & "' ORDER BY d.item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("La factura no se encuentra en los registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If

        If Strings.Left(tabla.Rows(0).Item("descrip"), 7) = "ANULADO" Then
            lbAnula.Text = Strings.Left(tabla.Rows(0).Item("descrip"), 7)
        Else
            lbAnula.Text = ""
        End If

        txtsubtotal.Text = "0"
        txttotal.Text = "0"
        txtdescuento.Text = "0"
        lbdescuento.Text = "0"
        txtiva.Text = "0"
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        txtnitc_LostFocus(AcceptButton, AcceptButton) 'para buscar cliente
        txtnitv.Text = tabla.Rows(0).Item("nitv")
        txtnitv_LostFocus(AcceptButton, AcceptButton) 'para buscar vendedor
        txtsubtotal.Text = Moneda2(tabla.Rows(0).Item("subtotal"))
        'descuento
        valordes.Text = tabla.Rows(0).Item("por_desc")
        txtdescuento.Text = tabla.Rows(0).Item("descuento")
        'lbdescuento.Text = Moneda2(tabla.Rows(0).Item("descuento"))
        txtcuentadesc.Text = tabla.Rows(0).Item("cta_desc")
        'RETE FUENTE
        Try
            valor_rtfuente.Text = tabla.Rows(0).Item("por_ret_f")
            txtrtefuente.Text = tabla.Rows(0).Item("ret_f")
            txtctaretef.Text = tabla.Rows(0).Item("cta_ret_f")
        Catch ex As Exception
        End Try
        'RETE CREE
        Try
            valorretCree.Text = tabla.Rows(0).Item("por_rtc")
            txtretCre.Text = tabla.Rows(0).Item("rtc")
            txtcuentaCree.Text = tabla.Rows(0).Item("cta_rtc")
        Catch ex As Exception
        End Try
        'RETE ica
        Try
            valor_rtica.Text = tabla.Rows(0).Item("por_ret_ica")
            txtrica.Text = tabla.Rows(0).Item("ret_ica")
            txtctarica.Text = tabla.Rows(0).Item("cta_ret_ica")
        Catch ex As Exception
        End Try
        'RETE iva
        Try
            valor_rtiva.Text = tabla.Rows(0).Item("por_ret_iva")
            txtriva.Text = tabla.Rows(0).Item("ret_iva")
            txtctariva.Text = tabla.Rows(0).Item("cta_ret_iva")
        Catch ex As Exception
        End Try
        Try
            lbanti1.Text = tabla.Rows(0).Item("doc1").ToString
            lbanti2.Text = tabla.Rows(0).Item("doc2").ToString
            lbanti3.Text = tabla.Rows(0).Item("doc3").ToString
        Catch ex As Exception

        End Try
        'iva
        valoriva.Text = tabla.Rows(0).Item("por_iva")
        txtiva.Text = tabla.Rows(0).Item("iva")
        txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
        'total
        txttotal.Text = tabla.Rows(0).Item("total")
        txtcuentatotal.Text = tabla.Rows(0).Item("cta_total")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        txtvmto.Text = tabla.Rows(0).Item("vmto")
        cbaprobado.Enabled = True
        cbaprobado.Text = "AP"
        txtobserbaciones.Text = "AJUSTE FACTURA " & NumeroDoc(tabla.Rows(0).Item("num")) & ". AJUSTE DE " & cmbTipoAF.Text
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'lbentrega.Text = tabla.Rows(0).Item("entregar")
        'lbdir.Text = tabla.Rows(0).Item("dir_ent")
        'lbciudad.Text = tabla.Rows(0).Item("ciu_ent")
        'lborden.Text = tabla.Rows(0).Item("o_compra")
        'lbfecha.Text = tabla.Rows(0).Item("fecha_o")
        '*********************************************************
        txtvmto.Text = tabla.Rows(0).Item("vmto")
        txtcentrocosto.Text = tabla.Rows(0).Item("cc")
        If txtcentrocosto.Text <> "0" Then
            BuscarCCs()
        Else
            txtcentro.Text = ""
        End If
        lbestado.Text = "NUEVO"
        If Trim(tabla.Rows(0).Item("afecta")) = "SI" Then
            rbafecta1.Checked = True
        Else
            rbafecta2.Checked = True
        End If
        gfactura.RowCount = items + 1
        Dim suma As Double = 0
        Try
            Dim dct As Double = 0
            Dim base As Double = 0
            lbdescuento.Text = "0"
            For i = 0 To items - 1
                gfactura.Item(0, i).Value = tabla.Rows(i).Item("item")
                gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo_it")
                gfactura.Item(1, i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nomart")
                gfactura.Item("bodega", i).Value = tabla.Rows(i).Item("numbod")
                gfactura.Item(3, i).Value = Fraccion(tabla.Rows(i).Item("cantidad"))
                gfactura.Item(4, i).Value = tabla.Rows(i).Item("valor")
                gfactura.Item(5, i).Value = tabla.Rows(i).Item("vtotal")
                gfactura.Item("iva", i).Value = tabla.Rows(i).Item("iva_d")
                'descuento
                gfactura.Item("descuento", i).Value = Moneda2(tabla.Rows(i).Item("por_des"))
                Try
                    base = tabla.Rows(i).Item("vtotal") / (1 + (tabla.Rows(i).Item("iva_d") / 100))
                Catch ex As Exception
                    base = 0
                End Try
                Try
                    dct = dct + (base * tabla.Rows(i).Item("por_des") / 100)
                Catch ex As Exception
                End Try
                lbdescuento.Text = dct
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                gfactura.Item("cc", i).Value = tabla.Rows(i).Item("concep")
                gfactura.Item("nit", i).Value = tabla.Rows(i).Item("nit")
                gfactura.Item("precio2", i).Value = Moneda2(0)
                suma = suma + tabla.Rows(i).Item("vtotal")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try 'CONCEPTOS
            cbconcepto.Items.Clear()
            cbsr.Items.Clear()
            cbvalor.Items.Clear()
            cbcuenta.Items.Clear()
            If Trim(tabla.Rows(0).Item("o_con")) = "si" Then 'hay otros conceptos
                Dim tipo As String = ""
                For i = 1 To 3
                    tipo = "t" & i 'tipo de concepto (1,2 o 3)
                    If Trim(tabla.Rows(0).Item(tipo)) <> "" Then
                        cbsr.Items.Add(tabla.Rows(0).Item(tipo))
                        tipo = "d" & i 'descripcion (1,2 o 3)
                        cbconcepto.Items.Add(tabla.Rows(0).Item(tipo))
                        tipo = "v" & i 'valor (1,2 o 3)
                        cbvalor.Items.Add(Moneda2(tabla.Rows(0).Item(tipo)))
                        tipo = "cta" & i 'cuenta (1,2 o 3)
                        cbcuenta.Items.Add(tabla.Rows(0).Item(tipo))
                    End If
                Next
                Try
                    cbconcepto.SelectedIndex = 0
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
        FormasDePago(numero)
        'Desbloquear()
        ' ........................    FORMA DE PAGO
        fpagoAJ = ""
        Dim tp As New DataTable
        myCommand.CommandText = "SELECT * FROM facpagos" & FrmSelFacturaVenta.cmbper.Text & " WHERE doc = '" & numero & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Refresh()
        If tp.Rows.Count > 0 Then
            For i = 0 To tp.Rows.Count - 1
                gfp.Item("cual", i).Value = tp.Rows(i).Item("tipo").ToString
                gfp.Item("detalle", i).Value = tp.Rows(i).Item("descrip").ToString
                gfp.Item("tt", i).Value = tp.Rows(i).Item("tt").ToString
                gfp.Item("banco", i).Value = tp.Rows(i).Item("banco").ToString
                gfp.Item("numero", i).Value = tp.Rows(i).Item("numero").ToString
                gfp.Item("monto", i).Value = Moneda2(tp.Rows(i).Item("valor"))
                If tp.Rows(i).Item("tipo").ToString = "Otra" Then
                    fpagoAJ = "credito"
                Else
                    fpagoAJ = ""
                End If
            Next
        End If
        lbsubtotal.Text = suma
        cmditems.Enabled = True
        CalcularTotales()
        '...........................

    End Sub
    Dim fpagoAJ As String

    Private Sub cmdNuevoAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevoAF.Click
        If lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        txtAF.Text = ""
        FrmSelFacturaVenta.cmbper.Enabled = True
        FrmSelFacturaVenta.cmbper.Text = PerActual(0) & PerActual(1)
        FrmSelFacturaVenta.lbform.Text = "fnAj"
        FrmSelFacturaVenta.ShowDialog()
        FrmSelFacturaVenta.cmbper.Enabled = False
        If txtAF.Text <> "" Then
            cmdNuevo_Click(AcceptButton, AcceptButton)
            txttipo.Text = lbdocajuste.Text
            txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
            txtdocafec.Text = txtAF.Text
            txtnitc.Enabled = False
            txtnitv.Enabled = False
            cmbTipoAF.Enabled = True
            BuscarFacturaAJ(txtdocafec.Text)
        End If
    End Sub

    Private Sub cmbTipoAF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoAF.SelectedIndexChanged
        If cmbTipoAF.Text = "Disminuir Valores" Then
            rbafecta2.Checked = True
        Else
            rbafecta1.Checked = True
        End If
        txtobserbaciones.Text = "AJUSTE FACTURA " & txtdocafec.Text & ". AJUSTE DE " & cmbTipoAF.Text
    End Sub
    Private Sub llenarDatosAudi()
        txtnitc2.Text = txtnitc.Text
        txtnitv2.Text = txtnitv.Text
        cbaprobado2.Text = cbaprobado.Text
        txtvmto2.Text = txtvmto.Text
        txtobserbaciones2.Text = txtobserbaciones.Text
        txtcentro2.Text = txtcentro.Text
        txttotal2.Text = txttotal.Text
        txtfecha2.Text = txtfecha.Value.ToString
        gfactura2.Rows.Clear()
        gfactura2.RowCount = gfactura.RowCount
        For i = 0 To gfactura2.RowCount - 1
            Try


                gfactura2.Item("num2", i).Value = gfactura.Item("num", i).Value
                gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", i).Value
                gfactura2.Item("descrip2", i).Value = gfactura.Item("descrip", i).Value
                gfactura2.Item("cant2", i).Value = gfactura.Item("cant", i).Value
                gfactura2.Item("valor2", i).Value = gfactura.Item("valor", i).Value
                gfactura2.Item("tipo2", i).Value = gfactura.Item("tipo", i).Value
                gfactura2.Item("bodega2", i).Value = gfactura.Item("bodega", i).Value
                gfactura2.Item("cc2", i).Value = gfactura.Item("cc", i).Value
                gfactura2.Item("descuento2", i).Value = gfactura.Item("descuento", i).Value
                gfactura2.Item("nit2", i).Value = gfactura.Item("nit", i).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
    End Sub

    Private Sub valorretCree_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valorretCree.KeyPress
        ValidarPorcentaje(valorretCree, e)
    End Sub

    Private Sub valorretCree_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles valorretCree.LostFocus
        CalcularTotales()
    End Sub

    Private Sub txtcuentaCree_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaCree.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fac_rtc_sp"
        FrmCuentas.ShowDialog()
    End Sub
End Class