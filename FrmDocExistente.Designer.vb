<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocExistente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbsel = New System.Windows.Forms.Label
        Me.cmdTodos = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdBuscar = New System.Windows.Forms.Button
        Me.cmdContinuar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtncentro = New System.Windows.Forms.TextBox
        Me.txtcentro = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtnumero = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnomdoc = New System.Windows.Forms.TextBox
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtdif = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcr = New System.Windows.Forms.TextBox
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiasVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(179, 17)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(44, 21)
        Me.cbper.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cbper, "periodo")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbsel)
        Me.GroupBox1.Controls.Add(Me.cmdTodos)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtncentro)
        Me.GroupBox1.Controls.Add(Me.txtcentro)
        Me.GroupBox1.Controls.Add(Me.txtperiodo)
        Me.GroupBox1.Controls.Add(Me.txtdia)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtnumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtnomdoc)
        Me.GroupBox1.Controls.Add(Me.txtdoc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbper)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(850, 137)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lbsel
        '
        Me.lbsel.AutoSize = True
        Me.lbsel.Location = New System.Drawing.Point(482, 20)
        Me.lbsel.Name = "lbsel"
        Me.lbsel.Size = New System.Drawing.Size(19, 13)
        Me.lbsel.TabIndex = 72
        Me.lbsel.Text = "no"
        Me.lbsel.Visible = False
        '
        'cmdTodos
        '
        Me.cmdTodos.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.cmdTodos.Location = New System.Drawing.Point(286, 70)
        Me.cmdTodos.Name = "cmdTodos"
        Me.cmdTodos.Size = New System.Drawing.Size(40, 31)
        Me.cmdTodos.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdTodos, "Ver todos")
        Me.cmdTodos.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdCancelar)
        Me.GroupBox5.Controls.Add(Me.CmdBuscar)
        Me.GroupBox5.Controls.Add(Me.cmdContinuar)
        Me.GroupBox5.Location = New System.Drawing.Point(587, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(253, 97)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdCancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdCancelar.Location = New System.Drawing.Point(169, 15)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 73)
        Me.cmdCancelar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdCancelar, "cancelar")
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'CmdBuscar
        '
        Me.CmdBuscar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdBuscar.Image = Global.SAE.My.Resources.Resources.buscar_doc
        Me.CmdBuscar.Location = New System.Drawing.Point(12, 15)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(73, 73)
        Me.CmdBuscar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdBuscar, "buscar documento")
        Me.CmdBuscar.UseVisualStyleBackColor = False
        '
        'cmdContinuar
        '
        Me.cmdContinuar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdContinuar.Image = Global.SAE.My.Resources.Resources.continuar
        Me.cmdContinuar.Location = New System.Drawing.Point(91, 15)
        Me.cmdContinuar.Name = "cmdContinuar"
        Me.cmdContinuar.Size = New System.Drawing.Size(73, 73)
        Me.cmdContinuar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdContinuar, "continuar y agregar")
        Me.cmdContinuar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Centro de Costos"
        '
        'txtncentro
        '
        Me.txtncentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtncentro.Enabled = False
        Me.txtncentro.Location = New System.Drawing.Point(229, 103)
        Me.txtncentro.Name = "txtncentro"
        Me.txtncentro.ReadOnly = True
        Me.txtncentro.Size = New System.Drawing.Size(218, 20)
        Me.txtncentro.TabIndex = 50
        '
        'txtcentro
        '
        Me.txtcentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentro.Enabled = False
        Me.txtcentro.Location = New System.Drawing.Point(179, 103)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(45, 20)
        Me.txtcentro.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.txtcentro, "centro de costos")
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(512, 76)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 47
        Me.txtperiodo.Text = "/00/0000"
        Me.ToolTip1.SetToolTip(Me.txtperiodo, "periodo")
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(485, 76)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 46
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdia, "dia")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(341, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 15)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Fecha (dd/mm/aaaa)"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(179, 77)
        Me.txtnumero.MaxLength = 20
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(105, 20)
        Me.txtnumero.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtnumero, "numero del documento")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Numero"
        '
        'txtnomdoc
        '
        Me.txtnomdoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomdoc.Enabled = False
        Me.txtnomdoc.Location = New System.Drawing.Point(239, 47)
        Me.txtnomdoc.Name = "txtnomdoc"
        Me.txtnomdoc.Size = New System.Drawing.Size(328, 20)
        Me.txtnomdoc.TabIndex = 4
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Location = New System.Drawing.Point(179, 47)
        Me.txtdoc.MaxLength = 2
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(54, 20)
        Me.txtdoc.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtdoc, "tipo de documento")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Documento"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtdif)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcr)
        Me.GroupBox3.Controls.Add(Me.txtdb)
        Me.GroupBox3.Controls.Add(Me.grilla)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 139)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(850, 253)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label4.Location = New System.Drawing.Point(603, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "$"
        '
        'txtdif
        '
        Me.txtdif.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdif.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtdif.Location = New System.Drawing.Point(620, 19)
        Me.txtdif.Name = "txtdif"
        Me.txtdif.ReadOnly = True
        Me.txtdif.Size = New System.Drawing.Size(183, 21)
        Me.txtdif.TabIndex = 10
        Me.txtdif.Text = "0"
        Me.txtdif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdif, "diferencia")
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label9.Location = New System.Drawing.Point(568, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 23)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "="
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label8.Location = New System.Drawing.Point(309, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "CREDITO $"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label5.Location = New System.Drawing.Point(34, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "DEBITO $"
        '
        'txtcr
        '
        Me.txtcr.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcr.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtcr.Location = New System.Drawing.Point(383, 19)
        Me.txtcr.Name = "txtcr"
        Me.txtcr.ReadOnly = True
        Me.txtcr.Size = New System.Drawing.Size(183, 21)
        Me.txtcr.TabIndex = 9
        Me.txtcr.Text = "0"
        Me.txtcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcr, "creditos")
        '
        'txtdb
        '
        Me.txtdb.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdb.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtdb.Location = New System.Drawing.Point(101, 19)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.ReadOnly = True
        Me.txtdb.Size = New System.Drawing.Size(183, 20)
        Me.txtdb.TabIndex = 8
        Me.txtdb.Text = "0"
        Me.txtdb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtdb, "debitos")
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.Cuenta, Me.Base, Me.DiasVencimiento, Me.FechaVencimiento, Me.Nit, Me.cc})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(6, 55)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(838, 186)
        Me.grilla.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.grilla, "movimientos")
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label7.Location = New System.Drawing.Point(289, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 24)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "-"
        '
        'Descripcion
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 180
        '
        'Debitos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
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
        'Base
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Base.DefaultCellStyle = DataGridViewCellStyle4
        Me.Base.FillWeight = 80.0!
        Me.Base.HeaderText = "Base"
        Me.Base.MaxInputLength = 30
        Me.Base.Name = "Base"
        Me.Base.ReadOnly = True
        Me.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Base.Width = 80
        '
        'DiasVencimiento
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.DiasVencimiento.DefaultCellStyle = DataGridViewCellStyle5
        Me.DiasVencimiento.HeaderText = "DiasV/miento"
        Me.DiasVencimiento.MaxInputLength = 4
        Me.DiasVencimiento.MinimumWidth = 80
        Me.DiasVencimiento.Name = "DiasVencimiento"
        Me.DiasVencimiento.ReadOnly = True
        Me.DiasVencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DiasVencimiento.Width = 80
        '
        'FechaVencimiento
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.Format = "d"
        Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle6
        Me.FechaVencimiento.HeaderText = "FechaV/miento"
        Me.FechaVencimiento.MaxInputLength = 10
        Me.FechaVencimiento.MinimumWidth = 90
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.ReadOnly = True
        Me.FechaVencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaVencimiento.Width = 90
        '
        'Nit
        '
        Me.Nit.HeaderText = "Nit"
        Me.Nit.MaxInputLength = 20
        Me.Nit.MinimumWidth = 105
        Me.Nit.Name = "Nit"
        Me.Nit.ReadOnly = True
        Me.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nit.Width = 105
        '
        'cc
        '
        Me.cc.HeaderText = "cc"
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.Visible = False
        '
        'FrmDocExistente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(867, 405)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDocExistente"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Buscar Documento Existente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnomdoc As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdif As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtncentro As System.Windows.Forms.TextBox
    Friend WithEvents txtcentro As System.Windows.Forms.TextBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents cmdContinuar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdTodos As System.Windows.Forms.Button
    Friend WithEvents lbsel As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiasVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
