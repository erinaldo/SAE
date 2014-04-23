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
Public Class FrmEst_Cuen_Prop

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub p2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p2.CheckedChanged
        If p2.Checked = True Then
            txtdueño.Enabled = True
            p1.Checked = False
        Else
            txtdueño.Enabled = False
            p1.Checked = True
        End If
    End Sub
    Private Sub txtdueño_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdueño.DoubleClick
        Try
            FrmSelDueño.txtclase.Text = "PROPIETARIO"
            FrmSelDueño.Text = "Seleccionar Propietario del Inmueble"
            FrmSelDueño.lbform.Text = "estado_cuenta"
            FrmSelDueño.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtdueño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdueño.KeyPress
        ValidarNIT(txtdueño, e)
    End Sub

    Private Sub txtdueño_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdueño.LostFocus
        Try
            If txtnomdu.Text = "" Then
                Dim tabla As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT tr.*, concat(t.nombre,' ',t.apellidos) as nom FROM tercerosinm tr  left join terceros t on t.nit=tr.nit WHERE  tr.nit = '" & txtdueño.Text & "' and tr.clase ='DUEÑO DE INMUEBLE';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                If tabla.Rows.Count = 0 Then
                    txtdueño.Text = ""
                    txtnomdu.Text = ""
                    Try
                        FrmSelDueño.txtclase.Text = "PROPIETARIO"
                        FrmSelDueño.Text = "Seleccionar Propietario del Inmueble"
                        FrmSelDueño.lbform.Text = "estado_cuenta"
                        FrmSelDueño.ShowDialog()
                    Catch ex As Exception
                    End Try
                Else
                    txtdueño.Text = tabla.Rows(0).Item("nit")
                    txtnomdu.Text = tabla.Rows(0).Item("nom")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        If p2.Checked = True And txtdueño.Text = "" Then
            MsgBox("Verifique el nit del propietario", MsgBoxStyle.Information, "Verificacion")
            txtdueño.Focus()
            Exit Sub
        End If
        Dim cad As String = ""
        If p2.Checked = True Then
            cad = " WHERE nit_d='" & txtdueño.Text & "'"
        End If

        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT DISTINCT nit_d FROM contrato_inm " & cad & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()

        Dim nit As String = ""
        If tc.Rows.Count > 0 Then

            If p2.Checked = True And txtdueño.Text <> "" Then
                nit = "'" & txtdueño.Text & "'"
            Else
                For i = 0 To tc.Rows.Count - 1
                    nit = nit & "'" & tc.Rows(i).Item(0) & "',"
                Next
                nit = Strings.Left(nit, Strings.Len(nit) - 1)
            End If
        Else
            MsgBox("No hay contratos creados", MsgBoxStyle.Information, "SAE")
            Exit Sub
        End If

        ' Try
        If p2.Checked = True And txtdueño.Text = "" Then
            MsgBox("Verifique el nit del propietario", MsgBoxStyle.Information, "Verificacion")
            txtdueño.Focus()
            Exit Sub
        End If
        If rbEsta.Checked = True Then
            VerPDF(nit)
        Else
            VerPDFAnt(nit)
        End If
        'Catch ex As Exception
        'End Try

    End Sub
    Private Sub VerPDFAnt(ByVal nit As String)
        Dim nom As String = ""
        Dim nitc As String = ""
        Dim tel As String = ""
        Dim dir As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nitc = tabla2.Rows(0).Item("nit")
        dir = tabla2.Rows(0).Item("direccion")
        tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim sql As String = ""

        
        sql = "SELECT a.nitc AS nitc, a.per_doc AS doc_ext, CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS doc," _
       & " TRIM(CONCAT(t.apellidos,' ',t.nombre)) AS nomnit, a.monto AS subtotal, a.causado AS total, (a.monto - a.`causado`) AS v_viva, a.concepto as concepto " _
       & " FROM  terceros t, ant_a_prov a " _
       & " WHERE a.nitc = t.nit AND a.nitc IN (" & nit & ") and a.monto<> a.causado " _
       & " ORDER BY nomnit, a.fecha"

        
        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myCommand.Connection = conexion
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")

        'myCommand.Parameters.Clear()
        'myCommand.CommandText = "SELECT * FROM  `ant_a_prov` "
        'myCommand.Connection = conexion
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(tabla, "cobdpen")


        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportEstCProAnt.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtel As New ParameterField
            Dim Prdir As New ParameterField

            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)

            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitc.ToString)

            Prtel.Name = "telf"
            Prtel.CurrentValues.AddValue(tel.ToString)

            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue(dir.ToString)

            

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub VerPDF(ByVal nit As String)

        Dim nom As String = ""
        Dim nitc As String = ""
        Dim tel As String = ""
        Dim dir As String = ""
        Dim email As String = ""
        Dim cad1 As String = ""
        Dim cadf As String = ""


        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nitc = tabla2.Rows(0).Item("nit")
        dir = tabla2.Rows(0).Item("direccion")
        tel = tabla2.Rows(0).Item("telefono1") & " " & tabla2.Rows(0).Item("telefono2")
        email = tabla2.Rows(0).Item("emailconta")

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        If p2.Checked = True Then
            cad1 = " AND cp.nitc='" & txtdueño.Text & "' "
            cadf = " and t.nit ='" & txtdueño.Text & "'"
        End If

        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim sql4 As String = ""
        Dim p As String = ""
        For l = 1 To 12
            If l <= 9 Then
                p = "0" & l
            Else
                p = l
            End If
            If l <> 12 Then
                sql4 = sql4 & "SELECT cp.nitc, o.doc, o.descrip, o.base,  CAST(CONCAT(o.tipo,o.valor) AS SIGNED) as valor FROM `otcon_comp" & p & "` o, ctas_x_pagar cp  WHERE o.doc=cp.doc " & cad1 & " UNION "
            Else
                sql4 = sql4 & "SELECT cp.nitc, o.doc, o.descrip, o.base,  CAST(CONCAT(o.tipo,o.valor) AS SIGNED)as valor FROM `otcon_comp" & p & "` o, ctas_x_pagar cp  WHERE o.doc=cp.doc " & cad1 & " "
            End If
        Next



        '        sql = " SELECT c.nitc, c.`nomnit` AS nomnit , CONCAT(t.telefono,' ', t.telconta) AS  ctasubtotal, " _
        ' & " t.dir AS descrip,  " _
        ' & " CAST(CONCAT(RIGHT(ci.fechaini,2),'/',MID(ci.fechaini,6,2),'/',LEFT(ci.fechaini,4)) AS CHAR(15)) AS fech,  " _
        ' & " c.doc as ctaret, c.descrip AS codContr, i.direccion AS doc_ext, ci.nomb_arr AS concepto, c.pagare AS moneda, (p.subtotal+p.v_viva) AS vpos ,  " _
        ' & " ci.por_comi AS iva,  " _
        ' & " ((p.subtotal+p.v_viva)* ci.por_comi/100) AS tasa,  " _
        ' & " (((p.subtotal+p.v_viva)* ci.por_comi/100)*(ci.por_iva/100)) AS v_viva,   " _
        ' & " ci.rtf AS retiva,   " _
        ' & " c.total AS pagado,  " _
        '& " IFNULL((SELECT SUM(monto -causado) FROM ant_a_prov WHERE nitc = c.nitc),0) AS ret,   " _
        '& " IFNULL((SELECT SUM(total-pagado) FROM cobdpen WHERE nitc = c.nitc),0) AS total,  " _
        '& "  (c.total-c.pagado) AS subtotal,   " _
        '& " (SELECT rcpos FROM ctas_x_pagar WHERE num = (SELECT MAX(num) FROM ctas_x_pagar WHERE tipafec = 'CNT' AND descrip = ci.cod_contra) LIMIT 1) AS ctaretiva ,  " _
        '& " (SELECT  CAST(CONCAT( RIGHT(c.fecha, 2), '/', MID(c.fecha, 6, 2), '/',LEFT(c.fecha, 4) ) AS CHAR(20)) FROM ctas_x_pagar WHERE `rcpos` =  (SELECT  MAX(num) FROM ctas_x_pagar WHERE tipafec = 'CNT' AND descrip = ci.cod_contra)) AS ctaiva,  " _
        '& " ci.periodo AS ctaretica,  CONCAT(t.cta_banco1,IF(t.cbanco<>'',CONCAT(' BANCO: ',t.cbanco),'')) AS rcpos,   " _
        '& " c.retiva AS retica" _
        '& " FROM ctas_x_pagar c, cobdpen p, terceros t,  inmuebles i, contrato_inm ci  " _
        '& " WHERE c.nitc IN (" & nit & ") AND c.`tipafec` ='CNT' AND i.codigo = ci.cod_inm AND ci.cod_contra= c.descrip AND t.nit= c.nitc AND c.total > c.pagado  " _
        '& " AND c.doc=p.doc  " _
        '& "ORDER BY c.nitc, ctaret "
        '        '///////////////////////////////////////

        sql = "SELECT doc AS ctaret, direccion AS doc_ext, noma AS concepto, dias AS moneda, valor AS vpos, por_comi AS iva, vcomi AS tasa," _
 & " iva AS v_viva, otrosp AS retica, totalp AS pagado, saldo AS subtotal, nitp  AS nitc, nomp AS nomnit, dir AS descrip,  " _
 & " telefono AS ctasubtotal, cta AS rcpos,  " _
 & " IFNULL((SELECT SUM(monto -causado) FROM ant_a_prov WHERE nitc = nitp),0) AS ret, IFNULL((SELECT SUM(total-pagado) FROM cobdpen WHERE nitc = nitp),0) AS total FROM("

        For k = 1 To Int(cbper.Text)
            If k <= 9 Then
                p = "0" & k
            Else
                p = k
            End If
            If k <> Int(cbper.Text) Then
                sql = sql & "SELECT fi.doc, i.direccion, fi.noma, fi.dias, fi.valor, fi.por_comi, fi.vcomi, fi.iva, fi.otrosp, totalp, (ct.total- ct.pagado) AS saldo, " _
                & "  fi.nitp, fi.nomp, t.dir, t.telefono, CONCAT(t.cta_banco1,IF(t.cbanco<>'',CONCAT(' BANCO: ',t.cbanco),'')) AS cta " _
                & "  FROM facturainm" & p & " fi, inmuebles i, contrato_inm c, ctas_x_pagar ct, terceros t " _
                & " WHERE i.codigo = c.cod_inm And c.cod_contra = fi.codcontrato And ct.doc = fi.doc " _
                & " AND ct.total > ct.pagado AND t.nit= fi.nitp " & cadf & " UNION "
                'sql = sql & "SELECT cp.nitc, o.doc, o.descrip, o.base,  CAST(CONCAT(o.tipo,o.valor) AS SIGNED) as valor FROM `otcon_comp" & p & "` o, ctas_x_pagar cp  WHERE o.doc=cp.doc UNION "
            Else
                sql = sql & "SELECT fi.doc, i.direccion, fi.noma, fi.dias, fi.valor, fi.por_comi, fi.vcomi, fi.iva, fi.otrosp, totalp, (ct.total- ct.pagado) AS saldo, " _
              & "  fi.nitp, fi.nomp, t.dir, t.telefono, CONCAT(t.cta_banco1,IF(t.cbanco<>'',CONCAT(' BANCO: ',t.cbanco),'')) AS cta " _
              & "  FROM facturainm" & p & " fi, inmuebles i, contrato_inm c, ctas_x_pagar ct, terceros t " _
              & " WHERE i.codigo = c.cod_inm And c.cod_contra = fi.codcontrato And ct.doc = fi.doc " _
              & " AND ct.total > ct.pagado AND t.nit= fi.nitp " & cadf & " "
                'sql = sql & "SELECT cp.nitc, o.doc, o.descrip, o.base,  CAST(CONCAT(o.tipo,o.valor) AS SIGNED)as valor FROM `otcon_comp" & p & "` o, ctas_x_pagar cp  WHERE o.doc=cp.doc "
            End If
        Next
        sql = sql & ") as c ORDER BY nitc, ctaret"

        '//////////////////////////////////////

        sql2 = "SELECT a.nitc AS nitc,a.fecha,  a.concepto AS descrip, a.monto AS subtotal, (a.monto - a.causado) AS total, " _
        & " CAST( (CONCAT( RIGHT( a.fecha , 2 ) ,  '/', MID(a.fecha ,  6, 2 ) ,  '/', LEFT( a.fecha , 4 ) ) ) AS CHAR( 20 ) ) AS ctaret " _
        & " FROM  terceros t, ant_a_prov a   " _
        & " WHERE a.nitc = t.nit AND a.nitc IN (" & nit & ") AND a.monto<> a.causado  ORDER BY a.nitc, a.fecha"

        sql3 = " SELECT c.nitc AS nitc, c.doc AS doc, c.concepto AS descrip, c.total AS subtotal, (c.total-c.pagado) AS descuento," _
        & " CAST(CONCAT(RIGHT(c.fecha,2),'/',MID(c.fecha,6,2),'/',LEFT(c.fecha,4)) AS CHAR(15)) AS nitv " _
        & " FROM cobdpen c WHERE c.nitc IN (" & nit & ") AND c.total > c.pagado "

        Dim tabla As DataSet
        tabla = New DataSet

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql2
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "cobdpen")

        myCommand.Parameters.Clear()
        myCommand.CommandText = sql3
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "facturas01")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "select logo as logofac from parcontrato "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "parafacts")


        '" SELECT nitc AS codart, doc, descrip AS nomart, valor , base AS vtotal FROM ( " & sql4 & ") as t order by doc"
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT nitc AS codart, descr AS nomart, CAST( CONCAT(tipo,valor) AS SIGNED) AS valor" _
        & " FROM otcon_contrato WHERE tcli='PROPIETARIO'  AND contb<>'S' ORDER BY nitc"
        'myCommand.CommandText = " SELECT nitc AS codart, doc, descrip AS nomart, valor , base AS vtotal FROM ( " & sql4 & ") as t order by doc"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla, "detafac01")

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\RInmobiliaria\ReportEstCuen_Pro.rpt")
        CrReport.SetDataSource(tabla)
        FrmVisorInformes.CrystalReportViewer1.ReportSource = CrReport

        Dim cad As String = ""
        If dir <> "" Then
            cad = cad & " DIRECCION: " & dir
        End If
        If tel <> "" Then
            cad = cad & " TELEFONO: " & tel
        End If
        If email <> "" Then
            cad = cad & " EMAIL: " & email
        End If
        Dim mesp As String = ""
        Select Case cbper.Text
            Case "01"
                mesp = "FEBRERO"
            Case "02"
                mesp = "MARZO"
            Case "03"
                mesp = "ABRIL"
            Case "04"
                mesp = "MAYO"
            Case "05"
                mesp = "JUNIO"
            Case "06"
                mesp = "JULIO"
            Case "07"
                mesp = "AGOSTO"
            Case "08"
                mesp = "SEPTIEMBRE"
            Case "09"
                mesp = "OCTUBRE"
            Case "10"
                mesp = "NOVIEMBRE"
            Case "11"
                mesp = "DICIEMBRE"
            Case "12"
                mesp = "ENERO"
        End Select

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtel As New ParameterField
            Dim Prdir As New ParameterField
            Dim Prpag As New ParameterField
            Dim Prfp As New ParameterField
            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nitc.ToString)
            Prtel.Name = "telf"
            Prtel.CurrentValues.AddValue("")
            Prdir.Name = "dir"
            Prdir.CurrentValues.AddValue(cad)
            Prpag.Name = "perpago"
            'Prpag.CurrentValues.AddValue(cbper.Text & Strings.Right(PerActual, 5))
            Prpag.CurrentValues.AddValue(mesp)

            Prfp.Name = "fpago"
            Prfp.CurrentValues.AddValue(txtdi1.Text & "/" & cbmes.Text & txtmes.Text)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prtel)
            prmdatos.Add(Prdir)
            prmdatos.Add(Prpag)
            prmdatos.Add(Prfp)
            FrmVisorInformes.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmVisorInformes.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub
  

    Private Sub txtdueño_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdueño.TextChanged
        If txtdueño.Text = "" Then
            txtnomdu.Text = ""
        End If
    End Sub

    Private Sub FrmEst_Cuen_Prop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = Strings.Left(PerActual, 2)
        txtmes.Text = Strings.Right(PerActual, 5)
    End Sub

    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        If Int(cbper.Text) <= 9 Then
            cbmes.Text = "0" & Int(cbper.Text) + 1
        ElseIf Int(cbper.Text) >= 10 And Int(cbper.Text) < 12 Then
            cbmes.Text = Int(cbper.Text) + 1
        ElseIf Int(cbper.Text) = 12 Then
            cbmes.Text = "01"
        End If

    End Sub

    Private Sub txtdi1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdi1.LostFocus
        If Int(txtdi1.Text) < 9 Then
            txtdi1.Text = "0" & Int(txtdi1.Text)
        End If
    End Sub
End Class