Public Class FrmCierreOpciones

    Private Sub cmdcancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelar.Click
        If rb1.Checked = True Then
            MiConexion(bda)
            Cerrar()
            FrmEntradaDatos.ShowDialog()
            Me.Close()
            MsgBox("Continue con el cierre", MsgBoxStyle.Information, "Confirmacion")
        Else
            If txtctapuente.Text = "" Then
                MsgBox("Seleccione la cuenta puente ", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            If txtctaUP.Text = "" Then
                MsgBox("Seleccione la cuenta Utilidad/Perdida ", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If
            MiConexion(bda)
            Cerrar()
            cierreautomatico()
            MsgBox("El ajuste de Valores se realizó satisfactoriamente ", MsgBoxStyle.Information, "Confirmacion")
            Me.Close()
            MsgBox("Continue con el cierre", MsgBoxStyle.Information, "Confirmacion")
        End If
        lbsaldo.Text = ""
    End Sub
    Private Sub cierreautomatico()

        grilla.Rows.Clear()
        grilla.RowCount = 4


        ' ----------- UTILIDAD/PERIDA
        grilla.Item("Descripcion", 0).Value = "UTILIDAD/PERDIDA"
        If CDbl(lbsaldo.Text) < 0 Then
            grilla.Item(1, 0).Value = Moneda(lbsaldo.Text)
            grilla.Item(2, 0).Value = Moneda(0)
        Else
            grilla.Item(1, 0).Value = Moneda(0)
            grilla.Item(2, 0).Value = Moneda(lbsaldo.Text)
        End If
        grilla.Item(3, 0).Value = txtctaUP.Text
        grilla.Item(4, 0).Value = Moneda(0)
        grilla.Item(5, 0).Value = ""
        grilla.Item(6, 0).Value = "0"
        
        ' ----------- PUENTE
        grilla.Item("Descripcion", 1).Value = "PUENTE"
        If CDbl(lbsaldo.Text) < 0 Then
            grilla.Item(1, 1).Value = Moneda(0)
            grilla.Item(2, 1).Value = Moneda(lbsaldo.Text)
        Else
            grilla.Item(1, 1).Value = Moneda(lbsaldo.Text)
            grilla.Item(2, 1).Value = Moneda(0)
        End If
        grilla.Item(3, 1).Value = txtctapuente.Text
        grilla.Item(4, 1).Value = Moneda(0)
        grilla.Item(5, 1).Value = ""
        grilla.Item(6, 1).Value = "0"

        '-------------------------------------------

        Dim td As New DataTable
        td.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT tipodoc, actual12 FROM `tipdoc` WHERE grupo='AJ' and tipodoc = 'AJ'  ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(td)
        Refresh()

        '-------------------------------------------


        Dim cad As String = ""
        Dim db As String = ""
        Dim cr As String = ""

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
                If cad <> "" And (db <> 0 Or cr <> 0) Then
                    InsertContabilidad(i, td.Rows(0).Item("actual12"), td.Rows(0).Item("tipodoc"))
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub
    Public Sub InsertContabilidad(ByVal fila As Integer, ByVal doc As Integer, ByVal tdoc As String)
        MiConexion(bda)
        BuscarPeriodo()


        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?item", fila + 1)
            myCommand.Parameters.AddWithValue("?doc", doc + 1)
            myCommand.Parameters.AddWithValue("?tipodoc", tdoc)
            myCommand.Parameters.AddWithValue("?periodo", PerActual)
            myCommand.Parameters.AddWithValue("?dia", Now.Day.ToString)
            myCommand.Parameters.AddWithValue("?centro", "0")
            myCommand.Parameters.AddWithValue("?descrip", CambiaCadena(grilla.Item("Descripcion", fila).Value, 49))
            Try
                myCommand.Parameters.AddWithValue("?debito", DIN(Moneda(grilla.Item("Debitos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?debito", "0")
            End Try
            Try
                myCommand.Parameters.AddWithValue("?credito", DIN(Moneda(grilla.Item("Creditos", fila).Value)))
            Catch ex As Exception
                myCommand.Parameters.AddWithValue("?credito", "0")
            End Try
            myCommand.Parameters.AddWithValue("?codigo", grilla.Item("cuenta", fila).Value)
            myCommand.Parameters.AddWithValue("?base", DIN(Moneda(grilla.Item("base", fila).Value)))
            myCommand.Parameters.AddWithValue("?diasv", Val(0))
            myCommand.Parameters.AddWithValue("?fechaven", "00/00/0000")
            myCommand.Parameters.AddWithValue("?nit", grilla.Item("nitc", fila).Value)
            myCommand.Parameters.AddWithValue("?cheque", "")

            myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
            'INSERTAR CONTABLE
            myCommand.CommandText = "INSERT INTO documentos" & Strings.Left(PerActual, 2) & " " _
                                  & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?descrip,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error Insertar Contable" & ex.ToString)
        End Try

        Try
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?num", doc + 1)
            myCommand.CommandText = "UPDATE tipdoc SET  actual12=?num WHERE grupo='AJ' and descripcion= 'AJUSTE DE CONTABILIDAD'"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error ACTUALIZAR CONSECUTIVO" & ex.ToString)
        End Try

        Cerrar()
    End Sub

    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            grcu.Enabled = False
        Else
            grcu.Enabled = True
        End If
    End Sub

    Private Sub txtctapuente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctapuente.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "cierreOp"
        If FrmCuentas.txtcuenta.Text = txtctapuente.Text Then
            FrmCuentas.txtcuenta.Text = ""
        Else
            FrmCuentas.txtcuenta.Text = txtctapuente.Text
        End If
        FrmCuentas.ShowDialog()
    End Sub

    Private Sub txtctaUP_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtctaUP.DoubleClick
        FrmCuentas.lbaux.Text = "auxiliar"
        FrmCuentas.lbform.Text = "cierreOUP"
        If FrmCuentas.txtcuenta.Text = txtctaUP.Text Then
            FrmCuentas.txtcuenta.Text = ""
        Else
            FrmCuentas.txtcuenta.Text = txtctaUP.Text
        End If
        FrmCuentas.ShowDialog()
    End Sub
End Class