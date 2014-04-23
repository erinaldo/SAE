Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmInfoReciboCartera

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
            'chcli.Checked = False
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub

    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            cargarclientes()
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
            FrmSelCliente.lbform.Text = "inf_recc"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
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

    Private Sub FrmInfoReciboCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtorden.SelectedItem = "Por Recibo"
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/" & ano
        fecha1.MaxDate = "31/12/" & ano
        fecha2.MinDate = "01/01/" & ano
        fecha2.MaxDate = "31/12/" & ano
        '**************************************
        fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Try
            fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception
            Try
                If PerActual(0) & PerActual(1) = "02" Then
                    fecha2.Value = "28/" & PerActual(0) & PerActual(1) & "/" & ano
                Else
                    fecha2.Value = "30/" & PerActual(0) & PerActual(1) & "/" & ano
                End If
            Catch ex2 As Exception
            End Try
        End Try

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

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If fecha1.Text.ToString > fecha2.Text.ToString Then
            MsgBox("Verifique la fecha", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim sql As String = ""
            Dim p As String = ""
            Dim per As String = ""
            Dim nom As String = ""
            Dim nit As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable

            per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & " / " & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & " / " & Strings.Right(fecha2.Text, 4)


            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim m1 As String = ""
            Dim m2 As String = ""
            Dim da1 As String = ""
            Dim da2 As String = ""

            m1 = Strings.Mid(fecha1.Text, 4, 2)
            m2 = Strings.Mid(fecha2.Text, 4, 2)

            da1 = Strings.Left(fecha1.Text, 2)
            da2 = Strings.Left(fecha2.Text, 2)

            Dim cl As String = ""
            Dim dc As String = ""
            Dim ord As String = ""
            If c2.Checked = True Then
                cl = "AND o.nitc= '" & txtnitc.Text & "'"
            End If

            If d1.Checked = True Then
                dc = " AND o.estado= 'AP' AND o.doc_aj = ''"
            ElseIf d2.Checked = True Then
                dc = " AND o.estado= '' "
            Else
                dc = " AND o.doc_aj <> '' "
            End If

            If txtorden.SelectedItem = "Por Recibo" Then
                ord = " ORDER BY  doc, it "
            Else
                ord = " ORDER BY  nomart"
            End If

            For i = Val(m1) To Val(m2)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                'sql = sql & "SELECT o.doc , concat(o.dia,'/',o.periodo) as concep,o.item as it,o.doc_afec as cta_iva , " _
                '& "if(o.debito='0',o.credito,o.debito)as valor, o.total as vtotal, o.nitc as cta_ing,concat(t.nombre,' ',t.apellidos) as nomart, " _
                '& "if ((SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))<0,'0',CAST( (SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))AS CHAR(10))) as codart, " _
                '& "o.tipo_pago as cta_cos FROM  cobdpen c,ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc WHERE   c.doc=o.doc_afec and o.doc_afec<>'' " _
                '& " AND o.dia BETWEEN '" & da1 & "' and '" & da2 & "' " & cl & " " & dc & ""

                If m1 = m2 Then

                    sql = sql & "SELECT o.doc , concat(o.dia,'/',o.periodo) as concep,o.item as it,o.doc_afec as cta_iva , " _
                 & "if(o.debito='0',o.credito,o.debito)as valor, o.total as vtotal, o.nitc as cta_ing,concat(t.nombre,' ',t.apellidos) as nomart, " _
                 & "if ((SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))<0,'0',CAST( (SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))AS CHAR(10))) as codart, " _
                 & "o.tipo_pago as cta_cos FROM  cobdpen c,ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc WHERE   c.doc=o.doc_afec and o.doc_afec<>'' " _
                 & " AND o.dia BETWEEN '" & da1 & "' and '" & da2 & "' " & cl & " " & dc & ""
                Else
                    If p = m1 Then
                        sql = sql & "SELECT o.doc , concat(o.dia,'/',o.periodo) as concep,o.item as it,o.doc_afec as cta_iva , " _
               & "if(o.debito='0',o.credito,o.debito)as valor, o.total as vtotal, o.nitc as cta_ing,concat(t.nombre,' ',t.apellidos) as nomart, " _
               & "if ((SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))<0,'0',CAST( (SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))AS CHAR(10))) as codart, " _
               & "o.tipo_pago as cta_cos FROM  cobdpen c,ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc WHERE   c.doc=o.doc_afec and o.doc_afec<>'' " _
               & " AND o.dia >= '" & da1 & "' " & cl & " " & dc & ""
                    ElseIf p <> m1 And p <> m2 Then
                        sql = sql & " UNION SELECT o.doc , concat(o.dia,'/',o.periodo) as concep,o.item as it,o.doc_afec as cta_iva , " _
            & "if(o.debito='0',o.credito,o.debito)as valor, o.total as vtotal, o.nitc as cta_ing,concat(t.nombre,' ',t.apellidos) as nomart, " _
            & "if ((SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))<0,'0',CAST( (SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))AS CHAR(10))) as codart, " _
            & "o.tipo_pago as cta_cos FROM  cobdpen c,ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc WHERE   c.doc=o.doc_afec and o.doc_afec<>'' " _
            & "  " & cl & " " & dc & ""
                    ElseIf p = m2 Then
                        sql = sql & " UNION SELECT o.doc , concat(o.dia,'/',o.periodo) as concep,o.item as it,o.doc_afec as cta_iva , " _
         & "if(o.debito='0',o.credito,o.debito)as valor, o.total as vtotal, o.nitc as cta_ing,concat(t.nombre,' ',t.apellidos) as nomart, " _
         & "if ((SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))<0,'0',CAST( (SELECT DATEDIFF(concat(right(o.periodo,4),'-',left(o.periodo,2),'-',o.dia),c.fecha ))AS CHAR(10))) as codart, " _
         & "o.tipo_pago as cta_cos FROM  cobdpen c,ot_cpc" & p & " o LEFT JOIN terceros t ON t.nit= o.nitc WHERE   c.doc=o.doc_afec and o.doc_afec<>'' " _
         & " AND o.dia <= '" & da2 & "' " & cl & " " & dc & ""
                    End If
                End If

            Next
            sql = sql & " " & ord & " "

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCRecibo.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportFacCon.CrystalReportViewer1.ReportSource = CrReport

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

                Prperiodo.Name = "per"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportFacCon.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacCon.ShowDialog()

            Catch ex As Exception
                ' MsgBox(sql)
            End Try

        End If
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
                FrmSelCliente.lbform.Text = "inf_recc"
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
            FrmSelCliente.lbform.Text = "inf_recc"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub

End Class