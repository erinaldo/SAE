<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLibroDiario
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parciales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbdb = New System.Windows.Forms.Label
        Me.lbcr = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdgenerar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbnit = New System.Windows.Forms.Label
        Me.lbcompa = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtdoc2 = New System.Windows.Forms.TextBox
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.d2 = New System.Windows.Forms.RadioButton
        Me.d1 = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.lbdoc = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbper = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbnomdoc = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.GroupBox4.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grilla)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 128)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(720, 318)
        Me.GroupBox4.TabIndex = 81
        Me.GroupBox4.TabStop = False
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Descripcion, Me.parciales, Me.Debitos, Me.Creditos})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(8, 10)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla.Size = New System.Drawing.Size(700, 302)
        Me.grilla.StandardTab = True
        Me.grilla.TabIndex = 69
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.Frozen = True
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MaxInputLength = 12
        Me.Cuenta.MinimumWidth = 100
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Descripcion
        '
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle25
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.Frozen = True
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.MinimumWidth = 280
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 280
        '
        'parciales
        '
        Me.parciales.Frozen = True
        Me.parciales.HeaderText = "Documento"
        Me.parciales.Name = "parciales"
        Me.parciales.ReadOnly = True
        '
        'Debitos
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle26
        Me.Debitos.Frozen = True
        Me.Debitos.HeaderText = "Débitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.MinimumWidth = 100
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle27.Format = "N2"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle27
        Me.Creditos.HeaderText = "Créditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.MinimumWidth = 100
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lbdb
        '
        Me.lbdb.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lbdb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdb.Location = New System.Drawing.Point(487, 9)
        Me.lbdb.Name = "lbdb"
        Me.lbdb.Size = New System.Drawing.Size(105, 23)
        Me.lbdb.TabIndex = 35
        Me.lbdb.Text = "0,00"
        Me.lbdb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbcr
        '
        Me.lbcr.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lbcr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcr.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcr.Location = New System.Drawing.Point(591, 9)
        Me.lbcr.Name = "lbcr"
        Me.lbcr.Size = New System.Drawing.Size(105, 23)
        Me.lbcr.TabIndex = 34
        Me.lbcr.Text = "0,00"
        Me.lbcr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Peru
        Me.Label20.Location = New System.Drawing.Point(353, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 16)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Sumas Iguales"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbdb)
        Me.GroupBox5.Controls.Add(Me.lbcr)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 439)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(720, 40)
        Me.GroupBox5.TabIndex = 82
        Me.GroupBox5.TabStop = False
        '
        'cmdgenerar
        '
        Me.cmdgenerar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdgenerar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdgenerar.Image = Global.SAE.My.Resources.Resources.pantalla
        Me.cmdgenerar.Location = New System.Drawing.Point(266, 14)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(59, 57)
        Me.cmdgenerar.TabIndex = 2
        Me.cmdgenerar.Text = "&G"
        Me.cmdgenerar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdgenerar, "Generar Alt + G")
        Me.cmdgenerar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(389, 14)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(328, 14)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 0
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdpantalla, "Reporte Alt + R")
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbnit)
        Me.GroupBox1.Controls.Add(Me.lbcompa)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 64)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        '
        'lbnit
        '
        Me.lbnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnit.Location = New System.Drawing.Point(7, 39)
        Me.lbnit.Name = "lbnit"
        Me.lbnit.Size = New System.Drawing.Size(434, 14)
        Me.lbnit.TabIndex = 52
        Me.lbnit.Text = "NIT COMPAÑIA"
        Me.lbnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbcompa
        '
        Me.lbcompa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcompa.Location = New System.Drawing.Point(7, 16)
        Me.lbcompa.Name = "lbcompa"
        Me.lbcompa.Size = New System.Drawing.Size(434, 14)
        Me.lbcompa.TabIndex = 50
        Me.lbcompa.Text = "NOMBRE COMPAÑIA"
        Me.lbcompa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.nivel)
        Me.GroupBox3.Controls.Add(Me.txtdoc2)
        Me.GroupBox3.Controls.Add(Me.txtdoc)
        Me.GroupBox3.Controls.Add(Me.d2)
        Me.GroupBox3.Controls.Add(Me.d1)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtperiodo)
        Me.GroupBox3.Controls.Add(Me.txtdia)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 72)
        Me.GroupBox3.TabIndex = 80
        Me.GroupBox3.TabStop = False
        '
        'txtdoc2
        '
        Me.txtdoc2.BackColor = System.Drawing.SystemColors.Control
        Me.txtdoc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc2.Enabled = False
        Me.txtdoc2.Location = New System.Drawing.Point(374, 43)
        Me.txtdoc2.Name = "txtdoc2"
        Me.txtdoc2.ReadOnly = True
        Me.txtdoc2.Size = New System.Drawing.Size(217, 20)
        Me.txtdoc2.TabIndex = 7
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Enabled = False
        Me.txtdoc.Location = New System.Drawing.Point(338, 43)
        Me.txtdoc.MaxLength = 2
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(36, 20)
        Me.txtdoc.TabIndex = 6
        '
        'd2
        '
        Me.d2.AutoSize = True
        Me.d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d2.Location = New System.Drawing.Point(212, 42)
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(119, 20)
        Me.d2.TabIndex = 5
        Me.d2.Text = "Por Documento"
        Me.d2.UseVisualStyleBackColor = True
        '
        'd1
        '
        Me.d1.AutoSize = True
        Me.d1.Checked = True
        Me.d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d1.Location = New System.Drawing.Point(21, 42)
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(170, 20)
        Me.d1.TabIndex = 4
        Me.d1.TabStop = True
        Me.d1.Text = "Todos Los Documentos"
        Me.d1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(21, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 16)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Fecha (dd/mm/aaaa)"
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(190, 16)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 1
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(163, 16)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 0
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbdoc
        '
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.ForeColor = System.Drawing.Color.Black
        Me.lbdoc.Location = New System.Drawing.Point(49, 41)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(40, 20)
        Me.lbdoc.TabIndex = 5
        Me.lbdoc.Text = "LD"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbdoc)
        Me.GroupBox2.Controls.Add(Me.lbper)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbnomdoc)
        Me.GroupBox2.Location = New System.Drawing.Point(462, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 69)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.ForeColor = System.Drawing.Color.Black
        Me.lbper.Location = New System.Drawing.Point(85, 40)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(99, 20)
        Me.lbper.TabIndex = 4
        Me.lbper.Text = "01/01/2011"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label7.Location = New System.Drawing.Point(7, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "No."
        '
        'lbnomdoc
        '
        Me.lbnomdoc.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lbnomdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnomdoc.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbnomdoc.Location = New System.Drawing.Point(8, 13)
        Me.lbnomdoc.Name = "lbnomdoc"
        Me.lbnomdoc.Size = New System.Drawing.Size(253, 20)
        Me.lbnomdoc.TabIndex = 1
        Me.lbnomdoc.Text = "LIBRO DIARIO"
        Me.lbnomdoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdgenerar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 484)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(719, 85)
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
        Me.GroupPanel1.TabIndex = 84
        '
        'nivel
        '
        Me.nivel.Location = New System.Drawing.Point(345, 16)
        Me.nivel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nivel.Name = "nivel"
        Me.nivel.Size = New System.Drawing.Size(29, 20)
        Me.nivel.TabIndex = 32
        Me.nivel.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Visible = False
        '
        'FrmLibroDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(736, 575)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLibroDiario"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  Libro Diario                                                              " & _
            "                                                              Salir Alt + F4"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbdb As System.Windows.Forms.Label
    Friend WithEvents lbcr As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdgenerar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbnit As System.Windows.Forms.Label
    Friend WithEvents lbcompa As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdoc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents d2 As System.Windows.Forms.RadioButton
    Friend WithEvents d1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbnomdoc As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
End Class
