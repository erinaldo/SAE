Public Class FrmDesFact

    Private Sub FrmDesFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha.Value = Today
        txtnumfac.Text = ""
        lbcliente.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
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
    'Private Sub Guar_MovUser()

    '    'Try

    '    Dim con As String = ""
    '    If DBCon.State = ConnectionState.Open Then
    '        Cerrar()
    '        con = "ab"
    '    End If

    '    Dim ubd As String = ""
    '    ubd = "user" & FrmPrincipal.lbcompania.Text.ToLower & Strings.Right(PerActual, 4)

    '    MiConexion(ubd)
    '    myCommand.Parameters.Clear()
    '    myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text)
    '    myCommand.Parameters.AddWithValue("?fech", DateTime.Now.ToString("yyyy-MM-dd"))
    '    myCommand.Parameters.AddWithValue("?hora", Format(Now(), "HH:mm:ss"))
    '    myCommand.Parameters.AddWithValue("?form", "FACTURACION")
    '    myCommand.Parameters.AddWithValue("?tmov", "DESAPROBAR DOCUMENTO " & txttipo.Text & txtnumfac.Text & " - PERIODO: " & cbper.Text)
    '    myCommand.Parameters.AddWithValue("?camp", "ESTADO")
    '    myCommand.Parameters.AddWithValue("?olf", "AP")
    '    myCommand.Parameters.AddWithValue("?nuev", "")

    '    myCommand.CommandText = "INSERT INTO mov" & Strings.Left(PerActual, 2) & " VALUES (?user,?fech,?hora,?form,?tmov,?camp,?olf,?nuev);"
    '    myCommand.ExecuteNonQuery()
    '    Cerrar()

    '    bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)

    '    If con <> "" Then
    '        MiConexion(bda)
    '    End If
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    '*************************************
    Public Sub DesaFactura()
        MiConexion(bda)
        Try
            myCommand.CommandText = "UPDATE facturas" & cbper.Text & " " _
                              & "SET estado='' WHERE num='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
            Contable()
            AnularInv()
            RecuperarCantidades()
            SacarCartera()
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT v1,v2,v3,doc1,doc2,doc3 FROM facturas" & cbper.Text & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                GuardarAnticipos(tabla.Rows(0).Item("v1").ToString, tabla.Rows(0).Item("doc1").ToString)
                GuardarAnticipos(tabla.Rows(0).Item("v2").ToString, tabla.Rows(0).Item("doc2").ToString)
                GuardarAnticipos(tabla.Rows(0).Item("v3").ToString, tabla.Rows(0).Item("doc3").ToString)
            Catch ex As Exception
            End Try

            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "DESAPROBAR DOC " & txttipo.Text & txtnumfac.Text, "ESTADO", "AP", "")
            End If
            MsgBox("EL DOCUMENTO FUÉ DESAPROBADO " & txttipo.Text & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String)
        'otros conceptos
        Dim sql As String = ""
        Dim sig As String = ""
        If txttipo.Text = lbtipo.Text Then
            sig = "+"
        Else
            sig = "-"
        End If
        Try
            If Trim(doc) <> "" Then
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_de_clie SET causado = causado " & sig & " " & DIN(valor) & " WHERE per_doc='" & Trim(doc) & "';"
                'MsgBox(sql)
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
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
            myCommand.CommandText = "SELECT * FROM detafac" & cbper.Text & " " _
            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "' AND tipo_it='I';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 0 To tabla.Rows.Count - 1
                ActualizarBodega(tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("numbod"), tabla.Rows(i).Item("cantidad"))
            Next
        Catch ex As Exception
            'MsgBox("Cantidades: " & ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bod As Integer, ByVal cantidad As Double)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
            myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " + ?cantidad " _
                                    & " WHERE codart='" & codart & "' AND periodo>='" & cbper.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Actualizar Bodega: " & ex.ToString)
        End Try
    End Sub
    Public Sub SacarCartera()
        Try
            myCommand.CommandText = "DELETE FROM cobdpen " _
                            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Cartera: " & ex.ToString)
        End Try
    End Sub
End Class