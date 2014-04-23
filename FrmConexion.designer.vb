<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConexion))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbform = New System.Windows.Forms.Label
        Me.Cancel = New System.Windows.Forms.Button
        Me.cmdprobar = New System.Windows.Forms.Button
        Me.CmdOk = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtpuerto = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtpass = New System.Windows.Forms.TextBox
        Me.txtuser = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt4 = New System.Windows.Forms.TextBox
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.ip2 = New System.Windows.Forms.RadioButton
        Me.ip1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.ErrorImage = CType(resources.GetObject("LogoPictureBox.ErrorImage"), System.Drawing.Image)
        Me.LogoPictureBox.Image = Global.SAE.My.Resources.Resources.SAE_LOGOTIPO
        Me.LogoPictureBox.Location = New System.Drawing.Point(4, 12)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(216, 217)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 1
        Me.LogoPictureBox.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(226, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 234)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbform)
        Me.GroupBox5.Controls.Add(Me.Cancel)
        Me.GroupBox5.Controls.Add(Me.cmdprobar)
        Me.GroupBox5.Controls.Add(Me.CmdOk)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 176)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(448, 52)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(12, 24)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 3
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(261, 19)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "&Cancelar"
        '
        'cmdprobar
        '
        Me.cmdprobar.Location = New System.Drawing.Point(70, 19)
        Me.cmdprobar.Name = "cmdprobar"
        Me.cmdprobar.Size = New System.Drawing.Size(94, 23)
        Me.cmdprobar.TabIndex = 0
        Me.cmdprobar.Text = "&Probar Conexión"
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(166, 19)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(94, 23)
        Me.CmdOk.TabIndex = 1
        Me.CmdOk.Text = "&Aceptar"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtpuerto)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 123)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(448, 52)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Puerto de Conexión"
        '
        'txtpuerto
        '
        Me.txtpuerto.Location = New System.Drawing.Point(124, 18)
        Me.txtpuerto.MaxLength = 5
        Me.txtpuerto.Name = "txtpuerto"
        Me.txtpuerto.Size = New System.Drawing.Size(37, 20)
        Me.txtpuerto.TabIndex = 0
        Me.txtpuerto.Text = "3306"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Puerto de Conexión"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtpass)
        Me.GroupBox3.Controls.Add(Me.txtuser)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(448, 51)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Usuario de La Base De Datos"
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(226, 20)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(210, 20)
        Me.txtpass.TabIndex = 1
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(60, 20)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(100, 20)
        Me.txtuser.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(167, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Usuario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt4)
        Me.GroupBox1.Controls.Add(Me.txt3)
        Me.GroupBox1.Controls.Add(Me.txt2)
        Me.GroupBox1.Controls.Add(Me.txt1)
        Me.GroupBox1.Controls.Add(Me.ip2)
        Me.GroupBox1.Controls.Add(Me.ip1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Servidor de Base de Datos"
        '
        'txt4
        '
        Me.txt4.Enabled = False
        Me.txt4.Location = New System.Drawing.Point(347, 18)
        Me.txt4.MaxLength = 3
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(30, 20)
        Me.txt4.TabIndex = 5
        Me.txt4.Text = "1"
        '
        'txt3
        '
        Me.txt3.Enabled = False
        Me.txt3.Location = New System.Drawing.Point(306, 18)
        Me.txt3.MaxLength = 3
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(30, 20)
        Me.txt3.TabIndex = 4
        Me.txt3.Text = "0"
        '
        'txt2
        '
        Me.txt2.Enabled = False
        Me.txt2.Location = New System.Drawing.Point(266, 18)
        Me.txt2.MaxLength = 3
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(30, 20)
        Me.txt2.TabIndex = 3
        Me.txt2.Text = "168"
        '
        'txt1
        '
        Me.txt1.Enabled = False
        Me.txt1.Location = New System.Drawing.Point(226, 18)
        Me.txt1.MaxLength = 3
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(30, 20)
        Me.txt1.TabIndex = 2
        Me.txt1.Text = "192"
        '
        'ip2
        '
        Me.ip2.AutoSize = True
        Me.ip2.Location = New System.Drawing.Point(163, 19)
        Me.ip2.Name = "ip2"
        Me.ip2.Size = New System.Drawing.Size(57, 17)
        Me.ip2.TabIndex = 1
        Me.ip2.Text = "&Cliente"
        Me.ip2.UseVisualStyleBackColor = True
        '
        'ip1
        '
        Me.ip1.AutoSize = True
        Me.ip1.Checked = True
        Me.ip1.Location = New System.Drawing.Point(17, 19)
        Me.ip1.Name = "ip1"
        Me.ip1.Size = New System.Drawing.Size(118, 17)
        Me.ip1.TabIndex = 0
        Me.ip1.TabStop = True
        Me.ip1.Text = "&Servidor   127.0.0.1"
        Me.ip1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(251, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(290, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 31)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(331, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 31)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "."
        '
        'FrmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(694, 245)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConexion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Parametros de Conexión"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt4 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents ip2 As System.Windows.Forms.RadioButton
    Friend WithEvents ip1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtpuerto As System.Windows.Forms.TextBox
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents txtuser As System.Windows.Forms.TextBox
    Friend WithEvents cmdprobar As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbform As System.Windows.Forms.Label
End Class
