Public Class FrmTipoDocumentos
    Public fil As Integer

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        Seleccionar(e.RowIndex)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Seleccionar(fil - 1)
        End If
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        Seleccionar(fil)
    End Sub
    Public Sub Seleccionar(ByVal fila As Integer)
        Try
            If gitems.Item(2, fila).Value = "" Then Exit Sub
            FrmDocumentos.txttipo.Text = gitems.Item(2, fila).Value
            FrmDocumentos.txtdoc.Text = gitems.Item(1, fila).Value
            FrmDocumentos.lbestado.Text = "CONSULTA"
            FrmDocumentos.lbnroobs.Text = fila + 1
            BuscarGrupo(gitems.Item(3, fila).Value)
            BuscarIniAct(gitems.Item(3, fila).Value, gitems.Item(2, fila).Value)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarGrupo(ByVal gr As String)
        Dim cad, cad2 As String
        For i = 0 To FrmDocumentos.txtgrupodoc.Items.Count - 1
            cad = FrmDocumentos.txtgrupodoc.Items.Item(i).ToString
            'MsgBox(cad)
            cad2 = cad(0) & cad(1)
            If gr = cad2 Then
                FrmDocumentos.txtgrupodoc.Text = cad
            End If
        Next
    End Sub
    Public Sub BuscarIniAct(ByVal grupo As String, ByVal tipo As String)
        If grupo = "FC" Then
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT iniciofc,actualfc FROM tipdoc where tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            InicioActual(tabla.Rows(0).Item(0), tabla.Rows(0).Item(1))
            FrmDocumentos.lbini.Text = "--------"
            FrmDocumentos.lbact.Text = "--------"
        Else
            Dim tabla2 As New DataTable
            BuscarPeriodo()
            FrmDocumentos.lbini.Text = PerActual
            FrmDocumentos.lbact.Text = PerActual
            Dim cadena, cadI, cadA As String
            cadena = PerActual
            cadA = "actual"
            cadI = "inicio"
            For x = 0 To cadena.Length - 1
                If cadena.Chars(x) = "/" Then
                    Exit For
                Else
                    cadA = cadA & cadena.Chars(x)
                    cadI = cadI & cadena.Chars(x)
                End If
            Next
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & cadI & "," & cadA & " FROM tipdoc WHERE tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            InicioActual(tabla2.Rows(0).Item(0), tabla2.Rows(0).Item(1))
        End If
    End Sub
    Public Sub InicioActual(ByVal ini As Long, ByVal act As Long)

        If ini < 10 Then
            FrmDocumentos.txtinicial.Text = "000" & ini
        ElseIf ini < 100 Then
            FrmDocumentos.txtinicial.Text = "00" & ini
        ElseIf ini < 1000 Then
            FrmDocumentos.txtinicial.Text = "0" & ini
        Else
            FrmDocumentos.txtinicial.Text = ini
        End If
        '*********************************************
        If act < 10 Then
            FrmDocumentos.txtaltual.Text = "000" & act
        ElseIf act < 100 Then
            FrmDocumentos.txtaltual.Text = "00" & act
        ElseIf act < 1000 Then
            FrmDocumentos.txtaltual.Text = "0" & act
        Else
            FrmDocumentos.txtaltual.Text = act
        End If
    End Sub

    Private Sub FrmTipoDocumentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gitems.Focus()
    End Sub
    Private Sub FrmTipoDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        gitems.Focus()
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 2
            aux = gitems.Item(2, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 2, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    cmditems_Click(AcceptButton, AcceptButton)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
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