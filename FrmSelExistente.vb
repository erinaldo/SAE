Public Class FrmSelExistente
    Public fila As Integer

    Private Sub FrmSelExistente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtcuenta.Text = ""
    End Sub
    Private Sub FrmSelExistente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        Dim items As Integer
        myCommand.CommandText = "SELECT DISTINCT(doc) FROM documentos" & lbper.Text & " WHERE tipodoc='" & lbdoc.Text & "' ORDER BY doc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            MsgBox("No han creado ningún documentos del tipo " & lbdoc.Text & " en el periodo " & lbper.Text & ", Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
            Exit Sub
        End If
        Try
            gcuenta.Rows.Clear()
        Catch ex As Exception
        End Try
        gcuenta.RowCount = items + 1
        For i = 0 To items - 1
            documentos(tabla.Rows(i).Item(0), i)
        Next
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        'BuscarGrilla(txtcuenta.Text)
        gcuenta.Focus()
    End Sub
    Public Sub documentos(ByVal doc As Integer, ByVal f As Integer)
        Dim tabla As New DataTable
        Try
            myCommand.CommandText = "SELECT doc,tipodoc,descri,nit,dia,periodo FROM documentos" & lbper.Text & " WHERE tipodoc='" & lbdoc.Text & "' AND doc=" & doc & " ORDER BY doc,item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            gcuenta.Item(0, f).Value = tabla.Rows(0).Item("tipodoc")
            gcuenta.Item(1, f).Value = NumeroDoc(tabla.Rows(0).Item("doc"))
            gcuenta.Item(2, f).Value = tabla.Rows(0).Item("descri")
            gcuenta.Item(3, f).Value = tabla.Rows(0).Item("nit")
            gcuenta.Item(4, f).Value = tabla.Rows(0).Item("dia") & "/" & tabla.Rows(0).Item("periodo")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gcuenta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellDoubleClick
        cmditems_Click(AcceptButton, AcceptButton)
    End Sub

    Private Sub gcuenta_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO BUSCAR
                Case 1
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                Case 2
                    fila = e.RowIndex
                    cmditems_Click(AcceptButton, AcceptButton)
                
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gcuenta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gcuenta.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If gcuenta.Item(1, fila - 1).Value = "" Then Exit Sub
            fila = fila - 1
            cmditems_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        If cad = "" Then Exit Sub
        Dim cad2, aux As String
        For i = 0 To gcuenta.RowCount - 2
            aux = gcuenta.Item(1, i).Value.ToString
            If Val(aux.Length) >= Val(cad.Length) Then
                cad2 = ""
                For j = 0 To cad.Length - 1
                    cad2 = cad2 & aux(j)
                Next
                If cad = cad2 Then
                    fila = i
                    Dim C As Integer = 1, F As Integer = i
                    gcuenta.CurrentCell = gcuenta(C, F)
                    gcuenta.Focus()
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        validarnumero(txtcuenta, e)
        If e.KeyChar = Chr(Keys.Enter) Then
            Try
                txtcuenta.Text = NumeroDoc(txtcuenta.Text)
            Catch ex As Exception
                txtcuenta.Text = NumeroDoc(0)
            End Try
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        Try
            txtcuenta.Text = NumeroDoc(txtcuenta.Text)
        Catch ex As Exception
            txtcuenta.Text = NumeroDoc(0)
        End Try
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If gcuenta.Item(1, fila).Value() = "" Then Exit Sub
        Select Case lbform.Text
            Case "doc_exi"
                FrmDocExistente.lbsel.Text = "si"
                FrmDocExistente.txtnumero.Text = gcuenta.Item(1, fila).Value()
                Me.Close()
            Case "doc_exi2"
                FrmEgresoNomina.lbsel.Text = "si"
                FrmEgresoNomina.txtnumero.Text = gcuenta.Item(1, fila).Value()
                Me.Close()
        End Select
    End Sub

  
End Class