Public Class FrmSelOrdenPagoDoc
    Public fila As Integer
    Private Sub FrmSelOrdenPagoDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cbper.Text = "TODOS"
        cbper.Text = Strings.Left(PerActual, 2)
        lbper.Text = "ORDENES DEL PERIODO " & PerActual
        llenar(" sop_cont LIKE '" & cbper.Text & "%' AND ")
    End Sub
    Private Sub llenar(ByVal cond As String)
        Dim f As String = ""
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            Dim anio As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            f = DateSerial(Strings.Right(PerActual, 4), Strings.Left(PerActual, 2) + 1, 0)
            f = Strings.Right(f, 4) & "-" & Strings.Mid(f, 4, 2) & "-" & Strings.Left(f, 2)
            'myCommand.CommandText = "SELECT doc, con_num, con_objeto, nomnit, con_valor, estado,sop_cont,   " _
            '& " CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) as fc FROM ord_pagos WHERE " & cond & " fecha<='" & f & "' AND estado<>'AN' AND sop_cont<>'' ORDER BY sop_cont;"

            myCommand.CommandText = "SELECT doc, con_num, con_objeto, nomnit, con_valor, estado,sop_cont,   " _
           & " CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) as fc FROM ord_pagos WHERE " & cond & "  estado<>'AN' AND sop_cont<>'' ORDER BY sop_cont;"

            '  myCommand.CommandText = "SELECT * FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' ORDER BY doc,fecha;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No existe ningun Egreso en el periodo seleccionado " & cbper.Text & ", Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                gitems.Rows.Clear()
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                If tabla.Rows(i).Item("doc").ToString <> "" Then
                    gitems.Item("ord", i).Value = tabla.Rows(i).Item("doc").ToString
                    gitems.Item("cod", i).Value = tabla.Rows(i).Item("con_num").ToString
                    gitems.Item("nombre", i).Value = tabla.Rows(i).Item("con_objeto").ToString
                    gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fc").ToString, 10)
                    gitems.Item("razon", i).Value = tabla.Rows(i).Item("nomnit").ToString
                    gitems.Item("valor", i).Value = Moneda(CDbl(tabla.Rows(i).Item("con_valor").ToString))
                    If tabla.Rows(i).Item("estado") = "AP" Then
                        gitems.Item("estado", i).Value = "PAGADO"
                    Else
                        gitems.Item("estado", i).Value = "PENDIENTE"
                    End If
                    gitems.Item("cont", i).Value = tabla.Rows(i).Item("sop_cont").ToString
                End If
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        FrmNuevoEgreso.txtorden.Text = gitems.Item("ord", mifila).Value()
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "N° ORDEN" Then
                cl = 2
            ElseIf cmbbuscar.Text = "CONTRATO" Then
                cl = 3
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 5
            ElseIf cmbbuscar.Text = "RAZON" Then
                cl = 6
            ElseIf cmbbuscar.Text = "DOC CE" Then
                cl = 1
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
            cmbbuscar.Text = "DOC CE"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "DOC CE"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub

    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        If cbper.Text = "TODOS" Then
            llenar("")
        Else
            llenar(" sop_cont LIKE '" & cbper.Text & "%' AND ")
        End If
    End Sub
End Class