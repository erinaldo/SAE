Public Class FrmSelInmueble
    Public fila As Integer
    Private Sub FrmSelInmueble_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbbuscar.Text = "CODIGO"
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT  i.`codigo`, i.tipoim, TRIM(CONCAT(i.`direccion`,' ',i.`barrio`)) as dir, s.`descripcion`, i.estado,  TRIM(CONCAT(i.`nitp`,' ',t.nombre,' ',t.apellidos)) AS nom " _
            & " FROM inmuebles i, terceros t, sae.mun s WHERE t.nit=i.nitp  AND s.`coddep`= i.`dpto` AND s.`codmun`= i.`ciudad` "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han seleccionado ningun inmueble, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("codigo", i).Value = tabla.Rows(i).Item("codigo")
                gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipoim")
                gitems.Item("dir", i).Value = tabla.Rows(i).Item("dir")
                gitems.Item("ciudad", i).Value = tabla.Rows(i).Item("descripcion")
                gitems.Item("nombre", i).Value = tabla.Rows(i).Item("nom")
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
        If gitems.Item("estado", mifila).Value() = "INACTIVO" And lbform.Text <> "Inmueble" Then
            MsgBox("El inmueble codigo " & gitems.Item("codigo", mifila).Value() & " esta INACTIVO, no permite esta acción ")
            Exit Sub
        End If

        Select Case lbform.Text
            Case "inf_nov"
                FrmInfNovedades.txtinm.Text = gitems.Item("codigo", mifila).Value()
            Case "Inmueble"
                FrmInmueble.txtcod.Text = gitems.Item("codigo", mifila).Value()
                'FrmInmueble.txtnitp.Text = gitems.Item("nit", mifila).Value()
                'FrmInmueble.txtnomp.Text = gitems.Item("nombre", mifila).Value()
                'FrmInmueble.cbestado.Text = gitems.Item("estado", mifila).Value()
            Case "contrato"
                If gitems.Item("estado", mifila).Value() = "OCUPADO" Then
                    MsgBox("Este inmueble ya no esta Disponible", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmContratos.txtinm.Text = gitems.Item("codigo", mifila).Value()
                FrmContratos.txtinm_LostFocus(AcceptButton, AcceptButton)
            Case "inf_inm"
                FrmInfInmuebles.txtinm.Text = gitems.Item("codigo", mifila).Value()
            Case "InmPagServ"
                FrmPagosServicios.txtinm.Text = gitems.Item("codigo", mifila).Value()
            Case "SelPagServ"
                FrmSelPagos.txtcuenta.Text = gitems.Item("codigo", mifila).Value()
            Case "InmNov"
                FrmNovedadInm.txtinm.Text = gitems.Item("codigo", mifila).Value()
            Case "InmGaleria"
                FrmGaleriaInm.txtcodinm.Text = gitems.Item("codigo", mifila).Value()
            Case "inf_PSe"
                FrmInfPagoServ.txtinm.Text = gitems.Item("codigo", mifila).Value()
            Case "SaldoInm"
                FrmSaldosIniInm.txtinm.Text = gitems.Item("codigo", mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        
        Dim cl As Integer = 0

        Try

            If cmbbuscar.Text = "CODIGO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "TIPO" Then
                cl = 2
            ElseIf cmbbuscar.Text = "DIRECCION" Then
                cl = 3
            ElseIf cmbbuscar.Text = "CIUDAD" Then
                cl = 4
            ElseIf cmbbuscar.Text = "PROPIETARIO" Then
                cl = 5
            ElseIf cmbbuscar.Text = "ESTADO" Then
                cl = 6
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