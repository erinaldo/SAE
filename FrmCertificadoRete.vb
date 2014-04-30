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
Public Class FrmCertificadoRete
    Dim cb As PdfContentByte
    Dim k, pag As Integer
    Dim MiPer, Cond As String
    Dim tdebito, tcredito, tnitb, tnitd, tnitc, tcuentab, tcuentad, tcuentac As Double
    Dim FechaRep As String

    Private Sub FrmCertificadoRete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtfecha.Value = Today
        Dim ano As String = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        LB1.Text = "Que en el año gravable " & ano & ", " & tablacomp.Rows(0).Item("descripcion") & " NIT. " & tablacomp.Rows(0).Item("nit") & ", le practicó retención en la fuente a título de renta a y por el siguiente(s) concepto(s): "
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChCorreo.CheckedChanged
        If ChCorreo.Checked = True Then
            txtcorreo.Enabled = True
        Else
            txtcorreo.Enabled = False
        End If
    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        ValidarNIT(txtnit, e)
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            MsgBox("El NIT no se encuetra en los registros, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            ' txtnit.Focus()
            txtnombre.Text = ""
            txtcorreo.Text = ""
            Try
                FrmSelCliente.lbform.Text = "cerret"
                FrmSelCliente.ShowDialog()
            Catch ex As Exception
            End Try
        Else
            txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
            txtcorreo.Text = tabla.Rows(0).Item("correo")
        End If
    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit='" & txtnit.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count = 0 Then
            txtnombre.Text = ""
            txtcorreo.Text = ""
        Else
            txtnombre.Text = tabla.Rows(0).Item("nombre") & " " & tabla.Rows(0).Item("apellidos")
            txtcorreo.Text = tabla.Rows(0).Item("correo")
        End If
    End Sub

    Private Sub txtcd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcd.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtexpedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtexpedido.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtfecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtcorreo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorreo.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click
        If Trim(txtnombre.Text) = "" Then
            MsgBox("Verifique el nit del tercero.  ", MsgBoxStyle.Information, "Verificando ")
            txtnit.Focus()
            Exit Sub
        End If
        If Trim(txtcd.Text) = "" Then
            MsgBox("Verifique Ciudad, Departammento de la Dirección de Impuestos y Aduanas Nacionales – DIAN.  ", MsgBoxStyle.Information, "Verificando ")
            txtcd.Focus()
            Exit Sub
        End If
        If Trim(txtexpedido.Text) = "" Then
            MsgBox("Verifique Ciudad donde se expide.  ", MsgBoxStyle.Information, "Verificando ")
            txtexpedido.Focus()
            Exit Sub
        End If
        If Trim(txtcorreo.Text) = "" And ChCorreo.Checked = True Then
            MsgBox("Verifique Correo destino del certificado.  ", MsgBoxStyle.Information, "Verificando ")
            txtcorreo.Focus()
            Exit Sub
        End If
        GenerarPDF()
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub
    Public Sub GenerarPDF()
        Dim sw As Integer = 0
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
        Dim tope As Integer
        Dim suma As Double = 0
        Dim base As Double = 0
        '**********    Buscar Cuentas Del Informe   ********
        Dim tabla, ttri, tnit As New DataTable
        myCommand.CommandText = "SELECT * FROM tributarios WHERE num='4';"
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
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '***************************************************************
            Banner()
            Dim per As String = ""
            '**********    Buscar Cuentas Del Informe   ********
            k = k - 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Concepto", 70, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Base", 300, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Retención", 400, k, 0)
            For i = 1 To 5
                If ttri.Rows(0).Item("cuenta" & i).ToString = "" Then Exit For
                For j = 0 To 12
                    If j < 10 Then
                        per = "0" & j
                    Else
                        per = j
                    End If
                    tnit.Clear()
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "SELECT SUM(debito - credito), SUM(base) FROM documentos" & per & " WHERE codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "' AND nit='" & txtnit.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tnit)
                    Try
                        suma = CDbl(tnit.Rows(0).Item(0))
                    Catch ex As Exception
                        suma = 0
                    End Try
                    Try
                        base = CDbl(tnit.Rows(0).Item(1))
                    Catch ex As Exception
                        suma = 0
                    End Try
                Next
                tabla.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT descripcion FROM selpuc WHERE codigo = '" & ttri.Rows(0).Item("cuenta" & i).ToString & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If suma <> 0 Then
                    k = k - 10
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tabla.Rows(0).Item("descripcion"), 70, k, 0)
                    If base < 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$" & Moneda(-1 * base), 300, k, 0)
                    Else
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$" & Moneda(base), 300, k, 0)
                    End If
                    If suma < 0 Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$" & Moneda(-1 * suma), 400, k, 0)
                    Else
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "$" & Moneda(suma), 400, k, 0)
                    End If
                End If
            Next
            k = k - 20
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "2.", 20, k, 0)
            Control_de_linea(Trim(LB3.Text & lb.Text & " " & txtcd.Text), 30, 125)
            k = k - 20
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "3.", 20, k, 0)
            Control_de_linea(Trim("Se expide, en " & txtexpedido.Text & ", a los " & txtfecha.Value.Day & " días del mes " & txtfecha.Value.Month & " de " & txtfecha.Value.Year), 30, 125)
            Dim tablacomp As New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            k = k - 20
            cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, k, 0)
            k = k - 10
            cb.EndText()
            'Forzamos vaciamiento del buffer.
            pdfw.Flush()
            oDoc.Close()
            'ABRIR FORMULARIO DESEADO

            If ChCorreo.Checked = True Then
                Dim resultado As MsgBoxResult
                resultado = MsgBox("¿Desea enviar el certificado por email?  ", MsgBoxStyle.YesNo, "Confirmando")
                If resultado = MsgBoxResult.Yes Then
                    sw = 1
                    cb = Nothing
                    pdfw = Nothing
                    oDoc = Nothing
                    EnviarEmail("hotmail", "rl-ingenieria@hotmail.com", "rlingenieria", My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf", LB1.Text, txtcorreo.Text, "", "CERTIFICADO DE RETENCIÓN EN LA FUENTE")
                End If
            End If
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox("ERROR al momento de generar reporte, verifique que  no  lo esten utilizando..." & ex.ToString, MsgBoxStyle.Critical, "SAE")
        Finally
            If sw = 0 Then
                cb = Nothing
                pdfw = Nothing
                oDoc = Nothing
            End If
        End Try
    End Sub
    Public Sub Banner()
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 800
        cb.ShowTextAligned(50, tablacomp.Rows(0).Item("descripcion"), 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "N.I.T. " & tablacomp.Rows(0).Item("nit"), 20, k, 0)
        k = k - 10
        Dim cad As String = ""
        If Trim(tablacomp.Rows(0).Item("direccion")) <> "" Then
            cad = cad & Trim(tablacomp.Rows(0).Item("direccion"))
        End If
        If Trim(tablacomp.Rows(0).Item("telefono1")) <> "" Then
            cad = cad & " Teléfono " & Trim(tablacomp.Rows(0).Item("telefono1"))
        End If
        cb.ShowTextAligned(50, Trim(cad), 20, k, 0)
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CERTIFICADO DE RETENCIÓN EN LA FUENTE A TITULO DE RENTA", 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Artículo 381 del Estatuto Tributario Nacional", 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CERTIFICA:", 300, k, 0)
        '********************************************************************
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "1.", 20, k, 0)
        Control_de_linea(LB1.Text, 30, 125)
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Nombre: " & Trim(txtnombre.Text), 30, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Identificación: " & txtnit.Text, 30, k, 0)

    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal x As Integer, ByVal tam As Integer)
        Dim linea As String = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = " " Or cadena(i) = "," Or cadena(i) = "." Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                    linea = ""
                    k = k - 10
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), x, k, 0)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If n2.Checked = True Then
            If txtnit.Text = "" Then
                MsgBox("Digite el NIT ")
            Else
                Dim cadC As String = ""
                Dim tablaT As New DataTable
                tablaT = New DataTable
                myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5 " _
                & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10,	cuenta11,	cuenta12, cuenta13 , cuenta14 , cuenta15    FROM tributarios WHERE num = '4' ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tablaT)
                If tablaT.Rows.Count > 0 Then
                    For i = 0 To 14
                        If Trim(tablaT.Rows(0).Item(i)) <> "" Then
                            cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                        End If
                    Next
                End If
                cadC = Strings.Left(cadC, cadC.Length - 2)
                Try
                    certificado(cadC)
                Catch ex As Exception
                End Try
            End If
        Else
            Dim cadC As String = ""
            Dim tablaT As New DataTable
            tablaT = New DataTable
            myCommand.CommandText = "SELECT cuenta1, cuenta2, cuenta3, cuenta4,	cuenta5 " _
            & " cuenta6, cuenta7, cuenta8, cuenta9,	cuenta10,	cuenta11,	cuenta12, cuenta13 , cuenta14 , cuenta15   FROM tributarios WHERE num = '4' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablaT)
            If tablaT.Rows.Count > 0 Then
                For i = 0 To 14
                    If Trim(tablaT.Rows(0).Item(i)) <> "" Then
                        cadC = cadC & "'" & tablaT.Rows(0).Item(i) & "'" & ", "
                    End If
                Next
            End If
            cadC = Strings.Left(cadC, cadC.Length - 2)
            '  Try
            certificado(cadC)
            'Catch ex As Exception
            '    'MsgBox("Error al Generar el Informe, " & ex.ToString, MsgBoxStyle.Information, "SAE")
            'End Try
        End If

    End Sub

    Private Sub certificado(ByVal cadC As String)

        Try

       
            Dim nom As String = ""
            Dim nomR As String = ""
            Dim nit As String = ""
            Dim Cnit As String = ""
            Dim nitR As String = ""
            Dim dir As String = ""
            Dim tel As String = ""
            Dim sql As String = ""
            Dim ciudad As String = ""
            Dim per As String = ""
            Dim dnit As String = ""
            Dim msg As String = ""


            nomR = txtnombre.Text
            nitR = "3. Se expide en " & txtexpedido.Text & " , " & txtfecha.Text
            ciudad = txtexpedido.Text
            per = PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString


            MiConexion(bda)
            Cerrar()

            Dim tabla2 As New DataTable
            tabla2 = New DataTable
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)

            nom = tabla2.Rows(0).Item("descripcion")
            nit = "NIT: " & tabla2.Rows(0).Item("nit")
            dir = tabla2.Rows(0).Item("direccion")
            tel = "Telefono: " & tabla2.Rows(0).Item("telefono1") & " - " & tabla2.Rows(0).Item("telefono1")


            msg = "1. Que el año gravable " & per & ", " & nom & " " & nit & ", le practico retencion en la fuente a titulo de renta a y por el siguiente(s) conceptos(s): "

            Dim conexion As New MySqlConnection
            Dim cadena As String
            cadena = datosconR(bda)
            conexion.ConnectionString = cadena
            conexion.Open()


            Dim pi As String = ""
            Dim p As String = ""
            Dim con As String = ""
            Dim cad As String = ""
            Dim nt As String = ""


            '' ///////////////// NIT
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If i <> 12 Then
                    con = con & " SELECT   d.nit  FROM  selpuc s , documentos" & p & " d  " _
                     & " WHERE  s.codigo = d.codigo  AND s.codigo IN (" & cadC & ")  UNION "
                Else
                    con = con & " SELECT   d.nit  FROM  selpuc s , documentos" & p & " d  " _
                     & " WHERE  s.codigo = d.codigo  AND s.codigo IN (" & cadC & ")  "
                End If
            Next

            Dim tb As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = con
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)


            If tb.Rows.Count > 0 Then
                cad = "( "
                For j = 0 To tb.Rows.Count - 1
                    If j <> tb.Rows.Count - 1 Then
                        cad = cad & " '" & tb.Rows(j).Item(0) & "', "
                    Else
                        cad = cad & " '" & tb.Rows(j).Item(0) & "' "
                    End If

                Next
                cad = cad & " )"
            End If



            If n1.Checked = True Then
                'If tb.Rows.Count > 0 Then
                '    nt = "AND d.nit IN " & cad & " "
                'End If
            Else
                nt = " AND d.nit = '" & txtnit.Text & "' "
            End If
            ''/////////////////
            sql = "SELECT nitcod, concepto, nitc, nomnit, fecha, ccosto, doc, descrip, descto, tasa, ctaret FROM("
            sql = sql & "SELECT c.nitcod, c.descrip as concepto, c.nitc,  TRIM( CONCAT(t.nombre,' ', t.apellidos)) AS nomnit, c.fecha, c.ccosto," _
                & " c.doc, c.concepto as descrip, sum(c.descto) as descto ,(SUM(c.tasa)*-1) as tasa, TRIM(CONCAT( t.telefono,' ', t.celular)) AS ctaret from ("
            '(d.debito - d.credito )as tasa 
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If i <> 12 Then
                    sql = sql & " SELECT d.item,  d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc,  " _
               & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
               & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20) ) as doc, " _
               & " d.descri as concepto, d.base as descto,   " _
               & " IF(d.debito<>0 AND LEFT(d.tipodoc,1)='A',(d.debito - d.credito ),CONCAT('-',d.credito)) AS tasa " _
               & " FROM  selpuc s , documentos" & p & " d  " _
               & " WHERE  s.codigo = d.codigo  AND s.codigo IN (" & cadC & ")  " & nt & " UNION "
                Else
                    sql = sql & " SELECT d.item, d.codigo AS nitcod, s.descripcion AS descrip, d.nit as nitc,  " _
             & "  CAST(  CONCAT(right(d.periodo,4), left(d.periodo,2), d.dia )AS DATE ) AS fecha, " _
             & " concat(d.dia,'/',d.periodo) as ccosto,  CAST(concat(d.tipodoc,lpad(d.doc,5,'0')) AS CHAR(20) ) as doc, " _
             & " d.descri as concepto, d.base as descto,  " _
             & " IF(d.debito<>0 AND LEFT(d.tipodoc,1)='A',(d.debito - d.credito ),CONCAT('-',d.credito)) AS tasa " _
             & " FROM  selpuc s , documentos" & p & " d  " _
             & " WHERE  s.codigo = d.codigo  AND s.codigo IN (" & cadC & ") " & nt & " "
                End If
            Next

            sql = sql & ") as c  LEFT JOIN  terceros t ON (c.nitc = t.nit)  GROUP BY nitc, nitcod  ORDER BY   nitc,  nitcod,  fecha ASC "

            sql = sql & " ) AS m WHERE tasa<>0"
            TextBox1.Text = sql

            '& " FROM  selpuc s , documentos" & p & " d LEFT JOIN  terceros t ON (d.nit = t.nit) " _
            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportCertR.rpt")
            CrReport.SetDataSource(tabla)
            FrmReportCertR.CrystalReportViewer1.ReportSource = CrReport

            Try
                Dim Prcompañia As New ParameterField
                Dim PrNit As New ParameterField
                Dim Prperiodo As New ParameterField
                Dim PrtituloG As New ParameterField
                Dim Praño As New ParameterField
                Dim Prciudad As New ParameterField
                Dim PrnomR As New ParameterField
                Dim PrnitR As New ParameterField

                Dim prmdatos As ParameterFields
                prmdatos = New ParameterFields

                Prcompañia.Name = "comp"
                Prcompañia.CurrentValues.AddValue(nom.ToString)

                PrNit.Name = "nit"
                PrNit.CurrentValues.AddValue(nit.ToString)

                Prperiodo.Name = "tel"
                Prperiodo.CurrentValues.AddValue(tel.ToString)

                PrtituloG.Name = "dir"
                PrtituloG.CurrentValues.AddValue(dir.ToString)

                Praño.Name = "msg"
                Praño.CurrentValues.AddValue(msg.ToString)

                PrnomR.Name = "nomR"
                PrnomR.CurrentValues.AddValue(nomR.ToString)

                PrnitR.Name = "nitR"
                PrnitR.CurrentValues.AddValue(nitR.ToString)

                Prciudad.Name = "ciudad"
                Prciudad.CurrentValues.AddValue(ciudad.ToString)

                prmdatos.Add(Prcompañia)
                prmdatos.Add(PrNit)
                prmdatos.Add(Prperiodo)
                prmdatos.Add(PrtituloG)

                prmdatos.Add(PrnomR)
                prmdatos.Add(Praño)
                prmdatos.Add(PrnitR)
                prmdatos.Add(Prciudad)

                FrmReportCertR.CrystalReportViewer1.ParameterFieldInfo = prmdatos
                FrmReportCertR.ShowDialog()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MsgBox("Error al Generar el Informe, " & ex.ToString, MsgBoxStyle.Information, "SAE")
        End Try
    End Sub

    Private Sub n2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles n2.CheckedChanged
        If n2.Checked = True Then
            txtnit.Enabled = True
            txtnombre.Enabled = True
        Else
            txtnit.Enabled = False
            txtnombre.Enabled = False
        End If
    End Sub
End Class