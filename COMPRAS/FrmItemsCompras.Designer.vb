<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemsCompras
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.lbbodega = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Ch_Ref = New System.Windows.Forms.CheckBox
        Me.Ch_Cod = New System.Windows.Forms.CheckBox
        Me.lbiva = New System.Windows.Forms.Label
        Me.LbTipoMov = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.cmddel = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.cmd_cod_bar = New System.Windows.Forms.Button
        Me.txtfecha = New System.Windows.Forms.DateTimePicker
        Me.cbdesc = New System.Windows.Forms.ComboBox
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmd_refe = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacven = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaiva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Fecha"
        '
        'gitems
        '
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.tipo, Me.codigo, Me.descrip, Me.cant, Me.precio, Me.bodega, Me.cc, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.iva, Me.costo, Me.descuento})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(6, 78)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(880, 367)
        Me.gitems.TabIndex = 75
        '
        'lbbodega
        '
        Me.lbbodega.AutoSize = True
        Me.lbbodega.Location = New System.Drawing.Point(257, 20)
        Me.lbbodega.Name = "lbbodega"
        Me.lbbodega.Size = New System.Drawing.Size(13, 13)
        Me.lbbodega.TabIndex = 6
        Me.lbbodega.Text = "1"
        Me.lbbodega.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Ch_Ref)
        Me.GroupPanel1.Controls.Add(Me.Ch_Cod)
        Me.GroupPanel1.Controls.Add(Me.lbbodega)
        Me.GroupPanel1.Controls.Add(Me.lbiva)
        Me.GroupPanel1.Controls.Add(Me.LbTipoMov)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmddel)
        Me.GroupPanel1.Controls.Add(Me.cmdadd)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 451)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(880, 85)
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
        Me.GroupPanel1.TabIndex = 76
        '
        'Ch_Ref
        '
        Me.Ch_Ref.AutoSize = True
        Me.Ch_Ref.Location = New System.Drawing.Point(524, 38)
        Me.Ch_Ref.Name = "Ch_Ref"
        Me.Ch_Ref.Size = New System.Drawing.Size(177, 17)
        Me.Ch_Ref.TabIndex = 5
        Me.Ch_Ref.Text = "Buscar Por Codigo y &Referencia"
        Me.ToolTip1.SetToolTip(Me.Ch_Ref, "Buscar Articulos Por Codigo y Referencia Alt + R")
        Me.Ch_Ref.UseVisualStyleBackColor = True
        Me.Ch_Ref.Visible = False
        '
        'Ch_Cod
        '
        Me.Ch_Cod.AutoSize = True
        Me.Ch_Cod.Checked = True
        Me.Ch_Cod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ch_Cod.Location = New System.Drawing.Point(523, 17)
        Me.Ch_Cod.Name = "Ch_Cod"
        Me.Ch_Cod.Size = New System.Drawing.Size(138, 17)
        Me.Ch_Cod.TabIndex = 4
        Me.Ch_Cod.Text = "Buscar Solo Por &Codigo"
        Me.ToolTip1.SetToolTip(Me.Ch_Cod, "Busacar Articulos Solo Por Codigo Alt + C")
        Me.Ch_Cod.UseVisualStyleBackColor = True
        Me.Ch_Cod.Visible = False
        '
        'lbiva
        '
        Me.lbiva.AutoSize = True
        Me.lbiva.Location = New System.Drawing.Point(257, 47)
        Me.lbiva.Name = "lbiva"
        Me.lbiva.Size = New System.Drawing.Size(23, 13)
        Me.lbiva.TabIndex = 5
        Me.lbiva.Text = "NO"
        Me.lbiva.Visible = False
        '
        'LbTipoMov
        '
        Me.LbTipoMov.AutoSize = True
        Me.LbTipoMov.Location = New System.Drawing.Point(123, 47)
        Me.LbTipoMov.Name = "LbTipoMov"
        Me.LbTipoMov.Size = New System.Drawing.Size(82, 13)
        Me.LbTipoMov.TabIndex = 4
        Me.LbTipoMov.Text = "entrada o salida"
        Me.LbTipoMov.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(123, 20)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 3
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'cmddel
        '
        Me.cmddel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmddel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddel.ForeColor = System.Drawing.Color.Transparent
        Me.cmddel.Image = Global.SAE.My.Resources.Resources.del
        Me.cmddel.Location = New System.Drawing.Point(424, 6)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(72, 68)
        Me.cmddel.TabIndex = 2
        Me.cmddel.Text = "&Q"
        Me.cmddel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmddel, "Quitar item Alt + Q")
        Me.cmddel.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Transparent
        Me.cmdadd.Image = Global.SAE.My.Resources.Resources.add
        Me.cmdadd.Location = New System.Drawing.Point(348, 6)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 68)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&A"
        Me.cmdadd.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdadd, "Agregar a factura Alt + A")
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Tipo"
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.Color.White
        Me.txtnumfac.Enabled = False
        Me.txtnumfac.Location = New System.Drawing.Point(426, 19)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ReadOnly = True
        Me.txtnumfac.Size = New System.Drawing.Size(87, 20)
        Me.txtnumfac.TabIndex = 2
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.Enabled = False
        Me.txttipo.Location = New System.Drawing.Point(57, 19)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.ReadOnly = True
        Me.txttipo.Size = New System.Drawing.Size(28, 20)
        Me.txttipo.TabIndex = 0
        '
        'cmd_cod_bar
        '
        Me.cmd_cod_bar.Location = New System.Drawing.Point(230, 43)
        Me.cmd_cod_bar.Name = "cmd_cod_bar"
        Me.cmd_cod_bar.Size = New System.Drawing.Size(188, 23)
        Me.cmd_cod_bar.TabIndex = 6
        Me.cmd_cod_bar.Text = "Buscar Por &Codigo de Barras Alt + C"
        Me.ToolTip1.SetToolTip(Me.cmd_cod_bar, "Buscar Articulos Por Codigo de Barras Alt + C")
        Me.cmd_cod_bar.UseVisualStyleBackColor = True
        '
        'txtfecha
        '
        Me.txtfecha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtfecha.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha.Enabled = False
        Me.txtfecha.Location = New System.Drawing.Point(575, 19)
        Me.txtfecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtfecha, "fecha del pedido")
        Me.txtfecha.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'cbdesc
        '
        Me.cbdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdesc.FormattingEnabled = True
        Me.cbdesc.Items.AddRange(New Object() {"NORMAL", "DETALLADA"})
        Me.cbdesc.Location = New System.Drawing.Point(571, 44)
        Me.cbdesc.Name = "cbdesc"
        Me.cbdesc.Size = New System.Drawing.Size(133, 21)
        Me.cbdesc.TabIndex = 7
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(91, 19)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(262, 20)
        Me.txttipo2.TabIndex = 1
        Me.txttipo2.TabStop = False
        '
        'cmd_refe
        '
        Me.cmd_refe.Location = New System.Drawing.Point(28, 42)
        Me.cmd_refe.Name = "cmd_refe"
        Me.cmd_refe.Size = New System.Drawing.Size(185, 23)
        Me.cmd_refe.TabIndex = 4
        Me.cmd_refe.Text = "Buscar Por &Referencia Alt + R"
        Me.ToolTip1.SetToolTip(Me.cmd_refe, "Buscar Articulos Por Codigo de Referencia Alt + R")
        Me.cmd_refe.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(379, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Número"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(428, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Traer Items Con Descripción "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_refe)
        Me.GroupBox1.Controls.Add(Me.cmd_cod_bar)
        Me.GroupBox1.Controls.Add(Me.txtfecha)
        Me.GroupBox1.Controls.Add(Me.cbdesc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txttipo2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnumfac)
        Me.GroupBox1.Controls.Add(Me.txttipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(880, 74)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'num
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
        Me.num.Frozen = True
        Me.num.HeaderText = "   ITEM"
        Me.num.MinimumWidth = 60
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Visible = False
        Me.num.Width = 60
        '
        'tipo
        '
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.Items.AddRange(New Object() {"I", "G"})
        Me.tipo.MinimumWidth = 50
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 50
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 90
        '
        'descrip
        '
        Me.descrip.Frozen = True
        Me.descrip.HeaderText = "DESCRIPCIÓN"
        Me.descrip.MinimumWidth = 320
        Me.descrip.Name = "descrip"
        Me.descrip.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descrip.Width = 320
        '
        'cant
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle2
        Me.cant.Frozen = True
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.MinimumWidth = 80
        Me.cant.Name = "cant"
        Me.cant.Width = 80
        '
        'precio
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.precio.DefaultCellStyle = DataGridViewCellStyle3
        Me.precio.Frozen = True
        Me.precio.HeaderText = "COSTO"
        Me.precio.MinimumWidth = 110
        Me.precio.Name = "precio"
        Me.precio.Width = 110
        '
        'bodega
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N0"
        Me.bodega.DefaultCellStyle = DataGridViewCellStyle4
        Me.bodega.Frozen = True
        Me.bodega.HeaderText = "BODEGA"
        Me.bodega.MinimumWidth = 60
        Me.bodega.Name = "bodega"
        Me.bodega.Width = 60
        '
        'cc
        '
        Me.cc.Frozen = True
        Me.cc.HeaderText = "C. COMICIONABLE"
        Me.cc.MinimumWidth = 120
        Me.cc.Name = "cc"
        Me.cc.Visible = False
        Me.cc.Width = 120
        '
        'ctainv
        '
        Me.ctainv.Frozen = True
        Me.ctainv.HeaderText = "CTA INVENTATIO"
        Me.ctainv.MinimumWidth = 110
        Me.ctainv.Name = "ctainv"
        Me.ctainv.ReadOnly = True
        Me.ctainv.Visible = False
        Me.ctainv.Width = 110
        '
        'ctacven
        '
        Me.ctacven.Frozen = True
        Me.ctacven.HeaderText = "CTA COS. VENTAS."
        Me.ctacven.MinimumWidth = 112
        Me.ctacven.Name = "ctacven"
        Me.ctacven.ReadOnly = True
        Me.ctacven.Visible = False
        Me.ctacven.Width = 112
        '
        'ctaing
        '
        Me.ctaing.Frozen = True
        Me.ctaing.HeaderText = "CTA INGRESO"
        Me.ctaing.MinimumWidth = 110
        Me.ctaing.Name = "ctaing"
        Me.ctaing.ReadOnly = True
        Me.ctaing.Visible = False
        Me.ctaing.Width = 110
        '
        'ctaiva
        '
        Me.ctaiva.Frozen = True
        Me.ctaiva.HeaderText = "CTA IVA"
        Me.ctaiva.MinimumWidth = 95
        Me.ctaiva.Name = "ctaiva"
        Me.ctaiva.ReadOnly = True
        Me.ctaiva.Visible = False
        Me.ctaiva.Width = 95
        '
        'iva
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.iva.DefaultCellStyle = DataGridViewCellStyle5
        Me.iva.Frozen = True
        Me.iva.HeaderText = "  % IVA"
        Me.iva.MinimumWidth = 60
        Me.iva.Name = "iva"
        Me.iva.Width = 60
        '
        'costo
        '
        Me.costo.Frozen = True
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'descuento
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.descuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.descuento.Frozen = True
        Me.descuento.HeaderText = "DESCUENTO"
        Me.descuento.Name = "descuento"
        '
        'FrmItemsCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(892, 541)
        Me.Controls.Add(Me.gitems)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemsCompras"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Items de Compras      Alt+A=AGREGAR,  Alt+Q=QUITAR,   Alt + F4=SALIR "
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents lbbodega As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbiva As System.Windows.Forms.Label
    Friend WithEvents LbTipoMov As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_cod_bar As System.Windows.Forms.Button
    Friend WithEvents txtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbdesc As System.Windows.Forms.ComboBox
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Ch_Ref As System.Windows.Forms.CheckBox
    Friend WithEvents Ch_Cod As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_refe As System.Windows.Forms.Button
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
