<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVendedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVendedores))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtvendedor = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdcc = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtdir = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txttel = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtpalm = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtzona = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbpalm = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbestado = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbadd = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RECAUDO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gitemsA = New System.Windows.Forms.DataGridView
        Me.cod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.conc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.por = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.recau = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbestado1 = New System.Windows.Forms.TextBox
        Me.txtnit1 = New System.Windows.Forms.TextBox
        Me.txtvendedor1 = New System.Windows.Forms.TextBox
        Me.txttel1 = New System.Windows.Forms.TextBox
        Me.txtdir1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gitemsA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtvendedor
        '
        Me.txtvendedor.BackColor = System.Drawing.Color.White
        Me.txtvendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvendedor.Location = New System.Drawing.Point(186, 46)
        Me.txtvendedor.MaxLength = 70
        Me.txtvendedor.Name = "txtvendedor"
        Me.txtvendedor.ShortcutsEnabled = False
        Me.txtvendedor.Size = New System.Drawing.Size(391, 21)
        Me.txtvendedor.TabIndex = 17
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit.Location = New System.Drawing.Point(185, 19)
        Me.txtnit.MaxLength = 15
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(121, 21)
        Me.txtnit.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 16)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Documento Identificación"
        '
        'Button1
        '
        Me.Button1.Image = Global.SAE.My.Resources.Resources.ccno
        Me.Button1.Location = New System.Drawing.Point(12, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 38)
        Me.Button1.TabIndex = 78
        Me.Button1.Text = "CC"
        Me.ToolTip1.SetToolTip(Me.Button1, "Eliminar Concepto Comisionable")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdcc
        '
        Me.cmdcc.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.cmdcc.Location = New System.Drawing.Point(12, 39)
        Me.cmdcc.Name = "cmdcc"
        Me.cmdcc.Size = New System.Drawing.Size(52, 38)
        Me.cmdcc.TabIndex = 76
        Me.cmdcc.Text = "C C"
        Me.ToolTip1.SetToolTip(Me.cmdcc, "Agregar Conceptos Comisionables")
        Me.cmdcc.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(572, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "modificar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(521, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(470, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 13
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(333, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(419, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(227, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(280, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "buscar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(8, 12)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(211, 22)
        Me.lbestado.TabIndex = 94
        Me.lbestado.Text = "NULO"
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(606, 13)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 93
        Me.lbnumero.Text = "0000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(522, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "Registro Nro."
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
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.cmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 56)
        Me.GroupBox1.TabIndex = 95
        Me.GroupBox1.TabStop = False
        '
        'txtdir
        '
        Me.txtdir.Location = New System.Drawing.Point(186, 73)
        Me.txtdir.MaxLength = 50
        Me.txtdir.Name = "txtdir"
        Me.txtdir.Size = New System.Drawing.Size(391, 20)
        Me.txtdir.TabIndex = 96
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 16)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Dirección Residencial"
        '
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(186, 99)
        Me.txttel.MaxLength = 15
        Me.txttel.Name = "txttel"
        Me.txttel.ShortcutsEnabled = False
        Me.txttel.Size = New System.Drawing.Size(110, 20)
        Me.txttel.TabIndex = 98
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 16)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Telefono / Celular"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 16)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Apellidos y Nombres"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Controls.Add(Me.txtpalm)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtzona)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbpalm)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbestado)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtvendedor)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtdir)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txttel)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 198)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        '
        'txtpalm
        '
        Me.txtpalm.Location = New System.Drawing.Point(516, 129)
        Me.txtpalm.MaxLength = 20
        Me.txtpalm.Name = "txtpalm"
        Me.txtpalm.ShortcutsEnabled = False
        Me.txtpalm.Size = New System.Drawing.Size(110, 20)
        Me.txtpalm.TabIndex = 116
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(433, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 16)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Codigo Palm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(262, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Enviar Palm"
        '
        'txtzona
        '
        Me.txtzona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtzona.Location = New System.Drawing.Point(107, 130)
        Me.txtzona.MaxLength = 20
        Me.txtzona.Name = "txtzona"
        Me.txtzona.ShortcutsEnabled = False
        Me.txtzona.Size = New System.Drawing.Size(147, 20)
        Me.txtzona.TabIndex = 113
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Zona o Area"
        '
        'cbpalm
        '
        Me.cbpalm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpalm.FormattingEnabled = True
        Me.cbpalm.Items.AddRange(New Object() {"no", "si"})
        Me.cbpalm.Location = New System.Drawing.Point(345, 129)
        Me.cbpalm.Name = "cbpalm"
        Me.cbpalm.Size = New System.Drawing.Size(83, 21)
        Me.cbpalm.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Estado del Vendedor"
        '
        'cbestado
        '
        Me.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbestado.FormattingEnabled = True
        Me.cbestado.Items.AddRange(New Object() {"activo", "inactivo"})
        Me.cbestado.Location = New System.Drawing.Point(169, 167)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(110, 21)
        Me.cbestado.TabIndex = 109
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.lbadd)
        Me.GroupBox3.Controls.Add(Me.cmdcc)
        Me.GroupBox3.Controls.Add(Me.gitems)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 298)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(642, 151)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Conceptos Comisionables"
        '
        'lbadd
        '
        Me.lbadd.AutoSize = True
        Me.lbadd.Location = New System.Drawing.Point(24, 80)
        Me.lbadd.Name = "lbadd"
        Me.lbadd.Size = New System.Drawing.Size(39, 13)
        Me.lbadd.TabIndex = 77
        Me.lbadd.Text = "Label9"
        Me.lbadd.Visible = False
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.nombre, Me.nit, Me.RECAUDO})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(87, 22)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gitems.Size = New System.Drawing.Size(537, 121)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 75
        '
        'buscar
        '
        Me.buscar.Frozen = True
        Me.buscar.HeaderText = "CODIGO"
        Me.buscar.MinimumWidth = 100
        Me.buscar.Name = "buscar"
        Me.buscar.ReadOnly = True
        Me.buscar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.buscar.ToolTipText = "buscar por apellidos"
        '
        'nombre
        '
        Me.nombre.Frozen = True
        Me.nombre.HeaderText = "CONCEPTO"
        Me.nombre.MaxInputLength = 300
        Me.nombre.MinimumWidth = 250
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 250
        '
        'nit
        '
        Me.nit.Frozen = True
        Me.nit.HeaderText = "     %"
        Me.nit.MinimumWidth = 50
        Me.nit.Name = "nit"
        Me.nit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nit.Width = 50
        '
        'RECAUDO
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.RECAUDO.DefaultCellStyle = DataGridViewCellStyle1
        Me.RECAUDO.Frozen = True
        Me.RECAUDO.HeaderText = "RECAUDO A DÍAS"
        Me.RECAUDO.MinimumWidth = 130
        Me.RECAUDO.Name = "RECAUDO"
        Me.RECAUDO.Width = 130
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gitemsA)
        Me.GroupBox4.Controls.Add(Me.cbestado1)
        Me.GroupBox4.Controls.Add(Me.txtnit1)
        Me.GroupBox4.Controls.Add(Me.txtvendedor1)
        Me.GroupBox4.Controls.Add(Me.txttel1)
        Me.GroupBox4.Controls.Add(Me.txtdir1)
        Me.GroupBox4.Location = New System.Drawing.Point(677, 33)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(298, 311)
        Me.GroupBox4.TabIndex = 90
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'gitemsA
        '
        Me.gitemsA.AllowUserToAddRows = False
        Me.gitemsA.AllowUserToDeleteRows = False
        Me.gitemsA.AllowUserToResizeColumns = False
        Me.gitemsA.AllowUserToResizeRows = False
        Me.gitemsA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitemsA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitemsA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitemsA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod, Me.conc, Me.por, Me.recau})
        Me.gitemsA.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitemsA.Location = New System.Drawing.Point(10, 162)
        Me.gitemsA.MultiSelect = False
        Me.gitemsA.Name = "gitemsA"
        Me.gitemsA.RowHeadersVisible = False
        Me.gitemsA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitemsA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gitemsA.Size = New System.Drawing.Size(537, 121)
        Me.gitemsA.StandardTab = True
        Me.gitemsA.TabIndex = 112
        '
        'cod
        '
        Me.cod.Frozen = True
        Me.cod.HeaderText = "CODIGO"
        Me.cod.MinimumWidth = 100
        Me.cod.Name = "cod"
        Me.cod.ReadOnly = True
        Me.cod.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cod.ToolTipText = "buscar por apellidos"
        '
        'conc
        '
        Me.conc.Frozen = True
        Me.conc.HeaderText = "CONCEPTO"
        Me.conc.MaxInputLength = 300
        Me.conc.MinimumWidth = 250
        Me.conc.Name = "conc"
        Me.conc.ReadOnly = True
        Me.conc.Width = 250
        '
        'por
        '
        Me.por.Frozen = True
        Me.por.HeaderText = "     %"
        Me.por.MinimumWidth = 50
        Me.por.Name = "por"
        Me.por.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.por.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.por.Width = 50
        '
        'recau
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.recau.DefaultCellStyle = DataGridViewCellStyle2
        Me.recau.Frozen = True
        Me.recau.HeaderText = "RECAUDO A DÍAS"
        Me.recau.MinimumWidth = 130
        Me.recau.Name = "recau"
        Me.recau.Width = 130
        '
        'cbestado1
        '
        Me.cbestado1.Location = New System.Drawing.Point(9, 134)
        Me.cbestado1.MaxLength = 15
        Me.cbestado1.Name = "cbestado1"
        Me.cbestado1.ShortcutsEnabled = False
        Me.cbestado1.Size = New System.Drawing.Size(110, 20)
        Me.cbestado1.TabIndex = 116
        '
        'txtnit1
        '
        Me.txtnit1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit1.Location = New System.Drawing.Point(9, 28)
        Me.txtnit1.MaxLength = 15
        Me.txtnit1.Name = "txtnit1"
        Me.txtnit1.ShortcutsEnabled = False
        Me.txtnit1.Size = New System.Drawing.Size(121, 21)
        Me.txtnit1.TabIndex = 112
        '
        'txtvendedor1
        '
        Me.txtvendedor1.BackColor = System.Drawing.Color.White
        Me.txtvendedor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvendedor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvendedor1.Location = New System.Drawing.Point(10, 55)
        Me.txtvendedor1.MaxLength = 70
        Me.txtvendedor1.Name = "txtvendedor1"
        Me.txtvendedor1.ShortcutsEnabled = False
        Me.txtvendedor1.Size = New System.Drawing.Size(391, 21)
        Me.txtvendedor1.TabIndex = 113
        '
        'txttel1
        '
        Me.txttel1.Location = New System.Drawing.Point(10, 108)
        Me.txttel1.MaxLength = 15
        Me.txttel1.Name = "txttel1"
        Me.txttel1.ShortcutsEnabled = False
        Me.txttel1.Size = New System.Drawing.Size(110, 20)
        Me.txttel1.TabIndex = 115
        '
        'txtdir1
        '
        Me.txtdir1.Location = New System.Drawing.Point(10, 82)
        Me.txtdir1.MaxLength = 50
        Me.txtdir1.Name = "txtdir1"
        Me.txtdir1.Size = New System.Drawing.Size(391, 20)
        Me.txtdir1.TabIndex = 114
        '
        'FrmVendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(662, 461)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVendedores"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Vendedores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gitemsA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtvendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents txtdir As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txttel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbestado As System.Windows.Forms.ComboBox
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents cmdcc As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbpalm As System.Windows.Forms.ComboBox
    Friend WithEvents txtzona As System.Windows.Forms.TextBox
    Friend WithEvents txtpalm As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbadd As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECAUDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnit1 As System.Windows.Forms.TextBox
    Friend WithEvents txtvendedor1 As System.Windows.Forms.TextBox
    Friend WithEvents txttel1 As System.Windows.Forms.TextBox
    Friend WithEvents txtdir1 As System.Windows.Forms.TextBox
    Friend WithEvents gitemsA As System.Windows.Forms.DataGridView
    Friend WithEvents cbestado1 As System.Windows.Forms.TextBox
    Friend WithEvents cod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents conc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents por As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents recau As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
