<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpFacturas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtdocfin = New System.Windows.Forms.TextBox
        Me.txtdocini = New System.Windows.Forms.TextBox
        Me.rbdoc2 = New System.Windows.Forms.RadioButton
        Me.rbdoc1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtpe2 = New System.Windows.Forms.TextBox
        Me.txtpe1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtfechafin = New System.Windows.Forms.TextBox
        Me.txtfechaini = New System.Windows.Forms.TextBox
        Me.rbfecha2 = New System.Windows.Forms.RadioButton
        Me.rbfecha1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txttipo = New System.Windows.Forms.ComboBox
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbdocumentos = New System.Windows.Forms.ComboBox
        Me.cbde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 306)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtdocfin)
        Me.GroupBox5.Controls.Add(Me.txtdocini)
        Me.GroupBox5.Controls.Add(Me.rbdoc2)
        Me.GroupBox5.Controls.Add(Me.rbdoc1)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 132)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(487, 88)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(327, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Final"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(168, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Inicial"
        '
        'txtdocfin
        '
        Me.txtdocfin.Enabled = False
        Me.txtdocfin.Location = New System.Drawing.Point(368, 41)
        Me.txtdocfin.Name = "txtdocfin"
        Me.txtdocfin.Size = New System.Drawing.Size(102, 20)
        Me.txtdocfin.TabIndex = 3
        '
        'txtdocini
        '
        Me.txtdocini.Enabled = False
        Me.txtdocini.Location = New System.Drawing.Point(217, 41)
        Me.txtdocini.Name = "txtdocini"
        Me.txtdocini.Size = New System.Drawing.Size(102, 20)
        Me.txtdocini.TabIndex = 2
        '
        'rbdoc2
        '
        Me.rbdoc2.AutoSize = True
        Me.rbdoc2.Location = New System.Drawing.Point(25, 44)
        Me.rbdoc2.Name = "rbdoc2"
        Me.rbdoc2.Size = New System.Drawing.Size(137, 17)
        Me.rbdoc2.TabIndex = 1
        Me.rbdoc2.Text = "&Rango De Documentos"
        Me.rbdoc2.UseVisualStyleBackColor = True
        '
        'rbdoc1
        '
        Me.rbdoc1.AutoSize = True
        Me.rbdoc1.Checked = True
        Me.rbdoc1.Location = New System.Drawing.Point(25, 19)
        Me.rbdoc1.Name = "rbdoc1"
        Me.rbdoc1.Size = New System.Drawing.Size(138, 17)
        Me.rbdoc1.TabIndex = 0
        Me.rbdoc1.TabStop = True
        Me.rbdoc1.Text = "&Todos Los Documentos"
        Me.rbdoc1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtpe2)
        Me.GroupBox4.Controls.Add(Me.txtpe1)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtfechafin)
        Me.GroupBox4.Controls.Add(Me.txtfechaini)
        Me.GroupBox4.Controls.Add(Me.rbfecha2)
        Me.GroupBox4.Controls.Add(Me.rbfecha1)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(487, 76)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        '
        'txtpe2
        '
        Me.txtpe2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtpe2.Enabled = False
        Me.txtpe2.Location = New System.Drawing.Point(394, 39)
        Me.txtpe2.Name = "txtpe2"
        Me.txtpe2.ReadOnly = True
        Me.txtpe2.Size = New System.Drawing.Size(54, 20)
        Me.txtpe2.TabIndex = 61
        Me.txtpe2.Text = "/00/0000"
        '
        'txtpe1
        '
        Me.txtpe1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtpe1.Enabled = False
        Me.txtpe1.Location = New System.Drawing.Point(251, 39)
        Me.txtpe1.Name = "txtpe1"
        Me.txtpe1.ReadOnly = True
        Me.txtpe1.Size = New System.Drawing.Size(54, 20)
        Me.txtpe1.TabIndex = 60
        Me.txtpe1.Text = "/00/0000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(323, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Final"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(164, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Inicial"
        '
        'txtfechafin
        '
        Me.txtfechafin.Enabled = False
        Me.txtfechafin.Location = New System.Drawing.Point(364, 39)
        Me.txtfechafin.MaxLength = 2
        Me.txtfechafin.Name = "txtfechafin"
        Me.txtfechafin.Size = New System.Drawing.Size(30, 20)
        Me.txtfechafin.TabIndex = 57
        Me.txtfechafin.Text = "01"
        '
        'txtfechaini
        '
        Me.txtfechaini.Enabled = False
        Me.txtfechaini.Location = New System.Drawing.Point(217, 39)
        Me.txtfechaini.MaxLength = 2
        Me.txtfechaini.Name = "txtfechaini"
        Me.txtfechaini.Size = New System.Drawing.Size(34, 20)
        Me.txtfechaini.TabIndex = 56
        Me.txtfechaini.Text = "01"
        '
        'rbfecha2
        '
        Me.rbfecha2.AutoSize = True
        Me.rbfecha2.Location = New System.Drawing.Point(21, 42)
        Me.rbfecha2.Name = "rbfecha2"
        Me.rbfecha2.Size = New System.Drawing.Size(107, 17)
        Me.rbfecha2.TabIndex = 55
        Me.rbfecha2.Text = "&Rango De Fecha"
        Me.rbfecha2.UseVisualStyleBackColor = True
        '
        'rbfecha1
        '
        Me.rbfecha1.AutoSize = True
        Me.rbfecha1.Checked = True
        Me.rbfecha1.Location = New System.Drawing.Point(21, 17)
        Me.rbfecha1.Name = "rbfecha1"
        Me.rbfecha1.Size = New System.Drawing.Size(113, 17)
        Me.rbfecha1.TabIndex = 54
        Me.rbfecha1.TabStop = True
        Me.rbfecha1.Text = "&Todas Las Fechas"
        Me.rbfecha1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txttipo)
        Me.GroupBox3.Controls.Add(Me.txttipo2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(487, 55)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txttipo.FormattingEnabled = True
        Me.txttipo.Location = New System.Drawing.Point(119, 17)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(58, 21)
        Me.txttipo.TabIndex = 3
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(183, 18)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(289, 20)
        Me.txttipo2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tipo De Documento"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbdocumentos)
        Me.GroupBox2.Controls.Add(Me.cbde)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(487, 53)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'cbdocumentos
        '
        Me.cbdocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdocumentos.FormattingEnabled = True
        Me.cbdocumentos.Items.AddRange(New Object() {"Aprobados", "Pendientes", "Anulados", "Todos"})
        Me.cbdocumentos.Location = New System.Drawing.Point(111, 17)
        Me.cbdocumentos.Name = "cbdocumentos"
        Me.cbdocumentos.Size = New System.Drawing.Size(96, 21)
        Me.cbdocumentos.TabIndex = 10
        '
        'cbde
        '
        Me.cbde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbde.FormattingEnabled = True
        Me.cbde.Items.AddRange(New Object() {"Inventarios", "Servicios y Otros Items", "Ambos"})
        Me.cbde.Location = New System.Drawing.Point(338, 17)
        Me.cbde.Name = "cbde"
        Me.cbde.Size = New System.Drawing.Size(140, 21)
        Me.cbde.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Imprimir Documentos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Imprimir Documentos de"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Button2)
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.Button1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(2, 311)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(507, 85)
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
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(368, 42)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "fac 1"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(45, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(368, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(247, 13)
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
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(186, 13)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'FrmImpFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(514, 403)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpFacturas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Impresión Documentos de Facturación"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txttipo As System.Windows.Forms.ComboBox
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbdocumentos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdocfin As System.Windows.Forms.TextBox
    Friend WithEvents txtdocini As System.Windows.Forms.TextBox
    Friend WithEvents rbdoc2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbdoc1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbfecha2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbfecha1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtpe2 As System.Windows.Forms.TextBox
    Friend WithEvents txtpe1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtfechafin As System.Windows.Forms.TextBox
    Friend WithEvents txtfechaini As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
