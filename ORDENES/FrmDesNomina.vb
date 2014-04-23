Public Class FrmDesNomina

    Private Sub cbper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbper.SelectedIndexChanged
        Try
            grilla.Rows.Clear()
            gitems.Rows.Clear()
            gitems.RowCount = 1
            lbtotal.Text = "0,00"
            lbter.Text = ""
            cmddes.Enabled = False
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM datos_nomina " _
            & "WHERE periodo='" & Trim(cbper.Text) & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6) & "' ORDER BY inicio;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("No hay nominas causadas en el periodo( " & Trim(cbper.Text) & " ), verifique.  ", MsgBoxStyle.Information)
                grilla.RowCount = 1
                Exit Sub
            Else
                grilla.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    grilla.Item("nomina", i).Value = tabla.Rows(i).Item("nombre_nomina")
                    grilla.Item("periodo", i).Value = tabla.Rows(i).Item("periodo")
                    grilla.Item("documento", i).Value = tabla.Rows(i).Item("tipodoc")
                    grilla.Item("inicio", i).Value = NumeroDoc(tabla.Rows(i).Item("inicio"))
                    grilla.Item("fin", i).Value = NumeroDoc(tabla.Rows(i).Item("fin"))
                    grilla.Item("dg", i).Value = "DesenGlobar"
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub FrmDesNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbper.Text = FrmEgresoNomina.cbper.Text
        cmddes.Enabled = False
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick
        Select Case e.ColumnIndex
            Case 5
                BuscarCta(e.RowIndex)
            Case 4
        End Select
    End Sub
    Public Sub BuscarCta(ByVal fila As Integer)
        Try
            Dim suma As Double = 0
            gitems.Rows.Clear()
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM documentos" & cbper.Text _
            & " WHERE tipodoc='" & grilla.Item("documento", fila).Value & "' " _
            & " AND doc >= " & Val(grilla.Item("inicio", fila).Value) & " " _
            & " AND doc <= " & Val(grilla.Item("fin", fila).Value) & " " _
            & " AND codigo='" & lbcta.Text & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("No hay datos para mostrar, verifique.  ", MsgBoxStyle.Information)
                gitems.RowCount = 1
                Exit Sub
            Else
                gitems.RowCount = tabla.Rows.Count + 1
                lbter.Text = "Hay " & tabla.Rows.Count & " Terceros en la Consulta."
                For i = 0 To tabla.Rows.Count - 1
                    gitems.Item("tercero", i).Value = DatosTercero(tabla.Rows(i).Item("nit"))
                    gitems.Item("nit", i).Value = tabla.Rows(i).Item("nit")
                    gitems.Item("db", i).Value = Moneda(tabla.Rows(i).Item("debito"))
                    gitems.Item("cr", i).Value = Moneda(tabla.Rows(i).Item("credito"))
                    gitems.Item("cta", i).Value = tabla.Rows(i).Item("codigo")
                    suma = suma + CDbl(tabla.Rows(i).Item("debito")) + CDbl(tabla.Rows(i).Item("credito"))
                Next
                lbtotal.Text = Moneda(suma)
                If lbtotal.Text = lbvalor.Text Then
                    cmddes.Enabled = True
                Else
                    cmddes.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Function DatosTercero(ByVal nit As String)
        Dim nom As String = ""
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ter FROM terceros where nit='" & nit & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            nom = tabla.Rows(0).Item("ter")
        Catch ex As Exception
        End Try
        Return UCase(nom)
    End Function

    Private Sub lbcuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbcuenta.Click

    End Sub

    Private Sub cmddes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddes.Click
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Los datos de la cuenta " & gitems.Item("cta", 0).Value & " serán desenglobados, ¿Desea Realizar los Cambios?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.Yes Then
            MiConexion(bda)
            Try
                myCommand.CommandText = "DELETE FROM documentos" & FrmEgresoNomina.cbper.Text & " where " _
                & "doc='" & Val(FrmEgresoNomina.txtnumero.Text) & "' AND tipodoc='" & FrmEgresoNomina.txtdoc.Text & "' " _
                & "AND (debito=" & DIN(lbvalor.Text) & " OR credito=" & DIN(lbvalor.Text) & ") " _
                & "AND codigo='" & gitems.Item("cta", 0).Value & "';"
                myCommand.ExecuteNonQuery()
                '++++++++++++++++++++++++++++++++++++++++++++++++ 
                Dim per As String = FrmEgresoNomina.cbper.Text.ToString & "/" & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
                For i = 0 To gitems.RowCount - 1
                    Try
                        GuardarContable(i, FrmEgresoNomina.txtdia.Text.ToString, per)
                    Catch ex As Exception

                    End Try
                Next
                MsgBox("Datos guardados correctamente", MsgBoxStyle.Information, "SAE Guardar Datos")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Cerrar()
        End If
    End Sub
    Public Sub GuardarContable(ByVal fila As Integer, ByVal dia As String, ByVal per As String)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", 400 - fila)
        myCommand.Parameters.AddWithValue("?doc", Val(FrmEgresoNomina.txtnumero.Text.ToString))
        myCommand.Parameters.AddWithValue("?tipodoc", FrmEgresoNomina.txtdoc.Text.ToString)
        myCommand.Parameters.AddWithValue("?periodo", per)
        myCommand.Parameters.AddWithValue("?dia", dia)
        myCommand.Parameters.AddWithValue("?ccosto", "0")
        myCommand.Parameters.AddWithValue("?descri", CambiaCadena(gitems.Item("tercero", fila).Value, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(gitems.Item("cr", fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(gitems.Item("db", fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", gitems.Item("cta", fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", "0")
        myCommand.Parameters.AddWithValue("?diasv", "0")
        myCommand.Parameters.AddWithValue("?fechaven", dia & "/" & FrmEgresoNomina.cbper.Text.ToString)
        myCommand.Parameters.AddWithValue("?nit", gitems.Item("nit", fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?cheque", "")
        myCommand.Parameters.AddWithValue("?modulo", "contabilidad")
        '************* GUARDAR CONSULTA *********************************************
        myCommand.CommandText = "INSERT INTO documentos" & FrmEgresoNomina.cbper.Text.ToString & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?ccosto,?descri,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
End Class