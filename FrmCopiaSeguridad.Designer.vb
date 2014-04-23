<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopiaSeguridad
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
        Me.cb_copia = New System.Windows.Forms.CheckBox
        Me.lbespere = New System.Windows.Forms.Label
        Me.Chbd = New System.Windows.Forms.CheckBox
        Me.cbdestino = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExaminar = New System.Windows.Forms.Button
        Me.cmbServidor = New System.Windows.Forms.ComboBox
        Me.cboBaseDatos = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNom_Backup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDirPathBackup = New System.Windows.Forms.TextBox
        Me.lbsw = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbform = New System.Windows.Forms.Label
        Me.lbtime = New System.Windows.Forms.Label
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdBackup = New System.Windows.Forms.Button
        Me.txtDescrip_Backup = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_copia)
        Me.GroupBox1.Controls.Add(Me.lbespere)
        Me.GroupBox1.Controls.Add(Me.Chbd)
        Me.GroupBox1.Controls.Add(Me.cbdestino)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnExaminar)
        Me.GroupBox1.Controls.Add(Me.cmbServidor)
        Me.GroupBox1.Controls.Add(Me.cboBaseDatos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNom_Backup)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDirPathBackup)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(614, 160)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del Backup"
        '
        'cb_copia
        '
        Me.cb_copia.AutoSize = True
        Me.cb_copia.Location = New System.Drawing.Point(462, 122)
        Me.cb_copia.Name = "cb_copia"
        Me.cb_copia.Size = New System.Drawing.Size(129, 17)
        Me.cb_copia.TabIndex = 32
        Me.cb_copia.Text = "Enviar copia al correo"
        Me.cb_copia.UseVisualStyleBackColor = True
        '
        'lbespere
        '
        Me.lbespere.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbespere.ForeColor = System.Drawing.Color.DarkRed
        Me.lbespere.Location = New System.Drawing.Point(188, 112)
        Me.lbespere.Name = "lbespere"
        Me.lbespere.Size = New System.Drawing.Size(268, 47)
        Me.lbespere.TabIndex = 31
        Me.lbespere.Text = "Por favor espere..."
        Me.lbespere.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Chbd
        '
        Me.Chbd.AutoSize = True
        Me.Chbd.Location = New System.Drawing.Point(344, 90)
        Me.Chbd.Name = "Chbd"
        Me.Chbd.Size = New System.Drawing.Size(217, 17)
        Me.Chbd.TabIndex = 30
        Me.Chbd.Text = "Guardar Copia de Todas Las Compañias"
        Me.Chbd.UseVisualStyleBackColor = True
        '
        'cbdestino
        '
        Me.cbdestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdestino.FormattingEnabled = True
        Me.cbdestino.Location = New System.Drawing.Point(118, 121)
        Me.cbdestino.Name = "cbdestino"
        Me.cbdestino.Size = New System.Drawing.Size(64, 21)
        Me.cbdestino.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Directorio Destino"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Servidor Local :"
        '
        'btnExaminar
        '
        Me.btnExaminar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExaminar.Location = New System.Drawing.Point(530, 55)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(58, 23)
        Me.btnExaminar.TabIndex = 21
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'cmbServidor
        '
        Me.cmbServidor.Enabled = False
        Me.cmbServidor.FormattingEnabled = True
        Me.cmbServidor.Location = New System.Drawing.Point(118, 29)
        Me.cmbServidor.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbServidor.Name = "cmbServidor"
        Me.cmbServidor.Size = New System.Drawing.Size(180, 21)
        Me.cmbServidor.TabIndex = 18
        Me.cmbServidor.Text = "127.0.0.1"
        '
        'cboBaseDatos
        '
        Me.cboBaseDatos.Enabled = False
        Me.cboBaseDatos.FormattingEnabled = True
        Me.cboBaseDatos.Location = New System.Drawing.Point(408, 26)
        Me.cboBaseDatos.Margin = New System.Windows.Forms.Padding(2)
        Me.cboBaseDatos.Name = "cboBaseDatos"
        Me.cboBaseDatos.Size = New System.Drawing.Size(180, 21)
        Me.cboBaseDatos.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Base de Datos:"
        '
        'txtNom_Backup
        '
        Me.txtNom_Backup.Location = New System.Drawing.Point(118, 88)
        Me.txtNom_Backup.MaxLength = 20
        Me.txtNom_Backup.Name = "txtNom_Backup"
        Me.txtNom_Backup.Size = New System.Drawing.Size(219, 20)
        Me.txtNom_Backup.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Directorio Origen:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Nombre Backup:"
        '
        'txtDirPathBackup
        '
        Me.txtDirPathBackup.Enabled = False
        Me.txtDirPathBackup.Location = New System.Drawing.Point(118, 58)
        Me.txtDirPathBackup.Name = "txtDirPathBackup"
        Me.txtDirPathBackup.Size = New System.Drawing.Size(406, 20)
        Me.txtDirPathBackup.TabIndex = 25
        Me.txtDirPathBackup.Text = "C:\Archivos de programa\MySQL\MySQL Server 5.0\bin"
        '
        'lbsw
        '
        Me.lbsw.AutoSize = True
        Me.lbsw.Location = New System.Drawing.Point(42, 31)
        Me.lbsw.Name = "lbsw"
        Me.lbsw.Size = New System.Drawing.Size(20, 13)
        Me.lbsw.TabIndex = 30
        Me.lbsw.Text = "sw"
        Me.lbsw.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.lbtime)
        Me.GroupPanel1.Controls.Add(Me.lbsw)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdBackup)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 172)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(614, 85)
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
        Me.GroupPanel1.TabIndex = 32
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(137, 36)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(0, 13)
        Me.lbform.TabIndex = 32
        Me.lbform.Visible = False
        '
        'lbtime
        '
        Me.lbtime.AutoSize = True
        Me.lbtime.Location = New System.Drawing.Point(450, 31)
        Me.lbtime.Name = "lbtime"
        Me.lbtime.Size = New System.Drawing.Size(39, 13)
        Me.lbtime.TabIndex = 31
        Me.lbtime.Text = "Label6"
        Me.lbtime.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(306, 5)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 70)
        Me.cmdsalir.TabIndex = 2
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Atrás Alt +F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdBackup
        '
        Me.cmdBackup.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdBackup.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdBackup.Image = Global.SAE.My.Resources.Resources.backup
        Me.cmdBackup.Location = New System.Drawing.Point(232, 5)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(70, 70)
        Me.cmdBackup.TabIndex = 0
        Me.cmdBackup.Text = "&C"
        Me.cmdBackup.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdBackup, "Copia de Seguridad  Alt + C")
        Me.cmdBackup.UseVisualStyleBackColor = False
        '
        'txtDescrip_Backup
        '
        Me.txtDescrip_Backup.Location = New System.Drawing.Point(64, 192)
        Me.txtDescrip_Backup.MaxLength = 100
        Me.txtDescrip_Backup.Multiline = True
        Me.txtDescrip_Backup.Name = "txtDescrip_Backup"
        Me.txtDescrip_Backup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescrip_Backup.Size = New System.Drawing.Size(63, 24)
        Me.txtDescrip_Backup.TabIndex = 29
        Me.txtDescrip_Backup.Text = "ninguna"
        Me.txtDescrip_Backup.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FrmCopiaSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(625, 260)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDescrip_Backup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCopiaSeguridad"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  Copia De Seguridad  Bajo Windows"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents cmbServidor As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaseDatos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNom_Backup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDirPathBackup As System.Windows.Forms.TextBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbsw As System.Windows.Forms.Label
    Friend WithEvents txtDescrip_Backup As System.Windows.Forms.TextBox
    Friend WithEvents cbdestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Chbd As System.Windows.Forms.CheckBox
    Friend WithEvents lbtime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbespere As System.Windows.Forms.Label
    Friend WithEvents cb_copia As System.Windows.Forms.CheckBox
    Friend WithEvents lbform As System.Windows.Forms.Label
End Class
