Public Class frmfacturacion
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub
    ''/////////////// inicio nota y obs /////////
    Private Sub cmdfactrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactrap.Click
        CargarComboTipoDoc("fr")
        Frmfacturarapida.ShowDialog()
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        myCommand.Parameters.Clear()
        Dim tablanew As New DataTable
        myCommand.CommandText = "SELECT  count(*) from obs;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablanew)
        Refresh()
        txtcodobs.Text = tablanew.Rows(0).Item(0) + 1
        lbnroobs.Text = tablanew.Rows(0).Item(0) + 1
        lbestobs.Text = "NUEVO"
        txtdesobs.Text = ""
        txtdesobs.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        If txtcodobs.Text <> "" And txtdesobs.Text <> "" Then
            If lbestobs.Text = "NUEVO" Then
                guardarObs()
            ElseIf lbestobs.Text = "EDITAR" Then
                ModificarObs()
            Else
                MsgBox("El estado " & lbestobs.Text & " no permite esta acción, Verifique", MsgBoxStyle.Information, "Verificando")
            End If
        Else
            MsgBox("Faltan datos por almacenar, Verifique", MsgBoxStyle.Information, "Guardar Datos")
        End If
    End Sub
    Public Sub guardarObs()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codigo", txtcodobs.Text.ToString)
        myCommand.Parameters.AddWithValue("?des", txtdesobs.Text.ToString)
        myCommand.CommandText = "INSERT INTO obs (obsdes) " _
                                 & " Values(?des)"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        lbestobs.Text = "GUARDADO"
    End Sub
    Public Sub ModificarObs()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos de la obserbación se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codigo", txtcodobs.Text.ToString)
            myCommand.Parameters.AddWithValue("?des", txtdesobs.Text.ToString)
            myCommand.CommandText = "Update obs set obsdes=?des WHERE obsid=?codigo"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            DBCon.Close()
            lbestobs.Text = "EDITADO"
        End If
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM obs LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtcodobs.Text = 1
        txtdesobs.Text = tabla.Rows(0).Item(1)
        lbnroobs.Text = 1
        lbestobs.Text = "CONSULTA"
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Dim i As Integer
        i = Val(lbnroobs.Text) - 1
        If i > 0 Then
            i = i - 1
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM obs LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcodobs.Text = tabla.Rows(0).Item(0)
            txtdesobs.Text = tabla.Rows(0).Item(1)
            lbnroobs.Text = i + 1
            lbestobs.Text = "CONSULTA"
        End If
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Dim i, ult As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM obs"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        ult = tabla2.Rows(0).Item(0) - 1
        i = Val(lbnroobs.Text) - 1
        If i < ult Then
            i = i + 1
            myCommand.CommandText = "SELECT * FROM obs LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcodobs.Text = tabla.Rows(0).Item(0)
            txtdesobs.Text = tabla.Rows(0).Item(1)
            lbnroobs.Text = i + 1
            lbestobs.Text = "CONSULTA"
        End If
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Dim i As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM obs"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        i = tabla2.Rows(0).Item(0) - 1
        myCommand.CommandText = "SELECT * FROM obs LIMIT " & i & ", 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtcodobs.Text = tabla.Rows(0).Item(0)
        txtdesobs.Text = tabla.Rows(0).Item(1)
        lbnroobs.Text = i + 1
        lbestobs.Text = "CONSULTA"
    End Sub
    Private Sub tabbacobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabbacobs.Click
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If txtcodobs.Text = "" Then Exit Sub
        lbestobs.Text = "EDITAR"
        txtdesobs.Focus()
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If txtcodobs.Text = "" Then Exit Sub
        lbestobs.Text = "ELIMINAR"
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos de la obserbación se van ha eliminar, ¿Desea Eliminarlos?.  ", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.CommandText = "delete from obs where obsid=" & txtcodobs.Text & ";"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
            DBCon.Close()
            MsgBox("La observación fue eliminada de los registros.  ", MsgBoxStyle.Information, "Eliminación")
            CmdCancelar_Click(AcceptButton, AcceptButton)
        End If
        lbestobs.Text = "CONSULTA"
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Dim x As String
        Dim items As Integer
        Dim tabla As New DataTable
        x = Trim(InputBox("Digite el codigo de la observación:   ", "Buscar Datos"))
        If x = "" Then Exit Sub
        If Val(x) = 0 Then
            MsgBox("Dato Invalido, Verifique.    ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * from obs where obsid='" & x.ToString & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("El codigo de la observación No Se Encuentra En Los Registros, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        txtcodobs.Text = tabla.Rows(0).Item(0)
        txtdesobs.Text = tabla.Rows(0).Item(1)
        lbnroobs.Text = tabla.Rows(0).Item(0)
        lbestobs.Text = "CONSULTA"
    End Sub
    ''/////////////// fin nota y obs /////////
    Private Sub frmfacturacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FrmPrincipal.Focus()
    End Sub

    Private Sub cmdperio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperio.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
    End Sub

    Private Sub cmdfacpargral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfacpargral.Click
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM parafacgral LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            FrmParametrosFact.lb.Text = "NUEVO"
            FrmParametrosFact.ShowDialog()
            Exit Sub
        End If
        CargarListasDePrecios()
        FrmParametrosFact.lb.Text = ""
        FrmParametrosFact.txttipo1.Text = tabla.Rows(0).Item(0)
        FrmParametrosFact.txttipo2.Text = tabla.Rows(0).Item(1)
        FrmParametrosFact.txttipo3.Text = tabla.Rows(0).Item(2)
        FrmParametrosFact.txttipo4.Text = tabla.Rows(0).Item(3)
        FrmParametrosFact.txtajust.Text = tabla.Rows(0).Item(4)
        If tabla.Rows(0).Item(5) = "1" Then
            FrmParametrosFact.rbf1.Checked = True
        ElseIf tabla.Rows(0).Item(5) = "2" Then
            FrmParametrosFact.rbf2.Checked = True
        Else
            FrmParametrosFact.rbf3.Checked = True
        End If
        If tabla.Rows(0).Item(6) = "SI" Then
            FrmParametrosFact.rbiva1.Checked = True
        ElseIf tabla.Rows(0).Item(6) = "NO" Then
            FrmParametrosFact.rbiva2.Checked = True
        End If
        If tabla.Rows(0).Item(7) = "SI" Then
            FrmParametrosFact.rbcomi1.Checked = True
        ElseIf tabla.Rows(0).Item(7) = "NO" Then
            FrmParametrosFact.rbcomi2.Checked = True
        End If
        If tabla.Rows(0).Item(8) = "SI" Then
            FrmParametrosFact.rbcont1.Checked = True
            FrmParametrosFact.txtcaja.Text = tabla.Rows(0).Item(9)
            FrmParametrosFact.txtbanco.Text = tabla.Rows(0).Item(10)
            FrmParametrosFact.txtctapc.Text = tabla.Rows(0).Item(11)
            FrmParametrosFact.txtinventario.Text = tabla.Rows(0).Item(12)
            FrmParametrosFact.txtventas.Text = tabla.Rows(0).Item(13)
            FrmParametrosFact.txtcosto.Text = tabla.Rows(0).Item(14)
            FrmParametrosFact.txtivapp.Text = tabla.Rows(0).Item(15)
            FrmParametrosFact.txtivad.Text = tabla.Rows(0).Item(16)
            FrmParametrosFact.txtvalorivap.Text = tabla.Rows(0).Item(17)
            FrmParametrosFact.txtvalorivad.Text = tabla.Rows(0).Item(18)
            FrmParametrosFact.txtdescuento.Text = tabla.Rows(0).Item(19)
            FrmParametrosFact.txtretfuente.Text = tabla.Rows(0).Item(20)
            FrmParametrosFact.txtcompa.Text = tabla.Rows(0).Item("compartido")
            FrmParametrosFact.txtcuota.Text = tabla.Rows(0).Item("cuota")
            FrmParametrosFact.txtabono.Text = tabla.Rows(0).Item("abonos")
        ElseIf tabla.Rows(0).Item(8) = "NO" Then
            FrmParametrosFact.rbcont2.Checked = True
        End If
        FrmParametrosFact.ShowDialog()
    End Sub
    Public Sub CargarListasDePrecios()
        'Dim items As Integer
        'Dim tabla As New DataTable
        'myCommand.CommandText = " SELECT * FROM `listasprec` ORDER BY numlist;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla)
        'Refresh()
        'items = tabla.Rows.Count
        'If items = 0 Then
        '    FrmParametrosFact.gitems.RowCount = 1
        '    FrmParametrosFact.gitems.Item(0, 0).Value = "1"
        '    FrmParametrosFact.gitems.Item(1, 0).Value = ""
        'Else
        '    FrmParametrosFact.gitems.RowCount = items
        '    For i = 0 To items - 1
        '        FrmParametrosFact.gitems.Item(0, i).Value = tabla.Rows(i).Item(0)
        '        FrmParametrosFact.gitems.Item(1, i).Value = tabla.Rows(i).Item(1)
        '    Next
        'End If
    End Sub
    Private Sub cmdparfacrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparfacrap.Click
        CargarComboTipoDoc("pf")
        BuscarParametrosDeFacturas("RAPIDA")
        FrmParaFactRapida.lbfact.Text = "RAPIDA"
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = False
        FrmParaFactRapida.Tab3.Visible = False
        FrmParaFactRapida.Tab4.Visible = False
        FrmParaFactRapida.cmdatras.Enabled = False
        FrmParaFactRapida.cmdsgt.Enabled = True
        FrmParaFactRapida.cmdatras.Text = ""
        FrmParaFactRapida.cmdsgt.Text = "&S"
        FrmParaFactRapida.ShowDialog()
    End Sub
    Private Sub cmdfactnormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfactnormal.Click
        CargarComboTipoDoc("pf")
        BuscarParametrosDeFacturas("NORMAL")
        FrmParaFactRapida.lbfact.Text = "NORMAL"
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = False
        FrmParaFactRapida.Tab3.Visible = False
        FrmParaFactRapida.Tab4.Visible = False
        FrmParaFactRapida.cmdatras.Enabled = False
        FrmParaFactRapida.cmdsgt.Enabled = True
        FrmParaFactRapida.cmdatras.Text = ""
        FrmParaFactRapida.cmdsgt.Text = "&S"
        FrmParaFactRapida.ShowDialog()
    End Sub
    Public Sub CargarComboTipoDoc(ByVal formu As String)
        If formu = "pf" Then
            FrmParaFactRapida.txttipo.Items.Clear()
        ElseIf formu = "fn" Then
            FrmFacturasyAjustes.txttipo.Items.Clear()
        ElseIf formu = "fr" Then
            Frmfacturarapida.txttipo.Items.Clear()
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4 FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        If Trim(tabla.Rows(0).Item(0)) <> "00" Then
            If formu = "pf" Then
                FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(0)))
            ElseIf formu = "fn" Then
                FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item(0)))
            ElseIf formu = "fr" Then
                Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(0)))
            End If
        End If
        If Trim(tabla.Rows(0).Item(1)) <> "00" Then
            If formu = "pf" Then
                FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(1)))
            ElseIf formu = "fn" Then
                FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item(1)))
            ElseIf formu = "fr" Then
                Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(1)))
            End If
        End If
        If Trim(tabla.Rows(0).Item(2)) <> "00" Then
            If formu = "pf" Then
                FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(2)))
            ElseIf formu = "fn" Then
                FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item(2)))
            ElseIf formu = "fr" Then
                Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(2)))
            End If
        End If
        If Trim(tabla.Rows(0).Item(3)) <> "00" Then
            If formu = "pf" Then
                FrmParaFactRapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(3)))
            ElseIf formu = "fn" Then
                FrmFacturasyAjustes.txttipo.Items.Add(Trim(tabla.Rows(0).Item(3)))
            ElseIf formu = "fr" Then
                Frmfacturarapida.txttipo.Items.Add(Trim(tabla.Rows(0).Item(3)))
            End If
        End If
    End Sub
    Public Sub BuscarParametrosDeFacturas(ByVal factura As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacts WHERE factura='" & factura & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmParaFactRapida.lbpara.Text = "Nota: No hay parametros en los registos."
            Exit Sub
        End If
        FrmParaFactRapida.lbpara.Text = ""
        FrmParaFactRapida.Tab1.Visible = True
        FrmParaFactRapida.Tab2.Visible = True
        FrmParaFactRapida.Tab3.Visible = True
        FrmParaFactRapida.Tab4.Visible = True
        '/////// PRIMERA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item(1)) = "S" Then
            FrmParaFactRapida.rbdoc1.Checked = True
            FrmParaFactRapida.txttipo.Text = tabla.Rows(0).Item(2)
        Else
            FrmParaFactRapida.rbdoc2.Checked = True
            FrmParaFactRapida.txttipo.Text = ""
            FrmParaFactRapida.txttipo2.Text = ""
        End If
        If Trim(tabla.Rows(0).Item(3)) = "manual" Then
            FrmParaFactRapida.rbnumf2.Checked = True
        Else
            FrmParaFactRapida.rbnumf.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(4)) = "S" Then
            FrmParaFactRapida.rbinv.Checked = True
        Else
            FrmParaFactRapida.rbinv2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(5)) = "S" Then
            FrmParaFactRapida.rbped.Checked = True
        Else
            FrmParaFactRapida.rbped2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(5)) = "cliente" Then
            FrmParaFactRapida.rbped.Checked = True
        Else
            FrmParaFactRapida.rbped2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(6)) = "automatico" Then 'fecha
            FrmParaFactRapida.rbfec1.Checked = True
        ElseIf Trim(tabla.Rows(0).Item(6)) = "manual" Then
            FrmParaFactRapida.rbfec2.Checked = True
        Else
            FrmParaFactRapida.rbfec3.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(7)) = "S" Then  'cliente
            FrmParaFactRapida.rbclie.Checked = True
            FrmParaFactRapida.txtnitc.Text = tabla.Rows(0).Item(8)
        Else
            FrmParaFactRapida.rbclie2.Checked = True
            FrmParaFactRapida.txtnitc.Text = ""
            FrmParaFactRapida.txtcliente.Text = ""
        End If
        If Trim(tabla.Rows(0).Item(9)) = "S" Then
            FrmParaFactRapida.rbsolnitc.Checked = True
        Else
            FrmParaFactRapida.rbsolnitc2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(10)) = "S" Then 'asignar vendedor
            FrmParaFactRapida.rbasigven.Checked = True
        Else
            FrmParaFactRapida.rbasigven2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(11)) = "S" Then  'vedendor
            FrmParaFactRapida.rbvendedor.Checked = True
            FrmParaFactRapida.txtnitv.Text = tabla.Rows(0).Item(12)
        Else
            FrmParaFactRapida.rbvendedor2.Checked = True
            FrmParaFactRapida.txtnitv.Text = ""
            FrmParaFactRapida.txtvendedor.Text = ""
        End If
        If Trim(tabla.Rows(0).Item(13)) = "S" Then 'solicitar vendedor
            FrmParaFactRapida.rbsolnitv.Checked = True
        Else
            FrmParaFactRapida.rbsolnitv2.Checked = True
        End If
        '/////// SEGUNDA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item(14)) = "S" Then 'solicitar vendedor
            FrmParaFactRapida.rbcodinv.Checked = True
        Else
            FrmParaFactRapida.rbcodinv2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(15)) = "S" Then '
            FrmParaFactRapida.rbsoldescit.Checked = True
        Else
            FrmParaFactRapida.rbsoldescit2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(16)) = "S" Then '
            FrmParaFactRapida.rbsolprecit.Checked = True
        Else
            FrmParaFactRapida.rbsolprecit2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(17)) = "S" Then '
            FrmParaFactRapida.rbviscostart.Checked = True
        Else
            FrmParaFactRapida.rbviscostart2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(18)) = "S" Then '
            FrmParaFactRapida.rbcentro.Checked = True
        Else
            FrmParaFactRapida.rbcentro2.Checked = True
        End If
        ''''''
        If Trim(tabla.Rows(0).Item(19)) = "S" Then 'Facturar diferentes unidades de empaque
            FrmParaFactRapida.rbfacdifuniemp.Checked = True
            If Trim(tabla.Rows(0).Item(20)) = "S" Then
                FrmParaFactRapida.ChPA.Checked = True
            Else
                FrmParaFactRapida.ChPA.Checked = False
            End If
        Else
            FrmParaFactRapida.rbfacdifuniemp2.Checked = True
            FrmParaFactRapida.ChPA.Checked = False
        End If
        ''''''''''''
        If Trim(tabla.Rows(0).Item(21)) = "S" Then 'BODEGA
            FrmParaFactRapida.rbbodpre.Checked = True
            FrmParaFactRapida.cbbod.Text = tabla.Rows(0).Item(22)
        Else
            FrmParaFactRapida.rbbodpre2.Checked = True
            FrmParaFactRapida.cbbod.Text = ""
        End If
        If Trim(tabla.Rows(0).Item(23)) = "S" Then 'MARGEN
            FrmParaFactRapida.rbmarg.Checked = True
            FrmParaFactRapida.txtmargen.Text = tabla.Rows(0).Item(24)
        Else
            FrmParaFactRapida.rbmarg2.Checked = True
            FrmParaFactRapida.txtmargen.Text = ""
        End If
        If Trim(tabla.Rows(0).Item(25)) = "S" Then
            FrmParaFactRapida.rbsolnitvit.Checked = True
        Else
            FrmParaFactRapida.rbsolnitvit2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(26)) = "S" Then 'CONCEPTO COMICIONABLE
            FrmParaFactRapida.rbcc.Checked = True
            FrmParaFactRapida.txtcc.Text = tabla.Rows(0).Item(27)
        Else
            FrmParaFactRapida.rbcc2.Checked = True
            FrmParaFactRapida.txtcc.Text = tabla.Rows(0).Item(27)
        End If
        '/////// TERCERA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item(28)) = "S" Then 'FORMA DE PAGO
            FrmParaFactRapida.rbfp.Checked = True
            If Trim(tabla.Rows(0).Item(29)) = "cheque" Then
                FrmParaFactRapida.rbcualfp1.Checked = True
            ElseIf Trim(tabla.Rows(0).Item(29)) = "tarjeta" Then
                FrmParaFactRapida.rbcualfp2.Checked = True
            ElseIf Trim(tabla.Rows(0).Item(29)) = "efectivo" Then
                FrmParaFactRapida.rbcualfp3.Checked = True
            ElseIf Trim(tabla.Rows(0).Item(29)) = "otra" Then
                FrmParaFactRapida.rbcualfp4.Checked = True
            End If
        Else
            FrmParaFactRapida.rbfp2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(30)) = "S" Then  'PREGUNTAR FORMA DE PAGO
            FrmParaFactRapida.rbpfp.Checked = True
        Else
            FrmParaFactRapida.rbpfp2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(31)) = "S" Then  'SOLICITAR DESC AL FINAL DE FACT
            FrmParaFactRapida.rbsoldescff.Checked = True
        Else
            FrmParaFactRapida.rbsoldescff2.Checked = True
        End If
        FrmParaFactRapida.txtformatfac.Text = tabla.Rows(0).Item(32)
        FrmParaFactRapida.txtformatped.Text = tabla.Rows(0).Item(33)
        FrmParaFactRapida.txtformatcot.Text = tabla.Rows(0).Item(34)
        If Trim(tabla.Rows(0).Item(35)) = "aprobadas" Then  'IMPRIMIR FACTURAS
            FrmParaFactRapida.rbimpfact1.Checked = True
        ElseIf Trim(tabla.Rows(0).Item(35)) = "noaprobadas" Then
            FrmParaFactRapida.rbimpfact2.Checked = True
        Else
            FrmParaFactRapida.rbimpfact3.Checked = True
        End If
        '/////// CUARTA PAGINA ///////////////////////////
        If Trim(tabla.Rows(0).Item(36)) = "solicitar" Then  'Orden de impresión
            FrmParaFactRapida.rbordenimp1.Checked = True
        ElseIf Trim(tabla.Rows(0).Item(36)) = "item" Then
            FrmParaFactRapida.rbordenimp2.Checked = True
        ElseIf Trim(tabla.Rows(0).Item(36)) = "codigo" Then
            FrmParaFactRapida.rbordenimp3.Checked = True
        Else
            FrmParaFactRapida.rbordenimp4.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(37)) = "solicitar" Then  'forma de impresión
            FrmParaFactRapida.rbfi1.Checked = True
        ElseIf Trim(tabla.Rows(0).Item(37)) = "pantalla" Then
            FrmParaFactRapida.rbfi2.Checked = True
        Else
            FrmParaFactRapida.rbfi3.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(38)) = "S" Then  'cajon moedero
            FrmParaFactRapida.rbcajon1.Checked = True
        Else
            FrmParaFactRapida.rbcajon2.Checked = True
        End If
        If Trim(tabla.Rows(0).Item(39)) = "S" Then  'copias
            FrmParaFactRapida.rbcopias1.Checked = True
            FrmParaFactRapida.txtcopias.Text = tabla.Rows(0).Item(40)
        Else
            FrmParaFactRapida.rbcopias2.Checked = True
            FrmParaFactRapida.txtcopias.Text = tabla.Rows(0).Item(40)
        End If
    End Sub
    Private Sub cdmdatvend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmdatvend.Click
        FrmVendedores.ShowDialog()
    End Sub
    Private Sub cmdconcomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmConceptosComicionables.ShowDialog()
    End Sub

    Private Sub cmdentped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmEntraPedidos.ShowDialog()
    End Sub

    Private Sub cmdfacajus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarComboTipoDoc("fn")
        FrmFacturasyAjustes.ShowDialog()
    End Sub

    Private Sub rapido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rapido.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "factura"
        FrmAbrirCompania.ShowDialog()
    End Sub

    Private Sub frmfacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Cerrar()
    End Sub
    '////////// Articulos y Servicios ///////////////////
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click

    End Sub
    Private Sub cmdlistapre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlistapre.Click

    End Sub
    Private Sub cmdser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdser.Click
        FrmArti_Serv.ShowDialog()
    End Sub
    Private Sub cmdlistaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlistaser.Click

    End Sub
End Class