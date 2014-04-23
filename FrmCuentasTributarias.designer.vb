<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentasTributarias
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
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DETALLE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmddel = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbtipo = New System.Windows.Forms.Label
        Me.lbnum = New System.Windows.Forms.Label
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla
        '
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.DETALLE})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grilla.Location = New System.Drawing.Point(5, 10)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla.Size = New System.Drawing.Size(354, 181)
        Me.grilla.TabIndex = 60
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Descripcion.Frozen = True
        Me.Descripcion.HeaderText = "NUM"
        Me.Descripcion.MaxInputLength = 30
        Me.Descripcion.MinimumWidth = 50
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 50
        '
        'DETALLE
        '
        Me.DETALLE.HeaderText = "DETALLE INFORME"
        Me.DETALLE.MinimumWidth = 300
        Me.DETALLE.Name = "DETALLE"
        Me.DETALLE.ReadOnly = True
        Me.DETALLE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DETALLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DETALLE.Width = 300
        '
        'gcuenta
        '
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.CUENTA})
        Me.gcuenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gcuenta.Location = New System.Drawing.Point(372, 32)
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gcuenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gcuenta.Size = New System.Drawing.Size(207, 139)
        Me.gcuenta.TabIndex = 61
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
        '
        'CUENTA
        '
        Me.CUENTA.HeaderText = "CUENTA"
        Me.CUENTA.MinimumWidth = 100
        Me.CUENTA.Name = "CUENTA"
        Me.CUENTA.ReadOnly = True
        Me.CUENTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmddel)
        Me.GroupPanel1.Controls.Add(Me.cmdadd)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 201)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(574, 85)
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
        Me.GroupPanel1.TabIndex = 71
        '
        'cmddel
        '
        Me.cmddel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmddel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddel.ForeColor = System.Drawing.Color.Transparent
        Me.cmddel.Image = Global.SAE.My.Resources.Resources.back
        Me.cmddel.Location = New System.Drawing.Point(292, 10)
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
        Me.cmdadd.Location = New System.Drawing.Point(216, 10)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 68)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&a"
        Me.cmdadd.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.IndianRed
        Me.Label1.Location = New System.Drawing.Point(372, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "* Doble clic para escoger cuentas"
        '
        'lbtipo
        '
        Me.lbtipo.AutoSize = True
        Me.lbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtipo.Location = New System.Drawing.Point(383, 9)
        Me.lbtipo.Name = "lbtipo"
        Me.lbtipo.Size = New System.Drawing.Size(28, 13)
        Me.lbtipo.TabIndex = 73
        Me.lbtipo.Text = "tipo"
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnum.Location = New System.Drawing.Point(370, 9)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(14, 13)
        Me.lbnum.TabIndex = 74
        Me.lbnum.Text = "0"
        '
        'FrmCuentasTributarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(587, 290)
        Me.Controls.Add(Me.lbnum)
        Me.Controls.Add(Me.lbtipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gcuenta)
        Me.Controls.Add(Me.grilla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmCuentasTributarias"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Cuentas Tributarias"
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETALLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbtipo As System.Windows.Forms.Label
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
