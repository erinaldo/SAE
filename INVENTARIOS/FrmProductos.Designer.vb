<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductos))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.txtdesc = New System.Windows.Forms.TextBox
        Me.txtdetallada = New System.Windows.Forms.TextBox
        Me.lbaux = New System.Windows.Forms.Label
        Me.txtnivel = New System.Windows.Forms.TextBox
        Me.txtref = New System.Windows.Forms.TextBox
        Me.txtcbarra = New System.Windows.Forms.TextBox
        Me.txtcprom = New System.Windows.Forms.TextBox
        Me.txtcuni = New System.Windows.Forms.TextBox
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.txtprecio = New System.Windows.Forms.TextBox
        Me.txtpiva = New System.Windows.Forms.TextBox
        Me.txtctotal = New System.Windows.Forms.TextBox
        Me.txtiva = New System.Windows.Forms.TextBox
        Me.txtuni = New System.Windows.Forms.TextBox
        Me.txtemp = New System.Windows.Forms.TextBox
        Me.txtcanemp = New System.Windows.Forms.TextBox
        Me.txtconcep = New System.Windows.Forms.TextBox
        Me.txtnumreg = New System.Windows.Forms.TextBox
        Me.txtarancel = New System.Windows.Forms.TextBox
        Me.txtposAran = New System.Windows.Forms.TextBox
        Me.rbimp2 = New System.Windows.Forms.RadioButton
        Me.rbimp1 = New System.Windows.Forms.RadioButton
        Me.cbestado = New System.Windows.Forms.ComboBox
        Me.cmdprov = New System.Windows.Forms.Button
        Me.cdmcuentas = New System.Windows.Forms.Button
        Me.cdmlista = New System.Windows.Forms.Button
        Me.cmddeta = New System.Windows.Forms.Button
        Me.txtpp = New System.Windows.Forms.TextBox
        Me.txtmin = New System.Windows.Forms.TextBox
        Me.txtuni_emp = New System.Windows.Forms.TextBox
        Me.cbexen = New System.Windows.Forms.ComboBox
        Me.cbexclu = New System.Windows.Forms.ComboBox
        Me.txtmargen = New System.Windows.Forms.TextBox
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.txtCantImprimir = New System.Windows.Forms.NumericUpDown
        Me.Gbotones = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Gpropiedades = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Gproducto = New System.Windows.Forms.GroupBox
        Me.Gdetalles = New System.Windows.Forms.GroupBox
        Me.btnImptodos = New System.Windows.Forms.Button
        Me.btnImprimirCod = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.Gcuentas = New System.Windows.Forms.GroupBox
        Me.lbdev = New System.Windows.Forms.Label
        Me.lbivad = New System.Windows.Forms.Label
        Me.lbivag = New System.Windows.Forms.Label
        Me.lbcos = New System.Windows.Forms.Label
        Me.lbing = New System.Windows.Forms.Label
        Me.lbinv = New System.Windows.Forms.Label
        Me.lbproveedores = New System.Windows.Forms.GroupBox
        Me.lbp5 = New System.Windows.Forms.Label
        Me.lbp4 = New System.Windows.Forms.Label
        Me.lbp3 = New System.Windows.Forms.Label
        Me.lbp2 = New System.Windows.Forms.Label
        Me.lbp1 = New System.Windows.Forms.Label
        Me.lbitem = New System.Windows.Forms.Label
        Me.Documento = New System.Drawing.Printing.PrintDocument
        Me.impresora = New System.Windows.Forms.PrintDialog
        CType(Me.txtCantImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gbotones.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Gpropiedades.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Gproducto.SuspendLayout()
        Me.Gdetalles.SuspendLayout()
        Me.Gcuentas.SuspendLayout()
        Me.lbproveedores.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtcodigo
        '
        Me.txtcodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtcodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtcodigo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcodigo.Location = New System.Drawing.Point(73, 22)
        Me.txtcodigo.MaxLength = 19
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ShortcutsEnabled = False
        Me.txtcodigo.Size = New System.Drawing.Size(135, 20)
        Me.txtcodigo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtcodigo, "Codigo")
        '
        'txtdesc
        '
        Me.txtdesc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesc.Location = New System.Drawing.Point(320, 25)
        Me.txtdesc.MaxLength = 60
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.ShortcutsEnabled = False
        Me.txtdesc.Size = New System.Drawing.Size(268, 20)
        Me.txtdesc.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtdesc, "Descripción ")
        '
        'txtdetallada
        '
        Me.txtdetallada.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdetallada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdetallada.Location = New System.Drawing.Point(324, 40)
        Me.txtdetallada.Multiline = True
        Me.txtdetallada.Name = "txtdetallada"
        Me.txtdetallada.ShortcutsEnabled = False
        Me.txtdetallada.Size = New System.Drawing.Size(239, 50)
        Me.txtdetallada.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtdetallada, "Descripción detallada")
        '
        'lbaux
        '
        Me.lbaux.AutoSize = True
        Me.lbaux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaux.ForeColor = System.Drawing.Color.Red
        Me.lbaux.Location = New System.Drawing.Point(209, 28)
        Me.lbaux.Name = "lbaux"
        Me.lbaux.Size = New System.Drawing.Size(15, 13)
        Me.lbaux.TabIndex = 56
        Me.lbaux.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lbaux, "Cuenta Auxiliar ya existe")
        Me.lbaux.Visible = False
        '
        'txtnivel
        '
        Me.txtnivel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnivel.Enabled = False
        Me.txtnivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnivel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtnivel.Location = New System.Drawing.Point(123, 19)
        Me.txtnivel.Name = "txtnivel"
        Me.txtnivel.ShortcutsEnabled = False
        Me.txtnivel.Size = New System.Drawing.Size(121, 20)
        Me.txtnivel.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtnivel, "Nivel ")
        '
        'txtref
        '
        Me.txtref.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtref.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtref.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtref.Location = New System.Drawing.Point(123, 44)
        Me.txtref.MaxLength = 18
        Me.txtref.Name = "txtref"
        Me.txtref.ShortcutsEnabled = False
        Me.txtref.Size = New System.Drawing.Size(121, 20)
        Me.txtref.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtref, "referencia")
        '
        'txtcbarra
        '
        Me.txtcbarra.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcbarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcbarra.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcbarra.Location = New System.Drawing.Point(123, 70)
        Me.txtcbarra.MaxLength = 10
        Me.txtcbarra.Name = "txtcbarra"
        Me.txtcbarra.ShortcutsEnabled = False
        Me.txtcbarra.Size = New System.Drawing.Size(91, 20)
        Me.txtcbarra.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtcbarra, "código de barras")
        '
        'txtcprom
        '
        Me.txtcprom.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcprom.Enabled = False
        Me.txtcprom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcprom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcprom.Location = New System.Drawing.Point(133, 70)
        Me.txtcprom.Name = "txtcprom"
        Me.txtcprom.ReadOnly = True
        Me.txtcprom.ShortcutsEnabled = False
        Me.txtcprom.Size = New System.Drawing.Size(119, 20)
        Me.txtcprom.TabIndex = 3
        Me.txtcprom.Text = "0,00"
        Me.txtcprom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcprom, "costo promedio")
        '
        'txtcuni
        '
        Me.txtcuni.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuni.Enabled = False
        Me.txtcuni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuni.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcuni.Location = New System.Drawing.Point(133, 44)
        Me.txtcuni.Name = "txtcuni"
        Me.txtcuni.ReadOnly = True
        Me.txtcuni.ShortcutsEnabled = False
        Me.txtcuni.Size = New System.Drawing.Size(119, 20)
        Me.txtcuni.TabIndex = 2
        Me.txtcuni.Text = "0,00"
        Me.txtcuni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcuni, "costo unitario")
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcantidad.Enabled = False
        Me.txtcantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcantidad.Location = New System.Drawing.Point(133, 19)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.ReadOnly = True
        Me.txtcantidad.ShortcutsEnabled = False
        Me.txtcantidad.Size = New System.Drawing.Size(61, 20)
        Me.txtcantidad.TabIndex = 0
        Me.txtcantidad.Text = "0"
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtcantidad, "cantidad")
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtprecio.Enabled = False
        Me.txtprecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtprecio.Location = New System.Drawing.Point(387, 43)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ShortcutsEnabled = False
        Me.txtprecio.Size = New System.Drawing.Size(119, 20)
        Me.txtprecio.TabIndex = 5
        Me.txtprecio.Text = "0,00"
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtprecio, "precio")
        '
        'txtpiva
        '
        Me.txtpiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtpiva.Enabled = False
        Me.txtpiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpiva.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtpiva.Location = New System.Drawing.Point(387, 69)
        Me.txtpiva.Name = "txtpiva"
        Me.txtpiva.ShortcutsEnabled = False
        Me.txtpiva.Size = New System.Drawing.Size(119, 20)
        Me.txtpiva.TabIndex = 7
        Me.txtpiva.Text = "0,00"
        Me.txtpiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtpiva, "precio con IVA")
        '
        'txtctotal
        '
        Me.txtctotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctotal.Enabled = False
        Me.txtctotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtctotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtctotal.Location = New System.Drawing.Point(387, 15)
        Me.txtctotal.Name = "txtctotal"
        Me.txtctotal.ReadOnly = True
        Me.txtctotal.ShortcutsEnabled = False
        Me.txtctotal.Size = New System.Drawing.Size(119, 20)
        Me.txtctotal.TabIndex = 4
        Me.txtctotal.Text = "0,00"
        Me.txtctotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtctotal, "costo total ")
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtiva.Location = New System.Drawing.Point(320, 99)
        Me.txtiva.MaxLength = 6
        Me.txtiva.Name = "txtiva"
        Me.txtiva.ShortcutsEnabled = False
        Me.txtiva.Size = New System.Drawing.Size(46, 20)
        Me.txtiva.TabIndex = 8
        Me.txtiva.Text = "0,00"
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtiva, "IVA")
        '
        'txtuni
        '
        Me.txtuni.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtuni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuni.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtuni.Location = New System.Drawing.Point(76, 156)
        Me.txtuni.Name = "txtuni"
        Me.txtuni.ShortcutsEnabled = False
        Me.txtuni.Size = New System.Drawing.Size(45, 20)
        Me.txtuni.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.txtuni, "unidad")
        '
        'txtemp
        '
        Me.txtemp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtemp.Location = New System.Drawing.Point(200, 156)
        Me.txtemp.Name = "txtemp"
        Me.txtemp.ShortcutsEnabled = False
        Me.txtemp.Size = New System.Drawing.Size(103, 20)
        Me.txtemp.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtemp, "empaque")
        '
        'txtcanemp
        '
        Me.txtcanemp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcanemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcanemp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcanemp.Location = New System.Drawing.Point(475, 154)
        Me.txtcanemp.Name = "txtcanemp"
        Me.txtcanemp.ShortcutsEnabled = False
        Me.txtcanemp.Size = New System.Drawing.Size(103, 20)
        Me.txtcanemp.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.txtcanemp, "cantidad por empaque")
        '
        'txtconcep
        '
        Me.txtconcep.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtconcep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconcep.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtconcep.Location = New System.Drawing.Point(191, 246)
        Me.txtconcep.MaxLength = 20
        Me.txtconcep.Name = "txtconcep"
        Me.txtconcep.Size = New System.Drawing.Size(103, 20)
        Me.txtconcep.TabIndex = 20
        Me.ToolTip1.SetToolTip(Me.txtconcep, "concepto comicionable")
        '
        'txtnumreg
        '
        Me.txtnumreg.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumreg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumreg.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtnumreg.Location = New System.Drawing.Point(161, 13)
        Me.txtnumreg.MaxLength = 20
        Me.txtnumreg.Name = "txtnumreg"
        Me.txtnumreg.Size = New System.Drawing.Size(121, 20)
        Me.txtnumreg.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtnumreg, "numero de registro")
        '
        'txtarancel
        '
        Me.txtarancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtarancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarancel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtarancel.Location = New System.Drawing.Point(161, 34)
        Me.txtarancel.MaxLength = 6
        Me.txtarancel.Name = "txtarancel"
        Me.txtarancel.ShortcutsEnabled = False
        Me.txtarancel.Size = New System.Drawing.Size(121, 20)
        Me.txtarancel.TabIndex = 3
        Me.txtarancel.Text = "0,00"
        Me.txtarancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtarancel, "Porcentaje de  Arancel")
        '
        'txtposAran
        '
        Me.txtposAran.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtposAran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtposAran.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtposAran.Location = New System.Drawing.Point(161, 55)
        Me.txtposAran.MaxLength = 20
        Me.txtposAran.Name = "txtposAran"
        Me.txtposAran.Size = New System.Drawing.Size(121, 20)
        Me.txtposAran.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtposAran, "Posición Arancelaria")
        '
        'rbimp2
        '
        Me.rbimp2.AutoSize = True
        Me.rbimp2.Location = New System.Drawing.Point(59, 16)
        Me.rbimp2.Name = "rbimp2"
        Me.rbimp2.Size = New System.Drawing.Size(97, 17)
        Me.rbimp2.TabIndex = 1
        Me.rbimp2.Text = "Si   Nº Registro"
        Me.ToolTip1.SetToolTip(Me.rbimp2, "se importa")
        Me.rbimp2.UseVisualStyleBackColor = True
        '
        'rbimp1
        '
        Me.rbimp1.AutoSize = True
        Me.rbimp1.Checked = True
        Me.rbimp1.Location = New System.Drawing.Point(14, 16)
        Me.rbimp1.Name = "rbimp1"
        Me.rbimp1.Size = New System.Drawing.Size(39, 17)
        Me.rbimp1.TabIndex = 0
        Me.rbimp1.TabStop = True
        Me.rbimp1.Text = "No"
        Me.ToolTip1.SetToolTip(Me.rbimp1, "no se importa")
        Me.rbimp1.UseVisualStyleBackColor = True
        '
        'cbestado
        '
        Me.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbestado.FormattingEnabled = True
        Me.cbestado.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.cbestado.Location = New System.Drawing.Point(191, 219)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(103, 21)
        Me.cbestado.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.cbestado, "estado del producto")
        '
        'cmdprov
        '
        Me.cmdprov.Location = New System.Drawing.Point(306, 125)
        Me.cmdprov.Name = "cmdprov"
        Me.cmdprov.Size = New System.Drawing.Size(141, 23)
        Me.cmdprov.TabIndex = 11
        Me.cmdprov.Text = "Proveedores Del Articulo"
        Me.ToolTip1.SetToolTip(Me.cmdprov, "proveedores")
        Me.cmdprov.UseVisualStyleBackColor = True
        '
        'cdmcuentas
        '
        Me.cdmcuentas.Location = New System.Drawing.Point(159, 125)
        Me.cdmcuentas.Name = "cdmcuentas"
        Me.cdmcuentas.Size = New System.Drawing.Size(141, 23)
        Me.cdmcuentas.TabIndex = 10
        Me.cdmcuentas.Text = "Cuentas Del Articulo"
        Me.ToolTip1.SetToolTip(Me.cdmcuentas, "cuentas contables")
        Me.cdmcuentas.UseVisualStyleBackColor = True
        '
        'cdmlista
        '
        Me.cdmlista.Location = New System.Drawing.Point(510, 42)
        Me.cdmlista.Name = "cdmlista"
        Me.cdmlista.Size = New System.Drawing.Size(68, 23)
        Me.cdmlista.TabIndex = 6
        Me.cdmlista.Text = "Detalles"
        Me.ToolTip1.SetToolTip(Me.cdmlista, "ver listas de precios")
        Me.cdmlista.UseVisualStyleBackColor = True
        '
        'cmddeta
        '
        Me.cmddeta.Location = New System.Drawing.Point(199, 17)
        Me.cmddeta.Name = "cmddeta"
        Me.cmddeta.Size = New System.Drawing.Size(53, 23)
        Me.cmddeta.TabIndex = 1
        Me.cmddeta.Text = "Detalles"
        Me.ToolTip1.SetToolTip(Me.cmddeta, "ver bodegas")
        Me.cmddeta.UseVisualStyleBackColor = True
        '
        'txtpp
        '
        Me.txtpp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtpp.Location = New System.Drawing.Point(522, 181)
        Me.txtpp.Name = "txtpp"
        Me.txtpp.ShortcutsEnabled = False
        Me.txtpp.Size = New System.Drawing.Size(56, 20)
        Me.txtpp.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.txtpp, "punto de pedido")
        '
        'txtmin
        '
        Me.txtmin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmin.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtmin.Location = New System.Drawing.Point(331, 179)
        Me.txtmin.Name = "txtmin"
        Me.txtmin.ShortcutsEnabled = False
        Me.txtmin.Size = New System.Drawing.Size(55, 20)
        Me.txtmin.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.txtmin, "cantidad mínima")
        '
        'txtuni_emp
        '
        Me.txtuni_emp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtuni_emp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuni_emp.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtuni_emp.Location = New System.Drawing.Point(188, 181)
        Me.txtuni_emp.Name = "txtuni_emp"
        Me.txtuni_emp.ShortcutsEnabled = False
        Me.txtuni_emp.Size = New System.Drawing.Size(58, 20)
        Me.txtuni_emp.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.txtuni_emp, "unidades de empaques")
        '
        'cbexen
        '
        Me.cbexen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbexen.FormattingEnabled = True
        Me.cbexen.Items.AddRange(New Object() {"no", "si"})
        Me.cbexen.Location = New System.Drawing.Point(126, 98)
        Me.cbexen.Name = "cbexen"
        Me.cbexen.Size = New System.Drawing.Size(39, 21)
        Me.cbexen.TabIndex = 100
        Me.ToolTip1.SetToolTip(Me.cbexen, "exento")
        '
        'cbexclu
        '
        Me.cbexclu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbexclu.FormattingEnabled = True
        Me.cbexclu.Items.AddRange(New Object() {"no", "si"})
        Me.cbexclu.Location = New System.Drawing.Point(236, 98)
        Me.cbexclu.Name = "cbexclu"
        Me.cbexclu.Size = New System.Drawing.Size(39, 21)
        Me.cbexclu.TabIndex = 102
        Me.ToolTip1.SetToolTip(Me.cbexclu, "exento")
        '
        'txtmargen
        '
        Me.txtmargen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtmargen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmargen.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtmargen.Location = New System.Drawing.Point(451, 100)
        Me.txtmargen.MaxLength = 6
        Me.txtmargen.Name = "txtmargen"
        Me.txtmargen.ShortcutsEnabled = False
        Me.txtmargen.Size = New System.Drawing.Size(46, 20)
        Me.txtmargen.TabIndex = 103
        Me.txtmargen.Text = "0,00"
        Me.txtmargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtmargen, "IVA")
        '
        'CmdEliminar
        '
        Me.CmdEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar1
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = False
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(268, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(9, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(559, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Último")
        Me.CmdUltimo.UseVisualStyleBackColor = False
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(508, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = False
        '
        'CmdAtras
        '
        Me.CmdAtras.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(457, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 8
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atrás")
        Me.CmdAtras.UseVisualStyleBackColor = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(406, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(319, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(113, 12)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(165, 12)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(61, 12)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'txtCantImprimir
        '
        Me.txtCantImprimir.Location = New System.Drawing.Point(218, 70)
        Me.txtCantImprimir.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.txtCantImprimir.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantImprimir.Name = "txtCantImprimir"
        Me.txtCantImprimir.Size = New System.Drawing.Size(41, 20)
        Me.txtCantImprimir.TabIndex = 64
        Me.ToolTip1.SetToolTip(Me.txtCantImprimir, "Numero de Copias")
        Me.txtCantImprimir.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Gbotones
        '
        Me.Gbotones.Controls.Add(Me.CmdEliminar)
        Me.Gbotones.Controls.Add(Me.CmdMostrar)
        Me.Gbotones.Controls.Add(Me.cmdNuevo)
        Me.Gbotones.Controls.Add(Me.CmdUltimo)
        Me.Gbotones.Controls.Add(Me.CmdSiguiente)
        Me.Gbotones.Controls.Add(Me.CmdAtras)
        Me.Gbotones.Controls.Add(Me.CmdPrimero)
        Me.Gbotones.Controls.Add(Me.cmdsalir)
        Me.Gbotones.Controls.Add(Me.cmdcancelar)
        Me.Gbotones.Controls.Add(Me.cmdmodificar)
        Me.Gbotones.Controls.Add(Me.cmdguardar)
        Me.Gbotones.Location = New System.Drawing.Point(2, 466)
        Me.Gbotones.Name = "Gbotones"
        Me.Gbotones.Size = New System.Drawing.Size(621, 56)
        Me.Gbotones.TabIndex = 0
        Me.Gbotones.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Gpropiedades)
        Me.GroupBox5.Controls.Add(Me.Gproducto)
        Me.GroupBox5.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(621, 466)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'Gpropiedades
        '
        Me.Gpropiedades.Controls.Add(Me.txtmargen)
        Me.Gpropiedades.Controls.Add(Me.Label15)
        Me.Gpropiedades.Controls.Add(Me.Label28)
        Me.Gpropiedades.Controls.Add(Me.cbexclu)
        Me.Gpropiedades.Controls.Add(Me.cbexen)
        Me.Gpropiedades.Controls.Add(Me.Label24)
        Me.Gpropiedades.Controls.Add(Me.Label26)
        Me.Gpropiedades.Controls.Add(Me.Label23)
        Me.Gpropiedades.Controls.Add(Me.txtpp)
        Me.Gpropiedades.Controls.Add(Me.txtmin)
        Me.Gpropiedades.Controls.Add(Me.txtuni_emp)
        Me.Gpropiedades.Controls.Add(Me.Label25)
        Me.Gpropiedades.Controls.Add(Me.txtconcep)
        Me.Gpropiedades.Controls.Add(Me.Label20)
        Me.Gpropiedades.Controls.Add(Me.GroupBox1)
        Me.Gpropiedades.Controls.Add(Me.cbestado)
        Me.Gpropiedades.Controls.Add(Me.Label19)
        Me.Gpropiedades.Controls.Add(Me.txtcanemp)
        Me.Gpropiedades.Controls.Add(Me.Label18)
        Me.Gpropiedades.Controls.Add(Me.txtemp)
        Me.Gpropiedades.Controls.Add(Me.Label17)
        Me.Gpropiedades.Controls.Add(Me.txtuni)
        Me.Gpropiedades.Controls.Add(Me.Label16)
        Me.Gpropiedades.Controls.Add(Me.txtiva)
        Me.Gpropiedades.Controls.Add(Me.Label13)
        Me.Gpropiedades.Controls.Add(Me.txtctotal)
        Me.Gpropiedades.Controls.Add(Me.Label12)
        Me.Gpropiedades.Controls.Add(Me.cmdprov)
        Me.Gpropiedades.Controls.Add(Me.cdmcuentas)
        Me.Gpropiedades.Controls.Add(Me.cdmlista)
        Me.Gpropiedades.Controls.Add(Me.txtpiva)
        Me.Gpropiedades.Controls.Add(Me.Label11)
        Me.Gpropiedades.Controls.Add(Me.txtprecio)
        Me.Gpropiedades.Controls.Add(Me.Label9)
        Me.Gpropiedades.Controls.Add(Me.cmddeta)
        Me.Gpropiedades.Controls.Add(Me.txtcprom)
        Me.Gpropiedades.Controls.Add(Me.Label6)
        Me.Gpropiedades.Controls.Add(Me.txtcuni)
        Me.Gpropiedades.Controls.Add(Me.Label7)
        Me.Gpropiedades.Controls.Add(Me.txtcantidad)
        Me.Gpropiedades.Controls.Add(Me.Label10)
        Me.Gpropiedades.Controls.Add(Me.Label14)
        Me.Gpropiedades.Controls.Add(Me.Label27)
        Me.Gpropiedades.Enabled = False
        Me.Gpropiedades.Location = New System.Drawing.Point(12, 169)
        Me.Gpropiedades.Name = "Gpropiedades"
        Me.Gpropiedades.Size = New System.Drawing.Size(596, 291)
        Me.Gpropiedades.TabIndex = 1
        Me.Gpropiedades.TabStop = False
        Me.Gpropiedades.Text = "Propiedades"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(390, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "MARGEN"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(500, 104)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 13)
        Me.Label28.TabIndex = 105
        Me.Label28.Text = "%"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(70, 103)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 13)
        Me.Label24.TabIndex = 99
        Me.Label24.Text = "EXENTO"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(394, 184)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(122, 13)
        Me.Label26.TabIndex = 97
        Me.Label26.Text = "PUNTO DE PEDIDO"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(252, 184)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(75, 13)
        Me.Label23.TabIndex = 96
        Me.Label23.Text = "CANT. MÍN."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(16, 185)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(164, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "UNIDADES DE EMPAQUES"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 249)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(170, 13)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "CONCEPTO COMICIONABLE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtposAran)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtarancel)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtnumreg)
        Me.GroupBox1.Controls.Add(Me.rbimp2)
        Me.GroupBox1.Controls.Add(Me.rbimp1)
        Me.GroupBox1.Location = New System.Drawing.Point(300, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 83)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "¿Se importa?"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(14, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 13)
        Me.Label22.TabIndex = 90
        Me.Label22.Text = "Posición Arancelaria"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(115, 13)
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "Porcentaje de  Arancel"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 227)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(158, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "ESTADO DEL PRODUCTO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(309, 159)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(164, 13)
        Me.Label18.TabIndex = 85
        Me.Label18.Text = "CANTIDAD POR EMPAQUE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(127, 159)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 83
        Me.Label17.Text = "EMPAQUE"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 159)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "UNIDAD"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(278, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "I.V.A."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(269, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "COSTO TOTAL"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(269, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "PRECIO CON IVA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(269, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "PRECIO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "COSTO PROM."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "COSTO UNI."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "CANTIDAD"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(369, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "%"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(168, 102)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 13)
        Me.Label27.TabIndex = 101
        Me.Label27.Text = "EXCLUIDO"
        '
        'Gproducto
        '
        Me.Gproducto.Controls.Add(Me.Gdetalles)
        Me.Gproducto.Controls.Add(Me.txtcodigo)
        Me.Gproducto.Controls.Add(Me.Label1)
        Me.Gproducto.Controls.Add(Me.txtdesc)
        Me.Gproducto.Controls.Add(Me.Label2)
        Me.Gproducto.Controls.Add(Me.lbaux)
        Me.Gproducto.Location = New System.Drawing.Point(9, 11)
        Me.Gproducto.Name = "Gproducto"
        Me.Gproducto.Size = New System.Drawing.Size(597, 154)
        Me.Gproducto.TabIndex = 0
        Me.Gproducto.TabStop = False
        '
        'Gdetalles
        '
        Me.Gdetalles.Controls.Add(Me.btnImptodos)
        Me.Gdetalles.Controls.Add(Me.btnImprimirCod)
        Me.Gdetalles.Controls.Add(Me.txtCantImprimir)
        Me.Gdetalles.Controls.Add(Me.txtcbarra)
        Me.Gdetalles.Controls.Add(Me.Label5)
        Me.Gdetalles.Controls.Add(Me.txtref)
        Me.Gdetalles.Controls.Add(Me.Label4)
        Me.Gdetalles.Controls.Add(Me.Label3)
        Me.Gdetalles.Controls.Add(Me.txtnivel)
        Me.Gdetalles.Controls.Add(Me.txtdetallada)
        Me.Gdetalles.Controls.Add(Me.Label8)
        Me.Gdetalles.Location = New System.Drawing.Point(10, 48)
        Me.Gdetalles.Name = "Gdetalles"
        Me.Gdetalles.Size = New System.Drawing.Size(579, 98)
        Me.Gdetalles.TabIndex = 2
        Me.Gdetalles.TabStop = False
        Me.Gdetalles.Text = "Detalles del Producto"
        '
        'btnImptodos
        '
        Me.btnImptodos.Location = New System.Drawing.Point(263, 38)
        Me.btnImptodos.Name = "btnImptodos"
        Me.btnImptodos.Size = New System.Drawing.Size(53, 23)
        Me.btnImptodos.TabIndex = 66
        Me.btnImptodos.Text = "Todos"
        Me.btnImptodos.UseVisualStyleBackColor = True
        '
        'btnImprimirCod
        '
        Me.btnImprimirCod.Location = New System.Drawing.Point(263, 69)
        Me.btnImprimirCod.Name = "btnImprimirCod"
        Me.btnImprimirCod.Size = New System.Drawing.Size(53, 23)
        Me.btnImprimirCod.TabIndex = 65
        Me.btnImprimirCod.Text = "Imprimir"
        Me.btnImprimirCod.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "CÓD. DE BARRAS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "REFERENCIA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(332, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "DESCRIPCIÓN DETALLADA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "NIVEL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CÓDIGO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(228, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "DESCRIPCIÓN"
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(582, 526)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 77
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(499, 525)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 76
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(5, 526)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 75
        Me.lbestado.Text = "NULO"
        '
        'Gcuentas
        '
        Me.Gcuentas.Controls.Add(Me.lbdev)
        Me.Gcuentas.Controls.Add(Me.lbivad)
        Me.Gcuentas.Controls.Add(Me.lbivag)
        Me.Gcuentas.Controls.Add(Me.lbcos)
        Me.Gcuentas.Controls.Add(Me.lbing)
        Me.Gcuentas.Controls.Add(Me.lbinv)
        Me.Gcuentas.Location = New System.Drawing.Point(311, 525)
        Me.Gcuentas.Name = "Gcuentas"
        Me.Gcuentas.Size = New System.Drawing.Size(182, 133)
        Me.Gcuentas.TabIndex = 78
        Me.Gcuentas.TabStop = False
        Me.Gcuentas.Text = "cuentas"
        Me.Gcuentas.Visible = False
        '
        'lbdev
        '
        Me.lbdev.AutoSize = True
        Me.lbdev.Location = New System.Drawing.Point(216, 48)
        Me.lbdev.Name = "lbdev"
        Me.lbdev.Size = New System.Drawing.Size(70, 13)
        Me.lbdev.TabIndex = 5
        Me.lbdev.Text = "devoluciones"
        '
        'lbivad
        '
        Me.lbivad.AutoSize = True
        Me.lbivad.Location = New System.Drawing.Point(123, 48)
        Me.lbivad.Name = "lbivad"
        Me.lbivad.Size = New System.Drawing.Size(82, 13)
        Me.lbivad.TabIndex = 4
        Me.lbivad.Text = "iva descontable"
        '
        'lbivag
        '
        Me.lbivag.AutoSize = True
        Me.lbivag.Location = New System.Drawing.Point(15, 48)
        Me.lbivag.Name = "lbivag"
        Me.lbivag.Size = New System.Drawing.Size(69, 13)
        Me.lbivag.TabIndex = 3
        Me.lbivag.Text = "iva generado"
        '
        'lbcos
        '
        Me.lbcos.AutoSize = True
        Me.lbcos.Location = New System.Drawing.Point(216, 19)
        Me.lbcos.Name = "lbcos"
        Me.lbcos.Size = New System.Drawing.Size(38, 13)
        Me.lbcos.TabIndex = 2
        Me.lbcos.Text = "costos"
        '
        'lbing
        '
        Me.lbing.AutoSize = True
        Me.lbing.Location = New System.Drawing.Point(120, 19)
        Me.lbing.Name = "lbing"
        Me.lbing.Size = New System.Drawing.Size(46, 13)
        Me.lbing.TabIndex = 1
        Me.lbing.Text = "ingresos"
        '
        'lbinv
        '
        Me.lbinv.AutoSize = True
        Me.lbinv.Location = New System.Drawing.Point(15, 19)
        Me.lbinv.Name = "lbinv"
        Me.lbinv.Size = New System.Drawing.Size(53, 13)
        Me.lbinv.TabIndex = 0
        Me.lbinv.Text = "inventario"
        '
        'lbproveedores
        '
        Me.lbproveedores.Controls.Add(Me.lbp5)
        Me.lbproveedores.Controls.Add(Me.lbp4)
        Me.lbproveedores.Controls.Add(Me.lbp3)
        Me.lbproveedores.Controls.Add(Me.lbp2)
        Me.lbproveedores.Controls.Add(Me.lbp1)
        Me.lbproveedores.Location = New System.Drawing.Point(144, 525)
        Me.lbproveedores.Name = "lbproveedores"
        Me.lbproveedores.Size = New System.Drawing.Size(153, 68)
        Me.lbproveedores.TabIndex = 79
        Me.lbproveedores.TabStop = False
        Me.lbproveedores.Text = "proveedores"
        Me.lbproveedores.Visible = False
        '
        'lbp5
        '
        Me.lbp5.AutoSize = True
        Me.lbp5.Location = New System.Drawing.Point(56, 48)
        Me.lbp5.Name = "lbp5"
        Me.lbp5.Size = New System.Drawing.Size(27, 13)
        Me.lbp5.TabIndex = 4
        Me.lbp5.Text = "lbp5"
        '
        'lbp4
        '
        Me.lbp4.AutoSize = True
        Me.lbp4.Location = New System.Drawing.Point(15, 48)
        Me.lbp4.Name = "lbp4"
        Me.lbp4.Size = New System.Drawing.Size(27, 13)
        Me.lbp4.TabIndex = 3
        Me.lbp4.Text = "lbp4"
        '
        'lbp3
        '
        Me.lbp3.AutoSize = True
        Me.lbp3.Location = New System.Drawing.Point(116, 20)
        Me.lbp3.Name = "lbp3"
        Me.lbp3.Size = New System.Drawing.Size(27, 13)
        Me.lbp3.TabIndex = 2
        Me.lbp3.Text = "lbp3"
        '
        'lbp2
        '
        Me.lbp2.AutoSize = True
        Me.lbp2.Location = New System.Drawing.Point(61, 20)
        Me.lbp2.Name = "lbp2"
        Me.lbp2.Size = New System.Drawing.Size(27, 13)
        Me.lbp2.TabIndex = 1
        Me.lbp2.Text = "lbp2"
        '
        'lbp1
        '
        Me.lbp1.AutoSize = True
        Me.lbp1.Location = New System.Drawing.Point(15, 19)
        Me.lbp1.Name = "lbp1"
        Me.lbp1.Size = New System.Drawing.Size(27, 13)
        Me.lbp1.TabIndex = 0
        Me.lbp1.Text = "lbp1"
        '
        'lbitem
        '
        Me.lbitem.AutoSize = True
        Me.lbitem.Location = New System.Drawing.Point(71, 526)
        Me.lbitem.Name = "lbitem"
        Me.lbitem.Size = New System.Drawing.Size(45, 13)
        Me.lbitem.TabIndex = 80
        Me.lbitem.Text = "Label29"
        '
        'Documento
        '
        '
        'impresora
        '
        Me.impresora.UseEXDialog = True
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(626, 545)
        Me.Controls.Add(Me.lbitem)
        Me.Controls.Add(Me.lbproveedores)
        Me.Controls.Add(Me.Gcuentas)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Gbotones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Productos del Inventario"
        CType(Me.txtCantImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gbotones.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Gpropiedades.ResumeLayout(False)
        Me.Gpropiedades.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Gproducto.ResumeLayout(False)
        Me.Gproducto.PerformLayout()
        Me.Gdetalles.ResumeLayout(False)
        Me.Gdetalles.PerformLayout()
        Me.Gcuentas.ResumeLayout(False)
        Me.Gcuentas.PerformLayout()
        Me.lbproveedores.ResumeLayout(False)
        Me.lbproveedores.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Gbotones As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Gproducto As System.Windows.Forms.GroupBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtdetallada As System.Windows.Forms.TextBox
    Friend WithEvents lbaux As System.Windows.Forms.Label
    Friend WithEvents Gdetalles As System.Windows.Forms.GroupBox
    Friend WithEvents txtnivel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcbarra As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Gpropiedades As System.Windows.Forms.GroupBox
    Friend WithEvents txtcprom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcuni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmddeta As System.Windows.Forms.Button
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cdmlista As System.Windows.Forms.Button
    Friend WithEvents txtpiva As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdprov As System.Windows.Forms.Button
    Friend WithEvents cdmcuentas As System.Windows.Forms.Button
    Friend WithEvents txtctotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtuni As System.Windows.Forms.TextBox
    Friend WithEvents txtcanemp As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtemp As System.Windows.Forms.TextBox
    Friend WithEvents cbestado As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtconcep As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents rbimp2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbimp1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtnumreg As System.Windows.Forms.TextBox
    Friend WithEvents txtposAran As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtarancel As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtpp As System.Windows.Forms.TextBox
    Friend WithEvents txtmin As System.Windows.Forms.TextBox
    Friend WithEvents txtuni_emp As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbexclu As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbexen As System.Windows.Forms.ComboBox
    Friend WithEvents Gcuentas As System.Windows.Forms.GroupBox
    Friend WithEvents lbdev As System.Windows.Forms.Label
    Friend WithEvents lbivad As System.Windows.Forms.Label
    Friend WithEvents lbivag As System.Windows.Forms.Label
    Friend WithEvents lbcos As System.Windows.Forms.Label
    Friend WithEvents lbing As System.Windows.Forms.Label
    Friend WithEvents lbinv As System.Windows.Forms.Label
    Friend WithEvents lbproveedores As System.Windows.Forms.GroupBox
    Friend WithEvents lbp5 As System.Windows.Forms.Label
    Friend WithEvents lbp4 As System.Windows.Forms.Label
    Friend WithEvents lbp3 As System.Windows.Forms.Label
    Friend WithEvents lbp2 As System.Windows.Forms.Label
    Friend WithEvents lbp1 As System.Windows.Forms.Label
    Friend WithEvents txtmargen As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lbitem As System.Windows.Forms.Label
    Friend WithEvents txtCantImprimir As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnImprimirCod As System.Windows.Forms.Button
    Friend WithEvents Documento As System.Drawing.Printing.PrintDocument
    Friend WithEvents impresora As System.Windows.Forms.PrintDialog
    Friend WithEvents btnImptodos As System.Windows.Forms.Button
End Class
