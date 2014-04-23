Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Drawing.Printing

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

Public Class FrmParaFactRapida
    Private Sub cmdatras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdatras.Click
        cmdatras.Text = "&A"
        If Tab1.Visible = True Then
            cmdatras.Enabled = False
        ElseIf Tab2.Visible = True Then
            Tab1.Visible = True
            Tab2.Visible = False
            cmdatras.Text = ""
            cmdatras.Enabled = False
        ElseIf Tab3.Visible = True Then
            Tab2.Visible = True
            Tab3.Visible = False
            cmdsgt.Text = "&S"
            cmdsgt.Enabled = True
        End If
    End Sub
    Private Sub cmdsgt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsgt.Click
        cmdsgt.Text = "&S"
        If Tab1.Visible = True Then
            If chVend.Checked = True And txtvendedor.Text = "" Then
                MsgBox("Digite el NIT o CC del vendedor para este equipo", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            Else
                Tab1.Visible = False
                Tab2.Visible = True
                cmdatras.Text = "&A"
                cmdatras.Enabled = True
            End If
           
        ElseIf Tab2.Visible = True Then

            If txtcc.Enabled = True Then
                If Txtcc2.Text = "" Or txtcc.Text = "" Then
                    MsgBox("Parametros de conceptos comisionables incompletos")
                Else
                    Tab2.Visible = False
                    Tab3.Visible = True
                    cmdsgt.Text = ""
                    cmdsgt.Enabled = False
                End If
            Else
                Tab2.Visible = False
                Tab3.Visible = True
                cmdsgt.Text = ""
                cmdsgt.Enabled = False
            End If
        ElseIf Tab3.Visible = True Then
            cmdsgt.Enabled = False
        End If

       

    End Sub

    Public Sub Guardar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de facturación " & lbfact.Text & " se van ha registrar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")

        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?factura", lbfact.Text.ToString)
            If rbdoc1.Checked = True Then 'tipo documento FC,AI
                myCommand.Parameters.AddWithValue("?doc", "S")
                myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?doc", "N")
                myCommand.Parameters.AddWithValue("?tipodoc", "".ToString)
            End If
            If rbnumf.Checked = True Then 'numero de factura
                myCommand.Parameters.AddWithValue("?numfact", "automatico")
            Else
                myCommand.Parameters.AddWithValue("?numfact", "manual")
            End If
            If rbinv.Checked = True Then 'afecta inventario?
                myCommand.Parameters.AddWithValue("?afecinv", "S")
            Else
                myCommand.Parameters.AddWithValue("?afecinv", "N")
            End If
            If rbfec1.Checked = True Then 'fecha
                myCommand.Parameters.AddWithValue("?fecha", "automatico")
            ElseIf rbfec2.Checked = True Then
                myCommand.Parameters.AddWithValue("?fecha", "manual")
            Else
                myCommand.Parameters.AddWithValue("?fecha", "predeterminada")
            End If
            If rbclie.Checked = True Then 'nit cliente predeterminado
                myCommand.Parameters.AddWithValue("?nitcpre", "S")
                myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?nitcpre", "N")
                myCommand.Parameters.AddWithValue("?nitc", "".ToString)
            End If
            If rbvendedor.Checked = True Then 'nit vendedor predeterminado
                myCommand.Parameters.AddWithValue("?nitvpre", "S")
                myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?nitvpre", "N")
                myCommand.Parameters.AddWithValue("?nitv", "".ToString)
            End If
            If rbcodinv.Checked = True Then 'mostrar solo codigos de detalles del inventario
                myCommand.Parameters.AddWithValue("?codinv", "S")
            Else
                myCommand.Parameters.AddWithValue("?codinv", "N")
            End If
            If rbcentro.Checked = True Then 'centro de costos
                myCommand.Parameters.AddWithValue("?centrocost", "S")
            Else
                myCommand.Parameters.AddWithValue("?centrocost", "N")
            End If
            If rbfacdifuniemp.Checked = True Then 'facturar diferentes unidades de empaque
                myCommand.Parameters.AddWithValue("?facdifuniemp", "S")
                If ChPA.Checked = True Then
                    myCommand.Parameters.AddWithValue("?precautcant", "S")
                Else
                    myCommand.Parameters.AddWithValue("?precautcant", "N")
                End If
            Else
                myCommand.Parameters.AddWithValue("?facdifuniemp", "N")
                myCommand.Parameters.AddWithValue("?precautcant", "N")
            End If
            If rbbodpre.Checked = True Then 'bodega predeterminada
                myCommand.Parameters.AddWithValue("?bodpre", "S")
                myCommand.Parameters.AddWithValue("?idbod", cbbod.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?bodpre", "N")
                myCommand.Parameters.AddWithValue("?idbod", "".ToString)
            End If
            If rbmarg.Checked = True Then 'controlar precio con margen min
                myCommand.Parameters.AddWithValue("?margmin", "S")
                myCommand.Parameters.AddWithValue("?margen", txtmargen.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?margmin", "N")
                myCommand.Parameters.AddWithValue("?margen", "0,00".ToString)
            End If
            If rbcc.Checked = True Then 'concepto comicionable predeterminado
                myCommand.Parameters.AddWithValue("?concomipre", "S")
                myCommand.Parameters.AddWithValue("?concomi", txtcc.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?concomipre", "N")
                myCommand.Parameters.AddWithValue("?concomi", "")
            End If
            If rbfp.Checked = True Then 'forma de pago predeterminada
                myCommand.Parameters.AddWithValue("?fpagopre", "S")
                If rbcualfp1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "cheque".ToString)
                ElseIf rbcualfp2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "tarjeta".ToString)
                ElseIf rbcualfp3.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "efectivo".ToString)
                ElseIf rbcualfp4.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "otra".ToString)
                End If
            Else
                myCommand.Parameters.AddWithValue("?fpagopre", "N")
                myCommand.Parameters.AddWithValue("?cualfp", "ninguna".ToString)
            End If
            If pdffac.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatfac", "pdf")
                myCommand.Parameters.AddWithValue("?logofac", data)
            ElseIf pdffac2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatfac", "pdf2")
                myCommand.Parameters.AddWithValue("?logofac", data)
            Else
                myCommand.Parameters.AddWithValue("?formatfac", "ticket")
                myCommand.Parameters.AddWithValue("?logofac", "")
            End If
            If pdfped.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatped", "pdf")
                myCommand.Parameters.AddWithValue("?logoped", data2)
            ElseIf pdfped2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatped", "pdf2")
                myCommand.Parameters.AddWithValue("?logoped", data2)
            Else
                myCommand.Parameters.AddWithValue("?formatped", "ticket")
                myCommand.Parameters.AddWithValue("?logoped", "")
            End If
            If pdfcot.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatcot", "pdf")
                myCommand.Parameters.AddWithValue("?logocot", data3)
            ElseIf pdfcot2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatcot", "pdf2")
                myCommand.Parameters.AddWithValue("?logocot", data3)
            Else
                myCommand.Parameters.AddWithValue("?formatcot", "ticket")
                myCommand.Parameters.AddWithValue("?logocot", "")
            End If
            myCommand.Parameters.AddWithValue("?tipocompa", cbregimen.Text)
            myCommand.Parameters.AddWithValue("?comentario", txtcomentario.Text.ToString)
            If rb_imp_decS.Checked = True Then
                myCommand.Parameters.AddWithValue("?imp_dec", "S")
            Else
                myCommand.Parameters.AddWithValue("?imp_dec", "N")
            End If
            If rbBNit.Checked = True Then
                myCommand.Parameters.AddWithValue("?bus_cli", "N")
            Else
                myCommand.Parameters.AddWithValue("?bus_cli", "A")
            End If
            If grNF.Visible = False Then
                myCommand.Parameters.AddWithValue("?Gfac", "N")
            Else
                If rdnf_n.Checked = True Then
                    myCommand.Parameters.AddWithValue("?Gfac", "N")
                Else
                    myCommand.Parameters.AddWithValue("?Gfac", "S")
                End If
            End If
            myCommand.Parameters.AddWithValue("?comen_ini", txtcomentarioini.Text)
            myCommand.CommandText = "INSERT INTO parafacts VALUES(?factura,?doc, ?tipodoc, ?numfact, ?afecinv, " _
                                  & " ?fecha, ?nitcpre, ?nitc, ?nitvpre, ?nitv, ?codinv, " _
                                  & " ?centrocost, ?facdifuniemp, ?precautcant, ?bodpre, ?idbod, " _
                                  & " ?margmin, ?margen, ?concomipre, ?concomi, ?fpagopre,?cualfp, " _
                                  & " ?formatfac,?logofac,?formatped,?logoped,?formatcot,?logocot,?tipocompa,?comentario,?imp_dec,?bus_cli,?Gfac,?comen_ini);"
            myCommand.ExecuteNonQuery()
            'MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()

            '---------------
            Try
                Dim tabla3 As New DataTable
                myCommand.CommandText = "SELECT porcomi FROM concomi where codcon = '" & txtcc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla3)
                Refresh()

                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT nitv FROM vendedores where estado = 'activo';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                Refresh()

                If rbcc2.Checked = False Then
                    If tabla2.Rows.Count <> 0 Then
                        For i = 0 To tabla2.Rows.Count - 1
                            myCommand.CommandText = "INSERT INTO vend_cc VALUES('" & tabla2.Rows(i).Item(0) & "','" & txtcc.Text & "', '" & tabla3.Rows(0).Item(0) & "', '" & Txtcc2.Text & "';"
                            myCommand.ExecuteNonQuery()
                            myCommand.Parameters.Clear()
                            Refresh()
                        Next
                    End If
                End If
            Catch ex As Exception
                '   MsgBox(ex.ToString)
            End Try
            '------------------

            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "GUARDAR PARAMETROS FACTURACION " & lbfact.Text, "", "", "")
            End If
            '.....

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")


            DBCon.Close()
            Me.Close()
        End If
    End Sub
    Public Sub Modificar()
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los parametros de facturación " & lbfact.Text & " se van ha modificar, ¿Desea Guardarlos?. ", MsgBoxStyle.YesNo, "Verificando. ")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)

            '----------------------------------------
            Try
                Dim tabla3 As New DataTable
                myCommand.CommandText = "SELECT concomi FROM parafacts where factura = '" & lbfact.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla3)
                Refresh()

                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM vend_cc WHERE codcon = '" & tabla3.Rows(0).Item(0) & "'  "
                myCommand.ExecuteNonQuery()
                Refresh()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '------------------------------------------

            myCommand.Parameters.Clear()
            Refresh()
            myCommand.Parameters.AddWithValue("?factura", lbfact.Text.ToString)
            If rbdoc1.Checked = True Then 'tipo documento FC,ETC...
                myCommand.Parameters.AddWithValue("?doc", "S")
                myCommand.Parameters.AddWithValue("?tipodoc", txttipo.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?doc", "N")
                myCommand.Parameters.AddWithValue("?tipodoc", "".ToString)
            End If
            If rbnumf.Checked = True Then 'numero de factura
                myCommand.Parameters.AddWithValue("?numfact", "automatico")
            Else
                myCommand.Parameters.AddWithValue("?numfact", "manual")
            End If
            If rbinv.Checked = True Then 'afecta inventario?
                myCommand.Parameters.AddWithValue("?afecinv", "S")
            Else
                myCommand.Parameters.AddWithValue("?afecinv", "N")
            End If
            If rbfec1.Checked = True Then 'fecha
                myCommand.Parameters.AddWithValue("?fecha", "automatico")
            ElseIf rbfec2.Checked = True Then
                myCommand.Parameters.AddWithValue("?fecha", "manual")
            Else
                myCommand.Parameters.AddWithValue("?fecha", "predeterminada")
            End If
            If rbclie.Checked = True Then 'nit cliente predeterminado
                myCommand.Parameters.AddWithValue("?nitcpre", "S")
                myCommand.Parameters.AddWithValue("?nitc", txtnitc.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?nitcpre", "N")
                myCommand.Parameters.AddWithValue("?nitc", "".ToString)
            End If
            If rbvendedor.Checked = True Then 'nit vendedor predeterminado
                myCommand.Parameters.AddWithValue("?nitvpre", "S")
                myCommand.Parameters.AddWithValue("?nitv", txtnitv.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?nitvpre", "N")
                myCommand.Parameters.AddWithValue("?nitv", "".ToString)
            End If
            If rbcodinv.Checked = True Then 'mostrar solo codigos de detalles del inventario
                myCommand.Parameters.AddWithValue("?codinv", "S")
            Else
                myCommand.Parameters.AddWithValue("?codinv", "N")
            End If
            If rbcentro.Checked = True Then 'centro de costos
                myCommand.Parameters.AddWithValue("?centrocost", "S")
            Else
                myCommand.Parameters.AddWithValue("?centrocost", "N")
            End If
            If rbfacdifuniemp.Checked = True Then 'facturar diferentes unidades de empaque
                myCommand.Parameters.AddWithValue("?facdifuniemp", "S")
                If ChPA.Checked = True Then
                    myCommand.Parameters.AddWithValue("?precautcant", "S")
                Else
                    myCommand.Parameters.AddWithValue("?precautcant", "N")
                End If
            Else
                myCommand.Parameters.AddWithValue("?facdifuniemp", "N")
                myCommand.Parameters.AddWithValue("?precautcant", "N")
            End If
            If rbbodpre.Checked = True Then 'bodega predeterminada
                myCommand.Parameters.AddWithValue("?bodpre", "S")
                myCommand.Parameters.AddWithValue("?idbod", cbbod.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?bodpre", "N")
                myCommand.Parameters.AddWithValue("?idbod", "".ToString)
            End If
            If rbmarg.Checked = True Then 'controlar precio con margen min
                myCommand.Parameters.AddWithValue("?margmin", "S")
                myCommand.Parameters.AddWithValue("?margen", txtmargen.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?margmin", "N")
                myCommand.Parameters.AddWithValue("?margen", "0,00".ToString)
            End If
            If rbcc.Checked = True Then 'concepto comicionable predeterminado
                myCommand.Parameters.AddWithValue("?concomipre", "S")
                myCommand.Parameters.AddWithValue("?concomi", txtcc.Text.ToString)
            Else
                myCommand.Parameters.AddWithValue("?concomipre", "N")
                myCommand.Parameters.AddWithValue("?concomi", "")
            End If
            If rbfp.Checked = True Then 'forma de pago predeterminada
                myCommand.Parameters.AddWithValue("?fpagopre", "S")
                If rbcualfp1.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "cheque".ToString)
                ElseIf rbcualfp2.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "tarjeta".ToString)
                ElseIf rbcualfp3.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "efectivo".ToString)
                ElseIf rbcualfp4.Checked = True Then
                    myCommand.Parameters.AddWithValue("?cualfp", "otra".ToString)
                End If
            Else
                myCommand.Parameters.AddWithValue("?fpagopre", "N")
                myCommand.Parameters.AddWithValue("?cualfp", "ninguna".ToString)
            End If
            If pdffac.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatfac", "pdf")
            ElseIf pdffac2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatfac", "pdf2")
            Else
                myCommand.Parameters.AddWithValue("?formatfac", "ticket")
            End If
            If pdfped.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatped", "pdf")
            ElseIf pdfped2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatped", "pdf2")
            Else
                myCommand.Parameters.AddWithValue("?formatped", "ticket")
            End If
            If pdfcot.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatcot", "pdf")
            ElseIf pdfcot2.Checked = True Then
                myCommand.Parameters.AddWithValue("?formatcot", "pdf2")
            Else
                myCommand.Parameters.AddWithValue("?formatcot", "ticket")
            End If
            myCommand.Parameters.AddWithValue("?tipocompa", cbregimen.Text)
            myCommand.Parameters.AddWithValue("?comentario", txtcomentario.Text.ToString)
            If rb_imp_decS.Checked = True Then
                myCommand.Parameters.AddWithValue("?imp_dec", "S")
            Else
                myCommand.Parameters.AddWithValue("?imp_dec", "N")
            End If
            If rbBNit.Checked = True Then
                myCommand.Parameters.AddWithValue("?bus_cli", "N")
            Else
                myCommand.Parameters.AddWithValue("?bus_cli", "A")
            End If
            If lbfact.Text = "NORMAL" Then
                myCommand.Parameters.AddWithValue("?Gfac", "N")
            Else
                If rdnf_n.Checked = True Then
                    myCommand.Parameters.AddWithValue("?Gfac", "N")
                Else
                    myCommand.Parameters.AddWithValue("?Gfac", "S")
                End If
            End If
            myCommand.Parameters.AddWithValue("?comen_ini", txtcomentarioini.Text)

            myCommand.CommandText = "UPDATE parafacts SET doc=?doc, tipodoc=?tipodoc, numfact=?numfact, afecinv=?afecinv, " _
                                 & " fecha=?fecha, nitcpre=?nitcpre, nitc=?nitc, nitvpre=?nitvpre, nitv=?nitv, codinv=?codinv, " _
                                 & " centrocost=?centrocost, facdifuniemp=?facdifuniemp, precautcant=?precautcant, bodpred=?bodpre, idbod=?idbod, " _
                                 & " margmin=?margmin, margen=?margen, concomipre=?concomipre, concomi=?concomi, fpagopre=?fpagopre,cualfp=?cualfp, " _
                                 & " formatfac=?formatfac,formatped=?formatped,formatcot=?formatcot,tipocompa=?tipocompa, comentario=?comentario, " _
                                 & " bus_cli=?bus_cli, imp_dec=?imp_dec,GuarNumFac=?Gfac, comentario_ini=?comen_ini WHERE factura=?factura;"
            myCommand.ExecuteNonQuery()
            If hayfoto = 1 Then
                ModificarPDF("logofac")
            End If
            If hayfoto2 = 1 Then
                ModificarPDF("logoped")
            End If
            If hayfoto3 = 1 Then
                ModificarPDF("logocot")
            End If
            'MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")
            myCommand.Parameters.Clear()
            Refresh()

            '---------------

            Try
                If rbcc.Checked = True Then
                    Dim tabla3 As New DataTable
                    myCommand.CommandText = "SELECT porcomi FROM concomi where codcon = '" & txtcc.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla3)
                    Refresh()

                    Dim tabla2 As New DataTable
                    myCommand.CommandText = "SELECT nitv FROM vendedores where estado = 'activo';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla2)
                    Refresh()

                    Dim i As Integer = 0
                    Dim s As String = ""
                    If tabla2.Rows.Count <> 0 Then

                        For i = 0 To tabla2.Rows.Count - 1
                            's = "INSERT INTO vend_cc VALUES('" & tabla2.Rows(i).Item(0) & "','" & txtcc.Text & "', '" & tabla3.Rows(0).Item(0) & "', '" & Txtcc2.Text & "';"
                            myCommand.CommandText = "INSERT INTO vend_cc VALUES('" & tabla2.Rows(i).Item(0) & "','" & txtcc.Text & "', '" & DIN(tabla3.Rows(0).Item(0)) & "', '" & Txtcc2.Text & "');"
                            myCommand.ExecuteNonQuery()
                            myCommand.Parameters.Clear()
                            Refresh()
                        Next

                    End If

                End If

            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try


            '------------------
            '.....
            If FrmPrincipal.cmdAuditoria.Visible = True Then
                Guar_MovUser("FACTURACION", "MODIFICAR PARAMETROS FACTURACION " & lbfact.Text, "", "", "")
            End If
            '.....

            MsgBox("La Base De Datos Se Actualizó Correctamente", MsgBoxStyle.Information, "Guardar Datos")

            DBCon.Close()
            Me.Close()
        End If
    End Sub
    Public Sub ModificarPDF(ByVal campo As String)
        Try
            myCommand.Parameters.Clear()
            If campo = "logofac" Then
                myCommand.Parameters.AddWithValue("?logo", data)
            ElseIf campo = "logoped" Then
                myCommand.Parameters.AddWithValue("?logo", data2)
            Else
                myCommand.Parameters.AddWithValue("?logo", data3)
            End If
            myCommand.CommandText = "UPDATE parafacts SET " & campo & "=?logo WHERE factura='" & lbfact.Text & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No se pudo guardar la imagen, Error: " & ex.ToString, MsgBoxStyle.Critical, "Control")
        End Try

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
    Private Sub txtnitc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitc.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT nombre,apellidos FROM terceros WHERE nit='" & txtnitc.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtcliente.Text = ""
            Exit Sub
        End If
        txtcliente.Text = tabla.Rows(0).Item(0) & " " & tabla.Rows(0).Item(1)
    End Sub
    Private Sub txtnitv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnitv.TextChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT nombre FROM vendedores WHERE nitv='" & txtnitv.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            txtvendedor.Text = ""
            Exit Sub
        End If
        txtvendedor.Text = tabla.Rows(0).Item(0)
    End Sub
    Private Sub rbvendedor2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbvendedor2.CheckedChanged
        txtnitv.Enabled = False
    End Sub
    Private Sub rbvendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbvendedor.CheckedChanged
        txtnitv.Enabled = True
        chVend.Checked = False
    End Sub
    Private Sub rbclie2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbclie2.CheckedChanged
        txtnitc.Enabled = False
    End Sub
    Private Sub rbclie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbclie.CheckedChanged
        txtnitc.Enabled = True
    End Sub
    Private Sub rbfacdifuniemp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ChPA.Checked = False
        ChPA.Enabled = False
    End Sub
    Private Sub rbfacdifuniemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ChPA.Checked = False
        ChPA.Enabled = True
    End Sub

    '*******************************
    Public pa As New System.Data.SqlClient.SqlParameter("@data", SqlDbType.VarBinary, 50) 'parametro de la sentencia sql
    Public data(), data2(), data3() As Byte 'arreglo de bytes el cual contedra la imagen
    Public ios As FileStream 'Manejo de archivos
    Dim hayfoto, hayfoto2, hayfoto3 As Integer

    Private Sub cmdlogofac_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogofac.Click
        Try
            Me.OPF.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data(ios.Length) 'llenamos el arreglo
                ios.Read(data, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto.Load(Me.OPF.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data 'llenamos la variable parametro con el arreglo
                hayfoto = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub cmdlogoped_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogoped.Click
        Try
            Me.OPF2.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF2.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF2.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data2(ios.Length) 'llenamos el arreglo
                ios.Read(data2, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto2.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto2.Load(Me.OPF2.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data2 'llenamos la variable parametro con el arreglo
                hayfoto2 = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub
    Private Sub cmdlogocot_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogocot.Click
        Try
            Me.OPF3.Filter = "Imagenes (JPG)|*.jpg" 'filtro de archivos del OpenFileDialog 
            If Me.OPF3.ShowDialog() = Windows.Forms.DialogResult.Cancel Then ' en caso de que se aplaste el boton cancelar salga y no haga nada
                Exit Sub
            Else
                ios = New FileStream(Me.OPF3.FileName, FileMode.Open, FileAccess.Read) 'instanciamos en Stream indicandole la ruta del arvhivo,el modo de acceso y si es de lectura o escritura
                ReDim data3(ios.Length) 'llenamos el arreglo
                ios.Read(data3, 0, CInt(ios.Length)) 'llenamos el arreglo
                Me.imgfoto3.SizeMode = PictureBoxSizeMode.StretchImage 'establecemos como se visualiza la imagen
                Me.imgfoto3.Load(Me.OPF3.FileName) 'visualizamos abriendo el archivo seleccionado
                pa.Value = data3 'llenamos la variable parametro con el arreglo
                hayfoto3 = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) 'en caso de error muestre un mensaje
        End Try
    End Sub

    Private Sub cmdguardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdguardar.Click

        '............VENDEDOR POR PC
        If chVend.Checked = True Then
            If lbfact.Text = "RAPIDA" Then
                Dim file As System.IO.StreamWriter = System.IO.File.CreateText(My.Application.Info.DirectoryPath & "\ven_fr.txt")
                file.Write(txtnitv.Text)
                file.Close()
            Else
                Dim file As System.IO.StreamWriter = System.IO.File.CreateText(My.Application.Info.DirectoryPath & "\ven_fn.txt")
                file.Write(txtnitv.Text)
                file.Close()
            End If
        Else
            If lbfact.Text = "RAPIDA" Then
                Try
                    File.Delete(My.Application.Info.DirectoryPath & "\ven_fr.txt")
                Catch ex As Exception
                End Try
            Else
                Try
                    File.Delete(My.Application.Info.DirectoryPath & "\ven_fn.txt")
                Catch ex As Exception
                End Try
            End If
        End If
        ' ...............................

        ' ............ ITEMS POR PC......
        If rb_itemN.Checked = True Then
            Try
                File.Delete(My.Application.Info.DirectoryPath & "\item.txt")
            Catch ex As Exception
            End Try
        Else
            Dim file As System.IO.StreamWriter = System.IO.File.CreateText(My.Application.Info.DirectoryPath & "\item.txt")
            file.Write(txtitems.Text)
            file.Close()
        End If
        '................................

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT factura FROM parafacts WHERE factura='" & lbfact.Text & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count = 0 Then
            Guardar()
        Else
            Modificar()
        End If
    End Sub
    Private Sub cmdcancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub rbbodpre2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbbodpre2.CheckedChanged
        cbbod.Enabled = False
    End Sub
    Private Sub rbbodpre_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbbodpre.CheckedChanged
        cbbod.Enabled = True
    End Sub

    Private Sub rbmarg2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbmarg2.CheckedChanged
        txtmargen.Enabled = False
    End Sub
    Private Sub rbmarg_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbmarg.CheckedChanged
        txtmargen.Enabled = True
    End Sub

    Private Sub rbcc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc2.CheckedChanged
        txtcc.Enabled = False
        Txtcc2.Enabled = False
    End Sub
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        txtcc.Enabled = True
        Txtcc2.Enabled = True
    End Sub

    Private Sub rbfp_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfp.CheckedChanged
        gcfp.Enabled = True
    End Sub
    Private Sub rbfp2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfp2.CheckedChanged
        gcfp.Enabled = False
    End Sub

    Private Sub pdffac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdffac.CheckedChanged
        cmdlogofac.Enabled = True
        imgfoto.Enabled = True
    End Sub
    Private Sub ticfac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticfac.CheckedChanged
        cmdlogofac.Enabled = False
        imgfoto.Enabled = False
    End Sub

    Private Sub pdfped_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdfped.CheckedChanged
        cmdlogoped.Enabled = True
        imgfoto2.Enabled = True
    End Sub
    Private Sub ticped_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticped.CheckedChanged
        cmdlogoped.Enabled = False
        imgfoto2.Enabled = False
    End Sub

    Private Sub pdfcot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pdfcot.CheckedChanged
        cmdlogocot.Enabled = True
        imgfoto3.Enabled = True
    End Sub
    Private Sub ticcot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticcot.CheckedChanged
        cmdlogocot.Enabled = False
        imgfoto3.Enabled = False
    End Sub

    Private Sub FrmParaFactRapida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        hayfoto = 0
        hayfoto2 = 0
        hayfoto3 = 0

        '............ Vendedor por pc
        Dim Archivo As String = ""
        Dim ruta As String

        If lbfact.Text = "RAPIDA" Then
            ruta = My.Application.Info.DirectoryPath & "\ven_fr.txt"
        Else
            ruta = My.Application.Info.DirectoryPath & "\ven_fn.txt"
        End If
        If My.Computer.FileSystem.FileExists(ruta) Then
            chVend.Checked = True
            Archivo = My.Computer.FileSystem.ReadAllText(ruta)
            txtnitv.Enabled = True
            txtnitv.Text = Archivo
            txtnitv_TextChanged(AcceptButton, AcceptButton)
        Else
            chVend.Checked = False
        End If
        '...................

        ' **** ITEMS POR EQUIPO ***
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\item.txt") Then
            rb_itemS.Checked = True
            txtitems.Enabled = True
            txtitems.Text = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\item.txt")
        Else
            rb_itemN.Checked = True
        End If
        '*******************

        If lbfact.Text <> "RAPIDA" Then
            grNF.Visible = False
        Else
            grNF.Visible = True
        End If

    End Sub

    Private Sub imgfoto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgfoto.DoubleClick
        cmdlogofac_Click_1(AcceptButton, AcceptButton)
    End Sub
    Private Sub imgfoto2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgfoto2.DoubleClick
        cmdlogoped_Click_1(AcceptButton, AcceptButton)
    End Sub
    Private Sub imgfoto3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgfoto3.Click
        cmdlogocot_Click_1(AcceptButton, AcceptButton)
    End Sub

    Private Sub cbbod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbod.SelectedIndexChanged
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM bodegas WHERE numbod=" & cbbod.Text & ";"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtbodega.Text = tabla.Rows(0).Item("nombod")
        Else
            txtbodega.Text = ""
        End If
    End Sub
    Private Sub rbdoc2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdoc2.CheckedChanged
        txttipo.Enabled = False
    End Sub
    Private Sub rbdoc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdoc1.CheckedChanged
        txttipo.Enabled = True
    End Sub

    Private Sub txtcc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcc.DoubleClick
        FrmSelCC.lbform.Text = "para_fac"
        FrmSelCC.ShowDialog()
    End Sub
    '//////// VISTA PREVIA ////////////////////////
    Private Sub cmd_vp_fact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_fact.Click


        If pdffac.Checked = True Then
            GenerarPDF("fact")
        ElseIf pdffac2.Checked = True Then
            GenerarPDF22("fact")
        Else
            GenerarTicket("fact")
        End If

    End Sub
    Private Sub cmd_vp_ped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_ped.Click
        If pdffac.Checked = True Then
            GenerarPDF("ped")
        ElseIf pdffac2.Checked = True Then
            GenerarPDF22("ped")
        Else
            GenerarTicket("ped")
        End If
    End Sub
    Private Sub cmd_vp_cot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_vp_cot.Click
        If pdfcot.Checked = True Then
            GenerarPDF("cot")
        ElseIf pdfcot2.Checked = True Then
            GenerarPDF22("cot")
        Else
            GenerarTicket("cot")
        End If
    End Sub
    '////////// REPORTES ///////////////////////
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    '////////// GENERAR PDF ///////////////////////
    Public Sub GenerarPDF(ByVal campo As String)
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg(campo)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner(campo)
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)

            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = k - 40
            cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k + 10, 0)
            Dim k2 As Integer = k
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "IVA  0%", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 585, k, 0)
            k = k - 5
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "__________________", 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR TOTAL", 485, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 585, k, 0)
            k = k - 10

            cb.ShowTextAligned(50, "SON: " & Num2Text(CDbl(0)) & " (PESOS M/C)", 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Observaciones: Ninguna", 10, k, 0)
            k = k - 20
            If Trim(txtcomentario.Text) <> "" Then
                'cb.ShowTextAligned(50, txtcomentario.Text, 10, k, 0)
                Control_de_linea(txtcomentario.Text, 10, 125)
                k = k - 10
            End If
            cb.ShowTextAligned(50, "Esta factura se asimila para todos sus efectos a la letra de cambio. Articulo 774 Codigo de Comercio.", 10, k, 0)
            k = k - 10
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 15
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text, 10, k, 0)
            k = k - 45
            cb.ShowTextAligned(50, "_____________________________", 20, k, 0)
            cb.ShowTextAligned(50, "_____________________________", 350, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "RECIBIDO", 20, k, 0)
            cb.ShowTextAligned(50, "ENTREGADO", 350, k, 0)
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
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal x As Integer, ByVal tam As Integer)
        Try
            salto = 1
            linea = ""
            Dim j As Integer = 0
            For i = 0 To cadena.Length - 1
                Try
                    If cadena(i) = "%" Then
                        If cadena(i + 1) = "%" Then
                            j = 0
                            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                            linea = ""
                            i = i + 1
                            k = k - 10
                        End If
                    Else
                        linea = linea & cadena(i)
                        If j < tam Then
                            j = j + 1
                        Else
                            If cadena(i) = "" Or cadena(i) = " " Or cadena(i) = "," Or cadena(i) = "." Or j >= tam + 3 Then
                                j = 0
                                cb.ShowTextAligned(50, Trim(linea), x, k, 0)
                                linea = ""
                                k = k - 10
                            Else
                                j = j + 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            cb.ShowTextAligned(50, Trim(linea), x, k, 0)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ColocarImg(ByVal campo As String)
        Try
            Dim img As iTextSharp.text.Image
            Try
                If campo = "fact" Then
                    img = iTextSharp.text.Image.GetInstance(imgfoto.ImageLocation)
                ElseIf campo = "ped" Then
                    img = iTextSharp.text.Image.GetInstance(imgfoto2.ImageLocation)
                Else
                    img = iTextSharp.text.Image.GetInstance(imgfoto3.ImageLocation)
                End If
            Catch ex As Exception
                If campo = "fact" Then
                    campo = "logofac"
                ElseIf campo = "ped" Then
                    campo = "logoped"
                Else
                    campo = "logocot"
                End If
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT " & campo & " FROM parafacts WHERE factura='" & lbfact.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                img = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item(0))
            End Try
            img.ScaleToFit(80, 180)
            img.SetAbsolutePosition(20, 770)
            img.Alignment = Element.ALIGN_RIGHT
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner(ByVal campo As String)
        pag = pag + 1
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 815
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("descripcion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "NIT. " & tablacomp.Rows(0).Item("nit") & " " & cbregimen.Text, 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tablacomp.Rows(0).Item("direccion"), 300, k, 0)
        k = k - 10
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEL. " & tablacomp.Rows(0).Item("telefono1") & "    " & tablacomp.Rows(0).Item("telefono2"), 300, k, 0)
        '**********************************************************************************************************************
        k = k - 25
        If campo = "fact" Then
            cb.ShowTextAligned(50, "FACTURA No. 00000", 20, k, 0)
        ElseIf campo = "ped" Then
            cb.ShowTextAligned(50, "PEDIDO No. 00000", 20, k, 0)
        Else
            cb.ShowTextAligned(50, "COTIZACIÓN No. 00000", 20, k, 0)
        End If
        k = k - 10
        cb.ShowTextAligned(50, "FECHA: Lunes 03 de Enero de 2011 HORA: 08:03:42", 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "SEÑORES: NOMBRE DEL CLIENTE", 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "NIT/CEDULA: NIT / CEDULA", 20, k, 0)
        k = k - 10
        cb.ShowTextAligned(50, "VENDEDOR: NOMBRE DEL VENDEDOR", 20, k, 0)
        '**********************************************************************************************************************
        k = k - 10
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 10
        '******************************************************** DIAN **************************************************************
        If campo = "fact" Then
            cb.ShowTextAligned(50, "Resolución DIAN 00000000000 del dd-mm-aaaa", 350, k + 45, 0)
            cb.ShowTextAligned(50, "Factura por computador Nro. de 1 al 1000", 350, k + 35, 0)
        End If
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "PAGINA: " & pag, 585, k + 25, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ITEM", 20, k, 0)
        cb.ShowTextAligned(50, "CODIGO", 40, k, 0)
        cb.ShowTextAligned(50, "DESCRIPCION", 120, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "CANTIDAD", 350, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "VALOR UNITARIO", 485, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "SUB TOTAL", 585, k, 0)
        k = k - 5
        cb.ShowTextAligned(50, "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- ", 0, k, 0)
        k = k - 5
    End Sub
    ' ----------  GENERAR PDF2 NUEVO
    Public Sub GenerarPDF22(ByVal campo As String)

        Dim nom As String = ""
        Dim nit As String = ""
        Dim email As String = ""
        Dim dire As String = ""
        Dim tel As String = ""
        Dim nor As String = ""

        nor = lbfact.Text

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)

        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")
        tel = Trim(tabla2.Rows(0).Item("telefono1") & "  " & tabla2.Rows(0).Item("telefono2"))
        email = tabla2.Rows(0).Item("emailconta")
        dire = tabla2.Rows(0).Item("direccion")


        Dim tabla As New DataTable
        tabla = New DataTable
        myCommand.CommandText = "SELECT logofac FROM parafacts where factura = 'RAPIDA'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\ReportFacRapVP.rpt")
        CrReport.SetDataSource(tabla)
        FrmReportFacRapVP.CrystalReportViewer1.ReportSource = CrReport

        Dim Tcampo As String = ""
        If campo = "fact" Then
            Tcampo = "FACTURA N° "
        End If
        If campo = "cot" Then
            Tcampo = "COTIZACION N° "
        End If
        If campo = "ped" Then
            Tcampo = "PEDIDO N° "
        End If

        Try
            Dim Prcompañia As New ParameterField
            Dim PrNit As New ParameterField
            Dim Prperiodo As New ParameterField
            Dim Prtelef As New ParameterField
            Dim Premail As New ParameterField
            Dim Prenorm As New ParameterField
            Dim Pretipo As New ParameterField


            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            Prcompañia.Name = "comp"
            Prcompañia.CurrentValues.AddValue(nom.ToString)
            PrNit.Name = "nit"
            PrNit.CurrentValues.AddValue(nit.ToString)
            Prperiodo.Name = "dir"
            Prperiodo.CurrentValues.AddValue(dire.ToString)
            Prtelef.Name = "telef"
            Prtelef.CurrentValues.AddValue(tel.ToString)
            Premail.Name = "email"
            Premail.CurrentValues.AddValue(email.ToString)
            Prenorm.Name = "normal"
            Prenorm.CurrentValues.AddValue(nor.ToString)
            Pretipo.Name = "campo"
            Pretipo.CurrentValues.AddValue(Tcampo.ToString)

            prmdatos.Add(Prcompañia)
            prmdatos.Add(PrNit)
            prmdatos.Add(Prperiodo)
            prmdatos.Add(Prtelef)
            prmdatos.Add(Premail)
            prmdatos.Add(Prenorm)
            prmdatos.Add(Pretipo)

            FrmReportFacRapVP.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportFacRapVP.ShowDialog()

        Catch ex As Exception

        End Try


    End Sub

    '//////////// GENERAR PDF2//////////////////////////
    Public Sub GenerarPDF2(ByVal campo As String)
        Try
            Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
            Dim pdfw As iTextSharp.text.pdf.PdfWriter
            Dim fuente As iTextSharp.text.pdf.BaseFont
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 80
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg2(1, "")
            ColocarImg2(4, campo)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner2(campo)
            cb.EndText()
            ColocarImg2(2, "")
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            '********************* DESCUENTOS, IVA, TOTAL, FPAGO, OBSRVACIONES ***************************************************************
            k = 135
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 565, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 565, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 585, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda("0"), 585, k, 0)
            k = k - 20
            If Trim(txtcomentario.Text) <> "" Then
                Control_de_linea(txtcomentario.Text, 20, 100)
                k = k - 10
            End If
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 20, k, 0)
            k = k - 15
            cb.ShowTextAligned(50, "Factura elaborada por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text, 20, k, 0)
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
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Public Sub ColocarImg2(ByVal i As Integer, ByVal campo As String)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\banner.jpg")
                img.SetAbsolutePosition(10, 595)
                img.ScaleToFit(690, 255)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\body.jpg")
                img.SetAbsolutePosition(10, 128)
                img.ScaleToFit(690, 470)
                img.Alignment = Element.ALIGN_CENTER
                cb.AddImage(img)
            ElseIf i = 3 Then
                'img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\FV\FV3R.jpg")
                'img.SetAbsolutePosition(0, k)
                'img.ScaleToFit(598, 170)
                'img.Alignment = Element.ALIGN_CENTER
                'cb.AddImage(img)
            Else
                Try
                    If campo = "fact" Then
                        img = iTextSharp.text.Image.GetInstance(imgfoto.ImageLocation)
                    ElseIf campo = "ped" Then
                        img = iTextSharp.text.Image.GetInstance(imgfoto2.ImageLocation)
                    Else
                        img = iTextSharp.text.Image.GetInstance(imgfoto3.ImageLocation)
                    End If
                Catch ex As Exception
                    If campo = "fact" Then
                        campo = "logofac"
                    ElseIf campo = "ped" Then
                        campo = "logoped"
                    Else
                        campo = "logocot"
                    End If
                    Dim tabla As New DataTable
                    myCommand.CommandText = "SELECT " & campo & " FROM parafacts WHERE factura='" & lbfact.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    img = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item(0))
                End Try
                img.ScaleToFit(80, 180)
                img.SetAbsolutePosition(20, 757)
                img.Alignment = Element.ALIGN_RIGHT
                cb.AddImage(img)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Banner2(ByVal campo As String)
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 780
        If campo = "fact" Then
            cb.ShowTextAligned(50, "Resolución DIAN 00000000000", 435, k + 30, 0)
            cb.ShowTextAligned(50, "del dd-mm-aaaa Prefijo --", 435, k + 20, 0)
            cb.ShowTextAligned(50, "Factura por computador", 435, k + 10, 0)
            cb.ShowTextAligned(50, "Nro. de 1 al 1000", 435, k, 0)
        End If
        k = 750
        If campo = "fact" Then
            cb.ShowTextAligned(50, "FACTURA DE VENTA", 445, k, 0)
            cb.ShowTextAligned(50, "No. 00000", 445, k - 25, 0)
        ElseIf campo = "ped" Then
            cb.ShowTextAligned(50, "PEDIDO", 445, k, 0)
            cb.ShowTextAligned(50, "No. 00000", 445, k - 15, 0)
        Else
            cb.ShowTextAligned(50, "COTIZACIÓN", 445, k, 0)
            cb.ShowTextAligned(50, "No. 00000", 445, k - 15, 0)
        End If
        '**********************************************
        k = 705
        cb.ShowTextAligned(50, Now.Day, 20, k, 0)
        cb.ShowTextAligned(50, Now.Month, 55, k, 0)
        cb.ShowTextAligned(50, Now.Year, 80, k, 0)
        '**********************************************
        k = 678
        cb.ShowTextAligned(50, "NOMBRE DEL CLIENTE", 90, k, 0)
        k = k - 23
        cb.ShowTextAligned(50, "NIT / CEDULA", 90, k, 0)
        k = k - 18
        cb.ShowTextAligned(50, "DIRECCIÓN DEL CLIENTE", 100, k, 0)
        cb.ShowTextAligned(50, "TELEFONO", 450, k, 0)
        k = k - 25
        cb.ShowTextAligned(50, "EFECTIVO", 140, k, 0)
        '***********************************************
        cb.ShowTextAligned(50, Now.Day & "/" & Now.Month & "/" & Now.Year, 480, k, 0)
        '*************************************************
        k = k - 37
    End Sub
    '////////////// GENERAR TICKET /////////////////////
    Private stringToPrint As String
    Public Sub GenerarTicket(ByVal campo As String)
        '*************DATOS COMPAÑIA***************************************
        Dim file As System.IO.StreamWriter = System.IO.File.CreateText(My.Application.Info.DirectoryPath & "\Reportes\temp.txt")
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        File.WriteLine(CambiaCadena(tablacomp.Rows(0).Item("descripcion"), 50))
        File.WriteLine("NIT. " & tablacomp.Rows(0).Item("nit") & " " & cbregimen.Text)
        File.WriteLine(tablacomp.Rows(0).Item("direccion"))
        File.WriteLine("TEL. " & tablacomp.Rows(0).Item("telefono1") & "    " & tablacomp.Rows(0).Item("telefono2"))
        '************** FACTURA ******************************
        File.WriteLine("FECHA: " & Now)
        If campo = "fact" Then
            File.WriteLine("FACTURA No. 00000 ")
        ElseIf campo = "ped" Then
            File.WriteLine("PEDIDO No. 00000 ")
        Else
            File.WriteLine("COTIZACIÓN No. 00000")
        End If
        File.WriteLine("SEÑORES: NOMBRE DEL CLIENTE")
        File.WriteLine("NIT/CEDULA: NIT / CEDULA")
        File.WriteLine("VENDEDOR: NOMBRE DEL VENDEDOR")
        File.WriteLine("Forma De Pago: Efectivo: $0,00")
        '*************** CUERPO ********************************
        File.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                  Cant            Unit      Iva         V/total")
        File.WriteLine("---------------------------------------------------------------")
        file.WriteLine("codigo  nombre del producto  ")
        file.WriteLine("                  0,00            0,00    0,00%           0,00")
        file.WriteLine("---------------------------------------------------------------")
        file.WriteLine("                                     Sub Total:           0,00")
        file.WriteLine("                                     Iva:                 0,00")
        file.WriteLine("                                     Total:               0,00")
        File.WriteLine(Chr(13))
        '*****************************************************************************
        File.WriteLine("Resolución DIAN 00000000 del 00-00-000")
        file.WriteLine("Factura por computador Nro. 1 al 1000")
        File.WriteLine("---------------------------------------------------------------")
        If Trim(txtcomentario.Text) <> "" Then file.WriteLine(txtcomentario.Text)
        File.WriteLine("Impreso a la fecha y hora: " & Now)
        File.WriteLine("Factura elaborada por computadora en el Software")
        File.WriteLine("de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text)
        File.WriteLine("---------------------------------------------------------------")
        File.Close()
        Dim docName As String = "temp.txt"
        Dim docPath As String = My.Application.Info.DirectoryPath & "\Reportes\"
        imprimir.DocumentName = docName
        Dim stream As New FileStream(docPath & docName, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                stringToPrint = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        imprimir.Print()
    End Sub
    Private Sub imprimir_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles imprimir.PrintPage
        Try
            Dim charactersOnPage As Integer = 0
            Dim linesPerPage As Integer = 0
            e.Graphics.MeasureString(stringToPrint, lbprint.Font, e.MarginBounds.Size, _
                StringFormat.GenericTypographic, charactersOnPage, linesPerPage)
            e.Graphics.DrawString(stringToPrint, lbprint.Font, Brushes.Black, _
                e.MarginBounds, StringFormat.GenericTypographic)
            stringToPrint = stringToPrint.Substring(charactersOnPage)
            e.HasMorePages = stringToPrint.Length > 0
        Catch ex As Exception

        End Try
    End Sub
   
 
    Private Sub Tabcont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tabcont.Click

    End Sub

    Private Sub chVend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chVend.CheckedChanged
        If chVend.Checked = True Then
            rbvendedor.Checked = False
            txtnitv.Enabled = True
        Else
            rbvendedor.Checked = False
            txtnitv.Enabled = False
        End If
    End Sub

    Private Sub rb_itemN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_itemN.CheckedChanged
        If rb_itemN.Checked = True Then
            rb_itemS.Checked = False
            txtitems.Enabled = False
        Else
            rb_itemS.Checked = True
            txtitems.Enabled = True
            txtitems.Text = "I"
        End If
    End Sub

    Private Sub rbfec2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfec2.CheckedChanged
      
    End Sub

    Private Sub rbnumf2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnumf2.CheckedChanged
        If rbnumf2.Checked = True Then
            grNF.Enabled = False
        Else
            grNF.Enabled = True
        End If
    End Sub
End Class