<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfContratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfContratos))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.txtnomarr = New System.Windows.Forms.TextBox
        Me.txtarre = New System.Windows.Forms.TextBox
        Me.txtnomdu = New System.Windows.Forms.TextBox
        Me.txtdueño = New System.Windows.Forms.TextBox
        Me.txtcontrato = New System.Windows.Forms.TextBox
        Me.g1 = New System.Windows.Forms.GroupBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.g2 = New System.Windows.Forms.GroupBox
        Me.p2 = New System.Windows.Forms.RadioButton
        Me.p1 = New System.Windows.Forms.RadioButton
        Me.g3 = New System.Windows.Forms.GroupBox
        Me.a2 = New System.Windows.Forms.RadioButton
        Me.a1 = New System.Windows.Forms.RadioButton
        Me.c3 = New System.Windows.Forms.RadioButton
        Me.cbmes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.g1.SuspendLayout()
        Me.g2.SuspendLayout()
        Me.g3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 246)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(449, 85)
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
        Me.GroupPanel1.TabIndex = 3
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(226, 19)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 15
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(161, 19)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'txtnomarr
        '
        Me.txtnomarr.Enabled = False
        Me.txtnomarr.Location = New System.Drawing.Point(222, 36)
        Me.txtnomarr.Name = "txtnomarr"
        Me.txtnomarr.Size = New System.Drawing.Size(222, 20)
        Me.txtnomarr.TabIndex = 4
        '
        'txtarre
        '
        Me.txtarre.BackColor = System.Drawing.Color.White
        Me.txtarre.Enabled = False
        Me.txtarre.Location = New System.Drawing.Point(116, 37)
        Me.txtarre.Name = "txtarre"
        Me.txtarre.Size = New System.Drawing.Size(100, 20)
        Me.txtarre.TabIndex = 3
        '
        'txtnomdu
        '
        Me.txtnomdu.Enabled = False
        Me.txtnomdu.Location = New System.Drawing.Point(210, 40)
        Me.txtnomdu.Name = "txtnomdu"
        Me.txtnomdu.Size = New System.Drawing.Size(235, 20)
        Me.txtnomdu.TabIndex = 4
        '
        'txtdueño
        '
        Me.txtdueño.BackColor = System.Drawing.Color.White
        Me.txtdueño.Enabled = False
        Me.txtdueño.Location = New System.Drawing.Point(107, 40)
        Me.txtdueño.Name = "txtdueño"
        Me.txtdueño.Size = New System.Drawing.Size(100, 20)
        Me.txtdueño.TabIndex = 3
        '
        'txtcontrato
        '
        Me.txtcontrato.BackColor = System.Drawing.Color.White
        Me.txtcontrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontrato.Enabled = False
        Me.txtcontrato.Location = New System.Drawing.Point(109, 45)
        Me.txtcontrato.Name = "txtcontrato"
        Me.txtcontrato.Size = New System.Drawing.Size(143, 20)
        Me.txtcontrato.TabIndex = 3
        '
        'g1
        '
        Me.g1.Controls.Add(Me.Label1)
        Me.g1.Controls.Add(Me.cbmes)
        Me.g1.Controls.Add(Me.c3)
        Me.g1.Controls.Add(Me.c2)
        Me.g1.Controls.Add(Me.c1)
        Me.g1.Controls.Add(Me.txtcontrato)
        Me.g1.Location = New System.Drawing.Point(6, 3)
        Me.g1.Name = "g1"
        Me.g1.Size = New System.Drawing.Size(449, 100)
        Me.g1.TabIndex = 0
        Me.g1.TabStop = False
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(18, 45)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(82, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "Un Contrato"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(18, 19)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(119, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "Todos los Contratos"
        Me.c1.UseVisualStyleBackColor = True
        '
        'g2
        '
        Me.g2.Controls.Add(Me.p2)
        Me.g2.Controls.Add(Me.p1)
        Me.g2.Controls.Add(Me.txtdueño)
        Me.g2.Controls.Add(Me.txtnomdu)
        Me.g2.Location = New System.Drawing.Point(6, 102)
        Me.g2.Name = "g2"
        Me.g2.Size = New System.Drawing.Size(449, 75)
        Me.g2.TabIndex = 1
        Me.g2.TabStop = False
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Location = New System.Drawing.Point(13, 40)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(92, 17)
        Me.p2.TabIndex = 2
        Me.p2.Text = "Un Propietario"
        Me.p2.UseVisualStyleBackColor = True
        '
        'p1
        '
        Me.p1.AutoSize = True
        Me.p1.Checked = True
        Me.p1.Location = New System.Drawing.Point(13, 16)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(129, 17)
        Me.p1.TabIndex = 1
        Me.p1.TabStop = True
        Me.p1.Text = "Todos los Propietarios"
        Me.p1.UseVisualStyleBackColor = True
        '
        'g3
        '
        Me.g3.Controls.Add(Me.a2)
        Me.g3.Controls.Add(Me.a1)
        Me.g3.Controls.Add(Me.txtnomarr)
        Me.g3.Controls.Add(Me.txtarre)
        Me.g3.Location = New System.Drawing.Point(6, 176)
        Me.g3.Name = "g3"
        Me.g3.Size = New System.Drawing.Size(449, 65)
        Me.g3.TabIndex = 2
        Me.g3.TabStop = False
        '
        'a2
        '
        Me.a2.AutoSize = True
        Me.a2.Location = New System.Drawing.Point(12, 39)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(99, 17)
        Me.a2.TabIndex = 2
        Me.a2.Text = "Un Arrendatario"
        Me.a2.UseVisualStyleBackColor = True
        '
        'a1
        '
        Me.a1.AutoSize = True
        Me.a1.Checked = True
        Me.a1.Location = New System.Drawing.Point(12, 15)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(136, 17)
        Me.a1.TabIndex = 1
        Me.a1.TabStop = True
        Me.a1.Text = "Todos los Arrendatarios"
        Me.a1.UseVisualStyleBackColor = True
        '
        'c3
        '
        Me.c3.AutoSize = True
        Me.c3.Location = New System.Drawing.Point(18, 70)
        Me.c3.Name = "c3"
        Me.c3.Size = New System.Drawing.Size(32, 17)
        Me.c3.TabIndex = 4
        Me.c3.Text = "A"
        Me.c3.UseVisualStyleBackColor = True
        '
        'cbmes
        '
        Me.cbmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmes.Enabled = False
        Me.cbmes.FormattingEnabled = True
        Me.cbmes.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbmes.Location = New System.Drawing.Point(55, 69)
        Me.cbmes.Name = "cbmes"
        Me.cbmes.Size = New System.Drawing.Size(43, 21)
        Me.cbmes.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Meses de Terminar"
        '
        'FrmInfContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(463, 337)
        Me.Controls.Add(Me.g3)
        Me.Controls.Add(Me.g2)
        Me.Controls.Add(Me.g1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informes de Contratos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.g1.ResumeLayout(False)
        Me.g1.PerformLayout()
        Me.g2.ResumeLayout(False)
        Me.g2.PerformLayout()
        Me.g3.ResumeLayout(False)
        Me.g3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txtnomarr As System.Windows.Forms.TextBox
    Friend WithEvents txtarre As System.Windows.Forms.TextBox
    Friend WithEvents txtnomdu As System.Windows.Forms.TextBox
    Friend WithEvents txtdueño As System.Windows.Forms.TextBox
    Friend WithEvents txtcontrato As System.Windows.Forms.TextBox
    Friend WithEvents g1 As System.Windows.Forms.GroupBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents g2 As System.Windows.Forms.GroupBox
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents g3 As System.Windows.Forms.GroupBox
    Friend WithEvents a2 As System.Windows.Forms.RadioButton
    Friend WithEvents a1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbmes As System.Windows.Forms.ComboBox
    Friend WithEvents c3 As System.Windows.Forms.RadioButton
End Class
