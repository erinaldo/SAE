<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPreciosServicios
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
        Me.lbdescricion = New System.Windows.Forms.Label
        Me.Gcomando = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbcodigo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GESTION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gcomando.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbdescricion
        '
        Me.lbdescricion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdescricion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdescricion.Location = New System.Drawing.Point(110, 43)
        Me.lbdescricion.Name = "lbdescricion"
        Me.lbdescricion.Size = New System.Drawing.Size(308, 41)
        Me.lbdescricion.TabIndex = 3
        Me.lbdescricion.Text = "Descripción:"
        '
        'Gcomando
        '
        Me.Gcomando.CanvasColor = System.Drawing.SystemColors.Control
        Me.Gcomando.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Gcomando.Controls.Add(Me.CmdSalir)
        Me.Gcomando.Controls.Add(Me.CmdRegistrarCambios)
        Me.Gcomando.Location = New System.Drawing.Point(4, 301)
        Me.Gcomando.Name = "Gcomando"
        Me.Gcomando.Size = New System.Drawing.Size(436, 85)
        '
        '
        '
        Me.Gcomando.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.Gcomando.Style.BackColorGradientAngle = 90
        Me.Gcomando.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.Gcomando.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gcomando.Style.BorderBottomWidth = 1
        Me.Gcomando.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Gcomando.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gcomando.Style.BorderLeftWidth = 1
        Me.Gcomando.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gcomando.Style.BorderRightWidth = 1
        Me.Gcomando.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.Gcomando.Style.BorderTopWidth = 1
        Me.Gcomando.Style.CornerDiameter = 4
        Me.Gcomando.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Gcomando.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.Gcomando.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Gcomando.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.Gcomando.TabIndex = 93
        '
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(218, 7)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 1
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.gparam
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(140, 7)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 0
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'lbform
        '
        Me.lbform.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbform.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbform.Location = New System.Drawing.Point(5, 8)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(432, 22)
        Me.lbform.TabIndex = 92
        Me.lbform.Text = "LISTAS DE PRECIOS DEL SERVICIO"
        Me.lbform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbdescricion)
        Me.GroupBox1.Controls.Add(Me.lbcodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 93)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'lbcodigo
        '
        Me.lbcodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcodigo.Location = New System.Drawing.Point(110, 16)
        Me.lbcodigo.Name = "lbcodigo"
        Me.lbcodigo.Size = New System.Drawing.Size(308, 23)
        Me.lbcodigo.TabIndex = 2
        Me.lbcodigo.Text = "Codigo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
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
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.nombre, Me.GESTION})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(4, 132)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gitems.Size = New System.Drawing.Size(436, 163)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 90
        '
        'ID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle1
        Me.ID.Frozen = True
        Me.ID.HeaderText = "No."
        Me.ID.MinimumWidth = 50
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 50
        '
        'nombre
        '
        Me.nombre.Frozen = True
        Me.nombre.HeaderText = "NOMBRE DE LA LISTA"
        Me.nombre.MaxInputLength = 300
        Me.nombre.MinimumWidth = 220
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombre.Width = 220
        '
        'GESTION
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.GESTION.DefaultCellStyle = DataGridViewCellStyle2
        Me.GESTION.Frozen = True
        Me.GESTION.HeaderText = "PRECIO"
        Me.GESTION.MinimumWidth = 140
        Me.GESTION.Name = "GESTION"
        Me.GESTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GESTION.Width = 140
        '
        'FrmPreciosServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(444, 390)
        Me.Controls.Add(Me.Gcomando)
        Me.Controls.Add(Me.lbform)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPreciosServicios"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Precios de Servicios"
        Me.Gcomando.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbdescricion As System.Windows.Forms.Label
    Friend WithEvents Gcomando As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbcodigo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GESTION As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
