<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FrmLogin
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents txtpasswd As System.Windows.Forms.TextBox
    Friend WithEvents CmdOk As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.txtusuario = New System.Windows.Forms.TextBox
        Me.txtpasswd = New System.Windows.Forms.TextBox
        Me.CmdOk = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.txtcompania = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtpasswC = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(219, 18)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(45, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(219, 48)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(67, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtusuario
        '
        Me.txtusuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtusuario.Location = New System.Drawing.Point(281, 21)
        Me.txtusuario.MaxLength = 20
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(178, 20)
        Me.txtusuario.TabIndex = 0
        '
        'txtpasswd
        '
        Me.txtpasswd.Location = New System.Drawing.Point(281, 48)
        Me.txtpasswd.Name = "txtpasswd"
        Me.txtpasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpasswd.Size = New System.Drawing.Size(178, 20)
        Me.txtpasswd.TabIndex = 1
        '
        'CmdOk
        '
        Me.CmdOk.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.CmdOk.Location = New System.Drawing.Point(242, 145)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(94, 23)
        Me.CmdOk.TabIndex = 4
        Me.CmdOk.Text = "&Aceptar"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(345, 145)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancelar"
        '
        'txtcompania
        '
        Me.txtcompania.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcompania.Location = New System.Drawing.Point(281, 89)
        Me.txtcompania.Name = "txtcompania"
        Me.txtcompania.Size = New System.Drawing.Size(178, 20)
        Me.txtcompania.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(219, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "&Compañia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtpasswC
        '
        Me.txtpasswC.Location = New System.Drawing.Point(281, 115)
        Me.txtpasswC.Name = "txtpasswC"
        Me.txtpasswC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpasswC.Size = New System.Drawing.Size(178, 20)
        Me.txtpasswC.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label3.Location = New System.Drawing.Point(214, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 30)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "______________________________________________________"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(219, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 23)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "&Contraseña"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.ErrorImage = Global.SAE.My.Resources.Resources.SAE
        Me.LogoPictureBox.Image = Global.SAE.My.Resources.Resources.SAE_LOGOTIPO
        Me.LogoPictureBox.Location = New System.Drawing.Point(10, 48)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(198, 86)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(477, 191)
        Me.Controls.Add(Me.txtpasswC)
        Me.Controls.Add(Me.txtcompania)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.txtpasswd)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Acceso SAE"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtcompania As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtpasswC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
