Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Public Class FrmListasClientes
    Private Sub FrmListasClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim items As Integer
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT numlist FROM listasprec ORDER BY numlist;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            cblista.Items.Clear()
            cblista2.Items.Clear()
            For i = 0 To items - 1
                cblista.Items.Add(tabla.Rows(i).Item(0))
                cblista2.Items.Add(tabla.Rows(i).Item(0))
            Next
        Catch ex As Exception
        End Try
    End Sub
    '*****************************
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
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items > 0 Then
            txtcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
            Dim i As Integer = ListaAsignada(txtnitc.Text)
            If i > 0 Then
                lbnota.Text = "Lista " & i & " asignada."
                cblista.Text = i
                cblista_SelectedIndexChanged(AcceptButton, AcceptButton)
            Else
                lbnota.Text = "No tiene una lista asignada."
            End If
        Else
            txtcliente.Text = ""
            lbnota.Text = ""
        End If
    End Sub
    Function ListaAsignada(ByVal nit As String) As Integer
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT numlist FROM lista_cliente WHERE nitc='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0).Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
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
            FrmSelCliente.lbform.Text = "lista_clie"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    '**********************************
    Private Sub cblista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblista.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nomlist FROM listasprec WHERE  numlist='" & Trim(cblista.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtlista.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
            txtlista.Text = ""
        End Try
    End Sub
    '*********************************
    Private Sub cmdLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLista.Click
        If Trim(txtcliente.Text) = "" Then
            MsgBox("Por favor seleccione un cliente. ", MsgBoxStyle.Information, "SAE Control")
            txtnitc.Focus()
            Exit Sub
        ElseIf Trim(txtlista.Text) = "" Or cblista.Text = "" Then
            MsgBox("Por favor seleccione una lista de precio para asignar. ", MsgBoxStyle.Information, "SAE Control")
            cblista.Focus()
            Exit Sub
        End If
        If ListaAsignada(txtnitc.Text) > 0 Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El cliente ya tiene asiganada una lista de precio, ¿Desea Cambiar la Lista?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                Modificar()
            End If
            Exit Sub
        End If
        Asignar()
    End Sub
    Public Sub Asignar()
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?numlist", cblista.Text)
            myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            myCommand.CommandText = "INSERT INTO lista_cliente VALUES (?numlist,?nitc);"
            myCommand.ExecuteNonQuery()
            txtnitc_TextChanged(AcceptButton, AcceptButton)
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "ASIGNAR LISTA DE PRECIO AL CLIENTE: " & txtnitc.Text, "", "", "")
            End If
            '.....

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
        Catch ex As Exception
            MsgBox("Error al insertar el registro: " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    Public Sub Modificar()
        MiConexion(bda)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?numlist", cblista.Text)
            myCommand.CommandText = "UPDATE lista_cliente SET numlist=?numlist WHERE nitc='" & txtnitc.Text & "';"
            myCommand.ExecuteNonQuery()
            txtnitc_TextChanged(AcceptButton, AcceptButton)
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "MODIFICAR LISTA DE PRECIO DEL CLIENTE: " & txtnitc.Text, "", "", "")
            End If
            '.....
            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()
        Catch ex As Exception
            MsgBox("Error al modificar el registro: " & ex.ToString)
        End Try
        Cerrar()
    End Sub
    '************************************************************
    '************************************************************
    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            cblista2.Enabled = False
        Else
            cblista2.Enabled = True
        End If
    End Sub
    Private Sub cblista2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblista2.SelectedIndexChanged
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT nomlist FROM listasprec WHERE  numlist='" & Trim(cblista2.Text) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtlista2.Text = tabla.Rows(0).Item(0)
        Catch ex As Exception
            txtlista2.Text = ""
        End Try
    End Sub
    Private Sub cmdPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPDF.Click
        Dim sql As String = ""
        If rb1.Checked = True Then
            sql = "SELECT l.*, c.nitc, trim(CONCAT(t.apellidos,' ',t.nombre)) AS cliente FROM lista_cliente c LEFT JOIN (terceros t, listasprec l) " _
            & "ON l.numlist=c.numlist AND c.nitc=t.nit ORDER BY numlist,cliente;"
        Else
            If Trim(txtlista2.Text) = "" Or cblista2.Text = "" Then
                MsgBox("Por favor seleccione una lista de precio para el informe. ", MsgBoxStyle.Information, "SAE Control")
                cblista2.Focus()
                Exit Sub
            End If
            sql = "SELECT l.*, c.nitc, trim(CONCAT(t.apellidos,' ',t.nombre)) AS cliente FROM lista_cliente c LEFT JOIN (terceros t, listasprec l) " _
            & "ON l.numlist=c.numlist AND c.nitc=t.nit WHERE l.numlist='" & cblista2.Text & "' ORDER BY numlist,cliente;"
        End If
        GenerarPDF(sql)
    End Sub
    '***************************************
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer As String
    Dim FechaRep As String
    Public Sub GenerarPDF(ByVal sql)
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim tope As Integer
        FechaRep = Now.ToString
        Dim l As String = ""
        '****************************************************************************
        Try
            pag = 1
            tope = 75
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            BannerLP()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            Dim tabla As New DataTable
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            For i = 0 To tabla.Rows.Count - 1
                k = k - 10
                If k <= tope Then
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    BannerLP()
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                If l <> tabla.Rows(i).Item("nomlist") Then
                    l = tabla.Rows(i).Item("nomlist")
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    cb.ShowTextAligned(50, "*** LISTA NUMERO " & tabla.Rows(i).Item("numlist") & " - " & l & " ***", 20, k, 0)
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                    k = k - 10
                End If
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tabla.Rows(i).Item("numlist"), 40, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("nitc"), 100, k, 0)
                cb.ShowTextAligned(50, tabla.Rows(i).Item("cliente"), 180, k, 0)
            Next
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub BannerLP()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 780, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "INFORME DE LISTAS DE PRECIOS POR CLIENTES", 300, 770, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 760, 0)
        k = 750
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NUM LISTA", 40, k, 0)
        cb.ShowTextAligned(50, "NIT / CC", 100, k, 0)
        cb.ShowTextAligned(50, "NOMBRE / RAZON SOCIAL CLIENTE", 180, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        cb.ShowTextAligned(50, "* NOTA: Los clientes sin listas de precios asignadas al momento de facturar tomaran el valor de la primera lista.", 20, 20, 0)
    End Sub
    '************************************************************
    '************************************************************
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
End Class