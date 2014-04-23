<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecibodeCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibodeCaja))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.txtnumero = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbnomdoc = New System.Windows.Forms.Label
        Me.lbcliente = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.cmdprint = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.txtcentro = New System.Windows.Forms.TextBox
        Me.CmdCons = New System.Windows.Forms.Button
        Me.txtciudad = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbsuma = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.txtdv = New System.Windows.Forms.TextBox
        Me.rbcc = New System.Windows.Forms.RadioButton
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.rbnit = New System.Windows.Forms.RadioButton
        Me.fecha = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.chefectivo = New System.Windows.Forms.CheckBox
        Me.txtsucursal = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtcheque = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ChAnti = New System.Windows.Forms.CheckBox
        Me.txtdocafec = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtconcepto = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtvalor = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.Label38 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbnit = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtncentro = New System.Windows.Forms.TextBox
        Me.lbcompa = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdmas = New System.Windows.Forms.Button
        Me.Ch_mov = New System.Windows.Forms.CheckBox
        Me.lbanulado = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Por concepto de:"
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(428, 13)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 2
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(401, 13)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 1
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbdoc)
        Me.GroupBox2.Controls.Add(Me.lbper)
        Me.GroupBox2.Controls.Add(Me.txtnumero)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbnomdoc)
        Me.GroupBox2.Location = New System.Drawing.Point(555, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 69)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'lbdoc
        '
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.ForeColor = System.Drawing.Color.Black
        Me.lbdoc.Location = New System.Drawing.Point(131, 43)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(40, 20)
        Me.lbdoc.TabIndex = 7
        Me.lbdoc.Text = "RO"
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.ForeColor = System.Drawing.Color.Black
        Me.lbper.Location = New System.Drawing.Point(54, 42)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(80, 20)
        Me.lbper.TabIndex = 6
        Me.lbper.Text = "01/2011-"
        '
        'txtnumero
        '
        Me.txtnumero.Enabled = False
        Me.txtnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumero.Location = New System.Drawing.Point(172, 42)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(94, 22)
        Me.txtnumero.TabIndex = 3
        Me.txtnumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label7.Location = New System.Drawing.Point(22, 41)
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
        Me.lbnomdoc.Location = New System.Drawing.Point(22, 13)
        Me.lbnomdoc.Name = "lbnomdoc"
        Me.lbnomdoc.Size = New System.Drawing.Size(253, 19)
        Me.lbnomdoc.TabIndex = 1
        Me.lbnomdoc.Text = "RECIBO DE CAJA"
        Me.lbnomdoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbcliente
        '
        Me.lbcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcliente.Location = New System.Drawing.Point(99, 10)
        Me.lbcliente.Name = "lbcliente"
        Me.lbcliente.Size = New System.Drawing.Size(474, 29)
        Me.lbcliente.TabIndex = 1
        Me.lbcliente.Text = "MI TERCERO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(5, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Recibido de:"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(201, 71)
        Me.Label18.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(257, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 15)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Fecha (dd/mm/aaaa)"
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(7, 11)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo Registro")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.anular1
        Me.CmdMostrar.Location = New System.Drawing.Point(321, 11)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Anular Documento")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 11)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar Registro")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdprint
        '
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(269, 11)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdprint, "Imprimir Registro")
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(737, 11)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ir Al Ultimo Registro")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(165, 11)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 38)
        Me.cmdEdit.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Editar Registro")
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(59, 11)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Listo")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(687, 11)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente Registro")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(636, 11)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 11
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Registro Anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(423, 11)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Cerrar Formulario")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(112, 11)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar Operación")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'txtcentro
        '
        Me.txtcentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentro.Enabled = False
        Me.txtcentro.Location = New System.Drawing.Point(128, 41)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(63, 20)
        Me.txtcentro.TabIndex = 53
        Me.ToolTip1.SetToolTip(Me.txtcentro, "Doble Clic para seleccionar Centro de Costos")
        '
        'CmdCons
        '
        Me.CmdCons.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdCons.Location = New System.Drawing.Point(372, 11)
        Me.CmdCons.Name = "CmdCons"
        Me.CmdCons.Size = New System.Drawing.Size(52, 38)
        Me.CmdCons.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCons, "Consultar")
        Me.CmdCons.UseVisualStyleBackColor = True
        '
        'txtciudad
        '
        Me.txtciudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtciudad.Location = New System.Drawing.Point(67, 14)
        Me.txtciudad.Name = "txtciudad"
        Me.txtciudad.Size = New System.Drawing.Size(184, 20)
        Me.txtciudad.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label8.Location = New System.Drawing.Point(608, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Valor $"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(12, 514)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 82
        Me.lbestado.Text = "NULO"
        '
        'lbsuma
        '
        Me.lbsuma.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lbsuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbsuma.Location = New System.Drawing.Point(180, 15)
        Me.lbsuma.Name = "lbsuma"
        Me.lbsuma.Size = New System.Drawing.Size(510, 42)
        Me.lbsuma.TabIndex = 2
        Me.lbsuma.Text = "SON CERO PESOS"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.grilla)
        Me.GroupBox7.Controls.Add(Me.GroupBox12)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 236)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(842, 211)
        Me.GroupBox7.TabIndex = 81
        Me.GroupBox7.TabStop = False
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Descripcion, Me.Debitos, Me.Creditos, Me.Base, Me.cc})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(6, 19)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(604, 187)
        Me.grilla.TabIndex = 0
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MaxInputLength = 12
        Me.Cuenta.MinimumWidth = 75
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Width = 75
        '
        'Descripcion
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Detalle Cuenta"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.MinimumWidth = 150
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 150
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
        Me.Debitos.MinimumWidth = 85
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Debitos.Width = 85
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
        Me.Creditos.MinimumWidth = 85
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Creditos.Width = 85
        '
        'Base
        '
        Me.Base.HeaderText = "Base"
        Me.Base.MinimumWidth = 60
        Me.Base.Name = "Base"
        Me.Base.ReadOnly = True
        Me.Base.Width = 85
        '
        'cc
        '
        Me.cc.HeaderText = "Centro de Costo"
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtdv)
        Me.GroupBox12.Controls.Add(Me.rbcc)
        Me.GroupBox12.Controls.Add(Me.txtnit)
        Me.GroupBox12.Controls.Add(Me.rbnit)
        Me.GroupBox12.Controls.Add(Me.fecha)
        Me.GroupBox12.Controls.Add(Me.Label17)
        Me.GroupBox12.Controls.Add(Me.Label18)
        Me.GroupBox12.Controls.Add(Me.Label15)
        Me.GroupBox12.Controls.Add(Me.chefectivo)
        Me.GroupBox12.Controls.Add(Me.txtsucursal)
        Me.GroupBox12.Controls.Add(Me.Label14)
        Me.GroupBox12.Controls.Add(Me.txtbanco)
        Me.GroupBox12.Controls.Add(Me.Label13)
        Me.GroupBox12.Controls.Add(Me.txtcheque)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Location = New System.Drawing.Point(618, 13)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(218, 192)
        Me.GroupBox12.TabIndex = 17
        Me.GroupBox12.TabStop = False
        '
        'txtdv
        '
        Me.txtdv.Enabled = False
        Me.txtdv.Location = New System.Drawing.Point(185, 145)
        Me.txtdv.Name = "txtdv"
        Me.txtdv.Size = New System.Drawing.Size(24, 20)
        Me.txtdv.TabIndex = 46
        '
        'rbcc
        '
        Me.rbcc.AutoSize = True
        Me.rbcc.Checked = True
        Me.rbcc.Location = New System.Drawing.Point(9, 148)
        Me.rbcc.Name = "rbcc"
        Me.rbcc.Size = New System.Drawing.Size(39, 17)
        Me.rbcc.TabIndex = 43
        Me.rbcc.TabStop = True
        Me.rbcc.Text = "CC"
        Me.rbcc.UseVisualStyleBackColor = True
        '
        'txtnit
        '
        Me.txtnit.Location = New System.Drawing.Point(108, 145)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(79, 20)
        Me.txtnit.TabIndex = 45
        '
        'rbnit
        '
        Me.rbnit.AutoSize = True
        Me.rbnit.Location = New System.Drawing.Point(49, 148)
        Me.rbnit.Name = "rbnit"
        Me.rbnit.Size = New System.Drawing.Size(63, 17)
        Me.rbnit.TabIndex = 44
        Me.rbnit.TabStop = True
        Me.rbnit.Text = "NIT No."
        Me.rbnit.UseVisualStyleBackColor = True
        '
        'fecha
        '
        Me.fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha.Location = New System.Drawing.Point(119, 168)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(90, 20)
        Me.fecha.TabIndex = 42
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(7, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 15)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Fecha Recibido"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label15.Location = New System.Drawing.Point(8, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Firma y Sello"
        '
        'chefectivo
        '
        Me.chefectivo.AutoSize = True
        Me.chefectivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chefectivo.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.chefectivo.Location = New System.Drawing.Point(148, 37)
        Me.chefectivo.Name = "chefectivo"
        Me.chefectivo.Size = New System.Drawing.Size(65, 17)
        Me.chefectivo.TabIndex = 4
        Me.chefectivo.Text = "Efectivo"
        Me.chefectivo.UseVisualStyleBackColor = True
        '
        'txtsucursal
        '
        Me.txtsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsucursal.Location = New System.Drawing.Point(49, 37)
        Me.txtsucursal.Name = "txtsucursal"
        Me.txtsucursal.Size = New System.Drawing.Size(93, 18)
        Me.txtsucursal.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label14.Location = New System.Drawing.Point(9, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 12)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Sucursal"
        '
        'txtbanco
        '
        Me.txtbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco.Location = New System.Drawing.Point(127, 17)
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.Size = New System.Drawing.Size(86, 18)
        Me.txtbanco.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label13.Location = New System.Drawing.Point(97, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 12)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Banco"
        '
        'txtcheque
        '
        Me.txtcheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcheque.Location = New System.Drawing.Point(59, 16)
        Me.txtcheque.Name = "txtcheque"
        Me.txtcheque.Size = New System.Drawing.Size(38, 18)
        Me.txtcheque.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label12.Location = New System.Drawing.Point(6, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 12)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Cheque No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(14, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "La Suma de (en Letras)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChAnti)
        Me.GroupBox3.Controls.Add(Me.txtdocafec)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtciudad)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtperiodo)
        Me.GroupBox3.Controls.Add(Me.txtdia)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(842, 40)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        '
        'ChAnti
        '
        Me.ChAnti.AutoSize = True
        Me.ChAnti.Location = New System.Drawing.Point(508, 15)
        Me.ChAnti.Name = "ChAnti"
        Me.ChAnti.Size = New System.Drawing.Size(130, 17)
        Me.ChAnti.TabIndex = 35
        Me.ChAnti.Text = "Marcar Como Anticipo"
        Me.ChAnti.UseVisualStyleBackColor = True
        '
        'txtdocafec
        '
        Me.txtdocafec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdocafec.Enabled = False
        Me.txtdocafec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocafec.Location = New System.Drawing.Point(711, 11)
        Me.txtdocafec.MaxLength = 15
        Me.txtdocafec.Name = "txtdocafec"
        Me.txtdocafec.Size = New System.Drawing.Size(94, 22)
        Me.txtdocafec.TabIndex = 34
        Me.txtdocafec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Peru
        Me.Label20.Location = New System.Drawing.Point(658, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 20)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(9, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ciudad"
        '
        'txtconcepto
        '
        Me.txtconcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto.Location = New System.Drawing.Point(132, 21)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(575, 20)
        Me.txtconcepto.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbcliente)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtvalor)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 100)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(842, 45)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        '
        'txtvalor
        '
        Me.txtvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalor.Location = New System.Drawing.Point(677, 14)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(146, 22)
        Me.txtvalor.TabIndex = 3
        Me.txtvalor.Text = "0,00"
        Me.txtvalor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtconcepto)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 138)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(842, 48)
        Me.GroupBox5.TabIndex = 79
        Me.GroupBox5.TabStop = False
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(686, 516)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 84
        Me.lbnroobs.Text = "0000"
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(586, 11)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 10
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(603, 515)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 83
        Me.Label38.Text = "Registro Nro."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbnit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtncentro)
        Me.GroupBox1.Controls.Add(Me.txtcentro)
        Me.GroupBox1.Controls.Add(Me.lbcompa)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 67)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'lbnit
        '
        Me.lbnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnit.Location = New System.Drawing.Point(7, 26)
        Me.lbnit.Name = "lbnit"
        Me.lbnit.Size = New System.Drawing.Size(434, 14)
        Me.lbnit.TabIndex = 57
        Me.lbnit.Text = "NIT COMPAÑIA"
        Me.lbnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Centro de Costos"
        '
        'txtncentro
        '
        Me.txtncentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtncentro.Enabled = False
        Me.txtncentro.Location = New System.Drawing.Point(197, 41)
        Me.txtncentro.Name = "txtncentro"
        Me.txtncentro.ReadOnly = True
        Me.txtncentro.Size = New System.Drawing.Size(243, 20)
        Me.txtncentro.TabIndex = 54
        '
        'lbcompa
        '
        Me.lbcompa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcompa.Location = New System.Drawing.Point(7, 9)
        Me.lbcompa.Name = "lbcompa"
        Me.lbcompa.Size = New System.Drawing.Size(434, 14)
        Me.lbcompa.TabIndex = 55
        Me.lbcompa.Text = "NOMBRE COMPAÑIA"
        Me.lbcompa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.GroupBox6.Controls.Add(Me.lbsuma)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 179)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(842, 64)
        Me.GroupBox6.TabIndex = 80
        Me.GroupBox6.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.CmdCons)
        Me.GroupBox8.Controls.Add(Me.Ch_mov)
        Me.GroupBox8.Controls.Add(Me.cmdprint)
        Me.GroupBox8.Controls.Add(Me.CmdUltimo)
        Me.GroupBox8.Controls.Add(Me.cmdEdit)
        Me.GroupBox8.Controls.Add(Me.CmdListo)
        Me.GroupBox8.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox8.Controls.Add(Me.CmdAtras)
        Me.GroupBox8.Controls.Add(Me.CmdSalir)
        Me.GroupBox8.Controls.Add(Me.CmdCancelar)
        Me.GroupBox8.Controls.Add(Me.CmdPrimero)
        Me.GroupBox8.Controls.Add(Me.CmdEliminar)
        Me.GroupBox8.Controls.Add(Me.CmdMostrar)
        Me.GroupBox8.Controls.Add(Me.CmdNuevo)
        Me.GroupBox8.Controls.Add(Me.cmdmas)
        Me.GroupBox8.Location = New System.Drawing.Point(7, 447)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(841, 56)
        Me.GroupBox8.TabIndex = 74
        Me.GroupBox8.TabStop = False
        '
        'cmdmas
        '
        Me.cmdmas.Location = New System.Drawing.Point(747, 16)
        Me.cmdmas.Name = "cmdmas"
        Me.cmdmas.Size = New System.Drawing.Size(35, 28)
        Me.cmdmas.TabIndex = 86
        Me.cmdmas.Text = "&I"
        Me.cmdmas.UseVisualStyleBackColor = True
        '
        'Ch_mov
        '
        Me.Ch_mov.AutoSize = True
        Me.Ch_mov.Location = New System.Drawing.Point(489, 16)
        Me.Ch_mov.Name = "Ch_mov"
        Me.Ch_mov.Size = New System.Drawing.Size(85, 30)
        Me.Ch_mov.TabIndex = 9
        Me.Ch_mov.Text = "Mostrar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Movimientos"
        Me.Ch_mov.UseVisualStyleBackColor = True
        '
        'lbanulado
        '
        Me.lbanulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbanulado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbanulado.Location = New System.Drawing.Point(215, 506)
        Me.lbanulado.Name = "lbanulado"
        Me.lbanulado.Size = New System.Drawing.Size(232, 29)
        Me.lbanulado.TabIndex = 85
        '
        'FrmRecibodeCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(852, 540)
        Me.Controls.Add(Me.lbanulado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecibodeCaja"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Recibo de Caja                 Impuestos: ALt + I"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbnomdoc As System.Windows.Forms.Label
    Friend WithEvents lbcliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents txtciudad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbsuma As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chefectivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtsucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtcheque As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtconcepto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents lbnit As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbcompa As System.Windows.Forms.Label
    Friend WithEvents txtncentro As System.Windows.Forms.TextBox
    Friend WithEvents txtcentro As System.Windows.Forms.TextBox
    Friend WithEvents txtdocafec As System.Windows.Forms.TextBox
    Friend WithEvents txtdv As System.Windows.Forms.TextBox
    Friend WithEvents rbcc As System.Windows.Forms.RadioButton
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents rbnit As System.Windows.Forms.RadioButton
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbanulado As System.Windows.Forms.Label
    Friend WithEvents Ch_mov As System.Windows.Forms.CheckBox
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChAnti As System.Windows.Forms.CheckBox
    Friend WithEvents CmdCons As System.Windows.Forms.Button
    Friend WithEvents cmdmas As System.Windows.Forms.Button
End Class
