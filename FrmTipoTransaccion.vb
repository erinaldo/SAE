Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class FrmTipoTransaccion
    Public fil As Integer
    Private Sub FrmTipoTransaccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        gitems.Rows.Clear()
        If lbform.Text = "SI" Then
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE grupo='SI';"
        Else
            myCommand.CommandText = "SELECT * FROM tipdoc WHERE grupo<>'SI';"
        End If
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        gitems.RowCount = tabla.Rows.Count + 2
        If tabla.Rows.Count <= 0 Then
            MsgBox("Favor cree los tipos de documentos para poder crearlos.   ", MsgBoxStyle.Information, "Verificando")
            Me.Close()
        End If
        For i = 0 To tabla.Rows.Count - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item(1, i).Value = tabla.Rows(i).Item("descripcion")
            gitems.Item(2, i).Value = tabla.Rows(i).Item("tipodoc")
            gitems.Item(3, i).Value = tabla.Rows(i).Item("grupo")
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        BuscarDoc(e.RowIndex)
    End Sub
    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION
                    BuscarDoc(e.RowIndex)
                Case 1
                    BuscarDoc(e.RowIndex)
                Case 2
                    BuscarDoc(e.RowIndex)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fil = e.RowIndex
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarDoc(fil - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        BuscarDoc(fil)
    End Sub
    Public Sub BuscarDoc(ByVal fila As Integer)
        If gitems.Item(2, fila).Value = "" Then Exit Sub
        Select Case lbform.Text
            Case "TODOS"
                TODOS(fila)
            Case "SI"
                SI(fila)
            Case "inv_tr"
                FrmParInventarios.txttra.Text = gitems.Item(2, fila).Value
            Case "inv_aj"
                FrmParInventarios.txtaju.Text = gitems.Item(2, fila).Value
            Case "inv_sa"
                FrmParInventarios.txtsal.Text = gitems.Item(2, fila).Value
            Case "inv_en"
                FrmParInventarios.txtent.Text = gitems.Item(2, fila).Value
            Case "doc_exi"
                FrmDocExistente.txtdoc.Text = gitems.Item(2, fila).Value
            Case "odoc_ce"
                FrmParametrosOtrosDoc.txt_ce.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_nce.Text = gitems.Item(1, fila).Value
            Case "odoc_ci"
                FrmParametrosOtrosDoc.txt_ci.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_nci.Text = gitems.Item(1, fila).Value
            Case "odoc_rc"
                FrmParametrosOtrosDoc.txt_rc.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_nrc.Text = gitems.Item(1, fila).Value
            Case "odoc_nd"
                FrmParametrosOtrosDoc.txt_nd.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_nnd.Text = gitems.Item(1, fila).Value
            Case "odoc_nc"
                FrmParametrosOtrosDoc.txt_nc.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_nnc.Text = gitems.Item(1, fila).Value
            Case "odoc_cd"
                FrmParametrosOtrosDoc.txt_cd.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_ncd.Text = gitems.Item(1, fila).Value
            Case "odoc_aj"
                FrmParametrosOtrosDoc.txt_aj.Text = gitems.Item(2, fila).Value
                FrmParametrosOtrosDoc.txt_naj.Text = gitems.Item(1, fila).Value
        End Select
        Me.Close()
    End Sub
    Public Sub SI(ByVal fila As Integer)
        If gitems.Item(2, fila).Value = "" Then Exit Sub
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT p.inicio FROM sae.periodos p LEFT JOIN (sae.companias c) ON p.codigo = c.codigo WHERE c.login = '" & FrmPrincipal.lbcompania.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        myCommand.Parameters.Clear()
        BuscarPeriodo()
        Dim mi_per As String
        mi_per = tabla2.Rows(0).Item(0)
        If mi_per = "00" Then mi_per = "01"
        Try
            FrmSaldosIniciales.txtperiodo.Text = Today.Day & "/" & mi_per & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Catch ex As Exception
            FrmSaldosIniciales.txtperiodo.Text = "01/" & mi_per & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        End Try
        'FrmSaldosIniciales.txtdia.Text = Today.Day
        FrmSaldosIniciales.TxtDocumento.Text = gitems.Item(2, fila).Value
        FrmSaldosIniciales.txtDoc.Text = gitems.Item(1, fila).Value
        myCommand.CommandText = "SELECT actual01 FROM tipdoc WHERE tipodoc='" & gitems.Item(2, fila).Value & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        FrmSaldosIniciales.TxtNumero.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
    End Sub
    Public Sub TODOS(ByVal fila As Integer)
        If gitems.Item(2, fila).Value = "" Then Exit Sub
        BuscarPeriodo()
        Try
            FrmEntradaDatos.txtperiodo.Text = "/" & PerActual
            FrmEntradaDatos.txtdia.Text = Today.Day
            Dim fe As Date = CDate(Today.Day.ToString & "/" & PerActual)
        Catch ex As Exception
            FrmEntradaDatos.txtdia.Text = "01"
        End Try
        
        FrmEntradaDatos.TxtDocumento.Text = gitems.Item(2, fila).Value
        FrmEntradaDatos.txtDoc.Text = gitems.Item(1, fila).Value
        If gitems.Item(3, fila).Value = "FC" Then
            FrmEntradaDatos.Lbper.Text = gitems.Item(2, fila).Value
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT actualfc FROM tipdoc WHERE tipodoc='" & gitems.Item(2, fila).Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            FrmEntradaDatos.TxtNumero.Text = NumeroDoc(Val(tabla.Rows(0).Item(0).ToString) + 1)
        Else

            Dim cadena, cad As String
            Dim tabla2 As New DataTable
            BuscarPeriodo()
            FrmEntradaDatos.Lbper.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "-" & PerActual(0) & PerActual(1) & "- "
            cadena = PerActual
            cad = "actual"
            For x = 0 To cadena.Length - 1
                If cadena.Chars(x) = "/" Then
                    Exit For
                Else
                    cad = cad & cadena.Chars(x)
                End If
            Next
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT " & cad & " FROM tipdoc WHERE tipodoc='" & gitems.Item(2, fila).Value & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            FrmEntradaDatos.TxtNumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(0).ToString) + 1)

        End If
        FrmEntradaDatos.TxtDocumento.Focus()
    End Sub
End Class