<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOtrosDocumentos
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
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.g_auditoria = New System.Windows.Forms.GroupBox
        Me.cmdcd = New DevComponents.DotNetBar.ButtonX
        Me.cmdncredito = New DevComponents.DotNetBar.ButtonX
        Me.cmdndebito = New DevComponents.DotNetBar.ButtonX
        Me.g_admin = New System.Windows.Forms.GroupBox
        Me.cmdcaja = New DevComponents.DotNetBar.ButtonX
        Me.cmdingresos = New DevComponents.DotNetBar.ButtonX
        Me.cmdegresos = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdpara = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.g_auditoria.SuspendLayout()
        Me.g_admin.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonX1)
        Me.GroupBox1.Controls.Add(Me.g_auditoria)
        Me.GroupBox1.Controls.Add(Me.g_admin)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 230)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(142, 187)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(186, 32)
        Me.ButtonX1.TabIndex = 20
        Me.ButtonX1.Text = "&Imprimir Documentos"
        Me.ButtonX1.Tooltip = "Recibo de Caja Alt +R"
        '
        'g_auditoria
        '
        Me.g_auditoria.Controls.Add(Me.cmdcd)
        Me.g_auditoria.Controls.Add(Me.cmdncredito)
        Me.g_auditoria.Controls.Add(Me.cmdndebito)
        Me.g_auditoria.Location = New System.Drawing.Point(240, 19)
        Me.g_auditoria.Name = "g_auditoria"
        Me.g_auditoria.Size = New System.Drawing.Size(227, 164)
        Me.g_auditoria.TabIndex = 1
        Me.g_auditoria.TabStop = False
        Me.g_auditoria.Text = "Contabilidad y Auditoria"
        '
        'cmdcd
        '
        Me.cmdcd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcd.Location = New System.Drawing.Point(18, 113)
        Me.cmdcd.Name = "cmdcd"
        Me.cmdcd.Size = New System.Drawing.Size(192, 36)
        Me.cmdcd.TabIndex = 19
        Me.cmdcd.Text = "Co&mprobante Diario"
        Me.ToolTip1.SetToolTip(Me.cmdcd, "Comprobante Diario Alt +M")
        '
        'cmdncredito
        '
        Me.cmdncredito.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdncredito.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdncredito.Location = New System.Drawing.Point(18, 71)
        Me.cmdncredito.Name = "cmdncredito"
        Me.cmdncredito.Size = New System.Drawing.Size(192, 36)
        Me.cmdncredito.TabIndex = 18
        Me.cmdncredito.Text = "Nota &Credito"
        Me.ToolTip1.SetToolTip(Me.cmdncredito, "Nota Credito Alt + C")
        '
        'cmdndebito
        '
        Me.cmdndebito.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdndebito.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdndebito.Location = New System.Drawing.Point(18, 29)
        Me.cmdndebito.Name = "cmdndebito"
        Me.cmdndebito.Size = New System.Drawing.Size(192, 36)
        Me.cmdndebito.TabIndex = 17
        Me.cmdndebito.Text = "Nota &Debito"
        Me.ToolTip1.SetToolTip(Me.cmdndebito, "Nota Debito Alt + D")
        '
        'g_admin
        '
        Me.g_admin.Controls.Add(Me.cmdcaja)
        Me.g_admin.Controls.Add(Me.cmdingresos)
        Me.g_admin.Controls.Add(Me.cmdegresos)
        Me.g_admin.Location = New System.Drawing.Point(8, 19)
        Me.g_admin.Name = "g_admin"
        Me.g_admin.Size = New System.Drawing.Size(227, 164)
        Me.g_admin.TabIndex = 0
        Me.g_admin.TabStop = False
        Me.g_admin.Text = "Administración Financiera"
        '
        'cmdcaja
        '
        Me.cmdcaja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcaja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcaja.Location = New System.Drawing.Point(18, 113)
        Me.cmdcaja.Name = "cmdcaja"
        Me.cmdcaja.Size = New System.Drawing.Size(192, 36)
        Me.cmdcaja.TabIndex = 19
        Me.cmdcaja.Text = "&Recibo de Caja"
        Me.cmdcaja.Tooltip = "Recibo de Caja Alt +R"
        '
        'cmdingresos
        '
        Me.cmdingresos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdingresos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdingresos.Location = New System.Drawing.Point(18, 71)
        Me.cmdingresos.Name = "cmdingresos"
        Me.cmdingresos.Size = New System.Drawing.Size(192, 36)
        Me.cmdingresos.TabIndex = 18
        Me.cmdingresos.Text = "Comprobante de &Ingresos"
        Me.ToolTip1.SetToolTip(Me.cmdingresos, "Comprobante de Ingresos Alt +I")
        '
        'cmdegresos
        '
        Me.cmdegresos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdegresos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdegresos.Location = New System.Drawing.Point(18, 29)
        Me.cmdegresos.Name = "cmdegresos"
        Me.cmdegresos.Size = New System.Drawing.Size(192, 36)
        Me.cmdegresos.TabIndex = 17
        Me.cmdegresos.Text = "Comprobante de &Egresos"
        Me.cmdegresos.Tooltip = "Comprobante de Egresos Alt+E"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdpara)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(10, 228)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(476, 85)
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
        Me.GroupPanel1.TabIndex = 3
        '
        'cmdpara
        '
        Me.cmdpara.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpara.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpara.Image = Global.SAE.My.Resources.Resources.parametros
        Me.cmdpara.Location = New System.Drawing.Point(166, 6)
        Me.cmdpara.Name = "cmdpara"
        Me.cmdpara.Size = New System.Drawing.Size(72, 68)
        Me.cmdpara.TabIndex = 0
        Me.cmdpara.Text = "&P"
        Me.cmdpara.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpara, "Parametros Alt + P")
        Me.cmdpara.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(238, 6)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(72, 68)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt+F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'FrmOtrosDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(495, 318)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOtrosDocumentos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Otros Documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.g_auditoria.ResumeLayout(False)
        Me.g_admin.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents g_admin As System.Windows.Forms.GroupBox
    Friend WithEvents g_auditoria As System.Windows.Forms.GroupBox
    Friend WithEvents cmdcd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdncredito As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdndebito As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdcaja As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdingresos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdegresos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdpara As System.Windows.Forms.Button
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
