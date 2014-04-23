Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

Public Class FrmInmueble

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub desbloquear()

        txtdes.Enabled = True
        txtcod.Enabled = True
        txtnitp.Enabled = True
        txtavalCom.Enabled = True
        txtdire.Enabled = True
        txtPvivi.Enabled = True
        txtAvaCata.Enabled = True
        txtBarrio.Enabled = True
        txtllaves.Enabled = True
        txtPvivi.Enabled = True
        txtPLocal.Enabled = True
        txtNcatas.Enabled = True
        txtAvaCata.Enabled = True
        txtnotaria.Enabled = True
        txtNEsc.Enabled = True
        txtfE.Enabled = True
        txtMatrInm.Enabled = True
        txtInsc.Enabled = True

        cmbEstrato.Enabled = True
        cmbconserva.Enabled = True
        cmbEst.Enabled = True
        cmbDestino.Enabled = True
        cmbTipo.Enabled = True
        cmbOperacion.Enabled = True
        cmbDpto.Enabled = True
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        cmbTipo.Enabled = True
        cmbCiudad.Enabled = True
        cbestado.Enabled = True

        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        CmdBuscar.Enabled = False
        CmdMostrar.Enabled = False


    End Sub
    Private Sub bloquear()
        lbestado.Text = ""
        txtdes.Enabled = False
        txtcod.Enabled = False
        txtnitp.Enabled = False
        txtavalCom.Enabled = False
        txtdire.Enabled = False
        txtPvivi.Enabled = False
        txtAvaCata.Enabled = False
        txtBarrio.Enabled = False
        txtllaves.Enabled = False
        txtPvivi.Enabled = False
        txtPLocal.Enabled = False
        txtNcatas.Enabled = False
        txtAvaCata.Enabled = False
        txtnotaria.Enabled = False
        txtNEsc.Enabled = False
        txtfE.Enabled = False
        txtMatrInm.Enabled = False
        txtInsc.Enabled = False

        cmbEstrato.Enabled = False
        cmbconserva.Enabled = False
        cmbEst.Enabled = False
        cmbDestino.Enabled = False
        cmbTipo.Enabled = False
        cmbOperacion.Enabled = False
        cmbDpto.Enabled = False
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmbTipo.Enabled = False
        cmbCiudad.Enabled = False
        cbestado.Enabled = False

        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        CmdBuscar.Enabled = True
        CmdMostrar.Enabled = True


    End Sub
    Private Sub limpiar()

        cmbTipo.Text = "APARTAESTUDIO"
        cbestado.Text = "DISPONIBLE"
        'cmbDpto.Items.Clear()
        cmbOperacion.Text = "ARRIENDO"
        cmbEstrato.Text = "00"
        cmbconserva.Text = "BUENO"
        cmbEst.Text = "NUEVO"
        cmbDestino.Text = "COMERCIAL"


        txtcod.Text = ""
        txtnitp.Text = ""
        txtnomp.Text = ""
        txtavalCom.Text = Moneda(0)
        txtdire.Text = ""
        txtPvivi.Text = Moneda(0)
        txtdes.Text = ""
        txtAvaCata.Text = Moneda(0)
        txtBarrio.Text = ""
        txtllaves.Text = Moneda(0)
        txtPLocal.Text = Moneda(0)
        txtNcatas.Text = ""
        txtAvaCata.Text = Moneda(0)
        txtnotaria.Text = ""
        txtNEsc.Text = ""
        txtfE.Text = ""
        txtMatrInm.Text = ""
        txtInsc.Text = ""

    End Sub
    Public cons As String = ""
    Private Sub FrmInmueble_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cons = "" Then
            cmdcancelar_Click(AcceptButton, AcceptButton)
        End If



        Dim tabla As New DataTable
        tabla.Clear()
        myCommand.CommandText = "SELECT descripcion, codigo  FROM sae.dptos ORDER BY descripcion ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        If tabla.Rows.Count > 0 Then
            For i = 0 To tabla.Rows.Count - 1
                cmbDpto2.Items.Add(UCase(tabla.Rows(i).Item("codigo")))
                cmbDpto.Items.Add(UCase(tabla.Rows(i).Item("descripcion")))
            Next
        End If

        MiConexion(bda)
        Dim tablas As New DataTable
        tablas.Clear()
        myCommand.CommandText = "SELECT * FROM inm_tipo ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablas)
        Refresh()
        If tablas.Rows.Count = 0 Then
            cmbTipo.Items.Clear()
            MsgBox("No ha creado ningun tipo de Inmueble", MsgBoxStyle.Information, "Verificación")
            Me.Close()
        Else
            cmbTipo.Items.Clear()
            For i = 0 To tablas.Rows.Count - 1
                cmbTipo.Items.Add(tablas.Rows(i).Item("tipo"))
            Next
            cmbTipo.Text = cmbTipo.Items(0).ToString
        End If
        Cerrar()
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click

        If txtcod.Text <> "" Then
            lbestado.Text = "EDITAR"
            desbloquear()
            txtcod.ReadOnly = False
        End If

    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        limpiar()
        bloquear()
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        desbloquear()
        lbestado.Text = "NUEVO"
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT dpto, mun FROM sae.companias;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                cmbDpto2.Text = tabla.Rows(0).Item(0)
                cmbCiudad2.Text = tabla.Rows(0).Item(1)
            End If
        Catch ex As Exception
            cmbDpto2.Text = "20"
            cmbCiudad2.Text = "20001"
        End Try
        txtcod.Focus()
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click

        If cbestado.Text = "Seleccione..." Then
            MsgBox("Debe seleccionar un estado valido", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        If txtcod.Text = "" Then
            MsgBox("El codigo del inmueble no puede estar en blanco", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        If txtnitp.Text = "" Then
            MsgBox("Seleccione el Propietario del inmueble", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        If txtavalCom.Text = "" Then
            MsgBox("Digite el avaluo del inmueble", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        Dim tb As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM inmuebles WHERE codigo ='" & txtcod.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        Try
            If tb.Rows.Count > 0 Then
                modificar()
            Else
                guardar()
            End If
        Catch ex As Exception
            MsgBox("Error al Guardar el inmueble, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
        


    End Sub
    Private Sub modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del inmueble se van a modificar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()

            myCommand.Parameters.AddWithValue("?cod", txtcod.Text)
            myCommand.Parameters.AddWithValue("?nitp", txtnitp.Text)
            myCommand.Parameters.AddWithValue("?avaluo", DIN(txtavalCom.Text))
            myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
            myCommand.Parameters.AddWithValue("?direccion", txtdire.Text)
            myCommand.Parameters.AddWithValue("?ciudad", cmbCiudad2.Text)
            myCommand.Parameters.AddWithValue("?vcanon", DIN(txtAvaCata.Text))
            myCommand.Parameters.AddWithValue("?des", txtdes.Text)
            myCommand.Parameters.AddWithValue("?tipoinm", cmbTipo.Text)
            myCommand.Parameters.AddWithValue("?operacion", cmbOperacion.Text)
            myCommand.Parameters.AddWithValue("?dpto", cmbDpto2.Text)
            myCommand.Parameters.AddWithValue("?barrio", txtBarrio.Text)
            myCommand.Parameters.AddWithValue("?estrato", cmbEstrato.Text)
            myCommand.Parameters.AddWithValue("?conser", cmbconserva.Text)
            myCommand.Parameters.AddWithValue("?tipoestado", cmbEst.Text)
            myCommand.Parameters.AddWithValue("?destino", cmbDestino.Text)
            myCommand.Parameters.AddWithValue("?llaves", DIN(txtllaves.Text))
            myCommand.Parameters.AddWithValue("?pvivi", DIN(txtPvivi.Text))
            myCommand.Parameters.AddWithValue("?plocal", DIN(txtPLocal.Text))
            myCommand.Parameters.AddWithValue("?ncatas", txtNcatas.Text)
            myCommand.Parameters.AddWithValue("?avcatas", DIN(txtAvaCata.Text))
            myCommand.Parameters.AddWithValue("?notaria", txtnotaria.Text)
            myCommand.Parameters.AddWithValue("?nEsc", txtNEsc.Text)
            myCommand.Parameters.AddWithValue("?fEsc", txtfE.Text)
            myCommand.Parameters.AddWithValue("?matricula", txtMatrInm.Text)
            myCommand.Parameters.AddWithValue("?inscripcion", txtInsc.Text)

            ' myCommand.CommandText = "UPDATE  inmuebles SET  nitp=?nitp, estado=?estado, avaluo=?avaluo,direccion=?direccion, ciudad=?ciudad,vcanon=?canon,descrip=?des WHERE codigo='" & txtcod.Text & "';"

            myCommand.CommandText = " UPDATE inmuebles SET codigo=?cod,nitp=?nitp,avaluo=?avaluo,estado=?estado,direccion=?direccion,ciudad=?ciudad,vcanon=?vcanon,descrip=?des, " _
            & " tipoim=?tipoinm,operacion=?operacion,dpto=?dpto,barrio=?barrio,estrato=?estrato,conserv=?conser,tipoestado=?tipoestado,destino=?destino,llaves=?llaves, " _
            & " previvi=?pvivi,prelocal=?plocal,ncatast=?ncatas,avcatast=?avcatas,notaria=?notaria,n_escritura=?nEsc,f_escritura=?fEsc,matricula=?matricula,inscripcion=?inscripcion WHERE codigo='" & txtcod.Text & "' "
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            bloquear()
            'cmdcancelar_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub guardar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del inmueble se van a guardar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cod", txtcod.Text)
            myCommand.Parameters.AddWithValue("?nitp", txtnitp.Text)
            myCommand.Parameters.AddWithValue("?avaluo", DIN(txtavalCom.Text))
            myCommand.Parameters.AddWithValue("?estado", cbestado.Text.ToString)
            myCommand.Parameters.AddWithValue("?direccion", txtdire.Text)
            myCommand.Parameters.AddWithValue("?ciudad", cmbCiudad2.Text)
            myCommand.Parameters.AddWithValue("?vcanon", DIN(txtAvaCata.Text))
            myCommand.Parameters.AddWithValue("?des", txtdes.Text)
            myCommand.Parameters.AddWithValue("?tipoinm", cmbTipo.Text)
            myCommand.Parameters.AddWithValue("?operacion", cmbOperacion.Text)
            myCommand.Parameters.AddWithValue("?dpto", cmbDpto2.Text)
            myCommand.Parameters.AddWithValue("?barrio", txtBarrio.Text)
            myCommand.Parameters.AddWithValue("?estrato", cmbEstrato.Text)
            myCommand.Parameters.AddWithValue("?conser", cmbconserva.Text)
            myCommand.Parameters.AddWithValue("?tipoestado", cmbEst.Text)
            myCommand.Parameters.AddWithValue("?destino", cmbDestino.Text)
            myCommand.Parameters.AddWithValue("?llaves", DIN(txtllaves.Text))
            myCommand.Parameters.AddWithValue("?pvivi", DIN(txtPvivi.Text))
            myCommand.Parameters.AddWithValue("?plocal", DIN(txtPLocal.Text))
            myCommand.Parameters.AddWithValue("?ncatas", txtNcatas.Text)
            myCommand.Parameters.AddWithValue("?avcatas", DIN(txtAvaCata.Text))
            myCommand.Parameters.AddWithValue("?notaria", txtnotaria.Text)
            myCommand.Parameters.AddWithValue("?nEsc", txtNEsc.Text)
            myCommand.Parameters.AddWithValue("?fEsc", txtfE.Text)
            myCommand.Parameters.AddWithValue("?matricula", txtMatrInm.Text)
            myCommand.Parameters.AddWithValue("?inscripcion", txtInsc.Text)

            myCommand.CommandText = "Insert INTO inmuebles Values (?cod,?nitp,?avaluo,?estado,?direccion,?ciudad,?vcanon,?des, " _
            & " ?tipoinm,?operacion,?dpto,?barrio,?estrato,?conser,?tipoestado,?destino,?llaves,?pvivi,?plocal,?ncatas,?avcatas," _
            & " ?notaria,?nEsc,?fEsc,?matricula,?inscripcion);"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            bloquear()
            'cmdcancelar_Click(AcceptButton, AcceptButton)
        End If
    End Sub

    Private Sub txtnitp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitp.KeyPress
        ValidarNIT(txtnitp, e)
    End Sub

    Private Sub txtnitp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitp.LostFocus
        If txtnomp.Text = "" Then
            Try
                txtnitp.Text = ""
                FrmSelDueño.Text = "Seleccionar Propietario de Inmueble"
                FrmSelDueño.lbform.Text = "Inmueble"
                FrmSelDueño.txtclase.Text = "PROPIETARIO"
                FrmSelDueño.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtnitp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitp.TextChanged
        Dim items As Integer
        Dim tb As New DataTable
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT i.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm i , terceros t WHERE i.nit ='" & txtnitp.Text & "' and t.nit=i.nit and i.clase= 'PROPIETARIO';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtnomp.Text = tabla.Rows(0).Item("nom")
            ' lbestado.Text = "CONSULTA"
        Else
            txtnomp.Text = ""

        End If
    End Sub

    Private Sub CmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBuscar.Click
        'Dim x As String
        'x = Trim(InputBox("Digite el Codigo del Inmueble", "Buscar"))
        'Buscar(x)
        If txtcod.Text = "" Then
            MsgBox("Verifique El Codigo del Inmueble", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        If cbestado.Text = "OCUPADO" Then
            MsgBox("El Inmueble no puede ser Eliminado porque su fase es OCUPADO", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        Dim resultado1 As MsgBoxResult
        resultado1 = MsgBox("El inmueble codigo " & txtcod.Text & " se van a Eliminar, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado1 = MsgBoxResult.Yes Then
            EliminarInm()
        End If

    End Sub
    Private Sub EliminarInm()
        Try
            MiConexion(bda)

            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM inmuebles WHERE codigo ='" & Trim(txtcod.Text) & "'"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente, El Inmueble ha sido Eliminado", MsgBoxStyle.Information, "Eliminar")
            Refresh()
            Cerrar()
            limpiar()
        Catch ex As Exception
            Cerrar()
        End Try
       
    End Sub
    Public Sub Buscar(ByVal x As String)
        Dim items As Integer
        Dim tabla As New DataTable
        If x = "" Then Exit Sub
        myCommand.CommandText = "SELECT * from inmuebles where codigo='" & x & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("El inmueble No Se Encuentra En Los Registros, Verifique", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        txtnitp.Text = tabla.Rows(0).Item("nitp")
        txtnitp_TextChanged(AcceptButton, AcceptButton)
        cbestado.Text = tabla.Rows(0).Item("estado")
        txtavalCom.Text = Moneda(tabla.Rows(0).Item("avaluo"))
        txtaval_LostFocus(AcceptButton, AcceptButton)
        txtcod.Text = tabla.Rows(0).Item("codigo")

        txtdire.Text = tabla.Rows(0).Item("direccion")
        txtPvivi.Text = Moneda(tabla.Rows(0).Item("vcanon"))
        txtdes.Text = tabla.Rows(0).Item("descrip")
        '...
        cmbTipo.Text = tabla.Rows(0).Item("tipoim")
        cmbOperacion.Text = tabla.Rows(0).Item("operacion")
        cmbDpto2.Text = tabla.Rows(0).Item("dpto")
        cmbCiudad2.Text = tabla.Rows(0).Item("ciudad")
        txtBarrio.Text = tabla.Rows(0).Item("barrio")
        cmbEstrato.Text = tabla.Rows(0).Item("estrato")
        cmbconserva.Text = tabla.Rows(0).Item("conserv")
        cmbEst.Text = tabla.Rows(0).Item("tipoestado")
        cmbDestino.Text = tabla.Rows(0).Item("destino")
        txtllaves.Text = tabla.Rows(0).Item("llaves")
        txtPvivi.Text = Moneda(tabla.Rows(0).Item("previvi"))
        txtPLocal.Text = Moneda(tabla.Rows(0).Item("prelocal"))
        txtNcatas.Text = tabla.Rows(0).Item("ncatast")
        txtAvaCata.Text = Moneda(tabla.Rows(0).Item("avcatast"))
        txtnotaria.Text = tabla.Rows(0).Item("notaria")
        txtNEsc.Text = tabla.Rows(0).Item("n_escritura")
        txtfE.Text = tabla.Rows(0).Item("f_escritura")
        txtMatrInm.Text = tabla.Rows(0).Item("matricula")
        txtInsc.Text = tabla.Rows(0).Item("inscripcion")

        bloquear()
        lbestado.Text = "CONSULTA"
        ' sw = 1
    End Sub

    Private Sub txtcod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod.LostFocus

        Dim tb As New DataTable
        myCommand.CommandText = "SELECT codigo FROM inmuebles where codigo='" & txtcod.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()

        If tb.Rows.Count > 0 Then
            For i = 0 To tb.Rows.Count - 1
                If lbestado.Text = "NUEVO" Then
                    If tb.Rows(i).Item(0) = txtcod.Text Then
                        MsgBox("El inmueble ya se encuentra registrado", MsgBoxStyle.Information)
                        Buscar(txtcod.Text)
                        txtavalCom.Focus()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub txtaval_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtavalCom.LostFocus
        If txtavalCom.Text <> "" Then
            txtavalCom.Text = Moneda(txtavalCom.Text)
        End If
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelInmueble.lbform.Text = "Inmueble"
        FrmSelInmueble.ShowDialog()
        If txtcod.Text <> "" Then
            Buscar(txtcod.Text)
        End If
    End Sub

    Private Sub txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcod.TextChanged

    End Sub

    Private Sub cbestado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbestado.SelectedIndexChanged

    End Sub

    Private Sub txtaval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtavalCom.TextChanged

    End Sub

    Private Sub txtcanon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPvivi.LostFocus
        If txtPvivi.Text <> "" Then
            txtPvivi.Text = Moneda(txtPvivi.Text)
        Else
            txtPvivi.Text = Moneda(0)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles servicios.Click
        If txtcod.Text <> "" Then
            FrmInmServicios.txtcod.Text = txtcod.Text
            FrmInmServicios.ShowDialog()
        Else
            MsgBox("Es necesario registrar el inmueble primero", MsgBoxStyle.Information, "Verificacion")
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dependencia.Click
        If txtcod.Text <> "" Then
            FrmInmDependencias.txtcod.Text = txtcod.Text
            FrmInmDependencias.ShowDialog()
        Else
            MsgBox("Es necesario registrar el inmueble primero", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub

    Private Sub cmbDpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDpto.SelectedIndexChanged
        cmbDpto2.SelectedIndex = cmbDpto.SelectedIndex
        BuscarMunicipio(cmbDpto2.Text)
        Try
            cmbCiudad.SelectedIndex = 0
        Catch ex As Exception
        End Try
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
        cmbCiudad.Items.Clear()
        cmbCiudad.Text = ""
        cmbCiudad2.Items.Clear()
        cmbCiudad2.Text = ""
        For i = 0 To tabla.Rows.Count - 1
            cmbCiudad.Items.Add(tabla.Rows(i).Item("descripcion"))
            cmbCiudad2.Items.Add(tabla.Rows(i).Item("codmun"))
        Next
    End Sub

    Private Sub cmbCiudad2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCiudad2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.mun WHERE codmun='" & cmbCiudad2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then

        Else
            cmbCiudad.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub

    Private Sub cmbDpto2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDpto2.SelectedIndexChanged
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * from sae.dptos WHERE codigo='" & cmbDpto2.Text & "' ORDER BY descripcion;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items <= 0 Then
        Else
            cmbDpto.Text = tabla.Rows(0).Item("descripcion")
        End If
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCiudad.SelectedIndexChanged
        cmbCiudad2.SelectedIndex = cmbCiudad.SelectedIndex
    End Sub

    Private Sub lbestado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbestado.TextChanged

        If lbestado.Text = "CONSULTA" And txtcod.Text <> "" Then
            servicios.Enabled = True
            dependencia.Enabled = True
            llaves.Enabled = True
            cmdGaleria.Enabled = True
        Else
            servicios.Enabled = False
            dependencia.Enabled = False
            llaves.Enabled = False
            cmdGaleria.Enabled = False
        End If
    End Sub

    Private Sub llaves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llaves.Click
        If txtcod.Text <> "" Then
            FrmInmLlaves.txtcod.Text = txtcod.Text
            FrmInmLlaves.txtllaves.Text = txtllaves.Text
            FrmInmLlaves.ShowDialog()
        Else
            MsgBox("Es necesario registrar el inmueble primero", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub

    Private Sub cmdGaleria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGaleria.Click
        If txtcod.Text <> "" Then
            FrmGaleriaInm.txtcodinm.Enabled = False
            FrmGaleriaInm.txtcodinm.Text = txtcod.Text
            FrmGaleriaInm.ShowDialog()
            FrmGaleriaInm.txtcodinm.Enabled = True
        Else
            MsgBox("Es necesario registrar el inmueble primero", MsgBoxStyle.Information, "Verificacion")
        End If
    End Sub

    Private Sub txtPLocal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPLocal.LostFocus
        If txtPLocal.Text <> "" Then
            txtPLocal.Text = Moneda(txtPLocal.Text)
        Else
            txtPLocal.Text = Moneda(0)
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If txtcod.Text <> "" Then
            MostrarInmuebles(txtcod.Text)
        Else
            MsgBox("Verifique el codigo del inmueble", MsgBoxStyle.Information, "Verificación")
        End If
    End Sub
    Public Sub MostrarInmuebles(ByVal cod As String)
        Try


            MiConexion(bda)
            Cerrar()

            Dim nom As String = ""
            Dim nit As String = ""
            Dim tel As String = ""
            Dim dir As String = ""
            Dim email As String = ""
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")
            dir = tabla2.Rows(0).Item("direccion")
            tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
            email = tabla2.Rows(0).Item("emailconta")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = "SELECT i.codigo, i.tipoim, i.estado, i.operacion," _
            & " i.`direccion`, i.`barrio`, i.`estrato`, i.`conserv`, " _
            & "TRIM(CONCAT(i.direccion,' ',i.`barrio`)) AS direccion, " _
            & "CONCAT((SELECT m.descripcion FROM sae.mun m WHERE m.codmun = i.ciudad AND m.coddep = i.`dpto`),' ',(SELECT d.descripcion FROM sae.dptos d WHERE d.`codigo`= i.`dpto` ))AS barrio, " _
            & "i.`conserv`, i.tipoestado, i.destino, i.llaves, i.`previvi`, i.`prelocal`, i.`ncatast`, i.`avcatast`, i.`avaluo`, i.nitp, TRIM(CONCAT(t.`nombre`,' ',t.`apellidos`)) AS f_escritura, " _
            & "IF(n_escritura<>'',CONCAT(n_escritura,' FECHA: ',f_escritura),'') AS n_escritura, i.notaria, i.matricula, i.inscripcion, i.descrip " _
            & "FROM inmuebles i, terceros t WHERE i.nitp= t.nit and codigo ='" & cod & "' "

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "inmuebles")


            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * FROM inm_dpden  WHERE codigo_inm ='" & cod & "' Order by codigo_inm"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "inm_dpden")


            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * FROM inm_llaves WHERE codigo_inm ='" & cod & "'Order by codigo_inm"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "inm_llaves")

            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * FROM inm_servicios WHERE codigo_inm ='" & cod & "' Order by codigo_inm"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "inm_servicios")

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportInmueble.rpt")
            CrReport.SetDataSource(tabla)
            FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields
                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)
                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)

                FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmVisorInformes.ShowDialog()

            Catch ex As Exception
            End Try
            conexion.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtAvaCata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAvaCata.LostFocus
        txtAvaCata.Text = Moneda(txtAvaCata.Text)
    End Sub
End Class