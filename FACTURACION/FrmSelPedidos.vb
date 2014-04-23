Public Class FrmSelPedidos
    Public fila As Integer
    Private Sub FrmSelPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        If lbltabla.Text = "Acta" Then
            cargarDatos("fact_acta_entrega")
        Else
            cargarDatos("fapipen")
        End If
        cmbBusc.Text = "DOCUMENTO"
    End Sub
    Sub cargarDatos(ByVal SelTabla As String)
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        myCommand.CommandText = "SELECT DISTINCT(numero),f.descrip,f.fecha,TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit, FORMAT(SUM(vtotal),2) AS total FROM " & SelTabla & " f LEFT JOIN (terceros t) ON f.nitc=t.nit  group by f.numero ORDER BY f.numero;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado facturas para la busquedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item("docu", i).Value = tabla.Rows(i).Item("numero")
            gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha").ToString, 10)
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item("con", i).Value = tabla.Rows(i).Item("descrip")
            gitems.Item("total", i).Value = tabla.Rows(i).Item("total")
            gitems.Item("tipo", i).Value = ""
            gitems.Item("numero", i).Value = tabla.Rows(i).Item("numero")
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
            FrmEntraPedidos.lbestado.Text = "CONSULTA"
            FrmEntraPedidos.txtnumped.Text = gitems.Item("docu", mifila).Value()
            FrmEntraPedidos.lbnumero.Text = mifila + 1
            gitems.Focus()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)


        Dim cl As Integer = 0
        Try

            If cmbBusc.Text = "DOCUMENTO" Then
                cl = 1
                txtcuenta.Text = NumeroDoc(cad)
                cad = NumeroDoc(cad)
            ElseIf cmbBusc.Text = "FECHA" Then
                cl = 2
            Else
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
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class