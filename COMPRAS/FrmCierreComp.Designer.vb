<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierreComp
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.lbform = New System.Windows.Forms.Label
        Me.cmdActuaS = New DevComponents.DotNetBar.ButtonX
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 99)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(360, 79)
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
        Me.GroupPanel1.TabIndex = 68
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(21, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(93, 20)
        Me.TextBox1.TabIndex = 64
        Me.TextBox1.Visible = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdcancelar.Location = New System.Drawing.Point(140, 3)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(80, 61)
        Me.cmdcancelar.TabIndex = 2
        Me.cmdcancelar.Text = "&C"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(46, 20)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(0, 13)
        Me.lbform.TabIndex = 68
        Me.lbform.Visible = False
        '
        'cmdActuaS
        '
        Me.cmdActuaS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdActuaS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdActuaS.Location = New System.Drawing.Point(85, 38)
        Me.cmdActuaS.Name = "cmdActuaS"
        Me.cmdActuaS.Size = New System.Drawing.Size(192, 36)
        Me.cmdActuaS.TabIndex = 63
        Me.cmdActuaS.Text = "&Cierre Anual"
        Me.cmdActuaS.Tooltip = "cierre de inventarios"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdActuaS)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(360, 90)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(98, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "CIERRE ANUAL COMPRAS"
        '
        'FrmCierreComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 185)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCierreComp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cierre Anual"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents cmdActuaS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
