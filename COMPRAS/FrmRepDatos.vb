Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Public Class FrmRepDatos

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Public Sub cmdActuaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActuaS.Click

        Dim p As String = ""
        Dim sql As String = ""
        Dim sql2 As String = ""
        Dim sql3 As String = ""
        Dim f As String = ""
        Dim it As String = ""

        Dim año As String = ""
        Dim resultado As MsgBoxResult

        Dim conexion As New MySqlConnection
        Dim cadena As String
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        resultado = MsgBox(" ¿Desea Reprocesar los saldos? ", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            Try

           
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

                        sql = sql & " SELECT f.doc, f.tipodoc, f.num, f.doc_afec, '' as descrip, '' as tipafec, '' as	clasaju, f.nitc, " _
                           & " concat(t.nombre,'',t.apellidos)as nomnit, '' as nitcod, f.fecha, f.vmto, " _
                           & " (SELECT nom_art FROM `detacomp" & p & "` where doc =f.doc and item = '1') as concepto, " _
                           & " f.subtotal, f.descuento, f.rtf, f.por_iva, f.iva, f.total, " _
                           & " f.cta_total, f.cta_rtf, f.cta_iva, f.cta_total, f.ctoc, 'N' as otroimp, " _
                           & "  '0' as retiva, '' as ctaretiva, '0' as retica,'' as ctaretica, '0' as pagado, " _
                           & " '' as rcpos,'0000-00-00' as fechpos, '0' as vpos,'0' as tasa, '' as moneda, 'L' as monloex,f.estado, '' as	salmov, '' as pagare " _
                           & " FROM  fact_comp" & p & " f , terceros t  " _
                           & " WHERE f.fpago = 'Otra' and f.nitc = t.nit and f.estado = 'AP' and left(f.fecha, 4)='" & año & "' UNION "

                    Else

                        sql = sql & " SELECT f.doc, f.tipodoc, f.num, f.doc_afec, '' as descrip, '' as tipafec, '' as	clasaju, f.nitc, " _
                          & " concat(t.nombre,'',t.apellidos)as nomnit, '' as nitcod, f.fecha, f.vmto, " _
                          & " (SELECT nom_art FROM `detacomp" & p & "` where doc =f.doc and item = '1') as concepto, " _
                          & " f.subtotal, f.descuento, f.rtf, f.por_iva, f.iva, f.total, " _
                          & " f.cta_total, f.cta_rtf, f.cta_iva, f.cta_total, f.ctoc, 'N' as otroimp, " _
                          & "  '0' as retiva, '' as ctaretiva, '0' as retica,'' as ctaretica, '0' as pagado, " _
                          & " '' as rcpos,'0000-00-00' as fechpos, '0' as vpos,'0' as tasa, '' as moneda, 'L' as monloex,f.estado, '' as	salmov, '' as pagare " _
                          & " FROM  fact_comp" & p & " f , terceros t  " _
                          & " WHERE f.fpago = 'Otra' and f.nitc = t.nit and f.estado = 'AP' and left(f.fecha, 4)='" & año & "'  "


                    End If
                Next
                sql = sql & "order by doc "


                TextBox1.Text = sql
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
                        Try
                            f = " '" & Strings.Right(tabla.Rows(i).Item("fecha").ToString, 4) & Strings.Mid(tabla.Rows(i).Item("fecha").ToString, 4, 2) & Strings.Left(tabla.Rows(i).Item("fecha").ToString, 2) & "'   "

                            sql2 = " '" & tabla.Rows(i).Item("doc") & "', '" & tabla.Rows(i).Item("tipodoc") & "' , '" & tabla.Rows(i).Item("num") & "', '" & tabla.Rows(i).Item("doc_afec") & "', '" & tabla.Rows(i).Item("descrip") & "', '" & tabla.Rows(i).Item("tipafec") & "', '" & tabla.Rows(i).Item("clasaju") & "', " _
                                & "  '" & tabla.Rows(i).Item("nitc") & "', '" & tabla.Rows(i).Item("nomnit") & "',  " _
                                & " '" & tabla.Rows(i).Item("nitcod") & "' , " & f & " " _
                                & " , '" & tabla.Rows(i).Item("vmto") & "' , '" & tabla.Rows(i).Item("concepto") & "', '" & tabla.Rows(i).Item("subtotal") & "', " _
                                & " '" & tabla.Rows(i).Item("descuento") & "', '" & tabla.Rows(i).Item("rtf") & "', '" & tabla.Rows(i).Item("por_iva") & "', " _
                                & " '" & tabla.Rows(i).Item("iva") & "', '" & tabla.Rows(i).Item("total") & "', '" & tabla.Rows(i).Item("cta_total") & "', " _
                                & " '" & tabla.Rows(i).Item("cta_rtf") & "', '" & tabla.Rows(i).Item("cta_iva") & "', '" & tabla.Rows(i).Item("cta_total") & "' , " _
                                & " '" & tabla.Rows(i).Item("ctoc") & "', '" & tabla.Rows(i).Item("otroimp") & "', '" & tabla.Rows(i).Item("retiva") & "', " _
                                & " '" & tabla.Rows(i).Item("ctaretiva") & "', '" & tabla.Rows(i).Item("retica") & "', '" & tabla.Rows(i).Item("ctaretica") & "', " _
                                & " '" & tabla.Rows(i).Item("pagado") & "', '" & tabla.Rows(i).Item("rcpos") & "', '" & tabla.Rows(i).Item("fechpos") & "', " _
                                & " '" & tabla.Rows(i).Item("vpos") & "', '" & tabla.Rows(i).Item("tasa") & "', '" & tabla.Rows(i).Item("moneda") & "', " _
                                & " '" & tabla.Rows(i).Item("monloex") & "', '" & tabla.Rows(i).Item("estado") & "', '" & tabla.Rows(i).Item("salmov") & "', '" & tabla.Rows(i).Item("pagare") & "' "

                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "  INSERT INTO ctas_x_pagar ( doc, tipo, num, doc_ext, descrip,	tipafec, clasaju, nitc, nomnit,	nitcod,	fecha,	vmto, concepto, " _
                            & "subtotal , descto, ret, iva,	v_viva,	total, ctasubtotal,	ctaret,	ctaiva,	ctatotal, ccosto, otroimp, retiva, ctaretiva, retica, ctaretica,  " _
                            & " pagado,	rcpos,	fechpos, vpos, tasa, moneda, monloex, estado, salmov, pagare ) VALUES  ( " & sql2 & ") "
                            myCommand.ExecuteNonQuery()

                        Catch ex As Exception
                        End Try

                        mibarra.Value = mibarra.Value + it
                        If mibarra.Value + it + 5 > mibarra.Maximum Then
                            mibarra.Value = mibarra.Value - 5
                        End If

                    Next
                End If


                sql3 = " select doc_afec, sum(o.abonado) as sum from ( "
                For i = 1 To 12
                    If i < 10 Then
                        p = "0" & i
                    Else
                        p = i
                    End If
                    If p <> "12" Then

                        sql3 = sql3 & "SELECt doc, doc_afec, estado, abonado " _
                        & " from ot_cpp" & p & " where estado ='AP' and abonado <>0  and right(periodo,4)='" & año & "' AND doc_aj='' UNION "
                    Else
                        sql3 = sql3 & " SELECt doc, doc_afec, estado, abonado " _
                        & " from ot_cpp" & p & " where estado ='AP' and abonado <>0  and right(periodo,4)='" & año & "' AND doc_aj='' "
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
                            myCommand.CommandText = "UPDATE  ctas_x_pagar " _
                                 & " SET pagado ='" & tabla_s.Rows(j).Item("sum") & "'" _
                                 & " WHERE doc='" & tabla_s.Rows(j).Item("doc_afec") & "' "
                            myCommand.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try

                    Next
                End If

                mibarra.Visible = False

                MsgBox("El proceso se realizo exitosamente ")

            Catch ex As Exception
                MsgBox("Error al Reprocesar los Saldos", MsgBoxStyle.Information, "Verificacion")
            End Try
        Else ' confirmar
            Me.Close()
        End If

    End Sub
End Class