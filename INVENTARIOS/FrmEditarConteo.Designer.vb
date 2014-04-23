<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditarConteo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantlibro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantfisica = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.guarcol = New System.Windows.Forms.DataGridViewButtonColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChDif = New System.Windows.Forms.CheckBox
        Me.ChRep = New System.Windows.Forms.CheckBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbnombod = New System.Windows.Forms.Label
        Me.lbnumbod = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbdoc = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbtipo = New System.Windows.Forms.Label
        Me.lbnum = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gitems)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 377)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.referencia, Me.descripcion, Me.cantlibro, Me.cantfisica, Me.ctainv, Me.ctacos, Me.guarcol, Me.costo})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(9, 15)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(745, 353)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 5
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MaxInputLength = 300
        Me.codigo.MinimumWidth = 80
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 80
        '
        'referencia
        '
        Me.referencia.Frozen = True
        Me.referencia.HeaderText = "REFERENCIA"
        Me.referencia.MinimumWidth = 80
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Width = 80
        '
        'descripcion
        '
        Me.descripcion.Frozen = True
        Me.descripcion.HeaderText = "DESCRIPCIÓN"
        Me.descripcion.MinimumWidth = 220
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 220
        '
        'cantlibro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cantlibro.DefaultCellStyle = DataGridViewCellStyle1
        Me.cantlibro.HeaderText = "CANT. LIBROS"
        Me.cantlibro.MinimumWidth = 120
        Me.cantlibro.Name = "cantlibro"
        Me.cantlibro.ReadOnly = True
        Me.cantlibro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cantlibro.Width = 120
        '
        'cantfisica
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cantfisica.DefaultCellStyle = DataGridViewCellStyle2
        Me.cantfisica.HeaderText = "CANT. FÍSICA"
        Me.cantfisica.MinimumWidth = 120
        Me.cantfisica.Name = "cantfisica"
        Me.cantfisica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cantfisica.Width = 120
        '
        'ctainv
        '
        Me.ctainv.HeaderText = "CTA INV"
        Me.ctainv.Name = "ctainv"
        Me.ctainv.Visible = False
        '
        'ctacos
        '
        Me.ctacos.HeaderText = "CTA COS"
        Me.ctacos.Name = "ctacos"
        Me.ctacos.Visible = False
        '
        'guarcol
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = "Guardar Fila"
        Me.guarcol.DefaultCellStyle = DataGridViewCellStyle3
        Me.guarcol.HeaderText = "GUARDAR FILA"
        Me.guarcol.Name = "guarcol"
        '
        'costo
        '
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.ChDif)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 460)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(766, 85)
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
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(345, 8)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 3
        Me.CmdSalir.Text = "&S"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.gparam
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(489, 3)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 2
        Me.CmdRegistrarCambios.Text = "&G"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        Me.CmdRegistrarCambios.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbnum)
        Me.GroupBox2.Controls.Add(Me.lbtipo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lbdoc)
        Me.GroupBox2.Controls.Add(Me.ChRep)
        Me.GroupBox2.Controls.Add(Me.txtperiodo)
        Me.GroupBox2.Controls.Add(Me.txtdia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lbnombod)
        Me.GroupBox2.Controls.Add(Me.lbnumbod)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(765, 74)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ChDif
        '
        Me.ChDif.AutoSize = True
        Me.ChDif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChDif.Location = New System.Drawing.Point(15, 24)
        Me.ChDif.Name = "ChDif"
        Me.ChDif.Size = New System.Drawing.Size(275, 19)
        Me.ChDif.TabIndex = 84
        Me.ChDif.Text = "Reporte Solo Articulos Con Diferencias"
        Me.ChDif.UseVisualStyleBackColor = True
        Me.ChDif.Visible = False
        '
        'ChRep
        '
        Me.ChRep.AutoSize = True
        Me.ChRep.Checked = True
        Me.ChRep.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChRep.Location = New System.Drawing.Point(59, 43)
        Me.ChRep.Name = "ChRep"
        Me.ChRep.Size = New System.Drawing.Size(205, 19)
        Me.ChRep.TabIndex = 83
        Me.ChRep.Text = "Generar Reporte al Guardar"
        Me.ChRep.UseVisualStyleBackColor = True
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(518, 13)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 81
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(491, 13)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 80
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(302, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Fecha  de Conteo (dd/mm/aaaa)"
        '
        'lbnombod
        '
        Me.lbnombod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbnombod.Location = New System.Drawing.Point(135, 12)
        Me.lbnombod.Name = "lbnombod"
        Me.lbnombod.Size = New System.Drawing.Size(157, 21)
        Me.lbnombod.TabIndex = 68
        Me.lbnombod.Text = "bodega"
        Me.lbnombod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbnumbod
        '
        Me.lbnumbod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbnumbod.Location = New System.Drawing.Point(106, 12)
        Me.lbnumbod.Name = "lbnumbod"
        Me.lbnumbod.Size = New System.Drawing.Size(30, 21)
        Me.lbnumbod.TabIndex = 67
        Me.lbnumbod.Text = "0"
        Me.lbnumbod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Bodega"
        '
        'lbdoc
        '
        Me.lbdoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(444, 44)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(128, 19)
        Me.lbdoc.TabIndex = 85
        Me.lbdoc.Text = "AJ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(304, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Documento de Ajuste"
        '
        'lbtipo
        '
        Me.lbtipo.AutoSize = True
        Me.lbtipo.Location = New System.Drawing.Point(646, 20)
        Me.lbtipo.Name = "lbtipo"
        Me.lbtipo.Size = New System.Drawing.Size(24, 13)
        Me.lbtipo.TabIndex = 87
        Me.lbtipo.Text = "tipo"
        Me.lbtipo.Visible = False
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Location = New System.Drawing.Point(646, 43)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(27, 13)
        Me.lbnum.TabIndex = 88
        Me.lbnum.Text = "num"
        Me.lbnum.Visible = False
        '
        'FrmEditarConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(777, 548)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditarConteo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Editar Conteo Físico"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbnombod As System.Windows.Forms.Label
    Friend WithEvents lbnumbod As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChDif As System.Windows.Forms.CheckBox
    Friend WithEvents ChRep As System.Windows.Forms.CheckBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantlibro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantfisica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents guarcol As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents lbtipo As System.Windows.Forms.Label
End Class
