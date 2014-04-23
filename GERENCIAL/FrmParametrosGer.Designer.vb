<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParametrosGer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParametrosGer))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmddel = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.lbnum = New System.Windows.Forms.Label
        Me.lbtipo = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(-2, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(441, 32)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "ESTOS PARAMETROS SON OBLIGATORIOS PARA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " VISUALIZAR LOS INFORMES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Brown
        Me.Label17.Location = New System.Drawing.Point(48, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(336, 16)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "_________________________________________"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.IndianRed
        Me.Label1.Location = New System.Drawing.Point(142, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "* Doble clic para escoger cuentas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmddel)
        Me.GroupPanel1.Controls.Add(Me.cmdadd)
        Me.GroupPanel1.Location = New System.Drawing.Point(2, 273)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(446, 85)
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
        Me.GroupPanel1.TabIndex = 79
        '
        'cmddel
        '
        Me.cmddel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmddel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddel.ForeColor = System.Drawing.Color.Transparent
        Me.cmddel.Image = Global.SAE.My.Resources.Resources.back
        Me.cmddel.Location = New System.Drawing.Point(232, 7)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(72, 68)
        Me.cmddel.TabIndex = 2
        Me.cmddel.Text = "&q"
        Me.cmddel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmddel.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Transparent
        Me.cmdadd.Image = Global.SAE.My.Resources.Resources.add
        Me.cmdadd.Location = New System.Drawing.Point(154, 7)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 68)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&a"
        Me.cmdadd.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'gcuenta
        '
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.descripcion, Me.CUENTA})
        Me.gcuenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gcuenta.Location = New System.Drawing.Point(16, 113)
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gcuenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gcuenta.Size = New System.Drawing.Size(410, 139)
        Me.gcuenta.TabIndex = 78
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "   SEL"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "CUENTA #"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.MinimumWidth = 300
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 300
        '
        'CUENTA
        '
        Me.CUENTA.HeaderText = "CUENTA"
        Me.CUENTA.MinimumWidth = 100
        Me.CUENTA.Name = "CUENTA"
        Me.CUENTA.ReadOnly = True
        Me.CUENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.c2)
        Me.GroupBox1.Controls.Add(Me.c1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 46)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(203, 19)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(112, 17)
        Me.c2.TabIndex = 1
        Me.c2.Text = "Gastos y/o Costos"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(82, 19)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(65, 17)
        Me.c1.TabIndex = 0
        Me.c1.TabStop = True
        Me.c1.Text = "Ingresos"
        Me.c1.UseVisualStyleBackColor = True
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnum.Location = New System.Drawing.Point(14, 97)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(14, 13)
        Me.lbnum.TabIndex = 83
        Me.lbnum.Text = "0"
        Me.lbnum.Visible = False
        '
        'lbtipo
        '
        Me.lbtipo.AutoSize = True
        Me.lbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtipo.ForeColor = System.Drawing.Color.Purple
        Me.lbtipo.Location = New System.Drawing.Point(186, 97)
        Me.lbtipo.Name = "lbtipo"
        Me.lbtipo.Size = New System.Drawing.Size(28, 13)
        Me.lbtipo.TabIndex = 82
        Me.lbtipo.Text = "tipo"
        '
        'FrmParametrosGer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(451, 363)
        Me.Controls.Add(Me.lbnum)
        Me.Controls.Add(Me.lbtipo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gcuenta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParametrosGer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametros"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents lbtipo As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
