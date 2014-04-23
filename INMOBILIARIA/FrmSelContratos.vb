Public Class FrmSelContratos
    Public fila As Integer
    Dim tabla As New DataTable

    Private Sub FrmSelContratos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            gitems.Rows.Clear()

            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT concat(t.nombre,' ',t.apellidos) as nom, c.* FROM contrato_inm c, terceros t where nit_d = t.nit ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han creado ningun contrato  ", MsgBoxStyle.Information, "Verificando ")
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1

                If tabla.Rows(i).Item("mes_total") = tabla.Rows(i).Item("mes_fact") Then
                    gitems.Item(1, i).Style.ForeColor = Color.Red
                    gitems.Item(1, i).Value = tabla.Rows(i).Item("cod_contra")
                    gitems.Item(2, i).Style.ForeColor = Color.Red
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("nom")
                    gitems.Item(3, i).Style.ForeColor = Color.Red
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("cod_inm")
                    gitems.Item(4, i).Style.ForeColor = Color.Red
                    gitems.Item(4, i).Value = tabla.Rows(i).Item("nomb_arr")
                    gitems.Item(5, i).Style.ForeColor = Color.Red
                    gitems.Item(5, i).Value = tabla.Rows(i).Item("valor")
                Else
                    gitems.Item(1, i).Value = tabla.Rows(i).Item("cod_contra")
                    gitems.Item(2, i).Value = tabla.Rows(i).Item("nom")
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("cod_inm")
                    gitems.Item(4, i).Value = tabla.Rows(i).Item("nomb_arr")
                    gitems.Item(5, i).Value = tabla.Rows(i).Item("valor")
                End If
               
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
            Case "contrato"
                FrmContratos.txtcontrato.Text = gitems.Item("contrato", mifila).Value()
            Case "inf_contrato"
                FrmInfContratos.txtcontrato.Text = gitems.Item("contrato", mifila).Value()
            Case "comEgre"
                FrmComEgresoCpp.txtcodCon.Text = gitems.Item("contrato", mifila).Value()
            Case "SaldoInm"
                FrmSaldosIniInm.txtcodcont.Text = gitems.Item("contrato", mifila).Value()
                FrmSaldosIniInm.txtnita.Text = tabla.Rows(fila).Item("nit_a")
                FrmSaldosIniInm.txtnoma.Text = tabla.Rows(fila).Item("nomb_arr")
                FrmSaldosIniInm.txtinm.Text = gitems.Item(3, mifila).Value
            Case "Extr"
                FrmEst_Cuen_Inm.txtcontr.Text = gitems.Item("contrato", mifila).Value()
            Case "inf_conc"
                FrmInfOtconcp.txtcon.Text = gitems.Item("contrato", mifila).Value()
        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
       
        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "COD CONTRATO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "PROPIETARIO" Then
                cl = 2
            ElseIf cmbbuscar.Text = "COD INMUEBLE" Then
                cl = 3
            ElseIf cmbbuscar.Text = "ARRENDATARIO" Then
                cl = 4
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
            cmbbuscar.Text = "COD CONTRATO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "COD CONTRATO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class