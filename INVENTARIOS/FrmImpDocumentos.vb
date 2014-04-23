Imports iTextSharp.text.pdf
Imports iTextSharp.text
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

Public Class FrmImpDocumentos
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Private Sub d1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d1.CheckedChanged
        txt_doc_ini.Enabled = False
        txt_doc_fin.Enabled = False
    End Sub
    Private Sub d2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.CheckedChanged
        txt_doc_ini.Enabled = True
        txt_doc_fin.Enabled = True
    End Sub
    Private Sub f1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f1.CheckedChanged
        txt_fec_ini.Enabled = False
        txt_fec_fin.Enabled = False
    End Sub
    Private Sub f2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f2.CheckedChanged
        txt_fec_ini.Enabled = True
        txt_fec_fin.Enabled = True
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub FrmImpDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Today.Day < 10 Then
            txt_fec_fin.Text = "0" & Today.Day
        Else
            txt_fec_fin.Text = Today.Day
        End If
        cbtipo.Text = "Entradas"
    End Sub
    Private Sub txt_doc_ini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_doc_ini.KeyPress
        validarnumero(txt_doc_ini, e)
    End Sub
    Private Sub txt_doc_fin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_doc_fin.KeyPress
        validarnumero(txt_doc_fin, e)
    End Sub
    Private Sub txt_fec_ini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fec_ini.KeyPress
        validarnumero(txt_fec_ini, e)
    End Sub
    Private Sub txt_fec_fin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fec_fin.KeyPress
        validarnumero(txt_fec_fin, e)
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If cbtipo.Text = "Traslados" Then
            pdfT()
        ElseIf cbtipo.Text = "Ajustes" Then
            pdfA()
        ElseIf cbtipo.Text = "Salidas" Then
            'pdfS() 
            Button1_Click(AcceptButton, AcceptButton)
        Else
            'pdfE()
            Button1_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Public Sub pdfT()
        If HayDocumentos("traslados") = 0 Then Exit Sub
        '****************************************************
        Dim sql As String
        sql = ConSQL(BuscarCampos("traslados"))
        '****************************************************
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        pag = 0
        '**************************************
        pdfw = PdfWriter.GetInstance(oDoc, New IO.FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        BannerT()
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        '*********************************************
        Dim tabla As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            k = k - 10
            If k < 60 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                BannerT()
                k = k - 10
                cb.EndText()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
            End If
            cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc") & " " & NumeroDoc(tabla.Rows(i).Item("num")), 60, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & PerActual & " - " & tabla.Rows(i).Item("hora").ToString, 150, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(verBod(tabla.Rows(i).Item("doc"), "bod_ori"), 20), 280, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(verBod(tabla.Rows(i).Item("doc"), "bod_des"), 20), 450, k, 0)
        Next
        '********************************************************************        
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        Try
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try
    End Sub
    Public Sub BannerT()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 800, 0)
        cb.ShowTextAligned(50, "DOCUMENTOS DE TRASLADOS PERIODO " & PerActual, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 770, 0)
        '**************************
        k = 760
        cb.ShowTextAligned(50, "DOCUMENTO", 60, k, 0)
        cb.ShowTextAligned(50, "FECHA Y HORA", 150, k, 0)
        cb.ShowTextAligned(50, "BODEGA DE SALIDA", 280, k, 0)
        cb.ShowTextAligned(50, "BODEGA DE ENTRADA", 450, k, 0)
    End Sub
    Function verBod(ByVal doc As String, ByVal campo As String)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT b.* FROM bodegas b LEFT JOIN (deta_mov" & PerActual(0) & PerActual(1) & " d) " _
                                  & " ON b.numbod = d." & campo _
                                  & " WHERE d.doc = '" & doc & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Return tabla.Rows(0).Item("numbod") & " - " & tabla.Rows(0).Item("nombod")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub pdfA()
        If HayDocumentos("ajustes") = 0 Then Exit Sub
    End Sub
    Public Sub BannerA()

    End Sub
    Public Sub pdfS()
        If HayDocumentos("salidas") = 0 Then Exit Sub
        '****************************************************
        Dim sql As String
        sql = ConSQL(BuscarCampos("salidas"))
        '****************************************************
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim suma As Double = 0
        FechaRep = Now.ToString
        pag = 0
        '**************************************
        pdfw = PdfWriter.GetInstance(oDoc, New IO.FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        BannerS()
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        '*********************************************
        Dim tabla As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            k = k - 10
            If k < 60 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                BannerS()
                k = k - 10
                cb.EndText()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
            End If
            cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 60, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & PerActual & " - " & tabla.Rows(i).Item("hora").ToString, 150, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(verBod(tabla.Rows(i).Item("doc"), "bod_ori"), 20), 250, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("nitc"), 380, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("total")), 545, k, 0)
            suma = suma + tabla.Rows(i).Item("total")
        Next
        '********************************************************************
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL:   $" & Moneda(suma), 545, k, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        Try
            FrmReportePuc.ShowDialog()
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try
    End Sub
    Public Sub BannerS()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 800, 0)
        cb.ShowTextAligned(50, "DOCUMENTOS DE SALIDAS PERIODO " & PerActual, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 770, 0)
        '**************************
        k = 760
        cb.ShowTextAligned(50, "DOCUMENTO", 60, k, 0)
        cb.ShowTextAligned(50, "FECHA Y HORA", 150, k, 0)
        cb.ShowTextAligned(50, "BODEGA DE SALIDA", 250, k, 0)
        cb.ShowTextAligned(50, "NIT / CC", 380, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "V. TOTAL", 545, k, 0)
        k = k - 5
    End Sub
    Public Sub pdfE()
        If HayDocumentos("entradas") = 0 Then Exit Sub
        '****************************************************
        Dim sql As String
        sql = ConSQL(BuscarCampos("entradas"))
        'MsgBox(sql)
        '****************************************************
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim suma As Double = 0
        FechaRep = Now.ToString
        pag = 0
        '**************************************
        pdfw = PdfWriter.GetInstance(oDoc, New IO.FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        BannerE()
        cb.EndText()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 8)
        '*********************************************
        Dim tabla As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            k = k - 10
            If k < 60 Then 'NUEVA PAGINA
                pag = pag + 1
                cb.EndText()
                oDoc.NewPage()
                'cb.AddImage(img) 'IMAGEN
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 9)
                BannerE()
                k = k - 10
                cb.EndText()
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 8)
            End If
            cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 60, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("dia") & "/" & PerActual & " - " & tabla.Rows(i).Item("hora").ToString, 150, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(verBod(tabla.Rows(i).Item("doc"), "bod_des"), 20), 250, k, 0)
            cb.ShowTextAligned(50, tabla.Rows(i).Item("nitc"), 380, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("total")), 545, k, 0)
            suma = suma + tabla.Rows(i).Item("total")
        Next
        '********************************************************************
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTAL:   $" & Moneda(suma), 545, k, 0)
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        Try
            FrmReportePuc.ShowDialog()
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try
    End Sub
    Public Sub BannerE()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & UCase(CompaniaActual) & " - " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 800, 0)
        cb.ShowTextAligned(50, "DOCUMENTOS DE ENTRADAS PERIODO " & PerActual, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 770, 0)
        '**************************
        k = 760
        cb.ShowTextAligned(50, "DOCUMENTO", 60, k, 0)
        cb.ShowTextAligned(50, "FECHA Y HORA", 150, k, 0)
        cb.ShowTextAligned(50, "BODEGA DE ENTRADA", 250, k, 0)
        cb.ShowTextAligned(50, "NIT / CC", 380, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "V. TOTAL", 545, k, 0)
        k = k - 5
    End Sub
    Function HayDocumentos(ByVal tabla As String)
        Dim t, t2 As New DataTable
        myCommand.CommandText = "SELECT " & tabla & " FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        If t2.Rows(0).Item(0).ToString = "" Then
            MsgBox("No han asignado ningun tipo de docuementos de " & tabla & ", Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Return 0
            Exit Function
        Else
            myCommand.CommandText = "SELECT count(*) FROM movimientos" & PerActual(0) & PerActual(1) & "  WHERE tipodoc='" & t2.Rows(0).Item(0) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            Refresh()
            If t.Rows(0).Item(0) = 0 Then
                MsgBox("No hay documentos creados en este periodo.", MsgBoxStyle.Information, "SAE Verificacion")
                Return 0
            Else
                Return 1
            End If
        End If
    End Function
    Function ConSQL(ByVal campo As String)
        Dim sql As String
        If d1.Checked = True Then
            If f1.Checked = True Then
                sql = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc = '" & campo & "' ORDER BY num DESC;"
            Else
                sql = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc = '" & campo & "' " _
                    & " AND dia>='" & txt_fec_ini.Text & "' AND dia<='" & txt_fec_fin.Text & "' ORDER BY num DESC;"
            End If
        Else
            If f1.Checked = True Then
                sql = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc = '" & campo & "' " _
                    & " AND num>=" & Val(txt_doc_ini.Text) & " AND num<=" & Val(txt_doc_fin.Text) & " ORDER BY num DESC;"
            Else
                sql = "SELECT * FROM movimientos" & PerActual(0) & PerActual(1) & " WHERE tipodoc = '" & campo & "' " _
                    & " AND num>=" & Val(txt_doc_ini.Text) & " AND num<=" & Val(txt_doc_fin.Text) & " " _
                    & " AND dia>='" & txt_fec_ini.Text & "' AND dia<='" & txt_fec_fin.Text & "' ORDER BY num DESC;"
            End If
        End If
        Return sql
    End Function
    Function BuscarCampos(ByVal campo)
        Dim t, t2 As New DataTable
        myCommand.CommandText = "SELECT " & campo & " FROM parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        Return t2.Rows(0).Item(0).ToString
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        MiConexion(bda)
        Cerrar()

        Dim p As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim tel As String = ""
        Dim dir As String = ""
        Dim email As String = ""
        Dim sql As String = ""
        Dim cad As String = ""
        Dim pord As String = ""
        Dim pdoc As String = ""
        Dim Tdoc As String = ""

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


        If cbtipo.Text = "Entradas" Then
            cad = "  AND bg.numbod = d.bod_des"
            pord = "ORDEN DE COMPRA"
            pdoc = "ENTRADA N°"
            Tdoc = "EN"
        ElseIf cbtipo.Text = "Salidas" Then
            cad = "  AND bg.numbod = d.bod_ori"
            pord = "N° DE PEDIDO"
            pdoc = "SALIDA N°"
            Tdoc = "SA"
        End If



        If d2.Checked = True Then
            cad = cad & " AND m.num BETWEEN " & Val(txt_doc_ini.Text) & " AND " & Val(txt_doc_fin.Text) & " "
        End If
        If f2.Checked = True Then
            cad = cad & " AND m.dia BETWEEN " & Val(txt_fec_ini.Text) & " AND " & Val(txt_fec_fin.Text) & " "
        End If

        p = Strings.Left(lbperiodo.Text, 2)
        sql = sql & "SELECT d.doc AS doc, d.item AS vmto, d.codart AS cta_total,d.nomart AS observ, d.cantidad AS iva, (d.valor/d.`cantidad`) AS ret_f, d.valor AS total, " _
       & " IF (tipodoc='EN',cast(CONCAT(d.bod_des,' ',bg.nombod) as char(30)),cast(CONCAT(d.bod_ori,' ',bg.nombod) as char(30))) AS ciu_ent, " _
       & " IF (tipodoc='EN',o_compra,n_pedido) AS cta2, m.total as v1, " _
       & " m.nitc AS nitc, CONCAT(t.`nombre`,' ',t.`apellidos`) AS d1, t.`dir` AS dir_ent, t.`telefono` AS cc,  m.observ AS descrip, m.concepto AS entregar,  " _
       & " CONCAT(m.dia,'/',m.per) AS cta1 FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t , bodegas bg " _
       & " WHERE d.doc = m.doc AND m.tipodoc='" & Tdoc & "' AND t.`nit`= m.nitc " & cad & " "

        sql = sql & " ORDER BY  doc "
        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT logofac from parafacts where factura='RAPIDA'"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parafacts")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "facturas01")


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportDocInvVarios.rpt")
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
            Dim Prord As New ParameterField



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
            Prord.Name = "ord"
            Prord.CurrentValues.AddValue(pord.ToString)
            Prres.Name = "tdoc"
            Prres.CurrentValues.AddValue(pdoc.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            prmdatos.Add(PrEmail)
            prmdatos.Add(Prord)
            prmdatos.Add(Prres)


            FrmReportFacVarias.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacVarias.ShowDialog()

        Catch ex As Exception
        End Try


    End Sub
End Class