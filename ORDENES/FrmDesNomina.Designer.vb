<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDesNomina
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDesNomina))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmddes = New System.Windows.Forms.Button
        Me.lbter = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbtotal = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.tercero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.db = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbvalor = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbcta = New System.Windows.Forms.Label
        Me.ee = New System.Windows.Forms.Label
        Me.lbcuenta = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.nomina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.periodo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.documento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.inicio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dg = New System.Windows.Forms.DataGridViewButtonColumn
        Me.lbsel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmddes)
        Me.GroupBox1.Controls.Add(Me.lbter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbdoc)
        Me.GroupBox1.Controls.Add(Me.lbtotal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.gitems)
        Me.GroupBox1.Controls.Add(Me.lbvalor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbcta)
        Me.GroupBox1.Controls.Add(Me.ee)
        Me.GroupBox1.Controls.Add(Me.lbcuenta)
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.lbsel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbper)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(744, 535)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cmddes
        '
        Me.cmddes.Enabled = False
        Me.cmddes.Location = New System.Drawing.Point(328, 506)
        Me.cmddes.Name = "cmddes"
        Me.cmddes.Size = New System.Drawing.Size(98, 23)
        Me.cmddes.TabIndex = 89
        Me.cmddes.Text = "DesenGlobar"
        Me.cmddes.UseVisualStyleBackColor = True
        '
        'lbter
        '
        Me.lbter.AutoSize = True
        Me.lbter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbter.Location = New System.Drawing.Point(16, 489)
        Me.lbter.Name = "lbter"
        Me.lbter.Size = New System.Drawing.Size(40, 16)
        Me.lbter.TabIndex = 88
        Me.lbter.Text = "++++"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Documento"
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(355, 25)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(71, 15)
        Me.lbdoc.TabIndex = 86
        Me.lbdoc.Text = "++++++++"
        '
        'lbtotal
        '
        Me.lbtotal.AutoSize = True
        Me.lbtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtotal.Location = New System.Drawing.Point(602, 489)
        Me.lbtotal.Name = "lbtotal"
        Me.lbtotal.Size = New System.Drawing.Size(71, 15)
        Me.lbtotal.TabIndex = 85
        Me.lbtotal.Text = "++++++++"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(540, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Total $"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(294, 277)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 16)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Detalles por Terceros"
        '
        'gitems
        '
        Me.gitems.AllowDrop = True
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tercero, Me.nit, Me.db, Me.cr, Me.cta})
        Me.gitems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gitems.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.gitems.Location = New System.Drawing.Point(15, 297)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gitems.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.gitems.RowHeadersVisible = False
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(715, 177)
        Me.gitems.TabIndex = 82
        '
        'tercero
        '
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tercero.DefaultCellStyle = DataGridViewCellStyle8
        Me.tercero.FillWeight = 180.0!
        Me.tercero.HeaderText = "Tercero"
        Me.tercero.MaxInputLength = 50
        Me.tercero.Name = "tercero"
        Me.tercero.ReadOnly = True
        Me.tercero.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tercero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tercero.Width = 250
        '
        'nit
        '
        Me.nit.FillWeight = 80.0!
        Me.nit.HeaderText = "Nit"
        Me.nit.MaxInputLength = 12
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nit.Width = 80
        '
        'db
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.db.DefaultCellStyle = DataGridViewCellStyle9
        Me.db.FillWeight = 80.0!
        Me.db.HeaderText = "Debito"
        Me.db.MaxInputLength = 30
        Me.db.MinimumWidth = 120
        Me.db.Name = "db"
        Me.db.ReadOnly = True
        Me.db.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.db.Width = 120
        '
        'cr
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cr.DefaultCellStyle = DataGridViewCellStyle10
        Me.cr.HeaderText = "Credito"
        Me.cr.MaxInputLength = 20
        Me.cr.MinimumWidth = 120
        Me.cr.Name = "cr"
        Me.cr.ReadOnly = True
        Me.cr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cr.Width = 120
        '
        'cta
        '
        Me.cta.HeaderText = "Cuenta"
        Me.cta.MinimumWidth = 120
        Me.cta.Name = "cta"
        Me.cta.ReadOnly = True
        Me.cta.Width = 120
        '
        'lbvalor
        '
        Me.lbvalor.AutoSize = True
        Me.lbvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbvalor.Location = New System.Drawing.Point(188, 88)
        Me.lbvalor.Name = "lbvalor"
        Me.lbvalor.Size = New System.Drawing.Size(71, 15)
        Me.lbvalor.TabIndex = 81
        Me.lbvalor.Text = "++++++++"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 16)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Valor a DesenGlobar $"
        '
        'lbcta
        '
        Me.lbcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcta.Location = New System.Drawing.Point(602, 16)
        Me.lbcta.Name = "lbcta"
        Me.lbcta.Size = New System.Drawing.Size(128, 16)
        Me.lbcta.TabIndex = 79
        Me.lbcta.Text = "+++"
        Me.lbcta.Visible = False
        '
        'ee
        '
        Me.ee.AutoSize = True
        Me.ee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ee.Location = New System.Drawing.Point(16, 54)
        Me.ee.Name = "ee"
        Me.ee.Size = New System.Drawing.Size(165, 16)
        Me.ee.TabIndex = 78
        Me.ee.Text = "Cuenta a DesenGlobar"
        '
        'lbcuenta
        '
        Me.lbcuenta.AutoSize = True
        Me.lbcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcuenta.Location = New System.Drawing.Point(187, 55)
        Me.lbcuenta.Name = "lbcuenta"
        Me.lbcuenta.Size = New System.Drawing.Size(71, 15)
        Me.lbcuenta.TabIndex = 75
        Me.lbcuenta.Text = "++++++++"
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nomina, Me.periodo, Me.documento, Me.inicio, Me.fin, Me.dg})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(15, 122)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(715, 152)
        Me.grilla.TabIndex = 73
        '
        'nomina
        '
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nomina.DefaultCellStyle = DataGridViewCellStyle12
        Me.nomina.FillWeight = 180.0!
        Me.nomina.HeaderText = "Nomina"
        Me.nomina.MaxInputLength = 50
        Me.nomina.Name = "nomina"
        Me.nomina.ReadOnly = True
        Me.nomina.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nomina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nomina.Width = 250
        '
        'periodo
        '
        Me.periodo.FillWeight = 80.0!
        Me.periodo.HeaderText = "Periodo"
        Me.periodo.MaxInputLength = 12
        Me.periodo.Name = "periodo"
        Me.periodo.ReadOnly = True
        Me.periodo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.periodo.Width = 80
        '
        'documento
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.documento.DefaultCellStyle = DataGridViewCellStyle13
        Me.documento.FillWeight = 80.0!
        Me.documento.HeaderText = "Documento"
        Me.documento.MaxInputLength = 30
        Me.documento.Name = "documento"
        Me.documento.ReadOnly = True
        Me.documento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.documento.Width = 80
        '
        'inicio
        '
        Me.inicio.HeaderText = "Inicial"
        Me.inicio.MaxInputLength = 20
        Me.inicio.MinimumWidth = 100
        Me.inicio.Name = "inicio"
        Me.inicio.ReadOnly = True
        Me.inicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'fin
        '
        Me.fin.HeaderText = "Final"
        Me.fin.MinimumWidth = 100
        Me.fin.Name = "fin"
        Me.fin.ReadOnly = True
        '
        'dg
        '
        Me.dg.HeaderText = "Desenglobar"
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Text = "Desenglobar"
        Me.dg.ToolTipText = "Desenglobar Cuenta Contable"
        '
        'lbsel
        '
        Me.lbsel.AutoSize = True
        Me.lbsel.Location = New System.Drawing.Point(647, 22)
        Me.lbsel.Name = "lbsel"
        Me.lbsel.Size = New System.Drawing.Size(19, 13)
        Me.lbsel.TabIndex = 72
        Me.lbsel.Text = "no"
        Me.lbsel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar en el Periodo "
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(176, 19)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(44, 21)
        Me.cbper.TabIndex = 0
        '
        'FrmDesNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(760, 542)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDesNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar Nomina"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbcuenta As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents lbsel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents lbcta As System.Windows.Forms.Label
    Friend WithEvents ee As System.Windows.Forms.Label
    Friend WithEvents nomina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents periodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lbvalor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents lbtotal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tercero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents db As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents lbter As System.Windows.Forms.Label
    Friend WithEvents cmddes As System.Windows.Forms.Button
End Class
