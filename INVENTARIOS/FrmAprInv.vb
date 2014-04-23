Imports MySql.Data.MySqlClient
Public Class FrmAprInv
    Dim p As String
    Dim conexion As New MySqlConnection
    Dim cadena As String
    Dim concep As Integer = 0

    Private Sub FrmAprFac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = PerActual(0) & PerActual(1)
        txtaño.Text = PerActual(2) & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
    End Sub

    Private Sub cmdpantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpantalla.Click

        Dim resultado As MsgBoxResult
        Dim ndoc As String = ""
        Dim tmov As String = ""
        Dim tipo As String = ""
        Dim cli As String = ""
        conexion.Close()
        p = cbper.Text

        grilla.Rows.Clear()
        cadena = datosconR(bda)
        conexion.ConnectionString = cadena
        conexion.Open()

        Dim tabla As New DataTable
        myCommand.CommandText = " SELECT IFNULL(trim(concat(t.nombre,' ',t.apellidos)),'NOMBRE') as nombre, m.doc, m.tipo_mov, m.tipo   FROM movimientos" & p & " m LEFT join terceros t on t.nit = m.nitc WHERE m.estado <> 'AP';"
        '  myCommand.CommandText = " SELECT IFNULL(trim(concat(t.nombre,' ',t.apellidos)),'NOMBRE') as nombre, m.doc, m.tipo_mov, m.tipo   FROM movimientos" & p & " m LEFT join terceros t on t.nit = m.nitc WHERE m.estado <> 'AP'  and m.doc in ('SA00001', 'AI00001')  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)


        If tabla.Rows.Count > 0 Then
            resultado = MsgBox("Desea aprobar todos los documentos del  periodo " & p & " ?", MsgBoxStyle.YesNo, "Confirmacion")
            If resultado = MsgBoxResult.No Then
                Me.Close()
            Else
                Dim it As Integer = 0
                mibarra.Value = 0
                mibarra.Visible = True
                mibarra.Maximum = tabla.Rows.Count
                it = 1
                Me.Cursor = Cursors.WaitCursor

                For i = 0 To tabla.Rows.Count - 1
                    ndoc = tabla.Rows(i).Item("doc")
                    tmov = tabla.Rows(i).Item("tipo_mov")
                    tipo = tabla.Rows(i).Item("tipo")
                    cli = tabla.Rows(i).Item("nombre")

                    If con_inv(ndoc, tmov, tipo) <> "no" Then
                        aprobar(ndoc)
                        If tmov <> "T" Then
                            contable(ndoc, tmov, tipo, cli)
                        End If
                    End If
                    mibarra.Value = mibarra.Value + it
                Next
                mibarra.Visible = False
                Me.Cursor = Cursors.Default
                MsgBox("El proceso se realizo con exito")
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Guar_MovUser("INVENTARIO", "APROBAR TODOS LOS DOCUMENTOS DEL PERIODO " & cbper.Text, "", "", "")
                End If
            End If
        Else
            MsgBox(" No existen documentos pendientes para aprobar en el periodo " & p & " ")
        End If


    End Sub

    Private Sub aprobar(ByVal doc As String)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE movimientos" & p & " SET estado = 'AP' WHERE doc = '" & doc & "'  "
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function ValidarCantidades(ByVal bodega As String, ByVal art As String, ByVal cant As Integer)
        Dim tbc As New DataTable
        tbc.Clear()
        myCommand.CommandText = "SELECT cant" & bodega & " FROM con_inv WHERE codart='" & art & "' and  periodo='" & p & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tbc)
        Refresh()
        If (CInt(tbc.Rows(0).Item(0)) - DIN(cant)) < 0 Then
            ' MsgBox("La cantidad disponible del articulo " & gfactura.Item(1, fila).Value & ", es " & tbc.Rows(0).Item(0) & " , Verifique", MsgBoxStyle.Information, "Verifique")
            Return (False)
            Exit Function
        End If
        Return (True)
    End Function

    Function con_inv(ByVal doc As String, ByVal tmov As String, ByVal tipo As String)
        Dim art As String = ""
        Dim bod As String = ""
        Dim cant As String = ""
        Dim cad As String = ""
        Dim par As String = ""

        Dim tabla_d As New DataTable
        tabla_d.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = " SELECT doc, codart,  bod_ori ,  bod_des, cantidad FROM deta_mov" & p & " WHERE doc = '" & doc & "'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_d)

        Dim tc As New DataTable
        tc.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT lista_art FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows.Count > 0 Then
            If tc.Rows(0).Item(0) = "SI" Then
                par = "SI"
            End If
        End If

        '... VERIFICAR CANTIDAES
        If tabla_d.Rows.Count > 0 Then
            For j = 0 To tabla_d.Rows.Count - 1
                art = tabla_d.Rows(j).Item("codart")
                cant = tabla_d.Rows(j).Item("cantidad")
                '/// VERIF CAN  
                If par = "SI" Then
                    If tmov = "A" Then
                        If tipo <> "ENTRADA" Then
                            bod = tabla_d.Rows(j).Item("bod_des")
                            If ValidarCantidades(bod, art, cant) = False Then
                                Return ("no")
                                Exit Function
                            End If
                        End If
                    Else
                        If tmov = "S" Then
                            bod = tabla_d.Rows(j).Item("bod_ori")
                            If ValidarCantidades(bod, art, cant) = False Then
                                Return ("no")
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next
        End If
        '...


        If tabla_d.Rows.Count > 0 Then
            For i = 0 To tabla_d.Rows.Count - 1
                art = tabla_d.Rows(i).Item("codart")
                cant = tabla_d.Rows(i).Item("cantidad")

                If tmov = "A" Then
                    If tipo = "ENTRADA" Then
                        bod = tabla_d.Rows(i).Item("bod_ori")
                        cad = " cant" & bod & " = cant" & bod & " + " & cant & ""
                    Else
                        bod = tabla_d.Rows(i).Item("bod_des")
                        cad = " cant" & bod & " = cant" & bod & " - " & cant & ""
                    End If
                Else
                    If tmov = "T" Then
                        cad = " cant" & tabla_d.Rows(i).Item("bod_ori") & " = cant" & tabla_d.Rows(i).Item("bod_ori") & " - " & cant & ", cant" & tabla_d.Rows(i).Item("bod_des") & " = cant" & tabla_d.Rows(i).Item("bod_des") & " + " & cant & " "
                    ElseIf tmov = "E" Then
                        cad = " cant" & tabla_d.Rows(i).Item("bod_des") & " = cant" & tabla_d.Rows(i).Item("bod_des") & " + " & cant & ""
                    ElseIf tmov = "S" Then
                        cad = " cant" & tabla_d.Rows(i).Item("bod_ori") & " = cant" & tabla_d.Rows(i).Item("bod_ori") & " - " & cant & ""
                    End If
                End If

                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "UPDATE con_inv SET " & cad & " WHERE codart = '" & art & "' and  periodo >='" & p & "' "
                    myCommand.Connection = conexion
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
        End If
        Return ("si")
    End Function

    Dim tabla_d As New DataTable

    Private Sub contable(ByVal doc As String, ByVal tmov As String, ByVal tipo As String, ByVal cli As String)

        tabla_d.Rows.Clear()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parafacgral;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        Dim n As Integer = 1
        Dim bod As String = ""
        Dim cd As String = ""
        grilla.RowCount = 1
        grilla.Rows.Clear()
        grilla.RowCount = 30

        If tabla.Rows(0).Item("intecontab").ToString = "SI" Then 'HAY INTERFAZ CONTABLE
            Dim tdoc As String = ""
            BuscarPeriodo()
            tdoc = "documentos" & PerActual(0) & PerActual(1)
            '************************************************
            '..... detafac
            myCommand.CommandText = " SELECT * FROM deta_mov" & p & "  where  doc ='" & doc & "'  "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla_d)
            Refresh()

            grilla.RowCount = grilla.RowCount + 1
            For i = 0 To tabla_d.Rows.Count - 1

                If tmov = "A" Then
                    If tipo = "ENTRADA" Then
                        bod = tabla_d.Rows(i).Item("bod_ori")
                        tipo = "AJUSTE SALIDA A BOD." & bod
                        cd = "AJUSTE"
                    Else
                        bod = tabla_d.Rows(i).Item("bod_des")
                        tipo = "AJUSTE ENTRADA A BOD." & bod
                        cd = "AJUSTE"
                    End If
                Else
                    If tmov = "E" Then
                        bod = tabla_d.Rows(i).Item("bod_des")
                        tipo = "ENTRADA A BOD." & bod
                    ElseIf tmov = "S" Then
                        bod = tabla_d.Rows(i).Item("bod_ori")
                        tipo = "SALIDA A BOD." & bod
                    End If
                End If
                MovimientoContable(i, "inv", tabla_d.Rows(i).Item("cta_inv"), tipo & " " & cli)
                MovimientoContable(i, "cventa", tabla_d.Rows(i).Item("cta_cos"), cli & Trim(cd) & " A VENTAS ")
            Next
            '    '********************************************************************

            Dim cad As String
            Dim db, cr As Double
            For i = 0 To grilla.RowCount - 1
                Try
                    Try
                        cad = grilla.Item("cuenta", i).Value.ToString
                    Catch ex As Exception
                        cad = ""
                    End Try
                    Try
                        db = grilla.Item("Debitos", i).Value
                    Catch ex As Exception
                        db = 0
                    End Try
                    Try
                        cr = grilla.Item("Creditos", i).Value
                    Catch ex As Exception
                        cr = 0
                    End Try
                    If cad <> "" And (db > 0 Or cr > 0) Then
                        InsertContabilidad(i, tdoc, doc, n)
                        n = n + 1
                    End If
                Catch ex As Exception
                    'MsgBox(ex.ToString)
                End Try
            Next
        End If

    End Sub

    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal tabla As String, ByVal doc As String, ByVal n As Integer)

        Dim tabla_m As New DataTable
        myCommand.CommandText = " SELECT * FROM `movimientos" & p & "` where doc ='" & doc & "' "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla_m)
        Refresh()
        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", n)
            myCommand.Parameters.AddWithValue("?doc", tabla_m.Rows(0).Item("num"))
            myCommand.Parameters.AddWithValue("?tipodoc", tabla_m.Rows(0).Item("tipodoc"))
            myCommand.Parameters.AddWithValue("?periodo", tabla_m.Rows(0).Item("per"))
            myCommand.Parameters.AddWithValue("?dia", tabla_m.Rows(0).Item("dia"))
            myCommand.Parameters.AddWithValue("?centro", tabla_m.Rows(0).Item("cc"))
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item("Debitos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item("Creditos", fila).Value))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", "0")
            myCommand.Parameters.AddWithValue("?diasv", "0")
            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            myCommand.Parameters.AddWithValue("?nit", tabla_m.Rows(0).Item("nitc"))
            myCommand.Parameters.AddWithValue("?modulo", "inventarios")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO " & tabla & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?modulo);"
            myCommand.Connection = conexion
            myCommand.ExecuteNonQuery()
            '   ActualizarMisCuentas(grilla.Item("cuenta", fila).Value, grilla.Item("Debitos", fila).Value, grilla.Item("Creditos", fila).Value)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Sub MovimientoContable(ByVal fo As Integer, ByVal tipo As String, ByVal cuenta As String, ByVal descrip As String)

        If cuenta = "" Then Exit Sub
        Dim sw, j, k As Integer
        Dim cad, des As String
        sw = 0

        For j = 0 To grilla.RowCount - 1
            k = j
            Try
                cad = grilla.Item("cuenta", j).Value.ToString
            Catch ex As Exception
                cad = ""
            End Try
            Try
                des = grilla.Item("Descripcion", j).Value.ToString
            Catch ex As Exception
                des = ""
            End Try
            '***************************
            If cad = "" And des = "" Then
                grilla.Item("cuenta", j).Value = cuenta
                grilla.Item("Descripcion", j).Value = descrip
                sw = 1
                Exit For
            ElseIf cad = cuenta Then
                If des = descrip Then
                    sw = 1
                    Exit For
                End If
            End If
        Next j
        j = k
        If sw = 0 Then
            grilla.RowCount = grilla.RowCount + 1
            grilla.Item("cuenta", k).Value = cuenta
            grilla.Item("Descripcion", k).Value = descrip
            grilla.RowCount = grilla.RowCount + 1
        End If

        Dim db, cr, monto As Double
        monto = 0
        Try
            db = grilla.Item("Debitos", j).Value
        Catch ex As Exception
            db = 0
        End Try
        Try
            cr = grilla.Item("Creditos", j).Value
        Catch ex As Exception
            cr = 0
        End Try

        Select Case tipo
            Case "inv"
                Try
                    monto = CDbl(tabla_d.Rows(fo).Item("valor")) * CDbl(tabla_d.Rows(fo).Item("cantidad"))
                Catch ex As Exception
                    monto = 0
                End Try
                grilla.Item("Debitos", j).Value = db
                grilla.Item("Creditos", j).Value = cr + monto
            Case "cventa"
                Try
                    monto = CDbl(tabla_d.Rows(fo).Item("valor")) * CDbl(tabla_d.Rows(fo).Item("cantidad"))
                Catch ex As Exception
                    monto = 0
                End Try
                grilla.Item("Debitos", j).Value = db + monto
                grilla.Item("Creditos", j).Value = cr
        End Select
    End Sub

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub


End Class