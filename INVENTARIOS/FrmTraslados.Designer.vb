<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTraslados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTraslados))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.cmditems = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.txtnomorigen = New System.Windows.Forms.TextBox
        Me.txtnomdestino = New System.Windows.Forms.TextBox
        Me.lbhora = New System.Windows.Forms.Label
        Me.txtfecha = New System.Windows.Forms.TextBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.cborigen = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbdestino = New System.Windows.Forms.ComboBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbespera = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtconcepto = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.cbaprobado = New System.Windows.Forms.ComboBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.lbdoc = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gfactura2 = New System.Windows.Forms.DataGridView
        Me.codigo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cbdestino1 = New System.Windows.Forms.TextBox
        Me.cbaprobado1 = New System.Windows.Forms.TextBox
        Me.txtobs1 = New System.Windows.Forms.TextBox
        Me.txtconcepto1 = New System.Windows.Forms.TextBox
        Me.cborigen1 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gfactura2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(518, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Registro Nro."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        Me.CmdEliminar.Enabled = False
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
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.Enabled = False
        Me.txtnumfac.Location = New System.Drawing.Point(236, 22)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(87, 20)
        Me.txtnumfac.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtnumfac, "numero factura")
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.Color.White
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.notas2
        Me.cmditems.Location = New System.Drawing.Point(498, 77)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(63, 66)
        Me.cmditems.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmditems, "editar items")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.White
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdPrint.Location = New System.Drawing.Point(567, 77)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(63, 66)
        Me.cmdPrint.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Imprimir ")
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'txtnomorigen
        '
        Me.txtnomorigen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomorigen.Enabled = False
        Me.txtnomorigen.Location = New System.Drawing.Point(166, 48)
        Me.txtnomorigen.Name = "txtnomorigen"
        Me.txtnomorigen.ShortcutsEnabled = False
        Me.txtnomorigen.Size = New System.Drawing.Size(87, 20)
        Me.txtnomorigen.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.txtnomorigen, "numero factura")
        '
        'txtnomdestino
        '
        Me.txtnomdestino.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomdestino.Enabled = False
        Me.txtnomdestino.Location = New System.Drawing.Point(396, 48)
        Me.txtnomdestino.Name = "txtnomdestino"
        Me.txtnomdestino.ShortcutsEnabled = False
        Me.txtnomdestino.Size = New System.Drawing.Size(87, 20)
        Me.txtnomdestino.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.txtnomdestino, "numero factura")
        '
        'lbhora
        '
        Me.lbhora.AutoSize = True
        Me.lbhora.Location = New System.Drawing.Point(558, 26)
        Me.lbhora.Name = "lbhora"
        Me.lbhora.Size = New System.Drawing.Size(49, 13)
        Me.lbhora.TabIndex = 78
        Me.lbhora.Text = "00:00:00"
        Me.ToolTip1.SetToolTip(Me.lbhora, "Hora")
        '
        'txtfecha
        '
        Me.txtfecha.Location = New System.Drawing.Point(6, 176)
        Me.txtfecha.MaxLength = 10
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ShortcutsEnabled = False
        Me.txtfecha.Size = New System.Drawing.Size(99, 20)
        Me.txtfecha.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.txtfecha, "nit cliente")
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(8, 6)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 22)
        Me.lbestado.TabIndex = 56
        Me.lbestado.Text = "NULO"
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(602, 7)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(14, 13)
        Me.lbnumero.TabIndex = 55
        Me.lbnumero.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Número "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Tipo De Documento"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txttipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttipo.Enabled = False
        Me.txttipo.Location = New System.Drawing.Point(119, 22)
        Me.txttipo.MaxLength = 4
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(41, 20)
        Me.txttipo.TabIndex = 0
        '
        'cborigen
        '
        Me.cborigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cborigen.Enabled = False
        Me.cborigen.FormattingEnabled = True
        Me.cborigen.Location = New System.Drawing.Point(119, 48)
        Me.cborigen.Name = "cborigen"
        Me.cborigen.Size = New System.Drawing.Size(41, 21)
        Me.cborigen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Bodega Origen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Bodega Destino"
        '
        'cbdestino
        '
        Me.cbdestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdestino.Enabled = False
        Me.cbdestino.FormattingEnabled = True
        Me.cbdestino.Location = New System.Drawing.Point(349, 48)
        Me.cbdestino.Name = "cbdestino"
        Me.cbdestino.Size = New System.Drawing.Size(43, 21)
        Me.cbdestino.TabIndex = 4
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(498, 22)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 3
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(471, 22)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 2
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(348, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 15)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Fecha (dd/mm/aaaa)"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.lbespera)
        Me.GroupBox2.Controls.Add(Me.lbhora)
        Me.GroupBox2.Controls.Add(Me.txtnomdestino)
        Me.GroupBox2.Controls.Add(Me.txtnomorigen)
        Me.GroupBox2.Controls.Add(Me.cmdPrint)
        Me.GroupBox2.Controls.Add(Me.cmditems)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtconcepto)
        Me.GroupBox2.Controls.Add(Me.cbdestino)
        Me.GroupBox2.Controls.Add(Me.txtperiodo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtdia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txttipo)
        Me.GroupBox2.Controls.Add(Me.txtnumfac)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cborigen)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 150)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lbespera
        '
        Me.lbespera.AutoSize = True
        Me.lbespera.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbespera.ForeColor = System.Drawing.Color.Maroon
        Me.lbespera.Location = New System.Drawing.Point(170, 130)
        Me.lbespera.Name = "lbespera"
        Me.lbespera.Size = New System.Drawing.Size(265, 24)
        Me.lbespera.TabIndex = 271
        Me.lbespera.Text = "ESPERE UN MOMENTO ..."
        Me.lbespera.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Concepto"
        '
        'txtconcepto
        '
        Me.txtconcepto.Location = New System.Drawing.Point(119, 80)
        Me.txtconcepto.Multiline = True
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtconcepto.Size = New System.Drawing.Size(364, 58)
        Me.txtconcepto.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(61, 238)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(539, 23)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "NÚM.    CODIGO          DESCRIPCIÓN                                              " & _
            "    CANTIDAD"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(65, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "Observaciones"
        '
        'txtobs
        '
        Me.txtobs.Location = New System.Drawing.Point(65, 401)
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtobs.Size = New System.Drawing.Size(333, 50)
        Me.txtobs.TabIndex = 3
        '
        'cbaprobado
        '
        Me.cbaprobado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbaprobado.Enabled = False
        Me.cbaprobado.FormattingEnabled = True
        Me.cbaprobado.Items.AddRange(New Object() {"", "AP"})
        Me.cbaprobado.Location = New System.Drawing.Point(557, 415)
        Me.cbaprobado.Name = "cbaprobado"
        Me.cbaprobado.Size = New System.Drawing.Size(43, 21)
        Me.cbaprobado.TabIndex = 4
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
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
        Me.gfactura.Location = New System.Drawing.Point(64, 266)
        Me.gfactura.Name = "gfactura"
        Me.gfactura.RowHeadersVisible = False
        Me.gfactura.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura.Size = New System.Drawing.Size(536, 115)
        Me.gfactura.TabIndex = 116
        '
        'num
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
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
        Me.desc.MinimumWidth = 290
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        Me.desc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.desc.Width = 290
        '
        'cant
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle3
        Me.valor.Frozen = True
        Me.valor.HeaderText = "V. UNI"
        Me.valor.MinimumWidth = 100
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.valor.Visible = False
        '
        'Vtotal
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Vtotal.DefaultCellStyle = DataGridViewCellStyle4
        Me.Vtotal.Frozen = True
        Me.Vtotal.HeaderText = "V. TOTAL"
        Me.Vtotal.MinimumWidth = 100
        Me.Vtotal.Name = "Vtotal"
        Me.Vtotal.ReadOnly = True
        Me.Vtotal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Vtotal.Visible = False
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
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Location = New System.Drawing.Point(252, 9)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(120, 13)
        Me.lbdoc.TabIndex = 117
        Me.lbdoc.Text = "documento de traslados"
        Me.lbdoc.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(423, 418)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 15)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Estado del Documento"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gfactura2)
        Me.GroupBox4.Controls.Add(Me.cbdestino1)
        Me.GroupBox4.Controls.Add(Me.txtfecha)
        Me.GroupBox4.Controls.Add(Me.cbaprobado1)
        Me.GroupBox4.Controls.Add(Me.txtobs1)
        Me.GroupBox4.Controls.Add(Me.txtconcepto1)
        Me.GroupBox4.Controls.Add(Me.cborigen1)
        Me.GroupBox4.Location = New System.Drawing.Point(685, 26)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(204, 337)
        Me.GroupBox4.TabIndex = 129
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'gfactura2
        '
        Me.gfactura2.AllowUserToAddRows = False
        Me.gfactura2.AllowUserToDeleteRows = False
        Me.gfactura2.AllowUserToResizeColumns = False
        Me.gfactura2.AllowUserToResizeRows = False
        Me.gfactura2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gfactura2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo2, Me.desc2, Me.cant2, Me.tipo2})
        Me.gfactura2.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gfactura2.Location = New System.Drawing.Point(-116, 207)
        Me.gfactura2.Name = "gfactura2"
        Me.gfactura2.RowHeadersVisible = False
        Me.gfactura2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gfactura2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gfactura2.Size = New System.Drawing.Size(536, 115)
        Me.gfactura2.TabIndex = 130
        '
        'codigo2
        '
        Me.codigo2.Frozen = True
        Me.codigo2.HeaderText = "CODIGO"
        Me.codigo2.MinimumWidth = 90
        Me.codigo2.Name = "codigo2"
        Me.codigo2.ReadOnly = True
        Me.codigo2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.codigo2.Width = 90
        '
        'desc2
        '
        Me.desc2.Frozen = True
        Me.desc2.HeaderText = "DESCRIPCIÓN"
        Me.desc2.MinimumWidth = 290
        Me.desc2.Name = "desc2"
        Me.desc2.ReadOnly = True
        Me.desc2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.desc2.Width = 290
        '
        'cant2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cant2.DefaultCellStyle = DataGridViewCellStyle5
        Me.cant2.Frozen = True
        Me.cant2.HeaderText = "CANTIDAD"
        Me.cant2.MinimumWidth = 80
        Me.cant2.Name = "cant2"
        Me.cant2.ReadOnly = True
        Me.cant2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cant2.Width = 80
        '
        'tipo2
        '
        Me.tipo2.HeaderText = "item"
        Me.tipo2.Name = "tipo2"
        '
        'cbdestino1
        '
        Me.cbdestino1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cbdestino1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbdestino1.Enabled = False
        Me.cbdestino1.Location = New System.Drawing.Point(53, 52)
        Me.cbdestino1.MaxLength = 4
        Me.cbdestino1.Name = "cbdestino1"
        Me.cbdestino1.Size = New System.Drawing.Size(41, 20)
        Me.cbdestino1.TabIndex = 131
        '
        'cbaprobado1
        '
        Me.cbaprobado1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cbaprobado1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbaprobado1.Enabled = False
        Me.cbaprobado1.Location = New System.Drawing.Point(6, 25)
        Me.cbaprobado1.MaxLength = 4
        Me.cbaprobado1.Name = "cbaprobado1"
        Me.cbaprobado1.Size = New System.Drawing.Size(41, 20)
        Me.cbaprobado1.TabIndex = 121
        '
        'txtobs1
        '
        Me.txtobs1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobs1.Location = New System.Drawing.Point(6, 129)
        Me.txtobs1.Multiline = True
        Me.txtobs1.Name = "txtobs1"
        Me.txtobs1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtobs1.Size = New System.Drawing.Size(175, 45)
        Me.txtobs1.TabIndex = 121
        '
        'txtconcepto1
        '
        Me.txtconcepto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto1.Location = New System.Drawing.Point(6, 78)
        Me.txtconcepto1.Multiline = True
        Me.txtconcepto1.Name = "txtconcepto1"
        Me.txtconcepto1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtconcepto1.Size = New System.Drawing.Size(175, 45)
        Me.txtconcepto1.TabIndex = 120
        '
        'cborigen1
        '
        Me.cborigen1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cborigen1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cborigen1.Enabled = False
        Me.cborigen1.Location = New System.Drawing.Point(6, 51)
        Me.cborigen1.MaxLength = 4
        Me.cborigen1.Name = "cborigen1"
        Me.cborigen1.Size = New System.Drawing.Size(41, 20)
        Me.cborigen1.TabIndex = 120
        '
        'FrmTraslados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(670, 461)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbdoc)
        Me.Controls.Add(Me.gfactura)
        Me.Controls.Add(Me.cbaprobado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtobs)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnumero)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTraslados"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Traslados de Mercancia"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gfactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gfactura2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
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
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents cborigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbdestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtconcepto As System.Windows.Forms.TextBox
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents cbaprobado As System.Windows.Forms.ComboBox
    Friend WithEvents txtnomorigen As System.Windows.Forms.TextBox
    Friend WithEvents txtnomdestino As System.Windows.Forms.TextBox
    Friend WithEvents lbhora As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents gfactura As System.Windows.Forms.DataGridView
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfecha As System.Windows.Forms.TextBox
    Friend WithEvents cbaprobado1 As System.Windows.Forms.TextBox
    Friend WithEvents txtobs1 As System.Windows.Forms.TextBox
    Friend WithEvents txtconcepto1 As System.Windows.Forms.TextBox
    Friend WithEvents cborigen1 As System.Windows.Forms.TextBox
    Friend WithEvents gfactura2 As System.Windows.Forms.DataGridView
    Friend WithEvents cbdestino1 As System.Windows.Forms.TextBox
    Friend WithEvents codigo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbespera As System.Windows.Forms.Label
End Class
