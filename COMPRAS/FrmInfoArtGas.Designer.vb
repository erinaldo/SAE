<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoArtGas
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtnomgas = New System.Windows.Forms.TextBox
        Me.txtnomart = New System.Windows.Forms.TextBox
        Me.txtgas = New System.Windows.Forms.TextBox
        Me.txtart = New System.Windows.Forms.TextBox
        Me.rb5 = New System.Windows.Forms.RadioButton
        Me.rb4 = New System.Windows.Forms.RadioButton
        Me.rb3 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha2 = New System.Windows.Forms.DateTimePicker
        Me.fecha1 = New System.Windows.Forms.DateTimePicker
        Me.chcli = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtnomgas)
        Me.GroupBox2.Controls.Add(Me.txtnomart)
        Me.GroupBox2.Controls.Add(Me.txtgas)
        Me.GroupBox2.Controls.Add(Me.txtart)
        Me.GroupBox2.Controls.Add(Me.rb5)
        Me.GroupBox2.Controls.Add(Me.rb4)
        Me.GroupBox2.Controls.Add(Me.rb3)
        Me.GroupBox2.Controls.Add(Me.rb2)
        Me.GroupBox2.Controls.Add(Me.rb1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 145)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte para"
        '
        'txtnomgas
        '
        Me.txtnomgas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomgas.Enabled = False
        Me.txtnomgas.Location = New System.Drawing.Point(273, 114)
        Me.txtnomgas.Name = "txtnomgas"
        Me.txtnomgas.ReadOnly = True
        Me.txtnomgas.Size = New System.Drawing.Size(264, 20)
        Me.txtnomgas.TabIndex = 59
        '
        'txtnomart
        '
        Me.txtnomart.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomart.Enabled = False
        Me.txtnomart.Location = New System.Drawing.Point(273, 88)
        Me.txtnomart.Name = "txtnomart"
        Me.txtnomart.ReadOnly = True
        Me.txtnomart.Size = New System.Drawing.Size(264, 20)
        Me.txtnomart.TabIndex = 58
        '
        'txtgas
        '
        Me.txtgas.Enabled = False
        Me.txtgas.Location = New System.Drawing.Point(167, 114)
        Me.txtgas.Name = "txtgas"
        Me.txtgas.Size = New System.Drawing.Size(100, 20)
        Me.txtgas.TabIndex = 7
        '
        'txtart
        '
        Me.txtart.Enabled = False
        Me.txtart.Location = New System.Drawing.Point(167, 88)
        Me.txtart.Name = "txtart"
        Me.txtart.Size = New System.Drawing.Size(100, 20)
        Me.txtart.TabIndex = 6
        '
        'rb5
        '
        Me.rb5.AutoSize = True
        Me.rb5.Location = New System.Drawing.Point(13, 114)
        Me.rb5.Name = "rb5"
        Me.rb5.Size = New System.Drawing.Size(126, 17)
        Me.rb5.TabIndex = 5
        Me.rb5.Text = "&5 Un Grupo de Gasto"
        Me.rb5.UseVisualStyleBackColor = True
        '
        'rb4
        '
        Me.rb4.AutoSize = True
        Me.rb4.Location = New System.Drawing.Point(13, 91)
        Me.rb4.Name = "rb4"
        Me.rb4.Size = New System.Drawing.Size(86, 17)
        Me.rb4.TabIndex = 4
        Me.rb4.Text = "&4 Un Articulo"
        Me.rb4.UseVisualStyleBackColor = True
        '
        'rb3
        '
        Me.rb3.AutoSize = True
        Me.rb3.Location = New System.Drawing.Point(13, 68)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(168, 17)
        Me.rb3.TabIndex = 3
        Me.rb3.Text = "&3 Todos los Grupos de Gastos"
        Me.rb3.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(13, 45)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(123, 17)
        Me.rb2.TabIndex = 2
        Me.rb2.Text = "&2 Todos los Articulos"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(12, 22)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(103, 17)
        Me.rb1.TabIndex = 1
        Me.rb1.TabStop = True
        Me.rb1.Text = "&1 Todo los Items"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chcli)
        Me.GroupBox3.Controls.Add(Me.txtcliente)
        Me.GroupBox3.Controls.Add(Me.txtnitc)
        Me.GroupBox3.Controls.Add(Me.c2)
        Me.GroupBox3.Controls.Add(Me.c1)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(544, 98)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informe Para"
        '
        'txtcliente
        '
        Me.txtcliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtcliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(146, 70)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(306, 20)
        Me.txtcliente.TabIndex = 4
        '
        'txtnitc
        '
        Me.txtnitc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnitc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnitc.Enabled = False
        Me.txtnitc.Location = New System.Drawing.Point(30, 70)
        Me.txtnitc.MaxLength = 20
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.Size = New System.Drawing.Size(111, 20)
        Me.txtnitc.TabIndex = 4
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(13, 48)
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
        Me.c1.Location = New System.Drawing.Point(12, 25)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(134, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos los Proveedores"
        Me.c1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 323)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(544, 85)
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
        Me.GroupPanel1.TabIndex = 12
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(43, 25)
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
        Me.cmdsalir.Location = New System.Drawing.Point(270, 12)
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
        Me.cmdpantalla.Location = New System.Drawing.Point(205, 12)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 14
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fecha2)
        Me.GroupBox1.Controls.Add(Me.fecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 257)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 60)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial"
        '
        'fecha2
        '
        Me.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha2.Location = New System.Drawing.Point(245, 29)
        Me.fecha2.Name = "fecha2"
        Me.fecha2.Size = New System.Drawing.Size(78, 20)
        Me.fecha2.TabIndex = 1
        Me.fecha2.Value = New Date(2011, 9, 9, 0, 0, 0, 0)
        '
        'fecha1
        '
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha1.Location = New System.Drawing.Point(79, 30)
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(78, 20)
        Me.fecha1.TabIndex = 0
        Me.fecha1.Value = New Date(2011, 9, 9, 0, 0, 0, 0)
        '
        'chcli
        '
        Me.chcli.AutoSize = True
        Me.chcli.Location = New System.Drawing.Point(146, 47)
        Me.chcli.Name = "chcli"
        Me.chcli.Size = New System.Drawing.Size(152, 17)
        Me.chcli.TabIndex = 3
        Me.chcli.Text = "Buscar Cliente por Apellido"
        Me.chcli.UseVisualStyleBackColor = True
        Me.chcli.Visible = False
        '
        'FrmInfoArtGas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(552, 411)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoArtGas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Informe de Compras a Proveedores por Articulo / Grupo de Gastos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtnomgas As System.Windows.Forms.TextBox
    Friend WithEvents txtnomart As System.Windows.Forms.TextBox
    Friend WithEvents txtgas As System.Windows.Forms.TextBox
    Friend WithEvents txtart As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chcli As System.Windows.Forms.CheckBox
End Class
