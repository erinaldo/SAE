<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfServPub
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfServPub))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbEstado = New System.Windows.Forms.ComboBox
        Me.i3 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtinm = New System.Windows.Forms.TextBox
        Me.i2 = New System.Windows.Forms.RadioButton
        Me.i1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbServ = New System.Windows.Forms.ComboBox
        Me.s2 = New System.Windows.Forms.RadioButton
        Me.s1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.i3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtinm)
        Me.GroupBox1.Controls.Add(Me.i2)
        Me.GroupBox1.Controls.Add(Me.i1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(451, 103)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inmuebles"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"DISPONIBLE", "OCUPADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(91, 69)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(132, 21)
        Me.cmbEstado.TabIndex = 89
        '
        'i3
        '
        Me.i3.AutoSize = True
        Me.i3.Location = New System.Drawing.Point(5, 71)
        Me.i3.Name = "i3"
        Me.i3.Size = New System.Drawing.Size(76, 17)
        Me.i3.TabIndex = 8
        Me.i3.Text = "&Por estado"
        Me.i3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(207, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "* Doble click para buscar"
        '
        'txtinm
        '
        Me.txtinm.BackColor = System.Drawing.Color.White
        Me.txtinm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinm.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtinm.Enabled = False
        Me.txtinm.Location = New System.Drawing.Point(92, 40)
        Me.txtinm.MaxLength = 30
        Me.txtinm.Name = "txtinm"
        Me.txtinm.Size = New System.Drawing.Size(111, 20)
        Me.txtinm.TabIndex = 3
        '
        'i2
        '
        Me.i2.AutoSize = True
        Me.i2.Location = New System.Drawing.Point(5, 42)
        Me.i2.Name = "i2"
        Me.i2.Size = New System.Drawing.Size(85, 17)
        Me.i2.TabIndex = 2
        Me.i2.Text = "&Un Inmueble"
        Me.i2.UseVisualStyleBackColor = True
        '
        'i1
        '
        Me.i1.AutoSize = True
        Me.i1.Checked = True
        Me.i1.Location = New System.Drawing.Point(6, 19)
        Me.i1.Name = "i1"
        Me.i1.Size = New System.Drawing.Size(122, 17)
        Me.i1.TabIndex = 1
        Me.i1.TabStop = True
        Me.i1.Text = "&Todos los Inmuebles"
        Me.i1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 185)
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
        Me.GroupPanel1.TabIndex = 6
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbServ)
        Me.GroupBox2.Controls.Add(Me.s2)
        Me.GroupBox2.Controls.Add(Me.s1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(451, 69)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Servicios"
        '
        'cmbServ
        '
        Me.cmbServ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServ.Enabled = False
        Me.cmbServ.FormattingEnabled = True
        Me.cmbServ.Location = New System.Drawing.Point(89, 41)
        Me.cmbServ.Name = "cmbServ"
        Me.cmbServ.Size = New System.Drawing.Size(188, 21)
        Me.cmbServ.TabIndex = 90
        '
        's2
        '
        Me.s2.AutoSize = True
        Me.s2.Location = New System.Drawing.Point(5, 42)
        Me.s2.Name = "s2"
        Me.s2.Size = New System.Drawing.Size(78, 17)
        Me.s2.TabIndex = 2
        Me.s2.Text = "&Un servicio"
        Me.s2.UseVisualStyleBackColor = True
        '
        's1
        '
        Me.s1.AutoSize = True
        Me.s1.Checked = True
        Me.s1.Location = New System.Drawing.Point(6, 19)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(115, 17)
        Me.s1.TabIndex = 1
        Me.s1.TabStop = True
        Me.s1.Text = "&Todos los servicios"
        Me.s1.UseVisualStyleBackColor = True
        '
        'FrmInfServPub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(460, 275)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfServPub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe de Servicios Publicos Inmobiliaria"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtinm As System.Windows.Forms.TextBox
    Friend WithEvents i2 As System.Windows.Forms.RadioButton
    Friend WithEvents i1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents s2 As System.Windows.Forms.RadioButton
    Friend WithEvents s1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents i3 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbServ As System.Windows.Forms.ComboBox
End Class
