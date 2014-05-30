Public Class FrmSelDocProveedor
    Public fila As Integer
    Dim tabla As New DataTable
    Private Sub FrmSelDocProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        If lbform.Text = "anularDoc" Then
            myCommand.CommandText = "SELECT f.*,TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit FROM fact_comp" & FrmAnularCompras.cbper.Text & " f LEFT JOIN (terceros t) ON f.nitc=t.nit WHERE f.tipodoc='" & FrmAnularCompras.txttipo.Text & "'  AND f.anulado<>'si' ORDER BY f.doc,f.fecha;"
        Else
            myCommand.CommandText = "SELECT f.*,TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit FROM fact_comp" & PerActual(0) & PerActual(1) & " f LEFT JOIN (terceros t) ON f.nitc=t.nit ORDER BY f.doc,f.fecha;"
        End If

        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado facturas para la busquedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            'Me.Close()
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            If tabla.Rows(i).Item("anulado") = "si" Then
                gitems.Item(0, i).Style.ForeColor = Color.Red
                gitems.Item(1, i).Style.ForeColor = Color.Red
                gitems.Item(2, i).Style.ForeColor = Color.Red
                gitems.Item(3, i).Style.ForeColor = Color.Red
                gitems.Item(4, i).Style.ForeColor = Color.Red
                gitems.Item(5, i).Style.ForeColor = Color.Red
                gitems.Item(6, i).Style.ForeColor = Color.Red
                gitems.Item(7, i).Style.ForeColor = Color.Red
            End If
            gitems.Item(0, i).Value = i + 1
            gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc_afec")
            gitems.Item("docu", i).Value = tabla.Rows(i).Item("doc")
            gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item("total", i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item("numero", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
            gitems.Item("estado", i).Value = tabla.Rows(i).Item("estado")
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
        Try
            If gitems.Item(1, mifila).Value() = "" Then Exit Sub
            If lbform.Text = "fpAj" Then
                If Strings.Left(gitems.Item(1, mifila).Value(), 2) = FrmDocProveedor.lbdocajuste.Text Then
                    MsgBox("Verifique el tipo de documento", MsgBoxStyle.Information, "SAE")
                    Exit Sub
                End If
                If gitems.Item("estado", mifila).Value() <> "AP" Then
                    MsgBox("No puede realizar un ajuste de una factura que no esta aprobada", MsgBoxStyle.Information, "Verificacion")
                    Exit Sub
                End If
                FrmDocProveedor.txtAF.Text = gitems.Item("docu", mifila).Value()
                Me.Close()
            ElseIf lbform.Text = "anularDoc" Then
                FrmAnularCompras.txtnumfac.Text = gitems.Item("numero", mifila).Value()
                Me.Close()
            Else
                FrmDocProveedor.lbestado.Text = "CONSULTA"
                FrmDocProveedor.txtnumfac.Text = gitems.Item("docu", mifila).Value()
                FrmDocProveedor.lbnumero.Text = mifila + 1
                gitems.Focus()
                Me.Close()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "DOC INTERNO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "DOC EXTERNO" Then
                cl = 2
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 3
            ElseIf cmbbuscar.Text = "PROVEEDOR" Then
                cl = 4
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
            cmbbuscar.Text = "DOC INTERNO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub cmbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbper.SelectedIndexChanged
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        myCommand.CommandText = "SELECT f.*,TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit FROM fact_comp" & cmbper.Text & " f LEFT JOIN (terceros t) ON f.nitc=t.nit ORDER BY f.doc,f.fecha;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado facturas para la busquedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            'Me.Close()
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc_afec")
            gitems.Item("docu", i).Value = tabla.Rows(i).Item("doc")
            gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item("total", i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item("numero", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
            gitems.Item("estado", i).Value = tabla.Rows(i).Item("estado")
        Next
    End Sub
End Class