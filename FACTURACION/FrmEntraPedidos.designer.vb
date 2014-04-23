<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntraPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntraPedidos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.valoriva = New System.Windows.Forms.TextBox
        Me.valordes = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtnitv = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.txtnumped = New System.Windows.Forms.TextBox
        Me.txtfechaped = New System.Windows.Forms.DateTimePicker
        Me.txtfechaent = New System.Windows.Forms.DateTimePicker
        Me.cmdentrega = New System.Windows.Forms.Button
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
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.lbcontrolprecio = New System.Windows.Forms.Label
        Me.lbformula = New System.Windows.Forms.Label
        Me.lbprecioiva = New System.Windows.Forms.Label
        Me.lbnumbod = New System.Windows.Forms.Label
        Me.lbmargen = New System.Windows.Forms.Label
        Me.lbcomicion = New System.Windows.Forms.Label
        Me.lbcc = New System.Windows.Forms.Label
        Me.txtnitc2 = New System.Windows.Forms.TextBox
        Me.txtnitv2 = New System.Windows.Forms.TextBox
        Me.txttotal2 = New System.Windows.Forms.TextBox
        Me.txtfechaped2 = New System.Windows.Forms.TextBox
        Me.txtobs2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtvendedor = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lbusuario = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbtipo = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbsubtotal = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.Label
        Me.txtdescuento = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gfactura = New System.Windows.Forms.DataGridView
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.imprimir = New System.Drawing.Printing.PrintDocument
        Me.Gparametros = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.valordes2 = New System.Windows.Forms.TextBox
        Me.gfactura2 = New System.Windows.Forms.DataGridView
        Me.codigo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bodega2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbespera = New System.Windows.Forms.Label
        Me.lblform = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gparametros.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gfactura2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(10, 6)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(246, 22)
        Me.lbestado.TabIndex = 100
        Me.lbestado.Text = "NULO"
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(611, 7)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(14, 13)
        Me.lbnumero.TabIndex = 98
        Me.lbnumero.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(527, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Registro Nro."
        '
        'valoriva
        '
        Me.valoriva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.valoriva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valoriva.ForeColor = System.Drawing.Color.SteelBlue
        Me.valoriva.Location = New System.Drawing.Point(94, 457)
        Me.valoriva.MaxLength = 5
        Me.valoriva.Name = "valoriva"
        Me.valoriva.ReadOnly = True
        Me.valoriva.ShortcutsEnabled = False
        Me.valoriva.Size = New System.Drawing.Size(42, 20)
        Me.valoriva.TabIndex = 85
        Me.valoriva.Text = "16,00"
        Me.valoriva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'valordes
        '
        Me.valordes.BackColor = System.Drawing.Color.White
        Me.valordes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valordes.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.valordes.Location = New System.Drawing.Point(94, 431)
        Me.valordes.MaxLength = 5
        Me.valordes.Name = "valordes"
        Me.valordes.ShortcutsEnabled = False
        Me.valordes.Size = New System.Drawing.Size(42, 20)
        Me.valordes.TabIndex = 84
        Me.valordes.Text = "0,00"
        Me.valordes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(10, 255)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(645, 23)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "NÚM.    CODIGO          DESCRIPCIÓN                          CANTIDAD       V. UN" & _
            "ITARIO       V. TOTAL"
        '
        'txtnitv
        '
        Me.txtnitv.Location = New System.Drawing.Point(125, 151)
        Me.txtnitv.Name = "txtnitv"
        Me.txtnitv.ShortcutsEnabled = False
        Me.txtnitv.Size = New System.Drawing.Size(119, 20)
        Me.txtnitv.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtnitv, "nit vendedor")
        '
        'txtnitc
        '
        Me.txtnitc.Location = New System.Drawing.Point(125, 125)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.ShortcutsEnabled = False
        Me.txtnitc.Size = New System.Drawing.Size(119, 20)
        Me.txtnitc.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtnitc, "nit cliente")
        '
        'txtnumped
        '
        Me.txtnumped.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtnumped.Enabled = False
        Me.txtnumped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumped.Location = New System.Drawing.Point(123, 17)
        Me.txtnumped.Name = "txtnumped"
        Me.txtnumped.ShortcutsEnabled = False
        Me.txtnumped.Size = New System.Drawing.Size(103, 22)
        Me.txtnumped.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtnumped, "número pedido")
        '
        'txtfechaped
        '
        Me.txtfechaped.CustomFormat = "yyyy/dd/mm"
        Me.txtfechaped.Location = New System.Drawing.Point(123, 45)
        Me.txtfechaped.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfechaped.Name = "txtfechaped"
        Me.txtfechaped.Size = New System.Drawing.Size(205, 20)
        Me.txtfechaped.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtfechaped, "fecha del pedido")
        Me.txtfechaped.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'txtfechaent
        '
        Me.txtfechaent.CustomFormat = "yyyy/dd/mm"
        Me.txtfechaent.Enabled = False
        Me.txtfechaent.Location = New System.Drawing.Point(123, 71)
        Me.txtfechaent.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfechaent.Name = "txtfechaent"
        Me.txtfechaent.Size = New System.Drawing.Size(205, 20)
        Me.txtfechaent.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtfechaent, "fecha de entrega")
        Me.txtfechaent.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'cmdentrega
        '
        Me.cmdentrega.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdentrega.Enabled = False
        Me.cmdentrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdentrega.ForeColor = System.Drawing.Color.Transparent
        Me.cmdentrega.Image = Global.SAE.My.Resources.Resources.ENTREGA
        Me.cmdentrega.Location = New System.Drawing.Point(334, 22)
        Me.cmdentrega.Name = "cmdentrega"
        Me.cmdentrega.Size = New System.Drawing.Size(63, 66)
        Me.cmdentrega.TabIndex = 3
        Me.cmdentrega.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdentrega, "datos de entrega Alt+D")
        Me.cmdentrega.UseVisualStyleBackColor = False
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.notas2
        Me.cmditems.Location = New System.Drawing.Point(40, 38)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(63, 66)
        Me.cmditems.TabIndex = 0
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "editar items")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(572, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "modificar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(521, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(470, 12)
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
        Me.CmdSalir.Location = New System.Drawing.Point(333, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(419, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(227, 12)
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
        Me.CmdMostrar.Location = New System.Drawing.Point(280, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "buscar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.White
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdPrint.Location = New System.Drawing.Point(113, 37)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(63, 66)
        Me.cmdPrint.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Imprimir ")
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'lbcontrolprecio
        '
        Me.lbcontrolprecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcontrolprecio.Location = New System.Drawing.Point(9, 41)
        Me.lbcontrolprecio.Name = "lbcontrolprecio"
        Me.lbcontrolprecio.Size = New System.Drawing.Size(43, 19)
        Me.lbcontrolprecio.TabIndex = 113
        Me.lbcontrolprecio.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbcontrolprecio, "controlar precio con margen")
        '
        'lbformula
        '
        Me.lbformula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbformula.Location = New System.Drawing.Point(10, 66)
        Me.lbformula.Name = "lbformula"
        Me.lbformula.Size = New System.Drawing.Size(45, 22)
        Me.lbformula.TabIndex = 112
        Me.lbformula.Text = "formula"
        Me.ToolTip1.SetToolTip(Me.lbformula, "formula precio")
        '
        'lbprecioiva
        '
        Me.lbprecioiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbprecioiva.Location = New System.Drawing.Point(59, 66)
        Me.lbprecioiva.Name = "lbprecioiva"
        Me.lbprecioiva.Size = New System.Drawing.Size(69, 22)
        Me.lbprecioiva.TabIndex = 111
        Me.lbprecioiva.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbprecioiva, "precio con iva")
        '
        'lbnumbod
        '
        Me.lbnumbod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbnumbod.Location = New System.Drawing.Point(9, 16)
        Me.lbnumbod.Name = "lbnumbod"
        Me.lbnumbod.Size = New System.Drawing.Size(47, 19)
        Me.lbnumbod.TabIndex = 107
        Me.lbnumbod.Text = "1"
        Me.ToolTip1.SetToolTip(Me.lbnumbod, "bodega")
        '
        'lbmargen
        '
        Me.lbmargen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbmargen.Location = New System.Drawing.Point(58, 41)
        Me.lbmargen.Name = "lbmargen"
        Me.lbmargen.Size = New System.Drawing.Size(69, 19)
        Me.lbmargen.TabIndex = 109
        Me.lbmargen.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lbmargen, "margen precio")
        '
        'lbcomicion
        '
        Me.lbcomicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcomicion.Location = New System.Drawing.Point(62, 16)
        Me.lbcomicion.Name = "lbcomicion"
        Me.lbcomicion.Size = New System.Drawing.Size(30, 19)
        Me.lbcomicion.TabIndex = 110
        Me.lbcomicion.Text = "NO"
        Me.ToolTip1.SetToolTip(Me.lbcomicion, "pagar comicion")
        '
        'lbcc
        '
        Me.lbcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcc.Location = New System.Drawing.Point(98, 16)
        Me.lbcc.Name = "lbcc"
        Me.lbcc.Size = New System.Drawing.Size(29, 19)
        Me.lbcc.TabIndex = 108
        Me.lbcc.Text = "cc"
        Me.ToolTip1.SetToolTip(Me.lbcc, "concepto comicionable")
        '
        'txtnitc2
        '
        Me.txtnitc2.Location = New System.Drawing.Point(6, 19)
        Me.txtnitc2.Name = "txtnitc2"
        Me.txtnitc2.ShortcutsEnabled = False
        Me.txtnitc2.Size = New System.Drawing.Size(119, 20)
        Me.txtnitc2.TabIndex = 137
        Me.ToolTip1.SetToolTip(Me.txtnitc2, "nit cliente")
        '
        'txtnitv2
        '
        Me.txtnitv2.Location = New System.Drawing.Point(6, 45)
        Me.txtnitv2.Name = "txtnitv2"
        Me.txtnitv2.ShortcutsEnabled = False
        Me.txtnitv2.Size = New System.Drawing.Size(119, 20)
        Me.txtnitv2.TabIndex = 138
        Me.ToolTip1.SetToolTip(Me.txtnitv2, "nit vendedor")
        '
        'txttotal2
        '
        Me.txttotal2.Location = New System.Drawing.Point(6, 67)
        Me.txttotal2.Name = "txttotal2"
        Me.txttotal2.ShortcutsEnabled = False
        Me.txttotal2.Size = New System.Drawing.Size(119, 20)
        Me.txttotal2.TabIndex = 139
        Me.ToolTip1.SetToolTip(Me.txttotal2, "nit vendedor")
        '
        'txtfechaped2
        '
        Me.txtfechaped2.Location = New System.Drawing.Point(131, 19)
        Me.txtfechaped2.Name = "txtfechaped2"
        Me.txtfechaped2.ShortcutsEnabled = False
        Me.txtfechaped2.Size = New System.Drawing.Size(119, 20)
        Me.txtfechaped2.TabIndex = 139
        Me.ToolTip1.SetToolTip(Me.txtfechaped2, "nit vendedor")
        '
        'txtobs2
        '
        Me.txtobs2.Location = New System.Drawing.Point(131, 45)
        Me.txtobs2.Name = "txtobs2"
        Me.txtobs2.ShortcutsEnabled = False
        Me.txtobs2.Size = New System.Drawing.Size(119, 20)
        Me.txtobs2.TabIndex = 141
        Me.ToolTip1.SetToolTip(Me.txtobs2, "nit vendedor")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Location = New System.Drawing.Point(26, 408)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Sub Total"
        '
        'txtvendedor
        '
        Me.txtvendedor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvendedor.Enabled = False
        Me.txtvendedor.Location = New System.Drawing.Point(247, 151)
        Me.txtvendedor.Name = "txtvendedor"
        Me.txtvendedor.ReadOnly = True
        Me.txtvendedor.Size = New System.Drawing.Size(378, 20)
        Me.txtvendedor.TabIndex = 71
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label8.Location = New System.Drawing.Point(26, 434)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Descuento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Crimson
        Me.Label10.Location = New System.Drawing.Point(25, 497)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 20)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "TOTAL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(26, 460)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "I.V.A"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Nit/Cedula Vendedor"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(247, 125)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(378, 20)
        Me.txtcliente.TabIndex = 68
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Nit/Cedula Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 15)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Fecha De Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Pedido Número"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
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
        Me.GroupBox1.Location = New System.Drawing.Point(10, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label15.Location = New System.Drawing.Point(138, 461)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 89
        Me.Label15.Text = "%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label14.Location = New System.Drawing.Point(138, 435)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 16)
        Me.Label14.TabIndex = 87
        Me.Label14.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label11.Location = New System.Drawing.Point(138, 451)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 42)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "_______"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 15)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Fecha De Entrega"
        '
        'txtobs
        '
        Me.txtobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobs.Location = New System.Drawing.Point(311, 429)
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.Size = New System.Drawing.Size(344, 48)
        Me.txtobs.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(308, 408)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 107
        Me.Label16.Text = "Observaciones"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(318, 502)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 124
        Me.Label20.Text = "Usuario En Linea:"
        '
        'lbusuario
        '
        Me.lbusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuario.Location = New System.Drawing.Point(412, 502)
        Me.lbusuario.Name = "lbusuario"
        Me.lbusuario.Size = New System.Drawing.Size(213, 20)
        Me.lbusuario.TabIndex = 123
        Me.lbusuario.Text = "user"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtnitc)
        Me.GroupBox2.Controls.Add(Me.txtcliente)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtnitv)
        Me.GroupBox2.Controls.Add(Me.txtvendedor)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 174)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmdPrint)
        Me.GroupBox3.Controls.Add(Me.cmditems)
        Me.GroupBox3.Controls.Add(Me.cmbtipo)
        Me.GroupBox3.Location = New System.Drawing.Point(419, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(220, 109)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "Imprimir Como"
        '
        'cmbtipo
        '
        Me.cmbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtipo.FormattingEnabled = True
        Me.cmbtipo.Items.AddRange(New Object() {"COTIZACION", "PEDIDO", "ACTA DE ENTREGA", "REMISION"})
        Me.cmbtipo.Location = New System.Drawing.Point(80, 13)
        Me.cmbtipo.Name = "cmbtipo"
        Me.cmbtipo.Size = New System.Drawing.Size(129, 21)
        Me.cmbtipo.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtnumped)
        Me.GroupBox4.Controls.Add(Me.txtfechaped)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtfechaent)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.cmdentrega)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(406, 109)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'lbsubtotal
        '
        Me.lbsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsubtotal.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbsubtotal.Location = New System.Drawing.Point(530, 394)
        Me.lbsubtotal.Name = "lbsubtotal"
        Me.lbsubtotal.Size = New System.Drawing.Size(126, 20)
        Me.lbsubtotal.TabIndex = 128
        Me.lbsubtotal.Text = "0,00"
        Me.lbsubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbsubtotal.Visible = False
        '
        'txttotal
        '
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Red
        Me.txttotal.Location = New System.Drawing.Point(170, 497)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(119, 20)
        Me.txttotal.TabIndex = 132
        Me.txttotal.Text = "0,00"
        Me.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtiva
        '
        Me.txtiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtiva.Location = New System.Drawing.Point(170, 456)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(119, 20)
        Me.txtiva.TabIndex = 131
        Me.txtiva.Text = "0,00"
        Me.txtiva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdescuento
        '
        Me.txtdescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtdescuento.Location = New System.Drawing.Point(170, 430)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(119, 20)
        Me.txtdescuento.TabIndex = 130
        Me.txtdescuento.Text = "0,00"
        Me.txtdescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtsubtotal.Location = New System.Drawing.Point(170, 404)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(119, 20)
        Me.txtsubtotal.TabIndex = 129
        Me.txtsubtotal.Text = "0,00"
        Me.txtsubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
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
        Me.gfactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.codigo, Me.descrip, Me.cant, Me.valor, Me.Vtotal, Me.tipo, Me.bodega, Me.cc, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.iva})
        Me.gfactura.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura.Location = New System.Drawing.Point(10, 280)
        Me.gfactura.Name = "gfactura"
        Me.gfactura.RowHeadersVisible = False
        Me.gfactura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura.Size = New System.Drawing.Size(646, 115)
        Me.gfactura.TabIndex = 133
        '
        'num
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
        Me.num.Frozen = True
        Me.num.HeaderText = "NÚM"
        Me.num.MinimumWidth = 50
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.num.Width = 50
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.Width = 90
        '
        'descrip
        '
        Me.descrip.Frozen = True
        Me.descrip.HeaderText = "DESCRIPCIÓN"
        Me.descrip.MinimumWidth = 200
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descrip.Width = 200
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
        'valor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.valor.Frozen = True
        Me.valor.HeaderText = "V. UNI"
        Me.valor.MinimumWidth = 100
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Vtotal
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Vtotal.DefaultCellStyle = DataGridViewCellStyle4
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
        'imprimir
        '
        '
        'Gparametros
        '
        Me.Gparametros.Controls.Add(Me.lbcontrolprecio)
        Me.Gparametros.Controls.Add(Me.lbformula)
        Me.Gparametros.Controls.Add(Me.lbprecioiva)
        Me.Gparametros.Controls.Add(Me.lbnumbod)
        Me.Gparametros.Controls.Add(Me.lbmargen)
        Me.Gparametros.Controls.Add(Me.lbcomicion)
        Me.Gparametros.Controls.Add(Me.lbcc)
        Me.Gparametros.Location = New System.Drawing.Point(518, 538)
        Me.Gparametros.Name = "Gparametros"
        Me.Gparametros.Size = New System.Drawing.Size(137, 91)
        Me.Gparametros.TabIndex = 134
        Me.Gparametros.TabStop = False
        Me.Gparametros.Text = "parametros"
        Me.Gparametros.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(561, 476)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 135
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.valordes2)
        Me.GroupBox5.Controls.Add(Me.txtobs2)
        Me.GroupBox5.Controls.Add(Me.txtfechaped2)
        Me.GroupBox5.Controls.Add(Me.gfactura2)
        Me.GroupBox5.Controls.Add(Me.txttotal2)
        Me.GroupBox5.Controls.Add(Me.txtnitc2)
        Me.GroupBox5.Controls.Add(Me.txtnitv2)
        Me.GroupBox5.Location = New System.Drawing.Point(689, 28)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 223)
        Me.GroupBox5.TabIndex = 136
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'valordes2
        '
        Me.valordes2.BackColor = System.Drawing.Color.White
        Me.valordes2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valordes2.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.valordes2.Location = New System.Drawing.Point(131, 67)
        Me.valordes2.MaxLength = 5
        Me.valordes2.Name = "valordes2"
        Me.valordes2.ShortcutsEnabled = False
        Me.valordes2.Size = New System.Drawing.Size(42, 20)
        Me.valordes2.TabIndex = 270
        Me.valordes2.Text = "0,00"
        Me.valordes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gfactura2
        '
        Me.gfactura2.AllowUserToAddRows = False
        Me.gfactura2.AllowUserToDeleteRows = False
        Me.gfactura2.AllowUserToResizeColumns = False
        Me.gfactura2.AllowUserToResizeRows = False
        Me.gfactura2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gfactura2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo2, Me.descrip2, Me.cant2, Me.valor2, Me.tipo2, Me.bodega2, Me.cc2, Me.iva2})
        Me.gfactura2.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura2.Location = New System.Drawing.Point(6, 93)
        Me.gfactura2.Name = "gfactura2"
        Me.gfactura2.RowHeadersVisible = False
        Me.gfactura2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura2.Size = New System.Drawing.Size(646, 115)
        Me.gfactura2.TabIndex = 140
        '
        'codigo2
        '
        Me.codigo2.Frozen = True
        Me.codigo2.HeaderText = "CODIGO"
        Me.codigo2.MinimumWidth = 90
        Me.codigo2.Name = "codigo2"
        Me.codigo2.ReadOnly = True
        Me.codigo2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo2.Width = 90
        '
        'descrip2
        '
        Me.descrip2.Frozen = True
        Me.descrip2.HeaderText = "DESCRIPCIÓN"
        Me.descrip2.MinimumWidth = 200
        Me.descrip2.Name = "descrip2"
        Me.descrip2.ReadOnly = True
        Me.descrip2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descrip2.Width = 200
        '
        'cant2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cant2.DefaultCellStyle = DataGridViewCellStyle5
        Me.cant2.Frozen = True
        Me.cant2.HeaderText = "CANTIDAD"
        Me.cant2.MinimumWidth = 80
        Me.cant2.Name = "cant2"
        Me.cant2.ReadOnly = True
        Me.cant2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cant2.Width = 80
        '
        'valor2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.valor2.DefaultCellStyle = DataGridViewCellStyle6
        Me.valor2.Frozen = True
        Me.valor2.HeaderText = "V. UNI"
        Me.valor2.MinimumWidth = 100
        Me.valor2.Name = "valor2"
        Me.valor2.ReadOnly = True
        Me.valor2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'tipo2
        '
        Me.tipo2.Frozen = True
        Me.tipo2.HeaderText = "TIPO"
        Me.tipo2.MinimumWidth = 20
        Me.tipo2.Name = "tipo2"
        Me.tipo2.ReadOnly = True
        Me.tipo2.Visible = False
        Me.tipo2.Width = 20
        '
        'bodega2
        '
        Me.bodega2.Frozen = True
        Me.bodega2.HeaderText = "BODEGA"
        Me.bodega2.Name = "bodega2"
        Me.bodega2.ReadOnly = True
        Me.bodega2.Visible = False
        '
        'cc2
        '
        Me.cc2.Frozen = True
        Me.cc2.HeaderText = "cc"
        Me.cc2.Name = "cc2"
        Me.cc2.ReadOnly = True
        Me.cc2.Visible = False
        '
        'iva2
        '
        Me.iva2.Frozen = True
        Me.iva2.HeaderText = "iva"
        Me.iva2.Name = "iva2"
        Me.iva2.Visible = False
        '
        'lbespera
        '
        Me.lbespera.AutoSize = True
        Me.lbespera.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbespera.ForeColor = System.Drawing.Color.Maroon
        Me.lbespera.Location = New System.Drawing.Point(198, 255)
        Me.lbespera.Name = "lbespera"
        Me.lbespera.Size = New System.Drawing.Size(265, 24)
        Me.lbespera.TabIndex = 269
        Me.lbespera.Text = "ESPERE UN MOMENTO ..."
        Me.lbespera.Visible = False
        '
        'lblform
        '
        Me.lblform.AutoSize = True
        Me.lblform.Location = New System.Drawing.Point(597, 509)
        Me.lblform.Name = "lblform"
        Me.lblform.Size = New System.Drawing.Size(52, 13)
        Me.lblform.TabIndex = 270
        Me.lblform.Text = "formulario"
        Me.lblform.Visible = False
        '
        'FrmEntraPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(662, 530)
        Me.Controls.Add(Me.lblform)
        Me.Controls.Add(Me.lbespera)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Gparametros)
        Me.Controls.Add(Me.gfactura)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.lbsubtotal)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lbusuario)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtobs)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.valoriva)
        Me.Controls.Add(Me.valordes)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmEntraPedidos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE PEDIDOS / COTIZACIONES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gparametros.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.gfactura2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents valoriva As System.Windows.Forms.TextBox
    Friend WithEvents valordes As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents txtnitv As System.Windows.Forms.TextBox
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents txtnumped As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtvendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdentrega As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtfechaped As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtfechaent As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbusuario As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbsubtotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents gfactura As System.Windows.Forms.DataGridView
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents imprimir As System.Drawing.Printing.PrintDocument
    Friend WithEvents Gparametros As System.Windows.Forms.GroupBox
    Friend WithEvents lbcontrolprecio As System.Windows.Forms.Label
    Friend WithEvents lbformula As System.Windows.Forms.Label
    Friend WithEvents lbprecioiva As System.Windows.Forms.Label
    Friend WithEvents lbnumbod As System.Windows.Forms.Label
    Friend WithEvents lbmargen As System.Windows.Forms.Label
    Friend WithEvents lbcomicion As System.Windows.Forms.Label
    Friend WithEvents lbcc As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txttotal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnitv2 As System.Windows.Forms.TextBox
    Friend WithEvents gfactura2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtobs2 As System.Windows.Forms.TextBox
    Friend WithEvents txtfechaped2 As System.Windows.Forms.TextBox
    Friend WithEvents codigo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bodega2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbespera As System.Windows.Forms.Label
    Friend WithEvents valordes2 As System.Windows.Forms.TextBox
    Friend WithEvents lblform As System.Windows.Forms.Label
End Class
