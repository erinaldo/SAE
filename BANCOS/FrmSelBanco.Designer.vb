<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelBanco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelBanco))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmditems = New System.Windows.Forms.Button
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.banco = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta_con = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbaux = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbbucar = New System.Windows.Forms.ComboBox
        Me.ok = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbfila = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(396, 6)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 0
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "seleccionar cuenta  Alt+S")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'gcuenta
        '
        Me.gcuenta.AllowUserToAddRows = False
        Me.gcuenta.AllowUserToDeleteRows = False
        Me.gcuenta.AllowUserToResizeColumns = False
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.codigo, Me.banco, Me.cta, Me.cta_con, Me.desc})
        Me.gcuenta.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.Location = New System.Drawing.Point(7, 61)
        Me.gcuenta.MultiSelect = False
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcuenta.Size = New System.Drawing.Size(864, 343)
        Me.gcuenta.StandardTab = True
        Me.gcuenta.TabIndex = 6
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
        'cta
        '
        Me.cta.Frozen = True
        Me.cta.HeaderText = "NUMERO CTA"
        Me.cta.MinimumWidth = 110
        Me.cta.Name = "cta"
        Me.cta.ReadOnly = True
        Me.cta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cta.Width = 110
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
        'desc
        '
        Me.desc.HeaderText = "BANCO"
        Me.desc.MinimumWidth = 200
        Me.desc.Name = "desc"
        Me.desc.Width = 200
        '
        'lbaux
        '
        Me.lbaux.AutoSize = True
        Me.lbaux.Location = New System.Drawing.Point(618, 29)
        Me.lbaux.Name = "lbaux"
        Me.lbaux.Size = New System.Drawing.Size(39, 13)
        Me.lbaux.TabIndex = 70
        Me.lbaux.Text = "auxiliar"
        Me.lbaux.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbbucar)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(864, 52)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'cbbucar
        '
        Me.cbbucar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbucar.FormattingEnabled = True
        Me.cbbucar.Items.AddRange(New Object() {"NUMERO CTA", "CTA CONTABLE", "CODIGO BANCO"})
        Me.cbbucar.Location = New System.Drawing.Point(185, 17)
        Me.cbbucar.Name = "cbbucar"
        Me.cbbucar.Size = New System.Drawing.Size(165, 21)
        Me.cbbucar.TabIndex = 74
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(525, 16)
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
        Me.Label5.Location = New System.Drawing.Point(17, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "BUSCAR CUENTAS POR"
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(356, 18)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(163, 20)
        Me.txtcuenta.TabIndex = 0
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbaux)
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 408)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(864, 85)
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
        Me.GroupPanel1.TabIndex = 7
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(91, 52)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(20, 13)
        Me.lbfila.TabIndex = 69
        Me.lbfila.Text = "fila"
        Me.lbfila.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(91, 29)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 68
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'FrmSelBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 498)
        Me.Controls.Add(Me.gcuenta)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccione el Banco"
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents lbaux As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta_con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbbucar As System.Windows.Forms.ComboBox
End Class
