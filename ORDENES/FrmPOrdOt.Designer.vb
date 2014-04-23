<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOrdOt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOrdOt))
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_nrc = New System.Windows.Forms.TextBox
        Me.txt_nci = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.rc = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.ci = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(14, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Interfaz"
        '
        'txt_nrc
        '
        Me.txt_nrc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_nrc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nrc.Enabled = False
        Me.txt_nrc.Location = New System.Drawing.Point(276, 57)
        Me.txt_nrc.Name = "txt_nrc"
        Me.txt_nrc.Size = New System.Drawing.Size(306, 20)
        Me.txt_nrc.TabIndex = 92
        '
        'txt_nci
        '
        Me.txt_nci.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_nci.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_nci.Enabled = False
        Me.txt_nci.Location = New System.Drawing.Point(276, 31)
        Me.txt_nci.Name = "txt_nci"
        Me.txt_nci.Size = New System.Drawing.Size(306, 20)
        Me.txt_nci.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(239, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Documento"
        '
        'rc
        '
        Me.rc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.rc.Location = New System.Drawing.Point(242, 57)
        Me.rc.Name = "rc"
        Me.rc.Size = New System.Drawing.Size(29, 20)
        Me.rc.TabIndex = 87
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(147, 20)
        Me.Label30.TabIndex = 89
        Me.Label30.Text = "Recibo de Caja P"
        '
        'ci
        '
        Me.ci.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ci.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ci.Location = New System.Drawing.Point(242, 31)
        Me.ci.Name = "ci"
        Me.ci.Size = New System.Drawing.Size(29, 20)
        Me.ci.TabIndex = 86
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(133, 20)
        Me.Label29.TabIndex = 88
        Me.Label29.Text = "CI Presupuesto"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 89)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(572, 94)
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
        Me.GroupPanel1.TabIndex = 94
        '
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(277, 10)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 1
        Me.CmdSalir.Text = "&C"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.gparam
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(199, 9)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 0
        Me.CmdRegistrarCambios.Text = "&G"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'FrmPOrdOt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(596, 186)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_nrc)
        Me.Controls.Add(Me.txt_nci)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rc)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.ci)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOrdOt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Otros documentos Recaudo"
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_nrc As System.Windows.Forms.TextBox
    Friend WithEvents txt_nci As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rc As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ci As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
End Class
