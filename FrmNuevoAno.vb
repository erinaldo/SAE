Imports System.IO

Public Class FrmNuevoAno
    Public anoactual As String
    Public sw As Integer
    Private Sub FrmNuevoAno_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sw <> 0 Then Exit Sub
        sw = 1
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        lbcompa.Text = tabla.Rows(0).Item("login") & " - " & tabla.Rows(0).Item("descripcion")
        lbperiodo.Text = PerActual
        anoactual = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub
    Private Sub FrmNuevoAno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        sw = 0
        BuscarPeriodo()
    End Sub
    Private Sub FrmNuevoAno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        sw = 0
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Se abrira o se creara el año (" & ano.Value & "), ¿Desea seguir?", MsgBoxStyle.YesNo, "SAE verificando")
            If resultado = MsgBoxResult.Yes Then
                mibarra.Value = 0
                mibarra.Visible = True
                Me.Cursor = Cursors.WaitCursor
                CrearNuevoAno("sae" & LCase(CompaniaActual) & ano.Value)
                mibarra.Value = 99
                mibarra.Visible = False
                Me.Cursor = Cursors.Default

                CrearVista()
                Me.Close()
            End If
        Catch ex As Exception
            mibarra.Value = 0
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
            MsgBox("ERROR AL CREAR EL NUEVO AÑO: " & ex.ToString)
        End Try
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Public Sub CrearNuevoAno(ByVal nbd As String)
        Dim bandera As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "show DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        bandera = 0
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = nbd Then
                bandera = 1
                Exit For
            End If
        Next
        mibarra.Value = 10
        Dim bd As String
        Dim a As String
        a = ano.Value
        '********************************************************
        bd = "sae" & LCase(CompaniaActual) & a
        If bandera = 1 Then
            MiConexion("sae")
            CreateImpuestos(nbd)
            'LlenarGenerales(nbd)
            Cerrar()
            AbrirExistente() ' ABRIR LA BD SAEloginAÑO
            Try
                FrmPrincipal.Update_tablas()
            Catch ex As Exception
            End Try
            MsgBox("La operación se realizó correctamente.  Año abierto.", MsgBoxStyle.Information, "SAE Abrir Otro Año")
        Else
            MiConexion("sae")
            FrmCierreAno.mibarra.Value = 11
            mibarra.Value = 11
            If bdexiste(bd) = 0 Then
                'CREAR BASE DE DATOS 
                myCommand.CommandText = "CREATE DATABASE " & bd & "; use " & bd & "; "
                myCommand.ExecuteNonQuery()
            End If
            Generales(bd)
            LlenarGenerales(nbd)
            FrmCierreAno.mibarra.Value = 20
            mibarra.Value = 20
            If FrmPrincipal.Contabilidad.Enabled = True Then
                Contabilidad(bd)
                LlenarDatos(bd)
            End If
            FrmCierreAno.mibarra.Value = 30
            mibarra.Value = 30
            If FrmPrincipal.Inventarios.Enabled = True Then
                Inventario(bd)
                FrmCierreAno.mibarra.Value = 35
                mibarra.Value = 35
                LlenarInventarios(bd)
            End If
            FrmCierreAno.mibarra.Value = 40
            mibarra.Value = 40
            Try
                If FrmPrincipal.inmobiliaria.Visible = True Then
                    If FrmPrincipal.inmobiliaria.Enabled = True Then
                        Inmobiliaria(bd)
                        FrmCierreAno.mibarra.Value = 50
                        mibarra.Value = 50
                        LlenarInmobiliaria(bd)
                    End If
                End If
            Catch ex As Exception
            End Try
            FrmCierreAno.mibarra.Value = 85
            mibarra.Value = 85
            If FrmPrincipal.Facturacion.Enabled = True Then
                Facturacion(bd)
                LLenarFacturacion(bd)
            End If
            If FrmPrincipal.Cartera.Enabled = True Then
                Cartera(bd)
                'LLenarFacturacion(bd)
            End If
            If FrmPrincipal.Proveedores.Enabled = True Then
                Proveedores(bd)
            End If
            If FrmPrincipal.Nomina.Enabled = True Then
                Nomina(bd)
            End If
            'ANTICIPOS
            TablaAnticipos(bd)
            PasarAnticipos(bd)
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Auditoria(bd)
                llenarAuditoria(bd)
            End If
            Try
                myCommand.CommandText = "DROP TABLE IF EXISTS " & bd & ".temp_terceros;"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            MsgBox("La operación se realizó correctamente. Año creado, pero NO abierto.", MsgBoxStyle.Information, "SAE Abrir Otro Año")
        End If
    End Sub
    Public Sub AbrirExistente()
        mibarra.Value = 95
        Dim tabla, tabla2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT codigo from sae.companias where login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <= 0 Then
            MsgBox("El período no se pudo abrir porque la compañia no existe, verifique. ", MsgBoxStyle.Information, "Guardar Datos")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * from sae.periodos where codigo='" & tabla2.Rows(0).Item("codigo") & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        PerActual = "01/" & ano.Value
        Try
            Dim swEscritor As StreamWriter
            swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\" & Trim(FrmPrincipal.lbcompania.Text) & ".txt", False)
            swEscritor.Write(Trim(PerActual))
            swEscritor.Close()
        Catch ex As Exception
        End Try
        FrmPrincipal.LbPeriodo.Text = PerActual
        MiConexion("sae")
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?periodo", "01/" & ano.Value)
        If tabla.Rows.Count > 0 Then
            myCommand.CommandText = "Update sae.periodos set activo='SI',periodo=?periodo WHERE codigo='" & tabla.Rows(0).Item("codigo") & "';"
        Else
            myCommand.CommandText = "INSERT INTO sae.periodos Values(?periodo, '00','SI','" & tabla.Rows(0).Item("codigo") & "');"
        End If
        myCommand.ExecuteNonQuery()
        Cerrar()
    End Sub
    '

End Class