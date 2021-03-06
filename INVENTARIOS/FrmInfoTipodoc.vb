﻿Imports iTextSharp.text
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

Public Class FrmInfoTipodoc

    Public ent, sal As String

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub FrmInfoTipodoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tabla As New DataTable
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        myCommand.CommandText = "SELECT tipodoc FROM tipdoc;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then Exit Sub
        txttipo.Items.Clear()
        For i As Integer = 0 To tabla.Rows.Count - 1
            txttipo.Items.Add(Trim(tabla.Rows(i).Item("tipodoc")))
            If i = 0 Then
                txttipo.Text = Trim(tabla.Rows(i).Item("tipodoc"))
            End If
        Next
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

    Private Sub cmdpantalla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Dim nit As String = ""
        Dim nom As String = ""
        Dim per As String = ""
        Dim sql As String = ""



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


            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            Dim p As String = " "




            ' ---------------------------------------------------
            ' --------------- TODOS LOS DOCUMENTOS ---------------
            If c1.Checked = True Then

                '    ' --------------- CODIGOS APROBADOS ---------------
                If d1.Checked = True Then
                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If
                        If p = cbini.Text Then

                            sql = "select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                 & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                 & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                 & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc AND m . estado ='AP'  "

                        Else

                            sql = sql & " UNION select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                   & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                   & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                   & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc AND m . estado ='AP'  "


                        End If
                    Next
                    sql = sql & " ORDER BY tipodoc,doc"

                    TextBox1.Text = sql

                End If

                ' --------------- TODOS LOS CODIGOS APROBADOS Y NO ---------------
                If d4.Checked = True Then
                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If
                        If p = cbini.Text Then

                            sql = "select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                       & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                       & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                       & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc   "
                        Else

                            sql = sql & " UNION select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                                            & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                                            & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                                            & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc   "
                        End If
                    Next
                    sql = sql & " ORDER BY tipodoc,doc"
                    TextBox1.Text = sql

                End If

            End If
            ' ---------- FIN ---- TODOS LOS DOCUMENTOS ---------------




            '' ------------------------------------------
            '' --------------- UN CODIGO ---------------
            If c2.Checked = True Then

                ' ' --------------- CODIGO APROBADO ---------------
                If d1.Checked = True Then

                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If
                        If p = cbini.Text Then

                            sql = "select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc AND m . estado ='AP' AND m.tipodoc = '" & txttipo.Text & "' "
                        Else

                            sql = sql & " UNION select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc AND m . estado ='AP' AND m.tipodoc = '" & txttipo.Text & "' "
                        End If
                    Next
                    sql = sql & " ORDER BY tipodoc,doc"
                    TextBox1.Text = sql


                End If

                '' ---------------  APROBADO Y NO---------------
                If d4.Checked = True Then
                    For i = Val(cbini.Text) To Val(cbfin.Text)

                        If i < 10 Then
                            p = "0" & i
                        Else
                            p = i
                        End If
                        If p = cbini.Text Then

                            sql = "select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc  AND m.tipodoc = '" & txttipo.Text & "' "
                        Else

                            sql = sql & " UNION select m.tipodoc, m.desc_mov, d . codart as tipo, d . nomart as observ, d . doc , CONCAT(m . dia , '/' , m . per )AS per , if(d.bod_ori=0,0,d.bod_ori) AS o_compra, if(d.bod_des=0,0,d.bod_des) AS n_pedido,  " _
                                & " IF(d . bod_ori <>0 ,0, cantidad )as nitc , IF(d . bod_des <>0 , 0 , cantidad )as cc , d . valor as concepto , " _
                                & " IF(d . bod_ori <>0 ,0 , (cantidad *d . valor ))as total , IF(d . bod_des <>0 ,0 , (cantidad *d . valor ))as num " _
                                & "FROM deta_mov" & p & " d , movimientos" & p & " m WHERE d . doc =m . doc AND m.tipodoc = '" & txttipo.Text & "' "
                        End If
                    Next
                    sql = sql & " ORDER BY tipodoc,doc"
                    TextBox1.Text = sql

                End If
            End If
            ' ---------------------------------------------------------------
            ' -------------FIN-- UN CODIGO ---------------



            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportMovDoc.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmRepMovDoc.CrystalReportViewer1.ReportSource = CrReport


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


                FrmRepMovDoc.CrystalReportViewer1.ParameterFieldInfo = prmdatos

            Catch ex As Exception
                MsgBox(sql)
            End Try

        Catch ex As Exception
            ' MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try
        FrmRepMovDoc.ShowDialog()

    End Sub


    Private Sub txttipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttipo.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & txttipo.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txttipo2.Text = ""
            Exit Sub
        End If
        txttipo2.Text = tabla.Rows(0).Item(0)
    End Sub

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttipo.Enabled = True
        Else
            txttipo.Enabled = False
        End If
    End Sub

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2, t3 As String
        Dim i, i2, j, k, pag, med, niv, pv As Integer
        Dim sum1, sument, sumsal, totalent, totalsal, cant, cant1 As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, cv, consulta, consulta2, tp, per, tdoc As String
        pag = 1
        per = ""
        tdoc = ""
        cv = ""
        cant1 = 0
        sument = 0
        totalent = 0
        totalsal = 0
        sumsal = 0
        niv = 0
        pv = 0
        cant = 0
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
        cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & "                                " & "PERIODO FINAL: " & "/" & cbfin.Text & txtpfin.Text, 20, 760, 0)
        cadena = "INFORME GENERAL DE ARTICULOS"
        med = 250
        i2 = cadena.Length
        i2 = i2 / 2
        j = med - i2
        cb.ShowTextAligned(50, cadena, j, 750, 0)
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
        k = 700
        cb.EndText()
        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 6)
        cb.BeginText()
        cb.ShowTextAligned(50, "TIPO/NUMERO", 20, k, 0)
        cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 10, 0)
        cb.ShowTextAligned(50, "FECHA", 80, k - 10, 0)
        cb.ShowTextAligned(50, " BODEGAS", 120, k, 0)
        cb.ShowTextAligned(50, "DEST|ORIG", 120, k - 10, 0)
        cb.ShowTextAligned(50, "CODIGO", 160, k, 0)
        cb.ShowTextAligned(50, "ARTICULO", 160, k - 10, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 200, k, 0)
        cb.ShowTextAligned(50, "CANTIDADES", 300, k, 0)
        cb.ShowTextAligned(50, "ENTRADAS", 280, k - 10, 0)
        cb.ShowTextAligned(50, "SALIDAS", 320, k - 10, 0)
        cb.ShowTextAligned(50, "COSTO", 380, k, 0)
        cb.ShowTextAligned(50, "UNITARIO", 380, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR", 460, k, 0)
        cb.ShowTextAligned(50, "ENTRADAS", 460, k - 10, 0)
        cb.ShowTextAligned(50, "VALOR", 540, k, 0)
        cb.ShowTextAligned(50, "SALIDAS", 540, k - 10, 0)
        k = k - 30
        cb.EndText()
        cad = ""
        consulta = ""
        For i = Val(cbini.Text) To Val(cbfin.Text)
            t1 = bda & ".deta_mov" & adicionar(i)
            t2 = bda & ".movimientos" & adicionar(i)
            t3 = bda & ".con_inv"


            If consulta = "" Then

                consulta = "(SELECT " & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc WHERE 1"

                If c2.Checked = True Then
                    consulta = consulta & " AND " & t2 & ".tipodoc = '" & txttipo.Text & "' "
                End If
                If d1.Checked = True Then
                    consulta = consulta & " AND " & t2 & ".estado='AP' "
                End If

                'consulta = consulta & " AND (" & t2 & ".dia>='" & txtdi1.Text & "' AND " & t2 & ".per>='" & cbini.Text & txtpini.Text & "' )  AND  (" & t2 & ".dia<='" & txtdi2.Text & "' AND " & t2 & ".per<='" & cbfin.Text & txtpfin.Text & "' ) "

                consulta = consulta & " ORDER BY " & t2 & ".doc) "
            Else
                consulta2 = "(SELECT " & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia  FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc WHERE 1"
                If c2.Checked = True Then
                    consulta2 = consulta2 & " AND " & t2 & ".tipodoc = '" & txttipo.Text & "' "
                End If

                If d1.Checked = True Then
                    consulta2 = consulta2 & " AND " & t2 & ".estado='AP' "
                End If

                'consulta2 = consulta2 & " AND (" & t2 & ".dia>='" & txtdi1.Text & "' AND " & t2 & ".per>='" & cbini.Text & txtpini.Text & "' )  AND  (" & t2 & ".dia<='" & txtdi2.Text & "' AND " & t2 & ".per<='" & cbfin.Text & txtpfin.Text & "' ) "

                consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & ".doc)"
            End If
        Next

        consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.doc"

        tabla = New DataTable
        myCommand.CommandText = consulta & cad
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        tp = ""

        If tabla.Rows.Count <> 0 Then
            For i = 0 To tabla.Rows.Count - 1
                If tp <> tabla.Rows(i).Item("tipodoc").ToString Then
                    If tp <> "" Then
                        cb.EndText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "________________________________________", 580, k, 0)
                        k = k - 8
                        cb.ShowTextAligned(50, "SUBTOTAL" & "   " & tdoc, 20, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
                        sument = 0
                        sumsal = 0
                        k = k - 20
                    End If
                    tabla1 = New DataTable
                    myCommand.CommandText = "SELECT " & bda & ".tipdoc.descripcion FROM " & bda & ".tipdoc WHERE " & bda & ".tipdoc.tipodoc='" & tabla.Rows(i).Item("tipodoc").ToString & "';"
                    myAdapter.SelectCommand = myCommand
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    cb.BeginText()
                    myAdapter.Fill(tabla1)
                    If tabla1.Rows.Count <> 0 Then
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "   " & tabla1.Rows(0).Item("descripcion").ToString, 20, k, 0)
                        tdoc = tabla1.Rows(0).Item("descripcion").ToString
                    End If
                    k = k - 10
                End If
        cb.EndText()
        ' k = k - 5
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
        cb.SetFontAndSize(fuente, 7)
        cb.BeginText()
        cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "  " & NumeroDoc(tabla.Rows(i).Item("num").ToString), 20, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("per").ToString, 105, k, 0)
        cb.ShowTextAligned(50, tabla.Rows(i).Item("codart").ToString, 160, k, 0)
        If Len(tabla.Rows(i).Item("nomart").ToString) > 20 Then
            cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("nomart").ToString, 20), 200, k, 0)
        Else
            cb.ShowTextAligned(50, tabla.Rows(i).Item("nomart").ToString, 200, k, 0)
        End If
        If tabla.Rows(i).Item("bod_ori").ToString <> "0" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("bod_ori").ToString, 130, k, 0)
        End If
        If tabla.Rows(i).Item("bod_des").ToString <> "0" Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("bod_des").ToString, 150, k, 0)
        End If

        tabla1 = New DataTable
        myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & Mid(tabla.Rows(i).Item("per").ToString, 1, 2) & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla1)
        If tabla1.Rows.Count > 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni").ToString), 420, k, 0)
        End If

                If tabla.Rows(i).Item("bod_des").ToString <> "0" Then
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 300, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 490, k, 0)
                    sument = sument + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    totalent = totalent + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                Else
                    'If tabla.Rows(i).Item("tipodoc").ToString = sal Then
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 340, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 570, k, 0)
                    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    'Else
                    '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 340, k, 0)
                    '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 570, k, 0)
                    '    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    '    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                    'End If
                End If

                tp = tabla.Rows(i).Item("tipodoc").ToString

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
                    cb.ShowTextAligned(50, "PERIODO INICIAL: " & cbini.Text & txtpini.Text & "                                " & "PERIODO FINAL: " & "/" & cbfin.Text & txtpfin.Text, 20, 760, 0)
                    cadena = "INFORME GENERAL DE ARTICULOS"
                    med = 250
                    i2 = cadena.Length
                    i2 = i2 / 2
                    j = med - i
                    cb.ShowTextAligned(50, cadena, j, 750, 0)
                    cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 740, 0)
                    k = 700
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 6)
                    cb.BeginText()
                    cb.ShowTextAligned(50, "TIPO/NUMERO", 20, k, 0)
                    cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 10, 0)
                    cb.ShowTextAligned(50, "FECHA", 80, k - 10, 0)
                    cb.ShowTextAligned(50, " BODEGAS", 120, k, 0)
                    cb.ShowTextAligned(50, "DEST|ORIG", 120, k - 10, 0)
                    cb.ShowTextAligned(50, "CODIGO", 160, k, 0)
                    cb.ShowTextAligned(50, "ARTICULO", 160, k - 10, 0)
                    cb.ShowTextAligned(50, "DESCRIPCION", 200, k, 0)
                    cb.ShowTextAligned(50, "CANTIDADES", 300, k, 0)
                    cb.ShowTextAligned(50, "ENTRADAS", 280, k - 10, 0)
                    cb.ShowTextAligned(50, "SALIDAS", 320, k - 10, 0)
                    cb.ShowTextAligned(50, "COSTO", 380, k, 0)
                    cb.ShowTextAligned(50, "UNITARIO", 380, k - 10, 0)
                    cb.ShowTextAligned(50, "VALOR", 460, k, 0)
                    cb.ShowTextAligned(50, "ENTRADAS", 460, k - 10, 0)
                    cb.ShowTextAligned(50, "VALOR", 540, k, 0)
                    cb.ShowTextAligned(50, "SALIDAS", 540, k - 10, 0)
                    k = k - 30
                End If
            Next
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            cb.BeginText()
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "________________________________________", 580, k, 0)
            k = k - 8
            cb.ShowTextAligned(50, "SUBTOTAL" & "   " & tdoc, 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
            sument = 0
            sumsal = 0
            k = k - 10
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 15)
            cb.BeginText()
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________", 580, k, 0)
            k = k - 15
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            cb.BeginText()
            cb.ShowTextAligned(50, "TOTAL GENERAL", 20, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalent), 490, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(totalsal), 570, k, 0)
            k = k - 15
        End If
        cb.EndText()
        pdfw.Flush()
        oDoc.Close()
        AbrirArchivo(NombreArchivo)
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class