<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModCausaPresu
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModCausaPresu))
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.objeto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctagas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctapp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.guardar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ctapp2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctagas2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.td = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.salir = New System.Windows.Forms.Button
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbitem = New System.Windows.Forms.Label
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.ref, Me.objeto, Me.desc, Me.nit, Me.fecha, Me.monto, Me.ctagas, Me.ctapp, Me.guardar, Me.ctapp2, Me.ctagas2, Me.nd, Me.td})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(4, 46)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.Size = New System.Drawing.Size(1080, 342)
        Me.gitems.TabIndex = 70
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "DOCUMENTO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 90
        '
        'ref
        '
        Me.ref.Frozen = True
        Me.ref.HeaderText = "CONTRATO"
        Me.ref.Name = "ref"
        Me.ref.ReadOnly = True
        '
        'objeto
        '
        Me.objeto.Frozen = True
        Me.objeto.HeaderText = "OBJETO DEL CONTRATO"
        Me.objeto.MinimumWidth = 170
        Me.objeto.Name = "objeto"
        Me.objeto.ReadOnly = True
        Me.objeto.Width = 170
        '
        'desc
        '
        Me.desc.Frozen = True
        Me.desc.HeaderText = "NOMBRE / RAZON SOCIAL"
        Me.desc.MinimumWidth = 170
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Width = 170
        '
        'nit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.nit.DefaultCellStyle = DataGridViewCellStyle1
        Me.nit.Frozen = True
        Me.nit.HeaderText = "NIT / CC"
        Me.nit.MinimumWidth = 80
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nit.Width = 80
        '
        'fecha
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.fecha.Frozen = True
        Me.fecha.HeaderText = "FECHA"
        Me.fecha.MinimumWidth = 80
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha.Width = 80
        '
        'monto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.monto.DefaultCellStyle = DataGridViewCellStyle3
        Me.monto.Frozen = True
        Me.monto.HeaderText = "MONTO"
        Me.monto.MinimumWidth = 100
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ctagas
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.ctagas.DefaultCellStyle = DataGridViewCellStyle4
        Me.ctagas.Frozen = True
        Me.ctagas.HeaderText = "CTA GASTO/COSTO"
        Me.ctagas.MinimumWidth = 100
        Me.ctagas.Name = "ctagas"
        '
        'ctapp
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.ctapp.DefaultCellStyle = DataGridViewCellStyle5
        Me.ctapp.Frozen = True
        Me.ctapp.HeaderText = "CTA X PAGAR"
        Me.ctapp.MinimumWidth = 100
        Me.ctapp.Name = "ctapp"
        '
        'guardar
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.NullValue = "Guardar"
        Me.guardar.DefaultCellStyle = DataGridViewCellStyle6
        Me.guardar.Frozen = True
        Me.guardar.HeaderText = "GUARDAR"
        Me.guardar.MinimumWidth = 70
        Me.guardar.Name = "guardar"
        Me.guardar.Text = "Guardar"
        Me.guardar.Width = 70
        '
        'ctapp2
        '
        Me.ctapp2.HeaderText = "ctapp2"
        Me.ctapp2.Name = "ctapp2"
        Me.ctapp2.Visible = False
        '
        'ctagas2
        '
        Me.ctagas2.HeaderText = "gasto"
        Me.ctagas2.Name = "ctagas2"
        Me.ctagas2.Visible = False
        '
        'nd
        '
        Me.nd.HeaderText = "num"
        Me.nd.Name = "nd"
        Me.nd.Visible = False
        '
        'td
        '
        Me.td.HeaderText = "tipo"
        Me.td.Name = "td"
        Me.td.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.salir)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 395)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1078, 78)
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
        'salir
        '
        Me.salir.BackColor = System.Drawing.Color.White
        Me.salir.Image = Global.SAE.My.Resources.Resources.atras
        Me.salir.Location = New System.Drawing.Point(502, 2)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(66, 68)
        Me.salir.TabIndex = 15
        Me.salir.UseVisualStyleBackColor = False
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(336, 12)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(71, 21)
        Me.cbper.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(318, 15)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "BUSCAR CUENTAS CAUSADAS EN EL PERIODO "
        '
        'lbitem
        '
        Me.lbitem.AutoSize = True
        Me.lbitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitem.ForeColor = System.Drawing.Color.DarkRed
        Me.lbitem.Location = New System.Drawing.Point(413, 13)
        Me.lbitem.Name = "lbitem"
        Me.lbitem.Size = New System.Drawing.Size(221, 20)
        Me.lbitem.TabIndex = 76
        Me.lbitem.Text = "No hay Items para mostrar"
        '
        'FrmModCausaPresu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1088, 485)
        Me.Controls.Add(Me.lbitem)
        Me.Controls.Add(Me.cbper)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gitems)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmModCausaPresu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " SAE Modificar Causaciones Presupuestales"
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbitem As System.Windows.Forms.Label
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents objeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctagas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctapp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents guardar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ctapp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctagas2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents td As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
