Public Class FrmGerencial

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub cmdsoptec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsoptec.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/rl-ingenieria/soporte.php")
        FrmWEB.Text = "SOPORTE WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdweb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdweb.Click
        FrmWEB.wb.Navigate("http://www.csi-ingenieria.com/")
        FrmWEB.Text = "EXPLORADOR WEB"
        FrmWEB.ShowDialog()
    End Sub

    Private Sub cmdbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackup.Click
        MiConexion(bda)
        Cerrar()
        FrmCopiaSeguridad.ShowDialog()
    End Sub

    Private Sub cmdperio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdperio.Click
        BuscarPeriodo()
        FrmPeriodo.lbactual.Text = PerActual
        FrmPeriodo.ShowDialog()
    End Sub

    Private Sub cmdcompa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcompa.Click
        MostrarCompaniaParaAbrir()
        FrmAbrirCompania.lbform.Text = "factura"
        FrmAbrirCompania.ShowDialog()
        MiConexion(bda)
        Cerrar()
    End Sub
    Private Sub cmdcli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcli.Click
        MiConexion(bda)
        Cerrar()
        FrmClienteC.ShowDialog()
        FrmClienteC.txtnitc.Focus()
    End Sub

    Private Sub cmdpro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpro.Click
        MiConexion(bda)
        Cerrar()
        FrmAnaProv.ShowDialog()
        FrmAnaProv.txtnitc.Focus()
    End Sub

    Private Sub cmdparinv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparinv.Click
        FrmParametrosGer.ShowDialog()
    End Sub

    Private Sub FrmGerencial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MiConexion(bda)
        Cerrar()
        Dim cr As String = ""

        MiConexion(bda)

        Try
            cr = " CREATE TABLE  `par_analisis` ( " _
              & " `num` INT( 11 ) NOT NULL , " _
              & " `detalle` VARCHAR( 30 ) NOT NULL , " _
              & " `cuenta1` VARCHAR( 15 ) NOT NULL , " _
              & " `cuenta2` VARCHAR( 15 ) NOT NULL , " _
               & "`cuenta3` VARCHAR( 15 ) NOT NULL , " _
               & " `cuenta4` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta5` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta6` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta7` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta8` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta9` VARCHAR( 15 ) NOT NULL , " _
               & "  `cuenta10` VARCHAR( 15 ) NOT NULL " _
               & " );"

            myCommand.Parameters.Clear()
            myCommand.CommandText = cr
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try


        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM `par_analisis`;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            myCommand.Parameters.Clear()
            myCommand.CommandText = "  INSERT INTO  `par_analisis` (  `num` ,  `detalle` ,  `cuenta1` ,  `cuenta2` ,  `cuenta3` ,  `cuenta4` ,  `cuenta5` ,  `cuenta6` ,  `cuenta7` ,  `cuenta8` ,  `cuenta9` ,  `cuenta10` ) " _
           & "  VALUES ( '1',  'Ingresos',  '',  '',  '',  '',  '',  '',  '',  '',  '',  ''), ( '2',  'Gastos',  '',  '',  '',  '',  '',  '',  '',  '',  '',  '');"
            myCommand.ExecuteNonQuery()
        End If
        Cerrar()
    End Sub

    Private Sub ButtonX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX9.Click

        MiConexion(bda)
        Dim ing As String = ""
        Dim gas As String = ""

        Dim tc As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM `parcontab`;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)

        Dim t_ing As New DataTable
        myCommand.CommandText = "SELECT * FROM  `par_analisis` ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t_ing)
        Refresh()

        For k = 1 To 10
            If t_ing.Rows(0).Item("cuenta" & k) <> "" Then
                ing = "okg"
            End If
            If t_ing.Rows(1).Item("cuenta" & k) <> "" Then
                gas = "okg"
            End If
        Next

        If tc.Rows.Count > 0 Then
            If tc.Rows(0).Item(0) = "S" Then
                If ing <> "" And gas <> "" Then
                    Frmccosto.ShowDialog()
                Else
                    MsgBox("Usted no ha definido los parametros", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Usted no trabaja con centros de costos ", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub cmdayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdayuda.Click
        Dim ruta As String
        ruta = My.Application.Info.DirectoryPath & "\Reportes\Ayuda_Gerencial.pdf"
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
End Class