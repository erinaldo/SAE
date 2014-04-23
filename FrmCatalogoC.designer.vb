<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCatalogoC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCatalogoC))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INICIAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TSA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdActCuenta = New System.Windows.Forms.Button
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdesc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbaux = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtnat = New System.Windows.Forms.TextBox
        Me.txtsaldo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbtipo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbnivel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdprint = New System.Windows.Forms.Button
        Me.cmdactualizar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chAuxiliar = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mibarra)
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 458)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(217, 277)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 61
        Me.ToolTip1.SetToolTip(Me.mibarra, "Por Favor Espere...")
        Me.mibarra.Visible = False
        '
        'grilla
        '
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.INICIAL, Me.TSI, Me.Debitos, Me.Creditos, Me.Cuenta, Me.TSA})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grilla.Location = New System.Drawing.Point(19, 161)
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
        Me.grilla.TabIndex = 59
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdActCuenta)
        Me.GroupBox4.Controls.Add(Me.txtcuenta)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.txtdesc)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.lbaux)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(674, 58)
        Me.GroupBox4.TabIndex = 56
        Me.GroupBox4.TabStop = False
        '
        'cmdActCuenta
        '
        Me.cmdActCuenta.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdActCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActCuenta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdActCuenta.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdActCuenta.Location = New System.Drawing.Point(609, 13)
        Me.cmdActCuenta.Name = "cmdActCuenta"
        Me.cmdActCuenta.Size = New System.Drawing.Size(52, 38)
        Me.cmdActCuenta.TabIndex = 55
        Me.cmdActCuenta.Text = "&C"
        Me.cmdActCuenta.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdActCuenta, "Actualizar Cuenta Alt+C")
        Me.cmdActCuenta.UseVisualStyleBackColor = False
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtcuenta.Location = New System.Drawing.Point(69, 22)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ReadOnly = True
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(84, 20)
        Me.txtcuenta.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.txtcuenta, "Cuenta")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CUENTA"
        '
        'txtdesc
        '
        Me.txtdesc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesc.Location = New System.Drawing.Point(259, 22)
        Me.txtdesc.MaxLength = 100
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.ReadOnly = True
        Me.txtdesc.ShortcutsEnabled = False
        Me.txtdesc.Size = New System.Drawing.Size(344, 20)
        Me.txtdesc.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.txtdesc, "Descripción Cuenta")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(170, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "DESCRIPCIÓN"
        '
        'lbaux
        '
        Me.lbaux.AutoSize = True
        Me.lbaux.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbaux.ForeColor = System.Drawing.Color.Red
        Me.lbaux.Location = New System.Drawing.Point(153, 26)
        Me.lbaux.Name = "lbaux"
        Me.lbaux.Size = New System.Drawing.Size(15, 13)
        Me.lbaux.TabIndex = 56
        Me.lbaux.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lbaux, "Cuenta Auxiliar ya existe")
        Me.lbaux.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chAuxiliar)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtnat)
        Me.GroupBox5.Controls.Add(Me.txtsaldo)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.cbtipo)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.cbnivel)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 72)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(674, 83)
        Me.GroupBox5.TabIndex = 57
        Me.GroupBox5.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "DETALLES DE LA CUENTA"
        '
        'txtnat
        '
        Me.txtnat.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnat.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtnat.Location = New System.Drawing.Point(364, 55)
        Me.txtnat.Name = "txtnat"
        Me.txtnat.ReadOnly = True
        Me.txtnat.Size = New System.Drawing.Size(25, 20)
        Me.txtnat.TabIndex = 59
        Me.txtnat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.txtnat, "Naturaleza D=Debito, C=Credito")
        '
        'txtsaldo
        '
        Me.txtsaldo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtsaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsaldo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtsaldo.Location = New System.Drawing.Point(444, 53)
        Me.txtsaldo.Name = "txtsaldo"
        Me.txtsaldo.ReadOnly = True
        Me.txtsaldo.Size = New System.Drawing.Size(151, 21)
        Me.txtsaldo.TabIndex = 56
        Me.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtsaldo, "Saldo cuenta")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(276, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "NATURALEZA"
        '
        'cbtipo
        '
        Me.cbtipo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtipo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.cbtipo.Location = New System.Drawing.Point(194, 55)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.ReadOnly = True
        Me.cbtipo.Size = New System.Drawing.Size(76, 20)
        Me.cbtipo.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.cbtipo, "Tipo")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(394, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "SALDO "
        '
        'cbnivel
        '
        Me.cbnivel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cbnivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnivel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.cbnivel.Location = New System.Drawing.Point(68, 55)
        Me.cbnivel.Name = "cbnivel"
        Me.cbnivel.ReadOnly = True
        Me.cbnivel.Size = New System.Drawing.Size(88, 20)
        Me.cbnivel.TabIndex = 57
        Me.ToolTip1.SetToolTip(Me.cbnivel, "Nivel ")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(158, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "TIPO "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "NIVEL"
        '
        'cmdprint
        '
        Me.cmdprint.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(370, 12)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdprint, "Imprimir todo el catalogo de cuentas")
        Me.cmdprint.UseVisualStyleBackColor = False
        '
        'cmdactualizar
        '
        Me.cmdactualizar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdactualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdactualizar.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.cmdactualizar.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdactualizar.Location = New System.Drawing.Point(266, 12)
        Me.cmdactualizar.Name = "cmdactualizar"
        Me.cmdactualizar.Size = New System.Drawing.Size(52, 38)
        Me.cmdactualizar.TabIndex = 5
        Me.cmdactualizar.Text = "&A"
        Me.cmdactualizar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ToolTip1.SetToolTip(Me.cmdactualizar, "Actualizar  Catalogo De Cuentas Alt+A")
        Me.cmdactualizar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdprint)
        Me.GroupBox2.Controls.Add(Me.CmdEliminar)
        Me.GroupBox2.Controls.Add(Me.cmdactualizar)
        Me.GroupBox2.Controls.Add(Me.CmdUltimo)
        Me.GroupBox2.Controls.Add(Me.cmdEdit)
        Me.GroupBox2.Controls.Add(Me.CmdListo)
        Me.GroupBox2.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox2.Controls.Add(Me.CmdAtras)
        Me.GroupBox2.Controls.Add(Me.CmdSalir)
        Me.GroupBox2.Controls.Add(Me.CmdCancelar)
        Me.GroupBox2.Controls.Add(Me.CmdPrimero)
        Me.GroupBox2.Controls.Add(Me.CmdMostrar)
        Me.GroupBox2.Controls.Add(Me.CmdNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 453)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(708, 56)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(214, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar Registro")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(648, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Último")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(163, 12)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 38)
        Me.cmdEdit.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Editar")
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
        Me.CmdSiguiente.Location = New System.Drawing.Point(597, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(546, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 10
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atrás")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(421, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(111, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(495, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(318, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(12, 512)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(139, 22)
        Me.lbestado.TabIndex = 58
        Me.lbestado.Text = "Estado"
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(647, 514)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 57
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(565, 513)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 56
        Me.Label38.Text = "Registro Nro."
        '
        'chAuxiliar
        '
        Me.chAuxiliar.AutoSize = True
        Me.chAuxiliar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chAuxiliar.Location = New System.Drawing.Point(28, 32)
        Me.chAuxiliar.Name = "chAuxiliar"
        Me.chAuxiliar.Size = New System.Drawing.Size(144, 17)
        Me.chAuxiliar.TabIndex = 61
        Me.chAuxiliar.Text = "Marcar como Auxiliar"
        Me.chAuxiliar.UseVisualStyleBackColor = True
        '
        'FrmCatalogoC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(717, 533)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCatalogoC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selección del PUC"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdesc As System.Windows.Forms.TextBox
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdactualizar As System.Windows.Forms.Button
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdActCuenta As System.Windows.Forms.Button
    Friend WithEvents cbtipo As System.Windows.Forms.TextBox
    Friend WithEvents cbnivel As System.Windows.Forms.TextBox
    Friend WithEvents txtnat As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbaux As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INICIAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents chAuxiliar As System.Windows.Forms.CheckBox
End Class
