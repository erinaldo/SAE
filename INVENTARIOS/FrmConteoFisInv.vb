Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class FrmConteoFisInv

    Private Sub FrmConteoFisInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtperiodo.Text = "/" & PerActual
            txtdia.Text = Now.Day
            Try
                Dim fecha As Date
                fecha = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
                txtdia.Text = "01"
            End Try
            '*******************************************************
            Dim tabla As New DataTable
            Dim items As Integer
            myCommand.CommandText = "SELECT * FROM bodegas ORDER BY numbod;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No han creado ninguna Bodega, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                Me.Close()
                Exit Sub
            End If
            cbbodega.Items.Clear()
            For i = 0 To items - 1
                cbbodega.Items.Add(tabla.Rows(i).Item("numbod"))
            Next
            cbbodega.Text = tabla.Rows(0).Item("numbod")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Try
            FrmReproInven.Bt_repro_Click(AcceptButton, AcceptButton)
            GenerarConteo()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpdf.Click
        GenerarPDF()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
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
    Private Sub cbbodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbodega.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & cbbodega.Text & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtnombod.Text = tabla.Rows(0).Item("nombod")
        Else
            txtnombod.Text = ""
        End If
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        validarnumero(txtdia, e)
    End Sub
    '******************************************************
    Private Sub rbca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbca.CheckedChanged
        txtctainv.Enabled = False
        txtctacos.Enabled = False
    End Sub
    Private Sub rbc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbc.CheckedChanged
        txtctainv.Enabled = True
        txtctacos.Enabled = True
    End Sub
    Private Sub txtctainv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctainv.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Trim(txtctainv.Text) = "" Then txtctainv.Text = "14"
            BuscarCuentas("inv")
            SendKeys.Send("{TAB}")
        Else
            validarnumero(txtctainv, e)
        End If
    End Sub
    Private Sub txtctainv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctainv.LostFocus
        If Trim(txtctainv.Text) = "" Then txtctainv.Text = "14"
        BuscarCuentas("inv")
    End Sub
    Private Sub txtctacos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtctacos.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Trim(txtctacos.Text) = "" Then txtctacos.Text = "61"
            BuscarCuentas("cos")
        Else
            validarnumero(txtctacos, e)
        End If
    End Sub
    Private Sub txtctacos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctacos.LostFocus
        If Trim(txtctacos.Text) = "" Then txtctacos.Text = "61"
        BuscarCuentas("cos")
    End Sub
    Public Sub BuscarCuentas(ByVal mitxt As String)
        Dim tabla As New DataTable
        Dim items As Integer
        If mitxt = "inv" Then
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & txtctainv.Text & "' AND nivel='Auxiliar';"
        Else
            myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo='" & txtctacos.Text & "' AND nivel='Auxiliar';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            If mitxt = "inv" Then
                txtnominv.Text = ""
                Try
                    FrmCuentas.lbform.Text = "cfi_inv"
                    FrmCuentas.txtcuenta.Text = txtctainv.Text
                    FrmCuentas.lbaux.Text = "auxiliar"
                    FrmCuentas.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                txtnomcos.Text = ""
                Try
                    FrmCuentas.lbform.Text = "cfi_cos"
                    FrmCuentas.txtcuenta.Text = txtctacos.Text
                    FrmCuentas.lbaux.Text = "auxiliar"
                    FrmCuentas.ShowDialog()
                Catch ex As Exception
                End Try
            End If
        Else
            If mitxt = "inv" Then
                txtnominv.Text = tabla.Rows(0).Item("descripcion")
            Else
                txtnomcos.Text = tabla.Rows(0).Item("descripcion")
            End If
        End If
    End Sub
    '********************************************************
    Public Sub GenerarConteo()
        If cbbodega.Text = "" Then
            MsgBox("Verifique la bodega de consulta.   ", MsgBoxStyle.Information, "SAE Control")
            cbbodega.Focus()
            Exit Sub
        End If
        Try
            Dim fecha As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("Verifique el dia del conteo.   ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Exit Sub
        End Try
        If rbsi.Checked = True And rbc.Checked = True Then 'hara ajuste autoaticamente(si es necesario)
            If Trim(txtnominv.Text) = "" Or Trim(txtnominv.Text) = "" Then
                MsgBox("Verifique las cuentas para los ajustes.   ", MsgBoxStyle.Information, "SAE Control")
                txtctainv.Focus()
                Exit Sub
            End If
        End If
        '********************************************************************************
        Dim Sql As String = ""
        If rbt.Checked = True Then 'todos los articulos
            Sql = "SELECT a.codart, a.nomart, c.costuni,a.referencia, a.cue_inv,a.cue_cos, c.cant" & Trim(cbbodega.Text) & " FROM articulos a  LEFT JOIN (con_inv c) ON a.codart = c.codart WHERE c.periodo='" & PerActual(0) & PerActual(1) & "'  AND a.estado='Activo' ORDER BY a.codart ;"
        Else ' rango de articulos
            If Trim(txtn1.Text) = "" Or Trim(txtn2.Text) = "" Then
                MsgBox("Varifique los rangos de los articulos.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            ElseIf txtini.Text > txtfin.Text Then
                MsgBox("Varifique los rangos de los articulos. " & txtini.Text & " debe ser menor o igual que " & txtfin.Text & ".", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            Sql = "SELECT a.codart, a.nomart, c.costuni,a.referencia, a.cue_inv,a.cue_cos, c.cant" & Trim(cbbodega.Text) & " FROM articulos a LEFT JOIN (con_inv c) ON a.codart = c.codart WHERE c.periodo='" & PerActual(0) & PerActual(1) & "' AND (c.codart>='" & txtini.Text & "' AND c.codart<='" & txtfin.Text & "') ORDER BY a.codart AND a.estado='Activo';"
        End If
        Dim ta As New DataTable
        myCommand.CommandText = Sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then
            MsgBox("No hay articulos para mostrar.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        FrmEditarConteo.gitems.RowCount = 1
        FrmEditarConteo.gitems.Rows.Clear()
        FrmEditarConteo.gitems.RowCount = ta.Rows.Count
        For i = 0 To ta.Rows.Count - 1
            FrmEditarConteo.gitems.Item("codigo", i).Value = ta.Rows(i).Item("codart")
            FrmEditarConteo.gitems.Item("referencia", i).Value = ta.Rows(i).Item("referencia")
            FrmEditarConteo.gitems.Item("descripcion", i).Value = ta.Rows(i).Item("nomart")
            FrmEditarConteo.gitems.Item("cantlibro", i).Value = Moneda(ta.Rows(i).Item("cant" & Trim(cbbodega.Text)))
            FrmEditarConteo.gitems.Item("cantfisica", i).Value = Moneda(ta.Rows(i).Item("cant" & Trim(cbbodega.Text)))
            FrmEditarConteo.gitems.Item("costo", i).Value = Moneda(ta.Rows(i).Item("costuni"))
            If rbsi.Checked = True And rbc.Checked = True Then 'hara ajuste autoaticamente(si es necesario)
                FrmEditarConteo.gitems.Item("ctainv", i).Value = txtctainv.Text 'cuentas inventario del ajuste
                FrmEditarConteo.gitems.Item("ctacos", i).Value = txtctacos.Text 'cuenta costo del ajuste
            Else
                FrmEditarConteo.gitems.Item("ctainv", i).Value = ta.Rows(i).Item("cue_inv")
                FrmEditarConteo.gitems.Item("ctacos", i).Value = ta.Rows(i).Item("cue_cos")
            End If
        Next
        '*************************************************************************************
        FrmEditarConteo.lbnumbod.Text = cbbodega.Text
        FrmEditarConteo.lbnombod.Text = txtnombod.Text
        FrmEditarConteo.txtdia.Text = txtdia.Text
        FrmEditarConteo.txtperiodo.Text = txtperiodo.Text
        FrmEditarConteo.ShowDialog()
    End Sub
    '***********************************************************
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
            If cbbodega.Text = "" Then
                MsgBox("Verifique la bodega de consulta.   ", MsgBoxStyle.Information, "SAE Control")
                cbbodega.Focus()
                Exit Sub
            End If
            '********************************************************************************
            Dim Sql As String = ""
            If rbt.Checked = True Then 'todos los articulos
                Sql = "SELECT a.codart, a.nomart, a.referencia, a.cue_inv,a.cue_cos, c.cant" & Trim(cbbodega.Text) & " FROM  articulos a LEFT JOIN (con_inv c) ON a.codart = c.codart WHERE c.periodo='" & PerActual(0) & PerActual(1) & "'  AND a.estado='Activo' ORDER BY a.codart;"
            Else ' rango de articulos
                If Trim(txtn1.Text) = "" Or Trim(txtn2.Text) = "" Then
                    MsgBox("Verifique los rangos de los articulos.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                ElseIf txtini.Text > txtfin.Text Then
                    MsgBox("Verifique los rangos de los articulos. " & txtini.Text & " debe ser menor o igual que " & txtfin.Text & ".", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                Sql = "SELECT a.codart, a.nomart, a.referencia, a.cue_inv,a.cue_cos, c.cant" & Trim(cbbodega.Text) & " FROM articulos a LEFT JOIN (con_inv c) ON a.codart = c.codart WHERE c.periodo='" & PerActual(0) & PerActual(1) & "' AND (c.codart>='" & txtini.Text & "' AND c.codart<='" & txtfin.Text & "') AND a.estado='Activo' ORDER BY a.codart;"
            End If
            Dim ta As New DataTable
            myCommand.CommandText = Sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            If ta.Rows.Count = 0 Then
                MsgBox("No hay articulos para mostrar.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
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
            For i = 0 To ta.Rows.Count - 1
                k = k - 10
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
                cb.ShowTextAligned(50, ta.Rows(i).Item("referencia"), 60, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(ta.Rows(i).Item("cant" & Trim(cbbodega.Text))), 485, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "_________________", 585, k, 0)
                Control_de_linea(ta.Rows(i).Item("nomart"), 120, 60)
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
    Public Sub Banner()
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, "COMPAÑIA: " & tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "BODEGA: " & cbbodega.Text & " " & txtnombod.Text, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 770, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ARTICULOS PARA CONTEO FÍSICO ", 300, 760, 0)
        cb.ShowTextAligned(50, "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ ", 0, 750, 0)
        k = 740
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CODIGO", 10, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCIÓN", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "REFERENCIA", 60, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANT. LIBROS", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CANT. FÍSICA", 585, k, 0)
        k = k - 10
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
End Class