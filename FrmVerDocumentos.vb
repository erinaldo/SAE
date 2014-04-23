Public Class FrmVerDocumentos
    Public fila, sw As Integer
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        Try
            If gitems.Item(2, mifila).Value() = "" Then Exit Sub
            Select Case lbform.Text
                Case "doc"
                    Dim cad As String
                    BuscarPeriodo()
                    cad = "documentos" & PerActual(0) & PerActual(1)
                    BuscarDocumento(cad, Val(gitems.Item(3, mifila).Value()), gitems.Item(2, mifila).Value(), gitems.Item(0, mifila).Value())
                Case "si"
                    BuscarDocumento2("documentos00", Val(gitems.Item(3, mifila).Value()), gitems.Item(2, mifila).Value(), gitems.Item(0, mifila).Value())
                Case "fr"
            End Select
            gitems.Focus()
            sw = 1
            Me.Close()
        Catch ex As Exception
            If gitems.Item("desc", mifila).Value = "CA" Then
                Me.Close()
            End If
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal tab As String, ByVal doc As String, ByVal tipo As String, ByVal fil As Integer)
       
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & tab & " WHERE doc=" & doc & " AND tipodoc='" & tipo & "' ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows(0).Item("doc") < 10 Then
            FrmEntradaDatos.TxtNumero.Text = "000" & tabla.Rows(0).Item("doc")
        ElseIf tabla.Rows(0).Item("doc") < 100 Then
            FrmEntradaDatos.TxtNumero.Text = "00" & tabla.Rows(0).Item("doc")
        ElseIf tabla.Rows(0).Item("doc") < 1000 Then
            FrmEntradaDatos.TxtNumero.Text = "0" & tabla.Rows(0).Item("doc")
        Else
            FrmEntradaDatos.TxtNumero.Text = tabla.Rows(0).Item("doc")
        End If
        FrmEntradaDatos.TxtDocumento.Text = tabla.Rows(0).Item("tipodoc")
        FrmEntradaDatos.TxtDocumento.ReadOnly = True
        FrmEntradaDatos.lbnroobs.Text = fil
        FrmEntradaDatos.lbestado.Text = "CONSULTA"
        BuscarTipo(tabla.Rows(0).Item("tipodoc"))
        FrmEntradaDatos.txtdia.Text = tabla.Rows(0).Item("dia")
        FrmEntradaDatos.txtperiodo.Text = "/" & tabla.Rows(0).Item("periodo")
        FrmEntradaDatos.grilla.RowCount = tabla.Rows.Count + 1
        For i = 0 To tabla.Rows.Count - 1
            FrmEntradaDatos.grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
            FrmEntradaDatos.grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
            FrmEntradaDatos.grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
            FrmEntradaDatos.grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
            FrmEntradaDatos.grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
            FrmEntradaDatos.grilla.Item(5, i).Value = tabla.Rows(i).Item("diasv")
            FrmEntradaDatos.grilla.Item(6, i).Value = tabla.Rows(i).Item("fechaven")
            FrmEntradaDatos.grilla.Item(7, i).Value = tabla.Rows(i).Item("nit")
        Next
    End Sub
    Public Sub BuscarTipo(ByVal tipo As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM tipdoc WHERE tipodoc='" & tipo & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows(0).Item(1) = "FC" Then
            FrmEntradaDatos.Lbper.Text = tipo
        Else
            BuscarPeriodo()
            FrmEntradaDatos.Lbper.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "-" & PerActual(0) & PerActual(1) & "- "
        End If
    End Sub
    Public Sub BuscarDocumento2(ByVal tab As String, ByVal doc As String, ByVal tipo As String, ByVal fil As Integer)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM " & tab & " WHERE doc=" & doc & " AND tipodoc='" & tipo & "' ORDER BY item;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows(0).Item("doc") < 10 Then
            FrmSaldosIniciales.TxtNumero.Text = "000" & tabla.Rows(0).Item("doc")
        ElseIf tabla.Rows(0).Item("doc") < 100 Then
            FrmSaldosIniciales.TxtNumero.Text = "00" & tabla.Rows(0).Item("doc")
        ElseIf tabla.Rows(0).Item("doc") < 1000 Then
            FrmSaldosIniciales.TxtNumero.Text = "0" & tabla.Rows(0).Item("doc")
        Else
            FrmSaldosIniciales.TxtNumero.Text = tabla.Rows(0).Item("doc")
        End If
        FrmSaldosIniciales.TxtDocumento.Text = tabla.Rows(0).Item("tipodoc")
        FrmSaldosIniciales.TxtDocumento.ReadOnly = True
        FrmSaldosIniciales.lbnroobs.Text = fil
        FrmSaldosIniciales.lbestado.Text = "CONSULTA"
        'FrmSaldosIniciales.txtdia.Text = tabla.Rows(0).Item("dia")
        FrmSaldosIniciales.txtperiodo.Text = tabla.Rows(0).Item("dia") & "/" & tabla.Rows(0).Item("periodo")
        FrmSaldosIniciales.grilla.RowCount = tabla.Rows.Count + 1
        For i = 0 To tabla.Rows.Count - 1
            FrmSaldosIniciales.grilla.Item(0, i).Value = tabla.Rows(i).Item("descri")
            FrmSaldosIniciales.grilla.Item(1, i).Value = tabla.Rows(i).Item("debito")
            FrmSaldosIniciales.grilla.Item(2, i).Value = tabla.Rows(i).Item("credito")
            FrmSaldosIniciales.grilla.Item(3, i).Value = tabla.Rows(i).Item("codigo")
            FrmSaldosIniciales.grilla.Item(4, i).Value = tabla.Rows(i).Item("base")
            FrmSaldosIniciales.grilla.Item(5, i).Value = tabla.Rows(i).Item("diasv")
            FrmSaldosIniciales.grilla.Item(6, i).Value = tabla.Rows(i).Item("fechaven")
            FrmSaldosIniciales.grilla.Item(7, i).Value = tabla.Rows(i).Item("nit")
        Next
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
        sw = 0
    End Sub
    Private Sub gitems_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gitems.DoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)


        Try
            If cad = "" Then Exit Sub

            For i = fila + 1 To gitems.RowCount - 2
                Try
                    If gitems.Item(3, i).Value.ToString = cad Then
                        Dim C As Integer = 3, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gitems.Item(3, i).Value.ToString = cad Then
                        Dim C As Integer = 3, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            MsgBox("No hay coincidencias en la busqueda.", MsgBoxStyle.Information, "SAE Buscar Terceros")
        Catch ex As Exception
        End Try

    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            ok.Focus()
            BuscarGrilla(txtcuenta.Text)
        Else
            validarnumero(txtcuenta, e)
        End If
    End Sub
    Public tcad As String = ""
    Private Sub llenarGrilla(ByVal cadena As String)

        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = " SELECT d.doc,d.tipodoc, d.periodo,d.dia, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nom, " _
            & " IF(SUM(d.debito)=0,SUM(d.credito),SUM(d.debito)) AS vl " _
            & " FROM " & tcad & " d , terceros t WHERE d.nit= t.nit  " & cadena & " GROUP BY CONCAT(tipodoc,doc) ORDER BY tipodoc,doc; "
            myAdapter.SelectCommand = myCommand

            'myCommand.CommandText = "SELECT d.doc,d.tipodoc, d.periodo,d.dia,  " _
            '& " (SELECT nit FROM " & tcad & " WHERE item='1' AND doc=d.doc AND  tipodoc=d.`tipodoc`) AS nits," _
            '& " (SELECT TRIM(CONCAT(t.nombre,' ',t.apellidos)) FROM terceros t WHERE nits= t.nit  ) AS nom," _
            '& " IF(SUM(d.debito)=0,SUM(d.credito),SUM(d.debito)) AS vl " _
            '& " FROM " & tcad & " d  WHERE  d.nit<> '' " & cadena & " GROUP BY CONCAT(tipodoc,doc) ORDER BY tipodoc,doc; "
            'myAdapter.SelectCommand = myCommand


            'myCommand.CommandText = "  SELECT d.doc,d.tipodoc, d.periodo,d.dia, d.nit,  " _
            '& " TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nom,  " _
            '& " ( " _
            '& "SELECT  " _
            '& " IF(SUM(debito)=0,SUM(credito),SUM(debito))  FROM  " _
            '& " " & tcad & "  WHERE tipodoc= d.`tipodoc` AND doc= d.`doc` " _
            '& " GROUP BY CONCAT(tipodoc,doc) " _
            '& " ) " _
            '& " AS vl  " _
            '& " FROM " & tcad & " d  , terceros t " _
            '& " WHERE  d.nit= t.nit AND item='1' " & cadena & " " _
            '& " GROUP BY CONCAT(tipodoc,doc) ORDER BY tipodoc,doc;  "
            myAdapter.SelectCommand = myCommand


            myAdapter.Fill(tabla)
            gitems.Rows.Clear()
            gitems.RowCount = tabla.Rows.Count + 1
            If tabla.Rows.Count = 0 Then
                MsgBox("No se han creado documentos...  ", MsgBoxStyle.Information, "Buscar Documentos")
                Exit Sub
            End If
            For i = 0 To tabla.Rows.Count - 1
                gitems.Item(0, i).Value = i + 1
                gitems.Item(2, i).Value = tabla.Rows(i).Item("tipodoc")
                '////////////////////////////////////////////
                gitems.Item(3, i).Value = NumeroDoc(tabla.Rows(i).Item("doc"))
                '////////////////////////////////////////////
                gitems.Item(4, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("periodo")
                gitems.Item(5, i).Value = tabla.Rows(i).Item("nit")
                gitems.Item(6, i).Value = UCase(tabla.Rows(i).Item("nom"))
                gitems.Item(7, i).Value = tabla.Rows(i).Item("vl")
            Next
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FrmVerDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Try
        '    Dim tabla As New DataTable
        '    myCommand.CommandText = "SELECT d.doc,d.tipodoc, d.periodo,d.dia, d.nit, TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nom, IF(SUM(d.debito)=0,SUM(d.credito),SUM(d.debito)) AS vl " _
        '    & " FROM " & cad & " d , terceros t WHERE  d.nit= t.nit GROUP BY CONCAT(tipodoc,doc) ORDER BY tipodoc,doc; "
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    gitems.RowCount = tabla.Rows.Count + 1
        '    If tabla.Rows.Count = 0 Then
        '        MsgBox("No se han creado documentos...  ", MsgBoxStyle.Information, "Buscar Documentos")
        '        Exit Sub
        '    End If
        '    For i = 0 To tabla.Rows.Count - 1
        '        gitems.Item(0, i).Value = i + 1
        '        gitems.Item(2, i).Value = tabla.Rows(i).Item("tipodoc")
        '        '////////////////////////////////////////////
        '        gitems.Item(3, i).Value = NumeroDoc(tabla.Rows(i).Item("doc"))
        '        '////////////////////////////////////////////
        '        gitems.Item(4, i).Value = tabla.Rows(i).Item("dia") & "/" & tabla.Rows(i).Item("periodo")
        '        gitems.Item(5, i).Value = tabla.Rows(i).Item("nit")
        '        gitems.Item(6, i).Value = tabla.Rows(i).Item("nom")
        '        gitems.Item(7, i).Value = tabla.Rows(i).Item("vl")
        '    Next
        'Catch ex As Exception
        'End Try

        cmbdoc.Items.Clear()
        cmbdoc.Items.Add("TODOS")
        cmbdoc.Text = "TODOS"
        Try
            Dim td As New DataTable
            myCommand.CommandText = " SELECT DISTINCT  d.tipodoc FROM " & tcad & " d  ORDER BY tipodoc  "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            If td.Rows.Count > 0 Then
                For j = 0 To td.Rows.Count - 1
                    cmbdoc.Items.Add(td.Rows(j).Item(0))
                Next
                cmbdoc_SelectedIndexChanged(AcceptButton, AcceptButton)
            End If
        Catch ex As Exception
        End Try

        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Private Sub cmbdoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdoc.SelectedIndexChanged
        If cmbdoc.Text = "TODOS" Then
            llenarGrilla("")
        Else
            llenarGrilla(" AND d.tipodoc = '" & cmbdoc.Text & "'")
        End If

    End Sub

    Private Sub txtcuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.LostFocus
        txtcuenta.Text = NumeroDoc(Val(txtcuenta.Text))
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged

    End Sub
End Class