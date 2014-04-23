<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambiarContraComp
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
        Me.actual = New System.Windows.Forms.TextBox
        Me.lbusuario = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.pass1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pass2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdcambiar = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'actual
        '
        Me.actual.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.actual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.actual.Location = New System.Drawing.Point(214, 56)
        Me.actual.MaxLength = 150
        Me.actual.Name = "actual"
        Me.actual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.actual.Size = New System.Drawing.Size(160, 20)
        Me.actual.TabIndex = 0
        '
        'lbusuario
        '
        Me.lbusuario.AutoSize = True
        Me.lbusuario.BackColor = System.Drawing.Color.Transparent
        Me.lbusuario.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuario.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbusuario.Location = New System.Drawing.Point(208, 17)
        Me.lbusuario.Name = "lbusuario"
        Me.lbusuario.Size = New System.Drawing.Size(118, 31)
        Me.lbusuario.TabIndex = 262
        Me.lbusuario.Text = "compañia"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(19, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(138, 29)
        Me.Label14.TabIndex = 261
        Me.Label14.Text = "Compañia:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.actual)
        Me.GroupBox2.Controls.Add(Me.lbusuario)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.pass1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.pass2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(428, 139)
        Me.GroupBox2.TabIndex = 266
        Me.GroupBox2.TabStop = False
        '
        'pass1
        '
        Me.pass1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pass1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pass1.Location = New System.Drawing.Point(214, 82)
        Me.pass1.MaxLength = 150
        Me.pass1.Name = "pass1"
        Me.pass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass1.Size = New System.Drawing.Size(160, 20)
        Me.pass1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 15)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Digite Nueva Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(21, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 15)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Digite Contraseña Actual"
        '
        'pass2
        '
        Me.pass2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pass2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pass2.Location = New System.Drawing.Point(214, 109)
        Me.pass2.MaxLength = 150
        Me.pass2.Name = "pass2"
        Me.pass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass2.Size = New System.Drawing.Size(160, 20)
        Me.pass2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(21, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 15)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Confirmar Nueva Contraseña"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.cmdcambiar)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 178)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(458, 85)
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
        Me.GroupPanel1.TabIndex = 265
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(458, 172)
        Me.GroupBox4.TabIndex = 266
        Me.GroupBox4.TabStop = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(226, 7)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 4
        Me.cmdcancelar.Text = "&S"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar Operación")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdcambiar
        '
        Me.cmdcambiar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcambiar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcambiar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdcambiar.Location = New System.Drawing.Point(153, 7)
        Me.cmdcambiar.Name = "cmdcambiar"
        Me.cmdcambiar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcambiar.TabIndex = 3
        Me.cmdcambiar.Text = "&S"
        Me.cmdcambiar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcambiar, "Cambiar Contraseña")
        Me.cmdcambiar.UseVisualStyleBackColor = False
        '
        'FrmCambiarContraComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(469, 267)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmCambiarContraComp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "  SAE Cambiar Contraseña Compañia"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents actual As System.Windows.Forms.TextBox
    Friend WithEvents cmdcambiar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbusuario As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pass2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
