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
Public Class FrmInfoListaPreciosArt

    Public fila As Integer = 0

    Private Sub FrmInfoListaPreciosArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gitems.RowCount = 6
        cborden.Text = "Codigo"
        Dim tlp As New DataTable
        myCommand.CommandText = "SELECT * FROM listasprec ORDER BY numlist;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tlp)
        If tlp.Rows.Count = 0 Then
            MsgBox("No Hay listas de precios creadas, verifique.   ", MsgBoxStyle.Information, "SAE Control")
        Else
            gitems.Rows.Clear()
            gitems.RowCount = tlp.Rows.Count
            For i = 0 To tlp.Rows.Count - 1
                gitems.Item(0, i).Value = True
                gitems.Item(1, i).Value = tlp.Rows(i).Item("numlist")
                gitems.Item(2, i).Value = tlp.Rows(i).Item("nomlist")
            Next
        End If
    End Sub
    '*****************************************************
    Private Sub rbt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt.CheckedChanged
        txtini.Enabled = False
        txtfin.Enabled = False
    End Sub
    Private Sub rbr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbr.CheckedChanged
        txtini.Enabled = True
        txtfin.Enabled = True
    End Sub
    '*****************************************************
    Private Sub txtini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtini.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtini.LostFocus
        BuscarArticulo(txtini.Text, "ini")
    End Sub
    Private Sub txtfin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfin.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtfin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfin.LostFocus
        BuscarArticulo(txtfin.Text, "fin")
    End Sub
    Public Sub BuscarArticulo(ByVal codart As String, ByVal txt As String)
        Dim items As Integer
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM articulos WHERE codart='" & codart & "' And estado='Activo' ORDER BY codart;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            If txt = "ini" Then
                txtn1.Text = ""
            Else
                txtn2.Text = ""
            End If
        Else
            If txt = "ini" Then
                txtn1.Text = tabla.Rows(0).Item("nomart")
            Else
                txtn2.Text = tabla.Rows(0).Item("nomart")
            End If
        End If
    End Sub
    '*****************************************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If ValidarRango() = False Then Exit Sub
        ' GenerarPDF()



        Dim nit As String = ""
        Dim nom As String = ""
        Dim sql As String = ""
        Dim p As String = ""
        Dim b As String = ""
        Dim tt As String = ""


        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

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

        p = PerActual(0) & PerActual(1)

        Dim cad As String = ""

        Dim pre As String = ""
        Dim preIVA As String = ""
        Dim preT As String = ""
        Dim x As Integer = 0
        Dim cant As String = ""

        Dim tablab As DataTable
        tablab = New DataTable
        myCommand.CommandText = "SELECT numbod from bodegas"
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablab)
        For i = 0 To tablab.Rows.Count - 1
            If i = 0 Then
                cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
            Else
                cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
            End If
        Next
        cant = cant & ") "


        If rbr.Checked = True Then
            cad = cad & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' "
        End If
        If chex.Checked = True Then
            cad = cad & " AND " & cant & " <> 0 "
        End If
        If cborden.Text = "Codigo" Then
            cad = cad & " ORDER BY codart "
        End If
        If cborden.Text = "Nombre" Then
            cad = cad & " ORDER BY nomart "
        End If
        If cborden.Text = "Referencia" Then
            cad = cad & " ORDER BY referencia "
        End If



        For i As Integer = 0 To gitems.RowCount - 1

            If gitems.Item(0, i).Value = True Then
                x = x + 1
                pre = pre & "c.precio" & gitems(1, i).Value & " AS precio" & gitems(1, i).Value & ", "
                preIVA = preIVA & "c.precio" & gitems(1, i).Value & "*(1+(a.iva/100)) AS precio" & x & ", "
                preT = preT & "PRECIO" & gitems(1, i).Value & "     "
            End If
            'MsgBox(gitems.Item(0, i).Value)
        Next


        If rbiva2.Checked = True Then
            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" & cad

            tt = "SIN IVA"
        End If
        If rbiva.Checked = True Then
            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" & cad

            tt = " CON IVA"
        End If



        ''////////////////// TODOS LOS CODIGOS///////////////
        'If rbt.Checked = True Then

        '    If cborden.Text = "Codigo" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY codart"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY codart"

        '            tt = " CON IVA"

        '        End If
        '    End If ' por codigo

        '    If cborden.Text = "Nombre" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY nomart"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY nomart"

        '            tt = "CON IVA"

        '        End If
        '    End If ' por Nombre

        '    If cborden.Text = "Referencia" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY referencia"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY referencia"

        '            tt = "CON IVA"

        '        End If
        '    End If ' por referencia

        'End If
        ''////////////// FIN / TODOS LOS CODIGOS///////////////


        ''////////////////// RANGO DE CODIGOS///////////////
        'If rbr.Checked = True Then

        '    If cborden.Text = "Codigo" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart)  " _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY codart"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) " _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY codart"

        '            tt = "CON IVA"

        '        End If
        '    End If ' por codigo

        '    If cborden.Text = "Nombre" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) " _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY nomart"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) '" _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY nomart"

        '            tt = "CON IVA"

        '        End If
        '    End If ' por Nombre

        '    If cborden.Text = "Referencia" Then

        '        If rbiva2.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & pre & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) " _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "'" _
        '            & " ORDER BY referencia"

        '            tt = "SIN IVA"
        '        End If

        '        If rbiva.Checked = True Then
        '            sql = "  SELECT c.codart AS codart, a.nomart AS cue_inv, a.referencia AS cue_cos, " & preIVA & " a.iva AS margen  " _
        '            & " FROM articulos a, con_inv c WHERE(c.codart = a.codart) " _
        '            & " AND ( a.codart) BETWEEN '" & txtini.Text & "' AND  '" & txtfin.Text & "' AND c.periodo =  '" & p & "' " _
        '            & " ORDER BY referencia"

        '            tt = "CON IVA"

        '        End If
        '    End If ' por referencia

        'End If
        ''////////////// FIN / POR RANGO ///////////////

        TextBox1.Text = sql
        TextBox2.Text = preT


        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportLisPre.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
        Catch ex As Exception
        End Try

        FrmRepLisPre.CrystalReportViewer1.ReportSource = CrReport


        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prbodega As New ParameterField
            Dim PrVitrina As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prperiodo.Name = "periodo"
            Prperiodo.CurrentValues.AddValue(PerActual.ToString)

            Prbodega.Name = "iva"
            Prbodega.CurrentValues.AddValue(tt.ToString)

            PrVitrina.Name = "vitrina"
            PrVitrina.CurrentValues.AddValue(preT.ToString)


            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prbodega)
            prmdatos.Add(PrVitrina)

            FrmRepLisPre.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmRepLisPre.ShowDialog()

        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try

    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '*****************************************************
    Function ValidarRango()
        If rbt.Checked = True Then
            Return True
        Else
            If Trim(txtn1.Text) = "" Or Trim(txtn2.Text) = "" Then
                MsgBox("Verifique los rangos de los articulos.   ", MsgBoxStyle.Information, "SAE Control")
                Return False
            ElseIf txtini.Text > txtfin.Text Then
                MsgBox("Verifique los rangos de los articulos. " & txtini.Text & " debe ser menor o igual que " & txtfin.Text & ".", MsgBoxStyle.Information, "SAE Control")
                Return False
            Else
                Return True
            End If
        End If
    End Function
    '****************** PDF ***********************************
    Dim cb As PdfContentByte
    Dim k, k2, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Try
            FechaRep = Now.ToString
            Dim tope As Integer

            Dim orden, campos, rango, sql As String
            If cborden.Text = "Codigo" Then
                orden = "ORDER BY a.codart"
            ElseIf cborden.Text = "Nombre" Then
                orden = "ORDER BY a.nomart"
            Else
                orden = "ORDER BY a.referencia"
            End If
            campos = "a.codart, a.nomart, a.referencia, a.iva"
            For i = 0 To gitems.RowCount - 1
                Try
                    If gitems.Item(0, i).Value = True And Val(gitems.Item(1, i).Value) > 0 And Trim(gitems.Item(2, i).Value) <> "" Then
                        campos = campos & ",c.precio" & Val(gitems.Item(1, i).Value)
                    End If
                Catch ex As Exception
                End Try
            Next
            If rbt.Checked = True Then
                rango = "WHERE c.periodo='" & PerActual(0) & PerActual(1) & "'"
            Else
                rango = "WHERE c.periodo='" & PerActual(0) & PerActual(1) & "' AND (c.codart>='" & txtini.Text & "' AND c.codart<='" & txtfin.Text & "')"
            End If
            Dim ta As New DataTable
            sql = "SELECT " & campos & " FROM con_inv c LEFT JOIN (articulos a) ON a.codart = c.codart AND a.estado='Activo' " & rango & " " & orden
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            '*********************************************
            pag = 0
            tope = 40
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            Banner()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '*****************************
            k = k + 20
            Dim j As Integer
            For i = 0 To ta.Rows.Count - 1
                k = k - 30
                If k < tope Then 'NUEVA PAGINA
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                End If
                '*****************************************************
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ta.Rows(i).Item("codart"), 10, k, 0)
                '*****************************************************
                k2 = k
                j = 0
                For i2 = 0 To gitems.RowCount - 1
                    Try
                        If gitems.Item(0, i2).Value = True And Val(gitems.Item(1, i2).Value) > 0 And Trim(gitems.Item(2, i2).Value) <> "" Then
                            j = j + 1
                            If j = 1 Then
                                Precio(ta.Rows(i).Item("precio" & (i2 + 1)), 390, ta.Rows(i).Item("iva"))
                            ElseIf j = 2 Then
                                Precio(ta.Rows(i).Item("precio" & (i2 + 1)), 490, ta.Rows(i).Item("iva"))
                            ElseIf j = 3 Then
                                Precio(ta.Rows(i).Item("precio" & (i2 + 1)), 590, ta.Rows(i).Item("iva"))
                                j = 0
                                If i < 4 Then k = k - 10
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                k = k2
                '*****************************************************
                cb.ShowTextAligned(50, ta.Rows(i).Item("referencia"), 200, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(ta.Rows(i).Item("iva")), 290, k, 0)
                k2 = k
                Control_de_linea(ta.Rows(i).Item("nomart"), 60, 30)
                k = k2
            Next
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
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
    Public Sub Precio(ByVal precio As String, ByVal pos As Integer, ByVal iva As Decimal)
        If rbiva.Checked = True Then
            precio = CDbl(precio) + (CDbl(precio) * iva / 100)
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(precio), pos, k, 0)
    End Sub
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        If rbiva.Checked = True Then
            cb.ShowTextAligned(50, "PRECIOS CON IVA INCLUIDO ", 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "PRECIOS SIN IVA ", 20, 780, 0)
        End If
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "LISTADO DE PRECIOS DE LOS ARTICULOS ", 300, 760, 0)
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 750, 0)
        k = 740
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CODIGO", 10, k - 10, 0)
        cb.ShowTextAligned(50, "DESCRIPCIÓN", 60, k - 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "REFERENCIA", 200, k - 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "% IVA", 290, k - 10, 0)
        '**********************************************************************
        Dim j As Integer = 0
        k2 = k
        For i = 0 To gitems.RowCount - 1
            Try
                If gitems.Item(0, i).Value = True And Val(gitems.Item(1, i).Value) > 0 And Trim(gitems.Item(2, i).Value) <> "" Then
                    j = j + 1
                    If j = 1 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, CambiaCadena(gitems.Item(2, i).Value, 21), 390, k, 0)
                    ElseIf j = 2 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, CambiaCadena(gitems.Item(2, i).Value, 21), 490, k, 0)
                    ElseIf j = 3 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, CambiaCadena(gitems.Item(2, i).Value, 21), 590, k, 0)
                        j = 0
                        If i < 4 Then k = k - 10
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        If k = k2 Then
            k = k - 10
        End If
        '***********************************************************************
        k = k - 5
        cb.ShowTextAligned(50, "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal x As Integer, ByVal tam As Integer)
        Dim linea As String = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = "" Or cadena(i) = "," Or cadena(i) = "." Or j = tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                    linea = ""
                    k = k - 10
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), x, k, 0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub gitems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellClick
        fila = e.RowIndex
    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub
End Class