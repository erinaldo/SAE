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
Public Class FrmInfoArtGas
    Private Sub FrmInfoArtGas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    '*************************************************
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then txtnitc.Enabled = False
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
            FrmSelCliente.lbform.Text = "cpp_inf_art_gas"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '*************************************************
    Private Sub rb4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb4.CheckedChanged
        If rb4.Checked = True Then
            If FrmPrincipal.Enabled = False Then
                txtart.Enabled = True
                MsgBox("No tiene permisos para el modulo de inventarios.  ", MsgBoxStyle.Information)
                rb3.Checked = True
            Else
                txtart.Enabled = True
            End If
        Else
            txtart.Enabled = False
        End If
    End Sub
    Private Sub rb5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb5.CheckedChanged
        If rb5.Checked = True Then
            txtgas.Enabled = True
        Else
            txtgas.Enabled = False
        End If
    End Sub
    '***********************************************************
    Private Sub txtart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtart.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtart_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtart.LostFocus
        Try
            If txtnomart.Text = "" Then
                FrmSelMisArticulos.lbform.Text = "info_art_gas"
                FrmSelMisArticulos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtart.TextChanged
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nomart FROM articulos WHERE codart ='" & txtart.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items > 0 Then
                txtnomart.Text = Trim(tabla.Rows(0).Item("nomart"))
            Else
                txtnomart.Text = ""
            End If
        Catch ex As Exception
            txtnomart.Text = ""
        End Try
    End Sub
    '*********************************************************
    Private Sub txtgas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgas.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtgas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgas.LostFocus
        If txtnomgas.Text = "" Then
            FrmSelMisGastos.lbform.Text = "info_art_gas"
            FrmSelMisGastos.ShowDialog()
        End If
    End Sub
    Private Sub txtgas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgas.TextChanged
        Try
            Dim items As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT nom_gas FROM gastos WHERE cod_gas ='" & txtgas.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items > 0 Then
                txtnomgas.Text = Trim(tabla.Rows(0).Item("nom_gas"))
            Else
                txtnomgas.Text = ""
            End If
        Catch ex As Exception
            txtnomgas.Text = ""
        End Try
    End Sub
    '*************************************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        'Dim tipo As String = ""
        ''******************************CAMPOS DE LA SENTENCIA*********************************************************
        'Dim sql As String = "SELECT v.*,(v.vtotal/(1+v.por_iva_g/100)) AS st,(v.vtotal-(v.vtotal*v.por_desc/100)) AS vt,trim(concat(t.apellidos,' ',t.nombre)) AS nomnit "
        'sql = sql & "FROM vista_deta_cpp v LEFT JOIN (terceros t) ON v.nitc=t.nit WHERE "
        ''***************************************************************************************
        'If rb1.Checked = True Then 'todos los items
        '    sql = sql & "v.tipo_it<>'' "
        '    tipo = "INFORME DE COMPRAS A PROVEEDORES POR ARTICULO / GRUPO DE GASTOS"
        'ElseIf rb2.Checked = True Then 'todos los articulos
        '    sql = sql & "v.tipo_it='I' "
        '    tipo = "INFORME DE COMPRAS A PROVEEDORES POR TODOS LOS ARTICULOS"
        'ElseIf rb3.Checked = True Then 'todos los gastos
        '    sql = sql & "v.tipo_it='G' "
        '    tipo = "INFORME DE COMPRAS A PROVEEDORES POR TODOS LOS GRUPOS DE GASTOS"
        'ElseIf rb4.Checked = True Then 'un articulo
        '    If txtart.Text = "" Or txtnomart.Text = "" Then
        '        MsgBox("Seleccione un articulo.  ", MsgBoxStyle.Information)
        '        txtart.Focus()
        '        Exit Sub
        '    End If
        '    tipo = "INFORME DE COMPRAS A PROVEEDORES POR UN ARTICULO"
        '    sql = sql & "v.tipo_it='I' AND v.cod_art LIKE '" & txtart.Text & "%' "
        'Else 'un gasto
        '    If txtgas.Text = "" Or txtnomgas.Text = "" Then
        '        MsgBox("Seleccione un grupo de gasto.  ", MsgBoxStyle.Information)
        '        txtgas.Focus()
        '        Exit Sub
        '    End If
        '    sql = sql & "v.tipo_it='G' AND v.cod_art='" & txtgas.Text & "' "
        '    tipo = "INFORME DE COMPRAS A PROVEEDORES POR UN GRUPO DE GASTOS"
        'End If
        ''***********HAY PROVEEDOR ****************************************************************************
        'If c2.Checked = True Then
        '    If txtnitc.Text = "" Or txtcliente.Text = "" Then
        '        MsgBox("Seleccione un grupo Proveedor.  ", MsgBoxStyle.Information)
        '        txtnitc.Focus()
        '        Exit Sub
        '    End If
        '    sql = sql & " AND v.nitc='" & txtnitc.Text & "' "
        '    tipo = tipo & " Y POR UN PROVEEDOR"
        'End If
        ''************ FECHA ********************************************************************
        'If fecha1.Value > fecha2.Value Then
        '    MsgBox("La fecha inicial debe ser menor o igual a la fecha final, verifique.  ", MsgBoxStyle.Information, "SAE Control")
        '    fecha1.Focus()
        '    Exit Sub
        'End If
        'sql = sql & " AND v.fecha>='" & Format(fecha1.Value, "yyyy-MM-dd") & "' AND v.fecha<='" & Format(fecha2.Value, "yyyy-MM-dd") & "' ORDER BY nom_art,nomnit,doc,item,fecha; "
        'Try
        '    GeneraPDF(sql, tipo)
        'Catch ex As Exception
        '    Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        '    AbrirArchivo(NombreArchivo)
        'End Try



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
        Dim cad As String = ""
        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        tit = "INFORME COMPRAS A PROVEEDOR "

        If c2.Checked = True Then ' UN PROV
            cad = cad & " AND f.nitc= '" & txtnitc.Text & "' AND t.nit= '" & txtnitc.Text & "'"
        End If
        If rb2.Checked = True Then ' TODOS ARTICULOS
            cad = cad & " AND f.doc_de = 'I' "
        End If
        If rb3.Checked = True Then ' TODOS GASTOS
            cad = cad & " AND f.doc_de = 'G' "
        End If
        If rb4.Checked = True Then ' UN ARTICULO
            cad = cad & " AND f.doc_de = 'I' AND dc.cod_art = '" & txtart.Text & "' "
        End If
        If rb5.Checked = True Then ' UN GASTO
            cad = cad & " AND f.doc_de = 'G' AND dc.cod_art = '" & txtgas.Text & "' "
        End If



        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If p = m1 Then
                sql = "  SELECT f.nitc, t.nombre, dc.cod_art, dc.nom_art, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc, CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha, dc.cantidad AS num, " _
                & " dc.valor/(1+(dc.por_iva_g/100)) AS v1 , f.doc_afec as usuario," _
                & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad) AS descuento, " _
                & " ((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad) AS iva, " _
                & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad) AS ret_f, " _
                & " (dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad AS Subtotal, " _
                & " dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) AS v2 " _
                & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t " _
                & " WHERE  (f.doc = dc.doc) AND f.nitc = t.nit " & cad
            Else
                sql = sql & " UNION SELECT f.nitc, t.nombre, dc.cod_art, dc.nom_art, ( TRIM( CONCAT( t.nombre,  ' ', t.apellidos ) )) AS ciu_ent, f.doc, CONCAT(dc.cod_art,' - ',dc.nom_art) AS dir_ent, CAST( f.fecha AS CHAR( 20 ) ) AS fecha, dc.cantidad AS num, " _
                & " dc.valor/(1+(dc.por_iva_g/100)) AS v1 , f.doc_afec as usuario," _
                & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad) AS descuento, " _
                & " ((dc.valor - ( dc.valor / ( 1 + ( dc.por_iva_g /100 ) ) )) * dc.cantidad) AS iva, " _
                & " (((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad) AS ret_f, " _
                & " (dc.valor/(1+(dc.por_iva_g/100)))* dc.cantidad AS Subtotal, " _
                & " dc.vtotal - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_rtf /100) * dc.cantidad)) - ((((dc.valor / ( 1 + ( dc.por_iva_g /100 ) )) * f.por_desc /100) * dc.cantidad)) AS v2 " _
                & " FROM fact_comp" & p & " f, detacomp" & p & " dc, terceros t " _
                & " WHERE (f.doc = dc.doc) AND f.nitc = t.nit " & cad
            End If
        Next

        sql = sql & " ORDER BY nombre "

        ' ////////////////// UN PROVEEDORES ////////////////


        TextBox1.Text = sql

        Dim tabla As DataTable
        tabla = New DataTable
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

    End Sub
    '*************************************************
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GeneraPDF(ByVal sql As String, ByVal tipo As String)
        Dim per As String = ""
        Dim tabla As New DataTable
        Dim items As Integer = 0
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        FechaRep = Now.ToString
        Dim subtotal, subiva, subvtotal As Double
        Dim tsub, tiva, total As Double
        Dim tope As Integer = 80
        Try
            pag = 1
            tope = 80
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            Banner(tipo)
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            subtotal = 0
            Dim art As String = ""
            '****************************************************************
            For i = 0 To items - 1
                If art <> tabla.Rows(i).Item("nom_art") Then
                    If art <> "" Then 'HAY SUBTOTAL
                        k = k - 5
                        cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                        k = k - 10
                        cb.ShowTextAligned(50, "*** SUB TOTAL ARTICULO/GRUPO: ", 150, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 400, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subiva), 500, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subvtotal), 590, k, 0)
                    End If
                    k = k - 15
                    cb.ShowTextAligned(50, "*** " & tabla.Rows(i).Item("nom_art") & " *** CODIGO: " & tabla.Rows(i).Item("cod_art"), 10, k, 0)
                    art = tabla.Rows(i).Item("nom_art")
                    subtotal = 0
                    subiva = 0
                    subvtotal = 0
                End If
                k = k - 10
                If k <= tope Then
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner(tipo)
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 2, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha"), 53, k, 0)
                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomnit"), 36), 95, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Moneda(tabla.Rows(i).Item("cantidad")), 270, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("valor")), 340, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("vtotal")), 400, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("por_desc")), 440, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("st")), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("por_iva_g")), 530, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("vt")), 590, k, 0)
                '******************************************************************
                subtotal = subtotal + (Moneda(tabla.Rows(i).Item("vtotal")))
                subiva = subiva + (Moneda(tabla.Rows(i).Item("st")))
                subvtotal = subvtotal + (Moneda(tabla.Rows(i).Item("vt")))
                '******************************************************************
                tsub = tsub + (Moneda(tabla.Rows(i).Item("vtotal")))
                tiva = tiva + (Moneda(tabla.Rows(i).Item("st")))
                total = total + (Moneda(tabla.Rows(i).Item("vt")))
            Next
            '****************************************************************
            If art <> "" Then 'HAY SUBTOTAL
                k = k - 5
                cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
                k = k - 10
                cb.ShowTextAligned(50, "*** SUB TOTAL ARTICULO/GRUPO: ", 150, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 400, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subiva), 500, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subvtotal), 590, k, 0)
            End If
            k = k - 5
            cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "***  TOTAL  GENERAL  *** ", 150, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tsub), 400, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tiva), 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(total), 590, k, 0)
            '****************************************************************
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
    Public Sub Banner(ByVal tipo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tipo, 300, 755, 0)
        cb.ShowTextAligned(50, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
        k = 735
        k = k - 10
        cb.ShowTextAligned(50, "DOCUMENTO", 2, k, 0)
        cb.ShowTextAligned(50, "FECHA", 53, k, 0)
        cb.ShowTextAligned(50, "PROVEEDOR", 95, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 270, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "COSTO", 340, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "UNITARIO", 340, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANTIDAD", 400, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "* COSTO", 400, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "  %", 440, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DCTO", 440, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 500, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, " %", 530, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA", 530, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 590, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "+IVA -DCTO", 590, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    '******************************************
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
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
                FrmSelCliente.lbform.Text = "cpp_inf_art_gas"
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
            FrmSelCliente.lbform.Text = "cpp_inf_art_gas"
            FrmSelCliente.ShowDialog()
        Else
            txtnitc.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub
End Class