<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParBancos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParBancos))
        Me.txtn4 = New System.Windows.Forms.TextBox
        Me.txtn3 = New System.Windows.Forms.TextBox
        Me.txtn2 = New System.Windows.Forms.TextBox
        Me.txtn1 = New System.Windows.Forms.TextBox
        Me.txtdoc1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtdoc3 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtdoc2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdoc4 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtn4
        '
        Me.txtn4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn4.Location = New System.Drawing.Point(235, 184)
        Me.txtn4.Name = "txtn4"
        Me.txtn4.ReadOnly = True
        Me.txtn4.Size = New System.Drawing.Size(304, 20)
        Me.txtn4.TabIndex = 7
        '
        'txtn3
        '
        Me.txtn3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn3.Location = New System.Drawing.Point(235, 146)
        Me.txtn3.Name = "txtn3"
        Me.txtn3.ReadOnly = True
        Me.txtn3.Size = New System.Drawing.Size(304, 20)
        Me.txtn3.TabIndex = 5
        '
        'txtn2
        '
        Me.txtn2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn2.Location = New System.Drawing.Point(235, 110)
        Me.txtn2.Name = "txtn2"
        Me.txtn2.ReadOnly = True
        Me.txtn2.Size = New System.Drawing.Size(304, 20)
        Me.txtn2.TabIndex = 3
        '
        'txtn1
        '
        Me.txtn1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn1.Location = New System.Drawing.Point(235, 75)
        Me.txtn1.Name = "txtn1"
        Me.txtn1.ReadOnly = True
        Me.txtn1.Size = New System.Drawing.Size(304, 20)
        Me.txtn1.TabIndex = 1
        '
        'txtdoc1
        '
        Me.txtdoc1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc1.Location = New System.Drawing.Point(187, 76)
        Me.txtdoc1.Name = "txtdoc1"
        Me.txtdoc1.ShortcutsEnabled = False
        Me.txtdoc1.Size = New System.Drawing.Size(41, 20)
        Me.txtdoc1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label3.Location = New System.Drawing.Point(23, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "Pagos con Cheques"
        '
        'txtdoc3
        '
        Me.txtdoc3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc3.Location = New System.Drawing.Point(187, 146)
        Me.txtdoc3.Name = "txtdoc3"
        Me.txtdoc3.ShortcutsEnabled = False
        Me.txtdoc3.Size = New System.Drawing.Size(41, 20)
        Me.txtdoc3.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label2.Location = New System.Drawing.Point(23, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Conciliaciones Bancarias"
        '
        'txtdoc2
        '
        Me.txtdoc2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc2.Location = New System.Drawing.Point(187, 111)
        Me.txtdoc2.Name = "txtdoc2"
        Me.txtdoc2.ShortcutsEnabled = False
        Me.txtdoc2.Size = New System.Drawing.Size(41, 20)
        Me.txtdoc2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label1.Location = New System.Drawing.Point(23, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 13)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "Consignaciones Bancarias"
        '
        'txtdoc4
        '
        Me.txtdoc4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc4.Location = New System.Drawing.Point(187, 184)
        Me.txtdoc4.Name = "txtdoc4"
        Me.txtdoc4.ShortcutsEnabled = False
        Me.txtdoc4.Size = New System.Drawing.Size(41, 20)
        Me.txtdoc4.TabIndex = 6
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Brown
        Me.Label24.Location = New System.Drawing.Point(10, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(534, 32)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "ESTOS PARAMETROS SON OBLIGATORIOS PARA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LOS DOCUMENTOS DE BANCOS"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label12.Location = New System.Drawing.Point(23, 187)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(150, 13)
        Me.Label12.TabIndex = 157
        Me.Label12.Text = "Transacciones Bancarias"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.cmdguardar)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 228)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(555, 85)
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
        Me.GroupPanel1.TabIndex = 206
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Brown
        Me.Label25.Location = New System.Drawing.Point(11, 41)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(528, 16)
        Me.Label25.TabIndex = 78
        Me.Label25.Text = "_________________________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtn4)
        Me.GroupBox1.Controls.Add(Me.txtn3)
        Me.GroupBox1.Controls.Add(Me.txtn2)
        Me.GroupBox1.Controls.Add(Me.txtn1)
        Me.GroupBox1.Controls.Add(Me.txtdoc1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtdoc3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtdoc2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtdoc4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 218)
        Me.GroupBox1.TabIndex = 207
        Me.GroupBox1.TabStop = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(287, 8)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 32
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(196, 8)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 31
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'FrmParBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 318)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametros de Bancos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtn4 As System.Windows.Forms.TextBox
    Friend WithEvents txtn3 As System.Windows.Forms.TextBox
    Friend WithEvents txtn2 As System.Windows.Forms.TextBox
    Friend WithEvents txtn1 As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtdoc3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdoc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdoc4 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
