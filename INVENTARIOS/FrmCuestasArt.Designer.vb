<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuestasArt
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtcivag = New System.Windows.Forms.TextBox
        Me.txtnivag = New System.Windows.Forms.TextBox
        Me.txtcivad = New System.Windows.Forms.TextBox
        Me.txtnivad = New System.Windows.Forms.TextBox
        Me.txtcdev = New System.Windows.Forms.TextBox
        Me.txtndev = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcinv = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtninv = New System.Windows.Forms.TextBox
        Me.txtcing = New System.Windows.Forms.TextBox
        Me.txtning = New System.Windows.Forms.TextBox
        Me.txtccos = New System.Windows.Forms.TextBox
        Me.txtncos = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txtcivag)
        Me.GroupBox1.Controls.Add(Me.txtnivag)
        Me.GroupBox1.Controls.Add(Me.txtcivad)
        Me.GroupBox1.Controls.Add(Me.txtnivad)
        Me.GroupBox1.Controls.Add(Me.txtcdev)
        Me.GroupBox1.Controls.Add(Me.txtndev)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtcinv)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtninv)
        Me.GroupBox1.Controls.Add(Me.txtcing)
        Me.GroupBox1.Controls.Add(Me.txtning)
        Me.GroupBox1.Controls.Add(Me.txtccos)
        Me.GroupBox1.Controls.Add(Me.txtncos)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 211)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuentas del Articulo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(9, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "AFECTA"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(6, 190)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(246, 15)
        Me.Label33.TabIndex = 74
        Me.Label33.Text = "* Doble clic para seleccionar cuentas"
        '
        'txtcivag
        '
        Me.txtcivag.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcivag.Location = New System.Drawing.Point(135, 114)
        Me.txtcivag.Name = "txtcivag"
        Me.txtcivag.ShortcutsEnabled = False
        Me.txtcivag.Size = New System.Drawing.Size(100, 20)
        Me.txtcivag.TabIndex = 65
        '
        'txtnivag
        '
        Me.txtnivag.BackColor = System.Drawing.SystemColors.Control
        Me.txtnivag.Enabled = False
        Me.txtnivag.Location = New System.Drawing.Point(239, 114)
        Me.txtnivag.Name = "txtnivag"
        Me.txtnivag.Size = New System.Drawing.Size(155, 20)
        Me.txtnivag.TabIndex = 66
        '
        'txtcivad
        '
        Me.txtcivad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcivad.Location = New System.Drawing.Point(135, 140)
        Me.txtcivad.Name = "txtcivad"
        Me.txtcivad.ShortcutsEnabled = False
        Me.txtcivad.Size = New System.Drawing.Size(100, 20)
        Me.txtcivad.TabIndex = 67
        '
        'txtnivad
        '
        Me.txtnivad.BackColor = System.Drawing.SystemColors.Control
        Me.txtnivad.Enabled = False
        Me.txtnivad.Location = New System.Drawing.Point(239, 140)
        Me.txtnivad.Name = "txtnivad"
        Me.txtnivad.Size = New System.Drawing.Size(155, 20)
        Me.txtnivad.TabIndex = 68
        '
        'txtcdev
        '
        Me.txtcdev.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcdev.Location = New System.Drawing.Point(135, 166)
        Me.txtcdev.Name = "txtcdev"
        Me.txtcdev.ShortcutsEnabled = False
        Me.txtcdev.Size = New System.Drawing.Size(100, 20)
        Me.txtcdev.TabIndex = 69
        '
        'txtndev
        '
        Me.txtndev.BackColor = System.Drawing.SystemColors.Control
        Me.txtndev.Enabled = False
        Me.txtndev.Location = New System.Drawing.Point(239, 166)
        Me.txtndev.Name = "txtndev"
        Me.txtndev.Size = New System.Drawing.Size(155, 20)
        Me.txtndev.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 15)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "IVA Generado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 15)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "IVA descontable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Devoluciones"
        '
        'txtcinv
        '
        Me.txtcinv.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcinv.Location = New System.Drawing.Point(135, 36)
        Me.txtcinv.Name = "txtcinv"
        Me.txtcinv.ShortcutsEnabled = False
        Me.txtcinv.Size = New System.Drawing.Size(100, 20)
        Me.txtcinv.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(132, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 15)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "CUENTA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(237, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 15)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "DESCRIPCIÓN"
        '
        'txtninv
        '
        Me.txtninv.BackColor = System.Drawing.SystemColors.Control
        Me.txtninv.Enabled = False
        Me.txtninv.Location = New System.Drawing.Point(239, 36)
        Me.txtninv.Name = "txtninv"
        Me.txtninv.Size = New System.Drawing.Size(155, 20)
        Me.txtninv.TabIndex = 55
        '
        'txtcing
        '
        Me.txtcing.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcing.Location = New System.Drawing.Point(135, 62)
        Me.txtcing.Name = "txtcing"
        Me.txtcing.ShortcutsEnabled = False
        Me.txtcing.Size = New System.Drawing.Size(100, 20)
        Me.txtcing.TabIndex = 56
        '
        'txtning
        '
        Me.txtning.BackColor = System.Drawing.SystemColors.Control
        Me.txtning.Enabled = False
        Me.txtning.Location = New System.Drawing.Point(239, 62)
        Me.txtning.Name = "txtning"
        Me.txtning.Size = New System.Drawing.Size(155, 20)
        Me.txtning.TabIndex = 57
        '
        'txtccos
        '
        Me.txtccos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtccos.Location = New System.Drawing.Point(135, 88)
        Me.txtccos.Name = "txtccos"
        Me.txtccos.ShortcutsEnabled = False
        Me.txtccos.Size = New System.Drawing.Size(100, 20)
        Me.txtccos.TabIndex = 58
        '
        'txtncos
        '
        Me.txtncos.BackColor = System.Drawing.SystemColors.Control
        Me.txtncos.Enabled = False
        Me.txtncos.Location = New System.Drawing.Point(239, 88)
        Me.txtncos.Name = "txtncos"
        Me.txtncos.Size = New System.Drawing.Size(155, 20)
        Me.txtncos.TabIndex = 59
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 15)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Inventarios"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 15)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Ingresos"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(6, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 15)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Costos de Ventas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 221)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(420, 85)
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
        Me.GroupPanel1.TabIndex = 73
        '
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(210, 9)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 1
        Me.CmdSalir.Text = "&S"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.gparam
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(132, 8)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 0
        Me.CmdRegistrarCambios.Text = "&G"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'FrmCuestasArt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(427, 309)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCuestasArt"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE CUENTAS DEL ARTICULO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcivag As System.Windows.Forms.TextBox
    Friend WithEvents txtnivag As System.Windows.Forms.TextBox
    Friend WithEvents txtcivad As System.Windows.Forms.TextBox
    Friend WithEvents txtnivad As System.Windows.Forms.TextBox
    Friend WithEvents txtcdev As System.Windows.Forms.TextBox
    Friend WithEvents txtndev As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcinv As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtninv As System.Windows.Forms.TextBox
    Friend WithEvents txtcing As System.Windows.Forms.TextBox
    Friend WithEvents txtning As System.Windows.Forms.TextBox
    Friend WithEvents txtccos As System.Windows.Forms.TextBox
    Friend WithEvents txtncos As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
