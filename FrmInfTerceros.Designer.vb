<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfTerceros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInfTerceros))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdpdf = New System.Windows.Forms.Button
        Me.cmbtipo = New System.Windows.Forms.ComboBox
        Me.r2 = New System.Windows.Forms.RadioButton
        Me.r1 = New System.Windows.Forms.RadioButton
        Me.r3 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.r3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.cmdpdf)
        Me.GroupBox1.Controls.Add(Me.cmbtipo)
        Me.GroupBox1.Controls.Add(Me.r2)
        Me.GroupBox1.Controls.Add(Me.r1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 103)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Image = Global.SAE.My.Resources.Resources.cparam
        Me.Button2.Location = New System.Drawing.Point(335, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 70)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmdpdf
        '
        Me.cmdpdf.BackColor = System.Drawing.Color.White
        Me.cmdpdf.Image = Global.SAE.My.Resources.Resources.continuar
        Me.cmdpdf.Location = New System.Drawing.Point(254, 17)
        Me.cmdpdf.Name = "cmdpdf"
        Me.cmdpdf.Size = New System.Drawing.Size(75, 70)
        Me.cmdpdf.TabIndex = 3
        Me.cmdpdf.UseVisualStyleBackColor = False
        '
        'cmbtipo
        '
        Me.cmbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipo.Enabled = False
        Me.cmbtipo.FormattingEnabled = True
        Me.cmbtipo.Items.AddRange(New Object() {"CLIENTES", "PROVEEDOR", "OTROS"})
        Me.cmbtipo.Location = New System.Drawing.Point(82, 69)
        Me.cmbtipo.Name = "cmbtipo"
        Me.cmbtipo.Size = New System.Drawing.Size(146, 21)
        Me.cmbtipo.TabIndex = 2
        '
        'r2
        '
        Me.r2.AutoSize = True
        Me.r2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r2.Location = New System.Drawing.Point(12, 69)
        Me.r2.Name = "r2"
        Me.r2.Size = New System.Drawing.Size(68, 19)
        Me.r2.TabIndex = 1
        Me.r2.Text = "Un Tipo"
        Me.r2.UseVisualStyleBackColor = True
        '
        'r1
        '
        Me.r1.AutoSize = True
        Me.r1.Checked = True
        Me.r1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r1.Location = New System.Drawing.Point(12, 20)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(59, 19)
        Me.r1.TabIndex = 0
        Me.r1.Text = "Todos"
        Me.r1.UseVisualStyleBackColor = True
        '
        'r3
        '
        Me.r3.AutoSize = True
        Me.r3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.r3.Location = New System.Drawing.Point(12, 45)
        Me.r3.Name = "r3"
        Me.r3.Size = New System.Drawing.Size(78, 19)
        Me.r3.TabIndex = 1
        Me.r3.Text = "Completo"
        Me.r3.UseVisualStyleBackColor = True
        '
        'FrmInfTerceros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(436, 118)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfTerceros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe Terceros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents r2 As System.Windows.Forms.RadioButton
    Friend WithEvents r1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdpdf As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents r3 As System.Windows.Forms.RadioButton
End Class
