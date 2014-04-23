Public Class FrmDesaInvSI

    Private Sub FrmDesaInvSI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT entradas FROM parinven;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then Exit Sub
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("entradas")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("entradas")))
                txttipo.Text = Trim(tabla.Rows(0).Item("entradas"))
            End If
        Catch ex As Exception
        End Try
        txtfecha.Value = Today
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
        lbcliente.Text = ""
        txtconcepto.Text = ""
        lbtotal.Text = "0,00"
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
        myCommand.CommandText = "SELECT * FROM movimientos00 WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        txtconcepto.Text = ""
        lbcliente.Text = ""
        lbtiopomov.Text = ""
        lbtotal.Text = "0,00"
        txtfecha.Value = Today
        If tabla.Rows.Count <= 0 Then
            MsgBox("El documento no existe en este periodo.", MsgBoxStyle.Information, "SAE Buscar")
        Else
            If VerificarDescrip(Trim(tabla.Rows(0).Item("desc_mov").ToString)) = False Then
                MsgBox("El documento ya fué anulado.", MsgBoxStyle.Information, "SAE Buscar")
            ElseIf Trim(tabla.Rows(0).Item("estado").ToString) = "" Then
                MsgBox("El documento no ha sido aprobado.", MsgBoxStyle.Information, "SAE Buscar")
            Else
                lbcliente.Text = Datos_Cliente(tabla.Rows(0).Item("nitc"))
                lbtotal.Text = Moneda(tabla.Rows(0).Item("total"))
                txtfecha.Value = CDate(tabla.Rows(0).Item("dia").ToString & "/" & PerActual)
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
                lbtiopomov.Text = UCase(tabla.Rows(0).Item("tipo"))
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
    Function VerificarDescrip(ByVal descrip As String)
        Dim cad As String = ""
        For i = 0 To descrip.Length - 1
            cad = cad & descrip(i)
            If cad = "ANULADO CON" Then
                Return False
                Exit Function
            End If
        Next
        Return True
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
        resultado = MsgBox("El docuemento " & txttipo.Text & txtnumfac.Text & " será desaprobado, ¿Desea Desaprobarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            DesaFactura()
        End If
    End Sub

    Public Sub DesaFactura()
        MiConexion(bda)
        Try
            myCommand.CommandText = "UPDATE movimientos00 " _
                              & "SET estado='' WHERE num='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
            Contable()
            RecuperarCantidades()
            'codbpen()
            MsgBox("EL DOCUMENTO FUÉ DESAPROBADO " & txttipo.Text & txtnumfac.Text & ". ", MsgBoxStyle.Information, "SAE Guardar")
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub Contable()
        Try
            myCommand.CommandText = "DELETE FROM documentos00 " _
                                 & " WHERE doc='" & Val(txtnumfac.Text) & "' AND tipodoc='" & txttipo.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Contable: " & ex.ToString)
        End Try
    End Sub
    Public Sub codbpen()
        Try
            myCommand.CommandText = "DELETE FROM `cobdpen` WHERE doc='" & PerActual & "-" & txttipo.Text & txtnumfac.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Contable: " & ex.ToString)
        End Try
    End Sub
    Public Sub RecuperarCantidades()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM deta_mov00 " _
            & " WHERE doc='" & txttipo.Text & txtnumfac.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            For i = 0 To tabla.Rows.Count - 1
                ActualizarBodega(tabla.Rows(i).Item("codart"), tabla.Rows(i).Item("bod_ori"), tabla.Rows(i).Item("bod_des"), tabla.Rows(i).Item("cantidad"))
            Next
        Catch ex As Exception
            'MsgBox("Cantidades: " & ex.ToString)
        End Try
    End Sub
    Public Sub ActualizarBodega(ByVal codart As String, ByVal bod As Integer, ByVal bod2 As Integer, ByVal cantidad As Double)
        Try
            myCommand.Parameters.Clear()
            If bod = 0 Then 'bodega origen = 0 entonces fue una entrada
                myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
                myCommand.CommandText = "UPDATE con_inv SET cant" & bod2 & "=cant" & bod2 & " - ?cantidad " _
                                        & " WHERE codart='" & codart & "' AND periodo>='00';"
            Else
                myCommand.Parameters.AddWithValue("?cantidad", DIN(cantidad))
                myCommand.CommandText = "UPDATE con_inv SET cant" & bod & "=cant" & bod & " + ?cantidad " _
                                        & " WHERE codart='" & codart & "' AND periodo>='00';"
            End If

            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox("Actualizar Bodega: " & ex.ToString)
        End Try
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class