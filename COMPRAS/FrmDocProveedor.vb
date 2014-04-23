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
Public Class FrmDocProveedor
    Dim ct As Integer
    Private Sub FrmDocProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FrmPrincipal.Inventarios.Enabled = False And FrmPrincipal.InventariosToolStripMenuItem.Enabled = False Then
            cmdRemision.Visible = False
        End If
        ''VERIFICAR SI USAN CENTRO DE COSTOS
        'Dim tabla As New DataTable
        'Try
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    If tabla.Rows(0).Item("ccosto") = "N" Then
        '        txtcentrocosto.Items.Clear()
        '        Exit Try
        '    End If
        '    tabla.Clear()
        '    myCommand.CommandText = "SELECT * FROM  centrocostos WHERE nivel='centro';"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    txtcentrocosto.Items.Clear()
        '    For i = 0 To tabla.Rows.Count - 1
        '        txtcentrocosto.Items.Add(tabla.Rows(i).Item("centro"))
        '    Next
        'Catch ex As Exception
        '    txtcentrocosto.Items.Clear()
        'End Try

        Dim tf As New DataTable
        Try
            tf.Clear()
            myCommand.CommandText = "SELECT deci FROM par_comp ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            lb_imp_dec.Text = Trim(tf.Rows(0).Item("deci"))
        Catch ex As Exception
            lb_imp_dec.Text = ""
        End Try

        lbestado.Text = "NULO"
        Parametros()
        bloquear()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Public Sub bloquear()
        txtnumfac.Enabled = False
        txtnitc.Enabled = False
        txtfecha.Enabled = False
        cbaprobado.Enabled = False
        cmditems.Enabled = False
        txtcentrocosto.Enabled = False
        txt_doc_afe.Enabled = False
        grup_tip_doc.Enabled = False
        grupoafecta.Enabled = False
        txtflete.Enabled = False
        txtseguro.Enabled = False
        '******impuestos ************
        valordes.Enabled = False
        valoriva.Enabled = False
        valorret.Enabled = False
        valorretCree.Enabled = False
        txtvmto.Enabled = False
        '****** comandos ***************
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdNuevo.Enabled = True
        cmdNuevoAF.Enabled = True
        cmdRemision.Enabled = True
        CmdEditar.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        cmditems.Enabled = False
        '**** cuentas *************
        txtcuentadesc.Enabled = False
        txtcuentaret.Enabled = False
        txtcuentaiva.Enabled = False
        txtcuentaCree.Enabled = False
        txtcuentaflete.Enabled = False
        txtcuentaseguro.Enabled = False
        txtcuentatotal.Enabled = False
        '............................
        cmbTipoAF.Enabled = False

    End Sub
    Public Sub Desbloquear()
        txtnitc.Enabled = True
        txtfecha.Enabled = True
        cbaprobado.Enabled = True
        cmditems.Enabled = True
        txt_doc_afe.Enabled = True
        grup_tip_doc.Enabled = True
        grupoafecta.Enabled = True
        txtflete.Enabled = True
        txtseguro.Enabled = True
        '******impuestos ************
        valordes.Enabled = True
        valoriva.Enabled = True
        valorret.Enabled = True
        valorretCree.Enabled = True
        txtvmto.Enabled = True
        '****** comandos ***************
        cmditems.Enabled = True
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdNuevo.Enabled = False
        cmdNuevoAF.Enabled = False
        cmdRemision.Enabled = False
        CmdEditar.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        '...
        If txt_doc_afe.Enabled = False Then
            cmbTipoAF.Enabled = True
        Else
            cmbTipoAF.Enabled = False
        End If
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
    Public Sub PonerenCero()
        cmbTipoAF.Text = "Seleccione..."
        Timer1.Enabled = False
        lbhora.Text = "00:00:00"
        lbestado.Text = "NULO"
        cmditems.Enabled = False
        txttipo.Enabled = False
        txttipo2.Text = ""
        txtnumfac.Text = ""
        lbnumero.Text = ""
        txtremision.Text = ""
        lbpedido.Text = ""
        lbusuario.Text = FrmPrincipal.lbuser.Text
        lbanti1.Text = ""
        lbanti2.Text = ""
        lbanti3.Text = ""
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
        txtcentrocosto.Text = ""
        txtcentro.Text = ""
        lbanula.Text = ""
        txtnitc.Text = ""
        txtcliente.Text = ""
        txtsubtotal.Text = "0,00"
        txtdescuento.Text = "0,00"
        lbdescuento.Text = "0,00"
        txtret.Text = "0,00"
        txtiva.Text = "0,00"
        txtflete.Text = "0,00"
        txtseguro.Text = "0,00"
        txtretCre.Text = "0,00"
        txttotal.Text = "0,00"
        valordes.Text = "0,00"
        valoriva.Text = "0,00"
        valorret.Text = "0,00"
        valorretCree.Text = "0,00"
        lbsubtotal.Text = "0,00"
        gfactura.RowCount = 1
        txtcuentadesc.Text = ""
        txtcuentaiva.Text = ""
        txtcuentaret.Text = ""
        txtcuentaflete.Text = ""
        txtcuentaseguro.Text = ""
        txtcuentatotal.Text = ""
        cbaprobado.Text = ""
        lbusuario.Text = ""
        txtvmto.Text = "0"
        txtobserbaciones.Text = ""
        txt_doc_afe.Text = ""
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
        cbbase.Items.Clear()
        cbcuenta.Items.Clear()
        CalcularTotales()
    End Sub
    Public Sub Parametros()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM par_comp LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            Exit Sub
        Else
            If lbestado.Text = "NUEVO" Then
                If Trim(tabla.Rows(0).Item("doc_fp").ToString) <> "" Then
                    txttipo.Text = Trim(tabla.Rows(0).Item("doc_fp").ToString)
                    txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
                End If
                txtcuentadesc.Text = Trim(tabla.Rows(0).Item("cta_desc").ToString)
                txtcuentaret.Text = Trim(tabla.Rows(0).Item("cta_rtf").ToString)
                txtcuentaiva.Text = Trim(tabla.Rows(0).Item("cta_iva_d").ToString)
                txtcuentaflete.Text = Trim(tabla.Rows(0).Item("cta_fle").ToString)
                txtcuentaseguro.Text = Trim(tabla.Rows(0).Item("cta_seg").ToString)
                txtcuentatotal.Text = Trim(tabla.Rows(0).Item("cta_cpp").ToString)
            End If
            lbintcont.Text = Trim(tabla.Rows(0).Item("int_con").ToString)
            If Trim(tabla.Rows(0).Item("int_con").ToString) = "SI" Then
                txtcuentadesc.Enabled = True
                txtcuentaret.Enabled = True
                txtcuentaiva.Enabled = True
                txtcuentaflete.Enabled = True
                txtcuentaseguro.Enabled = True
                txtcuentatotal.Enabled = True
                txtcuentaCree.Enabled = True
            End If
            lbsolnumcom.Text = Trim(tabla.Rows(0).Item("sol_num_com").ToString)
            If Trim(tabla.Rows(0).Item("sol_num_com").ToString) = "SI" Then
                txtnumfac.Enabled = True
            End If
            lbcanfact.Text = Trim(tabla.Rows(0).Item("can_fact").ToString)
            lbaumenta.Text = Trim(tabla.Rows(0).Item("fs_aum_inv").ToString)
            lbimpap.Text = Trim(tabla.Rows(0).Item("imp_ap").ToString)
            lbformat.Text = Trim(tabla.Rows(0).Item("format_fp").ToString)
        End If
        tabla.Clear()
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows(0).Item("ccosto") = "N" Then
            'txtcentrocos.Items.Clear()
            txtcentrocosto.Enabled = False
        Else
            txtcentrocosto.Enabled = True
        End If
    End Sub
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            PonerenCero()
            gfp.Item("detalle", 0).Value = "CREDITO"
            gfp.Item("cual", 0).Value = "Otra"
            txtvmto.Text = "30"
            lbusuario.Text = FrmPrincipal.lbuser.Text
            lbestado.Text = "NUEVO"
            txttipo.Enabled = True
            Parametros()
            Desbloquear()
            txttipo.Focus()
            BuscarPeriodo()
            chcosto.Enabled = True
        End If
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'CalcularTotales()
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
                chcosto.Enabled = True
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
    '////////// ELIMINAR ///////////////////////////////////////////////////
    Public Sub Eliminar()
        Try
            MiConexion(bda)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del documento " & txttipo.Text & txtnumfac.Text & " se van ha eliminar, ¿Desea Borrarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                ''''''''''''''''''SI pago credito'''''''''''''''''''''''''''''''
                If tabla.Rows(0).Item("fpago").ToString = "Otra" Then
                    If eliminarCredito() = False Then
                        MsgBox("El documeto NO puede ser eliminado porque registra abonos. ", MsgBoxStyle.Information, "SAE Control")
                        Cerrar()
                        Exit Sub
                    End If
                End If
                myCommand.CommandText = "DELETE FROM detacomp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  " _
                & "DELETE FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  " _
                & "DELETE FROM otcon_comp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';  "
                myCommand.ExecuteNonQuery()
                MsgBox("El documeto fué eliminado correctamente.  ", MsgBoxStyle.Information, "SAE Control")
            End If
            Cerrar()
            CmdPrimero_Click(AcceptButton, AcceptButton)
        Catch ex As Exception
            Cerrar()
            MsgBox(ex.ToString)
        End Try

    End Sub
    Function eliminarCredito()

        Dim cons As String = ""
        Dim p As String = ""
        For i = 1 To 12
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If i <> 12 Then
                cons = cons & "SELECT * FROM ot_cpp" & p & " WHERE  doc_afec='" & txttipo.Text & txtnumfac.Text & "' UNION "
            Else
                cons = cons & "SELECT * FROM ot_cpp" & p & " WHERE  doc_afec='" & txttipo.Text & txtnumfac.Text & "'  "
            End If
        Next
        Dim tf As New DataTable
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tf)
        Refresh()
        If tf.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelDocProveedor.cmbper.Text = PerActual(0) & PerActual(1)
            FrmSelDocProveedor.ShowDialog()
            Dim num As String = ""
            Try
                num = lbnumero.Text
            Catch ex As Exception
            End Try
            If lbestado.Text = "CONSULTA" Then
                BuscarDoc(txtnumfac.Text)
                lbnumero.Text = num
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    'BURCAR DESPLAZAMIENTO
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        bloquear()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM fact_comp" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count < 1 Then
                PonerenCero()
                Exit Sub
            End If
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnumero.Text = "1"
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            PonerenCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnumero.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT doc FROM fact_comp" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnumero.Text = i + 1
            Else
                CmdPrimero_Click(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM fact_comp" & PerActual(0) & PerActual(1) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnumero.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM fact_comp" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
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
            myCommand.CommandText = "SELECT count(*) FROM fact_comp" & PerActual(0) & PerActual(1) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            If i < 0 Then
                MsgBox("No hay facturas los registros, favor agreugue una.  ", MsgBoxStyle.Information, "Editar Factura ")
                Exit Sub
            End If
            myCommand.CommandText = "SELECT doc FROM fact_comp" & PerActual(0) & PerActual(1) & " ORDER BY tipodoc,num LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnumero.Text = i + 1
        Catch ex As Exception
            MsgBox(ex.ToString)
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDoc(ByVal numero As String)
        Timer1.Enabled = False
        PonerenCero()
        BuscarPeriodo()
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT f. * , d. *  " _
                               & "FROM fact_comp" & PerActual(0) & PerActual(1) & " f " _
                               & "LEFT JOIN (detacomp" & PerActual(0) & PerActual(1) & " d) " _
                               & "ON f.doc = d.doc " _
                               & "WHERE f.doc = '" & numero _
                               & "' ORDER BY d.item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("La factura no se encuentra en los registros o esta en un periodo diferente, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        txttipo.Text = tabla.Rows(0).Item("tipodoc")
        txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)  'para buscar
        txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num"))
        txt_doc_afe.Text = tabla.Rows(0).Item("doc_afec")
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        ' txtnitc_LostFocus(AcceptButton, AcceptButton) 'para buscar cliente
        If Trim(tabla.Rows(0).Item("anulado").ToString) <> "no" Then lbanula.Text = "DOCUMENTO ANULADO"
        lbusuario.Text = tabla.Rows(0).Item("usuario")
        txtfecha.Text = tabla.Rows(0).Item("fecha").ToString
        lbhora.Text = tabla.Rows(0).Item("hora").ToString
        txtsubtotal.Text = Moneda2(tabla.Rows(0).Item("subtotal"), lb_imp_dec.Text)
        'descuento
        valordes.Text = tabla.Rows(0).Item("por_desc")
        txtdescuento.Text = Moneda2(tabla.Rows(0).Item("descuento"), lb_imp_dec.Text)
        txtcuentadesc.Text = tabla.Rows(0).Item("cta_desc")
        'retencion
        valorret.Text = tabla.Rows(0).Item("por_rtf")
        txtret.Text = Moneda2(tabla.Rows(0).Item("rtf"), lb_imp_dec.Text)
        txtcuentaret.Text = tabla.Rows(0).Item("cta_rtf")
        'reteCree
        valorretCree.Text = tabla.Rows(0).Item("por_rtc")
        txtretCre.Text = Moneda2(tabla.Rows(0).Item("rtc"), lb_imp_dec.Text)
        txtcuentaCree.Text = tabla.Rows(0).Item("cta_rtc")
        'iva
        valoriva.Text = tabla.Rows(0).Item("por_iva")
        txtiva.Text = Moneda2(tabla.Rows(0).Item("iva"), lb_imp_dec.Text)
        txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
        'fletes
        txtflete.Text = Moneda2(tabla.Rows(0).Item("fle"), lb_imp_dec.Text)
        txtcuentaflete.Text = tabla.Rows(0).Item("cta_fle")
        'seguro
        txtseguro.Text = Moneda2(tabla.Rows(0).Item("seg"), lb_imp_dec.Text)
        txtcuentaseguro.Text = tabla.Rows(0).Item("cta_seg")
        'total
        txttotal.Text = Moneda2(tabla.Rows(0).Item("total"), lb_imp_dec.Text)
        txtcuentatotal.Text = tabla.Rows(0).Item("cta_total")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        txtobserbaciones.Text = tabla.Rows(0).Item("observ")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        txtvmto.Text = tabla.Rows(0).Item("vmto")
        txtcentrocosto.Text = tabla.Rows(0).Item("ctoc")
        If txtcentrocosto.Text <> "0" Then
            BuscarCCs()
        Else
            txtcentro.Text = ""
        End If
        txt_doc_afe.Text = Trim(tabla.Rows(0).Item("doc_afec"))
        lbestado.Text = "CONSULTA"
        If Trim(tabla.Rows(0).Item("afecta").ToString) = "SI" Then
            rbafecta1.Checked = True
        Else
            rbafecta2.Checked = True
        End If
        Try 'CONCEPTOS
            cbconcepto.Items.Clear()
            cbsr.Items.Clear()
            cbvalor.Items.Clear()
            cbcuenta.Items.Clear()
            cbbase.Items.Clear()
            cbldoc.Items.Clear()
            If Trim(tabla.Rows(0).Item("o_con")) = "si" Then 'hay otros conceptos
                '////////////
                Dim toc As New DataTable
                myCommand.CommandText = "SELECT  *  " _
                              & "FROM otcon_comp" & PerActual(0) & PerActual(1) & "  " _
                              & " WHERE doc = '" & numero _
                              & "' ORDER BY item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(toc)
                Refresh()

                If toc.Rows.Count > 0 Then
                    For l = 0 To toc.Rows.Count - 1
                        cbsr.Items.Add(toc.Rows(l).Item("tipo"))
                        cbconcepto.Items.Add(toc.Rows(l).Item("descrip"))
                        cbvalor.Items.Add(Moneda2(toc.Rows(l).Item("valor"), lb_imp_dec.Text))
                        cbcuenta.Items.Add(toc.Rows(l).Item("cta"))
                        cbbase.Items.Add(toc.Rows(l).Item("base"))
                        cbldoc.Items.Add(toc.Rows(l).Item("doc_ant"))
                    Next
                End If
                Try
                    cbconcepto.SelectedIndex = 0
                Catch ex As Exception
                End Try

                '/////////////

                ''Dim tipo As String = ""
                ''For i = 1 To 3
                ''    tipo = "t" & i 'tipo de concepto (1,2 o 3)
                ''    If Trim(tabla.Rows(0).Item(tipo)) <> "" Then
                ''        cbsr.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "d" & i 'descripcion (1,2 o 3)
                ''        cbconcepto.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "v" & i 'valor (1,2 o 3)
                ''        cbvalor.Items.Add(Moneda2(tabla.Rows(0).Item(tipo), lb_imp_dec.Text))
                ''        tipo = "cta" & i 'cuenta (1,2 o 3)
                ''        cbcuenta.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "b" & i 'base (1,2 o 3)
                ''        cbbase.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "doc" & i 'base (1,2 o 3)
                ''        If i = 1 Then lbanti1.Text = tabla.Rows(0).Item(tipo)
                ''        If i = 2 Then lbanti2.Text = tabla.Rows(0).Item(tipo)
                ''        If i = 3 Then lbanti3.Text = tabla.Rows(0).Item(tipo)
                ''    End If
                ''Next
                ''Try
                ''    cbconcepto.SelectedIndex = 0
                ''Catch ex As Exception
                ''End Try
            End If
        Catch ex As Exception
        End Try
        gfactura.RowCount = items + 1
        Dim suma As Double = 0
        lbdescuento.Text = "0"
        Dim dct As Double = 0
        Dim base As Double = 0
        Try
            For i = 0 To items - 1
                gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo_it")
                gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("cod_art")
                gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nom_art")
                gfactura.Item("bodega", i).Value = tabla.Rows(i).Item("num_bod")
                Try
                    gfactura.Item("cant", i).Value = Decimales(tabla.Rows(i).Item("cantidad").ToString)
                Catch ex As Exception
                End Try
                gfactura.Item("valor", i).Value = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text)
                gfactura.Item("Vtotal", i).Value = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
                gfactura.Item("iva", i).Value = tabla.Rows(i).Item("por_iva_g")
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_gas")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("valor")
                gfactura.Item("cc", i).Value = tabla.Rows(i).Item("concep")
                '... descuento
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
                '....
                Try
                    suma = suma + tabla.Rows(i).Item("vtotal")
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '******** ¿CUAL FORMA DE PAGO?  ************************************
        If Trim(tabla.Rows(0).Item("fpago").ToString) = "Efectivo" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        ElseIf Trim(tabla.Rows(0).Item("fpago").ToString) = "Cheque" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("numero", 0).Value = Trim(tabla.Rows(0).Item("num_ch").ToString)
            gfp.Item("banco", 0).Value = Trim(tabla.Rows(0).Item("banco").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        ElseIf Trim(tabla.Rows(0).Item("fpago").ToString) = "Tarjeta" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("numero", 0).Value = Trim(tabla.Rows(0).Item("num_tarj").ToString)
            gfp.Item("banco", 0).Value = Trim(tabla.Rows(0).Item("banco").ToString)
            gfp.Item("tt", 0).Value = Trim(tabla.Rows(0).Item("tip_tarj").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        Else 'OTRA CREDITO
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("desc_otra").ToString) '¿CUAL?
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        End If
        '*****************************************************
        lbsubtotal.Text = suma
        bloquear()
        cmditems.Enabled = False
        CalcularTotales()
    End Sub
    '*********** CALCULAR TOTALES *******************
    Public Sub CalcularTotales()
        Dim v_iva, x, desc, sd, vt, st, base, vcon As Double
        v_iva = 0
        sd = 0
        st = 0
        base = 0
        vcon = 0
        Try
            For i = 0 To gfactura.RowCount - 1
                Try 'base sin descuento
                    vt = CDbl(gfactura.Item("Vtotal", i).Value) / (1 + (CDbl(gfactura.Item("iva", i).Value) / 100)) 'base
                Catch ex As Exception
                    vt = 0
                End Try
                '
                Try
                    desc = vt * (CDbl(gfactura.Item("descuento", i).Value) / 100)
                    'desc = vt * (CDbl(valordes.Text) / 100) 
                Catch ex As Exception
                    desc = 0
                End Try
                vt = vt - desc
                '
                st = st + vt 'subtotal
                Try
                    desc = vt * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try

                sd = sd + desc
                Try
                    vt = vt - desc 'nueeva base
                Catch ex As Exception
                    vt = 0
                End Try
                base = base + vt
                Try
                    x = vt * (CDbl(gfactura.Item("iva", i).Value) / 100)
                    ' MsgBox(x & " = " & vt & " X " & gfactura.Item("iva", i).Value)
                Catch ex As Exception
                    ' MsgBox(ex.ToString)
                    x = 0
                End Try
                v_iva = v_iva + x
            Next
            txtiva.Text = Moneda2(v_iva, lb_imp_dec.Text)
        Catch ex As Exception
            txtiva.Text = Moneda2(v_iva, lb_imp_dec.Text)
            valoriva.Text = "0,00"
        End Try
        'descuentos
        Try
            valordes.Text = Format(CDbl(valordes.Text), "0.00")
        Catch ex As Exception
            valordes.Text = "0,00"
        End Try
        '********* RETENCIONES ************
        'RT FUENTE       
        txtdescuento.Text = Moneda2(sd, lb_imp_dec.Text)
        Try
            valorret.Text = Format(CDbl(valorret.Text), "0.00")
        Catch ex As Exception
            valorret.Text = "0,00"
        End Try
        txtsubtotal.Text = Moneda2(st, lb_imp_dec.Text)
        txtret.Text = Moneda2(CDbl(valorret.Text) * base / 100, lb_imp_dec.Text)
        txttotal.Text = Moneda2(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtret.Text) - CDbl(txtdescuento.Text), lb_imp_dec.Text)
        '************ RETECREE ****************
        Try
            valorretCree.Text = Format(CDbl(valorretCree.Text), "0.00")
        Catch ex As Exception
            valorretCree.Text = "0,00"
        End Try
        txtsubtotal.Text = Moneda2(st, lb_imp_dec.Text)
        txtretCre.Text = Moneda2(CDbl(valorretCree.Text) * base / 100, lb_imp_dec.Text)
        txttotal.Text = Moneda2(CDbl(txtsubtotal.Text) + CDbl(txtiva.Text) - CDbl(txtret.Text) - CDbl(txtretCre.Text) - CDbl(txtdescuento.Text), lb_imp_dec.Text)
        '........
        vcon = 0
        For i = 0 To cbsr.Items.Count - 1
            Try
                If Trim(cbsr.Items.Item(i).ToString) = "+" Then
                    txttotal.Text = Moneda2(CDbl(txttotal.Text) + CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
                    vcon = vcon + CDbl(cbvalor.Items.Item(i))
                ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
                    txttotal.Text = Moneda2(CDbl(txttotal.Text) - CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
                    vcon = vcon - CDbl(cbvalor.Items.Item(i))
                End If
            Catch ex As Exception
            End Try
        Next
        'For i = 0 To 2
        '    Try
        '        If Trim(cbsr.Items.Item(i).ToString) = "+" Then
        '            txttotal.Text = Moneda2(CDbl(txttotal.Text) + CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
        '            vcon = vcon + CDbl(cbvalor.Items.Item(i))
        '        ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
        '            txttotal.Text = Moneda2(CDbl(txttotal.Text) - CDbl(cbvalor.Items.Item(i)), lb_imp_dec.Text)
        '            vcon = vcon - CDbl(cbvalor.Items.Item(i))
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next
        lbvalor.Text = Moneda2(vcon, lb_imp_dec.Text)
        txtflete.Text = Moneda2(CDbl(txtflete.Text), lb_imp_dec.Text)
        txtseguro.Text = Moneda2(CDbl(txtseguro.Text), lb_imp_dec.Text)
        txttotal.Text = Moneda2(CDbl(txttotal.Text) + CDbl(txtflete.Text) + CDbl(txtseguro.Text), lb_imp_dec.Text)
        If gfp.RowCount = 1 Then
            gfp.Item("monto", 0).Value = txttotal.Text
        End If
    End Sub
    '************************************************
    Private Sub txttipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttipo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & Trim(txttipo.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
        txttipo2.Text = tabla.Rows(0).Item(0)
        If lbestado.Text = "NUEVO" Then
            BuscarNumero()
        End If
    End Sub
    Public Sub BuscarNumero()
        Try
            Dim tabla As New DataTable
            Dim item As Integer
            myCommand.CommandText = "SELECT actualfc FROM tipdoc where tipodoc='" & Trim(txttipo.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            item = tabla.Rows(0).Item(0)
            If item < 1 Then
                txtnumfac.Text = NumeroDoc(1)
            Else
                txtnumfac.Text = NumeroDoc(item + 1)
            End If
        Catch ex As Exception
            txtnumfac.Text = NumeroDoc(1)
        End Try
    End Sub
    Private Sub cmdfpago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfpago.Click
        FrmFormaPago.cmdvarias.Enabled = False
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
        '******************************************
        FrmFormaPago.tabforma.Visible = True
        FrmFormaPago.tabvarias.Visible = False
        FrmFormaPago.txtpago.Text = txttotal.Text
        gfp.Item("monto", 0).Value = txttotal.Text
        FrmFormaPago.txtcuenta.Text = txtcuentatotal.Text
        FrmFormaPago.txttotal.Text = txttotal.Text
        FrmFormaPago.txtcambio.Text = "0,00"
        FrmFormaPago.lbfp.Text = "Pagar Con " & gfp.Item("cual", 0).Value
        If gfp.Item("cual", 0).Value = "" Or gfp.Item("cual", 0).Value = "Efectivo" Then
            FrmFormaPago.lbfp.Text = "Pagar Con Efectivo"
            FrmFormaPago.gche.Enabled = False
            FrmFormaPago.gtar.Enabled = False
            FrmFormaPago.gcre.Enabled = False
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
        FrmFormaPago.lbform.Text = "fp"
        FrmFormaPago.ShowDialog()
        FrmFormaPago.cmdvarias.Enabled = True

    End Sub
    'VALIDACIONES
    Private Sub txtfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
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
    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        Try

            Dim cons As String = ""
            If txttipo.Text = lbdocajuste.Text Then
                cons = cons & "SELECT * FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
            Else

                Dim p As String = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> 12 Then
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
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
                BuscarDoc(txttipo.Text & txtnumfac.Text)
                lbnumero.Text = n

            End If
        Catch ex As Exception
        End Try

        'txtnumfac.Text = NumeroDoc(txtnumfac.Text)
    End Sub
    Private Sub txt_doc_afe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_doc_afe.KeyPress
        'If e.KeyChar = Chr(Keys.Enter) Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub
    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
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
            If txtnitc.Text <> "" Then
                retecree()
            End If
            cmditems.Enabled = True
            cmditems.Focus()
        Else
            gfactura.Focus()
        End If
    End Sub
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
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
            FrmSelCliente.lbform.Text = "fdp"
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
            resultado = MsgBox("El nit/cédula del proveedor no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "fdp"
                frmterceros.txtnit.Text = txtnitc.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "PROVEEDOR"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
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
                    valorretCree.Text = Moneda2(tr.Rows(0).Item("tarifa"), lb_imp_dec.Text)
                    txtcuentaCree.Text = tr.Rows(0).Item("cuenta")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdobservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdobservaciones.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmObsrvaciones.txtobservacion.Enabled = True
            If txtremision.Text <> "" Or lbpedido.Text <> "" Then
                FrmObsrvaciones.txtobservacion.Enabled = False
                'txtobserbaciones.Text = "REMISION ENTRADA N° " & txtremision.Text & "" & vbCrLf & txtobserbaciones.Text
            End If
        Else
            FrmObsrvaciones.txtobservacion.Enabled = False
        End If
        FrmObsrvaciones.txtobservacion.Text = txtobserbaciones.Text
        FrmObsrvaciones.lbform.Text = "fdp"
        FrmObsrvaciones.ShowDialog()
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
    Private Sub txtvmto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvmto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub cbaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '********* PORCENTAJES ***************
    Private Sub valordes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valordes.KeyPress
        ValidarPorcentaje(valordes, e)
    End Sub
    Private Sub valordes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valordes.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valorret_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valorret.KeyPress
        ValidarPorcentaje(valorret, e)
    End Sub
    Private Sub valorret_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valorret.LostFocus
        CalcularTotales()
    End Sub
    Private Sub valoriva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valoriva.KeyPress
        ValidarPorcentaje(valoriva, e)
    End Sub
    Private Sub valoriva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valoriva.LostFocus
        CalcularTotales()
    End Sub
    '********** CUENTAS *************
    Private Sub txtcuentadesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentadesc.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_desc"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaret_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaret.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_rtf"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuentaiva.KeyPress
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_iva"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaflete_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaflete.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_fle"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentaseguro_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaseguro.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_seg"
        FrmCuentas.ShowDialog()
    End Sub
    Private Sub txtcuentatotal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentatotal.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_total"
        FrmCuentas.ShowDialog()
    End Sub
    '****************************************************************
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        FrmItemsCompras.txtnumfac.Text = txtnumfac.Text
        FrmItemsCompras.txtfecha.Text = txtfecha.Text.ToString
        FrmItemsCompras.txttipo.Text = txttipo.Text
        FrmItemsCompras.txttipo2.Text = txttipo2.Text
        FrmItemsCompras.gitems.RowCount = 1
        Try
            FrmItemsCompras.gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        FrmItemsCompras.gitems.RowCount = gfactura.RowCount

        For i = 0 To gfactura.RowCount - 1
            FrmItemsCompras.gitems.Item("num", i).Value = i + 1
            FrmItemsCompras.gitems.Item("tipo", i).Value = gfactura.Item("tipo", i).Value
            FrmItemsCompras.gitems.Item("codigo", i).Value = gfactura.Item("codigo", i).Value
            FrmItemsCompras.gitems.Item("descrip", i).Value = gfactura.Item("descrip", i).Value
            FrmItemsCompras.gitems.Item("cant", i).Value = gfactura.Item("cant", i).Value
            FrmItemsCompras.gitems.Item("precio", i).Value = gfactura.Item("valor", i).Value
            FrmItemsCompras.gitems.Item("bodega", i).Value = gfactura.Item("bodega", i).Value
            FrmItemsCompras.gitems.Item("iva", i).Value = gfactura.Item("iva", i).Value
            '/////////////////////////////////////////////////////////////////////////////
            FrmItemsCompras.gitems.Item("cc", i).Value = gfactura.Item("cc", i).Value
            FrmItemsCompras.gitems.Item("ctainv", i).Value = gfactura.Item("ctainv", i).Value
            FrmItemsCompras.gitems.Item("ctacven", i).Value = gfactura.Item("ctacven", i).Value
            FrmItemsCompras.gitems.Item("ctaing", i).Value = gfactura.Item("ctaing", i).Value 'cta ing / gas
            FrmItemsCompras.gitems.Item("ctaiva", i).Value = gfactura.Item("ctaiva", i).Value
            FrmItemsCompras.gitems.Item("descuento", i).Value = Moneda2(gfactura.Item("descuento", i).Value, lb_imp_dec.Text)
        Next
        FrmItemsCompras.lbiva.Text = "NO"
        FrmItemsCompras.gitems.Columns(1).ReadOnly = False  'tipo I/S
        FrmItemsCompras.gitems.Columns(6).ReadOnly = False  'bodega
        FrmItemsCompras.gitems.Columns("cc").ReadOnly = True  'NO hay concepto comicionable
        FrmItemsCompras.lbform.Text = "fdp"
        FrmItemsCompras.LbTipoMov.Text = "entradas"
        FrmItemsCompras.gitems.Focus()
        FrmItemsCompras.ShowDialog()
        FrmItemsCompras.lbiva.Text = "NO"
        CalcularTotales()
    End Sub

    Private Sub Factura_Resumida()
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If lbimpap.Text = "SI" And cbaprobado.Text <> "AP" Then
                MsgBox("Para imprimir el documento de estar Aprobado (AP), Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
            Me.Cursor = Cursors.WaitCursor
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT format_fp FROM par_comp;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                If tabla.Rows.Count > 0 Then
                    lbformat.Text = tabla.Rows(0).Item(0)
                Else
                    lbformat.Text = "pdf"
                End If
            Catch ex As Exception
                lbformat.Text = "pdf"
            End Try
            Try
                If Trim(lbformat.Text) = "pdf" Then
                    GenerarPDF()
                ElseIf Trim(lbformat.Text) = "pdf2" Then
                    GenerarPDF2()
                Else
                    GenerarTicket()
                End If
            Catch ex As Exception
            End Try
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub Factura_Detallada()
        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim prov As String = ""
        Dim doc As String = ""
        Dim docD As String = ""
        Dim AfI As String = ""
        Dim fecha As String = ""
        Dim estado As String = ""
        Dim letraT As String = ""
        Dim subt As String = ""
        Dim des As String = ""
        Dim ret As String = ""
        Dim flet As String = ""
        Dim seg As String = ""
        Dim tot As String = ""
        Dim cdes As String = ""
        Dim cret As String = ""
        Dim cflet As String = ""
        Dim cseg As String = ""
        Dim ctot As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        prov = txtnitc.Text & " - " & txtcliente.Text
        doc = txttipo.Text & "  " & txttipo2.Text & "  " & txttipo.Text & txtnumfac.Text
        fecha = txtfecha.Text
        letraT = Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text))

        subt = txtsubtotal.Text
        des = txtdescuento.Text
        ret = txtret.Text
        flet = txtflete.Text
        seg = txtseguro.Text
        tot = txttotal.Text
        cdes = txtcuentadesc.Text
        cret = txtcuentaret.Text
        cflet = txtcuentaflete.Text
        cseg = txtcuentaseguro.Text
        ctot = txtcuentatotal.Text

        If cbaprobado.Text = "AP" Then
            estado = "APROBADO"
        Else
            estado = ""
        End If

        If rbdocde1.Checked = True Then
            docD = rbdocde1.Text
        Else
            docD = rbdocde2.Text
        End If

        If rbafecta1.Checked = True Then
            AfI = rbafecta1.Text
        Else
            AfI = rbafecta2.Text
        End If

        MiConexion(bda)
        Cerrar()


        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")
        '------------------------------------------
        Dim sql4 As String = ""
        Dim fpago As String = ""
        Dim fv As String = ""

        sql4 = " SELECT f.o_con,  CONCAT(f.fpago,', ', f.desc_otra) as Fpag, " _
       & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 2 ) ,  '/', " _
       & " MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 6, 2 ) ,  '/',  " _
       & " LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 4 ) ) ) AS CHAR( 20 ) ) AS fechaV " _
       & " FROM fact_comp" & p & " f WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' "

        Dim tabla5 As New DataTable
        tabla5 = New DataTable
        myCommand.CommandText = sql4
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla5)
        For i = 0 To tabla5.Rows.Count - 1
            fpago = tabla5.Rows(i).Item("Fpag").ToString
            fv = tabla5.Rows(i).Item("fechaV").ToString
        Next
        '---------------------------------------------
        Dim sql3 As String = ""
        Dim otro As String = ""
        Dim c_otro As String = ""
        Dim t_otro As String = ""

        If tabla5.Rows(0).Item("o_con").ToString = "si" Then
            sql3 = "SELECT * FROM otcon_comp" & p & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "'"
            'sql3 = " SELECT f.o_con,f.t1, f.d1, f.v1, f.cta1, f.t2,f.d2,f.v2,f.cta2,f.t3,f.d3,f.v3, f.cta3 FROM fact_comp" & p & " f WHERE f.doc= '" & txttipo.Text & txtnumfac.Text & "' "
            Dim tabla4 As New DataTable
            tabla4 = New DataTable
            myCommand.CommandText = sql3
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)

            If tabla4.Rows.Count > 0 Then
                For i = 0 To tabla4.Rows.Count - 1
                    t_otro = t_otro & (tabla4.Rows(i).Item("descrip").ToString) & vbCrLf
                    otro = otro & (tabla4.Rows(i).Item("tipo").ToString) & " " & Moneda2(tabla4.Rows(i).Item("valor").ToString, lb_imp_dec.Text) & vbCrLf
                    c_otro = c_otro & (tabla4.Rows(i).Item("cta").ToString) & vbCrLf
                Next
            End If

        End If

        'For i = 0 To tabla4.Rows.Count - 1
        '    If (tabla4.Rows(i).Item("o_con").ToString) = "si" Then
        '        If (tabla4.Rows(i).Item("t1").ToString) <> "" Then
        '            t_otro = t_otro & (tabla4.Rows(i).Item("d1").ToString) & vbCrLf
        '            otro = otro & (tabla4.Rows(i).Item("t1").ToString) & " " & Moneda2(tabla4.Rows(i).Item("v1").ToString, lb_imp_dec.Text) & vbCrLf
        '            c_otro = c_otro & (tabla4.Rows(i).Item("cta1").ToString) & vbCrLf
        '        End If
        '        If (tabla4.Rows(i).Item("t2").ToString) <> "" Then
        '            t_otro = t_otro & (tabla4.Rows(i).Item("d2").ToString) & vbCrLf
        '            otro = otro & (tabla4.Rows(i).Item("t2").ToString) & " " & Moneda2(tabla4.Rows(i).Item("v2").ToString, lb_imp_dec.Text) & vbCrLf
        '            c_otro = c_otro & (tabla4.Rows(i).Item("cta2").ToString) & vbCrLf
        '        End If
        '        If (tabla4.Rows(i).Item("t3").ToString) <> "" Then
        '            t_otro = t_otro & (tabla4.Rows(i).Item("d3").ToString) & vbCrLf
        '            otro = otro & (tabla4.Rows(i).Item("t3").ToString) & " " & Moneda2(tabla4.Rows(i).Item("v3").ToString, lb_imp_dec.Text) & vbCrLf
        '            c_otro = c_otro & (tabla4.Rows(i).Item("cta3").ToString) & vbCrLf
        '        End If
        '    Else
        '        t_otro = ""
        '        otro = ""
        '        c_otro = ""
        '    End If
        'Next
        '----------------------------------------------
        Dim sql2 As String = ""
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        Dim c_iva As String = ""
        sql2 = " SELECT d.por_iva_g , " _
        & "SUM( (((d.vtotal / ( 1 + ( d.por_iva_g /100 ) )) -  ((d.vtotal / ( 1 + ( d.por_iva_g /100 ) ))) * (d.por_des/100))* (d.por_iva_g /100)) - (((d.vtotal / ( 1 + ( d.por_iva_g /100 ) )) -  ((d.vtotal / ( 1 + ( d.por_iva_g /100 ) ))) * (d.por_des/100))* (d.por_iva_g /100))* (f.por_desc /100)) AS IVA, " _
        & "   f.cta_iva FROM detacomp" & p & " d, fact_comp" & p & " f WHERE d.doc='" & txttipo.Text & txtnumfac.Text & "' AND f.doc='" & txttipo.Text & txtnumfac.Text & "' GROUP BY d.por_iva_g "

        Dim tabla3 As New DataTable
        tabla3 = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)

        If txtiva.Text <> 0 Then
            For i = 0 To tabla3.Rows.Count - 1
                If (tabla3.Rows(i).Item(0).ToString) <> 0 Then
                    v_iva = v_iva & Moneda2(tabla3.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
                    tv_iva = tv_iva & "IVA " & (tabla3.Rows(i).Item(0).ToString) & " %" & vbCrLf
                    c_iva = c_iva & (tabla3.Rows(i).Item(2).ToString) & vbCrLf
                End If
            Next
        Else
            v_iva = "0.00"
            tv_iva = "IVA "
            c_iva = ""
        End If
        '---------------------------------

        Dim dc As Integer = 0
        If lb_imp_dec.Text = "S" Then
            dc = 2
        End If

        sql = " select d.doc, d.item , d.cod_art as codart, d.nom_art as nomart,  d.num_bod as numbod, d.cantidad, " _
           & " FORMAT((d.valor / ( 1 + ( d.por_iva_g /100 ) )) -  ((d.valor / ( 1 + ( d.por_iva_g /100 ) ))) * (d.por_des/100)," & dc & ") AS valor,  " _
           & " f.por_desc as iva_d, " _
           & " FORMAT(((d.valor / ( 1 + ( d.por_iva_g /100 ) )) -  ((d.valor / ( 1 + ( d.por_iva_g /100 ) ))) * (d.por_des/100) ) * d.cantidad," & dc & ") as vtotal,  " _
           & " d.cta_inv, IF (d.tipo_it='I',d.cta_cos,d.cta_gas) as cta_cos, if(f.ctoc=0,'',f.ctoc) as concep from detacomp" & p & " d, fact_comp" & p & " f where d.doc =  '" & txttipo.Text & txtnumfac.Text & "'  and  f.doc = d.doc "

        TextBox1.Text = sql

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportDocP.rpt")
        CrReport.SetDataSource(tabla)
        CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportDocP.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField

            Dim Prpr As New ParameterField
            Dim Prdoc As New ParameterField
            Dim Prdocd As New ParameterField
            Dim PrAF As New ParameterField
            Dim Prfec As New ParameterField
            Dim PrEst As New ParameterField
            Dim PrtotalL As New ParameterField

            Dim Prsub As New ParameterField
            Dim Prdes As New ParameterField
            Dim Prrt As New ParameterField
            Dim Prft As New ParameterField
            Dim Prsg As New ParameterField
            Dim Prdesc As New ParameterField
            Dim Prrtc As New ParameterField
            Dim Prftc As New ParameterField
            Dim Prsgc As New ParameterField
            Dim Prtt As New ParameterField
            Dim Prttc As New ParameterField

            Dim Prfpago As New ParameterField
            Dim Prfv As New ParameterField
            Dim Priv As New ParameterField
            Dim Prv_iv As New ParameterField
            Dim Prc_iv As New ParameterField
            Dim PrO As New ParameterField
            Dim PrOt As New ParameterField
            Dim PrOc As New ParameterField
            Dim Prde As New ParameterField
            Dim Prprc As New ParameterField
            Dim Prrc As New ParameterField
            Dim Prctarc As New ParameterField
            Dim Prdec As New ParameterField
            Dim Prtrtcre As New ParameterField
            Dim Prtrt As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prpr.Name = "prov"
            Prpr.CurrentValues.AddValue(prov.ToString)
            Prdoc.Name = "doc"
            Prdoc.CurrentValues.AddValue(doc.ToString)
            Prdocd.Name = "docde"
            Prdocd.CurrentValues.AddValue(docD.ToString)
            PrAF.Name = "afI"
            PrAF.CurrentValues.AddValue(AfI.ToString)
            Prfec.Name = "fech"
            Prfec.CurrentValues.AddValue(fecha.ToString)
            PrEst.Name = "estado"
            PrEst.CurrentValues.AddValue(estado.ToString)
            PrtotalL.Name = "Ltotal"
            PrtotalL.CurrentValues.AddValue(letraT.ToString)

            Prsub.Name = "sub"
            Prsub.CurrentValues.AddValue(subt.ToString)
            Prdes.Name = "des"
            Prdes.CurrentValues.AddValue(des.ToString)
            Prdesc.Name = "cdes"
            Prdesc.CurrentValues.AddValue(cdes.ToString)
            Prrt.Name = "ret"
            Prrt.CurrentValues.AddValue(ret.ToString)
            Prrtc.Name = "cret"
            Prrtc.CurrentValues.AddValue(cret.ToString)
            Prft.Name = "flt"
            Prft.CurrentValues.AddValue(flet.ToString)
            Prftc.Name = "cflt"
            Prftc.CurrentValues.AddValue(cflet.ToString)
            Prsg.Name = "seg"
            Prsg.CurrentValues.AddValue(seg.ToString)
            Prsgc.Name = "cseg"
            Prsgc.CurrentValues.AddValue(cseg.ToString)
            Prtt.Name = "tt"
            Prtt.CurrentValues.AddValue(tot.ToString)
            Prttc.Name = "ctt"
            Prttc.CurrentValues.AddValue(ctot.ToString)

            Prfpago.Name = "fpag"
            Prfpago.CurrentValues.AddValue(fpago.ToString)
            Prfv.Name = "fechV"
            Prfv.CurrentValues.AddValue(fv.ToString)
            Priv.Name = "iva"
            Priv.CurrentValues.AddValue(tv_iva.ToString)
            Prv_iv.Name = "v_iva"
            Prv_iv.CurrentValues.AddValue(v_iva.ToString)
            Prc_iv.Name = "c_iva"
            Prc_iv.CurrentValues.AddValue(c_iva.ToString)

            PrO.Name = "otro"
            PrO.CurrentValues.AddValue(otro.ToString)
            PrOt.Name = "t_otro"
            PrOt.CurrentValues.AddValue(t_otro.ToString)
            PrOc.Name = "c_otro"
            PrOc.CurrentValues.AddValue(c_otro.ToString)
            Prde.Name = "dext"
            Prde.CurrentValues.AddValue(txt_doc_afe.Text.ToString)


            Prtrtcre.Name = "trtcree"
            Prtrtcre.CurrentValues.AddValue("RETECREE " & valorretCree.Text.ToString & " %")
            Prrc.Name = "rtc"
            Prrc.CurrentValues.AddValue(txtretCre.Text.ToString)
            Prctarc.Name = "crtc"
            Prctarc.CurrentValues.AddValue(txtcuentaCree.Text.ToString)


            Prtrt.Name = "trten"
            Prtrt.CurrentValues.AddValue("RETENCION " & valorret.Text.ToString & " %")

            Prdec.Name = "decim"
            Prdec.CurrentValues.AddValue(lb_imp_dec.Text)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prpr)
            prmdatos.Add(Prdoc)
            prmdatos.Add(Prdocd)
            prmdatos.Add(PrAF)
            prmdatos.Add(Prfec)
            prmdatos.Add(PrEst)
            prmdatos.Add(PrtotalL)
            prmdatos.Add(Prsub)
            prmdatos.Add(Prdes)
            prmdatos.Add(Prdesc)
            prmdatos.Add(Prrt)
            prmdatos.Add(Prrtc)
            prmdatos.Add(Prft)
            prmdatos.Add(Prftc)
            prmdatos.Add(Prsg)
            prmdatos.Add(Prsgc)
            prmdatos.Add(Prtt)
            prmdatos.Add(Prttc)
            prmdatos.Add(Prfpago)
            prmdatos.Add(Prfv)
            prmdatos.Add(Priv)
            prmdatos.Add(Prv_iv)
            prmdatos.Add(Prc_iv)
            prmdatos.Add(PrO)
            prmdatos.Add(PrOt)
            prmdatos.Add(PrOc)
            prmdatos.Add(Prde)
            prmdatos.Add(Prrc)
            prmdatos.Add(Prctarc)
            prmdatos.Add(Prdec)
            prmdatos.Add(Prtrtcre)
            prmdatos.Add(Prtrt)

            FrmReportDocP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportDocP.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try
        conexion.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            If lbimpap.Text = "SI" And cbaprobado.Text <> "AP" Then
                MsgBox("Para imprimir el documento de estar Aprobado (AP), Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
            If rbR.Checked = True Then
                Factura_Resumida()
            Else
                Try
                    Factura_Detallada()
                Catch ex As Exception
                End Try
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
            MsgBox("No ha digitado datos del proveedor, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtnitc.Focus()
            Exit Sub
            'ElseIf txtdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
        ElseIf valordes.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
            Exit Sub
        ElseIf txtflete.Text <> Moneda2(0, lb_imp_dec.Text) And txtcuentaflete.Text = "" And txtcuentaflete.Enabled = True Then
            MsgBox("No ha escojido cuenta para los fletes, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaflete.Focus()
            Exit Sub
        ElseIf txtseguro.Text <> Moneda2(0, lb_imp_dec.Text) And txtcuentaseguro.Text = "" And txtcuentaseguro.Enabled = True Then
            MsgBox("No ha escojido cuenta para el seguro, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaseguro.Focus()
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
        ElseIf valorretCree.Text <> "0,00" And txtcuentaCree.Text = "" Then
            MsgBox("No ha escogido La cuenta para la Retencion CREE, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaCree.Focus()
            Exit Sub
        End If
        Dim sumafp As Double = 0
        For i = 0 To gfp.RowCount - 1
            sumafp = sumafp + Moneda2(gfp.Item("monto", i).Value, lb_imp_dec.Text)
        Next
        If sumafp <> Moneda2(txttotal.Text, lb_imp_dec.Text) Or gfp.Item("cual", 0).Value = "" Then
            MsgBox("Verifique la forma de pago.", MsgBoxStyle.Information, "Control Factura ")
            cmdfpago_Click(AcceptButton, AcceptButton)
            Exit Sub
        End If
        If PerActual <> Format(txtfecha.Value, "MM/yyyy") Then
            MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
            If txtfecha.Enabled = True Then
                txtfecha.Focus()
            End If
            Exit Sub
        End If
        'If txtremision.Text = "" Then
        If Trim(txt_doc_afe.Text) = "" Then
            Dim rdoc As MsgBoxResult
            rdoc = MsgBox("No ha digitado documento externo, ¿Desea Digitarlo? ", MsgBoxStyle.YesNo, "Verificando")
            If rdoc = MsgBoxResult.Yes Then
                txt_doc_afe.Focus()
                Exit Sub
            End If
        End If
        ' End If
        '''''' VALIDAR SI EXIXTE FACTURA '''''''''''''''''
        Dim sw As Integer = 0
        Dim conta As Integer = 0
        Dim sqlext As String = ""
        Do
            Dim cons As String = ""
            If txttipo.Text = lbdocajuste.Text Then
                cons = cons & "SELECT * FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
            Else
                Dim p As String = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> 12 Then
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE  tipodoc='" & txttipo.Text & "' AND num='" & txtnumfac.Text & "' "
                    End If
                Next
            End If
            Dim t As New DataTable
            myCommand.CommandText = cons
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()

            If t.Rows.Count > 0 Then
                If txtnumfac.Enabled = True Then
                    MsgBox("Verifique el numero de factura de compra, ya existe en los registros. ", MsgBoxStyle.Information, "SAE Control")
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

            ' VALIDAR DOC EXT
            If txt_doc_afe.Text <> "" Then
                Dim p As String = ""
                cons = ""
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> 12 Then
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE nitc='" & txtnitc.Text & "' AND doc_afec= '" & txt_doc_afe.Text & "' UNION "
                    Else
                        cons = cons & "SELECT * FROM fact_comp" & p & " WHERE  nitc='" & txtnitc.Text & "' AND doc_afec= '" & txt_doc_afe.Text & "' "
                    End If
                Next
                Dim taf As New DataTable
                myCommand.CommandText = cons
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(taf)
                Refresh()
                If taf.Rows.Count > 0 Then
                    Dim rdocf As MsgBoxResult
                    rdocf = MsgBox("Ya existe en el sistema un documento externo asociado a este proveedor ¿Desea Continuar? ", MsgBoxStyle.YesNo, "Verificando")
                    If rdocf = MsgBoxResult.No Then
                        txt_doc_afe.Focus()
                        Exit Sub
                    End If
                End If


            End If
        Loop While sw = 0
        validarcuentasFP()
        GuardarFactura()
    End Sub
    Public Sub validarcuentasFP()

        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Try
                '.....AUDITORIA PAGOS
                If gfp.Item("cual", 0).Value.ToString = "Cheque" Then
                    Vali_cuent_prov("ban", "FP-FACTURA DE PROVEEDORES", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", 0).Value.ToString = "Tarjeta" Then
                    Vali_cuent_prov("ban", "FP-FACTURA DE PROVEEDORES", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", 0).Value.ToString = "Efectivo" Then
                    Vali_cuent_prov("caja", "FP-FACTURA DE PROVEEDORES", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                ElseIf gfp.Item("cual", 0).Value.ToString = "Otra" Then
                    Vali_cuent_prov("cxc", "FP-FACTURA DE PROVEEDORES", txtcuentatotal.Text, txttipo.Text & txtnumfac.Text)
                End If
                '....... FIN AUDITORIA 


                If txtcuentadesc.Text <> "" Then
                    Vali_cuent_prov("des", "FP-FACTURA DE PROVEEDORES", txtcuentadesc.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtcuentaiva.Text <> "" Then
                    Vali_cuent_prov("ivap", "FP-FACTURA DE PROVEEDORES", txtcuentaiva.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtcuentaret.Text <> "" Then
                    Vali_cuent_prov("rtf", "FP-FACTURA DE PROVEEDORES", txtcuentaret.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtcuentaflete.Text <> "" Then
                    Vali_cuent_prov("fle", "FP-FACTURA DE PROVEEDORES", txtcuentaflete.Text, txttipo.Text & txtnumfac.Text)
                End If
                If txtcuentaseguro.Text <> "" Then
                    Vali_cuent_prov("seg", "FP-FACTURA DE PROVEEDORES", txtcuentaseguro.Text, txttipo.Text & txtnumfac.Text)
                End If

            Catch ex As Exception
                MsgBox("Error al Auditar, " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If

    End Sub
    Public Sub GuardarFactura()
        Dim afecta, doc_de As String
        txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(txtdescuento.Text)
        If rbafecta1.Checked = True Then
            afecta = "SI"  'SI afecta inventario
        Else
            afecta = "NO"  'NO afecta inventario
        End If
        If rbdocde1.Checked = True Then
            doc_de = "I"  'doc inventario
        Else
            doc_de = "G"  'doc gastos
        End If
        Timer1.Enabled = False
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
        myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text.ToString)
        myCommand.Parameters.AddWithValue("?doc_de", doc_de)
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?usuario", lbusuario.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text.ToString))
        myCommand.Parameters.AddWithValue("?hora", CDate(lbhora.Text))
        myCommand.Parameters.AddWithValue("?anulado", "no")
        myCommand.Parameters.AddWithValue("?doc_afec", txt_doc_afe.Text)
        myCommand.Parameters.AddWithValue("?afecta", afecta)
        'subtotal
        myCommand.Parameters.AddWithValue("?subtotal", DIN(Moneda2(txtsubtotal.Text, lb_imp_dec.Text)))
        'descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(Moneda2(txtdescuento.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_rtf", DIN(valorret.Text))
        myCommand.Parameters.AddWithValue("?rtf", DIN(Moneda2(txtret.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_rtf", txtcuentaret.Text)
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", DIN(valorretCree.Text))
        myCommand.Parameters.AddWithValue("?rtc", DIN(Moneda2(txtretCre.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_rtc", txtcuentaCree.Text)
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(Moneda2(txtiva.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'fletes
        myCommand.Parameters.AddWithValue("?fle", DIN(Moneda2(txtflete.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_fle", txtcuentaflete.Text)
        'seguros
        myCommand.Parameters.AddWithValue("?seg", DIN(Moneda2(txtseguro.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_seg", txtcuentaseguro.Text)
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(Moneda2(txttotal.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'centro de costo
        myCommand.Parameters.AddWithValue("?ctoc", Val(txtcentrocosto.Text))
        ' VALOR AAF
        If (txt_doc_afe.Text <> "") And (FDpagoAJ <> "") And (txtAF.Text <> "") And (txttipo.Text = lbdocajuste.Text) Then
            myCommand.Parameters.AddWithValue("?val_aj", DIN(txttotal.Text))
        Else
            myCommand.Parameters.AddWithValue("?val_aj", DIN(0))
        End If
        '*************** INICIO FORMA DE PAGO *************************************
        If gfp.Item("cual", 0).Value.ToString = "Efectivo" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", " ")
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        ElseIf gfp.Item("cual", 0).Value.ToString = "Cheque" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", gfp.Item("numero", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?banco", gfp.Item("banco", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        ElseIf gfp.Item("cual", 0).Value.ToString = "Tarjeta" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", gfp.Item("banco", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?tip_tarj", gfp.Item("tt", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_tarj", gfp.Item("numero", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        Else 'OTRA CREDITO
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", " ")
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", gfp.Item("detalle", 0).Value.ToString)
        End If
        '*************** FIN FORMA DE PAGO *************************************
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
        ' ''otros conceptos
        ''For i = 0 To 2
        ''    If i = 0 Then
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?o_con", "si")
        ''                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v1", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b1", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta1", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc1", lbanti1.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?o_con", "no")
        ''                myCommand.Parameters.AddWithValue("?t1", "")
        ''                myCommand.Parameters.AddWithValue("?d1", "")
        ''                myCommand.Parameters.AddWithValue("?v1", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b1", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta1", "")
        ''                myCommand.Parameters.AddWithValue("?doc1", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?o_con", "no")
        ''            myCommand.Parameters.AddWithValue("?t1", "")
        ''            myCommand.Parameters.AddWithValue("?d1", "")
        ''            myCommand.Parameters.AddWithValue("?v1", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b1", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta1", "")
        ''            myCommand.Parameters.AddWithValue("?doc1", "")
        ''        End Try
        ''    ElseIf i = 1 Then
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?t2", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d2", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v2", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b2", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta2", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc2", lbanti2.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?t2", "")
        ''                myCommand.Parameters.AddWithValue("?d2", "")
        ''                myCommand.Parameters.AddWithValue("?v2", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b2", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta2", "")
        ''                myCommand.Parameters.AddWithValue("?doc2", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?t2", "")
        ''            myCommand.Parameters.AddWithValue("?d2", "")
        ''            myCommand.Parameters.AddWithValue("?v2", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b2", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta2", "")
        ''            myCommand.Parameters.AddWithValue("?doc2", "")
        ''        End Try
        ''    Else
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?t3", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d3", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v3", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b3", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta3", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc3", lbanti3.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?t3", "")
        ''                myCommand.Parameters.AddWithValue("?d3", "")
        ''                myCommand.Parameters.AddWithValue("?v3", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b3", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta3", "")
        ''                myCommand.Parameters.AddWithValue("?doc3", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?t3", "")
        ''            myCommand.Parameters.AddWithValue("?d3", "")
        ''            myCommand.Parameters.AddWithValue("?v3", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b3", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta3", "")
        ''            myCommand.Parameters.AddWithValue("?doc3", "")
        ''        End Try
        ''    End If
        ''Next
        'INSERTAR FACTURA
        myCommand.CommandText = "INSERT INTO fact_comp" & PerActual(0) & PerActual(1) & " VALUES (?doc,?num,?tipodoc,?doc_de,?nitc,?usuario,?fecha,?hora,?anulado,?doc_afec,?afecta," _
                              & "?subtotal,?por_desc,?descuento,?cta_desc,?por_rtf,?rtf,?cta_rtf,?por_iva,?iva,?cta_iva,?fle,?cta_fle,?seg,?cta_seg," _
                              & "?total,?cta_total,?estado,?observ,?vmto,?ctoc," _
                              & "?fpago,?num_ch,?banco,?tip_tarj,?num_tarj,?desc_otra," _
                              & "?o_con,?t1,?d1,?v1,?cta1,?t2,?d2,?v2,?cta2,?t3,?d3,?v3,?cta3,?b1,?b2,?b3,?doc1,?doc2,?doc3,?val_aj,?por_rtc,?rtc,?cta_rtc);"
        myCommand.ExecuteNonQuery()
        Refresh()

        If cbaprobado.Text = "AP" Then
            GuardarAnticipos()
        End If
        '*********************************************
        Dim formula As String = "manual"
        Dim margen As Double = 0
        Dim t As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count > 0 Then
            formula = t.Rows(0).Item("formula")
            margen = t.Rows(0).Item("porcen")
        End If
        '*********************************************
        Dim sw As Integer = 0
        Dim total_inv, subt As Double
        total_inv = 0
        For i = 0 To gfactura.RowCount - 1
            If gfactura.Item("codigo", i).Value <> "" Then
                GuardarDetalles(i)
                If rbafecta1.Checked = True And cbaprobado.Text = "AP" Then 'AFECTA INVENTARIOS
                    If gfactura.Item("tipo", i).Value = "I" Then ' hay movimientos de inventarios
                        sw = 1
                        GuardarEnBodega(i)
                        If formula = "manual" Then
                            margen = 0
                        Else
                            GuardarPrecios(i, formula, margen)
                        End If
                        Actualizar_Con_inv(i, formula, margen)
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

        ' ACTUALIZAR TAB MOVIMIENTOS//////////
        If txtremision.Text <> "" Then
            myCommand.Parameters.Clear()
            myCommand.CommandText = " UPDATE  `movimientos" & PerActual(0) & PerActual(1) & "` SET  `n_pedido` =  'FAC' WHERE doc='" & txtremision.Text & "'"
            myCommand.ExecuteNonQuery()
            Refresh()
        End If
        '///////////
        ' ACTUALIZAR TAB PEDIDOS//////////
        If lbpedido.Text <> "" Then
            myCommand.Parameters.Clear()
            myCommand.CommandText = " UPDATE  pedi_comp  SET  cumplido =  'si' WHERE numero='" & lbpedido.Text & "'"
            myCommand.ExecuteNonQuery()
            Refresh()
            ActualizCanPedidos()
            lbpedido.Text = ""
        End If
        '///////////

        '...AJUST PAGO CREDITO
        If txtAF.Text <> "" And FDpagoAJ <> "" And cbaprobado.Text = "AP" Then
            AbonoAJ()
        End If


        If cbaprobado.Text = "AP" Then
            GuardarContable()
            If txttipo.Text <> lbdocajuste.Text Then
                GuardarCTA_X_PAGAR() 'ctas por pagar
            End If
            If txtremision.Text = "" And sw = 1 And rbafecta1.Checked = True Then
                GuardarMoviInvetarios(total_inv) 'si hay movi de inventarios y si afecta inventarios
            End If
        End If
        If cbsr.Items.Count <> 0 Then
            GuardarOtrosConcep()
        End If
        ValidarConsecutivo()
        bloquear()
        CalcularTotales()
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("COMPRAS", "GUARDAR FACTURA Nº: " & txttipo.Text & txtnumfac.Text, "", "", "")
        End If
        '.....
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        DBCon.Close()
        lbnumero.Text = "0"
        lbestado.Text = "GUARDADO"
        cmditems.Enabled = False
        cbaprobado.Enabled = False
        txtremision.Text = ""
        lbpedido.Text = ""
    End Sub
    Private Sub GuardarOtrosConcep()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM otcon_comp" & PerActual(0) & PerActual(1) & " " _
                                     & " WHERE doc ='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            For j = 0 To cbsr.Items.Count - 1
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
                myCommand.Parameters.AddWithValue("?itm", j + 1)
                myCommand.Parameters.AddWithValue("?sg", cbsr.Items.Item(j))
                myCommand.Parameters.AddWithValue("?des", CambiaCadena(cbconcepto.Items.Item(j), 99))
                myCommand.Parameters.AddWithValue("?v", DIN(Moneda2(cbvalor.Items.Item(j), lb_imp_dec.Text)))
                myCommand.Parameters.AddWithValue("?b", DIN(Moneda2(cbbase.Items.Item(j), lb_imp_dec.Text)))
                myCommand.Parameters.AddWithValue("?cta", cbcuenta.Items.Item(j))
                myCommand.Parameters.AddWithValue("?docAn", cbldoc.Items.Item(j))
                myCommand.CommandText = "INSERT INTO otcon_comp" & PerActual(0) & PerActual(1) & " " _
                                      & " Values(?doc,?itm,?sg,?des,?v,?cta,?b,?docAn);"
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox("Error al registrar los otros conceptos, " & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
    End Sub
    Private Sub AbonoAJ()
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE ctas_x_pagar SET total=total-" & DIN(txttotal.Text) & " WHERE doc='" & txt_doc_afe.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub ActualizCanPedidos()

        Dim tp As New DataTable
        myCommand.CommandText = "SELECT item FROM pedi_comp  WHERE numero='" & lbpedido.Text & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)

        If tp.Rows.Count > 0 Then
            For i = 0 To tp.Rows.Count - 1
                myCommand.Parameters.Clear()
                myCommand.CommandText = " UPDATE  pedi_comp  SET  cantrec = cantped WHERE numero='" & lbpedido.Text & "' and item ='" & tp.Rows(i).Item(0) & "'"
                myCommand.ExecuteNonQuery()
                Refresh()
            Next
        End If

    End Sub
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
                        sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti1.Text) & "';"
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
                        sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti2.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            Else
                Try
                    If Trim(cbsr.Items.Item(i).ToString) <> "" Then
                        myCommand.Parameters.Clear()
                        sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(cbvalor.Items.Item(i).ToString) & " WHERE per_doc='" & Trim(lbanti3.Text) & "';"
                        myCommand.CommandText = sql
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?tipo_it", gfactura.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item(1, fila).Value)
            myCommand.Parameters.AddWithValue("?nom_art", gfactura.Item(2, fila).Value)
            myCommand.Parameters.AddWithValue("?numbod", Val(gfactura.Item("bodega", fila).Value))
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item(3, fila).Value))
            myCommand.Parameters.AddWithValue("?valor", DIN(Moneda2(gfactura.Item(4, fila).Value, lb_imp_dec.Text)))
            myCommand.Parameters.AddWithValue("?vtotal", DIN(Moneda2(gfactura.Item(5, fila).Value, lb_imp_dec.Text)))
            myCommand.Parameters.AddWithValue("?por_iva_g", DIN(gfactura.Item("iva", fila).Value))
            'descuento
            myCommand.Parameters.AddWithValue("?por_des", DIN(gfactura.Item("descuento", fila).Value))
            'cuentas y concepto
            myCommand.Parameters.AddWithValue("?cta_inv", gfactura.Item("ctainv", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", gfactura.Item("ctacven", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_gas", gfactura.Item("ctaing", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", gfactura.Item("ctaiva", fila).Value)
            myCommand.Parameters.AddWithValue("?concep", gfactura.Item("cc", fila).Value)
            'INSERTAR DETALLES
            myCommand.CommandText = "INSERT INTO detacomp" & PerActual(0) & PerActual(1) & " " _
                                  & " VALUES(?doc,?item,?tipo_it,?codart,?nom_art,?numbod,?cantidad,?valor,?vtotal,?por_iva_g,?por_des,?cta_inv,?cta_cos,?cta_gas,?cta_iva,?concep);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "GuardarDetalle")
        End Try
    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer)
        Try
            ct = 0
            ct = ct + 1
            If gfactura.Item("tipo", fila).Value = "G" Then Exit Sub
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(gfactura.Item("cant", fila).Value))
            If txttipo.Text <> lbdocajuste.Text Then
                'myCommand.CommandText = "UPDATE con_inv SET cant" & Trim(gfactura.Item("bodega", fila).Value) & "=cant" & Trim(gfactura.Item("bodega", fila).Value) & " + ?cantidad " _
                myCommand.CommandText = "UPDATE con_inv SET cant" & Trim(gfactura.Item("bodega", fila).Value) & "=cant" & Trim(gfactura.Item("bodega", fila).Value) & " + " & DIN(gfactura.Item("cant", fila).Value) & " " _
               & " WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.CommandText = "UPDATE con_inv SET cant" & Trim(gfactura.Item("bodega", fila).Value) & "=cant" & Trim(gfactura.Item("bodega", fila).Value) & " - ?cantidad " _
                              & " WHERE codart='" & gfactura.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "GuardarBodega")
            If ct = 1 Then
                GuardarEnBodega(fila)
            End If
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

            If txttipo.Text = lbdocajuste.Text Then Exit Sub
            Dim precio, costo As Double
            costo = CDbl(gfactura.Item(4, fila).Value)
            costo = costo / (1 + (gfactura.Item("iva", fila).Value / 100))
            If chcosto.Checked = True Then
                costo = costo - (costo * CDbl(valordes.Text) / 100)
            End If
            If f = "/" Then
                precio = costo / (1 - margen / 100)
            Else
                precio = costo * (1 + margen / 100)
            End If
            If f = "manual" Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
                myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni " _
                                    & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?cos_uni", DIN(costo))
                myCommand.Parameters.AddWithValue("?precio", DIN(precio))
                myCommand.CommandText = "UPDATE articulos SET cos_uni=?cos_uni,precio=?precio " _
                                    & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
                myCommand.ExecuteNonQuery()
            End If

            '9*****************
        Catch ex As Exception
            MsgBox(ex.ToString)
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "GuardarPrecios")
        End Try
    End Sub
    Public Sub Actualizar_Con_inv(ByVal fila As Integer, ByVal f As String, ByVal margen As Integer)
        Try
            ct = 0
            ct = ct + 1
            If txttipo.Text = lbdocajuste.Text Then Exit Sub
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
            myCommand.CommandText = "SELECT costprom,margen,precio1, periodo FROM con_inv WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo<='" & PerActual(0) & PerActual(1) & "' order by periodo;"
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
            costo = costo / (1 + (iva / 100))
            If chcosto.Checked = True Then
                costo = costo - (costo * CDbl(valordes.Text) / 100)
            End If
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
                precio = precio + (precio * iva / 100)
            ElseIf f = "manual" Then
                Try
                    margen = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("precio1")) 'precio1 del periodo actual porq es manual(el ultimo campo)
                Catch ex As Exception
                    margen = 0
                End Try
                precio = CDbl(tabla.Rows(tabla.Rows.Count - 1).Item("precio1"))
            Else
                precio = costo * (1 + (margen / 100))
                'precio = precio + (precio * iva / 100)
            End If
            If f = "manual" Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?cosuni", costo)
                myCommand.Parameters.AddWithValue("?costprom", costoprom)
                myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            Else
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?cosuni", costo)
                myCommand.Parameters.AddWithValue("?costprom", costoprom)
                myCommand.Parameters.AddWithValue("?precio", precio)
                myCommand.CommandText = "UPDATE con_inv SET costuni=?cosuni,costprom=?costprom,precio1=?precio " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
                myCommand.ExecuteNonQuery()
            End If
            Try
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?costprom", costoprom)
                myCommand.CommandText = "UPDATE articulos SET cos_pro=?costprom " _
                                     & " WHERE codart='" & gfactura.Item(1, fila).Value & "';"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception

            End Try
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "ActualizarConInv")
            If ct = 1 Then
                Actualizar_Con_inv(fila, f, margen)
            End If
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
        If tabla.Rows.Count = 0 Then
            MsgBox("Verifique los parametros para interfaz contable en Facturacion", MsgBoxStyle.Information, "Verificacion")
        End If
        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then 'HAY INTERFAZ CONTABLE
            Dim tdoc As String
            BuscarPeriodo()
            tdoc = "documentos" & PerActual(0) & PerActual(1)
            '************************************************
            For i = 0 To gfp.Rows.Count - 1
                grilla.RowCount = grilla.RowCount + 1
                MovimientoContable(0, "total", txtcuentatotal.Text, "VR. TOTAL " & gfp.Item("cual", i).Value & " " & Trim(txtcliente.Text))
            Next
            'grilla.RowCount = grilla.RowCount + 1
            'MovimientoContable(0, "total", txtcuentatotal.Text, "VR. TOTAL " & Trim(txtcliente.Text))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "desc", txtcuentadesc.Text, "DESCUENTO " & valordes.Text & "% " & Trim(txtcliente.Text))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "rtf", txtcuentaret.Text, "RETE FUENTE " & valorret.Text & "% " & Trim(txtcliente.Text))
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "fle", txtcuentaflete.Text, "FLETE ")
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "seg", txtcuentaseguro.Text, "SEGURO ")
            grilla.RowCount = grilla.RowCount + 1
            MovimientoContable(0, "rtc", txtcuentaCree.Text, "RETE CREE" & valorret.Text & "% " & Trim(txtcliente.Text))
            If cbsr.Items.Count > 0 Then
                For l = 0 To cbsr.Items.Count - 1
                    If Trim(cbsr.Items.Item(l).ToString) = "+" Then
                        grilla.RowCount = grilla.RowCount + 1
                        concep = l
                        MovimientoContable(l, "+", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l))
                    ElseIf Trim(cbsr.Items.Item(l).ToString) = "-" Then
                        grilla.RowCount = grilla.RowCount + 1
                        concep = l
                        MovimientoContable(l, "-", cbcuenta.Items.Item(l), cbconcepto.Items.Item(l))
                    End If
                Next
            End If
            'For i = 0 To 2
            '    Try
            '        If Trim(cbsr.Items.Item(i).ToString) = "+" Then
            '            grilla.RowCount = grilla.RowCount + 1
            '            concep = i
            '            MovimientoContable(i, "+", cbcuenta.Items.Item(i), cbconcepto.Items.Item(i))
            '        ElseIf Trim(cbsr.Items.Item(i).ToString) = "-" Then
            '            grilla.RowCount = grilla.RowCount + 1
            '            concep = i
            '            MovimientoContable(i, "-", cbcuenta.Items.Item(i), cbconcepto.Items.Item(i))
            '        End If
            '    Catch ex As Exception
            '    End Try
            'Next
            For i = 0 To gfactura.RowCount - 1
                If gfactura.Item("tipo", i).Value = "I" Then
                    If txtremision.Text = "" Then
                        MovimientoContable(i, "inv", gfactura.Item("ctainv", i).Value, "INVENTARIO " & gfactura.Item("descrip", i).Value)
                    End If
                    MovimientoContable(i, "iva", gfactura.Item("ctaiva", i).Value, "IVA " & gfactura.Item("iva", i).Value & "% " & Trim(txtcliente.Text))
                Else
                    MovimientoContable(i, "ing", gfactura.Item("ctaing", i).Value, gfactura.Item("descrip", i).Value)
                    MovimientoContable(i, "iva", gfactura.Item("ctaiva", i).Value, "IVA " & gfactura.Item("iva", i).Value & "% " & Trim(txtcliente.Text))
                End If
            Next i
            '********************************************************************
            Dim cad As String
            Dim db, cr As Double
            grilla.Sort(grilla.Columns("Debitos"), System.ComponentModel.ListSortDirection.Descending)
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
            myCommand.Parameters.AddWithValue("?nit", txtnitc.Text)
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
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "GuardarContable")
        End Try
    End Sub
    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String)
        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des As String
        Dim desc, b2, rtf As Double
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
                    base = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                Try
                    desc = base * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                monto = base - desc

                ' monto = base

                'Try
                '    iva = CDbl(gfactura.Item("Vtotal", fo).Value) - (CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100)))
                '    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                'Catch ex As Exception
                '    iva = 0
                'End Try
                'monto = CDbl(gfactura.Item("Vtotal", fo).Value) - iva
                Try
                    rtf = monto * CDec(valorret.Text) / 100
                    rtf = Format(Math.Round(CDbl(rtf), 2), "0.00")
                Catch ex As Exception
                    rtf = 0
                End Try
                'monto = CDbl(gfactura.Item("Vtotal", fo).Value) - iva
                'monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "iva"
                Try 'base sin descuento
                    b2 = CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100))
                Catch ex As Exception
                End Try
                '
                Try
                    desc = b2 * (CDbl(gfactura.Item("descuento", fo).Value) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                '
                Try
                    desc = b2 * (CDec(valordes.Text) / 100)
                Catch ex As Exception
                    desc = 0
                End Try
                b2 = b2 - desc
                Try
                    base = base + b2 'base acomulada + nueva base
                Catch ex As Exception
                End Try
                Try
                    'iva = CDbl(gfactura("Vtotal", fo).Value) * CDec(gfactura("iva", fo).Value) / 100
                    iva = b2 * (CDec(gfactura.Item("iva", fo).Value) / 100)
                    'iva = base * (CDec(gfactura.Item("iva", fo).Value) / 100)
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = iva
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
                    ' iva = CDbl(gfactura("Vtotal", fo).Value) * CDec(gfactura("iva", fo).Value) / 100
                    iva = CDbl(gfactura.Item("Vtotal", fo).Value) - (CDbl(gfactura.Item("Vtotal", fo).Value) / (1 + (CDec(gfactura.Item("iva", fo).Value) / 100)))
                    iva = Format(Math.Round(CDbl(iva), 2), "0.00")
                Catch ex As Exception
                    iva = 0
                End Try
                monto = CDbl(gfactura.Item("Vtotal", fo).Value) - iva
                monto = monto - ((monto * gfactura.Item("descuento", fo).Value) / 100)
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "cventa"
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
            Case "desc"
                monto = CDbl(txtdescuento.Text)
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
            Case "rtf"
                monto = Format(Math.Round(CDbl(txtret.Text), 2), "0.00")
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                grilla.Item("base", j).Value = base
            Case "rtc"
                monto = Format(Math.Round(CDbl(txtretCre.Text), 2), "0.00")
                Try
                    base = base + (CDbl(lbsubtotal.Text) - CDbl(txtiva.Text)) - (CDbl(lbsubtotal.Text) * CDbl(valordes.Text) / 100)
                Catch ex As Exception
                End Try
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                grilla.Item("base", j).Value = base
            Case "total"
                ' monto = CDbl(txttotal.Text)
                monto = gfp.Item("monto", j).Value
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                If gfp.Item("cual", j).Value = "Cheque" Then
                    grilla.Item("cheque", j).Value = gfp.Item("numero", j).Value
                Else
                    grilla.Item("cheque", j).Value = ""
                End If
            Case "fle"
                monto = CDbl(txtflete.Text)
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "seg"
                monto = CDbl(txtseguro.Text)
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
            Case "+"
                monto = CDbl(cbvalor.Items.Item(concep))
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                Else
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                End If
                Try
                    grilla.Item("base", j).Value = CDbl(grilla.Item("base", j).Value) + CDbl(cbbase.Items.Item(fo))
                Catch ex As Exception
                End Try
            Case "-"
                monto = CDbl(cbvalor.Items.Item(concep))
                If txttipo.Text <> lbdocajuste.Text Then
                    grilla.Item("Debitos", j).Value = db
                    grilla.Item("Creditos", j).Value = cr + monto
                Else
                    grilla.Item("Debitos", j).Value = db + monto
                    grilla.Item("Creditos", j).Value = cr
                End If
                Try
                    grilla.Item("base", j).Value = CDbl(grilla.Item("base", j).Value) + CDbl(cbbase.Items.Item(fo))
                Catch ex As Exception
                End Try
        End Select
    End Sub
    Public Sub GuardarCTA_X_PAGAR()
        Try
            If gfp.Item("cual", 0).Value <> "Otra" Then Exit Sub
            Dim cad As String = txtcuentatotal.Text
            If cad(0) <> "2" Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Las cuenta (" & txtcuentatotal.Text & ") no pertenece a Cuentas por Pagar, ¿Desea Generar un Documento De Cuentas por Pagar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.No Then Exit Sub
            End If
            ''''''''''''''''''GENERAR DOCUMENTOS DE CUENTAS POR PAGAR TABLA COBDPEN'''''''''''''''''''''''''''''''
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(txtnumfac.Text))
            myCommand.Parameters.AddWithValue("?doc_ext", txt_doc_afe.Text.ToString)
            myCommand.Parameters.AddWithValue("?descrip", "")
            myCommand.Parameters.AddWithValue("?tipafec", "")
            myCommand.Parameters.AddWithValue("?clasaju", "")
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.Parameters.AddWithValue("?nomnit", txtcliente.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitcod", "")
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text))
            'dias de vmto
            myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
            myCommand.Parameters.AddWithValue("?concepto", CambiaCadena(gfactura.Item("descrip", 0).Value, 99))
            'subtotal
            myCommand.Parameters.AddWithValue("?subtotal", DIN(txtsubtotal.Text))
            'descuento
            myCommand.Parameters.AddWithValue("?descto", DIN(txtdescuento.Text))
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
            'moneda
            myCommand.Parameters.AddWithValue("?moneda", "")
            myCommand.Parameters.AddWithValue("?monloex", "L")
            'estado
            myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
            myCommand.Parameters.AddWithValue("?salmov", "")
            myCommand.Parameters.AddWithValue("?pagare", "")
            'INSERTAR COBDPEN
            myCommand.CommandText = "INSERT INTO ctas_x_pagar VALUES (?doc,?tipo,?num,?doc_ext,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?fecha,?vmto," _
                                  & "?concepto,?subtotal,?descto,?ret,?iva,?v_iva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva,?ctaretiva,?retica," _
                                  & "?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            GuardarError(ex.ToString, "FAC_PROVEEDOR " & txttipo.Text & txtnumfac.Text, "GuardarCxP")
        End Try
    End Sub
    Public Sub GuardarMoviInvetarios(ByVal total As Double)
        Try
            ct = 0
            ct = ct + 1
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", txttipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", txtnumfac.Text.ToString)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtfecha.Value.Day.ToString)
            myCommand.Parameters.AddWithValue("?hora", lbhora.Text.ToString)
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            If txttipo.Text <> lbdocajuste.Text Then
                myCommand.Parameters.AddWithValue("?tipo_mov", "E")
                myCommand.Parameters.AddWithValue("?tipo", "ENTRADA")
                myCommand.Parameters.AddWithValue("?tipo_sal", "ENTRADA POR COMPRA")
            Else
                myCommand.Parameters.AddWithValue("?tipo_mov", "S")
                myCommand.Parameters.AddWithValue("?tipo", "SALIDA")
                myCommand.Parameters.AddWithValue("?tipo_sal", "SALIDA POR COMPRA")
            End If
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
                    If gfactura.Item(1, i).Value <> "" And gfactura.Item("tipo", i).Value = "I" Then
                        GuardarDetallesInv(i)
                    End If
                Catch ex As Exception
                    GuardarError(ex.ToString, "FAC_PROVEEDOR-" & txttipo.Text & txtnumfac.Text, "GuardarMovInv - " & i)
                End Try
            Next
        Catch ex As Exception
            GuardarError(ex.ToString, "FAC_PROVEEDOR-" & txttipo.Text & txtnumfac.Text, "GuardarMovInv")
            If ct = 1 Then
                GuardarMoviInvetarios(total)
            End If
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarDetallesInv(ByVal fila As Integer)
        Try
            ct = 0
            ct = ct + 1
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", txttipo.Text & txtnumfac.Text)
            myCommand.Parameters.AddWithValue("?item", gfactura.Item(0, fila).Value)
            myCommand.Parameters.AddWithValue("?codart", gfactura.Item("codigo", fila).Value)
            myCommand.Parameters.AddWithValue("?nomart", gfactura.Item("descrip", fila).Value)
            myCommand.Parameters.AddWithValue("?bod_ori", "0")
            Try
                myCommand.Parameters.AddWithValue("?bod_des", Val(gfactura.Item("bodega", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?bod_des", "0")
            End Try
            'myCommand.Parameters.AddWithValue("?bod_des", "0")
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
            Dim costo As Double = 0
            Try
                costo = CDbl(gfactura.Item("valor", fila).Value) / (1 + (CDbl(gfactura.Item("iva", fila).Value) / 100))
            Catch ex As Exception
                Try
                    costo = CDbl(gfactura.Item("valor", fila).Value)
                Catch ex2 As Exception
                End Try
            End Try
            Try
                myCommand.Parameters.AddWithValue("?costo", DIN(Moneda2(costo, lb_imp_dec.Text)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
            & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            GuardarError(ex.ToString, "FAC_PROVEEDOR - " & txttipo.Text & txtnumfac.Text, "GuardarDetalleInv - " & fila)
            If ct = 1 Then
                GuardarDetallesInv(fila)
            End If
        End Try
    End Sub
    Public Sub ValidarConsecutivo()
        Try
            ActualizarConsecutivo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarConsecutivo()
        Dim tabla As New DataTable
        Dim c As String = "actualfc"
        myCommand.CommandText = "SELECT " & c & " FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        Try
            If Val(tabla.Rows(0).Item(0).ToString) < Val(txtnumfac.Text) Then
                myCommand.CommandText = "UPDATE tipdoc SET " & c & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Try
                myCommand.CommandText = "UPDATE tipdoc SET " & c & "=" & Val(txtnumfac.Text) & " WHERE tipodoc='" & txttipo.Text & "';"
                myCommand.ExecuteNonQuery()
            Catch ex2 As Exception
                MsgBox(ex.ToString)
            End Try
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
        ElseIf txtdescuento.Text <> "0,00" And txtcuentadesc.Text = "" And txtcuentadesc.Enabled = True Then
            MsgBox("No ha escojido cuenta para los descuentos, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentadesc.Focus()
            Exit Sub
        ElseIf txtflete.Text <> "0,00" And txtcuentaflete.Text = "" And txtcuentaflete.Enabled = True Then
            MsgBox("No ha escojido cuenta para los fletes, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaflete.Focus()
            Exit Sub
        ElseIf txtseguro.Text <> "0,00" And txtcuentaseguro.Text = "" And txtcuentaseguro.Enabled = True Then
            MsgBox("No ha escojido cuenta para el seguro, Verifique.  ", MsgBoxStyle.Information, "Editar Factura ")
            txtcuentaseguro.Focus()
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
            cmdfpago_Click(AcceptButton, AcceptButton)
            Exit Sub
        End If
        If PerActual <> Format(txtfecha.Value, "MM/yyyy") Then
            MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
            If txtfecha.Enabled = True Then
                txtfecha.Focus()
            End If
            Exit Sub
        End If
        If Trim(txt_doc_afe.Text) = "" Then
            Dim rdoc As MsgBoxResult
            rdoc = MsgBox("No ha digitado documento externo, ¿Desea Digitarlo? ", MsgBoxStyle.YesNo, "Verificando")
            If rdoc = MsgBoxResult.Yes Then
                txt_doc_afe.Focus()
                Exit Sub
            End If
        End If
        '''''' VALIDAR SI EXIXTE FACTURA PARA CREAR O MODIFICAR'''''''''''''''''
        Dim t As New DataTable
        myCommand.CommandText = "SELECT doc FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        Refresh()
        If t.Rows.Count < 1 Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("La factura (" & txttipo.Text & txtnumfac.Text & ") No Existe en los registros, ¿Desea Guardarla?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                validarcuentasFP()
                GuardarFactura()
            End If
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la factura (" & txttipo.Text & txtnumfac.Text & ") se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                validarcuentasFP()
                ModificarFactura()
            End If
        End If
    End Sub
    Public Sub ModificarFactura()
        '//////////////////////////////////////////////////////
        Dim afecta, doc_de As String
        txtsubtotal.Text = CDbl(txttotal.Text) + CDbl(txtdescuento.Text)
        If rbafecta1.Checked = True Then
            afecta = "SI"  'SI afecta inventario
        Else
            afecta = "NO"  'NO afecta inventario
        End If
        If rbdocde1.Checked = True Then
            doc_de = "I"  'doc inventario
        Else
            doc_de = "G"  'doc gastos
        End If
        Timer1.Enabled = False
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc_de", doc_de)
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
        myCommand.Parameters.AddWithValue("?usuario", lbusuario.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha.Text))
        myCommand.Parameters.AddWithValue("?hora", CDate(lbhora.Text))
        myCommand.Parameters.AddWithValue("?anulado", "no")
        myCommand.Parameters.AddWithValue("?doc_afec", txt_doc_afe.Text)
        myCommand.Parameters.AddWithValue("?afecta", afecta)
        'subtotal
        myCommand.Parameters.AddWithValue("?subtotal", DIN(Moneda2(txtsubtotal.Text, lb_imp_dec.Text)))
        'descuento
        myCommand.Parameters.AddWithValue("?por_desc", DIN(valordes.Text))
        myCommand.Parameters.AddWithValue("?descuento", DIN(Moneda2(txtdescuento.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_desc", txtcuentadesc.Text)
        'rete_fuente
        myCommand.Parameters.AddWithValue("?por_rtf", DIN(valorret.Text))
        myCommand.Parameters.AddWithValue("?rtf", DIN(Moneda2(txtret.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_rtf", txtcuentaret.Text)
        'rete_Cree
        myCommand.Parameters.AddWithValue("?por_rtc", DIN(valorretCree.Text))
        myCommand.Parameters.AddWithValue("?rtc", DIN(Moneda2(txtretCre.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_rtc", txtcuentaCree.Text)
        'iva
        myCommand.Parameters.AddWithValue("?por_iva", DIN(valoriva.Text))
        myCommand.Parameters.AddWithValue("?iva", DIN(Moneda2(txtiva.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_iva", txtcuentaiva.Text)
        'fletes
        myCommand.Parameters.AddWithValue("?fle", DIN(Moneda2(txtflete.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_fle", txtcuentaflete.Text)
        'seguros
        myCommand.Parameters.AddWithValue("?seg", DIN(Moneda2(txtseguro.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_seg", txtcuentaseguro.Text)
        'total
        myCommand.Parameters.AddWithValue("?total", DIN(Moneda2(txttotal.Text, lb_imp_dec.Text)))
        myCommand.Parameters.AddWithValue("?cta_total", txtcuentatotal.Text)
        'aprobada
        myCommand.Parameters.AddWithValue("?estado", cbaprobado.Text)
        'observaciones
        myCommand.Parameters.AddWithValue("?observ", txtobserbaciones.Text)
        'dias de vmto
        myCommand.Parameters.AddWithValue("?vmto", Val(txtvmto.Text))
        'centro de costo
        myCommand.Parameters.AddWithValue("?ctoc", Val(txtcentrocosto.Text))
        ' VALOR AAF
        If (txttipo.Text = lbdocajuste.Text) And (txt_doc_afe.Text <> "") And (gfp.Item("detalle", 0).Value.ToString = "CREDITO") Then
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
        '*************** INICIO FORMA DE PAGO *************************************
        If gfp.Item("cual", 0).Value.ToString = "Efectivo" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", " ")
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        ElseIf gfp.Item("cual", 0).Value.ToString = "Cheque" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", gfp.Item("numero", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?banco", gfp.Item("banco", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        ElseIf gfp.Item("cual", 0).Value.ToString = "Tarjeta" Then
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", gfp.Item("banco", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?tip_tarj", gfp.Item("tt", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_tarj", gfp.Item("numero", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?desc_otra", " ")
        Else 'OTRA CREDITO
            myCommand.Parameters.AddWithValue("?fpago", gfp.Item("cual", 0).Value.ToString)
            myCommand.Parameters.AddWithValue("?num_ch", " ")
            myCommand.Parameters.AddWithValue("?banco", " ")
            myCommand.Parameters.AddWithValue("?tip_tarj", " ")
            myCommand.Parameters.AddWithValue("?num_tarj", " ")
            myCommand.Parameters.AddWithValue("?desc_otra", gfp.Item("detalle", 0).Value.ToString)
        End If
        '*************** FIN FORMA DE PAGO *************************************
        ' ''otros conceptos
        ''For i = 0 To 2
        ''    If i = 0 Then
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?o_con", "si")
        ''                myCommand.Parameters.AddWithValue("?t1", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d1", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v1", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b1", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta1", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc1", lbanti1.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?o_con", "no")
        ''                myCommand.Parameters.AddWithValue("?t1", "")
        ''                myCommand.Parameters.AddWithValue("?d1", "")
        ''                myCommand.Parameters.AddWithValue("?v1", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b1", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta1", "")
        ''                myCommand.Parameters.AddWithValue("?doc1", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?o_con", "no")
        ''            myCommand.Parameters.AddWithValue("?t1", "")
        ''            myCommand.Parameters.AddWithValue("?d1", "")
        ''            myCommand.Parameters.AddWithValue("?v1", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b1", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta1", "")
        ''            myCommand.Parameters.AddWithValue("?doc1", "")
        ''        End Try
        ''    ElseIf i = 1 Then
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?t2", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d2", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v2", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b2", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta2", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc2", lbanti2.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?t2", "")
        ''                myCommand.Parameters.AddWithValue("?d2", "")
        ''                myCommand.Parameters.AddWithValue("?v2", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b2", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta2", "")
        ''                myCommand.Parameters.AddWithValue("?doc2", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?t2", "")
        ''            myCommand.Parameters.AddWithValue("?d2", "")
        ''            myCommand.Parameters.AddWithValue("?v2", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b2", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta2", "")
        ''            myCommand.Parameters.AddWithValue("?doc2", "")
        ''        End Try
        ''    Else
        ''        Try
        ''            If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        ''                myCommand.Parameters.AddWithValue("?t3", cbsr.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?d3", CambiaCadena(cbconcepto.Items.Item(i), 99))
        ''                myCommand.Parameters.AddWithValue("?v3", DIN(Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?b3", DIN(Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)))
        ''                myCommand.Parameters.AddWithValue("?cta3", cbcuenta.Items.Item(i))
        ''                myCommand.Parameters.AddWithValue("?doc3", lbanti3.Text)
        ''            Else
        ''                myCommand.Parameters.AddWithValue("?t3", "")
        ''                myCommand.Parameters.AddWithValue("?d3", "")
        ''                myCommand.Parameters.AddWithValue("?v3", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?b3", DIN(0))
        ''                myCommand.Parameters.AddWithValue("?cta3", "")
        ''                myCommand.Parameters.AddWithValue("?doc3", "")
        ''            End If
        ''        Catch ex As Exception
        ''            myCommand.Parameters.AddWithValue("?t3", "")
        ''            myCommand.Parameters.AddWithValue("?d3", "")
        ''            myCommand.Parameters.AddWithValue("?v3", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?b3", DIN(0))
        ''            myCommand.Parameters.AddWithValue("?cta3", "")
        ''            myCommand.Parameters.AddWithValue("?doc3", "")
        ''        End Try
        ''    End If
        ''Next
        'EDITAR FACTURA
        myCommand.CommandText = "UPDATE fact_comp" & PerActual(0) & PerActual(1) & " SET doc_de=?doc_de,nitc=?nitc,usuario=?usuario,fecha=?fecha,hora=?hora,anulado=?anulado,doc_afec=?doc_afec,afecta=?afecta," _
                              & "subtotal=?subtotal,por_desc=?por_desc,descuento=?descuento,cta_desc=?cta_desc,por_rtf=?por_rtf,rtf=?rtf,cta_rtf=?cta_rtf,por_iva=?por_iva,iva=?iva,cta_iva=?cta_iva," _
                              & "fle=?fle,cta_fle=?cta_fle,seg=?seg,cta_seg=?cta_seg," _
                              & "total=?total,cta_total=?cta_total,estado=?estado,observ=?observ,vmto=?vmto,ctoc=?ctoc, " _
                              & "fpago=?fpago,num_ch=?num_ch,banco=?banco,tip_tarj=?tip_tarj,num_tarj=?num_tarj,desc_otra=?desc_otra," _
                              & "o_con=?o_con,t1=?t1,d1=?d1,v1=?v1,cta1=?cta1,t2=?t2,d2=?d2,v2=?v2,cta2=?cta2,t3=?t3,d3=?d3,v3=?v3,cta3=?cta3," _
                              & "b1=?b1,b2=?b2,b3=?b3, " _
                              & "doc1=?doc1,doc2=?doc2,doc3=?doc3,valor_aj=?val_aj, por_rtc=?por_rtc, rtc=?rtc, cta_rtc=?cta_rtc WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        If cbsr.Items.Count <> 0 Then
            GuardarOtrosConcep()
        End If
        Dim formula As String = "manual"
        Dim margen As Double = 0
        Try
            '*********************************************
            Dim t As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT formula,porcen FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            formula = t.Rows(0).Item("formula")
            margen = t.Rows(0).Item("porcen")
            '*********************************************
        Catch ex As Exception

        End Try
        '///////////////////////////////////////////////////////////////
        Insertar("DELETE FROM detacomp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';")
        Dim sw As Integer = 0
        Dim total_inv, subt As Double
        total_inv = 0
        For i = 0 To gfactura.RowCount - 1
            If gfactura.Item("codigo", i).Value <> "" Then
                GuardarDetalles(i)
                If rbafecta1.Checked = True And cbaprobado.Text = "AP" Then 'AFECTA INVENTARIOS
                    If gfactura.Item("tipo", i).Value = "I" Then ' hay movimientos de inventarios
                        GuardarEnBodega(i)
                        Actualizar_Con_inv(i, formula, margen)
                        If formula <> "manual" Then GuardarPrecios(i, formula, margen)
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
        If cbaprobado.Text = "AP" Then 'documentio contable
            GuardarContable()
            GuardarCTA_X_PAGAR() 'CUENTAS POR PAGAR
            If sw = 1 And rbafecta1.Checked = True Then GuardarMoviInvetarios(total_inv) 'si hay movi de inventarios y si afecta inventarios
        End If
        bloquear()
        '.....
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("COMPRAS", "MODIFICAR FACTURA Nº: " & txttipo.Text & txtnumfac.Text, "", "", "")
        End If
        '.....
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        Refresh()
        CalcularTotales()
        DBCon.Close()
        lbestado.Text = "EDITADO"
        cmditems.Enabled = False
        cbaprobado.Enabled = False
    End Sub
    '***************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
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
            Dim valor, vtotal As Double
            myCommand.CommandText = "SELECT * FROM detacomp" & PerActual(0) & PerActual(1) & " WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' ORDER BY item;"
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
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cod_art"), 40, k, 0)
                'cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart"), 25), 120, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("cantidad"), 350, k, 0)
                Try
                    valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text) / (1 + (CDec(tabla.Rows(i).Item("por_iva_g")) / 100))
                    valor = valor - (valor * ((CDec(tabla.Rows(i).Item("por_des")) / 100)))
                Catch ex As Exception
                    valor = Moneda2(tabla.Rows(i).Item("valor"), lb_imp_dec.Text)
                    valor = valor - (valor * ((CDec(tabla.Rows(i).Item("por_des")) / 100)))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(valor, lb_imp_dec.Text), 485, k, 0)
                Try
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text) / (1 + (CDec(tabla.Rows(i).Item("por_iva_g")) / 100))
                    vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                Catch ex As Exception
                    vtotal = Moneda2(tabla.Rows(i).Item("vtotal"), lb_imp_dec.Text)
                    vtotal = vtotal - (vtotal * (CDbl(tabla.Rows(i).Item("por_des")) / 100))
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(vtotal, lb_imp_dec.Text), 585, k, 0)
                'CONTROL SALTO DE LINEA PARA NOMBRE O DESCRIPCION DEL ARTICULO
                Control_de_linea(tabla.Rows(i).Item("nom_art").ToString, 120, 38)
            Next
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 20
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtsubtotal.Text, lb_imp_dec.Text), 585, k, 0)
            If CDec(valordes.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESC. " & valordes.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtdescuento.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            If CDec(valorret.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE. FUENTE " & valorret.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtret.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            If CDec(valorretCree.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETE. CREE " & valorretCree.Text & "%", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "-" & Moneda2(txtretCre.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            If CDbl(txtiva.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA ", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtiva.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            If CDbl(txtflete.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "FLETE ", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtflete.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            If CDbl(txtseguro.Text) <> 0 Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SEGURO ", 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda2(txtseguro.Text, lb_imp_dec.Text), 585, k, 0)
            End If
            '/////////////////

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
            '*****************¿ANULADO?******************************************
            'Try
            '    Dim tana As New DataTable
            '    myCommand.CommandText = "SELECT anulado FROM fact_comp" & PerActual(0) & PerActual(1) & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            '    myAdapter.SelectCommand = myCommand
            '    myAdapter.Fill(tana)
            '    If Trim(tana.Rows(0).Item(0)) <> "" And Trim(tana.Rows(0).Item(0)) <> "no" Then
            '        Control_de_linea(tana.Rows(0).Item(0), 10, 125)
            '        k = k - 10
            '    End If
            'Catch ex As Exception
            'End Try
            '*****************COMENTARIO******************************************
            Try
                Dim tcom As New DataTable
                myCommand.CommandText = "SELECT comentario FROM par_comp;"
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
        k = 815
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "   " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        k = k - 25
        cb.ShowTextAligned(50, txttipo2.Text & " No. " & txtnumfac.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "DOC. EXTERNO/ANULADO " & txt_doc_afe.Text, 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "FECHA: " & txtfecha.Text, 20, k, 0)
        If Val(txtvmto.Text) > 0 Then
            k = k - 10
            cb.ShowTextAligned(50, "FECHA DE VENCIMIENTO: " & txtfecha.Value.AddDays(Val(txtvmto.Text)), 20, k, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "PROVEEDOR: ", 20, k, 0)
        Control_de_linea(Trim(txtcliente.Text), 83, 45)
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: " & txtnitc.Text, 20, k, 0)
        '**********************************************************************************************************************
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        '******************************************************** DIAN **************************************************************
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PAGINA: " & pag, 585, k + 25, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 40, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 350, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR UNITARIO", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
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
    Public Sub GenerarPDF2()

    End Sub
    Public Sub GenerarTicket()

    End Sub

    Private Sub cmdConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConceptos.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            FrmOtrosConceptosProv.g_concep.Enabled = True
            FrmOtrosConceptosProv.grilla.Enabled = True
            FrmOtrosConceptosProv.grilla.RowCount = 3
        Else
            FrmOtrosConceptosProv.g_concep.Enabled = False
            FrmOtrosConceptosProv.grilla.Enabled = False
        End If

        Try
            FrmOtrosConceptosProv.grilla.Rows.Clear()
            FrmOtrosConceptosProv.grilla.RowCount = cbsr.Items.Count + 2
            For j = 0 To cbsr.Items.Count - 1
                If Trim(cbsr.Items.Item(j).ToString) <> "" Then
                    FrmOtrosConceptosProv.grilla.Item("sel", j).Value = True
                    FrmOtrosConceptosProv.grilla.Item("tipo", j).Value = cbsr.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("txt", j).Value = cbconcepto.Items.Item(j)
                    FrmOtrosConceptosProv.grilla.Item("valor", j).Value = Moneda2(cbvalor.Items.Item(j), lb_imp_dec.Text)
                    FrmOtrosConceptosProv.grilla.Item("base", j).Value = Moneda2(cbbase.Items.Item(j), lb_imp_dec.Text)
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

        'Try
        '    For i = 0 To 2
        '        If i = 0 Then
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptosProv.Ch1.Checked = False
        '                    FrmOtrosConceptosProv.Ch1.Checked = True
        '                    FrmOtrosConceptosProv.cb1.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptosProv.txt1.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptosProv.valor1.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.base1.Text = Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.cta1.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptosProv.lbdoc1.Text = lbanti1.Text
        '                Else
        '                    FrmOtrosConceptosProv.Ch1.Checked = True
        '                    FrmOtrosConceptosProv.Ch1.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptosProv.Ch1.Checked = True
        '                FrmOtrosConceptosProv.Ch1.Checked = False
        '            End Try
        '        ElseIf i = 1 Then
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptosProv.Ch2.Checked = False
        '                    FrmOtrosConceptosProv.Ch2.Checked = True
        '                    FrmOtrosConceptosProv.cb2.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptosProv.txt2.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptosProv.valor2.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.base2.Text = Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.cta2.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptosProv.lbdoc2.Text = lbanti2.Text
        '                Else
        '                    FrmOtrosConceptosProv.Ch2.Checked = True
        '                    FrmOtrosConceptosProv.Ch2.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptosProv.Ch2.Checked = True
        '                FrmOtrosConceptosProv.Ch2.Checked = False
        '            End Try
        '        Else
        '            Try
        '                If Trim(cbsr.Items.Item(i).ToString) <> "" Then
        '                    FrmOtrosConceptosProv.Ch3.Checked = False
        '                    FrmOtrosConceptosProv.Ch3.Checked = True
        '                    FrmOtrosConceptosProv.cb3.Text = cbsr.Items.Item(i)
        '                    FrmOtrosConceptosProv.txt3.Text = cbconcepto.Items.Item(i)
        '                    FrmOtrosConceptosProv.valor3.Text = Moneda2(cbvalor.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.base3.Text = Moneda2(cbbase.Items.Item(i), lb_imp_dec.Text)
        '                    FrmOtrosConceptosProv.cta3.Text = cbcuenta.Items.Item(i)
        '                    FrmOtrosConceptosProv.lbdoc3.Text = lbanti3.Text
        '                Else
        '                    FrmOtrosConceptosProv.Ch3.Checked = True
        '                    FrmOtrosConceptosProv.Ch3.Checked = False
        '                End If
        '            Catch ex As Exception
        '                FrmOtrosConceptosProv.Ch3.Checked = True
        '                FrmOtrosConceptosProv.Ch3.Checked = False
        '            End Try
        '        End If
        '    Next
        'Catch ex As Exception
        'End Try
        FrmOtrosConceptosProv.lbform.Text = "fdp"
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
    '***********************************************
    Private Sub txtflete_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtflete.KeyPress
        ValidarMoneda(txtflete, e)
    End Sub
    Private Sub txtflete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtflete.LostFocus
        CalcularTotales()
    End Sub
    Private Sub txtseguro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtseguro.KeyPress
        ValidarMoneda(txtseguro, e)
    End Sub
    Private Sub txtseguro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtseguro.LostFocus
        CalcularTotales()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim prov As String = ""
        Dim doc As String = ""
        Dim docD As String = ""
        Dim AfI As String = ""
        Dim fecha As String = ""
        Dim estado As String = ""
        Dim letraT As String = ""
        Dim subt As String = ""
        Dim des As String = ""
        Dim ret As String = ""
        Dim flet As String = ""
        Dim seg As String = ""
        Dim tot As String = ""
        Dim cdes As String = ""
        Dim cret As String = ""
        Dim cflet As String = ""
        Dim cseg As String = ""
        Dim ctot As String = ""

        p = PerActual(0).ToString & PerActual(1).ToString
        prov = txtnitc.Text & " - " & txtcliente.Text
        doc = txttipo.Text & "  " & txttipo2.Text & "  " & txtnumfac.Text
        fecha = txtfecha.Text
        letraT = Num2Text(Moneda2(txttotal.Text, lb_imp_dec.Text))

        subt = txtsubtotal.Text
        des = txtdescuento.Text
        ret = txtret.Text
        flet = txtflete.Text
        seg = txtseguro.Text
        tot = txttotal.Text
        cdes = txtcuentadesc.Text
        cret = txtcuentaret.Text
        cflet = txtcuentaflete.Text
        cseg = txtcuentaseguro.Text
        ctot = txtcuentatotal.Text

        If cbaprobado.Text = "AP" Then
            estado = "APROBADO"
        Else
            estado = ""
        End If

        If rbdocde1.Checked = True Then
            docD = rbdocde1.Text
        Else
            docD = rbdocde2.Text
        End If

        If rbafecta1.Checked = True Then
            AfI = rbafecta1.Text
        Else
            AfI = rbafecta2.Text
        End If

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item(1)
        nit = tabla2.Rows(0).Item("nit")
        '------------------------------------------
        Dim sql4 As String = ""
        Dim fpago As String = ""
        Dim fv As String = ""

        sql4 = " SELECT  CONCAT(f.fpago,', ', f.desc_otra) as Fpag, " _
       & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 2 ) ,  '/', " _
       & " MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 6, 2 ) ,  '/',  " _
       & " LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY )  FROM fact_comp" & p & " f  WHERE  f.doc =  '" & txttipo.Text & txtnumfac.Text & "' ), 4 ) ) ) AS CHAR( 20 ) ) AS fechaV " _
       & " FROM fact_comp" & p & " f WHERE doc = '" & txttipo.Text & txtnumfac.Text & "' "

        Dim tabla5 As New DataTable
        tabla5 = New DataTable
        myCommand.CommandText = sql4
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla5)
        For i = 0 To tabla5.Rows.Count - 1
            fpago = tabla5.Rows(i).Item("Fpag").ToString
            fv = tabla5.Rows(i).Item("fechaV").ToString
        Next
        '---------------------------------------------
        Dim sql3 As String = ""
        Dim otro As String = ""
        Dim c_otro As String = ""
        Dim t_otro As String = ""
        sql3 = " SELECT f.o_con,f.t1, f.d1, f.v1, f.cta1, f.t2,f.d2,f.v2,f.cta2,f.t3,f.d3,f.v3, f.cta3 FROM fact_comp" & p & " f WHERE f.doc= '" & txttipo.Text & txtnumfac.Text & "' "
        Dim tabla4 As New DataTable
        tabla4 = New DataTable
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla4)

        For i = 0 To tabla4.Rows.Count - 1
            If (tabla4.Rows(i).Item("o_con").ToString) = "si" Then
                If (tabla4.Rows(i).Item("t1").ToString) <> "" Then
                    t_otro = t_otro & (tabla4.Rows(i).Item("d1").ToString) & vbCrLf
                    otro = otro & (tabla4.Rows(i).Item("t1").ToString) & (tabla4.Rows(i).Item("v1").ToString) & vbCrLf
                    c_otro = c_otro & (tabla4.Rows(i).Item("cta1").ToString) & vbCrLf
                End If
                If (tabla4.Rows(i).Item("t2").ToString) <> "" Then
                    t_otro = t_otro & (tabla4.Rows(i).Item("d2").ToString) & vbCrLf
                    otro = otro & (tabla4.Rows(i).Item("t2").ToString) & (tabla4.Rows(i).Item("v2").ToString) & vbCrLf
                    c_otro = c_otro & (tabla4.Rows(i).Item("cta2").ToString) & vbCrLf
                End If
                If (tabla4.Rows(i).Item("t3").ToString) <> "" Then
                    t_otro = t_otro & (tabla4.Rows(i).Item("d3").ToString) & vbCrLf
                    otro = otro & (tabla4.Rows(i).Item("t3").ToString) & (tabla4.Rows(i).Item("v3").ToString) & vbCrLf
                    c_otro = c_otro & (tabla4.Rows(i).Item("cta3").ToString) & vbCrLf
                End If
            Else
                t_otro = ""
                otro = ""
                c_otro = ""
            End If
        Next
        '----------------------------------------------
        Dim sql2 As String = ""
        Dim v_iva As String = ""
        Dim tv_iva As String = ""
        Dim c_iva As String = ""
        sql2 = " SELECT d.por_iva_g , SUM(( (((d.vtotal/(1+(d.por_iva_g /100))))-(((d.vtotal/(1+(d.por_iva_g /100)))) * (f.por_desc /100)))*(d.por_iva_g/100)) )as IVA,  f.cta_iva FROM detacomp" & p & " d, fact_comp" & p & " f WHERE d.doc='" & txttipo.Text & txtnumfac.Text & "' GROUP BY d.por_iva_g "

        Dim tabla3 As New DataTable
        tabla3 = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla3)

        If txtiva.Text <> 0 Then
            For i = 0 To tabla3.Rows.Count - 1
                If (tabla3.Rows(i).Item(0).ToString) <> 0 Then
                    v_iva = v_iva & Moneda2(tabla3.Rows(i).Item(1).ToString, lb_imp_dec.Text) & vbCrLf
                    tv_iva = tv_iva & "IVA " & (tabla3.Rows(i).Item(0).ToString) & " %" & vbCrLf
                    c_iva = c_iva & (tabla3.Rows(i).Item(2).ToString) & vbCrLf
                End If
            Next
        Else
            v_iva = "0.00"
            tv_iva = "IVA "
            c_iva = ""
        End If
        '---------------------------------
        sql = " select d.doc, d.item , d.cod_art, d.nom_art as nomart,  d.num_bod as numbod, d.cantidad, (d.valor / ( 1 + ( d.por_iva_g /100 ) )) AS valor, " _
           & " f.por_desc as iva_d, (((d.valor / ( 1 + ( d.por_iva_g /100 ) )) - f.por_desc) * d.cantidad ) as vtotal, " _
           & " d.cta_inv, d.cta_gas as costo, d.cta_cos from detacomp" & p & " d, fact_comp" & p & " f where d.doc =  '" & txttipo.Text & txtnumfac.Text & "'  and  f.doc = d.doc "

        TextBox1.Text = sql

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportDocP.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportDocP.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField

            Dim Prpr As New ParameterField
            Dim Prdoc As New ParameterField
            Dim Prdocd As New ParameterField
            Dim PrAF As New ParameterField
            Dim Prfec As New ParameterField
            Dim PrEst As New ParameterField
            Dim PrtotalL As New ParameterField

            Dim Prsub As New ParameterField
            Dim Prdes As New ParameterField
            Dim Prrt As New ParameterField
            Dim Prft As New ParameterField
            Dim Prsg As New ParameterField
            Dim Prdesc As New ParameterField
            Dim Prrtc As New ParameterField
            Dim Prftc As New ParameterField
            Dim Prsgc As New ParameterField
            Dim Prtt As New ParameterField
            Dim Prttc As New ParameterField

            Dim Prfpago As New ParameterField
            Dim Prfv As New ParameterField
            Dim Priv As New ParameterField
            Dim Prv_iv As New ParameterField
            Dim Prc_iv As New ParameterField
            Dim PrO As New ParameterField
            Dim PrOt As New ParameterField
            Dim PrOc As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prpr.Name = "prov"
            Prpr.CurrentValues.AddValue(prov.ToString)
            Prdoc.Name = "doc"
            Prdoc.CurrentValues.AddValue(doc.ToString)
            Prdocd.Name = "docde"
            Prdocd.CurrentValues.AddValue(docD.ToString)
            PrAF.Name = "afI"
            PrAF.CurrentValues.AddValue(AfI.ToString)
            Prfec.Name = "fech"
            Prfec.CurrentValues.AddValue(fecha.ToString)
            PrEst.Name = "estado"
            PrEst.CurrentValues.AddValue(estado.ToString)
            PrtotalL.Name = "Ltotal"
            PrtotalL.CurrentValues.AddValue(letraT.ToString)

            Prsub.Name = "sub"
            Prsub.CurrentValues.AddValue(subt.ToString)
            Prdes.Name = "des"
            Prdes.CurrentValues.AddValue(des.ToString)
            Prdesc.Name = "cdes"
            Prdesc.CurrentValues.AddValue(cdes.ToString)
            Prrt.Name = "ret"
            Prrt.CurrentValues.AddValue(ret.ToString)
            Prrtc.Name = "cret"
            Prrtc.CurrentValues.AddValue(cret.ToString)
            Prft.Name = "flt"
            Prft.CurrentValues.AddValue(flet.ToString)
            Prftc.Name = "cflt"
            Prftc.CurrentValues.AddValue(cflet.ToString)
            Prsg.Name = "seg"
            Prsg.CurrentValues.AddValue(seg.ToString)
            Prsgc.Name = "cseg"
            Prsgc.CurrentValues.AddValue(cseg.ToString)
            Prtt.Name = "tt"
            Prtt.CurrentValues.AddValue(tot.ToString)
            Prttc.Name = "ctt"
            Prttc.CurrentValues.AddValue(ctot.ToString)

            Prfpago.Name = "fpag"
            Prfpago.CurrentValues.AddValue(fpago.ToString)
            Prfv.Name = "fechV"
            Prfv.CurrentValues.AddValue(fv.ToString)
            Priv.Name = "iva"
            Priv.CurrentValues.AddValue(tv_iva.ToString)
            Prv_iv.Name = "v_iva"
            Prv_iv.CurrentValues.AddValue(v_iva.ToString)
            Prc_iv.Name = "c_iva"
            Prc_iv.CurrentValues.AddValue(c_iva.ToString)

            PrO.Name = "otro"
            PrO.CurrentValues.AddValue(otro.ToString)
            PrOt.Name = "t_otro"
            PrOt.CurrentValues.AddValue(t_otro.ToString)
            PrOc.Name = "c_otro"
            PrOc.CurrentValues.AddValue(c_otro.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prpr)
            prmdatos.Add(Prdoc)
            prmdatos.Add(Prdocd)
            prmdatos.Add(PrAF)
            prmdatos.Add(Prfec)
            prmdatos.Add(PrEst)
            prmdatos.Add(PrtotalL)
            prmdatos.Add(Prsub)
            prmdatos.Add(Prdes)
            prmdatos.Add(Prdesc)
            prmdatos.Add(Prrt)
            prmdatos.Add(Prrtc)
            prmdatos.Add(Prft)
            prmdatos.Add(Prftc)
            prmdatos.Add(Prsg)
            prmdatos.Add(Prsgc)
            prmdatos.Add(Prtt)
            prmdatos.Add(Prttc)
            prmdatos.Add(Prfpago)
            prmdatos.Add(Prfv)
            prmdatos.Add(Priv)
            prmdatos.Add(Prv_iv)
            prmdatos.Add(Prc_iv)
            prmdatos.Add(PrO)
            prmdatos.Add(PrOt)
            prmdatos.Add(PrOc)

            FrmReportDocP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportDocP.ShowDialog()

        Catch ex As Exception
            MsgBox(sql)
        End Try

    End Sub

    Private Sub cmdRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemision.Click
        If lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        FrmSelRemiProv.ShowDialog()

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
                FrmSelCentroCostos.lbform.Text = "FactProv"
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

    Private Sub cmdNuevoAF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevoAF.Click
        If lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        txtAF.Text = ""
        FrmSelDocProveedor.cmbper.Enabled = True
        FrmSelDocProveedor.cmbper.Text = PerActual(0) & PerActual(1)
        FrmSelDocProveedor.lbform.Text = "fpAj"
        FrmSelDocProveedor.ShowDialog()
        FrmSelDocProveedor.cmbper.Enabled = False
        If txtAF.Text <> "" Then
            cmdNuevo_Click(AcceptButton, AcceptButton)
            txttipo.Text = lbdocajuste.Text
            txt_doc_afe.Enabled = False
            txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)
            txt_doc_afe.Text = txtAF.Text
            txtnitc.Enabled = False
            cmbTipoAF.Enabled = True
            BuscarDocumentoAJ(txt_doc_afe.Text)
        End If
    End Sub
    Private Sub BuscarDocumentoAJ(ByVal numero As String)
        Timer1.Enabled = False
        'PonerenCero()
        'BuscarPeriodo()
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT f. * , d. *  " _
                               & "FROM fact_comp" & FrmSelDocProveedor.cmbper.Text & " f " _
                               & "LEFT JOIN (detacomp" & FrmSelDocProveedor.cmbper.Text & " d) " _
                               & "ON f.doc = d.doc " _
                               & "WHERE f.doc = '" & numero _
                               & "' ORDER BY d.item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("La factura no se encuentra en los registros o esta en un periodo diferente, Verifique.  ", MsgBoxStyle.Information, "Buscar Datos")
            Exit Sub
        End If
        'txttipo.Text = tabla.Rows(0).Item("tipodoc")
        'txttipo_SelectedIndexChanged(AcceptButton, AcceptButton)  'para buscar
        'txtnumfac.Text = NumeroDoc(tabla.Rows(0).Item("num"))
        'txt_doc_afe.Text = tabla.Rows(0).Item("doc_afec")
        txtnitc.Text = tabla.Rows(0).Item("nitc")
        txtnitc_LostFocus(AcceptButton, AcceptButton) 'para buscar cliente
        txtnitc.Enabled = False
        'If Trim(tabla.Rows(0).Item("anulado").ToString) <> "no" Then lbanula.Text = "DOCUMENTO ANULADO"
        lbusuario.Text = tabla.Rows(0).Item("usuario")
        'txtfecha.Text = tabla.Rows(0).Item("fecha").ToString
        'lbhora.Text = tabla.Rows(0).Item("hora").ToString
        txtsubtotal.Text = Moneda2(tabla.Rows(0).Item("subtotal"), lb_imp_dec.Text)
        'descuento
        valordes.Text = tabla.Rows(0).Item("por_desc")
        txtdescuento.Text = tabla.Rows(0).Item("descuento")
        txtcuentadesc.Text = tabla.Rows(0).Item("cta_desc")
        'retencion
        valorret.Text = tabla.Rows(0).Item("por_rtf")
        txtret.Text = tabla.Rows(0).Item("rtf")
        txtcuentaret.Text = tabla.Rows(0).Item("cta_rtf")
        'iva
        valoriva.Text = tabla.Rows(0).Item("por_iva")
        txtiva.Text = tabla.Rows(0).Item("iva")
        txtcuentaiva.Text = tabla.Rows(0).Item("cta_iva")
        'fletes
        txtflete.Text = tabla.Rows(0).Item("fle")
        txtcuentaflete.Text = tabla.Rows(0).Item("cta_fle")
        'seguro
        txtseguro.Text = tabla.Rows(0).Item("seg")
        txtcuentaseguro.Text = tabla.Rows(0).Item("cta_seg")
        'total
        txttotal.Text = tabla.Rows(0).Item("total")
        txtcuentatotal.Text = tabla.Rows(0).Item("cta_total")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        cbaprobado.Text = tabla.Rows(0).Item("estado")
        txtobserbaciones.Text = "AJUSTE DOCUMENTO PROVEEDOR No" & NumeroDoc(tabla.Rows(0).Item("num")) & ". AJUSTE DE " & cmbTipoAF.Text
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        txtvmto.Text = tabla.Rows(0).Item("vmto")
        txtcentrocosto.Text = tabla.Rows(0).Item("ctoc")
        If txtcentrocosto.Text <> "0" Then
            BuscarCCs()
        Else
            txtcentro.Text = ""
        End If
        'txt_doc_afe.Text = Trim(tabla.Rows(0).Item("doc_afec"))
        'lbestado.Text = "CONSULTA"
        If Trim(tabla.Rows(0).Item("afecta").ToString) = "SI" Then
            rbafecta1.Checked = True
        Else
            rbafecta2.Checked = True
        End If
        Try 'CONCEPTOS
            cbconcepto.Items.Clear()
            cbsr.Items.Clear()
            cbvalor.Items.Clear()
            cbcuenta.Items.Clear()
            cbbase.Items.Clear()
            If Trim(tabla.Rows(0).Item("o_con")) = "si" Then 'hay otros conceptos
                '////////////
                Dim toc As New DataTable
                myCommand.CommandText = "SELECT  *  " _
                              & "FROM otcon_comp" & PerActual(0) & PerActual(1) & "  " _
                              & " WHERE doc = '" & numero _
                              & "' ORDER BY item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(toc)
                Refresh()

                If toc.Rows.Count > 0 Then
                    For l = 0 To toc.Rows.Count - 1
                        cbsr.Items.Add(toc.Rows(l).Item("tipo"))
                        cbconcepto.Items.Add(toc.Rows(l).Item("descrip"))
                        cbvalor.Items.Add(Moneda2(toc.Rows(l).Item("valor"), lb_imp_dec.Text))
                        cbcuenta.Items.Add(toc.Rows(l).Item("cta"))
                        cbbase.Items.Add(toc.Rows(l).Item("base"))
                        cbldoc.Items.Add(toc.Rows(l).Item("doc_ant"))
                    Next
                End If
                Try
                    cbconcepto.SelectedIndex = 0
                Catch ex As Exception
                End Try

                '/////////////
                ''Dim tipo As String = ""
                ''For i = 1 To 3
                ''    tipo = "t" & i 'tipo de concepto (1,2 o 3)
                ''    If Trim(tabla.Rows(0).Item(tipo)) <> "" Then
                ''        cbsr.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "d" & i 'descripcion (1,2 o 3)
                ''        cbconcepto.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "v" & i 'valor (1,2 o 3)
                ''        cbvalor.Items.Add(Moneda2(tabla.Rows(0).Item(tipo), lb_imp_dec.Text))
                ''        tipo = "cta" & i 'cuenta (1,2 o 3)
                ''        cbcuenta.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "b" & i 'base (1,2 o 3)
                ''        cbbase.Items.Add(tabla.Rows(0).Item(tipo))
                ''        tipo = "doc" & i 'base (1,2 o 3)
                ''        If i = 1 Then lbanti1.Text = tabla.Rows(0).Item(tipo)
                ''        If i = 2 Then lbanti2.Text = tabla.Rows(0).Item(tipo)
                ''        If i = 3 Then lbanti3.Text = tabla.Rows(0).Item(tipo)
                ''    End If
                ''Next
                ''Try
                ''    cbconcepto.SelectedIndex = 0
                ''Catch ex As Exception
                ''End Try
            End If
        Catch ex As Exception
        End Try
        gfactura.RowCount = items + 1
        Dim suma As Double = 0
        lbdescuento.Text = "0"
        Dim dct As Double = 0
        Dim base As Double = 0
        Try
            For i = 0 To items - 1
                gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                gfactura.Item("tipo", i).Value = tabla.Rows(i).Item("tipo_it")
                gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("cod_art")
                gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nom_art")
                gfactura.Item("bodega", i).Value = tabla.Rows(i).Item("num_bod")
                Try
                    gfactura.Item("cant", i).Value = Decimales(tabla.Rows(i).Item("cantidad").ToString)
                Catch ex As Exception
                End Try
                gfactura.Item("valor", i).Value = tabla.Rows(i).Item("valor")
                gfactura.Item("Vtotal", i).Value = tabla.Rows(i).Item("vtotal")
                gfactura.Item("iva", i).Value = tabla.Rows(i).Item("por_iva_g")
                'cuentas
                gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cta_inv")
                gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cta_cos")
                gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cta_gas")
                gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cta_iva")
                gfactura.Item("costo", i).Value = tabla.Rows(i).Item("valor")
                gfactura.Item("cc", i).Value = tabla.Rows(i).Item("concep")
                '... descuento
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
                '....
                Try
                    suma = suma + tabla.Rows(i).Item("vtotal")
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '******** ¿CUAL FORMA DE PAGO?  ************************************
        FDpagoAJ = ""
        If Trim(tabla.Rows(0).Item("fpago").ToString) = "Efectivo" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        ElseIf Trim(tabla.Rows(0).Item("fpago").ToString) = "Cheque" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("numero", 0).Value = Trim(tabla.Rows(0).Item("num_ch").ToString)
            gfp.Item("banco", 0).Value = Trim(tabla.Rows(0).Item("banco").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        ElseIf Trim(tabla.Rows(0).Item("fpago").ToString) = "Tarjeta" Then
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("numero", 0).Value = Trim(tabla.Rows(0).Item("num_tarj").ToString)
            gfp.Item("banco", 0).Value = Trim(tabla.Rows(0).Item("banco").ToString)
            gfp.Item("tt", 0).Value = Trim(tabla.Rows(0).Item("tip_tarj").ToString)
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        Else 'OTRA CREDITO
            FDpagoAJ = "credito"
            gfp.Item("cual", 0).Value = Trim(tabla.Rows(0).Item("fpago").ToString)
            gfp.Item("detalle", 0).Value = Trim(tabla.Rows(0).Item("desc_otra").ToString) '¿CUAL?
            gfp.Item("monto", 0).Value = Moneda2(tabla.Rows(0).Item("total").ToString, lb_imp_dec.Text)
        End If
        '*****************************************************
        lbsubtotal.Text = suma
        'bloquear()
        cmditems.Enabled = True
        CalcularTotales()
    End Sub
    Dim FDpagoAJ As String

    Private Sub cmbTipoAF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoAF.SelectedIndexChanged
        If cmbTipoAF.Text = "Disminuir Valores" Then
            rbafecta2.Checked = True
        Else
            rbafecta1.Checked = True
        End If
        txtobserbaciones.Text = "AJUSTE DOCUMENTO PROVEEDOR No" & txt_doc_afe.Text & ". AJUSTE DE " & cmbTipoAF.Text
    End Sub

    Private Sub valorretCree_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valorretCree.KeyPress
        ValidarPorcentaje(valorretCree, e)
    End Sub

    Private Sub valorretCree_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles valorretCree.LostFocus
        CalcularTotales()
    End Sub

    Private Sub txtcuentaCree_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuentaCree.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "fdp_rtc"
        FrmCuentas.ShowDialog()
    End Sub
End Class