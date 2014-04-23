Public Class FrmAuditoria


    Private Sub FrmAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)
        Auditoria(bda)

    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MiConexion("sae")
        Cerrar()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT count(*) FROM sae.companias;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows(0).Item(0) <= 0 Then
            MsgBox("No hay compañias creadas. Verifique.  ", MsgBoxStyle.Information, "SAE Verificación")
            Exit Sub
        End If
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "conta"
        FrmAbrirCompania.ShowDialog()
        MiConexion(bda)
        Cerrar()
    End Sub

    Private Sub cmdperio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperio.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
    End Sub

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        FrmCopiaSeguridad.lbform.Text = "aud"
        FrmCopiaSeguridad.GroupBox1.Text = "Copia de seguridad Movimiento de usuarios"
        FrmCopiaSeguridad.ShowDialog()
        FrmCopiaSeguridad.lbform.Text = ""
        FrmCopiaSeguridad.GroupBox1.Text = "Informacion del Backup"
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://csi-ingenieria.com")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://csi-ingenieria.com/contactenos.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Contable.pdf"
        Try
            If (ruta IsNot Nothing) Then
                FrmAyuda.pdf.LoadFile(ruta)
                FrmAyuda.Show()
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            AbrirArchivo(ruta)
        End Try
    End Sub

    Private Sub datosbac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles datosbac.Click

        'If datosbac.IsSelected = True Then

        '    '    FrmloginAud.ShowDialog()
        '    '    If FrmloginAud.ok = "OK" Then

        '    ButtonX1.Visible = True
        '    ButtonX2.Visible = True
        '    lbcont.Visible = False
        '    cmdParFac.Visible = True
        '    cmdcomp.Visible = True
        '    cmdParInv.Visible = True
        '    cmdPCar.Visible = True
        '    '    Else
        '    '        cmd_SaldoIniciales.Visible = False
        '    '        ButtonX1.Visible = False
        '    '        ButtonX2.Visible = False
        '    '        cmd_pre.Visible = False
        '    '        lbcont.Visible = True
        '    '        cmdParFac.Visible = False
        '    '        cmdcomp.Visible = False
        '    '        cmdParInv.Visible = False
        '    '        cmdPCar.Visible = False
        '    '    End If
        'End If
    End Sub



    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        ''FrmUsuarioA.txtlogin.Text = "control"
        ''FrmUsuarioA.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        'FrmUsuarioApass.ShowDialog()
    End Sub


    Private Sub cmdPCar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPCar.Click
        MiConexion(bda)
        Cerrar()
        ''FrmparcarA.ShowDialog()
    End Sub

    Private Sub cmdParInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParInv.Click
        MiConexion(bda)
        Cerrar()
        'FmrParInv.ShowDialog()
    End Sub

    Private Sub cmdParFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParFac.Click
        MiConexion(bda)
        Cerrar()
        FrmParFac.ShowDialog()
    End Sub

    Private Sub cmdcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcomp.Click
        MiConexion(bda)
        Cerrar()
        FrmParProv.ShowDialog()
    End Sub


    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmInforAudit.ShowDialog()
    End Sub

    Private Sub cmdmovUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmovUser.Click
        MiConexion(bda)
        Cerrar()
        FrmInforAudMov.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmParOtrosDoc.ShowDialog()
    End Sub
End Class