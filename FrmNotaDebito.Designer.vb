<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNotaDebito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotaDebito))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbdoc = New System.Windows.Forms.Label
        Me.txtncentro = New System.Windows.Forms.TextBox
        Me.lbcompa = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtdv = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.lbcliente = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.rbnit = New System.Windows.Forms.RadioButton
        Me.rbcc = New System.Windows.Forms.RadioButton
        Me.lbnit = New System.Windows.Forms.Label
        Me.txtnumero = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcentro = New System.Windows.Forms.TextBox
        Me.lbnomdoc = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtvalor = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbsuma = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbdir = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdprint = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.cmdver = New System.Windows.Forms.Button
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.txtconta = New System.Windows.Forms.TextBox
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.txtaprobado = New System.Windows.Forms.TextBox
        Me.txtrevisado = New System.Windows.Forms.TextBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtelaborado = New System.Windows.Forms.TextBox
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.grilla2 = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdmas = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbanulado = New System.Windows.Forms.Label
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.monto})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(5, 34)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(706, 141)
        Me.grilla.TabIndex = 0
        '
        'Descripcion
        '
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Concepto"
        Me.Descripcion.MaxInputLength = 100
        Me.Descripcion.MinimumWidth = 450
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 450
        '
        'monto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.monto.DefaultCellStyle = DataGridViewCellStyle2
        Me.monto.HeaderText = "Valor"
        Me.monto.MaxInputLength = 30
        Me.monto.MinimumWidth = 250
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.monto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.monto.Width = 250
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 15)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "Centro de Costos"
        '
        'lbdoc
        '
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.ForeColor = System.Drawing.Color.Black
        Me.lbdoc.Location = New System.Drawing.Point(113, 42)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(40, 20)
        Me.lbdoc.TabIndex = 7
        Me.lbdoc.Text = "ND"
        '
        'txtncentro
        '
        Me.txtncentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtncentro.Enabled = False
        Me.txtncentro.Location = New System.Drawing.Point(197, 43)
        Me.txtncentro.Name = "txtncentro"
        Me.txtncentro.ReadOnly = True
        Me.txtncentro.Size = New System.Drawing.Size(243, 20)
        Me.txtncentro.TabIndex = 59
        '
        'lbcompa
        '
        Me.lbcompa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcompa.Location = New System.Drawing.Point(7, 11)
        Me.lbcompa.Name = "lbcompa"
        Me.lbcompa.Size = New System.Drawing.Size(434, 14)
        Me.lbcompa.TabIndex = 60
        Me.lbcompa.Text = "NOMBRE COMPAÑIA"
        Me.lbcompa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.ForeColor = System.Drawing.Color.Black
        Me.lbper.Location = New System.Drawing.Point(36, 41)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(80, 20)
        Me.lbper.TabIndex = 6
        Me.lbper.Text = "01/2011-"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdv)
        Me.GroupBox4.Controls.Add(Me.txtperiodo)
        Me.GroupBox4.Controls.Add(Me.txtdia)
        Me.GroupBox4.Controls.Add(Me.txtnit)
        Me.GroupBox4.Controls.Add(Me.lbcliente)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.rbnit)
        Me.GroupBox4.Controls.Add(Me.rbcc)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 66)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(720, 45)
        Me.GroupBox4.TabIndex = 105
        Me.GroupBox4.TabStop = False
        '
        'txtdv
        '
        Me.txtdv.Enabled = False
        Me.txtdv.Location = New System.Drawing.Point(558, 14)
        Me.txtdv.Name = "txtdv"
        Me.txtdv.Size = New System.Drawing.Size(24, 20)
        Me.txtdv.TabIndex = 3
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(652, 15)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 5
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(625, 15)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 4
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtnit.Location = New System.Drawing.Point(478, 14)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(81, 20)
        Me.txtnit.TabIndex = 2
        '
        'lbcliente
        '
        Me.lbcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcliente.Location = New System.Drawing.Point(91, 8)
        Me.lbcliente.Name = "lbcliente"
        Me.lbcliente.Size = New System.Drawing.Size(282, 30)
        Me.lbcliente.TabIndex = 1
        Me.lbcliente.Text = "MI TERCERO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Señor(es):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(589, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 12)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Fecha "
        '
        'rbnit
        '
        Me.rbnit.AutoSize = True
        Me.rbnit.Location = New System.Drawing.Point(416, 16)
        Me.rbnit.Name = "rbnit"
        Me.rbnit.Size = New System.Drawing.Size(63, 17)
        Me.rbnit.TabIndex = 1
        Me.rbnit.TabStop = True
        Me.rbnit.Text = "NIT No."
        Me.rbnit.UseVisualStyleBackColor = True
        '
        'rbcc
        '
        Me.rbcc.AutoSize = True
        Me.rbcc.Checked = True
        Me.rbcc.Location = New System.Drawing.Point(379, 16)
        Me.rbcc.Name = "rbcc"
        Me.rbcc.Size = New System.Drawing.Size(39, 17)
        Me.rbcc.TabIndex = 0
        Me.rbcc.TabStop = True
        Me.rbcc.Text = "CC"
        Me.rbcc.UseVisualStyleBackColor = True
        '
        'lbnit
        '
        Me.lbnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnit.Location = New System.Drawing.Point(7, 28)
        Me.lbnit.Name = "lbnit"
        Me.lbnit.Size = New System.Drawing.Size(434, 14)
        Me.lbnit.TabIndex = 62
        Me.lbnit.Text = "NIT COMPAÑIA"
        Me.lbnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtnumero
        '
        Me.txtnumero.Enabled = False
        Me.txtnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumero.Location = New System.Drawing.Point(158, 42)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(94, 22)
        Me.txtnumero.TabIndex = 3
        Me.txtnumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbnit)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtncentro)
        Me.GroupBox1.Controls.Add(Me.txtcentro)
        Me.GroupBox1.Controls.Add(Me.lbcompa)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 67)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'txtcentro
        '
        Me.txtcentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentro.Enabled = False
        Me.txtcentro.Location = New System.Drawing.Point(128, 43)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(63, 20)
        Me.txtcentro.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.txtcentro, "Doble Clic para seleccionar Centro de Costos")
        '
        'lbnomdoc
        '
        Me.lbnomdoc.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lbnomdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnomdoc.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbnomdoc.Location = New System.Drawing.Point(8, 13)
        Me.lbnomdoc.Name = "lbnomdoc"
        Me.lbnomdoc.Size = New System.Drawing.Size(253, 19)
        Me.lbnomdoc.TabIndex = 1
        Me.lbnomdoc.Text = "NOTA DEBITO"
        Me.lbnomdoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(601, 550)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 112
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(10, 549)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 111
        Me.lbestado.Text = "NULO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbdoc)
        Me.GroupBox2.Controls.Add(Me.lbper)
        Me.GroupBox2.Controls.Add(Me.txtnumero)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbnomdoc)
        Me.GroupBox2.Location = New System.Drawing.Point(457, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 69)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label7.Location = New System.Drawing.Point(9, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "No."
        '
        'txtcuenta
        '
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Location = New System.Drawing.Point(602, 16)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(103, 20)
        Me.txtcuenta.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox6.Controls.Add(Me.txtvalor)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.lbsuma)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 314)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(720, 64)
        Me.GroupBox6.TabIndex = 108
        Me.GroupBox6.TabStop = False
        '
        'txtvalor
        '
        Me.txtvalor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvalor.Location = New System.Drawing.Point(582, 18)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(129, 23)
        Me.txtvalor.TabIndex = 8
        Me.txtvalor.Text = "0,00"
        Me.txtvalor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label9.Location = New System.Drawing.Point(513, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 20)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Total $"
        '
        'lbsuma
        '
        Me.lbsuma.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbsuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsuma.Location = New System.Drawing.Point(176, 16)
        Me.lbsuma.Name = "lbsuma"
        Me.lbsuma.Size = New System.Drawing.Size(331, 42)
        Me.lbsuma.TabIndex = 2
        Me.lbsuma.Text = "SON CERO PESOS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(14, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "La Suma de (en Letras):"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lbdir)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 45)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(514, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Cuenta No."
        '
        'lbdir
        '
        Me.lbdir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbdir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbdir.Location = New System.Drawing.Point(92, 15)
        Me.lbdir.Name = "lbdir"
        Me.lbdir.Size = New System.Drawing.Size(390, 21)
        Me.lbdir.TabIndex = 1
        Me.lbdir.Text = "DIRECCIÓN TERCERO"
        Me.lbdir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Dirección:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(5, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(706, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Le(s) rogamos tomar nota de los siguientes cargos hechos a su apreciable cuenta:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdprint
        '
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(269, 12)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdprint, "Imprimir Registro")
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(659, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ir Al Ultimo Registro")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(164, 12)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 38)
        Me.cmdEdit.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Editar Registro")
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(58, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Listo")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(608, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente Registro")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(557, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 10
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Registro Anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(427, 13)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Cerrar Formulario")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(111, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar Operación")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar Registro")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.anular1
        Me.CmdMostrar.Location = New System.Drawing.Point(321, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Anular Documento")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo Registro")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdver
        '
        Me.cmdver.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.cmdver.Location = New System.Drawing.Point(374, 13)
        Me.cmdver.Name = "cmdver"
        Me.cmdver.Size = New System.Drawing.Size(53, 37)
        Me.cmdver.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdver, "Ver Documentos")
        Me.cmdver.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtconta)
        Me.GroupBox12.Location = New System.Drawing.Point(250, 68)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(240, 40)
        Me.GroupBox12.TabIndex = 3
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Contabilizado Por"
        '
        'txtconta
        '
        Me.txtconta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconta.Enabled = False
        Me.txtconta.Location = New System.Drawing.Point(9, 14)
        Me.txtconta.Name = "txtconta"
        Me.txtconta.Size = New System.Drawing.Size(225, 20)
        Me.txtconta.TabIndex = 10
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtaprobado)
        Me.GroupBox11.Location = New System.Drawing.Point(7, 67)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(240, 40)
        Me.GroupBox11.TabIndex = 2
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Autorizado Por"
        '
        'txtaprobado
        '
        Me.txtaprobado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtaprobado.Enabled = False
        Me.txtaprobado.Location = New System.Drawing.Point(9, 14)
        Me.txtaprobado.Name = "txtaprobado"
        Me.txtaprobado.Size = New System.Drawing.Size(225, 20)
        Me.txtaprobado.TabIndex = 10
        '
        'txtrevisado
        '
        Me.txtrevisado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrevisado.Enabled = False
        Me.txtrevisado.Location = New System.Drawing.Point(9, 15)
        Me.txtrevisado.Name = "txtrevisado"
        Me.txtrevisado.Size = New System.Drawing.Size(225, 20)
        Me.txtrevisado.TabIndex = 10
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GroupBox12)
        Me.GroupBox8.Controls.Add(Me.GroupBox11)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Location = New System.Drawing.Point(223, 371)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(501, 130)
        Me.GroupBox8.TabIndex = 110
        Me.GroupBox8.TabStop = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtrevisado)
        Me.GroupBox10.Location = New System.Drawing.Point(250, 22)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(240, 40)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Revisado Por"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtelaborado)
        Me.GroupBox9.Location = New System.Drawing.Point(7, 21)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(240, 40)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Elaborada Por"
        '
        'txtelaborado
        '
        Me.txtelaborado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtelaborado.Enabled = False
        Me.txtelaborado.Location = New System.Drawing.Point(9, 15)
        Me.txtelaborado.Name = "txtelaborado"
        Me.txtelaborado.Size = New System.Drawing.Size(225, 20)
        Me.txtelaborado.TabIndex = 9
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(683, 551)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 113
        Me.lbnroobs.Text = "0000"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.grilla2)
        Me.GroupBox7.Location = New System.Drawing.Point(5, 371)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(223, 130)
        Me.GroupBox7.TabIndex = 109
        Me.GroupBox7.TabStop = False
        '
        'grilla2
        '
        Me.grilla2.AllowDrop = True
        Me.grilla2.AllowUserToAddRows = False
        Me.grilla2.AllowUserToResizeColumns = False
        Me.grilla2.AllowUserToResizeRows = False
        Me.grilla2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.debitos})
        Me.grilla2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla2.Location = New System.Drawing.Point(11, 11)
        Me.grilla2.MultiSelect = False
        Me.grilla2.Name = "grilla2"
        Me.grilla2.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla2.RowHeadersVisible = False
        Me.grilla2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla2.Size = New System.Drawing.Size(201, 113)
        Me.grilla2.TabIndex = 0
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MaxInputLength = 12
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Width = 80
        '
        'debitos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.debitos.DefaultCellStyle = DataGridViewCellStyle3
        Me.debitos.HeaderText = "Créditos"
        Me.debitos.MaxInputLength = 30
        Me.debitos.MinimumWidth = 116
        Me.debitos.Name = "debitos"
        Me.debitos.ReadOnly = True
        Me.debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.debitos.Width = 116
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdver)
        Me.GroupBox13.Controls.Add(Me.cmdprint)
        Me.GroupBox13.Controls.Add(Me.CmdUltimo)
        Me.GroupBox13.Controls.Add(Me.cmdEdit)
        Me.GroupBox13.Controls.Add(Me.CmdListo)
        Me.GroupBox13.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox13.Controls.Add(Me.CmdAtras)
        Me.GroupBox13.Controls.Add(Me.CmdSalir)
        Me.GroupBox13.Controls.Add(Me.CmdCancelar)
        Me.GroupBox13.Controls.Add(Me.CmdPrimero)
        Me.GroupBox13.Controls.Add(Me.CmdEliminar)
        Me.GroupBox13.Controls.Add(Me.CmdMostrar)
        Me.GroupBox13.Controls.Add(Me.CmdNuevo)
        Me.GroupBox13.Controls.Add(Me.cmdmas)
        Me.GroupBox13.Location = New System.Drawing.Point(5, 493)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(720, 56)
        Me.GroupBox13.TabIndex = 102
        Me.GroupBox13.TabStop = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(506, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 9
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'cmdmas
        '
        Me.cmdmas.Location = New System.Drawing.Point(433, 17)
        Me.cmdmas.Name = "cmdmas"
        Me.cmdmas.Size = New System.Drawing.Size(35, 28)
        Me.cmdmas.TabIndex = 115
        Me.cmdmas.Text = "&I"
        Me.cmdmas.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grilla)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 142)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(719, 179)
        Me.GroupBox5.TabIndex = 107
        Me.GroupBox5.TabStop = False
        '
        'lbanulado
        '
        Me.lbanulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbanulado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbanulado.Location = New System.Drawing.Point(212, 549)
        Me.lbanulado.Name = "lbanulado"
        Me.lbanulado.Size = New System.Drawing.Size(232, 29)
        Me.lbanulado.TabIndex = 114
        '
        'FrmNotaDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(729, 578)
        Me.Controls.Add(Me.lbanulado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNotaDebito"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Nota Debito   "
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents txtncentro As System.Windows.Forms.TextBox
    Friend WithEvents lbcompa As System.Windows.Forms.Label
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdv As System.Windows.Forms.TextBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents lbcliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rbnit As System.Windows.Forms.RadioButton
    Friend WithEvents rbcc As System.Windows.Forms.RadioButton
    Friend WithEvents lbnit As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcentro As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbnomdoc As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtvalor As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbsuma As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbdir As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtconta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtaprobado As System.Windows.Forms.TextBox
    Friend WithEvents txtrevisado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtelaborado As System.Windows.Forms.TextBox
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents grilla2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbanulado As System.Windows.Forms.Label
    Friend WithEvents cmdver As System.Windows.Forms.Button
    Friend WithEvents cmdmas As System.Windows.Forms.Button
End Class
