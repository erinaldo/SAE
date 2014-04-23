Imports System.IO

Public Class FrmRestaurarCopia

    Private Sub FrmRestaurarCopia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If lbsw.Text = "0" Then
            lbsw.Text = "1"
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmRestaurarCopia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New DataTable
        myCommand.CommandText = "SELECT rol FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item(0).ToString <> "admin" Then
            Me.Close()
            MsgBox("Acceso denegado para este perfil de usuario....", MsgBoxStyle.Information, "SAE control.")
            Exit Sub
        End If
        cboBaseDatos.Text = bda
        lbsw.Text = "1"

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

            txtmysql.Text = Archivo

        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackup.Click
        lbsw.Text = "1"
        Try
            If txtmysql.Text = "" Then
                MsgBox("Seleccione directorio MYSQL, verifique", MsgBoxStyle.Information, "SAE Control")
                btnExaminar.Focus()
            ElseIf txtDirPathBackup.Text = "" Then
                MsgBox("Seleccione un archivo, verifique", MsgBoxStyle.Information, "SAE Control")
                btnExaminar.Focus()
            Else
                Restaurar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        lbsw.Text = "1"
        Me.Close()
    End Sub

    Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
        lbsw.Text = "0"
        Try
            Me.OPF.Filter = "(*.sql)|*.sql" 'filtro de archivos del OpenFileDialog 
            If Me.OPF.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                txtDirPathBackup.Text = OPF.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub btomysql_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btomysql.Click
        lbsw.Text = "0"
        Dim Directorio As New FolderBrowserDialog
        If Directorio.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtmysql.Text = Directorio.SelectedPath
        End If
    End Sub

    Public Sub Restaurar()
        MiConexion("sae")
        Cerrar()
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
        Try
            Dim comando, Arg, ruta As String
            ruta = (txtDirPathBackup.Text).Replace("\\", "/")
            comando = (txtmysql.Text).Replace("\\", "/")
            Arg = datoscon3(bda) & ruta
            'Arg = "mysql -u root -proot saeics2011 < C:\copia.sql"
            '================================================================================
            Dim Pr As Process = New Process
            Dim myProcess As Process = New Process
            myProcess.StartInfo.FileName = "cmd.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.WorkingDirectory = comando
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.Start()
            Dim myStreamWriter As StreamWriter = myProcess.StandardInput
            Dim mystreamreader As StreamReader = myProcess.StandardOutput
            myStreamWriter.WriteLine(Arg)
            'myStreamWriter.WriteLine("nombre de usuario mysql-u-p ***** DatabaseName <C: \ Backup.sql")
            myStreamWriter.Close()
            myProcess.WaitForExit()
            myProcess.Close()


            '*******************************************************************************
            'Dim fs As New FileStream("C:\SAE.bat", FileMode.Create, FileAccess.Write)
            'Dim s As New StreamWriter(fs)
            's.BaseStream.Seek(0, SeekOrigin.End)
            's.WriteLine("@echo off")
            's.WriteLine(comando & Arg)
            's.Close()
            'Process.Start(fs.Name)
            '-----------------------------------------------------------------------------
            MsgBox("La Restauración de la copia de seguridad se realizo correctamente.  ", MsgBoxStyle.Information, "SAE Información")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al restaurar el Backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MiConexion(bda)
        Cerrar()
    End Sub
    Public Sub RestaurarBackup()
        'Dim Archivo As String
        'Try
        '    Dim rutaconex As String
        '    rutaconex = (txtDirPathBackup.Text).Replace("\\", "/")
        '    If My.Computer.FileSystem.FileExists(rutaconex) Then
        '        Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
        '    Else
        '        MsgBox("Error #1100 Verifique origen del archivo Backup. ", MsgBoxStyle.Critical, "Verificando")
        '        Exit Sub
        '    End If
        '    'MiConexion(bda)
        '    'myCommand.Parameters.Clear()
        '    'myCommand.CommandText = Archivo
        '    'myCommand.ExecuteNonQuery()
        '    'Refresh()
        '    'Cerrar()
        '    Dim comando, Arg, ruta As String
        '    ruta = (txtDirPathBackup.Text).Replace("\\", "/")
        '    Arg = bda & " < " & Archivo
        '    comando = (txtmysql.Text & "\mysql").Replace("\\", "/")
        '    Dim Pr As Process = New Process
        '    Pr.StartInfo.FileName = comando
        '    Pr.StartInfo.Arguments = Arg
        '    Pr.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        '    Pr.Start()
        '    Pr.PriorityBoostEnabled = True
        'Catch ex As Exception
        '    MsgBox("Error #1100 " & ex.Message.ToString, MsgBoxStyle.Critical)
        '    Cerrar()
        'End Try
    End Sub
End Class