Imports MySql.Data.MySqlClient
Public Class FrmAnaProv
    Dim docu As String = ""
    Dim doc_aj As String = ""
    Public fila As Integer
    Dim f1 As String = ""
    Dim f2 As String = ""
    Dim fe1 As String = ""
    Dim fe2 As String = ""

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub Limpiart()
        txtfecha2.Value = CDate(PerActual & "/" & "01")
        txtfecha1.Value = CDate(PerActual & "/" & "01")
        gventasF.Rows.Clear()
        gproductos.Rows.Clear()
        gcartera.Rows.Clear()
        gmes.Rows.Clear()
        gpagos.Rows.Clear()
        txtsubF.Text = ""
        txtsubmes.Text = ""
        txtdesF.Text = ""
        txtdesmes.Text = ""
        txttotF.Text = ""
        txtttmes.Text = ""
        lb_n_doc.Text = ""
        lb_n_pro.Text = ""
        txtcant.Text = ""
        txtvalor.Text = ""
    End Sub
    Private Sub LimpiarI()

        gventasF.Rows.Clear()
        gproductos.Rows.Clear()
        gcartera.Rows.Clear()
        gmes.Rows.Clear()
        gpagos.Rows.Clear()
        txtsubF.Text = ""
        txtsubmes.Text = ""
        txtdesF.Text = ""
        txtdesmes.Text = ""
        txttotF.Text = ""
        txtttmes.Text = ""
        lb_n_doc.Text = ""
        lb_n_pro.Text = ""
        txtcant.Text = ""
        txtvalor.Text = ""
    End Sub
    Private Sub FrmAnaProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gmes
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With
        With gpagos
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With
        With gventasF
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With
        With gproductos
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With
        With gcartera
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.GhostWhite
        End With

        Limpiart()
        txtnitc.Text = ""
        txtcliente.Text = ""
        lb_n_doc.Visible = False
        txtmes.Text = "Todos"
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            cargarclientes()
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "Anal_pro"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
        Limpiart()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            Dim sql As String = ""
            Dim p As String = ""
            LimpiarI()
            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Try
                Dim tb_aj As New DataTable
                tb_aj = New DataTable
                myCommand.CommandText = "SELECT doc_aj FROM par_comp ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb_aj)
                doc_aj = tb_aj.Rows(0).Item(0)
            Catch ex As Exception
            End Try

            f1 = CDate(txtfecha1.Text)
            fe1 = Strings.Right(f1, 4) & "-" & Strings.Mid(f1, 4, 2) & "-" & Strings.Left(f1, 2)
            f2 = CDate(txtfecha2.Text)
            fe2 = Strings.Right(f2, 4) & "-" & Strings.Mid(f2, 4, 2) & "-" & Strings.Left(f2, 2)


            If Strings.Left(f1, 4) <> Strings.Left(PerActual, 4) Then
                For i = 1 To CInt(Strings.Mid(f2, 4, 2))
                    If i >= 10 Then
                        p = i
                    Else
                        p = "0" & i
                    End If
                    If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                        sql = " SELECT f.fecha, f.doc FROM fact_comp" & p & " f WHERE f.nitc = '" & txtnitc.Text & "' "
                    ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                        sql = sql & " SELECT f.fecha, f.doc FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' UNION "
                    Else
                        sql = sql & " SELECT f.fecha, f.doc  FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' "
                    End If
                Next
            Else
                For i = CInt(Strings.Mid(f1, 4, 2)) To CInt(Strings.Mid(f2, 4, 2))
                    If i >= 10 Then
                        p = i
                    Else
                        p = "0" & i
                    End If
                    If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                        sql = " SELECT f.fecha, f.doc FROM fact_comp" & p & " f WHERE f.nitc = '" & txtnitc.Text & "' "
                    ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                        sql = sql & " SELECT f.fecha, f.doc FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' UNION "
                    Else
                        sql = sql & " SELECT f.fecha, f.doc  FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' "
                    End If
                Next
            End If

            Dim tabla2 As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myCommand.Connection = conexion
            myAdapter.Fill(tabla2)
            Refresh()

            '"SELECT doc FROM `ctas_x_pagar`   where nitc ='" & txtnitc.Text & "'  AND " _
            '& " fecha BETWEEN '" & fe1 & "' and '" & fe2 & "' AND pagado< total"

            If tabla2.Rows.Count = 0 Then
                MsgBox("En este rango de fechas no hay compras al proveedor ", MsgBoxStyle.Information)
                Exit Sub
            Else
                docu = "("
                For i = 0 To tabla2.Rows.Count - 1
                    If i <> tabla2.Rows.Count - 1 Then
                        docu = docu & " '" & tabla2.Rows(i).Item(1) & "' ,"
                    Else
                        docu = docu & " '" & tabla2.Rows(i).Item(1) & "' "
                    End If
                Next
                docu = docu & ")"
                facturas()
                productos(docu)
                cartera(docu)
                pagos(docu)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub facturas()

        Dim sql As String = ""
        Dim p As String = ""
        Dim items As Integer = 0


        If Strings.Left(f1, 4) <> Strings.Left(PerActual, 4) Then
            For i = 1 To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total, f.doc_afec FROM fact_comp" & p & " f WHERE f.nitc = '" & txtnitc.Text & "' "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total, f.doc_afec FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' UNION "
                Else
                    sql = sql & " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total,  f.doc_afec  FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' "
                End If
            Next
        Else
            For i = CInt(Strings.Mid(f1, 4, 2)) To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total, f.doc_afec  FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total, f.doc_afec   FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' UNION "
                Else
                    sql = sql & " SELECT f.fecha, f.doc, f.subtotal, f.descuento, f.total,  f.doc_afec  FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' "
                End If
            Next
        End If

        sql = sql & "ORDER BY fecha"

        Dim subt As Double = 0
        Dim dct As Double = 0
        Dim tt As Double = 0

        Dim tb As New DataTable
        tb.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        items = tb.Rows.Count
        lb_n_doc.Text = items & " DOCUMENTOS"
        lb_n_doc.Visible = True
        gventasF.Rows.Clear()
        gventasF.RowCount = items + 1
        For j = 0 To items - 1
            gventasF.Item(0, j).Value = tb.Rows(j).Item("fecha")
            gventasF.Item(1, j).Value = tb.Rows(j).Item("doc")
            If doc_aj = Strings.Left(tb.Rows(j).Item("doc"), 2) Then
                gventasF.Item(2, j).Value = Moneda("-" & tb.Rows(j).Item("subtotal"))
                subt = subt + gventasF.Item(2, j).Value
                gventasF.Item(3, j).Value = Moneda("-" & tb.Rows(j).Item("descuento"))
                dct = dct + gventasF.Item(3, j).Value
                gventasF.Item(4, j).Value = Moneda("-" & tb.Rows(j).Item("total"))
                tt = tt + gventasF.Item(4, j).Value
            Else
                gventasF.Item(2, j).Value = Moneda(tb.Rows(j).Item("subtotal"))
                subt = subt + gventasF.Item(2, j).Value
                gventasF.Item(3, j).Value = Moneda(tb.Rows(j).Item("descuento"))
                dct = dct + gventasF.Item(3, j).Value
                gventasF.Item(4, j).Value = Moneda(tb.Rows(j).Item("total"))
                tt = tt + gventasF.Item(4, j).Value
            End If
            gventasF.Item(5, j).Value = tb.Rows(j).Item("doc_afec")
        Next
        txtsubF.Text = Moneda(subt)
        txtdesF.Text = Moneda(dct)
        txttotF.Text = Moneda(tt)


        '************* MES A MES*************
        gmes.Rows.Clear()
        Dim sql2 As String = ""
        gmes.RowCount = 12
        gmes.Item(0, 0).Value = "ENERO"
        gmes.Item(0, 1).Value = "FEBRERO"
        gmes.Item(0, 2).Value = "MARZO"
        gmes.Item(0, 3).Value = "ABRIL"
        gmes.Item(0, 4).Value = "MAYO"
        gmes.Item(0, 5).Value = "JUNIO"
        gmes.Item(0, 6).Value = "JULIO"
        gmes.Item(0, 7).Value = "AGOSTO"
        gmes.Item(0, 8).Value = "SEPTIEMBRE"
        gmes.Item(0, 9).Value = "OCTUBRE"
        gmes.Item(0, 10).Value = "NOVIEMBRE"
        gmes.Item(0, 11).Value = "DICIEMBRE"

        If Strings.Left(f1, 4) <> Strings.Left(PerActual, 4) Then
            For k = 1 To CInt(Strings.Mid(f2, 4, 2))
                If k >= 10 Then
                    p = k
                Else
                    p = "0" & k
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql2 = "SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql2 = sql2 & " SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c UNION "
                Else
                    sql2 = sql2 & "SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c "
                End If
            Next
        Else
            For k = CInt(Strings.Mid(f1, 4, 2)) To CInt(Strings.Mid(f2, 4, 2))
                If k >= 10 Then
                    p = k
                Else
                    p = "0" & k
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql2 = "SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql2 = sql2 & " SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c UNION "
                Else
                    sql2 = sql2 & "SELECT '" & p & "' as mes, sum(c.sub) as subt, sum(c.des) as dsc, sum(c.tot) as tt, IF( IFNULL(SUM( c.sub ),'Y') <>'Y', 'N', 'Y' )  as n  FROM( SELECT f.doc, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.subtotal), f.subtotal) as sub, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.descuento), f.descuento) as des, if (left(f.doc,2)='" & doc_aj & "',concat('-',f.total), f.total) as tot FROM fact_comp" & p & " f  WHERE f.nitc = '" & txtnitc.Text & "' ) as c "
                End If
            Next
        End If

        Dim subt_m As Double = 0
        Dim dct_m As Double = 0
        Dim tt_m As Double = 0

        Dim tb_mes As New DataTable
        tb_mes.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb_mes)
        Refresh()

        For j = 0 To tb_mes.Rows.Count - 1
            If tb_mes.Rows(j).Item("n") <> "Y" Then
                gmes.Item(1, tb_mes.Rows(j).Item("mes") - 1).Value = Moneda(tb_mes.Rows(j).Item("subt"))
                subt_m = subt_m + gmes.Item(1, tb_mes.Rows(j).Item("mes") - 1).Value
                gmes.Item(2, tb_mes.Rows(j).Item("mes") - 1).Value = Moneda(tb_mes.Rows(j).Item("dsc"))
                dct_m = dct_m + gmes.Item(2, tb_mes.Rows(j).Item("mes") - 1).Value
                gmes.Item(3, tb_mes.Rows(j).Item("mes") - 1).Value = Moneda(tb_mes.Rows(j).Item("tt"))
                tt_m = tt_m + gmes.Item(3, tb_mes.Rows(j).Item("mes") - 1).Value
            End If
        Next

        txtsubmes.Text = Moneda(subt_m)
        txtdesmes.Text = Moneda(dct_m)
        txtttmes.Text = Moneda(tt_m)

    End Sub
    Private Sub cartera(ByVal docu As String)

        Dim sql As String = ""
        Dim tt As Double = 0
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT doc, fecha, vmto, total, (total-pagado) as saldo, concepto FROM ctas_x_pagar where nitc ='" & txtnitc.Text & "'  AND fecha BETWEEN '" & fe1 & "' and '" & fe2 & "' AND pagado< total ORDER BY fecha"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        gcartera.Rows.Clear()
        gcartera.RowCount = tb.Rows.Count + 1

        For i = 0 To tb.Rows.Count - 1
            gcartera.Item(0, i).Value = tb.Rows(i).Item("doc")
            gcartera.Item(1, i).Value = tb.Rows(i).Item("fecha")
            gcartera.Item(2, i).Value = tb.Rows(i).Item("vmto")
            If doc_aj = Strings.Left(tb.Rows(i).Item("doc"), 2) Then
                gcartera.Item(3, i).Value = Moneda("-" & tb.Rows(i).Item("total"))
                gcartera.Item(4, i).Value = Moneda("-" & tb.Rows(i).Item("saldo"))
                tt = tt + gcartera.Item(4, i).Value
            Else
                gcartera.Item(3, i).Value = Moneda(tb.Rows(i).Item("total"))
                gcartera.Item(4, i).Value = Moneda(tb.Rows(i).Item("saldo"))
                tt = tt + gcartera.Item(4, i).Value
            End If
            gcartera.Item(5, i).Value = tb.Rows(i).Item("concepto")
        Next

    End Sub
    Private Sub productos(ByVal docu As String)
        Dim sql As String = ""

        Dim p As String = ""
        Dim mes As String = ""


        If Strings.Left(f1, 4) <> Strings.Left(PerActual, 4) Then
            For i = 1 To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " UNION "
                Else
                    sql = sql & "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " "
                End If
            Next
        Else
            For i = CInt(Strings.Mid(f1, 4, 2)) To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = "SELECT doc, item,cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " "
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " UNION "
                Else
                    sql = sql & "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & p & "' as mes FROM detacomp" & p & " where doc IN  " & docu & " "
                End If
            Next
        End If
        sql = sql & "ORDER BY mes, doc, item"

        Dim t_doc As New DataTable
        t_doc.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t_doc)
        Refresh()

        Dim cant As Double = 0
        Dim valor As Double = 0
        gproductos.Rows.Clear()
        gproductos.RowCount = t_doc.Rows.Count + 1
        For j = 0 To t_doc.Rows.Count - 1
            gproductos.Item(0, j).Value = t_doc.Rows(j).Item("item")
            gproductos.Item(1, j).Value = t_doc.Rows(j).Item("cod_art")
            gproductos.Item(2, j).Value = t_doc.Rows(j).Item("nom_art")
            If doc_aj = Strings.Left(t_doc.Rows(j).Item("doc"), 2) Then
                gproductos.Item(3, j).Value = "-" & t_doc.Rows(j).Item("cantidad")
                cant = cant + gproductos.Item(3, j).Value
                gproductos.Item(4, j).Value = Moneda("-" & t_doc.Rows(j).Item("vtotal"))
                valor = valor + gproductos.Item(4, j).Value
            Else
                gproductos.Item(3, j).Value = t_doc.Rows(j).Item("cantidad")
                cant = cant + t_doc.Rows(j).Item("cantidad")
                gproductos.Item(4, j).Value = t_doc.Rows(j).Item("vtotal")
                valor = valor + t_doc.Rows(j).Item("vtotal")
            End If
            gproductos.Item(5, j).Value = t_doc.Rows(j).Item("mes")
        Next
        lb_n_pro.Text = cant & " PRODUCTOS"
        txtcant.Text = cant
        txtvalor.Text = Moneda(valor)
    End Sub

    Private Sub pagos(ByVal docu As String)
        Dim sql As String = ""
        Dim p As String = ""

        If Strings.Left(f1, 4) <> Strings.Left(PerActual, 4) Then

            For i = 1 To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If 1 = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = "SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj=''"
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & "SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj='' UNION "
                Else
                    sql = sql & " SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj=''"
                End If
            Next
        Else
            For i = CInt(Strings.Mid(f1, 4, 2)) To CInt(Strings.Mid(f2, 4, 2))
                If i >= 10 Then
                    p = i
                Else
                    p = "0" & i
                End If
                If CInt(Strings.Mid(f1, 4, 2)) = CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = "SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj=''"
                ElseIf p <> CInt(Strings.Mid(f2, 4, 2)) Then
                    sql = sql & "SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj='' UNION "
                Else
                    sql = sql & " SELECT doc, fecha,doc_afec, descrip, concat(dia,'/',periodo) as f2, abonado FROM ot_cpp" & p & "  where doc_afec IN  " & docu & " and doc_aj=''"
                End If
            Next
        End If
        sql = sql & " ORDER BY  doc, fecha"

        Dim abo As Double = 0

        Dim t_doc As New DataTable
        t_doc.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t_doc)
        Refresh()
        gpagos.Rows.Clear()
        gpagos.RowCount = t_doc.Rows.Count + 1

        For l = 0 To t_doc.Rows.Count - 1
            gpagos.Item(0, l).Value = t_doc.Rows(l).Item("doc")
            gpagos.Item(1, l).Value = t_doc.Rows(l).Item("fecha")
            gpagos.Item(2, l).Value = t_doc.Rows(l).Item("doc_afec")
            gpagos.Item(3, l).Value = t_doc.Rows(l).Item("descrip")
            gpagos.Item(4, l).Value = t_doc.Rows(l).Item("f2")
            gpagos.Item(5, l).Value = t_doc.Rows(l).Item("abonado")
            abo = abo + gpagos.Item(5, l).Value
        Next
        txt_ab.Text = Moneda(abo)
    End Sub
    Private Sub seleccionardoc(ByVal mifila As Integer)

        Frmdetafac.gdetaF.Rows.Clear()

        Dim tbd As New DataTable
        tbd.Clear()
        Dim per As String = ""
        per = Strings.Mid(gventasF.Item(0, mifila).Value.ToString, 4, 2)
        myCommand.CommandText = "SELECT item, cod_art, nom_art, cantidad, valor from detacomp" & per & " where doc= '" & gventasF.Item(1, mifila).Value & "' ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbd)
        Refresh()

        Frmdetafac.lbtitulo.Text = "DETALLES DOCUMENTO " & gventasF.Item(1, mifila).Value

        Frmdetafac.gdetaF.RowCount = tbd.Rows.Count + 1
        For j = 0 To tbd.Rows.Count - 1
            Frmdetafac.gdetaF.Item(0, j).Value = tbd.Rows(j).Item("item")
            Frmdetafac.gdetaF.Item(1, j).Value = tbd.Rows(j).Item("cod_art")
            Frmdetafac.gdetaF.Item(2, j).Value = tbd.Rows(j).Item("nom_art")
            Frmdetafac.gdetaF.Item(3, j).Value = tbd.Rows(j).Item("cantidad")
            Frmdetafac.gdetaF.Item(4, j).Value = tbd.Rows(j).Item("valor")
        Next
        Frmdetafac.ShowDialog()
    End Sub

    Private Sub gventasF_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gventasF.CellDoubleClick
        seleccionardoc(fila)
    End Sub

    Private Sub gventasF_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gventasF.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gventasF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gventasF.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gventasF.Focus = True Then
            seleccionardoc(fila - 1)
        End If
    End Sub

    Private Sub txtmes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmes.SelectedIndexChanged
        Dim c As Integer = 0
        If gventasF.RowCount <> 0 Then
            If txtmes.Text = "Todos" Then
                productos(docu)
            Else
                Dim sql As String = ""
                Dim f1 As String = ""
                Dim f2 As String = ""

                f1 = CDate(txtfecha1.Text)
                f2 = CDate(txtfecha2.Text)

                sql = "SELECT doc, item, cod_art, nom_art, cantidad, vtotal, '" & txtmes.Text & "' as mes FROM detacomp" & txtmes.Text & " where doc IN  " & docu & " "
                sql = sql & "ORDER BY mes, doc, item"

                Dim t_doc As New DataTable
                t_doc.Clear()
                myCommand.CommandText = sql
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t_doc)
                Refresh()

                Dim cant As Double = 0
                Dim valor As Double = 0
                If t_doc.Rows.Count = 0 Then
                    gproductos.Rows.Clear()
                Else
                    gproductos.Rows.Clear()
                    gproductos.RowCount = t_doc.Rows.Count + 1
                    For j = 0 To t_doc.Rows.Count - 1
                        gproductos.Item(0, j).Value = t_doc.Rows(j).Item("item")
                        gproductos.Item(1, j).Value = t_doc.Rows(j).Item("cod_art")
                        gproductos.Item(2, j).Value = t_doc.Rows(j).Item("nom_art")
                        If doc_aj = Strings.Left(t_doc.Rows(j).Item("doc"), 2) Then
                            gproductos.Item(3, j).Value = Moneda("-" & t_doc.Rows(j).Item("cantidad"))
                            cant = cant + gproductos.Item(3, j).Value
                            gproductos.Item(4, j).Value = Moneda("-" & t_doc.Rows(j).Item("vtotal"))
                            valor = valor + gproductos.Item(4, j).Value
                        Else
                            gproductos.Item(3, j).Value = t_doc.Rows(j).Item("cantidad")
                            cant = cant + t_doc.Rows(j).Item("cantidad")
                            gproductos.Item(4, j).Value = t_doc.Rows(j).Item("vtotal")
                            valor = valor + t_doc.Rows(j).Item("vtotal")
                        End If
                        gproductos.Item(5, j).Value = t_doc.Rows(j).Item("mes")
                    Next
                End If
                lb_n_pro.Text = cant & " PRODUCTOS"
                txtcant.Text = cant
                txtvalor.Text = Moneda(valor)
            End If
        End If
    End Sub
End Class