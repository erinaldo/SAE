<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosIniInv
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
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSaldosIniInv))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.txtcentro = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbcc = New System.Windows.Forms.ComboBox
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chmostrar = New System.Windows.Forms.CheckBox
        Me.txtnombod = New System.Windows.Forms.TextBox
        Me.lbhora = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.txtconcepto = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbdestino = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbaprobado = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gfactura = New System.Windows.Forms.DataGridView
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacven = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaiva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label13 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbdoc = New System.Windows.Forms.Label
        Me.lbcta = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmbContable = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdInf = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.cmditems = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbestado)
        Me.GroupBox1.Controls.Add(Me.txtcentro)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbcc)
        Me.GroupBox1.Controls.Add(Me.lbnumero)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmditems)
        Me.GroupBox1.Controls.Add(Me.txtnombod)
        Me.GroupBox1.Controls.Add(Me.lbhora)
        Me.GroupBox1.Controls.Add(Me.txtcliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtnitc)
        Me.GroupBox1.Controls.Add(Me.txtperiodo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtnumfac)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txttipo)
        Me.GroupBox1.Controls.Add(Me.txtconcepto)
        Me.GroupBox1.Controls.Add(Me.txtdia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbdestino)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(663, 145)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion General"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(379, 11)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 22)
        Me.lbestado.TabIndex = 110
        Me.lbestado.Text = "NULO"
        Me.lbestado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcentro
        '
        Me.txtcentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtcentro.FormattingEnabled = True
        Me.txtcentro.Location = New System.Drawing.Point(464, 46)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(178, 21)
        Me.txtcentro.TabIndex = 122
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(534, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 120
        Me.Label18.Text = "Registro Nro."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(297, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 121
        Me.Label11.Text = "Centro de Costos"
        '
        'cbcc
        '
        Me.cbcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcc.Enabled = False
        Me.cbcc.FormattingEnabled = True
        Me.cbcc.Location = New System.Drawing.Point(388, 46)
        Me.cbcc.Name = "cbcc"
        Me.cbcc.Size = New System.Drawing.Size(72, 21)
        Me.cbcc.TabIndex = 74
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(618, 16)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(14, 13)
        Me.lbnumero.TabIndex = 121
        Me.lbnumero.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Fecha (dd/mm/aaaa)"
        '
        'chmostrar
        '
        Me.chmostrar.AutoSize = True
        Me.chmostrar.Location = New System.Drawing.Point(511, 345)
        Me.chmostrar.Name = "chmostrar"
        Me.chmostrar.Size = New System.Drawing.Size(97, 17)
        Me.chmostrar.TabIndex = 120
        Me.chmostrar.Text = " Imprimir Todos"
        Me.chmostrar.UseVisualStyleBackColor = True
        '
        'txtnombod
        '
        Me.txtnombod.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnombod.Enabled = False
        Me.txtnombod.Location = New System.Drawing.Point(162, 78)
        Me.txtnombod.Name = "txtnombod"
        Me.txtnombod.ShortcutsEnabled = False
        Me.txtnombod.Size = New System.Drawing.Size(131, 20)
        Me.txtnombod.TabIndex = 81
        '
        'lbhora
        '
        Me.lbhora.AutoSize = True
        Me.lbhora.Location = New System.Drawing.Point(215, 53)
        Me.lbhora.Name = "lbhora"
        Me.lbhora.Size = New System.Drawing.Size(49, 13)
        Me.lbhora.TabIndex = 80
        Me.lbhora.Text = "00:00:00"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(255, 108)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(295, 20)
        Me.txtcliente.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Tipo De Documento"
        '
        'txtnitc
        '
        Me.txtnitc.Location = New System.Drawing.Point(121, 108)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.ShortcutsEnabled = False
        Me.txtnitc.Size = New System.Drawing.Size(128, 20)
        Me.txtnitc.TabIndex = 76
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(155, 49)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 76
        Me.txtperiodo.Text = "/00/0000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Nit/Cedula"
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.Enabled = False
        Me.txtnumfac.Location = New System.Drawing.Point(169, 18)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(87, 20)
        Me.txtnumfac.TabIndex = 74
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(299, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Concepto"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttipo.Enabled = False
        Me.txttipo.Location = New System.Drawing.Point(121, 18)
        Me.txttipo.MaxLength = 4
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(41, 20)
        Me.txttipo.TabIndex = 73
        '
        'txtconcepto
        '
        Me.txtconcepto.BackColor = System.Drawing.Color.White
        Me.txtconcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto.Enabled = False
        Me.txtconcepto.Location = New System.Drawing.Point(367, 76)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtconcepto.Size = New System.Drawing.Size(183, 20)
        Me.txtconcepto.TabIndex = 77
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(123, 49)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 75
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Bodega de Entrada"
        '
        'cbdestino
        '
        Me.cbdestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdestino.Enabled = False
        Me.cbdestino.FormattingEnabled = True
        Me.cbdestino.Location = New System.Drawing.Point(119, 77)
        Me.cbdestino.Name = "cbdestino"
        Me.cbdestino.Size = New System.Drawing.Size(41, 21)
        Me.cbdestino.TabIndex = 75
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(496, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 13)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Estado del Documento"
        '
        'cbaprobado
        '
        Me.cbaprobado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbaprobado.Enabled = False
        Me.cbaprobado.FormattingEnabled = True
        Me.cbaprobado.Items.AddRange(New Object() {"", "AP"})
        Me.cbaprobado.Location = New System.Drawing.Point(611, 165)
        Me.cbaprobado.Name = "cbaprobado"
        Me.cbaprobado.Size = New System.Drawing.Size(43, 21)
        Me.cbaprobado.TabIndex = 79
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gfactura)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txttotal)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cbaprobado)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(663, 194)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Articulos"
        '
        'gfactura
        '
        Me.gfactura.AllowUserToAddRows = False
        Me.gfactura.AllowUserToDeleteRows = False
        Me.gfactura.AllowUserToResizeColumns = False
        Me.gfactura.AllowUserToResizeRows = False
        Me.gfactura.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gfactura.ColumnHeadersVisible = False
        Me.gfactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.codigo, Me.desc, Me.cant, Me.valor, Me.Vtotal, Me.tipo, Me.bodega, Me.cc, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.costo})
        Me.gfactura.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura.Location = New System.Drawing.Point(10, 44)
        Me.gfactura.Name = "gfactura"
        Me.gfactura.RowHeadersVisible = False
        Me.gfactura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura.Size = New System.Drawing.Size(641, 115)
        Me.gfactura.TabIndex = 111
        '
        'num
        '
        DataGridViewCellStyle41.Format = "N0"
        DataGridViewCellStyle41.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle41
        Me.num.Frozen = True
        Me.num.HeaderText = "NÚM"
        Me.num.MinimumWidth = 50
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.num.Width = 50
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo.Width = 90
        '
        'desc
        '
        Me.desc.Frozen = True
        Me.desc.HeaderText = "DESCRIPCIÓN"
        Me.desc.MinimumWidth = 200
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.desc.Width = 200
        '
        'cant
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle42.Format = "N0"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle42
        Me.cant.Frozen = True
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.MinimumWidth = 80
        Me.cant.Name = "cant"
        Me.cant.ReadOnly = True
        Me.cant.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cant.Width = 80
        '
        'valor
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle43.Format = "N2"
        DataGridViewCellStyle43.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle43
        Me.valor.Frozen = True
        Me.valor.HeaderText = "V. UNI"
        Me.valor.MinimumWidth = 100
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Vtotal
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle44.Format = "N2"
        DataGridViewCellStyle44.NullValue = Nothing
        Me.Vtotal.DefaultCellStyle = DataGridViewCellStyle44
        Me.Vtotal.Frozen = True
        Me.Vtotal.HeaderText = "V. TOTAL"
        Me.Vtotal.MinimumWidth = 100
        Me.Vtotal.Name = "Vtotal"
        Me.Vtotal.ReadOnly = True
        Me.Vtotal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'tipo
        '
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.MinimumWidth = 20
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Visible = False
        Me.tipo.Width = 20
        '
        'bodega
        '
        Me.bodega.Frozen = True
        Me.bodega.HeaderText = "BODEGA"
        Me.bodega.Name = "bodega"
        Me.bodega.ReadOnly = True
        Me.bodega.Visible = False
        '
        'cc
        '
        Me.cc.Frozen = True
        Me.cc.HeaderText = "cc"
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.Visible = False
        '
        'ctainv
        '
        Me.ctainv.Frozen = True
        Me.ctainv.HeaderText = "ctainv"
        Me.ctainv.Name = "ctainv"
        Me.ctainv.ReadOnly = True
        Me.ctainv.Visible = False
        '
        'ctacven
        '
        Me.ctacven.Frozen = True
        Me.ctacven.HeaderText = "ctacven"
        Me.ctacven.Name = "ctacven"
        Me.ctacven.ReadOnly = True
        Me.ctacven.Visible = False
        '
        'ctaing
        '
        Me.ctaing.Frozen = True
        Me.ctaing.HeaderText = "ctaing"
        Me.ctaing.Name = "ctaing"
        Me.ctaing.ReadOnly = True
        Me.ctaing.Visible = False
        '
        'ctaiva
        '
        Me.ctaiva.Frozen = True
        Me.ctaiva.HeaderText = "ctaiva"
        Me.ctaiva.Name = "ctaiva"
        Me.ctaiva.ReadOnly = True
        Me.ctaiva.Visible = False
        '
        'costo
        '
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(11, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(640, 23)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "NÚM.    CODIGO          DESCRIPCIÓN                          CANTIDAD       V. UN" & _
            "ITARIO       V. TOTAL"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.BurlyWood
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Red
        Me.txttotal.Location = New System.Drawing.Point(233, 162)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(257, 21)
        Me.txttotal.TabIndex = 17
        Me.txttotal.Text = "$0"
        Me.txttotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.BurlyWood
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(10, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 21)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Valor Documento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbContable)
        Me.GroupBox3.Controls.Add(Me.CmdEditar)
        Me.GroupBox3.Controls.Add(Me.CmdMostrar)
        Me.GroupBox3.Controls.Add(Me.cmdInf)
        Me.GroupBox3.Controls.Add(Me.CmdListo)
        Me.GroupBox3.Controls.Add(Me.CmdSalir)
        Me.GroupBox3.Controls.Add(Me.CmdCancelar)
        Me.GroupBox3.Controls.Add(Me.cmdNuevo)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 348)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(438, 66)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Location = New System.Drawing.Point(424, -5)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(20, 13)
        Me.lbdoc.TabIndex = 11
        Me.lbdoc.Text = "FP"
        Me.lbdoc.Visible = False
        '
        'lbcta
        '
        Me.lbcta.AutoSize = True
        Me.lbcta.Location = New System.Drawing.Point(450, -4)
        Me.lbcta.Name = "lbcta"
        Me.lbcta.Size = New System.Drawing.Size(37, 13)
        Me.lbcta.TabIndex = 10
        Me.lbcta.Text = "cta 22"
        Me.lbcta.Visible = False
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.cuenta})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(12, 424)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(653, 107)
        Me.grilla.TabIndex = 119
        '
        'Descripcion
        '
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle45
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 500
        Me.Descripcion.MinimumWidth = 350
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 350
        '
        'Debitos
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle46.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle46.Format = "N2"
        DataGridViewCellStyle46.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle46
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle47.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle47.Format = "N2"
        DataGridViewCellStyle47.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle47
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cuenta
        '
        Me.cuenta.FillWeight = 80.0!
        Me.cuenta.HeaderText = "Cuenta"
        Me.cuenta.MaxInputLength = 20
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        Me.cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cuenta.Width = 80
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CmdUltimo)
        Me.GroupBox4.Controls.Add(Me.CmdPrimero)
        Me.GroupBox4.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox4.Controls.Add(Me.CmdAtras)
        Me.GroupBox4.Location = New System.Drawing.Point(454, 358)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(219, 56)
        Me.GroupBox4.TabIndex = 82
        Me.GroupBox4.TabStop = False
        '
        'cmbContable
        '
        Me.cmbContable.Image = Global.SAE.My.Resources.Resources.sigpeso
        Me.cmbContable.Location = New System.Drawing.Point(380, 14)
        Me.cmbContable.Name = "cmbContable"
        Me.cmbContable.Size = New System.Drawing.Size(49, 39)
        Me.cmbContable.TabIndex = 120
        Me.ToolTip1.SetToolTip(Me.cmbContable, "Contabilizar")
        Me.cmbContable.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(61, 14)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 40)
        Me.CmdEditar.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "Editar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(275, 14)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 40)
        Me.CmdMostrar.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdInf
        '
        Me.cmdInf.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdInf.Location = New System.Drawing.Point(222, 14)
        Me.cmdInf.Name = "cmdInf"
        Me.cmdInf.Size = New System.Drawing.Size(52, 40)
        Me.cmdInf.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.cmdInf, "Imprimir")
        Me.cmdInf.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Enabled = False
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(115, 14)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 40)
        Me.CmdListo.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(327, 14)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 40)
        Me.CmdSalir.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Enabled = False
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(169, 14)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 40)
        Me.CmdCancelar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(6, 13)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 40)
        Me.cmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(159, 11)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 123
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(6, 11)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 120
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(108, 11)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 122
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(57, 11)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 121
        Me.CmdAtras.Text = " "
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.Color.White
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.notas2
        Me.cmditems.Location = New System.Drawing.Point(572, 71)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(63, 66)
        Me.cmditems.TabIndex = 78
        Me.ToolTip1.SetToolTip(Me.cmditems, "Articulos")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'FrmSaldosIniInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(680, 422)
        Me.Controls.Add(Me.chmostrar)
        Me.Controls.Add(Me.grilla)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbcta)
        Me.Controls.Add(Me.lbdoc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaldosIniInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Saldos Iniciales Inventario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdInf As System.Windows.Forms.Button
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents lbcta As System.Windows.Forms.Label
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents gfactura As System.Windows.Forms.DataGridView
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbhora As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents txtnombod As System.Windows.Forms.TextBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtconcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbdestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbaprobado As System.Windows.Forms.ComboBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents txtcentro As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbcc As System.Windows.Forms.ComboBox
    Friend WithEvents chmostrar As System.Windows.Forms.CheckBox
    Friend WithEvents cmbContable As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
