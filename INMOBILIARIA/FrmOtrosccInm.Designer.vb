<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOtrosccInm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOtrosccInm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdcontinuar = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.cmdImpuestos = New System.Windows.Forms.Button
        Me.lbform = New System.Windows.Forms.Label
        Me.lbdoc3 = New System.Windows.Forms.Label
        Me.G2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbdoc2 = New System.Windows.Forms.Label
        Me.lbdoc1 = New System.Windows.Forms.Label
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.txt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.afecta = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.cont2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dia = New System.Windows.Forms.DataGridViewComboBoxColumn
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.G2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdcontinuar
        '
        Me.cmdcontinuar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcontinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcontinuar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcontinuar.Image = Global.SAE.My.Resources.Resources.continuar
        Me.cmdcontinuar.Location = New System.Drawing.Point(418, 2)
        Me.cmdcontinuar.Name = "cmdcontinuar"
        Me.cmdcontinuar.Size = New System.Drawing.Size(69, 73)
        Me.cmdcontinuar.TabIndex = 0
        Me.cmdcontinuar.Text = "&c"
        Me.cmdcontinuar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcontinuar, "Continuar Alt + C")
        Me.cmdcontinuar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SAE.My.Resources.Resources.cparam
        Me.Button1.Location = New System.Drawing.Point(493, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 73)
        Me.Button1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.Button1, "Salir sin Guardar Alt + F4 ")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'grilla
        '
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.grilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.sel, Me.tipo, Me.txt, Me.valor, Me.base, Me.cta, Me.afecta, Me.cont2, Me.dia})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(10, 9)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.RowHeadersVisible = False
        Me.grilla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(969, 173)
        Me.grilla.TabIndex = 4
        '
        'cmdImpuestos
        '
        Me.cmdImpuestos.Location = New System.Drawing.Point(428, 22)
        Me.cmdImpuestos.Name = "cmdImpuestos"
        Me.cmdImpuestos.Size = New System.Drawing.Size(48, 34)
        Me.cmdImpuestos.TabIndex = 6
        Me.cmdImpuestos.Text = "&I"
        Me.cmdImpuestos.UseVisualStyleBackColor = True
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(543, 28)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 1
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'lbdoc3
        '
        Me.lbdoc3.AutoSize = True
        Me.lbdoc3.BackColor = System.Drawing.Color.White
        Me.lbdoc3.ForeColor = System.Drawing.Color.Crimson
        Me.lbdoc3.Location = New System.Drawing.Point(6, 49)
        Me.lbdoc3.Name = "lbdoc3"
        Me.lbdoc3.Size = New System.Drawing.Size(31, 13)
        Me.lbdoc3.TabIndex = 5
        Me.lbdoc3.Text = "doc3"
        Me.lbdoc3.Visible = False
        '
        'G2
        '
        Me.G2.CanvasColor = System.Drawing.SystemColors.Control
        Me.G2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.G2.Controls.Add(Me.Label1)
        Me.G2.Controls.Add(Me.lbdoc3)
        Me.G2.Controls.Add(Me.lbdoc2)
        Me.G2.Controls.Add(Me.lbdoc1)
        Me.G2.Controls.Add(Me.Button1)
        Me.G2.Controls.Add(Me.lbform)
        Me.G2.Controls.Add(Me.cmdcontinuar)
        Me.G2.Controls.Add(Me.cmdImpuestos)
        Me.G2.Location = New System.Drawing.Point(9, 188)
        Me.G2.Name = "G2"
        Me.G2.Size = New System.Drawing.Size(970, 83)
        '
        '
        '
        Me.G2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.G2.Style.BackColorGradientAngle = 90
        Me.G2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.G2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderBottomWidth = 1
        Me.G2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.G2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderLeftWidth = 1
        Me.G2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderRightWidth = 1
        Me.G2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.G2.Style.BorderTopWidth = 1
        Me.G2.Style.CornerDiameter = 4
        Me.G2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.G2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.G2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.G2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.G2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(39, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 39)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Para conceptos de tipo ""+"" :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Se creara el asiento Credito (-)  , digite la cuent" & _
            "a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y seleccione CONTAB para que afecte solo en contabilidad"
        '
        'lbdoc2
        '
        Me.lbdoc2.AutoSize = True
        Me.lbdoc2.BackColor = System.Drawing.Color.White
        Me.lbdoc2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbdoc2.Location = New System.Drawing.Point(5, 28)
        Me.lbdoc2.Name = "lbdoc2"
        Me.lbdoc2.Size = New System.Drawing.Size(31, 13)
        Me.lbdoc2.TabIndex = 4
        Me.lbdoc2.Text = "doc2"
        Me.lbdoc2.Visible = False
        '
        'lbdoc1
        '
        Me.lbdoc1.AutoSize = True
        Me.lbdoc1.BackColor = System.Drawing.Color.White
        Me.lbdoc1.ForeColor = System.Drawing.Color.Orange
        Me.lbdoc1.Location = New System.Drawing.Point(6, 3)
        Me.lbdoc1.Name = "lbdoc1"
        Me.lbdoc1.Size = New System.Drawing.Size(31, 13)
        Me.lbdoc1.TabIndex = 3
        Me.lbdoc1.Text = "doc1"
        Me.lbdoc1.Visible = False
        '
        'num
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
        Me.num.Frozen = True
        Me.num.HeaderText = "   ITEM"
        Me.num.MinimumWidth = 60
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Visible = False
        Me.num.Width = 60
        '
        'sel
        '
        Me.sel.HeaderText = "SEL"
        Me.sel.MinimumWidth = 30
        Me.sel.Name = "sel"
        Me.sel.Width = 30
        '
        'tipo
        '
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.Items.AddRange(New Object() {"", "+", "-"})
        Me.tipo.MinimumWidth = 50
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 50
        '
        'txt
        '
        DataGridViewCellStyle2.NullValue = " "
        Me.txt.DefaultCellStyle = DataGridViewCellStyle2
        Me.txt.HeaderText = "DESCRIPCION"
        Me.txt.MinimumWidth = 250
        Me.txt.Name = "txt"
        Me.txt.Width = 250
        '
        'valor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.valor.HeaderText = "VALOR"
        Me.valor.MinimumWidth = 110
        Me.valor.Name = "valor"
        Me.valor.Width = 150
        '
        'base
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.base.DefaultCellStyle = DataGridViewCellStyle4
        Me.base.HeaderText = "BASE"
        Me.base.MinimumWidth = 110
        Me.base.Name = "base"
        Me.base.Width = 110
        '
        'cta
        '
        Me.cta.HeaderText = "CUENTA"
        Me.cta.MinimumWidth = 100
        Me.cta.Name = "cta"
        '
        'afecta
        '
        Me.afecta.HeaderText = "AFECTA"
        Me.afecta.Items.AddRange(New Object() {"ARRENDATARIO", "PROPIETARIO"})
        Me.afecta.Name = "afecta"
        Me.afecta.Width = 110
        '
        'cont2
        '
        Me.cont2.HeaderText = "TIPO MOV"
        Me.cont2.Items.AddRange(New Object() {"SOLO CONTB", "CONT-FACT", "SOLO FACT"})
        Me.cont2.MinimumWidth = 100
        Me.cont2.Name = "cont2"
        '
        'dia
        '
        Me.dia.HeaderText = "DIAS"
        Me.dia.Items.AddRange(New Object() {"SI", "NO"})
        Me.dia.MinimumWidth = 50
        Me.dia.Name = "dia"
        Me.dia.Width = 50
        '
        'FrmOtrosccInm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(984, 278)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.G2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOtrosccInm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Otros Conceptos Inmobiliaria"
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.G2.ResumeLayout(False)
        Me.G2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdcontinuar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents cmdImpuestos As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents lbdoc3 As System.Windows.Forms.Label
    Friend WithEvents G2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbdoc2 As System.Windows.Forms.Label
    Friend WithEvents lbdoc1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents afecta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cont2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dia As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
