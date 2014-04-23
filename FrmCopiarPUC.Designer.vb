<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopiarPUC
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.txtComp = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtanio = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.r3 = New System.Windows.Forms.RadioButton
        Me.chPAct = New System.Windows.Forms.CheckBox
        Me.r2 = New System.Windows.Forms.RadioButton
        Me.r1 = New System.Windows.Forms.RadioButton
        Me.r4 = New System.Windows.Forms.RadioButton
        Me.r5 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1.SuspendLayout()
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
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 218)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(415, 85)
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
        Me.GroupPanel1.TabIndex = 78
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(213, 13)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.reprocesar
        Me.cmdpantalla.Location = New System.Drawing.Point(145, 13)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(62, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Campiar PUC")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'txtComp
        '
        Me.txtComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtComp.FormattingEnabled = True
        Me.txtComp.Location = New System.Drawing.Point(100, 13)
        Me.txtComp.Name = "txtComp"
        Me.txtComp.Size = New System.Drawing.Size(229, 21)
        Me.txtComp.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Compañia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtComp)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 72)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtanio.FormattingEnabled = True
        Me.txtanio.Location = New System.Drawing.Point(100, 40)
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(120, 21)
        Me.txtanio.TabIndex = 81
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.r5)
        Me.GroupBox2.Controls.Add(Me.r4)
        Me.GroupBox2.Controls.Add(Me.r3)
        Me.GroupBox2.Controls.Add(Me.chPAct)
        Me.GroupBox2.Controls.Add(Me.r2)
        Me.GroupBox2.Controls.Add(Me.r1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(415, 136)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        '
        'r3
        '
        Me.r3.AutoSize = True
        Me.r3.Location = New System.Drawing.Point(19, 65)
        Me.r3.Name = "r3"
        Me.r3.Size = New System.Drawing.Size(106, 17)
        Me.r3.TabIndex = 3
        Me.r3.TabStop = True
        Me.r3.Text = "Copiar Impuestos"
        Me.r3.UseVisualStyleBackColor = True
        '
        'chPAct
        '
        Me.chPAct.AutoSize = True
        Me.chPAct.Enabled = False
        Me.chPAct.Location = New System.Drawing.Point(156, 17)
        Me.chPAct.Name = "chPAct"
        Me.chPAct.Size = New System.Drawing.Size(124, 17)
        Me.chPAct.TabIndex = 1
        Me.chPAct.Text = "Guardar PUC  actual"
        Me.chPAct.UseVisualStyleBackColor = True
        '
        'r2
        '
        Me.r2.AutoSize = True
        Me.r2.Location = New System.Drawing.Point(19, 42)
        Me.r2.Name = "r2"
        Me.r2.Size = New System.Drawing.Size(111, 17)
        Me.r2.TabIndex = 2
        Me.r2.TabStop = True
        Me.r2.Text = "Copiar Parametros"
        Me.r2.UseVisualStyleBackColor = True
        '
        'r1
        '
        Me.r1.AutoSize = True
        Me.r1.Location = New System.Drawing.Point(19, 18)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(80, 17)
        Me.r1.TabIndex = 0
        Me.r1.TabStop = True
        Me.r1.Text = "Copiar PUC"
        Me.r1.UseVisualStyleBackColor = True
        '
        'r4
        '
        Me.r4.AutoSize = True
        Me.r4.Location = New System.Drawing.Point(19, 88)
        Me.r4.Name = "r4"
        Me.r4.Size = New System.Drawing.Size(101, 17)
        Me.r4.TabIndex = 4
        Me.r4.TabStop = True
        Me.r4.Text = "Copiar Servicios"
        Me.r4.UseVisualStyleBackColor = True
        '
        'r5
        '
        Me.r5.AutoSize = True
        Me.r5.Location = New System.Drawing.Point(19, 110)
        Me.r5.Name = "r5"
        Me.r5.Size = New System.Drawing.Size(91, 17)
        Me.r5.TabIndex = 5
        Me.r5.TabStop = True
        Me.r5.Text = "Copiar Gastos"
        Me.r5.UseVisualStyleBackColor = True
        '
        'FrmCopiarPUC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(426, 306)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCopiarPUC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copiar Datos de Otra Compañia"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txtComp As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtanio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents r3 As System.Windows.Forms.RadioButton
    Friend WithEvents r2 As System.Windows.Forms.RadioButton
    Friend WithEvents r1 As System.Windows.Forms.RadioButton
    Friend WithEvents chPAct As System.Windows.Forms.CheckBox
    Friend WithEvents r5 As System.Windows.Forms.RadioButton
    Friend WithEvents r4 As System.Windows.Forms.RadioButton
End Class
