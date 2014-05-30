Public Class FrmDesaprobarDoc

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmDesaprobarDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion("sae")
        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT desap, rol from usuarios where login='" & FrmPrincipal.lbuser.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)


        If tabla.Rows(0).Item(0) <> "S" Then
            MsgBox("No Tiene Permisos para este Proceso", MsgBoxStyle.Information, "Verifique")
            Me.Close()
        End If

        Cerrar()


        If FrmPrincipal.Inventarios.Visible = True And FrmPrincipal.Inventarios.Enabled = True Then
            BtInv.Enabled = True
        Else
            BtInv.Enabled = False
        End If
        If FrmPrincipal.BEstetica.Visible = True Or (FrmPrincipal.Facturacion.Enabled = True And FrmPrincipal.Facturacion.Visible = True) Then
            BtFv.Enabled = True
        Else
            BtFv.Enabled = False
        End If
        If FrmPrincipal.Cartera.Visible = True And FrmPrincipal.Cartera.Enabled = True Then
            BtRc.Enabled = True
        Else
            BtRc.Enabled = False
        End If
        If FrmPrincipal.Proveedores.Visible = True And FrmPrincipal.Proveedores.Enabled = True Then
            BtFP.Enabled = True
            BtCxP.Enabled = True
        Else
            BtFP.Enabled = False
            BtCxP.Enabled = False
        End If

        'If FrmPrincipal.inmobiliaria.Visible = True And FrmPrincipal.inmobiliaria.Enabled = True Then
        '    BtRc.Enabled = True
        '    BtCxP.Enabled = True
        'Else
        '    BtRc.Enabled = False
        '    BtCxP.Enabled = False
        'End If



    End Sub

    Private Sub BtFv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFv.Click
        MiConexion(bda)
        Cerrar()
        FrmDesFact.ShowDialog()
    End Sub

    Private Sub BtInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtInv.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaInvetario.ShowDialog()
    End Sub

    Private Sub BtRc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRc.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCartera.ShowDialog()
    End Sub

    Private Sub BtFP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFP.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCompra.ShowDialog()
    End Sub

    Private Sub BtCxP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCxP.Click
        MiConexion(bda)
        Cerrar()
        FrmDesaCxP.ShowDialog()
    End Sub
End Class