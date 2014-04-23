<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosIniciales
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSaldosIniciales))
        Me.Label38 = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiasVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdbloquear = New System.Windows.Forms.Button
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
        Me.txtcentro = New System.Windows.Forms.TextBox
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtvmto = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtncentro = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.DateTimePicker
        Me.TxtDocumento = New System.Windows.Forms.TextBox
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtdif = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcr = New System.Windows.Forms.TextBox
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdquitar = New System.Windows.Forms.Button
        Me.cmdImpuestos = New System.Windows.Forms.Button
        Me.lbcta = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(731, 483)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 62
        Me.Label38.Text = "Registro Nro."
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.Cuenta, Me.Base, Me.DiasVencimiento, Me.FechaVencimiento, Me.Nit, Me.cc, Me.cheque})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grilla.Location = New System.Drawing.Point(6, 55)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(965, 186)
        Me.grilla.TabIndex = 11
        '
        'Descripcion
        '
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0,00"
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle7
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0,00"
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0,00"
        Me.Base.DefaultCellStyle = DataGridViewCellStyle9
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.DiasVencimiento.DefaultCellStyle = DataGridViewCellStyle10
        Me.DiasVencimiento.HeaderText = "Dias Vmto"
        Me.DiasVencimiento.MaxInputLength = 4
        Me.DiasVencimiento.MinimumWidth = 70
        Me.DiasVencimiento.Name = "DiasVencimiento"
        Me.DiasVencimiento.ReadOnly = True
        Me.DiasVencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DiasVencimiento.Width = 70
        '
        'FechaVencimiento
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = "00/00/0000"
        Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle11
        Me.FechaVencimiento.HeaderText = "Fecha Vmto"
        Me.FechaVencimiento.MaxInputLength = 10
        Me.FechaVencimiento.MinimumWidth = 80
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.ReadOnly = True
        Me.FechaVencimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaVencimiento.Width = 80
        '
        'Nit
        '
        Me.Nit.HeaderText = "Nit"
        Me.Nit.MaxInputLength = 20
        Me.Nit.MinimumWidth = 90
        Me.Nit.Name = "Nit"
        Me.Nit.ReadOnly = True
        Me.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nit.Width = 90
        '
        'cc
        '
        Me.cc.HeaderText = "Cto Costo"
        Me.cc.MinimumWidth = 80
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cc.Width = 80
        '
        'cheque
        '
        Me.cheque.HeaderText = "Cheque"
        Me.cheque.MinimumWidth = 85
        Me.cheque.Name = "cheque"
        Me.cheque.ReadOnly = True
        Me.cheque.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cheque.Width = 85
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(823, 482)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 63
        Me.lbnroobs.Text = "0000"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(178, 482)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 61
        Me.lbestado.Text = "Estado"
        '
        'cmdbloquear
        '
        Me.cmdbloquear.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdbloquear.Image = Global.SAE.My.Resources.Resources.Bloquear
        Me.cmdbloquear.Location = New System.Drawing.Point(75, 10)
        Me.cmdbloquear.Name = "cmdbloquear"
        Me.cmdbloquear.Size = New System.Drawing.Size(59, 57)
        Me.cmdbloquear.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdbloquear, "Bloquear Saldos Iniciales")
        Me.cmdbloquear.UseVisualStyleBackColor = False
        '
        'cmdprint
        '
        Me.cmdprint.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdprint.Location = New System.Drawing.Point(9, 10)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(59, 57)
        Me.cmdprint.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdprint, "Imprimir")
        Me.cmdprint.UseVisualStyleBackColor = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(618, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 10
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
        Me.CmdSiguiente.Location = New System.Drawing.Point(567, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente Registro")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(516, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 8
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Registro Anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(324, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 6
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
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(271, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar Datos")
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
        'txtcentro
        '
        Me.txtcentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentro.Location = New System.Drawing.Point(188, 71)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(78, 20)
        Me.txtcentro.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtcentro, "Doble Clic para seleccionar Centro de Costos")
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDoc.Enabled = False
        Me.txtDoc.Location = New System.Drawing.Point(239, 18)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.ReadOnly = True
        Me.txtDoc.Size = New System.Drawing.Size(369, 20)
        Me.txtDoc.TabIndex = 2
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtvmto)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtnombre)
        Me.GroupBox4.Controls.Add(Me.txtnit)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtncentro)
        Me.GroupBox4.Controls.Add(Me.txtcentro)
        Me.GroupBox4.Controls.Add(Me.txtperiodo)
        Me.GroupBox4.Controls.Add(Me.txtDoc)
        Me.GroupBox4.Controls.Add(Me.TxtDocumento)
        Me.GroupBox4.Controls.Add(Me.TxtNumero)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(973, 125)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        '
        'txtvmto
        '
        Me.txtvmto.Location = New System.Drawing.Point(579, 46)
        Me.txtvmto.MaxLength = 4
        Me.txtvmto.Name = "txtvmto"
        Me.txtvmto.Size = New System.Drawing.Size(29, 20)
        Me.txtvmto.TabIndex = 5
        Me.txtvmto.Text = "0"
        Me.txtvmto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(515, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Dias Vmto"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(295, 96)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(313, 20)
        Me.txtnombre.TabIndex = 9
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(187, 96)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(102, 20)
        Me.txtnit.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Nit / CC Tercero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Centro de Costos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Nro Documento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 16)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Tipo de Documento"
        '
        'txtncentro
        '
        Me.txtncentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtncentro.Enabled = False
        Me.txtncentro.Location = New System.Drawing.Point(272, 72)
        Me.txtncentro.Name = "txtncentro"
        Me.txtncentro.ReadOnly = True
        Me.txtncentro.Size = New System.Drawing.Size(336, 20)
        Me.txtncentro.TabIndex = 7
        '
        'txtperiodo
        '
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtperiodo.Location = New System.Drawing.Point(420, 47)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.Size = New System.Drawing.Size(89, 20)
        Me.txtperiodo.TabIndex = 4
        '
        'TxtDocumento
        '
        Me.TxtDocumento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocumento.Location = New System.Drawing.Point(188, 18)
        Me.TxtDocumento.MaxLength = 4
        Me.TxtDocumento.Name = "TxtDocumento"
        Me.TxtDocumento.ReadOnly = True
        Me.TxtDocumento.Size = New System.Drawing.Size(45, 20)
        Me.TxtDocumento.TabIndex = 1
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtNumero.Location = New System.Drawing.Point(188, 46)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(67, 20)
        Me.TxtNumero.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdbloquear)
        Me.GroupBox5.Controls.Add(Me.cmdprint)
        Me.GroupBox5.Location = New System.Drawing.Point(720, 21)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(143, 71)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(269, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 15)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Fecha (dd/mm/aaaa)"
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
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.cmdEdit)
        Me.GroupBox1.Controls.Add(Me.CmdListo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdSalir)
        Me.GroupBox1.Controls.Add(Me.CmdCancelar)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.CmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 421)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 56)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(465, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 7
        Me.CmdPrimero.UseVisualStyleBackColor = True
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(985, 390)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
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
        Me.GroupBox3.Location = New System.Drawing.Point(6, 129)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(973, 253)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
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
        'cmdquitar
        '
        Me.cmdquitar.Location = New System.Drawing.Point(387, 447)
        Me.cmdquitar.Name = "cmdquitar"
        Me.cmdquitar.Size = New System.Drawing.Size(48, 24)
        Me.cmdquitar.TabIndex = 64
        Me.cmdquitar.Text = "&Quitar"
        Me.cmdquitar.UseVisualStyleBackColor = True
        '
        'cmdImpuestos
        '
        Me.cmdImpuestos.Location = New System.Drawing.Point(469, 437)
        Me.cmdImpuestos.Name = "cmdImpuestos"
        Me.cmdImpuestos.Size = New System.Drawing.Size(75, 23)
        Me.cmdImpuestos.TabIndex = 67
        Me.cmdImpuestos.Text = "&Impuestos"
        Me.cmdImpuestos.UseVisualStyleBackColor = True
        '
        'lbcta
        '
        Me.lbcta.AutoSize = True
        Me.lbcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcta.Location = New System.Drawing.Point(148, 400)
        Me.lbcta.Name = "lbcta"
        Me.lbcta.Size = New System.Drawing.Size(0, 16)
        Me.lbcta.TabIndex = 74
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 400)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 16)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Cuenta Contable"
        '
        'FrmSaldosIniciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(991, 505)
        Me.Controls.Add(Me.lbcta)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdquitar)
        Me.Controls.Add(Me.cmdImpuestos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmSaldosIniciales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Saldos Iniciales de Contabilidad           Quitar Fila Seleccionada = Alt +" & _
            " Q"
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbestado As System.Windows.Forms.Label
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
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtdif As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdbloquear As System.Windows.Forms.Button
    Friend WithEvents txtperiodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtncentro As System.Windows.Forms.TextBox
    Friend WithEvents txtcentro As System.Windows.Forms.TextBox
    Friend WithEvents cmdquitar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdImpuestos As System.Windows.Forms.Button
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtvmto As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiasVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbcta As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
