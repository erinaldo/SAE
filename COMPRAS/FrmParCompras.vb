Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Drawing.Printing
Public Class FrmParCompras
    Public pa As New System.Data.SqlClient.SqlParameter("@data", SqlDbType.VarBinary, 50) 'parametro de la sentencia sql
    Public data(), data2(), data3() As Byte 'arreglo de bytes el cual contedra la imagen
    Public ios As FileStream 'Manejo de archivos
    Dim hayfoto, hayfoto2, hayfoto3 As Integer
    '****** LOAD **********************************
    Private Sub FrmParCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hayfoto = 0
        hayfoto2 = 0
        hayfoto3 = 0
    End Sub
    '********* DESPLAZAMIENTO ************
    Private Sub cmdatras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdatras.Click
        cmdatras.Text = "&A"
        If Tab1.Visible = True Then
            cmdatras.Enabled = False
        ElseIf Tab2.Visible = True Then
            Tab1.Visible = True
            Tab2.Visible = False
            cmdatras.Text = ""
            cmdatras.Enabled = False
        ElseIf Tab3.Visible = True Then
            Tab2.Visible = True
            Tab3.Visible = False
            cmdsgt.Text = "&S"
            cmdsgt.Enabled = True
        End If
    End Sub
    Private Sub cmdsgt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsgt.Click
        cmdsgt.Text = "&S"
        If Tab1.Visible = True Then
            Tab1.Visible = False
            Tab2.Visible = True
            cmdatras.Text = "&A"
            cmdatras.Enabled = True
        ElseIf Tab2.Visible = True Then
            Tab2.Visible = False
            Tab3.Visible = True
            cmdsgt.Text = ""
            cmdsgt.Enabled = False
        ElseIf Tab3.Visible = True Then
            cmdsgt.Enabled = False
        End If
    End Sub
    '******** DOCUMENTOS *****************
    Private Sub txt_fp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_fp.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "comp_fp"
        FrmSelTipoDoc.ShowDialog()
    End Sub
    Private Sub txt_aj_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_aj.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "comp_aj"
        FrmSelTipoDoc.ShowDialog()
    End Sub
    Private Sub txt_cpp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cpp.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "comp_cpp"
        FrmSelTipoDoc.ShowDialog()
    End Sub
    Private Sub txt_gas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_gas.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "comp_gas"
        FrmSelTipoDoc.ShowDialog()
    End Sub
    Private Sub txt_ppf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ppf.DoubleClick
        FrmSelTipoDoc.lbtipo.Text = "comp_ppf"
        FrmSelTipoDoc.ShowDialog()
    End Sub
    '******** INTERFAZ CONTABLE ****************
    Private Sub rbcont1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont1.CheckedChanged
        If rbcont1.Checked = True Then
            g_cuentas.Enabled = True
        End If
    End Sub
    Private Sub rbcont2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcont2.CheckedChanged
        If rbcont2.Checked = True Then
            g_cuentas.Enabled = False
        End If
    End Sub
    '******** CUENTAS CONTABLES *****************
    Private Sub txt_cta_caja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_caja.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_caja"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_banco_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_banco.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_banco"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_cpp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_cpp.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_cpp"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_gas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_gas.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_gas"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_com_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_com.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_com"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_desc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_desc.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_desc"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_inv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_inv.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_inv"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_iva_g_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_iva_g.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_iva_g"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_por_iva_g_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_por_iva_g.KeyPress
        ValidarPorcentaje(txt_por_iva_g, e)
    End Sub
    Private Sub txt_por_iva_g_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_por_iva_g.LostFocus
        txt_por_iva_g.Text = Moneda(txt_por_iva_g.Text)
    End Sub
    Private Sub txt_cta_iva_d_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_iva_d.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_iva_d"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_por_iva_d_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_por_iva_d.KeyPress
        ValidarPorcentaje(txt_por_iva_d, e)
    End Sub
    Private Sub txt_por_iva_d_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_por_iva_d.LostFocus
        txt_por_iva_d.Text = Moneda(txt_por_iva_d.Text)
    End Sub
    Private Sub txt_cta_rtf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_rtf.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_rtf"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_fle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_fle.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_fle"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_seg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_seg.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_seg"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_ppf_c_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_ppf_c.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_ppf_c"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    Private Sub txt_cta_ppf_d_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta_ppf_d.DoubleClick
        FrmCuentas.lbaux.Text = "Grupo"
        FrmCuentas.lbform.Text = "comp_ppf_d"
        FrmCuentas.ShowDialog()
        FrmCuentas.lbaux.Text = "auxiliar"
    End Sub
    '**************************************************
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If lbpara.Visible = True Then
            Guardar()
        Else
            Modificar()
        End If
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    Public Sub Guardar()
        MiConexion(bda)
        Try
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los parametros de compras se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc_fp", txt_fp.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_aj", txt_aj.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_cpp", txt_cpp.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_gas", txt_gas.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_ppf", txt_ppf.Text.ToString)
                '****************************************************************
                If rbcont1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?int_con", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?int_con", "NO")
                End If
                '***************************************************************
                myCommand.Parameters.AddWithValue("?cta_caja", txt_cta_caja.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_banco", txt_cta_banco.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_cpp", txt_cta_cpp.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_gas", txt_cta_gas.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_com", txt_cta_com.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_desc", txt_cta_desc.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_inv", txt_cta_inv.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_iva_g", txt_cta_iva_g.Text.ToString)
                myCommand.Parameters.AddWithValue("?por_iva_g", DIN(txt_por_iva_g.Text))
                myCommand.Parameters.AddWithValue("?cta_iva_d", txt_cta_iva_d.Text.ToString)
                myCommand.Parameters.AddWithValue("?por_iva_d", DIN(txt_por_iva_d.Text))
                myCommand.Parameters.AddWithValue("?cta_rtf", txt_cta_rtf.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_fle", txt_cta_fle.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_seg", txt_cta_seg.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_ppf_c", txt_cta_ppf_c.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_ppf_d", txt_cta_ppf_d.Text.ToString)
                '***********************************************************
                If rb_sol_num1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?sol_num_com", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?sol_num_com", "NO")
                End If
                If rb_cant_fact2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?can_fact", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?can_fact", "NO")
                End If
                If rb_fs1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?fs_aum_inv", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?fs_aum_inv", "NO")
                End If
                If rb_imp_ap2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?imp_ap", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?imp_ap", "NO")
                End If
                '************* FORMATO FP *********************************************
                If pdffp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_fp", "pdf")
                    myCommand.Parameters.AddWithValue("?logo_fp", data)
                ElseIf pdf2fp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_fp", "pdf2")
                    myCommand.Parameters.AddWithValue("?logo_fp", data)
                Else
                    myCommand.Parameters.AddWithValue("?format_fp", "ticket")
                    myCommand.Parameters.AddWithValue("?logo_fp", "")
                End If
                '************* FORMATO CPP *********************************************
                If pdfcpp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_cpp", "pdf")
                    myCommand.Parameters.AddWithValue("?logo_cpp", data2)
                ElseIf pdf2cpp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_cpp", "pdf2")
                    myCommand.Parameters.AddWithValue("?logo_cpp", data2)
                Else
                    myCommand.Parameters.AddWithValue("?format_cpp", "ticket")
                    myCommand.Parameters.AddWithValue("?logo_cpp", "")
                End If
                '************* FORMATO PPF *********************************************
                If pdfppf.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_ppf", "pdf")
                    myCommand.Parameters.AddWithValue("?logo_ppf", data3)
                ElseIf pdf2ppf.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_ppf", "pdf2")
                    myCommand.Parameters.AddWithValue("?logo_ppf", data3)
                Else
                    myCommand.Parameters.AddWithValue("?format_ppf", "ticket")
                    myCommand.Parameters.AddWithValue("?logo_ppf", "")
                End If
                '************************************************************************
                myCommand.Parameters.AddWithValue("?comentario", txtcomentario.Text.ToString)
                If rb_decS.Checked = True Then
                    myCommand.Parameters.AddWithValue("?decmal", "S")
                Else
                    myCommand.Parameters.AddWithValue("?decmal", "N")
                End If
                '*********************************************************
                myCommand.CommandText = "INSERT INTO par_comp VALUES(?doc_fp,?doc_aj,?doc_cpp,?doc_gas,?doc_ppf,?int_con, " _
                                      & " ?cta_caja,?cta_banco,?cta_cpp,?cta_gas,?cta_com,?cta_desc,?cta_inv,?cta_iva_g,?por_iva_g,  " _
                                      & " ?cta_iva_d,?por_iva_d,?cta_rtf,?cta_fle,?cta_seg,?cta_ppf_c,?cta_ppf_d, " _
                                      & " ?sol_num_com,?can_fact,?fs_aum_inv,?imp_ap, " _
                                      & " ?format_fp,?logo_fp,?format_cpp,?logo_cpp,?format_ppf,?logo_ppf,?comentario,?decmal);"
                myCommand.ExecuteNonQuery()
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub Modificar()
        MiConexion(bda)
        Try

            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los parametros de compras se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
            If resultado = MsgBoxResult.Yes Then
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc_fp", txt_fp.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_aj", txt_aj.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_cpp", txt_cpp.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_gas", txt_gas.Text.ToString)
                myCommand.Parameters.AddWithValue("?doc_ppf", txt_ppf.Text.ToString)
                '****************************************************************
                If rbcont1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?int_con", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?int_con", "NO")
                End If
                '***************************************************************
                myCommand.Parameters.AddWithValue("?cta_caja", txt_cta_caja.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_banco", txt_cta_banco.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_cpp", txt_cta_cpp.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_gas", txt_cta_gas.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_com", txt_cta_com.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_desc", txt_cta_desc.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_inv", txt_cta_inv.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_iva_g", txt_cta_iva_g.Text.ToString)
                myCommand.Parameters.AddWithValue("?por_iva_g", DIN(txt_por_iva_g.Text))
                myCommand.Parameters.AddWithValue("?cta_iva_d", txt_cta_iva_d.Text.ToString)
                myCommand.Parameters.AddWithValue("?por_iva_d", DIN(txt_por_iva_d.Text))
                myCommand.Parameters.AddWithValue("?cta_rtf", txt_cta_rtf.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_fle", txt_cta_fle.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_seg", txt_cta_seg.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_ppf_c", txt_cta_ppf_c.Text.ToString)
                myCommand.Parameters.AddWithValue("?cta_ppf_d", txt_cta_ppf_d.Text.ToString)
                '***********************************************************
                If rb_sol_num1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?sol_num_com", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?sol_num_com", "NO")
                End If
                If rb_cant_fact2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?can_fact", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?can_fact", "NO")
                End If
                If rb_fs1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?fs_aum_inv", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?fs_aum_inv", "NO")
                End If
                If rb_imp_ap2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?imp_ap", "SI")
                Else
                    myCommand.Parameters.AddWithValue("?imp_ap", "NO")
                End If
                '************* FORMATO FP *********************************************
                If pdffp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_fp", "pdf")
                    'myCommand.Parameters.AddWithValue("?logo_fp", data)
                ElseIf pdf2fp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_fp", "pdf2")
                Else
                    myCommand.Parameters.AddWithValue("?format_fp", "ticket")
                End If
                '************* FORMATO CPP *********************************************
                If pdfcpp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_cpp", "pdf")
                    'myCommand.Parameters.AddWithValue("?logo_cpp", data2)
                ElseIf pdf2cpp.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_cpp", "pdf2")
                Else
                    myCommand.Parameters.AddWithValue("?format_cpp", "ticket")
                End If
                '************* FORMATO PPF *********************************************
                If pdfppf.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_ppf", "pdf")
                    'myCommand.Parameters.AddWithValue("?logo_ppf", data3)
                ElseIf pdf2ppf.Checked = True Then
                    myCommand.Parameters.AddWithValue("?format_ppf", "pdf2")
                Else
                    myCommand.Parameters.AddWithValue("?format_ppf", "ticket")
                End If
                '************************************************************************
                myCommand.Parameters.AddWithValue("?comentario", txtcomentario.Text.ToString)
                '*********************************************************
                If rb_decS.Checked = True Then
                    myCommand.Parameters.AddWithValue("?deci", "S")
                Else
                    myCommand.Parameters.AddWithValue("?deci", "N")
                End If

                myCommand.CommandText = "UPDATE par_comp SET doc_fp=?doc_fp,doc_aj=?doc_aj,doc_cpp=?doc_cpp,doc_gas=?doc_gas,doc_ppf=?doc_ppf,int_con=?int_con, " _
                                     & " cta_caja=?cta_caja,cta_banco=?cta_banco,cta_cpp=?cta_cpp,cta_gas=?cta_gas,cta_com=?cta_com,cta_desc=?cta_desc,cta_inv=?cta_inv,cta_iva_g=?cta_iva_g,por_iva_g=?por_iva_g,  " _
                                     & " cta_iva_d=?cta_iva_d,por_iva_d=?por_iva_d,cta_rtf=?cta_rtf,cta_fle=?cta_fle,cta_seg=?cta_seg,cta_ppf_c=?cta_ppf_c,cta_ppf_d=?cta_ppf_d, " _
                                     & " sol_num_com=?sol_num_com,can_fact=?can_fact,fs_aum_inv=?fs_aum_inv,imp_ap=?imp_ap, " _
                                     & " format_fp=?format_fp,format_cpp=?format_cpp,format_ppf=?format_ppf,comentario=?comentario,deci=?deci"
                myCommand.ExecuteNonQuery()
                If hayfoto = 1 Then
                    ModificarPDF("logo_fp")
                End If
                If hayfoto2 = 1 Then
                    ModificarPDF("logo_cpp")
                End If
                If hayfoto3 = 1 Then
                    ModificarPDF("logo_ppf")
                End If
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub ModificarPDF(ByVal campo As String)
        Try
            myCommand.Parameters.Clear()
            If campo = "logo_fp" Then
                myCommand.Parameters.AddWithValue("?logo", data)
            ElseIf campo = "logo_ccp" Then
                myCommand.Parameters.AddWithValue("?logo", data2)
            Else
                myCommand.Parameters.AddWithValue("?logo", data3)
            End If
            myCommand.CommandText = "UPDATE par_comp SET " & campo & "=?logo;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No se pudo guardar la imagen, Error: " & ex.ToString, MsgBoxStyle.Critical, "Control")
        End Try
    End Sub
    '******** EXAMINAR LOGOS ******************
    Private Sub cmdlogofp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogofp.Click
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
    Private Sub cmdlogoccp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogoccp.Click
        Try
            Me.OPF2.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF2.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF2.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data2(ios.Length) 'llenamos el arreglo
                ios.Read(data2, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto2.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto2.Load(Me.OPF2.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data2 'llenamos la variable parametro con el arreglo
                hayfoto2 = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub cmdlogoppf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogoppf.Click
        Try
            Me.OPF3.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF3.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF3.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data3(ios.Length) 'llenamos el arreglo
                ios.Read(data3, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto3.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto3.Load(Me.OPF3.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data3 'llenamos la variable parametro con el arreglo
                hayfoto3 = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub imgfoto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgfoto.DoubleClick
        cmdlogofp_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub imgfoto2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgfoto2.DoubleClick
        cmdlogoccp_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub imgfoto3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgfoto3.DoubleClick
        cmdlogoppf_Click(AcceptButton, AcceptButton)
    End Sub
    '********** HABILITAR EXAMINAR FP ***********
    Private Sub pdffp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdffp.CheckedChanged
        cmdlogofp.Enabled = True
        imgfoto.Enabled = True
    End Sub
    Private Sub pdf2fp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf2fp.CheckedChanged
        cmdlogofp.Enabled = True
        imgfoto.Enabled = True
    End Sub
    Private Sub ticfp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticfp.CheckedChanged
        cmdlogofp.Enabled = False
        imgfoto.Enabled = False
    End Sub
    '********** HABILITAR EXAMINAR CPP ***********
    Private Sub pdfcpp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdfcpp.CheckedChanged
        cmdlogoccp.Enabled = True
        imgfoto2.Enabled = True
    End Sub
    Private Sub pdf2cpp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf2cpp.CheckedChanged
        cmdlogoccp.Enabled = True
        imgfoto2.Enabled = True
    End Sub
    Private Sub ticcpp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticcpp.CheckedChanged
        cmdlogoccp.Enabled = False
        imgfoto2.Enabled = False
    End Sub
    '********** HABILITAR EXAMINAR PPF ***********
    Private Sub pdfppf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdfppf.CheckedChanged
        cmdlogoppf.Enabled = True
        imgfoto3.Enabled = True
    End Sub
    Private Sub pdf2ppf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdf2ppf.CheckedChanged
        cmdlogoppf.Enabled = True
        imgfoto3.Enabled = True
    End Sub
    Private Sub ticppf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticppf.CheckedChanged
        cmdlogoppf.Enabled = False
        imgfoto3.Enabled = False
    End Sub
    '********** VISTA PRELIMINAR *****************
    Private Sub cmd_vp_fp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_fp.Click
        If pdffp.Checked = True Then
            GenerarPDF("fp")
        ElseIf pdf2fp.Checked = True Then
            GenerarPDF2("fp")
        Else
            GenerarTicket("fp")
        End If
    End Sub
    Private Sub cmd_vp_cpp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_cpp.Click
        If pdfcpp.Checked = True Then
            GenerarPDF("cpp")
        ElseIf pdf2cpp.Checked = True Then
            GenerarPDF2("cpp")
        Else
            GenerarTicket("cpp")
        End If
    End Sub
    Private Sub cmd_vp_ppf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_ppf.Click
        If pdfppf.Checked = True Then
            GenerarPDF("ppf")
        ElseIf pdf2ppf.Checked = True Then
            GenerarPDF2("ppf")
        Else
            GenerarTicket("ppf")
        End If
    End Sub
    '*********** REPORTES ***********************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    '////////// GENERAR PDF ///////////////////////
    Public Sub GenerarPDF(ByVal campo As String)

    End Sub
    Public Sub GenerarPDF2(ByVal campo As String)

    End Sub
    Public Sub GenerarTicket(ByVal campo As String)

    End Sub
End Class