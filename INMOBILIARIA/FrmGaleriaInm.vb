Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmGaleriaInm
    Public fila As Integer
    Private Sub bloquear()
        cmdNuevo.Enabled = False
        cmdmodificar.Enabled = False
        cmdEliminar.Enabled = False
        txtdesc.Enabled = True
        cmdcancelar.Enabled = True
        cmdGuardar.Enabled = True
    End Sub
    Private Sub desbloquear()
        cmdNuevo.Enabled = True
        cmdmodificar.Enabled = True
        cmdEliminar.Enabled = True
        txtdesc.Enabled = False
        cmdcancelar.Enabled = False
        cmdGuardar.Enabled = False
    End Sub
    Private Sub limpiar()
        lbestado.Text = ""
        txtdesc.Text = ""
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Me.Size = New System.Drawing.Size(660, 381)
        gimagen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        OpenFileDialog1.Filter = "Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
        buscarImagenes()
        desbloquear()
        limpiar()
        PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Resources\app.jpg"
    End Sub

    Private Sub buscarImagenes()
        MiConexion(bda)

        Dim tn As New DataTable
        tn.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM inm_galeria  WHERE codinm='" & txtcodinm.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Refresh()

        gimagen.Rows.Clear()

        If tn.Rows.Count > 0 Then
            gimagen.RowCount = tn.Rows.Count
            For i = 0 To tn.Rows.Count - 1
                gimagen.Item("id", i).Value = tn.Rows(i).Item("id")
                gimagen.Item("imagen", i).Value = tn.Rows(i).Item("imagen")
                gimagen.Item("desc", i).Value = tn.Rows(i).Item("descr")
            Next
            seleccionar(0)
        Else
            limpiar()
            If txtcodinm.Text <> "" Then
                MsgBox("No exiten imagenes de este inmueble", MsgBoxStyle.Information, "Verificación")
            End If
        End If

        Cerrar()

        With gimagen
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        buscarImagenes()
    End Sub
    Public pa As New System.Data.SqlClient.SqlParameter("@data", SqlDbType.VarBinary, 50) 'parametro de la sentencia sql
    Public data() As Byte 'arreglo de bytes el cual contedra la imagen
    Public ios As FileStream 'Manejo de archivos
    Dim hayfoto As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click
        ' OpenFileDialog1.ShowDialog()
        bloquear()
        lbestado.Text = "NUEVO"
        Label1.Text = OpenFileDialog1.FileName.ToString
        ' PictureBox1.Image = System.Drawing.Image.FromFile(Label1.Text)

        Try
            '  Me.OpenFileDialog1.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                desbloquear()
                limpiar()

                Exit Sub
            Else
                ios = New FileStream(Me.OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data(ios.Length) 'llenamos el arreglo
                ios.Read(data, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.PictureBox1.Load(Me.OpenFileDialog1.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data 'llenamos la variable parametro con el arreglo
                hayfoto = 1
                txtdesc.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

        If txtcodinm.Text = "" Then
            MsgBox("Digite el codigo del Inmueble ", MsgBoxStyle.Information, "Verificación")
            Exit Sub
        Else
            Dim resultado As MsgBoxResult

            If lbestado.Text = "NUEVO" Then
                resultado = MsgBox("La Imagen se va a guardar para el inmueble " & txtcodinm.Text & ", ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then
                    MiConexion(bda)
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?imagen", data)
                        myCommand.Parameters.AddWithValue("?codinm", txtcodinm.Text.ToString)
                        myCommand.Parameters.AddWithValue("?descr", txtdesc.Text.ToString)
                        myCommand.CommandText = "Insert INTO inm_galeria (codinm,imagen,descr)Values(?codinm,?imagen,?descr) ;"
                        myCommand.ExecuteNonQuery()
                        Refresh()
                        MsgBox("Imagen Guardada", MsgBoxStyle.Information, "SAE")
                    Catch ex As Exception
                        MsgBox("Error al Guardar, Verifique el tamaño de la Imagen", MsgBoxStyle.Information, "Verificación")
                        PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Resources\app.jpg"
                    End Try
                    Cerrar()
                    gimagen.Focus()

                End If
            ElseIf lbestado.Text = "EDITAR" Then

                If gimagen.Focus = False Then
                    MsgBox("Seleccione la Imagen a editar", MsgBoxStyle.Information, "Verificación")
                    cmdcancelar_Click(AcceptButton, AcceptButton)
                    Exit Sub
                Else
                    resultado = MsgBox("La Descripción de Imagen N° " & gimagen.Item("id", fila).Value & " se va a Modificar. ¿Desea Modificarla?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        MiConexion(bda)
                        Try
                            myCommand.Parameters.Clear()
                            myCommand.Parameters.AddWithValue("?codinm", txtcodinm.Text.ToString)
                            myCommand.Parameters.AddWithValue("?descr", txtdesc.Text.ToString)
                            myCommand.CommandText = "UPDATE inm_galeria SET descr=?descr WHERE codinm=?codinm AND id=" & CInt(gimagen.Item("id", fila).Value) & " ;"
                            myCommand.ExecuteNonQuery()
                            Refresh()
                            MsgBox("Descripción Editada", MsgBoxStyle.Information, "SAE")
                        Catch ex As Exception
                            MsgBox("Error al Editar la Imagen", MsgBoxStyle.Information, "Verificación")
                        End Try
                        Cerrar()
                        gimagen.Focus()
                    End If
                End If
            End If

            buscarImagenes()
            cmdcancelar_Click(AcceptButton, AcceptButton)

        End If

    End Sub
    Function ExtraerImagen(ByVal Foto As Integer) As Byte()
        MiConexion(bda)

        Dim tn As New DataTable
        tn.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT imagen FROM inm_galeria where id = " & gimagen.Item("id", Foto).Value
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tn)
        Refresh()

        Dim MyPhoto() As Byte = CType(myCommand.ExecuteScalar(), Byte())
        Return MyPhoto

        Cerrar()

    End Function
    Private Sub seleccionar(ByVal mifila As Integer)
        Try
            Dim ms As New MemoryStream(ExtraerImagen(mifila))
            PictureBox1.Image = Image.FromStream(ms)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        buscarImagenes()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gimagen.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gimagen.CellEnter
        fila = e.RowIndex
        seleccionar(fila) 'captura f
    End Sub

    Private Sub DataGridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gimagen.KeyPress
        If gimagen.Focus = True Then
            seleccionar(fila)
        End If
    End Sub

    Private Sub txtcodinm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodinm.LostFocus
        MiConexion(bda)
        Try

            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM inmuebles WHERE estado<>'INACTIVO' and codigo='" & txtcodinm.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txtcodinm.Text = ""
                Try
                    FrmSelInmueble.lbform.Text = "InmGaleria"
                    FrmSelInmueble.ShowDialog()
                    ok_Click(AcceptButton, AcceptButton)
                Catch ex As Exception
                End Try
            Else
                txtcodinm.Text = tabla.Rows(0).Item("codigo")
                ok_Click(AcceptButton, AcceptButton)
            End If
           
        Catch ex As Exception
        End Try
        Cerrar()

    End Sub

    Private Sub txtcodinm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodinm.TextChanged
        If txtcodinm.Text = "" Then
            PictureBox1.ImageLocation = My.Application.Info.DirectoryPath & "\Resources\app.jpg"
            gimagen.Rows.Clear()
            limpiar()
        End If
    End Sub

    Private Sub cmdmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmodificar.Click
        bloquear()
        lbestado.Text = "EDITAR"
        txtdesc.Focus()
    End Sub

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        desbloquear()
        limpiar()
    End Sub


    Private Sub cmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEliminar.Click


        lbestado.Text = "ELIMINAR"

        If txtcodinm.Text = "" Then
            MsgBox("Digite el codigo del inmueble ", MsgBoxStyle.Information, "Verificación")
            lbestado.Text = ""
            Exit Sub
        Else
            If gimagen.Focus = False Then
                MsgBox("Seleccione la imagen a eliminar", MsgBoxStyle.Information, "Verificación")
                lbestado.Text = ""
                Exit Sub
            Else
                Dim resultado As MsgBoxResult
                resultado = MsgBox("Se va a Eliminar la Imagen N°" & gimagen.Item("id", fila).Value & " ¿Desea Continuar?", MsgBoxStyle.YesNo, "Verificando")
                If resultado = MsgBoxResult.Yes Then

                    MiConexion(bda)
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "DELETE FROM inm_galeria WHERE codinm='" & txtcodinm.Text & "' AND id = " & CInt(gimagen.Item("id", fila).Value)
                    myCommand.ExecuteNonQuery()
                    Refresh()
                    MsgBox("Imagen Eliminada", MsgBoxStyle.Information, "SAE")
                    Cerrar()

                    limpiar()
                    buscarImagenes()
                End If
            End If
        End If


    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    
    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Try
            Dim im As New MemoryStream(ExtraerImagen(fila))
            FrmVisorImagen.Imagen2.Image = Image.FromStream(im)
            FrmVisorImagen.Lbdes.Text = gimagen.Item("desc", fila).Value
            FrmVisorImagen.txtinm.Text = txtcodinm.Text
            FrmVisorImagen.lbnum.Text = fila
            FrmVisorImagen.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class