Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmInfCGN

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfCGN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbini.Text = Strings.Left(PerActual, 2)
        cbfin.Text = Strings.Left(PerActual, 2)
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With

        Try
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\cgn2005.txt") Then
                txtcodEntidad.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\cgn2005.txt")
            End If

            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\cgn2005tt.txt") Then
                Dim Archivo As String = ""
                Archivo = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\cgn2005tt.txt")
                txtnombre.Text = Archivo
            End If
        Catch ex As Exception
        End Try

        cmdBuscar_Click(AcceptButton, AcceptButton)
    End Sub


    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        GenerarTxt()
    End Sub
    Private Sub generarPDF()

        Dim sql As String = ""
        Dim p As String = ""
        Dim debito As String = ""
        Dim credito As String = ""
        Dim debito_s As String = ""
        Dim credito_s As String = ""
        Dim saldoI As String = ""
        Dim saldoI_s As String = ""
        Dim saldoF As String = ""
        Dim saldoF_s As String = ""
        Dim per As String = ""
        Dim nom As String = ""
        Dim nit As String = ""

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text
        'tt = "BALANCE DE PRUEBA"
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")


        If Val(cbini.Text) - 1 < 10 Then
            saldoI = "c.saldo0" & cbini.Text - 1
            saldoI_s = "saldo0" & cbini.Text - 1
        Else
            saldoI = "c.saldo" & cbini.Text - 1
            saldoI_s = "saldo" & cbini.Text - 1
        End If
        saldoF = "c.saldo" & cbini.Text
        saldoF_s = "saldo" & cbini.Text

        For i = Val(cbini.Text) To Val(cbfin.Text)
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If p = cbini.Text Then
                debito = debito & "c.debito" & p
                credito = credito & "c.credito" & p
                debito_s = debito_s & "debito" & p
                credito_s = credito_s & "credito" & p
            Else
                debito = debito & "+ c.debito" & p
                credito = credito & "+ c.credito" & p
                debito_s = debito_s & ", debito" & p
                credito_s = credito_s & ", credito" & p

            End If
        Next

        MiConexion(bda)
        'sql = " SELECT s.tipo_saldo, CONCAT(LEFT(s.codigo,1),'.',MID(s.codigo, 2, 1),'.',MID(s.codigo, 3, 2),'.',MID(s.codigo, 5, 2) ) AS cta, " _
        '& " s.codigo AS observ,s.descripcion as descrip, SUM(" & saldoI & ") as subtotal, sum(" & debito & ") as v1, sum(" & credito & ") as v2, CONVERT((SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),SIGNED) as total, " _
        '& "  CONVERT(IF(s.tipo_saldo='CO', (SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),'0') ,SIGNED) AS salCorr,  " _
        '& "   CONVERT(IF(s.tipo_saldo='NO', (SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),'0'),SIGNED) AS salNoCorr  " _
        '& " FROM " _
        '& " (SELECT codigo, " & saldoI_s & ", nivel, " & debito_s & ", " & credito_s & ", " & saldoF_s & "  from selpuc  where nivel = 'Auxiliar' ) as c " _
        '& "right join selpuc s on (c.codigo LIKE CONCAT(s.codigo,'%')) WHERE LENGTH(s.codigo)=(SELECT SUM(nivel1+nivel2+nivel3+nivel4) AS s FROM parcontab)  GROUP BY s.codigo ORDER BY observ"

        sql = "SELECT s.nivel, s.tipo_saldo," _
        & " CASE LENGTH(s.codigo) " _
        & " WHEN '1' THEN s.codigo  " _
        & " WHEN '2' THEN CONCAT(LEFT(s.codigo,1),'.',MID(s.codigo, 2, 1) ) " _
        & " WHEN '4' THEN CONCAT(LEFT(s.codigo,1),'.',MID(s.codigo, 2, 1),'.',MID(s.codigo, 3, 2)) " _
        & " WHEN '6' THEN CONCAT(LEFT(s.codigo,1),'.',MID(s.codigo, 2, 1),'.',MID(s.codigo, 3, 2),'.',MID(s.codigo, 5, 2))  " _
        & " WHEN '8' THEN CONCAT(LEFT(s.codigo,1),'.',MID(s.codigo, 2, 1),'.',MID(s.codigo, 3, 2),'.',MID(s.codigo, 5, 2),'.',MID(s.codigo, 7, 2)) " _
        & " END AS cta,  " _
        & "  s.codigo AS observ,s.descripcion AS descrip, " _
        & " ROUND(ROUND(SUM(" & saldoI & "),-3)/1000,0) as subtotal, " _
        & " ROUND(ROUND(SUM(" & debito & "),-3)/1000,0) as v1, " _
        & " ROUND(ROUND(SUM(" & credito & "),-3)/1000,0) as v2, " _
        & " ROUND(ROUND(CONVERT((SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),SIGNED),-3)/1000,0) as total, " _
        & " ROUND(ROUND(CONVERT(IF(s.tipo_saldo='CO', (SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),'0') ,SIGNED),-3)/1000,0) AS salCorr,  " _
        & " ROUND(ROUND(CONVERT(IF(s.tipo_saldo='NO', (SUM(" & saldoI & ")+ sum(" & debito & ")- SUM(" & credito & ")),'0'),SIGNED),-3)/1000,0) AS salNoCorr  " _
        & " FROM (SELECT codigo, " & saldoI_s & ", nivel, " & debito_s & ", " & credito_s & ", " & saldoF_s & "  from selpuc  where nivel = 'Auxiliar' ) as c " _
        & "RIGHT JOIN selpuc s  ON (c.codigo LIKE CONCAT(s.codigo,'%')) GROUP BY s.codigo ORDER BY observ"



        Dim tabla As New DataTable
        tabla.Clear()
        tabla = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        If tabla.Rows.Count = 0 Then
            MsgBox("No existen datos para mostrar", MsgBoxStyle.Information, "SAE")
            Exit Sub
        End If
        Dim fl As Integer = 0
        Try
            gitems.Rows.Clear()
            gitems.RowCount = 0
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        gitems.RowCount = tabla.Rows.Count + 1

        For i = 0 To tabla.Rows.Count - 1
            If tabla.Rows(i).Item("nivel") <> "Auxiliar" Then
                If tabla.Rows(i).Item("tipo_saldo") = "CO" Then
                    gitems.Item("tsaldo", fl).Value = True
                Else
                    gitems.Item("tsaldo", fl).Value = False
                End If
                gitems.Item("codigo", fl).Value = tabla.Rows(i).Item("cta")
                gitems.Item("descrip", fl).Value = tabla.Rows(i).Item("descrip")
                gitems.Item("salini", fl).Value = tabla.Rows(i).Item("subtotal")
                gitems.Item("debito", fl).Value = tabla.Rows(i).Item("v1")
                gitems.Item("credito", fl).Value = tabla.Rows(i).Item("v2")
                gitems.Item("salfin", fl).Value = tabla.Rows(i).Item("total")
                gitems.Item("salcorr", fl).Value = tabla.Rows(i).Item("salCorr")
                gitems.Item("salno", fl).Value = tabla.Rows(i).Item("salNoCorr")
                gitems.Item("codigo2", fl).Value = tabla.Rows(i).Item("observ")
                fl = fl + 1
            End If
        Next
        gitems.RowCount = fl + 1

        Cerrar()
    End Sub
    Public fila As Integer
    Dim ant As Boolean
    Private Sub GenerarTxt()
        Dim sFile As String = ("C:\CGN.txt")
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then 'Si el archivo existe, lo elimina antes
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)

            '..................
            Dim dig As String = ""
            If CInt(cbfin.Text) <= 6 Then
                dig = "1" & cbini.Text & cbfin.Text
            Else
                dig = "2" & cbini.Text & cbfin.Text
            End If
            _Line = "S" & vbTab & _
                    txtcodEntidad.Text & vbTab & _
                    dig & vbTab & _
                    Strings.Right(PerActual, 4) & vbTab & _
                    txtnombre.Text & vbTab
            swFile.WriteLine(_Line)
            '................
            With gitems 'dgvLis es el nombre de mi DataGridView
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells(1).Value <> "" Then
                        _Line = "D" & vbTab & _
                                .Rows(i).Cells(1).Value & vbTab & _
                                .Rows(i).Cells(3).Value & vbTab & _
                                .Rows(i).Cells(4).Value & vbTab & _
                                .Rows(i).Cells(5).Value & vbTab & _
                                .Rows(i).Cells(6).Value & vbTab & _
                                .Rows(i).Cells(7).Value & vbTab & _
                                .Rows(i).Cells(8).Value & vbTab
                        swFile.WriteLine(_Line)
                    End If
                Next
            End With
            swFile.Close()
            '////////////////
            Dim sFile2 As String = (My.Application.Info.DirectoryPath & "\cgn2005.txt")
            If File.Exists(sFile2) = True Then 'Si el archivo existe, lo elimina antes
                My.Computer.FileSystem.DeleteFile(sFile2, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile2 As StreamWriter = New StreamWriter(sFile2)
            swFile2.WriteLine(txtcodEntidad.Text)
            '////////////////
            Dim sFile3 As String = (My.Application.Info.DirectoryPath & "\cgn2005tt.txt")
            If File.Exists(sFile3) = True Then 'Si el archivo existe, lo elimina antes
                My.Computer.FileSystem.DeleteFile(sFile3, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile3 As StreamWriter = New StreamWriter(sFile3)
            swFile3.WriteLine(txtcodEntidad.Text)
            MsgBox("Archivo Generado y Guardado en C:\CGN.txt", MsgBoxStyle.Information, "SAE")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gitems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gitems.CellBeginEdit
        Select Case e.ColumnIndex
            Case 0  'CASO TIPO  
                ant = gitems.Item("tsaldo", e.RowIndex).Value
        End Select
    End Sub

    Private Sub gitems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEndEdit
        Try
            Select Case e.ColumnIndex
                Case 0  'CASO TIPO  
                    If ant <> gitems.Item("tsaldo", e.RowIndex).Value Then
                        myCommand.Parameters.Clear()
                        If gitems.Item("tsaldo", e.RowIndex).Value = True Then
                            myCommand.Parameters.AddWithValue("?tipo", "CO")
                            gitems.Item("salcorr", e.RowIndex).Value = Moneda(gitems.Item("salfin", e.RowIndex).Value)
                            gitems.Item("salno", e.RowIndex).Value = Moneda(0)
                        Else
                            myCommand.Parameters.AddWithValue("?tipo", "NO")
                            gitems.Item("salno", e.RowIndex).Value = Moneda(gitems.Item("salfin", e.RowIndex).Value)
                            gitems.Item("salcorr", e.RowIndex).Value = Moneda(0)
                        End If
                        Dim cd As String = ""
                        cd = gitems.Item("codigo2", e.RowIndex).Value
                        MiConexion(bda)
                        myCommand.CommandText = " UPDATE selpuc SET tipo_saldo = ?tipo where codigo LIKE CONCAT(LEFT('" & cd & "',(SELECT SUM(nivel1+nivel2) AS s FROM parcontab)),'%') "
                        myCommand.ExecuteNonQuery()
                        Refresh()
                        Cerrar()
                        cmdBuscar_Click(AcceptButton, AcceptButton)
                    End If
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If CInt(cbini.Text) > CInt(cbfin.Text) Then
            MsgBox("Verifique el rango de periodos", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        MiConexion(bda)
        Cerrar()
        generarPDF()
    End Sub
End Class