Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class FrmParContable

    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        Me.Close()
    End Sub

    Function validaropciones() As Boolean
        Dim x As Integer, y As Integer
        y = Val(txtlongitudcod.Text)
        x = Val(txtniv1.Text) + Val(txtniv2.Text) + Val(txtniv3.Text) + Val(txtniv4.Text) + Val(txtniv5.Text)
        If x = y Then
            borrardatos()
            validaropciones = True
            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    Dim ant As String = ""
                    Dim nue As String = ""
                    If rb_si.Checked = True And cc = "N" Then
                        ant = "NO"
                        nue = "SI"
                    ElseIf rb_si.Checked = False And cc = "S" Then
                        ant = "SI"
                        nue = "NO"
                    End If
                    If ant <> "" Then
                        '........
                        Guar_MovUser("CONTABILIDAD", "MODIFICAR NIVELES DE CUENTAS Y CENTROS DE COSTOS ", "CENTRO DE COSTO", ant, nue)
                        '.............
                    End If

                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        Else
            validaropciones = False
            Try
                If FrmPrincipal.cmdAuditoria.Visible = True Then
                    '........
                    Guar_MovUser("CONTABILIDAD", "GUARDAR NIVELES DE CUENTAS Y CENTROS DE COSTOS ", "", "", "")
                    '.............
                End If
            Catch ex As Exception
                MsgBox("Error al Auditar el movimiento " & ex.ToString, MsgBoxStyle.Information, "SAE")
            End Try
        End If
    End Function

    Private Sub CmdRegistrarCambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRegistrarCambios.Click
        If bas_con <> "E" Then
            MsgBox("No tienes permisos para esta operación.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        '........

        If rb_si.Checked = True Then
            If txtnivcc.Text = "2" Then
                If CInt(txtnc4.Text) < CInt(txtnc1.Text) Then
                    MsgBox("La longitud del Centro no puede ser menor a la del Grupo", MsgBoxStyle.Information, "Verificación")
                    Exit Sub
                End If
            End If
            If txtnivcc.Text = "3" Then
                If (CInt(txtnc4.Text) < CInt(txtnc2.Text)) Or (CInt(txtnc2.Text) < CInt(txtnc1.Text)) Then
                    MsgBox("Verifique la longitud de los centros de costo", MsgBoxStyle.Information, "Verificación")
                    Exit Sub
                End If
            End If
            If txtnivcc.Text = "4" Then
                If (CInt(txtnc4.Text) < CInt(txtnc3.Text)) Or (CInt(txtnc3.Text) < CInt(txtnc2.Text)) Or (CInt(txtnc2.Text) < CInt(txtnc1.Text)) Then
                    MsgBox("Verifique la longitud de los centros de costo", MsgBoxStyle.Information, "Verificación")
                    Exit Sub
                End If
            End If

        End If

        Dim sql As MySqlCommand = New MySqlCommand
        Dim dr As System.Data.IDataReader, buscaruser As Boolean, opcion As String
        buscaruser = False
        If validaropciones() Then
            If rb_si.Checked = True Then
                opcion = "S"
            Else
                opcion = "N"
            End If
            DBCon.Open()
            sql.Connection = DBCon
            sql.CommandText = "insert into parcontab values ('" + txtlongitudcod.Text + "','" + txtnivcue.Text + "','" + txtniv1.Text + "','" + txtniv2.Text + "','" + txtniv3.Text + "','" + txtniv4.Text + "','" + txtniv5.Text + "','" + opcion + "')"
            sql.CommandType = CommandType.Text
            dr = sql.ExecuteReader()
            DBCon.Close()
            If rb_si.Checked = True Then
                GuardCentroCosto()
            End If
            MsgBox("Los Niveles Fueron Guadados Exitosamente.", MsgBoxStyle.Information, "SAE, Guardar Niveles")
            Me.Close()
        Else
            MsgBox("Error Revise los Datos Longitud del Codigo Contable es Diferente a valor de Los Niveles", MsgBoxStyle.Critical, "SAE, Verificación")
        End If
    End Sub
    Private Sub GuardCentroCosto()
        MiConexion(bda)
        Try

            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?ccn", txtnivcc.Text)
            If txtnc1.Enabled = True Then
                myCommand.Parameters.AddWithValue("?n1", "Grupo")
                myCommand.Parameters.AddWithValue("?l1", CInt(txtnc1.Text))
            Else
                myCommand.Parameters.AddWithValue("?n1", "")
                myCommand.Parameters.AddWithValue("?l1", 0)
            End If
            If txtnc2.Enabled = True Then
                myCommand.Parameters.AddWithValue("?n2", "SubGrupo")
                myCommand.Parameters.AddWithValue("?l2", CInt(txtnc2.Text))
            Else
                myCommand.Parameters.AddWithValue("?n2", "")
                myCommand.Parameters.AddWithValue("?l2", 0)
            End If
            If txtnc3.Enabled = True Then
                myCommand.Parameters.AddWithValue("?n3", "Tipo")
                myCommand.Parameters.AddWithValue("?l3", CInt(txtnc3.Text))
            Else
                myCommand.Parameters.AddWithValue("?n3", "")
                myCommand.Parameters.AddWithValue("?l3", 0)
            End If
            If txtnc4.Enabled = True Then
                myCommand.Parameters.AddWithValue("?n4", "Centro")
                myCommand.Parameters.AddWithValue("?l4", CInt(txtnc4.Text))
            Else
                myCommand.Parameters.AddWithValue("?n4", "")
                myCommand.Parameters.AddWithValue("?l4", 0)
            End If
            myCommand.CommandText = "INSERT INTO ccnivel " _
                                     & " VALUES(?ccn,?n1,?l1,?n2,?l2,?n3,?l3,?n4,?l4);"
            myCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error verifique los niveles de los centros de costo", MsgBoxStyle.Information, "Verificacion")
        End Try
        Cerrar()
    End Sub

    Sub borrardatos()
        Try
            Dim sql As MySqlCommand = New MySqlCommand
            Dim dr As System.Data.IDataReader
            DBCon.Open()
            sql.Connection = DBCon
            sql.CommandText = "delete from parcontab"
            sql.CommandType = CommandType.Text
            dr = sql.ExecuteReader()
        Catch ex As Exception
            If DBCon.State = ConnectionState.Open Then DBCon.Close()
        End Try

        Try
            MiConexion(bda)
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM ccnivel"
            myCommand.ExecuteNonQuery()
            Cerrar()
        Catch ex As Exception
        End Try
       

        

    End Sub
    Private Sub FrmParContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT count(*) from selpuc where nivel='Auxiliar';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows(0).Item(0) > 0 Then
                txtlongitudcod.Enabled = False
                txtnivcue.Enabled = False
                txtniv1.Enabled = False
                txtniv2.Enabled = False
                txtniv3.Enabled = False
                txtniv4.Enabled = False
                txtniv5.Enabled = False
                
            End If
        Catch ex As Exception
        End Try
        NivelesDeCuentas()
    End Sub
    Public Sub BuscNivelesCC()
        Dim tc As New DataTable
        myCommand.CommandText = "SELECT * FROM ccnivel ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        Refresh()

        If tc.Rows.Count > 0 Then
            gncc.Enabled = False
            txtnivcc.Text = tc.Rows(0).Item("numnv")
            txtnivcc_SelectedIndexChanged(AcceptButton, AcceptButton)
            'Grupo
            If tc.Rows(0).Item("lon1") = 0 Then
                txtnc1.Text = "0"
            Else
                If tc.Rows(0).Item("lon1") < 10 Then
                    txtnc1.Text = "0" & tc.Rows(0).Item("lon1")
                Else
                    txtnc1.Text = tc.Rows(0).Item("lon1")
                End If
            End If
            'Subgrupo
            If tc.Rows(0).Item("lon2") = 0 Then
                txtnc1.Text = "0"
            Else
                If tc.Rows(0).Item("lon2") < 10 Then
                    txtnc2.Text = "0" & tc.Rows(0).Item("lon2")
                Else
                    txtnc2.Text = tc.Rows(0).Item("lon2")
                End If
            End If
            'Tipo
            If tc.Rows(0).Item("lon3") = 0 Then
                txtnc3.Text = "0"
            Else
                If tc.Rows(0).Item("lon3") < 10 Then
                    txtnc3.Text = "0" & tc.Rows(0).Item("lon3")
                Else
                    txtnc3.Text = tc.Rows(0).Item("lon3")
                End If
            End If
            'Centro
            If tc.Rows(0).Item("lon4") = 0 Then
                txtnc4.Text = "0"
            Else
                If tc.Rows(0).Item("lon4") < 10 Then
                    txtnc4.Text = "0" & tc.Rows(0).Item("lon4")
                Else
                    txtnc4.Text = tc.Rows(0).Item("lon4")
                End If
            End If
        Else
            gncc.Enabled = True
        End If


    End Sub
 
    Private Sub rb_no_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_no.CheckedChanged
        If rb_no.Checked = True Then
            gncc.Enabled = False
        Else
            gncc.Enabled = True
        End If
    End Sub

    Private Sub txtnivcc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnivcc.SelectedIndexChanged
        If txtnivcc.Text = "1" Then
            txtnc1.Enabled = False
            txtnc2.Enabled = False
            txtnc3.Enabled = False
            txtnc4.Enabled = True
        ElseIf txtnivcc.Text = "2" Then
            txtnc1.Enabled = True
            txtnc2.Enabled = False
            txtnc3.Enabled = False
            txtnc4.Enabled = True
        ElseIf txtnivcc.Text = "3" Then
            txtnc1.Enabled = True
            txtnc2.Enabled = True
            txtnc3.Enabled = False
            txtnc4.Enabled = True
        ElseIf txtnivcc.Text = "4" Then
            txtnc1.Enabled = True
            txtnc2.Enabled = True
            txtnc3.Enabled = True
            txtnc4.Enabled = True
        End If
        'If txtnivcc.Text = "2" Then
        '    txtnc1.Enabled = True
        '    txtnc2.Enabled = True
        'Else
        '    txtnc1.Enabled = False
        '    txtnc1.Text = "0"
        '    txtnc2.Enabled = False
        '    txtnc2.Text = "0"
        'End If
        'If txtnivcc.Text = "3" Then
        '    txtnc1.Enabled = True
        '    txtnc2.Enabled = True
        '    txtnc3.Enabled = True
        'Else
        '    txtnc1.Enabled = False
        '    txtnc1.Text = "0"
        '    txtnc2.Enabled = False
        '    txtnc2.Text = "0"
        '    txtnc3.Enabled = False
        '    txtnc3.Text = "0"
        'End If
        'If txtnivcc.Text = "4" Then
        '    txtnc1.Enabled = True
        '    txtnc2.Enabled = True
        '    txtnc3.Enabled = True
        '    txtnc4.Enabled = True
        'Else
        '    txtnc1.Enabled = False
        '    txtnc1.Text = "0"
        '    txtnc2.Enabled = False
        '    txtnc2.Text = "0"
        '    txtnc3.Enabled = False
        '    txtnc3.Text = "0"
        '    txtnc4.Enabled = False
        '    txtnc4.Text = "0"
        'End If
    End Sub


End Class