<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPass))
        Me.txtpasswC = New System.Windows.Forms.TextBox
        Me.txtcompania = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmdOk = New System.Windows.Forms.Button
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpasswC
        '
        Me.txtpasswC.Location = New System.Drawing.Point(267, 80)
        Me.txtpasswC.Name = "txtpasswC"
        Me.txtpasswC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpasswC.Size = New System.Drawing.Size(178, 20)
        Me.txtpasswC.TabIndex = 0
        '
        'txtcompania
        '
        Me.txtcompania.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcompania.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcompania.Location = New System.Drawing.Point(267, 54)
        Me.txtcompania.Name = "txtcompania"
        Me.txtcompania.ReadOnly = True
        Me.txtcompania.Size = New System.Drawing.Size(178, 20)
        Me.txtcompania.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(205, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "&Compañia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(331, 115)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "&Cancelar"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(205, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 23)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "&Contraseña"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.ErrorImage = CType(resources.GetObject("LogoPictureBox.ErrorImage"), System.Drawing.Image)
        Me.LogoPictureBox.Image = Global.SAE.My.Resources.Resources.SAE_LOGOTIPO
        Me.LogoPictureBox.Location = New System.Drawing.Point(4, 33)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(205, 95)
        Me.LogoPictureBox.TabIndex = 12
        Me.LogoPictureBox.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(250, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 24)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Abrir Compañia"
        '
        'CmdOk
        '
        Me.CmdOk.Location = New System.Drawing.Point(231, 115)
        Me.CmdOk.Name = "CmdOk"
        Me.CmdOk.Size = New System.Drawing.Size(94, 23)
        Me.CmdOk.TabIndex = 20
        Me.CmdOk.Text = "&Aceptar"
        '
        'FrmPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(460, 156)
        Me.Controls.Add(Me.CmdOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtpasswC)
        Me.Controls.Add(Me.txtcompania)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPass"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Abrir Compañia"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtpasswC As System.Windows.Forms.TextBox
    Friend WithEvents txtcompania As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmdOk As System.Windows.Forms.Button
End Class
