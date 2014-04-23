Public Class FrmDesapCEOrden

    Private Sub FrmDesapCEOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today

        Dim ta As New DataTable
        myCommand.CommandText = "SELECT doc_cpp FROM par_comp ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(ta.Rows(0).Item(0)) <> "" Then
            txttipo.Items.Add(Trim(ta.Rows(0).Item("doc_cpp")))
            txttipo.Text = Trim(ta.Rows(0).Item("doc_cpp"))
        End If

        cbper.Text = PerActual(0) & PerActual(1)
    End Sub
    Dim valb As Double
    Dim doccxp As String
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
        resultado = MsgBox("El documento " & txttipo.Text & txtnumfac.Text & " será desaprobado, ¿Desea desaprobarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            Desapro()
            MsgBox("EL DOCUMENTO FUÉ DESAPROBADO " & txttipo.Text & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
            Cerrar()
            txtnumfac.Text = ""
            lbcliente.Text = ""
            lbtotal.Text = "0,00"
            txtfecha.Value = Today
        End If
    End Sub
    Private Sub Desapro()

        'ORDENES
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE ord_pagos " _
                              & "SET estado='' WHERE doc='" & lbcliente.Text & "' ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
       

        'CTAS_X_PAGAR
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE ctas_x_pagar " _
                             & "SET pagado=pagado - " & DIN(valb) & " WHERE doc='" & doccxp & "' ;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        'OT_CPP
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE  FROM ot_cpp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        'DOCUMENTO
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE  FROM documentos" & cbper.Text & " WHERE doc='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "' "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        'MOVINGRESO
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE  FROM presupuesto" & Strings.Right(PerActual, 4) & ".movingresos" _
            & " WHERE movi_reconoce='" & cbper.Text & "/" & Strings.Right(PerActual, 4) & "-" & txttipo.Text & txtnumfac.Text & "' "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

        'RECAUDOS
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE  FROM presupuesto" & Strings.Right(PerActual, 4) & ".recaudos" _
            & " WHERE rec_nrodoc='" & cbper.Text & "/" & Strings.Right(PerActual, 4) & "-" & txttipo.Text & txtnumfac.Text & "' "
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error actualizar orden " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try

    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
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
        ' myCommand.CommandText = "SELECT * FROM ot_cpc" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myCommand.CommandText = "SELECT p.v_bruto,o.doc_afec, o.doc_aj, o.estado, o.doc, o.total, o.dia,o.periodo, p.doc AS ordenp FROM ot_cpp" & cbper.Text & " o, ord_pagos p WHERE " _
        & " o.doc='" & txttipo.Text & txtnumfac.Text & "' AND doc_afec<>'' AND p.sop_cont=CONCAT(o.periodo,'-',o.doc)"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        valb = 0
        doccxp = ""
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("doc_aj").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                doccxp = tabla.Rows(0).Item("doc_afec")
                valb = tabla.Rows(0).Item("v_bruto")
                lbcliente.Text = tabla.Rows(0).Item("ordenp")
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                Dim per As String = tabla.Rows(0).Item("periodo").ToString
                per = per(3) & per(4) & per(5) & per(6) & "-" & per(0) & per(1) & "-" & tabla.Rows(0).Item("dia").ToString
                txtfecha.Value = CDate(per)
            End If
        End If
    End Sub
End Class