<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAproD
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
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.txtaño = New System.Windows.Forms.TextBox
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Descripcion
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 500
        Me.Descripcion.MinimumWidth = 250
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 250
        '
        'Debitos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cuenta
        '
        Me.cuenta.FillWeight = 80.0!
        Me.cuenta.HeaderText = "Cuenta"
        Me.cuenta.MaxInputLength = 20
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        Me.cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cuenta.Width = 80
        '
        'base
        '
        Me.base.HeaderText = "base"
        Me.base.Name = "base"
        Me.base.ReadOnly = True
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.cuenta, Me.base})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(14, 208)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(653, 263)
        Me.grilla.TabIndex = 117
        Me.grilla.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 13)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "APROBAR DOCUMENTOS DE FACTURACION"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mibarra)
        Me.GroupBox1.Controls.Add(Me.txtaño)
        Me.GroupBox1.Controls.Add(Me.cbper)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 74)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(110, 51)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 115
        Me.mibarra.Visible = False
        '
        'txtaño
        '
        Me.txtaño.Enabled = False
        Me.txtaño.Location = New System.Drawing.Point(250, 32)
        Me.txtaño.Name = "txtaño"
        Me.txtaño.Size = New System.Drawing.Size(47, 20)
        Me.txtaño.TabIndex = 2
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(207, 31)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(36, 21)
        Me.cbper.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(150, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Periodo"
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(223, 3)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 70)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Atras Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.Color.White
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.shop
        Me.cmdpantalla.Location = New System.Drawing.Point(149, 3)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(70, 70)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Aprobar factura ")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 107)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(462, 85)
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
        Me.GroupPanel1.TabIndex = 115
        '
        'FrmAproD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(485, 197)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAproD"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aprobar Documentos"
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents txtaño As System.Windows.Forms.TextBox
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
