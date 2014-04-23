<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocumentos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbact = New System.Windows.Forms.Label
        Me.lbini = New System.Windows.Forms.Label
        Me.txtaltual = New System.Windows.Forms.TextBox
        Me.txtinicial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtgrupodoc = New System.Windows.Forms.ComboBox
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEstoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.mimenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(675, 150)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbact)
        Me.GroupBox4.Controls.Add(Me.lbini)
        Me.GroupBox4.Controls.Add(Me.txtaltual)
        Me.GroupBox4.Controls.Add(Me.txtinicial)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtdoc)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txttipo)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtgrupodoc)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(636, 127)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        '
        'lbact
        '
        Me.lbact.AutoSize = True
        Me.lbact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbact.Location = New System.Drawing.Point(149, 98)
        Me.lbact.Name = "lbact"
        Me.lbact.Size = New System.Drawing.Size(59, 15)
        Me.lbact.TabIndex = 34
        Me.lbact.Text = "00/0000"
        '
        'lbini
        '
        Me.lbini.AutoSize = True
        Me.lbini.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbini.Location = New System.Drawing.Point(149, 73)
        Me.lbini.Name = "lbini"
        Me.lbini.Size = New System.Drawing.Size(59, 15)
        Me.lbini.TabIndex = 33
        Me.lbini.Text = "00/0000"
        '
        'txtaltual
        '
        Me.txtaltual.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtaltual.Location = New System.Drawing.Point(211, 97)
        Me.txtaltual.Name = "txtaltual"
        Me.txtaltual.ReadOnly = True
        Me.txtaltual.Size = New System.Drawing.Size(71, 20)
        Me.txtaltual.TabIndex = 4
        '
        'txtinicial
        '
        Me.txtinicial.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtinicial.Location = New System.Drawing.Point(211, 71)
        Me.txtinicial.Name = "txtinicial"
        Me.txtinicial.ReadOnly = True
        Me.txtinicial.Size = New System.Drawing.Size(71, 20)
        Me.txtinicial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Actual"
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Location = New System.Drawing.Point(147, 45)
        Me.txtdoc.MaxLength = 30
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(276, 20)
        Me.txtdoc.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = " Descripción"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txttipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttipo.Location = New System.Drawing.Point(148, 13)
        Me.txttipo.MaxLength = 2
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(39, 20)
        Me.txttipo.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(96, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 15)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Inicio"
        '
        'txtgrupodoc
        '
        Me.txtgrupodoc.ContextMenuStrip = Me.mimenu
        Me.txtgrupodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtgrupodoc.Enabled = False
        Me.txtgrupodoc.FormattingEnabled = True
        Me.txtgrupodoc.Items.AddRange(New Object() {"AJ-->AJUSTE DE CONTABILIDAD", "CB-->CUENTAS DE COBRO", "CD-->COMPROBANTE DIARIO", "CE-->COMPROBANTES DE EGRESOS", "CG-->COMPROBANTES DE GASTOS ", "CI-->COMPROBANTES DE INGRESOS", "CN-->CONSIGNACION", "EN-->ENTRADA DE MERCANCIAS", "FC-->FACTURA DE VENTA", "FP-->FACTURA DE PROVEEDORES", "NC-->NOTA CRÉDITO", "ND-->NOTA DEBITO", "OT-->OTROS DOCUMENTOS", "RO-->RECIBO DE CAJA/REEMBOLSOS/OTRO", "SA-->SALIDA DE MERCANCIA", "SI-->SALDOS INICIALES", "TR-->TRASLADO DE MERCANCIA"})
        Me.txtgrupodoc.Location = New System.Drawing.Point(360, 13)
        Me.txtgrupodoc.Name = "txtgrupodoc"
        Me.txtgrupodoc.Size = New System.Drawing.Size(270, 21)
        Me.txtgrupodoc.Sorted = True
        Me.txtgrupodoc.TabIndex = 1
        '
        'mimenu
        '
        Me.mimenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueEsEstoToolStripMenuItem})
        Me.mimenu.Name = "mimenu"
        Me.mimenu.Size = New System.Drawing.Size(154, 26)
        '
        'QueEsEstoToolStripMenuItem
        '
        Me.QueEsEstoToolStripMenuItem.Name = "QueEsEstoToolStripMenuItem"
        Me.QueEsEstoToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.QueEsEstoToolStripMenuItem.Text = "¿Que es esto?"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(204, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 15)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Grupo de Documentos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Tipo de Documento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.cmdedit)
        Me.GroupBox1.Controls.Add(Me.CmdListo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdSalir)
        Me.GroupBox1.Controls.Add(Me.CmdCancelar)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.CmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 56)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(618, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Ir Ultimo Registro")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdedit
        '
        Me.cmdedit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdedit.Location = New System.Drawing.Point(164, 12)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(52, 38)
        Me.cmdedit.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdedit, "Editar Datos")
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(58, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Registrar Datos")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(567, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Ir Siguiente Registro")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(516, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 13
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Ir Registro Anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(324, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir del Formulario")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(111, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar Operación")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(465, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Ir Primer Registro")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar Registro")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(271, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar Datos")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo Registro")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(650, 218)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 54
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(567, 217)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 53
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(14, 216)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 55
        Me.lbestado.Text = "Estado"
        '
        'FrmDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(701, 236)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDocumentos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Tipos de Documentos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.mimenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtgrupodoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtaltual As System.Windows.Forms.TextBox
    Friend WithEvents txtinicial As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbact As System.Windows.Forms.Label
    Friend WithEvents lbini As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEstoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
