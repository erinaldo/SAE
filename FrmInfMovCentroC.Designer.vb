<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfMovCentroC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfMovCentroC))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcheque = New System.Windows.Forms.TextBox
        Me.ch2 = New System.Windows.Forms.RadioButton
        Me.ch1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.fecha2 = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha1 = New System.Windows.Forms.DateTimePicker
        Me.gcuenta = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.gnit = New System.Windows.Forms.GroupBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.n2 = New System.Windows.Forms.RadioButton
        Me.n1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.chGrupo = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gcuenta.SuspendLayout()
        Me.gnit.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcheque)
        Me.GroupBox1.Controls.Add(Me.ch2)
        Me.GroupBox1.Controls.Add(Me.ch1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 60)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'txtcheque
        '
        Me.txtcheque.Enabled = False
        Me.txtcheque.Location = New System.Drawing.Point(139, 28)
        Me.txtcheque.Name = "txtcheque"
        Me.txtcheque.Size = New System.Drawing.Size(180, 20)
        Me.txtcheque.TabIndex = 51
        '
        'ch2
        '
        Me.ch2.AutoSize = True
        Me.ch2.Location = New System.Drawing.Point(15, 31)
        Me.ch2.Name = "ch2"
        Me.ch2.Size = New System.Drawing.Size(118, 17)
        Me.ch2.TabIndex = 2
        Me.ch2.Text = "Un Centro de Costo"
        Me.ch2.UseVisualStyleBackColor = True
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.Checked = True
        Me.ch1.Location = New System.Drawing.Point(15, 11)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(154, 17)
        Me.ch1.TabIndex = 0
        Me.ch1.TabStop = True
        Me.ch1.Text = "Todos Los Centro de Costo"
        Me.ch1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.fecha2)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.fecha1)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 224)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(464, 50)
        Me.GroupBox4.TabIndex = 80
        Me.GroupBox4.TabStop = False
        '
        'fecha2
        '
        Me.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha2.Location = New System.Drawing.Point(309, 19)
        Me.fecha2.Name = "fecha2"
        Me.fecha2.Size = New System.Drawing.Size(78, 20)
        Me.fecha2.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(241, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Fecha Inicial"
        '
        'fecha1
        '
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha1.Location = New System.Drawing.Point(98, 19)
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(78, 20)
        Me.fecha1.TabIndex = 77
        '
        'gcuenta
        '
        Me.gcuenta.Controls.Add(Me.chGrupo)
        Me.gcuenta.Controls.Add(Me.Label7)
        Me.gcuenta.Controls.Add(Me.txtcuenta)
        Me.gcuenta.Controls.Add(Me.c2)
        Me.gcuenta.Controls.Add(Me.c1)
        Me.gcuenta.Location = New System.Drawing.Point(5, 64)
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.Size = New System.Drawing.Size(465, 92)
        Me.gcuenta.TabIndex = 78
        Me.gcuenta.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.IndianRed
        Me.Label7.Location = New System.Drawing.Point(297, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "* Doble clic para escoger cuentas"
        '
        'txtcuenta
        '
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Location = New System.Drawing.Point(116, 41)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(180, 20)
        Me.txtcuenta.TabIndex = 50
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(11, 41)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(78, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "Por Cuenta"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(11, 19)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(117, 17)
        Me.c1.TabIndex = 0
        Me.c1.TabStop = True
        Me.c1.Text = "Todas Las Cuentas"
        Me.c1.UseVisualStyleBackColor = True
        '
        'gnit
        '
        Me.gnit.Controls.Add(Me.txtnombre)
        Me.gnit.Controls.Add(Me.txtnit)
        Me.gnit.Controls.Add(Me.n2)
        Me.gnit.Controls.Add(Me.n1)
        Me.gnit.Location = New System.Drawing.Point(5, 162)
        Me.gnit.Name = "gnit"
        Me.gnit.Size = New System.Drawing.Size(464, 60)
        Me.gnit.TabIndex = 79
        Me.gnit.TabStop = False
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(206, 30)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(238, 20)
        Me.txtnombre.TabIndex = 52
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(98, 30)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(102, 20)
        Me.txtnit.TabIndex = 51
        '
        'n2
        '
        Me.n2.AutoSize = True
        Me.n2.Location = New System.Drawing.Point(15, 31)
        Me.n2.Name = "n2"
        Me.n2.Size = New System.Drawing.Size(77, 17)
        Me.n2.TabIndex = 2
        Me.n2.Text = "Por N. I. T."
        Me.n2.UseVisualStyleBackColor = True
        '
        'n1
        '
        Me.n1.AutoSize = True
        Me.n1.Checked = True
        Me.n1.Location = New System.Drawing.Point(15, 11)
        Me.n1.Name = "n1"
        Me.n1.Size = New System.Drawing.Size(111, 17)
        Me.n1.TabIndex = 0
        Me.n1.TabStop = True
        Me.n1.Text = "Todos Los N. I. T."
        Me.n1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.Button1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 279)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(464, 85)
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
        Me.GroupPanel1.TabIndex = 77
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 20)
        Me.TextBox1.TabIndex = 20
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.Button1.Location = New System.Drawing.Point(165, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 57)
        Me.Button1.TabIndex = 19
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(232, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 16
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'chGrupo
        '
        Me.chGrupo.AutoSize = True
        Me.chGrupo.Location = New System.Drawing.Point(13, 67)
        Me.chGrupo.Name = "chGrupo"
        Me.chGrupo.Size = New System.Drawing.Size(147, 17)
        Me.chGrupo.TabIndex = 74
        Me.chGrupo.Text = "Solo Cuentas Grupo 5 y 6"
        Me.chGrupo.UseVisualStyleBackColor = True
        '
        'FrmInfMovCentroC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(480, 368)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gcuenta)
        Me.Controls.Add(Me.gnit)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfMovCentroC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Movimientos de Centros de Costo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gcuenta.ResumeLayout(False)
        Me.gcuenta.PerformLayout()
        Me.gnit.ResumeLayout(False)
        Me.gnit.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcheque As System.Windows.Forms.TextBox
    Friend WithEvents ch2 As System.Windows.Forms.RadioButton
    Friend WithEvents ch1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents gcuenta As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents gnit As System.Windows.Forms.GroupBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents n2 As System.Windows.Forms.RadioButton
    Friend WithEvents n1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents chGrupo As System.Windows.Forms.CheckBox
End Class
