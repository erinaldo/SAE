<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelMetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelMetas))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmditems = New System.Windows.Forms.Button
        Me.lbfila = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbbuscar = New System.Windows.Forms.ComboBox
        Me.ok = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.area = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tope = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(179, 6)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 0
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "seleccionar cliente  Alt+S")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(90, 48)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(20, 13)
        Me.lbfila.TabIndex = 70
        Me.lbfila.Text = "fila"
        Me.lbfila.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbform.Location = New System.Drawing.Point(90, 26)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 68
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbbuscar)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(450, 52)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'cmbbuscar
        '
        Me.cmbbuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbuscar.FormattingEnabled = True
        Me.cmbbuscar.Items.AddRange(New Object() {"CODIGO", "AREA"})
        Me.cmbbuscar.Location = New System.Drawing.Point(99, 17)
        Me.cmbbuscar.Name = "cmbbuscar"
        Me.cmbbuscar.Size = New System.Drawing.Size(115, 21)
        Me.cmbbuscar.TabIndex = 77
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(384, 15)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(45, 23)
        Me.ok.TabIndex = 1
        Me.ok.Text = "Ok"
        Me.ok.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "BUSCAR POR "
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(220, 17)
        Me.txtcuenta.MaxLength = 100
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(158, 20)
        Me.txtcuenta.TabIndex = 0
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 380)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(450, 85)
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
        Me.GroupPanel1.TabIndex = 8
        '
        'gitems
        '
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod, Me.area, Me.tope})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(20, 60)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(416, 315)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 7
        '
        'cod
        '
        Me.cod.HeaderText = "CODIGO"
        Me.cod.Name = "cod"
        Me.cod.ReadOnly = True
        '
        'area
        '
        Me.area.HeaderText = "AREA"
        Me.area.MinimumWidth = 200
        Me.area.Name = "area"
        Me.area.ReadOnly = True
        Me.area.Width = 200
        '
        'tope
        '
        Me.tope.HeaderText = "TOPE"
        Me.tope.Name = "tope"
        Me.tope.ReadOnly = True
        '
        'FrmSelMetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(461, 471)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelMetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar Metas"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbbuscar As System.Windows.Forms.ComboBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tope As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
