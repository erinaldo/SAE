Public Class Frmdescrip_items



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case lbform.Text
            Case ""
                txtfila.Text = FrmItems.fila
                If FrmItems.gitems.Item("tipo", FrmItems.fila).Value = "I" Then
                    FrmItems.gitems.Item("descrip", FrmItems.fila).Value = FrmItems.gitems.Item("descrip", FrmItems.fila).Value & " " & txtdescp.Text
                Else
                    FrmItems.gitems.Item("descrip", FrmItems.fila).Value = txtdescp.Text
                End If
            Case "inm"
                If FrmInmDependencias.gEspacio.Item("nombre", FrmInmDependencias.fila).Value = "OTROS..." Then
                    FrmInmDependencias.gEspacio.Item("nombre", FrmInmDependencias.fila).Value = txtdescp.Text
                Else
                    FrmInmDependencias.gEspacio.Item("nombre", FrmInmDependencias.fila).Value = FrmInmDependencias.gEspacio.Item("nombre", FrmInmDependencias.fila).Value & " " & txtdescp.Text
                End If
            Case "inm_ser"
                FrmInmServicios.gservicios.Item("serv", FrmInmServicios.filaS).Value = txtdescp.Text
            Case "inm_sitio"
                If FrmInmLlaves.grilla.Item("sitio", FrmInmLlaves.fila).Value = "OTROS..." Then
                    FrmInmLlaves.grilla.Item("sitio", FrmInmLlaves.fila).Value = txtdescp.Text
                Else
                    FrmInmLlaves.grilla.Item("sitio", FrmInmLlaves.fila).Value = FrmInmLlaves.grilla.Item("sitio", FrmInmLlaves.fila).Value & " " & txtdescp.Text
                End If
        End Select

        Me.Close()
    End Sub

    Private Sub Frmdescrip_items_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfila.Text = ""
        txtdescp.Text = ""
        If FrmItems.gitems.Item("tipo", FrmItems.fila).Value = "S" Then
            txtdescp.Text = FrmItems.gitems.Item("descrip", FrmItems.fila).Value()
        End If

    End Sub

    Private Sub txtdescp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdescp.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Button1_Click(AcceptButton, AcceptButton)
        End If

    End Sub

    
End Class