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

Public Class FrmInfoterceros

    Public ent, sal As String

    Private Sub c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.CheckedChanged
        If c2.Checked = True Then
            txttip.Enabled = True
            chcli.Visible = True
            chcli.Checked = False
        Else
            txttip.Enabled = False
            chcli.Visible = False
            chcli.Checked = False
        End If
    End Sub

    Private Sub txttip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttip.DoubleClick
        FrmSelCliente.txtcuenta.Text = txttip.Text
        FrmSelCliente.lbform.Text = "inv_ter"
        FrmSelCliente.ShowDialog()
    End Sub

    Private Sub txttip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttip.TextChanged
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE terceros.nit='" & txttip.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <> 0 Then
            txtnom.Text = tabla.Rows(0).Item("apellidos").ToString & " " & tabla.Rows(0).Item("nombre").ToString
        Else
            txtnom.Text = ""
        End If
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

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
            Dim cad As String = ""


            If ComboBox1.Text <> "TODOS" Then
                cad = cad & " AND t.tipo= '" & ComboBox1.Text & "' "
            End If
            If d1.Checked = True Then
                cad = cad & " AND m.estado = 'AP' "
            Else
                cad = cad & " AND m.estado =  '' "
            End If
            If c2.Checked = True Then
                cad = cad & " AND t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' "
            End If


            sql = sql & "nit, nombre, apellidos, tipo"
            For i = Val(cbini.Text) To Val(cbfin.Text)

                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If p = cbini.Text Then
                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, CONCAT(d.codart,'-',d.nomart)as dir, " _
                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc  " & cad

                Else
                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, CONCAT(d.codart,'-',d.nomart) as dir, " _
                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc  " & cad

                End If
            Next
            '  sql = sql & "ORDER BY codart"
            TextBox1.Text = sql



            ' '' ---------------------------------------------------
            ' '' --------------- TODOS LOS DOCUMENTOS ---------------
            'If c1.Checked = True Then

            '    ' tipo cliente, empleado , otros, 
            '    If ComboBox1.Text <> "TODOS" Then

            '        '    '    ' --------------- CODIGOS APROBADOS ---------------
            '        If d1.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "'  AND m.estado =  'AP' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "' AND m.estado =  'AP'  "

            '                End If
            '            Next
            '            '  sql = sql & "ORDER BY codart"

            '            TextBox1.Text = sql

            '        End If
            '        '    '    ' -----------FIN---- CODIGOS APROBADOS ---------------

            '        '    '    ' --------------- CODIGOS NO APROBADOS ---------------
            '        If d2.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "'  AND m.estado =  '' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "' AND m.estado =  ''  "

            '                End If
            '            Next
            '            TextBox1.Text = sql

            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS NO APROBADOS ---------------


            '    Else

            '        '    '    ' --------  CODIGOS APROBADOS ---------------
            '        If d1.Checked = True Then
            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND m.estado =  'AP' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND m.estado =  'AP'  "

            '                End If
            '            Next
            '            TextBox1.Text = sql
            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS APROBADOS ---------------


            '        '    '    ' --------------- CODIGOS NO APROBADOS ---------------
            '        If d2.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND m.estado =  '' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE(t.nit = m.nitc) AND d.doc = m.doc AND m.estado =  ''  "

            '                End If
            '            Next
            '            TextBox1.Text = sql
            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS NO APROBADOS ---------------
            '    End If

            'End If
            '' '' ---------------------------------------------------
            '' '' -------------FIN -- TODOS LOS DOCUMENTOS ---------------
            '' ////////////////////////////////////////////////////////////////////



            '' '' ------------------------------------------
            '' '' --------------- UN NIT ---------------
            'If c2.Checked = True Then

            '    ' tipo cliente, empleado , otros, 
            '    If ComboBox1.Text <> "TODOS" Then

            '        '    '    ' --------------- CODIGOS APROBADOS ---------------
            '        If d1.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "'  AND m.estado =  'AP' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "' AND m.estado =  'AP'  "

            '                End If
            '            Next
            '            '  sql = sql & "ORDER BY codart"

            '            TextBox1.Text = sql

            '        End If
            '        '    '    ' -----------FIN---- CODIGOS APROBADOS ---------------

            '        '    '    ' --------------- CODIGOS NO APROBADOS ---------------
            '        If d2.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "'  AND m.estado =  '' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND t.tipo= '" & ComboBox1.Text & "' AND m.estado =  ''  "

            '                End If
            '            Next
            '            TextBox1.Text = sql

            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS NO APROBADOS ---------------


            '    Else

            '        '    '    ' --------  CODIGOS APROBADOS ---------------
            '        If d1.Checked = True Then
            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND m.estado =  'AP' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND m.estado =  'AP'  "

            '                End If
            '            Next
            '            TextBox1.Text = sql
            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS APROBADOS ---------------


            '        '    '    ' --------------- CODIGOS NO APROBADOS ---------------
            '        If d2.Checked = True Then

            '            For i = Val(cbini.Text) To Val(cbfin.Text)

            '                If i < 10 Then
            '                    p = "0" & i
            '                Else
            '                    p = i
            '                End If
            '                If p = cbini.Text Then
            '                    sql = " SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                    & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                    & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                    & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND m.estado =  '' "

            '                Else

            '                    sql = sql & " UNION SELECT t.nit, t.nombre, t.apellidos, t.tipo, m.doc as fax, CONCAT( m.dia,  '/', m.per ) AS persona, d.bod_ori as pais, d.bod_des as dept, m.concepto as dir, " _
            '                   & "IF( d.bod_ori <>0, 0, cantidad ) AS telefono, IF( d.bod_des <>0, 0, cantidad ) AS celular, d.valor AS cupo, " _
            '                   & " IF( d.bod_ori <>0, 0, (cantidad * d.valor) ) AS mes, IF( d.bod_des <>0, 0, (cantidad * d.valor) ) AS telconta " _
            '                   & "FROM deta_mov" & p & " d, movimientos" & p & " m, terceros t WHERE t.nit='" & txttip.Text & "' AND  m.nitc='" & txttip.Text & "' AND d.doc = m.doc AND m.estado =  ''  "

            '                End If
            '            Next
            '            TextBox1.Text = sql
            '        End If
            '        '    '    ' -------- FIN ------- CODIGOS NO APROBADOS ---------------
            '    End If




            'End If
            ' '' ---------------------------------------------------------------
            ' '' -------------FIN-- UN CODIGO ---------------



            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)

            Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportMovTer.rpt")
            CrReport.SetDataSource(tabla)
            CrReport.PrintOptions.PaperSize = PaperSize.PaperA4
            FrmRepMovTer.CrystalReportViewer1.ReportSource = CrReport


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

                FrmRepMovTer.CrystalReportViewer1.ParameterFieldInfo = prmdatos

            Catch ex As Exception
            End Try

            conexion.Close()
            FrmRepMovTer.ShowDialog()
        Catch ex As Exception

            ' MessageBox.Show("excepcion: " & ex.Message, "Mostrando Reporte")
        End Try


    End Sub

    Public Sub mostrar_PDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\inventarios.pdf"
        Dim cad, t1, t2, t3, t4 As String
        Dim i, i2, j, k, pag, med, niv, pv As Integer
        Dim sum1, sument, sumsal, totalent, totalsal, cant, cant1 As Double
        Dim tabla, tabla1, tabla2 As New DataTable
        Dim cadena, cv, consulta, consulta2, tp, per As String
        Try
            pag = 1
            per = ""
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
            cadena = "KARDEX POR TERCEROS"
            med = 250
            i2 = cadena.Length
            i2 = i2 / 2
            j = med - i2
            cb.ShowTextAligned(50, cadena, j, 760, 0)
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
            k = 730
            cb.EndText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 6)
            cb.BeginText()
            cb.ShowTextAligned(50, "TIPO/NUMERO", 20, k, 0)
            cb.ShowTextAligned(50, "DOCUMENTO", 20, k - 10, 0)
            cb.ShowTextAligned(50, "FECHA", 80, k - 10, 0)
            cb.ShowTextAligned(50, " BODEGAS", 120, k, 0)
            cb.ShowTextAligned(50, "DEST|ORIG", 120, k - 10, 0)
            cb.ShowTextAligned(50, "CONCEPTO", 160, k - 10, 0)
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
                t4 = bda & ".articulos"


                If consulta = "" Then

                    consulta = "(SELECT " & t4 & ".referencia," & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia," & bda & ".terceros.nit," & bda & ".terceros.nombre," & bda & ".terceros.apellidos FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t2 & ".nitc WHERE 1"

                    If c2.Checked = True Then
                        consulta = consulta & " AND " & t2 & ".nitc = '" & txttip.Text & "' "
                    End If

                    If d1.Checked = True Then
                        consulta = consulta & " AND " & t2 & ".estado='AP' "
                    End If

                    If ComboBox1.Text <> "TODOS" Then
                        consulta = consulta & " AND " & bda & ".terceros.tipo='" & ComboBox1.Text & "' "
                    End If

                    consulta = consulta & " ORDER BY " & t2 & ".doc)"
                Else
                    consulta2 = "(SELECT " & t4 & ".referencia," & t1 & ".doc," & t1 & ".item," & t1 & ".codart," & t1 & ".nomart," & t1 & ".bod_ori," & t1 & ".bod_des," & t1 & ".cantidad," & t1 & ".valor," & t2 & ".tipodoc," & t2 & ".num," & t2 & ".per," & t2 & ".nitc," & t2 & ".desc_mov," & t2 & ".concepto," & t2 & ".total," & t2 & ".estado," & t2 & ".dia," & bda & ".terceros.nit," & bda & ".terceros.nombre," & bda & ".terceros.apellidos FROM " & t1 & " INNER JOIN " & t2 & " ON " & t2 & ".doc=" & t1 & ".doc INNER JOIN " & t4 & " ON " & t4 & ".codart=" & t1 & ".codart INNER JOIN " & bda & ".terceros ON " & bda & ".terceros.nit=" & t2 & ".nitc WHERE 1"

                    If c2.Checked = True Then
                        consulta2 = consulta2 & " AND " & t2 & ".nitc = '" & txttip.Text & "' "
                    End If

                    If d1.Checked = True Then
                        consulta2 = consulta2 & " AND " & t2 & ".estado='AP' "
                    End If

                    If ComboBox1.Text <> "TODOS" Then
                        consulta2 = consulta2 & " AND " & bda & ".terceros.tipo='" & ComboBox1.Text & "' "
                    End If

                    consulta = consulta & " UNION " & consulta2 & " ORDER BY " & t2 & ".doc)"
                End If
            Next

            consulta = "SELECT consulta.* FROM (" & consulta & ") AS consulta ORDER BY consulta.nit"

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
                    If tp <> tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString Then
                        If tp <> "" Then
                            cb.EndText()
                            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                            cb.SetFontAndSize(fuente, 7)
                            cb.BeginText()
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 570, k, 0)
                            k = k - 10
                            cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
                            k = k - 15
                            sument = 0
                            sumsal = 0
                            k = k - 20
                        End If
                        cb.EndText()
                        ' k = k - 5
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                        cb.BeginText()
                        tabla1 = New DataTable
                        myCommand.CommandText = "SELECT " & bda & ".con_inv.* FROM " & bda & ".con_inv WHERE " & bda & ".con_inv.codart='" & tabla.Rows(i).Item("codart").ToString & "' AND " & bda & ".con_inv.periodo='" & per & "'"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tabla1)
                        'If l1.Checked = True Then
                        '    tabla2 = New DataTable
                        '    myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                        '    myAdapter.SelectCommand = myCommand
                        '    myAdapter.Fill(tabla2)
                        '    If tabla2.Rows.Count <> 0 Then
                        '        For l = 1 To tabla2.Rows.Count - 1
                        '            cant1 = cant1 + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                        '        Next
                        '    End If
                        'Else
                        '    tabla2 = New DataTable
                        '    myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas WHERE " & bda & ".bodegas.numbod='" & codbod.Value & "' ORDER BY " & bda & ".bodegas.numbod;"
                        '    myAdapter.SelectCommand = myCommand
                        '    myAdapter.Fill(tabla2)
                        '    If tabla2.Rows.Count <> 0 Then
                        '        For l = 1 To tabla2.Rows.Count - 1
                        '            cant1 = cant1 + CDbl(tabla1.Rows(i).Item("cant" & l).ToString)
                        '        Next
                        '    End If
                        'End If
                        cb.ShowTextAligned(50, tabla.Rows(i).Item("nit").ToString & "       " & tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString, 20, k, 0)
                        'cb.ShowTextAligned(50, "CANTIDAD Y COSTOS INICIALES      " & "VALOR INICIAL", 380, k, 0)
                        'k = k - 1
                        'cb.ShowTextAligned(50, "_____________________________________________", 20, k, 0)
                        'k = k - 9
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant1, 420, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                        'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant1) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)

                        k = k - 20
                    End If

                    tp = tabla.Rows(i).Item("apellidos").ToString & " " & tabla.Rows(i).Item("nombre").ToString
                    cb.EndText()
                    fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                    cb.SetFontAndSize(fuente, 7)
                    Refresh()
                    cb.BeginText()
                    'k = k - 10
                    cb.ShowTextAligned(50, tabla.Rows(i).Item("tipodoc").ToString & "  " & NumeroDoc(tabla.Rows(i).Item("num").ToString), 20, k, 0)
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("dia").ToString & "/" & tabla.Rows(i).Item("per").ToString, 105, k, 0)
                    'If Len(tabla.Rows(i).Item("concepto").ToString) > 20 Then
                    cb.ShowTextAligned(50, CambiaCadena(tabla.Rows(i).Item("concepto").ToString, 20), 160, k, 0)
                    ' Else
                    'cb.ShowTextAligned(50, tabla.Rows(i).Item("concepto").ToString, 160, k, 0)
                    'End If

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
                    cant = 0
                    'If l1.Checked = True Then
                    '    tabla2 = New DataTable
                    '    myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas ORDER BY " & bda & ".bodegas.numbod;"
                    '    myAdapter.SelectCommand = myCommand
                    '    myAdapter.Fill(tabla2)
                    '    If tabla2.Rows.Count <> 0 Then
                    '        For l = 1 To tabla2.Rows.Count - 1
                    '            cant = cant + CDbl(tabla1.Rows(0).Item("cant" & l).ToString)
                    '        Next
                    '    End If
                    'Else
                    '    tabla2 = New DataTable
                    '    myCommand.CommandText = "SELECT " & bda & ".bodegas.numbod FROM " & bda & ".bodegas WHERE " & bda & ".bodegas.numbod='" & codbod.Value & "' ORDER BY " & bda & ".bodegas.numbod;"
                    '    myAdapter.SelectCommand = myCommand
                    '    myAdapter.Fill(tabla2)
                    '    If tabla2.Rows.Count <> 0 Then
                    '        For l = 1 To tabla2.Rows.Count - 1
                    '            cant = cant + CDbl(tabla1.Rows(i).Item("cant" & l).ToString)
                    '        Next
                    '    End If
                    'End If

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
                        '    Else
                        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, tabla.Rows(i).Item("cantidad").ToString, 340, k, 0)
                        '    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString)), 570, k, 0)
                        '    sumsal = sumsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                        '    totalsal = totalsal + (CDbl(tabla1.Rows(0).Item("costuni").ToString) * CDbl(tabla.Rows(i).Item("cantidad").ToString))
                        'End If
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
                cadena = "KARDEX POR TERCEROS"
                med = 250
                i2 = cadena.Length
                i2 = i2 / 2
                j = med - i2
                cb.ShowTextAligned(50, cadena, j, 760, 0)
                cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, 750, 0)
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
                cb.ShowTextAligned(50, "CONCEPTO", 160, k - 10, 0)
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
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________________________", 570, k, 0)
                k = k - 10
                cb.EndText()
                fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                cb.SetFontAndSize(fuente, 7)
                cb.BeginText()
                cb.ShowTextAligned(50, "SUBTOTAL " & tp, 20, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sument), 490, k, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(sumsal), 570, k, 0)
                k = k - 15
                'cb.ShowTextAligned(50, "CANTIDAD Y COSTOS FINALES      " & "VALOR FINAL", 380, k, 0)
                'k = k - 8
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, cant, 420, k, 0)
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(tabla1.Rows(0).Item("costuni")), 490, k, 0)
                'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(CDbl(cant) * CDbl(tabla1.Rows(0).Item("costuni"))), 570, k, 0)

                sument = 0
                sumsal = 0
                k = k - 20

            End If

            If tabla.Rows.Count <> 0 Then
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
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try

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

    Private Sub FrmInfoterceros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComboBox1.Text = "TODOS"
        cbfin.Text = PerActual(0) & PerActual(1)
        cbini.Text = PerActual(0) & PerActual(1)
        txtpfin.Text = extraer_cadena2(PerActual, 2, 7)
        txtpini.Text = extraer_cadena2(PerActual, 2, 7)
        Dim tabla As DataTable
        tabla = New DataTable
        myCommand.CommandText = "select * from parinven;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count > 0 Then
            ent = tabla.Rows(0).Item("entradas").ToString
            sal = tabla.Rows(0).Item("salidas").ToString
        End If

        ' CARGAR CLIENTES
        ' AUTOCOMPLETAR NIT CLIENTE
        Try
            txttip.AutoCompleteCustomSource.Clear()

            Dim tb As New DataTable
            tb.Clear()
            myCommand.CommandText = "SELECT TRIM(concat(nombre,' ',apellidos)) as t FROM terceros ORDER BY t ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                For i = 0 To tb.Rows.Count - 1
                    txtnom.AutoCompleteCustomSource.Add(tb.Rows(i).Item(0))
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub
    Public Sub BuscarClientesApell(ByVal nom As String)
        Dim items As Integer
        Dim tablac As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE TRIM(concat(nombre,' ',apellidos)) ='" & nom & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablac)
        Refresh()
        items = tablac.Rows.Count
        If items = 0 Then
            txttip.Text = ""
            FrmSelCliente.lbform.Text = "inv_ter"
            FrmSelCliente.ShowDialog()
        Else
            txttip.Text = Trim(tablac.Rows(0).Item("nit"))
        End If
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub chcli_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chcli.CheckedChanged
        If chcli.Checked = True Then
            txttip.Enabled = False
            txtnom.Enabled = True
        Else
            txtnom.Enabled = False
            txttip.Enabled = True
        End If
    End Sub

    Private Sub txtnom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnom.LostFocus
        Try
            If txtnom.Text = "" Then
                txttip.Text = ""
                FrmSelCliente.lbform.Text = "inv_ter"
                FrmSelCliente.ShowDialog()
            Else
                BuscarClientesApell(txtnom.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


End Class