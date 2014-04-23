Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmGestionCitas

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmGestionCitas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        bloquear()
    End Sub
    Private Sub limpiar()
        txtestado.Text = ""
        txtf1.Value = CDate(Strings.Left(PerActual, 2) & "/" & Strings.Right(PerActual, 4) & "/" & Now.Day)
        txtserv.Text = ""
        txtnita.Text = ""
        txtobs.Text = ""
        lbestado.Text = ""
        Lbnov.Text = ""
        txtnitv.Text = ""
        txtnomv.Text = ""
        txtnitc.Text = ""
        txtnomc.Text = ""
        Try
            txthora.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
        Catch ex As Exception
            txthora.Text = "00:00:00"
        End Try

    End Sub
    Private Sub bloquear()
        ' act guardar
        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        cmdguardar.Enabled = False
        cmdcancelar.Enabled = False
        CmdEliminar.Enabled = True
        cmdProc.Enabled = True
        CmdMostrar.Enabled = True
        cmdPrint.Enabled = True
        txtnitv.Enabled = False
        txtnita.Enabled = False
        txtnitc.Enabled = False
        txtf1.Enabled = False
        txthora.Enabled = False
        txtserv.Enabled = False
        txtobs.Enabled = False
        txtestado.Enabled = False
    End Sub
    Private Sub desbloquear()
        ' act guardar
        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        cmdguardar.Enabled = True
        cmdcancelar.Enabled = True
        CmdEliminar.Enabled = False
        cmdProc.Enabled = False
        CmdMostrar.Enabled = False
        cmdPrint.Enabled = False
        txtnitv.Enabled = True
        txtnita.Enabled = True
        txtnitc.Enabled = True
        txtf1.Enabled = True
        txthora.Enabled = True
        txtserv.Enabled = True
        txtobs.Enabled = True
        txtestado.Enabled = True
    End Sub

    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        limpiar()
        desbloquear()
        txtestado.Text = "PENDIENTE"
        lbestado.Text = "NUEVO"
        txtestado.Enabled = False
        txtnitc.Focus()
        MiConexion(bda)
        NumNov()
        Cerrar()
    End Sub
    Private Sub NumNov()
        Try
            Lbnov.Text = ""
            Dim tn As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT max(num) FROM citas  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tn)
            Refresh()
            If tn.Rows.Count > 0 Then
                Lbnov.Text = NumeroDoc(tn.Rows(0).Item(0) + 1)
            End If
        Catch ex As Exception
            Lbnov.Text = NumeroDoc(1)
        End Try
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        limpiar()
        bloquear()
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        If lbestado.Text <> "CONSULTA" Then
            MsgBox("Seleccione la novedad a modificar", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        ElseIf lbestado.Text = "CONSULTA" And txtestado.Text <> "PENDIENTE" Then
            MsgBox("El estado CUMPLIDO no permite esta acción ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        Else
            lbestado.Text = "EDITAR"
            desbloquear()
        End If
    End Sub

    Private Sub txtnitv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitv.KeyPress
        ValidarNIT(txtnitv, e)
    End Sub

    Private Sub txtnitv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitv.LostFocus
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtnomv.Text = ""
            txtnitv.Text = ""
            cargarvendedor("cita_v")
        Else  'mostrar uno solo q coinside
            txtnomv.Text = tabla.Rows(0).Item(1)
        End If
    End Sub
    Private Sub cargarvendedor(ByVal tipo As String)
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM vendedores ORDER BY nombre;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelVendedor.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelVendedor.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre")
                FrmSelVendedor.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nitv")
            Next
            FrmSelVendedor.lbform.Text = tipo
            FrmSelVendedor.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtnomc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnomc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtnitc.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            txtnomc.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnitc.Text)
        End If
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            txtnomc.Focus()
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nit,TRIM(CONCAT(apellidos,' ',nombre))AS ter FROM terceros ORDER BY ter;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("ter")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "citaE"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtnomc.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "citaE"
                frmterceros.txtnit.Text = txtnitc.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtnitv.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtnomc.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub

    Private Sub txtnita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnita.KeyPress
        ValidarNIT(txtnita, e)
    End Sub

    Private Sub txtnita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.LostFocus
        If txtnitc.Text <> "" Then
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM vendedores WHERE  nitv ='" & txtnita.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtnoma.Text = ""
                txtnita.Text = ""
                cargarvendedor("cita_a")
            Else  'mostrar uno solo q coinside
                txtnoma.Text = tabla.Rows(0).Item(1)
            End If
        Else
            MsgBox("Seleccione el cliente")
        End If
        
    End Sub

    Private Sub txtserv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserv.KeyPress
        'If e.KeyChar = Chr(Keys.Enter) Then
        '    txtserv_LostFocus(AcceptButton, AcceptButton)
        '    'FrmSelServicio.lbform.Text = ""
        'End If
    End Sub

    Private Sub txtserv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtserv.LostFocus
        'Try
        '    FrmSelServicio.lbform.Text = "cita_a"
        '    FrmSelServicio.ShowDialog()
        'Catch ex As Exception

        'End Try
      
    End Sub

    Private Sub txtnita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnita.TextChanged
        If txtnita.Text = "" Then
            txtnoma.Text = ""
        End If
    End Sub

    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Validar()
    End Sub
    Private Sub Validar()
        If txtnitc.Text = "" Then
            MsgBox("Verifique la cedula del cliente ", MsgBoxStyle.Information, "Verificación")
            txtnitc.Focus()
            Exit Sub
        End If
        If txtserv.Text = "" Then
            MsgBox("Verifique el servicio para la cita ", MsgBoxStyle.Information, "Verificación")
            txtserv.Focus()
            Exit Sub
        End If
        If txtnitv.Text = "" Then
            MsgBox("Verifique el nit del usuario que registra el documento ", MsgBoxStyle.Information, "Verificación")
            txtnitv.Focus()
            Exit Sub
        End If
     
        If lbestado.Text = "NUEVO" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("¿Desea Registrar esta Cita?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Guardar()
                MsgBox("Datos Guardados correctamente", MsgBoxStyle.Information, "SAE")
            End If
        ElseIf lbestado.Text = "EDITAR" Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("¿Desea Modificar esta Cita?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Eliminar()
                Guardar()
                MsgBox("Datos Guardados correctamente", MsgBoxStyle.Information, "SAE")
            End If
        End If


    End Sub
    Private Sub Eliminar()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM citas where num='" & DIN(Lbnov.Text) & "';"
        myCommand.ExecuteNonQuery()
        Refresh()
        Cerrar()
    End Sub
    Private Sub Guardar()
        MiConexion(bda)

       
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?num", DIN(Lbnov.Text))
        myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text)
        myCommand.Parameters.AddWithValue("?nita", txtnita.Text)
        myCommand.Parameters.AddWithValue("?serv", txtserv.Text)
        myCommand.Parameters.AddWithValue("?fecha", CDate(txtf1.Text.ToString))
        myCommand.Parameters.AddWithValue("?hora", CDate(txthora.Text))
        myCommand.Parameters.AddWithValue("?observ", txtobs.Text)
        myCommand.Parameters.AddWithValue("?nitr", txtnitv.Text)
        myCommand.Parameters.AddWithValue("?estado", txtestado.Text)

        myCommand.CommandText = "Insert INTO citas Values(?num,?nitc,?nita,?serv,?fecha,?hora,?observ,?nitr,?estado);"
        myCommand.ExecuteNonQuery()
        Refresh()

        Cerrar()

        lbestado.Text = "GUARDADO"
        bloquear()
    End Sub

    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        Try
            FrmSelCitas.lbform.Text = "cita"
            FrmSelCitas.ShowDialog()
        Catch ex As Exception
        End Try
        If Lbnov.Text <> "" Then

            BuscarCita()
        End If
    End Sub

    Private Sub BuscarCita()
        Try

            MiConexion(bda)
            Dim tb As New DataTable
            myCommand.CommandText = "SELECT * FROM CITAS WHERE NUM='" & DIN(Lbnov.Text) & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()

            If tb.Rows.Count > 0 Then
                txtnitc.Text = tb.Rows(0).Item("nitc")
                txtnitc_LostFocus(AcceptButton, AcceptButton)
                txtnita.Text = tb.Rows(0).Item("nita")
                txtnita_LostFocus(AcceptButton, AcceptButton)
                txtserv.Text = tb.Rows(0).Item("servicio")
                txtf1.Text = tb.Rows(0).Item("fecha")
                txthora.Text = tb.Rows(0).Item("hora").ToString
                txtobs.Text = tb.Rows(0).Item("observ")
                txtnitv.Text = tb.Rows(0).Item("nitr")
                txtnitv_LostFocus(AcceptButton, AcceptButton)
                txtestado.Text = tb.Rows(0).Item("estado")
            End If
            Cerrar()
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try
    End Sub

    Private Sub txthora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthora.LostFocus
        'Try
        '    txthora.Text = CDate(txthora.Text)
        'Catch ex As Exception
        '    txthora.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
        'End Try
    End Sub

    Private Sub cmdProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProc.Click
        If Lbnov.Text = "" Then
            MsgBox("Verifique el numero de la cita", MsgBoxStyle.Information, "Verificacion")
            CmdMostrar.Focus()
        Else
            Try
                Dim resultado As MsgBoxResult
                resultado = MsgBox("La Cita sera Marcada como Cumplida ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    MiConexion(bda)
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE citas SET estado='CUMPLIDO' WHERE num='" & DIN(Lbnov.Text) & "'"
                    myCommand.ExecuteNonQuery()
                    Cerrar()

                    MsgBox("Cita Actualizada", MsgBoxStyle.Information, "SAE")
                    BuscarCita()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If Lbnov.Text = "" Then
            MsgBox("Verifique el numero de la cita", MsgBoxStyle.Information, "Verificacion")
            CmdMostrar.Focus()
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("La Cita sera Eliminada ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM citas WHERE num='" & DIN(Lbnov.Text) & "'"
                myCommand.ExecuteNonQuery()
                Cerrar()

                MsgBox("Cita ELIMINADA", MsgBoxStyle.Information, "SAE")
                lbestado.Text = "ELIMINADO"
                limpiar()

            End If
        End If
    End Sub
End Class