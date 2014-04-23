<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentas))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbaux = New System.Windows.Forms.Label
        Me.lbfila = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.cmditems = New System.Windows.Forms.Button
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NIVEL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ok = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.cmbbuscar = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbaux)
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 422)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(544, 85)
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
        Me.GroupPanel1.TabIndex = 1
        '
        'lbaux
        '
        Me.lbaux.AutoSize = True
        Me.lbaux.Location = New System.Drawing.Point(401, 29)
        Me.lbaux.Name = "lbaux"
        Me.lbaux.Size = New System.Drawing.Size(39, 13)
        Me.lbaux.TabIndex = 70
        Me.lbaux.Text = "auxiliar"
        Me.lbaux.Visible = False
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
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(232, 6)
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
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.nombre, Me.nit, Me.NIVEL})
        Me.gcuenta.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.Location = New System.Drawing.Point(6, 73)
        Me.gcuenta.MultiSelect = False
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcuenta.Size = New System.Drawing.Size(544, 343)
        Me.gcuenta.StandardTab = True
        Me.gcuenta.TabIndex = 0
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
        'nombre
        '
        Me.nombre.HeaderText = "CUENTA"
        Me.nombre.MaxInputLength = 300
        Me.nombre.MinimumWidth = 120
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 120
        '
        'nit
        '
        Me.nit.HeaderText = "DESCRIPCIÓN"
        Me.nit.MinimumWidth = 300
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 300
        '
        'NIVEL
        '
        Me.NIVEL.HeaderText = "NIVEL"
        Me.NIVEL.Name = "NIVEL"
        Me.NIVEL.ReadOnly = True
        Me.NIVEL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbbuscar)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(544, 68)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(483, 35)
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
        Me.Label5.Location = New System.Drawing.Point(159, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(235, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "BUSCAR CUENTAS DEL CATALOGO"
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(235, 38)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(242, 20)
        Me.txtcuenta.TabIndex = 0
        '
        'cmbbuscar
        '
        Me.cmbbuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbuscar.FormattingEnabled = True
        Me.cmbbuscar.Items.AddRange(New Object() {"CUENTA", "DESCRIPCION"})
        Me.cmbbuscar.Location = New System.Drawing.Point(109, 39)
        Me.cmbbuscar.Name = "cmbbuscar"
        Me.cmbbuscar.Size = New System.Drawing.Size(115, 21)
        Me.cmbbuscar.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "BUSCAR POR "
        '
        'FrmCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(556, 510)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gcuenta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE SELECCIONAR CUENTAS CONTABLES= Alt+S"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbaux As System.Windows.Forms.Label
    Friend WithEvents cmbbuscar As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
