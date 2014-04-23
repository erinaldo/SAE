<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompDiario
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbnit = New System.Windows.Forms.Label
        Me.lbcompa = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbnomdoc = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtdoc2 = New System.Windows.Forms.TextBox
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.d2 = New System.Windows.Forms.RadioButton
        Me.d1 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.nivel = New System.Windows.Forms.NumericUpDown
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parciales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbdb = New System.Windows.Forms.Label
        Me.lbcr = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtaprobado = New System.Windows.Forms.TextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtrevisado = New System.Windows.Forms.TextBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txtelaborado = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.cmdgenerar = New System.Windows.Forms.Button
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtciudad = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbnit)
        Me.GroupBox1.Controls.Add(Me.lbcompa)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 64)
        Me.GroupBox1.TabIndex = 0
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbdoc)
        Me.GroupBox2.Controls.Add(Me.lbper)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbnomdoc)
        Me.GroupBox2.Location = New System.Drawing.Point(456, -2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lbdoc
        '
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.ForeColor = System.Drawing.Color.Black
        Me.lbdoc.Location = New System.Drawing.Point(49, 41)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(40, 20)
        Me.lbdoc.TabIndex = 5
        Me.lbdoc.Text = "CD"
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
        Me.lbnomdoc.Text = "COMPROBANTE DE DIARIO"
        Me.lbnomdoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtdoc2)
        Me.GroupBox3.Controls.Add(Me.txtdoc)
        Me.GroupBox3.Controls.Add(Me.d2)
        Me.GroupBox3.Controls.Add(Me.d1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.nivel)
        Me.GroupBox3.Controls.Add(Me.txtciudad)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtperiodo)
        Me.GroupBox3.Controls.Add(Me.txtdia)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 63)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 72)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'txtdoc2
        '
        Me.txtdoc2.BackColor = System.Drawing.SystemColors.Control
        Me.txtdoc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc2.Enabled = False
        Me.txtdoc2.Location = New System.Drawing.Point(491, 41)
        Me.txtdoc2.Name = "txtdoc2"
        Me.txtdoc2.ReadOnly = True
        Me.txtdoc2.Size = New System.Drawing.Size(217, 20)
        Me.txtdoc2.TabIndex = 7
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Enabled = False
        Me.txtdoc.Location = New System.Drawing.Point(455, 41)
        Me.txtdoc.MaxLength = 2
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(36, 20)
        Me.txtdoc.TabIndex = 6
        '
        'd2
        '
        Me.d2.AutoSize = True
        Me.d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d2.Location = New System.Drawing.Point(367, 44)
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(87, 16)
        Me.d2.TabIndex = 5
        Me.d2.Text = "Por Documento"
        Me.d2.UseVisualStyleBackColor = True
        '
        'd1
        '
        Me.d1.AutoSize = True
        Me.d1.Checked = True
        Me.d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d1.Location = New System.Drawing.Point(247, 44)
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(120, 16)
        Me.d1.TabIndex = 4
        Me.d1.TabStop = True
        Me.d1.Text = "Todos Los Documentos"
        Me.d1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Nivel De Cuentas En El Informe (2-5)"
        '
        'nivel
        '
        Me.nivel.Location = New System.Drawing.Point(195, 43)
        Me.nivel.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nivel.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nivel.Name = "nivel"
        Me.nivel.Size = New System.Drawing.Size(29, 20)
        Me.nivel.TabIndex = 3
        Me.nivel.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(15, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Fecha (dd/mm/aaaa)"
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(170, 13)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 1
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(143, 13)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 0
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.grilla.Size = New System.Drawing.Size(700, 202)
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
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle9
        Me.Creditos.HeaderText = "Créditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.MinimumWidth = 100
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grilla)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 127)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(720, 218)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbdb)
        Me.GroupBox5.Controls.Add(Me.lbcr)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Location = New System.Drawing.Point(1, 338)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(720, 40)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
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
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.GroupBox9)
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.GroupBox10)
        Me.GroupBox6.Location = New System.Drawing.Point(2, 371)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(719, 116)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtaprobado)
        Me.GroupBox9.Location = New System.Drawing.Point(241, 13)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(233, 98)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Aprobado Por"
        '
        'txtaprobado
        '
        Me.txtaprobado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtaprobado.Location = New System.Drawing.Point(8, 68)
        Me.txtaprobado.Name = "txtaprobado"
        Me.txtaprobado.Size = New System.Drawing.Size(219, 20)
        Me.txtaprobado.TabIndex = 12
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtrevisado)
        Me.GroupBox7.Location = New System.Drawing.Point(477, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(233, 98)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Revisado Por"
        '
        'txtrevisado
        '
        Me.txtrevisado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrevisado.Location = New System.Drawing.Point(9, 69)
        Me.txtrevisado.Name = "txtrevisado"
        Me.txtrevisado.Size = New System.Drawing.Size(218, 20)
        Me.txtrevisado.TabIndex = 11
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtelaborado)
        Me.GroupBox10.Location = New System.Drawing.Point(5, 14)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(233, 96)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Elaborado Por"
        '
        'txtelaborado
        '
        Me.txtelaborado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtelaborado.Location = New System.Drawing.Point(5, 67)
        Me.txtelaborado.Name = "txtelaborado"
        Me.txtelaborado.Size = New System.Drawing.Size(221, 20)
        Me.txtelaborado.TabIndex = 10
        '
        'ToolTip1
        '
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
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdgenerar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 488)
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
        Me.GroupPanel1.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Ciudad"
        '
        'txtciudad
        '
        Me.txtciudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtciudad.Location = New System.Drawing.Point(297, 15)
        Me.txtciudad.Name = "txtciudad"
        Me.txtciudad.Size = New System.Drawing.Size(411, 20)
        Me.txtciudad.TabIndex = 2
        '
        'FrmCompDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(729, 578)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompDiario"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Comprobante De Diario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nivel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbnit As System.Windows.Forms.Label
    Friend WithEvents lbcompa As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbnomdoc As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbcr As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbdb As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtaprobado As System.Windows.Forms.TextBox
    Friend WithEvents txtrevisado As System.Windows.Forms.TextBox
    Friend WithEvents txtelaborado As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nivel As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtdoc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents d2 As System.Windows.Forms.RadioButton
    Friend WithEvents d1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdgenerar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtciudad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
