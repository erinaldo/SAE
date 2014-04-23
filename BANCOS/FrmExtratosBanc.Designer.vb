<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExtratosBanc
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExtratosBanc))
        Me.cminfoconciliaicon = New System.Windows.Forms.Button
        Me.lbhay = New System.Windows.Forms.Label
        Me.txtsaldo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.conepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtsi = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtper = New System.Windows.Forms.TextBox
        Me.cmdtran = New System.Windows.Forms.Button
        Me.LABELDV = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtnomcta = New System.Windows.Forms.TextBox
        Me.cmdActCuenta = New System.Windows.Forms.Button
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.txtcr = New System.Windows.Forms.TextBox
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtextra = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cminfoconciliaicon
        '
        Me.cminfoconciliaicon.BackColor = System.Drawing.SystemColors.Control
        Me.cminfoconciliaicon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cminfoconciliaicon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cminfoconciliaicon.Location = New System.Drawing.Point(341, 9)
        Me.cminfoconciliaicon.Name = "cminfoconciliaicon"
        Me.cminfoconciliaicon.Size = New System.Drawing.Size(168, 34)
        Me.cminfoconciliaicon.TabIndex = 143
        Me.cminfoconciliaicon.Text = "Informe &Conciliaciones"
        Me.cminfoconciliaicon.UseVisualStyleBackColor = False
        Me.cminfoconciliaicon.Visible = False
        '
        'lbhay
        '
        Me.lbhay.AutoSize = True
        Me.lbhay.Location = New System.Drawing.Point(759, 21)
        Me.lbhay.Name = "lbhay"
        Me.lbhay.Size = New System.Drawing.Size(19, 13)
        Me.lbhay.TabIndex = 141
        Me.lbhay.Text = "no"
        Me.lbhay.Visible = False
        '
        'txtsaldo
        '
        Me.txtsaldo.Location = New System.Drawing.Point(407, 141)
        Me.txtsaldo.Name = "txtsaldo"
        Me.txtsaldo.Size = New System.Drawing.Size(142, 20)
        Me.txtsaldo.TabIndex = 140
        Me.txtsaldo.Text = "0,00"
        Me.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(303, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Saldo Actual"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(807, 427)
        Me.GroupBox1.TabIndex = 212
        Me.GroupBox1.TabStop = False
        '
        'grilla
        '
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha, Me.tipo, Me.numero, Me.Debitos, Me.Creditos, Me.conepto, Me.nit})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grilla.DefaultCellStyle = DataGridViewCellStyle4
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grilla.Location = New System.Drawing.Point(8, 191)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
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
        Me.grilla.Size = New System.Drawing.Size(790, 230)
        Me.grilla.TabIndex = 121
        '
        'fecha
        '
        Me.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.fecha.Frozen = True
        Me.fecha.HeaderText = "FECHA"
        Me.fecha.MaxInputLength = 12
        Me.fecha.MinimumWidth = 100
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tipo
        '
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.MinimumWidth = 50
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tipo.Width = 50
        '
        'numero
        '
        Me.numero.Frozen = True
        Me.numero.HeaderText = "NUMERO"
        Me.numero.MinimumWidth = 70
        Me.numero.Name = "numero"
        Me.numero.ReadOnly = True
        Me.numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.numero.Width = 70
        '
        'Debitos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0,00"
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debitos.Frozen = True
        Me.Debitos.HeaderText = "DEBITOS ($)"
        Me.Debitos.MinimumWidth = 128
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Debitos.Width = 128
        '
        'Creditos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0,00"
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Creditos.Frozen = True
        Me.Creditos.HeaderText = "CREDITOS ($)"
        Me.Creditos.MinimumWidth = 128
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Creditos.Width = 128
        '
        'conepto
        '
        Me.conepto.Frozen = True
        Me.conepto.HeaderText = "CONCEPTO"
        Me.conepto.MinimumWidth = 190
        Me.conepto.Name = "conepto"
        Me.conepto.ReadOnly = True
        Me.conepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.conepto.Width = 190
        '
        'nit
        '
        Me.nit.Frozen = True
        Me.nit.HeaderText = "NIT"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cminfoconciliaicon)
        Me.GroupBox2.Controls.Add(Me.lbhay)
        Me.GroupBox2.Controls.Add(Me.txtsaldo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtsi)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtper)
        Me.GroupBox2.Controls.Add(Me.cmdtran)
        Me.GroupBox2.Controls.Add(Me.LABELDV)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtnomcta)
        Me.GroupBox2.Controls.Add(Me.cmdActCuenta)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtnum)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtbanco)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtcuenta)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(790, 175)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        '
        'txtsi
        '
        Me.txtsi.Location = New System.Drawing.Point(407, 115)
        Me.txtsi.Name = "txtsi"
        Me.txtsi.Size = New System.Drawing.Size(142, 20)
        Me.txtsi.TabIndex = 138
        Me.txtsi.Text = "0,00"
        Me.txtsi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(303, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Saldo Anterior"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(552, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "Periodo"
        '
        'txtper
        '
        Me.txtper.Enabled = False
        Me.txtper.Location = New System.Drawing.Point(611, 17)
        Me.txtper.Name = "txtper"
        Me.txtper.Size = New System.Drawing.Size(142, 20)
        Me.txtper.TabIndex = 135
        '
        'cmdtran
        '
        Me.cmdtran.BackColor = System.Drawing.SystemColors.Control
        Me.cmdtran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdtran.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdtran.Location = New System.Drawing.Point(167, 9)
        Me.cmdtran.Name = "cmdtran"
        Me.cmdtran.Size = New System.Drawing.Size(168, 34)
        Me.cmdtran.TabIndex = 134
        Me.cmdtran.Text = "Agregar &Transacciones"
        Me.cmdtran.UseVisualStyleBackColor = False
        '
        'LABELDV
        '
        Me.LABELDV.AutoSize = True
        Me.LABELDV.BackColor = System.Drawing.Color.Transparent
        Me.LABELDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELDV.ForeColor = System.Drawing.Color.Red
        Me.LABELDV.Location = New System.Drawing.Point(226, 89)
        Me.LABELDV.Name = "LABELDV"
        Me.LABELDV.Size = New System.Drawing.Size(16, 16)
        Me.LABELDV.TabIndex = 133
        Me.LABELDV.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(202, 89)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 16)
        Me.Label26.TabIndex = 132
        Me.Label26.Text = "DV"
        '
        'txtnomcta
        '
        Me.txtnomcta.BackColor = System.Drawing.Color.White
        Me.txtnomcta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomcta.Enabled = False
        Me.txtnomcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcta.Location = New System.Drawing.Point(226, 55)
        Me.txtnomcta.MaxLength = 70
        Me.txtnomcta.Name = "txtnomcta"
        Me.txtnomcta.ShortcutsEnabled = False
        Me.txtnomcta.Size = New System.Drawing.Size(528, 21)
        Me.txtnomcta.TabIndex = 1
        '
        'cmdActCuenta
        '
        Me.cmdActCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.cmdActCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActCuenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdActCuenta.Location = New System.Drawing.Point(12, 9)
        Me.cmdActCuenta.Name = "cmdActCuenta"
        Me.cmdActCuenta.Size = New System.Drawing.Size(146, 34)
        Me.cmdActCuenta.TabIndex = 130
        Me.cmdActCuenta.Text = "&Seleccionar Banco"
        Me.cmdActCuenta.UseVisualStyleBackColor = False
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnit.Enabled = False
        Me.txtnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit.Location = New System.Drawing.Point(76, 86)
        Me.txtnit.MaxLength = 15
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(121, 21)
        Me.txtnit.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Nit Banco"
        '
        'txtnum
        '
        Me.txtnum.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnum.Enabled = False
        Me.txtnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum.Location = New System.Drawing.Point(122, 116)
        Me.txtnum.MaxLength = 30
        Me.txtnum.Name = "txtnum"
        Me.txtnum.ShortcutsEnabled = False
        Me.txtnum.Size = New System.Drawing.Size(151, 21)
        Me.txtnum.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Número Cuenta"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.Color.White
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Enabled = False
        Me.txtbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco.Location = New System.Drawing.Point(247, 86)
        Me.txtbanco.MaxLength = 180
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(507, 21)
        Me.txtbanco.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Cuenta Contable"
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.Location = New System.Drawing.Point(122, 55)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(103, 21)
        Me.txtcuenta.TabIndex = 0
        '
        'txtcr
        '
        Me.txtcr.Location = New System.Drawing.Point(378, 432)
        Me.txtcr.Name = "txtcr"
        Me.txtcr.Size = New System.Drawing.Size(142, 20)
        Me.txtcr.TabIndex = 216
        Me.txtcr.Text = "0,00"
        Me.txtcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdb
        '
        Me.txtdb.Location = New System.Drawing.Point(230, 433)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(142, 20)
        Me.txtdb.TabIndex = 214
        Me.txtdb.Text = "0,00"
        Me.txtdb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(163, 468)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 15)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "Total Extracto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(163, 437)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 213
        Me.Label8.Text = "Totales"
        '
        'txtextra
        '
        Me.txtextra.Location = New System.Drawing.Point(378, 458)
        Me.txtextra.Name = "txtextra"
        Me.txtextra.Size = New System.Drawing.Size(142, 20)
        Me.txtextra.TabIndex = 217
        Me.txtextra.Text = "0,00"
        Me.txtextra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmExtratosBanc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(818, 490)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtcr)
        Me.Controls.Add(Me.txtdb)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtextra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExtratosBanc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SA Extratos Bancarios                                          Para  salir Alt + " & _
            "F4"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cminfoconciliaicon As System.Windows.Forms.Button
    Friend WithEvents lbhay As System.Windows.Forms.Label
    Friend WithEvents txtsaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtper As System.Windows.Forms.TextBox
    Friend WithEvents cmdtran As System.Windows.Forms.Button
    Friend WithEvents LABELDV As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtnomcta As System.Windows.Forms.TextBox
    Friend WithEvents cmdActCuenta As System.Windows.Forms.Button
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtextra As System.Windows.Forms.TextBox
End Class
