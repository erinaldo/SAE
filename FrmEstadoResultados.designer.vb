<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEstadoResultados
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.pdf = New System.Windows.Forms.Button
        Me.cmdGrafica = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.n2 = New System.Windows.Forms.RadioButton
        Me.n1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.frf = New System.Windows.Forms.CheckBox
        Me.frl = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.fcon = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChCierre = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtpfin = New System.Windows.Forms.TextBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.pdf)
        Me.GroupPanel1.Controls.Add(Me.cmdGrafica)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 284)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(494, 85)
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
        'pdf
        '
        Me.pdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pdf.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.pdf.Location = New System.Drawing.Point(175, 13)
        Me.pdf.Name = "pdf"
        Me.pdf.Size = New System.Drawing.Size(60, 57)
        Me.pdf.TabIndex = 76
        Me.pdf.UseVisualStyleBackColor = False
        '
        'cmdGrafica
        '
        Me.cmdGrafica.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdGrafica.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdGrafica.Image = Global.SAE.My.Resources.Resources.gbarra
        Me.cmdGrafica.Location = New System.Drawing.Point(80, 13)
        Me.cmdGrafica.Name = "cmdGrafica"
        Me.cmdGrafica.Size = New System.Drawing.Size(59, 57)
        Me.cmdGrafica.TabIndex = 1
        Me.cmdGrafica.Text = "&G"
        Me.cmdGrafica.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdGrafica, "Generar Gráfica Alt + G")
        Me.cmdGrafica.UseVisualStyleBackColor = False
        Me.cmdGrafica.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(243, 13)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 2
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(183, 13)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&P"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Generar Reporte En Pantalla Alt + P")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.n2)
        Me.GroupBox2.Controls.Add(Me.n1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 49)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(216, 43)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(255, 20)
        Me.txtnombre.TabIndex = 3
        Me.txtnombre.Visible = False
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(108, 43)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(102, 20)
        Me.txtnit.TabIndex = 2
        Me.txtnit.Visible = False
        '
        'n2
        '
        Me.n2.AutoSize = True
        Me.n2.Enabled = False
        Me.n2.Location = New System.Drawing.Point(25, 44)
        Me.n2.Name = "n2"
        Me.n2.Size = New System.Drawing.Size(77, 17)
        Me.n2.TabIndex = 1
        Me.n2.Text = "Por N. I. T."
        Me.n2.UseVisualStyleBackColor = True
        Me.n2.Visible = False
        '
        'n1
        '
        Me.n1.AutoSize = True
        Me.n1.Checked = True
        Me.n1.Location = New System.Drawing.Point(25, 19)
        Me.n1.Name = "n1"
        Me.n1.Size = New System.Drawing.Size(111, 17)
        Me.n1.TabIndex = 0
        Me.n1.TabStop = True
        Me.n1.Text = "Todos Los N. I. T."
        Me.n1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(494, 259)
        Me.GroupBox4.TabIndex = 73
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.frf)
        Me.GroupBox3.Controls.Add(Me.frl)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.fcon)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 187)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 62)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'frf
        '
        Me.frf.AutoSize = True
        Me.frf.Location = New System.Drawing.Point(162, 34)
        Me.frf.Name = "frf"
        Me.frf.Size = New System.Drawing.Size(92, 17)
        Me.frf.TabIndex = 1
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
        Me.frl.TabIndex = 2
        Me.frl.Text = "Representante Legal"
        Me.frl.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 15)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Firmas Del Estado De Resultados"
        '
        'fcon
        '
        Me.fcon.AutoSize = True
        Me.fcon.Checked = True
        Me.fcon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.fcon.Location = New System.Drawing.Point(20, 34)
        Me.fcon.Name = "fcon"
        Me.fcon.Size = New System.Drawing.Size(69, 17)
        Me.fcon.TabIndex = 0
        Me.fcon.Text = "Contador"
        Me.fcon.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.nivel)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 137)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(477, 51)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(314, 15)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Nivel De Cuentas Para El Estado De Resultados"
        '
        'nivel
        '
        Me.nivel.Location = New System.Drawing.Point(343, 19)
        Me.nivel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nivel.Name = "nivel"
        Me.nivel.Size = New System.Drawing.Size(29, 20)
        Me.nivel.TabIndex = 0
        Me.nivel.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ChCierre)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbfin)
        Me.GroupBox1.Controls.Add(Me.cbini)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtpfin)
        Me.GroupBox1.Controls.Add(Me.txtpini)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 75)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ChCierre
        '
        Me.ChCierre.AutoSize = True
        Me.ChCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCierre.Location = New System.Drawing.Point(22, 52)
        Me.ChCierre.Name = "ChCierre"
        Me.ChCierre.Size = New System.Drawing.Size(151, 17)
        Me.ChCierre.TabIndex = 49
        Me.ChCierre.Text = "Antes De Cierre Anual"
        Me.ChCierre.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 16)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Rango  De Periodos"
        '
        'cbfin
        '
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Location = New System.Drawing.Point(368, 19)
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 3
        '
        'cbini
        '
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(224, 20)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(326, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Final"
        '
        'txtpfin
        '
        Me.txtpfin.Enabled = False
        Me.txtpfin.Location = New System.Drawing.Point(411, 20)
        Me.txtpfin.Name = "txtpfin"
        Me.txtpfin.Size = New System.Drawing.Size(42, 20)
        Me.txtpfin.TabIndex = 48
        Me.txtpfin.Text = "/0000"
        '
        'txtpini
        '
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(269, 20)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 46
        Me.txtpini.Text = "/0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(175, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Inicial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(123, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 15)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "ESTADO DE PERDIDAS Y GANANCIAS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Hasta el Periodo"
        '
        'FrmEstadoResultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(516, 375)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEstadoResultados"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Estados De Resultados"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents n2 As System.Windows.Forms.RadioButton
    Friend WithEvents n1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpfin As System.Windows.Forms.TextBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents frf As System.Windows.Forms.CheckBox
    Friend WithEvents frl As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fcon As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdGrafica As System.Windows.Forms.Button
    Friend WithEvents ChCierre As System.Windows.Forms.CheckBox
    Friend WithEvents pdf As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
