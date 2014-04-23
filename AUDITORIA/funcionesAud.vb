Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Mail
Module funcionesAud
    Public Sub Vali_cuent_prov(ByVal cuenta As String, ByVal form As String, ByVal codigo As String, ByVal doc As String)
        
        Dim con As String = ""
        If DBCon.State = ConnectionState.Closed Then
            MiConexion(bda)
            con = "closed"
        End If

        Dim tc As New DataTable
        Select Case cuenta
            Case "caj"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c1_caj,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Caja", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ban"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c2_ban,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Banco", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "cxp"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c3_cxp,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Cuentas x Pagar", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "gas"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c4_gas,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Gastos", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "com"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c5_com,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Compras", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "des"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c6_des,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Descuento", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "inv"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c7_inv,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Inventario", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ivap"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c8_ivap,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Iva por pagar", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ivad"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c9_ivad,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Iva Descontable", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "rtf"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c10_rtf,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Retefuente", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "fle"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c11_fle,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Flete", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "seg"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c12_seg,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Seguro", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "pc"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c13_pc,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Pago PosFechado CD", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "pd"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c14_pd,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parcom` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Pago PosFechado DB", codigo, doc)
                    End If
                End If
                tc.Clear()
        End Select

        If con <> "" Then
            Cerrar()
        End If
      
    End Sub
    Public Sub Vali_cuent_fac(ByVal cuenta As String, ByVal form As String, ByVal codigo As String, ByVal doc As String)

        Dim con As String = ""
        If DBCon.State = ConnectionState.Closed Then
            MiConexion(bda)
            con = "closed"
        End If

        Dim tc As New DataTable
        Select Case cuenta
            Case "caj"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c1_caj,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Caja", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ban"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c2_ban,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Banco", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "cxc"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c3_cxc,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Cuentas x Cobrar", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "inv"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c4_inv,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Inventario", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ven"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c5_ven,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Ventas", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "cven"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c6_cven,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Costos de Ventas", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ivap"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c7_ivap,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Iva por Pagar", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "ivad"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c8_ivad,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Iva descontable", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "des"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c9_des,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "Descuento", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "rtf"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c10_rtf,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "RenteFuente", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "rtic"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c11_rtic,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "ReteIca", codigo, doc)
                    End If
                End If
                tc.Clear()
            Case "rtiv"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c12_rtiv,  '%' ) ,  'y',  'n' ) AS c  FROM `audi_parfac` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If tc.Rows(0).Item("c") <> "y" Then
                        guardar_aud(form, "ReteIva", codigo, doc)
                    End If
                End If
                tc.Clear()
        End Select

        If con <> "" Then
            Cerrar()
        End If

    End Sub
    Public Function cta_odoc(ByVal cta As String)
        Dim con As String = ""
        If DBCon.State = ConnectionState.Closed Then
            MiConexion(bda)
            con = "closed"
        End If
        Dim tcta As New DataTable
        If cta = "caj" Then
            myCommand.CommandText = "SELECT   IF( '" & cta & "%' LIKE CONCAT( c1_caj,  '%' ) ,  'y',  'n' ) AS c  FROM `aud_otdoc` ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tcta)
            If tcta.Rows.Count > 0 Then
                Return tcta.Rows(0).Item(0)
                Exit Function
            End If
        End If

        Return ""
    End Function
    Public Function Vali_cuent_Odoc(ByVal cuenta As String, ByVal form As String, ByVal codigo As String, ByVal doc As String, ByVal bs As String)

        Dim con As String = ""
        If DBCon.State = ConnectionState.Closed Then
            MiConexion(bda)
            con = "closed"
        End If


        Dim tc As New DataTable
        Select Case cuenta
            Case "caj"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c1_caj,  '%' ) ,  'y',  'n' ) AS c  FROM `aud_otdoc` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If bs <> "" Then
                        Return (tc.Rows(0).Item("c"))
                    Else
                        If tc.Rows(0).Item("c") <> "y" Then
                            guardar_aud(form, "Caja", codigo, doc)
                        End If
                    End If
                End If
                tc.Clear()
            Case "ban"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c2_ban,  '%' ) ,  'y',  'n' ) AS c  FROM `aud_otdoc` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If bs <> "" Then
                        Return (tc.Rows(0).Item("c"))
                    Else
                        If tc.Rows(0).Item("c") <> "y" Then
                            guardar_aud(form, "Banco", codigo, doc)
                        End If
                    End If
                End If
                tc.Clear()
            Case "cxc"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c3_cxc,  '%' ) ,  'y',  'n' ) AS c  FROM `aud_otdoc` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If bs <> "" Then
                        Return (tc.Rows(0).Item("c"))
                    Else
                        If tc.Rows(0).Item("c") <> "y" Then
                            guardar_aud(form, "Cuentas x Cobrar", codigo, doc)
                        End If
                    End If
                End If
                tc.Clear()
            Case "cxp"
                myCommand.CommandText = "SELECT   IF( '" & codigo & "%' LIKE CONCAT( c4_cxp,  '%' ) ,  'y',  'n' ) AS c  FROM `aud_otdoc` ;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                If tc.Rows.Count > 0 Then
                    If bs <> "" Then
                        Return (tc.Rows(0).Item("c"))
                    Else
                        If tc.Rows(0).Item("c") <> "y" Then
                            guardar_aud(form, "Cuentas x Pagar", codigo, doc)
                        End If
                    End If
                End If
                tc.Clear()
        End Select

        If con <> "" Then
            Cerrar()
        End If
        'If DBCon.State = ConnectionState.Open Then
        '    ' MsgBox("Cerrar conex")
        '    Cerrar()
        '    'Else
        '    '    MsgBox("No Cerrar conex No hay conexion abierta")
        'End If

    End Function

    Public Sub guardar_aud(ByVal formu As String, ByVal t_cuenta As String, ByVal c_error As String, ByVal doc As String)

        Try
            Dim exist As String = ""
            Dim ta As New DataTable
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT * FROM auditoria;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(ta)

            If ta.Rows.Count > 0 Then
                For i = 0 To ta.Rows.Count - 1
                    If ta.Rows(i).Item(0) = formu And ta.Rows(i).Item(2) = PerActual And ta.Rows(i).Item(5) = t_cuenta And ta.Rows(i).Item(6) = c_error And ta.Rows(i).Item(7) = doc Then
                        exist = "si"
                    End If
                Next
            End If

            If exist = "si" Then
                myCommand.Parameters.Clear()
                myCommand.CommandText = "DELETE FROM auditoria WHERE formulario = '" & formu & "' AND usuario = '" & FrmPrincipal.lbuser.Text & "' AND periodo = '" & PerActual & "' AND tip_cuenta='" & t_cuenta & "' AND cuenta_err='" & c_error & "' AND doc_alt = '" & doc & "'"
                myCommand.ExecuteNonQuery()
            End If

            myCommand.Parameters.Clear()
            myCommand.CommandText = "INSERT INTO auditoria (formulario,usuario,periodo,dia,hora,tip_cuenta,cuenta_err,doc_alt,fec_aud)" _
              & " VALUES ('" & formu & "', '" & FrmPrincipal.lbuser.Text & "','" & PerActual & "','" & Now.Day & "','" & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString & "', '" & t_cuenta & "','" & c_error & "','" & doc & "','" & DateTime.Now.ToString("yyyy-MM-dd") & "');"
            myCommand.ExecuteNonQuery()

            Try
                Dim tae As New DataTable
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT emailconta FROM sae.companias WHERE login = '" & FrmPrincipal.lbcompania.Text & "' "
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tae)
                If tae.Rows(0).Item(0) <> "" Then
                    EnviarEmail("gmail", "sae.auditoria@gmail.com", "politicas2", "", "DETALLE DE INCONSISTENCIA: " & vbCrLf & "Modulo:" & formu & vbCrLf & "Documento: " & doc & vbCrLf & "Cuenta Afectada: " & t_cuenta & vbCrLf & "Cuenta Error: " & c_error & vbCrLf & "Realizado por el Usuario:  " & FrmPrincipal.lbuser.Text & " , fecha " & Now & vbCrLf & vbCrLf & "Favor no responder a este correo, cualquier dificultad comuniquese con los desarrolladores del software o http://csi-ingenieria.com/contactenos.php ", tae.Rows(0).Item(0), "", "IRREGULARIDADES SAE")
                End If

                Catch ex As Exception
            End Try
            
            If DBCon.State = ConnectionState.Open Then
                Cerrar()
            End If

        Catch ex As Exception
            If DBCon.State = ConnectionState.Open Then
                Cerrar()
            End If
        End Try

    End Sub

    Public Sub Guar_MovUser(ByVal form As String, ByVal tmov As String, ByVal campos As String, ByVal olf As String, ByVal nuev As String)
        Dim con As String = ""
        Try
            If DBCon.State = ConnectionState.Open Then
                Cerrar()
                con = "ab"
            End If

            Dim ubd As String = ""
            ubd = "user" & FrmPrincipal.lbcompania.Text.ToLower & Strings.Right(PerActual, 4)

            MiConexion(ubd)

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text)
            myCommand.Parameters.AddWithValue("?fech", DateTime.Now.ToString("yyyy-MM-dd"))
            'myCommand.Parameters.AddWithValue("?hora", Now.Hour & Now.Minute & Now.Second)'
            myCommand.Parameters.AddWithValue("?hora", Format(Now(), "HH:mm:ss"))
            myCommand.Parameters.AddWithValue("?form", form)
            myCommand.Parameters.AddWithValue("?tmov", tmov)
            myCommand.Parameters.AddWithValue("?camp", campos)
            myCommand.Parameters.AddWithValue("?olf", olf)
            myCommand.Parameters.AddWithValue("?nuev", nuev)
            myCommand.Parameters.AddWithValue("?per", Strings.Left(PerActual, 2))

            myCommand.CommandText = "INSERT INTO mov" & Strings.Mid(DateTime.Now.ToString("yyyy-MM-dd"), 6, 2) & " VALUES (?user,?fech,?hora,?form,?tmov,?camp,?olf,?nuev,?per);"
            myCommand.ExecuteNonQuery()
            Cerrar()

            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)

            If con <> "" Then
                MiConexion(bda)
            End If
        Catch ex As Exception
            MsgBox("Error al auditar." & ex.ToString)
            bda = "sae" & FrmPrincipal.lbcompania.Text & Strings.Right(PerActual, 4)
            If con <> "" Then
                MiConexion(bda)
            End If
        End Try
    End Sub


End Module
