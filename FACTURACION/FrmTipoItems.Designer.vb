<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoItems
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
        Me.lbitems = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbser = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbfila = New System.Windows.Forms.Label
        Me.Ch_Ser = New System.Windows.Forms.CheckBox
        Me.Ch_Inv = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbitems
        '
        Me.lbitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitems.ForeColor = System.Drawing.Color.DarkRed
        Me.lbitems.Location = New System.Drawing.Point(13, 112)
        Me.lbitems.Name = "lbitems"
        Me.lbitems.Size = New System.Drawing.Size(247, 23)
        Me.lbitems.TabIndex = 75
        Me.lbitems.Text = "Favor Seleccione un tipo de Items."
        Me.lbitems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbser)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbfila)
        Me.GroupBox1.Controls.Add(Me.Ch_Ser)
        Me.GroupBox1.Controls.Add(Me.Ch_Inv)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 94)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar tipo de Items"
        '
        'lbser
        '
        Me.lbser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbser.ForeColor = System.Drawing.Color.DarkRed
        Me.lbser.Location = New System.Drawing.Point(145, 62)
        Me.lbser.Name = "lbser"
        Me.lbser.Size = New System.Drawing.Size(95, 23)
        Me.lbser.TabIndex = 78
        Me.lbser.Text = "Alt + S= Servicios"
        Me.lbser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(15, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 23)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Alt + I = Inventarios"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(157, 16)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(20, 13)
        Me.lbfila.TabIndex = 76
        Me.lbfila.Text = "fila"
        Me.lbfila.Visible = False
        '
        'Ch_Ser
        '
        Me.Ch_Ser.AutoSize = True
        Me.Ch_Ser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ch_Ser.Location = New System.Drawing.Point(148, 39)
        Me.Ch_Ser.Name = "Ch_Ser"
        Me.Ch_Ser.Size = New System.Drawing.Size(92, 20)
        Me.Ch_Ser.TabIndex = 7
        Me.Ch_Ser.Text = "&Servicios"
        Me.ToolTip1.SetToolTip(Me.Ch_Ser, "Item de Servicio Alt + S")
        Me.Ch_Ser.UseVisualStyleBackColor = True
        '
        'Ch_Inv
        '
        Me.Ch_Inv.AutoSize = True
        Me.Ch_Inv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ch_Inv.Location = New System.Drawing.Point(18, 39)
        Me.Ch_Inv.Name = "Ch_Inv"
        Me.Ch_Inv.Size = New System.Drawing.Size(103, 20)
        Me.Ch_Inv.TabIndex = 6
        Me.Ch_Inv.Text = "&Inventarios"
        Me.ToolTip1.SetToolTip(Me.Ch_Inv, "Item de Inventario Alt + I")
        Me.Ch_Inv.UseVisualStyleBackColor = True
        '
        'FrmTipoItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(284, 142)
        Me.Controls.Add(Me.lbitems)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTipoItems"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Seleccionar Tipo de Items"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbitems As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Ch_Ser As System.Windows.Forms.CheckBox
    Friend WithEvents Ch_Inv As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents lbser As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
