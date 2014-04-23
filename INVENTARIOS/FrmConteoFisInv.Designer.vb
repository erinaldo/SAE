<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConteoFisInv
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbr = New System.Windows.Forms.RadioButton
        Me.rbt = New System.Windows.Forms.RadioButton
        Me.txtn2 = New System.Windows.Forms.TextBox
        Me.txtn1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtfin = New System.Windows.Forms.TextBox
        Me.txtini = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtnombod = New System.Windows.Forms.TextBox
        Me.cbbodega = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbno = New System.Windows.Forms.RadioButton
        Me.rbsi = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rbca = New System.Windows.Forms.RadioButton
        Me.rbc = New System.Windows.Forms.RadioButton
        Me.txtctainv = New System.Windows.Forms.TextBox
        Me.txtctacos = New System.Windows.Forms.TextBox
        Me.txtnomcos = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtnominv = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdpdf = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 322)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbr)
        Me.GroupBox4.Controls.Add(Me.rbt)
        Me.GroupBox4.Controls.Add(Me.txtn2)
        Me.GroupBox4.Controls.Add(Me.txtn1)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtfin)
        Me.GroupBox4.Controls.Add(Me.txtini)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(556, 91)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'rbr
        '
        Me.rbr.AutoSize = True
        Me.rbr.Location = New System.Drawing.Point(12, 43)
        Me.rbr.Name = "rbr"
        Me.rbr.Size = New System.Drawing.Size(115, 17)
        Me.rbr.TabIndex = 1
        Me.rbr.Text = "Rango de Articulos"
        Me.rbr.UseVisualStyleBackColor = True
        '
        'rbt
        '
        Me.rbt.AutoSize = True
        Me.rbt.Checked = True
        Me.rbt.Location = New System.Drawing.Point(13, 19)
        Me.rbt.Name = "rbt"
        Me.rbt.Size = New System.Drawing.Size(114, 17)
        Me.rbt.TabIndex = 0
        Me.rbt.TabStop = True
        Me.rbt.Text = "Todos los Articulos"
        Me.rbt.UseVisualStyleBackColor = True
        '
        'txtn2
        '
        Me.txtn2.Enabled = False
        Me.txtn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtn2.Location = New System.Drawing.Point(313, 66)
        Me.txtn2.Name = "txtn2"
        Me.txtn2.Size = New System.Drawing.Size(225, 18)
        Me.txtn2.TabIndex = 5
        '
        'txtn1
        '
        Me.txtn1.Enabled = False
        Me.txtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtn1.Location = New System.Drawing.Point(313, 43)
        Me.txtn1.Name = "txtn1"
        Me.txtn1.Size = New System.Drawing.Size(225, 18)
        Me.txtn1.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Código Final"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(133, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Código Inicial"
        '
        'txtfin
        '
        Me.txtfin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfin.Location = New System.Drawing.Point(205, 65)
        Me.txtfin.Name = "txtfin"
        Me.txtfin.Size = New System.Drawing.Size(102, 20)
        Me.txtfin.TabIndex = 4
        '
        'txtini
        '
        Me.txtini.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtini.Location = New System.Drawing.Point(205, 42)
        Me.txtini.Name = "txtini"
        Me.txtini.Size = New System.Drawing.Size(102, 20)
        Me.txtini.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtperiodo)
        Me.GroupBox2.Controls.Add(Me.txtdia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtnombod)
        Me.GroupBox2.Controls.Add(Me.cbbodega)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(556, 79)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(226, 17)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 1
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(199, 17)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 0
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 15)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Fecha  de Conteo (dd/mm/aaaa)"
        '
        'txtnombod
        '
        Me.txtnombod.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnombod.Enabled = False
        Me.txtnombod.Location = New System.Drawing.Point(105, 50)
        Me.txtnombod.Name = "txtnombod"
        Me.txtnombod.ShortcutsEnabled = False
        Me.txtnombod.Size = New System.Drawing.Size(433, 20)
        Me.txtnombod.TabIndex = 3
        '
        'cbbodega
        '
        Me.cbbodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbodega.FormattingEnabled = True
        Me.cbbodega.Location = New System.Drawing.Point(59, 49)
        Me.cbbodega.Name = "cbbodega"
        Me.cbbodega.Size = New System.Drawing.Size(40, 21)
        Me.cbbodega.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Bodega"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbno)
        Me.GroupBox3.Controls.Add(Me.rbsi)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 171)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(556, 43)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'rbno
        '
        Me.rbno.AutoSize = True
        Me.rbno.Checked = True
        Me.rbno.Location = New System.Drawing.Point(474, 16)
        Me.rbno.Name = "rbno"
        Me.rbno.Size = New System.Drawing.Size(41, 17)
        Me.rbno.TabIndex = 82
        Me.rbno.TabStop = True
        Me.rbno.Text = "NO"
        Me.rbno.UseVisualStyleBackColor = True
        '
        'rbsi
        '
        Me.rbsi.AutoSize = True
        Me.rbsi.Location = New System.Drawing.Point(433, 16)
        Me.rbsi.Name = "rbsi"
        Me.rbsi.Size = New System.Drawing.Size(35, 17)
        Me.rbsi.TabIndex = 81
        Me.rbsi.Text = "SI"
        Me.rbsi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "¿Desea que el sistema realice el ajuste de inventario automaticamente?"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbca)
        Me.GroupBox5.Controls.Add(Me.rbc)
        Me.GroupBox5.Controls.Add(Me.txtctainv)
        Me.GroupBox5.Controls.Add(Me.txtctacos)
        Me.GroupBox5.Controls.Add(Me.txtnomcos)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtnominv)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 210)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(556, 100)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'rbca
        '
        Me.rbca.AutoSize = True
        Me.rbca.Checked = True
        Me.rbca.Location = New System.Drawing.Point(14, 19)
        Me.rbca.Name = "rbca"
        Me.rbca.Size = New System.Drawing.Size(171, 17)
        Me.rbca.TabIndex = 0
        Me.rbca.TabStop = True
        Me.rbca.Text = "Utilizar cuentas de los Articulos"
        Me.rbca.UseVisualStyleBackColor = True
        '
        'rbc
        '
        Me.rbc.AutoSize = True
        Me.rbc.Location = New System.Drawing.Point(13, 43)
        Me.rbc.Name = "rbc"
        Me.rbc.Size = New System.Drawing.Size(123, 17)
        Me.rbc.TabIndex = 1
        Me.rbc.Text = "Seleccionar Cuentas"
        Me.rbc.UseVisualStyleBackColor = True
        '
        'txtctainv
        '
        Me.txtctainv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtctainv.Location = New System.Drawing.Point(205, 42)
        Me.txtctainv.Name = "txtctainv"
        Me.txtctainv.Size = New System.Drawing.Size(102, 20)
        Me.txtctainv.TabIndex = 2
        Me.txtctainv.Text = "14"
        '
        'txtctacos
        '
        Me.txtctacos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtctacos.Location = New System.Drawing.Point(205, 65)
        Me.txtctacos.Name = "txtctacos"
        Me.txtctacos.Size = New System.Drawing.Size(102, 20)
        Me.txtctacos.TabIndex = 4
        Me.txtctacos.Text = "61"
        '
        'txtnomcos
        '
        Me.txtnomcos.Enabled = False
        Me.txtnomcos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcos.Location = New System.Drawing.Point(313, 66)
        Me.txtnomcos.Name = "txtnomcos"
        Me.txtnomcos.Size = New System.Drawing.Size(225, 18)
        Me.txtnomcos.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Cuenta 14"
        '
        'txtnominv
        '
        Me.txtnominv.Enabled = False
        Me.txtnominv.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnominv.Location = New System.Drawing.Point(313, 43)
        Me.txtnominv.Name = "txtnominv"
        Me.txtnominv.Size = New System.Drawing.Size(225, 18)
        Me.txtnominv.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Cuenta 61"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdpdf)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 333)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(572, 85)
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
        'cmdpdf
        '
        Me.cmdpdf.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpdf.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpdf.Location = New System.Drawing.Point(253, 14)
        Me.cmdpdf.Name = "cmdpdf"
        Me.cmdpdf.Size = New System.Drawing.Size(59, 57)
        Me.cmdpdf.TabIndex = 2
        Me.cmdpdf.Text = "&T"
        Me.cmdpdf.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.cmdpdf, "Tarjeta para conteo físico Alt + T")
        Me.cmdpdf.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(312, 14)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Atrás Alf+F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pantalla
        Me.cmdpantalla.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdpantalla.Location = New System.Drawing.Point(193, 14)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&P"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Generar en Pantalla Para Editar Alt + P")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(168, 321)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 81
        Me.mibarra.Visible = False
        '
        'FrmConteoFisInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(583, 425)
        Me.Controls.Add(Me.mibarra)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConteoFisInv"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Conteo Físico de Inventario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbbodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnombod As System.Windows.Forms.TextBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbno As System.Windows.Forms.RadioButton
    Friend WithEvents rbsi As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtn2 As System.Windows.Forms.TextBox
    Friend WithEvents txtn1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfin As System.Windows.Forms.TextBox
    Friend WithEvents txtini As System.Windows.Forms.TextBox
    Friend WithEvents rbr As System.Windows.Forms.RadioButton
    Friend WithEvents rbt As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents rbc As System.Windows.Forms.RadioButton
    Friend WithEvents rbca As System.Windows.Forms.RadioButton
    Friend WithEvents txtnomcos As System.Windows.Forms.TextBox
    Friend WithEvents txtnominv As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtctacos As System.Windows.Forms.TextBox
    Friend WithEvents txtctainv As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdpdf As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents mibarra As System.Windows.Forms.ProgressBar
End Class
