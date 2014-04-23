Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class frmterceros
    Public sw As Integer

    Private Sub frmterceros_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cbtipo.Enabled = True
        cmdcancelar.Enabled = True
        lbestado.Text = ""
        cmdcancelar_Click_1(AcceptButton, AcceptButton)
        txtnit.Focus()
    End Sub
    Private Sub frmclientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '********UPDATE TERCEROS***********************
        MiConexion(bda)
        Try
            myCommand.CommandText = "ALTER TABLE  `terceros` ADD  `dia` VARCHAR( 2 ) NOT NULL AFTER  `web` ,ADD  `mes` VARCHAR( 15 ) NOT NULL AFTER  `dia`,ADD  `contacto` VARCHAR( 100 ) NOT NULL AFTER  `mes` ,ADD  `telconta` VARCHAR( 15 ) NOT NULL AFTER  `contacto` ,ADD  `cupo` DOUBLE NOT NULL AFTER  `telconta` ,ADD  `vmto` BIGINT NOT NULL AFTER  `cupo` ,ADD  `iva` VARCHAR( 2 ) NOT NULL AFTER  `vmto` ," _
                                  & "ADD  `retef` VARCHAR( 2 ) NOT NULL AFTER  `iva` ,ADD  `reteiva` VARCHAR( 2 ) NOT NULL AFTER  `retef` ,ADD  `reteica` VARCHAR( 2 ) NOT NULL AFTER  `reteiva` ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.CommandText = "ALTER TABLE  `terceros` ADD  `pais` VARCHAR( 10 ) NOT NULL AFTER  `dir` ,ADD  `dept` VARCHAR( 10 ) NOT NULL AFTER  `pais` ,ADD  `mun` VARCHAR( 10 ) NOT NULL AFTER  `dept` ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            myCommand.CommandText = "ALTER TABLE  `terceros` ADD  `dv` VARCHAR( 2 ) NOT NULL AFTER  `nit` ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Cerrar()
        '*********************************************
        cbpais.Text = "COLOMBIA"
        cbpais2.Text = "169"
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.dptos ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
            MsgBox("No hay departamentos creados, Verifique", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        cbdep.Items.Clear()
        cbdep.Text = ""
        cbdep2.Items.Clear()
        cbdep2.Text = ""
        For i = 0 To tabla.Rows.Count - 1
            cbdep2.Items.Add(UCase(tabla.Rows(i).Item("codigo")))
            cbdep.Items.Add(UCase(tabla.Rows(i).Item("descripcion")))
        Next
        sw = 0
        txtnit.Focus()
        If lbestado.Text = "CONSULTA" Or lbestado.Text = "NULO" Or lbestado.Text = "" Then
            lbestado.Text = ""
            cmdcancelar_Click_1(AcceptButton, AcceptButton)
        ElseIf lbestado.Text = "NUEVO" Then
            lbestado.Text = ""
            Dim nitaxu As String = txtnit.Text
            cmdNuevo_Click(AcceptButton, AcceptButton)
            txtnit.Text = nitaxu
            txtnit.Focus()
        End If
    End Sub
    Public Sub BuscarMunicipio(ByVal dpt As String)
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT m.descripcion,m.codmun FROM sae.mun m LEFT JOIN (sae.dptos d) ON m.coddep = d.codigo WHERE d.codigo = '" & dpt & "' ORDER BY m.descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
            MsgBox("No hay municipios creados, Verifique", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        cbciudad.Items.Clear()
        cbciudad.Text = ""
        cbciudad2.Items.Clear()
        cbciudad2.Text = ""
        For i = 0 To tabla.Rows.Count - 1
            cbciudad.Items.Add(tabla.Rows(i).Item("descripcion"))
            cbciudad2.Items.Add(tabla.Rows(i).Item("codmun"))
        Next
    End Sub

    Public Sub Validar()
        If txtnit.Text = "" Then
            MsgBox("Por favor digite el Nit/cedula del tercero, Verifique", MsgBoxStyle.Information, "Verificando")
            txtnit.Focus()
            Exit Sub
        ElseIf txtnombre.Text = "" Then
            MsgBox("Por favor digite el Nombre del tercero, Verifique", MsgBoxStyle.Information, "Verificando")
            txtnombre.Focus()
            Exit Sub
        ElseIf txtapellido.Text = "" Then
            MsgBox("Por favor digite el Apellido del tercero, Verifique", MsgBoxStyle.Information, "Verificando")
            txtapellido.Focus()
            Exit Sub
        End If
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from terceros where nit='" & txtnit.Text.ToString & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <> 0 Then
            MsgBox("La Pesona Ya Se Encuentra En Los Registros, Verifique", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If FrmPrincipal.cmdOrden.Visible = True Then
            GuardarPres()
        End If
        Guardar()
        
    End Sub
    Private Sub GuardarPres()
        Try
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text.ToString & "-" & LABELDV.Text.ToString)
            myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
            myCommand.Parameters.AddWithValue("?Apellidos", txtapellido.Text.ToString)
            myCommand.Parameters.AddWithValue("?telefono", txttel.Text.ToString)
            myCommand.Parameters.AddWithValue("?celular", txtcel.Text.ToString)
            myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
            myCommand.Parameters.AddWithValue("?correo", txtcorreo.Text.ToString)
            myCommand.CommandText = "INSERT INTO presupuesto" & Strings.Right(PerActual, 4) & ".terceros " _
                                    & " Values('CC',?nit,?nombre,?apellidos,'','',?telefono,?celular,?dir, " _
                                    & " ?correo,'','','OTROS','A')"
            myCommand.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Guardar()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?nit", txtnit.Text.ToString)
        myCommand.Parameters.AddWithValue("?dv", LABELDV.Text.ToString)
        myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
        myCommand.Parameters.AddWithValue("?Apellidos", txtapellido.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
        If rbnatural.Checked = True Then
            myCommand.Parameters.AddWithValue("?persona", "natural".ToString)
        Else
            myCommand.Parameters.AddWithValue("?persona", "juridica".ToString)
        End If
        myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
        myCommand.Parameters.AddWithValue("?pais", cbpais2.Text.ToString)
        myCommand.Parameters.AddWithValue("?dept", cbdep2.Text.ToString)
        myCommand.Parameters.AddWithValue("?mun", cbciudad2.Text.ToString)
        myCommand.Parameters.AddWithValue("?telefono", txttel.Text.ToString)
        myCommand.Parameters.AddWithValue("?celular", txtcel.Text.ToString)
        myCommand.Parameters.AddWithValue("?fax", txtfax.Text.ToString)
        myCommand.Parameters.AddWithValue("?correo", CambiaCadena(txtcorreo.Text.ToString, 150))
        myCommand.Parameters.AddWithValue("?web", txtweb.Text.ToString)
        myCommand.Parameters.AddWithValue("?dia", cbdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?mes", cbmes.Text.ToString)
        myCommand.Parameters.AddWithValue("?contacto", CambiaCadena(txtcontacto.Text.ToString, 100))
        myCommand.Parameters.AddWithValue("?telconta", txttelcon.Text.ToString)
        Try
            myCommand.Parameters.AddWithValue("?cupo", CDbl(txtcupo.Text.ToString))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cupo", "0")
        End Try
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvencimiento.Text.ToString))
        myCommand.Parameters.AddWithValue("?iva", cbiva.Text.ToString)
        myCommand.Parameters.AddWithValue("?retef", cbrf.Text.ToString)
        myCommand.Parameters.AddWithValue("?reteiva", cbreteiva.Text.ToString)
        myCommand.Parameters.AddWithValue("?reteica", cbreteica.Text.ToString)
        '..
        myCommand.Parameters.AddWithValue("?retecree", cbretCree.Text.ToString)
        myCommand.Parameters.AddWithValue("?act1", txtAct1.Text.ToString)
        myCommand.Parameters.AddWithValue("?act2", txtAct2.Text.ToString)
        myCommand.Parameters.AddWithValue("?act3", txtAct3.Text.ToString)
        myCommand.Parameters.AddWithValue("?act4", txtAct4.Text.ToString)
        '..
        myCommand.Parameters.AddWithValue("?ctab1", txtctab1.Text.ToString)
        myCommand.Parameters.AddWithValue("?ctab2", txtctab1.Text.ToString)
        myCommand.CommandText = "INSERT INTO terceros " _
                                & " Values(?nit,?dv,?nombre,?apellidos,?tipo,?persona,?dir,?pais,?dept,?mun,?telefono,?celular,?fax,?correo,?web, " _
                                & " ?dia,?mes,?contacto,?telconta,?cupo,?vmto,?iva,?retef,?reteiva,?reteica,'',?retecree,?act1,?act2,?act3,?act4,?ctab1,?ctab2)"

        myCommand.ExecuteNonQuery()
        txtnit.ReadOnly = True
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "GUARDADO"
        BloquerCombos()
        Cerrar()
        CerrarForm()
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del tercero se van a modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            'myCommand.Parameters.AddWithValue("?nit", txtnit.Text.ToString)
            myCommand.Parameters.AddWithValue("?dv", LABELDV.Text.ToString)
            myCommand.Parameters.AddWithValue("?nombre", txtnombre.Text.ToString)
            myCommand.Parameters.AddWithValue("?apellido", txtapellido.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
            If rbnatural.Checked = True Then
                myCommand.Parameters.AddWithValue("?persona", "natural".ToString)
            Else
                myCommand.Parameters.AddWithValue("?persona", "juridica".ToString)
            End If
            myCommand.Parameters.AddWithValue("?dir", txtdir.Text.ToString)
            myCommand.Parameters.AddWithValue("?pais", cbpais2.Text.ToString)
            myCommand.Parameters.AddWithValue("?dept", cbdep2.Text.ToString)
            myCommand.Parameters.AddWithValue("?mun", cbciudad2.Text.ToString)
            myCommand.Parameters.AddWithValue("?telefono", txttel.Text.ToString)
            myCommand.Parameters.AddWithValue("?celular", txtcel.Text.ToString)
            myCommand.Parameters.AddWithValue("?fax", txtfax.Text.ToString)
            myCommand.Parameters.AddWithValue("?correo", txtcorreo.Text.ToString)
            myCommand.Parameters.AddWithValue("?web", txtweb.Text.ToString)
            myCommand.Parameters.AddWithValue("?dia", cbdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?mes", cbmes.Text.ToString)
            myCommand.Parameters.AddWithValue("?contacto", txtcontacto.Text.ToString)
            myCommand.Parameters.AddWithValue("?telconta", txttelcon.Text.ToString)
            Try
                myCommand.Parameters.AddWithValue("?cupo", CDbl(txtcupo.Text.ToString))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?cupo", "0")
            End Try
            myCommand.Parameters.AddWithValue("?vmto", Val(txtvencimiento.Text.ToString))
            myCommand.Parameters.AddWithValue("?iva", cbiva.Text.ToString)
            myCommand.Parameters.AddWithValue("?retef", cbrf.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteiva", cbreteiva.Text.ToString)
            myCommand.Parameters.AddWithValue("?reteica", cbreteica.Text.ToString)
            '....
            myCommand.Parameters.AddWithValue("?retecree", cbretCree.Text.ToString)
            myCommand.Parameters.AddWithValue("?act1", txtAct1.Text.ToString)
            myCommand.Parameters.AddWithValue("?act2", txtAct2.Text.ToString)
            myCommand.Parameters.AddWithValue("?act3", txtAct3.Text.ToString)
            myCommand.Parameters.AddWithValue("?act4", txtAct4.Text.ToString)
            '...
            myCommand.Parameters.AddWithValue("?ctab1", txtctab1.Text.ToString)
            myCommand.Parameters.AddWithValue("?ctab2", txtctab2.Text.ToString)

            myCommand.CommandText = "Update terceros set dv=?dv,nombre=?nombre, apellidos=?apellido, " _
                                  & "tipo=?tipo, persona=?persona, dir=?dir, pais=?pais,dept=?dept,mun=?mun, telefono=?telefono, " _
                                  & "celular=?celular, fax=?fax, correo=?correo, web=?web, " _
                                  & "dia=?dia,mes=?mes,contacto=?contacto,telconta=?telconta,cupo=?cupo,vmto=?vmto,iva=?iva,retef=?retef, " _
                                  & " reteiva=?reteiva,reteica=?reteica,nomina='',retecree=?retecree, act1=?act1, act2=?act2, act3=?act3, act4=?act4 " _
                                  & " ,cta_banco1=?ctab1,cbanco=?ctab2 WHERE nit='" & txtnit.Text.ToString & "';"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            BloquerCombos()
            lbestado.Text = "EDITADO"
            CerrarForm()
        End If
    End Sub
    Public Sub CerrarForm()
        Select Case lbform.Text
            Case "ingop"
                FrmCIordenes.txtnit.Text = txtnit.Text
                FrmCIordenes.txtnomt.Text = Trim(txtnombre.Text & " " & txtapellido.Text)
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "ORDEN"
                FrmOrdenPagos.txtnit.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "citaE"
                FrmGestionCitas.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fcp_co"
                FrmFacturasPendientes.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fr"
                Frmfacturarapida.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fn"
                FrmFacturasyAjustes.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fn_sp"
                FrmFacturasyAjustesSP.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fp"
                FrmEntraPedidos.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "fdp"
                FrmDocProveedor.txtnitc.Text = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
            Case "NucleoF"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmNucleoFami.grilla.Item(0, fil).Value = txtnit.Text
                FrmNucleoFami.grilla.Item(1, fil).Value = txtnombre.Text & " " & txtapellido.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "doccon"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmDocConciliaB.gitems.Item(7, fil).Value = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "generadoc"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmEntradaDatos.grilla.Item(7, fil).Value = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "Gce"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmComEgresoCpp.grilla.Item(6, fil).Value = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "generadoc_txt"
                FrmEntradaDatos.txtnit.Text = txtnit.Text
                FrmEntradaDatos.txtnombre.Text = Trim(txtnombre.Text & " " & txtapellido.Text)
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "si"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmSaldosIniciales.grilla.Item(7, fil).Value = txtnit.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "si_txt"
                FrmSaldosIniciales.txtnit.Text = txtnit.Text
                FrmSaldosIniciales.txtnombre.Text = Trim(txtnombre.Text & " " & txtapellido.Text)
                Me.Close()
            Case "entradas"
                FrmEntradas.txtnitc.Text = txtnit.Text
                FrmEntradas.txtcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "salidas"
                FrmSalidas.txtnitc.Text = txtnit.Text
                FrmSalidas.txtcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "comproEg"
                FrmComEgresoCpp.txtnit.Text = txtnit.Text
                FrmComEgresoCpp.lbcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "comproIn"
                FrmCompIngresos.txtnit.Text = txtnit.Text
                FrmCompIngresos.lbcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "comproRo"
                FrmRecibodeCaja.txtnit.Text = txtnit.Text
                FrmRecibodeCaja.lbcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "nc"
                FrmNotaCredito.txtnit.Text = txtnit.Text
                FrmNotaCredito.lbcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "nc"
                FrmNotaDebito.txtnit.Text = txtnit.Text
                FrmNotaDebito.lbcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "oc"
                FrmOrdenCompra.txtnitc.Text = txtnit.Text
                FrmOrdenCompra.txtcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "cpp_si"
                FrmSaldosInicialesCPP.txtnit.Text = txtnit.Text
                FrmSaldosInicialesCPP.txtcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
            Case "sic"
                FrmSaldosInicialesCPP.txtnit.Text = txtnit.Text
                FrmSaldosInicialesCPP.txtcliente.Text = txtapellido.Text & " " & txtnombre.Text
                cmdcancelar_Click_1(AcceptButton, AcceptButton)
                Me.Close()
        End Select
    End Sub
    Public Sub Buscar(ByVal x As String)
        Dim items As Integer
        Dim tabla As New DataTable
        If x = "" Then Exit Sub
        myCommand.CommandText = "SELECT * from terceros where nit='" & x & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("La Pesona No Se Encuentra En Los Registros, Verifique", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        txtnit.Text = tabla.Rows(0).Item("nit")
        cbtipo.Text = tabla.Rows(0).Item("tipo")
        If tabla.Rows(0).Item("persona") = "natural" Then
            rbnatural.Checked = True
        Else
            rbjuridica.Checked = True
        End If
        txtnombre.Text = tabla.Rows(0).Item("nombre")
        txtapellido.Text = tabla.Rows(0).Item("apellidos")
        '******************************
        txtdir.Text = ""
        txtdir.Text = tabla.Rows(0).Item("dir")
        cbpais2.Text = tabla.Rows(0).Item("pais")
        cbdep2.Text = tabla.Rows(0).Item("dept")
        cbciudad2.Text = tabla.Rows(0).Item("mun")

        '***************************************
        txttel.Text = tabla.Rows(0).Item("telefono")
        txtcel.Text = tabla.Rows(0).Item("celular")
        txtfax.Text = tabla.Rows(0).Item("fax")
        txtcorreo.Text = tabla.Rows(0).Item("correo")
        txtweb.Text = tabla.Rows(0).Item("web")
        '*******************************************
        cbdia.Text = tabla.Rows(0).Item("dia")
        cbmes.Text = tabla.Rows(0).Item("mes")
        txtcontacto.Text = tabla.Rows(0).Item("contacto")
        txttelcon.Text = tabla.Rows(0).Item("telconta")
        txtcupo.Text = Moneda(tabla.Rows(0).Item("cupo"))
        txtvencimiento.Text = Val(tabla.Rows(0).Item("vmto"))
        '******************************************************
        cbiva.Text = tabla.Rows(0).Item("iva")
        cbrf.Text = tabla.Rows(0).Item("retef")
        cbreteiva.Text = tabla.Rows(0).Item("reteiva")
        cbreteica.Text = tabla.Rows(0).Item("reteica")
        txtnit.ReadOnly = True
        cbretCree.Text = tabla.Rows(0).Item("retecree")
        txtAct1.Text = tabla.Rows(0).Item("act1")
        txtAct2.Text = tabla.Rows(0).Item("act2")
        txtAct3.Text = tabla.Rows(0).Item("act3")
        txtAct4.Text = tabla.Rows(0).Item("act4")
        '..
        txtctab1.Text = tabla.Rows(0).Item("cta_banco1")
        txtctab2.Text = tabla.Rows(0).Item("cbanco")
        BloquerCombos()
        lbestado.Text = "CONSULTA"
        sw = 1
    End Sub
    Private Sub rbjuridica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lb1.Visible = False
        txtapellido.Text = "(ninguno)"
        txtapellido.Enabled = False
    End Sub
    Private Sub rbnatural_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lb1.Visible = True
        txtapellido.Enabled = True
        txtapellido.Text = ""
    End Sub
    '''''''''''VALIDACIONES DE NUMEROS  '''''''''''''''''''
    Private Sub txttel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txttel, e)
    End Sub
    Private Sub txtcel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txtcel, e)
    End Sub
    Private Sub txtfax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txtfax, e)
    End Sub
    Private Sub txttelcon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txttelcon, e)
    End Sub
    Private Sub txtcupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txtcupo, e)
    End Sub
    Private Sub txtvencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarnumero(txtvencimiento, e)
    End Sub
    '''''''''VALIDACIONES DE LETRAS '''''''''''''''''''''''
    Private Sub txtapellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarletra(txtapellido, e)
    End Sub
    Private Sub txtnombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarletra(txtnombre, e)
    End Sub
    Private Sub txtcontacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        validarletra(txtcontacto, e)
    End Sub

    Private Sub cbiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnit_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Then
                ValidarNIT(txtnit, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT nit FROM terceros ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows.Count > 0 Then
            For i = 0 To tb.Rows.Count - 1
                If lbestado.Text = "NUEVO" Then
                    If tb.Rows(i).Item(0) = txtnit.Text Then
                        MsgBox("El Tercero ya se encuentra registrado", MsgBoxStyle.Information)
                        Buscar(txtnit.Text)
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        LABELDV.Text = DigitoNIT(txtnit.Text)
    End Sub

    Private Sub rbjuridica_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbjuridica.CheckedChanged
        txtapellido.Text = "  "
        txtapellido.BackColor = Color.SteelBlue
        txtapellido.Enabled = False
        lb1.Visible = False
        txtnombre.Focus()
    End Sub
    Private Sub rbnatural_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnatural.CheckedChanged
        txtapellido.Text = ""
        txtapellido.BackColor = Color.White
        txtapellido.Enabled = True
        lb1.Visible = True
        txtapellido.Focus()
    End Sub

    Private Sub cbtipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbtipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbpais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbdep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbrf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbrf.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbreteiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbreteiva.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbreteica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbreteica.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If per_ter <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        HabilitarCombos()
        txtnit.ReadOnly = False
        txtnit.Enabled = True
        txtnit.Text = ""
        txtapellido.Text = ""
        txtnombre.Text = ""
        cbtipo.Text = "CLIENTES"
        gper.Enabled = True
        rbnatural.Checked = True
        txtctab1.Text = ""
        txtctab2.Text = ""
        txtdir.Text = ""
        txttel.Text = ""
        txtcel.Text = ""
        txtfax.Text = ""
        txtcorreo.Text = ""
        txtweb.Text = ""
        txtcontacto.Text = ""
        txttelcon.Text = ""
        txtcupo.Text = "0,00"
        txtvencimiento.Text = "0"
        cbdia.Text = ""
        cbmes.Text = ""
        cbiva.Text = "SI"
        cbrf.Text = "NO"
        cbretCree.Text = "NO"
        cbreteiva.Text = "NO"
        cbreteica.Text = "NO"
        lbnroobs.Text = 0

        cbpais2.Text = "169"
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT dpto, mun FROM sae.companias;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                cbdep2.Text = tabla.Rows(0).Item(0)
                cbciudad2.Text = tabla.Rows(0).Item(1)
            End If
        Catch ex As Exception
            cbdep2.Text = "20"
            cbciudad2.Text = "20001"
        End Try
        lbestado.Text = "NUEVO"
        txtnit.Focus()
    End Sub
    Private Sub cmdguardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Try
            If lbestado.Text = "NUEVO" Then
                Validar()
            ElseIf lbestado.Text = "EDITAR" Then
                Modificar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdcancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdmodificar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        Try
            If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "ELIMINADO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If per_ter <> "E" Then
                MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
                Exit Sub
            End If
            'If txtnit.Text = "0" Then
            '    MsgBox("El NIT 0 no puede ser editado, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            '    Exit Sub
            'End If
            HabilitarCombos()
            lbestado.Text = "EDITAR"
            gper.Enabled = True
            txtnombre.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        Dim x As String
        x = Trim(InputBox("Digite el Nit/Cedula Del Tercero", "Buscar"))
        Buscar(x)
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelCliente.lbform.Text = "terceros"
        FrmSelCliente.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            Buscar(txtnit.Text)
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nit FROM terceros ORDER BY nombre,apellidos LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                txtnit.Text = ""
                txtapellido.Text = ""
                txtnombre.Text = ""
                txtdir.Text = ""
                txttel.Text = ""
                txtcel.Text = ""
                txtfax.Text = ""
                txtcorreo.Text = ""
                txtweb.Text = ""
                txtcontacto.Text = ""
                txttelcon.Text = ""
                txtcupo.Text = ""
                txtAct1.Text = ""
                txtAct2.Text = ""
                txtAct3.Text = ""
                txtAct4.Text = ""
                txtvencimiento.Text = ""
                lbnroobs.Text = 0
                lbestado.Text = "NULO"
                cmdNuevo.Focus()
            Else
                Refresh()
                txtnit.Text = tabla.Rows(0).Item("nit")
                Buscar(txtnit.Text)
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT nit FROM terceros ORDER BY nombre,apellidos LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtnit.Text = tabla.Rows(0).Item("nit")
                Buscar(txtnit.Text)
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM terceros"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT nit FROM terceros ORDER BY nombre,apellidos LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                txtnit.Text = tabla.Rows(0).Item("nit")
                Buscar(txtnit.Text)
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM terceros"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT nit FROM terceros ORDER BY nombre,apellidos LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtnit.Text = tabla.Rows(0).Item("nit")
            Buscar(txtnit.Text)
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub

    Private Sub txtapellido_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtapellido.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarletra(txtapellido, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtnombre_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdir.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txttel_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txttel, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcel_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcel.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtcel, e)
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtfax_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            validarnumero(txtfax, e)
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtcorreo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorreo.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtweb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtweb.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cbdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbdia.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub cbmes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbmes.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtcontacto_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontacto.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txttelcon_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelcon.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                validarnumero(txttelcon, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtcupo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcupo.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                ValidarMoneda(txtcupo, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtvencimiento_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvencimiento.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                validarnumero(txtvencimiento, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rbjuridica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbjuridica.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub rbnatural_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbnatural.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtcupo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcupo.LostFocus
        txtcupo.Text = Moneda(txtcupo.Text)
    End Sub

    Public Sub BloquerCombos()
        gper.Enabled = False
        cbretCree.Enabled = False
        cbtipo.Enabled = False
        cbdia.Enabled = False
        cbmes.Enabled = False
        cbiva.Enabled = False
        cbrf.Enabled = False
        cbreteiva.Enabled = False
        cbreteica.Enabled = False
        cbpais.Enabled = False
        cbdep.Enabled = False
        cbciudad.Enabled = False
        '*********** COMANDOS *********
        cmdNuevo.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdmodificar.Enabled = True
        CmdEliminar.Enabled = True
        CmdBuscar.Enabled = True
        CmdMostrar.Enabled = True
        cmdprint.Enabled = True
    End Sub
    Public Sub HabilitarCombos()
        cbretCree.Enabled = True
        gper.Enabled = True
        cbtipo.Enabled = True
        cbdia.Enabled = True
        cbmes.Enabled = True
        cbiva.Enabled = True
        cbrf.Enabled = True
        cbreteiva.Enabled = True
        cbreteica.Enabled = True
        cbpais.Enabled = True
        cbdep.Enabled = True
        cbciudad.Enabled = True
        '*********** COMANDOS *********
        cmdNuevo.Enabled = False
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        cmdmodificar.Enabled = False
        CmdEliminar.Enabled = False
        CmdBuscar.Enabled = False
        CmdMostrar.Enabled = False
        cmdprint.Enabled = False
    End Sub

    Private Sub cbdep_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbdep.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbdep_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdep.SelectedIndexChanged
        cbdep2.SelectedIndex = cbdep.SelectedIndex
        BuscarMunicipio(cbdep2.Text)
        Try
            cbciudad.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbciudad_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbciudad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub cbciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbciudad.SelectedIndexChanged
        cbciudad2.SelectedIndex = cbciudad.SelectedIndex
    End Sub
    '********************************************
    Private Sub cbpais2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpais2.SelectedIndexChanged
        cbpais.Text = "COLOMBIA"
    End Sub
    Private Sub cbdep2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdep2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.dptos WHERE codigo='" & cbdep2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
        Else
            cbdep.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub

    Private Sub cbciudad2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbciudad2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.mun WHERE codmun='" & cbciudad2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then

        Else
            cbciudad.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub

    Private Sub cbpais_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbpais.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub
    Private Sub cbpais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbpais.SelectedIndexChanged

    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        'GenerarPDF()
        FrmInfTerceros.ShowDialog()
    End Sub
    Dim cb As PdfContentByte
    Dim k, pag, tope As Integer
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        pag = 0
        tope = 40
        Try
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner()
            k = k - 10
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********CUERPO*******************
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT t.*,m.descripcion,TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS ter FROM terceros t " _
                                  & "LEFT JOIN (sae.mun m) " _
                                  & "ON t.mun=m.codmun " _
                                  & "ORDER BY ter;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k < tope Then 'NUEVA PAGINA
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("nit") & "-" & tabla.Rows(i).Item("dv"), 7, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(Trim(tabla.Rows(i).Item("ter")), 39), 62, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("tipo"), 246, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("telefono"), 293, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("celular"), 350, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(tabla.Rows(i).Item("dir"), 30), 400, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(i).Item("descripcion"), 530, k, 0)
            Next
            ''''''''FIN'''''''''
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
            'ABRIR FORMULARIO DESEADO
            Me.Cursor = Cursors.Default
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
            If oDoc.IsOpen Then
                oDoc.Close()
                Exit Sub
            End If
        Finally
            Me.Cursor = Cursors.Default
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        '************************************************
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "REPORTE DE TERCEROS", 230, 770, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 760, 0)
        k = 750
        cb.ShowTextAligned(50, "NIT - DV ", 7, k, 0)
        cb.ShowTextAligned(50, "NOMBRES Y APELLIDOS ", 62, k, 0)
        cb.ShowTextAligned(50, "TIPO ", 246, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TELEFONO", 293, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CELULAR", 350, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "DIRECCION", 400, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CIUDAD", 530, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If per_ter <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        Eliminar()
    End Sub

    Public Sub Eliminar()
        If VerificarMov() = True Then
            MsgBox("El tercero NIT/CEDULA " & txtnit.Text & " (" & Trim(txtnombre.Text & " " & txtapellido.Text) & ") tiene movimientos contables, verifique. ", MsgBoxStyle.Information, "SAE verificación")
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del tercero NIT/CEDULA " & txtnit.Text & " (" & Trim(txtnombre.Text & " " & txtapellido.Text) & ") se van a borrar, ¿Desea Eliminarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Try
                    MiConexion(bda)
                    myCommand.CommandText = "DELETE FROM terceros WHERE nit = '" & Trim(txtnit.Text) & "';"
                    myCommand.ExecuteNonQuery()
                    Refresh()
                    lbestado.Text = "ELIMINADO"
                    MsgBox("La Base De Datos Se Actualizó Correctamente (Tercero Borrado).  ", MsgBoxStyle.Information, "Borrar Datos")
                    Cerrar()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub
    Function VerificarMov()
        Dim res As Boolean = False
        Try
            Dim per As String = ""
            Dim t As New DataTable
            For i = 0 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                t.Clear()
                myCommand.CommandText = "SELECT count(*) FROM documentos" & per & " WHERE nit = '" & txtnit.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) > 0 Then
                    Return True
                    Exit Function
                End If
            Next
            res = False
        Catch ex As Exception
            MsgBox(ex.ToString)
            res = True
        End Try
        Return res
    End Function

    Private Sub cmdEdNit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdNit.Click
        If txtnit.Text <> "" Then
            FrmEditarNit.ShowDialog()
        End If
    End Sub

    Private Sub GRUPO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRUPO.Enter

    End Sub

    Private Sub txtAct1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct1.DoubleClick
        If BuscarAct(txtAct1.Text) = False Then
            txtAct1.Text = ""
            Try
                FrmActEco.lbform.Text = "TerAct1"
                FrmActEco.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
   
    Function BuscarAct(ByVal act As String)
        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT * FROM retecree where codigo='" & act & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Sub txtAct2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct2.DoubleClick
        If BuscarAct(txtAct2.Text) = False Then
            txtAct2.Text = ""
            Try
                FrmActEco.lbform.Text = "TerAct2"
                FrmActEco.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtAct3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct3.DoubleClick
        txtAct3.Text = ""
        Try
            FrmActEco.lbform.Text = "TerAct3"
            FrmActEco.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtAct4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct4.DoubleClick
        txtAct4.Text = ""
        Try
            FrmActEco.lbform.Text = "TerAct4"
            FrmActEco.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtAct1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAct1.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAct2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAct2.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAct3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAct3.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAct4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAct4.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAct1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct1.LostFocus
        If BuscarAct(txtAct1.Text) = False Then
            txtAct1.Text = ""
            'Try
            '    FrmActEco.lbform.Text = "TerAct1"
            '    FrmActEco.ShowDialog()
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Private Sub txtAct2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct2.LostFocus
        If BuscarAct(txtAct2.Text) = False Then
            txtAct2.Text = ""
            'Try
            '    FrmActEco.lbform.Text = "TerAct2"
            '    FrmActEco.ShowDialog()
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Private Sub txtAct3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct3.LostFocus
        If BuscarAct(txtAct3.Text) = False Then
            txtAct3.Text = ""
        End If

        'Try
        '    FrmActEco.lbform.Text = "TerAct3"
        '    FrmActEco.ShowDialog()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub txtAct4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAct4.LostFocus
        If BuscarAct(txtAct4.Text) = False Then
            txtAct4.Text = ""
        End If
    End Sub

    Private Sub txtctab1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctab1.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtctab2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctab2.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
        Else
            e.Handled = True
        End If
    End Sub
End Class
