Public Class FrmCopiaSeguridad
    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackup.Click
        lbsw.Text = "1"
        If cmbServidor.Text <> "" Then
            If Me.cboBaseDatos.Text <> "" Then
                If txtDirPathBackup.Text <> "" Then
                    If txtNom_Backup.Text <> "" Or Chbd.Checked = True Then
                        If txtDescrip_Backup.Text <> "" Then
                            lbespere.Visible = True
                            If crear_backup() = True Then
                                lbtime.Text = "0"
                                Timer1.Enabled = True
                            Else
                                ' MessageBox.Show("Error al crear el Backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Ingrese una descripcion del Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txtDescrip_Backup.Focus()
                        End If
                    Else
                        MessageBox.Show("Ingrese el nombre del Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtNom_Backup.Focus()
                    End If
                Else
                    MessageBox.Show("Seleccione la ruta donde se creara el Backup", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    btnExaminar.Focus()
                End If
            Else
                MessageBox.Show("Seleccione la Base de Datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        Else
            MessageBox.Show("Ingrese el Nombre del Servidor de Datos MYSQL", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function crear_backup() As Boolean
        Dim ruta As String = ""
        Dim comando, Arg As String
        Dim Pr As Process = New Process
        If txtDirPathBackup.Text = "C:\Archivos de programa\MySQL\MySQL Server 5.0\bin" Then
            Try
                If My.Computer.FileSystem.DirectoryExists(txtDirPathBackup.Text) Then
                    'MsgBox("existe")
                Else
                    txtDirPathBackup.Text = "C:\Archivos de programa (x86)\MySQL\MySQL Server 5.0\bin"
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        ruta = (cbdestino.Text & txtNom_Backup.Text & ".sql").Replace("\\", "/")
        comando = txtDirPathBackup.Text & "\mysqldump"
        Try
            If Chbd.Checked = True Then
                Dim tabla As New DataTable
                myCommand.CommandText = "SHOW DATABASES LIKE 'sae%';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                crear_backup = False
                For i = 0 To tabla.Rows.Count - 1
                    Try
                        ruta = (cbdestino.Text & tabla.Rows(i).Item(0).ToString & ".sql").Replace("\\", "/")
                        Try
                            Pr.Dispose()
                        Catch ex As Exception
                        End Try
                        Pr = New Process
                        Arg = "--opt --force " & datoscon2(tabla.Rows(i).Item(0).ToString) & "--databases " & tabla.Rows(i).Item(0).ToString & " -r " & ruta & ""
                        Pr.StartInfo.FileName = comando
                        Pr.StartInfo.Arguments = Arg
                        Pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        Pr.Start()
                    Catch ex As Exception
                        lbespere.Visible = False
                        MessageBox.Show("Error al crear el Backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                    End Try
                Next
                crear_backup = True
            Else
                Try
                    comando = txtDirPathBackup.Text & "\mysqldump"
                    If lbform.Text = "" Then
                        Arg = "--opt --force " & datoscon2(bda) & "--databases " & bda & " -r " & ruta & ""
                    Else
                        Arg = "--opt --force " & datoscon2(bda) & "--databases " & cboBaseDatos.Text & " -r " & ruta & ""
                    End If
                    'Arg = "--opt --force " & datoscon2(bda) & "--databases " & bda & " -r " & ruta & ""
                    Pr.StartInfo.FileName = comando
                    Pr.StartInfo.Arguments = Arg
                    Pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    Pr.Start()
                    crear_backup = True
                Catch ex As Exception
                    crear_backup = False
                    lbespere.Visible = False
                    MessageBox.Show("Error al crear el Backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    'Cerrar()
                End Try
            End If
            Try
                Pr.Dispose()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            lbespere.Visible = False
            crear_backup = False
            MessageBox.Show("Error al crear el Backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'lbespere.Visible = False
    End Function

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        lbsw.Text = "0"
        Dim Directorio As New FolderBrowserDialog
        If Directorio.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtDirPathBackup.Text = Directorio.SelectedPath
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        lbsw.Text = "1"
        Me.Close()
    End Sub

    Private Sub FrmCopiaSeguridad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lbsw.Text = "0" Then
            lbsw.Text = "1"
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmCopiaSeguridad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        lbespere.Visible = False
        lbsw.Text = "1"
        If lbform.Text = "" Then
            cboBaseDatos.Text = bda
            txtNom_Backup.Text = UCase(FrmPrincipal.lbcompania.Text) & "_" & Format(Now, "dd-MM-yyyy")
        Else
            cboBaseDatos.Text = "USER" & Strings.Mid(bda, 4, Strings.Len(bda) - 3)
            txtNom_Backup.Text = UCase("USER" & FrmPrincipal.lbcompania.Text) & "_" & Format(Now, "dd-MM-yyyy")
        End If
       
        Discos()
        Try
            Chbd_CheckedChanged(AcceptButton, AcceptButton)
        Catch ex As Exception

        End Try

        '--------------------

        Try
            Dim Archivo As String = ""
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & "\" & "RUTA" & ".txt"
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
            Else
                Archivo = "C:\Archivos de programa\MySQL\MySQL Server 5.0\bin"
            End If

            txtDirPathBackup.Text = Archivo

        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub Discos()
        cbdestino.Items.Clear()
        cbdestino.Items.Add("C:/")
        cbdestino.Items.Add("D:/")
        cbdestino.Items.Add("E:/")
        cbdestino.Items.Add("F:/")
        cbdestino.Items.Add("G:/")
        cbdestino.Items.Add("H:/")
        cbdestino.Items.Add("I:/")
        cbdestino.Items.Add("J:/")
        cbdestino.Text = "C:/"
    End Sub

    Private Sub Chbd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chbd.CheckedChanged
        If Chbd.Checked = True Then
            txtNom_Backup.Enabled = False
        Else
            txtNom_Backup.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim email As String = ""
        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        email = tabla2.Rows(0).Item("emailconta").ToString


        Dim i As Integer = 0
        Try
            i = Val(lbtime.Text)
        Catch ex As Exception
        End Try
        If i < 5 Then
            i = i + 1
            lbtime.Text = i
        ElseIf i < 10 And Chbd.Enabled = True Then
            i = i + 1
            lbtime.Text = i
        Else
            Timer1.Enabled = False
            lbespere.Visible = False
            '////////////////////////
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("PRINCIPAL", "COPIA DE SEGURIDAD ", "", "", "")
            End If

            If Chbd.Checked = True Then
                MessageBox.Show("Backup creado satisfactoriamnete, Archivos Guardados en " & cbdestino.Text, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If cb_copia.Checked = True Then
                    lbespere.Visible = True
                    lbespere.Text = "Enviando email... Esta operacion puede tardar varios minutos "
                End If
                MessageBox.Show("Backup creado satisfactoriamnete, Guardado en " & cbdestino.Text & txtNom_Backup.Text & ".sql", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If cb_copia.Checked = True Then
                    EnviarEmail("gmail", "tu.backup.sae@gmail.com", "saecopia123", cbdestino.Text & txtNom_Backup.Text & ".sql", "copia de seguridad sae " & Now & "Favor no responder a este correo, cualquier dificultad comuniquese con los siguientes numeros, REYNADO VEGA: 317 895 1206 - LIBANIS ARGUELLES 311 651 6330 o http://rl-ingenieria.com/soporte.php ", email, "", "COPIA DE SEGURIDAD SAE")

                    lbespere.Text = "Esta operacion puede tardar varios minutos porfavor espere...Enviando email"
                    lbespere.Visible = False
                End If
            End If
            Me.Close()
        End If
    End Sub

    Private Sub txtDirPathBackup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDirPathBackup.TextChanged

    End Sub

    
End Class