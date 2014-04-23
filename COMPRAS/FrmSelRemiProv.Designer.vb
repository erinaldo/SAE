<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelRemiProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelRemiProv))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbEnt = New System.Windows.Forms.RadioButton
        Me.RbPed = New System.Windows.Forms.RadioButton
        Me.cmditems = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmditems)
        Me.GroupBox1.Controls.Add(Me.RbPed)
        Me.GroupBox1.Controls.Add(Me.rbEnt)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 103)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbEnt
        '
        Me.rbEnt.AutoSize = True
        Me.rbEnt.Checked = True
        Me.rbEnt.Location = New System.Drawing.Point(18, 31)
        Me.rbEnt.Name = "rbEnt"
        Me.rbEnt.Size = New System.Drawing.Size(122, 17)
        Me.rbEnt.TabIndex = 0
        Me.rbEnt.TabStop = True
        Me.rbEnt.Text = "Remisionar Entradas"
        Me.rbEnt.UseVisualStyleBackColor = True
        '
        'RbPed
        '
        Me.RbPed.AutoSize = True
        Me.RbPed.Location = New System.Drawing.Point(18, 66)
        Me.RbPed.Name = "RbPed"
        Me.RbPed.Size = New System.Drawing.Size(118, 17)
        Me.RbPed.TabIndex = 1
        Me.RbPed.Text = "Remisionar Pedidos"
        Me.RbPed.UseVisualStyleBackColor = True
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(169, 22)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 2
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'FrmSelRemiProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(263, 109)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelRemiProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remisionar a Factura de Proveedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbPed As System.Windows.Forms.RadioButton
    Friend WithEvents rbEnt As System.Windows.Forms.RadioButton
    Friend WithEvents cmditems As System.Windows.Forms.Button
End Class
