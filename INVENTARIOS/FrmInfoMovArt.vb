Imports iTextSharp.text
Imports iTextSharp.text.pdf
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

Public Class FrmInfoMovArt

    Public ent, sal As String

    Private Sub FrmInfoMovArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tabla As New DataTable
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        tabla = New DataTable
        myCommand.CommandText = "select * from parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            ent = tabla.Rows(0).Item("entradas").ToString
            sal = tabla.Rows(0).Item("salidas").ToString
        End If
    End Sub

    Public Function adicionar(ByVal texto As String)
        Dim num As String
        If Len(texto) = 1 Then
            num = "0" & texto
        Else
            num = texto
        End If
        Return num
    End Function

    Public Function extraer_cadena2(ByVal cadena As String, ByVal ti As Integer, ByVal tf As Integer)
        Dim cad As String
        If cadena.Length >= 7 Then
            cad = ""
            For j = ti To tf - 1
                cad = cad & cadena(j)
            Next
        Else
            cad = cadena
        End If
        Return cad
    End Function

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtci.Enabled = True
        Else
            txtci.Enabled = False
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim sql As String = ""
        Dim peri As String = ""

        MiConexion(bda)
        Cerrar()

        Dim tabla2 As New DataTable
        tabla2 = New DataTable

        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        per = "PERIODO INICIAL: " & cbini.Text & "/" & txtpini.Text & " - PERIODO FINAL: " & cbfin.Text & "/" & txtpfin.Text

        Try

            peri = cbfin.Text & "" & txtpfin.Text

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim p As String = " "
            Dim ini As String = (Val(cbini.Text) - 1).ToString
            If Val(ini) < 10 Then ini = "0" & ini

            Dim cant As String = ""
            Dim tablab As DataTable
            tablab = New DataTable
            myCommand.CommandText = "SELECT numbod from bodegas"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablab)

            For i = 0 To tablab.Rows.Count - 1
                If i = 0 Then
                    cant = "(cant" & tablab.Rows(i).Item("numbod").ToString
                Else
                    cant = cant & "+ cant" & tablab.Rows(i).Item("numbod").ToString
                End If
            Next
            cant = cant & ") "


            Dim cod As String = ""
            Dim est As String = ""
            If c2.Checked = True Then
                cod = " AND d.codart = '" & txtci.Text & "' "
            End If
            If d1.Checked = True Then
                est = " AND m.estado = 'AP' "
            End If


            For i = Val(cbini.Text) To Val(cbfin.Text)

                If i < 10 Then

                    p = "0" & i
                Else
                    p = i
                End If
                If p = cbini.Text Then
                    sql = "select d.codart, d.nomart,  d.doc, CONCAT( m.dia,  '/', m.per ) as cta_inv,  d.bod_ori ,  d.bod_des , m.concepto as cta_cos, " _
                      & " IF (d.bod_ori<>0,0,cantidad) as item,IF (d.bod_des<>0,0,cantidad) as cantidad, d.valor as cta_ing,IF(d.bod_ori<>0,0,(cantidad *d.valor)) as valor, IF(d.bod_des<>0,0,(cantidad *d.valor)) as costo,  " _
                      & "(SELECT SUM" & cant & " FROM `con_inv` WHERE periodo='" & ini & "' AND codart= d.`codart` GROUP BY codart ) AS cta_iva " _
                      & " FROM deta_mov" & p & "  d , movimientos" & p & "  m " _
                      & " WHERE d . doc =m.doc " & cod & " " & est & " "
                Else
                    sql = sql & " UNION select d.codart, d.nomart,  d.doc, CONCAT( m.dia,  '/', m.per ) as cta_inv,  d.bod_ori ,  d.bod_des , m.concepto as cta_cos, " _
                          & " IF (d.bod_ori<>0,0,cantidad) as item,IF (d.bod_des<>0,0,cantidad) as cantidad, d.valor as cta_ing,IF(d.bod_ori<>0,0,(cantidad *d.valor)) as valor, IF(d.bod_des<>0,0,(cantidad *d.valor)) as costo, " _
                        & "(SELECT SUM" & cant & " FROM `con_inv` WHERE periodo='" & ini & "' AND codart= d.`codart` GROUP BY codart ) AS cta_iva " _
                        & " FROM deta_mov" & p & "  d , movimientos" & p & "  m " _
                          & " WHERE d. doc =m.doc" & cod & " " & est & "  "
                End If
            Next
            sql = sql & " ORDER BY codart;"
            TextBox1.Text = sql


            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportMovArt.rpt")
            CrReport.SetDataSource(tabla)
            Try
                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
            Catch ex As Exception
            End Try
            FrmRepMovArt.CrystalReportViewer1.ReportSource = CrReport


            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField


                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "periodo"
                Prperiodo.CurrentValues.AddValue(per.ToString)


                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)


                FrmRepMovArt.CrystalReportViewer1.ParameterFieldInfo = prmdatos

            Catch ex As Exception
                MsgBox(sql)
            End Try

        Catch ex As Exception
            ' MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
        FrmRepMovArt.ShowDialog()
    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        ct = 62
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    
    Private Sub txtci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtci.TextChanged

    End Sub
End Class