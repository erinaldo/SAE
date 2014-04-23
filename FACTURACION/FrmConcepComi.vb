Public Class FrmConcepComi
    Dim f As Integer
    Private Sub FrmConcepComi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      

        Try
           
            gitems.Rows.Clear()
            Dim tabla2 As New DataTable
            myCommand.CommandText = " SELECT * from concomi"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            For i = 0 To tabla2.Rows.Count - 1
                gitems.Rows.Add(tabla2.Rows(i).Item("codcon"), tabla2.Rows(i).Item("concepto"), tabla2.Rows(i).Item("porcomi"))
            Next

        Catch ex As Exception

        End Try
    End Sub


    Public Sub seleccionar(ByVal fo As Integer)

        Dim fila As Integer = lbfila.Text

        Select Case Lbform.Text
            Case "vendedores"
                FrmVendedores.gitems.Item("buscar", fila).Value = gitems.Item("codigo", f).Value
                FrmVendedores.gitems.Item("nombre", fila).Value = gitems.Item("concepto", f).Value
                FrmVendedores.gitems.Item("nit", fila).Value = gitems.Item("porcentaje", f).Value
                FrmVendedores.gitems.Item("recaudo", fila).Value = 0
                FrmVendedores.lbadd.Text = "si"
            Case "conmicar"
                FrmConcomiCart.gitems.Item("buscar", fila).Value = gitems.Item("codigo", f).Value
                FrmConcomiCart.gitems.Item("nombre", fila).Value = gitems.Item("concepto", f).Value
                FrmConcomiCart.gitems.Item("por", fila).Value = gitems.Item("porcentaje", f).Value
                FrmConcomiCart.gitems.Item("R1", fila).Value = 0
                FrmConcomiCart.gitems.Item("R2", fila).Value = 0
            Case "itemcar"
                FrmItemCartera.gitems.Item("comision", fila).Value = gitems.Item("codigo", f).Value
        End Select
        Lbform.Text = ""
        lbfila.Text = ""

       
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Dim fl As Integer = 0
        Try
            For i = 0 To FrmVendedores.gitems.Rows.Count - 1
                If FrmVendedores.gitems.Item("buscar", i).Value = gitems.Item("codigo", f).Value Then
                    fl = fl + 1
                End If
            Next

            If fl = 0 Then
                seleccionar(f)
                Me.Close()
            Else
                MsgBox("Este concepto ya fue asignado para este vendedor")
            End If
        Catch ex As Exception

        End Try
        


    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick

        Dim fl As Integer = 0

        For i = 0 To FrmVendedores.gitems.Rows.Count - 1
            If FrmVendedores.gitems.Item("buscar", i).Value = gitems.Item("codigo", f).Value Then
                fl = fl + 1
            End If
        Next

        If fl = 0 Then
            seleccionar(e.RowIndex)
            Me.Close()
        Else
            MsgBox("Este concepto ya existe")
        End If

    End Sub


    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        f = e.RowIndex        'captura fila
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        cad = UCase(cad)
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 1
            aux = gitems.Item(0, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 0, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub
End Class