<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenCompra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenCompra))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gfactura = New System.Windows.Forms.DataGridView
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.recibida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacven = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaiva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtfecha = New System.Windows.Forms.DateTimePicker
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.txtfecha_ent = New System.Windows.Forms.DateTimePicker
        Me.lbformat = New System.Windows.Forms.Label
        Me.lbcanfact = New System.Windows.Forms.Label
        Me.lbimpap = New System.Windows.Forms.Label
        Me.lbsolnumcom = New System.Windows.Forms.Label
        Me.lbaumenta = New System.Windows.Forms.Label
        Me.lbintcont = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmditems = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.cmdnuevo_rep = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtret = New System.Windows.Forms.Label
        Me.valorret = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.gfp = New System.Windows.Forms.DataGridView
        Me.cual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbdocajuste = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.Label
        Me.lbprint = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.Label
        Me.txtdescuento = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbsubtotal = New System.Windows.Forms.Label
        Me.lbusuario = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.valoriva = New System.Windows.Forms.TextBox
        Me.valordes = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.imprimir = New System.Drawing.Printing.PrintDocument
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtobservaciones = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtflete = New System.Windows.Forms.TextBox
        Me.Gparametros = New System.Windows.Forms.GroupBox
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gfp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Gparametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'gfactura
        '
        Me.gfactura.AllowUserToAddRows = False
        Me.gfactura.AllowUserToDeleteRows = False
        Me.gfactura.AllowUserToResizeColumns = False
        Me.gfactura.AllowUserToResizeRows = False
        Me.gfactura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gfactura.ColumnHeadersVisible = False
        Me.gfactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.codigo, Me.descrip, Me.cant, Me.recibida, Me.valor, Me.Vtotal, Me.tipo, Me.bodega, Me.cc, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.iva, Me.costo})
        Me.gfactura.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura.Location = New System.Drawing.Point(15, 240)
        Me.gfactura.Name = "gfactura"
        Me.gfactura.RowHeadersVisible = False
        Me.gfactura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura.Size = New System.Drawing.Size(675, 111)
        Me.gfactura.TabIndex = 8
        '
        'num
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
        Me.num.Frozen = True
        Me.num.HeaderText = "NÚM"
        Me.num.MinimumWidth = 40
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.num.Width = 40
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 80
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.Width = 80
        '
        'descrip
        '
        Me.descrip.Frozen = True
        Me.descrip.HeaderText = "DESCRIPCIÓN"
        Me.descrip.MinimumWidth = 180
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descrip.Width = 180
        '
        'cant
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle2
        Me.cant.Frozen = True
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.MinimumWidth = 80
        Me.cant.Name = "cant"
        Me.cant.ReadOnly = True
        Me.cant.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cant.Width = 80
        '
        'recibida
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.recibida.DefaultCellStyle = DataGridViewCellStyle3
        Me.recibida.Frozen = True
        Me.recibida.HeaderText = "RECIBIDA"
        Me.recibida.MinimumWidth = 70
        Me.recibida.Name = "recibida"
        Me.recibida.Width = 70
        '
        'valor
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle4
        Me.valor.Frozen = True
        Me.valor.HeaderText = "V. UNI"
        Me.valor.MinimumWidth = 100
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Vtotal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Vtotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.Vtotal.Frozen = True
        Me.Vtotal.HeaderText = "V. TOTAL"
        Me.Vtotal.MinimumWidth = 100
        Me.Vtotal.Name = "Vtotal"
        Me.Vtotal.ReadOnly = True
        Me.Vtotal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'tipo
        '
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.MinimumWidth = 20
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        Me.tipo.Width = 20
        '
        'bodega
        '
        Me.bodega.Frozen = True
        Me.bodega.HeaderText = "BODEGA"
        Me.bodega.Name = "bodega"
        Me.bodega.ReadOnly = True
        Me.bodega.Visible = False
        '
        'cc
        '
        Me.cc.Frozen = True
        Me.cc.HeaderText = "cc"
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.Visible = False
        '
        'ctainv
        '
        Me.ctainv.Frozen = True
        Me.ctainv.HeaderText = "ctainv"
        Me.ctainv.Name = "ctainv"
        Me.ctainv.ReadOnly = True
        Me.ctainv.Visible = False
        '
        'ctacven
        '
        Me.ctacven.Frozen = True
        Me.ctacven.HeaderText = "ctacven"
        Me.ctacven.Name = "ctacven"
        Me.ctacven.ReadOnly = True
        Me.ctacven.Visible = False
        '
        'ctaing
        '
        Me.ctaing.Frozen = True
        Me.ctaing.HeaderText = "ctaing"
        Me.ctaing.Name = "ctaing"
        Me.ctaing.ReadOnly = True
        Me.ctaing.Visible = False
        '
        'ctaiva
        '
        Me.ctaiva.Frozen = True
        Me.ctaiva.HeaderText = "ctaiva"
        Me.ctaiva.Name = "ctaiva"
        Me.ctaiva.ReadOnly = True
        Me.ctaiva.Visible = False
        '
        'iva
        '
        Me.iva.Frozen = True
        Me.iva.HeaderText = "iva"
        Me.iva.Name = "iva"
        Me.iva.Visible = False
        '
        'costo
        '
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'txtfecha
        '
        Me.txtfecha.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha.Location = New System.Drawing.Point(170, 153)
        Me.txtfecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtfecha, "fecha del pedido")
        Me.txtfecha.Value = New Date(2011, 7, 30, 0, 0, 0, 0)
        '
        'txtnitc
        '
        Me.txtnitc.Location = New System.Drawing.Point(170, 122)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.ShortcutsEnabled = False
        Me.txtnitc.Size = New System.Drawing.Size(119, 20)
        Me.txtnitc.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtnitc, "nit cliente")
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.Enabled = False
        Me.txtnumfac.Location = New System.Drawing.Point(170, 93)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(120, 20)
        Me.txtnumfac.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtnumfac, "numero factura")
        '
        'txtfecha_ent
        '
        Me.txtfecha_ent.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha_ent.Location = New System.Drawing.Point(170, 183)
        Me.txtfecha_ent.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha_ent.Name = "txtfecha_ent"
        Me.txtfecha_ent.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha_ent.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.txtfecha_ent, "fecha de entrega")
        Me.txtfecha_ent.Value = New Date(2011, 7, 30, 0, 0, 0, 0)
        '
        'lbformat
        '
        Me.lbformat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbformat.Location = New System.Drawing.Point(79, 40)
        Me.lbformat.Name = "lbformat"
        Me.lbformat.Size = New System.Drawing.Size(41, 19)
        Me.lbformat.TabIndex = 117
        Me.lbformat.Text = "tickect"
        Me.ToolTip1.SetToolTip(Me.lbformat, "formato para imprimir")
        '
        'lbcanfact
        '
        Me.lbcanfact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcanfact.Location = New System.Drawing.Point(79, 16)
        Me.lbcanfact.Name = "lbcanfact"
        Me.lbcanfact.Size = New System.Drawing.Size(30, 19)
        Me.lbcanfact.TabIndex = 116
        Me.lbcanfact.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbcanfact, "can fact teniendo en cuenta la retencion")
        '
        'lbimpap
        '
        Me.lbimpap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbimpap.Location = New System.Drawing.Point(45, 41)
        Me.lbimpap.Name = "lbimpap"
        Me.lbimpap.Size = New System.Drawing.Size(28, 19)
        Me.lbimpap.TabIndex = 115
        Me.lbimpap.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbimpap, "imptrimir solo facturas aprobadas")
        '
        'lbsolnumcom
        '
        Me.lbsolnumcom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbsolnumcom.Location = New System.Drawing.Point(43, 16)
        Me.lbsolnumcom.Name = "lbsolnumcom"
        Me.lbsolnumcom.Size = New System.Drawing.Size(30, 19)
        Me.lbsolnumcom.TabIndex = 114
        Me.lbsolnumcom.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbsolnumcom, "solicitar numerode comprobante")
        '
        'lbaumenta
        '
        Me.lbaumenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbaumenta.Location = New System.Drawing.Point(9, 41)
        Me.lbaumenta.Name = "lbaumenta"
        Me.lbaumenta.Size = New System.Drawing.Size(28, 19)
        Me.lbaumenta.TabIndex = 113
        Me.lbaumenta.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbaumenta, "fletes y seguros aumentan costos del inventario")
        '
        'lbintcont
        '
        Me.lbintcont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbintcont.Location = New System.Drawing.Point(7, 16)
        Me.lbintcont.Name = "lbintcont"
        Me.lbintcont.Size = New System.Drawing.Size(30, 19)
        Me.lbintcont.TabIndex = 110
        Me.lbintcont.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbintcont, "¿interfaz contable?")
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.White
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdPrint.Location = New System.Drawing.Point(618, 145)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(63, 66)
        Me.cmdPrint.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Imprimir ")
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.Color.White
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.notas2
        Me.cmditems.Location = New System.Drawing.Point(543, 145)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(63, 66)
        Me.cmditems.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmditems, "editar items")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(602, 14)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(218, 14)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "modificar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(112, 14)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(551, 14)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(500, 14)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 13
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(377, 14)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(165, 14)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(449, 14)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(271, 14)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Enabled = False
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(324, 14)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "buscar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(6, 14)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdnuevo_rep
        '
        Me.cmdnuevo_rep.Image = Global.SAE.My.Resources.Resources.nuevo_r
        Me.cmdnuevo_rep.Location = New System.Drawing.Point(59, 14)
        Me.cmdnuevo_rep.Name = "cmdnuevo_rep"
        Me.cmdnuevo_rep.Size = New System.Drawing.Size(52, 38)
        Me.cmdnuevo_rep.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdnuevo_rep, "Nuevo Registro Apartir del Actual")
        Me.cmdnuevo_rep.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label25.Location = New System.Drawing.Point(22, 470)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 13)
        Me.Label25.TabIndex = 294
        Me.Label25.Text = "Fletes"
        '
        'txtret
        '
        Me.txtret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtret.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtret.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtret.Location = New System.Drawing.Point(153, 416)
        Me.txtret.Name = "txtret"
        Me.txtret.Size = New System.Drawing.Size(119, 20)
        Me.txtret.TabIndex = 293
        Me.txtret.Text = "0,00"
        Me.txtret.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'valorret
        '
        Me.valorret.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.valorret.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valorret.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.valorret.Location = New System.Drawing.Point(90, 413)
        Me.valorret.MaxLength = 5
        Me.valorret.Name = "valorret"
        Me.valorret.ShortcutsEnabled = False
        Me.valorret.Size = New System.Drawing.Size(42, 20)
        Me.valorret.TabIndex = 10
        Me.valorret.Text = "0,00"
        Me.valorret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label22.Location = New System.Drawing.Point(22, 416)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 289
        Me.Label22.Text = "Retención"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label23.Location = New System.Drawing.Point(134, 417)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 16)
        Me.Label23.TabIndex = 292
        Me.Label23.Text = "%"
        '
        'gfp
        '
        Me.gfp.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gfp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cual, Me.detalle, Me.tt, Me.banco, Me.numero, Me.monto})
        Me.gfp.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfp.Location = New System.Drawing.Point(4, 583)
        Me.gfp.Name = "gfp"
        Me.gfp.RowHeadersVisible = False
        Me.gfp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfp.Size = New System.Drawing.Size(501, 55)
        Me.gfp.TabIndex = 272
        Me.gfp.Visible = False
        '
        'cual
        '
        DataGridViewCellStyle6.NullValue = Nothing
        Me.cual.DefaultCellStyle = DataGridViewCellStyle6
        Me.cual.Frozen = True
        Me.cual.HeaderText = "TIPO"
        Me.cual.MinimumWidth = 70
        Me.cual.Name = "cual"
        Me.cual.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.cual.Width = 70
        '
        'detalle
        '
        Me.detalle.Frozen = True
        Me.detalle.HeaderText = "DESCRIPCIÓN"
        Me.detalle.MinimumWidth = 90
        Me.detalle.Name = "detalle"
        Me.detalle.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.detalle.Width = 90
        '
        'tt
        '
        Me.tt.Frozen = True
        Me.tt.HeaderText = "TT"
        Me.tt.Name = "tt"
        Me.tt.Width = 30
        '
        'banco
        '
        Me.banco.Frozen = True
        Me.banco.HeaderText = "BANCO"
        Me.banco.Name = "banco"
        '
        'numero
        '
        Me.numero.Frozen = True
        Me.numero.HeaderText = "NUMERO"
        Me.numero.Name = "numero"
        '
        'monto
        '
        DataGridViewCellStyle7.NullValue = Nothing
        Me.monto.DefaultCellStyle = DataGridViewCellStyle7
        Me.monto.Frozen = True
        Me.monto.HeaderText = "VALOR"
        Me.monto.MinimumWidth = 80
        Me.monto.Name = "monto"
        Me.monto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.monto.Width = 80
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.cuenta, Me.base})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(1, 684)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(653, 66)
        Me.grilla.TabIndex = 285
        Me.grilla.Visible = False
        '
        'Descripcion
        '
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle8
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 500
        Me.Descripcion.MinimumWidth = 250
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 250
        '
        'Debitos
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle9
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle10
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.Name = "Creditos"
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cuenta
        '
        Me.cuenta.FillWeight = 80.0!
        Me.cuenta.HeaderText = "Cuenta"
        Me.cuenta.MaxInputLength = 20
        Me.cuenta.Name = "cuenta"
        Me.cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cuenta.Width = 80
        '
        'base
        '
        Me.base.HeaderText = "base"
        Me.base.Name = "base"
        '
        'lbdocajuste
        '
        Me.lbdocajuste.AutoSize = True
        Me.lbdocajuste.Location = New System.Drawing.Point(211, 7)
        Me.lbdocajuste.Name = "lbdocajuste"
        Me.lbdocajuste.Size = New System.Drawing.Size(56, 13)
        Me.lbdocajuste.TabIndex = 286
        Me.lbdocajuste.Text = "doc ajuste"
        Me.lbdocajuste.Visible = False
        '
        'txtiva
        '
        Me.txtiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtiva.Location = New System.Drawing.Point(153, 441)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(119, 20)
        Me.txtiva.TabIndex = 282
        Me.txtiva.Text = "0,00"
        Me.txtiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(153, 364)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(119, 20)
        Me.txtsubtotal.TabIndex = 280
        Me.txtsubtotal.Text = "0,00"
        Me.txtsubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbprint
        '
        Me.lbprint.AutoSize = True
        Me.lbprint.BackColor = System.Drawing.Color.Transparent
        Me.lbprint.Font = New System.Drawing.Font("Courier New", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbprint.ForeColor = System.Drawing.Color.Black
        Me.lbprint.Location = New System.Drawing.Point(289, 12)
        Me.lbprint.Name = "lbprint"
        Me.lbprint.Size = New System.Drawing.Size(30, 8)
        Me.lbprint.TabIndex = 287
        Me.lbprint.Text = "print"
        Me.lbprint.Visible = False
        '
        'txttotal
        '
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Red
        Me.txttotal.Location = New System.Drawing.Point(153, 502)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(119, 20)
        Me.txttotal.TabIndex = 283
        Me.txttotal.Text = "0,00"
        Me.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdescuento
        '
        Me.txtdescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtdescuento.Location = New System.Drawing.Point(153, 390)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(119, 20)
        Me.txtdescuento.TabIndex = 281
        Me.txtdescuento.Text = "0,00"
        Me.txtdescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(321, 470)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 274
        Me.Label4.Text = "Generado por el usuario:"
        '
        'lbsubtotal
        '
        Me.lbsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsubtotal.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbsubtotal.Location = New System.Drawing.Point(562, 350)
        Me.lbsubtotal.Name = "lbsubtotal"
        Me.lbsubtotal.Size = New System.Drawing.Size(128, 20)
        Me.lbsubtotal.TabIndex = 275
        Me.lbsubtotal.Text = "0,00"
        Me.lbsubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbsubtotal.Visible = False
        '
        'lbusuario
        '
        Me.lbusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuario.Location = New System.Drawing.Point(444, 470)
        Me.lbusuario.Name = "lbusuario"
        Me.lbusuario.Size = New System.Drawing.Size(246, 20)
        Me.lbusuario.TabIndex = 273
        Me.lbusuario.Text = "usuario"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(15, 3)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 22)
        Me.lbestado.TabIndex = 270
        Me.lbestado.Text = "Estado"
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(635, 8)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 269
        Me.lbnumero.Text = "0000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(551, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 268
        Me.Label18.Text = "Registro Nro."
        '
        'valoriva
        '
        Me.valoriva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.valoriva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valoriva.ForeColor = System.Drawing.Color.SteelBlue
        Me.valoriva.Location = New System.Drawing.Point(90, 438)
        Me.valoriva.MaxLength = 5
        Me.valoriva.Name = "valoriva"
        Me.valoriva.ReadOnly = True
        Me.valoriva.ShortcutsEnabled = False
        Me.valoriva.Size = New System.Drawing.Size(42, 20)
        Me.valoriva.TabIndex = 11
        Me.valoriva.Text = "0,00"
        Me.valoriva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'valordes
        '
        Me.valordes.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.valordes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valordes.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.valordes.Location = New System.Drawing.Point(90, 387)
        Me.valordes.MaxLength = 5
        Me.valordes.Name = "valordes"
        Me.valordes.ShortcutsEnabled = False
        Me.valordes.Size = New System.Drawing.Size(42, 20)
        Me.valordes.TabIndex = 9
        Me.valordes.Text = "0,00"
        Me.valordes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(16, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(674, 23)
        Me.Label13.TabIndex = 256
        Me.Label13.Text = "NÚM.  CODIGO       DESCRIPCIÓN                    CANTIDAD    RECIBIDA   V. UNITA" & _
            "RIO    V. TOTAL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(22, 441)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "I.V.A."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Crimson
        Me.Label10.Location = New System.Drawing.Point(21, 499)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 20)
        Me.Label10.TabIndex = 253
        Me.Label10.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label8.Location = New System.Drawing.Point(22, 390)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Location = New System.Drawing.Point(22, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "Sub Total"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(298, 122)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(383, 20)
        Me.txtcliente.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 16)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Nit/Cedula Proveedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 247
        Me.Label3.Text = "Fecha Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 245
        Me.Label2.Text = "Número Pedido"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.cmdnuevo_rep)
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.CmdEditar)
        Me.GroupBox1.Controls.Add(Me.CmdListo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdSalir)
        Me.GroupBox1.Controls.Add(Me.CmdCancelar)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.cmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label15.Location = New System.Drawing.Point(134, 442)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 262
        Me.Label15.Text = "%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label14.Location = New System.Drawing.Point(134, 391)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 16)
        Me.Label14.TabIndex = 260
        Me.Label14.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label11.Location = New System.Drawing.Point(134, 458)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 42)
        Me.Label11.TabIndex = 254
        Me.Label11.Text = "_______"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 305
        Me.Label1.Text = "Fecha Entrega"
        '
        'txtobservaciones
        '
        Me.txtobservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservaciones.Location = New System.Drawing.Point(320, 403)
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(370, 54)
        Me.txtobservaciones.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(321, 380)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 20)
        Me.Label12.TabIndex = 307
        Me.Label12.Text = "Observaciones"
        '
        'txtflete
        '
        Me.txtflete.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtflete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtflete.Enabled = False
        Me.txtflete.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtflete.Location = New System.Drawing.Point(153, 467)
        Me.txtflete.Name = "txtflete"
        Me.txtflete.ShortcutsEnabled = False
        Me.txtflete.Size = New System.Drawing.Size(119, 20)
        Me.txtflete.TabIndex = 12
        Me.txtflete.Text = "0,00"
        Me.txtflete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Gparametros
        '
        Me.Gparametros.Controls.Add(Me.lbformat)
        Me.Gparametros.Controls.Add(Me.lbcanfact)
        Me.Gparametros.Controls.Add(Me.lbimpap)
        Me.Gparametros.Controls.Add(Me.lbsolnumcom)
        Me.Gparametros.Controls.Add(Me.lbaumenta)
        Me.Gparametros.Controls.Add(Me.lbintcont)
        Me.Gparametros.Location = New System.Drawing.Point(532, 583)
        Me.Gparametros.Name = "Gparametros"
        Me.Gparametros.Size = New System.Drawing.Size(137, 67)
        Me.Gparametros.TabIndex = 308
        Me.Gparametros.TabStop = False
        Me.Gparametros.Text = "parametros"
        Me.Gparametros.Visible = False
        '
        'FrmOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(700, 539)
        Me.Controls.Add(Me.Gparametros)
        Me.Controls.Add(Me.txtflete)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtobservaciones)
        Me.Controls.Add(Me.txtfecha_ent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gfactura)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtret)
        Me.Controls.Add(Me.valorret)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.gfp)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.lbdocajuste)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.lbprint)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbusuario)
        Me.Controls.Add(Me.txtfecha)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.valoriva)
        Me.Controls.Add(Me.valordes)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmditems)
        Me.Controls.Add(Me.txtcliente)
        Me.Controls.Add(Me.txtnitc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtnumfac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbsubtotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOrdenCompra"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Pedidos / Ordenes de Compras"
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gfp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Gparametros.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gfactura As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents txtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtret As System.Windows.Forms.Label
    Friend WithEvents valorret As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents gfp As System.Windows.Forms.DataGridView
    Friend WithEvents cual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbdocajuste As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.Label
    Friend WithEvents lbprint As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbsubtotal As System.Windows.Forms.Label
    Friend WithEvents lbusuario As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents valoriva As System.Windows.Forms.TextBox
    Friend WithEvents valordes As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imprimir As System.Drawing.Printing.PrintDocument
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtfecha_ent As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtflete As System.Windows.Forms.TextBox
    Friend WithEvents Gparametros As System.Windows.Forms.GroupBox
    Friend WithEvents lbformat As System.Windows.Forms.Label
    Friend WithEvents lbcanfact As System.Windows.Forms.Label
    Friend WithEvents lbimpap As System.Windows.Forms.Label
    Friend WithEvents lbsolnumcom As System.Windows.Forms.Label
    Friend WithEvents lbaumenta As System.Windows.Forms.Label
    Friend WithEvents lbintcont As System.Windows.Forms.Label
    Friend WithEvents cmdnuevo_rep As System.Windows.Forms.Button
End Class
