Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmVisorImagen
    Dim tn As New DataTable
    Dim im As Integer = 0
    Private Sub FrmVisorImagen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        im = lbnum.Text

        MiConexion(bda)

        tn.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM inm_galeria  WHERE codinm='" & txtinm.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Refresh()


        seleccionar(lbnum.Text)
        Cerrar()

    End Sub
    Private Sub buscarImagenes()
        MiConexion(bda)


        Dim tn As New DataTable
        tn.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM inm_galeria  WHERE codinm='" & txtinm.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Refresh()

        If tn.Rows.Count > 0 Then
            seleccionar(0)
            'Else

            '    If txtcodinm.Text <> "" Then
            '        MsgBox("No exiten imagenes de este inmueble", MsgBoxStyle.Information, "Verificación")
            '    End If
        End If

        Cerrar()

    End Sub
    Function ExtraerImagen(ByVal Foto As Integer) As Byte()

        Lbdes.Text = tn.Rows(Foto).Item("descr")
        Dim MyPhoto() As Byte = CType(tn.Rows(Foto).Item("imagen"), Byte())
        Return MyPhoto

    End Function
    Private Sub seleccionar(ByVal mifila As Integer)
        Try
            Dim ms As New MemoryStream(ExtraerImagen(mifila))
            Imagen2.Image = Image.FromStream(ms)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        If im < tn.Rows.Count Then
            im = im + 1
            If im < tn.Rows.Count Then
                seleccionar(im)
            End If
        End If
        
    End Sub

    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        If im > 0 Then
            im = im - 1
            If im >= 0 Then
                seleccionar(im)
            End If
        End If
       
    End Sub
End Class