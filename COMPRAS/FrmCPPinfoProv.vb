'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmCPPinfoProv
    Private Sub FrmCPPinfoProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        fecha1.MinDate = "01/01/2010"
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
    End Sub
    Private Sub c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.CheckedChanged
        If c1.Checked = True Then txtnitc.Enabled = False
    End Sub
    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtnitc.Enabled = True
            txtnitc.Focus()
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
            FrmSelCliente.lbform.Text = "cpp_inf_pro"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '**********************************
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        '**************************************
        Dim per1, per2, dia1, dia2 As String
        If Val(fecha1.Value.Month.ToString) < 10 Then
            per1 = "0" & Val(fecha1.Value.Month.ToString) & "/" & fecha1.Value.Year
        Else
            per1 = fecha1.Value.Month.ToString & "/" & fecha1.Value.Year
        End If
        If Val(fecha2.Value.Month.ToString) < 10 Then
            per2 = "0" & Val(fecha2.Value.Month.ToString) & "/" & fecha2.Value.Year
        Else
            per2 = fecha2.Value.Month.ToString & "/" & fecha2.Value.Year
        End If
        If Val(fecha1.Value.Day.ToString) < 10 Then
            dia1 = "0" & Val(fecha1.Value.Day.ToString)
        Else
            dia1 = fecha1.Value.Day.ToString
        End If
        If Val(fecha2.Value.Day.ToString) < 10 Then
            dia2 = "0" & Val(fecha2.Value.Day.ToString)
        Else
            dia2 = fecha2.Value.Day.ToString
        End If
        Dim cad As String = "AND (dia>='" & dia1 & "' AND periodo>='" & per1 & "') AND (dia<='" & dia2 & "' AND periodo<='" & per2 & "')"
        '*******************************************
        '************************************************
        Dim sql As String = ""
        If c1.Checked = True Then
            If fecha1.Value > fecha2.Value Then
                MsgBox("La fecha inicial debe ser menor o igual a la fecha final, verifique.  ", MsgBoxStyle.Information, "SAE Control")
                fecha1.Focus()
                Exit Sub
            End If
            sql = "SELECT *  FROM ctas_x_pagar WHERE total>pagado AND fecha>='" & Format(fecha1.Value, "yyyy-MM-dd") & "' AND fecha<='" & Format(fecha2.Value, "yyyy-MM-dd") & "' ORDER BY nomnit,doc,fecha;"
        Else
            If Trim(txtcliente.Text) = "" Then
                MsgBox("Digite un nit de proveedor valido, verifique.  ", MsgBoxStyle.Information, "SAE Control")
                txtnitc.Focus()
                Exit Sub
            ElseIf fecha1.Value > fecha2.Value Then
                MsgBox("La fecha inicial debe ser menor o igual a la fecha final, verifique.  ", MsgBoxStyle.Information, "SAE Control")
                fecha1.Focus()
                Exit Sub
            End If
            sql = "SELECT * FROM ctas_x_pagar WHERE nitc='" & txtnitc.Text & "' AND total>pagado AND fecha>='" & Format(fecha1.Value, "yyyy-MM-dd") & "' AND fecha<='" & Format(fecha2.Value, "yyyy-MM-dd") & "' ORDER BY nomnit,doc,fecha;"
        End If
        GenerarPDF(sql, cad)
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '**********************************************
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Dim subfp, subce As Double
    Public Sub GenerarPDF(ByVal sql As String, ByVal cad As String)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim tabla As New DataTable
        Try
            MiConexion(bda)
            Cerrar()
            FechaRep = Now.ToString
            Dim tope As Integer = 80
            pag = 1
            tope = 80
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
            cb.SetFontAndSize(fuente, 6)
            '*****************************************************
            tabla.Clear()
            'MsgBox(sql)
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim ter As String = ""
            subfp = 0
            subce = 0
            For i = 0 To tabla.Rows.Count - 1
                If ter <> tabla.Rows(i).Item("nomnit") Then
                    If ter <> "" Then 'HAY SUBTOTAL
                        SubTotal(tabla.Rows(i).Item("nitc"), cad)
                    End If
                    k = k - 15
                    cb.ShowTextAligned(50, "*** PROVEEDOR: " & tabla.Rows(i).Item("nomnit") & " ***", 10, k, 0)
                    ter = tabla.Rows(i).Item("nomnit")
                    SaldoInicial(tabla.Rows(i).Item("nitc"), cad)
                End If
                '*************************************************************
                k = k - 10
                If k <= tope Then
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner()
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                    k = k - 10
                End If
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc"), 2, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("doc_ext"), 40, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("fecha"), 80, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("total")), 355, k, 0)
                subce = subce + CDbl(Moneda(tabla.Rows(i).Item("total")))
                Print_Comp_cpp(tabla.Rows(i).Item("doc"), cad)
            Next
            '**********************************
            If ter <> "" Then 'HAY SUBTOTAL
                SubTotal(tabla.Rows(tabla.Rows.Count - 1).Item("nitc"), cad)
            End If
            '*********************************
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
            Try
                'FrmReportePuc.ShowDialog()
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
        'Cerrar y Abrir nuevamente la conexion normal
        MiConexion(bda)
        Cerrar()
    End Sub
    Public Sub Print_Comp_cpp(ByVal doc_afec As String, ByVal cad As String)
        Dim t As New DataTable
        t.Clear()
        myCommand.CommandText = "SELECT doc,dia,periodo,item,descrip,doc_afec,abonado FROM vista_ot_cpp WHERE doc_afec='" & doc_afec & "' AND abonado>'0' " & cad & "  ORDER BY periodo,dia,doc,item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        For i = 0 To t.Rows.Count - 1
            k = k - 10
            cb.ShowTextAligned(50, t.Rows(i).Item("doc"), 2, k, 0)
            cb.ShowTextAligned(50, "------", 40, k, 0)
            cb.ShowTextAligned(50, t.Rows(i).Item("dia") & "/" & t.Rows(i).Item("periodo"), 80, k, 0)
            cb.ShowTextAligned(50, CambiaCadena(t.Rows(i).Item("descrip"), 30), 120, k, 0)
            cb.ShowTextAligned(50, t.Rows(i).Item("doc_afec"), 235, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(t.Rows(i).Item("abonado")), 420, k, 0)
            subfp = subfp + CDbl(Moneda(t.Rows(i).Item("abonado")))
        Next
    End Sub
    Public Sub SaldoInicial(ByVal nit As String, ByVal cad As String)
        cb.ShowTextAligned(50, "NIT/CEDULA: " & nit, 315, k, 0)
        subce = 0
        subfp = 0
    End Sub
    Public Sub SubTotal(ByVal nit As String, ByVal cad As String)
        k = k - 5
        cb.ShowTextAligned(50, "____________________________________________________________________________________________________________", 250, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "*** SUB TOTAL MOVIMIENTOS PROVEEDOR: ", 150, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subce), 355, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(subfp), 420, k, 0)
    End Sub
    Public Sub Banner()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA INICIAL: " & fecha1.Text & "  FECHA FINAL: " & fecha2.Text, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE MOVIMIENTOS DE CUENTAS POR PAGAR POR PROVEEDOR", 300, 755, 0)
        cb.ShowTextAligned(50, "----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 745, 0)
        k = 735
        cb.ShowTextAligned(50, "DOCUMENTO", 235, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CARGOS A", 355, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "ABONOS A", 420, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "INFORMACION PAGO POSTFECHADO", 585, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "* D O C U M E N T O *", 2, k + 10, 0)
        cb.ShowTextAligned(50, "INTERNO", 2, k, 0)
        cb.ShowTextAligned(50, "EXTERNO", 40, k, 0)
        cb.ShowTextAligned(50, "FECHA", 80, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCIÓN", 120, k, 0)
        cb.ShowTextAligned(50, "AFECTADO", 235, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CXPAGAR", 355, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CXPAGAR", 420, k, 0)
        cb.ShowTextAligned(50, "COMP.", 438, k, 0)
        cb.ShowTextAligned(50, "FECHA", 480, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
End Class