<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoCentroC
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cborden = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtnccf = New System.Windows.Forms.TextBox
        Me.txtccf = New System.Windows.Forms.TextBox
        Me.rb_cc1 = New System.Windows.Forms.RadioButton
        Me.txtncci = New System.Windows.Forms.TextBox
        Me.rb_cc2 = New System.Windows.Forms.RadioButton
        Me.txtcci = New System.Windows.Forms.TextBox
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 175)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cborden)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(437, 50)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'cborden
        '
        Me.cborden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cborden.FormattingEnabled = True
        Me.cborden.Items.AddRange(New Object() {"Codigo", "Alfabetico"})
        Me.cborden.Location = New System.Drawing.Point(173, 19)
        Me.cborden.Name = "cborden"
        Me.cborden.Size = New System.Drawing.Size(121, 21)
        Me.cborden.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 15)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Ordenar Informe Por"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtnccf)
        Me.GroupBox2.Controls.Add(Me.txtccf)
        Me.GroupBox2.Controls.Add(Me.rb_cc1)
        Me.GroupBox2.Controls.Add(Me.txtncci)
        Me.GroupBox2.Controls.Add(Me.rb_cc2)
        Me.GroupBox2.Controls.Add(Me.txtcci)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 102)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtnccf
        '
        Me.txtnccf.Enabled = False
        Me.txtnccf.Location = New System.Drawing.Point(173, 71)
        Me.txtnccf.Name = "txtnccf"
        Me.txtnccf.Size = New System.Drawing.Size(253, 20)
        Me.txtnccf.TabIndex = 5
        '
        'txtccf
        '
        Me.txtccf.Location = New System.Drawing.Point(109, 72)
        Me.txtccf.Name = "txtccf"
        Me.txtccf.Size = New System.Drawing.Size(58, 20)
        Me.txtccf.TabIndex = 4
        '
        'rb_cc1
        '
        Me.rb_cc1.AutoSize = True
        Me.rb_cc1.Checked = True
        Me.rb_cc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_cc1.Location = New System.Drawing.Point(14, 19)
        Me.rb_cc1.Name = "rb_cc1"
        Me.rb_cc1.Size = New System.Drawing.Size(181, 17)
        Me.rb_cc1.TabIndex = 0
        Me.rb_cc1.TabStop = True
        Me.rb_cc1.Text = "Todos los Centros de Costo"
        Me.rb_cc1.UseVisualStyleBackColor = True
        '
        'txtncci
        '
        Me.txtncci.Enabled = False
        Me.txtncci.Location = New System.Drawing.Point(173, 45)
        Me.txtncci.Name = "txtncci"
        Me.txtncci.Size = New System.Drawing.Size(253, 20)
        Me.txtncci.TabIndex = 3
        '
        'rb_cc2
        '
        Me.rb_cc2.AutoSize = True
        Me.rb_cc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_cc2.Location = New System.Drawing.Point(14, 46)
        Me.rb_cc2.Name = "rb_cc2"
        Me.rb_cc2.Size = New System.Drawing.Size(85, 17)
        Me.rb_cc2.TabIndex = 1
        Me.rb_cc2.Text = "Por Rango"
        Me.rb_cc2.UseVisualStyleBackColor = True
        '
        'txtcci
        '
        Me.txtcci.Location = New System.Drawing.Point(109, 46)
        Me.txtcci.Name = "txtcci"
        Me.txtcci.Size = New System.Drawing.Size(58, 20)
        Me.txtcci.TabIndex = 2
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 184)
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
        Me.GroupPanel1.TabIndex = 2
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(235, 7)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(65, 66)
        Me.cmdsalir.TabIndex = 3
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(166, 7)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(65, 66)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&G"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'FrmInfoCentroC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(479, 278)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoCentroC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Informe del Catalogo de  Centros de Costo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cborden As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnccf As System.Windows.Forms.TextBox
    Friend WithEvents txtccf As System.Windows.Forms.TextBox
    Friend WithEvents rb_cc1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtncci As System.Windows.Forms.TextBox
    Friend WithEvents rb_cc2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtcci As System.Windows.Forms.TextBox
End Class
