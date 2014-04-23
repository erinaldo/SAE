Imports System.IO
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmOtrosDocumentos

    Private Sub FrmOtrosDocumentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub FrmOtrosDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrearTablaOT_DOC()
        MiConexion(bda)
        Update_OT_DOC()
        Cerrar()
    End Sub
    Public Sub Update_OT_DOC()
        Dim per As String = ""
        For i = 1 To 12
            Try
                If i < 10 Then
                    per = "0" & i
                Else
                    per = i
                End If
                myCommand.CommandText = "ALTER TABLE ot_doc" & per & " ADD `doc_aj` VARCHAR( 30 ) NOT NULL;"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub cmdsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdegresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdegresos.Click
        If HayParametros() = True Then
            FrmComEgresoCpp.lbcontr.Text = ""
            FrmComEgresoCpp.Chcredito.Visible = False
            FrmComEgresoCpp.ShowDialog()
        End If

    End Sub

    Private Sub cmdingresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdingresos.Click
        If HayParametros() = True Then
            FrmCompIngresos.Chcredito.Visible = False
            FrmCompIngresos.ShowDialog()
        End If

    End Sub

    Private Sub cmdcaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcaja.Click
        If HayParametros() = True Then FrmRecibodeCaja.ShowDialog()
    End Sub

    Private Sub cmdndebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdndebito.Click
        If HayParametros() = True Then FrmNotaDebito.ShowDialog()
    End Sub

    Private Sub cmdncredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdncredito.Click
        If HayParametros() = True Then FrmNotaCredito.ShowDialog()
    End Sub
    Private Sub cmdcd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcd.Click
        If HayParametros() = True Then FrmCompDiario.ShowDialog()
    End Sub

    Private Sub cmdpara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdpara.Click
        If bas_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
        FrmParametrosOtrosDoc.ShowDialog()
    End Sub

    Function HayParametros()
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT count(*) FROM parotdoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item(0) < 1 Then
                MsgBox("No ha ingresado parametros para la interfaz.   ", MsgBoxStyle.Information, "SAE Control")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
            Return False
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MiConexion(bda)
        Cerrar()
        FrmImprDocContab.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        MiConexion(bda)
        Cerrar()
        FrmImprDocContab.ShowDialog()
    End Sub

End Class