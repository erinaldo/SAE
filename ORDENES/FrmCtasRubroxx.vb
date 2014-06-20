Public Class FrmCtasRubroxx
    Dim a As String
    Private Sub FrmCtasRubroxx_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        a = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        If tiprb.Text = "GASTOS" Then
            myCommand.CommandText = " select " & lbcm.Text & ", c.gasc_concepto, c.gasc_cod1, c.gasc_sd,  c.gasc_ctafpg, c.gasc_ctagas " _
       & " from presupuesto" & a & ".gasconcepto c "
        Else
            myCommand.CommandText = " select " & lbcm.Text & ", c.ingc_concepto, c.ingc_cod1, c.ingc_sd,   v.ingv_contrac, v.ingv_credito " _
       & " from presupuesto" & a & ".ingconcepto c,  presupuesto" & a & ".ingvalores v where c.ingc_cod1= v. ingv_cod1 "
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
            Exit Sub
        Else

            Dim style As New DataGridViewCellStyle
            style.Font = New Font(gitems.Font, FontStyle.Bold)
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = tabla.Rows.Count + 1
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item(3) = "S" Then
                    gitems.Rows(i).DefaultCellStyle = style
                    gitems.Item("guarcol", i).ReadOnly = True
                End If
                gitems.Item("cod_int", i).Value = tabla.Rows(i).Item(2)
                gitems.Item("cod", i).Value = tabla.Rows(i).Item(0)
                gitems.Item("descrip", i).Value = UCase(tabla.Rows(i).Item(1))
                gitems.Item("cta_db", i).Value = tabla.Rows(i).Item(5)
                gitems.Item("cta_cr", i).Value = tabla.Rows(i).Item(4)
                gitems.Item("sd", i).Value = tabla.Rows(i).Item(3)
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        End If
    End Sub
    Public Sub GuardarFila(ByVal f As Integer)

        Dim rs As MsgBoxResult
        rs = MsgBox("Las cuentas seran asignadas al Rubro,¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
        If rs = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            If tiprb.Text = "GASTOS" Then
                myCommand.CommandText = "UPDATE presupuesto" & a & ".gasconcepto SET gasc_ctafpg='" & gitems.Item("cta_cr", f).Value & "', gasc_ctagas='" & gitems.Item("cta_db", f).Value & "' WHERE gasc_cod1='" & gitems.Item("cod_int", f).Value & "';"
            Else
                myCommand.CommandText = "UPDATE presupuesto" & a & ".ingvalores SET ingv_contrac='" & gitems.Item("cta_cr", f).Value & "', ingv_credito='" & gitems.Item("cta_db", f).Value & "' WHERE ingv_cod1='" & gitems.Item("cod_int", f).Value & "';"
            End If
            myCommand.ExecuteNonQuery()
            Cerrar()
        End If
    End Sub
    Public fila, col As Integer

    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
       
        Try
            Select Case e.ColumnIndex
                Case 5 'CASO PRECIO 
                    If gitems.Item("sd", fila).Value = "S" Then
                        MsgBox("No puede asignar cuentas a rubros superiores", MsgBoxStyle.Information, "Verificacion")
                        Exit Sub
                    End If
                    GuardarFila(fila)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        If e.RowIndex >= gitems.RowCount - 1 Then Exit Sub
        Select Case e.ColumnIndex
            Case 3
                BuscarctaD(gitems.Item(3, e.RowIndex).Value, e.RowIndex, 3)
            Case 4
                BuscarctaC(gitems.Item(4, e.RowIndex).Value, e.RowIndex, 4)
        End Select
          
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        If col = 3 Then
            MostraCtaD(fila)
        ElseIf col = 4 Then
            MostraCtaC(fila)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "COD INTERNO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "OTRO CODIGO" Then
                cl = 1
            Else
                cl = 2
            End If

            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = fila + 1 To gitems.RowCount - 1
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Terceros")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "COD INTERNO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "COD INTERNO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = "13" And col = 5 Then
            GuardarFila(fila)
        End If
    End Sub
    Public Sub BuscarctaD(ByVal cuenta As String, ByVal fila As Integer, ByVal tp As String)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ctarbd"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                'If FrmEntradaDatos.nivel_cuenta(grilla2.Item(0, fila).Value) = True Then
                gitems.Item(3, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "ctarbd"
                FrmCuentas.lbfila.Text = fila
                If cuenta <> "" Then
                    FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                End If
                FrmCuentas.ShowDialog()
                'End If
            Else
                'gitems.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
            End If
        End If

    End Sub
    Public Sub BuscarctaC(ByVal cuenta As String, ByVal fila As Integer, ByVal tp As String)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ctarbc"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                'If FrmEntradaDatos.nivel_cuenta(grilla2.Item(0, fila).Value) = True Then
                gitems.Item(4, fila).Value = ""
                FrmCuentas.txtcuenta.Text = cuenta
                FrmCuentas.lbform.Text = "ctarbc"
                FrmCuentas.lbfila.Text = fila
                If cuenta <> "" Then
                    FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                End If
                FrmCuentas.ShowDialog()
                'End If
            Else
                'gitems.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
            End If
        End If

    End Sub
    Private Sub MostraCtaD(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & gitems.Item(3, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcta.Text = "CUENTA CONTABLE: " & tabla.Rows(0).Item("codigo").ToString & " " & UCase(tabla.Rows(0).Item("descripcion").ToString)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbcta.Text = ""
        End Try
    End Sub
    Private Sub MostraCtaC(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT codigo,descripcion FROM selpuc WHERE codigo='" & gitems.Item(4, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcta.Text = "CUENTA CONTABLE: " & tabla.Rows(0).Item("codigo").ToString & " " & UCase(tabla.Rows(0).Item("descripcion").ToString)
        Catch ex As Exception
            'MsgBox(ex.ToString)
            lbcta.Text = ""
        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
End Class