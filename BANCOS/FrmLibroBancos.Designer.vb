<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLibroBancos
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.c3 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtpfin = New System.Windows.Forms.TextBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(238, 104)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(246, 20)
        Me.TextBox1.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.IndianRed
        Me.Label7.Location = New System.Drawing.Point(134, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 13)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "* Doble clic para escoger bancos"
        '
        'txtcuenta
        '
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Location = New System.Drawing.Point(134, 104)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(100, 20)
        Me.txtcuenta.TabIndex = 76
        '
        'c3
        '
        Me.c3.AutoSize = True
        Me.c3.Location = New System.Drawing.Point(21, 104)
        Me.c3.Name = "c3"
        Me.c3.Size = New System.Drawing.Size(73, 17)
        Me.c3.TabIndex = 75
        Me.c3.Text = "Un &Banco"
        Me.c3.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(21, 76)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(114, 17)
        Me.c1.TabIndex = 74
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos Los Bancos"
        Me.c1.UseVisualStyleBackColor = True
        '
        'cbfin
        '
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Location = New System.Drawing.Point(214, 19)
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 58
        '
        'cbini
        '
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(70, 20)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(169, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Final"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 162)
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
        Me.GroupPanel1.TabIndex = 74
        '
        'txtpfin
        '
        Me.txtpfin.BackColor = System.Drawing.SystemColors.Control
        Me.txtpfin.Enabled = False
        Me.txtpfin.Location = New System.Drawing.Point(257, 20)
        Me.txtpfin.Name = "txtpfin"
        Me.txtpfin.Size = New System.Drawing.Size(42, 20)
        Me.txtpfin.TabIndex = 55
        Me.txtpfin.Text = "/0000"
        '
        'txtpini
        '
        Me.txtpini.BackColor = System.Drawing.SystemColors.Control
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(115, 20)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 53
        Me.txtpini.Text = "/0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Inicial"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtcuenta)
        Me.GroupBox1.Controls.Add(Me.c3)
        Me.GroupBox1.Controls.Add(Me.c1)
        Me.GroupBox1.Controls.Add(Me.cbfin)
        Me.GroupBox1.Controls.Add(Me.cbini)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtpfin)
        Me.GroupBox1.Controls.Add(Me.txtpini)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 155)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(246, 11)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 16
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(181, 11)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 15
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'FrmLibroBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(501, 252)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLibroBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Libro Bancos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents c3 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txtpfin As System.Windows.Forms.TextBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
