Imports ZedGraph

Public Class FrmGrafica
    Public y, y2 As Double
    Dim myPane As GraphPane
    Dim list1 As New PointPairList()
    Dim myBar As BarItem
    Dim labels(3) As String
    Dim colores As Color() = {Color.Red, Color.Blue, Color.Yellow, Color.MediumSeaGreen, Color.MediumSpringGreen, Color.MediumTurquoise, Color.DeepSkyBlue, Color.RoyalBlue, Color.BlueViolet, Color.Violet, Color.HotPink, Color.Gray}

    Private Sub CrearEstados(ByVal z1 As ZedGraphControl)
        Me.ZedGraphControl1.Visible = True
        myPane = z1.GraphPane
        myPane.Title.Text = "GRÁFICA ESTADOS DE RESULTADOS"
        myPane.XAxis.Title.Text = "PERIODO INICIAL: " & FrmEstadoResultados.cbfin.Text & FrmEstadoResultados.txtpini.Text & " - PERIODO FINAL: " & FrmEstadoResultados.cbfin.Text & FrmEstadoResultados.txtpfin.Text
        myPane.YAxis.Title.Text = "MONTOS EN $"
        '**********************************
        Dim tI, tG, tC As New DataTable
        Dim sumaI, sumaG, sumaC, aI, aG, aC, UTI As Double
        Dim saldo As String
        '****************************************
        sumaI = 0
        sumaG = 0
        sumaC = 0
        For j = Val(FrmEstadoResultados.cbini.Text) To Val(FrmEstadoResultados.cbfin.Text)
            If j < 10 Then
                saldo = "documentos0" & j
            Else
                saldo = "documentos" & j
            End If
            'TOTAL INGRESOS
             tI.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '4%';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tI)
            Try
                aI = tI.Rows(0).Item(0)
            Catch ex As Exception
                aI = 0
            End Try
            sumaI = sumaI + aI
            'TOTAL GASTOS
            tG.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '5%';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tG)
            Try
                aG = tG.Rows(0).Item(0)
            Catch ex As Exception
                aG = 0
            End Try
            sumaG = sumaG + aG
            'TOTAL COSTOS
            tC.Clear()
            myCommand.CommandText = "SELECT SUM(debito - credito) as s FROM " & saldo & " WHERE codigo like '6%';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tC)
            Try
                aC = tC.Rows(0).Item(0)
            Catch ex As Exception
                aC = 0
            End Try
            sumaC = sumaC + aC
        Next
        '***************************************        
        UTI = sumaI + sumaG + sumaC

        '***********************************
        labels(0) = "INGRESOS "
        labels(1) = "GASTOS "
        labels(2) = "COSTOS "
        If UTI < 0 Then
            labels(3) = "UTILIDAD "
        Else
            labels(3) = "PERDIDAD "
        End If
        '*******************
        list1.Add(0, (-1 * sumaI), 0)
        list1.Add(1, (-1 * sumaG), 1)
        list1.Add(2, (-1 * sumaC), 2)
        list1.Add(3, (-1 * UTI), 3)
        Dim segment1 As PieItem
        segment1 = myPane.AddPieSlice(20, colores(0), Color.White, 45.0F, 0, "INGRESOS: " & Moneda(sumaI))
        segment1 = myPane.AddPieSlice(20, colores(1), Color.White, 45.0F, 0, "GASTOS: " & Moneda(sumaG))
        segment1 = myPane.AddPieSlice(20, colores(2), Color.White, 45.0F, 0, "COSTOS: " & Moneda(sumaC))
        If UTI < 0 Then
            segment1 = myPane.AddPieSlice(20, colores(3), Color.White, 45.0F, 0, "UTILIDAD: " & Moneda(UTI))
        Else
            segment1 = myPane.AddPieSlice(20, colores(3), Color.White, 45.0F, 0, "PERDIDAD: " & Moneda(UTI))
        End If
        '************************
        myBar = myPane.AddBar("", list1, Color.Transparent)
        'myBar.Bar.Fill = New Fill(Color.Green, Color.White, Color.Green)
        'myBar.Bar.Fill = New Fill(Color.YellowGreen, Color.White, Color.YellowGreen)
        myBar.Bar.Fill = New Fill(colores)
        myPane.XAxis.MajorTic.IsBetweenLabels = True
        myPane.XAxis.Scale.TextLabels = labels
        myPane.XAxis.Scale.FontSpec.Size = 6
        myPane.XAxis.Type = AxisType.Text
        myBar.Bar.Fill = New Fill(colores)
        myBar.Bar.Fill.Type = FillType.GradientByZ
        myBar.Bar.Fill.RangeMin = 0
        myBar.Bar.Fill.RangeMax = 11
        myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(100, 220, 170), 45)
        myPane.Fill = New Fill(Color.White, Color.FromArgb(250, 250, 225), 45)

        z1.AxisChange()
        z1.Controls.Clear()
    End Sub
    Private Sub CrearBG(ByVal z1 As ZedGraphControl)
        Me.ZedGraphControl1.Visible = True
        myPane = z1.GraphPane
        myPane.Title.Text = "GRÁFICA BALANCE GENERAL "
        myPane.XAxis.Title.Text = "PERIODO: " & FrmBalanceGral.ini.Text & "/" & FrmBalanceGral.txtano.Text
        myPane.YAxis.Title.Text = "MONTOS EN $"
        '**********************************
        Dim tI, tG, tC As New DataTable
        Dim sumaI, sumaG, sumaC, aI, aG, aC, UTI As Double
        Dim saldo As String
        '****************************************
        sumaI = 0
        sumaG = 0
        sumaC = 0
        For j = Val(FrmBalanceGral.ini.Text) To Val(FrmBalanceGral.ini.Text)
            If j < 10 Then
                saldo = "saldo0" & j
            Else
                saldo = "saldo" & j
            End If
            tI.Clear()
            'TOTAL INGRESOS
            myCommand.CommandText = "SELECT SUM(" & saldo & ") as s FROM selpuc WHERE codigo like '1%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tI)
            Try
                aI = tI.Rows(0).Item(0)
            Catch ex As Exception
                aI = 0
            End Try
            sumaI = sumaI + aI
            tC.Clear()
            'TOTAL GASTOS
            myCommand.CommandText = "SELECT SUM(" & saldo & ") as s FROM selpuc WHERE codigo like '2%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tG)
            Try
                aG = tG.Rows(0).Item(0)
            Catch ex As Exception
                aG = 0
            End Try
            sumaG = sumaG + aG
            'TOTAL COSTOS
            myCommand.CommandText = "SELECT SUM(" & saldo & ") as s FROM selpuc WHERE codigo like '3%' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tC)
            Try
                aC = tC.Rows(0).Item(0)
            Catch ex As Exception
                aC = 0
            End Try
            sumaC = sumaC + aC
        Next
        '***************************************        
        UTI = sumaI + sumaG + sumaC

        '***********************************
        labels(0) = "ACTIVOS "
        labels(1) = "PASIVOS "
        labels(2) = "PATRIMONIO "
        labels(3) = "DIFERENCIA "
       
        '*******************
        list1.Add(0, sumaI, 0)
        '********************************
        If sumaG < 0 Then
            list1.Add(1, (-1 * sumaG), 1)
        Else
            list1.Add(1, sumaG, 1)
        End If
        '*********************************
        If sumaC < 0 Then
            list1.Add(2, (-1 * sumaC), 2)
        Else
            list1.Add(2, sumaC, 2)
        End If
        '**************************************
        list1.Add(3, UTI, 3)
        Dim segment1 As PieItem
        segment1 = myPane.AddPieSlice(20, colores(0), Color.White, 45.0F, 0, "ACTIVOS: " & Moneda(sumaI))
        segment1 = myPane.AddPieSlice(20, colores(1), Color.White, 45.0F, 0, "PASIVOS: " & Moneda(sumaG))
        segment1 = myPane.AddPieSlice(20, colores(2), Color.White, 45.0F, 0, "PATRIMONIO: " & Moneda(sumaC))
        segment1 = myPane.AddPieSlice(20, colores(3), Color.White, 45.0F, 0, "DIFERENCIA: " & Moneda(UTI))
      
        '************************
        myBar = myPane.AddBar("", list1, Color.Transparent)
        'myBar.Bar.Fill = New Fill(Color.Green, Color.White, Color.Green)
        'myBar.Bar.Fill = New Fill(Color.YellowGreen, Color.White, Color.YellowGreen)
        myBar.Bar.Fill = New Fill(colores)
        myPane.XAxis.MajorTic.IsBetweenLabels = True
        myPane.XAxis.Scale.TextLabels = labels
        myPane.XAxis.Scale.FontSpec.Size = 6
        myPane.XAxis.Type = AxisType.Text
        myBar.Bar.Fill = New Fill(colores)
        myBar.Bar.Fill.Type = FillType.GradientByZ
        myBar.Bar.Fill.RangeMin = 0
        myBar.Bar.Fill.RangeMax = 11
        myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(100, 220, 170), 45)
        myPane.Fill = New Fill(Color.White, Color.FromArgb(250, 250, 225), 45)

        z1.AxisChange()
        z1.Controls.Clear()
    End Sub

    Private Sub FrmGrafica_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FrmGrafica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case lbform.Text
            Case "estados"
                CrearEstados(ZedGraphControl1)
            Case "general"
                CrearBG(ZedGraphControl1)
        End Select
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Me.MenuStrip1.Visible = False
        Me.ZedGraphControl1.Size = New Size(600, 500)
        Try
            With PrintForm1
                .PrintAction = Printing.PrintAction.PrintToPrinter
                '.PrintAction = Printer.Orientation = 2
                'Printer.Orientation = 2
                .Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
                '.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
                '.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
            End With
            'PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview ' Crea una vista previa 
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
        Me.ZedGraphControl1.Size = New Size(838, 541)
        Me.MenuStrip1.Visible = True
    End Sub

    Private Sub AtrásToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtrásToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class