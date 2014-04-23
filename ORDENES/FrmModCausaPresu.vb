Public Class FrmModCausaPresu

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub FrmModCausaPresu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        LlenarGrilla()
    End Sub
    Public Sub LlenarGrilla()
        Dim sql As String = "SELECT * FROM ctas_x_pagar WHERE MONTH(fecha)='" & cbper.Text & "' OR MONTH(fecha)='" & Val(cbper.Text) & "' ORDER BY fecha;"
        Try
            'MsgBox(sql)
            Dim tabla As New DataTable
            myCommand.CommandText = Sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then Exit Sub
            gitems.RowCount = tabla.Rows.Count
            lbitem.Text = "HAY " & tabla.Rows.Count & " ITEM(S) EN LA LISTA..."
            For i = 0 To tabla.Rows.Count - 1
                gitems.Item("codigo", i).Value = tabla.Rows(i).Item("doc").ToString
                gitems.Item("ref", i).Value = tabla.Rows(i).Item("doc_ext").ToString
                gitems.Item("objeto", i).Value = tabla.Rows(i).Item("descrip").ToString
                gitems.Item("desc", i).Value = tabla.Rows(i).Item("nomnit").ToString
                gitems.Item("nit", i).Value = tabla.Rows(i).Item("nitc").ToString
                gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
                gitems.Item("monto", i).Value = Moneda(tabla.Rows(i).Item("total").ToString)
                If tabla.Rows(i).Item("ctatotal").ToString = "null" Then
                    gitems.Item("ctapp", i).Value = BuscarCtaPP(tabla.Rows(i).Item("num").ToString, tabla.Rows(i).Item("tipo").ToString)
                Else
                    gitems.Item("ctapp", i).Value = tabla.Rows(i).Item("ctatotal").ToString
                End If

                gitems.Item("ctagas", i).Value = BuscarCtaGas(tabla.Rows(i).Item("num").ToString, tabla.Rows(i).Item("tipo").ToString)
                gitems.Item("ctagas2", i).Value = gitems.Item("ctagas", i).Value
                gitems.Item("ctapp2", i).Value = gitems.Item("ctapp", i).Value
                gitems.Item("nd", i).Value = tabla.Rows(i).Item("num").ToString
                gitems.Item("td", i).Value = tabla.Rows(i).Item("tipo").ToString
            Next
        Catch ex As Exception
            MsgBox(Sql & "***********" & ex.ToString)
        End Try
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Function BuscarCtaPP(ByVal d As String, ByVal t As String)
        Dim cad As String = ""
        Try
            Dim tabla As New DataTable
            Dim per As String = ""
            For i = Val(cbper.Text) To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i.ToString
                End If
                myCommand.CommandText = "SELECT codigo FROM documentos" & per & " WHERE  doc='" & d & "' AND tipodoc='" & t & "' AND item='1';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count > 0 Then
                    cad = tabla.Rows(0).Item(0)
                    Try
                        myCommand.CommandText = "UPDATE ctas_x_pagar SET ctatotal=" & cad & " WHERE doc ='" & t & NumeroDoc(d) & "';"
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try
                    Exit For
                End If

            Next

        Catch ex As Exception

        End Try
        Return cad
    End Function
    Function BuscarCtaGas(ByVal d As String, ByVal t As String)
        Dim cad As String = ""
        Try
            Dim tabla As New DataTable
            Dim per As String = ""
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i.ToString
                End If
                myCommand.CommandText = "SELECT codigo FROM documentos" & per & " WHERE  doc='" & d & "' AND tipodoc='" & t & "' AND item='2';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count > 0 Then
                    cad = tabla.Rows(0).Item(0)
                    Exit For
                End If

            Next

        Catch ex As Exception

        End Try
        Return cad
    End Function

    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        gitems.RowCount = 1
        gitems.Rows.Clear()
        LlenarGrilla()
    End Sub
    Public col, fila As Integer

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 7 'CASO CUENTA
                    Buscarcuentas(gitems.Item(7, e.RowIndex).Value, e.RowIndex, 7)
                Case 8 'CASO CUENTA
                    Buscarcuentas(gitems.Item(8, e.RowIndex).Value, e.RowIndex, 8)
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex
                Case 7 'CASO CCOSTO
                    gitems.Item(7, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex, 7)
                Case 8 'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    gitems.Item(8, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex, 8)
            End Select
        End Try
        
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal f As Integer, ByVal t As Integer)
        Try
            If cuenta = "" Then

                FrmCuentas.lbform.Text = "ModPres" & t
                FrmCuentas.lbfila.Text = f
                FrmCuentas.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <= 0 Then
                    gitems.Item(t, f).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "ModPres" & t
                    FrmCuentas.lbfila.Text = f
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                Else
                    gitems.Item(t, f).Value = cuenta
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
    End Sub
    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = "13" And col = 9 Then
            GuardarFila(fila, col)
        End If
    End Sub
    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
        Try
            Select Case e.ColumnIndex
                Case 9 'guardar                   
                    GuardarFila(fila, col)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GuardarFila(ByVal f As Integer, ByVal c As Integer)
        MiConexion(bda)
        Dim sw As Integer = 0
        Try
            If (gitems.Item("ctagas", f).Value <> gitems.Item("ctagas2", f).Value) Then 'modficar cta gasto
                sw = 1
                UpCta(gitems.Item("ctagas", f).Value.ToString, "2", f)
            End If
            If (gitems.Item("ctapp", f).Value <> gitems.Item("ctapp2", f).Value) Then 'modficar cta por pagar
                sw = 1
                UpCta(gitems.Item("ctapp", f).Value.ToString, "1", f)
            End If
            If sw = 0 Then
                MsgBox("NO se modificaron datos..", MsgBoxStyle.Information, "SAE ")
            Else
                MsgBox("¡Datos Modificados!", MsgBoxStyle.Information, "SAE ")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub UpCta(ByVal codigo As String, ByVal it As String, ByVal f As Integer)
        Try
            Dim per As String = ""
            For i = 1 To 12
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i.ToString
                End If
                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE documentos" & per & " SET codigo=" & codigo & " WHERE doc ='" & gitems.Item("nd", f).Value & "' AND tipodoc='" & gitems.Item("td", f).Value & "' AND item='" & it & "';"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            Next
            If it = "1" Then 'hay que modificar ctas por pagar y buscar si tiene egreso para modificar tambien
                myCommand.Parameters.Clear()
                myCommand.CommandText = "UPDATE ctas_x_pagar SET ctatotal=" & codigo & " WHERE doc ='" & gitems.Item("codigo", f).Value & "';"
                myCommand.ExecuteNonQuery()
                BuscarEgreso(f)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarEgreso(ByVal f As Integer)
        Try
            'doc_afec
            Dim tabla As New DataTable
            Dim p As String = ""
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i.ToString
                End If
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT doc,item,tipo,num,doc_afec FROM ot_cpp" & p & " WHERE doc_afec='" & gitems.Item("codigo", f).Value & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count > 0 Then
                    myCommand.CommandText = "UPDATE documentos" & p & " SET codigo = " & gitems.Item("ctapp", f).Value & " WHERE codigo ='" & gitems.Item("ctapp2", f).Value.ToString & "' AND doc='" & tabla.Rows(0).Item("num").ToString & "' AND tipodoc='" & tabla.Rows(0).Item("tipo").ToString & "';"
                    myCommand.ExecuteNonQuery()
                    'myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE ot_cpp" & p & " SET codigo = " & gitems.Item("ctapp", f).Value & " WHERE doc_afec ='" & gitems.Item("codigo", f).Value & "';"
                    myCommand.ExecuteNonQuery()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub
End Class