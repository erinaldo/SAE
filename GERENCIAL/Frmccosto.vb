Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class Frmccosto
    Private Sub limpiar()
        txtcc.Text = ""
        txtnomcc.Text = ""
        txtnomcc.Text = ""
        txtpres.Text = ""
        g_ing.Rows.Clear()
        g_gast.Rows.Clear()
        txtut.Text = ""
        txt_tgas.Text = ""
        txt_ting.Text = ""
    End Sub

    Private Sub txtcc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcc.LostFocus
        limpiar()
        Buscarcc()
    End Sub

    Private Sub Buscarcc()
        Try
            If Trim(txtcc.Text) = "" Then
                FrmSelCentroCostos.lbform.Text = "analisis"
                FrmSelCentroCostos.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & Trim(txtcc.Text) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    MsgBox("El centro de costo no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                    txtcc.Text = ""
                    txtnomcc.Text = ""
                    txtpres.Text = ""
                    FrmSelCentroCostos.lbform.Text = "analisis"
                    FrmSelCentroCostos.ShowDialog()
                Else
                    txtnomcc.Text = tabla.Rows(0).Item("nombre")
                    txtpres.Text = tabla.Rows(0).Item("pres")
                End If
            End If
        Catch ex As Exception
            txtnomcc.Text = ""
        End Try
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click

        Dim ct As String = ""
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM  `par_analisis`;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        For i = 0 To tabla.Rows.Count - 1
            For k = 1 To 10
                If tabla.Rows(i).Item("cuenta" & k) <> "" Then
                    ct = "Y"
                End If
            Next
        Next

        If ct = "Y" Then
            documentos()
        Else
            MsgBox("  No ha definido los parametros", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Dim c_ing As String = ""
    Dim c_gas As String = ""

    Private Sub documentos()

        c_ing = ""
        c_gas = ""
        Dim p As String = ""
        Dim sqlI As String = ""
        Dim sqlG As String = ""

        Dim t_ing As New DataTable
        myCommand.CommandText = "SELECT * FROM  `par_analisis` ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t_ing)
        Refresh()

        For k = 1 To 10
            If t_ing.Rows(0).Item("cuenta" & k) <> "" Then
                c_ing = c_ing & t_ing.Rows(0).Item("cuenta" & k) & ","
            End If
            If t_ing.Rows(1).Item("cuenta" & k) <> "" Then
                c_gas = c_gas & t_ing.Rows(1).Item("cuenta" & k) & ","
            End If
        Next
        c_ing = Strings.Left(c_ing, Strings.Len(c_ing) - 1)
        c_gas = Strings.Left(c_gas, Strings.Len(c_gas) - 1)


        ' ******************   LLENAR GRILLA INGRESOS
        sqlI = " SELECT c.codigo, sum(c.credito) as sal_ing FROM ("
        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = "01" Then
                sqlI = sqlI & " SELECT codigo,  credito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_ing & ") AND centro = '" & txtcc.Text & "' "
            Else
                sqlI = sqlI & "UNION  SELECT codigo, credito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_ing & ") AND centro = '" & txtcc.Text & "' "
            End If
        Next
        sqlI = sqlI & " ) as c GROUP BY codigo"
        '" & txtcc.Text & "'

        Dim tb As New DataTable
        Dim tb_ing As New DataTable
        myCommand.CommandText = sqlI
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb_ing)
        Refresh()

        Dim s_ing As Double = 0

        If tb_ing.Rows.Count > 0 Then
            g_ing.RowCount = 10
            For j = 0 To tb_ing.Rows.Count - 1
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & tb_ing.Rows(j).Item(0) & "' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                g_ing.Item(0, j).Value = tb_ing.Rows(j).Item(0)
                g_ing.Item(1, j).Value = tb.Rows(0).Item("descripcion")
                g_ing.Item(2, j).Value = Moneda(tb_ing.Rows(j).Item(1))
                s_ing = s_ing + g_ing.Item(2, j).Value
                tb_ing.Clear()
            Next
        End If
        txt_ting.Text = Moneda(s_ing)
        '**************************************


        ' ************************    LLENAR GRILLA DE GASTOS
        sqlG = " SELECT c.codigo, sum(c.debito) as sal_gast FROM ("
        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = "01" Then
                sqlG = sqlG & " SELECT codigo, debito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_gas & ") AND centro = '" & txtcc.Text & "' "
            Else
                sqlG = sqlG & "UNION  SELECT codigo, debito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_gas & ") AND centro = '" & txtcc.Text & "' "
            End If
        Next
        sqlG = sqlG & " ) as c GROUP BY codigo"

        Dim tb_gas As New DataTable
        myCommand.CommandText = sqlG
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb_gas)
        Refresh()

        Dim s_gs As Double = 0
        If tb_gas.Rows.Count > 0 Then
            g_gast.RowCount = 10
            For j = 0 To tb_gas.Rows.Count - 1
                Try

                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & tb_gas.Rows(j).Item(0) & "' ;"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tb)
                    g_gast.Item(0, j).Value = tb_gas.Rows(j).Item(0)
                    g_gast.Item(1, j).Value = tb.Rows(0).Item("descripcion")
                    g_gast.Item(2, j).Value = Moneda(tb_gas.Rows(j).Item(1))
                    s_gs = s_gs + g_gast.Item(2, j).Value
                    tb_gas.Clear()

                Catch ex As Exception

                End Try
            Next
        End If
        txt_tgas.Text = Moneda(s_gs)
        '**************************************

        txtut.Text = Moneda(s_ing - s_gs)

    End Sub

    Private Sub Frmccosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
    End Sub

    Private Sub cmdpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpdf.Click

        MiConexion(bda)
        Cerrar()

        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql_ing As String = ""
        Dim sql_gas As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cc As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable


        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        per = "PERIODO ACTUAL: " & PerActual
        cc = txtcc.Text & " - " & txtnomcc.Text

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        sql_ing = " SELECT  sum(c.credito) as credito, '" & txtut.Text & "' as debito FROM ("
        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = "01" Then
                sql_ing = sql_ing & " SELECT codigo as centro,  credito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_ing & ") AND centro = '" & txtcc.Text & "' "
            Else
                sql_ing = sql_ing & "UNION  SELECT codigo as centro, credito " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_ing & ") AND centro = '" & txtcc.Text & "' "
            End If
        Next
        sql_ing = sql_ing & "ORDER BY centro ) as c "


        sql_gas = "select  sum(c.total) as total from ("
        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = "01" Then
                sql_gas = sql_gas & " SELECT codigo as per, debito as total " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_gas & ") AND centro = '" & txtcc.Text & "' "
            Else
                sql_gas = sql_gas & "UNION  SELECT codigo as per, debito as total " _
                & "FROM documentos" & p & " WHERE codigo IN (" & c_gas & ") AND centro = '" & txtcc.Text & "' "
            End If
        Next
        sql_gas = sql_gas & "ORDER BY per) as c "


        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql_ing
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "documentos01")


        myCommand.Parameters.Clear()
        myCommand.CommandText = sql_gas
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "movimientos01")


        'myCommand.Parameters.Clear()
        'myCommand.CommandText = Sql
        'myCommand.Connection = conexion
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla, "facturas01")

        '  TextBox1.Text = sql2


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportAcc.rpt")
        CrReport.SetDataSource(tabla)
        FrmRepSinMov.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prcc As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "per"
            Prperiodo.CurrentValues.AddValue(per.ToString)
            Prcc.Name = "cc"
            Prcc.CurrentValues.AddValue(cc.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prcc)

            FrmRepSinMov.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepSinMov.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
End Class