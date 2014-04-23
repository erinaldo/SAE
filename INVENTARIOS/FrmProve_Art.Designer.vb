<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProve_Art
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.txt4 = New System.Windows.Forms.TextBox
        Me.txtn4 = New System.Windows.Forms.TextBox
        Me.txt5 = New System.Windows.Forms.TextBox
        Me.txtn5 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtn1 = New System.Windows.Forms.TextBox
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.txtn2 = New System.Windows.Forms.TextBox
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.txtn3 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(9, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "NUMERO"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(9, 173)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(248, 15)
        Me.Label33.TabIndex = 74
        Me.Label33.Text = "* Doble clic para seleccionar NIT / CC"
        '
        'txt4
        '
        Me.txt4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt4.Location = New System.Drawing.Point(135, 114)
        Me.txt4.Name = "txt4"
        Me.txt4.ReadOnly = True
        Me.txt4.ShortcutsEnabled = False
        Me.txt4.Size = New System.Drawing.Size(100, 20)
        Me.txt4.TabIndex = 65
        '
        'txtn4
        '
        Me.txtn4.BackColor = System.Drawing.SystemColors.Control
        Me.txtn4.Enabled = False
        Me.txtn4.Location = New System.Drawing.Point(239, 114)
        Me.txtn4.Name = "txtn4"
        Me.txtn4.Size = New System.Drawing.Size(207, 20)
        Me.txtn4.TabIndex = 66
        '
        'txt5
        '
        Me.txt5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt5.Location = New System.Drawing.Point(135, 140)
        Me.txt5.Name = "txt5"
        Me.txt5.ReadOnly = True
        Me.txt5.ShortcutsEnabled = False
        Me.txt5.Size = New System.Drawing.Size(100, 20)
        Me.txt5.TabIndex = 67
        '
        'txtn5
        '
        Me.txtn5.BackColor = System.Drawing.SystemColors.Control
        Me.txtn5.Enabled = False
        Me.txtn5.Location = New System.Drawing.Point(239, 140)
        Me.txtn5.Name = "txtn5"
        Me.txtn5.Size = New System.Drawing.Size(207, 20)
        Me.txtn5.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Proveedor 4"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 211)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(465, 85)
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
        Me.GroupPanel1.TabIndex = 75
        '
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(234, 8)
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
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(156, 7)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 0
        Me.CmdRegistrarCambios.Text = "&G"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Proveedor 5"
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt1.Location = New System.Drawing.Point(135, 36)
        Me.txt1.Name = "txt1"
        Me.txt1.ReadOnly = True
        Me.txt1.ShortcutsEnabled = False
        Me.txt1.Size = New System.Drawing.Size(100, 20)
        Me.txt1.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(132, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "NIT / CC"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(237, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(177, 15)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "NOMBRE / RAZON SOCIAL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txt4)
        Me.GroupBox1.Controls.Add(Me.txtn4)
        Me.GroupBox1.Controls.Add(Me.txt5)
        Me.GroupBox1.Controls.Add(Me.txtn5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtn1)
        Me.GroupBox1.Controls.Add(Me.txt2)
        Me.GroupBox1.Controls.Add(Me.txtn2)
        Me.GroupBox1.Controls.Add(Me.txt3)
        Me.GroupBox1.Controls.Add(Me.txtn3)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 200)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proveedores del Articulo"
        '
        'txtn1
        '
        Me.txtn1.BackColor = System.Drawing.SystemColors.Control
        Me.txtn1.Enabled = False
        Me.txtn1.Location = New System.Drawing.Point(239, 36)
        Me.txtn1.Name = "txtn1"
        Me.txtn1.Size = New System.Drawing.Size(207, 20)
        Me.txtn1.TabIndex = 55
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt2.Location = New System.Drawing.Point(135, 62)
        Me.txt2.Name = "txt2"
        Me.txt2.ReadOnly = True
        Me.txt2.ShortcutsEnabled = False
        Me.txt2.Size = New System.Drawing.Size(100, 20)
        Me.txt2.TabIndex = 56
        '
        'txtn2
        '
        Me.txtn2.BackColor = System.Drawing.SystemColors.Control
        Me.txtn2.Enabled = False
        Me.txtn2.Location = New System.Drawing.Point(239, 62)
        Me.txtn2.Name = "txtn2"
        Me.txtn2.Size = New System.Drawing.Size(207, 20)
        Me.txtn2.TabIndex = 57
        '
        'txt3
        '
        Me.txt3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt3.Location = New System.Drawing.Point(135, 88)
        Me.txt3.Name = "txt3"
        Me.txt3.ReadOnly = True
        Me.txt3.ShortcutsEnabled = False
        Me.txt3.Size = New System.Drawing.Size(100, 20)
        Me.txt3.TabIndex = 58
        '
        'txtn3
        '
        Me.txtn3.BackColor = System.Drawing.SystemColors.Control
        Me.txtn3.Enabled = False
        Me.txtn3.Location = New System.Drawing.Point(239, 88)
        Me.txtn3.Name = "txtn3"
        Me.txtn3.Size = New System.Drawing.Size(207, 20)
        Me.txtn3.TabIndex = 59
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(6, 37)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 15)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Proveedor 1"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 15)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Proveedor 2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(6, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 15)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Proveedor 3"
        '
        'FrmProve_Art
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(478, 303)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProve_Art"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Proveedores del Articulo"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents txtn4 As System.Windows.Forms.TextBox
    Friend WithEvents txt5 As System.Windows.Forms.TextBox
    Friend WithEvents txtn5 As System.Windows.Forms.TextBox
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtn1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txtn2 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txtn3 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
