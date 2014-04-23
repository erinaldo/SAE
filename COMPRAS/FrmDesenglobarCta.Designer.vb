<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesenglobarCta
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbcr = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbnum = New System.Windows.Forms.Label
        Me.lbnomdoc = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.lbfila = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbdb = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbnombre = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbcta = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbter = New System.Windows.Forms.Label
        Me.lbcta2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lbcr)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbper)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbnum)
        Me.GroupBox1.Controls.Add(Me.lbnomdoc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbdoc)
        Me.GroupBox1.Controls.Add(Me.lbform)
        Me.GroupBox1.Controls.Add(Me.lbfila)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbdb)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbnombre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbcta)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(862, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS GENERALES"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label7.Location = New System.Drawing.Point(465, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(181, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "TOTAL MOV. CREDITO $"
        '
        'lbcr
        '
        Me.lbcr.AutoSize = True
        Me.lbcr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcr.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbcr.Location = New System.Drawing.Point(646, 84)
        Me.lbcr.Name = "lbcr"
        Me.lbcr.Size = New System.Drawing.Size(29, 16)
        Me.lbcr.TabIndex = 15
        Me.lbcr.Text = "cta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(181, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "DEL PERIODO"
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(296, 144)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(61, 16)
        Me.lbper.TabIndex = 13
        Me.lbper.Text = "00/0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "NUMERO:"
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnum.Location = New System.Drawing.Point(94, 144)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(48, 16)
        Me.lbnum.TabIndex = 11
        Me.lbnum.Text = "00000"
        '
        'lbnomdoc
        '
        Me.lbnomdoc.AutoSize = True
        Me.lbnomdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnomdoc.Location = New System.Drawing.Point(155, 115)
        Me.lbnomdoc.Name = "lbnomdoc"
        Me.lbnomdoc.Size = New System.Drawing.Size(73, 16)
        Me.lbnomdoc.TabIndex = 10
        Me.lbnomdoc.Text = "NOMBRE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "DOCUMENTO:"
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(120, 115)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(29, 16)
        Me.lbdoc.TabIndex = 8
        Me.lbdoc.Text = "CG"
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(651, 24)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(55, 13)
        Me.lbform.TabIndex = 7
        Me.lbform.Text = "Formulario"
        Me.lbform.Visible = False
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(566, 24)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(25, 13)
        Me.lbfila.TabIndex = 6
        Me.lbfila.Text = "000"
        Me.lbfila.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label3.Location = New System.Drawing.Point(9, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TOTAL MOV. DEBITO $"
        '
        'lbdb
        '
        Me.lbdb.AutoSize = True
        Me.lbdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdb.ForeColor = System.Drawing.Color.ForestGreen
        Me.lbdb.Location = New System.Drawing.Point(181, 84)
        Me.lbdb.Name = "lbdb"
        Me.lbdb.Size = New System.Drawing.Size(29, 16)
        Me.lbdb.TabIndex = 4
        Me.lbdb.Text = "cta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "DESCRIPCION:"
        '
        'lbnombre
        '
        Me.lbnombre.AutoSize = True
        Me.lbnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnombre.Location = New System.Drawing.Point(125, 52)
        Me.lbnombre.Name = "lbnombre"
        Me.lbnombre.Size = New System.Drawing.Size(29, 16)
        Me.lbnombre.TabIndex = 2
        Me.lbnombre.Text = "cta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CUENTA:"
        '
        'lbcta
        '
        Me.lbcta.AutoSize = True
        Me.lbcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcta.Location = New System.Drawing.Point(85, 24)
        Me.lbcta.Name = "lbcta"
        Me.lbcta.Size = New System.Drawing.Size(29, 16)
        Me.lbcta.TabIndex = 0
        Me.lbcta.Text = "cta"
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.Cuenta, Me.Base, Me.Nit})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(7, 191)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(862, 192)
        Me.grilla.TabIndex = 12
        '
        'Descripcion
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.Frozen = True
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.MinimumWidth = 250
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 250
        '
        'Debitos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debitos.Frozen = True
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.MinimumWidth = 170
        Me.Debitos.Name = "Debitos"
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Debitos.Width = 170
        '
        'Creditos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Creditos.Frozen = True
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.MinimumWidth = 170
        Me.Creditos.Name = "Creditos"
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Creditos.Width = 170
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.Frozen = True
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MaxInputLength = 12
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Width = 80
        '
        'Base
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Base.DefaultCellStyle = DataGridViewCellStyle4
        Me.Base.FillWeight = 80.0!
        Me.Base.Frozen = True
        Me.Base.HeaderText = "Base"
        Me.Base.MaxInputLength = 30
        Me.Base.MinimumWidth = 170
        Me.Base.Name = "Base"
        Me.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Base.Width = 170
        '
        'Nit
        '
        Me.Nit.HeaderText = "Nit"
        Me.Nit.MaxInputLength = 20
        Me.Nit.MinimumWidth = 100
        Me.Nit.Name = "Nit"
        Me.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nit.Visible = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.cmdguardar)
        Me.GroupPanel2.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel2.Location = New System.Drawing.Point(7, 431)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(862, 85)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.TabIndex = 77
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(354, 5)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 99
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(430, 5)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 100
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "TERCERO"
        '
        'lbter
        '
        Me.lbter.AutoSize = True
        Me.lbter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbter.Location = New System.Drawing.Point(100, 386)
        Me.lbter.Name = "lbter"
        Me.lbter.Size = New System.Drawing.Size(150, 16)
        Me.lbter.TabIndex = 17
        Me.lbter.Text = "NOMBRE TERCERO"
        '
        'lbcta2
        '
        Me.lbcta2.AutoSize = True
        Me.lbcta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcta2.Location = New System.Drawing.Point(154, 407)
        Me.lbcta2.Name = "lbcta2"
        Me.lbcta2.Size = New System.Drawing.Size(0, 16)
        Me.lbcta2.TabIndex = 79
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 407)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 16)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Cuenta Contable"
        '
        'FrmDesenglobarCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(876, 521)
        Me.Controls.Add(Me.lbcta2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbter)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmDesenglobarCta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Desenglobar Cuenta Contable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbdb As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbnombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbcta As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents lbnomdoc As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbcr As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbter As System.Windows.Forms.Label
    Friend WithEvents lbcta2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nit As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
