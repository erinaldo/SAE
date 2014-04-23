Public Class FrmSelPagos
    Public fila As Integer
    Public tabla As New DataTable

    Private Sub mostrarPagos()
        Dim cad As String = ""
        Try
            If txtcuenta.Text <> "" Then
                cad = "WHERE codigo_inm = '" & txtcuenta.Text & "'"
            End If
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT *, CAST(CONCAT(RIGHT(fecha,2),'/',MID(fecha,6,2),'/',LEFT(fecha,4)) AS CHAR(15)) AS fc   FROM inm_servpagos " & cad
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han registrado pagos a los servicios de este inmuebles, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                txtcuenta.Text = ""
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("inm", i).Value = tabla.Rows(i).Item("codigo_inm")
                gitems.Item("mes", i).Value = tabla.Rows(i).Item("mes")
                gitems.Item("serv", i).Value = tabla.Rows(i).Item("servicio")
                gitems.Item("fecha", i).Value = tabla.Rows(i).Item("fc")
                gitems.Item("valor", i).Value = Moneda(tabla.Rows(i).Item("valor"))
                gitems.Item("forma", i).Value = tabla.Rows(i).Item("forma")
                gitems.Item("per", i).Value = tabla.Rows(i).Item("perdoc")
                gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc")
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FrmSelPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ok.Focus()
        mostrarPagos()
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If txtcuenta.Text <> "" Then
            mostrarPagos()
        End If
    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM inmuebles i WHERE i.codigo ='" & txtcuenta.Text & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtcuenta.Text = ""
            Try
                FrmSelInmueble.lbform.Text = "SelPagServ"
                FrmSelInmueble.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtcuenta.Text = tabla.Rows(0).Item("codigo")
        End If
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
            Case "InmPagosSer"
                FrmPagosServicios.txtinm.Text = txtcuenta.Text
                FrmPagosServicios.cmbmes.Text = Strings.Left(gitems.Item("mes", fila).Value(), Len(gitems.Item("mes", fila).Value()) - 5)
                FrmPagosServicios.txtf1.Text = tabla.Rows(fila).Item("fecha")
                FrmPagosServicios.txtvalor.Text = gitems.Item("valor", fila).Value()
                FrmPagosServicios.txtmedpago.Text = gitems.Item("forma", fila).Value()
                FrmPagosServicios.lbmesA.Text = gitems.Item("mes", fila).Value()
                FrmPagosServicios.buscarServicio(txtcuenta.Text)
                FrmPagosServicios.cmbservicio.Text = gitems.Item("serv", fila).Value()
                FrmPagosServicios.BusArre()
                FrmPagosServicios.lbdoc.Text = gitems.Item("doc", fila).Value()
                FrmPagosServicios.lbper.Text = gitems.Item("per", fila).Value()
                If tabla.Rows(fila).Item("deposito") <> 0 Then
                    FrmPagosServicios.chdp.Checked = True
                    'FrmPagosServicios.txtdep.Text = Moneda(tabla.Rows(fila).Item("deposito"))
                End If


        End Select
        gitems.Focus()
        Me.Close()
    End Sub
End Class