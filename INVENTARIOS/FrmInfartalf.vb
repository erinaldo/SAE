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

Public Class FrmInfartalf

    Public col As New Integer
    Public vec(5) As Integer

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txtcf.Enabled = True
            txtci.Enabled = True
        Else
            txtcf.Enabled = False
            txtci.Enabled = False
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        'mostrar_PDF()

        Try

       

            Dim nit As String = ""
            Dim nom As String = ""
            Dim sql As String = ""
            Dim p As String = ""
            Dim pt As String = ""
            Dim j As String = ""
            Dim cant As String = ""
            Dim sql2 As String = ""
            Dim psql2 As String = ""

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable

            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = tabla2.Rows(0).Item("nit")


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            sql2 = " Select p.desc1 FROM parinven p "

            Dim tabla3 As New DataTable
            tabla3 = New DataTable
            myCommand.CommandText = sql2
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla3)

            psql2 = tabla3.Rows(0).Item(0).ToString


            Dim tablab As DataTable
            tablab = New DataTable
            myCommand.CommandText = "SELECT numbod from bodegas"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablab)

            For i = 0 To tablab.Rows.Count - 1
                If i = 0 Then
                    cant = "(c.cant" & tablab.Rows(i).Item("numbod").ToString
                Else
                    cant = cant & "+ c.cant" & tablab.Rows(i).Item("numbod").ToString
                End If
            Next
            cant = cant & ") "


            '////////////////////////////////
            '///////////////////////// ORDENAR POR CODIGO
            If O1.Checked = True Then

                If c1.Checked = True Then '---------------------- TODOS LOS CODIGOS

                    If i1.Checked = True Then  ' ---------------------- SIN CANTI

                        If l1.Checked = True Then

                            sql = " SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel " _
                           & "FROM articulos a  WHERE(a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                           & "ORDER BY codart "


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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos.CrystalReportViewer1.ReportSource = CrReport


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
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArticulos.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try
                        End If

                        If l2.Checked = True Then

                            p = cbini.Text

                            sql = "select  a.codart,a.nomart, '' as referencia, '' as codbar, NULL as unidad, NULL as empaque, a.nivel as nivel, NULL as can" _
                           & " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                           & " SELECT a.codart, a.nomart, a.referencia as referencia, a.codbar as codbar, a.unidad as unidad , a.empaque as empaque, a.nivel as nivel, " & cant & "  as can" _
                           & " FROM articulos a, con_inv c  WHERE a.codart = c.codart AND " & cant & " <> 0 AND c.periodo =  '" & p & "' " _
                           & "ORDER BY codart  "

                            ' sql = " SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel " _
                            '& "FROM articulos a  WHERE(a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p )) and and " & cant & " <>0 " _
                            '& "ORDER BY codart  "


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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos.CrystalReportViewer1.ReportSource = CrReport


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
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArticulos.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try
                        End If


                    End If  ' -------------------- FIN SIN CANT


                    ' ---------------- CON CANTI
                    If i2.Checked = True Then

                        If l1.Checked = True Then  ' ------------ Todos los articulos

                            p = cbini.Text

                            Dim cantd As String = ""
                            Dim cantd2 As String = ""
                            Dim tcan As String = ""

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    cantd2 = cantd2 & " NULL AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "

                                End If
                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)
                            cantd2 = Strings.Left(cantd2, cantd2.Length - 2)


                            sql = " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd2 & ", NULL as otro, NULL AS costuni, a.nivel as cue_cos " _
                            & " FROM articulos a WHERE  a.nivel =( Select p.desc1 FROM parinven p )  " _
                            & " UNION " _
                            & " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel as cue_cos " _
                            & "FROM articulos a, con_inv c WHERE  a.codart = c.codart AND c.periodo = '" & p & "' " _
                            & " ORDER BY codart"

                            'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            '& "FROM articulos a, con_inv c WHERE  a.codart = c.codart AND c.periodo = '" & p & "' " _
                            '& " ORDER BY codart"
                            ' sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            '& "FROM articulos a LEFT JOIN con_inv c ON ( a.codart = c.codart ) AND c.periodo = '" & p & "' " _
                            '& "WHERE ( a.nivel) IN (( Select p.desc1 FROM parinven p), (Select p.desc6 FROM parinven p))ORDER BY codart"


                            TextBox1.Text = sql
                            ' TextBox2.Text = cantd


                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos2.CrystalReportViewer1.ReportSource = CrReport

                            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField



                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields
                                Dim Prsql As New ParameterField

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)

                                Prsql.Name = "sql2"
                                Prsql.CurrentValues.AddValue(psql2.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)
                                prmdatos.Add(Prsql)

                                FrmGenArticulos2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If



                        If l2.Checked = True Then '///////////// Articulos con existencia


                            Dim cantd As String = ""
                            Dim cantd2 As String = ""
                            Dim tcan As String = ""
                            Dim fcant As String = ""

                            p = cbini.Text

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("
                            fcant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    cantd2 = cantd2 & " NULL AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "
                                    If x = 1 Then
                                        fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " IS NULL OR "
                                    Else
                                        fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR "
                                    End If



                                End If

                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)
                            fcant = Strings.Left(fcant, fcant.Length - 4) & ") "
                            cantd2 = Strings.Left(cantd2, cantd2.Length - 2)



                            sql = " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd2 & ", NULL as otro, NULL AS costuni, a.nivel as cue_cos " _
                            & " FROM articulos a WHERE  a.nivel =( Select p.desc1 FROM parinven p )  " _
                            & " UNION " _
                            & " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel as cue_cos " _
                            & "FROM articulos a, con_inv c WHERE  a.codart = c.codart AND c.periodo = '" & p & "' " _
                            & "  AND " & fcant & " ORDER BY codart"



                            'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            '& "FROM articulos a, con_inv c WHERE  a.codart = c.codart AND c.periodo = '" & p & "' " _
                            '& " AND " & fcant & " ORDER BY codart"

                            'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            '& "FROM articulos a LEFT JOIN con_inv c ON ( a.codart = c.codart ) AND c.periodo = '" & p & "' " _
                            '& "WHERE ( a.nivel) IN (( Select p.desc1 FROM parinven  p ), (Select p.desc6 FROM parinven  p  )) " _
                            '& " AND " & fcant & "  ORDER BY codart"


                            TextBox1.Text = sql

                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos2.CrystalReportViewer1.ReportSource = CrReport


                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField
                                Dim Prsql As New ParameterField


                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)

                                Prsql.Name = "sql2"
                                Prsql.CurrentValues.AddValue(psql2.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)
                                prmdatos.Add(Prsql)

                                FrmGenArticulos2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If
                    End If ' --------------FIN-- CON CANTI



                    ' ----------------- CON CANTI y VALORES
                    If i3.Checked = True Then

                        If l1.Checked = True Then ' //////////////////// Todos los articulos



                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                            sql = "select a.nomart, a.codart, a.nivel, NULL as can_emp, NULL as cos_uni, NULL as cos_pro, NULL as precio " _
                            & " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                            & " Select  a.nomart, a.codart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                            & "  WHERE a.codart = c.codart " _
                            & " AND c.periodo =  '" & p & "' " _
                            & " ORDER BY codart "

                            'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                            '& " ON (a.codart = c.codart) " _
                            '& " AND c.periodo =  '" & p & "' " _
                            '& " WHERE (a.nivel) IN (( Select p.desc1 FROM parinven p ),( Select p.desc6 FROM parinven p )) " _
                            ' & " ORDER BY codart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt3.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos3.CrystalReportViewer1.ReportSource = CrReport

                            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prsql As New ParameterField


                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prsql.Name = "sql2"
                                Prsql.CurrentValues.AddValue(psql2.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prsql)

                                FrmGenArticulos3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos3.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If ' fin todos los art


                        ' ///////////////// Solo existencia /////////////////
                        If l2.Checked = True Then
                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                            sql = "select a.nomart, a.codart, a.nivel, NULL as can_emp, NULL as cos_uni, NULL as cos_pro, NULL as precio " _
                           & " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                           & " Select  a.nomart, a.codart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                           & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                           & "  WHERE a.codart = c.codart AND " & cant & " <> 0" _
                           & " AND c.periodo =  '" & p & "' " _
                           & " ORDER BY codart "

                            'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                            '& " ON (a.codart = c.codart) " _
                            '& " AND c.periodo =  '" & p & "' " _
                            '& " WHERE " & cant & " <> 0 OR " & cant & " IS NULL AND " _
                            '& "(a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                            '& "ORDER BY codart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt3.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos3.CrystalReportViewer1.ReportSource = CrReport

                            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prsql As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prsql.Name = "sql2"
                                Prsql.CurrentValues.AddValue(psql2.ToString)

                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prsql)

                                FrmGenArticulos3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos3.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try


                        End If ' fin solo mov


                    End If ' --------------FIN-- CON CANTI y VALORES

                End If
                '------------------FIN TODOS LOS CODIGOS

                '///////////////////////////////////////////////////////
                '////////////////// RANGO DE CODIGOS //////////////////

                If c2.Checked = True Then


                    If i1.Checked = True Then  ' -------------- SIN Cantidades ni valores 

                        If l1.Checked = True Then

                            Dim tt As String = ""

                            sql = "SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel FROM articulos a " _
                            & " WHERE  (a.nivel) IN ((SELECT p.desc1 FROM parinven p), (SELECT p.desc6 FROM parinven p )) " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & "  ORDER BY codart"


                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef.CrystalReportViewer1.ReportSource = CrReport

                            tt = "INFORME GENERAL DE ARTICULOS"

                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtt As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)

                                Prtt.Name = "titulo"
                                Prtt.CurrentValues.AddValue(tt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtt)

                                FrmRepKarRef.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                            TextBox1.Text = sql

                        End If

                        If l2.Checked = True Then

                            Dim tt As String = ""

                            p = cbini.Text


                            sql = "SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel, NULL as can FROM articulos a " _
                            & " WHERE  a.nivel = (SELECT p.desc1 FROM parinven p) AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "')  UNION " _
                            & "SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel, " & cant & " as can FROM articulos a,  con_inv c " _
                            & " WHERE a.codart = c.codart AND " & cant & " <> 0 AND c.periodo =  '" & p & "' " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " ORDER BY codart"

                            '  sql = "select  a.codart,a.nomart, '' as referencia, '' as codbar, NULL as unidad, NULL as empaque, a.nivel as nivel, NULL as can" _
                            '& " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                            '& " SELECT a.codart, a.nomart, a.referencia as referencia, a.codbar as codbar, a.unidad as unidad , a.empaque as empaque, a.nivel as nivel, " & cant & "  as can" _
                            '& " FROM articulos a, con_inv c  WHERE a.codart = c.codart AND " & cant & " <> 0 AND c.periodo =  '" & p & "' " _
                            '& "ORDER BY codart  "

                            'sql = "SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel FROM articulos a " _
                            '& " WHERE  (a.nivel) IN ((SELECT p.desc1 FROM parinven p), (SELECT p.desc6 FROM parinven p )) " _
                            '& " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            '& "  ORDER BY codart"


                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef.CrystalReportViewer1.ReportSource = CrReport

                            tt = "INFORME GENERAL DE ARTICULOS"

                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtt As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)

                                Prtt.Name = "titulo"
                                Prtt.CurrentValues.AddValue(tt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtt)

                                FrmRepKarRef.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                            TextBox1.Text = sql

                        End If


                    End If  ' -------------- FIN SIN  Cantidades ni valores 


                    ' --------------  CON VALORES
                    If i2.Checked = True Then

                        p = cbini.Text
                        pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


                        ' Todos los articulos
                        If l1.Checked = True Then


                            Dim cantd As String = ""
                            Dim cantd2 As String = ""
                            Dim tcan As String = ""

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    cantd2 = cantd2 & "NULL AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "

                                End If



                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)
                            cantd2 = Strings.Left(cantd2, cantd2.Length - 2)

                            sql = " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd2 & ", NULL as otro, NULL AS costuni, a.nivel " _
                            & " FROM articulos a WHERE  a.nivel =( Select p.desc1 FROM parinven p ) AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " UNION " _
                            & "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel " _
                            & "FROM articulos a, con_inv c WHERE  a.codart = c.codart  AND c.periodo = '" & p & "' " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " ORDER BY codart"



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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef2.CrystalReportViewer1.ReportSource = CrReport

                            '%%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)

                                FrmRepKarRef2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If

                        '///////////// Articulos con existencia

                        If l2.Checked = True Then


                            Dim cantd As String = ""
                            Dim cantd2 As String = ""
                            Dim tcan As String = ""
                            Dim fcant As String = ""

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("
                            fcant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    cantd2 = cantd2 & "NULL AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "
                                    If x = 1 Then
                                        fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " IS NULL OR "
                                    Else
                                        fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR "
                                    End If



                                End If



                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)
                            cantd2 = Strings.Left(cantd2, cantd2.Length - 2)
                            fcant = Strings.Left(fcant, fcant.Length - 4) & ") "


                            sql = " Select a.codart AS codart , a.nomart AS cue_inv, " & cantd2 & ", NULL as otro, NULL AS costuni, a.nivel " _
                           & " FROM articulos a WHERE  a.nivel =( Select p.desc1 FROM parinven p ) AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                           & " UNION " _
                           & "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel " _
                           & "FROM articulos a,  con_inv c WHERE a.codart = c.codart  AND c.periodo = '" & p & "' " _
                           & " AND " & fcant & " " _
                           & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                           & " ORDER BY codart"


                            TextBox1.Text = sql

                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef2.CrystalReportViewer1.ReportSource = CrReport


                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)

                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)

                                FrmRepKarRef2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If
                    End If
                    ' ------------- FIN con Cantidad

                    ' ------------ Con cantidades y valores
                    If i3.Checked = True Then

                        ' //////////////////// Todos los articulos
                        If l1.Checked = True Then

                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


                            sql = " Select a.codart, a.nomart, a.nivel, NULL AS can_emp, NULL as cos_uni, " _
                            & " NULL as cos_pro, NULL AS precio FROM articulos a " _
                            & " WHERE a.nivel = ( Select p.desc1 FROM parinven p ) " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " UNION " _
                            & " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                            & " WHERE a.codart = c.codart " _
                            & " AND c.periodo =  '" & p & "' " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & "ORDER BY codart"

                            'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                            '& " ON (a.codart = c.codart) " _
                            '& " AND c.periodo =  '" & p & "' " _
                            '& " WHERE (a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                            '& " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            '& "ORDER BY codart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef3.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef3.CrystalReportViewer1.ReportSource = CrReport

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
                                Prperiodo.CurrentValues.AddValue(pt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmRepKarRef3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef3.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If


                        ' ///////////////// Solo existencia /////////////////
                        If l2.Checked = True Then


                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString



                            sql = " Select a.codart, a.nomart, a.nivel, NULL AS can_emp, NULL as cos_uni, " _
                            & " NULL as cos_pro, NULL AS precio FROM articulos a " _
                            & " WHERE a.nivel = ( Select p.desc1 FROM parinven p ) " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " UNION " _
                            & " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                            & " WHERE a.codart = c.codart " _
                            & " AND c.periodo =  '" & p & "' " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " AND " & cant & " <> 0  " _
                            & "ORDER BY codart"

                            'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                            '& " WHERE a.codart = c.codart " _
                            '& " AND c.periodo =  '" & p & "' " _
                            '& "  AND a.codart BETWEEN ( '" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            '& " AND " & cant & " <> 0 OR " & cant & " IS NULL AND " _
                            '& "ORDER BY codart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportKarRef3.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmRepKarRef3.CrystalReportViewer1.ReportSource = CrReport

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
                                Prperiodo.CurrentValues.AddValue(pt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmRepKarRef3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmRepKarRef3.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try
                        End If
                    End If

                End If
                '///////////////////////////////////////////////////////
                '////////////// FIN RANGO DE CODIGOS //////////////////
            End If
            '/////////////////// FIN  ORDENAR POR CODIGO


            ''////////////////////////////////
            ''///////////////////////// ORDENAR POR NOMBRE
            If O2.Checked = True Then

                '///////////////////////  TODOS LOS CODIGOS
                If c1.Checked = True Then

                    If i1.Checked = True Then  ' ---------------------- SIN CANTI

                        If l1.Checked = True Then


                            sql = " SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel " _
                            & "FROM articulos a  WHERE(a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                            & "ORDER BY nomart"


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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos.CrystalReportViewer1.ReportSource = CrReport


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
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArticulos.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        End If

                        If l2.Checked = True Then

                            p = cbini.Text


                            sql = " SELECT a.codart, a.nomart, a.referencia as referencia, a.codbar as codbar, a.unidad as unidad , a.empaque as empaque, a.nivel as nivel, " & cant & "  as can" _
                          & " FROM articulos a, con_inv c  WHERE a.codart = c.codart AND " & cant & " <> 0 AND c.periodo =  '" & p & "' " _
                          & "ORDER BY nomart  "

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos.CrystalReportViewer1.ReportSource = CrReport


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
                                Prperiodo.CurrentValues.AddValue(PerActual.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArticulos.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try


                        End If



                    End If  ' --------------------- FIN - SIN CANTI

                    '///////////////////////////////////////////////////////
                    If i2.Checked = True Then ' ---------------------- CON CANTI

                        If l1.Checked = True Then ' -------------- Todos los articulos

                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                            Dim cantd As String = ""
                            Dim tcan As String = ""

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "

                                End If
                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)


                            sql = "Select c.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel as cue_cos " _
                            & "FROM articulos a, con_inv c WHERE  a.codart = c.codart  AND c.periodo = '" & p & "' " _
                            & " ORDER BY nomart"


                            TextBox1.Text = sql
                            ' TextBox2.Text = cantd

                            Dim tabla As DataTable
                            tabla = New DataTable
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = sql
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)

                            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos2.CrystalReportViewer1.ReportSource = CrReport

                            ' %%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField
                                Dim Prsql As New ParameterField

                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)

                                Prsql.Name = "sql2"
                                Prsql.CurrentValues.AddValue(psql2.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)
                                prmdatos.Add(Prsql)

                                FrmGenArticulos2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        Else

                            If l2.Checked = True Then ' -------------- Articulos con Exist

                                Dim cantd As String = ""
                                Dim tcan As String = ""
                                Dim fcant As String = ""

                                p = cbini.Text
                                pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                                Dim tablabb As DataTable
                                tablabb = New DataTable
                                myCommand.CommandText = "SELECT numbod from bodegas"
                                myCommand.Connection = conexion
                                myAdapter.SelectCommand = myCommand
                                myAdapter.Fill(tablabb)

                                Dim x As Integer = 0

                                cant = "("
                                fcant = "("


                                For l = 0 To tablab.Rows.Count - 1


                                    If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                        x = x + 1

                                        cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                        cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                        tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "
                                        If x = 1 Then
                                            fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " IS NULL OR "
                                        Else
                                            fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR "
                                        End If

                                    End If

                                Next
                                cant = Strings.Left(cant, cant.Length - 1) & ") "
                                cantd = Strings.Left(cantd, cantd.Length - 2)
                                fcant = Strings.Left(fcant, fcant.Length - 4) & ") "

                                sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni, a.nivel as cue_cos " _
                               & "FROM articulos a, con_inv c where  a.codart = c.codart  AND c.periodo = '" & p & "' " _
                                & " AND " & fcant & "  ORDER BY nomart"
                                'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                                '& "FROM articulos a LEFT JOIN con_inv c ON ( a.codart = c.codart ) AND c.periodo = '" & p & "' " _
                                '& "WHERE ( a.nivel) IN (( Select p.desc1 FROM parinven p), (Select p.desc6 FROM parinven p)) " _
                                '& " AND " & fcant & "  ORDER BY nomart"


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

                                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt2.rpt")
                                CrReport.SetDataSource(tabla)
                                Try
                                    CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                                Catch ex As Exception
                                End Try
                                FrmGenArticulos2.CrystalReportViewer1.ReportSource = CrReport


                                Try
                                    Dim Prcompañia As New ParameterField
                                    Dim PrNit As New ParameterField
                                    Dim Prperiodo As New ParameterField
                                    Dim Prtitulo As New ParameterField
                                    Dim Prsql As New ParameterField

                                    Dim prmdatos As ParameterFields
                                    prmdatos = New ParameterFields

                                    Prcompañia.Name = "comp"
                                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                                    PrNit.Name = "nit"
                                    PrNit.CurrentValues.AddValue(nit.ToString)

                                    Prperiodo.Name = "periodo"
                                    Prperiodo.CurrentValues.AddValue(pt.ToString)

                                    Prtitulo.Name = "No1"
                                    Prtitulo.CurrentValues.AddValue(tcan.ToString)

                                    Prsql.Name = "sql2"
                                    Prsql.CurrentValues.AddValue(psql2.ToString)


                                    prmdatos.Add(Prcompañia)
                                    prmdatos.Add(PrNit)
                                    prmdatos.Add(Prperiodo)
                                    prmdatos.Add(Prtitulo)
                                    prmdatos.Add(Prsql)

                                    FrmGenArticulos2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                    FrmGenArticulos2.ShowDialog()

                                Catch ex As Exception
                                    MsgBox(sql)
                                End Try

                            End If ' ------------FIN-- Articulos con Exist

                        End If ' ------------FIN-- Todos los articulos

                    End If ' ---------------------- CON CANTI
                    '///////////////////////////////////////////////////////////


                    '///////////////////////////////////////////////////////////
                    '     ----------------- CON CANTI y VALORES
                    If i3.Checked = True Then

                        If l1.Checked = True Then ' -------------- Todos los articulos

                            p = cbini.Text
                            pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                            sql = "select a.nomart, a.codart, a.nivel, 0 as can_emp, 0 as cos_uni, 0 as cos_pro, 0 as precio " _
                           & " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                           & " Select  a.nomart, a.codart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                           & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                           & "  WHERE a.codart = c.codart " _
                           & " AND c.periodo =  '" & p & "' " _
                           & " ORDER BY nomart "

                            'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                            '& " ON (a.codart = c.codart) " _
                            '& " AND c.periodo =  '" & p & "' " _
                            '& " WHERE (a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                            ' & "ORDER BY nomart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt33.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                            Catch ex As Exception
                            End Try
                            FrmGenArticulos33.CrystalReportViewer1.ReportSource = CrReport

                            ' %%%%%%%%%%%%%%%%       enviar parametros segun consulta
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
                                Prperiodo.CurrentValues.AddValue(pt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArticulos33.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArticulos33.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try


                        Else

                            If l2.Checked = True Then ' ------------- Articulos con Exist

                                p = cbini.Text
                                pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                                sql = "select a.nomart, a.codart, a.nivel, 0 as can_emp, 0 as cos_uni, 0 as cos_pro, 0 as precio " _
                           & " FROM articulos a where a.nivel =( Select p.desc1 FROM parinven p ) UNION " _
                           & " Select  a.nomart, a.codart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                           & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                           & "  WHERE a.codart = c.codart AND " & cant & " <> 0" _
                           & " AND c.periodo =  '" & p & "' " _
                           & " ORDER BY nomart "

                                'sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                                '& " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                                '& " ON (a.codart = c.codart) " _
                                '& " AND c.periodo =  '" & p & "' " _
                                '& " WHERE " & cant & " <> 0 OR " & cant & " IS NULL AND " _
                                '& "(a.nivel)IN (( Select p.desc1 FROM parinven p ), ( Select p.desc6 FROM parinven p ))" _
                                '& "ORDER BY nomart"

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

                                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArt33.rpt")
                                CrReport.SetDataSource(tabla)
                                Try
                                    CrReport.PrintOptions.PaperSize = PaperSize.PaperLetter
                                Catch ex As Exception
                                End Try
                                FrmGenArticulos33.CrystalReportViewer1.ReportSource = CrReport

                                ' %%%%%%%%%%%%%%%%       enviar parametros segun consulta
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
                                    Prperiodo.CurrentValues.AddValue(pt.ToString)


                                    prmdatos.Add(Prcompañia)
                                    prmdatos.Add(PrNit)
                                    prmdatos.Add(Prperiodo)

                                    FrmGenArticulos33.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                    FrmGenArticulos33.ShowDialog()

                                Catch ex As Exception
                                    MsgBox(sql)
                                End Try


                            End If ' ------------FIN-- Articulos con Exist

                        End If ' ------------FIN-- Todos los articulos

                    End If '     ----------------- CON CANTI y VALORES
                    '///////////////////////////////////////////////////////////


                End If
                '///////////////// FIN TODOS LOS CODIGOS


                ' //////////////////////////////////////////////
                ''     ///////////////////// POR RANGO D REFERENCIA ///////////////////
                If c2.Checked = True Then

                    If i1.Checked = True Then ' -------------- SIN Cantidades ni valores 
                        sql = "SELECT a.codart, a.nomart, a.referencia, a.codbar, a.unidad, a.empaque, a.nivel FROM articulos a " _
                        & " WHERE   " _
                        & "  a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                         & " AND  (a.nivel) IN ((SELECT p.desc1 FROM parinven p), (SELECT p.desc6 FROM parinven p )) " _
                         & "  ORDER BY nomart"

                        Dim tabla As DataTable
                        tabla = New DataTable
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = sql
                        myCommand.Connection = conexion
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla)

                        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

                        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArtRN.rpt")
                        CrReport.SetDataSource(tabla)
                        Try
                            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                        Catch ex As Exception
                        End Try
                        FrmGenArtRN.CrystalReportViewer1.ReportSource = CrReport



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
                            Prperiodo.CurrentValues.AddValue(PerActual.ToString)


                            prmdatos.Add(Prcompañia)
                            prmdatos.Add(PrNit)
                            prmdatos.Add(Prperiodo)

                            FrmGenArtRN.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                            FrmGenArtRN.ShowDialog()

                        Catch ex As Exception
                            MsgBox(sql)
                        End Try

                        TextBox1.Text = sql


                    End If ' ------------- FIN - SIN Cantidades ni valores 



                    If i2.Checked = True Then  ' --------------- Con Cantidades

                        p = cbini.Text
                        pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                        If l1.Checked = True Then '............. Todos los Arti

                            Dim cantd As String = ""
                            Dim cantd2 As String = ""
                            Dim tcan As String = ""

                            Dim tablabb As DataTable
                            tablabb = New DataTable
                            myCommand.CommandText = "SELECT numbod from bodegas"
                            myCommand.Connection = conexion
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tablabb)

                            Dim x As Integer = 0

                            cant = "("


                            For l = 0 To tablab.Rows.Count - 1


                                If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                    x = x + 1

                                    cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                    cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                    cantd2 = cantd2 & "NULL AS cant" & x & ", "
                                    tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "

                                End If



                            Next
                            cant = Strings.Left(cant, cant.Length - 1) & ") "
                            cantd = Strings.Left(cantd, cantd.Length - 2)
                            cantd2 = Strings.Left(cantd2, cantd2.Length - 2)

                            'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd2 & ", NULL AS otro ,NULL AS costuni " _
                            '& "FROM articulos a  " _
                            '& "WHERE  a.nivel =( Select p.desc1 FROM parinven p) " _
                            '& " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            '& " UNION " _
                            sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            & "FROM articulos a, con_inv c WHERE a.codart = c.codart  AND c.periodo = '" & p & "' " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & " ORDER BY nomart"

                            'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                            '& "FROM articulos a LEFT JOIN con_inv c ON ( a.codart = c.codart ) AND c.periodo = '" & p & "' " _
                            '& "WHERE ( a.nivel) IN (( Select p.desc1 FROM parinven p), (Select p.desc6 FROM parinven p)) " _
                            '& " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            '& " ORDER BY codart"



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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArtRN2.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                            Catch ex As Exception
                            End Try
                            FrmGenArtRN2.CrystalReportViewer1.ReportSource = CrReport

                            '   %%%%%%%%%%%%%%%%       enviar parametros segun consulta
                            Try
                                Dim Prcompañia As New ParameterField
                                Dim PrNit As New ParameterField
                                Dim Prperiodo As New ParameterField
                                Dim Prtitulo As New ParameterField



                                Dim prmdatos As ParameterFields
                                prmdatos = New ParameterFields

                                Prcompañia.Name = "comp"
                                Prcompañia.CurrentValues.AddValue(nom.ToString)

                                PrNit.Name = "nit"
                                PrNit.CurrentValues.AddValue(nit.ToString)

                                Prperiodo.Name = "periodo"
                                Prperiodo.CurrentValues.AddValue(pt.ToString)

                                Prtitulo.Name = "No1"
                                Prtitulo.CurrentValues.AddValue(tcan.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)
                                prmdatos.Add(Prtitulo)

                                FrmGenArtRN2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArtRN2.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try

                        Else
                            If l2.Checked = True Then '.............Arti con exist

                                Dim cantd As String = ""
                                Dim tcan As String = ""
                                Dim fcant As String = ""

                                Dim tablabb As DataTable
                                tablabb = New DataTable
                                myCommand.CommandText = "SELECT numbod from bodegas"
                                myCommand.Connection = conexion
                                myAdapter.SelectCommand = myCommand
                                myAdapter.Fill(tablabb)

                                Dim x As Integer = 0

                                cant = "("
                                fcant = "("


                                For l = 0 To tablab.Rows.Count - 1


                                    If FrmLisBodegas.gitems.Item(1, l).Value = "SI" Then

                                        x = x + 1

                                        cant = cant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "+"
                                        cantd = cantd & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " AS cant" & x & ", "
                                        tcan = tcan & "   No " & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & "    "
                                        If x = 1 Then
                                            fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " IS NULL OR "
                                        Else
                                            fcant = fcant & "c.cant" & CInt(FrmLisBodegas.gitems.Item(0, l).Value) & " <> 0 OR "
                                        End If
                                    End If
                                Next

                                cant = Strings.Left(cant, cant.Length - 1) & ") "
                                cantd = Strings.Left(cantd, cantd.Length - 2)
                                fcant = Strings.Left(fcant, fcant.Length - 4) & ") "

                                'sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                                '& "FROM articulos a LEFT JOIN con_inv c ON ( a.codart = c.codart ) AND c.periodo = '" & p & "' " _
                                '& "WHERE ( a.nivel) IN (( Select p.desc1 FROM parinven p), (Select p.desc6 FROM parinven p)) " _
                                '& " AND " & fcant & " " _
                                '& " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                                '& " ORDER BY nomart"

                                sql = "Select a.codart AS codart , a.nomart AS cue_inv, " & cantd & ", IFNULL( " & cant & ", 0 ) AS otro ,a.uni_emp AS costuni " _
                                & "FROM articulos a, con_inv c WHERE  a.codart = c.codart  AND c.periodo = '" & p & "' " _
                                & " AND " & fcant & " " _
                                & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                                & " ORDER BY nomart"


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

                                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArtRN2.rpt")
                                CrReport.SetDataSource(tabla)
                                Try
                                    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                                Catch ex As Exception
                                End Try
                                FrmGenArtRN2.CrystalReportViewer1.ReportSource = CrReport


                                Try
                                    Dim Prcompañia As New ParameterField
                                    Dim PrNit As New ParameterField
                                    Dim Prperiodo As New ParameterField
                                    Dim Prtitulo As New ParameterField



                                    Dim prmdatos As ParameterFields
                                    prmdatos = New ParameterFields

                                    Prcompañia.Name = "comp"
                                    Prcompañia.CurrentValues.AddValue(nom.ToString)

                                    PrNit.Name = "nit"
                                    PrNit.CurrentValues.AddValue(nit.ToString)

                                    Prperiodo.Name = "periodo"
                                    Prperiodo.CurrentValues.AddValue(pt.ToString)

                                    Prtitulo.Name = "No1"
                                    Prtitulo.CurrentValues.AddValue(tcan.ToString)


                                    prmdatos.Add(Prcompañia)
                                    prmdatos.Add(PrNit)
                                    prmdatos.Add(Prperiodo)
                                    prmdatos.Add(Prtitulo)

                                    FrmGenArtRN2.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                    FrmGenArtRN2.ShowDialog()

                                Catch ex As Exception
                                    MsgBox(sql)
                                End Try

                            End If '..........Fin ...Arti con exist

                        End If '.........Fin... Todos los Arti
                    End If ' -----------FIN-- Con Cantidades


                    '         ---------------------- Valores y Cantidad FFFF
                    If i3.Checked = True Then

                        p = cbini.Text
                        pt = cbini.Text & "/" & PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

                        If l1.Checked = True Then ' ........ Todos los Articulos


                            sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                            & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a, con_inv c " _
                            & " WHERE a.codart = c.codart " _
                            & " AND c.periodo =  '" & p & "' " _
                            & " AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                            & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                            & "ORDER BY nomart"

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

                            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArtRN3.rpt")
                            CrReport.SetDataSource(tabla)
                            Try
                                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                            Catch ex As Exception
                            End Try
                            FrmGenArtRN3.CrystalReportViewer1.ReportSource = CrReport

                            ' %%%%%%%%%%%%%%%%       enviar parametros segun consulta
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
                                Prperiodo.CurrentValues.AddValue(pt.ToString)


                                prmdatos.Add(Prcompañia)
                                prmdatos.Add(PrNit)
                                prmdatos.Add(Prperiodo)

                                FrmGenArtRN3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                FrmGenArtRN3.ShowDialog()

                            Catch ex As Exception
                                MsgBox(sql)
                            End Try


                        Else
                            If l2.Checked = True Then ' .............. Art con exist

                                sql = " Select a.codart, a.nomart, a.nivel," & cant & " AS can_emp, c.costuni as cos_uni, " _
                                & " c.costprom as cos_pro, ( c.costuni * " & cant & " ) AS precio FROM articulos a LEFT JOIN con_inv c " _
                                & " ON (a.codart = c.codart) " _
                                & " AND c.periodo =  '" & p & "'  WHERE " & cant & " <> 0 " _
                                & " AND a.nivel = ( Select p.desc6 FROM parinven p ) " _
                                & " AND a.codart BETWEEN ('" & txtci.Text & "')  AND ('" & txtcf.Text & "') " _
                                & "ORDER BY nomart"

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

                                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportGenArtRN3.rpt")
                                CrReport.SetDataSource(tabla)
                                Try
                                    CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                                Catch ex As Exception
                                End Try
                                FrmGenArtRN3.CrystalReportViewer1.ReportSource = CrReport

                                ' %%%%%%%%%%%%%%%%       enviar parametros segun consulta
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
                                    Prperiodo.CurrentValues.AddValue(pt.ToString)


                                    prmdatos.Add(Prcompañia)
                                    prmdatos.Add(PrNit)
                                    prmdatos.Add(Prperiodo)

                                    FrmGenArtRN3.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                                    FrmGenArtRN3.ShowDialog()

                                Catch ex As Exception
                                    MsgBox(sql)
                                End Try



                            End If ' ............FIN.. Art con exist

                        End If ' ......FIN.. Todos los Articulos

                    End If '         ------------------FIN ---- Valores y Cantidad FFFF


                End If
                ''    /////////////////////////////// FIN RANGO REFERENCIA
            End If
            ''////////////////////////////////
            ''//////////////////// FIN ///// ORDENAR POR NOMBRE

        Catch ex As Exception
        End Try

    End Sub

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2 As String
        Dim i, j, k, pag, med, niv, pv As Integer
        Dim scan, sum1 As Double
        Dim tabla As New DataTable
        Dim cadena, cv As String
        pag = 1
        cv = ""
        niv = 0
        pv = 0
        sum1 = 0
        pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, _
            FileMode.Create, FileAccess.Write, FileShare.None))
        oDoc.Open()
        cb = pdfw.DirectContent
        oDoc.NewPage()
        cb.BeginText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 9)
        Refresh()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
        cadena = "INFORME GENERAL DE ARTICULOS"
        med = 250
        i = cadena.Length
        i = i / 2
        j = med - i
        cb.ShowTextAligned(50, cadena, j, 760, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
        k = 730
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 6)
        cb.BeginText()
        If i1.Checked = True Then
            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
            cb.ShowTextAligned(50, "LOCALIZACION", 200, k, 0)
            cb.ShowTextAligned(50, "REFERENCIA", 340, k - 10, 0)
            cb.ShowTextAligned(50, "CODIGO DE", 420, k, 0)
            cb.ShowTextAligned(50, "BARRAS", 420, k - 10, 0)
            cb.ShowTextAligned(50, "UNIDAD", 480, k - 10, 0)
            cb.ShowTextAligned(50, "CANT X", 540, k, 0)
            cb.ShowTextAligned(50, "EMPAQUE", 540, k - 10, 0)
        End If

        If i2.Checked = True Then
            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDADES EN BODEGA", 240, k, 0)
            col = 210
            For l As Integer = 0 To FrmLisBodegas.c - 1
                cb.ShowTextAligned(50, vec(l), col, k - 10, 0)
                col = col + 30
            Next
            cb.ShowTextAligned(50, "CANTIDAD", 420, k, 0)
            cb.ShowTextAligned(50, "TOTAL", 420, k - 10, 0)
            cb.ShowTextAligned(50, "UNIDADES", 500, k, 0)
            cb.ShowTextAligned(50, "EMPAQUE", 500, k - 10, 0)
        End If

        If i3.Checked = True Then
            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
            cb.ShowTextAligned(50, "CANTIDAD", 200, k, 0)
            cb.ShowTextAligned(50, " TOTAL", 200, k - 10, 0)
            cb.ShowTextAligned(50, " UNIDADES", 260, k, 0)
            cb.ShowTextAligned(50, "DE EMPAQUE", 260, k - 10, 0)
            cb.ShowTextAligned(50, " COSTO", 320, k, 0)
            cb.ShowTextAligned(50, "UNITARIO", 320, k - 10, 0)
            cb.ShowTextAligned(50, " COSTO", 380, k, 0)
            cb.ShowTextAligned(50, "PROMEDIO", 380, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR TOTAL", 450, k, 0)
            cb.ShowTextAligned(50, "A COSTO", 450, k - 10, 0)
            cb.ShowTextAligned(50, "VALOR TOTAL", 530, k, 0)
            cb.ShowTextAligned(50, "A PRECIO", 530, k - 10, 0)
        End If

        k = k - 30
        cb.EndText()
        cad = ""
        t1 = bda & ".articulos"
        t2 = bda & ".con_inv"
        If O1.Checked = True Then
            cad = " ORDER BY " & t1 & ".codart"
            cadena = "SELECT " & t1 & ".*," & t2 & ".* FROM " & t1 & " LEFT OUTER JOIN " & t2 & " ON " & t1 & ".codart=" & t2 & ".codart WHERE 1 "
        Else
            cad = " ORDER BY " & t1 & ".nomart"
            cadena = "SELECT " & t1 & ".*," & t2 & ".* FROM " & t1 & " INNER JOIN " & t2 & " ON " & t1 & ".codart=" & t2 & ".codart WHERE 1 "
        End If

        If l2.Checked = True Then
            tabla = New DataTable
            myCommand.CommandText = "SELECT * FROM bodegas"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count <= 0 Then
                MsgBox("No hay bodegas registradas")
                Exit Sub
            End If
            For i = 1 To tabla.Rows.Count
                If i = 1 Then
                    cadena = cadena & " AND (" & t2 & ".cant" & i & ">0"
                End If
                cadena = cadena & " OR " & t2 & ".cant" & i & ">0"
            Next
            cadena = cadena & ") "
        End If

        If c2.Checked = True Then
            cadena = cadena & " AND (" & t1 & ".codart>='" & txtci.Text & "' AND " & t1 & ".codart<='" & txtcf.Text & "') "
        End If

        'If n2.Checked = True Then
        '    tabla = New DataTable
        '    myCommand.CommandText = "SELECT " & bda & ".parinven.nivel1," & bda & ".parinven.nivel2," & bda & ".parinven.nivel3," & bda & ".parinven.nivel4," & bda & ".parinven.nivel5," & bda & ".parinven.nivel6 FROM " & bda & ".parinven"
        '    myAdapter.SelectCommand = myCommand
        '    myAdapter.Fill(tabla)
        '    If tabla.Rows.Count = 0 Then
        '        MsgBox("No existen parametros de inventario")
        '        Exit Sub
        '    Else
        '        niv = Val(tabla.Rows(0).Item(0)) & Val(tabla.Rows(0).Item(1)) & Val(tabla.Rows(0).Item(2)) & Val(tabla.Rows(0).Item(3)) & Val(tabla.Rows(0).Item(4)) & Val(tabla.Rows(0).Item(15))
        '        cadena = cadena & " AND CHAR_LENGTH(" & t1 & ".codart)=" & NUD1.Value & " "
        '    End If

        'End If

        tabla = New DataTable
        myCommand.CommandText = cadena & cad
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        If tabla.Rows.Count <> 0 Then
            For i = 0 To tabla.Rows.Count - 1
                If tabla.Rows(i).Item("periodo").ToString = Mid(PerActual, 1, 2) Or Trim(Len(tabla.Rows(i).Item("codart").ToString)) = 2 Then
                    If Trim(Len(tabla.Rows(i).Item("codart").ToString)) = 2 Then
                        If pv <> 0 And i3.Checked = True Then
                            cb.EndText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 7)
                            cb.BeginText()
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "______________________", 500, k, 0)
                            k = k - 11
                            cb.ShowTextAligned(50, "SUBTOTAL " & cv, 20, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
                            sum1 = 0
                            k = k - 10
                        End If
                        pv = 1
                        cv = tabla.Rows(i).Item("nomart").ToString
                        k = k - 10
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("nomart").ToString, 80, k, 0)

                    Else

                        If i1.Checked = True Then
                            cb.EndText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 7)
                            cb.BeginText()
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("desart").ToString, 20), 80, k, 0)
                            cb.ShowTextAligned(50, "", 200, k, 0)
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("referencia").ToString, 340, k, 0)
                            cb.ShowTextAligned(50, tabla.Rows(i).Item("codbar").ToString, 420, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("unidad").ToString, 500, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("can_emp").ToString, 560, k, 0)
                        Else
                            If i2.Checked = True Then
                                cb.EndText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 7)
                                cb.BeginText()
                                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("desart").ToString, 20), 80, k, 0)
                                col = 220
                                scan = 0
                                For l = 0 To FrmLisBodegas.c - 1
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cant" & vec(l)).ToString, col, k, 0)
                                    col = col + 30
                                    scan = scan + CDbl(tabla.Rows(i).Item("cant" & vec(l)).ToString)
                                Next

                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, scan, 440, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("can_emp").ToString, 560, k, 0)
                            Else
                                cb.EndText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 7)
                                cb.BeginText()
                                cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 20, k, 0)
                                cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("desart").ToString, 20), 80, k, 0)
                                col = 220
                                scan = 0
                                Dim tabla1 As New DataTable
                                myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                                myAdapter.SelectCommand = myCommand
                                myAdapter.Fill(tabla1)
                                If tabla1.Rows.Count <> 0 Then
                                    For l = 1 To tabla1.Rows.Count - 1
                                        scan = scan + CDbl(tabla.Rows(i).Item("cant" & l).ToString)
                                    Next
                                End If
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, scan, 220, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("costuni").ToString), 360, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla.Rows(i).Item("costprom").ToString), 430, k, 0)
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla.Rows(i).Item("costprom").ToString) * CDbl(scan)), 500, k, 0)
                                sum1 = sum1 + (CDbl(tabla.Rows(i).Item("costprom").ToString) * CDbl(scan))

                            End If
                        End If

                    End If

                    k = k - 10
                    If k <= 80 Then
                        pag = pag + 1
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        Refresh()
                        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla)
                        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion").ToString, 20, 810, 0)
                        cb.ShowTextAligned(50, "N.I.T. " & tabla.Rows(0).Item("nit").ToString, 20, 800, 0)
                        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
                        cb.ShowTextAligned(50, "PERIODO ACTUAL: " & PerActual, 20, 780, 0)
                        cb.ShowTextAligned(50, "FECHA IMPRESO: " & Now.ToString, 20, 770, 0)
                        cadena = "INFORME GENERAL DE ARTICULOS"
                        med = 250
                        'i = cadena.Length
                        'i = i / 2
                        'j = med - i
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, cadena, 300, 760, 0)
                        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
                        k = 700
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 6)
                        cb.BeginText()
                        If i1.Checked = True Then
                            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
                            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
                            cb.ShowTextAligned(50, "LOCALIZACION", 200, k, 0)
                            cb.ShowTextAligned(50, "REFERENCIA", 340, k - 10, 0)
                            cb.ShowTextAligned(50, "CODIGO DE", 420, k, 0)
                            cb.ShowTextAligned(50, "BARRAS", 420, k - 10, 0)
                            cb.ShowTextAligned(50, "UNIDAD", 480, k - 10, 0)
                            cb.ShowTextAligned(50, "CANT X", 540, k, 0)
                            cb.ShowTextAligned(50, "EMPAQUE", 540, k - 10, 0)
                        End If

                        If i2.Checked = True Then
                            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
                            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
                            cb.ShowTextAligned(50, "CANTIDADES EN BODEGA", 240, k, 0)
                            col = 210
                            For l As Integer = 0 To FrmLisBodegas.c - 1
                                cb.ShowTextAligned(50, vec(l), col, k - 10, 0)
                                col = col + 30
                            Next
                            cb.ShowTextAligned(50, "CANTIDAD", 420, k, 0)
                            cb.ShowTextAligned(50, "TOTAL", 420, k - 10, 0)
                            cb.ShowTextAligned(50, "UNIDADES", 500, k, 0)
                            cb.ShowTextAligned(50, "EMPAQUE", 500, k - 10, 0)
                        End If

                        If i3.Checked = True Then
                            cb.ShowTextAligned(50, "CODIGO", 20, k - 10, 0)
                            cb.ShowTextAligned(50, "DESCRIPCION", 80, k - 10, 0)
                            cb.ShowTextAligned(50, "CANTIDAD", 200, k, 0)
                            cb.ShowTextAligned(50, " TOTAL", 200, k - 10, 0)
                            cb.ShowTextAligned(50, " UNIDADES", 260, k, 0)
                            cb.ShowTextAligned(50, "DE EMPAQUE", 260, k - 10, 0)
                            cb.ShowTextAligned(50, " COSTO", 320, k, 0)
                            cb.ShowTextAligned(50, "UNITARIO", 320, k - 10, 0)
                            cb.ShowTextAligned(50, " COSTO", 380, k, 0)
                            cb.ShowTextAligned(50, "PROMEDIO", 380, k - 10, 0)
                            cb.ShowTextAligned(50, "VALOR TOTAL", 450, k, 0)
                            cb.ShowTextAligned(50, "A COSTO", 450, k - 10, 0)
                            cb.ShowTextAligned(50, "VALOR TOTAL", 530, k, 0)
                            cb.ShowTextAligned(50, "A PRECIO", 530, k - 10, 0)
                        End If
                        k = k - 30
                        'cb.EndText()
                    End If
                End If
            Next
            If i3.Checked = True Then
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "______________________", 500, k, 0)
                k = k - 11
                cb.ShowTextAligned(50, "SUBTOTAL " & cv, 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sum1), 500, k, 0)
                sum1 = 0
                k = k - 10
            End If
        End If

        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        Try
            AbrirArchivo(NombreArchivo)
        Catch ex As Exception
            AbrirArchivo(NombreArchivo)
            Exit Try
        End Try

    End Sub

    Private Sub txtci_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtci.DoubleClick
        ct = 1
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub txtci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtci.TextChanged

    End Sub

    Private Sub txtcf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcf.DoubleClick
        ct = 2
        FrmLisArt.ShowDialog()
    End Sub

    Private Sub txtcf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcf.TextChanged

    End Sub

    Private Sub i2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles i2.MouseClick
        If i2.Checked = True Then
            ct = 10
            FrmLisBodegas.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub FrmInfartalf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbini.SelectedIndex = 0
    End Sub
End Class