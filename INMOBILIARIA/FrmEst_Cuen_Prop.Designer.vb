<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEst_Cuen_Prop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEst_Cuen_Prop))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.g2 = New System.Windows.Forms.GroupBox
        Me.p2 = New System.Windows.Forms.RadioButton
        Me.p1 = New System.Windows.Forms.RadioButton
        Me.txtdueño = New System.Windows.Forms.TextBox
        Me.txtnomdu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbNov = New System.Windows.Forms.RadioButton
        Me.rbEsta = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbmes = New System.Windows.Forms.ComboBox
        Me.txtdi1 = New System.Windows.Forms.TextBox
        Me.txtmes = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.g2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 174)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(462, 85)
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
        Me.GroupPanel1.TabIndex = 119
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(223, 5)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 70)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.Color.White
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdpantalla.Location = New System.Drawing.Point(149, 5)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(70, 70)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Visualizar")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'g2
        '
        Me.g2.Controls.Add(Me.p2)
        Me.g2.Controls.Add(Me.p1)
        Me.g2.Controls.Add(Me.txtdueño)
        Me.g2.Controls.Add(Me.txtnomdu)
        Me.g2.Location = New System.Drawing.Point(4, 46)
        Me.g2.Name = "g2"
        Me.g2.Size = New System.Drawing.Size(460, 70)
        Me.g2.TabIndex = 120
        Me.g2.TabStop = False
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Location = New System.Drawing.Point(9, 43)
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
        Me.p1.Location = New System.Drawing.Point(8, 16)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(129, 17)
        Me.p1.TabIndex = 1
        Me.p1.TabStop = True
        Me.p1.Text = "Todos los Propietarios"
        Me.p1.UseVisualStyleBackColor = True
        '
        'txtdueño
        '
        Me.txtdueño.BackColor = System.Drawing.Color.White
        Me.txtdueño.Enabled = False
        Me.txtdueño.Location = New System.Drawing.Point(107, 42)
        Me.txtdueño.Name = "txtdueño"
        Me.txtdueño.Size = New System.Drawing.Size(100, 20)
        Me.txtdueño.TabIndex = 3
        '
        'txtnomdu
        '
        Me.txtnomdu.Enabled = False
        Me.txtnomdu.Location = New System.Drawing.Point(213, 43)
        Me.txtnomdu.Name = "txtnomdu"
        Me.txtnomdu.Size = New System.Drawing.Size(235, 20)
        Me.txtnomdu.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Hasta Periodo"
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(97, 14)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(40, 21)
        Me.cbper.TabIndex = 123
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbNov)
        Me.GroupBox1.Controls.Add(Me.rbEsta)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 51)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Visualizar"
        '
        'rbNov
        '
        Me.rbNov.AutoSize = True
        Me.rbNov.Location = New System.Drawing.Point(272, 19)
        Me.rbNov.Name = "rbNov"
        Me.rbNov.Size = New System.Drawing.Size(134, 17)
        Me.rbNov.TabIndex = 122
        Me.rbNov.Text = "Novedades / Anticipos"
        Me.rbNov.UseVisualStyleBackColor = True
        '
        'rbEsta
        '
        Me.rbEsta.AutoSize = True
        Me.rbEsta.Checked = True
        Me.rbEsta.Location = New System.Drawing.Point(62, 19)
        Me.rbEsta.Name = "rbEsta"
        Me.rbEsta.Size = New System.Drawing.Size(110, 17)
        Me.rbEsta.TabIndex = 0
        Me.rbEsta.TabStop = True
        Me.rbEsta.Text = "Estado de Cuenta"
        Me.rbEsta.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbmes)
        Me.GroupBox2.Controls.Add(Me.txtdi1)
        Me.GroupBox2.Controls.Add(Me.txtmes)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbper)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(460, 41)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'cbmes
        '
        Me.cbmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmes.FormattingEnabled = True
        Me.cbmes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbmes.Location = New System.Drawing.Point(342, 12)
        Me.cbmes.Name = "cbmes"
        Me.cbmes.Size = New System.Drawing.Size(40, 21)
        Me.cbmes.TabIndex = 124
        '
        'txtdi1
        '
        Me.txtdi1.Location = New System.Drawing.Point(308, 13)
        Me.txtdi1.MaxLength = 2
        Me.txtdi1.Name = "txtdi1"
        Me.txtdi1.Size = New System.Drawing.Size(30, 20)
        Me.txtdi1.TabIndex = 123
        Me.txtdi1.Text = "08"
        '
        'txtmes
        '
        Me.txtmes.BackColor = System.Drawing.Color.White
        Me.txtmes.Enabled = False
        Me.txtmes.Location = New System.Drawing.Point(387, 12)
        Me.txtmes.Name = "txtmes"
        Me.txtmes.ReadOnly = True
        Me.txtmes.Size = New System.Drawing.Size(51, 20)
        Me.txtmes.TabIndex = 127
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(209, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Fecha de Pago"
        '
        'FrmEst_Cuen_Prop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(469, 261)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.g2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEst_Cuen_Prop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Extrato Propietario Inmueble"
        Me.GroupPanel1.ResumeLayout(False)
        Me.g2.ResumeLayout(False)
        Me.g2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents g2 As System.Windows.Forms.GroupBox
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtdueño As System.Windows.Forms.TextBox
    Friend WithEvents txtnomdu As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEsta As System.Windows.Forms.RadioButton
    Friend WithEvents rbNov As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdi1 As System.Windows.Forms.TextBox
    Friend WithEvents cbmes As System.Windows.Forms.ComboBox
End Class
