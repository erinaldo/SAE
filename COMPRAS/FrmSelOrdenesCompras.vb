Public Class FrmSelOrdenesCompras
    Public fila As Integer
    Private Sub FrmSelOrdenesCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BuscarPeriodo()
        Dim tabla As New DataTable
        tabla.Clear()
        Dim items As Integer
        myCommand.CommandText = "SELECT DISTINCT(numero),f.nom_art,f.fechaped,TRIM(CONCAT(t.nombre,' ',t.apellidos)) AS nomnit, FORMAT(SUM(vtotal),2) AS total FROM pedi_comp f LEFT JOIN (terceros t) ON f.nitc=t.nit " & lbremis.Text & "  group by f.numero ORDER BY f.numero;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        items = tabla.Rows.Count
        gitems.Rows.Clear()
        If items = 0 Then
            MsgBox("No Existen documentos para la busqueda, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
            Me.Close()
            Exit Sub
        End If
        gitems.RowCount = items + 1
        For i = 0 To items - 1
            gitems.Item(0, i).Value = i + 1
            gitems.Item("docu", i).Value = tabla.Rows(i).Item("numero")
            gitems.Item("fecha", i).Value = CambiaCadena(tabla.Rows(i).Item("fechaped"), 10)
            gitems.Item("cliente", i).Value = tabla.Rows(i).Item("nomnit")
            gitems.Item("con", i).Value = tabla.Rows(i).Item("nom_art")
            gitems.Item("total", i).Value = tabla.Rows(i).Item("total")
            gitems.Item("tipo", i).Value = ""
            gitems.Item("numero", i).Value = tabla.Rows(i).Item("numero")
        Next
        With gitems
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Public Sub seleccionar(ByVal mifila As Integer)
        Try
            Select Case lbform.Text
                Case "Orden"
                    If gitems.Item(1, mifila).Value() = "" Then Exit Sub
                    FrmOrdenCompra.lbestado.Text = "CONSULTA"
                    FrmOrdenCompra.txtnumfac.Text = gitems.Item("docu", mifila).Value()
                    FrmOrdenCompra.lbnumero.Text = mifila + 1
                    gitems.Focus()
                Case "FacturaC"
                    If gitems.Item(1, mifila).Value() = "" Then Exit Sub
                    BuscarDocumentoFC(gitems.Item("docu", mifila).Value())
            End Select
            lbform.Text = ""
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BuscarDocumentoFC(ByVal doc As String)
        BuscarPeriodo()
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT * FROM pedi_comp WHERE numero='" & doc & "' LIMIT 1 ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        FrmDocProveedor.PonerenCero()
        FrmDocProveedor.Desbloquear()
        FrmDocProveedor.lbusuario.Text = FrmPrincipal.lbuser.Text
        FrmDocProveedor.lbhora.Text = Format(Now, "HH:mm:ss")
        FrmDocProveedor.lbpedido.Text = doc
        FrmDocProveedor.txttipo.Enabled = False
        FrmDocProveedor.BuscarClientes(tabla.Rows(0).Item("nitc"))
        FrmDocProveedor.grup_tip_doc.Enabled = False
        FrmDocProveedor.grupoafecta.Enabled = True
        FrmDocProveedor.rbafecta1.Checked = True
        FrmDocProveedor.txtnitc.Enabled = False
        FrmDocProveedor.txtnitc.Text = tabla.Rows(0).Item("nitc")
        FrmDocProveedor.cmditems.Enabled = True
        FrmDocProveedor.cmdConceptos.Enabled = True
        FrmDocProveedor.lbestado.Text = "NUEVO"
        FrmDocProveedor.txt_doc_afe.Enabled = True
        FrmDocProveedor.valordes.Enabled = False
        FrmDocProveedor.txtobserbaciones.Text = "APARTIR DE PEDIDO Num:" & doc & " - " & tabla.Rows(0).Item("observ")
        'cuentas
        FrmDocProveedor.txtflete.Enabled = False
        FrmDocProveedor.txtseguro.Enabled = False
        '
        FrmDocProveedor.valorret.Enabled = False
        FrmDocProveedor.chcosto.Enabled = False
        FrmDocProveedor.gfactura.Rows.Clear()
        FrmDocProveedor.gfactura.RowCount = 1
        BuscarDetallesC(doc)
        FrmDocProveedor.CalcularTotales()
        FrmDocProveedor.cbaprobado.Text = "AP"
        FrmDocProveedor.cbaprobado.Enabled = False

    End Sub
    Public Sub BuscarDetallesC(ByVal num_per As String)
        Dim tabla As New DataTable
        myCommand.CommandText = "SELECT p.*, a.cue_inv,a.cue_cos, a.cue_ing, a.cue_iva_c FROM pedi_comp p, articulos a WHERE p.numero='" & num_per & "' AND a.`codart`=p.`cod_art` ORDER BY p.item"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()

        FrmDocProveedor.Parametros()
        FrmDocProveedor.gfactura.RowCount = tabla.Rows.Count

        Dim suma As Double = 0
        FrmDocProveedor.lbdescuento.Text = "0"
        Dim dct As Double = 0
        Dim base As Double = 0
        Try
            For i = 0 To tabla.Rows.Count - 1
                FrmDocProveedor.gfactura.Item("num", i).Value = tabla.Rows(i).Item("item")
                FrmDocProveedor.gfactura.Item("tipo", i).Value = "I"
                FrmDocProveedor.gfactura.Item("codigo", i).Value = tabla.Rows(i).Item("cod_art")
                FrmDocProveedor.gfactura.Item("descrip", i).Value = tabla.Rows(i).Item("nom_art")
                FrmDocProveedor.gfactura.Item("bodega", i).Value = "1"
                Try
                    FrmDocProveedor.gfactura.Item("cant", i).Value = Decimales(tabla.Rows(i).Item("cantped").ToString)
                Catch ex As Exception
                End Try
                FrmDocProveedor.gfactura.Item("valor", i).Value = tabla.Rows(i).Item("valor")
                FrmDocProveedor.gfactura.Item("Vtotal", i).Value = Moneda(tabla.Rows(i).Item("vtotal"))
                FrmDocProveedor.gfactura.Item("iva", i).Value = tabla.Rows(i).Item("por_iva")
                'cuentas
                FrmDocProveedor.gfactura.Item("ctainv", i).Value = tabla.Rows(i).Item("cue_inv")
                FrmDocProveedor.gfactura.Item("ctacven", i).Value = tabla.Rows(i).Item("cue_cos")
                FrmDocProveedor.gfactura.Item("ctaing", i).Value = tabla.Rows(i).Item("cue_ing")
                FrmDocProveedor.gfactura.Item("ctaiva", i).Value = tabla.Rows(i).Item("cue_iva_c")
                FrmDocProveedor.gfactura.Item("costo", i).Value = tabla.Rows(i).Item("costo")
                FrmDocProveedor.gfactura.Item("cc", i).Value = ""
                '... descuento
                FrmDocProveedor.gfactura.Item("descuento", i).Value = Moneda(0)
                Try
                    base = tabla.Rows(i).Item("cantped") * (tabla.Rows(i).Item("valor") * (1 + (tabla.Rows(i).Item("por_iva") / 100))) / (1 + (tabla.Rows(i).Item("por_iva") / 100))
                Catch ex As Exception
                    base = 0
                End Try
                Try
                    dct = dct + (base * 0 / 100)
                Catch ex As Exception
                End Try
                FrmDocProveedor.lbdescuento.Text = dct
                '....
                Try
                    suma = suma + tabla.Rows(i).Item("vtotal")
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '*****************************************

    End Sub

    Public Sub BuscarGrilla(ByVal cad As String)
        txtcuenta.Text = NumeroDoc(cad)
        cad = NumeroDoc(cad)
        Try
            If cad = "" Then Exit Sub
            cad = UCase(cad)
            Dim cad2, aux As String
            For i = 0 To gitems.RowCount - 1
                aux = gitems.Item(1, i).Value.ToString
                If Val(aux.Length) >= Val(cad.Length) Then
                    cad2 = ""
                    For j = 0 To cad.Length - 1
                        cad2 = cad2 & aux(j)
                    Next
                    If cad = cad2 Then
                        Dim C As Integer = 1, F As Integer = i
                        gitems.CurrentCell = gitems(C, F)
                        gitems.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        BuscarGrilla(txtcuenta.Text)
    End Sub
    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BuscarGrilla(txtcuenta.Text)
        End If
    End Sub

End Class