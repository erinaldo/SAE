<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParaFactRapida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParaFactRapida))
        Me.Tabcont = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.grNF = New System.Windows.Forms.GroupBox
        Me.rdnf_s = New System.Windows.Forms.RadioButton
        Me.rdnf_n = New System.Windows.Forms.RadioButton
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtitems = New System.Windows.Forms.ComboBox
        Me.rb_itemS = New System.Windows.Forms.RadioButton
        Me.rb_itemN = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbBAp = New System.Windows.Forms.RadioButton
        Me.rbBNit = New System.Windows.Forms.RadioButton
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txtvendedor = New System.Windows.Forms.TextBox
        Me.chVend = New System.Windows.Forms.CheckBox
        Me.txtnitv = New System.Windows.Forms.TextBox
        Me.rbvendedor2 = New System.Windows.Forms.RadioButton
        Me.rbvendedor = New System.Windows.Forms.RadioButton
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.rbclie2 = New System.Windows.Forms.RadioButton
        Me.rbclie = New System.Windows.Forms.RadioButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.rbfec2 = New System.Windows.Forms.RadioButton
        Me.rbfec1 = New System.Windows.Forms.RadioButton
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rbinv2 = New System.Windows.Forms.RadioButton
        Me.rbinv = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rbnumf2 = New System.Windows.Forms.RadioButton
        Me.rbnumf = New System.Windows.Forms.RadioButton
        Me.grupoimprimir = New System.Windows.Forms.GroupBox
        Me.txttipo = New System.Windows.Forms.ComboBox
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.rbdoc2 = New System.Windows.Forms.RadioButton
        Me.rbdoc1 = New System.Windows.Forms.RadioButton
        Me.Tab1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.ChPA = New System.Windows.Forms.CheckBox
        Me.rbfacdifuniemp2 = New System.Windows.Forms.RadioButton
        Me.rbfacdifuniemp = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbcodinv2 = New System.Windows.Forms.RadioButton
        Me.rbcodinv = New System.Windows.Forms.RadioButton
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.txtmargen = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rbmarg2 = New System.Windows.Forms.RadioButton
        Me.rbmarg = New System.Windows.Forms.RadioButton
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.txtbodega = New System.Windows.Forms.TextBox
        Me.cbbod = New System.Windows.Forms.ComboBox
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEstoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.rbbodpre2 = New System.Windows.Forms.RadioButton
        Me.rbbodpre = New System.Windows.Forms.RadioButton
        Me.GroupBox22 = New System.Windows.Forms.GroupBox
        Me.gcfp = New System.Windows.Forms.GroupBox
        Me.rbcualfp4 = New System.Windows.Forms.RadioButton
        Me.rbcualfp2 = New System.Windows.Forms.RadioButton
        Me.rbcualfp3 = New System.Windows.Forms.RadioButton
        Me.rbcualfp1 = New System.Windows.Forms.RadioButton
        Me.rbfp2 = New System.Windows.Forms.RadioButton
        Me.rbfp = New System.Windows.Forms.RadioButton
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.Txtcc2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcc = New System.Windows.Forms.TextBox
        Me.rbcc2 = New System.Windows.Forms.RadioButton
        Me.rbcc = New System.Windows.Forms.RadioButton
        Me.GroupBox21 = New System.Windows.Forms.GroupBox
        Me.rbcentro2 = New System.Windows.Forms.RadioButton
        Me.rbcentro = New System.Windows.Forms.RadioButton
        Me.Tab2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rb_imp_decN = New System.Windows.Forms.RadioButton
        Me.rb_imp_decS = New System.Windows.Forms.RadioButton
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtcomentario = New System.Windows.Forms.TextBox
        Me.cbregimen = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.gped = New System.Windows.Forms.GroupBox
        Me.pdfped2 = New System.Windows.Forms.RadioButton
        Me.cmd_vp_ped = New System.Windows.Forms.Button
        Me.cmdlogoped = New System.Windows.Forms.Button
        Me.pdfped = New System.Windows.Forms.RadioButton
        Me.ticped = New System.Windows.Forms.RadioButton
        Me.imgfoto2 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbcaution = New System.Windows.Forms.Label
        Me.GroupBox23 = New System.Windows.Forms.GroupBox
        Me.pdffac2 = New System.Windows.Forms.RadioButton
        Me.cmd_vp_fact = New System.Windows.Forms.Button
        Me.cmdlogofac = New System.Windows.Forms.Button
        Me.pdffac = New System.Windows.Forms.RadioButton
        Me.ticfac = New System.Windows.Forms.RadioButton
        Me.imgfoto = New System.Windows.Forms.PictureBox
        Me.gcot = New System.Windows.Forms.GroupBox
        Me.pdfcot2 = New System.Windows.Forms.RadioButton
        Me.cmd_vp_cot = New System.Windows.Forms.Button
        Me.cmdlogocot = New System.Windows.Forms.Button
        Me.pdfcot = New System.Windows.Forms.RadioButton
        Me.ticcot = New System.Windows.Forms.RadioButton
        Me.imgfoto3 = New System.Windows.Forms.PictureBox
        Me.Tab3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdatras = New System.Windows.Forms.Button
        Me.cmdsgt = New System.Windows.Forms.Button
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbprint = New System.Windows.Forms.Label
        Me.lbpara = New System.Windows.Forms.Label
        Me.lbfact = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.OPF = New System.Windows.Forms.OpenFileDialog
        Me.OPF2 = New System.Windows.Forms.OpenFileDialog
        Me.OPF3 = New System.Windows.Forms.OpenFileDialog
        Me.imprimir = New System.Drawing.Printing.PrintDocument
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtcomentarioini = New System.Windows.Forms.TextBox
        CType(Me.Tabcont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabcont.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.grNF.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grupoimprimir.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.mimenu.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.gcfp.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.gped.SuspendLayout()
        CType(Me.imgfoto2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox23.SuspendLayout()
        CType(Me.imgfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcot.SuspendLayout()
        CType(Me.imgfoto3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tabcont
        '
        Me.Tabcont.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Tabcont.CanReorderTabs = True
        Me.Tabcont.Controls.Add(Me.TabControlPanel3)
        Me.Tabcont.Controls.Add(Me.TabControlPanel1)
        Me.Tabcont.Controls.Add(Me.TabControlPanel2)
        Me.Tabcont.ForeColor = System.Drawing.Color.Black
        Me.Tabcont.Location = New System.Drawing.Point(3, 4)
        Me.Tabcont.Name = "Tabcont"
        Me.Tabcont.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tabcont.SelectedTabIndex = 0
        Me.Tabcont.Size = New System.Drawing.Size(759, 389)
        Me.Tabcont.TabIndex = 1
        Me.Tabcont.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.Tabcont.Tabs.Add(Me.Tab1)
        Me.Tabcont.Tabs.Add(Me.Tab2)
        Me.Tabcont.Tabs.Add(Me.Tab3)
        Me.Tabcont.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.grNF)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox9)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox3)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox10)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox7)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox6)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox5)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox4)
        Me.TabControlPanel1.Controls.Add(Me.grupoimprimir)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(759, 363)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.Tab1
        '
        'grNF
        '
        Me.grNF.BackColor = System.Drawing.Color.Transparent
        Me.grNF.Controls.Add(Me.rdnf_s)
        Me.grNF.Controls.Add(Me.rdnf_n)
        Me.grNF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grNF.Location = New System.Drawing.Point(527, 309)
        Me.grNF.Name = "grNF"
        Me.grNF.Size = New System.Drawing.Size(226, 43)
        Me.grNF.TabIndex = 77
        Me.grNF.TabStop = False
        Me.grNF.Text = "Reservar No Factura al dar click en nuevo?"
        '
        'rdnf_s
        '
        Me.rdnf_s.AutoSize = True
        Me.rdnf_s.Location = New System.Drawing.Point(135, 20)
        Me.rdnf_s.Name = "rdnf_s"
        Me.rdnf_s.Size = New System.Drawing.Size(36, 17)
        Me.rdnf_s.TabIndex = 1
        Me.rdnf_s.Text = "Si"
        Me.rdnf_s.UseVisualStyleBackColor = True
        '
        'rdnf_n
        '
        Me.rdnf_n.AutoSize = True
        Me.rdnf_n.Checked = True
        Me.rdnf_n.Location = New System.Drawing.Point(77, 20)
        Me.rdnf_n.Name = "rdnf_n"
        Me.rdnf_n.Size = New System.Drawing.Size(43, 17)
        Me.rdnf_n.TabIndex = 0
        Me.rdnf_n.TabStop = True
        Me.rdnf_n.Text = "NO"
        Me.rdnf_n.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.txtitems)
        Me.GroupBox9.Controls.Add(Me.rb_itemS)
        Me.GroupBox9.Controls.Add(Me.rb_itemN)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(299, 306)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(226, 43)
        Me.GroupBox9.TabIndex = 55
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Item pre-determinado ?"
        '
        'txtitems
        '
        Me.txtitems.BackColor = System.Drawing.Color.White
        Me.txtitems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtitems.FormattingEnabled = True
        Me.txtitems.Items.AddRange(New Object() {"I", "S"})
        Me.txtitems.Location = New System.Drawing.Point(141, 18)
        Me.txtitems.Name = "txtitems"
        Me.txtitems.Size = New System.Drawing.Size(70, 21)
        Me.txtitems.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.txtitems, "tipo de documento")
        '
        'rb_itemS
        '
        Me.rb_itemS.AutoSize = True
        Me.rb_itemS.Location = New System.Drawing.Point(74, 20)
        Me.rb_itemS.Name = "rb_itemS"
        Me.rb_itemS.Size = New System.Drawing.Size(65, 17)
        Me.rb_itemS.TabIndex = 1
        Me.rb_itemS.Text = "Si Cuál"
        Me.rb_itemS.UseVisualStyleBackColor = True
        '
        'rb_itemN
        '
        Me.rb_itemN.AutoSize = True
        Me.rb_itemN.Checked = True
        Me.rb_itemN.Location = New System.Drawing.Point(16, 20)
        Me.rb_itemN.Name = "rb_itemN"
        Me.rb_itemN.Size = New System.Drawing.Size(43, 17)
        Me.rb_itemN.TabIndex = 0
        Me.rb_itemN.TabStop = True
        Me.rb_itemN.Text = "NO"
        Me.rb_itemN.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rbBAp)
        Me.GroupBox3.Controls.Add(Me.rbBNit)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(23, 306)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(268, 43)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Busqueda de Clientes"
        '
        'rbBAp
        '
        Me.rbBAp.AutoSize = True
        Me.rbBAp.Location = New System.Drawing.Point(128, 20)
        Me.rbBAp.Name = "rbBAp"
        Me.rbBAp.Size = New System.Drawing.Size(99, 17)
        Me.rbBAp.TabIndex = 1
        Me.rbBAp.Text = "Por Apellidos"
        Me.rbBAp.UseVisualStyleBackColor = True
        '
        'rbBNit
        '
        Me.rbBNit.AutoSize = True
        Me.rbBNit.Checked = True
        Me.rbBNit.Location = New System.Drawing.Point(16, 20)
        Me.rbBNit.Name = "rbBNit"
        Me.rbBNit.Size = New System.Drawing.Size(91, 17)
        Me.rbBNit.TabIndex = 0
        Me.rbBNit.TabStop = True
        Me.rbBNit.Text = "Por NIT/CC"
        Me.rbBNit.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.txtvendedor)
        Me.GroupBox10.Controls.Add(Me.chVend)
        Me.GroupBox10.Controls.Add(Me.txtnitv)
        Me.GroupBox10.Controls.Add(Me.rbvendedor2)
        Me.GroupBox10.Controls.Add(Me.rbvendedor)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(23, 230)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(672, 70)
        Me.GroupBox10.TabIndex = 53
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "¿Nit del vendedor pre-determinado?"
        '
        'txtvendedor
        '
        Me.txtvendedor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvendedor.Enabled = False
        Me.txtvendedor.Location = New System.Drawing.Point(270, 18)
        Me.txtvendedor.Name = "txtvendedor"
        Me.txtvendedor.ReadOnly = True
        Me.txtvendedor.Size = New System.Drawing.Size(370, 20)
        Me.txtvendedor.TabIndex = 20
        '
        'chVend
        '
        Me.chVend.AutoSize = True
        Me.chVend.Location = New System.Drawing.Point(16, 41)
        Me.chVend.Name = "chVend"
        Me.chVend.Size = New System.Drawing.Size(133, 17)
        Me.chVend.TabIndex = 12
        Me.chVend.Text = "Computador Actual"
        Me.chVend.UseVisualStyleBackColor = True
        '
        'txtnitv
        '
        Me.txtnitv.BackColor = System.Drawing.Color.White
        Me.txtnitv.Location = New System.Drawing.Point(140, 18)
        Me.txtnitv.Name = "txtnitv"
        Me.txtnitv.ShortcutsEnabled = False
        Me.txtnitv.Size = New System.Drawing.Size(119, 20)
        Me.txtnitv.TabIndex = 19
        '
        'rbvendedor2
        '
        Me.rbvendedor2.AutoSize = True
        Me.rbvendedor2.Checked = True
        Me.rbvendedor2.Location = New System.Drawing.Point(16, 18)
        Me.rbvendedor2.Name = "rbvendedor2"
        Me.rbvendedor2.Size = New System.Drawing.Size(43, 17)
        Me.rbvendedor2.TabIndex = 11
        Me.rbvendedor2.TabStop = True
        Me.rbvendedor2.Text = "NO"
        Me.rbvendedor2.UseVisualStyleBackColor = True
        '
        'rbvendedor
        '
        Me.rbvendedor.AutoSize = True
        Me.rbvendedor.Location = New System.Drawing.Point(65, 18)
        Me.rbvendedor.Name = "rbvendedor"
        Me.rbvendedor.Size = New System.Drawing.Size(37, 17)
        Me.rbvendedor.TabIndex = 10
        Me.rbvendedor.Text = "SI"
        Me.rbvendedor.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.txtcliente)
        Me.GroupBox7.Controls.Add(Me.txtnitc)
        Me.GroupBox7.Controls.Add(Me.rbclie2)
        Me.GroupBox7.Controls.Add(Me.rbclie)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(23, 164)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(668, 43)
        Me.GroupBox7.TabIndex = 50
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "¿Nit del cliente pre-determinado?"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(265, 18)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(375, 20)
        Me.txtcliente.TabIndex = 20
        '
        'txtnitc
        '
        Me.txtnitc.BackColor = System.Drawing.Color.White
        Me.txtnitc.Location = New System.Drawing.Point(140, 18)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.ShortcutsEnabled = False
        Me.txtnitc.Size = New System.Drawing.Size(119, 20)
        Me.txtnitc.TabIndex = 19
        '
        'rbclie2
        '
        Me.rbclie2.AutoSize = True
        Me.rbclie2.Checked = True
        Me.rbclie2.Location = New System.Drawing.Point(19, 17)
        Me.rbclie2.Name = "rbclie2"
        Me.rbclie2.Size = New System.Drawing.Size(43, 17)
        Me.rbclie2.TabIndex = 11
        Me.rbclie2.TabStop = True
        Me.rbclie2.Text = "NO"
        Me.rbclie2.UseVisualStyleBackColor = True
        '
        'rbclie
        '
        Me.rbclie.AutoSize = True
        Me.rbclie.Location = New System.Drawing.Point(68, 18)
        Me.rbclie.Name = "rbclie"
        Me.rbclie.Size = New System.Drawing.Size(66, 17)
        Me.rbclie.TabIndex = 10
        Me.rbclie.Text = "SI Cuál"
        Me.rbclie.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.rbfec2)
        Me.GroupBox6.Controls.Add(Me.rbfec1)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(441, 100)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(250, 42)
        Me.GroupBox6.TabIndex = 49
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fecha"
        '
        'rbfec2
        '
        Me.rbfec2.AutoSize = True
        Me.rbfec2.Location = New System.Drawing.Point(114, 20)
        Me.rbfec2.Name = "rbfec2"
        Me.rbfec2.Size = New System.Drawing.Size(66, 17)
        Me.rbfec2.TabIndex = 1
        Me.rbfec2.Text = "Manual"
        Me.rbfec2.UseVisualStyleBackColor = True
        '
        'rbfec1
        '
        Me.rbfec1.AutoSize = True
        Me.rbfec1.Checked = True
        Me.rbfec1.Location = New System.Drawing.Point(6, 20)
        Me.rbfec1.Name = "rbfec1"
        Me.rbfec1.Size = New System.Drawing.Size(88, 17)
        Me.rbfec1.TabIndex = 0
        Me.rbfec1.TabStop = True
        Me.rbfec1.Text = "Automatico"
        Me.rbfec1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.rbinv2)
        Me.GroupBox5.Controls.Add(Me.rbinv)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(258, 98)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(177, 43)
        Me.GroupBox5.TabIndex = 48
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Afecta Siempre Inventario"
        '
        'rbinv2
        '
        Me.rbinv2.AutoSize = True
        Me.rbinv2.Location = New System.Drawing.Point(82, 20)
        Me.rbinv2.Name = "rbinv2"
        Me.rbinv2.Size = New System.Drawing.Size(43, 17)
        Me.rbinv2.TabIndex = 1
        Me.rbinv2.Text = "NO"
        Me.rbinv2.UseVisualStyleBackColor = True
        '
        'rbinv
        '
        Me.rbinv.AutoSize = True
        Me.rbinv.Checked = True
        Me.rbinv.Location = New System.Drawing.Point(18, 20)
        Me.rbinv.Name = "rbinv"
        Me.rbinv.Size = New System.Drawing.Size(37, 17)
        Me.rbinv.TabIndex = 0
        Me.rbinv.TabStop = True
        Me.rbinv.Text = "SI"
        Me.rbinv.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.rbnumf2)
        Me.GroupBox4.Controls.Add(Me.rbnumf)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(23, 94)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(229, 43)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Número de factura"
        '
        'rbnumf2
        '
        Me.rbnumf2.AutoSize = True
        Me.rbnumf2.Location = New System.Drawing.Point(128, 20)
        Me.rbnumf2.Name = "rbnumf2"
        Me.rbnumf2.Size = New System.Drawing.Size(66, 17)
        Me.rbnumf2.TabIndex = 1
        Me.rbnumf2.Text = "Manual"
        Me.rbnumf2.UseVisualStyleBackColor = True
        '
        'rbnumf
        '
        Me.rbnumf.AutoSize = True
        Me.rbnumf.Checked = True
        Me.rbnumf.Location = New System.Drawing.Point(16, 20)
        Me.rbnumf.Name = "rbnumf"
        Me.rbnumf.Size = New System.Drawing.Size(88, 17)
        Me.rbnumf.TabIndex = 0
        Me.rbnumf.TabStop = True
        Me.rbnumf.Text = "Automatico"
        Me.rbnumf.UseVisualStyleBackColor = True
        '
        'grupoimprimir
        '
        Me.grupoimprimir.BackColor = System.Drawing.Color.Transparent
        Me.grupoimprimir.Controls.Add(Me.txttipo)
        Me.grupoimprimir.Controls.Add(Me.txttipo2)
        Me.grupoimprimir.Controls.Add(Me.rbdoc2)
        Me.grupoimprimir.Controls.Add(Me.rbdoc1)
        Me.grupoimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoimprimir.Location = New System.Drawing.Point(23, 33)
        Me.grupoimprimir.Name = "grupoimprimir"
        Me.grupoimprimir.Size = New System.Drawing.Size(672, 43)
        Me.grupoimprimir.TabIndex = 16
        Me.grupoimprimir.TabStop = False
        Me.grupoimprimir.Text = "¿Tipo de documento pre-determinado?"
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txttipo.FormattingEnabled = True
        Me.txttipo.Location = New System.Drawing.Point(180, 16)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(70, 21)
        Me.txttipo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.txttipo, "tipo de documento")
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(256, 17)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(387, 20)
        Me.txttipo2.TabIndex = 14
        '
        'rbdoc2
        '
        Me.rbdoc2.AutoSize = True
        Me.rbdoc2.Checked = True
        Me.rbdoc2.Location = New System.Drawing.Point(37, 17)
        Me.rbdoc2.Name = "rbdoc2"
        Me.rbdoc2.Size = New System.Drawing.Size(43, 17)
        Me.rbdoc2.TabIndex = 11
        Me.rbdoc2.TabStop = True
        Me.rbdoc2.Text = "NO"
        Me.rbdoc2.UseVisualStyleBackColor = True
        '
        'rbdoc1
        '
        Me.rbdoc1.AutoSize = True
        Me.rbdoc1.Location = New System.Drawing.Point(110, 18)
        Me.rbdoc1.Name = "rbdoc1"
        Me.rbdoc1.Size = New System.Drawing.Size(66, 17)
        Me.rbdoc1.TabIndex = 10
        Me.rbdoc1.Text = "SI Cuál"
        Me.rbdoc1.UseVisualStyleBackColor = True
        '
        'Tab1
        '
        Me.Tab1.AttachedControl = Me.TabControlPanel1
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Text = "Página 1/3"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.GroupBox18)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox1)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox15)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox13)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox22)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox20)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox21)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(759, 363)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.Tab2
        '
        'GroupBox18
        '
        Me.GroupBox18.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox18.Controls.Add(Me.ChPA)
        Me.GroupBox18.Controls.Add(Me.rbfacdifuniemp2)
        Me.GroupBox18.Controls.Add(Me.rbfacdifuniemp)
        Me.GroupBox18.Enabled = False
        Me.GroupBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(357, 35)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(332, 43)
        Me.GroupBox18.TabIndex = 61
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Facturar diferentes unidades de empaque"
        '
        'ChPA
        '
        Me.ChPA.AutoSize = True
        Me.ChPA.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChPA.Location = New System.Drawing.Point(120, 20)
        Me.ChPA.Name = "ChPA"
        Me.ChPA.Size = New System.Drawing.Size(204, 16)
        Me.ChPA.TabIndex = 12
        Me.ChPA.Text = "Precios automaticos por cantidades"
        Me.ChPA.UseVisualStyleBackColor = True
        '
        'rbfacdifuniemp2
        '
        Me.rbfacdifuniemp2.AutoSize = True
        Me.rbfacdifuniemp2.Checked = True
        Me.rbfacdifuniemp2.Location = New System.Drawing.Point(19, 18)
        Me.rbfacdifuniemp2.Name = "rbfacdifuniemp2"
        Me.rbfacdifuniemp2.Size = New System.Drawing.Size(43, 17)
        Me.rbfacdifuniemp2.TabIndex = 11
        Me.rbfacdifuniemp2.TabStop = True
        Me.rbfacdifuniemp2.Text = "NO"
        Me.rbfacdifuniemp2.UseVisualStyleBackColor = True
        '
        'rbfacdifuniemp
        '
        Me.rbfacdifuniemp.AutoSize = True
        Me.rbfacdifuniemp.Location = New System.Drawing.Point(75, 18)
        Me.rbfacdifuniemp.Name = "rbfacdifuniemp"
        Me.rbfacdifuniemp.Size = New System.Drawing.Size(37, 17)
        Me.rbfacdifuniemp.TabIndex = 10
        Me.rbfacdifuniemp.Text = "SI"
        Me.rbfacdifuniemp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbcodinv2)
        Me.GroupBox1.Controls.Add(Me.rbcodinv)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(23, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 43)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mostrar solo codigos de detalles del inventario"
        '
        'rbcodinv2
        '
        Me.rbcodinv2.AutoSize = True
        Me.rbcodinv2.Location = New System.Drawing.Point(78, 20)
        Me.rbcodinv2.Name = "rbcodinv2"
        Me.rbcodinv2.Size = New System.Drawing.Size(43, 17)
        Me.rbcodinv2.TabIndex = 11
        Me.rbcodinv2.Text = "NO"
        Me.rbcodinv2.UseVisualStyleBackColor = True
        '
        'rbcodinv
        '
        Me.rbcodinv.AutoSize = True
        Me.rbcodinv.Checked = True
        Me.rbcodinv.Location = New System.Drawing.Point(19, 20)
        Me.rbcodinv.Name = "rbcodinv"
        Me.rbcodinv.Size = New System.Drawing.Size(37, 17)
        Me.rbcodinv.TabIndex = 10
        Me.rbcodinv.TabStop = True
        Me.rbcodinv.Text = "SI"
        Me.rbcodinv.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox15.Controls.Add(Me.txtmargen)
        Me.GroupBox15.Controls.Add(Me.Label1)
        Me.GroupBox15.Controls.Add(Me.rbmarg2)
        Me.GroupBox15.Controls.Add(Me.rbmarg)
        Me.GroupBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(356, 117)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(333, 43)
        Me.GroupBox15.TabIndex = 59
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Controlar el precio contra un margen minimo"
        '
        'txtmargen
        '
        Me.txtmargen.BackColor = System.Drawing.Color.White
        Me.txtmargen.Location = New System.Drawing.Point(192, 18)
        Me.txtmargen.Name = "txtmargen"
        Me.txtmargen.Size = New System.Drawing.Size(80, 20)
        Me.txtmargen.TabIndex = 13
        Me.txtmargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Margen %"
        '
        'rbmarg2
        '
        Me.rbmarg2.AutoSize = True
        Me.rbmarg2.Checked = True
        Me.rbmarg2.Location = New System.Drawing.Point(19, 20)
        Me.rbmarg2.Name = "rbmarg2"
        Me.rbmarg2.Size = New System.Drawing.Size(43, 17)
        Me.rbmarg2.TabIndex = 11
        Me.rbmarg2.TabStop = True
        Me.rbmarg2.Text = "NO"
        Me.rbmarg2.UseVisualStyleBackColor = True
        '
        'rbmarg
        '
        Me.rbmarg.AutoSize = True
        Me.rbmarg.Location = New System.Drawing.Point(78, 20)
        Me.rbmarg.Name = "rbmarg"
        Me.rbmarg.Size = New System.Drawing.Size(37, 17)
        Me.rbmarg.TabIndex = 10
        Me.rbmarg.Text = "SI"
        Me.rbmarg.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox13.Controls.Add(Me.txtbodega)
        Me.GroupBox13.Controls.Add(Me.cbbod)
        Me.GroupBox13.Controls.Add(Me.rbbodpre2)
        Me.GroupBox13.Controls.Add(Me.rbbodpre)
        Me.GroupBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(23, 117)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(300, 43)
        Me.GroupBox13.TabIndex = 58
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Bodega pre-determinada"
        '
        'txtbodega
        '
        Me.txtbodega.BackColor = System.Drawing.Color.White
        Me.txtbodega.Enabled = False
        Me.txtbodega.Location = New System.Drawing.Point(194, 18)
        Me.txtbodega.Name = "txtbodega"
        Me.txtbodega.Size = New System.Drawing.Size(96, 20)
        Me.txtbodega.TabIndex = 14
        '
        'cbbod
        '
        Me.cbbod.BackColor = System.Drawing.Color.White
        Me.cbbod.ContextMenuStrip = Me.mimenu
        Me.cbbod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbod.FormattingEnabled = True
        Me.cbbod.Location = New System.Drawing.Point(146, 17)
        Me.cbbod.Name = "cbbod"
        Me.cbbod.Size = New System.Drawing.Size(44, 21)
        Me.cbbod.TabIndex = 12
        '
        'mimenu
        '
        Me.mimenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueEsEstoToolStripMenuItem})
        Me.mimenu.Name = "mimenu"
        Me.mimenu.Size = New System.Drawing.Size(146, 26)
        '
        'QueEsEstoToolStripMenuItem
        '
        Me.QueEsEstoToolStripMenuItem.Name = "QueEsEstoToolStripMenuItem"
        Me.QueEsEstoToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.QueEsEstoToolStripMenuItem.Text = "¿Que es esto?"
        '
        'rbbodpre2
        '
        Me.rbbodpre2.AutoSize = True
        Me.rbbodpre2.Checked = True
        Me.rbbodpre2.Location = New System.Drawing.Point(19, 20)
        Me.rbbodpre2.Name = "rbbodpre2"
        Me.rbbodpre2.Size = New System.Drawing.Size(43, 17)
        Me.rbbodpre2.TabIndex = 11
        Me.rbbodpre2.TabStop = True
        Me.rbbodpre2.Text = "NO"
        Me.rbbodpre2.UseVisualStyleBackColor = True
        '
        'rbbodpre
        '
        Me.rbbodpre.AutoSize = True
        Me.rbbodpre.Location = New System.Drawing.Point(79, 20)
        Me.rbbodpre.Name = "rbbodpre"
        Me.rbbodpre.Size = New System.Drawing.Size(66, 17)
        Me.rbbodpre.TabIndex = 10
        Me.rbbodpre.Text = "SI Cuál"
        Me.rbbodpre.UseVisualStyleBackColor = True
        '
        'GroupBox22
        '
        Me.GroupBox22.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox22.Controls.Add(Me.gcfp)
        Me.GroupBox22.Controls.Add(Me.rbfp2)
        Me.GroupBox22.Controls.Add(Me.rbfp)
        Me.GroupBox22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox22.Location = New System.Drawing.Point(42, 267)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(653, 67)
        Me.GroupBox22.TabIndex = 33
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Forma de pago predeterminada"
        '
        'gcfp
        '
        Me.gcfp.BackColor = System.Drawing.Color.Transparent
        Me.gcfp.Controls.Add(Me.rbcualfp4)
        Me.gcfp.Controls.Add(Me.rbcualfp2)
        Me.gcfp.Controls.Add(Me.rbcualfp3)
        Me.gcfp.Controls.Add(Me.rbcualfp1)
        Me.gcfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcfp.Location = New System.Drawing.Point(221, 10)
        Me.gcfp.Name = "gcfp"
        Me.gcfp.Size = New System.Drawing.Size(368, 46)
        Me.gcfp.TabIndex = 21
        Me.gcfp.TabStop = False
        '
        'rbcualfp4
        '
        Me.rbcualfp4.AutoSize = True
        Me.rbcualfp4.Location = New System.Drawing.Point(288, 20)
        Me.rbcualfp4.Name = "rbcualfp4"
        Me.rbcualfp4.Size = New System.Drawing.Size(49, 17)
        Me.rbcualfp4.TabIndex = 13
        Me.rbcualfp4.Text = "Otra"
        Me.rbcualfp4.UseVisualStyleBackColor = True
        '
        'rbcualfp2
        '
        Me.rbcualfp2.AutoSize = True
        Me.rbcualfp2.Location = New System.Drawing.Point(114, 20)
        Me.rbcualfp2.Name = "rbcualfp2"
        Me.rbcualfp2.Size = New System.Drawing.Size(65, 17)
        Me.rbcualfp2.TabIndex = 12
        Me.rbcualfp2.Text = "Tarjeta"
        Me.rbcualfp2.UseVisualStyleBackColor = True
        '
        'rbcualfp3
        '
        Me.rbcualfp3.AutoSize = True
        Me.rbcualfp3.Checked = True
        Me.rbcualfp3.Location = New System.Drawing.Point(195, 20)
        Me.rbcualfp3.Name = "rbcualfp3"
        Me.rbcualfp3.Size = New System.Drawing.Size(72, 17)
        Me.rbcualfp3.TabIndex = 11
        Me.rbcualfp3.TabStop = True
        Me.rbcualfp3.Text = "Efectivo"
        Me.rbcualfp3.UseVisualStyleBackColor = True
        '
        'rbcualfp1
        '
        Me.rbcualfp1.AutoSize = True
        Me.rbcualfp1.Location = New System.Drawing.Point(19, 20)
        Me.rbcualfp1.Name = "rbcualfp1"
        Me.rbcualfp1.Size = New System.Drawing.Size(68, 17)
        Me.rbcualfp1.TabIndex = 10
        Me.rbcualfp1.Text = "Cheque"
        Me.rbcualfp1.UseVisualStyleBackColor = True
        '
        'rbfp2
        '
        Me.rbfp2.AutoSize = True
        Me.rbfp2.Location = New System.Drawing.Point(40, 31)
        Me.rbfp2.Name = "rbfp2"
        Me.rbfp2.Size = New System.Drawing.Size(43, 17)
        Me.rbfp2.TabIndex = 11
        Me.rbfp2.Text = "NO"
        Me.rbfp2.UseVisualStyleBackColor = True
        '
        'rbfp
        '
        Me.rbfp.AutoSize = True
        Me.rbfp.Checked = True
        Me.rbfp.Location = New System.Drawing.Point(110, 31)
        Me.rbfp.Name = "rbfp"
        Me.rbfp.Size = New System.Drawing.Size(87, 17)
        Me.rbfp.TabIndex = 10
        Me.rbfp.TabStop = True
        Me.rbfp.Text = "SI ¿CUAL?"
        Me.rbfp.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox20.Controls.Add(Me.Txtcc2)
        Me.GroupBox20.Controls.Add(Me.Label7)
        Me.GroupBox20.Controls.Add(Me.Label8)
        Me.GroupBox20.Controls.Add(Me.txtcc)
        Me.GroupBox20.Controls.Add(Me.rbcc2)
        Me.GroupBox20.Controls.Add(Me.rbcc)
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(357, 199)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(338, 52)
        Me.GroupBox20.TabIndex = 32
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Concepto comisionable pre-determinado"
        '
        'Txtcc2
        '
        Me.Txtcc2.Enabled = False
        Me.Txtcc2.Location = New System.Drawing.Point(220, 18)
        Me.Txtcc2.Name = "Txtcc2"
        Me.Txtcc2.Size = New System.Drawing.Size(59, 20)
        Me.Txtcc2.TabIndex = 18
        Me.Txtcc2.Text = "30"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(205, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Dias de Recaudo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(83, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Doble clic para seleccionar"
        '
        'txtcc
        '
        Me.txtcc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcc.Location = New System.Drawing.Point(126, 18)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.ReadOnly = True
        Me.txtcc.Size = New System.Drawing.Size(60, 20)
        Me.txtcc.TabIndex = 14
        Me.txtcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbcc2
        '
        Me.rbcc2.AutoSize = True
        Me.rbcc2.Checked = True
        Me.rbcc2.Location = New System.Drawing.Point(28, 20)
        Me.rbcc2.Name = "rbcc2"
        Me.rbcc2.Size = New System.Drawing.Size(43, 17)
        Me.rbcc2.TabIndex = 11
        Me.rbcc2.TabStop = True
        Me.rbcc2.Text = "NO"
        Me.rbcc2.UseVisualStyleBackColor = True
        '
        'rbcc
        '
        Me.rbcc.AutoSize = True
        Me.rbcc.Location = New System.Drawing.Point(83, 20)
        Me.rbcc.Name = "rbcc"
        Me.rbcc.Size = New System.Drawing.Size(37, 17)
        Me.rbcc.TabIndex = 10
        Me.rbcc.Text = "SI"
        Me.rbcc.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox21.Controls.Add(Me.rbcentro2)
        Me.GroupBox21.Controls.Add(Me.rbcentro)
        Me.GroupBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox21.Location = New System.Drawing.Point(23, 199)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(300, 43)
        Me.GroupBox21.TabIndex = 31
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Solicitar centro de costos "
        '
        'rbcentro2
        '
        Me.rbcentro2.AutoSize = True
        Me.rbcentro2.Checked = True
        Me.rbcentro2.Location = New System.Drawing.Point(78, 20)
        Me.rbcentro2.Name = "rbcentro2"
        Me.rbcentro2.Size = New System.Drawing.Size(43, 17)
        Me.rbcentro2.TabIndex = 11
        Me.rbcentro2.TabStop = True
        Me.rbcentro2.Text = "NO"
        Me.rbcentro2.UseVisualStyleBackColor = True
        '
        'rbcentro
        '
        Me.rbcentro.AutoSize = True
        Me.rbcentro.Location = New System.Drawing.Point(19, 20)
        Me.rbcentro.Name = "rbcentro"
        Me.rbcentro.Size = New System.Drawing.Size(37, 17)
        Me.rbcentro.TabIndex = 10
        Me.rbcentro.Text = "SI"
        Me.rbcentro.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.AttachedControl = Me.TabControlPanel2
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Text = "Página 2/3"
        Me.Tab2.Visible = False
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.GroupBox2)
        Me.TabControlPanel3.Controls.Add(Me.GroupBox8)
        Me.TabControlPanel3.Controls.Add(Me.cmdguardar)
        Me.TabControlPanel3.Controls.Add(Me.cmdcancelar)
        Me.TabControlPanel3.Controls.Add(Me.gped)
        Me.TabControlPanel3.Controls.Add(Me.Label5)
        Me.TabControlPanel3.Controls.Add(Me.Label4)
        Me.TabControlPanel3.Controls.Add(Me.lbnumero)
        Me.TabControlPanel3.Controls.Add(Me.Label2)
        Me.TabControlPanel3.Controls.Add(Me.Label3)
        Me.TabControlPanel3.Controls.Add(Me.lbcaution)
        Me.TabControlPanel3.Controls.Add(Me.GroupBox23)
        Me.TabControlPanel3.Controls.Add(Me.gcot)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(759, 363)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.Tab3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rb_imp_decN)
        Me.GroupBox2.Controls.Add(Me.rb_imp_decS)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 301)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(265, 43)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imprimir Valores Con Decimales"
        '
        'rb_imp_decN
        '
        Me.rb_imp_decN.AutoSize = True
        Me.rb_imp_decN.Location = New System.Drawing.Point(141, 19)
        Me.rb_imp_decN.Name = "rb_imp_decN"
        Me.rb_imp_decN.Size = New System.Drawing.Size(123, 17)
        Me.rb_imp_decN.TabIndex = 11
        Me.rb_imp_decN.Text = "NO Ej: 1.000.000"
        Me.rb_imp_decN.UseVisualStyleBackColor = True
        '
        'rb_imp_decS
        '
        Me.rb_imp_decS.AutoSize = True
        Me.rb_imp_decS.Checked = True
        Me.rb_imp_decS.Location = New System.Drawing.Point(7, 20)
        Me.rb_imp_decS.Name = "rb_imp_decS"
        Me.rb_imp_decS.Size = New System.Drawing.Size(135, 17)
        Me.rb_imp_decS.TabIndex = 10
        Me.rb_imp_decS.TabStop = True
        Me.rb_imp_decS.Text = "SI Ej: 1.000.000,00"
        Me.rb_imp_decS.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.txtcomentarioini)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.txtcomentario)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.cbregimen)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(385, 166)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(370, 118)
        Me.GroupBox8.TabIndex = 102
        Me.GroupBox8.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(201, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "COMENTARIO FINAL"
        '
        'txtcomentario
        '
        Me.txtcomentario.Location = New System.Drawing.Point(202, 54)
        Me.txtcomentario.Multiline = True
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(157, 58)
        Me.txtcomentario.TabIndex = 103
        '
        'cbregimen
        '
        Me.cbregimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbregimen.FormattingEnabled = True
        Me.cbregimen.Items.AddRange(New Object() {"", "PERSONA NATURAL", "REGIMEN SIMPLIFICADO", "REGIMEN COMUN"})
        Me.cbregimen.Location = New System.Drawing.Point(142, 12)
        Me.cbregimen.Name = "cbregimen"
        Me.cbregimen.Size = New System.Drawing.Size(220, 21)
        Me.cbregimen.TabIndex = 101
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 13)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "TIPO DE COMPAÑIA"
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(297, 290)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 97
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "guardar parametros Alt+G")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(373, 290)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 98
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "salir sin guardar los cambios Alt+C")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'gped
        '
        Me.gped.BackColor = System.Drawing.Color.Transparent
        Me.gped.Controls.Add(Me.pdfped2)
        Me.gped.Controls.Add(Me.cmd_vp_ped)
        Me.gped.Controls.Add(Me.cmdlogoped)
        Me.gped.Controls.Add(Me.pdfped)
        Me.gped.Controls.Add(Me.ticped)
        Me.gped.Controls.Add(Me.imgfoto2)
        Me.gped.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gped.Location = New System.Drawing.Point(385, 59)
        Me.gped.Name = "gped"
        Me.gped.Size = New System.Drawing.Size(370, 102)
        Me.gped.TabIndex = 95
        Me.gped.TabStop = False
        '
        'pdfped2
        '
        Me.pdfped2.AutoSize = True
        Me.pdfped2.Location = New System.Drawing.Point(14, 38)
        Me.pdfped2.Name = "pdfped2"
        Me.pdfped2.Size = New System.Drawing.Size(60, 17)
        Me.pdfped2.TabIndex = 93
        Me.pdfped2.Text = "PDF 2"
        Me.pdfped2.UseVisualStyleBackColor = True
        '
        'cmd_vp_ped
        '
        Me.cmd_vp_ped.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_ped.Location = New System.Drawing.Point(244, 9)
        Me.cmd_vp_ped.Name = "cmd_vp_ped"
        Me.cmd_vp_ped.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_ped.TabIndex = 92
        Me.ToolTip1.SetToolTip(Me.cmd_vp_ped, "vista previa")
        Me.cmd_vp_ped.UseVisualStyleBackColor = True
        '
        'cmdlogoped
        '
        Me.cmdlogoped.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogoped.Location = New System.Drawing.Point(288, 77)
        Me.cmdlogoped.Name = "cmdlogoped"
        Me.cmdlogoped.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogoped.TabIndex = 13
        Me.cmdlogoped.Text = "Examinar..."
        Me.cmdlogoped.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogoped.UseVisualStyleBackColor = True
        '
        'pdfped
        '
        Me.pdfped.AutoSize = True
        Me.pdfped.Checked = True
        Me.pdfped.Location = New System.Drawing.Point(14, 15)
        Me.pdfped.Name = "pdfped"
        Me.pdfped.Size = New System.Drawing.Size(49, 17)
        Me.pdfped.TabIndex = 12
        Me.pdfped.TabStop = True
        Me.pdfped.Text = "PDF"
        Me.pdfped.UseVisualStyleBackColor = True
        '
        'ticped
        '
        Me.ticped.AutoSize = True
        Me.ticped.Location = New System.Drawing.Point(14, 61)
        Me.ticped.Name = "ticped"
        Me.ticped.Size = New System.Drawing.Size(69, 17)
        Me.ticped.TabIndex = 10
        Me.ticped.Text = "TICKET"
        Me.ticped.UseVisualStyleBackColor = True
        '
        'imgfoto2
        '
        Me.imgfoto2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imgfoto2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgfoto2.Location = New System.Drawing.Point(283, 11)
        Me.imgfoto2.Name = "imgfoto2"
        Me.imgfoto2.Size = New System.Drawing.Size(80, 65)
        Me.imgfoto2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgfoto2.TabIndex = 87
        Me.imgfoto2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(9, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(297, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Formato pre-determinado de cotizaciones"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(447, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(267, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Formato pre-determinado de pedidos"
        '
        'lbnumero
        '
        Me.lbnumero.BackColor = System.Drawing.Color.Transparent
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(9, 0)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(747, 24)
        Me.lbnumero.TabIndex = 90
        Me.lbnumero.Text = "FORMATOS PARA IMPRIMIR"
        Me.lbnumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(265, 16)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Formato pre-determinado de facturas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(758, 24)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "____________________________________________________________________"
        '
        'lbcaution
        '
        Me.lbcaution.AutoSize = True
        Me.lbcaution.BackColor = System.Drawing.Color.Transparent
        Me.lbcaution.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcaution.ForeColor = System.Drawing.Color.DarkRed
        Me.lbcaution.Location = New System.Drawing.Point(448, 307)
        Me.lbcaution.Name = "lbcaution"
        Me.lbcaution.Size = New System.Drawing.Size(305, 48)
        Me.lbcaution.TabIndex = 99
        Me.lbcaution.Text = "* Nota: para los reportes PDF se recomienda escoger una imagen JPG de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  1. Tama" & _
            "ño: 100 x 100 pixeles aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  2. Peso max:  1 MB aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        '
        'GroupBox23
        '
        Me.GroupBox23.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox23.Controls.Add(Me.pdffac2)
        Me.GroupBox23.Controls.Add(Me.cmd_vp_fact)
        Me.GroupBox23.Controls.Add(Me.cmdlogofac)
        Me.GroupBox23.Controls.Add(Me.pdffac)
        Me.GroupBox23.Controls.Add(Me.ticfac)
        Me.GroupBox23.Controls.Add(Me.imgfoto)
        Me.GroupBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox23.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(370, 102)
        Me.GroupBox23.TabIndex = 94
        Me.GroupBox23.TabStop = False
        '
        'pdffac2
        '
        Me.pdffac2.AutoSize = True
        Me.pdffac2.Location = New System.Drawing.Point(17, 38)
        Me.pdffac2.Name = "pdffac2"
        Me.pdffac2.Size = New System.Drawing.Size(60, 17)
        Me.pdffac2.TabIndex = 92
        Me.pdffac2.Text = "PDF 2"
        Me.pdffac2.UseVisualStyleBackColor = True
        '
        'cmd_vp_fact
        '
        Me.cmd_vp_fact.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_fact.Location = New System.Drawing.Point(238, 9)
        Me.cmd_vp_fact.Name = "cmd_vp_fact"
        Me.cmd_vp_fact.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_fact.TabIndex = 91
        Me.ToolTip1.SetToolTip(Me.cmd_vp_fact, "vista previa")
        Me.cmd_vp_fact.UseVisualStyleBackColor = True
        '
        'cmdlogofac
        '
        Me.cmdlogofac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogofac.Location = New System.Drawing.Point(283, 77)
        Me.cmdlogofac.Name = "cmdlogofac"
        Me.cmdlogofac.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogofac.TabIndex = 13
        Me.cmdlogofac.Text = "Examinar..."
        Me.cmdlogofac.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogofac.UseVisualStyleBackColor = True
        '
        'pdffac
        '
        Me.pdffac.AutoSize = True
        Me.pdffac.Checked = True
        Me.pdffac.Location = New System.Drawing.Point(17, 15)
        Me.pdffac.Name = "pdffac"
        Me.pdffac.Size = New System.Drawing.Size(60, 17)
        Me.pdffac.TabIndex = 12
        Me.pdffac.TabStop = True
        Me.pdffac.Text = "PDF 1"
        Me.pdffac.UseVisualStyleBackColor = True
        '
        'ticfac
        '
        Me.ticfac.AutoSize = True
        Me.ticfac.Location = New System.Drawing.Point(17, 61)
        Me.ticfac.Name = "ticfac"
        Me.ticfac.Size = New System.Drawing.Size(69, 17)
        Me.ticfac.TabIndex = 10
        Me.ticfac.Text = "TICKET"
        Me.ticfac.UseVisualStyleBackColor = True
        '
        'imgfoto
        '
        Me.imgfoto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imgfoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgfoto.Location = New System.Drawing.Point(279, 11)
        Me.imgfoto.Name = "imgfoto"
        Me.imgfoto.Size = New System.Drawing.Size(80, 65)
        Me.imgfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgfoto.TabIndex = 86
        Me.imgfoto.TabStop = False
        '
        'gcot
        '
        Me.gcot.BackColor = System.Drawing.Color.Transparent
        Me.gcot.Controls.Add(Me.pdfcot2)
        Me.gcot.Controls.Add(Me.cmd_vp_cot)
        Me.gcot.Controls.Add(Me.cmdlogocot)
        Me.gcot.Controls.Add(Me.pdfcot)
        Me.gcot.Controls.Add(Me.ticcot)
        Me.gcot.Controls.Add(Me.imgfoto3)
        Me.gcot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcot.Location = New System.Drawing.Point(6, 182)
        Me.gcot.Name = "gcot"
        Me.gcot.Size = New System.Drawing.Size(370, 102)
        Me.gcot.TabIndex = 96
        Me.gcot.TabStop = False
        '
        'pdfcot2
        '
        Me.pdfcot2.AutoSize = True
        Me.pdfcot2.Location = New System.Drawing.Point(17, 41)
        Me.pdfcot2.Name = "pdfcot2"
        Me.pdfcot2.Size = New System.Drawing.Size(60, 17)
        Me.pdfcot2.TabIndex = 93
        Me.pdfcot2.Text = "PDF 2"
        Me.pdfcot2.UseVisualStyleBackColor = True
        '
        'cmd_vp_cot
        '
        Me.cmd_vp_cot.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_cot.Location = New System.Drawing.Point(238, 11)
        Me.cmd_vp_cot.Name = "cmd_vp_cot"
        Me.cmd_vp_cot.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_cot.TabIndex = 92
        Me.ToolTip1.SetToolTip(Me.cmd_vp_cot, "vista previa")
        Me.cmd_vp_cot.UseVisualStyleBackColor = True
        '
        'cmdlogocot
        '
        Me.cmdlogocot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogocot.Location = New System.Drawing.Point(284, 78)
        Me.cmdlogocot.Name = "cmdlogocot"
        Me.cmdlogocot.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogocot.TabIndex = 13
        Me.cmdlogocot.Text = "Examinar..."
        Me.cmdlogocot.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogocot.UseVisualStyleBackColor = True
        '
        'pdfcot
        '
        Me.pdfcot.AutoSize = True
        Me.pdfcot.Checked = True
        Me.pdfcot.Location = New System.Drawing.Point(17, 15)
        Me.pdfcot.Name = "pdfcot"
        Me.pdfcot.Size = New System.Drawing.Size(49, 17)
        Me.pdfcot.TabIndex = 12
        Me.pdfcot.TabStop = True
        Me.pdfcot.Text = "PDF"
        Me.pdfcot.UseVisualStyleBackColor = True
        '
        'ticcot
        '
        Me.ticcot.AutoSize = True
        Me.ticcot.Enabled = False
        Me.ticcot.Location = New System.Drawing.Point(17, 66)
        Me.ticcot.Name = "ticcot"
        Me.ticcot.Size = New System.Drawing.Size(69, 17)
        Me.ticcot.TabIndex = 10
        Me.ticcot.Text = "TICKET"
        Me.ticcot.UseVisualStyleBackColor = True
        '
        'imgfoto3
        '
        Me.imgfoto3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imgfoto3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgfoto3.Location = New System.Drawing.Point(279, 12)
        Me.imgfoto3.Name = "imgfoto3"
        Me.imgfoto3.Size = New System.Drawing.Size(80, 65)
        Me.imgfoto3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgfoto3.TabIndex = 88
        Me.imgfoto3.TabStop = False
        '
        'Tab3
        '
        Me.Tab3.AttachedControl = Me.TabControlPanel3
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Text = "Página 3/3"
        Me.Tab3.Visible = False
        '
        'cmdatras
        '
        Me.cmdatras.BackColor = System.Drawing.Color.White
        Me.cmdatras.Enabled = False
        Me.cmdatras.ForeColor = System.Drawing.Color.Transparent
        Me.cmdatras.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdatras.Location = New System.Drawing.Point(3, 3)
        Me.cmdatras.Name = "cmdatras"
        Me.cmdatras.Size = New System.Drawing.Size(66, 68)
        Me.cmdatras.TabIndex = 19
        Me.cmdatras.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdatras, "atrás Alt+A")
        Me.cmdatras.UseVisualStyleBackColor = False
        '
        'cmdsgt
        '
        Me.cmdsgt.BackColor = System.Drawing.Color.White
        Me.cmdsgt.ForeColor = System.Drawing.Color.Transparent
        Me.cmdsgt.Image = Global.SAE.My.Resources.Resources._next
        Me.cmdsgt.Location = New System.Drawing.Point(679, 3)
        Me.cmdsgt.Name = "cmdsgt"
        Me.cmdsgt.Size = New System.Drawing.Size(66, 68)
        Me.cmdsgt.TabIndex = 80
        Me.cmdsgt.Text = "&S"
        Me.cmdsgt.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsgt, "siguiente Alt+S")
        Me.cmdsgt.UseVisualStyleBackColor = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.lbprint)
        Me.GroupPanel2.Controls.Add(Me.lbpara)
        Me.GroupPanel2.Controls.Add(Me.lbfact)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.cmdsgt)
        Me.GroupPanel2.Controls.Add(Me.cmdatras)
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 399)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(759, 85)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.TabIndex = 76
        '
        'lbprint
        '
        Me.lbprint.AutoSize = True
        Me.lbprint.BackColor = System.Drawing.Color.Transparent
        Me.lbprint.Font = New System.Drawing.Font("Courier New", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbprint.ForeColor = System.Drawing.Color.Black
        Me.lbprint.Location = New System.Drawing.Point(94, 55)
        Me.lbprint.Name = "lbprint"
        Me.lbprint.Size = New System.Drawing.Size(30, 8)
        Me.lbprint.TabIndex = 84
        Me.lbprint.Text = "print"
        Me.lbprint.Visible = False
        '
        'lbpara
        '
        Me.lbpara.AutoSize = True
        Me.lbpara.BackColor = System.Drawing.Color.Transparent
        Me.lbpara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbpara.ForeColor = System.Drawing.Color.Maroon
        Me.lbpara.Location = New System.Drawing.Point(250, 55)
        Me.lbpara.Name = "lbpara"
        Me.lbpara.Size = New System.Drawing.Size(251, 16)
        Me.lbpara.TabIndex = 83
        Me.lbpara.Text = "Nota: No hay parametros en los registos."
        '
        'lbfact
        '
        Me.lbfact.AutoSize = True
        Me.lbfact.BackColor = System.Drawing.Color.Transparent
        Me.lbfact.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfact.ForeColor = System.Drawing.Color.Black
        Me.lbfact.Location = New System.Drawing.Point(536, 23)
        Me.lbfact.Name = "lbfact"
        Me.lbfact.Size = New System.Drawing.Size(84, 24)
        Me.lbfact.TabIndex = 82
        Me.lbfact.Text = "RAPIDA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(151, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(388, 24)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "SAE PARAMETRIZACIÓN DE FACTURA"
        '
        'OPF
        '
        Me.OPF.FileName = "OpenFileDialog1"
        '
        'OPF2
        '
        Me.OPF2.FileName = "OpenFileDialog1"
        '
        'OPF3
        '
        Me.OPF3.FileName = "OpenFileDialog1"
        '
        'imprimir
        '
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 13)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "COMENTARIO INICIAL"
        '
        'txtcomentarioini
        '
        Me.txtcomentarioini.Location = New System.Drawing.Point(13, 51)
        Me.txtcomentarioini.Multiline = True
        Me.txtcomentarioini.Name = "txtcomentarioini"
        Me.txtcomentarioini.Size = New System.Drawing.Size(157, 58)
        Me.txtcomentarioini.TabIndex = 104
        '
        'FrmParaFactRapida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(768, 488)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Tabcont)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParaFactRapida"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE PARAMETRIZACIÓN DE FACTURAS.    Alt+F4=Salir sin guardar"
        CType(Me.Tabcont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabcont.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.grNF.ResumeLayout(False)
        Me.grNF.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grupoimprimir.ResumeLayout(False)
        Me.grupoimprimir.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.mimenu.ResumeLayout(False)
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        Me.gcfp.ResumeLayout(False)
        Me.gcfp.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.gped.ResumeLayout(False)
        Me.gped.PerformLayout()
        CType(Me.imgfoto2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        CType(Me.imgfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcot.ResumeLayout(False)
        Me.gcot.PerformLayout()
        CType(Me.imgfoto3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabcont As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tab3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tab2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tab1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents grupoimprimir As System.Windows.Forms.GroupBox
    Friend WithEvents rbdoc2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbdoc1 As System.Windows.Forms.RadioButton
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnumf2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbnumf As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbfec2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbfec1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbinv2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbinv As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents rbclie2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbclie As System.Windows.Forms.RadioButton
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtvendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtnitv As System.Windows.Forms.TextBox
    Friend WithEvents rbvendedor2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbvendedor As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents rbcc2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcc As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents rbcentro2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcentro As System.Windows.Forms.RadioButton
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsgt As System.Windows.Forms.Button
    Friend WithEvents cmdatras As System.Windows.Forms.Button
    Friend WithEvents lbfact As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txttipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbpara As System.Windows.Forms.Label
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEstoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OPF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents imgfoto As System.Windows.Forms.PictureBox
    Friend WithEvents imgfoto3 As System.Windows.Forms.PictureBox
    Friend WithEvents imgfoto2 As System.Windows.Forms.PictureBox
    Friend WithEvents OPF2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OPF3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents gcfp As System.Windows.Forms.GroupBox
    Friend WithEvents rbcualfp4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcualfp2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcualfp3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcualfp1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbfp2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbfp As System.Windows.Forms.RadioButton
    Friend WithEvents gcot As System.Windows.Forms.GroupBox
    Friend WithEvents cmdlogocot As System.Windows.Forms.Button
    Friend WithEvents pdfcot As System.Windows.Forms.RadioButton
    Friend WithEvents ticcot As System.Windows.Forms.RadioButton
    Friend WithEvents gped As System.Windows.Forms.GroupBox
    Friend WithEvents cmdlogoped As System.Windows.Forms.Button
    Friend WithEvents pdfped As System.Windows.Forms.RadioButton
    Friend WithEvents ticped As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdlogofac As System.Windows.Forms.Button
    Friend WithEvents pdffac As System.Windows.Forms.RadioButton
    Friend WithEvents ticfac As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents ChPA As System.Windows.Forms.CheckBox
    Friend WithEvents rbfacdifuniemp2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbfacdifuniemp As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbcodinv2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcodinv As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmargen As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbmarg2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbmarg As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents cbbod As System.Windows.Forms.ComboBox
    Friend WithEvents rbbodpre2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbbodpre As System.Windows.Forms.RadioButton
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents txtbodega As System.Windows.Forms.TextBox
    Friend WithEvents lbcaution As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmd_vp_ped As System.Windows.Forms.Button
    Friend WithEvents cmd_vp_fact As System.Windows.Forms.Button
    Friend WithEvents cmd_vp_cot As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cbregimen As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents imprimir As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcomentario As System.Windows.Forms.TextBox
    Friend WithEvents pdfped2 As System.Windows.Forms.RadioButton
    Friend WithEvents pdffac2 As System.Windows.Forms.RadioButton
    Friend WithEvents pdfcot2 As System.Windows.Forms.RadioButton
    Friend WithEvents lbprint As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_imp_decN As System.Windows.Forms.RadioButton
    Friend WithEvents rb_imp_decS As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txtcc2 As System.Windows.Forms.TextBox
    Friend WithEvents chVend As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbBAp As System.Windows.Forms.RadioButton
    Friend WithEvents rbBNit As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_itemS As System.Windows.Forms.RadioButton
    Friend WithEvents rb_itemN As System.Windows.Forms.RadioButton
    Friend WithEvents txtitems As System.Windows.Forms.ComboBox
    Friend WithEvents grNF As System.Windows.Forms.GroupBox
    Friend WithEvents rdnf_s As System.Windows.Forms.RadioButton
    Friend WithEvents rdnf_n As System.Windows.Forms.RadioButton
    Friend WithEvents txtcomentarioini As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
