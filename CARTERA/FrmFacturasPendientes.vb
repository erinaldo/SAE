Public Class FrmFacturasPendientes
    Public lon_cta As Integer

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub


    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        txttipo.Items.Clear()
        lon_cta = valor_longitud_contable()
        'grupoctas.Enabled = True
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        PonerEnCero()
        lbestado.Text = "NUEVO"
        Try
            Parametros()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lbusuario.Text = FrmPrincipal.lbuser.Text
        txttipo.Enabled = True
        lbhora.Text = Format(Now, "HH:mm:ss")
        'txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
        'CalcularTotales()
        txtvmto.Text = "0"
        cbaprobado.Enabled = True
        'rbafecta1.Checked = True
        'cmditems.Enabled = True
        If FrmParContable.rb_si.Checked = False Then
            txtcentrocosto.Enabled = False
        End If
        txttipo.Focus()
        txtnitc.Enabled = True
        txtnitv.Enabled = True
        txtcod.Enabled = True
        txtdetalle.Enabled = True
    End Sub

    '************************************************************************
    ' Defino Variables Globales para manejo de Parametros
    Public tipo_fac1, tipo_fac2, tipo_fac3, tipo_fac4 As String

    Public Sub Parametros()
        Dim tabla As New DataTable
        '*********************FACTURA RAPIDA********************************
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        If tabla.Rows(0).Item("par_fac1").ToString <> "" Then
            txttipo.Items.Add(tabla.Rows(0).Item("par_fac1"))
        End If

        If tabla.Rows(0).Item("par_fac2").ToString <> "" Then
            txttipo.Items.Add(tabla.Rows(0).Item("par_fac2"))
        End If

        If tabla.Rows(0).Item("par_fac3").ToString <> "" Then
            txttipo.Items.Add(tabla.Rows(0).Item("par_fac3"))
        End If

        If tabla.Rows(0).Item("par_fac4").ToString <> "" Then
            txttipo.Items.Add(tabla.Rows(0).Item("par_fac4"))
        End If

        txtctasub.Text = tabla.Rows(0).Item("par_cta_ven")
        txtctaret.Text = tabla.Rows(0).Item("par_cta_ret")
        txtcuentaiva.Text = tabla.Rows(0).Item("par_cta_iva")
        txtcuentadesc.Text = tabla.Rows(0).Item("par_cta_des")
        txtctatotal.Text = tabla.Rows(0).Item("par_cta_cco")



        ''''''''''''''''''DOC PRE'''''''''''''''''''''''''''''''
        If lbestado.Text = "NUEVO" Then
            txttipo.Enabled = True
        End If
        'COMICION EN VENTAS
        'lbcomicion.Text = tabla.Rows(0).Item("comventa").ToString
        'PRECIO CON IVA INCLUIDO
        'lbprecioiva.Text = tabla.Rows(0).Item("ivainclu").ToString
        'FORMULA PARA CALCULAR PRECIO
        'lbformula.Text = tabla.Rows(0).Item("formcosto").ToString
    End Sub

    '///////////////////////////////////////////
    Public Sub PonerEnCero()
        'Timer1.Enabled = False
        lbhora.Text = "00:00:00"
        lbestado.Text = "NULO"
        txttipo.Enabled = False
        txttipo2.Text = ""
        txtnumfac.Text = ""
        lbnumero.Text = ""

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
        txtcodeudor.Text = ""
        txtcod.Text = ""
        txtsubtotal.Text = ""
        txtdescuento.Text = ""
        txtiva.Text = ""
        txttotal.Text = ""
        valordes.Text = "0,00"
        'lbsubtotal.Text = "0,00"
        'gfactura.RowCount = 1
        txtcuentadesc.Text = ""
        txtcuentaiva.Text = ""
        txtctasub.Text = ""
        txtret.Text = ""
        txtctaret.Text = ""
        cbaprobado.Text = ""
        txttotal.Text = ""

        lbusuario.Text = ""
        txtvmto.Text = "0"
        txtdetalle.Text = ""
        'txtobserbaciones.Text = ""
        txtfecha.Enabled = False
        'grupoafecta.Enabled = False
        txtcentrocosto.Enabled = True
        cbaprobado.Enabled = True
        txtcuentaiva.Enabled = True
        txtcuentadesc.Enabled = True

        'gfactura.Rows.Clear()
        'gfactura.RowCount = 1
        'gfp.Rows.Clear()
        'gfp.RowCount = 1
        'CalcularTotales()
    End Sub


    '///////////  DESPLAZAR REGISTROS    ///////////////////
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' ORDER BY tipodoc,num LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count < 1 Then
            MsgBox("No hay facturas los registros, favor agregue una.  ", MsgBoxStyle.Information, "Editar Factura ")
            PonerEnCero()
            Exit Sub
        End If
        'BuscarFactura(tabla.Rows(0).Item(0))
        lbnumero.Text = "1"
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnumero.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            'BuscarFactura(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                'BuscarFactura(tabla.Rows(0).Item(0))
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
            myCommand.CommandText = "SELECT count(*) FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                cmdNuevo_Click(AcceptButton, AcceptButton)
                Exit Sub
            End If
            myCommand.CommandText = "SELECT * FROM facturas" & PerActual(0) & PerActual(1) & " WHERE tipodoc<>'" & lbdocajuste.Text & "' ORDER BY tipodoc,num LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            ' BuscarFactura(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    ''//////////////// FIN DESPLAZAR REGISTROS  ///////////////////////////

    Private Sub FrmFacturasPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CmdPrimero_Click(AcceptButton, AcceptButton)

        lbestado.Text = "estado"
        txtfecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
        txttipo.Items.Clear()
    End Sub

    Private Sub txttipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtnumfac.Focus()
        End If
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
        If lbestado.Text = "NUEVO" Then
            VeificarRDIAN(txttipo.Text, Val(txtnumfac.Text), txtfecha.Value)
        End If
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
    
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        If lbestado.Text <> "CONSULTA" Then
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub

    Private Sub txtnumfac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumfac.TextChanged

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
            FrmSelCliente.lbform.Text = "fcp"
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
                frmterceros.lbform.Text = "fcp"
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

    Public Sub cargarclientes_co()
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
            FrmSelCliente.lbform.Text = "fcp_cob"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes_co(ByVal nit As String)
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
                frmterceros.lbform.Text = "fcp_co"
                frmterceros.txtnit.Text = txtcod.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtnitv.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcodeudor.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub

    Public Sub cargarvendedor()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = "fr_car"
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
            'cmditems.Focus()
        Else  'mostrar uno solo q coinside
            txtvendedor.Text = tabla.Rows(0).Item(1)
        End If
    End Sub

    Private Sub txtnitc_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
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
        'If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        'cmditems.Enabled = True
        'cmditems.Focus()
        'Else
        'gfactura.Focus()
        'End If
    End Sub


    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cmditems.Enabled = False
    End Sub


    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitv.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                txtnitv_LostFocus1(AcceptButton, AcceptButton)
            Else
                validarnumero(txtnitc, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtnitv_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus
        If txtnitv.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtvendedor.Text = ""
            cargarvendedor()
        Else
            Buscarvendedor()
        End If
        'If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        'cmditems.Enabled = True
        'cmditems.Focus()
        'Else
        'gfactura.Focus()
        'End If
    End Sub

    Private Sub txtcod_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtcod, e)
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtcod_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod.LostFocus
        If txtcod.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtcod.Text = ""
            cargarclientes_co()
        Else
            BuscarClientes_co(txtcod.Text)
        End If
        'If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
        'cmditems.Enabled = True
        'cmditems.Focus()
        'Else
        'gfactura.Focus()
        'End If
    End Sub

    Private Sub txtsubtotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsubtotal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtctasub.Focus()
        End If
    End Sub

    Private Sub txtsubtotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsubtotal.LostFocus
        txtsubtotal.Text = Moneda(txtsubtotal.Text)
    End Sub

    Private Sub txtdescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescuento.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtcuentadesc.Focus()
        End If
    End Sub


    Private Sub txtdescuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdescuento.LostFocus
        txtdescuento.Text = Moneda(txtdescuento.Text)
    End Sub

    Private Sub txtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtcuentaiva.Focus()
        End If
    End Sub


    Private Sub txtiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiva.LostFocus
        txtiva.Text = Moneda(txtiva.Text)
    End Sub

    Private Sub txtret_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtret.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            'txttotal.Text = Val(txtsubtotal.Text) + Val(txtiva.Text) - Val(txtret.Text) - Val(txtdescuento.Text)
            'txttotal.Text = Moneda(txttotal.Text)
            txtctaret.Focus()
        End If
    End Sub

    Private Sub txtret_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtret.LostFocus
        txtret.Text = Moneda(txtret.Text)
        txttotal.Text = Moneda(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtdescuento.Text) - CDbl(txtret.Text))
    End Sub

    Private Sub valordes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valordes.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtdescuento.Text = Moneda(CDbl(txtsubtotal.Text) * (CDbl(valordes.Text) / 100))
            'ValidarPorcentaje(valordes, e)
            txtdescuento.Focus()
        End If
    End Sub


    'txtsubtotal.Text = Moneda(CDbl(lbsubtotal.Text) - CDbl(txtiva.Text))
    Private Sub valordes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valordes.LostFocus
        valordes.Text = Moneda(valordes.Text)
    End Sub

    Private Sub valoriva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valoriva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtiva.Text = Moneda((CDbl(txtsubtotal.Text) - CDbl(txtdescuento.Text)) * (CDbl(valoriva.Text) / 100))

            'txtiva.Text = DIN(txtsubtotal.Text) * (DIN(valoriva.Text) / 100)
            txtiva.Focus()
        End If
    End Sub

    Private Sub valoriva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valoriva.LostFocus
        valoriva.Text = Moneda(valoriva.Text)
    End Sub

    Private Sub txtvalorret_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalorret.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtret.Text = Moneda((CDbl(txtsubtotal.Text) - CDbl(txtdescuento.Text)) * (CDbl(txtvalorret.Text) / 100))
            'txtret.Text = DIN(txtsubtotal.Text) * (DIN(txtvalorret.Text) / 100)
            txtret.Focus()
        End If
    End Sub

    Private Sub txtvalorret_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalorret.LostFocus
        txtvalorret.Text = Moneda(txtvalorret.Text)
    End Sub

    Private Sub txtcuentadesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentadesc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtcuentadesc.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtcuentadesc.Text) Then
                    valoriva.Focus()
                End If
            Else
                FrmCuentas.lbform.Text = "banco_car_fac_des"
                FrmCuentas.ShowDialog()
            End If

        End If
    End Sub

   

    Private Sub txtcuentaiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentaiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtcuentaiva.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtcuentaiva.Text) Then
                    txtvalorret.Focus()
                End If
            Else
                FrmCuentas.lbform.Text = "banco_car_fac_iva"
                FrmCuentas.ShowDialog()
            End If

        End If
    End Sub

  
  

    Private Sub txtctaret_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctaret.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtctaret.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtctaret.Text) Then
                    txtctatotal.Focus()
                End If
            Else
                FrmCuentas.lbform.Text = "banco_car_fac_ret"
                FrmCuentas.ShowDialog()
            End If

        End If
    End Sub

    Private Sub txtctaret_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaret.TextChanged

    End Sub


    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            cbaprobado.Focus()
        End If
    End Sub

    Private Sub txtvmto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvmto.TextChanged

    End Sub

    Private Sub cbaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            CmdListo.Focus()
        End If
    End Sub

    Private Sub cbaprobado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbaprobado.SelectedIndexChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            lbhora.Text = Format(Now, "HH:mm:ss")
        End If
    End Sub

    Private Sub cmdobservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdobservaciones.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmObsrvaciones.txtobservacion.Enabled = True
        Else
            FrmObsrvaciones.txtobservacion.Enabled = False
        End If
        FrmObsrvaciones.txtobservacion.Text = txtobserbaciones.Text
        FrmObsrvaciones.lbform.Text = "fp"
        FrmObsrvaciones.ShowDialog()
    End Sub
    Public Sub apagar_botones()
        txttipo.Enabled = False
        txtcliente.Enabled = False
        txtcod.Enabled = False
        txtcodeudor.Enabled = False
        txtdescuento.Enabled = False
        txtdetalle.Enabled = False
        txtiva.Enabled = False
        txtnitc.Enabled = False
        txtvmto.Enabled = False
        txtctaret.Enabled = False
        txtctasub.Enabled = False
        txtcuentadesc.Enabled = False
        txtnitv.Enabled = False
        txtsubtotal.Enabled = False

        txtcentrocosto.Enabled = False
        cbaprobado.Enabled = False
        txtcuentaiva.Enabled = False
        txtcuentadesc.Enabled = False
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Then
            MiConexion(bda)
            ValidarGuardar()
            apagar_botones()
            If cbaprobado.Text = "AP" Then
                'Guardar Asiento Contable....
            End If
            'GuardarContable()
        ElseIf lbestado.Text = "EDITAR" Then
            'ValidarModificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
        'CalcularTotales()
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

    Public Sub ValidarGuardar()
        'CalcularTotales()
        If txttipo2.Text = "" Then
            MsgBox("No ha escogido el tipo de factura, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txttipo.Focus()
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
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
            Dim t As New DataTable
            myCommand.CommandText = "SELECT doc FROM facturas" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()
            If t.Rows.Count > 0 Then
                If txtnumfac.Enabled = True Then
                    MsgBox("Verifique el numero de factura, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
                    txtnumfac.Focus()
                    Exit Sub
                Else
                    If conta < 3 Then
                        BuscarNumero()
                        conta = conta + 1
                    End If

                End If
            Else
                sw = 1
            End If
        Loop While sw = 0
        GuardarCOBDPEN()
    End Sub

    Public Sub GuardarContable()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
    End Sub

    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha.Value.Day.ToString)
            myCommand.Parameters.AddWithValue("?centro", Val(txtcentrocosto.Text))
            'myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                'myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                ' myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            ' myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", "0")
            myCommand.Parameters.AddWithValue("?diasv", Val(txtvmto.Text))
            If Val(txtvmto.Text) > 0 Then
                Dim fec As Date = DateAdd("d", Val(txtvmto.Text), txtfecha.Value)
                myCommand.Parameters.AddWithValue("?fechaven", Format(fec, "dd/MM/yyyy"))
            Else
                myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            End If
            myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            myCommand.Parameters.AddWithValue("?modulo", "facturacion")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?modulo);"
            myCommand.ExecuteNonQuery()
            'ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
   
    Public Sub GuardarCOBDPEN()
        Try
            'If gfp.Item("cual", 0).Value <> "Otra" Then Exit Sub
            'Dim cad As String '= txtcuentatotal.Text
            'If cad(0) & cad(1) <> "13" Then
            'Dim resultado As MsgBoxResult
            'resultado = MsgBox("Las cuenta (" & txtcuentatotal.Text & ") no pertenece a Cuentas por Pagar, ¿Desea Generar un Documento De Cuentas por Pagar?", MsgBoxStyle.YesNo, "Verificando")
            'If resultado = MsgBoxResult.No Then Exit Sub
            'End If
            ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR TABLA COBDPEN'''''''''''''''''''''''''''''''
            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo", txttipo.Text)
            myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
            myCommand.Parameters.AddWithValue("?descrip", "")
            myCommand.Parameters.AddWithValue("?tipafec", "")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text)
            myCommand.Parameters.AddWithValue("?nomnit", txtcliente.Text)
            myCommand.Parameters.AddWithValue("?nitcod", txtcod.Text)
            myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text)
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text))
            'dias de vmto
            myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
            myCommand.Parameters.AddWithValue("?concepto", txtdetalle.Text)
            'subtotal
            myCommand.Parameters.AddWithValue("?subtotal", DIN(txtsubtotal.Text))
            'descuento
            myCommand.Parameters.AddWithValue("?descto", DIN(txtdescuento.Text))
            'rete_fuente
            myCommand.Parameters.AddWithValue("?ret", DIN(txtret.Text))
            'iva
            myCommand.Parameters.AddWithValue("?iva", DIN(valoriva.Text))
            myCommand.Parameters.AddWithValue("?v_iva", DIN(txtiva.Text))
            'total
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            'cuentas
            myCommand.Parameters.AddWithValue("?ctasubtotal", txtctasub.Text)
            myCommand.Parameters.AddWithValue("?ctaret", txtctaret.Text)
            myCommand.Parameters.AddWithValue("?ctaiva", txtcuentaiva.Text)
            myCommand.Parameters.AddWithValue("?ctatotal", txtctatotal.Text)
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
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            ValidarConsecutivo()
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtcentrocosto_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentrocosto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                'validarnumero(txtcentro, e)
                BuscarCC()
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcentrocosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentrocosto.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCC()
    End Sub

    Public Sub BuscarCC()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentrocosto.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcentrocosto.Text = ""
            If tabla.Rows.Count > 0 Then
                txtcentrocosto.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentrocosto.Text
                FrmSelCentroCostos.lbform.Text = "cc_p"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcentrocosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentrocosto.TextChanged

    End Sub

    Private Sub txtctasub_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctasub.DoubleClick
        FrmCuentas.lbform.Text = "banco_car_fac"
        FrmCuentas.ShowDialog()
    End Sub

    Function Verificar(ByVal cuenta As String) As Boolean
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function valor_longitud_contable() As Integer
        Dim tabla As New DataTable
        Dim x1 As Integer
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        x1 = tabla.Rows(0).Item("longitud")
        Return x1
    End Function


    Private Sub txtctasub_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctasub.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtctasub.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtctasub.Text) Then
                    valordes.Focus()
                End If
            Else
                FrmCuentas.lbform.Text = "banco_car_fac_sub"
                FrmCuentas.ShowDialog()
            End If
            'Else
            '   e.Handled = True
        End If
    End Sub


    Private Sub txtctatotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctatotal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Len(txtctatotal.Text) = lon_cta Then
                'SendKeys.Send("{TAB}")
                If Verificar(txtctatotal.Text) Then
                    txtvmto.Focus()
                End If
            Else
                FrmCuentas.lbform.Text = "banco_car_fac_tot"
                FrmCuentas.ShowDialog()
            End If
            'Else
            '   e.Handled = True
        End If
    End Sub

    Private Sub txtctasub_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctasub.TextChanged

    End Sub

    Private Sub txtsubtotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal.TextChanged

    End Sub

    Private Sub txtnitc_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged

    End Sub

    Private Sub txtnitv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged

    End Sub

    Private Sub txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcod.TextChanged

    End Sub

    Private Sub txtcuentadesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuentadesc.TextChanged

    End Sub

    Private Sub txtcuentaiva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuentaiva.TextChanged

    End Sub

    Private Sub txtctatotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctatotal.TextChanged

    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

    End Sub
End Class

