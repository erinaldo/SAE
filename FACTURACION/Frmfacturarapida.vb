Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object


Public Class Frmfacturarapida

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            Cerrar()
        Catch ex As Exception
        End Try
        If Trim(txtnitc.Text) = "" Then
            MsgBox("Digite los datos del cliente", MsgBoxStyle.Information, "SAE")
            txtnitc.Focus()
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        FrmItems.txtnumfac.Text = txtnumfac.Text
        FrmItems.txtfecha.Text = txtfecha.Text
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
                Try
                    If lbprecioiva.Text = "NO" Then
                        pre = CDbl(tb.Rows(0).Item(0))
                        'pre = CDbl(gfactura.Item(4, i).Value) / (1 + (gfactura.Item("iva", i).Value / 100))
                    Else
                        pre = CDbl(gfactura.Item(4, i).Value)
                    End If
                Catch ex As Exception
                    pre = CDbl(gfactura.Item(4, i).Value)
                End Try

                If lb_imp_dec.Text = "S" Then
                    pre = CDbl(gfactura.Item(4, i).Value)
                End If
                FrmItems.gitems.Item("num", i).Value = i + 1
                FrmItems.gitems.Item("tipo", i).Value = gfactura.Item("tipo", i).Value
                FrmItems.gitems.Item("codigo", i).Value = gfactura.Item(1, i).Value
                FrmItems.gitems.Item("descrip", i).Value = gfactura.Item(2, i).Value
                FrmItems.gitems.Item("cant", i).Value = gfactura.Item(3, i).Value
                'FrmItems.gitems.Item("precio", i).Value = gfactura.Item(4, i).Value
                FrmItems.gitems.Item("precio", i).Value = pre
                FrmItems.gitems.Item("bodega", i).Value = gfactura.Item(7, i).Value
                FrmItems.gitems.Item("iva", i).Value = gfactura.Item("iva", i).Value
                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
                FrmItems.gitems.Item("descuento", i).Value = Moneda2(gfactura.Item("descuento", i).Value, lb_imp_dec.Text)
                FrmItems.gitems.Item("nit", i).Value = gfactura.Item("nit", i).Value.ToString
                FrmItems.gitems.Item("precio2", i).Value = gfactura.Item("precio2", i).Value
                'FrmItems.gitems.Item("preiva", i).Value = gfactura.Item("precio2", i).Value
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
        FrmItems.lbform.Text = "fr"
        FrmItems.LbTipoMov.Text = "salidas"
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
                ValidarNIT(txtnitc, e)
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
            FrmSelCliente.lbform.Text = "fr"
            FrmSelCliente.ShowDialog()
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
                frmterceros.lbform.Text = "fr"
                frmterceros.txtnit.Text = txtnitc.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtnitv.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(  apellidos,' ',nombre)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txtnitc.Text = ""
            txtcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "fr"
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtnitv.Focus()
                chcli.Checked = False
                txtnitc_LostFocus(AcceptButton, AcceptButton)
            End If
        Else  'mostrar uno solo q coinside
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
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
            FrmSelVendedor.lbform.Text = "fr"
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Buscarvendedor()
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        If lbestado.Text = "NUEVO" Then
            myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "' and estado='activo' ;"
        Else
            myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "'  ;"
        End If
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
                Try
                    vt = CDbl(gfactura.Item("Vtotal", i).Value) / (1 + (CDbl(gfactura.Item("iva", i).Value) / 100)) 'base
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
                    desc = vt * (CDbl(valordes.Text) / 100)
                    'desc = vt * (CDbl(valordes.Text) / 100) 
                Catch ex As Exception
                    desc = 0
                End Try

                ' desc = CDbl(lbdescuento.Text)
                sd = sd + desc
                ' sd = desc
                Try
                    vt = vt - desc 'nueva base
                Catch ex As Exception
                    vt = 0
                End Try
                base = base + vt
                Try
                    x = vt * (CDbl(gfactura.Item("iva", i).Value) / 100)
                    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                    x = 0
                End Try
                v_iva = v_iva + x
            Next
            txtiva.Text = Moneda2(v_iva, lb_imp_dec.Text)
        Catch ex As Exception
            txtiva.Text = Moneda2(v_iva, lb_imp_dec.Text)
            valoriva.Text = "0,00"
        End Try

        Try
            valordes.Text = Format(CDbl(valordes.Text), "0.00")
        Catch ex As Exception
            valordes.Text = "0,00"
        End Try
        'txtiva.Text = Moneda2(CDbl(valoriva.Text) * CDbl(lbsubtotal.Text) / 100)
        '  txtdescuento.Text = Moneda2(sd + lbdescuento.Text)
        txtdescuento.Text = Moneda2(sd, lb_imp_dec.Text)
        ' lbdescuento.Text = Moneda2(sd)
        txtsubtotal.Text = Moneda2(st, lb_imp_dec.Text)
        txttotal.Text = Moneda2(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtdescuento.Text), lb_imp_dec.Text)
        ' txttotal.Text = Moneda2(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(lbdescuento.Text))
        If cbsr.Items.Count > 0 Then
            For i = 0 To cbsr.Items.Count - 1
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        txttotal.Text = Moneda2(CDbl(txttotal.Text) + CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        txttotal.Text = Moneda2(CDbl(txttotal.Text) - CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        If gfp.RowCount = 1 Then
            gfp.Item("monto", 0).Value = txttotal.Text
        End If
    End Sub
    '///////////////////////////////////////////
    Public Sub PonerEnCero()
        Timer1.Enabled = False
        lbhora.Text = "00:00:00"
        lbestado.Text = "NULO"
        cmditems.Enabled = False
        txttipo.Enabled = False
        lbAnula.Text = ""
        txttipo2.Text = ""
        txtnumfac.Text = ""
        lbnumero.Text = ""
        txtremision.Text = ""
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
        lbanti1.Text = ""
        lbanti2.Text = ""
        lbanti3.Text = ""
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtnitv.Text = ""
        txtvendedor.Text = ""
        txtsubtotal.Text = "0,00"
        txtdescuento.Text = "0,00"
        lbdescuento.Text = "0"
        txtiva.Text = "0,00"
        txttotal.Text = "0,00"
        valordes.Text = "0"
        lbsubtotal.Text = "0,00"
        gfactura.RowCount = 1
        txtcuentadesc.Text = ""
        txtcuentaiva.Text = ""
        txtcuentatotal.Text = ""
        cbaprobado.Text = ""
        lbusuario.Text = ""
        txtvmto.Text = "0"
        txtobserbaciones.Text = ""
        txtfecha.Enabled = False
        grupoafecta.Enabled = False
        'txtcentrocos.Enabled = False
        cbaprobado.Enabled = False
        txtcuentaiva.Enabled = False
        txtcuentadesc.Enabled = False
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
        Try
            fvmto.Value = txtfecha.Value
        Catch ex As Exception
        End Try
        CalcularTotales()
        txtpagado.Text = Moneda2("0", lb_imp_dec.Text)
        lbcambio.Text = Moneda2("0", lb_imp_dec.Text)
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
        If FrmPrincipal.Inventarios.Enabled = True Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        chcli.Enabled = False
        chcli.Checked = False
        txtcliente.Enabled = False
        txtnitc.Enabled = False
        txtnitv.Enabled = False
        txtfecha.Enabled = False
        cbaprobado.Enabled = False
        fvmto.Enabled = False
        cmditems.Enabled = False
        'txtcentrocos.Enabled = False
        '******impuestos ************
        valordes.Enabled = False
        valoriva.Enabled = False
        txtvmto.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        Button2.Enabled = False
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        '******* conceptos ***********
        cbconcepto.Enabled = False
        cbsr.Enabled = False
        cbvalor.Enabled = False
        cbcuenta.Enabled = False
        '...cc
        txtcentrocosto.Enabled = False

    End Sub
    Public Sub Desbloquear()
        chcli.Enabled = True
        chcli.Checked = False
        txtnitc.Enabled = True
        txtnitv.Enabled = True
        txtfecha.Enabled = True
        cbaprobado.Enabled = True
        fvmto.Enabled = True
        cmditems.Enabled = True
        '******impuestos ************
        valordes.Enabled = True
        valoriva.Enabled = True
        txtvmto.Enabled = True
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        Button2.Enabled = False
        Button2.Enabled = True
        'Button2.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        '******* conceptos ***********
        cmdConceptos.Enabled = True
        cbconcepto.Enabled = True
        cbsr.Enabled = True
        cbvalor.Enabled = True
        cbcuenta.Enabled = True
        '....
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
        BuscarPeriodo()
        PonerEnCero()
        lbestado.Text = "NUEVO"
        Try
            Cerrar()
        Catch ex1 As Exception
        End Try
        Try
            Desbloquear()
            Parametros()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lbusuario.Text = FrmPrincipal.lbuser.Text
        ' txtnitv.Text = 0
        ' Buscarvendedor()
        ' cmditems.Enabled = True
        txttipo.Enabled = True
        Timer1.Enabled = True
        lbhora.Text = Format(Now, "HH:mm:ss")
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        CalcularTotales()
        txtpagado.Text = Moneda2("0", lb_imp_dec.Text)
        lbcambio.Text = Moneda2("0", lb_imp_dec.Text)
        MiConexion(bda)
        If lbgf.Text = "S" Then
            ValidarConsecutivo()
        End If
        Try
            fvmto.Value = DateAdd("d", CInt(txtvmto.Text), txtfecha.Value)
        Catch ex As Exception
        End Try
        Cerrar()
        chcli.Focus()
    End Sub
    Public usacontf As String
    Public Sub Parametros()
        Dim tabla As New DataTable
        '*********************FACTURA RAPIDA********************************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='RAPIDA';"
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
                ruta = My.Application.Info.DirectoryPath & "\" & "ven_fr.txt"
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
        ''''''''''''''''''BUSCAR CLIENTE '''''''''''''''''''''''''''''''
        If tabla.Rows(0).Item("bus_cli").ToString = "N" Then
            chcli.Checked = False
        Else
            chcli.Checked = True
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
                    campo = "ctapc"
                    txtvmto.Text = "30"
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
        usacontf = ""
        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then
            '.. Parametros inventarios
            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT contable FROM parinven ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            Try
                usacontf = tp.Rows(0).Item(0)
            Catch ex As Exception
                usacontf = "no"
            End Try
            If lbestado.Text = "NUEVO" Then
                valoriva.Text = tabla.Rows(0).Item("porivapp")
                txtcuentaiva.Text = tabla.Rows(0).Item("ivapp")
                valordes.Text = "0,00"
                txtcuentadesc.Text = tabla.Rows(0).Item("descuento")
                txtcuentatotal.Text = tabla.Rows(0).Item(campo)
            End If
            txtcuentaiva.Enabled = True
            txtcuentadesc.Enabled = True
            txtcuentatotal.Enabled = True
        Else
            usacontf = "no"
            If lbestado.Text = "NUEVO" Then
                valoriva.Text = "0,00"
                txtcuentaiva.Text = ""
                valordes.Text = "0,00"
                txtcuentadesc.Text = ""
                txtcuentatotal.Text = ""
            End If
            txtcuentaiva.Enabled = False
            txtcuentadesc.Enabled = False
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
        Try
            If lbestado.Text = "NUEVO" Then
                ValidarGuardar()
            ElseIf lbestado.Text = "EDITAR" Then
                ValidarModificar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
            CalcularTotales()
        Catch ex As Exception
            GuardarError(ex.ToString, "FACT", "GuardarFacturaV")
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
                If (CDbl(tbc.Rows(0).Item(0)) - CDbl(gfactura.Item(3, fila).Value)) < 0 Then
                    MsgBox("La cantidad disponible del articulo " & gfactura.Item("codigo", fila).Value & ", es " & tbc.Rows(0).Item(0) & " , Verifique", MsgBoxStyle.Information, "Verifique")
                    Return (False)
                    Exit Function
                End If
                Return (True)
            Else
                Return (True)
            End If
        Catch ex As Exception
            Return (True)
        End Try
    End Function
    Public Sub GuardarAnticipos()
        'otros conceptos
        Dim sql As String = ""
        For i = 0 To 2
            If i = 0 Then
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado + " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti1.Text) & "';"
                        'MsgBox(sql)
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                End Try
            ElseIf i = 1 Then
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado + " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti2.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_de_clie SET causado = causado + " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti3.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        If lbestado.Text <> "CONSULTA" Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
            cmdConceptos.Enabled = True
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
                    limpiarDatosAudi()
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
        FrmSelFacturaVenta.lbform.Text = "fr"
        FrmSelFacturaVenta.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            Dim n As String = lbnumero.Text
            BuscarFactura(txttipo.Text & txtnumfac.Text)
            lbnumero.Text = n
        End If
    End Sub
    '////////// ELIMINAR ///////////////////////////////////////////////////
    Public Sub Eliminar()
        Try
            MiConexion(bda)
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
                    myCommand.CommandText = "DELETE FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  " _
                                          & "DELETE FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "'  ;" _
                                          & "DELETE FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  " _
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
            Cerrar()
        Catch ex As Exception
            Cerrar()
            MsgBox(ex.ToString)
        End Try

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
        ElseIf txtnitc.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcliente.Focus()
            Exit Sub
        ElseIf txtvendedor.Text = "" Then
            MsgBox("No ha digitado datos del vendedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitv.Focus()
            Exit Sub
        ElseIf txtcuentatotal.Text.Length < 10 Then
            If nivel_cuenta(Trim(txtcuentatotal.Text)) = False Then
                MsgBox("No ha escogido forma de pago o la cuenta Auxiliar, Verifique los parametros.  ", MsgBoxStyle.Information, "Editar Factura ")
                txtcuentatotal.Focus()
                Exit Sub
            End If
        ElseIf CDbl(txttotal.Text) <= 0 And CDbl(lbvalor.Text) = 0 Then
            MsgBox("El total a pagar deber mayor que cero (0), Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            cmditems.Focus()
            Exit Sub
        End If

        If txtdescuento.Text <> "0,00" And txtcuentadesc.Text.Length < 10 Then
            If nivel_cuenta(Trim(txtcuentadesc.Text)) = False Then
                MsgBox("No ha Seleccionado la  cuenta auxiliar para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
                txtcuentadesc.Focus()
                Exit Sub
            End If
        ElseIf txtiva.Text <> "0,00" And txtcuentaiva.Text.Length < 10 Then
            If nivel_cuenta(Trim(txtcuentaiva.Text)) = False Then
                MsgBox("No ha escogido cuenta para el IVA, Verifique los parametros.  ", MsgBoxStyle.Information, "Editar Factura ")
                txtcuentaiva.Focus()
                Exit Sub
            End If
        End If

        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text)
        Next
        If sumafp <> Moneda2(txttotal.Text, lb_imp_dec.Text) Or gfp.Item("cual", 0).Value = "" Then
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
        '''''' VALIDAR SI EXIXTE FACTURA '''''''''''''''''
        Dim sw As Integer = 0
        Dim conta As Integer = 0
        Do
            Dim cons As String = ""
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

            Dim t As New DataTable
            myCommand.CommandText = cons
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()

            'If t.Rows.Count = 0 Then
            'Dim t As New DataTable
            'myCommand.CommandText = "SELECT doc FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            'myAdapter.SelectCommand = myCommand
            'myAdapter.Fill(t)
            'Refresh()
            If t.Rows.Count > 0 Then
                If txtnumfac.Enabled = True Then
                    MsgBox("Verifique el numero de factura, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
                    txtnumfac.Focus()
                    Exit Sub
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
            Else
                sw = 1
            End If
        Loop While sw = 0
        Dim ap As String = ""
        ap = par_guar()
        If ap = "S" Then
            If cbaprobado.Text <> "AP" Then
                MsgBox("No se puede guardar la Factura si no esta Aprobada", MsgBoxStyle.Exclamation, "Verifique")
                cbaprobado.Text = "AP"
                Exit Sub
            End If
        End If
        Refresh()
        If Trim(txttipo.Text) = "" Then
            MsgBox("Verifique el tipo de documento para poder guardar la factura.", MsgBoxStyle.Information, "Control de Facturas")
            txttipo.Focus()
            Exit Sub
        End If

        'PARAMETRO LISTAR ARTIC CON EXISTENCIA PARA VALIDAR CANTI
        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows(0).Item(0) = "SI" And rbafecta1.Checked = True And cbaprobado.Text = "AP" Then
            '...VALIDAR CANTIDAD DISPONIBLE ...
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("codigo", i).Value <> "" And gfactura.Item("tipo", i).Value = "I" Then
                    If ValidarCantidades(i) = False Then
                        Exit Sub
                    End If
                End If
            Next
        End If

        validarcuentas()
        GuardarFactura()
    End Sub
    Public Function par_guar()

        Dim par As String = ""

        Dim tb As New DataTable
        tb.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT Guar_Ap FROM parafacgral ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            par = tb.Rows(0).Item(0)
        End If
        Return par
    End Function
    Public Sub GuardarFactura()
        If Trim(txttipo.Text.ToString) = "" Then
            MsgBox("Verifique el tipo de documento para poder guardar la factura.", MsgBoxStyle.Information, "Control de Facturas")
            txttipo.Focus()
            Exit Sub
        End If
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
        myCommand.Parameters.AddWithValue("?subtotal", DIN(Moneda2(txtsubtotal.Text, lb_imp_dec.Text)))
        'descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        ' myCommand.Parameters.AddWithValue("?descuento", DIN(lbdescuento.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(Moneda2(txtdescuento.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_ret_f", "0")
        myCommand.Parameters.AddWithValue("?ret_f", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_f", "")
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(Moneda2(txtiva.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'rete_iva
        myCommand.Parameters.AddWithValue("?por_ret_iva", "0")
        myCommand.Parameters.AddWithValue("?ret_iva", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_iva", "")
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", "0")
        myCommand.Parameters.AddWithValue("?rtc", "0")
        myCommand.Parameters.AddWithValue("?cta_rtc", "")
        'ret_ica
        myCommand.Parameters.AddWithValue("?por_ret_ica", "0")
        myCommand.Parameters.AddWithValue("?ret_ica", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_ica", "")
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(Moneda2(txttotal.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'datos de entega
        myCommand.Parameters.AddWithValue("?entregar", "")
        myCommand.Parameters.AddWithValue("?dir_ent", "")
        myCommand.Parameters.AddWithValue("?ciu_ent", "")
        myCommand.Parameters.AddWithValue("?o_compra", "")
        myCommand.Parameters.AddWithValue("?fecha_o", "")
        myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
        myCommand.Parameters.AddWithValue("?val_aj", DIN(0))
        'otros conceptos
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
        'For i = 0 To 2
        '    If i = 0 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?o_con", "si")
        '                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v1", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
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
        '                myCommand.Parameters.AddWithValue("?v2", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
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
        '                myCommand.Parameters.AddWithValue("?v3", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
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
        Try
            myCommand.CommandText = "INSERT INTO facturas" & PerActual(0) & PerActual(1) & " VALUES (?doc,?num,?tipodoc,?doc_de,?nitc,?nitv,?usuario,?fecha,?hora,?descrip,?doc_afec,?afecta," _
                             & "?subtotal,?por_desc,?descuento,?cta_desc,?por_ret_f,?ret_f,?cta_ret_f,?por_iva,?iva,?cta_iva,?por_ret_iva,?ret_iva,?cta_ret_iva,?por_ret_ica,?ret_ica,?cta_ret_ica," _
                             & "?total,?cta_total,?estado,?observ,?vmto,?entregar,?dir_ent,?ciu_ent,?o_compra,?fecha_o,?cc," _
                             & "?o_con,?t1,?d1,?v1,?cta1,?t2,?d2,?v2,?cta2,?t3,?d3,?v3,?cta3,?doc1,?doc2,?doc3,?val_aj,?por_rtc,?rtc,?cta_rtc);"
            myCommand.ExecuteNonQuery()
            Refresh()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Try
                Cerrar()
            Catch ex1 As Exception
            End Try
            'Dim rs As MsgBoxResult
            'rs = MsgBox("Hubo un error al guardar la factura, ¿Desea continuar? ", MsgBoxStyle.YesNo, "Confirmacion")
            'If rs = MsgBoxResult.Yes Then
            ValidarGuardar()
            'End If
            Exit Sub
        End Try
        Refresh()
        If lbgf.Text <> "S" Then ' ACTUALIZAR No D FACTURA ANTES. SEGUN PARAMETRO
            ValidarConsecutivo()
        End If
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
            GuardarCOBDPEN()
            If txtremision.Text = "" Then
                GuardarMoviInvetarios(total_inv) 'si hay movi de inventarios y si afecta inventarios
            End If
        End If

        ' ACTUALIZAR TAB MOVIMIENTOS//////////
        If txtremision.Text <> "" Then
            Dim cp(), ftr(), ft As String
            cp = txtremision.Text.Split(";")
            For i = 0 To cp.Length - 1
                ft = Trim(cp(i))
                ftr = ft.Split("-")
                myCommand.Parameters.Clear()
                myCommand.CommandText = " UPDATE  `movimientos" & ftr(1) & "` SET  `o_compra` =  'FAC' WHERE doc='" & ftr(0) & "'"
                myCommand.ExecuteNonQuery()
                Refresh()
            Next
            'myCommand.Parameters.Clear()
            'myCommand.CommandText = " UPDATE  `movimientos" & PerActual(0) & PerActual(1) & "` SET  `o_compra` =  'FAC' WHERE doc='" & txtremision.Text & "'"
            'myCommand.ExecuteNonQuery()
            'Refresh()
        End If
        '///////////
        '.....
        If cbsr.Items.Count <> 0 Then
            GuardarOtrosConcep()
        End If
        '.....
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
        txtremision.Text = ""
        CalcularTotales()
        cmdPrint_Click(AcceptButton, AcceptButton)

    End Sub
    Private Sub GuardarOtrosConcep()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                     & " WHERE doc ='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        If cbsr.Items.Count <> 0 Then
            Try
                For j = 0 To cbsr.Items.Count - 1
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
                    myCommand.Parameters.AddWithValue("?itm", j + 1)
                    myCommand.Parameters.AddWithValue("?sg", cbsr.Items.Item(j))
                    myCommand.Parameters.AddWithValue("?des", CambiaCadena(cbconcepto.Items.Item(j), 99))
                    myCommand.Parameters.AddWithValue("?v", DIN(Moneda(cbvalor.Items.Item(j))))
                    myCommand.Parameters.AddWithValue("?b", DIN(Moneda(cbbase.Items.Item(j))))
                    myCommand.Parameters.AddWithValue("?cta", cbcuenta.Items.Item(j))
                    myCommand.Parameters.AddWithValue("?docAn", cbldoc.Items.Item(j))
                    myCommand.CommandText = "INSERT INTO otcon_fac" & PerActual(0) & PerActual(1) & " " _
                                          & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                    myCommand.ExecuteNonQuery()
                Next
            Catch ex As Exception
                MsgBox("Error al registrar los otros conceptos, " & ex.ToString, MsgBoxStyle.Information, "Error")
            End Try

        End If
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?tipo_it", gfactura.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item(1, fila).Value)
            myCommand.Parameters.AddWithValue("?descrip", gfactura.Item(2, fila).Value)
            myCommand.Parameters.AddWithValue("?numbod", Val(gfactura.Item("bodega", fila).Value))
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
            myCommand.Parameters.AddWithValue("?valor", DIN(Moneda2(gfactura.Item(4, fila).Value, lb_imp_dec.Text)))
            myCommand.Parameters.AddWithValue("?vtotal", DIN(Moneda2(gfactura.Item(5, fila).Value, lb_imp_dec.Text)))
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
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_VENTAS", "GuardarDetalle")
        End Try

    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            If gfactura.Item("tipo", fila).Value = "S" Then Exit Sub
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            myCommand.CommandText = "UPDATE con_inv SET cant" & gfactura.Item("bodega", fila).Value & "=cant" & gfactura.Item("bodega", fila).Value & " - ?cantidad " _
                                  & " WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_VENTAS", "GuardarEnBodega")
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

                For i = 0 To gfp.RowCount - 1 'FORMAS DE PAGO
                    If gfp.Item(0, i).Value <> "" Then
                        If gfp.Item("cual", i).Value.ToString = "Cheque" Then
                            Vali_cuent_fac("ban", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                        ElseIf gfp.Item("cual", i).Value.ToString = "Tarjeta" Then
                            Vali_cuent_fac("ban", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                        ElseIf gfp.Item("cual", i).Value.ToString = "Efectivo" Then
                            Vali_cuent_fac("caj", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                        ElseIf gfp.Item("cual", i).Value.ToString = "Otra" Then
                            Vali_cuent_fac("cxc", "FC-FACTURA DE VENTA", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                        End If
                    End If
                Next
                ' ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡ fin  AUDITORIA ¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡
            Catch ex As Exception
                MsgBox("Error al Auditar " & ex.ToString, MsgBoxStyle.Information, "SAE")
                bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(FrmPrincipal.LbPeriodo.Text, 4)
            End Try
        End If
    End Sub
    Public Sub GuardarPagos(ByVal fila As Integer)
        Try
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
            myCommand.Parameters.AddWithValue("?valor", DIN(Moneda2(gfp.Item("monto", fila).Value, lb_imp_dec.Text)))
            'INSERTAR FORMAS DE PAGO
            myCommand.CommandText = "INSERT INTO facpagos" & PerActual(0) & PerActual(1) & " VALUES(?doc,?tipo,?descrip,?tt,?banco,?numero,?valor)"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_VENTAS", "GuardarPagos")
        End Try
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
                MovimientoContable(i, "total", txtcuentatotal.Text, "VR. TOTAL " & gfp.Item("cual", i).Value & Trim(txtcliente.Text), "")
            Next
            '************
            'grilla.RowCount = grilla.RowCount + 1
            'MovimientoContable(0, "total", txtcuentatotal.Text, "VR. TOTAL " & Trim(txtcliente.Text))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "desc", txtcuentadesc.Text, "DESCUENTO " & Trim(txtcliente.Text), "")
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
                If txtremision.Text = "" Then ' remision
                    If gfactura.Item("tipo", i).Value = "I" And rbafecta1.Checked = True Then 'TIPO I ^ AFECTA INVENTARIOS
                        MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, Trim(txtcliente.Text) & " A 1435 ", "")
                        MovimientoContable(i, "cventa", gfactura.Item("ctacven", i).Value, Trim(txtcliente.Text) & " A VENTAS ", "")
                    End If
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
            myCommand.Parameters.AddWithValue("?centro", Val(txtcentrocos.Text))
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(Moneda2(grilla.Item("Debitos", fila).Value, lb_imp_dec.Text)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(Moneda2(grilla.Item("Creditos", fila).Value, lb_imp_dec.Text)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(Moneda2(grilla.Item("base", fila).Value, lb_imp_dec.Text)))
            myCommand.Parameters.AddWithValue("?diasv", Val(txtvmto.Text))
            If Val(txtvmto.Text) > 0 Then
                Dim fec As Date = DateAdd("d", Val(txtvmto.Text), txtfecha.Value)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            '  Try
            If grilla.Item("nitc", fila).Value = "" Then
                myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            Else
                myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
            End If
            'Catch ex As Exception
            'MsgBox(ex.ToString)
            '   myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            '  End Try
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
            GuardarError(ex.ToString, "FAC_VENTAS", "InsertarContable")
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String, ByVal nit As String)
        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des, nit2 As String
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
                nit2 = grilla.Item("nitc", j).Value.ToString
            Catch ex As Exception
                nit2 = ""
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
            ElseIf cad = cuenta And nit = nit2 Then
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
        Select Case tipo
            Case "ing"
                Try
                    base = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDbl(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                Try
                    desc = base * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                monto = base - desc
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                grilla.Item("Debitos", j).Value = db
                grilla.Item("Creditos", j).Value = cr + monto
            Case "iva"
                Try 'base sin descuento
                    b2 = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDbl(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                Try
                    desc = b2 * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    desc = b2 * (CDbl(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    base = base + b2  'base acomulada + nueva base
                Catch ex As Exception
                End Try
                Try
                    'iva = CDbl(gfactura("Vtotal", fo).Value) * CDbl(gfactura("iva", fo).Value) / 100
                    iva = b2 * (CDbl(gfactura.Item("iva", fo).Value) / 100)
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = iva
                grilla.Item("Debitos", j).Value = db
                grilla.Item("Creditos", j).Value = cr + monto
                grilla.Item("base", j).Value = base
            Case "inv"
                Try
                    monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                Catch ex As Exception
                    monto = 0
                End Try
                grilla.Item("Debitos", j).Value = db
                grilla.Item("Creditos", j).Value = cr + monto
            Case "cventa"
                Try
                    monto = CDbl(gfactura.Item("costo", fo).Value) * CDbl(gfactura.Item("cant", fo).Value)
                Catch ex As Exception
                    monto = 0
                End Try
                grilla.Item("Debitos", j).Value = db + monto
                grilla.Item("Creditos", j).Value = cr
            Case "desc"
                ' monto = CDbl(lbdescuento.Text)
                monto = CDbl(txtdescuento.Text)
                grilla.Item("Debitos", j).Value = db + monto
                grilla.Item("Creditos", j).Value = cr
            Case "total"
                '  monto = CDbl(txttotal.Text)
                monto = gfp.Item("monto", j).Value
                grilla.Item("Debitos", j).Value = db + monto
                grilla.Item("Creditos", j).Value = cr
                If gfp.Item("cual", j).Value = "Cheque" Then
                    grilla.Item("cheque", j).Value = gfp.Item("numero", j).Value
                Else
                    grilla.Item("cheque", j).Value = ""
                End If
            Case "+"
                monto = CDbl(cbvalor.Items.Item(concep))
                grilla.Item("Debitos", j).Value = db
                grilla.Item("Creditos", j).Value = cr + monto
            Case "-"
                monto = CDbl(cbvalor.Items.Item(concep))
                grilla.Item("Debitos", j).Value = db + monto
                grilla.Item("Creditos", j).Value = cr
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
            'myCommand.Parameters.AddWithValue("?descto", DIN(lbdescuento.Text))
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
            myCommand.Parameters.AddWithValue("?ccosto", Val(txtcentrocos.Text))
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
            'moneda
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            'estado
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", "")
            'INSERTAR COBDPEN
            myCommand.CommandText = "INSERT INTO cobdpen VALUES (?doc,?tipo,?num,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?nitv,?fecha,?vmto," _
                                  & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                                  & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_VENTAS", "GuardarCobdpen")
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
            myCommand.Parameters.AddWithValue("?tipo_mov", "S")
            myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
            myCommand.Parameters.AddWithValue("?tipo_sal", "SALIDA POR FACTURA")
            myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", "")
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", DIN(Moneda2(total, lb_imp_dec.Text)))
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?tipo_sal,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            For i = 0 To gfactura.RowCount - 1
                Try
                    If gfactura.Item("tipo", i).Value.ToString = "I" Then
                        GuardarDetallesInv(i)
                    End If
                Catch ex As Exception
                    GuardarError(ex.ToString, "FAC_VENTAS-" & txttipo.Text & txtnumfac.Text, "GuardarMovInv-" & i)
                End Try
            Next
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_VENTAS-" & txttipo.Text & txtnumfac.Text, "GuardarMovInv")
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetallesInv(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", fila).Value)
            myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("descrip", fila).Value)
            Try
                myCommand.Parameters.AddWithValue("?bod_ori", Val(gfactura.Item("bodega", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?bod_ori", "0")
            End Try
            myCommand.Parameters.AddWithValue("?bod_des", "0")
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            Try
                myCommand.Parameters.AddWithValue("?valor", DIN(Moneda2(gfactura.Item("valor", fila).Value, lb_imp_dec.Text)))
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
            GuardarError(ex.ToString, "FAC_VENTAS-" & txttipo.Text & txtnumfac.Text, "GuardarDetalleInv fila(" & fila & ")")
            'MsgBox("Error guardando detalles de inventarios (" & fila & ") " & ex.ToString, MsgBoxStyle.Critical, "SAE Control de Errorres")
        End Try
    End Sub
    Public Sub ValidarConsecutivo()
        Try
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarConsecutivo(ByVal campo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Try
            If Val(tabla.Rows(0).Item("actualfc").ToString) < Val(txtnumfac.Text) Then
                myCommand.CommandText = "UPDATE parafacgral SET " & campo & "=" & Val(txtnumfac.Text) & ";"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            myCommand.CommandText = "UPDATE parafacgral SET " & campo & "=" & Val(txtnumfac.Text) & ";"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "UPDATE tipdoc SET actualfc=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
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
        ElseIf txtnitc.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcliente.Focus()
            Exit Sub
        ElseIf txtvendedor.Text = "" Then
            MsgBox("No ha digitado datos del vendedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitv.Focus()
            Exit Sub
        ElseIf txtdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            ' ElseIf lbdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
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
        End If
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text)
        Next
        If sumafp <> Moneda2(txttotal.Text, lb_imp_dec.Text) Or gfp.Item("cual", 0).Value = "" Then
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
        ap = par_guar()
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
        If tc.Rows(0).Item(0) = "SI" And rbafecta1.Checked = True And cbaprobado.Text = "AP" Then
            '...VALIDAR CANTIDAD DISPONIBLE ...
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("codigo", i).Value <> "" And gfactura.Item("tipo", i).Value = "I" Then
                    If ValidarCantidades(i) = False Then
                        Exit Sub
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

            If txtfecha.Value.ToString <> txtfecha2.Text Then
                camp = camp & "FECHA;"
                ant = ant & txtfecha2.Text & "; "
                nue = nue & txtfecha.Value.ToString & "; "
            End If
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
                        If (gfactura2.Item("codigo2", i).Value = gfactura.Item("codigo", j).Value) And (gfactura2.Item("descrip2", i).Value = gfactura.Item("descrip", j).Value) Then
                            If gfactura2.Item("cant2", i).Value <> gfactura.Item("cant", j).Value Then
                                camp = camp & "CANTIDAD ITEM " & gfactura2.Item("codigo2", i).Value & ";"
                                ant = ant & gfactura2.Item("cant2", i).Value & ";"
                                nue = nue & gfactura.Item("cant", i).Value & ";"
                            End If
                            If gfactura2.Item("valor2", i).Value <> gfactura.Item("valor", j).Value Then
                                camp = camp & "VALOR ITEM " & gfactura2.Item("codigo2", i).Value & ";"
                                ant = ant & gfactura2.Item("valor2", i).Value & ";"
                                nue = nue & gfactura.Item("valor", i).Value & ";"
                            End If
                            If CDbl(gfactura2.Item("descuento2", i).Value) <> CDbl(gfactura.Item("descuento", j).Value) Then
                                camp = camp & "DESCUENTO ITEM " & gfactura2.Item("codigo2", i).Value & ";"
                                ant = ant & gfactura2.Item("descuento2", i).Value & ";"
                                nue = nue & gfactura.Item("descuento", i).Value & ";"
                            End If
                            If gfactura2.Item("nit2", i).Value <> gfactura.Item("nit", j).Value Then
                                camp = camp & "NIT ITEM " & gfactura2.Item("codigo2", i).Value & ";"
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
        myCommand.Parameters.AddWithValue("?subtotal", DIN(Moneda2(txtsubtotal.Text, lb_imp_dec.Text)))
        'descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        ' myCommand.Parameters.AddWithValue("?descuento", DIN(lbdescuento.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(Moneda2(txtdescuento.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_ret_f", "0")
        myCommand.Parameters.AddWithValue("?ret_f", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_f", "")
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(Moneda2(txtiva.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'rete_iva
        myCommand.Parameters.AddWithValue("?por_ret_iva", "0")
        myCommand.Parameters.AddWithValue("?ret_iva", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_iva", "")
        'ret_ica
        myCommand.Parameters.AddWithValue("?por_ret_ica", "0")
        myCommand.Parameters.AddWithValue("?ret_ica", "0")
        myCommand.Parameters.AddWithValue("?cta_ret_ica", "")
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(Moneda2(txttotal.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'datos de entega
        myCommand.Parameters.AddWithValue("?entregar", "")
        myCommand.Parameters.AddWithValue("?dir_ent", "")
        myCommand.Parameters.AddWithValue("?ciu_ent", "")
        myCommand.Parameters.AddWithValue("?o_compra", "")
        myCommand.Parameters.AddWithValue("?fecha_o", "")
        myCommand.Parameters.AddWithValue("?cc", Val(txtcentrocosto.Text))
        'otros conceptos
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
        'For i = 0 To 2
        '    If i = 0 Then
        '        Try
        '            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                myCommand.Parameters.AddWithValue("?o_con", "si")
        '                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        '                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        '                myCommand.Parameters.AddWithValue("?v1", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
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
        '                myCommand.Parameters.AddWithValue("?v2", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
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
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", "0")
        myCommand.Parameters.AddWithValue("?rtc", "0")
        myCommand.Parameters.AddWithValue("?cta_rtc", "")
        'EDITAR FACTURA
        myCommand.CommandText = "UPDATE facturas" & PerActual(0) & PerActual(1) & " SET tipodoc=?tipodoc,doc_de=?doc_de,nitc=?nitc,nitv=?nitv,usuario=?usuario,fecha=?fecha,hora=?hora,descrip=?descrip,doc_afec=?doc_afec,afecta=?afecta," _
                              & "subtotal=?subtotal,por_desc=?por_desc,descuento=?descuento,cta_desc=?cta_desc,por_ret_f=?por_ret_f,ret_f=?ret_f,cta_ret_f=?cta_ret_f,por_iva=?por_iva,iva=?iva,cta_iva=?cta_iva," _
                              & "por_ret_iva=?por_ret_iva,ret_iva=?ret_iva,cta_ret_iva=?cta_ret_iva,por_ret_ica=?por_ret_ica,ret_ica=?ret_ica,cta_ret_ica=?cta_ret_ica," _
                              & "total=?total,cta_total=?cta_total,estado=?estado,observ=?observ,vmto=?vmto,entregar=?entregar,dir_ent=?dir_ent,ciu_ent=?ciu_ent,o_compra=?o_compra,fecha_o=?fecha_o,cc=?cc, " _
                              & "o_con=?o_con,t1=?t1,d1=?d1,v1=?v1,cta1=?cta1,t2=?t2,d2=?d2,v2=?v2,cta2=?cta2,t3=?t3,d3=?d3,v3=?v3,cta3=?cta3,doc1=?doc1,doc2=?doc2,doc3=?doc3,por_rtc=?por_rtc,rtc=?rtc,cta_rtc=?cta_rtc " _
                              & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        '///////////////////////////////////////////////////////////////
        Insertar("DELETE FROM detafac" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';")
        Insertar("DELETE FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';")
        If cbaprobado.Text = "AP" Then GuardarAnticipos()
        Dim sw As Integer = 0
        Dim total_inv, subt As Double
        total_inv = 0
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

        GuardarOtrosConcep()
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
        Try
            Dim tabla As New DataTable
            Dim item As Integer
            myCommand.CommandText = "SELECT actualfc FROM tipdoc where tipodoc='" & txttipo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            item = tabla.Rows(0).Item(0)
            If item = 0 Then
                PrimeraFactura()
            Else
                txtnumfac.Text = NumeroDoc(item + 1)
            End If
        Catch ex As Exception
            PrimeraFactura()
        End Try
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
        Try
            Timer1.Enabled = False
            PonerEnCero()
            BuscarPeriodo()
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT f. * , d. * " _
                                   & "FROM facturas" & PerActual(0) & PerActual(1) & " f " _
                                   & "LEFT JOIN (detafac" & PerActual(0) & PerActual(1) & " d) " _
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


            lbAnula.Text = Strings.Left(tabla.Rows(0).Item("descrip"), 7)

            txtsubtotal.Text = "0"
            txttotal.Text = "0"
            txtdescuento.Text = "0"
            'lbdescuento.Text = "0"
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
            txtsubtotal.Text = Moneda2(tabla.Rows(0).Item("subtotal"), lb_imp_dec.Text)
            'descuento
            valordes.Text = Moneda2(tabla.Rows(0).Item("por_desc"), lb_imp_dec.Text)
            txtdescuento.Text = tabla.Rows(0).Item("descuento")

            '  lbdescuento.Text = Moneda2(tabla.Rows(0).Item("descuento") - (tabla.Rows(0).Item("subtotal") * (tabla.Rows(0).Item("por_desc") / 100)))
            txtcuentadesc.Text = tabla.Rows(0).Item("cta_desc")
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
            txtvmto.Text = tabla.Rows(0).Item("vmto")
            Try
                fvmto.Value = DateAdd("d", CInt(txtvmto.Text), txtfecha.Value)
            Catch ex As Exception
            End Try
            txtcentrocosto.Text = tabla.Rows(0).Item("cc")
            If txtcentrocosto.Text <> "0" Then
                BuscarCCs()
            Else
                txtcentro.Text = ""
            End If
            lbestado.Text = "CONSULTA"
            If Trim(tabla.Rows(0).Item("afecta").ToString) = "SI" Then
                rbafecta1.Checked = True
            Else
                rbafecta2.Checked = True
            End If
            Try
                lbanti1.Text = tabla.Rows(0).Item("doc1").ToString
                lbanti2.Text = tabla.Rows(0).Item("doc2").ToString
                lbanti3.Text = tabla.Rows(0).Item("doc3").ToString
            Catch ex As Exception

            End Try
            gfactura.RowCount = items + 1
            Dim suma As Double = 0
            Dim dct As Double = 0
            Dim base As Double = 0
            Try
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
                    gfactura.Item("descuento", i).Value = Moneda2(tabla.Rows(i).Item("por_des"), lb_imp_dec.Text)
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
                    gfactura.Item("nit", i).Value = tabla.Rows(i).Item("nit").ToString
                    gfactura.Item("precio2", i).Value = Moneda2(0, lb_imp_dec.Text)
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
                            cbvalor.Items.Add(Moneda(toc.Rows(l).Item("valor")))
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
                '            cbvalor.Items.Add(Moneda2(tabla.Rows(0).Item(tipo), lb_imp_dec.Text))
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
                'MsgBox(ex.ToString)
            End Try
            FormasDePago(numero)
            lbsubtotal.Text = suma
            bloquear()
            cmditems.Enabled = False
            CalcularTotales()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        txtpagado.Text = "0,00"
        lbcambio.Text = "0,00"
    End Sub
    Public Sub FormasDePago(ByVal numero As String)
        Dim tablap As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM facpagos" & PerActual(0) & PerActual(1) & " WHERE doc = '" & numero & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablap)
        Refresh()
        items = tablap.Rows.Count
        If items > 0 Then
            gfp.RowCount = items
            For i = 0 To items - 1
                gfp.Item("cual", i).Value = tablap.Rows(i).Item("tipo").ToString
                gfp.Item("detalle", i).Value = tablap.Rows(i).Item("descrip").ToString
                gfp.Item("tt", i).Value = tablap.Rows(i).Item("tt").ToString
                gfp.Item("banco", i).Value = tablap.Rows(i).Item("banco").ToString
                gfp.Item("numero", i).Value = tablap.Rows(i).Item("numero").ToString
                gfp.Item("monto", i).Value = Moneda2(tablap.Rows(i).Item("valor"), lb_imp_dec.Text)
            Next
        End If
    End Sub
    ' /////////// FIN BARRA DE BOTONES FACTURA  ''''''''''''''''
    '///////////  DESPLAZAR REGISTROS    ///////////////////
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Dim tabla As New DataTable
        Dim s = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0' ORDER BY tipodoc,num LIMIT 0, 1;"
        myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0' ORDER BY tipodoc,num LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            MsgBox("No hay facturas los registros, favor agrege una.  ", MsgBoxStyle.Information, "Editar Factura ")
            PonerEnCero()
            Exit Sub
        End If
        BuscarFactura(tabla.Rows(0).Item(0))
        lbnumero.Text = "1"
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
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
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                cmdNuevo_Click(AcceptButton, AcceptButton)
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc<>'" & lbdocajuste.Text & "' AND ret_f='0' AND ret_iva='0' AND ret_ica='0' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
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
    Private Sub autocompletecliente()
        ' CARGAR CLIENTES
        ' AUTOCOMPLETAR NIT CLIENTE
        'Try
        '    txtcliente.AutoCompleteCustomSource.Clear()

        '    Dim tb As New DataTable
        '    tb.Clear()
        '    myCommand.CommandText = "SELECT TRIM(concat(  apellidos,' ',nombre)) as t FROM terceros ORDER BY t ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    If tb.Rows.Count > 0 Then
        '        For i = 0 To tb.Rows.Count - 1
        '            txtcliente.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub
    ''//////////////// FIN DESPLAZAR REGISTROS  ///////////////////////////
    Private Sub Frmfacturarapida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpagado.Text = Moneda2("0", lb_imp_dec.Text)
        lbcambio.Text = Moneda2("0", lb_imp_dec.Text)

        autocompletecliente()

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

        '...
        '....
        'Try
        '    Dim t As New DataTable
        '    myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(t)
        '    If t.Rows(0).Item("ccosto") = "S" Then
        '        txtcentrocosto.Enabled = True
        '    Else
        '        txtcentrocosto.Enabled = False
        '    End If
        'Catch ex As Exception
        '    txtcentrocosto.Enabled = False
        'End Try

        Dim tf As New DataTable
        Try
            tf.Clear()
            myCommand.CommandText = "SELECT GuarNumFac,imp_dec FROM parafacts where factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            lbgf.Text = tf.Rows(0).Item(0)
            lb_imp_dec.Text = Trim(tf.Rows(0).Item("imp_dec"))
        Catch ex As Exception
            lbgf.Text = "N"
            lb_imp_dec.Text = ""
        End Try

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
            ElseIf gfp.Item("cual", 0).Value = "Cheque" Then
                FrmFormaPago.txtnumcheq.Text = gfp.Item("numero", 0).Value
                FrmFormaPago.txtbanco.Text = gfp.Item("banco", 0).Value
                FrmFormaPago.gche.Enabled = True
                FrmFormaPago.gtar.Enabled = False
                FrmFormaPago.gcre.Enabled = False
            ElseIf gfp.Item("cual", 0).Value = "Tarjeta" Then
                FrmFormaPago.txttarjeta.Text = gfp.Item("detalle", 0).Value
                FrmFormaPago.txtnumtarjeta.Text = gfp.Item("numero", 0).Value
                FrmFormaPago.cbtarj.Text = gfp.Item("tt", 0).Value
                FrmFormaPago.gche.Enabled = False
                FrmFormaPago.gtar.Enabled = True
                FrmFormaPago.gcre.Enabled = False
            Else
                FrmFormaPago.txtespecifica.Text = gfp.Item("detalle", 0).Value
                FrmFormaPago.txtdias.Text = txtvmto.Text
                FrmFormaPago.gche.Enabled = False
                FrmFormaPago.gtar.Enabled = False
                FrmFormaPago.gcre.Enabled = True
                If Val(txtvmto.Text) > 0 Then
                    FrmFormaPago.rbsdia.Checked = True
                Else
                    FrmFormaPago.rbndia.Checked = True
                End If
            End If
        Else
            VariasFP()
        End If
        FrmFormaPago.lbform.Text = "fr"
        FrmFormaPago.ShowDialog()
        Try
            txtvmto_LostFocus(AcceptButton, AcceptButton)
        Catch ex As Exception
        End Try

    End Sub
    Public Sub VariasFP()
        FrmFormaPago.tabforma.Visible = False
        FrmFormaPago.tabvarias.Visible = True
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text)
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
            If txtremision.Text <> "" Then
                FrmObsrvaciones.txtobservacion.Enabled = False
                txtobserbaciones.Text = "REMISION SALIDA N° " & txtremision.Text & "" & vbCrLf & txtobserbaciones.Text
            End If
        Else
            FrmObsrvaciones.txtobservacion.Enabled = False
        End If
        FrmObsrvaciones.txtobservacion.Text = txtobserbaciones.Text
        FrmObsrvaciones.lbform.Text = "fr"
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
        FrmCuentas.lbform.Text = "fr_desc"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaiva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaiva.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fr_iva"
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
        FrmCuentas.lbform.Text = "fr_total"
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
    Public Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
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
        If lbestado.Text = "NUEVO" Then
            VeificarRDIAN(txttipo.Text, Val(txtnumfac.Text), txtfecha.Value)
        End If

    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else

            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT formatfac,imp_dec FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                lb_imp_dec.Text = Trim(tabla.Rows(0).Item("imp_dec"))
                If tabla.Rows(0).Item("formatfac") = "pdf" Then
                    If FrmPrincipal.lbcompania.Text = "HABITAR" Then
                        GenerarPDFHabitar()
                    Else
                        GenerarPDF()
                    End If
                ElseIf tabla.Rows(0).Item("formatfac") = "pdf2" Then
                    NGenerarPDF()
                Else
                    'GenerarTICKET2()
                    GenerarTicket()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If


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
    Public Sub GenerarTICKET2()

        Try


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
            fac = "Factura de Venta No: " & pre & " " & txtnumfac.Text
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
                        v_iva = v_iva & Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
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
                conc = conc & Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
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

            'FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport


            CrReport.SetParameterValue("comp", nom.ToString)
            CrReport.SetParameterValue("nit", nit.ToString)
            CrReport.SetParameterValue("dir", dire.ToString)
            CrReport.SetParameterValue("tel", tel.ToString)
            CrReport.SetParameterValue("fac", fac.ToString)
            CrReport.SetParameterValue("fec", fec.ToString)
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
            CrReport.SetParameterValue("rtiv", "0,00")
            CrReport.SetParameterValue("rtic", "0,00")
            CrReport.SetParameterValue("rtf", "0,00")
            CrReport.SetParameterValue("coment", coment.ToString)
            CrReport.SetParameterValue("pago", t_conc.ToString)
            CrReport.SetParameterValue("vpagos", conc.ToString)

            CrReport.PrintToPrinter(1, False, 0, 0)
            CrReport.Dispose()
            ' CrReport.PrintOptions.PrinterName

            'FrmVisorInformes.ShowDialog()
            'CrReport.Dispose()

            conexion.Close()

        Catch ex As Exception
            MsgBox("Error al imprimir el Ticket " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try




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
        Dim com_ini As String = ""

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        lett = Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text))

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
        & " (Select tipocompa from parafacts where factura= 'RAPIDA' ), " _
        & "(Select comentario_ini from parafacts where factura= 'RAPIDA' ) as com_ini " _
        & " from parafacgral pg "

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

        If txtiva.Text <> Moneda(0) Then
            For i = 0 To tabla4.Rows.Count - 1
                If tabla4.Rows(i).Item(1).ToString <> 0 Then
                    v_iva = v_iva & Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
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
            t_conc = t_conc & "" & (tabla4.Rows(i).Item(0).ToString) & ": " & Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text) & " // "
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



        If (tablO.Rows(0).Item("o_con").ToString) = "si" Then
            Dim ta4 As New DataTable
            ta4 = New DataTable
            myCommand.CommandText = "SELECT * FROM otcon_fac" & p & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta4)

            If tabla4.Rows.Count > 0 Then
                For l = 0 To ta4.Rows.Count - 1
                    t_otro = t_otro & (ta4.Rows(l).Item("descrip").ToString) & vbCrLf & vbCrLf
                    otro = otro & (ta4.Rows(l).Item("tipo").ToString) & Moneda2(ta4.Rows(l).Item("valor").ToString, lb_imp_dec.Text) & vbCrLf & vbCrLf
                Next
            End If
        Else
            t_otro = ""
            otro = ""
        End If

        ''For i = 0 To tablO.Rows.Count - 1
        ''    If (tablO.Rows(i).Item("o_con").ToString) = "si" Then
        ''        If (tablO.Rows(i).Item("t1").ToString) <> "" Then
        ''            t_otro = t_otro & (tablO.Rows(i).Item("d1").ToString) & vbCrLf & vbCrLf
        ''            otro = otro & (tablO.Rows(i).Item("t1").ToString) & Moneda2(tablO.Rows(i).Item("v1").ToString, lb_imp_dec.Text) & vbCrLf & vbCrLf
        ''        End If
        ''        If (tablO.Rows(i).Item("t2").ToString) <> "" Then
        ''            t_otro = t_otro & (tablO.Rows(i).Item("d2").ToString) & vbCrLf & vbCrLf
        ''            otro = otro & (tablO.Rows(i).Item("t2").ToString) & Moneda2(tablO.Rows(i).Item("v2").ToString, lb_imp_dec.Text) & vbCrLf & vbCrLf
        ''        End If
        ''        If (tablO.Rows(i).Item("t3").ToString) <> "" Then
        ''            t_otro = t_otro & (tablO.Rows(i).Item("d3").ToString) & vbCrLf & vbCrLf
        ''            otro = otro & (tablO.Rows(i).Item("t3").ToString) & Moneda2(tablO.Rows(i).Item("v3").ToString, lb_imp_dec.Text) & vbCrLf & vbCrLf
        ''        End If
        ''    Else
        ''        t_otro = ""
        ''        otro = ""
        ''    End If
        ''Next
        '----------------------------------------------

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT " & tabla2.Rows(0).Item("nit")
        If Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2")) <> "" Then
            tel = " TEL: " & Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        End If
        If tabla2.Rows(0).Item("emailconta") <> "" Then
            tel = tel & " EMAIL: " & tabla2.Rows(0).Item("emailconta")
        End If
        If tabla2.Rows(0).Item("direccion") <> "" Then
            tel = tel & " DIR: " & tabla2.Rows(0).Item("direccion")
        End If

        'email = "NO SOMOS GRANDES CONTRIBUYENTES"
        fac = txtnumfac.Text
        fec = txtfecha.Text & " HORA:" & lbhora.Text
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

        sql = " SELECT  d.doc , d.iva_d as cualfp, d.item as tipodoc, d.codart as idbod, a.referencia as margen,  d.nomart as comentario , " _
        & "  CAST((d.cantidad) AS CHAR(20)) as nitc, CAST(FORMAT(((d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)))," & dc & ")AS CHAR(20)) as nitvpre, " _
        & " FORMAT((((d.valor/(1+(d.iva_d/100)))- ((d.valor /(1+(d.iva_d/100))) * (d.por_des/100)) )* d.cantidad)," & dc & ") as nitv, " _
        & " (SELECT logofac FROM  parafacts where factura = 'RAPIDA') AS logofac, " _
        & " f.iva as numfact,  FORMAT(f.total," & dc & ") as margmin" _
        & " FROM facturas" & p & " f INNER JOIN(detafac" & p & " d) ON f.doc = d.doc LEFT JOIN articulos a ON d.codart= a.codart WHERE f.doc = '" & txttipo.Text & txtnumfac.Text & "'  " _
        & " ORDER BY item"

        TextBox1.Text = sql2
        TextBox2.Text = sql

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
            prTipo.CurrentValues.AddValue("FACTURA DE VENTA N°")

            prO.Name = "otro"
            prO.CurrentValues.AddValue(otro.ToString)
            prT.Name = "t_otro"
            prT.CurrentValues.AddValue(t_otro.ToString)

            prrtf.Name = "rtf"
            prrtf.CurrentValues.AddValue(Moneda(0))
            prrti.Name = "rti"
            prrti.CurrentValues.AddValue(Moneda(0))
            prrtic.Name = "rtic"
            prrtic.CurrentValues.AddValue(Moneda(0))
            prrtc.Name = "rtc"
            prrtc.CurrentValues.AddValue(Moneda(0))

            prtotalg.Name = "totalG"
            prtotalg.CurrentValues.AddValue(Moneda2(txttotal.Text, lb_imp_dec.Text))
            prsubtotal.Name = "subtotal"
            prsubtotal.CurrentValues.AddValue(Moneda2(txtsubtotal.Text, lb_imp_dec.Text))


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
            MsgBox("Error" & ex.ToString)
        End Try

        conexion.Close()

    End Sub
    Public Sub GenerarPDFHabitar()
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
            Dim nom As String = ""
            Dim cod As String = ""
            Dim t As Double = 0
            Dim j As Integer = 0
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item("tipo_it").ToString <> "I" Then
                    If tabla.Rows(i).Item("codart").ToString = "0001" Or tabla.Rows(i).Item("codart").ToString = "0004" Then
                        nom = tabla.Rows(i).Item("nomart").ToString
                        cod = tabla.Rows(i).Item("codart").ToString
                    End If
                    Try
                        vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                        vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                    Catch ex As Exception
                        vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
                        vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                    End Try
                    t = t + vtotal
                    '********** calculo subtotal con dcto ******
                    Try
                        vdesc = vtotal - (vtotal * CDbl(valordes.Text) / 100)
                    Catch ex As Exception
                        vdesc = vtotal
                    End Try
                    '***** valor iva *********
                    Try
                        va_iva = (vdesc * (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                    Catch ex As Exception
                        va_iva = 0
                    End Try
                    Try
                        AgruparIva(tabla.Rows(i).Item("iva_d").ToString, va_iva)
                    Catch ex As Exception
                    End Try
                Else
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
                    j = j + 1
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, j, 20, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("codart"), 40, k, 0)
                    'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 120, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda2(tabla.Rows(i).Item("cantidad"),lb_imp_dec.Text), 350, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(tabla.Rows(i).Item("iva_d").ToString, lb_imp_dec.Text), 500, k, 0)
                    Try
                        valor = (Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100)))
                        valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                        ' valor = Moneda2(tabla.Rows(i).Item("valor")) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                    Catch ex As Exception
                        valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text)
                    End Try
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor, lb_imp_dec.Text), 460, k, 0)
                    Try
                        vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                        vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                    Catch ex As Exception
                        vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
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
                        va_iva = (vdesc * (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                    Catch ex As Exception
                        va_iva = 0
                    End Try
                    Try
                        AgruparIva(tabla.Rows(i).Item("iva_d").ToString, va_iva)
                    Catch ex As Exception
                    End Try
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal, lb_imp_dec.Text), 585, k, 0)
                    'CONTROL SALTO DE LINEA PARA NOMBRE O DESCRIPCION DEL ARTICULO
                    Control_de_linea(tabla.Rows(i).Item("nomart").ToString, 120, 38)
                End If
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            If nom <> "" Then
                k = k - 10
                j = j + 1
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, j, 20, k, 0)
                cb.ShowTextAligned(50, cod, 40, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "1,00", 350, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(0, lb_imp_dec.Text), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(t, lb_imp_dec.Text), 460, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(t, lb_imp_dec.Text), 585, k, 0)
                Control_de_linea(nom, 120, 38)
            End If
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            'Dim calculoiva As Double

            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text, lb_imp_dec.Text), 585, k, 0)
            If CDbl(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtdescuento.Text, lb_imp_dec.Text), 585, k, 0)
                ' cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(lbdescuento.Text), 585, k, 0)
            End If
            'If CDbl(txtiva.Text) <> 0 Then
            Try


                For iiva = 0 To viva.Length - 1
                    If Moneda2(viva(iiva), lb_imp_dec.Text) <> "0,00" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA " & Moneda2(viva(iiva), lb_imp_dec.Text) & "%", 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vmon(iiva), lb_imp_dec.Text), 585, k, 0)
                    End If
                Next

            Catch ex As Exception

            End Try
            'End If
            For i = 0 To 2
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
                    End If
                Catch ex As Exception
                End Try
            Next
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text, lb_imp_dec.Text), 585, k, 0)
            k = k - 10
            '**************************** FORMA DE PAGO*****************************************************************
            cb.ShowTextAligned(50, "Forma De Pago:", 10, k2, 0)
            For i = 0 To gfp.RowCount - 1
                Try
                    If gfp.Item("cual", i).Value = "Otra" Then
                        cb.ShowTextAligned(50, CambiaCadena(gfp.Item("detalle", i).Value.ToString, 35) & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text), 73, k2, 0)
                    Else
                        cb.ShowTextAligned(50, gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text), 73, k2, 0)
                    End If
                    k2 = k2 - 10
                Catch ex As Exception
                End Try
            Next
            k2 = k2 - 5
            If k2 < k Then
                k = k2
            End If
            Control_de_linea("SON: " & Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text)), 10, 80)
            k = k - 10
            If txtobserbaciones.Text <> "" Then
                cb.ShowTextAligned(50, "Observaciones: ", 10, k, 0)
                Control_de_linea(txtobserbaciones.Text, 70, 100)
                k = k - 10
            End If
            k = k - 15
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    ' cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 10, 125)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            '*************************************************************
            cb.ShowTextAligned(50, "Esta factura se asimila para todos sus efectos a la letra de cambio. Articulo 774 Codigo de Comercio.", 10, k, 0)
            k = k - 10
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 10
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
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(tabla.Rows(i).Item("iva_d").ToString, lb_imp_dec.Text), 500, k, 0)
                Try
                    valor = (Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100)))
                    valor = valor - (valor * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                    ' valor = Moneda2(tabla.Rows(i).Item("valor")) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text)
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor, lb_imp_dec.Text), 460, k, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                    vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
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
                    va_iva = (vdesc * (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    va_iva = 0
                End Try
                Try
                    AgruparIva(tabla.Rows(i).Item("iva_d").ToString, va_iva)
                Catch ex As Exception
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal, lb_imp_dec.Text), 585, k, 0)
                'CONTROL SALTO DE LINEA PARA NOMBRE O DESCRIPCION DEL ARTICULO
                Control_de_linea(tabla.Rows(i).Item("nomart").ToString, 120, 38)
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            'Dim calculoiva As Double

            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text, lb_imp_dec.Text), 585, k, 0)
            If CDbl(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtdescuento.Text, lb_imp_dec.Text), 585, k, 0)
                ' cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(lbdescuento.Text), 585, k, 0)
            End If
            'If CDbl(txtiva.Text) <> 0 Then
            Try


                For iiva = 0 To viva.Length - 1
                    If Moneda2(viva(iiva), lb_imp_dec.Text) <> "0,00" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA " & Moneda2(viva(iiva), lb_imp_dec.Text) & "%", 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vmon(iiva), lb_imp_dec.Text), 585, k, 0)
                    End If
                Next

            Catch ex As Exception

            End Try
            'End If
            For i = 0 To cbsr.Items.Count - 1
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        k = k - 10
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
                    End If
                Catch ex As Exception
                End Try
            Next
            'For i = 0 To 2
            '    Try
            '        If Trim(cbsr.Items.Item(i).ToString) = "+" Then
            '            k = k - 10
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
            '        ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
            '            k = k - 10
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cbconcepto.Items.Item(i), 485, k, 0)
            '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 585, k, 0)
            '        End If
            '    Catch ex As Exception
            '    End Try
            'Next
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text, lb_imp_dec.Text), 585, k, 0)
            k = k - 10
            '**************************** FORMA DE PAGO*****************************************************************
            cb.ShowTextAligned(50, "Forma De Pago:", 10, k2, 0)
            For i = 0 To gfp.RowCount - 1
                Try
                    If gfp.Item("cual", i).Value = "Otra" Then
                        cb.ShowTextAligned(50, CambiaCadena(gfp.Item("detalle", i).Value.ToString, 35) & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text), 73, k2, 0)
                    Else
                        cb.ShowTextAligned(50, gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text), 73, k2, 0)
                    End If
                    k2 = k2 - 10
                Catch ex As Exception
                End Try
            Next
            k2 = k2 - 5
            If k2 < k Then
                k = k2
            End If
            Control_de_linea("SON: " & Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text)), 10, 80)
            k = k - 10
            If txtobserbaciones.Text <> "" Then
                cb.ShowTextAligned(50, "Observaciones: ", 10, k, 0)
                Control_de_linea(txtobserbaciones.Text, 70, 100)
                k = k - 10
            End If
            k = k - 15
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tcom)
                If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                    ' cb.ShowTextAligned(50, tcom.Rows(0).Item("comentario"), 10, k, 0)
                    Control_de_linea(tcom.Rows(0).Item("comentario"), 10, 125)
                    k = k - 10
                End If
            Catch ex As Exception
            End Try
            '*************************************************************
            cb.ShowTextAligned(50, "Esta factura se asimila para todos sus efectos a la letra de cambio. Articulo 774 Codigo de Comercio.", 10, k, 0)
            k = k - 10
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 10
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
    'Function Moneda2(ByVal monto As String)
    '    If lb_imp_dec.Text = "S" Then
    '        Try
    '            If CDbl(monto) = 0 Then
    '                monto = "0,00"
    '            ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
    '                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
    '            Else
    '                monto = Format(Math.Round(CDbl(monto), 2), "0,00.00")
    '            End If
    '            Return monto
    '        Catch ex As Exception
    '            Return "0,00"
    '        End Try
    '    Else
    '        Try
    '            If CDbl(monto) = 0 Then
    '                monto = "0"
    '            ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
    '                monto = Format(Math.Round(CDbl(monto), 0), "0.00")
    '            Else
    '                monto = Format(Math.Round(CDbl(monto), 0), "0,00")
    '            End If
    '            Return monto
    '        Catch ex As Exception
    '            Return "0"
    '        End Try
    '    End If
    'End Function
    Public Sub ColocarImg()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
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

    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        Dim tablaR As New DataTable
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='RAPIDA';"
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
        cb.ShowTextAligned(50, txttipo2.Text & " No. " & pref & " " & txtnumfac.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA: " & txtfecha.Text.ToString & " HORA: " & lbhora.Text.ToString, 20, k, 0)
        If Val(txtvmto.Text) > 0 Then
            k = k - 10
            cb.ShowTextAligned(50, "FECHA DE VENCIMIENTO: " & txtfecha.Value.AddDays(Val(txtvmto.Text)).ToString, 20, k, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "SEÑORES: ", 20, k, 0)
        Control_de_linea(Trim(txtcliente.Text), 70, 45)
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: " & txtnitc.Text, 20, k, 0)
        DatosTercero()
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
            Control_de_linea(tabla.Rows(0).Item("dir").ToString, 75, 40)
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
            tope = 240
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
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda2(tabla.Rows(i).Item("cantidad"), lb_imp_dec.Text), 50, k, 0)
                Try
                    valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text)
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor, lb_imp_dec.Text), 468, k + 2, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text) / (1 + (CDbl(tabla.Rows(i).Item("iva_d")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal, lb_imp_dec.Text), 568, k + 2, 0)
                Control_de_linea(tabla.Rows(i).Item("nomart").ToString, 82, 56)
                cb.EndText()
                k = k - 3
                ColocarImg2(3) ' linea
                cb.BeginText()
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = 217
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "SUBTOTAL $", 390, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DESCUENTO $", 390, k, 0)
            k = k - 10
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text, lb_imp_dec.Text), 568, k, 0)
            k = k - 10
            Dim hd As String = ""
            If CDbl(txtdescuento.Text) > 0 Then
                hd = "-"
            End If
            'If CDbl(lbdescuento.Text) > 0 Then
            '    hd = "-"
            'End If
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, hd & Moneda2(lbtdescuento.Text), 568, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, hd & Moneda2(txtdescuento.Text, lb_imp_dec.Text), 568, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtiva.Text, lb_imp_dec.Text), 568, k, 0)
            k = k - 10
            For i = 0 To 2
                Try
                    If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 568, k, 0)
                        k = k - 10
                    ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text), 568, k, 0)
                        k = k - 10
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txttotal.Text, lb_imp_dec.Text), 568, k, 0)
            '/////////////////////////////////////////////////////////////////
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = 217
            '*****************COMENTARIO******************************************
            Control_de_linea("SON: " & Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text)), 23, 90)
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
        myCommand.CommandText = "SELECT tipocompa FROM parafacts WHERE factura='RAPIDA';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
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
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp1") & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre2") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre2")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso2"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp2") & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini2") & " al " & tablad.Rows(0).Item("fin2"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre3") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre3")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso3"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp3") & " " & pre, 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "desde el Nro. " & tablad.Rows(0).Item("ini3") & " al " & tablad.Rows(0).Item("fin3"), 435, k, 0)
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            pre = ""
            If tablad.Rows(0).Item("pre4") <> "" Then pre = "Prefijo " & tablad.Rows(0).Item("pre4")
            cb.ShowTextAligned(50, "Resolución DIAN " & tablad.Rows(0).Item("reso4"), 435, k + 30, 0)
            cb.ShowTextAligned(50, "del " & tablad.Rows(0).Item("fecexp4") & " " & pre, 435, k + 20, 0)
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
                cb.ShowTextAligned(50, gfp.Item("cual", 0).Value & ": $" & Moneda2(gfp.Item("monto", 0).Value, lb_imp_dec.Text), 140, k, 0)
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
        'cb.ShowTextAligned(50, "k = " & k, 480, k, 0)


    End Sub
    Public Sub nfact()
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
        Dim k2 As Integer = 750
        cb.ShowTextAligned(50, txttipo2.Text, 445, k2, 0)
        cb.ShowTextAligned(50, "No. " & pref & " " & txtnumfac.Text, 445, k2 - 25, 0)
        cb.ShowTextAligned(50, "Página No." & pag, 445, k2 - 50, 0)

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
            'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(0).Item("dir"), 40), 75, k, 0)
            'cb.ShowTextAligned(50, Trim(tabla.Rows(0).Item("telefono") & " " & tabla.Rows(0).Item("celular")), 330, k, 0)
        Catch ex As Exception
        End Try
    End Sub
    '////////////// GENERAR TICKET /////////////////////
    Private stringToPrint As String
    Public Sub GenerarTicket()
        Dim file As System.IO.StreamWriter = System.IO.File.CreateText(My.Application.Info.DirectoryPath & "\Reportes\temp.txt")
        '*************DATOS COMPAÑIA***************************************

        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        Dim tablaR As New DataTable
        tablaR.Clear()
        myCommand.CommandText = "SELECT tipocompa " _
        & " FROM parafacts " _
        & " WHERE factura='RAPIDA';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablaR)
        '...
        Dim tb As New DataTable
        tb.Clear()
        myCommand.CommandText = "SELECT  " _
        & " CASE '" & txttipo.Text & "' " _
       & " WHEN tipof1 THEN pre1 " _
       & " WHEN tipof2 THEN pre2 " _
       & " WHEN tipof3 THEN pre3  " _
       & " WHEN tipof4 THEN pre4  " _
       & " END AS pref  " _
       & " FROM parafacgral "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        file.WriteLine(" ")
        file.WriteLine(" ")
        file.WriteLine(" ")
        file.WriteLine(SaltarCadena(tablacomp.Rows(0).Item("descripcion"), 48))
        file.WriteLine("N.I.T. " & tablacomp.Rows(0).Item("nit") & " - " & tablaR.Rows(0).Item("tipocompa"))
        file.WriteLine(tablacomp.Rows(0).Item("direccion"))
        file.WriteLine("TEL. " & tablacomp.Rows(0).Item("telefono1") & "    " & tablacomp.Rows(0).Item("telefono2"))
        '**************COMENTARIO INICIAL ******************
        Try
            Dim tini As New DataTable
            myCommand.CommandText = "SELECT comentario_ini FROM parafacts " _
                                  & "WHERE TRIM(comentario_ini)<>'';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tini)
            If tini.Rows.Count > 0 Then
                'file.WriteLine("")
                file.WriteLine(SaltarCadena(tini.Rows(0).Item(0), 38))
                'file.WriteLine("")
            End If
        Catch ex As Exception
        End Try
        file.WriteLine("---------------------------------------")
        '************** FACTURA ******************************
        file.WriteLine("FECHA: " & txtfecha.Text.ToString)
        file.WriteLine("HORA: " & lbhora.Text.ToString)
        file.WriteLine("FACTURA N°: " & tb.Rows(0).Item("pref") & " " & txtnumfac.Text)
        file.WriteLine("SEÑOR(A): " & txtcliente.Text)
        file.WriteLine("NIT/CEDULA: " & txtnitc.Text)
        file.WriteLine("VENDEDOR: " & txtvendedor.Text)
        '********* FORMA DE PAGO *********************
        For i = 0 To gfp.RowCount - 1
            Try
                If i = 0 Then
                    If gfp.Item("cual", i).Value = "Otra" Then
                        file.WriteLine("Forma De Pago: " & CambiaCadena(gfp.Item("detalle", i).Value.ToString, 27))
                        file.WriteLine("Fecha de Vencimiento: " & txtfecha.Value.AddDays(Val(txtvmto.Text)))
                    ElseIf Trim(gfp.Item("cual", i).Value.ToString) <> "" Then
                        file.WriteLine("Forma De Pago: " & gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text))
                    End If
                Else
                    file.WriteLine("               " & gfp.Item("cual", i).Value & ": $" & Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text))
                End If
            Catch ex As Exception
            End Try
        Next
        '*************** CUERPO DE LA FACTURA********************************
        file.WriteLine("---------------------------------------")
        file.WriteLine("    Cant   Unit      V/total      Iva ")
        file.WriteLine("---------------------------------------")
        Dim valor, vtotal As Double
        Dim cad As String = ""
        For i = 0 To gfactura.RowCount - 1
            Try
                If Trim(gfactura.Item("codigo", i).Value.ToString) <> "" Then
                    file.WriteLine(SaltarCadena(gfactura.Item("codigo", i).Value.ToString & "-" & gfactura.Item("descrip", i).Value.ToString, 38))
                    cad = LlenarEspacios(CambiaCadena(gfactura.Item("cant", i).Value.ToString, 6), 5)
                    Try
                        valor = Moneda2(gfactura.Item("valor", i).Value.ToString, lb_imp_dec.Text) / (1 + (CDbl(gfactura.Item("iva", i).Value.ToString) / 100))
                    Catch ex As Exception
                        valor = Moneda2(gfactura.Item("valor", i).Value.ToString, lb_imp_dec.Text)
                    End Try
                    ' cad = cad & LlenarEspacios(Moneda2(valor, lb_imp_dec.Text), 10)
                    cad = cad & LlenarEspacios(Moneda2(valor, lb_imp_dec.Text), 11)
                    Try
                        vtotal = Moneda2(gfactura.Item("Vtotal", i).Value.ToString, lb_imp_dec.Text) / (1 + (CDbl(gfactura.Item("iva", i).Value.ToString) / 100))
                    Catch ex As Exception
                        vtotal = Moneda2(gfactura.Item("Vtotal", i).Value.ToString, lb_imp_dec.Text)
                    End Try
                    'cad = cad & LlenarEspacios(Moneda2(gfactura.Item("iva", i).Value.ToString, lb_imp_dec.Text), 6)
                    'cad = cad & LlenarEspacios(Moneda2(vtotal, lb_imp_dec.Text), 11)
                    cad = cad & LlenarEspacios(Moneda2(vtotal, lb_imp_dec.Text), 11)
                    If Moneda(gfactura.Item("iva", i).Value.ToString) <> Moneda(0) Then
                        cad = cad & LlenarEspacios("D", 5)
                    End If

                    file.WriteLine(cad)
                End If
            Catch ex As Exception
            End Try
        Next
        '*************** TOTALES DE LA FACTURA********************************
        file.WriteLine("---------------------------------------")
        cad = LlenarEspacios("Sub Total:", 15)
        cad = cad & LlenarEspacios(Moneda2(txtsubtotal.Text, lb_imp_dec.Text), 16)
        file.WriteLine(cad)

        '...IVA...
        Dim sql3 As String = ""
        Dim p As String = ""
        p = PerActual(0).ToString & PerActual(1).ToString
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

        If txtiva.Text <> Moneda(0) Then
            For i = 0 To tabla4.Rows.Count - 1
                If tabla4.Rows(i).Item(1).ToString <> 0 Then
                    cad = LlenarEspacios("D = Iva " & (tabla4.Rows(i).Item(0).ToString) & "% :", 11)
                    cad = cad & LlenarEspacios(Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text), 16)
                    file.WriteLine(cad)
                End If
            Next
        End If
        '.....
        '--------------------OTROS CONCEPTOS-------------------------
        For i = 0 To cbsr.Items.Count - 1
            Try
                If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                    cad = LlenarEspacios(cbconcepto.Items(i).ToString, 15)
                    cad = cad & LlenarEspacios(Moneda2(cbvalor.Items(i).ToString, lb_imp_dec.Text), 16)
                    file.WriteLine(cad)
                ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                    cad = LlenarEspacios(cbconcepto.Items(i).ToString, 15)
                    cad = cad & LlenarEspacios(Moneda2("-" & cbvalor.Items(i).ToString, lb_imp_dec.Text), 16)
                    file.WriteLine(cad)
                End If
            Catch ex As Exception
            End Try
        Next
        ''For i = 0 To tablO.Rows.Count - 1
        ''    If (tablO.Rows(i).Item("o_con").ToString) = "si" Then
        ''        If (tablO.Rows(i).Item("t1").ToString) <> "" Then
        ''            cad = LlenarEspacios(tablO.Rows(i).Item("d1").ToString, 15)
        ''            cad = cad & LlenarEspacios(tablO.Rows(i).Item("t1").ToString & Moneda2(tablO.Rows(i).Item("v1").ToString, lb_imp_dec.Text), 16)
        ''        End If
        ''        If (tablO.Rows(i).Item("t2").ToString) <> "" Then
        ''            cad = LlenarEspacios(tablO.Rows(i).Item("d2").ToString, 15)
        ''            cad = cad & LlenarEspacios(tablO.Rows(i).Item("t2").ToString & Moneda2(tablO.Rows(i).Item("v2").ToString, lb_imp_dec.Text), 16)
        ''        End If
        ''        If (tablO.Rows(i).Item("t3").ToString) <> "" Then
        ''            cad = LlenarEspacios(tablO.Rows(i).Item("d3").ToString, 15)
        ''            cad = cad & LlenarEspacios(tablO.Rows(i).Item("t3").ToString & Moneda2(tablO.Rows(i).Item("v3").ToString, lb_imp_dec.Text), 16)
        ''        End If
        ''    End If
        ''Next
        '----------------------------------------------


        'If Moneda2(txtiva.Text) <> "0,00" Then
        '    cad = LlenarEspacios("Iva:", 15)
        '    cad = cad & LlenarEspacios(Moneda2(txtiva.Text), 16)
        '    file.WriteLine(cad)
        'End If
        If Moneda2(txtdescuento.Text, lb_imp_dec.Text) <> "0,00" Then
            cad = LlenarEspacios("Descuento:", 15)
            cad = cad & LlenarEspacios(Moneda2(txtdescuento.Text, lb_imp_dec.Text), 16)
            file.WriteLine(cad)
        End If
        cad = LlenarEspacios("Total:", 15)
        cad = cad & LlenarEspacios(Moneda2(txttotal.Text, lb_imp_dec.Text), 16)
        file.WriteLine(cad)
        file.WriteLine(Chr(13))
        '************* OBSERVACIONES ************************
        If Trim(txtobserbaciones.Text) <> "" Then
            file.WriteLine("Obs: " & CambiaCadena(Trim(txtobserbaciones.Text), 38))
        End If
        '******************************************************** DIAN **************************************************************
        Dim tablad As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablad)
        If tablad.Rows(0).Item("tipof1") = txttipo.Text And tablad.Rows(0).Item("hr1") = "SI" Then
            file.WriteLine("R.DIAN " & tablad.Rows(0).Item("reso1") & " del " & tablad.Rows(0).Item("fecexp1"))
            file.WriteLine("RANGO FACT. " & tablad.Rows(0).Item("ini1") & " al " & tablad.Rows(0).Item("fin1"))
        ElseIf tablad.Rows(0).Item("tipof2") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            file.WriteLine("R.DIAN " & tablad.Rows(0).Item("reso2") & " del " & tablad.Rows(0).Item("fecexp2"))
            file.WriteLine("RANGO FACT. " & tablad.Rows(0).Item("ini2") & " al " & tablad.Rows(0).Item("fin2"))
        ElseIf tablad.Rows(0).Item("tipof3") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            file.WriteLine("R.DIAN " & tablad.Rows(0).Item("reso3") & " del " & tablad.Rows(0).Item("fecexp3"))
            file.WriteLine("RANGO FACT. " & tablad.Rows(0).Item("ini3") & " al " & tablad.Rows(0).Item("fin3"))
        ElseIf tablad.Rows(0).Item("tipof4") = txttipo.Text And tablad.Rows(0).Item("hr2") = "SI" Then
            file.WriteLine("R.DIAN " & tablad.Rows(0).Item("reso4") & " del " & tablad.Rows(0).Item("fecexp4"))
            file.WriteLine("RANGO FACT. " & tablad.Rows(0).Item("ini4") & " al " & tablad.Rows(0).Item("fin4"))
        End If
        file.WriteLine("---------------------------------------")
        '*****************COMENTARIO******************************************
        Try
            Dim tcom As New DataTable
            myCommand.CommandText = "SELECT comentario FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcom)
            If Trim(tcom.Rows(0).Item("comentario")) <> "" Then
                file.WriteLine(SaltarCadena(tcom.Rows(0).Item("comentario"), 38))
            End If
        Catch ex As Exception
        End Try
        '**********************INFORMACIÓN DEL IMPRESO*************************************
        file.WriteLine("Impreso a la fecha: " & Strings.Left(Now.ToString, 10))
        file.WriteLine("Impreso a la hora: " & Strings.Right(Now.ToString, 13))
        file.WriteLine("Factura elaborada por computadora en el ")
        file.WriteLine("Software de Administración  Empresarial ")
        file.WriteLine("SAE Versión " & FrmPrincipal.lbversion.Text)
        file.WriteLine("---------------------------------------")
        file.WriteLine("")
        file.WriteLine("")
        file.WriteLine("")
        file.Close()


        '*************** MANDAR A IMPRIMIR ********************************
        Dim docName As String = "temp.txt"
        Dim docPath As String = My.Application.Info.DirectoryPath & "\Reportes\"
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

        'imprimir.GetType()

        'imprimir.DefaultPageSettings.Margins.Left = 2
        'imprimir.DefaultPageSettings.Margins.Top = 3

        'imprimir.Print()
        FrmImpTicket.TextBox1.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Reportes\temp.txt")
        FrmImpTicket.ShowDialog()


    End Sub

    Function LlenarEspacios(ByVal cad As String, ByVal esp As Integer)
        Dim cadaux As String
        cadaux = cad
        If cad.Length < esp Then
            For i = cad.Length To esp
                cadaux = " " & cadaux
            Next
        End If
        Return cadaux
    End Function
    Private Sub imprimir_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles imprimir.PrintPage
        Try
            Dim charactersOnPage As Integer = 0
            Dim linesPerPage As Integer = 0
            e.Graphics.MeasureString(stringToPrint, lbprint.Font, e.MarginBounds.Size, _
                StringFormat.GenericTypographic, charactersOnPage, linesPerPage)
            e.Graphics.DrawString(stringToPrint, lbprint.Font, Brushes.Black, _
                e.MarginBounds, StringFormat.GenericTypographic)
            stringToPrint = stringToPrint.Substring(charactersOnPage)
            e.HasMorePages = stringToPrint.Length > 0

        Catch ex As Exception
        End Try
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
    '            txtcentrocos.Text = ""
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
        '                    FrmOtrosConceptos.valor1.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
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
        '                    FrmOtrosConceptos.valor2.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
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
        '                    FrmOtrosConceptos.valor3.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
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
        'FrmOtrosConceptos.lbform.Text = "fr"
        'FrmOtrosConceptos.ShowDialog()
        'Try
        '    cbconcepto.SelectedIndex = 0
        'Catch ex As Exception
        'End Try
        Try
            FrmOtrosConceptosProv.grilla.Rows.Clear()
            FrmOtrosConceptosProv.grilla.RowCount = cbsr.Items.Count + 2
            For j = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(j).ToString) <> "" Then
                    FrmOtrosConceptosProv.grilla.Item("sel", j).Value = True
                    FrmOtrosConceptosProv.grilla.Item("tipo", j).Value = cbsr.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("txt", j).Value = cbconcepto.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("valor", j).Value = Moneda(cbvalor.Items.Item(j))
                    FrmOtrosConceptosProv.grilla.Item("base", j).Value = Moneda(cbbase.Items.Item(j))
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

        FrmOtrosConceptosProv.lbform.Text = "fr"
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
            lbvalor.Text = Moneda2(cbvalor.Text, lb_imp_dec.Text)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

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

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        lett = Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text))

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
        & " CASE 'SI' " _
        & " WHEN pg.hr1 THEN pg.pre1 " _
        & " WHEN pg.hr2 THEN pg.pre2 " _
        & " WHEN pg.hr3 THEN pg.pre3 " _
        & " WHEN pg.hr4 THEN pg.pre4 " _
        & " END AS pref, " _
        & " (SELECT  t.dir from facturas" & p & " f, terceros t where f.doc =  '" & txttipo.Text & txtnumfac.Text & "' and f.nitc= t.nit ) as dirC, " _
        & " (SELECT  t.telefono from facturas" & p & " f, terceros t where f.doc =  '" & txttipo.Text & txtnumfac.Text & "' and f.nitc= t.nit ) as telC " _
        & " , (Select f.observ from facturas" & p & " f where f.doc =  '" & txttipo.Text & txtnumfac.Text & "') as obs,  " _
        & " ( select comentario from parafacts where factura= 'RAPIDA') as com , " _
        & "(SELECT fp.descrip FROM facpagos" & p & " fp where fp.doc = '" & txttipo.Text & txtnumfac.Text & "') AS tpag, " _
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
        & " END AS tfac " _
        & " from parafacgral pg "

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
            fpag = tabla3.Rows(0).Item("tpag")
            tfac = tabla3.Rows(0).Item(8)
        Else
            MsgBox("")
        End If

        '.....................................
        Dim vd As String = ""
        vd = valordes.Text.Replace(",", ".")

        sql3 = " SELECT iva_d , SUM(( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & vd & "/100)))*(iva_d/100)) )as IVA FROM detafac09 d WHERE d.doc='" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' GROUP BY iva_d "
        '  sql3 = " Select iva_d , SUM(( (((vtotal/(1+(iva_d/100))))-(((vtotal/(1+(iva_d/100)))) * (" & txtdescuento.Text & "/100)))*(iva_d/100)) )as IVA FROM detafac09 d WHERE d.doc= '" & txttipo.Text.ToString & txtnumfac.Text.ToString & "' GROUP BY iva_d "
        'sql3 = " SELECT iva_d , SUM((d . valor -(d . valor /(1 +d . iva_d /100 )))*d . cantidad )AS IVA  FROM detafac09 d  WHERE d . doc ='" & txttipo.Text.ToString & txtnumfac.Text.ToString & "'  GROUP BY iva_d "

        Dim tabla4 As New DataTable
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        tabla4 = New DataTable
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        For i = 0 To tabla4.Rows.Count - 1
            v_iva = v_iva & Moneda2(tabla4.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
            tv_iva = tv_iva & "IVA " & (tabla4.Rows(i).Item(0).ToString) & " %" & vbCrLf
        Next

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")
        tel = tabla2.Rows(0).Item(5)
        email = tabla2.Rows(0).Item(6)
        dire = tabla2.Rows(0).Item(7)

        fac = txtnumfac.Text
        fec = txtfecha.Text
        cli = txtcliente.Text
        Ncli = txtnitc.Text
        vend = txtvendedor.Text
        des = "- " & txtdescuento.Text
        'des = "- " & lbdescuento.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql = " SELECT  d.doc , d.item as tipodoc, d.codart as idbod, d.nomart as comentario , " _
        & " d.cantidad as nitc, (d.valor/(1+(d.iva_d/100))) as nitvpre, " _
        & " ( (d.valor/(1+(iva_d/100))) * d.cantidad   ) as nitv, " _
        & " (SELECT logofac FROM  parafacts where factura = 'RAPIDA') AS logofac, " _
        & " f.iva as numfact,  f.total as margmin" _
        & " FROM facturas" & p & " f INNER JOIN(detafac" & p & " d) ON f.doc = d.doc WHERE f.doc = '" & txttipo.Text & txtnumfac.Text & "' " _
        & "ORDER BY item"

        TextBox1.Text = sql



        Dim tabla As DataSet
        tabla = New DataSet
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
            Premail.CurrentValues.AddValue(email.ToString)

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

            FrmReportFacRap.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRap.ShowDialog()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If

        FrmSelMovInventario.lbform.Text = "Factura"
        FrmSelMovInventario.ShowDialog()
    End Sub


    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txtcliente.Enabled = True
            txtnitc.Enabled = False
            'autocompletecliente()
        Else
            txtcliente.Enabled = False
            txtnitc.Enabled = True
        End If
    End Sub

    Private Sub txtcliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcliente.KeyPress

    End Sub

    Private Sub txtcliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcliente.LostFocus
        If txtcliente.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtnitc.Text = ""
            cargarclientes()
        Else
            BuscarClientesApell(txtcliente.Text)
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub

    Private Sub txtpagado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpagado.KeyPress
        ValidarMoneda(txtpagado, e)
    End Sub

    Private Sub txtpagado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpagado.LostFocus
        txtpagado.Text = Moneda2(txtpagado.Text, lb_imp_dec.Text)
    End Sub

    Private Sub txtpagado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpagado.TextChanged

        Try
            lbcambio.Text = Moneda2(CDbl(txtpagado.Text) - CDbl(txttotal.Text), lb_imp_dec.Text)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtcliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcliente.TextChanged

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
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentrocosto.Text & "'  and nivel ='centro';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtcentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentrocosto.Text
                txtcentrocosto.Text = ""
                FrmSelCentroCostos.lbform.Text = "FactRap"
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
                'MsgBox(ex.ToString)
            End Try
        Next
    End Sub
    Public Sub limpiarDatosAudi()
        txtnitc2.Text = ""
        txtnitv2.Text = ""
        cbaprobado2.Text = ""
        txtvmto2.Text = ""
        txtobserbaciones2.Text = ""
        txtcentro2.Text = ""
        txttotal2.Text = ""
        txtfecha2.Text = ""
    End Sub

    Function nivel_cuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & codigo & "' AND nivel='Auxiliar';"
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

    Private Sub txtfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfecha.ValueChanged
        If lbestado.Text = "NUEVO" Then
            Try
                fvmto.Value = txtfecha.Value
                txtvmto.Text = "0"
                Try
                    txtvmto_LostFocus(AcceptButton, AcceptButton)
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtvmto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvmto.LostFocus
        Try
            fvmto.Value = DateAdd("d", CInt(txtvmto.Text), txtfecha.Value)
        Catch ex As Exception
        End Try
    End Sub

   
    Private Sub fvmto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fvmto.ValueChanged
        txtvmto.Text = DateDiff("d", txtfecha.Value, fvmto.Value)
    End Sub
End Class