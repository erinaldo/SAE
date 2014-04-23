<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfTributarios
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdretat = New DevComponents.DotNetBar.ButtonX
        Me.cmdretpt = New DevComponents.DotNetBar.ButtonX
        Me.cmdcuentas = New DevComponents.DotNetBar.ButtonX
        Me.cmdivades = New DevComponents.DotNetBar.ButtonX
        Me.cdmotras = New DevComponents.DotNetBar.ButtonX
        Me.cdmICA = New DevComponents.DotNetBar.ButtonX
        Me.cmdivapp = New DevComponents.DotNetBar.ButtonX
        Me.cmdivaret = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdrtc = New DevComponents.DotNetBar.ButtonX
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdrtc)
        Me.GroupBox3.Controls.Add(Me.cmdretat)
        Me.GroupBox3.Controls.Add(Me.cmdretpt)
        Me.GroupBox3.Controls.Add(Me.cmdcuentas)
        Me.GroupBox3.Controls.Add(Me.cmdivades)
        Me.GroupBox3.Controls.Add(Me.cdmotras)
        Me.GroupBox3.Controls.Add(Me.cdmICA)
        Me.GroupBox3.Controls.Add(Me.cmdivapp)
        Me.GroupBox3.Controls.Add(Me.cmdivaret)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(444, 229)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'cmdretat
        '
        Me.cmdretat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdretat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdretat.Location = New System.Drawing.Point(231, 19)
        Me.cmdretat.Name = "cmdretat"
        Me.cmdretat.Size = New System.Drawing.Size(192, 36)
        Me.cmdretat.TabIndex = 36
        Me.cmdretat.Text = "Retenciones &A Terceros"
        '
        'cmdretpt
        '
        Me.cmdretpt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdretpt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdretpt.Location = New System.Drawing.Point(16, 145)
        Me.cmdretpt.Name = "cmdretpt"
        Me.cmdretpt.Size = New System.Drawing.Size(192, 36)
        Me.cmdretpt.TabIndex = 34
        Me.cmdretpt.Text = "Retenciones Por &Terceros"
        '
        'cmdcuentas
        '
        Me.cmdcuentas.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcuentas.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcuentas.Location = New System.Drawing.Point(16, 19)
        Me.cmdcuentas.Name = "cmdcuentas"
        Me.cmdcuentas.Size = New System.Drawing.Size(192, 36)
        Me.cmdcuentas.TabIndex = 33
        Me.cmdcuentas.Text = "De&finir Cuentas"
        '
        'cmdivades
        '
        Me.cmdivades.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdivades.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdivades.Location = New System.Drawing.Point(16, 103)
        Me.cmdivades.Name = "cmdivades"
        Me.cmdivades.Size = New System.Drawing.Size(192, 36)
        Me.cmdivades.TabIndex = 32
        Me.cmdivades.Text = "IVA  &Descontable"
        '
        'cdmotras
        '
        Me.cdmotras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmotras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmotras.Location = New System.Drawing.Point(115, 187)
        Me.cdmotras.Name = "cdmotras"
        Me.cdmotras.Size = New System.Drawing.Size(192, 36)
        Me.cdmotras.TabIndex = 31
        Me.cdmotras.Text = "&Otras Cuentas"
        '
        'cdmICA
        '
        Me.cdmICA.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmICA.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmICA.Location = New System.Drawing.Point(231, 103)
        Me.cdmICA.Name = "cdmICA"
        Me.cdmICA.Size = New System.Drawing.Size(192, 36)
        Me.cdmICA.TabIndex = 30
        Me.cdmICA.Text = "I&CA Retenido"
        '
        'cmdivapp
        '
        Me.cmdivapp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdivapp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdivapp.Location = New System.Drawing.Point(16, 61)
        Me.cmdivapp.Name = "cmdivapp"
        Me.cmdivapp.Size = New System.Drawing.Size(192, 36)
        Me.cmdivapp.TabIndex = 29
        Me.cmdivapp.Text = "&IVA Por Pagar"
        '
        'cmdivaret
        '
        Me.cmdivaret.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdivaret.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdivaret.Location = New System.Drawing.Point(231, 61)
        Me.cmdivaret.Name = "cmdivaret"
        Me.cmdivaret.Size = New System.Drawing.Size(192, 36)
        Me.cmdivaret.TabIndex = 28
        Me.cmdivaret.Text = "IVA &Retenido"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 247)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(444, 85)
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
        Me.GroupPanel1.TabIndex = 77
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(189, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdrtc
        '
        Me.cmdrtc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdrtc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdrtc.Location = New System.Drawing.Point(231, 145)
        Me.cmdrtc.Name = "cmdrtc"
        Me.cmdrtc.Size = New System.Drawing.Size(192, 36)
        Me.cmdrtc.TabIndex = 37
        Me.cmdrtc.Text = "&Retencion CREE"
        '
        'FrmInfTributarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(468, 335)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfTributarios"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Informes Tributarios"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdretat As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdretpt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdcuentas As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdivades As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdmotras As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdmICA As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdivapp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdivaret As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdrtc As DevComponents.DotNetBar.ButtonX
End Class
