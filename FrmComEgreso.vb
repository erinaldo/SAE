Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports MySql.Data.MySqlClient
Public Class FrmComEgresoCpp
    Public col, fila, FinEdit As Integer
    Public ps As String = ""

    Private Sub FrmComEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtperiodo.Text = "/" & PerActual
        lbper.Text = PerActual & " - "
        Try
            Dim tablacomp As New DataTable
            '*********************
            myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tablacomp)
            lbcompa.Text = tablacomp.Rows(0).Item("descripcion")
            lbnit.Text = "NIT: " & tablacomp.Rows(0).Item("nit")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

        logo = ""
        Try
            Dim td As New DataTable
            myCommand.CommandText = "SELECT logo FROM parotdoc ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(td)
            logo = td.Rows(0).Item("logo")
        Catch ex As Exception
            logo = "NO"
        End Try

        If ps = "" Then
            lbestado.Text = "NULO"
            ' Desde Inmob
            If lbcontr.Text = "" Then
                txtcodCon.Visible = False
            Else
                txtcodCon.Visible = True
            End If

            CmdPrimero_Click(AcceptButton, AcceptButton)
        End If
    End Sub
    Dim logo As String
    Public Sub PonerEnCero()
        ChAnti.Checked = False
        Chcredito.Checked = False
        txtcodCon.Text = ""
        txtcentro.Text = ""
        txtncentro.Text = ""
        txtnumero.Text = ""
        txtciudad.Text = ""
        txtdia.Text = Now.Day
        Try
            Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            txtdia.Text = "01"
        End Try
        txtdetall.Text = ""
        txtvalor.Text = "0,00"
        lbcliente.Text = ""
        txtconcepto.Text = ""
        lbsuma.Text = "SON CERO PESOS"
        grilla.Rows.Clear()
        grilla.RowCount = 4
        txtcheque.Text = ""
        txtbanco.Text = ""
        txtsucursal.Text = ""
        chefectivo.Checked = True
        txtnit.Text = ""
        txtelaborado.Text = ""
        txtaprobado.Text = ""
        txtconta.Text = ""
        fecha.Value = Today
        lbestado.Text = "NULO"
        lbnroobs.Text = "0"
        Bloquear()
    End Sub
    Public Sub Bloquear()
        Try
            txtcodCon.Enabled = False
        Catch ex As Exception
        End Try
        Chcredito.Enabled = False
        ChAnti.Enabled = False
        txtcentro.Enabled = False
        grilla.ReadOnly = True
        txtdia.Enabled = False
        chefectivo.Enabled = False
        fecha.Enabled = False
        txtaprobado.Enabled = False
        txtelaborado.Enabled = False
        txtconta.Enabled = False
        rbcc.Enabled = False
        rbnit.Enabled = False
        '**** READ ONLY *************
        txtdetall.ReadOnly = True
        txtciudad.ReadOnly = True
        txtnit.ReadOnly = True
        txtconcepto.ReadOnly = True
        txtvalor.ReadOnly = True
        txtcheque.ReadOnly = True
        txtbanco.ReadOnly = True
        txtsucursal.ReadOnly = True
        '********** comandos ***********
        CmdNuevo.Enabled = True
        CmdListo.Enabled = False
        CmdCancelar.Enabled = False
        cmdEdit.Enabled = True
        'CmdEliminar.Enabled=true 
        cmdprint.Enabled = True
        CmdMostrar.Enabled = True
        txtnumero.Enabled = False
        grilla.Columns("cc").ReadOnly = True


    End Sub
    Public Sub DesBloquear()
        grilla.ReadOnly = False
        Dim t As New DataTable
        myCommand.CommandText = "SELECT ccosto FROM parcontab;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t)
        If t.Rows(0).Item("ccosto") = "S" Then
            txtcentro.Enabled = True
            grilla.Columns("cc").ReadOnly = False
        Else
            txtcentro.Enabled = False
            grilla.Columns("cc").ReadOnly = True
        End If
        '****************************************************
        Try
            txtcodCon.Enabled = True
        Catch ex As Exception
        End Try
        Chcredito.Enabled = True
        ChAnti.Enabled = True
        txtdia.Enabled = True
        chefectivo.Enabled = True
        fecha.Enabled = True
        txtaprobado.Enabled = True
        txtelaborado.Enabled = True
        txtconta.Enabled = True
        rbcc.Enabled = True
        rbnit.Enabled = True
        '**** READ ONLY *************
        txtdetall.ReadOnly = False
        txtciudad.ReadOnly = False
        txtnit.ReadOnly = False
        txtconcepto.ReadOnly = False
        txtvalor.ReadOnly = False
        txtcheque.ReadOnly = False
        txtbanco.ReadOnly = False
        txtsucursal.ReadOnly = False
        '********** comandos ***********
        CmdNuevo.Enabled = False
        CmdListo.Enabled = True
        CmdCancelar.Enabled = True
        cmdEdit.Enabled = False
        'CmdEliminar.Enabled=False 
        cmdprint.Enabled = False
        CmdMostrar.Enabled = False
    End Sub
    Public Sub BuscarActual()
        If lbestado.Text = "NUEVO" Then
            Dim tabla2, tabla As New DataTable
            myCommand.CommandText = "SELECT ce FROM parotdoc;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para los comprobantes de egresos (del grupo CE), verifique.   ", MsgBoxStyle.Information, "Verificando")
                Me.Close()
                Exit Sub
            End If
            myCommand.CommandText = "SELECT tipodoc, descripcion, actual" & PerActual(0) & PerActual(1) & ", grupo, actualfc FROM tipdoc WHERE tipodoc='" & tabla.Rows(0).Item(0) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            If tabla2.Rows.Count < 1 Then
                MsgBox("Favor no han creado tipo de documento para los comprobantes de egresos (del grupo CE), verifique.   ", MsgBoxStyle.Information, "Verificando")
                Me.Close()
            Else
                lbnomdoc.Text = tabla2.Rows(0).Item("descripcion").ToString
                lbdoc.Text = tabla2.Rows(0).Item("tipodoc").ToString
                If tabla2.Rows(0).Item("grupo").ToString = "FC" Then
                    txtnumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item("actualfc").ToString) + 1)
                Else
                    txtnumero.Text = NumeroDoc(Val(tabla2.Rows(0).Item(2).ToString) + 1)
                End If
            End If
        End If
    End Sub
    Public Sub CmdNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdNuevo.Click
        If PerBloq() = False Then Exit Sub
        If lbestado.Text = "NUEVO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        If tra_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If

        myCommand.CommandText = "SELECT * FROM selpuc WHERE nivel='Auxiliar';"
        myAdapter.SelectCommand = myCommand
        Dim tabla2 As New DataTable
        myAdapter.Fill(tabla2)
        If tabla2.Rows.Count <= 0 Then
            MsgBox("Favor no han creados cuentas auxiliares, Verifique.  ", MsgBoxStyle.Information, "Verificando")
            Exit Sub
        End If
        PonerEnCero()
        Try
            Dim tu As New DataTable
            myCommand.CommandText = "SELECT concat(nombres,' ',apellidos) FROM sae.usuarios WHERE login='" & FrmPrincipal.lbuser.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tu)
            txtelaborado.Text = tu.Rows(0).Item(0)
        Catch ex As Exception
            txtelaborado.Text = FrmPrincipal.lbuser.Text
        End Try
        Try
            Dim tc As New DataTable
            myCommand.CommandText = "SELECT contador FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tc)
            txtconta.Text = tc.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        Try
            Dim tca As New DataTable
            myCommand.CommandText = "SELECT firma1 FROM parordenes ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tca)
            txtaprobado.Text = tca.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        lbestado.Text = "NUEVO"
        DesBloquear()
        SacarCuenta()
        BuscarActual()
        txtnumero.Enabled = True
        txtnumero.ReadOnly = False
        If txtcentro.Enabled = True Then
            txtcentro.Focus()
        Else
            If lbcontr.Text <> "" Then
                txtcodCon.Focus()
            Else
                txtciudad.Focus()
            End If
        End If
    End Sub
    Private Sub CmdListo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdListo.Click

        Try
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                If ValidarGuardar() = True Then
                    AuditoriaCE()
                    MiConexion(bda)
                    If lbestado.Text = "NUEVO" Then
                        Dim ban As Integer = 0
                        Dim tabla As New DataTable
                        '************** COMO ES NUEVO GUARDAR UNO QUE NO EXISTA ********************
                        While ban = 0
                            tabla.Clear()
                            'myCommand.CommandText = "SELECT doc FROM ot_doc" & PerActual(0) & PerActual(1) & " WHERE doc ='" & lbdoc.Text & txtnumero.Text & "';"
                            myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc ='" & CInt(txtnumero.Text) & "' and tipodoc='" & lbdoc.Text & "';"
                            myAdapter.SelectCommand = myCommand
                            myAdapter.Fill(tabla)
                            If tabla.Rows.Count = 0 Then 'NO EXISTE
                                ban = 1
                            Else 'EXISTE BUSCO EL SGT
                                txtnumero.Text = NumeroDoc(Val(txtnumero.Text) + 1)
                                ban = 0
                            End If
                        End While
                        If ChAnti.Checked = True Then
                            If GuardarAnticipo() = 0 Then
                                MsgBox("Favor seleccione una cuenta para los anticipos para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                Exit Sub
                            End If
                        End If
                        For i = 0 To grilla.RowCount - 1
                            If grilla.Item(0, i).Value <> "" Then
                                Try
                                    Guardar(i)
                                    GuardarContable(i)
                                    ActualizarCuentas(i)
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            End If

                            If FrmPrincipal.cmdOrden.Visible = True Then
                                If grilla.Item(0, i).Value <> "" Then
                                    GuardarPresupuesto(i)
                                End If
                            End If
                        Next
                                '*******************************
                                '......... GUARDAR CREDITO
                                If Chcredito.Checked = True Then
                                    If GuardarCxP() = 0 Then
                                        MsgBox("Favor seleccione una cuenta cuenta de cuentas por cobrar para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                        Exit Sub
                                    End If
                                End If
                                '********************************
                                '********************************
                                'Guardar_Nov()
                        GuardarObserva()

                        Dim t2 As New DataTable
                        myCommand.CommandText = "SELECT tipodoc,  grupo, actualfc FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                        myAdapter.SelectCommand = myCommand
                        myAdapter.Fill(t2)
                        Dim cs As String = ""
                        If t2.Rows(0).Item("grupo") <> "FC" Then
                            cs = "Update tipdoc set actual" & PerActual(0) & PerActual(1) & "=?actual WHERE tipodoc=?tipodoc AND actual" & PerActual(0) & PerActual(1) & "<?actual;"
                        Else
                            cs = "Update tipdoc set actualfc=?actual WHERE tipodoc=?tipodoc AND actualfc<?actual;"
                        End If

                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("?actual", txtnumero.Text.ToString)
                        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
                        myCommand.CommandText = cs
                        myCommand.ExecuteNonQuery()
                                lbestado.Text = "GUARDADO"
                                '.....
                                If FrmPrincipal.cmdAuditoria.Visible = True Then
                                    Guar_MovUser("CONTABILIDAD", "GUARDAR COMPROBANTE DE EGRESO Nº: " & lbdoc.Text & txtnumero.Text, "", "", "")
                                End If
                                '.....
                                MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                                Bloquear()
                            Else
                                Dim s As String = ""
                                Dim resultado As MsgBoxResult
                                resultado = MsgBox("El documento " & lbdoc.Text & txtnumero.Text & " se va a Editar, ¿Desea Modificarlo?", MsgBoxStyle.YesNo, "Verificando")
                                If resultado = MsgBoxResult.Yes Then
                                    If ChAnti.Checked = True Then
                                        If GuardarAnticipo() = 0 Then
                                            MsgBox("Favor seleccione una cuenta para los anticipos para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                            Exit Sub
                                        End If
                                    End If
                                    ModificarCuentas()
                                    Eliminar()

                                    s = Eliminar()
                                    If s <> "" Then
                                        CmdCancelar_Click(AcceptButton, AcceptButton)
                                        Exit Sub
                                    End If

                                    For i = 0 To grilla.RowCount - 1
                                        If grilla.Item(0, i).Value <> "" Then
                                            Try
                                                Guardar(i)
                                                GuardarContable(i)
                                                ActualizarCuentas(i)
                                            Catch ex As Exception
                                                MsgBox(ex.ToString)
                                            End Try
                                        End If

                                If FrmPrincipal.cmdOrden.Visible = True Then
                                    If grilla.Item(0, i).Value <> "" Then
                                        GuardarPresupuesto(i)
                                    End If
                                End If
                            Next
                                    '*******************************
                                    '......... GUARDAR CREDITO
                                    If Chcredito.Checked = True Then
                                        If GuardarCxP() = 0 Then
                                            MsgBox("Favor seleccione una cuenta de cuentas por pagar para poder guardar el documento.", MsgBoxStyle.Information, "SAE Control de Datos")
                                            Exit Sub
                                        End If
                                    End If
                                    '********************************
                                    'Guardar_Nov()
                                    GuardarObserva()
                                    lbestado.Text = "EDITADO"
                                    '.....
                                    If FrmPrincipal.cmdAuditoria.Visible = True Then
                                        Guar_MovUser("CONTABILIDAD", "MODIFICAR COMPROBANTE DE EGRESO Nº: " & lbdoc.Text & txtnumero.Text, "", "", "")
                                    End If
                                    '.....
                                    MsgBox("La Base De Datos Se Actualizó Correctamente.  ", MsgBoxStyle.Information, "Guardar Datos")
                                    Bloquear()
                                End If
                            End If
                    Cerrar()
                End If
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox("Error al intentar guardar el registro, por favor intentelo nuevamente.    " & ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub SacarCuenta()
        Try
            Dim sumadb, sumacr, db, cr As Double
            sumadb = 0
            sumacr = 0
            For i = 0 To grilla.RowCount - 1
                Try
                    db = CDbl(grilla.Item(2, i).Value)
                Catch ex As Exception
                    db = 0
                End Try
                Try
                    cr = CDbl(grilla.Item(3, i).Value)
                Catch ex As Exception
                    cr = 0
                End Try
                sumadb = sumadb + db
                sumacr = sumacr + cr
            Next
            txtdb.Text = sumadb
            txtdb.Text = Moneda(txtdb.Text)
            txtcr.Text = sumacr
            txtcr.Text = Moneda(txtcr.Text)
            txtdif.Text = sumadb - sumacr
            txtdif.Text = Moneda(txtdif.Text)
            If (sumadb - sumacr) = 0 Then txtdif.Text = "0,00"
        Catch ex As Exception
            MsgBox("Error al sacar diferencia " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
        End Try
    End Sub
    Function GuardarCxP()

        Dim sw As Integer = 0 'bandera para la cta
        Dim cta As String = ""
        Dim tpuc As String = ""

        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT tipo FROM sae.companias WHERE login='" & FrmPrincipal.lbcompania.Text & "' ;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows(0).Item(0) = "comercial" Then
                tpuc = "2205*"
            Else
                tpuc = "24*"
            End If
        Catch ex As Exception
            tpuc = "2205*"
        End Try
        '  MsgBox(tpuc)

        For i = 0 To grilla.RowCount - 1
            Try
                'MsgBox(grilla.Item("Cuenta", i).Value.ToString)
                If grilla.Item("Cuenta", i).Value.ToString Like tpuc = True Then
                    cta = grilla.Item("Cuenta", i).Value.ToString
                    sw = 1
                    '  MsgBox(cta)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
        If sw = 0 Then
            Dim resultado As MsgBoxResult
            For i = 0 To grilla.RowCount - 1
                If Chcredito.Checked = True Then
                    Try
                        resultado = MsgBox("No ha seleccionado una cuenta de la " & tpuc.Replace("*", "").ToString & ", ¿Esta es su cuenta de Cuentas por Cobrar " & grilla.Item("Cuenta", i).Value.ToString & "?", MsgBoxStyle.YesNo, "Verificando")
                        If resultado = MsgBoxResult.Yes Then
                            cta = grilla.Item("Cuenta", i).Value.ToString
                            sw = 1
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

        If sw <> 0 Then
            Try
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?doc", PerActual & "-" & lbdoc.Text & txtnumero.Text)
                myCommand.Parameters.AddWithValue("?tipo", lbdoc.Text)
                myCommand.Parameters.AddWithValue("?num", Val(txtnumero.Text))
                myCommand.Parameters.AddWithValue("?doc_ext", "")
                myCommand.Parameters.AddWithValue("?descrip", "")
                myCommand.Parameters.AddWithValue("?tipafec", "")
                myCommand.Parameters.AddWithValue("?clasaju", "")
                myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
                myCommand.Parameters.AddWithValue("?nomnit", lbcliente.Text)
                myCommand.Parameters.AddWithValue("?nitcod", "")
                myCommand.Parameters.AddWithValue("?fecha", Strings.Right(txtperiodo.Text, 4) & "-" & Strings.Mid(txtperiodo.Text, 2, 2) & "-" & txtdia.Text)
                myCommand.Parameters.AddWithValue("?vmto", Val(30))
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text)
                myCommand.Parameters.AddWithValue("?subtotal", CDbl(txtvalor.Text))
                myCommand.Parameters.AddWithValue("?descto", CDbl(0))
                myCommand.Parameters.AddWithValue("?ret", CDbl(0))
                myCommand.Parameters.AddWithValue("?iva", DIN(0))
                myCommand.Parameters.AddWithValue("?v_viva", CDbl(0))
                myCommand.Parameters.AddWithValue("?total", CDbl(txtvalor.Text))
                myCommand.Parameters.AddWithValue("?ctasubtotal", cta)
                myCommand.Parameters.AddWithValue("?ctaret", "")
                myCommand.Parameters.AddWithValue("?ctaiva", "")
                myCommand.Parameters.AddWithValue("?ctatotal", cta)
                myCommand.Parameters.AddWithValue("?ccosto", "0")
                myCommand.Parameters.AddWithValue("?otroimp", "N")
                myCommand.Parameters.AddWithValue("?retiva", CDbl(0))
                myCommand.Parameters.AddWithValue("?ctaretiva", "")
                myCommand.Parameters.AddWithValue("?retica", CDbl(0))
                myCommand.Parameters.AddWithValue("?ctaretica", "")
                myCommand.Parameters.AddWithValue("?pagado", CDbl(0))
                myCommand.Parameters.AddWithValue("?rcpos", "")
                myCommand.Parameters.AddWithValue("?fechpos", "0000-00-00")
                myCommand.Parameters.AddWithValue("?vpos", CDbl(0))
                myCommand.Parameters.AddWithValue("?tasa", CDbl(0))
                myCommand.Parameters.AddWithValue("?moneda", "")
                myCommand.Parameters.AddWithValue("?monloex", "")
                myCommand.Parameters.AddWithValue("?estado", "AP")
                myCommand.Parameters.AddWithValue("?salmov", "")
                myCommand.Parameters.AddWithValue("?pagare", "")
                myCommand.CommandText = "INSERT INTO ctas_x_pagar  VALUES(" _
                    & "?doc,?tipo,?num,?doc_ext,?descrip,?tipafec,?clasaju,?nitc,?nomnit,?nitcod,?fecha,?vmto,?concepto,?subtotal," _
                    & "?descto,?ret,?iva,?v_viva,?total,?ctasubtotal,?ctaret,?ctaiva,?ctatotal,?ccosto,?otroimp,?retiva," _
                    & "?ctaretiva,?retica,?ctaretica,?pagado,?rcpos,?fechpos,?vpos,?tasa,?moneda,?monloex,?estado,?salmov,?pagare " _
                    & ");"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
            Catch ex As Exception
            End Try
        End If
        Return sw
    End Function
    Function GuardarAnticipo()
        Dim sw As Integer = 0 'bandera para la cta
        Dim cta As String = ""
        Dim fl As Integer = 0
        Try
            For i = 0 To grilla.RowCount - 1
                Try
                    If grilla.Item("Cuenta", i).Value.ToString Like "1330*" = True Then
                        cta = grilla.Item("Cuenta", i).Value.ToString
                        fl = i
                        sw = 1
                        'MsgBox(cta)
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            If sw = 0 Then
                Dim resultado As MsgBoxResult
                For i = 0 To grilla.RowCount - 1
                    Try
                        If ChAnti.Checked = True Then
                            resultado = MsgBox("No ha seleccionado una cuenta de la 1330, ¿esta es su cuenta de anticipos " & grilla.Item("Cuenta", i).Value.ToString & "?", MsgBoxStyle.YesNo, "Verificando")
                            If resultado = MsgBoxResult.Yes Then
                                cta = grilla.Item("Cuenta", i).Value.ToString
                                fl = i
                                sw = 1
                                Exit For
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If
            If sw <> 0 Then
                Dim Sql As String = "DELETE FROM ant_a_prov WHERE per_doc='" & PerActual & "-" & lbdoc.Text & txtnumero.Text & "';"
                Ejecutar(Sql)
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?per_doc", PerActual & "-" & lbdoc.Text & txtnumero.Text)
                myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text)
                myCommand.Parameters.AddWithValue("?per", PerActual)
                Try
                    myCommand.Parameters.AddWithValue("?fecha", CDate(txtdia.Text & "/" & PerActual))
                Catch ex As Exception
                    myCommand.Parameters.AddWithValue("?fecha", txtdia.Text & "/" & PerActual)
                End Try
                myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
                myCommand.Parameters.AddWithValue("?monto", DIN(Moneda(grilla.Item("Debitos", fl).Value.ToString)))
                myCommand.Parameters.AddWithValue("?causado", DIN("0"))
                myCommand.Parameters.AddWithValue("?cta", cta)
                myCommand.Parameters.AddWithValue("?user", FrmPrincipal.lbuser.Text.ToString)
                myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text)
                myCommand.CommandText = "INSERT INTO ant_a_prov VALUES(" _
                & "?per_doc,?doc,?per,?fecha,?nitc,?monto,?causado,?cta,?user,NOW(),?concepto" _
                & ");"
                myCommand.ExecuteNonQuery()
                myCommand.Parameters.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return sw
    End Function
    
    Public Sub CmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelar.Click
        Try
            If lbestado.Text <> "CONSULTA" Then
                CmdPrimero_Click(AcceptButton, AcceptButton)
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "SAE Control")
        End Try
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
                If PerBloq() = False Then Exit Sub
                If Trim(lbanulado.Text) <> "" Then
                    MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                    Exit Sub
                End If
                If tra_con <> "E" Then
                    MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                    Exit Sub
                End If
                DesBloquear()
                grilla.ReadOnly = False
                txtnumero.ReadOnly = True
                lbestado.Text = "EDITAR"
                grilla.Item(0, 0).Selected = True
                grilla.Focus()
                If txtcentro.Enabled = True Then
                    txtcentro.Focus()
                Else
                    txtciudad.Focus()
                End If
            Else
                MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CmdEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEliminar.Click
        If tra_con <> "E" Then
            MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
            Exit Sub
        End If
    End Sub
    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdprint.Click
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Or lbestado.Text = "NULO" Then
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        Else
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Desea imprimir con el formato de cheque?", MsgBoxStyle.YesNo, "Verificando")
            If FrmPrincipal.cmdOrden.Visible = False Then
                If resultado = MsgBoxResult.Yes Then
                    GenerarPDFCheque()
                Else
                    GenerarPDF()
                End If
            Else
                If resultado = MsgBoxResult.Yes Then
                    GenerarNPDF("S")
                Else
                    GenerarNPDF("n")
                End If
            End If
        End If
    End Sub
    Private Sub CmdMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMostrar.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" And lbestado.Text <> "NULO" Then
            If PerBloq() = False Then Exit Sub
            If Trim(lbanulado.Text) <> "" Then
                MsgBox("El documento fué " & lbanulado.Text & ".   ", MsgBoxStyle.Information, "Verificando")
                Exit Sub
            End If
            If tra_con <> "E" Then
                MsgBox("No tienes permisos para esta operaión.   ", MsgBoxStyle.Information, "SAE Control")
                Exit Sub
            End If
            FrmAnularOtDoc.lbcompa.Text = lbcompa.Text
            FrmAnularOtDoc.lbnit.Text = lbnit.Text
            FrmAnularOtDoc.txtcentro.Text = txtcentro.Text
            FrmAnularOtDoc.txtncentro.Text = txtncentro.Text
            FrmAnularOtDoc.txttipo.Text = lbdoc.Text
            FrmAnularOtDoc.txttipo2.Text = lbnomdoc.Text
            FrmAnularOtDoc.txtnumfac.Text = txtnumero.Text
            FrmAnularOtDoc.lbper_a.Text = "del " & PerActual
            Try
                FrmAnularOtDoc.txtfecha.Text = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
            End Try
            FrmAnularOtDoc.txtfecha_ana.Text = Today
            FrmAnularOtDoc.lbcliente.Text = lbcliente.Text
            FrmAnularOtDoc.lbform.Text = "ci"
            FrmAnularOtDoc.ShowDialog()
        Else
            MsgBox("El estado " & lbestado.Text & " del registro no permite esta acción, Verifique.   ", MsgBoxStyle.Information, "Verificando")
        End If
    End Sub
    Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
        lbcontr.Text = ""
        Me.Close()
    End Sub
    '************************************
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        Try
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE' ORDER BY doc, item LIMIT 0, 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                CmdNuevo.Focus()
            Else
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                SacarCuenta()
                lbnroobs.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            PonerEnCero()
        End Try
    End Sub
    Private Sub CmdAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAtras.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            i = Val(lbnroobs.Text) - 1
            If i > 0 Then
                i = i - 1
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE' ORDER BY doc, item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                SacarCuenta()
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSiguiente.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i, ult As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            ult = tabla2.Rows.Count - 1
            i = Val(lbnroobs.Text) - 1
            If i < ult Then
                i = i + 1
                myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE' ORDER BY doc, item LIMIT " & i & ", 1;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                BuscarDocumento(tabla.Rows(0).Item(0))
                SacarCuenta()
                lbnroobs.Text = i + 1
            End If
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Private Sub CmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdUltimo.Click
        Try
            BuscarPeriodo()
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim i As Integer
            Dim tabla, tabla2 As New DataTable
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla2)
            Refresh()
            i = tabla2.Rows.Count - 1
            myCommand.CommandText = "SELECT DISTINCT(doc) FROM " & mes & " WHERE grupo='CE' ORDER BY doc, item LIMIT " & i & ", 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            BuscarDocumento(tabla.Rows(0).Item(0))
            SacarCuenta()
            lbnroobs.Text = i + 1
        Catch ex As Exception
            CmdPrimero_Click(AcceptButton, AcceptButton)
        End Try
    End Sub
    Public Sub BuscarDocumento(ByVal doc As String)
        Try
            Dim mes As String = "ot_doc" & PerActual(0) & PerActual(1)
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM " & mes & " WHERE doc='" & doc & "' ORDER BY item;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            If tabla.Rows.Count = 0 Then
                PonerEnCero()
                CmdNuevo.Focus()
            Else
                Refresh()
                '----- INMOBILIARIA
                If tabla.Rows(0).Item("cod_contra").ToString = "SI" Then
                    ChAnti.Checked = True
                Else
                    ChAnti.Checked = False
                End If
                '-----------
                txtcentro.Text = tabla.Rows(0).Item("ccosto")
                txtncentro.Text = ""
                If tabla.Rows(0).Item("ccosto").ToString <> "0" Then BuscarCC()
                lbdoc.Text = tabla.Rows(0).Item("tipo")
                txtnumero.Text = NumeroDoc(tabla.Rows(0).Item("num"))
                txtciudad.Text = tabla.Rows(0).Item("ciudad")
                txtdia.Text = tabla.Rows(0).Item("dia")
                Try
                    Dim f As Date = CDate(txtdia.Text & txtperiodo.Text)
                Catch ex As Exception
                    txtdia.Text = "01"
                End Try
                txtvalor.Text = Moneda(tabla.Rows(0).Item("total"))
                txtvalor_LostFocus(AcceptButton, AcceptButton)
                lbcliente.Text = ""
                txtconcepto.Text = tabla.Rows(0).Item("concepto")
                grilla.Rows.Clear()
                txtcheque.Text = tabla.Rows(0).Item("cheque")
                txtbanco.Text = tabla.Rows(0).Item("banco")
                txtsucursal.Text = tabla.Rows(0).Item("sucursal")
                If tabla.Rows(0).Item("efectivo") = "S" Then
                    chefectivo.Checked = True
                    Chcredito.Checked = False
                ElseIf tabla.Rows(0).Item("efectivo") = "N" Then
                    chefectivo.Checked = False
                    Chcredito.Checked = False
                Else
                    chefectivo.Checked = False
                    Chcredito.Checked = True
                End If
                txtnit.Text = tabla.Rows(0).Item("nitc")
                Try
                    If tabla.Rows(0).Item("tn") = "CC" Then
                        rbcc.Checked = True
                    Else
                        rbnit.Checked = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    rbnit.Checked = True
                End Try
                txtnit_LostFocus(AcceptButton, AcceptButton)
                txtelaborado.Text = tabla.Rows(0).Item("elaborado")
                txtaprobado.Text = tabla.Rows(0).Item("autorizado")
                txtconta.Text = tabla.Rows(0).Item("contabilizado")
                Try
                    lbanulado.Text = tabla.Rows(0).Item("doc_aj")
                Catch ex As Exception
                    lbanulado.Text = ""
                End Try
                fecha.Value = CDate(tabla.Rows(0).Item("fecha").ToString)
                grilla.RowCount = tabla.Rows.Count + 1
                For i = 0 To tabla.Rows.Count - 1
                    grilla.Item(0, i).Value = tabla.Rows(i).Item("codigo")
                    grilla.Item(1, i).Value = tabla.Rows(i).Item("descrip")
                    grilla.Item(2, i).Value = Moneda(tabla.Rows(i).Item("debito"))
                    grilla.Item(3, i).Value = Moneda(tabla.Rows(i).Item("credito"))
                    grilla.Item(4, i).Value = Moneda(tabla.Rows(i).Item("base"))
                    grilla.Item(5, i).Value = tabla.Rows(i).Item("ccosto")
                Next
                '***********************************************************
                Dim t2 As New DataTable
                myCommand.CommandText = "SELECT item, codigo, nit FROM documentos" & PerActual(0) & PerActual(1) & " WHERE tipodoc='" & lbdoc.Text & "' AND doc='" & Val(txtnumero.Text) & "' order by item;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(t2)
                If t2.Rows.Count > 0 Then
                    For i = 0 To t2.Rows.Count - 1
                        grilla.Item(6, i).Value = t2.Rows(i).Item("nit")
                    Next
                End If
                '***********************************************************
                Dim tabla2 As New DataTable
                myCommand.CommandText = "SELECT descripcion FROM tipdoc WHERE tipodoc='" & lbdoc.Text & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla2)
                If tabla2.Rows.Count > 0 Then
                    lbnomdoc.Text = tabla2.Rows(0).Item("descripcion").ToString
                End If
                BuscarObserv()
                Bloquear()
                lbestado.Text = "CONSULTA"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub BuscarObserv()
        Try
            Dim t2 As New DataTable
            myCommand.CommandText = "SELECT * FROM `obsdocumentos" & Strings.Left(PerActual, 2) & "`  WHERE doc='" & Val(txtnumero.Text) & "' and tipodoc= '" & lbdoc.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t2)
            If t2.Rows.Count > 0 Then
                txtdetall.Text = t2.Rows(0).Item("comentario").ToString
            Else
                txtdetall.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    '******************************************
    Private Sub txtcentro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcentro.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarnumero(txtcentro, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtcentro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcentro.LostFocus
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        BuscarCC()
    End Sub
    Public Sub BuscarCC()
        Try
            Dim t As New DataTable
            myCommand.CommandText = "SELECT ccosto FROM parcontab;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t)
            If t.Rows(0).Item("ccosto") <> "S" Then Exit Sub
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & txtcentro.Text & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            txtncentro.Text = ""
            If tabla.Rows.Count > 0 Then
                txtncentro.Text = tabla.Rows(0).Item("nombre")
            Else
                FrmSelCentroCostos.txtcuenta.Text = txtcentro.Text
                FrmSelCentroCostos.lbform.Text = "comproEg"
                FrmSelCentroCostos.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtdia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdia.KeyPress
        If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            If e.KeyChar = Chr(Keys.Enter) Then
                SendKeys.Send("{TAB}")
            Else
                validarnumero(txtdia, e)
            End If
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtdia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdia.LostFocus
        Try
            Dim mifec As Date
            mifec = txtdia.Text & txtperiodo.Text
            Try
                fecha.Value = CDate(txtdia.Text & txtperiodo.Text)
            Catch ex As Exception
                fecha.Value = Today
            End Try
        Catch ex As Exception
            MsgBox("Error en el formato de la fecha, Verifique el día.  ", MsgBoxStyle.Information, "Verificación")
            txtdia.Focus()
        End Try
    End Sub

    Private Sub txtciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtciudad.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                validarletra(txtciudad, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvalor.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarMoneda(txtvalor, e)
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtvalor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvalor.LostFocus
        txtvalor.Text = Moneda(txtvalor.Text)
        lbsuma.Text = "SON " & Num2Text(txtvalor.Text)
    End Sub
    Private Sub txtconcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconcepto.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
           
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcheque.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtbanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanco.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtsucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsucursal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chefectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chefectivo.CheckedChanged
        If chefectivo.Checked = True Then
            txtcheque.Enabled = False
            txtbanco.Enabled = False
            txtsucursal.Enabled = False
            txtnit.Focus()
            Chcredito.Checked = False
        Else
            txtcheque.Enabled = True
            txtbanco.Enabled = True
            txtsucursal.Enabled = True
            txtcheque.Focus()
            Chcredito.Checked = False
        End If

    End Sub

    Private Sub txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnit.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
                ValidarNIT(txtnit, e)
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnit.LostFocus
        If txtnit.Text = "" Then
            If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
            lbcliente.Text = ""
            cargarclientes()
        Else
            BuscarClientes(txtnit.Text)
        End If
    End Sub
    Public Sub cargarclientes()
        Try
            FrmSelCliente.lbform.Text = "comproEg"
            FrmSelCliente.ShowDialog()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub BuscarClientes(ByVal nit As String)
        Dim items As Integer
        Dim tabla, tabla2 As New DataTable
        myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & nit & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        If items = 0 Then
            lbcliente.Text = ""
            Dim resultado As MsgBoxResult
            resultado = MsgBox("El nit/cédula del cliente no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
            If resultado = MsgBoxResult.Yes Then
                frmterceros.txtnit.Text = txtnit.Text
                LimpiarTerceros()
                frmterceros.cbtipo.Text = "CLIENTES"
                frmterceros.lbform.Text = "comproEg"
                frmterceros.rbnatural.Checked = True
                frmterceros.txtnit.Focus()
                frmterceros.ShowDialog()
                txtconcepto.Focus()
            End If
        Else  'mostrar uno solo q coinside
            lbcliente.Text = Trim(tabla.Rows(0).Item("apellidos") & " " & tabla.Rows(0).Item("nombre"))
        End If
    End Sub
    Private Sub txtnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnit.TextChanged
        If rbnit.Checked = True Then
            txtdv.Text = "-" & DigitoNIT(txtnit.Text)
        Else
            txtdv.Text = ""
        End If
    End Sub
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        txtdv.Text = ""
        txtnit.Focus()
    End Sub
    Private Sub rbnit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnit.CheckedChanged
        txtdv.Text = "-" & DigitoNIT(txtnit.Text)
        txtnit.Focus()
    End Sub

    Private Sub fecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fecha.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtelaborado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtelaborado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtaprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtconta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grilla_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grilla.CellBeginEdit
        FinEdit = 1
    End Sub
    Private Sub grilla_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grilla.CellValidating
        If FinEdit = 1 Then
            FinEdit = 0
            SendKeys.Send(Chr(Keys.Tab))
            e.Cancel = True
        End If
    End Sub
    Private Sub grilla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEnter
        fila = e.RowIndex
        col = e.ColumnIndex
        BuscarNomTer(fila)
        Try
            Select Case e.ColumnIndex
                Case 2  'CASO DEBITO 
                Case 3  'CASO CREDITO                     
                Case 0 'CASO CUENTA 
                    If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
                Case 6
                    If grilla.Item(3, e.RowIndex).Value <> "" Or grilla.Item(0, e.RowIndex).Value = "" Then Exit Sub
                    SendKeys.Send(Chr(Keys.Space))
                    SendKeys.Send(Chr(Keys.Back))
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grilla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellEndEdit
        Try
            If e.RowIndex > 0 And UCase(grilla.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "FF" Then
                grilla.Item(e.ColumnIndex, e.RowIndex).Value = grilla.Item(e.ColumnIndex, e.RowIndex - 1).Value
                ValoresDefecto(e.RowIndex)
                SacarCuenta()
                Exit Sub
            End If
            Select Case e.ColumnIndex
                Case 1  'CASO DESCRIPCION                       
                    grilla.Item(1, e.RowIndex).Value = UCase(grilla.Item(1, e.RowIndex).Value)
                Case 2  'CASO DEBITO                    
                    grilla.Item(2, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(2, e.RowIndex).Value.ToString), 2)
                    If grilla.Item(2, e.RowIndex).Value > 0 Then SendKeys.Send(Chr(Keys.Tab))
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO 
                    If CDbl(grilla.Item(3, e.RowIndex).Value) = 0 Then
                        grilla.Item(3, e.RowIndex).Value = "0,00"
                    Else
                        grilla.Item(3, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(3, e.RowIndex).Value.ToString), 2)
                        grilla.Item(2, e.RowIndex).Value = "0,00"
                    End If
                Case 4  'CASO BASE 
                    grilla.Item(4, e.RowIndex).Value = Math.Round(CDbl(grilla.Item(4, e.RowIndex).Value.ToString), 2)
                Case 5  'CASO CCOSTO
                    Buscarcco(grilla.Item("cc", e.RowIndex).Value, e.RowIndex)
                Case 0 'CASO CUENTA
                    Buscarcuentas(grilla.Item(0, e.RowIndex).Value, e.RowIndex)
                Case 6
                    Buscartercero(grilla.Item(6, e.RowIndex).Value, e.RowIndex)
            End Select
        Catch ex As Exception
            Select Case e.ColumnIndex

                Case 2 'CASO DEBITO
                    If grilla.Item(2, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor debito, Verifique. " & grilla.Item(2, e.RowIndex).Value, MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(2, e.RowIndex).Value = "0,00"
                Case 3  'CASO CREDITO  
                    If grilla.Item(3, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor credito, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(3, e.RowIndex).Value = "0,00"
                Case 4 'CASO BASE 
                    If grilla.Item(4, e.RowIndex).Value <> "" Then
                        MsgBox("Error al digitar el valor de la base, Verifique. ", MsgBoxStyle.Critical, "SAE Verificación")
                    End If
                    grilla.Item(4, e.RowIndex).Value = "0,00"
                Case 5 'CASO CCOSTO
                    grilla.Item("cc", e.RowIndex).Value = ""
                    Buscarcco("", e.RowIndex)
                Case 0  'CASO CUENTA    
                    'MsgBox("Error al digitar la cuenta. " & ex.ToString, MsgBoxStyle.Critical, "SAE Verificación")
                    grilla.Item(0, e.RowIndex).Value = ""
                    Buscarcuentas("", e.RowIndex)
                Case 6
                    grilla.Item(6, e.RowIndex).Value = ""
                    Buscartercero("", e.RowIndex)
            End Select
        End Try
        ValoresDefecto(e.RowIndex)
        SacarCuenta()
    End Sub
    Public Sub ValoresDefecto(ByVal i)
        Try
            If grilla.Item(2, i).Value.ToString = "" Then
                grilla.Item(2, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(2, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(3, i).Value.ToString = "" Then
                grilla.Item(3, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(3, i).Value = "0,00"
        End Try
        Try
            If grilla.Item(4, i).Value.ToString = "" Then
                grilla.Item(4, i).Value = "0,00"
            End If
        Catch ex As Exception
            grilla.Item(4, i).Value = "0,00"
        End Try
    End Sub
    Private Sub Buscartercero(ByVal ter As String, ByVal fila As Integer)
        Try
            If Trim(ter) = "" Then
                FrmSelCliente.lbform.Text = "Gce"
                FrmSelCliente.lbfila.Text = fila
                FrmSelCliente.ShowDialog()
            Else
                Dim items As Integer
                Dim tabla, tabla2 As New DataTable
                myCommand.CommandText = "SELECT * FROM terceros WHERE nit ='" & Trim(ter) & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Refresh()
                items = tabla.Rows.Count
                If items = 0 Then
                    Dim resultado As MsgBoxResult
                    resultado = MsgBox("El nit/cédula " & ter & " del tercero no existe en los registros, ¿Desea Agregarlos?", MsgBoxStyle.YesNo, "Verificando")
                    If resultado = MsgBoxResult.Yes Then
                        frmterceros.txtnit.Text = Trim(ter)
                        grilla.Item(6, fila).Value = ""
                        LimpiarTerceros()
                        frmterceros.lbestado.Text = "NUEVO"
                        frmterceros.cbtipo.Text = "CLIENTES"
                        frmterceros.lbform.Text = "Gce"
                        frmterceros.lbfila.Text = fila
                        frmterceros.txtnit.Focus()
                        frmterceros.ShowDialog()
                    Else
                        MsgBox("No se asigno ningún nit...", MsgBoxStyle.Information, "SAE Información")
                        grilla.Item(6, fila).Value = ""
                    End If
                Else

                    grilla.Item(6, fila).Value = Trim(ter)
                End If
            End If
           
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BuscarNomTer(ByVal f As Integer)
        Try
            Dim tabla As New DataTable
            myCommand.CommandText = "SELECT TRIM(CONCAT(nombre,' ',apellidos)) AS ape FROM terceros WHERE nit='" & grilla.Item(6, f).Value.ToString & "';"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            lbcta.Text = tabla.Rows(0).Item("ape").ToString
        Catch ex As Exception
            'MsgBox(ex.ToString)
            'txtnit.Text = ""
            lbcta.Text = ""
        End Try
    End Sub
    Public Sub Buscarcuentas(ByVal cuenta As String, ByVal fila As Integer)
        Try
            If cuenta = "" Then
                FrmCuentas.lbform.Text = "comproEg"
                FrmCuentas.lbfila.Text = fila
                FrmCuentas.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM selpuc WHERE codigo ='" & cuenta & "' AND nivel='Auxiliar';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count <= 0 Then
                    grilla.Item(0, fila).Value = ""
                    FrmCuentas.txtcuenta.Text = cuenta
                    FrmCuentas.lbform.Text = "comproEg"
                    FrmCuentas.lbfila.Text = fila
                    If cuenta <> "" Then
                        FrmCuentas.ok_Click(AcceptButton, AcceptButton)
                    End If
                    FrmCuentas.ShowDialog()
                Else
                    grilla.Item(0, fila).Value = cuenta
                    grilla.Item(1, fila).Value = tabla.Rows(0).Item("descripcion")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Buscarcco(ByVal ccosto As String, ByVal fila As Integer)
        Try
            If ccosto = "" Then
                FrmSelCentroCostos.lbform.Text = "comproEgG"
                FrmSelCentroCostos.lbfila.Text = fila
                FrmSelCentroCostos.ShowDialog()
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT * FROM centrocostos WHERE centro='" & ccosto & "';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows.Count = 0 Then
                    grilla.Item("cc", fila).Value = ""
                    FrmSelCentroCostos.txtcuenta.Text = ccosto
                    FrmSelCentroCostos.lbform.Text = "comproEgG"
                    FrmSelCentroCostos.lbfila.Text = fila
                    FrmSelCentroCostos.ShowDialog()
                Else
                    grilla.Item("cc", fila).Value = ccosto
                End If
            End If
        Catch ex As Exception
            '  txtnomcc.Text = ""
        End Try
    End Sub

    Private Sub grilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grilla.KeyDown
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If e.KeyCode = 8 Then
            If fila = grilla.RowCount - 1 Then Exit Sub
            QuitarFila(fila)
        ElseIf e.KeyCode = "13" Then
            e.Handled = True
            SendKeys.Send(Chr(Keys.Tab))
        End If
    End Sub
    Public Sub QuitarFila(ByVal f As Integer)
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        If fila = grilla.RowCount - 1 Then Exit Sub
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Toda la fila será retirada, ¿Desea Quitarla?", MsgBoxStyle.YesNo, "SAE Quitar Fila")
        If resultado = MsgBoxResult.Yes Then
            grilla.Rows.RemoveAt(fila)
        End If
    End Sub
    '///////////////////////////////////////////////////////////////
    Function ValidarGuardar()
        SacarCuenta()
        Try
            Dim fec As Date
            fec = CDate(txtdia.Text & txtperiodo.Text)
        Catch ex As Exception
            MsgBox("El dia no coincide con un formato de fecha correcto, Verifique.  ", MsgBoxStyle.Information, "SAE Control")
            txtdia.Focus()
            Return False
            Exit Function
        End Try

        If lbcontr.Text <> "" Then
            If txtcodCon.Text = "" Then
                MsgBox("No ha digitado el codigo del contrato, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                txtcodCon.Focus()
                Return False
                Exit Function
            End If
        End If
        If txtcentro.Enabled = True And txtncentro.Text = "" Then
            MsgBox("No ha digitado centro de costos, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtncentro.Focus()
            Return False
            Exit Function
        ElseIf txtvalor.Text = "0,00" Then
            MsgBox("No ha digitado el campo valor, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtvalor.Focus()
            Return False
            Exit Function
        ElseIf lbcliente.Text = "" Then
            MsgBox("No ha digitado datos del cliente, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            txtnit.Focus()
            Return False
            Exit Function
        ElseIf Chcredito.Checked = False Then
            If chefectivo.Checked = False Then
                If txtcheque.Text = "" Then
                    MsgBox("No ha digitado el numero del cheque, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                    txtcheque.Focus()
                    Return False
                    Exit Function
                ElseIf Trim(txtbanco.Text) = "" Then
                    MsgBox("No ha digitado el campo banco, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                    txtbanco.Focus()
                    Return False
                    Exit Function
                ElseIf Trim(txtsucursal.Text) = "" Then
                    MsgBox("No ha digitado el campo sucursal, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
                    txtsucursal.Focus()
                    Return False
                    Exit Function
                End If
            End If
            'ElseIf chefectivo.Checked = False Then
            '    If txtcheque.Text = "" Then
            '        MsgBox("No ha digitado el numero del cheque, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            '        txtcheque.Focus()
            '        Return False
            '        Exit Function
            '    ElseIf Trim(txtbanco.Text) = "" Then
            '        MsgBox("No ha digitado el campo banco, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            '        txtbanco.Focus()
            '        Return False
            '        Exit Function
            '    ElseIf Trim(txtsucursal.Text) = "" Then
            '        MsgBox("No ha digitado el campo sucursal, Verifique.  ", MsgBoxStyle.Information, "SAE Control ")
            '        txtsucursal.Focus()
            '        Return False
            '        Exit Function
            '    End If
        End If
        If CDec(txtdif.Text) <> 0 Then
            MsgBox("Favor verifique los items del documento la diferencia no puede ser distinta de cero(0)...", MsgBoxStyle.Information, "SAE Verificación")
            grilla.Focus()
            Return False
            Exit Function
        ElseIf CDec(txtdb.Text) = 0 Then
            MsgBox("Favor verifique los items del documento no digitado ningun debito...", MsgBoxStyle.Information, "SAE Verificación")
            txtdb.Focus()
            Return False
            Exit Function
        ElseIf CDec(txtcr.Text) = 0 Then
            MsgBox("Favor verifique los items del documento no digitado ningun credito...", MsgBoxStyle.Information, "SAE Verificación")
            txtcr.Focus()
            Return False
            Exit Function
        End If
        If grilla.RowCount < 2 Then
            MsgBox("Verifique los campos de contabilización.  ", MsgBoxStyle.Information, "SAE Control ")
            grilla.Focus()
            Return False
            Exit Function
        Else
            Dim db, cr As Double
            Dim sdb As Double = 0
            Dim scr As Double = 0
            For i = 0 To grilla.RowCount - 1
                If grilla.Item("Cuenta", i).Value <> "" Then
                    Try
                        db = CDbl(grilla.Item("Debitos", i).Value)
                    Catch ex As Exception
                        db = 0
                    End Try
                    sdb = sdb + db
                    Try
                        cr = CDbl(grilla.Item("Creditos", i).Value)
                    Catch ex As Exception
                        cr = 0
                    End Try
                    scr = scr + cr
                End If
            Next
            If sdb = 0 Or scr = 0 Then
                MsgBox("Verifique los campos Debitos y Créditos.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
            ElseIf sdb <> scr Then
                MsgBox("Debitos(" & Moneda(sdb) & ") <> Créditos(" & Moneda(scr) & "); Las sumas deben ser iguales.  ", MsgBoxStyle.Information, "SAE Control ")
                grilla.Focus()
                Return False
                Exit Function
                'ElseIf scr <> CDbl(txtvalor.Text) Then
                '    MsgBox("El valor del documento no coincide con los movimientos ", MsgBoxStyle.Information, "SAE Control ")
                '    txtvalor.Focus()
                '    Return False
                '    Exit Function
            End If
        End If
        Return True
    End Function
    Private Sub AuditoriaCE()
        If FrmPrincipal.cmdAuditoria.Visible = True Then
            Dim en As String = "N"
            For i = 0 To grilla.RowCount - 1
                If grilla.Item("Cuenta", i).Value <> "" Then
                    If grilla.Item("Creditos", i).Value.ToString <> Moneda(0) Then
                        If chefectivo.Checked = True Then
                            If Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "cs") = "y" Then
                                en = "S"
                                Exit For
                            End If
                        ElseIf Chcredito.Checked = True Then
                            If Vali_cuent_Odoc("cxc", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "cs") = "y" Then
                                en = "S"
                                Exit For
                            End If
                        Else
                            If Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "cs") = "y" Then
                                en = "S"
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
            If en = "N" Then
                If chefectivo.Checked = True Then
                    For i = 0 To grilla.RowCount - 1
                        If grilla.Item("Cuenta", i).Value <> "" Then
                            If grilla.Item("Creditos", i).Value.ToString <> Moneda(0) Then
                                Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                            End If
                        End If
                    Next
                ElseIf Chcredito.Checked = True Then
                    For i = 0 To grilla.RowCount - 1
                        If grilla.Item("Cuenta", i).Value <> "" Then
                            If grilla.Item("Creditos", i).Value.ToString <> Moneda(0) Then
                                Vali_cuent_Odoc("cxc", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                            End If
                        End If
                    Next
                Else
                    For i = 0 To grilla.RowCount - 1
                        If grilla.Item("Cuenta", i).Value <> "" Then
                            If grilla.Item("Creditos", i).Value.ToString <> Moneda(0) Then
                                Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text, "")
                            End If
                        End If
                    Next
                End If
            End If


            ''/////////////////////
            'For i = 0 To grilla.RowCount - 1
            '    If grilla.Item("Cuenta", i).Value <> "" Then
            '        If grilla.Item("Creditos", i).Value.ToString <> Moneda(0) Then
            '            If chefectivo.Checked = True Then
            '                Vali_cuent_Odoc("caj", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text)
            '            ElseIf Chcredito.Checked = True Then
            '                Vali_cuent_Odoc("cxc", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text)
            '            Else
            '                Vali_cuent_Odoc("ban", lbdoc.Text & "-" & lbnomdoc.Text, grilla.Item("Cuenta", i).Value.ToString, lbdoc.Text & txtnumero.Text & "-" & lbper.Text)
            '            End If
            '        End If
            '    End If
            'Next
            ''////////////////////////
        End If
    End Sub
    Public Sub Guardar(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", lbdoc.Text & txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?grupo", "CE")
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?num", Val(txtnumero.Text.ToString))
        myCommand.Parameters.AddWithValue("?doc_afec", "")
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?ciudad", txtciudad.Text.ToString)
        myCommand.Parameters.AddWithValue("?concepto", txtconcepto.Text.ToString)
        myCommand.Parameters.AddWithValue("?nitc", txtnit.Text)
        If rbcc.Checked = True Then
            myCommand.Parameters.AddWithValue("?tn", "CC")
        Else
            myCommand.Parameters.AddWithValue("?tn", "NIT")
        End If
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 99))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?total", DIN(txtvalor.Text).ToString)
        If Chcredito.Checked = True Then
            myCommand.Parameters.AddWithValue("?efectivo", "C")
            myCommand.Parameters.AddWithValue("?cheque", "")
            myCommand.Parameters.AddWithValue("?banco", "")
            myCommand.Parameters.AddWithValue("?sucursal", "")
        Else
            If chefectivo.Checked = True Then
                myCommand.Parameters.AddWithValue("?efectivo", "S")
                myCommand.Parameters.AddWithValue("?cheque", "")
                myCommand.Parameters.AddWithValue("?banco", "")
                myCommand.Parameters.AddWithValue("?sucursal", "")
            Else
                myCommand.Parameters.AddWithValue("?efectivo", "N")
                myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
                myCommand.Parameters.AddWithValue("?banco", txtbanco.Text)
                myCommand.Parameters.AddWithValue("?sucursal", txtsucursal.Text)
            End If
        End If
        '*********************************************************
        '  myCommand.Parameters.AddWithValue("?ccosto", txtcentro.Text)
        If grilla.Item("cc", fila).Value <> "" Then
            myCommand.Parameters.AddWithValue("?ccosto", grilla.Item("cc", fila).Value.ToString)
        Else
            myCommand.Parameters.AddWithValue("?ccosto", txtcentro.Text)
        End If
        myCommand.Parameters.AddWithValue("?fecha", fecha.Value)
        myCommand.Parameters.AddWithValue("?elaborado", CambiaCadena(txtelaborado.Text, 50))
        myCommand.Parameters.AddWithValue("?autorizado", CambiaCadena(txtaprobado.Text, 50))
        myCommand.Parameters.AddWithValue("?revisado", "")
        myCommand.Parameters.AddWithValue("?contabilizado", CambiaCadena(txtconta.Text, 50))
        myCommand.Parameters.AddWithValue("?doc_aj", " ")
        If ChAnti.Checked = True Then
            myCommand.Parameters.AddWithValue("?cont", "SI")
        Else
            myCommand.Parameters.AddWithValue("?cont", " ")
        End If

        myCommand.CommandText = "INSERT INTO ot_doc" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?grupo,?tipodoc,?num,?doc_afec,?dia,?periodo,?ciudad,?concepto,?nitc,?tn,?codigo,?desc,?debito,?credito,?base,?total,?efectivo,?cheque,?banco,?sucursal,?ccosto,?fecha,?elaborado,?autorizado,?revisado,?contabilizado,?doc_aj,?cont);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Private Sub GuardarPresupuesto(ByVal fila As Integer)

        If grilla.Item(0, fila).Value.ToString Like 4 & "*" Then

            Dim pbd As String = "presupuesto" & Strings.Right(PerActual, 4)
            Dim cta As String = ""
            Dim ing As String = ""
            Dim val As Double = 0
            If Len(txtdia.Text) = 1 Then txtdia.Text = "0" & txtdia.Text
            Dim f As String = Strings.Right(txtperiodo.Text, 4) & Strings.Mid(txtperiodo.Text, 2, 2) & txtdia.Text

            cta = grilla.Item(0, fila).Value.ToString
            val = grilla.Item(3, fila).Value.ToString

            Dim tp As New DataTable
            tp.Clear()
            myCommand.CommandText = "SELECT MIN(c.ingc_nums), v.ingv_cod1 FROM " & pbd & ".ingvalores v, " & pbd & ".ingconcepto c  " _
            & " WHERE v.ingv_contrac='" & cta & "' AND c.ingc_sd='D' AND c.ingc_cod1= v.ingv_cod1 GROUP BY ingc_nivel ORDER BY c.ingc_nums LIMIT 1;"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tp)
            If tp.Rows.Count = 0 Then Exit Sub

            ing = tp.Rows(0).Item(1)

            Try
                'Guardar MovIng
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO " & pbd & ".`movingresos`(movi_rubro,movi_fecha, movi_vigencia, " _
                                & "movi_aumento, movi_reduccion, movi_credito, movi_contra, " _
                                & "movi_aplaza,movi_desaplaza,movi_recaudo,movi_reconoce) " _
                                & "VALUES ('" & ing & "', " & f & "," & Strings.Right(PerActual, 4) & ", " _
                                & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ", '" & lbper.Text & lbdoc.Text & txtnumero.Text & "' )"
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                myCommand.Parameters.Clear()
                myCommand.CommandText = "INSERT INTO  " & pbd & ".`recaudos` (  `rec_fecha` ,  `rec_rubro` ,  `rec_descripcion` , " _
               & " `rec_valor` ,  `rec_vigencia` ,  `rec_cuenta` ,  `rec_ctabanc` ,  `rec_nrofactura` ,  `rec_modulo` ,  `rec_nrodoc` ,  " _
               & " `rec_tercero` ,  `rec_fechor` ,  `rec_user` )  VALUES (" _
               & "   " & f & ", '" & ing & "',  'RECAUDO POR " & lbper.Text & lbdoc.Text & txtnumero.Text & "', " & DIN(val) & ", " & Strings.Right(PerActual, 4) & ",  '1', " _
               & " '',  '',  'sae_ce', '" & lbper.Text & lbdoc.Text & txtnumero.Text & "', '" & txtnit.Text & "',NOW(),  '" & FrmPrincipal.lbuser.Text & "' );"
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
                                            & " '0', '0', '0', '0', '0', '0', " & DIN(val) & ",'" & lbper.Text & lbdoc.Text & txtnumero.Text & "' )"
                            myCommand.ExecuteNonQuery()

                        Next
                    End If

                Next
            Catch ex As Exception
                MsgBox("Error " & ex.ToString)
            End Try


        End If
    End Sub
    Public Sub GuardarContable(ByVal fila As Integer)
        myCommand.Parameters.Clear()
        myCommand.Parameters.AddWithValue("?item", fila + 1)
        myCommand.Parameters.AddWithValue("?doc", txtnumero.Text.ToString)
        myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
        myCommand.Parameters.AddWithValue("?periodo", PerActual)
        myCommand.Parameters.AddWithValue("?dia", txtdia.Text.ToString)
        If grilla.Item("cc", fila).Value <> "" Then
            myCommand.Parameters.AddWithValue("?centro", grilla.Item("cc", fila).Value.ToString)
        Else
            myCommand.Parameters.AddWithValue("?centro", txtcentro.Text)
        End If
        myCommand.Parameters.AddWithValue("?desc", CambiaCadena(grilla.Item(1, fila).Value.ToString, 50))
        myCommand.Parameters.AddWithValue("?debito", DIN(grilla.Item(2, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?credito", DIN(grilla.Item(3, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?codigo", grilla.Item(0, fila).Value.ToString)
        myCommand.Parameters.AddWithValue("?base", DIN(grilla.Item(4, fila).Value).ToString)
        myCommand.Parameters.AddWithValue("?diasv", "0")
        myCommand.Parameters.AddWithValue("?fechaven", "(NINGUNA)")
        Try
            If grilla.Item(6, fila).Value = "" Then
                myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
            Else
                myCommand.Parameters.AddWithValue("?nit", grilla.Item(6, fila).Value)
            End If
        Catch ex As Exception
            myCommand.Parameters.AddWithValue("?nit", txtnit.Text)
        End Try

        If chefectivo.Checked = False Then
            myCommand.Parameters.AddWithValue("?cheque", txtcheque.Text)
        Else
            myCommand.Parameters.AddWithValue("?cheque", "")
        End If
        myCommand.Parameters.AddWithValue("?modulo", "Otros doc")
        myCommand.CommandText = "INSERT INTO documentos" & PerActual(0) & PerActual(1) & " VALUES(?item,?doc,?tipodoc,?periodo,?dia,?centro,?desc,?debito,?credito,?codigo,?base,?diasv,?fechaven,?nit,?cheque,?modulo);"
        myCommand.ExecuteNonQuery()
        myCommand.Parameters.Clear()
    End Sub
    Private Sub GuardarObserva()
        If Trim(txtdetall.Text) <> "" Then
            myCommand.Parameters.AddWithValue("?doc", Val(txtnumero.Text))
            myCommand.Parameters.AddWithValue("?tipodoc", lbdoc.Text)
            myCommand.Parameters.AddWithValue("?comentario", txtdetall.Text)
            myCommand.CommandText = "INSERT INTO obsdocumentos" & PerActual(0) & PerActual(1) & " VALUES(?doc,?tipodoc,?comentario)"
            myCommand.ExecuteNonQuery()
        End If
    End Sub
    Public Sub ActualizarCuentas(ByVal i As Integer)
        Dim sql As String
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        Try
            db = CDbl(grilla.Item(2, i).Value.ToString)
        Catch ex As Exception
            db = 0
        End Try
        Try
            cb = CDbl(grilla.Item(3, i).Value.ToString)
        Catch ex As Exception
            cb = 0
        End Try
        suma = db - cb
        sql = "UPDATE selpuc SET saldo=saldo + " & DIN(suma) & ", " & saldo & "=" & saldo & " + " & DIN(suma) & ", " _
            & debito & "=" & debito & " + " & DIN(db) & ", " _
            & credito & "=" & credito & " + " & DIN(cb) & " " _
            & "WHERE codigo='" & grilla.Item(0, i).Value & "';"
        Ejecutar(sql)
    End Sub
    Public Sub ModificarCuentas()
        Dim sql As String
        Dim tabla As New DataTable
        Dim suma, db, cb As Double
        Dim saldo As String = "saldo" & PerActual(0) & PerActual(1)
        Dim debito As String = "debito" & PerActual(0) & PerActual(1)
        Dim credito As String = "credito" & PerActual(0) & PerActual(1)
        myCommand.CommandText = "SELECT * FROM documentos" & PerActual(0) & PerActual(1) & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & Trim(lbdoc.Text) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        For i = 0 To tabla.Rows.Count - 1
            Try
                db = CDbl(tabla.Rows(i).Item("debito").ToString)
            Catch ex As Exception
                db = 0
            End Try
            Try
                cb = CDbl(tabla.Rows(i).Item("credito").ToString)
            Catch ex As Exception
                cb = 0
            End Try
            suma = db - cb
            sql = "UPDATE selpuc SET saldo=saldo - " & DIN(suma) & ", " & saldo & "=" & saldo & " - " & DIN(suma) & ", " _
                & debito & "=" & debito & " - " & DIN(db) & ", " _
                & credito & "=" & credito & " - " & DIN(cb) & " " _
                & "WHERE codigo='" & tabla.Rows(i).Item("codigo").ToString & "';"
            Ejecutar(sql)
        Next
    End Sub
    Public Sub Ejecutar(ByVal sql As String)
        myCommand.CommandText = sql
        myCommand.ExecuteNonQuery()
    End Sub
    Function Eliminar()
        Dim Sql, tabla As String

        ' ..... credito
        Dim tc As New DataTable
        myCommand.CommandText = "SELECT pagado FROM ctas_x_pagar WHERE doc='" & PerActual & "-" & lbdoc.Text & txtnumero.Text & "' ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)
        If tc.Rows.Count > 0 Then
            If tc.Rows(0).Item(0) <> CDbl(0) Then
                MsgBox("El documento no se puede editar porque ya han abanonado a la deuda", MsgBoxStyle.Information, "Verificacion")
                Return ("salir")
                Exit Function
            Else
                tabla = "ctas_x_pagar"
                Sql = "DELETE FROM " & tabla & " WHERE doc='" & PerActual & "-" & lbdoc.Text & txtnumero.Text & "' ;"
                Ejecutar(Sql)
            End If
        End If

        tabla = "documentos" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc=" & Val(txtnumero.Text) & " AND tipodoc='" & lbdoc.Text & "';"
        Ejecutar(Sql)
        tabla = "ot_doc" & PerActual(0) & PerActual(1)
        Sql = "DELETE FROM " & tabla & " WHERE doc='" & lbdoc.Text & txtnumero.Text & "';"
        Ejecutar(Sql)

        If FrmPrincipal.cmdOrden.Visible = True Then
            ElimiPresup()
        End If

        Return ("")
        'Sql = "DELETE FROM ant_a_prov WHERE per_doc='" & PerActual & "-" & lbdoc.Text & txtnumero.Text & "';"
        'Ejecutar(Sql)
    End Function
    Private Sub ElimiPresup()
        Dim sql As String = ""
        sql = " DELETE FROM presupuesto" & Strings.Right(PerActual, 4) & ".movingresos where movi_reconoce ='" & lbper.Text & lbdoc.Text & txtnumero.Text & "'"
        Ejecutar(sql)

        sql = " DELETE FROM presupuesto" & Strings.Right(PerActual, 4) & ".recaudos where rec_nrodoc ='" & lbper.Text & lbdoc.Text & txtnumero.Text & "'"
        Ejecutar(sql)
    End Sub
    '******************************************************************
    Dim cb As PdfContentByte
    Dim k, pag, tope, salto As Integer
    Dim MiPer, linea As String
    Dim FechaRep As String
    Private Sub GenerarPDFCheque()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 110
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImgCheq(0)
            ColocarImgCheq(1)
            If logo = "SI" Then
                ColocarLogo("cheq")
            End If
            '********CABECERA************** 
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.SetFontAndSize(fuente, 11)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbnomdoc.Text, 388, 568, 0)
            cb.EndText()
            cb.BeginText()
            '********NUMERO************** 
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PerActual & " - " & lbdoc.Text & txtnumero.Text, 410, 543, 0)
            cb.EndText()
            cb.BeginText()
            '********** BANNER CHEQ********************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            BannerCheque()
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********** BANNER ********************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner("cheq")
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********** ANTICIPO *****************
            If ChAnti.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 676, 0)
            End If
            '*******FORMA DE PAGO*****************
            If Chcredito.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 575, 350, 0)
            ElseIf chefectivo.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 353, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcheque.Text, 457, 370, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtbanco.Text, 513, 370, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtsucursal.Text, 450, 353, 0)
            End If
            ''*******CUERPO**********************
            '*******CUERPO**********************
            k = 358
            Dim fin As Integer
            If Ch_mov.Checked = True Then
                fin = grilla.RowCount - 1
            Else
                fin = 1
            End If
            Dim cad As String = "///"
            For i = 0 To fin
                If Ch_mov.Checked = True Then cad = Trim(grilla.Item(0, i).Value)

                If cad <> "" Then
                    'If grilla.Item(0, i).Value <> "" Then
                    If i = 0 Or i = 1 Then
                        k = k - 22
                    Else
                        k = k - 18
                    End If
                    'If (i Mod 2) = 1 Then k = k + 1
                    'If i = 1 Then k = k - 2
                    If k < tope Then
                        k = 563
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If i > 0 Then
                        cb.EndText()
                        ColocarImgCheq(2)
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If Ch_mov.Checked = True Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value, 27), 75, k + 1, 0)
                        If grilla.Item(2, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(2, i).Value), 312, k + 1, 0)
                        If grilla.Item(3, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 401, k + 1, 0)
                    End If
                End If
            Next
            cb.EndText()
            k = k - 96
            ColocarImgCheq(3)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = k + 42
            PrintNit()
            k = k - 17
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fecha.Value, 515, k, 0)
            k = k - 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 12, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 145, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtconta.Text, 278, k, 0)
            Observacion()
            If ChAnti.Checked = True Then
                k = k - 20
                cb.ShowTextAligned(50, "***** Este documento fué marcado como anticipo. ******", 10, k, 0)
            End If
            k = k - 20
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            '*********** FIN ***********************
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Private Sub GenerarNPDF(ByVal ch As String)

        BuscarPeriodo()

        Dim sql As String = ""
        Dim doc As String = ""
        Dim nom As String = ""
        Dim nit As String = ""

        MiConexion(bda)

        Dim tabla2 As New DataTable
        tabla2 = New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla2)
        nom = tabla2.Rows(0).Item("descripcion")
        nit = tabla2.Rows(0).Item("nit")

        Dim tabl As  New DataSet
        myCommand.Parameters.Clear()
        myCommand.CommandText = "select comentario as descrip from obsdocumentos" & Strings.Left(PerActual, 2) & " WHERE doc='" & Val(txtnumero.Text) & "' and tipodoc='" & lbdoc.Text & "' LIMIT 1"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "ctas_x_pagar")

        myCommand.Parameters.Clear()
        myCommand.CommandText = "SELECT UPPER(descrip) AS descri, debito ,credito FROM ot_doc" & Strings.Left(PerActual, 2) & " WHERE doc='" & lbdoc.Text & txtnumero.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabl, "documentos01")

       
        Dim CrReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        CrReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Try
            CrReport.PrintOptions.PaperSize = PaperSize.PaperLegal
        Catch ex As Exception
        End Try
        CrReport.Load(My.Application.Info.DirectoryPath & "\Reportes\Rordenes\ReportNCE.rpt")
        CrReport.SetDataSource(tabl)
        FrmReportCCxPg.CrystalReportViewer1.ReportSource = CrReport

        Try
            Dim PrNit As New ParameterField
            Dim Prcomp As New ParameterField
            '..
            Dim Prt1 As New ParameterField
            Dim Prm1 As New ParameterField
            Dim Prf1 As New ParameterField
            Dim Prp1 As New ParameterField
            '..
            Dim Prt2 As New ParameterField
            Dim Prm2 As New ParameterField
            Dim Prf2 As New ParameterField
            Dim Prch As New ParameterField
            Dim Pror As New ParameterField
            Dim Prts As New ParameterField


            Dim prmdatos As ParameterFields
            prmdatos = New ParameterFields

            PrNit.Name = "comp"
            PrNit.CurrentValues.AddValue(nom)
            Prcomp.Name = "nit"
            Prcomp.CurrentValues.AddValue(nit.ToString)
            '...
            Prt1.Name = "doc"
            Prt1.CurrentValues.AddValue(lbdoc.Text & txtnumero.Text)
            Prm1.Name = "pagado"
            Prm1.CurrentValues.AddValue(lbcliente.Text)
            Prf1.Name = "concepto"
            Prf1.CurrentValues.AddValue(txtconcepto.Text)
            Prp1.Name = "vtotal"
            Prp1.CurrentValues.AddValue(txtvalor.Text)
            '...
            Prt2.Name = "nch"
            Prt2.CurrentValues.AddValue(txtcheque.Text)
            Prm2.Name = "ban"
            Prm2.CurrentValues.AddValue(txtbanco.Text)
            Prf2.Name = "fecha"
            Prf2.CurrentValues.AddValue(txtdia.Text & txtperiodo.Text)
            Prch.Name = "ch"
            Prch.CurrentValues.AddValue(ch)
            Pror.Name = "ord"
            Pror.CurrentValues.AddValue(txtaprobado.Text)
            Prts.Name = "tes"
            Prts.CurrentValues.AddValue(txtelaborado.Text)

            prmdatos.Add(PrNit)
            prmdatos.Add(Prcomp)
            prmdatos.Add(Prt1)
            prmdatos.Add(Prm1)
            prmdatos.Add(Prf1)
            prmdatos.Add(Prp1)
            prmdatos.Add(Prt2)
            prmdatos.Add(Prm2)
            prmdatos.Add(Prf2)
            prmdatos.Add(Prch)
            prmdatos.Add(Pror)
            prmdatos.Add(Prts)

            FrmReportCCxPg.CrystalReportViewer1.ParameterFieldInfo = prmdatos
            FrmReportCCxPg.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub GenerarPDF()
        Dim oDoc As New iTextSharp.text.Document(PageSize.A4, 0, 0, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Try
            Dim NombreArchivo As String = My.Application.Info.DirectoryPath & "\Reportes\reporte.pdf"
            FechaRep = Now.ToString
            pag = 0
            tope = 110
            '**************************************
            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open()
            cb = pdfw.DirectContent
            oDoc.NewPage()
            ColocarImg(1)
            If logo = "SI" Then
                ColocarLogo("pdf")
            End If
            '********CABECERA************** 
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.WHITE)
            cb.SetFontAndSize(fuente, 11)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbnomdoc.Text, 388, 807, 0)
            cb.EndText()
            cb.BeginText()
            '********NUMERO************** 
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetColorFill(iTextSharp.text.BaseColor.BLACK)
            cb.SetFontAndSize(fuente, 12)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, PerActual & " - " & lbdoc.Text & txtnumero.Text, 410, 780, 0)
            cb.EndText()
            cb.BeginText()
            '********** BANNER ********************
            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 9)
            Banner("pdf")
            cb.EndText()
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            '********** ANTICIPO *****************
            If ChAnti.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 720, 0)
            End If
            '*******FORMA DE PAGO*****************
            If Chcredito.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 575, 578, 0)
            ElseIf chefectivo.Checked = True Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 590, 0)
            Else
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtcheque.Text, 457, 605, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtbanco.Text, 513, 605, 0)
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtsucursal.Text, 450, 588, 0)
            End If
            ''*******CUERPO**********************
            'k = 595
            'For i = 0 To grilla.RowCount - 1
            '    If grilla.Item(0, i).Value <> "" Then
            '        If i = 0 Or i = 1 Then
            '            k = k - 22
            '        Else
            '            k = k - 18
            '        End If
            '        If (i Mod 2) = 1 Then k = k + 1
            '        If i = 1 Then k = k - 2
            '        If k < tope Then
            '            k = 760
            '            cb.EndText()
            '            oDoc.NewPage()
            '            cb.BeginText()
            '            fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            '            cb.SetFontAndSize(fuente, 7)
            '        End If

            '        If i > 0 Then
            '            cb.EndText()
            '            ColocarImg(2)
            '            cb.BeginText()
            '            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            '            cb.SetFontAndSize(fuente, 7)
            '        End If
            '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
            '        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value, 27), 75, k + 1, 0)
            '        If grilla.Item(2, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(2, i).Value), 312, k + 1, 0)
            '        If grilla.Item(3, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 401, k + 1, 0)
            '    End If
            'Next
            'cb.EndText()
            'k = k - 96
            'ColocarImg(3)
            'cb.BeginText()
            'fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            'cb.SetFontAndSize(fuente, 7)
            'k = k + 42
            'PrintNit()
            'k = k - 17
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fecha.Value, 515, k, 0)
            'k = k - 15
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 12, k, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 145, k, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtconta.Text, 278, k, 0)
            'Observacion()
            'k = k - 20
            'cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            'k = k - 10
            'cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            ''*********** FIN ***********************
            '*******CUERPO**********************
            k = 595
            Dim fin As Integer
            If Ch_mov.Checked = True Then
                fin = grilla.RowCount - 1
            Else
                fin = 1
            End If
            Dim cad As String = "///"
            For i = 0 To fin
                If Ch_mov.Checked = True Then cad = Trim(grilla.Item(0, i).Value)

                If cad <> "" Then
                    'If grilla.Item(0, i).Value <> "" Then
                    If i = 0 Or i = 1 Then
                        k = k - 22
                    Else
                        k = k - 18
                    End If
                    'If (i Mod 2) = 1 Then k = k + 1
                    'If i = 1 Then k = k - 2
                    If k < tope Then
                        k = 760
                        cb.EndText()
                        oDoc.NewPage()
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If i > 0 Then
                        cb.EndText()
                        ColocarImg(2)
                        cb.BeginText()
                        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
                        cb.SetFontAndSize(fuente, 7)
                    End If
                    If Ch_mov.Checked = True Then
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, grilla.Item(0, i).Value, 10, k + 1, 0)
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CambiaCadena(grilla.Item(1, i).Value, 27), 75, k + 1, 0)
                        If grilla.Item(2, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(2, i).Value), 312, k + 1, 0)
                        If grilla.Item(3, i).Value <> "0,00" Then cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(grilla.Item(3, i).Value), 401, k + 1, 0)
                    End If
                End If
            Next
            cb.EndText()
            k = k - 96
            ColocarImg(3)
            cb.BeginText()
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 7)
            k = k + 42
            PrintNit()
            k = k - 17
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fecha.Value, 515, k, 0)
            k = k - 15
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtelaborado.Text, 12, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtaprobado.Text, 145, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtconta.Text, 278, k, 0)
            Observacion()
            If ChAnti.Checked = True Then
                k = k - 20
                cb.ShowTextAligned(50, "***** Este documento fué marcado como anticipo. ******", 10, k, 0)
            End If
            k = k - 20
            cb.ShowTextAligned(50, "Impreso a la fecha y hora: " & Now & " por el usuario: " & FrmPrincipal.lbuser.Text, 10, k, 0)
            k = k - 10
            cb.ShowTextAligned(50, "Documento elaborado por computadora en el Software de Administración Empresarial SAE Versión " & FrmPrincipal.lbversion.Text & ".", 10, k, 0)
            '*********** FIN ***********************
            cb.EndText()
            pdfw.Flush()
            oDoc.Close()
            Try
                AbrirArchivo(NombreArchivo)
            Catch ex As Exception
                AbrirArchivo(NombreArchivo)
                Exit Try
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try
    End Sub
    Public Sub Observacion()
        Try
            If Trim(lbanulado.Text) <> "" Then
                k = k - 20
                cb.ShowTextAligned(50, "DOCUMENTO " & lbanulado.Text & ". ", 10, k, 0)
            Else
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT aj FROM parotdoc;"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                If tabla.Rows(0).Item("aj") = lbdoc.Text Then
                    tabla.Clear()
                    myCommand.CommandText = "SELECT doc_afec FROM ot_doc" & PerActual(0) & PerActual(1) & " WHERE doc='" & lbdoc.Text.ToString & txtnumero.Text.ToString & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tabla)
                    If Trim(tabla.Rows(0).Item("doc_afec").ToString) <> "" Then
                        k = k - 20
                        cb.ShowTextAligned(50, "ANULA AL DOCUMENTO " & tabla.Rows(0).Item("doc_afec") & ". ", 10, k, 0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BannerCheque()
        Dim d As Integer = 0
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        k = 750
        d = 350
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Strings.Right(fecha.Text, 4) & "    " & Strings.Mid(fecha.Text, 4, 2) & "    " & Strings.Left(fecha.Text, 2), 300, k, 0)
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtvalor.Text, 500, k, 0)
        k = k - 30
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbcliente.Text, 150, k, 0)
        k = k - 20
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbsuma.Text, 100, k, 0)
    End Sub
    Public Sub Banner(ByVal form As String)
        Dim d As Integer = 0
        Dim tablacomp As New DataTable
        myCommand.CommandText = "SELECT * FROM sae.companias WHERE login='" & UCase(CompaniaActual) & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablacomp)
        If form = "pdf" Then
            k = 800
            If logo = "SI" Then
                d = 80
            Else
                d = 10
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), d, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), d, k, 0)
            If txtncentro.Text <> "" Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CENTRO DE COSTOS: " & txtcentro.Text & " - " & txtncentro.Text, 10, k, 0)
            End If
            k = 750
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtciudad.Text, 60, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 338, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtvalor.Text), 575, k, 0)
            'pagado a
            k = 716
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbcliente.Text, 73, k, 0)
            'concepto
            k = k - 28
            Control_de_linea(txtconcepto.Text, 110, 80)
            'valor en letras
            k = 655
            Control_de_linea(": " & lbsuma.Text, 137, 75)
        Else
            k = 562
            If logo = "SI" Then
                d = 80
            Else
                d = 10
            End If
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tablacomp.Rows(0).Item("descripcion"), d, k, 0)
            k = k - 10
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "NIT: " & tablacomp.Rows(0).Item("nit"), d, k, 0)
            If txtncentro.Text <> "" Then
                k = k - 10
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "CENTRO DE COSTOS: " & txtcentro.Text & " - " & txtncentro.Text, 10, k, 0)
            End If
            k = 512
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtciudad.Text, 60, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtdia.Text & "/" & PerActual, 338, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, Moneda(txtvalor.Text), 575, k, 0)
            'pagado a
            k = 478
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, lbcliente.Text, 73, k, 0)
            'concepto
            k = k - 28
            Control_de_linea(txtconcepto.Text, 110, 80)
            'valor en letras
            k = 417
            Control_de_linea(": " & lbsuma.Text, 137, 75)
        End If

    End Sub
    Private Sub ColocarLogo(ByVal form As String)
        If form = "pdf" Then
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
                img.ScaleToFit(67, 180)
                img.SetAbsolutePosition(10, 775)
                img.Alignment = Element.ALIGN_RIGHT
                cb.AddImage(img)
            Catch ex As Exception
            End Try
        Else
            Try
                Dim tabla As New DataTable
                myCommand.CommandText = "SELECT logofac FROM parafacts WHERE factura='RAPIDA';"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tabla)
                Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(tabla.Rows(0).Item("logofac"))
                img.ScaleToFit(55, 90)
                img.SetAbsolutePosition(10, 537)
                img.Alignment = Element.ALIGN_RIGHT
                cb.AddImage(img)
            Catch ex As Exception
            End Try
        End If


    End Sub
    Public Sub ColocarImg(ByVal i As Integer)
        Try
            Dim img As iTextSharp.text.Image
            If i = 1 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE1.jpg")
                img.SetAbsolutePosition(0, 570)
                img.ScaleToFit(598, 500)
            ElseIf i = 2 Then
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE2.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 50)
            Else
                img = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE3.jpg")
                img.SetAbsolutePosition(0, k)
                img.ScaleToFit(598, 170)
            End If
            img.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ColocarImgCheq(ByVal i As Integer)
        Try
            Dim img1 As iTextSharp.text.Image
            If i = 0 Then
                img1 = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CHEQUE.jpg")
                img1.SetAbsolutePosition(0, 580)
                img1.ScaleToFit(598, 500)
            ElseIf i = 1 Then
                img1 = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE1.jpg")
                img1.SetAbsolutePosition(0, 332)
                img1.ScaleToFit(598, 500)
            ElseIf i = 2 Then
                img1 = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE2.jpg")
                img1.SetAbsolutePosition(0, k)
                img1.ScaleToFit(598, 50)
            Else
                img1 = iTextSharp.text.Image.GetInstance(My.Application.Info.DirectoryPath & "\Reportes\CE\CE3.jpg")
                img1.SetAbsolutePosition(0, k)
                img1.ScaleToFit(598, 170)
            End If
            img1.Alignment = Element.ALIGN_CENTER
            cb.AddImage(img1)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Control_de_linea(ByVal cadena As String, ByVal pos As Integer, ByVal tam As Integer)
        Dim s As Integer = 1
        linea = ""
        Dim j As Integer = 0
        For i = 0 To cadena.Length - 1
            linea = linea & cadena(i)
            If j < tam Then
                j = j + 1
            Else
                If cadena(i) = " " And j > tam Then
                    j = 0
                    cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
                    linea = ""
                    k = k - 10
                    s = s + 1
                Else
                    j = j + 1
                End If
            End If
        Next
        cb.ShowTextAligned(50, Trim(linea), pos, k, 0)
    End Sub
    Public Sub PrintNit()
        If rbcc.Checked = True Then
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text, 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 419, k, 0)
        Else
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, txtnit.Text & txtdv.Text, 500, k, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "X", 456, k, 0)
        End If
    End Sub

    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        validarnumero(txtnumero, e)
    End Sub

    Private Sub txtnumero_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnumero.LostFocus
        txtnumero.Text = NumeroDoc(txtnumero.Text)
    End Sub

    Private Sub txtcodCon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodCon.DoubleClick
        'Try
        '    If txtcodCon.Text <> "" Then
        '        buscarcontrato(txtcodCon.Text)
        '    Else
        '        buscarcontrato(0)
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub txtcodCon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodCon.LostFocus
        Try
            If txtcodCon.Text <> "" Then
                buscarcontrato(txtcodCon.Text)
            Else
                buscarcontrato(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub buscarcontrato(ByVal cod As String)
        Dim tc As New DataTable
        myCommand.CommandText = "SELECT cod_contra,nit_d FROM contrato_inm where cod_contra = '" & cod & "';"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tc)

        If tc.Rows.Count = 0 Then
            Try
                FrmSelContratos.lbform.Text = "comEgre"
                FrmSelContratos.ShowDialog()
                'txtcodCon.Focus()
                If txtcodCon.Text <> "" Then
                    Dim tct As New DataTable
                    myCommand.CommandText = "SELECT nit_d FROM contrato_inm where cod_contra = '" & txtcodCon.Text & "';"
                    myAdapter.SelectCommand = myCommand
                    myAdapter.Fill(tct)
                    txtnit.Text = tct.Rows(0).Item(0)
                    BuscarClientes(txtnit.Text)
                End If

            Catch ex As Exception
            End Try
        Else
            txtnit.Text = tc.Rows(0).Item(1)
            rbnit.Checked = True
        End If
        BuscarClientes(txtnit.Text)
    End Sub


    Private Sub txtcodCon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodCon.TextChanged
        If txtcodCon.Text = "" Then
            txtnit.Text = ""
        End If
    End Sub

    Private Sub CmdCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCons.Click
        Try
            FrmSelOtdoc.lbtabla.Text = "ot_doc" & PerActual(0) & PerActual(1) & ""
            FrmSelOtdoc.tdoc.Text = "'" & lbdoc.Text & "'"
            FrmSelOtdoc.lbform.Text = "ComEgre"
            FrmSelOtdoc.ShowDialog()
            BuscarDocumento(lbdoc.Text & txtnumero.Text)
            SacarCuenta()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdmas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmas.Click
        If lbestado.Text <> "NUEVO" And lbestado.Text <> "EDITAR" Then Exit Sub
        SendKeys.Send(Chr(Keys.Space))
        FrmSelConcepImp.lbform.Text = "ComEgres"
        FrmSelConcepImp.lbfila.Text = fila
        If fila = grilla.RowCount - 1 Then
            grilla.RowCount = grilla.RowCount + 1
        End If
        FrmSelConcepImp.ShowDialog()
        'SacarCuenta()
    End Sub

    Private Sub cmdmas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdmas.GotFocus
        SendKeys.Send(Chr(Keys.Tab))
    End Sub

    Private Sub Chcredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chcredito.CheckedChanged
        If Chcredito.Checked = True Then
            chefectivo.Checked = False
        Else
            chefectivo.Checked = True
        End If
    End Sub

    Private Sub grilla_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grilla.CellContentClick

    End Sub

    Private Sub txtconcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconcepto.TextChanged

    End Sub

    Private Sub txtdetall_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdetall.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If lbestado.Text = "NUEVO" And grilla.Item(0, 0).Value = "" Then
                grilla.Focus()
                grilla.Item(0, 0).Selected = True
                SendKeys.Send(Chr(Keys.Space))
                SendKeys.Send(Chr(Keys.Back))
                grilla.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        Else
            If lbestado.Text = "NUEVO" Or lbestado.Text = "EDITAR" Then
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtdetall_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdetall.TextChanged

    End Sub
End Class