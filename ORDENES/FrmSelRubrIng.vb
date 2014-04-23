Imports System.IO

Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.Object
Public Class FrmSelRubrIng
    Public fila As Integer

    Private Sub FrmSelRubrIng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lbform.Text = "infCER2" Then
            gitems.Columns("sel").Visible = True
        Else
            gitems.Columns("sel").Visible = False
        End If
        Try
            llenarGrilla()
        Catch ex As Exception
        End Try
        'Dim a As String = Strings.Right(PerActual, 4)
        '   Dim tabla As New DataTable

        '   If Strings.Left(lbcm.Text, 6) = "c.ingc" Then
        '       myCommand.CommandText = " select " & lbcm.Text & ", c.ingc_concepto, c.ingc_cod1, c.ingc_sd,  v.ingv_credito, v.ingv_contrac " _
        '& " from presupuesto" & a & ".ingconcepto c,  presupuesto" & a & ".ingvalores v where c.ingc_cod1= v. ingv_cod1 "
        '       myAdapter.SelectCommand = myCommand
        '       myAdapter.Fill(tabla)
        '       Refresh()
        '       If tabla.Rows.Count = 0 Then
        '           MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
        '           Try
        '               gitems.Rows.Clear()
        '           Catch ex As Exception
        '           End Try
        '           Exit Sub
        '       Else

        '           Dim style As New DataGridViewCellStyle
        '           style.Font = New Font(gitems.Font, FontStyle.Bold)
        '           Try
        '               gitems.Rows.Clear()
        '           Catch ex As Exception
        '           End Try
        '           gitems.RowCount = tabla.Rows.Count + 1
        '           For i = 0 To tabla.Rows.Count - 1
        '               If tabla.Rows(i).Item("ingc_sd") = "S" Then
        '                   gitems.Rows(i).DefaultCellStyle = style
        '               End If
        '               gitems.Item(0, i).Value = tabla.Rows(i).Item("ingc_cod1")
        '               gitems.Item(1, i).Value = tabla.Rows(i).Item(0)
        '               gitems.Item(2, i).Value = UCase(tabla.Rows(i).Item("ingc_concepto"))
        '               gitems.Item(3, i).Value = tabla.Rows(i).Item("ingc_sd")
        '               gitems.Item("deb", i).Value = tabla.Rows(i).Item("ingv_contrac")
        '               gitems.Item("cred", i).Value = tabla.Rows(i).Item("ingv_credito")
        '           Next
        '           With gitems
        '               .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        '               .DefaultCellStyle.BackColor = Color.FloralWhite
        '           End With
        '       End If
        '   Else
        '       myCommand.CommandText = " select " & lbcm.Text & ", c.gasc_concepto, c.gasc_cod1, c.gasc_sd,  v.gasv_credito, v.gasv_contrac " _
        '& " from presupuesto" & a & ".gasconcepto c,  presupuesto" & a & ".gasvalores v where c.gasc_cod1= v. gasv_cod1 "
        '       myAdapter.SelectCommand = myCommand
        '       myAdapter.Fill(tabla)
        '       Refresh()
        '       If tabla.Rows.Count = 0 Then
        '           MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
        '           Try
        '               gitems.Rows.Clear()
        '           Catch ex As Exception
        '           End Try
        '           Exit Sub
        '       Else

        '           Dim style As New DataGridViewCellStyle
        '           style.Font = New Font(gitems.Font, FontStyle.Bold)
        '           Try
        '               gitems.Rows.Clear()
        '           Catch ex As Exception
        '           End Try
        '           gitems.RowCount = tabla.Rows.Count + 1
        '           For i = 0 To tabla.Rows.Count - 1
        '               If tabla.Rows(i).Item("gasc_sd") = "S" Then
        '                   gitems.Rows(i).DefaultCellStyle = style
        '               End If
        '               gitems.Item(0, i).Value = tabla.Rows(i).Item("gasc_cod1")
        '               gitems.Item(1, i).Value = tabla.Rows(i).Item(0)
        '               gitems.Item(2, i).Value = UCase(tabla.Rows(i).Item("gasc_concepto"))
        '               gitems.Item(3, i).Value = tabla.Rows(i).Item("gasc_sd")
        '               gitems.Item("deb", i).Value = tabla.Rows(i).Item("gasv_contrac")
        '               gitems.Item("cred", i).Value = tabla.Rows(i).Item("gasv_credito")
        '               gitems.Item("trb", i).Value = "I"
        '           Next
        '           With gitems
        '               .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        '               .DefaultCellStyle.BackColor = Color.FloralWhite
        '           End With
        '       End If
        '   End If

    End Sub
    Private Sub llenarGrilla()

        Dim a As String = Strings.Right(PerActual, 4)
        Dim tabla As New DataTable

        If r1.Checked = True Then
            myCommand.CommandText = " select c.ingc" & Strings.Mid(lbcm.Text, 7, Strings.Len(lbcm.Text)) & ", c.ingc_concepto, c.ingc_cod1, c.ingc_sd,  v.ingv_credito, v.ingv_contrac " _
    & " from presupuesto" & a & ".ingconcepto c,  presupuesto" & a & ".ingvalores v where c.ingc_cod1= v. ingv_cod1 "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
                Exit Sub
            Else

                Dim style As New DataGridViewCellStyle
                style.Font = New Font(gitems.Font, FontStyle.Bold)
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
                gitems.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    If tabla.Rows(i).Item("ingc_sd") = "S" Then
                        gitems.Rows(i).DefaultCellStyle = style
                    End If
                    gitems.Item(0, i).Value = tabla.Rows(i).Item("ingc_cod1")
                    gitems.Item(1, i).Value = tabla.Rows(i).Item(0)
                    gitems.Item(2, i).Value = UCase(tabla.Rows(i).Item("ingc_concepto"))
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("ingc_sd")
                    gitems.Item("deb", i).Value = tabla.Rows(i).Item("ingv_contrac")
                    gitems.Item("cred", i).Value = tabla.Rows(i).Item("ingv_credito")
                    gitems.Item("trb", i).Value = "I"
                Next
                With gitems
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FloralWhite
                End With
            End If
        Else
            myCommand.CommandText = " select c.gasc" & Strings.Mid(lbcm.Text, 7, Strings.Len(lbcm.Text)) & ", c.gasc_concepto, c.gasc_cod1, c.gasc_sd,  v.gasv_credito, v.gasv_contrac " _
    & " from presupuesto" & a & ".gasconcepto c,  presupuesto" & a & ".gasvalores v where c.gasc_cod1= v. gasv_cod1 "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count = 0 Then
                MsgBox("No existe ningun rubro para mostrar", MsgBoxStyle.Information, "SAE")
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
                Exit Sub
            Else

                Dim style As New DataGridViewCellStyle
                style.Font = New Font(gitems.Font, FontStyle.Bold)
                Try
                    gitems.Rows.Clear()
                Catch ex As Exception
                End Try
                gitems.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    If tabla.Rows(i).Item("gasc_sd") = "S" Then
                        gitems.Rows(i).DefaultCellStyle = style
                    End If
                    gitems.Item(0, i).Value = tabla.Rows(i).Item("gasc_cod1")
                    gitems.Item(1, i).Value = tabla.Rows(i).Item(0)
                    gitems.Item(2, i).Value = UCase(tabla.Rows(i).Item("gasc_concepto"))
                    gitems.Item(3, i).Value = tabla.Rows(i).Item("gasc_sd")
                    gitems.Item("deb", i).Value = tabla.Rows(i).Item("gasv_contrac")
                    gitems.Item("cred", i).Value = tabla.Rows(i).Item("gasv_credito")
                    gitems.Item("trb", i).Value = "G"
                Next
                With gitems
                    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                    .DefaultCellStyle.BackColor = Color.FloralWhite
                End With
            End If
        End If
    End Sub

    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub

    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub
        If gitems.Item(3, mifila).Value() = "S" Then
            MsgBox("No puede seleccionar rubros de niveles altos", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        Select Case lbform.Text
            Case "infCER"
                FrmInfEgreRubro.txtd.Text = gitems.Item(0, fila).Value
                FrmInfEgreRubro.txtnomr.Text = gitems.Item(1, fila).Value
            Case "ingp"
                FrmCIordenes.txtrb1.Text = gitems.Item(0, fila).Value
                FrmCIordenes.txtrb.Text = gitems.Item(1, fila).Value
                FrmCIordenes.txtnomrb.Text = gitems.Item(2, fila).Value
                FrmCIordenes.txtdeb.Text = gitems.Item("cred", fila).Value
                FrmCIordenes.txtcred.Text = gitems.Item("deb", fila).Value
            Case "concB"
                Dim fil As Integer
                fil = Val(lbfila.Text)
                'MsgBox(gitems.Item(0, fila).Value)
                FrmDocConciliaB.gitems.Item(8, fil).Value = gitems.Item(0, fila).Value
            Case "infCER2"
                Dim f As Integer = 0
                FrmInfEgreRubro.grubro.RowCount = 1
                For i = 0 To gitems.RowCount - 1
                    Try
                        If gitems.Item("sel", i).Value = True Then
                            FrmInfEgreRubro.grubro.RowCount = FrmInfEgreRubro.grubro.RowCount + 1
                            FrmInfEgreRubro.grubro.Item("rubro", f).Value = gitems.Item(0, i).Value
                            f = f + 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
        End Select
        Me.Close()
    End Sub

    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub

    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        If cmbbuscar.Text = "" Then
            cmbbuscar.Text = "COD INTERNO"
        End If
        BuscarGrilla(txtcuenta.Text)
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If cmbbuscar.Text = "" Then
                cmbbuscar.Text = "COD INTERNO"
            End If
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub
    Public Sub BuscarGrilla(ByVal cad As String)
        Dim cl As Integer = 0
        Try
            If cmbbuscar.Text = "COD INTERNO" Then
                cl = 0
            ElseIf cmbbuscar.Text = "OTRO CODIGO" Then
                cl = 1
            Else
                cl = 2
            End If

            If cad = "" Then Exit Sub
            cad = UCase(cad)
            For i = fila + 1 To gitems.RowCount - 1
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
            Next
            For i = 0 To fila
                Try
                    If gitems.Item(cl, i).Value.ToString Like "*" & cad & "*" Then
                        Dim C As Integer = cl, F As Integer = i
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

    Private Sub r1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles r1.CheckedChanged

        If r1.Checked = True Then
            Me.Text = "Seleccionar Rubro de INGRESO"
        Else
            Me.Text = "Seleccionar Rubro de GASTOS"
        End If
        Try
            llenarGrilla()

        Catch ex As Exception

        End Try
    End Sub
End Class