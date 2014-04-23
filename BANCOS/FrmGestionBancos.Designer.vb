<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionBancos
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestionBancos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INICIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtnomcta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.LABELDV = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.cmdActCuenta = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.CmdEditar)
        Me.GroupBox1.Controls.Add(Me.CmdListo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdSalir)
        Me.GroupBox1.Controls.Add(Me.CmdCancelar)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.cmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(669, 56)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(578, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 16)
        Me.Label26.TabIndex = 132
        Me.Label26.Text = "DV"
        '
        'grilla
        '
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.INICIAL, Me.TSI, Me.Debitos, Me.Creditos, Me.Cuenta, Me.TSA})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grilla.Location = New System.Drawing.Point(11, 236)
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
        Me.grilla.Size = New System.Drawing.Size(669, 290)
        Me.grilla.TabIndex = 127
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Descripcion.Frozen = True
        Me.Descripcion.HeaderText = "MES / AÑO"
        Me.Descripcion.MaxInputLength = 30
        Me.Descripcion.MinimumWidth = 112
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 112
        '
        'INICIAL
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0,00"
        Me.INICIAL.DefaultCellStyle = DataGridViewCellStyle8
        Me.INICIAL.Frozen = True
        Me.INICIAL.HeaderText = "SALDO INICIAL ($)"
        Me.INICIAL.MinimumWidth = 128
        Me.INICIAL.Name = "INICIAL"
        Me.INICIAL.ReadOnly = True
        Me.INICIAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.INICIAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.INICIAL.Width = 128
        '
        'TSI
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle9.NullValue = "D"
        Me.TSI.DefaultCellStyle = DataGridViewCellStyle9
        Me.TSI.Frozen = True
        Me.TSI.HeaderText = "E"
        Me.TSI.MinimumWidth = 20
        Me.TSI.Name = "TSI"
        Me.TSI.ReadOnly = True
        Me.TSI.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TSI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TSI.ToolTipText = "Estado Saldo Inicial"
        Me.TSI.Width = 20
        '
        'Debitos
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0,00"
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle10
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
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0,00"
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle11
        Me.Creditos.Frozen = True
        Me.Creditos.HeaderText = "CREDITOS ($)"
        Me.Creditos.MinimumWidth = 128
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Creditos.Width = 128
        '
        'Cuenta
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0,00"
        Me.Cuenta.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.Frozen = True
        Me.Cuenta.HeaderText = "SALDO ($)"
        Me.Cuenta.MinimumWidth = 128
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Width = 128
        '
        'TSA
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle13.NullValue = "D"
        Me.TSA.DefaultCellStyle = DataGridViewCellStyle13
        Me.TSA.Frozen = True
        Me.TSA.HeaderText = "E"
        Me.TSA.MinimumWidth = 20
        Me.TSA.Name = "TSA"
        Me.TSA.ReadOnly = True
        Me.TSA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TSA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TSA.ToolTipText = "Estado Saldo Actual"
        Me.TSA.Width = 20
        '
        'txtnomcta
        '
        Me.txtnomcta.BackColor = System.Drawing.Color.White
        Me.txtnomcta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomcta.Enabled = False
        Me.txtnomcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcta.Location = New System.Drawing.Point(226, 19)
        Me.txtnomcta.MaxLength = 70
        Me.txtnomcta.Name = "txtnomcta"
        Me.txtnomcta.ShortcutsEnabled = False
        Me.txtnomcta.Size = New System.Drawing.Size(391, 21)
        Me.txtnomcta.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 16)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Código Interno del Banco"
        '
        'txtcodigo
        '
        Me.txtcodigo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(176, 55)
        Me.txtcodigo.MaxLength = 10
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ShortcutsEnabled = False
        Me.txtcodigo.Size = New System.Drawing.Size(87, 21)
        Me.txtcodigo.TabIndex = 2
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(219, 276)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 128
        Me.mibarra.Visible = False
        '
        'LABELDV
        '
        Me.LABELDV.AutoSize = True
        Me.LABELDV.BackColor = System.Drawing.Color.Transparent
        Me.LABELDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELDV.ForeColor = System.Drawing.Color.Red
        Me.LABELDV.Location = New System.Drawing.Point(602, 58)
        Me.LABELDV.Name = "LABELDV"
        Me.LABELDV.Size = New System.Drawing.Size(16, 16)
        Me.LABELDV.TabIndex = 133
        Me.LABELDV.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LABELDV)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtnomcta)
        Me.GroupBox2.Controls.Add(Me.cmdActCuenta)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtcodigo)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Controls.Add(Me.txtnum)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtbanco)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtcuenta)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 149)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit.Location = New System.Drawing.Point(446, 55)
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
        Me.Label5.Location = New System.Drawing.Point(286, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Nit Banco o Corporación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(282, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "a Nombre de"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(371, 122)
        Me.txtnombre.MaxLength = 180
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ShortcutsEnabled = False
        Me.txtnombre.Size = New System.Drawing.Size(246, 21)
        Me.txtnombre.TabIndex = 6
        '
        'txtnum
        '
        Me.txtnum.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum.Location = New System.Drawing.Point(121, 122)
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
        Me.Label2.Location = New System.Drawing.Point(12, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Número Cuenta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 16)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Nombre del Banco o Corporación"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.Color.White
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Enabled = False
        Me.txtbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco.Location = New System.Drawing.Point(226, 89)
        Me.txtbanco.MaxLength = 180
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(391, 21)
        Me.txtbanco.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Cuenta Contable"
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.Location = New System.Drawing.Point(122, 19)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(103, 21)
        Me.txtcuenta.TabIndex = 0
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(609, 5)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 124
        Me.lbnumero.Text = "0000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(525, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 123
        Me.Label18.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(11, 4)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(211, 22)
        Me.lbestado.TabIndex = 125
        Me.lbestado.Text = "NULO"
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(600, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "Editar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(549, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(498, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 13
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atras")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(280, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(447, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(227, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdActCuenta
        '
        Me.cmdActCuenta.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdActCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 2.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActCuenta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdActCuenta.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdActCuenta.Location = New System.Drawing.Point(621, 11)
        Me.cmdActCuenta.Name = "cmdActCuenta"
        Me.cmdActCuenta.Size = New System.Drawing.Size(40, 34)
        Me.cmdActCuenta.TabIndex = 130
        Me.cmdActCuenta.Text = "&C"
        Me.cmdActCuenta.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdActCuenta, "Actualizar Saldos de la Cuenta")
        Me.cmdActCuenta.UseVisualStyleBackColor = False
        '
        'FrmGestionBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(687, 532)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.mibarra)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lbestado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGestionBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestion Bancos"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INICIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtnomcta As System.Windows.Forms.TextBox
    Friend WithEvents cmdActCuenta As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents LABELDV As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
End Class
