<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmValorInmu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmValorInmu))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.v1 = New System.Windows.Forms.RadioButton
        Me.v2 = New System.Windows.Forms.RadioButton
        Me.v3 = New System.Windows.Forms.RadioButton
        Me.cmditems = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmditems)
        Me.GroupBox1.Controls.Add(Me.v3)
        Me.GroupBox1.Controls.Add(Me.v2)
        Me.GroupBox1.Controls.Add(Me.v1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 99)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'v1
        '
        Me.v1.AutoSize = True
        Me.v1.Location = New System.Drawing.Point(14, 16)
        Me.v1.Name = "v1"
        Me.v1.Size = New System.Drawing.Size(99, 17)
        Me.v1.TabIndex = 0
        Me.v1.Text = "Precio Vivienda"
        Me.v1.UseVisualStyleBackColor = True
        '
        'v2
        '
        Me.v2.AutoSize = True
        Me.v2.Location = New System.Drawing.Point(14, 41)
        Me.v2.Name = "v2"
        Me.v2.Size = New System.Drawing.Size(169, 17)
        Me.v2.TabIndex = 1
        Me.v2.Text = "Precio Local Comercial / Mixto"
        Me.v2.UseVisualStyleBackColor = True
        '
        'v3
        '
        Me.v3.AutoSize = True
        Me.v3.Checked = True
        Me.v3.Location = New System.Drawing.Point(14, 67)
        Me.v3.Name = "v3"
        Me.v3.Size = New System.Drawing.Size(45, 17)
        Me.v3.TabIndex = 2
        Me.v3.TabStop = True
        Me.v3.Text = "Otro"
        Me.v3.UseVisualStyleBackColor = True
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(197, 14)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 3
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'FrmValorInmu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(300, 120)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmValorInmu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Valor Inmueble"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents v2 As System.Windows.Forms.RadioButton
    Friend WithEvents v1 As System.Windows.Forms.RadioButton
    Friend WithEvents v3 As System.Windows.Forms.RadioButton
    Friend WithEvents cmditems As System.Windows.Forms.Button
End Class
