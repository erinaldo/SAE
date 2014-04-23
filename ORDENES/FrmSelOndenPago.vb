Public Class FrmSelOndenPago
    Public fila As Integer
    Private Sub FrmSelOndenPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lbper.Text = "ORDENES DEL PERIODO " & PerActual
        cbper.Text = Strings.Left(PerActual, 2)
        If lbform.Text = "egre_ord" Then
            cbper.Enabled = True
            llenarG(" per like '" & cbper.Text & "%' and  ")
        Else
            cbper.Enabled = False
            llenarG("per like '" & PerActual & "%' and ")
        End If
    End Sub
    Private Sub llenarG(ByVal cond As String)
        Dim f As String = ""

        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            Dim anio As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
            If lbform.Text = "egre_ord" Then

                If cbper.Text = "TODOS" Then
                    f = DateSerial(Strings.Right(PerActual, 4), Strings.Left(PerActual, 2) + 1, 0)
                    f = Strings.Right(f, 4) & "-" & Strings.Mid(f, 4, 2) & "-" & Strings.Left(f, 2)
                    cond = cond & " fecha<='" & f & "' and "
                End If
                'myCommand.CommandText = "SELECT doc, con_num, con_objeto, nomnit, con_valor, estado,sop_cont,   " _
                '& " CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) as fc FROM ord_pagos WHERE " & cond & " fecha<='" & f & "' AND estado<>'AN' and sop_cont='' ORDER BY fecha,doc;"
                myCommand.CommandText = "SELECT doc, con_num, con_objeto, nomnit, con_valor, estado,sop_cont,   " _
           & " CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) as fc FROM ord_pagos WHERE " & cond & "  estado<>'AN' and sop_cont='' ORDER BY fecha,doc;"
            Else
                myCommand.CommandText = "SELECT doc, con_num, con_objeto, nomnit, con_valor, estado, sop_cont,  " _
                & " CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) as fc FROM ord_pagos WHERE " & cond & " estado<>'AN' ORDER BY doc,fecha;"
            End If
            '  myCommand.CommandText = "SELECT * FROM ord_pagos WHERE per='" & PerActual & "' AND estado<>'AN' ORDER BY doc,fecha;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay ninguna orden el el periodo " & PerActual & ", Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
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
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "ordenes"
                If gitems.Item("ord", mifila).Value() = "" Then Exit Sub
                FrmOrdenPagos.txtorden.Text = gitems.Item("ord", mifila).Value()
                FrmOrdenPagos.lbestado.Text = "CONSULTA"
                FrmOrdenPagos.lbnroobs.Text = mifila + 1
            Case "egre_ord"
                FrmNuevoEgreso.txtorden.Text = gitems.Item("ord", mifila).Value()
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
            If cmbbuscar.Text = "N° ORDEN" Then
                cl = 1
            ElseIf cmbbuscar.Text = "CONTRATO" Then
                cl = 2
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 4
            ElseIf cmbbuscar.Text = "RAZON" Then
                cl = 5
            ElseIf cmbbuscar.Text = "DOC CE" Then
                cl = 8
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
            cmbbuscar.Text = "N° ORDEN"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "N° ORDEN"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
       
        If lbform.Text = "egre_ord" Then
            If cbper.Text = "TODOS" Then
                llenarG(" ")
            Else
                llenarG("per like '" & cbper.Text & "%' and ")
            End If
        Else
            llenarG("per like '" & PerActual & "%' and ")
        End If
    End Sub
End Class