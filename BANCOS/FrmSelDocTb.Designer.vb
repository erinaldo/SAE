<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelDocTb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelDocTb))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmditems = New System.Windows.Forms.Button
        Me.ok = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.lbfila = New System.Windows.Forms.Label
        Me.lbaux = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbform = New System.Windows.Forms.Label
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.lbdoc2 = New System.Windows.Forms.Label
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.origen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.destino = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(457, 17)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(45, 23)
        Me.ok.TabIndex = 1
        Me.ok.Text = "Ok"
        Me.ok.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbdoc2)
        Me.GroupBox3.Controls.Add(Me.lbdoc)
        Me.GroupBox3.Controls.Add(Me.lbper)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(5, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(864, 80)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(17, 50)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(25, 15)
        Me.lbdoc.TabIndex = 76
        Me.lbdoc.Text = "XX"
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(591, 22)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(59, 15)
        Me.lbper.TabIndex = 75
        Me.lbper.Text = "01/2013"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(512, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "PERIODO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(251, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "BUSCAR NUMERO DE DOCUMENTOS"
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(288, 19)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(163, 20)
        Me.txtcuenta.TabIndex = 0
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
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbaux)
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 400)
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
        Me.GroupPanel1.TabIndex = 10
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
        'gcuenta
        '
        Me.gcuenta.AllowUserToAddRows = False
        Me.gcuenta.AllowUserToDeleteRows = False
        Me.gcuenta.AllowUserToResizeColumns = False
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.doc, Me.fecha, Me.origen, Me.destino, Me.monto})
        Me.gcuenta.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.Location = New System.Drawing.Point(5, 92)
        Me.gcuenta.MultiSelect = False
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gcuenta.Size = New System.Drawing.Size(864, 304)
        Me.gcuenta.StandardTab = True
        Me.gcuenta.TabIndex = 9
        '
        'lbdoc2
        '
        Me.lbdoc2.AutoSize = True
        Me.lbdoc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc2.Location = New System.Drawing.Point(83, 50)
        Me.lbdoc2.Name = "lbdoc2"
        Me.lbdoc2.Size = New System.Drawing.Size(251, 15)
        Me.lbdoc2.TabIndex = 77
        Me.lbdoc2.Text = "BUSCAR NUMERO DE DOCUMENTOS"
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
        'doc
        '
        Me.doc.Frozen = True
        Me.doc.HeaderText = "DOCUMENTO"
        Me.doc.MaxInputLength = 300
        Me.doc.MinimumWidth = 90
        Me.doc.Name = "doc"
        Me.doc.ReadOnly = True
        Me.doc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.doc.Width = 90
        '
        'fecha
        '
        Me.fecha.HeaderText = "FECHA"
        Me.fecha.MinimumWidth = 80
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha.Width = 80
        '
        'origen
        '
        Me.origen.HeaderText = "CUENTA ORIGEN"
        Me.origen.MinimumWidth = 270
        Me.origen.Name = "origen"
        Me.origen.ReadOnly = True
        Me.origen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.origen.Width = 270
        '
        'destino
        '
        Me.destino.HeaderText = "CUENTA DESTINO"
        Me.destino.MinimumWidth = 270
        Me.destino.Name = "destino"
        Me.destino.ReadOnly = True
        Me.destino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.destino.Width = 270
        '
        'monto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.monto.DefaultCellStyle = DataGridViewCellStyle2
        Me.monto.HeaderText = "MONTO $"
        Me.monto.MinimumWidth = 135
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Width = 135
        '
        'FrmSelDocTb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(877, 487)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gcuenta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmSelDocTb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " SAE Seleccionar Documentos"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents lbaux As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents lbdoc2 As System.Windows.Forms.Label
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents destino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
