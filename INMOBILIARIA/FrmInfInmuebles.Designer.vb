<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfInmuebles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfInmuebles))
        Me.gr2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnom = New System.Windows.Forms.TextBox
        Me.txttip = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtinm = New System.Windows.Forms.TextBox
        Me.i2 = New System.Windows.Forms.RadioButton
        Me.i1 = New System.Windows.Forms.RadioButton
        Me.gr3 = New System.Windows.Forms.GroupBox
        Me.a3 = New System.Windows.Forms.RadioButton
        Me.a2 = New System.Windows.Forms.RadioButton
        Me.a1 = New System.Windows.Forms.RadioButton
        Me.cmbesta = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtdesc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbDestino = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GrVal = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.P2 = New System.Windows.Forms.RadioButton
        Me.P1 = New System.Windows.Forms.RadioButton
        Me.r1 = New System.Windows.Forms.TextBox
        Me.r2 = New System.Windows.Forms.TextBox
        Me.v2 = New System.Windows.Forms.RadioButton
        Me.v1 = New System.Windows.Forms.RadioButton
        Me.gr2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gr3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GrVal.SuspendLayout()
        Me.SuspendLayout()
        '
        'gr2
        '
        Me.gr2.Controls.Add(Me.Label3)
        Me.gr2.Controls.Add(Me.txtnom)
        Me.gr2.Controls.Add(Me.txttip)
        Me.gr2.Controls.Add(Me.c2)
        Me.gr2.Controls.Add(Me.c1)
        Me.gr2.Location = New System.Drawing.Point(6, 78)
        Me.gr2.Name = "gr2"
        Me.gr2.Size = New System.Drawing.Size(450, 92)
        Me.gr2.TabIndex = 3
        Me.gr2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Nit"
        '
        'txtnom
        '
        Me.txtnom.Location = New System.Drawing.Point(164, 62)
        Me.txtnom.Name = "txtnom"
        Me.txtnom.ReadOnly = True
        Me.txtnom.Size = New System.Drawing.Size(274, 20)
        Me.txtnom.TabIndex = 4
        '
        'txttip
        '
        Me.txttip.BackColor = System.Drawing.Color.White
        Me.txttip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txttip.Enabled = False
        Me.txttip.Location = New System.Drawing.Point(44, 62)
        Me.txttip.MaxLength = 2
        Me.txttip.Name = "txttip"
        Me.txttip.Size = New System.Drawing.Size(111, 20)
        Me.txttip.TabIndex = 3
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(15, 36)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(92, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "&Un Propietario"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(14, 13)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(129, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos los Propietarios"
        Me.c1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 433)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(449, 81)
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
        Me.cmdsalir.Location = New System.Drawing.Point(226, 7)
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
        Me.cmdpantalla.Location = New System.Drawing.Point(161, 7)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtinm)
        Me.GroupBox1.Controls.Add(Me.i2)
        Me.GroupBox1.Controls.Add(Me.i1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(451, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inmuebles"
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
        'gr3
        '
        Me.gr3.Controls.Add(Me.a3)
        Me.gr3.Controls.Add(Me.a2)
        Me.gr3.Controls.Add(Me.a1)
        Me.gr3.Location = New System.Drawing.Point(274, 231)
        Me.gr3.Name = "gr3"
        Me.gr3.Size = New System.Drawing.Size(183, 97)
        Me.gr3.TabIndex = 2
        Me.gr3.TabStop = False
        Me.gr3.Text = "Agrupar Informe"
        '
        'a3
        '
        Me.a3.AutoSize = True
        Me.a3.Location = New System.Drawing.Point(24, 69)
        Me.a3.Name = "a3"
        Me.a3.Size = New System.Drawing.Size(77, 17)
        Me.a3.TabIndex = 3
        Me.a3.Text = "Por Ciudad"
        Me.a3.UseVisualStyleBackColor = True
        '
        'a2
        '
        Me.a2.AutoSize = True
        Me.a2.Location = New System.Drawing.Point(23, 46)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(94, 17)
        Me.a2.TabIndex = 2
        Me.a2.Text = "Por Propietario"
        Me.a2.UseVisualStyleBackColor = True
        '
        'a1
        '
        Me.a1.AutoSize = True
        Me.a1.Checked = True
        Me.a1.Location = New System.Drawing.Point(24, 23)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(76, 17)
        Me.a1.TabIndex = 1
        Me.a1.TabStop = True
        Me.a1.Text = "Por estado"
        Me.a1.UseVisualStyleBackColor = True
        '
        'cmbesta
        '
        Me.cmbesta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbesta.FormattingEnabled = True
        Me.cmbesta.Items.AddRange(New Object() {"TODOS", "DISPONIBLE", "OCUPADO"})
        Me.cmbesta.Location = New System.Drawing.Point(80, 18)
        Me.cmbesta.Name = "cmbesta"
        Me.cmbesta.Size = New System.Drawing.Size(121, 21)
        Me.cmbesta.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdesc)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbesta)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 230)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(259, 100)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(81, 51)
        Me.txtdesc.Multiline = True
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(156, 40)
        Me.txtdesc.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripcion "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estado"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbDestino)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbTipo)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 171)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(449, 56)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Items.AddRange(New Object() {"TODOS", "COMERCIAL", "MIXTO", "VIVIENDA", "OTRO"})
        Me.cmbDestino.Location = New System.Drawing.Point(317, 19)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(121, 21)
        Me.cmbDestino.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "DESTINO"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(42, 21)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "TIPO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GrVal)
        Me.GroupBox4.Controls.Add(Me.v2)
        Me.GroupBox4.Controls.Add(Me.v1)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 333)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(450, 94)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'GrVal
        '
        Me.GrVal.Controls.Add(Me.Label8)
        Me.GrVal.Controls.Add(Me.Label7)
        Me.GrVal.Controls.Add(Me.P2)
        Me.GrVal.Controls.Add(Me.P1)
        Me.GrVal.Controls.Add(Me.r1)
        Me.GrVal.Controls.Add(Me.r2)
        Me.GrVal.Location = New System.Drawing.Point(128, 10)
        Me.GrVal.Name = "GrVal"
        Me.GrVal.Size = New System.Drawing.Size(309, 75)
        Me.GrVal.TabIndex = 9
        Me.GrVal.TabStop = False
        Me.GrVal.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(164, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "a"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Desde"
        '
        'P2
        '
        Me.P2.AutoSize = True
        Me.P2.Location = New System.Drawing.Point(167, 16)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(84, 17)
        Me.P2.TabIndex = 9
        Me.P2.Text = "Precio Local"
        Me.P2.UseVisualStyleBackColor = True
        '
        'P1
        '
        Me.P1.AutoSize = True
        Me.P1.Checked = True
        Me.P1.Location = New System.Drawing.Point(12, 16)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(99, 17)
        Me.P1.TabIndex = 8
        Me.P1.TabStop = True
        Me.P1.Text = "Precio Vivienda"
        Me.P1.UseVisualStyleBackColor = True
        '
        'r1
        '
        Me.r1.BackColor = System.Drawing.Color.White
        Me.r1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.r1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.r1.Location = New System.Drawing.Point(43, 49)
        Me.r1.MaxLength = 100
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(115, 20)
        Me.r1.TabIndex = 7
        '
        'r2
        '
        Me.r2.BackColor = System.Drawing.Color.White
        Me.r2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.r2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.r2.Location = New System.Drawing.Point(182, 48)
        Me.r2.MaxLength = 100
        Me.r2.Name = "r2"
        Me.r2.Size = New System.Drawing.Size(120, 20)
        Me.r2.TabIndex = 7
        '
        'v2
        '
        Me.v2.AutoSize = True
        Me.v2.Location = New System.Drawing.Point(12, 58)
        Me.v2.Name = "v2"
        Me.v2.Size = New System.Drawing.Size(110, 17)
        Me.v2.TabIndex = 8
        Me.v2.Text = "Rango de Valores"
        Me.v2.UseVisualStyleBackColor = True
        '
        'v1
        '
        Me.v1.AutoSize = True
        Me.v1.Checked = True
        Me.v1.Location = New System.Drawing.Point(14, 23)
        Me.v1.Name = "v1"
        Me.v1.Size = New System.Drawing.Size(109, 17)
        Me.v1.TabIndex = 7
        Me.v1.TabStop = True
        Me.v1.Text = "&Todos los Valores"
        Me.v1.UseVisualStyleBackColor = True
        '
        'FrmInfInmuebles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 516)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gr3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gr2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfInmuebles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe de Inmuebles"
        Me.gr2.ResumeLayout(False)
        Me.gr2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gr3.ResumeLayout(False)
        Me.gr3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrVal.ResumeLayout(False)
        Me.GrVal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gr2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents txttip As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtinm As System.Windows.Forms.TextBox
    Friend WithEvents i2 As System.Windows.Forms.RadioButton
    Friend WithEvents i1 As System.Windows.Forms.RadioButton
    Friend WithEvents gr3 As System.Windows.Forms.GroupBox
    Friend WithEvents a3 As System.Windows.Forms.RadioButton
    Friend WithEvents a2 As System.Windows.Forms.RadioButton
    Friend WithEvents a1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmbesta As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents r2 As System.Windows.Forms.TextBox
    Friend WithEvents r1 As System.Windows.Forms.TextBox
    Friend WithEvents v2 As System.Windows.Forms.RadioButton
    Friend WithEvents v1 As System.Windows.Forms.RadioButton
    Friend WithEvents GrVal As System.Windows.Forms.GroupBox
    Friend WithEvents P2 As System.Windows.Forms.RadioButton
    Friend WithEvents P1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
