<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormaPago2
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
        Me.G1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdbanco = New System.Windows.Forms.Button
        Me.cmdtarjeta = New System.Windows.Forms.Button
        Me.cmdcheque = New System.Windows.Forms.Button
        Me.cmdefectivo = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEstoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.G2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbform = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.cmdcuenta = New System.Windows.Forms.Button
        Me.txtcambio = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtpago = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdcontinuar = New System.Windows.Forms.Button
        Me.tabforma = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.gtar = New System.Windows.Forms.GroupBox
        Me.txtnumtarjeta = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbtarj = New System.Windows.Forms.ComboBox
        Me.txttarjeta = New System.Windows.Forms.TextBox
        Me.gche = New System.Windows.Forms.GroupBox
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.txtnumcheq = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbfp = New System.Windows.Forms.Label
        Me.tabfp = New DevComponents.DotNetBar.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.G1.SuspendLayout()
        Me.mimenu.SuspendLayout()
        Me.G2.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        Me.gtar.SuspendLayout()
        Me.gche.SuspendLayout()
        CType(Me.tabfp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabfp.SuspendLayout()
        Me.SuspendLayout()
        '
        'G1
        '
        Me.G1.CanvasColor = System.Drawing.SystemColors.Control
        Me.G1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.G1.Controls.Add(Me.cmdbanco)
        Me.G1.Controls.Add(Me.cmdtarjeta)
        Me.G1.Controls.Add(Me.cmdcheque)
        Me.G1.Controls.Add(Me.cmdefectivo)
        Me.G1.Location = New System.Drawing.Point(4, 6)
        Me.G1.Name = "G1"
        Me.G1.Size = New System.Drawing.Size(486, 85)
        '
        '
        '
        Me.G1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.G1.Style.BackColorGradientAngle = 90
        Me.G1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.G1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G1.Style.BorderBottomWidth = 1
        Me.G1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.G1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G1.Style.BorderLeftWidth = 1
        Me.G1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G1.Style.BorderRightWidth = 1
        Me.G1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G1.Style.BorderTopWidth = 1
        Me.G1.Style.CornerDiameter = 4
        Me.G1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.G1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.G1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.G1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.G1.TabIndex = 74
        '
        'cmdbanco
        '
        Me.cmdbanco.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbanco.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdbanco.Image = Global.SAE.My.Resources.Resources.banco
        Me.cmdbanco.Location = New System.Drawing.Point(313, 5)
        Me.cmdbanco.Name = "cmdbanco"
        Me.cmdbanco.Size = New System.Drawing.Size(69, 73)
        Me.cmdbanco.TabIndex = 3
        Me.cmdbanco.Text = "&B"
        Me.cmdbanco.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdbanco, "Banco / Consignacion Alt + B")
        Me.cmdbanco.UseVisualStyleBackColor = False
        '
        'cmdtarjeta
        '
        Me.cmdtarjeta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdtarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdtarjeta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdtarjeta.Image = Global.SAE.My.Resources.Resources.tarjeta
        Me.cmdtarjeta.Location = New System.Drawing.Point(169, 5)
        Me.cmdtarjeta.Name = "cmdtarjeta"
        Me.cmdtarjeta.Size = New System.Drawing.Size(69, 73)
        Me.cmdtarjeta.TabIndex = 1
        Me.cmdtarjeta.Text = "&T"
        Me.cmdtarjeta.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.cmdtarjeta, "Tarjeta Alt +T")
        Me.cmdtarjeta.UseVisualStyleBackColor = False
        '
        'cmdcheque
        '
        Me.cmdcheque.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcheque.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcheque.Image = Global.SAE.My.Resources.Resources.cheque
        Me.cmdcheque.Location = New System.Drawing.Point(96, 5)
        Me.cmdcheque.Name = "cmdcheque"
        Me.cmdcheque.Size = New System.Drawing.Size(69, 73)
        Me.cmdcheque.TabIndex = 0
        Me.cmdcheque.Text = "&C"
        Me.cmdcheque.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcheque, "Cheque Alt + C")
        Me.cmdcheque.UseVisualStyleBackColor = False
        '
        'cmdefectivo
        '
        Me.cmdefectivo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdefectivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdefectivo.Image = Global.SAE.My.Resources.Resources.efectivo
        Me.cmdefectivo.Location = New System.Drawing.Point(241, 5)
        Me.cmdefectivo.Name = "cmdefectivo"
        Me.cmdefectivo.Size = New System.Drawing.Size(69, 73)
        Me.cmdefectivo.TabIndex = 2
        Me.cmdefectivo.Text = "&E"
        Me.cmdefectivo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdefectivo, "Efectivo Alt + E")
        Me.cmdefectivo.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancelar.Location = New System.Drawing.Point(407, 58)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdcancelar.TabIndex = 3
        Me.cmdcancelar.Text = "Salir"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'mimenu
        '
        Me.mimenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueEsEstoToolStripMenuItem})
        Me.mimenu.Name = "mimenu"
        Me.mimenu.Size = New System.Drawing.Size(146, 26)
        '
        'QueEsEstoToolStripMenuItem
        '
        Me.QueEsEstoToolStripMenuItem.Name = "QueEsEstoToolStripMenuItem"
        Me.QueEsEstoToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.QueEsEstoToolStripMenuItem.Text = "¿Que es esto?"
        '
        'G2
        '
        Me.G2.CanvasColor = System.Drawing.SystemColors.Control
        Me.G2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.G2.Controls.Add(Me.lbform)
        Me.G2.Controls.Add(Me.Label16)
        Me.G2.Controls.Add(Me.txtcuenta)
        Me.G2.Controls.Add(Me.cmdcuenta)
        Me.G2.Controls.Add(Me.txtcambio)
        Me.G2.Controls.Add(Me.Label3)
        Me.G2.Controls.Add(Me.txttotal)
        Me.G2.Controls.Add(Me.Label8)
        Me.G2.Controls.Add(Me.txtpago)
        Me.G2.Controls.Add(Me.Label2)
        Me.G2.Controls.Add(Me.cmdcontinuar)
        Me.G2.Location = New System.Drawing.Point(3, 316)
        Me.G2.Name = "G2"
        Me.G2.Size = New System.Drawing.Size(486, 105)
        '
        '
        '
        Me.G2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.G2.Style.BackColorGradientAngle = 90
        Me.G2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.G2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderBottomWidth = 1
        Me.G2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.G2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderLeftWidth = 1
        Me.G2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderRightWidth = 1
        Me.G2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderTopWidth = 1
        Me.G2.Style.CornerDiameter = 4
        Me.G2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.G2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.G2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.G2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.G2.TabIndex = 76
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(45, 86)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 35
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Tomato
        Me.Label16.Location = New System.Drawing.Point(196, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Cuenta"
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.Menu
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.ForeColor = System.Drawing.Color.Tomato
        Me.txtcuenta.Location = New System.Drawing.Point(316, 7)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ReadOnly = True
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(160, 20)
        Me.txtcuenta.TabIndex = 33
        Me.txtcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdcuenta
        '
        Me.cmdcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcuenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcuenta.Image = Global.SAE.My.Resources.Resources.cuenta
        Me.cmdcuenta.Location = New System.Drawing.Point(97, 11)
        Me.cmdcuenta.Name = "cmdcuenta"
        Me.cmdcuenta.Size = New System.Drawing.Size(69, 73)
        Me.cmdcuenta.TabIndex = 32
        Me.cmdcuenta.Text = "&p"
        Me.cmdcuenta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdcuenta, "Seleccionar Cuenta PUC Alt + P ")
        Me.cmdcuenta.UseVisualStyleBackColor = False
        '
        'txtcambio
        '
        Me.txtcambio.BackColor = System.Drawing.SystemColors.Menu
        Me.txtcambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcambio.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtcambio.Location = New System.Drawing.Point(316, 73)
        Me.txtcambio.Name = "txtcambio"
        Me.txtcambio.ReadOnly = True
        Me.txtcambio.ShortcutsEnabled = False
        Me.txtcambio.Size = New System.Drawing.Size(160, 20)
        Me.txtcambio.TabIndex = 13
        Me.txtcambio.Text = "0"
        Me.txtcambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label3.Location = New System.Drawing.Point(196, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Valor Cambio"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.Menu
        Me.txttotal.Enabled = False
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txttotal.Location = New System.Drawing.Point(316, 51)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.ShortcutsEnabled = False
        Me.txttotal.Size = New System.Drawing.Size(160, 20)
        Me.txttotal.TabIndex = 12
        Me.txttotal.Text = "0"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label8.Location = New System.Drawing.Point(196, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Valor Pagado"
        '
        'txtpago
        '
        Me.txtpago.BackColor = System.Drawing.SystemColors.Menu
        Me.txtpago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpago.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtpago.Location = New System.Drawing.Point(316, 29)
        Me.txtpago.Name = "txtpago"
        Me.txtpago.ShortcutsEnabled = False
        Me.txtpago.Size = New System.Drawing.Size(160, 20)
        Me.txtpago.TabIndex = 11
        Me.txtpago.Text = "0"
        Me.txtpago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(196, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Valor Factura"
        '
        'cmdcontinuar
        '
        Me.cmdcontinuar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcontinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcontinuar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcontinuar.Image = Global.SAE.My.Resources.Resources.continuar
        Me.cmdcontinuar.Location = New System.Drawing.Point(15, 11)
        Me.cmdcontinuar.Name = "cmdcontinuar"
        Me.cmdcontinuar.Size = New System.Drawing.Size(69, 73)
        Me.cmdcontinuar.TabIndex = 14
        Me.cmdcontinuar.Text = "&A"
        Me.cmdcontinuar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcontinuar, "Continuar Alt + A")
        Me.cmdcontinuar.UseVisualStyleBackColor = False
        '
        'tabforma
        '
        Me.tabforma.AttachedControl = Me.TabControlPanel6
        Me.tabforma.Name = "tabforma"
        Me.tabforma.Text = "Forma De Pago"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.gtar)
        Me.TabControlPanel6.Controls.Add(Me.gche)
        Me.TabControlPanel6.Controls.Add(Me.lbfp)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(486, 188)
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabIndex = 1
        Me.TabControlPanel6.TabItem = Me.tabforma
        '
        'gtar
        '
        Me.gtar.BackColor = System.Drawing.Color.Transparent
        Me.gtar.Controls.Add(Me.txtnumtarjeta)
        Me.gtar.Controls.Add(Me.Label14)
        Me.gtar.Controls.Add(Me.Label7)
        Me.gtar.Controls.Add(Me.cbtarj)
        Me.gtar.Controls.Add(Me.txttarjeta)
        Me.gtar.Location = New System.Drawing.Point(3, 116)
        Me.gtar.Name = "gtar"
        Me.gtar.Size = New System.Drawing.Size(479, 51)
        Me.gtar.TabIndex = 54
        Me.gtar.TabStop = False
        Me.gtar.Text = "Tarjeta"
        '
        'txtnumtarjeta
        '
        Me.txtnumtarjeta.BackColor = System.Drawing.SystemColors.Menu
        Me.txtnumtarjeta.Location = New System.Drawing.Point(291, 19)
        Me.txtnumtarjeta.Name = "txtnumtarjeta"
        Me.txtnumtarjeta.ShortcutsEnabled = False
        Me.txtnumtarjeta.Size = New System.Drawing.Size(177, 20)
        Me.txtnumtarjeta.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(152, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(244, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Número"
        '
        'cbtarj
        '
        Me.cbtarj.ContextMenuStrip = Me.mimenu
        Me.cbtarj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtarj.FormattingEnabled = True
        Me.cbtarj.Items.AddRange(New Object() {"DB", "CR"})
        Me.cbtarj.Location = New System.Drawing.Point(181, 19)
        Me.cbtarj.Name = "cbtarj"
        Me.cbtarj.Size = New System.Drawing.Size(39, 21)
        Me.cbtarj.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cbtarj, "tipo de tarjeta (DB=débito, CR=crédito)")
        '
        'txttarjeta
        '
        Me.txttarjeta.BackColor = System.Drawing.SystemColors.Menu
        Me.txttarjeta.Location = New System.Drawing.Point(17, 19)
        Me.txttarjeta.Name = "txttarjeta"
        Me.txttarjeta.ShortcutsEnabled = False
        Me.txttarjeta.Size = New System.Drawing.Size(121, 20)
        Me.txttarjeta.TabIndex = 7
        '
        'gche
        '
        Me.gche.BackColor = System.Drawing.Color.Transparent
        Me.gche.Controls.Add(Me.txtbanco)
        Me.gche.Controls.Add(Me.txtnumcheq)
        Me.gche.Controls.Add(Me.Label4)
        Me.gche.Controls.Add(Me.Label5)
        Me.gche.Location = New System.Drawing.Point(3, 36)
        Me.gche.Name = "gche"
        Me.gche.Size = New System.Drawing.Size(479, 74)
        Me.gche.TabIndex = 53
        Me.gche.TabStop = False
        Me.gche.Text = "Cheque/Consignacion"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.SystemColors.Control
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Location = New System.Drawing.Point(56, 43)
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(255, 20)
        Me.txtbanco.TabIndex = 6
        '
        'txtnumcheq
        '
        Me.txtnumcheq.BackColor = System.Drawing.SystemColors.Menu
        Me.txtnumcheq.Location = New System.Drawing.Point(57, 17)
        Me.txtnumcheq.Name = "txtnumcheq"
        Me.txtnumcheq.ShortcutsEnabled = False
        Me.txtnumcheq.Size = New System.Drawing.Size(121, 20)
        Me.txtnumcheq.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(11, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Banco"
        '
        'lbfp
        '
        Me.lbfp.BackColor = System.Drawing.Color.Transparent
        Me.lbfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfp.Location = New System.Drawing.Point(9, 6)
        Me.lbfp.Name = "lbfp"
        Me.lbfp.Size = New System.Drawing.Size(467, 31)
        Me.lbfp.TabIndex = 10
        Me.lbfp.Text = "Efectivo"
        Me.lbfp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabfp
        '
        Me.tabfp.BackColor = System.Drawing.Color.White
        Me.tabfp.CanReorderTabs = True
        Me.tabfp.Controls.Add(Me.TabControlPanel6)
        Me.tabfp.Location = New System.Drawing.Point(4, 99)
        Me.tabfp.Name = "tabfp"
        Me.tabfp.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabfp.SelectedTabIndex = 0
        Me.tabfp.Size = New System.Drawing.Size(486, 214)
        Me.tabfp.TabIndex = 75
        Me.tabfp.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabfp.Tabs.Add(Me.tabforma)
        Me.tabfp.Text = "Cheque"
        '
        'FrmFormaPago2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CancelButton = Me.cmdcancelar
        Me.ClientSize = New System.Drawing.Size(496, 426)
        Me.Controls.Add(Me.G1)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.tabfp)
        Me.Controls.Add(Me.cmdcancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFormaPago2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Forma de Pago"
        Me.G1.ResumeLayout(False)
        Me.mimenu.ResumeLayout(False)
        Me.G2.ResumeLayout(False)
        Me.G2.PerformLayout()
        Me.TabControlPanel6.ResumeLayout(False)
        Me.gtar.ResumeLayout(False)
        Me.gtar.PerformLayout()
        Me.gche.ResumeLayout(False)
        Me.gche.PerformLayout()
        CType(Me.tabfp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabfp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents G1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdtarjeta As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdcheque As System.Windows.Forms.Button
    Friend WithEvents cmdefectivo As System.Windows.Forms.Button
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEstoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents G2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents cmdcuenta As System.Windows.Forms.Button
    Friend WithEvents txtcambio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtpago As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdcontinuar As System.Windows.Forms.Button
    Friend WithEvents tabforma As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents gtar As System.Windows.Forms.GroupBox
    Friend WithEvents txtnumtarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbtarj As System.Windows.Forms.ComboBox
    Friend WithEvents txttarjeta As System.Windows.Forms.TextBox
    Friend WithEvents gche As System.Windows.Forms.GroupBox
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents txtnumcheq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbfp As System.Windows.Forms.Label
    Friend WithEvents tabfp As DevComponents.DotNetBar.TabControl
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdbanco As System.Windows.Forms.Button
End Class
