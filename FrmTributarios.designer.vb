<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTributarios
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbnum = New System.Windows.Forms.Label
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdcertificado = New System.Windows.Forms.Button
        Me.ri2 = New System.Windows.Forms.RadioButton
        Me.ri1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.txtperf = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.n2 = New System.Windows.Forms.RadioButton
        Me.n1 = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbtipo = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.Button1)
        Me.GroupPanel1.Controls.Add(Me.lbnum)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 249)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(493, 85)
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
        Me.GroupPanel1.TabIndex = 74
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(27, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.Button1.Location = New System.Drawing.Point(177, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 67)
        Me.Button1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.Button1, "Visualizar Informe")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Location = New System.Drawing.Point(369, 28)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(42, 13)
        Me.lbnum.TabIndex = 4
        Me.lbnum.Text = "numero"
        Me.lbnum.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(245, 7)
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
        Me.cmdpantalla.Location = New System.Drawing.Point(433, 19)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(39, 45)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&G"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Generar Informe Atl + G")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        Me.cmdpantalla.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 216)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdcertificado)
        Me.GroupBox4.Controls.Add(Me.ri2)
        Me.GroupBox4.Controls.Add(Me.ri1)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 67)
        Me.GroupBox4.TabIndex = 66
        Me.GroupBox4.TabStop = False
        '
        'cmdcertificado
        '
        Me.cmdcertificado.Location = New System.Drawing.Point(152, 14)
        Me.cmdcertificado.Name = "cmdcertificado"
        Me.cmdcertificado.Size = New System.Drawing.Size(123, 23)
        Me.cmdcertificado.TabIndex = 2
        Me.cmdcertificado.Text = "Certificado Retención"
        Me.cmdcertificado.UseVisualStyleBackColor = True
        Me.cmdcertificado.Visible = False
        '
        'ri2
        '
        Me.ri2.AutoSize = True
        Me.ri2.Location = New System.Drawing.Point(22, 39)
        Me.ri2.Name = "ri2"
        Me.ri2.Size = New System.Drawing.Size(110, 17)
        Me.ri2.TabIndex = 1
        Me.ri2.Text = "Informe Resumido"
        Me.ri2.UseVisualStyleBackColor = True
        '
        'ri1
        '
        Me.ri1.AutoSize = True
        Me.ri1.Checked = True
        Me.ri1.Location = New System.Drawing.Point(22, 14)
        Me.ri1.Name = "ri1"
        Me.ri1.Size = New System.Drawing.Size(108, 17)
        Me.ri1.TabIndex = 0
        Me.ri1.TabStop = True
        Me.ri1.Text = "Informe Detallado"
        Me.ri1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbfin)
        Me.GroupBox2.Controls.Add(Me.txtperf)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbini)
        Me.GroupBox2.Controls.Add(Me.txtpini)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 55)
        Me.GroupBox2.TabIndex = 63
        Me.GroupBox2.TabStop = False
        '
        'cbfin
        '
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Location = New System.Drawing.Point(334, 19)
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbfin, "periodo final")
        '
        'txtperf
        '
        Me.txtperf.Enabled = False
        Me.txtperf.Location = New System.Drawing.Point(379, 20)
        Me.txtperf.Name = "txtperf"
        Me.txtperf.Size = New System.Drawing.Size(42, 20)
        Me.txtperf.TabIndex = 3
        Me.txtperf.Text = "/0000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 16)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Periodo Inicial"
        '
        'cbini
        '
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(125, 20)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cbini, "periodo inical")
        '
        'txtpini
        '
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(170, 20)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 1
        Me.txtpini.Text = "/0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(227, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Periodo Final"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtnombre)
        Me.GroupBox3.Controls.Add(Me.txtnit)
        Me.GroupBox3.Controls.Add(Me.n2)
        Me.GroupBox3.Controls.Add(Me.n1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 140)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 67)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(213, 38)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(255, 20)
        Me.txtnombre.TabIndex = 3
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(105, 38)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(102, 20)
        Me.txtnit.TabIndex = 2
        '
        'n2
        '
        Me.n2.AutoSize = True
        Me.n2.Location = New System.Drawing.Point(22, 39)
        Me.n2.Name = "n2"
        Me.n2.Size = New System.Drawing.Size(77, 17)
        Me.n2.TabIndex = 1
        Me.n2.Text = "Por N. I. T."
        Me.n2.UseVisualStyleBackColor = True
        '
        'n1
        '
        Me.n1.AutoSize = True
        Me.n1.Checked = True
        Me.n1.Location = New System.Drawing.Point(22, 14)
        Me.n1.Name = "n1"
        Me.n1.Size = New System.Drawing.Size(111, 17)
        Me.n1.TabIndex = 0
        Me.n1.TabStop = True
        Me.n1.Text = "Todos Los N. I. T."
        Me.n1.UseVisualStyleBackColor = True
        '
        'lbtipo
        '
        Me.lbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtipo.Location = New System.Drawing.Point(3, 6)
        Me.lbtipo.Name = "lbtipo"
        Me.lbtipo.Size = New System.Drawing.Size(493, 23)
        Me.lbtipo.TabIndex = 76
        Me.lbtipo.Text = "INFORME DE TIPO"
        Me.lbtipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmTributarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(506, 341)
        Me.Controls.Add(Me.lbtipo)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTributarios"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Informes Tributarios"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbtipo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ri2 As System.Windows.Forms.RadioButton
    Friend WithEvents ri1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents n2 As System.Windows.Forms.RadioButton
    Friend WithEvents n1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents cmdcertificado As System.Windows.Forms.Button
    Friend WithEvents txtperf As System.Windows.Forms.TextBox
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
