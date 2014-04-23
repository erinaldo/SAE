<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRestaurarCopia
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
        Me.lbsw = New System.Windows.Forms.Label
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdBackup = New System.Windows.Forms.Button
        Me.btnExaminar = New System.Windows.Forms.Button
        Me.cboBaseDatos = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btomysql = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtmysql = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDirPathBackup = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OPF = New System.Windows.Forms.OpenFileDialog
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbsw)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdBackup)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 160)
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
        Me.GroupPanel1.TabIndex = 34
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
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(272, 5)
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
        Me.cmdBackup.Location = New System.Drawing.Point(198, 5)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(70, 70)
        Me.cmdBackup.TabIndex = 0
        Me.cmdBackup.Text = "&R"
        Me.cmdBackup.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdBackup, "Restaurar Copia de Seguridad  Alt + R")
        Me.cmdBackup.UseVisualStyleBackColor = False
        '
        'btnExaminar
        '
        Me.btnExaminar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExaminar.Location = New System.Drawing.Point(464, 104)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(58, 23)
        Me.btnExaminar.TabIndex = 21
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'cboBaseDatos
        '
        Me.cboBaseDatos.Enabled = False
        Me.cboBaseDatos.FormattingEnabled = True
        Me.cboBaseDatos.Location = New System.Drawing.Point(120, 24)
        Me.cboBaseDatos.Margin = New System.Windows.Forms.Padding(2)
        Me.cboBaseDatos.Name = "cboBaseDatos"
        Me.cboBaseDatos.Size = New System.Drawing.Size(180, 21)
        Me.cboBaseDatos.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Base de Datos:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btomysql)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtmysql)
        Me.GroupBox1.Controls.Add(Me.btnExaminar)
        Me.GroupBox1.Controls.Add(Me.cboBaseDatos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDirPathBackup)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 144)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del Backup"
        '
        'btomysql
        '
        Me.btomysql.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btomysql.Location = New System.Drawing.Point(464, 64)
        Me.btomysql.Name = "btomysql"
        Me.btomysql.Size = New System.Drawing.Size(58, 23)
        Me.btomysql.TabIndex = 28
        Me.btomysql.Text = "Examinar"
        Me.btomysql.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Directorio MYSQL"
        '
        'txtmysql
        '
        Me.txtmysql.Enabled = False
        Me.txtmysql.Location = New System.Drawing.Point(120, 64)
        Me.txtmysql.Name = "txtmysql"
        Me.txtmysql.Size = New System.Drawing.Size(336, 20)
        Me.txtmysql.TabIndex = 27
        Me.txtmysql.Text = "C:\Archivos de programa\MySQL\MySQL Server 5.0\bin"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Archivo Backup:"
        '
        'txtDirPathBackup
        '
        Me.txtDirPathBackup.Enabled = False
        Me.txtDirPathBackup.Location = New System.Drawing.Point(118, 106)
        Me.txtDirPathBackup.Name = "txtDirPathBackup"
        Me.txtDirPathBackup.Size = New System.Drawing.Size(338, 20)
        Me.txtDirPathBackup.TabIndex = 25
        '
        'OPF
        '
        Me.OPF.FileName = "OpenFileDialog1"
        '
        'FrmRestaurarCopia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(562, 255)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRestaurarCopia"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Restaurar Copia De Seguridad   Bajo Windows"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbsw As System.Windows.Forms.Label
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents cboBaseDatos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDirPathBackup As System.Windows.Forms.TextBox
    Friend WithEvents OPF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtmysql As System.Windows.Forms.TextBox
    Friend WithEvents btomysql As System.Windows.Forms.Button
End Class
