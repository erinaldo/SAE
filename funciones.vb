Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Mail

Module funciones
    Dim con As New MySqlConnection()
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public DBCon As MySqlConnection
    Dim conexion As New MySqlConnection
    Public bConexionExitosa As Boolean = True
    Public ct As Integer
    Public Sub MiConexion(ByVal bd As String)
        Try
            DBCon = New MySql.Data.MySqlClient.MySqlConnection
            DBCon.ConnectionString = datoscon(bd) & "Allow User Variables=True;"
            'Abrimos la conexión y comprobamos que no hay error
            bConexionExitosa = True
            DBCon.Open()
            myCommand.Connection = DBCon
        Catch ex As MySqlException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            Try
                MsgBox("No Hay Conexión establecida, Error: " & ex.Message.ToString, MsgBoxStyle.Critical, "SAE Conexión")
                If Trim(bd) = "sae" Then
                    bConexionExitosa = False
                    FrmConexion.ShowDialog()
                    If bConexionExitosa = True Then
                        MiConexion(bd)
                    End If
                End If
            Catch ex2 As Exception
            End Try
        End Try
    End Sub
    Public Sub Cerrar()
        DBCon.Close()
    End Sub
    Public Sub MiConexion2()
        Dim cadena As String
        Try
            cadena = datoscon(bda) & "Allow Zero Datetime=True;Convert Zero Datetime=True;User Variables=True;Persist Security Info=True;"
            'MsgBox(cadena)
            conexion.ConnectionString = cadena
            conexion.Open()
            myCommand.Connection = conexion
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString, MsgBoxStyle.Critical, "SAE Conexion")
        End Try
    End Sub
    Public Sub Cerrar2()
        conexion.Close()
    End Sub
    Function datoscon(ByVal bd As String)
        Try
            Dim cnx, ip, bduser, bdpass, bdpuerto As String
            Dim j As Integer
            j = 0
            ip = ""
            bduser = ""
            bdpass = ""
            bdpuerto = ""
            cnx = LlenarVector()
            For i = 0 To cnx.Length - 1
                If cnx(i) <> ";" Then
                    If j = 0 Then
                        ip = ip & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 1 Then
                        bduser = bduser & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 2 Then
                        bdpass = bdpass & (Chr(Val(Asc(cnx(i)))))
                    Else
                        bdpuerto = bdpuerto & (Chr(Val(Asc(cnx(i)))))
                    End If
                Else
                    j = j + 1
                End If
            Next
            ' MsgBox("server=" & ip & ";user=" & bduser & "; password=" & bdpass & "; database=" & bd & ";port=" & bdpuerto & ";")
            Return "server=" & ip & ";user=" & bduser & "; password=" & bdpass & "; database=" & bd & ";port=" & bdpuerto & ";"
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return ""
        End Try
    End Function
    Function LlenarVector() As String
        Dim Archivo As String
        Try
            Dim rutaconex As String
            rutaconex = My.Application.Info.DirectoryPath & "\cnx.txt"
            If My.Computer.FileSystem.FileExists(rutaconex) Then
                Archivo = My.Computer.FileSystem.ReadAllText(rutaconex)
                Return Archivo
            Else
                MsgBox("Error #3225 no se puede ingresar al sistema, Verifique con el Administrador", MsgBoxStyle.Critical, "Verificando")
                End
            End If
        Catch ex As Exception
            MsgBox("Error #3225 " & ex.Message.ToString, MsgBoxStyle.Critical)
            End
        End Try
    End Function
    Function datoscon2(ByVal bd As String)
        Try
            Dim cnx, ip, bduser, bdpass, bdpuerto As String
            Dim j As Integer
            j = 0
            ip = ""
            bduser = ""
            bdpass = ""
            bdpuerto = ""
            cnx = LlenarVector()
            For i = 0 To cnx.Length - 1
                If cnx(i) <> ";" Then
                    If j = 0 Then
                        ip = ip & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 1 Then
                        bduser = bduser & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 2 Then
                        bdpass = bdpass & (Chr(Val(Asc(cnx(i)))))
                    Else
                        bdpuerto = bdpuerto & (Chr(Val(Asc(cnx(i)))))
                    End If
                Else
                    j = j + 1
                End If
            Next
            Return "--user=" & bduser & " --password=" & bdpass & " "
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return ""
        End Try
    End Function
    Function datoscon3(ByVal bd As String)
        Try
            Dim cnx, ip, bduser, bdpass, bdpuerto As String
            Dim j As Integer
            j = 0
            ip = ""
            bduser = ""
            bdpass = ""
            bdpuerto = ""
            cnx = LlenarVector()
            For i = 0 To cnx.Length - 1
                If cnx(i) <> ";" Then
                    If j = 0 Then
                        ip = ip & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 1 Then
                        bduser = bduser & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 2 Then
                        bdpass = bdpass & (Chr(Val(Asc(cnx(i)))))
                    Else
                        bdpuerto = bdpuerto & (Chr(Val(Asc(cnx(i)))))
                    End If
                Else
                    j = j + 1
                End If
            Next
            'Return " -u " & bduser & " -p" & bdpass & " " & bd & " < "
            Return "mysql -u" & bduser & " -p" & bdpass & " " & bd & " < "
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return ""
        End Try
    End Function

    Function datosconR(ByVal bd As String)
        Try
            Dim cnx, ip, bduser, bdpass, bdpuerto As String
            Dim j As Integer
            j = 0
            ip = ""
            bduser = ""
            bdpass = ""
            bdpuerto = ""
            cnx = LlenarVector()
            For i = 0 To cnx.Length - 1
                If cnx(i) <> ";" Then
                    If j = 0 Then
                        ip = ip & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 1 Then
                        bduser = bduser & (Chr(Val(Asc(cnx(i)))))
                    ElseIf j = 2 Then
                        bdpass = bdpass & (Chr(Val(Asc(cnx(i)))))
                    Else
                        bdpuerto = bdpuerto & (Chr(Val(Asc(cnx(i)))))
                    End If
                Else
                    j = j + 1
                End If
            Next
            Return "server=" & ip & ";user=" & bduser & "; password=" & bdpass & "; database=" & bd & ";port=" & bdpuerto & ";Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True;"
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return ""
        End Try
    End Function
    '//////////////////////////////////////////////////
    Public Sub LimpiarTerceros()
        frmterceros.txtapellido.Text = ""
        frmterceros.txtnombre.Text = ""
        frmterceros.txtdir.Text = ""
        frmterceros.txttel.Text = ""
        frmterceros.txtcel.Text = ""
        frmterceros.txtfax.Text = ""
        frmterceros.txtcorreo.Text = ""
        frmterceros.txtweb.Text = ""
        frmterceros.rbnatural.Checked = True
        frmterceros.lbestado.Text = "NUEVO"
    End Sub
    Public Function DigitoNIT(ByVal sNit As String) As String
        On Error Resume Next
        '<-- Devuelve el Digito de verificación del NIT.
        Dim sTMP, sTmp1, sTMP2 As String
        Dim i As Integer
        Dim iResiduo As Integer
        Dim iChequeo As Integer
        Dim iPrimos(15) As Integer '<- Defino el Arreglo de los Primos.
        iPrimos(1) = 3 : iPrimos(2) = 7 : iPrimos(3) = 13 : iPrimos(4) = 17 : iPrimos(5) = 19
        iPrimos(6) = 23 : iPrimos(7) = 29 : iPrimos(8) = 37 : iPrimos(9) = 41 : iPrimos(10) = 43
        iPrimos(11) = 47 : iPrimos(12) = 53 : iPrimos(13) = 59 : iPrimos(14) = 67 : iPrimos(15) = 71
        iChequeo = 0 : iResiduo = 0
        For i = 0 To Len(Trim(sNit)) - 1
            sTMP = Mid(sNit, Len(Trim(sNit)) - i, 1)
            iChequeo = iChequeo + (Val(sTMP) * iPrimos(i + 1))
            'MsgBox Val(sTmp), vbCritical, iPrimos(i + 1)
        Next i
        iResiduo = iChequeo Mod 11
        If iResiduo <= 1 Then
            If iResiduo = 0 Then DigitoNIT = 0
            If iResiduo = 1 Then DigitoNIT = 1
        Else
            DigitoNIT = 11 - iResiduo
        End If
    End Function
    Function Fraccion(ByVal monto As String)

        Try
            If FrmPrincipal.txtcant.Text <> "" Then
                Dim rs As Double = 0
                Dim ct As String = ""
                Dim cp() As String

                ct = monto
                cp = ct.Split("/")

                If cp.Length <= 1 Then
                    monto = Format(CDbl(monto), "0.0000")
                Else
                    monto = DIN(cp(0)) / DIN(cp(1))
                    monto = Format(CDbl(monto), "0.0000")
                End If
            Else
                monto = Moneda(monto)
            End If

            Return monto
        Catch ex As Exception

        End Try
        
    End Function
    Function Moneda(ByVal monto As String)
        Try
            If CDbl(monto) = 0 Then
                monto = "0,00"
            ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                monto = Format(Math.Round(CDbl(monto), 2), "0.00")
            Else
                monto = Format(Math.Round(CDbl(monto), 2), "0,00.00")
            End If
            Return monto
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function
    Function Moneda2(ByVal monto As String, ByVal lb_imp_dec As String)
        If lb_imp_dec = "S" Then
            Try
                If CDbl(monto) = 0 Then
                    monto = "0,00"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 2), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 2), "0,00.00")
                End If
                Return monto
            Catch ex As Exception
                Return "0,00"
            End Try
        Else
            Try
                If CDbl(monto) = 0 Then
                    monto = "0"
                ElseIf CDbl(monto) > -100 And CDbl(monto) < 100 Then
                    monto = Format(Math.Round(CDbl(monto), 0), "0.00")
                Else
                    monto = Format(Math.Round(CDbl(monto), 0), "0,00")
                End If
                Return monto
            Catch ex As Exception
                Return "0"
            End Try
        End If
    End Function
    Function Decimales(ByVal monto As String)
        Try
            If CDbl(monto) = 0 Then
                monto = "0,00"
            Else
                monto = Format(Math.Round(CDec(monto), 2), "0.00")
            End If
            Return monto
        Catch ex As Exception
            Return "0,00"
        End Try
    End Function
    Public Sub ValidarNIT(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "0" To "9", Chr(8), Chr(13)
                txt.ForeColor = Color.Black
            Case Else
                txt.ForeColor = Color.Black
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub validarletra(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "A" To "Z", "a" To "z", Chr(8), Chr(13), _
                      "á" To "ú", "Á" To "Ú", "ñ", "Ñ", " ", _
                      "à" To "ù", "À" To "Ú", _
                      "ü", "Ä" To "Ü", "'", "!", "¡", "¿", "?", """"
                txt.ForeColor = Color.Black
            Case Else
                'txt.ForeColor = Color.Red
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub validarnumero(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "0" To "9", Chr(8), Chr(13)
                txt.ForeColor = Color.Black
            Case Else
                'txt.ForeColor = Color.Red
                Beep()
                e.Handled = True
        End Select
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub ValidarMoneda(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                txt.Text = Format(Math.Round(CDbl(txt.Text), 2), "0,00.00")
                If CDbl(txt.Text) = 0 Then
                    txt.Text = "0,00"
                End If
                SendKeys.Send("{TAB}")
            Else
                Select Case e.KeyChar
                    Case "0" To "9", Chr(8), Chr(13), ".", ","
                    Case Else
                        Beep()
                        e.Handled = True
                End Select
            End If
        Catch ex As Exception
            If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
        End Try
    End Sub
    Public Sub ValidarPorcentaje(ByVal txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                txt.Text = Format(Math.Round(CDbl(txt.Text), 2), "0.00")
                If CDbl(txt.Text) = 0 Then
                    txt.Text = "0,00"
                End If
                SendKeys.Send("{TAB}")
            Else
                Select Case e.KeyChar
                    Case "0" To "9", Chr(8), Chr(13), ","
                    Case Else
                        Beep()
                        e.Handled = True
                End Select
            End If
        Catch ex As Exception
            If e.KeyChar = Chr(Keys.Enter) Then SendKeys.Send("{TAB}")
        End Try
    End Sub
    Public cc As String
    Public Sub NivelesDeCuentas()
        cc = ""
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM parcontab LIMIT 0, 1;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        If tabla.Rows.Count <> 0 Then
            FrmParContable.txtlongitudcod.Text = tabla.Rows(0).Item("longitud")
            FrmParContable.txtnivcue.Text = tabla.Rows(0).Item("niveles")
            FrmParContable.txtniv1.Text = tabla.Rows(0).Item("nivel1")
            FrmParContable.txtniv2.Text = tabla.Rows(0).Item("nivel2")
            FrmParContable.txtniv3.Text = tabla.Rows(0).Item("nivel3")
            FrmParContable.txtniv4.Text = tabla.Rows(0).Item("nivel4")
            FrmParContable.txtniv5.Text = tabla.Rows(0).Item("nivel5")
            If tabla.Rows(0).Item("ccosto").ToString = "S" Then
                FrmParContable.rb_si.Checked = True
                FrmParContable.gncc.Enabled = True
                cc = "S"
            Else
                FrmParContable.rb_no.Checked = True
                FrmParContable.gncc.Enabled = False
                cc = "N"
            End If
            If FrmParContable.rb_si.Checked = True Then
                FrmParContable.BuscNivelesCC()
            End If
        End If
    End Sub
    '******* PASAR MONTOS($) A LETRAS *****************
    Public Function Num2Text(ByVal value As String) As String
        Num2Text = ""
        Dim cad As String = ""
        Dim cent As String = ""
        value = Moneda(value)
        For i = 0 To value.Length - 1
            If i = (value.Length - 2) Or i = (value.Length - 1) Then
                cent = cent & value(i) 'decimales 
            ElseIf i < (value.Length - 3) Then
                cad = cad & value(i) ' parte entera
            End If
        Next
        Dim v As Double
        Try
            v = CDbl(cad)
        Catch ex As Exception
            v = 0
        End Try
        Try
            Num2Text = Trim(P_Entera(v))
        Catch ex As Exception

        End Try

        If v >= 1000000 Then ' SON MILLONES DE PESOS
            cad = ""
            Dim aux As String = Num2Text
            For i = (aux.Length - 5) To aux.Length - 1
                cad = cad & aux(i)
            Next
            If cad = "ILLON" Or cad = "LONES" Then 'MI-BI-TRILLONES DE PESOS
                Num2Text = Num2Text & " DE PESOS"
            Else
                Num2Text = Num2Text & " PESOS"
            End If
        Else ' SON PESOS O MILES  
            Num2Text = Num2Text & " PESOS"
        End If
        Try
            v = Val(cent)
        Catch ex As Exception
            v = 0
        End Try
        If v > 0 Then
            Num2Text = Num2Text & " CON " & P_decimal(v) & " CENTAVOS"
        End If
    End Function
    Public Function P_Entera(ByVal value As Double) As String
        Try
            Try
                If value.ToString < "0.0" Then value = 0
            Catch ex As Exception
                Exit Function
            End Try

            Select Case value
                Case 0 : P_Entera = "CERO"
                Case 1 : P_Entera = "UN"
                Case 2 : P_Entera = "DOS"
                Case 3 : P_Entera = "TRES"
                Case 4 : P_Entera = "CUATRO"
                Case 5 : P_Entera = "CINCO"
                Case 6 : P_Entera = "SEIS"
                Case 7 : P_Entera = "SIETE"
                Case 8 : P_Entera = "OCHO"
                Case 9 : P_Entera = "NUEVE"
                Case 10 : P_Entera = "DIEZ"
                Case 11 : P_Entera = "ONCE"
                Case 12 : P_Entera = "DOCE"
                Case 13 : P_Entera = "TRECE"
                Case 14 : P_Entera = "CATORCE"
                Case 15 : P_Entera = "QUINCE"
                Case Is < 20 : P_Entera = "DIECI" & P_Entera(value - 10)
                Case 20 : P_Entera = "VEINTE"
                Case Is < 30 : P_Entera = "VEINTI" & P_Entera(value - 20)
                Case 30 : P_Entera = "TREINTA"
                Case 40 : P_Entera = "CUARENTA"
                Case 50 : P_Entera = "CINCUENTA"
                Case 60 : P_Entera = "SESENTA"
                Case 70 : P_Entera = "SETENTA"
                Case 80 : P_Entera = "OCHENTA"
                Case 90 : P_Entera = "NOVENTA"
                Case Is < 100 : P_Entera = P_Entera(Int(value \ 10) * 10) & " Y " & P_Entera(value Mod 10)
                Case 100 : P_Entera = "CIEN"
                Case Is < 200 : P_Entera = "CIENTO " & P_Entera((value - 100))
                Case 200, 300, 400, 600, 800 : P_Entera = P_Entera(Int(value \ 100)) & "CIENTOS"
                Case 500 : P_Entera = "QUINIENTOS"
                Case 700 : P_Entera = "SETECIENTOS"
                Case 900 : P_Entera = "NOVECIENTOS"
                Case Is < 1000 : P_Entera = P_Entera(Int(value \ 100) * 100) & " " & P_Entera(value Mod 100)
                Case 1000 : P_Entera = "MIL"
                Case Is < 2000 : P_Entera = "MIL " & P_Entera(value Mod 1000)
                Case Is < 1000000 : P_Entera = P_Entera(Int(value \ 1000)) & " MIL"
                    If value Mod 1000 Then P_Entera = P_Entera & " " & P_Entera(value Mod 1000)
                Case 1000000 : P_Entera = "UN MILLON"
                Case Is < 2000000 : P_Entera = "UN MILLON " & P_Entera(value Mod 1000000)
                Case Is < 1000000000000.0# : P_Entera = P_Entera(Int(value / 1000000)) & " MILLONES "
                    If (value - Int(value / 1000000) * 1000000) Then P_Entera = P_Entera & " " & P_Entera(value - Int(value / 1000000) * 1000000)
                Case 1000000000000.0# : P_Entera = "UN BILLON"
                Case Is < 2000000000000.0# : P_Entera = "UN BILLON " & P_Entera(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
                Case Else : P_Entera = P_Entera(Int(value / 1000000000000.0#)) & " BILLONES"
                    If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then P_Entera = P_Entera & " " & P_Entera(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            End Select
        Catch ex As Exception

        End Try
    End Function
    Public Function P_decimal(ByVal value As Double) As String
        Select Case value
            Case 0 : P_decimal = "CERO"
            Case 1 : P_decimal = "UN"
            Case 2 : P_decimal = "DOS"
            Case 3 : P_decimal = "TRES"
            Case 4 : P_decimal = "CUATRO"
            Case 5 : P_decimal = "CINCO"
            Case 6 : P_decimal = "SEIS"
            Case 7 : P_decimal = "SIETE"
            Case 8 : P_decimal = "OCHO"
            Case 9 : P_decimal = "NUEVE"
            Case 10 : P_decimal = "DIEZ"
            Case 11 : P_decimal = "ONCE"
            Case 12 : P_decimal = "DOCE"
            Case 13 : P_decimal = "TRECE"
            Case 14 : P_decimal = "CATORCE"
            Case 15 : P_decimal = "QUINCE"
            Case Is < 20 : P_decimal = "DIECI" & P_decimal(value - 10)
            Case 20 : P_decimal = "VEINTE"
            Case Is < 30 : P_decimal = "VEINTI" & P_decimal(value - 20)
            Case 30 : P_decimal = "TREINTA"
            Case 40 : P_decimal = "CUARENTA"
            Case 50 : P_decimal = "CINCUENTA"
            Case 60 : P_decimal = "SESENTA"
            Case 70 : P_decimal = "SETENTA"
            Case 80 : P_decimal = "OCHENTA"
            Case 90 : P_decimal = "NOVENTA"
            Case Is < 100 : P_decimal = P_decimal(Int(value \ 10) * 10) & " Y " & P_decimal(value Mod 10)
            Case Else : P_decimal = ""
        End Select
    End Function
    '************************************
    Public Function NumeroDoc(ByVal num As Integer)
        Dim cad As String
        If num < 10 Then
            cad = "0000" & num
        ElseIf num < 100 Then
            cad = "000" & num
        ElseIf num + 1 < 1000 Then
            cad = "00" & num
        ElseIf num + 1 < 10000 Then
            cad = "0" & num
        Else
            cad = num
        End If
        Return cad
    End Function
    Public Function SaltarCadena(ByVal cadena As String, ByVal tam As Integer)
        'Dim cad As String
        'Try
        '    If cadena.Length > tam Then
        '        cad = ""
        '        For j = 0 To tam - 1
        '            cad = cad & cadena(j)
        '            If cad.Length > tam Then
        '                cad = cad & vbCrLf
        '            End If
        '        Next
        '        cad = cad & vbCrLf
        '        For i = tam - 1 To cadena.Length - 1
        '            cad = cad & cadena(i)
        '        Next
        '    Else
        '        cad = cadena
        '    End If
        '    Return cad
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    Return cadena
        'End Try

        Dim cad As String
        Dim t As Integer = 0
        Try
            If cadena.Length > tam Then
                cad = ""
                For j = 0 To cadena.Length - 1
                    cad = cad & cadena(j)
                    t = t + 1
                    If t >= tam Then
                        t = 0
                        cad = cad & vbCrLf
                    End If
                Next
                'cad = cad & vbCrLf
            Else
                cad = cadena
            End If
            Return cad
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return cadena
        End Try
    End Function
    Public Function CambiaCadena(ByVal cadena As String, ByVal tam As Integer)
        Dim cad As String
        Try
            If cadena.Length > tam Then
                cad = ""
                For j = 0 To tam - 1
                    cad = cad & cadena(j)
                Next
            Else
                cad = cadena
            End If
            Return cad
        Catch ex As Exception
            Return cadena
        End Try
    End Function
    Public Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            If Not Imagen Is Nothing Then
                Dim Bin As New MemoryStream(Imagen)
                Dim Resultado As Image = Image.FromStream(Bin)
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function BuscarCentroCostos(ByVal centro As String)
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro=" & Val(centro) & ";"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows.Count > 0 Then
                Return t.Rows(0).Item("nombre")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Function DIN(ByVal monto As String) 'Double para INSERT
        Dim m As Double
        'Dim vt() As String

        'vt = monto.Split(",")

        'Try

        '    If vt(1).Length <> 4 Then
        '        Try
        '            m = CDbl(Moneda(monto))
        '        Catch et As Exception
        '            m = 0
        '        End Try
        '    Else
        '        Try
        '            m = monto
        '        Catch et As Exception
        '            m = 0
        '        End Try
        '    End If

        'Catch ex As Exception
        Try
            m = CDbl(monto)
        Catch et As Exception
            m = 0
        End Try
        'End Try

        'If cp(1).Length = 4 Then

        '    monto = Moneda(monto)
        'Else
        '    monto = DIN(cp(0)) / DIN(cp(1))
        'End If


        'Try
        '    m = CDbl(Moneda(monto))
        'Catch ex As Exception
        '    m = 0
        'End Try
        Return m.ToString.Replace(",", ".")
    End Function
    '************ACTUALIZA SALDO DE UNA CUENTA DEL SELPUC**********************
    Public Sub ActualizarMisCuentas(ByVal codigo As String, ByVal debito As String, ByVal credito As String)
        Try
            Dim cdb, ccr, csa As String
            csa = "saldo" & PerActual(0) & PerActual(1)
            cdb = "debito" & PerActual(0) & PerActual(1)
            ccr = "credito" & PerActual(0) & PerActual(1)
            Dim suma, db, cb As Double
            Try
                db = CDbl(debito)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cb = CDbl(credito)
            Catch ex As Exception
                cb = 0
            End Try
            suma = db - cb
            myCommand.CommandText = "UPDATE selpuc SET " _
            & "saldo = saldo + " & suma & ", " _
            & csa & "=" & csa & " + " & suma & ", " _
            & cdb & "=" & cdb & " + " & db & ", " _
            & ccr & "=" & ccr & " + " & cb & " " _
            & "WHERE codigo='" & codigo & "';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub VeificarRDIAN(ByVal tipo As String, ByVal num As Integer, ByVal fecha As Date)
        Try
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.CommandText = "SELECT * FROM parafacgral;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Dim hr, fin, flim, reso As String
            If tipo = tabla.Rows(0).Item("tipof1") Then
                hr = "hr1" '¿HAY RESOLUCION?
                fin = "fin1" 'TOPE NUMERO DE FACTURA
                flim = "feclim1" 'FECHA LIMITE RESOLUCION
                reso = "reso1" 'NUMERO DE L RESOLUCIÓN
            ElseIf tipo = tabla.Rows(0).Item("tipof2") Then
                hr = "hr2"
                fin = "fin2"
                flim = "feclim2"
                reso = "reso2"
            ElseIf tipo = tabla.Rows(0).Item("tipof3") Then
                hr = "hr3"
                fin = "fin3"
                flim = "feclim3"
                reso = "reso3"
            ElseIf tipo = tabla.Rows(0).Item("tipof4") Then
                hr = "hr4"
                fin = "fin4"
                flim = "feclim4"
                reso = "reso4"
            Else
                Exit Sub 'NO HAY EL DOCUMENTO ES DE AJUSTE
            End If
            '*************** VERIFICACION RESOLUCION DIAN ***********************
            If tabla.Rows(0).Item(hr) = "NO" Then Exit Sub 'HO HAY RESOLUCION PARA ESTE DOCUMENTO
            If num > Val(tabla.Rows(0).Item(fin)) And Val(tabla.Rows(0).Item(fin)) > 0 Then
                MsgBox("Has superado el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & tabla.Rows(0).Item(reso) & ", Limite=" & Val(tabla.Rows(0).Item(fin)), MsgBoxStyle.Critical, "SAE Resolución DIAN")
            ElseIf num + 50 >= Val(tabla.Rows(0).Item(fin)) And Val(tabla.Rows(0).Item(fin)) > 0 Then
                MsgBox("Ya casi superas el limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & tabla.Rows(0).Item(reso) & ", Limite=" & Val(tabla.Rows(0).Item(fin)), MsgBoxStyle.Information, "SAE Resolución DIAN")
            Else
                'If fecha > CDate(tabla.Rows(0).Item(flim).ToString) Then
                '    MsgBox("Ha superado la fecha limite para realizar facturas por computador permitidas por la RESOLUCIÓN DIAN " & tabla.Rows(0).Item(reso) & ", Fecha Limite=" & tabla.Rows(0).Item(flim).ToString, MsgBoxStyle.Critical, "SAE Resolución DIAN")
                'Else
                '    fecha = DateAdd(DateInterval.Day, 15, fecha)
                '    If fecha >= CDate(tabla.Rows(0).Item(flim).ToString) Then
                '        MsgBox("Ya casi superas la fecha limite de facturas por computador permitidas por la RESOLUCIÓN DIAN " & tabla.Rows(0).Item(reso) & ", Fecha Limite=" & tabla.Rows(0).Item(flim).ToString, MsgBoxStyle.Information, "SAE Resolución DIAN")
                '    End If
                'End If
            End If
            '*************************************************************
        Catch ex As Exception

        End Try
    End Sub
    '*******************************************
    Function PerBloq()
        Dim tablabloq As New DataTable
        myCommand.CommandText = "SELECT * FROM bloq_per WHERE periodo='" & PerActual(0) & PerActual(1) & "' ORDER BY periodo;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablabloq)
        If tablabloq.Rows(0).Item(1) <> "n" Then
            MsgBox("El periodo actual fue bloqueado, verifique.   ", MsgBoxStyle.Information, "Verificando")
            Return False
        Else
            Return True
        End If
    End Function
    '***************ENVIAR EMAIL *****************
    Public Sub EnviarEmail(ByVal host As String, ByVal c_from As String, ByVal pass As String, ByVal ruta As String, ByVal cuerpo As String, ByVal para As String, ByVal para2 As String, ByVal asunto As String)
        Try

            Dim mail As New MailMessage()
            Dim Attach As Attachment
            Dim SmtpServer As New SmtpClient

            SmtpServer.Timeout = 1

            SmtpServer.Credentials = New Net.NetworkCredential(c_from, pass) 'para autentificarnos
            If host = "hotmail" Then
                SmtpServer.Port = 25
                SmtpServer.Host = "smtp.live.com"
            ElseIf host = "gmail" Then
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
            ElseIf host = "yahoo" Then
                'SMTP
                'SmtpServer.Port = 465
                'SmtpServer.Host = "smtp.mail.yahoo.com.ar"
                'POP3
                SmtpServer.Port = 995
                SmtpServer.Host = "pop.mail.yahoo.com"
            Else
                MsgBox("no ha seleccionado servidor.....")
                Exit Sub
            End If
            SmtpServer.EnableSsl = True
            If Trim(para) <> "" Then mail.To.Add(para)
            If Trim(para2) <> "" Then mail.To.Add(para2)
            mail.From = New MailAddress(c_from) 'la misma con la que nos autentificamos
            mail.Subject = asunto
            If Trim(ruta) <> "" Then
                Attach = New Attachment(ruta) 'ruta del archivo 
                mail.Attachments.Add(Attach)
            End If
            mail.Body = cuerpo
            SmtpServer.Send(mail)
            mail.Dispose()

            MsgBox("Email Enviado")
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString)
        End Try
    End Sub
    '************* CALCULAR EDAD ******************
    Function Calcular_Edad(ByVal Fecha_Nacimiento As Date)
        Dim Años As Object
        Try
            Años = DateDiff("yyyy", Fecha_Nacimiento, Now)
            If Now < DateSerial(Now.Year, Fecha_Nacimiento.Month, Fecha_Nacimiento.Day) Then
                Años = Años - 1
            End If
            Return CInt(Años)
        Catch ex As Exception
            Return "0"
        End Try

    End Function
    '****************** ABRIR PDF **************************
    Public Sub AbrirArchivo(ByVal ruta As String)
        '********** ELIMINO Y/O DIRECTORIO *****************
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\temp", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
        End Try
        '********** CREO DIRECTORIO *****************
        Try
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\temp")
        Catch ex As Exception
        End Try
        '**************** CREO EL ARCHIVO TEMPORAL *******************
        Dim archivo As String = "temp\temp_" & Now.Year & "_" & Now.Month & "_" & Now.Day & "_" & Now.Hour & "_" & Now.Minute & "_" & Now.Second & "_" & Now.Millisecond & ".pdf"
        Try
            My.Computer.FileSystem.CopyFile(ruta, My.Application.Info.DirectoryPath & "\" & archivo)
        Catch ex As Exception
        End Try
        '*************** ABRIR ARCHIVO DESDE EL CMD ********************
        Try
            Dim comando, Arg As String
            comando = "C:\Windows\System32\cmd.exe"
            Arg = ruta
            Dim Pr As Process = New Process
            Pr.StartInfo.FileName = comando
            Pr.StartInfo.Arguments = Arg
            Pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Pr.StartInfo.FileName = archivo
            Pr.Start()
        Catch ex As Exception
            MessageBox.Show("Error al abrir el archivo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GuardarError(ByVal msj As String, ByVal form As String, ByVal proc As String)
        Try
            msj = msj.Replace("'", " ")
            myCommand.Parameters.Clear()
            myCommand.CommandText = " INSERT INTO error VALUES (null, '" & form & "','" & msj & "','" & DateTime.Now.ToString("yyyy-MM-dd") & "','" & proc & "' );"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LLenarMovPresupuestoGas()

        MiConexion(bda)

        EliminarDatos()

        Dim sql As String = ""
        Dim p As String = ""

        For i = 1 To 12
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> 12 Then
                sql = sql & "SELECT doc_afec, CONCAT(RIGHT(periodo, 4) , LEFT(periodo,2) , IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f " _
                & " FROM ot_cpp" & p & " WHERE doc_afec<>'' UNION "
                '& " and LENGTH(doc_afec)=11 UNION "
            Else
                sql = sql & "SELECT doc_afec, CONCAT(RIGHT(periodo, 4) , LEFT(periodo,2) , IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f " _
                & " FROM ot_cpp" & p & " WHERE doc_afec<>'' "
                '& " and LENGTH(doc_afec)=11 "
            End If
        Next


        Dim t As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count > 0 Then
            MsgBox("espere un momento")

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE presupuesto" & Strings.Right(PerActual, 4) & ".gasconcepto SET gasc_orden=gasc_cod1"
            'myCommand.ExecuteNonQuery()
            For i = 0 To t.Rows.Count - 1
                pagoPres(t.Rows(i).Item("doc_afec"))
                Mov_presGas(t.Rows(i).Item("doc_afec"), t.Rows(i).Item("f"))
                Mov_presIng(t.Rows(i).Item("doc_afec"), t.Rows(i).Item("f"))
            Next
            MsgBox("Fin del proceso")
        End If

        Reprocesar_otce_presup()
        Reprocesar_conciliaciones()
        Reprocesar_OtrosCI()

        Cerrar()

    End Sub
    Private Sub EliminarDatos()

        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM " & pbd & ".recaudos WHERE rec_modulo IN ('sae_ce','sae_ordenes','REPROCESAR ORDENES','sae_otrosing','REPROCESAR OTROSCE','sae_cbanco');"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM " & pbd & ".movingresos WHERE movi_reconoce NOT IN (0,'') AND CAST(movi_reconoce AS SIGNED) >0;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "DELETE FROM " & pbd & ".movgastos WHERE mov_vsae<>0;"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE  " & pbd & ".pagos SET pag_sae='NO' WHERE pag_sae='SI';"
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub pagoPres(ByVal doccxp As String)
        Dim tap As New DataTable
        tap.Clear()
        myCommand.CommandText = "SELECT salmov FROM ctas_x_pagar WHERE doc='" & doccxp & "' and LEFT(fecha,4)='" & Strings.Right(PerActual, 4) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tap)

        If tap.Rows.Count = 0 Then Exit Sub
        myCommand.Parameters.Clear()
        myCommand.CommandText = "UPDATE presupuesto" & Strings.Right(PerActual, 4) & ".pagos SET pag_sae='SI' WHERE pag_consecutivo='" & tap.Rows(0).Item(0) & "'"
        myCommand.ExecuteNonQuery()
    End Sub

    Private Sub Mov_presIng(ByVal doccxp As String, ByVal f As String)

        'If doccxp = "CP01158" Then
        '    MsgBox("hola")
        'End If
        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim cta As String = ""
        Dim ing As String = ""
        Dim val As Double = 0

        Dim tcta As New DataTable
        tcta.Clear()
        myCommand.CommandText = "SELECT d.cta, d.cr, o.con_ben, o.nomnit, o.sop_cont FROM ord_pagos o , deta_ord d  WHERE o.doccxp='" & doccxp & "' AND d.doc= o.doc AND cta LIKE '41%';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tcta)

        If tcta.Rows.Count = 0 Then Exit Sub

        For i = 0 To tcta.Rows.Count - 1
            cta = tcta.Rows(i).Item("cta")
            val = tcta.Rows(i).Item("cr")

            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
            & " WHERE v.ingv_contrac='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count <> 0 Then
                ing = tp.Rows(0).Item(1)
                Try
                    'Guardar MovIng
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                    & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                    & "movi_aplaza,movi_desaplaza,movi_recaudo, movi_reconoce) " _
                                    & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                    & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & tcta.Rows(i).Item("sop_cont") & "' )"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try

                    If Trim(tcta.Rows(i).Item("sop_cont")) <> "" Then
                        myCommand.Parameters.Clear()
                        myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
                       & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
                       & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
                       & "   " & f & ", '" & ing & "',  'RECAUDO POR " & tcta.Rows(i).Item("sop_cont") & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
                       & " '',  '',  'REPROCESAR ORDENES', '" & tcta.Rows(i).Item("sop_cont") & "', '" & tcta.Rows(i).Item("con_ben") & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
                        myCommand.ExecuteNonQuery()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    '..Buscar nivel
                    Dim tam As Integer = Len(ing)
                    Dim lik As String = ""

                    Dim tg As New DataTable
                    myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tg)
                    Dim nv As String = tg.Rows(0).Item(0)
                    Dim num As String = tg.Rows(0).Item(1)
                    For j = 0 To tam
                        lik = Strings.Left(ing, tam - j)

                        Dim tc As New DataTable
                        tc.Clear()
                        myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                        & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                        & "FROM " & pbd & ".ingvalores as v " _
                                        & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                        & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                        & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                        & "c.ingc_concepto LIMIT 1"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)
                        If tc.Rows.Count > 0 Then
                            For k = 0 To tc.Rows.Count - 1
                                nv = tc.Rows(k).Item("nivel")
                                num = tc.Rows(k).Item("num")
                                'Guardar MovIng
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                                & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & tcta.Rows(i).Item("sop_cont") & "' )"
                                myCommand.ExecuteNonQuery()

                            Next
                        End If

                    Next

                Catch ex As Exception
                    MsgBox("Error " & ex.ToString)
                End Try
            End If

        Next
    End Sub
    Private Sub Mov_presGas(ByVal doccxp As String, ByVal f As String)

        Dim tp As New DataTable
        tp.Clear()
        myCommand.CommandText = "SELECT ccosto, rcpos FROM ctas_x_pagar WHERE doc='" & doccxp & "' and LEFT(fecha,4)='" & Strings.Right(PerActual, 4) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tp)

        If tp.Rows.Count = 0 Then Exit Sub

        Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
        Dim v As String = ""

        Dim rb(), vrb() As String
        rb = tp.Rows(0).Item(0).Split(";")
        vrb = tp.Rows(0).Item(1).Split(";")

        If rb.Length = 0 Then Exit Sub
        For i = 0 To rb.Length - 1

            If Trim(rb(i).ToString) = "" Then Exit Sub
            Try
                v = vrb(i).ToString
                ' v = MontoRubro2(vrb(i).ToString.Replace(".", ","))
            Catch ex As Exception
                v = 0
            End Try

            Try
                'Guardar MovGasto
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO " & pbd & ".`movgastos`(movg_rubro,movg_fecha, movg_vigencia, " _
                                & "movg_aumento, movg_reduccion, movg_credito, movg_contra, " _
                                & "movg_aplaza,movg_desaplaza, movg_cdp, movg_rp, movg_pago,movg_anticipo,mov_vsae) " _
                                & "VALUES ('" & rb(i).ToString & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                & " '0', '0', '0', '0', '0', '0', '0', '0','0','0'," & v & " )"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '..Buscar nivel
            Dim tam As Integer = Len(rb(i).ToString)
            Dim lik As String = ""

            Dim tg As New DataTable
            tg.Clear()
            myCommand.CommandText = "SELECT gasc_nivel, gasc_nums  FROM " & pbd & ".gasconcepto WHERE gasc_orden='" & rb(i).ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tg)
            'If tg.Rows.Count = 0 Then Exit For

            Try
                If tg.Rows.Count <> 0 Then

                    Dim nv As String = tg.Rows(0).Item(0)
                    Dim num As String = tg.Rows(0).Item(1)
                    For j = 0 To tam
                        lik = Strings.Left(rb(i).ToString, tam - j)

                        Dim tc As New DataTable
                        tc.Clear()
                        myCommand.CommandText = "SELECT c.gasc_cod1 as codigo, c.gasc_concepto, " _
                                        & "c.gasc_nivel as nivel, c.gasc_nums as num " _
                                        & "FROM " & pbd & ".gasvalores as v " _
                                        & "INNER JOIN " & pbd & ".gasconcepto as c ON c.gasc_cod1=v.gasv_cod1 " _
                                        & "WHERE c.gasc_orden = '" & lik & "' AND c.gasc_nums< " & num & " " _
                                        & "AND c.gasc_nivel<" & nv & " ORDER BY c.gasc_nivel, " _
                                        & "c.gasc_concepto LIMIT 1"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)

                        If tc.Rows.Count > 0 Then
                            For k = 0 To tc.Rows.Count - 1
                                nv = tc.Rows(k).Item("nivel")
                                num = tc.Rows(k).Item("num")
                                'Guardar MovGasto
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "INSERT INTO " & pbd & ".`movgastos`(movg_rubro,movg_fecha, movg_vigencia, " _
                                                & "movg_aumento, movg_reduccion, movg_credito, movg_contra, " _
                                                & "movg_aplaza,movg_desaplaza, movg_cdp, movg_rp, movg_pago,movg_anticipo,mov_vsae) " _
                                                & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                                & " '0', '0', '0', '0', '0', '0', '0', '0','0','0'," & v & " )"
                                myCommand.ExecuteNonQuery()

                            Next
                        End If

                    Next
                End If
            Catch ex As Exception
                MsgBox("Error " & ex.ToString)
            End Try
        Next

    End Sub
    Private Sub Reprocesar_OtrosCI()

        Dim sql As String = ""
        Dim p As String = ""
        'Dim tdoc As String = ""

        'Dim t As New DataTable
        't.Clear()
        'myCommand.CommandText = "SELECT doc3 FROM parbanc "
        'myAdapter.SelectCommand = myCommand
        'myAdapter.Fill(t)
        'If t.Rows.Count = 0 Then Exit Sub
        'MsgBox("espere un momento_ReprocesarConciliaciones")
        'tdoc = t.Rows(0).Item(0)

        sql = "SELECT num,rb_cod1, nitc, CAST(CONCAT(LEFT(fecha,4),MID(fecha,6,2),RIGHT(fecha,2)) AS CHAR(15)) AS f, " _
        & " CAST(CONCAT(MID(fecha,6,2),'/',LEFT(fecha,4),'-',doc_ci,num_ci) AS CHAR(25)) AS doc, valor  FROM otdoc_pres"

        Dim tb As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)

        If tb.Rows.Count = 0 Then
            MsgBox("No hay datos para ReprocesarOtrosCI")
            Exit Sub
        End If

        For i = 0 To tb.Rows.Count - 1
            Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
            'Dim cta As String = ""
            Dim ing As String = ""
            Dim val As Double = 0
            Dim f As String = tb.Rows(i).Item("f")

            'cta = tb.Rows(i).Item("rb_cod1")
            val = tb.Rows(i).Item("valor")
            ing = tb.Rows(i).Item("rb_cod1")

            Try
                'Guardar MovIng
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & tb.Rows(i).Item("doc") & "' )"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
               & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
               & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
               & "   " & f & ", '" & ing & "',  '', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
               & " '',  '',  'sae_otrosing', '" & tb.Rows(i).Item("doc") & "', '0',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                '..Buscar nivel
                Dim tam As Integer = Len(ing)
                Dim lik As String = ""

                Dim tg As New DataTable
                myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tg)
                Dim nv As String = tg.Rows(0).Item(0)
                Dim num As String = tg.Rows(0).Item(1)
                For j = 0 To tam
                    lik = Strings.Left(ing, tam - j)

                    Dim tc As New DataTable
                    tc.Clear()
                    myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                    & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                    & "FROM " & pbd & ".ingvalores as v " _
                                    & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                    & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                    & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                    & "c.ingc_concepto LIMIT 1"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tc)
                    If tc.Rows.Count > 0 Then
                        For k = 0 To tc.Rows.Count - 1
                            nv = tc.Rows(k).Item("nivel")
                            num = tc.Rows(k).Item("num")
                            'Guardar MovIng
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                            & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                            & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                            & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & tb.Rows(i).Item("doc") & "' )"
                            myCommand.ExecuteNonQuery()

                        Next
                    End If

                Next
            Catch ex As Exception
                MsgBox("Error " & ex.ToString)
            End Try
        Next
        MsgBox("Fin del proceso_ReprocesarOtrosCI")

    End Sub
    Private Sub Reprocesar_conciliaciones()

        Dim sql As String = ""
        Dim p As String = ""
        Dim tdoc As String = ""

        Dim t As New DataTable
        t.Clear()
        myCommand.CommandText = "SELECT doc3 FROM parbanc "
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count = 0 Then Exit Sub
        MsgBox("espere un momento_ReprocesarConciliaciones")
        tdoc = t.Rows(0).Item(0)

        For i = 1 To 12
            If i <= 9 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> 12 Then
                sql = sql & " SELECT item, CONCAT(RIGHT(periodo,4),LEFT(periodo,2),IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f, centro," _
                & " cast(CONCAT(item,'-',periodo,'-',tipodoc,LPAD(doc,5,0)) as char(50)) AS doct, cast(IF(debito<>0,CONCAT('-',debito), credito) as signed) as valor, nit, descri " _
                & " FROM documentos" & p & " WHERE tipodoc='CB' AND centro NOT IN (0, '') AND codigo NOT LIKE '1110%' union"
            Else
                sql = sql & " SELECT item, CONCAT(RIGHT(periodo,4),LEFT(periodo,2),IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f, centro," _
           & " CAST(CONCAT(item,'-',periodo,'-',tipodoc,LPAD(doc,5,0)) AS CHAR(50)) AS doct, cast(IF(debito<>0,CONCAT('-',debito), credito) as signed) as valor, nit, descri " _
           & " FROM documentos" & p & " WHERE tipodoc='CB' AND centro NOT IN (0, '') AND codigo NOT LIKE '1110%' "
            End If
        Next

        Dim tb As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)

        If tb.Rows.Count = 0 Then
            MsgBox("No hay datos para ReprocesarConciliaciones")
            Exit Sub
        End If

        For i = 0 To tb.Rows.Count - 1
            Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
            ' Dim cta As String = ""
            Dim ing As String = ""
            Dim val As Double = 0
            Dim f As String = tb.Rows(i).Item("f")

            'cta = tb.Rows(i).Item("codigo")
            val = tb.Rows(i).Item("valor")
            ing = tb.Rows(i).Item("centro")

            Try
                'Guardar MovIng
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & tb.Rows(i).Item("doct") & "' )"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
               & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
               & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
               & "   " & f & ", '" & ing & "',  '', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
               & " '',  '',  'sae_cbanco', '" & tb.Rows(i).Item("doct") & "', '0',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                '..Buscar nivel
                Dim tam As Integer = Len(ing)
                Dim lik As String = ""

                Dim tg As New DataTable
                myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tg)
                Dim nv As String = tg.Rows(0).Item(0)
                Dim num As String = tg.Rows(0).Item(1)
                For j = 0 To tam
                    lik = Strings.Left(ing, tam - j)

                    Dim tc As New DataTable
                    tc.Clear()
                    myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                    & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                    & "FROM " & pbd & ".ingvalores as v " _
                                    & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                    & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                    & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                    & "c.ingc_concepto LIMIT 1"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tc)
                    If tc.Rows.Count > 0 Then
                        For k = 0 To tc.Rows.Count - 1
                            nv = tc.Rows(k).Item("nivel")
                            num = tc.Rows(k).Item("num")
                            'Guardar MovIng
                            myCommand.Parameters.Clear()
                            myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                            & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                            & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                            & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & tb.Rows(i).Item("doct") & "' )"
                            myCommand.ExecuteNonQuery()

                        Next
                    End If

                Next
            Catch ex As Exception
                MsgBox("Error " & ex.ToString)
            End Try
        Next
        MsgBox("Fin del proceso_ReprocesarConciliaciones")

    End Sub
    Private Sub Reprocesar_otce_presup()

        Dim sql As String = ""
        Dim p As String = ""
        Dim tdoc As String = ""

        Dim t As New DataTable
        myCommand.CommandText = "SELECT ce FROM `parotdoc`"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows.Count = 0 Then Exit Sub
        MsgBox("espere un momento_ReprocesarOtrosCE")
        tdoc = t.Rows(0).Item(0)


        For i = 1 To 12
            If i <= 9 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> 12 Then
                sql = sql & " SELECT CONCAT(periodo,'-',doc) AS doct," _
                & " CONCAT(RIGHT(periodo,4),LEFT(periodo,2),IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f, " _
                & " dia, periodo,codigo, credito, nitc FROM ot_doc" & p & " WHERE credito<>0 AND tipo= '" & tdoc & "' AND codigo LIKE '4%' UNION "
            Else
                sql = sql & " SELECT CONCAT(periodo,'-',doc) AS doct," _
             & " CONCAT(RIGHT(periodo,4),LEFT(periodo,2),IF(LENGTH(dia)=1,CONCAT('0',dia),dia)) AS f, " _
             & " dia, periodo,codigo, credito, nitc FROM ot_doc" & p & " WHERE credito<>0 AND tipo= '" & tdoc & "' AND codigo LIKE '4%' "
            End If
        Next

        Dim tb As New DataTable
        myCommand.CommandText = sql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tb)

        If tb.Rows.Count = 0 Then
            MsgBox("No hay datos para reprocesar_ReprocesarOtroCE")
            Exit Sub
        End If

        For i = 0 To tb.Rows.Count - 1

            Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
            Dim cta As String = ""
            Dim ing As String = ""
            Dim val As Double = 0
            Dim f As String = tb.Rows(i).Item("f")

            cta = tb.Rows(i).Item("codigo")
            val = tb.Rows(i).Item("credito")

            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
            & " WHERE v.ingv_contrac='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count <> 0 Then
                ing = tp.Rows(0).Item(1)

                Try
                    'Guardar MovIng
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                    & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                    & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                    & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                    & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & tb.Rows(i).Item("doct") & "' )"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    myCommand.Parameters.Clear()
                    myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
                   & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
                   & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
                   & "   " & f & ", '" & ing & "',  '', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
                   & " '',  '',  'REPROCESAR OTROSCE', '" & tb.Rows(i).Item("doct") & "', '0',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
                    myCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    '..Buscar nivel
                    Dim tam As Integer = Len(ing)
                    Dim lik As String = ""

                    Dim tg As New DataTable
                    myCommand.CommandText = "SELECT ingc_nivel, ingc_nums  FROM " & pbd & ".ingconcepto WHERE ingc_orden='" & ing & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tg)
                    Dim nv As String = tg.Rows(0).Item(0)
                    Dim num As String = tg.Rows(0).Item(1)
                    For j = 0 To tam
                        lik = Strings.Left(ing, tam - j)

                        Dim tc As New DataTable
                        tc.Clear()
                        myCommand.CommandText = "SELECT c.ingc_cod1 as codigo, c.ingc_concepto, " _
                                        & "c.ingc_nivel as nivel, c.ingc_nums as num " _
                                        & "FROM " & pbd & ".ingvalores as v " _
                                        & "INNER JOIN " & pbd & ".ingconcepto as c ON c.ingc_cod1=v.ingv_cod1 " _
                                        & "WHERE c.ingc_orden = '" & lik & "' AND c.ingc_nums< " & num & " " _
                                        & "AND c.ingc_nivel<" & nv & " ORDER BY c.ingc_nivel, " _
                                        & "c.ingc_concepto LIMIT 1"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(tc)
                        If tc.Rows.Count > 0 Then
                            For k = 0 To tc.Rows.Count - 1
                                nv = tc.Rows(k).Item("nivel")
                                num = tc.Rows(k).Item("num")
                                'Guardar MovIng
                                myCommand.Parameters.Clear()
                                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                                & "VALUES ('" & tc.Rows(k).Item("codigo") & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & tb.Rows(i).Item("doct") & "' )"
                                myCommand.ExecuteNonQuery()

                            Next
                        End If

                    Next
                Catch ex As Exception
                    MsgBox("Error " & ex.ToString)
                End Try

            End If
        Next
        MsgBox("Fin del proceso_ReprocesarOtroCE")
    End Sub
    Public Sub ModificarNumCE()
        MiConexion(bda)
        Dim num As String = ""
        Dim tg As New DataTable
        myCommand.Parameters.Clear()
        ' myCommand.CommandText = "SELECT RIGHT(sop_cont,5) AS num , RIGHT(sop_cont,7) AS doc, sop_cont FROM ord_pagos WHERE sop_cont<>'' AND sop_cont LIKE '02/%'  AND sop_cont > '02/2014-CE00067' ORDER BY sop_cont;"
        myCommand.CommandText = "SELECT doc, num FROM ord_pagos WHERE per='04/2014';"

        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tg)

        If tg.Rows.Count = 0 Then Exit Sub
        'num = "23"
        num = "106"
        For i = 0 To tg.Rows.Count - 1

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE documentos02 SET doc='" & num & "' WHERE doc='" & tg.Rows(i).Item("num") & "' AND tipodoc='CE'; "
            'myCommand.ExecuteNonQuery()

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE ot_cpp02 SET doc=CONCAT('CE','" & NumeroDoc(Int(num)) & "'), num=" & num & " WHERE  doc='" & tg.Rows(i).Item("doc") & "';"
            'myCommand.ExecuteNonQuery()

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE ord_pagos SET sop_cont= CONCAT('02/2014-CE','" & NumeroDoc(Int(num)) & "') WHERE sop_cont='" & tg.Rows(i).Item("sop_cont") & "';"
            'myCommand.ExecuteNonQuery()

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE documentos01 SET doc='" & num & "' WHERE doc='" & tg.Rows(i).Item("num") & "' AND tipodoc='CE'; "
            'myCommand.ExecuteNonQuery()

            'myCommand.Parameters.Clear()
            'myCommand.CommandText = "UPDATE ot_cpp01 SET doc=CONCAT('CE','" & NumeroDoc(Int(num)) & "'), num=" & num & " WHERE  doc='" & tg.Rows(i).Item("doc") & "';"
            'myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE ord_pagos SET doc= CONCAT('04/2014-','" & NumeroDoc(Int(num)) & "'), num='" & Int(num) & "' WHERE doc='" & tg.Rows(i).Item("doc") & "';"
            myCommand.ExecuteNonQuery()

            myCommand.Parameters.Clear()
            myCommand.CommandText = "UPDATE deta_ord SET doc= CONCAT('04/2014-','" & NumeroDoc(Int(num)) & "') WHERE doc='" & tg.Rows(i).Item("doc") & "';"
            myCommand.ExecuteNonQuery()

            num = Int(num) + 1
        Next
        MsgBox("OK")
        Cerrar()

    End Sub
End Module

