Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Public Class FrmCierreComp

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdActuaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActuaS.Click

        Dim p As String = ""
        p = PerActual(0).ToString() & PerActual(1).ToString

        If p = "12" Then

            Dim resultado As MsgBoxResult

            resultado = MsgBox(" ¿Desea realizar el cierre anual ? ", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then

                Dim conexion As New MySqlConnection
                Dim cadena As String
                cadena = datosconR(bda)
                conexion.ConnectionString = cadena
                conexion.Open()

                Dim b As String = ""
                Dim c As String = ""
                Dim f As String = ""
                Dim fp As String = ""
                Dim sql As String = ""
                Dim sql2 As String = ""
                b = Strings.Right(bda, 4)
                b = b + 1

                c = "sae" & CompaniaActual & b
                Dim tabla As New DataTable
                myCommand.CommandText = "show databases like '" & c & "'"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()

                If tabla.Rows.Count > 0 Then

                    sql2 = " SELECT doc, tipo, num, doc_ext, descrip, tipafec, clasaju, nitc, nomnit, nitcod, " _
                    & " fecha, vmto, concepto, subtotal, descto, ret, iva, v_viva, total, ctasubtotal,	ctaret,	ctaiva,	ctatotal, " _
                    & " ccosto,	otroimp, retiva, ctaretiva, retica, ctaretica,pagado, rcpos, DATE_FORMAT(fechpos, '%Y-%m-%y') as fechpos,vpos,tasa,moneda, " _
                    & " monloex, estado,salmov,pagare FROM ctas_x_pagar where pagado < total "

                    Dim tabla2 As DataTable
                    tabla2 = New DataTable
                    myCommand.CommandText = sql2
                    myCommand.Connection = conexion
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla2)
                    Refresh()
                    If tabla2.Rows.Count <> 0 Then

                        For i = 0 To tabla2.Rows.Count - 1
                            Try

                                f = " '" & Strings.Right(tabla2.Rows(i).Item("fecha").ToString, 4) & Strings.Mid(tabla2.Rows(i).Item("fecha").ToString, 4, 2) & Strings.Left(tabla2.Rows(i).Item("fecha").ToString, 2) & "'   "
                                fp = " '" & Strings.Right(tabla2.Rows(i).Item("fechpos").ToString, 4) & Strings.Mid(tabla2.Rows(i).Item("fechpos").ToString, 4, 2) & Strings.Left(tabla2.Rows(i).Item("fechpos").ToString, 2) & "'   "

                                sql = " '" & tabla2.Rows(i).Item("doc") & "', '" & tabla2.Rows(i).Item("tipo") & "' , '" & tabla2.Rows(i).Item("num") & "', '" & tabla2.Rows(i).Item("doc_ext") & "', '" & tabla2.Rows(i).Item("descrip") & "', '" & tabla2.Rows(i).Item("tipafec") & "', '" & tabla2.Rows(i).Item("clasaju") & "', " _
                                & "  '" & tabla2.Rows(i).Item("nitc") & "', '" & tabla2.Rows(i).Item("nomnit") & "',  " _
                                & " '" & tabla2.Rows(i).Item("nitcod") & "' ,  " _
                                & "  " & f & " , " _
                                & "  '" & tabla2.Rows(i).Item("vmto") & "' ,  " _
                                & "  '" & tabla2.Rows(i).Item("concepto") & "' ,  " _
                                & " '" & DIN(tabla2.Rows(i).Item("subtotal")) & "', " _
                                & " '" & DIN(tabla2.Rows(i).Item("descto")) & "', '" & DIN(tabla2.Rows(i).Item("ret")) & "', '" & DIN(tabla2.Rows(i).Item("iva")) & "', " _
                                & " '" & DIN(tabla2.Rows(i).Item("v_viva")) & "', '" & DIN(tabla2.Rows(i).Item("total")) & "', '" & tabla2.Rows(i).Item("ctasubtotal") & "', " _
                                & " '" & tabla2.Rows(i).Item("ctaret") & "', '" & tabla2.Rows(i).Item("ctaiva") & "', '" & tabla2.Rows(i).Item("ctatotal") & "' , " _
                                & " '" & tabla2.Rows(i).Item("ccosto") & "', '" & tabla2.Rows(i).Item("otroimp") & "', '" & DIN(tabla2.Rows(i).Item("retiva")) & "', " _
                                & " '" & tabla2.Rows(i).Item("ctaretiva") & "', '" & DIN(tabla2.Rows(i).Item("retica")) & "', '" & tabla2.Rows(i).Item("ctaretica") & "', " _
                                & " '" & DIN(tabla2.Rows(i).Item("pagado")) & "', '" & tabla2.Rows(i).Item("rcpos") & "', " & fp & ", " _
                                & " '" & DIN(tabla2.Rows(i).Item("vpos")) & "', '" & DIN(tabla2.Rows(i).Item("tasa")) & "', '" & tabla2.Rows(i).Item("moneda") & "', " _
                                & " '" & tabla2.Rows(i).Item("monloex") & "', '" & tabla2.Rows(i).Item("estado") & "', '" & tabla2.Rows(i).Item("salmov") & "', '" & tabla2.Rows(i).Item("pagare") & "' "

                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "  INSERT INTO " & c & ".ctas_x_pagar ( doc, tipo, num, doc_ext, descrip, tipafec, clasaju, nitc, nomnit, nitcod,fecha, vmto, concepto, " _
                                & "subtotal, descto, ret, iva, v_viva, total, ctasubtotal,	ctaret,	ctaiva,	ctatotal, ccosto,	otroimp, retiva, ctaretiva, retica, ctaretica, " _
                                & " pagado, rcpos,fechpos,vpos,tasa,moneda,monloex,	estado,salmov,pagare ) VALUES  ( " & sql & ") "
                                myCommand.ExecuteNonQuery()
                            Catch ex As Exception
                                'MsgBox(ex.ToString)
                            End Try
                        Next
                        MsgBox("El proceso se realizo satisfactoriamente")
                    End If

                Else
                    MsgBox("Debe crear el nuevo año")
                End If
            End If

        Else
            MsgBox("Este proceso solo puede realizar en el Periodo N° 12")
        End If

    End Sub
End Class