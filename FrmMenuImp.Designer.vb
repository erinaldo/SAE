<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuImp
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
        Me.g_admin = New System.Windows.Forms.GroupBox
        Me.cmdreportes = New DevComponents.DotNetBar.ButtonX
        Me.cmdimpuestos = New DevComponents.DotNetBar.ButtonX
        Me.cmdgrupos = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.g_admin.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'g_admin
        '
        Me.g_admin.Controls.Add(Me.cmdreportes)
        Me.g_admin.Controls.Add(Me.cmdimpuestos)
        Me.g_admin.Controls.Add(Me.cmdgrupos)
        Me.g_admin.Location = New System.Drawing.Point(7, 6)
        Me.g_admin.Name = "g_admin"
        Me.g_admin.Size = New System.Drawing.Size(273, 149)
        Me.g_admin.TabIndex = 1
        Me.g_admin.TabStop = False
        Me.g_admin.Text = "Conceptos de Impuestos"
        '
        'cmdreportes
        '
        Me.cmdreportes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdreportes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdreportes.Location = New System.Drawing.Point(21, 132)
        Me.cmdreportes.Name = "cmdreportes"
        Me.cmdreportes.Size = New System.Drawing.Size(229, 36)
        Me.cmdreportes.TabIndex = 19
        Me.cmdreportes.Text = "&Reportes"
        Me.cmdreportes.Tooltip = "Reportes Alt + R"
        Me.cmdreportes.Visible = False
        '
        'cmdimpuestos
        '
        Me.cmdimpuestos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdimpuestos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdimpuestos.Location = New System.Drawing.Point(21, 83)
        Me.cmdimpuestos.Name = "cmdimpuestos"
        Me.cmdimpuestos.Size = New System.Drawing.Size(229, 36)
        Me.cmdimpuestos.TabIndex = 18
        Me.cmdimpuestos.Text = "&Impuestos"
        Me.cmdimpuestos.Tooltip = "Impuestos Alt + I"
        '
        'cmdgrupos
        '
        Me.cmdgrupos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdgrupos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdgrupos.Location = New System.Drawing.Point(21, 41)
        Me.cmdgrupos.Name = "cmdgrupos"
        Me.cmdgrupos.Size = New System.Drawing.Size(229, 36)
        Me.cmdgrupos.TabIndex = 17
        Me.cmdgrupos.Text = "&Grupos o Conceptos de Impuestos"
        Me.cmdgrupos.Tooltip = "Grupos o Conceptos Alt + G "
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 168)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(273, 85)
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
        Me.GroupPanel1.TabIndex = 4
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(105, 9)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(65, 66)
        Me.cmdsalir.TabIndex = 3
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'FrmMenuImp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(290, 266)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.g_admin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMenuImp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  Conceptos de Impuestos"
        Me.g_admin.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents g_admin As System.Windows.Forms.GroupBox
    Friend WithEvents cmdreportes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdimpuestos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdgrupos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
End Class
