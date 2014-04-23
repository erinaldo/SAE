<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformeCC
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcheque = New System.Windows.Forms.TextBox
        Me.ch2 = New System.Windows.Forms.RadioButton
        Me.ch1 = New System.Windows.Forms.RadioButton
        Me.gcc = New System.Windows.Forms.GroupBox
        Me.txtNomcc = New System.Windows.Forms.TextBox
        Me.txtcc = New System.Windows.Forms.TextBox
        Me.cc2 = New System.Windows.Forms.RadioButton
        Me.cc1 = New System.Windows.Forms.RadioButton
        Me.gb = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.o2 = New System.Windows.Forms.RadioButton
        Me.o1 = New System.Windows.Forms.RadioButton
        Me.gper = New System.Windows.Forms.GroupBox
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.lbper = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtpfin = New System.Windows.Forms.TextBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.p3 = New System.Windows.Forms.RadioButton
        Me.p2 = New System.Windows.Forms.RadioButton
        Me.p1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.gcuenta = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcfin = New System.Windows.Forms.TextBox
        Me.txtcini = New System.Windows.Forms.TextBox
        Me.c3 = New System.Windows.Forms.RadioButton
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.gdoc = New System.Windows.Forms.GroupBox
        Me.mibarra = New System.Windows.Forms.ProgressBar
        Me.txtdoc2 = New System.Windows.Forms.TextBox
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.d2 = New System.Windows.Forms.RadioButton
        Me.d1 = New System.Windows.Forms.RadioButton
        Me.gnit = New System.Windows.Forms.GroupBox
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.n2 = New System.Windows.Forms.RadioButton
        Me.n1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdactualizar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdperiodo = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gcc.SuspendLayout()
        Me.gb.SuspendLayout()
        Me.gper.SuspendLayout()
        Me.gcuenta.SuspendLayout()
        Me.gdoc.SuspendLayout()
        Me.gnit.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.gcc)
        Me.GroupBox4.Controls.Add(Me.gb)
        Me.GroupBox4.Controls.Add(Me.gper)
        Me.GroupBox4.Controls.Add(Me.gcuenta)
        Me.GroupBox4.Controls.Add(Me.gdoc)
        Me.GroupBox4.Controls.Add(Me.gnit)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(494, 472)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcheque)
        Me.GroupBox1.Controls.Add(Me.ch2)
        Me.GroupBox1.Controls.Add(Me.ch1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 366)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 55)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'txtcheque
        '
        Me.txtcheque.Enabled = False
        Me.txtcheque.Location = New System.Drawing.Point(144, 30)
        Me.txtcheque.Name = "txtcheque"
        Me.txtcheque.Size = New System.Drawing.Size(99, 20)
        Me.txtcheque.TabIndex = 51
        '
        'ch2
        '
        Me.ch2.AutoSize = True
        Me.ch2.Location = New System.Drawing.Point(25, 31)
        Me.ch2.Name = "ch2"
        Me.ch2.Size = New System.Drawing.Size(79, 17)
        Me.ch2.TabIndex = 2
        Me.ch2.Text = "Un Cheque"
        Me.ch2.UseVisualStyleBackColor = True
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.Checked = True
        Me.ch1.Location = New System.Drawing.Point(25, 11)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(120, 17)
        Me.ch1.TabIndex = 0
        Me.ch1.TabStop = True
        Me.ch1.Text = "Todos Los Cheques"
        Me.ch1.UseVisualStyleBackColor = True
        '
        'gcc
        '
        Me.gcc.Controls.Add(Me.txtNomcc)
        Me.gcc.Controls.Add(Me.txtcc)
        Me.gcc.Controls.Add(Me.cc2)
        Me.gcc.Controls.Add(Me.cc1)
        Me.gcc.Location = New System.Drawing.Point(6, 310)
        Me.gcc.Name = "gcc"
        Me.gcc.Size = New System.Drawing.Size(477, 55)
        Me.gcc.TabIndex = 74
        Me.gcc.TabStop = False
        '
        'txtNomcc
        '
        Me.txtNomcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomcc.Enabled = False
        Me.txtNomcc.Location = New System.Drawing.Point(249, 30)
        Me.txtNomcc.Name = "txtNomcc"
        Me.txtNomcc.ReadOnly = True
        Me.txtNomcc.Size = New System.Drawing.Size(222, 20)
        Me.txtNomcc.TabIndex = 52
        '
        'txtcc
        '
        Me.txtcc.Enabled = False
        Me.txtcc.Location = New System.Drawing.Point(144, 30)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(99, 20)
        Me.txtcc.TabIndex = 51
        '
        'cc2
        '
        Me.cc2.AutoSize = True
        Me.cc2.Location = New System.Drawing.Point(25, 31)
        Me.cc2.Name = "cc2"
        Me.cc2.Size = New System.Drawing.Size(120, 17)
        Me.cc2.TabIndex = 2
        Me.cc2.Text = "Por Centro de Costo"
        Me.cc2.UseVisualStyleBackColor = True
        '
        'cc1
        '
        Me.cc1.AutoSize = True
        Me.cc1.Checked = True
        Me.cc1.Location = New System.Drawing.Point(25, 11)
        Me.cc1.Name = "cc1"
        Me.cc1.Size = New System.Drawing.Size(164, 17)
        Me.cc1.TabIndex = 0
        Me.cc1.TabStop = True
        Me.cc1.Text = "Todos Los Centros de Costos"
        Me.cc1.UseVisualStyleBackColor = True
        '
        'gb
        '
        Me.gb.Controls.Add(Me.RadioButton1)
        Me.gb.Controls.Add(Me.o2)
        Me.gb.Controls.Add(Me.o1)
        Me.gb.Location = New System.Drawing.Point(5, 435)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(478, 31)
        Me.gb.TabIndex = 73
        Me.gb.TabStop = False
        Me.gb.Text = "Agrupar por "
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(271, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.Text = "Fecha"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'o2
        '
        Me.o2.AutoSize = True
        Me.o2.Location = New System.Drawing.Point(194, 8)
        Me.o2.Name = "o2"
        Me.o2.Size = New System.Drawing.Size(62, 17)
        Me.o2.TabIndex = 3
        Me.o2.Text = "Tercero"
        Me.o2.UseVisualStyleBackColor = True
        '
        'o1
        '
        Me.o1.AutoSize = True
        Me.o1.Checked = True
        Me.o1.Location = New System.Drawing.Point(116, 8)
        Me.o1.Name = "o1"
        Me.o1.Size = New System.Drawing.Size(59, 17)
        Me.o1.TabIndex = 2
        Me.o1.TabStop = True
        Me.o1.Text = "Cuenta"
        Me.o1.UseVisualStyleBackColor = True
        '
        'gper
        '
        Me.gper.Controls.Add(Me.cbfin)
        Me.gper.Controls.Add(Me.cbini)
        Me.gper.Controls.Add(Me.lbper)
        Me.gper.Controls.Add(Me.Label2)
        Me.gper.Controls.Add(Me.txtpfin)
        Me.gper.Controls.Add(Me.txtpini)
        Me.gper.Controls.Add(Me.txtperiodo)
        Me.gper.Controls.Add(Me.txtdia)
        Me.gper.Controls.Add(Me.Label3)
        Me.gper.Controls.Add(Me.p3)
        Me.gper.Controls.Add(Me.p2)
        Me.gper.Controls.Add(Me.p1)
        Me.gper.Controls.Add(Me.Label1)
        Me.gper.Location = New System.Drawing.Point(7, 9)
        Me.gper.Name = "gper"
        Me.gper.Size = New System.Drawing.Size(477, 94)
        Me.gper.TabIndex = 39
        Me.gper.TabStop = False
        '
        'cbfin
        '
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Location = New System.Drawing.Point(360, 40)
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 52
        '
        'cbini
        '
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(216, 41)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 51
        '
        'lbper
        '
        Me.lbper.AutoSize = True
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.Location = New System.Drawing.Point(165, 20)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(59, 15)
        Me.lbper.TabIndex = 50
        Me.lbper.Text = "00/0000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(315, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Final"
        '
        'txtpfin
        '
        Me.txtpfin.BackColor = System.Drawing.SystemColors.Control
        Me.txtpfin.Enabled = False
        Me.txtpfin.Location = New System.Drawing.Point(403, 41)
        Me.txtpfin.Name = "txtpfin"
        Me.txtpfin.Size = New System.Drawing.Size(42, 20)
        Me.txtpfin.TabIndex = 48
        Me.txtpfin.Text = "/0000"
        '
        'txtpini
        '
        Me.txtpini.BackColor = System.Drawing.SystemColors.Control
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(261, 41)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 46
        Me.txtpini.Text = "/0000"
        '
        'txtperiodo
        '
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(334, 65)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 45
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(307, 65)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 44
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(163, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 15)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Fecha (dd/mm/aaaa)"
        '
        'p3
        '
        Me.p3.AutoSize = True
        Me.p3.Location = New System.Drawing.Point(25, 66)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(78, 17)
        Me.p3.TabIndex = 2
        Me.p3.Text = "Libro Diario"
        Me.p3.UseVisualStyleBackColor = True
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Checked = True
        Me.p2.Location = New System.Drawing.Point(25, 43)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(118, 17)
        Me.p2.TabIndex = 1
        Me.p2.TabStop = True
        Me.p2.Text = "Rango De Periodos"
        Me.p2.UseVisualStyleBackColor = True
        '
        'p1
        '
        Me.p1.AutoSize = True
        Me.p1.Location = New System.Drawing.Point(25, 20)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(94, 17)
        Me.p1.TabIndex = 0
        Me.p1.Text = "Periodo Actual"
        Me.p1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(164, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Inicial"
        '
        'gcuenta
        '
        Me.gcuenta.Controls.Add(Me.Label7)
        Me.gcuenta.Controls.Add(Me.txtcuenta)
        Me.gcuenta.Controls.Add(Me.Label4)
        Me.gcuenta.Controls.Add(Me.txtcfin)
        Me.gcuenta.Controls.Add(Me.txtcini)
        Me.gcuenta.Controls.Add(Me.c3)
        Me.gcuenta.Controls.Add(Me.c2)
        Me.gcuenta.Controls.Add(Me.c1)
        Me.gcuenta.Controls.Add(Me.Label6)
        Me.gcuenta.Location = New System.Drawing.Point(7, 100)
        Me.gcuenta.Name = "gcuenta"
        Me.gcuenta.Size = New System.Drawing.Size(477, 93)
        Me.gcuenta.TabIndex = 39
        Me.gcuenta.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.IndianRed
        Me.Label7.Location = New System.Drawing.Point(287, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "* Doble clic para escoger cuentas"
        '
        'txtcuenta
        '
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Location = New System.Drawing.Point(167, 66)
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(100, 20)
        Me.txtcuenta.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(313, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Final"
        '
        'txtcfin
        '
        Me.txtcfin.Enabled = False
        Me.txtcfin.Location = New System.Drawing.Point(354, 42)
        Me.txtcfin.Name = "txtcfin"
        Me.txtcfin.Size = New System.Drawing.Size(100, 20)
        Me.txtcfin.TabIndex = 48
        '
        'txtcini
        '
        Me.txtcini.Enabled = False
        Me.txtcini.Location = New System.Drawing.Point(211, 43)
        Me.txtcini.Name = "txtcini"
        Me.txtcini.Size = New System.Drawing.Size(100, 20)
        Me.txtcini.TabIndex = 46
        '
        'c3
        '
        Me.c3.AutoSize = True
        Me.c3.Location = New System.Drawing.Point(25, 66)
        Me.c3.Name = "c3"
        Me.c3.Size = New System.Drawing.Size(78, 17)
        Me.c3.TabIndex = 2
        Me.c3.Text = "Por Cuenta"
        Me.c3.UseVisualStyleBackColor = True
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(25, 43)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(116, 17)
        Me.c2.TabIndex = 1
        Me.c2.Text = "Rango De Cuentas"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(25, 20)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(117, 17)
        Me.c1.TabIndex = 0
        Me.c1.TabStop = True
        Me.c1.Text = "Todas Las Cuentas"
        Me.c1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(164, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Inicial"
        '
        'gdoc
        '
        Me.gdoc.Controls.Add(Me.mibarra)
        Me.gdoc.Controls.Add(Me.txtdoc2)
        Me.gdoc.Controls.Add(Me.txtdoc)
        Me.gdoc.Controls.Add(Me.d2)
        Me.gdoc.Controls.Add(Me.d1)
        Me.gdoc.Location = New System.Drawing.Point(7, 190)
        Me.gdoc.Name = "gdoc"
        Me.gdoc.Size = New System.Drawing.Size(477, 62)
        Me.gdoc.TabIndex = 39
        Me.gdoc.TabStop = False
        '
        'mibarra
        '
        Me.mibarra.Location = New System.Drawing.Point(120, 10)
        Me.mibarra.Name = "mibarra"
        Me.mibarra.Size = New System.Drawing.Size(229, 23)
        Me.mibarra.TabIndex = 73
        Me.mibarra.Visible = False
        '
        'txtdoc2
        '
        Me.txtdoc2.BackColor = System.Drawing.SystemColors.Control
        Me.txtdoc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc2.Enabled = False
        Me.txtdoc2.Location = New System.Drawing.Point(209, 34)
        Me.txtdoc2.Name = "txtdoc2"
        Me.txtdoc2.ReadOnly = True
        Me.txtdoc2.Size = New System.Drawing.Size(262, 20)
        Me.txtdoc2.TabIndex = 51
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Enabled = False
        Me.txtdoc.Location = New System.Drawing.Point(167, 35)
        Me.txtdoc.MaxLength = 4
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(36, 20)
        Me.txtdoc.TabIndex = 50
        '
        'd2
        '
        Me.d2.AutoSize = True
        Me.d2.Location = New System.Drawing.Point(25, 35)
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(99, 17)
        Me.d2.TabIndex = 2
        Me.d2.Text = "Por Documento"
        Me.d2.UseVisualStyleBackColor = True
        '
        'd1
        '
        Me.d1.AutoSize = True
        Me.d1.Checked = True
        Me.d1.Location = New System.Drawing.Point(25, 15)
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(138, 17)
        Me.d1.TabIndex = 0
        Me.d1.TabStop = True
        Me.d1.Text = "Todos Los Documentos"
        Me.d1.UseVisualStyleBackColor = True
        '
        'gnit
        '
        Me.gnit.Controls.Add(Me.txtnombre)
        Me.gnit.Controls.Add(Me.txtnit)
        Me.gnit.Controls.Add(Me.n2)
        Me.gnit.Controls.Add(Me.n1)
        Me.gnit.Location = New System.Drawing.Point(7, 248)
        Me.gnit.Name = "gnit"
        Me.gnit.Size = New System.Drawing.Size(477, 60)
        Me.gnit.TabIndex = 40
        Me.gnit.TabStop = False
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(216, 30)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(255, 20)
        Me.txtnombre.TabIndex = 52
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(108, 30)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(102, 20)
        Me.txtnit.TabIndex = 51
        '
        'n2
        '
        Me.n2.AutoSize = True
        Me.n2.Location = New System.Drawing.Point(25, 31)
        Me.n2.Name = "n2"
        Me.n2.Size = New System.Drawing.Size(77, 17)
        Me.n2.TabIndex = 2
        Me.n2.Text = "Por N. I. T."
        Me.n2.UseVisualStyleBackColor = True
        '
        'n1
        '
        Me.n1.AutoSize = True
        Me.n1.Checked = True
        Me.n1.Location = New System.Drawing.Point(25, 11)
        Me.n1.Name = "n1"
        Me.n1.Size = New System.Drawing.Size(111, 17)
        Me.n1.TabIndex = 0
        Me.n1.TabStop = True
        Me.n1.Text = "Todos Los N. I. T."
        Me.n1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.Button1)
        Me.GroupPanel1.Controls.Add(Me.cmdactualizar)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdperiodo)
        Me.GroupPanel1.Location = New System.Drawing.Point(2, 499)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(494, 85)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel1.TabIndex = 71
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 20)
        Me.TextBox1.TabIndex = 20
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.Button1.Location = New System.Drawing.Point(191, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 57)
        Me.Button1.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.Button1, "Otros Formatos")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdactualizar
        '
        Me.cmdactualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdactualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdactualizar.ForeColor = System.Drawing.SystemColors.Info
        Me.cmdactualizar.Image = Global.SAE.My.Resources.Resources.actualCC
        Me.cmdactualizar.Location = New System.Drawing.Point(254, 12)
        Me.cmdactualizar.Name = "cmdactualizar"
        Me.cmdactualizar.Size = New System.Drawing.Size(59, 57)
        Me.cmdactualizar.TabIndex = 18
        Me.cmdactualizar.Text = "&A"
        Me.cmdactualizar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdactualizar, "Actualizar  Catalogo De Cuentas Alt+A")
        Me.cmdactualizar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(314, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 16
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdperiodo
        '
        Me.cmdperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdperiodo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdperiodo.Image = Global.SAE.My.Resources.Resources.abriperiodo1
        Me.cmdperiodo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.cmdperiodo.Location = New System.Drawing.Point(133, 12)
        Me.cmdperiodo.Name = "cmdperiodo"
        Me.cmdperiodo.Size = New System.Drawing.Size(59, 57)
        Me.cmdperiodo.TabIndex = 13
        Me.cmdperiodo.Text = "&P"
        Me.cmdperiodo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdperiodo, "Abrir Periodo Alt + P")
        Me.cmdperiodo.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(144, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 15)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "MOVIMIENTOS DE CUENTAS"
        '
        'FrmInformeCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(502, 589)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInformeCC"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Informes  Libros Auxiliares"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gcc.ResumeLayout(False)
        Me.gcc.PerformLayout()
        Me.gb.ResumeLayout(False)
        Me.gb.PerformLayout()
        Me.gper.ResumeLayout(False)
        Me.gper.PerformLayout()
        Me.gcuenta.ResumeLayout(False)
        Me.gcuenta.PerformLayout()
        Me.gdoc.ResumeLayout(False)
        Me.gdoc.PerformLayout()
        Me.gnit.ResumeLayout(False)
        Me.gnit.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gper As System.Windows.Forms.GroupBox
    Friend WithEvents p3 As System.Windows.Forms.RadioButton
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtpfin As System.Windows.Forms.TextBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gcuenta As System.Windows.Forms.GroupBox
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcfin As System.Windows.Forms.TextBox
    Friend WithEvents txtcini As System.Windows.Forms.TextBox
    Friend WithEvents c3 As System.Windows.Forms.RadioButton
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdperiodo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents gdoc As System.Windows.Forms.GroupBox
    Friend WithEvents txtdoc2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents d2 As System.Windows.Forms.RadioButton
    Friend WithEvents d1 As System.Windows.Forms.RadioButton
    Friend WithEvents gnit As System.Windows.Forms.GroupBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents n2 As System.Windows.Forms.RadioButton
    Friend WithEvents n1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdactualizar As System.Windows.Forms.Button
    Friend WithEvents mibarra As System.Windows.Forms.ProgressBar
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents gb As System.Windows.Forms.GroupBox
    Friend WithEvents o2 As System.Windows.Forms.RadioButton
    Friend WithEvents o1 As System.Windows.Forms.RadioButton
    Friend WithEvents gcc As System.Windows.Forms.GroupBox
    Friend WithEvents txtNomcc As System.Windows.Forms.TextBox
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents cc2 As System.Windows.Forms.RadioButton
    Friend WithEvents cc1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcheque As System.Windows.Forms.TextBox
    Friend WithEvents ch2 As System.Windows.Forms.RadioButton
    Friend WithEvents ch1 As System.Windows.Forms.RadioButton
End Class
