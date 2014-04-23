Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Drawing.Printing

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Imports System
Imports System.Object
Public Class FrmParInmob

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub txtcta_v_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_v.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_ventas"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_v_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_v.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_rtf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_rtf.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_rtf"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_rtf_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_rtf.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_iva_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_iva.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_iva"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_iva.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_v_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_v.LostFocus
        'If txtcta_v.Text = "" Then
        '    txtcta_v_DoubleClick(AcceptButton, AcceptButton)
        'End If
    End Sub

    Private Sub txtcta_rtf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_rtf.LostFocus
        'If txtcta_rtf.Text = "" Then
        '    txtcta_rtf_DoubleClick(AcceptButton, AcceptButton)
        'End If
    End Sub

    Private Sub txtcta_iva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_iva.LostFocus
        'If txtcta_iva.Text = "" Then
        '    txtcta_iva_DoubleClick(AcceptButton, AcceptButton)
        'End If
    End Sub
    Private Sub IntereCartera()

        Dim tp As New DataTable
        tp.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT hay_int,mon_int  FROM car_par ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)
        Refresh()

        If tp.Rows(0).Item(0) = "NO" Then
            MsgBox("No ha definido el porcentaje para los Intereses Moratorios", MsgBoxStyle.Information, "Verificación")

            Dim resultado As MsgBoxResult
            resultado = MsgBox("¿Desea Definir los Intereses Moratorios?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                FrmCartera.cmddoc_Click(AcceptButton, AcceptButton)
                'frmparametroscartera.ShowDialog()
                txtint.Text = frmparametroscartera.txtmonto.Text
                txtint_LostFocus(AcceptButton, AcceptButton)
            End If
        Else
            txtint.Text = tp.Rows(0).Item("mon_int")
            'Exit Sub
        End If
    End Sub
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        Try

            If cbfac.Checked = False And cbres1.Text = "" Then
                MsgBox("Seleccione Si tiene o No resolucion", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            End If

            IntereCartera()

            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los Parametros Inmobiliarios se van a guardar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                MiConexion(bda)



                Try
                    '************************
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "DELETE  FROM parcontrato ;"
                    myCommand.ExecuteNonQuery()
                    myCommand.Parameters.Clear()
                    Refresh()
                    '***********************
                Catch ex As Exception
                End Try


                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?comen", txtobs.Text)
                myCommand.Parameters.AddWithValue("?iva", txtcta_iva.Text)
                myCommand.Parameters.AddWithValue("?rtf", txtcta_rtf.Text)
                myCommand.Parameters.AddWithValue("?vent", txtcta_v.Text)
                If cbfac.Checked = False Then
                    myCommand.Parameters.AddWithValue("?prf", "NO")
                    myCommand.Parameters.AddWithValue("?docf", "")
                Else
                    myCommand.Parameters.AddWithValue("?prf", "SI")
                    myCommand.Parameters.AddWithValue("?docf", cbdocF.Text)
                End If
                myCommand.Parameters.AddWithValue("?tipof1", txttipo1.Text)
                myCommand.Parameters.AddWithValue("?a_f1", txtn1.Text)
                myCommand.Parameters.AddWithValue("?hr1", cbres1.Text)
                myCommand.Parameters.AddWithValue("?reso1", reso1.Text)
                myCommand.Parameters.AddWithValue("?fecexp1", fecexp1.Value)
                myCommand.Parameters.AddWithValue("?feclim1", feclim1.Value)
                myCommand.Parameters.AddWithValue("?ini1", ini1.Text)
                myCommand.Parameters.AddWithValue("?fin1", fin1.Text)
                myCommand.Parameters.AddWithValue("?pre1", pre1.Text)
                myCommand.Parameters.AddWithValue("?cli", txtcta_cli.Text)
                myCommand.Parameters.AddWithValue("?comi", txtcta_c.Text)
                If txtint.Text = "" Then
                    myCommand.Parameters.AddWithValue("?mora", CDbl(0))
                Else
                    myCommand.Parameters.AddWithValue("?mora", CDbl(txtint.Text))
                End If
                myCommand.Parameters.AddWithValue("?logo", data)
                myCommand.Parameters.AddWithValue("?ad", txtctaad.Text)
                myCommand.Parameters.AddWithValue("?ac", txtctaac.Text)
                'myCommand.Parameters.AddWithValue("?ctaing", txtctaing.Text)
                'If cbAcuerdo.Checked = False Then
                '    myCommand.Parameters.AddWithValue("?ctAc", "NO")
                'Else
                '    myCommand.Parameters.AddWithValue("?ctAc", "SI")
                'End If
                If e1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?editar", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?editar", "NO")
                End If
                myCommand.CommandText = "Insert INTO parcontrato Values (?comen,?vent,?iva,?rtf,?prf,?docf,?tipof1,?a_f1,?hr1,?reso1,?fecexp1,?feclim1,?ini1,?fin1,?pre1,?cli,?comi,?mora,?logo,?ad,?ac,?editar);"
                myCommand.ExecuteNonQuery()
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()

                Cerrar()
            End If
        Catch ex As Exception
            MsgBox("Error al guardar los parametros " & ex.ToString)
        End Try

    End Sub
    Dim parf As String

    Private Sub FrmParInmob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hayfoto = 0

        txtobs.Focus()
        parf = ""

        ' Try
        Dim tb As New DataTable
        tb.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT comentario,ctavent,ctaiva,ctartf,parf,tipof1,a_f1,hr1,reso1,if(fecexp1='0000-00-00','11111111',fecexp1) as fecexp1,if(feclim1='0000-00-00',1111-11-11,feclim1) as feclim1,ini1,fin1,pre1,docf,ctacms,ctacli,mora,logo,ctaad,ctaac,editar FROM parcontrato ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows.Count <> 0 Then

            txtobs.Text = tb.Rows(0).Item("comentario")
            txtcta_iva.Text = tb.Rows(0).Item("ctaiva")
            txtcta_rtf.Text = tb.Rows(0).Item("ctartf")
            txtcta_v.Text = tb.Rows(0).Item("ctavent")
            txtcta_c.Text = tb.Rows(0).Item("ctacms")
            txtcta_cli.Text = tb.Rows(0).Item("ctacli")
            txtctaad.Text = tb.Rows(0).Item("ctaad")
            txtctaac.Text = tb.Rows(0).Item("ctaac")
            If tb.Rows(0).Item("editar") = "NO" Then
                e2.Checked = False
                e1.Checked = True
            Else
                e1.Checked = True
                e2.Checked = False
            End If
            '.... MORA
            If Moneda(tb.Rows(0).Item("mora")) = Moneda(0) Then
                Dim tm As New DataTable
                tm.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT mon_int FROM car_par  ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tm)
                Refresh()
                If tm.Rows.Count > 0 Then
                    txtint.Text = Moneda(tm.Rows(0).Item(0))
                Else
                    txtint.Text = Moneda(0)
                End If
            Else
                txtint.Text = Moneda(tb.Rows(0).Item("mora"))
            End If

            'txtint.Text = Moneda(tb.Rows(0).Item("mora"))
            Try
                imgfoto.Image = Bytes_Imagen(tb.Rows(0).Item("logo"))
            Catch ex As Exception
                imgfoto.Image = Nothing
            End Try

            'parf = tb.Rows(0).Item("parf")
            If tb.Rows(0).Item("parf") = "NO" Then
                cbdocF.Items.Clear()
                cbdocF.Enabled = False
                txtdocF.Text = ""
                cbfac.Checked = False
                txttipo1.Text = tb.Rows(0).Item("tipof1")
                txtn1.Text = NumeroDoc(tb.Rows(0).Item("a_f1"))
                txtn1.Enabled = False
                cbres1.Text = tb.Rows(0).Item("hr1")
                reso1.Text = tb.Rows(0).Item("reso1")
                ini1.Value = Val(1)
                fin1.Value = Val(1000)
                pre1.Text = tb.Rows(0).Item("pre1")
                Try
                    fecexp1.Value = tb.Rows(0).Item("fecexp1")
                    feclim1.Value = tb.Rows(0).Item("feclim1")
                Catch ex As Exception
                    fecexp1.Value = Today
                    feclim1.Value = Today
                End Try
            Else
                parf = "s"
                cbfac.Checked = True
                cbdocF.Items.Clear()
                cbdocF.Enabled = True
                cbdocF.Items.Clear()
                cbdocF.Items.Add(tb.Rows(0).Item("docf"))
                cbdocF.Text = tb.Rows(0).Item("docf")
                'cbdocF_SelectedIndexChanged(AcceptButton, AcceptButton)
                txttipo1.Enabled = True
            End If
        End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub txtobs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtobs.TextChanged

    End Sub

    Private Sub txttipo1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttipo1.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "inm"
        FrmSelTipoDoc.ShowDialog()
    End Sub

    Private Sub cbres1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbres1.SelectedIndexChanged
        If cbres1.Text = "SI" Then
            reso1.Enabled = True
            fecexp1.Enabled = True
            feclim1.Enabled = True
            ini1.Enabled = True
            fin1.Enabled = True
            pre1.Enabled = True
        Else
            cbres1.Text = "NO"
            reso1.Enabled = False
            fecexp1.Enabled = False
            feclim1.Enabled = False
            ini1.Enabled = False
            fin1.Enabled = False
            pre1.Enabled = False
        End If
    End Sub


    Private Sub cbfac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbfac.CheckedChanged
        parf = ""
        If cbfac.Checked = True Then
            txttipo1.Enabled = False
            cbdocF.Enabled = True
            cbdocF.Items.Clear()
            If parf = "" Then
                docFac()
            End If
        Else
            cbdocF.Enabled = False
            txttipo1.Enabled = True
        End If
    End Sub
    Private Sub docFac()


        Dim tb As New DataTable
        tb.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4 FROM `parafacgral`  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)
        Refresh()
        If tb.Rows.Count > 0 Then
            If tb.Rows(0).Item(0) <> "" Then
                cbdocF.Items.Add(tb.Rows(0).Item(0))
            End If
            If tb.Rows(0).Item(3) <> "" Then
                cbdocF.Items.Add(tb.Rows(0).Item(3))
            End If
            If tb.Rows(0).Item(1) <> "" Then
                cbdocF.Items.Add(tb.Rows(0).Item(1))
            End If
            If tb.Rows(0).Item(2) <> "" Then
                cbdocF.Items.Add(tb.Rows(0).Item(2))
            End If
        End If

    End Sub


    Private Sub cmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuevo.Click

        cbfac.Checked = False
        txttipo1.Text = ""
        txtn1.Text = NumeroDoc(0)
        txtn1.Enabled = False
        cbres1.Text = "NO"
        reso1.Text = ""
        ini1.Value = Val(1)
        fin1.Value = Val(1000)
        pre1.Text = ""
        fecexp1.Value = Today
        feclim1.Value = Today

        'cbfac.Checked = True
        'txttipo1.Enabled = True
    End Sub

    Private Sub cbdocF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdocF.SelectedIndexChanged
        If cbdocF.Text = "" Then
            txtdocF.Text = ""
        Else
            Dim tb As New DataTable
            tb.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT descripcion FROM tipdoc where tipodoc ='" & cbdocF.Text & "'  ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            Refresh()
            If tb.Rows.Count > 0 Then
                cbdocF.Text = cbdocF.Text
                txtdocF.Text = tb.Rows(0).Item(0)
            End If
        End If

    End Sub

    Private Sub txtcta_cli_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_cli.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_cli"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_cli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_cli.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcta_c_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcta_c.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_cms"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcta_c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcta_c.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtint.KeyPress
        ValidarMoneda(txtint, e)
    End Sub

    Private Sub txtint_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtint.LostFocus
        If txtint.Text = "" Then
            txtint.Text = Moneda(0)
        Else
            txtint.Text = Moneda(txtint.Text)
        End If
    End Sub

    Private Sub txtint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtint.TextChanged

    End Sub
    '*******************************
    Public pa As New System.Data.SqlClient.SqlParameter("@data", SqlDbType.VarBinary, 50) 'parametro de la sentencia sql
    Public data() As Byte 'arreglo de bytes el cual contedra la imagen
    Public ios As FileStream 'Manejo de archivos
    Dim hayfoto As Integer

    Private Sub cmdlogofac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogofac.Click
        Try
            Me.OPF.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data(ios.Length) 'llenamos el arreglo
                ios.Read(data, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto.Load(Me.OPF.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data 'llenamos la variable parametro con el arreglo
                hayfoto = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub

    
    Private Sub txtctaac_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaac.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_ac"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtctaad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaad.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_ad"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtctaing_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaing.DoubleClick
        Try
            FrmCuentas.lbform.Text = "parinm_ing"
            FrmCuentas.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtctaing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctaing.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        Else
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class