Public Class FrmCartera


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
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://rl-ingenieria.com/")
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
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub cmdsaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsaldo.Click
        MiConexion(bda)
        Cerrar()
        FrmFacturasPendientes.ShowDialog()
    End Sub

    Private Sub cmddoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddoc.Click
        MiConexion(bda)
        Cerrar()
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT * FROM car_par LIMIT 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No hay parametros definidos, Verifique.  ", MsgBoxStyle.Information, "Verificando.  ")
            frmparametroscartera.lb.Text = "NUEVO"
            frmparametroscartera.txttipo1.Text = ""
            frmparametroscartera.txttipo2.Text = ""
            frmparametroscartera.txttipo3.Text = ""
            frmparametroscartera.txttipo4.Text = ""
            frmparametroscartera.txtajust.Text = ""
            frmparametroscartera.txtrc.Text = ""
            frmparametroscartera.txtrcc.Text = ""

            '***************************************
            frmparametroscartera.rbcont2.Checked = True
            '***************************************

            frmparametroscartera.txtcaja.Text = ""
            frmparametroscartera.txtbanco.Text = ""
            frmparametroscartera.txtctapc.Text = ""
            frmparametroscartera.txtretencion.Text = ""
            frmparametroscartera.txtventas.Text = ""
            frmparametroscartera.txtivapp.Text = ""
            frmparametroscartera.txtdescuento.Text = ""
            frmparametroscartera.txtretencion.Text = ""
            frmparametroscartera.ShowDialog()
            Exit Sub
        End If
        frmparametroscartera.lb.Text = ""
        frmparametroscartera.txttipo1.Text = tabla.Rows(0).Item("par_fac1")
        frmparametroscartera.txttipo2.Text = tabla.Rows(0).Item("par_fac2")
        frmparametroscartera.txttipo3.Text = tabla.Rows(0).Item("par_fac3")
        frmparametroscartera.txttipo4.Text = tabla.Rows(0).Item("par_fac4")
        frmparametroscartera.txtajust.Text = tabla.Rows(0).Item("par_aju")
        frmparametroscartera.txtrc.Text = tabla.Rows(0).Item("par_rc")
        frmparametroscartera.txtrcc.Text = tabla.Rows(0).Item("par_ci")
        'frmparametroscartera.txtajust.Text = tabla.Rows(0).Item("par_posf")

        '************************************************
        
        If tabla.Rows(0).Item("par_int") = "SI" Then
            Try
                frmparametroscartera.rbcont1.Checked = True
                frmparametroscartera.txtcaja.Text = tabla.Rows(0).Item("par_cta_caja")
                frmparametroscartera.txtbanco.Text = tabla.Rows(0).Item("par_cta_ban")
                frmparametroscartera.txtctapc.Text = tabla.Rows(0).Item("par_cta_cco")
                frmparametroscartera.txtventas.Text = tabla.Rows(0).Item("par_cta_ven")
                frmparametroscartera.txtivapp.Text = tabla.Rows(0).Item("par_cta_iva")
                frmparametroscartera.txtdescuento.Text = tabla.Rows(0).Item("par_cta_des")
                frmparametroscartera.txtretencion.Text = tabla.Rows(0).Item("par_cta_ret")
            Catch ex As Exception
            End Try
        ElseIf tabla.Rows(0).Item("par_int") = "NO" Then
            frmparametroscartera.rbcont2.Checked = True
        End If
        frmparametroscartera.ShowDialog()
    End Sub

    Private Sub ButtonX20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX20.Click
        MiConexion(bda)
        Cerrar()
        Frmestadisticaedades.ShowDialog()
    End Sub


    Private Sub cmd_OtrosIngresos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_OtrosIngresos.Click
        MiConexion(bda)
        Cerrar()
        CrearTablaOT_DOC()
        FrmCompIngresos.ShowDialog()
    End Sub
End Class