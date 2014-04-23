Public Class FrmSelDueño
    Public fila As Integer
    Private Sub FrmSelDueño_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gitems.Rows.Clear()
            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            If txtclase.Text <> "cliente_inm" Then
                myCommand.CommandText = "SELECT i.nit,TRIM(CONCAT(t.apellidos,' ',t.nombre))AS ter, i.clase as tipo FROM tercerosinm i left join terceros t ON i.nit=t.nit  where i.clase= '" & txtclase.Text & "' ORDER BY ter;"
            Else
                myCommand.CommandText = "SELECT i.nit,TRIM(CONCAT(t.apellidos,' ',t.nombre))AS ter, i.clase as tipo FROM tercerosinm i left join terceros t ON i.nit=t.nit ORDER BY ter;"

            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay terceros clasificados como " & txtclase.Text & ", Verifique.  ", MsgBoxStyle.Information, "Informacion ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item(1, i).Value = tabla.Rows(i).Item("ter")
                gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
                gitems.Item(3, i).Value = tabla.Rows(i).Item("tipo")
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
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "infFacInm2"
                FrmInfSerInm.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfSerInm.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "InfAnov"
                FrmInfNovedades.txtnita.Text = gitems.Item(2, mifila).Value()
                FrmInfNovedades.txtnoma.Text = gitems.Item(1, mifila).Value()
            Case "InfPnov"
                FrmInfNovedades.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfNovedades.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "nv_inm"
                FrmNovedadInm.txtnita.Text = gitems.Item(2, mifila).Value()
                FrmNovedadInm.txtnoma.Text = gitems.Item(1, mifila).Value()
            Case "Inmueble"
                If gitems.Item(3, mifila).Value() <> "PROPIETARIO" Then
                    MsgBox("Este tercero no es propietario de inmueble", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmInmueble.txtnitp.Text = gitems.Item(2, mifila).Value()
                FrmInmueble.txtnomp.Text = gitems.Item(1, mifila).Value()
            Case "contrato"
                If gitems.Item(3, mifila).Value() <> "PROPIETARIO" Then
                    MsgBox("Este tercero no es propietario  de inmueble", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmContratos.txtdueño.Text = gitems.Item(2, mifila).Value()
                FrmContratos.txtnomdu.Text = gitems.Item(1, mifila).Value()
            Case "contratoA"
                If gitems.Item(3, mifila).Value() <> "ARRENDATARIO" Then
                    MsgBox("Este tercero no es arrendatario", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmContratos.txtarre.Text = gitems.Item(2, mifila).Value()
                FrmContratos.txtnomarr.Text = gitems.Item(1, mifila).Value()
            Case "cliente_inm"
                FrmInfTercerosInm.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfTercerosInm.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "dueños_inf_inm"
                If gitems.Item(3, mifila).Value() <> "PROPIETARIO" Then
                    MsgBox("Este tercero no es propietario de inmuebles", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmInfInmuebles.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfInmuebles.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "inf_contrato"
                If gitems.Item(3, mifila).Value() <> "PROPIETARIO" Then
                    MsgBox("Este tercero no es propietario de inmuebles", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmInfContratos.txtdueño.Text = gitems.Item(2, mifila).Value()
                FrmInfContratos.txtnomdu.Text = gitems.Item(1, mifila).Value()
            Case "inf_contrato_a"
                If gitems.Item(3, mifila).Value() <> "ARRENDATARIO" Then
                    MsgBox("Este tercero no es Arrendatario", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmInfContratos.txtarre.Text = gitems.Item(2, mifila).Value()
                FrmInfContratos.txtnomarr.Text = gitems.Item(1, mifila).Value()
            Case "contratoC2"
                FrmContratos.txtco2.Text = gitems.Item(2, mifila).Value()
                FrmContratos.txtnomco2.Text = gitems.Item(1, mifila).Value()
            Case "contratoC"
                FrmContratos.txtco.Text = gitems.Item(2, mifila).Value()
                FrmContratos.txtnomco.Text = gitems.Item(1, mifila).Value()
            Case "estado_cuenta"
                FrmEst_Cuen_Prop.txtdueño.Text = gitems.Item(2, mifila).Value()
                FrmEst_Cuen_Prop.txtnomdu.Text = gitems.Item(1, mifila).Value()
            Case "dueños_inf_pago"
                If gitems.Item(3, mifila).Value() <> "PROPIETARIO" Then
                    MsgBox("Este tercero no es propietario de inmuebles", MsgBoxStyle.Information, "Verifique")
                    Exit Sub
                End If
                FrmInfPagoServ.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfPagoServ.txtnom.Text = gitems.Item(1, mifila).Value()
            Case "SaldosInm"
                FrmSaldosIniInm.txtnita.Text = gitems.Item(2, mifila).Value()
                FrmSaldosIniInm.txtnoma.Text = gitems.Item(1, mifila).Value()
            Case "infFacInm"
                FrmInfFacInm.txttip.Text = gitems.Item(2, mifila).Value()
                FrmInfFacInm.txtnom.Text = gitems.Item(1, mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
        txtclase.Text = ""
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "NOMBRES" Then
                cl = 1
            ElseIf cmbbuscar.Text = "NIT/CEDULA" Then
                cl = 2
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
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "NOMBRES"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "NOMBRES"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class