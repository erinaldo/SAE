Imports System.Drawing.Printing
Public Class frmImpcodBarras
    Dim contenido As PrintPageEventArgs
    Private Sub frmImpcodBarras_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cbini.Text = PerActual(0) & PerActual(1)
        With gtDatos
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub

    Sub cargarDatos()
        Dim items As Integer
        Dim tabla As New DataTable

        Dim sql As String = ""
        sql = "SELECT ar.codart, ar.nomart, ar.desart, FORMAT(ar.precio,0) AS precio, dt.cant1 " _
             & "FROM articulos AS ar INNER JOIN con_inv  AS dt ON  ar.codart  = dt.codart " _
             & "WHERE ar.codart LIKE '" & txtmarca.Text & "%'  AND dt.periodo='" & cbini.Text & "' AND ar.nivel='Articulo';"
        myCommand.CommandText = Sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)

        items = tabla.Rows.Count
        If items = 0 Then
            'MsgBox("No han seleccionado ninguna cuenta del PUC, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Exit Sub
        End If
        gtDatos.RowCount = items
        For i = 0 To items - 1
            gtDatos.Item(0, i).Value = tabla.Rows(i).Item("codart")
            gtDatos.Item(1, i).Value = tabla.Rows(i).Item("nomart")
            gtDatos.Item(2, i).Value = CambiaCadena(tabla.Rows(i).Item("desart"), 12)
            gtDatos.Item(3, i).Value = tabla.Rows(i).Item("precio")
            gtDatos.Item(4, i).Value = tabla.Rows(i).Item("cant1")
        Next
        CalcularTotal()
    End Sub

    Private Sub txtmarca_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtmarca.TextChanged
        If txtmarca.Text.Length >= 2 Then
            cargarDatos()
        End If
        If txtmarca.Text = "" Then
            gtDatos.Rows.Clear()
        End If

    End Sub

    Private Sub Documento_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Documento.PrintPage
        Dim band As Integer = 0
        Dim salto As Integer = 0
        Dim salto2 As Integer = 0
        Dim salto3 As Integer = 0
        Dim nsalto As Integer = 15
        Dim linea As Integer = 0
        Dim k As Integer = 10
        Dim c As Integer = 0

        'MsgBox(t)
        'contenido.HasMorePages = True
        salto = k
        salto2 = 40 + k
        salto3 = 55 + k
        For i As Integer = 0 To gtDatos.RowCount - 1
            Try
                c = Val(gtDatos.Item(4, i).Value)
            Catch ex As Exception
                c = 0
            End Try

            If c > 0 Then

                For j = 1 To c

                    '********************************
                    contenido = e
                    band = band + 1
                    If band = 1 Then
                        contenido.Graphics.DrawString("*" & gtDatos.Item(0, i).Value & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 8, salto)
                        contenido.Graphics.DrawString(gtDatos.Item(2, i).Value, New Font("Arial", 8), Brushes.Black, 10, salto2)
                        contenido.Graphics.DrawString("Precio: $" & gtDatos.Item(3, i).Value, New Font("Arial", 8), Brushes.Black, 12, salto3)
                    ElseIf band = 2 Then
                        contenido.Graphics.DrawString("*" & gtDatos.Item(0, i).Value.ToString & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 143, salto)
                        contenido.Graphics.DrawString(gtDatos.Item(2, i).Value.ToString, New Font("Arial", 8), Brushes.Black, 145, salto2)
                        contenido.Graphics.DrawString("Precio: $" & gtDatos.Item(3, i).Value, New Font("Arial", 8), Brushes.Black, 145, salto3)
                    Else
                        contenido.Graphics.DrawString("*" & gtDatos.Item(0, i).Value.ToString & "*", New Font("c39hrp24dhtt", 20), Brushes.Black, 277, salto)
                        contenido.Graphics.DrawString(gtDatos.Item(2, i).Value.ToString, New Font("Arial", 8), Brushes.Black, 279, salto2)
                        contenido.Graphics.DrawString("Precio: $" & gtDatos.Item(3, i).Value, New Font("Arial", 8), Brushes.Black, 279, salto3)
                        band = 0
                        k = k + 100
                        linea = linea + 1
                        'If linea >= 3 Then
                        salto = k
                        salto2 = 40 + k
                        salto3 = 55 + k
                        If linea = 1 Then
                            salto = salto + 10
                            salto2 = salto2 + 10
                            salto3 = salto3 + 10

                        ElseIf linea > 1 And linea <= 11 Then
                            nsalto = nsalto + (6.5 * 1.3)
                            salto = salto + nsalto
                            salto2 = salto2 + nsalto
                            salto3 = salto3 + nsalto
                        ElseIf linea >= 12 And linea <= 22 Then
                            nsalto = nsalto + (7.5 * 1.3)
                            salto = salto + nsalto
                            salto2 = salto2 + nsalto
                            salto3 = salto3 + nsalto
                        Else
                            nsalto = nsalto + (8.5 * 1.3)
                            salto = salto + nsalto
                            salto2 = salto2 + nsalto
                            salto3 = salto3 + nsalto
                        End If

                        'End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub btnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVista.Click
        vista.Document = Documento
        Configurar()
        vista.ShowDialog()
    End Sub

    Private Sub Configurar()
        impresora.Document = Documento
        impresora.ShowDialog()
        Dim tamaño As Printing.PaperSize
        Dim cant As Integer = 0
        Dim cant2 As Double = 0
        Dim tam As Integer = 0
        Try
            cant = Val(lbcant.Text)
        Catch ex As Exception
            cant = 1
        End Try
        'MsgBox(cant Mod (3))
        If cant Mod (3) = 0 Then
            cant = (cant / 3)
            'cant = cant * 100
        Else
            cant2 = cant / 3
            cant = cant / 3
            cant2 = cant2 - cant
            If cant2 > 0 Then
                cant = cant + 1
            End If
            'cant = cant + 1
        End If
       
        cant = cant * 100
        If cant >= 300 Then
            cant = cant + (cant * 0.1)
        End If

        tamaño = New Printing.PaperSize("personal", 1000.8, cant)
        Documento.PrinterSettings = impresora.PrinterSettings
        Documento.DefaultPageSettings.PaperSize = tamaño
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Configurar()
        Documento.Print()
    End Sub
    Public Sub CalcularTotal()
        Dim can As Integer = 0
        Dim c As Integer = 0
        For i = 0 To gtDatos.RowCount - 1
            Try
                c = Val(Trim(gtDatos.Item("Cantidad", i).Value.ToString))
            Catch ex As Exception
                c = 0
            End Try
            can = can + c
        Next
        lbcant.Text = can
    End Sub

    Private Sub gtDatos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gtDatos.CellEndEdit
        Try
            gtDatos.Item("Cantidad", e.RowIndex).Value = Val(gtDatos.Item("Cantidad", e.RowIndex).Value)
        Catch ex As Exception
            gtDatos.Item("Cantidad", e.RowIndex).Value = "1"
        End Try
        CalcularTotal()
    End Sub

    
End Class