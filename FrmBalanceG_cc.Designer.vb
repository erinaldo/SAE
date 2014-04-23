<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalanceG_cc
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.txtano = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.frf = New System.Windows.Forms.CheckBox
        Me.frl = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtncc = New System.Windows.Forms.TextBox
        Me.txtcc = New System.Windows.Forms.TextBox
        Me.rb_cc2 = New System.Windows.Forms.RadioButton
        Me.rb_cc1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.fcon = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ch = New System.Windows.Forms.CheckBox
        Me.GroupPanel1.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 15)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Nivel De Cuentas Para El Balance"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 276)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(516, 85)
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
        Me.GroupPanel1.TabIndex = 4
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(256, 6)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(65, 66)
        Me.cmdsalir.TabIndex = 3
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(187, 6)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(65, 66)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&G"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Generar Balance Atl + G")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'nivel
        '
        Me.nivel.Location = New System.Drawing.Point(271, 19)
        Me.nivel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nivel.Name = "nivel"
        Me.nivel.Size = New System.Drawing.Size(29, 20)
        Me.nivel.TabIndex = 4
        Me.nivel.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.nivel)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 135)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 51)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbper)
        Me.GroupBox2.Controls.Add(Me.txtano)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 49)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cbper
        '
        Me.cbper.DisplayMember = "01"
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(238, 15)
        Me.cbper.MaxLength = 2
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(43, 21)
        Me.cbper.TabIndex = 2
        Me.cbper.ValueMember = "01"
        '
        'txtano
        '
        Me.txtano.Location = New System.Drawing.Point(283, 16)
        Me.txtano.Name = "txtano"
        Me.txtano.ReadOnly = True
        Me.txtano.Size = New System.Drawing.Size(40, 20)
        Me.txtano.TabIndex = 45
        Me.txtano.Text = "/0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Periodo a generar en el balance"
        '
        'frf
        '
        Me.frf.AutoSize = True
        Me.frf.Location = New System.Drawing.Point(162, 34)
        Me.frf.Name = "frf"
        Me.frf.Size = New System.Drawing.Size(92, 17)
        Me.frf.TabIndex = 58
        Me.frf.Text = "Revisor Fiscal"
        Me.frf.UseVisualStyleBackColor = True
        '
        'frl
        '
        Me.frl.AutoSize = True
        Me.frl.Checked = True
        Me.frl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.frl.Location = New System.Drawing.Point(323, 34)
        Me.frl.Name = "frl"
        Me.frl.Size = New System.Drawing.Size(125, 17)
        Me.frl.TabIndex = 57
        Me.frl.Text = "Representante Legal"
        Me.frl.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Firmas Del Balance"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 258)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ch)
        Me.GroupBox5.Controls.Add(Me.txtncc)
        Me.GroupBox5.Controls.Add(Me.txtcc)
        Me.GroupBox5.Controls.Add(Me.rb_cc2)
        Me.GroupBox5.Controls.Add(Me.rb_cc1)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(477, 70)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'txtncc
        '
        Me.txtncc.Enabled = False
        Me.txtncc.Location = New System.Drawing.Point(219, 42)
        Me.txtncc.Name = "txtncc"
        Me.txtncc.Size = New System.Drawing.Size(250, 20)
        Me.txtncc.TabIndex = 52
        '
        'txtcc
        '
        Me.txtcc.Enabled = False
        Me.txtcc.Location = New System.Drawing.Point(162, 42)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(56, 20)
        Me.txtcc.TabIndex = 51
        '
        'rb_cc2
        '
        Me.rb_cc2.AutoSize = True
        Me.rb_cc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_cc2.Location = New System.Drawing.Point(20, 44)
        Me.rb_cc2.Name = "rb_cc2"
        Me.rb_cc2.Size = New System.Drawing.Size(139, 17)
        Me.rb_cc2.TabIndex = 50
        Me.rb_cc2.TabStop = True
        Me.rb_cc2.Text = "Por Centro de Costo"
        Me.rb_cc2.UseVisualStyleBackColor = True
        '
        'rb_cc1
        '
        Me.rb_cc1.AutoSize = True
        Me.rb_cc1.Checked = True
        Me.rb_cc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_cc1.Location = New System.Drawing.Point(20, 17)
        Me.rb_cc1.Name = "rb_cc1"
        Me.rb_cc1.Size = New System.Drawing.Size(60, 17)
        Me.rb_cc1.TabIndex = 49
        Me.rb_cc1.TabStop = True
        Me.rb_cc1.Text = "Todos"
        Me.rb_cc1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.frf)
        Me.GroupBox4.Controls.Add(Me.frl)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.fcon)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 188)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 62)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'fcon
        '
        Me.fcon.AutoSize = True
        Me.fcon.Checked = True
        Me.fcon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.fcon.Location = New System.Drawing.Point(20, 34)
        Me.fcon.Name = "fcon"
        Me.fcon.Size = New System.Drawing.Size(69, 17)
        Me.fcon.TabIndex = 55
        Me.fcon.Text = "Contador"
        Me.fcon.UseVisualStyleBackColor = True
        '
        'ch
        '
        Me.ch.AutoSize = True
        Me.ch.Checked = True
        Me.ch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch.Enabled = False
        Me.ch.Location = New System.Drawing.Point(219, 17)
        Me.ch.Name = "ch"
        Me.ch.Size = New System.Drawing.Size(147, 17)
        Me.ch.TabIndex = 53
        Me.ch.Text = "Traer valoeres agrupados"
        Me.ch.UseVisualStyleBackColor = True
        '
        'FrmBalanceG_cc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(534, 370)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBalanceG_cc"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Balance General por Centro de Costo"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents txtano As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents frf As System.Windows.Forms.CheckBox
    Friend WithEvents frl As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents fcon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_cc2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_cc1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtncc As System.Windows.Forms.TextBox
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents ch As System.Windows.Forms.CheckBox
End Class
