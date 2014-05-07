<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCIordenes
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCIordenes))
        Me.g2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.grilla1 = New System.Windows.Forms.DataGridView
        Me.cta1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.deta1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.db1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cd1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtnumIP = New System.Windows.Forms.TextBox
        Me.txtNip = New System.Windows.Forms.TextBox
        Me.txtDip = New System.Windows.Forms.TextBox
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtvalor = New System.Windows.Forms.TextBox
        Me.txtrb = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.g1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtnomt = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtconcepto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtrb1 = New System.Windows.Forms.TextBox
        Me.txtnomrb = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CmdCons = New System.Windows.Forms.Button
        Me.cmdprint = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.g3 = New System.Windows.Forms.GroupBox
        Me.txtnitb = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.cmdBanco = New System.Windows.Forms.Button
        Me.grilla2 = New System.Windows.Forms.DataGridView
        Me.cta2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.deta2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.db2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cd2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtnumRC = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNrc = New System.Windows.Forms.TextBox
        Me.txtDrc = New System.Windows.Forms.TextBox
        Me.txtctab = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcred = New System.Windows.Forms.TextBox
        Me.txtdeb = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.g0 = New System.Windows.Forms.GroupBox
        Me.i2 = New System.Windows.Forms.RadioButton
        Me.i1 = New System.Windows.Forms.RadioButton
        Me.g2.SuspendLayout()
        CType(Me.grilla1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.g3.SuspendLayout()
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.g0.SuspendLayout()
        Me.SuspendLayout()
        '
        'g2
        '
        Me.g2.Controls.Add(Me.Label8)
        Me.g2.Controls.Add(Me.grilla1)
        Me.g2.Controls.Add(Me.txtnumIP)
        Me.g2.Controls.Add(Me.txtNip)
        Me.g2.Controls.Add(Me.txtDip)
        Me.g2.Location = New System.Drawing.Point(8, 261)
        Me.g2.Name = "g2"
        Me.g2.Size = New System.Drawing.Size(645, 157)
        Me.g2.TabIndex = 3
        Me.g2.TabStop = False
        Me.g2.Text = "Ingreso a Presupuesto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 16)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Tipo de Documento"
        '
        'grilla1
        '
        Me.grilla1.AllowDrop = True
        Me.grilla1.AllowUserToResizeColumns = False
        Me.grilla1.AllowUserToResizeRows = False
        Me.grilla1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cta1, Me.deta1, Me.db1, Me.cd1})
        Me.grilla1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla1.Location = New System.Drawing.Point(11, 43)
        Me.grilla1.MultiSelect = False
        Me.grilla1.Name = "grilla1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grilla1.RowHeadersVisible = False
        Me.grilla1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla1.Size = New System.Drawing.Size(616, 108)
        Me.grilla1.TabIndex = 3
        '
        'cta1
        '
        Me.cta1.FillWeight = 80.0!
        Me.cta1.HeaderText = "Cuenta"
        Me.cta1.MaxInputLength = 12
        Me.cta1.MinimumWidth = 100
        Me.cta1.Name = "cta1"
        Me.cta1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'deta1
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deta1.DefaultCellStyle = DataGridViewCellStyle1
        Me.deta1.FillWeight = 180.0!
        Me.deta1.HeaderText = "Detalle Cuenta"
        Me.deta1.MaxInputLength = 50
        Me.deta1.MinimumWidth = 290
        Me.deta1.Name = "deta1"
        Me.deta1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.deta1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.deta1.Width = 290
        '
        'db1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.db1.DefaultCellStyle = DataGridViewCellStyle2
        Me.db1.HeaderText = "Debitos"
        Me.db1.MaxInputLength = 30
        Me.db1.MinimumWidth = 100
        Me.db1.Name = "db1"
        Me.db1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.db1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cd1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cd1.DefaultCellStyle = DataGridViewCellStyle3
        Me.cd1.HeaderText = "Creditos"
        Me.cd1.MaxInputLength = 30
        Me.cd1.MinimumWidth = 100
        Me.cd1.Name = "cd1"
        Me.cd1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtnumIP
        '
        Me.txtnumIP.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumIP.Enabled = False
        Me.txtnumIP.Location = New System.Drawing.Point(536, 17)
        Me.txtnumIP.Name = "txtnumIP"
        Me.txtnumIP.Size = New System.Drawing.Size(91, 20)
        Me.txtnumIP.TabIndex = 4
        '
        'txtNip
        '
        Me.txtNip.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNip.Enabled = False
        Me.txtNip.Location = New System.Drawing.Point(215, 17)
        Me.txtNip.Name = "txtNip"
        Me.txtNip.ReadOnly = True
        Me.txtNip.Size = New System.Drawing.Size(315, 20)
        Me.txtNip.TabIndex = 4
        '
        'txtDip
        '
        Me.txtDip.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDip.Enabled = False
        Me.txtDip.Location = New System.Drawing.Point(164, 17)
        Me.txtDip.MaxLength = 4
        Me.txtDip.Name = "txtDip"
        Me.txtDip.ReadOnly = True
        Me.txtDip.Size = New System.Drawing.Size(45, 20)
        Me.txtDip.TabIndex = 44
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(335, 128)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(42, 21)
        Me.cbper.TabIndex = 7
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(381, 128)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(36, 20)
        Me.txtperiodo.TabIndex = 7
        Me.txtperiodo.Text = "0000"
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(301, 128)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 6
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(253, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label3.Location = New System.Drawing.Point(9, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "MONTO $"
        '
        'txtvalor
        '
        Me.txtvalor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvalor.Enabled = False
        Me.txtvalor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalor.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtvalor.Location = New System.Drawing.Point(90, 127)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(128, 20)
        Me.txtvalor.TabIndex = 5
        Me.txtvalor.Text = "0"
        Me.txtvalor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.txtvalor, "Valor")
        '
        'txtrb
        '
        Me.txtrb.BackColor = System.Drawing.Color.White
        Me.txtrb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrb.Enabled = False
        Me.txtrb.Location = New System.Drawing.Point(89, 16)
        Me.txtrb.MaxLength = 30
        Me.txtrb.Name = "txtrb"
        Me.txtrb.Size = New System.Drawing.Size(120, 20)
        Me.txtrb.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtrb, "Codigo del Rubro")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Rubro"
        '
        'g1
        '
        Me.g1.Controls.Add(Me.Label9)
        Me.g1.Controls.Add(Me.txtnomt)
        Me.g1.Controls.Add(Me.txtnit)
        Me.g1.Controls.Add(Me.Label7)
        Me.g1.Controls.Add(Me.txtconcepto)
        Me.g1.Controls.Add(Me.Label4)
        Me.g1.Controls.Add(Me.cbper)
        Me.g1.Controls.Add(Me.txtrb1)
        Me.g1.Controls.Add(Me.txtnomrb)
        Me.g1.Controls.Add(Me.txtrb)
        Me.g1.Controls.Add(Me.Label1)
        Me.g1.Controls.Add(Me.txtvalor)
        Me.g1.Controls.Add(Me.txtperiodo)
        Me.g1.Controls.Add(Me.Label3)
        Me.g1.Controls.Add(Me.txtdia)
        Me.g1.Controls.Add(Me.Label12)
        Me.g1.Location = New System.Drawing.Point(10, 68)
        Me.g1.Name = "g1"
        Me.g1.Size = New System.Drawing.Size(645, 187)
        Me.g1.TabIndex = 2
        Me.g1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(9, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Rubro cod1"
        '
        'txtnomt
        '
        Me.txtnomt.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomt.Enabled = False
        Me.txtnomt.Location = New System.Drawing.Point(217, 155)
        Me.txtnomt.Name = "txtnomt"
        Me.txtnomt.ReadOnly = True
        Me.txtnomt.Size = New System.Drawing.Size(414, 20)
        Me.txtnomt.TabIndex = 8
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(89, 155)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(122, 20)
        Me.txtnit.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(9, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Tercero"
        '
        'txtconcepto
        '
        Me.txtconcepto.BackColor = System.Drawing.Color.White
        Me.txtconcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto.Enabled = False
        Me.txtconcepto.Location = New System.Drawing.Point(90, 75)
        Me.txtconcepto.MaxLength = 30
        Me.txtconcepto.Multiline = True
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(541, 44)
        Me.txtconcepto.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(9, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Concepto"
        '
        'txtrb1
        '
        Me.txtrb1.BackColor = System.Drawing.Color.White
        Me.txtrb1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrb1.Enabled = False
        Me.txtrb1.Location = New System.Drawing.Point(90, 46)
        Me.txtrb1.MaxLength = 30
        Me.txtrb1.Name = "txtrb1"
        Me.txtrb1.ReadOnly = True
        Me.txtrb1.Size = New System.Drawing.Size(122, 20)
        Me.txtrb1.TabIndex = 48
        Me.ToolTip1.SetToolTip(Me.txtrb1, "cod rubro")
        '
        'txtnomrb
        '
        Me.txtnomrb.BackColor = System.Drawing.Color.White
        Me.txtnomrb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomrb.Location = New System.Drawing.Point(217, 16)
        Me.txtnomrb.MaxLength = 30
        Me.txtnomrb.Multiline = True
        Me.txtnomrb.Name = "txtnomrb"
        Me.txtnomrb.ReadOnly = True
        Me.txtnomrb.Size = New System.Drawing.Size(412, 50)
        Me.txtnomrb.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CmdCons)
        Me.GroupBox5.Controls.Add(Me.cmdprint)
        Me.GroupBox5.Controls.Add(Me.cmdEdit)
        Me.GroupBox5.Controls.Add(Me.CmdSalir)
        Me.GroupBox5.Controls.Add(Me.CmdEliminar)
        Me.GroupBox5.Controls.Add(Me.CmdListo)
        Me.GroupBox5.Controls.Add(Me.CmdCancelar)
        Me.GroupBox5.Controls.Add(Me.CmdNuevo)
        Me.GroupBox5.Location = New System.Drawing.Point(10, 621)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(643, 57)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'CmdCons
        '
        Me.CmdCons.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdCons.Location = New System.Drawing.Point(396, 11)
        Me.CmdCons.Name = "CmdCons"
        Me.CmdCons.Size = New System.Drawing.Size(52, 38)
        Me.CmdCons.TabIndex = 59
        Me.CmdCons.UseVisualStyleBackColor = True
        '
        'cmdprint
        '
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(342, 11)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 57
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(236, 11)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 40)
        Me.cmdEdit.TabIndex = 55
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(449, 11)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 60
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(289, 11)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 39)
        Me.CmdEliminar.TabIndex = 56
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(133, 11)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(51, 38)
        Me.CmdListo.TabIndex = 52
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(187, 11)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(49, 39)
        Me.CmdCancelar.TabIndex = 53
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(82, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(48, 38)
        Me.CmdNuevo.TabIndex = 51
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'g3
        '
        Me.g3.Controls.Add(Me.txtnitb)
        Me.g3.Controls.Add(Me.Label5)
        Me.g3.Controls.Add(Me.txtbanco)
        Me.g3.Controls.Add(Me.cmdBanco)
        Me.g3.Controls.Add(Me.grilla2)
        Me.g3.Controls.Add(Me.txtnumRC)
        Me.g3.Controls.Add(Me.Label2)
        Me.g3.Controls.Add(Me.txtNrc)
        Me.g3.Controls.Add(Me.txtDrc)
        Me.g3.Location = New System.Drawing.Point(8, 423)
        Me.g3.Name = "g3"
        Me.g3.Size = New System.Drawing.Size(645, 201)
        Me.g3.TabIndex = 4
        Me.g3.TabStop = False
        Me.g3.Text = "Recibo de caja"
        '
        'txtnitb
        '
        Me.txtnitb.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnitb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnitb.Enabled = False
        Me.txtnitb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnitb.Location = New System.Drawing.Point(195, 49)
        Me.txtnitb.MaxLength = 15
        Me.txtnitb.Name = "txtnitb"
        Me.txtnitb.ShortcutsEnabled = False
        Me.txtnitb.Size = New System.Drawing.Size(118, 21)
        Me.txtnitb.TabIndex = 142
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(156, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 15)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "No cta"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.Color.White
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Enabled = False
        Me.txtbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco.Location = New System.Drawing.Point(319, 48)
        Me.txtbanco.MaxLength = 180
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(308, 21)
        Me.txtbanco.TabIndex = 143
        '
        'cmdBanco
        '
        Me.cmdBanco.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBanco.ForeColor = System.Drawing.Color.Black
        Me.cmdBanco.Location = New System.Drawing.Point(9, 43)
        Me.cmdBanco.Name = "cmdBanco"
        Me.cmdBanco.Size = New System.Drawing.Size(141, 28)
        Me.cmdBanco.TabIndex = 4
        Me.cmdBanco.Text = "&Seleccionar Banco"
        Me.cmdBanco.UseVisualStyleBackColor = False
        '
        'grilla2
        '
        Me.grilla2.AllowDrop = True
        Me.grilla2.AllowUserToResizeColumns = False
        Me.grilla2.AllowUserToResizeRows = False
        Me.grilla2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cta2, Me.deta2, Me.db2, Me.cd2})
        Me.grilla2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla2.Location = New System.Drawing.Point(11, 79)
        Me.grilla2.MultiSelect = False
        Me.grilla2.Name = "grilla2"
        Me.grilla2.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla2.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grilla2.RowHeadersVisible = False
        Me.grilla2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla2.Size = New System.Drawing.Size(616, 114)
        Me.grilla2.TabIndex = 5
        '
        'cta2
        '
        Me.cta2.FillWeight = 80.0!
        Me.cta2.HeaderText = "Cuenta"
        Me.cta2.MaxInputLength = 12
        Me.cta2.MinimumWidth = 100
        Me.cta2.Name = "cta2"
        Me.cta2.ReadOnly = True
        Me.cta2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'deta2
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deta2.DefaultCellStyle = DataGridViewCellStyle5
        Me.deta2.FillWeight = 180.0!
        Me.deta2.HeaderText = "Detalle Cuenta"
        Me.deta2.MaxInputLength = 50
        Me.deta2.MinimumWidth = 290
        Me.deta2.Name = "deta2"
        Me.deta2.ReadOnly = True
        Me.deta2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.deta2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.deta2.Width = 290
        '
        'db2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.db2.DefaultCellStyle = DataGridViewCellStyle6
        Me.db2.HeaderText = "Debitos"
        Me.db2.MaxInputLength = 30
        Me.db2.MinimumWidth = 100
        Me.db2.Name = "db2"
        Me.db2.ReadOnly = True
        Me.db2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.db2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cd2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cd2.DefaultCellStyle = DataGridViewCellStyle7
        Me.cd2.HeaderText = "Creditos"
        Me.cd2.MaxInputLength = 30
        Me.cd2.MinimumWidth = 100
        Me.cd2.Name = "cd2"
        Me.cd2.ReadOnly = True
        Me.cd2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtnumRC
        '
        Me.txtnumRC.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumRC.Enabled = False
        Me.txtnumRC.Location = New System.Drawing.Point(539, 17)
        Me.txtnumRC.Name = "txtnumRC"
        Me.txtnumRC.Size = New System.Drawing.Size(91, 20)
        Me.txtnumRC.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Tipo de Documento"
        '
        'txtNrc
        '
        Me.txtNrc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNrc.Enabled = False
        Me.txtNrc.Location = New System.Drawing.Point(218, 17)
        Me.txtNrc.Name = "txtNrc"
        Me.txtNrc.ReadOnly = True
        Me.txtNrc.Size = New System.Drawing.Size(315, 20)
        Me.txtNrc.TabIndex = 45
        '
        'txtDrc
        '
        Me.txtDrc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDrc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDrc.Enabled = False
        Me.txtDrc.Location = New System.Drawing.Point(167, 17)
        Me.txtDrc.MaxLength = 4
        Me.txtDrc.Name = "txtDrc"
        Me.txtDrc.ReadOnly = True
        Me.txtDrc.Size = New System.Drawing.Size(45, 20)
        Me.txtDrc.TabIndex = 44
        '
        'txtctab
        '
        Me.txtctab.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtctab.Enabled = False
        Me.txtctab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtctab.Location = New System.Drawing.Point(674, 373)
        Me.txtctab.MaxLength = 15
        Me.txtctab.Name = "txtctab"
        Me.txtctab.ShortcutsEnabled = False
        Me.txtctab.Size = New System.Drawing.Size(118, 21)
        Me.txtctab.TabIndex = 145
        Me.ToolTip1.SetToolTip(Me.txtctab, "ctabanco")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "OTROS INGRESOS "
        '
        'txtcred
        '
        Me.txtcred.BackColor = System.Drawing.Color.White
        Me.txtcred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcred.Enabled = False
        Me.txtcred.Location = New System.Drawing.Point(670, 133)
        Me.txtcred.MaxLength = 30
        Me.txtcred.Name = "txtcred"
        Me.txtcred.Size = New System.Drawing.Size(122, 20)
        Me.txtcred.TabIndex = 49
        Me.ToolTip1.SetToolTip(Me.txtcred, "credito")
        '
        'txtdeb
        '
        Me.txtdeb.BackColor = System.Drawing.Color.White
        Me.txtdeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdeb.Enabled = False
        Me.txtdeb.Location = New System.Drawing.Point(670, 159)
        Me.txtdeb.MaxLength = 30
        Me.txtdeb.Name = "txtdeb"
        Me.txtdeb.Size = New System.Drawing.Size(122, 20)
        Me.txtdeb.TabIndex = 50
        Me.ToolTip1.SetToolTip(Me.txtdeb, "debito")
        '
        'txtnum
        '
        Me.txtnum.BackColor = System.Drawing.Color.White
        Me.txtnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnum.Enabled = False
        Me.txtnum.Location = New System.Drawing.Point(670, 70)
        Me.txtnum.MaxLength = 30
        Me.txtnum.Name = "txtnum"
        Me.txtnum.Size = New System.Drawing.Size(122, 20)
        Me.txtnum.TabIndex = 147
        Me.ToolTip1.SetToolTip(Me.txtnum, "Codigo del Rubro")
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(13, 8)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 146
        Me.lbestado.Text = "NULO"
        '
        'g0
        '
        Me.g0.Controls.Add(Me.i2)
        Me.g0.Controls.Add(Me.i1)
        Me.g0.Location = New System.Drawing.Point(12, 33)
        Me.g0.Name = "g0"
        Me.g0.Size = New System.Drawing.Size(643, 34)
        Me.g0.TabIndex = 1
        Me.g0.TabStop = False
        Me.g0.Text = "Tipo de Ingreso"
        '
        'i2
        '
        Me.i2.AutoSize = True
        Me.i2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.i2.Location = New System.Drawing.Point(351, 11)
        Me.i2.Name = "i2"
        Me.i2.Size = New System.Drawing.Size(110, 17)
        Me.i2.TabIndex = 1
        Me.i2.Text = "Ingreso Normal"
        Me.i2.UseVisualStyleBackColor = True
        '
        'i1
        '
        Me.i1.AutoSize = True
        Me.i1.Checked = True
        Me.i1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.i1.Location = New System.Drawing.Point(100, 12)
        Me.i1.Name = "i1"
        Me.i1.Size = New System.Drawing.Size(155, 17)
        Me.i1.TabIndex = 0
        Me.i1.TabStop = True
        Me.i1.Text = "Ingreso con Causacion"
        Me.i1.UseVisualStyleBackColor = True
        '
        'FrmCIordenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(662, 680)
        Me.Controls.Add(Me.g0)
        Me.Controls.Add(Me.txtnum)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.txtctab)
        Me.Controls.Add(Me.txtdeb)
        Me.Controls.Add(Me.txtcred)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.g3)
        Me.Controls.Add(Me.g1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.g2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCIordenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingresos a Presupuesto"
        Me.g2.ResumeLayout(False)
        Me.g2.PerformLayout()
        CType(Me.grilla1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g1.ResumeLayout(False)
        Me.g1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.g3.ResumeLayout(False)
        Me.g3.PerformLayout()
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.g0.ResumeLayout(False)
        Me.g0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents g2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtnumIP As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNip As System.Windows.Forms.TextBox
    Friend WithEvents txtDip As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents txtrb As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents g1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnomrb As System.Windows.Forms.TextBox
    Friend WithEvents g3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnumRC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNrc As System.Windows.Forms.TextBox
    Friend WithEvents txtDrc As System.Windows.Forms.TextBox
    Friend WithEvents grilla2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents txtconcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdBanco As System.Windows.Forms.Button
    Friend WithEvents txtnitb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdCons As System.Windows.Forms.Button
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents txtctab As System.Windows.Forms.TextBox
    Friend WithEvents txtnomt As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtrb1 As System.Windows.Forms.TextBox
    Friend WithEvents txtcred As System.Windows.Forms.TextBox
    Friend WithEvents txtdeb As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents grilla1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cta1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deta1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents db1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cd1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cta2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deta2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents db2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cd2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents g0 As System.Windows.Forms.GroupBox
    Friend WithEvents i2 As System.Windows.Forms.RadioButton
    Friend WithEvents i1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
