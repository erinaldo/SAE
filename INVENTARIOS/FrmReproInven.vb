Imports System.IO
Imports MySql.Data.MySqlClient

Imports System.Data.OleDb
Imports System.Net.Mail
Imports System
Imports System.Object
Public Class FrmReproInven

    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub


    Public Sub Bt_repro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_repro.Click
        Dim resultado As MsgBoxResult
        resultado = MsgBox("El inventario será reprocesado, El proceso puede tardar algunos minutos ¿Desea Reprocesarlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            '    Me.Close()
            'Else
           
            Label1.Visible = False

            mibarra.Value = 0
            mibarra.Visible = True
            Try
                FrmConteoFisInv.mibarra.Value = 0
                FrmConteoFisInv.mibarra.Visible = True
            Catch ex As Exception
            End Try

            Dim it As Integer = 0
            Dim nbod As Integer = 0
            Dim sql As String = ""
            Dim sql2 As String = ""
            Dim sql3 As String = ""
            Dim sql4 As String = ""
            Dim codA As String = ""
            Dim per As String = ""
            MiConexion(bda)
            Me.Cursor = Cursors.WaitCursor

            Try
                Dim tabla As New DataTable
                tabla = New DataTable
                myCommand.CommandText = "SELECT count(numbod) as cont from bodegas;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Dim tabla4 As New DataTable
                tabla4 = New DataTable

                Dim cant As String = ""
                nbod = tabla.Rows(0).Item(0)

                For i = 1 To nbod
                    If i = 1 Then
                        cant = "c.cant" & i
                    Else
                        cant = cant & " , c.cant" & i
                    End If
                Next
                sql = "SELECT a.*," & cant & " FROM articulos a LEFT JOIN (con_inv c) ON a.codart=c.codart WHERE c.periodo='00' "
                cant = ""
                Dim tabla2 As New DataTable
                tabla2 = New DataTable
                myCommand.CommandText = sql
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                mibarra.Maximum = tabla2.Rows.Count
                it = 1
                'MsgBox(it & " -- ")
                ' while Xiam
                For i = 0 To tabla2.Rows.Count - 1
                    Try


                        codA = tabla2.Rows(i).Item("codart")
                        cant = ""
                        For j = 1 To nbod
                            If j = 1 Then
                                cant = "cant" & j & "=" & tabla2.Rows(i).Item("cant" & j)
                            Else
                                cant += ", cant" & j & "=" & tabla2.Rows(i).Item("cant" & j)
                            End If
                        Next
                        sql2 = "UPDATE con_inv SET " & cant & " WHERE codart='" & codA & "' AND periodo >='01';"
                        myCommand.CommandText = sql2
                        myCommand.ExecuteNonQuery()
                        For k = 1 To 12
                            If k < 10 Then
                                per = "0" & k
                            Else
                                per = k
                            End If

                            cant = ""
                            For k2 = 1 To nbod
                                If k2 = nbod Then
                                    cant += "( IFNULL((SELECT SUM(d.cantidad) FROM deta_mov" & per & " d LEFT JOIN (movimientos" & per & " m) ON d.doc=m.doc WHERE d.bod_des='" & k2 & "' AND m.estado='AP' AND d.codart = '" & codA & "'),'0') - " _
                                    & " IFNULL((SELECT SUM(d.cantidad) FROM deta_mov" & per & " d LEFT JOIN (movimientos" & per & " m) ON d.doc=m.doc WHERE d.bod_ori='" & k2 & "' AND m.estado='AP' AND d.codart = '" & codA & "'),'0') ) AS cant" & k2 & " "
                                Else
                                    cant += "( IFNULL((SELECT SUM(d.cantidad) FROM deta_mov" & per & " d LEFT JOIN (movimientos" & per & " m) ON d.doc=m.doc WHERE d.bod_des='" & k2 & "' AND m.estado='AP' AND d.codart = '" & codA & "'),'0') - " _
                                   & " IFNULL((SELECT SUM(d.cantidad) FROM deta_mov" & per & " d LEFT JOIN (movimientos" & per & " m) ON d.doc=m.doc WHERE d.bod_ori='" & k2 & "' AND m.estado='AP' AND d.codart = '" & codA & "'),'0') ) AS cant" & k2 & " ,  "
                                End If
                            Next
                            sql3 = "SELECT  d.codart," & cant & ",m.estado FROM deta_mov" & per & " d LEFT JOIN (movimientos" & per & " m) ON d.doc=m.doc WHERE d.codart='" & codA & "' AND m.estado='AP' group by d.codart"
                            tabla4.Clear()
                            myCommand.CommandText = sql3
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla4)
                            For ii = 0 To tabla4.Rows.Count - 1
                                cant = ""

                                For j2 = 1 To nbod
                                    If j2 = nbod Then
                                        cant += "cant" & j2 & " = cant" & j2 & " + " & DIN(Moneda(tabla4.Rows(ii).Item("cant" & j2)))
                                    Else
                                        cant += "cant" & j2 & " = cant" & j2 & " + " & DIN(Moneda(tabla4.Rows(ii).Item("cant" & j2))) & " , "
                                    End If
                                Next
                                sql4 = "UPDATE con_inv SET " & cant & " WHERE codart = '" & codA & "' AND periodo >= '" & per & "';"
                                myCommand.CommandText = sql4
                                myCommand.ExecuteNonQuery()
                            Next
                        Next
                        mibarra.Value = mibarra.Value + it
                        If mibarra.Value + it + 5 > mibarra.Maximum Then
                            mibarra.Value = mibarra.Value - 5
                        End If

                        Try
                            FrmConteoFisInv.mibarra.Value = mibarra.Value + it
                            If FrmConteoFisInv.mibarra.Value + it + 5 > FrmConteoFisInv.mibarra.Maximum Then
                                FrmConteoFisInv.mibarra.Value = FrmConteoFisInv.mibarra.Value - 5
                            End If
                        Catch ex2 As Exception
                        End Try
                    Catch ex As Exception
            MsgBox("sql4" & "******" & ex.ToString)
        End Try
                Next
        ' Fin while Xiam
        Me.Cursor = Cursors.Default
        Try
                    FrmConteoFisInv.mibarra.Visible = False
        Catch ex As Exception
        End Try
        mibarra.Visible = False
        Me.Close()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("INVENTARIO", "REPROCESAR INVENTARIO", "", "", "")
        End If
        MsgBox("Inventario Reprocesado Correctamente...", MsgBoxStyle.Information, "SAE Reprocesar Inventarios")
            Catch ex As Exception
            Me.Cursor = Cursors.Default
            Try
                    FrmConteoFisInv.mibarra.Visible = False
            Catch ex1 As Exception
            End Try
            mibarra.Visible = False
            MsgBox(ex.ToString)
        End Try
        Cerrar()

        End If
    End Sub

    Private Sub FrmReproInven_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class