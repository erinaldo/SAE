Public Class FrmAumentarPrecios

    Private Sub FrmAumentarPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lba.Text = ""
        If FrmPrincipal.Inventarios.Enabled = False Then
            rb2.Checked = True
            rb1.Enabled = False
            lb1.Text = ""
        Else
            rb1.Checked = True
            rb1.Enabled = True
            lb1.Text = "(Los precios seran modificados desde el periodo " & PerActual & ")"
        End If
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT numlist FROM listasprec ORDER BY numlist;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            cblista.Items.Clear()
            For i = 0 To items - 1
                cblista.Items.Add(tabla.Rows(i).Item(0))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cblista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblista.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nomlist FROM listasprec WHERE  numlist='" & Trim(cblista.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtlista.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
            txtlista.Text = ""
        End Try
    End Sub
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtcod1.Enabled = False
            txtcod2.Enabled = False
            txtcod.Enabled = False
        End If
    End Sub
    Private Sub a1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a1.CheckedChanged
        If a1.Checked = True Then
            txtmonto.Enabled = True
            txtporcentaje.Enabled = False
            txtprecio.Enabled = False
            txtUtilidad.Enabled = False
        End If
    End Sub
    '******************* VALIDACIONES *****************************
    Private Sub txtcod1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcod1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod1.LostFocus

    End Sub
    '**************************************************************
    Private Sub txtcod2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcod2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod2.LostFocus

    End Sub
    Public Sub BuscarCod(ByVal txt As String)
        If rb1.Checked = True Then '******** BUSCAR ARTICULO ****************

        Else '******** BUSCAR SERVICIO ****************

        End If
    End Sub
    '*********************************************************
    Private Sub txtmonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        ValidarMoneda(txtmonto, e)
    End Sub
    Private Sub txtmonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto.LostFocus
        txtmonto.Text = Moneda(txtmonto.Text)
    End Sub
    '***************************************
    Private Sub txtporcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtporcentaje.KeyPress
        ValidarPorcentaje(txtporcentaje, e)
    End Sub
    Private Sub txtporcentaje_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtporcentaje.LostFocus
        txtporcentaje.Text = Moneda(txtporcentaje.Text)
    End Sub
    Private Sub rbl1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbl1.CheckedChanged
        If rbl1.Checked = True Then
            cblista.Enabled = False
        Else
            cblista.Enabled = True
        End If
    End Sub
    '***********************************
    Private Sub cmdguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click
        If validar() = True Then
            If rb1.Checked = True Then
                Articulos()
            Else
                Servicios()
            End If
        End If
    End Sub
    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub
    '*********************
    Function validar()
        If rbl2.Checked = True And Trim(txtlista.Text = "") Then
            MsgBox("Favor verifique la lista de precio.  ", MsgBoxStyle.Information, "SAE Control")
            cblista.Focus()
            Return False
            Exit Function
        End If
        If c2.Checked = True Then
            If Trim(txtnom1.Text) = "" Or Trim(txtnom2.Text) = "" Then
                MsgBox("Favor verifique los rango de los codigos.  ", MsgBoxStyle.Information, "SAE Control")
                txtcod1.Focus()
                Return False
                Exit Function
            End If
        End If
        If c3.Checked = True Then
            If Trim(txtcod.Text) = "" Or Trim(txtnom.Text) = "" Then
                MsgBox("Favor verifique el codigo.  ", MsgBoxStyle.Information, "SAE Control")
                txtcod.Focus()
                Return False
                Exit Function
            End If
            If lbnivel.Text <> "Articulo" Then
                MsgBox("Favor verifique, solo puede seleecionnar codigo de un articulo(nivel).  ", MsgBoxStyle.Information, "SAE Control")
                txtcod.Focus()
                Return False
                Exit Function
            End If
        End If
        If a1.Checked = True And CDbl(txtmonto.Text) <= 0 Then
            MsgBox("Favor verifique el valor del monto.  ", MsgBoxStyle.Information, "SAE Control")
            txtmonto.Focus()
            Return False
            Exit Function
        End If
        If a2.Checked = True And CDbl(txtporcentaje.Text) <= 0 Then
            MsgBox("Favor verifique el valor del porcentaje.  ", MsgBoxStyle.Information, "SAE Control")
            txtporcentaje.Focus()
            Return False
            Exit Function
        End If
        If a3.Checked = True And CDbl(txtprecio.Text) <= 0 Then
            MsgBox("Favor verifique el valor del precio.  ", MsgBoxStyle.Information, "SAE Control")
            txtprecio.Focus()
            Return False
            Exit Function
        End If
        If a4.Checked = True And CDbl(txtUtilidad.Text) <= 0 Then
            MsgBox("Favor verifique el monto de la utilidad.  ", MsgBoxStyle.Information, "SAE Control")
            txtUtilidad.Focus()
            Return False
            Exit Function
        End If
        '*******************************
        Return True
    End Function
    '*********************
    Public Sub Articulos()
        MiConexion(bda)
        '***************************
        Dim s As String 'aumentar o disminuir
        If rbmod1.Checked = True Then
            s = " + "
        Else
            s = " - "
        End If
        '***********************************************************
        Dim d As Integer  'cantida de decimales
        If p1.Checked = True Then 'con dos decimales
            d = 2
        Else
            d = 0
        End If
        Dim sql As String = "UPDATE con_inv SET "
        Dim sql2 As String = "UPDATE articulos SET "
        Try
            If rbl1.Checked = True Then 'TODAS LAS LISTAS DE PRECIOS
                Dim items As Integer
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT numlist FROM listasprec ORDER BY numlist;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                Dim p As String = ""
                Dim pb As String = ""
                For i = 0 To items - 1
                    p = "precio" & tabla.Rows(i).Item(0)
                    If ChBase.Checked = True Then
                        pb = "precio1"
                    Else
                        pb = "precio" & tabla.Rows(i).Item(0)
                    End If
                    If a1.Checked = True Then 'MONTO
                        sql = sql & p & " = ROUND(" & pb & s & DIN(txtmonto.Text) & "," & d & ")"
                        If i = 0 Then sql2 = sql2 & "precio = ROUND(precio " & s & DIN(txtmonto.Text) & "," & d & ")"
                    ElseIf a2.Checked = True Then   'PORCENTAJE
                        sql = sql & p & " = ROUND(" & pb & s & "(" & pb & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                        If i = 0 Then sql2 = sql2 & "precio = ROUND(precio " & s & "(precio " & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                    ElseIf a3.Checked = True Then 'precio fijo
                        sql = sql & p & " = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                        If i = 0 Then sql2 = sql2 & "precio = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                    Else
                        sql = sql & p & " = ROUND(costuni * (1 + (" & DIN(txtUtilidad.Text) & "/100))," & d & ")"
                        If i = 0 Then sql2 = sql2 & "precio = ROUND(cos_uni * ( 1 + (" & DIN(txtUtilidad.Text) & "/100))," & d & ")"
                    End If
                    If i < items - 1 Then
                        sql = sql & ", "
                    End If
                Next
            Else 'UNA LISTA DE PRECIOS
                Dim p As String = ""
                Dim pb As String = ""
                p = "precio" & cblista.Text
                If ChBase.Checked = True Then
                    pb = "precio1"
                Else
                    pb = "precio" & cblista.Text
                End If
                If a1.Checked = True Then 'MONTO
                    sql = sql & p & " = ROUND(" & pb & s & DIN(txtmonto.Text) & "," & d & ")"
                    sql2 = sql2 & "precio = ROUND(precio " & s & DIN(txtmonto.Text) & "," & d & ")"
                ElseIf a2.Checked = True Then   'PORCENTAJE
                    sql = sql & p & " = ROUND(" & pb & s & "(" & pb & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                    sql2 = sql2 & "precio = ROUND(precio " & s & "(precio " & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                ElseIf a3.Checked = True Then
                    sql = sql & p & " = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                    sql2 = sql2 & "precio = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                Else
                    sql = sql & p & " = ROUND(costuni * (1 + (" & DIN(txtUtilidad.Text) & "/100))," & d & ")"
                    sql2 = sql2 & "precio = ROUND(cos_uni * ( 1 + (" & DIN(txtUtilidad.Text) & "/100))," & d & ")"
                End If
            End If
            If c1.Checked = True Then
                sql = sql & " WHERE periodo>='" & PerActual(0) & PerActual(1) & "';"
                sql2 = sql2 & " WHERE nivel='Articulo';"
            ElseIf c2.Checked = True Then
                sql = sql & " WHERE periodo>='" & PerActual(0) & PerActual(1) & "' AND codart>='" & txtcod1.Text & "' AND codart<='" & txtcod2.Text & "';"
                sql2 = sql2 & " WHERE codart>='" & txtcod1.Text & "' AND codart<='" & txtcod2.Text & "' AND nivel='Articulo';"
            Else
                sql = sql & " WHERE periodo>='" & PerActual(0) & PerActual(1) & "' AND codart='" & txtcod.Text & "';"
                sql2 = sql2 & " WHERE codart='" & txtcod.Text & "';"
            End If
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la(s) lista(s) de articulos se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                lba.Text = "Modificando Lista de Precios de Articulos Favor Espere..."
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                If rbl1.Checked = True Then
                    Try
                        myCommand.CommandText = sql2
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(sql2)
                    End Try
                Else
                    If cblista.Text = 1 Then
                        Try
                            myCommand.CommandText = sql2
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(sql2)
                        End Try
                    End If
                End If
                lba.Text = ""
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "MODIFICAR PRECIOS DE ARTICULOS ", "", "", "")
                End If
                '.....
            End If
            lba.Text = ""
        Catch ex As Exception
            MsgBox(sql)
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    '*********************
    Public Sub Servicios()
        MiConexion(bda)
        '***************************
        Dim s As String 'aumentar o disminuir
        If rbmod1.Checked = True Then
            s = " + "
        Else
            s = " - "
        End If
        '***********************************************************
        Dim d As Integer  'cantida de decimales
        If p1.Checked = True Then 'con dos decimales
            d = 2
        Else
            d = 0
        End If
        Try
            Dim sql As String = "UPDATE servicios SET "
            If rbl1.Checked = True Then 'TODAS LAS LISTAS DE PRECIOS
                Dim items As Integer
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT numlist FROM listasprec ORDER BY numlist;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                Dim p As String = ""
                Dim pb As String = ""
                For i = 0 To items - 1
                    If i = 0 Then
                        p = "pventa"
                    Else
                        p = "pventa" & tabla.Rows(i).Item(0)
                    End If
                    If ChBase.Checked = True Then
                        pb = "pventa"
                    Else
                        pb = p
                    End If
                    If a1.Checked = True Then 'MONTO
                        sql = sql & p & " = ROUND(" & pb & s & DIN(txtmonto.Text) & "," & d & ")"
                    ElseIf a2.Checked = True Then   'PORCENTAJE
                        sql = sql & p & " = ROUND(" & pb & s & "(" & pb & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                    Else
                        sql = sql & p & " = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                    End If
                    If i < items - 1 Then
                        sql = sql & ", "
                    End If
                Next
            Else 'UNA LISTA DE PRECIOS
                Dim p As String = ""
                Dim pb As String = ""
                If cblista.Text = "1" Then
                    p = "pventa"
                Else
                    p = "pventa" & cblista.Text
                End If
                If ChBase.Checked = True Then
                    pb = "pventa"
                Else
                    pb = p
                End If
                If a1.Checked = True Then 'MONTO
                    sql = sql & p & " = ROUND(" & pb & s & DIN(txtmonto.Text) & "," & d & ")"
                ElseIf a2.Checked = True Then   'PORCENTAJE
                    sql = sql & p & " = ROUND(" & pb & s & "(" & pb & "*" & DIN(txtporcentaje.Text) & "/100)," & d & ")"
                Else
                    sql = sql & p & " = ROUND(" & DIN(txtprecio.Text) & "," & d & ")"
                End If
            End If
            If c1.Checked = True Then
                sql = sql & ";"
            ElseIf c2.Checked = True Then
                sql = sql & " WHERE codser>='" & txtcod1.Text & "' AND codser<='" & txtcod2.Text & "';"
            Else
                sql = sql & " WHERE codser='" & txtcod.Text & "';"
            End If
            'MsgBox(sql)
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los datos de la(s) lista(s) de servicios se van ha modifcar, ¿Desea Guardarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                lba.Text = "Modificando Lista de Precios de Servicios Favor Espere..."
                myCommand.CommandText = sql
                myCommand.ExecuteNonQuery()
                lba.Text = ""
                MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
                myCommand.Parameters.Clear()
                Refresh()
                '.....
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("FACTURACION", "MODIFICAR PRECIOS DE SERVICIOS", "", "", "")
                End If
                '.....
            End If
            lba.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Cerrar()
    End Sub
    '*********************

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcod.Enabled = False
            txtcod1.Enabled = True
            txtcod2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.CheckedChanged
        If c3.Checked = True Then
            txtcod1.Enabled = False
            txtcod2.Enabled = False
            txtcod.Enabled = True
            a3.Enabled = True
        Else
            a3.Enabled = False
        End If
    End Sub

    Private Sub txtcod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcod.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcod.LostFocus
        If Trim(txtnom.Text) = "" Or Trim(lbnivel.Text) <> "Articulo" Or Trim(txtcod.Text) = "" Then
            If rb1.Checked = True Then 'inventario
                FrmArti_de_Inventarios.lbform.Text = "lista_precio"
                FrmArti_de_Inventarios.txtcuenta.Text = txtcod.Text
                FrmArti_de_Inventarios.ShowDialog()
            Else 'servicio

            End If
        End If
    End Sub
    Private Sub txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcod.TextChanged
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            If rb1.Checked = True Then
                myCommand.CommandText = "SELECT nomart,nivel,iva,precio as p FROM articulos WHERE codart='" + txtcod.Text + "';"
            Else
                myCommand.CommandText = "SELECT nombre,concat('Articulo') as nivel,iva,pventa as p FROM servicios WHERE codser='" + txtcod.Text + "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtnom.Text = ""
                lbnivel.Text = ""
            Else
                txtnom.Text = tabla.Rows(0).Item(0).ToString
                lbnivel.Text = tabla.Rows(0).Item(1).ToString
                lbiva.Text = Moneda(tabla.Rows(0).Item("iva").ToString)
                lbprecio.Text = Moneda(tabla.Rows(0).Item("p").ToString)
            End If
        Catch ex As Exception
            txtnom.Text = ""
            lbnivel.Text = ""
        End Try
    End Sub

    Private Sub txtcod1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcod1.TextChanged
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            If rb1.Checked = True Then
                myCommand.CommandText = "SELECT nomart FROM articulos WHERE codart='" + txtcod1.Text + "';"
            Else
                myCommand.CommandText = "SELECT nombre FROM servicios WHERE codser='" + txtcod1.Text + "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtnom1.Text = ""
            Else
                txtnom1.Text = tabla.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            txtnom1.Text = ""
        End Try
    End Sub
    Private Sub txtcod2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcod2.TextChanged
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            If rb1.Checked = True Then
                myCommand.CommandText = "SELECT nomart FROM articulos WHERE codart='" + txtcod2.Text + "';"
            Else
                myCommand.CommandText = "SELECT nombre FROM servicios WHERE codser='" + txtcod2.Text + "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                txtnom2.Text = ""
            Else
                txtnom2.Text = tabla.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            txtnom2.Text = ""
        End Try
    End Sub
    '****************************************************************

    Private Sub a2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.CheckedChanged
        If a2.Checked = True Then
            txtmonto.Enabled = False
            txtporcentaje.Enabled = True
            txtprecio.Enabled = False
            txtUtilidad.Enabled = False
        End If
    End Sub

    Private Sub a3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a3.CheckedChanged
        If a3.Checked = True Then
            txtmonto.Enabled = False
            txtporcentaje.Enabled = False
            txtprecio.Enabled = True
            txtUtilidad.Enabled = False
        End If
    End Sub

    Private Sub txtprecio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprecio.GotFocus
        Try
            If a3.Text = "Precio (Sin IVA)" Then
                FrmPrecioItems.lbform.Text = "lista_precio"
                FrmPrecioItems.txt2.Text = lbprecio.Text
            Else
                FrmPrecioItems.lbform.Text = "lista_precio2"
                FrmPrecioItems.txt1.Text = lbprecio.Text
            End If
            FrmPrecioItems.lbiva.Text = lbiva.Text
            FrmPrecioItems.ShowDialog()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub txtprecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtprecio.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then Exit Sub
            e.Handled = True
            If a3.Text = "Precio (Sin IVA)" Then
                FrmPrecioItems.lbform.Text = "lista_precio"
                FrmPrecioItems.txt2.Text = lbprecio.Text
            Else
                FrmPrecioItems.lbform.Text = "lista_precio2"
                FrmPrecioItems.txt1.Text = lbprecio.Text
            End If
            FrmPrecioItems.lbiva.Text = lbiva.Text
            FrmPrecioItems.ShowDialog()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub txtprecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        ValidarMoneda(txtprecio, e)
    End Sub
    Private Sub txtprecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprecio.LostFocus
        txtprecio.Text = Moneda(txtprecio.Text)
    End Sub

    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            a3.Text = "Precio (Sin IVA)"
            a4.Enabled = True
        Else
            a3.Text = "Precio (Con IVA)"
            If a4.Checked = True Then
                a1.Checked = True
            End If
            a4.Enabled = False
        End If

    End Sub

    Private Sub txtprecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprecio.TextChanged

    End Sub

    Private Sub cmditem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditem.Click
        MiConexion(bda)
        Cerrar()
        BuscarPeriodo()
        FrmModPreciosManual.ShowDialog()
    End Sub

    Private Sub txtUtilidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilidad.KeyPress
        ValidarMoneda(txtUtilidad, e)
    End Sub

    Private Sub txtUtilidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUtilidad.LostFocus
        txtUtilidad.Text = Moneda(txtUtilidad.Text)
    End Sub

    
    Private Sub a4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a4.CheckedChanged
        If a4.Checked = True Then
            txtmonto.Enabled = False
            txtporcentaje.Enabled = False
            txtprecio.Enabled = False
            txtUtilidad.Enabled = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class