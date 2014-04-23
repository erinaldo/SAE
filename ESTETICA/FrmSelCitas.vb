Public Class FrmSelCitas
    Public fila As Integer
    Private Sub FrmSelCitas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbbuscar.Text = "Nº NOVEDAD"
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT c.num,CAST(CONCAT(c.nitc,' ',t.nombre,' ', t.apellidos) AS CHAR(60)) AS cliente  , " _
            & " CAST(CONCAT(c.nita,' ',v.nombre) AS CHAR(60)) AS asesor , c.servicio, CAST(CONCAT(RIGHT(c.fecha,2),'/',MID(c.fecha,6,2),'/',LEFT(c.fecha,4)) AS CHAR(15)) AS fc, " _
            & " c.hora, c.estado FROM citas c, terceros t, vendedores v WHERE t.nit = c.nitc AND v.nitv=c.nita"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No creado ninguna Cita, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
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
                gitems.Item("num", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
                gitems.Item("cliente", i).Value = tabla.Rows(i).Item("cliente")
                gitems.Item("asesor", i).Value = tabla.Rows(i).Item("asesor")
                gitems.Item("serv", i).Value = tabla.Rows(i).Item("servicio")
                gitems.Item("fecha", i).Value = tabla.Rows(i).Item("fc")
                gitems.Item("hora", i).Value = tabla.Rows(i).Item("hora")
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

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
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
            Case "cita"
                FrmGestionCitas.lbestado.Text = "CONSULTA"
                FrmGestionCitas.lbnov1.Visible = True
                FrmGestionCitas.Lbnov.Text = gitems.Item("num", mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0

        Try

            If cmbbuscar.Text = "Nº CITA" Then
                cl = 0
                cad = NumeroDoc(cad)
            ElseIf cmbbuscar.Text = "CLIENTE" Then
                cl = 1
            ElseIf cmbbuscar.Text = "ASESOR" Then
                cl = 2
            ElseIf cmbbuscar.Text = "FECHA" Then
                cl = 3
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
                MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar citas")
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
            If cmbbuscar.Text = "Nº CITA" Then
                txtcuenta.Text = NumeroDoc(txtcuenta.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class