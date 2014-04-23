Public Class FrmSelPediPen

    Private Sub FrmSelPediPen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim items As Integer
        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT distinct(numero) FROM pedi_comp WHERE cumplido='no' ORDER BY numero;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        Refresh()
        items = tabla2.Rows.Count
        gitems.Rows.Clear()
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(1, i).Value = NumeroDoc(tabla2.Rows(i).Item("numero"))
            DatosPedi(tabla2.Rows(i).Item("numero"), i)
        Next
        BuscarGrilla(txtcuenta.Text)
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Public Sub DatosPedi(ByVal num As String, ByVal i As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT p.fechaped,trim(concat(t.nombre,' ',t.apellidos)) AS nomnit FROM pedi_comp p LEFT JOIN (terceros t) ON p.nitc=t.nit WHERE p.numero='" & num & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                gitems.Item(2, i).Value = CambiaCadena(tabla.Rows(0).Item("fechaped").ToString, 10)
                gitems.Item(3, i).Value = tabla.Rows(0).Item("nomnit")
                gitems.Item(4, i).Value = SumarValores(num)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function SumarValores(ByVal num As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT SUM(vtotal) AS vt FROM pedi_comp WHERE numero='" & num & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                Return Moneda(tabla.Rows(0).Item("vt"))
            Else
                Return "0,00"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return "0,00"
        End Try
    End Function

    Public Sub BuscarGrilla(ByVal cad As String)
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            Dim cad2, aux As String
            For i = 0 To gitems.RowCount - 1
                aux = gitems.Item(1, i).Value.ToString
                If Val(aux.Length) >= Val(cad.Length) Then
                    cad2 = ""
                    For j = 0 To cad.Length - 1
                        cad2 = cad2 & aux(j)
                    Next
                    If cad = cad2 Then
                        Dim C As Integer = 1, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                End If
            Next
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
    Public fila As Integer
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
            If gitems.Item(1, mifila).Value = "" Then Exit Sub
            Select Case lbform.Text
                Case "marcar_ped"
                    FrmMarcarPedidos.txtnumfac.Text = gitems.Item("codigo", mifila).Value
                    FrmMarcarPedidos.lbsel.Text = "si"
                Case "pedi_comp"
                    
            End Select
            Me.Close()
            gitems.Focus()
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class