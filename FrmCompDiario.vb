Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmCompDiario

    Private Sub FrmCompDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT cd FROM parotdoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count < 1 Then
            MsgBox("Favor no han creado tipo de documento para los comprobantes de diario (del grupo CD), verifique.   ", MsgBoxStyle.Information, "Verificando")
            Me.Close()
            Exit Sub
        Else
            lbdoc.Text = tabla.Rows(0).Item(0)
            lbnomdoc.Text = tipodocumento(tabla.Rows(0).Item(0))
        End If
        '***********************************************
        lbper.Text = PerActual & " - "
        txtdia.Text = Now.Day
        txtperiodo.Text = "/" & PerActual
        txtdia_LostFocus(AcceptButton, AcceptButton)
        txtelaborado.Text = "Usuario " & FrmPrincipal.lbuser.Text
        Try
            Dim tablacomp As New DataTable
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            lbcompa.Text = tablacomp.Rows(0).Item("descripcion")
            lbnit.Text = "NIT: " & tablacomp.Rows(0).Item("nit")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        txtdia.Focus()
        cmdgenerar_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtdia, e)
        End If
    End Sub
    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        Try
            Dim mifec As Date
            If Val(txtdia.Text) < 10 Then txtdia.Text = "0" & Val(txtdia.Text)
            mifec = txtdia.Text & txtperiodo.Text
            lbper.Text = mifec
        Catch ex As Exception
            txtdia.Text = "01"
            txtdia.Focus()
        End Try
    End Sub

    Private Sub txtciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtciudad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            validarletra(txtciudad, e)
        End If
    End Sub
    Private Sub nivel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nivel.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub d1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d1.CheckedChanged
        If d1.Checked = True Then
            txtdoc2.Text = ""
            txtdoc.Text = ""
            txtdoc.Enabled = False
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub d2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.CheckedChanged
        If d2.Checked = True Then
            txtdoc.Enabled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtdoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdoc.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtdoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdoc.LostFocus
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdoc2.Text = tabla.Rows(0).Item("descripcion")
        Else
            txtdoc2.Text = ""
        End If
    End Sub
    Private Sub txtdoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdoc.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & txtdoc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            txtdoc2.Text = tabla.Rows(0).Item("descripcion")
        Else
            txtdoc2.Text = ""
        End If
    End Sub

    Private Sub txtelaborado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtelaborado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtrevisado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrevisado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdgenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdgenerar.Click
        Generar()
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        cmdgenerar_Click(AcceptButton, AcceptButton)
        GenerarPDF()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    '**********************************************
    Public j As Integer
    Public Sub Generar()
        Dim sql As String
        If txtdoc2.Text <> "" Then 'POR TIPO DE DOCUMENTO
            sql = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE (dia='" & txtdia.Text & "' OR dia='" & Val(txtdia.Text) & "') AND tipodoc='" & Trim(txtdoc.Text) & "' ORDER BY tipodoc,codigo,doc;"
        Else ' TODOS LOS DOCUEMTOS
            sql = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE dia='" & txtdia.Text & "' OR dia='" & Val(txtdia.Text) & "' ORDER BY tipodoc,codigo,doc;"
        End If
        Dim tabla As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        grilla.Rows.Clear()
        If tabla.Rows.Count > 0 Then
            grilla.RowCount = 1
        Else
            grilla.RowCount = 9
        End If
        Dim sdb As Double = 0
        Dim scr As Double = 0
        Dim tipodoc As String = ""
        Dim cuenta As String = ""
        Dim i As Integer
        j = -1
        For i = 0 To tabla.Rows.Count - 1
            Try
                'If i < tabla.Rows.Count - 1 Then
                If tipodoc = "" Then
                    tipodoc = tabla.Rows(i).Item("tipodoc")
                    NuevoDoc(tipodoc)
                End If
                'CONTROLAR DOCUMENTOS
                If tipodoc <> tabla.Rows(i).Item("tipodoc") Then
                    SubtotalCuenta(cuenta, tipodoc)
                    SubtotalDocumento(tipodoc)
                    tipodoc = tabla.Rows(i).Item("tipodoc")
                    NuevoDoc(tipodoc)
                    cuenta = CuentaNivel(tabla.Rows(i).Item("codigo"))
                    NuevaCuenta(cuenta)
                End If
                'CONTROLAR CUENTAS
                If cuenta = "" Then
                    cuenta = CuentaNivel(tabla.Rows(i).Item("codigo"))
                    NuevaCuenta(cuenta)
                ElseIf cuenta <> CuentaNivel(tabla.Rows(i).Item("codigo")) Then
                    SubtotalCuenta(cuenta, tipodoc)
                    cuenta = CuentaNivel(tabla.Rows(i).Item("codigo"))
                    NuevaCuenta(cuenta)
                End If
                'End If
                'CONTROLAR AUXLIARES
                j = j + 1
                grilla.RowCount = grilla.RowCount + 1
                grilla.Item(0, j).Value = tabla.Rows(i).Item("codigo")
                grilla.Item(1, j).Value = tabla.Rows(i).Item("descri")
                grilla.Item(2, j).Value = tabla.Rows(i).Item("tipodoc") & NumeroDoc(tabla.Rows(i).Item("doc"))
                If Moneda(tabla.Rows(i).Item("debito")) <> "0,00" Then
                    grilla.Item(3, j).Value = Moneda(tabla.Rows(i).Item("debito"))
                    sdb = sdb + tabla.Rows(i).Item("debito")
                End If
                If Moneda(tabla.Rows(i).Item("credito")) <> "0,00" Then
                    grilla.Item(4, j).Value = Moneda(tabla.Rows(i).Item("credito"))
                    scr = scr + tabla.Rows(i).Item("credito")
                End If
            Catch ex As Exception
            End Try
        Next
        '******************************************
        If Trim(tipodoc) <> "" Then
            SubtotalCuenta(cuenta, tipodoc)
            SubtotalDocumento(tipodoc)
        Else
            grilla.Item(0, 0).Value = "****"
            grilla.Item(1, 0).Value = "***** NO SE HAN REGISTRADO MOVIMIENTOS *****"
            grilla.Item(2, 0).Value = "*************                      *****************                   ********************"
            grilla.Item(3, 0).Value = "************"
            grilla.Item(4, 0).Value = "************"
        End If
        '**********************************************************
        lbdb.Text = Moneda(sdb)
        lbcr.Text = Moneda(scr)
    End Sub
    Function CuentaNivel(ByVal codigo As String)
        Dim tam As Integer = 0
        Dim cuenta = ""
        If nivel.Value = 1 Then
            tam = 1
        ElseIf nivel.Value = 2 Then
            tam = 2
        ElseIf nivel.Value = 3 Then
            tam = 4
        ElseIf nivel.Value = 4 Then
            tam = 6
        ElseIf nivel.Value = 5 Then
            tam = codigo.Length
        End If
        For i = 0 To tam - 1
            cuenta = cuenta & codigo(i)
        Next
        Return cuenta
    End Function
    Public Sub NuevaCuenta(ByVal codigo As String)
        grilla.RowCount = grilla.RowCount + 1
        j = j + 1
        grilla.Item(0, j).Value = "-- " & codigo
        grilla.Item(1, j).Value = tipocuenta(codigo)
        grilla.Item(2, j).Value = "------------------                     -------------------                  ----------------------"
        grilla.Item(3, j).Value = "------------------"
        grilla.Item(4, j).Value = "------------------"
    End Sub
    Public Sub SubtotalCuenta(ByVal codigo As String, ByVal tipodoc As String)
        grilla.RowCount = grilla.RowCount + 1
        j = j + 1
        grilla.Item(0, j).Value = "--Sub. " & codigo
        grilla.Item(1, j).Value = tipocuenta(codigo)
        grilla.Item(2, j).Value = "------------------"
        '***************************************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT SUM(debito), SUM(credito) FROM documentos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & tipodoc & "' AND (dia='" & txtdia.Text & "' OR dia='" & Val(txtdia.Text) & "') AND codigo LIKE '" & codigo & "%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            grilla.Item(3, j).Value = Moneda(tabla.Rows(0).Item(0))
        Catch ex As Exception
            grilla.Item(3, j).Value = Moneda(0)
        End Try
        Try
            grilla.Item(4, j).Value = Moneda(tabla.Rows(0).Item(1))
        Catch ex As Exception
            grilla.Item(4, j).Value = Moneda(0)
        End Try
    End Sub
    Function tipocuenta(ByVal codigo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & codigo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            Return tabla.Rows(0).Item("descripcion")
        Else
            Return ""
        End If
    End Function
    '/////////////////////////////
    Public Sub NuevoDoc(ByVal tipodoc As String)
        grilla.RowCount = grilla.RowCount + 1
        j = j + 1
        grilla.Item(0, j).Value = "** " & tipodoc & " **"
        grilla.Item(1, j).Value = tipodocumento(tipodoc)
        grilla.Item(2, j).Value = "*************                      *****************                   ********************"
        grilla.Item(3, j).Value = "************"
        grilla.Item(4, j).Value = "************"
    End Sub
    Public Sub SubtotalDocumento(ByVal tipodoc As String)
        grilla.RowCount = grilla.RowCount + 1
        j = j + 1
        grilla.Item(0, j).Value = "** SUB TOTAL **"
        grilla.Item(1, j).Value = tipodoc & " " & tipodocumento(tipodoc)
        grilla.Item(2, j).Value = "************"
        '***************************************************************
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT SUM(debito), SUM(credito) FROM documentos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & tipodoc & "' AND (dia='" & txtdia.Text & "' OR dia='" & Val(txtdia.Text) & "');"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            grilla.Item(3, j).Value = Moneda(tabla.Rows(0).Item(0))
        Catch ex As Exception
            grilla.Item(3, j).Value = Moneda(0)
        End Try
        Try
            grilla.Item(4, j).Value = Moneda(tabla.Rows(0).Item(1))
        Catch ex As Exception
            grilla.Item(4, j).Value = Moneda(0)
        End Try
    End Sub
    Function tipodocumento(ByVal tipo As String)
        If tipo = "CA" Then
            Return "CIERRE ANUAL"
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & tipo & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0).Item("descripcion")
            Else
                Return ""
            End If
        End If
       
    End Function
    Function niveles()
        If nivel.Value = 1 Then
            Return "Clase"
        ElseIf nivel.Value = 2 Then
            Return "Grupo"
        ElseIf nivel.Value = 3 Then
            Return "Cuenta"
        ElseIf nivel.Value = 4 Then
            Return "Sub Cuenta"
        Else
            Return "Auxiliar"
        End If
    End Function
    '******************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 60
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg(1)
            cb.BeginText()
            '''''''''''BANNER''''''''''''
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            Banner()
            k = 710
            For i = 0 To grilla.RowCount - 1
                k = k - 19
                If i = grilla.RowCount - 1 Then tope = 160
                If k < tope Then
                    k = 760
                    cb.EndText()
                    oDoc.NewPage()
                    ColocarImg(1)
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Banner()
                    k = 691
                End If
                cb.EndText()
                ColocarImg(2)
                cb.BeginText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
                Try
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value.ToString, 55), 76, k + 1, 0)
                Catch ex As Exception
                End Try
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(2, i).Value, 340, k + 1, 0)
                If Moneda(grilla.Item(3, i).Value) <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 493, k + 1, 0)
                If Moneda(grilla.Item(4, i).Value) <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(4, i).Value), 578, k + 1, 0)
            Next
            '************************
            cb.EndText()
            k = k - 147
            ColocarImg(3)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = k - 10
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            '****************************************************
            k = k + 120
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(lbdb.Text), 493, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(lbcr.Text), 578, k, 0)
            k = k - 80
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 10, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 207, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtrevisado.Text, 402, k, 0)

            '*********** FIN ***********************
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
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Banner()
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbdoc.Text & " " & lbper.Text, 433, 797, 0)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 820
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), 10, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), 10, k, 0)
        k = k - 10
        pag = pag + 1
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "PAGINA No: " & pag, 10, k, 0)
        k = 767
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtciudad.Text, 250, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 125, k, 0)
        k = 742
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, nivel.Value, 153, k, 0)
        If d2.Checked = True And txtdoc2.Text <> "" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  **** REPORTE GENERADO PARA LOS DOCUMENTOS TIPO: " & txtdoc.Text & " - " & txtdoc2.Text & " ****", 180, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "  **** REPORTE GENERADO PARA TODOS LOS TIPOS DE DOCUMENTOS ****", 180, k, 0)
        End If
    End Sub
    Public Sub ColocarImg(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CD\CD1.jpg")
                img.SetAbsolutePosition(0, 710)
                img.ScaleToFit(598, 250)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CD\CD2.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 50)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CD\CD3.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 170)
            End If
            img.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal pos As Integer, ByVal tam As Integer)
        Dim s As Integer = 1
        linea = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = " " And j > tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
                    linea = ""
                    k = k - 10
                    s = s + 1
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
    End Sub
End Class