<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPeriodo))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdcan = New System.Windows.Forms.Button
        Me.cmdabrir = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbactual = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.mes = New System.Windows.Forms.ComboBox
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ano = New System.Windows.Forms.TextBox
        Me.lbmes = New System.Windows.Forms.Label
        Me.GroupPanel1.SuspendLayout()
        Me.mimenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbmes)
        Me.GroupPanel1.Controls.Add(Me.cmdcan)
        Me.GroupPanel1.Controls.Add(Me.cmdabrir)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 159)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(334, 85)
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
        Me.GroupPanel1.TabIndex = 2
        '
        'cmdcan
        '
        Me.cmdcan.BackColor = System.Drawing.Color.White
        Me.cmdcan.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcan.Image = Global.SAE.My.Resources.Resources.cancelarperiodo
        Me.cmdcan.Location = New System.Drawing.Point(170, 8)
        Me.cmdcan.Name = "cmdcan"
        Me.cmdcan.Size = New System.Drawing.Size(66, 68)
        Me.cmdcan.TabIndex = 10
        Me.cmdcan.Text = "&S"
        Me.cmdcan.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcan, "salir sin guardar cambios")
        Me.cmdcan.UseVisualStyleBackColor = False
        '
        'cmdabrir
        '
        Me.cmdabrir.BackColor = System.Drawing.Color.White
        Me.cmdabrir.ForeColor = System.Drawing.Color.Transparent
        Me.cmdabrir.Image = Global.SAE.My.Resources.Resources.abriperiodo
        Me.cmdabrir.Location = New System.Drawing.Point(85, 8)
        Me.cmdabrir.Name = "cmdabrir"
        Me.cmdabrir.Size = New System.Drawing.Size(66, 68)
        Me.cmdabrir.TabIndex = 9
        Me.cmdabrir.Text = "&P"
        Me.cmdabrir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdabrir, "abrir período")
        Me.cmdabrir.UseVisualStyleBackColor = False
        '
        'lbactual
        '
        Me.lbactual.AutoSize = True
        Me.lbactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbactual.ForeColor = System.Drawing.Color.DarkRed
        Me.lbactual.Location = New System.Drawing.Point(207, 64)
        Me.lbactual.Name = "lbactual"
        Me.lbactual.Size = New System.Drawing.Size(97, 25)
        Me.lbactual.TabIndex = 7
        Me.lbactual.Text = "00/2011"
        Me.ToolTip1.SetToolTip(Me.lbactual, "periodo actua (mes/año)")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(48, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(229, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "PERÍODO  ( MES/AÑO)"
        Me.ToolTip1.SetToolTip(Me.Label4, "formato período")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(238, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 29)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "/"
        Me.ToolTip1.SetToolTip(Me.Label3, "periodo actua (mes/año)")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "PERÍODO ACTUAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ABRIR  PERÍODO "
        '
        'mes
        '
        Me.mes.ContextMenuStrip = Me.mimenu
        Me.mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mes.FormattingEnabled = True
        Me.mes.Location = New System.Drawing.Point(190, 104)
        Me.mes.Margin = New System.Windows.Forms.Padding(4)
        Me.mes.Name = "mes"
        Me.mes.Size = New System.Drawing.Size(49, 24)
        Me.mes.TabIndex = 96
        '
        'mimenu
        '
        Me.mimenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2})
        Me.mimenu.Name = "mimenu"
        Me.mimenu.Size = New System.Drawing.Size(146, 26)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(145, 22)
        Me.ToolStripMenuItem2.Text = "¿Que es esto?"
        '
        'ano
        '
        Me.ano.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ano.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ano.Location = New System.Drawing.Point(256, 104)
        Me.ano.Name = "ano"
        Me.ano.ReadOnly = True
        Me.ano.ShortcutsEnabled = False
        Me.ano.Size = New System.Drawing.Size(48, 22)
        Me.ano.TabIndex = 99
        Me.ano.Text = "2011"
        '
        'lbmes
        '
        Me.lbmes.AutoSize = True
        Me.lbmes.Location = New System.Drawing.Point(268, 32)
        Me.lbmes.Name = "lbmes"
        Me.lbmes.Size = New System.Drawing.Size(39, 13)
        Me.lbmes.TabIndex = 11
        Me.lbmes.Text = "Label5"
        Me.lbmes.Visible = False
        '
        'FrmPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(345, 248)
        Me.Controls.Add(Me.ano)
        Me.Controls.Add(Me.mes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbactual)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPeriodo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "   SAE ABRIR PERIODO  Abrir=(Alt+P), Salir=(Alt+S)"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.mimenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdabrir As System.Windows.Forms.Button
    Friend WithEvents cmdcan As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbactual As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ano As System.Windows.Forms.TextBox
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbmes As System.Windows.Forms.Label
End Class
