Public Class FrmSelVendedor
    Public fila, sw As Integer
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        sw = 0
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
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        BuscarVendedor(gitems.Item(0, fila).Value()) 'buscar registro
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub

        If lbform.Text = "contr" Then
            FrmContratos.txtvend.Text = gitems.Item(2, mifila).Value()
            FrmContratos.txtnomven.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "infcitas" Then
            FrmInforCitas.txtnita.Text = gitems.Item(2, mifila).Value()
            FrmInforCitas.txtnoma.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "inf_vend" Then
            FrmInfoVendedores.txttip.Text = gitems.Item(2, mifila).Value()
            FrmInfoVendedores.txtnom.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "frs" Then
            FrmFacturaEstetica.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmFacturaEstetica.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "fr" Then
            Frmfacturarapida.txtnitv.Text = gitems.Item(2, mifila).Value()
            Frmfacturarapida.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "vendedor" Then
            FrmVendedores.lbestado.Text = "CONSULTA"
            FrmVendedores.lbnumero.Text = mifila + 1
            FrmVendedores.txtnit.Text = gitems.Item(2, mifila).Value()
            FrmVendedores.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "fp" Then
            FrmEntraPedidos.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmEntraPedidos.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "fn" Then
            FrmFacturasyAjustes.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmFacturasyAjustes.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "ter" Then
            frmterceros.txtnit.Text = gitems.Item(2, mifila).Value()
            frmterceros.txtnombre.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "fr_car" Then
            FrmFacturasPendientes.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmFacturasPendientes.txtvendedor.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "cita_v" Then
            FrmGestionCitas.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmGestionCitas.txtnomv.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "cita_a" Then
            FrmGestionCitas.txtnita.Text = gitems.Item(2, mifila).Value()
            FrmGestionCitas.txtnoma.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "novedades" Then
            FrmNovedadInm.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmNovedadInm.txtnomv.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "comicar" Then
            FrmConcomiCart.txttip.Text = gitems.Item(2, mifila).Value()
            FrmConcomiCart.txtnom.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "comicarV" Then
            FrmConcomiCart.txttip.Text = gitems.Item(2, mifila).Value()
            FrmConcomiCart.txtnom.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "reccar" Then
            FrmReciboCartera.txtnitv.Text = gitems.Item(2, mifila).Value()
            FrmReciboCartera.txtnomv.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "infcartcom" Then
            FrmInfCartComision.txtnitc.Text = gitems.Item(2, mifila).Value()
            FrmInfCartComision.txtcliente.Text = gitems.Item(1, mifila).Value()
        ElseIf lbform.Text = "item_s" Then
            Dim fil As Integer
            fil = Val(lbfila.Text)
            FrmItemsEst.gitems.Item(15, fil).Value = gitems.Item(2, mifila).Value()
        End If
        gitems.Focus()
        sw = 1
        Me.Close()
    End Sub
    Public Sub BuscarVendedor(ByVal dato As String)
        MsgBox("OPCION PENDIENTE")
    End Sub
    Private Sub FrmSelVendedor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'If sw <> 1 Then
        '    seleccionar(0)
        '    Exit Sub
        'End If
        'sw = 0
    End Sub

    Private Sub FrmSelVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        'Try
        '    If cad = "" Then Exit Sub
        '    cad = UCase(cad)
        '    Dim cad2, aux As String
        '    For i = 0 To gitems.RowCount - 1
        '        aux = gitems.Item(1, i).Value.ToString
        '        If Val(aux.Length) >= Val(cad.Length) Then
        '            cad2 = ""
        '            For j = 0 To cad.Length - 1
        '                cad2 = cad2 & aux(j)
        '            Next
        '            If cad = cad2 Then
        '                Dim C As Integer = 1, F As Integer = i
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
            'If cmbbuscar.Text = "NOMBRES" Then
            '    cl = 1
            'ElseIf cmbbuscar.Text = "NIT/CEDULA" Then
            '    cl = 2
            'End If
            cl = 1

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
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class