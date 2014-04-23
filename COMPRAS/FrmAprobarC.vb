Imports MySql.Data.MySqlClient
Public Class FrmAprobarC
    Dim p As String
    Dim conexion As New MySqlConnection
    Dim cadena As String
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmAprobarC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        txtaño.Text = PerActual(2) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Dim resultado As MsgBoxResult

        conexion.Close()
        p = cbper.Text
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM  `ot_cpp" & p & "` WHERE estado <>  'AP' AND item = 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count > 0 Then
            resultado = MsgBox("Desea aprobar todos los documentos del  periodo " & p & " ?", MsgBoxStyle.YesNo, "Confirmacion")
            If resultado = MsgBoxResult.No Then
                Me.Close()
            Else
                Dim it As Integer = 0
                mibarra.Value = 0
                mibarra.Visible = True
                mibarra.Maximum = tabla.Rows.Count
                it = 1
                Me.Cursor = Cursors.WaitCursor
                For i = 0 To tabla.Rows.Count - 1
                    aprobar(tabla.Rows(i).Item("doc"))
                    documentos(tabla.Rows(i).Item("doc"))
                    cuentas(tabla.Rows(i).Item("doc"))
                    GuardarAnticipos(tabla.Rows(i).Item("credito"), tabla.Rows(i).Item("doc_anti"))
                    mibarra.Value = mibarra.Value + it
                Next
                mibarra.Visible = False
                Me.Cursor = Cursors.Default
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("COMPRAS", "APROBAR TODOS LOS CXP P-" & cbper.Text, "", "", "")
                End If
                '.....
                MsgBox("El proceso se realizo con exito", MsgBoxStyle.Information, "SAE")
            End If
        Else
            MsgBox(" No existen documentos a aprobar en el periodo " & p & " ")
        End If
    End Sub
    Private Sub GuardarAnticipos(ByVal valor As String, ByVal doc As String)
        'otros conceptos
        Dim sql As String = ""
        Dim sig As String = "+"
        Try
            If Trim(doc) <> "" Then
                myCommand.Parameters.Clear()
                sql = "UPDATE ant_a_prov SET causado = causado " & sig & " " & DIN(valor) & " WHERE per_doc='" & Trim(doc) & "';"
                'MsgBox(sql)
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub aprobar(ByVal doc As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE ot_cpp" & p & " SET estado = 'AP' WHERE doc = '" & doc & "'  "
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub documentos(ByVal doc As String)

        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM ot_cpp" & p & " WHERE doc = '" & doc & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            For i = 0 To tabla.Rows.Count - 1
                Try
                    myCommand.Parameters.Clear()
                    myCommand.Parameters.AddWithValue("?item", tabla.Rows(i).Item("item"))
                    myCommand.Parameters.AddWithValue("?doc", Strings.Right(tabla.Rows(i).Item("doc"), 5))
                    myCommand.Parameters.AddWithValue("?tipodoc", tabla.Rows(i).Item("tipo"))
                    myCommand.Parameters.AddWithValue("?periodo", tabla.Rows(i).Item("periodo"))
                    myCommand.Parameters.AddWithValue("?dia", tabla.Rows(i).Item("dia"))
                    myCommand.Parameters.AddWithValue("?centro", 0)
                    myCommand.Parameters.AddWithValue("?descri", tabla.Rows(i).Item("descrip"))
                    myCommand.Parameters.AddWithValue("?debito", tabla.Rows(i).Item("debito"))
                    myCommand.Parameters.AddWithValue("?credito", tabla.Rows(i).Item("credito"))
                    myCommand.Parameters.AddWithValue("?codigo", tabla.Rows(i).Item("codigo"))
                    myCommand.Parameters.AddWithValue("?base", tabla.Rows(i).Item("base"))
                    myCommand.Parameters.AddWithValue("?diasv", 0)
                    myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
                    myCommand.Parameters.AddWithValue("?nit", tabla.Rows(i).Item("nitc"))
                    myCommand.Parameters.AddWithValue("?modulo", "Otros doc")

                    myCommand.CommandText = "INSERT INTO documentos" & p & " VALUES " _
                                         & "(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descri,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?modulo); "
                    myCommand.Connection = conexion
                    myCommand.ExecuteNonQuery()
                    Refresh()
                Catch ex As Exception
                End Try
            Next
        End If

    End Sub

    Private Sub cuentas(ByVal doc As String)
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM ot_cpp" & p & " WHERE doc = '" & doc & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item("doc_afec") <> "" Then
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE ctas_x_pagar SET pagado = pagado + " & tabla.Rows(i).Item("abonado") & " WHERE doc = '" & tabla.Rows(i).Item("doc_afec") & "'  "
                    myCommand.Connection = conexion
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Next
    End Sub
End Class