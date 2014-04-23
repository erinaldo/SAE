Public Class FrmConsultaInm
    Public fila As Integer
    Private Sub FrmConsultaInm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MiConexion(bda)
        Dim tablas As New DataTable
        tablas.Clear()
        myCommand.CommandText = "SELECT * FROM inm_tipo ;"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tablas)
        Refresh()
        cmbTipo.Items.Clear()
        cmbTipo.Items.Add("Seleccione...")
        If tablas.Rows.Count <> 0 Then
            For i = 0 To tablas.Rows.Count - 1
                cmbTipo.Items.Add(tablas.Rows(i).Item("tipo"))
            Next
            cmbTipo.Text = cmbTipo.Items(0).ToString
        End If
        Cerrar()

        txtPLocal.Text = Moneda(0)
        txtPvivi.Text = Moneda(0)
        gitems.Rows.Clear()


    End Sub

    Private Sub txtcodinm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodinm.TextChanged
        If txtcodinm.Text <> "" Then
            cmbTipo.Enabled = False
            cmbOperacion.Enabled = False
            cmbDestino.Enabled = False
            cmbEst.Enabled = False
            cmbAlco.Enabled = False
            txtdep.Enabled = False
            txtPvivi.Enabled = False
            txtPLocal.Enabled = False
        Else
            cmbTipo.Enabled = True
            cmbOperacion.Enabled = True
            cmbDestino.Enabled = True
            cmbEst.Enabled = True
            cmbAlco.Enabled = True
            txtdep.Enabled = True
            txtPvivi.Enabled = True
            txtPLocal.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtPLocal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPLocal.LostFocus
        txtPLocal.Text = Moneda(txtPLocal.Text)
    End Sub

    Private Sub txtPvivi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPvivi.LostFocus
        txtPvivi.Text = Moneda(txtPvivi.Text)
    End Sub

   
    Private Sub Continuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Continuar.Click
        Try
            Dim cad As String = ""

            If txtcodinm.Text <> "" Then
                cad = cad & " AND i.codigo= '" & txtcodinm.Text & "'"
            Else
                If (cbestado.Text <> "Seleccione...") And (cbestado.Text <> "") Then
                    cad = cad & " AND i.estado='" & cbestado.Text & "'"
                End If
                If (cmbTipo.Text <> "Seleccione...") And (cmbTipo.Text <> "") Then
                    cad = cad & " AND i.tipoim='" & cmbTipo.Text & "'"
                End If
                If cmbOperacion.Text <> "Seleccione..." And (cmbOperacion.Text <> "") Then
                    cad = cad & " AND i.operacion='" & cmbOperacion.Text & "'"
                End If
                If cmbDestino.Text <> "Seleccione..." And (cmbDestino.Text <> "") Then
                    cad = cad & " AND i.destino='" & cmbDestino.Text & "'"
                End If
                If cmbEst.Text <> "Seleccione..." And (cmbEst.Text <> "") Then
                    cad = cad & " AND i.tipoestado='" & cmbEst.Text & "'"
                End If
                If txtPvivi.Text <> Moneda(0) And (txtPvivi.Text <> "") Then
                    cad = cad & "AND i.previvi <= " & DIN(txtPvivi.Text)
                End If
                If txtPLocal.Text <> Moneda(0) And (txtPLocal.Text <> "") Then
                    cad = cad & "AND i.prelocal <= " & DIN(txtPLocal.Text)
                End If
                If cmbAlco.Text <> "Sel..." And (cmbAlco.Text <> "") Then
                    cad = cad & " AND (SELECT IFNULL( COUNT( descrip ) , 0 ) AS num FROM  `inm_dpden` WHERE codigo_inm =  i.codigo AND descrip LIKE 'ALCOBA%') ='" & cmbAlco.Text & "' "
                End If
                If txtdep.Text <> "" Then
                    cad = cad & " AND (SELECT  descrip FROM  `inm_dpden` WHERE codigo_inm =  i.codigo )  LIKE CONCAT('%','" & txtdep.Text & "','%') "
                End If

            End If


            Dim tabla As New DataTable
            tabla.Clear()
            Dim items As Integer
            myCommand.CommandText = "SELECT  i.`codigo`, i.tipoim, TRIM(CONCAT(i.`direccion`,' ',i.`barrio`)) as dir, s.`descripcion`, i.estado,  TRIM(CONCAT(i.`nitp`,' ',t.nombre,' ',t.apellidos)) AS nom " _
            & " FROM inmuebles i, terceros t, sae.mun s WHERE t.nit=i.nitp  AND s.`coddep`= i.`dpto` AND s.`codmun`= i.`ciudad` " & cad
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            items = tabla.Rows.Count
            If items = 0 Then
                MsgBox("No existen resultados para la Busqueda, Verifique.  ", MsgBoxStyle.Information, "Verificando ")
                gitems.Rows.Clear()
                Exit Sub
            End If
            Try
                gitems.Rows.Clear()
            Catch ex As Exception
            End Try
            gitems.RowCount = items + 1
            For i = 0 To items - 1
                gitems.Item("codigo", i).Value = tabla.Rows(i).Item("codigo")
                gitems.Item("tipo", i).Value = tabla.Rows(i).Item("tipoim")
                gitems.Item("dir", i).Value = tabla.Rows(i).Item("dir")
                gitems.Item("ciudad", i).Value = tabla.Rows(i).Item("descripcion")
                gitems.Item("nombre", i).Value = tabla.Rows(i).Item("nom")
                gitems.Item("estado", i).Value = tabla.Rows(i).Item("estado")
            Next
            With gitems
                .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.BackColor = Color.FloralWhite
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gitems_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellEnter
        fila = e.RowIndex        'captura fila
    End Sub
    Private Sub gitems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gitems.CellDoubleClick
        seleccionar(fila)
    End Sub
    Private Sub gitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gitems.KeyPress
        If e.KeyChar = Chr(Keys.Enter) And gitems.Focus = True Then
            seleccionar(fila - 1)
        End If
    End Sub
    Private Sub cmditems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmditems.Click
        seleccionar(fila)
    End Sub
    Private Sub seleccionar(ByVal mifila As Integer)
        If gitems.Item(1, mifila).Value() = "" Then Exit Sub

        FrmInmueble.txtcod.Text = gitems.Item(1, mifila).Value
        FrmInmueble.Buscar(FrmInmueble.txtcod.Text)
        FrmInmueble.cons = "in"
        FrmInmueble.ShowDialog()

    End Sub


End Class