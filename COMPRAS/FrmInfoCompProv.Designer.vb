<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoCompProv
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chcli = New System.Windows.Forms.CheckBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha2 = New System.Windows.Forms.DateTimePicker
        Me.fecha1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.e5 = New System.Windows.Forms.RadioButton
        Me.e4 = New System.Windows.Forms.RadioButton
        Me.e3 = New System.Windows.Forms.RadioButton
        Me.e2 = New System.Windows.Forms.RadioButton
        Me.e1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txttipo = New System.Windows.Forms.ComboBox
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.doc2 = New System.Windows.Forms.RadioButton
        Me.doc1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chcli)
        Me.GroupBox3.Controls.Add(Me.txtcliente)
        Me.GroupBox3.Controls.Add(Me.txtnitc)
        Me.GroupBox3.Controls.Add(Me.c2)
        Me.GroupBox3.Controls.Add(Me.c1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(460, 94)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informe Para"
        '
        'chcli
        '
        Me.chcli.AutoSize = True
        Me.chcli.Location = New System.Drawing.Point(148, 44)
        Me.chcli.Name = "chcli"
        Me.chcli.Size = New System.Drawing.Size(152, 17)
        Me.chcli.TabIndex = 3
        Me.chcli.Text = "Buscar Cliente por Apellido"
        Me.chcli.UseVisualStyleBackColor = True
        Me.chcli.Visible = False
        '
        'txtcliente
        '
        Me.txtcliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtcliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(148, 67)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(306, 20)
        Me.txtcliente.TabIndex = 4
        '
        'txtnitc
        '
        Me.txtnitc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnitc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnitc.Enabled = False
        Me.txtnitc.Location = New System.Drawing.Point(32, 67)
        Me.txtnitc.MaxLength = 20
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.Size = New System.Drawing.Size(111, 20)
        Me.txtnitc.TabIndex = 4
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(16, 48)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(91, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "&Un Proveedor"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(15, 25)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(134, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos los Proveedores"
        Me.c1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fecha2)
        Me.GroupBox1.Controls.Add(Me.fecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(217, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 135)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial"
        '
        'fecha2
        '
        Me.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha2.Location = New System.Drawing.Point(90, 63)
        Me.fecha2.Name = "fecha2"
        Me.fecha2.Size = New System.Drawing.Size(78, 20)
        Me.fecha2.TabIndex = 1
        '
        'fecha1
        '
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha1.Location = New System.Drawing.Point(88, 30)
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(78, 20)
        Me.fecha1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.e5)
        Me.GroupBox2.Controls.Add(Me.e4)
        Me.GroupBox2.Controls.Add(Me.e3)
        Me.GroupBox2.Controls.Add(Me.e2)
        Me.GroupBox2.Controls.Add(Me.e1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(204, 135)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos con Estado"
        '
        'e5
        '
        Me.e5.AutoSize = True
        Me.e5.Location = New System.Drawing.Point(16, 22)
        Me.e5.Name = "e5"
        Me.e5.Size = New System.Drawing.Size(127, 17)
        Me.e5.TabIndex = 1
        Me.e5.Text = "&Aprobados Sin Anular"
        Me.e5.UseVisualStyleBackColor = True
        '
        'e4
        '
        Me.e4.AutoSize = True
        Me.e4.Checked = True
        Me.e4.Location = New System.Drawing.Point(17, 106)
        Me.e4.Name = "e4"
        Me.e4.Size = New System.Drawing.Size(55, 17)
        Me.e4.TabIndex = 4
        Me.e4.TabStop = True
        Me.e4.Text = "&Todos"
        Me.e4.UseVisualStyleBackColor = True
        '
        'e3
        '
        Me.e3.AutoSize = True
        Me.e3.Location = New System.Drawing.Point(16, 87)
        Me.e3.Name = "e3"
        Me.e3.Size = New System.Drawing.Size(69, 17)
        Me.e3.TabIndex = 3
        Me.e3.Text = "Anul&ados"
        Me.e3.UseVisualStyleBackColor = True
        '
        'e2
        '
        Me.e2.AutoSize = True
        Me.e2.Location = New System.Drawing.Point(16, 64)
        Me.e2.Name = "e2"
        Me.e2.Size = New System.Drawing.Size(78, 17)
        Me.e2.TabIndex = 2
        Me.e2.Text = "&Pendientes"
        Me.e2.UseVisualStyleBackColor = True
        '
        'e1
        '
        Me.e1.AutoSize = True
        Me.e1.Location = New System.Drawing.Point(16, 41)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(76, 17)
        Me.e1.TabIndex = 0
        Me.e1.Text = "&Aprobados"
        Me.e1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 334)
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
        Me.GroupPanel1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(39, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(212, 17)
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
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(147, 17)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 14
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txttipo)
        Me.GroupBox4.Controls.Add(Me.txttipo2)
        Me.GroupBox4.Controls.Add(Me.doc2)
        Me.GroupBox4.Controls.Add(Me.doc1)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 107)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(460, 75)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Documento de"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txttipo.FormattingEnabled = True
        Me.txttipo.Location = New System.Drawing.Point(127, 47)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(58, 21)
        Me.txttipo.TabIndex = 10
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(190, 48)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(264, 20)
        Me.txttipo2.TabIndex = 11
        '
        'doc2
        '
        Me.doc2.AutoSize = True
        Me.doc2.Location = New System.Drawing.Point(16, 48)
        Me.doc2.Name = "doc2"
        Me.doc2.Size = New System.Drawing.Size(97, 17)
        Me.doc2.TabIndex = 2
        Me.doc2.Text = "&Un Documento"
        Me.doc2.UseVisualStyleBackColor = True
        '
        'doc1
        '
        Me.doc1.AutoSize = True
        Me.doc1.Checked = True
        Me.doc1.Location = New System.Drawing.Point(15, 25)
        Me.doc1.Name = "doc1"
        Me.doc1.Size = New System.Drawing.Size(134, 17)
        Me.doc1.TabIndex = 1
        Me.doc1.TabStop = True
        Me.doc1.Text = "&Todos los Documentos"
        Me.doc1.UseVisualStyleBackColor = True
        '
        'FrmInfoCompProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(472, 423)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoCompProv"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Informe de Compras por Proveedor"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents e4 As System.Windows.Forms.RadioButton
    Friend WithEvents e3 As System.Windows.Forms.RadioButton
    Friend WithEvents e2 As System.Windows.Forms.RadioButton
    Friend WithEvents e1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents doc2 As System.Windows.Forms.RadioButton
    Friend WithEvents doc1 As System.Windows.Forms.RadioButton
    Friend WithEvents txttipo As System.Windows.Forms.ComboBox
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents e5 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chcli As System.Windows.Forms.CheckBox
End Class
