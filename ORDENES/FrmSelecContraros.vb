Public Class FrmSelecContraros
    Public fila As Integer
    Private Sub FrmSelecContraros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gitems.Rows.Clear()
        Catch ex As Exception
        End Try
        chord.Checked = True
        chord_CheckedChanged(AcceptButton, AcceptButton)
        'todas()
    End Sub
    Private Sub todas()
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            Dim anio As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT doc_ext,descrip,nitc,nomnit,fecha,total, pagare, doc FROM ctas_x_pagar WHERE total > pagado;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay ningun contrato por mostrar, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("cod", i).Value = tabla.Rows(i).Item("doc_ext").ToString
                gitems.Item("regpre", i).Value = tabla.Rows(i).Item("pagare").ToString
                gitems.Item("nombre", i).Value = tabla.Rows(i).Item("descrip").ToString
                gitems.Item("nit", i).Value = tabla.Rows(i).Item("nitc").ToString
                gitems.Item("razon", i).Value = UCase(tabla.Rows(i).Item("nomnit").ToString)
                gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
                gitems.Item("valor", i).Value = Moneda(CDbl(tabla.Rows(i).Item("total").ToString))
                gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc").ToString
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
            If gitems.Rows.Count > 0 Then
                Existente()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub pendiente()
        Try

       
            Dim docx As String = ""
            Dim ts As New DataTable
            ts.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT doccxp FROM ord_pagos ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ts)
            Refresh()
            docx = "("
            If ts.Rows.Count > 0 Then
                For i = 0 To ts.Rows.Count - 1
                    If i <> ts.Rows.Count - 1 Then
                        docx = docx & "'" & ts.Rows(i).Item("doccxp") & "',"
                    Else
                        docx = docx & "'" & ts.Rows(i).Item("doccxp") & "'"
                    End If
                Next
            Else
                todas()
                Exit Sub
            End If
            docx = docx & ")"
            '////////////////////////////////
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            Dim anio As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT doc_ext,descrip,nitc,nomnit,fecha,total, pagare, doc FROM ctas_x_pagar WHERE total > pagado and doc  NOT IN " & docx & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay ningun contrato por mostrar, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("cod", i).Value = tabla.Rows(i).Item("doc_ext").ToString
                gitems.Item("regpre", i).Value = tabla.Rows(i).Item("pagare").ToString
                gitems.Item("nombre", i).Value = tabla.Rows(i).Item("descrip").ToString
                gitems.Item("nit", i).Value = tabla.Rows(i).Item("nitc").ToString
                gitems.Item("razon", i).Value = UCase(tabla.Rows(i).Item("nomnit").ToString)
                gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
                gitems.Item("valor", i).Value = Moneda(CDbl(tabla.Rows(i).Item("total").ToString))
                gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc").ToString
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Existente()
        Try
            Dim ts As New DataTable
            ts.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT doccxp, doc FROM ord_pagos ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ts)
            Refresh()
            If ts.Rows.Count > 0 Then
                For i = 0 To ts.Rows.Count - 1
                    For j = 0 To gitems.Rows.Count - 1
                        If ts.Rows(i).Item("doccxp") = gitems.Item("doc", j).Value Then
                            gitems.Item(1, j).Style.ForeColor = Color.Red
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)

        Dim ts As New DataTable
        ts.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT doccxp, doc FROM ord_pagos WHERE doccxp ='" & gitems.Item("doc", mifila).Value & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ts)
        Refresh()
        If ts.Rows.Count > 0 Then
            MsgBox("Esta cuenta por pagar Ya tiene asignada una orden (" & ts.Rows(0).Item(1) & ")", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "contra"
                FrmOrdenPagos.lbcp.Text = gitems.Item("doc", mifila).Value()
                FrmOrdenPagos.txtcontra.Text = gitems.Item("cod", mifila).Value()
                FrmOrdenPagos.txtdis.Text = gitems.Item("regpre", mifila).Value()

        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        'Try
        '    If cad = "" Then Exit Sub
        '    cad = UCase(cad)
        '    For i = 0 To gitems.RowCount - 1
        '        Try
        '            If gitems.Item(1, i).Value.ToString Like "*" & cad & "*" Then
        '                Dim C As Integer = 1, F As Integer = i
        '                gitems.CurrentCell = gitems(C, F)
        '                gitems.Focus()
        '                Exit Sub
        '            End If
        '        Catch ex As Exception
        '        End Try
        '    Next
        '    MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Terceros")
        'Catch ex As Exception
        'End Try
        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "COD RP" Then
                cl = 2
            ElseIf cmbbuscar.Text = "CONTRATO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "NIT/CEDULA" Then
                cl = 4
            ElseIf cmbbuscar.Text = "NOMBRE" Then
                cl = 5
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 6
            End If

            Try
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
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "COD RP"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "COD RP"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub chord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chord.CheckedChanged
        If chord.Checked = True Then
            pendiente()
        Else
            todas()
        End If
    End Sub
End Class