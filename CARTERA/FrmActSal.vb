Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Public Class FrmActSal

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()

    End Sub

    Private Sub cmdActuaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActuaS.Click

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim sql4 As String = ""
        Dim f As String = ""
        Dim it As String = ""

        Dim año As String = ""
        Dim resultado As MsgBoxResult

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        resultado = MsgBox(" ¿Desea Actualizar los saldos? ", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then

            Dim tf As New DataTable
            myCommand.CommandText = "SELECT tipodoc FROM `tipdoc` WHERE descripcion='AJUSTE DE FACTURACION'"
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tf)
            Refresh()

            'tf.Rows(0).Item(0)


            mibarra.Value = 0
            mibarra.Visible = True

            año = PerActual(3).ToString & PerActual(4).ToString & PerActual(5).ToString & PerActual(6).ToString

            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If p <> "12" Then
                    sql = sql & " SELECT fp.doc ,  f.tipodoc, f.num, f.descrip, '' as tipafec,'' as clasaju, f.nitc, concat(t.nombre,'',t.apellidos)as nomnit, '' as nitcod, f.nitv, f.fecha, f.vmto, f.observ, f.subtotal, f.descuento, f.ret_f, f.por_iva, f.iva, f.total, f.cta_total, f.cta_ret_f, f.cta_iva,  f.cta_total, f.cc, 'N' as otroimp, f.ret_iva, f.cta_ret_iva, f.ret_ica, f.cta_ret_ica, '0' as pagado, " _
                        & " '' as rcpos, '00000000' as fechpos,'' as vpos, '' as tasa, '' as moneda,'L' as monloex,	f.estado,'' as  salmov, '' as pagare " _
                        & "FROM  facturas" & p & " f, facpagos" & p & " fp, terceros t " _
                        & " where f.doc = fp.doc and fp.tipo = 'Otra' and f.estado='AP' and left(f.fecha, 4)='" & año & "' and t.nit = f.nitc  AND LEFT(f.descrip,7)<>'ANULADO' UNION"
                Else
                    sql = sql & " SELECT fp.doc ,  f.tipodoc, f.num, f.descrip, '' as tipafec, '' as clasaju, f.nitc, concat(t.nombre,'',t.apellidos)as nomnit, '' as nitcod, f.nitv, f.fecha, f.vmto, f.observ, f.subtotal, f.descuento, f.ret_f, f.por_iva, f.iva, f.total, f.cta_total, f.cta_ret_f, f.cta_iva,  f.cta_total, f.cc, 'N' as otroimp, f.ret_iva, f.cta_ret_iva, f.ret_ica, f.cta_ret_ica, '0' as pagado, " _
                      & " '' as rcpos, '00000000' as fechpos,'' as vpos, '' as tasa, '' as moneda,'L' as monloex,	f.estado,'' as  salmov, '' as pagare " _
                      & "FROM  facturas" & p & " f, facpagos" & p & " fp, terceros t " _
                      & " where f.doc = fp.doc and fp.tipo = 'Otra' and f.estado='AP' and left(f.fecha, 4)='" & año & "' and t.nit = f.nitc AND LEFT(f.descrip,7)<>'ANULADO' "
                End If
            Next
            sql = sql & "order by doc "

            Dim tabla As DataTable
            tabla = New DataTable
            myCommand.CommandText = sql
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()

            If tabla.Rows.Count > 0 Then

                mibarra.Maximum = tabla.Rows.Count
                it = 1

                For i = 0 To tabla.Rows.Count - 1

                    '... ELiminar ..
                    Try
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "  DELETE FROM cobdpen WHERE doc='" & tabla.Rows(i).Item("doc") & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    '...............

                    If tabla.Rows(i).Item("tipodoc") <> tf.Rows(0).Item(0) And tabla.Rows(i).Item("descrip") <> "" Then
                        Try
                            f = " '" & Strings.Right(tabla.Rows(i).Item("fecha").ToString, 4) & Strings.Mid(tabla.Rows(i).Item("fecha").ToString, 4, 2) & Strings.Left(tabla.Rows(i).Item("fecha").ToString, 2) & "'   "
                            sql2 = " '" & tabla.Rows(i).Item("doc") & "', '" & tabla.Rows(i).Item("tipodoc") & "' , '" & tabla.Rows(i).Item("num") & "', '" & tabla.Rows(i).Item("descrip") & "', '" & tabla.Rows(i).Item("tipafec") & "', '" & tabla.Rows(i).Item("clasaju") & "', " _
                                & "  '" & tabla.Rows(i).Item("nitc") & "', '" & tabla.Rows(i).Item("nomnit") & "',  " _
                                & " '" & tabla.Rows(i).Item("nitcod") & "' , '" & tabla.Rows(i).Item("nitv") & "' ,  " _
                                & "  " & f & " " _
                                & " , '" & tabla.Rows(i).Item("vmto") & "' , '" & CambiaCadena(tabla.Rows(i).Item("observ"), 100) & "', '" & DIN(tabla.Rows(i).Item("subtotal")) & "', " _
                                & " '" & DIN(tabla.Rows(i).Item("descuento")) & "', '" & DIN(tabla.Rows(i).Item("ret_f")) & "', '" & DIN(tabla.Rows(i).Item("por_iva")) & "', " _
                                & " '" & DIN(tabla.Rows(i).Item("iva")) & "', '" & DIN(tabla.Rows(i).Item("total")) & "', '" & tabla.Rows(i).Item("cta_total") & "', " _
                                & " '" & tabla.Rows(i).Item("cta_ret_f") & "', '" & tabla.Rows(i).Item("cta_iva") & "', '" & tabla.Rows(i).Item("cta_total") & "' , " _
                                & " '" & tabla.Rows(i).Item("cc") & "', '" & tabla.Rows(i).Item("otroimp") & "', '" & tabla.Rows(i).Item("ret_iva") & "', " _
                                & " '" & tabla.Rows(i).Item("cta_ret_iva") & "', '" & DIN(tabla.Rows(i).Item("ret_ica")) & "', '" & tabla.Rows(i).Item("cta_ret_ica") & "', " _
                                & " '" & DIN(tabla.Rows(i).Item("pagado")) & "', '" & tabla.Rows(i).Item("rcpos") & "', '" & tabla.Rows(i).Item("fechpos") & "', " _
                                & " '" & DIN(tabla.Rows(i).Item("vpos")) & "', '" & DIN(tabla.Rows(i).Item("tasa")) & "', '" & tabla.Rows(i).Item("moneda") & "', " _
                                & " '" & tabla.Rows(i).Item("monloex") & "', '" & tabla.Rows(i).Item("estado") & "', '" & tabla.Rows(i).Item("salmov") & "', '" & tabla.Rows(i).Item("pagare") & "' "

                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "  INSERT INTO cobdpen ( doc, tipo, num, descrip, tipafec, clasaju, nitc, nomnit, nitcod, nitv, fecha, vmto, concepto, " _
                            & "subtotal, descto, ret, iva, v_viva, total, ctasubtotal, ctaret, ctaiva, ctatotal, ccosto, otroimp, retiva, ctaretiva, retica, ctaretica, " _
                            & " pagado, rcpos, fechpos, vpos, tasa, moneda, monloex, estado, salmov, pagare) VALUES  ( " & sql2 & ") "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If

                    mibarra.Value = mibarra.Value + it
                    If mibarra.Value + it > mibarra.Maximum Then
                        mibarra.Value = mibarra.Value - 5
                    End If

                Next
            End If

            '........AGREGAR ABONOS..........
            sql3 = " select doc_afec, sum(o.abonado) as sum from ( "
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If p <> "12" Then

                    sql3 = sql3 & "SELECt doc_afec, estado, abonado " _
                    & " from ot_cpc" & p & " where estado ='AP' and abonado <>0  and right(periodo,4)='" & año & "' AND doc_aj=''  UNION "
                Else
                    sql3 = sql3 & " SELECt doc_afec, estado, abonado " _
                    & " from ot_cpc" & p & " where estado ='AP' and abonado <>0  and right(periodo,4)='" & año & "' AND doc_aj=''  "
                End If
            Next
            sql3 = sql3 & "order by doc_afec) o group by doc_afec "


            TextBox1.Text = sql3

            Dim tabla_s As DataTable
            tabla_s = New DataTable
            myCommand.CommandText = sql3
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_s)
            Refresh()

            If tabla_s.Rows.Count <> 0 Then
                For j = 0 To tabla_s.Rows.Count - 1
                    Try
                        myCommand.CommandText = "UPDATE  cobdpen " _
                             & " SET pagado ='" & tabla_s.Rows(j).Item("sum") & "'" _
                             & " WHERE doc='" & tabla_s.Rows(j).Item("doc_afec") & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                Next
            End If

            '....................DESCONTAR .POR AJ..........
            sql4 = " SELECT doc_afec, SUM(valor_aj) AS suma FROM ( "
            For i = 1 To 12
                If i < 10 Then
                    p = "0" & i
                Else
                    p = i
                End If
                If p <> "12" Then
                    sql4 = sql4 & "SELECt doc_afec, valor_aj " _
                    & " from facturas" & p & " WHERE estado ='AP' AND doc_afec<>'' AND valor_aj<>0 UNION "
                Else
                    sql4 = sql4 & "SELECt doc_afec, valor_aj " _
                   & " from facturas" & p & " WHERE estado ='AP' AND doc_afec<>'' AND valor_aj<>0 "
                End If
            Next
            sql4 = sql4 & "order by doc_afec) AS c GROUP BY doc_afec "

            TextBox1.Text = sql4
            Dim ta As DataTable
            ta = New DataTable
            myCommand.CommandText = sql4
            myCommand.Connection = conexion
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)
            Refresh()
            If ta.Rows.Count <> 0 Then
                For j = 0 To ta.Rows.Count - 1
                    Try
                        myCommand.CommandText = "UPDATE  cobdpen " _
                             & " SET total = total - " & ta.Rows(j).Item("suma") & " " _
                             & " WHERE doc='" & ta.Rows(j).Item("doc_afec") & "' "
                        myCommand.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                Next
            End If


            mibarra.Visible = False
            MsgBox("El proceso se realizo exitosamente ")
        Else ' confirmar
            Me.Close()
        End If


    End Sub
End Class