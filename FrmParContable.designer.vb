<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParContable
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gncc = New System.Windows.Forms.GroupBox
        Me.txtnc4 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtnc2 = New System.Windows.Forms.ComboBox
        Me.txtnc1 = New System.Windows.Forms.ComboBox
        Me.txtnivcc = New System.Windows.Forms.ComboBox
        Me.txtnc3 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtniv5 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtlongitudcod = New System.Windows.Forms.ComboBox
        Me.txtniv1 = New System.Windows.Forms.ComboBox
        Me.txtniv2 = New System.Windows.Forms.ComboBox
        Me.txtniv3 = New System.Windows.Forms.ComboBox
        Me.txtniv4 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtnivcue = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rb_si = New System.Windows.Forms.RadioButton
        Me.rb_no = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdRegistrarCambios = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCtaDiferencia = New System.Windows.Forms.TextBox
        Me.txtCtaPerdida = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gncc.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.gncc)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(605, 362)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCtaPerdida)
        Me.GroupBox1.Controls.Add(Me.txtCtaDiferencia)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 276)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(563, 81)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuentas de Balance"
        '
        'gncc
        '
        Me.gncc.Controls.Add(Me.txtnc4)
        Me.gncc.Controls.Add(Me.Label14)
        Me.gncc.Controls.Add(Me.Label15)
        Me.gncc.Controls.Add(Me.Label12)
        Me.gncc.Controls.Add(Me.Label13)
        Me.gncc.Controls.Add(Me.txtnc2)
        Me.gncc.Controls.Add(Me.txtnc1)
        Me.gncc.Controls.Add(Me.txtnivcc)
        Me.gncc.Controls.Add(Me.txtnc3)
        Me.gncc.Controls.Add(Me.Label11)
        Me.gncc.Location = New System.Drawing.Point(25, 159)
        Me.gncc.Name = "gncc"
        Me.gncc.Size = New System.Drawing.Size(562, 86)
        Me.gncc.TabIndex = 9
        Me.gncc.TabStop = False
        Me.gncc.Text = "Niveles Centro de Costo"
        '
        'txtnc4
        '
        Me.txtnc4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnc4.FormattingEnabled = True
        Me.txtnc4.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.txtnc4.Location = New System.Drawing.Point(459, 47)
        Me.txtnc4.Name = "txtnc4"
        Me.txtnc4.Size = New System.Drawing.Size(35, 21)
        Me.txtnc4.Sorted = True
        Me.txtnc4.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(291, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 15)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Tipo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(393, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 76
        Me.Label15.Text = "Centro"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(62, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 15)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "Grupo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(166, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 15)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "SubGrupo"
        '
        'txtnc2
        '
        Me.txtnc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnc2.FormattingEnabled = True
        Me.txtnc2.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.txtnc2.Location = New System.Drawing.Point(243, 51)
        Me.txtnc2.Name = "txtnc2"
        Me.txtnc2.Size = New System.Drawing.Size(35, 21)
        Me.txtnc2.Sorted = True
        Me.txtnc2.TabIndex = 12
        '
        'txtnc1
        '
        Me.txtnc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnc1.FormattingEnabled = True
        Me.txtnc1.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.txtnc1.Location = New System.Drawing.Point(114, 52)
        Me.txtnc1.Name = "txtnc1"
        Me.txtnc1.Size = New System.Drawing.Size(35, 21)
        Me.txtnc1.Sorted = True
        Me.txtnc1.TabIndex = 11
        '
        'txtnivcc
        '
        Me.txtnivcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnivcc.FormattingEnabled = True
        Me.txtnivcc.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.txtnivcc.Location = New System.Drawing.Point(277, 19)
        Me.txtnivcc.Name = "txtnivcc"
        Me.txtnivcc.Size = New System.Drawing.Size(35, 21)
        Me.txtnivcc.Sorted = True
        Me.txtnivcc.TabIndex = 10
        '
        'txtnc3
        '
        Me.txtnc3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnc3.FormattingEnabled = True
        Me.txtnc3.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10"})
        Me.txtnc3.Location = New System.Drawing.Point(329, 51)
        Me.txtnc3.Name = "txtnc3"
        Me.txtnc3.Size = New System.Drawing.Size(35, 21)
        Me.txtnc3.Sorted = True
        Me.txtnc3.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(86, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(180, 15)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Niveles de Centro de Costo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(4, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(347, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "* Una vez se hallan creado cuentas, no se pueden modificar los niveles."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtniv5)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtlongitudcod)
        Me.GroupBox4.Controls.Add(Me.txtniv1)
        Me.GroupBox4.Controls.Add(Me.txtniv2)
        Me.GroupBox4.Controls.Add(Me.txtniv3)
        Me.GroupBox4.Controls.Add(Me.txtniv4)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtnivcue)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(563, 103)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        '
        'txtniv5
        '
        Me.txtniv5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtniv5.FormattingEnabled = True
        Me.txtniv5.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.txtniv5.Location = New System.Drawing.Point(501, 72)
        Me.txtniv5.Name = "txtniv5"
        Me.txtniv5.Size = New System.Drawing.Size(35, 21)
        Me.txtniv5.Sorted = True
        Me.txtniv5.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(440, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Auxiliar"
        '
        'txtlongitudcod
        '
        Me.txtlongitudcod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtlongitudcod.FormattingEnabled = True
        Me.txtlongitudcod.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "11", "12"})
        Me.txtlongitudcod.Location = New System.Drawing.Point(266, 12)
        Me.txtlongitudcod.Name = "txtlongitudcod"
        Me.txtlongitudcod.Size = New System.Drawing.Size(43, 21)
        Me.txtlongitudcod.TabIndex = 0
        '
        'txtniv1
        '
        Me.txtniv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtniv1.FormattingEnabled = True
        Me.txtniv1.Items.AddRange(New Object() {"1"})
        Me.txtniv1.Location = New System.Drawing.Point(58, 72)
        Me.txtniv1.Name = "txtniv1"
        Me.txtniv1.Size = New System.Drawing.Size(35, 21)
        Me.txtniv1.Sorted = True
        Me.txtniv1.TabIndex = 2
        '
        'txtniv2
        '
        Me.txtniv2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtniv2.FormattingEnabled = True
        Me.txtniv2.Items.AddRange(New Object() {"1"})
        Me.txtniv2.Location = New System.Drawing.Point(160, 72)
        Me.txtniv2.Name = "txtniv2"
        Me.txtniv2.Size = New System.Drawing.Size(35, 21)
        Me.txtniv2.Sorted = True
        Me.txtniv2.TabIndex = 3
        '
        'txtniv3
        '
        Me.txtniv3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtniv3.FormattingEnabled = True
        Me.txtniv3.Items.AddRange(New Object() {"2"})
        Me.txtniv3.Location = New System.Drawing.Point(267, 72)
        Me.txtniv3.Name = "txtniv3"
        Me.txtniv3.Size = New System.Drawing.Size(35, 21)
        Me.txtniv3.Sorted = True
        Me.txtniv3.TabIndex = 4
        '
        'txtniv4
        '
        Me.txtniv4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtniv4.FormattingEnabled = True
        Me.txtniv4.Items.AddRange(New Object() {"0", "1", "2"})
        Me.txtniv4.Location = New System.Drawing.Point(397, 72)
        Me.txtniv4.Name = "txtniv4"
        Me.txtniv4.Size = New System.Drawing.Size(35, 21)
        Me.txtniv4.Sorted = True
        Me.txtniv4.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Clase"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Grupo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(212, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Cuenta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Sub-Cuenta"
        '
        'txtnivcue
        '
        Me.txtnivcue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtnivcue.FormattingEnabled = True
        Me.txtnivcue.Items.AddRange(New Object() {"5"})
        Me.txtnivcue.Location = New System.Drawing.Point(265, 41)
        Me.txtnivcue.Name = "txtnivcue"
        Me.txtnivcue.Size = New System.Drawing.Size(35, 21)
        Me.txtnivcue.Sorted = True
        Me.txtnivcue.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Niveles de Cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(216, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "6 - 12"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Longitud del Codigo Contable"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rb_si)
        Me.GroupBox3.Controls.Add(Me.rb_no)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 116)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(563, 41)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'rb_si
        '
        Me.rb_si.AutoSize = True
        Me.rb_si.Location = New System.Drawing.Point(256, 16)
        Me.rb_si.Name = "rb_si"
        Me.rb_si.Size = New System.Drawing.Size(34, 17)
        Me.rb_si.TabIndex = 9
        Me.rb_si.TabStop = True
        Me.rb_si.Text = "Si"
        Me.rb_si.UseVisualStyleBackColor = True
        '
        'rb_no
        '
        Me.rb_no.AutoSize = True
        Me.rb_no.Checked = True
        Me.rb_no.Location = New System.Drawing.Point(296, 16)
        Me.rb_no.Name = "rb_no"
        Me.rb_no.Size = New System.Drawing.Size(39, 17)
        Me.rb_no.TabIndex = 8
        Me.rb_no.TabStop = True
        Me.rb_no.Text = "No"
        Me.rb_no.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Centros de Costos "
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.CmdSalir)
        Me.GroupPanel1.Controls.Add(Me.CmdRegistrarCambios)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 377)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(605, 85)
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
        Me.GroupPanel1.TabIndex = 71
        '
        'CmdSalir
        '
        Me.CmdSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.cparam
        Me.CmdSalir.Location = New System.Drawing.Point(299, 9)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(72, 68)
        Me.CmdSalir.TabIndex = 10
        Me.CmdSalir.Text = "&S"
        Me.CmdSalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir Alt + S")
        Me.CmdSalir.UseVisualStyleBackColor = False
        '
        'CmdRegistrarCambios
        '
        Me.CmdRegistrarCambios.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdRegistrarCambios.Image = Global.SAE.My.Resources.Resources.gparam
        Me.CmdRegistrarCambios.Location = New System.Drawing.Point(221, 8)
        Me.CmdRegistrarCambios.Name = "CmdRegistrarCambios"
        Me.CmdRegistrarCambios.Size = New System.Drawing.Size(72, 68)
        Me.CmdRegistrarCambios.TabIndex = 9
        Me.CmdRegistrarCambios.Text = "&G"
        Me.CmdRegistrarCambios.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.CmdRegistrarCambios, "Guardar Cambios Alt + G")
        Me.CmdRegistrarCambios.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(41, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(292, 15)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Cuenta para la Diferencia (Balance General)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(41, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(262, 15)
        Me.Label17.TabIndex = 75
        Me.Label17.Text = "Cuenta para la Perdida (Est. Resultado)"
        '
        'txtCtaDiferencia
        '
        Me.txtCtaDiferencia.Location = New System.Drawing.Point(339, 28)
        Me.txtCtaDiferencia.Name = "txtCtaDiferencia"
        Me.txtCtaDiferencia.Size = New System.Drawing.Size(105, 20)
        Me.txtCtaDiferencia.TabIndex = 76
        '
        'txtCtaPerdida
        '
        Me.txtCtaPerdida.Location = New System.Drawing.Point(339, 53)
        Me.txtCtaPerdida.Name = "txtCtaPerdida"
        Me.txtCtaPerdida.Size = New System.Drawing.Size(105, 20)
        Me.txtCtaPerdida.TabIndex = 77
        '
        'FrmParContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(620, 468)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParContable"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Niveles de Cuenta y Centros de Costo"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gncc.ResumeLayout(False)
        Me.gncc.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdRegistrarCambios As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_no As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtniv1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtniv2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtniv3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtniv4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnivcue As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtlongitudcod As System.Windows.Forms.ComboBox
    Friend WithEvents txtniv5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rb_si As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gncc As System.Windows.Forms.GroupBox
    Friend WithEvents txtnivcc As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtnc3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtnc1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtnc2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtnc4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCtaPerdida As System.Windows.Forms.TextBox
    Friend WithEvents txtCtaDiferencia As System.Windows.Forms.TextBox
End Class
