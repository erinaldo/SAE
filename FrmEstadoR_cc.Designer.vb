<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadoR_cc
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtncc = New System.Windows.Forms.TextBox
        Me.txtcc = New System.Windows.Forms.TextBox
        Me.rb_cc2 = New System.Windows.Forms.RadioButton
        Me.rb_cc1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.frf = New System.Windows.Forms.CheckBox
        Me.frl = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.fcon = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.lbper = New System.Windows.Forms.Label
        Me.rb_per2 = New System.Windows.Forms.RadioButton
        Me.rb_per1 = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.ch = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 279)
        Me.GroupBox1.TabIndex = 77
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
        Me.txtncc.Location = New System.Drawing.Point(225, 42)
        Me.txtncc.Name = "txtncc"
        Me.txtncc.Size = New System.Drawing.Size(249, 20)
        Me.txtncc.TabIndex = 52
        '
        'txtcc
        '
        Me.txtcc.Enabled = False
        Me.txtcc.Location = New System.Drawing.Point(157, 42)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(68, 20)
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
        Me.GroupBox4.Location = New System.Drawing.Point(18, 209)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 62)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.nivel)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 51)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbfin)
        Me.GroupBox2.Controls.Add(Me.cbini)
        Me.GroupBox2.Controls.Add(Me.lbper)
        Me.GroupBox2.Controls.Add(Me.rb_per2)
        Me.GroupBox2.Controls.Add(Me.rb_per1)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 74)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cbfin
        '
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Location = New System.Drawing.Point(271, 21)
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 55
        Me.cbfin.Visible = False
        '
        'cbini
        '
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(227, 21)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 54
        Me.cbini.Visible = False
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(134, 21)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(55, 13)
        Me.lbper.TabIndex = 53
        Me.lbper.Text = "00/0000"
        '
        'rb_per2
        '
        Me.rb_per2.AutoSize = True
        Me.rb_per2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_per2.Location = New System.Drawing.Point(20, 46)
        Me.rb_per2.Name = "rb_per2"
        Me.rb_per2.Size = New System.Drawing.Size(87, 17)
        Me.rb_per2.TabIndex = 52
        Me.rb_per2.TabStop = True
        Me.rb_per2.Text = "Acomulado"
        Me.rb_per2.UseVisualStyleBackColor = True
        '
        'rb_per1
        '
        Me.rb_per1.AutoSize = True
        Me.rb_per1.Checked = True
        Me.rb_per1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_per1.Location = New System.Drawing.Point(20, 19)
        Me.rb_per1.Name = "rb_per1"
        Me.rb_per1.Size = New System.Drawing.Size(108, 17)
        Me.rb_per1.TabIndex = 51
        Me.rb_per1.TabStop = True
        Me.rb_per1.Text = "Periodo Actual"
        Me.rb_per1.UseVisualStyleBackColor = True
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
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 285)
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
        Me.GroupPanel1.TabIndex = 76
        '
        'ch
        '
        Me.ch.AutoSize = True
        Me.ch.Checked = True
        Me.ch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ch.Enabled = False
        Me.ch.Location = New System.Drawing.Point(225, 17)
        Me.ch.Name = "ch"
        Me.ch.Size = New System.Drawing.Size(147, 17)
        Me.ch.TabIndex = 54
        Me.ch.Text = "Traer valoeres agrupados"
        Me.ch.UseVisualStyleBackColor = True
        '
        'FrmEstadoR_cc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(532, 382)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstadoR_cc"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Estado de Resultados por Centro de Costo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtncc As System.Windows.Forms.TextBox
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents rb_cc2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_cc1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents frf As System.Windows.Forms.CheckBox
    Friend WithEvents frl As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fcon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents rb_per2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_per1 As System.Windows.Forms.RadioButton
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents ch As System.Windows.Forms.CheckBox
End Class
