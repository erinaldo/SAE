<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFPEgresos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFPEgresos))
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta_con = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gcuenta
        '
        Me.gcuenta.AllowUserToDeleteRows = False
        Me.gcuenta.AllowUserToResizeColumns = False
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.codigo, Me.cta, Me.banco, Me.cta_con, Me.monto, Me.cheque})
        Me.gcuenta.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.Location = New System.Drawing.Point(5, 6)
        Me.gcuenta.MultiSelect = False
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcuenta.Size = New System.Drawing.Size(951, 189)
        Me.gcuenta.StandardTab = True
        Me.gcuenta.TabIndex = 7
        '
        'buscar
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.buscar.DefaultCellStyle = DataGridViewCellStyle1
        Me.buscar.Frozen = True
        Me.buscar.HeaderText = "BUSCAR"
        Me.buscar.MaxInputLength = 15
        Me.buscar.MinimumWidth = 10
        Me.buscar.Name = "buscar"
        Me.buscar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.buscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.buscar.ToolTipText = "buscar "
        Me.buscar.Visible = False
        Me.buscar.Width = 10
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MaxInputLength = 300
        Me.codigo.MinimumWidth = 120
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 120
        '
        'cta
        '
        Me.cta.Frozen = True
        Me.cta.HeaderText = "NUMERO CTA"
        Me.cta.MinimumWidth = 130
        Me.cta.Name = "cta"
        Me.cta.Width = 130
        '
        'banco
        '
        Me.banco.Frozen = True
        Me.banco.HeaderText = "DESCRIPCIÓN"
        Me.banco.MinimumWidth = 290
        Me.banco.Name = "banco"
        Me.banco.ReadOnly = True
        Me.banco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.banco.Width = 290
        '
        'cta_con
        '
        Me.cta_con.HeaderText = "CTA CONTABLE"
        Me.cta_con.MinimumWidth = 120
        Me.cta_con.Name = "cta_con"
        Me.cta_con.ReadOnly = True
        Me.cta_con.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cta_con.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cta_con.Width = 120
        '
        'monto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.monto.DefaultCellStyle = DataGridViewCellStyle2
        Me.monto.HeaderText = "MONTO ($)"
        Me.monto.MinimumWidth = 140
        Me.monto.Name = "monto"
        Me.monto.Width = 140
        '
        'cheque
        '
        Me.cheque.HeaderText = "TRANS / CHEQUE"
        Me.cheque.MinimumWidth = 130
        Me.cheque.Name = "cheque"
        Me.cheque.Width = 130
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 228)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(951, 85)
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
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(476, 9)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 1
        Me.CmdSalir.Text = "&S"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.add
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(398, 8)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 0
        Me.CmdRegistrarCambios.Text = "&A"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txttotal.Location = New System.Drawing.Point(615, 200)
        Me.txttotal.MaxLength = 200
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(198, 20)
        Me.txttotal.TabIndex = 97
        Me.txttotal.Text = "0,00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(240, 20)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "VALOR NETO A PAGAR ......"
        '
        'FrmFPEgresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(962, 318)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gcuenta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmFPEgresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "    Varias Cuentas de Pagos para los Egresos"
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
