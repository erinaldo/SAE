Imports iTextSharp.text.pdf
Imports iTextSharp.text
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

Public Class FrmTributarios
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer, Cond As String
    Dim tdebito, tcredito, tnitb, tnitd, tnitc, tcuentab, tcuentad, tcuentac As Double
    Dim FechaRep As String
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Private Sub FrmTributarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If lbnum.Text = "4" Then
            cmdcertificado.Visible = True
        Else
            cmdcertificado.Visible = False
        End If
        BuscarPeriodo()
        cbini.Text = PerActual(0) & PerActual(1)
        cbfin.Text = cbini.Text
        txtpini.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        txtperf.Text = txtpini.Text
    End Sub

    Private Sub n1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n1.CheckedChanged
        txtnit.Enabled = False
    End Sub
    Private Sub n2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n2.CheckedChanged
        txtnit.Enabled = True
    End Sub
    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        VerificarNit()
        Try
            FrmSelCliente.lbform.Text = "trib"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Function VerificarNit()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            txtnombre.Text = ""
            Return False
        Else
            txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
            Return True
        End If
    End Function

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        Informe()
    End Sub

    Public Sub Informe()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim i, j, tope As Integer
        Dim tele As String
        '**********    Buscar Cuentas Del Informe   ********
        Dim tabla, tablames, ttri, tnit As New DataTable
        myCommand.CommandText = "SELECT * FROM tributarios WHERE num=" & Val(lbnum.Text) & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(ttri)
        '********************
        Try
            pag = 1
            FechaRep = Now.ToString
            tdebito = 0
            tcredito = 0
            tcuentab = 0
            tcuentac = 0
            tcuentad = 0
            tope = 70
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            '***************
            BannerBG(cbini.Text & "/" & txtpini.Text, lbtipo.Text)
            '*****************
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '/**********************
            For i = 1 To 5
                If ttri.Rows(0).Item("cuenta" & i).ToString = "" Then Exit For
                tablames.Clear()
                tnit.Clear()
                k = k - 20
                If k < tope Then 'NUEVA PAGINA
                    pag = pag + 1
                    cb.EndText()
                    oDoc.NewPage()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 9)
                    BannerBG(cbini.Text & "/" & txtpini.Text, lbtipo.Text)
                    k = k - 10
                    cb.EndText()
                    cb.BeginText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 8)
                End If
                SaldoInicial(ttri.Rows(0).Item("cuenta" & i))
                k = k - 10
                tnit.Clear()
                myCommand.Parameters.Clear()
                If n1.Checked = True Then
                    myCommand.CommandText = "SELECT distinct(d.nit),d.codigo, t.nombre, t.apellidos, t.telefono, t.celular FROM documentos" & cbini.Text & " d LEFT JOIN (terceros t) ON t.nit = d.nit WHERE d.codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "' ORDER BY t.apellidos"
                Else
                    myCommand.CommandText = "SELECT distinct(d.nit),d.codigo, t.nombre, t.apellidos, t.telefono, t.celular FROM documentos" & cbini.Text & " d LEFT JOIN (terceros t) ON t.nit = d.nit WHERE d.codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "' AND d.nit='" & txtnit.Text & "' ORDER BY t.apellidos"
                End If
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tnit)
                For j = 0 To tnit.Rows.Count - 1
                    k = k - 10
                    If k < tope Then 'NUEVA PAGINA
                        pag = pag + 1
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 9)
                        BannerBG(cbini.Text & "/" & txtpini.Text, lbtipo.Text)
                        k = k - 10
                        cb.EndText()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 8)
                    End If
                    tablames.Clear()
                    myCommand.Parameters.Clear()
                    tele = ""
                    If tnit.Rows(j).Item("telefono").ToString <> "(ninguno)" And tnit.Rows(j).Item("telefono").ToString <> "" Then
                        tele = tnit.Rows(j).Item("telefono").ToString
                    End If
                    If tnit.Rows(j).Item("celular").ToString <> "(ninguno)" And tnit.Rows(j).Item("celular").ToString <> "" Then
                        tele = tele & " " & tnit.Rows(j).Item("celular").ToString
                    End If
                    If ri1.Checked = True Then
                        cb.ShowTextAligned(50, "N.I.T.: " & tnit.Rows(j).Item("nit"), 20, k, 0)
                        cb.ShowTextAligned(50, Trim(tnit.Rows(j).Item("apellidos") & " " & tnit.Rows(j).Item("nombre")), 110, k, 0)
                        cb.ShowTextAligned(50, "Telefonos " & Trim(tele), 300, k, 0)
                        myCommand.CommandText = "SELECT base,debito,credito,tipodoc,doc,dia,periodo,descri FROM documentos" & cbini.Text & " WHERE codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "' AND nit='" & tnit.Rows(j).Item("nit") & "'"
                    Else
                        cb.ShowTextAligned(50, tnit.Rows(j).Item("nit"), 10, k, 0)
                        cb.ShowTextAligned(50, Trim(tnit.Rows(j).Item("apellidos") & " " & tnit.Rows(j).Item("nombre")), 70, k, 0)
                        cb.ShowTextAligned(50, Trim(tele), 230, k, 0)
                        myCommand.CommandText = "SELECT SUM(base),SUM(debito),SUM(credito) FROM documentos" & cbini.Text & " WHERE codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "' AND nit='" & tnit.Rows(j).Item("nit") & "'"
                    End If
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tablames)
                    tnitb = 0
                    tnitd = 0
                    tnitc = 0
                    For w = 0 To tablames.Rows.Count - 1
                        If ri1.Checked = True Then
                            k = k - 10
                            If k < tope Then 'NUEVA PAGINA
                                pag = pag + 1
                                cb.EndText()
                                oDoc.NewPage()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 9)
                                BannerBG(cbini.Text & "/" & txtpini.Text, lbtipo.Text)
                                k = k - 10
                                cb.EndText()
                                cb.BeginText()
                                fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                                cb.SetFontAndSize(fuente, 8)
                            End If
                            cb.ShowTextAligned(50, tablames.Rows(w).Item("tipodoc") & numeros(tablames.Rows(w).Item("doc")), 20, k, 0)
                            cb.ShowTextAligned(50, tablames.Rows(w).Item("dia") & "/" & tablames.Rows(w).Item("periodo"), 80, k, 0)
                            cb.ShowTextAligned(50, tablames.Rows(w).Item("descri"), 130, k, 0)
                        End If
                        If (tablames.Rows(w).Item(0).ToString) <> "0" Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tablames.Rows(w).Item(0).ToString), 2), "0,00.00"), 385, k, 0)
                            tnitb = tnitb + tablames.Rows(w).Item(0)
                        Else
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 385, k, 0)
                        End If
                        If (tablames.Rows(w).Item(1).ToString) <> "0" Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tablames.Rows(w).Item(1).ToString), 2), "0,00.00"), 485, k, 0)
                            tnitd = tnitd + tablames.Rows(w).Item(1)
                        Else
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 485, k, 0)
                        End If
                        If (tablames.Rows(w).Item(2).ToString) <> "0" Then
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tablames.Rows(w).Item(2).ToString), 2), "0,00.00"), 585, k, 0)
                            tnitc = tnitc + tablames.Rows(w).Item(2)
                        Else
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
                        End If
                    Next w
                    TotalesNIT()
                    tnitb = 0
                    tnitd = 0
                    tnitc = 0
                Next j
                k = k - 15
                TotalesCuenta()
                tcuentab = 0
                tcuentac = 0
                tcuentad = 0
                k = k - 18
                SaldoFinal(ttri.Rows(0).Item("cuenta" & i))
            Next i
            k = k - 20
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "________________________________________", 585, k + 10, 0)
            cb.ShowTextAligned(50, "TOTAL GENERAL: ", 20, k, 0)
            If tdebito <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tdebito), 2), "0,00.00"), 485, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 485, k, 0)
            End If
            If tcredito <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tcredito), 2), "0,00.00"), 585, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
            End If
            '********************************************************************
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("ERROR al momento de generar el balance de P Y G, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub BannerBG(ByVal pi As String, ByVal tipo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, 810, 0)
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, 800, 0)
        cb.ShowTextAligned(50, "PAGINA: " & pag, 20, 790, 0)
        If cbini.Text = cbfin.Text Then
            cb.ShowTextAligned(50, "PERIODO: " & pi, 20, 780, 0)
        Else
            cb.ShowTextAligned(50, "RANGO DE PERIODOS: [" & cbini.Text & "/" & txtpini.Text & "  -  " & cbfin.Text & "/" & txtperf.Text & "]", 20, 780, 0)
        End If
        cb.ShowTextAligned(50, "FECHA IMPRESO: " & FechaRep, 20, 760, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tipo, 300, 750, 0)
        k = 740
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        If ri1.Checked = True Then
            cb.ShowTextAligned(50, "TIPO DE INFORME: DETALLADO", 20, 770, 0)
            cb.ShowTextAligned(50, "DOCUMENTO", 20, k, 0)
            cb.ShowTextAligned(50, "FECHA", 85, k, 0)
            cb.ShowTextAligned(50, "DESCRIPCIÓN", 130, k, 0)
        Else
            cb.ShowTextAligned(50, "TIPO DE INFORME: RESUMIDO", 20, 770, 0)
            cb.ShowTextAligned(50, "N.I.T.", 10, k, 0)
            cb.ShowTextAligned(50, "NOMBRE / RAZON SOCIAL", 70, k, 0)
            cb.ShowTextAligned(50, "TEL. / CEL.", 230, k, 0)
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "BASE", 385, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "DEBITO", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "CREDITO", 585, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
    End Sub
    Public Sub SaldoInicial(ByVal cuenta As String)
        Dim saldo As Double
        Dim cad As String
        Dim per As Integer
        Dim tabla As New DataTable
        per = Val(cbini.Text) - 1
        If per < 10 Then
            cad = "saldo0" & per
        Else
            cad = "saldo" & per
        End If
        myCommand.CommandText = "SELECT " & cad & ",codigo,descripcion FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            saldo = tabla.Rows(0).Item(0)
        Catch ex As Exception
            saldo = 0
        End Try
        cb.ShowTextAligned(50, "CUENTA: " & tabla.Rows(0).Item("codigo"), 20, k, 0)
        cb.ShowTextAligned(50, tabla.Rows(0).Item("descripcion"), 115, k, 0)

        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO INICIAL: ", 450, k, 0)
        If saldo <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(saldo), 2), "0,00.00"), 585, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
        End If

    End Sub
    Public Sub SaldoFinal(ByVal cuenta As String)
        Dim saldo As Double
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT saldo" & cbfin.Text & " FROM selpuc WHERE codigo='" & cuenta & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Try
            saldo = tabla.Rows(0).Item(0)
        Catch ex As Exception
            saldo = 0
        End Try
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SALDO FINAL: ", 450, k, 0)
        If saldo <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(saldo), 2), "0,00.00"), 585, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
        End If
    End Sub
    Public Sub TotalesNIT()
        If ri1.Checked = True Then
            k = k - 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________________________________________", 585, k + 10, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTALES N.I.T.: ", 250, k, 0)
            If tnitb <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tnitb), 2), "0,00.00"), 385, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 385, k, 0)
            End If
            '************************************
            If tnitd <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tnitd), 2), "0,00.00"), 485, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 485, k, 0)
            End If
            '****************************************
            If tnitc <> 0 Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tnitc), 2), "0,00.00"), 585, k, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
            End If
        End If
        tcuentab = tcuentab + tnitb
        tcuentac = tcuentac + tnitc
        tcuentad = tcuentad + tnitd
    End Sub
    Public Sub TotalesCuenta()
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________________________________________", 585, k + 10, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "TOTALES CUENTA: ", 250, k, 0)
        If tcuentab <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tcuentab), 2), "0,00.00"), 385, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 385, k, 0)
        End If
        '************************************
        If tcuentad <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tcuentad), 2), "0,00.00"), 485, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 485, k, 0)
        End If
        '****************************************
        If tcuentac <> 0 Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Format(Math.Round(CDbl(tcuentac), 2), "0,00.00"), 585, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "0,00", 585, k, 0)
        End If
        tdebito = tdebito + tcuentad
        tcredito = tcredito + tcuentac
    End Sub

    Function numeros(ByVal num As Integer)
        Return NumeroDoc(num)
    End Function

    Private Sub cmdcertificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcertificado.Click
        FrmCertificadoRete.ShowDialog()
    End Sub

    Private Sub cbini_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbini.SelectedIndexChanged
        cbfin.Items.Clear()
        For i = Val(cbini.Text) To 12
            If i < 10 Then
                cbfin.Items.Add("0" & i)
            Else
                cbfin.Items.Add(i)
            End If
        Next
        Try
            If Val(cbini.Text) > Val(cbfin.Text) Then
                cbfin.Text = cbini.Text
            End If
        Catch ex As Exception
            cbfin.Text = cbini.Text
        End Try
    End Sub


    Private Sub Reporte(ByVal cadC As String, ByVal tipo As String)


        Try

        
            Dim sql As String = ""
            Dim tituloG As String = ""
            Dim nom As String = ""
            Dim nit As String = ""
            Dim dnit As String = ""
            Dim nitp As String = ""
            Dim per As String = ""
            Dim p As String = ""
            Dim pi As String = ""
            Dim ini As Integer = 0
            Dim fin As Integer = 0

            ini = cbini.Text
            fin = cbfin.Text

            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nitp = "NIT: " & tabla2.Rows(0).Item("nit")
            per = "PERIODO: " & cbini.Text & "/" & txtpini.Text & " - " & cbfin.Text & "/" & txtperf.Text

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()

            If n2.Checked = True Then
                nit = " AND nit = '" & txtnit.Text & "' "
                dnit = " AND d.nit = '" & txtnit.Text & "' "
            End If

            '---------- saldos iniciales
            Dim salT As String = ""
            For j = 1 To ini
                If j < 10 Then
                    pi = "0" & j - 1
                Else
                    If j = 10 Then
                        pi = "0" & j - 1
                    Else
                        pi = j - 1
                    End If
                End If
                If j <> ini Then
                    salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & "   WHERE codigo IN (" & cadC & ") " & nit & " group by codigo UNION "
                Else
                    salT = salT & " SELECT nit, codigo, tipodoc, IFNULL(sum(debito-credito),0) as n from documentos" & pi & "  WHERE codigo IN (" & cadC & ") " & nit & " group by codigo "
                End If
            Next

            If ri2.Checked = True Then
                sql = " select cc.nitcod, cc.descrip, cc.nitc, cc.nomnit, cc.ctaret, cc.subtotal, sum(cc.descto) as descto, sum(cc.tasa) as tasa, sum(cc.total) as total FROM (  "
            End If

            ' ....... fin saldos iniciales
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
                If i <> fin Then

                    sql = sql & " SELECT  d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, trim( concat(t.nombre,' ', t.apellidos)) as nomnit,  trim(concat( t.telefono,' ', t.celular)) as ctaret, " _
               & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
               & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
               & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20) ) as doc, " _
               & " d.descri as concepto, d.base as descto, d.debito as tasa, d.credito as total  " _
               & " FROM  selpuc s , documentos" & p & " d , terceros t  " _
               & " WHERE  d.nit = t.nit and s.codigo = d.codigo  AND s.codigo IN (" & cadC & ")  " & dnit & " UNION "

                Else

                    sql = sql & " SELECT  d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc, trim( concat(t.nombre,' ', t.apellidos)) as nomnit,  trim(concat( t.telefono,' ', t.celular)) as ctaret, " _
             & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
             & " IFNULL(( select  sum(c.n) FROM ( " & salT & " ) as c   WHERE  c.codigo =  d.codigo  GROUP BY codigo ),0) as subtotal,  " _
             & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20) ) as doc, " _
             & " d.descri as concepto, d.base as descto, d.debito as tasa, d.credito as total  " _
             & " FROM  selpuc s , documentos" & p & " d , terceros t  " _
             & " WHERE  d.nit = t.nit and s.codigo = d.codigo  AND s.codigo IN (" & cadC & ") " & dnit & " "

                End If
            Next

            If ri1.Checked = True Then
                sql = sql & " ORDER BY nitcod, nomnit, fecha ASC "
            Else
                sql = sql & " ) as cc GROUP BY nitc ORDER BY nitcod, nomnit "
            End If

            TextBox1.Text = sql

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            If ri1.Checked = True Then ' Detallado

                tituloG = " " & tipo & " - DETALLADO "


                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTributario.rpt")
                CrReport.SetDataSource(tabla)
                CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
                FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrtituloG As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)
                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nitp.ToString)
                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    PrtituloG.Name = "tituloG"
                    PrtituloG.CurrentValues.AddValue(tituloG.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrtituloG)

                    FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportTributario.ShowDialog()
                Catch ex As Exception
                End Try
            Else
                tituloG = "" & tipo & " - RESUMIDO "

                Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
                CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportTributarioR.rpt")
                CrReport.SetDataSource(tabla)
                FrmReportTributario.CrystalReportViewer1.ReportSource = CrReport

                Try
                    Dim Prcompañia As New ParameterField
                    Dim PrNit As New ParameterField
                    Dim Prperiodo As New ParameterField
                    Dim PrtituloG As New ParameterField

                    Dim prmdatos As ParameterFields
                    prmdatos = New ParameterFields

                    Prcompañia.Name = "comp"
                    Prcompañia.CurrentValues.AddValue(nom.ToString)
                    PrNit.Name = "nit"
                    PrNit.CurrentValues.AddValue(nitp.ToString)
                    Prperiodo.Name = "periodo"
                    Prperiodo.CurrentValues.AddValue(per.ToString)

                    PrtituloG.Name = "tituloG"
                    PrtituloG.CurrentValues.AddValue(tituloG.ToString)

                    prmdatos.Add(Prcompañia)
                    prmdatos.Add(PrNit)
                    prmdatos.Add(Prperiodo)
                    prmdatos.Add(PrtituloG)

                    FrmReportTributario.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                    FrmReportTributario.ShowDialog()
                Catch ex As Exception
                End Try


            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error al generar el informe. " & ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cadC As String = ""
        Dim tipo As String = ""
        Dim tablaT As New DataTable
        tablaT = New DataTable

        Select Case lbnum.Text
            Case "1"
                tipo = "INFORME I.V.A RECAUDADO (POR PAGAR)"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12  FROM tributarios WHERE num = '1' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                '  Try
                Reporte(cadC, tipo)
                ' Catch ex As Exception
                'End Try

            Case "2"
                tipo = "INFORME I.V.A PAGADO (DESCONTABLE)"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '2' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "3"
                tipo = "INFORME RETENCIONES HECHAS POR TERCEROS"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '3' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "4"
                tipo = "RETENCIONES HECHAS A TERCEROS"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '4' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "5"
                tipo = "INFORME I.V.A RETENIDOS A TERCEROS "
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '5' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "6"
                tipo = "INFORME I.C.A RETENIDOS A TERCEROS"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '6' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "7"
                tipo = "INFORME DE OTRAS CUENTAS"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '7' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
            Case "8"
                tipo = "INFORME DE OTRAS CUENTAS"
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5, " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10, cuenta11 , cuenta12 FROM tributarios WHERE num = '8' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 11
                        If tablaT.Rows(0).Item(i) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    Reporte(cadC, tipo)
                Catch ex As Exception
                End Try
        End Select
    End Sub

End Class