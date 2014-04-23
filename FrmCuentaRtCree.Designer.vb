<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCuentaRtCree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentaRtCree))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.cmbporc = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdactualizar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Porcentaje de ReteCree"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcuenta)
        Me.GroupBox1.Controls.Add(Me.cmbporc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 96)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtcuenta
        '
        Me.txtcuenta.Location = New System.Drawing.Point(162, 61)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(130, 20)
        Me.txtcuenta.TabIndex = 4
        '
        'cmbporc
        '
        Me.cmbporc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbporc.FormattingEnabled = True
        Me.cmbporc.Location = New System.Drawing.Point(162, 33)
        Me.cmbporc.Name = "cmbporc"
        Me.cmbporc.Size = New System.Drawing.Size(59, 21)
        Me.cmbporc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cuenta"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdactualizar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 103)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(326, 85)
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
        Me.GroupPanel1.TabIndex = 72
        '
        'cmdactualizar
        '
        Me.cmdactualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdactualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdactualizar.ForeColor = System.Drawing.SystemColors.Info
        Me.cmdactualizar.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdactualizar.Location = New System.Drawing.Point(94, 11)
        Me.cmdactualizar.Name = "cmdactualizar"
        Me.cmdactualizar.Size = New System.Drawing.Size(59, 57)
        Me.cmdactualizar.TabIndex = 18
        Me.cmdactualizar.Text = "&A"
        Me.cmdactualizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdactualizar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(159, 11)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 20
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'FrmCuentaRtCree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(337, 194)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCuentaRtCree"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametrizacion de cuentas ReteCree"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents cmbporc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdactualizar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
End Class
