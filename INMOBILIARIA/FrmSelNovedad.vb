Public Class FrmSelNovedad
    Public fila As Integer


    Private Sub FrmSelNovedad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbbuscar.Text = "Nº NOVEDAD"
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT n.ndoc,n.codigoinm,n.nita, n.estado, n.fecha, " _
            & " CAST(CONCAT(RIGHT(n.fecha,2),'/',MID(n.fecha,6,2),'/',LEFT(n.fecha,4)) AS CHAR(15)) AS fc, " _
            & " (SELECT CONCAT(n.nitp,' - ',TRIM(concat(te.nombre,' ',te.apellidos))) FROM terceros te WHERE te.nit= n.nitp) as nomp," _
            & " TRIM(concat(t.nombre,' ',t.apellidos)) as nom FROM inm_novdad n, terceros t WHERE t.nit=n.nita ORDER BY fecha;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No creado ninguna Novedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("novedad", i).Value = tabla.Rows(i).Item("ndoc")
                gitems.Item("inmueble", i).Value = tabla.Rows(i).Item("codigoinm")
                gitems.Item("fecha", i).Value = tabla.Rows(i).Item("fc")
                gitems.Item("prop", i).Value = tabla.Rows(i).Item("nomp")
                gitems.Item("nomar", i).Value = tabla.Rows(i).Item("nita") & " - " & tabla.Rows(i).Item("nom")
                gitems.Item("estado", i).Value = tabla.Rows(i).Item("estado")
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
    Private Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "novedad"
                FrmNovedadInm.lbestado.Text = "CONSULTA"
                FrmNovedadInm.lbnov1.Visible = True
                FrmNovedadInm.Lbnov.Text = gitems.Item("novedad", mifila).Value()
                FrmNovedadInm.txtinm.Text = gitems.Item("inmueble", mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0

        Try

            If cmbbuscar.Text = "Nº NOVEDAD" Then
                cl = 0
                cad = NumeroDoc(cad)
            ElseIf cmbbuscar.Text = "COD INMUEBLE" Then
                cl = 1
            ElseIf cmbbuscar.Text = "FECHA" Then
                cl = 2
            ElseIf cmbbuscar.Text = "PROPIETARIO" Then
                cl = 3
            ElseIf cmbbuscar.Text = "ARRENDATARIO" Then
                cl = 4
            ElseIf cmbbuscar.Text = "ESTADO" Then
                cl = 5
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
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Try
            If cmbbuscar.Text = "Nº NOVEDAD" Then
                txtcuenta.Text = NumeroDoc(txtcuenta.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class