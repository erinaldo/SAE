<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMarcarPedidos
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbfecha = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbfecha2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbcumplido = New System.Windows.Forms.Label
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.lbsel = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pedida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.recibida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.recibida2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdBuscar)
        Me.GroupBox2.Controls.Add(Me.CmdMostrar)
        Me.GroupBox2.Controls.Add(Me.txtnumfac)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtcliente)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(652, 90)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Documento"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(315, 45)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(49, 32)
        Me.cmdBuscar.TabIndex = 6
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(264, 45)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(49, 32)
        Me.CmdMostrar.TabIndex = 5
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumfac.Location = New System.Drawing.Point(133, 52)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(120, 20)
        Me.txtnumfac.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Numero del Pedido"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(264, 19)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(371, 20)
        Me.txtcliente.TabIndex = 1
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(136, 19)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(119, 20)
        Me.txtnit.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Nit/Cedula Proveedor"
        '
        'lbfecha
        '
        Me.lbfecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfecha.Location = New System.Drawing.Point(130, 112)
        Me.lbfecha.Name = "lbfecha"
        Me.lbfecha.Size = New System.Drawing.Size(111, 20)
        Me.lbfecha.TabIndex = 8
        Me.lbfecha.Text = "00/00/0000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fecha Pedido"
        '
        'lbfecha2
        '
        Me.lbfecha2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbfecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfecha2.Location = New System.Drawing.Point(396, 111)
        Me.lbfecha2.Name = "lbfecha2"
        Me.lbfecha2.Size = New System.Drawing.Size(111, 20)
        Me.lbfecha2.TabIndex = 10
        Me.lbfecha2.Text = "00/00/0000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(266, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha Entrega"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdguardar)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.lbsel)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 310)
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
        Me.GroupPanel1.TabIndex = 2
        '
        'lbcumplido
        '
        Me.lbcumplido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcumplido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcumplido.Location = New System.Drawing.Point(614, 111)
        Me.lbcumplido.Name = "lbcumplido"
        Me.lbcumplido.Size = New System.Drawing.Size(44, 20)
        Me.lbcumplido.TabIndex = 190
        Me.lbcumplido.Text = "no"
        Me.lbcumplido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(249, 6)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 0
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(325, 6)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 1
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdcancelar.UseVisualStyleBackColor = False
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
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tipo, Me.codigo, Me.concepto, Me.pedida, Me.recibida, Me.recibida2, Me.item})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(6, 135)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(652, 169)
        Me.grilla.TabIndex = 1
        '
        'tipo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tipo.DefaultCellStyle = DataGridViewCellStyle9
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.MinimumWidth = 40
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Width = 40
        '
        'codigo
        '
        Me.codigo.FillWeight = 80.0!
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.MaxInputLength = 12
        Me.codigo.MinimumWidth = 80
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 80
        '
        'concepto
        '
        Me.concepto.HeaderText = "Descripcion"
        Me.concepto.MinimumWidth = 290
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.concepto.Width = 290
        '
        'pedida
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pedida.DefaultCellStyle = DataGridViewCellStyle10
        Me.pedida.FillWeight = 180.0!
        Me.pedida.HeaderText = "Cantidad Pedida"
        Me.pedida.MaxInputLength = 12
        Me.pedida.MinimumWidth = 110
        Me.pedida.Name = "pedida"
        Me.pedida.ReadOnly = True
        Me.pedida.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pedida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pedida.Width = 110
        '
        'recibida
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle11.Format = "N2"
        Me.recibida.DefaultCellStyle = DataGridViewCellStyle11
        Me.recibida.HeaderText = "Cantidad Recibida"
        Me.recibida.MaxInputLength = 30
        Me.recibida.MinimumWidth = 110
        Me.recibida.Name = "recibida"
        Me.recibida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.recibida.Width = 110
        '
        'recibida2
        '
        Me.recibida2.HeaderText = "Recibida"
        Me.recibida2.Name = "recibida2"
        Me.recibida2.ReadOnly = True
        Me.recibida2.Visible = False
        '
        'item
        '
        Me.item.HeaderText = "Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.item.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(531, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cumplido"
        '
        'FrmMarcarPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(665, 400)
        Me.Controls.Add(Me.lbcumplido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.lbfecha2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbfecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMarcarPedidos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Marcar Pedidos Cumplidos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbfecha As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbfecha2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbsel As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents lbcumplido As System.Windows.Forms.Label
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pedida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recibida2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
