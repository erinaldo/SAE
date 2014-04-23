<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenPagos))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtconcep = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbdv = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdCE = New System.Windows.Forms.Button
        Me.cmdprint = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.g1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbcp = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtrubro2 = New System.Windows.Forms.TextBox
        Me.txtreso = New System.Windows.Forms.TextBox
        Me.lbper2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.lbform = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.txtnomrubro = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtplazo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcontra = New System.Windows.Forms.TextBox
        Me.txtdis = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.fecha = New System.Windows.Forms.DateTimePicker
        Me.txtorden = New System.Windows.Forms.TextBox
        Me.lbper = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtrubro = New System.Windows.Forms.TextBox
        Me.txtbase = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.lbpesos = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtbruto = New System.Windows.Forms.TextBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.porc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chOp = New System.Windows.Forms.CheckBox
        Me.GroupBox8.SuspendLayout()
        Me.g1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 225)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "RUBRO"
        '
        'txtconcep
        '
        Me.txtconcep.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtconcep.Location = New System.Drawing.Point(85, 160)
        Me.txtconcep.Multiline = True
        Me.txtconcep.Name = "txtconcep"
        Me.txtconcep.Size = New System.Drawing.Size(649, 58)
        Me.txtconcep.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Concepto"
        '
        'lbdv
        '
        Me.lbdv.AutoSize = True
        Me.lbdv.Location = New System.Drawing.Point(236, 132)
        Me.lbdv.Name = "lbdv"
        Me.lbdv.Size = New System.Drawing.Size(13, 13)
        Me.lbdv.TabIndex = 16
        Me.lbdv.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "DV"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "NIT/CC"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdCE)
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
        Me.GroupBox8.Controls.Add(Me.CmdNuevo)
        Me.GroupBox8.Location = New System.Drawing.Point(7, 565)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(758, 56)
        Me.GroupBox8.TabIndex = 98
        Me.GroupBox8.TabStop = False
        '
        'cmdCE
        '
        Me.cmdCE.Image = CType(resources.GetObject("cmdCE.Image"), System.Drawing.Image)
        Me.cmdCE.Location = New System.Drawing.Point(700, 12)
        Me.cmdCE.Name = "cmdCE"
        Me.cmdCE.Size = New System.Drawing.Size(52, 38)
        Me.cmdCE.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdCE, "Generar Comprobante de Egreso")
        Me.cmdCE.UseVisualStyleBackColor = True
        Me.cmdCE.Visible = False
        '
        'cmdprint
        '
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(318, 13)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdprint, "pdf")
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(635, 13)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(212, 13)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 38)
        Me.cmdEdit.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Editar")
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Enabled = False
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(107, 13)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(584, 13)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(533, 13)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 9
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atras")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(370, 13)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(51, 38)
        Me.CmdSalir.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Enabled = False
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(160, 13)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(482, 13)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdEliminar.Location = New System.Drawing.Point(267, 13)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Mostrar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(55, 13)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(260, 129)
        Me.txtnombre.MaxLength = 10
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(474, 20)
        Me.txtnombre.TabIndex = 8
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.Location = New System.Drawing.Point(85, 129)
        Me.txtnit.MaxLength = 10
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(118, 20)
        Me.txtnit.TabIndex = 7
        '
        'g1
        '
        Me.g1.Controls.Add(Me.Button1)
        Me.g1.Controls.Add(Me.lbcp)
        Me.g1.Controls.Add(Me.Label13)
        Me.g1.Controls.Add(Me.txtrubro2)
        Me.g1.Controls.Add(Me.txtreso)
        Me.g1.Controls.Add(Me.lbper2)
        Me.g1.Controls.Add(Me.Label12)
        Me.g1.Controls.Add(Me.txttipo)
        Me.g1.Controls.Add(Me.lbform)
        Me.g1.Controls.Add(Me.Label16)
        Me.g1.Controls.Add(Me.txtdoc)
        Me.g1.Controls.Add(Me.txtnomrubro)
        Me.g1.Controls.Add(Me.Label9)
        Me.g1.Controls.Add(Me.txtconcep)
        Me.g1.Controls.Add(Me.Label7)
        Me.g1.Controls.Add(Me.lbdv)
        Me.g1.Controls.Add(Me.Label8)
        Me.g1.Controls.Add(Me.txtnombre)
        Me.g1.Controls.Add(Me.Label6)
        Me.g1.Controls.Add(Me.txtnit)
        Me.g1.Controls.Add(Me.Label5)
        Me.g1.Controls.Add(Me.txtplazo)
        Me.g1.Controls.Add(Me.Label4)
        Me.g1.Controls.Add(Me.txtcontra)
        Me.g1.Controls.Add(Me.txtdis)
        Me.g1.Controls.Add(Me.Label3)
        Me.g1.Controls.Add(Me.Label2)
        Me.g1.Controls.Add(Me.fecha)
        Me.g1.Controls.Add(Me.txtorden)
        Me.g1.Controls.Add(Me.lbper)
        Me.g1.Controls.Add(Me.Label1)
        Me.g1.Location = New System.Drawing.Point(7, 0)
        Me.g1.Name = "g1"
        Me.g1.Size = New System.Drawing.Size(749, 285)
        Me.g1.TabIndex = 104
        Me.g1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(239, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 23)
        Me.Button1.TabIndex = 116
        Me.Button1.Text = "Buscar"
        Me.ToolTip1.SetToolTip(Me.Button1, "Buscar Contratos")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbcp
        '
        Me.lbcp.AutoSize = True
        Me.lbcp.Location = New System.Drawing.Point(12, 23)
        Me.lbcp.Name = "lbcp"
        Me.lbcp.Size = New System.Drawing.Size(56, 13)
        Me.lbcp.TabIndex = 115
        Me.lbcp.Text = "CPXXXXX"
        Me.lbcp.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(593, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Resolucion"
        '
        'txtrubro2
        '
        Me.txtrubro2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtrubro2.Location = New System.Drawing.Point(85, 224)
        Me.txtrubro2.MaxLength = 100
        Me.txtrubro2.Multiline = True
        Me.txtrubro2.Name = "txtrubro2"
        Me.txtrubro2.Size = New System.Drawing.Size(118, 45)
        Me.txtrubro2.TabIndex = 29
        '
        'txtreso
        '
        Me.txtreso.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtreso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtreso.Location = New System.Drawing.Point(657, 49)
        Me.txtreso.MaxLength = 20
        Me.txtreso.Name = "txtreso"
        Me.txtreso.Size = New System.Drawing.Size(77, 20)
        Me.txtreso.TabIndex = 2
        '
        'lbper2
        '
        Me.lbper2.AutoSize = True
        Me.lbper2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper2.Location = New System.Drawing.Point(332, 16)
        Me.lbper2.Name = "lbper2"
        Me.lbper2.Size = New System.Drawing.Size(74, 20)
        Me.lbper2.TabIndex = 28
        Me.lbper2.Text = "01/2012"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(424, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Tipo"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txttipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttipo.Location = New System.Drawing.Point(456, 92)
        Me.txttipo.MaxLength = 10
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(62, 20)
        Me.txttipo.TabIndex = 5
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(566, 16)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(27, 13)
        Me.lbform.TabIndex = 24
        Me.lbform.Text = "form"
        Me.lbform.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(522, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Soporte Contable"
        '
        'txtdoc
        '
        Me.txtdoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Location = New System.Drawing.Point(616, 92)
        Me.txtdoc.MaxLength = 10
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(118, 20)
        Me.txtdoc.TabIndex = 6
        '
        'txtnomrubro
        '
        Me.txtnomrubro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomrubro.Location = New System.Drawing.Point(209, 225)
        Me.txtnomrubro.Multiline = True
        Me.txtnomrubro.Name = "txtnomrubro"
        Me.txtnomrubro.Size = New System.Drawing.Size(525, 45)
        Me.txtnomrubro.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(297, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Plazo"
        '
        'txtplazo
        '
        Me.txtplazo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtplazo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplazo.Location = New System.Drawing.Point(336, 92)
        Me.txtplazo.MaxLength = 10
        Me.txtplazo.Name = "txtplazo"
        Me.txtplazo.Size = New System.Drawing.Size(85, 20)
        Me.txtplazo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Contrato"
        '
        'txtcontra
        '
        Me.txtcontra.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcontra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontra.Location = New System.Drawing.Point(85, 92)
        Me.txtcontra.MaxLength = 10
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(148, 20)
        Me.txtcontra.TabIndex = 3
        '
        'txtdis
        '
        Me.txtdis.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdis.Location = New System.Drawing.Point(378, 50)
        Me.txtdis.MaxLength = 4
        Me.txtdis.Name = "txtdis"
        Me.txtdis.Size = New System.Drawing.Size(198, 20)
        Me.txtdis.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(315, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Numero RP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha"
        '
        'fecha
        '
        Me.fecha.Location = New System.Drawing.Point(85, 53)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(200, 20)
        Me.fecha.TabIndex = 1
        '
        'txtorden
        '
        Me.txtorden.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtorden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtorden.Enabled = False
        Me.txtorden.Location = New System.Drawing.Point(410, 16)
        Me.txtorden.MaxLength = 10
        Me.txtorden.Name = "txtorden"
        Me.txtorden.Size = New System.Drawing.Size(118, 20)
        Me.txtorden.TabIndex = 1
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(628, 16)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(74, 20)
        Me.lbper.TabIndex = 1
        Me.lbper.Text = "01/2012"
        Me.lbper.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(72, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ORDEN DE PAGO NUMERO"
        '
        'txtrubro
        '
        Me.txtrubro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtrubro.Location = New System.Drawing.Point(346, 293)
        Me.txtrubro.MaxLength = 10
        Me.txtrubro.Multiline = True
        Me.txtrubro.Name = "txtrubro"
        Me.txtrubro.Size = New System.Drawing.Size(118, 45)
        Me.txtrubro.TabIndex = 10
        Me.txtrubro.Visible = False
        '
        'txtbase
        '
        Me.txtbase.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtbase.Location = New System.Drawing.Point(492, 346)
        Me.txtbase.MaxLength = 200
        Me.txtbase.Name = "txtbase"
        Me.txtbase.ReadOnly = True
        Me.txtbase.Size = New System.Drawing.Size(198, 20)
        Me.txtbase.TabIndex = 101
        Me.txtbase.Text = "0,00"
        Me.txtbase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 316)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(277, 20)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "MENOS IVA DEL CONTRATO ....."
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtiva.Location = New System.Drawing.Point(491, 318)
        Me.txtiva.MaxLength = 200
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(198, 20)
        Me.txtiva.TabIndex = 100
        Me.txtiva.Text = "0,00"
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 344)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(345, 20)
        Me.Label18.TabIndex = 112
        Me.Label18.Text = "VALOR BASE PARA DEDUCCIONES ......"
        '
        'lbpesos
        '
        Me.lbpesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbpesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbpesos.Location = New System.Drawing.Point(12, 528)
        Me.lbpesos.Name = "lbpesos"
        Me.lbpesos.Size = New System.Drawing.Size(753, 37)
        Me.lbpesos.TabIndex = 107
        Me.lbpesos.Text = "SON: CERO PESOS"
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txttotal.Location = New System.Drawing.Point(492, 505)
        Me.txttotal.MaxLength = 200
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(198, 20)
        Me.txttotal.TabIndex = 103
        Me.txttotal.Text = "0,00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(576, 625)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 109
        Me.Label38.Text = "Registro Nro."
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(657, 625)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 110
        Me.lbnroobs.Text = "0000"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(10, 624)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 108
        Me.lbestado.Text = "NULO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 290)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(254, 20)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "VALOR BRUTO A PAGAR ......"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 504)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(240, 20)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "VALOR NETO A PAGAR ......"
        '
        'txtbruto
        '
        Me.txtbruto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtbruto.Location = New System.Drawing.Point(492, 292)
        Me.txtbruto.MaxLength = 200
        Me.txtbruto.Name = "txtbruto"
        Me.txtbruto.Size = New System.Drawing.Size(198, 20)
        Me.txtbruto.TabIndex = 99
        Me.txtbruto.Text = "0,00"
        Me.txtbruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cta, Me.Descripcion, Me.Debitos, Me.Creditos, Me.porc, Me.tipo})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(11, 372)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(754, 128)
        Me.grilla.TabIndex = 102
        '
        'cta
        '
        Me.cta.HeaderText = "Cuenta"
        Me.cta.Name = "cta"
        '
        'Descripcion
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle6
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Concepto"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.MinimumWidth = 220
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 220
        '
        'Debitos
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle7
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.MinimumWidth = 180
        Me.Debitos.Name = "Debitos"
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Debitos.Width = 180
        '
        'Creditos
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle8
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.MinimumWidth = 180
        Me.Creditos.Name = "Creditos"
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Creditos.Width = 180
        '
        'porc
        '
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.porc.DefaultCellStyle = DataGridViewCellStyle9
        Me.porc.HeaderText = "por %"
        Me.porc.MinimumWidth = 60
        Me.porc.Name = "porc"
        Me.porc.Width = 60
        '
        'tipo
        '
        Me.tipo.HeaderText = "tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.Visible = False
        '
        'chOp
        '
        Me.chOp.AutoSize = True
        Me.chOp.Location = New System.Drawing.Point(307, 625)
        Me.chOp.Name = "chOp"
        Me.chOp.Size = New System.Drawing.Size(117, 17)
        Me.chOp.TabIndex = 113
        Me.chOp.Text = "Mostrar Resolucion"
        Me.chOp.UseVisualStyleBackColor = True
        Me.chOp.Visible = False
        '
        'FrmOrdenPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(769, 649)
        Me.Controls.Add(Me.chOp)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.g1)
        Me.Controls.Add(Me.txtbase)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lbpesos)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtrubro)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtbruto)
        Me.Controls.Add(Me.grilla)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmOrdenPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SAE Orden de Pagos"
        Me.GroupBox8.ResumeLayout(False)
        Me.g1.ResumeLayout(False)
        Me.g1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtconcep As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbdv As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCE As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents g1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbper2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents txtnomrubro As System.Windows.Forms.TextBox
    Friend WithEvents txtrubro As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtplazo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcontra As System.Windows.Forms.TextBox
    Friend WithEvents txtdis As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtorden As System.Windows.Forms.TextBox
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbase As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbpesos As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtbruto As System.Windows.Forms.TextBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents txtrubro2 As System.Windows.Forms.TextBox
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtreso As System.Windows.Forms.TextBox
    Friend WithEvents chOp As System.Windows.Forms.CheckBox
    Friend WithEvents lbcp As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
