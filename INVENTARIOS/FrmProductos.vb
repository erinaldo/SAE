Imports System.Drawing.Printing
Public Class FrmProductos
    Public n, n1, n2, n3, n4, n5, n6 As Integer
    Public d1, d2, d3, d4, d5, d6 As String
    Dim contenido As PrintPageEventArgs


    Private Sub FrmProductos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Dim usacont As String = ""
    Private Sub FrmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        usacont = ""
        Dim tp As New DataTable
        tp.Clear()
        myCommand.CommandText = "SELECT contable FROM parinven ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Try
            usacont = tp.Rows(0).Item(0)
        Catch ex As Exception
            usacont = "no"
        End Try


        If lbitem.Text = "item" Then
            cmdNuevo_Click(AcceptButton, AcceptButton)
            txtcodigo.Focus()
        ElseIf lbitem.Text = "itemMod" Then
            Bloquear()
            lbestado.Text = "CONSULTA"
            BurcarArti(txtcodigo.Text)
            cmdmodificar_Click(AcceptButton, AcceptButton)
            txtcodigo.Focus()
        Else
            CmdPrimero_Click(AcceptButton, AcceptButton)
            ' AUTOCOMPLETAR CODIGO DE ARTICULOS
            'Try
            '    txtcodigo.AutoCompleteCustomSource.Clear()
            '    Dim tb As New DataTable
            '    tb.Clear()
            '    myCommand.CommandText = "SELECT codart FROM articulos ORDER BY codart ;"
            '    myAdapter.SelectCommand = myCommand
            '    myAdapter.Fill(tb)
            '    If tb.Rows.Count > 0 Then
            '        For i = 0 To tb.Rows.Count - 1
            '            txtcodigo.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
            '        Next
            '    End If
            'Catch ex As Exception
            'End Try
        End If
        lbitem.Text = ""

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub rbimp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbimp2.CheckedChanged
        txtnumreg.Enabled = True
        txtarancel.Enabled = True
        txtposAran.Enabled = True
    End Sub
    Private Sub rbimp1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbimp1.CheckedChanged
        txtnumreg.Enabled = False
        txtarancel.Enabled = False
        txtposAran.Enabled = False
    End Sub
    Public Sub Bloquear()
        cmdNuevo.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        cmdmodificar.Enabled = True
        btnImprimirCod.Enabled = True
        CmdEliminar.Enabled = True
        CmdMostrar.Enabled = True
        txtcodigo.Enabled = False
        txtcodigo.ReadOnly = True
    End Sub
    Public Sub DesBloquear()
        cmdNuevo.Enabled = False
        txtcodigo.Enabled = True
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        cmdmodificar.Enabled = False
        btnImprimirCod.Enabled = False
        CmdEliminar.Enabled = False
        CmdMostrar.Enabled = False
        txtcodigo.ReadOnly = False
    End Sub
    Public Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text <> "NUEVO" Then
            lbaux.Visible = False
            txtcodigo.Text = ""
            txtdesc.Text = ""
            txtdetallada.Text = ""
            txtnivel.Text = "Ninguno"
            txtref.Text = ""
            txtcbarra.Text = ""
            '********propiedades****************
            txtcantidad.Text = 0
            txtcuni.Text = "0,00"
            txtcprom.Text = "0,00"
            txtctotal.Text = "0,00"
            txtprecio.Text = "0,00"
            txtpiva.Text = "0,00"
            txtiva.Text = "0,00"
            txtmargen.Text = "0,00"
            cbexen.Text = "no"
            cbexclu.Text = "no"
            txtuni.Text = "0"
            txtemp.Text = "0"
            txtcanemp.Text = "0,00"
            txtuni_emp.Text = "0,00"
            txtmin.Text = "0,00"
            txtpp.Text = "0,00"
            cbestado.Text = "Activo"
            txtconcep.Text = ""
            rbimp1.Checked = True
            txtnumreg.Text = ""
            txtarancel.Text = "0,00"
            txtposAran.Text = ""
            Gpropiedades.Enabled = False
            '***********cuentas*************
            lbinv.Text = ""
            lbing.Text = ""
            lbcos.Text = ""
            lbivag.Text = ""
            lbivad.Text = ""
            lbdev.Text = ""
            '********proveedores****************
            lbp1.Text = ""
            lbp2.Text = ""
            lbp3.Text = ""
            lbp4.Text = ""
            lbp5.Text = ""
            '***********************
            DesBloquear()
            lbestado.Text = "NUEVO"
            lbnroobs.Text = ""
            BuscarNiveles()
            txtcodigo.Focus()


        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Try
            myCommand.Parameters.Clear()
        Catch ex As Exception
        End Try
        Try
            If lbestado.Text = "NUEVO" Then
                Verificar()
            ElseIf lbestado.Text = "EDITAR" Then
                Verificar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Bloquear()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        DesBloquear()
        lbestado.Text = "EDITAR"
        txtdesc.Focus()
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        FrmArti_de_Inventarios.lbform.Text = "articulos"
        FrmArti_de_Inventarios.ShowDialog()
        If lbestado.Text = "CONSULTA" Then
            Bloquear()
            BurcarArti(txtcodigo.Text)
        End If
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codart FROM articulos ORDER BY codart LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                lbestado.Text = "NULO"
                lbnroobs.Text = "0"
                CmdPrimero.Focus()
            Else
                BurcarArti(tabla.Rows(0).Item(0))
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT codart FROM articulos ORDER BY codart LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BurcarArti(tabla.Rows(0).Item(0))
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
            myCommand.CommandText = "SELECT count(*) FROM articulos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT codart FROM articulos ORDER BY codart LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BurcarArti(tabla.Rows(0).Item(0))
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
            myCommand.CommandText = "SELECT count(*) FROM articulos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT codart FROM articulos ORDER BY codart LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BurcarArti(tabla.Rows(0).Item(0).ToString)
            lbnroobs.Text = i + 1
            lbestado.Text = "CONSULTA"
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BurcarArti(ByVal codart As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & codart & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                txtcodigo.Text = codart
                txtcodigo_KeyUp(AcceptButton, AcceptButton)
                txtdesc.Text = tabla.Rows(0).Item("nomart")
                txtdetallada.Text = tabla.Rows(0).Item("desart")
                txtnivel.Text = tabla.Rows(0).Item("nivel")
                txtref.Text = tabla.Rows(0).Item("referencia")
                txtcbarra.Text = tabla.Rows(0).Item("codbar")
                cbestado.Text = Trim(tabla.Rows(0).Item("estado").ToString)
                '***********************************************************
                Try
                    txtcantidad.Text = ContarArticulos(tabla.Rows(0).Item("codart"))
                Catch ex As Exception
                    txtcantidad.Text = "0"
                End Try
                '********************************************************
                Try
                    txtcuni.Text = Moneda(tabla.Rows(0).Item("cos_uni"))
                    txtcprom.Text = Moneda(tabla.Rows(0).Item("cos_pro"))
                    txtctotal.Text = Moneda((Val(txtcantidad.Text) * tabla.Rows(0).Item("cos_uni")).ToString)
                    txtprecio.Text = Moneda(tabla.Rows(0).Item("precio"))
                    Dim precioiva As Double
                    precioiva = CDbl(tabla.Rows(0).Item("precio")) + (CDbl(tabla.Rows(0).Item("precio")) * CDbl(tabla.Rows(0).Item("iva")) / 100)
                    txtpiva.Text = Moneda(precioiva)
                Catch ex As Exception
                End Try
                '***********************************************************
                txtiva.Text = Format(CDbl(tabla.Rows(0).Item("iva")), "0.00")
                If txtnivel.Text = "Articulo" Then Buscar_Con_Inv(tabla.Rows(0).Item("codart"))
                '******************************************************************************
                txtmargen.Text = Format(CDbl(tabla.Rows(0).Item("margen")), "0.00")
                cbexen.Text = tabla.Rows(0).Item("exento")
                cbexclu.Text = tabla.Rows(0).Item("excluido")
                txtuni.Text = tabla.Rows(0).Item("unidad")
                txtemp.Text = tabla.Rows(0).Item("empaque")
                txtcanemp.Text = tabla.Rows(0).Item("can_emp")
                txtuni_emp.Text = tabla.Rows(0).Item("uni_emp")
                txtmin.Text = tabla.Rows(0).Item("cant_min")
                txtpp.Text = tabla.Rows(0).Item("pp")
                txtconcep.Text = tabla.Rows(0).Item("con_comi")
                If tabla.Rows(0).Item("importa") = "no" Then
                    rbimp1.Checked = True
                Else
                    rbimp2.Checked = True
                End If
                txtnumreg.Text = tabla.Rows(0).Item("num_reg")
                txtarancel.Text = Format(Math.Round(CDbl(tabla.Rows(0).Item("por_ara")), 2), "0.00")
                txtposAran.Text = tabla.Rows(0).Item("pos_ara")
                If tabla.Rows(0).Item("nivel") = "Articulo" Then
                    Gpropiedades.Enabled = True
                Else
                    Gpropiedades.Enabled = False
                End If
                '************************************************************
                lbinv.Text = tabla.Rows(0).Item("cue_inv")
                lbing.Text = tabla.Rows(0).Item("cue_ing")
                lbcos.Text = tabla.Rows(0).Item("cue_cos")
                lbivag.Text = tabla.Rows(0).Item("cue_iva_v")
                lbivad.Text = tabla.Rows(0).Item("cue_iva_c")
                lbdev.Text = tabla.Rows(0).Item("cue_dev")
                '************************************************************ 
                lbp1.Text = tabla.Rows(0).Item("p1")
                lbp2.Text = tabla.Rows(0).Item("p2")
                lbp3.Text = tabla.Rows(0).Item("p3")
                lbp4.Text = tabla.Rows(0).Item("p4")
                lbp5.Text = tabla.Rows(0).Item("p5")
                If txtnivel.Text = "Articulo" Then
                    If CDbl(txtcantidad.Text) <= CDbl(txtpp.Text) Then
                        'CANTIDAES BAJO EL PUNTO DE PEDIDO
                    End If
                End If
                Bloquear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerenCero()
        End Try
    End Sub
    Public Sub Buscar_Con_Inv(ByVal codart As String)
        Dim precioiva As Double = 0
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM con_inv WHERE codart='" & codart & "' AND periodo='" & PerActual(0) & PerActual(1) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then Exit Sub
            txtcuni.Text = Moneda(tabla.Rows(0).Item("costuni"))
            txtcprom.Text = Moneda(tabla.Rows(0).Item("costprom"))
            txtctotal.Text = Moneda((Val(txtcantidad.Text) * tabla.Rows(0).Item("costuni")).ToString)
            precioiva = CDbl(txtprecio.Text) + (CDbl(txtprecio.Text) * CDbl(txtiva.Text) / 100)
            txtpiva.Text = Moneda(precioiva)
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        txtpiva.Text = Moneda(precioiva)
    End Sub
    Public Sub PonerenCero()

    End Sub
    Function ContarArticulos(ByVal codart As String)
        Dim tabla As New DataTable
        Dim suma, cant As Double
        suma = 0
        Try
            Dim ct As String = "0"
            For i = 1 To 10
                ct = ct + " + cant" & i
            Next

            tabla.Clear()
            myCommand.CommandText = "SELECT sum(" & ct & "), periodo FROM con_inv WHERE codart LIKE'" & codart & "%' AND periodo='" & PerActual(0) & PerActual(1) & "' GROUP BY periodo ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                cant = tabla.Rows(0).Item(0)
            Catch ex As Exception
                cant = 0
            End Try
            suma = suma + cant

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return suma
    End Function

    'BUSCAR NIVELES DE LAS CUENTAS
    Public Sub BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            n = Val(tabla.Rows(0).Item("longitud"))
            n1 = Val(tabla.Rows(0).Item("nivel1"))
            n2 = Val(tabla.Rows(0).Item("nivel2"))
            n3 = Val(tabla.Rows(0).Item("nivel3"))
            n4 = Val(tabla.Rows(0).Item("nivel4"))
            n5 = Val(tabla.Rows(0).Item("nivel5"))
            n6 = Val(tabla.Rows(0).Item("nivel6"))
            txtcodigo.MaxLength = n
            If n1 > 0 Then
                d1 = tabla.Rows(0).Item("desc1")
            Else
                d1 = ""
            End If
            If n2 > 0 Then
                d2 = tabla.Rows(0).Item("desc2")
            Else
                d2 = ""
            End If
            If n3 > 0 Then
                d3 = tabla.Rows(0).Item("desc3")
            Else
                d3 = ""
            End If
            If n4 > 0 Then
                d4 = tabla.Rows(0).Item("desc4")
            Else
                d4 = ""
            End If
            If n5 > 0 Then
                d5 = tabla.Rows(0).Item("desc5")
            Else
                d5 = ""
            End If
            If n6 > 0 Then
                d6 = tabla.Rows(0).Item("desc6")
            Else
                d6 = ""
            End If
        Catch ex As Exception
            MsgBox("Por favor verifique los niveles de los codigo de grupos y productos...", MsgBoxStyle.Information, "SAE verificación")
            Me.Close()
        End Try
    End Sub
    Private Sub txtcodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodigo.KeyPress
        lbaux.Visible = False
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcodigo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodigo.KeyUp
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        LongitudCodigo()
    End Sub
    Public Sub LongitudCodigo()
        BuscarNiveles()
        lbaux.Visible = False
        Gpropiedades.Enabled = False
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If Val(txtcodigo.Text.Length) = n1 And d1 <> "" Then
                txtnivel.Text = d1
            ElseIf Val(txtcodigo.Text.Length) = (n1 + n2) And d2 <> "" Then
                txtnivel.Text = d2
            ElseIf Val(txtcodigo.Text.Length) = (n1 + n2 + n3) And d3 <> "" Then
                txtnivel.Text = d3
            ElseIf Val(txtcodigo.Text.Length) = (n1 + n2 + n3 + n4) And d4 <> "" Then
                txtnivel.Text = d4
            ElseIf Val(txtcodigo.Text.Length) = (n1 + n2 + n3 + n4 + n5) And d5 <> "" Then
                txtnivel.Text = d5
            ElseIf Val(txtcodigo.Text.Length) = n And d6 <> "" Then
                txtnivel.Text = d6
                Gpropiedades.Enabled = True
            Else
                txtnivel.Text = "ninguno"
            End If
            Try
                If txtnivel.Text = "Articulo" And Trim(lbinv.Text) = "" Then
                    Try
                        Dim tabla As New DataTable
                        myCommand.CommandText = "SELECT * FROM parinven;"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla)
                        lbinv.Text = tabla.Rows(0).Item("cuenta1")
                        lbing.Text = tabla.Rows(0).Item("cuenta2")
                        lbcos.Text = tabla.Rows(0).Item("cuenta3")
                        lbivag.Text = tabla.Rows(0).Item("cuenta4")
                        lbivad.Text = tabla.Rows(0).Item("cuenta5")
                        lbdev.Text = tabla.Rows(0).Item("cuenta6")
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub
    Function BuscarNivelesAnt()
        BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & Trim(txtcodigo.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 And lbestado.Text = "NUEVO" Then
            MsgBox("El " & txtnivel.Text & " ( " & txtcodigo.Text & " ) YA se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            Return False
        Else
            Return VerificarNiveles()
        End If
    End Function
    Function VerificarNiveles()
        BuscarNiveles()
        Dim cad, cad2 As String
        cad2 = Trim(txtcodigo.Text)
        '*************** NIVEL 1 ***********************
        cad = ""
        If n1 < cad2.Length And d1 <> "" Then
            For i = 0 To n1 - 1
                cad = cad & cad2(i)
            Next
            Dim tablan1 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan1)
            If tablan1.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El nivel " & d1 & " ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcodigo.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 2 ***********************
        cad = ""
        If (n1 + n2) < cad2.Length And d2 <> "" Then
            For i = 0 To (n1 + n2 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan2 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan2)
            If tablan2.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El nivel " & d2 & " ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcodigo.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 3 ***********************
        cad = ""
        If (n1 + n2 + n3) < cad2.Length And d3 <> "" Then
            For i = 0 To (n1 + n2 + n3 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan3 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan3)
            If tablan3.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El nivel " & d3 & " ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcodigo.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 4 ***********************
        cad = ""
        If (n1 + n2 + n3 + n4) < cad2.Length And d4 <> "" Then
            For i = 0 To (n1 + n2 + n3 + n4 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan4 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan4)
            If tablan4.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El nivel " & d4 & " ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcodigo.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 4 ***********************
        cad = ""
        If (n1 + n2 + n3 + n4 + n5) < cad2.Length And d5 <> "" Then
            For i = 0 To (n1 + n2 + n3 + n4 + n5 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan4 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan4)
            If tablan4.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El nivel " & d5 & "( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcodigo.Focus()
                Exit Function
            End If
        End If
        '*************** TODO BIEN (HAY TODOS LOS NIVELES) *************************
        Return True
    End Function

    Public Sub Verificar()
        If txtnivel.Text = "ninguno" Then
            MsgBox("El codigo del grupo o articulo no es un nivel correcto, verifique.  ", MsgBoxStyle.Information, "SAE Verificacion")
            txtcodigo.Focus()
            Exit Sub
        ElseIf txtdesc.Text = "" Then
            MsgBox("Favor digite una descripción para el grupo o articulo. ", MsgBoxStyle.Information, "SAE Verificacion")
            txtdesc.Focus()
            Exit Sub
        ElseIf txtdetallada.Text = "" Then
            MsgBox("Favor digite una descripción detallada para el grupo o articulo. ", MsgBoxStyle.Information, "SAE Verificacion")
            txtdetallada.Focus()
            Exit Sub
        End If

        '.... VALIDAR CUENTAS
        If lbinv.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If
        If lbing.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique  ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If
        If lbcos.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If
        If lbivag.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If
        If lbivad.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If
        If lbdev.Text = "" And txtnivel.Text = "Articulo" And usacont = "si" Then
            MsgBox("Las cuentas del articulo estan incompletas.Verifique ", MsgBoxStyle.Information, "SAE Verificacion")
            cdmcuentas.Focus()
            Exit Sub
        End If

        myCommand.Parameters.Clear()
        Refresh()
        If lbestado.Text = "NUEVO" Then
            If BuscarNivelesAnt() = False Then Exit Sub
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            If ExisteArticulo() = True Then Exit Sub
            Modificar()
        End If

    End Sub
    Function ExisteArticulo()
        Dim res As Boolean = False
        Try
            Dim tablan1 As New DataTable
            myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & txtcodigo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan1)
            If tablan1.Rows.Count > 0 Then
                res = False
            Else
                res = True
                Dim resultado As MsgBoxResult
                resultado = MsgBox("El codigo " & txtcodigo.Text & " NO existe, ¿Desea agregarlo al inventario?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    If BuscarNivelesAnt() = True Then
                        Guardar()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return res
    End Function

    Public Sub Guardar()
        If txtnivel.Text <> "ninguno" Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            Try
                myCommand.Parameters.AddWithValue("?codart", txtcodigo.Text)
                myCommand.Parameters.AddWithValue("?nomart", txtdesc.Text)
                myCommand.Parameters.AddWithValue("?desart", txtdetallada.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel", txtnivel.Text)
                myCommand.Parameters.AddWithValue("?referencia", txtref.Text.ToString)
                myCommand.Parameters.AddWithValue("?codbar", txtcbarra.Text)
                myCommand.Parameters.AddWithValue("?cos_uni", CDbl(txtcuni.Text))
                myCommand.Parameters.AddWithValue("?cos_pro", CDbl(txtcprom.Text))
                myCommand.Parameters.AddWithValue("?margen", CDec(txtmargen.Text))
                myCommand.Parameters.AddWithValue("?precio", CDbl(txtprecio.Text))
                myCommand.Parameters.AddWithValue("?iva", CDec(txtiva.Text))
                myCommand.Parameters.AddWithValue("?exento", cbexen.Text)
                myCommand.Parameters.AddWithValue("?excluido", cbexclu.Text)
                myCommand.Parameters.AddWithValue("?cue_inv", lbinv.Text)
                myCommand.Parameters.AddWithValue("?cue_ing", lbing.Text)
                myCommand.Parameters.AddWithValue("?cue_cos", lbcos.Text)
                myCommand.Parameters.AddWithValue("?cue_iva_v", lbivag.Text)
                myCommand.Parameters.AddWithValue("?cue_iva_c", lbivad.Text)
                myCommand.Parameters.AddWithValue("?cue_dev", lbdev.Text)
                myCommand.Parameters.AddWithValue("?unidad", txtuni.Text)
                myCommand.Parameters.AddWithValue("?empaque", CDbl(txtemp.Text))
                myCommand.Parameters.AddWithValue("?can_emp", CDbl(txtcanemp.Text))
                myCommand.Parameters.AddWithValue("?uni_emp", CDbl(txtuni_emp.Text))
                myCommand.Parameters.AddWithValue("?cant_min", CDbl(txtmin.Text))
                myCommand.Parameters.AddWithValue("?pp", CDbl(txtpp.Text))
                myCommand.Parameters.AddWithValue("?estado", cbestado.Text)
                myCommand.Parameters.AddWithValue("?con_comi", txtconcep.Text)
                If rbimp1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?importa", "no")
                Else
                    myCommand.Parameters.AddWithValue("?importa", "si")
                End If
                myCommand.Parameters.AddWithValue("?num_reg", txtnumreg.Text)
                Try
                    myCommand.Parameters.AddWithValue("?por_ara", CDec(txtarancel.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?por_ara", "0")
                End Try
                myCommand.Parameters.AddWithValue("?pos_ara", txtposAran.Text)
                myCommand.Parameters.AddWithValue("?p1", lbp1.Text)
                myCommand.Parameters.AddWithValue("?p2", lbp2.Text)
                myCommand.Parameters.AddWithValue("?p3", lbp3.Text)
                myCommand.Parameters.AddWithValue("?p4", lbp4.Text)
                myCommand.Parameters.AddWithValue("?p5", lbp5.Text)
                myCommand.CommandText = "INSERT INTO articulos " _
                                     & " VALUES (?codart,?nomart,?desart,?nivel,?referencia,?codbar,?cos_uni,?cos_pro,?margen,?precio,?iva,?exento,?excluido,?cue_inv,?cue_ing,?cue_cos,?cue_iva_v,?cue_iva_c,?cue_dev,?unidad,?empaque,?can_emp,?uni_emp,?cant_min,?pp,?estado,?con_comi,?importa,?num_reg,?por_ara,?pos_ara,?p1,?p2,?p3,?p4,?p5);"
                myCommand.ExecuteNonQuery()
                If txtnivel.Text = "Articulo" Then
                    Dim per, sql As String
                    For i = 0 To 12
                        If i < 10 Then
                            per = "0" & i
                        Else
                            per = i
                        End If
                        sql = "INSERT INTO con_inv (codart,periodo,costuni,costprom,costmoe,otro,margen,base,cue_inv,cue_cos,cue_ing,cue_iva_v,cue_iva_c,cue_dev,saldoi,vent,vsal,vaju)" _
                        & " VALUES('" & txtcodigo.Text & "','" & per & "','0','0','0','0','" & CDbl(txtmargen.Text) & "','0','" & lbinv.Text & "','" & lbcos.Text & "','" & lbing.Text & "','" & lbivag.Text & "','" & lbivad.Text & "','" & lbdev.Text & "','0','0','0','0');"
                        Afecta_Con_inv(sql)
                    Next
                End If
                Cerrar()
                MsgBox("El nuevo " & txtnivel.Text & " Fué Guadados Exitosamente.  ", MsgBoxStyle.Information, "SAE, Guardar Datos")
                Bloquear()
                lbestado.Text = "GUARDADO"
                lbnroobs.Text = ""
            Catch ex As Exception
                MsgBox("No se pudo guardar el " & txtnivel.Text & ", error: " & ex.ToString, MsgBoxStyle.Critical, "SAE")
            End Try
            Cerrar()
        End If
    End Sub
    Public Sub Afecta_Con_inv(ByVal sql As String)
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub Modificar()
        MiConexion(bda)
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos del " & txtnivel.Text & " se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?nomart", txtdesc.Text.ToString)
                myCommand.Parameters.AddWithValue("?desart", txtdetallada.Text.ToString)
                myCommand.Parameters.AddWithValue("?nivel", txtnivel.Text)
                myCommand.Parameters.AddWithValue("?referencia", txtref.Text.ToString)
                myCommand.Parameters.AddWithValue("?codbar", txtcbarra.Text)
                Try
                    myCommand.Parameters.AddWithValue("?margen", CDec(txtmargen.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?margen", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?iva", CDec(txtiva.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?iva", "0")
                End Try
                myCommand.Parameters.AddWithValue("?exento", cbexen.Text)
                myCommand.Parameters.AddWithValue("?excluido", cbexclu.Text)
                myCommand.Parameters.AddWithValue("?cue_inv", lbinv.Text)
                myCommand.Parameters.AddWithValue("?cue_ing", lbing.Text)
                myCommand.Parameters.AddWithValue("?cue_cos", lbcos.Text)
                myCommand.Parameters.AddWithValue("?cue_iva_v", lbivag.Text)
                myCommand.Parameters.AddWithValue("?cue_iva_c", lbivad.Text)
                myCommand.Parameters.AddWithValue("?cue_dev", lbdev.Text)
                myCommand.Parameters.AddWithValue("?unidad", txtuni.Text)
                Try
                    myCommand.Parameters.AddWithValue("?empaque", CDbl(txtemp.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?empaque", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?can_emp", CDbl(txtcanemp.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?can_emp", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?uni_emp", CDbl(txtuni_emp.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?uni_emp", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?cant_min", CDbl(txtmin.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?cant_min", "0")
                End Try
                Try
                    myCommand.Parameters.AddWithValue("?pp", CDbl(txtpp.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?pp", "0")
                End Try
                myCommand.Parameters.AddWithValue("?estado", cbestado.Text)
                myCommand.Parameters.AddWithValue("?con_comi", txtconcep.Text)
                If rbimp1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?importa", "no")
                Else
                    myCommand.Parameters.AddWithValue("?importa", "si")
                End If
                myCommand.Parameters.AddWithValue("?num_reg", txtnumreg.Text)
                Try
                    myCommand.Parameters.AddWithValue("?por_ara", CDec(txtarancel.Text))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?por_ara", "0")
                End Try
                myCommand.Parameters.AddWithValue("?pos_ara", txtposAran.Text)
                myCommand.Parameters.AddWithValue("?p1", lbp1.Text)
                myCommand.Parameters.AddWithValue("?p2", lbp2.Text)
                myCommand.Parameters.AddWithValue("?p3", lbp3.Text)
                myCommand.Parameters.AddWithValue("?p4", lbp4.Text)
                myCommand.Parameters.AddWithValue("?p5", lbp5.Text)
                '*******************************************************************
                myCommand.CommandText = "UPDATE articulos SET nomart=?nomart,desart=?desart,nivel=?nivel,referencia=?referencia,codbar=?codbar,margen=?margen,iva=?iva,exento=?exento,excluido=?excluido,cue_inv=?cue_inv,cue_ing=?cue_ing,cue_cos=?cue_cos," _
                                    & "cue_iva_v=?cue_iva_v,cue_iva_c=?cue_iva_c,cue_dev=?cue_dev,unidad=?unidad,empaque=?empaque,can_emp=?can_emp,uni_emp=?uni_emp,cant_min=?cant_min,pp=?pp,estado=?estado,con_comi=?con_comi,importa=?importa,num_reg=?num_reg,por_ara=?por_ara,pos_ara=?pos_ara,p1=?p1,p2=?p2,p3=?p3,p4=?p4,p5=?p5 WHERE codart='" & txtcodigo.Text & "';"
                myCommand.ExecuteNonQuery()
                If txtnivel.Text = "Articulo" Then
                    Dim per, sql As String
                    per = PerActual(0) & PerActual(1)
                    For i = Val(per) To 12
                        If i < 10 Then
                            per = "0" & i
                        Else
                            per = i
                        End If
                        sql = "UPDATE con_inv SET margen=" & CDbl(txtmargen.Text) & ", cue_inv='" & lbinv.Text & "',cue_cos='" & lbcos.Text & "',cue_ing='" & lbing.Text & "',cue_iva_v='" & lbivag.Text & "',cue_iva_c='" & lbivad.Text & "',cue_dev='" & lbdev.Text & "'" _
                            & " WHERE codart='" & txtcodigo.Text & "' AND periodo='" & per & "';"
                        Afecta_Con_inv(sql)
                    Next
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                Bloquear()
                lbestado.Text = "EDITADO"
            End If
        Catch ex As Exception
            MsgBox("No se pudo modificar el " & txtnivel.Text & ", error: " & ex.ToString, MsgBoxStyle.Critical, "SAE")
        End Try
        Cerrar()
    End Sub

    Private Sub txtref_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtref.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcbarra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcbarra.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtdetallada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdetallada.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiva.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(txtiva, e)
        Else
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
            e.Handled = True
        End If
    End Sub
    Private Sub txtmargen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmargen.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(txtmargen, e)
        Else
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
            e.Handled = True
        End If
    End Sub
    Private Sub txtloc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtuni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuni.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtemp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcanemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcanemp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
                validarnumero(txtcanemp, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtuni_emp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuni_emp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtuni, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmin.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtmin, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtpp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtpp, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtconcep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcep.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnumreg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumreg.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtarancel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtarancel.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            ValidarPorcentaje(txtarancel, e)
        Else
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            End If
            e.Handled = True
        End If
    End Sub
    Private Sub txtposAran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtposAran.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cdmcuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmcuentas.Click
        If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            BuscarCA()
            FrmCuestasArt.ShowDialog()
        End If
    End Sub
    Public Sub BuscarCA()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbinv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtcinv.Text = ""
            FrmCuestasArt.txtninv.Text = ""
        Else
            FrmCuestasArt.txtcinv.Text = lbinv.Text
            FrmCuestasArt.txtninv.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbing.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtcing.Text = ""
            FrmCuestasArt.txtning.Text = ""
        Else
            FrmCuestasArt.txtcing.Text = lbing.Text
            FrmCuestasArt.txtning.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbcos.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtccos.Text = ""
            FrmCuestasArt.txtncos.Text = ""
        Else
            FrmCuestasArt.txtccos.Text = lbcos.Text
            FrmCuestasArt.txtncos.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbivag.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtcivag.Text = ""
            FrmCuestasArt.txtnivag.Text = ""
        Else
            FrmCuestasArt.txtcivag.Text = lbivag.Text
            FrmCuestasArt.txtnivag.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbivad.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtcivad.Text = ""
            FrmCuestasArt.txtnivad.Text = ""
        Else
            FrmCuestasArt.txtcivad.Text = lbivad.Text
            FrmCuestasArt.txtnivad.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & lbdev.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmCuestasArt.txtcdev.Text = ""
            FrmCuestasArt.txtndev.Text = ""
        Else
            FrmCuestasArt.txtcdev.Text = lbdev.Text
            FrmCuestasArt.txtndev.Text = tabla.Rows(0).Item(0)
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
    End Sub
    Private Sub cmdprov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprov.Click
        If (lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR") And txtnivel.Text = "Articulo" Then
            BuscarPA()
            FrmProve_Art.ShowDialog()
        End If
    End Sub
    Public Sub BuscarPA()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT nombre, apellidos FROM terceros WHERE nit='" & lbp1.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmProve_Art.txt1.Text = ""
            FrmProve_Art.txtn1.Text = ""
        Else
            FrmProve_Art.txt1.Text = lbp1.Text
            FrmProve_Art.txtn1.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT nombre, apellidos FROM terceros WHERE nit='" & lbp2.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmProve_Art.txt2.Text = ""
            FrmProve_Art.txtn2.Text = ""
        Else
            FrmProve_Art.txt2.Text = lbp2.Text
            FrmProve_Art.txtn2.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT nombre, apellidos FROM terceros WHERE nit='" & lbp3.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmProve_Art.txt3.Text = ""
            FrmProve_Art.txtn3.Text = ""
        Else
            FrmProve_Art.txt3.Text = lbp3.Text
            FrmProve_Art.txtn3.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT nombre, apellidos FROM terceros WHERE nit='" & lbp4.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmProve_Art.txt4.Text = ""
            FrmProve_Art.txtn4.Text = ""
        Else
            FrmProve_Art.txt4.Text = lbp4.Text
            FrmProve_Art.txtn4.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT nombre, apellidos FROM terceros WHERE nit='" & lbp5.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            FrmProve_Art.txt5.Text = ""
            FrmProve_Art.txtn5.Text = ""
        Else
            FrmProve_Art.txt5.Text = lbp5.Text
            FrmProve_Art.txtn5.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
        End If
        tabla.Clear()
        myCommand.Parameters.Clear()
    End Sub

    Private Sub cmddeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddeta.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "NULO" Then
            FrmArtBodPre.CmdRegistrarCambios.Enabled = False
            FrmArtBodPre.lbcodigo.Text = txtcodigo.Text
            FrmArtBodPre.lbdescricion.Text = txtdesc.Text
            FrmArtBodPre.lbform.Text = "ARTICULO EN BODEGAS"
            FrmArtBodPre.gitems.Columns(2).HeaderText = "CANTIDAD"
            FrmArtBodPre.gitems.Columns(2).ReadOnly = True
            FrmArtBodPre.ShowDialog()
        End If
    End Sub

    Private Sub cdmlista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmlista.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "NULO" Then
            FrmArtBodPre.lbcodigo.Text = txtcodigo.Text
            FrmArtBodPre.lbdescricion.Text = txtdesc.Text
            FrmArtBodPre.lbform.Text = "LISTAS DE PRECIOS DEL ARTICULO"
            FrmArtBodPre.gitems.Columns(2).HeaderText = "PRECIO"
            If lbestado.Text = "EDITAR" Then
                FrmArtBodPre.gitems.Columns(2).ReadOnly = False
                FrmArtBodPre.CmdRegistrarCambios.Enabled = True
            Else
                FrmArtBodPre.gitems.Columns(2).ReadOnly = True
                FrmArtBodPre.CmdRegistrarCambios.Enabled = False
            End If
            FrmArtBodPre.ShowDialog()
        End If
    End Sub

    Private Sub txtdesc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesc.LostFocus
        If Trim(txtdetallada.Text) = "" Then
            BuscarMarca(txtcodigo.Text)
        End If
    End Sub
    Public Sub BuscarMarca(ByVal cod As String)
        Try
            If cod.Length < 2 Then Exit Sub
            Dim ta As New DataTable
            ta.Clear()
            myCommand.CommandText = "select nomart from articulos where codart='" & cod(0) & cod(1) & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            If ta.Rows.Count > 0 Then
                txtdetallada.Text = ta.Rows(0).Item(0)
            Else
                txtdetallada.Text = txtdesc.Text
            End If
        Catch ex As Exception
            txtdetallada.Text = txtdesc.Text
        End Try
    End Sub
    Private Sub txtcodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodigo.LostFocus

        If txtcodigo.Text <> "" Then
            If lbestado.Text = "NUEVO" Then
                Dim ta As New DataTable
                ta.Clear()
                myCommand.CommandText = "select codart from articulos where codart='" & txtcodigo.Text & "'"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(ta)
                If ta.Rows.Count > 0 Then
                    MsgBox("Ese codigo ya fue asignado a otro producto", MsgBoxStyle.Information, "Verifique")
                    BurcarArti(txtcodigo.Text)
                    lbnroobs.Text = 1
                    lbestado.Text = "CONSULTA"
                End If
            End If
            If Trim(txtdetallada.Text) = "" Then
                BuscarMarca(txtcodigo.Text)
            End If
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        MiConexion(bda)


        Dim nbod As Integer = 0
        Dim sqlb As String = ""
        Dim cant As String = ""
        Dim p As String = ""


        Dim tabla_b As New DataTable
        tabla_b = New DataTable
        myCommand.CommandText = "select numbod from bodegas"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_b)
        nbod = tabla_b.Rows.Count

        For i = 1 To nbod
            If i <> nbod Then
                cant = cant & "c.cant" & i & " =0 AND "
            Else
                cant = cant & "c.cant" & i & " =0 "
            End If
        Next

        Dim sql As String
        sql = " SELECT c.codart FROM  con_inv c WHERE  " & cant & " AND c.periodo = '00' and c.codart like '" & txtcodigo.Text & "%' "
        Dim tabla As New DataTable
        tabla = New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim sql2 As String

        sql2 = " SELECT codart FROM deta_mov01 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov02 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov03 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov04 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov05 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov06 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov07 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov08 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov09 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov10 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov11 where codart like '" & txtcodigo.Text & "%' union " _
        & " SELECT codart FROM deta_mov12 where codart like '" & txtcodigo.Text & "%' "

        Dim tabla_d As New DataTable
        tabla_d = New DataTable
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_d)

        If tabla.Rows.Count <> 0 And tabla_d.Rows.Count = 0 Then

            Dim resultado As MsgBoxResult
            resultado = MsgBox("Realmente desea eliminar el  articulo seleccionado?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Try
                    myCommand.CommandText = "DELETE  FROM articulos  where codart like '" & txtcodigo.Text & "%'"
                    myCommand.ExecuteNonQuery()

                    myCommand.CommandText = "DELETE FROM con_inv where codart like '" & txtcodigo.Text & "%' "
                    myCommand.ExecuteNonQuery()

                    MsgBox("Articulo eliminado con exito", MsgBoxStyle.Information, "SAE")

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Else
            If tabla.Rows.Count = 0 And tabla_d.Rows.Count = 0 Then

                myCommand.CommandText = "DELETE FROM articulos  where codart like '" & txtcodigo.Text & "%'"
                myCommand.ExecuteNonQuery()

                MsgBox("Eliminado con exito", MsgBoxStyle.Information, "SAE")
            Else
                MsgBox("No puede realizar esta operacion con el codigo seleccionado, es posible que tenga movimientos.", MsgBoxStyle.Information, "SAE")
            End If

        End If




    End Sub


    Private Sub btnImprimirCod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImprimirCod.Click

        If txtCantImprimir.Value >= 1 Then
            Configurar()
            Documento.Print()
        Else
            MsgBox("No se ha definido el numero de Copias")
        End If
    End Sub
    Function configAlto() As Integer
        Dim alto As Integer
        alto = 0
        Dim nCopias As Integer
        nCopias = txtCantImprimir.Value
        Select Case nCopias
            Case 1 To 3
                alto = 100
            Case 4 To 6
                alto = 200
            Case 7 To 9
                alto = 300
            Case 10 To 12
                alto = 400
            Case 13 To 15
                alto = 500
            Case 16 To 18
                alto = 600
            Case 19 To 21
                alto = 700
            Case 22 To 24
                alto = 800
            Case 25 To 27
                alto = 900
            Case 28 To 30
                alto = 940
        End Select
        Return alto
    End Function
    Function mapearCodigo(ByVal num As Integer) As String
        Dim codigo As String
        If num >= 0 And num <= 9 Then
            codigo = "0000" + num.ToString
        ElseIf num >= 10 And num <= 99 Then
            codigo = "000" + num.ToString
        ElseIf num >= 100 And num <= 999 Then
            codigo = "00" + num.ToString
        ElseIf num >= 1000 And num <= 9999 Then
            codigo = "0" + num.ToString
        Else
            codigo = num.ToString
        End If
        Return codigo
    End Function
    Private Sub Configurar()
        impresora.Document = Documento
        impresora.ShowDialog()
        Dim tamaño As Printing.PaperSize
        tamaño = New Printing.PaperSize("personal", 1000.8, configAlto())
        Documento.PrinterSettings = impresora.PrinterSettings
        Documento.DefaultPageSettings.PaperSize = tamaño
    End Sub

    Private Sub Documento_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles Documento.PrintPage
        If txtnivel.Text <> "Articulo" Then Exit Sub
        If Trim(txtcbarra.Text) = "" Then Exit Sub
        Dim salto As Integer = 0
        Dim salto2 As Integer = 0
        Dim salto3 As Integer = 0
        Dim nsalto As Integer = 15
        Dim marca As String = CambiaCadena(txtdetallada.Text, 12)
        If txtCantImprimir.Value = 1 Then
            contenido = e
            contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 8, 20)
            contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 18, 55)
            contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 4), Brushes.Black, 20, 70)
            contenido.HasMorePages = False
        ElseIf txtCantImprimir.Value = 2 Then
            contenido = e
            contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 8, 20)
            contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 4), Brushes.Black, 20, 70)
            contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 18, 55)

            contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 143, 20)
            contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 4), Brushes.Black, 160, 70)
            contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 153, 55)
            contenido.HasMorePages = False
        Else
            For k As Integer = 10 To 940 Step 100
                salto = k
                salto2 = 55 + k
                salto3 = 45 + k
                If k <> 10 Then
                    salto = salto + nsalto
                    salto2 = salto2 + nsalto
                    salto3 = salto3 + nsalto
                    nsalto = nsalto + (15 * 1.3)
                End If
                contenido = e
                contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 8, salto)
                contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 10, salto3)
                contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 8), Brushes.Black, 10, salto2)

                contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 143, salto)
                contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 8), Brushes.Black, 145, salto2)
                contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 145, salto3)

                contenido.Graphics.DrawString("*" & txtcodigo.Text & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 277, salto)
                contenido.Graphics.DrawString("Precio: $" & txtpiva.Text, New Font("Arial", 8), Brushes.Black, 279, salto2)
                contenido.Graphics.DrawString(marca, New Font("Arial", 8), Brushes.Black, 279, salto3)
                contenido.HasMorePages = False
            Next
        End If

    End Sub

    Private Sub btnImptodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImptodos.Click
        frmImpcodBarras.ShowDialog()
    End Sub

    
    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodigo.TextChanged
        Try
            txtcbarra.Text = txtcodigo.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdesc.TextChanged

    End Sub
End Class