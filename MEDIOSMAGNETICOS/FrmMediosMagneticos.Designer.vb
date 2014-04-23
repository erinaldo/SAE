<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMediosMagneticos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMediosMagneticos))
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.datosbac = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.cmdPCar = New DevComponents.DotNetBar.ButtonX
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.salir = New System.Windows.Forms.Button
        Me.cmdayuda = New System.Windows.Forms.Button
        Me.cmdsoptec = New System.Windows.Forms.Button
        Me.cmdweb = New System.Windows.Forms.Button
        Me.cmdbackup = New System.Windows.Forms.Button
        Me.cmdperio = New System.Windows.Forms.Button
        Me.cmdcompa = New System.Windows.Forms.Button
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel3
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Procesos"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel3.Controls.Add(Me.Label2)
        Me.TabControlPanel3.Controls.Add(Me.Label3)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(733, 274)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 2
        Me.TabControlPanel3.TabItem = Me.TabItem2
        '
        'datosbac
        '
        Me.datosbac.AttachedControl = Me.TabControlPanel1
        Me.datosbac.Name = "datosbac"
        Me.datosbac.Text = "Datos Basicos"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel1.Controls.Add(Me.cmdPCar)
        Me.TabControlPanel1.Controls.Add(Me.Label1)
        Me.TabControlPanel1.Controls.Add(Me.Label7)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(733, 274)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.datosbac
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(249, 136)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(210, 36)
        Me.ButtonX1.TabIndex = 29
        Me.ButtonX1.Text = "Asignar Cuentas a Conceptos"
        '
        'cmdPCar
        '
        Me.cmdPCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdPCar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdPCar.Location = New System.Drawing.Point(248, 94)
        Me.cmdPCar.Name = "cmdPCar"
        Me.cmdPCar.Size = New System.Drawing.Size(210, 36)
        Me.cmdPCar.TabIndex = 28
        Me.cmdPCar.Text = "Asignar Valor Minimo a Conceptos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(164, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(438, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Medios Magneticos- Datos Basicos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(54, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(627, 42)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "_____________________________"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.salir)
        Me.GroupPanel1.Controls.Add(Me.cmdayuda)
        Me.GroupPanel1.Controls.Add(Me.cmdsoptec)
        Me.GroupPanel1.Controls.Add(Me.cmdweb)
        Me.GroupPanel1.Controls.Add(Me.cmdbackup)
        Me.GroupPanel1.Controls.Add(Me.cmdperio)
        Me.GroupPanel1.Controls.Add(Me.cmdcompa)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 3)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(733, 85)
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
        Me.GroupPanel1.TabIndex = 8
        '
        'salir
        '
        Me.salir.BackColor = System.Drawing.Color.White
        Me.salir.Image = Global.SAE.My.Resources.Resources.atras
        Me.salir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.salir.Location = New System.Drawing.Point(533, 8)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(66, 68)
        Me.salir.TabIndex = 14
        Me.salir.UseVisualStyleBackColor = False
        '
        'cmdayuda
        '
        Me.cmdayuda.BackColor = System.Drawing.Color.White
        Me.cmdayuda.Image = Global.SAE.My.Resources.Resources.ayuda
        Me.cmdayuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdayuda.Location = New System.Drawing.Point(461, 8)
        Me.cmdayuda.Name = "cmdayuda"
        Me.cmdayuda.Size = New System.Drawing.Size(66, 68)
        Me.cmdayuda.TabIndex = 13
        Me.cmdayuda.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdayuda.UseVisualStyleBackColor = False
        '
        'cmdsoptec
        '
        Me.cmdsoptec.BackColor = System.Drawing.Color.White
        Me.cmdsoptec.Image = Global.SAE.My.Resources.Resources.soporte
        Me.cmdsoptec.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdsoptec.Location = New System.Drawing.Point(389, 8)
        Me.cmdsoptec.Name = "cmdsoptec"
        Me.cmdsoptec.Size = New System.Drawing.Size(66, 68)
        Me.cmdsoptec.TabIndex = 12
        Me.cmdsoptec.UseVisualStyleBackColor = False
        '
        'cmdweb
        '
        Me.cmdweb.BackColor = System.Drawing.Color.White
        Me.cmdweb.Image = Global.SAE.My.Resources.Resources.web
        Me.cmdweb.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdweb.Location = New System.Drawing.Point(317, 8)
        Me.cmdweb.Name = "cmdweb"
        Me.cmdweb.Size = New System.Drawing.Size(66, 68)
        Me.cmdweb.TabIndex = 11
        Me.cmdweb.UseVisualStyleBackColor = False
        '
        'cmdbackup
        '
        Me.cmdbackup.BackColor = System.Drawing.Color.White
        Me.cmdbackup.Image = Global.SAE.My.Resources.Resources.backup
        Me.cmdbackup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdbackup.Location = New System.Drawing.Point(246, 8)
        Me.cmdbackup.Name = "cmdbackup"
        Me.cmdbackup.Size = New System.Drawing.Size(66, 68)
        Me.cmdbackup.TabIndex = 10
        Me.cmdbackup.UseVisualStyleBackColor = False
        '
        'cmdperio
        '
        Me.cmdperio.BackColor = System.Drawing.Color.White
        Me.cmdperio.Image = Global.SAE.My.Resources.Resources.periodo
        Me.cmdperio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdperio.Location = New System.Drawing.Point(174, 8)
        Me.cmdperio.Name = "cmdperio"
        Me.cmdperio.Size = New System.Drawing.Size(66, 68)
        Me.cmdperio.TabIndex = 9
        Me.cmdperio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdperio.UseVisualStyleBackColor = False
        '
        'cmdcompa
        '
        Me.cmdcompa.BackColor = System.Drawing.Color.White
        Me.cmdcompa.Image = Global.SAE.My.Resources.Resources.abrir2
        Me.cmdcompa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdcompa.Location = New System.Drawing.Point(102, 8)
        Me.cmdcompa.Name = "cmdcompa"
        Me.cmdcompa.Size = New System.Drawing.Size(66, 68)
        Me.cmdcompa.TabIndex = 8
        Me.cmdcompa.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.CloseButtonVisible = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Location = New System.Drawing.Point(7, 94)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(733, 300)
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.datosbac)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(248, 109)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(210, 36)
        Me.ButtonX2.TabIndex = 31
        Me.ButtonX2.Text = "Generar Formatos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(164, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(438, 31)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Medios Magneticos- Datos Basicos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(54, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(627, 42)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "_____________________________"
        '
        'FrmMediosMagneticos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(745, 399)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMediosMagneticos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medios Magneticos"
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents datosbac As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdPCar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdcompa As System.Windows.Forms.Button
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdayuda As System.Windows.Forms.Button
    Friend WithEvents cmdsoptec As System.Windows.Forms.Button
    Friend WithEvents cmdweb As System.Windows.Forms.Button
    Friend WithEvents cmdbackup As System.Windows.Forms.Button
    Friend WithEvents cmdperio As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
