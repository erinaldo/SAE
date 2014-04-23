Public Class FrmGruposImp

    Private Sub FrmGruposImp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmdPrimero_Click(AcceptButton, AcceptButton)
    End Sub
    '********************** OPERACIONES ************************************************************
    Public Sub PonerEnCero()
        TxtCodGral.Text = ""
        txtDescriGral.Text = ""
    End Sub
    Public Sub Bloquear()
        TxtCodGral.Enabled = False
        txtDescriGral.Enabled = False
    End Sub
    Public Sub DesBloquear()
        TxtCodGral.Enabled = True
        txtDescriGral.Enabled = True
    End Sub
    '***************** BOTONES DE COMANDO ********************************************************************
    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If per_imp <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
        PonerEnCero()
        DesBloquear()
        lbestado.Text = "NUEVO"
        TxtCodGral.Focus()
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
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
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If per_imp <> "E" Then
                    MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
                    Exit Sub
                End If
                DesBloquear()
                TxtCodGral.Enabled = False
                lbestado.Text = "EDITAR"
                txtDescriGral.Focus()
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If per_imp <> "E" Then
            MsgBox("No tiene los permisos de escritura...", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelConcepImp.lbform.Text = "concepto"
            FrmSelConcepImp.ShowDialog()
            If lbestado.Text = "CONSULTA" Then Bloquear()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '***************** DESPLAZAMIENTO *****************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT cod_concep FROM con_gral_imp ORDER BY cod_concep LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                Bloquear()
                lbestado.Text = "NULO"
            Else
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            Bloquear()
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT cod_concep FROM con_gral_imp ORDER BY cod_concep LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = i + 1
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM con_gral_imp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows(0).Item(0) - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT cod_concep FROM con_gral_imp ORDER BY cod_concep LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
                BuscarDoc(TxtCodGral.Text)
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM con_gral_imp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows(0).Item(0) - 1
            myCommand.CommandText = "SELECT cod_concep FROM con_gral_imp ORDER BY cod_concep LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
            BuscarDoc(TxtCodGral.Text)
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDoc(ByVal codigo As String)
        Try
            Bloquear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM con_gral_imp WHERE cod_concep='" & codigo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                TxtCodGral.Text = tabla.Rows(0).Item("cod_concep")
                txtDescriGral.Text = tabla.Rows(0).Item("decrip_gral")
                lbestado.Text = "CONSULTA"
            Else
                PonerEnCero()
            End If
        Catch ex As Exception
        End Try
    End Sub
    '************ VALIDACIONES *************************************************
    Private Sub TxtCodGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodGral.KeyPress
        validarnumero(TxtCodGral, e)
    End Sub
    Private Sub TxtCodGral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodGral.LostFocus
        Try
            If Val(TxtCodGral.Text) < 10 Then
                TxtCodGral.Text = "0" & Val(TxtCodGral.Text)
            Else
                TxtCodGral.Text = Val(TxtCodGral.Text)
            End If
        Catch ex As Exception
            TxtCodGral.Text = "00"
        End Try
        
    End Sub
    Private Sub txtDescriGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescriGral.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '****************** VALIDAR, GUARDAR Y MODIFICAR ********************************************
    Public Sub ValidarGuardar()
        If TxtCodGral.Text = "" Or TxtCodGral.Text = "00" Then
            MsgBox("Por favor digite el código del concepto, Verifique", MsgBoxStyle.Information, "Verificando")
            TxtCodGral.Focus()
            Exit Sub
        ElseIf txtDescriGral.Text = "" Then
            MsgBox("Por favor digite la descripción del concepto, Verifique", MsgBoxStyle.Information, "Verificando")
            txtDescriGral.Focus()
            Exit Sub
        End If
        MiConexion(bda)
        If lbestado.Text = "NUEVO" Then
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * from con_gral_imp WHERE cod_concep='" & TxtCodGral.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items <> 0 Then
                MsgBox("El concepto ya se encuantra en los registros, Verifique", MsgBoxStyle.Information, "Verificando")
            Else
                Guardar()
            End If
        Else
            Modificar()
        End If
        Cerrar()
    End Sub
    Public Sub Guardar()
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?cod_concep", TxtCodGral.Text.ToString)
        myCommand.Parameters.AddWithValue("?decrip_gral", CambiaCadena(txtDescriGral.Text.ToString, 50))
        myCommand.CommandText = "INSERT INTO con_gral_imp  " _
                                & " Values(?cod_concep,?decrip_gral)"
        myCommand.ExecuteNonQuery()
        MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
        lbestado.Text = "GUARDADO"
        Bloquear()
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos del concepto se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?decrip_gral", CambiaCadena(txtDescriGral.Text.ToString, 50))
            myCommand.CommandText = "UPDATE con_gral_imp  SET " _
                                  & "decrip_gral=?decrip_gral WHERE cod_concep='" & TxtCodGral.Text.ToString & "';"
            myCommand.ExecuteNonQuery()
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            lbestado.Text = "EDITADO"
            Bloquear()
        End If
    End Sub
End Class