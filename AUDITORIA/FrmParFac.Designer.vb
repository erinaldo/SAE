<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParFac
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParFac))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtreteivaF = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtreteicaF = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtretfuenteF = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtdescuentoF = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtivadF = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtivappF = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtcostoF = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtventasF = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtinventarioF = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtctapcF = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtbancoF = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtcajaF = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdparfac = New System.Windows.Forms.Button
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(516, 48)
        Me.Label2.TabIndex = 268
        Me.Label2.Text = "DEFINA LAS CUENTAS " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA VERIFICAR LOS MOVIMIENTOS CONTABLES EN FACTURACION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtreteivaF
        '
        Me.txtreteivaF.Location = New System.Drawing.Point(385, 207)
        Me.txtreteivaF.Name = "txtreteivaF"
        Me.txtreteivaF.ShortcutsEnabled = False
        Me.txtreteivaF.Size = New System.Drawing.Size(84, 20)
        Me.txtreteivaF.TabIndex = 255
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label40.Location = New System.Drawing.Point(272, 210)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(70, 13)
        Me.Label40.TabIndex = 267
        Me.Label40.Text = "Rete. I.V.A"
        '
        'txtreteicaF
        '
        Me.txtreteicaF.Location = New System.Drawing.Point(385, 179)
        Me.txtreteicaF.Name = "txtreteicaF"
        Me.txtreteicaF.ShortcutsEnabled = False
        Me.txtreteicaF.Size = New System.Drawing.Size(84, 20)
        Me.txtreteicaF.TabIndex = 254
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label39.Location = New System.Drawing.Point(272, 182)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 13)
        Me.Label39.TabIndex = 266
        Me.Label39.Text = "Rete. I.C.A"
        '
        'txtretfuenteF
        '
        Me.txtretfuenteF.Location = New System.Drawing.Point(385, 152)
        Me.txtretfuenteF.Name = "txtretfuenteF"
        Me.txtretfuenteF.ShortcutsEnabled = False
        Me.txtretfuenteF.Size = New System.Drawing.Size(84, 20)
        Me.txtretfuenteF.TabIndex = 253
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(272, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 265
        Me.Label18.Text = "Rete. Fuente"
        '
        'txtdescuentoF
        '
        Me.txtdescuentoF.Location = New System.Drawing.Point(385, 127)
        Me.txtdescuentoF.Name = "txtdescuentoF"
        Me.txtdescuentoF.ShortcutsEnabled = False
        Me.txtdescuentoF.Size = New System.Drawing.Size(84, 20)
        Me.txtdescuentoF.TabIndex = 252
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label19.Location = New System.Drawing.Point(272, 130)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 13)
        Me.Label19.TabIndex = 264
        Me.Label19.Text = "Descuentos"
        '
        'txtivadF
        '
        Me.txtivadF.Location = New System.Drawing.Point(385, 102)
        Me.txtivadF.Name = "txtivadF"
        Me.txtivadF.ShortcutsEnabled = False
        Me.txtivadF.Size = New System.Drawing.Size(84, 20)
        Me.txtivadF.TabIndex = 251
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label20.Location = New System.Drawing.Point(272, 105)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 263
        Me.Label20.Text = "I.V.A descontable"
        '
        'txtivappF
        '
        Me.txtivappF.Location = New System.Drawing.Point(385, 75)
        Me.txtivappF.Name = "txtivappF"
        Me.txtivappF.ShortcutsEnabled = False
        Me.txtivappF.Size = New System.Drawing.Size(84, 20)
        Me.txtivappF.TabIndex = 250
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label22.Location = New System.Drawing.Point(272, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 262
        Me.Label22.Text = "I.V.A por pagar"
        '
        'txtcostoF
        '
        Me.txtcostoF.Location = New System.Drawing.Point(142, 206)
        Me.txtcostoF.Name = "txtcostoF"
        Me.txtcostoF.ShortcutsEnabled = False
        Me.txtcostoF.Size = New System.Drawing.Size(84, 20)
        Me.txtcostoF.TabIndex = 249
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label23.Location = New System.Drawing.Point(35, 209)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 13)
        Me.Label23.TabIndex = 261
        Me.Label23.Text = "Costos de Venta"
        '
        'txtventasF
        '
        Me.txtventasF.Location = New System.Drawing.Point(142, 181)
        Me.txtventasF.Name = "txtventasF"
        Me.txtventasF.ShortcutsEnabled = False
        Me.txtventasF.Size = New System.Drawing.Size(84, 20)
        Me.txtventasF.TabIndex = 248
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label24.Location = New System.Drawing.Point(35, 181)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 260
        Me.Label24.Text = "Ventas"
        '
        'txtinventarioF
        '
        Me.txtinventarioF.Location = New System.Drawing.Point(142, 155)
        Me.txtinventarioF.Name = "txtinventarioF"
        Me.txtinventarioF.ShortcutsEnabled = False
        Me.txtinventarioF.Size = New System.Drawing.Size(84, 20)
        Me.txtinventarioF.TabIndex = 247
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label25.Location = New System.Drawing.Point(35, 158)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 259
        Me.Label25.Text = "Inventarios"
        '
        'txtctapcF
        '
        Me.txtctapcF.Location = New System.Drawing.Point(142, 129)
        Me.txtctapcF.Name = "txtctapcF"
        Me.txtctapcF.ShortcutsEnabled = False
        Me.txtctapcF.Size = New System.Drawing.Size(84, 20)
        Me.txtctapcF.TabIndex = 246
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label26.Location = New System.Drawing.Point(34, 134)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 13)
        Me.Label26.TabIndex = 258
        Me.Label26.Text = "Ctas. Por Cobrar"
        '
        'txtbancoF
        '
        Me.txtbancoF.Location = New System.Drawing.Point(142, 104)
        Me.txtbancoF.Name = "txtbancoF"
        Me.txtbancoF.ShortcutsEnabled = False
        Me.txtbancoF.Size = New System.Drawing.Size(84, 20)
        Me.txtbancoF.TabIndex = 245
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label27.Location = New System.Drawing.Point(35, 107)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(49, 13)
        Me.Label27.TabIndex = 257
        Me.Label27.Text = "Bancos"
        '
        'txtcajaF
        '
        Me.txtcajaF.Location = New System.Drawing.Point(142, 78)
        Me.txtcajaF.Name = "txtcajaF"
        Me.txtcajaF.ShortcutsEnabled = False
        Me.txtcajaF.Size = New System.Drawing.Size(84, 20)
        Me.txtcajaF.TabIndex = 244
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label28.Location = New System.Drawing.Point(35, 81)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 13)
        Me.Label28.TabIndex = 256
        Me.Label28.Text = "Caja"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Button1)
        Me.GroupPanel3.Controls.Add(Me.cmdparfac)
        Me.GroupPanel3.Location = New System.Drawing.Point(7, 239)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(513, 78)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel3.TabIndex = 243
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = Global.SAE.My.Resources.Resources.cparam
        Me.Button1.Location = New System.Drawing.Point(255, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 68)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&c"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdparfac
        '
        Me.cmdparfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdparfac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdparfac.ForeColor = System.Drawing.Color.Transparent
        Me.cmdparfac.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdparfac.Location = New System.Drawing.Point(166, 3)
        Me.cmdparfac.Name = "cmdparfac"
        Me.cmdparfac.Size = New System.Drawing.Size(72, 68)
        Me.cmdparfac.TabIndex = 0
        Me.cmdparfac.Text = "      &g"
        Me.cmdparfac.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdparfac.UseVisualStyleBackColor = False
        '
        'FrmParFac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(523, 323)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtreteivaF)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.txtreteicaF)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.txtretfuenteF)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtdescuentoF)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtivadF)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtivappF)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtcostoF)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtventasF)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtinventarioF)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtctapcF)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtbancoF)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtcajaF)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GroupPanel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParFac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auditoria Documentos Facturacion"
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtreteivaF As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtreteicaF As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmdparfac As System.Windows.Forms.Button
    Friend WithEvents txtretfuenteF As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtdescuentoF As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtivadF As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtivappF As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtcostoF As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtventasF As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtinventarioF As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtctapcF As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtbancoF As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtcajaF As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
End Class
