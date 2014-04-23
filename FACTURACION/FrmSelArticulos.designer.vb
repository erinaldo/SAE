<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelArticulos))
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nivel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacven = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaiva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.canbod = New System.Windows.Forms.DataGridViewButtonColumn
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmd_nv = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lbform = New System.Windows.Forms.Label
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.lb = New System.Windows.Forms.Label
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.lbiva = New System.Windows.Forms.Label
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.fila = New System.Windows.Forms.Label
        Me.cbpag = New System.Windows.Forms.ComboBox
        Me.cmditems = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdAct = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_buscar = New System.Windows.Forms.ComboBox
        Me.ok = New System.Windows.Forms.Button
        Me.lbitems = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gitems
        '
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.codigo, Me.ref, Me.desc, Me.nivel, Me.cant, Me.precio, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.iva, Me.costo, Me.cant2, Me.precio2, Me.canbod})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(11, 63)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.Size = New System.Drawing.Size(881, 333)
        Me.gitems.TabIndex = 68
        '
        'buscar
        '
        Me.buscar.Frozen = True
        Me.buscar.HeaderText = "BUSCAR"
        Me.buscar.MinimumWidth = 90
        Me.buscar.Name = "buscar"
        Me.buscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.buscar.Visible = False
        Me.buscar.Width = 90
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 90
        '
        'ref
        '
        Me.ref.Frozen = True
        Me.ref.HeaderText = "REFERENCIA"
        Me.ref.Name = "ref"
        Me.ref.ReadOnly = True
        '
        'desc
        '
        Me.desc.Frozen = True
        Me.desc.HeaderText = "DESCRIPCIÓN"
        Me.desc.MinimumWidth = 250
        Me.desc.Name = "desc"
        Me.desc.Width = 250
        '
        'nivel
        '
        Me.nivel.Frozen = True
        Me.nivel.HeaderText = "NIVEL"
        Me.nivel.Name = "nivel"
        Me.nivel.ReadOnly = True
        Me.nivel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nivel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nivel.Width = 80
        '
        'cant
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle1
        Me.cant.Frozen = True
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.MinimumWidth = 70
        Me.cant.Name = "cant"
        Me.cant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cant.Visible = False
        Me.cant.Width = 70
        '
        'precio
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.precio.DefaultCellStyle = DataGridViewCellStyle2
        Me.precio.Frozen = True
        Me.precio.HeaderText = "PRECIO"
        Me.precio.Name = "precio"
        Me.precio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ctainv
        '
        Me.ctainv.Frozen = True
        Me.ctainv.HeaderText = "CTA INVENTARIO"
        Me.ctainv.Name = "ctainv"
        Me.ctainv.ReadOnly = True
        Me.ctainv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ctainv.Visible = False
        '
        'ctacven
        '
        Me.ctacven.Frozen = True
        Me.ctacven.HeaderText = "CTA C VEN"
        Me.ctacven.Name = "ctacven"
        Me.ctacven.ReadOnly = True
        Me.ctacven.Visible = False
        '
        'ctaing
        '
        Me.ctaing.Frozen = True
        Me.ctaing.HeaderText = "CTA INGRESO"
        Me.ctaing.Name = "ctaing"
        Me.ctaing.ReadOnly = True
        Me.ctaing.Visible = False
        '
        'ctaiva
        '
        Me.ctaiva.HeaderText = "CTAIVA"
        Me.ctaiva.Name = "ctaiva"
        Me.ctaiva.ReadOnly = True
        Me.ctaiva.Visible = False
        '
        'iva
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.iva.DefaultCellStyle = DataGridViewCellStyle3
        Me.iva.HeaderText = "IVA"
        Me.iva.MinimumWidth = 50
        Me.iva.Name = "iva"
        Me.iva.ReadOnly = True
        Me.iva.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.iva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.iva.Width = 50
        '
        'costo
        '
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'cant2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Green
        Me.cant2.DefaultCellStyle = DataGridViewCellStyle4
        Me.cant2.HeaderText = "DISPONIBLE"
        Me.cant2.MinimumWidth = 89
        Me.cant2.Name = "cant2"
        Me.cant2.ReadOnly = True
        Me.cant2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cant2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cant2.Width = 89
        '
        'precio2
        '
        Me.precio2.HeaderText = "precio2"
        Me.precio2.Name = "precio2"
        Me.precio2.Visible = False
        '
        'canbod
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.NullValue = "Cantidades"
        Me.canbod.DefaultCellStyle = DataGridViewCellStyle5
        Me.canbod.HeaderText = "DETALLES"
        Me.canbod.Name = "canbod"
        Me.canbod.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.canbod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.canbod.Text = "cantidades"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmd_nv)
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.CmdUltimo)
        Me.GroupPanel1.Controls.Add(Me.CmdSiguiente)
        Me.GroupPanel1.Controls.Add(Me.lb)
        Me.GroupPanel1.Controls.Add(Me.CmdAtras)
        Me.GroupPanel1.Controls.Add(Me.lbiva)
        Me.GroupPanel1.Controls.Add(Me.CmdPrimero)
        Me.GroupPanel1.Controls.Add(Me.fila)
        Me.GroupPanel1.Controls.Add(Me.cbpag)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 398)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(881, 85)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel1.TabIndex = 69
        '
        'cmd_nv
        '
        Me.cmd_nv.BackColor = System.Drawing.Color.White
        Me.cmd_nv.Image = Global.SAE.My.Resources.Resources.nuevo_r
        Me.cmd_nv.Location = New System.Drawing.Point(348, 5)
        Me.cmd_nv.Name = "cmd_nv"
        Me.cmd_nv.Size = New System.Drawing.Size(68, 68)
        Me.cmd_nv.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.cmd_nv, "Crear Nuevo Articulo")
        Me.cmd_nv.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(503, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 76
        Me.TextBox1.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(97, 59)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(31, 13)
        Me.lbform.TabIndex = 75
        Me.lbform.Text = "items"
        Me.lbform.Visible = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(642, 31)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(30, 30)
        Me.CmdUltimo.TabIndex = 6
        Me.CmdUltimo.Text = "&u"
        Me.CmdUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ultimo Alt+U")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        Me.CmdUltimo.Visible = False
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(613, 31)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(30, 30)
        Me.CmdSiguiente.TabIndex = 5
        Me.CmdSiguiente.Text = "&n"
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "SiguieNte Alt+N")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        Me.CmdSiguiente.Visible = False
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.Location = New System.Drawing.Point(4, 9)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(175, 15)
        Me.lb.TabIndex = 73
        Me.lb.Text = "BUSCAR ARTICULOS POR"
        Me.lb.Visible = False
        '
        'CmdAtras
        '
        Me.CmdAtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(584, 31)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(30, 30)
        Me.CmdAtras.TabIndex = 4
        Me.CmdAtras.Text = " &a"
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Anterior Alt+A")
        Me.CmdAtras.UseVisualStyleBackColor = True
        Me.CmdAtras.Visible = False
        '
        'lbiva
        '
        Me.lbiva.AutoSize = True
        Me.lbiva.Location = New System.Drawing.Point(186, 36)
        Me.lbiva.Name = "lbiva"
        Me.lbiva.Size = New System.Drawing.Size(23, 13)
        Me.lbiva.TabIndex = 71
        Me.lbiva.Text = "NO"
        Me.lbiva.Visible = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(555, 31)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(30, 30)
        Me.CmdPrimero.TabIndex = 3
        Me.CmdPrimero.Text = "&p"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primera Alt+P")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        Me.CmdPrimero.Visible = False
        '
        'fila
        '
        Me.fila.AutoSize = True
        Me.fila.Location = New System.Drawing.Point(124, 36)
        Me.fila.Name = "fila"
        Me.fila.Size = New System.Drawing.Size(13, 13)
        Me.fila.TabIndex = 70
        Me.fila.Text = "0"
        Me.fila.Visible = False
        '
        'cbpag
        '
        Me.cbpag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpag.FormattingEnabled = True
        Me.cbpag.Location = New System.Drawing.Point(510, 36)
        Me.cbpag.Name = "cbpag"
        Me.cbpag.Size = New System.Drawing.Size(43, 21)
        Me.cbpag.TabIndex = 2
        Me.cbpag.Visible = False
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(420, 3)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 67
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "seleccionar articulos  Alt+S")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(417, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "PAG."
        Me.Label1.Visible = False
        '
        'cmdAct
        '
        Me.cmdAct.BackColor = System.Drawing.Color.White
        Me.cmdAct.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdAct.Location = New System.Drawing.Point(552, 9)
        Me.cmdAct.Name = "cmdAct"
        Me.cmdAct.Size = New System.Drawing.Size(46, 38)
        Me.cmdAct.TabIndex = 78
        Me.ToolTip1.SetToolTip(Me.cmdAct, "Actualizar Lista")
        Me.cmdAct.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdAct)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cb_buscar)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.lbitems)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(887, 52)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "BUSCAR ARTICULOS POR"
        '
        'cb_buscar
        '
        Me.cb_buscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_buscar.FormattingEnabled = True
        Me.cb_buscar.Items.AddRange(New Object() {"CODIGO", "DESCRIPCIÓN", "REFERENCIA"})
        Me.cb_buscar.Location = New System.Drawing.Point(164, 19)
        Me.cb_buscar.Name = "cb_buscar"
        Me.cb_buscar.Size = New System.Drawing.Size(121, 21)
        Me.cb_buscar.TabIndex = 0
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(492, 16)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(45, 23)
        Me.ok.TabIndex = 2
        Me.ok.Text = "Ok"
        Me.ok.UseVisualStyleBackColor = True
        '
        'lbitems
        '
        Me.lbitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitems.ForeColor = System.Drawing.Color.DarkRed
        Me.lbitems.Location = New System.Drawing.Point(600, 18)
        Me.lbitems.Name = "lbitems"
        Me.lbitems.Size = New System.Drawing.Size(182, 23)
        Me.lbitems.TabIndex = 72
        Me.lbitems.Text = "Hay 0 items"
        Me.lbitems.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(290, 19)
        Me.txtcuenta.MaxLength = 100
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(195, 20)
        Me.txtcuenta.TabIndex = 1
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(290, 215)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 116
        Me.mibarra.Visible = False
        '
        'FrmSelArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(904, 486)
        Me.Controls.Add(Me.mibarra)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelArticulos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE   SELECCIONAR ITEMS=Alt+S,  SALIR= Alt+F4"
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents fila As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents lbiva As System.Windows.Forms.Label
    Friend WithEvents cbpag As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents lbitems As System.Windows.Forms.Label
    Friend WithEvents cb_buscar As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmd_nv As System.Windows.Forms.Button
    Friend WithEvents cmdAct As System.Windows.Forms.Button
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents canbod As System.Windows.Forms.DataGridViewButtonColumn
End Class
