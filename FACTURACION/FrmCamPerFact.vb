Public Class FrmCamPerFact

    Private Sub FrmCamPerFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha.Value = Today
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        txtfecha2.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4 FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("tipof1")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
            txttipo.Text = Trim(tabla.Rows(0).Item("tipof1"))
        End If
        If Trim(tabla.Rows(0).Item("tipof2")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof2")))
        End If
        If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
        End If
        If Trim(tabla.Rows(0).Item("tipof4")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
        End If
        '******************************************
        cbper.Text = PerActual(0) & PerActual(1)
        cmbNper.Text = PerActual(0) & PerActual(1)
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
        myCommand.CommandText = "SELECT * FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("descrip").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "AP" Then
                MsgBox("El documento no ha sido desaprobado.", MsgBoxStyle.Information, "SAE Buscar")
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

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
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
        If Val(txtfecha2.Value.Month.ToString) <> Val(cmbNper.Text) Then
            MsgBox("La fecha debe estar en el mismo periodo.", MsgBoxStyle.Information, "SAE Buscar")
            txtfecha2.Focus()
            Exit Sub
        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El documento " & txttipo.Text & txtnumfac.Text & " será Modificado , ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            cambiarperiodo()
        End If
    End Sub
    Private Sub cambiarperiodo()
        Try
            MiConexion(bda)
            If cbper.Text <> cmbNper.Text Then

                ' PASAR PERIODO
                myCommand.CommandText = "INSERT facturas" & cmbNper.Text & "  SELECT * FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "INSERT detafac" & cmbNper.Text & "  SELECT * FROM detafac" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "INSERT facpagos" & cmbNper.Text & " SELECT * FROM facpagos" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()

                'ELIMINAR FAC
                myCommand.CommandText = "DELETE FROM detafac" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "DELETE FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()
                myCommand.CommandText = "DELETE FROM facpagos" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' "
                myCommand.ExecuteNonQuery()
            End If
            '...UPDATE  FECHA
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?fecha", CDate(txtfecha2.Text))
            myCommand.CommandText = "UPDATE  facturas" & cmbNper.Text & " SET  `fecha` = ?fecha WHERE  doc='" & txttipo.Text & txtnumfac.Text & "' "
            myCommand.ExecuteNonQuery()
            Cerrar()

            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "CAMBIAR DE FECHA DOC " & txttipo.Text & txtnumfac.Text, "FECHA,PERIODO", CDate(txtfecha.Text), CDate(txtfecha2.Text) & "," & cmbNper.Text)
            End If
            '.....

            MsgBox("El proceso se realizo satisfactoriamente, Recuerde Aprobar el documento ", MsgBoxStyle.Information, "Verificacion")
        Catch ex As Exception
            MsgBox("Error en el proceso," & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try

    End Sub

    Private Sub cmbNper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNper.SelectedIndexChanged

        Dim dia As String = ""
        dia = txtfecha.Value.Day.ToString

        Try
            txtfecha2.Value = CDate(cmbNper.Text & "/" & Strings.Right(PerActual, 4) & "/" & dia)
        Catch ex As Exception
            txtfecha2.Value = CDate(cmbNper.Text & "/" & Strings.Right(PerActual, 4) & "/" & "01")
        End Try

    End Sub
End Class