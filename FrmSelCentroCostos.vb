Public Class FrmSelCentroCostos
    Public fila As Integer
    Private Sub FrmSelCentroCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT * FROM centrocostos ORDER BY centro;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ningun centro de costos, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 2
        For i = 0 To items - 1
            gitems.Item(0, i).Value = tabla.Rows(i).Item("nombre").ToString
            gitems.Item(1, i).Value = tabla.Rows(i).Item("centro").ToString
            gitems.Item(2, i).Value = tabla.Rows(i).Item("nivel").ToString
            gitems.Item(3, i).Value = tabla.Rows(i).Item("pres").ToString
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        'BuscarGrilla(txtcuenta.Text)
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
        Try
            If gitems.Item(2, mifila).Value() <> "centro" And lbform.Text <> "inf_cc_f" And lbform.Text <> "centro" And lbform.Text <> "inf_cc_i" And lbform.Text <> "est_res_cc" And lbform.Text <> "bal_gral_cc" Then
                MsgBox("Favor seleccione solo centro de costos.")
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        Select Case lbform.Text
            Case "RecCaG"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmRecibodeCaja.grilla.Item("cc", fil).Value = gitems.Item(1, mifila).Value().ToString
                fil = 0
            Case "comproIgG"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmCompIngresos.grilla.Item("cc", fil).Value = gitems.Item(1, mifila).Value().ToString
                fil = 0
            Case "comproEgG"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                FrmComEgresoCpp.grilla.Item("cc", fil).Value = gitems.Item(1, mifila).Value().ToString
                fil = 0
            Case "InfoMovCC"
                FrmInfMovCentroC.txtcheque.Text = gitems.Item(1, mifila).Value().ToString
            Case "cpp_si"
                FrmSaldosInicialesCPP.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmSaldosInicialesCPP.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "car_si"
                FrmSaldosInicialesCartera.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmSaldosInicialesCartera.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "car_cpp"
                FrmSaldosInicialesCPP.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmSaldosInicialesCPP.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "centro"
                FrmCentroCostos.txtcodigo.Text = gitems.Item(1, mifila).Value().ToString
                FrmCentroCostos.txtnombre.Text = gitems.Item(0, mifila).Value().ToString
                FrmCentroCostos.lbestado.Text = "CONSULTA"
                FrmCentroCostos.lbnumero.Text = (mifila + 1).ToString
            Case "cc_p"
                FrmFacturasPendientes.txtcentrocosto.Text = gitems.Item(1, mifila).Value().ToString
                FrmFacturasPendientes.txtcentrocosto_NOM.Text = gitems.Item(0, mifila).Value().ToString
            Case "conta_ent"
                FrmEntradaDatos.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmEntradaDatos.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "conta_si"
                FrmSaldosIniciales.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmSaldosIniciales.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "comproEg"
                FrmComEgresoCpp.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmComEgresoCpp.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "comproIn"
                FrmCompIngresos.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmCompIngresos.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "comproRo"
                FrmRecibodeCaja.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmRecibodeCaja.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "nc"
                FrmNotaCredito.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmNotaCredito.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "nd"
                FrmNotaDebito.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmNotaDebito.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "est_res_cc"
                FrmEstadoR_cc.txtcc.Text = gitems.Item(1, mifila).Value().ToString
                FrmEstadoR_cc.txtncc.Text = gitems.Item(0, mifila).Value().ToString
            Case "bal_gral_cc"
                FrmBalanceG_cc.txtcc.Text = gitems.Item(1, mifila).Value().ToString
                FrmBalanceG_cc.txtncc.Text = gitems.Item(0, mifila).Value().ToString
            Case "inf_cc_i"
                FrmInfoCentroC.txtcci.Text = gitems.Item(1, mifila).Value().ToString
                FrmInfoCentroC.txtncci.Text = gitems.Item(0, mifila).Value().ToString
            Case "inf_cc_f"
                FrmInfoCentroC.txtccf.Text = gitems.Item(1, mifila).Value().ToString
                FrmInfoCentroC.txtnccf.Text = gitems.Item(0, mifila).Value().ToString
            Case "cpp_egre"
                FrmCompEgreCpp.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmCompEgreCpp.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "rec_car"
                FrmReciboCartera.txtcentro.Text = gitems.Item(1, mifila).Value().ToString
                FrmReciboCartera.txtncentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "inf_cc"
                FrmInformeCC.txtcc.Text = gitems.Item(1, mifila).Value().ToString
                FrmInformeCC.txtNomcc.Text = gitems.Item(0, mifila).Value().ToString
            Case "FactRap"
                Frmfacturarapida.txtcentrocosto.Text = gitems.Item(1, mifila).Value().ToString
                Frmfacturarapida.txtcentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "FactAjus"
                FrmFacturasyAjustes.txtcentrocosto.Text = gitems.Item(1, mifila).Value().ToString
                FrmFacturasyAjustes.txtcentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "FactProv"
                FrmDocProveedor.txtcentrocosto.Text = gitems.Item(1, mifila).Value().ToString
                FrmDocProveedor.txtcentro.Text = gitems.Item(0, mifila).Value().ToString
            Case "ContInm"
                FrmContratos.txtcentrocosto.Text = gitems.Item(1, mifila).Value().ToString
                FrmContratos.txtcentro.Text = gitems.Item(0, mifila).Value().ToString
                ' ANALISIS GERENCIAL
            Case "analisis"
                Frmccosto.txtcc.Text = gitems.Item(1, mifila).Value().ToString
                Frmccosto.txtnomcc.Text = gitems.Item(0, mifila).Value().ToString
                Frmccosto.txtpres.Text = gitems.Item(3, mifila).Value().ToString
           
        End Select
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        'If cad = "" Then Exit Sub
        'cad = UCase(cad)
        'Dim cad2, aux As String
        'For i = 0 To gitems.RowCount - 1
        '    aux = gitems.Item(1, i).Value.ToString
        '    If Val(aux.Length) >= Val(cad.Length) Then
        '        cad2 = ""
        '        For j = 0 To cad.Length - 1
        '            cad2 = cad2 & aux(j)
        '        Next
        '        If cad = cad2 Then
        '            Dim C As Integer = 1, F As Integer = i
        '            gitems.CurrentCell = gitems(C, F)
        '            gitems.Focus()
        '            Exit Sub
        '        End If
        '    End If
        'Next

        Dim cl As Integer = 0
        Try

            If cmbbuscar.Text = "CODIGO" Then
                cl = 1
            ElseIf cmbbuscar.Text = "NOMBRE" Then
                cl = 0
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

    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged

    End Sub
End Class