<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalanceGral
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
        Me.lbform = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.pdf = New System.Windows.Forms.Button
        Me.cmdGrafica = New System.Windows.Forms.Button
        Me.cmdactualizar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkMostrarDif = New System.Windows.Forms.CheckBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.frf = New System.Windows.Forms.CheckBox
        Me.frl = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.fcon = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ini = New System.Windows.Forms.ComboBox
        Me.txtano = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.pdf)
        Me.GroupPanel1.Controls.Add(Me.cmdGrafica)
        Me.GroupPanel1.Controls.Add(Me.cmdactualizar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 235)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(516, 85)
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
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(5, 8)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(39, 13)
        Me.lbform.TabIndex = 7
        Me.lbform.Text = "Label3"
        Me.lbform.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(449, 53)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(43, 20)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Visible = False
        '
        'pdf
        '
        Me.pdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pdf.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.pdf.Location = New System.Drawing.Point(127, 7)
        Me.pdf.Name = "pdf"
        Me.pdf.Size = New System.Drawing.Size(65, 65)
        Me.pdf.TabIndex = 5
        Me.pdf.UseVisualStyleBackColor = False
        '
        'cmdGrafica
        '
        Me.cmdGrafica.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdGrafica.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdGrafica.Image = Global.SAE.My.Resources.Resources.gbarra
        Me.cmdGrafica.Location = New System.Drawing.Point(39, 6)
        Me.cmdGrafica.Name = "cmdGrafica"
        Me.cmdGrafica.Size = New System.Drawing.Size(65, 66)
        Me.cmdGrafica.TabIndex = 4
        Me.cmdGrafica.Text = "&G"
        Me.cmdGrafica.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdGrafica, "Generar Gráfica Alt + G")
        Me.cmdGrafica.UseVisualStyleBackColor = False
        Me.cmdGrafica.Visible = False
        '
        'cmdactualizar
        '
        Me.cmdactualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdactualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdactualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdactualizar.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdactualizar.Location = New System.Drawing.Point(223, 6)
        Me.cmdactualizar.Name = "cmdactualizar"
        Me.cmdactualizar.Size = New System.Drawing.Size(65, 66)
        Me.cmdactualizar.TabIndex = 2
        Me.cmdactualizar.Text = "&A"
        Me.cmdactualizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdactualizar, "Actualizar Catalogo de Cuentas Alt + A")
        Me.cmdactualizar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(290, 6)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(65, 66)
        Me.cmdsalir.TabIndex = 3
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(156, 6)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(65, 66)
        Me.cmdpantalla.TabIndex = 1
        Me.cmdpantalla.Text = "&G"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Generar Balance Atl + G")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.mibarra)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 223)
        Me.GroupBox1.TabIndex = 73
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkMostrarDif)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 178)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(476, 37)
        Me.GroupBox5.TabIndex = 63
        Me.GroupBox5.TabStop = False
        '
        'chkMostrarDif
        '
        Me.chkMostrarDif.AutoSize = True
        Me.chkMostrarDif.Checked = True
        Me.chkMostrarDif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarDif.Location = New System.Drawing.Point(20, 14)
        Me.chkMostrarDif.Name = "chkMostrarDif"
        Me.chkMostrarDif.Size = New System.Drawing.Size(186, 17)
        Me.chkMostrarDif.TabIndex = 63
        Me.chkMostrarDif.Text = "Mostrar Diferencia en el Resumen"
        Me.chkMostrarDif.UseVisualStyleBackColor = True
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(156, 100)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 62
        Me.ToolTip1.SetToolTip(Me.mibarra, "Por Favor Espere...")
        Me.mibarra.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.frf)
        Me.GroupBox4.Controls.Add(Me.frl)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.fcon)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 114)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 62)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'frf
        '
        Me.frf.AutoSize = True
        Me.frf.Location = New System.Drawing.Point(162, 34)
        Me.frf.Name = "frf"
        Me.frf.Size = New System.Drawing.Size(92, 17)
        Me.frf.TabIndex = 58
        Me.frf.Text = "Revisor Fiscal"
        Me.frf.UseVisualStyleBackColor = True
        '
        'frl
        '
        Me.frl.AutoSize = True
        Me.frl.Checked = True
        Me.frl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.frl.Location = New System.Drawing.Point(323, 34)
        Me.frl.Name = "frl"
        Me.frl.Size = New System.Drawing.Size(125, 17)
        Me.frl.TabIndex = 57
        Me.frl.Text = "Representante Legal"
        Me.frl.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 15)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Firmas Del Balance"
        '
        'fcon
        '
        Me.fcon.AutoSize = True
        Me.fcon.Checked = True
        Me.fcon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.fcon.Location = New System.Drawing.Point(20, 34)
        Me.fcon.Name = "fcon"
        Me.fcon.Size = New System.Drawing.Size(69, 17)
        Me.fcon.TabIndex = 55
        Me.fcon.Text = "Contador"
        Me.fcon.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.nivel)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 61)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 51)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 15)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Nivel De Cuentas Para El Balance"
        '
        'nivel
        '
        Me.nivel.Location = New System.Drawing.Point(271, 19)
        Me.nivel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nivel.Name = "nivel"
        Me.nivel.Size = New System.Drawing.Size(29, 20)
        Me.nivel.TabIndex = 4
        Me.nivel.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ini)
        Me.GroupBox2.Controls.Add(Me.txtano)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 49)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ini
        '
        Me.ini.DisplayMember = "01"
        Me.ini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ini.FormattingEnabled = True
        Me.ini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.ini.Location = New System.Drawing.Point(238, 15)
        Me.ini.MaxLength = 2
        Me.ini.Name = "ini"
        Me.ini.Size = New System.Drawing.Size(43, 21)
        Me.ini.TabIndex = 2
        Me.ini.ValueMember = "01"
        '
        'txtano
        '
        Me.txtano.Location = New System.Drawing.Point(283, 16)
        Me.txtano.Name = "txtano"
        Me.txtano.ReadOnly = True
        Me.txtano.Size = New System.Drawing.Size(40, 20)
        Me.txtano.TabIndex = 45
        Me.txtano.Text = "/0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Periodo a generar en el balance"
        '
        'FrmBalanceGral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(524, 328)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBalanceGral"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Balance General"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdactualizar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtano As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
    Friend WithEvents ini As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents frl As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fcon As System.Windows.Forms.CheckBox
    Friend WithEvents frf As System.Windows.Forms.CheckBox
    Friend WithEvents cmdGrafica As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents pdf As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkMostrarDif As System.Windows.Forms.CheckBox
End Class
