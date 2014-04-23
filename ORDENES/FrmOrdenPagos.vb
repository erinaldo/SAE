Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports MySql.Data.MySqlClient
Public Class FrmOrdenPagos
    Dim cta_efe As String = ""
    Dim cta_ban As String = ""
    Dim a As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    Private Sub FrmOrdenPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = " ALTER TABLE  `ctas_x_pagar` CHANGE  `ccosto`  `ccosto` TEXT CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        BuscarPeriodo()
        lbper.Text = PerActual
        lbper2.Text = PerActual
        Try
            fecha.Text = CDate(PerActual & "/" & Now.Day)
            fecha.Value = CDate(PerActual & "/" & Now.Day)
        Catch ex As Exception
        End Try
        'fechamin()
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Public Sub ParCompra()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT LEFT(cta_caja,4) AS efe, LEFT(cta_banco,4) AS ban FROM par_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            cta_efe = tabla.Rows(0).Item("efe").ToString
            cta_ban = tabla.Rows(0).Item("ban").ToString
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Bruto()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT *, SUM(debito) as db FROM ot_cpp" & PerActual(0) & PerActual(1) & " WHERE doc_afec<>'' AND doc='" & txtdoc.Text & "' GROUP BY doc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtbruto.Text = Moneda(tabla.Rows(0).Item("db"))
            txttotal.Text = Moneda(tabla.Rows(0).Item("total"))
            Try
                lbpesos.Text = "SON: " & Num2Text(txttotal.Text)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'txtcheque.Text = tabla.Rows(0).Item("cheque")
            'txtbanco.Text = tabla.Rows(0).Item("banco")
            fecha.Value = CDate(tabla.Rows(0).Item("dia") & "/" & PerActual)
            'fechar.Value = fecha.Value
            txtnit.Text = tabla.Rows(0).Item("nitc")
            lbdv.Text = DigitoNIT(txtnit.Text)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarDeta()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT o.debito,o.credito,s.descripcion FROM ot_cpp" & PerActual(0) & PerActual(1) & " o LEFT JOIN(selpuc s) ON o.codigo=s.codigo WHERE o.doc_afec='' AND o.doc='" & txtdoc.Text & "' AND LEFT(o.codigo,4)<>'" & cta_efe & "' AND LEFT(o.codigo,4)<>'" & cta_ban & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            grilla.ReadOnly = True
            grilla.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                grilla.Item(0, i).Value = tabla.Rows(i).Item("descripcion")
                grilla.Item(1, i).Value = Moneda(tabla.Rows(i).Item("debito"))
                grilla.Item(2, i).Value = Moneda(tabla.Rows(i).Item("credito"))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub fechamin()

        Try
            fecha.MinDate = "01/" & PerActual
            fecha.Text = CDate(Now.Day & "/" & PerActual)
            'fecha.MaxDate = "31/" & PerActual
            fecha.MaxDate = DateSerial(Year(fecha.Value), Month(fecha.Value) + 1, 0)
        Catch ex As Exception
            MsgBox(ex.ToString())
            'Try
            '    fecha.MaxDate = "30/" & PerActual
            'Catch ex2 As Exception
            '    Try
            '        fecha.MaxDate = "29/" & PerActual
            '    Catch ex3 As Exception
            '        fecha.MaxDate = "28/" & PerActual
            '    End Try
            'End Try
        End Try
        '**************************
        'fechar.MinDate = "01/" & PerActual
    End Sub
    Public Sub Bloquear()
        txtorden.Enabled = False
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        cmdprint.Enabled = True
        cmdCE.Enabled = True
        g1.Enabled = False
        txtbruto.Enabled = False
        txtiva.Enabled = False
        txtbase.Enabled = False
        txttotal.Enabled = False
        grilla.ReadOnly = True
    End Sub
    Public Sub DesBloquear()
        txtorden.Enabled = True
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        cmdprint.Enabled = False
        cmdCE.Enabled = False
        g1.Enabled = True
        txtbruto.Enabled = True
        txtiva.Enabled = True
        txtbase.Enabled = True
        txttotal.Enabled = True
        grilla.ReadOnly = False
    End Sub
    Public Sub PonerEncero()
        txtorden.Text = ""
        Try
            fecha.Value = CDate(PerActual & "/" & Now.Day)
            'fecha.Value = Today
            'fechar.Value = Today
        Catch ex As Exception

        End Try
        txtdoc.Text = ""
        txtconcep.Text = ""
        txtcontra.Text = ""
        txttipo.Text = ""
        txtrubro.Text = ""
        txtrubro2.Text = ""
        txtnomrubro.Text = ""
        grilla.RowCount = 1
        grilla.Rows.Clear()
        lbper.Text = PerActual
        lbper2.Text = PerActual
        txtdis.Text = ""
        txtnit.Text = ""
        txtnombre.Text = ""
        lbdv.Text = ""
        txtconcep.Text = ""
        txtplazo.Text = ""
        txtbruto.Text = Moneda(0)
        txtiva.Text = Moneda(0)
        txtbase.Text = Moneda(0)
        txttotal.Text = Moneda(0)
        lbpesos.Text = "SON: CERO PESOS"
    End Sub
    '***********************************************
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        DesBloquear()
        txtorden.Enabled = True
        PonerEncero()
        BuscarPeriodo()
        lbestado.Text = "NUEVO"
        Dim cs As String = ""
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT nord FROM parordenes ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        If tb.Rows.Count > 0 Then
            If tb.Rows(0).Item(0) = "A" Then
                cs = "SELECT IFNULL(MAX(num),0) AS num FROM ord_pagos ;"
            ElseIf tb.Rows(0).Item(0) = "M" Then
                cs = "SELECT IFNULL(MAX(num),0) AS num FROM ord_pagos WHERE per='" & PerActual & "';"
            Else
                MsgBox("Verifique el parametro", MsgBoxStyle.Information, "SAE")
                Me.Close()
            End If
        End If

        Try
            Dim tabla As New DataTable
            myCommand.CommandText = cs
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtorden.Text = NumeroDoc(Val(tabla.Rows(0).Item("num").ToString) + 1)
        Catch ex As Exception
            txtorden.Text = NumeroDoc(1)
        End Try
        txtcontra.ReadOnly = True
        Button1.Focus()
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Dim cad As String = ""
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If ValidarGuardar() = True Then
                If lbestado.Text = "EDITAR" Then
                    cad = "AND doc<>'" & PerActual & "-" & txtorden.Text & "' "
                End If
                Dim ts As New DataTable
                ts.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT doccxp, doc FROM ord_pagos WHERE doccxp ='" & Doccxp & "' " & cad & " ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(ts)
                Refresh()
                If ts.Rows.Count > 0 Then
                    MsgBox("Esta cuenta por pagar Ya tiene asignada una orden (" & ts.Rows(0).Item(1) & ")", MsgBoxStyle.Information, "Verificacion")
                    Exit Sub
                End If

                MiConexion(bda)
                Try
                    If lbestado.Text = "NUEVO" Then
                        Guardar()
                    Else
                        Modificar()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                Cerrar()
            End If
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "ELIMINADO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT estado FROM ord_pagos WHERE doc='" & PerActual & "-" & txtorden.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If Trim(tabla.Rows(0).Item("estado").ToString) <> "" Then
                MsgBox("El documento no puede ser modificado porque ya fue pagado. ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            lbestado.Text = "EDITAR"
            DesBloquear()
            txtorden.Enabled = False
            txtcontra.ReadOnly = True
            Button1.Focus()
        Catch ex As Exception
            MsgBox("Error al intententar modificar el registro " & ex.ToString, MsgBoxStyle.Information, "SAE Control de Errores")
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        Try
            FrmSelOndenPago.lbform.Text = "ordenes"
            FrmSelOndenPago.ShowDialog()
            If lbestado.Text = "CONSULTA" Then BuscarDoc(txtorden.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            Dim tf As New DataTable
            tf.Clear()
            myCommand.CommandText = "SELECT forden FROM parordenes"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            If tf.Rows.Count <> 0 Then
                If tf.Rows(0).Item(0) <> "" Then
                    Select Case tf.Rows(0).Item(0)
                        Case "1"
                            GenerarPDF()
                        Case "2"
                            GenerarPDF2()
                    End Select
                Else
                    MsgBox("Verifique el Formato de la Orden en los parametros", MsgBoxStyle.Information, "SAE")
                End If
            Else
                MsgBox("Verifique el Formato de la Orden en los parametros", MsgBoxStyle.Information, "SAE")
            End If

            'If chOp.Checked = False Then
            '    GenerarPDF()
            'Else
            '    GenerarResol()
            'End If
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '*******************************************
    Function ValidarGuardar()
        Try
            If Trim(txtorden.Text = "") Then
                MsgBox("Verifique la orden de pago... ", MsgBoxStyle.Information)
                txtorden.Focus()
                Return False
                Exit Function
            End If
            If Trim(txtdis.Text = "") Then
                MsgBox("Verifique la disponibilidad... ", MsgBoxStyle.Information)
                txtdis.Focus()
                Return False
                Exit Function
            End If
            If Trim(txtorden.Text = "") Then
                MsgBox("Verifique la orden de pago... ", MsgBoxStyle.Information)
                txtorden.Focus()
                Return False
                Exit Function
            End If
            If Trim(txtnombre.Text = "") Then
                MsgBox("Verifique el nit del tercero... ", MsgBoxStyle.Information)
                txtnit.Focus()
                Return False
                Exit Function
            End If
        Catch ex As Exception

        End Try
        Return True
    End Function
    Public Sub Guardar()
        BuscarPeriodo()
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?ord", PerActual & "-" & txtorden.Text)
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?doc", Val(txtorden.Text))
            myCommand.Parameters.AddWithValue("?fecha", fecha.Value)
            myCommand.Parameters.AddWithValue("?con_num", CambiaCadena(txtcontra.Text, 20))
            myCommand.Parameters.AddWithValue("?con_ben", CambiaCadena(txtnit.Text, 15))
            myCommand.Parameters.AddWithValue("?nomnit", CambiaCadena(txtnombre.Text, 199))
            myCommand.Parameters.AddWithValue("?con_objeto", txtconcep.Text)
            myCommand.Parameters.AddWithValue("?con_valor", DIN(txtbruto.Text))
            myCommand.Parameters.AddWithValue("?con_plazo", CambiaCadena(txtplazo.Text, 10))
            myCommand.Parameters.AddWithValue("?sop_cont", " ")
            myCommand.Parameters.AddWithValue("?cta_rubro", Trim(txtrubro.Text.Replace(Chr(13), ";")))
            myCommand.Parameters.AddWithValue("?v_bruto", DIN(txtbruto.Text))
            myCommand.Parameters.AddWithValue("?v_neto", DIN(txttotal.Text))
            myCommand.Parameters.AddWithValue("?v_iva", DIN(txtiva.Text))
            myCommand.Parameters.AddWithValue("?estado", " ")
            myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text.ToString)
            myCommand.Parameters.AddWithValue("?doccxp", Doccxp)
            myCommand.Parameters.AddWithValue("?reso", txtreso.Text)
            '************* GUARDAR CONSULTA *********************************************
            myCommand.CommandText = "INSERT INTO ord_pagos VALUES" _
            & "(?ord,?per,?doc,?fecha,?con_num,?con_ben,?nomnit,?con_objeto,?con_valor,?con_plazo,?sop_cont,?cta_rubro,?v_bruto,?v_neto,?v_iva,?estado,?user,now(),?doccxp,?reso);"
            myCommand.ExecuteNonQuery()
            '**********************GUARDAR DETALLES ****************************
            Try
                'If grilla.RowCount = 1 Then Exit Sub
                If grilla.RowCount <> 1 Then
                    For i = 0 To grilla.RowCount - 1
                        Try
                            If grilla.Item("cta", i).Value.ToString <> "" And (grilla.Item("Creditos", i).Value <> Moneda(0) Or grilla.Item("Debitos", i).Value <> Moneda(0)) Then
                                myCommand.Parameters.Clear()
                                myCommand.Parameters.AddWithValue("?ord", PerActual & "-" & txtorden.Text)
                                myCommand.Parameters.AddWithValue("?cta", grilla.Item("cta", i).Value.ToString)
                                myCommand.Parameters.AddWithValue("?concep", CambiaCadena(grilla.Item("Descripcion", i).Value.ToString, 100))
                                myCommand.Parameters.AddWithValue("?db", DIN(grilla.Item("Debitos", i).Value.ToString))
                                myCommand.Parameters.AddWithValue("?cr", DIN(grilla.Item("Creditos", i).Value.ToString))
                                Try
                                    myCommand.Parameters.AddWithValue("?por", DIN(grilla.Item("porc", i).Value.ToString))
                                Catch ex As Exception
                                    myCommand.Parameters.AddWithValue("?por", DIN(0))
                                End Try

                                Try
                                    myCommand.Parameters.AddWithValue("?tipo", grilla.Item("tipo", i).Value.ToString)
                                Catch ex As Exception
                                    'MsgBox(ex.ToString)
                                    If grilla.Item("Debitos", i).Value.ToString = "0,00" Then
                                        myCommand.Parameters.AddWithValue("?tipo", "CR")
                                    Else
                                        myCommand.Parameters.AddWithValue("?tipo", "DB")
                                    End If
                                End Try
                                myCommand.CommandText = "INSERT INTO deta_ord VALUES(?ord,?cta,?concep,?db,?cr,?por,?tipo);"
                                myCommand.ExecuteNonQuery()
                            End If

                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Next
                End If
                MsgBox("Datos Guardados Correctamente...", MsgBoxStyle.Information)
                lbestado.Text = "GUARDADO"
                Bloquear()
            Catch ex As Exception
                MsgBox("Error detalles: " & ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Modificar()
        Try
            BuscarPeriodo()
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la orden de pago " & PerActual & "-" & txtorden.Text & " se van a modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?fecha", fecha.Value)
                myCommand.Parameters.AddWithValue("?con_num", CambiaCadena(txtcontra.Text, 20))
                myCommand.Parameters.AddWithValue("?con_ben", CambiaCadena(txtnit.Text, 15))
                myCommand.Parameters.AddWithValue("?nomnit", CambiaCadena(txtnombre.Text, 199))
                myCommand.Parameters.AddWithValue("?con_objeto", txtconcep.Text)
                myCommand.Parameters.AddWithValue("?con_valor", DIN(txtbruto.Text))
                myCommand.Parameters.AddWithValue("?con_plazo", CambiaCadena(txtplazo.Text, 10))
                myCommand.Parameters.AddWithValue("?sop_cont", " ")
                myCommand.Parameters.AddWithValue("?cta_rubro", txtrubro.Text)
                myCommand.Parameters.AddWithValue("?v_bruto", DIN(txtbruto.Text))
                myCommand.Parameters.AddWithValue("?v_neto", DIN(txttotal.Text))
                myCommand.Parameters.AddWithValue("?v_iva", DIN(txtiva.Text))
                myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text.ToString)
                '************* GUARDAR CONSULTA *********************************************
                myCommand.CommandText = "UPDATE ord_pagos SET " _
                & "fecha=?fecha,con_num=?con_num,con_ben=?con_ben,nomnit=?nomnit,con_objeto=?con_objeto,con_valor=?con_valor,con_plazo=?con_plazo," _
                & "sop_cont=?sop_cont,cta_rubro=?cta_rubro,v_bruto=?v_bruto,v_neto=?v_neto,v_iva=?v_iva,user=?user,ult_up=now() " _
                & "WHERE doc='" & PerActual & "-" & txtorden.Text & "';"
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "DELETE FROM deta_ord WHERE doc='" & PerActual & "-" & txtorden.Text & "';"
                myCommand.ExecuteNonQuery()
                '**********************GUARDAR DETALLES ****************************
                Try
                    'If grilla.RowCount = 1 Then Exit Sub
                    If grilla.RowCount <> 1 Then
                        For i = 0 To grilla.RowCount - 1
                            Try
                                If grilla.Item("cta", i).Value.ToString <> "" And (grilla.Item("Creditos", i).Value <> Moneda(0) Or grilla.Item("Debitos", i).Value <> Moneda(0)) Then
                                    myCommand.Parameters.Clear()
                                    myCommand.Parameters.AddWithValue("?ord", PerActual & "-" & txtorden.Text)
                                    myCommand.Parameters.AddWithValue("?cta", grilla.Item("cta", i).Value.ToString)
                                    myCommand.Parameters.AddWithValue("?concep", CambiaCadena(grilla.Item("Descripcion", i).Value.ToString, 100))
                                    myCommand.Parameters.AddWithValue("?db", DIN(grilla.Item("Debitos", i).Value.ToString))
                                    myCommand.Parameters.AddWithValue("?cr", DIN(grilla.Item("Creditos", i).Value.ToString))
                                    Try
                                        myCommand.Parameters.AddWithValue("?por", DIN(grilla.Item("porc", i).Value.ToString))
                                    Catch ex As Exception
                                        myCommand.Parameters.AddWithValue("?por", DIN(0))
                                    End Try
                                    Try
                                        myCommand.Parameters.AddWithValue("?tipo", grilla.Item("tipo", i).Value.ToString)
                                    Catch ex As Exception
                                        If grilla.Item("Debitos", i).Value.ToString = "0,00" Then
                                            myCommand.Parameters.AddWithValue("?tipo", "CR")
                                        Else
                                            myCommand.Parameters.AddWithValue("?tipo", "DB")
                                        End If
                                    End Try
                                    myCommand.CommandText = "INSERT INTO deta_ord VALUES(?ord,?cta,?concep,?db,?cr,?por,?tipo);"
                                    myCommand.ExecuteNonQuery()
                                End If

                            Catch ex As Exception
                                'MsgBox(ex.ToString)
                            End Try
                        Next
                    End If
                    Bloquear()
                    MsgBox("Datos Modificados Correctamente...", MsgBoxStyle.Information)
                    lbestado.Text = "EDITADO"
                Catch ex As Exception
                    MsgBox("Error detalles: " & ex.ToString)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '*******************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Bloquear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' ORDER BY doc,fecha LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                Bloquear()
                PonerEncero()
                lbestado.Text = "NULO"
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnroobs.Text = 1
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
                myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' ORDER BY doc,fecha LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM ord_pagos WHERE per='" & PerActual & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' ORDER BY doc,fecha LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDoc(tabla.Rows(0).Item(0))
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM ord_pagos WHERE per='" & PerActual & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT doc FROM ord_pagos WHERE per='" & PerActual & "' ORDER BY doc,fecha LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDoc(tabla.Rows(0).Item(0))
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub DatosContrato(ByVal doc As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM ctas_x_pagar WHERE doc='" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtplazo.Text = tabla.Rows(0).Item("vmto").ToString
            txtconcep.Text = tabla.Rows(0).Item("descrip").ToString
            txttipo.Text = tabla.Rows(0).Item("ctaret").ToString
            Doccxp = tabla.Rows(0).Item("doc").ToString
            lbcp.Text = tabla.Rows(0).Item("doc").ToString
            txtdis.Text = tabla.Rows(0).Item("pagare").ToString
            ' varios rubros
            Dim rb As String = ""
            Dim cad As String = ""
            Dim vc() As String
            rb = tabla.Rows(0).Item("ccosto").ToString

            If rb.Length <> rb.Replace(";", "").Length Then
                vc = rb.Split(";")
                For i = 0 To vc.Length - 1
                    If i = vc.Length - 1 Then
                        cad = cad & vc(i)
                    Else
                        cad = cad & vc(i) & vbCrLf
                    End If
                Next
            Else
                cad = tabla.Rows(0).Item("ccosto").ToString
            End If
            txtrubro.Text = cad
            txtrubro_TextChanged(AcceptButton, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarDoc(ByVal doc As String)
        Try
            Bloquear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT o.*,d.* FROM ord_pagos o LEFT JOIN deta_ord d ON o.doc = d.doc WHERE o.doc='" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            'MsgBox(tabla.Rows.Count)
            If tabla.Rows.Count = 0 Then
                CmdNuevo.Focus()
            Else
                lbestado.Text = "CONSULTA"
                lbper2.Text = tabla.Rows(0).Item("per").ToString
                txtorden.Text = NumeroDoc(Val(tabla.Rows(0).Item("num").ToString))
                fecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
                txtcontra.Text = tabla.Rows(0).Item("con_num").ToString
                txtnit.Text = tabla.Rows(0).Item("con_ben").ToString
                txtnombre.Text = tabla.Rows(0).Item("nomnit").ToString
                txtdoc.Text = tabla.Rows(0).Item("sop_cont").ToString
                txtreso.Text = tabla.Rows(0).Item("resolucion").ToString
                '...doccxp
                DatosContrato(tabla.Rows(0).Item("doccxp").ToString)
                Try
                    txtbruto.Text = Moneda(CDbl(tabla.Rows(0).Item("v_bruto").ToString))
                Catch ex As Exception
                    txtbruto.Text = Moneda("0")
                End Try
                Try
                    txtiva.Text = Moneda(CDbl(tabla.Rows(0).Item("v_iva").ToString))
                Catch ex As Exception
                    txtiva.Text = Moneda("0")
                End Try
                txtbase.Text = "0,00"
                Try
                    txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
                Catch ex As Exception
                End Try
                CalcularTotales()
                Try
                    grilla.Rows.Clear()
                Catch ex As Exception

                End Try
                grilla.RowCount = tabla.Rows.Count + 1
                If tabla.Rows.Count > 0 Then

                    For i = 0 To tabla.Rows.Count - 1
                        Try
                            grilla.Item("cta", i).Value = tabla.Rows(i).Item("cta").ToString
                            grilla.Item("Descripcion", i).Value = tabla.Rows(i).Item("concep").ToString
                            grilla.Item("tipo", i).Value = tabla.Rows(i).Item("tipo").ToString
                            Try
                                grilla.Item("porc", i).Value = CDbl(tabla.Rows(i).Item("porc").ToString)
                            Catch ex As Exception
                                grilla.Item("porc", i).Value = "0"
                            End Try
                            Try
                                grilla.Item("Debitos", i).Value = Moneda(CDbl(tabla.Rows(i).Item("db").ToString))
                            Catch ex As Exception
                                grilla.Item("Debitos", i).Value = Moneda("0")
                            End Try
                            Try
                                grilla.Item("Creditos", i).Value = Moneda(CDbl(tabla.Rows(i).Item("cr").ToString))
                            Catch ex As Exception
                                grilla.Item("Creditos", i).Value = Moneda("0")
                            End Try
                        Catch ex As Exception
                            MsgBox("Error al buscar detalles " & ex.ToString)
                        End Try
                    Next
                End If
            End If
            CalcularTotales()
                lbestado.Text = "CONSULTA"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fecha.ValueChanged
        ' ''lbdispo.Text = fecha.Value.Year.ToString
        ''lbper2.Text = fecha.Value.Year.ToString
        ''If fecha.Value.Month < 10 Then
        ''    'lbdispo.Text = lbdispo.Text & "0" & fecha.Value.Month.ToString
        ''    lbper2.Text = lbper2.Text & "0" & fecha.Value.Month.ToString
        ''Else
        ''    'lbdispo.Text = lbdispo.Text & fecha.Value.Month.ToString
        ''    lbper2.Text = lbper2.Text & fecha.Value.Month.ToString
        ''End If
        ''If fecha.Value.Day < 10 Then
        ''    'lbdispo.Text = lbdispo.Text & "0" & fecha.Value.Day.ToString
        ''Else
        ''    'lbdispo.Text = lbdispo.Text & fecha.Value.Day.ToString
        ''End If
        ' ''lbdispo.Text = lbdispo.Text & "-"

        If lbestado.Text = "NUEVO" Then
            If PerActual <> Format(fecha.Value, "MM/yyyy") Then
                Try
                    fecha.Value = CDate(PerActual & "/" & Now.Day)
                Catch ex As Exception
                    If fecha.Enabled = True Then
                        fecha.Value = DateTime.Now.ToString("yyyy-MM-dd")
                    Else
                        fecha.Value = CDate(PerActual & "/" & "01")
                    End If
                End Try
                If fecha.Enabled = True Then
                    fecha.Focus()
                End If
                MsgBox("La fecha no coincide con el periodo actual (" & PerActual & "), Verifique.  ", MsgBoxStyle.Information, "Control Factura ")
            End If
        End If
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        ValidarNIT(txtnit, e)
    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        lbdv.Text = DigitoNIT(txtnit.Text)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtnombre.Text = Trim(tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos"))
        Catch ex As Exception
            txtnombre.Text = ""
        End Try
    End Sub
    '*****************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerarPDF()

        BuscarPeriodo()

        Dim sql As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        doc = PerActual & "-" & txtorden.Text

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
        nom = tabla2.Rows(0).Item("descripcion")
        ' nit = tabla2.Rows(0).Item("nit")
        '& " o.con_objeto as concepto, " _


        sql = "SELECT o.`doc` AS doc_ext,  o.`fecha` , o.`con_ben` AS  nitc, o.`nomnit` AS nomnit, o.`v_bruto` AS subtotal, o.`v_neto` AS total, " _
        & "        IF( (SELECT clasaju FROM ctas_x_pagar WHERE doc = o.doccxp)<> '', " _
        & " CONCAT(trim(o.con_objeto),'\nOBSERVACION: ',(SELECT clasaju FROM ctas_x_pagar WHERE doc = o.doccxp)), " _
        & " o.con_objeto) as concepto, " _
        & " d.`concep` AS descrip, d.porc as iva, (d.`db`- d.cr) AS descto, CAST(CONCAT( RIGHT(o.fecha, 2), '/', MID(o.fecha, 6, 2),'/',LEFT(o.fecha, 4)) AS CHAR(10)) AS pagare, " _
        & " trim(cta_rubro) as cta_rubro " _
        & "  FROM ord_pagos o LEFT JOIN deta_ord d ON o.doc = '" & doc & "' AND d.doc = '" & doc & "' WHERE o.doc = '" & doc & "' "

        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        '..........
        Dim cm As String = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "gasc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "gasc_fut"
        Else
            cm = "gasc_cgdg"
        End If


        Dim rb As String = ""
        'Try
        Dim cd_rb As String = ""
        rb = Trim(tabla.Rows(0).Item("cta_rubro"))

        Dim cp() As String
        cp = rb.Split(";")
        For i = 0 To cp.Length - 1
            If i <> cp.Length - 1 Then
                cd_rb = cd_rb & "'" & cp(i).ToString & "',"
            Else
                cd_rb = cd_rb & "'" & cp(i).ToString & "'"
            End If
        Next

        cd_rb = Trim(cd_rb.Replace(Chr(10), ""))
        Dim tr As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CONCAT(" & cm & " ,'  - ' ,gasc_concepto) FROM presupuesto" & a & ".`gasconcepto`  WHERE `gasc_cod1` IN (" & Trim(cd_rb) & ") "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr)
        rb = ""
        If tr.Rows.Count > 0 Then
            For j = 0 To tr.Rows.Count - 1
                rb = rb & tr.Rows(j).Item(0).ToString & vbCrLf
            Next
        End If
        'Catch ex As Exception
        '    rb = ""
        'End Try
        '.... FIRMAS...............................
        Dim t1 As String = ""
        Dim m1 As String = ""
        Dim f1 As String = ""
        Dim p1 As String = ""
        Dim t2 As String = ""
        Dim m2 As String = ""
        Dim f2 As String = ""
        Dim p2 As String = ""
        Dim t3 As String = ""
        Dim m3 As String = ""
        Dim f3 As String = ""
        Dim p3 As String = ""
        Dim t4 As String = ""
        Dim m4 As String = ""
        Dim f4 As String = ""
        Dim p4 As String = ""
        Dim t5 As String = ""
        Dim m5 As String = ""
        Dim f5 As String = ""
        Dim p5 As String = ""

        Dim tf As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT *  FROM parordenes  "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tf)
        If tf.Rows.Count <> 0 Then
            t1 = tf.Rows(0).Item("titulo1")
            m1 = tf.Rows(0).Item("msj1")
            f1 = tf.Rows(0).Item("firma1")
            p1 = tf.Rows(0).Item("pie1")
            t2 = tf.Rows(0).Item("titulo2")
            m2 = tf.Rows(0).Item("msj2")
            f2 = tf.Rows(0).Item("firma2")
            p2 = tf.Rows(0).Item("pie2")
            t3 = tf.Rows(0).Item("titulo3")
            m3 = tf.Rows(0).Item("msj3")
            f3 = tf.Rows(0).Item("firma3")
            p3 = tf.Rows(0).Item("pie3")
            t4 = tf.Rows(0).Item("titulo4")
            m4 = tf.Rows(0).Item("msj4")
            f4 = tf.Rows(0).Item("firma4")
            p4 = tf.Rows(0).Item("pie4")
            t5 = tf.Rows(0).Item("titulo5")
            m5 = tf.Rows(0).Item("msj5")
            f5 = txtnombre.Text
            p5 = "NIT/CC: " & txtnit.Text
        End If
        '............. Resolucion.............
        Dim tt As String = ""
        Dim cuer As String = ""
        Dim fir As String = ""
        Dim pie As String = ""
        Dim a1 As String = ""
        Dim ff As String = ""

        Dim ta3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM parreso ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta3)
        If ta3.Rows.Count > 0 Then
            tt = ta3.Rows(0).Item("titulo")
            cuer = "QUE: EL MUNICIPIO DE " & ta3.Rows(0).Item("municipio") & ", adeuda a: " & txtnombre.Text & ", portador del documento " _
            & " de identidad No " & txtnit.Text & ", segun concepto referente a: " & txtconcep.Text & ", y existe la disponibilidad presupuestal para atender el compromiso."
            fir = ta3.Rows(0).Item("firma")
            pie = ta3.Rows(0).Item("pie")
            ff = ff & "Dado en " & ta3.Rows(0).Item("municipio") & ", "
        End If
        a1 = "Páguese a: " & txtnombre.Text & ", portador del documento de identidad No. " & txtnit.Text & ". La suma de: " & lbpesos.Text & " $ " & txttotal.Text & " en atencion al considerando anterior."
        ff = ff & " el dia " & fecha.Text


        Dim tabl As DataSet
        tabl = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac FROM parafacts WHERE factura='RAPIDA'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "parafacts")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT pagare as nomart FROM ctas_x_pagar WHERE doc='" & Doccxp & "';"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLegal
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportOrdenPago.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            Dim Prord As New ParameterField
            Dim Prletra As New ParameterField
            '..
            Dim Prt1 As New ParameterField
            Dim Prm1 As New ParameterField
            Dim Prf1 As New ParameterField
            Dim Prp1 As New ParameterField
            '..
            Dim Prt2 As New ParameterField
            Dim Prm2 As New ParameterField
            Dim Prf2 As New ParameterField
            Dim Prp2 As New ParameterField
            '..
            Dim Prt3 As New ParameterField
            Dim Prm3 As New ParameterField
            Dim Prf3 As New ParameterField
            Dim Prp3 As New ParameterField
            '..
            Dim Prt4 As New ParameterField
            Dim Prm4 As New ParameterField
            Dim Prf4 As New ParameterField
            Dim Prp4 As New ParameterField
            '..
            Dim Prt5 As New ParameterField
            Dim Prm5 As New ParameterField
            Dim Prf5 As New ParameterField
            Dim Prp5 As New ParameterField
            '...
            Dim Prreso As New ParameterField
            Dim PrtitR As New ParameterField
            Dim Prcuer As New ParameterField
            Dim Pra1 As New ParameterField
            Dim Prfirm As New ParameterField
            Dim Prpief As New ParameterField
            Dim PrFec As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "rubr"
            PrNit.CurrentValues.AddValue(rb.ToString)
            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prord.Name = "tord"
            Prord.CurrentValues.AddValue("ORDEN DE PAGO N° " & PerActual & " - " & txtorden.Text & "")
            Prletra.Name = "letra"
            Prletra.CurrentValues.AddValue(lbpesos.Text.ToString)
            '...
            Prt1.Name = "t1"
            Prt1.CurrentValues.AddValue(t1)
            Prm1.Name = "msj1"
            Prm1.CurrentValues.AddValue(m1)
            Prf1.Name = "f1"
            Prf1.CurrentValues.AddValue(f1)
            Prp1.Name = "p1"
            Prp1.CurrentValues.AddValue(p1)
            '...
            Prt2.Name = "t2"
            Prt2.CurrentValues.AddValue(t2)
            Prm2.Name = "msj2"
            Prm2.CurrentValues.AddValue(m2)
            Prf2.Name = "f2"
            Prf2.CurrentValues.AddValue(f2)
            Prp2.Name = "p2"
            Prp2.CurrentValues.AddValue(p2)
            '...
            Prt3.Name = "t3"
            Prt3.CurrentValues.AddValue(t3)
            Prm3.Name = "msj3"
            Prm3.CurrentValues.AddValue(m3)
            Prf3.Name = "f3"
            Prf3.CurrentValues.AddValue(f3)
            Prp3.Name = "p3"
            Prp3.CurrentValues.AddValue(p3)
            '...
            Prt4.Name = "t4"
            Prt4.CurrentValues.AddValue(t4)
            Prm4.Name = "msj4"
            Prm4.CurrentValues.AddValue(m4)
            Prf4.Name = "f4"
            Prf4.CurrentValues.AddValue(f4)
            Prp4.Name = "p4"
            Prp4.CurrentValues.AddValue(p4)
            '...
            Prt5.Name = "t5"
            Prt5.CurrentValues.AddValue(t5)
            Prm5.Name = "msj5"
            Prm5.CurrentValues.AddValue(m5)
            Prf5.Name = "f5"
            Prf5.CurrentValues.AddValue(f5)
            Prp5.Name = "p5"
            Prp5.CurrentValues.AddValue(p5)

            '.. Reso
            Prreso.Name = "reso"
            Prreso.CurrentValues.AddValue(txtreso.Text.ToString)
            PrtitR.Name = "tit"
            PrtitR.CurrentValues.AddValue(tt)
            Prcuer.Name = "cuerpo"
            Prcuer.CurrentValues.AddValue(cuer)
            Pra1.Name = "a1"
            Pra1.CurrentValues.AddValue(a1)
            'Prfirm.Name = "firm"
            'Prfirm.CurrentValues.AddValue(fir)
            'Prpief.Name = "pief"
            'Prpief.CurrentValues.AddValue(pie)
            PrFec.Name = "fec"
            PrFec.CurrentValues.AddValue(ff)

            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prord)
            prmdatos.Add(Prletra)
            prmdatos.Add(Prt1)
            prmdatos.Add(Prm1)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prp1)
            prmdatos.Add(Prt2)
            prmdatos.Add(Prm2)
            prmdatos.Add(Prf2)
            prmdatos.Add(Prp2)
            prmdatos.Add(Prt3)
            prmdatos.Add(Prm3)
            prmdatos.Add(Prf3)
            prmdatos.Add(Prp3)
            prmdatos.Add(Prt4)
            prmdatos.Add(Prm4)
            prmdatos.Add(Prf4)
            prmdatos.Add(Prp4)
            prmdatos.Add(Prt5)
            prmdatos.Add(Prm5)
            prmdatos.Add(Prf5)
            prmdatos.Add(Prp5)

            prmdatos.Add(Prreso)
            prmdatos.Add(PrtitR)
            prmdatos.Add(Prcuer)
            prmdatos.Add(Pra1)
            'prmdatos.Add(Prfirm)
            'prmdatos.Add(Prpief)
            prmdatos.Add(PrFec)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function MontoRubro(ByVal m As String)
        Dim mt As Double = 0 'monto rubro
        Dim mta As Double = 0 'monto auxiliar
        Dim dcto As Double = 0 'descuento
        'MsgBox("ok")
        Try
            mt = CDbl(m)
            mta = CDbl(m)
        Catch ex As Exception
        End Try
        Try
            For i = 0 To grilla.RowCount - 1
                Try
                    dcto = 0
                    If (CDbl(grilla.Item("porc", i).Value) > 0) Then
                        dcto = mta * (CDbl(grilla.Item("porc", i).Value) / 100)
                    End If
                    mt = mt - dcto
                    'MsgBox(mt)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
            m = Moneda(mt)
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
        Return m
    End Function
    Private Sub GenerarPDF2()

        BuscarPeriodo()

        Dim sql As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        Dim nite As String = ""
        doc = PerActual & "-" & txtorden.Text

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
        nom = tabla2.Rows(0).Item("descripcion")
        nite = tabla2.Rows(0).Item("nit")
        '& " o.con_objeto as concepto, " _


        sql = "SELECT o.`doc` AS doc_ext,  o.`fecha` , o.`con_ben` AS  nitc, o.`nomnit` AS nomnit, o.`v_bruto` AS subtotal, o.`v_neto` AS total, " _
        & "        IF( (SELECT clasaju FROM ctas_x_pagar WHERE doc = o.doccxp)<> '', " _
        & " CONCAT(trim(o.con_objeto),'\nOBSERVACION: ',(SELECT clasaju FROM ctas_x_pagar WHERE doc = o.doccxp)), " _
        & " o.con_objeto) as concepto, " _
        & " d.`concep` AS descrip, d.porc as iva, (d.`db`- d.cr) AS descto, CAST(CONCAT( RIGHT(o.fecha, 2), '/', MID(o.fecha, 6, 2),'/',LEFT(o.fecha, 4)) AS CHAR(10)) AS pagare, " _
        & " trim(cta_rubro) as cta_rubro, c.pagare as ctasubtotal, cast(c.ctaretica as char(20)) as ctaretiva " _
        & "  FROM ctas_x_pagar c, ord_pagos o LEFT JOIN deta_ord d ON o.doc = '" & doc & "' AND d.doc = '" & doc & "' " _
        & " WHERE o.doc = '" & doc & "' and c.doc= o.doccxp"

        Dim tabla As  New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        '..........
        Dim cm As String = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "gasc_cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "gasc_fut"
        Else
            cm = "gasc_cgdg"
        End If

        Dim rb As String = ""
        'Try
        Dim cd_rb As String = ""
        rb = Trim(tabla.Rows(0).Item("cta_rubro"))

        Dim cp() As String
        cp = rb.Split(";")
        For i = 0 To cp.Length - 1
            If i <> cp.Length - 1 Then
                cd_rb = cd_rb & "'" & cp(i).ToString & "',"
            Else
                cd_rb = cd_rb & "'" & cp(i).ToString & "'"
            End If
        Next

        cd_rb = Trim(cd_rb.Replace(Chr(10), ""))
        Dim tr As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT CONCAT(" & cm & " ,'  - ' ,gasc_concepto) " _
        & " FROM presupuesto" & a & ".`gasconcepto`, ctas_x_pagar  WHERE `gasc_cod1` IN (" & Trim(cd_rb) & ") " _
        & " and doc='" & lbcp.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr)
        rb = ""
        'If tr.Rows.Count > 0 Then
        '    For j = 0 To tr.Rows.Count - 1
        '        rb = rb & tr.Rows(j).Item(0).ToString & vbCrLf
        '    Next
        'End If

        Dim ta5 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select moneda, rcpos, if(monloex='N','',monloex) as mon from ctas_x_pagar where doc='" & lbcp.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta5)
        Dim cp2() As String
        Dim cp3() As String
        Dim cp4() As String
        cp2 = Trim(ta5.Rows(0).Item("moneda")).Split(";")
        cp3 = Trim(ta5.Rows(0).Item("rcpos")).Split(";")
        cp4 = Trim(ta5.Rows(0).Item("mon")).Split(";")
       
        If tr.Rows.Count > 0 Then
            For j = 0 To tr.Rows.Count - 1
                If Int(cp3(j).ToString) <> 0 Then
                    rb = rb & "RUBRO:" & tr.Rows(j).Item(0).ToString & vbCrLf
                    ' "FUENTE: " & cp2(j).ToString & vbCrLf & _
                    ' "MONTO: " & MontoRubro(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf & _
                    '"SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                    'Try
                    '    rb = rb & "FUENTE: " & cp2(j).ToString & vbCrLf
                    'Catch ex As Exception
                    'End Try
                    Try
                        If Trim(cp2(j).ToString) <> "" Then
                            rb = rb & "FUENTE: " & cp2(j).ToString & vbCrLf
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        rb = rb & "MONTO: " & MontoRubro(Moneda(cp3(j).ToString.Replace(".", ","))) & vbCrLf
                    Catch ex As Exception
                    End Try
                    Try
                        If Trim(cp4(j).ToString) <> "" Then
                            rb = rb & "SECTOR: " & cp4(j).ToString & vbCrLf & vbCrLf
                        Else
                            rb = rb & vbCrLf
                        End If
                    Catch ex As Exception
                        rb = rb & vbCrLf
                    End Try
                End If
            Next
        End If


        'Catch ex As Exception
        '    rb = ""
        'End Try
        '.... FIRMAS...............................
        Dim t1 As String = ""
        Dim m1 As String = ""
        Dim f1 As String = ""
        Dim p1 As String = ""
        Dim t2 As String = ""
        Dim m2 As String = ""
        Dim f2 As String = ""
        Dim p2 As String = ""
        Dim t3 As String = ""
        Dim m3 As String = ""
        Dim f3 As String = ""
        Dim p3 As String = ""
        Dim t4 As String = ""
        Dim m4 As String = ""
        Dim f4 As String = ""
        Dim p4 As String = ""
        Dim t5 As String = ""
        Dim m5 As String = ""
        Dim f5 As String = ""
        Dim p5 As String = ""

        Dim tf As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT *  FROM parordenes  "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tf)
        If tf.Rows.Count <> 0 Then
            t1 = tf.Rows(0).Item("titulo1")
            m1 = tf.Rows(0).Item("msj1")
            f1 = tf.Rows(0).Item("firma1")
            p1 = tf.Rows(0).Item("pie1")
            t2 = tf.Rows(0).Item("titulo2")
            m2 = tf.Rows(0).Item("msj2")
            f2 = tf.Rows(0).Item("firma2")
            p2 = tf.Rows(0).Item("pie2")
            t3 = tf.Rows(0).Item("titulo3")
            m3 = tf.Rows(0).Item("msj3")
            f3 = tf.Rows(0).Item("firma3")
            p3 = tf.Rows(0).Item("pie3")
            t4 = tf.Rows(0).Item("titulo4")
            m4 = tf.Rows(0).Item("msj4")
            f4 = tf.Rows(0).Item("firma4")
            p4 = tf.Rows(0).Item("pie4")
            t5 = tf.Rows(0).Item("titulo5")
            m5 = tf.Rows(0).Item("msj5")
            f5 = txtnombre.Text
            p5 = "NIT/CC: " & txtnit.Text
        End If
        '............. Resolucion.............
        Dim tt As String = ""
        Dim cuer As String = ""
        Dim fir As String = ""
        Dim pie As String = ""
        Dim a1 As String = ""
        Dim ff As String = ""

        Dim ta3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM parreso ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta3)
        If ta3.Rows.Count > 0 Then
            tt = ta3.Rows(0).Item("titulo")
            cuer = "QUE: EL MUNICIPIO DE " & ta3.Rows(0).Item("municipio") & ", adeuda a: " & txtnombre.Text & ", portador del documento " _
            & " de identidad No " & txtnit.Text & ", segun concepto referente a: " & txtconcep.Text & ", y existe la disponibilidad presupuestal para atender el compromiso."
            fir = ta3.Rows(0).Item("firma")
            pie = ta3.Rows(0).Item("pie")
            ff = ff & "Dado en " & ta3.Rows(0).Item("municipio") & ", "
        End If
        a1 = "Páguese a: " & txtnombre.Text & ", portador del documento de identidad No. " & txtnit.Text & ". La suma de: " & lbpesos.Text & " $ " & txttotal.Text & " en atencion al considerando anterior."
        ff = ff & " el dia " & fecha.Text


        Dim tabl As DataSet
        tabl = New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac FROM parafacts WHERE factura='RAPIDA'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "parafacts")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT pagare as nomart FROM ctas_x_pagar WHERE doc='" & Doccxp & "';"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLegal
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportOrdenP.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim PrNite As New ParameterField
            Dim Prcomp As New ParameterField
            Dim Prord As New ParameterField
            Dim Prletra As New ParameterField
            '..
            Dim Prt1 As New ParameterField
            Dim Prm1 As New ParameterField
            Dim Prf1 As New ParameterField
            Dim Prp1 As New ParameterField
            '..
            Dim Prt2 As New ParameterField
            Dim Prm2 As New ParameterField
            Dim Prf2 As New ParameterField
            Dim Prp2 As New ParameterField
            '..
            Dim Prt3 As New ParameterField
            Dim Prm3 As New ParameterField
            Dim Prf3 As New ParameterField
            Dim Prp3 As New ParameterField
            '..
            Dim Prt4 As New ParameterField
            Dim Prm4 As New ParameterField
            Dim Prf4 As New ParameterField
            Dim Prp4 As New ParameterField
            '..
            Dim Prt5 As New ParameterField
            Dim Prm5 As New ParameterField
            Dim Prf5 As New ParameterField
            Dim Prp5 As New ParameterField
            '...
            Dim Prreso As New ParameterField
            Dim PrtitR As New ParameterField
            Dim Prcuer As New ParameterField
            Dim Pra1 As New ParameterField
            Dim Prfirm As New ParameterField
            Dim Prpief As New ParameterField
            Dim PrFec As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "rubr"
            PrNit.CurrentValues.AddValue(rb.ToString)
            PrNite.Name = "nit"
            PrNite.CurrentValues.AddValue(nite.ToString)
            Prcomp.Name = "comp"
            Prcomp.CurrentValues.AddValue(nom.ToString)
            Prord.Name = "tord"
            Prord.CurrentValues.AddValue("ORDEN DE PAGO N° " & PerActual & " - " & txtorden.Text & "")
            Prletra.Name = "letra"
            Prletra.CurrentValues.AddValue(lbpesos.Text.ToString)
            '...
            Prt1.Name = "t1"
            Prt1.CurrentValues.AddValue(t1)
            Prm1.Name = "msj1"
            Prm1.CurrentValues.AddValue(m1)
            Prf1.Name = "f1"
            Prf1.CurrentValues.AddValue(f1)
            Prp1.Name = "p1"
            Prp1.CurrentValues.AddValue(p1)
            '...
            Prt2.Name = "t2"
            Prt2.CurrentValues.AddValue(t2)
            Prm2.Name = "msj2"
            Prm2.CurrentValues.AddValue(m2)
            Prf2.Name = "f2"
            Prf2.CurrentValues.AddValue(f2)
            Prp2.Name = "p2"
            Prp2.CurrentValues.AddValue(p2)
            '...
            Prt3.Name = "t3"
            Prt3.CurrentValues.AddValue(t3)
            Prm3.Name = "msj3"
            Prm3.CurrentValues.AddValue(m3)
            Prf3.Name = "f3"
            Prf3.CurrentValues.AddValue(f3)
            Prp3.Name = "p3"
            Prp3.CurrentValues.AddValue(p3)
            '...
            Prt4.Name = "t4"
            Prt4.CurrentValues.AddValue(t4)
            Prm4.Name = "msj4"
            Prm4.CurrentValues.AddValue(m4)
            Prf4.Name = "f4"
            Prf4.CurrentValues.AddValue(f4)
            Prp4.Name = "p4"
            Prp4.CurrentValues.AddValue(p4)
            '...
            Prt5.Name = "t5"
            Prt5.CurrentValues.AddValue(t5)
            Prm5.Name = "msj5"
            Prm5.CurrentValues.AddValue(m5)
            Prf5.Name = "f5"
            Prf5.CurrentValues.AddValue(f5)
            Prp5.Name = "p5"
            Prp5.CurrentValues.AddValue(p5)

            '.. Reso
            Prreso.Name = "reso"
            Prreso.CurrentValues.AddValue(txtreso.Text.ToString)
            PrtitR.Name = "tit"
            PrtitR.CurrentValues.AddValue(tt)
            Prcuer.Name = "cuerpo"
            Prcuer.CurrentValues.AddValue(cuer)
            Pra1.Name = "a1"
            Pra1.CurrentValues.AddValue(a1)
            'Prfirm.Name = "firm"
            'Prfirm.CurrentValues.AddValue(fir)
            'Prpief.Name = "pief"
            'Prpief.CurrentValues.AddValue(pie)
            PrFec.Name = "fec"
            PrFec.CurrentValues.AddValue(ff)

            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prord)
            prmdatos.Add(Prletra)
            prmdatos.Add(Prt1)
            prmdatos.Add(Prm1)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prp1)
            prmdatos.Add(Prt2)
            prmdatos.Add(Prm2)
            prmdatos.Add(Prf2)
            prmdatos.Add(Prp2)
            prmdatos.Add(Prt3)
            prmdatos.Add(Prm3)
            prmdatos.Add(Prf3)
            prmdatos.Add(Prp3)
            prmdatos.Add(Prt4)
            prmdatos.Add(Prm4)
            prmdatos.Add(Prf4)
            prmdatos.Add(Prp4)
            prmdatos.Add(Prt5)
            prmdatos.Add(Prm5)
            prmdatos.Add(Prf5)
            prmdatos.Add(Prp5)

            prmdatos.Add(Prreso)
            prmdatos.Add(PrtitR)
            prmdatos.Add(Prcuer)
            prmdatos.Add(Pra1)
            'prmdatos.Add(Prfirm)
            prmdatos.Add(PrNite)
            prmdatos.Add(PrFec)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal pos As Integer, ByVal tam As Integer)
        Dim s As Integer = 1
        linea = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = " " And j > tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
                    linea = ""
                    k = k - 10
                    s = s + 1
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
    End Sub
    Public Sub Banner()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 807
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "REPUPBLICA DE COLOMBIA", 300, 807, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "DIVISION DE TESORERIA", 300, k, 0)
        k = k - 10
        If fecha.Value.Month < 10 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ORDEN DE PAGO NUMERO " & fecha.Value.Year & "0" & fecha.Value.Month & "-" & txtorden.Text, 300, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ORDEN DE PAGO NUMERO " & fecha.Value.Year & fecha.Value.Month & "-" & txtorden.Text, 300, k, 0)
        End If
        k = k - 10
    End Sub

    Private Sub txtcontra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontra.DoubleClick
        Try
            FrmSelecContraros.lbform.Text = "contra"
            FrmSelecContraros.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcontra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontra.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub txtcontra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontra.LostFocus
        
    End Sub
    Private Sub txtcontra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcontra.TextChanged
        Doccxp = ""
        If lbestado.Text = "CONSULTA" Then Exit Sub
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT *, (total - pagado) as bruto FROM ctas_x_pagar WHERE doc ='" & lbcp.Text & "' AND pagado<total;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtplazo.Text = tabla.Rows(0).Item("vmto").ToString
            txtconcep.Text = tabla.Rows(0).Item("descrip").ToString
            txttipo.Text = tabla.Rows(0).Item("ctaret").ToString
            Doccxp = tabla.Rows(0).Item("doc").ToString
            ' varios rubros
            Dim rb As String = ""
            Dim cad As String = ""
            Dim vc() As String
            rb = tabla.Rows(0).Item("ccosto").ToString
            If rb.Length <> rb.Replace(";", "").Length Then
                vc = rb.Split(";")
                For i = 0 To vc.Length - 1
                    If i = vc.Length - 1 Then
                        cad = cad & vc(i)
                    Else
                        cad = cad & vc(i) & vbCrLf
                    End If
                Next
            Else
                cad = tabla.Rows(0).Item("ccosto").ToString
            End If
            txtrubro.Text = cad
            txtrubro_TextChanged(AcceptButton, AcceptButton)
            txtdis.Text = tabla.Rows(0).Item("pagare").ToString
            txtnit.Text = tabla.Rows(0).Item("nitc").ToString
            txtnombre.Text = tabla.Rows(0).Item("nomnit").ToString
            Try
                txtbruto.Text = Moneda(CDbl(tabla.Rows(0).Item("bruto").ToString))
            Catch ex As Exception
                txtbruto.Text = Moneda("0")
            End Try
            Try
                txtiva.Text = Moneda(CDbl(tabla.Rows(0).Item("v_viva").ToString))
            Catch ex As Exception
                txtiva.Text = Moneda("0")
            End Try
            txtbase.Text = "0,00"
            Try
                txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
            Catch ex As Exception
            End Try
            BuscarDctos()
        Catch ex As Exception
            txtdis.Text = ""
            txtplazo.Text = ""
            txtconcep.Text = ""
            txttipo.Text = ""
            txtrubro.Text = ""
            txtrubro2.Text = ""
            txtdis.Text = ""
            txtnit.Text = ""
            txtnombre.Text = ""
            txtbruto.Text = Moneda("0")
            txtiva.Text = Moneda("0")
            Try
                grilla.Rows.Clear()
            Catch ex2 As Exception
            End Try
        End Try
        CalcularTotales()
    End Sub
    Public Sub BuscarContrato2()
        If txtorden.Text <> "" And txtdis.Text <> "" Then Exit Sub
        Doccxp = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT *, (total - pagado) as bruto FROM ctas_x_pagar WHERE pagare='" & txtdis.Text & "' AND pagado<total;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtplazo.Text = tabla.Rows(0).Item("vmto").ToString
            txtconcep.Text = tabla.Rows(0).Item("descrip").ToString
            txttipo.Text = tabla.Rows(0).Item("ctaret").ToString
            Doccxp = tabla.Rows(0).Item("doc").ToString
            ' varios rubros
            Dim rb As String = ""
            Dim cad As String = ""
            Dim vc() As String
            rb = tabla.Rows(0).Item("ccosto").ToString
            If rb.Length <> rb.Replace(";", "").Length Then
                vc = rb.Split(";")
                For i = 0 To vc.Length - 1
                    If i = vc.Length - 1 Then
                        cad = cad & vc(i)
                    Else
                        cad = cad & vc(i) & vbCrLf
                    End If
                Next
            Else
                cad = tabla.Rows(0).Item("ccosto").ToString
            End If
            txtrubro.Text = cad
            txtrubro_TextChanged(AcceptButton, AcceptButton)
            txtdis.Text = tabla.Rows(0).Item("pagare").ToString
            txtnit.Text = tabla.Rows(0).Item("nitc").ToString
            txtnombre.Text = tabla.Rows(0).Item("nomnit").ToString
            Try
                txtbruto.Text = Moneda(CDbl(tabla.Rows(0).Item("bruto").ToString))
            Catch ex As Exception
                txtbruto.Text = Moneda("0")
            End Try
            Try
                txtiva.Text = Moneda(CDbl(tabla.Rows(0).Item("v_viva").ToString))
            Catch ex As Exception
                txtiva.Text = Moneda("0")
            End Try
            txtbase.Text = "0,00"
            Try
                txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
            Catch ex As Exception
            End Try
            BuscarDctos()
        Catch ex As Exception

            txtdis.Text = ""
            txtplazo.Text = ""
            txtconcep.Text = ""
            txttipo.Text = ""
            txtrubro.Text = ""
            txtrubro2.Text = ""
            txtdis.Text = ""
            txtnit.Text = ""
            txtnombre.Text = ""
            txtbruto.Text = Moneda("0")
            txtiva.Text = Moneda("0")
            Try
                grilla.Rows.Clear()
            Catch ex2 As Exception
            End Try
        End Try
        CalcularTotales()
    End Sub
    Public Sub BuscarContrato()
        If txtorden.Text <> "" And txtdis.Text <> "" Then Exit Sub
        Doccxp = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT *, (total - pagado) as bruto FROM ctas_x_pagar WHERE doc='" & lbcp.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            txtplazo.Text = tabla.Rows(0).Item("vmto").ToString
            txtconcep.Text = tabla.Rows(0).Item("descrip").ToString
            txttipo.Text = tabla.Rows(0).Item("ctaret").ToString
            Doccxp = tabla.Rows(0).Item("doc").ToString
            ' varios rubros
            Dim rb As String = ""
            Dim cad As String = ""
            Dim vc() As String
            rb = tabla.Rows(0).Item("ccosto").ToString
            If rb.Length <> rb.Replace(";", "").Length Then
                vc = rb.Split(";")
                For i = 0 To vc.Length - 1
                    If i = vc.Length - 1 Then
                        cad = cad & vc(i)
                    Else
                        cad = cad & vc(i) & vbCrLf
                    End If
                Next
            Else
                cad = tabla.Rows(0).Item("ccosto").ToString
            End If
            txtrubro.Text = cad
            txtrubro_TextChanged(AcceptButton, AcceptButton)
            txtdis.Text = tabla.Rows(0).Item("pagare").ToString
            txtnit.Text = tabla.Rows(0).Item("nitc").ToString
            txtnombre.Text = tabla.Rows(0).Item("nomnit").ToString
            Try
                txtbruto.Text = Moneda(CDbl(tabla.Rows(0).Item("bruto").ToString))
            Catch ex As Exception
                txtbruto.Text = Moneda("0")
            End Try
            Try
                txtiva.Text = Moneda(CDbl(tabla.Rows(0).Item("v_viva").ToString))
            Catch ex As Exception
                txtiva.Text = Moneda("0")
            End Try
            txtbase.Text = "0,00"
            Try
                txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
            Catch ex As Exception
            End Try
            BuscarDctos()
        Catch ex As Exception

            txtdis.Text = ""
            txtplazo.Text = ""
            txtconcep.Text = ""
            txttipo.Text = ""
            txtrubro.Text = ""
            txtrubro2.Text = ""
            txtdis.Text = ""
            txtnit.Text = ""
            txtnombre.Text = ""
            txtbruto.Text = Moneda("0")
            txtiva.Text = Moneda("0")
            Try
                grilla.Rows.Clear()
            Catch ex2 As Exception
            End Try
        End Try
        CalcularTotales()
    End Sub
    Private Sub GenerarResol()
        BuscarPeriodo()

        Dim sql As String = ""
        Dim doc As String = ""
        Dim nit As String = ""
        Dim nom As String = ""
        Dim dir As String = ""
        Dim tel As String = ""
        Dim tt As String = ""
        Dim a1 As String = ""
        Dim cuer As String = ""
        Dim fir As String = ""
        Dim pie As String = ""
        Dim ff As String = ""

        MiConexion(bda)

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        dir = tabla2.Rows(0).Item("direccion")
        tel = tabla2.Rows(0).Item("telefono1") & "-" & tabla2.Rows(0).Item("telefono2")


        Dim t2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM parreso ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        If t2.Rows.Count > 0 Then
            tt = t2.Rows(0).Item("titulo")
            cuer = "QUE: EL MUNICIPIO DE " & t2.Rows(0).Item("municipio") & ", adeuda a: " & txtnombre.Text & ", portador del documento " _
            & " de identidad No " & txtnit.Text & ", segun concepto referente a: " & txtconcep.Text & ", y existe la disponibilidad presupuestal para atender el compromiso."
            fir = t2.Rows(0).Item("firma")
            pie = t2.Rows(0).Item("pie")
            ff = ff & "Dado en " & t2.Rows(0).Item("municipio") & ", "
        End If
        a1 = "Páguese a: " & txtnombre.Text & ", portador del documento de identidad No. " & txtnit.Text & ". La suma de: " & lbpesos.Text & " $ " & txttotal.Text & " en atencion al considerando anterior."
        ff = ff & "a los " & Now.Day & " dias del mes " & Now.Month & " de " & Now.Year


        '.... REPORTE.......
        Dim tr As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT ctaretica as nomart FROM ctas_x_pagar WHERE doc='" & Doccxp & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr, "detafac01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac FROM parafacts WHERE factura='RAPIDA'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tr, "parafacts")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportOrdResol.rpt")
        CrReport.SetDataSource(tr)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            Dim Prord As New ParameterField
            Dim Prletra As New ParameterField
            Dim Prt1 As New ParameterField
            Dim Prm1 As New ParameterField
            Dim Prf1 As New ParameterField
            Dim Prcom As New ParameterField
            Dim Prni As New ParameterField
            Dim Prdir As New ParameterField
            Dim Prtelf As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "reso"
            PrNit.CurrentValues.AddValue(txtreso.Text.ToString)
            Prcomp.Name = "tit"
            Prcomp.CurrentValues.AddValue(tt)
            Prord.Name = "cuerpo"
            Prord.CurrentValues.AddValue(cuer)
            Prletra.Name = "a1"
            Prletra.CurrentValues.AddValue(a1)
            Prt1.Name = "firm"
            Prt1.CurrentValues.AddValue(fir)
            Prm1.Name = "pief"
            Prm1.CurrentValues.AddValue(pie)
            Prf1.Name = "fec"
            Prf1.CurrentValues.AddValue(ff)
            Prcom.Name = "comp"
            Prcom.CurrentValues.AddValue(nom)
            Prni.Name = "nitc"
            Prni.CurrentValues.AddValue("NIT " & nit)
            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue("Direccion: " & dir)
            Prtelf.Name = "tel"
            Prtelf.CurrentValues.AddValue("Telefono " & tel)

            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prord)
            prmdatos.Add(Prletra)
            prmdatos.Add(Prt1)
            prmdatos.Add(Prm1)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prcom)
            prmdatos.Add(Prni)
            prmdatos.Add(Prdir)
            prmdatos.Add(Prtelf)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub

    Public Sub CalcularTotales()
        Try
            txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
        Catch ex As Exception
        End Try
        Dim db As Double = 0
        Dim cr As Double = 0
        Dim sdb As Double = 0
        Dim scr As Double = 0
        For i = 0 To grilla.RowCount - 1
            Try
                db = CDbl(grilla.Item("Debitos", i).Value.ToString)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cr = CDbl(grilla.Item("Creditos", i).Value.ToString)
            Catch ex As Exception
                cr = 0
            End Try
            sdb = sdb + db
            scr = scr + cr
        Next
        Try
            txttotal.Text = Moneda(CDbl(txtbruto.Text) + sdb - scr)
        Catch ex As Exception

        End Try
        lbpesos.Text = "SON " & Num2Text(txttotal.Text)
    End Sub
    Public Sub BuscarDctos()
        Try
            Dim tabla As New DataTable
            Dim sql As String = ""
            sql = "SELECT * FROM presupuesto" & a & ".detatipcontrato  " _
            & "WHERE tic_codigo ='" & txttipo.Text & "';"

            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Try
                grilla.Rows.Clear()
                grilla.RowCount = tabla.Rows.Count + 1
            Catch ex As Exception
            End Try
            'MsgBox("Cantidad " & tabla.Rows.Count)
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows.Count = 0 Then Exit For
                grilla.Item("cta", i).Value = tabla.Rows(i).Item("detc_ctaconta").ToString
                grilla.Item("Descripcion", i).Value = tabla.Rows(i).Item("detc_nombre").ToString
                grilla.Item("tipo", i).Value = tabla.Rows(i).Item("detc_tmov").ToString
                Try
                    grilla.Item("porc", i).Value = CDbl(tabla.Rows(i).Item("detc_porcentaje").ToString)
                Catch ex As Exception
                    grilla.Item("porc", i).Value = "0"
                    'MsgBox("2 ==>" & ex.ToString)
                End Try
                If grilla.Item("tipo", i).Value.ToString = "CR" Then
                    Try
                        grilla.Item("Debitos", i).Value = Moneda("0")
                        grilla.Item("Creditos", i).Value = Moneda("0")
                        'MsgBox(txtbase.Text & " x " & tabla.Rows(i).Item("detc_porcentaje").ToString & " / 100")
                        grilla.Item("Creditos", i).Value = Moneda(CDbl(txtbase.Text) * CDbl(tabla.Rows(i).Item("detc_porcentaje").ToString) / 100)
                    Catch ex As Exception
                        MsgBox("3 ==>" & ex.ToString)
                    End Try
                Else
                    Try
                        grilla.Item("Debitos", i).Value = Moneda("0")
                        grilla.Item("Creditos", i).Value = Moneda("0")
                        grilla.Item("Debitos", i).Value = Moneda(CDbl(txtbase.Text) * CDbl(grilla.Item("porc", i).Value) / 100)
                    Catch ex As Exception
                        MsgBox("4 ==>" & ex.ToString)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox("1 ==>" & ex.ToString)
        End Try
    End Sub

    Private Sub txtrubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrubro.TextChanged

        Dim cd_rb As String = ""
        Dim rb As String = ""
        Dim crb As String = ""

        Dim cp() As String
        cp = txtrubro.Text.Split(Chr(Keys.Enter))
       
        For i = 0 To cp.Length - 1
            If i = 0 Then
                cd_rb = "'" & Trim(cp(i)) & "'"

            ElseIf Trim(cp(i)) <> "" Then
                cd_rb = Trim(cd_rb) & ",'" & Trim(cp(i)) & "'"
            End If
        Next

        cd_rb = cd_rb.Replace(Chr(10), "")

        'Try
        txtrubro2.Text = ""
        If cd_rb <> "" Then
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT gasc_cod1,gasc_concepto FROM presupuesto" & a & ".gasconcepto WHERE gasc_cod1 IN(" & Trim(cd_rb) & ") ORDER BY " & Trim(cd_rb) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            rb = ""
            crb = ""
            If tabla.Rows.Count > 0 Then
                For j = 0 To tabla.Rows.Count - 1
                    rb = rb & tabla.Rows(j).Item("gasc_concepto").ToString & vbCrLf
                    crb = crb & tabla.Rows(j).Item("gasc_cod1").ToString & vbCrLf
                Next
            End If
            txtnomrubro.Text = rb
            txtrubro2.Text = crb
        End If
        'Catch ex As Exception
        '    txtnomrubro.Text = ""
        'End Try
    End Sub
    Private Sub txtorden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtorden.KeyPress
        validarnumero(txtorden, e)
    End Sub
    Private Sub txtorden_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtorden.LostFocus
        txtorden.Text = NumeroDoc(Val(txtorden.Text))
        Dim tbo As New DataTable
        myCommand.CommandText = "SELECT * FROM ord_pagos WHERE doc ='" & Trim(lbper.Text & "-" & txtorden.Text) & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbo)
        If tbo.Rows.Count > 0 Then
            MsgBox("El codigo de la orden ya ha sido utilizado, Verifique", MsgBoxStyle.Information, "Verificacion")
            txtorden.Text = "00000"
            Exit Sub
        End If

    End Sub
    '***********************************
    Public Sub CalcularDetalles()
        txtbase.Text = Moneda(CDbl(txtbruto.Text) - CDbl(txtiva.Text))
        For i = 0 To grilla.RowCount - 1
            Try
                If grilla.Item("tipo", i).Value.ToString = "CR" Then
                    Try
                        grilla.Item("Debitos", i).Value = Moneda("0")
                        grilla.Item("Creditos", i).Value = Moneda("0")
                        grilla.Item("Creditos", i).Value = Moneda(CDbl(txtbase.Text) * CDbl(grilla.Item("porc", i).Value) / 100)
                    Catch ex As Exception
                        MsgBox("3 ==>" & ex.ToString)
                    End Try
                Else
                    Try
                        grilla.Item("Debitos", i).Value = Moneda("0")
                        grilla.Item("Creditos", i).Value = Moneda("0")
                        grilla.Item("Debitos", i).Value = Moneda(CDbl(txtbase.Text) * CDbl(grilla.Item("porc", i).Value) / 100)
                    Catch ex As Exception
                        MsgBox("4 ==>" & ex.ToString)
                    End Try
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub txtbruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbruto.KeyPress
        ValidarMoneda(txtbruto, e)
    End Sub
    Private Sub txtbruto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtbruto.LostFocus
        txtbruto.Text = Moneda(txtbruto.Text)
        CalcularDetalles()
        CalcularTotales()
    End Sub
    Private Sub txtiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiva.KeyPress
        ValidarMoneda(txtiva, e)
    End Sub
    Private Sub txtiva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtiva.LostFocus
        txtiva.Text = Moneda(txtiva.Text)
        CalcularDetalles()
        CalcularTotales()
    End Sub

    Private Sub cmdCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCE.Click
        If lbestado.Text = "NULO" Or lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "ELIMINADO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        Try
            FrmNuevoEgreso.lbdoc.Text = PerActual & "-" & txtorden.Text
            FrmNuevoEgreso.lbper2.Text = PerActual
            FrmNuevoEgreso.lbperiodo.Text = lbper2.Text
            FrmNuevoEgreso.txtorden.Text = txtorden.Text
            FrmNuevoEgreso.fecha.Value = fecha.Value
            'FrmNuevoEgreso.txtdis.Text = txtdis.Text
            FrmNuevoEgreso.txtcontra.Text = txtcontra.Text
            FrmNuevoEgreso.txtplazo.Text = txtplazo.Text
            FrmNuevoEgreso.txttipo.Text = txttipo.Text
            FrmNuevoEgreso.txtnit.Text = txtnit.Text
            FrmNuevoEgreso.txtnombre.Text = txtnombre.Text
            FrmNuevoEgreso.lbdv.Text = lbdv.Text
            FrmNuevoEgreso.txtconcep.Text = txtconcep.Text
            FrmNuevoEgreso.txtrubro.Text = txtrubro.Text
            FrmNuevoEgreso.txtnomrubro.Text = txtnomrubro.Text
            FrmNuevoEgreso.txttotal.Text = txttotal.Text
            FrmNuevoEgreso.lbpesos.Text = lbpesos.Text
            FrmNuevoEgreso.fechace.MinDate = fecha.Value
            FrmNuevoEgreso.fechace.Value = fecha.Value
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT estado FROM ord_pagos WHERE doc='" & PerActual & "-" & txtorden.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            'BuscarActualCE()
            BuscarVigencia()
            If Trim(tabla.Rows(0).Item("estado").ToString) <> "" Then
                FrmNuevoEgreso.CmdListo.Enabled = False
                FrmNuevoEgreso.CmdCancelar.Enabled = False
                FrmNuevoEgreso.cmdprint.Enabled = True
                Try
                    Dim v() As String
                    v = txtdoc.Text.Split("-")
                    FrmNuevoEgreso.lbperiodo.Text = v(0)
                    FrmNuevoEgreso.txtce.Text = Strings.Right(v(1), v(1).Length - 2)
                    BuscarCE(v(0), v(1))
                Catch ex As Exception
                    FrmNuevoEgreso.txtce.Text = ""
                End Try

                FrmNuevoEgreso.fechace.Value = fecha.Value
                FrmNuevoEgreso.gce.Enabled = False
            Else
                FrmNuevoEgreso.CmdListo.Enabled = True
                FrmNuevoEgreso.CmdCancelar.Enabled = True
                FrmNuevoEgreso.cmdprint.Enabled = False
                FrmNuevoEgreso.gce.Enabled = True
                FrmNuevoEgreso.txtvig.Text = ""
                FrmNuevoEgreso.txtcta.Text = ""
                FrmNuevoEgreso.txtcheque.Text = ""
                FrmNuevoEgreso.txtordenador.Text = ""
                FrmNuevoEgreso.txtcontador.Text = ""
                BuscarContador()
            End If
            Try
                FrmNuevoEgreso.grilla.Rows.Clear()
            Catch ex As Exception
            End Try
            FrmNuevoEgreso.grilla.RowCount = grilla.RowCount + 5
            Dim j As Integer = 0
            '*********************************************
            FrmNuevoEgreso.grilla.Item("Cuenta", j).Value = ""
            FrmNuevoEgreso.grilla.Item("Debitos", j).Value = "0"
            FrmNuevoEgreso.grilla.Item("Creditos", j).Value = txttotal.Text
            FrmNuevoEgreso.grilla.Item("Descripcion", j).Value = "ORDEN DE PAGO " & PerActual & "-" & txtorden.Text
            FrmNuevoEgreso.grilla.Item("Base", j).Value = "0"
            FrmNuevoEgreso.grilla.Item("doc_afe", j).Value = ""
            FrmNuevoEgreso.grilla.Item("editar", j).Value = "si"
            FrmNuevoEgreso.grilla.Item("DocAnti", j).Value = ""
            FrmNuevoEgreso.grilla.Item("abonado", j).Value = "0"
            '**********************************************
            For i = 0 To grilla.RowCount - 1
                j = i + 1
                FrmNuevoEgreso.grilla.Item("Cuenta", j).Value = grilla.Item("cta", i).Value
                FrmNuevoEgreso.grilla.Item("Debitos", j).Value = grilla.Item("Debitos", i).Value
                FrmNuevoEgreso.grilla.Item("Creditos", j).Value = grilla.Item("Creditos", i).Value
                FrmNuevoEgreso.grilla.Item("Descripcion", j).Value = grilla.Item("Descripcion", i).Value
                FrmNuevoEgreso.grilla.Item("Base", j).Value = txtbase.Text
                FrmNuevoEgreso.grilla.Item("doc_afe", j).Value = ""
                FrmNuevoEgreso.grilla.Item("editar", j).Value = "no"
                FrmNuevoEgreso.grilla.Item("DocAnti", j).Value = ""
                FrmNuevoEgreso.grilla.Item("abonado", j).Value = "0"
            Next
            j = j + 1
            '*********************************************
            FrmNuevoEgreso.grilla.Item("Cuenta", j).Value = BuscarCta()
            FrmNuevoEgreso.grilla.Item("Debitos", j).Value = txtbruto.Text
            FrmNuevoEgreso.grilla.Item("Creditos", j).Value = "0"
            FrmNuevoEgreso.grilla.Item("Descripcion", j).Value = "ORDEN DE PAGO " & PerActual & "-" & txtorden.Text
            FrmNuevoEgreso.grilla.Item("Base", j).Value = "0"
            FrmNuevoEgreso.grilla.Item("doc_afe", j).Value = BuscarDocAfe()
            FrmNuevoEgreso.grilla.Item("editar", j).Value = "no"
            FrmNuevoEgreso.grilla.Item("DocAnti", j).Value = ""
            FrmNuevoEgreso.grilla.Item("abonado", j).Value = txtbruto.Text
            '*********************************************************************
            VBruto = ""
            VBruto = txtbruto.Text
            Try
                FrmNuevoEgreso.ShowDialog()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MsgBox("Error al intententar modificar el registro " & ex.ToString, MsgBoxStyle.Information, "SAE Control de Errores")
        End Try
    End Sub
    Public VBruto, Doccxp As String
    Public Sub BuscarCE(ByVal per As String, ByVal doc As String)
        Try
            Dim v() As String
            v = per.Split("/")
            Dim b As String = "sae" & FrmPrincipal.lbcompania.Text & v(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & b & ".ot_cpp" & v(0) & " WHERE doc='" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            FrmNuevoEgreso.txtvig.Text = tabla.Rows(0).Item("doc_anti").ToString
            FrmNuevoEgreso.txtcta.Text = tabla.Rows(0).Item("codigo").ToString
            FrmNuevoEgreso.txtcheque.Text = tabla.Rows(0).Item("cheque").ToString
            FrmNuevoEgreso.txtbanco.Text = tabla.Rows(0).Item("banco").ToString
            BuscarBanco(tabla.Rows(0).Item("codigo").ToString)
            Try
                FrmNuevoEgreso.fechace.Value = CDate(v(1) & "-" & v(0) & "-" & tabla.Rows(0).Item("dia").ToString)
            Catch ex As Exception

            End Try
            FrmNuevoEgreso.txtordenador.Text = tabla.Rows(0).Item("revisado").ToString
            FrmNuevoEgreso.txtcontador.Text = tabla.Rows(0).Item("contabilizado").ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BuscarBanco(ByVal ban As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM bancos WHERE codigo='" & ban & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            FrmNuevoEgreso.txtctab.Text = tabla.Rows(0).Item("num_cta").ToString
        Catch ex As Exception
            FrmNuevoEgreso.txtctab.Text = ""
        End Try
    End Sub
    Public Sub BuscarActualCE(ByVal per As String)
        Try
            Dim ta As New DataTable
            myCommand.CommandText = "SELECT doc_cpp FROM par_comp ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            If ta.Rows.Count = 0 Then
                MsgBox("Verifique el tipo de documento a usar en la tabla par_comp (doc_cpp)", MsgBoxStyle.Information, "SAE")
                Me.Close()
            End If
            
            'If lbestado.Text = "NUEVO" Then
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT tipodoc, descripcion, actual" & per & ", grupo, actualfc FROM tipdoc WHERE tipodoc='" & ta.Rows(0).Item(0) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para los comprobantes de egresos (del grupo CE), verifique.   ", MsgBoxStyle.Information, "Verificando")
                'Me.Close()
            Else
                FrmNuevoEgreso.lbdes.Text = tabla2.Rows(0).Item("descripcion").ToString
                FrmNuevoEgreso.lbtipodoc.Text = tabla2.Rows(0).Item("tipodoc").ToString

                If tabla2.Rows(0).Item("grupo").ToString = "FC" Then
                    Try
                        'MsgBox(NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1))
                        FrmNuevoEgreso.txtce.Text = NumeroDoc(Val(tabla2.Rows(0).Item("actualfc").ToString) + 1)
                    Catch ex As Exception
                        FrmNuevoEgreso.txtce.Text = NumeroDoc(1)
                    End Try
                Else
                    Try
                        'MsgBox(NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1))
                        FrmNuevoEgreso.txtce.Text = NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1)
                    Catch ex As Exception
                        FrmNuevoEgreso.txtce.Text = NumeroDoc(1)
                    End Try
                End If
               
            End If
                ' End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub BuscarVigencia()
        Try
            'If lbestado.Text = "NUEVO" Then
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT con_vigencia FROM presupuesto" & a & ".contratos WHERE con_numero='" & txtcontra.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            FrmNuevoEgreso.txtvig.Text = tabla2.Rows(0).Item("con_vigencia").ToString
            ' End If
        Catch ex As Exception
            FrmNuevoEgreso.txtvig.Text = ""
        End Try

    End Sub
    Public Sub BuscarContador()
        Try
            'If lbestado.Text = "NUEVO" Then
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT contador,rlegal FROM sae.companias WHERE login='" & FrmPrincipal.lbcompania.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            FrmNuevoEgreso.txtordenador.Text = tabla2.Rows(0).Item("rlegal").ToString
            FrmNuevoEgreso.txtcontador.Text = tabla2.Rows(0).Item("contador").ToString

        Catch ex As Exception
            'MsgBox(ex.ToString)
            FrmNuevoEgreso.txtcontador.Text = ""
        End Try
    End Sub
    Function BuscarCta()
        Dim cta As String = ""
        Try
            'If lbestado.Text = "NUEVO" Then
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT ctatotal FROM ctas_x_pagar  WHERE doc_ext ='" & txtcontra.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            cta = tabla2.Rows(0).Item("ctatotal").ToString
        Catch ex As Exception
            cta = ""
        End Try
        Return cta
    End Function
    Function BuscarDocAfe()
        Dim cta As String = ""
        Try
            'If lbestado.Text = "NUEVO" Then
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT doc FROM ctas_x_pagar  WHERE doc_ext ='" & txtcontra.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            cta = tabla2.Rows(0).Item("doc").ToString
        Catch ex As Exception
            cta = ""
        End Try
        Return cta
    End Function

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged

    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        If txtcontra.Text <> "" Then


            Select Case e.ColumnIndex
                Case 0 'CASO CUENTA
                    Buscarcuentas(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
                    If grilla.Item(0, e.RowIndex).Value <> "" Then
                        grilla.Item("Debitos", e.RowIndex).Value = Moneda(0)
                        grilla.Item("Creditos", e.RowIndex).Value = Moneda(0)
                    Else
                        grilla.Item("Debitos", e.RowIndex).Value = ""
                        grilla.Item("Creditos", e.RowIndex).Value = ""
                        grilla.Item("Descripcion", e.RowIndex).Value = ""
                    End If
                Case 2
                    If grilla.Item("Debitos", e.RowIndex).Value <> "" Then
                        Try
                            grilla.Item("Debitos", e.RowIndex).Value = Moneda(grilla.Item("Debitos", e.RowIndex).Value)
                            CalcularTotales()
                        Catch ex As Exception
                            grilla.Item("Debitos", e.RowIndex).Value = ""
                        End Try
                    End If
                Case 3
                    Try
                        grilla.Item("Creditos", e.RowIndex).Value = Moneda(grilla.Item("Creditos", e.RowIndex).Value)
                        CalcularTotales()
                    Catch ex As Exception
                        grilla.Item("Creditos", e.RowIndex).Value = ""
                    End Try
                Case 4
                    Try
                        grilla.Item("porc", e.RowIndex).Value = Moneda(grilla.Item("porc", e.RowIndex).Value)
                        If grilla.Item("Creditos", e.RowIndex).Value <> Moneda(0) Then
                            grilla.Item("Creditos", e.RowIndex).Value = CDbl(txtbase.Text) * (CDbl(grilla.Item("porc", e.RowIndex).Value) / 100)
                        ElseIf grilla.Item("Debitos", e.RowIndex).Value <> Moneda(0) Then
                            grilla.Item("Debitos", e.RowIndex).Value = CDbl(txtbase.Text) * (CDbl(grilla.Item("porc", e.RowIndex).Value) / 100)
                        ElseIf grilla.Item("Debitos", e.RowIndex).Value = Moneda(0) And grilla.Item("Debitos", e.RowIndex).Value = Moneda(0) Then
                            grilla.Item("Creditos", e.RowIndex).Value = CDbl(txtbase.Text) * (CDbl(grilla.Item("porc", e.RowIndex).Value) / 100)
                        End If
                        CalcularTotales()
                    Catch ex As Exception
                        grilla.Item("porc", e.RowIndex).Value = ""
                    End Try
            End Select
        End If
        CalcularTotales()
    End Sub
    Private Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ordenPG"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & Trim(cuenta) & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If grilla.Item(0, fila).Value = "" Or FrmEntradaDatos.nivel_cuenta(grilla.Item(0, fila).Value) = True Then
                    grilla.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "ordenPG"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    SendKeys.Send(Chr(Keys.Tab))
                    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                    resultado = MsgBox("La cuenta (" & grilla.Item(0, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                    If resultado = MsgBoxResult.Yes Then
                        FrmNuevaCuenta.txtcuenta.Text = grilla.Item(0, fila).Value
                        grilla.Item(0, fila).Value = ""
                        FrmNuevaCuenta.lbfila.Text = fila
                        FrmNuevaCuenta.ShowDialog()
                    Else
                        grilla.Item(0, fila).Value = ""
                    End If
                End If
            Else
                grilla.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
                grilla.Item(1, fila).Selected = True
            End If
        End If

    End Sub

    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        'Select Case e.ColumnIndex
        '    Case 0 'CASO CUENTA
        '        'validarnumero(grilla.Item(0, e.RowIndex).Value, e)
        '        'Buscarcuentas(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
        '        If grilla.Item(0, e.RowIndex).Value <> "" Then Exit Sub
        '        SendKeys.Send(Chr(Keys.Space))
        '        SendKeys.Send(Chr(Keys.Back))
        'End Select
    End Sub
    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyCode = 8 Then
                If fila = grilla.RowCount - 1 Then Exit Sub
                QuitarFila(fila)
            ElseIf e.KeyCode = "13" Then
                e.Handled = True
                SendKeys.Send(Chr(Keys.Tab))
            End If
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)

        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
        CalcularTotales()
    End Sub
    Public fila As Integer
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If Trim(txtnit.Text) = "" Then
            Try
                FrmSelCliente.lbform.Text = "Orden"
                FrmSelCliente.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            Dim tb As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnit.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            Try
                If tb.Rows.Count = 0 Then
                    txtnit.Text = ""
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula del proveedor no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.lbform.Text = "ORDEN"
                        frmterceros.txtnit.Text = txtnit.Text
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTE"
                        frmterceros.rbnatural.Checked = True
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    End If
                    'FrmSelCliente.lbform.Text = "Orden"
                    'FrmSelCliente.ShowDialog()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub txtorden_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtorden.TextChanged

    End Sub

    Private Sub g1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles g1.Enter

    End Sub

    Private Sub txtdis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdis.TextChanged
        'BuscarContrato2()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Try
                FrmSelecContraros.lbform.Text = "contra"
                FrmSelecContraros.ShowDialog()
                txtcontra_TextChanged(AcceptButton, AcceptButton)
            Catch ex As Exception

            End Try
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
End Class