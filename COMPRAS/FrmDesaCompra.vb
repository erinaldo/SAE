Public Class FrmDesaCompra

    Private Sub FrmDesaCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha.Value = Today
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT doc_fp FROM par_comp;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("doc_fp")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fp")))
            txttipo.Text = Trim(tabla.Rows(0).Item("doc_fp"))
        End If
        '******************************************
        cbper.Text = PerActual(0) & PerActual(1)
    End Sub
    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        txtnumfac.Text = ""
        txtfecha.Value = Today
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
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
        txtnumfac.Text = ""
    End Sub
    Private Sub txtnumfac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumfac.KeyPress
        validarnumero(txtnumfac, e)
    End Sub
    Private Sub txtnumfac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumfac.LostFocus
        txtnumfac.Text = NumeroDoc(Val(txtnumfac.Text))
        BuscarDoc()
    End Sub
    Public Sub BuscarDoc()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM fact_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("anulado").ToString) <> "no" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
            End If
        End If
    End Sub
    Function Datos_Cliente(ByVal nit As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nombre,apellidos FROM terceros WHERE nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            Return Trim(tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos"))
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If Trim(txtnumfac.Text) = "" Then
            MsgBox("Digite un numero de documento.", MsgBoxStyle.Information, "SAE Buscar")
            txtnumfac.Focus()
            Exit Sub
        End If
        If Trim(lbcliente.Text) = "" Then
            MsgBox("Favor escoja un documento valido.", MsgBoxStyle.Information, "SAE Buscar")
            txtnumfac.Focus()
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El docuemento " & txttipo.Text & txtnumfac.Text & " será Desaprobado, ¿Desea Desaprobarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            DesaFactura()
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '*************************************
    Public Sub DesaFactura()
        MiConexion(bda)
        Try
            myCommand.CommandText = "UPDATE fact_comp" & cbper.Text & " " _
                              & "SET estado='' WHERE num='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
            Contable()
            AnularInv()
            RecuperarCantidades()
            GuardarAnticipos()
            SacarCartera()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("COMPRAS", "DESAPROBAR FACTURA DE COMPRA Nº: " & txttipo.Text & txtnumfac.Text & "-" & cbper.Text, "", "", "")
            End If
            '.....
            MsgBox("EL DOCUMENTO FUÉ DESAPROBADO " & txttipo.Text & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub GuardarAnticipos()
        Try
            Dim tipo As String = ""
            Dim sql As String = ""
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM fact_comp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 1 To 3
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_a_prov SET causado = causado - " & DIN(tabla.Rows(0).Item("v" & i)) & " WHERE per_doc='" & tabla.Rows(0).Item("doc" & i).ToString & "';"
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
    Public Sub Contable()
        Try
            myCommand.CommandText = "DELETE FROM documentos" & cbper.Text & " " _
                                 & " WHERE doc='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Contable: " & ex.ToString)
        End Try
    End Sub
    Public Sub AnularInv()
        Try
            myCommand.CommandText = "DELETE FROM deta_mov" & cbper.Text & " " _
                            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = "DELETE FROM movimientos" & cbper.Text & " " _
                                 & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Inventario: " & ex.ToString)
        End Try
    End Sub
    Public Sub RecuperarCantidades()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM detacomp" & cbper.Text & " " _
            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' AND tipo_it='I';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 0 To tabla.Rows.Count - 1
                ActualizarBodega(tabla.Rows(i).Item("cod_art"), tabla.Rows(i).Item("num_bod"), tabla.Rows(i).Item("cantidad"))
            Next
        Catch ex As Exception
            'MsgBox("Cantidades: " & ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bod As Integer, ByVal cantidad As Double)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(Moneda(cantidad)))
            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " - ?cantidad " _
                                    & " WHERE codart='" & codart & "' AND periodo>='" & cbper.Text & "';"
            myCommand.ExecuteNonQuery()
            myCommand.Parameters.Clear()
        Catch ex As Exception
            'MsgBox("Actualizar Bodega: " & ex.ToString)
        End Try
    End Sub
    Public Sub SacarCartera()
        Try
            myCommand.CommandText = "DELETE FROM ctas_x_pagar  " _
                            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Cartera: " & ex.ToString)
        End Try
    End Sub
End Class