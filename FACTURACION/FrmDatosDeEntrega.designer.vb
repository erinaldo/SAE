<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosDeEntrega
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbform = New System.Windows.Forms.Label
        Me.cmdcontinuar = New System.Windows.Forms.Button
        Me.txtentrega = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtdir = New System.Windows.Forms.TextBox
        Me.txtciudad = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtfecha = New System.Windows.Forms.DateTimePicker
        Me.lbfecha = New System.Windows.Forms.Label
        Me.lborden = New System.Windows.Forms.Label
        Me.txtorden = New System.Windows.Forms.TextBox
        Me.lbtitulo = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmdcontinuar)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 148)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(572, 85)
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
        Me.GroupPanel1.TabIndex = 76
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(130, 30)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 3
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'cmdcontinuar
        '
        Me.cmdcontinuar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcontinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcontinuar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcontinuar.Image = Global.SAE.My.Resources.Resources.continuar
        Me.cmdcontinuar.Location = New System.Drawing.Point(245, 8)
        Me.cmdcontinuar.Name = "cmdcontinuar"
        Me.cmdcontinuar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcontinuar.TabIndex = 2
        Me.cmdcontinuar.Text = "      &C"
        Me.cmdcontinuar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcontinuar, "continuar Alt+C")
        Me.cmdcontinuar.UseVisualStyleBackColor = False
        '
        'txtentrega
        '
        Me.txtentrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtentrega.ForeColor = System.Drawing.Color.Black
        Me.txtentrega.Location = New System.Drawing.Point(84, 39)
        Me.txtentrega.Name = "txtentrega"
        Me.txtentrega.Size = New System.Drawing.Size(486, 20)
        Me.txtentrega.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.txtentrega, "quien recibe el pedido")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(12, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Entregar a"
        '
        'txtdir
        '
        Me.txtdir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdir.ForeColor = System.Drawing.Color.Black
        Me.txtdir.Location = New System.Drawing.Point(84, 65)
        Me.txtdir.Name = "txtdir"
        Me.txtdir.Size = New System.Drawing.Size(486, 20)
        Me.txtdir.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.txtdir, "dirección")
        '
        'txtciudad
        '
        Me.txtciudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtciudad.ForeColor = System.Drawing.Color.Black
        Me.txtciudad.Location = New System.Drawing.Point(84, 91)
        Me.txtciudad.Name = "txtciudad"
        Me.txtciudad.Size = New System.Drawing.Size(486, 20)
        Me.txtciudad.TabIndex = 80
        Me.ToolTip1.SetToolTip(Me.txtciudad, "ciudad")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Dirección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Ciudad"
        '
        'txtfecha
        '
        Me.txtfecha.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha.Location = New System.Drawing.Point(365, 117)
        Me.txtfecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha.TabIndex = 83
        Me.ToolTip1.SetToolTip(Me.txtfecha, "fecha de la orden")
        Me.txtfecha.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'lbfecha
        '
        Me.lbfecha.AutoSize = True
        Me.lbfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbfecha.Location = New System.Drawing.Point(255, 121)
        Me.lbfecha.Name = "lbfecha"
        Me.lbfecha.Size = New System.Drawing.Size(110, 13)
        Me.lbfecha.TabIndex = 84
        Me.lbfecha.Text = "Fecha de la orden"
        '
        'lborden
        '
        Me.lborden.AutoSize = True
        Me.lborden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lborden.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lborden.Location = New System.Drawing.Point(12, 120)
        Me.lborden.Name = "lborden"
        Me.lborden.Size = New System.Drawing.Size(133, 13)
        Me.lborden.TabIndex = 85
        Me.lborden.Text = "Orden de Compra Nro."
        '
        'txtorden
        '
        Me.txtorden.ForeColor = System.Drawing.Color.Black
        Me.txtorden.Location = New System.Drawing.Point(143, 117)
        Me.txtorden.Name = "txtorden"
        Me.txtorden.Size = New System.Drawing.Size(107, 20)
        Me.txtorden.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.txtorden, "orden de compra")
        '
        'lbtitulo
        '
        Me.lbtitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbtitulo.Location = New System.Drawing.Point(15, 9)
        Me.lbtitulo.Name = "lbtitulo"
        Me.lbtitulo.Size = New System.Drawing.Size(555, 20)
        Me.lbtitulo.TabIndex = 87
        Me.lbtitulo.Text = "DATOS DE ENTREGA DEL PEDIDO"
        Me.lbtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmDatosDeEntrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(582, 239)
        Me.Controls.Add(Me.lbtitulo)
        Me.Controls.Add(Me.txtorden)
        Me.Controls.Add(Me.lborden)
        Me.Controls.Add(Me.txtfecha)
        Me.Controls.Add(Me.lbfecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtciudad)
        Me.Controls.Add(Me.txtdir)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtentrega)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDatosDeEntrega"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "   SAE DATOS DE ENTREGA  Continuar=Alt+C"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcontinuar As System.Windows.Forms.Button
    Friend WithEvents txtentrega As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtdir As System.Windows.Forms.TextBox
    Friend WithEvents txtciudad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbfecha As System.Windows.Forms.Label
    Friend WithEvents lborden As System.Windows.Forms.Label
    Friend WithEvents txtorden As System.Windows.Forms.TextBox
    Friend WithEvents lbtitulo As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
