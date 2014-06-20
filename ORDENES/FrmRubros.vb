Public Class FrmRubros
    Dim cm, a As String
    Dim fila As Integer
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "COD INTERNO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub FrmRubros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        a = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable
        Dim ok As String = "n"
        myCommand.CommandText = "SHOW DATABASES;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item(0) = "presupuesto" & a Then
                ok = "s"
                Exit For
            End If
        Next
        If ok = "n" Then
            MsgBox("Esta empresa no usa el software de Presupuesto", MsgBoxStyle.Information, "SAE")
            Me.Close()
        End If


        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Try
            fecha1.MinDate = "01/01/" & ano
            fecha1.MaxDate = "31/12/" & ano
            fecha2.MinDate = "01/01/" & ano
            fecha2.MaxDate = "31/12/" & ano
            '**************************************

            fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception

        End Try
        Try
            fecha2.Value = DateSerial(Strings.Right(PerActual, 4), Strings.Left(PerActual, 2) + 1, 0)
            'fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception
            Try
                If PerActual(0) & PerActual(1) = "02" Then
                    fecha2.Value = "28/" & PerActual(0) & PerActual(1) & "/" & ano
                Else
                    fecha2.Value = "30/" & PerActual(0) & PerActual(1) & "/" & ano
                End If
            Catch ex2 As Exception
            End Try
        End Try

        Try
            gitems.Rows.Clear()
        Catch ex As Exception
        End Try

        cm = ""
        Dim tps As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select para_codigo from presupuesto" & a & ".parametros"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tps)
        If tps.Rows(0).Item(0) = "I" Then
            cm = "cod1"
        ElseIf tps.Rows(0).Item(0) = "F" Then
            cm = "fut"
        Else
            cm = "cgdg"
        End If

        ' cm = "c.ingc_" & cm
        If lbtipo.Text = "ing" Then
            gitems.Columns("recaudo").Visible = True
            gitems.Columns("acumu").Visible = True
            '...
            gitems.Columns("rp").Visible = False
            gitems.Columns("cdp").Visible = False
            gitems.Columns("pago").Visible = False
        Else
            gitems.Columns("recaudo").Visible = False
            gitems.Columns("acumu").Visible = False
            '...
            gitems.Columns("rp").Visible = True
            gitems.Columns("cdp").Visible = True
            gitems.Columns("pago").Visible = True
        End If



    End Sub
    Private Sub Mostrar()
        Dim f1, f2 As String

        f1 = Strings.Right(CDate(fecha1.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha1.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha1.Text.ToString), 2)
        f2 = Strings.Right(CDate(fecha2.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha2.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha2.Text.ToString), 2)


        Dim tp As New DataTable
        tp.Clear()
        myCommand.Parameters.Clear()
        If lbtipo.Text = "ing" Then
            myCommand.CommandText = "SELECT  c.ingc_orden, c.ingc_" & cm & ", c.ingc_sd, c.ingc_concepto, v.ingv_valor, IFNULL(m.rc,0) AS recaud, " _
       & " IFNULL(a.acum,0) AS acum " _
       & " FROM presupuesto" & a & ".ingvalores v, presupuesto" & a & ".ingconcepto c  " _
       & " LEFT JOIN (SELECT movi_rubro, SUM(movi_recaudo) AS acum FROM presupuesto" & a & ".movingresos WHERE movi_fecha  " _
       & "  BETWEEN '" & a & "-01-01' AND '" & f2 & "' AND movi_recaudo<>0  " _
       & "  GROUP BY movi_rubro ORDER BY movi_rubro) a ON a.movi_rubro=c.ingc_orden  " _
       & "  Left Join " _
       & "  ( SELECT movi_rubro, SUM(movi_recaudo) rc FROM presupuesto" & a & ".movingresos WHERE movi_fecha  " _
       & "   BETWEEN '" & f1 & "' AND '" & f2 & "' AND movi_recaudo<>0  " _
       & "  GROUP BY movi_rubro ORDER BY movi_rubro) m " _
       & " ON m.movi_rubro=a.movi_rubro " _
       & "  WHERE c.ingc_orden=v.ingv_orden"
            myAdapter.SelectCommand = myCommand
        Else
            myCommand.CommandText = " SELECT  c.gasc_orden, c.gasc_" & cm & ", c.gasc_sd, c.gasc_concepto, v.gasv_valor, IFNULL(a.cdp,0) AS cdp, IFNULL(a.pagos,0) pg," _
& " IFNULL(a.rp,0) AS rp  FROM presupuesto" & a & ".gasvalores v, presupuesto" & a & ".gasconcepto c   LEFT JOIN " _
& " (SELECT movg_rubro, SUM(movg_rp) AS rp, SUM(movg_cdp) cdp, SUM(mov_vsae) pagos FROM presupuesto" & a & ".movgastos WHERE " _
& " movg_fecha BETWEEN '" & f1 & "' AND '" & f2 & "' " _
& " GROUP BY movg_rubro ORDER BY movg_rubro) a ON a.movg_rubro=c.gasc_orden " _
& " WHERE c.gasc_orden=v.gasv_orden   " _
& " ORDER BY c.gasc_orden"

            myAdapter.SelectCommand = myCommand
        End If
       
        myAdapter.Fill(tp)

        If tp.Rows.Count > 0 Then

            Dim style As New DataGridViewCellStyle
            style.Font = New Font(gitems.Font, FontStyle.Bold)
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = tp.Rows.Count
            For i = 0 To tp.Rows.Count - 1
                If tp.Rows(i).Item(2) = "S" Then
                    gitems.Rows(i).DefaultCellStyle = style
                End If
                If lbtipo.Text = "ing" Then
                    gitems.Item("cod_int", i).Value = tp.Rows(i).Item(0)
                    gitems.Item("cod", i).Value = tp.Rows(i).Item(1)
                    gitems.Item("descrip", i).Value = UCase(tp.Rows(i).Item(3))
                    gitems.Item("ini", i).Value = Moneda(tp.Rows(i).Item(4))
                    gitems.Item("recaudo", i).Value = Moneda(tp.Rows(i).Item(5))
                    gitems.Item("acumu", i).Value = Moneda(tp.Rows(i).Item(6))
                    gitems.Item("sd", i).Value = tp.Rows(i).Item(2)
                Else
                    gitems.Item("cod_int", i).Value = tp.Rows(i).Item(0)
                    gitems.Item("cod", i).Value = tp.Rows(i).Item(1)
                    gitems.Item("descrip", i).Value = UCase(tp.Rows(i).Item(3))
                    gitems.Item("ini", i).Value = Moneda(tp.Rows(i).Item(4))
                    gitems.Item("rp", i).Value = Moneda(tp.Rows(i).Item("rp"))
                    gitems.Item("cdp", i).Value = Moneda(tp.Rows(i).Item("cdp"))
                    gitems.Item("pago", i).Value = Moneda(tp.Rows(i).Item("pg"))
                    gitems.Item("sd", i).Value = tp.Rows(i).Item(2)
                End If
               
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        End If

    End Sub

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        Mostrar()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "COD INTERNO"
            End If
            BuscarGrilla(txtcuenta.Text)
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

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub
End Class