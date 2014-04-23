Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class FrmEditarConteo
    Private Sub FrmEditarConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbdoc.Text = ""
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub
    Private Sub ChRep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChRep.CheckedChanged
        If ChRep.Checked = False Then
            ChDif.Checked = False
        End If
    End Sub
    Private Sub ChDif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChDif.CheckedChanged
        If ChRep.Checked = False Then
            ChDif.Checked = False
        End If
    End Sub
    '*********************************************************
    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        If FrmConteoFisInv.rbsi.Checked = True Then

        Else
            If ChRep.Checked = True Then

            End If
            Me.Close()
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
    '****************** PDF ***********************************
    Public col, fila As Integer
    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
        Try
            Select Case e.ColumnIndex
                Case 7 'CASO PRECIO                   
                    GuardarFila(fila, col)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 4 'CASO PRECIO                   
                    gitems.Item(4, e.RowIndex).Value = Moneda(gitems.Item(4, e.RowIndex).Value)

            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
    End Sub

    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = "13" And col = 7 Then
            GuardarFila(fila, col)
        End If
    End Sub
    Public Sub GuardarFila(ByVal f As Integer, ByVal c As Integer)
        If (Moneda(gitems.Item(3, f).Value) = Moneda(gitems.Item(4, f).Value)) Then
            MsgBox("no ha modificado la cantidad...", MsgBoxStyle.Information)
        Else
            Dim cant As Double
            cant = CDbl(gitems.Item(3, f).Value) - CDbl(gitems.Item(4, f).Value)
            If cant > 0 Then 'hay menos ej: 10-8=2 
                AjusteInv(f, c, cant, "SALIDA") ' ajuste por salida
            Else  'hay mas ej:8-10= -2
                cant = cant * (-1)
                AjusteInv(f, c, cant, "ENTRADA") ' ajuste por entrada
            End If
        End If
    End Sub
    Public Sub AjusteInv(ByVal f As Integer, ByVal c As Integer, ByVal cant As Double, ByVal tipo As String)
        MiConexion(bda)
        Try
            NewDoc()
            Dim total As Double
            total = CDbl(gitems.Item("costo", f).Value) * cant
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            GuardarFactura(tipo, total)
            ActualizarCon()
            GuardarDetalles(f, tipo, cant, total)
            GuardarEnBodega(f, tipo, cant)
            If tipo = "ENTRADA" Then
                InsertContabilidad(f, "documentos" & PerActual(0) & PerActual(1), tipo, gitems.Item("ctainv", f).Value, total, 0)
                InsertContabilidad(f, "documentos" & PerActual(0) & PerActual(1), tipo, gitems.Item("ctacos", f).Value, 0, total)
            Else
                InsertContabilidad(f, "documentos" & PerActual(0) & PerActual(1), tipo, gitems.Item("ctacos", f).Value, total, 0)
                InsertContabilidad(f, "documentos" & PerActual(0) & PerActual(1), tipo, gitems.Item("ctainv", f).Value, 0, total)
            End If
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("INVENTARIO", "EDITAR CONTEO FISICO", "CANTIDAD", gitems.Item("cantlibro", f).Value, gitems.Item("cantfisica", f).Value)
            End If
            gitems.Item("cantlibro", f).Value = gitems.Item("cantfisica", f).Value
            MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
        Cerrar()
    End Sub
    Public Sub NewDoc()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT ajustes FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("No ha seleccionado tipo de documento para los ajustes.", MsgBoxStyle.Information, "SAE Control")
        Else
            lbdoc.Text = tabla.Rows(0).Item(0).ToString
            lbtipo.Text = tabla.Rows(0).Item(0).ToString
            Dim t As New DataTable
            If Today.Day < 10 Then
                txtdia.Text = "0" & Today.Day
            Else
                txtdia.Text = Today.Day
            End If
            txtperiodo.Text = "/" & PerActual
            Try
                Dim fe As Date = CDate(txtdia.Text & "/" & txtperiodo.Text)
            Catch ex As Exception
                If PerActual(0) & PerActual(1) = "02" Then
                    txtdia.Text = "28"
                Else
                    txtdia.Text = "30"
                End If
            End Try
            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT actual" & PerActual(0) & PerActual(1) & " FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t)
                If Val(t.Rows(0).Item(0).ToString) = 0 Then
                    lbdoc.Text = lbdoc.Text & NumeroDoc(1)
                    lbnum.Text = NumeroDoc(1)
                Else
                    lbdoc.Text = lbdoc.Text & NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                    lbnum.Text = NumeroDoc(Val(t.Rows(0).Item(0).ToString) + 1)
                End If
            Catch ex As Exception
                lbdoc.Text = lbdoc.Text & NumeroDoc(1)
                lbnum.Text = NumeroDoc(1)
            End Try
        End If
    End Sub
    Public Sub GuardarFactura(ByVal tipo As String, ByVal total As Double)
        Try
            ' MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", lbdoc.Text)
            myCommand.Parameters.AddWithValue("?tipo_doc", lbtipo.Text.ToString)
            myCommand.Parameters.AddWithValue("?num", Val(lbnum.Text.ToString))
            myCommand.Parameters.AddWithValue("?per", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
            myCommand.Parameters.AddWithValue("?hora", CambiaCadena(Now.TimeOfDay.ToString, 10))
            myCommand.Parameters.AddWithValue("?nitc", "0")
            myCommand.Parameters.AddWithValue("?tipo_mov", "A")
            myCommand.Parameters.AddWithValue("?tipo", tipo)
            myCommand.Parameters.AddWithValue("?tipo_sal", tipo)
            myCommand.Parameters.AddWithValue("?cc", 0)
            myCommand.Parameters.AddWithValue("?concepto", "AJUSTE POR CONTEO FISICO")
            myCommand.Parameters.AddWithValue("?o_compra", "")
            myCommand.Parameters.AddWithValue("?n_pedido", "")
            myCommand.Parameters.AddWithValue("?observ", "")
            myCommand.Parameters.AddWithValue("?total", DIN(Moneda(total)))
            myCommand.Parameters.AddWithValue("?estado", "AP")
            myCommand.CommandText = "INSERT INTO movimientos" & PerActual(0) & PerActual(1) & " " _
                                  & " Values(?doc,?tipo_doc,?num,?per,?dia,?hora,?nitc,?tipo_mov,?tipo,?tipo_sal,?cc,?concepto,?o_compra,?n_pedido,?observ,?total,?estado);"
            'MsgBox(myCommand.CommandText.ToString)
            myCommand.ExecuteNonQuery()
            '*********************************************                     
        Catch ex As Exception
            'Cerrar()
            MsgBox("Error al intentar guardar el registro. Intentelo nuevamente." & ex.ToString, MsgBoxStyle.Information, "SAE Control")
        End Try
    End Sub
    Public Sub ActualizarCon()
        Dim campo As String = "actual" & PerActual(0) & PerActual(1)
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT " & campo & " FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            If Val(lbnum.Text) > Val(tabla.Rows(0).Item(0)) Then
                myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(lbnum.Text) & " WHERE tipodoc='" & lbtipo.Text & "';"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            myCommand.CommandText = "UPDATE tipdoc SET " & campo & "=" & Val(lbnum.Text) & " WHERE tipodoc='" & lbtipo.Text & "';"
            myCommand.ExecuteNonQuery()
        End Try
    End Sub
    Public Sub GuardarDetalles(ByVal fila As Integer, ByVal tipo As String, ByVal cant As Double, ByVal total As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?codart", gitems.Item("codigo", fila).Value)
        myCommand.Parameters.AddWithValue("?nomart", gitems.Item("descripcion", fila).Value)
        If tipo = "ENTRADAS" Or tipo = "ENTRADA" Then
            myCommand.Parameters.AddWithValue("?bod_ori", "0")
            myCommand.Parameters.AddWithValue("?bod_des", lbnumbod.Text)
        Else
            myCommand.Parameters.AddWithValue("?bod_ori", lbnumbod.Text)
            myCommand.Parameters.AddWithValue("?bod_des", "0")
        End If
        myCommand.Parameters.AddWithValue("?cantidad", DIN(Moneda(cant)))
        myCommand.Parameters.AddWithValue("?valor", DIN(Moneda(total)))
        '****************************************************************************************
        myCommand.Parameters.AddWithValue("?cta_inv", gitems.Item("ctainv", fila).Value)
        myCommand.Parameters.AddWithValue("?cta_cos", gitems.Item("ctacos", fila).Value)
        myCommand.Parameters.AddWithValue("?cta_ing", " ")
        myCommand.Parameters.AddWithValue("?cta_iva", " ")
        Try
            myCommand.Parameters.AddWithValue("?costo", DIN(gitems.Item("costo", fila).Value))
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?costo", "0")
        End Try
        myCommand.CommandText = "INSERT INTO deta_mov" & PerActual(0) & PerActual(1) & " " _
        & " Values(?doc,?item,?codart,?nomart,?bod_ori,?bod_des,?cantidad,?valor,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo);"
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub GuardarEnBodega(ByVal fila As Integer, ByVal tipo As String, ByVal cant As Double)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codart", gitems.Item("codigo", fila).Value)
        If tipo = "ENTRADA" Then
            myCommand.Parameters.AddWithValue("?numbod", "0")
        Else
            myCommand.Parameters.AddWithValue("?numbod", lbnumbod.Text)
        End If
        myCommand.Parameters.AddWithValue("?cantidad", DIN(Moneda(cant)))
        If tipo = "ENTRADA" Then
            myCommand.CommandText = "UPDATE con_inv SET cant" & lbnumbod.Text & "=cant" & lbnumbod.Text & " + ?cantidad " _
               & " WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
        Else
            myCommand.CommandText = "UPDATE con_inv SET cant" & lbnumbod.Text & "=cant" & lbnumbod.Text & " - ?cantidad " _
           & " WHERE codart='" & gitems.Item("codigo", fila).Value & "' AND periodo>='" & PerActual(0) & PerActual(1) & "';"
        End If
        myCommand.ExecuteNonQuery()
    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String, ByVal tipo As String, ByVal cta As String, ByVal db As Double, ByVal cr As Double)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", Val(lbnum.Text.ToString))
            myCommand.Parameters.AddWithValue("?tipodoc", lbtipo.Text)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
            myCommand.Parameters.AddWithValue("?centro", "0")
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena("AJUSTE " & gitems.Item("descripcion", fila).Value, 49))
            myCommand.Parameters.AddWithValue("?debito", DIN(Moneda(db)))
            myCommand.Parameters.AddWithValue("?credito", DIN(Moneda(cr)))
            myCommand.Parameters.AddWithValue("?codigo", cta)
            myCommand.Parameters.AddWithValue("?base", "0")
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            myCommand.Parameters.AddWithValue("?nit", "0")
            myCommand.Parameters.AddWithValue("?modulo", "inventarios")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?modulo,'');"
            myCommand.ExecuteNonQuery()
            ActualizarMisCuentas(cta, db, cr)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '****************************************************
    Public Sub EjecutaSQL(ByVal sql As String)
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''
    
End Class