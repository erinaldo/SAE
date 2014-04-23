Public Class FrmBancos

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
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub
    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "EXPLORADOR WEB"
        FrmWEB.ShowDialog()
    End Sub
    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Contable.pdf"
        Try
            If (ruta IsNot Nothing) Then
                Try
                    AbrirArchivo(ruta)
                Catch ex As Exception
                    AbrirArchivo(ruta)
                End Try
            Else
                MsgBox("No se encontro el archivo de ayuda.  ", MsgBoxStyle.Information, "SAE")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '***************************************************
    Private Sub FrmBancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Bancos(bda)
        Cerrar()
    End Sub
    Private Sub cmddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddoc.Click
        MiConexion(bda)
        Cerrar()
        FrmParBancos.ShowDialog()
    End Sub

    Private Sub cmdBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBancos.Click
        MiConexion(bda)
        Cerrar()
        Try
            FrmGestionBancos.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdgenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgenerar.Click
        MiConexion(bda)
        Cerrar()
        FrmExtratosBanc.cminfoconciliaicon.Visible = False
        FrmExtratosBanc.ShowDialog()
    End Sub

    Private Sub cmdsaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldo.Click
        MiConexion(bda)
        Cerrar()
        Dim tablabloq As New DataTable
        myCommand.CommandText = "SELECT * FROM " & bda & ".bloq_per WHERE periodo='00' ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablabloq)
        If tablabloq.Rows(0).Item(1) <> "n" Then
            FrmSaldosIniciales.cmdbloquear.Enabled = False
        Else
            FrmSaldosIniciales.cmdbloquear.Enabled = True
        End If
        FrmSaldosIniciales.ShowDialog()
    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        MiConexion(bda)
        Cerrar()
        FrmEntradaDatos.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        'FrmExtratosBanc.cminfoconciliaicon.Visible = True
        FrmExtratosBanc.ShowDialog()
        'FrmExtratosBanc.cminfoconciliaicon.Visible = False
    End Sub

    Private Sub cdmlibmay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmlibmay.Click
        Dim cta As String = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT LEFT(codigo,4) AS cta FROM bancos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            cta = tabla.Rows(0).Item("cta")
        Catch ex As Exception

        End Try
        If cta <> "" Then
            FrmInformeCC.c3.Checked = True
            FrmInformeCC.txtcuenta.Text = cta
        End If
        FrmInformeCC.ShowDialog()
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX3.Click
        MiConexion(bda)
        Cerrar()
        FrmConciliacionB.ShowDialog()
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX4.Click
        MiConexion(bda)
        Cerrar()
        FrmTransacciones.ShowDialog()
    End Sub
End Class