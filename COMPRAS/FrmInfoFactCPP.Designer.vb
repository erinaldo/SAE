<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoFactCPP
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtdoc_ext = New System.Windows.Forms.TextBox
        Me.cmdBuscarExt = New System.Windows.Forms.Button
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.txttipo = New System.Windows.Forms.ComboBox
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbsel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbfecha = New System.Windows.Forms.Label
        Me.lbvalor = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbvmto = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbsaldo = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbpagado = New System.Windows.Forms.Label
        Me.lbdoc_i = New System.Windows.Forms.Label
        Me.lbdoc_e = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdoc_ext)
        Me.GroupBox2.Controls.Add(Me.cmdBuscarExt)
        Me.GroupBox2.Controls.Add(Me.cmdBuscar)
        Me.GroupBox2.Controls.Add(Me.CmdMostrar)
        Me.GroupBox2.Controls.Add(Me.txtnumfac)
        Me.GroupBox2.Controls.Add(Me.txttipo)
        Me.GroupBox2.Controls.Add(Me.txttipo2)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtcliente)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 110)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Documento"
        '
        'txtdoc_ext
        '
        Me.txtdoc_ext.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc_ext.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc_ext.Location = New System.Drawing.Point(461, 79)
        Me.txtdoc_ext.Name = "txtdoc_ext"
        Me.txtdoc_ext.ShortcutsEnabled = False
        Me.txtdoc_ext.Size = New System.Drawing.Size(120, 20)
        Me.txtdoc_ext.TabIndex = 189
        Me.ToolTip1.SetToolTip(Me.txtdoc_ext, "Numero del documento")
        '
        'cmdBuscarExt
        '
        Me.cmdBuscarExt.Location = New System.Drawing.Point(587, 71)
        Me.cmdBuscarExt.Name = "cmdBuscarExt"
        Me.cmdBuscarExt.Size = New System.Drawing.Size(49, 32)
        Me.cmdBuscarExt.TabIndex = 188
        Me.cmdBuscarExt.Text = "Buscar"
        Me.cmdBuscarExt.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(291, 72)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(49, 32)
        Me.cmdBuscar.TabIndex = 6
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(240, 72)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(49, 32)
        Me.CmdMostrar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar documentos")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumfac.Location = New System.Drawing.Point(118, 79)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(120, 20)
        Me.txtnumfac.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtnumfac, "Numero del documento")
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txttipo.FormattingEnabled = True
        Me.txttipo.Location = New System.Drawing.Point(118, 47)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(58, 21)
        Me.txttipo.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txttipo, "tipo de documento")
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(181, 48)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(454, 20)
        Me.txttipo2.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 84)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Numero Documento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "Tipo Documento"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(246, 19)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(389, 20)
        Me.txtcliente.TabIndex = 1
        '
        'txtnit
        '
        Me.txtnit.Location = New System.Drawing.Point(118, 19)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(119, 20)
        Me.txtnit.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtnit, "nit / cedula del proveedor")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Nit/Cedula Proveedor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(359, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 190
        Me.Label12.Text = "Documento Externo"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(345, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 35)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "||" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "||" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbsel
        '
        Me.lbsel.AutoSize = True
        Me.lbsel.Location = New System.Drawing.Point(535, 29)
        Me.lbsel.Name = "lbsel"
        Me.lbsel.Size = New System.Drawing.Size(19, 13)
        Me.lbsel.TabIndex = 187
        Me.lbsel.Text = "no"
        Me.lbsel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(245, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Datos Del Documento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha"
        '
        'lbfecha
        '
        Me.lbfecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfecha.Location = New System.Drawing.Point(76, 188)
        Me.lbfecha.Name = "lbfecha"
        Me.lbfecha.Size = New System.Drawing.Size(111, 20)
        Me.lbfecha.TabIndex = 6
        Me.lbfecha.Text = "00/00/0000"
        Me.ToolTip1.SetToolTip(Me.lbfecha, "fecha documento")
        '
        'lbvalor
        '
        Me.lbvalor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbvalor.Location = New System.Drawing.Point(258, 188)
        Me.lbvalor.Name = "lbvalor"
        Me.lbvalor.Size = New System.Drawing.Size(180, 20)
        Me.lbvalor.TabIndex = 8
        Me.lbvalor.Text = "0,00"
        Me.lbvalor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lbvalor, "valor facturado")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(194, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Valor $"
        '
        'lbvmto
        '
        Me.lbvmto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbvmto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbvmto.Location = New System.Drawing.Point(553, 188)
        Me.lbvmto.Name = "lbvmto"
        Me.lbvmto.Size = New System.Drawing.Size(111, 20)
        Me.lbvmto.TabIndex = 10
        Me.lbvmto.Text = "00/00/0000"
        Me.ToolTip1.SetToolTip(Me.lbvmto, "fecha de vencimiento")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(445, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 20)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Vencimiento"
        '
        'lbsaldo
        '
        Me.lbsaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbsaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsaldo.Location = New System.Drawing.Point(466, 394)
        Me.lbsaldo.Name = "lbsaldo"
        Me.lbsaldo.Size = New System.Drawing.Size(180, 20)
        Me.lbsaldo.TabIndex = 13
        Me.lbsaldo.Text = "0,00"
        Me.lbsaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lbsaldo, "Valor por pagar")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(320, 394)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Valor por Pagar $"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.lbsel)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 420)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(652, 85)
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
        Me.GroupPanel1.TabIndex = 1
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(295, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 0
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.doc, Me.concepto, Me.fecha, Me.valor})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(12, 221)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(652, 169)
        Me.grilla.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.grilla, "pagos al documento")
        '
        'doc
        '
        Me.doc.FillWeight = 80.0!
        Me.doc.HeaderText = "Documento"
        Me.doc.MaxInputLength = 12
        Me.doc.MinimumWidth = 80
        Me.doc.Name = "doc"
        Me.doc.ReadOnly = True
        Me.doc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.doc.Width = 80
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.MinimumWidth = 320
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.Width = 320
        '
        'fecha
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle1
        Me.fecha.FillWeight = 180.0!
        Me.fecha.HeaderText = "Fecha (dd/mm/yyyy)"
        Me.fecha.MaxInputLength = 12
        Me.fecha.MinimumWidth = 120
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha.Width = 120
        '
        'valor
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle2.Format = "N2"
        Me.valor.DefaultCellStyle = DataGridViewCellStyle2
        Me.valor.HeaderText = "Valor Abonado"
        Me.valor.MaxInputLength = 30
        Me.valor.MinimumWidth = 110
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.valor.Width = 110
        '
        'lbpagado
        '
        Me.lbpagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbpagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbpagado.Location = New System.Drawing.Point(141, 394)
        Me.lbpagado.Name = "lbpagado"
        Me.lbpagado.Size = New System.Drawing.Size(180, 20)
        Me.lbpagado.TabIndex = 15
        Me.lbpagado.Text = "0,00"
        Me.lbpagado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lbpagado, "Valor por pagar")
        '
        'lbdoc_i
        '
        Me.lbdoc_i.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdoc_i.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc_i.Location = New System.Drawing.Point(186, 154)
        Me.lbdoc_i.Name = "lbdoc_i"
        Me.lbdoc_i.Size = New System.Drawing.Size(142, 20)
        Me.lbdoc_i.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.lbdoc_i, "fecha documento")
        '
        'lbdoc_e
        '
        Me.lbdoc_e.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdoc_e.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc_e.Location = New System.Drawing.Point(521, 153)
        Me.lbdoc_e.Name = "lbdoc_e"
        Me.lbdoc_e.Size = New System.Drawing.Size(142, 20)
        Me.lbdoc_e.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.lbdoc_e, "fecha documento")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 394)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Valor Pagado $"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Documento Interno"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(353, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(168, 20)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Documento Externo"
        '
        'FrmInfoFactCPP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(674, 518)
        Me.Controls.Add(Me.lbdoc_e)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbdoc_i)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbpagado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.lbsaldo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.lbvmto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbvalor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbfecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoFactCPP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Consulta del Estado de una Factura por Proveedor"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.ComboBox
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbfecha As System.Windows.Forms.Label
    Friend WithEvents lbvalor As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbvmto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbsaldo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents lbsel As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbpagado As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdBuscarExt As System.Windows.Forms.Button
    Friend WithEvents lbdoc_i As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbdoc_e As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtdoc_ext As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
