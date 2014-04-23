﻿Public Class FrmSelFacturaCompra
    Public fila As Integer
    Private Sub FrmSelFacturaCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        myCommand.CommandText = "SELECT doc_ext, doc, fecha, nomnit, total, pagado, (total - pagado) AS saldo, tipo, num FROM ctas_x_pagar WHERE nitc='" & FrmInfoFactCPP.txtnit.Text & "' AND tipo='" & FrmInfoFactCPP.txttipo.Text & "' ORDER BY doc,fecha;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No han creado facturas para la busquedad, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item("doc", i).Value = tabla.Rows(i).Item("doc_ext")
            gitems.Item("docu", i).Value = tabla.Rows(i).Item("doc")
            gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fecha"), 10)
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item("total", i).Value = Moneda(tabla.Rows(i).Item("total"))
            gitems.Item("abono", i).Value = Moneda(tabla.Rows(i).Item("pagado"))
            gitems.Item("saldo", i).Value = Moneda(tabla.Rows(i).Item("saldo"))
            gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipo")
            gitems.Item("numero", i).Value = NumeroDoc(tabla.Rows(i).Item("num"))
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        FrmInfoFactCPP.lbsel.Text = "si"
        FrmInfoFactCPP.txttipo.Text = gitems.Item("tipo", mifila).Value()
        FrmInfoFactCPP.txtnumfac.Text = gitems.Item("numero", mifila).Value()
        gitems.Focus()
        Me.Close()
    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        cad = UCase(cad)
        Dim cad2, aux As String
        For i = 0 To gitems.RowCount - 1
            aux = gitems.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    Dim C As Integer = 1, F As Integer = i
                    gitems.CurrentCell = gitems(C, F)
                    gitems.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
End Class