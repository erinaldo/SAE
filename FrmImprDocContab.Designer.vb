<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImprDocContab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImprDocContab))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbperiodo = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtnomdoc = New System.Windows.Forms.TextBox
        Me.cbtipo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtperiodo2 = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_fec_fin = New System.Windows.Forms.TextBox
        Me.txt_fec_ini = New System.Windows.Forms.TextBox
        Me.f2 = New System.Windows.Forms.RadioButton
        Me.f1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_doc_fin = New System.Windows.Forms.TextBox
        Me.txt_doc_ini = New System.Windows.Forms.TextBox
        Me.d2 = New System.Windows.Forms.RadioButton
        Me.d1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbperiodo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 47)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lbperiodo
        '
        Me.lbperiodo.AutoSize = True
        Me.lbperiodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbperiodo.Location = New System.Drawing.Point(228, 15)
        Me.lbperiodo.Name = "lbperiodo"
        Me.lbperiodo.Size = New System.Drawing.Size(74, 20)
        Me.lbperiodo.TabIndex = 56
        Me.lbperiodo.Text = "00/0000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 16)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Documentos del Periodo"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtnomdoc)
        Me.GroupBox5.Controls.Add(Me.cbtipo)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 54)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(422, 51)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'txtnomdoc
        '
        Me.txtnomdoc.BackColor = System.Drawing.Color.White
        Me.txtnomdoc.Enabled = False
        Me.txtnomdoc.Location = New System.Drawing.Point(202, 20)
        Me.txtnomdoc.Name = "txtnomdoc"
        Me.txtnomdoc.ReadOnly = True
        Me.txtnomdoc.Size = New System.Drawing.Size(214, 20)
        Me.txtnomdoc.TabIndex = 7
        '
        'cbtipo
        '
        Me.cbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipo.FormattingEnabled = True
        Me.cbtipo.Location = New System.Drawing.Point(153, 19)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Size = New System.Drawing.Size(43, 21)
        Me.cbtipo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Tipo de Documento"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtperiodo2)
        Me.GroupBox6.Controls.Add(Me.txtperiodo)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.txt_fec_fin)
        Me.GroupBox6.Controls.Add(Me.txt_fec_ini)
        Me.GroupBox6.Controls.Add(Me.f2)
        Me.GroupBox6.Controls.Add(Me.f1)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 196)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(423, 79)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        '
        'txtperiodo2
        '
        Me.txtperiodo2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo2.Enabled = False
        Me.txtperiodo2.Location = New System.Drawing.Point(345, 44)
        Me.txtperiodo2.Name = "txtperiodo2"
        Me.txtperiodo2.ReadOnly = True
        Me.txtperiodo2.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo2.TabIndex = 5
        Me.txtperiodo2.Text = "/00/0000"
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(189, 43)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 3
        Me.txtperiodo.Text = "/00/0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(264, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Final"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(103, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Inicial"
        '
        'txt_fec_fin
        '
        Me.txt_fec_fin.Enabled = False
        Me.txt_fec_fin.Location = New System.Drawing.Point(308, 43)
        Me.txt_fec_fin.MaxLength = 2
        Me.txt_fec_fin.Name = "txt_fec_fin"
        Me.txt_fec_fin.Size = New System.Drawing.Size(31, 20)
        Me.txt_fec_fin.TabIndex = 4
        '
        'txt_fec_ini
        '
        Me.txt_fec_ini.Enabled = False
        Me.txt_fec_ini.Location = New System.Drawing.Point(156, 42)
        Me.txt_fec_ini.MaxLength = 2
        Me.txt_fec_ini.Name = "txt_fec_ini"
        Me.txt_fec_ini.Size = New System.Drawing.Size(27, 20)
        Me.txt_fec_ini.TabIndex = 2
        Me.txt_fec_ini.Text = "01"
        '
        'f2
        '
        Me.f2.AutoSize = True
        Me.f2.Location = New System.Drawing.Point(25, 44)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(57, 17)
        Me.f2.TabIndex = 1
        Me.f2.Text = "Rango"
        Me.f2.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.AutoSize = True
        Me.f1.Checked = True
        Me.f1.Location = New System.Drawing.Point(25, 19)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(113, 17)
        Me.f1.TabIndex = 0
        Me.f1.TabStop = True
        Me.f1.Text = "Todas Las Fechas"
        Me.f1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_doc_fin)
        Me.GroupBox1.Controls.Add(Me.txt_doc_ini)
        Me.GroupBox1.Controls.Add(Me.d2)
        Me.GroupBox1.Controls.Add(Me.d1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 79)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(298, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Final"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(169, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Inicial"
        '
        'txt_doc_fin
        '
        Me.txt_doc_fin.Enabled = False
        Me.txt_doc_fin.Location = New System.Drawing.Point(346, 42)
        Me.txt_doc_fin.Name = "txt_doc_fin"
        Me.txt_doc_fin.Size = New System.Drawing.Size(64, 20)
        Me.txt_doc_fin.TabIndex = 3
        '
        'txt_doc_ini
        '
        Me.txt_doc_ini.Enabled = False
        Me.txt_doc_ini.Location = New System.Drawing.Point(224, 41)
        Me.txt_doc_ini.Name = "txt_doc_ini"
        Me.txt_doc_ini.Size = New System.Drawing.Size(68, 20)
        Me.txt_doc_ini.TabIndex = 2
        '
        'd2
        '
        Me.d2.AutoSize = True
        Me.d2.Location = New System.Drawing.Point(25, 44)
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(121, 17)
        Me.d2.TabIndex = 1
        Me.d2.Text = "Rango Por Numeros"
        Me.d2.UseVisualStyleBackColor = True
        '
        'd1
        '
        Me.d1.AutoSize = True
        Me.d1.Checked = True
        Me.d1.Location = New System.Drawing.Point(25, 19)
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(138, 17)
        Me.d1.TabIndex = 0
        Me.d1.TabStop = True
        Me.d1.Text = "Todos Los Documentos"
        Me.d1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 291)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(421, 85)
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
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(218, 3)
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
        Me.cmdpantalla.Location = New System.Drawing.Point(153, 3)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'FrmImprDocContab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(434, 383)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImprDocContab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Documentos Contabilidad"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbperiodo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtperiodo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_fec_fin As System.Windows.Forms.TextBox
    Friend WithEvents txt_fec_ini As System.Windows.Forms.TextBox
    Friend WithEvents f2 As System.Windows.Forms.RadioButton
    Friend WithEvents f1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_doc_fin As System.Windows.Forms.TextBox
    Friend WithEvents txt_doc_ini As System.Windows.Forms.TextBox
    Friend WithEvents d2 As System.Windows.Forms.RadioButton
    Friend WithEvents d1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents txtnomdoc As System.Windows.Forms.TextBox
End Class
