Public Class FrmSelFacturaVenta
    Public fila As Integer
    Private Sub FrmSelFacturaVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        cmbbuscar.Text = "DOCUMENTOS"
        cmbper.Text = Strings.Left(PerActual, 2)
        gitems.Rows.Clear()
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        If lbform.Text = "fr" Then
            myCommand.CommandText = "SELECT  LEFT( f.descrip, 7 ) as anul, f.doc, f.fecha, t.nombre, t.apellidos, v.nombre AS vendedor, f.total,f.tipodoc, f.num FROM facturas" & PerActual(0) & PerActual(1) & " f, terceros t, vendedores v  WHERE  f.nitc=t.nit AND f.nitv=v.nitv AND f.ret_f='0' AND f.ret_iva='0' AND f.ret_ica='0' AND f.tipodoc<>'" & Frmfacturarapida.lbdocajuste.Text & "' ORDER BY f.doc,f.fecha;"
        Else
            myCommand.CommandText = "SELECT LEFT( f.descrip, 7 ) as anul,f.doc, f.fecha, t.nombre, t.apellidos, v.nombre AS vendedor, f.total,f.tipodoc, f.num FROM facturas" & PerActual(0) & PerActual(1) & " f, terceros t, vendedores v  WHERE  f.nitc=t.nit AND f.nitv=v.nitv  ORDER BY f.doc,f.fecha;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado facturas en este periodo, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1

            If tabla.Rows(i).Item("anul") = "ANULADO" Then
                gitems.Item(0, i).Style.ForeColor = Color.Red
                gitems.Item(1, i).Style.ForeColor = Color.Red
                gitems.Item(2, i).Style.ForeColor = Color.Red
                gitems.Item(3, i).Style.ForeColor = Color.Red
                gitems.Item(4, i).Style.ForeColor = Color.Red
                gitems.Item(5, i).Style.ForeColor = Color.Red
                gitems.Item("tipo", i).Style.ForeColor = Color.Red
                gitems.Item("numero", i).Style.ForeColor = Color.Red
            End If
            gitems.Item(0, i).Value = i + 1
            gitems.Item(1, i).Value = tabla.Rows(i).Item("doc")
            gitems.Item(2, i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
            gitems.Item(3, i).Value = tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos")
            gitems.Item(4, i).Value = tabla.Rows(i).Item("vendedor")
            gitems.Item(5, i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item("numero", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "fn_sp"
                FrmFacturasyAjustesSP.txttipo.Text = gitems.Item("tipo", mifila).Value()
                FrmFacturasyAjustesSP.txtnumfac.Text = gitems.Item("numero", mifila).Value()
                FrmFacturasyAjustesSP.lbestado.Text = "CONSULTA"
                FrmFacturasyAjustesSP.lbnumero.Text = gitems.Item(0, mifila).Value
            Case "fn"
                FrmFacturasyAjustes.txttipo.Text = gitems.Item("tipo", mifila).Value()
                FrmFacturasyAjustes.txtnumfac.Text = gitems.Item("numero", mifila).Value()
                FrmFacturasyAjustes.lbestado.Text = "CONSULTA"
                FrmFacturasyAjustes.lbnumero.Text = gitems.Item(0, mifila).Value
            Case "fr"
                Frmfacturarapida.txttipo.Text = gitems.Item("tipo", mifila).Value()
                Frmfacturarapida.txtnumfac.Text = gitems.Item("numero", mifila).Value()
                Frmfacturarapida.lbestado.Text = "CONSULTA"
                Frmfacturarapida.lbnumero.Text = gitems.Item(0, mifila).Value
            Case "fnAj"
                If Strings.Left(gitems.Item("doc", mifila).Value, 2) = FrmFacturasyAjustes.lbdocajuste.Text Then
                    MsgBox("Verifique el documento", MsgBoxStyle.Information, "SAE")
                    Exit Sub
                End If
                FrmFacturasyAjustes.txtAF.Text = gitems.Item("doc", mifila).Value
        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "DOCUMENTO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 2
            ElseIf cmbbuscar.Text = "CLIENTE" Then
                cl = 3
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
            cmbbuscar.Text = "DOCUMENTO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "DOCUMENTO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub cmbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbper.SelectedIndexChanged
        gitems.Rows.Clear()
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        If lbform.Text = "fr" Then
            myCommand.CommandText = "SELECT  LEFT( f.descrip, 7 ) as anul, f.doc, f.fecha, t.nombre, t.apellidos, v.nombre AS vendedor, f.total,f.tipodoc, f.num FROM facturas" & cmbper.Text & " f, terceros t, vendedores v  WHERE  f.nitc=t.nit AND f.nitv=v.nitv AND f.ret_f='0' AND f.ret_iva='0' AND f.ret_ica='0' AND f.tipodoc<>'" & Frmfacturarapida.lbdocajuste.Text & "' ORDER BY f.doc,f.fecha;"
        Else
            myCommand.CommandText = "SELECT LEFT( f.descrip, 7 ) as anul,f.doc, f.fecha, t.nombre, t.apellidos, v.nombre AS vendedor, f.total,f.tipodoc, f.num FROM facturas" & cmbper.Text & " f, terceros t, vendedores v  WHERE  f.nitc=t.nit AND f.nitv=v.nitv  ORDER BY f.doc,f.fecha;"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado facturas en este periodo, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1

            If tabla.Rows(i).Item("anul") = "ANULADO" Then
                gitems.Item(0, i).Style.ForeColor = Color.Red
                gitems.Item(1, i).Style.ForeColor = Color.Red
                gitems.Item(2, i).Style.ForeColor = Color.Red
                gitems.Item(3, i).Style.ForeColor = Color.Red
                gitems.Item(4, i).Style.ForeColor = Color.Red
                gitems.Item(5, i).Style.ForeColor = Color.Red
                gitems.Item("tipo", i).Style.ForeColor = Color.Red
                gitems.Item("numero", i).Style.ForeColor = Color.Red
            End If
            gitems.Item(0, i).Value = i + 1
            gitems.Item(1, i).Value = tabla.Rows(i).Item("doc")
            gitems.Item(2, i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
            gitems.Item(3, i).Value = tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos")
            gitems.Item(4, i).Value = tabla.Rows(i).Item("vendedor")
            gitems.Item(5, i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item("numero", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
        Next
    End Sub
End Class