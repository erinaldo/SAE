Public Class FrmAdaptacionPUC

    Private Sub FrmAdaptacionPUC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NivaleAux()
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        llenar()
    End Sub
    Public Sub llenar()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim tabla, tabla2, tabla3 As New DataTable
            Dim items As Integer
            Dim tipo As String = ""
            '******************************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" + FrmPrincipal.lbcompania.Text + "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            tipo = tabla3.Rows(0).Item("tipo")
            If tipo = "comercial" Then
                tipo = "puc"
            ElseIf tipo = "cooperativo" Then
                tipo = "puc_coop"
            ElseIf tipo = "publico" Then
                tipo = "puc_public"
            Else 
                tipo = "puc_salud"
            End If
            '********************************
            myCommand.CommandText = "SELECT * FROM sae." & tipo & " ORDER BY codigo;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han seleccionado ninguna cuenta del PUC, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gcuenta.Rows.Clear()
            Catch ex As Exception
            End Try
            gcuenta.RowCount = items
            For i = 0 To items - 1
                tabla2.Clear()
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & tabla.Rows(i).Item("codigo") & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                If tabla2.Rows.Count > 0 Then
                    gcuenta.Item(0, i).Value = True
                    gcuenta.Item(3, i).Value = True
                Else
                    gcuenta.Item(0, i).Value = False
                    gcuenta.Item(3, i).Value = False
                End If
                gcuenta.Item(1, i).Value = tabla.Rows(i).Item("codigo")
                gcuenta.Item(2, i).Value = tabla.Rows(i).Item("descripcion")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    '*************GUARDAR LAS CUENTA************
    Private Sub cmdcambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcambiar.Click
        If bas_con <> "E" Then
            MsgBox("No tienes permisos para esta operación.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            mibarra.Visible = True
            mibarra.Value = 5
            MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
            GuardarPUC()
            mibarra.Value = 100
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
            MsgBox("Las cuentas fueron agregadas correctamente.", MsgBoxStyle.Information, "Verificando")
            Cerrar()
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                '........
                Guar_MovUser("CONTABILIDAD", "ADAPTACION DEL PUC ", "", "", "")
                '.............
            End If
        Catch ex As Exception
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarPUC()
        Dim barra, baraux As Double
        barra = 100 / gcuenta.RowCount
        Dim cad, cad2, nat, nivel, tipo, sql As String
        nat = ""
        nivel = ""
        tipo = ""
        For i = 0 To gcuenta.RowCount - 1
            If gcuenta.Item(0, i).Value = True And gcuenta.Item(3, i).Value = False Then
                cad = gcuenta.Item(1, i).Value
                Select Case cad(0)
                    Case "1"
                        nat = "D"
                        tipo = "Activo"
                    Case "2"
                        nat = "C"
                        tipo = "Pasivo"
                    Case "3"
                        nat = "C"
                        tipo = "Capital"
                    Case "4"
                        nat = "C"
                        tipo = "Ingresos"
                    Case "5"
                        nat = "D"
                        tipo = "Egresos"
                    Case "6"
                        nat = "D"
                        tipo = "Egresos"
                    Case "7"
                        nat = "D"
                        tipo = "Egresos"
                    Case "8"
                        nat = "D"
                        tipo = "Activo"
                    Case "9"
                        nat = "D"
                        tipo = "Egresos"
                End Select
                cad2 = ""
                For j = 0 To (Val(cad.Length) - 1)
                    cad2 = cad2 & cad(j)
                    If Val(cad2.Length) = 1 Then
                        nivel = "Clase"
                        If Verificar(cad2) = True Then 'NO EXISTE LA CUENTA
                            sql = "INSERT INTO selpuc VALUES " _
                            & "('" & cad2 & "','" & BuscarDescripcion(cad2) & "','" & nat & "','" & nivel & "','" & tipo & "',0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
                            InsertSELPUC(sql)
                        End If
                    ElseIf Val(cad2.Length) = 2 Then
                        nivel = "Grupo"
                        If Verificar(cad2) = True Then 'NO EXISTE LA CUENTA
                            sql = "INSERT INTO selpuc VALUES " _
                            & "('" & cad2 & "','" & BuscarDescripcion(cad2) & "','" & nat & "','" & nivel & "','" & tipo & "',0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
                            InsertSELPUC(sql)
                        End If
                    ElseIf Val(cad2.Length) = 4 Then
                        nivel = "Cuenta"
                        If Verificar(cad2) = True Then 'NO EXISTE LA CUENTA
                            sql = "INSERT INTO selpuc VALUES " _
                            & "('" & cad2 & "','" & BuscarDescripcion(cad2) & "','" & nat & "','" & nivel & "','" & tipo & "',0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
                            InsertSELPUC(sql)
                        End If
                    ElseIf Val(cad2.Length) = 6 Then
                        nivel = "Sub Cuenta"
                        If Verificar(cad2) = True Then 'NO EXISTE LA CUENTA
                            If Nivel_Todo() = 6 Then
                                nivel = "Auxiliar"
                            End If
                            sql = "INSERT INTO selpuc VALUES " _
                            & "('" & cad2 & "','" & BuscarDescripcion(cad2) & "','" & nat & "','" & nivel & "','" & tipo & "',0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
                            InsertSELPUC(sql)
                            '********* INSERT AUXILIAR ******************************
                            If Nivel_Todo() <> 6 Then
                                nivel = "Auxiliar"
                                Dim auxiliar, ceros As String
                                ceros = ""
                                For ind = 1 To Val(lbnivel.Text) - 1
                                    ceros = ceros & "0"
                                Next
                                ceros = ceros & "1"
                                auxiliar = cad2 & ceros
                                If Verificar(auxiliar) = True Then 'NO EXISTE LA CUENTA
                                    sql = "INSERT INTO selpuc VALUES " _
                                    & "('" & auxiliar & "','" & BuscarDescripcion(cad2) & "','" & nat & "','" & nivel & "','" & tipo & "',0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,'NO');"
                                    InsertSELPUC(sql)
                                End If
                            End If
                            '********* FIN INSERT AUXILIAR ******************************
                        End If
                    End If
                Next
            End If
            '************** CONTROLAR BARRA DE ESTADO ************       
            If mibarra.Value + barra < 98 Then
                baraux = baraux + barra
                If baraux >= 1 Then
                    mibarra.Value = mibarra.Value + 1
                    baraux = 0
                End If
            Else
                mibarra.Value = 95
            End If
            '********** FIN BARRA DE ESTADO ****************
        Next
    End Sub
    Public Sub NivaleAux()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nivel5 FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbnivel.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
            lbnivel.Text = "2"
        End Try

    End Sub
    Function Nivel_Todo()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT longitud FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Return tabla.Rows(0).Item(0)
        Catch ex As Exception
            Return "6"
        End Try
    End Function
    Function Verificar(ByVal cuenta As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function BuscarDescripcion(ByVal cuenta As String)
        For i = 0 To gcuenta.RowCount - 1
            If cuenta = gcuenta.Item(1, i).Value Then
                gcuenta.Item(3, i).Value = True
                gcuenta.Item(0, i).Value = True
                Return gcuenta.Item(2, i).Value
                Exit Function
            End If
        Next
        Return "Ninguna"
    End Function
    Public Sub InsertSELPUC(ByVal sql As String)
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub

    '*************BUSCAR EN LA GRILLA LAS CUENTA************
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gcuenta.RowCount - 2
            aux = gcuenta.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 1, F As Integer = i
                    gcuenta.CurrentCell = gcuenta(C, F)
                    gcuenta.Focus()
                    Exit Sub
                End If
            End If
        Next
        txtcuenta.Focus()
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            gcuenta.Focus()
            BuscarGrilla(txtcuenta.Text)
        Else
            validarnumero(txtcuenta, e)
        End If
    End Sub

    Private Sub CheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAll.CheckedChanged
        If CheckAll.Checked = True Then
            For i = 0 To gcuenta.RowCount - 1
                If Trim(gcuenta.Item("nombre", i).Value.ToString) <> "" Then
                    gcuenta.Item(0, i).Value = True
                End If
            Next
        Else
            llenar()
        End If
    End Sub
End Class