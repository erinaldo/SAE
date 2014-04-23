<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormaPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFormaPago))
        Me.G1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdtarjeta = New System.Windows.Forms.Button
        Me.cmdvarias = New System.Windows.Forms.Button
        Me.cmdcredito = New System.Windows.Forms.Button
        Me.cmdcheque = New System.Windows.Forms.Button
        Me.cmdefectivo = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbtarj1 = New System.Windows.Forms.ComboBox
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEstoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cbtarj2 = New System.Windows.Forms.ComboBox
        Me.cbtarj3 = New System.Windows.Forms.ComboBox
        Me.cbtarj = New System.Windows.Forms.ComboBox
        Me.cmdcuenta = New System.Windows.Forms.Button
        Me.cmdcontinuar = New System.Windows.Forms.Button
        Me.tabfp = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.gcre = New System.Windows.Forms.GroupBox
        Me.gdia = New System.Windows.Forms.GroupBox
        Me.txtdias = New System.Windows.Forms.TextBox
        Me.rbsdia = New System.Windows.Forms.RadioButton
        Me.rbndia = New System.Windows.Forms.RadioButton
        Me.txtespecifica = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gtar = New System.Windows.Forms.GroupBox
        Me.txtnumtarjeta = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txttarjeta = New System.Windows.Forms.TextBox
        Me.gche = New System.Windows.Forms.GroupBox
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.txtnumcheq = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbfp = New System.Windows.Forms.Label
        Me.tabforma = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel10 = New DevComponents.DotNetBar.TabControlPanel
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtnumtar3 = New System.Windows.Forms.TextBox
        Me.txtvt3 = New System.Windows.Forms.TextBox
        Me.txttar3 = New System.Windows.Forms.TextBox
        Me.txtnumtar2 = New System.Windows.Forms.TextBox
        Me.txtvt2 = New System.Windows.Forms.TextBox
        Me.txttar2 = New System.Windows.Forms.TextBox
        Me.txtnumtar1 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtbanco2 = New System.Windows.Forms.TextBox
        Me.txtnumcheque2 = New System.Windows.Forms.TextBox
        Me.txtvt1 = New System.Windows.Forms.TextBox
        Me.txtvefec = New System.Windows.Forms.TextBox
        Me.txttar1 = New System.Windows.Forms.TextBox
        Me.txtvche = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabvarias = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.G2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbform = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.txtcambio = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtpago = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.G1.SuspendLayout()
        Me.mimenu.SuspendLayout()
        CType(Me.tabfp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabfp.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        Me.gcre.SuspendLayout()
        Me.gdia.SuspendLayout()
        Me.gtar.SuspendLayout()
        Me.gche.SuspendLayout()
        Me.TabControlPanel10.SuspendLayout()
        Me.G2.SuspendLayout()
        Me.SuspendLayout()
        '
        'G1
        '
        Me.G1.CanvasColor = System.Drawing.SystemColors.Control
        Me.G1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.G1.Controls.Add(Me.cmdtarjeta)
        Me.G1.Controls.Add(Me.cmdvarias)
        Me.G1.Controls.Add(Me.cmdcredito)
        Me.G1.Controls.Add(Me.cmdcheque)
        Me.G1.Controls.Add(Me.cmdefectivo)
        Me.G1.Location = New System.Drawing.Point(7, 3)
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
        Me.G1.TabIndex = 71
        '
        'cmdtarjeta
        '
        Me.cmdtarjeta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdtarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdtarjeta.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdtarjeta.Image = Global.SAE.My.Resources.Resources.tarjeta
        Me.cmdtarjeta.Location = New System.Drawing.Point(136, 3)
        Me.cmdtarjeta.Name = "cmdtarjeta"
        Me.cmdtarjeta.Size = New System.Drawing.Size(69, 73)
        Me.cmdtarjeta.TabIndex = 1
        Me.cmdtarjeta.Text = "&T"
        Me.cmdtarjeta.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.cmdtarjeta, "Tarjeta Alt + T")
        Me.cmdtarjeta.UseVisualStyleBackColor = False
        '
        'cmdvarias
        '
        Me.cmdvarias.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdvarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdvarias.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdvarias.Image = Global.SAE.My.Resources.Resources.variasfp
        Me.cmdvarias.Location = New System.Drawing.Point(354, 3)
        Me.cmdvarias.Name = "cmdvarias"
        Me.cmdvarias.Size = New System.Drawing.Size(69, 73)
        Me.cmdvarias.TabIndex = 4
        Me.cmdvarias.Text = "&V"
        Me.cmdvarias.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ToolTip1.SetToolTip(Me.cmdvarias, "Varias formas de pago Alt + V")
        Me.cmdvarias.UseVisualStyleBackColor = False
        '
        'cmdcredito
        '
        Me.cmdcredito.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcredito.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcredito.Image = Global.SAE.My.Resources.Resources.credito
        Me.cmdcredito.Location = New System.Drawing.Point(281, 3)
        Me.cmdcredito.Name = "cmdcredito"
        Me.cmdcredito.Size = New System.Drawing.Size(69, 73)
        Me.cmdcredito.TabIndex = 3
        Me.cmdcredito.Text = "&O"
        Me.cmdcredito.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.cmdcredito, "Otro(crédito) Alt + O")
        Me.cmdcredito.UseVisualStyleBackColor = False
        '
        'cmdcheque
        '
        Me.cmdcheque.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcheque.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcheque.Image = Global.SAE.My.Resources.Resources.cheque
        Me.cmdcheque.Location = New System.Drawing.Point(63, 3)
        Me.cmdcheque.Name = "cmdcheque"
        Me.cmdcheque.Size = New System.Drawing.Size(69, 73)
        Me.cmdcheque.TabIndex = 0
        Me.cmdcheque.Text = "&C"
        Me.cmdcheque.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdcheque, "Cheque Alt + C")
        Me.cmdcheque.UseVisualStyleBackColor = False
        '
        'cmdefectivo
        '
        Me.cmdefectivo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdefectivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdefectivo.Image = Global.SAE.My.Resources.Resources.efectivo
        Me.cmdefectivo.Location = New System.Drawing.Point(208, 3)
        Me.cmdefectivo.Name = "cmdefectivo"
        Me.cmdefectivo.Size = New System.Drawing.Size(69, 73)
        Me.cmdefectivo.TabIndex = 2
        Me.cmdefectivo.Text = "&E"
        Me.ToolTip1.SetToolTip(Me.cmdefectivo, "Efectivo Alt + E")
        Me.cmdefectivo.UseVisualStyleBackColor = False
        '
        'cbtarj1
        '
        Me.cbtarj1.ContextMenuStrip = Me.mimenu
        Me.cbtarj1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtarj1.FormattingEnabled = True
        Me.cbtarj1.Items.AddRange(New Object() {"DB", "CR"})
        Me.cbtarj1.Location = New System.Drawing.Point(118, 67)
        Me.cbtarj1.Name = "cbtarj1"
        Me.cbtarj1.Size = New System.Drawing.Size(39, 21)
        Me.cbtarj1.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.cbtarj1, "tipo de tarjeta (DB=débito, CR=crédito)")
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
        'cbtarj2
        '
        Me.cbtarj2.ContextMenuStrip = Me.mimenu
        Me.cbtarj2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtarj2.FormattingEnabled = True
        Me.cbtarj2.Items.AddRange(New Object() {"DB", "CR"})
        Me.cbtarj2.Location = New System.Drawing.Point(118, 93)
        Me.cbtarj2.Name = "cbtarj2"
        Me.cbtarj2.Size = New System.Drawing.Size(39, 21)
        Me.cbtarj2.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.cbtarj2, "tipo de tarjeta (DB=débito, CR=crédito)")
        '
        'cbtarj3
        '
        Me.cbtarj3.ContextMenuStrip = Me.mimenu
        Me.cbtarj3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtarj3.FormattingEnabled = True
        Me.cbtarj3.Items.AddRange(New Object() {"DB", "CR"})
        Me.cbtarj3.Location = New System.Drawing.Point(118, 120)
        Me.cbtarj3.Name = "cbtarj3"
        Me.cbtarj3.Size = New System.Drawing.Size(39, 21)
        Me.cbtarj3.TabIndex = 27
        Me.ToolTip1.SetToolTip(Me.cbtarj3, "tipo de tarjeta (DB=débito, CR=crédito)")
        '
        'cbtarj
        '
        Me.cbtarj.ContextMenuStrip = Me.mimenu
        Me.cbtarj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtarj.FormattingEnabled = True
        Me.cbtarj.Items.AddRange(New Object() {"DB", "CR"})
        Me.cbtarj.Location = New System.Drawing.Point(168, 19)
        Me.cbtarj.Name = "cbtarj"
        Me.cbtarj.Size = New System.Drawing.Size(39, 21)
        Me.cbtarj.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cbtarj, "tipo de tarjeta (DB=débito, CR=crédito)")
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
        Me.ToolTip1.SetToolTip(Me.cmdcuenta, "Seleccionar Cuenta  PUC Alt + P")
        Me.cmdcuenta.UseVisualStyleBackColor = False
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
        Me.ToolTip1.SetToolTip(Me.cmdcontinuar, "Continuar con la Facturación Alt + A")
        Me.cmdcontinuar.UseVisualStyleBackColor = False
        '
        'tabfp
        '
        Me.tabfp.BackColor = System.Drawing.Color.White
        Me.tabfp.CanReorderTabs = True
        Me.tabfp.Controls.Add(Me.TabControlPanel6)
        Me.tabfp.Controls.Add(Me.TabControlPanel10)
        Me.tabfp.Location = New System.Drawing.Point(7, 96)
        Me.tabfp.Name = "tabfp"
        Me.tabfp.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabfp.SelectedTabIndex = 0
        Me.tabfp.Size = New System.Drawing.Size(486, 232)
        Me.tabfp.TabIndex = 72
        Me.tabfp.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabfp.Tabs.Add(Me.tabforma)
        Me.tabfp.Tabs.Add(Me.tabvarias)
        Me.tabfp.Text = "Cheque"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.gcre)
        Me.TabControlPanel6.Controls.Add(Me.gtar)
        Me.TabControlPanel6.Controls.Add(Me.gche)
        Me.TabControlPanel6.Controls.Add(Me.lbfp)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(486, 206)
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
        'gcre
        '
        Me.gcre.BackColor = System.Drawing.Color.Transparent
        Me.gcre.Controls.Add(Me.gdia)
        Me.gcre.Controls.Add(Me.txtespecifica)
        Me.gcre.Controls.Add(Me.Label6)
        Me.gcre.Location = New System.Drawing.Point(19, 138)
        Me.gcre.Name = "gcre"
        Me.gcre.Size = New System.Drawing.Size(446, 54)
        Me.gcre.TabIndex = 55
        Me.gcre.TabStop = False
        Me.gcre.Text = "Otro Medio"
        '
        'gdia
        '
        Me.gdia.BackColor = System.Drawing.Color.Transparent
        Me.gdia.Controls.Add(Me.txtdias)
        Me.gdia.Controls.Add(Me.rbsdia)
        Me.gdia.Controls.Add(Me.rbndia)
        Me.gdia.Location = New System.Drawing.Point(279, 8)
        Me.gdia.Name = "gdia"
        Me.gdia.Size = New System.Drawing.Size(156, 39)
        Me.gdia.TabIndex = 52
        Me.gdia.TabStop = False
        Me.gdia.Text = "Días de Vencimiento"
        '
        'txtdias
        '
        Me.txtdias.BackColor = System.Drawing.SystemColors.Control
        Me.txtdias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdias.Location = New System.Drawing.Point(93, 15)
        Me.txtdias.MaxLength = 4
        Me.txtdias.Name = "txtdias"
        Me.txtdias.ShortcutsEnabled = False
        Me.txtdias.Size = New System.Drawing.Size(49, 20)
        Me.txtdias.TabIndex = 7
        Me.txtdias.Text = "30"
        '
        'rbsdia
        '
        Me.rbsdia.AutoSize = True
        Me.rbsdia.Location = New System.Drawing.Point(51, 16)
        Me.rbsdia.Name = "rbsdia"
        Me.rbsdia.Size = New System.Drawing.Size(34, 17)
        Me.rbsdia.TabIndex = 1
        Me.rbsdia.TabStop = True
        Me.rbsdia.Text = "Si"
        Me.rbsdia.UseVisualStyleBackColor = True
        '
        'rbndia
        '
        Me.rbndia.AutoSize = True
        Me.rbndia.Location = New System.Drawing.Point(6, 17)
        Me.rbndia.Name = "rbndia"
        Me.rbndia.Size = New System.Drawing.Size(39, 17)
        Me.rbndia.TabIndex = 0
        Me.rbndia.TabStop = True
        Me.rbndia.Text = "No"
        Me.rbndia.UseVisualStyleBackColor = True
        '
        'txtespecifica
        '
        Me.txtespecifica.BackColor = System.Drawing.SystemColors.Control
        Me.txtespecifica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtespecifica.Location = New System.Drawing.Point(78, 22)
        Me.txtespecifica.Name = "txtespecifica"
        Me.txtespecifica.ShortcutsEnabled = False
        Me.txtespecifica.Size = New System.Drawing.Size(195, 20)
        Me.txtespecifica.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(10, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Especifique"
        '
        'gtar
        '
        Me.gtar.BackColor = System.Drawing.Color.Transparent
        Me.gtar.Controls.Add(Me.txtnumtarjeta)
        Me.gtar.Controls.Add(Me.Label14)
        Me.gtar.Controls.Add(Me.Label7)
        Me.gtar.Controls.Add(Me.cbtarj)
        Me.gtar.Controls.Add(Me.txttarjeta)
        Me.gtar.Location = New System.Drawing.Point(19, 84)
        Me.gtar.Name = "gtar"
        Me.gtar.Size = New System.Drawing.Size(446, 51)
        Me.gtar.TabIndex = 54
        Me.gtar.TabStop = False
        Me.gtar.Text = "Tarjeta"
        '
        'txtnumtarjeta
        '
        Me.txtnumtarjeta.BackColor = System.Drawing.SystemColors.Menu
        Me.txtnumtarjeta.Location = New System.Drawing.Point(258, 17)
        Me.txtnumtarjeta.Name = "txtnumtarjeta"
        Me.txtnumtarjeta.ShortcutsEnabled = False
        Me.txtnumtarjeta.Size = New System.Drawing.Size(160, 20)
        Me.txtnumtarjeta.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(139, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Tipo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(208, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Número"
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
        Me.gche.Location = New System.Drawing.Point(19, 36)
        Me.gche.Name = "gche"
        Me.gche.Size = New System.Drawing.Size(446, 45)
        Me.gche.TabIndex = 53
        Me.gche.TabStop = False
        Me.gche.Text = "Cheque"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.SystemColors.Control
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Location = New System.Drawing.Point(241, 17)
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(177, 20)
        Me.txtbanco.TabIndex = 6
        '
        'txtnumcheq
        '
        Me.txtnumcheq.BackColor = System.Drawing.SystemColors.Menu
        Me.txtnumcheq.Location = New System.Drawing.Point(65, 17)
        Me.txtnumcheq.Name = "txtnumcheq"
        Me.txtnumcheq.ShortcutsEnabled = False
        Me.txtnumcheq.Size = New System.Drawing.Size(121, 20)
        Me.txtnumcheq.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(15, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Número"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(197, 20)
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
        'tabforma
        '
        Me.tabforma.AttachedControl = Me.TabControlPanel6
        Me.tabforma.Name = "tabforma"
        Me.tabforma.Text = "Forma De Pago"
        '
        'TabControlPanel10
        '
        Me.TabControlPanel10.Controls.Add(Me.Label15)
        Me.TabControlPanel10.Controls.Add(Me.cbtarj3)
        Me.TabControlPanel10.Controls.Add(Me.cbtarj2)
        Me.TabControlPanel10.Controls.Add(Me.cbtarj1)
        Me.TabControlPanel10.Controls.Add(Me.txtnumtar3)
        Me.TabControlPanel10.Controls.Add(Me.txtvt3)
        Me.TabControlPanel10.Controls.Add(Me.txttar3)
        Me.TabControlPanel10.Controls.Add(Me.txtnumtar2)
        Me.TabControlPanel10.Controls.Add(Me.txtvt2)
        Me.TabControlPanel10.Controls.Add(Me.txttar2)
        Me.TabControlPanel10.Controls.Add(Me.txtnumtar1)
        Me.TabControlPanel10.Controls.Add(Me.Label19)
        Me.TabControlPanel10.Controls.Add(Me.Label17)
        Me.TabControlPanel10.Controls.Add(Me.Label18)
        Me.TabControlPanel10.Controls.Add(Me.txtbanco2)
        Me.TabControlPanel10.Controls.Add(Me.txtnumcheque2)
        Me.TabControlPanel10.Controls.Add(Me.txtvt1)
        Me.TabControlPanel10.Controls.Add(Me.txtvefec)
        Me.TabControlPanel10.Controls.Add(Me.txttar1)
        Me.TabControlPanel10.Controls.Add(Me.txtvche)
        Me.TabControlPanel10.Controls.Add(Me.Label13)
        Me.TabControlPanel10.Controls.Add(Me.Label12)
        Me.TabControlPanel10.Controls.Add(Me.Label11)
        Me.TabControlPanel10.Controls.Add(Me.Label10)
        Me.TabControlPanel10.Controls.Add(Me.Label9)
        Me.TabControlPanel10.Controls.Add(Me.Label1)
        Me.TabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel10.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel10.Name = "TabControlPanel10"
        Me.TabControlPanel10.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel10.Size = New System.Drawing.Size(486, 206)
        Me.TabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel10.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel10.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel10.Style.GradientAngle = 90
        Me.TabControlPanel10.TabIndex = 5
        Me.TabControlPanel10.TabItem = Me.tabvarias
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(119, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Tipo"
        '
        'txtnumtar3
        '
        Me.txtnumtar3.BackColor = System.Drawing.SystemColors.Control
        Me.txtnumtar3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumtar3.Location = New System.Drawing.Point(163, 120)
        Me.txtnumtar3.Name = "txtnumtar3"
        Me.txtnumtar3.ShortcutsEnabled = False
        Me.txtnumtar3.Size = New System.Drawing.Size(149, 20)
        Me.txtnumtar3.TabIndex = 28
        '
        'txtvt3
        '
        Me.txtvt3.BackColor = System.Drawing.SystemColors.Menu
        Me.txtvt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvt3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtvt3.Location = New System.Drawing.Point(318, 120)
        Me.txtvt3.Name = "txtvt3"
        Me.txtvt3.ShortcutsEnabled = False
        Me.txtvt3.Size = New System.Drawing.Size(158, 20)
        Me.txtvt3.TabIndex = 29
        Me.txtvt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttar3
        '
        Me.txttar3.BackColor = System.Drawing.SystemColors.Menu
        Me.txttar3.Location = New System.Drawing.Point(5, 120)
        Me.txttar3.Name = "txttar3"
        Me.txttar3.ShortcutsEnabled = False
        Me.txttar3.Size = New System.Drawing.Size(102, 20)
        Me.txttar3.TabIndex = 26
        '
        'txtnumtar2
        '
        Me.txtnumtar2.BackColor = System.Drawing.SystemColors.Control
        Me.txtnumtar2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumtar2.Location = New System.Drawing.Point(163, 94)
        Me.txtnumtar2.Name = "txtnumtar2"
        Me.txtnumtar2.ShortcutsEnabled = False
        Me.txtnumtar2.Size = New System.Drawing.Size(149, 20)
        Me.txtnumtar2.TabIndex = 24
        '
        'txtvt2
        '
        Me.txtvt2.BackColor = System.Drawing.SystemColors.Menu
        Me.txtvt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvt2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtvt2.Location = New System.Drawing.Point(318, 94)
        Me.txtvt2.Name = "txtvt2"
        Me.txtvt2.ShortcutsEnabled = False
        Me.txtvt2.Size = New System.Drawing.Size(158, 20)
        Me.txtvt2.TabIndex = 25
        Me.txtvt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttar2
        '
        Me.txttar2.BackColor = System.Drawing.SystemColors.Menu
        Me.txttar2.Location = New System.Drawing.Point(5, 94)
        Me.txttar2.Name = "txttar2"
        Me.txttar2.ShortcutsEnabled = False
        Me.txttar2.Size = New System.Drawing.Size(102, 20)
        Me.txttar2.TabIndex = 22
        '
        'txtnumtar1
        '
        Me.txtnumtar1.BackColor = System.Drawing.SystemColors.Control
        Me.txtnumtar1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumtar1.Location = New System.Drawing.Point(163, 68)
        Me.txtnumtar1.Name = "txtnumtar1"
        Me.txtnumtar1.ShortcutsEnabled = False
        Me.txtnumtar1.Size = New System.Drawing.Size(149, 20)
        Me.txtnumtar1.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(164, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Número"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(153, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Banco"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(6, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Número"
        '
        'txtbanco2
        '
        Me.txtbanco2.BackColor = System.Drawing.SystemColors.Control
        Me.txtbanco2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco2.Location = New System.Drawing.Point(197, 25)
        Me.txtbanco2.Name = "txtbanco2"
        Me.txtbanco2.ShortcutsEnabled = False
        Me.txtbanco2.Size = New System.Drawing.Size(115, 20)
        Me.txtbanco2.TabIndex = 16
        '
        'txtnumcheque2
        '
        Me.txtnumcheque2.BackColor = System.Drawing.SystemColors.Menu
        Me.txtnumcheque2.Location = New System.Drawing.Point(56, 25)
        Me.txtnumcheque2.Name = "txtnumcheque2"
        Me.txtnumcheque2.ShortcutsEnabled = False
        Me.txtnumcheque2.Size = New System.Drawing.Size(91, 20)
        Me.txtnumcheque2.TabIndex = 15
        '
        'txtvt1
        '
        Me.txtvt1.BackColor = System.Drawing.SystemColors.Menu
        Me.txtvt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvt1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtvt1.Location = New System.Drawing.Point(318, 68)
        Me.txtvt1.Name = "txtvt1"
        Me.txtvt1.ShortcutsEnabled = False
        Me.txtvt1.Size = New System.Drawing.Size(158, 20)
        Me.txtvt1.TabIndex = 21
        Me.txtvt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtvefec
        '
        Me.txtvefec.BackColor = System.Drawing.SystemColors.Menu
        Me.txtvefec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvefec.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtvefec.Location = New System.Drawing.Point(318, 152)
        Me.txtvefec.Name = "txtvefec"
        Me.txtvefec.ShortcutsEnabled = False
        Me.txtvefec.Size = New System.Drawing.Size(158, 20)
        Me.txtvefec.TabIndex = 30
        Me.txtvefec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttar1
        '
        Me.txttar1.BackColor = System.Drawing.SystemColors.Menu
        Me.txttar1.Location = New System.Drawing.Point(5, 68)
        Me.txttar1.Name = "txttar1"
        Me.txttar1.ShortcutsEnabled = False
        Me.txttar1.Size = New System.Drawing.Size(102, 20)
        Me.txttar1.TabIndex = 18
        '
        'txtvche
        '
        Me.txtvche.BackColor = System.Drawing.SystemColors.Menu
        Me.txtvche.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvche.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtvche.Location = New System.Drawing.Point(318, 25)
        Me.txtvche.Name = "txtvche"
        Me.txtvche.ShortcutsEnabled = False
        Me.txtvche.Size = New System.Drawing.Size(158, 20)
        Me.txtvche.TabIndex = 17
        Me.txtvche.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkRed
        Me.Label13.Location = New System.Drawing.Point(6, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Efectivo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(2, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 16)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Tarjetas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(4, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Cheques"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(427, -1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Valores"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(-5, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(524, 31)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "__________________________________"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-6, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(524, 31)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "__________________________________"
        '
        'tabvarias
        '
        Me.tabvarias.AttachedControl = Me.TabControlPanel10
        Me.tabvarias.Name = "tabvarias"
        Me.tabvarias.Text = "Varias Formas de Pago"
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
        Me.G2.Location = New System.Drawing.Point(6, 330)
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
        Me.G2.TabIndex = 73
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
        'cmdcancelar
        '
        Me.cmdcancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancelar.Location = New System.Drawing.Point(414, 48)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdcancelar.TabIndex = 74
        Me.cmdcancelar.Text = "Salir"
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'FrmFormaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.cmdcancelar
        Me.ClientSize = New System.Drawing.Size(499, 438)
        Me.Controls.Add(Me.G2)
        Me.Controls.Add(Me.tabfp)
        Me.Controls.Add(Me.G1)
        Me.Controls.Add(Me.cmdcancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFormaPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE FORMA DE PAGO   Salir Alt + F4"
        Me.G1.ResumeLayout(False)
        Me.mimenu.ResumeLayout(False)
        CType(Me.tabfp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabfp.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        Me.gcre.ResumeLayout(False)
        Me.gcre.PerformLayout()
        Me.gdia.ResumeLayout(False)
        Me.gdia.PerformLayout()
        Me.gtar.ResumeLayout(False)
        Me.gtar.PerformLayout()
        Me.gche.ResumeLayout(False)
        Me.gche.PerformLayout()
        Me.TabControlPanel10.ResumeLayout(False)
        Me.TabControlPanel10.PerformLayout()
        Me.G2.ResumeLayout(False)
        Me.G2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents G1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdtarjeta As System.Windows.Forms.Button
    Friend WithEvents cmdvarias As System.Windows.Forms.Button
    Friend WithEvents cmdcredito As System.Windows.Forms.Button
    Friend WithEvents cmdcheque As System.Windows.Forms.Button
    Friend WithEvents cmdefectivo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tabfp As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents lbfp As System.Windows.Forms.Label
    Friend WithEvents tabforma As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel10 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabvarias As DevComponents.DotNetBar.TabItem
    Friend WithEvents G2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcontinuar As System.Windows.Forms.Button
    Friend WithEvents txtespecifica As System.Windows.Forms.TextBox
    Friend WithEvents txtnumcheq As System.Windows.Forms.TextBox
    Friend WithEvents txtnumtarjeta As System.Windows.Forms.TextBox
    Friend WithEvents txttarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txttar1 As System.Windows.Forms.TextBox
    Friend WithEvents txtvche As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtvt1 As System.Windows.Forms.TextBox
    Friend WithEvents txtvefec As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtbanco2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnumcheque2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnumtar1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtnumtar2 As System.Windows.Forms.TextBox
    Friend WithEvents txtvt2 As System.Windows.Forms.TextBox
    Friend WithEvents txttar2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnumtar3 As System.Windows.Forms.TextBox
    Friend WithEvents txtvt3 As System.Windows.Forms.TextBox
    Friend WithEvents txttar3 As System.Windows.Forms.TextBox
    Friend WithEvents txtcambio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtpago As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbtarj1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbtarj As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbtarj3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbtarj2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdcuenta As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEstoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gdia As System.Windows.Forms.GroupBox
    Friend WithEvents txtdias As System.Windows.Forms.TextBox
    Friend WithEvents rbsdia As System.Windows.Forms.RadioButton
    Friend WithEvents rbndia As System.Windows.Forms.RadioButton
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents gcre As System.Windows.Forms.GroupBox
    Friend WithEvents gtar As System.Windows.Forms.GroupBox
    Friend WithEvents gche As System.Windows.Forms.GroupBox
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
End Class
