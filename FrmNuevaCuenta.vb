Public Class FrmNuevaCuenta
    Public n, n1, n2, n3, n4, n5 As Integer
    Private Sub FrmNuevaCuenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbestado.Text = "NULO"
    End Sub
    Private Sub FrmNuevaCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cad As String = Trim(txtcuenta.Text)
        CmdNuevo_Click(AcceptButton, AcceptButton)
        For i = 0 To cad.Length - 1
            txtcuenta.Text = txtcuenta.Text & cad(i)
            txtcuenta_KeyUp(AcceptButton, AcceptButton)
        Next
    End Sub
    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If lbestado.Text <> "NUEVO" Then
            lbaux.Visible = False
            txtcuenta.Text = ""
            txtdesc.Text = ""
            txtsaldo.Text = "0,00"
            cbnivel.Text = "Ninguno"
            cbtipo.Text = "Ninguno"
            txtnat.Text = ""
            txtcuenta.ReadOnly = False
            txtdesc.ReadOnly = False
            lbestado.Text = "NUEVO"
            BuscarNiveles()
            txtcuenta.Focus()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    'BUSCAR NIVELES DE LAS CUENTAS
    Public Sub BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            n = Val(tabla.Rows(0).Item("longitud"))
            n1 = Val(tabla.Rows(0).Item("nivel1"))
            n2 = Val(tabla.Rows(0).Item("nivel2"))
            n3 = Val(tabla.Rows(0).Item("nivel3"))
            n4 = Val(tabla.Rows(0).Item("nivel4"))
            n5 = Val(tabla.Rows(0).Item("nivel5"))
            txtcuenta.MaxLength = n
        Catch ex As Exception
            MsgBox("Por favor verifique los niveles de cuenta...", MsgBoxStyle.Information, "SAE verificación")
            Me.Close()
        End Try
    End Sub
    'DIGITANDO LA CUENTA
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        lbaux.Visible = False
        Select Case e.KeyChar
            Case "0" To "9", Chr(8), Chr(13)
            Case Else
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcuenta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcuenta.KeyUp
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        LongitudCuenta()
    End Sub
    Function LongitudCuenta()
        BuscarNiveles()
        lbaux.Visible = False
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If Val(txtcuenta.Text.Length) = n1 Then
                cbnivel.Text = "Clase"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2) Then
                cbnivel.Text = "Grupo"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2 + n3) Then
                cbnivel.Text = "Cuenta"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = (n1 + n2 + n3 + n4) Then
                cbnivel.Text = "Sub Cuenta"
                Return BCuenta()
            ElseIf Val(txtcuenta.Text.Length) = n Then
                cbnivel.Text = "Auxiliar"
                Return BCuenta()
            Else
                cbnivel.Text = "Ninguno"
                Return False
            End If
        Else
            Return False
            Exit Function
        End If
    End Function
    Function BCuenta()
        lbaux.Visible = False
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdesc.Text = tabla.Rows(0).Item("descripcion")
            txtnat.Text = tabla.Rows(0).Item("naturaleza")
            cbtipo.Text = tabla.Rows(0).Item("tipo")
            If cbnivel.Text = "Auxiliar" And lbestado.Text = "NUEVO" Then
                lbaux.Visible = True
            End If
            Return False
        Else
            If cbnivel.Text = "Clase" Then
                MsgBox("La clase ( " & txtcuenta.Text & " ) No exixte por favor verifique. ", MsgBoxStyle.Information, "SAE verificación")
                txtcuenta.Text = ""
                txtdesc.Text = ""
                txtsaldo.Text = "0,00"
                cbnivel.Text = "Ninguno"
                cbtipo.Text = "Ninguno"
                txtnat.Text = ""
                Return False
            Else
                txtsaldo.Text = "0,00"
                Return True
            End If
        End If
    End Function
    '*************************************************
    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '/////////// GUARDAR Y MODIFICAR //////////////////////////////
    Public Sub ValidarGuardar()
        BuscarNiveles()
        If cbnivel.Text = "Ninguno" Then
            MsgBox("La cuenta ( " & txtcuenta.Text & " ) NO pertenece a ningún nivel, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            txtcuenta.Focus()
            Exit Sub
        ElseIf txtdesc.Text = "" Then
            MsgBox("Favor digite la descripción de la cuenta, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            txtdesc.Focus()
            Exit Sub
        ElseIf BuscarNivelesAnt() = False Then
            txtcuenta.Focus()
            Exit Sub
        End If
        If lbestado.Text = "NUEVO" Then
            Guardar()
        ElseIf lbestado.Text = "EDITAR" Then
            Modificar()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Function BuscarNivelesAnt()
        BuscarNiveles()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 And lbestado.Text = "NUEVO" Then
            MsgBox("La cuenta ( " & txtcuenta.Text & " ) YA se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
            Return False
        Else
            Return VerificarNiveles()
        End If
    End Function
    Function VerificarNiveles()
        BuscarNiveles()
        Dim cad, cad2 As String
        cad2 = Trim(txtcuenta.Text)
        '*************** NIVEL 1 ***********************
        cad = ""
        If n1 < cad2.Length Then
            For i = 0 To n1 - 1
                cad = cad & cad2(i)
            Next
            Dim tablan1 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan1)
            If tablan1.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Clase ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 2 ***********************
        cad = ""
        If (n1 + n2) < cad2.Length Then
            For i = 0 To (n1 + n2 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan2 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan2)
            If tablan2.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("El Grupo ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 3 ***********************
        cad = ""
        If (n1 + n2 + n3) < cad2.Length Then
            For i = 0 To (n1 + n2 + n3 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan3 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan3)
            If tablan3.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Cuenta ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** NIVEL 4 ***********************
        cad = ""
        If (n1 + n2 + n3 + n4) < cad2.Length Then
            For i = 0 To (n1 + n2 + n3 + n4 - 1)
                cad = cad & cad2(i)
            Next
            'MsgBox(cad)
            Dim tablan4 As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cad & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablan4)
            If tablan4.Rows.Count <= 0 And lbestado.Text = "NUEVO" Then
                MsgBox("La Sub Cuenta ( " & cad & " ) NO se encuentra en los registros, verifique. ", MsgBoxStyle.Information, "SAE verificación")
                Return False
                txtcuenta.Focus()
                Exit Function
            End If
        End If
        '*************** TODO BIEN (HAY TODOS LOS NIVELES) *************************
        Return True
    End Function
    Public Sub Guardar()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?codigo", Trim(txtcuenta.Text.ToString))
        myCommand.Parameters.AddWithValue("?descripcion", txtdesc.Text.ToString)
        myCommand.Parameters.AddWithValue("?naturaleza", txtnat.Text.ToString)
        myCommand.Parameters.AddWithValue("?nivel", cbnivel.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipo", cbtipo.Text.ToString)
        myCommand.CommandText = "INSERT INTO selpuc VALUES (?codigo,?descripcion,?naturaleza,?nivel,?tipo,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
        lbestado.Text = "GUARDADO"
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        Cerrar()
        txtcuenta.ReadOnly = True
        txtdesc.ReadOnly = True
        lbaux.Visible = False
        If cbnivel.Text = "Auxiliar" Then
            Dim fila As Integer = Val(lbfila.Text)
            FrmEntradaDatos.grilla.Item(3, fila).Value = txtcuenta.Text
            Me.Close()
        End If
    End Sub
    Public Sub Modificar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & Trim(txtcuenta.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then 'LA CUENTA EXISTE SE PUEDE MODIFICAR
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            myCommand.Parameters.Clear()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?codigo", txtcuenta.Text.ToString)
            myCommand.Parameters.AddWithValue("?des", txtdesc.Text.ToString)
            myCommand.CommandText = "Update selpuc set descripcion=?des WHERE codigo=?codigo;"
            myCommand.ExecuteNonQuery()
            lbestado.Text = "EDITADO"
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
            Cerrar()
            txtcuenta.ReadOnly = True
            txtdesc.ReadOnly = True
            lbaux.Visible = False
        Else
            Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
            resultado = MsgBox("La cuenta (" & txtcuenta.Text & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
            If resultado = MsgBoxResult.Yes Then
                If BuscarNivelesAnt() = False Then
                    txtcuenta.Focus()
                    Exit Sub
                End If
                txtsaldo.Text = "0,00"
                Guardar()
            End If
        End If
    End Sub

    '************************************************
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarGuardar()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    '************************************************
    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Me.Close()
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub
End Class