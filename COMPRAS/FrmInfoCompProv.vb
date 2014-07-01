Imports iTextSharp.text.pdf
Imports iTextSharp.text
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
Public Class FrmInfoCompProv

    Private Sub FrmInfoCompProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        '*********************
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT doc_fp, doc_aj FROM par_comp;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("doc_fp")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fp")))
                txttipo.Text = Trim(tabla.Rows(0).Item("doc_fp"))
            End If
            If Trim(tabla.Rows(0).Item("doc_aj")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_aj")))
            End If
        Catch ex As Exception
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
    Public consulta As String = ""
    Public tipo As String = ""
    Public dia1, mes1, dia2, mes2 As Integer
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'consulta = ""
        ''************PROVEEDOR********************
        'If c1.Checked = True Then
        '    consulta = consulta & " f.nitc<>'' "
        '    tipo = "TODOS LOS PROVEEDORES, "
        'Else
        '    If txtcliente.Text = "" Then
        '        MsgBox("Digite un nit del proovedor valido.  ", MsgBoxStyle.Information, "SAE Control")
        '        txtnitc.Focus()
        '        Exit Sub
        '    End If
        '    consulta = consulta & " f.nitc='" & txtnitc.Text & "' "
        '    tipo = "EL PROVEEDOR " & txtcliente.Text & ", "
        'End If
        ''************DOCUMENTO DE (AP, FP)********************
        'If doc2.Checked = True Then
        '    If txttipo2.Text = "" Then
        '        MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
        '        txttipo.Focus()
        '        Exit Sub
        '    End If
        '    consulta = consulta & " AND f.tipodoc='" & txttipo.Text & "' "
        'End If
        ''************ESTADO DEL DOCUMENTO********************
        'If e1.Checked = True Then 'DOC APROBADOS
        '    consulta = consulta & " AND f.estado='AP' "
        '    tipo = tipo & "DOCUMENTOS APROBADOS."
        'ElseIf e2.Checked = True Then 'DOC PENDIENTES
        '    consulta = consulta & " AND f.estado<>'AP' "
        '    tipo = tipo & "DOCUMENTOS PENDIENTES."
        'ElseIf e3.Checked = True Then 'DOC ANULADOS
        '    consulta = consulta & " AND f.anulado='si' "
        '    tipo = tipo & "DOCUMENTOS ANULADOS."
        'ElseIf e5.Checked = True Then 'DOC APROBADOS SIN ANULAR
        '    consulta = consulta & " AND f.anulado='no' AND f.estado='AP'"
        '    tipo = tipo & "DOCUMENTOS APROBADOS SIN ANULAR."
        'Else
        '    tipo = tipo & "TODOS LOS DOCUMENTOS."
        'End If
        ''********************************
        'dia1 = fecha1.Value.Day
        'mes1 = fecha1.Value.Month
        'dia2 = fecha2.Value.Day
        'mes2 = fecha2.Value.Month
        ''********************************
        'MiConexion(bda)
        'Cerrar()
        'GenerarPDf()



        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim per As String = ""
        Dim p As String = ""
        Dim cant As String = ""
        Dim tit As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        per = "PERIODO INICIAL: " & Strings.Mid(fecha1.Text, 4, 2) & " / " & Strings.Right(fecha1.Text, 4) & "  PERIODO FINAL: " & Strings.Mid(fecha2.Text, 4, 2) & " / " & Strings.Right(fecha2.Text, 4)
        tit = "INFORME COMPRAS POR PROVEEDOR"

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
        Dim d1, d2 As String

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)
        d1 = Strings.Left(fecha1.Text, 2)
        d2 = Strings.Left(fecha2.Text, 2)

        Dim cad As String = ""
        If c2.Checked = True Then ' Un nit
            cad = cad & " AND f.nitc= '" & txtnitc.Text & "' AND t.nit= '" & txtnitc.Text & "' "
        End If
        If doc2.Checked = True Then ' Un doc
            cad = cad & " AND f.tipodoc = '" & txttipo.Text & "' "
        End If
        If e1.Checked = True Then ' AP
            cad = cad & " AND f.estado =  'AP' "
        End If
        If e2.Checked = True Then ' PENDIENTES
            cad = cad & " AND f.estado =  '' "
        End If
        If e3.Checked = True Then ' ANULADOS
            cad = cad & " AND f.anulado = 'si' "
        End If
        If e5.Checked = True Then ' APRO SIN ANULAR
            cad = cad & " AND f.estado='AP' AND f.anulado = 'no' "
        End If

        If chRs.Checked = False Then
            '//////////////////////////////////
            For i = Val(m1) To Val(m2)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If p = m1 Then
                    sql = "  SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc,CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha, dc.cantidad AS num, " _
                    & " dc.valor/(1+(dc.por_iva_g/100)) AS v1 , f.doc_afec as usuario," _
                    & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad) AS descuento, " _
                    & " ((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad) AS iva, " _
                    & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad) AS ret_f, " _
                    & " (dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad AS Subtotal, " _
                    & " dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) AS v2 " _
                    & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t " _
                    & " WHERE  (f.doc = dc.doc) AND f.nitc = t.nit " & cad

                Else
                    sql = sql & " UNION SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc, CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha, dc.cantidad AS num, " _
                     & " dc.valor/(1+(dc.por_iva_g/100)) AS v1 , f.doc_afec as usuario," _
                    & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad) AS descuento, " _
                    & " ((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad) AS iva, " _
                    & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad) AS ret_f, " _
                    & " (dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad AS Subtotal, " _
                    & " dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) AS v2 " _
                    & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t " _
                    & " WHERE  (f.doc = dc.doc) AND f.nitc = t.nit " & cad
                End If
            Next

            sql = sql & " ORDER BY nombre "


            '' //////////////////  ////////////////



            TextBox1.Text = sql


            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCcomXpro.rpt")
            CrReport.SetDataSource(tabla)
            Try
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            Catch ex As Exception
            End Try
            FrmReportCcomXpro.CrystalReportViewer1.ReportSource = CrReport

            Dim doc_aj As String = ""
            Dim tb As New DataTable
            tb = New DataTable
            myCommand.CommandText = "SELECT doc_aj FROM `par_comp` "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            doc_aj = tb.Rows(0).Item(0)

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtitulo As New ParameterField
                Dim PrAJ As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtitulo.Name = "titulo"
                Prtitulo.CurrentValues.AddValue(tit.ToString)

                PrAJ.Name = "doc_aj"
                PrAJ.CurrentValues.AddValue(doc_aj.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtitulo)
                prmdatos.Add(PrAJ)
                FrmReportCcomXpro.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCcomXpro.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else

            Dim doc_aj As String = ""
            Try
                Dim tb As New DataTable
                tb = New DataTable
                myCommand.CommandText = "SELECT doc_aj FROM `par_comp` "
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb)
                doc_aj = tb.Rows(0).Item(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            '//////////////////////////////////

            sql = " SELECT concat(c.nitc,'__',c.ciu_ent) descrip, SUM(c.num) num, SUM(c.v1) v1, SUM(c.descuento) descuento, SUM(c.ret_f) ret_f, SUM(c.subtotal) subtotal," _
            & " SUM(c.iva) iva, SUM(c.v2) v2 FROM ( "

            For i = Val(m1) To Val(m2)
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If

                If Val(m1) = Val(m2) Then
                    sql = sql & "  SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc,CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, " _
& " CAST( f.fecha AS CHAR( 20 ) ) AS fecha, " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.cantidad),dc.cantidad) num,   " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.valor/(1+(dc.por_iva_g/100))),dc.valor/(1+(dc.por_iva_g/100)))  v1, " _
& "  f.doc_afec AS usuario,  " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) descuento, " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)),((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)) iva, " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) ret_f, " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad),(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad) subtotal,   " _
& " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) " _
& " ,dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) v2  " _
& " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t  " _
& "  WHERE  (f.doc = dc.doc) AND f.nitc = t.nit and  RIGHT(f.fecha,2) BETWEEN '" & d1 & "' and '" & d2 & "' " & cad
                Else
                    If i = Val(m1) Then
                        sql = sql & "  SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc,CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, " _
    & " CAST( f.fecha AS CHAR( 20 ) ) AS fecha, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.cantidad),dc.cantidad) num,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.valor/(1+(dc.por_iva_g/100))),dc.valor/(1+(dc.por_iva_g/100)))  v1, " _
    & "  f.doc_afec AS usuario,  " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) descuento, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)),((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)) iva, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) ret_f, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad),(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad) subtotal,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) " _
    & " ,dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) v2  " _
    & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t   " _
    & "  WHERE  (f.doc = dc.doc) AND f.nitc = t.nit and  RIGHT(f.fecha,2) >= '" & d1 & "' " & cad
                    ElseIf i <> Val(m1) Or i <> Val(m2) Then
                        sql = sql & "  UNION  SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc,CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, " _
    & " CAST( f.fecha AS CHAR( 20 ) ) AS fecha, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.cantidad),dc.cantidad) num,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.valor/(1+(dc.por_iva_g/100))),dc.valor/(1+(dc.por_iva_g/100)))  v1, " _
    & "  f.doc_afec AS usuario,  " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) descuento, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)),((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)) iva, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) ret_f, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad),(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad) subtotal,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) " _
    & " ,dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) v2  " _
    & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t  " _
    & "  WHERE  (f.doc = dc.doc) AND f.nitc = t.nit " & cad
                    ElseIf i = Val(m2) Then
                        sql = sql & " UNION  SELECT f.nitc, t.nombre, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc,CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, " _
    & " CAST( f.fecha AS CHAR( 20 ) ) AS fecha, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.cantidad),dc.cantidad) num,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.valor/(1+(dc.por_iva_g/100))),dc.valor/(1+(dc.por_iva_g/100)))  v1, " _
    & "  f.doc_afec AS usuario,  " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) descuento, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)),((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad)) iva, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)),(((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) ret_f, " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad),(dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad) subtotal,   " _
    & " IF (LEFT(f.doc,2)='" & doc_aj & "',CONCAT('-',dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) " _
    & " ,dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) ) v2  " _
    & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t  " _
    & "  WHERE  (f.doc = dc.doc) AND f.nitc = t.nit and  RIGHT(f.fecha,2) <= '" & d2 & "' " & cad
                    End If
                End If
            Next

            sql = sql & " ) AS c   GROUP BY c.nitc ORDER BY c.nombre "
            Dim tabla As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportComXproR.rpt")
            CrReport.SetDataSource(tabla)
            Try
                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
            Catch ex As Exception
            End Try
            FrmReportCcomXpro.CrystalReportViewer1.ReportSource = CrReport


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
                Prperiodo.Name = "rg"
                Prperiodo.CurrentValues.AddValue("FECHA INICIAL:" & fecha1.Text & "  - FECHA FINAL:" & fecha2.Text)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)

                FrmReportCcomXpro.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCcomXpro.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If


    End Sub
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GenerarPDf()
        Dim per As String = ""
        Dim tabla As New DataTable
        Dim items As Integer = 0
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        Dim subdes, subrtf, subtotal, subiva, subvtotal As Double
        Dim tdes, trtf, tsub, tiva, total As Double
        Dim tope As Integer = 80
        Try
            '**********************************************************************
            Dim tablacomp, tablater As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            '**********************************************************************
            pag = 1
            tope = 80
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********************************
            cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
            cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
            cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "   FECHA FINAL: " & fecha2.Text, 20, 770, 0)
            cb.ShowTextAligned(50, "REPORTE GENERADO PARA: " & tipo, 20, 760, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE COMPRAS A PROVEEDORES", 300, 750, 0)
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 740, 0)
            '****************************
            k = 720
            cb.ShowTextAligned(50, "DOC", 7, k, 0)
            cb.ShowTextAligned(50, "FECHA", 48, k, 0)
            cb.ShowTextAligned(50, "ARTICULO/GASTO", 90, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 235, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PRECIO", 300, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "UNITARIO", 300, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESCUENTOS", 360, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "EN ITEMS", 360, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETECION EN", 410, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "LA FUENTE", 410, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUBTOTAL", 470, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "I.V.A.", 530, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUBTOT + IVA", 590, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "- RTF - DESC", 590, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, k, 0)
            k = k - 5
            '******************************
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            '********************************************************************************
            tdes = 0
            trtf = 0
            tsub = 0
            tiva = 0
            total = 0
            '**********
            subdes = 0
            subrtf = 0
            subtotal = 0
            subiva = 0
            subvtotal = 0
            Dim ter As String = ""
            For p = mes1 To mes2
                If p < 10 Then
                    per = "0" & p
                Else
                    per = p
                End If
                tabla.Clear()
                myCommand.CommandText = "SELECT t.nombre, t.apellidos, f.doc, f.fecha, d.nom_art, d.cantidad, d.valor," _
                & "(f.por_desc * d.vtotal/100) AS descuento,(d.vtotal/(1+d.por_iva_g/100)) AS subtotal,(f.por_rtf * (d.vtotal/(1+d.por_iva_g/100))/100) AS rtf,(d.vtotal-(d.vtotal/(1+d.por_iva_g/100))) AS iva, (d.vtotal-(f.por_desc * d.vtotal/100)- (f.por_rtf * (d.vtotal/(1+d.por_iva_g/100))/100) ) AS vtotal" _
                & " FROM fact_comp" & per & " f LEFT JOIN (detacomp" & per & " d, terceros t)" _
                & " ON d.doc=f.doc AND f.nitc=t.nit" _
                & " WHERE " & consulta & " ORDER BY t.nombre, t.apellidos, f.doc, d.item;"
                'MsgBox(myCommand.CommandText.ToString)
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                subtotal = 0
                For i = 0 To items - 1
                    If ter <> tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos") Then
                        If ter <> "" Then 'HAY SUBTOTAL
                            k = k - 5
                            cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                            k = k - 10
                            cb.ShowTextAligned(50, "*** SUB TOTAL PROVEEDOR: ", 150, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subdes), 360, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subrtf), 410, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 470, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subiva), 530, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subvtotal), 590, k, 0)
                        End If
                        k = k - 15
                        cb.ShowTextAligned(50, "*** PROVEEDOR: " & tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos"), 10, k, 0)
                        ter = tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos")
                        subdes = 0
                        subrtf = 0
                        subtotal = 0
                        subiva = 0
                        subvtotal = 0
                    End If
                    k = k - 10
                    If k <= tope Then
                        pag = pag + 1
                        '***********************BANNER***************************************************
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        '********************************
                        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "   FECHA FINAL: " & fecha2.Text, 20, 770, 0)
                        cb.ShowTextAligned(50, "REPORTE GENERADO PARA: " & tipo, 20, 760, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE COMPRAS A PROVEEDORES", 300, 750, 0)
                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
                        '****************************
                        k = 720
                        cb.ShowTextAligned(50, "DOC", 7, k, 0)
                        cb.ShowTextAligned(50, "FECHA", 48, k, 0)
                        cb.ShowTextAligned(50, "ARTICULO/GASTO", 90, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 235, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PRECIO", 300, k + 10, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "UNITARIO", 300, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DESCUENTOS", 360, k + 10, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "EN ITEMS", 360, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "RETECION EN", 410, k + 10, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "LA FUENTE", 410, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUBTOTAL", 470, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "I.V.A.", 530, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUBTOT + IVA", 590, k + 10, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "- RTF - DESC", 590, k, 0)
                        k = k - 10
                        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
                        k = k - 5
                        '******************************
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 6)
                        k = k - 10
                        '********************************************************************************
                    End If
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 8, k, 0)
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha"), 48, k, 0)
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nom_art"), 30), 90, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda(tabla.Rows(i).Item("cantidad")), 235, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("valor")), 300, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("descuento")), 360, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("rtf")), 410, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("subtotal")), 470, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("iva")), 530, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("vtotal")), 590, k, 0)
                    '******************************************************************
                    subdes = subdes + (Moneda(tabla.Rows(i).Item("descuento")))
                    subrtf = subrtf + (Moneda(tabla.Rows(i).Item("rtf")))
                    subtotal = subtotal + (Moneda(tabla.Rows(i).Item("subtotal")))
                    subiva = subiva + (Moneda(tabla.Rows(i).Item("iva")))
                    subvtotal = subvtotal + (Moneda(tabla.Rows(i).Item("vtotal")))
                    '******************************************************************
                    tdes = tdes + (Moneda(tabla.Rows(i).Item("descuento")))
                    trtf = trtf + (Moneda(tabla.Rows(i).Item("rtf")))
                    tsub = tsub + (Moneda(tabla.Rows(i).Item("subtotal")))
                    tiva = tiva + (Moneda(tabla.Rows(i).Item("iva")))
                    total = total + (Moneda(tabla.Rows(i).Item("vtotal")))
                Next
            Next
            If ter <> "" Then 'HAY SUBTOTAL
                k = k - 5
                cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "*** SUB TOTAL PROVEEDOR: ", 150, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subdes), 360, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subrtf), 410, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 470, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subiva), 530, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subvtotal), 590, k, 0)
            End If
            k = k - 5
            cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "***  TOTAL  GENERAL  *** ", 150, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tdes), 360, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(trtf), 410, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tsub), 470, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tiva), 530, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total), 590, k, 0)
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtnitc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnitc.KeyPress
        ValidarNIT(txtnitc, e)
    End Sub
    Private Sub txtnitc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnitc.LostFocus
        If txtcliente.Text = "" Then
            txtnitc.Text = ""
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
            FrmSelCliente.lbform.Text = "com_inf_pro"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            chcli.Visible = True
            chcli.Checked = False
            'txtnitc.Focus()
        Else
            txtnitc.Enabled = False
            chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then
            txtnitc.Enabled = False
        End If
    End Sub
    Private Sub doc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doc1.CheckedChanged
        If doc1.Checked = True Then
            txttipo.Enabled = False
        End If
    End Sub
    Private Sub doc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doc2.CheckedChanged
        If doc2.Checked = True Then
            txttipo.Enabled = True
        End If
    End Sub

    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                txttipo2.Text = ""
                Exit Sub
            End If
            txttipo2.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
            txttipo2.Text = ""
        End Try
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
                FrmSelCliente.lbform.Text = "com_inf_pro"
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
            FrmSelCliente.lbform.Text = "com_inf_pro"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class