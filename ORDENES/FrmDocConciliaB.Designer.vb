<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocConciliaB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocConciliaB))
        Me.Gmov = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.txtdif = New System.Windows.Forms.TextBox
        Me.TxtDocumento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtdb = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcr = New System.Windows.Forms.TextBox
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtnomcta = New System.Windows.Forms.TextBox
        Me.txtsalB = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.txtdifsal = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtsaldo = New System.Windows.Forms.TextBox
        Me.txtsalcon = New System.Windows.Forms.TextBox
        Me.txtsalB2 = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gdes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gDeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gCred = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gBase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gdvmto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gfvmto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grubro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.trubro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gmov.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gmov
        '
        Me.Gmov.Controls.Add(Me.GroupBox4)
        Me.Gmov.Controls.Add(Me.gitems)
        Me.Gmov.Location = New System.Drawing.Point(6, 86)
        Me.Gmov.Name = "Gmov"
        Me.Gmov.Size = New System.Drawing.Size(956, 228)
        Me.Gmov.TabIndex = 146
        Me.Gmov.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtNumero)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtDoc)
        Me.GroupBox4.Controls.Add(Me.txtdif)
        Me.GroupBox4.Controls.Add(Me.TxtDocumento)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtdb)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtcr)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(944, 72)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtNumero.Enabled = False
        Me.TxtNumero.Location = New System.Drawing.Point(455, 17)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(84, 20)
        Me.TxtNumero.TabIndex = 54
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CmdListo)
        Me.GroupBox5.Controls.Add(Me.CmdCancelar)
        Me.GroupBox5.Controls.Add(Me.CmdNuevo)
        Me.GroupBox5.Location = New System.Drawing.Point(752, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(173, 57)
        Me.GroupBox5.TabIndex = 50
        Me.GroupBox5.TabStop = False
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(57, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(51, 38)
        Me.CmdListo.TabIndex = 52
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(111, 11)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(49, 39)
        Me.CmdCancelar.TabIndex = 53
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(48, 38)
        Me.CmdNuevo.TabIndex = 51
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 16)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Tipo de Documento"
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDoc.Enabled = False
        Me.txtDoc.Location = New System.Drawing.Point(204, 17)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.ReadOnly = True
        Me.txtDoc.Size = New System.Drawing.Size(246, 20)
        Me.txtDoc.TabIndex = 45
        '
        'txtdif
        '
        Me.txtdif.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdif.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtdif.Location = New System.Drawing.Point(524, 45)
        Me.txtdif.Name = "txtdif"
        Me.txtdif.ReadOnly = True
        Me.txtdif.Size = New System.Drawing.Size(183, 21)
        Me.txtdif.TabIndex = 46
        Me.txtdif.Text = "0"
        Me.txtdif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDocumento
        '
        Me.TxtDocumento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocumento.Enabled = False
        Me.TxtDocumento.Location = New System.Drawing.Point(153, 17)
        Me.TxtDocumento.MaxLength = 4
        Me.TxtDocumento.Name = "TxtDocumento"
        Me.TxtDocumento.ReadOnly = True
        Me.TxtDocumento.Size = New System.Drawing.Size(45, 20)
        Me.TxtDocumento.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "DEBITO $"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label9.Location = New System.Drawing.Point(500, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 23)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "="
        '
        'txtdb
        '
        Me.txtdb.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdb.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtdb.Location = New System.Drawing.Point(76, 45)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.ReadOnly = True
        Me.txtdb.Size = New System.Drawing.Size(167, 20)
        Me.txtdb.TabIndex = 44
        Me.txtdb.Text = "0"
        Me.txtdb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label8.Location = New System.Drawing.Point(251, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "CREDITO $"
        '
        'txtcr
        '
        Me.txtcr.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcr.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtcr.Location = New System.Drawing.Point(325, 45)
        Me.txtcr.Name = "txtcr"
        Me.txtcr.ReadOnly = True
        Me.txtcr.Size = New System.Drawing.Size(167, 21)
        Me.txtcr.TabIndex = 45
        Me.txtcr.Text = "0"
        Me.txtcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gitems
        '
        Me.gitems.AllowDrop = True
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gdes, Me.gDeb, Me.gCred, Me.gcta, Me.gBase, Me.gdvmto, Me.gfvmto, Me.gnit, Me.grubro, Me.gcheque, Me.trubro})
        Me.gitems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.gitems.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.gitems.Location = New System.Drawing.Point(7, 85)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gitems.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.gitems.RowHeadersVisible = False
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(940, 136)
        Me.gitems.TabIndex = 12
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(1051, 145)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(42, 21)
        Me.cbper.TabIndex = 149
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(1097, 145)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(36, 20)
        Me.txtperiodo.TabIndex = 147
        Me.txtperiodo.Text = "0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(1017, 145)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 146
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(965, 149)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Fecha"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtnomcta)
        Me.GroupBox1.Controls.Add(Me.txtsalB)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtcuenta)
        Me.GroupBox1.Controls.Add(Me.txtdifsal)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtsaldo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 75)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        '
        'txtnomcta
        '
        Me.txtnomcta.BackColor = System.Drawing.Color.White
        Me.txtnomcta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomcta.Enabled = False
        Me.txtnomcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcta.Location = New System.Drawing.Point(231, 14)
        Me.txtnomcta.MaxLength = 70
        Me.txtnomcta.Name = "txtnomcta"
        Me.txtnomcta.ShortcutsEnabled = False
        Me.txtnomcta.Size = New System.Drawing.Size(711, 21)
        Me.txtnomcta.TabIndex = 149
        '
        'txtsalB
        '
        Me.txtsalB.BackColor = System.Drawing.Color.White
        Me.txtsalB.Location = New System.Drawing.Point(370, 51)
        Me.txtsalB.Name = "txtsalB"
        Me.txtsalB.ReadOnly = True
        Me.txtsalB.Size = New System.Drawing.Size(128, 20)
        Me.txtsalB.TabIndex = 149
        Me.txtsalB.Text = "0,00"
        Me.txtsalB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Cuenta Contable"
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.Location = New System.Drawing.Point(116, 15)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(103, 21)
        Me.txtcuenta.TabIndex = 148
        '
        'txtdifsal
        '
        Me.txtdifsal.ForeColor = System.Drawing.Color.Maroon
        Me.txtdifsal.Location = New System.Drawing.Point(601, 50)
        Me.txtdifsal.Name = "txtdifsal"
        Me.txtdifsal.ReadOnly = True
        Me.txtdifsal.Size = New System.Drawing.Size(124, 20)
        Me.txtdifsal.TabIndex = 153
        Me.txtdifsal.Text = "0,00"
        Me.txtdifsal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(260, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 15)
        Me.Label15.TabIndex = 148
        Me.Label15.Text = "Saldo en Banco"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Saldo Ajustado"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(522, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 15)
        Me.Label13.TabIndex = 152
        Me.Label13.Text = "Diferencia"
        '
        'txtsaldo
        '
        Me.txtsaldo.BackColor = System.Drawing.Color.White
        Me.txtsaldo.Location = New System.Drawing.Point(118, 48)
        Me.txtsaldo.Name = "txtsaldo"
        Me.txtsaldo.ReadOnly = True
        Me.txtsaldo.Size = New System.Drawing.Size(134, 20)
        Me.txtsaldo.TabIndex = 151
        Me.txtsaldo.Text = "0,00"
        Me.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsalcon
        '
        Me.txtsalcon.Location = New System.Drawing.Point(968, 38)
        Me.txtsalcon.Name = "txtsalcon"
        Me.txtsalcon.Size = New System.Drawing.Size(142, 20)
        Me.txtsalcon.TabIndex = 159
        Me.txtsalcon.Text = "0,00"
        Me.txtsalcon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtsalcon, "salaj anterior")
        '
        'txtsalB2
        '
        Me.txtsalB2.BackColor = System.Drawing.Color.White
        Me.txtsalB2.Location = New System.Drawing.Point(968, 75)
        Me.txtsalB2.Name = "txtsalB2"
        Me.txtsalB2.ReadOnly = True
        Me.txtsalB2.Size = New System.Drawing.Size(128, 20)
        Me.txtsalB2.TabIndex = 150
        Me.txtsalB2.Text = "0,00"
        Me.txtsalB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gdes
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gdes.DefaultCellStyle = DataGridViewCellStyle1
        Me.gdes.FillWeight = 180.0!
        Me.gdes.Frozen = True
        Me.gdes.HeaderText = "Descripcion"
        Me.gdes.MaxInputLength = 50
        Me.gdes.MinimumWidth = 160
        Me.gdes.Name = "gdes"
        Me.gdes.ReadOnly = True
        Me.gdes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gdes.Width = 160
        '
        'gDeb
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.gDeb.DefaultCellStyle = DataGridViewCellStyle2
        Me.gDeb.Frozen = True
        Me.gDeb.HeaderText = "Debitos"
        Me.gDeb.MaxInputLength = 30
        Me.gDeb.Name = "gDeb"
        Me.gDeb.ReadOnly = True
        Me.gDeb.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gDeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gCred
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.gCred.DefaultCellStyle = DataGridViewCellStyle3
        Me.gCred.Frozen = True
        Me.gCred.HeaderText = "Creditos"
        Me.gCred.MaxInputLength = 30
        Me.gCred.Name = "gCred"
        Me.gCred.ReadOnly = True
        Me.gCred.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gcta
        '
        Me.gcta.FillWeight = 80.0!
        Me.gcta.Frozen = True
        Me.gcta.HeaderText = "Cuenta"
        Me.gcta.MaxInputLength = 12
        Me.gcta.Name = "gcta"
        Me.gcta.ReadOnly = True
        Me.gcta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcta.Width = 80
        '
        'gBase
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.gBase.DefaultCellStyle = DataGridViewCellStyle4
        Me.gBase.FillWeight = 80.0!
        Me.gBase.Frozen = True
        Me.gBase.HeaderText = "Base"
        Me.gBase.MaxInputLength = 30
        Me.gBase.Name = "gBase"
        Me.gBase.ReadOnly = True
        Me.gBase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gBase.Width = 80
        '
        'gdvmto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.gdvmto.DefaultCellStyle = DataGridViewCellStyle5
        Me.gdvmto.Frozen = True
        Me.gdvmto.HeaderText = "Dias Vmto"
        Me.gdvmto.MaxInputLength = 4
        Me.gdvmto.MinimumWidth = 65
        Me.gdvmto.Name = "gdvmto"
        Me.gdvmto.ReadOnly = True
        Me.gdvmto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gdvmto.Width = 65
        '
        'gfvmto
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = "00/00/0000"
        Me.gfvmto.DefaultCellStyle = DataGridViewCellStyle6
        Me.gfvmto.HeaderText = "Fecha Vmto"
        Me.gfvmto.MaxInputLength = 10
        Me.gfvmto.MinimumWidth = 75
        Me.gfvmto.Name = "gfvmto"
        Me.gfvmto.ReadOnly = True
        Me.gfvmto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gfvmto.Width = 75
        '
        'gnit
        '
        Me.gnit.HeaderText = "Nit"
        Me.gnit.MaxInputLength = 20
        Me.gnit.MinimumWidth = 95
        Me.gnit.Name = "gnit"
        Me.gnit.ReadOnly = True
        Me.gnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gnit.Width = 95
        '
        'grubro
        '
        Me.grubro.HeaderText = "Rubro"
        Me.grubro.MinimumWidth = 150
        Me.grubro.Name = "grubro"
        Me.grubro.ReadOnly = True
        Me.grubro.Width = 150
        '
        'gcheque
        '
        Me.gcheque.HeaderText = "Cheque"
        Me.gcheque.MinimumWidth = 80
        Me.gcheque.Name = "gcheque"
        Me.gcheque.ReadOnly = True
        Me.gcheque.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gcheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcheque.Width = 80
        '
        'trubro
        '
        Me.trubro.HeaderText = "trbro"
        Me.trubro.Name = "trubro"
        Me.trubro.ReadOnly = True
        '
        'FrmDocConciliaB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(965, 322)
        Me.Controls.Add(Me.cbper)
        Me.Controls.Add(Me.txtsalcon)
        Me.Controls.Add(Me.txtperiodo)
        Me.Controls.Add(Me.txtsalB2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtdia)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Gmov)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDocConciliaB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documento para Conciliacion Bancaria"
        Me.Gmov.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gmov As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtdif As System.Windows.Forms.TextBox
    Friend WithEvents TxtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdifsal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtsaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtsalB As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtnomcta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtsalcon As System.Windows.Forms.TextBox
    Friend WithEvents txtsalB2 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gdes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gDeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gCred As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gBase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdvmto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gfvmto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grubro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trubro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
