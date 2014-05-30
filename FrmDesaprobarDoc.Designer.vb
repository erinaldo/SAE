<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesaprobarDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDesaprobarDoc))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtCxP = New DevComponents.DotNetBar.ButtonX
        Me.BtFP = New DevComponents.DotNetBar.ButtonX
        Me.BtRc = New DevComponents.DotNetBar.ButtonX
        Me.BtInv = New DevComponents.DotNetBar.ButtonX
        Me.BtFv = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtCxP)
        Me.GroupBox1.Controls.Add(Me.BtFP)
        Me.GroupBox1.Controls.Add(Me.BtRc)
        Me.GroupBox1.Controls.Add(Me.BtInv)
        Me.GroupBox1.Controls.Add(Me.BtFv)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 275)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BtCxP
        '
        Me.BtCxP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtCxP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtCxP.Location = New System.Drawing.Point(89, 219)
        Me.BtCxP.Name = "BtCxP"
        Me.BtCxP.Size = New System.Drawing.Size(218, 44)
        Me.BtCxP.TabIndex = 29
        Me.BtCxP.Text = "Documentos de Comprobantes de CxP"
        '
        'BtFP
        '
        Me.BtFP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtFP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtFP.Location = New System.Drawing.Point(89, 169)
        Me.BtFP.Name = "BtFP"
        Me.BtFP.Size = New System.Drawing.Size(218, 44)
        Me.BtFP.TabIndex = 28
        Me.BtFP.Text = "Documentos de Factura de Compras"
        '
        'BtRc
        '
        Me.BtRc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtRc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtRc.Location = New System.Drawing.Point(89, 119)
        Me.BtRc.Name = "BtRc"
        Me.BtRc.Size = New System.Drawing.Size(218, 44)
        Me.BtRc.TabIndex = 27
        Me.BtRc.Text = "Documentos de Cartera(Recibos de Pago)"
        '
        'BtInv
        '
        Me.BtInv.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtInv.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtInv.Location = New System.Drawing.Point(89, 69)
        Me.BtInv.Name = "BtInv"
        Me.BtInv.Size = New System.Drawing.Size(218, 44)
        Me.BtInv.TabIndex = 26
        Me.BtInv.Text = "Documentos de Inventario"
        '
        'BtFv
        '
        Me.BtFv.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtFv.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtFv.Location = New System.Drawing.Point(89, 18)
        Me.BtFv.Name = "BtFv"
        Me.BtFv.Size = New System.Drawing.Size(218, 44)
        Me.BtFv.TabIndex = 25
        Me.BtFv.Text = "Documentos de Facturacion"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 287)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(413, 83)
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
        Me.GroupPanel1.TabIndex = 85
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(162, 5)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(74, 61)
        Me.cmdsalir.TabIndex = 15
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'FrmDesaprobarDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(426, 376)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDesaprobarDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Desaprobar Documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtFv As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtCxP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtFP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtRc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtInv As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
End Class
