Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmMovCli
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub FrmMovCli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 5)
        txtpini.Text = Strings.Right(PerActual, 5)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)

        '' CARGAR CLIENTES
        '' AUTOCOMPLETAR NIT CLIENTE
        'Try
        '    txtcliente.AutoCompleteCustomSource.Clear()

        '    Dim tb As New DataTable
        '    tb.Clear()
        '    myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tb)
        '    If tb.Rows.Count > 0 Then
        '        For i = 0 To tb.Rows.Count - 1
        '            txtcliente.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = False
        End If
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            'chcli.Visible = True
            'chcli.Checked = False
            'txtnitc.Focus()
        Else
            txtnitc.Enabled = False
            'chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            cargarclientes()
        End If
    End Sub

    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        Else
            txtcliente.Text = ""
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT * FROM terceros ORDER BY nombre,apellidos;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            items = tabla2.Rows.Count
            FrmSelCliente.gitems.Rows.Clear()
            FrmSelCliente.gitems.RowCount = items + 1
            For i = 0 To items - 1
                FrmSelCliente.gitems.Item(1, i).Value = tabla2.Rows(i).Item("nombre") & " " & tabla2.Rows(i).Item("apellidos")
                FrmSelCliente.gitems.Item(2, i).Value = tabla2.Rows(i).Item("nit")
            Next
            FrmSelCliente.lbform.Text = "inf_mov_cli"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        ' Try
        If CInt(cbfin.Text) < CInt(cbini.Text) Then
            MsgBox("Seleccione un rango de periodos valido", MsgBoxStyle.Information)
            cbfin.Text = cbini.Text
        Else
            informe()
        End If
        '  Catch ex As Exception

        '  End Try


    End Sub
    Private Sub informe()

        Dim per As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim sql As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        If cbini.Text <> cbfin.Text Then
            per = "PERIODO INICIAL: " & cbini.Text & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & txtpfin.Text
        Else
            per = "PERIODO : " & cbini.Text & txtpini.Text
        End If
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT : " & tabla2.Rows(0).Item("nit")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim docu As String = ""
        Dim p As String = ""
        Dim cli As String = ""
        Dim c_cli As String = ""
        Dim o_cli As String = ""
        If c2.Checked = True Then
            cli = " AND nitc = '" & txtnitc.Text & "' "
            c_cli = " AND c.nitc = '" & txtnitc.Text & "' "
            o_cli = " AND o.nitc = '" & txtnitc.Text & "' "
        End If

        Dim aj As String = ""
        Dim t_aj As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT aj FROM  `parotdoc` "
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t_aj)
        If t_aj.Rows.Count > 0 Then
            aj = t_aj.Rows(0).Item(0)
        End If


        Dim cons As String = ""
        For i = CInt(cbini.Text) To CInt(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If p <> cbfin.Text Then
                cons = cons & "SELECT DOC_AFEC FROM `ot_cpc" & p & "` where doc_afec<>'' UNION "
            Else
                cons = cons & "SELECT DOC_AFEC FROM `ot_cpc" & p & "` where doc_afec<>'' "
            End If
        Next

        Dim tbc As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbc)

        If tbc.Rows.Count <> 0 Then
            docu = " IN ("
            For j = 0 To tbc.Rows.Count - 1
                If j <> tbc.Rows.Count - 1 Then
                    docu = docu & " '" & tbc.Rows(j).Item(0) & "' , "
                Else
                    docu = docu & " '" & tbc.Rows(j).Item(0) & "' ) "
                End If
            Next
        End If
        '/////////////// SALDOS ////////////////////
        Dim sql3 As String = ""
        Dim sql2 As String = ""
        '///////////////////////////////////////////
        If i1.Checked = True Then ' INFORME RESUMIDO
            sql = "select rs.nomnit , rs.nitc, (rs.v_viva-rs.ret) as ret, sum(rs.subtotal) as subtotal, sum(rs.descto) as descto FROM ("
        End If

        If m1.Checked = True Then ' movimientos

            If CInt(cbini.Text) = 1 Then
                sql2 = " SELECT nitc as codart, sum(total) as valor from cobdpen where doc " & docu & " " & cli & " GROUP BY nitc ORDER BY nitc"
                ' saldo pagos
                sql3 = "SELECT cn.nitc as nt, 0 as saldo FROM( "
                For i = CInt(cbini.Text) To CInt(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If p <> cbfin.Text Then
                        sql3 = sql3 & "SELECT nitc, sum(total) as st FROM ot_cpc" & p & "    WHERE doc_afec " & docu & " AND doc_aj = '' " & cli & " GROUP BY nitc UNION "
                    Else
                        sql3 = sql3 & "SELECT nitc, sum(total) as st  FROM ot_cpc" & p & "   WHERE doc_afec " & docu & " AND doc_aj = '' " & cli & " GROUP BY nitc "
                    End If
                Next
                sql3 = sql3 & ") AS cn GROUP BY nitc ORDER BY nitc"
            Else
                ' total deuda
                sql2 = " SELECT nitc as codart, sum(total) as valor from cobdpen where doc " & docu & " " & cli & " GROUP BY nitc ORDER BY nitc"
                ' saldo pagos
                sql3 = "SELECT cn.nitc as nt, sum(cn.sT) as saldo FROM( "

                For i = 1 To (CInt(cbini.Text) - 1)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> (CInt(cbini.Text) - 1) Then
                        sql3 = sql3 & "SELECT nitc, sum(total) as st FROM ot_cpc" & p & "    WHERE doc_afec " & docu & " AND doc_aj = '' " & cli & " GROUP BY nitc UNION "
                    Else
                        sql3 = sql3 & "SELECT nitc, sum(total) as st  FROM ot_cpc" & p & "   WHERE doc_afec " & docu & " AND doc_aj = '' " & cli & " GROUP BY nitc "
                    End If
                Next
                sql3 = sql3 & ") AS cn GROUP BY nitc ORDER BY nitc"
            End If
            '///////////////////////////////////////////


            sql = sql & "SELECT c.nitc, c.doc,c.nomnit, CAST( (CONCAT( RIGHT(  c.fecha , 2 ) ,  '/', MID(  c.fecha ,  6, 2 ) ,  '/', LEFT(  c.fecha , 4 ) ) ) AS CHAR( 20 ) ) as nitcod, c.concepto as descrip,  " _
        & " '' AS nitv, c.total as subtotal,  0 AS descto, t.valor as v_viva , IFNULL(t2.saldo,0) as ret" _
        & " FROM    " _
        & " ( " & sql2 & ") as t, " _
        & " `cobdpen` c " _
        & "LEFT JOIN " _
        & "(" & sql3 & ") AS t2  ON t2.nt=c.nitc" _
        & " WHERE doc " & docu & " AND t.codart= c.nitc  " & c_cli & " UNION "

            For i = CInt(cbini.Text) To CInt(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p <> cbfin.Text Then
                    sql = sql & "SELECT o.nitc, o.doc, CONCAT(t.nombre,' ',t.apellidos) as nomnit, CAST( CONCAT( o.dia,  '/', o.periodo ) AS CHAR(20)) AS nitcod, o.concepto as descrip, o.doc_afec as  nitv, 0 as subtotal,  o.credito AS descto,0 as  valor, 0 as saldo FROM ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc  WHERE o.doc_afec " & docu & " AND o.doc_aj = '' " & o_cli & "UNION "
                Else
                    sql = sql & "SELECT o.nitc, o.doc, CONCAT(t.nombre,' ',t.apellidos) as nomnit, CAST( CONCAT( o.dia,  '/', o.periodo ) AS CHAR(20)) AS nitcod, o.concepto as descrip, o.doc_afec as  nitv, 0 AS subtotal,  o.credito AS descto,0 as valor, 0 as saldo FROM ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc  WHERE o.doc_afec " & docu & " AND o.doc_aj = ''  " & o_cli & ""
                End If
            Next
            sql = sql & "ORDER BY nitc"

        Else  ' todos sin con mov

            '/////////////////////// SALDOS


            ' todos mov 
            If CInt(cbini.Text) = 1 Then
                sql2 = " SELECT nitc as codart, sum(total) as valor from cobdpen where nitc<>'' " & cli & " GROUP BY nitc ORDER BY nitc"
                ' saldo pagos
                sql3 = "SELECT cn.nitc as nt, 0 as saldo FROM( "
                For i = CInt(cbini.Text) To CInt(cbfin.Text)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If p <> cbfin.Text Then
                        sql3 = sql3 & "SELECT nitc, sum(total) as st FROM ot_cpc" & p & "    WHERE  doc_aj = '' " & cli & " GROUP BY nitc UNION "
                    Else
                        sql3 = sql3 & "SELECT nitc, sum(total) as st  FROM ot_cpc" & p & "   WHERE  doc_aj = '' " & cli & " GROUP BY nitc "
                    End If
                Next
                sql3 = sql3 & ") AS cn GROUP BY nitc ORDER BY nitc"

            Else
                ' total deuda
                sql2 = " SELECT nitc as codart, sum(total) as valor from cobdpen where nitc<>'' " & cli & " GROUP BY nitc ORDER BY nitc"
                ' saldo pagos
                sql3 = "SELECT cn.nitc as nt, sum(cn.sT) as saldo FROM( "

                For i = 1 To (CInt(cbini.Text) - 1)
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If

                    If i <> (CInt(cbini.Text) - 1) Then
                        sql3 = sql3 & "SELECT nitc, sum(total) as st FROM ot_cpc" & p & "    WHERE doc_aj = '' " & cli & " GROUP BY nitc UNION "
                    Else
                        sql3 = sql3 & "SELECT nitc, sum(total) as st  FROM ot_cpc" & p & "   WHERE  doc_aj = '' " & cli & " GROUP BY nitc "
                    End If
                Next
                sql3 = sql3 & ") AS cn GROUP BY nitc ORDER BY nitc"
            End If
            '/////////////////////////// FIN SALDOS 

            sql = sql & "SELECT c.nitc, c.doc,c.nomnit, CAST( (CONCAT( RIGHT(  c.fecha , 2 ) ,  '/', MID(  c.fecha ,  6, 2 ) ,  '/', LEFT(  c.fecha , 4 ) ) ) AS CHAR( 20 ) ) as nitcod, c.concepto as descrip,  " _
          & " '' AS nitv, c.total as subtotal,  0 AS descto, t.valor as v_viva , IFNULL(t2.saldo,0) as ret" _
          & " FROM    " _
          & " ( " & sql2 & ") as t, " _
          & " `cobdpen` c " _
          & "LEFT JOIN " _
          & "(" & sql3 & ") AS t2  ON t2.nt=c.nitc" _
          & " WHERE t.codart= c.nitc  " & c_cli & " UNION "

            For i = CInt(cbini.Text) To CInt(cbfin.Text)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p <> cbfin.Text Then
                    sql = sql & "SELECT o.nitc, o.doc, CONCAT(t.nombre,' ',t.apellidos) as nomnit, CAST( CONCAT( o.dia,  '/', o.periodo ) AS CHAR(20)) AS nitcod, o.concepto as descrip, o.doc_afec as  nitv, 0 as subtotal,  o.credito AS descto,0 as  valor, 0 as saldo FROM ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc  WHERE o.doc_aj = '' " & o_cli & "UNION "
                Else
                    sql = sql & "SELECT o.nitc, o.doc, CONCAT(t.nombre,' ',t.apellidos) as nomnit, CAST( CONCAT( o.dia,  '/', o.periodo ) AS CHAR(20)) AS nitcod, o.concepto as descrip, o.doc_afec as  nitv, 0 AS subtotal,  o.credito AS descto,0 as valor, 0 as saldo FROM ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc  WHERE  o.doc_aj = ''  " & o_cli & ""
                End If
            Next
            sql = sql & "ORDER BY nitc"

        End If


        If i1.Checked = True Then ' INFORME RESUMIDO
            sql = sql & " ) as rs where left(rs.doc,2)<>'" & aj & "' GROUP BY rs.nitc ORDER BY nomnit"
        End If

        TextBox1.Text = sql

        If i2.Checked = True Then

            'detallado
            Dim tabla As DataSet
            tabla = New DataSet
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "cobdpen")

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMovC.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCarCuen.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField

                Dim Pr_aj As New ParameterField
                Dim Pr_sa As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Pr_aj.Name = "aju"
                Pr_aj.CurrentValues.AddValue(aj.ToString)
                'Pr_sa.Name = "sal"
                'Pr_sa.CurrentValues.AddValue(tsal.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Pr_aj)
                ' prmdatos.Add(Pr_sa)

                FrmReportCarCuen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCarCuen.ShowDialog()
            Catch ex As Exception
            End Try

        Else
            ' resumido
            Dim tabla As DataSet
            tabla = New DataSet
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "cobdpen")


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMovC1R.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCarCuen.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportCarCuen.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCarCuen.ShowDialog()
            Catch ex As Exception
            End Try

        End If
        '   End If




    End Sub

 
    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txtnitc.Enabled = False
            txtcliente.Enabled = True
        Else
            txtcliente.Enabled = False
            txtnitc.Enabled = True
        End If
    End Sub

    Private Sub txtcliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcliente.LostFocus
        Try
            If txtcliente.Text = "" Then
                txtnitc.Text = ""
                FrmSelCliente.lbform.Text = "inf_mov_cli"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtcliente.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(nombre,' ',apellidos)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txtnitc.Text = ""
            FrmSelCliente.lbform.Text = "inf_mov_cli"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class