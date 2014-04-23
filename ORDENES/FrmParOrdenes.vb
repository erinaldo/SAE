Public Class FrmParOrdenes

    Private Sub cbf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbf.SelectedIndexChanged
        If cbf.Text = "" Then
            gf1.Enabled = False
            gf2.Enabled = False
            gf3.Enabled = False
            gf4.Enabled = False
            gf5.Enabled = False
        ElseIf cbf.Text = "1" Then
            gf1.Enabled = True
            gf2.Enabled = False
            gf3.Enabled = False
            gf4.Enabled = False
            gf5.Enabled = False
        ElseIf cbf.Text = "2" Then
            gf1.Enabled = True
            gf2.Enabled = True
            gf3.Enabled = False
            gf4.Enabled = False
            gf5.Enabled = False
        ElseIf cbf.Text = "3" Then
            gf1.Enabled = True
            gf2.Enabled = True
            gf3.Enabled = True
            gf4.Enabled = False
            gf5.Enabled = False
        ElseIf cbf.Text = "4" Then
            gf1.Enabled = True
            gf2.Enabled = True
            gf3.Enabled = True
            gf4.Enabled = True
            gf5.Enabled = False
        ElseIf cbf.Text = "5" Then
            gf1.Enabled = True
            gf2.Enabled = True
            gf3.Enabled = True
            gf4.Enabled = True
            gf5.Enabled = True
        End If
    End Sub

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        If cbf.Text = "" Then
            MsgBox("Verifique el numero de firmas", MsgBoxStyle.Information, "Verificacion")
            cbf.Focus()
            Exit Sub
        End If
        guardarFirms()
    End Sub
    Private Sub guardarFirms()
        Try
            MiConexion(bda)
            borrardatos()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?num", CInt(cbf.Text))
            'firma1
            If gf1.Enabled = True Then
                myCommand.Parameters.AddWithValue("?t1", txttitulo1.Text)
                myCommand.Parameters.AddWithValue("?msj1", txtmsj1.Text)
                myCommand.Parameters.AddWithValue("?f1", txtnom1.Text)
                myCommand.Parameters.AddWithValue("?p1", txtpie1.Text)
            Else
                myCommand.Parameters.AddWithValue("?t1", "")
                myCommand.Parameters.AddWithValue("?msj1", "")
                myCommand.Parameters.AddWithValue("?f1", "")
                myCommand.Parameters.AddWithValue("?p1", "")
            End If
            'firma2
            If gf2.Enabled = True Then
                myCommand.Parameters.AddWithValue("?t2", txttitulo2.Text)
                myCommand.Parameters.AddWithValue("?msj2", txtmsj2.Text)
                myCommand.Parameters.AddWithValue("?f2", txtnom2.Text)
                myCommand.Parameters.AddWithValue("?p2", txtpie2.Text)
            Else
                myCommand.Parameters.AddWithValue("?t2", "")
                myCommand.Parameters.AddWithValue("?msj2", "")
                myCommand.Parameters.AddWithValue("?f2", "")
                myCommand.Parameters.AddWithValue("?p2", "")
            End If
            'firma3
            If gf3.Enabled = True Then
                myCommand.Parameters.AddWithValue("?t3", txttitulo3.Text)
                myCommand.Parameters.AddWithValue("?msj3", txtmsj3.Text)
                myCommand.Parameters.AddWithValue("?f3", txtnom3.Text)
                myCommand.Parameters.AddWithValue("?p3", txtpie3.Text)
            Else
                myCommand.Parameters.AddWithValue("?t3", "")
                myCommand.Parameters.AddWithValue("?msj3", "")
                myCommand.Parameters.AddWithValue("?f3", "")
                myCommand.Parameters.AddWithValue("?p3", "")
            End If
            'firma4
            If gf4.Enabled = True Then
                myCommand.Parameters.AddWithValue("?t4", txttitulo4.Text)
                myCommand.Parameters.AddWithValue("?msj4", txtmsj4.Text)
                myCommand.Parameters.AddWithValue("?f4", txtnom4.Text)
                myCommand.Parameters.AddWithValue("?p4", txtpie4.Text)
            Else
                myCommand.Parameters.AddWithValue("?t4", "")
                myCommand.Parameters.AddWithValue("?msj4", "")
                myCommand.Parameters.AddWithValue("?f4", "")
                myCommand.Parameters.AddWithValue("?p4", "")
            End If
            'firma5
            If gf5.Enabled = True Then
                myCommand.Parameters.AddWithValue("?t5", txttitulo5.Text)
                myCommand.Parameters.AddWithValue("?msj5", txtmsj5.Text)
                myCommand.Parameters.AddWithValue("?f5", txtnom5.Text)
                myCommand.Parameters.AddWithValue("?p5", txtpie5.Text)
            Else
                myCommand.Parameters.AddWithValue("?t5", "")
                myCommand.Parameters.AddWithValue("?msj5", "")
                myCommand.Parameters.AddWithValue("?f5", "")
                myCommand.Parameters.AddWithValue("?p5", "")
            End If
            If op1.Checked = True Then
                myCommand.Parameters.AddWithValue("?forden", "1")
            Else
                myCommand.Parameters.AddWithValue("?forden", "2")
            End If
            If ce1.Checked = True Then
                myCommand.Parameters.AddWithValue("?fce", "1")
            ElseIf ce2.Checked = True Then
                myCommand.Parameters.AddWithValue("?fce", "2")
            Else
                myCommand.Parameters.AddWithValue("?fce", "3")
            End If
            If n1.Checked = True Then
                myCommand.Parameters.AddWithValue("?nord", "A")
            Else
                myCommand.Parameters.AddWithValue("?nord", "M")
            End If
            myCommand.CommandText = "INSERT INTO ParOrdenes VALUES (?num,?t1,?msj1,?f1,?p1,?t2,?msj2,?f2,?p2,?t3,?msj3,?f3,?p3,?t4,?msj4,?f4,?p4,?t5,?msj5,?f5,?p5,?forden,?fce,?nord);"
            myCommand.ExecuteNonQuery()
            Cerrar()
            MsgBox("Los Parametros para las ordenes Fueron Guadados Exitosamente.", MsgBoxStyle.Information, "SAE, Guardar Parametros")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar los parametros", MsgBoxStyle.Information, "SAE")
            Cerrar()
        End Try
    End Sub
    Sub borrarParReso()
        Try
            myCommand.CommandText = "delete from parreso"
            myCommand.CommandType = CommandType.Text
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Sub borrardatos()
        Try
            myCommand.CommandText = "delete from ParOrdenes"
            myCommand.CommandType = CommandType.Text
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmParOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parordenes ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <> 0 Then
            cbf.Text = tabla.Rows(0).Item("num")
            txttitulo1.Text = tabla.Rows(0).Item("titulo1")
            txtmsj1.Text = tabla.Rows(0).Item("msj1")
            txtnom1.Text = tabla.Rows(0).Item("firma1")
            txtpie1.Text = tabla.Rows(0).Item("pie1")
            txttitulo2.Text = tabla.Rows(0).Item("titulo2")
            txtmsj2.Text = tabla.Rows(0).Item("msj2")
            txtnom2.Text = tabla.Rows(0).Item("firma2")
            txtpie2.Text = tabla.Rows(0).Item("pie2")
            txttitulo3.Text = tabla.Rows(0).Item("titulo3")
            txtmsj3.Text = tabla.Rows(0).Item("msj3")
            txtnom3.Text = tabla.Rows(0).Item("firma3")
            txtpie3.Text = tabla.Rows(0).Item("pie3")
            txttitulo4.Text = tabla.Rows(0).Item("titulo4")
            txtmsj4.Text = tabla.Rows(0).Item("msj4")
            txtnom4.Text = tabla.Rows(0).Item("firma4")
            txtpie4.Text = tabla.Rows(0).Item("pie4")
            txttitulo5.Text = tabla.Rows(0).Item("titulo5")
            Try
                txtmsj5.Text = tabla.Rows(0).Item("msj5")
                txtnom5.Text = tabla.Rows(0).Item("firma5")
                txtpie5.Text = tabla.Rows(0).Item("pie5").ToString
            Catch ex As Exception
            End Try
            If tabla.Rows(0).Item("forden") = "1" Then
                op1.Checked = True
            Else
                op2.Checked = True
            End If
            If tabla.Rows(0).Item("fce") = "1" Then
                ce1.Checked = True
            ElseIf tabla.Rows(0).Item("fce") = "2" Then
                ce2.Checked = True
            Else
                ce3.Checked = True
            End If
            If tabla.Rows(0).Item("nord") = "M" Then
                n2.Checked = True
            Else
                n1.Checked = True
            End If
        End If

        Dim tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM parreso ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <> 0 Then
            txttit.Text = tabla2.Rows(0).Item("titulo")
            txtmun.Text = tabla2.Rows(0).Item("municipio")
            txtfirR.Text = tabla2.Rows(0).Item("firma")
            txtpieR.Text = tabla2.Rows(0).Item("pie")
        End If

        Cerrar()
    End Sub

    Private Sub cmbCanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCanc.Click
        Me.Close()
    End Sub

    
    'Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
    '    If TabControl1.SelectTab = "" Then
    '        Me.Height = 585
    '    ElseIf TabControl1.SelectedTab = "" Then
    '        Me.Height = 560
    '    End If
    'End Sub

    Private Sub GuarReso()
        Try
            MiConexion(bda)
            borrarParReso()
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?tit", txttit.Text)
            myCommand.Parameters.AddWithValue("?mun", txtmun.Text)
            myCommand.Parameters.AddWithValue("?fir", txtfirR.Text)
            myCommand.Parameters.AddWithValue("?pie", txtpieR.Text)

            myCommand.CommandText = "INSERT INTO parreso VALUES(?tit,?mun,?fir,?pie) "
            myCommand.ExecuteNonQuery()
            Cerrar()
            MsgBox("Los Parametros para las Resoluciones Fueron Guadados Exitosamente.", MsgBoxStyle.Information, "SAE, Guardar Parametros")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar los parametros", MsgBoxStyle.Information, "SAE")
            Cerrar()
        End Try
    End Sub
    Private Sub cmdGReso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGReso.Click
        GuarReso()
    End Sub

    Private Sub BverOp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BverOp.Click
        Dim NombreArchivo As String = ""
        If op1.Checked = True Then
            NombreArchivo = My.Application.Info.DirectoryPath & "\Reportes\Rordenes\OP1.pdf"
        Else
            NombreArchivo = My.Application.Info.DirectoryPath & "\Reportes\Rordenes\OP2.pdf"
        End If
        AbrirArchivo(NombreArchivo)
    End Sub

    Private Sub BverCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BverCE.Click
        Dim NombreArchivo As String = ""
        If op1.Checked = True Then
            NombreArchivo = My.Application.Info.DirectoryPath & "\Reportes\Rordenes\CE.pdf"
        Else
            NombreArchivo = My.Application.Info.DirectoryPath & "\Reportes\Rordenes\CE2.pdf"
        End If
        AbrirArchivo(NombreArchivo)
    End Sub
End Class