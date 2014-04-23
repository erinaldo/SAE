<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepDatos
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
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.cmdActuaS = New DevComponents.DotNetBar.ButtonX
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(52, 55)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 80
        Me.mibarra.Visible = False
        '
        'cmdActuaS
        '
        Me.cmdActuaS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdActuaS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdActuaS.Location = New System.Drawing.Point(68, 45)
        Me.cmdActuaS.Name = "cmdActuaS"
        Me.cmdActuaS.Size = New System.Drawing.Size(192, 36)
        Me.cmdActuaS.TabIndex = 63
        Me.cmdActuaS.Text = "&Reprocesar"
        Me.cmdActuaS.Tooltip = "cierre de inventarios"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(101, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "REPROCESAR DATOS"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 109)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(324, 85)
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
        Me.cmdcancelar.Location = New System.Drawing.Point(125, 8)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.mibarra)
        Me.GroupBox5.Controls.Add(Me.cmdActuaS)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(324, 101)
        Me.GroupBox5.TabIndex = 69
        Me.GroupBox5.TabStop = False
        '
        'FrmRepDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(343, 202)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepDatos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " SAE Reprocesar Datos de Ctas x Pagar"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdActuaS As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
