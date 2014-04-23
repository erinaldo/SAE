Public Class Frmestadisticaedades

    Private Sub rdbcliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbcliente.CheckedChanged

    End Sub

    Private Sub rdbcliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbcliente.Click
        txtnit.Enabled = True
        txtnit.Focus()
    End Sub

    Private Sub txtnit_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtnit_LostFocus1(AcceptButton, AcceptButton)
        Else
            validarnumero(txtnit, e)
        End If
    End Sub

    Private Sub txtnit_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnit.Text = "" Then
            txtcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnit.Text)
        End If
    End Sub


    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = Trim(tabla2.Rows(i).Item("apellidos") & " " & tabla2.Rows(i).Item("nombre"))
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "fc_estad"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            txtcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.lbform.Text = "fc_estad"
                frmterceros.txtnit.Text = txtnit.Text
                frmterceros.lbestado.Text = "NUEVO"
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtnit.Focus()
            End If
        Else  'mostrar uno solo q coinside
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub

    Private Sub rdbsector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbsector.Click
        txttitulo.Visible = True
        'grafica.Visible = True
        If rdbcliente.Checked = True Then
            Generar_graficas_pie_individual()
        Else
            Generar_graficas_pie()
        End If

    End Sub

    Private Sub rdbbarras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbbarras.Click
        txttitulo.Visible = True
        'grafica.Visible = True
        If rdbcliente.Checked = True Then
            Generar_graficas_barras_individual()
        Else
            Generar_graficas_barras()
        End If

    End Sub

    Sub Generar_graficas_pie_individual()
        Dim items1 As Integer
        Dim num_reg As Integer
        Dim totalcar, total1, total2, total3, total4 As Double
        Dim venc1, venc2, venc3, venc4 As Integer
        Dim f1, f2 As String

        f1 = (txtfecha1.Value.ToString("yyyy-MM-dd"))
        f2 = (txtfecha2.Value.ToString("yyyy-MM-dd"))
        Try
            items1 = -1
            '************Vencimientos**************
            venc1 = Val(txtdias.Text)
            venc2 = venc1 + Val(txtdias.Text)
            venc3 = venc2 + Val(txtdias.Text)
            venc4 = venc3 + Val(txtdias.Text)

            '********* Totalizar Cartera 

            Dim tabla As New DataTable
            Dim recibe As New Object
           
            ' Filtro de Fecha si Existe.----

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If



            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            num_reg = tabla.Rows.Count
            recibe = tabla.Rows(0).Item(0)


            If num_reg = 0 Then
                total1 = 0
            Else
                total1 = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try


            Dim tabla2 As New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and nitc ='" & Trim(txtnit.Text) & "'and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If


            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()

            items1 = tabla2.Rows.Count

            If items1 <= 0 Then
                total2 = 0
            Else
                total2 = tabla2.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 

        Try


            Dim tabla3 As New DataTable



            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If



            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            Refresh()
            items1 = tabla3.Rows.Count

            If items1 <= 0 Then
                total3 = 0
            Else
                total3 = tabla3.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 
        Try



            Dim tabla4 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha>='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If



            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)
            Refresh()
            items1 = tabla4.Rows.Count

            If items1 <= 0 Then
                total4 = 0
            Else
                total4 = tabla4.Rows(0).Item(0)
            End If
            '**********************************
            'MsgBox(total1)
            ' MsgBox(total2)
            'MsgBox(total3)
            'MsgBox(total4)

        Catch ex As Exception
            '
        End Try

        totalcar = total1 + total2 + total3 + total4
        'MsgBox(totalcar)
        'MsgBox()
        '**************** Generar Grafica ******************

        Dim chartParameters As String
        chartParameters = "caption=Cartera Estadistica Por Edades;xAxisName=Dias;yAxisName=Valores;numberPrefix=$"
        'Sets charts parameters
        'grafica.ChartType = FusionChartsForVB.enumChartNames.pie3d
        'grafica.Data.setChartParams(chartParameters)
        'grafica.Data.addChartData(Str(total1), "label='" & Str(venc1) & "'")
        'grafica.Data.addChartData(Str(total2), "label='" & Str(venc2) & "'")
        'grafica.Data.addChartData(Str(total3), "label='" & Str(venc3) & "'")
        'grafica.Data.addChartData(Str(total4), "label='" & Str(venc4) & "'")
        'grafica.Data.addChartData("28000", "", "color=ff000f")

        'grafica.Data.addChartData("29000", "label=May")
        'grafica.Data.addChartData("27000", "label=Jun")
        'grafica.Data.addTrendLine("startValue=22000;color=cc00cc;displayValue=Average")
        'grafica.Data.defineStyle("CanvasAnim", "animation", "param=_xScale;start=0;duration=1")
        'grafica.Data.applyStyle("DataPlot", "CanvasAnim")
        '' Renders the chart
        'grafica.RenderChart()
    End Sub

    Sub Generar_graficas_pie()
        Dim items1 As Integer
        Dim num_reg As Integer
        Dim totalcar, total1, total2, total3, total4 As Double
        Dim venc1, venc2, venc3, venc4 As Integer
        Dim f1, f2 As String

        f1 = (txtfecha1.Value.ToString("yyyy-MM-dd"))
        f2 = (txtfecha2.Value.ToString("yyyy-MM-dd"))

        Try


            items1 = -1
            '************Vencimientos**************
            venc1 = Val(txtdias.Text)
            venc2 = venc1 + Val(txtdias.Text)
            venc3 = venc2 + Val(txtdias.Text)
            venc4 = venc3 + Val(txtdias.Text)

            '********* Totalizar Cartera 
            Dim tabla As New DataTable
            Dim recibe As New Object
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            num_reg = tabla.Rows.Count
            recibe = tabla.Rows(0).Item(0)


            If num_reg = 0 Then
                total1 = 0
            Else
                total1 = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try


            Dim tabla2 As New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()

            items1 = tabla2.Rows.Count

            If items1 <= 0 Then
                total2 = 0
            Else
                total2 = tabla2.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 

        Try


            Dim tabla3 As New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            Refresh()
            items1 = tabla3.Rows.Count

            If items1 <= 0 Then
                total3 = 0
            Else
                total3 = tabla3.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 
        Try



            Dim tabla4 As New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "';"
            End If
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)
            Refresh()
            items1 = tabla4.Rows.Count

            If items1 <= 0 Then
                total4 = 0
            Else
                total4 = tabla4.Rows(0).Item(0)
            End If
            '**********************************
            'MsgBox(total1)
            ' MsgBox(total2)
            'MsgBox(total3)
            'MsgBox(total4)

        Catch ex As Exception
            '
        End Try

        totalcar = total1 + total2 + total3 + total4
        'MsgBox(totalcar)
        'MsgBox()
        '**************** Generar Grafica ******************

        Dim chartParameters As String
        chartParameters = "caption=Cartera Estadistica Por Edades;xAxisName=Dias;yAxisName=Valores;numberPrefix=$"
        'Sets charts parameters
        'grafica.ChartType = FusionChartsForVB.enumChartNames.pie3d
        'grafica.Data.setChartParams(chartParameters)
        'grafica.Data.addChartData(Str(total1), "label='" & Str(venc1) & "'")
        'grafica.Data.addChartData(Str(total2), "label='" & Str(venc2) & "'")
        'grafica.Data.addChartData(Str(total3), "label='" & Str(venc3) & "'")
        'grafica.Data.addChartData(Str(total4), "label='" & Str(venc4) & "'")
        ''grafica.Data.addChartData("28000", "", "color=ff000f")

        ''grafica.Data.addChartData("29000", "label=May")
        ''grafica.Data.addChartData("27000", "label=Jun")
        'grafica.Data.addTrendLine("startValue=22000;color=cc00cc;displayValue=Average")
        'grafica.Data.defineStyle("CanvasAnim", "animation", "param=_xScale;start=0;duration=1")
        'grafica.Data.applyStyle("DataPlot", "CanvasAnim")
        '' Renders the chart
        'grafica.RenderChart()
    End Sub

    Sub Generar_graficas_barras_individual()
        Dim items1 As Integer
        Dim num_reg As Integer
        Dim totalcar, total1, total2, total3, total4 As Double
        Dim venc1, venc2, venc3, venc4 As Integer

        Dim f1, f2 As String

        f1 = (txtfecha1.Value.ToString("yyyy-MM-dd"))
        f2 = (txtfecha2.Value.ToString("yyyy-MM-dd"))

        Try


            items1 = -1
            '************Vencimientos**************
            venc1 = Val(txtdias.Text)
            venc2 = venc1 + Val(txtdias.Text)
            venc3 = venc2 + Val(txtdias.Text)
            venc4 = venc3 + Val(txtdias.Text)

            '********* Totalizar Cartera 
            Dim tabla As New DataTable
            Dim recibe As New Object

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            num_reg = tabla.Rows.Count
            recibe = tabla.Rows(0).Item(0)


            If num_reg = 0 Then
                total1 = 0
            Else
                total1 = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try


            Dim tabla2 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and nitc ='" & Trim(txtnit.Text) & "'and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()

            items1 = tabla2.Rows.Count

            If items1 <= 0 Then
                total2 = 0
            Else
                total2 = tabla2.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 

        Try


            Dim tabla3 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            Refresh()
            items1 = tabla3.Rows.Count

            If items1 <= 0 Then
                total3 = 0
            Else
                total3 = tabla3.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 
        Try



            Dim tabla4 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnit.Text) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and nitc ='" & Trim(txtnit.Text) & "';"
            End If

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)
            Refresh()
            items1 = tabla4.Rows.Count

            If items1 <= 0 Then
                total4 = 0
            Else
                total4 = tabla4.Rows(0).Item(0)
            End If
            '**********************************
            'MsgBox(total1)
            ' MsgBox(total2)
            'MsgBox(total3)
            'MsgBox(total4)

        Catch ex As Exception
            '
        End Try

        totalcar = total1 + total2 + total3 + total4
        'MsgBox(totalcar)
        'MsgBox()
        '**************** Generar Grafica ******************

        Dim chartParameters As String
        chartParameters = "caption=Cartera Estadistica Por Edades;xAxisName=Dias;yAxisName=Valores;numberPrefix=$"
        'Sets charts parameters
        'grafica.ChartType = FusionChartsForVB.enumChartNames.column3d
        'grafica.Data.setChartParams(chartParameters)
        'grafica.Data.addChartData(Str(total1), "label='" & Str(venc1) & "'")
        'grafica.Data.addChartData(Str(total2), "label='" & Str(venc2) & "'")
        'grafica.Data.addChartData(Str(total3), "label='" & Str(venc3) & "'")
        'grafica.Data.addChartData(Str(total4), "label='" & Str(venc4) & "'")
        ''grafica.Data.addChartData("28000", "", "color=ff000f")

        ''grafica.Data.addChartData("29000", "label=May")
        ''grafica.Data.addChartData("27000", "label=Jun")
        'grafica.Data.addTrendLine("startValue=22000;color=cc00cc;displayValue=Average")
        'grafica.Data.defineStyle("CanvasAnim", "animation", "param=_xScale;start=0;duration=1")
        'grafica.Data.applyStyle("DataPlot", "CanvasAnim")
        '' Renders the chart
        'grafica.RenderChart()
    End Sub

    Public Sub Generar_graficas_barras()
        Dim items1 As Integer
        Dim num_reg As Integer
        Dim totalcar, total1, total2, total3, total4 As Double
        Dim venc1, venc2, venc3, venc4 As Integer
        Dim f1, f2 As String

        f1 = (txtfecha1.Value.ToString("yyyy-MM-dd"))
        f2 = (txtfecha2.Value.ToString("yyyy-MM-dd"))

        Try


            items1 = -1
            '************Vencimientos**************
            venc1 = Val(txtdias.Text)
            venc2 = venc1 + Val(txtdias.Text)
            venc3 = venc2 + Val(txtdias.Text)
            venc4 = venc3 + Val(txtdias.Text)

            '********* Totalizar Cartera 
            Dim tabla As New DataTable
            Dim recibe As New Object

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto <='" & Trim(Str(venc1)) & "';"
            End If



            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            num_reg = tabla.Rows.Count
            recibe = tabla.Rows(0).Item(0)


            If num_reg = 0 Then
                total1 = 0
            Else
                total1 = tabla.Rows(0).Item(0)
            End If
        Catch ex As Exception
            'PonerEnCero()
        End Try

        '**********************************

        '********* Totalizar Cartera 
        Try


            Dim tabla2 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc1)) & "' and vmto <='" & Trim(Str(venc2)) & "';"
            End If


            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()

            items1 = tabla2.Rows.Count

            If items1 <= 0 Then
                total2 = 0
            Else
                total2 = tabla2.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 

        Try


            Dim tabla3 As New DataTable

            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc2)) & "' and vmto <='" & Trim(Str(venc3)) & "';"
            End If



            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)
            Refresh()
            items1 = tabla3.Rows.Count

            If items1 <= 0 Then
                total3 = 0
            Else
                total3 = tabla3.Rows(0).Item(0)
            End If
            '**********************************
        Catch ex As Exception
            '
        End Try
        '********* Totalizar Cartera 
        Try



            Dim tabla4 As New DataTable
            If filtrofecha.Checked Then
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "' and fecha >='" & f2 & "' and fecha <='" & f1 & "';"
            Else
                myCommand.CommandText = "SELECT sum(total) FROM cobdpen where vmto >'" & Trim(Str(venc3)) & "' and vmto <='" & Trim(Str(venc4)) & "';"
            End If


            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla4)
            Refresh()
            items1 = tabla4.Rows.Count

            If items1 <= 0 Then
                total4 = 0
            Else
                total4 = tabla4.Rows(0).Item(0)
            End If
            '**********************************
            'MsgBox(total1)
            ' MsgBox(total2)
            'MsgBox(total3)
            'MsgBox(total4)

        Catch ex As Exception
            '
        End Try

        totalcar = total1 + total2 + total3 + total4
        'MsgBox(totalcar)
        'MsgBox()
        '**************** Generar Grafica ******************

        Dim chartParameters As String
        chartParameters = "caption=Cartera Estadistica Por Edades;xAxisName=Dias;yAxisName=Valores;numberPrefix=$"
        'Sets charts parameters
        'grafica.ChartType = FusionChartsForVB.enumChartNames.column3d
        'grafica.Data.setChartParams(chartParameters)
        'grafica.Data.addChartData(Str(total1), "label='" & Str(venc1) & "'")
        'grafica.Data.addChartData(Str(total2), "label='" & Str(venc2) & "'")
        'grafica.Data.addChartData(Str(total3), "label='" & Str(venc3) & "'")
        'grafica.Data.addChartData(Str(total4), "label='" & Str(venc4) & "'")
        ''grafica.Data.addChartData("28000", "", "color=ff000f")

        ''grafica.Data.addChartData("29000", "label=May")
        ''grafica.Data.addChartData("27000", "label=Jun")
        'grafica.Data.addTrendLine("startValue=22000;color=cc00cc;displayValue=Average")
        'grafica.Data.defineStyle("CanvasAnim", "animation", "param=_xScale;start=0;duration=1")
        'grafica.Data.applyStyle("DataPlot", "CanvasAnim")
        '' Renders the chart
        'grafica.RenderChart()
    End Sub


    Private Sub Frmestadisticaedades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha1.Value = DateTime.Now.ToString("yyyy-MM-dd")
        txtfecha2.Value = DateTime.Now.ToString("yyyy-MM-dd")
        txttitulo.Visible = False
        txtcliente.Text = ""
        txtnit.Text = ""
        rdbtclientes.Focus()
    End Sub

    Private Sub rdbtclientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbtclientes.Click
        txtnit.Enabled = False
    End Sub



    Private Sub rdbsector_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbsector.CheckedChanged

    End Sub

    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged

    End Sub

    Private Sub rdbtclientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtclientes.CheckedChanged

    End Sub
End Class

