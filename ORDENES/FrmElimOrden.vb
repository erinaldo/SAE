Public Class FrmElimOrden

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmElimOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = Strings.Left(PerActual, 2)
        cbaño.Text = Strings.Right(PerActual, 5)
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today

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
        myCommand.CommandText = "SELECT * FROM ord_pagos WHERE doc='" & cbper.Text & cbaño.Text & "-" & txtnumfac.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
            Exit Sub
        Else
            If Trim(tabla.Rows(0).Item("estado")) <> "" Then
                MsgBox("La Orden registra Comprobante de Egreso, Desapruebelo y luego realice este proceso", MsgBoxStyle.Information, "SAE Buscar")
                Exit Sub
            End If
            lbcliente.Text = tabla.Rows(0).Item("con_objeto")
            txtfecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
            lbtotal.Text = Moneda(tabla.Rows(0).Item("v_neto"))
        End If

    End Sub

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
        resultado = MsgBox("La Orden de Pago " & cbper.Text & cbaño.Text & txtnumfac.Text & " será ELIMINADA, este proceso es irreversible ¿Desea continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            eliminar()
            MsgBox("LA ORDEN DE PAGO FUÉ ELIMINADA " & cbper.Text & cbaño.Text & "-" & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
            Cerrar()
            txtnumfac.Text = ""
            lbcliente.Text = ""
            lbtotal.Text = "0,00"
            txtfecha.Value = Today
        End If
    End Sub
    Private Sub eliminar()

        'ORDENES
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM ord_pagos WHERE doc='" & cbper.Text & cbaño.Text & "-" & txtnumfac.Text & "' ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error ELIMINAR orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        'Deta_ORDENES
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM deta_ord WHERE doc='" & cbper.Text & cbaño.Text & "-" & txtnumfac.Text & "' ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error ELIMINAR detalle_orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
End Class