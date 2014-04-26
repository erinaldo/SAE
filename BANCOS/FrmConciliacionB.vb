Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmConciliacionB
    Dim cm As String
    Private Sub cmdActCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActCuenta.Click
        Try
            CmdCancelar_Click(AcceptButton, AcceptButton)
            lbhay.Text = "no"
            FrmSelBanco.lbform.Text = "concil"
            FrmSelBanco.ShowDialog()
            If lbhay.Text <> "no" Then
                BuscarDatosB()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BuscarDatosB()
        Try
            If txtcuenta.Text = "" Then PonerEnCero()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT b.*,s.descripcion AS d FROM bancos b LEFT JOIN (selpuc s) ON b.codigo=s.codigo WHERE b.codigo='" & txtcuenta.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtcuenta.Text = tabla.Rows(0).Item("codigo")
            txtnomcta.Text = tabla.Rows(0).Item("d")
            txtbanco.Text = Trim(tabla.Rows(0).Item("banco"))
            txtnum.Text = tabla.Rows(0).Item("num_cta")
            txtnit.Text = tabla.Rows(0).Item("nit")
            LABELDV.Text = DigitoNIT(txtnit.Text)
            'txtper.Text = PerActual

            'Saldos()
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerEnCero()
        End Try
    End Sub
  
    Public Sub BuscarSi()
        Dim tablaPer As New DataTable
        Dim per, sql As String
        Dim axu As Integer = 0
        sql = ""
        Dim perf As Integer = Val(PerActual(0) & PerActual(1)) - 1
        For j = 0 To perf
            If j < 10 Then
                per = "0" & j
            Else
                per = j
            End If
            axu = axu + 1
            If axu <= 1 Then
                sql = "SELECT SUM(debito - credito) AS s FROM documentos" & per & " WHERE codigo='" & txtcuenta.Text & "' "
            Else
                sql = sql & " UNION SELECT SUM(debito - credito) AS s FROM documentos" & per & " WHERE codigo='" & txtcuenta.Text & "' "
            End If
        Next
        sql = sql & ";"
        Dim suma As Double = 0
        Try
            MsgBox(sql)
            tablaPer.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaPer)
            For i = 0 To tablaPer.Rows.Count - 1
                Try
                    suma = suma + CDbl(Moneda(tablaPer.Rows(i).Item("s").ToString))
                Catch ex As Exception
                    '       MsgBox(ex.ToString)
                End Try
            Next
        Catch ex As Exception
            'MsgBox("22222" & ex.ToString)
        End Try
        txtsi.Text = Moneda(suma)

    End Sub
    Private Sub BuscarSII()
        Dim pi As String = ""
        Dim m1 As String = ""
        Dim m2 As String = ""
        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)
        Dim salT As String = ""
        Dim salI As String = ""
        For j = 0 To Val(m1)
            If j < 10 Then
                pi = "0" & j
            Else
                'If j = 10 Then
                '    pi = "0" & j
                'Else
                pi = j
                'End If
            End If


            If j = 0 Then
                salT = salT & " SELECT " & pi & " , item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
           & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo  "
            ElseIf j <> Val(m1) Then
                salT = salT & " UNION SELECT " & pi & " , item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
     & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo "
            Else
                salT = salT & " UNION SELECT " & pi & " , item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
           & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) and FORMAT(dia,0) < " & Val(Strings.Left(fecha1.Text, 2)) & " group by codigo "
                ' 
                '  ElseIf j <> Val(m2) Then
                '      salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo "
                '  Else
                '      salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) < " & Val(Strings.Left(fecha2.Text, 2)) & " group by codigo "
            End If
        Next

        salI = "select IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   GROUP BY codigo ),0) as subtotal "
        Dim tbI As New DataTable
        tbI.Clear()
        myCommand.CommandText = salI
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbI)

        txtsi.Text = Moneda(tbI.Rows(0).Item(0))
    End Sub

    Public Sub PonerEnCero()
        Try
            'grilla.Rows.Clear()
            'txtcuenta.Text = ""
            ''txtcodigo.Text = ""
            'txtnit.Text = ""
            'txtbanco.Text = ""
            'txtnum.Text = ""
            'txtsi.Text = "0,00"
            'txtsaldo.Text = "0,00"
            'txtdb.Text = "0,00"
            'txtcr.Text = "0,00"
            'txtextra.Text = "0,00"
            'txtnomcta.Text = ""
            'txtnombre.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmConciliacionB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Try
            fecha1.MinDate = "01/01/" & ano
            fecha1.MaxDate = "31/12/" & ano
            fecha2.MinDate = "01/01/" & ano
            fecha2.MaxDate = "31/12/" & ano
            '**************************************

            fecha1.Value = "01/" & PerActual(0) & PerActual(1) & "/" & ano
        Catch ex As Exception

        End Try
        Try
            fecha2.Value = DateSerial(Strings.Right(PerActual, 4), Strings.Left(PerActual, 2) + 1, 0)
            'fecha2.Value = Now.Day & "/" & PerActual(0) & PerActual(1) & "/" & ano
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
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False

        bloquear()
        limpiar()
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub bloquear()
        cmdContinuar.Enabled = True
        cmdEdit.Enabled = True
        CmdEliminar.Enabled = True
        CmdCons.Enabled = True
        cmdver.Enabled = True

        cmdGd.Enabled = False
        cmdcanc.Enabled = False
    End Sub
    Private Sub desbloquear()
        cmdContinuar.Enabled = False
        cmdEdit.Enabled = False
        CmdEliminar.Enabled = False
        CmdCons.Enabled = False
        cmdver.Enabled = False

        cmdGd.Enabled = True
        cmdcanc.Enabled = True
    End Sub
    Private Sub limpiar()

        txtsaldo.Text = Moneda(0)
        txtsalaj.Text = Moneda(0)
        txtsalB.Text = Moneda(0)
        txtdifsal.Text = Moneda(0)
        txtsalcon.Text = Moneda(0)
        grilla.Rows.Clear()
        txtdb.Text = Moneda(0)
        txtcr.Text = Moneda(0)
        txtdif.Text = Moneda(0)

        txtDcb.Text = ""
        txtDcb2.Text = ""
        txtNcb.Text = ""
        TxtDocumento.Text = ""
        txtDoc.Text = ""
        TxtNumero.Text = ""
        gitems.Rows.Clear()
        gcon.Rows.Clear()
        lbnum.Text = ""
        lbestado.Text = "NULO"
    End Sub
    Dim f1, f2 As String
  
    Private Sub cmdContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContinuar.Click
        If txtnomcta.Text = "" Then
            MsgBox("Seleccione una cuenta bancaria...", MsgBoxStyle.Information, "SAE Control.")
            Exit Sub
        End If
        Dim tp As String = "can"
        f1 = Strings.Right(CDate(fecha1.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha1.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha1.Text.ToString), 2)
        f2 = Strings.Right(CDate(fecha2.Text.ToString), 4) & "-" & Strings.Mid(CDate(fecha2.Text.ToString), 4, 2) & "-" & Strings.Left(CDate(fecha2.Text.ToString), 2)

        Dim tbI As New DataTable
        tbI.Clear()
        myCommand.CommandText = "select * from conciliacion where ctabanco='" & txtcuenta.Text & "' " _
        & " and fini='" & f1 & "' and ffin='" & f2 & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbI)
        If tbI.Rows.Count > 0 Then
            MsgBox("Ya existe una conciliacion para este banco en ese rango de fechas")
            Dim resp As MsgBoxResult
            resp = MsgBox("Si: Para realizar un Nuevo documento.  No: Editar el existente. ", MsgBoxStyle.YesNoCancel, "SAE Imprimir")
            If resp = MsgBoxResult.Yes Then
                tp = "SI"
            ElseIf resp = MsgBoxResult.No Then
                tp = "NO"
            Else
                tp = "can"
            End If
        Else
            tp = "SI"
        End If

        If tp = "SI" Then

            Try
                BuscarSII()
                Saldos()
            Catch ex As Exception
            End Try
            'txtsalaj.Text = txtsaldo.Text
            txtsalaj.Text = txtsi.Text
            txtsalB.Text = Moneda(0)
            txtdifsal.Text = txtsalaj.Text
            CmdCancelar_Click(AcceptButton, AcceptButton)
            SacarCuenta()
            txtdia.Enabled = True
            txtdia.Text = Now.Day
            cbper.Text = Strings.Left(PerActual, 2)
            txtperiodo.Text = Strings.Right(PerActual, 4)
            'limpiar
            gcon.Rows.Clear()
            txtDcb.Text = ""
            txtDcb2.Text = ""
            txtNcb.Text = ""
            txtsalcon.Text = 0
            NumActual()
            txtdia.Focus()
            desbloquear()
            gdatos.Enabled = True
            Gmov.Enabled = True
            lbestado.Text = "NUEVO"
        ElseIf tp = "NO" Then
            Try
                FrmSelConcili.lbcm.Text = "editar"
                FrmSelConcili.lbfila.Text = " AND ctabanco='" & txtcuenta.Text & "' and fini='" & f1 & "' and ffin='" & f2 & "' "
                FrmSelConcili.lbform.Text = "ConcilB"
                FrmSelConcili.ShowDialog()
                FrmSelConcili.lbcm.Text = ""
                FrmSelConcili.lbfila.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            If lbnum.Text <> "" Then
                BuscarConciliacion()
                lbestado.Text = "EDITAR"
                gdatos.Enabled = True
                Gmov.Enabled = True
                desbloquear()
                CmdNuevo.Enabled = False
                CmdCancelar.Enabled = True
                SaldosEditar()
            End If
        End If
    End Sub
    Private Sub NumActual()
        Dim ta As New DataTable
        ta.Clear()
        myCommand.CommandText = "SELECT MAX(num) from conciliacion"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ta)
        If ta.Rows.Count = 0 Then
            lbnum.Text = 1
        Else
            Try
                lbnum.Text = CInt(ta.Rows(0).Item(0)) + 1
            Catch ex As Exception
                lbnum.Text = 1
            End Try

        End If
    End Sub
    Public Sub Saldos()

        Dim sql As String = ""
        Dim axu As Integer = 0
        Dim perf As String = PerActual(0) & PerActual(1)
        'sql = "SELECT * FROM documentos" & perf & " WHERE codigo='" & txtcuenta.Text & "' ORDER BY dia,tipodoc,doc;"
        '.........
        Dim m1 As String = ""
        Dim m2 As String = ""
        Dim p As String = ""

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        sql = sql & " SELECT item,dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque FROM ("

        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If m1 = m2 Then
                sql = sql & " select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
                  & " FROM documentos" & p & " WHERE FORMAT(dia,0) BETWEEN " & Val(Strings.Left(fecha1.Text, 2)) & " AND  " & Val(Strings.Left(fecha2.Text, 2)) & " " _
                  & " AND  codigo = '" & txtcuenta.Text & "'"
            Else
                If p = m1 Then
                    sql = sql & " select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
               & " FROM documentos" & p & " WHERE FORMAT(dia,0) >= " & Val(Strings.Left(fecha1.Text, 2)) & " " _
               & " AND  codigo = '" & txtcuenta.Text & "'"
                ElseIf p <> m2 Then
                    sql = sql & " UNION select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
              & " FROM documentos" & p & " WHERE codigo = '" & txtcuenta.Text & "' "
                ElseIf p = m2 Then
                    sql = sql & " UNION select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
              & " FROM documentos" & p & " WHERE FORMAT(dia,0) <= " & Val(Strings.Left(fecha2.Text, 2)) & " " _
              & " AND  codigo = '" & txtcuenta.Text & "'"
                End If
            End If
        Next
        sql = sql & " ) AS c ORDER BY FORMAT(dia,0), FORMAT(left(periodo,2),0) "
        grilla.Rows.Clear()
        '.........
        Dim sumad As Double = 0
        Dim sumac As Double = 0
        Try
            Dim tablaPer As New DataTable
            tablaPer.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaPer)
            If tablaPer.Rows.Count > 0 Then
                grilla.RowCount = tablaPer.Rows.Count + 1
                For i = 0 To tablaPer.Rows.Count - 1
                    Try
                        sumad = sumad + CDbl(Moneda(tablaPer.Rows(i).Item("debito").ToString))
                        sumac = sumac + CDbl(Moneda(tablaPer.Rows(i).Item("credito").ToString))
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try
                    grilla.Item("fecha", i).Value = tablaPer.Rows(i).Item("dia").ToString & "/" & tablaPer.Rows(i).Item("periodo").ToString
                    grilla.Item("numero", i).Value = NumeroDoc(tablaPer.Rows(i).Item("doc").ToString)
                    grilla.Item("tipo", i).Value = tablaPer.Rows(i).Item("tipodoc").ToString
                    grilla.Item("Debitos", i).Value = Moneda(tablaPer.Rows(i).Item("debito").ToString)
                    grilla.Item("Creditos", i).Value = Moneda(tablaPer.Rows(i).Item("credito").ToString)
                    grilla.Item("conepto", i).Value = tablaPer.Rows(i).Item("descri").ToString
                    grilla.Item("nit", i).Value = tablaPer.Rows(i).Item("nit").ToString
                    grilla.Item("cheque2", i).Value = tablaPer.Rows(i).Item("cheque").ToString
                    grilla.Item("sel", i).Value = "NO"
                    'MsgBox(i)
                Next
            Else
                grilla.RowCount = 1
            End If
        Catch ex As Exception
            '  MsgBox("22222" & ex.ToString)
        End Try
        Dim extra As Double = 0
        'txtdb.Text = Moneda(sumad)
        'txtcr.Text = Moneda(sumac)
        'txtextra.Text = Moneda(CDbl(Moneda(sumad)) - CDbl(Moneda(sumac)))
        extra = Moneda(CDbl(Moneda(sumad)) - CDbl(Moneda(sumac)))
        txtsaldo.Text = Moneda(CDbl(txtsi.Text) + CDbl(extra))
        txtsalaj.Text = Moneda(0)
    End Sub
    Public Sub SaldosEditar()

        Dim sql As String = ""
        Dim axu As Integer = 0
        Dim perf As String = PerActual(0) & PerActual(1)
        'sql = "SELECT * FROM documentos" & perf & " WHERE codigo='" & txtcuenta.Text & "' ORDER BY dia,tipodoc,doc;"
        '.........
        Dim m1 As String = ""
        Dim m2 As String = ""
        Dim p As String = ""

        m1 = Strings.Mid(fecha1.Text, 4, 2)
        m2 = Strings.Mid(fecha2.Text, 4, 2)

        sql = sql & " SELECT item,dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque FROM ("

        For i = Val(m1) To Val(m2)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If m1 = m2 Then
                sql = sql & " select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
                  & " FROM documentos" & p & " WHERE FORMAT(dia,0) BETWEEN " & Val(Strings.Left(fecha1.Text, 2)) & " AND  " & Val(Strings.Left(fecha2.Text, 2)) & " " _
                  & " AND  codigo = '" & txtcuenta.Text & "'" _
                  & " AND tipodoc<>'CB' AND CONCAT(tipodoc,LPAD(doc,5,0)) NOT IN (SELECT CONCAT(cta_iva,concep) FROM detacomp" & p & " WHERE doc='" & lbnum.Text & "') "
            Else
                If p = m1 Then
                    sql = sql & " select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
               & " FROM documentos" & p & " WHERE FORMAT(dia,0) >= " & Val(Strings.Left(fecha1.Text, 2)) & " " _
               & " AND  codigo = '" & txtcuenta.Text & "'" _
                  & " AND tipodoc<>'CB' AND CONCAT(tipodoc,LPAD(doc,5,0)) NOT IN (SELECT CONCAT(cta_iva,concep) FROM detacomp" & p & " WHERE doc='" & lbnum.Text & "') "

                ElseIf p <> m2 Then
                    sql = sql & " UNION select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
              & " FROM documentos" & p & " WHERE codigo = '" & txtcuenta.Text & "' " _
                  & " AND tipodoc<>'CB' AND CONCAT(tipodoc,LPAD(doc,5,0)) NOT IN (SELECT CONCAT(cta_iva,concep) FROM detacomp" & p & " WHERE doc='" & lbnum.Text & "') "

                ElseIf p = m2 Then
                    sql = sql & " UNION select item, dia, doc, tipodoc, debito, credito, descri, nit, periodo,cheque " _
              & " FROM documentos" & p & " WHERE FORMAT(dia,0) <= " & Val(Strings.Left(fecha2.Text, 2)) & " " _
              & " AND  codigo = '" & txtcuenta.Text & "'" _
             & " AND tipodoc<>'CB' AND CONCAT(tipodoc,LPAD(doc,5,0)) NOT IN (SELECT CONCAT(cta_iva,concep) FROM detacomp" & p & " WHERE doc='" & lbnum.Text & "') "
                End If
            End If
        Next
        sql = sql & " ) AS c ORDER BY FORMAT(dia,0), FORMAT(left(periodo,2),0) "
        'grilla.Rows.Clear()
        '.........
        Dim sumad As Double = 0
        Dim sumac As Double = 0
        Try

            Dim tablaPer As New DataTable
            tablaPer.Clear()
            myCommand.CommandText = sql
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaPer)
            If tablaPer.Rows.Count > 0 Then
                grilla.RowCount = tablaPer.Rows.Count + 1 + grilla.RowCount
                For i = 0 To tablaPer.Rows.Count - 1
                    Try
                        sumad = sumad + CDbl(Moneda(tablaPer.Rows(i).Item("debito").ToString))
                        sumac = sumac + CDbl(Moneda(tablaPer.Rows(i).Item("credito").ToString))
                    Catch ex As Exception
                        ' MsgBox(ex.ToString)
                    End Try
                    grilla.Item("fecha", i).Value = tablaPer.Rows(i).Item("dia").ToString & "/" & tablaPer.Rows(i).Item("periodo").ToString
                    grilla.Item("numero", i).Value = NumeroDoc(tablaPer.Rows(i).Item("doc").ToString)
                    grilla.Item("tipo", i).Value = tablaPer.Rows(i).Item("tipodoc").ToString
                    grilla.Item("Debitos", i).Value = Moneda(tablaPer.Rows(i).Item("debito").ToString)
                    grilla.Item("Creditos", i).Value = Moneda(tablaPer.Rows(i).Item("credito").ToString)
                    grilla.Item("conepto", i).Value = tablaPer.Rows(i).Item("descri").ToString
                    grilla.Item("nit", i).Value = tablaPer.Rows(i).Item("nit").ToString
                    grilla.Item("cheque2", i).Value = tablaPer.Rows(i).Item("cheque").ToString
                    grilla.Item("sel", i).Value = "NO"
                    'MsgBox(i)
                Next
            Else
                'grilla.RowCount = 2
            End If
        Catch ex As Exception
            '  MsgBox("22222" & ex.ToString)
        End Try
    End Sub
    Dim camp As String
    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 8
                    camp = ""
                    camp = grilla.Item("sel", e.RowIndex).Value
                    'If grilla.Item("sel", e.RowIndex).Value = True Then
                    '    grilla.Item("fecha", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("tipo", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("numero", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("Debitos", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("Creditos", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("conepto", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("nit", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("set", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    '    grilla.Item("cheque2", e.RowIndex).Style.BackColor = Color.DeepSkyBlue
                    'Else
                    '    grilla.Item("fecha", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("tipo", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("numero", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("Debitos", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("Creditos", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("conepto", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("nit", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("set", e.RowIndex).Style.BackColor = Color.White
                    '    grilla.Item("cheque2", e.RowIndex).Style.BackColor = Color.White
                    'End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grilla_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellDoubleClick

    End Sub

    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit

        If e.RowIndex >= grilla.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 8

                    Dim s As Double = 0
                    If camp <> grilla.Item("sel", e.RowIndex).Value Then
                        If grilla.Item("sel", e.RowIndex).Value = "OK" Then
                            s = s + (grilla.Item(3, e.RowIndex).Value - grilla.Item(4, e.RowIndex).Value)
                        Else
                            s = s - (grilla.Item(3, e.RowIndex).Value - grilla.Item(4, e.RowIndex).Value)
                        End If
                        txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) + s)
                        caldif()
                    End If

            End Select
        Catch ex As Exception

        End Try



    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        GenerarPDF()
    End Sub
    Private Sub GenerarPDF()
        Try

          
            Dim nom As String = ""
            Dim nitp As String = ""
            Dim per As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
          

            MiConexion(bda)

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            ' Try
            Dim sql2 As String = ""
            Dim sql As String = ""
            Dim ini As Integer = 0
            Dim fin As Integer = 0
            Dim dia As String = ""
            Dim p As String = ""
            Dim pi As String = ""
            Dim cuent As String = ""
            Dim cuentT As String = ""
            Dim doc As String = ""
            Dim docT As String = ""
            Dim nit As String = ""
            Dim nitT As String = ""
            Dim tipo As String = ""
            Dim tt As String = ""
            Dim ord As String = ""
            Dim cc As String = ""
            Dim c_f As String = ""
            Dim titulo As String = ""
            Dim tituloG As String = ""

            
            per = " RANGO DE FECHAS: " & fecha1.Value & " -- " & fecha2.Value
            tituloG = " CONCILIACIONES BANCARIAS"
           

            '---------- saldos iniciales
            Dim m1 As String = ""
            Dim m2 As String = ""
            m1 = Strings.Mid(fecha1.Text, 4, 2)
            m2 = Strings.Mid(fecha2.Text, 4, 2)
            Dim salT As String = ""
            For j = 0 To Val(m1)
                If j < 10 Then
                    pi = "0" & j
                Else
                    If j = 10 Then
                        pi = "0" & j
                    Else
                        pi = j
                    End If
                End If
                If j = 0 Then
                    salT = salT & " SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
               & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo "
                ElseIf j <> 0 And j <> Val(m1) Then
                    salT = salT & " UNION SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
              & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo "
                ElseIf j = m1 Then
                    salT = salT & " UNION SELECT " & pi & ", item, nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
              & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) < " & Val(Strings.Left(fecha1.Text, 2)) & " group by codigo "
                End If

            Next
            'For j = 1 To Val(m1)
            '    If j < 10 Then
            '        pi = "0" & j - 1
            '    Else
            '        If j = 10 Then
            '            pi = "0" & j - 1
            '        Else
            '            pi = j - 1
            '        End If
            '    End If
            '    If Val(m1) = 1 Then
            '        salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
            '        & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) BETWEEN '" & Val(Strings.Left(fecha1.Text, 2)) & "' AND  '" & Val(Strings.Left(fecha2.Text, 2)) & "' group by codigo "
            '    Else
            '        If pi = "00" Then
            '            salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
            '       & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) >= '" & Val(Strings.Left(fecha1.Text, 2)) & "' group by codigo "
            '        ElseIf pi <> "00" And pi <> m1 Then
            '            salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
            '      & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  group by codigo "
            '        ElseIf pi = m1 Then
            '            salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
            '      & " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) <= '" & Val(Strings.Left(fecha2.Text, 2)) & "' group by codigo "
            '        End If
            '    End If
            'Next



            ini = Val(m1)
            fin = Val(m2)
           
            ' ....... fin saldos iniciales

            ' SQL2
            ' sql2 = "select  codigo as codart, sum(c.n) AS valor FROM ( " & salT & " ) as c   GROUP BY codigo ORDER BY  codigo "
            sql2 = "select  '' as item, '' as tipodoc, c.codigo as nitcod, s.descripcion as decrip, '' as nitc, '' as nomnit, '' as fecha, sum(c.n) AS subtotal, " _
            & " '' as ccosto, '' as doc, '' as concepto, 0 as tasa, 0 as total,'' as ctaretiva FROM ( " & salT & " ) as c , selpuc s WHERE c.codigo = s.codigo   "



            tipo = "***** CUENTA: "
            c_f = " FECHA "
            tt = "NIT / NOMBRE - RAZON SOCIAL"
            ord = " d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, concat(t.nombre,' ', t.apellidos) as nomnit "

            If ini < 10 Then
                pi = "0" & ini - 1
            Else
                If ini = 10 Then
                    pi = "0" & ini - 1
                Else
                    pi = ini - 1
                End If
            End If
            For i = ini To fin
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                'If i <> fin Then
                '    sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                '    & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                '    & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                '    & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                '    & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                '    & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
                '    & " AND s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) UNION "
                'Else
                '    sql = sql & " SELECT d.item, d.tipodoc, " & ord & ", " _
                '    & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                '    & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal, " _
                '    & " concat(d.dia,'/',d.periodo) as ccosto, CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20)) as doc, " _
                '    & " d.descri as concepto, d.debito as tasa , d.credito as total, d.cheque as ctaretiva  " _
                '    & " FROM  selpuc s , documentos" & p & " d ,  terceros t WHERE d.nit = t.nit " _
                '    & " AND  s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  "
                'End If

                If ini = fin Then
                    sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                   & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                   & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                   & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                   & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                   & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
                   & " AND s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  AND FORMAT(d.dia,0) BETWEEN " & Val(Strings.Left(fecha1.Text, 2)) & " AND  " & Val(Strings.Left(fecha2.Text, 2)) & " "

                    'salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                    '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) BETWEEN '" & Val(Strings.Left(fecha1.Text, 2)) & "' AND  '" & Val(Strings.Left(fecha2.Text, 2)) & "' group by codigo "
                Else
                    If i = ini Then
                        sql = sql & " SELECT  d.item, d.tipodoc, " & ord & ", " _
                  & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                  & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                  & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                  & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                  & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
                  & " AND s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )  AND FORMAT(d.dia,0) >= " & Val(Strings.Left(fecha1.Text, 2)) & "  "

                        '     salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                        '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) >= '" & Val(Strings.Left(fecha1.Text, 2)) & "' group by codigo "
                    ElseIf i <> ini And i <> fin Then

                        sql = sql & " UNION  SELECT  d.item, d.tipodoc, " & ord & ", " _
                & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
                & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
                & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
                & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
                & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
                & " AND s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' )   "

                        '      salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                        '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) >= '" & Val(Strings.Left(fecha1.Text, 2)) & "' group by codigo "
                    ElseIf i = fin Then

                        sql = sql & " UNION  SELECT  d.item, d.tipodoc, " & ord & ", " _
              & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
              & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
              & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,7,'0')) AS CHAR(20) ) as doc, " _
              & " d.descri as concepto,  d.debito as tasa, d.credito as total, d.cheque as ctaretiva   " _
              & " FROM  selpuc s , documentos" & p & " d ,  terceros t where d.nit = t.nit " _
              & " AND s.codigo = d.codigo AND s.codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(d.dia,0) <= " & Val(Strings.Left(fecha2.Text, 2)) & "  "

                        '      salT = salT & " UNION SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & " " _
                        '& " WHERE codigo LIKE CONCAT('" & txtcuenta.Text & "','%' ) AND FORMAT(dia,0) <= '" & Val(Strings.Left(fecha2.Text, 2)) & "' group by codigo "
                    End If
                End If
            Next
            'sql = sql & " ORDER BY nitcod, fecha ASC, tipodoc, doc  "


            ''*********************************************************************************
            ''**********************************************************************************
            
            Dim tb As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)

            Dim ca As String = ""

            ' '' AGRUPAR POR CUENTA
            If tb.Rows.Count = 0 Then
                sql = sql2 & "GROUP BY c.codigo ORDER BY  c.codigo "
            Else
                Dim tb2 As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "select  DISTINCT r.nitcod  from (" & sql & ") as r"
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb2)

                For i = 0 To tb2.Rows.Count - 1
                    If i = 0 Then
                        ca = ca & tb2.Rows(i).Item(0)
                    Else
                        ca = ca & "," & tb2.Rows(i).Item(0)
                    End If
                Next

                sql2 = sql2 & " AND c.codigo NOT IN (" & ca & ") GROUP BY c.codigo "
                sql = sql & " UNION " & sql2 & " ORDER BY nitcod, fecha , tipodoc, doc  "

                Dim tb3 As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = sql2
                myCommand.Connection = conexion
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tb3)
            End If



            Dim tabla As DataSet
            tabla = New DataSet

            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "cobdpen")

            myCommand.Parameters.Clear()
            myCommand.CommandText = "select * from deta_mov01"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla, "deta_mov01")


            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCMov_cue.rpt")
            CrReport.SetDataSource(tabla)
            ' CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmReportCMov_cue.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim Prtipo As New ParameterField
                Dim Prtt As New ParameterField
                Dim Prtitulo As New ParameterField
                Dim PrtituloG As New ParameterField
                Dim Prcf As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nitp.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)

                Prtipo.Name = "tipo"
                Prtipo.CurrentValues.AddValue(tipo.ToString)

                Prtt.Name = "tt"
                Prtt.CurrentValues.AddValue(tt.ToString)

                Prtitulo.Name = "titulo"
                Prtitulo.CurrentValues.AddValue(titulo.ToString)

                PrtituloG.Name = "tituloG"
                PrtituloG.CurrentValues.AddValue(tituloG.ToString)

                Prcf.Name = "Cue_Fec"
                Prcf.CurrentValues.AddValue(c_f.ToString)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(Prtipo)
                prmdatos.Add(Prtt)
                prmdatos.Add(Prtitulo)
                prmdatos.Add(PrtituloG)
                prmdatos.Add(Prcf)

                FrmReportCMov_cue.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCMov_cue.ShowDialog()

            Catch ex As Exception
            End Try

            conexion.Close()
            Cerrar()
            'Catch ex As Exception
            '    MsgBox("Error al generar el informe " & ex.ToString, MsgBoxStyle.Information, "SAE")
            'End Try
        Catch ex As Exception
            MsgBox("Error al Generar el Informe" & ex.ToString, MsgBoxStyle.Information, "Informacion")
        End Try
    End Sub

    Private Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
       
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        If lbestado.Text = "NUEVO" Then
            'cmdver.Enabled = False
            txtDoc.Text = ""
            TxtDocumento.Text = ""
            TxtNumero.Text = ""
            'Parametro
            Dim tp As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "select t.tipodoc, t.descripcion, t.actual" & cbper.Text & " from  tipdoc t WHERE t.tipodoc= 'OC' "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count = 0 Then
                MsgBox("Verifique que exista el documento OC ", MsgBoxStyle.Information, "Verificacion")
                Exit Sub
            Else
                TxtDocumento.Text = tp.Rows(0).Item(0)
                txtDoc.Text = tp.Rows(0).Item(1)
                TxtNumero.Text = NumeroDoc(Val(tp.Rows(0).Item(2).ToString) + 1)
            End If
        End If

        txtdb.Text = Moneda(0)
        txtcr.Text = Moneda(0)
        txtdif.Text = Moneda(0)
        gitems.Rows.Clear()
        gitems.ReadOnly = False
        gitems.RowCount = 2
        gitems.Item(0, 0).Value = ""
        gitems.Item(1, 0).Value = "0,00"
        gitems.Item(2, 0).Value = "0,00"
        gitems.Item(3, 0).Value = ""
        gitems.Item(4, 0).Value = "0,00"
        gitems.Item(5, 0).Value = "0"
        gitems.Item(6, 0).Value = "00/00/0000"
        gitems.Item(7, 0).Value = ""
        gitems.Item(8, 0).Value = ""
        gitems.Item(9, 0).Value = ""

        'cm = ""
        'Dim tps As New DataTable
        'myCommand.Parameters.Clear()
        'myCommand.CommandText = "select para_codigo from presupuesto" & Strings.Right(PerActual, 4) & ".parametros"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tps)
        'If tps.Rows(0).Item(0) = "I" Then
        '    cm = "c.ingc_cod1"
        'ElseIf tps.Rows(0).Item(0) = "F" Then
        '    cm = "c.ingc_fut"
        'Else
        '    cm = "c.ingc_cgdg"
        'End If
    End Sub
    Dim vl As String
    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        vl = ""
        If e.RowIndex >= gitems.RowCount - 1 Then Exit Sub
        Select Case e.ColumnIndex
            Case 1
                vl = Moneda(gitems.Item("Deb", e.RowIndex).Value)
            Case 2
                vl = Moneda(gitems.Item("Cred", e.RowIndex).Value)
        End Select
        
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        If e.RowIndex >= gitems.RowCount - 1 Then Exit Sub
        Try
            Select Case e.ColumnIndex
                Case 0
                    Try
                        gitems.Item("Descripcion", e.RowIndex).Value = UCase(gitems.Item("Descripcion", e.RowIndex).Value)
                    Catch ex As Exception
                        gitems.Item("Descripcion", e.RowIndex).Value = ""
                    End Try
                Case 1
                    Try
                        gitems.Item("Deb", e.RowIndex).Value = Moneda(gitems.Item("Deb", e.RowIndex).Value)
                        gitems.Item("Cred", e.RowIndex).Value = Moneda(0)
                    Catch ex As Exception
                        gitems.Item("Deb", e.RowIndex).Value = Moneda(0)
                    End Try
                    If gitems.Item("Deb", e.RowIndex).Value <> vl Then
                        txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) - CDbl(vl))
                        txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) + CDbl(gitems.Item("Deb", e.RowIndex).Value))
                    End If
                Case 2
                    Try
                        gitems.Item("Cred", e.RowIndex).Value = Moneda(gitems.Item("Cred", e.RowIndex).Value)
                        gitems.Item("Deb", e.RowIndex).Value = Moneda(0)

                        If gitems.Item("Cred", e.RowIndex).Value <> vl Then
                            txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) + CDbl(vl))
                            txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) - CDbl(gitems.Item("Cred", e.RowIndex).Value))
                        End If

                    Catch ex As Exception
                        gitems.Item("Cred", e.RowIndex).Value = Moneda(0)
                    End Try
                    'Case 3
                    '    Buscarcuentas(gitems.Item(3, e.RowIndex).Value, e.RowIndex)
                    'Case 4
                    '    Try
                    '        gitems.Item("Base", e.RowIndex).Value = Moneda(gitems.Item("Base", e.RowIndex).Value)
                    '    Catch ex As Exception
                    '        gitems.Item("Base", e.RowIndex).Value = Moneda(0)
                    '    End Try
                    'Case 8
                    '    BuscarRubr(gitems.Item(8, e.RowIndex).Value, e.RowIndex)

            End Select
        Catch ex As Exception
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuenta()
        caldif()

    End Sub
    'Private Sub BuscarRubr(ByVal rb As String, ByVal fl As Integer)

    '    Dim a As String = Strings.Right(PerActual, 4)
    '    Dim tabla As New DataTable
    '    myCommand.CommandText = " select " & cm & ", c.ingc_concepto, c.ingc_cod1 , c.ingc_sd, v.ingv_credito, v.ingv_contrac " _
    '    & " from presupuesto" & a & ".ingconcepto c, presupuesto" & a & ".ingvalores v " _
    '    & " where " & cm & " = '" & Trim(rb) & "' AND c.ingc_sd='D' and c.ingc_cod1= v.ingv_cod1"
    '    myAdapter.SelectCommand = myCommand
    '    myAdapter.Fill(tabla)
    '    Refresh()
    '    If tabla.Rows.Count > 0 Then
    '        gitems.Item(8, fl).Value = tabla.Rows(0).Item("ingc_cod1")
    '        'txtnomrb.Text = tabla.Rows(0).Item("ingc_concepto")
    '        'txtcred.Text = tabla.Rows(0).Item("ingv_contrac")
    '        'txtdeb.Text = tabla.Rows(0).Item("ingv_credito")
    '    Else
    '        Try
    '            Try
    '                gitems.Item(8, fl).Value = ""
    '            Catch ex As Exception
    '            End Try
    '            FrmSelRubrIng.lbfila.Text = fl
    '            FrmSelRubrIng.lbform.Text = "concB"
    '            FrmSelRubrIng.lbcm.Text = cm
    '            FrmSelRubrIng.ShowDialog()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub
    Private Sub saldoAj()
        Try
            Dim s As Double = 0
            For i = 0 To grilla.Rows.Count - 1
                s = s + (grilla.Item(3, i).Value - grilla.Item(4, i).Value)
            Next
            txtsalaj.Text = Moneda(s)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SacarCuenta()
        Try
            Dim sumadb, sumacr, db, cr As Double
            sumadb = 0
            sumacr = 0
            For i = 0 To gitems.RowCount - 1
                Try
                    db = CDbl(gitems.Item(1, i).Value)
                Catch ex As Exception
                    db = 0
                End Try
                Try
                    cr = CDbl(gitems.Item(2, i).Value)
                Catch ex As Exception
                    cr = 0
                End Try
                sumadb = sumadb + db
                sumacr = sumacr + cr
            Next
            txtdb.Text = sumadb
            txtdb.Text = Moneda(txtdb.Text)
            txtcr.Text = sumacr
            txtcr.Text = Moneda(txtcr.Text)
            txtdif.Text = sumadb - sumacr
            txtdif.Text = Moneda(txtdif.Text)
            If (sumadb - sumacr) = 0 Then txtdif.Text = "0,00"
        Catch ex As Exception
            MsgBox("Error al sacar diferencia " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try

     
            Try
                If gitems.Item(1, i).Value.ToString = "" Then
                    gitems.Item(1, i).Value = "0,00"
                End If
            Catch ex As Exception
                gitems.Item(1, i).Value = "0,00"
            End Try
            Try
                If gitems.Item(2, i).Value.ToString = "" Then
                    gitems.Item(2, i).Value = "0,00"
                End If
            Catch ex As Exception
                gitems.Item(2, i).Value = "0,00"
            End Try
            Try
                If gitems.Item(4, i).Value.ToString = "" Then
                    gitems.Item(4, i).Value = "0,00"
                End If
            Catch ex As Exception
                gitems.Item(4, i).Value = "0,00"
            End Try
            Dim fec As Date
            Try
                fec = CDate(Now.Day & "/" & PerActual)
            Catch ex As Exception
                fec = CDate("01" & "/" & PerActual)
            End Try
            Try
                If Trim(gitems.Item(5, i).Value.ToString) = "" Then
                    gitems.Item(5, i).Value = Val(0)
                    gitems.Item(6, i).Value = fec.AddDays(Val(0))
                End If
            Catch ex As Exception
                Try
                    gitems.Item(5, i).Value = Val(0)
                    gitems.Item(6, i).Value = fec.AddDays(Val(0))
                Catch ex2 As Exception
                    gitems.Item(5, i).Value = "0"
                    gitems.Item(6, i).Value = fec
                End Try
            End Try
            Try
                If gitems.Item(7, i).Value.ToString = "" And Trim(txtbanco.Text) <> "" Then
                    gitems.Item(7, i).Value = txtnit.Text
                End If
            Catch ex As Exception
                If Trim(txtbanco.Text) <> "" Then
                    gitems.Item(7, i).Value = txtnit.Text
                End If
            End Try
            Try
                If gitems.Item(8, i).Value = "" Then
                    gitems.Item(8, i).Value = ""
                End If
            Catch ex As Exception
                gitems.Item(8, i).Value = ""
            End Try
            'gitems.Item(8, i).Value = "0"
            'Try
            '    If Trim(gitems.Item(8, i).Value.ToString) = "" And Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then

            '    End If
            'Catch ex As Exception
            '    If Trim(txtncentro.Text) <> "" And txtcentro.Enabled = True Then
            '        gitems.Item(8, i).Value = txtcentro.Text
            '    End If
            'End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        If cuenta = "" Then
            FrmCuentas.lbform.Text = "ConciBancaria"
            FrmCuentas.lbfila.Text = fila
            FrmCuentas.ShowDialog()
        Else
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                If gitems.Item(3, fila).Value = "" Or FrmEntradaDatos.nivel_cuenta(gitems.Item(3, fila).Value) = True Then
                    gitems.Item(3, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "ConciBancaria"
                    FrmCuentas.lbfila.Text = fila
                    FrmCuentas.ShowDialog()
                Else
                    SendKeys.Send(Chr(Keys.Tab))
                    Dim resultado As MsgBoxResult 'HAY QUE AGREGAR UNA NUEVA CUENTA
                    resultado = MsgBox("La cuenta (" & gitems.Item(3, fila).Value & ") NO existe en los registros, ¿Desea Agregarla?", MsgBoxStyle.YesNo, "SAE verificando")
                    If resultado = MsgBoxResult.Yes Then
                        FrmNuevaCuenta.txtcuenta.Text = gitems.Item(3, fila).Value
                        gitems.Item(3, fila).Value = ""
                        FrmNuevaCuenta.lbfila.Text = fila
                        FrmNuevaCuenta.ShowDialog()
                    Else
                        gitems.Item(3, fila).Value = ""
                    End If
                End If
            Else
                gitems.Item(4, fila).Selected = True
            End If
        End If

    End Sub

    Private Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click

        txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) - CDbl(txtdif.Text))
        caldif()
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        If lbestado.Text = "NUEVO" Then
            txtDoc.Text = ""
            TxtDocumento.Text = ""
            TxtNumero.Text = ""
        End If
        txtdb.Text = Moneda(0)
        txtcr.Text = Moneda(0)
        txtdif.Text = Moneda(0)
        gitems.Rows.Clear()
        gitems.ReadOnly = True
    End Sub

    Private Sub txtcuenta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcuenta.TextChanged
        If Trim(txtcuenta.Text) <> "" Then
            Gmov.Enabled = True
        Else
            Gmov.Enabled = False
        End If
    End Sub

    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click
        ValidarGuardar()
        cmdContinuar_Click(AcceptButton, AcceptButton)

    End Sub
    Private Sub ValidarGuardar()
        SacarCuenta()
        If TxtDocumento.Text = "" Then
            MsgBox("Favor escoger el tipo de documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtDocumento.Focus()
            Exit Sub
        ElseIf TxtNumero.Text = "" Then
            MsgBox("Favor verifique el campo Nro Documento...", MsgBoxStyle.Information, "SAE Verificación")
            TxtNumero.Focus()
            Exit Sub
            'ElseIf CDec(txtdif.Text) <> 0 Then
            '    MsgBox("Favor verifique los items del documento la diferencia no puede ser distinta de cero(0)...", MsgBoxStyle.Information, "SAE Verificación")
            '    gitems.Focus()
            '    Exit Sub
            'ElseIf CDec(txtdb.Text) = 0 Then
            '    MsgBox("Favor verifique los items del documento no digitado ningun debito...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtdb.Focus()
            '    Exit Sub
            'ElseIf txtcr.Text = "000,00" Then
            '    MsgBox("Favor verifique los items del documento no digitado ningun credito...", MsgBoxStyle.Information, "SAE Verificación")
            '    txtcr.Focus()
            '    Exit Sub
        ElseIf gitems.RowCount <= 1 Then
            MsgBox("Favor verifique los items del documento no digitado ninguno...", MsgBoxStyle.Information, "SAE Verificación")
            gitems.Focus()
            Exit Sub
        End If
        'Try
        '    Dim mifec As Date
        '    mifec = txtdia.Text & txtperiodo.Text
        'Catch ex As Exception
        '    MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
        '    txtdia.Focus()
        '    Exit Sub
        'End Try
        'MesdelPeriodo()
        'Dim cad As String
        'cad = TxtDocumento.Text
        'cad = cad(0) & cad(1)
        'MiConexion(bda)
        For i = 0 To gitems.RowCount - 2
            If gitems.Item(0, i).Value = "" And gitems.Item(3, i).Value <> "" Then
                MsgBox("falta digitar una descripción.  ", MsgBoxStyle.Information, "SAE Verificación")
                gitems.Item(0, i).Selected = True
                gitems.Focus()
                Exit Sub
                'ElseIf gitems.Item(3, i).Value = "" Then
                '    MsgBox("falta digitar una cuenta.  ", MsgBoxStyle.Information, "SAE Verificación")
                '    gitems.Item(3, i).Selected = True
                '    gitems.Focus()
                '    Exit Sub
                'ElseIf CDbl(gitems.Item(1, i).Value) = 0 And CDbl(gitems.Item(2, i).Value) = 0 Then
                '    MsgBox("Los valores debito y credito no pueden ser ambos iguales a cero(0) en un mismo Item.   ", MsgBoxStyle.Information, "SAE Verificación")
                '    gitems.Item(1, i).Selected = True
                '    gitems.Focus()
                '    Exit Sub
            End If
        Next
        Try
            Dim fecha As Date = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
        Catch ex As Exception
            MsgBox("Verifique la Fecha", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End Try
        For i = 0 To gcon.RowCount - 2
            Try
                If gcon.Item(3, i).Value.ToString <> "" Then
                    Guardar(i)
                    'If gcon.Item(3, i).Value.ToString <> txtcuenta.Text Then
                    '    Try
                    '        GuardarPresup(i)
                    '    Catch ex As Exception
                    '        MsgBox("Error al ingresar en presupuesto")
                    '    End Try
                    'End If
                End If
            Catch ex As Exception
            End Try
        Next
      
        '****************** ACTUALIZAR CONSECUTIVO **********************
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
        myCommand.CommandText = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
        myCommand.ExecuteNonQuery()

        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        gitems.ReadOnly = True
        Cerrar()
        '...limpiar
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        'cmdver.Enabled = True

        'txtDoc.Text = ""
        'TxtDocumento.Text = ""
        'TxtNumero.Text = ""
        'txtdb.Text = Moneda(0)
        'txtcr.Text = Moneda(0)
        'txtdif.Text = Moneda(0)
        'gitems.Rows.Clear()
        'gitems.ReadOnly = True
        'CmdCancelar_Click(AcceptButton, AcceptButton)
    End Sub
    Private Sub GuardarPresup(ByVal fil As Integer)

        MiConexion(bda)
        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim cta As String = ""
        Dim ing As String = ""
        Dim val As Double = 0
        Dim f As String = Strings.Right(txtperiodo.Text, 4) & cbper.Text & txtdia.Text

        ' cta = txtcuenta.Text

        If gcon.Item(8, fil).Value <> "" Then
            If CDbl(gcon.Item(1, fil).Value) <> 0 Then ' debito
                MovPresup(pbd, gcon.Item(8, fil).Value, CDbl("-" & gcon.Item(1, fil).Value), f, gcon.Item(7, fil).Value.ToString)
            Else
                MovPresup(pbd, gcon.Item(8, fil).Value, CDbl(gcon.Item(2, fil).Value), f, gcon.Item(7, fil).Value.ToString)
            End If
        End If
        'Dim tp As New DataTable
        'tp.Clear()
        'myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
        '& " WHERE v.ingv_credito='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tp)
        'If tp.Rows.Count = 0 Then Exit Sub


        'For i = 0 To gitems.RowCount - 2
        '    Try
        '        If gitems.Item(3, i).Value.ToString <> "" And gitems.Item(3, i).Value.ToString <> txtcuenta.Text Then
        '            'If gitems.Item(3, i).Value.ToString Like 4 & "*" Then
        '            If CDbl(gitems.Item(1, i).Value) <> 0 Then ' debito
        '                MovPresup(pbd, tp.Rows(0).Item(1), CDbl("-" & gitems.Item(1, i).Value), f, gitems.Item(7, i).Value.ToString)
        '            Else
        '                MovPresup(pbd, tp.Rows(0).Item(1), CDbl(gitems.Item(2, i).Value), f, gitems.Item(7, i).Value.ToString)
        '            End If
        '            'MovPresup(pbd, tp.Rows(0).Item(1), CDbl(gitems.Item(2, fila).Value), f, gitems.Item(7, fila).Value.ToString)
        '            'End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        'Next
        Cerrar()
    End Sub
    Private Sub MovPresup(ByVal pbd As String, ByVal ing As String, ByVal val As Double, ByVal f As String, ByVal nit As String)

        Try
            'Guardar MovIng
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                            & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                            & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                            & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "' )"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
           & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
           & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
           & "   " & f & ", '" & ing & "',  'RECAUDO POR " & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
           & " '',  '',  'sae_cbanco', '" & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "', '" & nit & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            '..Buscar nivel
            Dim tam As Integer = Len(ing)
            Dim lik As String = ""

            Dim tg As New DataTable
            myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tg)
            Dim nv As String = tg.Rows(0).Item(0)
            Dim num As String = tg.Rows(0).Item(1)
            For j = 0 To tam
                lik = Strings.Left(ing, tam - j)

                Dim tc As New DataTable
                tc.Clear()
                myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                & "FROM " & pbd & ".ingvalores as v " _
                                & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                & "c.ingc_concepto LIMIT 1"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    For k = 0 To tc.Rows.Count - 1
                        nv = tc.Rows(k).Item("nivel")
                        num = tc.Rows(k).Item("num")
                        'Guardar MovIng
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                        & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                        & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                        & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                        & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "' )"
                        myCommand.ExecuteNonQuery()

                    Next
                End If

            Next
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try
    End Sub
    Public Sub Guardar(ByVal fila As Integer)


        Dim fecha As Date = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
        Dim diasv
        Try
            If gcon.Item(5, fila).Value = "0" Then
                fecha = CDate(txtdia.Text & "/" & cbper.Text & "/" & Strings.Right(PerActual, 4))
            Else
                fecha = fecha.AddDays(Val(gcon.Item(5, fila).Value))
            End If
        Catch ex As Exception
            fecha = "(NINGUNA)"
        End Try
        Try
            If Val(gcon.Item(5, fila).Value) = 0 Then
                diasv = 0
            Else
                diasv = Val(gcon.Item(5, fila).Value)
            End If
        Catch ex As Exception
            diasv = 0
        End Try
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", txtNcb.Text)
        myCommand.Parameters.AddWithValue("?tipodoc", txtDcb.Text)
        myCommand.Parameters.AddWithValue("?periodo", cbper.Text & "/" & txtperiodo.Text)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
        Try
            myCommand.Parameters.AddWithValue("?centro", gcon.Item(8, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?centro", "0")
        End Try
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(gcon.Item(0, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(gcon.Item(1, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(gcon.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", gcon.Item(3, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(gcon.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", diasv)
        myCommand.Parameters.AddWithValue("?fechaven", CambiaCadena(Trim(fecha.ToString), 10))
        Try
            myCommand.Parameters.AddWithValue("?cheque", gcon.Item(9, fila).Value.ToString)
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?cheque", "")
        End Try
        'Try
        '    myCommand.Parameters.AddWithValue("?nit", gcon.Item(7, fila).Value.ToString)
        'Catch ex As Exception
        '    myCommand.Parameters.AddWithValue("?nit", "0")
        'End Try
        Try
            If gcon.Item(7, fila).Value.ToString = "" Or IsDBNull(gcon.Item(7, fila).Value.ToString) = True Then
                myCommand.Parameters.AddWithValue("?nit", "0")
            Else
                myCommand.Parameters.AddWithValue("?nit", gcon.Item(7, fila).Value.ToString)
            End If
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?nit", "0")
        End Try

        myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
        myCommand.CommandText = "INSERT INTO documentos" & cbper.Text & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
        Refresh()
        Cerrar()

    End Sub
    Public col, fila, FinEdit As Integer
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        ValoresDefecto(e.RowIndex)
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO DESCRIPCION 
                    'If filaAnt < fila And FinEdit = 1 Then
                    '    Posicionar(1)
                    'End If
                Case 1  'CASO DEBITO 
                Case 2  'CASO CREDITO                     
                Case 3 'CASO CUENTA 
                    If gitems.Item(3, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 4 'CASO BASE                     
                Case 5 'CASO DIAS                     
                Case 6 'CASO FECHA                    
                Case 7 'CASO NIT 
                    If gitems.Item(7, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 8 'CASO NIT 
                    If gitems.Item(8, e.RowIndex).Value <> "" Or gitems.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    If FinEdit = 1 Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub txtsalB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsalB.LostFocus
        caldif()
    End Sub
    Private Sub caldif()
        Try
            txtsalB.Text = Moneda(txtsalB.Text)
            txtdifsal.Text = Moneda(CDbl(txtsalaj.Text) - CDbl(txtsalB.Text))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            GeneralPDF2()
        Catch ex As Exception
            MsgBox("Error al generar el documento" & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub
    Private Sub GeneralPDF2()
        Dim tp As String = ""
        Dim p As String = ""
        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""
        Dim des As String = ""


        MiConexion(bda)
        Cerrar()

        tp = " and d.tipodoc='" & TxtDocumento.Text & "' and doc='" & Int(TxtNumero.Text) & "'"

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = "NIT : " & tabla2.Rows(0).Item("nit")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim desc As String = ""
        'If i2.Checked = True Then
        '    tp = "and d.tipodoc='" & TxtDocumento.Text & "'"
        '    desc = "(SELECT (SUM(debito)-SUM(credito)) FROM documentos" & p & " WHERE CAST(CONCAT(d.tipodoc, LPAD(d.doc, 7, '0')) AS CHAR(10)) = CAST(CONCAT(tipodoc, LPAD(doc, 7, '0')) AS CHAR(10))) AS base "
        'Else
        desc = "0 as base "
        'End If

        For i = 1 To CInt(Strings.Left(PerActual, 2))
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If

            If p <> CInt(Strings.Left(PerActual, 2)) Then
                sql = sql & "SELECT concat(d.tipodoc," & p & ")tipodoc , td.descripcion as centro, d.item,CAST(CONCAT(d.tipodoc, LPAD(d.doc,7,'0')) AS CHAR(10)) AS periodo, d.descri, " _
                & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo, concat(t.nombre,' ', t.apellidos) as cheque, " _
                & "  " & desc & " " _
                & " FROM documentos" & p & " d, tipdoc td, terceros t " _
                & " WHERE td.tipodoc = d.tipodoc " & tp & " and t.nit= d.nit UNION "
            Else
                sql = sql & "SELECT concat(d.tipodoc," & p & ")tipodoc, td.descripcion as centro, d.item,CAST(CONCAT(d.tipodoc, LPAD(d.doc,7,'0')) AS CHAR(10)) AS periodo, d.descri, " _
                & " d.codigo, d.nit, d.debito, d.credito, CAST(CONCAT(d.dia,'/',d.periodo) AS CHAR(20)) as modulo,  concat(t.nombre,' ', t.apellidos) as cheque,  " _
                & " " & desc & " " _
                & " FROM documentos" & p & " d, tipdoc td, terceros t " _
                & " WHERE td.tipodoc = d.tipodoc " & tp & "  and t.nit= d.nit"
            End If
        Next
        sql = sql & " ORDER BY tipodoc, periodo, item"


        Dim tabla As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportContDoc.rpt")
        CrReport.SetDataSource(tabla)
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        FrmReportCertR.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prdd As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)

            Prdd.Name = "ddes"
            Prdd.CurrentValues.AddValue(des.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prdd)

            FrmReportCertR.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCertR.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        'If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If CmdListo.Enabled = True Then
            If fila = gitems.RowCount - 1 Then Exit Sub
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
            If resultado = MsgBoxResult.Yes Then
                gitems.Rows.RemoveAt(fila)
                SacarCuenta()
            End If
        End If
       
    End Sub

    Private Sub gitems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gitems.KeyDown
        If e.KeyCode = 8 Then
            If fila = gitems.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        End If
        
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        If lbestado.Text = "NUEVO" Then
            txtDcb.Text = ""
            txtDcb2.Text = ""
            txtNcb.Text = ""
            FrmDocConciliaB.Gmov.Enabled = True

            txtsalaj.Text = CDbl(txtsalaj.Text) - CDbl(txtsalcon.Text)
            txtsalcon.Text = 0
            FrmDocConciliaB.gitems.Rows.Clear()
            If gcon.Rows.Count > 1 Then
                FrmDocConciliaB.CmdNuevo.Enabled = False
                FrmDocConciliaB.CmdCancelar.Enabled = True
                FrmDocConciliaB.CmdListo.Enabled = True
                FrmDocConciliaB.gitems.ReadOnly = False
                FrmDocConciliaB.gitems.Rows.Clear()
                FrmDocConciliaB.gitems.RowCount = gcon.RowCount
                For i = 0 To gcon.Rows.Count - 1
                    FrmDocConciliaB.gitems.Item("gdes", i).Value = gcon.Item("gdes", i).Value
                    FrmDocConciliaB.gitems.Item("gDeb", i).Value = gcon.Item("gDeb", i).Value
                    FrmDocConciliaB.gitems.Item("gCred", i).Value = gcon.Item("gCred", i).Value
                    FrmDocConciliaB.gitems.Item("gCta", i).Value = gcon.Item("gCta", i).Value
                    FrmDocConciliaB.gitems.Item("gBase", i).Value = gcon.Item("gBase", i).Value
                    FrmDocConciliaB.gitems.Item("gdvmto", i).Value = gcon.Item("gdvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gfvmto", i).Value = gcon.Item("gfvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gnit", i).Value = gcon.Item("gnit", i).Value
                    FrmDocConciliaB.gitems.Item("grubro", i).Value = gcon.Item("grubro", i).Value
                    FrmDocConciliaB.gitems.Item("gcheque", i).Value = gcon.Item("gcheque", i).Value
                    ' FrmDocConciliaB.gitems.Item("trbro", i).Value = gcon.Item("trbro", i).Value
                Next
            Else
                FrmDocConciliaB.CmdNuevo.Enabled = True
                FrmDocConciliaB.CmdCancelar.Enabled = False
                FrmDocConciliaB.CmdListo.Enabled = False
            End If
            gcon.Rows.Clear()
            FrmDocConciliaB.txtcuenta.Text = txtcuenta.Text
            FrmDocConciliaB.txtnomcta.Text = txtnomcta.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(txtsalaj.Text)
            FrmDocConciliaB.txtsalB.Text = txtsalB.Text
            FrmDocConciliaB.txtsalB2.Text = txtsalaj.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(CDbl(FrmDocConciliaB.txtsalB2.Text) + CDbl(FrmDocConciliaB.txtsalcon.Text))
            FrmDocConciliaB.txtdifsal.Text = txtdifsal.Text
            caldif()

            FrmDocConciliaB.ShowDialog()

            txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) + CDbl(txtsalcon.Text))
            caldif()

        ElseIf lbestado.Text = "EDITAR" Then
            
            FrmDocConciliaB.TxtDocumento.Text = txtDcb.Text
            FrmDocConciliaB.TxtNumero.Text = txtNcb.Text
            FrmDocConciliaB.Gmov.Enabled = True

            txtsalaj.Text = CDbl(txtsalaj.Text) - CDbl(txtsalcon.Text)
            txtsalcon.Text = 0
            FrmDocConciliaB.gitems.Rows.Clear()
            If gcon.Rows.Count > 1 Then
                FrmDocConciliaB.CmdNuevo.Enabled = False
                FrmDocConciliaB.CmdCancelar.Enabled = True
                FrmDocConciliaB.CmdListo.Enabled = True
                FrmDocConciliaB.gitems.ReadOnly = False
                FrmDocConciliaB.gitems.Enabled = True
                FrmDocConciliaB.gitems.Rows.Clear()
                FrmDocConciliaB.gitems.RowCount = gcon.RowCount
                For i = 0 To gcon.Rows.Count - 1
                    FrmDocConciliaB.gitems.Item("gdes", i).Value = gcon.Item("gdes", i).Value
                    FrmDocConciliaB.gitems.Item("gDeb", i).Value = gcon.Item("gDeb", i).Value
                    FrmDocConciliaB.gitems.Item("gCred", i).Value = gcon.Item("gCred", i).Value
                    FrmDocConciliaB.gitems.Item("gCta", i).Value = gcon.Item("gCta", i).Value
                    FrmDocConciliaB.gitems.Item("gBase", i).Value = gcon.Item("gBase", i).Value
                    FrmDocConciliaB.gitems.Item("gdvmto", i).Value = gcon.Item("gdvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gfvmto", i).Value = gcon.Item("gfvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gnit", i).Value = gcon.Item("gnit", i).Value
                    FrmDocConciliaB.gitems.Item("grubro", i).Value = gcon.Item("grubro", i).Value
                    FrmDocConciliaB.gitems.Item("gcheque", i).Value = gcon.Item("gcheque", i).Value
                    '   FrmDocConciliaB.gitems.Item("trbro", i).Value = gcon.Item("trbro", i).Value
                Next
            Else
                FrmDocConciliaB.CmdNuevo.Enabled = True
                FrmDocConciliaB.CmdCancelar.Enabled = False
                FrmDocConciliaB.CmdListo.Enabled = False
            End If
            gcon.Rows.Clear()
            FrmDocConciliaB.txtcuenta.Text = txtcuenta.Text
            FrmDocConciliaB.txtnomcta.Text = txtnomcta.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(txtsalaj.Text)
            FrmDocConciliaB.txtsalB.Text = txtsalB.Text
            FrmDocConciliaB.txtsalB2.Text = txtsalaj.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(CDbl(FrmDocConciliaB.txtsalB2.Text) + CDbl(FrmDocConciliaB.txtsalcon.Text))
            FrmDocConciliaB.txtdifsal.Text = txtdifsal.Text
            caldif()

            FrmDocConciliaB.ShowDialog()

            txtsalaj.Text = Moneda(CDbl(txtsalaj.Text) + CDbl(txtsalcon.Text))
            caldif()
        ElseIf lbestado.Text = "CONSULTA" Then
            FrmDocConciliaB.TxtDocumento.Text = txtDcb.Text
            FrmDocConciliaB.TxtNumero.Text = txtNcb.Text
            FrmDocConciliaB.Gmov.Enabled = False
            FrmDocConciliaB.gitems.Rows.Clear()
            If gcon.Rows.Count > 1 Then
                FrmDocConciliaB.CmdNuevo.Enabled = False
                FrmDocConciliaB.CmdCancelar.Enabled = True
                FrmDocConciliaB.CmdListo.Enabled = True
                FrmDocConciliaB.gitems.ReadOnly = False
                FrmDocConciliaB.gitems.Rows.Clear()
                FrmDocConciliaB.gitems.RowCount = gcon.RowCount
                For i = 0 To gcon.Rows.Count - 1
                    FrmDocConciliaB.gitems.Item("gdes", i).Value = gcon.Item("gdes", i).Value
                    FrmDocConciliaB.gitems.Item("gDeb", i).Value = gcon.Item("gDeb", i).Value
                    FrmDocConciliaB.gitems.Item("gCred", i).Value = gcon.Item("gCred", i).Value
                    FrmDocConciliaB.gitems.Item("gCta", i).Value = gcon.Item("gCta", i).Value
                    FrmDocConciliaB.gitems.Item("gBase", i).Value = gcon.Item("gBase", i).Value
                    FrmDocConciliaB.gitems.Item("gdvmto", i).Value = gcon.Item("gdvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gfvmto", i).Value = gcon.Item("gfvmto", i).Value
                    FrmDocConciliaB.gitems.Item("gnit", i).Value = gcon.Item("gnit", i).Value
                    FrmDocConciliaB.gitems.Item("grubro", i).Value = gcon.Item("grubro", i).Value
                    FrmDocConciliaB.gitems.Item("gcheque", i).Value = gcon.Item("gcheque", i).Value
                    ' FrmDocConciliaB.gitems.Item("trbro", i).Value = gcon.Item("trbro", i).Value
                Next
            Else
                FrmDocConciliaB.CmdNuevo.Enabled = True
                FrmDocConciliaB.CmdCancelar.Enabled = False
                FrmDocConciliaB.CmdListo.Enabled = False
            End If

            FrmDocConciliaB.txtcuenta.Text = txtcuenta.Text
            FrmDocConciliaB.txtnomcta.Text = txtnomcta.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(txtsalaj.Text)
            FrmDocConciliaB.txtsalB.Text = txtsalB.Text
            FrmDocConciliaB.txtsalB2.Text = txtsalaj.Text
            FrmDocConciliaB.txtsaldo.Text = Moneda(CDbl(FrmDocConciliaB.txtsalB2.Text) + CDbl(FrmDocConciliaB.txtsalcon.Text))
            FrmDocConciliaB.txtdifsal.Text = txtdifsal.Text
            FrmDocConciliaB.ShowDialog()
        End If

    End Sub

    Private Sub gitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellContentClick

    End Sub

   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGd.Click
        If lbestado.Text = "NUEVO" Then
            Validar()
        ElseIf lbestado.Text = "EDITAR" Then
            Dim rs As MsgBoxResult
            rs = MsgBox("Se va a Modificar la Conciliacion No " & lbnum.Text & ".¿Desea continuar? ", MsgBoxStyle.YesNo, "Verificando")
            If rs = MsgBoxResult.Yes Then
                EliminarDatos()
                Validar()
            End If
        End If

    End Sub
    Private Sub Validar()
        Try
            Dim mifec As Date
            mifec = txtdia.Text & "/" & cbper.Text & "/" & txtperiodo.Text
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
            Exit Sub
        End Try
        'MesdelPeriodo()
        'Dim cad As String
        'cad = TxtDocumento.Text
        'cad = cad(0) & cad(1)
        MiConexion(bda)

        Guardar()
        ' GUARDAR DOCXX  CB
        For i = 0 To gcon.RowCount - 1
            Try
                If gcon.Item(3, i).Value.ToString <> "" Then
                    Guardar(i)
                    'If gcon.Item(3, i).Value.ToString <> txtcuenta.Text Then
                    '    Try
                    '        GuardarPresup(i)
                    '    Catch ex As Exception
                    '        MsgBox("Error al ingresar en presupuesto")
                    '    End Try
                    'End If
                End If
            Catch ex As Exception
            End Try
        Next

        MiConexion(bda)
        'GUARDAR OTROS MOVI
        For i = 0 To gitems.RowCount - 2
            Try
                If gitems.Item("descripcion", i).Value.ToString <> "" Then
                    GuardarOtros(i)
                End If
            Catch ex As Exception
            End Try
        Next

        'GUARDAR DATOS CONCILIACION
        For i = 0 To grilla.RowCount - 1
            Try
                If grilla.Item("tipo", i).Value.ToString <> "" Then
                    GuardarCon(i)
                End If
            Catch ex As Exception
            End Try
        Next
        '****************** ACTUALIZAR CONSECUTIVO **********************
        actualizarcon()
        MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
        bloquear()
        Cerrar()
        lbestado.Text = "NUEVO"
    End Sub
    Private Sub Guardar()
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?num", lbnum.Text)
            myCommand.Parameters.AddWithValue("?per", cbper.Text & "/" & txtperiodo.Text)
            myCommand.Parameters.AddWithValue("?dia", txtdia.Text)
            myCommand.Parameters.AddWithValue("?ctabanco", txtcuenta.Text)
            myCommand.Parameters.AddWithValue("?doccon", cbper.Text)
            myCommand.Parameters.AddWithValue("?docotros", TxtDocumento.Text & TxtNumero.Text)
            myCommand.Parameters.AddWithValue("?doccuadre", txtDcb.Text & txtNcb.Text)
            myCommand.Parameters.AddWithValue("?fini", CDate(fecha1.Text.ToString))
            myCommand.Parameters.AddWithValue("?ffin", CDate(fecha2.Text.ToString))
            myCommand.Parameters.AddWithValue("?salaj", DIN(txtsalaj.Text))
            myCommand.Parameters.AddWithValue("?salbanco", DIN(txtsalB.Text))
            myCommand.Parameters.AddWithValue("?saldol", DIN(txtsaldo.Text))
            myCommand.Parameters.AddWithValue("?elab", FrmPrincipal.lbuser.Text)
            'INSERTAR DETALLES
            myCommand.CommandText = "INSERT INTO conciliacion " _
                                  & " VALUES(?num,?per,?dia,?ctabanco,?doccon,?docotros,?doccuadre,?fini,?ffin,?salaj,?salbanco,?saldol,?elab);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
    Public Sub GuardarCon(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", lbnum.Text)
            myCommand.Parameters.AddWithValue("?item", fila)
            myCommand.Parameters.AddWithValue("?tipo_it", "")
            myCommand.Parameters.AddWithValue("?codart", grilla.Item("fecha", fila).Value)
            myCommand.Parameters.AddWithValue("?nom_art", grilla.Item("conepto", fila).Value)
            myCommand.Parameters.AddWithValue("?numbod", Val(0))
            myCommand.Parameters.AddWithValue("?cantidad", DIN(0))
            myCommand.Parameters.AddWithValue("?valor", DIN(grilla.Item("Debitos", fila).Value))
            myCommand.Parameters.AddWithValue("?vtotal", DIN(grilla.Item("Creditos", fila).Value))
            myCommand.Parameters.AddWithValue("?por_iva_g", DIN(0))
            'cuentas y concepto
            myCommand.Parameters.AddWithValue("?cta_inv", grilla.Item("nit", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_cos", grilla.Item("cheque2", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_gas", grilla.Item("sel", fila).Value)
            myCommand.Parameters.AddWithValue("?cta_iva", grilla.Item("tipo", fila).Value)
            myCommand.Parameters.AddWithValue("?concep", grilla.Item("numero", fila).Value)
            'INSERTAR DETALLES
            myCommand.CommandText = "INSERT INTO detacomp" & cbper.Text & " " _
                                  & " VALUES(?doc,?item,?tipo_it,?codart,?nom_art,?numbod,?cantidad,?valor,?vtotal,?por_iva_g,?cta_inv,?cta_cos,?cta_gas,?cta_iva,?concep);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GuardarOtros(ByVal fila As Integer)
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?doc", TxtDocumento.Text & TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?item", fila)
            myCommand.Parameters.AddWithValue("?tipo_it", "")
            myCommand.Parameters.AddWithValue("?codart", txtcuenta.Text)
            myCommand.Parameters.AddWithValue("?descrip", gitems.Item("descripcion", fila).Value)
            myCommand.Parameters.AddWithValue("?numbod", Val(0))
            myCommand.Parameters.AddWithValue("?cantidad", DIN(0))
            myCommand.Parameters.AddWithValue("?valor", DIN(gitems.Item("Deb", fila).Value))
            myCommand.Parameters.AddWithValue("?vtotal", DIN(gitems.Item("Cred", fila).Value))
            myCommand.Parameters.AddWithValue("?iva_d", DIN(0))
            'descuento
            myCommand.Parameters.AddWithValue("?por_des", DIN(0))
            'cuentas y concepto
            Try

                If gitems.Item("Cuenta", fila).Value = "" Or IsDBNull(gitems.Item("Cuenta", fila).Value) = True Then
                    myCommand.Parameters.AddWithValue("?cta_inv", "")
                Else
                    myCommand.Parameters.AddWithValue("?cta_inv", gitems.Item("Cuenta", fila).Value)
                End If
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?cta_inv", ".")
            End Try
            myCommand.Parameters.AddWithValue("?cta_cos", "")
            myCommand.Parameters.AddWithValue("?cta_ing", "")
            myCommand.Parameters.AddWithValue("?cta_iva", "")
            Try
                myCommand.Parameters.AddWithValue("?costo", DIN(0))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?costo", "0")
            End Try
            myCommand.Parameters.AddWithValue("?concep", "")
            myCommand.Parameters.AddWithValue("?nit", "")
            'INSERTAR DETALLES
            myCommand.CommandText = "INSERT INTO detafac" & cbper.Text & " " _
                                  & " VALUES(?doc,?item,?tipo_it,?codart,?descrip,?numbod,?cantidad,?valor,?vtotal,?iva_d,?por_des,?cta_inv,?cta_cos,?cta_ing,?cta_iva,?costo,?concep,?nit);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub actualizarcon()
        'DOC CB
        Dim t2 As New DataTable
        t2.Clear()
        myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & txtDcb.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        Dim cs As String = ""
        If t2.Rows.Count > 0 Then
            If t2.Rows(0).Item("grupo") <> "FC" Then
                cs = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
            Else
                cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            End If

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", txtNcb.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", txtDcb.Text)
            myCommand.CommandText = cs
            myCommand.ExecuteNonQuery()
            '....
        End If

        'DOC OC      
        Dim t3 As New DataTable
        t3.Clear()
        myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & TxtDocumento.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t3)
        cs = ""
        If t3.Rows.Count > 0 Then
            If t3.Rows(0).Item("grupo") <> "FC" Then
                cs = "Update tipdoc set actual" & cbper.Text & "=?actual WHERE tipodoc=?tipodoc AND actual" & cbper.Text & "<?actual;"
            Else
                cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
            End If

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?actual", TxtNumero.Text.ToString)
            myCommand.Parameters.AddWithValue("?tipodoc", TxtDocumento.Text)
            myCommand.CommandText = cs
            myCommand.ExecuteNonQuery()
        End If
    End Sub

    Private Sub cmdcanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcanc.Click
        bloquear()
        limpiar()
    End Sub

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        Try
            FrmSelConcili.lbform.Text = "ConcilB"
            FrmSelConcili.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If lbnum.Text <> "" Then
            BuscarConciliacion()
        End If
    End Sub
    Private Sub BuscarConciliacion()

        gdatos.Enabled = False
        Gmov.Enabled = False

        Dim tb As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT c.*, b.* FROM conciliacion c, bancos b WHERE c.ctabanco= b.codigo and c.num='" & lbnum.Text & "' ORDER BY num; "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)


        txtcuenta.Text = tb.Rows(0).Item("ctabanco")
        BuscarDatosB()
        lbnum.Text = tb.Rows(0).Item("num")
        fecha1.Value = CDate(tb.Rows(0).Item("fini").ToString)
        fecha2.Value = CDate(tb.Rows(0).Item("ffin").ToString)
        txtsaldo.Text = Moneda(tb.Rows(0).Item("sallibro"))
        txtsalaj.Text = Moneda(tb.Rows(0).Item("salaj"))
        txtsalB.Text = Moneda(tb.Rows(0).Item("salbanco"))
        txtDcb.Text = Strings.Left(tb.Rows(0).Item("doccuadre"), 2)
        txtNcb.Text = Strings.Right(tb.Rows(0).Item("doccuadre"), 5)
        TxtDocumento.Text = Strings.Left(tb.Rows(0).Item("docotros"), 2)
        TxtNumero.Text = Strings.Right(tb.Rows(0).Item("docotros"), 5)
        txtdia.Text = tb.Rows(0).Item("dia")
        cbper.Text = Strings.Left(tb.Rows(0).Item("per"), 2)
        txtperiodo.Text = Strings.Right(tb.Rows(0).Item("per"), 4)
        If tb.Rows(0).Item("doccuadre") <> "" Then
            buscar_CB(Strings.Left(tb.Rows(0).Item("per"), 2))
        Else
            gcon.Rows.Clear()
        End If
        If tb.Rows(0).Item("docotros") <> "" Then
            buscar_OD(Strings.Left(tb.Rows(0).Item("per"), 2), tb.Rows(0).Item("docotros"))
        Else
            gitems.Rows.Clear()
        End If
        buscar_datosc(tb.Rows(0).Item("doccon"), tb.Rows(0).Item("num"))
        lbestado.Text = "CONSULTA"
    End Sub
    Private Sub buscar_CB(ByVal p As String)

        Dim tcb As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM documentos" & p & " WHERE tipodoc='" & txtDcb.Text & "' and doc ='" & Val(txtNcb.Text) & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tcb)

        If tcb.Rows.Count > 0 Then
            gcon.Rows.Clear()
            gcon.RowCount = tcb.Rows.Count + 1
            For i = 0 To tcb.Rows.Count - 1
                gcon.Item("gdes", i).Value = tcb.Rows(i).Item("descri")
                gcon.Item("gDeb", i).Value = Moneda(tcb.Rows(i).Item("debito"))
                gcon.Item("gCred", i).Value = Moneda(tcb.Rows(i).Item("credito"))
                gcon.Item("gcta", i).Value = tcb.Rows(i).Item("codigo")
                gcon.Item("gbase", i).Value = tcb.Rows(i).Item("base")
                gcon.Item("gdvmto", i).Value = tcb.Rows(i).Item("diasv")
                gcon.Item("gfvmto", i).Value = tcb.Rows(i).Item("fechaven")
                gcon.Item("gnit", i).Value = tcb.Rows(i).Item("nit")
                gcon.Item("grubro", i).Value = tcb.Rows(i).Item("centro")
                gcon.Item("gcheque", i).Value = tcb.Rows(i).Item("cheque")
            Next
        End If

    End Sub
    Private Sub buscar_OD(ByVal p As String, ByVal doc As String)

        Dim tob As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM detafac" & p & " WHERE doc='" & doc & "'  "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tob)

        If tob.Rows.Count > 0 Then
            gitems.Rows.Clear()
            gitems.RowCount = tob.Rows.Count + 1
            For i = 0 To tob.Rows.Count - 1
                gitems.Item("descripcion", i).Value = tob.Rows(i).Item("nomart")
                gitems.Item("Deb", i).Value = Moneda(tob.Rows(i).Item("valor"))
                gitems.Item("Cred", i).Value = Moneda(tob.Rows(i).Item("vtotal"))
                gitems.Item("Cuenta", i).Value = tob.Rows(i).Item("codart")
            Next
        End If
    End Sub
    Private Sub buscar_datosc(ByVal p As String, ByVal num As String)

        Dim td As New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM detacomp" & p & " WHERE doc='" & num & "'  "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)

        If td.Rows.Count > 0 Then
            grilla.Rows.Clear()
            grilla.RowCount = td.Rows.Count + 1
            For i = 0 To td.Rows.Count - 1
                grilla.Item("fecha", i).Value = td.Rows(i).Item("cod_art")
                grilla.Item("tipo", i).Value = td.Rows(i).Item("cta_iva")
                grilla.Item("numero", i).Value = td.Rows(i).Item("concep")
                grilla.Item("Debitos", i).Value = Moneda(td.Rows(i).Item("valor"))
                grilla.Item("Creditos", i).Value = Moneda(td.Rows(i).Item("vtotal"))
                grilla.Item("conepto", i).Value = td.Rows(i).Item("nom_art")
                grilla.Item("nit", i).Value = td.Rows(i).Item("cta_inv")
                grilla.Item("cheque2", i).Value = td.Rows(i).Item("cta_cos")
                grilla.Item("sel", i).Value = td.Rows(i).Item("cta_gas")
            Next
        End If
    End Sub

    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If lbnum.Text = "" Then
            MsgBox("Verifique el documento a Eliminar", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        Dim rs As MsgBoxResult
        rs = MsgBox("Se va a Eliminar la Conciliacion No " & lbnum.Text & ".¿Desea continuar? ", MsgBoxStyle.YesNo, "Verificando")
        If rs = MsgBoxResult.Yes Then

            EliminarDatos()
            limpiar()
            lbestado.Text = "ELIMINADO"
            MsgBox("Conciliacion Eliminada ", MsgBoxStyle.Information, "SAE")
            grilla.Rows.Clear()

        End If
    End Sub
    Private Sub EliminarDatos()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM documentos" & cbper.Text & " WHERE doc='" & DIN(txtNcb.Text) & "' and tipodoc='" & txtDcb.Text & "';"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM detacomp" & cbper.Text & " WHERE doc='" & DIN(lbnum.Text) & "' ;"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM detafac" & cbper.Text & " WHERE doc='" & TxtDocumento.Text & TxtNumero.Text & "' ;"
        myCommand.ExecuteNonQuery()

        myCommand.Parameters.Clear()
        myCommand.CommandText = "DELETE FROM conciliacion WHERE num='" & lbnum.Text & "' ;"
        myCommand.ExecuteNonQuery()

        Try
            If txtDcb.Text <> "" And txtNcb.Text <> "" Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM presupuesto" & Strings.Right(PerActual, 4) & ".movingresos WHERE movi_reconoce='" & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "'"
                myCommand.ExecuteNonQuery()

                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM presupuesto" & Strings.Right(PerActual, 4) & ".recaudos WHERE rec_nrodoc='" & cbper.Text & "/" & txtperiodo.Text & "-" & txtDcb.Text & txtNcb.Text & "'"
                myCommand.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
        Cerrar()
    End Sub

    Private Sub cmdver_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdver.Click
        If lbnum.Text = "" Then
            MsgBox("Verifique el documento a Visualizar", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        MiConexion(bda)
        Ver()
        Cerrar()
    End Sub
    Private Sub Ver()

        Dim sql As String = ""
        Dim nom As String = ""
        Dim nit As String = ""

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        ':::::::::::::::::::::::::::::::::::::::::::::


        Dim tabl As New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT c.num, c.sallibro AS subtotal, c.salbanco AS descto, (c.sallibro-c.salbanco) AS total, c.docotros AS nitc," _
        & " c.doccuadre AS nitcod, c.salaj AS ret,CAST( CONCAT(s.nombres,' ', s.apellidos) AS CHAR(50)) AS doc_ext FROM conciliacion c, sae.usuarios s " _
        & " WHERE c.num='" & lbnum.Text & "' AND s.login= c.elaborado LIMIT 1 "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT item, CAST(CONCAT(cta_iva,concep) AS CHAR(15)) AS doc, cod_art AS codart, nom_art AS nomart, valor AS cantidad, vtotal AS valor," _
        & " cta_cos, cta_gas AS cta_ing  FROM detacomp" & cbper.Text & " WHERE doc='" & lbnum.Text & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "deta_mov01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT item, nomart, valor, vtotal, cta_inv FROM detafac" & cbper.Text & " WHERE doc='" & TxtDocumento.Text & TxtNumero.Text & "'; "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "detafac01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT item, descri, debito, credito, codigo, cheque FROM documentos" & cbper.Text & " WHERE tipodoc='" & txtDcb.Text & "' AND doc='" & Val(txtNcb.Text) & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "documentos01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportConciB.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            ''..
            Dim Prcta1 As New ParameterField
            Dim Prdeta1 As New ParameterField
            Dim Prdb1 As New ParameterField
            Dim Prcd1 As New ParameterField

            Dim Prcta2 As New ParameterField
            Dim Prdeta2 As New ParameterField
            Dim Prdb2 As New ParameterField
            Dim Prcd2 As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "comp"
            PrNit.CurrentValues.AddValue(nom)
            Prcomp.Name = "nit"
            Prcomp.CurrentValues.AddValue(nit.ToString)
            ' ''...
            Prcta1.Name = "banco"
            Prcta1.CurrentValues.AddValue(txtnit.Text & " " & txtbanco.Text)
            Prdeta1.Name = "No cta"
            Prdeta1.CurrentValues.AddValue(txtnum.Text)
            Prdb1.Name = "cta"
            Prdb1.CurrentValues.AddValue(txtcuenta.Text)
            Prcd1.Name = "fecha"
            Prcd1.CurrentValues.AddValue(fecha1.Text & " a " & fecha2.Text)
            ' ''...
            Prcta2.Name = "fechae"
            Prcta2.CurrentValues.AddValue(txtdia.Text & "/" & cbper.Text & "/" & txtperiodo.Text)
            Prdeta2.Name = "tt"
            Prdeta2.CurrentValues.AddValue("CONCILIACION BANCARIA No " & lbnum.Text)
            'Prdb2.Name = "db2"
            'Prdb2.CurrentValues.AddValue(pdb2)
            'Prcd2.Name = "cd2"
            'Prcd2.CurrentValues.AddValue(pcd2)


            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prcta1)
            prmdatos.Add(Prdeta1)
            prmdatos.Add(Prdb1)
            prmdatos.Add(Prcd1)
            prmdatos.Add(Prcta2)
            prmdatos.Add(Prdeta2)
            'prmdatos.Add(Prdb2)
            'prmdatos.Add(Prcd2)


            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        lbestado.Text = "EDITAR"
        gdatos.Enabled = True
        Gmov.Enabled = True
        desbloquear()
        CmdNuevo.Enabled = False
        CmdCancelar.Enabled = True
    End Sub
End Class