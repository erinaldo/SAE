Public Class FrmArti_de_Inventarios
    Public fila As Integer
    Private Sub FrmArti_de_Inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        '............
        Dim tb As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows.Count > 0 Then
            Dim bod As String = "0"
            For i = 0 To tb.Rows.Count - 1
                bod = bod & " + cant" & tb.Rows(i).Item(0) & " "
            Next

            '.....
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT a.* , ( SELECT SUM(" & bod & ") FROM con_inv WHERE a.codart= codart AND periodo='" & Strings.Left(PerActual, 2) & "') AS ncant FROM articulos a ORDER BY codart;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han agredado ningun articulo, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Me.Close()
                Exit Sub
            End If
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(0, i).Value = tabla.Rows(i).Item("codart")
                gitems.Item(1, i).Value = tabla.Rows(i).Item("nomart")
                gitems.Item(2, i).Value = tabla.Rows(i).Item("desart")
                gitems.Item(3, i).Value = tabla.Rows(i).Item("nivel")
                gitems.Item(4, i).Value = tabla.Rows(i).Item("ncant")
            Next
            BuscarGrilla(txtcuenta.Text)
        Else
            MsgBox("No han agredado ninguna Bodega, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
        End If



        
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
            Case "Infarticulos"
                FrmInfoArticulos.txttip.Text = gitems.Item(0, mifila).Value()
                FrmInfoArticulos.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "articulos"
                FrmProductos.lbestado.Text = "CONSULTA"
                FrmProductos.lbnroobs.Text = mifila + 1
                FrmProductos.txtcodigo.Text = gitems.Item(0, mifila).Value()
            Case "tar_conteo_ini"
                FrmTarConteoFisico.txtini.Text = gitems.Item(0, mifila).Value()
            Case "tar_conteo_fin"
                FrmTarConteoFisico.txtfin.Text = gitems.Item(0, mifila).Value()
            Case "lista_precio"
                FrmAumentarPrecios.txtcod.Text = gitems.Item(0, mifila).Value()
                FrmAumentarPrecios.txtnom.Text = gitems.Item(1, mifila).Value()
                FrmAumentarPrecios.lbnivel.Text = gitems.Item(3, mifila).Value()
            Case "lista_rango1"
                FrmAumentarPrecios.txtcod1.Text = gitems.Item(0, mifila).Value()
                FrmAumentarPrecios.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "lista_rango2"
                FrmAumentarPrecios.txtcod2.Text = gitems.Item(0, mifila).Value()
                FrmAumentarPrecios.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "InfoKardex"
                FrmInfoKardex.txtci.Text = gitems.Item(0, mifila).Value()
            Case "InfPunto1"
                FrmInfPunto.txtci.Text = gitems.Item(0, mifila).Value()
            Case "InfPunto2"
                FrmInfPunto.txtcf.Text = gitems.Item(0, mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        'Try
        '    If cad = "" Then Exit Sub
        '    cad = UCase(cad)
        '    Dim cad2, aux As String
        '    For i = 0 To gitems.RowCount - 1
        '        aux = gitems.Item(0, i).Value.ToString
        '        If Val(aux.Length) >= Val(cad.Length) Then
        '            cad2 = ""
        '            For j = 0 To cad.Length - 1
        '                cad2 = cad2 & aux(j)
        '            Next
        '            If cad = cad2 Then
        '                Dim C As Integer = 0, F As Integer = i
        '                gitems.CurrentCell = gitems(C, F)
        '                gitems.Focus()
        '                Exit Sub
        '            End If
        '        End If
        '    Next
        'Catch ex As Exception
        'End Try
        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "CODIGO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "DESCRIPCION" Then
                cl = 1
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
            cmbbuscar.Text = "CODIGO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class