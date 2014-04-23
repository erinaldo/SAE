<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActualizarCC
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
        Me.txtano2 = New System.Windows.Forms.TextBox
        Me.txtmes2 = New System.Windows.Forms.TextBox
        Me.lbper = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtano = New System.Windows.Forms.TextBox
        Me.txtmes = New System.Windows.Forms.TextBox
        Me.p3 = New System.Windows.Forms.RadioButton
        Me.p2 = New System.Windows.Forms.RadioButton
        Me.p1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdactualizar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdperiodo = New System.Windows.Forms.Button
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtano2)
        Me.GroupBox1.Controls.Add(Me.txtmes2)
        Me.GroupBox1.Controls.Add(Me.lbper)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtano)
        Me.GroupBox1.Controls.Add(Me.txtmes)
        Me.GroupBox1.Controls.Add(Me.p3)
        Me.GroupBox1.Controls.Add(Me.p2)
        Me.GroupBox1.Controls.Add(Me.p1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 94)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'txtano2
        '
        Me.txtano2.Location = New System.Drawing.Point(385, 43)
        Me.txtano2.Name = "txtano2"
        Me.txtano2.ReadOnly = True
        Me.txtano2.Size = New System.Drawing.Size(44, 20)
        Me.txtano2.TabIndex = 54
        Me.txtano2.Text = "/2010"
        '
        'txtmes2
        '
        Me.txtmes2.Enabled = False
        Me.txtmes2.Location = New System.Drawing.Point(358, 43)
        Me.txtmes2.MaxLength = 2
        Me.txtmes2.Name = "txtmes2"
        Me.txtmes2.Size = New System.Drawing.Size(29, 20)
        Me.txtmes2.TabIndex = 53
        Me.txtmes2.Text = "01"
        Me.txtmes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(165, 20)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(59, 15)
        Me.lbper.TabIndex = 50
        Me.lbper.Text = "00/0000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(313, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Final"
        '
        'txtano
        '
        Me.txtano.Location = New System.Drawing.Point(249, 43)
        Me.txtano.Name = "txtano"
        Me.txtano.ReadOnly = True
        Me.txtano.Size = New System.Drawing.Size(46, 20)
        Me.txtano.TabIndex = 45
        Me.txtano.Text = "/2010"
        '
        'txtmes
        '
        Me.txtmes.Enabled = False
        Me.txtmes.Location = New System.Drawing.Point(222, 43)
        Me.txtmes.MaxLength = 2
        Me.txtmes.Name = "txtmes"
        Me.txtmes.Size = New System.Drawing.Size(29, 20)
        Me.txtmes.TabIndex = 44
        Me.txtmes.Text = "01"
        Me.txtmes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'p3
        '
        Me.p3.AutoSize = True
        Me.p3.Location = New System.Drawing.Point(25, 66)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(163, 17)
        Me.p3.TabIndex = 2
        Me.p3.Text = "Todo el Catalogo de Cuentas"
        Me.p3.UseVisualStyleBackColor = True
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Location = New System.Drawing.Point(25, 43)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(118, 17)
        Me.p2.TabIndex = 1
        Me.p2.Text = "Rango De Periodos"
        Me.p2.UseVisualStyleBackColor = True
        '
        'p1
        '
        Me.p1.AutoSize = True
        Me.p1.Checked = True
        Me.p1.Location = New System.Drawing.Point(25, 20)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(94, 17)
        Me.p1.TabIndex = 0
        Me.p1.TabStop = True
        Me.p1.Text = "Periodo Actual"
        Me.p1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(164, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Inicial"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(494, 119)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdactualizar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdperiodo)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 130)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(494, 85)
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
        Me.cmdactualizar.Location = New System.Drawing.Point(214, 11)
        Me.cmdactualizar.Name = "cmdactualizar"
        Me.cmdactualizar.Size = New System.Drawing.Size(59, 57)
        Me.cmdactualizar.TabIndex = 22
        Me.cmdactualizar.Text = "&A"
        Me.cmdactualizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdactualizar, "Actualizar  Catalogo De Cuentas Alt+A")
        Me.cmdactualizar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(274, 11)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 21
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdperiodo
        '
        Me.cmdperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdperiodo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdperiodo.Image = Global.SAE.My.Resources.Resources.abriperiodo1
        Me.cmdperiodo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.cmdperiodo.Location = New System.Drawing.Point(154, 11)
        Me.cmdperiodo.Name = "cmdperiodo"
        Me.cmdperiodo.Size = New System.Drawing.Size(59, 57)
        Me.cmdperiodo.TabIndex = 19
        Me.cmdperiodo.Text = "&P"
        Me.cmdperiodo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdperiodo, "Abrir Periodo Alt + P")
        Me.cmdperiodo.UseVisualStyleBackColor = False
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(138, 106)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 74
        Me.mibarra.Visible = False
        '
        'FrmActualizarCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(505, 221)
        Me.Controls.Add(Me.mibarra)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmActualizarCC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Actualizar Catalogo de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents p3 As System.Windows.Forms.RadioButton
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtano2 As System.Windows.Forms.TextBox
    Friend WithEvents txtmes2 As System.Windows.Forms.TextBox
    Friend WithEvents txtano As System.Windows.Forms.TextBox
    Friend WithEvents txtmes As System.Windows.Forms.TextBox
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdactualizar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdperiodo As System.Windows.Forms.Button
End Class
