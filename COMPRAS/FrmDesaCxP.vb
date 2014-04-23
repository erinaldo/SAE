Public Class FrmDesaCxP

    Private Sub FrmDesaCxP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha.Value = Today
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT doc_cpp,doc_gas,doc_ppf FROM par_comp;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("doc_cpp")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_cpp")))
            txttipo.Text = Trim(tabla.Rows(0).Item("doc_cpp"))
        End If
        If Trim(tabla.Rows(0).Item("doc_gas")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_gas")))
        End If
        If Trim(tabla.Rows(0).Item("doc_ppf")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_ppf")))
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
        myCommand.CommandText = "SELECT * FROM ot_cpp" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If Trim(tabla.Rows(0).Item("doc_aj").ToString) <> "" Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")

            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                Dim per As String = tabla.Rows(0).Item("periodo").ToString
                per = per(3) & per(4) & per(5) & per(6) & "-" & per(0) & per(1) & "-" & tabla.Rows(0).Item("dia").ToString
                txtfecha.Value = CDate(per)
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
    '********************************************
    Public Sub AnularCartera()
        MiConexion(bda)
        Try
            myCommand.CommandText = "UPDATE ot_cpp" & cbper.Text & " " _
                              & "SET estado='' WHERE num='" & Val(txtnumfac.Text) & "' AND tipo='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
            Contable()
            SacarCartera()
            GuardarAnticipos()
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("COMPRAS", "DESAPROBAR DOC CXP Nº: " & txttipo.Text & txtnumfac.Text & "-" & cbper.Text, "", "", "")
            End If
            '.....
            MsgBox("EL DOCUMENTO FUÉ DESAPROBADO " & txttipo.Text & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Cerrar()
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
    Public Sub SacarCartera()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM ot_cpp" & cbper.Text & " " _
            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' AND TRIM(doc_afec)<>'';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 0 To tabla.Rows.Count - 1
                ActCartera(tabla.Rows(i).Item("doc_afec"), Moneda(tabla.Rows(i).Item("abonado")))
            Next
        Catch ex As Exception
            MsgBox("Consultado Documentos: " & ex.ToString)
        End Try
    End Sub
    Public Sub ActCartera(ByVal doc As String, ByVal mon As String)
        Try
            myCommand.CommandText = "UPDATE ctas_x_pagar SET pagado=pagado - " & DIN(mon) _
                          & " WHERE doc=TRIM('" & doc & "');"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Act Cartera: " & ex.ToString)
        End Try

    End Sub
    Public Sub GuardarAnticipos()
        Try
            Dim tabla As New DataTable
            Dim sql As String = ""
            Dim sig As String = ""
            myCommand.CommandText = "SELECT * FROM ot_cpp" & cbper.Text & " " _
            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' AND TRIM(doc_anti)<>'';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 0 To tabla.Rows.Count - 1
                Try
                    myCommand.Parameters.Clear()
                    If lbtipo.Text = txttipo.Text Then
                        sig = "+"
                    Else
                        sig = "-"
                    End If
                    sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(Moneda(tabla.Rows(i).Item("credito"))) & " WHERE per_doc='" & Trim(tabla.Rows(i).Item("doc_anti").ToString) & "';"
                    myCommand.CommandText = sql
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            MsgBox("Consultado Documentos para anticipos: " & ex.ToString)
        End Try
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
        resultado = MsgBox("El docuemento " & txttipo.Text & txtnumfac.Text & " será desaprobado, ¿Desea desaprobarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            AnularCartera()
        End If
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class