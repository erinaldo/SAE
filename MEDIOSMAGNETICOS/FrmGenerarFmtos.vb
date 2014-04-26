Public Class FrmGenerarFmtos

    Private Sub FrmGenerarFmtos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdesfor.Text = ""
        cmbcon.Items.Clear()
        txtdesfor.Text = ""
        txtcon.Text = ""
        Limpiar("1001")
        With gcuenta
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.BackColor = Color.FloralWhite
        End With
        buscarFormatos()
    End Sub
    Private Sub buscarFormatos()
        Try

            Dim tabla As New DataTable
            tabla.Clear()
            'myCommand.CommandText = "SELECT DISTINCT c.codfor, f.descripcion FROM conceptos c, formatos f WHERE c.codfor = f.codigo"
            myCommand.CommandText = "SELECT DISTINCT f.codigo, f.descripcion FROM  formatos f Limit 10"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                cmbForm.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    'cmbForm.Items.Add(tabla.Rows(i).Item("codfor"))
                    cmbForm.Items.Add(tabla.Rows(i).Item("codigo"))
                Next
            Else
                MsgBox("No existen formatos para mostrar", MsgBoxStyle.Information, "Verifique")
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar los Formatos")
        End Try

    End Sub

    Private Sub cmbForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForm.SelectedIndexChanged
        Dim tabla As New DataTable
        tabla.Clear()
        'myCommand.CommandText = "SELECT  f.descripcion, c.codcon  FROM  formatos f, conceptos c " _
        '& " WHERE f.codigo= '" & cmbForm.Text & "'  AND c.codfor='" & cmbForm.Text & "'"
        myCommand.CommandText = "SELECT  f.descripcion, IFNULL(c.codcon,'NO') codcon FROM  conceptos c  RIGHT JOIN  formatos f " _
        & " ON  c.codfor='" & cmbForm.Text & "' WHERE f.codigo= '" & cmbForm.Text & "'"
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(tabla)
        Refresh()
        If tabla.Rows.Count > 0 Then
            txtdesfor.Text = UCase(tabla.Rows(0).Item("descripcion"))
            cmbcon.Items.Clear()
            txtcon.Text = ""
            Limpiar(cmbForm.Text)
            For j = 0 To tabla.Rows.Count - 1
                cmbcon.Items.Clear()
                For i = 0 To tabla.Rows.Count - 1
                    cmbcon.Items.Add(tabla.Rows(i).Item("codcon"))
                Next
            Next
        End If
    End Sub
    Private Sub Limpiar(ByVal tp As String)
        gcuenta.Rows.Clear()
        gcuenta.RowCount = 1
        Select Case tp
            Case "1001"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("pagoD").Visible = True
                gcuenta.Columns("pagoN").Visible = True
                gcuenta.Columns("ivad").Visible = True
                gcuenta.Columns("ivaNd").Visible = True
                gcuenta.Columns("reteprac").Visible = True
                gcuenta.Columns("reteasu").Visible = True
                gcuenta.Columns("rtfcomun").Visible = True
                gcuenta.Columns("rtfsimp").Visible = True
                gcuenta.Columns("rtfNo").Visible = True
                'NO
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
                gcuenta.Columns("tdcont").Visible = False
                gcuenta.Columns("idcont").Visible = False
            Case "1003"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("vartf").Visible = True
                gcuenta.Columns("tiprt").Visible = True
                'NO
                gcuenta.Columns("pais").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
                gcuenta.Columns("tdcont").Visible = False
                gcuenta.Columns("idcont").Visible = False
            Case "1005"
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("impdes").Visible = True
                gcuenta.Columns("ivaxdev").Visible = True
                'NO
                gcuenta.Columns("concepto").Visible = False
                gcuenta.Columns("pais").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("dir").Visible = False
                gcuenta.Columns("dpto").Visible = False
                gcuenta.Columns("mcp").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
                gcuenta.Columns("tdcont").Visible = False
                gcuenta.Columns("idcont").Visible = False
            Case "1006"
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                'NO
                gcuenta.Columns("concepto").Visible = False
                gcuenta.Columns("pais").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("dir").Visible = False
                gcuenta.Columns("dpto").Visible = False
                gcuenta.Columns("mcp").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = True
                gcuenta.Columns("ivaxdev").Visible = True
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1007"
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("ingprop").Visible = True
                gcuenta.Columns("ingcons").Visible = True
                gcuenta.Columns("ingcont").Visible = True
                gcuenta.Columns("ingmin").Visible = True
                gcuenta.Columns("ingfid").Visible = True
                gcuenta.Columns("ingter").Visible = True
                gcuenta.Columns("devdes").Visible = True
                'NO
                gcuenta.Columns("concepto").Visible = False
                gcuenta.Columns("dpto").Visible = False
                gcuenta.Columns("mcp").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1008"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("salcxc").Visible = True
                'NO
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1009"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("salcxp").Visible = True
                'NO
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1010"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("vaporte").Visible = True
                gcuenta.Columns("ppart").Visible = True
                gcuenta.Columns("ppartd").Visible = True
                'NO
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1011"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("saldo").Visible = True
                'NO
                gcuenta.Columns("tipo_id").Visible = False
                gcuenta.Columns("num_id").Visible = False
                gcuenta.Columns("dv").Visible = False
                gcuenta.Columns("apell1").Visible = False
                gcuenta.Columns("apell2").Visible = False
                gcuenta.Columns("nom1").Visible = False
                gcuenta.Columns("nom2").Visible = False
                gcuenta.Columns("rsocial").Visible = False
                gcuenta.Columns("dir").Visible = False
                gcuenta.Columns("dpto").Visible = False
                gcuenta.Columns("mcp").Visible = False
                gcuenta.Columns("pais").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1012"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("valor").Visible = True
                'NO
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1013"
                gcuenta.Columns("tipfid").Visible = True
                gcuenta.Columns("subfid").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("vfide").Visible = True
                gcuenta.Columns("rendfide").Visible = True
                gcuenta.Columns("numfid").Visible = True
                'NO
                gcuenta.Columns("concepto").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("reteprac").Visible = False
                gcuenta.Columns("reteasu").Visible = False
                gcuenta.Columns("rtfcomun").Visible = False
                gcuenta.Columns("rtfsimp").Visible = False
                gcuenta.Columns("rtfNo").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("pago").Visible = False
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("ivacosto").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1014"
                gcuenta.Columns("tipfid").Visible = True
                gcuenta.Columns("subfid").Visible = True
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("pago").Visible = True
                gcuenta.Columns("ivacosto").Visible = True
                gcuenta.Columns("reteprac").Visible = True
                gcuenta.Columns("reteasu").Visible = True
                gcuenta.Columns("rtfcomun").Visible = True
                gcuenta.Columns("rtfsimp").Visible = True
                gcuenta.Columns("rtfNo").Visible = True
                gcuenta.Columns("idfid").Visible = True
                'NO
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("tdcont").Visible = False
                gcuenta.Columns("idcont").Visible = False
                gcuenta.Columns("ape1cont").Visible = False
                gcuenta.Columns("ape2cont").Visible = False
                gcuenta.Columns("nom1cont").Visible = False
                gcuenta.Columns("nom2cont").Visible = False
                gcuenta.Columns("rsocialcont").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1016"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("pago").Visible = True
                gcuenta.Columns("ivacosto").Visible = True
                gcuenta.Columns("reteprac").Visible = True
                gcuenta.Columns("reteasu").Visible = True
                gcuenta.Columns("rtfcomun").Visible = True
                gcuenta.Columns("rtfsimp").Visible = True
                gcuenta.Columns("rtfNo").Visible = True
                gcuenta.Columns("tdcont").Visible = True
                gcuenta.Columns("idcont").Visible = True
                gcuenta.Columns("ape1cont").Visible = True
                gcuenta.Columns("ape2cont").Visible = True
                gcuenta.Columns("nom1cont").Visible = True
                gcuenta.Columns("nom2cont").Visible = True
                gcuenta.Columns("rsocialcont").Visible = True
                'NO
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False
                gcuenta.Columns("ingbrut").Visible = False
                gcuenta.Columns("dvcont").Visible = False
            Case "1017"
                gcuenta.Columns("concepto").Visible = True
                gcuenta.Columns("tipo_id").Visible = True
                gcuenta.Columns("num_id").Visible = True
                gcuenta.Columns("dv").Visible = True
                gcuenta.Columns("apell1").Visible = True
                gcuenta.Columns("apell2").Visible = True
                gcuenta.Columns("nom1").Visible = True
                gcuenta.Columns("nom2").Visible = True
                gcuenta.Columns("rsocial").Visible = True
                gcuenta.Columns("dir").Visible = True
                gcuenta.Columns("dpto").Visible = True
                gcuenta.Columns("mcp").Visible = True
                gcuenta.Columns("pais").Visible = True
                gcuenta.Columns("pago").Visible = True
                gcuenta.Columns("ingbrut").Visible = True
                gcuenta.Columns("ivacosto").Visible = True
                gcuenta.Columns("dvcont").Visible = True
                gcuenta.Columns("reteprac").Visible = True
                gcuenta.Columns("reteasu").Visible = True
                gcuenta.Columns("rtfcomun").Visible = True
                gcuenta.Columns("rtfsimp").Visible = True
                gcuenta.Columns("rtfNo").Visible = True
                gcuenta.Columns("tdcont").Visible = True
                gcuenta.Columns("idcont").Visible = True
                gcuenta.Columns("ape1cont").Visible = True
                gcuenta.Columns("ape2cont").Visible = True
                gcuenta.Columns("nom1cont").Visible = True
                gcuenta.Columns("nom2cont").Visible = True
                gcuenta.Columns("rsocialcont").Visible = True
                'NO
                gcuenta.Columns("idfid").Visible = False
                gcuenta.Columns("tipfid").Visible = False
                gcuenta.Columns("subfid").Visible = False
                gcuenta.Columns("pagoD").Visible = False
                gcuenta.Columns("pagoN").Visible = False
                gcuenta.Columns("ivad").Visible = False
                gcuenta.Columns("ivaNd").Visible = False
                gcuenta.Columns("vartf").Visible = False
                gcuenta.Columns("tiprt").Visible = False
                gcuenta.Columns("impdes").Visible = False
                gcuenta.Columns("ivaxdev").Visible = False
                gcuenta.Columns("impgen").Visible = False
                gcuenta.Columns("ivaxdec").Visible = False
                gcuenta.Columns("ingprop").Visible = False
                gcuenta.Columns("ingcons").Visible = False
                gcuenta.Columns("ingcont").Visible = False
                gcuenta.Columns("ingmin").Visible = False
                gcuenta.Columns("ingfid").Visible = False
                gcuenta.Columns("ingter").Visible = False
                gcuenta.Columns("devdes").Visible = False
                gcuenta.Columns("salcxc").Visible = False
                gcuenta.Columns("salcxp").Visible = False
                gcuenta.Columns("vaporte").Visible = False
                gcuenta.Columns("ppart").Visible = False
                gcuenta.Columns("ppartd").Visible = False
                gcuenta.Columns("saldo").Visible = False
                gcuenta.Columns("valor").Visible = False
                gcuenta.Columns("vfide").Visible = False
                gcuenta.Columns("rendfide").Visible = False
                gcuenta.Columns("numfid").Visible = False



        End Select

    End Sub
    Dim c As Integer
    Private Sub cmbcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcon.SelectedIndexChanged
        If cmbcon.Text = "NO" Then
            txtcon.Text = UCase("No Tiene")
        Else
            Dim tabla As New DataTable
            tabla.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT  c.descr  FROM  formatos f, conceptos c " _
            & " WHERE c.codcon= '" & cmbcon.Text & "'  AND c.codfor='" & cmbForm.Text & "'"
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(tabla)
            Refresh()
            If tabla.Rows.Count > 0 Then
                txtcon.Text = UCase(tabla.Rows(0).Item("descr"))
            End If
        End If
       
    End Sub
    Private Sub Buscar1001()

        If gcuenta.RowCount <= 1 Then
            c = 0
        End If


        Dim cad As String = ""
        Dim cad1 As String = ""
        Dim cons As String = ""
        Dim tope As Double = 0

        If cmbcon.Text <> "NO" Then
            ' CON CONCEPTOS
            Dim t1 As New DataTable
            t1.Clear()
            myCommand.Parameters.Clear()
            myCommand.CommandText = "SELECT c.cuenta, s.descripcion, p.tope, c.mov FROM cta_conc c, selpuc s, conceptos p " _
            & " WHERE c.cuenta = s.codigo AND c.codfor ='" & cmbForm.Text & "' AND c.codcon = '" & cmbcon.Text & "' AND p.codcon=c.codcon AND p.codfor=c.codfor "
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(t1)
            Refresh()
            'gcuenta.Rows.Clear()
            If t1.Rows.Count = 0 Then
                MsgBox("Verifique las cuentas para el concepto " & cmbcon.Text & " - Formato " & cmbForm.Text, MsgBoxStyle.Information, "Verifique")
                Exit Sub
            Else
                Try
                    tope = CDbl(t1.Rows(0).Item("tope"))
                Catch ex As Exception
                    tope = CDbl(0)
                End Try
                If t1.Rows(0).Item("mov") = "sl" Then
                    cad1 = "d.debito-d.credito"
                ElseIf t1.Rows(0).Item("mov") = "db" Then
                    cad1 = "d.debito"
                ElseIf t1.Rows(0).Item("mov") = "cr" Then
                    cad1 = "d.credito"
                End If
                For j = 0 To t1.Rows.Count - 1
                    If j = 0 Then
                        cad = cad & " AND d.codigo LIKE '" & t1.Rows(j).Item("cuenta") & "%' "
                    Else
                        cad = cad & " OR  d.codigo LIKE '" & t1.Rows(j).Item("cuenta") & "%' "
                    End If
                Next
            End If

        End If


        cons = "SELECT IF(t.persona='natural','13','31') ti, c.nit, t.dv,  " _
        & " IF(t.persona='natural',t.apellidos,'') AS apel, " _
        & " IF(t.persona='natural',t.nombre,'') AS nomb, " _
        & " IF(t.persona='juridica',t.nombre,'') AS razon, t.dir, t.dept, RIGHT(t.mun,3) mun, t.pais, " _
        & " c.s AS s FROM ( " _
        & " SELECT s.nit, SUM(s.sm) as s FROM ("

        '.. Buscar
        Dim p As String = ""
        For i = 1 To 12
            If i < 10 Then
                p = "0" & i
            Else
                p = i
            End If
            If i <> 12 Then
                '        cons = cons & " SELECT SUM(d.debito-d.credito) AS sm, d.codigo, d.nit FROM documentos" & p & " d " _
                '& " WHERE  d.nit<>'' " & cad & " GROUP BY d.nit  UNION "
                cons = cons & " SELECT SUM(" & cad1 & ") AS sm, d.codigo, d.nit FROM documentos" & p & " d " _
 & " WHERE  d.nit<>'' " & cad & " GROUP BY d.nit  UNION "

            Else
                '          cons = cons & " SELECT SUM(d.debito-d.credito) AS sm, d.codigo, d.nit FROM documentos" & p & " d " _
                '& " WHERE  d.nit<>'' " & cad & " GROUP BY d.nit "
                cons = cons & " SELECT SUM(" & cad1 & ") AS sm, d.codigo, d.nit FROM documentos" & p & " d " _
                & " WHERE  d.nit<>'' " & cad & " GROUP BY d.nit "

            End If
        Next

        'cons = "SELECT IF(t.persona='natural','13','31') ti, c.nit, t.dv,  " _
        '& " IF(t.persona='natural',t.apellidos,'') AS apel, " _
        '& " IF(t.persona='natural',t.nombre,'') AS nomb, " _
        '& " IF(t.persona='juridica',t.nombre,'') AS razon, t.dir, t.dept, t.mun, t.pais, " _
        '& " SUM(c.s) AS s FROM ( "

        'cons = cons & " SELECT (d.debito-d.credito) AS s, d.codigo, d.nit FROM documentos01 d " _
        '& " WHERE  d.nit<>'' " & cad & " UNION " _
        '& " SELECT (d.debito-d.credito) AS s, d.codigo, d.nit FROM documentos02 d " _
        '& " WHERE  d.nit<>'' " & cad & " "

        cons = cons & " ) AS s  GROUP BY s.nit ) AS c , terceros t WHERE c.nit= t.nit "

        Dim t2 As New DataTable
        t2.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t2)
        Refresh()

        If c = 0 Then
            gcuenta.Rows.Clear()
            gcuenta.RowCount = t2.Rows.Count + 1
        Else
            gcuenta.RowCount = gcuenta.RowCount + t2.Rows.Count + 1
        End If
        'grilla vacia
        If t2.Rows.Count <> 0 Then
            'If c = 0 Then
            Me.Cursor = Cursors.WaitCursor
            mibarra.Value = 0
            mibarra.Visible = True
            mibarra.Maximum = t2.Rows.Count + 1
            Dim vtp As Double = 0
            For i = 0 To t2.Rows.Count - 1
                If CDbl(t2.Rows(i).Item("s")) < tope Then

                    vtp = vtp + CDbl(t2.Rows(i).Item("s"))
                    gcuenta.RowCount = gcuenta.RowCount - 1
                Else
                    gcuenta.Item("concepto", c).Value = cmbcon.Text
                    gcuenta.Item("tipo_id", c).Value = t2.Rows(i).Item("ti")
                    gcuenta.Item("num_id", c).Value = t2.Rows(i).Item("nit")
                    gcuenta.Item("dv", c).Value = t2.Rows(i).Item("dv")
                    gcuenta.Item("tipo_id", c).Value = t2.Rows(i).Item("ti")
                    gcuenta.Item("apell1", c).Value = retorno(Trim(t2.Rows(i).Item("apel")), 1)
                    gcuenta.Item("apell2", c).Value = retorno(Trim(t2.Rows(i).Item("apel")), 2)
                    gcuenta.Item("nom1", c).Value = retorno(Trim(t2.Rows(i).Item("nomb")), 1)
                    gcuenta.Item("nom2", c).Value = retorno(Trim(t2.Rows(i).Item("nomb")), 2)
                    gcuenta.Item("rsocial", c).Value = t2.Rows(i).Item("razon")
                    gcuenta.Item("dir", c).Value = t2.Rows(i).Item("dir")
                    gcuenta.Item("dpto", c).Value = t2.Rows(i).Item("dept")
                    gcuenta.Item("mcp", c).Value = t2.Rows(i).Item("mun")
                    gcuenta.Item("pais", c).Value = t2.Rows(i).Item("pais")
                    gcuenta.Item("pagoD", c).Value = t2.Rows(i).Item("s")
                    c = c + 1
                    mibarra.Value = mibarra.Value + 1
                End If
               
            Next
            If tope <> 0 Then
                Dim tc As New DataTable
                tc.Clear()
                myCommand.Parameters.Clear()
                myCommand.CommandText = "SELECT descripcion, direccion, dpto, RIGHT(mun,3) AS m FROM sae.companias WHERE login='" & FrmPrincipal.lbcompania.Text & "'"
                myAdapter.SelectCommand = myCommand
                myAdapter.Fill(tc)
                Refresh()
                Try
                    gcuenta.RowCount = gcuenta.RowCount + 1
                    gcuenta.Item("concepto", c).Value = cmbcon.Text
                    gcuenta.Item("tipo_id", c).Value = "43"
                    gcuenta.Item("num_id", c).Value = "222222222"
                    gcuenta.Item("dv", c).Value = ""
                    gcuenta.Item("tipo_id", c).Value = ""
                    gcuenta.Item("apell1", c).Value = ""
                    gcuenta.Item("apell2", c).Value = ""
                    gcuenta.Item("nom1", c).Value = ""
                    gcuenta.Item("nom2", c).Value = ""
                    gcuenta.Item("rsocial", c).Value = tc.Rows(0).Item("descripcion")
                    gcuenta.Item("dir", c).Value = tc.Rows(0).Item("direccion")
                    gcuenta.Item("dpto", c).Value = tc.Rows(0).Item("dpto")
                    gcuenta.Item("mcp", c).Value = tc.Rows(0).Item("m")
                    gcuenta.Item("pais", c).Value = "169"
                    gcuenta.Item("pagoD", c).Value = Moneda(vtp)
                    c = c + 1
                Catch ex As Exception
                End Try
            End If
            'End If
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
        End If


    End Sub
    Private Function retorno(ByRef camp As String, ByRef t As Integer)
        Dim cad As String = ""
        Dim retornar() As String
        retornar = camp.Split(" ")
        If t = 1 Then
            Try
                Return retornar(0)
            Catch ex As Exception
                Return ""
            End Try
        Else
            Try
                For d = 1 To retornar.Length - 1
                    cad = cad & retornar(d) & " "
                Next
                Return cad
            Catch ex As Exception
                Return ""
            End Try
        End If
    End Function



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        If cmbForm.Text = "" Then
            MsgBox("Verifique el codigo del Formato", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If
        If cmbcon.Text = "" Then
            MsgBox("Verifique el codigo del concepto", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If
        Try
            Select Case cmbForm.Text
                Case "1001"
                    Buscar1001()
            End Select
        Catch ex As Exception
            mibarra.Visible = False
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub BGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGuardar.Click
        If gcuenta.RowCount = 1 Then
            MsgBox("La tabla no puede estar vacia", MsgBoxStyle.Information, "Verifique")
            Exit Sub
        End If
        Guardar(cmbForm.Text)
    End Sub
    Private Sub Guardar(ByVal formato As String)
        Select Case formato
            Case "1001"
                G1001()
            Case "1003"
                G1003()
            Case "1005"
                G1005()
            Case "1006"
                G1006()
            Case "1007"
                G1007()
            Case "1008"
                G1008()
            Case "1009"
                G1009()
            Case "1010"
                G1010()
            Case "1011"
                G1011()
            Case "1012"
                G1012()
        End Select
    End Sub
    Private Sub G1012()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1012 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?valor", DIN(gcuenta.Item("valor", i).Value))
                myCommand.CommandText = "INSERT INTO  f1012 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?pais,?valor)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1011()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1011 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?saldo", DIN(gcuenta.Item("saldo", i).Value))
                myCommand.CommandText = "INSERT INTO  f1011 VALUES (?codcon,?saldo)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1010()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1010 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?vaporte", DIN(gcuenta.Item("vaporte", i).Value))
                myCommand.Parameters.AddWithValue("?ppart", DIN(gcuenta.Item("ppart", i).Value))
                myCommand.Parameters.AddWithValue("?ppartd", DIN(gcuenta.Item("ppartd", i).Value))
                myCommand.CommandText = "INSERT INTO  f1010 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?pais,?vaporte,?ppart,?ppartd)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1009()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1009 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?salcxp", DIN(gcuenta.Item("salcxp", i).Value))
                myCommand.CommandText = "INSERT INTO  f1009 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?pais,?salcxp)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1008()

        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1008 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?salcxc", DIN(gcuenta.Item("salcxc", i).Value))
                myCommand.CommandText = "INSERT INTO  f1008 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?pais,?salcxc)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1007()

        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1007 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?ingprop", DIN(gcuenta.Item("ingprop", i).Value))
                myCommand.Parameters.AddWithValue("?ingcons", DIN(gcuenta.Item("ingcons", i).Value))
                myCommand.Parameters.AddWithValue("?ingcont", DIN(gcuenta.Item("ingcont", i).Value))
                myCommand.Parameters.AddWithValue("?ingmin", DIN(gcuenta.Item("ingmin", i).Value))
                myCommand.Parameters.AddWithValue("?ingfid", DIN(gcuenta.Item("ingfid", i).Value))
                myCommand.Parameters.AddWithValue("?devdes", DIN(gcuenta.Item("devdes", i).Value))
                myCommand.CommandText = "INSERT INTO  f1007 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir," _
                & "?pais,?ingprop,?ingcons,?ingcont,?ingmin,?ingfid,?devdes)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()

    End Sub
    Private Sub G1006()
        MiConexion(bda)

        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1006 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?impgen", DIN(gcuenta.Item("impgen", i).Value))
                myCommand.Parameters.AddWithValue("?ivaxdec", DIN(gcuenta.Item("ivaxdec", i).Value))
                myCommand.CommandText = "INSERT INTO  f1006 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?impgen,?ivaxdec)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1005()
        MiConexion(bda)

        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1005 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?impdes", DIN(gcuenta.Item("impdes", i).Value))
                myCommand.Parameters.AddWithValue("?ivaxdev", DIN(gcuenta.Item("ivaxdev", i).Value))
                myCommand.CommandText = "INSERT INTO  f1005 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?impdes,?ivaxdev)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1003()
        MiConexion(bda)

        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1003 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?vartf", DIN(gcuenta.Item("vartf", i).Value))
                myCommand.Parameters.AddWithValue("?tiprt", DIN(gcuenta.Item("tiprt", i).Value))
                myCommand.CommandText = "INSERT INTO  f1003 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?vartf,?tiprt)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub
    Private Sub G1001()
        MiConexion(bda)
        myCommand.Parameters.Clear()
        myCommand.CommandText = " DELETE FROM f1001 WHERE codcon='" & cmbcon.Text & "'"
        myCommand.ExecuteNonQuery()

        mibarra.Value = 0
        mibarra.Visible = True
        mibarra.Maximum = gcuenta.RowCount
        For i = 0 To gcuenta.RowCount - 2
            myCommand.Parameters.Clear()
            If gcuenta.Item("concepto", i).Value <> "" Then
                myCommand.Parameters.AddWithValue("?codcon", gcuenta.Item("concepto", i).Value)
                myCommand.Parameters.AddWithValue("?tdoc", gcuenta.Item("tipo_id", i).Value)
                myCommand.Parameters.AddWithValue("?num_id", gcuenta.Item("num_id", i).Value)
                myCommand.Parameters.AddWithValue("?dv", gcuenta.Item("dv", i).Value)
                myCommand.Parameters.AddWithValue("?apell1", gcuenta.Item("apell1", i).Value)
                myCommand.Parameters.AddWithValue("?apell2", gcuenta.Item("apell2", i).Value)
                myCommand.Parameters.AddWithValue("?nom1", gcuenta.Item("nom1", i).Value)
                myCommand.Parameters.AddWithValue("?nom2", gcuenta.Item("nom2", i).Value)
                myCommand.Parameters.AddWithValue("?rsocial", gcuenta.Item("rsocial", i).Value)
                myCommand.Parameters.AddWithValue("?dir", gcuenta.Item("dir", i).Value)
                myCommand.Parameters.AddWithValue("?dpto", gcuenta.Item("dpto", i).Value)
                myCommand.Parameters.AddWithValue("?mcp", gcuenta.Item("mcp", i).Value)
                myCommand.Parameters.AddWithValue("?pais", gcuenta.Item("pais", i).Value)
                myCommand.Parameters.AddWithValue("?pagod", DIN(gcuenta.Item("pagoD", i).Value))
                myCommand.Parameters.AddWithValue("?pagon", DIN(gcuenta.Item("pagoN", i).Value))
                myCommand.Parameters.AddWithValue("?ivad", DIN(gcuenta.Item("ivad", i).Value))
                myCommand.Parameters.AddWithValue("?ivand", DIN(gcuenta.Item("ivaNd", i).Value))
                myCommand.Parameters.AddWithValue("?rtprac", DIN(gcuenta.Item("reteprac", i).Value))
                myCommand.Parameters.AddWithValue("?rtasu", DIN(gcuenta.Item("reteasu", i).Value))
                myCommand.Parameters.AddWithValue("?rtcomun", DIN(gcuenta.Item("rtfcomun", i).Value))
                myCommand.Parameters.AddWithValue("?rtsimp", DIN(gcuenta.Item("rtfsimp", i).Value))
                myCommand.Parameters.AddWithValue("?rtno", DIN(gcuenta.Item("rtfNo", i).Value))
                myCommand.CommandText = "INSERT INTO  f1001 VALUES (?codcon,?tdoc,?num_id,?dv,?apell1,?apell2,?nom1,?nom2,?rsocial,?dir,?dpto," _
                & "?mcp,?pais,?pagod,?pagon,?ivad,?ivand,?rtprac,?rtasu,?rtcomun,?rtsimp,?rtno)"
                myCommand.ExecuteNonQuery()
                Refresh()
                mibarra.Value = mibarra.Value + 1
            End If
        Next
        mibarra.Visible = False
        MsgBox("Datos Guardados", MsgBoxStyle.Information, "Verificacion")
        Cerrar()
    End Sub

    Private Sub bImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImp.Click

        If cmbForm.Text = "" Then
            MsgBox("Verifique el numero del formato", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        ElseIf cmbcon.Text = "" Then
            MsgBox("Verifique el numero del concepto", MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If
        Dim cons As String = ""
        cons = "SELECT * FROM f" & cmbForm.Text & " WHERE codcon='" & cmbcon.Text & "'"

        Select Case cmbForm.Text
            Case "1001"
                L1001(cons)
            Case "1003"
                L1003(cons)
            Case "1005"
                L1005(cons)
            Case "1006"
                L1006(cons)
            Case "1007"
                L1007(cons)
            Case "1008"
                L1008(cons)
            Case "1009"
                L1009(cons)
            Case "1010"
                L1010(cons)
            Case "1011"
                L1011(cons)
            Case "1012"
                L1012(cons)
        End Select
    End Sub
    Private Sub L1001(ByVal cons As String)

        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("pagoD", j).Value = t1.Rows(j).Item("pagod")
            gcuenta.Item("pagoN", j).Value = t1.Rows(j).Item("pagon")
            gcuenta.Item("ivad", j).Value = t1.Rows(j).Item("ivad")
            gcuenta.Item("ivaNd", j).Value = t1.Rows(j).Item("ivand")
            gcuenta.Item("reteprac", j).Value = t1.Rows(j).Item("rtprac")
            gcuenta.Item("reteasu", j).Value = t1.Rows(j).Item("rtasu")
            gcuenta.Item("rtfcomun", j).Value = t1.Rows(j).Item("rtcomun")
            gcuenta.Item("rtfsimp", j).Value = t1.Rows(j).Item("rtsimp")
            gcuenta.Item("rtfNo", j).Value = t1.Rows(j).Item("rtno")
        Next
    End Sub
    Private Sub L1003(ByVal cons As String)

        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("vartf", j).Value = t1.Rows(j).Item("vartf")
            gcuenta.Item("tiprt", j).Value = t1.Rows(j).Item("tiprt")
        Next
    End Sub
    Private Sub L1005(ByVal cons As String)

        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("pagoD", j).Value = t1.Rows(j).Item("pagod")
            gcuenta.Item("pagoN", j).Value = t1.Rows(j).Item("pagon")
            gcuenta.Item("ivad", j).Value = t1.Rows(j).Item("ivad")
            gcuenta.Item("ivaNd", j).Value = t1.Rows(j).Item("ivand")
            gcuenta.Item("reteprac", j).Value = t1.Rows(j).Item("rtprac")
            gcuenta.Item("reteasu", j).Value = t1.Rows(j).Item("rtasu")
            gcuenta.Item("rtfcomun", j).Value = t1.Rows(j).Item("rtcomun")
            gcuenta.Item("rtfsimp", j).Value = t1.Rows(j).Item("rtsimp")
            gcuenta.Item("rtfNo", j).Value = t1.Rows(j).Item("rtno")
        Next
    End Sub
    Private Sub L1006(ByVal cons As String)

        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("impgen", j).Value = t1.Rows(j).Item("impgen")
            gcuenta.Item("ivaxdec", j).Value = t1.Rows(j).Item("ivaxdec")
        Next
        
    End Sub
    Private Sub L1007(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("ingprop", j).Value = t1.Rows(j).Item("ingprop")
            gcuenta.Item("ingcons", j).Value = t1.Rows(j).Item("ingcons")
            gcuenta.Item("ingcont", j).Value = t1.Rows(j).Item("ingcont")
            gcuenta.Item("ingmin", j).Value = t1.Rows(j).Item("ingmin")
            gcuenta.Item("ingfid", j).Value = t1.Rows(j).Item("ingfid")
            gcuenta.Item("ingter", j).Value = t1.Rows(j).Item("ingter")
            gcuenta.Item("devdes", j).Value = t1.Rows(j).Item("devdes")
        Next
    End Sub
    Private Sub L1008(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("salcxc", j).Value = t1.Rows(j).Item("salcxc")
        Next
    End Sub
    Private Sub L1009(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("salcxc", j).Value = t1.Rows(j).Item("salcxp")
        Next
    End Sub
    Private Sub L1010(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("vaporte", j).Value = t1.Rows(j).Item("vaporte")
            gcuenta.Item("ppart", j).Value = t1.Rows(j).Item("ppart")
            gcuenta.Item("ppartd", j).Value = t1.Rows(j).Item("ppartd")
        Next
    End Sub
    Private Sub L1011(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("saldo", j).Value = t1.Rows(j).Item("saldo")
        Next
    End Sub
    Private Sub L1012(ByVal cons As String)
        Dim t1 As New DataTable
        t1.Clear()
        myCommand.Parameters.Clear()
        myCommand.CommandText = cons
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(t1)
        Refresh()
        If t1.Rows.Count = 0 Then
            MsgBox("No existen datos para importar, para el formato " & cmbForm.Text & " y el Concepto " & cmbcon.Text, MsgBoxStyle.Information, "Verificacion")
            Exit Sub
        End If

        gcuenta.RowCount = t1.Rows.Count + 1
        For j = 0 To t1.Rows.Count - 1
            gcuenta.Item("concepto", j).Value = t1.Rows(j).Item("codcon")
            gcuenta.Item("tipo_id", j).Value = t1.Rows(j).Item("tdoc")
            gcuenta.Item("num_id", j).Value = t1.Rows(j).Item("num_id")
            gcuenta.Item("dv", j).Value = t1.Rows(j).Item("dv")
            gcuenta.Item("apell1", j).Value = t1.Rows(j).Item("apell1")
            gcuenta.Item("apell2", j).Value = t1.Rows(j).Item("apell2")
            gcuenta.Item("nom1", j).Value = t1.Rows(j).Item("nom1")
            gcuenta.Item("nom2", j).Value = t1.Rows(j).Item("nom2")
            gcuenta.Item("rsocial", j).Value = t1.Rows(j).Item("rsocial")
            gcuenta.Item("dir", j).Value = t1.Rows(j).Item("dir")
            gcuenta.Item("dpto", j).Value = t1.Rows(j).Item("dpto")
            gcuenta.Item("mcp", j).Value = t1.Rows(j).Item("mcp")
            gcuenta.Item("pais", j).Value = t1.Rows(j).Item("pais")
            gcuenta.Item("valor", j).Value = t1.Rows(j).Item("valor")
        Next
    End Sub

    Private Sub Bcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcan.Click
        gcuenta.Rows.Clear()
    End Sub
End Class