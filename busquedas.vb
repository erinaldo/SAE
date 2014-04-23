Imports System.IO
Module busquedas
    Public PerActual As String
    Public bda As String
    '**************************************
    Public per_ter As String = ""
    Public per_tdoc As String = ""
    Public per_imp As String = ""
    '**************************************
    Public bas_con As String = ""
    Public tra_con As String = ""
    Public inf_con As String = ""
    Public pro_con As String = ""
    '**************************************
    Public bas_inv As String = ""
    Public tra_inv As String = ""
    Public inf_inv As String = ""
    Public pro_inv As String = ""
    '**************************************
    Public bas_fac As String = ""
    Public tra_fac As String = ""
    Public inf_fac As String = ""
    Public pro_fac As String = ""
    '**************************************
    Public bas_car As String = ""
    Public tra_car As String = ""
    Public inf_car As String = ""
    Public pro_car As String = ""
    '**************************************
    Public bas_pro As String = ""
    Public tra_pro As String = ""
    Public inf_pro As String = ""
    Public pro_pro As String = ""

    Public Sub MostrarCompaniaParaAbrir()

        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias ORDER BY codigo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <= 0 Then
            MsgBox("No hay compañias creadas, verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        FrmAbrirCompania.gitems.RowCount = tabla.Rows.Count
        For i = 0 To tabla.Rows.Count - 1
            If UCase(tabla.Rows(i).Item("login")) = UCase(CompaniaActual) Then
                FrmAbrirCompania.txtlogin.Text = UCase(CompaniaActual)
                FrmAbrirCompania.txtcompania.Text = tabla.Rows(i).Item("descripcion")
                FrmAbrirCompania.txtnit.Text = tabla.Rows(i).Item("nit")
                BuscarPeriodo()
                FrmAbrirCompania.txtperiodo.Text = PerActual
            End If
            FrmAbrirCompania.gitems.Item(0, i).Value = tabla.Rows(i).Item("login")
            FrmAbrirCompania.gitems.Item(1, i).Value = UCase(tabla.Rows(i).Item("descripcion"))
            FrmAbrirCompania.gitems.Item(2, i).Value = tabla.Rows(i).Item("nit")
        Next
    End Sub
    Function LlenarPeriodo() As String
        Dim Archivo As String
        Try
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & "\" & Trim(FrmPrincipal.lbcompania.Text) & ".txt"
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
                Return Archivo
            Else
                Return "+++"
            End If
        Catch ex As Exception
            Return "+++"
        End Try
    End Function
    Public Sub BuscarPeriodo()
        '*********************************
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        '******************************************
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT codigo FROM sae.companias WHERE login='" & Trim(UCase(CompaniaActual)) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <= 0 Then
            MsgBox("El período no se pudo abrir porque la compañia no existe, verifique. ", MsgBoxStyle.Information, "Guardar Datos")
            PerActual = "(ninguno)"
            Exit Sub
        End If
        '******** EXISTE LA COMPAÑIA****************************
        Dim p As String = LlenarPeriodo()
        If p = "+++" Then
            myCommand.CommandText = "SELECT * from sae.periodos where codigo='" & tabla2.Rows(0).Item("codigo") & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No hay periodos usados, Verifique.  ", MsgBoxStyle.Information, "Buscar Periodos")
                PerActual = "(ninguno)"
            Else
                PerActual = tabla.Rows(0).Item(0)
            End If
            FrmPrincipal.LbPeriodo.Text = PerActual
            '************CREAR ARCHIVO*********************
            Try
                Dim swEscritor As StreamWriter
                swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\" & Trim(FrmPrincipal.lbcompania.Text) & ".txt", False)
                swEscritor.Write(Trim(PerActual))
                swEscritor.Close()
            Catch ex As Exception
            End Try
        Else
            PerActual = p
            FrmPrincipal.LbPeriodo.Text = PerActual
        End If
        ''''''''''''' LLENAR DATOS ''''''''''''''''''''''''''''''''''
        bda = "sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Try
            FrmPeriodo.ano.Text = PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub AbrirPeriodo(ByVal periodo As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Se va abrir un período diferente, ¿Desea Abrirlo?", MsgBoxStyle.YesNo, "Verificando")
        If resultado = MsgBoxResult.No Then Exit Sub
        ''/////////////////////////////////////////////////////////////////
        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT codigo from sae.companias where login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <= 0 Then
            MsgBox("El período no se pudo abrir porque la compañia no existe, verifique. ", MsgBoxStyle.Information, "Guardar Datos")
            Exit Sub
        End If
        myCommand.CommandText = "SELECT * from sae.periodos where codigo='" & tabla2.Rows(0).Item("codigo") & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        items = tabla.Rows.Count
        PerActual = periodo
        MiConexion("sae")
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?periodo", periodo)
        If items > 0 Then
            myCommand.CommandText = "Update sae.periodos set activo='SI',periodo=?periodo WHERE codigo='" & tabla.Rows(0).Item("codigo") & "';"
        Else
            myCommand.CommandText = "INSERT INTO sae.periodos Values(?periodo, '00','SI','" & tabla2.Rows(0).Item("codigo") & "');"
        End If
        myCommand.ExecuteNonQuery()
        Try
            Dim swEscritor As StreamWriter
            swEscritor = New StreamWriter(My.Application.Info.DirectoryPath & "\" & Trim(FrmPrincipal.lbcompania.Text) & ".txt", False)
            swEscritor.Write(Trim(PerActual))
            swEscritor.Close()
        Catch ex As Exception
        End Try
        '////////////////////////
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Guar_MovUser("PRINCIPAL", "ABRIR PERIODO " & periodo, "", "", "")
        End If
        MsgBox("El período se abrio correctamente. ", MsgBoxStyle.Information, "Guardar Datos")
        myCommand.Parameters.Clear()
        DBCon.Close()
        BuscarPeriodo()
        MiConexion("sae" & CompaniaActual & PerActual(3) & PerActual(4) & PerActual(5) & PerActual(6))
        Cerrar()
    End Sub
End Module
