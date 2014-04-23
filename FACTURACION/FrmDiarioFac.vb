Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmDiarioFac

    Private Sub FrmDiarioFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpfin.Text = Strings.Right(PerActual, 4)
        txtpini.Text = Strings.Right(PerActual, 4)
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        If Now.Day < 10 Then
            txtdi2.Text = "0" & Now.Day
        Else
            txtdi2.Text = Now.Day
        End If
        If Now.Day < 10 Then
            txtdi1.Text = "0" & Now.Day
        Else
            txtdi1.Text = Now.Day
        End If
    End Sub
    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If CInt(txtdi1.Text) <= 9 Then
            txtdi1.Text = "0" & CInt(txtdi1.Text)
        End If
    End Sub
    Private Sub txtdi2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi2.LostFocus
        If CInt(txtdi2.Text) <= 9 Then
            txtdi2.Text = "0" & CInt(txtdi2.Text)
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            GenerarPDF()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GenerarPDF()
        Dim cad As String = ""
        Dim sql As String = ""
        Dim sql1 As String = ""
        Dim sql3 As String = ""
        Dim sql2 As String = ""
        Dim p As String = ""
        Dim nom As String = ""
        Dim nit As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")


        If d1.Checked = True Then 'APROBADOS SIN ANULAR
            cad = " and f.estado= 'AP'  AND LEFT(f.descrip,7)<>'ANULADO' "
        ElseIf d2.Checked = True Then ' PENDIENTES
            cad = " and f.estado= '' "
        ElseIf d3.Checked = True Then ' ANULADOS
            cad = " AND LEFT(f.descrip,7)='ANULADO' "
        End If


        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If cbini.Text = cbfin.Text Then
                sql = sql & "SELECT f.doc , f.tipodoc , f.num, f.total, f.fecha, " _
                & " CAST(CONCAT(RIGHT(f.fecha,2),'/',MID(f.fecha,6,2),'/',LEFT(f.fecha,4)) AS CHAR(15)) AS cta_iva,  f.por_iva, f.iva, " _
                & " fp.descrip , fp.valor " _
                & " FROM facturas" & p & "	f, facpagos" & p & " fp WHERE fp.doc= f.doc AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & cad


                'sql = sql & " Select f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, f.fecha, f.doc_afec,  df.cantidad AS num, " _
                '   & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                '   & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                '   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                '    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                '   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND right(f.fecha,2) BETWEEN '" & txtdi1.Text & "' AND  '" & txtdi2.Text & "' " & td & "  AND ( f.doc = df.doc ) "
            Else
                If p = cbini.Text Then

                    sql = sql & " SELECT f.doc , f.tipodoc , f.num, f.total, f.fecha, " _
                  & " CAST(CONCAT(RIGHT(f.fecha,2),'/',MID(f.fecha,6,2),'/',LEFT(f.fecha,4)) AS CHAR(15)) AS cta_iva,  f.por_iva, f.iva, " _
                  & " fp.descrip , fp.valor " _
                  & " FROM facturas" & p & " f, facpagos" & p & " fp WHERE fp.doc= f.doc " _
                  & " AND right(f.fecha,2) >= '" & txtdi1.Text & "' " & cad

                    '    sql = sql & " Select f.tipodoc, f.doc,f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent, f.fecha ,  f.doc_afec,  df.cantidad AS num, " _
                    '     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                    '    & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                    '   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    '    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                    '   & " FROM detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND right(f.fecha,2) >= '" & txtdi1.Text & "'  " & cad & "  AND ( f.doc = df.doc ) "
                ElseIf p = cbini.Text <> p = cbfin.Text Then

                    sql = sql & " UNION SELECT f.doc , f.tipodoc , f.num, f.total, f.fecha, " _
                & " CAST(CONCAT(RIGHT(f.fecha,2),'/',MID(f.fecha,6,2),'/',LEFT(f.fecha,4)) AS CHAR(15)) AS cta_iva,  f.por_iva, f.iva, " _
                & " fp.descrip , fp.valor " _
                & " FROM facturas" & p & " f, facpagos" & p & " fp WHERE fp.doc= f.doc " & cad

                    '    sql = sql & " UNION SELECT f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent,  f.fecha ,  f.doc_afec, df.cantidad AS num, " _
                    '     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                    '    & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                    '   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    '    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                    '   & " FROM  detafac" & p & " df, facturas" & p & " f , terceros t WHERE f.nitc = t.nit AND ( f.doc = df.doc )  " & td & "  "
                ElseIf p = cbfin.Text Then

                    sql = sql & " UNION SELECT f.doc , f.tipodoc , f.num, f.total, f.fecha, " _
                & " CAST(CONCAT(RIGHT(f.fecha,2),'/',MID(f.fecha,6,2),'/',LEFT(f.fecha,4)) AS CHAR(15)) AS cta_iva,  f.por_iva, f.iva, " _
                & " fp.descrip , fp.valor " _
                & " FROM facturas" & p & " f, facpagos" & p & " fp WHERE fp.doc= f.doc " _
                & " AND right(f.fecha,2) <= '" & txtdi2.Text & "' " & cad

                    '    sql = sql & " UNION SELECT f.tipodoc, f.doc, f.hora as cta_iva, (TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) ) ) AS ciu_ent,  f.fecha ,  f.doc_afec, df.cantidad AS num, " _
                    '     & " CAST( (CONCAT( RIGHT( f . fecha , 2 ) ,  '/', MID( f . fecha ,  6, 2 ) ,  '/', LEFT( f . fecha , 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
                    '     & " ((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) AS subtotal, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100)))* f.por_desc /100) AS descuento, " _
                    '   & " (((df.vtotal-(df.vtotal*(df.por_des/100))) - (( ((df.vtotal-(df.vtotal*(df.por_des/100))) / ( 1 + ( df.iva_d /100 ) ))* f.por_desc /100)) - (((df.vtotal-(df.vtotal*(df.por_des/100)))-((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))))) - ((((df.vtotal-(df.vtotal*(df.por_des/100)))/(1+(df.iva_d /100))) * f.por_ret_f/100))) * df.iva_d/100) as iva, " _
                    '   & " (((df.vtotal/(1+(df.iva_d /100))) * f.por_ret_f/100)) AS ret_f, " _
                    '    & " (((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) - ( ((df.vtotal/(1+(df.iva_d/100))-(df.vtotal/(1+(df.iva_d/100)) *(df.por_des/100)) )) * (f.por_desc/100))) * (1+(df.iva_d/100)) AS total  " _
                    '   & " FROM  detafac" & p & " df, facturas" & p & " f, terceros t WHERE f.nitc = t.nit and  right(f.fecha,2) <= '" & txtdi2.Text & "'  " & td & "  AND ( f.doc = df.doc ) "
                End If
                End If

        Next

        'Sql = Sql & ") as c ORDER BY fecha ASC, cta_iva "

        'TODAS
        sql1 = " SELECT tipodoc, num, total, cta_iva, por_iva, iva FROM (" & sql & ") as c"

        '////////////////  FORMAS DE PAGO
        'Dim md() As String
        Dim pg As String = ""
        Dim despg As String = ""
        Dim vpg As String = ""
        Dim npg As String = ""
        'md = ("CHEQUE" & vbCrLf & "EFECTIVO").Split(Chr(Keys.Enter))

        pg = CambiaCadena("  MEDIOS DE PAGOS", 20) & CambiaCadena("     VALOR    ", 20) & "    N° TRANS" & vbCrLf
        sql2 = " SELECT descrip,(SUM(valor)) as s, COUNT(descrip) as can FROM (" & sql & ") as c GROUP BY descrip"
        Dim t2 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        If t2.Rows.Count > 0 Then
            For i = 0 To t2.Rows.Count - 1
                despg = despg & UCase(t2.Rows(i).Item("descrip")) & vbCrLf
                vpg = vpg & Moneda(t2.Rows(i).Item("s")) & vbCrLf
                npg = npg & t2.Rows(i).Item("can") & vbCrLf
                'pg = pg & Rpadv(t2.Rows(i).Item("descrip"), 20, " ") & lpadv(t2.Rows(i).Item("s"), 20, " ") & vbCrLf
            Next
        End If


        'IVA
        Dim desIv As String = ""
        Dim vIv As String = ""
        Dim nIv As String = ""
        sql3 = "SELECT por_iva, SUM(iva) as s, COUNT(por_iva) as can FROM (" & sql & ") as c GROUP BY por_iva"
        Dim t3 As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        If t3.Rows.Count > 0 Then
            For i = 0 To t3.Rows.Count - 1
                desIv = desIv & UCase(t3.Rows(i).Item("por_iva")) & vbCrLf
                vIv = vIv & Moneda(t3.Rows(i).Item("s")) & vbCrLf
                nIv = nIv & t3.Rows(i).Item("can") & vbCrLf
                'pg = pg & Rpadv(t2.Rows(i).Item("descrip"), 20, " ") & lpadv(t2.Rows(i).Item("s"), 20, " ") & vbCrLf
            Next
        End If

        'Dim doc As String = ""
        'For i = 0 To tabla.Rows.Count - 1
        '    If i <> tabla.Rows.Count - 1 Then
        '        doc = doc & " '" & tabla.Rows(i).Item("doc") & "' , "
        '    Else
        '        doc = doc & " '" & tabla.Rows(i).Item("doc") & "' "
        '    End If
        'Next

        'sql2 = "SELECT f.descrip, SUM(f.valor) , COUNT(f.descrip) FROM facpagos01 f WHERE" _
        '& " doc IN (" & doc & ") " _
        '& "GROUP BY descrip"

        'Dim tabl As New DataTable


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql1
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacDiario.rpt")
        CrReport.SetDataSource(tabla)
        'CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        FrmReportFacCon.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtitulo As New ParameterField
            Dim PrdA As New ParameterField
            Dim Prdsp As New ParameterField
            Dim Prdvp As New ParameterField
            Dim Prdnp As New ParameterField
            Dim PrdI As New ParameterField
            Dim PrvI As New ParameterField
            Dim PrnI As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "f1"
            Prperiodo.CurrentValues.AddValue(txtdi1.Text & "/" & cbini.Text & "/" & txtpini.Text)
            Prtitulo.Name = "f2"
            Prtitulo.CurrentValues.AddValue(txtdi1.Text & "/" & cbini.Text & "/" & txtpini.Text)

            PrdA.Name = "pg"
            PrdA.CurrentValues.AddValue(pg)
            Prdsp.Name = "dpg"
            Prdsp.CurrentValues.AddValue(despg)
            Prdvp.Name = "vpg"
            Prdvp.CurrentValues.AddValue(vpg)
            Prdnp.Name = "npg"
            Prdnp.CurrentValues.AddValue(npg)

            PrdI.Name = "dIv"
            PrdI.CurrentValues.AddValue(desIv)
            PrvI.Name = "vIv"
            PrvI.CurrentValues.AddValue(vIv)
            PrnI.Name = "nIv"
            PrnI.CurrentValues.AddValue(nIv)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtitulo)
            prmdatos.Add(PrdA)
            prmdatos.Add(Prdsp)
            prmdatos.Add(Prdvp)
            prmdatos.Add(Prdnp)
            prmdatos.Add(PrdI)
            prmdatos.Add(PrvI)
            prmdatos.Add(PrnI)

            FrmReportFacCon.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacCon.ShowDialog()

        Catch ex As Exception
            ' MsgBox(sql)
        End Try

    End Sub
    Public Function lpadv(ByVal cad As String, ByVal longi As Integer, ByVal car As String) As String
        Dim clen As Integer
        Dim temp As String
        'on local error resume next 
        'Tomamos la cadena enviada en el parámetro
        'eliminando los caracteres vacios izq-dch
        temp = Trim(cad)
        clen = Len(temp)
        'Analizamos si la longitud justificada es menos
        'que la propia cadena enviada en parámetro.
        If clen < longi Then
            temp = Strings.Space((longi - clen) & car) & temp
        End If
        lpadv = temp
    End Function

    Public Function Rpadv(ByVal cad As String, ByVal longi As Integer, ByVal car As String) As String
        Dim clen As Integer
        Dim temp As String
        temp = Trim(cad)
        clen = Len(temp)
        If clen < longi Then
            temp = temp & Strings.Space((longi - clen) & car)
        End If
        Rpadv = temp
    End Function
End Class