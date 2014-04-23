Imports iTextSharp.text
Imports iTextSharp.text.pdf
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

Public Class FrmImpFacturas
    Private Sub FrmImpFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbdocumentos.Text = "Aprobados"
        cbde.Text = "Inventarios"
        txtpe1.Text = "/" & PerActual
        txtpe2.Text = "/" & PerActual
        txtfechaini.Text = "01"
        txtfechafin.Text = Now.Day
        '************************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT tipof1,tipof2,tipof3,tipof4,tipoaj FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        If Trim(tabla.Rows(0).Item("tipof1")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof1")))
            txttipo.Text = Trim(tabla.Rows(0).Item("tipof1"))
        End If
        If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
        End If
        If Trim(tabla.Rows(0).Item("tipof3")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof3")))
        End If
        If Trim(tabla.Rows(0).Item("tipof4")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipof4")))
        End If
        If Trim(tabla.Rows(0).Item("tipoaj")) <> "" Then
            txttipo.Items.Add(Trim(tabla.Rows(0).Item("tipoaj")))
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT formatfac,imp_dec FROM parafacts WHERE factura='RAPIDA';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item("formatfac") = "pdf" Then
                mostrar_pdf()
            ElseIf tabla.Rows(0).Item("formatfac") = "pdf2" Then
                mostrar_pdf2()
            Else
                ' GenerarTicket()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
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
        BuscarDocumento()
    End Sub
    Public Sub BuscarDocumento()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT min(num),max(num) FROM facturas" & PerActual(0) & PerActual(1) & "  WHERE tipodoc='" & txttipo.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            txtdocini.Text = NumeroDoc(tabla.Rows(0).Item(0))
            txtdocfin.Text = NumeroDoc(tabla.Rows(0).Item(1))
        Catch ex As Exception
            txtdocini.Text = NumeroDoc(0)
            txtdocfin.Text = NumeroDoc(0)
        End Try

    End Sub

    Private Sub rbdoc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdoc1.CheckedChanged
        txtdocini.Enabled = False
        txtdocfin.Enabled = False
    End Sub
    Private Sub rbdoc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdoc2.CheckedChanged
        txtdocini.Enabled = True
        txtdocfin.Enabled = True
    End Sub
    Private Sub rbfecha1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfecha1.CheckedChanged
        txtfechaini.Enabled = False
        txtfechafin.Enabled = False
    End Sub
    Private Sub rbfecha2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfecha2.CheckedChanged
        txtfechaini.Enabled = True
        txtfechafin.Enabled = True
    End Sub

    Public Sub mostrar_pdf()
        Try
            MiConexion(bda)
            Cerrar()

            Dim pre As String = ""
            Dim fac As String = ""
            Dim res As String = ""
            Dim nom As String = ""
            Dim nit As String = ""
            Dim tel As String = ""
            Dim dir As String = ""
            Dim email As String = ""
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""

            Dim p As String = ""
            Dim tdoc As String = ""
            Dim rdoc As String = ""
            Dim fdoc As String = ""
            Dim ddoc As String = ""
            Dim f1 As Integer = 0
            Dim f2 As Integer = 0

            p = PerActual(0).ToString & PerActual(1).ToString

            '.........
            If cbdocumentos.Text = "Aprobados" Then
                tdoc = " and f.estado = 'AP' "
            End If
            If cbdocumentos.Text = "Pendientes" Then
                tdoc = " and f.estado = '' "
            End If
            If cbdocumentos.Text = "Anulados" Then
                tdoc = " and  LEFT(f.descrip,7)='ANULADO' "
            End If
            '.........
            If rbdoc2.Checked = True Then
                rdoc = " AND f.doc BETWEEN '" & txttipo.Text & txtdocini.Text & "' AND  '" & txttipo.Text & txtdocfin.Text & "  '"
            End If
            '...........
            If rbfecha2.Checked = True Then
                fdoc = " AND CAST(Right(f . fecha,2) AS CHAR(5)) BETWEEN '" & txtfechaini.Text & "' and '" & txtfechafin.Text & "' "
            End If
            '..........
            If cbde.Text = "Inventarios" Then
                ddoc = " AND f.doc_de = 'I' "
            End If
            If cbde.Text = "Servicios y Otros Items" Then
                ddoc = " AND f.doc_de <> 'I' "
            End If

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT. " & tabla2.Rows(0).Item("nit")
            dir = tabla2.Rows(0).Item("direccion")
            tel = "TEL. " & tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
            email = tabla2.Rows(0).Item("emailconta")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " select f.doc,v.nombre as nitv, f.observ, f.num,  " _
            & " CAST(CONCAT(Right(f . fecha,2),'/',mid(f . fecha,6,2),'/',left(f . fecha,4)) AS CHAR(20) )as cta1, " _
            & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 2 ) ,  '/', MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 6, 2 ) ,  '/', LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
            & " f.nitc, CONCAT(t.nombre,' ',t.apellidos) as usuario, t.dir as cta2, t.telefono as cta3, " _
            & " f.observ as obs, f.descuento, f.iva, f.total,f.ret_f , f.ret_ica  , f.ret_iva  " _
            & " from  parafacgral pg, vendedores v, facturas" & p & " f  LEFT JOIN terceros t ON ( f.nitc = t.nit )  " _
            & " WHERE f.nitv = v.nitv and f.tipodoc = '" & txttipo.Text & "' " & tdoc & " " & rdoc & " " & fdoc & " " & ddoc & " order by doc "


            sql2 = " select pf.logofac,  " _
            & " CASE ('" & txttipo.Text & "' )  " _
            & " WHEN pg.tipof1   " _
            & " THEN IF (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '')  " _
            & " WHEN pg.tipof2   " _
            & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof3   " _
            & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof4   " _
            & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '')  " _
            & " END AS res, " _
             & " CASE ('" & txttipo.Text & "' ) " _
            & " WHEN pg.tipof1 " _
            & " THEN IF (pg.hr1='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
            & " WHEN pg.tipof2 " _
            & " THEN IF (pg.hr2='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
            & " WHEN pg.tipof3 " _
            & " THEN IF (pg.hr3='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
            & " WHEN pg.tipof4 " _
            & " THEN IF (pg.hr4='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
            & " END AS tfac, pf.comentario, " _
             & " CASE 'SI' " _
            & " WHEN pg.hr1 THEN pg.pre1 " _
            & " WHEN pg.hr2 THEN pg.pre2 " _
            & " WHEN pg.hr3 THEN pg.pre3 " _
            & " WHEN pg.hr4 THEN pg.pre4 " _
            & " END AS pref " _
            & " from  parafacts pf, parafacgral pg where factura = 'RAPIDA'   "

            sql3 = "select d.item, d.doc, d.codart, d.nomart, d.cantidad , d.iva_d,  (d.valor/(1+(d.iva_d/100))) as valor, " _
            & " ( (d.valor/(1+(d.iva_d/100))) * d.cantidad   ) as vtotal " _
            & " from detafac" & p & " d order by doc, item"

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql2
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "parafacts")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql3
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "detafac01")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "facturas01")

            TextBox1.Text = sql2

            Dim tablaa As DataTable
            tablaa = New DataTable
            myCommand.CommandText = sql2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaa)
            If tablaa.Rows.Count > 0 Then
                res = tablaa.Rows(0).Item("res")
                fac = tablaa.Rows(0).Item("tfac")
                pre = tablaa.Rows(0).Item("pref")
            End If


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacVariasR.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportFacVarias.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prtel As New ParameterField
                Dim Prdir As New ParameterField
                Dim Prres As New ParameterField
                Dim Prfac As New ParameterField
                Dim Prprf As New ParameterField


                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prtel.Name = "telef"
                Prtel.CurrentValues.AddValue(tel.ToString)

                Prdir.Name = "dir"
                Prdir.CurrentValues.AddValue(dir.ToString)

                Prres.Name = "res"
                Prres.CurrentValues.AddValue(res.ToString)

                Prfac.Name = "fac"
                Prfac.CurrentValues.AddValue(fac.ToString)

                Prprf.Name = "pref"
                Prprf.CurrentValues.AddValue(pre.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prtel)
                prmdatos.Add(Prdir)
                prmdatos.Add(Prres)
                prmdatos.Add(Prfac)
                prmdatos.Add(Prprf)

                FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacVarias.ShowDialog()

            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try

    End Sub
    Public Sub mostrar_pdf2()

        Try

        
            MiConexion(bda)
            Cerrar()

            Dim pre As String = ""
            Dim fac As String = ""
            Dim res As String = ""
            Dim nom As String = ""
            Dim nit As String = ""
            Dim tel As String = ""
            Dim dir As String = ""
            Dim email As String = ""
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""

            Dim p As String = ""
            Dim tdoc As String = ""
            Dim rdoc As String = ""
            Dim fdoc As String = ""
            Dim ddoc As String = ""
            Dim f1 As Integer = 0
            Dim f2 As Integer = 0

            p = PerActual(0).ToString & PerActual(1).ToString

            '.........
            If cbdocumentos.Text = "Aprobados" Then
                tdoc = " and f.estado = 'AP' "
            End If
            If cbdocumentos.Text = "Pendientes" Then
                tdoc = " and f.estado = '' "
            End If
            If cbdocumentos.Text = "Anulados" Then
                tdoc = " and  LEFT(f.descrip,7)='ANULADO' "
            End If
            '.........
            If rbdoc2.Checked = True Then
                rdoc = " AND f.doc BETWEEN '" & txttipo.Text & txtdocini.Text & "' AND  '" & txttipo.Text & txtdocfin.Text & "  '"
            End If
            '...........
            If rbfecha2.Checked = True Then
                fdoc = " AND CAST(Right(f . fecha,2) AS CHAR(5)) BETWEEN '" & txtfechaini.Text & "' and '" & txtfechafin.Text & "' "
            End If
            '..........
            If cbde.Text = "Inventarios" Then
                ddoc = " AND f.doc_de = 'I' "
            End If
            If cbde.Text = "Servicios y Otros Items" Then
                ddoc = " AND f.doc_de <> 'I' "
            End If

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")
            dir = tabla2.Rows(0).Item("direccion")
            tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
            email = tabla2.Rows(0).Item("emailconta")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " select f.doc,v.nombre as nitv, f.observ, f.num,  " _
            & " CAST(CONCAT(Right(f . fecha,2),'/',mid(f . fecha,6,2),'/',left(f . fecha,4)) AS CHAR(20) )as cta1, " _
            & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 2 ) ,  '/', MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 6, 2 ) ,  '/', LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
            & " f.nitc, CONCAT(t.nombre,' ',t.apellidos) as usuario, t.dir as cta2, t.telefono as cta3, " _
            & " f.observ as obs, f.descuento, f.iva, f.total,f.ret_f , f.ret_ica  , f.ret_iva  " _
            & " from  parafacgral pg, vendedores v, facturas" & p & " f  LEFT JOIN terceros t ON ( f.nitc = t.nit )  " _
            & " WHERE f.nitv = v.nitv and f.tipodoc = '" & txttipo.Text & "' " & tdoc & " " & rdoc & " " & fdoc & " " & ddoc & " order by doc "


            sql2 = " select pf.logofac,  " _
            & " CASE ('" & txttipo.Text & "' )  " _
            & " WHEN pg.tipof1   " _
            & " THEN IF (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '')  " _
            & " WHEN pg.tipof2   " _
            & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof3   " _
            & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof4   " _
            & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '')  " _
            & " END AS res, " _
             & " CASE ('" & txttipo.Text & "' ) " _
            & " WHEN pg.tipof1 " _
            & " THEN IF (pg.hr1='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
            & " WHEN pg.tipof2 " _
            & " THEN IF (pg.hr2='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
            & " WHEN pg.tipof3 " _
            & " THEN IF (pg.hr3='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
            & " WHEN pg.tipof4 " _
            & " THEN IF (pg.hr4='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
            & " END AS tfac, pf.comentario, " _
             & " CASE 'SI' " _
            & " WHEN pg.hr1 THEN pg.pre1 " _
            & " WHEN pg.hr2 THEN pg.pre2 " _
            & " WHEN pg.hr3 THEN pg.pre3 " _
            & " WHEN pg.hr4 THEN pg.pre4 " _
            & " END AS pref " _
            & " from  parafacts pf, parafacgral pg where factura = 'RAPIDA'   "

            sql3 = "select d.item, d.doc, d.codart, d.nomart, d.cantidad , d.iva_d,  (d.valor/(1+(d.iva_d/100))) as valor, " _
            & " ( (d.valor/(1+(d.iva_d/100))) * d.cantidad   ) as vtotal " _
            & " from detafac" & p & " d order by doc, item"

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql2
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "parafacts")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql3
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "detafac01")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "facturas01")

            TextBox1.Text = sql2

            Dim tablaa As DataTable
            tablaa = New DataTable
            myCommand.CommandText = sql2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaa)
            If tablaa.Rows.Count > 0 Then
                res = tablaa.Rows(0).Item("res")
                fac = tablaa.Rows(0).Item("tfac")
                pre = tablaa.Rows(0).Item("pref")
            End If



            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacVarias.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportFacVarias.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtel As New ParameterField
                Dim PrEmail As New ParameterField
                Dim Prdir As New ParameterField
                Dim Prres As New ParameterField
                Dim Prfac As New ParameterField
                Dim Prprf As New ParameterField


                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prtel.Name = "telef"
                Prtel.CurrentValues.AddValue(tel.ToString)

                Prdir.Name = "dir"
                Prdir.CurrentValues.AddValue(dir.ToString)

                PrEmail.Name = "email"
                PrEmail.CurrentValues.AddValue(email.ToString)

                Prres.Name = "res"
                Prres.CurrentValues.AddValue(res.ToString)

                Prfac.Name = "fac"
                Prfac.CurrentValues.AddValue(fac.ToString)

                Prprf.Name = "pref"
                Prprf.CurrentValues.AddValue(pre.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prtel)
                prmdatos.Add(Prdir)
                prmdatos.Add(PrEmail)
                prmdatos.Add(Prres)
                prmdatos.Add(Prfac)
                prmdatos.Add(Prprf)

                FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacVarias.ShowDialog()

            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try

    End Sub

    'Public Sub mostrar_pdf()
    '    Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
    '    Dim pdfw As iTextSharp.text.pdf.PdfWriter
    '    Dim cb As PdfContentByte
    '    Dim fuente As iTextSharp.text.pdf.BaseFont
    '    Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\facturacion.pdf"
    '    Dim i, k, pag, no, c, par As Integer
    '    Dim sumavalor, sumaiva, sumasub, sumavalor1, sumaiva1, sumasub1, iva As Double
    '    Dim tabla, tabla1, tabla2 As New DataTable
    '    Dim cadena, t1, t2, t3, tp, cad1, cad2, cad3, consulta, consulta2 As String
    '    par = 0
    '    sumavalor1 = 0
    '    sumaiva1 = 0
    '    sumasub1 = 0
    '    pag = 1
    '    sumaiva = 0
    '    sumavalor = 0
    '    sumasub = 0
    '    c = 0
    '    iva = 0
    '    cad2 = ""
    '    cad3 = ""
    '    pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
    '        FileMode.Create, FileAccess.Write, FileShare.None))
    '    oDoc.Open()
    '    cb = pdfw.DirectContent
    '    oDoc.NewPage()
    '    cb.BeginText()
    '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '    cb.SetFontAndSize(fuente, 9)
    '    Refresh()
    '    myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
    '    myAdapter.SelectCommand = myCommand
    '    myAdapter.Fill(tabla)
    '    cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
    '    cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
    '    cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
    '    cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
    '    cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
    '    cadena = "IMPRIMIR DOCUMENTOS"
    '    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
    '    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 740, 0)
    '    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 730, 0)
    '    k = 700
    '    no = 0
    '    cb.EndText()
    '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '    cb.SetFontAndSize(fuente, 7)
    '    cb.BeginText()


    '    cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 8, 0)
    '    cb.ShowTextAligned(50, "FECHA", 80, k - 8, 0)
    '    cb.ShowTextAligned(50, "NIT/CC", 130, k - 8, 0)
    '    cb.ShowTextAligned(50, "NOMBRE", 200, k - 8, 0)
    '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 585, k - 8, 0)
    '    cad1 = " ORDER BY codart,nomart"



    '    k = k - 30

    '    t1 = bda & ".facturas" & Mid(PerActual, 1, 2)
    '    t2 = bda & ".detafac" & Mid(PerActual, 1, 2)
    '    t3 = bda


    '    consulta = ""
    '    consulta2 = ""
    '    consulta = "SELECT " & t1 & ".doc," & t2 & ".nomart," & t1 & ".tipodoc," & t1 & ".num,DATE_FORMAT(" & t1 & ".fecha,'%d/%m/%y') as fecha," & t3 & ".terceros.nit," & t3 & ".terceros.nombre," & t3 & ".terceros.apellidos," & t1 & ".total," & t2 & ".valor as subtotal," & t1 & ".descuento," & t1 & ".iva," & t2 & ".vtotal," & t2 & ".iva_d," & t2 & ".valor  FROM " & t3 & ".terceros INNER JOIN (" & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc) ON " & t1 & ".nitc=" & t3 & ".terceros.nit where " & t1 & ".tipodoc='" & txttipo.Text & "' "
    '    If cbdocumentos.Text = "Aprobados" Then
    '        consulta = consulta & " AND " & t1 & ".estado='AP'"
    '    Else
    '        If cbdocumentos.Text = "Pendientes" Then
    '            consulta = consulta & " AND " & t1 & ".estado=''"
    '        Else

    '        End If
    '    End If

    '    If cbde.Text = "Inventarios" Then
    '        consulta = consulta & " AND " & t1 & ".doc_de='I' "
    '    Else
    '        If cbde.Text = "Servicios y Otros Items" Then
    '            consulta = consulta & " AND " & t1 & ".doc_de='S' "
    '        End If
    '    End If

    '    If rbdoc2.Checked = True Then
    '        consulta = consulta & " AND (" & t1 & ".num>='" & txtdocini.Text & "' AND " & t1 & ".num<='" & txtdocfin.Text & "') "
    '    End If

    '    If rbfecha2.Checked = True Then
    '        consulta = consulta & " AND (DAYOFMONTH(DATE(" & t1 & ".fecha)) BETWEEN '" & txtfechaini.Text & "' AND '" & txtfechafin.Text & "') "
    '    End If

    '    cb.EndText()
    '    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '    cb.SetFontAndSize(fuente, 7)
    '    cb.BeginText()

    '    consulta = consulta & "ORDER BY " & t1 & ".doc;"
    '    myCommand.CommandText = consulta

    '    myAdapter.SelectCommand = myCommand
    '    tabla = New DataTable
    '    myAdapter.Fill(tabla)
    '    tp = ""
    '    For i = 0 To tabla.Rows.Count - 1

    '        cb.EndText()
    '        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '        cb.SetFontAndSize(fuente, 7)
    '        cb.BeginText()
    '        cad3 = Trim(tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString)
    '        If Len(cad3) > 100 Then
    '            cad3 = CambiaCadena(cad3, 100)
    '        End If
    '        cb.ShowTextAligned(50, tabla.Rows(i).Item("doc").ToString, 20, k, 0)
    '        cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha").ToString, 80, k, 0)
    '        cb.ShowTextAligned(50, tabla.Rows(i).Item("nit").ToString, 130, k, 0)
    '        cb.ShowTextAligned(50, cad3, 200, k, 0)
    '        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("total").ToString), 585, k, 0)
    '        k = k - 10



    '        sumavalor = sumavalor + Val(Val(tabla.Rows(i).Item("total").ToString))

    '        'k = k - 8

    '        If k <= 80 Then
    '            cb.EndText()
    '            oDoc.NewPage()
    '            k = 730
    '            pag = pag + 1
    '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '            cb.SetFontAndSize(fuente, 9)
    '            Refresh()
    '            cb.BeginText()
    '            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
    '            myAdapter.SelectCommand = myCommand
    '            myAdapter.Fill(tabla)
    '            cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion").ToString, 20, 810, 0)
    '            cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
    '            cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
    '            cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
    '            cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
    '            k = 700
    '            cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 8, 0)
    '            cb.ShowTextAligned(50, "FECHA", 60, k - 8, 0)
    '            cb.ShowTextAligned(50, "NIT/CC", 130, k - 8, 0)
    '            cb.ShowTextAligned(50, "NOMBRE", 200, k - 8, 0)
    '            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 585, k - 8, 0)
    '            cb.EndText()
    '        End If

    '    Next


    '    cb.EndText()
    '    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
    '    cb.SetFontAndSize(fuente, 7)

    '    cb.BeginText()
    '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "____________________", 586, k, 0)
    '    k = k - 10
    '    cb.ShowTextAligned(50, "VALOR TOTAL", 20, k, 0)
    '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumavalor), 585, k, 0)
    '    cb.EndText()
    '    pdfw.Flush()
    '    oDoc.Close()
    '    Try
    '        AbrirArchivo(NombreArchivo)
    '    Catch ex As Exception
    '        AbrirArchivo(NombreArchivo)
    '        Exit Try
    '    End Try

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

        
            MiConexion(bda)
            Cerrar()

            Dim pre As String = ""
            Dim fac As String = ""
            Dim res As String = ""
            Dim nom As String = ""
            Dim nit As String = ""
            Dim tel As String = ""
            Dim dir As String = ""
            Dim email As String = ""
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""

            Dim p As String = ""
            Dim tdoc As String = ""
            Dim rdoc As String = ""
            Dim fdoc As String = ""
            Dim ddoc As String = ""
            Dim f1 As Integer = 0
            Dim f2 As Integer = 0

            p = PerActual(0).ToString & PerActual(1).ToString

            '.........
            If cbdocumentos.Text = "Aprobados" Then
                tdoc = " and f.estado = 'AP' "
            End If
            If cbdocumentos.Text = "Pendientes" Then
                tdoc = " and f.estado = '' "
            End If
            If cbdocumentos.Text = "Anulados" Then
                tdoc = " and  LEFT(f.descrip,7)='ANULADO' "
            End If
            '.........
            If rbdoc2.Checked = True Then
                rdoc = " AND f.doc BETWEEN '" & txttipo.Text & txtdocini.Text & "' AND  '" & txttipo.Text & txtdocfin.Text & "  '"
            End If
            '...........
            If rbfecha2.Checked = True Then
                fdoc = " AND CAST(Right(f . fecha,2) AS CHAR(5)) BETWEEN '" & txtfechaini.Text & "' and '" & txtfechafin.Text & "' "
            End If
            '..........
            If cbde.Text = "Inventarios" Then
                ddoc = " AND f.doc_de = 'I' "
            End If
            If cbde.Text = "Servicios y Otros Items" Then
                ddoc = " AND f.doc_de <> 'I' "
            End If

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")
            dir = tabla2.Rows(0).Item("direccion")
            tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
            email = tabla2.Rows(0).Item("emailconta")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " select f.doc,v.nombre as nitv, f.observ, f.num,  " _
            & " CAST(CONCAT(Right(f . fecha,2),'/',mid(f . fecha,6,2),'/',left(f . fecha,4)) AS CHAR(20) )as cta1, " _
            & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 2 ) ,  '/', MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 6, 2 ) ,  '/', LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
            & " f.nitc, CONCAT(t.nombre,' ',t.apellidos) as usuario, t.dir as cta2, t.telefono as cta3, " _
            & " f.observ as obs, f.descuento, f.iva, f.total,f.ret_f , f.ret_ica  , f.ret_iva  " _
            & " from  parafacgral pg, vendedores v, facturas" & p & " f  LEFT JOIN terceros t ON ( f.nitc = t.nit )  " _
            & " WHERE f.nitv = v.nitv and f.tipodoc = '" & txttipo.Text & "' " & tdoc & " " & rdoc & " " & fdoc & " " & ddoc & " order by doc "


            sql2 = " select pf.logofac,  " _
            & " CASE ('" & txttipo.Text & "' )  " _
            & " WHEN pg.tipof1   " _
            & " THEN IF (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '')  " _
            & " WHEN pg.tipof2   " _
            & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof3   " _
            & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof4   " _
            & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '')  " _
            & " END AS res, " _
             & " CASE ('" & txttipo.Text & "' ) " _
            & " WHEN pg.tipof1 " _
            & " THEN IF (pg.hr1='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
            & " WHEN pg.tipof2 " _
            & " THEN IF (pg.hr2='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
            & " WHEN pg.tipof3 " _
            & " THEN IF (pg.hr3='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
            & " WHEN pg.tipof4 " _
            & " THEN IF (pg.hr4='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
            & " END AS tfac, pf.comentario, " _
             & " CASE 'SI' " _
            & " WHEN pg.hr1 THEN pg.pre1 " _
            & " WHEN pg.hr2 THEN pg.pre2 " _
            & " WHEN pg.hr3 THEN pg.pre3 " _
            & " WHEN pg.hr4 THEN pg.pre4 " _
            & " END AS pref " _
            & " from  parafacts pf, parafacgral pg where factura = 'RAPIDA'   "

            sql3 = "select d.item, d.doc, d.codart, d.nomart, d.cantidad , d.iva_d,  (d.valor/(1+(d.iva_d/100))) as valor, " _
            & " ( (d.valor/(1+(d.iva_d/100))) * d.cantidad   ) as vtotal " _
            & " from detafac" & p & " d order by doc, item"

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql2
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "parafacts")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql3
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "detafac01")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "facturas01")

            TextBox1.Text = sql2

            Dim tablaa As DataTable
            tablaa = New DataTable
            myCommand.CommandText = sql2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaa)
            If tablaa.Rows.Count > 0 Then
                res = tablaa.Rows(0).Item("res")
                fac = tablaa.Rows(0).Item("tfac")
                pre = tablaa.Rows(0).Item("pref")
            End If



            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacVarias.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportFacVarias.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtel As New ParameterField
                Dim PrEmail As New ParameterField
                Dim Prdir As New ParameterField
                Dim Prres As New ParameterField
                Dim Prfac As New ParameterField
                Dim Prprf As New ParameterField


                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prtel.Name = "telef"
                Prtel.CurrentValues.AddValue(tel.ToString)

                Prdir.Name = "dir"
                Prdir.CurrentValues.AddValue(dir.ToString)

                PrEmail.Name = "email"
                PrEmail.CurrentValues.AddValue(email.ToString)

                Prres.Name = "res"
                Prres.CurrentValues.AddValue(res.ToString)

                Prfac.Name = "fac"
                Prfac.CurrentValues.AddValue(fac.ToString)

                Prprf.Name = "pref"
                Prprf.CurrentValues.AddValue(pre.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prtel)
                prmdatos.Add(Prdir)
                prmdatos.Add(PrEmail)
                prmdatos.Add(Prres)
                prmdatos.Add(Prfac)
                prmdatos.Add(Prprf)

                FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacVarias.ShowDialog()

            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

       
            MiConexion(bda)
            Cerrar()

            Dim pre As String = ""
            Dim fac As String = ""
            Dim res As String = ""
            Dim nom As String = ""
            Dim nit As String = ""
            Dim tel As String = ""
            Dim dir As String = ""
            Dim email As String = ""
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""

            Dim p As String = ""
            Dim tdoc As String = ""
            Dim rdoc As String = ""
            Dim fdoc As String = ""
            Dim ddoc As String = ""
            Dim f1 As Integer = 0
            Dim f2 As Integer = 0

            p = PerActual(0).ToString & PerActual(1).ToString

            '.........
            If cbdocumentos.Text = "Aprobados" Then
                tdoc = " and f.estado = 'AP' "
            End If
            If cbdocumentos.Text = "Pendientes" Then
                tdoc = " and f.estado = '' "
            End If
            If cbdocumentos.Text = "Anulados" Then
                tdoc = " and  LEFT(f.descrip,7)='ANULADO' "
            End If
            '.........
            If rbdoc2.Checked = True Then
                rdoc = " AND f.doc BETWEEN '" & txttipo.Text & txtdocini.Text & "' AND  '" & txttipo.Text & txtdocfin.Text & "  '"
            End If
            '...........
            If rbfecha2.Checked = True Then
                fdoc = " AND CAST(Right(f . fecha,2) AS CHAR(5)) BETWEEN '" & txtfechaini.Text & "' and '" & txtfechafin.Text & "' "
            End If
            '..........
            If cbde.Text = "Inventarios" Then
                ddoc = " AND f.doc_de = 'I' "
            End If
            If cbde.Text = "Servicios y Otros Items" Then
                ddoc = " AND f.doc_de <> 'I' "
            End If

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT. " & tabla2.Rows(0).Item("nit") & " " & " REGIMEN COMUN"
            dir = tabla2.Rows(0).Item("direccion")
            tel = "TEL. " & tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
            email = tabla2.Rows(0).Item("emailconta")

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql = " select f.doc,v.nombre as nitv, f.observ, f.num,  " _
            & " CAST(CONCAT(Right(f . fecha,2),'/',mid(f . fecha,6,2),'/',left(f . fecha,4)) AS CHAR(20) )as cta1, " _
            & " CAST( (CONCAT( RIGHT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 2 ) ,  '/', MID( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 6, 2 ) ,  '/', LEFT( (select ADDDATE(f . fecha , INTERVAL f . vmto DAY ) ), 4 ) ) ) AS CHAR( 20 ) ) AS fecha_o, " _
            & " f.nitc, CONCAT(t.nombre,' ',t.apellidos) as usuario, t.dir as cta2, t.telefono as cta3, " _
            & " f.observ as obs, f.descuento, f.iva, f.total,f.ret_f , f.ret_ica  , f.ret_iva  " _
            & " from  parafacgral pg, vendedores v, facturas" & p & " f  LEFT JOIN terceros t ON ( f.nitc = t.nit )  " _
            & " WHERE f.nitv = v.nitv and f.tipodoc = '" & txttipo.Text & "' " & tdoc & " " & rdoc & " " & fdoc & " " & ddoc & " order by doc "


            sql2 = " select pf.logofac,  " _
            & " CASE ('" & txttipo.Text & "' )  " _
            & " WHEN pg.tipof1   " _
            & " THEN IF (pg.hr1='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso1, ' del ', CONCAT( RIGHT(pg.fecexp1, 2),'/', MID( pg.fecexp1, 6, 2 ),'/', LEFT( pg.fecexp1, 4 ))) AS CHAR(100)), '')  " _
            & " WHEN pg.tipof2   " _
            & " THEN IF (pg.hr2='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso2, ' del ', CONCAT( RIGHT(pg.fecexp2, 2),'/', MID( pg.fecexp2, 6, 2 ),'/', LEFT( pg.fecexp2, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof3   " _
            & " THEN IF (pg.hr3='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso3, ' del ', CONCAT( RIGHT(pg.fecexp3, 2),'/', MID( pg.fecexp3, 6, 2 ),'/', LEFT( pg.fecexp3, 4 ))) AS CHAR(100)), '')   " _
            & " WHEN pg.tipof4   " _
            & " THEN IF (pg.hr4='SI',  CAST(CONCAT('Resolucion DIAN ' ,pg.reso4, ' del ', CONCAT( RIGHT(pg.fecexp4, 2),'/', MID( pg.fecexp4, 6, 2 ),'/', LEFT( pg.fecexp4, 4 ))) AS CHAR(100)), '')  " _
            & " END AS res, " _
             & " CASE ('" & txttipo.Text & "' ) " _
            & " WHEN pg.tipof1 " _
            & " THEN IF (pg.hr1='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini1, ' al ',pg.fin1) AS CHAR(100)), '') " _
            & " WHEN pg.tipof2 " _
            & " THEN IF (pg.hr2='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini2, ' al ',pg.fin2) AS CHAR(100)), '') " _
            & " WHEN pg.tipof3 " _
            & " THEN IF (pg.hr3='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini3, ' al ',pg.fin3) AS CHAR(100)), '') " _
            & " WHEN pg.tipof4 " _
            & " THEN IF (pg.hr4='SI', " _
            & " CAST(CONCAT('Factura por computador ' ,pg.ini4, ' al ',pg.fin4) AS CHAR(100)), '') " _
            & " END AS tfac, pf.comentario, " _
             & " CASE 'SI' " _
            & " WHEN pg.hr1 THEN pg.pre1 " _
            & " WHEN pg.hr2 THEN pg.pre2 " _
            & " WHEN pg.hr3 THEN pg.pre3 " _
            & " WHEN pg.hr4 THEN pg.pre4 " _
            & " END AS pref " _
            & " from  parafacts pf, parafacgral pg where factura = 'RAPIDA'   "

            sql3 = "select d.item, d.doc, d.codart, d.nomart, d.cantidad , d.iva_d,  (d.valor/(1+(d.iva_d/100))) as valor, " _
            & " ( (d.valor/(1+(d.iva_d/100))) * d.cantidad   ) as vtotal " _
            & " from detafac" & p & " d order by doc, item"

            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql2
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "parafacts")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql3
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "detafac01")


            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "facturas01")

            TextBox1.Text = sql2

            Dim tablaa As DataTable
            tablaa = New DataTable
            myCommand.CommandText = sql2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaa)
            If tablaa.Rows.Count > 0 Then
                res = tablaa.Rows(0).Item("res")
                fac = tablaa.Rows(0).Item("tfac")
                pre = tablaa.Rows(0).Item("pref")
            End If


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacVariasR.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportFacVarias.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prtel As New ParameterField
                Dim Prdir As New ParameterField
                Dim Prres As New ParameterField
                Dim Prfac As New ParameterField
                Dim Prprf As New ParameterField


                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prtel.Name = "telef"
                Prtel.CurrentValues.AddValue(tel.ToString)

                Prdir.Name = "dir"
                Prdir.CurrentValues.AddValue(dir.ToString)

                Prres.Name = "res"
                Prres.CurrentValues.AddValue(res.ToString)

                Prfac.Name = "fac"
                Prfac.CurrentValues.AddValue(fac.ToString)

                Prprf.Name = "pref"
                Prprf.CurrentValues.AddValue(pre.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prtel)
                prmdatos.Add(Prdir)
                prmdatos.Add(Prres)
                prmdatos.Add(Prfac)
                prmdatos.Add(Prprf)

                FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportFacVarias.ShowDialog()

            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try

    End Sub
End Class