Public Class FrmDesaCartera

    Private Sub FrmDesaCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        '******************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT par_rc, par_ci  FROM car_par;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("par_rc")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_rc")))
            txttipo.Text = Trim(tabla.Rows(0).Item("par_rc"))
        End If
        If Trim(tabla.Rows(0).Item("par_ci")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_ci")))
        End If
        '******************************************
        cbper.Text = PerActual(0) & PerActual(1)
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
        myCommand.CommandText = "SELECT * FROM ot_cpc" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
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
            myCommand.CommandText = "UPDATE ot_cpc" & cbper.Text & " " _
                              & "SET estado='' WHERE num='" & Val(txtnumfac.Text) & "' AND tipo='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
            Contable()
            SacarCartera()
            GuardarAnticipos()
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
                sql = "UPDATE ant_de_clie SET causado = causado - " & DIN(tabla.Rows(0).Item("v" & i)) & " WHERE per_doc='" & tabla.Rows(0).Item("doc" & i).ToString & "';"
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
    Public Sub SacarCartera()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM ot_cpc" & cbper.Text & " " _
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
            myCommand.CommandText = "UPDATE cobdpen SET pagado=pagado - " & DIN(mon) _
                          & " WHERE doc='" & doc & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Act Cartera: " & ex.ToString)
        End Try

    End Sub
End Class