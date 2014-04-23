<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEliminarComp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEliminarComp))
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtlogin = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.txtcompania = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LbPass = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Lbesperar = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmditems = New System.Windows.Forms.Button
        Me.lbfila = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.periodo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "COMPAÑIA EN USO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtlogin)
        Me.GroupBox1.Controls.Add(Me.txtperiodo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnit)
        Me.GroupBox1.Controls.Add(Me.txtcompania)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 90)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        '
        'txtlogin
        '
        Me.txtlogin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtlogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlogin.Location = New System.Drawing.Point(138, 35)
        Me.txtlogin.Name = "txtlogin"
        Me.txtlogin.ReadOnly = True
        Me.txtlogin.ShortcutsEnabled = False
        Me.txtlogin.Size = New System.Drawing.Size(59, 20)
        Me.txtlogin.TabIndex = 2
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtperiodo.Location = New System.Drawing.Point(443, 61)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.ShortcutsEnabled = False
        Me.txtperiodo.Size = New System.Drawing.Size(88, 20)
        Me.txtperiodo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(351, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "PERIODO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "NIT"
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnit.Location = New System.Drawing.Point(138, 61)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ReadOnly = True
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(172, 20)
        Me.txtnit.TabIndex = 4
        '
        'txtcompania
        '
        Me.txtcompania.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcompania.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcompania.Location = New System.Drawing.Point(203, 35)
        Me.txtcompania.Name = "txtcompania"
        Me.txtcompania.ReadOnly = True
        Me.txtcompania.ShortcutsEnabled = False
        Me.txtcompania.Size = New System.Drawing.Size(328, 20)
        Me.txtcompania.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "COMPAÑIA"
        '
        'LbPass
        '
        Me.LbPass.AutoSize = True
        Me.LbPass.Location = New System.Drawing.Point(458, 34)
        Me.LbPass.Name = "LbPass"
        Me.LbPass.Size = New System.Drawing.Size(29, 13)
        Me.LbPass.TabIndex = 73
        Me.LbPass.Text = "pass"
        Me.LbPass.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Lbesperar)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.gitems)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(585, 241)
        Me.GroupBox5.TabIndex = 91
        Me.GroupBox5.TabStop = False
        '
        'Lbesperar
        '
        Me.Lbesperar.AutoSize = True
        Me.Lbesperar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbesperar.ForeColor = System.Drawing.Color.Maroon
        Me.Lbesperar.Location = New System.Drawing.Point(160, 169)
        Me.Lbesperar.Name = "Lbesperar"
        Me.Lbesperar.Size = New System.Drawing.Size(232, 16)
        Me.Lbesperar.TabIndex = 92
        Me.Lbesperar.Text = "....... ESPERE UN MOMENTO ....."
        Me.Lbesperar.Visible = False
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.desc, Me.codigo, Me.grupo, Me.num, Me.periodo})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(11, 108)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gitems.Size = New System.Drawing.Size(563, 123)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 0
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(293, 8)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 2
        Me.cmdcancelar.Text = "&C"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar Operación Alt + C")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(219, 8)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 1
        Me.cmditems.Text = "&A"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "Abrir Compañia Alt + A")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(99, 34)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(20, 13)
        Me.lbfila.TabIndex = 72
        Me.lbfila.Text = "fila"
        Me.lbfila.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(99, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "formulario"
        Me.Label1.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(122, 25)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(0, 13)
        Me.lbform.TabIndex = 68
        Me.lbform.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LbPass)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 251)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(585, 85)
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
        Me.GroupPanel1.TabIndex = 90
        '
        'desc
        '
        Me.desc.FillWeight = 50.0!
        Me.desc.Frozen = True
        Me.desc.HeaderText = "USUARIO"
        Me.desc.MinimumWidth = 100
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "DESCRIPCIÓN"
        Me.codigo.MinimumWidth = 270
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.codigo.Width = 270
        '
        'grupo
        '
        Me.grupo.FillWeight = 50.0!
        Me.grupo.Frozen = True
        Me.grupo.HeaderText = "NIT"
        Me.grupo.MinimumWidth = 130
        Me.grupo.Name = "grupo"
        Me.grupo.ReadOnly = True
        Me.grupo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grupo.Width = 130
        '
        'num
        '
        Me.num.HeaderText = "NUM"
        Me.num.Name = "num"
        Me.num.Visible = False
        '
        'periodo
        '
        Me.periodo.HeaderText = "PERIODO"
        Me.periodo.Name = "periodo"
        Me.periodo.Visible = False
        '
        'FrmEliminarComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(598, 343)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEliminarComp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Eliminar Compañia"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtlogin As System.Windows.Forms.TextBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents txtcompania As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LbPass As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Lbesperar As System.Windows.Forms.Label
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents periodo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
