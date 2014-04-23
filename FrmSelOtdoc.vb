Public Class FrmSelOtdoc
    Public fila As Integer
    Private Sub FrmSelOtdoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbbuscar.Text = "DOCUMENTO"

        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        myCommand.CommandText = "SELECT DISTINCT o.doc, CONCAT(o.dia,'/',o.periodo) AS fecha, o.concepto, o.nitc, TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit, o.total " _
        & " FROM " & lbtabla.Text & " o, terceros t  WHERE  o.tipo IN (" & tdoc.Text & ") AND o.nitc=t.nit ORDER BY o.fecha,o.doc ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado Documentos para la busqueda, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item(1, i).Value = tabla.Rows(i).Item("doc")
            gitems.Item(2, i).Value = CambiaCadena(tabla.Rows(i).Item("fecha"), 10)
            gitems.Item(3, i).Value = tabla.Rows(i).Item("nitc")
            gitems.Item(4, i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item(5, i).Value = tabla.Rows(i).Item("concepto")
            gitems.Item(6, i).Value = tabla.Rows(i).Item("total")
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
            Case "ComEgre"
                FrmComEgresoCpp.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
            Case "ComIngre"
                FrmCompIngresos.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
            Case "RecCaja"
                FrmRecibodeCaja.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
            Case "NotaDb"
                FrmNotaDebito.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
            Case "NotaCr"
                FrmNotaCredito.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
            Case "ReciCartera"
                FrmReciboCartera.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
                FrmReciboCartera.txttipo.Text = Strings.Left(gitems.Item(1, mifila).Value(), 2)
            Case "ComEgreCpp"
                FrmCompEgreCpp.txtnumero.Text = Strings.Right(gitems.Item(1, mifila).Value(), Strings.Len(gitems.Item(1, mifila).Value()) - 2)
                FrmCompEgreCpp.txttipo.Text = Strings.Left(gitems.Item(1, mifila).Value(), 2)
        End Select
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)

        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "DOCUMENTO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "FECHA(dd/mm/aaaa)" Then
                cl = 2
            ElseIf cmbbuscar.Text = "NOMBRE CLIENTE" Then
                cl = 4
            ElseIf cmbbuscar.Text = "NIT CLIENTE" Then
                cl = 3
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
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class