<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModPreciosManual
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cborden = New System.Windows.Forms.ComboBox
        Me.cbnombre = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbitems = New System.Windows.Forms.Label
        Me.cbtipo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtlista = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cblista = New System.Windows.Forms.ComboBox
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.np = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.guardar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdcancela = New System.Windows.Forms.Button
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbprecio = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cborden)
        Me.GroupBox1.Controls.Add(Me.cbnombre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbitems)
        Me.GroupBox1.Controls.Add(Me.cbtipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtlista)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cblista)
        Me.GroupBox1.Controls.Add(Me.gitems)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(804, 429)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(315, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "ORDENAR POR"
        '
        'cborden
        '
        Me.cborden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cborden.FormattingEnabled = True
        Me.cborden.Items.AddRange(New Object() {"CODIGO", "NOMBRE"})
        Me.cborden.Location = New System.Drawing.Point(440, 50)
        Me.cborden.Name = "cborden"
        Me.cborden.Size = New System.Drawing.Size(143, 21)
        Me.cborden.TabIndex = 78
        '
        'cbnombre
        '
        Me.cbnombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbnombre.FormattingEnabled = True
        Me.cbnombre.Items.AddRange(New Object() {"NORMAL", "DETALLADO"})
        Me.cbnombre.Location = New System.Drawing.Point(163, 53)
        Me.cbnombre.Name = "cbnombre"
        Me.cbnombre.Size = New System.Drawing.Size(143, 21)
        Me.cbnombre.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "MOSTRAR NOMBRE"
        '
        'lbitems
        '
        Me.lbitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitems.ForeColor = System.Drawing.Color.DarkRed
        Me.lbitems.Location = New System.Drawing.Point(636, 50)
        Me.lbitems.Name = "lbitems"
        Me.lbitems.Size = New System.Drawing.Size(160, 23)
        Me.lbitems.TabIndex = 75
        Me.lbitems.Text = "Hay 0 items"
        Me.lbitems.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbtipo
        '
        Me.cbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipo.FormattingEnabled = True
        Me.cbtipo.Items.AddRange(New Object() {"INVENTARIOS", "SERVICIOS"})
        Me.cbtipo.Location = New System.Drawing.Point(163, 23)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Size = New System.Drawing.Size(143, 21)
        Me.cbtipo.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 16)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "MOSTRAR ITEMS DE"
        '
        'txtlista
        '
        Me.txtlista.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtlista.Enabled = False
        Me.txtlista.Location = New System.Drawing.Point(440, 24)
        Me.txtlista.Name = "txtlista"
        Me.txtlista.ReadOnly = True
        Me.txtlista.Size = New System.Drawing.Size(356, 20)
        Me.txtlista.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(315, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "LISTA"
        '
        'cblista
        '
        Me.cblista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cblista.FormattingEnabled = True
        Me.cblista.Location = New System.Drawing.Point(369, 23)
        Me.cblista.Name = "cblista"
        Me.cblista.Size = New System.Drawing.Size(65, 21)
        Me.cblista.TabIndex = 70
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.ref, Me.desc, Me.iva, Me.pa, Me.np, Me.guardar})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(6, 77)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.Size = New System.Drawing.Size(790, 345)
        Me.gitems.TabIndex = 69
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
        Me.desc.MinimumWidth = 260
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Width = 260
        '
        'iva
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.iva.DefaultCellStyle = DataGridViewCellStyle1
        Me.iva.Frozen = True
        Me.iva.HeaderText = "IVA %"
        Me.iva.MinimumWidth = 50
        Me.iva.Name = "iva"
        Me.iva.ReadOnly = True
        Me.iva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.iva.Width = 50
        '
        'pa
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.pa.DefaultCellStyle = DataGridViewCellStyle2
        Me.pa.Frozen = True
        Me.pa.HeaderText = "PRECIO ACTUAL"
        Me.pa.MinimumWidth = 100
        Me.pa.Name = "pa"
        Me.pa.ReadOnly = True
        Me.pa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'np
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.np.DefaultCellStyle = DataGridViewCellStyle3
        Me.np.Frozen = True
        Me.np.HeaderText = "NUEVO PRECIO"
        Me.np.MinimumWidth = 100
        Me.np.Name = "np"
        Me.np.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'guardar
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = "Guardar"
        Me.guardar.DefaultCellStyle = DataGridViewCellStyle4
        Me.guardar.Frozen = True
        Me.guardar.HeaderText = "GUARDAR"
        Me.guardar.MinimumWidth = 70
        Me.guardar.Name = "guardar"
        Me.guardar.Text = "Guardar"
        Me.guardar.Width = 70
        '
        'cmdcancela
        '
        Me.cmdcancela.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancela.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancela.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancela.Location = New System.Drawing.Point(366, 3)
        Me.cmdcancela.Name = "cmdcancela"
        Me.cmdcancela.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancela.TabIndex = 1
        Me.cmdcancela.Text = "&c"
        Me.cmdcancela.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancela, "Salir sin guardar")
        Me.cmdcancela.UseVisualStyleBackColor = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbprecio)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.cmdcancela)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 437)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(804, 78)
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
        Me.GroupPanel1.TabIndex = 35
        '
        'lbprecio
        '
        Me.lbprecio.BackColor = System.Drawing.Color.PapayaWhip
        Me.lbprecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbprecio.ForeColor = System.Drawing.Color.DarkRed
        Me.lbprecio.Location = New System.Drawing.Point(471, 21)
        Me.lbprecio.Name = "lbprecio"
        Me.lbprecio.Size = New System.Drawing.Size(296, 29)
        Me.lbprecio.TabIndex = 3
        Me.lbprecio.Text = "COLOCAR PRECIOS CON IVA INCLUIDO"
        Me.lbprecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(15, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(331, 56)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Nota:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-Para los articulos de inventario digitar precios sin iva." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-Para los serv" & _
            "icios digitar precios con iva incluido."
        '
        'FrmModPreciosManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(817, 520)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmModPreciosManual"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Modificar Precios Manualmente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcancela As System.Windows.Forms.Button
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents cblista As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtlista As System.Windows.Forms.TextBox
    Friend WithEvents cbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbitems As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cborden As System.Windows.Forms.ComboBox
    Friend WithEvents cbnombre As System.Windows.Forms.ComboBox
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents np As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents guardar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbprecio As System.Windows.Forms.Label
End Class
