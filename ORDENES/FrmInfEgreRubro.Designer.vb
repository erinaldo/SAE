<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfEgreRubro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfEgreRubro))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtnomr = New System.Windows.Forms.TextBox
        Me.cmdrb = New System.Windows.Forms.Button
        Me.txtd = New System.Windows.Forms.TextBox
        Me.r3 = New System.Windows.Forms.RadioButton
        Me.r2 = New System.Windows.Forms.RadioButton
        Me.r1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtdi2 = New System.Windows.Forms.TextBox
        Me.txtdi1 = New System.Windows.Forms.TextBox
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.txtpfin = New System.Windows.Forms.TextBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.grubro = New System.Windows.Forms.DataGridView
        Me.rubro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.grubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtnomr)
        Me.GroupBox2.Controls.Add(Me.cmdrb)
        Me.GroupBox2.Controls.Add(Me.txtd)
        Me.GroupBox2.Controls.Add(Me.r3)
        Me.GroupBox2.Controls.Add(Me.r2)
        Me.GroupBox2.Controls.Add(Me.r1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(468, 85)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        '
        'txtnomr
        '
        Me.txtnomr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomr.Enabled = False
        Me.txtnomr.Location = New System.Drawing.Point(236, 29)
        Me.txtnomr.Name = "txtnomr"
        Me.txtnomr.Size = New System.Drawing.Size(224, 20)
        Me.txtnomr.TabIndex = 84
        '
        'cmdrb
        '
        Me.cmdrb.Location = New System.Drawing.Point(112, 54)
        Me.cmdrb.Name = "cmdrb"
        Me.cmdrb.Size = New System.Drawing.Size(142, 23)
        Me.cmdrb.TabIndex = 84
        Me.cmdrb.Text = "Seleccionar"
        Me.cmdrb.UseVisualStyleBackColor = True
        '
        'txtd
        '
        Me.txtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtd.Enabled = False
        Me.txtd.Location = New System.Drawing.Point(113, 29)
        Me.txtd.Name = "txtd"
        Me.txtd.Size = New System.Drawing.Size(117, 20)
        Me.txtd.TabIndex = 83
        '
        'r3
        '
        Me.r3.AutoSize = True
        Me.r3.Location = New System.Drawing.Point(15, 57)
        Me.r3.Name = "r3"
        Me.r3.Size = New System.Drawing.Size(91, 17)
        Me.r3.TabIndex = 82
        Me.r3.Text = "Varios Rubros"
        Me.r3.UseVisualStyleBackColor = True
        '
        'r2
        '
        Me.r2.AutoSize = True
        Me.r2.Location = New System.Drawing.Point(15, 36)
        Me.r2.Name = "r2"
        Me.r2.Size = New System.Drawing.Size(71, 17)
        Me.r2.TabIndex = 81
        Me.r2.Text = "Un Rubro"
        Me.r2.UseVisualStyleBackColor = True
        '
        'r1
        '
        Me.r1.AutoSize = True
        Me.r1.Checked = True
        Me.r1.Location = New System.Drawing.Point(15, 15)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(55, 17)
        Me.r1.TabIndex = 0
        Me.r1.TabStop = True
        Me.r1.Text = "Todos"
        Me.r1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdi2)
        Me.GroupBox4.Controls.Add(Me.txtdi1)
        Me.GroupBox4.Controls.Add(Me.cbfin)
        Me.GroupBox4.Controls.Add(Me.txtpfin)
        Me.GroupBox4.Controls.Add(Me.cbini)
        Me.GroupBox4.Controls.Add(Me.txtpini)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 88)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(469, 55)
        Me.GroupBox4.TabIndex = 82
        Me.GroupBox4.TabStop = False
        '
        'txtdi2
        '
        Me.txtdi2.Location = New System.Drawing.Point(328, 22)
        Me.txtdi2.MaxLength = 2
        Me.txtdi2.Name = "txtdi2"
        Me.txtdi2.Size = New System.Drawing.Size(30, 20)
        Me.txtdi2.TabIndex = 12
        Me.txtdi2.Text = "01"
        '
        'txtdi1
        '
        Me.txtdi1.Location = New System.Drawing.Point(103, 22)
        Me.txtdi1.MaxLength = 2
        Me.txtdi1.Name = "txtdi1"
        Me.txtdi1.Size = New System.Drawing.Size(30, 20)
        Me.txtdi1.TabIndex = 10
        Me.txtdi1.Text = "01"
        '
        'cbfin
        '
        Me.cbfin.DisplayMember = "01"
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbfin.Location = New System.Drawing.Point(363, 21)
        Me.cbfin.MaxLength = 2
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 13
        Me.cbfin.Tag = "1"
        Me.cbfin.ValueMember = "01"
        '
        'txtpfin
        '
        Me.txtpfin.Enabled = False
        Me.txtpfin.Location = New System.Drawing.Point(406, 22)
        Me.txtpfin.Name = "txtpfin"
        Me.txtpfin.Size = New System.Drawing.Size(42, 20)
        Me.txtpfin.TabIndex = 64
        Me.txtpfin.Text = "/0000"
        '
        'cbini
        '
        Me.cbini.DisplayMember = "01"
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(137, 22)
        Me.cbini.MaxLength = 2
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 11
        Me.cbini.Tag = "1"
        Me.cbini.ValueMember = "01"
        '
        'txtpini
        '
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(181, 23)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 62
        Me.txtpini.Text = "/0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(241, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Fecha Final"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Fecha Inicial"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 148)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(468, 85)
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
        Me.GroupPanel1.TabIndex = 81
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(22, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(233, 6)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 12
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(168, 6)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 11
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'grubro
        '
        Me.grubro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grubro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rubro})
        Me.grubro.Location = New System.Drawing.Point(507, 12)
        Me.grubro.Name = "grubro"
        Me.grubro.Size = New System.Drawing.Size(198, 150)
        Me.grubro.TabIndex = 84
        '
        'rubro
        '
        Me.rubro.HeaderText = "rubro"
        Me.rubro.Name = "rubro"
        '
        'FrmInfEgreRubro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(482, 241)
        Me.Controls.Add(Me.grubro)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfEgreRubro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe  Egresos - Rubros"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.grubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdrb As System.Windows.Forms.Button
    Friend WithEvents txtd As System.Windows.Forms.TextBox
    Friend WithEvents r3 As System.Windows.Forms.RadioButton
    Friend WithEvents r2 As System.Windows.Forms.RadioButton
    Friend WithEvents r1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdi2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdi1 As System.Windows.Forms.TextBox
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents txtpfin As System.Windows.Forms.TextBox
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txtnomr As System.Windows.Forms.TextBox
    Friend WithEvents grubro As System.Windows.Forms.DataGridView
    Friend WithEvents rubro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
