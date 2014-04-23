Public Class FrmExtratosBanc

    Private Sub cmdActCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActCuenta.Click
        Try
            lbhay.Text = "no"
            FrmSelBanco.lbform.Text = "banco_ext"
            FrmSelBanco.ShowDialog()
            If lbhay.Text <> "no" Then
                BuscarDatosB()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PonerEnCero()
        Try
            grilla.Rows.Clear()
            txtcuenta.Text = ""
            'txtcodigo.Text = ""
            txtnit.Text = ""
            txtbanco.Text = ""
            txtnum.Text = ""
            txtsi.Text = "0,00"
            txtsaldo.Text = "0,00"
            txtdb.Text = "0,00"
            txtcr.Text = "0,00"
            txtextra.Text = "0,00"
            txtnomcta.Text = ""
            'txtnombre.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarDatosB()
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
            txtper.Text = PerActual
            BuscarSi()
            Saldos()
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
            'MsgBox(sql)
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
    Public Sub Saldos()
        Dim tablaPer As New DataTable
        Dim sql As String
        Dim axu As Integer = 0
        Dim perf As String = PerActual(0) & PerActual(1)
        sql = "SELECT * FROM documentos" & perf & " WHERE codigo='" & txtcuenta.Text & "' ORDER BY dia,tipodoc,doc;"
        Dim sumad As Double = 0
        Dim sumac As Double = 0
        Try
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
                    End Try
                    grilla.Item("fecha", i).Value = tablaPer.Rows(i).Item("dia").ToString & "/" & tablaPer.Rows(i).Item("periodo").ToString
                    grilla.Item("numero", i).Value = NumeroDoc(tablaPer.Rows(i).Item("doc").ToString)
                    grilla.Item("tipo", i).Value = tablaPer.Rows(i).Item("tipodoc").ToString
                    grilla.Item("Debitos", i).Value = Moneda(tablaPer.Rows(i).Item("debito").ToString)
                    grilla.Item("Creditos", i).Value = Moneda(tablaPer.Rows(i).Item("credito").ToString)
                    grilla.Item("conepto", i).Value = tablaPer.Rows(i).Item("descri").ToString
                    grilla.Item("nit", i).Value = tablaPer.Rows(i).Item("nit").ToString
                Next
            Else
                grilla.RowCount = 1
            End If
        Catch ex As Exception
            'MsgBox("22222" & ex.ToString)
        End Try
        txtdb.Text = Moneda(sumad)
        txtcr.Text = Moneda(sumac)
        txtextra.Text = Moneda(CDbl(Moneda(sumad)) - CDbl(Moneda(sumac)))
        txtsaldo.Text = Moneda(CDbl(txtsi.Text) + CDbl(txtextra.Text))
    End Sub
    Private Sub cmdtran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtran.Click
        MiConexion(bda)
        Cerrar()
        FrmEntradaDatos.lbform.Text = "bancos"
        FrmEntradaDatos.ShowDialog()
        If Trim(txtcuenta.Text) <> "" Then
            BuscarDatosB()
        End If
    End Sub
    '*****************************************************************
    Private Sub FrmExtratosBanc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PonerEnCero()
    End Sub

    Private Sub cminfoconciliaicon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cminfoconciliaicon.Click
        If Trim(txtcuenta.Text) = "" Then
            MsgBox("Favor seleccione un banco... ", MsgBoxStyle.Information)
        Else

        End If
    End Sub
End Class