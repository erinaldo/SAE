Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class FrmVentasCartera

    Private Sub FrmVentasCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            myCommand.CommandText = "SELECT doc_fac1, par_aju FROM car_par;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then Exit Sub
            txttipo.Items.Clear()
            If Trim(tabla.Rows(0).Item("doc_fac1")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("doc_fac1")))
                txttipo.Text = Trim(tabla.Rows(0).Item("doc_fac1"))
            End If
            If Trim(tabla.Rows(0).Item("par_aju")) <> "" Then
                txttipo.Items.Add(Trim(tabla.Rows(0).Item("par_aju")))
            End If
        Catch ex As Exception
        End Try

    End Sub
    Public consulta As String = ""
    Public tipo As String = ""
    Public dia1, mes1, dia2, mes2 As Integer
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        consulta = ""
        '************PROVEEDOR********************
        If c1.Checked = True Then
            consulta = consulta & " f.nitc<>'' "
            tipo = "TODOS LOS CLIENTES, "
        Else
            If txtcliente.Text = "" Then
                MsgBox("Digite un nit del Cliente valido.  ", MsgBoxStyle.Information, "SAE Control")
                txtnitc.Focus()
                Exit Sub
            End If
            consulta = consulta & " f.nitc='" & txtnitc.Text & "' "
            tipo = "EL CLIENTE " & txtcliente.Text & ", "
        End If
        '************DOCUMENTO DE (AF, FC)********************
        If doc2.Checked = True Then
            If txttipo2.Text = "" Then
                MsgBox("Verifique el tipo de documento.  ", MsgBoxStyle.Information, "SAE Control")
                txttipo.Focus()
                Exit Sub
            End If
            consulta = consulta & " AND f.tipodoc='" & txttipo.Text & "' "
        End If
        '************ESTADO DEL DOCUMENTO********************
        If e1.Checked = True Then 'DOC APROBADOS
            consulta = consulta & " AND f.estado='AP' "
            tipo = tipo & "DOCUMENTOS APROBADOS."
        ElseIf e2.Checked = True Then 'DOC PENDIENTES
            consulta = consulta & " AND f.estado<>'AP' "
            tipo = tipo & "DOCUMENTOS PENDIENTES."
        ElseIf e3.Checked = True Then 'DOC ANULADOS
            consulta = consulta & " AND f.anulado='si' "
            tipo = tipo & "DOCUMENTOS ANULADOS."
        ElseIf e5.Checked = True Then 'DOC APROBADOS SIN ANULAR
            consulta = consulta & " AND f.anulado='no' AND f.estado='AP'"
            tipo = tipo & "DOCUMENTOS APROBADOS SIN ANULAR."
        Else
            tipo = tipo & "TODOS LOS DOCUMENTOS."
        End If
        '********************************
        dia1 = fecha1.Value.Day
        mes1 = fecha1.Value.Month
        dia2 = fecha2.Value.Day
        mes2 = fecha2.Value.Month
        '********************************
        MiConexion(bda)
        Cerrar()
        GenerarPDf()
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
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE VENTAS A CLIENTES", 300, 750, 0)
            cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 740, 0)
            '****************************
            k = 720
            cb.ShowTextAligned(50, "DOC", 7, k, 0)
            cb.ShowTextAligned(50, "FECHA", 48, k, 0)
            cb.ShowTextAligned(50, "ARTICULO/SERVICIOS", 90, k, 0)
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
                            cb.ShowTextAligned(50, "*** SUB TOTAL CLIENTE: ", 150, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subdes), 360, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subrtf), 410, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subtotal), 470, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subiva), 530, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subvtotal), 590, k, 0)
                        End If
                        k = k - 15
                        cb.ShowTextAligned(50, "*** CLIENTE: " & tabla.Rows(i).Item("nombre") & " " & tabla.Rows(i).Item("apellidos"), 10, k, 0)
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
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE VENTAS A CLIENTE", 300, 750, 0)
                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
                        '****************************
                        k = 720
                        cb.ShowTextAligned(50, "DOC", 7, k, 0)
                        cb.ShowTextAligned(50, "FECHA", 48, k, 0)
                        cb.ShowTextAligned(50, "ARTICULO/SERVICIOS", 90, k, 0)
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
                cb.ShowTextAligned(50, "*** SUB TOTAL CLIENTE: ", 150, k, 0)
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
            FrmSelCliente.lbform.Text = "com_inf_car"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
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

End Class