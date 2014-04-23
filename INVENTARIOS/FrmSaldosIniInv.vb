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
Public Class FrmSaldosIniInv

    Private Sub FrmSaldosIniInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT entradas FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try

            If tabla.Rows(0).Item("entradas").ToString = "" Then
                MsgBox("No han asignado ningun tipo de docuementos a las entradas, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Me.Close()
                Exit Sub
            Else
                lbdoc.Text = tabla.Rows(0).Item("entradas").ToString
                tabla.Clear()
                myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    MsgBox("No han creado ninguna Bodega, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    Me.Close()
                    Exit Sub
                End If
                cbdestino.Items.Clear()
                For i = 0 To items - 1
                    cbdestino.Items.Add(tabla.Rows(i).Item("numbod"))
                Next
            End If

        Catch ex As Exception
            MsgBox("No han asignado ningun tipo de documentos a las entradas, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
        End Try
        '****************************************
        'VERIFICAR SI USAN CENTRO DE COSTOS
        Try
            tabla.Clear()
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item("ccosto") = "N" Then
                cbcc.Items.Clear()
                BuscarPeriodo()
                lbestado.Text = "NULO"
                CmdPrimero_Click(AcceptButton, AcceptButton)
                Exit Sub
            End If
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM  centrocostos WHERE nivel='centro';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            cbcc.Items.Clear()
            txtcentro.Items.Clear()
            For i = 0 To tabla.Rows.Count - 1
                cbcc.Items.Add(tabla.Rows(i).Item("centro"))
                txtcentro.Items.Add(tabla.Rows(i).Item("nombre"))
            Next
        Catch ex As Exception
            cbcc.Items.Clear()
        End Try
        '****************************************
        BuscarPeriodo()
        lbestado.Text = "NULO"
        CmdPrimero_Click(AcceptButton, AcceptButton)


    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarNIT(txtnitc, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtcliente.Text = ""
            cargarclientes()
        ElseIf txtnitc.Text = "0" Then
            txtcliente.Text = "   [  SIN NIT  ]"
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
            FrmSelCliente.lbform.Text = "SaldoIniInv"
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
                frmterceros.txtnit.Text = txtnitc.Text
                LimpiarTerceros()
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.lbform.Text = "SaldoIniInv"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtconcepto.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If cbdestino.Text = "" Then
                MsgBox("Favor Seleccione Bodega Destino. ", MsgBoxStyle.Information, "SAE Control")
                cbdestino.Focus()
                Exit Sub
            End If
            FrmItems.txtnumfac.Text = txtnumfac.Text
            Try
                FrmItems.txtfecha.Text = txtdia.Text & txtperiodo.Text
            Catch ex As Exception
                FrmItems.txtfecha.Text = "01" & txtperiodo.Text
            End Try
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = ""
            Try
                FrmItems.gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            FrmItems.gitems.RowCount = gfactura.RowCount + 1
            For i = 0 To gfactura.RowCount - 1
                FrmItems.gitems.Item("num", i).Value = i + 1
                FrmItems.gitems.Item("tipo", i).Value = gfactura.Item(6, i).Value
                FrmItems.gitems.Item("codigo", i).Value = gfactura.Item(1, i).Value
                FrmItems.gitems.Item("descrip", i).Value = gfactura.Item(2, i).Value
                FrmItems.gitems.Item("cant", i).Value = gfactura.Item(3, i).Value
                FrmItems.gitems.Item("precio", i).Value = gfactura.Item(4, i).Value
                FrmItems.gitems.Item("bodega", i).Value = gfactura.Item(7, i).Value
                '/////////////////////////////////////////////////////////////////////////////
                FrmItems.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
                FrmItems.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
                FrmItems.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
                FrmItems.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value
                FrmItems.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
            Next
            '*******************************************************
            FrmItems.gitems.Columns("precio").HeaderText = "COSTO"
            FrmItems.gitems.Columns(1).Visible = False  'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = False  'cc
            FrmItems.gitems.Columns("ctainv").Visible = True   'cc
            FrmItems.gitems.Columns("num").Visible = True   'num
            FrmItems.gitems.Columns("bodega").ReadOnly = True 'bodega
            FrmItems.gitems.Columns("cc").ReadOnly = True 'C COMI
            FrmItems.txttipo.Text = txttipo.Text
            FrmItems.txttipo2.Text = "ENTRADA DE MERCANCIAS"
            FrmItems.txtnumfac.Text = txtnumfac.Text
            FrmItems.lbform.Text = "saldosInic"
            FrmItems.LbTipoMov.Text = "entradas"
            FrmItems.lbbodega.Text = cbdestino.Text.ToString
            FrmItems.ShowDialog()
            FrmItems.gitems.Columns(1).Visible = True   'tipo I/S
            FrmItems.gitems.Columns("cc").Visible = True   'cc
            FrmItems.gitems.Columns("ctainv").Visible = False    'cc
            FrmItems.gitems.Columns("num").Visible = False    'num
            FrmItems.gitems.Columns("bodega").ReadOnly = False 'bodega
            FrmItems.gitems.Columns("cc").ReadOnly = False 'C COMI
            FrmItems.gitems.Columns("precio").HeaderText = "PRECIO"
        End If
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT entradas FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("No ha seleccionado tipo de documento para las entradas.", MsgBoxStyle.Information, "SAE Control")
        Else
            PoneEnCero()
            'Timer1.Enabled = True
            Dim t As New DataTable
            If Today.Day < 10 Then
                txtdia.Text = "0" & Today.Day
            Else
                txtdia.Text = Today.Day
            End If
            txtperiodo.Text = "/" & PerActual
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT iniciofc FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                txtnumfac.Text = NumeroDoc(1)
            End Try
            txtconcepto.Text = "SALDO INICIAL INVENTARIO"
            lbestado.Text = "NUEVO"
            txttipo.Text = tabla.Rows(0).Item(0)
            lbhora.Text = Format(Now, "HH:mm:ss")
            DesBloquear()
        End If


    End Sub
    Public Sub bloquear()

        txtdia.Enabled = False
        txtnitc.Enabled = False
        cbdestino.Enabled = False
        cbaprobado.Enabled = False
        cbcc.Enabled = False
        txtcentro.Enabled = False
        '****** comandos ***************
        cmbContable.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        cmdInf.Enabled = True
        CmdEditar.Enabled = True
        CmdMostrar.Enabled = True
    End Sub
    Public Sub DesBloquear()

        txtdia.Enabled = True
        txtnitc.Enabled = True
        cbdestino.Enabled = True
        cbaprobado.Enabled = True
        cbcc.Enabled = True
        txtcentro.Enabled = True
        cmbContable.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        cmdInf.Enabled = False
        CmdEditar.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Public Sub PoneEnCero()
        BuscarPeriodo()
        cbdestino.Enabled = False
        'cbdestino.Text = ""
        txtnombod.Text = ""
        lbestado.Text = "NULO"
        txttipo.Text = ""
        txtnumfac.Text = ""
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtconcepto.Text = ""
        txttotal.Text = "0,00"
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        lbhora.Text = ""
        cbaprobado.Text = ""
        cbcc.Text = ""
    End Sub
    Private Sub cbdestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdestino.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & cbdestino.Text & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtnombod.Text = tabla.Rows(0).Item("nombod")
        Else
            txtnombod.Text = ""
        End If
    End Sub
    Private Sub primero()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        If lbestado.Text <> "CONSULTA" Then
            primero()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Try
                myCommand.Parameters.Clear()
            Catch ex As Exception
            End Try
            ValidarGuardar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Public Sub ValidarGuardar()
        Try
            Dim fec As Date
            fec = CDate(txtdia.Text & txtperiodo.Text & " " & lbhora.Text)
        Catch ex As Exception
            MsgBox("El dia no coincide con un formato de fecha correcto, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Exit Sub
        End Try
        If txttipo.Text = "" Then
            MsgBox("No ha escogido el tipo de entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            Exit Sub
        ElseIf txtcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtnitc.Focus()
            Exit Sub
        ElseIf txtnombod.Text = "" Then
            MsgBox("No ha seleccionado bodega de entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cbdestino.Focus()
            Exit Sub
        ElseIf gfactura.Item(1, 0).Value = "" Then
            MsgBox("No ha escogido producto(s) para la entrada, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            cmditems.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            GuardarFactura()
        ElseIf lbestado.Text = "EDITAR" Then
            ModificarFactura()
        End If
    End Sub
    '****************************************************
    Public Sub ModificarFactura()
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la entrada se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                '********************************************
                EliminarDetalles(txttipo.Text & txtnumfac.Text)
                '***********************************************************
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
                myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
                myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
                myCommand.Parameters.AddWithValue("?tipo_sal", "ENTRADA DE MERCANCIAS")
                myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
                myCommand.Parameters.AddWithValue("?o_compra", "")
                myCommand.Parameters.AddWithValue("?observ", "")
                myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
                myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
                myCommand.CommandText = "UPDATE movimientos00 SET dia=?dia, hora=?hora, desc_mov=?tipo_sal, nitc=?nitc, " _
                                      & "cc=?cc,concepto=?concepto, o_compra=?o_compra, observ=?observ, total=?total, estado=?estado WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myCommand.ExecuteNonQuery()
                '*********************************************
                Dim t As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                Dim formula As String
                formula = t.Rows(0).Item("formula")
                Dim margen As Integer
                margen = t.Rows(0).Item("porcen")
                '*********************************************
                For i = 0 To gfactura.RowCount - 1
                    If gfactura.Item(1, i).Value <> "" Then
                        GuardarDetalles(i)
                        If cbaprobado.Text = "AP" Then
                            GuardarEnBodega(i)
                            Actualizar_Con_inv(i, formula, margen)
                        End If
                        GuardarPrecios(i, formula, margen)
                    End If
                Next
                'If cbaprobado.Text = "AP" Then GuardarContable()
                bloquear()
                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                cbaprobado.Enabled = False
                cbdestino.Enabled = False
                lbestado.Text = "EDITADO"
                cbaprobado.Enabled = False
                '***********************************************************
                Cerrar()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Cerrar()
        End Try
    End Sub
    Public Sub GuardarFactura()
        Try
            MiConexion(bda)
            Try
                Dim tabla As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT iniciofc FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If Val(tabla.Rows(0).Item(0).ToString) = 0 Then
                    txtnumfac.Text = NumeroDoc(1)
                Else
                    txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                txtnumfac.Text = NumeroDoc(1)
            End Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipo_mov", "E")
            myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
            myCommand.Parameters.AddWithValue("?tipo_sal", "ENTRADA DE MERCANCIAS")
            myCommand.Parameters.AddWithValue("?cc", Val(cbcc.Text.ToString))
            myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", DIN(txttotal.Text))
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text.ToString)
            myCommand.CommandText = "INSERT INTO movimientos00 " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?tipo_sal,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            myCommand.ExecuteNonQuery()
            '*********************************************
            Dim t As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Dim formula As String
            formula = t.Rows(0).Item("formula")
            Dim margen As Double
            margen = t.Rows(0).Item("porcen")
            '*********************************************
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item(1, i).Value <> "" Then
                    GuardarDetalles(i)
                    If cbaprobado.Text = "AP" Then
                        GuardarEnBodega(i)
                        Actualizar_Con_inv(i, formula, margen)
                    End If
                    GuardarPrecios(i, formula, margen)

                End If
            Next
            ActualizarCon()
            'If cbaprobado.Text = "AP" Then GuardarContable()
            bloquear()
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            lbnumero.Text = "0"
            lbestado.Text = "GUARDADO"
            cbaprobado.Enabled = False
        Catch ex As Exception
            Cerrar()
            MsgBox("Error al intentar guardar el registro. Intentelo nuevamente." & ex.ToString, MsgBoxStyle.Information, "SAE Control")
        End Try
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", fila).Value)
            myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("desc", fila).Value)
            myCommand.Parameters.AddWithValue("?bod_ori", "0")
            myCommand.Parameters.AddWithValue("?bod_des", cbdestino.Text)
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            myCommand.Parameters.AddWithValue("?valor", DIN(gfactura.Item("valor", fila).Value))
            '****************************************************************************************
            myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_ing", gfactura.Item("ctaing", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
            Try
                myCommand.Parameters.AddWithValue("?costo", DIN(gfactura.Item("costo", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.CommandText = "INSERT INTO deta_mov00 " _
            & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item(1, fila).Value)
            myCommand.Parameters.AddWithValue("?numbod", cbdestino.Text)
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
            myCommand.CommandText = "UPDATE con_inv SET cant" & cbdestino.Text & "=cant" & cbdestino.Text & " + ?cantidad " _
                                  & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Actualizar_Con_inv(ByVal fila As Integer, ByVal f As String, ByVal margen As Integer)
        Try
            Dim precio, costo, costoprom, suma As Double
            Dim cant As Integer
            '******** iva de l artiuclo***************************************
            Dim tabla, tiva As New DataTable
            Dim iva As Decimal
            myCommand.CommandText = "SELECT iva FROM articulos WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tiva)
            Try
                iva = tiva.Rows(0).Item("iva")
            Catch ex As Exception
                iva = 0
            End Try
            '************************************************
            myCommand.CommandText = "SELECT costprom,margen,precio1 FROM con_inv WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo='00';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            suma = 0
            cant = 1 'al menos el q acaba de entrar
            For i = 0 To tabla.Rows.Count - 1
                Try
                    costoprom = tabla.Rows(i).Item("costprom")
                Catch ex As Exception
                    costoprom = 0
                End Try
                If costoprom > 0 Then
                    suma = suma + costoprom
                    cant = cant + 1 'hubo compra en ese mes ==> entra en promedio
                End If
            Next
            costo = CDbl(gfactura.Item(4, fila).Value) 'costo del articulo
            Try
                margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("margen")) 'margen del periodo actual (el ultimo campo)
            Catch ex As Exception
                margen = 0
            End Try
            suma = suma + costo
            costoprom = suma / cant
            '*********************************
            If f = "/" Then 'precio segun formula
                precio = costo / (1 - margen / 100)
            ElseIf f = "manual" Then
                Try
                    margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("precio1")) 'precio1 del periodo actual porq es manual(el ultimo campo)
                Catch ex As Exception
                    margen = 0
                End Try
            Else
                precio = costo * (1 + margen / 100)
            End If
            ' precio = precio + (precio * iva / 100)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cosuni", costo)
            myCommand.Parameters.AddWithValue("?costprom", costoprom)
            If f = "manual" Then
                myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "' ;"
            Else
                myCommand.Parameters.AddWithValue("?precio", precio)
                myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom,precio1=?precio " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "' ;"
            End If
            myCommand.ExecuteNonQuery()
            Try
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?costprom", costoprom)
                myCommand.CommandText = "UPDATE articulos SET cos_pro=?costprom " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarPrecios(ByVal fila As Integer, ByVal f As String, ByVal margen As Integer)
        Try
            Dim tiva As New DataTable
            myCommand.CommandText = "SELECT margen FROM articulos WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tiva)
            Try
                margen = tiva.Rows(0).Item("margen")
            Catch ex As Exception
                margen = 0
            End Try
            Dim precio, costo As Double
            costo = CDbl(gfactura.Item(4, fila).Value)
            If f = "/" Then
                precio = costo / (1 - margen / 100)
            Else
                precio = costo * (1 + margen / 100)
            End If
            ' MsgBox("entro act precios")
            myCommand.Parameters.Clear()
            If f = "manual" Then
                myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
                myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni " _
                                      & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            Else
                myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
                myCommand.Parameters.AddWithValue("?precio", DIN(precio))
                myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni,precio=?precio " _
                                      & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
            End If
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ActualizarCon()
        Try
            Dim campo As String = "iniciofc"
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & campo & " FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                If Val(txtnumfac.Text) > Val(tabla.Rows(0).Item(0)) Then
                    myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                    myCommand.ExecuteNonQuery()
                End If
            Catch ex As Exception
                myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub EliminarDetalles(ByVal num_per As String)
        EjecutaSQL("DELETE FROM deta_mov00 WHERE doc='" & num_per & "';")
    End Sub
    Public Sub EjecutaSQL(ByVal sql As String)
        Try
            myCommand.CommandText = sql
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmdEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEditar.Click
        BuscarPeriodo()
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If cbaprobado.Text <> "AP" Then
                lbestado.Text = "EDITAR"
                DesBloquear()
            Else
                MsgBox("El registro no se puede editar (REGISTRO APROBADO).   ", MsgBoxStyle.Information, "Verificando")
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmSelMovInventario.lbform.Text = "SaldosIniInv"
        FrmSelMovInventario.lbtipo.Text = lbdoc.Text
        FrmSelMovInventario.lbtitulo.Text = "BUSCAR ENTRADA(" & lbdoc.Text & ") POR NUMERO"
        FrmSelMovInventario.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            BuscarDocumento(txttipo.Text & txtnumfac.Text)
        End If
    End Sub
    Public Sub BuscarDocumento(ByVal num_per As String)
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM movimientos00 WHERE doc='" & num_per & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        '***************************************
        txttipo.Text = tabla.Rows(0).Item("tipodoc")
        txtnumfac.Text = NumeroDoc(Val(tabla.Rows(0).Item("num")))
        txtdia.Text = tabla.Rows(0).Item("dia")
        txtperiodo.Text = "/" & tabla.Rows(0).Item("per")
        lbhora.Text = tabla.Rows(0).Item("hora").ToString
        'cbtipo.Text = tabla.Rows(0).Item("desc_mov")
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        txtnitc_LostFocus(AcceptButton, AcceptButton)
        cbcc.Text = tabla.Rows(0).Item("cc")
        txtconcepto.Text = tabla.Rows(0).Item("concepto")
        'txtcompra.Text = tabla.Rows(0).Item("o_compra")
        'txtobs.Text = tabla.Rows(0).Item("observ")
        txttotal.Text = Moneda(tabla.Rows(0).Item("total"))
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        gfactura.Rows.Clear()
        gfactura.RowCount = 1
        BuscarDetalles(num_per)
        '***************************************
        'Timer1.Enabled = False
        bloquear()
        lbestado.Text = "CONSULTA"
    End Sub
    Public Sub BuscarDetalles(ByVal num_per As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM deta_mov00 WHERE doc = '" & num_per & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Dim suma As Double
            suma = 0
            gfactura.RowCount = tabla.Rows.Count
            cbdestino.Text = tabla.Rows(0).Item("bod_des")
            For i = 0 To tabla.Rows.Count - 1
                gfactura.Item(0, i).Value = tabla.Rows(i).Item("item")
                gfactura.Item(1, i).Value = tabla.Rows(i).Item("codart")
                gfactura.Item(2, i).Value = tabla.Rows(i).Item("nomart")
                gfactura.Item(3, i).Value = Fraccion(tabla.Rows(i).Item("cantidad"))
                gfactura.Item(4, i).Value = Moneda(tabla.Rows(i).Item("valor"))
                gfactura.Item(5, i).Value = Moneda(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor"))
                suma = suma + CDbl(tabla.Rows(i).Item("cantidad") * tabla.Rows(i).Item("valor"))
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_ing")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                gfactura.Item(7, i).Value = cbdestino.Text
            Next
            txttotal.Text = Moneda(suma)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "' LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PoneEnCero()
                Exit Sub
            End If
            BuscarDocumento(tabla.Rows(0).Item("doc"))
            lbnumero.Text = "1"
        Catch ex As Exception
            MsgBox(ex.ToString)
            PoneEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnumero.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT doc FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
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
            myCommand.CommandText = "SELECT count(*) FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
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
            myCommand.CommandText = "SELECT count(*) FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM movimientos00 WHERE tipodoc='" & lbdoc.Text & "' LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub NGenerarPDF()

        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim email As String = ""
        Dim dire As String = ""

        p = "00"


        MiConexion(bda)
        Cerrar()


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT: " & tabla2.Rows(0).Item("nit")
        tel = Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        email = tabla2.Rows(0).Item("emailconta")
        dire = tabla2.Rows(0).Item("direccion")


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql = "SELECT d.item, d.codart, d.nomart,CAST((d.cantidad) AS CHAR(20)) AS doc, d.valor AS costo, d.valor * d.cantidad  as valor, " _
        & " m.nitc as cta_inv, trim(CONCAT(t.nombre,' ', t.apellidos)) as cta_cos, t.dir as cta_ing, trim(CONCAT(t.telefono,' - ',t.celular)) as cta_iva" _
        & " FROM  deta_mov00 d, movimientos00 m LEFT JOIN terceros t ON m.nitc=t.nit " _
        & " WHERE  d.doc=m.doc AND d.doc =  '" & txttipo.Text & txtnumfac.Text & "'  ORDER BY item"


        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "deta_mov01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "Select doc as cc, desc_mov, concepto, o_compra as n_pedido, observ, CAST(concat(dia,'/',per) AS CHAR(20)) as per " _
                                & " from movimientos00 where doc= '" & txttipo.Text & txtnumfac.Text & "' "
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "movimientos01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " select logofac from parafacts where factura ='RAPIDA' "
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parafacts")


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportSalida2.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacRap.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtelef As New ParameterField
            Dim Premail As New ParameterField
            Dim Prtipo As New ParameterField
            Dim Prorden As New ParameterField
            Dim Prbod As New ParameterField

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
            Prtipo.Name = "tipo"
            Prtipo.CurrentValues.AddValue("ENTRADA No")
            Prorden.Name = "orden"
            Prorden.CurrentValues.AddValue("ORDEN DE COMPRA")
            Prbod.Name = "bod"
            Prbod.CurrentValues.AddValue(cbdestino.Text & " " & txtnombod.Text)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtelef)
            prmdatos.Add(Premail)
            prmdatos.Add(Prtipo)
            prmdatos.Add(Prorden)
            prmdatos.Add(Prbod)

            FrmReportFacRap.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRap.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conexion.Close()

    End Sub
    Public Sub GenerarTodos()

        MiConexion(bda)
        Cerrar()

        Dim p As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim dir As String = ""
        Dim email As String = ""
        Dim sql As String = ""
        Dim cad As String = ""
        Dim pord As String = ""
        Dim pdoc As String = ""
        Dim Tdoc As String = ""

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


        'If cbtipo.Text = "Entradas" Then
        '    cad = "  AND bg.numbod = d.bod_des"
        '    pord = "ORDEN DE COMPRA"
        '    pdoc = "ENTRADA N°"
        '    Tdoc = "EN"
        'ElseIf cbtipo.Text = "Salidas" Then
        '    cad = "  AND bg.numbod = d.bod_ori"
        '    pord = "N° DE PEDIDO"
        '    pdoc = "SALIDA N°"
        '    Tdoc = "SA"
        'End If



        'If d2.Checked = True Then
        '    cad = cad & " AND m.num BETWEEN " & Val(txt_doc_ini.Text) & " AND " & Val(txt_doc_fin.Text) & " "
        'End If
        'If f2.Checked = True Then
        '    cad = cad & " AND m.dia BETWEEN " & Val(txt_fec_ini.Text) & " AND " & Val(txt_fec_fin.Text) & " "
        'End If

        'p = Strings.Left(lbperiodo.Text, 2)
        sql = sql & "SELECT d.doc AS doc, d.item AS vmto, d.codart AS cta_total,d.nomart AS observ, d.cantidad AS iva, (d.valor/d.`cantidad`) AS ret_f, d.valor AS total, " _
       & " IF (tipodoc='EN',cast(CONCAT(d.bod_des,' ',bg.nombod) as char(30)),cast(CONCAT(d.bod_ori,' ',bg.nombod) as char(30))) AS ciu_ent, " _
       & " IF (tipodoc='EN',o_compra,n_pedido) AS cta2, m.total as v1, " _
       & " m.nitc AS nitc, CONCAT(t.`nombre`,' ',t.`apellidos`) AS d1, t.`dir` AS dir_ent, t.`telefono` AS cc,  m.observ AS descrip, m.concepto AS entregar,  " _
       & " CONCAT(m.dia,'/',m.per) AS cta1 FROM deta_mov00 d, movimientos00 m, terceros t , bodegas bg " _
       & " WHERE d.doc = m.doc  AND t.`nit`= m.nitc AND bg.numbod = d.bod_des "

        sql = sql & " ORDER BY  doc "
        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "facturas01")


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTodSIinv.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacVarias.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            'Dim Prperiodo As New ParameterField
            'Dim Prtel As New ParameterField
            'Dim PrEmail As New ParameterField
            'Dim Prdir As New ParameterField
            'Dim Prres As New ParameterField
            'Dim Prord As New ParameterField



            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            'Prtel.Name = "telef"
            'Prtel.CurrentValues.AddValue(tel.ToString)
            'Prdir.Name = "dir"
            'Prdir.CurrentValues.AddValue(dir.ToString)
            'PrEmail.Name = "email"
            'PrEmail.CurrentValues.AddValue(email.ToString)
            'Prord.Name = "ord"
            'Prord.CurrentValues.AddValue(pord.ToString)
            'Prres.Name = "tdoc"
            'Prres.CurrentValues.AddValue(pdoc.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            'prmdatos.Add(Prtel)
            'prmdatos.Add(Prdir)
            'prmdatos.Add(PrEmail)
            'prmdatos.Add(Prord)
            'prmdatos.Add(Prres)


            FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacVarias.ShowDialog()

        Catch ex As Exception
        End Try

        conexion.Close()

    End Sub

    Private Sub cmdInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInf.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Else
                If chmostrar.Checked = False Then
                    NGenerarPDF()
                Else
                    GenerarTodos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    Private Sub cbcc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbcc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbcc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcc.SelectedIndexChanged
        Try
            txtcentro.SelectedIndex = cbcc.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcentro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcentro.SelectedIndexChanged
        Try
            cbcc.SelectedIndex = txtcentro.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarContable()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            grilla.RowCount = 1
            grilla.Rows.Clear()
            grilla.RowCount = 30
            If tabla.Rows(0).Item("contable").ToString <> "no" Then 'HAY INTERFAZ CONTABLE
               
                '************************************************

                grilla.Item("Descripcion", 0).Value = "SALDO INICIAL INVENTARIO "
                grilla.Item(1, 0).Value = txttotal.Text
                grilla.Item(2, 0).Value = Moneda(0)
                grilla.Item(3, 0).Value = tabla.Rows(0).Item("cdebito")

                grilla.Item("Descripcion", 1).Value = txtcliente.Text.ToString
                grilla.Item(1, 1).Value = Moneda(0)
                grilla.Item(2, 1).Value = txttotal.Text
                grilla.Item(3, 1).Value = tabla.Rows(0).Item("ccredito")
                '-------------------------------------------

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
                            InsertContabilidad(i)
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.ToString)
                    End Try
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
            myCommand.Parameters.AddWithValue("?centro", Val(cbcc.Text.ToString))
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
            myCommand.Parameters.AddWithValue("?base", "0")
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?modulo", "inventarios")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos00 " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
            ' ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
   
    Private Sub cmbContable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbContable.Click

        MiConexion(bda)

        Dim tp As New DataTable
        myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)

        If tp.Rows.Count > 0 Then
            If tp.Rows(0).Item("cdebito") = "" Then
                MsgBox("No ha definido la cuenta para debitar", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
            If tp.Rows(0).Item("ccredito") = "" Then
                MsgBox("No ha definido la cuenta para acreditar", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If
            If cbaprobado.Text <> "AP" Then
                MsgBox("El documento debe estar aprobado", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            Else

                Dim tc As New DataTable
                tc.Clear()
                myCommand.CommandText = "SELECT * FROM `documentos00` where doc='" & txtnumfac.Text.ToString & "' and tipodoc='EN';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)

                If tc.Rows.Count = 0 Then
                    GuardarContable()
                    MsgBox("El documento contable se realizó con exito", MsgBoxStyle.Information, "SAE")
                Else
                    MsgBox("El documento ya fue contabilizado", MsgBoxStyle.Information, "SAE")
                End If
            End If
        End If
        Cerrar()
    End Sub
End Class