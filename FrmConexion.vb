Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FrmConexion
    Dim ip As String

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If lbform.Text <> "ppal" Then
            MsgBox("No hay conexión establecida", MsgBoxStyle.Critical, "SAE Conexión")
            Application.Exit()
        Else
            Me.Close()
        End If
       
    End Sub
    Private Sub cmdprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprobar.Click
        If probarCnx() = True Then
            MsgBox("Prueba de conexión exitosa...   ", MsgBoxStyle.Information, "SAE Conexión")
        End If
    End Sub
    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdOk.Click
        If probarCnx() = True Then
            Dim linea, cad As String
            linea = ""
            cad = ip
            '///// IP //////
            For i = 0 To cad.Length - 1
                linea = linea & (Chr(Val(Asc(cad(i)))))
            Next
            linea = linea & ";"
            '///// USER //////
            cad = txtuser.Text
            For i = 0 To cad.Length - 1
                linea = linea & (Chr(Val(Asc(cad(i)))))
            Next
            linea = linea & ";"
            '///// PASS //////
            cad = txtpass.Text
            For i = 0 To cad.Length - 1
                linea = linea & (Chr(Val(Asc(cad(i)))))
            Next
            linea = linea & ";"
            '///// PUERTO //////
            cad = txtpuerto.Text
            For i = 0 To cad.Length - 1
                linea = linea & (Chr(Val(Asc(cad(i)))))
            Next

            '********** LLENAR ARCHIVO ************
            Dim swEscritor As StreamWriter
            swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\cnx.txt", False)
            swEscritor.Write(Trim(linea))
            swEscritor.Close()
            If lbform.Text = "ppal" Then
                MsgBox("Parametros de conexión creados exitosamente. Favor volver a ingresar al sistema...   ", MsgBoxStyle.Information, "SAE Conexión")
                End
            Else
                MsgBox("Parametros de conexión creados exitosamente...   ", MsgBoxStyle.Information, "SAE Conexión")
                Me.Close()
            End If
          
        End If
    End Sub
    Function probarCnx()
        If ip1.Checked = True Then
            ip = "127.0.0.1"
        Else
            ip = txt1.Text & "." & txt2.Text & "." & txt3.Text & "." & txt4.Text
        End If
        DBCon = New MySql.Data.MySqlClient.MySqlConnection
        DBCon.ConnectionString = "server=" & ip & ";user=" & txtuser.Text & "; password=" & txtpass.Text & "; database=sae;port=" & txtpuerto.Text & ";"
        Try
            'Abrimos la conexión y comprobamos que no hay error
            bConexionExitosa = True
            DBCon.Open()
            myCommand.Connection = DBCon
            DBCon.Close()
        Catch ex As MySqlException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox("No Hay Conexión establecida, Error: " & ex.Message.ToString, MsgBoxStyle.Critical, "SAE Conexión")
            bConexionExitosa = False
        End Try
        Return bConexionExitosa
    End Function

    Private Sub ip1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ip1.CheckedChanged
        txt1.Enabled = False
        txt2.Enabled = False
        txt3.Enabled = False
        txt4.Enabled = False
    End Sub
    Private Sub ip2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ip2.CheckedChanged
        txt1.Enabled = True
        txt2.Enabled = True
        txt3.Enabled = True
        txt4.Enabled = True
    End Sub

    Private Sub txtpuerto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpuerto.KeyPress
        validarnumero(txtpuerto, e)
    End Sub
    Private Sub txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress
        validarnumero(txt1, e)
    End Sub
    Private Sub txt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt2.KeyPress
        validarnumero(txt2, e)
    End Sub
    Private Sub txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt3.KeyPress
        validarnumero(txt3, e)
    End Sub
    Private Sub txt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt4.KeyPress
        validarnumero(txt4, e)
    End Sub

    Private Sub txtuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuser.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmConexion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtuser.Text = ""
        txtpass.Text = ""
    End Sub
End Class